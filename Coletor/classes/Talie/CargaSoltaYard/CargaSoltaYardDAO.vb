Public Class CargaSoltaYardDAO

    Public Shared Function ObterProximoID()
        Return OracleDAO.ExecuteScalar("SELECT REDEX.SEQ_CARGA_SOLTA_YARD.NEXTVAL FROM DUAL")
    End Function

    Public Shared Function InserirRegistroCargaSoltaYard(
                                                        ByVal AutonumPatioCs As Long,
                                                        ByVal Armazem As String,
                                                        ByVal Yard As String,
                                                        ByVal Quantidade As Long) As Boolean

        Dim SQL As New StringBuilder

        SQL.Append("INSERT INTO ")
        SQL.Append("	REDEX.TB_CARGA_SOLTA_YARD ")
        SQL.Append("		( ")
        SQL.Append("			AUTONUM, ")
        SQL.Append("			AUTONUM_PATIOCS, ")
        SQL.Append("			ARMAZEM, ")
        SQL.Append("			YARD, ")
        SQL.Append("			QUANTIDADE, ")
        SQL.Append("			MOTIVO_COL ")
        SQL.Append("		) VALUES( ")
        SQL.Append("			" & ObterProximoID() & ",")
        SQL.Append("			" & AutonumPatioCs & ",")
        SQL.Append("			" & Armazem & ",")
        SQL.Append("			'" & Yard & "'" & ",")
        SQL.Append("			" & Quantidade & ",")
        SQL.Append("			0")
        SQL.Append("		) ")

        If OracleDAO.Execute(SQL.ToString()) Then
            Return True
        End If

        Return False

    End Function


    Public Shared Function InserirRegistroCargaSoltaYardM(
                                                        ByVal Autonum_TALIE As Long
                                                        ) As Boolean

        Dim SQL As String
        Dim tb1 As DataTable
        SQL = "Select Autonum,Autonum_PCS,Armazem,Yard,Volumes"
        SQL = SQL & " From REDEX.TB_MARCANTES_RDX Where AUTONUM_TALIE = " & Autonum_TALIE
        SQL = SQL & " ORDER BY AUTONUM "

        tb1 = OracleDAO.List(SQL)

        Dim idYard As Long


        For I = 0 To tb1.Rows.Count - 1

            idYard = OracleDAO.ExecuteScalar("SELECT REDEX.SEQ_CARGA_SOLTA_YARD.NEXTVAL FROM DUAL")

            SQL = " INSERT INTO  REDEX.TB_CARGA_SOLTA_YARD "
            SQL = SQL & " ("
            SQL = SQL & " AUTONUM,"
            SQL = SQL & " AUTONUM_PATIOCS,"
            SQL = SQL & " Armazem,"
            SQL = SQL & " Yard,"
            SQL = SQL & " Quantidade,"
            SQL = SQL & " MOTIVO_COL ) SELECT "
            SQL = SQL & idYard & " ,"
            SQL = SQL & " AUTONUM_PCS,"
            SQL = SQL & " Armazem,"
            SQL = SQL & " Yard,"
            SQL = SQL & " VOLUMES,"
            SQL = SQL & " 0"
            SQL = SQL & " From REDEX.TB_MARCANTES_RDX Where AUTONUM = " & tb1.Rows(I)("AUTONUM") & " AND NVL(ARMAZEM,0) >0 "
            'Try
            OracleDAO.Execute(SQL)
            'Catch
            'MsgBox("hei")
            'End Try

            SQL = "UPDATE REDEX.TB_MARCANTES_RDX SET AUTONUM_CS_YARD=" & idYard & " WHERE AUTONUM=" & tb1.Rows(I)("AUTONUM")
            OracleDAO.Execute(SQL)

        Next



        Return True

    End Function

End Class
