Imports System.Windows.Forms
' This class was added to allow a transparent panel to lay over the VLC player control, so that mouse click events can be captured on the video itself.
Public Class TransparentPanel
    Inherits Panel

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H20 ''#WS_EX_TRANSPARENT
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Do nothing for the OnPaint call
    End Sub

End Class