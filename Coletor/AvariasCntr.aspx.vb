Public Class AvariasCntr
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.lblAutonumCntr.Text = Val(Session("AUTONUMCNTR").ToString())
            Me.lblSEQ.Text = Session("ID_CONTEINER").ToString()

            Dim Tb1 As New ADODB.Recordset
            Dim Sql As String = String.Empty
            Sql = "Select nvl(termo_avaria,0) as termo_avaria from SGIPA.TB_CNTR_BL WHERE AUTONUM=" & Val(Session("AUTONUMCNTR").ToString())
            Tb1.Open(Sql, BD.Conexao, 1, 1)
            If Tb1.Fields("termo_avaria").Value = "0" Then
                Me.lblTermo.Visible = False
                Me.btSalvar.Visible = True
            Else
                Me.lblTermo.Visible = True
                Me.btSalvar.Visible = False
            End If


            LimpaAvarias()

            CarregalblIAV()

            CarregarAvarias(Val(Session("AUTONUMCNTR").ToString()))

        End If

    End Sub

    Protected Sub CarregarAvarias(AutonumCntr As Long)
        Dim sql As String
        Dim tb1 As New ADODB.Recordset
        Dim tb2 As New ADODB.Recordset

        LimpaAvarias()

        Dim QtdeAnt As Integer
        QtdeAnt = 0

        sql = "Select local,tipo,complemento,providencia,COMPL_IPA "
        sql = sql & " from sgipa.tb_avarias_conteiner "
        If AutonumCntr > 0 Then
            sql = sql & " where cntr=" & AutonumCntr
        End If

        tb1.Open(sql, BD.Conexao, 1, 1)
        If Not tb1.EOF Then

            While Not tb1.EOF

                sql = "Select descr_avaria from sgipa.tb_conv_avarias_cntr "
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
                                    If Me.lblTermo.Visible = True Then
                                        BTAv.Enabled = False
                                    Else
                                        BTAv.Enabled = True
                                    End If
                                End If
                            End If
                        Next
                    Next

                Else
                    tb3.Close()
                    sql = "Select descr_avaria from sgipa.tb_conv_avarias_cntr "
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
                                        If Me.lblTermo.Visible = True Then
                                            BTAvc.Enabled = False
                                        Else
                                            BTAvc.Enabled = True
                                        End If
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

    End Sub


    Protected Sub LimpaAvarias()

        Dim tb1 As New ADODB.Recordset
        Dim sql As String = String.Empty
        Dim i As Integer
        sql = "Select "
        sql = sql & " AUTONUM, DESCR_AVARIA, LOCAL,"
        sql = sql & " TIPO, COMPLEMENTO, PROVIDENCIA, "
        sql = sql & " PROVIDENCIA_C, ID_AVARIA_COL"
        sql = sql & " From SGIPA.TB_CONV_AVARIAS_CNTR "
        sql = sql & " WHERE ROWNUM<=26 "
        sql = sql & " order by ID_AVARIA_COL,DESCR_AVARIA "
        tb1.Open(sql, BD.Conexao)
        i = 1

        While Not tb1.EOF
            'Me.Controls("CHECKBOX" & i.ToString()).Text = tb1.Fields("DESCR_AVARIA").ToString

            Dim CkAv As CheckBox = CType(Page.FindControl("CHECKBOX" & i), CheckBox)
            Dim BTAv As Button = CType(Page.FindControl("BUTTON" & i), Button)

            CkAv.Visible = True
            CkAv.Checked = False
            BTAv.Visible = True
            BTAv.BackColor = Drawing.Color.Red
            CkAv.Text = tb1.Fields("DESCR_AVARIA").Value.ToString

            If Me.lblTermo.Visible = True Then
                BTAv.Enabled = False
                CkAv.Enabled = False
            Else
                BTAv.Enabled = True
                CkAv.Enabled = True
            End If



            If tb1.Fields("PROVIDENCIA_C").Value.ToString = "" Then
                BTAv.Enabled = False
            Else
                If Me.lblTermo.Visible = False Then BTAv.Enabled = True
            End If



            i = i + 1
            tb1.MoveNext()
        End While



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

        Response.Redirect("InventarioCNTR.aspx")

    End Sub

    Protected Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click

        Dim Sql As String

        If ValidaAvaria() Then

            'Sql = "DELETE FROM SGIPA.TB_AVARIAS_CONTEINER "
            'Sql = Sql & " WHERE "
            'Sql = Sql & " CNTR=" & Val(lblAutonumCntr.Text)


            'APAGA APENAS OS QUE TEM CONVERSAO PRA SALVAR NOVAMENTE
            Sql = " DELETE From SGIPA.TB_AVARIAS_CONTEINER "
            Sql = Sql & " Where AUTONUM IN("
            Sql = Sql & " Select A.AUTONUM FROM SGIPA.TB_AVARIAS_CONTEINER A "
            Sql = Sql & " INNER Join SGIPA.TB_CONV_AVARIAS_CNTR B "
            Sql = Sql & " On A.LOCAL=B.LOCAL And A.TIPO=B.TIPO "
            Sql = Sql & " And A.COMPLEMENTO=B.COMPLEMENTO "
            Sql = Sql & " WHERE A.CNTR =  " & Val(lblAutonumCntr.Text)
            Sql = Sql & ")"


            BD.Conexao.Execute(Sql)

            For I = 1 To 26
                Dim CkAv As CheckBox = CType(Page.FindControl("CHECKBOX" & I), CheckBox)
                Dim BTAv As Button = CType(Page.FindControl("BUTTON" & I), Button)


                If CkAv.Checked = True Then
                    'MensagemAvaria = MensagemAvaria & " " & CkAv.Text
                    Sql = "Select "
                    Sql = Sql & " LOCAL,"
                    Sql = Sql & " TIPO, COMPLEMENTO, PROVIDENCIA, "
                    Sql = Sql & " PROVIDENCIA_C "
                    Sql = Sql & " From SGIPA.TB_CONV_AVARIAS_CNTR "
                    Sql = Sql & " WHERE DESCR_AVARIA='" & CkAv.Text & "'"
                    Dim tB1 As New ADODB.Recordset
                    tB1.Open(Sql, BD.Conexao, 1, 1)
                    If Not tB1.EOF Then


                        Sql = "INSERT INTO SGIPA.TB_AVARIAS_CONTEINER ( "
                        Sql = Sql & " AUTONUM, CNTR, LOCAL, "
                        Sql = Sql & " TIPO, COMPLEMENTO, PROVIDENCIA, "
                        Sql = Sql & " DT_AVARIA "
                        Sql = Sql & " ) values ("
                        Sql = Sql & "SGIPA.SEQ_AVARIAS_CONTEINER.NEXTVAL," & Val(lblAutonumCntr.Text) & ","
                        Sql = Sql & "'" & tB1.Fields("LOCAL").Value.ToString & "',"
                        Sql = Sql & "'" & tB1.Fields("TIPO").Value.ToString & "',"
                        Sql = Sql & tB1.Fields("COMPLEMENTO").Value & ","

                        If BTAv.BackColor = Drawing.Color.Red Then
                            Sql = Sql & "'" & tB1.Fields("PROVIDENCIA").Value.ToString & "',"
                        Else
                            Sql = Sql & "'" & tB1.Fields("PROVIDENCIA_C").Value.ToString & "',"
                        End If

                        Sql = Sql & "SYSDATE"
                        Sql = Sql & ")"
                        BD.Conexao.Execute(Sql)



                    End If

                End If
            Next I



            CarregalblIAV()




            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Avarias Registradas!');</script>", False)


            LimpaAvarias()

            CarregalblIAV()

            CarregarAvarias(Me.lblAutonumCntr.Text)


        End If

    End Sub


    Private Function ValidaAvaria() As Boolean

        'For I = 1 To 26
        '    Dim CkAv As CheckBox = CType(Page.FindControl("CHECKBOX" & I), CheckBox)
        '    Dim BTAv As Button = CType(Page.FindControl("BUTTON" & I), Button)


        '    If CkAv.Checked = True Then


        '    Else

        '        If txAv.Text <> "" And txAv.Text <> "0" Then
        '            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Quantidade avariada informada sem indicação que existe avaria para o ITEM " & CkAv.Text & "');</script>", False)
        '            Return False
        '        End If

        '    End If
        'Next I


        Return True

    End Function



End Class