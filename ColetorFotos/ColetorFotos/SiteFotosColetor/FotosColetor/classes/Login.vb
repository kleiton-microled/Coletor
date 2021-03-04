Public Class Login

    Private _ConsultaReefer As Integer
    Public Shared AutonumPatio As Integer
    Public Shared NomePatio As String
    Public Shared NomeUsuario As String



    Public Property ConsultaReefer() As String
        Get
            Return _ConsultaReefer
        End Get
        Set(ByVal value As String)
            _ConsultaReefer = value
        End Set
    End Property

    Public Shared Function EfetuarLogin(ByVal Usuario As String, ByVal Senha As String) As Long

        Dim Rst As New ADODB.Recordset

        Try

            'If BD.ControleSenha = "0" Then
            If Senha <> "" Then
                Rst.Open(String.Format("SELECT AUTONUM FROM " & BD.BancoOperador & "TB_CAD_USUARIOS WHERE USUARIO='{0}' AND SENHA='{1}'", Usuario, Senha), BD.Conexao, 3, 3)
            Else
                Rst.Open(String.Format("SELECT AUTONUM FROM " & BD.BancoOperador & "TB_CAD_USUARIOS WHERE USUARIO='{0}'", Usuario), BD.Conexao, 3, 3)
            End If

            If Not Rst.EOF Then
                Return Rst.Fields("AUTONUM").Value
            End If

            'End If



        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return 0

    End Function

    Public Shared Function Valida_Acesso_Botao(QualUsuario As String, QualNomeBotao As String) As Boolean
        Dim Sql As String = String.Empty

        Sql = "SELECT 1 "
        Sql = Sql & " FROM"
        Sql = Sql & " " & BD.BancoOperador & "TB_SYS_FUNCOES"
        Sql = Sql & " ," & BD.BancoOperador & "TB_SYS_GRP_PERMISSOES"
        Sql = Sql & " ," & BD.BancoOperador & "TB_SYS_USER_GRUPOS "
        Sql = Sql & " ," & BD.BancoOperador & "TB_CAD_USUARIOS "
        Sql = Sql & " WHERE"
        Sql = Sql & "((tb_cad_usuarios.autonum = tb_sys_user_grupos.autonumuser) "
        Sql = Sql & " AND (tb_sys_funcoes.codfunc = tb_sys_grp_permissoes.codfunc) "
        Sql = Sql & " AND (tb_sys_grp_permissoes.codgrupo = tb_sys_user_grupos.codgrupo) "
        Sql = Sql & " AND (UPPER(tb_cad_usuarios.usuario) = '" & QualUsuario & "') "
        Sql = Sql & " AND (tb_sys_funcoes.sistema = 'COLETORWEB') "
        Sql = Sql & " AND (UPPER(tb_sys_funcoes.Nomeobj) = '" & QualNomeBotao & "')) "
        Sql = Sql & " and (tb_sys_grp_permissoes.codtipoperm=5) "

        Dim tbUA As New ADODB.Recordset
        tbUA.Open(Sql, BD.Conexao, 1, 1)
        If Not tbUA.EOF Then
            tbUA.Close()
            Return True
        Else
            tbUA.Close()
            Return False
        End If



    End Function


    Public Function UsuarioConsultaReefer(ByVal Usuario As String) As Boolean

        Dim Rst As New ADODB.Recordset

        Rst.Open(String.Format("SELECT NVL(FLAG_CON_REEFER,0) FLAG_CON_REEFER FROM " & BD.BancoOperador & "TB_CAD_USUARIOS WHERE USUARIO='{0}'", Usuario), BD.Conexao, 3, 3)

        If Not Rst.EOF Then
            If Convert.ToInt32(Rst.Fields("FLAG_CON_REEFER").Value.ToString()) = 1 Then
                Return True
            End If
        End If

        Return False

    End Function

    Public Function ConsultarPatio(ByVal Usuario As String) As String

        Dim Rst As New ADODB.Recordset

        Rst.Open(String.Format("SELECT B.DESCR_RESUMIDO FROM " & BD.BancoOperador & "TB_CAD_USUARIOS A LEFT JOIN " & BD.BancoOperador & "TB_PATIOS B ON A.PATIO_COLETOR = B.AUTONUM WHERE A.USUARIO='{0}'", Usuario), BD.Conexao, 3, 3)

        If Not Rst.EOF Then
            Return Rst.Fields("DESCR_RESUMIDO").Value.ToString()
        End If

        Return String.Empty

    End Function

    Public Function ConsultarAutonumPatio(ByVal Usuario As String) As String

        Dim Rst As New ADODB.Recordset

        Rst.Open(String.Format("SELECT B.AUTONUM FROM " & BD.BancoOperador & "TB_CAD_USUARIOS A LEFT JOIN " & BD.BancoOperador & "TB_PATIOS B ON A.PATIO_COLETOR = B.AUTONUM WHERE A.USUARIO='{0}'", Usuario), BD.Conexao, 3, 3)

        If Not Rst.EOF Then
            Return Rst.Fields("AUTONUM").Value.ToString()
        End If

        Return String.Empty

    End Function

    Public Function ConsultarEmpresa(ByVal Usuario) As String

        Dim Rst As New ADODB.Recordset

        Rst.Open(String.Format("SELECT B.RAZAO_SOCIAL FROM " & BD.BancoOperador & "TB_CAD_USUARIOS A LEFT JOIN " & BD.BancoSgipa & "TB_EMPRESAS B ON A.COD_EMPRESA = B.AUTONUM WHERE A.USUARIO='{0}'", Usuario), BD.Conexao, 3, 3)

        If Not Rst.EOF Then
            Return Rst.Fields("RAZAO_SOCIAL").Value.ToString()
        End If

        Return String.Empty

    End Function

End Class
