Public Class ParametroDAO

    Public Shared Function FlagDescargaYard() As Byte
        Return OracleDAO.ExecuteScalar("SELECT FLAG_COL_DESCARGA_YARD FROM REDEX.TB_PARAMETROS WHERE COD_EMPRESA = 1")
    End Function

End Class
