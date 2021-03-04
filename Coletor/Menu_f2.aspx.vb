Public Class WebForm2

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
            Catch ex As Exception
                Response.Redirect("Index.aspx")
            End Try
        End If
    End Sub


    Private Sub ApagarCookies()
        Response.Cookies.Remove("LOGADO")
        Response.Cookies.Remove("USUARIO")
        Response.Cookies.Remove("SENHA")
        Response.Cookies.Remove("EMPRESA")
        Response.Cookies.Remove("PATIO")
        Response.Cookies.Remove("AUTONUMPATIO")
    End Sub

    Protected Sub btIni_Click(sender As Object, e As EventArgs) Handles btIni.Click
        Response.Redirect("DesovaDatas.aspx")
    End Sub


    Protected Sub btIni0_Click(sender As Object, e As EventArgs) Handles btIni0.Click
        Response.Redirect("InventarioCS.aspx")
    End Sub


    Protected Sub btIni1_Click(sender As Object, e As EventArgs) Handles btIni1.Click
        ApagarCookies()
        Response.Redirect("Index.aspx")
    End Sub


    Private Sub form1_Load(sender As Object, e As System.EventArgs) Handles form1.Load
        txtTerminal.Text = Session("PATIO")
        txtUsuario.Text = Session("USUARIO")
    End Sub


    Protected Sub btIni3_Click(sender As Object, e As EventArgs) Handles btIni3.Click
        Response.Redirect("Operacao.aspx")
    End Sub

    Protected Sub btIni4_Click(sender As Object, e As EventArgs) Handles btIni4.Click

    End Sub
End Class