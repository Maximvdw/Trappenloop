Imports System.Net.Sockets
Imports System.IO
Imports System.Collections.Generic
Imports System.Net

Public Class clsListener
    Private Enum RequestTags As Byte
        Connect = 1
        Disconnect = 2
        DataTransfer = 3
        StringTransfer = 4
        ByteTransfer = 5
    End Enum

    Private Server As TcpListener
    Private Clients As Dictionary(Of Int16, tcpConnection)
    Private nClients As Byte
    Private mPacketSize As Int16

#Region "Event Declarations"
    Public Event ConnectionRequest(ByVal Requestor As TcpClient, ByRef AllowConnection As Boolean)
    Public Event DataReceived(ByVal Client As tcpConnection, ByVal msgTag As Byte, ByVal mStream As MemoryStream)
    Public Event StringReceived(ByVal Client As tcpConnection, ByVal msgTag As Byte, ByVal message As String)
    Public Event Disconnect(ByVal Client As tcpConnection)
#End Region

    Dim PORT_NUM As Integer
    Public Sub New(ByVal nPort As Integer, Optional ByVal PacketSize As Int16 = 4096)
        'constructor:
        'Creates a dictionary to store client connections
        'and starts listening for connection requests on the
        'port specified
        mPacketSize = PacketSize
        Clients = New Dictionary(Of Int16, tcpConnection)
        Listen(nPort)
    End Sub

    Private Sub Listen(ByVal nPort As Integer)
        Try
            'instantiate the listener class
            Server = New TcpListener(System.Net.IPAddress.Any, nPort)
            'start listening for connection requests
            Server.Start()
            'asyncronously wait for connection requests
            Server.BeginAcceptTcpClient(New AsyncCallback(AddressOf DoAcceptTcpClientCallback), Server)
        Catch ex As SocketException
            'Error PORT IS IN USE
            'Change Port Number (-1) and try again
            PORT_NUM -= 1
            Listen(PORT_NUM)
        Catch ex As Exception
            'Error Unknow
        End Try
    End Sub
    Public Shared ClientName As String = Nothing
    Private Sub DoAcceptTcpClientCallback(ByVal ar As IAsyncResult)
        Try
            ' Processes the client connection request.
            ' A maximum of 255 connections can be made.
            ' Get the listener that handles the client request.
            Dim listener As TcpListener = CType(ar.AsyncState, TcpListener)

            Dim client As TcpClient = listener.EndAcceptTcpClient(ar)
            Try
                ' Get CALL data from server
                Dim bytesFrom(10024) As Byte
                Dim dataFromClient As String
                Dim networkStream As NetworkStream = _
                client.GetStream()
                networkStream.Read(bytesFrom, 0, CInt(client.ReceiveBufferSize))
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom)
                dataFromClient = _
                dataFromClient.Substring(0, dataFromClient.IndexOf("$"))
                'Set Clientname
                ClientName = dataFromClient
            Catch ex As Exception
                '' Error bij het ophalen van Connectiegegevens
                '' Foutieve Verbinding
            End Try


            'add client to list of connected clients
            SendMessage(RequestTags.Connect, mPacketSize, client)
            Dim newClient As tcpConnection = New tcpConnection(client, mPacketSize)
            newClient.Tag = nClients
            Clients.Add(nClients, newClient)
            nClients += CByte(1)

            'need to delegate events for client since client
            'is created dynamically and is going to be put into a 
            'collection so this is how we are going to propagate 
            'the events up to the end user
            AddHandler newClient.DataReceived, AddressOf onDataReceived
            AddHandler newClient.StringReceived, AddressOf onStringReceived
            AddHandler newClient.Disconnect, AddressOf onClientDisconnect
            newClient = Nothing

            'get client name and ip
            Dim ClientIP As String = Nothing
            Dim ServerIP As String = Nothing
            Dim ServerName As String = Nothing
            Try
                'Get host name and ip from client socket
                ServerName = My.Computer.Name
                Dim ipend As Net.IPEndPoint = CType(client.Client.RemoteEndPoint, Net.IPEndPoint)
                If Not ipend Is Nothing Then
                    ClientIP = ipend.Address.ToString
                End If
            Catch ex As Exception
                'Error
                ClientName = ClientIP
            End Try

            'send message to all connected clients
            Broadcast(1, "Verbonden met " & ServerName.ToUpper)

            'Toon berich dat verbinding is gelukt
            frm_main.Connected()

            'continue listening
            listener.BeginAcceptTcpClient(New AsyncCallback(AddressOf DoAcceptTcpClientCallback), listener)

        Catch ex As Exception
            'Error
        End Try

    End Sub 'DoAcceptTcpClientCallback

    Private Sub SendMessage(ByVal msgTag As Byte, ByVal msg As Int16, ByVal client As TcpClient)
        '' Zend message
        Try
            ' This subroutine sends a one-byte response through a tcpClient
            ' Synclock ensure that no other threads try to use the stream at the same time.
            SyncLock client.GetStream
                Dim writer As New BinaryWriter(client.GetStream)
                writer.Write(msgTag)
                writer.Write(msg)
                ' Make sure all data is sent now.
                writer.Flush()
            End SyncLock
        Catch ex As Exception
            'Error
        End Try
    End Sub

#Region "Broadcast methods"
    Public Sub Broadcast(ByVal msgTag As Byte)
        '' Zend Gegevens naar Alle verbonden clients
        '' (Message Tag)
        For Each myClient As KeyValuePair(Of Short, tcpConnection) In Clients
            Clients(myClient.Key).Send(msgTag)
        Next
    End Sub

    Public Sub Broadcast(ByVal msgTag As Byte, ByVal strX As String)
        '' Zend Gegevens naar Alle verbonden clients
        '' (String)
        For Each myClient As KeyValuePair(Of Short, tcpConnection) In Clients
            Clients(myClient.Key).Send(msgTag, strX)
        Next
    End Sub

    Public Sub Broadcast(ByVal msgTag As Byte, ByVal byteData() As Byte)
        '' Zend Gegevens naar Alle verbonden clients
        '' (ByteDate)
        For Each myClient As KeyValuePair(Of Short, tcpConnection) In Clients
            Clients(myClient.Key).Send(msgTag, byteData)
        Next
    End Sub
    Public Sub BroadcastFile(ByVal msgTag As Byte, ByVal FilePath As String)
        '' Zend Gegevens naar Alle verbonden clients
        '' (File data)
        For Each myClient As KeyValuePair(Of Short, tcpConnection) In Clients
            Clients(myClient.Key).SendFile(msgTag, FilePath)
        Next
    End Sub
#End Region

#Region "Events for the clients"
    Private Sub onClientDisconnect(ByVal Client As tcpConnection)
        RaiseEvent Disconnect(Client)
        'Sluit de client en verwijder uit lijst
        Clients.Remove(Client.Tag)
        Client = Nothing
    End Sub

    Private Sub onDataReceived(ByVal client As tcpConnection, ByVal msgTag As Byte, ByVal mstream As MemoryStream)
        '' Start DateReceived
        RaiseEvent DataReceived(client, msgTag, mstream)
    End Sub

    Private Sub onStringReceived(ByVal Sender As tcpConnection, ByVal msgTag As Byte, ByVal message As String)
        '' Start StringReceived
        RaiseEvent StringReceived(Sender, msgTag, message)
    End Sub
#End Region

End Class
