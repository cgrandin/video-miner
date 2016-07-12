Public Class DynamicTextbox
    Inherits TextBox

    Private m_button_font As String
    Private m_button_text_size As String

    Public Sub New(buttonFont As String, buttonTextSize As String)
        m_button_font = buttonFont
        m_button_text_size = buttonTextSize

        Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"
        Dim txtName As String = Name
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
        Dim font_family As FontFamily
        Try
            font_family = New FontFamily(buttonFont)
        Catch ex As Exception
            font_family = New FontFamily(DEFAULT_BUTTON_FONT)
        End Try
        If font_family.IsStyleAvailable(FontStyle.Regular) Then
            Me.Font = New Font(font_family, Convert.ToSingle(m_button_text_size, Globalization.CultureInfo.InvariantCulture), FontStyle.Regular)
        ElseIf font_family.IsStyleAvailable(FontStyle.Bold) Then
            Me.Font = New Font(font_family, Convert.ToSingle(m_button_text_size, Globalization.CultureInfo.InvariantCulture), FontStyle.Bold)
        ElseIf font_family.IsStyleAvailable(FontStyle.Italic) Then
            Me.Font = New Font(font_family, Convert.ToSingle(m_button_text_size, Globalization.CultureInfo.InvariantCulture), FontStyle.Italic)
        End If
        'Me.Font = New Font(font_family, Convert.ToSingle(m_button_text_size, Globalization.CultureInfo.InvariantCulture), FontStyle.Bold)
    End Sub
    Public Sub setNoData(strText As String)
        Me.Text = strText
        Me.ForeColor = Color.Red
    End Sub

    Public Sub setData(text As String)
        Me.Text = text
        Me.ForeColor = Color.Green
    End Sub

End Class
