Namespace EventArgs
    Public Class QuerySearchForUserEventArgs
        Inherits System.EventArgs
        Private _Username As String
        Public Property Username() As String
            Friend Get
                Return _Username
            End Get
            Set(ByVal value As String)
                _Username = value
            End Set
        End Property
    End Class
    Public Class QueryInitialCredentialsEventArgs
        Inherits System.EventArgs
        Public Sub New(ByVal savePasswordEnabled As Boolean)
            _SavePasswordEnabled = savePasswordEnabled
        End Sub
        Private _Username As String
        Public Property UserName() As String
            Friend Get
                Return _Username
            End Get
            Set(ByVal value As String)
                _Username = value
            End Set
        End Property
        Private _Password As String
        Public Property Password() As String
            Friend Get
                Return _Password
            End Get
            Set(ByVal value As String)
                _Password = value
            End Set
        End Property
        Private _Cancel As Boolean
        Public Property Cancel() As Boolean
            Friend Get
                Return _Cancel
            End Get
            Set(ByVal value As Boolean)
                _Cancel = value
            End Set
        End Property
        Private _SavePasswordEnabled As Boolean
        Public ReadOnly Property SavePasswordEnabled() As Boolean
            Get
                Return _SavePasswordEnabled
            End Get
        End Property
    End Class

    Public Class SaveCredentialsEventArgs
        Inherits System.EventArgs
        Public Sub New(ByVal applicationName As String, ByVal username As String, ByVal password As String)
            _ApplicationName = applicationName
            _Username = username
            _Password = password
        End Sub
        Private _ApplicationName As String
        Public ReadOnly Property ApplicationName() As String
            Get
                Return _ApplicationName
            End Get
        End Property
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
    End Class

    Public Class QueryPreviouslyUsedUsernamesEventArgs
        Inherits System.EventArgs
        Private _Usernames As List(Of String)
        Public Property Usernames() As List(Of String)
            Friend Get
                Return _Usernames
            End Get
            Set(ByVal value As List(Of String))
                _Usernames = value
            End Set
        End Property
        Private _Cancel As Boolean
        Public Property Cancel() As Boolean
            Friend Get
                Return _Cancel
            End Get
            Set(ByVal value As Boolean)
                _Cancel = value
            End Set
        End Property
    End Class
End Namespace
