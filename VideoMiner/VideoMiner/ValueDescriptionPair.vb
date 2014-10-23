Public Class ValueDescriptionPair
    Public Value As String
    Public Description As String

    Public Sub New(ByVal NewValue As String, ByVal NewDescription As String)
        Value = NewValue
        Description = NewDescription
    End Sub

    Public Overrides Function ToString() As String
        Return Description
    End Function
End Class
