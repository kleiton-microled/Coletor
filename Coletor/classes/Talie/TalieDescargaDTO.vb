Public Class TalieDescargaDTO

    Private _CodigoItem As String
    Private _Descricao As String

    Public Property CodigoItem() As String
        Get
            Return _CodigoItem
        End Get
        Set(ByVal value As String)
            _CodigoItem = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return _Descricao
        End Get
        Set(ByVal value As String)
            _Descricao = value
        End Set
    End Property

End Class
