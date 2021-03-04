Imports System.Data.OleDb

Public Class frmMarcante
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.txtEmbalagem.Text = ""
        Me.txtQtde.Text = ""
        Me.txtQtdeM.Text = ""
        If FiltroOK() Then
            Carrega_Conteineres()
        End If
    End Sub
    Private Function FiltroOK() As Boolean

        If Me.txtLote.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Lote nao informado');</script>", False)
            Return False
        End If


        Return True
    End Function

    Private Sub Carrega_Conteineres()
        If Me.txtLote.Text <> "" Then

            Me.cbConteiner.DataTextField = "DISPLAY"
            Me.cbConteiner.DataValueField = "AUTONUM"

            Dim tb1 As New ADODB.Recordset
            Dim Sql As String
            Sql = " select c.autonum, c.ID_CONTEINER AS DISPLAY "
            Sql = Sql & " FROM SGIPA.tb_cntr_bl c inner join SGIPA.tb_amr_cntr_bl a on c.autonum=a.cntr "
            Sql = Sql & " WHERE "
            Sql = Sql & " a.bl=" & Val(Me.txtLote.Text)
            Sql = Sql & " and c.PATIO=" & Session("AutonumPatio")
            Sql = Sql & " ORDER BY ID_CONTEINER "
            tb1.Open(Sql, BD.Conexao, 1, 1)


            Using Adapter As New OleDbDataAdapter()
                Dim Ds As New DataSet
                Adapter.Fill(Ds, tb1, "VIEW_CNTR")

                Me.cbConteiner.DataSource = Ds.Tables(0)
                Me.cbConteiner.DataBind()
            End Using



            Me.cbConteiner.Items.Insert(0, "--Selecione um cntr--")
            Me.cbConteiner.SelectedIndex = 0

            If Me.cbConteiner.Items.Count = 2 Then
                Me.cbConteiner.SelectedIndex = 1
                Carrega_Dados_Conteiner()
            End If

        End If
    End Sub

    Private Sub Carrega_Dados_Conteiner()
        Dim Sql As String = String.Empty

        Sql = " Select c.QUANTIDADE, E.DESCR AS DESCR_EMBALAGEM FROM "
        Sql = Sql & " SGIPA.TB_CARGA_CNTR C INNER JOIN SGIPA.DTE_TB_EMBALAGENS E ON C.EMBALAGEM=E.CODE(+) "
        Sql = Sql & " WHERE  "
        Sql = Sql & " C.BL=" & Val(Me.txtLote.Text)

        Dim TB1 As New ADODB.Recordset
        TB1.Open(Sql, BD.Conexao, 1, 1)
        If Not TB1.EOF Then
            Me.txtEmbalagem.Text = TB1.Fields("DESCR_EMBALAGEM").Value.ToString
            Me.txtQtde.Text = TB1.Fields("QUANTIDADE").Value.ToString
        Else
            Me.txtEmbalagem.Text = ""
            Me.txtQtde.Text = ""
        End If
    End Sub

    Private Function Valida() As Boolean

        If Me.txtLote.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Lote nao informado');</script>", False)
            Return False
        End If

        If Me.cbConteiner.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Conteiner nao informado');</script>", False)
            Return False
        End If

        If Me.txtQtde.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Conteiner/BL nao encontrado');</script>", False)
            Return False
        End If

        If Me.txtEmbalagem.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Conteiner/BL nao encontrado');</script>", False)
            Return False
        End If

        Dim AutonumCntr As Long
        AutonumCntr = 0

        Dim Sql As String = String.Empty
        Sql = "SELECT A.AUTONUM,C.AUTONUM AS AUTONUMCNTR, TO_CHAR(C.DT_FIM_DESOVA,'DDMMYYYY') AS DT_FIM_DESOVA FROM SGIPA.TB_AMR_CNTR_bl A INNER JOIN "
        Sql = Sql & " SGIPA.TB_BL B ON A.BL=B.AUTONUM INNER JOIN "
        Sql = Sql & " SGIPA.TB_CNTR_BL C ON A.CNTR=C.AUTONUM "
        Sql = Sql & " WHERE "
        Sql = Sql & " B.AUTONUM=" & Val(Me.txtLote.Text)
        Sql = Sql & " AND C.AUTONUM= " & Me.cbConteiner.SelectedValue

        Dim TB1 As New ADODB.Recordset
        TB1.Open(Sql, BD.Conexao, 1, 1)
        If TB1.EOF Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Conteiner/Lote nao encontrado');</script>", False)
            Return False
        Else
            If TB1.Fields("DT_FIM_DESOVA").Value.ToString <> "" Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Fim da desova do conteiner já informado. Utilize opcao de reimpressao');</script>", False)
                Return False
            End If
            AutonumCntr = TB1.Fields("AUTONUMCNTR").Value
        End If
        TB1.Close()

        If Me.txtQtdeM.Text = "" Or Me.txtQtdeM.Text = "0" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade de marcantes não informado');</script>", False)
            Return False
        End If

        Return True
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Valida() Then

            If Valida_Impressora_Patio(Session("AUTONUMPATIO"), Session("AUTONUMUSUARIO")) Then

                Dim Sql As String

                Sql = "INSERT INTO SGIPA.TB_SOL_MARCANTES ( "
                Sql = Sql & " AUTONUM, DT_SOLICITA, FLAG_IMPRESSO, "
                Sql = Sql & " DT_IMPRESSAO, USUARIO_SOLICITA, QTDE, "
                Sql = Sql & " BL, ITEM, CNTR, "
                Sql = Sql & " ID_CONTEINER, ID_ARMAZEM,ID_PATIO) values ( "
                Sql = Sql & " SGIPA.SEQ_SOL_MARCANTES.NEXTVAL,SYSDATE,0,NULL,"
                Sql = Sql & Session("AUTONUMUSUARIO") & ","
                Sql = Sql & Val(Me.txtQtdeM.Text) & ","
                Sql = Sql & Val(Me.txtLote.Text) & ","
                Sql = Sql & "1,"
                Sql = Sql & Me.cbConteiner.SelectedValue & ","
                Sql = Sql & "'" & Me.cbConteiner.SelectedItem.ToString & "',"
                Sql = Sql & "0,"
                Sql = Sql & Session("AUTONUMPATIO")
                Sql = Sql & ")"
                BD.Conexao.Execute(Sql)

                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcantes solicitados!');</script>", False)

                Me.txtLote.Text = ""
                Me.cbConteiner.SelectedIndex = -1

                Me.txtQtdeM.Text = ""
                Me.txtQtde.Text = ""
                Me.txtEmbalagem.Text = ""
                Me.txtMarcante.Text = ""

            End If
        End If
    End Sub

    Protected Sub txtLote_TextChanged(sender As Object, e As EventArgs) Handles txtLote.TextChanged
        Me.txtEmbalagem.Text = ""
        Me.txtQtde.Text = ""
        Me.txtQtdeM.Text = ""
        If FiltroOK() Then
            Carrega_Conteineres()
        End If
    End Sub

    Protected Sub cbConteiner_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConteiner.SelectedIndexChanged
        If Me.cbConteiner.SelectedIndex > 0 Then
            Carrega_Dados_Conteiner()
        End If
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

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If ValidaReimpressao() Then

            If Valida_Impressora_Patio(Session("AUTONUMPATIO"), Session("AUTONUMUSUARIO")) Then

                Dim Sql As String

                Sql = "INSERT INTO SGIPA.TB_SOL_MARCANTES ( "
                Sql = Sql & " AUTONUM, DT_SOLICITA, FLAG_IMPRESSO, "
                Sql = Sql & " DT_IMPRESSAO, USUARIO_SOLICITA, QTDE, "
                Sql = Sql & " BL, ITEM, CNTR, "
                Sql = Sql & " ID_CONTEINER, ID_ARMAZEM,ID_PATIO,MARCANTE) values ( "
                Sql = Sql & " SGIPA.SEQ_SOL_MARCANTES.NEXTVAL,SYSDATE,0,NULL,"
                Sql = Sql & Session("AUTONUMUSUARIO") & ","
                Sql = Sql & "0,"
                Sql = Sql & "0,"
                Sql = Sql & "0,"
                Sql = Sql & "0,"
                Sql = Sql & "NULL,"
                Sql = Sql & "0,"
                Sql = Sql & Session("AUTONUMPATIO") & ","
                Sql = Sql & "'" & Me.txtMarcante.Text & "'"
                Sql = Sql & ")"
                BD.Conexao.Execute(Sql)

                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante solicitado!');</script>", False)

                Me.txtLote.Text = ""
                Me.cbConteiner.SelectedIndex = -1

                Me.txtQtdeM.Text = ""
                Me.txtQtde.Text = ""
                Me.txtEmbalagem.Text = ""
                Me.txtMarcante.Text = ""
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
            'Sql = Sql & " AND ID_PATIO=" & QualPatio

            Dim tb3 As New ADODB.Recordset
            tb3.Open(Sql, BD.Conexao, 1, 1)
            If tb3.EOF Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Impressora inválida');</script>", False)
                Return False
            Else
                If tb3.Fields("id_patio").Value <> QualPatio Then
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Impressora inválida - Patio divergente');</script>", False)
                    Return False
                End If
            End If
            tb3.Close()

        End If

        Return True
    End Function


    Private Function ValidaReimpressao() As Boolean

        Dim Sql As String = String.Empty
        If Me.txtMarcante.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe o marcante para reimpressao');</script>", False)
            Return False
        End If

        Sql = "select marcante,id_patio from operador.vw_invent_armazem "
        Sql = Sql & " where marcante='" & Me.txtMarcante.Text & "'"
        Dim tb1 As New ADODB.Recordset
        tb1.Open(Sql, BD.Conexao, 1, 1)
        If tb1.EOF Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante não encontrado no estoque');</script>", False)
            Return False
        Else
            If tb1.Fields("id_patio").Value <> Session("AUTONUMPATIO") Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Patio divergente do usuario');</script>", False)
                Return False
            End If
        End If

        Return True
    End Function

End Class