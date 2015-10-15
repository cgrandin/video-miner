Imports System.Text.RegularExpressions

Public Class frmFOV
    Private m_data As String

    Public ReadOnly Property Data As String
        Get
            Return m_data
        End Get
    End Property

    Private Sub txtFOV_Validating(sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFOV.Validating
        Dim tb As TextBox = CType(sender, TextBox)
        ' This regular expression allows 1 or more digits.
        ' So it covers integers but does not allow for the empty string.
        Dim regex As New Regex("^(\d+)*$")
        Dim match As Match = regex.Match(tb.Text)
        If match.Success Then
            m_data = txtFOV.Text
        Else
            e.Cancel = True
            tb.Select(0, tb.Text.Length)
            MessageBox.Show("Only numeric characters are permitted in the '" & Strings.Right(tb.Name, tb.Name.Length - 3) & "' textbox.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class