Imports AjaxControlToolkit

Public Class DDC
    Inherits System.Web.UI.Page

    Dim OrdensOBJ As New Ordens
    Dim OrdensBLL As New Ordens

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("LOGADO") Is Nothing Or Session("USUARIO") Is Nothing Or Session("SENHA") Is Nothing Or Session("EMPRESA") Is Nothing Or Session("PATIO") Is Nothing Or Session("AUTONUMPATIO") Is Nothing Then
            Try
                Session("LOGADO") = Server.HtmlEncode(Request.Cookies("LOGADO").Value)
                Session("USUARIO") = Server.HtmlEncode(Request.Cookies("USUARIO").Value)
                Session("SENHA") = Server.HtmlEncode(Request.Cookies("SENHA").Value)
                Session("EMPRESA") = Server.HtmlEncode(Request.Cookies("EMPRESA").Value)
                Session("PATIO") = Server.HtmlEncode(Request.Cookies("PATIO").Value)
                Session("AUTONUMPATIO") = Server.HtmlEncode(Request.Cookies("AUTONUMPATIO").Value)
                Session("AUTONUMUSUARIO") = Server.HtmlEncode(Request.Cookies("AUTONUMUSUARIO").Value)
                Session("BROWSER_NAME") = Server.HtmlEncode(Request.Cookies("BROWSER_NAME").Value)
                Session("BROWSER_VERSION") = Server.HtmlEncode(Request.Cookies("BROWSER_VERSION").Value)
                Session("MobileDeviceModel") = Server.HtmlEncode(Request.Cookies("MobileDeviceModel").Value)
                Session("MobileDeviceManufacturer") = Server.HtmlEncode(Request.Cookies("MobileDeviceManufacturer").Value)
                Session("IsMobileDevice") = Server.HtmlEncode(Request.Cookies("IsMobileDevice").Value)
                Session("FLAG_OB_MARCANTE") = Server.HtmlEncode(Request.Cookies("FLAG_OB_MARCANTE").Value)
                Session("FLAG_FILMA_DESOVA") = Server.HtmlEncode(Request.Cookies("FLAG_FILMA_DESOVA").Value)
                Session("FLAG_REDEX_SEM_MARCANTE") = Server.HtmlEncode(Request.Cookies("FLAG_REDEX_SEM_MARCANTE").Value)
                Session("LARGURATELA") = Server.HtmlEncode(Request.Cookies("LARGURATELA").Value)

            Catch ex As Exception

                Response.Redirect("Index.aspx")
            End Try
        End If



        If Not Page.IsPostBack Then

            txtUsuario.Text = Session("USUARIO")

            txtTerminal.Text = Session("PATIO")

            Me.txtIDConteiner.Text = Session("ID_CONTEINER").ToString
            Me.txtPlaca.Text = Session("PLACA").ToString
            Me.txtAutonumCNTR.Text = Session("AUTONUMCNTR").ToString
            Me.txtOC.Text = Session("OC").ToString

            CarregarEmbalagens()

            If Session("AUTONUMCNTR") > 0 Then

                Me.txtAutonumCNTR.Text = Session("AUTONUMCNTR").ToString

                CarregarDadosCntr(Session("AUTONUMCNTR"), Session("FLAG_DDC"), Session("PLACA"), Session("OC").ToString)

                CarregarLotesREGConteiner(Session("AUTONUMCNTR"), Session("OC"))


                If Session("AUTONUMBLDDC") > 0 Then

                    Me.cbLotes.SelectedValue = Session("AUTONUMBL")

                    Me.cbEmbalagem.SelectedValue = Session("EMBALAGEM")
                    Me.TxtQtde.Text = Session("QTDE")
                    Me.txtPesoBruto.Text = Session("PESO")



                End If


            End If

        End If





    End Sub

    Private Sub CarregarLotesREGConteiner(ByVal Autonum_Cntr As Integer, OC As Long)

        Me.cbLotes.DataTextField = "DISPLAY"
        Me.cbLotes.DataValueField = "AUTONUM"

        Me.cbLotes.DataSource = Ordens.ConsultarLotesRegConteiner(Autonum_Cntr, 0, OC)
        Me.cbLotes.DataBind()

        Me.cbLotes.Items.Insert(0, "--Selecione um lote--")
        Me.cbLotes.SelectedIndex = 0



    End Sub


    Protected Sub btSair_Click(sender As Object, e As EventArgs) Handles btSair.Click

        Dim Controle As Control
        Dim Subcontrol As Control
        For Each Controle In Page.Controls
            For Each Subcontrol In Controle.Controls
                Subcontrol.Dispose()
            Next
            Controle.Dispose()
        Next

        Session("RET_AUTONUMCNTR") = Session("AUTONUMCNTR").ToString()
        Session("RET_AUTONUMVEICULODDC") = Session("AUTONUMVEICULODDC").ToString()

        Response.Redirect("DesovaDatas.aspx")

    End Sub

    Private Sub GridDesovas_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridDesovas.PageIndexChanging


    End Sub




    Private Sub form1_Load(sender As Object, e As EventArgs) Handles Me.Load



    End Sub



    Private Sub CarregarEmbalagens()

        Me.cbEmbalagem.DataTextField = "DISPLAY"
        Me.cbEmbalagem.DataValueField = "AUTONUM"

        Me.cbEmbalagem.DataSource = Ordens.CarregarCadEmbalagens(1)
        Me.cbEmbalagem.DataBind()

        Me.cbEmbalagem.Items.Insert(0, "--Selecione uma embalagem--")
        Me.cbEmbalagem.SelectedIndex = 0

    End Sub



    Public Sub CarregarDadosCntr(ByVal Autonum_Cntr As Integer, Flag_DDC As Integer, Placa As String, Oc As Long)

        Dim OrdensOBJ As Ordens = Ordens.PopulaDadosCntr(Autonum_Cntr, Flag_DDC, Placa, Oc)

        If OrdensOBJ IsNot Nothing Then





        Else
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro não mais disponível');</script>", False)
        End If

    End Sub


    Private Sub Carrega_RegistroCS(ByVal Lote As Integer, ByVal Autonum_Cntr As Long, ByVal OC As Long)
        Me.GridDesovas.DataSource = Ordens.MostrarRegistroCS(Lote, Autonum_Cntr, 1, OC)
        Me.GridDesovas.DataBind()
    End Sub



    Private Sub Carrega_Item_Registrado(AUTONUMRCS As Long)

        Dim OrdensOBJ As Ordens = Ordens.PopulaItemRegistrado(AUTONUMRCS)

        If OrdensOBJ IsNot Nothing Then

            Me.TxtQtde.Text = OrdensOBJ.Qtde.ToString
            Me.TxtQtde.ToolTip = OrdensOBJ.Qtde.ToString

            Me.txtMarca.Text = OrdensOBJ.Marca.ToString
            Me.txtMercadoria.Text = OrdensOBJ.Mercadoria.ToString


            If OrdensOBJ.Embalagem > 0 Then
                Me.cbEmbalagem.SelectedValue = OrdensOBJ.Embalagem

            Else
                Me.cbEmbalagem.SelectedIndex = 0

            End If


            Me.txtPesoBruto.Text = OrdensOBJ.PesoBruto.ToString
            Me.TXTAUTONUMRCS.Text = OrdensOBJ.AutonumRCS.ToString

        Else
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro não mais disponível');</script>", False)
        End If

    End Sub

    Protected Sub btIni1_Click(sender As Object, e As EventArgs) Handles btSalvar.Click




        If Validar() Then


            'Dim Tbe As New ADODB.Recordset
            'Dim Sql As String
            'Sql = "select COUNT(*)"
            'Sql = Sql & " from"
            'Sql = Sql & " operador.tb_gate_new gn"
            'Sql = Sql & " inner join operador.tb_amr_gate ag on gn.autonum=ag.gate"
            'Sql = Sql & " inner join tb_ordem_carregamento oc on ag.id_oc=oc.autonum"
            'Sql = Sql & " inner join sgipa.tb_registro_saida_cs a on oc.autonum = a.ordem_carreg"
            'Sql = Sql & " inner join sgipa.tb_ordem_carregamento b on a.ordem_carreg=b.autonum"
            'Sql = Sql & " inner join sgipa.tb_carga_solta cs on A.cs=cs.autonum"
            'Sql = Sql & " inner join sgipa.tb_bl bl on cs.bl=bl.autonum"
            'Sql = Sql & " where"
            'Sql = Sql & " gn.flag_gate_out=0 and b.flag_saida=0 "
            'Sql = Sql & " and gn.placa='" & Me.txtPlaca.Text & "'"
            'Tbe.Open(Sql, BD.Conexao, 3, 3)
            'If Tbe.Fields(0).Value > 1 Then
            '    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Descarga possui mais de 1 item. Obrigatorio pesagem no armazem');</script>", False)
            'End If
            'Tbe.Close()


            ConfirmaDesovaItem()

            Carrega_RegistroCS(Me.cbLotes.SelectedValue, Val(Me.txtAutonumCNTR.Text), Val(Me.txtOC.Text))


            Me.TXTAUTONUMRCS.Text = ""
            Me.cbEmbalagem.SelectedIndex = -1
            Me.cbEmbalagem.Enabled = False
            Me.txtMarca.Text = ""
            Me.txtMarca.Enabled = False
            Me.txtMercadoria.Text = ""
            Me.txtMercadoria.Enabled = False
            Me.txtPesoBruto.Text = ""
            Me.txtPesoBruto.Enabled = False
            Me.TxtQtde.Text = ""
            Me.TxtQtde.Enabled = False


        End If

    End Sub

    Private Sub ConfirmaDesovaItem()

        Dim SQL As String

        Dim QR As Integer = 0

        Session("QTD_DIGITADA") = Me.TxtQtde.Text

        'Try
        If Val(Me.TXTAUTONUMRCS.Text) > 0 Then

            SQL = "SELECT NVL(QUANTIDADE,0) AS QTO FROM SGIPA.TB_REGISTRO_SAIDA_CS WHERE AUTONUM=" & Val(Me.TXTAUTONUMRCS.Text)
            QR = OracleDAO.ExecuteScalar(SQL)

            If Val(Me.TxtQtde.Text) > QR Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade nao pode ser maior que a registrada');</script>", False)
                Exit Sub
            End If


            If Val(Me.TxtQtde.Text) < QR Then
                Session("QTD_ANTIGA") = QR
                Me.modal.Show()
                Exit Sub
            Else
                ConfirmarGravacaoItem(True)
            End If
            '            ConfirmarGravacaoItem(True)
        End If



        'Catch ex As Exception
        '   ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Erro. Tente Novamente.');</script>", False)
        'End Try



    End Sub

    Public Sub ConfirmarGravacaoItem(ByVal Resposta As Boolean)

        Dim SQL As String

        Session("AUTONUMGATE") = 0

        If Me.txtPlaca.Text = "" Then
            'SAI - SEM VEICULO
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Placa veículo não informada!');</script>", False)
            Exit Sub
        Else
            SQL = "SELECT autonum from OPERADOR.tb_gate_new where placa='" & Me.txtPlaca.Text & "' and flag_gate_in=1 and flag_gate_out=0"
            Dim Rs As New ADODB.Recordset
            Rs.Open(SQL, BD.Conexao, 3, 3)
            If Rs.RecordCount = 0 Then
                'SAI, VEICULO SEM ENTRADA
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Veículo sem entrada!');</script>", False)
                Exit Sub
            Else
                Session("AUTONUMGATE") = Rs.Fields("AUTONUM").Value
            End If
        End If

        Dim OrdensOBJ As New Ordens

        OrdensOBJ.PesoBruto = Replace(Replace(txtPesoBruto.Text, ".", ""), ",", ".")
        OrdensOBJ.Qtde = Me.TxtQtde.Text

        If Session("QTD_ANTIGA") IsNot Nothing And Session("QTD_DIGITADA") IsNot Nothing Then
            If Val(Session("QTD_ANTIGA").ToString()) <> Val(Session("QTD_DIGITADA").ToString()) Then
                OrdensOBJ.PesoBruto = (Val(txtPesoBruto.Text) / Val(Session("QTD_ANTIGA").ToString())) * Val(Session("QTD_DIGITADA").ToString())
                OrdensOBJ.Qtde = Val(Session("QTD_DIGITADA").ToString())
            End If
        End If

        OrdensOBJ.Lote = Me.cbLotes.SelectedValue
        OrdensOBJ.Autonum_Cntr = Val(Me.txtAutonumCNTR.Text)
        OrdensOBJ.Item = 1
        OrdensOBJ.Embalagem = Me.cbEmbalagem.SelectedValue
        OrdensOBJ.Mercadoria = Me.txtMercadoria.Text.ToUpper().Trim
        OrdensOBJ.Marca = Me.txtMarca.Text.ToUpper().Trim
        OrdensOBJ.QtdeM = 0
        OrdensOBJ.Genero = 0
        OrdensOBJ.Volume = 0
        OrdensOBJ.Imo = ""
        OrdensOBJ.ehAvaria = 0
        OrdensOBJ.ehAcrescimo = 0
        OrdensOBJ.ehIdfa = 0
        OrdensOBJ.ehDivEmbalagem = 0
        OrdensOBJ.AutonumRCS = Val(Me.TXTAUTONUMRCS.Text)
        OrdensOBJ.Autonum_CS = Val(Me.TXTAUTONUMCARGA.Text)

        OrdensOBJ.Resposta = Resposta


        If Ordens.InserirDesovaDDC(OrdensOBJ, Session("AUTONUMUSUARIO"), Val(Me.txtOC.Text), Session("AUTONUMGATE"), Me.txtPlaca.Text) Then

            Dim Obs As String = ""

            SQL = "SELECT AUTONUMCS FROM SGIPA.TB_CARGA_SOLTA_DESOVA_COL WHERE AUTONUMCS=" & OrdensOBJ.Autonum_CS
            Dim Tbe As New ADODB.Recordset
            Tbe.Open(SQL, BD.Conexao, 3, 3)

            If Tbe.EOF Then

                SQL = "INSERT INTO SGIPA.TB_CARGA_SOLTA_DESOVA_COL (AUTONUMCS,USUARIO,DT,BROWSER_NAME,BROWSER_VERSION,MOBILEDEVICEMODEL,MOBILEDEVICEMANUFACTURER,FLAG_MOBILE) VALUES ("
                SQL = SQL & OrdensOBJ.Autonum_CS & ","
                SQL = SQL & Session("AUTONUMUSUARIO") & ","
                SQL = SQL & "SYSDATE,"
                SQL = SQL & "'" & Session("BROWSER_NAME") & "',"
                SQL = SQL & "'" & Session("BROWSER_VERSION") & "',"
                SQL = SQL & "'" & Session("MOBILEDEVICEMODEL") & "',"
                SQL = SQL & "'" & Session("MOBILEDEVICEMANUFACTURER") & "',"
                SQL = SQL & IIf(Session("ISMOBILEDEVICE") = False, 0, 1)
                SQL = SQL & ") "
                BD.Conexao.Execute(SQL)

            End If

            SQL = "UPDATE SGIPA.TB_AVARIAS_CS SET AUTONUMCS=" & OrdensOBJ.Autonum_CS
            SQL = SQL & " WHERE NVL(AUTONUMCS,0)=0 And BL=" & Me.cbLotes.SelectedValue

            BD.Conexao.Execute(SQL)


            SQL = "UPDATE SGIPA.TB_CARGA_SOLTA SET FLAG_AVARIADO=1 WHERE "
            SQL = SQL & " AUTONUM In (Select AUTONUMCS FROM SGIPA.TB_AVARIAS_CS WHERE AUTONUMCS=" & OrdensOBJ.Autonum_CS & ")"
            BD.Conexao.Execute(SQL)

            If Resposta Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro Inserido!');</script>", False)
            End If

        End If

        Carrega_RegistroCS(Me.cbLotes.SelectedValue, Val(Me.txtAutonumCNTR.Text), Val(Me.txtOC.Text))
        PopularCampos(0)

    End Sub



    Private Function Validar()




        If Me.cbLotes.SelectedIndex < 1 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione o lote');</script>", False)
            Return False
        End If

        If Me.TxtQtde.Text = String.Empty Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe a quantidade');</script>", False)
            Return False
        End If

        If Val(Me.TxtQtde.Text) = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade inválida');</script>", False)
            Return False
        End If

        If Me.cbEmbalagem.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe a embalagem');</script>", False)
            Return False
        End If


        If Me.txtPesoBruto.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe o peso');</script>", False)
            Return False
        End If

        If Val(Me.txtPesoBruto.Text) = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Peso inválido');</script>", False)
            Return False
        End If













        Return True



    End Function

    Protected Sub btLogOff_Click(sender As Object, e As EventArgs) Handles btLogOff.Click

        If Me.cbLotes.SelectedIndex < 1 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('BL nao selecionado');</script>", False)
            Exit Sub
        End If

        If Me.TXTAUTONUMCARGA.Text = "" Or Me.TXTAUTONUMCARGA.Text = "0" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione primeiro o item');</script>", False)
            Exit Sub
        End If


        Session("AUTONUMBLDDC") = Me.cbLotes.SelectedValue
        Session("AUTONUMBL") = Me.cbLotes.SelectedValue
        Session("ITEM") = 1
        Session("AUTONUMCNTR") = Val(Me.txtAutonumCNTR.Text)
        If Me.cbEmbalagem.SelectedIndex > 0 Then
            Session("EMBALAGEM") = Me.cbEmbalagem.SelectedValue
        Else
            Session("EMBALAGEM") = 0
        End If
        Session("QTDE") = Me.TxtQtde.Text
        Session("PESO") = Me.txtPesoBruto.Text


        Me.cbLotes.SelectedIndex = -1

        Response.Redirect("Avarias.aspx")

    End Sub



    Private Function ValidarAvaria() As Boolean

        If Me.TXTAUTONUMRCS.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Item nao selecionado');</script>", False)
            Return False
        End If

        Return True

    End Function

    Protected Sub txtOC_TextChanged(sender As Object, e As EventArgs) Handles txtOC.TextChanged

    End Sub
    Public Sub PopularCampos(ByVal NovaQuantidade As Integer)

        Dim ID As Long
        ID = GridDesovas.DataKeys(0).Value

        Dim OrdemOBJ As New Ordens
        OrdemOBJ = Ordens.PopulaItemRegistrado(ID)

        If Not IsNothing(OrdemOBJ) Then

            Me.cbEmbalagem.Enabled = True
            Me.txtMarca.Enabled = True
            Me.txtMercadoria.Enabled = True
            Me.txtPesoBruto.Enabled = True
            Me.TxtQtde.Enabled = True

            Me.cbEmbalagem.SelectedValue = OrdemOBJ.Embalagem
            Me.txtMarca.Text = OrdemOBJ.Marca
            Me.txtMercadoria.Text = OrdemOBJ.Mercadoria
            Me.txtPesoBruto.Text = OrdemOBJ.PesoBruto
            If NovaQuantidade > 0 Then
                Me.TxtQtde.Text = NovaQuantidade
            Else
                Me.TxtQtde.Text = OrdemOBJ.Qtde
            End If
            Session("QTD_ANTIGA") = Me.TxtQtde.Text
            Me.TXTAUTONUMRCS.Text = ID
            Me.TXTAUTONUMCARGA.Text = OrdemOBJ.Autonum_CS
        End If

    End Sub
    Protected Sub GridDesovas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridDesovas.SelectedIndexChanged
        PopularCampos(0)
    End Sub

    Protected Sub txtPlaca_TextChanged(sender As Object, e As EventArgs) Handles txtPlaca.TextChanged

    End Sub

    Protected Sub cbLotes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLotes.SelectedIndexChanged
        If Me.cbLotes.SelectedIndex > 0 Then
            Carrega_RegistroCS(Me.cbLotes.SelectedValue, Val(Me.txtAutonumCNTR.Text), Val(Me.txtOC.Text))
        End If
    End Sub

    Protected Sub btConfirmar_Click(sender As Object, e As EventArgs) Handles btConfirmar.Click
        PopularCampos(Val(Session("QTD_ANTIGA").ToString()))
        ConfirmarGravacaoItem(True)
    End Sub

    Protected Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        PopularCampos(Val(Session("QTD_ANTIGA").ToString()))
        ConfirmarGravacaoItem(False)
    End Sub

    Protected Sub txtMercadoria_TextChanged(sender As Object, e As EventArgs) Handles txtMercadoria.TextChanged

    End Sub

    Protected Sub cbEmbalagem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmbalagem.SelectedIndexChanged

    End Sub

    Private Sub btConfirmar_Command(sender As Object, e As CommandEventArgs) Handles btConfirmar.Command

    End Sub

    Private Sub modal_Disposed(sender As Object, e As EventArgs) Handles modal.Disposed

    End Sub

    Private Sub modal_Load(sender As Object, e As EventArgs) Handles modal.Load

    End Sub

    Private Sub modal_ResolveControlID(sender As Object, e As ResolveControlEventArgs) Handles modal.ResolveControlID

    End Sub

    Private Sub modal_Unload(sender As Object, e As EventArgs) Handles modal.Unload

    End Sub

    Private Sub modal_DataBinding(sender As Object, e As EventArgs) Handles modal.DataBinding

    End Sub
End Class
