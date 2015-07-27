Public Class DynamicTextbox
    Inherits TextBox

    Public Sub New(name As String, buttonFont As String, buttonTextSize As Integer)
        Me.Name = "txt" & Replace(name, "%", "Percent")
        Me.Text = "No " & name
        Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"
        Dim txtName As String = name
        Dim Letter As String
        For x As Integer = 0 To Me.Name.Length - 1
            Letter = Me.Name.Substring(x, 1).ToUpper
            If strCharactersAllowed.Contains(Letter) = False Then
                txtName = txtName.Replace(Letter, String.Empty)
            End If
        Next
        Me.Name = txtName
        Me.BackColor = Color.LightGray
        Me.ForeColor = Color.Red
        Me.TextAlign = HorizontalAlignment.Center
        Me.ReadOnly = True
        Dim font_family As FontFamily = New FontFamily(buttonFont)
        If font_family.IsStyleAvailable(FontStyle.Regular) Then
            Me.Font = New Font(font_family, buttonTextSize, FontStyle.Regular)
        ElseIf font_family.IsStyleAvailable(FontStyle.Bold) Then
            Me.Font = New Font(font_family, buttonTextSize, FontStyle.Bold)
        ElseIf font_family.IsStyleAvailable(FontStyle.Italic) Then
            Me.Font = New Font(font_family, buttonTextSize, FontStyle.Italic)
        End If
        Me.Font = New Font(font_family, buttonTextSize, FontStyle.Bold)
    End Sub

End Class
