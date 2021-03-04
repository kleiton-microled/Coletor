Public Class AmrGateDAO

    Public Shared Function ObterProximoID()
        Return OracleDAO.ExecuteScalar("SELECT REDEX.SEQ_TB_AMR_GATE.NEXTVAL FROM DUAL")
    End Function

    Public Shared Function InserirRegistroAmrGate(
                                                 ByVal AutonumGate As Long,
                                                 ByVal CsRdx As Long,
                                                 ByVal Balanca As Long,
                                                 ByVal Inicio As String,
                                                 ByVal AutonumBooking As Long) As Boolean

        Dim SQL As New StringBuilder

        SQL.Append("INSERT INTO ")
        SQL.Append("	REDEX.TB_AMR_GATE ")
        SQL.Append("		( ")
        SQL.Append("			AUTONUM, ")
        SQL.Append("			GATE, ")
        SQL.Append("			CNTR_RDX, ")
        SQL.Append("			CS_RDX, ")
        SQL.Append("			PESO_ENTRADA, ")
        SQL.Append("			PESO_SAIDA, ")
        SQL.Append("			DATA, ")
        SQL.Append("			ID_BOOKING, ")
        SQL.Append("			ID_OC, ")
        SQL.Append("			FUNCAO_GATE, ")
        SQL.Append("			FLAG_HISTORICO ")
        SQL.Append("		) VALUES ( ")
        SQL.Append("			" & ObterProximoID() & ",")
        SQL.Append("			" & AutonumGate & ",")
        SQL.Append("			0, ")
        SQL.Append("			" & CsRdx & ", ")
        SQL.Append("			" & Balanca & ", ")
        SQL.Append("			0, ")
        SQL.Append("			TO_DATE('" & Inicio & "','DD/MM/YYYY HH24:MI'), ")
        SQL.Append("			" & AutonumBooking & ", ")
        SQL.Append("			0, ")
        SQL.Append("			203, ")
        SQL.Append("			0 ")
        SQL.Append("		) ")

        If OracleDAO.Execute(SQL.ToString()) Then
            Return True
        End If

        Return False

    End Function

End Class
