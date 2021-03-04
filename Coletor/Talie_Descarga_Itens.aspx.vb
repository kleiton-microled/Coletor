﻿Imports System.Data.OleDb
Public Class Talie_Descarga_Itens

    Inherits System.Web.UI.Page


    Public Sub Carrega_Item(Item As Long)
        Session("wItem") = Item
        Dim Sql As String
        Dim MsgBox As String

        Dim Rs As New ADODB.Recordset
        Sql = "select ti.*, ti.nf as num_nf,to_char(ti.comprimento,'00.00') as CLAC,to_char(ti.largura,'00.00') as CLAL, to_char(ti.altura,'00.00') as CLAA, to_char(ti.peso,'0000.000') as PESOSTR, e.SIGLA, ti.yard  from redex.tb_talie_item ti"
        SQL = SQL & " left join redex.tb_notas_fiscais nf on ti.autonum_nf = nf.autonum_nf"
        SQL = SQL & " left join redex.tb_cad_embalagens e on ti.autonum_emb=e.autonum_emb "
        SQL = SQL & " where ti.autonum_ti = " & Session("wItem")
        Rs.Open(SQL, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        If Rs.EOF Then
            MsgBox = "Item nao localicado"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Rs.Close()
            Exit Sub
        End If

        Me.TxtNF.Text = Rs("num_nf").Value.ToString
        Session("wAutonum_NF") = Rs("autonum_nf").Value

        Session("wAutonum_RegCS") = Rs("autonum_regcs").Value
        Call Resumo()

        Sql = ""
        Sql = Sql & "SELECT B.peso_bruto, B.QTDE "
        Sql = Sql & " FROM redex.tb_registro_cs a"
        Sql = Sql & " INNER JOIN redex.tb_booking_carga b ON a.autonum_bcg = b.autonum_bcg "
        Sql = Sql & " where a.autonum_regcs = " & Session("wAutonum_RegCS")
        Dim TB As New ADODB.Recordset
        TB.Open(Sql, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)

        If Not TB.EOF Then
            Session("PESO_BRUTO") = TB("PESO_BRUTO").Value
            Session("QUANTIDADE") = TB("QTDE").Value
        Else
            Session("PESO_BRUTO") = 0
            Session("QUANTIDADE") = 1
        End If

        Me.TxtQtde.Text = Rs("qtde_descarga").Value.ToString
        Me.TxtCLAC.Text = Rs("CLAC").Value.ToString
        Me.TxtCLAL.Text = Rs("CLAL").Value.ToString
        Me.TxtCLAA.Text = Rs("CLAA").Value.ToString
        Me.TxtPeso.Text = Rs("PESOSTR").Value.ToString
        Me.TxtQtde.Text = Rs("qtde_estufagem").Value.ToString
        Me.TxtRemonte.Text = Rs("remonte").Value.ToString
        Me.TxtFumigacao.Text = Rs("fumigacao").Value.ToString
        Me.TxtIMO1.Text = Rs("imo").Value.ToString
        Me.TxtUNO1.Text = Rs("uno").Value.ToString
        Me.TxtIMO2.Text = Rs("imo2").Value.ToString
        Me.TxtUNO2.Text = Rs("uno2").Value.ToString
        Me.TxtIMO3.Text = Rs("imo3").Value.ToString
        Me.TxtUNO3.Text = Rs("uno3").Value.ToString
        Me.TxtIMO4.Text = Rs("imo4").Value.ToString
        Me.TxtUNO4.Text = Rs("uno4").Value.ToString
        Me.txtLocal.Text = Rs("yard").Value.ToString

        If Rs("autonum_emb").Value.ToString <> "" Then
            Me.DcEmbalagem.SelectedValue = Rs("autonum_emb").Value
        Else
            Me.DcEmbalagem.SelectedIndex = 0
            Me.DcEmbalagem.Text = "0"
        End If

        If Rs("flag_madeira").Value = 1 Then
            Me.CheckBox2.Checked = True
        Else
            Me.CheckBox2.Checked = False
        End If

        If Rs("flag_fragil").Value = 1 Then
            Me.CheckBox3.Checked = True
        Else
            Me.CheckBox3.Checked = False
        End If


        Me.TxtCodEmb.Text = Rs("SIGLA").Value.ToString

    End Sub


    Public Sub Carrega_Descarga(Talie As Long)

        Me.ListaDescarga.Items.Clear()

        Dim Rs As New ADODB.Recordset

        Dim Sql As String

        Sql = "select ti.autonum_ti"
        
		Sql = Sql & ", 'NF ' || nvl(ti.nf,'') || ' ' || nvl(qtde_descarga,0) || '   ' || nvl(e.SIGLA,e.DESCRICAO_emb) || ' ' || TRIM(to_char(nvl(ti.comprimento,''),'00.00')) || 'x' || TRIM(to_char(nvl(ti.largura,''),'00.00')) || 'x' || TRIM(to_char(nvl(ti.altura,''),'00.00'))   AS DISPLAY"
        Sql = SQL & " from"
        SQL = SQL & " redex.tb_talie t"
        SQL = SQL & " inner join redex.tb_talie_item ti on t.autonum_talie = ti.autonum_talie "
        SQL = SQL & " left join redex.tb_cad_embalagens e on ti.autonum_emb = e.autonum_emb "
        '        Sql = Sql & " left join redex.tb_notas_fiscais nf on ti.autonum_nf = nf.autonum_nf "
        SQL = SQL & " where t.autonum_talie = " & Talie
        SQL = SQL & " order by ti.autonum_ti "

        Rs.Open(SQL, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Me.ListaDescarga.DataTextField = "display"
        Me.ListaDescarga.DataValueField = "autonum_ti"
        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, rs, "VW_ITENS")
            Me.ListaDescarga.DataSource = Ds.Tables(0)
            Me.ListaDescarga.DataBind()
        End Using



    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Sql As String

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

            Dim RsEmbalagem As New ADODB.Recordset
            SQL = "Select autonum_emb,"
            'SQL = SQL & "case when sigla is not null then sigla || ' = ' || descricao_emb  else descricao_emb end descricao_emb"
            SQL = SQL & " descricao_emb"
            SQL = SQL & " from REDEX.tb_cad_embalagens order by sigla, descricao_emb "
            RsEmbalagem.Open(SQL, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
            Me.DcEmbalagem.DataTextField = "descricao_emb"
            Me.DcEmbalagem.DataValueField = "autonum_emb"
            Using Adapter As New OleDbDataAdapter()
                Dim Ds As New DataSet
                Adapter.Fill(Ds, RsEmbalagem, "VW_EMBALAGEM")
                Me.DcEmbalagem.DataSource = Ds.Tables(0)
                Me.DcEmbalagem.DataBind()
            End Using
            Me.DcEmbalagem.Items.Insert(0, "--Selecione uma embalagem--")
            Me.DcEmbalagem.SelectedIndex = 0
            Me.DcEmbalagem.Text = "0"



            Carrega_Descarga(Session("autonum_talie"))

            Me.BtNovo.Enabled = True
            Me.BtNovo.BackColor = Drawing.Color.FromArgb(00, 66, 99)

            Me.BtAbreItem.Enabled = True
            Me.BtAbreItem.BackColor = Drawing.Color.FromArgb(00, 66, 99)

            Me.BtExcluir.Enabled = False
            Me.BtExcluir.BackColor = Drawing.Color.LightGray

            Me.BtCancelar.Enabled = False
            Me.BtCancelar.BackColor = Drawing.Color.LightGray

            Me.BtVoltar.Enabled = True
            Me.BtVoltar.BackColor = Drawing.Color.FromArgb(00, 66, 99)

            Me.BtGravar.Enabled = False
            Me.BtGravar.BackColor = Drawing.Color.LightGray

            Me.BtBuscaNF.Enabled = True
            Me.BtBuscaNF.BackColor = Drawing.Color.FromArgb(00, 66, 99)

            Me.btLimpar.Enabled = False
            Me.btLimpar.BackColor = Drawing.Color.LightGray


            Me.TxtNF.Enabled = True

            Me.TxtNF.Focus()

        End If


    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles BtVoltar.Click
        Session("wvolta") = True
        Response.Redirect("TALIE_descarga_registro.aspx")
    End Sub

    Protected Sub BtBuscaNF_Click(sender As Object, e As EventArgs) Handles BtBuscaNF.Click

        BuscaNF()



    End Sub
    Protected Sub BuscaNF()

        Dim Sql As String
        Dim MsgBox As String


        Me.TxtPeso.Text = ""
        Me.TxtQtde.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtRemonte.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtFumigacao.Text = ""
        Me.TxtCLAA.Text = ""
        Me.TxtCLAC.Text = ""
        Me.TxtCLAL.Text = ""
        Me.DcEmbalagem.SelectedIndex = -1
        Me.TXTSALDO.Text = "0 / 0"

        Session("wItem") = 0

        If Me.TxtNF.Text = "" Then
            MsgBox = "Informe a NF"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            TxtNF.Focus()
            Exit Sub
        End If

        TxtNF.Text = Format(Val(TxtNF.Text), "0000000000")


        Dim TB As New ADODB.Recordset
        Session("wAutonum_NF") = 0
        Sql = "SELECT a.AUTONUM_NF FROM redex.TB_NOTAS_FISCAIS A "
        Sql = Sql & " inner join redex.tb_booking boo on a.autonum_boo = boo.autonum_boo"
        Sql = Sql & " AND boo.AUTONUM_boo = " & Session("wAUTONUM_BOO")
        Sql = Sql & " and A.NUM_NF = '" & Me.TxtNF.Text & "'"
        TB.Open(Sql, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        If Not TB.EOF Then
            Session("wAutonum_NF") = TB("Autonum_NF").Value
        End If
        TB.Close()


        Sql = ""
        Sql = Sql & "SELECT a.autonum_regcs AS ID, a.quantidade , B.peso_bruto, B.QTDE, B.autonum_emb, d.desc_produto, C.SIGLA,"
        Sql = Sql & " B.IMO,B.IMO2,B.IMO3,B.IMO4,B.UNO,B.UNO2,B.UNO3,B.UNO4 "
        Sql = Sql & " FROM redex.tb_registro_cs a"
        Sql = Sql & " INNER JOIN redex.tb_booking_carga b ON a.autonum_bcg = b.autonum_bcg "
        Sql = Sql & " INNER JOIN redex.tb_cad_embalagens c ON b.autonum_emb = c.autonum_emb "
        Sql = Sql & " INNER JOIN redex.tb_cad_produtos d ON b.autonum_pro = d.autonum_pro "
        Sql = Sql & " where a.autonum_reg = " & Session("Wautonum_reg")
        Sql = Sql & " and a.NF = '" & TxtNF.Text & "'"
        TB.Open(Sql, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        If TB.EOF Then
            TB.Close()
            MsgBox = "Nota fiscal nao identificada no registro."
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            TxtNF.Focus()
            Exit Sub
        End If


        'Me.TxtQtde.Text = TB("quantidade").Value.ToString
        Me.DcEmbalagem.SelectedValue = TB("autonum_emb").Value
        Me.TxtCodEmb.Text = TB("SIGLA").Value.ToString
        Me.TxtUNO1.Text = TB("UNO").Value.ToString
        Me.TxtUNO2.Text = TB("UNO2").Value.ToString
        Me.TxtUNO3.Text = TB("UNO3").Value.ToString
        Me.TxtUNO4.Text = TB("UNO4").Value.ToString

        Me.TxtIMO1.Text = TB("IMO").Value.ToString
        Me.TxtIMO2.Text = TB("IMO2").Value.ToString
        Me.TxtIMO3.Text = TB("IMO3").Value.ToString
        Me.TxtIMO4.Text = TB("IMO4").Value.ToString

        Session("PESO_BRUTO") = TB("PESO_BRUTO").Value
        Session("QUANTIDADE") = TB("QTDE").Value

        Session("wAutonum_RegCS") = TB("ID").Value

        Call Resumo()

        TB.Close()

        Me.BtNovo.Enabled = False
        Me.BtNovo.BackColor = Drawing.Color.LightGray

        Me.BtExcluir.Enabled = False
        Me.BtExcluir.BackColor = Drawing.Color.LightGray

        Me.BtCancelar.Enabled = True
        Me.BtCancelar.BackColor = Drawing.Color.FromArgb(0, 66, 99)


        Me.BtVoltar.Enabled = False
        Me.BtVoltar.BackColor = Drawing.Color.LightGray

        Me.BtGravar.Enabled = True
        Me.BtGravar.BackColor = Drawing.Color.FromArgb(0, 66, 99)

        Me.btLimpar.Enabled = False
        Me.btLimpar.BackColor = Drawing.Color.LightGray


        Me.BtBuscaNF.Enabled = False
        Me.BtBuscaNF.BackColor = Drawing.Color.LightGray

        Me.TxtNF.Enabled = False
        Me.BtAbreItem.Enabled = False
        Me.BtAbreItem.BackColor = Drawing.Color.LightGray

        Me.TxtQtde.Focus()

    End Sub

    Protected Sub Resumo()
        Dim Sql As String


        Sql = "select NVL(sum(qtde_descarga),0) from redex.tb_talie_item where autonum_regcs=" & Session("wAutonum_RegCS")
        Dim QtdD As Long
        QtdD = BD.Conexao.Execute(Sql).Fields(0).Value

        Sql = "Select NVL(sum(quantidade),0) from redex.tb_registro_cs where autonum_regcs=" & Session("wAutonum_RegCS")
        Dim QtdR As Long
        QtdR = BD.Conexao.Execute(Sql).Fields(0).Value

        If QtdD = QtdR Then
            Session("wFIMNOTA") = 1
        Else
            Session("wFIMNOTA") = 0
        End If


        Me.TXTSALDO.Text = QtdD.ToString & " / " & QtdR.ToString
    End Sub


    Protected Sub BtNovo_Click(sender As Object, e As EventArgs) Handles BtNovo.Click


        Me.BtNovo.Enabled = False
        Me.BtNovo.BackColor = Drawing.Color.LightGray

        Me.BtExcluir.Enabled = False
        Me.BtExcluir.BackColor = Drawing.Color.LightGray

        Me.BtCancelar.Enabled = True
        Me.BtCancelar.BackColor = Drawing.Color.FromArgb(00, 66, 99)


        Me.BtVoltar.Enabled = False
        Me.BtVoltar.BackColor = Drawing.Color.LightGray


        Me.BtGravar.Enabled = True
        Me.BtGravar.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Me.btLimpar.Enabled = True
        Me.btLimpar.BackColor = Drawing.Color.FromArgb(00, 66, 99)


        Me.BtBuscaNF.Enabled = False
        Me.BtBuscaNF.BackColor = Drawing.Color.LightGray

        Me.TxtNF.Enabled = False
        Me.BtAbreItem.Enabled = False
        Me.BtAbreItem.BackColor = Drawing.Color.LightGray


        Session("wItem") = 0
        Me.TxtPeso.Text = ""
        Me.TxtQtde.Text = ""
        Me.TxtRemonte.Text = ""
        Me.TxtFumigacao.Text = ""
        Me.TxtCLAA.Text = ""
        Me.TxtCLAC.Text = ""
        Me.TxtCLAL.Text = ""
        Me.TxtUNO1.Text = ""
        Me.TxtUNO2.Text = ""
        Me.TxtUNO3.Text = ""
        Me.TxtUNO4.Text = ""
        Me.TxtIMO1.Text = ""
        Me.TxtIMO2.Text = ""
        Me.TxtIMO3.Text = ""
        Me.TxtIMO4.Text = ""
        Me.TxtCodEmb.Text = ""
        Me.CheckBox2.Checked = False
        Me.CheckBox3.Checked = False
        Me.DcEmbalagem.SelectedIndex = 0

        Me.TxtQtde.Focus()



    End Sub

    Protected Sub BtGravar_Click(sender As Object, e As EventArgs) Handles BtGravar.Click
        GravaItem()
    End Sub

    Protected Sub GravaItem()

        Dim Sql As String
        Dim MsgBox As String

        If Not ValidarNumerico(TxtQtde.Text) Then
            MsgBox = "Conteudo do campo invalido"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            TxtQtde.Text = "" : TxtQtde.Focus() : Exit Sub
        End If

        If Not ValidarNumerico(TxtRemonte.Text) Then
            MsgBox = "Conteudo do campo Remonte invalido. Preencha apenas com números"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            TxtRemonte.Text = "" : TxtRemonte.Focus() : Exit Sub
        End If

        If Me.TxtIMO1.Text <> "" Then
            Sql = "SELECT COUNT(*) FROM redex.tb_cad_carga_perigosa where code='" & TxtIMO1.Text & "'"
            If (BD.Conexao.Execute(Sql).Fields(0)).Value = 0 Then
                MsgBox = "IMO nao cadastrado"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
                TxtIMO1.Text = "" : TxtIMO1.Focus() : Exit Sub
            End If
        End If
        If Me.TxtIMO2.Text <> "" Then
            Sql = "SELECT COUNT(*) FROM redex.tb_cad_carga_perigosa where code='" & TxtIMO2.Text & "'"
            If (BD.Conexao.Execute(Sql).Fields(0)).Value = 0 Then
                MsgBox = "IMO nao cadastrado"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
                TxtIMO2.Text = "" : TxtIMO2.Focus() : Exit Sub
            End If
        End If
        If Me.TxtIMO3.Text <> "" Then
            Sql = "SELECT COUNT(*) FROM redex.tb_cad_carga_perigosa where code='" & TxtIMO3.Text & "'"
            If (BD.Conexao.Execute(Sql).Fields(0)).Value = 0 Then
                MsgBox = "IMO nao cadastrado"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
                TxtIMO3.Text = "" : TxtIMO3.Focus() : Exit Sub
            End If
        End If
        If Me.TxtIMO4.Text <> "" Then
            Sql = "SELECT COUNT(*) FROM redex.tb_cad_carga_perigosa where code='" & TxtIMO4.Text & "'"
            If (BD.Conexao.Execute(Sql).Fields(0)).Value = 0 Then
                MsgBox = "IMO nao cadastrado"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
                TxtIMO4.Text = "" : TxtIMO4.Focus() : Exit Sub
            End If
        End If

        If Me.TxtUNO1.Text <> "" Then
            Sql = "SELECT COUNT(*) FROM redex.tb_cad_onu where code='" & TxtUNO1.Text & "'"
            If (BD.Conexao.Execute(Sql).Fields(0)).Value = 0 Then
                MsgBox = "UNO nao cadastrado"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
                TxtUNO1.Text = "" : TxtUNO1.Focus() : Exit Sub
            End If
        End If
        If Me.TxtUNO2.Text <> "" Then
            Sql = "SELECT COUNT(*) FROM redex.tb_cad_onu where code='" & TxtUNO2.Text & "'"
            If (BD.Conexao.Execute(Sql).Fields(0)).Value = 0 Then
                MsgBox = "UNO nao cadastrado"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
                TxtUNO2.Text = "" : TxtUNO2.Focus() : Exit Sub
            End If
        End If
        If Me.TxtUNO3.Text <> "" Then
            Sql = "SELECT COUNT(*) FROM redex.tb_cad_onu where code='" & TxtUNO3.Text & "'"
            If (BD.Conexao.Execute(Sql).Fields(0)).Value = 0 Then

                MsgBox = "UNO nao cadastrado"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
                TxtUNO3.Text = "" : TxtUNO3.Focus() : Exit Sub
            End If
        End If
        If Me.TxtUNO4.Text <> "" Then
            Sql = "SELECT COUNT(*) FROM redex.tb_cad_onu where code='" & TxtUNO4.Text & "'"
            If (BD.Conexao.Execute(Sql).Fields(0)).Value = 0 Then
                MsgBox = "UNO nao cadastrado"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
                TxtUNO4.Text = "" : TxtUNO4.Focus() : Exit Sub
            End If
        End If
        If Session("AUTONUM_TALIE") = 0 Then
            MsgBox = "Talie nao informado"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Exit Sub
        End If

        If Session("AUTONUM_TALIE") = "" Then
            MsgBox = "Talie nao informado"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Exit Sub
        End If

        If String.IsNullOrEmpty(Session("AUTONUM_TALIE")) Then
            MsgBox = "Talie nao informado"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Exit Sub
        End If

        Sql = "select flag_fechado from redex.tb_talie where autonum_talie=" & Session("autonum_talie")
        If BD.Conexao.Execute(Sql).Fields(0).Value = 1 Then
            MsgBox = "Talie Fehado - Operacao cancelada"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Exit Sub
        End If

        If Val(Me.TxtQtde.Text) = 0 Then
            MsgBox = "Quantidade nao informada"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Me.TxtQtde.Focus() : Exit Sub
        End If
        If Me.DcEmbalagem.SelectedIndex <= 0 Then
            MsgBox = "Embalagem nao informada"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Me.DcEmbalagem.Focus() : Exit Sub
        End If
        If Me.TxtNF.Text = "" Then 'Or Session("wAutonum_NF") = 0 Then
            MsgBox = "NF nao informada"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Me.TxtNF.Focus() : Exit Sub
        End If
        'If Session("wAutonum_NF") = 0 Then
        '    MsgBox = "NF invalida"
        '    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
        '    Me.TxtNF.Focus() : Exit Sub
        'End If
        If Session("wAutonum_RegCS") = "" Then
            MsgBox = "Talie nao informado"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Exit Sub
        End If

        If String.IsNullOrEmpty(Session("wAutonum_RegCS")) Then
            MsgBox = "Talie nao informado"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Exit Sub
        End If
        If Session("wAutonum_RegCS") = 0 Then
            MsgBox = "Item de descarga invalido"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Exit Sub
        End If
        If Me.TxtCLAC.Text = "" Then Me.TxtCLAC.Text = "0"
        If Me.TxtCLAL.Text = "" Then Me.TxtCLAL.Text = "0"
        If Me.TxtCLAA.Text = "" Then Me.TxtCLAA.Text = "0"
        If Me.TxtPeso.Text = "" Then Me.TxtPeso.Text = "0"


        Sql = "select NVL(sum(qtde_descarga),0) from redex.tb_talie_item where autonum_regcs=" & Session("wAutonum_RegCS")
        If Session("wItem") <> 0 Then
            Sql = Sql & " And autonum_ti <> " & Session("wItem")
        End If
        Dim QtdD As Long
        QtdD = BD.Conexao.Execute(Sql).Fields(0).Value

        Sql = "Select NVL(sum(quantidade),0) from redex.tb_registro_cs where autonum_regcs=" & Session("wAutonum_RegCS")
        Dim QtdR As Long
        QtdR = BD.Conexao.Execute(Sql).Fields(0).Value
        If Val(Me.TxtQtde.Text) + QtdD > QtdR Then
            MsgBox = "Quantidade informada nao disponivel. Verifique outras descargas deste item."
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Exit Sub
        End If


        Dim Al As Long
        Al = 0

        If Me.txtLocal.Text <> "" Then
            Sql = "SELECT nvl(max(A.armazem),0) FROM SGIPA.TB_YARD_CS A INNER JOIN SGIPA.TB_ARMAZENS_IPA B ON A.ARMAZEM=B.AUTONUM WHERE B.PATIO=" & Session("AUTONUMPATIO") & " And A.YARD = '" & Me.txtLocal.Text.ToUpper & "'"

            Al = BD.Conexao.Execute(Sql).Fields(0).Value
            If Al = 0 Then
                MsgBox = "Posição inexistente neste patio"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
                Exit Sub
            End If
        End If


        Dim SqlHist2 As String = String.Empty

        If Session("wItem") = 0 Then
            Sql = "select redex.seq_tb_talie_item.nextval from dual"
            Session("wItem") = BD.Conexao.Execute(Sql).Fields(0).Value

            Sql = "Insert into redex.tb_talie_item (AUTONUM_TI,autonum_talie,autonum_regcs,qtde_descarga"
            Sql = Sql & ",tipo_descarga,diferenca,obs,qtde_disponivel,comprimento,largura,altura,peso,qtde_estufagem,marca"
            Sql = Sql & ",remonte,fumigacao,flag_fragil,flag_madeira,YARD,armazem,autonum_nf,nf"
            Sql = Sql & ",imo,uno,imo2,uno2,imo3,uno3,imo4,uno4,autonum_emb"
            Sql = Sql & ") values (" & Session("wItem") & ","
            Sql = Sql & Session("AUTONUM_TALIE")
            Sql = Sql & "," & Session("wAutonum_RegCS")
            Sql = Sql & "," & Replace(Me.TxtQtde.Text, ",", ".")
            Sql = Sql & ",''"
            Sql = Sql & ",0"
            Sql = Sql & ",''"
            Sql = Sql & ",0"
            Sql = Sql & "," & Replace(Me.TxtCLAC.Text, ",", ".")
            Sql = Sql & "," & Replace(Me.TxtCLAL.Text, ",", ".")
            Sql = Sql & "," & Replace(Me.TxtCLAA.Text, ",", ".")
            Sql = Sql & "," & Replace(Me.TxtPeso.Text, ",", ".")
            Sql = Sql & "," & Replace(Me.TxtQtde.Text, ",", ".")
            Sql = Sql & ",''"
            Sql = Sql & ",'" & Me.TxtRemonte.Text & "'"
            Sql = Sql & ",'" & Me.TxtFumigacao.Text & "'"
            Sql = Sql & "," & IIf(Me.CheckBox3.Checked = True, 1, 0)
            Sql = Sql & "," & IIf(Me.CheckBox2.Checked = True, 1, 0)
            If Al = 0 Then
                Sql = Sql & ",null"
                Sql = Sql & ",null"
            Else
                Sql = Sql & ",'" & Me.txtLocal.Text.ToUpper & "'"
                Sql = Sql & ",'" & Al & "'"

            End If
            Sql = Sql & "," & Session("wAutonum_NF")
            Sql = Sql & ",'" & TxtNF.Text & "'"
            Sql = Sql & ",'" & TxtIMO1.Text & "'"
            Sql = Sql & ",'" & TxtUNO1.Text & "'"
            Sql = Sql & ",'" & TxtIMO2.Text & "'"
            Sql = Sql & ",'" & TxtUNO2.Text & "'"
            Sql = Sql & ",'" & TxtIMO3.Text & "'"
            Sql = Sql & ",'" & TxtUNO3.Text & "'"
            Sql = Sql & ",'" & TxtIMO4.Text & "'"
            Sql = Sql & ",'" & TxtUNO4.Text & "'"
            Sql = Sql & "," & Me.DcEmbalagem.SelectedValue
            Sql = Sql & ")"



            SqlHist2 = "INSERT INTO REDEX.TB_TALIE_ITEM_COL (AUTONUM_TI,USUARIO,DT,BROWSER_NAME,BROWSER_VERSION,MOBILEDEVICEMODEL,MOBILEDEVICEMANUFACTURER,FLAG_MOBILE,IP_CONNECTION) VALUES ("
            SqlHist2 = SqlHist2 & Session("wItem") & ","
            SqlHist2 = SqlHist2 & Session("AUTONUMUSUARIO") & ","
            SqlHist2 = SqlHist2 & "SYSDATE,"
            SqlHist2 = SqlHist2 & "'" & Session("BROWSER_NAME") & "',"
            SqlHist2 = SqlHist2 & "'" & Session("BROWSER_VERSION") & "',"
            SqlHist2 = SqlHist2 & "'" & Session("MOBILEDEVICEMODEL") & "',"
            SqlHist2 = SqlHist2 & "'" & Session("MOBILEDEVICEMANUFACTURER") & "',"
            SqlHist2 = SqlHist2 & IIf(Session("ISMOBILEDEVICE") = False, 0, 1) & "',"
            SqlHist2 = SqlHist2 & "'" & Session("IP_CONNECTION") & "'"
            SqlHist2 = SqlHist2 & ") "




        Else

            Sql = "update redex.tb_talie_item set"
            Sql = Sql & " qtde_descarga = " & Replace(Me.TxtQtde.Text, ",", ".")
            Sql = Sql & ",comprimento=" & Replace(Me.TxtCLAC.Text, ",", ".")
            Sql = Sql & ",largura=" & Replace(Me.TxtCLAL.Text, ",", ".")
            Sql = Sql & ",altura=" & Replace(Me.TxtCLAA.Text, ",", ".")
            Sql = Sql & ",peso=" & Replace(Me.TxtPeso.Text, ",", ".")
            Sql = Sql & ",qtde_estufagem=" & Replace(Me.TxtQtde.Text, ",", ".")
            Sql = Sql & ",remonte='" & Me.TxtRemonte.Text & "'"
            Sql = Sql & ",fumigacao='" & Me.TxtFumigacao.Text & "'"
            Sql = Sql & ",imo='" & TxtIMO1.Text & "'"
            Sql = Sql & ",uno='" & TxtUNO1.Text & "'"
            Sql = Sql & ",imo2='" & TxtIMO2.Text & "'"
            Sql = Sql & ",uno2='" & TxtUNO2.Text & "'"
            Sql = Sql & ",imo3='" & TxtIMO3.Text & "'"
            Sql = Sql & ",uno3='" & TxtUNO3.Text & "'"
            Sql = Sql & ",imo4='" & TxtIMO4.Text & "'"
            Sql = Sql & ",uno4='" & TxtUNO4.Text & "'"
            Sql = Sql & ",autonum_emb=" & Me.DcEmbalagem.SelectedValue
            Sql = Sql & ",yard='" & Me.txtLocal.Text.ToUpper & "'"
            Sql = Sql & ",armazem='" & Al & "'"
            Sql = Sql & " where autonum_ti=" & Session("wItem")

        End If

        Try
            'BD.Conexao.BeginTrans()
            Try
                BD.Conexao.Execute(Sql.ToString(), BD.LinhasAfetadas)
                If SqlHist2 <> String.Empty Then BD.Conexao.Execute(SqlHist2.ToUpper)
            Catch ex As Exception
                Throw New Exception("Erro. Tente novamente." & ex.Message())
            End Try
            'BD.Conexao.CommitTrans()

            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro inserido com sucesso');</script>", False)

        Catch ex As Exception
            Throw New Exception("Erro. Tente novamente." & ex.Message())
            'BD.Conexao.RollbackTrans()
        End Try


        Carrega_Descarga(Session("autonum_talie"))

        Session("NF") = Me.TxtNF.Text



        Me.TxtPeso.Text = ""
        Me.TxtQtde.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtRemonte.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtFumigacao.Text = ""
        Me.TxtCLAA.Text = ""
        Me.TxtCLAC.Text = ""
        Me.TxtCLAL.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtUNO1.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtUNO2.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtUNO3.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtUNO4.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtIMO1.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtIMO2.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtIMO3.Text = ""
        If Me.CheckBox1.Checked = False Then Me.TxtIMO4.Text = ""

        Me.CheckBox2.Checked = False
        Me.CheckBox3.Checked = False

        Me.DcEmbalagem.SelectedIndex = 0
        Me.TxtCodEmb.Text = ""
        Me.TxtNF.Text = ""
        'Me.txtLocal.Text = ""
        Me.TXTSALDO.Text = ""

        Me.BtNovo.Enabled = True
        Me.BtNovo.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Me.BtExcluir.Enabled = False
        Me.BtExcluir.BackColor = Drawing.Color.LightGray

        Me.BtCancelar.Enabled = False
        Me.BtCancelar.BackColor = Drawing.Color.LightGray

        Me.BtVoltar.Enabled = True
        Me.BtVoltar.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Me.BtGravar.Enabled = False
        Me.BtGravar.BackColor = Drawing.Color.LightGray


        Me.btLimpar.Enabled = False
        Me.btLimpar.BackColor = Drawing.Color.LightGray


        Me.BtBuscaNF.Enabled = True
        Me.BtBuscaNF.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Me.TxtNF.Enabled = True
        Me.BtAbreItem.Enabled = True
        Me.BtAbreItem.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Resumo()


        Me.TxtNF.Focus()

        If Me.CheckBox1.Checked = True And Session("wFIMNOTA") = 0 Then
            Me.TxtNF.Text = Session("NF")
            BuscaNF()
        End If


        If Session("wFIMNOTA") = 1 Then
            Me.TXTSALDO.Text = ""
        End If
    End Sub

    Protected Sub BtExcluir_Click(sender As Object, e As EventArgs) Handles BtExcluir.Click
        Dim Sql As String
        Dim MsgBox As String

        Sql = "select flag_fechado from redex.tb_talie where autonum_talie=" & Session("autonum_talie")
        If BD.Conexao.Execute(SQL).Fields(0).Value = 1 Then
            MsgBox = "Talie Fehado - Operacao cancelada"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Exit Sub
        End If

        If Session("wItem") = 0 Then
            MsgBox = "Um item deve estar selecionado para exclusao"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Exit Sub
        End If

        SQL = "DELETE FROM REDEX.TB_TALIE_ITEM WHERE AUTONUM_TI=" & Session("wItem")
        Try
            'BD.Conexao.BeginTrans()
            Try
                BD.Conexao.Execute(SQL.ToString(), BD.LinhasAfetadas)
            Catch ex As Exception
                Throw New Exception("Erro. Tente novamente." & ex.Message())
            End Try
            'BD.Conexao.CommitTrans()
            MsgBox = "Registro Excluido"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
        Catch ex As Exception
            Throw New Exception("Erro. Tente novamente." & ex.Message())
            'BD.Conexao.RollbackTrans()
        End Try



        Carrega_Descarga(Session("autonum_talie"))

        Me.TxtPeso.Text = ""
        Me.TxtQtde.Text = ""
        Me.TxtRemonte.Text = ""
        Me.TxtFumigacao.Text = ""
        Me.TxtCLAA.Text = ""
        Me.TxtCLAC.Text = ""
        Me.TxtCLAL.Text = ""
        Me.TxtUNO1.Text = ""
        Me.TxtUNO2.Text = ""
        Me.TxtUNO3.Text = ""
        Me.TxtUNO4.Text = ""
        Me.TxtIMO1.Text = ""
        Me.TxtIMO2.Text = ""
        Me.TxtIMO3.Text = ""
        Me.TxtIMO4.Text = ""
        Me.DcEmbalagem.SelectedIndex = 0
        Me.TxtCodEmb.Text = ""
        Me.CheckBox2.Checked = False
        Me.CheckBox3.Checked = False

        Session("wItem") = 0


        Me.BtNovo.Enabled = True
        Me.BtNovo.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Me.BtExcluir.Enabled = False
        Me.BtExcluir.BackColor = Drawing.Color.LightGray

        Me.BtCancelar.Enabled = False
        Me.BtCancelar.BackColor = Drawing.Color.LightGray

        Me.BtVoltar.Enabled = True
        Me.BtVoltar.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Me.BtGravar.Enabled = False
        Me.BtGravar.BackColor = Drawing.Color.LightGray


        Me.btLimpar.Enabled = False
        Me.btLimpar.BackColor = Drawing.Color.LightGray


        Me.BtBuscaNF.Enabled = True
        Me.BtBuscaNF.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Me.TxtNF.Enabled = True
        Me.BtAbreItem.Enabled = True
        Me.BtAbreItem.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Resumo()

    End Sub

    Protected Sub BtCancelar_Click(sender As Object, e As EventArgs) Handles BtCancelar.Click

        Me.TxtNF.Text = ""
        Me.TxtPeso.Text = ""
        Me.TxtQtde.Text = ""
        Me.TxtRemonte.Text = ""
        Me.TxtFumigacao.Text = ""
        Me.TxtCLAA.Text = ""
        Me.TxtCLAC.Text = ""
        Me.TxtCLAL.Text = ""
        Me.TxtUNO1.Text = ""
        Me.TxtUNO2.Text = ""
        Me.TxtUNO3.Text = ""
        Me.TxtUNO4.Text = ""
        Me.TxtIMO1.Text = ""
        Me.TxtIMO2.Text = ""
        Me.TxtIMO3.Text = ""
        Me.TxtIMO4.Text = ""
        Me.DcEmbalagem.SelectedIndex = 0
        Me.TxtCodEmb.Text = ""
        Me.TXTSALDO.Text = ""
        Me.CheckBox2.Checked = False
        Me.CheckBox3.Checked = False

        Session("wItem") = 0

        Me.BtNovo.Enabled = True
        Me.BtNovo.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Me.BtExcluir.Enabled = False
        Me.BtExcluir.BackColor = Drawing.Color.LightGray

        Me.BtCancelar.Enabled = False
        Me.BtCancelar.BackColor = Drawing.Color.LightGray

        Me.BtVoltar.Enabled = True
        Me.BtVoltar.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Me.BtGravar.Enabled = False
        Me.BtGravar.BackColor = Drawing.Color.LightGray

        Me.btLimpar.Enabled = False
        Me.btLimpar.BackColor = Drawing.Color.LightGray

        Me.BtBuscaNF.Enabled = True
        Me.BtBuscaNF.BackColor = Drawing.Color.FromArgb(00, 66, 99)

        Me.TxtNF.Enabled = True

        Me.BtAbreItem.Enabled = True
        Me.BtAbreItem.BackColor = Drawing.Color.FromArgb(00, 66, 99)


    End Sub



    Protected Sub TxtNF_TextChanged(sender As Object, e As EventArgs) Handles TxtNF.TextChanged
        If Len(TxtNF.Text) = 10 Then
            BuscaNF()
        Else
            'TxtNF.Text = Right("0000000000" & TxtNF.Text, 10)
            'BuscaNF()
        End If
    End Sub

    Private Sub ListaDescarga_DataBinding(sender As Object, e As EventArgs) Handles ListaDescarga.DataBinding

    End Sub

    Private Sub ListaDescarga_DataBound(sender As Object, e As EventArgs) Handles ListaDescarga.DataBound


    End Sub

    Private Sub ListaDescarga_Load(sender As Object, e As EventArgs) Handles ListaDescarga.Load



    End Sub

    Protected Sub ListaDescarga_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListaDescarga.SelectedIndexChanged



    End Sub


    Private Sub ListaDescarga_TextChanged(sender As Object, e As EventArgs) Handles ListaDescarga.TextChanged

    End Sub

    Protected Sub BtAbreItem_Click(sender As Object, e As EventArgs) Handles BtAbreItem.Click


        Dim MsgBox As String

        If ListaDescarga.SelectedIndex = -1 Then
            MsgBox = "Um item deve estar selecionado"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + MsgBox + "');</script>", False)
            Exit Sub
        End If


        If ListaDescarga.SelectedItem.Value > 0 Then
            Carrega_Item(ListaDescarga.SelectedItem.Value)

            Me.BtNovo.Enabled = False
            Me.BtNovo.BackColor = Drawing.Color.LightGray

            Me.BtExcluir.Enabled = True
            Me.BtExcluir.BackColor = Drawing.Color.FromArgb(00, 66, 99)

            Me.BtCancelar.Enabled = True
            Me.BtCancelar.BackColor = Drawing.Color.FromArgb(00, 66, 99)

            Me.BtVoltar.Enabled = False
            Me.BtVoltar.BackColor = Drawing.Color.LightGray

            Me.BtGravar.Enabled = True
            Me.BtGravar.BackColor = Drawing.Color.FromArgb(00, 66, 99)

            Me.btLimpar.Enabled = True
            Me.btLimpar.BackColor = Drawing.Color.FromArgb(00, 66, 99)

            Me.BtBuscaNF.Enabled = False
            Me.BtBuscaNF.BackColor = Drawing.Color.LightGray

            Me.TxtNF.Enabled = False
            Me.BtAbreItem.Enabled = False
            Me.BtAbreItem.BackColor = Drawing.Color.LightGray

        End If
    End Sub


    Protected Sub TxtCLAC_TextChanged(sender As Object, e As EventArgs) Handles TxtCLAC.TextChanged

    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        Me.TxtNF.Focus()
    End Sub

    Protected Sub TxtIMO1_TextChanged(sender As Object, e As EventArgs) Handles TxtIMO1.TextChanged

    End Sub

    Protected Sub btLimpar_Click(sender As Object, e As EventArgs) Handles btLimpar.Click
        Me.TxtPeso.Text = ""
        Me.TxtQtde.Text = ""
        Me.TxtRemonte.Text = ""
        Me.TxtFumigacao.Text = ""
        Me.TxtCLAA.Text = ""
        Me.TxtCLAC.Text = ""
        Me.TxtCLAL.Text = ""
        Me.DcEmbalagem.SelectedIndex = -1
        Me.TxtIMO1.Text = ""
        Me.TxtIMO2.Text = ""
        Me.TxtIMO3.Text = ""
        Me.TxtIMO4.Text = ""
        Me.TxtNF.Text = ""
        Me.TXTSALDO.Text = ""
        Me.CheckBox2.Checked = False
        Me.CheckBox3.Checked = False
        If Me.TxtNF.Enabled = True Then Me.TxtNF.Focus()

    End Sub

    Protected Sub TxtCodEmb_TextChanged(sender As Object, e As EventArgs) Handles TxtCodEmb.TextChanged
        Me.DcEmbalagem.SelectedIndex = 0

        If Me.TxtCodEmb.Text <> "" Then
            Dim Sql As String
            Sql = "SELECT AUTONUM_EMB FROM REDEX.TB_CAD_EMBALAGENS WHERE SIGLA='" & Me.TxtCodEmb.Text.ToUpper & "'"
            Dim rsE As New ADODB.Recordset
            rsE.Open(Sql, BD.Conexao)
            If Not rsE.EOF Then
                Me.DcEmbalagem.SelectedValue = rsE("AUTONUM_EMB").Value
                Me.BtGravar.Focus()
            Else
                Me.TxtCodEmb.Text = ""
            End If
            rsE.Close()
        End If
    End Sub

    Protected Sub DcEmbalagem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DcEmbalagem.SelectedIndexChanged
        Dim Sql As String

        If Me.DcEmbalagem.Text <> "" Then

            Sql = "SELECT SIGLA FROM REDEX.TB_CAD_EMBALAGENS WHERE AUTONUM_EMB=" & Me.DcEmbalagem.SelectedValue
            Dim rsE As New ADODB.Recordset
            rsE.Open(Sql, BD.Conexao)
            If Not rsE.EOF Then
                Me.TxtCodEmb.Text = rsE("SIGLA").Value.ToString
            Else
                Me.TxtCodEmb.Text = ""
            End If
            rsE.Close()
        Else
            Me.TxtCodEmb.Text = ""
        End If
    End Sub

    Protected Sub TxtQtde_TextChanged(sender As Object, e As EventArgs) Handles TxtQtde.TextChanged
        Dim Peso As Double

        'If Me.TxtPeso.Text = "" Or Val(Me.TxtPeso.Text) = 0 Then
        Peso = (Session("PESO_BRUTO") / Session("QUANTIDADE")) * Me.TxtQtde.Text
        Me.TxtPeso.Text = Microsoft.VisualBasic.Format(Peso, "0000.##0")
        'End If

        TxtCodEmb.Focus()

    End Sub

    Protected Sub TxtPeso_TextChanged(sender As Object, e As EventArgs) Handles TxtPeso.TextChanged

    End Sub
End Class