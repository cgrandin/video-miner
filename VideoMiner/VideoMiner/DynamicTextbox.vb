Public Class DynamicTextbox
    Inherits TextBox

    ''' <summary>
    ''' A unique key so that this DynamicTextbox can be linked to a corresponding DynamicButton later.
    ''' One and only one DynamicButton will have the same control code as this.
    ''' </summary>
    Private m_control_code As Integer
    Private m_text As String

    Public Property ControlCode As String
        Get
            Return m_control_code
        End Get
        Set(value As String)
            m_control_code = value
        End Set
    End Property

    Public Sub New(controlCode As Integer, name As String, buttonFont As String, buttonTextSize As Integer)
        Me.ControlCode = controlCode
        'Me.Name = "txt" & Replace(name, "%", "Percent")
        Me.Name = name
        m_text = name
        Me.Text = "No " & name
        'm_data_code_name = dataCodeName
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

    Public Sub setNoData()
        Me.Text = "No " & m_text
        Me.ForeColor = Color.Red
    End Sub

    Public Sub setData(text As String)
        Me.Text = text
        Me.ForeColor = Color.Green
    End Sub
End Class
