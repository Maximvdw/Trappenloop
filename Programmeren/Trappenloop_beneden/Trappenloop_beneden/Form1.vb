Option Strict On
Option Explicit On

'Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.Net.Sockets
Imports be.belgium.eid
Imports System.Runtime.InteropServices

Public Class frm_main

    '' Trappenloop - (Start dit programma op de computer waar de gebruiker moet geregistreerd worden)
    '' Auteur: Maxim Van de Wynckel
    '' Copyright: © 2012
    '' LAST EDIT: 27/03/2012
    Const VERSION As Integer = 27032012

#Region " Identiteits kaart "
    '' Lees de ID kaart en verkrijg gegevens

#Region " Kaart Lezers "
    '' De Kaartlezer die word gebruikt kan SIS en ID kaart lezen
    Private Function Load_sis(ByVal Reader As BEID_ReaderContext) As Boolean
        Try
            '' Stel Kaart in als Belgische SIS kaart
            Dim card As BEID_SISCard
            card = Reader.getSISCard()

            '' Zeg welke gegevens er moeten worden opgehaald
            Dim doc As BEID_SisId
            '' Verkrijg gegevens van SIS kaart
            doc = card.getID()

            '' Verkrijg Voornaam
            Voornaam = doc.getName()
            '' Verkrijg Achternaam
            Achternaam = doc.getSurname()
            '' Verkrijg Geslacht
            Geslacht = doc.getGender
        Catch ex As Exception
            '' Return Error
            Return False
        End Try
        '' Return geen error
        Return True
    End Function
    Private Function Load_eid(ByVal Reader As BEID_ReaderContext) As Boolean
        Try
            '' Stel de kaart in als Belgische ID kaart
            Dim card As BEID_EIDCard
            card = Reader.getEIDCard()
            If card.isTestCard() Then
                card.setAllowTestCard(True)
            End If

            '' Zeg welke gegevens er moeten worden opgehaald
            Dim doc As BEID_EId
            '' Verkrijg gegevens van ID kaart
            doc = card.getID()

            '' Verkrijg Voornaam
            Voornaam = doc.getFirstName()
            '' Verkrijg Achternaam
            Achternaam = doc.getSurname()
            '' Verkrijg Geslacht
            Geslacht = doc.getGender()

            '' Verkrijg de Foto van de ID kaart
            Dim picture As BEID_Picture
            picture = card.getPicture()

            Dim bytearray As Byte()
            bytearray = picture.getData().GetBytes()

            '' Start een memory stream om de foto op te slagen
            Dim ms As MemoryStream
            ms = New MemoryStream()
            ms.Write(bytearray, 0, bytearray.Length)

            '' Save de foto naar stream
            Foto = Image.FromStream(ms, True)
        Catch ex As Exception
            '' Return Error
            Return False
        End Try

        '' Return geen error
        Return True
    End Function
#End Region

    Public Sub ReadID_Data()
        '' Kijk of er een invoke nodig is
        If Me.InvokeRequired = True Then
            Me.Invoke(New MethodInvoker(AddressOf ReadID_Data))
        Else
            Try
                '' Lees alle informatie van de ID kaart
                Try
                    '' Start een nieuwe sessie
                    Dim ReaderSet As BEID_ReaderSet
                    ReaderSet = BEID_ReaderSet.instance()

                    '' Verkrijg versie van Reader (ACR38U SpaceShip)
                    Dim Reader As BEID_ReaderContext
                    Reader = ReaderSet.getReader()

                    '' Wis alle vorige instellingen
                    pic_pas.Image = Nothing
                    Foto = Nothing
                    Voornaam = Nothing
                    Achternaam = Nothing
                    Geslacht = Nothing

                    '' Kijk of er een kaart insteekt, en welke
                    If Reader.isCardPresent() Then
                        If Reader.getCardType() = BEID_CardType.BEID_CARDTYPE_EID _
                            Or Reader.getCardType() = BEID_CardType.BEID_CARDTYPE_FOREIGNER _
                            Or Reader.getCardType() = BEID_CardType.BEID_CARDTYPE_KIDS Then
                            '' Laad gegevens uit Identiteitskaart
                            Load_eid(Reader)

                        ElseIf Reader.getCardType() = BEID_CardType.BEID_CARDTYPE_SIS Then
                            '' Laad gegevens uit SIS kaart
                            Load_sis(Reader)

                        Else
                            '' Error Geen bekende kaart
                        End If
                    End If

                    '' Toon de gegevens
                    Voornaam = Voornaam.Substring(0, Voornaam.IndexOf(" "))
                    Me.lbl_voornaam.Text = Voornaam
                    Me.lbl_achternaam.Text = Achternaam
                    Me.lbl_geslacht.Text = Geslacht
                    Me.pic_pas.Image = Foto
                    manual_data.txt_voornaam.Text = Voornaam
                    manual_data.txt_achternaam.Text = Achternaam
                    If Geslacht = "M" Then
                        manual_data.rbmale.Checked = True
                    Else
                        manual_data.rbfemale.Checked = True
                    End If

                    '' Toon extra info

                    '' Sluit sessie af
                    BEID_ReaderSet.releaseSDK()
                    btn_manual.PerformClick()
                Catch ex As BEID_Exception
                    Debug.Print("Crash BEID_Exception!")
                    BEID_ReaderSet.releaseSDK()
                Catch ex As Exception
                    Debug.Print("Crash System.Exception!")
                    BEID_ReaderSet.releaseSDK()
                End Try
            Catch ex As Exception
                '' CRITICAL ERROR
                MessageBox.Show("Er is een zware fout gevonden in het ophalen van de gegevens." & vbNewLine & "De functie word uitgeschakelt!", "Critcal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btn_read.Visible = False
            End Try
        End If
        '' Enable button
        btn_read.Enabled = True
        btn_read.Text = "&Lees ID gegevens"
    End Sub
    Private Sub btn_read_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_read.Click
        '' Haal de gegevens van de BEID kaart
        '' Disable de laadknop
        btn_action.Enabled = True
        btn_read.Enabled = False
        btn_read.Text = "Bezig met laden..."
        '' Start een nieuwe thread
        Dim ID_TH As New Threading.Thread(AddressOf ReadID_Data)
        ID_TH.Start()
    End Sub
#End Region

#Region " Connection "
    '' Verbinding maken met de server boven
    '' Connection Details
    Private WithEvents client As tcpConnection
    Public PORT_NUM As Integer = 1000
    Public CON_TIMOUT As Integer = 2000
    Dim Server As String = Nothing  'Volledige Server naam met :Poort
    Dim ServerIP As String = Nothing 'Server IP
    Dim PortIP As Integer = Nothing  'Server Poort
    Sub CreateConnection(Optional ByVal Server As String = "", Optional ByVal Port As Integer = 0)
        'Create a complete socket connection with a server
        Try
            btn_action.Enabled = True
            btn_connect.Enabled = False
            btn_read.Enabled = True
            btn_manual.Enabled = True
            '' Vraag naar de server
            If Server = "" Then
                Server = InputBox("Geef de Server naam [IP:PORT]", "Verbinden met Server")
                'Show message
                ReadData = "Bezig met verbinden..."
                msg()
                'Get IP/Computer name
                ServerIP = Server.Substring(0, Server.IndexOf(":"))
                'Get PORT
                PortIP = CInt(Server.Substring(Server.IndexOf(":") + 1))
            Else
                'Show message
                ReadData = "Bezig met verbinden..."
                msg()
                'Get IP/Computer name
                ServerIP = Server
                'Get PORT
                PortIP = Port
            End If


            'Create Connection
            Connect(ServerIP, PortIP, CON_TIMOUT)
        Catch ex As ArgumentOutOfRangeException
            'Port not entered
            ReadData = "Poort nummer niet gevonden!"
            msg()
            btn_action.Enabled = False
            btn_connect.Enabled = True
            btn_read.Enabled = False
            btn_manual.Enabled = False
        Catch ex As InvalidCastException
            'Invalid port entered
            ReadData = "Geen geldig poort nummer ingegeven!"
            msg()
            btn_action.Enabled = False
            btn_connect.Enabled = True
            btn_read.Enabled = False
            btn_manual.Enabled = False
        End Try
    End Sub
    Sub Connect(ByVal Server As String, ByVal Port As Integer, Optional ByVal Timeout As Integer = 2000)
        Try
            client = New tcpConnection(Server, Port, Timeout)
            ReadData = "Aanvraag verzonden..."
            msg()
        Catch ex As Exception
            'Error Try again
            ReadData = "Kon geen verbinding maken met " & Server & ":" & Port & " !"
            msg()
            btn_action.Enabled = False
            btn_connect.Enabled = True
        End Try
    End Sub
#End Region

#Region " Data Opslag "
    '' Zet hier alles wat nodig is om de gegevens op te slagen
    '' Zowel tijdelijk als permanent
    Sub SaveToList()
        '' Perform Invoke
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf SaveToList))
        Else
            '' Start Geluid
            If GoogleSound = True Then
                Media.URL = (Application.StartupPath & "\sound\" & UserID & "_aangekomen.mpeg")
            End If

            '' Save alles naar list
            If Handicap > 0 Then
                lst_players.Items.Add(UserID & "# " & Voornaam & " " & Achternaam & " - " & Tijd - Handicap & "ms [HANDICAP]")
            End If
            lst_players.Items.Add(UserID & "# " & Voornaam & " " & Achternaam & " - " & Tijd - Handicap & "ms")
            '' STop eigen CONTROLE timer
            grp_trial.Enabled = False
            grp_gegevens.Enabled = True
            btn_action.Enabled = False
            btn_action.Text = "&Start"
            Action_SW = False 'Zet actie terug op start
            '' Toon tijd op Groupbox
            lbl_time.Text = String.Format("{0:00}:{1:00}:{2:00}", Math.Round(Tijd / 60000, 0), Math.Round(Tijd / 1000, 0) - (Math.Round(Tijd / 60000, 0) * 60), Math.Round(Tijd / 10, 0) - ((Math.Round(Tijd / 1000, 0) - (Math.Round(Tijd / 60000, 0) * 60)) * 100) - (Math.Round(Tijd / 60000, 0) * 600))
            '' Zet status
            lbl_status.Text = UserID & " Aangekomen!"
            '' Download image als webcampxp nodig is
            Try
                If WebcamXP = True Then
                    If IO.File.Exists(Application.StartupPath & "\webcam\" & UserID - 1 & ".jpg") = True Then
                        IO.File.Delete(Application.StartupPath & "\webcam\" & UserID - 1 & ".jpg")
                    End If
                    My.Computer.Network.DownloadFile("http://" & ServerIP & ":8080/cam_1.jpg", Application.StartupPath & "\webcam\" & UserID - 1 & ".jpg")
                    pnl_webcam.BackgroundImage = Image.FromFile(Application.StartupPath & "\webcam\" & UserID - 1 & ".jpg")
                End If
            Catch ex As Exception

            End Try
            Me.Refresh()
            '' Save nu alles naar de file
            SaveToFile()
            '' Clear Screen
            Dim TH_Clear As New Thread(AddressOf ClearData)
            TH_Clear.Start()
        End If
    End Sub
    Sub SaveToList_Buiten()
        '' Perform Invoke
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf SaveToList_Buiten))
        Else
            '' Start Geluid
            Media.URL = (Application.StartupPath & "\sound\" & UserID & "_buitentijd.mpeg")
        End If
    End Sub
    Sub SaveToFile(Optional ByVal ID As Integer = 0)
        '' Save alles naar Data.ini
        If ID = 0 Then
            Ini_Data.WriteString("Name", CStr(UserID), Achternaam)
            Ini_Data.WriteString("SureName", CStr(UserID), Voornaam)
            Ini_Data.WriteString("Gender", CStr(UserID), Geslacht)
            Ini_Data.WriteString("Trial", CStr(UserID), CStr(Tijd - Handicap))
            Ini_Data.WriteString("Length", CStr(UserID), CStr(Lengte))
            Ini_Data.WriteString("Weight", CStr(UserID), CStr(Gewicht))
            Ini_Data.WriteString("Date", CStr(UserID), StartTijd)
            Ini_Data.WriteString("Information", "UserID", CStr(UserID))
            Ini_Data.WriteInteger("FullName", Voornaam & " " & Achternaam, 1)
            Ini_Data.WriteString("BMI", CStr(UserID), CStr(BMI))
            Ini_Data.WriteString("BMI Level", CStr(UserID), CStr(BMI_Level))
        Else
            Ini_Data.WriteString("Name", CStr(ID), Achternaam_edit)
            Ini_Data.WriteString("SureName", CStr(ID), Voornaam_edit)
            Ini_Data.WriteString("Gender", CStr(ID), Geslacht_edit)
            Ini_Data.WriteString("Trial", CStr(ID), CStr(Tijd_edit))
            Ini_Data.WriteString("Length", CStr(ID), CStr(Lengte_edit))
            Ini_Data.WriteString("Weight", CStr(ID), CStr(Gewicht_edit))
            Ini_Data.WriteString("Date", CStr(ID), StartTijd_edit)
            Ini_Data.WriteInteger("FullName", Voornaam_edit & " " & Achternaam_edit, 1)
            Ini_Data.WriteString("BMI", CStr(ID), CStr(BMI_edit))
            Ini_Data.WriteString("BMI Level", CStr(ID), CStr(BMI_Level_edit))
        End If

    End Sub
#End Region
#Region "Client Events"
    Private Sub DataReceived(ByVal Sender As tcpConnection, ByVal msgtag As Byte, _
       ByVal mStream As System.IO.MemoryStream) Handles client.DataReceived
        client.Send(1, "%OK%DATA")
        'Show picture
        SaveFile(Application.StartupPath & "\webcam\" & UserID - 1 & ".jpg", mStream)
        pnl_webcam.BackgroundImage = Image.FromFile(Application.StartupPath & "\webcam\" & UserID - 1 & ".jpg")
    End Sub
    Private Sub client_Connect(ByVal sender As tcpConnection) Handles client.Connect
        'This event will be raised in a different thread than the original 
        ' thread of this form
        '' Send ABORT in case of previous run
        client.Send(4, "%ABORT%")
        SyncComputer()
    End Sub
    Sub Disconnected()
        '' Doe hier wat er moet gebeuren bij een disconnect
        '' Perform Invoke
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Disconnected))
        Else
            '' Invoke complete
            grp_gegevens.Enabled = True
            grp_trial.Enabled = False
            btn_action.Text = "&Start"
            Action_SW = False 'Zet actie start
            btn_action.Enabled = False
            btn_connect.Enabled = True
            btn_read.Enabled = False
            btn_manual.Enabled = False
        End If
    End Sub
    Private Sub client_Disconnect(ByVal sender As tcpConnection) Handles client.Disconnect
        'This event will be raised in a different thread than the original thread of thid form
        ReadData = "Verbinding verloren!"
        msg()
        Disconnected()
    End Sub
    Private Sub client_StringReceived(ByVal Sender As tcpConnection, ByVal msgTag As Byte, ByVal Message As String) Handles client.StringReceived
        'This code is run in a seperate thread from the thread that started the form
        'so we must either handle any control access in a special thread-safe way
        'or ignore illegal cross thread calls
        Select Case msgTag
            Case 1
                'Normal text
                ReadData = Message
                msg()
            Case 2
                'Command
                If Message.ToUpper.StartsWith("%STOP%") Then
                    '' Tijd gestopt verkrijg gegevens
                    '' Haal tijd uit string
                    Tijd = CInt(Message.Substring("%STOP%".Length))
                    '' Start Save Procedure
                    SaveToList()
                    '' Zet 1 bij ID
                    UserID += 1
                ElseIf Message.ToUpper.StartsWith("%STOPTIME%") Then
                    '' Buiten tijd!
                    Label_status_STR = "Buiten tijd!"
                    LabelCreate()
                    '' Start Save Procedure
                    If GoogleSound = True Then
                        SaveToList_Buiten()
                    End If

                ElseIf Message.ToUpper.StartsWith("%OUTTIME%") Then
                    '' De persoon heeft niet binnen het tijdslimiet afgedrukt
                ElseIf Message.ToUpper.StartsWith("%ERROR%") Then
                    '' Er is een onvolledig bericht aangekomen
                ElseIf Message.ToUpper.StartsWith("%OK%") Then
                    '' Er is een berich aangekomen
                    Dim Bericht As String = Message.Substring("%OK%".Length)
                    Label_status_STR = Bericht
                    LabelCreate()
                End If
        End Select
    End Sub
#End Region 'Client Events

#Region " Label Set "
    '' Zet de waarde in een label dat moet worden opgeroepen vanop
    '' een andere thread
    Dim Label_status_STR As String
    Sub LabelCreate()
        '' Wacht op invoke
        '' Perform Invoke
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf LabelCreate))
        Else
            '' Zet label waardes
            lbl_status.Text = Label_status_STR
        End If
    End Sub
#End Region

#Region " Save Webcam File "
    Private Sub SaveFile(ByVal FilePath As String, ByVal mstream As System.IO.MemoryStream)
        Try
            'save file to path specified
            Dim FS As New FileStream(FilePath, IO.FileMode.Create, IO.FileAccess.Write)
            mstream.WriteTo(FS)
            mstream.Flush()
            FS.Close()
        Catch ex As IOException
            'Error File in use
        End Try
    End Sub
#End Region
#Region " Stel status "
    '' Post message on form
    Public ReadData As String = Nothing
    Public Sub msg()
        '' Zet de status op lbl_GLOBAl_status
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf msg))
        Else
            lbl_GLOBAL_status.Text = ReadData
        End If
    End Sub
#End Region

#Region " Download TTS "
    '' Download de tem fiels om TTS af te spelen
    Sub TTS_DL(ByVal naam As Object)
        Try
            If IO.File.Exists(Application.StartupPath & "\sound\" & UserID & "_aangekomen.mpeg") = True Then
                IO.File.Delete(Application.StartupPath & "\sound\" & UserID & "_aangekomen.mpeg")
            End If
            If IO.File.Exists(Application.StartupPath & "\sound\" & UserID & "_buitentijd.mpeg") = True Then
                IO.File.Delete(Application.StartupPath & "\sound\" & UserID & "_buitentijd.mpeg")
            End If
            '' NAAM is aangekomen
            My.Computer.Network.DownloadFile("http://translate.google.com/translate_tts?tl=nl&q=" & CStr(naam) & " is aangekomen.", Application.StartupPath & "\sound\" & UserID & "_aangekomen.mpeg")
            '' NAAM is buiten tijd
            My.Computer.Network.DownloadFile("http://translate.google.com/translate_tts?tl=nl&q=" & CStr(naam) & " is buiten tijd.", Application.StartupPath & "\sound\" & UserID & "_buitentijd.mpeg")
        Catch ex As Exception
            '' geen internet / verbinding met Google
        End Try
    End Sub
#End Region

#Region " BMI CALC "
    Sub BMI_Calc(ByVal weight As Decimal, ByVal height As Decimal, Optional ByVal Edit As Boolean = False)
        Try
            ' Declare local variables
            If Edit = False Then
                BMI = CDec(weight / Math.Pow(height / 100, 2))
                Try
                    Select Case BMI
                        Case CDec(0.0) To CDec(18.5)
                            BMI_Level = BMI_Level_Sel.Underweight
                        Case CDec(18.6) To CDec(24.9)
                            BMI_Level = BMI_Level_Sel.Normal
                        Case Is > CDec(25.0)
                            BMI_Level = BMI_Level_Sel.Overweight
                    End Select
                Catch ex As Exception

                End Try

                ' Calculate and display BMI in lblBMI
                lbl_bmi.Text = BMI.ToString

                ' Format BMI value to 2 decimal places
                lbl_bmi.Text = FormatNumber(BMI, 2)
            Else
                BMI_edit = CDec(weight / Math.Pow(height / 100, 2))
                Try
                    Select Case BMI_edit
                        Case CDec(0.0) To CDec(18.5)
                            BMI_Level_edit = BMI_Level_Sel.Underweight
                        Case CDec(18.6) To CDec(24.9)
                            BMI_Level_edit = BMI_Level_Sel.Normal
                        Case Is > CDec(25.0)
                            BMI_Level_edit = BMI_Level_Sel.Overweight
                    End Select
                Catch ex As Exception

                End Try
            End If


        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region " Get System Time (Perform SYNC)"
    Private myTicks As Long
    Sub SyncComputer()
        '' Sync system time with other computer
        myTicks = Now.Ticks
        Try
            '' Send sync
            client.Send(4, "%SYNC%" & myTicks)
        Catch ex As Exception
            '' Sync Error
        End Try
    End Sub
#End Region
    Private Sub btn_manual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_manual.Click
        Try
            btn_action.Enabled = True
            '' Handmatige invoer van gegevens
            If manual_data.ShowDialog = Windows.Forms.DialogResult.OK Then
                '' Verkrijg de gegevens
                Voornaam = manual_data.txt_voornaam.Text
                Achternaam = manual_data.txt_achternaam.Text
                If manual_data.rbmale.Checked = True Then
                    'Man
                    Geslacht = "M"
                Else
                    'Vrouw
                    Geslacht = "V"
                End If
                Lengte = CInt(manual_data.txt_length.Text)
                Gewicht = CInt(manual_data.txt_weight.Text)


            End If
        Catch ex As Exception
            '' ONVOLDOENDE INFO
        End Try
        '' Toon de gegevens
        lbl_voornaam.Text = Voornaam
        lbl_achternaam.Text = Achternaam
        lbl_geslacht.Text = Geslacht
        lbl_weight.Text = CStr(Gewicht)
        lbl_length.Text = CStr(Lengte)
        BMI_Calc(Gewicht, Lengte)
    End Sub

    Dim Action_SW As Boolean = False 'FALSE=START TRUE=STOP
    Sub BeepLast()
        Console.Beep(1400, 1000)
    End Sub
    Public GoogleSound As Boolean = True
    Private Sub btn_action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_action.Click
        '' Kijk of de persoon al gelopen heeft
        If Ini_Data.GetInteger("FullName", Voornaam & " " & Achternaam, 0) = 1 Then
            '' Al gelopen
            If MessageBox.Show("Deze persoon heeft al reeds gelopen!" & vbNewLine & "Wilt u toch verder gaan?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            Else
                Return
            End If
        End If
        '' Kijk of er een stop/stat nodig is
        If Action_SW = False Then
            If Internal_Speaker = False Then
                Try
                    '' Start muziek voor start
                    Sound.Play()
                    '' Wacht 3 seconden
                    Thread.Sleep(SoundDelay)
                Catch ex As Exception
                    GoTo Internal
                End Try

            Else
Internal:
                Console.Beep(700, 500)
                Thread.Sleep(500)
                Console.Beep(700, 500)
                Thread.Sleep(500)
                Console.Beep(700, 500)
                Thread.Sleep(500)
                Dim TH_Lastbeep As New Thread(AddressOf BeepLast)
                TH_Lastbeep.Start()
            End If
            Try
                '' Save Start tijd
                StartTijd = Format(Now, "dd/MM/yyyy HH:mm:ss:ms")
                '' Zend Start gegevens naar de client
                client.Send(4, "%START%" & lbl_voornaam.Text & " " & lbl_achternaam.Text)
            Catch ex As Exception
                MsgBox("Check de verbinding...")
                btn_action.Enabled = False
                btn_connect.Enabled = True
                Return
            End Try

            '' STart eigen CONTROLE timer
            grp_trial.Enabled = True
            grp_gegevens.Enabled = False
            btn_action.Text = "&Stop"
            Action_SW = True 'Zet actie stop
            '' Stel status
            lbl_status.Text = "Start verstuurd!"
            If GoogleSound = True Then
                Dim TH_Download As New Thread(AddressOf TTS_DL)
                TH_Download.Start(Voornaam & " " & Achternaam)
            End If


        Else
            '' Zend Stop gegevens naar de client
            '' STop eigen CONTROLE timer
            grp_trial.Enabled = False
            grp_gegevens.Enabled = True
            btn_action.Enabled = False
            btn_action.Text = "&Start"
            Action_SW = False 'Zet actie terug op start
            Action_SW = False 'Zet actie start
            client.Send(4, "%ABORT%")
            '' Wis info na 5 sec (START ALS apparte Thread)
            Dim TH_Clear As New Thread(AddressOf ClearData)
            TH_Clear.Start()
        End If
    End Sub

    Private Sub btn_connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_connect.Click
        '' Maak een verbinding met een client
        '' Start de verbinding op een nieuwe thread, zodat het programma niet stopt
        CreateConnection()
    End Sub

    Private Sub frm_main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '' Waarschuwing
        If MessageBox.Show("Weet u zeker dat u wilt afsluiten?", "Waarschuwing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            '' Sluit het programma
            End
        Else
            '' Stop het programma van afsluiten
            e.Cancel = True
        End If
    End Sub

    '' Declaraties die benodigd zijn bij start
    Dim Sound As New System.Media.SoundPlayer()
    Dim Ini_Data As New IniFile(Application.StartupPath & "\data.ini")
    Public Internal_Speaker As Boolean = False
    Dim WebcamXP As Boolean = True
    Dim Handicap As Integer = 0
    Dim SoundDelay As Integer = 4000
    Private Sub frm_main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Kijk of er al een database is
        If IO.File.Exists(Application.StartupPath & "\data.ini") = True Then
            '' File bestaat
            '' Valideer file en verkijg data
            If VERSION = Ini_Data.GetInteger("Information", "Version", 0) Then
                '' Versie klopt
                UserID = Ini_Data.GetInteger("Information", "UserID", 1) + 1
                For i = 1 To UserID - 1
                    '' Voeg elke UserID toe
                    If Ini_Data.GetString("Trial", CStr(i), "") = "DEL" Then
                    Else
                        lst_players.Items.Add(i & "# " & Ini_Data.GetString("SureName", CStr(i), "") & " " & Ini_Data.GetString("Name", CStr(i), "") & " - " & Ini_Data.GetString("Trial", CStr(i), "") & "ms")

                    End If
                Next
            Else
                Try
                    IO.File.Copy(Application.StartupPath & "\data.ini", Application.StartupPath & "\data_BACKUP.ini")
                    IO.File.Delete(Application.StartupPath & "\data.ini")
                Catch ex As Exception

                End Try

                '' Versie fout
                GoTo VERSIONFail
            End If
        Else
VERSIONFail:
            '' File bestaat niet
            '' Maak de file aan
            Ini_Data.WriteInteger("Information", "Version", VERSION) 'Versie informatie
            Ini_Data.WriteInteger("Information", "UserID", 0) 'Starten vanaf userid x
        End If
        Try
            '' Laad Start Geluid
            Sound.SoundLocation = Application.StartupPath & "\sound\start.wav"
            Sound.Load()
            Sound.Play()
            Sound.Stop()
        Catch ex As Exception
            MessageBox.Show("Start geluid niet geladen!", "Error")
        End Try

        '' Laad config instellingen
        Dim Ini_Config As New IniFile(Application.StartupPath & "\config.ini")
        Try
            ServerIP = Ini_Config.GetString("Settings", "Default_Host", "")
            PortIP = CInt(Ini_Config.GetString("Settings", "Default_Port", ""))
            If CBool(Ini_Config.GetString("Settings", "Internal_Speaker", "")) = True Then
                '' Internal speaker aan
                Internal_Speaker = True
            End If
            '' Maak een verbinding met een client
            '' Start de verbinding op een nieuwe thread, zodat het programma niet stopt
            CreateConnection(ServerIP, PortIP)
        Catch ex As Exception
            '' Error reading data
        End Try

        Try
            '' Kijk of hij van WebcamXP moet gebruiken
            If CBool(Ini_Config.GetString("Settings", "WebcamXP", "")) = True Then
                WebcamXP = True
            Else
                WebcamXP = False
            End If
            If CBool(Ini_Config.GetString("Settings", "GoogleSound", "")) = True Then
                GoogleSound = True
            Else
                GoogleSound = False
            End If
        Catch ex As Exception

        End Try
        Try
            '' Kijk voor handicap
            Handicap = Ini_Config.GetInteger("Settings", "Handicap", 0)
        Catch ex As Exception

        End Try
        Try
            '' Kijk voor sound delay
            SoundDelay = Ini_Config.GetInteger("Settings", "SoundDelay", 0)
        Catch ex As Exception

        End Try
    End Sub

#Region " Gegevens "
    '' Declaraties voor gegevens
    Dim Voornaam As String = Nothing
    Dim Achternaam As String = Nothing
    Dim Geslacht As String = Nothing
    Dim Adres As String = Nothing
    Dim Foto As Image = Nothing
    Dim Tijd As Integer = Nothing
    Dim UserID As Integer = 1
    Dim StartTijd As String = Nothing
    Dim Lengte As Integer = Nothing
    Dim Gewicht As Integer = Nothing
    Dim BMI As Decimal = Nothing
    Dim BMI_Level As Integer = Nothing

    Dim Voornaam_edit As String = Nothing
    Dim Achternaam_edit As String = Nothing
    Dim Geslacht_edit As String = Nothing
    Dim Foto_edit As Image = Nothing
    Dim Tijd_edit As Integer = Nothing
    Dim UserID_edit As Integer = 1
    Dim StartTijd_edit As String = Nothing
    Dim Lengte_edit As Integer = Nothing
    Dim Gewicht_edit As Integer = Nothing
    Dim BMI_edit As Decimal = Nothing
    Dim BMI_Level_edit As Integer = Nothing

    Public Enum BMI_Level_Sel As Integer
        Underweight = 1
        Normal = 2
        Overweight = 3
    End Enum
#End Region

#Region " Clear Screen "
    '' Wis het scherm na 5 sec
    Private Sub ClearData()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf ClearData))
        Else
            '' Slaap 5 seconden
            Thread.Sleep(5000)
            '' Vraag naar Invoke

            lbl_time.Text = "00:00:00"
            pnl_webcam.BackgroundImage = Nothing
            '' Wis invoer
            lbl_voornaam.Text = ""
            lbl_achternaam.Text = ""
            lbl_geslacht.Text = ""
            lbl_bmi.Text = ""
            lbl_length.Text = ""
            lbl_weight.Text = ""
            pic_pas.Image = Nothing
            '' Wis invoer data
            manual_data.txt_achternaam.Text = ""
            manual_data.txt_voornaam.Text = ""
            manual_data.txt_date.Text = ""
            manual_data.txt_length.Text = ""
            manual_data.txt_time.Text = ""
            manual_data.txt_weight.Text = ""
        End If
    End Sub
#End Region

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        '' Kijk of er een lid is geselecteerd
        If Not lst_players.SelectedItem Is Nothing Then
            '' Wis item
            Dim ID_sel As Integer = CInt(lst_players.SelectedItem.ToString.Substring(0, lst_players.SelectedItem.ToString.IndexOf("#")))
            lst_players.Items.Remove(lst_players.SelectedItem)
            Ini_Data.WriteString("Trial", CStr(ID_sel), "DEL")
        End If
    End Sub

    Dim Lock As Boolean = False
    Private Sub btn_lock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lock.Click
        If Lock = False Then
            '' Disable Everything
            Tabs.Enabled = False
            btn_action.Enabled = False
            btn_connect.Enabled = False
            btn_read.Enabled = False
            btn_manual.Enabled = False
            Lock = True
        Else
            '' Disable Everything
            If LoginDialogForm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Tabs.Enabled = True
                btn_action.Enabled = True
                btn_connect.Enabled = False
                btn_read.Enabled = True
                btn_manual.Enabled = True
                Lock = False
            End If
        End If

    End Sub

    Private Sub btn_change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_change.Click
        '' Kijk of er een item is geselecteerd
        If Not lst_players.SelectedItem Is Nothing Then
            '' Roep de informatie op van de user en toon Manual Edit
            Dim ID_sel As Integer = CInt(lst_players.SelectedItem.ToString.Substring(0, lst_players.SelectedItem.ToString.IndexOf("#")))
            Voornaam_edit = Ini_Data.GetString("SureName", CStr(ID_sel), "")
            Achternaam_edit = Ini_Data.GetString("Name", CStr(ID_sel), "")
            Lengte_edit = CInt(Ini_Data.GetString("Length", CStr(ID_sel), ""))
            Gewicht_edit = CInt(Ini_Data.GetString("Weight", CStr(ID_sel), ""))
            Tijd_edit = CInt(Ini_Data.GetString("Trial", CStr(ID_sel), ""))
            StartTijd_edit = Ini_Data.GetString("Date", CStr(ID_sel), "")
            Geslacht_edit = Ini_Data.GetString("Gender", CStr(ID_sel), "")
            manual_data.txt_voornaam.Text = Voornaam_edit
            manual_data.txt_achternaam.Text = Achternaam_edit
            manual_data.txt_length.Text = CStr(Lengte_edit)
            manual_data.txt_weight.Text = CStr(Gewicht_edit)
            manual_data.txt_time.Text = CStr(Tijd_edit)
            manual_data.txt_date.Text = CStr(StartTijd_edit)
            BMI_Calc(Gewicht_edit, Lengte_edit, True)

            If Geslacht_edit = "M" Then
                manual_data.rbmale.Checked = True
            Else
                manual_data.rbfemale.Checked = True
            End If
            Try
                manual_data.pic_picture.Image = Image.FromFile(Application.StartupPath & "\webcam\" & ID_sel & ".jpg")
            Catch ex As Exception

            End Try

            '' Wacht op OK
            manual_data.Post_Edit = True
            If manual_data.ShowDialog = Windows.Forms.DialogResult.OK Then
                '' Ok gedrukt
                '' Verkrijg de gegevens
                Voornaam_edit = manual_data.txt_voornaam.Text
                Achternaam_edit = manual_data.txt_achternaam.Text
                If manual_data.rbmale.Checked = True Then
                    'Man
                    Geslacht_edit = "M"
                Else
                    'Vrouw
                    Geslacht_edit = "V"
                End If
                Lengte_edit = CInt(manual_data.txt_length.Text)
                Gewicht_edit = CInt(manual_data.txt_weight.Text)
                Tijd_edit = CInt(manual_data.txt_time.Text)
                StartTijd_edit = manual_data.txt_date.Text
                '' Save data
                SaveToFile(ID_sel)
            End If
        End If
        manual_data.Post_Edit = False

        '' RELOAD
        If IO.File.Exists(Application.StartupPath & "\data.ini") = True Then
            '' File bestaat
            '' Valideer file en verkijg data
            If VERSION = Ini_Data.GetInteger("Information", "Version", 0) Then
                '' Versie klopt
                UserID = Ini_Data.GetInteger("Information", "UserID", 1) + 1
                lst_players.Items.Clear()
                For i = 1 To UserID - 1
                    '' Voeg elke UserID toe
                    If Ini_Data.GetString("Trial", CStr(i), "") = "DEL" Then
                    Else
                        lst_players.Items.Add(i & "# " & Ini_Data.GetString("SureName", CStr(i), "") & " " & Ini_Data.GetString("Name", CStr(i), "") & " - " & Ini_Data.GetString("Trial", CStr(i), "") & "ms")

                    End If
                Next
            Else
                '' Versie fout
                GoTo VERSIONFail
            End If
        Else
VERSIONFail:
            '' File bestaat niet
            '' Maak de file aan
            Ini_Data.WriteInteger("Information", "Version", VERSION) 'Versie informatie
            Ini_Data.WriteInteger("Information", "UserID", 1) 'Starten vanaf userid x
        End If
    End Sub

#Region " Genereer Uitslag "
    Private Sub btn_gen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gen.Click
        '' Normaal 4 inc
        '' BMI = 10 inc

        Try
            Dim PRG As Integer = 0
            If chk_KL1.Checked = True Then
                PRG += 4
            End If
            If chk_KL2.Checked = True Then
                PRG += 4
            End If
            If chk_KL3.Checked = True Then
                PRG += 4
            End If
            If chk_KL4.Checked = True Then
                PRG += 10
            End If
            Progbar_Generate.Maximum = PRG
        Catch ex As Exception
            Progbar_Generate.Maximum = 100
        End Try


        '' Maak uitslag per klassement
        If chk_KL1.Checked = True Then
            Progbar_Generate.Increment(1)
            '' Totaal Klassement
            '' Laad aantal mensen
            Dim Count As Integer = CInt(Ini_Data.GetInteger("Information", "UserID", 1))
            Dim Array_Uitslag(3, Count) As String
            Dim ERRCOUNT As Integer = 0
            For i = 1 To Count - ERRCOUNT
                If Ini_Data.GetString("Trial", CStr(i), "") = "DEL" Then
                    '' Gedelete
                    ERRCOUNT += 1
                Else
                    Array_Uitslag(0, i) = Ini_Data.GetString("SureName", CStr(i), "")
                    Array_Uitslag(1, i) = Ini_Data.GetString("Name", CStr(i), "")
                    Array_Uitslag(2, i) = Ini_Data.GetString("Gender", CStr(i), "")
                    Array_Uitslag(3, i) = Ini_Data.GetString("Trial", CStr(i), "")
                End If
            Next
            Progbar_Generate.Increment(1)
            '' Sorteer
            '' Array_uitslag(3,0) (3,1) ... moet worden gechecked
            For j = 1 To Array_Uitslag.GetUpperBound(1)
                For i = 1 To Count - ERRCOUNT
                    Dim TempArray(3, Count - ERRCOUNT) As String
                    Try
                        If CDec(Array_Uitslag(3, i)) > CDec(Array_Uitslag(3, i + 1)) Then
                            '' Store tijdelijk
                            TempArray(0, 0) = Array_Uitslag(0, i)
                            TempArray(1, 0) = Array_Uitslag(1, i)
                            TempArray(2, 0) = Array_Uitslag(2, i)
                            TempArray(3, 0) = Array_Uitslag(3, i)

                            '' Swap Plaatsen
                            Array_Uitslag(0, i) = Array_Uitslag(0, i + 1)
                            Array_Uitslag(1, i) = Array_Uitslag(1, i + 1)
                            Array_Uitslag(2, i) = Array_Uitslag(2, i + 1)
                            Array_Uitslag(3, i) = Array_Uitslag(3, i + 1)

                            '' Zet terug
                            Array_Uitslag(0, i + 1) = TempArray(0, 0)
                            Array_Uitslag(1, i + 1) = TempArray(1, 0)
                            Array_Uitslag(2, i + 1) = TempArray(2, 0)
                            Array_Uitslag(3, i + 1) = TempArray(3, 0)
                        End If
                    Catch ex As Exception

                    End Try

                Next
            Next
            Progbar_Generate.Increment(1)
            '' Zet nu alles op een Txt file
            Dim Fnum As Integer = FreeFile()
            Try
                FileOpen(Fnum, Application.StartupPath & "\Uitslag\Totaal.txt", OpenMode.Output)
                For i = 1 + ERRCOUNT To Count - ERRCOUNT
                    PrintLine(Fnum, i - ERRCOUNT & "# " & Array_Uitslag(0, i) & " " & Array_Uitslag(1, i) & " [" & Array_Uitslag(2, i) & "] - " & Array_Uitslag(3, i) & "ms")
                Next
            Catch ex As Exception
            Finally
                FileClose(Fnum)
            End Try
            Progbar_Generate.Increment(1)
        End If
        If chk_KL2.Checked = True Then
            '' Mannen Klassement
            '' Laad aantal mensen
            Dim Count As Integer = CInt(Ini_Data.GetInteger("Information", "UserID", 1))
            Dim Array_Uitslag(3, Count) As String
            Dim ERRCOUNT As Integer = 0
            Progbar_Generate.Increment(1)
            For i = 1 To Count - ERRCOUNT
                If Ini_Data.GetString("Trial", CStr(i), "") = "DEL" Or Ini_Data.GetString("Gender", CStr(i), "") = "V" Then
                    '' Gedelete
                    ERRCOUNT += 1
                Else
                    Array_Uitslag(0, i - ERRCOUNT) = Ini_Data.GetString("SureName", CStr(i), "")
                    Array_Uitslag(1, i - ERRCOUNT) = Ini_Data.GetString("Name", CStr(i), "")
                    Array_Uitslag(2, i - ERRCOUNT) = Ini_Data.GetString("Gender", CStr(i), "")
                    Array_Uitslag(3, i - ERRCOUNT) = Ini_Data.GetString("Trial", CStr(i), "")
                End If
            Next
            Progbar_Generate.Increment(1)
            ReDim Preserve Array_Uitslag(3, Count - ERRCOUNT)
            '' Sorteer
            '' Array_uitslag(3,0) (3,1) ... moet worden gechecked
            For j = 1 To Array_Uitslag.GetUpperBound(1)
                For i = 1 To Count
                    Dim TempArray(3, Count - ERRCOUNT) As String
                    Try
                        If CDec(Array_Uitslag(3, i)) > CDec(Array_Uitslag(3, i + 1)) Then
                            '' Store tijdelijk
                            TempArray(0, 0) = Array_Uitslag(0, i)
                            TempArray(1, 0) = Array_Uitslag(1, i)
                            TempArray(2, 0) = Array_Uitslag(2, i)
                            TempArray(3, 0) = Array_Uitslag(3, i)

                            '' Swap Plaatsen
                            Array_Uitslag(0, i) = Array_Uitslag(0, i + 1)
                            Array_Uitslag(1, i) = Array_Uitslag(1, i + 1)
                            Array_Uitslag(2, i) = Array_Uitslag(2, i + 1)
                            Array_Uitslag(3, i) = Array_Uitslag(3, i + 1)

                            '' Zet terug
                            Array_Uitslag(0, i + 1) = TempArray(0, 0)
                            Array_Uitslag(1, i + 1) = TempArray(1, 0)
                            Array_Uitslag(2, i + 1) = TempArray(2, 0)
                            Array_Uitslag(3, i + 1) = TempArray(3, 0)
                        End If
                    Catch ex As Exception

                    End Try

                Next
            Next
            Progbar_Generate.Increment(1)
            '' Zet nu alles op een Txt file
            Dim Fnum As Integer = FreeFile()
            Try
                FileOpen(Fnum, Application.StartupPath & "\Uitslag\Mannen.txt", OpenMode.Output)
                For i = 1 + ERRCOUNT To Count + 1
                    PrintLine(Fnum, i - ERRCOUNT & "# " & Array_Uitslag(0, i - ERRCOUNT) & " " & Array_Uitslag(1, i - ERRCOUNT) & " [" & Array_Uitslag(2, i - ERRCOUNT) & "] - " & Array_Uitslag(3, i - ERRCOUNT) & "ms")
                Next
            Catch ex As Exception
            Finally
                FileClose(Fnum)
            End Try
            Progbar_Generate.Increment(1)
        End If

        If chk_KL3.Checked = True Then
            '' Vrouwen Klassement
            '' Laad aantal mensen
            Progbar_Generate.Increment(1)
            Dim Count As Integer = CInt(Ini_Data.GetInteger("Information", "UserID", 1))
            Dim Array_Uitslag(3, Count) As String
            Dim ERRCOUNT As Integer = 0
            For i = 1 To Count - ERRCOUNT
                If Ini_Data.GetString("Trial", CStr(i), "") = "DEL" Or Ini_Data.GetString("Gender", CStr(i), "") = "M" Then
                    '' Gedelete
                    ERRCOUNT += 1
                Else
                    Array_Uitslag(0, i - ERRCOUNT) = Ini_Data.GetString("SureName", CStr(i), "")
                    Array_Uitslag(1, i - ERRCOUNT) = Ini_Data.GetString("Name", CStr(i), "")
                    Array_Uitslag(2, i - ERRCOUNT) = Ini_Data.GetString("Gender", CStr(i), "")
                    Array_Uitslag(3, i - ERRCOUNT) = Ini_Data.GetString("Trial", CStr(i), "")
                End If
            Next
            Progbar_Generate.Increment(1)
            ReDim Preserve Array_Uitslag(3, Count - ERRCOUNT)
            '' Sorteer
            '' Array_uitslag(3,0) (3,1) ... moet worden gechecked
            For j = 1 To Array_Uitslag.GetUpperBound(1)
                For i = 1 To Count
                    Dim TempArray(3, Count - ERRCOUNT) As String
                    Try
                        If CDec(Array_Uitslag(3, i)) > CDec(Array_Uitslag(3, i + 1)) Then
                            '' Store tijdelijk
                            TempArray(0, 0) = Array_Uitslag(0, i)
                            TempArray(1, 0) = Array_Uitslag(1, i)
                            TempArray(2, 0) = Array_Uitslag(2, i)
                            TempArray(3, 0) = Array_Uitslag(3, i)

                            '' Swap Plaatsen
                            Array_Uitslag(0, i) = Array_Uitslag(0, i + 1)
                            Array_Uitslag(1, i) = Array_Uitslag(1, i + 1)
                            Array_Uitslag(2, i) = Array_Uitslag(2, i + 1)
                            Array_Uitslag(3, i) = Array_Uitslag(3, i + 1)

                            '' Zet terug
                            Array_Uitslag(0, i + 1) = TempArray(0, 0)
                            Array_Uitslag(1, i + 1) = TempArray(1, 0)
                            Array_Uitslag(2, i + 1) = TempArray(2, 0)
                            Array_Uitslag(3, i + 1) = TempArray(3, 0)
                        End If
                    Catch ex As Exception

                    End Try

                Next
            Next
            Progbar_Generate.Increment(1)
            '' Zet nu alles op een Txt file
            Dim Fnum As Integer = FreeFile()
            Try
                FileOpen(Fnum, Application.StartupPath & "\Uitslag\Vrouwen.txt", OpenMode.Output)
                For i = 1 + ERRCOUNT To Count + 1
                    PrintLine(Fnum, i - ERRCOUNT & "# " & Array_Uitslag(0, i - ERRCOUNT) & " " & Array_Uitslag(1, i - ERRCOUNT) & " [" & Array_Uitslag(2, i - ERRCOUNT) & "] - " & Array_Uitslag(3, i - ERRCOUNT) & "ms")
                Next
            Catch ex As Exception
            Finally
                FileClose(Fnum)
            End Try
            Progbar_Generate.Increment(1)
        End If
        If chk_KL4.Checked = True Then
            '' BMI klassement
            '' Laad aantal mensen
            Progbar_Generate.Increment(1)
            Dim Count As Integer = CInt(Ini_Data.GetInteger("Information", "UserID", 1))
            Dim Array_Uitslag(3, Count) As String
            Dim ERRCOUNT As Integer = 0
            For i = 1 To Count - ERRCOUNT
                If Ini_Data.GetString("Trial", CStr(i), "") = "DEL" Or Not Ini_Data.GetString("BMI Level", CStr(i), "") = "1" Then
                    '' Gedelete
                    ERRCOUNT += 1
                Else
                    Array_Uitslag(0, i - ERRCOUNT) = Ini_Data.GetString("SureName", CStr(i), "")
                    Array_Uitslag(1, i - ERRCOUNT) = Ini_Data.GetString("Name", CStr(i), "")
                    Array_Uitslag(2, i - ERRCOUNT) = Ini_Data.GetString("Gender", CStr(i), "")
                    Array_Uitslag(3, i - ERRCOUNT) = Ini_Data.GetString("Trial", CStr(i), "")
                End If
            Next
            Progbar_Generate.Increment(1)
            ReDim Preserve Array_Uitslag(3, Count - ERRCOUNT)
            '' Sorteer
            '' Array_uitslag(3,0) (3,1) ... moet worden gechecked
            For j = 1 To Array_Uitslag.GetUpperBound(1)
                For i = 1 To Count
                    Dim TempArray(3, Count - ERRCOUNT) As String
                    Try
                        If CDec(Array_Uitslag(3, i)) > CDec(Array_Uitslag(3, i + 1)) Then
                            '' Store tijdelijk
                            TempArray(0, 0) = Array_Uitslag(0, i)
                            TempArray(1, 0) = Array_Uitslag(1, i)
                            TempArray(2, 0) = Array_Uitslag(2, i)
                            TempArray(3, 0) = Array_Uitslag(3, i)

                            '' Swap Plaatsen
                            Array_Uitslag(0, i) = Array_Uitslag(0, i + 1)
                            Array_Uitslag(1, i) = Array_Uitslag(1, i + 1)
                            Array_Uitslag(2, i) = Array_Uitslag(2, i + 1)
                            Array_Uitslag(3, i) = Array_Uitslag(3, i + 1)

                            '' Zet terug
                            Array_Uitslag(0, i + 1) = TempArray(0, 0)
                            Array_Uitslag(1, i + 1) = TempArray(1, 0)
                            Array_Uitslag(2, i + 1) = TempArray(2, 0)
                            Array_Uitslag(3, i + 1) = TempArray(3, 0)
                        End If
                    Catch ex As Exception

                    End Try

                Next
            Next
            Progbar_Generate.Increment(1)
            '' Zet nu alles op een Txt file
            Dim Fnum As Integer = FreeFile()
            Try
                FileOpen(Fnum, Application.StartupPath & "\Uitslag\BMI1.txt", OpenMode.Output)
                For i = 1 + ERRCOUNT To Count + 1
                    PrintLine(Fnum, i - ERRCOUNT & "# " & Array_Uitslag(0, i - ERRCOUNT) & " " & Array_Uitslag(1, i - ERRCOUNT) & " [" & Array_Uitslag(2, i - ERRCOUNT) & "] - " & Array_Uitslag(3, i - ERRCOUNT) & "ms")
                Next
            Catch ex As Exception
            Finally
                FileClose(Fnum)
            End Try
            Progbar_Generate.Increment(1)
            '' Laad aantal mensen
            Count = CInt(Ini_Data.GetInteger("Information", "UserID", 1))
            ReDim Array_Uitslag(3, Count)
            ERRCOUNT = 0
            For i = 1 To Count - ERRCOUNT
                If Ini_Data.GetString("Trial", CStr(i), "") = "DEL" Or Not Ini_Data.GetString("BMI Level", CStr(i), "") = "2" Then
                    '' Gedelete
                    ERRCOUNT += 1
                Else
                    Array_Uitslag(0, i - ERRCOUNT) = Ini_Data.GetString("SureName", CStr(i), "")
                    Array_Uitslag(1, i - ERRCOUNT) = Ini_Data.GetString("Name", CStr(i), "")
                    Array_Uitslag(2, i - ERRCOUNT) = Ini_Data.GetString("Gender", CStr(i), "")
                    Array_Uitslag(3, i - ERRCOUNT) = Ini_Data.GetString("Trial", CStr(i), "")
                End If
            Next
            Progbar_Generate.Increment(1)
            ReDim Preserve Array_Uitslag(3, Count - ERRCOUNT)
            '' Sorteer
            '' Array_uitslag(3,0) (3,1) ... moet worden gechecked
            For j = 1 To Array_Uitslag.GetUpperBound(1)
                For i = 1 To Count
                    Dim TempArray(3, Count - ERRCOUNT) As String
                    Try
                        If CDec(Array_Uitslag(3, i)) > CDec(Array_Uitslag(3, i + 1)) Then
                            '' Store tijdelijk
                            TempArray(0, 0) = Array_Uitslag(0, i)
                            TempArray(1, 0) = Array_Uitslag(1, i)
                            TempArray(2, 0) = Array_Uitslag(2, i)
                            TempArray(3, 0) = Array_Uitslag(3, i)

                            '' Swap Plaatsen
                            Array_Uitslag(0, i) = Array_Uitslag(0, i + 1)
                            Array_Uitslag(1, i) = Array_Uitslag(1, i + 1)
                            Array_Uitslag(2, i) = Array_Uitslag(2, i + 1)
                            Array_Uitslag(3, i) = Array_Uitslag(3, i + 1)

                            '' Zet terug
                            Array_Uitslag(0, i + 1) = TempArray(0, 0)
                            Array_Uitslag(1, i + 1) = TempArray(1, 0)
                            Array_Uitslag(2, i + 1) = TempArray(2, 0)
                            Array_Uitslag(3, i + 1) = TempArray(3, 0)
                        End If
                    Catch ex As Exception

                    End Try

                Next
            Next
            Progbar_Generate.Increment(1)
            '' Zet nu alles op een Txt file
            Fnum = FreeFile()
            Try
                FileOpen(Fnum, Application.StartupPath & "\Uitslag\BMI2.txt", OpenMode.Output)
                For i = 1 + ERRCOUNT To Count + 1
                    PrintLine(Fnum, i - ERRCOUNT & "# " & Array_Uitslag(0, i - ERRCOUNT) & " " & Array_Uitslag(1, i - ERRCOUNT) & " [" & Array_Uitslag(2, i - ERRCOUNT) & "] - " & Array_Uitslag(3, i - ERRCOUNT) & "ms")
                Next
            Catch ex As Exception
            Finally
                FileClose(Fnum)
            End Try
            Progbar_Generate.Increment(1)
            '' Laad aantal mensen
            Count = CInt(Ini_Data.GetInteger("Information", "UserID", 1))
            ReDim Array_Uitslag(3, Count)
            ERRCOUNT = 0
            For i = 1 To Count - ERRCOUNT
                If Ini_Data.GetString("Trial", CStr(i), "") = "DEL" Or Not Ini_Data.GetString("BMI Level", CStr(i), "") = "3" Then
                    '' Gedelete
                    ERRCOUNT += 1
                Else
                    Array_Uitslag(0, i - ERRCOUNT) = Ini_Data.GetString("SureName", CStr(i), "")
                    Array_Uitslag(1, i - ERRCOUNT) = Ini_Data.GetString("Name", CStr(i), "")
                    Array_Uitslag(2, i - ERRCOUNT) = Ini_Data.GetString("Gender", CStr(i), "")
                    Array_Uitslag(3, i - ERRCOUNT) = Ini_Data.GetString("Trial", CStr(i), "")
                End If
            Next
            Progbar_Generate.Increment(1)
            ReDim Preserve Array_Uitslag(3, Count - ERRCOUNT)
            '' Sorteer
            '' Array_uitslag(3,0) (3,1) ... moet worden gechecked
            For j = 1 To Array_Uitslag.GetUpperBound(1)
                For i = 1 To Count
                    Dim TempArray(3, Count - ERRCOUNT) As String
                    Try
                        If CDec(Array_Uitslag(3, i)) > CDec(Array_Uitslag(3, i + 1)) Then
                            '' Store tijdelijk
                            TempArray(0, 0) = Array_Uitslag(0, i)
                            TempArray(1, 0) = Array_Uitslag(1, i)
                            TempArray(2, 0) = Array_Uitslag(2, i)
                            TempArray(3, 0) = Array_Uitslag(3, i)

                            '' Swap Plaatsen
                            Array_Uitslag(0, i) = Array_Uitslag(0, i + 1)
                            Array_Uitslag(1, i) = Array_Uitslag(1, i + 1)
                            Array_Uitslag(2, i) = Array_Uitslag(2, i + 1)
                            Array_Uitslag(3, i) = Array_Uitslag(3, i + 1)

                            '' Zet terug
                            Array_Uitslag(0, i + 1) = TempArray(0, 0)
                            Array_Uitslag(1, i + 1) = TempArray(1, 0)
                            Array_Uitslag(2, i + 1) = TempArray(2, 0)
                            Array_Uitslag(3, i + 1) = TempArray(3, 0)
                        End If
                    Catch ex As Exception

                    End Try

                Next
            Next
            Progbar_Generate.Increment(1)
            '' Zet nu alles op een Txt file
            Fnum = FreeFile()
            Try
                FileOpen(Fnum, Application.StartupPath & "\Uitslag\BMI3.txt", OpenMode.Output)
                For i = 1 + ERRCOUNT To Count + 1
                    PrintLine(Fnum, i - ERRCOUNT & "# " & Array_Uitslag(0, i - ERRCOUNT) & " " & Array_Uitslag(1, i - ERRCOUNT) & " [" & Array_Uitslag(2, i - ERRCOUNT) & "] - " & Array_Uitslag(3, i - ERRCOUNT) & "ms")
                Next
            Catch ex As Exception
            Finally
                FileClose(Fnum)
            End Try
            Progbar_Generate.Increment(1)
        End If
        '' toon berich
        MessageBox.Show("Uitslag opgeslagen!")
        Progbar_Generate.Value = 0
    End Sub
#End Region

    Private Sub grp_gegevens_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grp_gegevens.Enter

    End Sub

    Private Sub pnl_controls_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnl_controls.Paint

    End Sub
End Class
