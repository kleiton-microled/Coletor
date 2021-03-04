Imports System.Data.OleDb

Public Class InventarioCSF2_new
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

            txtMarcante.Focus()

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

        Me.txtMercadoria.Text = ""
        Me.txtQtde.Text = ""
        Me.txtQtdePos.Text = ""
        Me.txtNVOCC.Text = ""
        Me.txtVolume.Text = ""

        Me.txtIMO.Text = ""
        Me.txtBL.Text = ""
        Me.txtLote.Text = ""
        Me.txtYard.Text = ""

        Me.txtlocalpos.Text = ""
        Me.txtEtiqueta.Text = ""
        Me.txtANVISA.Text = ""
        Me.txtSistema.Text = ""



        CarregarItens(0, "")


        Me.cbArm.SelectedIndex = -1
        Me.cbItem.SelectedIndex = -1
        Me.cbMotivoPos.SelectedIndex = -1
        Me.cbOcupacao_CT.SelectedValue = 0
        Me.cbOcupacao_CT.Visible = False


    End Sub



    Protected Sub btFiltra_Click(sender As Object, e As EventArgs) Handles btFiltra.Click
        Carrega_Dados(Me.txtMarcante.Text)

        If Me.cbMotivoPos.Items.Count > 1 Then
            Me.cbMotivoPos.SelectedIndex = 1
        End If
    End Sub

    Sub Carrega_Dados(ByVal QualMarcante As String)

        Dim OrdensOBJ As InventarioCS_f2 = InventarioCS_f2.PopulaDados(QualMarcante, Session("AUTONUMPATIO"))

        Limpa()
        If OrdensOBJ IsNot Nothing Then

            If OrdensOBJ.Patio.ToString = Session("AUTONUMPATIO").ToString Then

                Me.txtMercadoria.Text = OrdensOBJ.Mercadoria.ToString

                Me.txtEntrada.Text = OrdensOBJ.Entrada.ToString
                Me.txtConteiner.Text = OrdensOBJ.Conteiner.ToString
                Me.txtCliente.Text = OrdensOBJ.Cliente.ToString
                Me.txtVolume.Text = OrdensOBJ.Volume.ToString & " m3"

                If OrdensOBJ.IMO.ToString <> "0" Then
                    Me.txtIMO.Text = OrdensOBJ.IMO.ToString
                Else
                    Me.txtIMO.Text = ""
                End If
                Me.txtNVOCC.Text = OrdensOBJ.Nvocc.ToString
                Me.txtBL.Text = OrdensOBJ.BL.ToString
                Me.txtLote.Text = OrdensOBJ.Lote.ToString
                Me.txtANVISA.Text = OrdensOBJ.ANVISA.ToString
                Me.txtSistema.Text = OrdensOBJ.Sistema.ToString
                CarregarItens(OrdensOBJ.Lote, Me.txtMarcante.Text)

            Else

                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Pátio divergente do usuário logado');</script>", False)

            End If


        Else
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Marcante não encontrado em estoque');</script>", False)
            txtMarcante.Text = ""


        End If


    End Sub


    Sub Carrega_Dados_Item(ByVal QualMarcante As String)

        Dim OrdensOBJ As InventarioCS_f2 = InventarioCS_f2.PopulaItem(QualMarcante)


        If OrdensOBJ IsNot Nothing Then
            Me.txtQtde.Text = OrdensOBJ.Quantidade.ToString
            Me.txtQtdePos.Text = OrdensOBJ.Quantidade.ToString
            Me.txtEmbalagem.Text = OrdensOBJ.Embalagem.ToString
            Me.txtLocal.Text = OrdensOBJ.Local.ToString
            If OrdensOBJ.Yard.ToString <> "-" Then
                Me.txtYard.Text = OrdensOBJ.Yard.ToString
            Else
                Me.txtYard.Text = ""
            End If

        End If

    End Sub

    Private Sub CarregarItens(ByVal QualLote As String, ByVal QualMarcante As String)


        Me.cbItem.DataTextField = "DISPLAY"
        Me.cbItem.DataValueField = "AUTONUM"

        Me.cbItem.DataSource = InventarioCS_f2.ConsultarItensLote(QualLote, QualMarcante)
        Me.cbItem.DataBind()


        Me.cbItem.Items.Insert(0, "--Item--")
        Me.cbItem.SelectedIndex = 0

        'Carrega_Dados_Item(Me.cbItem.SelectedValue)

        If Me.cbItem.Items.Count = 2 Then
            Me.cbItem.SelectedIndex = 1

            Carrega_Dados_Item(QualMarcante)

        Else
            Me.cbItem.SelectedIndex = 0
        End If

    End Sub

    Protected Sub cbItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbItem.SelectedIndexChanged
        If Me.cbItem.SelectedIndex > 0 Then
            Carrega_Dados_Item(Me.cbItem.SelectedValue)
        End If
    End Sub




    Protected Sub txtConteiner_TextChanged(sender As Object, e As EventArgs) Handles txtConteiner.TextChanged

    End Sub

    Protected Sub cbArm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbArm.SelectedIndexChanged
        'Carrega_Yard(Val(cbArm.SelectedValue))
        Seta_Ocupacao(Val(cbArm.SelectedValue))

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
        'Dim Sql As String
        'Sql = "SELECT ' LOTE: ' || TO_CHAR(LOTE) || ' ' || QTDE || ' ' || EMBALAGEM AS DISPLAY FROM OPERADOR.VW_INVENT_ARMAZEM WHERE AUTONUM_ARMAZEM=" & Id_Armazem & " And Posicao='" & Local & "'"

        'Dim Rst As New ADODB.Recordset

        'Try
        '    Rst.Open(Sql, BD.Conexao, 3, 3)
        'Catch ex As Exception
        '    GravaLog(ex.Message.ToString() & " " & Sql)
        'End Try

        'If Not Rst.EOF Then
        '    Me.txtCargaNoLocal.Text = Rst.Fields("DISPLAY").Value.ToString
        'Else
        '    Me.txtCargaNoLocal.Text = ""
        'End If
        'Rst.Close()



    End Sub
    Private Sub Seta_Ocupacao(AutonumArm As Long)
        Dim Rst As New ADODB.Recordset
        Dim Sql$

        Sql = "SELECT NVL(FLAG_CT,0) AS FLAG_CT,NVL(OCUPACAO_CT,0) AS OCUPACAO_CT FROM SGIPA.TB_ARMAZENS_IPA WHERE AUTONUM=" & AutonumArm
        Rst.Open(Sql, BD.Conexao, 3, 3)
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
        If Validar() Then

            Dim Sql As String
            Dim SqlF As String

            Dim Sql2 As String

            Dim SqlHist As String
            Dim SqlHist2 As String

            Dim AutonumCs As Long
            Dim AutonumCY As Long

            Dim Tipo As String
            Tipo = Left(Me.cbItem.SelectedValue, 1)

            If Tipo = "C" Then
                AutonumCs = Val(Mid(Me.cbItem.SelectedValue, 2))
            ElseIf Tipo = "Y" Then
                AutonumCY = Val(Mid(Me.cbItem.SelectedValue, 2))

                If Me.txtSistema.Text <> "R" Then
                    Sql = "SELECT AUTONUM_CS FROM SGIPA.TB_CARGA_SOLTA_YARD WHERE AUTONUM={0}"
                Else
                    Sql = "SELECT AUTONUM_PATIOCS AS AUTONUM_CS FROM REDEX.TB_CARGA_SOLTA_YARD WHERE AUTONUM={0}"
                End If
                SqlF = String.Format(Sql, AutonumCY)

                Dim Rst As New ADODB.Recordset
                Rst.Open(SqlF, BD.Conexao, 3, 3)

                If Not Rst.EOF Then
                    AutonumCs = Rst.Fields("AUTONUM_CS").Value
                End If
                Rst.Close()

                If Me.txtSistema.Text <> "R" Then
                    If AutonumCs = 0 Then
                        If Me.txtMarcante.Text <> "" Then
                            Sql = "SELECT AUTONUMCS FROM OPERADOR.VW_INVENT_ARMAZEM WHERE MARCANTE='" & Me.txtMarcante.Text & "'"
                            Dim Rsm As New ADODB.Recordset
                            Rsm.Open(Sql, BD.Conexao, 3, 3)

                            If Not Rsm.EOF Then
                                AutonumCs = Rsm.Fields("AUTONUMCS").Value
                            End If
                            Rsm.Close()

                        End If
                    End If
                End If
            End If

            Dim MensPatio As String
            MensPatio = InventarioCS_f2.ValidaRegrasArmazem(AutonumCs, Me.txtYard.Text.ToUpper, Me.cbArm.SelectedValue)
            If MensPatio <> "OK" Then
                MensPatio = "Conflito com Regra de Armazem :" & MensPatio
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" & MensPatio & "');</script>", False)
                Exit Sub
            End If

            Dim idCsYard As Long
            Dim tbId As New ADODB.Recordset

            If Me.txtSistema.Text <> "R" Then
                tbId.Open("SELECT SGIPA.SEQ_CARGA_SOLTA_YARD.NEXTVAL AS QUAL FROM DUAL", BD.Conexao, 3, 3)
            Else
                tbId.Open("SELECT REDEX.SEQ_CARGA_SOLTA_YARD.NEXTVAL AS QUAL FROM DUAL", BD.Conexao, 3, 3)
            End If

            idCsYard = tbId.Fields("QUAL").Value

            If Me.txtSistema.Text <> "R" Then
                Sql = "INSERT INTO SGIPA.TB_CARGA_SOLTA_YARD (AUTONUM,AUTONUM_CS,ARMAZEM,YARD,ORIGEM,QUANTIDADE,MOTIVO_COL) VALUES "
            Else
                Sql = "INSERT INTO REDEX.TB_CARGA_SOLTA_YARD (AUTONUM,AUTONUM_PATIOCS,ARMAZEM,YARD,ORIGEM,QUANTIDADE,MOTIVO_COL) VALUES "
            End If
            Sql = Sql & "(" & idCsYard & ",{0},{1},'{2}','I',{3},{4})"
            SqlF = String.Format(Sql, AutonumCs, Me.cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper, Val(Me.txtQtdePos.Text), Me.cbMotivoPos.SelectedValue)

            If Me.txtSistema.Text <> "R" Then
                Sql2 = "UPDATE SGIPA.TB_MARCANTES Set AUTONUM_CS_YARD=" & idCsYard & " WHERE AUTONUM= " & Val(Me.txtMarcante.Text)
            Else
                Sql2 = "UPDATE REDEX.TB_MARCANTES_RDX Set AUTONUM_CS_YARD=" & idCsYard & " WHERE AUTONUM= " & Val(Me.txtMarcante.Text)
            End If


            Dim AutonumHS As Long
            Dim tbHS As New ADODB.Recordset

            If Me.txtSistema.Text <> "R" Then
                tbHS.Open("SELECT SGIPA.SEQ_HIST_SHIFTING_CS.NEXTVAL AS QUAL FROM DUAL", BD.Conexao, 3, 3)
            Else
                tbHS.Open("SELECT REDEX.SEQ_HIST_SHIFTING_CS.NEXTVAL AS QUAL FROM DUAL", BD.Conexao, 3, 3)
            End If

            AutonumHS = tbHS.Fields("QUAL").Value

            SqlHist = ""
            If Me.txtSistema.Text <> "R" Then
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
            SqlHist = SqlHist & Val(Me.txtMarcante.Text) & ","
            SqlHist = SqlHist & Me.cbArm.SelectedValue & ","
            SqlHist = SqlHist & "'" & Me.txtlocalpos.Text.ToUpper & "',"
            SqlHist = SqlHist & "SYSDATE,"
            SqlHist = SqlHist & Session("AUTONUMUSUARIO") & ","
            SqlHist = SqlHist & "'" & Me.txtYard.Text & "',"
            SqlHist = SqlHist & Val(Me.txtLote.Text) & ","
            SqlHist = SqlHist & Me.cbMotivoPos.SelectedValue
            SqlHist = SqlHist & ")"

            If Me.txtSistema.Text <> "R" Then
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

            Dim Sql3 As String

            Sql3 = ""
            If Me.cbOcupacao_CT.Visible = True Then
                Sql3 = "UPDATE SGIPA.TB_ARMAZENS_IPA Set OCUPACAO_CT=" & Me.cbOcupacao_CT.SelectedValue & " WHERE AUTONUM=" & Me.cbArm.SelectedValue
            End If


            Try
                'BD.Conexao.BeginTrans()

                Try
                    BD.Conexao.Execute(SqlF.ToString(), BD.LinhasAfetadas)
                Catch ex As Exception
                    GravaLog(ex.Message.ToString() & " " & SqlF)
                End Try

                If Sql2 <> String.Empty Then
                    Try
                        BD.Conexao.Execute(Sql2.ToString(), BD.LinhasAfetadas)
                    Catch ex As Exception
                        GravaLog(ex.Message.ToString() & " " & Sql2)
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

                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro Inserido!');</script>", False)

                Limpa()

                Me.txtLote.Text = ""
                Me.txtMarcante.Text = ""
                Me.txtMarcante.Focus()

                btSalvar.Enabled = True

            Catch ex As Exception
                Throw New Exception("Erro. Tente novamente." & ex.Message())
                BD.Conexao.RollbackTrans()
                btSalvar.Enabled = True
            End Try
        End If
    End Sub




    Private Function Valida_Quantidade(ByVal Autonumcs As Long, ByVal Quant As Double) As Boolean

        Dim Rst As New ADODB.Recordset
        Dim Sql As String

        Dim quant_alocada As String = "0"
        Dim quant_estoque As String = "0"

        Sql = "SELECT NVL(sum(quantidade),0) quant_alocada FROM SGIPA.TB_CARGA_SOLTA_YARD WHERE AUTONUM_CS={0} "
        Sql = String.Format(Sql, Autonumcs)

        Try
            Rst.Open(Sql, BD.Conexao, 3, 3)
        Catch ex As Exception
            GravaLog(ex.Message.ToString() & " " & Sql)
        End Try

        If Not Rst.EOF Then
            quant_alocada = Rst.Fields("quant_alocada").Value.ToString()
        End If

        Rst.Close()

        Sql = "SELECT (quantidade_real-quantidade_saida) quant_estoque FROM SGIPA.TB_CARGA_SOLTA WHERE AUTONUM={0} "
        Sql = String.Format(Sql, Autonumcs)

        Try
            Rst.Open(Sql, BD.Conexao, 3, 3)
        Catch ex As Exception
            GravaLog(ex.Message.ToString() & " " & Sql)
        End Try

        If Not Rst.EOF Then
            quant_estoque = Rst.Fields("quant_estoque").Value.ToString()
        End If

        Rst.Close()

        If (quant_alocada + Quant) > quant_estoque Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Item não informado.');</script>", False)
            Return False
        Else
            Return True
        End If

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
                        Sql = Sql & " AND YARD NOT IN ('CAM','CANCC','GOUT')"

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

    End Sub



    Protected Sub txtEntrada_TextChanged(sender As Object, e As EventArgs) Handles txtEntrada.TextChanged

    End Sub



    Protected Sub cbLocalPOS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLocalPOS.SelectedIndexChanged
        'Mostra_Carga_No_Local(cbArm.SelectedValue, cbLocalPOS.SelectedValue)
    End Sub



    Private Sub txtlocalpos_TextChanged(sender As Object, e As System.EventArgs) Handles txtlocalpos.TextChanged
        'Mostra_Carga_No_Local(cbArm.SelectedValue, Me.txtlocalpos.Text.ToUpper)



    End Sub

    Protected Sub cbMotivoPos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMotivoPos.SelectedIndexChanged

    End Sub

    Protected Sub txtLote_TextChanged(sender As Object, e As EventArgs) Handles txtLote.TextChanged

    End Sub

    Protected Sub btFiltra0_Click(sender As Object, e As EventArgs) Handles btFiltra0.Click
        Dim Sql As String
        Dim Cod_Bar As String
        Dim Yard As String
        Dim Pos As String
        Dim Pos1 As String
        Yard = Me.txtEtiqueta.Text.Replace("-", "")
        Sql = ""
        Pos1 = ""
        Cod_Bar = Microsoft.VisualBasic.Left(Yard, 2)
        Pos = Microsoft.VisualBasic.Mid(Yard, 3)
        If Len(Pos) = 4 Then
            Pos1 = Microsoft.VisualBasic.Left(Pos, 3) & "01" & Microsoft.VisualBasic.Right(Pos, 1)
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


                If Me.txtlocalpos.Text.Trim = "SAIDA" Or Me.txtlocalpos.Text.Trim = "TREM" Or Me.txtlocalpos.Text.Trim = "ENTREGA" Then
                    Me.cbMotivoPos.SelectedValue = 8
                    Exit Sub
                End If

                If Me.txtlocalpos.Text.Trim = "BAL" Then
                    Me.cbMotivoPos.SelectedValue = 6
                    Exit Sub
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


                If Me.txtYard.Text.Trim = "" And Me.txtlocalpos.Text <> "" Then
                    Me.cbMotivoPos.SelectedValue = 12
                    Exit Sub
                End If

                If Me.txtlocalpos.Text.Trim <> "" And Me.txtlocalpos.Text.Trim <> "" Then
                    Me.cbMotivoPos.SelectedValue = 1
                    Exit Sub
                End If




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

            Carrega_Dados(Me.txtMarcante.Text)

            If txtMarcante.Text <> "" Then

                If Me.cbMotivoPos.Items.Count > 1 Then
                    Me.cbMotivoPos.SelectedIndex = 1
                End If

                Me.txtEtiqueta.Focus()

            Else

                Me.txtMarcante.Focus()

            End If

        End If

    End Sub

    Protected Sub btSair0_Click(sender As Object, e As EventArgs) Handles btSair0.Click

        Session("FLAG_REDEX_SEM_MARCANTE") = 1

        Response.Redirect("InventarioCS.aspx")

    End Sub

End Class