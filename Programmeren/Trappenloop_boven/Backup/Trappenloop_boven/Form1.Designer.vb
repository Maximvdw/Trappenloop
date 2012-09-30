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
        Me.layout_frm = New System.Windows.Forms.TableLayoutPanel
        Me.lbl_timer = New System.Windows.Forms.Label
        Me.lbl_tijd_Txt = New System.Windows.Forms.Label
        Me.lbl_message = New System.Windows.Forms.Label
        Me.piccap = New System.Windows.Forms.PictureBox
        Me.layout_frm.SuspendLayout()
        CType(Me.piccap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layout_frm
        '
        Me.layout_frm.ColumnCount = 3
        Me.layout_frm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.layout_frm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.layout_frm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.layout_frm.Controls.Add(Me.lbl_timer, 1, 1)
        Me.layout_frm.Controls.Add(Me.lbl_tijd_Txt, 1, 0)
        Me.layout_frm.Controls.Add(Me.lbl_message, 1, 2)
        Me.layout_frm.Controls.Add(Me.piccap, 2, 2)
        Me.layout_frm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layout_frm.Location = New System.Drawing.Point(0, 0)
        Me.layout_frm.Name = "layout_frm"
        Me.layout_frm.RowCount = 3
        Me.layout_frm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.layout_frm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 500.0!))
        Me.layout_frm.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 166.0!))
        Me.layout_frm.Size = New System.Drawing.Size(1062, 687)
        Me.layout_frm.TabIndex = 0
        '
        'lbl_timer
        '
        Me.lbl_timer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_timer.Font = New System.Drawing.Font("Calibri", 150.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_timer.Location = New System.Drawing.Point(109, 110)
        Me.lbl_timer.Name = "lbl_timer"
        Me.lbl_timer.Size = New System.Drawing.Size(843, 500)
        Me.lbl_timer.TabIndex = 0
        Me.lbl_timer.Text = "00:00:00"
        Me.lbl_timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_tijd_Txt
        '
        Me.lbl_tijd_Txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_tijd_Txt.Font = New System.Drawing.Font("Calibri", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tijd_Txt.Location = New System.Drawing.Point(109, 0)
        Me.lbl_tijd_Txt.Name = "lbl_tijd_Txt"
        Me.lbl_tijd_Txt.Size = New System.Drawing.Size(843, 110)
        Me.lbl_tijd_Txt.TabIndex = 1
        Me.lbl_tijd_Txt.Text = "Uw Tijd bedraagt:"
        Me.lbl_tijd_Txt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lbl_message
        '
        Me.lbl_message.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_message.Font = New System.Drawing.Font("Calibri", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_message.Location = New System.Drawing.Point(109, 610)
        Me.lbl_message.Name = "lbl_message"
        Me.lbl_message.Size = New System.Drawing.Size(843, 166)
        Me.lbl_message.TabIndex = 2
        Me.lbl_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'piccap
        '
        Me.piccap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.piccap.Location = New System.Drawing.Point(958, 613)
        Me.piccap.Name = "piccap"
        Me.piccap.Size = New System.Drawing.Size(101, 160)
        Me.piccap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.piccap.TabIndex = 3
        Me.piccap.TabStop = False
        Me.piccap.Visible = False
        '
        'frm_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1062, 687)
        Me.Controls.Add(Me.layout_frm)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trappenloop"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.layout_frm.ResumeLayout(False)
        CType(Me.piccap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents layout_frm As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_timer As System.Windows.Forms.Label
    Friend WithEvents lbl_tijd_Txt As System.Windows.Forms.Label
    Friend WithEvents lbl_message As System.Windows.Forms.Label
    Friend WithEvents piccap As System.Windows.Forms.PictureBox

End Class
