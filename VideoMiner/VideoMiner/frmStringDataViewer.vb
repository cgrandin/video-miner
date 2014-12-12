Public Class frmStringDataViewer
    Private m_blCloseAllowed
    Private m_blPaused

    Event ClosingEvent()
    ''' <summary>
    ''' Signal the calling class that you want to only be sent data for whatever string was chosen in that class.
    ''' </summary>
    Event ShowChosenStringOnlyEvent()
    ''' <summary>
    ''' Signal the calling class that you want to be sent data for all incoming NMEA strings.
    ''' </summary>
    ''' <remarks></remarks>
    Event ShowAllStringsEvent()

    Public Sub New()
        InitializeComponent()
        m_blPaused = False
        m_blCloseAllowed = False
        txtStringData.AppendText("VideoMiner Serial Port Data viewer" & vbCrLf & "Waiting for data stream..." & vbCrLf & vbCrLf)
        rbChosenStrings.Select()
    End Sub

    ''' <summary>
    ''' Clear the textbox of all data.
    ''' </summary>
    Public Sub ClearText()
        txtStringData.Text = "VideoMiner Serial Port Data viewer" & vbCrLf & "Waiting for data stream..." & vbCrLf & vbCrLf
    End Sub

    ''' <summary>
    ''' Append the string to the textbox
    ''' </summary>
    ''' <remarks>Only appends if the form is visible and not "paused"</remarks>
    Public Sub AppendString(str As String)
        Dim s As String = str & vbCrLf
        Try
            If Me.Visible And Not m_blPaused Then
                txtStringData.AppendText(s)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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

    Private Sub rbChosenStrings_CheckedChanged(sender As Object, e As EventArgs) Handles rbChosenStrings.CheckedChanged
        RaiseEvent ShowChosenStringOnlyEvent()
    End Sub

    Private Sub rbAllNMEAStrings_CheckedChanged(sender As Object, e As EventArgs) Handles rbAllNMEAStrings.CheckedChanged
        RaiseEvent ShowAllStringsEvent()
    End Sub
End Class