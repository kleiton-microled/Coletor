Module ControleAcesso


    Public Sub validarVersao()
        'VERIFICAÇÃO DA VERSÃO DO SISTEMA
        Dim versaoEXE As String = Application.ProductVersion.ToString()
        Dim wsSenhas As String = ""
        Dim VServico As loginMicroled.CriptografiaSoap

        Try
            Dim rsPar As New DataTable
            'Dim sql As String
            'Sql = "SELECT NVL(DIR_MINUTA_PDF,' ') AS DIR_MINUTA_PDF FROM " & DAO.BancoOperador & "DTE_TB_PARAMETROS_SISTEMA "
            rsPar = DAO.Consultar("SELECT WS_SENHA FROM SGIPA.TB_CONTROLE_SENHA")
            If rsPar.Rows.Count <= 0 Then
                MsgBox("WS não parametrizado!", vbInformation, Application.ProductName)
                Err.Clear()
                End
            End If
            wsSenhas = nNull(rsPar.Rows(0)(0).ToString, 1)

            Dim VRequest As New loginMicroled.ObterVersaoRequestBody("FATURAMENTO-OP")
            Dim VRequisicao As New loginMicroled.ObterVersaoRequest(VRequest)

            If wsSenhas <> "" Then
                VServico = New loginMicroled.CriptografiaSoapClient("CriptografiaSoap", wsSenhas)
            Else
                VServico = New loginMicroled.CriptografiaSoapClient()
            End If
            Dim VRetorno = VServico.ObterVersao(VRequisicao).Body.ObterVersaoResult.ToString
            If nNull(versaoEXE.ToString.Replace(".", ""), 1) <> nNull(VRetorno.ToString.Replace(".", ""), 1) Then
                MsgBox("Versão do sistema incorreta ou não ativa!", vbInformation, Application.ProductName)
                Err.Clear()
                End
            End If
        Catch ex As Exception
            MsgBox("Ocorreu um erro ao validar a versão do sistema, contate o suporte" & vbCrLf & "Erro: " & Err.Description, vbInformation, Application.ProductName)
            Err.Clear()
            End
        End Try

    End Sub

    Public Function validarUsuario(tabelaLogin As String, usuario As String, senha As String) As String
        Dim lgRequest As New loginMicroled.ValidarUsuarioRequestBody(tabelaLogin, usuario, senha)
        Dim lgRequisicao As New loginMicroled.ValidarUsuarioRequest(lgRequest)
        Dim wsSenhas As String = ""
        Dim lgServico As loginMicroled.CriptografiaSoap
        Try
            Dim rsPar As New DataTable
            rsPar = DAO.Consultar("SELECT WS_SENHA FROM SGIPA.TB_CONTROLE_SENHA")
            If rsPar.Rows.Count <= 0 Then
                MsgBox("WS não parametrizado!", vbInformation, Application.ProductName)
                Err.Clear()
                End
            End If
            wsSenhas = nNull(rsPar.Rows(0)(0).ToString, 1)

            If wsSenhas <> "" Then
                lgServico = New loginMicroled.CriptografiaSoapClient("CriptografiaSoap", wsSenhas)
            Else
                lgServico = New loginMicroled.CriptografiaSoapClient
            End If
            Dim lgRetorno = lgServico.ValidarUsuario(lgRequisicao).Body.ValidarUsuarioResult.ToString

            Return lgRetorno.ToString

        Catch ex As Exception
            MsgBox("Ocorreu um erro ao validar o usuário, contate o suporte" & vbCrLf & "Erro: " & Err.Description, vbInformation, Application.ProductName)
            Err.Clear()
            End
        End Try
    End Function


    Public Function alterarSenha(novaSenha As String, tabelaLogin As String, usuario As String) As String


        Dim ALRequest As New loginMicroled.alterarSenhaRequestBody(novaSenha, tabelaLogin, usuario)
        Dim ALRequisicao As New loginMicroled.alterarSenhaRequest(ALRequest)
        Dim wsSenhas As String = ""
        Dim ALServico As loginMicroled.CriptografiaSoap
        Try
            Dim rsPar As New DataTable
            rsPar = DAO.Consultar("SELECT WS_SENHA FROM SGIPA.TB_CONTROLE_SENHA")
            If rsPar.Rows.Count <= 0 Then
                MsgBox("WS não parametrizado!", vbInformation, Application.ProductName)
                Err.Clear()
                End
            End If
            wsSenhas = nNull(rsPar.Rows(0)(0).ToString, 1)

            If wsSenhas <> "" Then
                ALServico = New loginMicroled.CriptografiaSoapClient("CriptografiaSoap", wsSenhas)
            Else
                ALServico = New loginMicroled.CriptografiaSoapClient
            End If
            Dim ALRetorno = ALServico.alterarSenha(ALRequisicao).Body.alterarSenhaResult.ToString

            Return ALRetorno.ToString
        Catch ex As Exception
            MsgBox("Ocorreu um erro ao tentar alterar a senha!" & vbCrLf & "Erro: " & ex.Message, vbInformation, Application.ProductName)
            End
        End Try

    End Function

    Public Sub gerarCriptografia(nomeSistema As String)
        Dim CPTRequest As New loginMicroled.EncriptarTabelaRequestBody(nomeSistema)
        Dim CPTRequisicao As New loginMicroled.EncriptarTabelaRequest(CPTRequest)
        Dim wsSenhas As String = ""
        Dim CPTServico As loginMicroled.CriptografiaSoap
        Try
            Dim rsPar As New DataTable
            rsPar = DAO.Consultar("SELECT WS_SENHA FROM SGIPA.TB_CONTROLE_SENHA")
            If rsPar.Rows.Count <= 0 Then
                MsgBox("WS não parametrizado!", vbInformation, Application.ProductName)
                Err.Clear()
                End
            End If
            wsSenhas = nNull(rsPar.Rows(0)(0).ToString, 1)

            If wsSenhas <> "" Then
                CPTServico = New loginMicroled.CriptografiaSoapClient("CriptografiaSoap", wsSenhas)
            Else
                CPTServico = New loginMicroled.CriptografiaSoapClient
            End If
            Dim CPTRetorno = CPTServico.EncriptarTabela(CPTRequisicao).Body.EncriptarTabelaResult.ToString
        Catch ex As Exception
            MsgBox("Ocorreu um erro ao tentar alterar a senha!" & vbCrLf & "Erro: " & ex.Message, vbInformation, Application.ProductName)
            End
        End Try
    End Sub

    Public Sub gerarDescriptografia(nomeSistema As String)
        Dim CPTRequest As New loginMicroled.DescriptarTabelaRequestBody(nomeSistema)
        Dim CPTRequisicao As New loginMicroled.DescriptarTabelaRequest(CPTRequest)
        Dim wsSenhas As String = ""
        Dim CPTServico As loginMicroled.CriptografiaSoap
        Try
            Dim rsPar As New DataTable
            rsPar = DAO.Consultar("SELECT WS_SENHA FROM SGIPA.TB_CONTROLE_SENHA")
            If rsPar.Rows.Count <= 0 Then
                MsgBox("WS não parametrizado!", vbInformation, Application.ProductName)
                Err.Clear()
                End
            End If
            wsSenhas = nNull(rsPar.Rows(0)(0).ToString, 1)

            If wsSenhas <> "" Then
                CPTServico = New loginMicroled.CriptografiaSoapClient("CriptografiaSoap", wsSenhas)
            Else
                CPTServico = New loginMicroled.CriptografiaSoapClient
            End If
            Dim CPTRetorno = CPTServico.DescriptarTabela(CPTRequisicao).Body.DescriptarTabelaResult.ToString

        Catch ex As Exception
            MsgBox("Ocorreu um erro ao tentar alterar a senha!" & vbCrLf & "Erro: " & ex.Message, vbInformation, Application.ProductName)
            End
        End Try
    End Sub



End Module
