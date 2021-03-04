Public Class TalieItemDAO

    Public Shared Function ObterProximoID()
        Return OracleDAO.ExecuteScalar("SELECT REDEX.SEQ_TB_TALIE_ITEM.NEXTVAL FROM DUAL")
    End Function

    Public Shared Function ObterItens(ByVal item As Long) As DataTable

        Dim SQL As New StringBuilder()

        SQL.Append("SELECT ")
        SQL.Append("    TI.AUTONUM_NF, ")
        SQL.Append("    TI.QTDE_DESCARGA, ")
        SQL.Append("    TI.QTDE_ESTUFAGEM, ")
        SQL.Append("    TI.REMONTE, ")
        SQL.Append("    TI.FUMIGACAO, ")
        SQL.Append("    TI.IMO, ")
        SQL.Append("    TI.UNO, ")
        SQL.Append("    TI.IMO2, ")
        SQL.Append("    TI.UNO2, ")
        SQL.Append("    TI.IMO3, ")
        SQL.Append("    TI.UNO3, ")
        SQL.Append("    TI.IMO4, ")
        SQL.Append("    TI.UNO4, ")
        SQL.Append("    TI.YARD, ")
        SQL.Append("    TI.AUTONUM_EMB, ")
        SQL.Append("    TI.FLAG_MADEIRA, ")
        SQL.Append("    TI.FLAG_FRAGIL, ")
        SQL.Append("    TI.AUTONUM_REGCS, ")
        SQL.Append("    TI.NF AS NUM_NF, ")
        SQL.Append("    TO_CHAR(TI.COMPRIMENTO,'00.00') AS CLAC, ")
        SQL.Append("    TO_CHAR(TI.LARGURA,'00.00') AS CLAL, ")
        SQL.Append("    TO_CHAR(TI.ALTURA,'00.00') AS CLAA, ")
        SQL.Append("    TO_CHAR(TI.PESO,'000000.000') AS PESOSTR, ")
        SQL.Append("    E.SIGLA, ")
        SQL.Append("    E.DESCRICAO_EMB || '-' || E.AUTONUM_EMB AS EMBALAGEM, ")
        SQL.Append("    TI.YARD ")
        SQL.Append("FROM ")
        SQL.Append("    REDEX.TB_TALIE_ITEM TI ")
        SQL.Append("LEFT JOIN ")
        SQL.Append("    REDEX.TB_NOTAS_FISCAIS NF ON TI.AUTONUM_NF = NF.AUTONUM_NF ")
        SQL.Append("LEFT JOIN ")
        SQL.Append("    REDEX.TB_CAD_EMBALAGENS E ON TI.AUTONUM_EMB = E.AUTONUM_EMB ")
        SQL.Append("WHERE ")
        SQL.Append("    TI.AUTONUM_TI = " & Val(item))

        Return OracleDAO.List(SQL.ToString())

    End Function

    Public Shared Function GravarDadosTemporarios(ByVal TalieItemDto As TalieItemDTO) As Boolean

        Dim SQL As New StringBuilder

        SQL.Append("UPDATE REDEX.TB_TMP_COLETOR_TALIE_ITENS ")
        SQL.Append("	LBLPESOBRUTO = '" & TalieItemDto.PesoBruto & "', ")
        SQL.Append("	LBLQUANTIDADE = '" & TalieItemDto.Quantidade & "', ")
        SQL.Append("	LBLCODIGOREGCS = '" & TalieItemDto.CodigoRegCs & "', ")
        SQL.Append("	LBLCODIGOTALIE = '" & TalieItemDto.CodigoTalie & "', ")
        SQL.Append("	LBLCODIGONF = '" & TalieItemDto.CodigoNF & "', ")
        SQL.Append("	LBLCODIGOBOOKING = '" & TalieItemDto.CodigoBooking & "', ")
        SQL.Append("	LBLCODIGOITEM = '" & TalieItemDto.CodigoItem & "', ")
        SQL.Append("	LBLFIMNOTA = '" & TalieItemDto.FimNota & "', ")
        SQL.Append("	LBLCODIGOPATIO = '" & TalieItemDto.CodigoPatio & "', ")
        SQL.Append("	LBLCODIGOREGISTRO = '" & TalieItemDto.CodigoRegistro & "', ")
        SQL.Append("	TXTNF = '" & TalieItemDto.NumNF & "', ")
        SQL.Append("	TXTQTDE = '" & TalieItemDto.Qtde & "', ")
        SQL.Append("	TXTPESO = '" & TalieItemDto.Peso & "', ")
        SQL.Append("	TXTSALDO = '" & TalieItemDto.Saldo & "', ")
        SQL.Append("	DCEMBALAGEM = '" & TalieItemDto.Embalagem & "', ")
        SQL.Append("	TXTCLAC = '" & TalieItemDto.CLAC & "', ")
        SQL.Append("	TXTCLAL = '" & TalieItemDto.CLAL & "', ")
        SQL.Append("	TXTCLAA = '" & TalieItemDto.CLAA & "', ")
        SQL.Append("	TXTLOCAL = '" & TalieItemDto.Local & "', ")
        SQL.Append("	TXTIMO1 = '" & TalieItemDto.IMO1 & "', ")
        SQL.Append("	TXTIMO2 = '" & TalieItemDto.IMO2 & "', ")
        SQL.Append("	TXTIMO3 = '" & TalieItemDto.IMO3 & "', ")
        SQL.Append("	TXTIMO4 = '" & TalieItemDto.IMO4 & "', ")
        SQL.Append("	TXTUNO1 = '" & TalieItemDto.UNO1 & "', ")
        SQL.Append("	TXTUNO2 = '" & TalieItemDto.UNO2 & "', ")
        SQL.Append("	TXTUNO3 = '" & TalieItemDto.UNO3 & "', ")
        SQL.Append("	TXTUNO4 = '" & TalieItemDto.UNO4 & "', ")
        SQL.Append("	TXTREMONTE = '" & TalieItemDto.Remonte & "', ")
        SQL.Append("	TXTFUMIGACAO = '" & TalieItemDto.Fumigacao & "' ")

        Return OracleDAO.Execute(SQL.ToString())

    End Function

    Public Shared Function ObterPesoQuantidade(ByVal AutonumRegCs As Long) As DataTable

        Dim SQL As New StringBuilder()

        SQL.Append("SELECT ")
        SQL.Append("    B.PESO_BRUTO, ")
        SQL.Append("    B.QTDE ")
        SQL.Append("FROM ")
        SQL.Append("    REDEX.TB_REGISTRO_CS A ")
        SQL.Append("INNER JOIN ")
        SQL.Append("    REDEX.TB_BOOKING_CARGA B ON A.AUTONUM_BCG = B.AUTONUM_BCG ")
        SQL.Append("WHERE ")
        SQL.Append("    A.AUTONUM_REGCS = " & AutonumRegCs)

        Return OracleDAO.List(SQL.ToString())

    End Function

    Public Shared Function CarregarDescarga(ByVal Talie As Long) As List(Of TalieDescargaDTO)

        Dim SQL As New StringBuilder()

        SQL.Append("SELECT ")
        SQL.Append("    TI.AUTONUM_TI AS CodigoItem, ")
        SQL.Append("    'NF ' || NVL(TI.NF,'') || ' ' || NVL(QTDE_DESCARGA,0) || '   ' || NVL(E.SIGLA,E.DESCRICAO_EMB) || ' ' || TRIM(TO_CHAR(NVL(TI.COMPRIMENTO,''),'00.00')) || 'x' || TRIM(TO_CHAR(NVL(TI.LARGURA,''),'00.00')) || 'x' || TRIM(TO_CHAR(NVL(TI.ALTURA,''),'00.00')) AS Descricao ")
        SQL.Append("FROM ")
        SQL.Append("    REDEX.TB_TALIE T ")
        SQL.Append("INNER JOIN ")
        SQL.Append("    REDEX.TB_TALIE_ITEM TI ON T.AUTONUM_TALIE = TI.AUTONUM_TALIE ")
        SQL.Append("LEFT JOIN ")
        SQL.Append("    REDEX.TB_CAD_EMBALAGENS E ON TI.AUTONUM_EMB = E.AUTONUM_EMB ")
        SQL.Append("WHERE ")
        SQL.Append("    T.AUTONUM_TALIE = " & Talie)
        SQL.Append("ORDER BY ")
        SQL.Append("    TI.AUTONUM_TI ")

        Dim ds As New DataTable

        Try
            ds = OracleDAO.List(SQL.ToString())
        Catch ex As Exception
            Throw New Exception(SQL.ToString())
        End Try

        Dim Lista As New List(Of TalieDescargaDTO)

        If ds IsNot Nothing Then
            For Each Linha As DataRow In ds.Rows

                Dim item As New TalieDescargaDTO
                item.CodigoItem = Linha("CodigoItem").ToString()
                item.Descricao = Linha("Descricao").ToString()

                Lista.Add(item)

            Next
        End If

        Return Lista

    End Function

    Public Shared Function ObterIDNotaFiscal(ByVal AutonumBOO As Long, ByVal NumNF As String) As DataTable

        Dim SQL As New StringBuilder()

        SQL.Append("SELECT ")
        SQL.Append("    A.AUTONUM_NF ")
        SQL.Append("FROM ")
        SQL.Append("    REDEX.TB_NOTAS_FISCAIS A ")
        SQL.Append("INNER JOIN ")
        SQL.Append("    REDEX.TB_BOOKING BOO ON A.AUTONUM_BOO = BOO.AUTONUM_BOO ")
        SQL.Append("AND ")
        SQL.Append("    BOO.AUTONUM_BOO = " & AutonumBOO)
        SQL.Append(" AND ")
        SQL.Append("    A.NUM_NF = '" & NumNF & "' ")

        Return OracleDAO.List(SQL.ToString())

    End Function

    Public Shared Function ObterItensNF(ByVal AutonumReg As Long, ByVal NF As String) As DataTable

        Dim SQL As New StringBuilder()

        SQL.Append("SELECT ")
        SQL.Append("    A.AUTONUM_REGCS AS ID, ")
        SQL.Append("    A.QUANTIDADE, ")
        SQL.Append("    B.PESO_BRUTO, ")
        SQL.Append("    B.QTDE, ")
        SQL.Append("    B.AUTONUM_EMB, ")
        SQL.Append("    D.DESC_PRODUTO, ")
        SQL.Append("    C.SIGLA, ")
        SQL.Append("    C.DESCRICAO_EMB || '-' || C.AUTONUM_EMB AS EMBALAGEM, ")
        SQL.Append("    B.IMO, ")
        SQL.Append("    B.IMO2, ")
        SQL.Append("    B.IMO3, ")
        SQL.Append("    B.IMO4, ")
        SQL.Append("    B.UNO, ")
        SQL.Append("    B.UNO2, ")
        SQL.Append("    B.UNO3, ")
        SQL.Append("    B.UNO4 ")
        SQL.Append("FROM ")
        SQL.Append("    REDEX.TB_REGISTRO_CS A ")
        SQL.Append("INNER JOIN ")
        SQL.Append("    REDEX.TB_BOOKING_CARGA B ON A.AUTONUM_BCG = B.AUTONUM_BCG ")
        SQL.Append("INNER JOIN ")
        SQL.Append("    REDEX.TB_CAD_EMBALAGENS C ON B.AUTONUM_EMB = C.AUTONUM_EMB ")
        SQL.Append("INNER JOIN ")
        SQL.Append("    REDEX.TB_CAD_PRODUTOS D ON B.AUTONUM_PRO = D.AUTONUM_PRO ")
        SQL.Append("WHERE ")
        SQL.Append("    A.AUTONUM_REG = " & Val(AutonumReg))
        SQL.Append(" AND ")
        SQL.Append("    A.NF = '" & NF & "'")

        Return OracleDAO.List(SQL.ToString())

    End Function

    Public Shared Function ObterResumoQuantidadeDescarga(ByVal AutonumRegCs As Long, Optional ByVal AutonumTI As Long = 0) As Long
        Return OracleDAO.ExecuteScalar("SELECT NVL(SUM(QTDE_DESCARGA),0) FROM REDEX.TB_TALIE_ITEM WHERE AUTONUM_REGCS = " & AutonumRegCs & IIf(AutonumTI > 0, " AND AUTONUM_TI <> " & AutonumTI, String.Empty))
    End Function

    Public Shared Function ObterResumoQuantidade(ByVal AutonumRegCs As Long) As Long
        Return OracleDAO.ExecuteScalar("SELECT NVL(SUM(QUANTIDADE),0) FROM REDEX.TB_REGISTRO_CS WHERE AUTONUM_REGCS = " & AutonumRegCs)
    End Function

    Public Shared Function ConsultarIMOPorCodigoDaCarga(ByVal Codigo As String) As Short
        Return OracleDAO.ExecuteScalar("SELECT COUNT(*) FROM REDEX.TB_CAD_CARGA_PERIGOSA WHERE CODE = '" & Codigo & "'")
    End Function

    Public Shared Function ConsultarUNOPorCodigoDaCarga(ByVal Codigo As Long) As Short
        Return OracleDAO.ExecuteScalar("SELECT COUNT(*) FROM REDEX.TB_CAD_ONU WHERE CODE = '" & Codigo & "'")
    End Function

    Public Shared Function ObterPosicaoPatio(ByVal AutonumPatio As Long, ByVal Local As String) As String
        Dim ArmR As String
        ArmR = OracleDAO.ExecuteScalar("SELECT NVL(MAX(A.ARMAZEM),0) FROM SGIPA.TB_YARD_CS A INNER JOIN SGIPA.TB_ARMAZENS_IPA B ON A.ARMAZEM=B.AUTONUM WHERE B.PATIO=" & AutonumPatio & " AND A.YARD = '" & Local & "' AND B.DESCR LIKE '%RDX%'")
        If ArmR = "0" Then
            Return OracleDAO.ExecuteScalar("SELECT NVL(MAX(A.ARMAZEM),0) FROM SGIPA.TB_YARD_CS A INNER JOIN SGIPA.TB_ARMAZENS_IPA B ON A.ARMAZEM=B.AUTONUM WHERE B.PATIO=" & AutonumPatio & " AND A.YARD = '" & Local & "'")
        Else
            Return ArmR
        End If
    End Function

    Public Shared Function InserirTalieItem(
                                           ByVal AutonumItem As Long,
                                           ByVal AutonumTalie As Long,
                                           ByVal AutonumRegCs As Long,
                                           ByVal Qtde As Integer,
                                           ByVal CLAC As String,
                                           ByVal CLAL As String,
                                           ByVal CLAA As String,
                                           ByVal Peso As String,
                                           ByVal Remonte As String,
                                           ByVal Fumigacao As String,
                                           ByVal Fragil As Boolean,
                                           ByVal Madeira As Boolean,
                                           ByVal Local As String,
                                           ByVal Armazem As String,
                                           ByVal AutonumNF As Long,
                                           ByVal NF As String,
                                           ByVal IMO1 As String,
                                           ByVal UNO1 As String,
                                           ByVal IMO2 As String,
                                           ByVal UNO2 As String,
                                           ByVal IMO3 As String,
                                           ByVal UNO3 As String,
                                           ByVal IMO4 As String,
                                           ByVal UNO4 As String,
                                           ByVal AutonumEmbalagem As Long) As Boolean

        Dim SQL As New StringBuilder

        SQL.Append("INSERT INTO ")
        SQL.Append("    REDEX.TB_TALIE_ITEM ")
        SQL.Append("    ( ")
        SQL.Append("        AUTONUM_TI, ")
        SQL.Append("        AUTONUM_TALIE, ")
        SQL.Append("        AUTONUM_REGCS, ")
        SQL.Append("        QTDE_DESCARGA, ")
        SQL.Append("        TIPO_DESCARGA, ")
        SQL.Append("        DIFERENCA, ")
        SQL.Append("        OBS, ")
        SQL.Append("        QTDE_DISPONIVEL, ")
        SQL.Append("        COMPRIMENTO, ")
        SQL.Append("        LARGURA, ")
        SQL.Append("        ALTURA, ")
        SQL.Append("        PESO, ")
        SQL.Append("        QTDE_ESTUFAGEM, ")
        SQL.Append("        MARCA, ")
        SQL.Append("        REMONTE, ")
        SQL.Append("        FUMIGACAO, ")
        SQL.Append("        FLAG_FRAGIL, ")
        SQL.Append("        FLAG_MADEIRA, ")
        SQL.Append("        YARD, ")
        SQL.Append("        ARMAZEM, ")
        SQL.Append("        AUTONUM_NF, ")
        SQL.Append("        NF, ")
        SQL.Append("        IMO, ")
        SQL.Append("        UNO, ")
        SQL.Append("        IMO2, ")
        SQL.Append("        UNO2, ")
        SQL.Append("        IMO3, ")
        SQL.Append("        UNO3, ")
        SQL.Append("        IMO4, ")
        SQL.Append("        UNO4, ")
        SQL.Append("        AUTONUM_EMB ")
        SQL.Append("    ) VALUES ( ")
        SQL.Append(AutonumItem & ",")
        SQL.Append(AutonumTalie & ",")
        SQL.Append(AutonumRegCs & ",")
        SQL.Append(Qtde & ",")
        SQL.Append("'',")
        SQL.Append("0,")
        SQL.Append("'',")
        SQL.Append("0,")
        SQL.Append(Replace(CLAC, ",", ".") & ",")
        SQL.Append(Replace(CLAL, ",", ".") & ",")
        SQL.Append(Replace(CLAA, ",", ".") & ",")
        SQL.Append(Replace(Peso, ",", ".") & ",")
        SQL.Append(Qtde & ",")
        SQL.Append("'',")
        SQL.Append("'" & Remonte & "',")
        SQL.Append("'" & Fumigacao & "',")
        SQL.Append(IIf(Fragil, 1, 0) & ",")
        SQL.Append(IIf(Madeira, 1, 0) & ",")

        If Armazem = 0 Then
            SQL.Append("null,")
            SQL.Append("null,")
        Else
            SQL.Append("'" & Local & "',")
            SQL.Append("'" & Armazem & "',")
        End If

        SQL.Append(AutonumNF & ",")
        SQL.Append("'" & NF & "',")
        SQL.Append("'" & IMO1 & "',")
        SQL.Append("'" & UNO1 & "',")
        SQL.Append("'" & IMO2 & "',")
        SQL.Append("'" & UNO2 & "',")
        SQL.Append("'" & IMO3 & "',")
        SQL.Append("'" & UNO3 & "',")
        SQL.Append("'" & IMO4 & "',")
        SQL.Append("'" & UNO4 & "',")
        SQL.Append(AutonumEmbalagem & "")
        SQL.Append(" ) ")

        Try
            If OracleDAO.Execute(SQL.ToString()) Then
                Return True
            End If
        Catch ex As Exception
            Throw New Exception(SQL.ToString())
        End Try

        Return False

    End Function

    Public Shared Function InserirTalieItemCol(
                                              ByVal AutonumItem As Long,
                                              ByVal AutonumUsuario As Long,
                                              ByVal BrowserName As String,
                                              ByVal BrowserVersion As String,
                                              ByVal MobileDeviceModel As String,
                                              ByVal MobileDeviceManufacturer As String,
                                              ByVal IsMobileDevice As Boolean,
                                              ByVal Ip_Connection As String) As Boolean

        Dim SQL As New StringBuilder

        SQL.Append("INSERT INTO ")
        SQL.Append("    REDEX.TB_TALIE_ITEM_COL ")
        SQL.Append("        ( ")
        SQL.Append("            AUTONUM_TI, ")
        SQL.Append("            USUARIO, ")
        SQL.Append("            DT, ")
        SQL.Append("            BROWSER_NAME, ")
        SQL.Append("            BROWSER_VERSION, ")
        SQL.Append("            MOBILEDEVICEMODEL, ")
        SQL.Append("            MOBILEDEVICEMANUFACTURER, ")
        SQL.Append("            FLAG_MOBILE, ")
        SQL.Append("            IP_CONNECTION ")
        SQL.Append("        ) VALUES ( ")
        SQL.Append("            " & AutonumItem & ",")
        SQL.Append("            " & AutonumUsuario & ",")
        SQL.Append("            SYSDATE, ")
        SQL.Append("            '" & BrowserName & "',")
        SQL.Append("            '" & BrowserVersion & "',")
        SQL.Append("            '" & MobileDeviceModel & "',")
        SQL.Append("            '" & MobileDeviceManufacturer & "',")
        SQL.Append("            " & Val(IsMobileDevice) & ",")
        SQL.Append("            '" & Ip_Connection & "'")
        SQL.Append("        ) ")

        Try
            If OracleDAO.Execute(SQL.ToString()) Then
                Return True
            End If
        Catch ex As Exception
            Throw New Exception(SQL.ToString())
        End Try

        Return False

    End Function

    Public Shared Function AlterarTalieItem(
                                          ByVal AutonumItem As Long,
                                          ByVal AutonumTalie As Long,
                                          ByVal AutonumRegCs As Long,
                                          ByVal Qtde As String,
                                          ByVal CLAC As String,
                                          ByVal CLAL As String,
                                          ByVal CLAA As String,
                                          ByVal Peso As String,
                                          ByVal Remonte As String,
                                          ByVal Fumigacao As String,
                                          ByVal Fragil As Boolean,
                                          ByVal Madeira As Boolean,
                                          ByVal Local As String,
                                          ByVal Armazem As String,
                                          ByVal AutonumNF As Long,
                                          ByVal NF As String,
                                          ByVal IMO1 As String,
                                          ByVal UNO1 As String,
                                          ByVal IMO2 As String,
                                          ByVal UNO2 As String,
                                          ByVal IMO3 As String,
                                          ByVal UNO3 As String,
                                          ByVal IMO4 As String,
                                          ByVal UNO4 As String,
                                          ByVal AutonumEmbalagem As Long) As Boolean

        Dim SQL As New StringBuilder

        SQL.Append("UPDATE REDEX.TB_TALIE_ITEM SET")
        SQL.Append("     QTDE_DESCARGA = " & Qtde)
        SQL.Append("    ,COMPRIMENTO=" & CLAC)
        SQL.Append("    ,LARGURA=" & CLAL)
        SQL.Append("    ,ALTURA=" & CLAA)
        SQL.Append("    ,PESO=" & Peso)
        SQL.Append("    ,QTDE_ESTUFAGEM=" & Qtde)
        SQL.Append("    ,REMONTE='" & Remonte & "'")
        SQL.Append("    ,FUMIGACAO='" & Fumigacao & "'")
        SQL.Append("    ,IMO='" & IMO1 & "'")
        SQL.Append("    ,UNO='" & UNO1 & "'")
        SQL.Append("    ,IMO2='" & IMO2 & "'")
        SQL.Append("    ,UNO2='" & UNO2 & "'")
        SQL.Append("    ,IMO3='" & IMO3 & "'")
        SQL.Append("    ,UNO3='" & UNO3 & "'")
        SQL.Append("    ,IMO4='" & IMO4 & "'")
        SQL.Append("    ,UNO4='" & UNO4 & "'")
        SQL.Append("    ,AUTONUM_EMB=" & AutonumEmbalagem)
        SQL.Append("    ,YARD='" & Local & "'")
        SQL.Append("    ,ARMAZEM='" & Armazem & "'")
        SQL.Append(" WHERE AUTONUM_TI=" & AutonumItem)

        If OracleDAO.Execute(SQL.ToString()) Then
            Return True
        End If

        Return False

    End Function

    Public Shared Function ExcluirTalieItem(ByVal AutonumItem As Long) As Boolean
        Return OracleDAO.Execute("DELETE FROM REDEX.TB_TALIE_ITEM WHERE AUTONUM_TI = " & Val(AutonumItem))
    End Function

    Public Shared Function ExcluirItensPorTalie(ByVal AutonumTalie As Long) As Boolean
        Return OracleDAO.Execute("DELETE FROM REDEX.TB_TALIE_ITEM WHERE AUTONUM_TALIE = " & Val(AutonumTalie))
    End Function

End Class

