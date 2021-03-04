Imports System.Data.OleDb

Public Class InventarioCego
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
            CarregaInventarios(0)
            CarregarArmazens()
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

    Private Sub Limpa()
        Me.cbArm.SelectedIndex = 0
        Me.txtlocalpos.Text = ""
        Me.txtMarcante.Text = ""
        Me.txtEtiqueta.Text = ""
    End Sub

    Sub CarregaInventarios(Id As Long)

        Dim rsI As New ADODB.Recordset
        Dim Sql As String

        If Id = 0 Then
            Sql = "SELECT AUTONUM,ID_ARMAZEM,DESCR,DESCR_ARMAZEM,PRATELEIRA,HEAP FROM SGIPA.VW_INVENT_ABERTO WHERE PATIO=" & Session("AUTONUMPATIO") & " ORDER BY DESCR"
        Else
            Sql = "SELECT AUTONUM,ID_ARMAZEM,DESCR,DESCR_ARMAZEM,PRATELEIRA,HEAP FROM SGIPA.VW_INVENT_ABERTO WHERE AUTONUM=" & Id & " AND PATIO=" & Session("AUTONUMPATIO") & " ORDER BY DESCR"
        End If

        rsI.Open(Sql, BD.Conexao, 3, 3)

        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, rsI, "VIEW_INVENTARIOS")
            Me.GridInventario.DataSource = Ds.Tables(0)
            Me.GridInventario.DataBind()
        End Using

        If Id = 0 Then
            Me.GridInventario.Font.Bold = False
            txtMarcante.Enabled = False
            txtEtiqueta.Enabled = False
        Else
            Me.GridInventario.Font.Bold = True
        End If

        If Me.GridInventario.Rows.Count = 1 Then
            Id = GridInventario.DataKeys(0).Item(0).ToString
            Me.GridInventario.Font.Bold = True
            Me.TxtAutonumINV.Text = Id
            Me.txtEtiqueta.Enabled = True
            Me.txtMarcante.Enabled = True
            Me.txtMarcante.Focus()
            CarregaGridCarga()
        End If

    End Sub

    Private Sub CarregaGridCarga()

        Dim rsI As New ADODB.Recordset
        Dim Sql As String
        Dim ID As Long

        ID = Val(Me.TxtAutonumINV.Text)

        Sql = " SELECT SUBSTR('000000000000' || MARCANTE ,-12) AS MARCANTE ,YARD, AUTONUM FROM SGIPA.TB_INVENTARIO_ITEM WHERE AUTONUM_INV= " & ID & " ORDER BY AUTONUM DESC "

        rsI.Open(Sql, BD.Conexao, 3, 3)

        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, rsI, "VIEW_INVENTARIOS_ITEM")
            Me.GridItens.DataSource = Ds.Tables(0)
            Me.GridItens.DataBind()

        End Using
    End Sub


    Protected Sub GridInventario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridInventario.SelectedIndexChanged


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

    Protected Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click
        Dim Sql As String = String.Empty

        Dim ID As Long



        If validaItem() Then

            ID = Val(Me.TxtAutonumINV.Text)

            Sql = "Select autonum from sgipa.tb_inventario_item where autonum_inv=" & ID & " and marcante=" & Val(Me.txtMarcante.Text)

            Dim tb1 = New ADODB.Recordset
            tb1.Open(Sql, BD.Conexao)
            If Not tb1.EOF Then

                Sql = "UPDATE SGIPA.TB_INVENTARIO_ITEM SET "
                Sql = Sql & " YARD='" & Me.txtlocalpos.Text & "',"
                Sql = Sql & " DT_INVENT=SYSDATE, "
                Sql = Sql & " AUTONUM_USER= " & Session("AUTONUMUSUARIO")
                Sql = Sql & " WHERE AUTONUM=" & tb1.Fields("AUTONUM").Value.ToString

            Else

                Sql = "INSERT INTO SGIPA.TB_INVENTARIO_ITEM (AUTONUM,"
                Sql = Sql & "AUTONUM_INV,"
                Sql = Sql & "MARCANTE,"
                Sql = Sql & "YARD,"
                Sql = Sql & "DT_INVENT,AUTONUM_USER) VALUES (SGIPA.SEQ_INVENTARIO_ITEM.NEXTVAL, "
                Sql = Sql & ID & ","
                Sql = Sql & Val(Me.txtMarcante.Text) & ","
                Sql = Sql & "'" & Me.txtlocalpos.Text & "',"
                Sql = Sql & " SYSDATE ,"
                Sql = Sql & Session("AUTONUMUSUARIO")
                Sql = Sql & ")"

            End If

            BD.Conexao.Execute(Sql)
            CarregaGridCarga()
            Limpa()
            txtMarcante.Focus()
        End If

    End Sub


    Protected Function validaItem() As Boolean

        Dim AutonumArm As Integer = 0
        Dim YardCs As String = String.Empty
        Dim FlagCt As Boolean = False
        Dim Sql As String = String.Empty

        Dim ID As Long


        If Me.TxtAutonumINV.Text <> "" Then

            ID = Val(Me.TxtAutonumINV.Text)

        Else

            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Escolha o inventário!');</script>", False)
            Return False
        End If



        If Me.txtMarcante.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe o Marcante!');</script>", False)
            Return False
        End If


        If Me.cbArm.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Armazem inválido!');</script>", False)
            Return False
        End If

        Dim tbCT As New ADODB.Recordset
        Sql = "SELECT autonum FROM SGIPA.tb_armazens_ipa where autonum=" & Val(Me.cbArm.SelectedValue) & " and flag_ct=1"
        tbCT.Open(Sql, BD.Conexao)
        If Not tbCT.EOF Then

            FlagCt = True
        End If
        tbCT.Close()

        If Not FlagCt Then
            If Me.txtlocalpos.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe o Local!');</script>", False)
                Return False
            End If
        End If


        If Len(Me.txtMarcante.Text) <> 12 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante com formato inválido!');</script>", False)
            Return False
        End If

        AutonumArm = Me.cbArm.SelectedValue
        YardCs = Me.txtlocalpos.Text

        '01L011
        '01COFRE
        Dim xArm As Integer
        Dim Xpos As String
        xArm = AutonumArm
        Xpos = Me.txtlocalpos.Text


        If Not FlagCt Then
            Dim tb1 As New ADODB.Recordset
            Sql = "SELECT AUTONUM FROM sgipa.tb_yard_cs where armazem=" & Val(xArm) & " and yard='" & Xpos & "'"
            tb1.Open(Sql, BD.Conexao)
            If Not tb1.EOF Then
                YardCs = Xpos
            Else
                YardCs = Left$(YardCs, 3) & "01" & Right$(YardCs, 1)
                tb1.Close()
                Sql = "SELECT AUTONUM FROM sgipa.tb_yard_cs where armazem=" & Val(xArm) & " and yard='" & Microsoft.VisualBasic.Left(YardCs, 3) & "01" & Microsoft.VisualBasic.Right(YardCs, 1) & "'"
                tb1.Open(Sql, BD.Conexao)
                If Not tb1.EOF Then
                    YardCs = Left$(YardCs, 3) & "01" & Right$(YardCs, 1)
                Else
                    YardCs = ""
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Local inválido!');</script>", False)
                    Return False
                End If
            End If
            tb1.Close()
        Else
            YardCs = ""
        End If

        Dim tbinv As New ADODB.Recordset
        Sql = "Select id_armazem,prateleira,heap from sgipa.vw_invent_aberto where autonum=" & ID
        tbinv.Open(Sql, BD.Conexao)
        If tbinv.EOF Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Inventário Inválido!');</script>", False)
            Return False
        Else
            If tbinv("id_armazem").Value <> AutonumArm Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Armazem divergente do inventario!');</script>", False)
                Return False
            End If
            If tbinv("prateleira").Value.ToString <> "" Then
                If Microsoft.VisualBasic.Left(YardCs, 1) <> tbinv("prateleira").Value.ToString Then
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Prateleira divergente do inventario!');</script>", False)
                    Return False
                End If
            End If
            If tbinv("Heap").Value.ToString <> "" Then
                If YardCs <> tbinv("Heap").Value.ToString Then
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Local divergente do inventario!');</script>", False)
                    Return False
                End If
            End If
        End If




        Return True
    End Function

    Protected Sub GridItens_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridItens.SelectedIndexChanged

    End Sub

    Protected Sub txtEtiqueta_TextChanged(sender As Object, e As EventArgs) Handles txtEtiqueta.TextChanged
        Dim Sql As String
        Dim Cod_Bar As String
        Dim Yard As String
        Dim Pos As String
        Dim Pos1 As String
        Dim FlagCt As Boolean
        FlagCt = False
        Dim AutonumCt As Long = 0

        Sql = "SELECT AUTONUM FROM SGIPA.TB_ARMAZENS_IPA WHERE DESCR='" & Me.txtEtiqueta.Text & "' and flag_ct=1"
        Dim tbCt As New ADODB.Recordset
        tbCt.Open(Sql, BD.Conexao, 3, 3)
        If Not tbCt.EOF Then
            FlagCt = True
            AutonumCt = tbCt.Fields("autonum").Value
        Else
            AutonumCt = 0
            FlagCt = False
        End If


        Yard = Me.txtEtiqueta.Text.Replace("-", "")
        Sql = ""
        Pos1 = ""

        If Not FlagCt Then


            Cod_Bar = Microsoft.VisualBasic.Left(Yard, 2)
            Pos = Microsoft.VisualBasic.Mid(Yard, 3)
            If Len(Pos) = 4 Then
                Pos1 = Microsoft.VisualBasic.Left(Pos, 3) & "01" & Microsoft.VisualBasic.Right(Pos, 1)
            ElseIf Len(Pos) = 5 Then
                Pos1 = Microsoft.VisualBasic.Left(Pos, 4) & "01" & Microsoft.VisualBasic.Right(Pos, 1)
            ElseIf Len(Pos) = 6 Or Len(Pos) = 7 Then
                Pos1 = Pos
            Else
                Pos1 = ""
            End If

            If Me.txtEtiqueta.Text <> "" Then
                Sql = "SELECT Y.AUTONUM,Y.YARD,A.AUTONUM, NVL(A.PATIO,0) AS PATIO FROM SGIPA.TB_YARD_CS Y INNER JOIN SGIPA.TB_ARMAZENS_IPA A "
                Sql = Sql & " On Y.ARMAZEM=A.AUTONUM WHERE "
                Sql = Sql & " A.COD_BAR='" & Cod_Bar & "'"
                Sql = Sql & " AND ((Y.YARD='" & Pos & "' AND Y.VALIDA=0) OR (Y.YARD='" & Pos1 & "' AND Y.VALIDA=1)) "

                Dim tb1 As New ADODB.Recordset
                tb1.Open(Sql, BD.Conexao, 3, 3)
                If Not tb1.EOF Then

                    If tb1.Fields("PATIO").Value <> Session("AUTONUMPATIO") Then
                        Me.txtlocalpos.Text = ""
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Armazem não pertence ao patio do usuário.');</script>", False)
                    Else

                        Me.cbArm.SelectedValue = tb1.Fields("AUTONUM").Value
                        Me.txtlocalpos.Text = tb1.Fields("YARD").Value.ToString

                    End If

                    Me.btSalvar.Focus()

                Else

                    Me.txtlocalpos.Text = ""
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Posição não encontrada.');</script>", False)

                End If
                tb1.Close()







            End If
        Else
            'ct
            If AutonumCt > 0 Then
                Me.cbArm.SelectedValue = AutonumCt
                Me.txtlocalpos.Text = ""
                Me.btSalvar.Focus()
            End If
        End If
    End Sub

    Protected Sub txtMarcante_TextChanged(sender As Object, e As EventArgs) Handles txtMarcante.TextChanged
        If Len(Me.txtMarcante.Text) = 12 Then
            Me.txtEtiqueta.Focus()
        Else

            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante com formato inválido!');</script>", False)
            Me.txtMarcante.Focus()

        End If
    End Sub

    Private Sub GridItens_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridItens.RowCommand
        If e.CommandName <> "Sort" And e.CommandName <> "Page" Then

            Dim Index As Integer = e.CommandArgument
            Dim Id As String
            Dim Sql As String


            Id = GridItens.DataKeys(Index).Item(0).ToString

            If Not Id = String.Empty Or Not Id = 0 Then

                Select Case e.CommandName

                    Case "DEL"


                        Sql = "delete from SGIPA.tb_INVENTARIO_ITEM where autonum=" & Id
                        BD.Conexao.Execute(Sql)



                        CarregaGridCarga()
                End Select

            End If



        End If

    End Sub

    Private Sub GridItens_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridItens.PageIndexChanging

        GridItens.PageIndex = e.NewPageIndex
        CarregaGridCarga()

    End Sub

    Private Sub GridInventario_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridInventario.RowCommand

        If e.CommandName = "SelInvent" Then

            Dim Index As Integer = e.CommandArgument
            Dim Id As String

            Try

                Id = GridInventario.DataKeys(Index - (GridInventario.PageIndex * GridInventario.PageSize)).Item(0).ToString


                CarregaInventarios(Val(Id))
            Catch

            End Try

        End If


        If e.CommandName = "ALL" Then
            CarregaInventarios(0)
            Me.TxtAutonumINV.Text = "0"
            CarregaGridCarga()
        End If
    End Sub

    Private Sub GridInventario_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridInventario.PageIndexChanging
        GridInventario.PageIndex = e.NewPageIndex
        CarregaInventarios(0)
        GridInventario.DataBind()
    End Sub
End Class

