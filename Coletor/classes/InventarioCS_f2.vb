Imports System.Data.OleDb
Public Class InventarioCS_f2
    Inherits System.Web.UI.Page

    Public _Mercadoria As String
    Public _Marca As String
    Public _Entrada As String
    Public _Cliente As String
    Public _Conteiner As String

    Public _Canal As String
    Public _Volume As String
    Public _Doc As String
    Public _Movimento As String
    Public _Imo As String


    Public _Quantidade As String
    Public _Embalagem As String
    Public _Local As String
    Public _Yard As String
    Public _Patio As String
    Public _Nvocc As String
    Public _Bl As String
    Public _Lote As String
    Public _Sistema As String
    Public _ANVISA As String
    Public _FlagAnvisa As String

    Public Property Nvocc() As String
        Get
            Return Me._Nvocc
        End Get
        Set(ByVal value As String)
            Me._Nvocc = value
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

    Public Property Sistema() As String
        Get
            Return Me._Sistema
        End Get
        Set(ByVal value As String)
            Me._Sistema = value
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

    Public Property BL() As String
        Get
            Return Me._Bl
        End Get
        Set(ByVal value As String)
            Me._Bl = value
        End Set
    End Property
    Public Property Lote() As String
        Get
            Return Me._Lote
        End Get
        Set(ByVal value As String)
            Me._Lote = value
        End Set
    End Property

    Public Property Canal() As String
        Get
            Return Me._Canal
        End Get
        Set(ByVal value As String)
            Me._Canal = value
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


    Public Property Doc() As String
        Get
            Return Me._Doc
        End Get
        Set(ByVal value As String)
            Me._Doc = value
        End Set
    End Property

    Public Property Movimento() As String
        Get
            Return Me._Movimento
        End Get
        Set(ByVal value As String)
            Me._Movimento = value
        End Set
    End Property

    Public Property IMO() As String
        Get
            Return Me._Imo
        End Get
        Set(ByVal value As String)
            Me._Imo = value
        End Set
    End Property


    Public Property Patio() As String
        Get
            Return Me._Patio
        End Get
        Set(ByVal value As String)
            Me._Patio = value
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
    Public Property Quantidade() As String
        Get
            Return Me._Quantidade
        End Get
        Set(ByVal value As String)
            Me._Quantidade = value
        End Set
    End Property

    Public Property Embalagem() As String
        Get
            Return Me._Embalagem
        End Get
        Set(ByVal value As String)
            Me._Embalagem = value
        End Set
    End Property

    Public Property Local() As String
        Get
            Return Me._Local
        End Get
        Set(ByVal value As String)
            Me._Local = value
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


    Public Property Entrada() As String
        Get
            Return Me._Entrada
        End Get
        Set(ByVal value As String)
            Me._Entrada = value
        End Set
    End Property

    Public Property Cliente() As String
        Get
            Return Me._Cliente
        End Get
        Set(ByVal value As String)
            Me._Cliente = value
        End Set
    End Property

    Public Property Conteiner() As String
        Get
            Return Me._Conteiner
        End Get
        Set(ByVal value As String)
            Me._Conteiner = value
        End Set
    End Property

    Public Shared Function ValidaRegrasArmazem(AutonumCs As Long, Pilha As String, AutonumArmazem As Long) As String

        Dim Retorno As String

        Dim con As New OleDbConnection(BD.StringConexao)
        con.Open()
        Dim cmd As New OleDbCommand("OPERADOR.fValidaRegrasArmazem", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New OleDbParameter("l_result", OleDbType.VarChar, 300, ParameterDirection.ReturnValue, True, 0, 0, "l_result", DataRowVersion.Current, ""))
        cmd.Parameters.Add("p_QualCs", OleDbType.VarChar, 12).Value = AutonumCs
        cmd.Parameters.Add("p_QualPilha", OleDbType.VarChar, 12).Value = Pilha
        cmd.Parameters.Add("p_QualAutonum_Armazem", OleDbType.VarChar, 12).Value = AutonumArmazem
        cmd.ExecuteScalar()
        Retorno = (cmd.Parameters(0).Value.ToString)
        con.Close()

        Return Retorno

    End Function
    Public Shared Function PopulaDados(QualMarcante As String, QualPatio As Integer) As InventarioCS_f2

        Dim Rst0 As New ADODB.Recordset
        Dim Rst As New ADODB.Recordset
        Dim Rst2 As New ADODB.Recordset
        Dim Sql As String

        Dim Lote_Str As String = String.Empty

        If Val(QualMarcante) > 0 Then

            Sql = "SELECT SISTEMA,LOTE_STR FROM OPERADOR.VW_INVENT_ARMAZEM WHERE TO_NUMBER(MARCANTE)=" & Val(QualMarcante)
            Rst0.Open(Sql, BD.Conexao, 3, 3)

            If Not Rst0.EOF Then


                Lote_Str = Rst0.Fields("LOTE_STR").Value.ToString

                Sql = "SELECT "
                Sql = Sql & " MERCADORIA,"
                Sql = Sql & " MARCA,"
                Sql = Sql & " TO_CHAR(DATA_ENTRADA,'DD/MM/YYYY HH24:MI') AS DATA_ENTRADA,"
                Sql = Sql & " IMPORTADOR,"
                Sql = Sql & " CNTR_DESOVA, "
                Sql = Sql & " ID_PATIO,"
                Sql = Sql & " TIPO_DOC,"
                Sql = Sql & " DECODE(CANAL_ALF,0,'AMARELO',1,'VERMELHO',2,'VERDE',3,'CINZA',9,'') AS CANAL_ALF,"
                Sql = Sql & " MOTIVO_PROX_MVTO AS MOTIVO_PROX_MVTO ,"
                Sql = Sql & " VOLUME,"
                Sql = Sql & " IMO,"
                Sql = Sql & " NVOCC,"
                Sql = Sql & " BL,"
                Sql = Sql & " LOTE_STR AS LOTE,"
                Sql = Sql & " FINALITY, SISTEMA, ANVISA, FLAG_ANVISA "
                Sql = Sql & " FROM OPERADOR.VW_INVENT_ARMAZEM_COL_P" & QualPatio
                Sql = Sql & " WHERE LOTE_STR='" & Lote_Str & "'"

                Rst.Open(Sql, BD.Conexao, 3, 3)


                If Not Rst.EOF Then

                    Dim OrdensOBJ As New InventarioCS_f2

                    OrdensOBJ.Mercadoria = Rst.Fields("MERCADORIA").Value.ToString
                    OrdensOBJ.Marca = Rst.Fields("MARCA").Value.ToString
                    OrdensOBJ.Entrada = Rst.Fields("DATA_ENTRADA").Value.ToString
                    OrdensOBJ.Cliente = Rst.Fields("IMPORTADOR").Value.ToString
                    OrdensOBJ.Conteiner = Rst.Fields("CNTR_DESOVA").Value.ToString
                    OrdensOBJ.Patio = Rst.Fields("ID_PATIO").Value.ToString
                    OrdensOBJ.Volume = Rst.Fields("VOLUME").Value.ToString
                    OrdensOBJ.Doc = Rst.Fields("TIPO_DOC").Value.ToString
                    OrdensOBJ.Canal = Rst.Fields("CANAL_ALF").Value.ToString
                    OrdensOBJ.Movimento = Rst.Fields("MOTIVO_PROX_MVTO").Value.ToString
                    OrdensOBJ.IMO = Rst.Fields("IMO").Value.ToString
                    OrdensOBJ.Nvocc = Rst.Fields("NVOCC").Value.ToString
                    OrdensOBJ.BL = Rst.Fields("BL").Value.ToString
                    OrdensOBJ.Lote = Rst.Fields("Lote").Value.ToString
                    OrdensOBJ.Sistema = Rst.Fields("SISTEMA").Value.ToString
                    OrdensOBJ.ANVISA = Rst.Fields("ANVISA").Value.ToString
                    OrdensOBJ.FlagAnvisa = Rst.Fields("FLAG_ANVISA").Value.ToString

                    Return OrdensOBJ
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

            Return Nothing
        Else
            Return Nothing
        End If

    End Function

    Public Shared Function PopulaItem(QualMarcante As String) As InventarioCS_f2

        Dim Rst As New ADODB.Recordset
        Dim Sql As String
        Dim SqlF As String



        If BD.BancoEmUso = "ORACLE" Then

            Sql = "SELECT "
            Sql = Sql & " QTDE,"
            Sql = Sql & " EMBALAGEM,"
            Sql = Sql & " (DESCR_ARMAZEM || ' ' || POSICAO) AS LOCAL, "
            Sql = Sql & " POSICAO AS YARD "
            Sql = Sql & " "
            Sql = Sql & " FROM OPERADOR.VW_INVENT_ARMAZEM_ITEM"
            Sql = Sql & " WHERE MARCANTE='{0}'"


            SqlF = String.Format(Sql, QualMarcante)

            Rst.Open(SqlF, BD.Conexao, 3, 3)

        Else

            Sql = ""

        End If

        If Not Rst.EOF Then

            Dim OrdensOBJ As New InventarioCS_f2

            OrdensOBJ.Quantidade = Rst.Fields("QTDE").Value.ToString
            OrdensOBJ.Embalagem = Rst.Fields("EMBALAGEM").Value.ToString
            OrdensOBJ.Local = Rst.Fields("LOCAL").Value.ToString
            OrdensOBJ.Yard = Rst.Fields("YARD").Value.ToString
            Return OrdensOBJ

        End If

        Return Nothing



    End Function
    Public Shared Function ConsultarItensLote(ByVal QualLote As String, QualMarcante As String) As DataTable

        Dim Rst As New ADODB.Recordset

        Dim Sql As String

        Sql = " select ID_GRAVACAO as autonum, (QTDE ||  '/' || QTDE_CAPTADA || ' ' || EMBALAGEM || ' ' || DESCR_ARMAZEM || ' ' || POSICAO  ) AS DISPLAY "
        Sql = Sql & " FROM OPERADOR.VW_INVENT_ARMAZEM_ITEM "
        Sql = Sql & " WHERE "
        Sql = Sql & " LOTE_STR='" & QualLote & "'"
        Sql = Sql & " AND MARCANTE='" & QualMarcante & "'"
        Sql = Sql & " AND QTDE>0 ORDER BY DESCR_ARMAZEM,POSICAO "


        Rst.Open(Sql, BD.Conexao, 3, 3)

        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, Rst, "VIEW_ITENS_LOTES")
            Return Ds.Tables(0)
        End Using

    End Function

    Public Shared Function ConsultarArmazens(ByVal QualPatio As String) As DataTable

        Dim Rst As New ADODB.Recordset

        Dim Sql As String

        Sql = " select Autonum as autonum, Descr AS DISPLAY "
        Sql = Sql & " FROM sgipa.tb_armazens_ipa "
        Sql = Sql & " WHERE dt_saida is null and flag_historico=0 and "
        Sql = Sql & " patio=" & QualPatio
        Sql = Sql & " ORDER BY DESCR "


        Rst.Open(Sql, BD.Conexao, 3, 3)

        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, Rst, "VIEW_ARM")
            Return Ds.Tables(0)
        End Using

    End Function

    Public Shared Function ConsultarYard(ByVal QualArmazem As String) As DataTable

        Dim Rst As New ADODB.Recordset

        Dim Sql As String

        Sql = " select YARD as autonum, YARD AS DISPLAY "
        Sql = Sql & " FROM sgipa.tb_YARD_CS "
        Sql = Sql & " WHERE "
        Sql = Sql & " ARMAZEM=" & QualArmazem
        Sql = Sql & " ORDER BY YARD  "


        Rst.Open(Sql, BD.Conexao, 3, 3)

        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, Rst, "VIEW_YARD")
            Return Ds.Tables(0)
        End Using

    End Function

    Public Shared Function ConsultarMotivo() As DataTable

        Dim Rst As New ADODB.Recordset

        Dim Sql As String

        Sql = " select Autonum as autonum, Descricao AS DISPLAY "
        Sql = Sql & " FROM operador.tb_cad_motivo where nvl(flag_coletor,0) = 1"
        Sql = Sql & " ORDER BY descricao  "

        Rst.Open(Sql, BD.Conexao, 3, 3)

        Using Adapter As New OleDbDataAdapter()
            Dim Ds As New DataSet
            Adapter.Fill(Ds, Rst, "VIEW_motivos")
            Return Ds.Tables(0)
        End Using

    End Function
End Class
