Public Class Index
    Inherits System.Web.UI.Page

    Dim Login As New Login



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MsgErro As String = String.Empty

        lblERRO.Text = ""
        txtUsuario.Focus()

        Me.Label7.Visible = False
        Me.txtNovaSenha.Visible = False
        Me.btSalvar.Visible = False


        Me.Label2.Text = "VERSAO " & My.Application.Info.Version.ToString

        If Not Page.IsPostBack Then


            If Request.QueryString("err") IsNot Nothing Then

                MsgErro = Request.QueryString("err").ToString()

                If MsgErro.Equals("1") Then
                    txtUsuario.Focus()
                End If

                If MsgErro.Equals("2") Then
                    lblERRO.Text = Session("ERROLOGIN")

                    If Session("ERROLOGIN") = "SENHA EXPIRADA" Then
                        Me.txtUsuario.Text = Session("USUARIO")
                        txtUsuario.Enabled = False
                        Me.Label7.Visible = True
                        Me.txtNovaSenha.Visible = True
                        Me.btSalvar.Visible = True
                    End If

                End If

            End If
        End If



        'Dim s As String = ""
        'With Request.Browser
        '    s &= "Browser Capabilities" & vbCrLf
        '    s &= "Type = " & .Type & vbCrLf
        '    s &= "Name = " & .Browser & vbCrLf
        '    s &= "Version = " & .Version & vbCrLf
        '    s &= "Major Version = " & .MajorVersion & vbCrLf
        '    s &= "Minor Version = " & .MinorVersion & vbCrLf
        '    s &= "Platform = " & .Platform & vbCrLf
        '    s &= "Is Beta = " & .Beta & vbCrLf
        '    s &= "Is Crawler = " & .Crawler & vbCrLf
        '    s &= "Is AOL = " & .AOL & vbCrLf
        '    s &= "Is Win16 = " & .Win16 & vbCrLf
        '    s &= "Is Win32 = " & .Win32 & vbCrLf
        '    s &= "Supports Frames = " & .Frames & vbCrLf
        '    s &= "Supports Tables = " & .Tables & vbCrLf
        '    s &= "Supports Cookies = " & .Cookies & vbCrLf
        '    s &= "Supports VBScript = " & .VBScript & vbCrLf
        '    s &= "Supports JavaScript = " &
        '    .EcmaScriptVersion.ToString() & vbCrLf
        '    s &= "Supports Java Applets = " & .JavaApplets & vbCrLf
        '    s &= "Supports ActiveX Controls = " & .ActiveXControls &
        '    vbCrLf
        'End With

    End Sub

    Private Sub EscreverCookies()

        Dim Cookie1 As New HttpCookie("LOGADO")
        Cookie1.Values.Add("LOGADO", Session("LOGADO").ToString())
        Cookie1.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie1)

        Dim Cookie2 As New HttpCookie("USUARIO")
        Cookie1.Values.Add("USUARIO", Session("USUARIO").ToString())
        Cookie2.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie2)

        Dim Cookie3 As New HttpCookie("SENHA")
        Cookie1.Values.Add("SENHA", Session("SENHA").ToString())
        Cookie3.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie3)

        Dim Cookie4 As New HttpCookie("EMPRESA")
        Cookie4.Values.Add("EMPRESA", Session("EMPRESA").ToString())
        Cookie4.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie4)

        Dim Cookie5 As New HttpCookie("PATIO")
        Cookie5.Values.Add("PATIO", Session("PATIO").ToString())
        Cookie5.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie5)

        Dim Cookie6 As New HttpCookie("AUTONUMPATIO")
        Cookie6.Values.Add("AUTONUMPATIO", Session("AUTONUMPATIO").ToString())
        Cookie6.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie6)

        Dim Cookie7 As New HttpCookie("AUTONUMUSUARIO")
        Cookie7.Values.Add("AUTONUMUSUARIO", Session("AUTONUMUSUARIO").ToString())
        Cookie7.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie7)

        Dim Cookie8 As New HttpCookie("BROWSER_NAME")
        Cookie8.Values.Add("BROWSER_NAME", Session("BROWSER_NAME").ToString())
        Cookie8.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie8)

        Dim Cookie9 As New HttpCookie("BROWSER_VERSION")
        Cookie9.Values.Add("BROWSER_VERSION", Session("BROWSER_VERSION").ToString())
        Cookie9.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie9)

        Dim Cookie10 As New HttpCookie("MobileDeviceModel")
        Cookie10.Values.Add("MobileDeviceModel", Session("MobileDeviceModel").ToString())
        Cookie10.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie10)

        Dim Cookie11 As New HttpCookie("MobileDeviceManufacturer")
        Cookie11.Values.Add("MobileDeviceManufacturer", Session("MobileDeviceManufacturer").ToString())
        Cookie11.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie11)

        Dim Cookie12 As New HttpCookie("IsMobileDevice")
        Cookie12.Values.Add("IsMobileDevice", Session("IsMobileDevice").ToString())
        Cookie12.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie12)

        Dim Cookie13 As New HttpCookie("FLAG_OB_MARCANTE")
        Cookie13.Values.Add("FLAG_OB_MARCANTE", Session("FLAG_OB_MARCANTE").ToString())
        Cookie13.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie13)

        Dim Cookie14 As New HttpCookie("FLAG_FILMA_DESOVA")
        Cookie14.Values.Add("FLAG_FILMA_DESOVA", Session("FLAG_FILMA_DESOVA").ToString())
        Cookie14.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie14)

        Dim Cookie15 As New HttpCookie("FLAG_REDEX_SEM_MARCANTE")
        Cookie15.Values.Add("FLAG_REDEX_SEM_MARCANTE", Session("FLAG_REDEX_SEM_MARCANTE").ToString())
        Cookie15.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie15)

        Dim Cookie16 As New HttpCookie("LARGURATELA")
        Cookie16.Values.Add("LARGURATELA", Session("LARGURATELA").ToString())
        Cookie16.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie16)

        Dim Cookie17 As New HttpCookie("IP_CONNECTION")
        Cookie17.Values.Add("IP_CONNECTION", Session("IP_CONNECTION").ToString())
        Cookie17.Expires = DateTime.Now.AddDays(1)
        Response.Cookies.Add(Cookie17)

    End Sub




    Protected Sub btLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btLogin.Click

        Dim strValidaVersao As String = ""
        Dim strValidaUsuario As String = ""

        Dim Rst As New ADODB.Recordset


        If BD.ControleSenha = "1" Then
            strValidaVersao = ControleAcesso.validarVersao
            If strValidaVersao <> "OK" Then
                'ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" & strValidaVersao & "');</script>", False)
                Session("ERROLOGIN") = strValidaVersao
                Response.Redirect("Index.aspx?err=2")
            End If

            strValidaUsuario = ControleAcesso.validarUsuario("OPERADOR.TB_CAD_USUARIOS", txtUsuario.Text.ToUpper(), txtSenha.Text)
            If strValidaUsuario = "SENHA EXPIROU" Then
                Session("ERROLOGIN") = "SENHA EXPIRADA"
                Session("USUARIO") = txtUsuario.Text.ToUpper()
                Session("SENHA") = txtSenha.Text
                Rst.Open(String.Format("SELECT B.DESCR_RESUMIDO , C.RAZAO_SOCIAL , B.AUTONUM  FROM " & BD.BancoOperador & "TB_CAD_USUARIOS A LEFT JOIN " & BD.BancoOperador & "TB_PATIOS B ON A.PATIO_COLETOR = B.AUTONUM  LEFT JOIN " & BD.BancoSgipa & "TB_EMPRESAS C ON A.COD_EMPRESA = C.AUTONUM  WHERE A.USUARIO='{0}'", txtUsuario.Text.ToUpper()), BD.Conexao, 3, 3)
                If Not Rst.EOF Then
                    Session("PATIO") = Rst.Fields("DESCR_RESUMIDO").Value.ToString()
                    Session("AUTONUMPATIO") = Rst.Fields("AUTONUM").Value.ToString()
                    Session("EMPRESA") = txtPatio.Text
                End If
                Response.Redirect("Index.aspx?err=2")
            ElseIf strValidaUsuario = "NÃO AUTORIZADO" Then
                Session("ERROLOGIN") = "USUARIO/SENHA INVALIDO"
                Response.Redirect("Index.aspx?err=2")
            ElseIf strValidaUsuario = "LIMITE ERROS" Then
                Session("ERROLOGIN") = "LIMITE DE ERROS. TENTE NOVAMENTE MAIS TARDE"
                Response.Redirect("Index.aspx?err=2")
            ElseIf strValidaUsuario = "AUTORIZADO" Then
                Session("AUTONUMUSUARIO") = Login.EfetuarLogin(txtUsuario.Text.ToUpper(), "")
            End If


        Else
            Session("AUTONUMUSUARIO") = Login.EfetuarLogin(txtUsuario.Text.ToUpper(), txtSenha.Text)
        End If




        If Session("AUTONUMUSUARIO") > 0 Then

            Session("LOGADO") = True
            Session("USUARIO") = txtUsuario.Text.ToUpper()
            Session("SENHA") = txtSenha.Text
            Rst.Open(String.Format("SELECT B.DESCR_RESUMIDO , C.RAZAO_SOCIAL , B.AUTONUM  FROM " & BD.BancoOperador & "TB_CAD_USUARIOS A LEFT JOIN " & BD.BancoOperador & "TB_PATIOS B ON A.PATIO_COLETOR = B.AUTONUM  LEFT JOIN " & BD.BancoSgipa & "TB_EMPRESAS C ON A.COD_EMPRESA = C.AUTONUM  WHERE A.USUARIO='{0}'", txtUsuario.Text.ToUpper()), BD.Conexao, 3, 3)
            If Not Rst.EOF Then
                Session("PATIO") = Rst.Fields("DESCR_RESUMIDO").Value.ToString()
                Session("AUTONUMPATIO") = Rst.Fields("AUTONUM").Value.ToString()
                Session("EMPRESA") = txtPatio.Text
            End If
            Me.txtPatio.Text = Session("PATIO")
            txtEmpresa.Text = Session("EMPRESA")

            Dim sql As String
            sql = "SELECT A.FLAG_OB_MARCANTE, P.FLAG_FILMA_DESOVA FROM TB_ARMAZENS_IPA A INNER JOIN OPERADOR.TB_PATIOS P ON A.PATIO=P.AUTONUM WHERE A.PATIO=" & Session("AUTONUMPATIO") & " AND A.FLAG_PADRAO_PATIO=1"
            Dim rs As New ADODB.Recordset
            rs.Open(sql, BD.Conexao, 1, 1)
            If Not rs.EOF Then
                Session("FLAG_OB_MARCANTE") = rs.Fields("FLAG_OB_MARCANTE").Value
                Session("FLAG_FILMA_DESOVA") = rs.Fields("FLAG_FILMA_DESOVA").Value
            Else
                Session("FLAG_OB_MARCANTE") = 0
                Session("FLAG_FILMA_DESOVA") = 0
            End If

            Session("FLAG_REDEX_SEM_MARCANTE") = 0

            Dim tamTela As Integer = 800
            Try
                If Request.Form("HiddenField1") IsNot Nothing Then
                    tamTela = Integer.Parse(Request.Form("HiddenField1").ToString())
                End If
            Catch
            End Try

            Session("LARGURATELA") = tamTela

            Dim IP As String = ""
            Try
                If Request.Form("HiddenField2") IsNot Nothing Then
                    IP = Request.Form("HiddenField2").ToString()
                End If
            Catch
            End Try

            'Session("IP_CONNECTION") = IP

            With Request.Browser
                Session("BROWSER_NAME") = .Browser
                Session("BROWSER_VERSION") = .Version
                Session("MobileDeviceModel") = .MobileDeviceModel
                Session("MobileDeviceManufacturer") = .MobileDeviceManufacturer
                Session("IsMobileDevice") = .IsMobileDevice

            End With


            'ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" & Session("IP_CONNECTION") & "');</script>", False)


            Dim iPTESTE As String
            iPTESTE = GetIPAddress()

            'ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('" & iPTESTE & "');</script>", False)

            Session("IP_CONNECTION") = iPTESTE

            EscreverCookies()


            Response.Redirect("Menu.aspx?pg=1")
        Else
            Response.Redirect("Index.aspx?err=1")
        End If


    End Sub
    Public Shared Function GetIPAddress() As String
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim sIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(sIPAddress) Then
            Return context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = sIPAddress.Split(New [Char]() {","c})
            Return ipArray(0)
        End If
    End Function

    Protected Sub txtUsuario_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtUsuario.TextChanged
        Dim Rst As New ADODB.Recordset

        Me.txtUsuario.Text = UCase(Me.txtUsuario.Text)
        If Not txtUsuario.Text = String.Empty Then

            Rst.Open(String.Format("SELECT B.DESCR_RESUMIDO , C.RAZAO_SOCIAL , B.AUTONUM  FROM " & BD.BancoOperador & "TB_CAD_USUARIOS A LEFT JOIN " & BD.BancoOperador & "TB_PATIOS B ON A.PATIO_COLETOR = B.AUTONUM  LEFT JOIN " & BD.BancoSgipa & "TB_EMPRESAS C ON A.COD_EMPRESA = C.AUTONUM  WHERE A.USUARIO='{0}'", txtUsuario.Text.ToUpper()), BD.Conexao, 3, 3)
            If Not Rst.EOF Then
                txtPatio.Text = Rst.Fields("DESCR_RESUMIDO").Value.ToString()
                If txtPatio.Text <> String.Empty Then
                    Login.AutonumPatio = Rst.Fields("AUTONUM").Value.ToString()
                    Login.NomePatio = txtPatio.Text
                    Login.NomeUsuario = txtUsuario.Text.ToUpper
                    txtEmpresa.Text = Rst.Fields("RAZAO_SOCIAL").Value.ToString()
                    txtSenha.Focus()
                    btLogin.Enabled = True
                End If
            Else
                txtUsuario.Text = ""
                txtEmpresa.Text = ""
            End If

        End If

    End Sub

    Protected Sub txtEmpresa_TextChanged(sender As Object, e As EventArgs) Handles txtEmpresa.TextChanged

    End Sub

    Protected Sub txtPatio_TextChanged(sender As Object, e As EventArgs) Handles txtPatio.TextChanged

    End Sub

    Protected Sub txtSenha_TextChanged(sender As Object, e As EventArgs) Handles txtSenha.TextChanged

    End Sub

    Protected Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click
        Dim StrTrocaSenha As String
        StrTrocaSenha = ControleAcesso.alterarSenha(Me.txtNovaSenha.Text, "OPERADOR.TB_CAD_USUARIOS", Me.txtUsuario.Text.ToUpper)
        If StrTrocaSenha <> "OK" Then
            Session("ERROLOGIN") = StrTrocaSenha
            Response.Redirect("Index.aspx?err=2")
        Else
            txtUsuario.Enabled = True
            Me.txtUsuario.Text = ""
            Me.Label7.Visible = False
            Me.txtNovaSenha.Visible = False
            Me.btSalvar.Visible = False
            Me.txtNovaSenha.Text = ""
            ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "script", "<script>alert('Senha alterada com sucesso!');</script>", False)
        End If
    End Sub

    Protected Sub txtNovaSenha_TextChanged(sender As Object, e As EventArgs) Handles txtNovaSenha.TextChanged

    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load

    End Sub
End Class