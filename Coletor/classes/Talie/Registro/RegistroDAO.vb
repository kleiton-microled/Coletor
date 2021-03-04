Public Class RegistroDAO

    Public Shared Function ObterQuantidadeRegistro(ByVal AutonumRegistro As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT NVL(SUM(QUANTIDADE),0) FROM REDEX.TB_REGISTRO_CS WHERE AUTONUM_REG = " & AutonumRegistro)
    End Function

End Class
