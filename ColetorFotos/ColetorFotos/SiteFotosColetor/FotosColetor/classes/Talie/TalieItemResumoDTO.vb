Public Class TalieItemResumoDTO

    Private _QtdeD As Long
    Private _QtdeR As Long
    Private _FimNota As Boolean

    Public Property QtdeD() As Integer
        Get
            Return _QtdeD
        End Get
        Set(ByVal value As Integer)
            _QtdeD = value
        End Set
    End Property

    Public Property QtdeR() As String
        Get
            Return _QtdeR
        End Get
        Set(ByVal value As String)
            _QtdeR = value
        End Set
    End Property

    Public Property FimNota() As Boolean
        Get
            Return _FimNota
        End Get
        Set(ByVal value As Boolean)
            _FimNota = value
        End Set
    End Property

    Public ReadOnly Property Saldo() As String
        Get
            Return _QtdeD.ToString() & " / " & _QtdeR.ToString()
        End Get
    End Property

End Class
