Public Class EquipeDAO

    Public Shared Function CarregarEquipesOperador() As DataTable
        Return OracleDAO.List("SELECT AUTONUM_EQP, NOME_EQP FROM REDEX.TB_EQUIPE WHERE FLAG_ATIVO=1 AND FLAG_OPERADOR=1 ORDER BY NOME_EQP")
    End Function

    Public Shared Function CarregarEquipesConferente() As DataTable
        Return OracleDAO.List("SELECT AUTONUM_EQP, NOME_EQP FROM REDEX.TB_EQUIPE WHERE FLAG_ATIVO=1 AND FLAG_CONFERENTE=1 ORDER BY NOME_EQP")
    End Function

    Public Shared Function ObterCodigoEquipePorLogin(ByVal CodigoUsuario As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT AUTONUM_EQP FROM REDEX.TB_EQUIPE WHERE ID_LOGIN = " & Val(CodigoUsuario))
    End Function

End Class
