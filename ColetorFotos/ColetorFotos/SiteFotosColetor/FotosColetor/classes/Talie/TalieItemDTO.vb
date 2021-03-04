Public Class TalieItemDTO

    Private _Item As Integer
    Private _NumNF As String
    Private _CodigoNF As String
    Private _CodigoRegCs As Long
    Private _CodigoTalie As Long
    Private _CodigoBooking As Long
    Private _CodigoRegistro As Long
    Private _CodigoItem As Long
    Private _CodigoPatio As Long
    Private _Peso As String
    Private _PesoBruto As Long
    Private _Qtde As Long
    Private _Quantidade As Long
    Private _QtdeEstufagem As Long
    Private _QtdeDescarga As Long
    Private _Remonte As String
    Private _Fumigacao As String
    Private _CLAC As String
    Private _CLAL As String
    Private _CLAA As String
    Private _IMO1 As String
    Private _UNO1 As String
    Private _IMO2 As String
    Private _UNO2 As String
    Private _IMO3 As String
    Private _UNO3 As String
    Private _IMO4 As String
    Private _UNO4 As String
    Private _Local As String
    Private _Saldo As String
    Private _FimNota As String
    Private _CodigoEmbalagem As String
    Private _Embalagem As String
    Private _FlagMadeira As Boolean
    Private _FlagFragil As Boolean
    Private _Inconsistencia As String
    Private _Resumo As TalieItemResumoDTO

    Public Property Item() As Integer
        Get
            Return _Item
        End Get
        Set(ByVal value As Integer)
            _Item = value
        End Set
    End Property

    Public Property NumNF() As String
        Get
            Return _NumNF
        End Get
        Set(ByVal value As String)
            _NumNF = value
        End Set
    End Property

    Public Property CodigoNF() As String
        Get
            Return _CodigoNF
        End Get
        Set(ByVal value As String)
            _CodigoNF = value
        End Set
    End Property

    Public Property CodigoRegCs() As Long
        Get
            Return _CodigoRegCs
        End Get
        Set(ByVal value As Long)
            _CodigoRegCs = value
        End Set
    End Property

    Public Property CodigoTalie() As Long
        Get
            Return _CodigoTalie
        End Get
        Set(ByVal value As Long)
            _CodigoTalie = value
        End Set
    End Property

    Public Property CodigoBooking() As Long
        Get
            Return _CodigoBooking
        End Get
        Set(ByVal value As Long)
            _CodigoBooking = value
        End Set
    End Property

    Public Property CodigoRegistro() As Long
        Get
            Return _CodigoRegistro
        End Get
        Set(ByVal value As Long)
            _CodigoRegistro = value
        End Set
    End Property

    Public Property CodigoItem() As Long
        Get
            Return _CodigoItem
        End Get
        Set(ByVal value As Long)
            _CodigoItem = value
        End Set
    End Property

    Public Property CodigoPatio() As Long
        Get
            Return _Codigopatio
        End Get
        Set(ByVal value As Long)
            _Codigopatio = value
        End Set
    End Property

    Public Property Peso() As String
        Get
            Return _Peso
        End Get
        Set(ByVal value As String)
            _Peso = value
        End Set
    End Property

    Public Property PesoBruto() As Long
        Get
            Return _PesoBruto
        End Get
        Set(ByVal value As Long)
            _PesoBruto = value
        End Set
    End Property

    Public Property Qtde() As Long
        Get
            Return _Qtde
        End Get
        Set(ByVal value As Long)
            _Qtde = value
        End Set
    End Property

    Public Property Quantidade() As Long
        Get
            Return _Quantidade
        End Get
        Set(ByVal value As Long)
            _Quantidade = value
        End Set
    End Property

    Public Property QtdeEstufagem() As Long
        Get
            Return _QtdeEstufagem
        End Get
        Set(ByVal value As Long)
            _QtdeEstufagem = value
        End Set
    End Property

    Public Property QtdeDescarga() As Long
        Get
            Return _QtdeDescarga
        End Get
        Set(ByVal value As Long)
            _QtdeDescarga = value
        End Set
    End Property

    Public Property Remonte() As String
        Get
            Return _Remonte
        End Get
        Set(ByVal value As String)
            _Remonte = value
        End Set
    End Property

    Public Property Fumigacao() As String
        Get
            Return _Fumigacao
        End Get
        Set(ByVal value As String)
            _Fumigacao = value
        End Set
    End Property

    Public Property CLAC() As String
        Get
            Return _CLAC
        End Get
        Set(ByVal value As String)
            _CLAC = value
        End Set
    End Property

    Public Property CLAL() As String
        Get
            Return _CLAL
        End Get
        Set(ByVal value As String)
            _CLAL = value
        End Set
    End Property

    Public Property CLAA() As String
        Get
            Return _CLAA
        End Get
        Set(ByVal value As String)
            _CLAA = value
        End Set
    End Property

    Public Property IMO1() As String
        Get
            Return _IMO1
        End Get
        Set(ByVal value As String)
            _IMO1 = value
        End Set
    End Property

    Public Property UNO1() As String
        Get
            Return _UNO1
        End Get
        Set(ByVal value As String)
            _UNO1 = value
        End Set
    End Property

    Public Property IMO2() As String
        Get
            Return _IMO2
        End Get
        Set(ByVal value As String)
            _IMO2 = value
        End Set
    End Property

    Public Property UNO2() As String
        Get
            Return _UNO2
        End Get
        Set(ByVal value As String)
            _UNO2 = value
        End Set
    End Property

    Public Property IMO3() As String
        Get
            Return _IMO3
        End Get
        Set(ByVal value As String)
            _IMO3 = value
        End Set
    End Property

    Public Property UNO3() As String
        Get
            Return _UNO3
        End Get
        Set(ByVal value As String)
            _UNO3 = value
        End Set
    End Property

    Public Property IMO4() As String
        Get
            Return _IMO4
        End Get
        Set(ByVal value As String)
            _IMO4 = value
        End Set
    End Property

    Public Property UNO4() As String
        Get
            Return _UNO4
        End Get
        Set(ByVal value As String)
            _UNO4 = value
        End Set
    End Property

    Public Property Local() As String
        Get
            Return _Local
        End Get
        Set(ByVal value As String)
            _Local = value
        End Set
    End Property

    Public Property Saldo() As String
        Get
            Return _Saldo
        End Get
        Set(ByVal value As String)
            _Saldo = value
        End Set
    End Property

    Public Property FimNota() As String
        Get
            Return _FimNota
        End Get
        Set(ByVal value As String)
            _FimNota = value
        End Set
    End Property

    Public Property CodigoEmbalagem() As String
        Get
            Return _CodigoEmbalagem
        End Get
        Set(ByVal value As String)
            _CodigoEmbalagem = value
        End Set
    End Property

    Public Property Embalagem() As String
        Get
            Return _Embalagem
        End Get
        Set(ByVal value As String)
            _Embalagem = value
        End Set
    End Property

    Public Property FlagMadeira() As Boolean
        Get
            Return _FlagMadeira
        End Get
        Set(ByVal value As Boolean)
            _FlagMadeira = value
        End Set
    End Property

    Public Property FlagFragil() As Boolean
        Get
            Return _FlagFragil
        End Get
        Set(ByVal value As Boolean)
            _FlagFragil = value
        End Set
    End Property

    Public Property Inconsistencia() As String
        Get
            Return _Inconsistencia
        End Get
        Set(ByVal value As String)
            _Inconsistencia = value
        End Set
    End Property

    Public Property Resumo() As TalieItemResumoDTO
        Get
            Return _Resumo
        End Get
        Set(ByVal value As TalieItemResumoDTO)
            _Resumo = value
        End Set
    End Property

End Class
