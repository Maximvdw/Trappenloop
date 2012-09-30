Imports System.ComponentModel

''' <summary>
''' Login dialog to mimic windows login dialog
''' </summary>
<ToolboxBitmap(GetType(LoginDialog), "Key24.png")> _
Public Class LoginDialog
    ''' <summary>
    ''' Occurs when user clicks the search for user button.
    ''' </summary>
    <Description("Occurs when user clicks the search for user button")> _
    Public Event QuerySearchForUser(ByVal sender As Object, ByRef e As EventArgs.QuerySearchForUserEventArgs)
    ''' <summary>
    ''' Occurs when login dialog diaplays so you can supply a list of previously used login names.
    ''' </summary>
    <Description("Occurs when login dialog diaplays so you can supply a list of previously used login names.")> _
    Public Event QueryPreviouslyUsedUsernames(ByVal sender As Object, ByRef e As EventArgs.QueryPreviouslyUsedUsernamesEventArgs)
    ''' <summary>
    ''' Occurs when login displays so you can supply previously used credentials.
    ''' </summary>
    <Description("Occurs when login displays so you can supply previously used credentials.")> _
    Public Event QueryInitialCredentials(ByVal sender As Object, ByRef e As EventArgs.QueryInitialCredentialsEventArgs)
    ''' <summary>
    ''' Occurs when user clicks the OK button and the SavePassword checkbox is checked so the credentials can be saved.
    ''' </summary>
    <Description("Occurs when user clicks the OK button and the SavePassword checkbox is checked so the credentials can be saved.")> _
    Public Event SaveCredentials(ByVal sender As Object, ByVal e As EventArgs.SaveCredentialsEventArgs)

    ''' <summary>
    ''' Shows the dialog.
    ''' </summary>
    ''' <param name="owner">The owner.</param>
    ''' <returns>DialogResult</returns>
    Public Function ShowDialog(ByVal owner As System.Windows.Forms.IWin32Window) As System.Windows.Forms.DialogResult
        Dim result As System.Windows.Forms.DialogResult = Windows.Forms.DialogResult.Cancel
        Using frm As New LoginDialogForm
            AddHandler frm.QuerySearchForUser, AddressOf SearchForUser_Clicked
            Dim e As New EventArgs.QueryInitialCredentialsEventArgs(_ShowRememberCheckbox And _RememberCheckboxChecked)
            Dim e1 As New EventArgs.QueryPreviouslyUsedUsernamesEventArgs
            RaiseEvent QueryInitialCredentials(Me, e)
            If e.Cancel Then Return Windows.Forms.DialogResult.Cancel
            RaiseEvent QueryPreviouslyUsedUsernames(Me, e1)
            If e1.Cancel Then Return DialogResult.Cancel
            If Not IsNothing(_CustomBitmap) Then frm.PictureBox1.Image = _CustomBitmap
            frm.btnFindUser.Enabled = _EnableSearchForUser
            frm.cboUserNames.DataSource = e1.Usernames
            frm.txtPassword.Text = e.Password
            frm.cboUserNames.Text = e.UserName
            frm.chkRemember.Visible = _ShowRememberCheckbox
            If _ShowRememberCheckbox Then frm.chkRemember.Checked = _RememberCheckboxChecked
            frm.Text = _Title
            frm.lblDescription.Text = _Description
            frm.BringToFront()
            frm.Activate()
            frm.TopMost = True
            result = frm.ShowDialog(owner)
            If result = Windows.Forms.DialogResult.OK Then
                _Username = frm.Username
                _Password = frm.Password
                If frm.chkRemember.Checked Then RaiseEvent SaveCredentials(Me, New EventArgs.SaveCredentialsEventArgs(_ApplicationName, _Username, _Password))
            End If
        End Using
        Return result
    End Function
    Private _Title As String = "Login"
    ''' <summary>
    ''' Gets or sets the title.
    ''' </summary>
    ''' <value>
    ''' The title.
    ''' </value>
    <DefaultValue("Login"), Description("Gets or sets the title.")> _
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
        End Set
    End Property
    Private _Description As String = "Please supply your credentials..."
    ''' <summary>
    ''' Gets or sets the description.
    ''' </summary>
    ''' <value>
    ''' The description.
    ''' </value>
    <DefaultValue("Please supply your credentials..."), Description("Gets or sets the description.")> _
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property
    Private _ApplicationName As String = Nothing
    ''' <summary>
    ''' Gets or sets the name of the application.
    ''' </summary>
    ''' <value>
    ''' The name of the application.
    ''' </value>
    <Description("Gets or sets the name of the application.")> _
    Public Property ApplicationName() As String
        Get
            Return _ApplicationName
        End Get
        Set(ByVal value As String)
            _ApplicationName = value
        End Set
    End Property
    Private _ShowRememberCheckbox As Boolean = True
    ''' <summary>
    ''' Indicates whether show remember checkbox is displayed.
    ''' </summary>
    ''' <value>
    ''' <c>true</c> if show remember checkbox is displayed; otherwise, <c>false</c>.
    ''' </value>
    <DefaultValue(True), Description("Indicates whether show remember checkbox is displayed.")> _
    Public Property ShowRememberCheckbox() As Boolean
        Get
            Return _ShowRememberCheckbox
        End Get
        Set(ByVal value As Boolean)
            _ShowRememberCheckbox = value
            If Not value Then _RememberCheckboxChecked = False
        End Set
    End Property
    Private _RememberCheckboxChecked As Boolean = False
    ''' <summary>
    ''' Indicates whether the show remember checkbox is checked.
    ''' </summary>
    ''' <value>
    ''' <c>true</c> if show remember checkbox is checked; otherwise, <c>false</c>.    ''' 
    ''' </value>
    <DefaultValue(False), Description("Indicates whether the show remember checkbox is checked.")> _
    Public Property RememberCheckboxChecked() As Boolean
        Get
            Return _RememberCheckboxChecked
        End Get
        Set(ByVal value As Boolean)
            _RememberCheckboxChecked = value
        End Set
    End Property
    Private _CustomBitmap As Image
    ''' <summary>
    ''' Gets or sets the custom bitmap.
    ''' </summary>
    ''' <value>
    ''' The custom bitmap.
    ''' </value>
    <Description("Gets or sets the custom bitmap.")> _
    Public Property CustomBitmap() As Image
        Get
            Return _CustomBitmap
        End Get
        Set(ByVal value As Image)
            _CustomBitmap = value
        End Set
    End Property
    Private _EnableSearchForUser As Boolean
    ''' <summary>
    ''' Indicates whether the search for user button is enabled.
    ''' </summary>
    ''' <value>
    ''' <c>true</c> to enable search for user; otherwise, <c>false</c>.
    ''' </value>
    <DefaultValue(False), Description("Indicates whether the search for user button is enabled.")> _
    Public Property EnableSearchForUser() As Boolean
        Get
            Return _EnableSearchForUser
        End Get
        Set(ByVal value As Boolean)
            _EnableSearchForUser = value
        End Set
    End Property
    Private _Username As String
    ''' <summary>
    ''' Gets the username.
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property Username() As String
        Get
            Return _Username
        End Get
    End Property
    Private _Password As String
    ''' <summary>
    ''' Gets the password.
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property Password() As String
        Get
            Return _Password
        End Get
    End Property
    Private Sub SearchForUser_Clicked(ByVal sender As Object, ByRef e As EventArgs.QuerySearchForUserEventArgs)
        RaiseEvent QuerySearchForUser(Me, e)
    End Sub
End Class



