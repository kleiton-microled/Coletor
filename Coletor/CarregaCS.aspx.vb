Imports System.Data.OleDb

Public Class CarregaCS
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
            CarregarVeiculos()


            Me.txtMarcante.Enabled = True
            Me.txtLote.Enabled = False
            Me.txtQtde.Enabled = False


            Me.cbVeiculo.Focus()

            If Session("LARGURATELA") < 500 Then
                Me.GridCarregamento.PageSize = 3
                Me.GridOC.PageSize = 3
            Else
                Me.GridCarregamento.PageSize = 5
                Me.GridOC.PageSize = 5
            End If

        End If

    End Sub

    Protected Sub Limpa()
        Me.txtLote.Text = ""
        Me.txtQtde.Text = ""
        Me.txtAutonumCS.Text = ""
        Me.txtLocal.Text = ""
        Me.txtAutonumArmazem.Text = "0"
        Me.txtAutonum_cs_Yard.Text = "0"

    End Sub


    Protected Sub CarregarVeiculos()




        Me.cbVeiculo.DataTextField = "DISPLAY"
        Me.cbVeiculo.DataValueField = "DISPLAY"

        Dim tb1 As New ADODB.Recordset
        Dim Sql As String = String.Empty

        Sql = "Select  "
        Sql = Sql & " CASE MIN(NVL(DT_CARREGAMENTO,SYSDATE-365)) WHEN SYSDATE-365 THEN '( )' ELSE '(x)' END || MAX(NVL(PLACA_C,'')) || ' ' || MAX(NVL(PLACA_CARRETA, '')) || ' '|| MAX(NVL(MODELO,'')) AS DISPLAY "
        Sql = Sql & " From SGIPA.VW_COL_CAM_CARREGAMENTO "
        Sql = Sql & " WHERE PATIO=" & Session("AUTONUMPATIO")
        Sql = Sql & " GROUP BY PLACA_C, PLACA_CARRETA"
        Sql = Sql & " ORDER BY 1 "

        tb1.Open(Sql, BD.Conexao, 1, 1)

        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, tb1, "VIEW_VEIC")

            Me.cbVeiculo.DataSource = Ds.Tables(0)
            Me.cbVeiculo.DataBind()
        End Using

        Me.cbVeiculo.Items.Insert(0, "--Selecione uma Veic.--")
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

    Protected Sub cbVeiculo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbVeiculo.SelectedIndexChanged
        If Me.cbVeiculo.SelectedIndex > 0 Then
            Carrega_LvOrdem()
            Carrega_LvCarregamento()
            Limpa()
            Me.txtMarcante.Text = ""
            Me.txtMarcante.Focus()




        End If
    End Sub

    Protected Sub GridEstufados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridOC.SelectedIndexChanged

    End Sub

    Protected Sub Carrega_LvOrdem()



        Dim tb1 As New ADODB.Recordset
        Dim Sql As String = String.Empty

        Sql = "Select "
        Sql = Sql & " A.PLACA_C,"
        Sql = Sql & " A.PLACA_CARRETA,"
        Sql = Sql & " A.MODELO,"
        Sql = Sql & " A.ORDEM_CARREG,"
        Sql = Sql & " A.NUM_OC,"
        Sql = Sql & " A.QUANTIDADE,"
        Sql = Sql & " A.AUTONUMCS,"
        Sql = Sql & " A.LOTE,"
        Sql = Sql & " A.ITEM,"
        Sql = Sql & " A.EMBALAGEM, NVL(B.QTDE_CARREGADA,0) As QTDE_CARREGADA from SGIPA.VW_COL_CAM_CARREGAMENTO A LEFT JOIN ("
        Sql = Sql & " Select  SUM(volumes) As QTDE_CARREGADA, AUTONUM_CARGA As AUTONUMCS "
        Sql = Sql & " from sgipa.tb_marcantes M INNER JOIN SGIPA.TB_CARGA_SOLTA_YARD Y On M.AUTONUM_CS_YARD=Y.AUTONUM "
        Sql = Sql & " WHERE "
        Sql = Sql & " M.VOLUMES>0 And Y.YARD='CAM' AND (M.PLACA_C IS NULL OR M.PLACA_C='" & Microsoft.VisualBasic.Mid(Me.cbVeiculo.Text, 4, 8) & "') GROUP BY M.AUTONUM_CARGA "
        Sql = Sql & " ) B ON A.AUTONUMCS=B.AUTONUMCS "
        Sql = Sql & " WHERE A.PLACA_C='" & Microsoft.VisualBasic.Mid(Me.cbVeiculo.Text, 4, 8) & "'"
        Sql = Sql & " ORDER BY A.LOTE,A.ITEM "

        tb1.Open(Sql, BD.Conexao, 1, 1)

        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, tb1, "VIEW_CNTR")

            Me.GridOC.DataSource = Ds.Tables(0)
            Me.GridOC.DataBind()



        End Using



    End Sub


    Protected Sub Carrega_LvCarregamento()
        Dim tb1 As New ADODB.Recordset
        Dim Sql As String = String.Empty


        Sql = "SELECT "
        Sql = Sql & " LPAD (TRIM (TO_CHAR (NVL (m.autonum, 0))), 12, 0) AS MARCANTE,"
        Sql = Sql & " M.VOLUMES AS QUANTIDADE, "
        Sql = Sql & " C.BL "
        Sql = Sql & " from SGIPA.TB_MARCANTES M INNER JOIN SGIPA.TB_CARGA_SOLTA_YARD Y ON M.AUTONUM_CS_YARD=Y.AUTONUM "
        Sql = Sql & " INNER JOIN SGIPA.TB_CARGA_SOLTA C ON M.AUTONUM_CARGA=C.AUTONUM "
        Sql = Sql & " WHERE "
        Sql = Sql & " M.AUTONUM_CARGA IN (SELECT DISTINCT AUTONUMCS FROM SGIPA.VW_COL_CAM_CARREGAMENTO WHERE PLACA_C='" & Microsoft.VisualBasic.Mid(Me.cbVeiculo.Text, 4, 8) & "')"
        Sql = Sql & " AND (M.PLACA_C ='" & Microsoft.VisualBasic.Mid(Me.cbVeiculo.Text, 4, 8) & "')"
        Sql = Sql & " AND Y.YARD='CAM' ORDER BY C.BL, M.AUTONUM "



        tb1.Open(Sql, BD.Conexao, 1, 1)

        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, tb1, "VIEW_CNTR")

            Me.GridCarregamento.DataSource = Ds.Tables(0)
            Me.GridCarregamento.DataBind()



        End Using



    End Sub

    Protected Sub GridCarregamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridCarregamento.SelectedIndexChanged

    End Sub

    Protected Sub txtLote_TextChanged(sender As Object, e As EventArgs) Handles txtLote.TextChanged

    End Sub

    Protected Sub txtMarcante_TextChanged(sender As Object, e As EventArgs) Handles txtMarcante.TextChanged
        Dim Sql As String = String.Empty

        If Len(txtMarcante.Text) = 12 Then
            Carrega_Dados_Marcante()
            If Valida_Marcante() Then

                Dim AutonumCSYard As Long
                Sql = "SELECT SGIPA.SEQ_CARGA_SOLTA_YARD.NEXTVAL AS QUAL FROM DUAL"
                Dim TB1 As New ADODB.Recordset
                TB1.Open(Sql, BD.Conexao, 1, 1)
                AutonumCSYard = TB1.Fields("QUAL").Value

                Sql = "UPDATE SGIPA.TB_CARGA_SOLTA_YARD SET QUANTIDADE=0 WHERE AUTONUM=" & Me.txtAutonum_cs_Yard.Text
                BD.Conexao.Execute(Sql)

                Sql = "INSERT INTO SGIPA.TB_CARGA_SOLTA_YARD (AUTONUM,AUTONUM_CS,ARMAZEM,YARD,ORIGEM,QUANTIDADE,MOTIVO_COL) VALUES "
                Sql = Sql & "(" & AutonumCSYard & "," & Me.txtAutonumCS.Text & "," & Me.txtAutonumArmazem.Text & ",'CAM','I'," & Me.txtQtde.Text & ",8)"
                BD.Conexao.Execute(Sql)


                Sql = "UPDATE SGIPA.TB_MARCANTES SET AUTONUM_CS_YARD=" & AutonumCSYard & ",PLACA_C='" & Microsoft.VisualBasic.Mid(Me.cbVeiculo.Text, 4, 8) & "' WHERE AUTONUM=" & Val(Me.txtMarcante.Text)
                BD.Conexao.Execute(Sql)

                Dim SqlHist2 As String

                SqlHist2 = "INSERT INTO SGIPA.TB_CARREGAMENTO_COL (MARCANTE , USUARIO,DT,BROWSER_NAME,BROWSER_VERSION,MOBILEDEVICEMODEL,MOBILEDEVICEMANUFACTURER,FLAG_MOBILE) VALUES ("
                SqlHist2 = SqlHist2 & Val(Me.txtMarcante.Text) & ","
                SqlHist2 = SqlHist2 & Session("AUTONUMUSUARIO") & ","
                SqlHist2 = SqlHist2 & "SYSDATE,"
                SqlHist2 = SqlHist2 & "'" & Session("BROWSER_NAME") & "',"
                SqlHist2 = SqlHist2 & "'" & Session("BROWSER_VERSION") & "',"
                SqlHist2 = SqlHist2 & "'" & Session("MOBILEDEVICEMODEL") & "',"
                SqlHist2 = SqlHist2 & "'" & Session("MOBILEDEVICEMANUFACTURER") & "',"
                SqlHist2 = SqlHist2 & IIf(Session("ISMOBILEDEVICE") = False, 0, 1)
                SqlHist2 = SqlHist2 & ") "

                BD.Conexao.Execute(SqlHist2)


                Carrega_LvOrdem()
                Carrega_LvCarregamento()


                Limpa()
                Me.txtMarcante.Text = ""
                Me.txtMarcante.Focus()

            End If

        End If
    End Sub


    Protected Sub Carrega_Dados_Marcante()
        Dim Sql As String

        Limpa()


        Sql = " SELECT"
        Sql = Sql & " M.AUTONUM AS MARCANTE,"
        Sql = Sql & " S.AUTONUM AS AUTONUMCS,"
        Sql = Sql & " S.BL AS LOTE,"
        Sql = Sql & " S.ITEM,"
        Sql = Sql & " M.VOLUMES AS QUANTIDADE,"
        Sql = Sql & " E.DESCR AS EMBALAGEM,"
        Sql = Sql & " S.MERCADORIA,"
        Sql = Sql & " S.MARCA,"
        Sql = Sql & " NVL(A.AUTONUM,0) AS AUTONUM_ARMAZEM,"
        Sql = Sql & " A.DESCR AS DESCR_ARMAZEM,"
        Sql = Sql & " S.CNTR AS AUTONUMCNTR,"
        Sql = Sql & " c.Id_Conteiner,"
        Sql = Sql & " Y.YARD AS POSICAO, "
        Sql = Sql & " M.AUTONUM_CS_YARD "
        Sql = Sql & " From"
        Sql = Sql & " SGIPA.TB_CARGA_SOLTA S LEFT JOIN"
        Sql = Sql & " SGIPA.DTE_TB_EMBALAGENS E ON S.EMBALAGEM=E.CODE LEFT JOIN"
        Sql = Sql & " SGIPA.TB_CNTR_BL C ON S.CNTR=C.AUTONUM INNER JOIN"
        Sql = Sql & " SGIPA.TB_MARCANTES M ON S.AUTONUM=M.AUTONUM_CARGA LEFT JOIN"
        Sql = Sql & " SGIPA.TB_CARGA_SOLTA_YARD Y ON M.AUTONUM_CS_YARD=Y.AUTONUM LEFT JOIN "
        Sql = Sql & " SGIPA.TB_ARMAZENS_IPA A ON Y.ARMAZEM= A.AUTONUM "
        Sql = Sql & " Where"
        Sql = Sql & " M.AUTONUM=" & Val(Me.txtMarcante.Text)
        Sql = Sql & " AND S.PATIO=" & Session("AUTONUMPATIO")
        Dim tb1 As New ADODB.Recordset
        tb1.Open(Sql, BD.Conexao, 1, 1)
        If Not tb1.EOF Then
            Me.txtLote.Text = tb1.Fields("LOTE").Value.ToString
            Me.txtQtde.Text = tb1.Fields("QUANTIDADE").Value.ToString
            Me.txtAutonumCS.Text = tb1.Fields("AUTONUMCS").Value.ToString
            Me.txtLocal.Text = tb1.Fields("POSICAO").Value.ToString
            Me.txtAutonumArmazem.Text = tb1.Fields("AUTONUM_ARMAZEM").Value.ToString
            Me.txtAutonum_cs_Yard.Text = tb1.Fields("AUTONUM_CS_YARD").Value.ToString
        End If
        tb1.Close()

    End Sub

    Protected Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click
        'Dim Sql As String
        'If Valida_Marcante() Then

        '    Dim AutonumCSYard As Long
        '    Sql = "SELECT SGIPA.SEQ_CARGA_SOLTA_YARD.NEXTVAL AS QUAL FROM DUAL"
        '    Dim TB1 As New ADODB.Recordset
        '    TB1.Open(Sql, BD.Conexao, 1, 1)
        '    AutonumCSYard = TB1.Fields("QUAL").Value

        '    Sql = "UPDATE SGIPA.TB_CARGA_SOLTA_YARD SET QUANTIDADE=0 WHERE AUTONUM=" & Me.txtAutonum_Cs_Yard.text
        '    BD.Conexao.Execute(Sql)

        '    Sql = "INSERT INTO SGIPA.TB_CARGA_SOLTA_YARD (AUTONUM,AUTONUM_CS,ARMAZEM,YARD,ORIGEM,QUANTIDADE,MOTIVO_COL) VALUES "
        '    Sql = Sql & "(" & AutonumCSYard & "," & Me.txtAutonumCS.Text & "," & Me.txtAutonumArmazem.Text & ",'CAM','I'," & Me.txtQtde.Text & ",8)"
        '    BD.Conexao.Execute(Sql)


        '    Sql = "UPDATE SGIPA.TB_MARCANTES SET AUTONUM_CS_YARD=" & AutonumCSYard & ",PLACA_C='" & Microsoft.VisualBasic.Mid(Me.cbVeiculo.Text, 4, 8) & "' WHERE AUTONUM=" & Val(Me.txtMarcante.Text)
        '    BD.Conexao.Execute(Sql)


        '    Carrega_LvOrdem()
        '    Carrega_LvCarregamento()


        '    Limpa()
        '    Me.txtMarcante.Text = ""
        '    Me.txtMarcante.Focus()

        'End If
        'TA sendo feito na leitura do marcante

    End Sub

    Function Valida_Marcante() As Boolean
        If Me.txtMarcante.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante nao informado!');</script>", False)
            Return False
        End If

        If Me.txtLote.Text = "" Or Me.txtAutonumCS.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante nao encontrado!');</script>", False)
            Return False
        End If



        'Verifica se Carga pertence ao Carregamento
        Dim Sql As String
        Sql = "SELECT AUTONUMCS FROM SGIPA.VW_COL_CAM_CARREGAMENTO WHERE AUTONUMCS=" & Me.txtAutonumCS.Text & " AND PLACA_C='" & Microsoft.VisualBasic.Mid(Me.cbVeiculo.Text, 4, 8) & "'"
        Dim TB1 As New ADODB.Recordset
        TB1.Open(Sql, BD.Conexao, 1, 1)
        If TB1.EOF Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Carga nao pertence ao carregamento');</script>", False)
            Return False
        End If
        TB1.Close()


        If Me.txtLocal.Text = "CAM" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante já carregado');</script>", False)
            Return False
        End If


        'QUANTIDADE NAO ESTOURAR....
        Sql = "SELECT "

        Sql = Sql & " SUM(A.QUANTIDADE) AS QTDE_PREVISTA,"
        Sql = Sql & " SUM(NVL(B.QTDE_CARREGADA,0)) AS QTDE_CARREGADA from SGIPA.VW_COL_CAM_CARREGAMENTO A LEFT JOIN ("
        Sql = Sql & " SELECT  SUM(volumes) AS QTDE_CARREGADA, AUTONUM_CARGA AS AUTONUMCS "
        Sql = Sql & " from sgipa.tb_marcantes M INNER JOIN SGIPA.TB_CARGA_SOLTA_YARD Y ON M.AUTONUM_CS_YARD=Y.AUTONUM "
        Sql = Sql & " WHERE "
        Sql = Sql & " M.VOLUMES>0 AND Y.YARD='CAM' AND (M.PLACA_C IS NULL OR M.PLACA_C='" & Microsoft.VisualBasic.Mid(Me.cbVeiculo.Text, 4, 8) & "') GROUP BY M.AUTONUM_CARGA "
        Sql = Sql & " ) B ON A.AUTONUMCS=B.AUTONUMCS "
        Sql = Sql & " WHERE A.PLACA_C='" & Microsoft.VisualBasic.Mid(Me.cbVeiculo.Text, 4, 8) & "'"
        Sql = Sql & " AND A.AUTONUMCS= " & Me.txtAutonumCS.Text


        TB1.Open(Sql, BD.Conexao, 1, 1)

        If Not TB1.EOF Then
            If TB1.Fields("QTDE_CARREGADA").Value + Val(Me.txtQtde.Text) > TB1.Fields("QTDE_PREVISTA").Value Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade superior ao registrado');</script>", False)
                Return False
            End If
        End If
        TB1.Close()

        Return True


    End Function

    Private Sub GridCarregamento_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridCarregamento.RowCommand
        If e.CommandName <> "Sort" And e.CommandName <> "Page" Then

            Dim Index As Integer = e.CommandArgument
            Dim Id As String
            Dim Sql As String

            'Id = GridEstufados.DataKeys((CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)).RowIndex)("AUTONUM_SC").ToString()
            Id = Val(GridCarregamento.DataKeys(Index).Item(0).ToString)

            If Not Id = String.Empty Or Not Id = 0 Then

                Select Case e.CommandName

                    Case "DEL"

                        If ValidaExclusaoItem() Then
                            Sql = "UPDATE SGIPA.TB_CARGA_SOLTA_YARD SET YARD='CANCC' WHERE AUTONUM IN (SELECT AUTONUM_CS_YARD FROM SGIPA.TB_MARCANTES WHERE AUTONUM=" & Id & ")"
                            BD.Conexao.Execute(Sql)

                            Sql = "update SGIPA.TB_MARCANTES SET PLACA_C='' WHERE AUTONUM = " & Id
                            BD.Conexao.Execute(Sql)

                            Carrega_LvOrdem()
                            Carrega_LvCarregamento()


                        End If



                End Select

            End If

        End If


    End Sub

    Function ValidaExclusaoItem() As Boolean

        If Microsoft.VisualBasic.Left(Me.cbVeiculo.Text, 3) <> "( )" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Já foi apontado final do carregamento!');</script>", False)
            Return False
        End If

        Return True
    End Function

    Protected Sub btSalvar0_Click(sender As Object, e As EventArgs) Handles btSalvar0.Click
        If ValidaFinalizar() Then

            Dim Sql As String = String.Empty
            Sql = "UPDATE SGIPA.TB_ORDEM_CARREGAMENTO SET DT_CARREGAMENTO=SYSDATE WHERE AUTONUM IN "
            Sql = Sql & " (SELECT ORDEM_CARREG FROM SGIPA.VW_COL_CAM_CARREGAMENTO WHERE PLACA_C='" & Microsoft.VisualBasic.Mid(Me.cbVeiculo.Text, 4, 8) & "') "
            Sql = Sql & " AND DT_CARREGAMENTO IS NULL "
            BD.Conexao.Execute(Sql)
            CarregarVeiculos()

            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Carregamento finalizado com sucesso!');</script>", False)



        End If
    End Sub

    Function ValidaFinalizar() As Boolean
        If Me.cbVeiculo.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Escolha o veículo!');</script>", False)
            Return False
        End If

        Dim Alerta As String


        For i = 0 To Me.GridOC.Rows.Count - 1
            Alerta = "Carregamento Incompleto Lote " & GridOC.Rows(i).Cells(1).Text
            If GridOC.Rows(i).Cells(3).Text <> GridOC.Rows(i).Cells(4).Text Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" & Alerta & "');</script>", False)
                Return False
            End If
        Next


        Return True
    End Function

    Private Sub GridOC_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridOC.PageIndexChanging
        GridOC.PageIndex = e.NewPageIndex
        Carrega_LvOrdem()

    End Sub

    Private Sub GridCarregamento_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridCarregamento.PageIndexChanging
        GridCarregamento.PageIndex = e.NewPageIndex
        Carrega_LvCarregamento()
    End Sub

    Private Sub CarregaCS_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

    End Sub

    Private Sub CarregaCS_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete


    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load

    End Sub

    Private Sub CarregaCS_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub CarregaCS_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete

    End Sub

    Private Sub CarregaCS_SaveStateComplete(sender As Object, e As EventArgs) Handles Me.SaveStateComplete

    End Sub

    Protected Sub Atualizar_Click(sender As Object, e As EventArgs) Handles Atualizar.Click
        If Me.cbVeiculo.SelectedIndex > 0 Then
            Carrega_LvOrdem()
            Carrega_LvCarregamento()
            Limpa()
            Me.txtMarcante.Text = ""
            Me.txtMarcante.Focus()
        End If
    End Sub

    Protected Sub btnFotos_Click(sender As Object, e As EventArgs) Handles btnFotos.Click

        ' If Val(cbVeiculo.SelectedValue) <> 0 Then
        '     ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione um Veiculo.');</script>", False)
        '     Exit Sub
        ' End If

        Dim url As String = ConfigurationManager.AppSettings("UrlSiteFotos").ToString()
        Response.Write("<script>window.open('" + url + "/Fotos.aspx?idTipoProcesso=6&autonumCntrBl=" & cbVeiculo.SelectedValue & "&autonumPatio=" + Session("PATIO").ToString() + "&lote=0&autonumCsOp=0&autonumPatioOp=0&autonumCsrdx=0&autonumPatiordx=0','_blank');</script>")
    End Sub

End Class