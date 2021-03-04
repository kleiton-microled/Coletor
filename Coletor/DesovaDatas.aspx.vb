Public Class DesovaDatas
    Inherits System.Web.UI.Page
    Dim OrdensOBJ As New Ordens
    Dim OrdensBLL As New Ordens

    Private Sub Limpa()
        Me.txtYard.Text = ""
        Me.txtDtFim.Text = "__/__ __:__"
        Me.txtDtInicio.Text = "__/__ __:__"
        Me.txtCamera.Text = ""
        Me.txtEtiquetas.Text = ""
        Me.txtIDTimeLine.Text = ""
        Me.cbPlaca.SelectedIndex = -1
    End Sub

    Protected Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btIni.Click

        If Me.txtDtInicio.Text = "__/__ __:__" Then

            If Session("FLAG_DDC") = 1 Then
                If Me.cbPlaca.SelectedIndex < 1 Then
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione a placa');</script>", False)
                    Exit Sub
                End If
            End If

            If Me.cbConteiner.SelectedIndex < 1 Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione o conteiner');</script>", False)
                Exit Sub
            End If

            If (Me.cbConteiner.SelectedIndex > 0 And Me.cbPlaca.SelectedIndex > 0 And Session("FLAG_DDC") = 1) Or (Me.cbConteiner.SelectedIndex > 0 And Session("FLAG_DDC") = 0) Then

                ' If RadioButtonList1.SelectedIndex >= 0 Then

                Dim Sql As String
                Dim SqlF As String
                Dim IdTimeLine As Long
                Dim AutonumCamera As Long = 0


                If Session("FLAG_DDC") = 0 Then

                    Dim Rst As New ADODB.Recordset

                    Sql = " select autonum, descr  "
                    Sql = Sql & " FROM OPERADOR.TB_CAMERAS WHERE DESCR='" & Me.txtCamera.Text & "'"

                    Rst.Open(Sql, BD.Conexao, 3, 3)

                    If Rst.RecordCount = 0 Then

                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Câmera nao encontrada ' );</script>", False)
                        Exit Sub
                    Else
                        AutonumCamera = Rst.Fields("AUTONUM").Value
                    End If

                Else

                    AutonumCamera = 0

                End If


                If ValidaMapa(Me.cbConteiner.SelectedValue) = True Then

                    IdTimeLine = 0

                    If Session("FLAG_FILMA_DESOVA") = 1 Then
                        Dim RetornoGravacao$
                        RetornoGravacao = OrdensOBJ.IniciaGravacao(Me.cbConteiner.SelectedItem.Text, Me.txtCamera.Text, 1)

                        If Left$(RetornoGravacao, 5) = "Erro=" Then

                            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Atenção, não foi iniciada a gravação da filmagem da desova ' );</script>", False)
                            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" & RetornoGravacao & "');</script>", False)
                        End If

                        If Left$(RetornoGravacao, 11) = "IdTimeLine=" Then
                            IdTimeLine = Val(Mid$(RetornoGravacao, 12))
                        End If

                    End If

                    Sql = "UPDATE SGIPA.TB_CNTR_BL SET DT_INICIO_DESOVA=SYSDATE "

                    If Me.RadioButtonList1.SelectedIndex = 0 Then
                        Sql = Sql & " ,FLAG_DESOVA_MANUAL=1"
                    ElseIf Me.RadioButtonList1.SelectedIndex = 1 Then
                        Sql = Sql & " ,FLAG_DESOVA_MANUAL=0"
                    ElseIf Me.RadioButtonList1.SelectedIndex < 0 Then
                        Sql = Sql & " ,FLAG_DESOVA_MANUAL=NULL"
                    End If
                    Sql = Sql & ", IDTIMELINE= {0} "
                    Sql = Sql & ", ID_CAMERA_DESOVA= {1} "
                    Sql = Sql & " ,CONFERENTE_DESOVA = '{2}' "
                    Sql = Sql & " WHERE AUTONUM={3} "

                    SqlF = String.Format(Sql, IdTimeLine, AutonumCamera, Session("USUARIO"), Me.cbConteiner.SelectedValue)


                    Try
                        BD.Conexao.Execute(SqlF.ToString(), BD.LinhasAfetadas)
                    Catch ex As Exception
                        Throw New Exception("Erro. Tente novamente." & ex.Message())
                    End Try

                    If Session("FLAG_DDC") = 1 Then

                        Sql = "UPDATE SGIPA.TB_ORDEM_CARREGAMENTO SET INICIO_DESOVA_DDC=SYSDATE "
                        Sql = Sql & ", ID_CAMERA_DESOVA_DDC= {0} "
                        Sql = Sql & " WHERE AUTONUM = {1} "

                        SqlF = String.Format(Sql, AutonumCamera, Val(Me.TXTOC.Text))


                        Try
                            BD.Conexao.Execute(SqlF.ToString(), BD.LinhasAfetadas)
                        Catch ex As Exception
                            Throw New Exception("Erro. Tente novamente." & ex.Message())
                        End Try

                    End If


                    If Session("FLAG_DDC") = 1 Then

                        CarregarDadosCntr(Me.cbConteiner.SelectedValue, Session("FLAG_DDC"), Mid(cbPlaca.SelectedItem.Text, 1, 8), cbPlaca.SelectedValue)
                    Else
                        CarregarDadosCntr(Me.cbConteiner.SelectedValue, Session("FLAG_DDC"), "", 0)
                    End If


                Else

                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Atenção. Um ou mais lotes deste conteiner não tem autorizacao do MAPA. Contacte o setor de importação');</script>", False)
                End If


            End If

        Else
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Data de Início de desova já informado.');</script>", False)
        End If
    End Sub

    Private Function ValidaMapa(AutonumCntr As Long) As Boolean
        Dim Sql As String = String.Empty
        Dim tb1 As New ADODB.Recordset
        Dim tb2 As New ADODB.Recordset
        Dim tb3 As New ADODB.Recordset

        Sql = "SELECT NVL(COUNT(1),0) AS QTE FROM SGIPA.TB_AMR_CNTR_BL WHERE CNTR =" & AutonumCntr
        Sql = Sql & " AND BL IN(SELECT AUTONUM FROM SGIPA.TB_BL WHERE NVL(AUDIT_SIGVIG_PC,0) > 0 OR NVL(AUDIT_SIGVIG_SIT,0) > 0) "

        tb1.Open(Sql, BD.Conexao, 3, 3)
        If tb1.Fields("QTE").Value > 0 Then
            'VERIFICA SE É PARTE - LOTE
            Sql = "SELECT NVL(COUNT(1),0) AS QTE FROM SGIPA.TB_AMR_CNTR_BL WHERE CNTR =" & AutonumCntr
            Sql = Sql & " AND BL IN(SELECT AUTONUM FROM SGIPA.TB_BL WHERE FLAG_ATIVO = 1) "
            tb2.Open(Sql, BD.Conexao, 3, 3)

            If tb2.Fields("QTE").Value > 1 Then
                'VERIFICA ENTRE OS BLS ATIVOS SE HÁ ALGUM SEM DATA DE LIBERACAO
                Sql = "SELECT NVL(COUNT(1),0) AS QTE FROM SGIPA.TB_BL "
                Sql = Sql & " WHERE AUTONUM IN (SELECT BL FROM SGIPA.TB_AMR_CNTR_BL WHERE CNTR = " & AutonumCntr & "   ) "
                Sql = Sql & " AND DT_LIBERACAO IS NULL "
                Sql = Sql & " AND (NVL(AUDIT_SIGVIG_PC,0) > 0 OR NVL(AUDIT_SIGVIG_SIT,0) > 0) AND FLAG_ATIVO=1 "

                tb3.Open(Sql, BD.Conexao, 3, 3)

                If tb3.Fields("QTE").Value > 0 Then
                    tb3.Close()
                    Return False
                End If
            End If
            tb2.Close()
        End If
        tb1.Close()

        Return True
    End Function

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

        If Session("FLAG_DDC") = 0 Then
            Me.lblTitulo.Text = "DESOVA DE CONTEINER"
            Me.btDDCItens.Visible = False
            Me.cbPlaca.Visible = False
            Me.lblPlaca.Visible = False
        End If

        If Session("FLAG_DDC") = 1 Then
            Me.lblTitulo.Text = "DESOVA DIRETA CAM."
            Me.btDDCItens.Visible = True
            Me.cbPlaca.Visible = True
            Me.lblPlaca.Visible = True
        End If

        lblUsuario.Text = Session("USUARIO")
        lblTerminal.Text = Session("PATIO")

        If Not Page.IsPostBack Then
            CarregarConteineres()
            cbConteiner.SelectedIndex = -1
        End If

        If Session("RET_AUTONUMCNTR") IsNot Nothing And
            Session("RET_AUTONUMVEICULODDC") IsNot Nothing Then

            CarregarConteineres()

            If Me.cbConteiner.Items.Count > 0 Then
                Me.cbConteiner.SelectedValue = Val(Session("RET_AUTONUMCNTR").ToString())
            End If

            CarregaPlacas(Val(Session("RET_AUTONUMCNTR").ToString()))

            If Me.cbPlaca.Items.Count > 0 Then
                Me.cbPlaca.SelectedValue = Val(Session("RET_AUTONUMVEICULODDC").ToString())
                CarregarDadosCntr(Me.cbConteiner.SelectedValue, Session("FLAG_DDC"), Mid(cbPlaca.SelectedItem.Text, 1, 8), cbPlaca.SelectedValue)
            End If

            Session("RET_AUTONUMCNTR") = Nothing
            Session("RET_AUTONUMVEICULODDC") = Nothing

        End If

        'RET_FOT_CNTR
        If Request.QueryString("RET_FOT_CNTR") IsNot Nothing Then
            Me.cbPlaca.SelectedIndex = -1

            CarregarConteineres()
            Me.cbConteiner.SelectedValue = Request.QueryString("RET_FOT_CNTR")
            CarregarDadosCntr(Request.QueryString("RET_FOT_CNTR"), Session("FLAG_DDC"), "", 0)
        End If

    End Sub



    Private Sub CarregarConteineres()

        Me.cbConteiner.DataTextField = "DISPLAY"
        Me.cbConteiner.DataValueField = "AUTONUM"

        Me.cbConteiner.DataSource = Ordens.ConsultarConteineresIni(Session("AUTONUMPATIO"), Session("FLAG_DDC"))
        Me.cbConteiner.DataBind()

        Me.cbConteiner.Items.Insert(0, "Escolher")
        Me.cbConteiner.SelectedIndex = 0


    End Sub

    Protected Sub cbConteiner_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConteiner.SelectedIndexChanged
        If Me.cbConteiner.SelectedIndex > 0 Then
            If Session("FLAG_DDC") = 0 Then
                CarregarDadosCntr(Me.cbConteiner.SelectedValue, Session("FLAG_DDC"), "", 0)
            Else
                Me.cbPlaca.SelectedIndex = -1
                CarregaPlacas(Me.cbConteiner.SelectedValue)
            End If
        End If
    End Sub

    Public Sub CarregaPlacas(AUTONUMCNTR As Long)

        Me.cbPlaca.DataTextField = "DISPLAY"
        Me.cbPlaca.DataValueField = "AUTONUM"


        Me.cbPlaca.DataSource = Ordens.ConsultarPlacas(AUTONUMCNTR, Session("FLAG_DDC"))
        Me.cbPlaca.DataBind()



        Me.cbPlaca.Items.Insert(0, "--Selecione a Placa--")
        Me.cbPlaca.SelectedIndex = 0
    End Sub

    Public Sub CarregarDadosCntr(ByVal Autonum_Cntr As Integer, Flag_DDC As Integer, Placa As String, Ordem As Long)

        Dim OrdensOBJ As Ordens = Ordens.PopulaDadosCntr(Autonum_Cntr, Flag_DDC, Placa, Ordem)

        If OrdensOBJ IsNot Nothing Then
            Me.txtYard.Text = OrdensOBJ.Yard.ToString
            Me.txtDtFim.Text = OrdensOBJ.DtFim.ToString
            Me.txtDtInicio.Text = OrdensOBJ.DtInicio.ToString
            Me.txtCamera.Text = OrdensOBJ.Camera.ToString
            If OrdensOBJ.FlagDesovaManual = 1 Then
                Me.RadioButtonList1.SelectedIndex = 0
            ElseIf OrdensOBJ.FlagDesovaManual = 0 Then
                Me.RadioButtonList1.SelectedIndex = 1
            ElseIf OrdensOBJ.FlagDesovaManual = 9 Then
                Me.RadioButtonList1.SelectedIndex = -1
            End If
            Me.txtEtiquetas.Text = OrdensOBJ.Obs_Desova_Col.ToString.Trim
            Me.txtIDTimeLine.Text = OrdensOBJ.IdtimeLine.ToString
            Me.txtEtiquetas.Text = OrdensOBJ.Obs_Desova_Col.ToString().Replace("<br/>", vbCrLf)

            Me.TXTOC.Text = OrdensOBJ.OC.ToString
        Else
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro não mais disponível');</script>", False)
        End If


    End Sub

    Private Sub form2_Load(sender As Object, e As System.EventArgs) Handles form2.Load

        'If Session("LOGADO") Is Nothing Or Session("USUARIO") Is Nothing Or Session("SENHA") Is Nothing Or Session("EMPRESA") Is Nothing Or Session("PATIO") Is Nothing Or Session("AUTONUMPATIO") Is Nothing Then
        '    Try
        '        Session("LOGADO") = Server.HtmlEncode(Request.Cookies("LOGADO").Value)
        '        Session("USUARIO") = Server.HtmlEncode(Request.Cookies("USUARIO").Value)
        '        Session("SENHA") = Server.HtmlEncode(Request.Cookies("SENHA").Value)
        '        Session("EMPRESA") = Server.HtmlEncode(Request.Cookies("EMPRESA").Value)
        '        Session("PATIO") = Server.HtmlEncode(Request.Cookies("PATIO").Value)
        '        Session("AUTONUMPATIO") = Server.HtmlEncode(Request.Cookies("AUTONUMPATIO").Value)
        '        Session("AUTONUMUSUARIO") = Server.HtmlEncode(Request.Cookies("AUTONUMUSUARIO").Value)
        '        Session("BROWSER_NAME") = Server.HtmlEncode(Request.Cookies("BROWSER_NAME").Value)
        '        Session("BROWSER_VERSION") = Server.HtmlEncode(Request.Cookies("BROWSER_VERSION").Value)
        '        Session("MobileDeviceModel") = Server.HtmlEncode(Request.Cookies("MobileDeviceModel").Value)
        '        Session("MobileDeviceManufacturer") = Server.HtmlEncode(Request.Cookies("MobileDeviceManufacturer").Value)
        '        Session("IsMobileDevice") = Server.HtmlEncode(Request.Cookies("IsMobileDevice").Value)
        '        Session("FLAG_OB_MARCANTE") = Server.HtmlEncode(Request.Cookies("FLAG_OB_MARCANTE").Value)
        '        Session("FLAG_FILMA_DESOVA") = Server.HtmlEncode(Request.Cookies("FLAG_FILMA_DESOVA").Value)
        '        Session("FLAG_REDEX_SEM_MARCANTE") = Server.HtmlEncode(Request.Cookies("FLAG_REDEX_SEM_MARCANTE").Value)
        '        Session("LARGURATELA") = Server.HtmlEncode(Request.Cookies("LARGURATELA").Value)
        '    Catch ex As Exception
        '        Response.Redirect("Index.aspx")
        '    End Try
        'End If

        'txtUsuario.Text = Session("USUARIO")
        'txtTerminal.Text = Session("PATIO")

        'If Not Page.IsPostBack Then
        '    CarregarConteineres()
        '    cbConteiner.SelectedIndex = -1
        'End If
    End Sub



    Protected Sub btFim_Click(sender As Object, e As EventArgs) Handles btFim.Click

        If Me.txtDtInicio.Text <> "__/__ __:__" Then

            If Me.RadioButtonList1.SelectedIndex >= 0 Then

                If Me.txtDtFim.Text = "__/__ __:__" Then
                    If OrdensOBJ.ExisteLotesPendentes(Me.cbConteiner.SelectedValue, Session("FLAG_DDC")) Then
                        lblAlerta.Text = "Atenção: Existem lotes ainda não desovados. Deseja Continuar ? "
                        pnConfirma.Visible = True
                        ModalPopupExtender1.Show()
                    Else
                        ConfirmarFim()

                    End If
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Data de Término de desova já informada.');</script>", False)
                End If
            Else
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe se a desova foi manual ou mecanizada');</script>", False)
            End If
        Else
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Data de Início de desova não informada.');</script>", False)
        End If

    End Sub

    Private Sub ConfirmarFim()
        lblAlerta.Text = "Confirma o fim da desova do Contêiner ? "
        pnConfirma.Visible = True
        ModalPopupExtender1.Show()
    End Sub

    Private Function PPonto(ByVal valor As String) As String
        Return Replace(Replace(valor, ".", ""), ",", ".")
    End Function

    Private Sub Finalizar()

        Dim Valida As Boolean
        Valida = True

        Dim AutonumCamera As Long

        Dim Sql As String
        Dim SqlF As String


        If Session("FLAG_DDC") = 0 Then
            If Me.txtCamera.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Atenção, câmera nao informada ');</script>", False)
                Valida = False
            Else
                Dim Rst As New ADODB.Recordset

                Sql = " select autonum, descr  "
                Sql = Sql & " FROM OPERADOR.TB_CAMERAS WHERE DESCR='" & Me.txtCamera.Text & "'"

                Rst.Open(Sql, BD.Conexao, 3, 3)

                If Rst.RecordCount = 0 Then
                    Valida = False
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Câmera nao encontrada ' );</script>", False)
                Else
                    AutonumCamera = Rst.Fields("AUTONUM").Value
                End If
            End If

        Else
            AutonumCamera = 0

        End If

        If Session("FLAG_DDC") = 0 Then

            If Valida Then

                Sql = "Select A.LOTE,A.ITEM FROM "
                Sql = Sql & " (Select lote,item,quantidade from sgipa.vw_desova_col_itens  where autonum_cntr=" & Me.cbConteiner.SelectedValue & ") A, "
                Sql = Sql & " (Select lote, item, quantidade, idfa from sgipa.vw_desova_col_itens_desovados  where autonum_cntr=" & Me.cbConteiner.SelectedValue & ") B, "
                Sql = Sql & " (select lote, lotes_manifestados, lotes_desovados from sgipa.vw_lote_manif_desovados) C "
                Sql = Sql & " where "
                Sql = Sql & " a.lote =  b.lote And a.item = b.item And a.quantidade > b.quantidade And b.idfa = 0 "
                Sql = Sql & " And a.lote = c.lote "
                Sql = Sql & " And c.lotes_manifestados=c.lotes_desovados "


                Dim tbFalta As New ADODB.Recordset
                tbFalta.Open(Sql, BD.Conexao, 3, 3)
                While Not tbFalta.EOF

                    If Valida Then

                        'ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Bl/Item sem indicação de falta " + tbFalta.Fields("lote").Value.ToString + " " + tbFalta.Fields("item").Value.ToString + "' );</script>", False)

                        Sql = "select NVL(sum(d.quantidade),0)  as qd from sgipa.vw_desova_col_itens_desovados d  "
                        Sql = Sql & " where d.lote= " & tbFalta.Fields("lote").Value.ToString

                        Dim QteM As Long = 0
                        Dim QteD As Long = 0

                        Dim tb1 As New ADODB.Recordset
                        tb1.Open(Sql, BD.Conexao, 3, 3)
                        If Not tb1.EOF Then
                            QteD = tb1.Fields("qd").Value
                        End If

                        Sql = "select NVL(max(d.quantidade),0)  as qd from sgipa.vw_desova_col_itens d  "
                        Sql = Sql & " where d.lote= " & tbFalta.Fields("lote").Value.ToString

                        Dim tb2 As New ADODB.Recordset
                        tb2.Open(Sql, BD.Conexao, 3, 3)
                        If Not tb2.EOF Then
                            QteM = tb2.Fields("qd").Value
                        End If

                        If QteD < QteM Then
                            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Bl/Item DESOVADO (" & tbFalta.Fields("lote").Value.ToString & ") com qtde a menor sem indicação de falta ' );</script>", False)
                            Valida = False
                        End If
                    End If
                    tbFalta.MoveNext()

                End While

                tbFalta.Close()



                If Valida Then

                    Sql = "Select A.LOTE,A.ITEM FROM "
                    Sql = Sql & " (Select lote,item,quantidade from sgipa.vw_desova_col_itens  where autonum_cntr=" & Me.cbConteiner.SelectedValue & ") A, "
                    Sql = Sql & " (Select lote, item, quantidade, flag_acrescimo from sgipa.vw_desova_col_itens_desovados  where autonum_cntr=" & Me.cbConteiner.SelectedValue & ") B, "
                    Sql = Sql & " (select lote, lotes_manifestados, lotes_desovados from sgipa.vw_lote_manif_desovados) C "
                    Sql = Sql & " where "
                    Sql = Sql & " a.lote =  b.lote And a.item = b.item And a.quantidade < b.quantidade And b.flag_acrescimo = 0 "
                    Sql = Sql & " And a.lote = c.lote "
                    Sql = Sql & " And c.lotes_manifestados=c.lotes_desovados "

                    Dim tbAC As New ADODB.Recordset
                    tbAC.Open(Sql, BD.Conexao, 3, 3)
                    If Not tbAC.EOF Then
                        'ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Bl/Item sem indicação de acréscimo " + tbAC.Fields("lote").Value.ToString + " " + tbAC.Fields("item").Value.ToString + "' );</script>", False)
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Bl/Item DESOVADO (" & tbAC.Fields("lote").Value.ToString & ") com qtde a maior sem indicação de acrescimo ' );</script>", False)
                        Valida = False
                    End If
                    tbAC.Close()
                End If


            End If
        End If


        '       Valida = True



        If Session("FLAG_DDC") = 1 Then

            Sql = "select count(1) from sgipa.tb_carga_solta where usuario_ddc=" & Session("AUTONUMUSUARIO").ToString()
            Sql = Sql & " and cntr = " & Me.cbConteiner.SelectedValue
            Dim ds As New DataTable
            ds = OracleDAO.List(Sql)
            If ds IsNot Nothing Then
                If ds.Rows.Count = 0 Then
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Não é permitido o fim da desova sem o cadastro dos itens');</script>", False)
                    Exit Sub
                End If
            End If
        End If

        If Valida Then

            If Session("FLAG_FILMA_DESOVA") = 1 Then

                Dim RetornoGravacao$

                Try

                    RetornoGravacao = OrdensOBJ.PararGravacao(Val(Me.txtIDTimeLine.Text), Me.txtCamera.Text, OrdensOBJ.Agora)

                    If Left$(RetornoGravacao, 5) = "Erro=" Then
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Atenção, erro ao tentar parar a filmagem da desova ' );</script>", False)
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" & RetornoGravacao & "');</script>", False)
                    End If

                Catch ex As Exception

                End Try

            End If

            If Session("FLAG_DDC") = 1 Then

                Sql = "UPDATE SGIPA.TB_ORDEM_CARREGAMENTO SET FIM_DESOVA_DDC=SYSDATE "
                Sql = Sql & ", ID_CAMERA_DESOVA_DDC= {0} "
                Sql = Sql & " WHERE AUTONUM ={1} "

                SqlF = String.Format(Sql, AutonumCamera, Me.TXTOC.Text)


                Try
                    BD.Conexao.Execute(SqlF.ToString(), BD.LinhasAfetadas)
                Catch ex As Exception
                    Throw New Exception("Erro. Tente novamente." & ex.Message())
                End Try

            End If

            Sql = "UPDATE SGIPA.TB_CNTR_BL SET DT_FIM_DESOVA=SYSDATE "
            Sql = Sql & ", ID_CAMERA_DESOVA= " & AutonumCamera
            If Me.RadioButtonList1.SelectedIndex = 0 Then
                Sql = Sql & " ,FLAG_DESOVA_MANUAL=1"
            ElseIf Me.RadioButtonList1.SelectedIndex = 1 Then
                Sql = Sql & " ,FLAG_DESOVA_MANUAL=0"
            ElseIf Me.RadioButtonList1.SelectedIndex < 0 Then
                Sql = Sql & " ,FLAG_DESOVA_MANUAL=NULL"
            End If
            If Session("FLAG_DDC") = 1 Then
                Sql = Sql & " ,YARD='SAIDA' "
            End If


            Sql = Sql & " WHERE AUTONUM={0} "

            SqlF = String.Format(Sql, Me.cbConteiner.SelectedValue)

            Try
                BD.Conexao.Execute(SqlF.ToString(), BD.LinhasAfetadas)

            Catch ex As Exception
                Throw New Exception("Erro. Tente novamente." & ex.Message())
            End Try


            If Session("FLAG_DDC") = 1 Then
                CarregarDadosCntr(Me.cbConteiner.SelectedValue, Session("FLAG_DDC"), Mid(cbPlaca.SelectedItem.Text, 1, 8), Me.cbPlaca.SelectedValue)
            Else
                CarregarDadosCntr(Me.cbConteiner.SelectedValue, Session("FLAG_DDC"), "", 0)
            End If

            If Session("FLAG_DDC") = 1 Then

                Dim Rsb As New ADODB.Recordset

                Sql = "select a.ordem_carreg, a.quantidade,cs.embalagem,a.autonum, bl.num_documento,nvl(cs.peso_bruto,0) as peso"
                Sql = Sql & " from"
                Sql = Sql & " operador.tb_gate_new gn"
                Sql = Sql & " inner join operador.tb_amr_gate ag on gn.autonum=ag.gate"
                Sql = Sql & " inner join tb_ordem_carregamento oc on ag.id_oc=oc.autonum"
                Sql = Sql & " inner join sgipa.tb_registro_saida_cs a on oc.autonum = a.ordem_carreg"
                Sql = Sql & " inner join sgipa.tb_ordem_carregamento b on a.ordem_carreg=b.autonum"
                Sql = Sql & " inner join sgipa.tb_carga_solta cs on A.cs=cs.autonum"
                Sql = Sql & " inner join sgipa.tb_bl bl on cs.bl=bl.autonum"
                Sql = Sql & " where"
                Sql = Sql & " gn.flag_gate_out=0 and b.flag_saida=0 "
                Sql = Sql & " and gn.placa='" & Mid(cbPlaca.SelectedItem.Text, 1, 8) & "'"

                Rsb.Open(Sql, BD.Conexao, 3, 3)

                If Rsb.EOF Then
                    Rsb.Close()
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Não consta descarga ou entrada deste veiculo');</script>", False)
                End If

                Do While Not Rsb.EOF

                    Sql = "select count(*) from sgipa.tb_balanca_armazem where sc=" & Rsb.Fields("Autonum").Value.ToString()

                    If Val(BD.Conexao.Execute(Sql).Fields(0).ToString) = 0 Then

                        Dim id As Long
                        id = BD.Conexao.Execute("select SGIPA.seq_ticket_armazem.nextval from dual").Fields(0).Value

                        Sql = "insert into SGIPA.tb_balanca_armazem ("
                        Sql = Sql & "autonum,"
                        Sql = Sql & "autonum_reg,"
                        Sql = Sql & "sistema,quantidade,peso,embalagem,data_pesagem,observacao,documento,local,local_gerador,sc,placa,flag_retorno) values ("
                        Sql = Sql & ID & ","
                        Sql = Sql & Rsb.Fields("ordem_carreg").Value.ToString()
                        Sql = Sql & ",'IPA'"
                        Sql = Sql & "," & PPonto(Rsb.Fields("Quantidade").Value.ToString())
                        Sql = Sql & "," & PPonto(Rsb.Fields("Peso").Value.ToString())
                        Sql = Sql & "," & Rsb.Fields("embalagem").Value.ToString()
                        Sql = Sql & ",to_date('" & Now.ToString("dd/MM/yyyy HH:mm") & "','dd/mm/yyyy hh24:mi')"
                        Sql = Sql & ",''"
                        Sql = Sql & ",''"
                        Sql = Sql & ",'G'"
                        Sql = Sql & ",'G'"
                        Sql = Sql & "," & Rsb.Fields("Autonum").Value.ToString()
                        Sql = Sql & ",'" & Mid(cbPlaca.SelectedItem.Text, 1, 8) & "'"
                        Sql = Sql & ",0"
                        Sql = Sql & ")"
                    Else
                        Sql = "update sgipa.tb_balanca_armazem set"
                        Sql = Sql & " autonum_reg = " & Rsb.Fields("ordem_carreg").Value.ToString()
                        Sql = Sql & ", quantidade = " & PPonto(Rsb.Fields("Quantidade").Value.ToString())
                        Sql = Sql & ",peso = " & PPonto(Rsb.Fields("Peso").Value.ToString())
                        Sql = Sql & ", embalagem = " & Rsb.Fields("embalagem").Value.ToString()
                        Sql = Sql & ", data_pesagem = to_date('" & Now.ToString("dd/MM/yyyy HH:mm") & "','dd/mm/yyyy hh24:mi')"
                        Sql = Sql & " where  SC = " & Rsb.Fields("Autonum").Value.ToString()

                        BD.Conexao.Execute(Sql)
                    End If

                    BD.Conexao.Execute(Sql)
                    Rsb.MoveNext()

                Loop

            End If


        End If

        pnConfirma.Visible = False


    End Sub

    Protected Sub btnConfirmarYrd_Click(sender As Object, e As EventArgs) Handles btnConfirmarYrd.Click
        Finalizar()
    End Sub

    Protected Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click


        If Me.lblAlerta.Text = "Confirma o fim da desova do Contêiner ? " Then
            Finalizar()
            lblAlerta.Text = ""
            pnConfirma.Visible = False
        Else
            ConfirmarFim()
        End If


    End Sub

    Protected Sub btnFecharConfirm_Click(sender As Object, e As EventArgs) Handles btnFecharConfirm.Click
        ModalPopupExtender1.Hide()
    End Sub



    Protected Sub btnFecharConfirmYrd_Click(sender As Object, e As EventArgs) Handles btnFecharConfirmYrd.Click
        ModalPopupExtender1.Hide()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged

    End Sub

    Protected Sub btDDCItens_Click(sender As Object, e As EventArgs) Handles btDDCItens.Click

        If Me.txtDtInicio.Text = "__/__ __:__" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Data de Início não informada.');</script>", False)
            Exit Sub
        End If
        If Me.txtDtFim.Text <> "__/__ __:__" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Data de término já informada.');</script>", False)
            Exit Sub
        End If

        If Me.cbConteiner.SelectedValue > 0 And Me.cbPlaca.SelectedValue > 0 Then

            Session("ID_CONTEINER") = Me.cbConteiner.SelectedItem.Text

            Session("PLACA") = Mid(cbPlaca.SelectedItem.Text, 1, 8)
            Session("AUTONUMVEICULODDC") = Me.cbPlaca.SelectedValue
            Session("AUTONUMCNTR") = Me.cbConteiner.SelectedValue
            Session("OC") = Val(Me.TXTOC.Text)

            Response.Redirect("DDC.aspx")

        End If


    End Sub

    Protected Sub cbPlaca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPlaca.SelectedIndexChanged
        If Me.cbPlaca.SelectedIndex > 0 Then

            CarregarDadosCntr(Me.cbConteiner.SelectedValue, Session("FLAG_DDC"), Mid(cbPlaca.SelectedItem.Text, 1, 8), cbPlaca.SelectedValue)

        End If
    End Sub

    Protected Sub btnFotos_Click(sender As Object, e As EventArgs) Handles btnFotos.Click

        If Val(cbConteiner.SelectedValue) = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione um Contêiner.');</script>", False)
            Exit Sub
        End If

        Dim url As String = ConfigurationManager.AppSettings("UrlSiteFotos").ToString()
        Response.Write("<script>window.open('" + url + "/Fotos.aspx?idTipoProcesso=1&autonumCntrBl=" & cbConteiner.SelectedValue & "&autonumPatio=" + Session("PATIO").ToString() + "&lote=0&autonumCsOp=0&autonumPatioOp=0&autonumCsrdx=0&autonumPatiordx=0','_blank');</script>")
    End Sub
End Class