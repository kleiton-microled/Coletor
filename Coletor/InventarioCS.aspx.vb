Public Class WebForm3
    Inherits System.Web.UI.Page

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

        If Not Page.IsPostBack Then
            Limpa()
            CarregarArmazens()
            CarregarMotivos()
            Me.cbArm.SelectedIndex = -1
            If Me.cbMotivoPos.Items.Count > 1 Then
                Me.cbMotivoPos.SelectedIndex = 1
            End If
        End If



    End Sub

    Private Sub CarregarArmazens()


        Me.cbArm.DataTextField = "DISPLAY"
        Me.cbArm.DataValueField = "AUTONUM"

        Me.cbArm.DataSource = InventarioCS_f2.ConsultarArmazens(Session("AUTONUMPATIO"))
        Me.cbArm.DataBind()

        Me.cbArm.Items.Insert(0, "--Arm--")
        Me.cbArm.SelectedIndex = 0



    End Sub
    Private Sub CarregarMotivos()


        Me.cbMotivoPos.DataTextField = "DISPLAY"
        Me.cbMotivoPos.DataValueField = "AUTONUM"

        Me.cbMotivoPos.DataSource = InventarioCS_f2.ConsultarMotivo()
        Me.cbMotivoPos.DataBind()

        Me.cbMotivoPos.Items.Insert(0, "--Motivo--")
        Me.cbMotivoPos.SelectedIndex = 0



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

    Sub Limpa()
        Me.txtCliente.Text = ""
        Me.txtConteiner.Text = ""
        Me.txtEmbalagem.Text = ""
        Me.txtEntrada.Text = ""
        Me.txtLocal.Text = ""
        'Me.cbLocalPOS.SelectedIndex = -1
        Me.txtMarca.Text = ""
        Me.txtMercadoria.Text = ""
        Me.txtQtde.Text = ""
        Me.txtQtdePos.Text = ""
        Me.txtNVOCC.Text = ""
        Me.txtVolume.Text = ""
        Me.txtDOC.Text = ""
        Me.txtCanal.Text = ""
        Me.txtIMO.Text = ""
        Me.txtBL.Text = ""
        Me.txtMOV.Text = ""
        Me.txtlocalpos.Text = ""

        Me.txtCargaNoLocal.Text = ""
        Me.txtANVISA.Text = ""

        Me.cbArm.SelectedIndex = -1
        Me.cbItem.SelectedIndex = -1
        'Me.cbMotivoPos.SelectedIndex = -1
        Me.cbOcupacao_CT.SelectedValue = 0
        Me.cbOcupacao_CT.Visible = False

        Me.txtSISTEMA.Text = ""
        Me.txtLote.Focus()

    End Sub

    Protected Sub LimpaItens()
        CarregarItens("0", False)
    End Sub



    Protected Sub Filtra()

        LimpaItens()

        Carrega_Dados_Lote(Me.txtLote.Text)

    End Sub

    Protected Sub Carrega_Dados_Lote(ByVal QualLote As String)


        Dim OrdensOBJ As InventarioCS_f2 = InventarioCS.PopulaDadosLote(QualLote, Session("AUTONUMPATIO"), IIf(Session("FLAG_REDEX_SEM_MARCANTE") = 1, True, False))


            Limpa()
            If OrdensOBJ IsNot Nothing Then

                If OrdensOBJ.Patio.ToString = Session("AUTONUMPATIO").ToString Then
                    'Me.txtLote.Text =
                    Me.txtMercadoria.Text = OrdensOBJ.Mercadoria.ToString
                    Me.txtMarca.Text = OrdensOBJ.Marca.ToString
                    Me.txtEntrada.Text = OrdensOBJ.Entrada.ToString
                    Me.txtConteiner.Text = OrdensOBJ.Conteiner.ToString
                    Me.txtCliente.Text = OrdensOBJ.Cliente.ToString
                    Me.txtVolume.Text = OrdensOBJ.Volume.ToString & " m3"
                    If OrdensOBJ.Doc.ToString <> "NOT DEFINED YET" Then
                        Me.txtDOC.Text = OrdensOBJ.Doc.ToString
                    Else
                        Me.txtDOC.Text = ""
                    End If
                    Me.txtCanal.Text = OrdensOBJ.Canal.ToString
                    Me.txtMOV.Text = OrdensOBJ.Movimento.ToString
                    If OrdensOBJ.IMO.ToString <> "0" Then
                        Me.txtIMO.Text = OrdensOBJ.IMO.ToString
                    Else
                        Me.txtIMO.Text = ""
                    End If
                    Me.txtNVOCC.Text = OrdensOBJ.Nvocc.ToString
                    Me.txtBL.Text = OrdensOBJ.BL.ToString
                    Me.txtSISTEMA.Text = OrdensOBJ.Sistema.ToString
                    Me.txtANVISA.Text = OrdensOBJ.ANVISA.ToString

                    CarregarItens(QualLote, IIf(OrdensOBJ.Sistema.ToString = "RDX", True, False))
                    Me.txtQtdePos.Focus()

                Else

                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Pátio divergente do usuário logado');</script>", False)
                    'auqi usa
                End If


            Else
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Lote não encontrado');</script>", False)

            End If


    End Sub


    Sub Carrega_Dados_Item(ByVal Id_Gravacao As String)

        Dim OrdensOBJ As InventarioCS_f2 = InventarioCS.PopulaItem(Id_Gravacao)


        If OrdensOBJ IsNot Nothing Then
            Me.txtQtde.Text = OrdensOBJ.Quantidade.ToString
            Me.txtEmbalagem.Text = OrdensOBJ.Embalagem.ToString
            Me.txtLocal.Text = OrdensOBJ.Local.ToString
            If OrdensOBJ.Yard.ToString <> "-" Then
                Me.txtYard.Text = OrdensOBJ.Yard.ToString
            Else
                Me.txtYard.Text = ""
            End If
        End If

    End Sub

    Private Sub CarregarItens(ByVal QualLote As String, FlagRedex As Boolean)

        If QualLote <> "0" Then

            Me.cbItem.DataTextField = "DISPLAY"
            Me.cbItem.DataValueField = "AUTONUM"

            Me.cbItem.DataSource = InventarioCS.ConsultarItensLote(QualLote, FlagRedex, Session("AUTONUMPATIO"))
            Me.cbItem.DataBind()


            Me.cbItem.Items.Insert(0, "--Item--")
            Me.cbItem.SelectedIndex = 0

            'Carrega_Dados_Item(Me.cbItem.SelectedValue)

            If Me.cbItem.Items.Count = 2 Then
                Me.cbItem.SelectedIndex = 1

                Carrega_Dados_Item(Me.cbItem.SelectedValue)

            Else
                Me.cbItem.SelectedIndex = 0
            End If
        Else

            Me.cbItem.DataSource = Nothing
            Me.cbItem.Items.Insert(0, "--Item--")
            Me.cbItem.SelectedIndex = 0

        End If

    End Sub

    Protected Sub cbItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbItem.SelectedIndexChanged
        If Me.cbItem.SelectedIndex >= 0 Then
            Carrega_Dados_Item(Me.cbItem.SelectedValue)
        End If
    End Sub




    Protected Sub txtConteiner_TextChanged(sender As Object, e As EventArgs) Handles txtConteiner.TextChanged

    End Sub

    Protected Sub cbArm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbArm.SelectedIndexChanged
        'Carrega_Yard(Val(cbArm.SelectedValue))
        Seta_Ocupacao(Val(cbArm.SelectedValue))
        Me.txtCargaNoLocal.Text = ""
        Me.txtlocalpos.Focus()
    End Sub
    Protected Sub Carrega_Yard(AutonumArm As Long)
        Me.cbLocalPOS.DataTextField = "DISPLAY"
        Me.cbLocalPOS.DataValueField = "AUTONUM"

        Me.cbLocalPOS.DataSource = InventarioCS_f2.ConsultarYard(AutonumArm)
        Me.cbLocalPOS.DataBind()

        Me.cbLocalPOS.Items.Insert(0, "--Posicao--")
        Me.cbLocalPOS.SelectedIndex = 0
    End Sub
    Protected Sub Mostra_Carga_No_Local(Id_Armazem As Long, Local As String)

        Dim Sql As String
        Sql = "SELECT ' LOTE: ' || LOTE_STR || ' ' || QTDE || ' ' || EMBALAGEM AS DISPLAY FROM OPERADOR.VW_INVENT_ARMAZEM_ITEM WHERE AUTONUM_ARMAZEM=" & Id_Armazem & " And Posicao='" & Local & "'"

        Dim Rst As New ADODB.Recordset

        Try
            Rst.Open(Sql, BD.Conexao, 3, 3)
        Catch ex As Exception
            GravaLog(ex.Message.ToString() & " " & Sql)
        End Try

        If Not Rst.EOF Then
            Me.txtCargaNoLocal.Text = Rst.Fields("DISPLAY").Value.ToString
        Else
            Me.txtCargaNoLocal.Text = ""
        End If
        Rst.Close()


    End Sub

    Private Sub Seta_Ocupacao(AutonumArm As Long)

        Dim Rst As New ADODB.Recordset
        Dim Sql$

        Sql = "SELECT NVL(FLAG_CT,0) AS FLAG_CT,NVL(OCUPACAO_CT,0) AS OCUPACAO_CT FROM SGIPA.TB_ARMAZENS_IPA WHERE AUTONUM=" & AutonumArm


        Try
            Rst.Open(Sql, BD.Conexao, 3, 3)
        Catch ex As Exception
            GravaLog(ex.Message.ToString() & " " & Sql)
        End Try

        If Not Rst.EOF Then
            If Rst.Fields("FLAG_CT").Value = 1 Then
                Me.cbOcupacao_CT.Visible = True
                Me.cbOcupacao_CT.SelectedValue = Rst.Fields("OCUPACAO_CT").Value
            Else
                Me.cbOcupacao_CT.SelectedValue = 0
                Me.cbOcupacao_CT.Visible = False
            End If
        Else
            Me.cbOcupacao_CT.SelectedValue = 0
            Me.cbOcupacao_CT.Visible = False
        End If

    End Sub

    Protected Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click
        btSalvar.Enabled = False


        If Validar() Then

            Dim Sql As String
            Dim SqlF As String

            Dim Sql2 As String
            Dim SqlF2 As String

            Dim AutonumCs As Long
            Dim AutonumCY As Long

            Dim RI As String
            RI = Microsoft.VisualBasic.Mid(Me.cbItem.SelectedValue, 1, 1)

            Dim UV As String
            UV = Microsoft.VisualBasic.Mid(Me.cbItem.SelectedValue, 2, 1)

            Dim Tipo As String
            Tipo = Microsoft.VisualBasic.Mid(Me.cbItem.SelectedValue, 3, 1)

            Dim QtdeM As Integer = 0
            Dim RstV As New ADODB.Recordset
            Dim id_Gravacao As String
            id_Gravacao = Mid(Me.cbItem.SelectedValue, 3)
            If UV = "U" Then
                Sql = "Select 0 as qtde, '" & id_Gravacao & "' AS ID_GRAVACAO from dual"
            Else
                Sql = "Select b.id_gravacao,b.qtde from operador.vw_invent_armazem_item a inner join operador.vw_invent_armazem_item b "
                Sql = Sql & " on a.lote_str=b.lote_str and a.sistema=b.sistema "
                Sql = Sql & " and a.EMBALAGEM = b.embalagem and a.MARCANTE=b.marcante"
                Sql = Sql & " and a.DESCR_ARMAZEM=b.descr_armazem"
                Sql = Sql & " and a.POSICAO=b.posicao where "
                Sql = Sql & " a.id_gravacao='" & id_Gravacao & "'"
                Sql = Sql & " and a.qtde=1 "
                Sql = Sql & " order by a.id_gravacao"
            End If

            RstV.Open(Sql, BD.Conexao, 3, 3)

            Do While Not RstV.EOF

                If QtdeM < Val(Me.txtQtdePos.Text) Then


                    If Tipo = "C" Then
                        AutonumCs = Val(Mid(RstV.Fields("ID_GRAVACAO").Value, 2))
                    ElseIf Tipo = "Y" Then
                        AutonumCY = Val(Mid(RstV.Fields("ID_GRAVACAO").Value, 2))

                        If Me.txtSISTEMA.Text <> "RDX" Then
                            Sql = "SELECT AUTONUM_CS FROM SGIPA.TB_CARGA_SOLTA_YARD WHERE AUTONUM={0}"
                            SqlF = String.Format(Sql, AutonumCY)
                        Else
                            Sql = "SELECT AUTONUM_PATIOCS AS AUTONUM_CS FROM REDEX.TB_CARGA_SOLTA_YARD WHERE AUTONUM={0}"
                            SqlF = String.Format(Sql, AutonumCY)
                        End If


                        Dim Rst As New ADODB.Recordset

                        Try
                            Rst.Open(SqlF, BD.Conexao, 3, 3)
                        Catch ex As Exception
                            GravaLog(ex.Message.ToString() & " " & SqlF)
                        End Try

                        If Not Rst.EOF Then
                            AutonumCs = Rst.Fields("AUTONUM_CS").Value
                        End If
                        Rst.Close()



                    End If

                    Dim MensPatio As String
                    MensPatio = InventarioCS_f2.ValidaRegrasArmazem(AutonumCs, Me.txtYard.Text.ToUpper, Me.cbArm.SelectedValue)
                    If MensPatio <> "OK" Then
                        MensPatio = "Conflito com Regra de Armazem :" & MensPatio
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" & MensPatio & "');</script>", False)
                        Exit Sub
                    End If

                    If Valida_Quantidade(AutonumCs, Val(Me.txtQtdePos.Text)) = False Then
                        Exit Sub
                    End If

                    If Me.txtSISTEMA.Text <> "RDX" Then
                        If Me.txtlocalpos.Text <> "" Then
                            Sql = "SELECT AUTONUM FROM SGIPA.TB_CARGA_SOLTA_YARD WHERE AUTONUM_CS={0} "
                            Sql = Sql & " AND ARMAZEM={1} AND YARD='{2}' "
                            SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper)
                        Else
                            Sql = "SELECT AUTONUM FROM SGIPA.TB_CARGA_SOLTA_YARD WHERE AUTONUM_CS={0} "
                            Sql = Sql & " AND ARMAZEM={1} "
                            SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue)
                        End If
                    Else
                        If Me.txtlocalpos.Text <> "" Then
                            Sql = "SELECT AUTONUM FROM REDEX.TB_CARGA_SOLTA_YARD WHERE AUTONUM_PATIOCS={0} "
                            Sql = Sql & " AND ARMAZEM={1} AND YARD='{2}' "
                            SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper)
                        Else
                            Sql = "SELECT AUTONUM FROM REDEX.TB_CARGA_SOLTA_YARD WHERE AUTONUM_PATIOCS={0} "
                            Sql = Sql & " AND ARMAZEM={1} "
                            SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue)
                        End If
                    End If

                    Dim Rst5 As New ADODB.Recordset

                    Try
                        Rst5.Open(SqlF, BD.Conexao, 3, 3)
                    Catch ex As Exception
                        GravaLog(ex.Message.ToString() & " " & SqlF)
                    End Try

                    If Rst5.EOF Then
                        If Val(Me.txtQtdePos.Text) > 0 Then
                            If Me.txtlocalpos.Text <> "" And Val(Me.txtQtdePos.Text) > 0 Then
                                If Me.txtSISTEMA.Text <> "RDX" Then
                                    Sql = "INSERT INTO SGIPA.TB_CARGA_SOLTA_YARD (AUTONUM,AUTONUM_CS,ARMAZEM,YARD,ORIGEM,QUANTIDADE) VALUES "
                                    Sql = Sql & "(SGIPA.SEQ_CARGA_SOLTA_YARD.NEXTVAL,{0},{1},'{2}','I',{3})"
                                    SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper, Val(Me.txtQtdePos.Text))
                                Else
                                    Sql = "INSERT INTO REDEX.TB_CARGA_SOLTA_YARD (AUTONUM,AUTONUM_PATIOCS,ARMAZEM,YARD,QUANTIDADE) VALUES "
                                    Sql = Sql & "(REDEX.SEQ_CARGA_SOLTA_YARD.NEXTVAL,{0},{1},'{2}',{3})"

                                    If UV = "U" Then
                                        SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper, Val(Me.txtQtdePos.Text))
                                    Else
                                        SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper, RstV.Fields("QTDE").Value)

                                    End If

                                End If

                            Else
                                If Me.txtSISTEMA.Text <> "RDX" Then
                                    Sql = "INSERT INTO SGIPA.TB_CARGA_SOLTA_YARD (AUTONUM,AUTONUM_CS,ARMAZEM,ORIGEM,QUANTIDADE) VALUES "
                                    Sql = Sql & "(SGIPA.SEQ_CARGA_SOLTA_YARD.NEXTVAL,{0},{1},'I',{2})"
                                    SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Val(Me.txtQtdePos.Text))
                                Else
                                    Sql = "INSERT INTO REDEX.TB_CARGA_SOLTA_YARD (AUTONUM,AUTONUM_PATIOCS,ARMAZEM,QUANTIDADE) VALUES "
                                    Sql = Sql & "(REDEX.SEQ_CARGA_SOLTA_YARD.NEXTVAL,{0},{1},{2})"
                                    If UV = "U" Then
                                        SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Val(Me.txtQtdePos.Text))
                                    Else
                                        SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, RstV.Fields("QTDE").Value)
                                    End If

                                End If
                            End If
                        End If
                    Else

                        If Val(Me.txtQtdePos.Text) > 0 Then
                            If Me.txtSISTEMA.Text <> "RDX" Then
                                Sql = "UPDATE SGIPA.TB_CARGA_SOLTA_YARD SET QUANTIDADE=QUANTIDADE + {0} "
                                Sql = Sql & " WHERE AUTONUM={1}"
                                SqlF = String.Format(Sql, Val(Me.txtQtdePos.Text), Rst5.Fields("AUTONUM").Value)
                            Else
                                Sql = "UPDATE REDEX.TB_CARGA_SOLTA_YARD SET QUANTIDADE=QUANTIDADE + {0} "
                                Sql = Sql & " WHERE AUTONUM={1}"

                                If UV = "U" Then
                                    SqlF = String.Format(Sql, Val(Me.txtQtdePos.Text), Rst5.Fields("AUTONUM").Value)
                                Else
                                    SqlF = String.Format(Sql, RstV.Fields("QTDE").Value, Rst5.Fields("AUTONUM").Value)
                                End If

                            End If
                        End If
                    End If


                    Rst5.Close()

                    Sql2 = ""
                    SqlF2 = ""

                    If Tipo = "Y" And Me.txtSISTEMA.Text <> "RDX" Then
                        Sql2 = "UPDATE SGIPA.TB_CARGA_SOLTA_YARD SET QUANTIDADE=QUANTIDADE-{0} WHERE AUTONUM={1} AND QUANTIDADE>={2}"
                        SqlF2 = String.Format(Sql2, Val(Me.txtQtdePos.Text), AutonumCY, Val(Me.txtQtdePos.Text))
                    End If
                    If Tipo = "Y" And Me.txtSISTEMA.Text = "RDX" Then
                        Sql2 = "UPDATE REDEX.TB_CARGA_SOLTA_YARD SET QUANTIDADE=QUANTIDADE-{0} WHERE AUTONUM={1} AND QUANTIDADE>={2}"
                        If UV = "U" Then
                            SqlF2 = String.Format(Sql2, Val(Me.txtQtdePos.Text), AutonumCY, Val(Me.txtQtdePos.Text))
                        Else
                            SqlF2 = String.Format(Sql2, RstV.Fields("QTDE").Value, AutonumCY, 0)
                        End If
                    End If

                    Dim Sql3 As String

                    Sql3 = ""
                    If Me.cbOcupacao_CT.Visible = True Then
                        Sql3 = "UPDATE SGIPA.TB_ARMAZENS_IPA SET OCUPACAO_CT=" & Me.cbOcupacao_CT.SelectedValue & " WHERE AUTONUM=" & Me.cbArm.SelectedValue
                    End If


                    Dim AutonumHS As Long
                    Dim tbHS As New ADODB.Recordset
                    If Me.txtSISTEMA.Text <> "RDX" Then
                        tbHS.Open("Select SGIPA.SEQ_HIST_SHIFTING_CS.NEXTVAL As QUAL FROM DUAL", BD.Conexao, 3, 3)
                    Else
                        tbHS.Open("Select REDEX.SEQ_HIST_SHIFTING_CS.NEXTVAL As QUAL FROM DUAL", BD.Conexao, 3, 3)
                    End If

                    AutonumHS = tbHS.Fields("QUAL").Value


                    Dim SqlHist As String
                    Dim SqlHist2 As String

                    SqlHist = ""
                    If Me.txtSISTEMA.Text <> "RDX" Then
                        SqlHist = SqlHist & "INSERT INTO SGIPA.TB_HIST_SHIFTING_CS (AUTONUM,"
                    Else
                        SqlHist = SqlHist & "INSERT INTO REDEX.TB_HIST_SHIFTING_CS (AUTONUM,"
                    End If
                    SqlHist = SqlHist & "MARCANTE,"
                    SqlHist = SqlHist & "ARMAZEM,"
                    SqlHist = SqlHist & "YARD,"
                    SqlHist = SqlHist & "DT_MOV,"
                    SqlHist = SqlHist & "USUARIO,"
                    SqlHist = SqlHist & "ORIGEM,"
                    SqlHist = SqlHist & "LOTE,"
                    SqlHist = SqlHist & "MOTIVO"
                    SqlHist = SqlHist & ") VALUES (" & AutonumHS & ","
                    SqlHist = SqlHist & "0,"
                    SqlHist = SqlHist & Me.cbArm.SelectedValue & ","
                    SqlHist = SqlHist & "'" & Me.txtlocalpos.Text.ToUpper & "',"
                    SqlHist = SqlHist & "SYSDATE,"
                    SqlHist = SqlHist & Session("AUTONUMUSUARIO") & ","
                    SqlHist = SqlHist & "'" & Me.txtYard.Text & "',"
                    SqlHist = SqlHist & "'" & Me.txtLote.Text & "',"
                    SqlHist = SqlHist & Me.cbMotivoPos.SelectedValue
                    SqlHist = SqlHist & ")"

                    If Me.txtSISTEMA.Text <> "RDX" Then
                        SqlHist2 = "INSERT INTO SGIPA.TB_HIST_SHIFTING_CS_COL (AUTONUMHS,USUARIO,DT,BROWSER_NAME,BROWSER_VERSION,MOBILEDEVICEMODEL,MOBILEDEVICEMANUFACTURER,FLAG_MOBILE) VALUES ("
                    Else
                        SqlHist2 = "INSERT INTO REDEX.TB_HIST_SHIFTING_CS_COL (AUTONUMHS,USUARIO,DT,BROWSER_NAME,BROWSER_VERSION,MOBILEDEVICEMODEL,MOBILEDEVICEMANUFACTURER,FLAG_MOBILE) VALUES ("
                    End If
                    SqlHist2 = SqlHist2 & AutonumHS & ","
                    SqlHist2 = SqlHist2 & Session("AUTONUMUSUARIO") & ","
                    SqlHist2 = SqlHist2 & "SYSDATE,"
                    SqlHist2 = SqlHist2 & "'" & Session("BROWSER_NAME") & "',"
                    SqlHist2 = SqlHist2 & "'" & Session("BROWSER_VERSION") & "',"
                    SqlHist2 = SqlHist2 & "'" & Session("MOBILEDEVICEMODEL") & "',"
                    SqlHist2 = SqlHist2 & "'" & Session("MOBILEDEVICEMANUFACTURER") & "',"
                    SqlHist2 = SqlHist2 & IIf(Session("ISMOBILEDEVICE") = False, 0, 1)
                    SqlHist2 = SqlHist2 & ") "


                    Try
                            'BD.Conexao.BeginTrans()

                            Try
                                BD.Conexao.Execute(SqlF.ToString(), BD.LinhasAfetadas)
                            Catch ex As Exception
                                GravaLog(ex.Message.ToString() & " " & SqlF)
                            End Try

                            If Sql2 <> String.Empty Then
                                Try
                                    BD.Conexao.Execute(SqlF2.ToString(), BD.LinhasAfetadas)
                                Catch ex As Exception
                                    GravaLog(ex.Message.ToString() & " " & SqlF2)
                                End Try
                            End If

                            If Sql3 <> String.Empty Then
                                Try
                                    BD.Conexao.Execute(Sql3.ToString(), BD.LinhasAfetadas)
                                Catch ex As Exception
                                    GravaLog(ex.Message.ToString() & " " & Sql3)
                                End Try
                            End If

                        If SqlHist <> String.Empty Then
                            Try
                                BD.Conexao.Execute(SqlHist.ToString(), BD.LinhasAfetadas)
                            Catch ex As Exception
                                GravaLog(ex.Message.ToString() & " " & SqlHist)
                            End Try
                        End If

                        If SqlHist2 <> String.Empty Then
                            Try
                                BD.Conexao.Execute(SqlHist2.ToString(), BD.LinhasAfetadas)
                            Catch ex As Exception
                                GravaLog(ex.Message.ToString() & " " & SqlHist2)
                            End Try
                        End If

                        'BD.Conexao.CommitTrans()



                    Catch ex As Exception
                            Throw New Exception("Erro. Tente novamente." & ex.Message())
                            BD.Conexao.RollbackTrans()
                            btSalvar.Enabled = True
                        End Try

                        QtdeM = QtdeM + RstV.Fields("QTDE").Value

                    End If

                    RstV.MoveNext()

            Loop

            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro Inserido!');</script>", False)

            Limpa()

            Me.txtLote.Text = ""

            btSalvar.Enabled = True


        End If


        btSalvar.Enabled = True

    End Sub

    Private Function Valida_Quantidade(ByVal Autonumcs As Long, ByVal Quant As Double) As Boolean

        'Dim Rst As New ADODB.Recordset
        'Dim Sql As String

        'Dim quant_alocada As String = "0"
        'Dim quant_estoque As String = "0"

        '        Sql = "SELECT NVL(sum(quantidade),0) quant_alocada FROM SGIPA.TB_CARGA_SOLTA_YARD WHERE AUTONUM_CS={0} "
        '       Sql = String.Format(Sql, Autonumcs)

        'Try
        'Rst.Open(Sql, BD.Conexao, 3, 3)
        'Catch ex As Exception
        'GravaLog(ex.Message.ToString() & " " & Sql)
        'End Try

        'If Not Rst.EOF Then
        'quant_alocada = Rst.Fields("quant_alocada").Value.ToString()
        'End If

        'Rst.Close()

        'Sql = "SELECT (quantidade_real-quantidade_saida) quant_estoque FROM SGIPA.TB_CARGA_SOLTA WHERE AUTONUM={0} "
        'Sql = String.Format(Sql, Autonumcs)

        'Try
        'Rst.Open(Sql, BD.Conexao, 3, 3)
        'Catch ex As Exception
        'GravaLog(ex.Message.ToString() & " " & Sql)
        'End Try

        'If Not Rst.EOF Then
        'quant_estoque = Rst.Fields("quant_estoque").Value.ToString()
        'End If

        'Rst.Close()

        ' If (quant_alocada + Quant) > quant_estoque And (quant_alocada <> Quant) Then
        ' ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Item não informado.');</script>", False)
        'Return False
        'Else
        Return True
        'End If

    End Function

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

    Private Function Validar() As Boolean

        If Me.txtLote.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Lote não informado.');</script>", False)
            Return False
        End If

        If Me.cbItem.Text = String.Empty Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Item não informado.');</script>", False)
            Return False
        End If

        If Me.txtQtdePos.Text = String.Empty Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade não informada.');</script>", False)
            Return False
        End If

        If Val(Me.txtQtdePos.Text) > Val(Me.txtQtde.Text) Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade indisponível.');</script>", False)
            Return False
        End If

        If Val(Me.txtQtdePos.Text) = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade não informada.');</script>", False)
            Return False
        End If

        If Val(Me.txtQtdePos.Text) < 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade inválida.');</script>", False)
            Return False
        End If

        If Me.cbArm.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Armazem não informado.');</script>", False)
            Return False
        End If

        If Me.cbMotivoPos.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Motivo não informado.');</script>", False)
            Return False
        End If

        Dim Rst As New ADODB.Recordset
        Dim Rst2 As New ADODB.Recordset
        Dim Sql As String
        Dim SqlF As String

        If BD.BancoEmUso = "ORACLE" Then

            Sql = "SELECT "
            Sql = Sql & " NVL(FLAG_CT,0) AS FLAG_CT"
            Sql = Sql & " FROM SGIPA.TB_ARMAZENS_IPA "
            Sql = Sql & " WHERE AUTONUM='{0}'"

            SqlF = String.Format(Sql, Me.cbArm.SelectedValue)

            Try
                Rst.Open(SqlF, BD.Conexao, 3, 3)
            Catch ex As Exception
                GravaLog(ex.Message.ToString() & " " & SqlF)
            End Try            

            If Not Rst.EOF Then
                If Rst.Fields("FLAG_CT").Value = 1 Then
                    If Me.txtlocalpos.Text <> String.Empty And Me.txtlocalpos.Text <> "" Then
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Armazem CT não informe posição.');</script>", False)
                        Return False
                    End If

                Else
                    If Me.txtlocalpos.Text = String.Empty Then
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Posicao não informada.');</script>", False)
                        Return False
                    Else

                        Sql = "SELECT "
                        Sql = Sql & " AUTONUM, FLAG_BLOQUEIO "
                        Sql = Sql & " FROM SGIPA.TB_YARD_CS "
                        Sql = Sql & " WHERE ARMAZEM='{0}' AND UPPER(YARD)='{1}'"
                        Sql = Sql & " AND YARD NOT IN ('CAM','CANCC','GOUT') "
                        SqlF = String.Format(Sql, Me.cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper)

                        Try
                            Rst2.Open(SqlF, BD.Conexao, 3, 3)
                        Catch ex As Exception
                            GravaLog(ex.Message.ToString() & " " & SqlF)
                        End Try

                        If Rst2.EOF Then
                            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Posicao inválida.');</script>", False)
                            Return False
                        Else
                            If Rst2.Fields("FLAG_BLOQUEIO").Value.ToString = "1" Then
                                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Posicao Bloqueada.');</script>", False)
                                Return False
                            End If
                        End If
                        Rst2.Close()
                    End If
                End If
            End If
            Rst.Close()

        End If




        Return True

    End Function

    Protected Sub txtQtdePos_TextChanged(sender As Object, e As EventArgs) Handles txtQtdePos.TextChanged
        cbArm.Focus()
    End Sub



    Protected Sub txtEntrada_TextChanged(sender As Object, e As EventArgs) Handles txtEntrada.TextChanged

    End Sub

    Protected Sub txtMOV_TextChanged(sender As Object, e As EventArgs) Handles txtMOV.TextChanged

    End Sub

    Protected Sub cbLocalPOS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLocalPOS.SelectedIndexChanged
        '        Mostra_Carga_No_Local(cbArm.SelectedValue, cbLocalPOS.SelectedValue)
    End Sub

    Protected Sub btSalvar0_Click(sender As Object, e As EventArgs) Handles btSalvar0.Click
        '        btSalvar0.Enabled = False

        If Validar() Then



            Dim Sql As String
            Dim SqlF As String

            Dim Sql2 As String
            Dim SqlF2 As String

            Dim AutonumCs As Long
            Dim AutonumCY As Long

            Dim Tipo As String
            Tipo = Microsoft.VisualBasic.Mid(Me.cbItem.SelectedValue, 3, 1)

            If Tipo = "C" Then
                AutonumCs = Val(Microsoft.VisualBasic.Mid(Me.cbItem.SelectedValue, 4))
            ElseIf Tipo = "Y" Then
                AutonumCY = Val(Microsoft.VisualBasic.Mid(Me.cbItem.SelectedValue, 4))

                If Me.txtSISTEMA.Text <> "RDX" Then
                    Sql = "SELECT AUTONUM_CS FROM SGIPA.TB_CARGA_SOLTA_YARD WHERE AUTONUM={0}"
                    SqlF = String.Format(Sql, AutonumCY)
                Else
                    Sql = "SELECT AUTONUM_PATIOCS AS AUTONUM_CS FROM REDEX.TB_CARGA_SOLTA_YARD WHERE AUTONUM={0}"
                    SqlF = String.Format(Sql, AutonumCY)
                End If


                Dim Rst As New ADODB.Recordset

                Try
                    Rst.Open(SqlF, BD.Conexao, 3, 3)
                Catch ex As Exception
                    GravaLog(ex.Message.ToString() & " " & SqlF)
                End Try

                If Not Rst.EOF Then
                    AutonumCs = Rst.Fields("AUTONUM_CS").Value
                End If
                Rst.Close()
            End If

            Dim nIndItem As String
            nIndItem = 1


            Try
                If Val(Me.txtQtdePos.Text) > 0 Then

                    If Me.txtSISTEMA.Text <> "RDX" Then
                        Sql = "SELECT AUTONUM FROM SGIPA.TB_CARGA_SOLTA_YARD WHERE AUTONUM_CS={0} "
                        Sql = Sql & " AND ARMAZEM={1} AND YARD='{2}' "
                        SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper)
                    Else
                        Sql = "SELECT AUTONUM FROM REDEX.TB_CARGA_SOLTA_YARD WHERE AUTONUM_PATIOCS={0} "
                        Sql = Sql & " AND ARMAZEM={1} AND YARD='{2}' "
                        SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper)
                    End If

                    Dim Rst5 As New ADODB.Recordset

                    Try
                        Rst5.Open(SqlF, BD.Conexao, 3, 3)
                    Catch ex As Exception
                        GravaLog(ex.Message.ToString() & " " & SqlF)
                    End Try

                    If Rst5.EOF Then
                        If Me.txtSISTEMA.Text <> "RDX" Then
                            Sql = "INSERT INTO SGIPA.TB_CARGA_SOLTA_YARD (AUTONUM,AUTONUM_CS,ARMAZEM,YARD,ORIGEM,QUANTIDADE) VALUES "
                            Sql = Sql & "(SGIPA.SEQ_CARGA_SOLTA_YARD.NEXTVAL,{0},{1},'{2}','I',{3})"
                            SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper, Val(Me.txtQtdePos.Text))
                        Else
                            Sql = "INSERT INTO REDEX.TB_CARGA_SOLTA_YARD (AUTONUM,AUTONUM_PATIOCS,ARMAZEM,YARD,QUANTIDADE) VALUES "
                            Sql = Sql & "(REDEX.SEQ_CARGA_SOLTA_YARD.NEXTVAL,{0},{1},'{2}',{3})"
                            SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper, Val(Me.txtQtdePos.Text))
                        End If
                    Else
                        If Me.txtSISTEMA.Text <> "RDX" Then
                            Sql = "UPDATE SGIPA.TB_CARGA_SOLTA_YARD SET QUANTIDADE=QUANTIDADE + {0} "
                            Sql = Sql & " WHERE AUTONUM={1}"
                            SqlF = String.Format(Sql, Val(Me.txtQtdePos.Text), Rst5.Fields("AUTONUM").Value)
                        Else
                            Sql = "UPDATE REDEX.TB_CARGA_SOLTA_YARD SET QUANTIDADE=QUANTIDADE + {0} "
                            Sql = Sql & " WHERE AUTONUM={1}"
                            SqlF = String.Format(Sql, Val(Me.txtQtdePos.Text), Rst5.Fields("AUTONUM").Value)
                        End If

                    End If
                    Rst5.Close()

                    Sql2 = ""
                    SqlF2 = ""

                    If Tipo = "Y" Then
                        If Me.txtSISTEMA.Text <> "RDX" Then
                            Sql2 = "UPDATE SGIPA.TB_CARGA_SOLTA_YARD SET QUANTIDADE=QUANTIDADE-{0} WHERE AUTONUM={1}"
                            SqlF2 = String.Format(Sql2, Val(Me.txtQtdePos.Text), AutonumCY)
                        Else
                            Sql2 = "UPDATE REDEX.TB_CARGA_SOLTA_YARD SET QUANTIDADE=QUANTIDADE-{0} WHERE AUTONUM={1}"
                            SqlF2 = String.Format(Sql2, Val(Me.txtQtdePos.Text), AutonumCY)
                        End If

                    End If


                    'BD.Conexao.BeginTrans()

                    Try
                        BD.Conexao.Execute(SqlF.ToString(), BD.LinhasAfetadas)
                    Catch ex As Exception
                        GravaLog(ex.Message.ToString() & " " & SqlF)
                    End Try

                    If Sql2 <> String.Empty Then
                        Try
                            BD.Conexao.Execute(SqlF2.ToString(), BD.LinhasAfetadas)
                        Catch ex As Exception
                            GravaLog(ex.Message.ToString() & " " & SqlF2)
                        End Try
                    End If

                    'BD.Conexao.CommitTrans()

                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro Inserido!');</script>", False)

                    nIndItem = cbItem.Text
                End If

                Limpa()



            Catch ex As Exception
                Throw New Exception("Erro. Tente novamente." & ex.Message())
                'btSalvar0.Enabled = True
            End Try

            Carrega_Dados_Lote(Me.txtLote.Text)

            Try
                Me.cbItem.Text = nIndItem
                Carrega_Dados_Item(Me.cbItem.SelectedValue)
                'btSalvar0.Enabled = True
            Catch ex As Exception
                Me.cbItem.SelectedIndex = -1
                'btSalvar0.Enabled = True
            End Try



        End If

        'btSalvar0.Enabled = True

    End Sub

    Private Sub txtlocalpos_TextChanged(sender As Object, e As System.EventArgs) Handles txtlocalpos.TextChanged
        'Mostra_Carga_No_Local(Val(cbArm.SelectedValue), Me.txtlocalpos.Text.ToUpper)
        Dim Sql As String

        If Me.txtlocalpos.Text.Trim = "SAIDA" Or Me.txtlocalpos.Text.Trim = "TREM" Or Me.txtlocalpos.Text.Trim = "ENTREGA" Then
            Me.cbMotivoPos.SelectedValue = 8
            Exit Sub
        End If

        If Me.txtlocalpos.Text.Trim = "BAL" Then
            Me.cbMotivoPos.SelectedValue = 6
            Exit Sub
        End If

        If Len(Me.txtlocalpos.Text) = 3 Then
            If Me.cbArm.SelectedIndex = 0 Then

                Sql = "SELECT ARMAZEM FROM SGIPA.TB_YARD_CS WHERE YARD='" & Me.txtlocalpos.Text & "'"
                Dim tBa As New ADODB.Recordset
                tBa.Open(Sql, BD.Conexao, 1, 1)
                If Not tBa.EOF Then
                    Me.cbArm.SelectedValue = tBa.Fields("ARMAZEM").Value
                    Exit Sub
                End If
            End If
        End If



        Sql = "SELECT 1 FROM SGIPA.TB_YARD_CS WHERE "
        Sql = Sql & " YARD='" & Me.txtlocalpos.Text & "'"
        Sql = Sql & " AND VALIDA=0  "
        Dim tBm As New ADODB.Recordset
        tBm.Open(Sql, BD.Conexao, 1, 1)
        If Not tBm.EOF Then
            Me.cbMotivoPos.SelectedValue = 33
            Exit Sub
        End If
        tBm.Close()


        If Me.txtYard.Text.Trim = "-" And Me.txtlocalpos.Text <> "" Then
            Me.cbMotivoPos.SelectedValue = 12
            Exit Sub
        End If

        If Me.txtlocalpos.Text.Trim <> "" And Me.txtlocalpos.Text.Trim <> "" Then
            Me.cbMotivoPos.SelectedValue = 1
            Exit Sub
        End If


        btSalvar.Focus()

    End Sub

    Protected Sub cbMotivoPos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMotivoPos.SelectedIndexChanged

    End Sub

    Protected Sub txtLote_TextChanged(sender As Object, e As EventArgs) Handles txtLote.TextChanged

        Me.txtLote.Text = Me.txtLote.Text.Replace(" ", "/")
        Filtra()


    End Sub
End Class