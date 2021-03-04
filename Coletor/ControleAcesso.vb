Module ControleAcesso

    Public Function ValidarNumerico(Campo As String) As Boolean
        ValidarNumerico = True
        If Campo <> "" And Not IsNumeric(Campo) Then
            ValidarNumerico = False
        End If
        If Campo <> "" And Val(Campo) < 0 Then
            ValidarNumerico = False
        End If
    End Function

    Public Function validarVersao() As String
        'VERIFICAÇÃO DA VERSÃO DO SISTEMA
        'Dim versaoEXE As String = Application.ProductVersion.ToString()
        Dim versaoEXE As String = Microsoft.VisualBasic.Format(My.Application.Info.Version.Major, "00") & "." & Microsoft.VisualBasic.Format(My.Application.Info.Version.Minor, "00") & "." & Microsoft.VisualBasic.Format(My.Application.Info.Version.Build, "0000") & "." & My.Application.Info.Version.Revision.ToString


        Dim wsSenhas As String = ""
        Dim VServico As loginMicroled.CriptografiaSoap

        Try
            Dim rsPar As New ADODB.Recordset
            'Dim sql As String
            'Sql = "SELECT NVL(DIR_MINUTA_PDF,' ') AS DIR_MINUTA_PDF FROM " & DAO.BancoOperador & "DTE_TB_PARAMETROS_SISTEMA "
            rsPar.Open("SELECT nvl(WS_SENHA,'') as WS_SENHA FROM SGIPA.TB_CONTROLE_SENHA", BD.Conexao, 3, 3)
            If rsPar.RecordCount = 0 Then
                Return "WS não parametrizado!"
            End If

            wsSenhas = rsPar.Fields("WS_SENHA").Value.ToString

            Dim VRequest As New loginMicroled.ObterVersaoRequestBody("COLETOR")
            Dim VRequisicao As New loginMicroled.ObterVersaoRequest(VRequest)

            If wsSenhas <> "" Then
                VServico = New loginMicroled.CriptografiaSoapClient("CriptografiaSoap", wsSenhas)
            Else
                VServico = New loginMicroled.CriptografiaSoapClient()
            End If
            Dim VRetorno = VServico.ObterVersao(VRequisicao).Body.ObterVersaoResult.ToString
            If versaoEXE.ToString.Replace(".", "") <> VRetorno.ToString.Replace(".", "") Then
                Return "Versão do sistema incorreta ou não ativa!"
            Else
                Return "OK"
            End If



        Catch ex As Exception
            Return "Ocorreu um erro ao validar a versão do sistema, contate o suporte"

        End Try

    End Function

    Public Function validarUsuario(tabelaLogin As String, usuario As String, senha As String) As String
        Dim lgRequest As New loginMicroled.ValidarUsuarioRequestBody(tabelaLogin, usuario, senha)
        Dim lgRequisicao As New loginMicroled.ValidarUsuarioRequest(lgRequest)
        Dim wsSenhas As String = ""
        Dim lgServico As loginMicroled.CriptografiaSoap
        Try
            Dim rsPar As New ADODB.Recordset
            rsPar.Open("SELECT nvl(WS_SENHA,'') as WS_SENHA FROM SGIPA.TB_CONTROLE_SENHA", BD.Conexao, 3, 3)
            If rsPar.RecordCount = 0 Then
                Return "WS não parametrizado!"
            End If

            wsSenhas = rsPar.Fields("WS_SENHA").Value.ToString

            If wsSenhas <> "" Then
                lgServico = New loginMicroled.CriptografiaSoapClient("CriptografiaSoap", wsSenhas)
            Else
                lgServico = New loginMicroled.CriptografiaSoapClient
            End If
            Dim lgRetorno = lgServico.ValidarUsuario(lgRequisicao).Body.ValidarUsuarioResult.ToString

            Return lgRetorno.ToString

        Catch ex As Exception
            Return "Ocorreu um erro ao validar o usuário, contate o suporte"
        End Try
    End Function


    Public Function alterarSenha(novaSenha As String, tabelaLogin As String, usuario As String) As String


        Dim ALRequest As New loginMicroled.alterarSenhaRequestBody(novaSenha, tabelaLogin, usuario)
        Dim ALRequisicao As New loginMicroled.alterarSenhaRequest(ALRequest)
        Dim wsSenhas As String = ""
        Dim ALServico As loginMicroled.CriptografiaSoap
        Try
            Dim rsPar As New ADODB.Recordset
            rsPar.Open("SELECT NVL(WS_SENHA,'') AS WS_SENHA FROM SGIPA.TB_CONTROLE_SENHA", BD.Conexao, 3, 3)
            If rsPar.RecordCount = 0 Then
                Return "WS não parametrizado!"
            End If
            wsSenhas = rsPar.Fields("WS_SENHA").Value.ToString

            If wsSenhas <> "" Then
                ALServico = New loginMicroled.CriptografiaSoapClient("CriptografiaSoap", wsSenhas)
            Else
                ALServico = New loginMicroled.CriptografiaSoapClient
            End If
            Dim ALRetorno = ALServico.alterarSenha(ALRequisicao).Body.alterarSenhaResult.ToString

            Return ALRetorno.ToString

        Catch ex As Exception
            Return "Ocorreu um erro ao tentar alterar a senha!"

        End Try

    End Function




End Module
