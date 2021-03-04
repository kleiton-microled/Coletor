Public Class WebForm4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.lblAutonumCS.Text = Ordens.QualAutonumCS(Val(Session("AUTONUMCNTR").ToString), Val(Session("AUTONUMBL").ToString), Val(Session("ITEM").ToString))

            CarregarEmbalagens()
            CarregarMarcantesAV()

            If Session("EMBALAGEM") <> 0 Then
                cbEmbalagem.SelectedValue = Session("EMBALAGEM")
            End If

            LimpaAvarias()

            If Session("REFOB") = 1 Then
                Me.txtQtdeA.Text = "1"
                Me.txtPesoA.Text = Session("PESO")

            Else
                Me.txtQtdeA.Text = "0"
                Me.txtPesoA.Text = "0"
            End If


            CarregalblIAV()

            CarregarAvarias(Me.lblAutonumCS.Text, Me.lblSEQ.Text)


        End If

    End Sub

    Protected Sub CarregarAvarias(AutonumCS As Long, AutonumSeq As Long)
        Dim sql As String
        Dim tb1 As New ADODB.Recordset
        Dim tb2 As New ADODB.Recordset


        LimpaAvarias()


        Dim QtdeAnt As Integer
        QtdeAnt = 0

        sql = "Select quantidade_avariada,peso_avariado,local,tipo,complemento,providencia,COMPL_IPA,MARCANTE,REFERENCIA "
        sql = sql & " from sgipa.tb_avarias_cs "
        If AutonumCs > 0 Then
            sql = sql & " where autonumcs=" & AutonumCs
        Else
            sql = sql & " where bl=" & Session("AUTONUMBL") & " And item=" & Session("ITEM") & " And autonumcs=0"
        End If
        sql = sql & " and nvl(SEQ_AVARIAS_CS_COL,0)=" & AutonumSeq

        tb1.Open(sql, BD.Conexao, 1, 1)
        If Not tb1.EOF Then

            Me.txtPesoA.Text = tb1.Fields("peso_avariado").Value
            Me.txtQtdeA.Text = tb1.Fields("quantidade_avariada").Value
            Me.cbEmbalagem.SelectedValue = Ordens.RetornaCodigoDaEmbalagem(tb1.Fields("COMPL_IPA").Value)
            Me.txtReferencia.Text = tb1.Fields("REFERENCIA").Value.ToString
            If tb1.Fields("MARCANTE").Value > 0 Then
                Me.cbMarcante.SelectedValue = Microsoft.VisualBasic.Right("000000000000" + tb1.Fields("MARCANTE").Value.ToString, 12)
            Else
                Me.cbMarcante.SelectedIndex = 0
            End If

            While Not tb1.EOF

                    If QtdeAnt <> 0 And Val(tb1.Fields("quantidade_avariada").Value) <> QtdeAnt Then
                        Me.CHECKBOX27.Checked = True
                        MostraEspecificas()

                        Me.txtQtdeA.Text = ""
                    End If

                    QtdeAnt = Val(tb1.Fields("quantidade_avariada").Value)


                    sql = "Select descr_avaria from sgipa.tb_conv_avarias "
                    sql = sql & " where "
                    sql = sql & " local=" & tb1.Fields("local").Value
                    sql = sql & " And tipo=" & tb1.Fields("tipo").Value
                    sql = sql & " And complemento=" & tb1.Fields("complemento").Value
                    sql = sql & " And providencia=" & tb1.Fields("providencia").Value


                    Dim tb3 As New ADODB.Recordset
                    tb3.Open(sql, BD.Conexao, 1, 1)
                    If Not tb3.EOF Then
                        Dim c As Control
                        Dim childc As Control
                        For Each c In Page.Controls
                            For Each childc In c.Controls
                                If TypeOf childc Is CheckBox Then
                                    Dim CkAv As CheckBox = CType(childc, CheckBox)
                                    If CkAv.Text = tb3.Fields("descr_avaria").Value.ToString Then
                                        CkAv.Checked = True
                                        Dim NButton As String
                                        NButton = Replace(CkAv.ID.ToUpper, "CHECKBOX", "BUTTON")
                                        Dim BTAv As Button = CType(Page.FindControl(NButton), Button)
                                        BTAv.BackColor = Drawing.Color.Red
                                        Dim Ntxt As String
                                        Ntxt = Replace(CkAv.ID.ToUpper, "CHECKBOX", "TXTQTDEE")
                                        Dim txAv As TextBox = CType(Page.FindControl(Ntxt), TextBox)
                                        txAv.Text = tb1.Fields("quantidade_avariada").Value
                                    End If
                                End If
                            Next
                        Next

                    Else
                        tb3.Close()
                        sql = "Select descr_avaria from sgipa.tb_conv_avarias "
                        sql = sql & " where "
                        sql = sql & " local=" & tb1.Fields("local").Value
                        sql = sql & " And tipo=" & tb1.Fields("tipo").Value
                        sql = sql & " And complemento=" & tb1.Fields("complemento").Value
                        sql = sql & " And providencia_c=" & tb1.Fields("providencia").Value
                        Dim tb4 As New ADODB.Recordset
                        tb4.Open(sql, BD.Conexao, 1, 1)
                        If Not tb4.EOF Then
                            Dim c As Control
                            Dim childc As Control
                            For Each c In Page.Controls
                                For Each childc In c.Controls
                                    If TypeOf childc Is CheckBox Then
                                        Dim CkAv As CheckBox = CType(childc, CheckBox)
                                        If CkAv.Text = tb4.Fields("descr_avaria").Value.ToString Then
                                            CkAv.Checked = True
                                            Dim NButtonC As String
                                            NButtonC = Replace(CkAv.ID.ToUpper, "CHECKBOX", "BUTTON")
                                            Dim BTAvc As Button = CType(Page.FindControl(NButtonC), Button)
                                            BTAvc.BackColor = Drawing.Color.Green
                                            Dim Ntxtc As String
                                            Ntxtc = Replace(CkAv.ID.ToUpper, "CHECKBOX", "TXTQTDEE")
                                            Dim txAvC As TextBox = CType(Page.FindControl(Ntxtc), TextBox)
                                            txAvC.Text = tb1.Fields("quantidade_avariada").Value
                                        End If
                                    End If
                                Next
                            Next
                        End If
                        tb4.Close()
                    End If
                    tb1.MoveNext()
                End While
            Else
                LimpaAvarias()
        End If

    End Sub

    Protected Sub CarregalblIAV()
        Dim Sql As String = String.Empty

        Me.lblTotal.Text = ""
        Me.lblAtual.Text = ""

        Sql = "SELECT COUNT(0) AS QUAL FROM (SELECT DISTINCT NVL(SEQ_AVARIAS_CS_COL,0) FROM SGIPA.TB_AVARIAS_CS WHERE AUTONUMCS = " & lblAutonumCS.Text & " AND BL=" & Session("AUTONUMBL") & ")"

        Dim tb1 As DataTable
        tb1 = OracleDAO.List(Sql)
        If tb1.Rows.Count > 0 Then
            Me.lblAtual.Text = "1"
            Me.lblTotal.Text = tb1.Rows(0)("QUAL")
            Me.lblSEQ.Text = carregaAVIndice(Me.lblAutonumCS.Text, 1)
        End If
        tb1.Dispose()

    End Sub

    Protected Function carregaAVIndice(AutonumCS As Long, Indice As Integer) As Long
        Dim Sql As String
        Sql = "SELECT NVL(QUAL,0) FROM ( "
        Sql = Sql & " Select  QUAL, ROWNUM As EITA FROM (Select DISTINCT NVL(SEQ_AVARIAS_CS_COL,0) As QUAL FROM SGIPA.TB_AVARIAS_CS WHERE AUTONUMCS = " & AutonumCS & " AND BL=" & Session("AUTONUMBL")
        Sql = Sql & " ORDER BY NVL(SEQ_AVARIAS_CS_COL, 0) "
        Sql = Sql & " )) "
        Sql = Sql & " WHERE EITA = " & Indice
        Return OracleDAO.ExecuteScalar(Sql)

    End Function

    Protected Sub LimpaAvarias()

        Dim tb1 As New ADODB.Recordset
        Dim sql As String = String.Empty
        Dim i As Integer
        sql = "Select "
        sql = sql & " AUTONUM, DESCR_AVARIA, LOCAL,"
        sql = sql & " TIPO, COMPLEMENTO, PROVIDENCIA, "
        sql = sql & " PROVIDENCIA_C, ID_AVARIA_COL"
        sql = sql & " From SGIPA.TB_CONV_AVARIAS "
        sql = sql & " WHERE ROWNUM<=26 "
        sql = sql & " order by ID_AVARIA_COL,DESCR_AVARIA "
        tb1.Open(sql, BD.Conexao)
        i = 1

        Me.CHECKBOX27.Checked = False
        Me.cbMarcante.SelectedIndex = -1
        Me.txtReferencia.Text = ""

        While Not tb1.EOF
            'Me.Controls("CHECKBOX" & i.ToString()).Text = tb1.Fields("DESCR_AVARIA").ToString

            Dim CkAv As CheckBox = CType(Page.FindControl("CHECKBOX" & i), CheckBox)
            Dim BTAv As Button = CType(Page.FindControl("BUTTON" & i), Button)
            Dim txAv As TextBox = CType(Page.FindControl("TXTQTDEE" & i), TextBox)

            CkAv.Visible = True
            CkAv.Checked = False
            BTAv.Visible = True
            BTAv.BackColor = Drawing.Color.Red
            CkAv.Text = tb1.Fields("DESCR_AVARIA").Value.ToString
            If tb1.Fields("PROVIDENCIA_C").Value.ToString = "" Then
                BTAv.Enabled = False
            Else
                BTAv.Enabled = True
            End If
            txAv.Text = ""

            i = i + 1
            tb1.MoveNext()
        End While

        EscondeEspecificas()

    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            Button1.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = False Then
            Button4.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then
            If Button1.BackColor = Drawing.Color.Green Then
                Button1.BackColor = Drawing.Color.Red
            Else
                Button1.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        If CheckBox22.Checked = True Then
            If Button22.BackColor = Drawing.Color.Green Then
                Button22.BackColor = Drawing.Color.Red
            Else
                Button22.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CheckBox2.Checked = True Then
            If Button2.BackColor = Drawing.Color.Green Then
                Button2.BackColor = Drawing.Color.Red
            Else
                Button2.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If CheckBox3.Checked = True Then
            If Button3.BackColor = Drawing.Color.Green Then
                Button3.BackColor = Drawing.Color.Red
            Else
                Button3.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If CheckBox4.Checked = True Then
            If Button4.BackColor = Drawing.Color.Green Then
                Button4.BackColor = Drawing.Color.Red
            Else
                Button4.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If CheckBox5.Checked = True Then
            If Button5.BackColor = Drawing.Color.Green Then
                Button5.BackColor = Drawing.Color.Red
            Else
                Button5.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If CheckBox6.Checked = True Then
            If Button6.BackColor = Drawing.Color.Green Then
                Button6.BackColor = Drawing.Color.Red
            Else
                Button6.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If CheckBox7.Checked = True Then
            If Button7.BackColor = Drawing.Color.Green Then
                Button7.BackColor = Drawing.Color.Red
            Else
                Button7.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If CheckBox8.Checked = True Then
            If Button8.BackColor = Drawing.Color.Green Then
                Button8.BackColor = Drawing.Color.Red
            Else
                Button8.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If CheckBox9.Checked = True Then
            If Button9.BackColor = Drawing.Color.Green Then
                Button9.BackColor = Drawing.Color.Red
            Else
                Button9.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If CheckBox10.Checked = True Then
            If Button10.BackColor = Drawing.Color.Green Then
                Button10.BackColor = Drawing.Color.Red
            Else
                Button10.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If CheckBox11.Checked = True Then
            If Button11.BackColor = Drawing.Color.Green Then
                Button11.BackColor = Drawing.Color.Red
            Else
                Button11.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If CheckBox12.Checked = True Then
            If Button12.BackColor = Drawing.Color.Green Then
                Button12.BackColor = Drawing.Color.Red
            Else
                Button12.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If CheckBox13.Checked = True Then
            If Button13.BackColor = Drawing.Color.Green Then
                Button13.BackColor = Drawing.Color.Red
            Else
                Button13.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If CheckBox14.Checked = True Then
            If Button14.BackColor = Drawing.Color.Green Then
                Button14.BackColor = Drawing.Color.Red
            Else
                Button14.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If CheckBox15.Checked = True Then
            If Button15.BackColor = Drawing.Color.Green Then
                Button15.BackColor = Drawing.Color.Red
            Else
                Button15.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If CheckBox16.Checked = True Then
            If Button16.BackColor = Drawing.Color.Green Then
                Button16.BackColor = Drawing.Color.Red
            Else
                Button16.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If CheckBox17.Checked = True Then
            If Button17.BackColor = Drawing.Color.Green Then
                Button17.BackColor = Drawing.Color.Red
            Else
                Button17.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If CheckBox18.Checked = True Then
            If Button18.BackColor = Drawing.Color.Green Then
                Button18.BackColor = Drawing.Color.Red
            Else
                Button18.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If CheckBox19.Checked = True Then
            If Button19.BackColor = Drawing.Color.Green Then
                Button19.BackColor = Drawing.Color.Red
            Else
                Button19.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        If CheckBox20.Checked = True Then
            If Button20.BackColor = Drawing.Color.Green Then
                Button20.BackColor = Drawing.Color.Red
            Else
                Button20.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If CheckBox21.Checked = True Then
            If Button21.BackColor = Drawing.Color.Green Then
                Button21.BackColor = Drawing.Color.Red
            Else
                Button21.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        If CheckBox23.Checked = True Then
            If Button23.BackColor = Drawing.Color.Green Then
                Button23.BackColor = Drawing.Color.Red
            Else
                Button23.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        If CheckBox24.Checked = True Then
            If Button24.BackColor = Drawing.Color.Green Then
                Button24.BackColor = Drawing.Color.Red
            Else
                Button24.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        If CheckBox25.Checked = True Then
            If Button25.BackColor = Drawing.Color.Green Then
                Button25.BackColor = Drawing.Color.Red
            Else
                Button25.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        If CheckBox26.Checked = True Then
            If Button26.BackColor = Drawing.Color.Green Then
                Button26.BackColor = Drawing.Color.Red
            Else
                Button26.BackColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Protected Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = False Then
            Button2.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = False Then
            Button3.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = False Then
            Button5.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = False Then
            Button6.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked = False Then
            Button7.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked = False Then
            Button8.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked = False Then
            Button9.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged
        If CheckBox10.Checked = False Then
            Button10.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked = False Then
            Button11.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged
        If CheckBox12.Checked = False Then
            Button12.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox13.CheckedChanged
        If CheckBox13.Checked = False Then
            Button13.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked = False Then
            Button14.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox15_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox15.CheckedChanged
        If CheckBox15.Checked = False Then
            Button15.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox16.CheckedChanged
        If CheckBox16.Checked = False Then
            Button16.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox17_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox17.CheckedChanged
        If CheckBox17.Checked = False Then
            Button17.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox18_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox18.CheckedChanged
        If CheckBox18.Checked = False Then
            Button18.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox19_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox19.CheckedChanged
        If CheckBox19.Checked = False Then
            Button19.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox20_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox20.CheckedChanged
        If CheckBox20.Checked = False Then
            Button20.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox21_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox21.CheckedChanged
        If CheckBox21.Checked = False Then
            Button21.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox22_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox22.CheckedChanged
        If CheckBox22.Checked = False Then
            Button22.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox23_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox23.CheckedChanged
        If CheckBox23.Checked = False Then
            Button23.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox24_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox24.CheckedChanged
        If CheckBox24.Checked = False Then
            Button24.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox25_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox25.CheckedChanged
        If CheckBox25.Checked = False Then
            Button25.BackColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub CheckBox26_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox26.CheckedChanged
        If CheckBox26.Checked = False Then
            Button26.BackColor = Drawing.Color.Red
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

        If Session("FLAG_DDC") = 0 Then
            Response.Redirect("Operacao.aspx")
        Else
            Response.Redirect("DDC.aspx")
        End If
    End Sub

    Private Sub CarregarEmbalagens()

        Me.cbEmbalagem.DataTextField = "DISPLAY"
        Me.cbEmbalagem.DataValueField = "AUTONUM"

        Me.cbEmbalagem.DataSource = Ordens.CarregarCadEmbalagens(Session("FLAG_DDC"))
        Me.cbEmbalagem.DataBind()

        Me.cbEmbalagem.Items.Insert(0, "--Selecione uma embalagem--")
        Me.cbEmbalagem.SelectedIndex = 0

    End Sub

    Private Sub CarregarMarcantesAV()

        Me.cbMarcante.DataTextField = "DISPLAY"
        Me.cbMarcante.DataValueField = "AUTONUM"

        Me.cbMarcante.DataSource = Ordens.CarregaMarcanteAV(Val(Session("AUTONUMBL").ToString), Session("ID_CONTEINER").ToString)
        Me.cbMarcante.DataBind()

        Me.cbMarcante.Items.Insert(0, " ")
        Me.cbMarcante.SelectedIndex = 0


    End Sub


    Protected Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click

        Dim Sql As String

        If ValidaAvaria() Then


            Dim MensagemAvaria As String = String.Empty

            MensagemAvaria = cbEmbalagem.SelectedItem.ToString

            If Me.lblSEQ.Text <> "" Then
                Sql = "DELETE FROM SGIPA.TB_AVARIAS_CS "
                Sql = Sql & " WHERE "
                Sql = Sql & " AUTONUMCS=" & lblAutonumCS.Text
                Sql = Sql & " And SEQ_AVARIAS_CS_COL=" & Val(Me.lblSEQ.Text)
                BD.Conexao.Execute(Sql)
            End If


            For I = 1 To 26
                Dim CkAv As CheckBox = CType(Page.FindControl("CHECKBOX" & I), CheckBox)
                Dim BTAv As Button = CType(Page.FindControl("BUTTON" & I), Button)
                Dim txAv As TextBox = CType(Page.FindControl("TXTQTDEE" & I), TextBox)

                If CkAv.Checked = True Then
                    'MensagemAvaria = MensagemAvaria & " " & CkAv.Text
                    Sql = "Select "
                    Sql = Sql & " LOCAL,"
                    Sql = Sql & " TIPO, COMPLEMENTO, PROVIDENCIA, "
                    Sql = Sql & " PROVIDENCIA_C "
                    Sql = Sql & " From SGIPA.TB_CONV_AVARIAS "
                    Sql = Sql & " WHERE DESCR_AVARIA='" & CkAv.Text & "'"
                    Dim tB1 As New ADODB.Recordset
                    tB1.Open(Sql, BD.Conexao, 1, 1)
                    If Not tB1.EOF Then


                        Sql = "INSERT INTO SGIPA.TB_AVARIAS_CS ( "
                        Sql = Sql & " AUTONUM, AUTONUMCS, LOCAL, "
                        Sql = Sql & " TIPO, COMPLEMENTO, "
                        Sql = Sql & " PESO_AVARIADO, PROVIDENCIA, QUANTIDADE_AVARIADA, "
                        Sql = Sql & " DT_AVARIA, "
                        Sql = Sql & " BL, ITEM, COMPL_IPA,SEQ_AVARIAS_CS_COL, MARCANTE, REFERENCIA ) values ("
                        Sql = Sql & "SGIPA.SEQ_AVARIAS_CS.NEXTVAL," & lblAutonumCS.Text & ","
                        Sql = Sql & "'" & tB1.Fields("LOCAL").Value.ToString & "',"
                        Sql = Sql & "'" & tB1.Fields("TIPO").Value.ToString & "',"
                        Sql = Sql & tB1.Fields("COMPLEMENTO").Value & ","
                        Sql = Sql & Me.txtPesoA.Text.Replace(",", ".") & ","
                        If BTAv.BackColor = Drawing.Color.Red Then
                            Sql = Sql & "'" & tB1.Fields("PROVIDENCIA").Value.ToString & "',"
                        Else
                            Sql = Sql & "'" & tB1.Fields("PROVIDENCIA_C").Value.ToString & "',"
                        End If
                        If txAv.Visible = False Then
                            Sql = Sql & Me.txtQtdeA.Text & ","
                        Else
                            Sql = Sql & txAv.Text & ","
                        End If
                        Sql = Sql & "SYSDATE,"
                        Sql = Sql & Session("AUTONUMBL") & ","
                        Sql = Sql & Session("ITEM") & ",'" & MensagemAvaria & "'," & Val(Me.lblSEQ.Text) & ","
                        If Me.cbMarcante.SelectedIndex > 0 Then
                            Sql = Sql & Val(cbMarcante.SelectedItem.Text) & ","
                        Else
                            Sql = Sql & "0,"
                        End If
                        Sql = Sql & "'" & Me.txtReferencia.Text.ToUpper & "'"
                        Sql = Sql & ")"
                        BD.Conexao.Execute(Sql)



                    End If

                End If
            Next I


            Session("PESO_AVARIADO") = Me.txtPesoA.Text

            CarregalblIAV()



            If lblAutonumCS.Text > 0 Then
                Sql = "UPDATE SGIPA.TB_CARGA_SOLTA Set FLAG_AVARIADO=1 "
                Sql = Sql & " WHERE AUTONUM=" & lblAutonumCS.Text
                BD.Conexao.Execute(Sql)
            Else
                Sql = "UPDATE SGIPA.TB_CARGA_SOLTA Set FLAG_AVARIADO=1 "
                Sql = Sql & " WHERE bl=" & Session("AUTONUMBL")
                Sql = Sql & " And CNTR=" & Session("AUTONUMCNTR")
                Sql = Sql & " And ITEM=" & Session("ITEM")
                BD.Conexao.Execute(Sql)
            End If

            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Avarias Registradas!');</script>", False)


            LimpaAvarias()

            CarregalblIAV()

            CarregarAvarias(Me.lblAutonumCS.Text, Me.lblSEQ.Text)


        End If

    End Sub


    Private Function ValidaAvaria() As Boolean

        If Me.txtReferencia.Text <> "" Then
            If Not IsNumeric(Me.txtReferencia.Text) Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('A referencia deve ser numerica');</script>", False)
                Return False
            End If
        End If

        If Me.txtQtdeA.Text <> "" Then
            If Not IsNumeric(Me.txtQtdeA.Text) Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('A quantidade deve ser numerica');</script>", False)
                Return False
            End If
        End If

        If Me.CHECKBOX27.Checked = False Then
            If txtQtdeA.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe a quantidade avariada');</script>", False)
                Return False
            End If

            If txtQtdeA.Text = "0" Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe a quantidade avariada');</script>", False)
                Return False
            End If

            If Val(Me.txtQtdeA.Text) < 1 Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade avariada inválida');</script>", False)
                Return False
            End If
        Else

            For I = 1 To 26
                Dim CkAv As CheckBox = CType(Page.FindControl("CHECKBOX" & I), CheckBox)
                Dim BTAv As Button = CType(Page.FindControl("BUTTON" & I), Button)
                Dim txAv As TextBox = CType(Page.FindControl("TXTQTDEE" & I), TextBox)

                If CkAv.Checked = True Then

                    If txAv.Text = "" Then
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe a quantidade avariada ITEM " & CkAv.Text & "');</script>", False)
                        Return False
                    End If

                    If txAv.Text = "0" Then
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe a quantidade avariada ITEM " & CkAv.Text & "');</script>", False)
                        Return False
                    End If

                    If Val(txAv.Text) < 1 Then
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade avariada inválida ITEM " & CkAv.Text & "'');</script>", False)
                        Return False
                    End If

                Else

                    If txAv.Text <> "" And txAv.Text <> "0" Then
                        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade avariada informada sem indicação que existe avaria para o ITEM " & CkAv.Text & "');</script>", False)
                        Return False
                    End If

                End If
            Next I

        End If


        If Me.cbEmbalagem.SelectedIndex = 0 Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe a embalagem');</script>", False)
            Return False
        End If

        'If Val(txtQtdeA.Text) > Val(TxtQtde.Text) Then
        'ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade avariada inválida');</script>", False)
        'Return False
        'End If


        If txtPesoA.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe o peso da avaria');</script>", False)
            Return False
        End If

        If txtPesoA.Text = "0" Then
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Informe o peso da avaria');</script>", False)
            Return False
        End If

        'Se a Referencia é Obrigatória.
        If Trim(txtReferencia.Text) = "" Then
            If Session("REFOB") = 1 Then
                ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Para este cliente, obrigatorio informar a referencia');</script>", False)
                Return False
            End If
        End If

        Return True

    End Function

    Protected Sub cbEmbalagem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmbalagem.SelectedIndexChanged
        'If Me.cbEmbalagem.SelectedIndex > 0 Then
        'CarregarAvarias(Me.cbEmbalagem.SelectedItem.ToString)
        'End If
    End Sub

    Protected Sub btSalvar0_Click(sender As Object, e As EventArgs) Handles btSalvar0.Click
        LimpaAvarias()
        If Session("REFOB") = 1 Then
            Me.txtQtdeA.Text = "1"
            'Me.txtPesoA.Text = Session("PESO")
            If Session("PESO_AVARIADO") <> "" Then
                Me.txtPesoA.Text = Session("PESO_AVARIADO")
            Else
                Me.txtPesoA.Text = Session("PESO")
            End If
        Else
            Me.txtQtdeA.Text = "0"
            Me.txtPesoA.Text = "0"
        End If

        If Session("EMBALAGEM") <> 98 Then
            cbEmbalagem.SelectedValue = Session("EMBALAGEM")
        Else
            Me.cbEmbalagem.SelectedIndex = -1
        End If
        Me.lblSEQ.Text = Ordens.ProximoSEQ_AVARIAS_CS_COL
    End Sub

    Protected Sub btSalvar1_Click(sender As Object, e As EventArgs) Handles btSalvar1.Click

        Dim MensagemAvaria As String = String.Empty
        Dim SQL As String

        MensagemAvaria = cbEmbalagem.SelectedItem.ToString

        SQL = "DELETE FROM SGIPA.TB_AVARIAS_CS "
        SQL = SQL & " WHERE "
        SQL = SQL & " AUTONUMCS=" & Me.lblAutonumCS.Text
        SQL = SQL & " AND BL=" & Session("AUTONUMBL")
        SQL = SQL & " AND ITEM=" & Session("ITEM")
        SQL = SQL & " AND COMPL_IPA='" & MensagemAvaria & "'"
        BD.Conexao.Execute(SQL)

        '29-05-2017 LIMPAR FLAG_AVARIADO 
        SQL = "UPDATE SGIPA.TB_CARGA_SOLTA SET FLAG_AVARIADO=0 WHERE AUTONUM= " & Me.lblAutonumCS.Text
        SQL = SQL & "AND NOT EXISTS (SELECT AUTONUM FROM SGIPA.TB_AVARIAS_CS WHERE AUTONUMCS=" & Me.lblAutonumCS.Text & ")"
        BD.Conexao.Execute(SQL)

        LimpaAvarias()
        Me.txtPesoA.Text = "0"
        Me.txtQtdeA.Text = "0"
        Me.cbEmbalagem.SelectedIndex = -1

        CarregalblIAV()

        CarregarAvarias(Me.lblAutonumCS.Text, Me.lblSEQ.Text)

    End Sub

    Protected Sub txtQtdeA_TextChanged(sender As Object, e As EventArgs) Handles txtQtdeA.TextChanged

    End Sub

    Protected Sub CheckBox27_CheckedChanged(sender As Object, e As EventArgs) Handles CHECKBOX27.CheckedChanged
        If Me.CHECKBOX27.Checked = True Then
            MostraEspecificas()


        Else
            EscondeEspecificas()

        End If


    End Sub

    Sub MostraEspecificas()
        For I = 1 To 26
            Dim CkAv As CheckBox = CType(Page.FindControl("CHECKBOX" & I), CheckBox)
            Dim BTAv As Button = CType(Page.FindControl("BUTTON" & I), Button)
            Dim TbQtAv As TextBox = CType(Page.FindControl("TXTQTDEE" & I), TextBox)
            If BTAv.Visible = True Then
                TbQtAv.Visible = True
                BTAv.Width = 30

            End If
        Next I
        Me.txtQtdeA.Text = ""
        Me.txtQtdeA.Enabled = False
    End Sub

    Sub EscondeEspecificas()
        For I = 1 To 26
            Dim CkAv As CheckBox = CType(Page.FindControl("CHECKBOX" & I), CheckBox)
            Dim BTAv As Button = CType(Page.FindControl("BUTTON" & I), Button)
            Dim TbQtAv As TextBox = CType(Page.FindControl("TXTQTDEE" & I), TextBox)

            TbQtAv.Visible = False
            BTAv.Width = 45
            TbQtAv.Text = ""

        Next I

        Me.txtQtdeA.Enabled = True
    End Sub

    Protected Sub txtPesoA_TextChanged(sender As Object, e As EventArgs) Handles txtPesoA.TextChanged

    End Sub

    Protected Sub ImageUP_Click(sender As Object, e As ImageClickEventArgs) Handles ImageUP.Click

        If Me.lblTotal.Text <> "" And Me.lblAtual.Text <> "" Then
            If Val(Me.lblAtual.Text) < Val(Me.lblTotal.Text) Then
                Me.lblAtual.Text = Val(Me.lblAtual.Text) + 1
                Me.lblSEQ.Text = carregaAVIndice(Me.lblAutonumCS.Text, Me.lblAtual.Text)
                CarregarAvarias(Me.lblAutonumCS.Text, Me.lblSEQ.Text)
            End If
        End If

    End Sub

    Protected Sub ImageDown_Click(sender As Object, e As ImageClickEventArgs) Handles ImageDown.Click

        If Me.lblTotal.Text <> "" And Me.lblAtual.Text <> "" Then
            If Val(Me.lblAtual.Text) > 1 Then
                Me.lblAtual.Text = Val(Me.lblAtual.Text) - 1
                Me.lblSEQ.Text = carregaAVIndice(Me.lblAutonumCS.Text, Me.lblAtual.Text)
                CarregarAvarias(Me.lblAutonumCS.Text, Me.lblSEQ.Text)
            End If
        End If



    End Sub

    Protected Sub cbMarcante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMarcante.SelectedIndexChanged

    End Sub
End Class