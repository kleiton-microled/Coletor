Public Class TalieDTO

    Private _Registro As Long
    Private _CodigoTalie As String
    Private _CodigoBooking As Long
    Private _CodigoReserva As Long
    Private _CodigoGate As Long
    Private _CodigoRegistro As Long
    Private _Operacao As String
    Private _Conferente As Long
    Private _Equipe As Integer
    Private _Placa As String
    Private _Reserva As String
    Private _Cliente As String
    Private _Inicio As String
    Private _Termino As String
    Private _StatusTalie As String
    Private _Observacao As String
    Private _ExisteTalieAberto As Boolean
    Private _Inconsistencia As String
    Private _CodigoErro As Integer

    Public Property Registro() As Long
        Get
            Return _Registro
        End Get
        Set(ByVal value As Long)
            _Registro = value
        End Set
    End Property

    Public Property CodigoTalie() As String
        Get
            Return _CodigoTalie
        End Get
        Set(ByVal value As String)
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

    Public Property CodigoReserva() As Long
        Get
            Return _CodigoReserva
        End Get
        Set(ByVal value As Long)
            _CodigoReserva = value
        End Set
    End Property

    Public Property CodigoGate() As Long
        Get
            Return _CodigoGate
        End Get
        Set(ByVal value As Long)
            _CodigoGate = value
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

    Public Property Operacao() As String
        Get
            Return _Operacao
        End Get
        Set(ByVal value As String)
            _Operacao = value
        End Set
    End Property

    Public Property Conferente() As Long
        Get
            Return _Conferente
        End Get
        Set(ByVal value As Long)
            _Conferente = value
        End Set
    End Property

    Public Property Equipe() As Integer
        Get
            Return _Equipe
        End Get
        Set(ByVal value As Integer)
            _Equipe = value
        End Set
    End Property

    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property

    Public Property Reserva() As String
        Get
            Return _Reserva
        End Get
        Set(ByVal value As String)
            _Reserva = value
        End Set
    End Property

    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

    Public Property Inicio() As String
        Get
            Return _Inicio
        End Get
        Set(ByVal value As String)
            _Inicio = value
        End Set
    End Property

    Public Property Termino() As String
        Get
            Return _Termino
        End Get
        Set(ByVal value As String)
            _Termino = value
        End Set
    End Property

    Public Property StatusTalie() As String
        Get
            Return _StatusTalie
        End Get
        Set(ByVal value As String)
            _StatusTalie = value
        End Set
    End Property

    Public Property Observacao() As String
        Get
            Return _Observacao
        End Get
        Set(ByVal value As String)
            _Observacao = value
        End Set
    End Property

    Public Property ExisteTalieAberto() As Boolean
        Get
            Return _ExisteTalieAberto
        End Get
        Set(ByVal value As Boolean)
            _ExisteTalieAberto = value
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

    Public Property CodigoErro() As Integer
        Get
            Return _CodigoErro
        End Get
        Set(ByVal value As Integer)
            _CodigoErro = value
        End Set
    End Property

End Class
