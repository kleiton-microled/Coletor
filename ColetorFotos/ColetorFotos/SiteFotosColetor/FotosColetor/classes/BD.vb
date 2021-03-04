Public Class BD

    Private Shared _Servidor As String
    Private Shared _Schema As String
    Private Shared _Usuario As String
    Private Shared _Senha As String
    Private Shared _BancoEmUso As String
    Private Shared _BancoOperador As String
    Private Shared _BancoSgipa As String
    Private Shared _Provedor As String
    Private Shared _ControleSenha As String
    Private Shared _SenhaEncriptada As String
    Private Shared _Conexao As ADODB.Connection

    Public Shared LinhasAfetadas As Integer

    Public Shared Property Servidor() As String
        Get
            Return _Servidor
        End Get
        Set(ByVal value As String)
            _Servidor = value
        End Set
    End Property

    Public Shared Property ControleSenha() As String
        Get
            Return _ControleSenha
        End Get
        Set(ByVal value As String)
            _ControleSenha = value
        End Set
    End Property

    Public Shared Property SenhaEncriptada() As String
        Get
            Return _SenhaEncriptada
        End Get
        Set(ByVal value As String)
            _SenhaEncriptada = value
        End Set
    End Property

    Public Shared Property Schema() As String
        Get
            Return _Schema
        End Get
        Set(ByVal value As String)
            _Schema = value
        End Set
    End Property

    Public Shared Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Public Shared Property Senha() As String
        Get
            Return _Senha
        End Get
        Set(ByVal value As String)
            _Senha = value
        End Set
    End Property

    Public Shared Property BancoEmUso() As String
        Get
            Return _BancoEmUso
        End Get
        Set(ByVal value As String)
            _BancoEmUso = value
        End Set
    End Property

    Public Shared ReadOnly Property BancoOperador() As String
        Get
            If BancoEmUso = "ORACLE" Then
                Return "OPERADOR."
            Else
                Return "OPERADOR.DBO."
            End If
        End Get
    End Property

    Public Shared ReadOnly Property BancoSgipa() As String
        Get
            If BancoEmUso = "ORACLE" Then
                Return "SGIPA."
            Else
                Return "SGIPA.DBO."
            End If
        End Get
    End Property

    Public Shared Property Provedor() As String
        Get
            Return _Provedor
        End Get
        Set(ByVal value As String)
            _Provedor = value
        End Set
    End Property

    Public Shared ReadOnly Property StringConexao
        Get
            If BancoEmUso = "ORACLE" Then
                Return String.Format("Provider={0};Data Source={1};User ID={2};Password={3};Unicode=True;PLSQLRSet=true", Provedor, Servidor, Usuario, Senha)
            Else
                Return String.Format("Provider=SQLOLEDB.1;Data Source={0};Initial Catalog={1};User ID={2};Password={3}", Servidor, Schema, Usuario, Senha)
            End If
        End Get
    End Property

    Public Shared Function Conexao() As ADODB.Connection
        Try
            If _Conexao Is Nothing Then
                _Conexao = New ADODB.Connection
                _Conexao.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                _Conexao.Open(StringConexao)
            End If
            Return _Conexao
        Catch ex As Exception
            _Conexao = New ADODB.Connection
            _Conexao.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            _Conexao.Open(StringConexao)
            Return _Conexao
        End Try

    End Function

    Shared Sub New()

        Provedor = ConfigurationManager.AppSettings("Provedor").ToString()
        Servidor = ConfigurationManager.AppSettings("Servidor").ToString()
        Schema = ConfigurationManager.AppSettings("Schema").ToString()
        Usuario = ConfigurationManager.AppSettings("Usuario").ToString()
        Senha = ConfigurationManager.AppSettings("Senha").ToString()
        BancoEmUso = ConfigurationManager.AppSettings("Banco").ToString()
        ControleSenha = ConfigurationManager.AppSettings("ControleSenha").ToString()

    End Sub

End Class
