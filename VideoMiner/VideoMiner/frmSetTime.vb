Public Class frmSetTime

    Private m_strUserTime As String

    Public Property UserTime As String
        Get
            Return m_strUserTime.Substring(0, 2) & ":" & m_strUserTime.Substring(2, 2) & ":" & m_strUserTime.Substring(4, 2)
        End Get
        Set(value As String)
            m_strUserTime = value
        End Set
    End Property

    Event TimeChanged()
    Event UseGPSTime()
    Event UseComputerTime()
    Event UseElapsedTime()
    Event UseContinueTime()

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            m_strUserTime = Me.txtSetTime.Text
            m_strUserTime = m_strUserTime.Replace(":", "")
            'dtUserTime = New DateTime(Now().Year, Now().Month, Now().Day, CType(strUserTime.Substring(0, 2), Integer), CType(strUserTime.Substring(2, 2), Integer), CType(strUserTime.Substring(4, 2), Integer))
            RaiseEvent TimeChanged()
            If Not booUseExternalVideo Then
                'dblVideoTimeUserSet = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.currentPosition
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox("The time entered is invalid, please try again")
        End Try

    End Sub

    Public Sub setGPSInfo()
        Me.txtTimeSource.Text = "GPS"
        Me.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        Me.txtTimeSource.BackColor = Color.LightGray
        Me.txtTimeSource.ForeColor = Color.LimeGreen
        Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
    End Sub

    Private Sub cmdFromGps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseGPSTimeDate.Click
        booUseGPSTimeCodes = True
        RaiseEvent UseGPSTime()
    End Sub

    Private Sub frmSetTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            cmdOk_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub frmSetTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Me.BringToFront()
        If strUserTime = "" Then
            Me.txtSetTime.Text = "00000000"
        Else
            Me.txtSetTime.Text = strUserTime
        End If
    End Sub

    Private Sub cmdUseComputerTimeDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseComputerTimeDate.Click
        Dim strTime As String = ""
        If Now.Hour >= 10 Then
            strTime = CStr(Now.Hour)
        Else
            strTime = "0" & CStr(Now.Hour)
        End If
        If Now.Minute >= 10 Then
            strTime = strTime & ":" & CStr(Now.Minute)
        Else
            strTime = strTime & ":0" & CStr(Now.Minute)
        End If
        If Now.Second >= 10 Then
            strTime = strTime & ":" & CStr(Now.Second)
        Else
            strTime = strTime & ":0" & CStr(Now.Second)
        End If

        Dim strDate As String = ""
        If Now.Day >= 10 Then
            strDate = CStr(Now.Day)
        Else
            strDate = "0" & CStr(Now.Day)
        End If
        If Now.Month >= 10 Then
            strDate = strDate & "/" & CStr(Now.Month)
        Else
            strDate = strDate & "/0" & CStr(Now.Month)
        End If

        If Now.Year >= 10 Then
            strDate = strDate & "/" & CStr(Now.Year)
        Else
            strDate = strDate & "/0" & CStr(Now.Year)
        End If

        txtSetTime.Text = strTime

        Me.txtTimeSource.Text = "COMPUTER"
        Me.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        Me.txtTimeSource.BackColor = Color.LightGray
        Me.txtTimeSource.ForeColor = Color.LimeGreen
        Me.txtTimeSource.TextAlign = HorizontalAlignment.Center

    End Sub

    Private Sub cmdUseElapsedTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseElapsedTime.Click
        RaiseEvent UseElapsedTime()
        Me.txtTimeSource.Text = "ELAPSED"
        Me.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        Me.txtTimeSource.BackColor = Color.LightGray
        Me.txtTimeSource.ForeColor = Color.LimeGreen
        Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
        'Me.txtSetTime.Text = frmVideoPlayer.lblCurrentTime.Text
    End Sub

    Private Sub cmdContinueFromLastClip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContinueFromLastClip.Click
        RaiseEvent UseContinueTime()
        Me.txtTimeSource.Text = "VIDEO"
        Me.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        Me.txtTimeSource.BackColor = Color.LightGray
        Me.txtTimeSource.ForeColor = Color.LimeGreen
        Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
    End Sub

    'Private Sub txtSetTime_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSetTime.KeyUp
    '    If myFormLibrary.frmVideoMiner.tmrComputerTime.Enabled Then
    '        myFormLibrary.frmVideoMiner.tmrComputerTime.Stop()
    '    End If
    '    If Not myFormLibrary.frmVideoMiner.m_SerialPort Is Nothing Then
    '        If myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then
    '            Dim closePort As Thread
    '            closePort = New Thread(New ThreadStart(AddressOf myFormLibrary.frmVideoMiner.CloseSerialPort))
    '            closePort.Start()
    '        End If
    '    End If
    '    myFormLibrary.frmVideoMiner.strTimeDateSource = "VIDEO"
    '    myFormLibrary.frmVideoMiner.intTimeSource = 2
    '    myFormLibrary.frmVideoMiner.blUseGPSTime = False
    '    myFormLibrary.frmVideoMiner.blUseComputerTime = False
    '    myFormLibrary.frmVideoMiner.blUseElapsedTime = False
    '    myFormLibrary.frmVideoMiner.blUseVideoTime = True
    '    Me.txtTimeSource.Text = "VIDEO"
    '    Me.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
    '    Me.txtTimeSource.BackColor = Color.LightGray
    '    Me.txtTimeSource.ForeColor = Color.LimeGreen
    '    Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
    '    myFormLibrary.frmVideoMiner.txtTimeSource.Text = myFormLibrary.frmVideoMiner.strTimeDateSource
    '    myFormLibrary.frmVideoMiner.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
    '    myFormLibrary.frmVideoMiner.txtTimeSource.BackColor = Color.LightGray
    '    myFormLibrary.frmVideoMiner.txtTimeSource.ForeColor = Color.LimeGreen
    '    myFormLibrary.frmVideoMiner.txtTimeSource.TextAlign = HorizontalAlignment.Center
    '    myFormLibrary.frmVideoMiner.txtDateSource.Text = myFormLibrary.frmVideoMiner.strTimeDateSource
    '    myFormLibrary.frmVideoMiner.txtDateSource.Font = New Font("", 10, FontStyle.Bold)
    '    myFormLibrary.frmVideoMiner.txtDateSource.BackColor = Color.LightGray
    '    myFormLibrary.frmVideoMiner.txtDateSource.ForeColor = Color.LimeGreen
    '    myFormLibrary.frmVideoMiner.txtDateSource.TextAlign = HorizontalAlignment.Center
    'End Sub
End Class