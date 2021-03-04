Imports System.Web.Script.Services
Imports System.Web.Services

Public Class TalieDescargaItens
    Inherits System.Web.UI.Page

    <System.Web.Services.WebMethod()>
    Public Shared Function CarregaItemAsync(ByVal Item As String) As TalieItemDTO

        Dim TalieItemDto As New TalieItemDTO

        If String.IsNullOrEmpty(Item) Then
            TalieItemDto.Inconsistencia = "Um item deve estar selecionado."
            Return TalieItemDto
        End If

        TalieItemDto.Item = Item

        Dim rs As New DataTable
        rs = TalieItemDAO.ObterItens(Item)

        If rs IsNot Nothing Then
            If rs.Rows.Count = 0 Then
                TalieItemDto.Inconsistencia = "Item não localizado."
                Return TalieItemDto
            End If
        End If

        TalieItemDto.NumNF = Format(Val(rs.Rows(0)("NUM_NF").ToString()), "0000000000")

        TalieItemDto.CodigoNF = rs.Rows(0)("AUTONUM_NF").ToString()
        TalieItemDto.CodigoRegCs = rs.Rows(0)("AUTONUM_REGCS").ToString()

        TalieItemDto.Resumo = Resumo(TalieItemDto.CodigoRegCs)

        Dim rsPeso As New DataTable
        rsPeso = TalieItemDAO.ObterPesoQuantidade(Val(rs.Rows(0)("AUTONUM_REGCS").ToString()))

        If rsPeso IsNot Nothing Then
            If rsPeso.Rows.Count > 0 Then
                TalieItemDto.PesoBruto = rsPeso.Rows(0)("PESO_BRUTO").ToString()
                TalieItemDto.Quantidade = rsPeso.Rows(0)("QTDE").ToString()
            Else
                TalieItemDto.PesoBruto = 0
                TalieItemDto.Quantidade = 1
            End If
        End If

        rsPeso.Dispose()

        TalieItemDto.QtdeDescarga = rs.Rows(0)("QTDE_DESCARGA").ToString()
        TalieItemDto.Peso = rs.Rows(0)("PESOSTR").ToString()
        TalieItemDto.QtdeEstufagem = rs.Rows(0)("QTDE_ESTUFAGEM").ToString()
        TalieItemDto.Remonte = rs.Rows(0)("REMONTE").ToString()
        TalieItemDto.Fumigacao = rs.Rows(0)("FUMIGACAO").ToString()
        TalieItemDto.CLAC = rs.Rows(0)("CLAC").ToString()
        TalieItemDto.CLAL = rs.Rows(0)("CLAL").ToString()
        TalieItemDto.CLAA = rs.Rows(0)("CLAA").ToString()
        TalieItemDto.IMO1 = rs.Rows(0)("IMO").ToString()
        TalieItemDto.UNO1 = rs.Rows(0)("UNO").ToString()
        TalieItemDto.IMO2 = rs.Rows(0)("IMO2").ToString()
        TalieItemDto.UNO2 = rs.Rows(0)("UNO2").ToString()
        TalieItemDto.IMO3 = rs.Rows(0)("IMO3").ToString()
        TalieItemDto.UNO3 = rs.Rows(0)("UNO3").ToString()
        TalieItemDto.IMO4 = rs.Rows(0)("IMO4").ToString()
        TalieItemDto.UNO4 = rs.Rows(0)("UNO4").ToString()
        TalieItemDto.Local = rs.Rows(0)("YARD").ToString()

        ' TalieItemDto.Peso = String.Format("{0:N3}", Convert.ToDecimal(rs.Rows(0)("PESOSTR").ToString())).PadLeft(8, "0"c).Replace(",", ".")

        If rs.Rows(0)("AUTONUM_EMB").ToString() <> String.Empty Then
            TalieItemDto.CodigoEmbalagem = rs.Rows(0)("SIGLA").ToString()
            TalieItemDto.Embalagem = rs.Rows(0)("EMBALAGEM").ToString()
        Else
            TalieItemDto.CodigoEmbalagem = 0
            TalieItemDto.Embalagem = String.Empty
        End If

        If Val(rs.Rows(0)("FLAG_MADEIRA").ToString()) = 1 Then
            TalieItemDto.FlagMadeira = True
        Else
            TalieItemDto.FlagMadeira = False
        End If

        If Val(rs.Rows(0)("FLAG_FRAGIL").ToString()) = 1 Then
            TalieItemDto.FlagFragil = True
        Else
            TalieItemDto.FlagFragil = False
        End If

        TalieItemDto.Resumo = Resumo(TalieItemDto.CodigoRegCs)

        rs.Dispose()

        Return TalieItemDto

    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function CarregarDescarga(ByVal Talie As String) As List(Of TalieDescargaDTO)

        Dim CodigoTalie As Long = 0

        If IsNumeric(Talie) Then
            CodigoTalie = Talie
        End If

        Return TalieItemDAO.CarregarDescarga(CodigoTalie)

    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function ObterEmbalagemPorCodigo(ByVal Codigo As String) As String
        If Codigo.Length > 1 Then
            Return EmbalagemDAO.ObterDescricaoEmbalagemPorCodigo(Codigo.ToUpper())
        End If
        Return String.Empty
    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function CalcularPeso(
                                       ByVal PesoBrutoCarga As String,
                                       ByVal QuantidadeCarga As String,
                                       ByVal QuantidadeInformada As String) As String

        Dim Resultado As Decimal = 0.000

        Try
            If IsNumeric(PesoBrutoCarga) And IsNumeric(QuantidadeCarga) And IsNumeric(QuantidadeInformada) Then
                Resultado = String.Format("{0:N3}", (Val(PesoBrutoCarga) / Val(QuantidadeCarga)) * Val(QuantidadeInformada))
            End If
        Catch
            Return "0"
        End Try

        Return Resultado.ToString().PadLeft(8, "0"c).Replace(",", ".")

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1))
        Response.Cache.SetNoStore()

        If Not Page.IsPostBack Then

            If Request.QueryString("CodigoTalie") IsNot Nothing Then
                If IsNumeric(Request.QueryString("CodigoTalie").ToString()) Then
                    Me.lblCodigoTalie.Value = Request.QueryString("CodigoTalie").ToString()
                End If
            End If

            If Request.QueryString("CodigoBooking") IsNot Nothing Then
                If IsNumeric(Request.QueryString("CodigoBooking").ToString()) Then
                    Me.lblCodigoBooking.Value = Request.QueryString("CodigoBooking").ToString()
                End If
            End If

            If Request.QueryString("CodigoRegistro") IsNot Nothing Then
                If IsNumeric(Request.QueryString("CodigoRegistro").ToString()) Then
                    Me.lblCodigoRegistro.Value = Request.QueryString("CodigoRegistro").ToString()
                End If
            End If

            If Request.QueryString("CodigoPatio") IsNot Nothing Then
                If IsNumeric(Request.QueryString("CodigoPatio").ToString()) Then
                    Me.lblCodigoPatio.Value = Request.QueryString("CodigoPatio").ToString()
                End If
            End If



            Me.temp_registro_txtTalie.Value = Request.QueryString("temp_registro_txtTalie").ToString()
            Me.temp_registro_TxtInicio.Value = Request.QueryString("temp_registro_TxtInicio").ToString()
            Me.temp_registro_TxtFim.Value = Request.QueryString("temp_registro_TxtFim").ToString()
            Me.temp_registro_TxtRegistro.Value = Request.QueryString("temp_registro_TxtRegistro").ToString()
            Me.temp_registro_TxtPlaca.Value = Request.QueryString("temp_registro_TxtPlaca").ToString()
            Me.temp_registro_TxtReserva.Value = Request.QueryString("temp_registro_TxtReserva").ToString()
            Me.temp_registro_TxtCliente.Value = Request.QueryString("temp_registro_TxtCliente").ToString()
            Me.temp_registro_DC_Conferente.Value = Request.QueryString("temp_registro_DC_Conferente").ToString()
            Me.temp_registro_DC_Equipe.Value = Request.QueryString("temp_registro_DC_Equipe").ToString()
            Me.temp_registro_DC_Operacao.Value = Request.QueryString("temp_registro_DC_Operacao").ToString()
            Me.temp_registro_lblCodigoBooking.Value = Request.QueryString("temp_registro_lblCodigoBooking").ToString()
            Me.temp_registro_lblCodigoGate.Value = Request.QueryString("temp_registro_lblCodigoGate").ToString()
            Me.temp_registro_lblCodigoRegistro.Value = Request.QueryString("temp_registro_lblCodigoRegistro").ToString()
            Me.temp_registro_lblCodigoReserva.Value = Request.QueryString("temp_registro_lblCodigoReserva").ToString()
            Me.temp_registro_lblCodigoUsuario.Value = Request.QueryString("temp_registro_lblCodigoUsuario").ToString()
            Me.temp_registro_lblCodigoPatio.Value = Request.QueryString("temp_registro_lblCodigoPatio").ToString()


            Me.ListaDescarga.DataSource = TalieItemDAO.CarregarDescarga(Me.lblCodigoTalie.Value).ToList()
            Me.ListaDescarga.DataBind()

        End If

    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Function BuscaNF(
                                  ByVal NumNF As String,
                                  ByVal CodigoBooking As String,
                                  ByVal CodigoRegistro As String) As TalieItemDTO

        Dim TalieItemDto As New TalieItemDTO

        If Not IsNumeric(CodigoBooking) Then
            TalieItemDto.Inconsistencia = "Código do Booking indisponível"
            Return TalieItemDto
        End If

        If Not IsNumeric(CodigoRegistro) Then
            TalieItemDto.Inconsistencia = "Código do Registro indisponível"
            Return TalieItemDto
        End If

        If NumNF = String.Empty Then
            TalieItemDto.Inconsistencia = "Por favor, informe a NF."
            Return TalieItemDto
        End If

        TalieItemDto.NumNF = Format(Val(NumNF), "0000000000")

        Dim ds As New DataTable
        ds = TalieItemDAO.ObterIDNotaFiscal(Val(CodigoBooking), TalieItemDto.NumNF)

        If ds IsNot Nothing Then
            If ds.Rows.Count > 0 Then
                TalieItemDto.CodigoNF = Val(ds.Rows(0)("AUTONUM_NF").ToString())
            End If
        End If

        ds = TalieItemDAO.ObterItensNF(Val(CodigoRegistro), TalieItemDto.NumNF)

        If ds IsNot Nothing Then
            If ds.Rows.Count = 0 Then
                TalieItemDto.Inconsistencia = "Nota Fiscal não identificada no registro."
                Return TalieItemDto
            End If
        End If

        TalieItemDto.CodigoEmbalagem = ds.Rows(0)("SIGLA").ToString()
        TalieItemDto.Embalagem = ds.Rows(0)("EMBALAGEM").ToString()
        TalieItemDto.UNO1 = ds.Rows(0)("UNO").ToString()
        TalieItemDto.UNO2 = ds.Rows(0)("UNO2").ToString()
        TalieItemDto.UNO3 = ds.Rows(0)("UNO3").ToString()
        TalieItemDto.UNO4 = ds.Rows(0)("UNO4").ToString()

        TalieItemDto.IMO1 = ds.Rows(0)("IMO").ToString()
        TalieItemDto.IMO2 = ds.Rows(0)("IMO2").ToString()
        TalieItemDto.IMO3 = ds.Rows(0)("IMO3").ToString()
        TalieItemDto.IMO4 = ds.Rows(0)("IMO4").ToString()

        TalieItemDto.PesoBruto = Val(ds.Rows(0)("PESO_BRUTO").ToString())
        TalieItemDto.Quantidade = Val(ds.Rows(0)("QTDE").ToString())

        TalieItemDto.CodigoRegCs = Val(ds.Rows(0)("ID").ToString())

        TalieItemDto.Resumo = Resumo(TalieItemDto.CodigoRegCs)

        ds.Dispose()

        Return TalieItemDto

    End Function

    Private Shared Function Resumo(ByVal CodigoRegCs As Long) As TalieItemResumoDTO

        Dim ResumoDto As New TalieItemResumoDTO

        ResumoDto.QtdeD = TalieItemDAO.ObterResumoQuantidadeDescarga(Val(CodigoRegCs))
        ResumoDto.QtdeR = TalieItemDAO.ObterResumoQuantidade(Val(CodigoRegCs))

        If ResumoDto.QtdeD = ResumoDto.QtdeR Then
            ResumoDto.FimNota = True
        Else
            ResumoDto.FimNota = False
        End If

        Return ResumoDto

    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function ObterSaldoRestante(ByVal CodigoRegCs As String) As TalieItemResumoDTO

        Dim ResumoDto As New TalieItemResumoDTO

        ResumoDto.QtdeD = TalieItemDAO.ObterResumoQuantidadeDescarga(Val(CodigoRegCs))
        ResumoDto.QtdeR = TalieItemDAO.ObterResumoQuantidade(Val(CodigoRegCs))

        If ResumoDto.QtdeD = 0 And ResumoDto.QtdeR = 0 Then
            ResumoDto.FimNota = False
        Else
            If ResumoDto.QtdeD = ResumoDto.QtdeR Then
                ResumoDto.FimNota = True
            Else
                ResumoDto.FimNota = False
            End If
        End If

        Return ResumoDto

    End Function

    Private Shared Function ValidarCampos(ByVal TalieItemDto As TalieItemDTO) As String

        If Not ValidarNumerico(TalieItemDto.Qtde) Then
            Return "Conteúdo do campo inválido."
        End If

        If Not ValidarNumerico(TalieItemDto.Remonte) Then
            Return "Conteudo do campo Remonte invalido. Preencha apenas com números"
        End If

        If TalieItemDto.IMO1 <> String.Empty Then
            If TalieItemDAO.ConsultarIMOPorCodigoDaCarga(TalieItemDto.IMO1) = 0 Then
                Return "IMO1 não cadastrado"
            End If
        End If

        If TalieItemDto.IMO2 <> String.Empty Then
            If TalieItemDAO.ConsultarIMOPorCodigoDaCarga(TalieItemDto.IMO2) = 0 Then
                Return "IMO2 não cadastrado"
            End If
        End If

        If TalieItemDto.IMO3 <> String.Empty Then
            If TalieItemDAO.ConsultarIMOPorCodigoDaCarga(TalieItemDto.IMO3) = 0 Then
                Return "IMO3 não cadastrado"
            End If
        End If

        If TalieItemDto.IMO4 <> String.Empty Then
            If TalieItemDAO.ConsultarIMOPorCodigoDaCarga(TalieItemDto.IMO4) = 0 Then
                Return "IMO4 não cadastrado"
            End If
        End If

        If TalieItemDto.UNO1 <> String.Empty Then
            If TalieItemDAO.ConsultarUNOPorCodigoDaCarga(TalieItemDto.UNO1) = 0 Then
                Return "UNO1 não cadastrado"
            End If
        End If

        If TalieItemDto.UNO2 <> String.Empty Then
            If TalieItemDAO.ConsultarUNOPorCodigoDaCarga(TalieItemDto.UNO2) = 0 Then
                Return "UNO2 não cadastrado"
            End If
        End If

        If TalieItemDto.UNO3 <> String.Empty Then
            If TalieItemDAO.ConsultarUNOPorCodigoDaCarga(TalieItemDto.UNO3) = 0 Then
                Return "UNO3 não cadastrado"
            End If
        End If

        If TalieItemDto.UNO4 <> String.Empty Then
            If TalieItemDAO.ConsultarUNOPorCodigoDaCarga(TalieItemDto.UNO4) = 0 Then
                Return "UNO4 não cadastrado"
            End If
        End If

        If TalieDAO.TalieFechado(Val(TalieItemDto.CodigoTalie)) = 1 Then
            Return "Talie Fechado - Operação cancelada"
        End If

        If Val(TalieItemDto.Qtde) = 0 Then
            Return "Quantidade não informada"
        End If

        If Val(TalieItemDto.CodigoEmbalagem) = 0 Then
            Return "Embalagem não informada"
        End If

        If TalieItemDto.NumNF = String.Empty Then
            Return "NF nao informada"
        End If

        If Val(TalieItemDto.CodigoTalie) = 0 Then
            Return "Talie não informado"
            Return False
        End If

        If Val(TalieItemDto.CodigoRegCs) = 0 Then
            Return "Item de descarga inválido"
        End If

        If Val(TalieItemDto.Remonte.Length) > 3 Then
            Return "Remonte inválido."
        End If

        Return String.Empty

    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function GravarItemAsync(
                                    ByVal CodigoRegCs As String,
                                    ByVal CodigoTalie As String,
                                    ByVal CodigoItem As String,
                                    ByVal Qtde As String,
                                    ByVal Patio As String,
                                    ByVal Yard As String,
                                    ByVal CLAC As String,
                                    ByVal CLAL As String,
                                    ByVal CLAA As String,
                                    ByVal Peso As String,
                                    ByVal Remonte As String,
                                    ByVal Fumigacao As String,
                                    ByVal Fragil As String,
                                    ByVal Madeira As String,
                                    ByVal IMO1 As String,
                                    ByVal IMO2 As String,
                                    ByVal IMO3 As String,
                                    ByVal IMO4 As String,
                                    ByVal UNO1 As String,
                                    ByVal UNO2 As String,
                                    ByVal UNO3 As String,
                                    ByVal UNO4 As String,
                                    ByVal CodigoEmbalagem As String,
                                    ByVal CodigoNF As String,
                                    ByVal NumNF As String) As String

        Dim TalieItemDto As New TalieItemDTO

        TalieItemDto.Qtde = Val(Qtde)
        TalieItemDto.Remonte = Remonte
        TalieItemDto.IMO1 = IMO1
        TalieItemDto.IMO2 = IMO2
        TalieItemDto.IMO3 = IMO3
        TalieItemDto.IMO4 = IMO4
        TalieItemDto.UNO1 = UNO1
        TalieItemDto.UNO2 = UNO2
        TalieItemDto.UNO3 = UNO3
        TalieItemDto.UNO4 = UNO4
        TalieItemDto.CodigoTalie = Val(CodigoTalie)
        TalieItemDto.NumNF = NumNF
        TalieItemDto.CodigoRegCs = Val(CodigoRegCs)

        Dim Inconsistencia As String = String.Empty

        Try
            TalieItemDto.CodigoEmbalagem = CodigoEmbalagem.Split("-")(1)
        Catch ex As Exception
            Inconsistencia = "Informe a Embalagem"
        End Try

        Inconsistencia = ValidarCampos(TalieItemDto)

        If Inconsistencia <> String.Empty Then
            Return Inconsistencia
        End If

        Dim QtdD As Long = TalieItemDAO.ObterResumoQuantidadeDescarga(Val(CodigoRegCs), Val(CodigoItem))
        Dim QtdR As Long = TalieItemDAO.ObterResumoQuantidade(Val(CodigoRegCs))

        If Val(Qtde) + QtdD > QtdR Then
            Return "Quantidade informada não disponível. Verifique outras descargas deste item."
        End If

        Dim Al As Long = 0

        If Yard <> String.Empty Then

            Al = TalieItemDAO.ObterPosicaoPatio(Val(Patio), Yard.ToUpper)

            If Al = 0 Then
                Return "Posição inexistente neste patio."
            End If

        End If

        If Not IsNumeric(CLAA) Then CLAA = 0
        If Not IsNumeric(CLAC) Then CLAC = 0
        If Not IsNumeric(CLAL) Then CLAL = 0

        '  If Val(Peso) = 0 Then

        'Dim rsPeso As New DataTable
        'rsPeso = TalieItemDAO.ObterPesoQuantidade(Val(CodigoRegCs))
        '
        'If rsPeso IsNot Nothing Then
        'If rsPeso.Rows.Count > 0 Then
        'Peso = CalcularPeso(rsPeso.Rows(0)("PESO_BRUTO").ToString(), rsPeso.Rows(0)("QTDE").ToString(), Qtde)
        'End If
        'End If

        'End If

        Try

            If Val(CodigoItem) = 0 Then

                CodigoItem = TalieItemDAO.ObterProximoID()

                TalieItemDAO.InserirTalieItem(
                    Val(CodigoItem),
                    Val(CodigoTalie),
                    Val(CodigoRegCs),
                    Qtde,
                    CLAC,
                    CLAL,
                    CLAA,
                    Peso,
                    Remonte,
                    Fumigacao,
                    Fragil,
                    Madeira,
                    Yard.ToUpper,
                    Al,
                    Val(CodigoNF),
                    NumNF,
                    IMO1,
                    UNO1,
                    IMO2,
                    UNO2,
                    IMO3,
                    UNO3,
                    IMO4,
                    UNO4,
                    TalieItemDto.CodigoEmbalagem)

                TalieItemDAO.InserirTalieItemCol(
                    Val(CodigoItem),
                    Val(HttpContext.Current.Session("AUTONUMUSUARIO")),
                    HttpContext.Current.Session("BROWSER_NAME"),
                    HttpContext.Current.Session("BROWSER_VERSION"),
                    HttpContext.Current.Session("MOBILEDEVICEMODEL"),
                    HttpContext.Current.Session("MOBILEDEVICEMANUFACTURER"),
                    IIf(HttpContext.Current.Session("ISMOBILEDEVICE") = False, 0, 1), HttpContext.Current.Session("IP_CONNECTION"))

            Else

                TalieItemDAO.AlterarTalieItem(
                    Val(CodigoItem),
                    Val(CodigoTalie),
                    Val(CodigoRegCs),
                    Qtde,
                    CLAC,
                    CLAL,
                    CLAA,
                    Peso,
                    Remonte,
                    Fumigacao,
                    Fragil,
                    Madeira,
                    Yard.ToUpper,
                    Al,
                    Val(CodigoNF),
                    NumNF,
                    IMO1,
                    UNO1,
                    IMO2,
                    UNO2,
                    IMO3,
                    UNO3,
                    IMO4,
                    UNO4,
                    TalieItemDto.CodigoEmbalagem)

            End If

            TalieItemDto.Resumo = Resumo(CodigoRegCs)

        Catch ex As Exception
            Return String.Format("Falha ao salvar o item de NF - {0}", ex.Message)
        End Try

        Return CodigoItem

    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function ExcluirAsync(
                                       ByVal CodigoTalie As String,
                                       ByVal CodigoItem As String) As String

        If TalieDAO.TalieFechado(Val(CodigoTalie)) = 1 Then
            Return "Talie Fechado - Operação cancelada"
        End If

        If Val(CodigoItem) = 0 Then
            Return "Um item deve estar selecionado para exclusão"
        End If

        Try
            TalieItemDAO.ExcluirTalieItem(Val(CodigoItem))
        Catch ex As Exception
            Return "Erro. Tente novamente." & ex.Message()
        End Try

        Return String.Empty

    End Function

    Protected Sub BtVoltar_Click(sender As Object, e As EventArgs) Handles BtVoltar.Click

        If HttpContext.Current.Request.Cookies("ColTalieItens") IsNot Nothing Then
            HttpContext.Current.Request.Cookies("ColTalieItens").Expires = Now.AddDays(-1)
        End If

        If (Not Request.Cookies("ColTalieItens") Is Nothing) Then
            Dim myCookie As HttpCookie
            myCookie = New HttpCookie("ColTalieItens")
            myCookie.Expires = DateTime.Now.AddDays(-1D)
            Response.Cookies.Add(myCookie)
        End If

        Dim Controle As Control
        Dim Subcontrol As Control
        For Each Controle In Page.Controls
            For Each Subcontrol In Controle.Controls
                Subcontrol.Dispose()
            Next
            Controle.Dispose()
        Next

        Response.Redirect("TalieDescargaRegistro.aspx?" &
                          "usuario=" & Me.temp_registro_lblCodigoUsuario.Value &
                          "&patio=" & Me.temp_registro_lblCodigoPatio.Value &
                          "&temp_registro_txtTalie=" & Me.temp_registro_txtTalie.Value &
                          "&temp_registro_TxtInicio=" & Me.temp_registro_TxtInicio.Value &
                          "&temp_registro_TxtFim=" & Me.temp_registro_TxtFim.Value &
                          "&temp_registro_TxtRegistro=" & Me.temp_registro_TxtRegistro.Value &
                          "&temp_registro_TxtPlaca=" & Me.temp_registro_TxtPlaca.Value &
                          "&temp_registro_TxtReserva=" & Me.temp_registro_TxtReserva.Value &
                          "&temp_registro_TxtCliente=" & Me.temp_registro_TxtCliente.Value &
                          "&temp_registro_DC_Conferente=" & Me.temp_registro_DC_Conferente.Value &
                          "&temp_registro_DC_Equipe=" & Me.temp_registro_DC_Equipe.Value &
                          "&temp_registro_DC_Operacao=" & Me.temp_registro_DC_Operacao.Value &
                          "&temp_registro_lblCodigoBooking=" & Me.temp_registro_lblCodigoBooking.Value &
                          "&temp_registro_lblCodigoGate=" & Me.temp_registro_lblCodigoGate.Value &
                          "&temp_registro_lblCodigoRegistro=" & Me.temp_registro_lblCodigoRegistro.Value &
                          "&temp_registro_lblCodigoReserva=" & Me.temp_registro_lblCodigoReserva.Value &
                          "&temp_registro_lblCodigoUsuario=" & Me.temp_registro_lblCodigoUsuario.Value &
                          "&temp_registro_lblCodigoPatio=" & Me.temp_registro_lblCodigoPatio.Value)

    End Sub

    Protected Sub BtGravar_Click(sender As Object, e As EventArgs) Handles BtGravar.Click

    End Sub

    Protected Sub btnRetornarDados_Click(sender As Object, e As EventArgs) Handles btnRetornarDados.Click

    End Sub



    Protected Sub btMarcantes_Click(sender As Object, e As EventArgs) Handles btMarcantes.Click
        If Trim(lblCodigoItem.Value) = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Primeiro descarregue/selecione o item');</script>", False)
        Else

            If Me.TxtQtde.Text = "" Or Me.TxtQtde.Text = "0" Then 'Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Primeiro informe a quatidade a descarregar');</script>", False)
            Else




                Response.Redirect("../frmMarcanteRDX.aspx?" &
                            "CodigoTalie=" & Me.lblCodigoTalie.Value &
                            "&CodigoBooking=" & Me.lblCodigoBooking.Value &
                            "&CodigoPatio=" & Me.lblCodigoPatio.Value &
                            "&CodigoRegistro=" & Me.lblCodigoRegistro.Value &
                              "&usuario=" & Me.temp_registro_lblCodigoUsuario.Value &
                              "&patio=" & Me.temp_registro_lblCodigoPatio.Value &
                              "&temp_registro_txtTalie=" & Me.temp_registro_txtTalie.Value &
                              "&temp_registro_TxtInicio=" & Me.temp_registro_TxtInicio.Value &
                              "&temp_registro_TxtFim=" & Me.temp_registro_TxtFim.Value &
                              "&temp_registro_TxtRegistro=" & Me.temp_registro_TxtRegistro.Value &
                              "&temp_registro_TxtPlaca=" & Me.temp_registro_TxtPlaca.Value &
                              "&temp_registro_TxtReserva=" & Me.temp_registro_TxtReserva.Value &
                              "&temp_registro_TxtCliente=" & Me.temp_registro_TxtCliente.Value &
                              "&temp_registro_DC_Conferente=" & Me.temp_registro_DC_Conferente.Value &
                              "&temp_registro_DC_Equipe=" & Me.temp_registro_DC_Equipe.Value &
                              "&temp_registro_DC_Operacao=" & Me.temp_registro_DC_Operacao.Value &
                              "&temp_registro_lblCodigoBooking=" & Me.temp_registro_lblCodigoBooking.Value &
                              "&temp_registro_lblCodigoGate=" & Me.temp_registro_lblCodigoGate.Value &
                              "&temp_registro_lblCodigoRegistro=" & Me.temp_registro_lblCodigoRegistro.Value &
                              "&temp_registro_lblCodigoReserva=" & Me.temp_registro_lblCodigoReserva.Value &
                              "&temp_registro_lblCodigoUsuario=" & Me.temp_registro_lblCodigoUsuario.Value &
                              "&temp_registro_lblCodigoPatio=" & Me.temp_registro_lblCodigoPatio.Value &
                              "&temp_registro_AutonumRegCs=" & lblCodigoRegCS.Value &
                              "&temp_registro_QtdeDescarga=" & Val(Me.TxtQtde.Text) &
                              "&temp_registro_AutonumTI=" & Val(lblCodigoItem.Value))




            End If


        End If


    End Sub

    Protected Sub BtExcluir_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub TxtFumigacao_TextChanged(sender As Object, e As EventArgs) Handles TxtFumigacao.TextChanged

    End Sub

    Protected Sub ListaDescarga_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListaDescarga.SelectedIndexChanged

    End Sub

    Protected Sub TxtQtde_TextChanged(sender As Object, e As EventArgs) Handles TxtQtde.TextChanged



        ' TxtPeso.Text = CalcularPesoN()
    End Sub

    <WebMethod>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json)>
    Public Shared Function CalcularPesoN(ByVal CodigoRegistro As String, ByVal Quantidade As String, ByVal NF As String) As String

        Dim Resultado As Decimal = 0.000

        Dim PesoUni As Decimal
        PesoUni = 0

        Dim Sql As String
        Sql = "SELECT PESO_BRUTO/VOLUMES AS QTO FROM REDEX.TB_NOTAS_FISCAIS WHERE AUTONUM_REG=" & CodigoRegistro & " AND NUM_NF=" & NF & ""

        Dim tb1 As New ADODB.Recordset
        tb1.Open(Sql, BD.Conexao, 3, 3)

        If Not tb1.EOF Then
            PesoUni = tb1.Fields("QTO").Value
        End If

        tb1.Close()

        Try
            If IsNumeric(Quantidade) Then
                Resultado = String.Format("{0:N3}", (PesoUni * Val(Quantidade)))
            End If
        Catch
            Return "0"
        End Try

        Return Resultado.ToString().PadLeft(8, "0"c).Replace(",", ".")
    End Function

    Protected Sub BtBuscaNF_Click(sender As Object, e As EventArgs) Handles BtBuscaNF.Click

    End Sub

    Protected Sub TXTSALDO_TextChanged(sender As Object, e As EventArgs) Handles TXTSALDO.TextChanged

    End Sub

    Protected Sub TxtPeso_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class