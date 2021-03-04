Imports System.Data.OleDb
Imports System.Runtime.Caching

Public Class TalieDescargaRegistro
    Inherits System.Web.UI.Page

    Private Sub CarregarEquipesOperador()

        Dim Ds As New DataTable
        Ds = EquipeDAO.CarregarEquipesOperador()

        Me.DC_Equipe.DataSource = Ds
        Me.DC_Equipe.DataBind()

        Me.DC_Equipe.Items.Insert(0, "--Selecione uma equipe--")
        Me.DC_Equipe.SelectedIndex = 0

        Ds.Dispose()

    End Sub

    Private Sub CarregarEquipesConferente()

        Dim Ds As New DataTable
        Ds = EquipeDAO.CarregarEquipesConferente()

        If Ds IsNot Nothing Then
            If Ds.Rows.Count > 0 Then

                Me.DC_Conferente.DataSource = Ds
                Me.DC_Conferente.DataBind()

                Me.DC_Conferente.Items.Insert(0, "--Selecione um conferente--")
                Me.DC_Conferente.SelectedIndex = 0

            End If
        End If

        Ds.Dispose()

    End Sub

    Private Sub CarregarOperacao()

        Me.DC_Operacao.ClearSelection()

        Me.DC_Operacao.Items.Add("MANUAL")
        Me.DC_Operacao.Items.Add("AUTOMATIZADA")

        Me.DC_Operacao.Items.Insert(0, "--Selecione a operaçao--")

        Me.DC_Operacao.SelectedIndex = 0

    End Sub

    Protected Sub CarregaPadroes()

        Dim CodigoEquipe As Long = 0

        If Me.DC_Conferente.SelectedIndex = 0 Then

            CodigoEquipe = EquipeDAO.ObterCodigoEquipePorLogin(Val(Me.lblCodigoUsuario.Value))

            If Val(CodigoEquipe) > 0 Then
                Me.DC_Conferente.SelectedValue = CodigoEquipe
            End If

        End If

        If Me.DC_Equipe.SelectedIndex = 0 Then

            Dim Horario As String
            Horario = Format(Now, "HHmm")

            If Horario >= "0800" And Horario <= "1559" Then Me.DC_Equipe.SelectedValue = 62
            If Horario >= "1600" And Horario <= "2359" Then Me.DC_Equipe.SelectedValue = 101
            If Horario >= "0000" And Horario <= "0759" Then Me.DC_Equipe.SelectedValue = 270

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1))
        Response.Cache.SetNoStore()

        If Request.QueryString("usuario") IsNot Nothing Then
            Me.lblCodigoUsuario.Value = Request.QueryString("usuario").ToString()
            Me.lblCodigoPatio.Value = Request.QueryString("patio").ToString()
        Else
            Response.Redirect("../Index.aspx")
        End If

        If Not Page.IsPostBack Then

            CarregarEquipesOperador()
            CarregarEquipesConferente()
            CarregarOperacao()
            CarregaPadroes()

            If Request.QueryString("temp_registro_txtTalie") IsNot Nothing Then

                Me.txtTalie.Text = Request.QueryString("temp_registro_txtTalie").ToString()
                Me.TxtInicio.Text = Request.QueryString("temp_registro_TxtInicio").ToString()
                Me.TxtFim.Text = Request.QueryString("temp_registro_TxtFim").ToString()
                Me.TxtRegistro.Text = Request.QueryString("temp_registro_TxtRegistro").ToString()
                Me.TxtPlaca.Text = Request.QueryString("temp_registro_TxtPlaca").ToString()
                Me.TxtReserva.Text = Request.QueryString("temp_registro_TxtReserva").ToString()
                Me.TxtCliente.Text = Request.QueryString("temp_registro_TxtCliente").ToString()
                Me.DC_Conferente.SelectedValue = Request.QueryString("temp_registro_DC_Conferente").ToString()
                Me.DC_Equipe.SelectedValue = Request.QueryString("temp_registro_DC_Equipe").ToString()
                Me.DC_Operacao.SelectedValue = Request.QueryString("temp_registro_DC_Operacao").ToString()
                Me.lblCodigoBooking.Value = Request.QueryString("temp_registro_lblCodigoBooking").ToString()
                Me.lblCodigoGate.Value = Request.QueryString("temp_registro_lblCodigoGate").ToString()
                Me.lblCodigoRegistro.Value = Request.QueryString("temp_registro_lblCodigoRegistro").ToString()
                Me.lblCodigoReserva.Value = Request.QueryString("temp_registro_lblCodigoReserva").ToString()
                Me.lblCodigoUsuario.Value = Request.QueryString("temp_registro_lblCodigoUsuario").ToString()
                Me.lblCodigoPatio.Value = Request.QueryString("temp_registro_lblCodigoPatio").ToString()

            End If

        End If

        Me.TxtRegistro.Focus()

    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Function ObterDadosTalieAsync(ByVal Registro As String, ByVal Inicio As String, ByVal Usuario As String) As TalieDTO

        Dim Ds As New DataTable
        Dim TalieDto As New TalieDTO

        If Val(Registro) <> 0 Then

            TalieDto.Inconsistencia = String.Empty

            Ds = TalieRegistroDAO.ObterRegistrosTaliePorRegistro(Val(Registro))

            If Ds IsNot Nothing Then

                If Ds.Rows.Count > 0 Then

                    TalieDto.ExisteTalieAberto = True

                    TalieDto.Registro = Registro
                    TalieDto.CodigoTalie = Val(Ds.Rows(0)("AUTONUM_TALIE").ToString())
                    TalieDto.CodigoBooking = Val(Ds.Rows(0)("AUTONUM_BOO").ToString())

                    If Ds.Rows(0)("FORMA_OPERACAO").ToString() = String.Empty Then
                        TalieDto.Operacao = "AUTOMATIZADA"
                    Else
                        If Ds.Rows(0)("FORMA_OPERACAO").ToString() = "M" Then
                            TalieDto.Operacao = "MANUAL"
                        Else
                            TalieDto.Operacao = "AUTOMATIZADA"
                        End If
                    End If

                    If Val(Ds.Rows(0)("CONFERENTE").ToString()) <> 0 Then
                        TalieDto.Conferente = Val(Ds.Rows(0)("conferente").ToString())
                    End If

                    If Val(Ds.Rows(0)("EQUIPE").ToString()) <> 0 Then
                        TalieDto.Equipe = Val(Ds.Rows(0)("equipe").ToString())
                    End If

                    TalieDto.Placa = Ds.Rows(0)("PLACA").ToString()
                    TalieDto.Reserva = Ds.Rows(0)("REFERENCE").ToString()
                    TalieDto.CodigoGate = Val(Ds.Rows(0)("AUTONUM_GATE").ToString())
                    TalieDto.CodigoRegistro = Val(Registro)
                    TalieDto.Cliente = Ds.Rows(0)("FANTASIA").ToString()
                    TalieDto.Inicio = Convert.ToDateTime(Ds.Rows(0)("INICIO").ToString()).ToString("dd/MM/yyyy HH:mm")

                    If Ds.Rows(0)("TERMINO").ToString() <> "" Then
                        TalieDto.Termino = Convert.ToDateTime(Ds.Rows(0)("TERMINO").ToString()).ToString("dd/MM/yyyy HH:mm")
                    Else
                        TalieDto.Termino = String.Empty
                    End If

                    TalieDto.StatusTalie = String.Empty

                    If Val(Ds.Rows(0)("FLAG_FECHADO").ToString()) = 1 Then
                        TalieDto.StatusTalie = "TALIE FECHADO"
                    End If

                    TalieDto.Observacao = Ds.Rows(0)("OBS").ToString()

                Else

                    TalieDto.CodigoTalie = 0

                    TalieDto.Observacao = String.Empty
                    TalieDto.Operacao = String.Empty
                    TalieDto.Termino = String.Empty
                    TalieDto.StatusTalie = String.Empty

                    If Inicio = String.Empty Then
                        TalieDto.Inicio = Convert.ToDateTime(Now).ToString("dd/MM/yyyy HH:mm")
                    Else

                        If Not IsDate(Inicio) Then
                            TalieDto.Inconsistencia = "Data início inválida"
                            Return TalieDto
                        End If

                        If Mid(Inicio, 4, 2) > "12" Then
                            TalieDto.Inconsistencia = "Data início inválida"
                            Return TalieDto
                        End If

                        TalieDto.Inicio = Inicio

                    End If

                    If TalieRegistroDAO.ContemRegistroPorCodigo(Val(Registro)) = 0 Then
                        TalieDto.Inconsistencia = "Registro não encontrado"
                        Return TalieDto
                    End If

                    TalieDto.Placa = TalieRegistroDAO.ObterPlacaPorCodigoRegistro(Val(Registro))

                    If TalieRegistroDAO.ExisteGateIn(Val(Registro)) = 0 Then
                        TalieDto.Inconsistencia = "Gate IN não localizado"
                        Return TalieDto
                    End If

                    Ds = TalieRegistroDAO.ObterRegistrosGate(Val(Registro))

                    If Ds IsNot Nothing Then
                        If Ds.Rows.Count > 0 Then
                            TalieDto.Reserva = Ds.Rows(0)("REFERENCE").ToString()
                            TalieDto.CodigoBooking = Ds.Rows(0)("AUTONUM_BOO").ToString()
                            TalieDto.CodigoGate = Ds.Rows(0)("AUTONUM").ToString()
                            TalieDto.Cliente = Ds.Rows(0)("FANTASIA").ToString()
                            TalieDto.CodigoRegistro = Val(Registro)
                        End If
                    End If

                End If

            End If

        End If

        Dim CodigoEquipe As Long = 0

        If TalieDto.Conferente = 0 Then

            CodigoEquipe = EquipeDAO.ObterCodigoEquipePorLogin(Val(Usuario))

            If Val(CodigoEquipe) > 0 Then
                TalieDto.Conferente = CodigoEquipe
            End If

        End If

        If TalieDto.Equipe = 0 Then

            Dim Horario As String
            Horario = Convert.ToDateTime(Now).ToString("HHmm")

            If Horario >= "0800" And Horario <= "1559" Then TalieDto.Equipe = 62
            If Horario >= "1600" And Horario <= "2359" Then TalieDto.Equipe = 101
            If Horario >= "0000" And Horario <= "0759" Then TalieDto.Equipe = 270

        End If

        Ds.Dispose()

        Return TalieDto

    End Function

    Protected Sub DC_Conferente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DC_Conferente.SelectedIndexChanged
        DC_Equipe.Focus()
    End Sub

    Protected Sub BtMc_Click(sender As Object, e As EventArgs) Handles BtMc.Click

    End Sub

    Private Shared Function ValidarCampos(ByVal TalieDto As TalieDTO) As String

        If Val(TalieDto.CodigoTalie) <> 0 Then
            If TalieDAO.TalieFechado(Val(TalieDto.CodigoTalie)) = 1 Then
                Return "Talie Fechado - Operação cancelada"
            End If
        End If

        If TalieDto.Operacao = String.Empty Then
            Return "Informe o modo de operação"
        End If

        If Not IsDate(TalieDto.Inicio) Then
            Return "Favor informar a data de início"
        End If

        If Mid(TalieDto.Inicio, 4, 2) > "12" Then
            Return "Data inválida"
        End If

        Return String.Empty

    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function GravarTalieAsync(
                                           ByVal CodigoTalie As String,
                                           ByVal CodigoBooking As String,
                                           ByVal Placa As String,
                                           ByVal Inicio As String,
                                           ByVal Conferente As String,
                                           ByVal Equipe As String,
                                           ByVal Operacao As String,
                                           ByVal CodigoGate As String,
                                           ByVal Registro As String,
                                           ByVal Observacao As String) As String

        Dim Inconsistencias As String = String.Empty

        If Not IsNumeric(Conferente) Then
            Return "Selecione um Conferente"
        End If

        If Not IsNumeric(Equipe) Then
            Return "Selecione uma Equipe"
        End If

        Dim talieDto As New TalieDTO
        talieDto.CodigoTalie = CodigoTalie
        talieDto.CodigoBooking = CodigoBooking
        talieDto.Placa = Placa
        talieDto.Inicio = Inicio
        talieDto.Conferente = Conferente
        talieDto.Equipe = Equipe
        talieDto.Operacao = Operacao
        talieDto.CodigoGate = CodigoGate
        talieDto.Registro = Registro
        talieDto.Observacao = Observacao

        Inconsistencias = ValidarCampos(talieDto)

        If Inconsistencias <> String.Empty Then
            Return Inconsistencias
        End If

        If Val(CodigoTalie) = 0 Then

            If TalieDAO.TalieFechadoParaReservaPlaca(Val(CodigoBooking), Placa) = 1 Then
                Return "Já existe talie aberto para esta placa/reserva"
            End If

            If TalieDAO.ExisteTalieAberto(Registro) Then
                Return "Já existe talie aberto para este registro"
            End If




            CodigoTalie = TalieDAO.ObterProximoID()

            Try
                TalieDAO.InserirTalie(
                    Val(CodigoTalie),
                    Inicio,
                    Val(Conferente),
                    Val(Equipe),
                    Val(CodigoBooking),
                    UCase(Left(Operacao, 1)),
                    Placa,
                    Val(CodigoGate),
                    Val(Registro),
                    Observacao)

            Catch ex As Exception
                Return "Erro. Tente novamente." & ex.Message()
            End Try

        Else

            If TalieDAO.TalieFechado(Val(CodigoTalie)) = 1 Then
                Return "Talie Fechado. Alteração não permitida."
            End If

            Try

                TalieDAO.AlterarTalie(
                    Val(CodigoTalie),
                    Inicio,
                    Val(Conferente),
                    Val(Equipe),
                    UCase(Left(Operacao, 1)),
                    Observacao)

            Catch ex As Exception
                Return "Erro. Tente novamente." & ex.Message()
            End Try

        End If

        talieDto = Nothing

        Return CodigoTalie

    End Function

    Protected Sub BtCancelar_Click(sender As Object, e As EventArgs) Handles BtCancelar.Click
        Response.Redirect("TalieDescargaRegistro.aspx?usuario=" & Me.lblCodigoUsuario.Value & "&patio=" & Me.lblCodigoPatio.Value)
    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Function ExcluirTalieAsync(
                                            ByVal CodigoTalie As String) As String

        If Val(CodigoTalie) = 0 Then
            Return "Um registro deve estar selecionado para exclusao"
        End If

        If TalieDAO.TalieFechado(Val(CodigoTalie)) = 1 Then
            Return "Talie Fechado. Exclusão não permitida"
        End If

        Try

            TalieItemDAO.ExcluirItensPorTalie(Val(CodigoTalie))
            TalieDAO.ExcluirTalie(Val(CodigoTalie))

        Catch ex As Exception
            Return "Erro. Tente novamente."
        End Try

        Return String.Empty

    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function FinalizarTalieAsync(
                                            ByVal CodigoTalie As String,
                                            ByVal CodigoBooking As String,
                                            ByVal Registro As String,
                                            ByVal Inicio As String) As String

        Dim Gate As Long
        Dim Boo As Long
        Dim Balanca As Long

        Dim Patio As Short = 0
        Dim QtdD As Long = 0
        Dim QtdR As Long = 0
        Dim id As Long = 0

        Dim QR As Long = 0
        Dim QE As Long = 0

        If Val(CodigoTalie) = 0 Then
            Return "Um registro deve estar selecionado/gravado para ser finalizado"
        End If

        If TalieDAO.TalieFechado(Val(CodigoTalie)) = 1 Then
            Return "Já consta fechamento para este Talie - Operação cancelada"
        End If

        If TalieDAO.ExisteCargaCadastrada(Val(CodigoTalie)) = 0 Then
            Return "Finalize o talie somente após o lançamento da descarga"
        End If

        Try

            Patio = BookingDAO.ObterCodigoPatioPorBooking(Val(CodigoBooking))

            QtdD = TalieDAO.ObterQuantidadeDescargaPorTalie(Val(CodigoTalie))

            QtdR = RegistroDAO.ObterQuantidadeRegistro(Val(Registro))

            If QtdD <> QtdR Then
                Return "Quantidade descarregada diverge da quantidade registrada"
            End If

            'VERIFICA OBRIGATORIEDADE DAS POSICOES

            If ParametroDAO.FlagDescargaYard() = 1 Then

                If TalieDAO.ItensCadastradosSemPosicao(Val(CodigoTalie)) > 0 Then
                    Return "Existe item sem posição de armazem cadastrada - Operação Cancelada"
                End If

            End If

            If TalieDAO.TotalEtiquetas(Val(CodigoTalie)) = 0 Then
                Return "Não consta geração de etiquetas deste registro - Operação Cancelada"
            End If

            TalieDAO.GerarAlertaEtiqueta(Val(CodigoTalie), 1)

            If TalieDAO.MarcantesComPendencia(Val(CodigoTalie)) <> 0 Then
                Return "Consta pendencia de emissão de marcantes deste registro - Operação Cancelada"
            End If

            TalieDAO.GerarAlertaEtiqueta(Val(CodigoTalie), 2)

            Gate = 0
            Balanca = 0

            Dim Ds As New DataTable
            Ds = TalieDAO.ObterRegistrosTalie(Val(CodigoTalie))

            If Ds IsNot Nothing Then
                If Ds.Rows.Count > 0 Then

                    Gate = Ds.Rows(0)("Autonum_gate").ToString()
                    'Talie.Termino = Convert.ToDateTime(Now).ToString("HH:mm")
                    Balanca = GateDAO.ObterPesoBruto(Gate)

                    For Each Item As DataRow In Ds.Rows
                        Boo = Item("autonum_boo").ToString()

                        Dim Sql As String = ""
                        Sql = "select autonum_pcs from redex.tb_patio_cs where talie_descarga=" & Item("autonum_ti").ToString
                        Dim Rst As DataTable
                        Rst = OracleDAO.List(Sql)
                        If Rst.Rows.Count <> 0 Then
                            MsgBox("Ja consta consta item em estoque - Verifique e comunique o TI")
                        Else
                            id = PatioCsDAO.ObterProximoID()

                            Dim wPeso As Double = 0
                            wPeso = CDbl(Item("PESO").ToString)
                            If Item("QUANTIDADE").ToString() > 1 Then
                                wPeso = Math.Round(wPeso / Val(Item("QUANTIDADE").ToString), 3)
                            End If

                            PatioCsDAO.InserirRegistroPatioCS(
                                id,
                                Val(Item("AUTONUM_BCG").ToString()),
                                Val(Item("QUANTIDADE").ToString()),
                                Val(Item("AUTONUM_EMB").ToString()),
                                Val(Item("EMB_RESERVA").ToString()),
                                Val(Item("AUTONUM_PRO").ToString()),
                                Val(Item("AUTONUM_REGCS").ToString()),
                                Item("MARCA").ToString(),
                                Convert.ToDecimal(Item("COMPRIMENTO").ToString()),
                                Convert.ToDecimal(Item("LARGURA").ToString()),
                                Convert.ToDecimal(Item("ALTURA").ToString()),
                            Convert.ToDecimal(wPeso),
                            Inicio,
                                Val(Item("AUTONUM_NF").ToString()),
                                Val(Item("AUTONUM_TI").ToString()),
                                Val(Item("QTDE_ESTUFAGEM").ToString()),
                                Item("YARD").ToString(),
                                Item("ARMAZEM").ToString(),
                                Patio,
                                Item("IMO").ToString(),
                                Item("UNO").ToString(),
                                Item("IMO2").ToString(),
                                Item("UNO2").ToString(),
                                Item("IMO3").ToString(),
                                Item("UNO3").ToString(),
                                Item("IMO4").ToString(),
                                Item("UNO4").ToString(),
                                Item("CODPRODUTO").ToString())


                            PatioCsDAO.VinculaCargaMarcanteRDX(
                                id,
                                Val(CodigoTalie))

                            CargaSoltaYardDAO.InserirRegistroCargaSoltaYardM(Val(CodigoTalie))

                            ' If Item("YARD").ToString() <> String.Empty Then
                            '
                            'CargaSoltaYardDAO.InserirRegistroCargaSoltaYard(
                            'id,
                            'Val(Item("armazem").ToString()),
                            'Item("Yard").ToString(),
                            'Val(Item("Quantidade").ToString()))

                            'End If

                            If Item("IMO").ToString() <> String.Empty Then
                                BookingCargaDAO.AtualizaIMO(Item("IMO").ToString(), Val(Item("AUTONUM_BCG").ToString()))
                            End If

                            AmrGateDAO.InserirRegistroAmrGate(
                                Val(Item("AUTONUM_GATE").ToString()),
                                id,
                                Balanca,
                                Inicio,
                                Val(CodigoBooking))

                            PatioCsDAO.AtualizarPatioCsPai(id)


                        End If
                        Rst = Nothing

                    Next

                End If
            End If

            TalieRegistroDAO.FinalizarTalie(Val(CodigoTalie))

            'verifica toda carga entrada da reserva
            QR = BookingDAO.ObterQuantidade(Boo)

            QE = BookingDAO.ObterQuantidadeEntrada(Boo)

            If QR = QE And QE <> 0 Then
                BookingDAO.FinalizarBooking(Boo)
            End If

            BookingDAO.SetStatusReserva(Boo)

            Ds.Dispose()

            Return CodigoTalie

        Catch ex As Exception
            Return "Erro durante processo de Fechamento. Processo Cancelado"
        End Try

        Gate = Nothing
        Boo = Nothing
        Balanca = Nothing
        Patio = Nothing
        QtdD = Nothing
        QtdR = Nothing
        id = Nothing
        QR = Nothing
        QE = Nothing

    End Function

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If HttpContext.Current.Request.Cookies("ColTalieItens") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("ColTalieItens").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_TxtRegistro") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_TxtRegistro").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_TxtInicio") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_TxtInicio").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_TxtFim") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_TxtFim").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_TxtPlaca") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_TxtPlaca").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_TxtReserva") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_TxtReserva").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_TxtCliente") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_TxtCliente").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_DC_Conferente") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_DC_Conferente").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_DC_Equipe") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_DC_Equipe").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_DC_Operacao") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_DC_Operacao").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_TxtObservacao") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_TxtObservacao").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_lblCodigoBooking") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_lblCodigoBooking").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_lblCodigoGate") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_lblCodigoGate").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_lblCodigoRegistro") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_lblCodigoRegistro").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_lblCodigoReserva") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_lblCodigoReserva").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_txtTalie") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_txtTalie").Expires = Now.AddDays(-1)
        End If

        If HttpContext.Current.Request.Cookies("_coletorTalie_LBStatusTalie") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("_coletorTalie_LBStatusTalie").Expires = Now.AddDays(-1)
        End If

        Dim Controle As Control
        Dim Subcontrol As Control
        For Each Controle In Page.Controls
            For Each Subcontrol In Controle.Controls
                Subcontrol.Dispose()
            Next
            Controle.Dispose()
        Next

        Response.Redirect("../Menu.aspx")

    End Sub

    Protected Sub BtNext_Click(sender As Object, e As EventArgs) Handles BtNext.Click


    End Sub

    Protected Sub btnRetornarDados_Click(sender As Object, e As EventArgs) Handles btnRetornarDados.Click

    End Sub

    Protected Sub BtFinalizar_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub BtFinalizar_Click1(sender As Object, e As EventArgs) Handles BtFinalizar.Click

    End Sub

    Protected Sub BtGravar_Click(sender As Object, e As EventArgs) Handles BtGravar.Click

    End Sub

    Protected Sub BtObservacao_Click(sender As Object, e As EventArgs) Handles BtObservacao.Click

    End Sub

    Protected Sub TxtFim_TextChanged(sender As Object, e As EventArgs) Handles TxtFim.TextChanged

    End Sub
End Class