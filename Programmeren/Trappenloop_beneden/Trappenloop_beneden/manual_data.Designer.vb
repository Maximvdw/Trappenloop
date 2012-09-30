<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class manual_data
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbmale = New System.Windows.Forms.RadioButton()
        Me.rbfemale = New System.Windows.Forms.RadioButton()
        Me.txt_voornaam = New System.Windows.Forms.TextBox()
        Me.txt_achternaam = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.grp_basic = New System.Windows.Forms.GroupBox()
        Me.grp_extra = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_weight = New System.Windows.Forms.TextBox()
        Me.txt_length = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pic_picture = New System.Windows.Forms.PictureBox()
        Me.grp_trial = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_date = New System.Windows.Forms.TextBox()
        Me.txt_time = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.grp_basic.SuspendLayout()
        Me.grp_extra.SuspendLayout()
        CType(Me.pic_picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_trial.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Voornaam:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Achternaam:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Geslacht:"
        '
        'rbmale
        '
        Me.rbmale.AutoSize = True
        Me.rbmale.Checked = True
        Me.rbmale.Location = New System.Drawing.Point(99, 67)
        Me.rbmale.Name = "rbmale"
        Me.rbmale.Size = New System.Drawing.Size(46, 17)
        Me.rbmale.TabIndex = 3
        Me.rbmale.TabStop = True
        Me.rbmale.Text = "Man"
        Me.rbmale.UseVisualStyleBackColor = True
        '
        'rbfemale
        '
        Me.rbfemale.AutoSize = True
        Me.rbfemale.Location = New System.Drawing.Point(168, 67)
        Me.rbfemale.Name = "rbfemale"
        Me.rbfemale.Size = New System.Drawing.Size(55, 17)
        Me.rbfemale.TabIndex = 4
        Me.rbfemale.Text = "Vrouw"
        Me.rbfemale.UseVisualStyleBackColor = True
        '
        'txt_voornaam
        '
        Me.txt_voornaam.Location = New System.Drawing.Point(99, 15)
        Me.txt_voornaam.Name = "txt_voornaam"
        Me.txt_voornaam.Size = New System.Drawing.Size(200, 20)
        Me.txt_voornaam.TabIndex = 5
        '
        'txt_achternaam
        '
        Me.txt_achternaam.Location = New System.Drawing.Point(99, 41)
        Me.txt_achternaam.Name = "txt_achternaam"
        Me.txt_achternaam.Size = New System.Drawing.Size(200, 20)
        Me.txt_achternaam.TabIndex = 6
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(342, 264)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(74, 24)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "&Opslaan"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'grp_basic
        '
        Me.grp_basic.Controls.Add(Me.Label1)
        Me.grp_basic.Controls.Add(Me.Label2)
        Me.grp_basic.Controls.Add(Me.txt_achternaam)
        Me.grp_basic.Controls.Add(Me.rbfemale)
        Me.grp_basic.Controls.Add(Me.txt_voornaam)
        Me.grp_basic.Controls.Add(Me.rbmale)
        Me.grp_basic.Controls.Add(Me.Label3)
        Me.grp_basic.Location = New System.Drawing.Point(9, 1)
        Me.grp_basic.Name = "grp_basic"
        Me.grp_basic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grp_basic.Size = New System.Drawing.Size(319, 96)
        Me.grp_basic.TabIndex = 8
        Me.grp_basic.TabStop = False
        Me.grp_basic.Text = "Basis Informatie"
        '
        'grp_extra
        '
        Me.grp_extra.Controls.Add(Me.Label7)
        Me.grp_extra.Controls.Add(Me.Label6)
        Me.grp_extra.Controls.Add(Me.txt_weight)
        Me.grp_extra.Controls.Add(Me.txt_length)
        Me.grp_extra.Controls.Add(Me.Label5)
        Me.grp_extra.Controls.Add(Me.Label4)
        Me.grp_extra.Location = New System.Drawing.Point(9, 103)
        Me.grp_extra.Name = "grp_extra"
        Me.grp_extra.Size = New System.Drawing.Size(319, 69)
        Me.grp_extra.TabIndex = 9
        Me.grp_extra.TabStop = False
        Me.grp_extra.Text = "Bijkomende Informatie"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(268, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Kg"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(268, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "cm"
        '
        'txt_weight
        '
        Me.txt_weight.Location = New System.Drawing.Point(99, 42)
        Me.txt_weight.Name = "txt_weight"
        Me.txt_weight.Size = New System.Drawing.Size(163, 20)
        Me.txt_weight.TabIndex = 9
        '
        'txt_length
        '
        Me.txt_length.Location = New System.Drawing.Point(99, 16)
        Me.txt_length.Name = "txt_length"
        Me.txt_length.Size = New System.Drawing.Size(163, 20)
        Me.txt_length.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Gewicht: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Lengte: "
        '
        'pic_picture
        '
        Me.pic_picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_picture.Location = New System.Drawing.Point(334, 18)
        Me.pic_picture.Name = "pic_picture"
        Me.pic_picture.Size = New System.Drawing.Size(82, 62)
        Me.pic_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_picture.TabIndex = 10
        Me.pic_picture.TabStop = False
        '
        'grp_trial
        '
        Me.grp_trial.Controls.Add(Me.Label8)
        Me.grp_trial.Controls.Add(Me.Label9)
        Me.grp_trial.Controls.Add(Me.txt_date)
        Me.grp_trial.Controls.Add(Me.txt_time)
        Me.grp_trial.Controls.Add(Me.Label10)
        Me.grp_trial.Controls.Add(Me.Label11)
        Me.grp_trial.Enabled = False
        Me.grp_trial.Location = New System.Drawing.Point(9, 178)
        Me.grp_trial.Name = "grp_trial"
        Me.grp_trial.Size = New System.Drawing.Size(319, 69)
        Me.grp_trial.TabIndex = 12
        Me.grp_trial.TabStop = False
        Me.grp_trial.Text = "Loop Gegevens"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(268, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(268, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "ms"
        '
        'txt_date
        '
        Me.txt_date.Location = New System.Drawing.Point(99, 42)
        Me.txt_date.Name = "txt_date"
        Me.txt_date.Size = New System.Drawing.Size(163, 20)
        Me.txt_date.TabIndex = 9
        '
        'txt_time
        '
        Me.txt_time.Location = New System.Drawing.Point(99, 16)
        Me.txt_time.Name = "txt_time"
        Me.txt_time.Size = New System.Drawing.Size(163, 20)
        Me.txt_time.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 15)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Start tijd:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 15)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Looptijd: "
        '
        'manual_data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 291)
        Me.Controls.Add(Me.grp_trial)
        Me.Controls.Add(Me.pic_picture)
        Me.Controls.Add(Me.grp_extra)
        Me.Controls.Add(Me.grp_basic)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "manual_data"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Handmatige Invoer"
        Me.grp_basic.ResumeLayout(False)
        Me.grp_basic.PerformLayout()
        Me.grp_extra.ResumeLayout(False)
        Me.grp_extra.PerformLayout()
        CType(Me.pic_picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_trial.ResumeLayout(False)
        Me.grp_trial.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbmale As System.Windows.Forms.RadioButton
    Friend WithEvents rbfemale As System.Windows.Forms.RadioButton
    Friend WithEvents txt_voornaam As System.Windows.Forms.TextBox
    Friend WithEvents txt_achternaam As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents grp_basic As System.Windows.Forms.GroupBox
    Friend WithEvents grp_extra As System.Windows.Forms.GroupBox
    Friend WithEvents pic_picture As System.Windows.Forms.PictureBox
    Friend WithEvents txt_weight As System.Windows.Forms.TextBox
    Friend WithEvents txt_length As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grp_trial As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_date As System.Windows.Forms.TextBox
    Friend WithEvents txt_time As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
