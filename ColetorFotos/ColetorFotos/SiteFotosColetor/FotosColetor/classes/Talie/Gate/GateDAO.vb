Public Class GateDAO

    Public Shared Function ObterPesoBruto(ByVal AutonumGateNew As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT BRUTO FROM REDEX.TB_GATE_NEW WHERE AUTONUM = " & AutonumGateNew)
    End Function

End Class
