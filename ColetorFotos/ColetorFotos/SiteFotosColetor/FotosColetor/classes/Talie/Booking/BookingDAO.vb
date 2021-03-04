Public Class BookingDAO

    Public Shared Function ObterCodigoPatioPorBooking(ByVal AutonumBooking As Long) As Short
        Return OracleDAO.ExecuteScalar("SELECT AUTONUM_PATIOS FROM REDEX.TB_BOOKING WHERE AUTONUM_BOO = " & AutonumBooking)
    End Function

    Public Shared Function ObterQuantidade(ByVal AutonumBooking As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT NVL(SUM(BCG.QTDE),0) FROM REDEX.TB_BOOKING BOO INNER JOIN REDEX.TB_BOOKING_CARGA BCG ON BOO.AUTONUM_BOO = BCG.AUTONUM_BOO WHERE BOO.AUTONUM_BOO = " & AutonumBooking & " AND BCG.FLAG_CS=1")
    End Function

    Public Shared Function ObterQuantidadeEntrada(ByVal AutonumBooking As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT SUM(PCS.QTDE_ENTRADA) FROM REDEX.TB_BOOKING BOO INNER JOIN REDEX.TB_BOOKING_CARGA BCG ON BOO.AUTONUM_BOO = BCG.AUTONUM_BOO INNER JOIN REDEX.TB_PATIO_CS PCS ON BCG.AUTONUM_BCG = PCS.AUTONUM_BCG AND BOO.AUTONUM_BOO = " & AutonumBooking)
    End Function

    Public Shared Function FinalizarBooking(ByVal AutonumBooking As Long) As Boolean
        Return OracleDAO.Execute("UPDATE REDEX.TB_BOOKING SET FLAG_FINALIZADO = 1 WHERE AUTONUM_BOO = " & AutonumBooking)
    End Function

    Public Shared Function SetStatusReserva(ByVal AutonumBooking As Long) As Boolean
        Return OracleDAO.Execute("UPDATE REDEX.TB_BOOKING SET STATUS_RESERVA=2 WHERE AUTONUM_BOO = " & AutonumBooking)
    End Function

End Class
