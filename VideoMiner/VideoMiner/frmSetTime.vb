Public Class frmSetTime

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            strUserTime = Me.txtSetTime.Text
            strUserTime = strUserTime.Replace(":", "")
            dtUserTime = New DateTime(Now().Year, Now().Month, Now().Day, CType(strUserTime.Substring(0, 2), Integer), CType(strUserTime.Substring(2, 2), Integer), CType(strUserTime.Substring(4, 2), Integer))
            myFormLibrary.frmVideoMiner.txtTime.Text = strUserTime.Substring(0, 2) & ":" & strUserTime.Substring(2, 2) & ":" & strUserTime.Substring(4, 2)
            myFormLibrary.frmVideoMiner.txtTime.Font = New Font("", 10, FontStyle.Bold)
            myFormLibrary.frmVideoMiner.txtTime.BackColor = Color.LightGray
            myFormLibrary.frmVideoMiner.txtTime.ForeColor = Color.LimeGreen
            myFormLibrary.frmVideoMiner.txtTime.TextAlign = HorizontalAlignment.Center
            If Not booUseExternalVideo Then
                dblVideoTimeUserSet = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.currentPosition
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox("The time entered is invalid, please try again")
        End Try

    End Sub

    Private Sub cmdFromGps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseGPSTimeDate.Click
        myFormLibrary.frmVideoMiner.blUseGPSTime = True
        myFormLibrary.frmVideoMiner.blUseComputerTime = False
        myFormLibrary.frmVideoMiner.blUseElapsedTime = False
        myFormLibrary.frmVideoMiner.blUseVideoTime = False

        booUseGPSTimeCodes = True
        myFormLibrary.frmVideoMiner.mnuUseGPSTimeCodes.Checked = True

        If myFormLibrary.frmVideoMiner.tmrComputerTime.Enabled Then
            myFormLibrary.frmVideoMiner.tmrComputerTime.Stop()
        End If

        myFormLibrary.frmVideoMiner.mnuUseGPSTimeCodes.Checked = True
        Call myFormLibrary.frmVideoMiner.mnuUseGPSTimeCodes_Click(sender, e)
        If myFormLibrary.frmVideoMiner.m_SerialPort Is Nothing Then
            'myFormLibrary.frmGpsSettings = New frmGpsSettings
            'myFormLibrary.frmGpsSettings.TopMost = True
            'myFormLibrary.frmGpsSettings.BringToFront()
            'myFormLibrary.frmGpsSettings.ShowDialog()
            'If myFormLibrary.frmVideoMiner.m_SerialPort Is Nothing Then
            Exit Sub
            'End If
        End If

        If myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then
            Me.txtSetTime.Text = myFormLibrary.frmVideoMiner.txtTime.Text
            'myFormLibrary.frmVideoMiner.mnuUseGPSTimeCodes.Checked = True
            'myFormLibrary.frmVideoMiner.strTimeDateSource = "GPS"
            Me.txtTimeSource.Text = "GPS"
            Me.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
            Me.txtTimeSource.BackColor = Color.LightGray
            Me.txtTimeSource.ForeColor = Color.LimeGreen
            Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
            'myFormLibrary.frmVideoMiner.lblGPSConnection.Visible = True
            'myFormLibrary.frmVideoMiner.lblGPSConnectionValue.Visible = True
            'myFormLibrary.frmVideoMiner.lblGPSPort.Visible = True
            'myFormLibrary.frmVideoMiner.lblGPSPortValue.Visible = True
            'myFormLibrary.frmVideoMiner.lblGPSLocation.Visible = True
            'myFormLibrary.frmVideoMiner.lblX.Visible = True
            'myFormLibrary.frmVideoMiner.lblXValue.Visible = True
            'myFormLibrary.frmVideoMiner.lblY.Visible = True
            'myFormLibrary.frmVideoMiner.lblYValue.Visible = True
            'myFormLibrary.frmVideoMiner.lblZ.Visible = True
            'myFormLibrary.frmVideoMiner.lblZValue.Visible = True
        End If
        'Dim aPoint As New Point
        'Dim blAquiredFix As Boolean
        'With aPoint
        '    .NMEA = myFormLibrary.frmVideoMiner.txtNMEA.Text
        '    blAquiredFix = .GetPoint     ' Returns true if there is a valid location
        'End With
        'Dim strTime As String = myFormLibrary.frmVideoMiner.GPSUserTime

        'Me.txtSetTime.Text = strTime


    End Sub

    Private Sub cmdGpsSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        myFormLibrary.frmVideoMiner.blUseGPSTime = True
        myFormLibrary.frmVideoMiner.blUseComputerTime = False
        myFormLibrary.frmVideoMiner.blUseElapsedTime = False
        myFormLibrary.frmVideoMiner.blUseVideoTime = False
        frmGpsSettings.ShowDialog()
        frmGpsSettings.Dispose()

    End Sub

    Private Sub frmSetTime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myFormLibrary.frmSetTime = Nothing
    End Sub


    Private Sub frmSetTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            Call cmdOk_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub frmSetTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myFormLibrary.frmSetTime = Me
        Me.TopMost = True
        Me.BringToFront()
        If strUserTime = "" Then
            Me.txtSetTime.Text = "00000000"
        Else
            Me.txtSetTime.Text = strUserTime
        End If
    End Sub

    Private Sub cmdUseComputerTimeDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseComputerTimeDate.Click
        If Not myFormLibrary.frmVideoMiner.m_SerialPort Is Nothing Then
            If myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then
                Dim closePort As Thread
                closePort = New Thread(New ThreadStart(AddressOf myFormLibrary.frmVideoMiner.CloseSerialPort))
                closePort.Start()
            End If
        End If
        If myFormLibrary.frmVideoMiner.tmrGPSExpiry.Enabled Then
            myFormLibrary.frmVideoMiner.tmrGPSExpiry.Stop()
        End If
        myFormLibrary.frmVideoMiner.strTimeDateSource = "COMPUTER"
        myFormLibrary.frmVideoMiner.intTimeSource = 5

        myFormLibrary.frmVideoMiner.blUseGPSTime = False
        myFormLibrary.frmVideoMiner.blUseComputerTime = True
        myFormLibrary.frmVideoMiner.blUseElapsedTime = False
        myFormLibrary.frmVideoMiner.blUseVideoTime = False
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

        If Not myFormLibrary.frmSetTime Is Nothing Then
            myFormLibrary.frmSetTime.txtSetTime.Text = strTime
        End If

        Me.txtTimeSource.Text = "COMPUTER"
        Me.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        Me.txtTimeSource.BackColor = Color.LightGray
        Me.txtTimeSource.ForeColor = Color.LimeGreen
        Me.txtTimeSource.TextAlign = HorizontalAlignment.Center

        myFormLibrary.frmVideoMiner.txtTime.Font = New Font("", 10, FontStyle.Bold)
        myFormLibrary.frmVideoMiner.txtTime.BackColor = Color.LightGray
        myFormLibrary.frmVideoMiner.txtTime.ForeColor = Color.LimeGreen
        myFormLibrary.frmVideoMiner.txtTime.TextAlign = HorizontalAlignment.Center

        myFormLibrary.frmVideoMiner.txtTimeSource.Text = myFormLibrary.frmVideoMiner.strTimeDateSource
        myFormLibrary.frmVideoMiner.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        myFormLibrary.frmVideoMiner.txtTimeSource.BackColor = Color.LightGray
        myFormLibrary.frmVideoMiner.txtTimeSource.ForeColor = Color.LimeGreen
        myFormLibrary.frmVideoMiner.txtTimeSource.TextAlign = HorizontalAlignment.Center
        myFormLibrary.frmVideoMiner.txtDateSource.Text = myFormLibrary.frmVideoMiner.strTimeDateSource
        myFormLibrary.frmVideoMiner.txtDateSource.Font = New Font("", 10, FontStyle.Bold)
        myFormLibrary.frmVideoMiner.txtDateSource.BackColor = Color.LightGray
        myFormLibrary.frmVideoMiner.txtDateSource.ForeColor = Color.LimeGreen
        myFormLibrary.frmVideoMiner.txtDateSource.TextAlign = HorizontalAlignment.Center

        myFormLibrary.frmVideoMiner.tmrComputerTime.Start()
    End Sub

    Private Sub cmdUseElapsedTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseElapsedTime.Click
        If myFormLibrary.frmVideoMiner.tmrComputerTime.Enabled Then
            myFormLibrary.frmVideoMiner.tmrComputerTime.Stop()
        End If
        If Not myFormLibrary.frmVideoMiner.m_SerialPort Is Nothing Then
            If myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then
                Dim closePort As Thread
                closePort = New Thread(New ThreadStart(AddressOf myFormLibrary.frmVideoMiner.CloseSerialPort))
                closePort.Start()
            End If
        End If
        myFormLibrary.frmVideoMiner.strTimeDateSource = "ELAPSED"
        myFormLibrary.frmVideoMiner.intTimeSource = 1
        myFormLibrary.frmVideoMiner.blUseGPSTime = False
        myFormLibrary.frmVideoMiner.blUseComputerTime = False
        myFormLibrary.frmVideoMiner.blUseElapsedTime = True
        myFormLibrary.frmVideoMiner.blUseVideoTime = False

        Me.txtTimeSource.Text = "ELAPSED"
        Me.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        Me.txtTimeSource.BackColor = Color.LightGray
        Me.txtTimeSource.ForeColor = Color.LimeGreen
        Me.txtTimeSource.TextAlign = HorizontalAlignment.Center

        myFormLibrary.frmVideoMiner.txtTimeSource.Text = myFormLibrary.frmVideoMiner.strTimeDateSource
        myFormLibrary.frmVideoMiner.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        myFormLibrary.frmVideoMiner.txtTimeSource.BackColor = Color.LightGray
        myFormLibrary.frmVideoMiner.txtTimeSource.ForeColor = Color.LimeGreen
        myFormLibrary.frmVideoMiner.txtTimeSource.TextAlign = HorizontalAlignment.Center
        myFormLibrary.frmVideoMiner.txtDateSource.Text = myFormLibrary.frmVideoMiner.strTimeDateSource
        myFormLibrary.frmVideoMiner.txtDateSource.Font = New Font("", 10, FontStyle.Bold)
        myFormLibrary.frmVideoMiner.txtDateSource.BackColor = Color.LightGray
        myFormLibrary.frmVideoMiner.txtDateSource.ForeColor = Color.LimeGreen
        myFormLibrary.frmVideoMiner.txtDateSource.TextAlign = HorizontalAlignment.Center
        Me.txtSetTime.Text = myFormLibrary.frmVideoPlayer.lblCurrentTime.Text
    End Sub

    Private Sub cmdPlayPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlayPause.Click
        Call myFormLibrary.frmVideoMiner.cmdPlayPause_Click(sender, e)
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        Call myFormLibrary.frmVideoMiner.cmdStop_Click(sender, e)
    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        Call myFormLibrary.frmVideoMiner.cmdPrevious_Click(sender, e)
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        Call myFormLibrary.frmVideoMiner.cmdNext_Click(sender, e)
    End Sub

    Private Sub cmdContinueFromLastClip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContinueFromLastClip.Click
        If myFormLibrary.frmVideoMiner.tmrComputerTime.Enabled Then
            myFormLibrary.frmVideoMiner.tmrComputerTime.Stop()
        End If
        If Not myFormLibrary.frmVideoMiner.m_SerialPort Is Nothing Then
            If myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then
                Dim closePort As Thread
                closePort = New Thread(New ThreadStart(AddressOf myFormLibrary.frmVideoMiner.CloseSerialPort))
                closePort.Start()
            End If
        End If
        myFormLibrary.frmVideoMiner.strTimeDateSource = "VIDEO"
        myFormLibrary.frmVideoMiner.intTimeSource = 2
        myFormLibrary.frmVideoMiner.blUseGPSTime = False
        myFormLibrary.frmVideoMiner.blUseComputerTime = False
        myFormLibrary.frmVideoMiner.blUseElapsedTime = False
        myFormLibrary.frmVideoMiner.blUseVideoTime = True
        Me.txtTimeSource.Text = "VIDEO"
        Me.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        Me.txtTimeSource.BackColor = Color.LightGray
        Me.txtTimeSource.ForeColor = Color.LimeGreen
        Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
        Me.txtSetTime.Text = myFormLibrary.frmVideoMiner.strPreviousClipTime
        myFormLibrary.frmVideoMiner.txtTimeSource.Text = myFormLibrary.frmVideoMiner.strTimeDateSource
        myFormLibrary.frmVideoMiner.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        myFormLibrary.frmVideoMiner.txtTimeSource.BackColor = Color.LightGray
        myFormLibrary.frmVideoMiner.txtTimeSource.ForeColor = Color.LimeGreen
        myFormLibrary.frmVideoMiner.txtTimeSource.TextAlign = HorizontalAlignment.Center
        myFormLibrary.frmVideoMiner.txtDateSource.Text = myFormLibrary.frmVideoMiner.strTimeDateSource
        myFormLibrary.frmVideoMiner.txtDateSource.Font = New Font("", 10, FontStyle.Bold)
        myFormLibrary.frmVideoMiner.txtDateSource.BackColor = Color.LightGray
        myFormLibrary.frmVideoMiner.txtDateSource.ForeColor = Color.LimeGreen
        myFormLibrary.frmVideoMiner.txtDateSource.TextAlign = HorizontalAlignment.Center
    End Sub

    Private Sub txtSetTime_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSetTime.KeyUp
        If myFormLibrary.frmVideoMiner.tmrComputerTime.Enabled Then
            myFormLibrary.frmVideoMiner.tmrComputerTime.Stop()
        End If
        If Not myFormLibrary.frmVideoMiner.m_SerialPort Is Nothing Then
            If myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then
                Dim closePort As Thread
                closePort = New Thread(New ThreadStart(AddressOf myFormLibrary.frmVideoMiner.CloseSerialPort))
                closePort.Start()
            End If
        End If
        myFormLibrary.frmVideoMiner.strTimeDateSource = "VIDEO"
        myFormLibrary.frmVideoMiner.intTimeSource = 2
        myFormLibrary.frmVideoMiner.blUseGPSTime = False
        myFormLibrary.frmVideoMiner.blUseComputerTime = False
        myFormLibrary.frmVideoMiner.blUseElapsedTime = False
        myFormLibrary.frmVideoMiner.blUseVideoTime = True
        Me.txtTimeSource.Text = "VIDEO"
        Me.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        Me.txtTimeSource.BackColor = Color.LightGray
        Me.txtTimeSource.ForeColor = Color.LimeGreen
        Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
        myFormLibrary.frmVideoMiner.txtTimeSource.Text = myFormLibrary.frmVideoMiner.strTimeDateSource
        myFormLibrary.frmVideoMiner.txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        myFormLibrary.frmVideoMiner.txtTimeSource.BackColor = Color.LightGray
        myFormLibrary.frmVideoMiner.txtTimeSource.ForeColor = Color.LimeGreen
        myFormLibrary.frmVideoMiner.txtTimeSource.TextAlign = HorizontalAlignment.Center
        myFormLibrary.frmVideoMiner.txtDateSource.Text = myFormLibrary.frmVideoMiner.strTimeDateSource
        myFormLibrary.frmVideoMiner.txtDateSource.Font = New Font("", 10, FontStyle.Bold)
        myFormLibrary.frmVideoMiner.txtDateSource.BackColor = Color.LightGray
        myFormLibrary.frmVideoMiner.txtDateSource.ForeColor = Color.LimeGreen
        myFormLibrary.frmVideoMiner.txtDateSource.TextAlign = HorizontalAlignment.Center
    End Sub
End Class