Imports System.Data.OleDb
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Xml
Imports Coletor.DesovaService
' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Ordens

    Inherits System.Web.UI.Page

    Private _Yard As String
    Private _Camera As String
    Private _DtInicio As String
    Private _DtFim As String
    Private _FlagDesovaManual As Integer
    Private _Autonum_Cntr As Integer
    Private _Autonum_CS As Integer

    Private _Lote As Integer
    Private _Item As Integer

    Private _Qtde As Integer
    Private _QtdeM As Integer
    Private _Embalagem As Integer
    Private _Mercadoria As String
    Private _Volume As String
    Private _Marca As String
    Private _Importador As String
    Private _PesoBruto As String
    Private _Imo As String
    Private _Onu As String
    Private _Genero As Integer
    Private _ehMadeira As Byte
    Private _ehAvaria As Byte
    Private _ehAcrescimo As Byte
    Private _ehIdfa As Byte
    Private _ehHubPort As Byte
    Private _ehDespachante As Byte

    Private _idTimeLine As Long
    Private _Obs_Desova_Col As String
    Private _ehDivEmbalagem As Byte
    Private _ANVISA As String
    Private _FlagAnvisa As String
    Private _Temp_Anvisa As String
    Private _Temp_AnvisaMax As String
    Private _Placa As String
    Private _OC As Long
    Private _AutonumRCS As Long
    Private _Resposta As Boolean

    Public Property ehIdfa() As Byte
        Get
            Return Me._ehIdfa
        End Get
        Set(ByVal value As Byte)
            Me._ehIdfa = value
        End Set
    End Property
    Public Property ehDivEmbalagem() As Byte
        Get
            Return Me._ehDivEmbalagem
        End Get
        Set(ByVal value As Byte)
            Me._ehDivEmbalagem = value
        End Set
    End Property

    Public Property ehDespachante() As Byte
        Get
            Return Me._ehDespachante
        End Get
        Set(ByVal value As Byte)
            Me._ehDespachante = value
        End Set
    End Property


    Public Property ehHubPort() As Byte
        Get
            Return Me._ehHubPort
        End Get
        Set(ByVal value As Byte)
            Me._ehHubPort = value
        End Set
    End Property

    Public Property ehAcrescimo() As Byte
        Get
            Return Me._ehAcrescimo
        End Get
        Set(ByVal value As Byte)
            Me._ehAcrescimo = value
        End Set
    End Property
    Public Property ehAvaria() As Byte
        Get
            Return Me._ehAvaria
        End Get
        Set(ByVal value As Byte)
            Me._ehAvaria = value
        End Set
    End Property

    Public Property Resposta() As Boolean
        Get
            Return Me._Resposta
        End Get
        Set(ByVal value As Boolean)
            Me._Resposta = value
        End Set
    End Property

    Public Property ehMadeira() As Byte
        Get
            Return Me._ehMadeira
        End Get
        Set(ByVal value As Byte)
            Me._ehMadeira = value
        End Set
    End Property

    Public Property Genero() As Integer
        Get
            Return Me._Genero
        End Get
        Set(ByVal value As Integer)
            Me._Genero = value
        End Set
    End Property
    Public Property IdtimeLine() As Long
        Get
            Return Me._idTimeLine
        End Get
        Set(ByVal value As Long)
            Me._idTimeLine = value
        End Set
    End Property
    Public Property OC() As Long
        Get
            Return Me._OC
        End Get
        Set(ByVal value As Long)
            Me._OC = value
        End Set
    End Property
    Public Property AutonumRCS() As Long
        Get
            Return Me._AutonumRCS
        End Get
        Set(ByVal value As Long)
            Me._AutonumRCS = value
        End Set
    End Property
    Public Property Item() As Integer
        Get
            Return Me._Item
        End Get
        Set(ByVal value As Integer)
            Me._Item = value
        End Set
    End Property

    Public Property Lote() As Integer
        Get
            Return Me._Lote
        End Get
        Set(ByVal value As Integer)
            Me._Lote = value
        End Set
    End Property
    Public Property Onu() As String
        Get
            Return Me._Onu
        End Get
        Set(ByVal value As String)
            Me._Onu = value
        End Set
    End Property

    Public Property Placa() As String
        Get
            Return Me._Placa
        End Get
        Set(ByVal value As String)
            Me._Placa = value
        End Set
    End Property

    Public Property Obs_Desova_Col() As String
        Get
            Return Me._Obs_Desova_Col
        End Get
        Set(ByVal value As String)
            Me._Obs_Desova_Col = value
        End Set
    End Property


    Public Property ANVISA() As String
        Get
            Return Me._ANVISA
        End Get
        Set(ByVal value As String)
            Me._ANVISA = value
        End Set
    End Property


    Public Property FlagAnvisa() As String
        Get
            Return Me._FlagAnvisa
        End Get
        Set(ByVal value As String)
            Me._FlagAnvisa = value
        End Set
    End Property

    Public Property Imo() As String
        Get
            Return Me._Imo
        End Get
        Set(ByVal value As String)
            Me._Imo = value
        End Set
    End Property

    Public Property PesoBruto() As String
        Get
            Return Me._PesoBruto
        End Get
        Set(ByVal value As String)
            Me._PesoBruto = value
        End Set
    End Property

    Public Property Marca() As String
        Get
            Return Me._Marca
        End Get
        Set(ByVal value As String)
            Me._Marca = value
        End Set
    End Property

    Public Property Importador() As String
        Get
            Return Me._Importador
        End Get
        Set(ByVal value As String)
            Me._Importador = value
        End Set
    End Property

    Public Property Volume() As String
        Get
            Return Me._Volume
        End Get
        Set(ByVal value As String)
            Me._Volume = value
        End Set
    End Property
    Public Property Mercadoria() As String
        Get
            Return Me._Mercadoria
        End Get
        Set(ByVal value As String)
            Me._Mercadoria = value
        End Set
    End Property

    Public Property Embalagem() As Integer
        Get
            Return Me._Embalagem
        End Get
        Set(ByVal value As Integer)
            Me._Embalagem = value
        End Set
    End Property

    Public Property Qtde() As Integer
        Get
            Return Me._Qtde
        End Get
        Set(ByVal value As Integer)
            Me._Qtde = value
        End Set
    End Property
    Public Property QtdeM() As Integer
        Get
            Return Me._QtdeM
        End Get
        Set(ByVal value As Integer)
            Me._QtdeM = value
        End Set
    End Property
    Public Property Yard() As String
        Get
            Return Me._Yard
        End Get
        Set(ByVal value As String)
            Me._Yard = value
        End Set
    End Property
    Public Property Autonum_Cntr() As Integer
        Get
            Return Me._Autonum_Cntr
        End Get
        Set(ByVal value As Integer)
            Me._Autonum_Cntr = value
        End Set
    End Property

    Public Property Autonum_CS() As Integer
        Get
            Return Me._Autonum_CS
        End Get
        Set(ByVal value As Integer)
            Me._Autonum_CS = value
        End Set
    End Property

    Public Property FlagDesovaManual() As Integer
        Get
            Return Me._FlagDesovaManual
        End Get
        Set(ByVal value As Integer)
            Me._FlagDesovaManual = value
        End Set
    End Property
    Public Property Camera() As String
        Get
            Return Me._Camera
        End Get
        Set(ByVal value As String)
            Me._Camera = value
        End Set
    End Property

    Public Property DtInicio() As String
        Get
            Return Me._DtInicio
        End Get
        Set(ByVal value As String)
            Me._DtInicio = value
        End Set
    End Property

    Public Property DtFim() As String
        Get
            Return Me._DtFim
        End Get
        Set(ByVal value As String)
            Me._DtFim = value
        End Set
    End Property


    Public Property Temp_Anvisa() As String
        Get
            Return Me._Temp_Anvisa
        End Get
        Set(ByVal value As String)
            Me._Temp_Anvisa = value
        End Set
    End Property


    Public Property Temp_AnvisaMax() As String
        Get
            Return Me._Temp_AnvisaMax
        End Get
        Set(ByVal value As String)
            Me._Temp_AnvisaMax = value
        End Set
    End Property

    Public Function RetornarDadosTela(ByVal Lote As Integer, ByVal Cntr As Integer) As Ordens

        Dim Rst As New ADODB.Recordset
        Rst.Open("SELECT NVL(OBS_DESOVA_COL,' ') OBS_DESOVA_COL FROM SGIPA.TB_CARGA_SOLTA WHERE BL = " & Lote & " AND CNTR = " & Cntr, BD.Conexao, 3, 3)

        If Not Rst.EOF Then
            Dim OrdensOBJ As New Ordens
            Dim RsAv As New ADODB.Recordset
            Dim Sql As String = String.Empty
            Sql = "SELECT AUTONUM FROM SGIPA.TB_AVARIAS_CS WHERE AUTONUMCS IN (SELECT AUTONUM FROM SGIPA.TB_CARGA_SOLTA"
            Sql = Sql & " WHERE BL=" & Lote & " AND CNTR=" & Cntr
            Sql = Sql & " )"
            RsAv.Open(Sql, BD.Conexao, 1, 1)
            If RsAv.EOF Then
                OrdensOBJ.Obs_Desova_Col = " N/C " & Rst.Fields("OBS_DESOVA_COL").Value.ToString.Replace("N/C", " ")
                OrdensOBJ.ehAvaria = 0
                Sql = "UPDATE SGIPA.TB_CARGA_SOLTA SET FLAG_AVARIADO=0 WHERE BL=" & Lote & " AND CNTR=" & Cntr
                BD.Conexao.Execute(Sql)
            Else
                OrdensOBJ.Obs_Desova_Col = Rst.Fields("OBS_DESOVA_COL").Value.ToString.Replace("N/C", " ")
            End If

            Return OrdensOBJ

        End If

        Return Nothing

    End Function

    Public Shared Function ExisteCS(ByVal Lote As Long, Autonum_Cntr As Long, Item As Integer) As Long
        Dim Sql As String
        Sql = "SELECT nvl(AUTONUM,0)  FROM SGIPA.TB_CARGA_SOLTA WHERE BL=" & Lote & " AND CNTR=" & Autonum_Cntr & " AND ITEM=" & Item
        Return OracleDAO.ExecuteScalar(Sql)
    End Function

    Public Shared Function ProximoSEQ_AVARIAS_CS_COL() As Long

        Return OracleDAO.ExecuteScalar("SELECT SGIPA.SEQ_AVARIAS_CS_COL.NEXTVAL AS QUAL FROM DUAL")

    End Function

    Public Shared Function QualAutonumCS(AutonumCntr As Long, AutonumBl As Long, Item As Integer) As Long

        Return OracleDAO.ExecuteScalar("SELECT NVL(AUTONUM,0) AS QUAL FROM SGIPA.TB_CARGA_SOLTA WHERE BL=" & AutonumBl & " AND CNTR=" & AutonumCntr & " AND ITEM=" & Item)

    End Function

    Public Shared Function ProximaSEQ_CARGA_SOLTA() As Long

        Return OracleDAO.ExecuteScalar("Select SGIPA.SEQ_CARGA_SOLTA.NEXTVAL As QUAL FROM DUAL")

    End Function


    Public Shared Function RetornaCodigoDaEmbalagem(DescrEmbalagem As String) As Long

        Return OracleDAO.ExecuteScalar("Select CODE As QUAL FROM SGIPA.DTE_TB_EMBALAGENS WHERE DESCR='" & DescrEmbalagem & "'")

    End Function

    Public Shared Function ConsultarConteineres(AutonumPatio As Integer) As DataTable

        Dim Sql As String

        Sql = " Select AUTONUM_CNTR As autonum, ID_CONTEINER As DISPLAY "
        Sql = Sql & " FROM SGIPA.VW_DESOVA_COL_CNTR "
        Sql = Sql & " WHERE "
        Sql = Sql & " PATIO=" & AutonumPatio
        Sql = Sql & " And DT_INICIO Is Not NULL"
        Sql = Sql & " And DT_FIM Is NULL"
        Sql = Sql & " ORDER BY ID_CONTEINER "

        Return OracleDAO.List(Sql.ToString())

    End Function

    Public Shared Function ConsultarPlacas(AutonumCNTR As Long, Flag_DDC As Byte) As DataTable

        Dim Sql As String

        If Flag_DDC = 1 Then
            Sql = " Select OC As autonum,PLACA_C || '/ OC:'|| to_char(oc) as DISPLAY "
            Sql = Sql & " FROM SGIPA.VW_DDC_COL_CNTR "
            Sql = Sql & " WHERE "
            Sql = Sql & " AUTONUM_CNTR=" & AutonumCNTR
        Else
            Sql = " Select OC As autonum,PLACA_C as DISPLAY "
            Sql = Sql & " FROM SGIPA.VW_DDC_COL_CNTR "
            Sql = Sql & " WHERE "
            Sql = Sql & " AUTONUM_CNTR=" & AutonumCNTR
        End If
        Return OracleDAO.List(Sql.ToString())

    End Function

    Public Function IniciaGravacao(ByVal wID_Conteiner As String, ByVal wIdCamera As Integer, ByVal wPosition As Integer) As String

        Dim St = New Coletor.DesovaService.RequestStart

        Try

            St.Sort = "ASC"
            St.idCamera = wIdCamera
            St.Position = wPosition
            St.Container = wID_Conteiner
            St.idOperationType = 2


            Dim client As DesovaServiceClient = New DesovaServiceClient()
            Dim Retorno
            Retorno = Nothing
            Retorno = client.StartRecording(St)

            client.Close()
            Return "IdTimeLine=" & Retorno.IdTimeLine.ToString
            client.Close()


        Catch ex As Exception

            'Throw New Exception("Erro ao tentar iniciar a filmagem :    " & ex.Message()) : 
            Return "Erro=Problema na tentativa de iniciar filmagem"

        End Try


        'Return "IdTimeLine=0"


    End Function

    Public Function PararGravacao(ByVal wIdTimeLine As Long, ByVal wIdCamera As Integer, QualData As Date) As String


        Try

            Dim client As DesovaServiceClient = New DesovaServiceClient




            Dim St
            St = New DesovaService.RequestStop
            St.sort = "ASC"
            St.Enddate = QualData
            St.idCamera = wIdCamera
            St.idTimeLine = wIdTimeLine



            Dim Retorno
            Retorno = Nothing
            Retorno = client.StopRecording(St)

            If Retorno.success = True Then
                Return "Ok"
            Else
                Return "Erro=" & Retorno.Message.ToString
            End If
            client.Close()

        Catch ex As Exception
            Return "Erro=Problema na tentativa de Parar a filmagem"
            'Return "Ok"
        End Try

        'Return "Ok"

    End Function


    Public Shared Function ConsultarConteineresIni(AutonumPatio As Integer, Flag_DDC As Integer) As DataTable

        Dim Sql As String

        Sql = " select DISTINCT AUTONUM_CNTR as autonum, ID_CONTEINER AS DISPLAY "
        If Flag_DDC = 0 Then
            Sql = Sql & " FROM SGIPA.VW_DESOVA_COL_CNTR "
        Else
            Sql = Sql & " FROM SGIPA.VW_DDC_COL_CNTR "
        End If
        Sql = Sql & " WHERE "
        Sql = Sql & " PATIO=" & AutonumPatio
        Sql = Sql & " ORDER BY ID_CONTEINER "


        Return OracleDAO.List(Sql.ToString())

    End Function

    Public Shared Function CarregarCadEmbalagens(Flag_DDC As Integer) As DataTable

        Dim Sql As String

        Sql = " select code as autonum, descr AS DISPLAY "
        If Flag_DDC = 0 Then
            Sql = Sql & " FROM SGIPA.DTE_TB_EMBALAGENS where flag_coletor=1"
        Else
            Sql = Sql & " FROM SGIPA.DTE_TB_EMBALAGENS "
        End If
        Sql = Sql & " ORDER BY DESCR "


        Return OracleDAO.List(Sql.ToString())

    End Function

    Public Shared Function CarregaMarcanteAV(QualLote As Long, QualIDConteiner As String) As DataTable

        Dim Sql As String
        Sql = "SELECT MARCANTE AS AUTONUM, MARCANTE AS DISPLAY FROM SGIPA.TB_TEMP_DESOVA_MARCANTE "
        Sql = Sql & " WHERE LOTE=" & QualLote
        Sql = Sql & " AND ID_CONTEINER='" & QualIDConteiner & "'"
        Sql = Sql & " ORDER BY MARCANTE "


        Return OracleDAO.List(Sql.ToString())



    End Function

    Public Shared Function CarregarLocalA() As DataTable


        Dim Sql As String

        Sql = " select code as autonum, descr AS DISPLAY "
        Sql = Sql & " FROM SGIPA.DTE_TB_avarias where ident='L' and flag_coletor=1"
        Sql = Sql & " ORDER BY DESCR "


        Return OracleDAO.List(Sql.ToString())

    End Function
    Public Shared Function CarregarTipoA() As DataTable


        Dim Sql As String

        Sql = " select code as autonum, descr AS DISPLAY "
        Sql = Sql & " FROM SGIPA.DTE_TB_avarias where ident='T' and flag_coletor=1"
        Sql = Sql & " ORDER BY DESCR "


        Return OracleDAO.List(Sql.ToString())

    End Function


    Public Shared Function CarregarComplementoA() As DataTable


        Dim Sql As String

        Sql = " select code as autonum, descr AS DISPLAY "
        Sql = Sql & " FROM SGIPA.DTE_TB_avarias where ident='C' and flag_coletor=1"
        Sql = Sql & " ORDER BY DESCR "

        Return OracleDAO.List(Sql.ToString())

    End Function

    Public Shared Function CarregarProcidenciaA() As DataTable

        Dim Sql As String

        Sql = " select code as autonum, descr AS DISPLAY "
        Sql = Sql & " FROM SGIPA.DTE_TB_providencias "
        Sql = Sql & " ORDER BY DESCR "


        Return OracleDAO.List(Sql.ToString())

    End Function
    Public Shared Function CarregarCadGenero() As DataTable

        Dim Sql As String

        Sql = " select autonum, descr AS DISPLAY "
        Sql = Sql & " FROM SGIPA.TB_CAD_GRUPO_PRODUTOS "
        Sql = Sql & " ORDER BY DESCR "


        Return OracleDAO.List(Sql.ToString())

    End Function

    Public Shared Function InserirDesova(ByVal OrdensOBJ As Ordens) As Boolean

        Dim Sql As String
        Dim SqlF As String
        Dim Peso As String
        Dim Volume As String
        Dim Pos As Byte

        Pos = InStr(OrdensOBJ.PesoBruto.ToString(), ".")
        Peso = OrdensOBJ.PesoBruto.ToString()
        If Pos > 1 Then
            Peso = OrdensOBJ.PesoBruto.ToString().Substring(0, Pos - 1)
        End If
        Pos = InStr(OrdensOBJ.Volume.ToString(), ".")
        Volume = OrdensOBJ.Volume.ToString()
        If Pos > 1 Then
            Volume = OrdensOBJ.Volume.ToString().Substring(0, Pos - 1)
        End If

        Pos = InStr(OrdensOBJ.PesoBruto.ToString(), ",")
        Peso = OrdensOBJ.PesoBruto.ToString()
        If Pos > 1 Then
            Peso = OrdensOBJ.PesoBruto.ToString().Substring(0, Pos - 1)
        End If
        Pos = InStr(OrdensOBJ.Volume.ToString(), ",")
        Volume = OrdensOBJ.Volume.ToString()
        If Pos > 1 Then
            Volume = OrdensOBJ.Volume.ToString().Substring(0, Pos - 1)
        End If

        If BD.BancoEmUso = "ORACLE" Then

            Try

                Dim Id As Long
                Id = Ordens.ExisteCS(OrdensOBJ.Lote, OrdensOBJ.Autonum_Cntr, OrdensOBJ.Item)

                If Id = 0 Then

                    Id = Ordens.ProximaSEQ_CARGA_SOLTA
                    OrdensOBJ.Autonum_CS = Id

                    Sql = "INSERT INTO SGIPA.TB_CARGA_SOLTA (AUTONUM,BL,CNTR,VIAGEM,"
                    Sql = Sql & " ITEM,"
                    Sql = Sql & " QUANTIDADE,"
                    Sql = Sql & " QUANTIDADE_REAL, "
                    Sql = Sql & " EMBALAGEM,"
                    Sql = Sql & " Mercadoria,"
                    Sql = Sql & " Marca,"
                    Sql = Sql & " Genero,"
                    Sql = Sql & " PESO_BRUTO,"
                    Sql = Sql & " Volume, "
                    Sql = Sql & " FLAG_TERMINAL,FLAG_HISTORICO,FLAG_CHEGADA_TOTAL,QUANTIDADE_SAIDA,DT,"
                    Sql = Sql & " IMO,UNDG,"
                    Sql = Sql & " FLAG_AVARIADO,"
                    Sql = Sql & " PATIO,AMR, FLAG_MADEIRA, IDFA, FLAG_ACRESCIMO, FLAG_AG_DESP_DESOVA,FLAG_DIV_EMB_DESOVA,TEMPERATURA_ANVISA,TEMPERATURA_ANVISA_MAX) SELECT " & Id & ","

                    Sql = Sql & " LOTE, AUTONUM_CNTR, VIAGEM, "
                    Sql = Sql & " {0}," 'ITEM
                    Sql = Sql & " {1}," 'QUANTIDADE
                    Sql = Sql & " {2}," 'QUANTIDADE_REAL
                    Sql = Sql & " {3}," 'EMBALAGEM
                    Sql = Sql & " '{4}'," 'MERCADORIA
                    Sql = Sql & " '{5}'," 'MARCA
                    Sql = Sql & " {6}," 'GENERO
                    Sql = Sql & " {7}," 'PESO_BRUTO
                    Sql = Sql & " {8}," 'VOLUME
                    Sql = Sql & " 1,0,1,0,DT, "
                    Sql = Sql & " '{9}','{10}'," 'IMO
                    Sql = Sql & " {11}," 'FLAG_AVARIADO
                    Sql = Sql & " PATIO,AMR,{12},{13},{14},{15},{16},'{17}','{18}' FROM SGIPA.VW_DESOVA_COL_ITENS WHERE "
                    Sql = Sql & " LOTE={19}"
                    Sql = Sql & " AND AUTONUM_CNTR={20}"
                    Sql = Sql & " AND ITEM={21}"

                    SqlF = String.Format(Sql, OrdensOBJ.Item, OrdensOBJ.QtdeM, OrdensOBJ.Qtde, OrdensOBJ.Embalagem, OrdensOBJ.Mercadoria, OrdensOBJ.Marca, OrdensOBJ.Genero, Peso, Volume, OrdensOBJ.Imo, OrdensOBJ.Onu, OrdensOBJ.ehAvaria, OrdensOBJ.ehMadeira, OrdensOBJ.ehIdfa, OrdensOBJ.ehAcrescimo, OrdensOBJ.ehDespachante, OrdensOBJ.ehDivEmbalagem, OrdensOBJ.Temp_Anvisa, OrdensOBJ.Temp_AnvisaMax, OrdensOBJ.Lote, OrdensOBJ.Autonum_Cntr, OrdensOBJ.Item)

                Else

                    SqlF = "UPDATE SGIPA.TB_CARGA_SOLTA SET QUANTIDADE_REAL=QUANTIDADE_REAL+" & OrdensOBJ.Qtde
                    SqlF = SqlF & ",EMBALAGEM=" & OrdensOBJ.Embalagem
                    SqlF = SqlF & ",MERCADORIA='" & OrdensOBJ.Mercadoria & "'"
                    SqlF = SqlF & ",MARCA='" & OrdensOBJ.Marca & "'"
                    SqlF = SqlF & ",IDFA=" & OrdensOBJ.ehIdfa
                    SqlF = SqlF & ",PESO_BRUTO=" & Peso
                    SqlF = SqlF & ",FLAG_ACRESCIMO=" & OrdensOBJ.ehAcrescimo

                    SqlF = SqlF & ",FLAG_AG_DESP_DESOVA=" & OrdensOBJ.ehDespachante
                    SqlF = SqlF & ",FLAG_DIV_EMB_DESOVA=" & OrdensOBJ.ehDivEmbalagem
                    SqlF = SqlF & " ,TEMPERATURA_ANVISA='" & OrdensOBJ.Temp_Anvisa & "'"
                    SqlF = SqlF & " ,TEMPERATURA_ANVISA_MAX='" & OrdensOBJ.Temp_AnvisaMax & "'"
                    SqlF = SqlF & " WHERE AUTONUM=" & Id

                    OrdensOBJ.Autonum_CS = Id

                End If

                OracleDAO.Execute(SqlF)


                Return True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

        End If

        Return False


    End Function


    Public Shared Function InserirDesovaDDC(ByVal OrdensOBJ As Ordens, AutonumUSer As Long, OC As Long, AutonumGate As Long, Placa As String) As Boolean

        Dim Sql As String

        Dim Peso As String
        Dim Volume As String
        Dim Pos As Byte

        Pos = InStr(OrdensOBJ.PesoBruto.ToString(), ".")
        Peso = OrdensOBJ.PesoBruto.ToString()
        If Pos > 1 Then
            Peso = OrdensOBJ.PesoBruto.ToString().Substring(0, Pos - 1)
        End If
        Pos = InStr(OrdensOBJ.Volume.ToString(), ".")
        Volume = OrdensOBJ.Volume.ToString()
        If Pos > 1 Then
            Volume = OrdensOBJ.Volume.ToString().Substring(0, Pos - 1)
        End If

        Pos = InStr(OrdensOBJ.PesoBruto.ToString(), ",")
        Peso = OrdensOBJ.PesoBruto.ToString()
        If Pos > 1 Then
            Peso = OrdensOBJ.PesoBruto.ToString().Substring(0, Pos - 1)
        End If
        Pos = InStr(OrdensOBJ.Volume.ToString(), ",")
        Volume = OrdensOBJ.Volume.ToString()
        If Pos > 1 Then
            Volume = OrdensOBJ.Volume.ToString().Substring(0, Pos - 1)
        End If

        Dim QR As Integer
        Dim QM As Integer
        Dim QS As Integer
        Dim SM As Integer


        If BD.BancoEmUso = "ORACLE" Then

            Try


                If OrdensOBJ.AutonumRCS > 0 Then

                    Sql = "SELECT NVL(QUANTIDADE,0) AS QTO FROM SGIPA.TB_REGISTRO_SAIDA_CS WHERE AUTONUM=" & OrdensOBJ.AutonumRCS
                    QR = OracleDAO.ExecuteScalar(Sql)

                    Sql = "Select NVL(QUANTIDADE_REAL,0) AS QTO FROM SGIPA.TB_CARGA_SOLTA WHERE AUTONUM=" & OrdensOBJ.Autonum_CS
                    QM = OracleDAO.ExecuteScalar(Sql)

                    Sql = "Select nvl(QUANTIDADE_saida, 0) AS QTO FROM SGIPA.TB_carga_solta WHERE autonum=" & OrdensOBJ.Autonum_CS
                    QS = OracleDAO.ExecuteScalar(Sql)

                    Sql = "Select (NVL(QUANTIDADE_REAL,0) - NVL(QUANTIDADE_SAIDA,0)) AS QTO FROM SGIPA.TB_CARGA_SOLTA WHERE AUTONUM=" & OrdensOBJ.Autonum_CS
                    SM = OracleDAO.ExecuteScalar(Sql)

                    If OrdensOBJ.Qtde < QR Then
                        If OrdensOBJ.Resposta Then
                            Sql = "update sgipa.tb_registro_saida_cs Set quantidade = " & OrdensOBJ.Qtde
                            Sql = Sql & " where autonum = " & OrdensOBJ.AutonumRCS
                            OracleDAO.Execute(Sql)
                            Atualiza_Agendamento(OrdensOBJ.Lote, OrdensOBJ.Autonum_CS, Placa, OrdensOBJ.Qtde)
                        Else
                            OrdensOBJ.Qtde = QR
                        End If

                    End If

                    If OrdensOBJ.Qtde > QR And OrdensOBJ.Qtde <= SM Then
                        OrdensOBJ.Qtde = QR
                    End If
                    If OrdensOBJ.Qtde > QR Then
                        OrdensOBJ.Qtde = QR
                    End If


                    'Sql = "update sgipa.tb_registro_saida_cs Set quantidade = " & OrdensOBJ.Qtde
                    'Sql = Sql & " where autonum = " & OrdensOBJ.AutonumRCS
                    'OracleDAO.Execute(Sql)
                    'Atualiza_Agendamento(OrdensOBJ.Lote, OrdensOBJ.Autonum_CS, Placa, OrdensOBJ.Qtde)

                    'If Val(OrdensOBJ.Qtde) > QR And Val(OrdensOBJ.Qtde) <= SM Then
                    '    Sql = "update sgipa.tb_registro_saida_cs Set quantidade = " & OrdensOBJ.Qtde
                    '    Sql = Sql & " where autonum = " & OrdensOBJ.AutonumRCS
                    '    OracleDAO.Execute(Sql)
                    '    Atualiza_Agendamento(OrdensOBJ.Lote, OrdensOBJ.Autonum_CS, Placa, OrdensOBJ.Qtde)
                    'End If

                    'If Val(OrdensOBJ.Qtde) > QR Then
                    '    Sql = "update sgipa.tb_registro_saida_cs Set quantidade = " & OrdensOBJ.Qtde
                    '    Sql = Sql & " where autonum = " & OrdensOBJ.AutonumRCS
                    '    OracleDAO.Execute(Sql)
                    '    Atualiza_Agendamento(OrdensOBJ.Lote, OrdensOBJ.Autonum_CS, Placa, OrdensOBJ.Qtde)

                    '    S = (Val(OrdensOBJ.Qtde) - QR)

                    '    Sql = "update sgipa.tb_carga_solta Set quantidade=QUANTIDADE+" & S & ",quantidade_real=quantidade_real+" & S & " where autonum=" & OrdensOBJ.Autonum_CS
                    '    OracleDAO.Execute(Sql)
                    'End If


                    Sql = "update sgipa.tb_carga_solta Set"
                    Sql = Sql & " embalagem=" & OrdensOBJ.Embalagem
                    Sql = Sql & ",mercadoria='" & OrdensOBJ.Mercadoria & "'"
                    Sql = Sql & ",marca='" & OrdensOBJ.Marca & "'"
                    Sql = Sql & ",dt_ultima_atualizacao=sysdate"
                    Sql = Sql & ",usuario_ddc=" & AutonumUSer
                    Sql = Sql & " where autonum = " & OrdensOBJ.Autonum_CS
                    OracleDAO.Execute(Sql)

                Else

                    'Dim Id As Long
                    'Id = Ordens.ExisteCS(OrdensOBJ.Lote, OrdensOBJ.Autonum_Cntr, OrdensOBJ.Item)

                    'Dim Rsx As New DataTable
                    'Sql = "select NVL(ARMAZEM_IPA,0) AS ARMAZEM_IPA, NVL(TO_CHAR(DT_CHEGADA_VEI,'DD/MM/YYYY HH24:MI:SS'),'') AS DT_CHEGADA_VEI, NVL(SEQ_GR,0) AS SEQ_GR, NVL(TO_CHAR(DT_LIBERACAO,'DD/MM/YYYY HH24:MI:SS'),'') AS DT_LIBERACAO from sgipa.tb_carga_solta where bl=" & OrdensOBJ.Lote & " and item=1"
                    'Rsx = OracleDAO.List(Sql)

                    'If Id = 0 Then

                    '    Id = Ordens.ProximaSEQ_CARGA_SOLTA
                    '    OrdensOBJ.Autonum_CS = Id

                    '    Sql = "select nvl(max(item),0) as qual from sgipa.tb_carga_solta where bl=" & OrdensOBJ.Lote

                    '    Dim Nitem As Integer

                    '    Nitem = OracleDAO.ExecuteScalar(Sql)
                    '    Nitem = Nitem + 1

                    '    Sql = "insert into sgipa.tb_carga_solta (AUTONUM, BL, CNTR ,VIAGEM ,ITEM ,FLAG_TERMINAL, QUANTIDADE, QUANTIDADE_REAL ,"
                    '    Sql = Sql & " EMBALAGEM ,MERCADORIA, MARCA, PESO_BRUTO,PATIO,FLAG_CHEGADA_TOTAL ,"
                    '    Sql = Sql & " DT,ARMAZEM_IPA,DT_CHEGADA_VEI,SEQ_GR,DT_LIBERACAO,DT_ULTIMA_ATUALIZACAO,USUARIO_DDC "
                    '    Sql = Sql & " )  "
                    '    Sql = Sql & " SELECT " & Id & ","
                    '    Sql = Sql & " LOTE, AUTONUM_CNTR, VIAGEM, "
                    '    Sql = Sql & " {0}," 'ITEM
                    '    Sql = Sql & " 1," 'FLAG_TERMINAL
                    '    Sql = Sql & " {1}," 'QUANTIDADE
                    '    Sql = Sql & " {2}," 'QUANTIDADE_REAL
                    '    Sql = Sql & " {3}," 'EMBALAGEM
                    '    Sql = Sql & " '{4}'," 'MERCADORIA
                    '    Sql = Sql & " '{5}'," 'MARCA
                    '    Sql = Sql & " {6}," 'PESO_BRUTO
                    '    Sql = Sql & " PATIO,"
                    '    Sql = Sql & " 1," 'FLAG_CHEGADA_TOTAL
                    '    Sql = Sql & "DT, "
                    '    If Rsx.Rows.Count > 0 Then
                    '        If Rsx.Rows(0)("ARMAZEM_IPA") <> 0 Then
                    '            Sql = Sql & Rsx.Rows(0)("ARMAZEM_IPA") & ","
                    '        Else
                    '            Sql = Sql & "NULL,"
                    '        End If
                    '        If Rsx.Rows(0)("DT_CHEGADA_VEI") <> "" Then
                    '            Sql = Sql & "TO_DATE('" & Rsx.Rows(0)("DT_CHEGADA_VEI") & "','DD/MM/YYYY HH24:MI:SS') ,"
                    '        Else
                    '            Sql = Sql & "NULL,"
                    '        End If
                    '        If Rsx.Rows(0)("SEQ_GR") <> 0 Then
                    '            Sql = Sql & Rsx.Rows(0)("SEQ_GR") & ","
                    '        Else
                    '            Sql = Sql & "NULL,"
                    '        End If
                    '        If Rsx.Rows(0)("DT_LIBERACAO") <> "" Then
                    '            Sql = Sql & "TO_DATE('" & Rsx.Rows(0)("DT_LIBERACAO") & "','DD/MM/YYYY HH24:MI:SS') ,"
                    '        Else
                    '            Sql = Sql & "NULL,"
                    '        End If

                    '    Else
                    '        Sql = Sql & "NULL,NULL,NULL,NULL,"
                    '    End If

                    '    Sql = Sql & "SYSDATE, " 'DT_ULTIMA_ATUALIZACAO
                    '    Sql = Sql & AutonumUSer

                    '    Sql = Sql & " From SGIPA.VW_DDC_COL_ITENS Where "
                    '    Sql = Sql & " LOTE={7}"
                    '    Sql = Sql & " And AUTONUM_CNTR={8}"
                    '    Sql = Sql & " And ITEM={9}"

                    '    SqlF = String.Format(Sql, Nitem, OrdensOBJ.QtdeM, OrdensOBJ.Qtde, OrdensOBJ.Embalagem, OrdensOBJ.Mercadoria, OrdensOBJ.Marca, Peso, OrdensOBJ.Lote, OrdensOBJ.Autonum_Cntr, OrdensOBJ.Item)

                    '    OracleDAO.Execute(SqlF)


                    '    Sql = "insert into sgipa.tb_registro_saida_cs (autonum,ordem_carreg,cs,quantidade"
                    '    Sql = Sql & ") values ("
                    '    Sql = Sql & "sgipa.SEQ_REGISTRO_SAIDA_CS.NEXTVAL"
                    '    Sql = Sql & "," & OC
                    '    Sql = Sql & "," & Id
                    '    Sql = Sql & "," & OrdensOBJ.Qtde
                    '    Sql = Sql & ")"
                    '    OracleDAO.Execute(SqlF)


                    '    Dim IdAmr As Long = 0


                    '    Sql = "select nvl(autonum,0) from operador.tb_amr_gate where gate=" & AutonumGate & " and cs_ipa=" & Id
                    '    IdAmr = OracleDAO.ExecuteScalar(Sql)

                    '    If IdAmr = 0 Then
                    '        Sql = "insert into operador.tb_amr_gate (autonum,gate,cs_ipa,id_oc,data"
                    '        Sql = Sql & ") values ("
                    '        Sql = Sql & "operador.seq_tb_amr_gate.nextval"
                    '        Sql = Sql & "," & AutonumGate
                    '        Sql = Sql & "," & Id
                    '        Sql = Sql & "," & OC
                    '        Sql = Sql & ",SYSDATE"
                    '        Sql = Sql & ")"
                    '        BD.Conexao.Execute(Sql)
                    '    End If

                    '    Rsx.Dispose()


                End If

                Sql = "UPDATE SGIPA.TB_CNTR_BL SET inicio_ddc=sysdate, FLAG_DDC=2 WHERE flag_ddc<>2 and AUTONUM=" & OrdensOBJ.Autonum_Cntr
                OracleDAO.Execute(Sql)

                Return True

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

        End If

        Return False


    End Function

    Public Shared Function ConsultarLotesConteiner(ByVal Autonum_Cntr As Integer, Flag_DDC As Integer) As DataTable


        Dim Sql As String


        Sql = " Select LOTE As autonum, '(' || FLAG_DESOVADO || '' || LOTE || ')' || ' ' || NUMERO_BL AS DISPLAY "
        If Flag_DDC = 0 Then
            Sql = Sql & " FROM SGIPA.VW_DESOVA_COL_LOTES "
        Else
            Sql = Sql & " FROM SGIPA.VW_DDC_COL_LOTES "
        End If

        Sql = Sql & " WHERE "
        Sql = Sql & " AUTONUM_CNTR=" & Autonum_Cntr
        Sql = Sql & " ORDER BY LOTE "

        Return OracleDAO.List(Sql)

    End Function

    Public Shared Function ConsultarLotesRegConteiner(ByVal Autonum_Cntr As Integer, Flag_DDC As Integer, OC As Long) As DataTable


        Dim Sql As String

        Sql = " Select LOTE As autonum, LOTE ||  ' ' || NUMERO_BL AS DISPLAY "
        Sql = Sql & " FROM SGIPA.VW_DDC_COL_LOTES "
        Sql = Sql & " WHERE "
        Sql = Sql & " AUTONUM_CNTR=" & Autonum_Cntr
        Sql = Sql & " AND OC=" & OC
        Sql = Sql & " ORDER BY LOTE "

        Return OracleDAO.List(Sql)

    End Function

    Public Shared Function ConsultarItensManifestados(ByVal Lote As Integer, ByVal Autonum_Cntr As Integer) As DataTable

        Dim Sql As String

        Sql = " select item as autonum, item AS DISPLAY "
        Sql = Sql & " FROM SGIPA.VW_DESOVA_COL_ITENS "
        Sql = Sql & " WHERE "
        Sql = Sql & " LOTE=" & Lote
        Sql = Sql & " AND AUTONUM_CNTR=" & Autonum_Cntr
        Sql = Sql & " ORDER BY ITEM "

        Return OracleDAO.List(Sql)

    End Function

    Public Function ExisteLotesPendentes(QualCntr As Integer, Flag_DDC As Integer) As Boolean


        Dim Sql As String = ""

        Sql = " SELECT NVL(LOTE,0) "
        If Flag_DDC = 0 Then
            Sql = Sql & " FROM SGIPA.VW_DESOVA_COL_ITENS WHERE "
        Else
            Sql = Sql & " FROM SGIPA.VW_DDC_COL_ITENS WHERE "
        End If
        Sql = Sql & "AUTONUM_CNTR=" & QualCntr & " And LOTE Not IN ( "
        If Flag_DDC = 0 Then
            Sql = Sql & "SELECT LOTE FROM SGIPA.VW_DESOVA_COL_ITENS_DESOVADOS WHERE AUTONUM_CNTR=" & QualCntr & ") "
        Else
            Sql = Sql & "SELECT LOTE FROM SGIPA.VW_DDC_COL_ITENS_DESOVADOS WHERE AUTONUM_CNTR=" & QualCntr & ") "
        End If


        If OracleDAO.ExecuteScalar(Sql) > 0 Then
            Return True
        End If

        Return False

    End Function

    Public Shared Function PopulaDadosCntr(QualCntr As Integer, Flag_DDC As Integer, Placa As String, Ordem As Long) As Ordens

        Dim Rst As New DataTable
        Dim Rst2 As New DataTable
        Dim Sql As String
        Dim SqlF As String

        If BD.BancoEmUso = "ORACLE" Then

            Sql = "SELECT "
            Sql = Sql & " PATIO,"
            Sql = Sql & " ID_CONTEINER,"
            Sql = Sql & " MOTIVO_ABERTURA,"
            Sql = Sql & " YARD,"
            Sql = Sql & " DECODE(DT_INICIO,NULL,'__/__ __:__',TO_CHAR(DT_INICIO,'DD/MM/YYYY HH24:MI')) AS DT_INICIO,"
            Sql = Sql & " DECODE(DT_FIM,NULL,'__/__ __:__',TO_CHAR(DT_FIM,'DD/MM/YYYY HH24:MI')) AS DT_FIM,"
            Sql = Sql & " CAMERA,"
            Sql = Sql & " NVL(FLAG_DESOVA_MANUAL,9) AS FLAG_DESOVA_MANUAL,"
            Sql = Sql & " AUTONUM_CNTR, "
            Sql = Sql & " NVL(IDTIMELINE,0) AS IDTIMELINE,"
            Sql = Sql & " NVL(OBS_DESOVA_COL,' ') AS OBS_DESOVA_COL "
            If Flag_DDC = 0 Then
                Sql = Sql & ",'' AS PLACA"
                Sql = Sql & ", 0 AS OC"
                Sql = Sql & " FROM SGIPA.VW_DESOVA_COL_CNTR"

            Else
                Sql = Sql & " ,PLACA_C AS PLACA"
                Sql = Sql & " ,OC AS OC"
                Sql = Sql & " FROM SGIPA.VW_DDC_COL_CNTR"
            End If
            Sql = Sql & " WHERE AUTONUM_CNTR={0} "
            If Flag_DDC = 0 Then
                SqlF = String.Format(Sql, QualCntr)
            Else
                Sql = Sql & " AND PLACA_C='{1}' "
                Sql = Sql & " AND OC='{2}' "
                SqlF = String.Format(Sql, QualCntr, Placa, Ordem)
            End If

            Rst = OracleDAO.List(SqlF)

        End If

        If Rst.Rows.Count > 0 Then

            Dim OrdensOBJ As New Ordens


            OrdensOBJ.Yard = Rst.Rows(0)("YARD").ToString
            OrdensOBJ.DtFim = Rst.Rows(0)("DT_FIM").ToString
            OrdensOBJ.DtInicio = Rst.Rows(0)("DT_INICIO").ToString
            OrdensOBJ.Camera = Rst.Rows(0)("CAMERA").ToString
            OrdensOBJ.Autonum_Cntr = Rst.Rows(0)("AUTONUM_CNTR")
            OrdensOBJ.FlagDesovaManual = Rst.Rows(0)("FLAG_DESOVA_MANUAL")
            OrdensOBJ.IdtimeLine = Rst.Rows(0)("IDTIMELINE")
            OrdensOBJ.Placa = Rst.Rows(0)("PLACA").ToString
            OrdensOBJ.OC = Rst.Rows(0)("OC")

            Rst2 = OracleDAO.List("SELECT BL,NVL(OBS_DESOVA_COL,' ') OBS_DESOVA_COL FROM SGIPA.TB_CARGA_SOLTA WHERE CNTR = " & QualCntr)

            OrdensOBJ.Obs_Desova_Col = ""

            For I = 0 To Rst2.Rows.Count - 1
                OrdensOBJ.Obs_Desova_Col += "Lote: " & Rst2.Rows(I)("BL").ToString & " - " & Rst2.Rows(I)("OBS_DESOVA_COL").ToString & "<br/>"
            Next

            Rst2.Dispose()

            Return OrdensOBJ

        End If

        Rst.Dispose()

        Return Nothing

    End Function

    Public Function Agora() As Date

        Dim Rst As New DataTable
        Dim Sql As String


        If BD.BancoEmUso = "ORACLE" Then

            Sql = "SELECT SYSDATE AS JA FROM DUAL "

            Rst = OracleDAO.List(Sql)

            Return Rst.Rows(0)("JA")

            Rst.Dispose()

        End If

    End Function

    Public Shared Function PopulaItemManifestado(Lote As Integer, Autonum_Cntr As Integer, Item As Integer, Flag_DDC As Integer) As Ordens

        Dim Rst As New DataTable
        Dim RstD As New DataTable
        Dim Sql As String
        Dim SqlF As String

        If BD.BancoEmUso = "ORACLE" Then

            Sql = "SELECT "
            Sql = Sql & " ITEM,"
            Sql = Sql & " QUANTIDADE,"
            Sql = Sql & " COD_EMBALAGEM,"
            Sql = Sql & " MERCADORIA,"
            Sql = Sql & " MARCA,"
            Sql = Sql & " PESO_BRUTO,"
            Sql = Sql & " FLAG_MADEIRA,"
            Sql = Sql & " FLAG_AVARIA,  VOLUME , IMO AS IMO, ONU AS ONU, 0 AS GENERO,FLAG_HUBPORT,IMPORTADOR, ANVISA, FLAG_ANVISA  "
            If Flag_DDC = 0 Then
                Sql = Sql & " FROM SGIPA.VW_DESOVA_COL_ITENS"
            Else
                Sql = Sql & " FROM SGIPA.VW_DDC_COL_ITENS"
            End If
            Sql = Sql & " WHERE LOTE={0} "
            Sql = Sql & " AND ITEM={1} "
            SqlF = String.Format(Sql, Lote, Item)

            Rst = OracleDAO.List(SqlF)

            Sql = "SELECT "
            Sql = Sql & " NVL(SUM(QUANTIDADE),0) AS QUANTIDADE,MAX(FLAG_AVARIADO) AS FLAG_AVARIADO, MAX(COD_EMBALAGEM) AS COD_EMBALAGEM "

            If Flag_DDC = 0 Then
                Sql = Sql & " FROM SGIPA.VW_DESOVA_COL_ITENS_DESOVADOS"
            Else
                Sql = Sql & " FROM SGIPA.VW_DDC_COL_ITENS_DESOVADOS"
            End If
            Sql = Sql & " WHERE LOTE={0} "

            Sql = Sql & " AND ITEM={1} "


            SqlF = String.Format(Sql, Lote, Item)

            RstD = OracleDAO.List(SqlF)


        Else

            Sql = ""

        End If

        If Rst.Rows.Count > 0 Then

            Dim OrdensOBJ As New Ordens

            OrdensOBJ.QtdeM = Rst.Rows(0)("QUANTIDADE")
            OrdensOBJ.ANVISA = Rst.Rows(0)("ANVISA").ToString
            OrdensOBJ.FlagAnvisa = Rst.Rows(0)("FLAG_ANVISA").ToString

            If RstD.Rows(0)("QUANTIDADE") = 0 Then
                OrdensOBJ.Qtde = Rst.Rows(0)("QUANTIDADE")
                OrdensOBJ.Embalagem = Rst.Rows(0)("COD_EMBALAGEM")
            Else
                If Rst.Rows(0)("QUANTIDADE") - RstD.Rows(0)("QUANTIDADE") > 0 Then
                    OrdensOBJ.Qtde = Rst.Rows(0)("QUANTIDADE") - RstD.Rows(0)("QUANTIDADE")
                Else
                    OrdensOBJ.Qtde = 0
                End If
                OrdensOBJ.ehAvaria = RstD.Rows(0)("FLAG_AVARIADO")
                OrdensOBJ.Embalagem = RstD.Rows(0)("COD_EMBALAGEM")

            End If



            OrdensOBJ.Mercadoria = Rst.Rows(0)("MERCADORIA").ToString
            OrdensOBJ.Volume = Rst.Rows(0)("VOLUME")
            OrdensOBJ.Marca = Rst.Rows(0)("MARCA").ToString
            OrdensOBJ.Importador = Rst.Rows(0)("IMPORTADOR").ToString
            OrdensOBJ.PesoBruto = Rst.Rows(0)("PESO_BRUTO")
            OrdensOBJ.Imo = Rst.Rows(0)("IMO").ToString
            OrdensOBJ.Onu = Rst.Rows(0)("ONU").ToString
            OrdensOBJ.Genero = Rst.Rows(0)("GENERO")
            OrdensOBJ.ehHubPort = Rst.Rows(0)("FLAG_HUBPORT")


            Return OrdensOBJ

        End If

        Return Nothing



    End Function
    Public Shared Function PopulaItemRegistrado(AUTONUMRCS As Long) As Ordens

        Dim Rst As New DataTable
        Dim RstD As New DataTable
        Dim Sql As String

        Sql = "select CS.AUTONUM AS AUTONUMCARGA, a.quantidade, C.CODE AS COD_EMBALAGEM, c.descr as EMBALAGEM, CS.MARCA, CS.MERCADORIA, a.autonum  AS AUTONUMRCS ,CS.PESO_BRUTO,CS.QUANTIDADE_REAL "
        Sql = Sql & " from sgipa.tb_registro_saida_cs a"
        Sql = Sql & " inner join sgipa.tb_ordem_carregamento b on a.ordem_carreg=b.autonum"
        Sql = Sql & " inner join sgipa.tb_carga_solta cs on A.cs=cs.autonum"
        Sql = Sql & " inner join SGIPA.dte_tb_embalagens c on CS.embalagem = c.code"
        Sql = Sql & " where "
        Sql = Sql & " a.autonum=" & AUTONUMRCS
        Rst = OracleDAO.List(Sql)

        If Rst.Rows.Count > 0 Then

            Dim OrdensOBJ As New Ordens

            OrdensOBJ.QtdeM = Rst.Rows(0)("QUANTIDADE")
            OrdensOBJ.Qtde = Rst.Rows(0)("QUANTIDADE")
            OrdensOBJ.Embalagem = Rst.Rows(0)("COD_EMBALAGEM").ToString
            OrdensOBJ.Mercadoria = Rst.Rows(0)("MERCADORIA").ToString
            OrdensOBJ.Marca = Rst.Rows(0)("MARCA").ToString
            OrdensOBJ.AutonumRCS = Rst.Rows(0)("AUTONUMRCS").ToString
            OrdensOBJ.PesoBruto = Math.Round(Rst.Rows(0)("PESO_BRUTO") * (Rst.Rows(0)("QUANTIDADE") / Rst.Rows(0)("QUANTIDADE_REAL")), 3)
            OrdensOBJ.Autonum_CS = Rst.Rows(0)("AUTONUMCARGA")
            Rst.Dispose()

            Return OrdensOBJ

        End If

        Rst.Dispose()


        Return Nothing



    End Function


    Public Shared Function MostrarDesovas(ByVal Lote As Integer, ByVal Autonum_Cntr As Integer, Flag_DDC As Integer) As DataTable

        Dim Sql As String
        Dim SqlF As String

        Sql = " Select "
        Sql = Sql & " ITEM, QUANTIDADE, DESCR_EMBALAGEM As EMBALAGEM, Mercadoria, Marca, AUTONUM As AUTONUM_CS,CASE FLAG_AVARIADO WHEN 0 THEN '' ELSE 'X' END AS FLAG_AVARIADO, CASE IDFA WHEN 0 THEN '' ELSE 'X' END AS IDFA ,FLAG_MADEIRA,CASE FLAG_ACRESCIMO WHEN 0 THEN '' ELSE 'X' END AS FLAG_ACRESCIMO ,PESO_BRUTO, CASE FLAG_AG_DESP_DESOVA WHEN 0 THEN '' ELSE 'X' END AS AG_DESP "
        Sql = Sql & " FROM "
        If Flag_DDC = 0 Then
            Sql = Sql & " SGIPA.VW_DESOVA_COL_ITENS_DESOVADOS "
        Else
            Sql = Sql & " SGIPA.VW_DDC_COL_ITENS_DESOVADOS "
        End If
        Sql = Sql & " WHERE "
        Sql = Sql & " LOTE={0} "
        Sql = Sql & " AND AUTONUM_CNTR = {1} "
        Sql = Sql & " ORDER BY ITEM "

        SqlF = String.Format(Sql, Lote, Autonum_Cntr)

        Return OracleDAO.List(SqlF)

    End Function
    Public Shared Function MostrarRegistroCS(ByVal Lote As Long, ByVal Autonum_Cntr As Long, Flag_DDC As Integer, OC As Long) As DataTable

        Dim Sql As String


        Sql = "select a.QUANTIDADE, c.descr as EMBALAGEM , CS.MARCA ,CS.MERCADORIA,  a.autonum as AUTONUMRCS"
        Sql = Sql & " from sgipa.tb_registro_saida_cs a "
        Sql = Sql & " inner join sgipa.tb_ordem_carregamento b on a.ordem_carreg=b.autonum"
        Sql = Sql & " inner join sgipa.tb_carga_solta cs on A.cs=cs.autonum"
        Sql = Sql & " inner join SGIPA.dte_tb_embalagens c on CS.embalagem = c.code"
        Sql = Sql & " where "
        Sql = Sql & " b.autonum=" & OC
        Sql = Sql & " and cs.bl=" & Lote
        Sql = Sql & " and cs.cntr=" & Autonum_Cntr
        Sql = Sql & " ORDER BY EMBALAGEM,MARCA "

        Return OracleDAO.List(Sql)


    End Function
    Public Shared Function MostrarAvarias(ByVal Lote As Integer, ByVal Item As Integer) As DataTable

        Dim Sql As String
        Dim SqlF As String


        Sql = " SELECT "
        Sql = Sql & " AUTONUM, "
        Sql = Sql & " QTDE, "
        Sql = Sql & " LOCAL, "
        Sql = Sql & " TIPO, "
        Sql = Sql & " COMPL, "
        Sql = Sql & " PROVI, "
        Sql = Sql & " PESO "
        Sql = Sql & " FROM "
        Sql = Sql & " SGIPA.VW_COL_AVARIAS_ITEM "
        Sql = Sql & " WHERE "
        Sql = Sql & " BL={0} "
        Sql = Sql & " AND ITEM = {1} "


        SqlF = String.Format(Sql, Lote, Item)

        Return OracleDAO.List(SqlF)

    End Function
    Public Function ValidarExclusaoDesova(ByVal Ordens As Ordens)

        Return True

    End Function


    Public Function ExcluirDesova(ByVal Ordem As Ordens, QualCntr As String) As Boolean

        Dim SQL As New StringBuilder


        If BD.BancoEmUso = "ORACLE" Then

            OracleDAO.Execute("UPDATE SGIPA.TB_MARCANTES SET AUTONUM_CARGA=0,VOLUMES=0,DT_ASSOCIACAO=NULL WHERE AUTONUM_CARGA=" & Ordem.Autonum_CS)

            If Ordem.Autonum_CS > 0 Then
                OracleDAO.Execute("DELETE FROM SGIPA.TB_AVARIAS_CS WHERE AUTONUMCS=" & Ordem.Autonum_CS)
                OracleDAO.Execute("DELETE FROM SGIPA.TB_CARGA_SOLTA_DESOVA_COL  WHERE AUTONUMCS=" & Ordem.Autonum_CS)
            Else
                OracleDAO.Execute("DELETE FROM SGIPA.TB_AVARIAS_CS WHERE AUTONUMCS=0 And BL=" & Ordem.Lote & " And ITEM=" & Ordem.Item)
            End If

            OracleDAO.Execute("DELETE FROM SGIPA.TB_TEMP_DESOVA_MARCANTE WHERE LOTE='" & Ordem.Lote & "' AND ID_CONTEINER='" & QualCntr & "'")


            SQL.Append(String.Format("DELETE FROM SGIPA.TB_CARGA_SOLTA WHERE AUTONUM={0}", Ordem.Autonum_CS))
        End If

        Try

            OracleDAO.Execute(SQL.ToString())

            Return True

        Catch ex As Exception
            Throw New Exception("Erro. Tente novamente." & ex.Message())
        End Try

        Return False

    End Function

    Private Shared Sub Atualiza_Agendamento(Lote As Long, CS As Long, Placa As String, Q As Integer)
        Dim Sql As String

        Sql = "UPDATE SGIPA.TB_AG_CS_NF Set QTDE=" & Q
        Sql = Sql & " WHERE AUTONUM In ("
        Sql = Sql & " Select A.AUTONUM "
        Sql = Sql & " From"
        Sql = Sql & " SGIPA.TB_AG_CS_NF a"
        Sql = Sql & " INNER JOIN SGIPA.TB_AG_CS B On A.AUTONUM_AGENDAMENTO= B.AUTONUM"
        Sql = Sql & " INNER JOIN OPERADOR.TB_AG_VEICULOS C On B.AUTONUM_VEICULO=C.AUTONUM"
        Sql = Sql & " WHERE A.LOTE=" & Lote & " And A.AUTONUM_CS=" & CS & " And C.PLACA_CAVALO='" & Placa & "'"
        Sql = Sql & ")"

        OracleDAO.Execute(Sql)

    End Sub


End Class
