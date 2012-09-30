<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_main))
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.tab_bsic = New System.Windows.Forms.TabPage()
        Me.grp_trial = New System.Windows.Forms.GroupBox()
        Me.lbl_status_txt = New System.Windows.Forms.Label()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.time_panel = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_time = New System.Windows.Forms.Label()
        Me.Label_web = New System.Windows.Forms.Label()
        Me.pnl_webcam = New System.Windows.Forms.Panel()
        Me.Media = New AxWMPLib.AxWindowsMediaPlayer()
        Me.grp_gegevens = New System.Windows.Forms.GroupBox()
        Me.lbl_bmi = New System.Windows.Forms.Label()
        Me.lbl_bmi_txt = New System.Windows.Forms.Label()
        Me.lbl_weight = New System.Windows.Forms.Label()
        Me.lbl_weight_txt = New System.Windows.Forms.Label()
        Me.lbl_length = New System.Windows.Forms.Label()
        Me.txt_length_txt = New System.Windows.Forms.Label()
        Me.pnl_image = New System.Windows.Forms.Panel()
        Me.pic_pas = New System.Windows.Forms.PictureBox()
        Me.lbl_geslacht = New System.Windows.Forms.Label()
        Me.lbl_geslacht_txt = New System.Windows.Forms.Label()
        Me.btn_manual = New System.Windows.Forms.Button()
        Me.btn_read = New System.Windows.Forms.Button()
        Me.lbl_achternaam = New System.Windows.Forms.Label()
        Me.lbl_voornaam = New System.Windows.Forms.Label()
        Me.lbl_achternaam_txt = New System.Windows.Forms.Label()
        Me.lbl_voornaam_txt = New System.Windows.Forms.Label()
        Me.tab_deelnemers = New System.Windows.Forms.TabPage()
        Me.pnl_controls = New System.Windows.Forms.Panel()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.btn_change = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.lst_players = New System.Windows.Forms.ListBox()
        Me.tab_output = New System.Windows.Forms.TabPage()
        Me.chk_KL4 = New System.Windows.Forms.CheckBox()
        Me.chk_KL3 = New System.Windows.Forms.CheckBox()
        Me.chk_KL2 = New System.Windows.Forms.CheckBox()
        Me.chk_KL1 = New System.Windows.Forms.CheckBox()
        Me.btn_gen = New System.Windows.Forms.Button()
        Me.btn_action = New System.Windows.Forms.Button()
        Me.status_Strp = New System.Windows.Forms.StatusStrip()
        Me.lbl_GLOBAL_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl_copyrights = New System.Windows.Forms.Label()
        Me.btn_connect = New System.Windows.Forms.Button()
        Me.btn_lock = New System.Windows.Forms.Button()
        Me.LBL_VERSION = New System.Windows.Forms.Label()
        Me.Progbar_Generate = New System.Windows.Forms.ProgressBar()
        Me.Tabs.SuspendLayout()
        Me.tab_bsic.SuspendLayout()
        Me.grp_trial.SuspendLayout()
        Me.time_panel.SuspendLayout()
        Me.pnl_webcam.SuspendLayout()
        CType(Me.Media, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_gegevens.SuspendLayout()
        Me.pnl_image.SuspendLayout()
        CType(Me.pic_pas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_deelnemers.SuspendLayout()
        Me.pnl_controls.SuspendLayout()
        Me.tab_output.SuspendLayout()
        Me.status_Strp.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tabs
        '
        Me.Tabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tabs.Controls.Add(Me.tab_bsic)
        Me.Tabs.Controls.Add(Me.tab_deelnemers)
        Me.Tabs.Controls.Add(Me.tab_output)
        Me.Tabs.Location = New System.Drawing.Point(0, 0)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(482, 298)
        Me.Tabs.TabIndex = 0
        '
        'tab_bsic
        '
        Me.tab_bsic.Controls.Add(Me.grp_trial)
        Me.tab_bsic.Controls.Add(Me.grp_gegevens)
        Me.tab_bsic.Location = New System.Drawing.Point(4, 23)
        Me.tab_bsic.Name = "tab_bsic"
        Me.tab_bsic.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_bsic.Size = New System.Drawing.Size(474, 271)
        Me.tab_bsic.TabIndex = 0
        Me.tab_bsic.Text = "Basis Gegevens"
        Me.tab_bsic.UseVisualStyleBackColor = True
        '
        'grp_trial
        '
        Me.grp_trial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_trial.Controls.Add(Me.lbl_status_txt)
        Me.grp_trial.Controls.Add(Me.lbl_status)
        Me.grp_trial.Controls.Add(Me.time_panel)
        Me.grp_trial.Controls.Add(Me.Label_web)
        Me.grp_trial.Controls.Add(Me.pnl_webcam)
        Me.grp_trial.Enabled = False
        Me.grp_trial.Location = New System.Drawing.Point(8, 149)
        Me.grp_trial.Name = "grp_trial"
        Me.grp_trial.Size = New System.Drawing.Size(457, 116)
        Me.grp_trial.TabIndex = 1
        Me.grp_trial.TabStop = False
        Me.grp_trial.Text = "Informatie"
        '
        'lbl_status_txt
        '
        Me.lbl_status_txt.AutoSize = True
        Me.lbl_status_txt.Location = New System.Drawing.Point(9, 67)
        Me.lbl_status_txt.Name = "lbl_status_txt"
        Me.lbl_status_txt.Size = New System.Drawing.Size(44, 14)
        Me.lbl_status_txt.TabIndex = 4
        Me.lbl_status_txt.Text = "Status:"
        '
        'lbl_status
        '
        Me.lbl_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_status.Location = New System.Drawing.Point(59, 66)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(214, 17)
        Me.lbl_status.TabIndex = 3
        Me.lbl_status.Text = "Wachten op Start..."
        '
        'time_panel
        '
        Me.time_panel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.time_panel.ColumnCount = 1
        Me.time_panel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.time_panel.Controls.Add(Me.lbl_time, 0, 0)
        Me.time_panel.Location = New System.Drawing.Point(12, 19)
        Me.time_panel.Name = "time_panel"
        Me.time_panel.RowCount = 1
        Me.time_panel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.time_panel.Size = New System.Drawing.Size(261, 44)
        Me.time_panel.TabIndex = 2
        '
        'lbl_time
        '
        Me.lbl_time.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_time.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_time.Location = New System.Drawing.Point(4, 1)
        Me.lbl_time.Name = "lbl_time"
        Me.lbl_time.Size = New System.Drawing.Size(253, 42)
        Me.lbl_time.TabIndex = 0
        Me.lbl_time.Text = "00:00:00"
        Me.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_web
        '
        Me.Label_web.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_web.AutoSize = True
        Me.Label_web.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_web.Location = New System.Drawing.Point(304, 13)
        Me.Label_web.Name = "Label_web"
        Me.Label_web.Size = New System.Drawing.Size(98, 13)
        Me.Label_web.TabIndex = 1
        Me.Label_web.Text = "Webcam snapshot:"
        '
        'pnl_webcam
        '
        Me.pnl_webcam.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_webcam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnl_webcam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_webcam.Controls.Add(Me.Media)
        Me.pnl_webcam.Location = New System.Drawing.Point(307, 29)
        Me.pnl_webcam.Name = "pnl_webcam"
        Me.pnl_webcam.Size = New System.Drawing.Size(135, 81)
        Me.pnl_webcam.TabIndex = 0
        '
        'Media
        '
        Me.Media.Enabled = True
        Me.Media.Location = New System.Drawing.Point(-22, 53)
        Me.Media.Name = "Media"
        Me.Media.OcxState = CType(resources.GetObject("Media.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Media.Size = New System.Drawing.Size(75, 23)
        Me.Media.TabIndex = 5
        Me.Media.Visible = False
        '
        'grp_gegevens
        '
        Me.grp_gegevens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_gegevens.Controls.Add(Me.lbl_bmi)
        Me.grp_gegevens.Controls.Add(Me.lbl_bmi_txt)
        Me.grp_gegevens.Controls.Add(Me.lbl_weight)
        Me.grp_gegevens.Controls.Add(Me.lbl_weight_txt)
        Me.grp_gegevens.Controls.Add(Me.lbl_length)
        Me.grp_gegevens.Controls.Add(Me.txt_length_txt)
        Me.grp_gegevens.Controls.Add(Me.pnl_image)
        Me.grp_gegevens.Controls.Add(Me.lbl_geslacht)
        Me.grp_gegevens.Controls.Add(Me.lbl_geslacht_txt)
        Me.grp_gegevens.Controls.Add(Me.btn_manual)
        Me.grp_gegevens.Controls.Add(Me.btn_read)
        Me.grp_gegevens.Controls.Add(Me.lbl_achternaam)
        Me.grp_gegevens.Controls.Add(Me.lbl_voornaam)
        Me.grp_gegevens.Controls.Add(Me.lbl_achternaam_txt)
        Me.grp_gegevens.Controls.Add(Me.lbl_voornaam_txt)
        Me.grp_gegevens.Location = New System.Drawing.Point(8, 6)
        Me.grp_gegevens.Name = "grp_gegevens"
        Me.grp_gegevens.Size = New System.Drawing.Size(457, 137)
        Me.grp_gegevens.TabIndex = 0
        Me.grp_gegevens.TabStop = False
        Me.grp_gegevens.Text = "Gegevens"
        '
        'lbl_bmi
        '
        Me.lbl_bmi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_bmi.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_bmi.Location = New System.Drawing.Point(94, 87)
        Me.lbl_bmi.Name = "lbl_bmi"
        Me.lbl_bmi.Size = New System.Drawing.Size(248, 14)
        Me.lbl_bmi.TabIndex = 18
        '
        'lbl_bmi_txt
        '
        Me.lbl_bmi_txt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_bmi_txt.AutoSize = True
        Me.lbl_bmi_txt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_bmi_txt.Location = New System.Drawing.Point(9, 87)
        Me.lbl_bmi_txt.Name = "lbl_bmi_txt"
        Me.lbl_bmi_txt.Size = New System.Drawing.Size(39, 14)
        Me.lbl_bmi_txt.TabIndex = 17
        Me.lbl_bmi_txt.Text = "BMI: "
        '
        'lbl_weight
        '
        Me.lbl_weight.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_weight.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_weight.Location = New System.Drawing.Point(94, 73)
        Me.lbl_weight.Name = "lbl_weight"
        Me.lbl_weight.Size = New System.Drawing.Size(248, 14)
        Me.lbl_weight.TabIndex = 16
        '
        'lbl_weight_txt
        '
        Me.lbl_weight_txt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_weight_txt.AutoSize = True
        Me.lbl_weight_txt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_weight_txt.Location = New System.Drawing.Point(9, 73)
        Me.lbl_weight_txt.Name = "lbl_weight_txt"
        Me.lbl_weight_txt.Size = New System.Drawing.Size(66, 14)
        Me.lbl_weight_txt.TabIndex = 15
        Me.lbl_weight_txt.Text = "Gewicht: "
        '
        'lbl_length
        '
        Me.lbl_length.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_length.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_length.Location = New System.Drawing.Point(94, 59)
        Me.lbl_length.Name = "lbl_length"
        Me.lbl_length.Size = New System.Drawing.Size(248, 14)
        Me.lbl_length.TabIndex = 14
        '
        'txt_length_txt
        '
        Me.txt_length_txt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_length_txt.AutoSize = True
        Me.txt_length_txt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_length_txt.Location = New System.Drawing.Point(9, 59)
        Me.txt_length_txt.Name = "txt_length_txt"
        Me.txt_length_txt.Size = New System.Drawing.Size(57, 14)
        Me.txt_length_txt.TabIndex = 13
        Me.txt_length_txt.Text = "Lengte: "
        '
        'pnl_image
        '
        Me.pnl_image.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnl_image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_image.Controls.Add(Me.pic_pas)
        Me.pnl_image.Location = New System.Drawing.Point(366, 15)
        Me.pnl_image.Name = "pnl_image"
        Me.pnl_image.Size = New System.Drawing.Size(80, 113)
        Me.pnl_image.TabIndex = 12
        '
        'pic_pas
        '
        Me.pic_pas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pic_pas.Location = New System.Drawing.Point(0, 0)
        Me.pic_pas.Name = "pic_pas"
        Me.pic_pas.Size = New System.Drawing.Size(78, 111)
        Me.pic_pas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_pas.TabIndex = 0
        Me.pic_pas.TabStop = False
        '
        'lbl_geslacht
        '
        Me.lbl_geslacht.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_geslacht.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_geslacht.Location = New System.Drawing.Point(94, 45)
        Me.lbl_geslacht.Name = "lbl_geslacht"
        Me.lbl_geslacht.Size = New System.Drawing.Size(248, 14)
        Me.lbl_geslacht.TabIndex = 11
        '
        'lbl_geslacht_txt
        '
        Me.lbl_geslacht_txt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_geslacht_txt.AutoSize = True
        Me.lbl_geslacht_txt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_geslacht_txt.Location = New System.Drawing.Point(9, 45)
        Me.lbl_geslacht_txt.Name = "lbl_geslacht_txt"
        Me.lbl_geslacht_txt.Size = New System.Drawing.Size(67, 14)
        Me.lbl_geslacht_txt.TabIndex = 9
        Me.lbl_geslacht_txt.Text = "Geslacht:"
        '
        'btn_manual
        '
        Me.btn_manual.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_manual.Enabled = False
        Me.btn_manual.Image = CType(resources.GetObject("btn_manual.Image"), System.Drawing.Image)
        Me.btn_manual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_manual.Location = New System.Drawing.Point(156, 106)
        Me.btn_manual.Name = "btn_manual"
        Me.btn_manual.Size = New System.Drawing.Size(143, 25)
        Me.btn_manual.TabIndex = 8
        Me.btn_manual.Text = "&Handmatige invoer"
        Me.btn_manual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_manual.UseVisualStyleBackColor = True
        '
        'btn_read
        '
        Me.btn_read.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_read.Enabled = False
        Me.btn_read.Image = CType(resources.GetObject("btn_read.Image"), System.Drawing.Image)
        Me.btn_read.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_read.Location = New System.Drawing.Point(12, 106)
        Me.btn_read.Name = "btn_read"
        Me.btn_read.Size = New System.Drawing.Size(138, 25)
        Me.btn_read.TabIndex = 7
        Me.btn_read.Text = "&Lees ID gegevens"
        Me.btn_read.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_read.UseVisualStyleBackColor = True
        '
        'lbl_achternaam
        '
        Me.lbl_achternaam.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_achternaam.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_achternaam.Location = New System.Drawing.Point(94, 31)
        Me.lbl_achternaam.Name = "lbl_achternaam"
        Me.lbl_achternaam.Size = New System.Drawing.Size(248, 14)
        Me.lbl_achternaam.TabIndex = 4
        '
        'lbl_voornaam
        '
        Me.lbl_voornaam.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_voornaam.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_voornaam.Location = New System.Drawing.Point(94, 17)
        Me.lbl_voornaam.Name = "lbl_voornaam"
        Me.lbl_voornaam.Size = New System.Drawing.Size(248, 14)
        Me.lbl_voornaam.TabIndex = 3
        '
        'lbl_achternaam_txt
        '
        Me.lbl_achternaam_txt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_achternaam_txt.AutoSize = True
        Me.lbl_achternaam_txt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_achternaam_txt.Location = New System.Drawing.Point(9, 31)
        Me.lbl_achternaam_txt.Name = "lbl_achternaam_txt"
        Me.lbl_achternaam_txt.Size = New System.Drawing.Size(90, 14)
        Me.lbl_achternaam_txt.TabIndex = 1
        Me.lbl_achternaam_txt.Text = "Achternaam: "
        '
        'lbl_voornaam_txt
        '
        Me.lbl_voornaam_txt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_voornaam_txt.AutoSize = True
        Me.lbl_voornaam_txt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_voornaam_txt.Location = New System.Drawing.Point(9, 17)
        Me.lbl_voornaam_txt.Name = "lbl_voornaam_txt"
        Me.lbl_voornaam_txt.Size = New System.Drawing.Size(79, 14)
        Me.lbl_voornaam_txt.TabIndex = 0
        Me.lbl_voornaam_txt.Text = "Voornaam: "
        '
        'tab_deelnemers
        '
        Me.tab_deelnemers.Controls.Add(Me.pnl_controls)
        Me.tab_deelnemers.Controls.Add(Me.lst_players)
        Me.tab_deelnemers.Location = New System.Drawing.Point(4, 23)
        Me.tab_deelnemers.Name = "tab_deelnemers"
        Me.tab_deelnemers.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_deelnemers.Size = New System.Drawing.Size(474, 271)
        Me.tab_deelnemers.TabIndex = 1
        Me.tab_deelnemers.Text = "Deelnemers"
        Me.tab_deelnemers.UseVisualStyleBackColor = True
        '
        'pnl_controls
        '
        Me.pnl_controls.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_controls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_controls.Controls.Add(Me.btn_add)
        Me.pnl_controls.Controls.Add(Me.btn_change)
        Me.pnl_controls.Controls.Add(Me.btn_delete)
        Me.pnl_controls.Location = New System.Drawing.Point(330, 3)
        Me.pnl_controls.Name = "pnl_controls"
        Me.pnl_controls.Size = New System.Drawing.Size(140, 259)
        Me.pnl_controls.TabIndex = 1
        '
        'btn_add
        '
        Me.btn_add.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_add.Enabled = False
        Me.btn_add.Image = CType(resources.GetObject("btn_add.Image"), System.Drawing.Image)
        Me.btn_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_add.Location = New System.Drawing.Point(14, 70)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(116, 26)
        Me.btn_add.TabIndex = 2
        Me.btn_add.Text = "&Toevoegen"
        Me.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'btn_change
        '
        Me.btn_change.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_change.Image = CType(resources.GetObject("btn_change.Image"), System.Drawing.Image)
        Me.btn_change.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_change.Location = New System.Drawing.Point(14, 41)
        Me.btn_change.Name = "btn_change"
        Me.btn_change.Size = New System.Drawing.Size(116, 26)
        Me.btn_change.TabIndex = 1
        Me.btn_change.Text = "Wij&zigen"
        Me.btn_change.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_change.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_delete.Image = CType(resources.GetObject("btn_delete.Image"), System.Drawing.Image)
        Me.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_delete.Location = New System.Drawing.Point(14, 12)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(116, 26)
        Me.btn_delete.TabIndex = 0
        Me.btn_delete.Text = "&Wissen"
        Me.btn_delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'lst_players
        '
        Me.lst_players.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lst_players.FormattingEnabled = True
        Me.lst_players.ItemHeight = 14
        Me.lst_players.Location = New System.Drawing.Point(6, 6)
        Me.lst_players.Name = "lst_players"
        Me.lst_players.Size = New System.Drawing.Size(321, 256)
        Me.lst_players.TabIndex = 0
        '
        'tab_output
        '
        Me.tab_output.Controls.Add(Me.Progbar_Generate)
        Me.tab_output.Controls.Add(Me.chk_KL4)
        Me.tab_output.Controls.Add(Me.chk_KL3)
        Me.tab_output.Controls.Add(Me.chk_KL2)
        Me.tab_output.Controls.Add(Me.chk_KL1)
        Me.tab_output.Controls.Add(Me.btn_gen)
        Me.tab_output.Location = New System.Drawing.Point(4, 23)
        Me.tab_output.Name = "tab_output"
        Me.tab_output.Size = New System.Drawing.Size(474, 271)
        Me.tab_output.TabIndex = 2
        Me.tab_output.Text = "Uitslag"
        Me.tab_output.UseVisualStyleBackColor = True
        '
        'chk_KL4
        '
        Me.chk_KL4.AutoSize = True
        Me.chk_KL4.Checked = True
        Me.chk_KL4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_KL4.Location = New System.Drawing.Point(8, 107)
        Me.chk_KL4.Name = "chk_KL4"
        Me.chk_KL4.Size = New System.Drawing.Size(114, 18)
        Me.chk_KL4.TabIndex = 4
        Me.chk_KL4.Text = "Klassement BMI"
        Me.chk_KL4.UseVisualStyleBackColor = True
        '
        'chk_KL3
        '
        Me.chk_KL3.AutoSize = True
        Me.chk_KL3.Checked = True
        Me.chk_KL3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_KL3.Location = New System.Drawing.Point(8, 83)
        Me.chk_KL3.Name = "chk_KL3"
        Me.chk_KL3.Size = New System.Drawing.Size(141, 18)
        Me.chk_KL3.TabIndex = 3
        Me.chk_KL3.Text = "Klassement Vrouwen"
        Me.chk_KL3.UseVisualStyleBackColor = True
        '
        'chk_KL2
        '
        Me.chk_KL2.AutoSize = True
        Me.chk_KL2.Checked = True
        Me.chk_KL2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_KL2.Location = New System.Drawing.Point(8, 59)
        Me.chk_KL2.Name = "chk_KL2"
        Me.chk_KL2.Size = New System.Drawing.Size(138, 18)
        Me.chk_KL2.TabIndex = 2
        Me.chk_KL2.Text = "Klassement Mannen"
        Me.chk_KL2.UseVisualStyleBackColor = True
        '
        'chk_KL1
        '
        Me.chk_KL1.AutoSize = True
        Me.chk_KL1.Checked = True
        Me.chk_KL1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_KL1.Location = New System.Drawing.Point(8, 35)
        Me.chk_KL1.Name = "chk_KL1"
        Me.chk_KL1.Size = New System.Drawing.Size(128, 18)
        Me.chk_KL1.TabIndex = 1
        Me.chk_KL1.Text = "Klassement Totaal"
        Me.chk_KL1.UseVisualStyleBackColor = True
        '
        'btn_gen
        '
        Me.btn_gen.Location = New System.Drawing.Point(3, 3)
        Me.btn_gen.Name = "btn_gen"
        Me.btn_gen.Size = New System.Drawing.Size(131, 26)
        Me.btn_gen.TabIndex = 0
        Me.btn_gen.Text = "&Genereer Uistlag"
        Me.btn_gen.UseVisualStyleBackColor = True
        '
        'btn_action
        '
        Me.btn_action.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_action.Enabled = False
        Me.btn_action.Image = CType(resources.GetObject("btn_action.Image"), System.Drawing.Image)
        Me.btn_action.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_action.Location = New System.Drawing.Point(403, 305)
        Me.btn_action.Name = "btn_action"
        Me.btn_action.Size = New System.Drawing.Size(76, 25)
        Me.btn_action.TabIndex = 1
        Me.btn_action.Text = "&Start"
        Me.btn_action.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_action.UseVisualStyleBackColor = True
        '
        'status_Strp
        '
        Me.status_Strp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_GLOBAL_status})
        Me.status_Strp.Location = New System.Drawing.Point(0, 336)
        Me.status_Strp.Name = "status_Strp"
        Me.status_Strp.Size = New System.Drawing.Size(482, 22)
        Me.status_Strp.TabIndex = 2
        Me.status_Strp.Text = "StatusStrip1"
        '
        'lbl_GLOBAL_status
        '
        Me.lbl_GLOBAL_status.Name = "lbl_GLOBAL_status"
        Me.lbl_GLOBAL_status.Size = New System.Drawing.Size(0, 17)
        '
        'lbl_copyrights
        '
        Me.lbl_copyrights.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_copyrights.AutoSize = True
        Me.lbl_copyrights.ForeColor = System.Drawing.Color.DimGray
        Me.lbl_copyrights.Location = New System.Drawing.Point(9, 302)
        Me.lbl_copyrights.Name = "lbl_copyrights"
        Me.lbl_copyrights.Size = New System.Drawing.Size(172, 14)
        Me.lbl_copyrights.TabIndex = 3
        Me.lbl_copyrights.Text = "© Maxim Van de Wynckel 2012"
        '
        'btn_connect
        '
        Me.btn_connect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_connect.Image = CType(resources.GetObject("btn_connect.Image"), System.Drawing.Image)
        Me.btn_connect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_connect.Location = New System.Drawing.Point(298, 305)
        Me.btn_connect.Name = "btn_connect"
        Me.btn_connect.Size = New System.Drawing.Size(99, 25)
        Me.btn_connect.TabIndex = 4
        Me.btn_connect.Text = "&Verbinden"
        Me.btn_connect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_connect.UseVisualStyleBackColor = True
        '
        'btn_lock
        '
        Me.btn_lock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_lock.Image = CType(resources.GetObject("btn_lock.Image"), System.Drawing.Image)
        Me.btn_lock.Location = New System.Drawing.Point(456, 1)
        Me.btn_lock.Name = "btn_lock"
        Me.btn_lock.Size = New System.Drawing.Size(23, 23)
        Me.btn_lock.TabIndex = 2
        Me.btn_lock.UseVisualStyleBackColor = True
        '
        'LBL_VERSION
        '
        Me.LBL_VERSION.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBL_VERSION.AutoSize = True
        Me.LBL_VERSION.ForeColor = System.Drawing.Color.DimGray
        Me.LBL_VERSION.Location = New System.Drawing.Point(22, 317)
        Me.LBL_VERSION.Name = "LBL_VERSION"
        Me.LBL_VERSION.Size = New System.Drawing.Size(137, 14)
        Me.LBL_VERSION.TabIndex = 5
        Me.LBL_VERSION.Text = "Versie: 1.2.2 (20/04/2012"
        '
        'Progbar_Generate
        '
        Me.Progbar_Generate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Progbar_Generate.Location = New System.Drawing.Point(3, 245)
        Me.Progbar_Generate.Name = "Progbar_Generate"
        Me.Progbar_Generate.Size = New System.Drawing.Size(463, 23)
        Me.Progbar_Generate.TabIndex = 5
        '
        'frm_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 358)
        Me.Controls.Add(Me.LBL_VERSION)
        Me.Controls.Add(Me.btn_lock)
        Me.Controls.Add(Me.btn_connect)
        Me.Controls.Add(Me.lbl_copyrights)
        Me.Controls.Add(Me.status_Strp)
        Me.Controls.Add(Me.btn_action)
        Me.Controls.Add(Me.Tabs)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(490, 326)
        Me.Name = "frm_main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trappenloop"
        Me.Tabs.ResumeLayout(False)
        Me.tab_bsic.ResumeLayout(False)
        Me.grp_trial.ResumeLayout(False)
        Me.grp_trial.PerformLayout()
        Me.time_panel.ResumeLayout(False)
        Me.pnl_webcam.ResumeLayout(False)
        CType(Me.Media, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_gegevens.ResumeLayout(False)
        Me.grp_gegevens.PerformLayout()
        Me.pnl_image.ResumeLayout(False)
        CType(Me.pic_pas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_deelnemers.ResumeLayout(False)
        Me.pnl_controls.ResumeLayout(False)
        Me.tab_output.ResumeLayout(False)
        Me.tab_output.PerformLayout()
        Me.status_Strp.ResumeLayout(False)
        Me.status_Strp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents tab_bsic As System.Windows.Forms.TabPage
    Friend WithEvents grp_gegevens As System.Windows.Forms.GroupBox
    Friend WithEvents btn_read As System.Windows.Forms.Button
    Friend WithEvents lbl_achternaam As System.Windows.Forms.Label
    Friend WithEvents lbl_voornaam As System.Windows.Forms.Label
    Friend WithEvents lbl_achternaam_txt As System.Windows.Forms.Label
    Friend WithEvents lbl_voornaam_txt As System.Windows.Forms.Label
    Friend WithEvents tab_deelnemers As System.Windows.Forms.TabPage
    Friend WithEvents btn_action As System.Windows.Forms.Button
    Friend WithEvents btn_manual As System.Windows.Forms.Button
    Friend WithEvents grp_trial As System.Windows.Forms.GroupBox
    Friend WithEvents Label_web As System.Windows.Forms.Label
    Friend WithEvents pnl_webcam As System.Windows.Forms.Panel
    Friend WithEvents time_panel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_time As System.Windows.Forms.Label
    Friend WithEvents lst_players As System.Windows.Forms.ListBox
    Friend WithEvents pnl_controls As System.Windows.Forms.Panel
    Friend WithEvents btn_change As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents lbl_status_txt As System.Windows.Forms.Label
    Friend WithEvents lbl_status As System.Windows.Forms.Label
    Friend WithEvents status_Strp As System.Windows.Forms.StatusStrip
    Friend WithEvents lbl_copyrights As System.Windows.Forms.Label
    Friend WithEvents btn_connect As System.Windows.Forms.Button
    Friend WithEvents lbl_GLOBAL_status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbl_geslacht As System.Windows.Forms.Label
    Friend WithEvents lbl_geslacht_txt As System.Windows.Forms.Label
    Friend WithEvents lbl_length As System.Windows.Forms.Label
    Friend WithEvents txt_length_txt As System.Windows.Forms.Label
    Friend WithEvents pnl_image As System.Windows.Forms.Panel
    Friend WithEvents pic_pas As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_weight As System.Windows.Forms.Label
    Friend WithEvents lbl_weight_txt As System.Windows.Forms.Label
    Friend WithEvents lbl_bmi As System.Windows.Forms.Label
    Friend WithEvents lbl_bmi_txt As System.Windows.Forms.Label
    Friend WithEvents btn_lock As System.Windows.Forms.Button
    Friend WithEvents tab_output As System.Windows.Forms.TabPage
    Friend WithEvents chk_KL4 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_KL3 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_KL2 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_KL1 As System.Windows.Forms.CheckBox
    Friend WithEvents btn_gen As System.Windows.Forms.Button
    Friend WithEvents Media As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents LBL_VERSION As System.Windows.Forms.Label
    Friend WithEvents Progbar_Generate As System.Windows.Forms.ProgressBar

End Class
