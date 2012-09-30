Imports System.Net.Sockets
Imports System.IO
Imports System.Text

Public Class tcpConnection
    Private Enum RequestTags As Byte
        SystemName = 0
        Connect = 1
        Disconnect = 2
        DataTransfer = 3
        StringTransfer = 4
        ByteTransfer = 5
        ChatTransfer = 6
    End Enum

    Private PACKET_SIZE As Int16 = 10024
    Private client As New TcpClient
    Private readByte(0) As Byte
    Private myTag As Byte
    Private isConnected As Boolean 'set to true when connection is granted by server

#Region "Declare events"
    Public Event DataReceived(ByVal sender As tcpConnection, ByVal msgTag As Byte, ByVal mstream As MemoryStream)
    Public Event MessageReceived(ByVal sender As tcpConnection, ByVal msgTag As Byte)
    Public Event StringReceived(ByVal Sender As tcpConnection, ByVal msgTag As Byte, ByVal message As String)
    Public Event ChatReceived(ByVal Sender As tcpConnection, ByVal msgTag As Byte, ByVal message As String)
    Public Event TransferProgress(ByVal Sender As tcpConnection, ByVal msgTag As Byte, ByVal Percentage As Single)
    Public Event Connect(ByVal sender As tcpConnection)
    Public Event Disconnect(ByVal sender As tcpConnection)
#End Region

#Region "Overloaded Constructors and destructor"
    Public Sub New(ByVal client As TcpClient, ByVal PacketSize As Int16)
        Try
            'instantiates class for use in server
            'don't handle errors here, allow caller to handle them
            PACKET_SIZE = PacketSize
            Me.client = client
            'Start an asynchronous read from the NetworkStream
            Me.client.GetStream.BeginRead(readByte, 0, 1, AddressOf ReceiveOneByte, Nothing)
        Catch ex As Exception
            'Error
        End Try
    End Sub
    Public Sub Disconnect_Server()
        'Disconnect from server
        client.Close()
        RaiseEvent Disconnect(Me)
    End Sub
    Public WithEvents TimerTimout As New System.Timers.Timer
    Sub ConnectTimout() Handles TimerTimout.Elapsed
        'Stop connecting after timer
        client.Close()
    End Sub
    Public Sub New(ByVal IPServer As String, ByVal Port As Integer, Optional ByVal Timout As Integer = 2000)
        'instantiates class for use in client
        'don't handle errors here, allow caller to handle them

        '' Configure Client
        Me.client.ReceiveTimeout = 1000
        Me.client.SendTimeout = 1000
        'create a new TcpClient and make a synchronous connection 
        'attempt to the provided host name and port number
        TimerTimout.Interval = Timout
        TimerTimout.Start()
        Me.client.Connect(IPServer, Port)
        TimerTimout.Stop()
        'Send Machine name to server
        Try
            Dim serverStream = client.GetStream()
            Dim outStream As Byte() = _
            System.Text.Encoding.ASCII.GetBytes(My.Computer.Name + "$")
            serverStream.Write(outStream, 0, outStream.Length)
            serverStream.Flush()
        Catch ex As Exception

        End Try
        'Start an asynchronous read from the NetworkStream
        Me.client.GetStream.BeginRead(readByte, 0, 1, AddressOf ReceiveOneByte, Nothing)
    End Sub

    Protected Overrides Sub finalize()
        'we don't care about errors in this section since we are ending
        On Error Resume Next
        If isConnected Then Send(RequestTags.Disconnect)
        client.GetStream.Close()
        client.Close()
        client = Nothing
    End Sub

#End Region

    Public Property Tag() As Byte
        Get
            Tag = myTag
        End Get
        Set(ByVal value As Byte)
            myTag = value
        End Set
    End Property

    Private Sub ReceiveOneByte(ByVal ar As IAsyncResult)
        'This is where the data is received.  All data communications 
        'begin with a one-byte identifier that tells the class how to
        'handle what is to follow.
        Dim r As BinaryReader
        Dim sreader As StreamReader
        Dim bytesFrom(10024) As Byte
        Dim mStream As MemoryStream
        Dim lData As Int32
        Dim DataFromClient As String = Nothing
        Dim readBuffer(PACKET_SIZE) As Byte
        Dim StrBuffer(PACKET_SIZE) As Char
        Dim passThroughByte As Byte
        Dim nData As Integer
        Dim lenData As Integer
        Try
            SyncLock client.GetStream
                'if error occurs here then socket has closed
                Try
                    client.GetStream.EndRead(ar)
                Catch
                    RaiseEvent Disconnect(Me)
                    Exit Sub
                End Try
            End SyncLock

            'this is the instruction on how to handle the rest of the data to come.
            Select Case readByte(0)
                Case RequestTags.Connect
                    'sent from server to client informing client that a successful 
                    'connection negotiation has been made and the connection now exists.
                    isConnected = True 'identifies this class as on the client end
                    RaiseEvent Connect(Me)
                    SyncLock client.GetStream
                        r = New BinaryReader(client.GetStream)
                        PACKET_SIZE = r.ReadInt16
                        'Continue the asynchronous read from the NetworkStream
                        Me.client.GetStream.BeginRead(readByte, 0, 1, AddressOf ReceiveOneByte, Nothing)
                    End SyncLock

                Case RequestTags.Disconnect
                    'sent to either client or server
                    'propagated forward to Listener on server end
                    RaiseEvent Disconnect(Me)

                Case RequestTags.DataTransfer
                    'a block of data is coming
                    'Format of this transaction is
                    '   DataTransfer identifier byte
                    '   Pass-Through Byte contains user defined data
                    '   Length of data block (max size = 2,147,483,647 bytes)
                    SyncLock client.GetStream
                        r = New BinaryReader(client.GetStream)
                        'next we expect a pass-through byte
                        client.GetStream.Read(readByte, 0, 1)
                        passThroughByte = readByte(0)
                        'next expect length of data (Int32)
                        nData = r.ReadInt32
                        lenData = nData
                        'now comes the data, save it in a memory stream
                        mStream = New MemoryStream
                        While nData > 0
                            RaiseEvent TransferProgress(Me, passThroughByte, CSng(1.0 - nData / lenData))
                            lData = client.GetStream.Read(readBuffer, 0, PACKET_SIZE)
                            mStream.Write(readBuffer, 0, lData)
                            nData -= lData
                        End While
                        'Continue the asynchronous read from the NetworkStream
                        Me.client.GetStream.BeginRead(readByte, 0, 1, AddressOf ReceiveOneByte, Nothing)
                    End SyncLock
                    'once all data has arrived, pass it on to the end user as a stream
                    RaiseEvent DataReceived(Me, passThroughByte, mStream)
                    mStream.Dispose()

                Case RequestTags.StringTransfer
                    'a block of data is coming
                    'Format of this transaction is
                    '   DataTransfer identifier byte
                    '   Pass-Through Byte contains user defined data
                    '   Length of data block (max size = 2,147,483,647 bytes)
                    SyncLock client.GetStream
                        r = New BinaryReader(client.GetStream)
                        'next we expect a pass-through byte
                        client.GetStream.Read(readByte, 0, 1)
                        passThroughByte = readByte(0)
                        'next expect length of data (Int32)
                        nData = r.ReadInt32
                        lenData = nData
                        'Here we receive the transfer of string data in a block
                        'not to exceed PACKET_SIZE in length.
                        'now comes the data, save it in a memory stream
                        mStream = New MemoryStream
                        'Check if nData is Smaller than the ReadBuffer
                        'If it is larger than use the PACKET_SIZE as ofset
                        If nData > PACKET_SIZE Then
                            'Use packet size
                            While nData > 0
                                lData = client.GetStream.Read(readBuffer, 0, PACKET_SIZE)
                                mStream.Write(readBuffer, 0, lData)
                                nData -= lData
                            End While
                        Else
                            'Use ndata Length
                            While nData > 0
                                lData = client.GetStream.Read(readBuffer, 0, nData)
                                mStream.Write(readBuffer, 0, lData)
                                nData -= lData
                            End While
                        End If
                        'Continue the asynchronous read from the NetworkStream
                        Me.client.GetStream.BeginRead(readByte, 0, 1, AddressOf ReceiveOneByte, Nothing)
                    End SyncLock
                    'once all data has arrived, pass it on to the end user as a stream
                    mStream.Position = 0
                    sreader = New StreamReader(mStream)
                    Dim strX As New String(sreader.ReadToEnd().Substring(0, lenData))
                    RaiseEvent StringReceived(Me, passThroughByte, strX)
                    mStream.Dispose()
                Case RequestTags.ByteTransfer
                    'Here we receive a user-defined one-byte message
                    SyncLock client.GetStream
                        client.GetStream.Read(readByte, 0, 1)
                    End SyncLock
                    'pass byte on to end user
                    RaiseEvent MessageReceived(Me, readByte(0))
                    SyncLock client.GetStream
                        'Continue the asynchronous read from the NetworkStream
                        Me.client.GetStream.BeginRead(readByte, 0, 1, AddressOf ReceiveOneByte, Nothing)
                    End SyncLock

            End Select
        Catch ex As Exception
            'Error Client Disconnected
            Disconnect_Server()
        End Try
    End Sub


#Region "Overloaded methods to send data between client(s) and server"

    Public Sub Send(ByVal msgTag As Byte)
        Try
            ' This subroutine sends a one-byte response
            SyncLock client.GetStream
                Dim writer As New BinaryWriter(client.GetStream)
                'notify that 1-byte is coming
                writer.Write(RequestTags.ByteTransfer)
                'Send user defined message byte
                writer.Write(msgTag)
                ' Make sure all data is sent now.
                writer.Flush()
            End SyncLock
        Catch ex As Exception
            'Error
        End Try
    End Sub

    Public Sub Send(ByVal msgTag As Byte, ByVal strX As String)
        Try
            'sends array of byte data
            SyncLock client.GetStream
                Dim writer As New BinaryWriter(client.GetStream)
                'Notify that byte data is coming
                If msgTag = 6 Then
                    'Chat message
                    writer.Write(RequestTags.ChatTransfer)
                Else
                    'Other
                    writer.Write(RequestTags.StringTransfer)
                End If
                'send user-define message byte
                writer.Write(msgTag)
                'send length of data block
                writer.Write(Encoding.ASCII.GetBytes(strX).Length)
                'send the data
                writer.Write(Encoding.ASCII.GetBytes(strX))
                'make sure all data is sent
                writer.Flush()
            End SyncLock
        Catch ex As Exception
            'Error
        End Try
    End Sub

    Public Sub Send(ByVal msgTag As Byte, ByVal byteData() As Byte)
        Try
            'sends array of byte data
            SyncLock client.GetStream
                Dim writer As New BinaryWriter(client.GetStream)
                'Notify that byte data is coming
                writer.Write(RequestTags.DataTransfer)
                'send user-define message byte
                writer.Write(msgTag)
                'send length of data block
                writer.Write(byteData.Length)
                'send the data
                writer.Write(byteData)
                'make sure all data is sent
                writer.Flush()
            End SyncLock
        Catch ex As Exception
            'Error
        End Try
    End Sub
    'returns all text from last "/" in URL, but puts a "\" in front of the file name..
    Private Function GetFileNameFromURL(ByVal URL As String) As String
        If URL.IndexOf("\"c) = -1 Then Return String.Empty

        Return "\" & URL.Substring(URL.LastIndexOf("\"c) + 1)
    End Function
    Public Sub SendFile(ByVal msgTag As Byte, ByVal FilePath As String)
        Try
            'max filesize is 2GB
            Dim byteArray() As Byte
            Dim fs As FileStream = New FileStream(FilePath, FileMode.Open, FileAccess.Read)
            Dim r As New BinaryReader(fs)

            SyncLock client.GetStream
                Dim w As New BinaryWriter(client.GetStream)
                'notify that file data is coming
                w.Write(RequestTags.DataTransfer)
                'send user-define message byte
                w.Write(msgTag)
                'send size of file
                w.Write(CInt(fs.Length))
                'Send the file data
                Do
                    'read data from file
                    byteArray = r.ReadBytes(PACKET_SIZE)
                    'write data to Network Stream
                    w.Write(byteArray)
                Loop While byteArray.Length = PACKET_SIZE
                'make sure all data is sent
                w.Flush()
            End SyncLock
        Catch ex As Exception
            'Error While sending file
        End Try

    End Sub
#End Region

End Class
