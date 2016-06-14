''' <summary>
''' This Class was added To allow a transparent panel To lay over the video player control, 
''' so that mouse click events can be captured On the video itself.
''' </summary>
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