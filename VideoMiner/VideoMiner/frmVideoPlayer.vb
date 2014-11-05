Imports Microsoft.Win32
Imports System.TimeSpan
'Imports System.Windows ' For RoutedEvent
Imports Vlc.DotNet.Core
Imports Vlc.DotNet.Forms
Imports Vlc.DotNet.Core.Medias

Public Class frmVideoPlayer
    Public tsDurationTime As TimeSpan = Zero
    Public tsCurrentVideoTime As TimeSpan = Zero
    Public blIsPlaying As Boolean = False
    Public blChapter As Boolean = False
    Public blRecordPerSecond As Boolean = False
    Private mbMedia As MediaBase
    'Private fmtTimeFormat As System.IFormatProvider

    Event plyrVideo_EndedEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Event plyrVideo_EndedBroadcastEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'Public Shared ReadOnly VideoEndedEvent As RoutedEvent = EventManager.RegisterRoutedEvent("VideoEnded", RoutingStrategy.Bubble, GetType(RoutedEventHandler), GetType(Form))

    'Public Custom Event VideoEnded As RoutedEventHandler
    '    AddHandler(ByVal value As RoutedEventHandler)
    '        Me.AddHandler(VideoEndedEvent)
    '    End AddHandler

    '    RemoveHandler(ByVal value As RoutedEventHandler)
    '        Me.RemoveHandler(VideoEndedEvent, value)
    '    End RemoveHandler

    '    RaiseEvent(ByVal sender As Object, ByVal e As RoutedEventArgs)
    '        Me.RaiseEvent(e)
    '    End RaiseEvent
    'End Event

    Public Sub frmVideoPlayer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = myFormLibrary.frmVideoMiner.FileName
        mbMedia = New PathMedia(strVideoFilePath)
    End Sub

    Private Sub frmVideoPlayer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Need an event here so the parent can handle it. This way, the data in the main form will be gracefully changed.
        If MessageBox.Show("Are you sure you want to close this video?", "Close video", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Me.CausesValidation = True
            e.Cancel = True
        Else
            ' Make sure to stop video so it's not running in the background
            plyrVideoPlayer.Stop()
            myFormLibrary.frmVideoMiner.strPreviousClipTime = myFormLibrary.frmVideoMiner.txtTime.Text
            myFormLibrary.frmVideoPlayer = Nothing
            If Me.tmrVideo.Enabled = True Then
                Me.tmrVideo.Stop()
            End If
            myFormLibrary.frmVideoMiner.video_file_open = False
            myFormLibrary.frmVideoMiner.pnlVideoControls.Visible = False
            Call myFormLibrary.frmVideoMiner.enableDisableVideoMenu(False)
            Call myFormLibrary.frmVideoMiner.video_file_unload()
        End If

    End Sub

    Private Sub tmrVideo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrVideo.Tick
        If Me.plyrVideoPlayer.IsPlaying Then
            ' Check to see if the video has reached the end. If so, reset it to the beginning and stop it. If not, update the label and scrollbar
            Me.tsDurationTime = Me.plyrVideoPlayer.Media.Duration
            If Me.plyrVideoPlayer.Time.TotalSeconds >= tsDurationTime.TotalSeconds Then
                ' The video played to or past the end of the video, so raise the EndReached event
                AddHandler plyrVideo_EndedEvent, AddressOf plyrVideo_Ended
                RaiseEvent plyrVideo_EndedEvent(Nothing, Nothing)
                Exit Sub
            End If
            trkCurrentPosition.Value = Me.plyrVideoPlayer.Time.TotalSeconds / Me.tsDurationTime.TotalSeconds * 100
            Dim strCurrTime As String = Me.plyrVideoPlayer.Time.ToString()
            'Dim strCurrTime As String = strGetVideoTime(Me.plyrVideoPlayer)
            ' Remove the last N digits from the current time from video
            strCurrTime = strCurrTime.Remove(strCurrTime.Length - VIDEO_TIME_STRIP_DIGITS)
            Me.lblCurrentTime.Text = strCurrTime
            Me.lblDuration.Text = Me.plyrVideoPlayer.Media.Duration.ToString

            Call myFormLibrary.frmVideoMiner.enableDisableVideoMenu(True)

            Call myFormLibrary.frmVideoMiner.video_file_load()
            Me.pnlHideVideo.Visible = False

            myFormLibrary.frmVideoMiner.pnlVideoControls.Visible = True
            myFormLibrary.frmVideoMiner.pnlImageControls.Visible = False
        Else
            Me.lblCurrentTime.Text = VIDEO_TIME_DECIMAL_LABEL
            Me.plyrVideoPlayer.Play(mbMedia)
        End If
    End Sub

    'Private Sub trkCurrentPosition_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trkCurrentPosition.MouseDown

    '    If blIsPlaying = True Then
    '        'Me.plyrVideoPlayer.playlist.togglePause()
    '        plyrVideoPlayer.Pause()
    '        If myFormLibrary.frmVideoMiner.tmrRecordPerSecond.Enabled = True Then
    '            blRecordPerSecond = True
    '            myFormLibrary.frmVideoMiner.tmrRecordPerSecond.Stop()
    '        End If
    '    End If
    'End Sub

    'Private Sub trkCurrentPosition_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trkCurrentPosition.MouseUp
    '    If blIsPlaying = True Then
    '        'Me.plyrVideoPlayer.playlist.play()
    '        plyrVideoPlayer.Play()
    '        If blRecordPerSecond = True Then
    '            myFormLibrary.frmVideoMiner.tmrRecordPerSecond.Start()
    '            blRecordPerSecond = False
    '        End If
    '    End If
    'End Sub

    Private Sub trkCurrentPosition_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkCurrentPosition.Scroll
        Try
            ' trkCurrentPosition slider is on a scale of 0-100, and the video player's position
            ' is from 0-1 so the slider position must be divided by 100.
            Dim strCurrTime As String = Me.plyrVideoPlayer.Time.ToString
            ' Remove the last N digits from the current time from video
            strCurrTime = strCurrTime.Remove(strCurrTime.Length - VIDEO_TIME_STRIP_DIGITS)
            plyrVideoPlayer.Position = Me.trkCurrentPosition.Value / 100.0
            Me.lblCurrentTime.Text = strCurrTime
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub plyrVideo_Ended(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plyrVideoPlayer.EndReached
        'If the end of the video is reached, reset everything to the beginning
        If Me.tmrVideo.Enabled = True Then
            Me.tmrVideo.Stop()
        End If
        plyrVideoPlayer.Refresh()
        trkCurrentPosition.Value = 0.0
        Me.lblCurrentTime.Text = Me.plyrVideoPlayer.Time.ToString
        ' Need to fire an event here so that the main form knows that the video stopped and was reset, so that the data in the main form can be updated
        AddHandler plyrVideo_EndedBroadcastEvent, AddressOf myFormLibrary.frmVideoMiner.videoEnded
        RaiseEvent plyrVideo_EndedBroadcastEvent(Nothing, Nothing)
    End Sub

End Class