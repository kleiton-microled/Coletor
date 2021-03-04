Public Class EmbalagemDAO

    Public Shared Function CarregarEmbalagens(ByVal id As String) As List(Of EmbalagemDTO)

        Dim SQL As New StringBuilder()

        SQL.Append(String.Format("SELECT AUTONUM_EMB, DESCRICAO_EMB FROM REDEX.TB_CAD_EMBALAGENS WHERE SIGLA IS NOT NULL AND AUTONUM_EMB = {0} ORDER BY SIGLA, DESCRICAO_EMB", id))

        Dim ds As New DataTable
        ds = OracleDAO.List(SQL.ToString())

        Dim Lista As New List(Of EmbalagemDTO)

        If ds IsNot Nothing Then
            For Each Linha As DataRow In ds.Rows

                Dim item As New EmbalagemDTO
                item.Codigo = Linha("AUTONUM_EMB").ToString()
                item.Descricao = Linha("DESCRICAO_EMB").ToString()

                Lista.Add(item)

            Next
        End If

        Return Lista

    End Function

    Public Shared Function ObterDescricaoEmbalagemPorCodigo(ByVal Codigo As String) As String
        Return OracleDAO.ExecuteScalar(String.Format("SELECT DESCRICAO_EMB || '-' || AUTONUM_EMB AS SIGLA FROM REDEX.TB_CAD_EMBALAGENS WHERE SIGLA IS NOT NULL AND SIGLA = '{0}' ORDER BY SIGLA, DESCRICAO_EMB", Codigo))
    End Function

End Class
