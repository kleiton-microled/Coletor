Public Class PatioCsDAO

    Public Shared Function ObterProximoID()
        Return OracleDAO.ExecuteScalar("SELECT REDEX.SEQ_TB_PATIO_CS.NEXTVAL FROM DUAL")
    End Function

    Public Shared Function InserirRegistroPatioCS(
                                                 ByVal AutonumPatioCs As Long,
                                                 ByVal AutonumBookingCarga As Long,
                                                 ByVal QuantidadeEntrada As Long,
                                                 ByVal AutonumEmbalagem As Long,
                                                 ByVal EmbalagemReserva As Long,
                                                 ByVal AutonumProduto As Long,
                                                 ByVal AutonumRegCs As Long,
                                                 ByVal Marca As String,
                                                 ByVal Comprimento As Decimal,
                                                 ByVal Largura As Decimal,
                                                 ByVal Altura As Decimal,
                                                 ByVal Bruto As Decimal,
                                                 ByVal DataInicio As String,
                                                 ByVal AutonumNF As Long,
                                                 ByVal AutonumTalieItem As Long,
                                                 ByVal QuantidadeEstufagem As Integer,
                                                 ByVal Yard As String,
                                                 ByVal Armazem As String,
                                                 ByVal Patio As Long,
                                                 ByVal IMO1 As String,
                                                 ByVal UNO1 As String,
                                                 ByVal IMO2 As String,
                                                 ByVal UNO2 As String,
                                                 ByVal IMO3 As String,
                                                 ByVal UNO3 As String,
                                                 ByVal IMO4 As String,
                                                 ByVal UNO4 As String,
                                                 ByVal CodigoProduto As String) As Boolean

        Dim SQL As New StringBuilder

        SQL.Append("INSERT INTO ")
        SQL.Append("	REDEX.TB_PATIO_CS ")
        SQL.Append("		( ")
        SQL.Append("			AUTONUM_PCS, ")
        SQL.Append("			AUTONUM_BCG, ")
        SQL.Append("			QTDE_ENTRADA, ")
        SQL.Append("			AUTONUM_EMB, ")
        SQL.Append("			AUTONUM_PRO, ")
        SQL.Append("			MARCA, ")
        SQL.Append("			VOLUME_DECLARADO, ")
        SQL.Append("			COMPRIMENTO, ")
        SQL.Append("			LARGURA, ")
        SQL.Append("			ALTURA, ")
        SQL.Append("			BRUTO, ")
        SQL.Append("			DT_PRIM_ENTRADA, ")
        SQL.Append("			FLAG_HISTORICO, ")
        SQL.Append("			AUTONUM_REGCS, ")
        SQL.Append("			AUTONUM_NF, ")
        SQL.Append("			TALIE_DESCARGA, ")
        SQL.Append("			QTDE_ESTUFAGEM, ")
        SQL.Append("			YARD, ")
        SQL.Append("			ARMAZEM, ")
        SQL.Append("			AUTONUM_PATIOS, ")
        SQL.Append("			PATIO, ")
        SQL.Append("			IMO, ")
        SQL.Append("			UNO, ")
        SQL.Append("			IMO2, ")
        SQL.Append("			UNO2, ")
        SQL.Append("			IMO3, ")
        SQL.Append("			UNO3, ")
        SQL.Append("			IMO4, ")
        SQL.Append("			UNO4, ")
        SQL.Append("			CODPRODUTO ")
        SQL.Append("		)VALUES( ")
        SQL.Append("            " & AutonumPatioCs & ", ")
        SQL.Append("            " & AutonumBookingCarga & ",")
        SQL.Append("            " & QuantidadeEntrada & ", ")

        If AutonumEmbalagem <> 0 Then
            SQL.Append("        " & AutonumEmbalagem & ",")
        Else
            SQL.Append("        " & EmbalagemReserva & ", ")
        End If

        SQL.Append("            " & AutonumProduto & ",")
        SQL.Append("            '" & Marca & "'" & ",")
        SQL.Append("            " & Replace(Comprimento * Largura * Altura, ",", ".") & ",")
        SQL.Append("            " & Replace(Comprimento, ",", ".") & ",")
        SQL.Append("            " & Replace(Largura, ",", ".") & ",")
        SQL.Append("            " & Replace(Altura, ",", ".") & ",")
        SQL.Append("            " & Replace(Bruto, ",", ".") & ", ")
        SQL.Append("            TO_DATE('" & DataInicio & "','dd/mm/yyyy hh24:mi')" & ",")
        SQL.Append("            0" & ",")
        SQL.Append("            " & AutonumRegCs & ", ")
        SQL.Append("            " & AutonumNF & ", ")
        SQL.Append("            " & AutonumTalieItem & ",")
        SQL.Append("            " & QuantidadeEstufagem & ",")
        SQL.Append("            '" & Yard & "'" & ",")
        SQL.Append("            '" & Armazem & "'" & ",")
        SQL.Append("            " & Patio & ", ")
        SQL.Append("            " & Patio & ",")
        SQL.Append("            '" & IMO1 & "'" & ",")
        SQL.Append("            '" & UNO1 & "'" & ",")
        SQL.Append("            '" & IMO2 & "'" & ",")
        SQL.Append("            '" & UNO2 & "'" & ",")
        SQL.Append("            '" & IMO3 & "'" & ",")
        SQL.Append("            '" & UNO3 & "'" & ",")
        SQL.Append("            '" & IMO4 & "'" & ",")
        SQL.Append("            '" & UNO4 & "'" & ",")
        SQL.Append("            '" & CodigoProduto & "'")
        SQL.Append("		) ")

        If OracleDAO.Execute(SQL.ToString()) Then
            Return True
        End If

        Return False

    End Function

    Public Shared Function VinculaCargaMarcanteRDX(
                                                 ByVal AutonumPatioCs As Long,
                                                 ByVal AutonumTalie As Long) As Boolean

        Dim SQL As New StringBuilder

        SQL.Append(" UPDATE ")
        SQL.Append(" REDEX.TB_MARCANTES_RDX SET  ")
        SQL.Append(" AUTONUM_PCS=" & AutonumPatioCs)
        SQL.Append(" WHERE ")
        SQL.Append(" AUTONUM_TALIE=" & AutonumTalie)
        SQL.Append(" AND VOLUMES>0 AND NVL(AUTONUM_PCS,0)=0 ")

        If OracleDAO.Execute(SQL.ToString()) Then
            Return True
        End If

        Return False

    End Function


    Public Shared Function AtualizarPatioCsPai(ByVal id As Long) As Boolean
        Return OracleDAO.Execute("UPDATE REDEX.TB_PATIO_CS SET PCS_PAI = " & id & " WHERE AUTONUM_PCS = " & id)
    End Function

End Class
