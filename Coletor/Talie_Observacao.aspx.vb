Public Class WebForm5
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("wLoad") Then
            Me.TxtObservacao.Text = Session("WOBS")
            Session("wLoad") = False
        End If

    End Sub

    Protected Sub TxtObservacao_TextChanged(sender As Object, e As EventArgs) Handles TxtObservacao.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session("WOBS") = Me.TxtObservacao.Text
        Session("wvolta") = True

        Response.Redirect("TALIE_descarga_registro.aspx")
    End Sub
End Class