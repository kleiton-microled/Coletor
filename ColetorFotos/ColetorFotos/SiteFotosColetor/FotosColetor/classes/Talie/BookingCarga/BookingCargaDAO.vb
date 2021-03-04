Public Class BookingCargaDAO

    Public Shared Function AtualizaIMO(ByVal IMO As String, ByVal AutonumBookingCarga As Long) As Boolean
        Return OracleDAO.Execute("UPDATE REDEX.TB_BOOKING_CARGA SET IMO='" & IMO & "' WHERE AUTONUM_BCG = " & AutonumBookingCarga)
    End Function

End Class
