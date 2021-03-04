Imports AjaxControlToolkit
Imports System.Data.OleDb
Public Class Monitoramento
    Inherits System.Web.UI.Page

    Dim Monitoramento As New Monitora
    Dim intInicio As Integer
    Dim intTamanhoPagina As Integer
    Dim QtdRegistros As Integer
    Dim Usuario As New Login

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim SMgr As ScriptManager = ScriptManager.GetCurrent(Page)
        SMgr.SetFocus(Me.txtConteiner)

        If Session("LOGADO") Is Nothing Then
            Response.Redirect("Index.aspx")
        End If
        
        If Not Page.IsPostBack Then
            ViewState("Inicio") = 0
            Consultar()
        End If

    End Sub

    Private Sub Consultar()

        If Not txtConteiner.Text = String.Empty Then

            If Usuario.UsuarioConsultaReefer(Session("USUARIO").ToString()) Then
                PanelConsultaReeefer.Visible = True
                lblPerm.Visible = False
            Else
                lblPerm.Visible = True
                PanelConsultaReeefer.Visible = False
                PanelConsultaReeefer.Visible = False
                Exit Sub
            End If

            Using Conexao As New OleDbConnection(BD.StringConexao())
                Using Adaptador As New OleDbDataAdapter(Monitoramento.Consultar(txtConteiner.Text.ToUpper()), Conexao)

                    intInicio = ViewState("Inicio")
                    ViewState("tamanhoPagina") = 1

                    Dim Ds1 As New DataSet
                    Adaptador.Fill(Ds1, intInicio, ViewState("tamanhoPagina"), "TB_MONITORA_REEFER")

                    QtdRegistros = Monitoramento.ConsultarTotalRegistros(txtConteiner.Text.ToUpper())

                    If Ds1.Tables(0).Rows.Count > 0 Then

                        Repeater1.DataSource = Ds1
                        Repeater1.DataBind()

                        lblPrimeiro.Text = intInicio + 1
                        lblUltimo.Text = QtdRegistros

                        txtTempMedicaoChegada.Enabled = False

                        btAnterior.Visible = True
                        btProximo.Visible = True
                        lblPrimeiro.Visible = True
                        lblUltimo.Visible = True
                        lblDe.Visible = True

                        If Not lblPrimeiro.Text = QtdRegistros Then
                            btProximo.Enabled = True
                        Else
                            btProximo.Enabled = False
                        End If

                        If intInicio = 0 Then
                            btAnterior.Enabled = False
                        Else
                            btAnterior.Enabled = True
                        End If

                    Else
                        btAnterior.Visible = False
                        btProximo.Visible = False
                        lblPrimeiro.Visible = False
                        lblUltimo.Visible = False
                        lblDe.Visible = False
                    End If

                End Using
            End Using

        End If

    End Sub

    Protected Sub txtConteiner_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtConteiner.TextChanged

        If Not txtConteiner.Text.Replace("_", "").Replace("-", "") = String.Empty Then
            CarregarDados(txtConteiner.Text.ToUpper())
            Consultar()
        End If

    End Sub

    Private Sub CarregarTemperaturaChegada(ByVal Conteiner As String)

        If Not Monitoramento.ConsultarTemperaturaChegada(Conteiner) = String.Empty Then
            txtTempMedicaoChegada_MaskedEditExtender.Enabled = False
            txtTempMedicaoChegada.Text = Monitoramento.ConsultarTemperaturaChegada(Conteiner)
        End If

    End Sub

    Private Sub CarregarDados(ByVal Conteiner As String)

        Dim MonitoramentoOBJ As Monitora = Monitoramento.ConsultarPorConteiner(Conteiner, 1)

        If MonitoramentoOBJ IsNot Nothing Then

            If MonitoramentoOBJ.ConsultarQuantidadeConteiner(Conteiner, 1) Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('O Sistema Localizou mais de uma unidade com o final informado. Para continuar, digite o código completo do contêiner.');location.href='Monitoramento.aspx';</script>", False)
                Exit Sub
            End If

            txtConteiner.Text = MonitoramentoOBJ.Conteiner
            txtTamanho.Text = MonitoramentoOBJ.Tamanho
            txtTipo.Text = MonitoramentoOBJ.Tipo
            txtLinha.Text = MonitoramentoOBJ.Line
            txtTemperatura.Text = MonitoramentoOBJ.Temperatura
            txtTemperaturaEscala.Text = MonitoramentoOBJ.Escala
            txtUmidade.Text = MonitoramentoOBJ.Umidade
            txtVentilacao.Text = MonitoramentoOBJ.Ventilacao
            txtNavio.Text = MonitoramentoOBJ.NavioViagem
            txtReserva.Text = MonitoramentoOBJ.Reserva
            txtDataEntrada.Text = MonitoramentoOBJ.Data_Ent_Temp
            txtPosPatio.Text = MonitoramentoOBJ.Yard
            txtSistema.Text = MonitoramentoOBJ.Sistema
            txtCodigo.Text = MonitoramentoOBJ.Codigo

            txtTempMedicaoChegadaEscala.Text = txtTemperaturaEscala.Text.Trim
            txtTempMedicaoFornecidaEscala.Text = txtTemperaturaEscala.Text.Trim
            txtTempMedicaoRetornoEscala.Text = txtTemperaturaEscala.Text.Trim

            CarregarTemperaturaChegada(Conteiner)

            txtConteiner.Enabled = False

        Else
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Contêiner não encontrado.');location.href='Monitoramento.aspx';</script>", False)
        End If

    End Sub

    Protected Sub btSalvar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btSalvar.Click

        If Validar() Then

            Dim MonitoramentoOBJ As New Monitora

            MonitoramentoOBJ.Conteiner = txtConteiner.Text.ToUpper().Trim
            MonitoramentoOBJ.Tamanho = txtTamanho.Text.Trim
            MonitoramentoOBJ.Tipo = txtTipo.Text.Trim
            MonitoramentoOBJ.Line = txtLinha.Text.Trim
            MonitoramentoOBJ.Data_Ent_Temp = txtDataEntrada.Text.Trim
            MonitoramentoOBJ.Umidade = txtUmidade.Text.Trim
            MonitoramentoOBJ.Ventilacao = txtVentilacao.Text.Trim
            MonitoramentoOBJ.Temperatura = txtTemperatura.Text.Trim
            MonitoramentoOBJ.Escala = txtTemperaturaEscala.Text.Trim
            MonitoramentoOBJ.NavioViagem = txtNavio.Text.Trim
            MonitoramentoOBJ.Reserva = txtReserva.Text.Trim
            MonitoramentoOBJ.Yard = txtPosPatio.Text.Trim
            MonitoramentoOBJ.Sistema = txtSistema.Text.Trim
            MonitoramentoOBJ.Codigo = txtCodigo.Text.Trim
            MonitoramentoOBJ.TemperaturaRetorno = txtTempMedicaoRetorno.Text.Replace("_", "").Trim
            MonitoramentoOBJ.TemperaturaChegada = txtTempMedicaoChegada.Text.Replace("_", "").Trim

            Try
                If MonitoramentoOBJ.Inserir(MonitoramentoOBJ) Then
                    txtTempMedicaoChegada.Enabled = False
                    ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Registro Inserido!');location.href='Monitoramento.aspx';</script>", False)
                    Consultar()
                End If
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Erro. Tente Novamente.');</script>", False)
            End Try

            LimparCampos()
            txtConteiner.Focus()

        End If

    End Sub

    Private Sub LimparCampos()

        txtCodigo.Text = String.Empty
        txtConteiner.Text = String.Empty
        txtDataEntrada.Text = String.Empty
        txtLinha.Text = String.Empty
        txtNavio.Text = String.Empty
        txtPosPatio.Text = String.Empty
        txtReserva.Text = String.Empty
        txtSistema.Text = String.Empty
        txtTamanho.Text = String.Empty
        txtTemperatura.Text = String.Empty
        txtTemperaturaEscala.Text = String.Empty
        txtTempMedicaoChegada.Text = String.Empty
        txtTempMedicaoChegadaEscala.Text = String.Empty
        txtTempMedicaoFornecida.Text = String.Empty
        txtTempMedicaoFornecidaEscala.Text = String.Empty
        txtTempMedicaoRetorno.Text = String.Empty
        txtTempMedicaoRetornoEscala.Text = String.Empty
        txtTipo.Text = String.Empty
        txtUmidade.Text = String.Empty
        txtUmidadeMedicao.Text = String.Empty
        txtVentilacao.Text = String.Empty
        txtVentilacaoMedicao.Text = String.Empty

        txtConteiner.Enabled = True

    End Sub

    Private Function Validar()

        Dim Conteiner As String = Replace(Replace(txtConteiner.Text, "_", ""), "-", "")

        Dim TemperaturaChegada As String = Replace(Replace(Replace(txtTempMedicaoChegada.Text.Trim, "_", ""), "-", ""), ".", "")
        Dim TemperaturaRetorno As String = Replace(Replace(Replace(txtTempMedicaoRetorno.Text.Trim, "_", ""), "-", ""), ".", "")
        Dim TemperaturaFornecida As String = Replace(Replace(Replace(txtTempMedicaoFornecida.Text.Trim, "_", ""), "-", ""), ".", "")

        Dim TemperaturaChegadaEscala As String = Replace(Replace(txtTempMedicaoChegadaEscala.Text.ToUpper().Trim, ".", ""), "-", "")
        Dim TemperaturaRetornoEscala As String = Replace(Replace(txtTempMedicaoRetornoEscala.Text.ToUpper().Trim, ".", ""), "-", "")
        Dim TemperaturaFornecidaEscala As String = Replace(Replace(txtTempMedicaoFornecidaEscala.Text.ToUpper().Trim, ".", ""), "-", "")

        If Conteiner = String.Empty Then
            txtConteiner.BackColor = Drawing.Color.Yellow
            Return False
        Else
            txtConteiner.BackColor = Drawing.Color.White
        End If

        If txtTempMedicaoChegada.Enabled Then
            If TemperaturaChegada = String.Empty Then
                txtTempMedicaoChegada.BackColor = Drawing.Color.Yellow
                Return False
            Else
                txtTempMedicaoChegada.BackColor = Drawing.Color.White
            End If
        End If

        If txtTemperaturaEscala.Text.Trim = String.Empty Then
            txtTemperaturaEscala.BackColor = Drawing.Color.Yellow
            Return False
        Else
            txtTemperaturaEscala.BackColor = Drawing.Color.White
        End If

        If TemperaturaFornecida = String.Empty Then
            txtTempMedicaoFornecida.BackColor = Drawing.Color.Yellow
            Return False
        Else
            txtTempMedicaoFornecida.BackColor = Drawing.Color.White
        End If

        If TemperaturaRetorno = String.Empty Then
            txtTempMedicaoRetorno.BackColor = Drawing.Color.Yellow
            Return False
        Else
            txtTempMedicaoRetorno.BackColor = Drawing.Color.White
        End If

        If txtUmidade.Text.Trim = String.Empty Then
            txtUmidade.BackColor = Drawing.Color.Yellow
            Return False
        Else
            txtUmidade.BackColor = Drawing.Color.White
        End If

        If txtVentilacao.Text.Trim = String.Empty Then
            txtVentilacao.BackColor = Drawing.Color.Yellow
            Return False
        Else
            txtVentilacao.BackColor = Drawing.Color.White
        End If

        If TemperaturaChegadaEscala <> "C" And TemperaturaChegadaEscala <> "F" Then
            txtTempMedicaoChegadaEscala.BackColor = Drawing.Color.Yellow
            Return False
        Else
            txtTempMedicaoChegadaEscala.BackColor = Drawing.Color.White
        End If

        If TemperaturaFornecidaEscala <> "C" And TemperaturaFornecidaEscala <> "F" Then
            txtTempMedicaoFornecidaEscala.BackColor = Drawing.Color.Yellow
            Return False
        Else
            txtTempMedicaoFornecidaEscala.BackColor = Drawing.Color.White
        End If

        If TemperaturaRetornoEscala <> "C" And TemperaturaRetornoEscala <> "F" Then
            txtTempMedicaoRetornoEscala.BackColor = Drawing.Color.Yellow
            Return False
        Else
            txtTempMedicaoRetornoEscala.BackColor = Drawing.Color.White
        End If

        Return True

    End Function

    Protected Sub btConsultar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btConsultar.Click

        Me.TabContainer.ActiveTab = TabContainer.Tabs(1)

        If Not txtConteiner.Text.Replace("-", "").Replace("-", "") = String.Empty Then
            Consultar()
        End If

    End Sub

    Protected Sub btSair_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btNovoRegistro.Click
        Response.Redirect("Monitoramento.aspx")
    End Sub

    Protected Sub btProximo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btProximo.Click

        Dim contadorDatalist As Integer = Repeater1.Items.Count

        intInicio = ViewState("Inicio") + ViewState("tamanhoPagina")
        ViewState("Inicio") = intInicio

        If contadorDatalist < ViewState("tamanhoPagina") Then
            ViewState("Inicio") = ViewState("Inicio") - ViewState("tamanhoPagina")
        Else
            intInicio = ViewState("Inicio") - ViewState("tamanhoPagina")
        End If

        Consultar()

    End Sub

    Protected Sub btAnterior_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btAnterior.Click

        intInicio = ViewState("Inicio") - ViewState("tamanhoPagina")

        ViewState("Inicio") = intInicio
        If intInicio <= 0 Then
            ViewState("Inicio") = 0
        End If

        Consultar()

    End Sub

End Class