Imports System.Data.OleDb

Public Class frmMarcanteRDX
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



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
            'Me.temp_registro_AutonumRegCs.Value = Request.QueryString("temp_registro_AutonumRegCs").ToString()
            'Me.temp_registro_QtdeDescarga.Value = Request.QueryString("temp_registro_QtdeDescarga").ToString()
            'Me.temp_registro_AutonumTI.Value = Request.QueryString("temp_registro_AutonumTI").ToString()

            Me.temp_registro_AutonumRegCs.Value = 0
            Me.temp_registro_QtdeDescarga.Value = 0
            Me.temp_registro_AutonumTI.Value = 0

            Carrega_Grid1()

            CarregarArmazens()

            Me.cbArm.SelectedIndex = -1

            txtMarcante.Focus()

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

    Private Function Valida() As Boolean



        If Me.txtMarcante.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante nao informado');</script>", False)
            Return False
        End If

        If Me.txtQtdeM.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade não informada');</script>", False)
            Return False
        End If


        If Val(Me.temp_registro_txtTalie.Value) <> 0 Then
            If TalieDAO.TalieFechado(Val(Me.temp_registro_txtTalie.Value)) = 1 Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Talie Fechado - Operação cancelada');</script>", False)
                Return False
            End If
        End If


        Dim Sql As String = String.Empty
        Sql = "SELECT A.AUTONUM_REGCS,A.AUTONUM_BOO, A.VOLUMES, A.AUTONUM,A.FLAG_REGISTRO  FROM "
        Sql = Sql & " REDEX.TB_MARCANTES_RDX A "
        Sql = Sql & " WHERE "
        Sql = Sql & " A.AUTONUM=" & Val(Me.txtMarcante.Text)


        Dim TB1 As New ADODB.Recordset
        TB1.Open(Sql, BD.Conexao, 1, 1)
        If TB1.EOF Then

            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante nao encontrado');</script>", False)
            Return False

        Else

            If TB1.Fields("AUTONUM_BOO").Value.ToString <> Me.temp_registro_lblCodigoBooking.Value Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante não pertence ao item descarregado');</script>", False)
                Return False
            End If

            If TB1.Fields("VOLUMES").Value.ToString <> "0" And TB1.Fields("FLAG_REGISTRO").Value = 0 Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante já associado');</script>", False)
                Return False
            End If

            If Val(Me.txtQtdeAssociada.Text) + Val(Me.txtQtdeM.Text) > Val(Me.txtQtdeDesc.Text) Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Divergencia de Quantidades');</script>", False)
                Return False
            End If

        End If
        TB1.Close()



        Dim FlagCt As Boolean
        FlagCt = False
        Dim AutonumCt As Long = 0
        FlagCt = False

        If Me.txtlocalpos.Text <> "" And Me.cbArm.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe o armazem.');</script>", False)
            Return False
        End If

        If Me.cbArm.SelectedIndex > 0 Then
            Sql = "SELECT AUTONUM FROM SGIPA.TB_ARMAZENS_IPA WHERE AUTONUM=" & Me.cbArm.SelectedValue & " and flag_ct=1"
            Dim tbCt As New ADODB.Recordset
            tbCt.Open(Sql, BD.Conexao, 3, 3)
            If Not tbCt.EOF Then
                FlagCt = True
                AutonumCt = tbCt.Fields("autonum").Value
            Else
                AutonumCt = 0
                FlagCt = False
            End If

            If Not FlagCt Then

                If Me.txtlocalpos.Text <> "" Then
                    Sql = "SELECT Y.AUTONUM,Y.YARD,A.AUTONUM, NVL(A.PATIO,0) AS PATIO FROM SGIPA.TB_YARD_CS Y INNER JOIN SGIPA.TB_ARMAZENS_IPA A "
                    Sql = Sql & " On Y.ARMAZEM=A.AUTONUM WHERE "
                    Sql = Sql & " Y.ARMAZEM=" & Me.cbArm.SelectedValue
                    Sql = Sql & " AND Y.YARD='" & Me.txtlocalpos.Text & "'"

                    Dim tb10 As New ADODB.Recordset
                    tb10.Open(Sql, BD.Conexao, 3, 3)
                    If Not tb10.EOF Then

                        If tb10.Fields("PATIO").Value <> Session("AUTONUMPATIO") Then
                            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Armazem não pertence ao patio do usuário.');</script>", False)
                            Return False
                        End If

                    Else

                        Me.txtlocalpos.Text = ""
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Posição não encontrada.');</script>", False)
                        Return False
                    End If
                    tb10.Close()
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe o local.');</script>", False)
                    Return False
                End If


            End If
        End If

        Return True
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles ADICIONAR.Click
        If Valida() Then



            Dim Sql As String

            Sql = "UPDATE REDEX.TB_MARCANTES_RDX SET   "
            Sql = Sql & " VOLUMES= " & Val(Me.txtQtdeM.Text)
            Sql = Sql & ",AUTONUM_TALIE=" & Me.temp_registro_txtTalie.Value
            If Me.cbArm.SelectedIndex > 0 Then
                Sql = Sql & ",ARMAZEM=" & Me.cbArm.SelectedValue
            Else
                Sql = Sql & ",ARMAZEM=0"
            End If
            Sql = Sql & ",YARD='" & Me.txtlocalpos.Text & "'"
            Sql = Sql & " WHERE AUTONUM= " & Val(Me.txtMarcante.Text)

            BD.Conexao.Execute(Sql)

            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante associado com sucesso!');</script>", False)

            Me.txtMarcante.Text = ""
            Me.txtQtdeM.Text = ""

            Carrega_Grid1
        End If

    End Sub

    Protected Sub Carrega_Grid1()

        Dim tb1 As New ADODB.Recordset
        Dim Sql As String


        Sql = "SELECT NVL(SUM(QTDE_DESCARGA),0) AS QTDE FROM REDEX.TB_TALIE_ITEM WHERE AUTONUM_TALIE=" & Me.temp_registro_txtTalie.Value

        Dim tb3 As New ADODB.Recordset
        tb3.Open(Sql, BD.Conexao, 1, 1)
        If Not tb3.EOF Then
            Me.txtQtdeDesc.Text = tb3.Fields("QTDE").Value
        Else
            Me.txtQtdeDesc.Text = "0"
        End If




        Sql = "SELECT "
        Sql = Sql & " LPAD(Trim(TO_CHAR(M.AUTONUM)), 12, 0)  As MARCANTE, VOLUMES AS QTDE, YARD AS LOCAL "
        Sql = Sql & " FROM REDEX.TB_MARCANTES_RDX M  "
        Sql = Sql & " WHERE M.AUTONUM_BOO=" & Me.temp_registro_lblCodigoBooking.Value
        Sql = Sql & " AND M.AUTONUM_TALIE=" & Me.temp_registro_txtTalie.Value
        Sql = Sql & " AND VOLUMES > 0 "
        Sql = Sql & " order by m.autonum "

        tb1.Open(Sql, BD.Conexao, 1, 1)

        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, tb1, "VIEW_CNTR")

            Me.Grid1.DataSource = Ds.Tables(0)
            Me.Grid1.DataBind()


            Ds.Dispose()
        End Using


        Sql = "SELECT NVL(SUM(VOLUMES),0) AS QTO FROM REDEX.TB_MARCANTES_RDX  "
        Sql = Sql & " WHERE AUTONUM_BOO=" & Me.temp_registro_lblCodigoBooking.Value
        Sql = Sql & " AND AUTONUM_TALIE=" & Me.temp_registro_txtTalie.Value

        Dim tb2 As New ADODB.Recordset
        tb2.Open(Sql, BD.Conexao, 1, 1)
        If Not tb2.EOF Then
            Me.txtQtdeAssociada.Text = tb2.Fields("QTO").Value
        End If


        If tb1.State = 1 Then
            tb1.Close()
        End If
        tb1 = Nothing



    End Sub



    Protected Sub BTVOLTAR_Click(sender As Object, e As EventArgs) Handles BTVOLTAR.Click

        If Val(Me.txtQtdeAssociada.Text) > Val(Me.txtQtdeDesc.Text) Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Divergencia de Quantidades');</script>", False)
        Else
            Dim Controle As Control
            Dim Subcontrol As Control
            For Each Controle In Page.Controls
                For Each Subcontrol In Controle.Controls
                    Subcontrol.Dispose()
                Next
                Controle.Dispose()
            Next
            Response.Redirect("Talie/TalieDescargaRegistro.aspx?" &
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
                          "&temp_registro_AutonumRegCs=" & Me.temp_registro_AutonumRegCs.Value &
                          "&temp_registro_QtdeDescarga=" & Me.temp_registro_QtdeDescarga.Value &
                          "&temp_registro_AutonumTI=" & Me.temp_registro_AutonumTI.Value)



        End If



    End Sub

    Private Sub Grid1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles Grid1.RowCommand
        If e.CommandName <> "Sort" And e.CommandName <> "Page" Then

            Dim Index As Integer = e.CommandArgument
            Dim Id As String
            Dim Sql As String


            Id = Grid1.DataKeys(Index).Item(0).ToString

            If Not Id = String.Empty Or Not Id = 0 Then

                Select Case e.CommandName

                    Case "DEL"

                        If ValidaExclusao Then

                            Sql = "UPDATE REDEX.TB_MARCANTES_RDX SET VOLUMES=0 WHERE autonum=" & Val(Id)
                            BD.Conexao.Execute(Sql)


                            Carrega_Grid1()


                        End If



                End Select

            End If

        End If

    End Sub


    Protected Function ValidaExclusao()

        If Val(Me.temp_registro_txtTalie.Value) <> 0 Then
            If TalieDAO.TalieFechado(Val(Me.temp_registro_txtTalie.Value)) = 1 Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Talie Fechado - Operação cancelada');</script>", False)
                Return False
            End If
        End If

        Return True
    End Function

    Protected Sub Grid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Grid1.SelectedIndexChanged

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

            End If
        End If
    End Sub

    Protected Sub txtMarcante_TextChanged(sender As Object, e As EventArgs) Handles txtMarcante.TextChanged

    End Sub

    Protected Sub cbArm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbArm.SelectedIndexChanged

    End Sub

    Protected Sub txtlocalpos_TextChanged(sender As Object, e As EventArgs) Handles txtlocalpos.TextChanged

    End Sub
End Class