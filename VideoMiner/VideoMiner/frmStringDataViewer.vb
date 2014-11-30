Public Class frmStringDataViewer
    Private m_blCloseAllowed
    Private m_blPaused

    Event ClosingEvent()

    Public Sub AppendString(str As String)
        Dim s As String = str & vbCrLf
        Try
            If Not m_blPaused Then
                txtStringData.AppendText(s)
                txtStringData.Refresh()
            End If
        Catch ex As Exception
            ' Sometimes the AppendString method could be called after the form is dispoed
            ' so catch the exception and ignore it
        End Try
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs)
        If Not m_blCloseAllowed And e.CloseReason = CloseReason.UserClosing Then
            Me.Hide()
            e.Cancel = True
        End If
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub frmStringDataViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RaiseEvent ClosingEvent()
    End Sub

    Private Sub frmStringDataViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_blPaused = False
        m_blCloseAllowed = True
        txtStringData.AppendText("VideoMiner Serial Port Data viewer" & vbCrLf & "Waiting for data stream..." & vbCrLf)
    End Sub

    Private Sub cmdPause_Click(sender As Object, e As EventArgs) Handles cmdPause.Click
        If m_blPaused Then
            cmdPause.Text = "Pause"
        Else
            cmdPause.Text = "Continue"
        End If
        m_blPaused = Not m_blPaused
    End Sub

    Private Sub txtStringData_DoubleClick(sender As Object, e As EventArgs) Handles txtStringData.DoubleClick
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub
End Class