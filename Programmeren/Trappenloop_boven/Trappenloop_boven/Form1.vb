Option Strict On
Option Explicit On

Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Public Class frm_main

    '' Trappenloop - (Start dit programma op de computer waar de gebruiker op de knop moet drukken)
    '' Auteur: Maxim Van de Wynckel
    '' Copyright: © 2012
    '' LAST EDIT: 15/04/2012

#Region " Stopwatch "
    '' Declaraties voor Tijdelijke opslag
    Dim Time As Decimal = Nothing

    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function
    Private Const VK_LBUTTON As Short = &H1
    Private Const VK_RBUTTON As Short = &H2

    '' Maak een eigen timer aan als event
    Public Sub Start_Timer()
        '' Kijk of er een invoke nodig is
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf Start_Timer))
        Else
            '' Verwijder alle gegevens van de vorige sessie
            Time = Nothing
            Stopwatch_On = True
            '' Start de Stopwatch Watcher Thread
            Dim TH_Stpwtch As New Thread(AddressOf Stopwatch)
            TH_Stpwtch.Start()
            '' Refresh het scherm
            Me.Refresh()
        End If
    End Sub
    Dim Span As TimeSpan 'Tijd van gebruiker
    Dim Allowclick As Boolean = False
    Public Sub Stopwatch()
        GetAsyncKeyState(VK_LBUTTON) 'Dit wist vorige lezing
        '' Dit is de Stopwatch Thread.
        '' Er mogen geen directe verwijzingen naar deze sub gaan
        '' Kijk of er een invoke nodig is
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf Stopwatch))
        Else
            Allowclick = False
            '' Zet de Start tijd
            Time_Start = DateTime.Now
            While Stopwatch_On = True
                Dim Span As TimeSpan = DateTime.Now.Subtract(Time_Start)
                lbl_timer.Text = String.Format("{0:00}:{1:00}:{2:00}", Span.Minutes, Span.Seconds, (Span.Milliseconds / 10)) '.ToString.Substring(0, 1) Voor honderste tonen
                '' Ververs de Timer
                Me.Refresh()
                lbl_timer.Refresh()
                '' Controlleer of buiten tijd
                If CDec((Span.Minutes * 60000) + (Span.Seconds * 1000) + Span.Milliseconds) > Maxtime Then
                    '' Buiten tijd
                    lbl_timer.ForeColor = Color.Red
                    lbl_message.Text = "Buiten tijd!"
                    listener.Broadcast(2, "%STOPTIME%")
                ElseIf CDec((Span.Minutes * 60000) + (Span.Seconds * 1000) + Span.Milliseconds) > Mintime Then
                    Allowclick = True
                Else
                    '' Gewoon
                    lbl_timer.ForeColor = Color.Black
                End If
                '' Laat de thread even rusten
                Thread.Sleep(10)
                '' Controlleer op Muis klik
                If CBool(GetAsyncKeyState(VK_LBUTTON)) And Allowclick = True Then
                    '' Muis ingedrukt
                    '' Stop de timer !!!
                    Stopwatch_On = False
                    '' Zet alles normaal
                    lbl_timer.Text = String.Format("{0:00}:{1:00}:{2:0}", Span.Minutes, Span.Seconds, (Span.Milliseconds / 10))
                    lbl_timer.ForeColor = Color.Black
                    '' Me
                    lbl_message.Text = "Proficiat! Je hebt het gehaald."
                    '' Save De gegevens
                    Time = CDec((Span.Minutes * 60000) + (Span.Seconds * 1000) + Span.Milliseconds)
                    '' Zend een STOP terug met de tijd
                    listener.Broadcast(2, "%STOP%" & Time)
                    If Webcam_TAKE = True Then
                        '' Neem foto
                        Dim TH_Snapshot As New Thread(AddressOf CreatePic)
                        TH_Snapshot.Start()
                    End If

                    '' Start Wis timer
                    Dim TH_Clear As New Thread(AddressOf ClearScreen)
                    TH_Clear.Start()

                End If
            End While
        End If
    End Sub
    Public Stopwatch_On As Boolean = False
    '' Declataties voor stopwatch
    Public Time_Start As DateTime
    Sub ClearScreen()
        '' Kijk of er een invoke nodig is
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf ClearScreen))
        Else
            '' Wacht 5 seconden en wis het scherm
            Me.Refresh()
            Threading.Thread.Sleep(5000)
            lbl_timer.Text = "00:00:00"
            lbl_message.Text = ""
        End If
    End Sub
#End Region

#Region " Sluit Programma "
    Private Const NUM5 As Short = 35
    '' Sluit het programma als ESC ingedrukt is
    Sub CloseProgram()
        '' Kijk elke 10 milliseconden of  BACKSPACE is ingedrukt
        While True
            If CBool(GetAsyncKeyState(NUM5)) Then
                ' Sluit het Programme
                End
            End If
            ' Wacht 10 ms om de pc niet te overbelasten
            Threading.Thread.Sleep(10)
        End While
    End Sub
#End Region

#Region " Min/Max mogelijk "
    Dim Mintime As Integer
    Dim Maxtime As Integer
#End Region

#Region " GUI "
    '' GUI van het programma
    Public Webcam_TAKE As Boolean = True
    Dim KleurKnop As String = "Rode"
    Sub Initialize()
        '' Laad het programma
        '' Verberg de cursor
        ShowCursor(0)
        '' Zet de form op TOP
        Me.TopMost = False
        'Ververs
        Me.Refresh()
        '' Laad instellingen
        Dim INIReader As New IniFile(Application.StartupPath & "\config.ini")
        Mintime = INIReader.GetInteger("Settings", "Minimum", 0)
        Maxtime = INIReader.GetInteger("Settings", "Maximum", 1000000)
        Webcam_TAKE = INIReader.GetBoolean("Settings", "Webcam", True)
        KleurKnop = INIReader.GetString("Settings", "KleurKnop", "Rode")
    End Sub
    Private Declare Function ShowCursor Lib "user32" _
    (ByVal bShow As Long) As Long
#End Region

#Region " Initialize "

    Private Sub frm_main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End 'ANDERS stoppen de threads niet
    End Sub
    Private Sub frm_main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '' Start de Task Handler
        Tasks()
    End Sub
#End Region

#Region " Event Task Manager"
    '' Controlleer alle events
    Sub Tasks()
        '' Laad het programma
        Initialize()
        '' Start de thread die wacht op BACKSPACE klik
        Dim TH_Close As New Threading.Thread(AddressOf CloseProgram)
        TH_Close.Start()
        '' Start de thread die het RAM geheugen cleared
        Dim TH_Ram As New Thread(AddressOf FlushMemory)
        TH_Ram.Start()
        '' Start de thread die wacht op verbindingen
        listener = New clsListener(PORT_NUM, PACKET_SIZE)
    End Sub
#End Region

#Region " RAM reduce "
    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, ByVal maximumWorkingSetSize As Integer) As Integer
    Public Sub FlushMemory()
        While True
            'Clean the program's ram
            'Omdat de tijd Correct moet blijven
            'en het programma niet te veel ram mag gebruiken. Worden images, namen,.. gewist uit RAM
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
            End If
            Thread.Sleep(5000)
        End While
    End Sub
#End Region

#Region " Connection "
    '' Declarations
    'This is the port number we will monitor
    Public PORT_NUM As Integer = 1000 'Default = 1000
    'This is the number of bytes to transfer in one block
    Public PACKET_SIZE As Short = 4096

    Private WithEvents listener As clsListener

    'These are message tags designed for this particular app
    Enum Requests As Byte
        PictureFile = 1
        DataFile = 2
    End Enum

    Private Sub listener_ConnectionRequest(ByVal requestor As System.Net.Sockets.TcpClient, _
        ByRef AllowConnection As Boolean) Handles listener.ConnectionRequest
        'Here you can examine the requestor to determine whether to accept the connection or not
        Debug.Print("Connection Request")
        '' Accepteer de verbinding
        AllowConnection = True
    End Sub
#End Region

#Region "Data Reception Events"
#Region " Connecting/Disconnecting "
    Sub Connected()
        '' Komt op als er een verbind tot stand is gebracht.\
        '' Kijk of er een invoke nodig is
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf Connected))
        Else
            ''Zet de hele stopwatch af
            Stopwatch_On = False
            lbl_timer.Text = "00:00:00"
            lbl_message.Text = "Verbinding met host!"
        End If
    End Sub
    Private Sub Disconnect() Handles listener.Disconnect
        '' Sluit huidige loper
        '' Kijk of er een invoke nodig is
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf Disconnect))
        Else
            ''Zet de hele stopwatch af
            Stopwatch_On = False
            lbl_timer.Text = "00:00:00"
            lbl_message.Text = "Verbinding met host Verbroken!"
        End If
    End Sub
#End Region

    Private Sub SaveFile(ByVal FilePath As String, ByVal mstream As System.IO.MemoryStream)
        Try
            'save file to path specified
            Dim FS As New FileStream(FilePath, IO.FileMode.Create, IO.FileAccess.Write)
            mstream.WriteTo(FS)
            mstream.Flush()
            FS.Close()
        Catch ex As IOException
            'Error File in use
            listener.Broadcast(1, "%ERROR%")
        End Try
    End Sub
    Private Sub listener_DataReceived(ByVal Sender As tcpConnection, ByVal msgtag As Byte, _
        ByVal mStream As System.IO.MemoryStream) Handles listener.DataReceived
        'Save file
        SaveFile(FilePath_SEND, mStream)
    End Sub

    Dim StartTime_Error As Integer = 0
    Private Sub listener_StringReceived(ByVal Sender As tcpConnection, ByVal msgTag As Byte, _
        ByVal message As String) Handles listener.StringReceived

        'This is where the client will send us requests for file data using our 
        '' Kijk welke data is aangekomen
        Select Case True
            Case message.ToUpper.StartsWith("%SYNC%%") '%SYNC%STARTTIME
                '' Je ontvangt de tijd in ms van de andere pc
                '' Stel deze tijd in
                TimeSet = CLng(message.Substring("%SYNC%".Length))
                SyncTime()
            Case message.ToUpper.StartsWith("%START%") '%START%Maxim Van de Wynckel
                '' Krijg de naam van de loper
                Naam = message.Substring("%START%".Length)
                '' Zet de naam in de label
                Label_message_STR = "'" & Naam & "'" & vbNewLine & "Druk op de " & KleurKnop & " knop om uw tijd vast te leggen."
                Label_timer_STR = "00:00:00"
                LabelChange()
                '' Start Timer
                Start_Timer()
                '' Stuur een OK terug
                listener.Broadcast(2, "%OK%" & "Trappenloop Gestart!")
            Case message.ToUpper.StartsWith("%ABORT%") '%ABORT%    Stop de timer
                '' Stop de timer !!!
                Stopwatch_On = False
                '' Message
                Label_message_STR = ""
                Label_timer_STR = "00:00:00"
                LabelChange()
                '' Save De gegevens
                Time = CDec((Span.Minutes * 60000) + (Span.Seconds * 1000) + Span.Milliseconds)
        End Select
    End Sub
    Public FilePath_SEND As String
    'returns all text from last "/" in URL, but puts a "\" in front of the file name..
    Private Function GetFileNameFromURL(ByVal URL As String) As String
        If URL.IndexOf("\"c) = -1 Then Return String.Empty

        Return "\" & URL.Substring(URL.LastIndexOf("\"c) + 1)
    End Function

#End Region

#Region " Gegevens Loper "
    '' Gegevens van de persoon die loops
    Dim Naam As String = Nothing
#End Region

#Region " SyncTime "
    Dim TimeSet As Long = Nothing
    Dim TimeNow As Long = Nothing
    Dim FoutNauwkeurigheid As Long = Nothing
    '' This will syncronize the time from the remote pc
    Sub SyncTime()
        '' Kijk of er een invoke nodig is
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf SyncTime))
        Else
            '' Invoke klaar
            TimeNow = Now.Ticks
            FoutNauwkeurigheid = TimeNow - TimeSet
            ' Normaal is dit + maar dat maakt niet veel uit
        End If
    End Sub
#End Region

#Region " Label Change "
    Dim Label_timer_STR As String
    Dim Label_message_STR As String
    Public Sub LabelChange()
        '' Dit wijzigt de labels
        '' het mag geen argumenten hebben omdat het een invoke
        '' nodig heeft
        '' Kijk of er een invoke nodig is
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf LabelChange))
        Else
            '' Zet de waardes in de strings
            lbl_message.Text = Label_message_STR
            lbl_timer.Text = Label_timer_STR
            '' Gewoon
            lbl_timer.ForeColor = Color.Black
        End If
    End Sub
#End Region

#Region " Webcam "
    Sub CreatePic()
        '' Kijk of er een invoke nodig is
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf CreatePic))
        Else
            '' Start alle threads om een foto te nemen
            OpenForm()
            SavePicture()
            DestroyWindow(hHwnd)
        End If

    End Sub
    '' Na elke loop word er een foto genomen
    '' Deze dient vooral als controle
    '' Het programma moet kunnen runnen ZONDER webcam
    'Create constant using attend in function of DLL file.
    Dim WebcamPic As Image = Nothing
    Const CAP As Short = &H400S
    Const CAP_DRIVER_CONNECT As Integer = CAP + 10
    Const CAP_DRIVER_DISCONNECT As Integer = CAP + 11
    Const CAP_EDIT_COPY As Integer = CAP + 30
    Const CAP_SET_PREVIEW As Integer = CAP + 50
    Const CAP_SET_PREVIEWRATE As Integer = CAP + 52
    Const CAP_SET_SCALE As Integer = CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1

    Dim iDevice As Integer = 0  ' Normal device ID 
    Dim hHwnd As Integer  ' Handle value to preview window

    ' Declare function from AVI capture DLL.

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
         ByVal lParam As Object) As Integer

    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWndParent As Integer, _
        ByVal nID As Integer) As Integer

    ' Use SendMessage to copy the data to the clipboard Then transfer the image to the picture box. 

    Private Sub SavePicture()
        Dim data As IDataObject
        Dim bmap As Image
        ' Copy image to clipboard 
        SendMessage(hHwnd, CAP_EDIT_COPY, 0, 0)

        ' Get image from clipboard and convert it to a bitmap 
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
            WebcamPic = bmap
            '' Temp Save the image
            Dim DTFormat As String = Format(Now, "dd_MM_yyy-HH_mm_ss")
            WebcamPic.Save(Application.StartupPath & "\webcam\" & DTFormat & ".jpg")
            '' Send the file to remote PC
            listener.BroadcastFile(1, Application.StartupPath & "\webcam\" & DTFormat & ".jpg")
        End If
    End Sub

    Private Sub frmcap_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        ' Disconnect from device
        SendMessage(hHwnd, CAP_DRIVER_DISCONNECT, iDevice, 0)
        ' close window 
        DestroyWindow(hHwnd)
    End Sub
    Private Sub OpenForm()
        Dim iHeight As Integer = piccap.Height
        Dim iWidth As Integer = piccap.Width

        ' Open Preview window in picturebox .
        ' Create a child window with capCreateCaptureWindowA so you can display it in a picturebox.

        hHwnd = capCreateCaptureWindowA(CStr(iDevice), WS_VISIBLE Or WS_CHILD, 0, 0, 320, _
            240, piccap.Handle.ToInt32, 0)
        ' Connect to device
        If CBool(SendMessage(hHwnd, CAP_DRIVER_CONNECT, iDevice, 0)) Then

            ' Set the preview scale
            SendMessage(hHwnd, CAP_SET_SCALE, CInt(True), 0)

            ' Set the preview rate in milliseconds
            SendMessage(hHwnd, CAP_SET_PREVIEWRATE, 66, 0)

            ' Start previewing the image from the camera 
            SendMessage(hHwnd, CAP_SET_PREVIEW, CInt(True), 0)
        Else
            ' Error connecting to device close window 
            DestroyWindow(hHwnd)

        End If
    End Sub
#End Region
End Class
