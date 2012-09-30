<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class LoginDialogForm
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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginDialogForm))
        Me.lblDescription = New System.Windows.Forms.Label
        Me.lblUsername = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.cboUserNames = New System.Windows.Forms.ComboBox
        Me.btnFindUser = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.chkRemember = New System.Windows.Forms.CheckBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(13, 73)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(287, 23)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = "The description goes here"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(16, 116)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(61, 13)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "User name:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(16, 143)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "Password:"
        '
        'cboUserNames
        '
        Me.cboUserNames.FormattingEnabled = True
        Me.HelpProvider1.SetHelpString(Me.cboUserNames, "Provides a space for you to type or select the user name that is required by the " & _
                "server/application.")
        Me.cboUserNames.Location = New System.Drawing.Point(83, 113)
        Me.cboUserNames.Name = "cboUserNames"
        Me.HelpProvider1.SetShowHelp(Me.cboUserNames, True)
        Me.cboUserNames.Size = New System.Drawing.Size(183, 21)
        Me.cboUserNames.TabIndex = 2
        '
        'btnFindUser
        '
        Me.btnFindUser.Enabled = False
        Me.HelpProvider1.SetHelpString(Me.btnFindUser, "Provides the ability to search for a user.")
        Me.btnFindUser.Location = New System.Drawing.Point(272, 113)
        Me.btnFindUser.Name = "btnFindUser"
        Me.HelpProvider1.SetShowHelp(Me.btnFindUser, True)
        Me.btnFindUser.Size = New System.Drawing.Size(28, 21)
        Me.btnFindUser.TabIndex = 3
        Me.btnFindUser.Text = "..."
        Me.btnFindUser.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.HelpProvider1.SetHelpString(Me.txtPassword, "Provides a space for you to type the password of the selected user.")
        Me.txtPassword.Location = New System.Drawing.Point(83, 140)
        Me.txtPassword.Name = "txtPassword"
        Me.HelpProvider1.SetShowHelp(Me.txtPassword, True)
        Me.txtPassword.Size = New System.Drawing.Size(183, 20)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'chkRemember
        '
        Me.chkRemember.AutoSize = True
        Me.HelpProvider1.SetHelpString(Me.chkRemember, "Specifies whether the user name and password will be saved for future use.")
        Me.chkRemember.Location = New System.Drawing.Point(83, 173)
        Me.chkRemember.Name = "chkRemember"
        Me.HelpProvider1.SetShowHelp(Me.chkRemember, True)
        Me.chkRemember.Size = New System.Drawing.Size(141, 17)
        Me.chkRemember.TabIndex = 6
        Me.chkRemember.Text = "Remember my password"
        Me.chkRemember.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.HelpProvider1.SetHelpString(Me.btnOK, "Accepts the currently entered user name and password.")
        Me.btnOK.Location = New System.Drawing.Point(144, 229)
        Me.btnOK.Name = "btnOK"
        Me.HelpProvider1.SetShowHelp(Me.btnOK, True)
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.HelpProvider1.SetHelpString(Me.btnCancel, "Cancels the dialog and returns without supplying user name or password.")
        Me.btnCancel.Location = New System.Drawing.Point(225, 229)
        Me.btnCancel.Name = "btnCancel"
        Me.HelpProvider1.SetShowHelp(Me.btnCancel, True)
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 250
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 59)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(312, 3)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(312, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'LoginDialogForm
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(312, 266)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkRemember)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.btnFindUser)
        Me.Controls.Add(Me.cboUserNames)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginDialogForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Goes Here"
        Me.TopMost = True
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents cboUserNames As System.Windows.Forms.ComboBox
    Friend WithEvents btnFindUser As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents chkRemember As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
End Class