Friend Class LoginDialogForm
    Private Sub LoginDialogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
    Private _Username As String
    Public ReadOnly Property Username() As String
        Get
            Return _Username
        End Get
    End Property
    Private _Password As String
    Public ReadOnly Property Password() As String
        Get
            Return _Password
        End Get
    End Property
    Private _SaveCredentials As Boolean
    Public ReadOnly Property SaveCredentials() As Boolean
        Get
            Return _SaveCredentials
        End Get
    End Property

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        _SaveCredentials = chkRemember.Checked
        _Username = cboUserNames.SelectedText
        _Password = txtPassword.Text
        If _Username = "Administrator" And _Password = "trappenloop2012" Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else

        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.Activate()
        Me.BringToFront()
        Me.Focus()
        cboUserNames.Focus()
    End Sub
    Friend Event QuerySearchForUser(ByVal sender As Object, ByRef e As EventArgs.QuerySearchForUserEventArgs)
    Private Sub btnFindUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindUser.Click
        Dim e1 As New EventArgs.QuerySearchForUserEventArgs
        RaiseEvent QuerySearchForUser(Me, e1)
        If Not String.IsNullOrEmpty(e1.Username) Then
            cboUserNames.Text = e1.Username
            txtPassword.Text = String.Empty
        End If
    End Sub
End Class