Option Strict Off

Imports System.Drawing.Font
Imports System.Drawing.FontFamily
Imports System.Drawing.FontConverter

Public Class frmConfigureButtonFormat

    Dim blLoad As Boolean = True

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtButtonLength_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtButtonHeight.KeyPress
        Call numericTextboxValidation(sender, e)
    End Sub

    Private Sub txtButonWidth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtButtonWidth.KeyPress
        Call numericTextboxValidation(sender, e)
    End Sub
    ' Function used for validating text entered into a text box
    Public Sub numericTextboxValidation(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            ' Allow the following characters to be entered into the text box: 1,2,3,4,5,6,7,8,9,0,. and BACKSPACE
            Case "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "0"c, "."c, Convert.ToChar(8)
                e.Handled = False
                ' Dont allow the addition of other characters in the text box
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub frmConfigureSpeciesButtons_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myFormLibrary.frmConfigureButtonFormat = Nothing
    End Sub

    Private Sub frmConfigureSpeciesButtons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myFormLibrary.frmConfigureButtonFormat = Me
        Me.txtButtonHeight.Text = myFormLibrary.frmVideoMiner.ButtonHeight
        Me.txtButtonWidth.Text = myFormLibrary.frmVideoMiner.ButtonWidth
        Me.cboButtonFont.DrawMode = DrawMode.OwnerDrawFixed
        Me.cboButtonFont.Font = New Font("Microsoft Sans Serif, 11.25pt", 11.25)
        Me.cboButtonFont.ItemHeight = 20
        Dim objFontFamily As FontFamily
        Dim objFontCollection As System.Drawing.Text.FontCollection

        objFontCollection = New System.Drawing.Text.InstalledFontCollection()
        For Each objFontFamily In objFontCollection.Families
            cboButtonFont.Items.Add(objFontFamily.Name)
        Next

        Me.cboButtonFont.SelectedItem = myFormLibrary.frmVideoMiner.ButtonFont

        Dim arrFontSize() As Integer = {8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72}
        Dim i As Integer
        For i = 0 To arrFontSize.Length - 1
            Me.cboButtonTextSize.Items.Add(arrFontSize(i))
        Next
        Me.cboButtonTextSize.Text = myFormLibrary.frmVideoMiner.ButtonTextSize

        blLoad = False
    End Sub

    Private Sub cboButtonFont_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboButtonFont.DrawItem
        e.DrawBackground()
        If (e.State And DrawItemState.Focus) <> 0 Then
            e.DrawFocusRectangle()
        End If
        Dim objBrush As Brush = Nothing
        Try
            objBrush = New SolidBrush(e.ForeColor)
            Dim _FontName As String = cboButtonFont.Items(e.Index)
            Dim _font As Font
            Dim _fontfamily As FontFamily
            _fontfamily = New FontFamily(_FontName)
            If _fontfamily.IsStyleAvailable(FontStyle.Regular) Then
                _font = New Font(_fontfamily, 14, FontStyle.Regular)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Bold) Then
                _font = New Font(_fontfamily, 14, FontStyle.Bold)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Italic) Then
                _font = New Font(_fontfamily, 14, FontStyle.Italic)
            End If

            e.Graphics.DrawString(_FontName, _font, objBrush, e.Bounds)
        Finally
            If objBrush IsNot Nothing Then
                objBrush.Dispose()
            End If
            objBrush = Nothing
        End Try
    End Sub

    Private Sub cboButtonTextSize_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboButtonTextSize.KeyPress
        Call numericTextboxValidation(sender, e)
    End Sub

    Private Sub cboButtonTextSize_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboButtonTextSize.TextChanged
        If Not blLoad Then
            Dim newFont As Font
            Dim _fontfamily As FontFamily
            _fontfamily = New FontFamily(Me.cboButtonFont.Text)
            If _fontfamily.IsStyleAvailable(FontStyle.Regular) Then
                newFont = New Font(_fontfamily, CInt(Me.cboButtonTextSize.Text), FontStyle.Regular)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Bold) Then
                newFont = New Font(_fontfamily, CInt(Me.cboButtonTextSize.Text), FontStyle.Bold)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Italic) Then
                newFont = New Font(_fontfamily, CInt(Me.cboButtonTextSize.Text), FontStyle.Italic)
            End If

            Me.cmdPreviewButton.Font = newFont

        End If
    End Sub

    Private Sub txtButtonWidth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtButtonWidth.TextChanged
        If Me.txtButtonWidth.Text <> "" Then
            Me.cmdPreviewButton.Width = Me.txtButtonWidth.Text
        End If
    End Sub

    Private Sub txtButtonHeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtButtonHeight.TextChanged
        If Me.txtButtonHeight.Text <> "" Then
            Me.cmdPreviewButton.Height = Me.txtButtonHeight.Text
        End If
    End Sub

    Private Sub cboButtonFont_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboButtonFont.SelectedIndexChanged
        If Not blLoad Then
            Dim newFont As Font
            Dim _fontfamily As FontFamily
            _fontfamily = New FontFamily(Me.cboButtonFont.Text)
            If _fontfamily.IsStyleAvailable(FontStyle.Regular) Then
                newFont = New Font(_fontfamily, CInt(Me.cboButtonTextSize.Text), FontStyle.Regular)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Bold) Then
                newFont = New Font(_fontfamily, CInt(Me.cboButtonTextSize.Text), FontStyle.Bold)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Italic) Then
                newFont = New Font(_fontfamily, CInt(Me.cboButtonTextSize.Text), FontStyle.Italic)
            End If

            Me.cmdPreviewButton.Font = newFont
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        myFormLibrary.frmVideoMiner.ButtonHeight = CInt(Me.txtButtonHeight.Text)
        myFormLibrary.frmVideoMiner.ButtonWidth = CInt(Me.txtButtonWidth.Text)
        myFormLibrary.frmVideoMiner.ButtonFont = Me.cboButtonFont.Text
        myFormLibrary.frmVideoMiner.ButtonTextSize = CInt(Me.cboButtonTextSize.Text)

        Dim strConfigFile As String = strconfigFilePath & "\VideoMinerConfigurationDetails.xml"
        SaveXmlSettings(strConfigFile, "VideoMinerConfigurationDetails/ButtonFormat/ButtonSize/Height", Me.txtButtonHeight.Text)
        SaveXmlSettings(strConfigFile, "VideoMinerConfigurationDetails/ButtonFormat/ButtonSize/Width", Me.txtButtonWidth.Text)
        SaveXmlSettings(strConfigFile, "VideoMinerConfigurationDetails/ButtonFormat/ButtonText/Font", Me.cboButtonFont.Text)
        SaveXmlSettings(strConfigFile, "VideoMinerConfigurationDetails/ButtonFormat/ButtonText/TextSize", Me.cboButtonTextSize.Text)

        If myFormLibrary.frmVideoMiner.db_file_open Then
            myFormLibrary.frmVideoMiner.blupdateColumns = False
            myFormLibrary.frmVideoMiner.pnlSpeciesData.Controls.Clear()
            Call RefreshDatabase(sender, e)
            myFormLibrary.frmVideoMiner.blupdateColumns = True
        End If
        Me.Close()
    End Sub

End Class