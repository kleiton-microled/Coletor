Imports System.Data.OleDb
Public Class InventarioCS
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
    Public _Patio As String
    Public _Nvocc As String
    Public _Bl As String
    Public Property Nvocc() As String
        Get
            Return Me._Nvocc
        End Get
        Set(ByVal value As String)
            Me._Nvocc = value
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


    Public Shared Function PopulaDadosLote(QualLote As String, QualPatio As Integer, Optional SoRedex As Boolean = False) As InventarioCS_f2

        Dim dr As OleDbDataReader
        Dim rsCs As New DataTable


        Using p_connect As New OleDb.OleDbConnection(BD.StringConexao)
            Using p_cmd As New OleDb.OleDbCommand()
                p_cmd.CommandType = CommandType.StoredProcedure

                p_cmd.CommandText = "SGIPA.P_CONS_INVENT_ARM"

                p_cmd.Connection = p_connect
                p_cmd.Parameters.Add("P_ID_LOTE", OleDbType.VarChar, 12).Value = QualLote
                p_cmd.Parameters.Add("P_PATIO", OleDbType.VarChar, 1).Value = QualPatio
                If InStr(QualLote, "/") = 0 Then
                    p_cmd.Parameters.Add("P_FLAG_SO_REDEX", OleDbType.Integer).Value = IIf(SoRedex, 1, 0)
                Else
                    p_cmd.Parameters.Add("P_FLAG_SO_REDEX", OleDbType.Integer).Value = 1
                End If
                p_connect.Open()
                dr = p_cmd.ExecuteReader(CommandBehavior.CloseConnection)
                rsCs.Load(dr)

                If rsCs.Rows.Count > 0 Then


                    Dim OrdensOBJ As New InventarioCS_f2

                    OrdensOBJ.Mercadoria = rsCs.Rows(0)("MERCADORIA").ToString
                    OrdensOBJ.Marca = rsCs.Rows(0)("MARCA").ToString
                    OrdensOBJ.Entrada = rsCs.Rows(0)("DATA_ENTRADA").ToString
                    OrdensOBJ.Cliente = rsCs.Rows(0)("IMPORTADOR").ToString
                    OrdensOBJ.Conteiner = rsCs.Rows(0)("CNTR_DESOVA").ToString
                    OrdensOBJ.Patio = rsCs.Rows(0)("ID_PATIO").ToString
                    OrdensOBJ.Volume = rsCs.Rows(0)("VOLUME").ToString
                    OrdensOBJ.Doc = rsCs.Rows(0)("TIPO_DOC").ToString
                    OrdensOBJ.Canal = rsCs.Rows(0)("CANAL_ALF").ToString
                    OrdensOBJ.Movimento = rsCs.Rows(0)("MOTIVO_PROX_MVTO").ToString
                    OrdensOBJ.IMO = rsCs.Rows(0)("IMO").ToString
                    OrdensOBJ.Nvocc = rsCs.Rows(0)("NVOCC").ToString
                    OrdensOBJ.BL = rsCs.Rows(0)("BL").ToString
                    OrdensOBJ.Sistema = rsCs.Rows(0)("FINALITY").ToString
                    OrdensOBJ.ANVISA = rsCs.Rows(0)("ANVISA").ToString
                    OrdensOBJ.FlagAnvisa = rsCs.Rows(0)("FLAG_ANVISA").ToString
                    Return OrdensOBJ

                End If
                rsCs.Dispose()

            End Using
        End Using




        Return Nothing



    End Function

    Public Shared Function PopulaItem(Id_Gravacao As String) As InventarioCS_f2

        Dim Rst As New ADODB.Recordset
        Dim Sql As String
        Dim SqlF As String



        If BD.BancoEmUso = "ORACLE" Then

            If Microsoft.VisualBasic.Mid(Id_Gravacao, 1, 2) <> "RV" Then


                Dim dr As OleDbDataReader
                Dim rsCs As New DataTable


                Using p_connect As New OleDb.OleDbConnection(BD.StringConexao)
                    Using p_cmd As New OleDb.OleDbCommand()
                        p_cmd.CommandType = CommandType.StoredProcedure

                        p_cmd.CommandText = "SGIPA.P_INVENT_ARM_ITEM_IDG"

                        p_cmd.Connection = p_connect
                        p_cmd.Parameters.Add("P_ID_GRAVACAO1", OleDbType.VarChar, 1).Value = Microsoft.VisualBasic.Mid(Id_Gravacao, 3, 1)
                        p_cmd.Parameters.Add("P_ID_AUTONUMCS", OleDbType.VarChar, 12).Value = Id_Gravacao.Replace("IU", "").Replace("RU", "").Replace("RV", "").Replace("C", "").Replace("Y", "")
                        p_cmd.Parameters.Add("P_SISTEMA", OleDbType.VarChar, 1).Value = Microsoft.VisualBasic.Mid(Id_Gravacao, 1, 1)
                        p_connect.Open()
                        dr = p_cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        rsCs.Load(dr)

                        If rsCs.Rows.Count > 0 Then

                            Dim OrdensOBJ As New InventarioCS_f2

                            OrdensOBJ.Quantidade = rsCs.Rows(0)("QTDE").ToString
                            OrdensOBJ.Embalagem = rsCs.Rows(0)("EMBALAGEM").ToString
                            OrdensOBJ.Local = rsCs.Rows(0)("LOCAL").ToString
                            OrdensOBJ.Yard = rsCs.Rows(0)("YARD").ToString
                            Return OrdensOBJ


                        End If
                        rsCs.Dispose()

                    End Using
                End Using



            Else

                Sql = "SELECT "
                Sql = Sql & " SUM(A.QTDE) AS QTDE,"
                Sql = Sql & " MIN(A.EMBALAGEM) AS EMBALAGEM ,"
                Sql = Sql & " (  MIN(A.DESCR_ARMAZEM) || ' ' || MIN(A.POSICAO)) AS LOCAL, "
                Sql = Sql & " MIN(A.POSICAO) AS YARD"
                Sql = Sql & " FROM OPERADOR.VW_INVENT_ARMAZEM_ITEM A INNER JOIN OPERADOR.VW_INVENT_ARMAZEM_ITEM B   "
                Sql = Sql & " ON A.EMBALAGEM=B.EMBALAGEM AND A.POSICAO=B.POSICAO AND A.LOTE_STR=B.LOTE_STR AND A.MARCANTE=B.MARCANTE WHERE A.ID_GRAVACAO='{0}' AND A.QTDE=1 "
                Sql = Sql & " GROUP BY A.LOTE_STR,A.EMBALAGEM,A.DESCR_ARMAZEM,A.POSICAO, A.MARCANTE "

                SqlF = String.Format(Sql, Id_Gravacao.Replace("IU", "").Replace("RU", "").Replace("RV", ""))

                Rst.Open(SqlF, BD.Conexao, 3, 3)

                Dim OrdensOBJ2 As New InventarioCS_f2

                OrdensOBJ2.Quantidade = Rst.Fields("QTDE").Value.ToString
                OrdensOBJ2.Embalagem = Rst.Fields("EMBALAGEM").Value.ToString
                OrdensOBJ2.Local = Rst.Fields("LOCAL").Value.ToString
                OrdensOBJ2.Yard = Rst.Fields("YARD").Value.ToString
                Return OrdensOBJ2

            End If


        Else

            Sql = ""

        End If



        Return Nothing



    End Function
    Public Shared Function ConsultarItensLote(ByVal QualLote As String, FlagRedex As Boolean, QualPatio As Integer) As DataTable



        Dim dr As OleDbDataReader
        Dim rsCs As New DataTable


        Using p_connect As New OleDb.OleDbConnection(BD.StringConexao)
            Using p_cmd As New OleDb.OleDbCommand()
                p_cmd.CommandType = CommandType.StoredProcedure
                If FlagRedex = False Then
                    p_cmd.CommandText = "SGIPA.P_CONS_INVENT_ARM_ITEM_IPA"
                Else
                    p_cmd.CommandText = "SGIPA.P_CONS_INVENT_ARM_ITEM_RDX"
                End If
                p_cmd.Connection = p_connect
                p_cmd.Parameters.Add("P_ID_LOTE", OleDbType.VarChar, 12).Value = QualLote
                p_cmd.Parameters.Add("P_PATIO", OleDbType.VarChar, 1).Value = QualPatio
                p_connect.Open()
                dr = p_cmd.ExecuteReader(CommandBehavior.CloseConnection)
                rsCs.Load(dr)

                Return rsCs


            End Using
        End Using





    End Function

    Public Shared Function ConsultarArmazens(ByVal QualPatio As String) As DataTable


        Dim Sql As String

        Sql = " select Autonum as autonum, Descr AS DISPLAY "
        Sql = Sql & " FROM sgipa.tb_armazens_ipa "
        Sql = Sql & " WHERE dt_saida is null and flag_historico=0 and "
        Sql = Sql & " patio=" & QualPatio
        Sql = Sql & " ORDER BY DESCR "


        Return OracleDAO.List(Sql)

    End Function

    Public Shared Function ConsultarYard(ByVal QualArmazem As String) As DataTable


        Dim Sql As String

        Sql = " select YARD as autonum, YARD AS DISPLAY "
        Sql = Sql & " FROM sgipa.tb_YARD_CS "
        Sql = Sql & " WHERE "
        Sql = Sql & " ARMAZEM=" & QualArmazem
        Sql = Sql & " ORDER BY YARD  "


        Return OracleDAO.List(Sql)

    End Function

    Public Shared Function ConsultarMotivo() As DataTable


        Dim Sql As String

        Sql = " select Autonum as autonum, Descricao AS DISPLAY "
        Sql = Sql & " FROM operador.tb_cad_motivo where nvl(flag_coletor,0) = 1"
        Sql = Sql & " ORDER BY descricao  "


        Return OracleDAO.List(Sql)

    End Function
End Class
