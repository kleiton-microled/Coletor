Imports System.Data.OleDb


Public Class Estufagem
    Inherits System.Web.UI.Page

    Dim Sql As String = String.Empty
    Dim OrdensOBJ As New Ordens

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

            CarregarConferentes()
            CarregarEquipes()
            CarregarModo()
            cbConferente.SelectedIndex = -1
            cbEquipe.SelectedIndex = -1
            cbModo.SelectedIndex = -1
            Me.txtPlanejamento.Focus()
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
        Me.GridEtiquetas.Dispose()
        Me.cbConferente.Dispose()
        Me.cbEquipe.Dispose()
        Me.cbModo.Dispose()
        Me.GridEstufados.Dispose()

        Response.Redirect("Menu.aspx")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridEstufados.SelectedIndexChanged

    End Sub

    Protected Sub lbReserva_TextChanged(sender As Object, e As EventArgs) Handles lbReserva.TextChanged

    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load




    End Sub

    Private Sub CarregarConferentes()

        Me.cbConferente.DataTextField = "DISPLAY"
        Me.cbConferente.DataValueField = "AUTONUM"
        Dim tb1 As New ADODB.Recordset
        Sql = "Select autonum_eqp as AUTONUM, nome_eqp as DISPLAY from REDEX.tb_equipe where flag_ativo=1 and flag_conferente=1 order by nome_eqp "
        tb1.Open(Sql, BD.Conexao, 1, 1)


        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, tb1, "VIEW_CNTR")

            Me.cbConferente.DataSource = Ds.Tables(0)
            Me.cbConferente.DataBind()
            Ds.Dispose()
        End Using

        Me.cbConferente.Items.Insert(0, "--Selecione uma Conf.--")

        If tb1.State = 1 Then
            tb1.Close()
        End If

        tb1 = Nothing


    End Sub
    Private Sub CarregarEquipes()

        Me.cbEquipe.DataTextField = "DISPLAY"
        Me.cbEquipe.DataValueField = "AUTONUM"

        Dim tb1 As New ADODB.Recordset
        Sql = "Select autonum_eqp as AUTONUM, nome_eqp as DISPLAY from REDEX.tb_equipe where flag_ativo=1 and flag_Operador=1 order by nome_eqp "
        tb1.Open(Sql, BD.Conexao, 1, 1)


        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, tb1, "VIEW_CNTR")

            Me.cbEquipe.DataSource = Ds.Tables(0)
            Me.cbEquipe.DataBind()
            Ds.Dispose()
        End Using



        Me.cbEquipe.Items.Insert(0, "--Selecione uma Equipe--")

        If tb1.State = 1 Then
            tb1.Close()
        End If
        tb1 = Nothing



    End Sub

    Private Sub CarregarModo()
        Me.cbModo.Items.Insert(0, "--Selecione o Modo--")
        Me.cbModo.Items.Insert(1, "Automatizada")
        Me.cbModo.Items.Insert(2, "Manual")
    End Sub


    Protected Sub cbModo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModo.SelectedIndexChanged

    End Sub

    Protected Sub btSair0_Click(sender As Object, e As EventArgs) Handles btSair0.Click
        CarregaPlanejamento()
        CarregaItensEstufados()
    End Sub
    Sub CarregaItensEstufados()

        Dim tb1 As New ADODB.Recordset
        If Val(Me.txtAutonumPatio.Text) = 0 Then Exit Sub

        Sql = "SELECT rownum as nr , SC.QTDE_SAIDA, sc.autonum_sc, emb.descricao_emb, pcs.codproduto,  pro.desc_produto, nf.num_nf,boo.reference, boo.autonum_boo"
        Sql = Sql & ",nf.autonum_sd_boo, sc.autonum_rcs, sc.codproduto as codbarra"
        Sql = Sql & " FROM REDEX.tb_saida_carga sc  "
        Sql = Sql & " INNER JOIN REDEX.tb_patio_cs pcs       ON sc.autonum_pcs = pcs.autonum_pcs "
        Sql = Sql & " left JOIN REDEX.tb_cad_embalagens emb ON pcs.autonum_emb = emb.autonum_emb "
        Sql = Sql & " INNER JOIN REDEX.tb_notas_fiscais nf   ON pcs.autonum_nf = nf.autonum_nf "
        Sql = Sql & " INNER JOIN REDEX.tb_booking_carga bcg  ON pcs.autonum_bcg = bcg.autonum_bcg "
        Sql = Sql & " left JOIN REDEX.tb_cad_produtos pro   ON bcg.autonum_pro = pro.autonum_pro "
        Sql = Sql & " INNER JOIN REDEX.tb_booking boo        ON bcg.autonum_boo = boo.autonum_boo "
        Sql = Sql & " where sc.autonum_patio=" & Val(Me.txtAutonumPatio.Text)
        Sql = Sql & " order by boo.reference, sc.codproduto"

        tb1.Open(Sql, BD.Conexao, 1, 1)

        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, tb1, "VIEW_CNTR")

            Me.GridEstufados.DataSource = Ds.Tables(0)
            Me.GridEstufados.DataBind()

            'Me.txtPLAN.Text = GridEstufados.Rows.Count
            Ds.Dispose()
        End Using

        If tb1.State = 1 Then
            tb1.Close()
        End If
        tb1 = Nothing

        Dim TB2 As New ADODB.Recordset

        Sql = "SELECT NVL(SUM(SC.QTDE_SAIDA),0) AS QTO "
        Sql = Sql & " FROM REDEX.tb_saida_carga sc  "
        Sql = Sql & " where sc.autonum_patio=" & Val(Me.txtAutonumPatio.Text)


        TB2.Open(Sql, BD.Conexao, 1, 1)
        Me.txtTTL.Text = TB2.Fields("QTO").Value

    End Sub

    Sub CarregaEtiquetas()

        Dim tb1 As New ADODB.Recordset

        If Val(Me.txtAutonumRo.Text) > 0 Then

            If Me.ckMC.Checked = False Then
                Sql = "SELECT"
                Sql = Sql & " DISTINCT  e.lote, 1 as quantidade, e.codproduto as etiqueta, boo.reference as reserva, to_char(e.emissao,'dd/mm/yyyy') as emissao"
                Sql = Sql & " FROM REDEX.etiquetas e"
                Sql = Sql & " inner join REDEX.tb_booking boo on e.autonum_boo = boo.autonum_boo"
                Sql = Sql & " left join REDEX.tb_saida_carga sc on e.codproduto = sc.codproduto"
                Sql = Sql & " where"
                Sql = Sql & " sc.codproduto is null and"
                Sql = Sql & " e.autonum_boo in"
                Sql = Sql & " ("
                Sql = Sql & " select bcg.autonum_boo from redex.tb_romaneio_cs rcs"
                Sql = Sql & " inner join redex.tb_patio_cs pcs on rcs.autonum_pcs = pcs.autonum_pcs"
                Sql = Sql & " inner join redex.tb_booking_carga bcg on pcs.autonum_bcg = bcg.autonum_bcg"
                Sql = Sql & " Where rcs.Autonum_Ro = " & Val(Me.txtAutonumRo.Text)
                Sql = Sql & " group by bcg.autonum_boo"
                Sql = Sql & " )"
                Sql = Sql & " order by e.lote, e.codproduto"
                'Sql = Sql & " order by sc.data_estufagem desc "
            Else

                Sql = " SELECT "
                Sql = Sql & " DISTINCT  BOO.OS AS LOTE , M.Volumes as quantidade, LPAD (TRIM (TO_CHAR (m.autonum)), 12, 0) as etiqueta, boo.reference as reserva, to_char(m.dt_associacao,'dd/mm/yyyy') as emissao "
                Sql = Sql & " FROM REDEX.tb_marcantes_rdx m "
                Sql = Sql & " inner join REDEX.tb_booking boo on m.autonum_boo = boo.autonum_boo "
                Sql = Sql & " left join REDEX.tb_saida_carga sc  "
                Sql = Sql & " on LPAD (TRIM (TO_CHAR (m.autonum)), 12, 0) = sc.codproduto "
                Sql = Sql & " where "
                'Sql = Sql & " sc.codproduto is null and "
                Sql = Sql & " m.autonum_boo in "
                Sql = Sql & " ( "
                Sql = Sql & " select bcg.autonum_boo from redex.tb_romaneio_cs rcs "
                Sql = Sql & " inner join redex.tb_patio_cs pcs on rcs.autonum_pcs = pcs.autonum_pcs "
                Sql = Sql & " inner join redex.tb_booking_carga bcg on pcs.autonum_bcg = bcg.autonum_bcg "
                Sql = Sql & " Where rcs.Autonum_Ro =  " & Val(Me.txtAutonumRo.Text)
                Sql = Sql & " group by bcg.autonum_boo "
                Sql = Sql & " ) and m.volumes>0 "
                Sql = Sql & " order by boo.os,LPAD (TRIM (TO_CHAR (m.autonum)), 12, 0) "


            End If

            tb1.Open(Sql, BD.Conexao, 1, 1)

            Using Adapter As New OleDbDataAdapter()
                Dim Ds As New DataSet
                Adapter.Fill(Ds, tb1, "VIEW_CNTR")

                Me.GridEtiquetas.DataSource = Ds.Tables(0)
                Me.GridEtiquetas.DataBind()

                Ds.Dispose()
            End Using

        End If

        If tb1.State = 1 Then
            tb1.Close()
        End If
        tb1 = Nothing

    End Sub

    Sub CarregaPlanejamento()

        Me.txtAutonumCamera.Text = "0"
        Me.txtIDTIMELINE.Text = "0"
        Me.txtCamera.Text = "-"
        Me.txtPLAN.Text = "0"

        Sql = "select nvl(cli.fantasia,'') as fantasia, ro.autonum_ro, cc.id_conteiner, nvl(boo.reference,'') as reference "
        Sql = Sql & ",boo.autonum_boo, ro.autonum_patio, boo.autonum_parceiro"
        Sql = Sql & ",to_char(tal.inicio,'DD/MM/YY HH24:MI') as INICIO "
        Sql = Sql & ",to_char(tal.TERMINO,'DD/MM/YY HH24:MI') as TERMINO "
        Sql = Sql & ",NVL(tal.conferente,0) as CONFERENTE "
        Sql = Sql & ",NVL(tal.equipe,0) as EQUIPE "
        Sql = Sql & ",CASE NVL(tal.FORMA_OPERACAO,'-')  WHEN '-' THEN -1 WHEN 'A' THEN 1 WHEN 'M' THEN 2 END as FORMA_OPERACAO "
        Sql = Sql & ",nvl(tal.autonum_talie,0) as AUTONUM_TALIE,nvl(tal.autonum_camera,0) as autonum_camera, nvl(cc.yard,'') as yard, nvl(cc.patio,0) as patio "
        Sql = Sql & ",nvl(tal.idtimeline,0) as idtimeline "
        Sql = Sql & " from redex.tb_romaneio ro "
        Sql = Sql & " inner join redex.tb_patio cc on ro.autonum_patio = cc.autonum_patio "
        Sql = Sql & " inner join redex.tb_booking boo on ro.autonum_boo = boo.autonum_boo "
        Sql = Sql & " inner join redex.tb_cad_parceiros cli on boo.autonum_parceiro = cli.autonum "
        Sql = Sql & " left join redex.tb_talie tal on ro.autonum_ro=tal.autonum_ro  "
        Sql = Sql & " where ro.autonum_ro = " & Val(Me.txtPlanejamento.Text)

        Dim tb1 As New ADODB.Recordset
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then
            Me.txtInicio.Text = tb1.Fields("INICIO").Value.ToString
            Me.txtFIM.Text = tb1.Fields("TERMINO").Value.ToString
            Me.lbCliente.Text = tb1.Fields("fantasia").Value.ToString
            Me.lbReserva.Text = tb1.Fields("reference").Value.ToString
            Me.lbConteiner.Text = tb1.Fields("id_conteiner").Value.ToString
            Me.txtAutonumBoo.Text = tb1.Fields("autonum_boo").Value.ToString
            Me.txtID_Cliente.Text = tb1.Fields("autonum_parceiro").Value.ToString
            Me.txtAutonumPatio.Text = tb1.Fields("autonum_patio").Value.ToString
            Me.txtAutonumRo.Text = tb1.Fields("autonum_ro").Value.ToString
            Me.txtTalie.Text = tb1.Fields("autonum_talie").Value
            Me.txtIDTIMELINE.Text = tb1.Fields("IDTIMELINE").Value

            If tb1.Fields("autonum_camera").Value > 0 Then
                Me.txtAutonumCamera.Text = tb1.Fields("autonum_camera").Value.ToString

            Else
                Sql = "SELECT NVL(MAX(C.autonum),0) AS QUALCAM FROM OPERADOR.TB_YARD P INNER JOIN OPERADOR.TB_CAMERAS C ON P.AUTONUM_CAMERA=C.AUTONUM WHERE P.PATIO=" & tb1.Fields("PATIO").Value & " AND P.YARD='" & tb1.Fields("yard").Value.ToString & "'"
                Me.txtAutonumCamera.Text = OracleDAO.ExecuteScalar(Sql)

            End If


            If Me.txtAutonumCamera.Text <> "0" Then
                Sql = "SELECT NVL(MAX(C.descr),'-') AS QUALCAM FROM OPERADOR.TB_CAMERAS C WHERE C.AUTONUM =" & Me.txtAutonumCamera.Text
                Me.txtCamera.Text = OracleDAO.ExecuteScalar(Sql)
            End If

            Dim tbMC As New ADODB.Recordset

            Sql = "select m.autonum  "
            Sql = Sql & " from redex.tb_romaneio ro "
            Sql = Sql & " inner join redex.tb_romaneio_cs rcs on ro.autonum_ro = rcs.autonum_ro "
            Sql = Sql & " inner join redex.TB_patio_cs pcs on rcs.autonum_pcs = pcs.autonum_pcs "
            Sql = Sql & " inner join redex.tb_booking_carga bc on pcs.autonum_bcg=bc.autonum_bcg "
            Sql = Sql & " inner join redex.tb_booking boo on bc.autonum_boo=boo.autonum_boo "
            Sql = Sql & " inner join redex.tb_marcantes_rdx m on boo.autonum_boo=m.autonum_boo "
            Sql = Sql & " where ro.autonum_ro=" & Val(Me.txtAutonumRo.Text)

            'Sql = "select autonum from redex.tb_marcantes_rdx where autonum_boo=" & tb1.Fields("autonum_boo").Value.ToString
            tbMC.Open(Sql, BD.Conexao, 3, 3)

            If tbMC.EOF Then
                Me.ckMC.Checked = False
            Else
                Me.ckMC.Checked = True
            End If


            Sql = "select NVL(sum(rcs.qtde),0) as Quanto "
            Sql = Sql & " from redex.tb_romaneio ro "
            Sql = Sql & " inner join redex.tb_romaneio_cs rcs on ro.autonum_ro = rcs.autonum_ro "
            Sql = Sql & " inner join redex.TB_patio_cs pcs on rcs.autonum_pcs = pcs.autonum_pcs "
            Sql = Sql & " where ro.autonum_ro=" & Val(Me.txtAutonumRo.Text)

            Dim TB10 As New ADODB.Recordset
            TB10.Open(Sql, BD.Conexao, 3, 3)
            If Not TB10.EOF Then
                Me.txtPLAN.Text = TB10.Fields("Quanto").Value
            End If
            TB10.Close()


            Try
                Me.cbConferente.SelectedValue = tb1.Fields("CONFERENTE").Value
            Catch
                Me.cbConferente.SelectedIndex = -1
            End Try
            Try
                Me.cbEquipe.SelectedValue = tb1.Fields("EQUIPE").Value
            Catch
                Me.cbEquipe.SelectedIndex = -1
            End Try
            Try
                Me.cbModo.SelectedIndex = tb1.Fields("FORMA_OPERACAO").Value
            Catch
                Me.cbModo.SelectedIndex = -1
            End Try
        Else

            Me.txtInicio.Text = ""
            Me.txtFIM.Text = ""
            Me.lbCliente.Text = ""
            Me.lbReserva.Text = ""
            Me.lbConteiner.Text = ""
            Me.cbConferente.SelectedIndex = -1
            Me.cbEquipe.SelectedIndex = -1
            Me.cbModo.SelectedIndex = -1
            Me.txtAutonumBoo.Text = "0"
            Me.txtID_Cliente.Text = "0"
            Me.txtAutonumPatio.Text = "0"
            Me.txtAutonumRo.Text = "0"
            Me.txtTalie.Text = "0"
            Me.txtPLAN.Text = "0"

        End If

        If tb1.State = 1 Then
            tb1.Close()
        End If
        tb1 = Nothing

        CarregaEtiquetas()

        Me.txtProduto.Focus()


    End Sub

    Protected Sub txtPlanejamento_TextChanged(sender As Object, e As EventArgs) Handles txtPlanejamento.TextChanged

        If String.IsNullOrWhiteSpace(Me.txtPlanejamento.Text) Then Exit Sub

        CarregaPlanejamento()
        CarregaItensEstufados()
        cbConferente.Focus()

    End Sub

    Protected Sub btSair1_Click(sender As Object, e As EventArgs) Handles btSair1.Click
        If ValidaInicio() Then


            Dim Id As Long
            Sql = "select REDEX.SEQ_TB_TALIE.NEXTVAL from dual"
            Id = BD.Conexao.Execute(Sql).Fields(0).Value

            Sql = "INSERT INTO REDEX.TB_TALIE (AUTONUM_TALIE,"
            Sql = Sql & "autonum_patio,inicio,termino,flag_estufagem,flag_carregamento,"
            Sql = Sql & "crossdocking,autonum_boo,forma_operacao,conferente,equipe,autonum_ro,autonum_camera"
            Sql = Sql & ") values (" & Id & " ,"
            Sql = Sql & Val(Me.txtAutonumPatio.Text) & ","
            Sql = Sql & "SYSDATE,"
            Sql = Sql & "NULL,"
            Sql = Sql & "1,"
            Sql = Sql & "1,"
            Sql = Sql & "0,"
            Sql = Sql & Val(Me.txtAutonumBoo.Text) & ","
            If Me.cbModo.SelectedIndex = 1 Then
                Sql = Sql & "'A',"
            ElseIf Me.cbModo.SelectedIndex = 2 Then
                Sql = Sql & "'M',"
            End If
            Sql = Sql & Me.cbConferente.SelectedValue & ","
            Sql = Sql & Me.cbEquipe.SelectedValue & ","
            Sql = Sql & Val(Me.txtAutonumRo.Text) & "," & Me.txtAutonumCamera.Text & ")"
            BD.Conexao.Execute(Sql)


            Sql = "update redex.tb_romaneio set autonum_talie=" & Id & " where autonum_ro=" & Val(Me.txtAutonumRo.Text)
            BD.Conexao.Execute(Sql)


            Dim IdTimeLine As Long
            IdTimeLine = 0

            If Session("FLAG_FILMA_DESOVA") = 99 Then
                Dim RetornoGravacao$
                RetornoGravacao = OrdensOBJ.IniciaGravacao(Me.lbConteiner.Text, Me.txtCamera.Text, 1)

                If Left$(RetornoGravacao, 5) = "Erro=" Then

                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Atenção, não foi iniciada a gravação da filmagem da desova ' );</script>", False)
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" & RetornoGravacao & "');</script>", False)
                End If

                If Left$(RetornoGravacao, 11) = "IdTimeLine=" Then
                    IdTimeLine = Val(Mid$(RetornoGravacao, 12))
                    Sql = "UPDATE REDEX.TB_TALIE SET IDTIMELINE=" & IdTimeLine & " WHERE AUTONUM_TALIE=" & Id
                    BD.Conexao.Execute(Sql)
                End If


            End If


            CarregaPlanejamento()

        End If

    End Sub



    Function ValidaInicio() As Boolean
        If Me.txtAutonumRo.Text = "0" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Planejamento não selecionado!');</script>", False)
            Return False
        End If

        If Me.txtInicio.Text <> "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Inicio já informado!');</script>", False)
            Return False
        End If

        If Me.cbConferente.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe o conferente!');</script>", False)
            Return False
        End If

        If Me.cbEquipe.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe o Equipe!');</script>", False)
            Return False
        End If

        If Me.cbModo.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe o modo!');</script>", False)
            Return False
        End If
        Me.txtAutonumCamera.Text = "0"
        If Me.txtAutonumCamera.Text = "0" Then
            '   ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Camera não definida!');</script>", False)
            '   Return False
        End If

        'Nao pode ter um tallie para este conteiner

        Sql = String.Empty
        Sql = " Select autonum_talie from REDEX.tb_talie where autonum_patio=" & Val(Me.txtAutonumPatio.Text)
        Dim tb1 As New ADODB.Recordset
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Já existe talie aberto para este contêiner!');</script>", False)
            Return False
        End If
        tb1.Close()


        Sql = String.Empty
        Sql = "select * from redex.tb_romaneio where autonum_ro = " & Val(Me.txtAutonumRo.Text) & " and nvl(autonum_talie,0)>0 "

        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Já existe um talie aberto para este planejamento!');</script>", False)
            Return False
        End If
        tb1.Close()

        tb1 = Nothing

        Return True
    End Function


    Function ValidaFim() As Boolean
        If Me.txtAutonumRo.Text = "0" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Planejamento não selecionado!');</script>", False)
            Return False
        End If

        If Me.txtInicio.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Inicio ainda não informado!');</script>", False)
            Return False
        End If

        If Me.txtFIM.Text <> "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Final já informado!');</script>", False)
            Return False
        End If
        Dim tb1 As New ADODB.Recordset

        Sql = "SELECT AUTONUM_PATIO FROM REDEX.TB_TALIE WHERE AUTONUM_TALIE=" & Val(Me.txtTalie.Text)
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then
            If Val(tb1.Fields("autonum_patio").Value) <> Val(Me.txtAutonumPatio.Text) Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Divergencia no conteiner vinculado ao talie. Verifique com o Documental!');</script>", False)
                Return False
            End If
        End If
        tb1.Close()


        Sql = "SELECT AUTONUM_patio FROM REDEX.TB_romaneio WHERE AUTONUM_ro=" & Val(Me.txtAutonumRo.Text)
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then
            If Val(tb1.Fields("autonum_patio").Value) <> Val(Me.txtAutonumPatio.Text) Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Divergencia no conteiner vinculado ao Planejamento.Verifique com o Documental');</script>", False)
                Return False
            End If
        End If
        tb1.Close()


        Sql = "SELECT AUTONUM_talie FROM REDEX.TB_romaneio WHERE NVL(autonum_talie,0)<>0 AND autonum_talie <> " & Val(Me.txtTalie.Text) & " and AUTONUM_ro=" & Val(Me.txtAutonumRo.Text)
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Já existe outro Talie vinculado a este planejamento');</script>", False)
            Return False
        End If
        tb1.Close()


        'CONSISTE AS NOTAS FISCAIS
        If Me.ckMC.Checked = False Then
            Sql = "select SC.AUTONUM_RO "
            Sql = Sql & " from redex.tb_saida_carga sc"
            Sql = Sql & " inner join redex.tb_patio_cs pcs on sc.autonum_pcs = pcs.autonum_pcs"
            Sql = Sql & " inner join redex.tb_notas_fiscais nf on nf.autonum_nf = pcs.autonum_nf"
            Sql = Sql & " left join redex.tb_notas_itens nfi on nfi.autonum_nf = nf.autonum_nf"
            Sql = Sql & " where sc.autonum_ro = " & Val(Me.txtAutonumRo.Text)
            Sql = Sql & " and nvl(nfi.autonum_nf,0)=0"
            Sql = UCase(Sql)
            tb1.Open(Sql, BD.Conexao, 3, 3)
            If Not tb1.EOF Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Existe nota fiscal sem item estufado!');</script>", False)
                Return False
            End If
            tb1.Close()
        Else
            If Val(Me.txtPLAN.Text) <> Val(Me.txtTTL.Text) Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Existe divergencia na quantidade de itens estufados!');</script>", False)
                Return False
            End If
        End If

        Dim Lacre As String = ""
        Sql = "select nvl(lacre,'') as Lacre  from redex.tb_patio_lacres where autonum_patio=" & Val(Me.txtAutonumPatio.Text) & " and flag_ativo=1"

        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then
            Lacre = tb1.Fields("Lacre").Value.ToString
        Else
            'ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Não existe lacre para o conteiner estufado, verifique controle de lacres !');</script>", False)
        End If
        tb1.Close()

        Dim QtdeS As Long = 0
        Dim Qtde As Long = 0


        Sql = "select nvl(sum(qtde_saida),0) as qual from redex.tb_saida_carga where autonum_patio=" & Val(Me.txtAutonumPatio.Text)
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then
            QtdeS = tb1.Fields("Qual").Value
        End If
        tb1.Close()


        Sql = "select nvl(sum(qtde),0) as qual from redex.tb_romaneio_cs where autonum_ro=" & Val(Me.txtAutonumRo.Text)
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then
            Qtde = tb1.Fields("Qual").Value
        End If
        tb1.Close()

        If QtdeS <> Qtde Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Divergência de quantidade planejada e estufada !');</script>", False)
            Return False
        End If



        'DUE

        Dim TemDueLib As Boolean

        Dim tBbooDue As New ADODB.Recordset

        Sql = " SELECT distinct boo.autonum_boo "
        Sql = Sql & " FROM REDEX.tb_saida_carga sc   "
        Sql = Sql & " INNER JOIN REDEX.tb_patio_cs pcs       ON sc.autonum_pcs = pcs.autonum_pcs  "
        Sql = Sql & " left JOIN REDEX.tb_cad_embalagens emb ON pcs.autonum_emb = emb.autonum_emb  "
        Sql = Sql & " INNER JOIN REDEX.tb_notas_fiscais nf   ON pcs.autonum_nf = nf.autonum_nf  "
        Sql = Sql & " INNER JOIN REDEX.tb_booking_carga bcg  ON pcs.autonum_bcg = bcg.autonum_bcg  "
        Sql = Sql & " left JOIN REDEX.tb_cad_produtos pro   ON bcg.autonum_pro = pro.autonum_pro  "
        Sql = Sql & " INNER JOIN REDEX.tb_booking boo        ON bcg.autonum_boo = boo.autonum_boo  "
        Sql = Sql & " where sc.autonum_ro=  " & Val(Me.txtAutonumRo.Text)

        Sql = UCase(Sql)
        tBbooDue.Open(Sql, BD.Conexao, 3, 3)

        TemDueLib = False

        While Not tBbooDue.EOF


            Sql = "SELECT A.DUE , nvl(A.STATUS_DUE,0) as STATUS_DUE ,B.FLAG_LIB_SAIDA,b.descricao, nvl(a.bloqueio,0) as BLOQUEIO FROM REDEX.TB_DUE_RUC A LEFT JOIN REDEX.STATUS_DUE B ON A.STATUS_DUE=B.CODIGO WHERE AUTONUM_BOO=" & tBbooDue.Fields("autonum_boo").Value

            Sql = UCase(Sql)
            Dim tBDue As New ADODB.Recordset
            tBDue.Open(Sql, BD.Conexao, 3, 3)

            If Not tBDue.EOF Then

                'TemDUE = True

                If tBDue.Fields("STATUS_DUE").Value = 0 Then

                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Existe DUE sem status informado!');</script>", False)
                    Return False



                Else


                    If tBDue.Fields("BLOQUEIO").Value = 1 Then

                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Existe DUE com bloqueio de embarque no portal unico!');</script>", False)
                        Return False

                    Else

                        If tBDue.Fields("FLAG_LIB_SAIDA").Value = 0 Then
                            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Existe DUE com status que impede prosseguimento!');</script>", False)

                        Else
                            TemDueLib = True
                        End If
                    End If

                End If
            End If

            tBbooDue.MoveNext()
        End While


        If Not TemDueLib Then
            Sql = " SELECT SDP.autonum_sd "
            Sql = Sql & " FROM REDEX.tb_saida_carga sc   "
            Sql = Sql & " INNER JOIN REDEX.tb_patio_cs pcs       ON sc.autonum_pcs = pcs.autonum_pcs  "
            Sql = Sql & " left JOIN REDEX.tb_cad_embalagens emb ON pcs.autonum_emb = emb.autonum_emb  "
            Sql = Sql & " INNER JOIN REDEX.tb_notas_fiscais nf   ON pcs.autonum_nf = nf.autonum_nf  "
            Sql = Sql & " INNER JOIN REDEX.tb_booking_carga bcg  ON pcs.autonum_bcg = bcg.autonum_bcg  "
            Sql = Sql & " left JOIN REDEX.tb_cad_produtos pro   ON bcg.autonum_pro = pro.autonum_pro  "
            Sql = Sql & " INNER JOIN REDEX.tb_booking boo        ON bcg.autonum_boo = boo.autonum_boo  "
            Sql = Sql & " LEFT Join redex.tb_cad_sd_boo sdf On boo.autonum_boo=sdf.autonum_boo  "
            Sql = Sql & " LEFT Join redex.tb_cad_sd sdp on sdp.autonum_sd = sdf.autonum_sd   "
            Sql = Sql & " where sc.autonum_ro=  " & Val(Me.txtAutonumRo.Text)
            Sql = Sql & " AND NVL(SDP.AUTONUM_SD,0)=0 "

            Sql = UCase(Sql)
            tb1.Open(Sql, BD.Conexao, 3, 3)
            If Not tb1.EOF Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('SD de liberação nao cadastrada!');</script>", False)
                Return False
            End If
            tb1.Close()

            tb1 = Nothing
        End If




        Return True
    End Function
    Function ValidaExclusaoItem() As Boolean

        If Me.txtFIM.Text <> "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Já foi informado o fim da operação!');</script>", False)
            Return False
        End If

        Return True

    End Function
    Protected Sub btSair2_Click(sender As Object, e As EventArgs) Handles btSair2.Click
        If ValidaFim() Then

            Dim Sql As String

            Sql = "UPDATE REDEX.TB_TALIE SET TERMINO=SYSDATE,FLAG_FECHADO=1 WHERE AUTONUM_PATIO= " & Val(Me.txtAutonumPatio.Text)

            BD.Conexao.Execute(Sql)

            Sql = "UPDATE REDEX.TB_ROMANEIO SET FLAG_HISTORICO=1 WHERE AUTONUM_RO= " & Val(Me.txtAutonumRo.Text)

            BD.Conexao.Execute(Sql)

            If Session("FLAG_FILMA_DESOVA") = 99 Then

                Dim RetornoGravacao$

                Try

                    RetornoGravacao = OrdensOBJ.PararGravacao(Val(Me.txtIDTIMELINE.Text), Me.txtCamera.Text, OrdensOBJ.Agora)

                    If Left$(RetornoGravacao, 5) = "Erro=" Then
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Atenção, erro ao tentar parar a filmagem da desova ' );</script>", False)
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" & RetornoGravacao & "');</script>", False)
                    End If

                Catch ex As Exception

                End Try

            End If


            CarregaPlanejamento()

        End If
    End Sub

    Private Sub GridEstufados_RowDeleted(sender As Object, e As GridViewDeletedEventArgs) Handles GridEstufados.RowDeleted

    End Sub

    Private Sub GridEstufados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridEstufados.RowCommand

        If e.CommandName <> "Sort" And e.CommandName <> "Page" Then

            Dim Index As Integer = e.CommandArgument
            Dim Id As String
            Dim Sql As String

            'Id = GridEstufados.DataKeys((CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)).RowIndex)("AUTONUM_SC").ToString()
            Id = GridEstufados.DataKeys(Index).Item(0).ToString

            If Not Id = String.Empty Or Not Id = 0 Then

                Select Case e.CommandName

                    Case "DEL"

                        If ValidaExclusaoItem() Then

                            Dim tbDel As New ADODB.Recordset
                            Sql = "SELECT  SC.QTDE_SAIDA, sc.autonum_sc"
                            Sql = Sql & " ,sc.codproduto as codbarra, NF.AUTONUM_NF "
                            Sql = Sql & " FROM REDEX.tb_saida_carga sc  "
                            Sql = Sql & " INNER JOIN REDEX.tb_patio_cs pcs       ON sc.autonum_pcs = pcs.autonum_pcs "
                            Sql = Sql & " left JOIN REDEX.tb_cad_embalagens emb ON pcs.autonum_emb = emb.autonum_emb "
                            Sql = Sql & " INNER JOIN REDEX.tb_notas_fiscais nf   ON pcs.autonum_nf = nf.autonum_nf "
                            Sql = Sql & " INNER JOIN REDEX.tb_booking_carga bcg  ON pcs.autonum_bcg = bcg.autonum_bcg "
                            Sql = Sql & " left JOIN REDEX.tb_cad_produtos pro   ON bcg.autonum_pro = pro.autonum_pro "
                            Sql = Sql & " INNER JOIN REDEX.tb_booking boo        ON bcg.autonum_boo = boo.autonum_boo "
                            Sql = Sql & " where sc.autonum_SC=" & Id
                            tbDel.Open(Sql, BD.Conexao, 3, 3)


                            If Me.ckMC.Checked = False Then
                                Sql = "update redex.tb_romaneio_cs set estufado=nvl(estufado,0) - 1 where autonum_rcs=" & Id
                                BD.Conexao.Execute(Sql)
                            Else
                                If Not tbDel.EOF Then

                                    Sql = "update redex.tb_romaneio_cs set estufado=nvl(estufado,0) - " & Val(tbDel.Fields("QTDE_SAIDA").Value) & " where autonum_rcs=" & Id
                                    BD.Conexao.Execute(Sql)

                                    Sql = "DELETE FROM REDEX.TB_MARCANTES_RDX_ESTUFAGEM "
                                    Sql = Sql & " WHERE MARCANTE=" & Val(tbDel.Fields("CODBARRA").Value)
                                    Sql = Sql & " AND AUTONUM_NF=" & Val(tbDel.Fields("AUTONUM_NF").Value)
                                    Sql = Sql & " AND AUTONUM_RO=" & Val(Me.txtAutonumRo.Text)
                                    Sql = Sql & " AND QUANTIDADE= " & Val(tbDel.Fields("QTDE_SAIDA").Value)
                                    BD.Conexao.Execute(Sql)

                                    Sql = "UPDATE REDEX.TB_MARCANTES_RDX SET "
                                    Sql = Sql & " VOLUMES = VOLUMES + " & Val(tbDel.Fields("QTDE_SAIDA").Value)
                                    Sql = Sql & " WHERE AUTONUM=" & Val(tbDel.Fields("CODBARRA").Value)

                                    BD.Conexao.Execute(Sql)
                                End If
                            End If

                            Sql = "delete from REDEX.tb_saida_carga where autonum_sc=" & Id
                            BD.Conexao.Execute(Sql)

                            CarregaItensEstufados()
                            CarregaEtiquetas()

                        End If



                End Select

            End If

        End If



    End Sub

    Protected Sub txtProduto_TextChanged(sender As Object, e As EventArgs) Handles txtProduto.TextChanged
        If Len(txtProduto.Text) = 12 Then
            If ValidaProduto() Then
                CarregaComboNota
            Else
                If Me.txtProduto.Text <> "" Then
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Código de produto inválido!');</script>", False)
                    Me.txtCodProduto.Text = "0"
                    LimpaComboNota
                    Me.lblLote.Text = ""
                End If
            End If
        Else
        End If


    End Sub

    Private Sub LimpaComboNota()
        Me.cbNF.DataTextField = "DISPLAY"
        Me.cbNF.DataValueField = "AUTONUM"
        Dim tb1 As New ADODB.Recordset

        Sql = " Select DISTINCT I.NF AS DISPLAY ,I.AUTONUM_NF AS AUTONUM FROM REDEX.TB_MARCANTES_RDX M INNER JOIN "
        Sql = Sql & " REDEX.TB_TALIE T ON M.AUTONUM_TALIE=T.AUTONUM_TALIE INNER JOIN "
        Sql = Sql & " REDEX.TB_TALIE_ITEM I ON T.AUTONUM_TALIE=I.AUTONUM_TALIE  "
        Sql = Sql & " WHERE M.AUTONUM = 0 "
        tb1.Open(Sql, BD.Conexao, 1, 1)


        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, tb1, "VIEW_NF")

            Me.cbNF.DataSource = Ds.Tables(0)
            Me.cbNF.DataBind()
            Ds.Dispose()
        End Using

        Me.cbConferente.Items.Insert(0, "--NF--")

        If tb1.State = 1 Then
            tb1.Close()
        End If

        tb1 = Nothing

    End Sub

    Private Sub CarregaComboNota()

        Me.cbNF.DataTextField = "DISPLAY"
        Me.cbNF.DataValueField = "AUTONUM"
        Dim tb1 As New ADODB.Recordset

        Sql = " Select DISTINCT I.NF AS DISPLAY ,I.AUTONUM_NF AS AUTONUM FROM REDEX.TB_MARCANTES_RDX M INNER JOIN "
        Sql = Sql & " REDEX.TB_TALIE T ON M.AUTONUM_TALIE=T.AUTONUM_TALIE INNER JOIN "
        Sql = Sql & " REDEX.TB_TALIE_ITEM I ON T.AUTONUM_TALIE=I.AUTONUM_TALIE AND I.AUTONUM_NF IN ( "
        Sql = Sql & " SELECT PCS.AUTONUM_NF FROM REDEX.TB_PATIO_CS PCS INNER JOIN REDEX.TB_ROMANEIO_CS RCS ON "
        Sql = Sql & " PCS.AUTONUM_PCS=RCS.AUTONUM_PCS AND RCS.AUTONUM_RO=" & Val(Me.txtAutonumRo.Text)
        Sql = Sql & " )"
        Sql = Sql & " WHERE M.AUTONUM = " & Val(Me.txtProduto.Text)
        tb1.Open(Sql, BD.Conexao, 1, 1)


        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, tb1, "VIEW_NF")

            Me.cbNF.DataSource = Ds.Tables(0)
            Me.cbNF.DataBind()
            Ds.Dispose()
        End Using

        Me.cbNF.Items.Insert(0, "--NF--")

        If tb1.State = 1 Then
            tb1.Close()
        End If

        tb1 = Nothing

    End Sub

    Sub Estufar()

        If Me.ckMC.Checked = False Then
            Sql = "select ro.autonum_ro,nvl(ro.autonum_patio,0) as autonum_patio, nvl(pcs.autonum_pcs,0) as autonum_pcs,"
            Sql = Sql & " nvl(pcs.autonum_nf,0) as autonum_nf, nvl(pcs.autonum_emb,0) as autonum_emb ,"
            Sql = Sql & " nvl(pcs.bruto,0) as bruto, nvl(pcs.comprimento,0) as comprimento ,"
            Sql = Sql & " nvl(pcs.largura,0) as largura, nvl(pcs.altura,0) as altura ,"
            Sql = Sql & " nvl(pcs.autonum_pro,0) as autonum_pro,nvl(rcs.autonum_rcs,0) as autonum_rcs "
            Sql = Sql & " from redex.tb_romaneio ro "
            Sql = Sql & " inner join redex.tb_romaneio_cs rcs on ro.autonum_ro = rcs.autonum_ro "
            Sql = Sql & " inner join redex.VW_patio_cs pcs on rcs.autonum_pcs = pcs.autonum_pcs "
            Sql = Sql & " where rcs.autonum_rcs=" & Val(txtCodProduto.Text)
            Sql = Sql & " and pcs.codproduto='" & Microsoft.VisualBasic.Mid(txtProduto.Text, 1, 8) & "'"
        Else
            Sql = "select ro.autonum_ro,nvl(ro.autonum_patio,0) as autonum_patio, nvl(pcs.autonum_pcs,0) as autonum_pcs,"
            Sql = Sql & " nvl(pcs.autonum_nf,0) as autonum_nf, nvl(pcs.autonum_emb,0) as autonum_emb ,"
            Sql = Sql & " nvl(pcs.bruto,0) as bruto, nvl(pcs.comprimento,0) as comprimento ,"
            Sql = Sql & " nvl(pcs.largura,0) as largura, nvl(pcs.altura,0) as altura ,"
            Sql = Sql & " nvl(pcs.autonum_pro,0) as autonum_pro,nvl(rcs.autonum_rcs,0) as autonum_rcs "
            Sql = Sql & " from redex.tb_romaneio ro "
            Sql = Sql & " inner join redex.tb_romaneio_cs rcs on ro.autonum_ro = rcs.autonum_ro "
            Sql = Sql & " inner join redex.VW_patio_cs pcs on rcs.autonum_pcs = pcs.autonum_pcs "
            Sql = Sql & " where ro.autonum_ro=" & Val(Me.txtAutonumRo.Text)
            Sql = Sql & " and pcs.autonum_nf=" & Me.cbNF.SelectedValue
        End If

        Dim tb1 As New ADODB.Recordset
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then

            Sql = "INSERT INTO REDEX.TB_AMR_NF_SAIDA (AUTONUM, AUTONUM_NFI, AUTONUM_PATIO, QTDE_ESTUFADA, AUTONUM_PATIO_CS"
            Sql = Sql & ") VALUES ("
            Sql = Sql & " redex.seq_tb_amr_nf_saida.nextval"
            Sql = Sql & "," & tb1.Fields("Autonum_NF").Value
            Sql = Sql & "," & tb1.Fields("Autonum_Patio").Value
            Sql = Sql & ",1"
            Sql = Sql & "," & tb1.Fields("autonum_pcs").Value
            Sql = Sql & ")"
            BD.Conexao.Execute(Sql.ToUpper)


            Dim Autonum_SC As Long

            Sql = "Select REDEX.seq_SAIDA_CARGA.nextval As QUAL FROM DUAL"
            Autonum_SC = BD.Conexao.Execute(Sql).Fields(0).Value


            Sql = "INSERT INTO REDEX.TB_SAIDA_CARGA (AUTONUM_SC, AUTONUM_PCS,"
            Sql = Sql & " QTDE_SAIDA,AUTONUM_EMB,PESO_BRUTO,ALTURA,COMPRIMENTO,LARGURA,VOLUME,autonum_patio,ID_CONTEINER,MERCADORIA"
            Sql = Sql & ",DATA_ESTUFAGEM,autonum_nfi,autonum_ro,autonum_talie,codproduto,autonum_rcs) VALUES ("
            Sql = Sql & Autonum_SC
            Sql = Sql & "," & tb1.Fields("autonum_pcs").Value
            If Me.ckMC.Checked = False Then
                Sql = Sql & ",1"
            Else
                Sql = Sql & "," & Val(Me.txtQtde.Text)
            End If
            Sql = Sql & "," & tb1.Fields("autonum_EMB").Value
            Sql = Sql & "," & tb1.Fields("BRUTO").Value.ToString.Replace(",", ".")
            Sql = Sql & "," & tb1.Fields("COMPRIMENTO").Value.ToString.Replace(",", ".")
            Sql = Sql & "," & tb1.Fields("LARGURA").Value.ToString.Replace(",", ".")
            Sql = Sql & "," & tb1.Fields("ALTURA").Value.ToString.Replace(",", ".")
            Sql = Sql & "," & (tb1.Fields("ALTURA").Value * tb1.Fields("COMPRIMENTO").Value * tb1.Fields("LARGURA").Value).ToString.Replace(",", ".")
            Sql = Sql & "," & tb1.Fields("autonum_patio").Value
            Sql = Sql & ",'" & Me.lbConteiner.Text & "'"
            Sql = Sql & "," & tb1.Fields("autonum_pro").Value
            Sql = Sql & ", sysdate"
            Sql = Sql & "," & tb1.Fields("autonum_nf").Value
            Sql = Sql & "," & tb1.Fields("autonum_ro").Value
            Sql = Sql & "," & Val(Me.txtTalie.Text)
            Sql = Sql & ",'" & txtProduto.Text & "'"
            Sql = Sql & "," & tb1.Fields("autonum_rcs").Value
            Sql = Sql & ")"
            BD.Conexao.Execute(Sql.ToUpper)



            Sql = "INSERT INTO REDEX.TB_SAIDA_CARGA_COL (AUTONUM_SC,USUARIO,DT,BROWSER_NAME,BROWSER_VERSION,MOBILEDEVICEMODEL,MOBILEDEVICEMANUFACTURER,FLAG_MOBILE,IP_CONNECTION) VALUES ("
            Sql = Sql & Autonum_SC & ","
            Sql = Sql & Session("AUTONUMUSUARIO") & ","
            Sql = Sql & "SYSDATE,"
            Sql = Sql & "'" & Session("BROWSER_NAME") & "',"
            Sql = Sql & "'" & Session("BROWSER_VERSION") & "',"
            Sql = Sql & "'" & Session("MOBILEDEVICEMODEL") & "',"
            Sql = Sql & "'" & Session("MOBILEDEVICEMANUFACTURER") & "',"
            Sql = Sql & IIf(Session("ISMOBILEDEVICE") = False, 0, 1) & ","
            Sql = Sql & "'" & Session("IP_CONNECTION") & "'"
            Sql = Sql & ") "

            BD.Conexao.Execute(Sql.ToUpper)

            If Me.ckMC.Checked = True Then
                Sql = " INSERT INTO REDEX.TB_MARCANTES_RDX_ESTUFAGEM "
                Sql = Sql & " (MARCANTE  ,"
                Sql = Sql & " QUANTIDADE  , "
                Sql = Sql & " AUTONUM_NF,"
                Sql = Sql & " AUTONUM_RO ) VALUES ("
                Sql = Sql & Val(Me.txtProduto.Text) & ","
                Sql = Sql & Val(Me.txtQtde.Text) & ","
                Sql = Sql & Me.cbNF.SelectedValue & ","
                Sql = Sql & Val(Me.txtPlanejamento.Text)
                Sql = Sql & ")"
                BD.Conexao.Execute(Sql.ToUpper)

                Sql = "UPDATE REDEX.TB_MARCANTES_RDX SET VOLUMES=VOLUMES-" & Val(Me.txtQtde.Text)
                Sql = Sql & " WHERE AUTONUM=" & Val(Me.txtProduto.Text)
                BD.Conexao.Execute(Sql.ToUpper)

            End If



            Sql = "update REDEX.tb_patio set ef='F' where autonum_patio = " & tb1.Fields("Autonum_Patio").Value & " AND EF<>'F'"
            BD.Conexao.Execute(Sql.ToUpper)

            If Me.ckMC.Checked = False Then
                Sql = "update redex.tb_romaneio_cs set estufado=nvl(estufado,0) + 1 where autonum_rcs=" & tb1.Fields("autonum_rcs").Value
                BD.Conexao.Execute(Sql.ToUpper)
            Else
                Sql = "update redex.tb_romaneio_cs set estufado=nvl(estufado,0) + " & Val(Me.txtQtde.Text) & "  where autonum_ro = " & Val(Me.txtPlanejamento.Text) & " and autonum_pcs=" & tb1.Fields("autonum_pcs").Value
                BD.Conexao.Execute(Sql.ToUpper)
            End If


            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Item estufado com sucesso!');</script>", False)

            CarregaEtiquetas()

            Me.txtCodProduto.Text = "0"
            Me.txtProduto.Text = ""
            Me.txtQtde.Text = ""
            LimpaComboNota()



            If GridEtiquetas.Rows.Count = 0 Then
                Me.btSair2.Focus()
            Else
                Me.txtProduto.Focus()
            End If


        End If

        tb1.Close()
        tb1 = Nothing
    End Sub


    Function ValidaProduto() As Boolean

        Me.txtCodProduto.Text = "0"
        'Me.lblReserva.Text = ""
        'Me.lblNF.Text = ""
        Me.lblLote.Text = ""

        If Me.txtAutonumRo.Text = "0" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Planejamento nao selecionado!');</script>", False)
            Return False
        End If

        If Me.txtInicio.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Primeiro informe o inicio da operação!');</script>", False)
            Return False
        End If

        If Me.txtFIM.Text <> "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Já foi informado o fim da operação!');</script>", False)
            Return False
        End If

        If Me.ckMC.Checked = False Then
            Sql = "select 1"
            Sql = Sql & " from redex.tb_romaneio ro "
            Sql = Sql & " inner join redex.tb_romaneio_cs rcs on ro.autonum_ro = rcs.autonum_ro "
            Sql = Sql & " inner join redex.VW_patio_cs pcs on rcs.autonum_pcs = pcs.autonum_pcs "
            Sql = Sql & " where ro.autonum_ro=" & Val(Me.txtAutonumRo.Text)
            Sql = Sql & " and pcs.codproduto='" & Microsoft.VisualBasic.Mid(txtProduto.Text, 1, 8) & "'"
        Else
            Sql = " SELECT "
            Sql = Sql & " 1 "
            Sql = Sql & " FROM REDEX.tb_marcantes_rdx m "
            Sql = Sql & " inner join REDEX.tb_booking boo on m.autonum_boo = boo.autonum_boo "
            Sql = Sql & " left join REDEX.tb_saida_carga sc  "
            Sql = Sql & " on LPAD (TRIM (TO_CHAR (m.autonum)), 12, 0) = sc.codproduto "
            Sql = Sql & " where 0=0 "
            'Sql = Sql & " and sc.codproduto is null  "
            Sql = Sql & " and m.autonum_boo in "
            Sql = Sql & " ( "
            Sql = Sql & " select bcg.autonum_boo from redex.tb_romaneio_cs rcs "
            Sql = Sql & " inner join redex.tb_patio_cs pcs on rcs.autonum_pcs = pcs.autonum_pcs "
            Sql = Sql & " inner join redex.tb_booking_carga bcg on pcs.autonum_bcg = bcg.autonum_bcg "
            Sql = Sql & " Where rcs.Autonum_Ro = " & Val(Me.txtAutonumRo.Text)
            Sql = Sql & " group by bcg.autonum_boo "
            Sql = Sql & " ) "
            Sql = Sql & " order by boo.os,LPAD (TRIM (TO_CHAR (m.autonum)), 12, 0) "

        End If

        Dim tb1 As New ADODB.Recordset
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If tb1.EOF Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Produto não localizado no planejamento');</script>", False)
            tb1.Close()
            Return False
        End If
        tb1.Close()

        If Me.ckMC.Checked = False Then
            Sql = "select '1' from redex.tb_saida_carga where codproduto='" & Me.txtProduto.Text & "'"

            tb1.Open(Sql, BD.Conexao, 3, 3)
            If Not tb1.EOF Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Produto já estufado');</script>", False)
                tb1.Close()
                Return False
            End If
            tb1.Close()
        End If

        'Qtde planejada
        Dim Qtde_P As Long
        Dim Qtde_E As Long

        Qtde_P = 0
        Qtde_E = 0

        If Me.ckMC.Checked = False Then

            Sql = "select NVL(sum(rcs.qtde),0) as Quanto "
            Sql = Sql & " from redex.tb_romaneio ro "
            Sql = Sql & " inner join redex.tb_romaneio_cs rcs on ro.autonum_ro = rcs.autonum_ro "
            Sql = Sql & " inner join redex.TB_patio_cs pcs on rcs.autonum_pcs = pcs.autonum_pcs "
            Sql = Sql & " where ro.autonum_ro=" & Val(Me.txtAutonumRo.Text)

            Sql = Sql & " and pcs.codproduto='" & Microsoft.VisualBasic.Mid(txtProduto.Text, 1, 8) & "'"

            tb1.Open(Sql, BD.Conexao, 3, 3)
            If Not tb1.EOF Then
                Qtde_P = tb1.Fields("Quanto").Value
            End If
            tb1.Close()
        Else
            Qtde_P = Val(Me.txtPLAN.Text)
        End If

        'Qtde estufada
        Sql = "select NVL(sum(sc.QTDE_SAIDA),0) as Quanto from"
        Sql = Sql & " redex.tb_saida_carga sc"
        Sql = Sql & " where"
        Sql = Sql & " autonum_ro=" & Val(Me.txtAutonumRo.Text)
        If Me.ckMC.Checked = False Then
            Sql = Sql & " and codproduto='" & Microsoft.VisualBasic.Mid(txtProduto.Text, 1, 8) & "'"
        Else
            Sql = Sql & " and codproduto in ("
            Sql = Sql & " SELECT LPAD (TRIM (TO_CHAR (m.autonum)), 12, 0) "
            Sql = Sql & " FROM REDEX.tb_marcantes_rdx m "
            Sql = Sql & " inner join REDEX.tb_booking boo on m.autonum_boo = boo.autonum_boo "
            Sql = Sql & " INNER join REDEX.tb_saida_carga sc  "
            Sql = Sql & " on LPAD (TRIM (TO_CHAR (m.autonum)), 12, 0) = sc.codproduto "
            Sql = Sql & " where "
            Sql = Sql & " m.autonum_boo in "
            Sql = Sql & " ( "
            Sql = Sql & " select bcg.autonum_boo from redex.tb_romaneio_cs rcs "
            Sql = Sql & " inner join redex.tb_patio_cs pcs on rcs.autonum_pcs = pcs.autonum_pcs "
            Sql = Sql & " inner join redex.tb_booking_carga bcg on pcs.autonum_bcg = bcg.autonum_bcg "
            Sql = Sql & " Where rcs.Autonum_Ro = " & Val(Me.txtAutonumRo.Text)
            Sql = Sql & " ) "
            Sql = Sql & " ) "
        End If
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then
            Qtde_E = tb1.Fields("Quanto").Value
        End If
        tb1.Close()

        If Qtde_E >= Qtde_P Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Todas a cargas planejadas para este produto já foram estufadas');</script>", False)
            Return False
        End If

        If Me.ckMC.Checked = False Then
            Sql = "select rcs.qtde,rcs.autonum_pcs,pcs.codproduto,rcs.autonum_rcs,boo.reference, boo.os, nf.num_nf "
            Sql = Sql & " from REDEX.tb_romaneio ro "
            Sql = Sql & " inner join REDEX.tb_romaneio_cs rcs on ro.autonum_ro = rcs.autonum_ro "
            Sql = Sql & " inner join REDEX.tb_patio_cs pcs on rcs.autonum_pcs=pcs.autonum_pcs"
            Sql = Sql & " inner join REDEX.tb_booking_carga bcg on pcs.autonum_bcg = bcg.autonum_bcg "
            Sql = Sql & " inner join REDEX.tb_booking boo on bcg.autonum_boo = boo.autonum_boo "
            Sql = Sql & " left join REDEX.tb_notas_fiscais nf on pcs.autonum_nf = nf.autonum_nf "
            Sql = Sql & " inner join REDEX.vw_saldo_item sld on pcs.autonum_pcs = sld.autonum_pcs "
            Sql = Sql & " left join (select autonum_rcs,sum(qtde_saida) as saida from redex.tb_saida_carga where autonum_ro=" & Val(Me.txtAutonumRo.Text) & " group by autonum_rcs) sc on rcs.autonum_rcs=sc.autonum_rcs"
            Sql = Sql & " where ro.autonum_ro=" & Val(Me.txtAutonumRo.Text)
            Sql = Sql & " and pcs.codproduto='" & Microsoft.VisualBasic.Mid(txtProduto.Text, 1, 8) & "'"
            Sql = Sql & " and nvl(sc.saida,0) < rcs.qtde"

            tb1.Open(Sql, BD.Conexao, 3, 3)

            If tb1.EOF Then
                'MsgBox "Nao consta item disponivel em estoque ou todos os itens deste produto ja foram estufados" & vbCr & "Estufagem Cancelada"
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Nao consta item disponivel em estoque ou todos os itens deste produto ja foram estufados');</script>", False)
                tb1.Close()
                Return False
            End If
            tb1.Close()
        End If

        If Me.ckMC.Checked = False Then
            Sql = "select rcs.qtde,rcs.autonum_pcs,pcs.codproduto,nvl(rcs.autonum_rcs,0) as autonum_rcs,nvl(boo.reference,'') as reference, boo.os, nvl(nf.num_nf,'') as num_nf "
            Sql = Sql & " from redex.tb_romaneio ro "
            Sql = Sql & " inner join redex.tb_romaneio_cs rcs on ro.autonum_ro = rcs.autonum_ro "
            Sql = Sql & " inner join redex.vw_patio_cs pcs on rcs.autonum_pcs = pcs.autonum_pcs "
            Sql = Sql & " left join redex.tb_booking_carga bcg on pcs.autonum_bcg = bcg.autonum_bcg "
            Sql = Sql & " left join redex.tb_booking boo on bcg.autonum_boo = boo.autonum_boo "
            Sql = Sql & " left join redex.tb_notas_fiscais nf on pcs.autonum_nf = nf.autonum_nf "
            Sql = Sql & " where ro.autonum_ro=" & Val(Me.txtAutonumRo.Text)
            Sql = Sql & " and pcs.codproduto='" & Microsoft.VisualBasic.Mid(txtProduto.Text, 1, 8) & "'"

            tb1.Open(Sql, BD.Conexao, 3, 3)
            If tb1.EOF Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Erro na busca dos dados da carga');</script>", False)
                tb1.Close()
                Return False
            Else
                If tb1.Fields("autonum_rcs").Value = 0 Then
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Item de Romaneio nao encontrado');</script>", False)
                    tb1.Close()
                    Return False
                End If
                If tb1.Fields("reference").Value.ToString = "" Then
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Reserva nao encontrada');</script>", False)
                    tb1.Close()
                    Return False
                End If
                If tb1.Fields("num_nf").Value.ToString = "" Then
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('NF nao encontrada');</script>", False)
                    tb1.Close()
                    Return False
                End If
                If tb1.Fields("os").Value.ToString = "" Then
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('OS nao encontrada');</script>", False)
                    tb1.Close()
                    Return False
                End If

                Me.txtCodProduto.Text = tb1.Fields("autonum_rcs").Value.ToString
                Me.lblLote.Text = tb1.Fields("OS").Value.ToString

            End If
            tb1.Close()
            tb1 = Nothing
        End If

        Return True

    End Function

    Protected Sub GridEtiquetas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridEtiquetas.SelectedIndexChanged

    End Sub

    Private Sub GridEtiquetas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridEtiquetas.PageIndexChanging
        GridEtiquetas.PageIndex = e.NewPageIndex
        CarregaEtiquetas()
    End Sub

    Private Sub GridEstufados_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridEstufados.PageIndexChanging
        GridEstufados.PageIndex = e.NewPageIndex
        CarregaItensEstufados()
    End Sub


    Protected Sub cbConferente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConferente.SelectedIndexChanged

    End Sub

    Protected Sub cbEquipe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEquipe.SelectedIndexChanged

    End Sub

    Protected Sub txtTTL_TextChanged(sender As Object, e As EventArgs) Handles txtPLAN.TextChanged

    End Sub

    Protected Sub btSair3_Click(sender As Object, e As EventArgs) Handles btSair3.Click
        If Len(txtProduto.Text) = 12 Then
            If ValidaDadosEst Then
                If ValidaProduto() Then

                    Estufar()
                    CarregaItensEstufados()
                End If
            End If
        Else
            If Me.txtProduto.Text <> "" Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Código de produto inválido!');</script>", False)
                Me.txtCodProduto.Text = "0"
                'Me.lblReserva.Text = ""
                'Me.lblNF.Text = ""
                Me.lblLote.Text = ""
            End If
        End If
    End Sub

    Private Function ValidaDadosEst() As Boolean
        If Me.cbNF.SelectedIndex <= 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Nota fiscal não informada!');</script>", False)
            Return False
        End If

        If Me.txtQtde.Text = "0" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade não informada!');</script>", False)
            Return False
        End If

        'Verificar se existe esta quantidade disponivel nesta nota
        Dim Sql As String
        Sql = " Select M.VOLUMES,I.QTDE_DESCARGA, I.NF,I.AUTONUM_NF FROM REDEX.TB_MARCANTES_RDX M "
        Sql = Sql & " INNER JOIN REDEX.TB_TALIE T ON M.AUTONUM_TALIE=T.AUTONUM_TALIE INNER JOIN "
        Sql = Sql & " REDEX.TB_TALIE_ITEM I ON T.AUTONUM_TALIE=I.AUTONUM_TALIE "
        Sql = Sql & " WHERE M.AUTONUM = " & Val(Me.txtProduto.Text)
        Sql = Sql & " And I.AUTONUM_NF=" & Me.cbNF.SelectedValue

        Dim tb1 As New ADODB.Recordset
        tb1.Open(Sql, BD.Conexao, 3, 3)
        If Not tb1.EOF Then
            If tb1.Fields("QTDE_DESCARGA").Value < Val(Me.txtQtde.Text) Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade indisponível para esta NOTA!');</script>", False)
                Return False
            End If
            If Val(Me.txtQtde.Text) > tb1.Fields("VOLUMES").Value Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade indisponível neste Marcante!');</script>", False)
                Return False
            End If
        End If

        'Quanto daquela nota já foi estufada neste romaneio x Planejamento NF
        Dim QtePlan As Long = 0
        Dim QteEst As Long = 0

        Sql = " Select sum(rcs.qtde) as qto "
        Sql = Sql & " From redex.tb_romaneio ro INNER Join redex.tb_romaneio_cs rcs "
        Sql = Sql & " On ro.autonum_ro = rcs.autonum_ro "
        Sql = Sql & " INNER Join redex.tb_patio_cs pcs ON rcs.autonum_pcs = pcs.autonum_pcs"
        Sql = Sql & " WHERE ro.autonum_ro = " & Val(Me.txtPlanejamento.Text)
        Sql = Sql & " And autonum_nf=" & Me.cbNF.SelectedValue
        Dim tb0 As New ADODB.Recordset
        tb0.Open(Sql, BD.Conexao, 3, 3)
        If Not tb0.EOF Then
            QtePlan = tb0.Fields("qto").Value
        End If
        tb0.Close()


        Sql = "SELECT NVL(SUM(QTDE_SAIDA),0) AS QTO FROM REDEX.TB_SAIDA_CARGA "
        Sql = Sql & " WHERE AUTONUM_NFI= " & Me.cbNF.SelectedValue
        Sql = Sql & " And AUTONUM_RO=" & Val(Me.txtPlanejamento.Text)
        Dim TB2 As New ADODB.Recordset
        TB2.Open(Sql, BD.Conexao, 3, 3)
        If Not TB2.EOF Then
            QteEst = TB2.Fields("QTO").Value
        End If
        TB2.Close()

        If Val(txtQtde.Text) + QteEst > QtePlan Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade excederá o planejado para a Nota!');</script>", False)
            Return False
        End If

        Return True

    End Function

    Protected Sub cbNF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNF.SelectedIndexChanged

    End Sub

    Protected Sub btnFotos_Click(sender As Object, e As EventArgs) Handles btnFotos.Click

        If Val(Me.txtAutonumPatio.Text) = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Selecione um Contêiner.');</script>", False)
            Exit Sub
        End If
        Dim url As String = ConfigurationManager.AppSettings("UrlSiteFotos").ToString()
        url = "http://localhost:51044"
        Response.Redirect(url & "/Fotos.aspx?idTipoProcesso=2&autonumCntrBl=0&autonumPatio=" & Session("PATIO") & "&lote=0&autonumCsOp=0&autonumPatioOp=0&autonumCsrdx=0&autonumPatiordx=" & Me.txtAutonumPatio.Text)
        '  Response.Write("<script>window.open('http://www.google.com.br/','_blank');</script>")
        'Response.Write("<script>window.open('" + url + "/Fotos.aspx?idTipoProcesso=2&autonumCntrBl=0&autonumPatio=" + Session("PATIO").ToString() + "&lote=0&autonumCsOp=0&autonumPatioOp=0&autonumCsrdx=0&autonumPatiordx=" + Me.txtAutonumPatio.Text + "','_blank');</script>")

    End Sub
End Class