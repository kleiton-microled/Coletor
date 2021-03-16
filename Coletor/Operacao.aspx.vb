Imports Oracle.ManagedDataAccess.Client

Public Class WebForm1
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
                Session("IP_CONNECTION") = Server.HtmlEncode(Request.Cookies("IP_CONNECTION").Value)
            Catch ex As Exception
                Response.Redirect("Index.aspx")
            End Try
        End If


        '   If Session("USUARIO") = "MICROLED" Then
        Me.btSair0.Visible = True
        Me.TxtQtdeM0.Visible = True
        '  Else
        ' Me.btSair0.Visible = False
        'Me.TxtQtdeM0.Visible = False
        '' End If

    End Sub

    Public Sub GravaLog(ByVal msg As String)

        'Dim str As System.IO.StreamWriter

        'If Not System.IO.Directory.Exists(Server.MapPath(".") & "\logs") Then
        '    System.IO.Directory.CreateDirectory(Server.MapPath(".") & "\logs")
        'End If

        'Try
        '    str = New System.IO.StreamWriter(Server.MapPath(".") & "\logs\log.txt")
        '    str.WriteLine(Now.ToString() & " - " & msg)
        '    str.Close()
        'Catch ex As Exception
        '    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('O Sistema não conseguiu criar o log de erros. Verifique se a pasta da aplicação contém o diretório logs ou se possui permissão de escrita.');</script>", False)
        'End Try

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

        Response.Redirect("Menu.aspx")
    End Sub

    Private Sub GridDesovas_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridDesovas.PageIndexChanging
        GridDesovas.PageIndex = e.NewPageIndex
        Carrega_Itens_Desovados(cbLotes.SelectedValue, cbConteiner.SelectedValue)
    End Sub

    Private Sub GridDesovas_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridDesovas.RowCommand

        If e.CommandName <> "Sort" And e.CommandName <> "Page" Then

            Dim Index As Integer = e.CommandArgument
            Dim Id As String

            Id = GridDesovas.DataKeys((CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)).RowIndex)("AUTONUM_CS").ToString()

            If Not Id = String.Empty Or Not Id = 0 Then

                Select Case e.CommandName

                    Case "DEL"

                        OrdensOBJ.Autonum_CS = Id


                        If Me.txtDtFim.Text <> "__/__ __:__" Then
                            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Já foi informado o fim da desova!');</script>", False)
                            Return
                        End If


                        If Me.cbLotes.SelectedIndex > 0 Then

                            OrdensOBJ.Lote = cbLotes.SelectedValue

                            If OrdensBLL.ValidarExclusaoDesova(OrdensOBJ) Then
                                If OrdensBLL.ExcluirDesova(OrdensOBJ, Me.cbConteiner.SelectedItem.Text) Then
                                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Desova cancelada com sucesso!');</script>", False)
                                    If Val(cbLotes.SelectedValue) >= 0 And Val(Me.cbConteiner.SelectedValue) >= 0 Then
                                        Carrega_Itens_Desovados(cbLotes.SelectedValue, cbConteiner.SelectedValue)
                                    End If
                                    If Val(Me.cbConteiner.SelectedValue) >= 0 Then
                                        CarregarLotesConteiner(Me.cbConteiner.SelectedValue)
                                    End If
                                Else
                                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Falha durante o cancelamento.');</script>", False)
                                End If
                            Else
                                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Operação não permitida');</script>", False)
                            End If
                        Else
                            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione o lote');</script>", False)
                        End If

                End Select

            End If

        End If

    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        txtUsuario.Text = Session("USUARIO")
        txtTerminal.Text = Session("PATIO")


        If Not Page.IsPostBack Then

            CarregarConteineres()
            cbConteiner.SelectedIndex = -1
            CarregarEmbalagens()

            If Session("AUTONUMCNTR") > 0 Then
                Me.cbConteiner.SelectedValue = Session("AUTONUMCNTR")
                CarregarDadosCntr(Session("AUTONUMCNTR"), Session("FLAG_DDC"))
                CarregarLotesConteiner(Session("AUTONUMCNTR"))
                Me.cbLotes.SelectedValue = Session("AUTONUMBL")

                Carrega_DadosLote()


                Me.cbEmbalagem.SelectedValue = Session("EMBALAGEM")
                Me.TxtQtde.Text = Session("QTDE")
                Me.txtPesoBruto.Text = Session("PESO")
                Me.txtIMO.Text = Session("IMO")
                Me.txtONU.Text = Session("ONU")
                Me.ckDespachante.Checked = Session("DESPACHANTE")
                Me.ckAcrescimo.Checked = Session("ACRESCIMO")
                Me.ckIDFA.Checked = Session("FALTA")

                'If Session("QTEMARCANTES") > 0 Then
                '    For I = 1 To Session("QTEMARCANTES")
                '        Me.lstMarcantes.Items.Add(Session("MARCANTE" & I))
                '    Next I
                'End If


            End If

        End If


    End Sub

    Private Sub CarregarConteineres()

        Me.cbConteiner.DataTextField = "DISPLAY"
        Me.cbConteiner.DataValueField = "AUTONUM"

        Me.cbConteiner.DataSource = Ordens.ConsultarConteineres(Session("AUTONUMPATIO"))
        Me.cbConteiner.DataBind()

        Me.cbConteiner.Items.Insert(0, "--Selecione um cntr--")
        Me.cbConteiner.SelectedIndex = 0

    End Sub

    Private Sub CarregarEmbalagens()

        Me.cbEmbalagem.DataTextField = "DISPLAY"
        Me.cbEmbalagem.DataValueField = "AUTONUM"

        Me.cbEmbalagem.DataSource = Ordens.CarregarCadEmbalagens(0)
        Me.cbEmbalagem.DataBind()

        Me.cbEmbalagem.Items.Insert(0, "--Selecione uma embalagem--")
        Me.cbEmbalagem.SelectedIndex = 0

        Me.cbEmbalagemNovoItem.DataTextField = "DISPLAY"
        Me.cbEmbalagemNovoItem.DataValueField = "AUTONUM"
        Me.cbEmbalagemNovoItem.DataSource = Ordens.CarregarCadEmbalagens(0)
        Me.cbEmbalagemNovoItem.DataBind()
        Me.cbEmbalagemNovoItem.Items.Insert(0, "--Selecione uma embalagem--")
        Me.cbEmbalagemNovoItem.SelectedIndex = 0

    End Sub


    Protected Sub cbConteiner_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConteiner.SelectedIndexChanged

        If Me.cbConteiner.SelectedIndex > 0 Then
            CarregarDadosCntr(Me.cbConteiner.SelectedValue, Session("FLAG_DDC"))
            Me.txtEtiquetas.Text = ""
        End If

    End Sub

    Private Sub CarregarLotesConteiner(ByVal Autonum_Cntr As Integer)

        Me.cbLotes.DataTextField = "DISPLAY"
        Me.cbLotes.DataValueField = "AUTONUM"

        Me.cbLotes.DataSource = Ordens.ConsultarLotesConteiner(Autonum_Cntr, 0)
        Me.cbLotes.DataBind()

        Me.cbLotes.Items.Insert(0, "--Selecione um lote--")
        Me.cbLotes.SelectedIndex = 0

        Me.txt1.Text = "0"
        Me.txt2.Text = "0"

    End Sub

    Public Sub CarregarDadosCntr(ByVal Autonum_Cntr As Integer, Flag_DDC As Integer)

        Dim OrdensOBJ As Ordens = Ordens.PopulaDadosCntr(Autonum_Cntr, Flag_DDC, "", 0)

        If OrdensOBJ IsNot Nothing Then

            Me.txtDtFim.Text = OrdensOBJ.DtFim.ToString
            Me.txtDtInicio.Text = OrdensOBJ.DtInicio.ToString
            Me.txtEtiquetas.Text = OrdensOBJ.Obs_Desova_Col.ToString

            'Carregando os lotes
            CarregarLotesConteiner(Autonum_Cntr)

        Else
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro não mais disponível');</script>", False)
        End If

    End Sub

    Protected Sub cbLotes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLotes.SelectedIndexChanged

        If cbLotes.SelectedIndex > 0 Then

            Carrega_DadosLote()

        End If

    End Sub

    Private Sub Carrega_DadosLote()

        Me.txtEtiquetas.Text = String.Empty
        Me.ckIDFA.Checked = False
        Me.ckAvaria.Checked = False
        Me.ckAcrescimo.Checked = False
        Me.txtAnvisa.Text = ""
        Me.ckAnvisa.Checked = False
        Me.txtTempAnvisa.Text = ""
        Me.txtTempAnvisaMax.Text = ""


        If Me.cbConteiner.SelectedIndex <> 0 Then

            Carrega_Itens_Desovados(cbLotes.SelectedValue, cbConteiner.SelectedValue)
            Carrega_Itens_Manifestados(cbLotes.SelectedValue, cbConteiner.SelectedValue)

            Dim OrdemObj As New Ordens
            OrdemObj = OrdensOBJ.RetornarDadosTela(Me.cbLotes.SelectedValue, Me.cbConteiner.SelectedValue)

            If OrdemObj IsNot Nothing Then
                Me.txtEtiquetas.Text = OrdemObj.Obs_Desova_Col.Replace("<br/>", vbCrLf)
            Else
                Me.txtEtiquetas.Text = String.Empty
                Me.txtEtiquetas.Text = Nothing
            End If

            Carrega_Lote_Manif_Desovados(cbLotes.SelectedValue)

            Mostra_Marcante_Temp()

        End If


        If Me.cbItem.Items.Count > 1 Then
            Me.cbItem.SelectedIndex = 1
            Carrega_Item_Manifestado(Me.cbLotes.SelectedValue, Me.cbConteiner.SelectedValue, Me.cbItem.SelectedValue)

        End If
    End Sub


    Private Sub Carrega_Itens_Desovados(ByVal Lote As Integer, ByVal Autonum_Cntr As Integer)
        Me.GridDesovas.DataSource = Ordens.MostrarDesovas(Lote, Autonum_Cntr, 0)
        Me.GridDesovas.DataBind()
    End Sub

    Private Sub Carrega_Lote_Manif_Desovados(ByVal Lote As Integer)
        Dim sql As String
        sql = "SELECT LOTES_MANIFESTADOS, LOTES_DESOVADOS FROM SGIPA.VW_LOTE_MANIF_DESOVADOS WHERE LOTE=" & Lote
        Dim Rst As New ADODB.Recordset
        Rst.Open(sql, BD.Conexao, 3, 3)
        Me.txt2.Text = Rst.Fields("LOTES_MANIFESTADOS").Value.ToString
        Me.txt1.Text = Rst.Fields("LOTES_DESOVADOS").Value.ToString

    End Sub




    Private Sub Carrega_Itens_Manifestados(ByVal Lote As Integer, ByVal Autonum_Cntr As Integer)

        Me.cbItem.DataTextField = "DISPLAY"
        Me.cbItem.DataValueField = "AUTONUM"

        Me.cbItem.DataSource = Ordens.ConsultarItensManifestados(Lote, Autonum_Cntr)
        Me.cbItem.DataBind()

        Me.cbItem.Items.Insert(0, "--Selecione um item--")
        Me.cbItem.SelectedIndex = 0

    End Sub

    Protected Sub cbItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbItem.SelectedIndexChanged

        If Me.cbItem.SelectedIndex > 0 Then
            Carrega_Item_Manifestado(Me.cbLotes.SelectedValue, Me.cbConteiner.SelectedValue, Me.cbItem.SelectedValue)

        End If

    End Sub

    Private Sub Carrega_Item_Manifestado(ByVal Lote As Integer, Autonum_Cntr As Integer, Item As Integer)

        Dim OrdensOBJ As Ordens = Ordens.PopulaItemManifestado(Lote, Autonum_Cntr, Item, 0)

        If OrdensOBJ IsNot Nothing Then

            Me.TxtQtde.Text = OrdensOBJ.Qtde.ToString
            Me.TxtQtde.ToolTip = OrdensOBJ.Qtde.ToString
            Me.txtQM.Text = OrdensOBJ.QtdeM.ToString
            Me.txtVolume.Text = OrdensOBJ.Volume.ToString
            Me.txtIMO.Text = OrdensOBJ.Imo.ToString
            Me.TxtIMOCAP.Text = OrdensOBJ.Imo.ToString
            Me.txtImportador.Text = OrdensOBJ.Importador.ToString
            Me.txtAnvisa.Text = OrdensOBJ.ANVISA.ToString
            Me.txtMarca.Text = OrdensOBJ.Marca.ToString
            Me.TxtMercadoria.Text = OrdensOBJ.Mercadoria.ToString
            Me.txtONU.Text = OrdensOBJ.Onu.ToString

            'Me.ckMadeira.Checked = IIf(OrdensOBJ.ehMadeira = 1, True, False)
            Me.ckAvaria.Checked = IIf(OrdensOBJ.ehAvaria = 1, True, False)
            Me.ckHubPort.Checked = IIf(OrdensOBJ.ehHubPort = 1, True, False)
            Me.ckDespachante.Checked = IIf(OrdensOBJ.ehDespachante = 1, True, False)
            Me.ckAnvisa.Checked = IIf(OrdensOBJ.FlagAnvisa = "1", True, False)
            If OrdensOBJ.FlagAnvisa = "1" Then
                Me.txtTempAnvisa.Enabled = True
                Me.txtTempAnvisa.BackColor = Drawing.Color.White
                Me.txtTempAnvisaMax.Enabled = True
                Me.txtTempAnvisaMax.BackColor = Drawing.Color.White

            Else
                Me.txtTempAnvisa.Enabled = False
                Me.txtTempAnvisa.BackColor = Drawing.Color.Silver
                Me.txtTempAnvisaMax.Enabled = False
                Me.txtTempAnvisaMax.BackColor = Drawing.Color.Silver
            End If


            If OrdensOBJ.Embalagem > 0 Then
                Me.cbEmbalagem.SelectedValue = OrdensOBJ.Embalagem
                Me.TxtEMB.Text = OrdensOBJ.Embalagem
            Else
                Me.cbEmbalagem.SelectedIndex = 0
                Me.TxtEMB.Text = "0"
            End If

            Me.txtPesoBruto.Text = OrdensOBJ.PesoBruto.ToString

            Me.lstMarcantes.ClearSelection()
            txtMarcante.Focus()

        Else
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro não mais disponível');</script>", False)
        End If

    End Sub

    Protected Sub btIni1_Click(sender As Object, e As EventArgs) Handles btSalvar.Click


        If Me.cbConteiner.SelectedValue Is Nothing Or Me.cbConteiner.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione o Contêiner.');</script>", False)
            Exit Sub
        End If

        'Dim sql As String
        'sql = "UPDATE SGIPA.TB_CNTR_BL SET OBS_DESOVA_COL='Lote: " & Me.cbLotes.Text & " <br/> " & Left$(Me.txtEtiquetas.Text.Trim, 150) & "'"
        'sql = sql & " WHERE AUTONUM = " & Me.cbConteiner.SelectedValue
        'BD.Conexao.Execute(sql)

        If Validar() Then

            If txtIMO.Text <> Me.TxtIMOCAP.Text Then

                pnConfirma.Visible = True
                ModalPopupExtender1.Show()
            Else

                ConfirmaDesovaItem()
                Dim IdAnt As Integer
                IdAnt = cbLotes.SelectedValue
                CarregarLotesConteiner(Me.cbConteiner.SelectedValue)
                cbLotes.SelectedValue = IdAnt
                If Me.cbItem.SelectedIndex > 0 Then
                    Carrega_Item_Manifestado(Me.cbLotes.SelectedValue, Me.cbConteiner.SelectedValue, Me.cbItem.SelectedValue)
                End If
            End If

            Carrega_DadosLote()

        End If


    End Sub

    Private Sub ConfirmaDesovaItem()

        Dim OrdensOBJ As New Ordens

        OrdensOBJ.Lote = Me.cbLotes.SelectedValue
        OrdensOBJ.Autonum_Cntr = Me.cbConteiner.SelectedValue
        OrdensOBJ.Item = Me.cbItem.SelectedValue
        OrdensOBJ.Embalagem = Me.cbEmbalagem.SelectedValue
        OrdensOBJ.Qtde = Me.TxtQtde.Text
        OrdensOBJ.Mercadoria = Me.TxtMercadoria.Text.ToUpper().Trim
        OrdensOBJ.Marca = Me.txtMarca.Text.ToUpper().Trim
        OrdensOBJ.QtdeM = Me.txtQM.Text
        OrdensOBJ.Genero = 0
        OrdensOBJ.PesoBruto = Replace(Replace(txtPesoBruto.Text, ".", ""), ",", ".")
        If Me.txtVolume.Text <> "" Then
            OrdensOBJ.Volume = Replace(Replace(txtVolume.Text, ".", ""), ",", ".")
        Else
            OrdensOBJ.Volume = 0
        End If
        OrdensOBJ.Imo = Me.txtIMO.Text
        OrdensOBJ.ehAvaria = IIf(ckAvaria.Checked = True, 1, 0)
        OrdensOBJ.ehAcrescimo = IIf(ckAcrescimo.Checked = True, 1, 0)
        OrdensOBJ.ehIdfa = IIf(ckIDFA.Checked = True, 1, 0)
        'OrdensOBJ.ehMadeira = IIf(ckMadeira.Checked = True, 1, 0)

        OrdensOBJ.ehDespachante = IIf(ckDespachante.Checked = True, 1, 0)
        If Val(Me.TxtEMB.Text) <> cbEmbalagem.SelectedValue Then
            OrdensOBJ.ehDivEmbalagem = 1
        Else
            OrdensOBJ.ehDivEmbalagem = 0
        End If

        OrdensOBJ.Obs_Desova_Col = Me.txtEtiquetas.Text
        OrdensOBJ.Onu = Me.txtONU.Text
        OrdensOBJ.Temp_Anvisa = Me.txtTempAnvisa.Text
        OrdensOBJ.Temp_AnvisaMax = Me.txtTempAnvisaMax.Text

        Try

            BD.Conexao.BeginTrans()

            If Ordens.InserirDesova(OrdensOBJ) Then

                Dim Sql As String = ""
                Dim Obs As String = ""

                'Associando os marcantes
                For i = 0 To Me.lstMarcantes.Items.Count - 1
                    If Microsoft.VisualBasic.Right(lstMarcantes.Items(i).ToString, 1) <> "X" Then
                        Sql = "UPDATE SGIPA.TB_MARCANTES SET AUTONUM_CARGA=" & OrdensOBJ.Autonum_CS
                        Sql = Sql & ",VOLUMES=" & Val(Microsoft.VisualBasic.Mid(Me.lstMarcantes.Items(i).ToString, 14))
                        Sql = Sql & ",DT_ASSOCIACAO=SYSDATE "
                        Sql = Sql & " WHERE AUTONUM=" & Val(Microsoft.VisualBasic.Mid(Me.lstMarcantes.Items(i).ToString, 1, 12))
                        BD.Conexao.Execute(Sql)
                    End If
                Next i

                Dim ObsCs As String
                ObsCs = txtEtiquetas.Text
                Sql = "UPDATE SGIPA.TB_Carga_SOLTA SET OBS_DESOVA_COL='" & Mid(ObsCs, 1, 500) & "'"
                Sql = Sql & " WHERE AUTONUM = " & OrdensOBJ.Autonum_CS
                BD.Conexao.Execute(Sql)

                Atualiza_ObsDesova()

                Sql = "SELECT AUTONUMCS FROM SGIPA.TB_CARGA_SOLTA_DESOVA_COL WHERE AUTONUMCS=" & OrdensOBJ.Autonum_CS
                Dim Tbe As New ADODB.Recordset
                Tbe.Open(Sql, BD.Conexao, 3, 3)

                If Tbe.EOF Then

                    Sql = "INSERT INTO SGIPA.TB_CARGA_SOLTA_DESOVA_COL (AUTONUMCS,USUARIO,DT,BROWSER_NAME,BROWSER_VERSION,MOBILEDEVICEMODEL,MOBILEDEVICEMANUFACTURER,FLAG_MOBILE) VALUES ("
                    Sql = Sql & OrdensOBJ.Autonum_CS & ","
                    Sql = Sql & Session("AUTONUMUSUARIO") & ","
                    Sql = Sql & "SYSDATE,"
                    Sql = Sql & "'" & Session("BROWSER_NAME") & "',"
                    Sql = Sql & "'" & Session("BROWSER_VERSION") & "',"
                    Sql = Sql & "'" & Session("MOBILEDEVICEMODEL") & "',"
                    Sql = Sql & "'" & Session("MOBILEDEVICEMANUFACTURER") & "',"
                    Sql = Sql & IIf(Session("ISMOBILEDEVICE") = False, 0, 1)
                    Sql = Sql & ") "
                    BD.Conexao.Execute(Sql)

                End If

                Sql = "UPDATE SGIPA.TB_AVARIAS_CS SET AUTONUMCS=" & OrdensOBJ.Autonum_CS
                Sql = Sql & " WHERE NVL(AUTONUMCS,0)=0 And BL=" & Me.cbLotes.SelectedValue
                Sql = Sql & " And ITEM=" & Me.cbItem.Text
                BD.Conexao.Execute(Sql)

                Sql = "UPDATE SGIPA.TB_CARGA_SOLTA SET FLAG_AVARIADO=1 WHERE "
                Sql = Sql & " AUTONUM In (Select AUTONUMCS FROM SGIPA.TB_AVARIAS_CS WHERE AUTONUMCS=" & OrdensOBJ.Autonum_CS & ")"
                BD.Conexao.Execute(Sql)

                Me.lstMarcantes.Items.Clear()

                'Sql = "DELETE FROM TB_TEMP_DESOVA_MARCANTE WHERE LOTE='" & Me.cbLotes.SelectedValue & "' AND ID_CONTEINER='" & Me.cbConteiner.SelectedItem.Text & "'"
                'BD.Conexao.Execute(Sql)

                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro Inserido!');</script>", False)

            End If

            BD.Conexao.CommitTrans()

        Catch ex As Exception
            BD.Conexao.RollbackTrans()
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Erro. Tente Novamente.');</script>", False)

        End Try

        Carrega_Itens_Desovados(cbLotes.SelectedValue, cbConteiner.SelectedValue)


        Dim OrdemObj As New Ordens
        OrdemObj = OrdensOBJ.RetornarDadosTela(Me.cbLotes.SelectedValue, Me.cbConteiner.SelectedValue)

        If OrdemObj IsNot Nothing Then
            Me.txtEtiquetas.Text = OrdemObj.Obs_Desova_Col.Replace("<br/>", vbCrLf)
        Else
            Me.txtEtiquetas.Text = String.Empty
            Me.txtEtiquetas.Text = Nothing
        End If



    End Sub

    Private Sub Atualiza_ObsDesova()

        Dim Obs As String = String.Empty
        Dim Sql As String

        Dim Rst2 As New ADODB.Recordset
        Rst2.Open("SELECT BL,NVL(OBS_DESOVA_COL,' ') OBS_DESOVA_COL FROM SGIPA.TB_CARGA_SOLTA WHERE CNTR = " & Me.cbConteiner.SelectedValue & " ORDER BY BL", BD.Conexao, 3, 3)

        While Not Rst2.EOF
            Obs += "Lote: " & Rst2.Fields("BL").Value.ToString & " - " & Rst2.Fields("OBS_DESOVA_COL").Value.ToString & "<br/>"
            Rst2.MoveNext()
        End While

        'Obs += "Lote: " & cbLotes.SelectedValue & " - " & txtEtiquetas.Text & "<br/>"
        Sql = "UPDATE SGIPA.TB_CNTR_BL SET OBS_DESOVA_COL='" & Mid(Obs, 1, 500) & "'"
        Sql = Sql & " WHERE AUTONUM = " & Me.cbConteiner.SelectedValue
        BD.Conexao.Execute(Sql)


    End Sub

    Private Function Validar()

        Dim Sql As String

        If Me.txtDtInicio.Text = "__/__ __:__" Or Me.txtDtInicio.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Não foi informado o início da desova do contêiner');</script>", False)
            Return False
        End If

        If Me.txtDtFim.Text <> "__/__ __:__" And Me.txtDtFim.Text <> "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Já foi informado o término da desova do contêiner');</script>", False)
            Return False
        End If

        If Me.cbLotes.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione o lote');</script>", False)
            Return False
        End If

        If Me.TxtQtde.Text = String.Empty Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe a quantidade');</script>", False)
            Return False
        End If

        If Me.cbItem.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione o item');</script>", False)
            Return False
        End If

        If Me.cbEmbalagem.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe a embalagem');</script>", False)
            Return False
        End If


        'Sql = "Select autonum from sgipa.tb_carga_solta where bl=" & Me.cbLotes.SelectedValue & " and cntr=" & Me.cbConteiner.SelectedValue & " and item=" & Me.cbItem.SelectedValue
        'Dim tbE As New ADODB.Recordset
        'tbE.Open(Sql, BD.Conexao)
        'If Not tbE.EOF Then
        '    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Item já desovado');</script>", False)
        '    Return False
        'End If


        Dim QtdeM As Integer = 0
        Dim QtdeD As Integer = 0

        Sql = "SELECT QTDE_MANIFESTADA, QTDE_DESOVADA FROM SGIPA.VW_BL_ITEM_FAL_ACRESC WHERE LOTE=" & Me.cbLotes.SelectedValue & " AND ITEM=" & Me.cbItem.SelectedValue
        Dim Rst As New ADODB.Recordset
        Rst.Open(Sql, BD.Conexao, 3, 3)
        QtdeM = Rst.Fields("QTDE_MANIFESTADA").Value
        QtdeD = Rst.Fields("QTDE_DESOVADA").Value + Val(Me.TxtQtde.Text)


        If ckAcrescimo.Checked = True Or ckIDFA.Checked = True Then
            If Val(Me.txt2.Text) - Val(Me.txt1.Text) > 1 Then 'nao é ultimo BL
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Falta ou acréscimo só deve ser indicado na desova do último contêiner do lote');</script>", False)
                Return False
            End If
        End If


        'If QtdeD < QtdeM Then
        '    If ckIDFA.Checked = False Then
        '        If Val(Me.txt2.Text) - Val(Me.txt1.Text) <= 1 Then 'ultimo BL
        '            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Indique que houve falta. Qdte Manifestada " & QtdeM.ToString & ". Qtde Desovada " & QtdeD.ToString & "');</script>", False)
        '            Return False
        '        End If
        '    End If
        'End If


        If QtdeD > QtdeM Then
            If ckAcrescimo.Checked = False Then
                'If Val(Me.txt2.Text) - Val(Me.txt1.Text) <= 1 Then 'ultimo BL
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Indique que houve acrescimo. Qdte Manifestada " & QtdeM.ToString & ". Qtde Desovada " & QtdeD.ToString & "');</script>", False)
                Return False
            End If
            'End If
        End If

        'If ckIDFA.Checked = True And ckAcrescimo.Checked = True Then
        '    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Falta e acrescimo ? ');</script>", False)
        '    Return False
        'End If

        'If QtdeD = QtdeM Then
        '    If Val(Me.txt2.Text) - Val(Me.txt1.Text) <= 1 Then 'ultimo BL
        '        If ckAcrescimo.Checked = True Then
        '            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Não houve acréscimo com estas quantidades');</script>", False)
        '            Return False
        '        End If
        '        If ckIDFA.Checked = True Then
        '            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Não houve falta com estas quantidades');</script>", False)
        '            Return False
        '        End If
        '    End If
        'End If



        If Me.txtIMO.Text <> "" Then

            Sql = "Select code from operador.tb_cad_carga_perigosa where code='" & Me.txtIMO.Text & "'"
            Dim tbI As New ADODB.Recordset
            tbI.Open(Sql, BD.Conexao)
            If tbI.EOF Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Código IMO inválido');</script>", False)
                Return False
            End If
        End If

        If Me.txtTempAnvisaMax.Text <> "" And Me.txtTempAnvisa.Text <> "" Then
            If Val(Me.txtTempAnvisaMax.Text) < Val(Me.txtTempAnvisa.Text) Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Faixa de temperatura inválida');</script>", False)
                Return False
            End If
        End If


        If Session("FLAG_OB_MARCANTE") = 1 Then
            'Qtde cargas - quantidade associada aos marcantes
            Dim QtdeMarcante As Long
            QtdeMarcante = 0

            For i = 0 To Me.lstMarcantes.Items.Count - 1
                If Microsoft.VisualBasic.Right(lstMarcantes.Items(i).ToString, 1) <> "X" Then
                    QtdeMarcante = QtdeMarcante + Val(Microsoft.VisualBasic.Mid(lstMarcantes.Items(i).ToString, 14))
                End If
            Next


            If Val(Me.TxtQtde.Text) <> QtdeMarcante Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade associada aos marcantes diferente da quantidade desovada');</script>", False)
                Return False
            End If

            Return True

        Else

            Return True

        End If

    End Function

    Protected Sub btLogOff_Click(sender As Object, e As EventArgs) Handles btLogOff.Click
        If Me.cbLotes.SelectedIndex = -1 Or Me.cbLotes.SelectedIndex = 0 Or Me.cbLotes.SelectedValue Is Nothing Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('BL nao selecionado');</script>", False)
            Exit Sub
        End If

        If Me.cbItem.SelectedIndex = -1 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Item nao selecionado');</script>", False)
            Exit Sub
        End If

        Session("AUTONUMBL") = Me.cbLotes.SelectedValue
        Session("ITEM") = Me.cbItem.Text
        Session("AUTONUMCNTR") = Me.cbConteiner.SelectedValue
        Session("EMBALAGEM") = Me.cbEmbalagem.SelectedValue
        Session("QTDE") = Me.TxtQtde.Text
        Session("PESO") = Me.txtPesoBruto.Text
        Session("IMO") = Me.txtIMO.Text
        Session("ONU") = Me.txtONU.Text
        Session("DESPACHANTE") = Me.ckDespachante.Checked
        Session("ACRESCIMO") = Me.ckAcrescimo.Checked
        Session("FALTA") = Me.ckIDFA.Checked
        Session("ID_CONTEINER") = Me.cbConteiner.SelectedItem.Text
        'Session("QTEMARCANTES") = lstMarcantes.Items.Count
        'For I = 1 To Session("QTEMARCANTES")
        ' Session("MARCANTE" & I) = Me.lstMarcantes.Items(I - 1).Text
        'Next I

        Session("REFOB") = 0
        Dim Sql As String
        Sql = "Select b.autonum  from sgipa.tb_bl b inner join sgipa.tb_cad_parceiros p "
        Sql = Sql & " on b.importador = p.autonum "
        Sql = Sql & " where b.autonum=" & Session("AUTONUMBL")
        Sql = Sql & " and nvl(p.FLAG_REFERENCIA_C_AVARIA,0)=1 "
        Dim tb1 As DataTable
        tb1 = OracleDAO.List(Sql)
        If tb1.Rows.Count > 0 Then
            Session("REFOB") = 1
        End If


        Response.Redirect("Avarias.aspx")

    End Sub

    Protected Sub ckAcrescimo_CheckedChanged(sender As Object, e As EventArgs) Handles ckAcrescimo.CheckedChanged

        If ckAcrescimo.Checked Then
            ckIDFA.Checked = False
        End If

    End Sub

    Protected Sub ckIDFA_CheckedChanged(sender As Object, e As EventArgs) Handles ckIDFA.CheckedChanged

        If ckIDFA.Checked Then
            ckAcrescimo.Checked = False
        End If

    End Sub

    Protected Sub txtEtiquetas_TextChanged(sender As Object, e As EventArgs) Handles txtEtiquetas.TextChanged

    End Sub

    Protected Sub btAdd_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        If ValidaMarcante() Then
            Me.lstMarcantes.Items.Add(Me.txtMarcante.Text & " " & Me.TxtQtdeM.Text)
            Adiciona_Marcante_Temp()
            Me.TxtQtdeM.Text = ""
            Me.txtMarcante.Text = ""
            txtMarcante.Focus()
        End If
    End Sub

    Private Sub Adiciona_Marcante_Temp()

        Dim Sql As String
        Sql = "INSERT INTO SGIPA.TB_TEMP_DESOVA_MARCANTE "
        Sql = Sql & "(LOTE,"
        Sql = Sql & "ID_CONTEINER,"
        Sql = Sql & "MARCANTE,"
        Sql = Sql & "QUANTIDADE) VALUES ( "
        Sql = Sql & Me.cbLotes.SelectedValue & ","
        Sql = Sql & "'" & Me.cbConteiner.SelectedItem.Text & "',"
        Sql = Sql & "'" & Me.txtMarcante.Text & "',"
        Sql = Sql & Val(Me.TxtQtdeM.Text)
        Sql = Sql & ")"
        BD.Conexao.Execute(Sql)

    End Sub
    Private Sub Remove_Marcante_Temp()

        Dim Sql As String
        Sql = "DELETE FROM SGIPA.TB_TEMP_DESOVA_MARCANTE "
        Sql = Sql & " WHERE LOTE='" & Me.cbLotes.SelectedValue & "'"
        Sql = Sql & " AND ID_CONTEINER= '" & Me.cbConteiner.SelectedItem.Text & "'"
        Sql = Sql & " AND MARCANTE = '" & Microsoft.VisualBasic.Mid(Me.lstMarcantes.SelectedItem.Text, 1, 12) & "'"
        BD.Conexao.Execute(Sql)

    End Sub

    Private Sub Mostra_Marcante_Temp()

        Me.lstMarcantes.Items.Clear()

        Dim Sql As String
        Sql = "SELECT A.MARCANTE, A.QUANTIDADE, CASE NVL(M.DT_ASSOCIACAO,SYSDATE) WHEN SYSDATE THEN ' ' ELSE ' X' END AS JAFOI FROM SGIPA.TB_TEMP_DESOVA_MARCANTE A LEFT JOIN "
        Sql = Sql & " SGIPA.TB_MARCANTES M ON TO_NUMBER(A.MARCANTE)=M.AUTONUM"
        Sql = Sql & " WHERE A.LOTE=" & Me.cbLotes.SelectedValue
        Sql = Sql & " AND A.ID_CONTEINER= '" & Me.cbConteiner.SelectedItem.Text & "'"
        Sql = Sql & " ORDER BY A.MARCANTE "


        Dim tbI As New ADODB.Recordset
        tbI.Open(Sql, BD.Conexao)
        If Not tbI.EOF Then

            Do
                Me.lstMarcantes.Items.Add(tbI.Fields("MARCANTE").Value.ToString & " " & tbI.Fields("QUANTIDADE").Value.ToString & " " & tbI.Fields("JAFOI").Value.ToString)
                tbI.MoveNext()
            Loop While Not tbI.EOF

        End If
        tbI.Close()


    End Sub


    Private Function ValidaMarcante() As Boolean

        If Me.txtMarcante.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante não informado');</script>", False)
            Return False
        End If

        If Len(Trim(Me.txtMarcante.Text)) <> 12 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante formato incorreto');</script>", False)
            Return False
        End If

        If Me.TxtQtdeM.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Qtde de Marcante invalido');</script>", False)
            Return False
        End If

        'MARCANTE JÁ USADO
        For i = 0 To Me.lstMarcantes.Items.Count - 1
            If Me.txtMarcante.Text = Microsoft.VisualBasic.Left(Me.lstMarcantes.Items(i).Text, 12) Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante já lido');</script>", False)
                Return False
            End If
        Next

        Dim tb1 As New ADODB.Recordset
        Dim Sql As String
        Sql = "Select autonum,bl,nvl(autonum_carga,0) as autonum_carga from " & BD.BancoSgipa & "TB_MARCANTES WHERE AUTONUM=" & Val(Me.txtMarcante.Text)
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If tb1.RecordCount = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante invalido');</script>", False)
            Return False
        Else
            If tb1.Fields("autonum_carga").Value > 0 Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Este marcante já foi utilizado');</script>", False)
                Return False
            End If
            If tb1.Fields("bl").Value <> Me.cbLotes.SelectedValue Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('BL divergente do marcante');</script>", False)
                Return False
            End If
        End If
        tb1.Close()

        Return True

    End Function
    Protected Sub btRem_Click1(sender As Object, e As EventArgs) Handles btRem.Click
        If Me.lstMarcantes.SelectedIndex >= 0 Then
            Remove_Marcante_Temp()
            lstMarcantes.Items.RemoveAt(Me.lstMarcantes.SelectedIndex)

        End If
    End Sub

    Protected Sub GridDesovas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridDesovas.SelectedIndexChanged

    End Sub

    Private Sub txtEtiquetas_Load(sender As Object, e As EventArgs) Handles txtEtiquetas.Load

    End Sub

    Private Function ValidarAvaria() As Boolean

        If Me.cbLotes.SelectedIndex < 1 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('BL nao selecionado');</script>", False)
            Return False
        End If

        If Me.cbConteiner.SelectedIndex < 1 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Conteiner nao selecionado');</script>", False)
            Return False
        End If

        If Me.cbItem.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Item de bl nao selecionado');</script>", False)
            Return False

        End If

        Return True

    End Function
    Protected Sub txtONU_TextChanged(sender As Object, e As EventArgs) Handles txtONU.TextChanged

    End Sub

    Protected Sub TxtQtdeM_TextChanged(sender As Object, e As EventArgs) Handles TxtQtdeM.TextChanged

    End Sub

    Protected Sub btSalvar0_Click(sender As Object, e As EventArgs) Handles btSalvar0.Click

        If cbConteiner.SelectedValue > 0 And cbItem.Text <> "" And cbLotes.SelectedValue > 0 Then
            Dim Sql As String
            Sql = "UPDATE SGIPA.TB_CARGA_SOLTA SET OBS_DESOVA_COL='" & Me.txtEtiquetas.Text & "'"
            Sql = Sql & " WHERE CNTR=" & Me.cbConteiner.SelectedValue
            Sql = Sql & " AND BL=" & Me.cbLotes.SelectedValue
            Sql = Sql & " AND ITEM=" & Me.cbItem.Text
            BD.Conexao.Execute(Sql)
            Atualiza_ObsDesova()
        Else
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Item nao selecionado/Desovado');</script>", False)
        End If
    End Sub

    Protected Sub txtMarcante_TextChanged(sender As Object, e As EventArgs) Handles txtMarcante.TextChanged
        If Len(Me.txtMarcante.Text) = 12 Then
            TxtQtdeM.Focus()
        End If
    End Sub

    Protected Sub btnFecharConfirm_Click(sender As Object, e As EventArgs) Handles btnFecharConfirm.Click
        ModalPopupExtender1.Hide()
    End Sub

    Protected Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        ConfirmaDesovaItem()
        ModalPopupExtender1.Hide()
    End Sub

    Protected Sub btSair0_Click(sender As Object, e As EventArgs) Handles btSair0.Click
        If ValidaGeracaoMarcante() = True Then
            Dim Sql As String

            If Valida_Impressora_Patio(Session("AUTONUMPATIO"), Session("AUTONUMUSUARIO")) Then

                Sql = "INSERT INTO SGIPA.TB_SOL_MARCANTES ( "
                Sql = Sql & " AUTONUM, DT_SOLICITA, FLAG_IMPRESSO, "
                Sql = Sql & " DT_IMPRESSAO, USUARIO_SOLICITA, QTDE, "
                Sql = Sql & " BL, ITEM, CNTR, "
                Sql = Sql & " ID_CONTEINER, ID_ARMAZEM,ID_PATIO) values ( "
                Sql = Sql & " SGIPA.SEQ_SOL_MARCANTES.NEXTVAL,SYSDATE,0,NULL,"
                Sql = Sql & Session("AUTONUMUSUARIO") & ","
                Sql = Sql & Val(Me.TxtQtdeM0.Text) & ","
                Sql = Sql & Val(Me.cbLotes.SelectedValue) & ","
                Sql = Sql & Val(Me.cbItem.Text) & ","
                Sql = Sql & Me.cbConteiner.SelectedValue & ","
                Sql = Sql & "'" & Me.cbConteiner.SelectedItem.ToString & "',"
                Sql = Sql & "0,"
                Sql = Sql & Session("AUTONUMPATIO")
                Sql = Sql & ")"
                BD.Conexao.Execute(Sql)

                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcantes solicitados!');</script>", False)
                Me.TxtQtdeM0.Text = ""

            End If
        End If
    End Sub


    Private Function Valida_Impressora_Patio(QualPatio As Integer, QualUsuario As Integer) As Boolean
        Dim Sql As String = String.Empty
        Dim QualImpressora As String = String.Empty

        Sql = "SELECT  "
        Sql = Sql & " U.IMPRESSORA_MARCANTE  "
        Sql = Sql & " FROM OPERADOR.TB_CAD_USUARIOS U "
        Sql = Sql & " WHERE U.AUTONUM=" & QualUsuario
        Sql = Sql & " AND U.IMPRESSORA_MARCANTE IS NOT NULL"

        Dim tb1 As New ADODB.Recordset
        tb1.Open(Sql, BD.Conexao, 1, 1)
        If Not tb1.EOF Then
            QualImpressora = tb1.Fields("IMPRESSORA_MARCANTE").Value.ToString
        End If
        tb1.Close()

        If QualImpressora = "" Then

            Sql = "SELECT  "
            Sql = Sql & " B.IMPRESSORA_MARCANTE "
            Sql = Sql & " FROM "
            Sql = Sql & " SGIPA.TB_ARMAZENS_IPA B "
            Sql = Sql & " WHERE B.AUTONUM= " & QualPatio
            Sql = Sql & " AND B.IMPRESSORA_MARCANTE IS NOT NULL"

            Dim tb2 As New ADODB.Recordset
            tb2.Open(Sql, BD.Conexao, 1, 1)
            If Not tb2.EOF Then
                QualImpressora = tb2.Fields("IMPRESSORA_MARCANTE").Value.ToString
            End If
            tb2.Close()
        End If

        If QualImpressora = "" Then

            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Nenhuma impressora cadastrada para usuario/patio');</script>", False)
            Return False

        Else

            Sql = "Select "
            Sql = Sql & " ID_IMPRESSORA, ID_PATIO "
            Sql = Sql & " From SGIPA.TB_IMPRESSORAS_PATIO "
            Sql = Sql & " WHERE ID_IMPRESSORA='" & QualImpressora & "'"
            Sql = Sql & " AND ID_PATIO=" & QualPatio

            Dim tb3 As New ADODB.Recordset
            tb3.Open(Sql, BD.Conexao, 1, 1)
            If tb3.EOF Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Impressora inválida');</script>", False)
                Return False
            End If
            tb3.Close()

        End If

        Return True
    End Function

    Function ValidaGeracaoMarcante() As Boolean

        If Me.cbLotes.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Lote não selecionado');</script>", False)
            Return False
        End If

        If Me.cbConteiner.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Conteiner não selecionado');</script>", False)
            Return False
        End If

        If Me.cbItem.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione o item');</script>", False)
            Return False
        End If

        If Me.TxtQtdeM0.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe a quantidade de marcantes');</script>", False)
            Return False
        End If

        Return True

    End Function

    Protected Sub TxtQtdeM0_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnFotos_Click(sender As Object, e As EventArgs) Handles btnFotos.Click
        Dim OrdensOBJ As New Ordens

        If (Me.cbConteiner.SelectedIndex = -1 Or Me.cbConteiner.SelectedIndex = 0) Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione um Contêiner.');</script>", False)
            Exit Sub
        End If
        OrdensOBJ.Autonum_Cntr = Me.cbConteiner.SelectedValue
        If (Me.cbLotes.SelectedIndex = -1 Or Me.cbLotes.SelectedIndex = 0) Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione um Lote.');</script>", False)
            Exit Sub
        End If
        OrdensOBJ.Lote = Me.cbLotes.SelectedValue

        If Val(OrdensOBJ.Autonum_Cntr) = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione um Contêiner.');</script>", False)
            Exit Sub
        End If
        If Val(OrdensOBJ.Lote) = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione um Contêiner.');</script>", False)
            Exit Sub
        End If

        Dim url As String = ConfigurationManager.AppSettings("UrlSiteFotos").ToString()
        'Response.Write("<script>")
        'Response.Write("window.open("url & "'/Fotos.aspx?idTipoProcesso=1&autonumCntrBl=" & OrdensOBJ.Autonum_Cntr & "&autonumPatio=" & Session("PATIO") & "&lote=" & OrdensOBJ.Lote & "&autonumCsOp=0&autonumPatioOp=0&autonumCsrdx=0&autonumPatiordx=0','_blank')")
        'Response.Write("</script>")
        'Response.Redirect(url & "/Fotos.aspx?idTipoProcesso=1&autonumCntrBl=" & OrdensOBJ.Autonum_Cntr & "&autonumPatio=" & Session("PATIO") & "&lote=" & OrdensOBJ.Lote & "&autonumCsOp=0&autonumPatioOp=0&autonumCsrdx=0&autonumPatiordx=0")
        Response.Write("<script>window.open('" + url + "/Fotos.aspx?idTipoProcesso=1&autonumCntrBl=" & OrdensOBJ.Autonum_Cntr & "&autonumPatio=" & Session("PATIO") & "&lote=" & OrdensOBJ.Lote & "&autonumCsOp=0&autonumPatioOp=0&autonumCsrdx=0&autonumPatiordx=0','_blank');</script>")
    End Sub

    Protected Sub btnSalvarNovoitem_Click(sender As Object, e As EventArgs) Handles btnSalvarNovoitem.Click

        Dim OrdensOBJ As New Ordens

        If (Me.cbEmbalagemNovoItem.SelectedIndex <> 0) Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione uma Embalagem.');</script>", False)
            Exit Sub
        End If

        OrdensOBJ.Embalagem = Me.cbEmbalagemNovoItem.SelectedIndex
        OrdensOBJ.Qtde = 1
        If Me.txtVolumeNovoItem.Text <> "" Then
            OrdensOBJ.Volume = Replace(Replace(txtVolumeNovoItem.Text, ".", ""), ",", ".")
        Else
            OrdensOBJ.Volume = 0
        End If
        OrdensOBJ.PesoBruto = Replace(Replace(txtPesoBrutoNovoItem.Text, ".", ""), ",", ".")
        OrdensOBJ.Imo = Val(Me.txtIMONovoItem.Text)
        OrdensOBJ.Onu = Me.txtONUNovoItem.Text
        OrdensOBJ.Mercadoria = Me.TxtMercadoriaNovoItem.Text
        OrdensOBJ.Importador = Me.txtImportadorNovoItem.Text
        OrdensOBJ.Marca = Me.txtMarcaNovoItem.Text


        OracleDAO.Execute("INSERT INTO SGIPA.TB_CARGA_CNTR (autonum, bl, item, quantidade, quantidade_real, embalagem, mercadoria, marca, peso_bruto, ncm, volume_m3, ncm2, flag_item_acrescimo)
                           VALUES (SEQ_CARGA_CNTR.nextval, 
                            " & lblLote.Text & "
                            ," & Me.cbItem.Items.Count + 1 & ",
                            " & Me.TxtQtdeNovoItem.Text & ",
                            " & Me.TxtQtdeNovoItem.Text & ",
                            " & Me.cbEmbalagemNovoItem.SelectedIndex & ",
                            " & Me.TxtMercadoriaNovoItem.Text & ",
                            " & Me.txtMarcaNovoItem.Text & ",
                            " & Me.txtPesoBrutoNovoItem.Text & ",'72150000', '0', '76040000',0)")

    End Sub
    Private Sub CadastroNovoItem()
        Dim OrdensOBJ As New Ordens

        OrdensOBJ.Embalagem = Me.cbEmbalagemNovoItem.SelectedValue
        OrdensOBJ.Qtde = Me.TxtQtdeNovoItem.Text
        If Me.txtVolumeNovoItem.Text <> "" Then
            OrdensOBJ.Volume = Replace(Replace(txtVolumeNovoItem.Text, ".", ""), ",", ".")
        Else
            OrdensOBJ.Volume = 0
        End If
        OrdensOBJ.PesoBruto = Replace(Replace(txtPesoBrutoNovoItem.Text, ".", ""), ",", ".")
        OrdensOBJ.Imo = txtIMONovoItem.Text
        OrdensOBJ.Onu = txtONUNovoItem.Text
        OrdensOBJ.Mercadoria = TxtMercadoriaNovoItem.Text
        OrdensOBJ.Importador = txtImportador.Text
        OrdensOBJ.Marca = txtMarcaNovoItem.Text

        BD.Conexao.BeginTrans()
        Dim Sql As String = ""
        Sql = "insert into sgipa.tb_carga_cntr (autonum, bl, item, quantidade, quantidade_real, embalagem, mercadoria, marca, peso_bruto, ncm, volume_m3, ncm2, flag_item_acrescimo) 
                    VALUES ("
        Sql = Sql & "SEQ_CARGA_CNTR.nextval" & ","
        Sql = Sql & OrdensOBJ.Lote & ","
        Sql = Sql & "2" & ","
        Sql = Sql & OrdensOBJ.Qtde & ","
        Sql = Sql & OrdensOBJ.Qtde & ","
        Sql = Sql & OrdensOBJ.Embalagem & ","
        Sql = Sql & OrdensOBJ.Mercadoria & ","
        Sql = Sql & OrdensOBJ.Marca & ","
        Sql = Sql & OrdensOBJ.PesoBruto & ","
        Sql = Sql & "0" & ","
        Sql = Sql & "0" & ","
        Sql = Sql & "0" & ","
        Sql = Sql & "0" & ","
        Sql = Sql & ") "
        BD.Conexao.Execute(Sql)

    End Sub

    Protected Sub lblLote_Load(sender As Object, e As EventArgs) Handles lblLote.Load
        lblLote.Text = cbLotes.SelectedValue
    End Sub

    Protected Sub cbEmbalagemNovoItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmbalagemNovoItem.SelectedIndexChanged
        Dim combo = Me.cbEmbalagemNovoItem.SelectedValue

    End Sub
End Class
