Imports System.Data.OleDb
Imports System.IO

Public Class OracleDAO

    Private Shared _Servidor As String
    Private Shared _Usuario As String
    Private Shared _Senha As String
    Private Shared _Schema As String
    Private Shared _Base As String

    Private Shared Connect As New OleDbConnection()
    Private Shared _StringConexao As String

    Public Shared Property Servidor() As String
        Get
            Return _Servidor
        End Get
        Set(ByVal value As String)
            _Servidor = value
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

    Public Shared Property Schema() As String
        Get
            Return _Schema
        End Get
        Set(ByVal value As String)
            _Schema = value
        End Set
    End Property

    Public Shared Property Base() As String
        Get
            Return _Base
        End Get
        Set(ByVal value As String)
            _Base = value
        End Set
    End Property

    Public Shared ReadOnly Property BancoOperador() As String
        Get
            Return "OPERADOR."
        End Get
    End Property

    Public Shared ReadOnly Property BancoSgipa() As String
        Get
            Return "SGIPA."
        End Get
    End Property

    Shared Sub New()

        Try

            Servidor = ConfigurationManager.AppSettings("Servidor").ToString()
            Schema = ConfigurationManager.AppSettings("Schema").ToString()
            Usuario = ConfigurationManager.AppSettings("Usuario").ToString()
            Senha = ConfigurationManager.AppSettings("Senha").ToString()

        Catch
            Throw New Exception("O Arquivo de configuração não foi encontrado ou contém erros.")
        End Try

        ConexaoBD()

    End Sub

    Private Shared Sub ConexaoBD()

        If Connect.State = ConnectionState.Closed Then

            Try
                Connect.ConnectionString = ConnectionString()
                Connect.Open()
            Catch ex As Exception
                Throw New Exception(String.Format("Falha na Conexão. {0}", ex.Message))
            End Try

        End If

    End Sub

    Public Shared Function ExecuteScalar(ByVal SQL As String) As Object

        Dim Result As Object = Nothing

        Using Cmd As New OleDbCommand()

            ConexaoBD()

            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = SQL
            Cmd.Connection = Connect

            Try
                Result = Cmd.ExecuteScalar()
            Catch ex As Exception
                Throw New Exception(String.Format("Falha na instrução SQL. {0}", ex.Message))
            End Try

        End Using

        Return If(Result Is Nothing, Nothing, Result.ToString())

    End Function

    Public Shared Function Execute(ByVal SQL As String) As Boolean

        Dim Success As Boolean = False

        Using Cmd As New OleDbCommand()

            ConexaoBD()

            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = SQL
            Cmd.Connection = Connect

            Try
                Cmd.ExecuteNonQuery()
                Success = True
            Catch ex As OleDbException
                Throw New Exception(String.Format("Falha na Conexão. {0}", ex.Message))
            End Try

        End Using

        Return Success

    End Function

    Public Shared Function List(ByVal SQL As String) As DataTable

        Using Adp As New OleDbDataAdapter()
            Using Cmd As New OleDbCommand()

                ConexaoBD()

                Dim Ds As New DataSet()

                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = SQL
                Cmd.Connection = Connect

                Try
                    Adp.SelectCommand = Cmd
                    Adp.Fill(Ds)
                    Return Ds.Tables(0)
                Catch ex As Exception
                    Throw New Exception(String.Format("Falha na Conexão. {0}", ex.Message))
                End Try

            End Using
        End Using

        Return Nothing

    End Function

    Public Shared Function LerCampoBLOB(ByVal SQL As String) As Byte()

        Dim Result As Object = Nothing

        Using Cmd As New OleDbCommand()

            Try

                ConexaoBD()

                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = SQL
                Cmd.Connection = Connect

                Dim imagemEmBytes As Byte() = DirectCast(Cmd.ExecuteScalar(), Byte())

                Result = imagemEmBytes

            Catch ex As Exception
                Result = Nothing
            End Try

        End Using

        Return Result

    End Function

    'Public Shared Function GravarCampoBLOB(ByVal SQL As String, ByVal Codigo As Integer) As Boolean

    '    Dim Result As Object = Nothing

    '    Dim ms As New System.IO.MemoryStream()
    '    Imagem.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

    '    Using Cmd As New OleDbCommand()

    '        Try

    '            ConexaoBD()

    '            Cmd.CommandType = CommandType.Text
    '            Cmd.CommandText = SQL
    '            Cmd.Connection = Connect

    '            Cmd.Parameters.Add("IMAGEM", OleDb.OleDbType.Binary).Value = ms.ToArray()
    '            Cmd.Parameters.Add("AUTONUM", OleDb.OleDbType.Integer).Value = Codigo

    '            Cmd.ExecuteNonQuery()

    '        Catch ex As Exception
    '            Result = Nothing
    '        End Try

    '    End Using

    '    Return Result

    'End Function

    Public Shared Function ConnectionString() As String
        Return String.Format("Provider=OraOLEDB.Oracle;Data Source={0};User ID={1};Password={2}", Servidor, Usuario, Senha)
    End Function

End Class
