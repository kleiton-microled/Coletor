Public Class TalieRegistroDAO

    Public Shared Function ObterRegistrosTaliePorRegistro(ByVal Registro As String) As DataTable

        Dim SQL As New StringBuilder

        SQL.Append("SELECT ")
        SQL.Append("	T.AUTONUM_TALIE, ")
        SQL.Append("	T.AUTONUM_PATIO, ")
        SQL.Append("	T.PLACA, ")
        SQL.Append("	T.INICIO, ")
        SQL.Append("	T.TERMINO, ") 
        SQL.Append("	T.FLAG_DESCARGA, ")
        SQL.Append("	T.FLAG_ESTUFAGEM, ") 
        SQL.Append("	T.CROSSDOCKING, ") 
        SQL.Append("	NVL(T.CONFERENTE,0) AS CONFERENTE, ")
        SQL.Append("	NVL(T.EQUIPE,0) AS EQUIPE, ") 
        SQL.Append("	T.AUTONUM_BOO, ") 
        SQL.Append("	T.FLAG_CARREGAMENTO, ")
        SQL.Append("	T.FORMA_OPERACAO, ") 
        SQL.Append("	T.AUTONUM_GATE, ") 
        SQL.Append("	T.FLAG_FECHADO, ")
        SQL.Append("	T.OBS, ") 
        SQL.Append("	T.AUTONUM_RO, ")
        SQL.Append("	T.AUDIT_225, ")
        SQL.Append("	T.ANO_TERMO, ") 
        SQL.Append("	T.TERMO, ") 
        SQL.Append("	T.DATA_TERMO, ")
        SQL.Append("	T.FLAG_PACOTES, ") 
        SQL.Append("	T.ALERTA_ETIQUETA, ") 
        SQL.Append("	T.AUTONUM_REG, ")
        SQL.Append("	T.FLAG_COMPLETO, ") 
        SQL.Append("	T.EMAIL_ENVIADO, ")
        SQL.Append("	BOO.REFERENCE, ") 
        SQL.Append("	CP.FANTASIA ") 
        SQL.Append("FROM ")
        SQL.Append("	REDEX.TB_TALIE T ")
        SQL.Append("INNER JOIN ") 
        SQL.Append("	REDEX.TB_BOOKING BOO ON T.AUTONUM_BOO = BOO.AUTONUM_BOO ")
        SQL.Append("INNER JOIN ") 
        SQL.Append("	REDEX.TB_CAD_PARCEIROS CP ON BOO.AUTONUM_PARCEIRO = CP.AUTONUM ")
        SQL.Append("WHERE ")
        SQL.Append("	T.AUTONUM_REG = " & Registro)

        Return OracleDAO.List(SQL.ToString())

    End Function

    Public Shared Function ContemRegistroPorCodigo(ByVal CodigoRegistro As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT COUNT(1) FROM REDEX.TB_REGISTRO WHERE AUTONUM_REG = " & Val(CodigoRegistro))
    End Function

    Public Shared Function ObterPlacaPorCodigoRegistro(ByVal CodigoRegistro As Long) As String
        Return OracleDAO.ExecuteScalar("SELECT PLACA FROM REDEX.TB_REGISTRO WHERE AUTONUM_REG = " & Val(CodigoRegistro))
    End Function

    Public Shared Function ExisteGateIn(ByVal CodigoRegistro As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT COUNT(1) FROM REDEX.TB_REGISTRO B INNER JOIN REDEX.TB_GATE_NEW A ON B.AUTONUM_GATE = A.AUTONUM INNER JOIN REDEX.TB_BOOKING E ON B.AUTONUM_BOO = E.AUTONUM_BOO INNER JOIN REDEX.TB_CAD_PARCEIROS CP ON E.AUTONUM_PARCEIRO = CP.AUTONUM WHERE B.AUTONUM_REG = " & Val(CodigoRegistro) & " AND A.DT_GATE_IN IS NOT NULL")
    End Function

    Public Shared Function ObterRegistrosGate(ByVal CodigoRegistro As String) As DataTable
        Return OracleDAO.List("SELECT E.AUTONUM_PARCEIRO, E.REFERENCE, A.AUTONUM, E.AUTONUM_BOO, CP.FANTASIA FROM REDEX.TB_REGISTRO B INNER JOIN REDEX.TB_GATE_NEW A ON B.AUTONUM_GATE = A.AUTONUM INNER JOIN REDEX.TB_BOOKING E ON B.AUTONUM_BOO = E.AUTONUM_BOO INNER JOIN REDEX.TB_CAD_PARCEIROS CP ON E.AUTONUM_PARCEIRO = CP.AUTONUM WHERE B.AUTONUM_REG=" & Val(CodigoRegistro) & " AND A.DT_GATE_IN IS NOT NULL ")
    End Function

    Public Shared Function FinalizarTalie(ByVal Talie As Long) As Boolean
        Return OracleDAO.Execute("UPDATE REDEX.TB_TALIE SET FLAG_FECHADO=1,TERMINO=SYSDATE WHERE AUTONUM_TALIE = " & Talie)
    End Function

End Class
