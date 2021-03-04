Imports System.Data.OleDb

Public Class Talie_Descarga_Registro
    Inherits System.Web.UI.Page

    Public Msgbox As String
    Public Shared SQL As String
    Public Shared wObs As String
    Public Shared wLoad As Boolean = True

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
            'If Not wProximo Then
            Dim RsEquipes As New ADODB.Recordset
            SQL = "Select autonum_eqp, nome_eqp from redex.tb_equipe where flag_ativo=1 and flag_operador=1  order by nome_eqp "
            RsEquipes.Open(SQL, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
            Me.DC_Equipe.DataTextField = "nome_eqp"
            Me.DC_Equipe.DataValueField = "autonum_eqp"
            Using Adapter As New OleDbDataAdapter()
                Dim Ds As New DataSet
                Adapter.Fill(Ds, RsEquipes, "VW_EQUIPE")
                Me.DC_Equipe.DataSource = Ds.Tables(0)
                Me.DC_Equipe.DataBind()
            End Using
            Me.DC_Equipe.Items.Insert(0, "--Selecione uma equipe--")
            Me.DC_Equipe.SelectedIndex = 0
            '             Me.DC_Equipe.Text = "0"


            Dim RsConferente As New ADODB.Recordset
            SQL = "Select autonum_eqp, nome_eqp from redex.tb_equipe where flag_ativo=1 and flag_conferente=1 order by nome_eqp"
            RsConferente.Open(SQL, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
            Me.DC_Conferente.DataTextField = "nome_eqp"
            Me.DC_Conferente.DataValueField = "autonum_eqp"
            Using Adapter As New OleDbDataAdapter()
                Dim Ds As New DataSet
                Adapter.Fill(Ds, RsConferente, "VW_CONFERENTE")
                Me.DC_Conferente.DataSource = Ds.Tables(0)
                Me.DC_Conferente.DataBind()
            End Using
            Me.DC_Conferente.Items.Insert(0, "--Selecione um conferente--")
            Me.DC_Conferente.SelectedIndex = 0
            '  Me.DC_Conferente.Text = "0"


            Me.DC_Operacao.ClearSelection()
            Me.DC_Operacao.Items.Add("MANUAL")
            Me.DC_Operacao.Items.Add("AUTOMATIZADA")
            Me.DC_Operacao.Items.Insert(0, "--Selecione a operaçao--")
            Me.DC_Operacao.SelectedIndex = 0
            ' Me.DC_Operacao.Text = "0"


            Me.BtEcluir.Enabled = False
            Me.BtEcluir.BackColor = Drawing.Color.LightGray

            Me.BtFinalizar.Enabled = False
            Me.BtFinalizar.BackColor = Drawing.Color.LightGray

            Me.BtGravar.Enabled = False
            Me.BtGravar.BackColor = Drawing.Color.LightGray

            Me.BtNovo.Enabled = True
            Me.BtNovo.BackColor = Drawing.Color.FromArgb(0, 66, 99)

            Me.BtCancelar.Enabled = False
            Me.BtCancelar.BackColor = Drawing.Color.LightGray

            Me.BtNext.Enabled = False
            Me.BtNext.BackColor = Drawing.Color.LightGray

            Carrega_Padroes()

            Me.TxtRegistro.Focus()

        End If

        If Session("wvolta") Then

            Me.LB_Talie.Text = Session("C1")
            Me.TxtInicio.Text = Session("C2")
            Me.TxtFim.Text = Session("C3")
            Me.TxtRegistro.Text = Session("C4")
            Me.TxtPlaca.Text = Session("C5")
            Me.TxtCliente.Text = Session("C6")
            Me.TxtReserva.Text = Session("C7")
            Me.DC_Conferente.Text = Session("C8")
            Me.DC_Equipe.Text = Session("C9")
            Me.DC_Operacao.Text = Session("C10")

            Session("wvolta") = False

            Me.BtGravar.Enabled = True
            Me.BtGravar.BackColor = Drawing.Color.FromArgb(0, 66, 99)

            Me.BtNovo.Enabled = False
            Me.BtNovo.BackColor = Drawing.Color.LightGray

            Me.BtCancelar.Enabled = True
            Me.BtCancelar.BackColor = Drawing.Color.FromArgb(0, 66, 99)

            Me.BtFinalizar.Enabled = True
            Me.BtFinalizar.BackColor = Drawing.Color.FromArgb(0, 66, 99)

            Me.BtNext.Enabled = True
            Me.BtNext.BackColor = Drawing.Color.FromArgb(0, 66, 99)

            Me.BtEcluir.Enabled = True
            Me.BtEcluir.BackColor = Drawing.Color.FromArgb(0, 66, 99)

            Me.BtGravar.Focus()

        End If

        wObs = Session("WOBS")

    End Sub

    Protected Sub Carrega_Padroes()

        If Me.DC_Conferente.SelectedIndex = 0 Then

            SQL = "SELECT autonum_eqp FROM REDEX.TB_EQUIPE WHERE ID_LOGIN=" & Session("AUTONUMUSUARIO")

            Dim TB1 As New ADODB.Recordset
            TB1.Open(SQL, BD.Conexao, 3, 3)

            If Not TB1.EOF Then
                Me.DC_Conferente.SelectedValue = TB1.Fields("AUTONUM_EQP").Value
                Me.DC_Conferente.Enabled = False
            Else
                Me.DC_Conferente.Enabled = True
            End If

        End If

        If Me.DC_Equipe.SelectedIndex = 0 Then

            Dim Horario As String
            Horario = Format(Now, "HHmm")

            If Horario >= "0800" And Horario <= "1559" Then Me.DC_Equipe.SelectedValue = 62
            If Horario >= "1600" And Horario <= "2359" Then Me.DC_Equipe.SelectedValue = 101
            If Horario >= "0000" And Horario <= "0759" Then Me.DC_Equipe.SelectedValue = 270

        End If

    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TxtRegistro.TextChanged

    End Sub

    Protected Sub BtNext_Click(sender As Object, e As EventArgs) Handles BtNext.Click

        Session("WOBS") = wObs

        Session("C1") = Me.LB_Talie.Text
        Session("C2") = Me.TxtInicio.Text
        Session("C3") = Me.TxtFim.Text
        Session("C4") = Me.TxtRegistro.Text
        Session("C5") = Me.TxtPlaca.Text
        Session("C6") = Me.TxtCliente.Text
        Session("C7") = Me.TxtReserva.Text
        Session("C8") = Me.DC_Conferente.Text
        Session("C9") = Me.DC_Equipe.Text
        Session("C10") = Me.DC_Operacao.Text
        Session("wvolta") = False

        Response.Redirect("TALIE_descarga_itens.aspx")

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.LBStatusTalie.Text = ""
        Me.LB_Talie.Text = ""

        Session("AUTONUM_TALIE") = 0

        TxtRegistro.Text = Val(TxtRegistro.Text)

        If TxtRegistro.Text <> "" And TxtRegistro.Text <> "0" Then

            SQL = " Select "
            SQL = SQL & " t.AUTONUM_TALIE, t.AUTONUM_PATIO, t.PLACA, "
            SQL = SQL & " t.INICIO, t.TERMINO, t.FLAG_DESCARGA,"
            SQL = SQL & " t.FLAG_ESTUFAGEM, t.CROSSDOCKING, nvl(t.CONFERENTE,0) as CONFERENTE ,"
            SQL = SQL & " nvl(t.EQUIPE,0) as equipe, t.AUTONUM_BOO, t.FLAG_CARREGAMENTO,"
            SQL = SQL & " t.FORMA_OPERACAO, t.AUTONUM_GATE, t.FLAG_FECHADO,"
            SQL = SQL & " t.OBS, t.AUTONUM_RO, t.AUDIT_225,"
            SQL = SQL & " t.ANO_TERMO, t.TERMO, t.DATA_TERMO,"
            SQL = SQL & " t.FLAG_PACOTES, t.ALERTA_ETIQUETA, t.AUTONUM_REG, "
            SQL = SQL & " t.FLAG_COMPLETO, t.EMAIL_ENVIADO,"
            SQL = SQL & " boo.reference, cp.fantasia from redex.tb_talie T"
            SQL = SQL & " inner join redex.tb_booking boo On t.autonum_boo=boo.autonum_boo"
            SQL = SQL & " inner join redex.tb_cad_parceiros cp On boo.autonum_parceiro=cp.autonum"
            SQL = SQL & " where t.AUTONUM_REG = " & TxtRegistro.Text

            Dim Rs As New ADODB.Recordset
            Rs.Open(SQL, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)

            If Not Rs.EOF Then

                Msgbox = "Já existe talie aberto para esta placa/reserva - Abrindo para edicao"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)

                Me.LB_Talie.Text = Rs("autonum_talie").Value
                Session("AUTONUM_TALIE") = Me.LB_Talie.Text
                Session("wAUTONUM_BOO") = Rs("autonum_BOO").Value

                If Rs("FORMA_OPERACAO").Value.ToString = "" Then
                    Me.DC_Operacao.SelectedValue = "AUTOMATIZADA"
                Else
                    If Rs("forma_operacao").Value = "M" Then
                        Me.DC_Operacao.SelectedValue = "MANUAL"
                    Else
                        Me.DC_Operacao.SelectedValue = "AUTOMATIZADA"
                    End If
                End If

                If Rs("conferente").Value <> 0 Then
                    Me.DC_Conferente.SelectedValue = Rs("conferente").Value
                End If

                If Rs("equipe").Value <> 0 Then
                    Me.DC_Equipe.SelectedValue = Rs("equipe").Value
                End If

                TxtPlaca.Text = Rs("placa").Value.ToString
                Me.TxtReserva.Text = Rs("reference").Value.ToString
                Session("WReserva") = Me.TxtReserva.Text
                Session("wAutonum_BOO") = Rs("autonum_boo").Value
                Session("wAutonum_Gate") = Rs("autonum_gate").Value
                Session("wAutonum_Reg") = TxtRegistro.Text
                Me.TxtCliente.Text = Rs("fantasia").Value.ToString
                Me.TxtInicio.Text = Format(Rs("INICIO").Value, "dd/MM/yyyy HH:mm")

                If Rs("termino").Value.ToString <> "" Then
                    Me.TxtFim.Text = Format(Rs("termino").Value, "HH:mm").ToString
                End If

                If Rs("flag_fechado").Value = 1 Then
                    Me.LBStatusTalie.Text = "TALIE FECHADO"
                End If

                wObs = Rs("obs").Value.ToString
                Session("WOBS") = wObs
                Rs.Close()

            Else

                wObs = ""
                Session("WOBS") = wObs

                If TxtInicio.Text = "" Then
                    TxtInicio.Text = Format(Now, "dd/MM/yyyy HH:mm")
                Else
                    TxtInicio.Text = Replace(TxtInicio.Text, " ", "")
                    TxtInicio.Text = Replace(TxtInicio.Text, ":", "")
                    TxtInicio.Text = Replace(TxtInicio.Text, "/", "")
                    If TxtInicio.Text.Length > 12 Then TxtInicio.Text = Left(Me.TxtInicio.Text, 12)
                    TxtInicio.Text = Mid(Me.TxtInicio.Text, 1, 2) + "/" + Mid(Me.TxtInicio.Text, 3, 2) + "/" + Mid(Me.TxtInicio.Text, 5, 4) + " " + Mid(Me.TxtInicio.Text, 9, 2) + ":" + Mid(Me.TxtInicio.Text, 11, 2)

                    If Not IsDate(TxtInicio.Text) Then
                        Msgbox = "Data Inicio Invalida"
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert(" + Msgbox + ");</script>", False)
                        Exit Sub
                    End If
                    If Mid(TxtInicio.Text, 4, 2) > "12" Then
                        Msgbox = "Data Inicio Invalida"
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
                        Exit Sub
                    End If
                End If

                Dim Rsx As New ADODB.Recordset

                SQL = "select * from"
                SQL = SQL & " redex.tb_registro reg"
                SQL = SQL & " where"
                SQL = SQL & " autonum_reg=" & TxtRegistro.Text
                Rsx.Open(SQL, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)

                If Rsx.EOF Then
                    Msgbox = "Registro não encontrado"
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert(" + Msgbox & " );</script>", False)
                    Rsx.Close()
                    TxtRegistro.Text = ""
                    Exit Sub
                End If

                TxtPlaca.Text = Rsx("placa").Value.ToString

                SQL = " "
                SQL = "select e.autonum_parceiro,e.reference, a.autonum, e.autonum_boo ,cp.fantasia"
                SQL = SQL & " from redex.tb_registro b"
                SQL = SQL & " inner join redex.tb_gate_new a on b.autonum_gate = a.autonum"
                SQL = SQL & " inner join redex.tb_booking e on b.autonum_boo = e.autonum_boo"
                SQL = SQL & " inner join redex.tb_cad_parceiros cp on e.autonum_parceiro = cp.autonum"
                SQL = SQL & " where b.autonum_reg=" & TxtRegistro.Text & " AND"
                'SQL = SQL & " a.placa='" & TxtPlaca.Text & "'"
                SQL = SQL & " A.DT_GATE_IN IS NOT NULL "
                'SQL = SQL & " AND a.dt_gate_in > b.dt_chegada AND"
                'SQL = SQL & " a.dt_gate_in < to_date('" & TxtInicio.Text & "','DD/MM/YYYY hh24:mi') AND"
                'SQL = SQL & " (a.dt_gate_out is null or a.dt_gate_out > to_date('" & TxtInicio.Text & "','DD/MM/YYYY hh24:mi'))"

                Dim RsReservas As New ADODB.Recordset
                RsReservas.Open(SQL, BD.Conexao, 3, 3)

                If RsReservas.EOF Then
                    Msgbox = "Gate IN nao localizado"
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
                    RsReservas.Close()
                    Exit Sub
                End If

                Me.TxtReserva.Text = RsReservas("reference").Value.ToString
                Session("WReserva") = Me.TxtReserva.Text
                Session("wAutonum_BOO") = RsReservas("autonum_boo").Value
                Session("wAutonum_Gate") = RsReservas("autonum").Value
                Session("wAutonum_Reg") = TxtRegistro.Text
                Me.TxtCliente.Text = RsReservas("fantasia").Value.ToString

            End If

            Me.BtEcluir.Enabled = False
            Me.BtEcluir.BackColor = Drawing.Color.LightGray

            Me.BtGravar.Enabled = True
            Me.BtGravar.BackColor = Drawing.Color.FromArgb(0, 66, 99)

            Me.BtNovo.Enabled = False
            Me.BtNovo.BackColor = Drawing.Color.LightGray

            Me.BtCancelar.Enabled = True
            Me.BtCancelar.BackColor = Drawing.Color.FromArgb(0, 66, 99)

            Me.BtNext.Enabled = False
            Me.BtNext.BackColor = Drawing.Color.LightGray

            Me.BtFinalizar.Enabled = True
            Me.BtFinalizar.BackColor = Drawing.Color.FromArgb(0, 66, 99)

            If Session("AUTONUM_TALIE") <> 0 Then

                Me.BtFinalizar.Enabled = True
                Me.BtFinalizar.BackColor = Drawing.Color.FromArgb(0, 66, 99)

                Me.BtNext.Enabled = True
                Me.BtNext.BackColor = Drawing.Color.FromArgb(0, 66, 99)

                Me.BtEcluir.Enabled = True
                Me.BtEcluir.BackColor = Drawing.Color.FromArgb(0, 66, 99)

            End If

            Me.DC_Conferente.Focus()

        End If

        Carrega_Padroes()

    End Sub

    Protected Sub TxtPlaca_TextChanged(sender As Object, e As EventArgs) Handles TxtPlaca.TextChanged

    End Sub

    Protected Sub DC_Conferente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DC_Conferente.SelectedIndexChanged
        DC_Equipe.Focus()
    End Sub

    Protected Sub BtNovo_Click(sender As Object, e As EventArgs) Handles BtNovo.Click

        LB_Talie.Text = ""

        Session("AUTONUM_TALIE") = 0
        Session("wAutonum_BOO") = 0
        Session("WReserva") = ""
        Session("wAutonum_Gate") = 0
        Session("wAutonum_Reg") = 0

        Me.TxtInicio.Text = ""
        Me.TxtRegistro.Text = ""
        Me.TxtPlaca.Text = ""
        Me.TxtReserva.Text = ""
        Me.TxtCliente.Text = ""
        Me.DC_Conferente.SelectedIndex = 0
        Me.DC_Equipe.SelectedIndex = 0
        Me.DC_Operacao.SelectedIndex = 0
        Me.LBStatusTalie.Text = ""

        TxtInicio.Text = Format(Now, "dd/MM/yyyy HH:mm")

        Me.BtEcluir.Enabled = False
        Me.BtEcluir.BackColor = Drawing.Color.LightGray

        Me.BtFinalizar.Enabled = False
        Me.BtFinalizar.BackColor = Drawing.Color.LightGray

        Me.BtGravar.Enabled = False
        Me.BtGravar.BackColor = Drawing.Color.LightGray

        Me.BtNovo.Enabled = False
        Me.BtNovo.BackColor = Drawing.Color.LightGray

        Me.BtCancelar.Enabled = True
        Me.BtCancelar.BackColor = Drawing.Color.FromArgb(0, 66, 99)

        Me.BtNext.Enabled = False
        Me.BtNext.BackColor = Drawing.Color.LightGray

        Carrega_Padroes()

    End Sub

    Protected Sub BtGravar_Click(sender As Object, e As EventArgs) Handles BtGravar.Click

        If Session("AUTONUM_TALIE") <> 0 Then
            SQL = "select flag_fechado from redex.tb_talie where autonum_talie=" & Session("AUTONUM_TALIE")
            If BD.Conexao.Execute(SQL).Fields(0).Value = 1 Then
                Msgbox = "Talie Fehado - Operacao cancelada"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
                Exit Sub
            End If
        End If

        If Me.DC_Operacao.SelectedIndex <= 0 Then
            Msgbox = "Informe o modo de operação"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        If Me.DC_Conferente.SelectedIndex <= 0 Then
            Msgbox = "Conferente não Informado"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        If Me.DC_Equipe.SelectedIndex <= 0 Then
            Msgbox = "Equipe não Informada"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        If Me.TxtInicio.Text = "" Then
            Msgbox = "Favor informar a data de inicio"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        If Not IsDate(TxtInicio.Text) Then
            Msgbox = "Data Inválida"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        If Mid(TxtInicio.Text, 4, 2) > "12" Then
            Msgbox = "Data Inválida"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        Dim Rs As New ADODB.Recordset

        If Session("AUTONUM_TALIE") = 0 Then

            SQL = "select autonum_talie from redex.tb_talie where autonum_boo=" & Session("wAutonum_BOO") & " and placa='" & Me.TxtPlaca.Text & "' and nvl(flag_fechado,0)=0"
            Rs.Open(SQL, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)

            If Not Rs.EOF Then
                Msgbox = "Já existe talie aberto para esta placa/reserva"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
                Rs.Close()
                Exit Sub
            End If


            SQL = "select redex.seq_tb_talie.nextval from dual"
            Session("AUTONUM_TALIE") = BD.Conexao.Execute(SQL).Fields(0).Value

            Me.LB_Talie.Text = Session("AUTONUM_TALIE")

            SQL = "Insert into redex.tb_talie (autonum_talie,"
            SQL = SQL & "autonum_patio,inicio,termino,flag_descarga,flag_estufagem,flag_carregamento"
            SQL = SQL & ",crossdocking,conferente,equipe,autonum_boo,forma_operacao,placa,AUTONUM_GATE,FLAG_COMPLETO,AUTONUM_REG,OBS"
            SQL = SQL & ") values ( " & Session("AUTONUM_TALIE") & ","
            SQL = SQL & "NULL"
            SQL = SQL & ",to_date('" & TxtInicio.Text & "','dd/mm/yyyy HH24:MI')"
            SQL = SQL & ",NULL"
            SQL = SQL & ",1"
            SQL = SQL & ",0"
            SQL = SQL & ",0"
            SQL = SQL & ",0"
            SQL = SQL & "," & Me.DC_Conferente.SelectedValue
            SQL = SQL & "," & Me.DC_Equipe.SelectedValue
            SQL = SQL & "," & Session("wAutonum_BOO")
            SQL = SQL & ",'" & UCase(Left(Me.DC_Operacao.SelectedValue, 1)) & "'"
            SQL = SQL & ",'" & Me.TxtPlaca.Text & "'"
            SQL = SQL & "," & Session("wAutonum_Gate")
            SQL = SQL & ",0"
            SQL = SQL & "," & Session("wAutonum_Reg")
            SQL = SQL & ",'" & wObs & "'"
            SQL = SQL & ")"

            Try
                'BD.Conexao.BeginTrans()
                Try
                    BD.Conexao.Execute(SQL.ToString(), BD.LinhasAfetadas)
                Catch ex As Exception

                End Try
                'BD.Conexao.CommitTrans()
            Catch ex As Exception
                Throw New Exception("Erro. Tente novamente." & ex.Message())
                'BD.Conexao.RollbackTrans()
            End Try

        Else

            SQL = "select count(*) from redex.tb_talie where autonum_talie=" & Session("AUTONUM_TALIE") & "  and flag_fechado=1"
            If (BD.Conexao.Execute(SQL).Fields(0)).Value > 0 Then
                Msgbox = "Talie Fechado, alteração não permitida"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
                Exit Sub
            End If

            SQL = "update redex.tb_talie set"
            SQL = SQL & " inicio=to_date('" & Me.TxtInicio.Text & "','dd/mm/yyyy hh24:mi')"
            SQL = SQL & ",conferente=" & Me.DC_Conferente.SelectedValue
            SQL = SQL & ",equipe=" & DC_Equipe.SelectedValue
            '             SQL = SQL & ",autonum_boo=" & wAutonum_BOO
            SQL = SQL & ",forma_operacao='" & UCase(Left(Me.DC_Operacao.SelectedValue, 1)) & "'"
            '             SQL = SQL & ",AUTONUM_REG=" & Nnull(TxtRegistro, 0)
            SQL = SQL & ",obs='" & wObs & "'"
            SQL = SQL & " where autonum_talie = " & Session("AUTONUM_TALIE")

            Try
                'BD.Conexao.BeginTrans()
                Try
                    BD.Conexao.Execute(SQL.ToString(), BD.LinhasAfetadas)
                Catch ex As Exception
                    Msgbox = "Erro. Tente novamente." & ex.Message()
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
                End Try
                'BD.Conexao.CommitTrans()
            Catch ex As Exception
                Msgbox = "Erro. Tente novamente." & ex.Message()
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)

                'BD.Conexao.RollbackTrans()
            End Try
        End If

        Me.BtEcluir.Enabled = True
        Me.BtEcluir.BackColor = Drawing.Color.FromArgb(0, 66, 99)

        Me.BtFinalizar.Enabled = True
        Me.BtFinalizar.BackColor = Drawing.Color.FromArgb(0, 66, 99)

        Me.BtGravar.Enabled = False
        Me.BtGravar.BackColor = Drawing.Color.LightGray

        Me.BtNovo.Enabled = False
        Me.BtNovo.BackColor = Drawing.Color.LightGray

        Me.BtCancelar.Enabled = True
        Me.BtCancelar.BackColor = Drawing.Color.FromArgb(0, 66, 99)

        Me.BtNext.Enabled = True
        Me.BtNext.BackColor = Drawing.Color.FromArgb(0, 66, 99)


        Me.BtNext.Focus()

    End Sub

    Protected Sub BtCancelar_Click(sender As Object, e As EventArgs) Handles BtCancelar.Click

        LB_Talie.Text = ""

        Session("AUTONUM_TALIE") = 0
        Session("wAutonum_BOO") = 0
        Session("WReserva") = ""
        Session("wAutonum_Gate") = 0
        Session("wAutonum_Reg") = 0

        Me.TxtInicio.Text = ""
        Me.TxtRegistro.Text = ""
        Me.TxtPlaca.Text = ""
        Me.TxtReserva.Text = ""
        Me.TxtCliente.Text = ""
        Me.DC_Conferente.SelectedIndex = 0
        Me.DC_Equipe.SelectedIndex = 0
        Me.DC_Operacao.SelectedIndex = 0

        Me.BtEcluir.Enabled = False
        Me.BtEcluir.BackColor = Drawing.Color.LightGray

        Me.BtFinalizar.Enabled = False
        Me.BtFinalizar.BackColor = Drawing.Color.LightGray

        Me.BtGravar.Enabled = False
        Me.BtGravar.BackColor = Drawing.Color.LightGray

        Me.BtNovo.Enabled = True
        Me.BtNovo.BackColor = Drawing.Color.FromArgb(0, 66, 99)

        Me.BtCancelar.Enabled = False
        Me.BtCancelar.BackColor = Drawing.Color.LightGray

        Me.BtNext.Enabled = False
        Me.BtNext.BackColor = Drawing.Color.LightGray

        Carrega_Padroes()

    End Sub

    Protected Sub BtEcluir_Click(sender As Object, e As EventArgs) Handles BtEcluir.Click

        If Session("AUTONUM_TALIE") = 0 Then
            Msgbox = "Um registro deve estar selecionado para exclusao"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        SQL = "select count(*) from redex.tb_talie where autonum_talie=" & Session("AUTONUM_TALIE") & "  and flag_fechado=1"

        If (BD.Conexao.Execute(SQL).Fields(0)).Value > 0 Then
            Msgbox = "Talie Fechado, exclusao não permitida"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        SQL = "delete from redex.tb_talie_item where autonum_talie=" & Session("AUTONUM_TALIE")
        BD.Conexao.Execute(SQL)

        SQL = "delete from redex.tb_talie where autonum_talie=" & Session("AUTONUM_TALIE")
        BD.Conexao.Execute(SQL)

        Msgbox = "Talie Excluido"
        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)

        LB_Talie.Text = ""

        Session("AUTONUM_TALIE") = 0
        Session("wAutonum_BOO") = 0
        Session("WReserva") = ""
        Session("wAutonum_Gate") = 0
        Session("wAutonum_Reg") = 0

        Me.TxtInicio.Text = ""
        Me.TxtRegistro.Text = ""
        Me.TxtPlaca.Text = ""
        Me.TxtReserva.Text = ""
        Me.TxtCliente.Text = ""
        Me.DC_Conferente.SelectedIndex = 0
        Me.DC_Equipe.SelectedIndex = 0
        Me.DC_Operacao.SelectedIndex = 0
        Me.LBStatusTalie.Text = ""

        Me.BtEcluir.Enabled = False
        Me.BtEcluir.BackColor = Drawing.Color.LightGray

        Me.BtFinalizar.Enabled = False
        Me.BtFinalizar.BackColor = Drawing.Color.LightGray

        Me.BtGravar.Enabled = False
        Me.BtGravar.BackColor = Drawing.Color.LightGray

        Me.BtNovo.Enabled = True
        Me.BtNovo.BackColor = Drawing.Color.FromArgb(0, 66, 99)

        Me.BtCancelar.Enabled = False
        Me.BtCancelar.BackColor = Drawing.Color.LightGray

        Me.BtNext.Enabled = False
        Me.BtNext.BackColor = Drawing.Color.LightGray

    End Sub

    Protected Sub BtFinalizar_Click(sender As Object, e As EventArgs) Handles BtFinalizar.Click

        If Session("AUTONUM_TALIE") = 0 Then
            Msgbox = "Um registro deve estar selecionado/gravado para ser finalizado"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        SQL = "select flag_fechado from redex.tb_talie where autonum_talie=" & Session("AUTONUM_TALIE")

        If BD.Conexao.Execute(SQL).Fields(0).Value = 1 Then
            Msgbox = "Ja consta fechamento para este Talie - Operacao cancelada"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        Dim Gate As Long
        Dim Boo As Long
        Dim Balanca As Long
        Dim Patio As Byte

        Patio = BD.Conexao.Execute("select autonum_patios from redex.tb_booking where autonum_boo=" & Session("wAutonum_BOO")).Fields(0).Value

        If BD.Conexao.Execute("select count(*) from redex.tb_talie_item where autonum_talie=" & Session("AUTONUM_TALIE")).Fields(0).Value = 0 Then
            Msgbox = "Finalize o talie somente após o lançamento da descarga"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        'If BD.Conexao.Execute("SELECT COUNT(*) FROM redex.TB_TALIE_ITEM A , redex.TB_NOTAS_ITENS B where A.AUTONUM_NF=B.AUTONUM_NF(+)  AND  AUTONUM_MER IS NULL AND a.autonum_talie=" & Session("AUTONUM_TALIE")).Fields(0).Value > 0 Then
        '    Msgbox = "Finalize o talie somente após o lançamento das Notas Fiscais e seus Itens "
        '    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
        '    Exit Sub
        'End If

        SQL = "select NVL(sum(qtde_descarga),0) from redex.tb_talie_item where autonum_talie=" & Session("AUTONUM_TALIE")

        Dim QtdD As Long
        QtdD = BD.Conexao.Execute(SQL).Fields(0).Value

        SQL = "select NVL(sum(quantidade),0) from redex.tb_registro_cs where autonum_reg=" & Me.TxtRegistro.Text

        Dim QtdR As Long
        QtdR = BD.Conexao.Execute(SQL).Fields(0).Value

        If QtdD <> QtdR Then
            Msgbox = "Quantidade descarregada diverge da quantidade registrada"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        'VERIFICA OBRIGATORIEDADE DAS POSICOES
        SQL = "select FLAG_COL_DESCARGA_YARD from redex.tb_parametros where cod_empresa=1 "
        Dim FLAG_COL_DESCARGA_YARD As Integer
        FLAG_COL_DESCARGA_YARD = BD.Conexao.Execute(SQL).Fields(0).Value
        If FLAG_COL_DESCARGA_YARD = 1 Then
            SQL = ""
            SQL = SQL & "SELECT nvl(count(*),0) FROM"
            SQL = SQL & " redex.tb_talie t"
            SQL = SQL & " INNER JOIN redex.tb_talie_item ti ON t.autonum_talie = ti.autonum_talie"
            SQL = SQL & " where t.autonum_talie = " & Session("AUTONUM_TALIE")
            SQL = SQL & " and ti.yard is null "
            If BD.Conexao.Execute(SQL).Fields(0).Value > 0 Then
                Msgbox = "Existe item sem posição de armazem cadastrada - Operação Cancelada"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
                Exit Sub
            End If

        End If

        'VERIFICA EMISSAO DE ETIQUETAS PARA DESCARGA ARMAZEM
        SQL = ""
        SQL = SQL & "SELECT nvl(count(*),0) FROM"
        SQL = SQL & " redex.tb_talie t"
        SQL = SQL & " INNER JOIN redex.tb_talie_item ti ON t.autonum_talie = ti.autonum_talie"
        SQL = SQL & " INNER JOIN redex.etiquetas e on ti.autonum_regcs = e.autonum_rcs"
        SQL = SQL & " where t.autonum_talie = " & Session("AUTONUM_TALIE")

        If BD.Conexao.Execute(SQL).Fields(0).Value = 0 Then
            Msgbox = "Não Consta geração de etiquetas deste registro - Operação Cancelada"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        SQL = "UPDATE REDEX.TB_TALIE SET ALERTA_ETIQUETA=1 WHERE AUTONUM_TALIE=" & Session("AUTONUM_TALIE")
        BD.Conexao.Execute(SQL)

        SQL = ""
        SQL = SQL & "SELECT nvl(count(*),0) FROM"
        SQL = SQL & " redex.tb_talie t"
        SQL = SQL & " INNER JOIN redex.tb_talie_item ti ON t.autonum_talie = ti.autonum_talie"
        SQL = SQL & " INNER JOIN redex.etiquetas e on ti.autonum_regcs = e.autonum_rcs"
        SQL = SQL & " where t.autonum_talie = " & Session("AUTONUM_TALIE") & " and emissao is null"

        If BD.Conexao.Execute(SQL).Fields(0).Value <> 0 Then
            Msgbox = "Consta pendencia de emissão de etiquetas deste registro - Operação Cancelada"
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)
            Exit Sub
        End If

        SQL = "UPDATE REDEX.TB_TALIE SET ALERTA_ETIQUETA=2 WHERE AUTONUM_TALIE=" & Session("AUTONUM_TALIE")
        BD.Conexao.Execute(SQL)

        Dim Rs As New ADODB.Recordset

        Gate = 0
        Balanca = 0
        SQL = ""
        SQL = SQL & "SELECT d.autonum_bcg, b.qtde_descarga AS quantidade, b.autonum_emb, "
        SQL = SQL & " d.autonum_pro, b.marca, b.qtde_estufagem, a.termino, b.comprimento, "
        SQL = SQL & " b.largura, b.altura, b.peso, B.autonum_nf, a.autonum_boo, b.autonum_ti,"
        SQL = SQL & " a.autonum_gate, a.autonum_talie, b.yard,b.armazem,b.autonum_emb, d.autonum_emb as emb_reserva"
        SQL = SQL & " ,etq.codproduto"
        SQL = SQL & " ,b.imo,b.uno, b.imo2,b.uno2, b.imo3,b.uno3, b.imo4,b.uno4, b.autonum_regcs"
        SQL = SQL & "  FROM redex.tb_talie a  "
        SQL = SQL & "  INNER JOIN redex.tb_talie_item b ON a.autonum_talie = b.autonum_talie "
        '        SQL = SQL & "  INNER JOIN redex.tb_notas_fiscais c ON b.autonum_nf = c.autonum_nf "
        SQL = SQL & "  INNER JOIN redex.tb_registro_cs e ON e.autonum_regcs = b.autonum_regcs "
        SQL = SQL & "  INNER JOIN redex.tb_booking_carga d ON d.autonum_bcg = e.autonum_bcg "
        SQL = SQL & "  LEFT JOIN (select autonum_rcs, substr(codproduto,1,8) codproduto from redex.etiquetas group by autonum_rcs, substr(codproduto,1,8)) etq on e.autonum_regcs = etq.autonum_rcs"
        SQL = SQL & "  where a.autonum_talie=" & Session("AUTONUM_TALIE")

        Rs.Open(SQL, BD.Conexao, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)

        If Not Rs.EOF Then
            Gate = Rs("Autonum_gate").Value
            Me.TxtFim.Text = Format(Now, "HH:mm")
            Balanca = BD.Conexao.Execute("select bruto from redex.tb_gate_new where autonum=" & Gate).Fields(0).Value
        End If

        On Error GoTo ErroFinaliza

        'BD.Conexao.BeginTrans()
        Do While Not Rs.EOF

            Dim id As Long
            id = BD.Conexao.Execute("select redex.seq_tb_patio_cs.nextval from dual").Fields(0).Value

            SQL = "INSERT INTO redex.TB_PATIO_CS (autonum_pcs,AUTONUM_BCG,QTDE_ENTRADA,AUTONUM_EMB,autonum_pro,MARCA,VOLUME_DECLARADO,COMPRIMENTO"
            SQL = SQL & ",LARGURA,ALTURA,BRUTO,DT_PRIM_ENTRADA,FLAG_HISTORICO,AUTONUM_REGCS,AUTONUM_NF,talie_descarga,QTDE_ESTUFAGEM,YARD,ARMAZEM,AUTONUM_PATIOS,PATIO"
            SQL = SQL & ",imo,uno,imo2,uno2,imo3,uno3,imo4,uno4,codproduto"
            SQL = SQL & " )Values(" & id & ","
            SQL = SQL & " " & Rs("AUTONUM_BCG").Value.ToString
            SQL = SQL & " ," & Rs("Quantidade").Value.ToString
            If Rs("autonum_EMB").Value.ToString <> "" Then
                SQL = SQL & " ," & Rs("autonum_EMB").Value.ToString
            Else
                SQL = SQL & " ," & Rs("emb_reserva").Value.ToString
            End If
            SQL = SQL & " ," & Rs("autonum_pro").Value.ToString
            SQL = SQL & " ,'" & Rs("Marca").Value.ToString & "'"
            SQL = SQL & " ," & Replace(Rs("Comprimento").Value * Rs("Largura").Value * Rs("Altura").Value, ",", ".")
            SQL = SQL & " ," & Replace(Rs("Comprimento").Value, ",", ".")
            SQL = SQL & " ," & Replace(Rs("Largura").Value, ",", ".")
            SQL = SQL & " ," & Replace(Rs("Altura").Value, ",", ".")
            SQL = SQL & " ," & Replace(Rs("Peso").Value, ",", ".")
            SQL = SQL & " ,to_date('" & Me.TxtInicio.Text & "','dd/mm/yyyy hh24:mi')"
            SQL = SQL & " ,0"
            SQL = SQL & " ," & Rs("autonum_regcs").Value.ToString
            SQL = SQL & "," & Rs("Autonum_NF").Value.ToString
            SQL = SQL & "," & Rs("AUTONUM_TI").Value.ToString
            SQL = SQL & " ," & Rs("qtde_estufagem").Value.ToString
            SQL = SQL & " ,'" & Rs("Yard").Value.ToString & "'"
            SQL = SQL & " ,'" & Rs("armazem").Value.ToString & "'"
            SQL = SQL & "," & Patio
            SQL = SQL & "," & Patio
            SQL = SQL & ",'" & Rs("IMO").Value.ToString & "'"
            SQL = SQL & ",'" & Rs("UNO").Value.ToString & "'"
            SQL = SQL & ",'" & Rs("imo2").Value.ToString & "'"
            SQL = SQL & ",'" & Rs("uno2").Value.ToString & "'"
            SQL = SQL & ",'" & Rs("imo3").Value.ToString & "'"
            SQL = SQL & ",'" & Rs("uno3").Value.ToString & "'"
            SQL = SQL & ",'" & Rs("imo4").Value.ToString & "'"
            SQL = SQL & ",'" & Rs("uno4").Value.ToString & "'"
            SQL = SQL & ",'" & Rs("codproduto").Value.ToString & "'"
            SQL = SQL & ")"

            BD.Conexao.Execute(UCase(SQL))

            If Rs("Yard").Value.ToString <> "" Then

                SQL = " INSERT INTO REDEX.TB_CARGA_SOLTA_YARD ( "
                SQL = SQL & " AUTONUM, AUTONUM_PATIOCS, ARMAZEM, "
                SQL = SQL & " YARD, QUANTIDADE, MOTIVO_COL) "
                SQL = SQL & " VALUES(REDEX.SEQ_CARGA_SOLTA_YARD.NEXTVAL, "
                SQL = SQL & id & ","
                SQL = SQL & Rs("armazem").Value.ToString & ","
                SQL = SQL & "'" & Rs("Yard").Value.ToString() & "',"
                SQL = SQL & Rs("Quantidade").Value.ToString() & ",0"
                SQL = SQL & ")"

                BD.Conexao.Execute(UCase(SQL))

            End If

            If Rs("IMO").Value.ToString <> "" Then
                SQL = "update redex.tb_booking_carga Set imo='" & Rs("IMO").Value.ToString & "' where autonum_bcg=" & Rs("AUTONUM_BCG").Value
                BD.Conexao.Execute(SQL)
            End If

            SQL = "insert into redex.tb_amr_gate"
            SQL = SQL & " (autonum,"
            SQL = SQL & "gate"
            SQL = SQL & ",cntr_rdx"
            SQL = SQL & ",cs_rdx"
            SQL = SQL & ",peso_entrada"
            SQL = SQL & ",peso_saida"
            SQL = SQL & ",data"
            SQL = SQL & ",id_booking"
            SQL = SQL & ",id_oc"
            SQL = SQL & ",funcao_gate"
            SQL = SQL & ",flag_historico"
            SQL = SQL & " ) values (redex.seq_tb_amr_gate.nextval,"
            SQL = SQL & Rs("Autonum_gate").Value.ToString
            SQL = SQL & ",0"
            SQL = SQL & "," & id
            SQL = SQL & "," & Balanca
            SQL = SQL & ",0"
            SQL = SQL & ",to_date('" & Me.TxtInicio.Text & "','dd/mm/yyyy hh24:mi')"
            SQL = SQL & "," & Session("wAutonum_BOO")
            SQL = SQL & ",0"
            SQL = SQL & ",203"
            SQL = SQL & ",0"
            SQL = SQL & ")"
            BD.Conexao.Execute(UCase(SQL))

            SQL = "update redex.tb_patio_cs set pcs_pai = " & id & " where autonum_pcs = " & id
            BD.Conexao.Execute(UCase(SQL))

            Boo = Rs("autonum_boo").Value

            Rs.MoveNext()
        Loop

        Rs.Close()

        'SQL = "select nvl(count(*),0) from redex.tb_patio_cs pcs inner join redex.tb_talie_item ti on pcs.talie_descarga = ti.autonum_ti"
        'SQL = SQL & " where ti.autonum_talie = " & Session("AUTONUM_TALIE")
        'If BD.Conexao.Execute(SQL).Fields(0).Value = 0 Then
        'Rs.Close()
        'Msgbox = "Falha no processo de fechamento" & vbCr & "Carga não foi transferida para o estoque" & vbCr & "Contate o TI assim que possível"
        'ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)

        'BD.Conexao.RollbackTrans()
        'Exit Sub
        'end If

        BD.Conexao.Execute("update redex.tb_talie set flag_fechado=1,termino=sysdate where autonum_talie=" & Session("AUTONUM_TALIE"))

        'verifica toda carga entrada da reserva
        Dim QR As Long
        SQL = "select nvl(sum(bcg.qtde),0) from redex.tb_booking boo"
        SQL = SQL & " inner join redex.tb_booking_carga bcg on boo.autonum_boo = bcg.autonum_boo"
        SQL = SQL & " where boo.autonum_boo = " & Boo
        SQL = SQL & " and bcg.flag_cs=1"
        QR = BD.Conexao.Execute(UCase(SQL)).Fields(0).Value

        Dim QE As Long
        SQL = "select sum(pcs.qtde_entrada) from redex.tb_booking boo"
        SQL = SQL & " inner join redex.tb_booking_carga bcg on boo.autonum_boo = bcg.autonum_boo"
        SQL = SQL & " inner join redex.tb_patio_cs pcs on bcg.autonum_bcg = pcs.autonum_bcg and boo.autonum_boo = " & Boo
        QE = BD.Conexao.Execute(UCase(SQL)).Fields(0).Value

        If QR = QE And QE <> 0 Then
            SQL = "update redex.tb_booking set flag_finalizado=1 where autonum_boo = " & Boo
            BD.Conexao.Execute(UCase(SQL))
        End If

        SQL = "update redex.tb_booking set status_reserva=2 where autonum_boo = " & Boo
        BD.Conexao.Execute(UCase(SQL))

        'BD.Conexao.CommitTrans()

        Msgbox = "Carga Transferida para o estoque"
        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)

        Me.BtFinalizar.Enabled = False
        Me.BtFinalizar.BackColor = Drawing.Color.LightGray

        LB_Talie.Text = ""
        Session("AUTONUM_TALIE") = 0
        Session("wAutonum_BOO") = 0
        Session("WReserva") = ""
        Session("wAutonum_Gate") = 0
        Session("wAutonum_Reg") = 0

        Me.TxtInicio.Text = ""
        Me.TxtRegistro.Text = ""
        Me.TxtPlaca.Text = ""
        Me.TxtReserva.Text = ""
        Me.TxtCliente.Text = ""
        Me.DC_Conferente.SelectedIndex = 0
        Me.DC_Equipe.SelectedIndex = 0
        Me.DC_Operacao.SelectedIndex = 0

        Exit Sub

ErroFinaliza:
        'BD.Conexao.RollbackTrans()
        Msgbox = "Erro durante  processo de Fechamento" & vbCr & vbCr & "Processo Cancelado"
        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" + Msgbox & "' );</script>", False)

    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load

    End Sub

    Private Sub TxtInicio_Disposed(sender As Object, e As EventArgs) Handles TxtInicio.Disposed

    End Sub

    Protected Sub TxtInicio_TextChanged(sender As Object, e As EventArgs) Handles TxtInicio.TextChanged

    End Sub

    Protected Sub BtObservacao_Click(sender As Object, e As EventArgs) Handles BtObservacao.Click

        Session("C1") = Me.LB_Talie.Text
        Session("C2") = Me.TxtInicio.Text
        Session("C3") = Me.TxtFim.Text
        Session("C4") = Me.TxtRegistro.Text
        Session("C5") = Me.TxtPlaca.Text
        Session("C6") = Me.TxtCliente.Text
        Session("C7") = Me.TxtReserva.Text
        Session("C8") = Me.DC_Conferente.Text
        Session("C9") = Me.DC_Equipe.Text
        Session("C10") = Me.DC_Operacao.Text
        Session("wvolta") = False

        Session("WLOAD") = True
        Session("WOBS") = wObs

        Response.Redirect("TALIE_observacao.aspx")

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("Menu.aspx")
    End Sub

    Protected Sub DC_Operacao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DC_Operacao.SelectedIndexChanged
        Me.BtGravar.Focus()
    End Sub

    Protected Sub DC_Equipe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DC_Equipe.SelectedIndexChanged
        DC_Operacao.Focus()
    End Sub

End Class