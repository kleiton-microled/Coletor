Public Class TalieDAO

    Public Shared Function ObterRegistrosTalie(ByVal Talie As Long) As DataTable

        Dim SQL As New StringBuilder

        SQL.Append("SELECT ")
        SQL.Append("	D.AUTONUM_BCG, ")
        SQL.Append("	B.QTDE_DESCARGA AS QUANTIDADE, ")
        SQL.Append("	B.AUTONUM_EMB, ")
        SQL.Append("	D.AUTONUM_PRO, ")
        SQL.Append("	B.MARCA, ")
        SQL.Append("	B.QTDE_ESTUFAGEM, ")
        SQL.Append("	A.TERMINO, ")
        SQL.Append("	B.COMPRIMENTO, ")
        SQL.Append("	B.LARGURA, ")
        SQL.Append("	B.ALTURA, ")
        SQL.Append("	B.PESO, ")
        SQL.Append("	B.AUTONUM_NF, ")
        SQL.Append("	A.AUTONUM_BOO, ")
        SQL.Append("	B.AUTONUM_TI, ")
        SQL.Append("	A.AUTONUM_GATE, ")
        SQL.Append("	A.AUTONUM_TALIE, ")
        SQL.Append("	B.YARD, ")
        SQL.Append("	B.ARMAZEM, ")
        SQL.Append("	B.AUTONUM_EMB, ")
        SQL.Append("	D.AUTONUM_EMB AS EMB_RESERVA, ")
        SQL.Append("	ETQ.CODPRODUTO, ")
        SQL.Append("	B.IMO, ")
        SQL.Append("	B.UNO, ")
        SQL.Append("	B.IMO2, ")
        SQL.Append("	B.UNO2, ")
        SQL.Append("	B.IMO3, ")
        SQL.Append("	B.UNO3, ")
        SQL.Append("	B.IMO4, ")
        SQL.Append("	B.UNO4, ")
        SQL.Append("	E.AUTONUM_REGCS ")
        SQL.Append("FROM  ")
        SQL.Append("	REDEX.TB_TALIE A ")
        SQL.Append("INNER JOIN  ")
        SQL.Append("	REDEX.TB_TALIE_ITEM B ON A.AUTONUM_TALIE = B.AUTONUM_TALIE ")
        SQL.Append("INNER JOIN  ")
        SQL.Append("	REDEX.TB_REGISTRO_CS E ON E.AUTONUM_REGCS = B.AUTONUM_REGCS ")
        SQL.Append("INNER JOIN  ")
        SQL.Append("	REDEX.TB_BOOKING_CARGA D ON D.AUTONUM_BCG = E.AUTONUM_BCG ")
        SQL.Append("LEFT JOIN  ")
        SQL.Append("	( ")
        SQL.Append("		SELECT  ")
        SQL.Append("			AUTONUM_RCS, ")
        SQL.Append("			SUBSTR(CODPRODUTO,1,8) CODPRODUTO ")
        SQL.Append("		FROM  ")
        SQL.Append("			REDEX.ETIQUETAS ")
        SQL.Append("		GROUP BY  ")
        SQL.Append("			AUTONUM_RCS, ")
        SQL.Append("			SUBSTR(CODPRODUTO,1,8) ")
        SQL.Append("	) ETQ ON E.AUTONUM_REGCS = ETQ.AUTONUM_RCS ")
        SQL.Append("WHERE  ")
        SQL.Append("	A.AUTONUM_TALIE = " & Talie)

        Return OracleDAO.List(SQL.ToString())

    End Function

    Public Shared Function ObterProximoID()
        Return OracleDAO.ExecuteScalar("SELECT REDEX.SEQ_TB_TALIE.NEXTVAL FROM DUAL")
    End Function

    Public Shared Function TalieFechado(ByVal Talie As Long) As Byte
        Return OracleDAO.ExecuteScalar("SELECT NVL(FLAG_FECHADO,0) FLAG_FECHADO FROM REDEX.TB_TALIE WHERE AUTONUM_TALIE = " & Talie)
    End Function

    Public Shared Function TalieFechadoParaReservaPlaca(ByVal AutonumBooking As Long, ByVal Placa As String) As Byte
        Return OracleDAO.ExecuteScalar("SELECT NVL(FLAG_FECHADO,0) FLAG_FECHADO FROM REDEX.TB_TALIE WHERE AUTONUM_BOO = " & AutonumBooking & " AND PLACA = '" & Placa & "'")
    End Function

    Public Shared Function ExisteCargaCadastrada(ByVal Talie As Long) As Short
        Return OracleDAO.ExecuteScalar("SELECT COUNT(*) FROM REDEX.TB_TALIE_ITEM WHERE AUTONUM_TALIE = " & Talie)
    End Function
    Public Shared Function ExisteTalieAberto(ByVal Registro As String) As Short
        Return OracleDAO.ExecuteScalar("SELECT COUNT(*) FROM REDEX.TB_TALIE WHERE autonum_reg=" & Registro & " and nvl(flag_fechado,0)=0")
    End Function

    Public Shared Function ObterQuantidadeDescargaPorTalie(ByVal Talie As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT NVL(SUM(QTDE_DESCARGA),0) FROM REDEX.TB_TALIE_ITEM WHERE AUTONUM_TALIE = " & Talie)
    End Function

    Public Shared Function ItensCadastradosSemPosicao(ByVal Talie As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT COUNT(*) FROM REDEX.TB_MARCANTES_RDX WHERE AUTONUM_TALIE=" & Talie & " AND YARD IS NULL")
    End Function

    Public Shared Function TotalEtiquetas(ByVal Talie As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT COUNT(*) FROM REDEX.TB_MARCANTES_RDX T WHERE T.AUTONUM_TALIE = " & Talie)
    End Function

    Public Shared Function EtiquetasComPendencia(ByVal Talie As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT COUNT(*) FROM REDEX.TB_TALIE T INNER JOIN REDEX.TB_TALIE_ITEM TI ON T.AUTONUM_TALIE = TI.AUTONUM_TALIE INNER JOIN REDEX.ETIQUETAS E ON TI.AUTONUM_REGCS = E.AUTONUM_RCS WHERE T.AUTONUM_TALIE = " & Talie & " AND EMISSAO IS NULL")
    End Function

    Public Shared Function MarcantesComPendencia(ByVal Talie As Long) As Long
        Dim Sql As String
        Sql = " Select count(*) from "
        Sql = Sql & " (SELECT SUM(VOLUMES)   QTDE_MC FROM REDEX.TB_MARCANTES_RDX WHERE AUTONUM_TALIE=" & Talie & " ) a , "
        Sql = Sql & " (SELECT SUM(QTDE_DESCARGA) QTDE_DS FROM REDEX.TB_TALIE_ITEM WHERE AUTONUM_TALIE=" & Talie & ") b "
        Sql = Sql & " where a.QTDE_MC <> B.QTDE_DS "

        Return OracleDAO.ExecuteScalar(Sql)

    End Function

    Public Shared Function InserirTalie(
                                       ByVal AutonumTalie As Long,
                                       ByVal DataInicio As String,
                                       ByVal Conferente As Long,
                                       ByVal Equipe As Long,
                                       ByVal AutonumBooking As Long,
                                       ByVal Operacao As String,
                                       ByVal Placa As String,
                                       ByVal AutonumGate As Long,
                                       ByVal AutonumRegistro As Long,
                                       ByVal Obs As String) As Boolean

        Dim SQL As New StringBuilder

        SQL.Append("INSERT INTO ")
        SQL.Append("	REDEX.TB_TALIE( ")
        SQL.Append("		AUTONUM_TALIE, ")
        SQL.Append("		AUTONUM_PATIO, ")
        SQL.Append("		INICIO, ")
        SQL.Append("		TERMINO, ")
        SQL.Append("		FLAG_DESCARGA, ")
        SQL.Append("		FLAG_ESTUFAGEM, ")
        SQL.Append("		FLAG_CARREGAMENTO, ")
        SQL.Append("		CROSSDOCKING, ")
        SQL.Append("		CONFERENTE, ")
        SQL.Append("		EQUIPE, ")
        SQL.Append("		AUTONUM_BOO, ")
        SQL.Append("		FORMA_OPERACAO, ")
        SQL.Append("		PLACA, ")
        SQL.Append("		AUTONUM_GATE, ")
        SQL.Append("		FLAG_COMPLETO, ")
        SQL.Append("		AUTONUM_REG, ")
        SQL.Append("		OBS ")
        SQL.Append("	) VALUES ( ")
        SQL.Append("		" & AutonumTalie & ",")
        SQL.Append("		NULL, ")
        SQL.Append("		TO_DATE('" & DataInicio & "','DD/MM/YYYY HH24:MI'),")
        Sql.Append("		NULL, ")
        Sql.Append("		1, ")
        Sql.Append("		0, ")
        Sql.Append("		0, ")
        Sql.Append("		0, ")
        Sql.Append("		" & Conferente & ",")
        Sql.Append("        " & Equipe & ",")
        Sql.Append("        " & AutonumBooking & ",")
        Sql.Append("		'" & Operacao & "', ")
        Sql.Append("		'" & Placa & "', ")
        Sql.Append("		" & AutonumGate & ",")
        Sql.Append("		0,")
        Sql.Append("		" & AutonumRegistro & ",")
        Sql.Append("		'" & Obs & "' ")
        Sql.Append("	) ")

        If OracleDAO.Execute(Sql.ToString()) Then
            Return True
        End If

        Return False

    End Function

    Public Shared Function AlterarTalie(
                                       ByVal AutonumTalie As Long,
                                       ByVal DataInicio As String,
                                       ByVal Conferente As Long,
                                       ByVal Equipe As Long,
                                       ByVal Operacao As String,
                                       ByVal Obs As String) As Boolean

        Dim SQL As New StringBuilder

        SQL.Append("UPDATE REDEX.TB_TALIE SET ")
        SQL.Append("	INICIO=TO_DATE('" & DataInicio & "','DD/MM/YYYY HH24:MI'),")
        SQL.Append("	CONFERENTE=" & Conferente & ",")
        SQL.Append("	EQUIPE=" & Equipe & ",")
        SQL.Append("	FORMA_OPERACAO='" & Operacao & "', ")
        SQL.Append("	OBS='" & Obs & "' ")
        SQL.Append("WHERE  ")
        SQL.Append("	AUTONUM_TALIE = " & AutonumTalie)

        If OracleDAO.Execute(SQL.ToString()) Then
            Return True
        End If

        Return False

    End Function

    Public Shared Function ExcluirTalie(ByVal Talie As Long) As Boolean
        Return OracleDAO.Execute("DELETE FROM REDEX.TB_TALIE WHERE AUTONUM_TALIE = " & Talie)
    End Function

    Public Shared Function GerarAlertaEtiqueta(ByVal Talie As Long, ByVal Alerta As Short) As Boolean
        Return OracleDAO.Execute("UPDATE REDEX.TB_TALIE SET ALERTA_ETIQUETA = " & Alerta & " WHERE AUTONUM_TALIE =" & Talie)
    End Function

End Class
