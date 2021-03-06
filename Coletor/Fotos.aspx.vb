﻿Imports System.IO

Public Class Fotos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
        '        Session("IP_CONNECTION") = Server.HtmlEncode(Request.Cookies("IP_CONNECTION").Value)
        '    Catch ex As Exception
        '        Response.Redirect("Index.aspx")
        '    End Try
        'End If   

        Dim idTipoProcesso = Val(Request.QueryString("idTipoProcesso").ToString())
        Dim autonumCntrBl = Val(Request.QueryString("autonumCntrBl").ToString())
        Dim autonumPatio = Val(Request.QueryString("autonumPatio").ToString())
        Dim lote = Val(Request.QueryString("lote").ToString())
        Dim autonumCsOp = Val(Request.QueryString("autonumCsOp").ToString())
        Dim autonumPatioOp = Val(Request.QueryString("autonumPatioOp").ToString())
        Dim autonumCsrdx = Val(Request.QueryString("autonumCsrdx").ToString())
        Dim autonumPatiordx = Val(Request.QueryString("autonumPatiordx").ToString())


        CarregarNomeProcesso(idTipoProcesso)

        If autonumCntrBl > 0 Then

            CarregarSiglaConteiner(autonumCntrBl)

            Me.lblConteinerLoteSelecionado.Text = Me.lblConteinerLoteSelecionado.Text & " - " & lote

            CarregarEtapas(idTipoProcesso, autonumCntrBl, autonumPatio, autonumCsOp, lote, 0, 0)

            If Request.QueryString("idWorkflowFoto") IsNot Nothing Then

                Dim idWorkflowFoto = Val(Request.QueryString("idWorkflowFoto").ToString())
                Dim pagina = Val(IIf(Request.QueryString("pagina") Is Nothing, "1", Request.QueryString("pagina")))

                CarregarNomeEtapa(idWorkflowFoto)
                CarregarFotos(idWorkflowFoto, autonumCntrBl, 0,pagina)

                Me.qtdF.Text = pagina
                Me.pnlPrincipal.Visible = False
                Me.pnlDetalhes.Visible = True
            End If

        End If
        If autonumPatiordx > 0 Then

            CarregarSiglaConteinerrdx(autonumPatiordx)

            Carregarreserva(autonumCsrdx)


            CarregarEtapas(idTipoProcesso, autonumCntrBl, autonumPatio, autonumCsOp, lote, autonumPatiordx, autonumCsrdx)

            If Request.QueryString("idWorkflowFoto") IsNot Nothing Then

                Dim idWorkflowFoto = Val(Request.QueryString("idWorkflowFoto").ToString())
                Dim pagina = Val(IIf(Request.QueryString("pagina") Is Nothing, "1", Request.QueryString("pagina")))

                CarregarNomeEtapa(idWorkflowFoto)
                CarregarFotos(idWorkflowFoto, 0, autonumPatiordx, pagina)

                Me.qtdF.Text = pagina
                Me.pnlPrincipal.Visible = False
                Me.pnlDetalhes.Visible = True
            End If

        End If

    End Sub

    Private Sub CarregarNomeProcesso(ByVal idTipoProcesso As Integer)

        Dim NomeProcesso As String = OracleDAO.ExecuteScalar("SELECT DESCR FROM SGIPA.TB_TIPOS_PROCESSO WHERE ID = " & idTipoProcesso)

        Me.lblTipoProcesso.Text = NomeProcesso
        Me.lblTipoProcessoDetalhes.Text = NomeProcesso

    End Sub

    Private Sub CarregarNomeEtapa(ByVal idEtapa As Integer)

        Dim NomeEtapa As String = OracleDAO.ExecuteScalar("SELECT DESCR_FOTO FROM SGIPA.TB_WORKFLOW_FOTO WHERE ID = " & idEtapa)

        Me.lblEtapaSelecionada.Text = NomeEtapa

    End Sub

    Private Sub CarregarFotos(ByVal idEtapa As Integer, ByVal autonumCntrBl As Long, ByVal autonumCntrrdx As Long, ByVal pagina As Integer)

        Dim DsImagens As DataTable = OracleDAO.List("       
SELECT IMAGEM, row_num, TOTAL_LINHAS FROM (
SELECT IMAGEM, ROWNUM row_num, TOTAL_LINHAS FROM (
            SELECT IMAGEM,count(*) over() TOTAL_LINHAS FROM SGIPA.TB_FOTO_PROCESSO 
                WHERE ID_WORKFLOW_FOTO = " & idEtapa & " AND 
                AUTONUM_CNTR_BL = " & autonumCntrBl & " AND
                AUTONUM_PATIO_RDX = " & autonumCntrrdx & " ORDER BY ID
            )) WHERE row_num =" & pagina & "")

        If DsImagens IsNot Nothing Then
            If DsImagens.Rows.Count > 0 Then

                Me.qtdFT.Text = DsImagens.Rows(0)("TOTAL_LINHAS").ToString()

                If Not String.IsNullOrEmpty(DsImagens.Rows(0)("IMAGEM")) Then
                    Me.pbImagemDisplay.ImageUrl = Path.Combine("uploads", DsImagens.Rows(0)("IMAGEM").ToString())
                End If

            Else
                Me.qtdFT.Text = "0"
                Me.qtdF.Text = "1"
            End If
        End If

    End Sub

    Private Sub CarregarSiglaConteiner(ByVal autonumCntrBl As Integer)

        Dim SiglaConteiner As String = OracleDAO.ExecuteScalar("SELECT ID_CONTEINER FROM SGIPA.TB_CNTR_BL WHERE AUTONUM = " & autonumCntrBl)

        Me.lblConteinerLoteSelecionado.Text = SiglaConteiner
        Me.lblConteinerLoteSelecionadoDetalhes.Text = SiglaConteiner

    End Sub
    Private Sub CarregarSiglaConteinerrdx(ByVal autonumCntrrdx As Long)

        Dim SiglaConteiner As String = OracleDAO.ExecuteScalar("SELECT ID_CONTEINER FROM REDEX.TB_PATIO  WHERE AUTONUM_PATIO = " & autonumCntrrdx)

        Me.lblConteinerLoteSelecionado.Text = SiglaConteiner
        Me.lblConteinerLoteSelecionadoDetalhes.Text = SiglaConteiner

    End Sub
    Private Sub Carregarreserva(ByVal autonumcsrdx As Long)

        Dim reservapcs As String = OracleDAO.ExecuteScalar("SELECT  C.REFERENCE from REDEX.TB_PATIO_CS A INNER JOIN REDEX.TB_BOOKING_CARGA B ON A.AUTONUM_BCG=B.AUTONUM_BCG  INNER JOIN REDEX.TB_BOOKING C ON  C.AUTONUM_BOO=B.AUTONUM_BOO WHERE A.AUTONUM_PCS= " & autonumcsrdx)
        Me.lblConteinerLoteSelecionado.Text = Me.lblConteinerLoteSelecionado.Text & " - " & reservapcs

    End Sub

    Private Sub CarregarEtapas(ByVal idTipoProcesso As Integer, ByVal autonumCntrBl As Long, ByVal autonumPatio As Long, ByVal autonumCsOp As Long, ByVal lote As Long, autonumPatiordx As Long, autonumCsrdx As Long)

        Me.gdvEtapas.DataSource = OracleDAO.List(
            String.Format("
                SELECT
                    A.ID, 
                    A.ID_TIPO_PROCESSO,
                    A.DESCR_FOTO,
                    A.QUALIFICADOR, 
                    A.FLAG_OBRIGATORIO,
                    A.FLAG_AVARIA,
                    (SELECT 
                        DECODE(COUNT(1),0,'-',COUNT(1)) 
                            FROM SGIPA.TB_FOTO_PROCESSO 
                        WHERE ID_WORKFLOW_FOTO = A.ID 
                            AND AUTONUM_CNTR_BL = {1}
                            AND AUTONUM_PATIO = {2}
                            AND AUTONUM_CS_OP = {3}
                            AND BL = {4}
                            AND AUTONUM_PATIO_RDX = {5}
                            AND AUTONUM_CS_RDX = {6}
                                                    ) QTDE_FOTOS
                FROM 
                    SGIPA.TB_WORKFLOW_FOTO A
                WHERE 
                    A.ID_TIPO_PROCESSO = {0} 
                ORDER BY 
                    A.DESCR_FOTO", idTipoProcesso, autonumCntrBl, autonumPatio, autonumCsOp, lote, autonumPatiordx, autonumCsrdx))

        Me.gdvEtapas.DataBind()

    End Sub

    Protected Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        Me.pnlDetalhes.Visible = False
        Me.pnlPrincipal.Visible = True
    End Sub

    Protected Sub brnProximaFoto_Click(sender As Object, e As ImageClickEventArgs) Handles brnProximaFoto.Click

        Dim idTipoProcesso = Val(Request.QueryString("idTipoProcesso").ToString())
        Dim autonumCntrBl = Val(Request.QueryString("autonumCntrBl").ToString())
        Dim autonumPatio = Val(Request.QueryString("autonumPatio").ToString())
        Dim lote = Val(Request.QueryString("lote").ToString())
        Dim autonumCsOp = Val(Request.QueryString("autonumCsOp").ToString())
        Dim autonumPatioOp = Val(Request.QueryString("autonumPatioOp").ToString())
        Dim autonumCsrdx = Val(Request.QueryString("autonumCsrdx").ToString())
        Dim autonumPatiordx = Val(Request.QueryString("autonumPatiordx").ToString())
        Dim idWorkflowFoto = Val(Request.QueryString("idWorkflowFoto").ToString())

        Dim paginaAtual = qtdF.Text
        If paginaAtual < Val(qtdFT.Text) Then
            paginaAtual = paginaAtual + 1
            qtdF.Text = paginaAtual
            Response.Redirect("Fotos.aspx?idTipoProcesso=" & idTipoProcesso & "&autonumCntrBl=" & Request.QueryString("autonumCntrBl").ToString() & "&autonumPatio=" & Request.QueryString("autonumPatio").ToString() & "&lote=" & Request.QueryString("lote").ToString() & "&autonumCsOp=" & Request.QueryString("autonumCsOp").ToString() & "&autonumPatioOp=" & Request.QueryString("autonumPatioOp").ToString() & "&idWorkflowFoto=" & idWorkflowFoto & "&pagina=" & paginaAtual & "")
        End If

    End Sub

    Protected Sub btnFotoAnterior_Click(sender As Object, e As ImageClickEventArgs) Handles btnFotoAnterior.Click

        Dim idTipoProcesso = Val(Request.QueryString("idTipoProcesso").ToString())
        Dim autonumCntrBl = Val(Request.QueryString("autonumCntrBl").ToString())
        Dim autonumPatio = Val(Request.QueryString("autonumPatio").ToString())
        Dim lote = Val(Request.QueryString("lote").ToString())
        Dim autonumCsOp = Val(Request.QueryString("autonumCsOp").ToString())
        Dim autonumPatioOp = Val(Request.QueryString("autonumPatioOp").ToString())
        Dim autonumCsrdx = Val(Request.QueryString("autonumCsrdx").ToString())
        Dim autonumPatiordx = Val(Request.QueryString("autonumPatiordx").ToString())
        Dim idWorkflowFoto = Val(Request.QueryString("idWorkflowFoto").ToString())

        Dim paginaAtual = qtdF.Text
        If paginaAtual > 1 Then
            paginaAtual = paginaAtual - 1
            qtdF.Text = paginaAtual
            Response.Redirect("Fotos.aspx?idTipoProcesso=" & idTipoProcesso & "&autonumCntrBl=" & Request.QueryString("autonumCntrBl").ToString() & "&autonumPatio=" & Request.QueryString("autonumPatio").ToString() & "&lote=" & Request.QueryString("lote").ToString() & "&autonumCsOp=" & Request.QueryString("autonumCsOp").ToString() & "&autonumPatioOp=" & Request.QueryString("autonumPatioOp").ToString() & "&autonumCsrdx=" & Request.QueryString("autonumCsrdx").ToString() & "&idWorkflowFoto=" & idWorkflowFoto & "&pagina=" & paginaAtual & "")
        End If

    End Sub

    Private Sub ExibeFoto(ByVal paginaAtual As String, ByVal totalPaginas As String, idWorkflowFoto As String, ByVal autonumCntrBl As String, ByVal autonumCntrrdx As String)

        If paginaAtual >= 0 And paginaAtual <= totalPaginas Then

            Dim DsImagens As DataTable = OracleDAO.List("
            SELECT IMAGEM FROM SGIPA.TB_FOTO_PROCESSO 
                WHERE ID_WORKFLOW_FOTO = " & idWorkflowFoto & " 
                AND AUTONUM_CNTR_BL = " & autonumCntrBl & " 
                AND AUTONUM_PATIO_RDX = " & autonumCntrrdx & " 
                AND ROWNUM = " & paginaAtual & " ORDER BY ID")

            If DsImagens IsNot Nothing Then
                If DsImagens.Rows.Count > 0 Then
                    If Not String.IsNullOrEmpty(DsImagens.Rows(0)("IMAGEM")) Then
                        Me.pbImagemDisplay.ImageUrl = DsImagens.Rows(0)("IMAGEM").ToString()
                    End If
                End If
            End If

        End If
    End Sub

    Protected Sub gdvEtapas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gdvEtapas.SelectedIndexChanged

    End Sub
End Class