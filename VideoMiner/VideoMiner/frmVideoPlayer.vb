Imports WMPLib
Imports Microsoft.Win32
'Imports AXVLC
Imports AxAXVLC

Public Class frmVideoPlayer

    Private intSeconds As Integer = 0
    Public dblDuration As Double = 0
    Public dblCurrentVideoTime As Double = 0
    Public blIsPlaying As Boolean = False
    Public blChapter As Boolean = False
    Public blRecordPerSecond As Boolean = False

    Private Sub frmVideoPlayer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myFormLibrary.frmVideoMiner.strPreviousClipTime = myFormLibrary.frmVideoMiner.txtTime.Text
        myFormLibrary.frmVideoPlayer = Nothing
        If Me.tmrCurrentTime.Enabled = True Then
            Me.tmrCurrentTime.Stop()
        End If

        If Me.tmrVideo.Enabled = True Then
            Me.tmrVideo.Stop()
        End If
        'myFormLibrary.frmVideoMiner.strPreviousClipTime = myFormLibrary.frmVideoMiner.VideoTime
        myFormLibrary.frmVideoMiner.video_file_open = False

        myFormLibrary.frmVideoMiner.pnlVideoControls.Visible = False

        Call myFormLibrary.frmVideoMiner.enableDisableVideoMenu(False)

        Call myFormLibrary.frmVideoMiner.video_file_unload()

    End Sub

    Public Sub frmVideoPlayer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myFormLibrary.frmVideoPlayer = Me
        Me.Text = myFormLibrary.frmVideoMiner.FileName
        Me.trkCurrentPosition.Value = 0
        'Dim itemId As Integer

        'Me.plyrVideoPlayer.playlist.items.clear()
        'itemId = Me.plyrVideoPlayer.playlist.add(strVideoFilePath, Me.Text, "--no-ffmpeg-hw")

        'Me.plyrVideoPlayer.playlist.playItem(itemId)
        'Dim regOverlay As RegistryKey
        'regOverlay = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\MediaPlayer\\Preferences\\VideoSettings", True)

        'regOverlay.SetValue("UseVMROverlay", 0)
        'regOverlay.Close()


        plyrVideoPlayer.uiMode = "none"
        plyrVideoPlayer.URL = strVideoFilePath

        plyrVideoPlayer.Ctlcontrols.play()

        'While Not Me.plyrVideoPlayer.playState = WMPPlayState.wmppsPlaying
        'End While
        tmrVideo.Start()

        Me.SelectNextControl(Me.SplitContainer1.Panel2, False, True, True, True)
    End Sub

    Private Sub tmrVideo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrVideo.Tick

        'If Me.plyrVideoPlayer.playState = WMPPlayState.wmppsPlaying Then

        If Me.plyrVideoPlayer.playState = WMPPlayState.wmppsPlaying Then

            Me.plyrVideoPlayer.settings.setMode("showFrame", True)
            Me.plyrVideoPlayer.Ctlcontrols.stop()

            Me.dblDuration = Me.plyrVideoPlayer.currentMedia.duration

            If myFormLibrary.frmVideoMiner.VideoTime = 0 Then
                Me.plyrVideoPlayer.Ctlcontrols.currentPosition = 0
            Else
                Me.plyrVideoPlayer.Ctlcontrols.currentPosition = myFormLibrary.frmVideoMiner.VideoTime

                Dim dblvalue As Double

                dblvalue = (myFormLibrary.frmVideoMiner.VideoTime / Me.dblDuration) * 100

                dblvalue = Math.Round(dblvalue, 0)

                trkCurrentPosition.Value = dblvalue

            End If
            'Me.plyrVideoPlayer.playlist.togglePause()

            'Call createFirstFrame()


            pctVideoStatus.BackgroundImage = Image.FromFile(filePath & "\Stop_Icon_Inverse.png")
            If Me.dblDuration <> 0 Then
                tmrVideo.Stop()
                'trkCurrentPosition.Value = 0
            Else
                Exit Sub
            End If

            Me.lblCurrentTime.Text = createTimeString(myFormLibrary.frmVideoMiner.VideoTime)
            Me.lblDuration.Text = createTimeString(Me.dblDuration)
            intSeconds = 0

            Call myFormLibrary.frmVideoMiner.enableDisableVideoMenu(True)

            Call myFormLibrary.frmVideoMiner.video_file_load()
            Me.pnlHideVideo.Visible = False

            If plyrVideoPlayer.settings.isAvailable("rate") Then
                myFormLibrary.frmVideoMiner.cmdIncreaseRate.Enabled = True
                myFormLibrary.frmVideoMiner.cmdIncreaseRate.Visible = True
                myFormLibrary.frmVideoMiner.cmdDecreaseRate.Enabled = True
                myFormLibrary.frmVideoMiner.cmdDecreaseRate.Visible = True
            Else
                If plyrVideoPlayer.Ctlcontrols.isAvailable("FastForward") Then
                    myFormLibrary.frmVideoMiner.cmdIncreaseRate.Enabled = True
                    myFormLibrary.frmVideoMiner.cmdIncreaseRate.Visible = True
                    myFormLibrary.frmVideoMiner.cmdDecreaseRate.Enabled = True
                    myFormLibrary.frmVideoMiner.cmdDecreaseRate.Visible = True
                Else
                    myFormLibrary.frmVideoMiner.cmdIncreaseRate.Enabled = False
                    myFormLibrary.frmVideoMiner.cmdIncreaseRate.Visible = False
                    myFormLibrary.frmVideoMiner.cmdDecreaseRate.Enabled = False
                    myFormLibrary.frmVideoMiner.cmdDecreaseRate.Visible = False
                End If
            End If

            myFormLibrary.frmVideoMiner.pnlVideoControls.Visible = True
            myFormLibrary.frmVideoMiner.pnlImageControls.Visible = False
        End If

            If intSeconds Mod 4 = 0 Then
                lblLoading.Text = "Loading Video "
            Else
                lblLoading.Text = lblLoading.Text & ". . "
            End If

            intSeconds += 1

            If intSeconds = 40 Then
                MessageBox.Show("Could not load the video " & strVideoFilePath & ".  The file may be corrupted or you do not have the necessary codec installed.", "Could Not Play Media", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tmrVideo.Stop()
                intSeconds = 0
                Me.Close()
            End If


    End Sub

    Private Sub tmrCurrentTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCurrentTime.Tick

        Dim dblDurationSeconds As Double = 0
        Dim dblCurrentSeconds As Double = 0
        Dim strCurrentTime As String = ""
        Dim strDurationTime As String = ""


        dblCurrentVideoTime = Me.plyrVideoPlayer.Ctlcontrols.currentPosition
        dblDurationSeconds = Me.dblDuration - dblCurrentSeconds

        'dblCurrentSeconds = plyrVideoPlayer.Ctlcontrols.currentPosition
        'dblDurationSeconds = plyrVideoPlayer.currentMedia.duration - dblCurrentSeconds

        strCurrentTime = createTimeString(dblCurrentVideoTime)
        strDurationTime = createTimeString(Me.dblDuration)


        Me.lblCurrentTime.Text = strCurrentTime
        Me.lblDuration.Text = strDurationTime
        'If dblCurrentVideoTime <> 0 Then
        '    myFormLibrary.frmVideoMiner.strPreviousClipTime = strCurrentTime
        'End If
        'Dim dblDuration As Double
        'dblDuration = Me.AxVLCPlugin21.input.Length
        'dblDuration = plyrVideoPlayer.currentMedia.duration
        Dim intValue As Integer

        intValue = Math.Round((dblCurrentVideoTime / Me.dblDuration) * 100, 0)

        'If Me.plyrVideoPlayer.playState <> WMPPlayState.wmppsPlaying And Me.plyrVideoPlayer.currentMedia.Position > 0 Then
        '    intValue = 100
        '    Me.tmrCurrentTime.Stop()
        'End If

        If intValue > 100 Then
            intValue = 100
        End If
        trkCurrentPosition.Value = intValue
        If myFormLibrary.frmVideoMiner.blUseElapsedTime Or myFormLibrary.frmVideoMiner.blUseVideoTime Then
            If Not myFormLibrary.frmSetTime Is Nothing Then
                myFormLibrary.frmSetTime.txtSetTime.Text = GetVideoTime(dblCurrentVideoTime, "")
            End If
            If dblCurrentVideoTime <> 0 Then
                myFormLibrary.frmVideoMiner.txtTime.Text = GetVideoTime(dblCurrentVideoTime, "")
                If dtUserTime.Hour = 0 And dtUserTime.Minute = 0 And dtUserTime.Second = 0 Then
                    Dim strDate() As String
                    strDate = myFormLibrary.frmVideoMiner.txtTransectDate.Text.Split("/")
                    Dim intDay As Integer
                    intDay = CInt(strDate(0))
                End If
                myFormLibrary.frmVideoMiner.txtTime.Font = New Font("", 10, FontStyle.Bold)
                myFormLibrary.frmVideoMiner.txtTime.BackColor = Color.LightGray
                myFormLibrary.frmVideoMiner.txtTime.ForeColor = Color.LimeGreen
            End If

        End If

    End Sub

    Private Sub trkCurrentPosition_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trkCurrentPosition.MouseDown

        If blIsPlaying = True Then
            'Me.plyrVideoPlayer.playlist.togglePause()
            plyrVideoPlayer.Ctlcontrols.pause()
            If myFormLibrary.frmVideoMiner.tmrRecordPerSecond.Enabled = True Then
                blRecordPerSecond = True
                myFormLibrary.frmVideoMiner.tmrRecordPerSecond.Stop()
            End If
        End If
    End Sub

    Private Sub trkCurrentPosition_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trkCurrentPosition.MouseUp
        If blIsPlaying = True Then
            'Me.plyrVideoPlayer.playlist.play()
            plyrVideoPlayer.Ctlcontrols.play()
            If blRecordPerSecond = True Then
                myFormLibrary.frmVideoMiner.tmrRecordPerSecond.Start()
                blRecordPerSecond = False
            End If
        End If
    End Sub

    Private Sub trkCurrentPosition_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkCurrentPosition.Scroll

        Dim dblValue As Double

        dblValue = Me.trkCurrentPosition.Value / 100

        dblCurrentVideoTime = dblValue * plyrVideoPlayer.currentMedia.duration
        plyrVideoPlayer.Ctlcontrols.currentPosition = dblCurrentVideoTime

        Dim dblDurationSeconds As Double = 0
        Dim dblCurrentSeconds As Double = 0
        Dim strCurrentTime As String = ""
        Dim strDurationTime As String = ""

        'dblCurrentVideoTime = dblCurrentVideoTime + dblValue
        'dblDurationSeconds = Me.dblDuration - dblCurrentVideoTime

        'dblCurrentSeconds = plyrVideoPlayer.Ctlcontrols.currentPosition
        'dblDurationSeconds = plyrVideoPlayer.currentMedia.duration - dblCurrentSeconds

        strCurrentTime = createTimeString(dblCurrentVideoTime)
        'strDurationTime = createTimeString(dblDurationSeconds)

        'Me.plyrVideoPlayer.Ctlcontrols.currentPosition = dblCurrentVideoTime
        Me.lblCurrentTime.Text = strCurrentTime
        'If dblCurrentVideoTime <> 0 Then
        '    myFormLibrary.frmVideoMiner.strPreviousClipTime = strCurrentTime
        'End If
        'Me.lblDuration.Text = strDurationTime

        'If Me.plyrVideoPlayer.input.state = 2 Then
        '    MsgBox("Buffering")
        'Else
        '    MsgBox("Playing")
        'End If

    End Sub

    'Private Sub plyrVideoPlayer_PlayStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles plyrVideoPlayer.PlayStateChange

    '    If plyrVideoPlayer.playState = WMPPlayState.wmppsStopped Then
    '        Me.tmrCurrentTime.Stop()
    '        Me.lblCurrentTime.Text = createTimeString(plyrVideoPlayer.Ctlcontrols.currentPosition)
    '        Me.lblDuration.Text = createTimeString(plyrVideoPlayer.currentMedia.duration)
    '        Me.trkCurrentPosition.Value = 0

    '        myFormLibrary.frmVideoMiner.cmdPlayPause.BackgroundImage = Image.FromFile(filePath & "\Play_Icon.png")
    '        pctVideoStatus.BackgroundImage = Image.FromFile(filePath & "\Stop_Icon_Inverse.png")
    '    End If

    'End Sub


    'Public Sub createFirstFrame()

    '    ' Create a graphics object for the live video stream and set the bitmap to be the dimensions of the picture box
    '    Dim GR As Graphics = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.CreateGraphics
    '    Dim bmpCapture As New Bitmap(myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Width, myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Height)
    '    Dim pbhdc As IntPtr = GR.GetHdc     ' Set up a handle to the graohics object
    '    Dim bmpGraphics As Graphics = Graphics.FromImage(bmpCapture)
    '    Dim bmpHdc As IntPtr = bmpGraphics.GetHdc

    '    ' Use the library to get a screen capture of the picture box area
    '    BitBlt(bmpHdc, 0, 0, Me.plyrVideoPlayer.Width, Me.plyrVideoPlayer.Height, pbhdc, 0, 0, COPY)
    '    GR.ReleaseHdc(pbhdc)
    '    bmpGraphics.ReleaseHdc(bmpHdc)

    '    Me.pctFirstFrame.Image = bmpCapture
    '    Me.pctFirstFrame.Visible = True

    'End Sub

    Private Sub plyrVideoPlayer_PlayStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles plyrVideoPlayer.PlayStateChange
        If Me.plyrVideoPlayer.playState = WMPPlayState.wmppsStopped Or Me.plyrVideoPlayer.playState = WMPPlayState.wmppsPaused Then
            If Me.tmrCurrentTime.Enabled Then
                Me.tmrCurrentTime.Stop()
                blIsPlaying = False
            End If
        End If
    End Sub
End Class