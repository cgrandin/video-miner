﻿Imports Microsoft.Win32
Imports System.TimeSpan
Imports Vlc.DotNet.Core
Imports Vlc.DotNet.Forms
Imports Vlc.DotNet.Core.Medias

Public Class frmVideoPlayer
    'Private intSeconds As Integer = 0
    Public tsDurationTime As TimeSpan = Zero
    Public tsCurrentVideoTime As TimeSpan = Zero
    Public blIsPlaying As Boolean = False
    Public blChapter As Boolean = False
    Public blRecordPerSecond As Boolean = False
    Private mbMedia As MediaBase
    'Private fmtTimeFormat As System.IFormatProvider

    Public Sub frmVideoPlayer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myFormLibrary.frmVideoPlayer = Me
        Me.Text = myFormLibrary.frmVideoMiner.FileName
        'Me.trkCurrentPosition.Value = 0
        mbMedia = New PathMedia(strVideoFilePath)
        ' Start the video and the timer on the main form
        tmrVideo.Start()
        Me.SelectNextControl(Me.SplitContainer1.Panel2, False, True, True, True)
        'fmtTimeFormat.GetFormat()
    End Sub

    Private Sub frmVideoPlayer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
            Me.tsDurationTime = Me.plyrVideoPlayer.Media.Duration
            trkCurrentPosition.Value = Me.plyrVideoPlayer.Time.TotalSeconds / Me.tsDurationTime.TotalSeconds * 100

            Dim strCurrTime As String = Me.plyrVideoPlayer.Time.ToString
            ' Remove the last four digits (too precise) from the current time from video
            strCurrTime = strCurrTime.Remove(strCurrTime.Length - 4)
            Me.lblCurrentTime.Text = strCurrTime
            Me.lblDuration.Text = Me.plyrVideoPlayer.Media.Duration.ToString

            Call myFormLibrary.frmVideoMiner.enableDisableVideoMenu(True)

            Call myFormLibrary.frmVideoMiner.video_file_load()
            Me.pnlHideVideo.Visible = False

            myFormLibrary.frmVideoMiner.pnlVideoControls.Visible = True
            myFormLibrary.frmVideoMiner.pnlImageControls.Visible = False
        Else
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
            plyrVideoPlayer.Position = Me.trkCurrentPosition.Value / 100.0
            Me.lblCurrentTime.Text = Me.plyrVideoPlayer.Time.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub plyrVideo_Ended(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plyrVideoPlayer.EndReached
        ' If the end of the video is reached, reset everything to the beginning
        'trkCurrentPosition.Value = 0.0
        'Me.lblCurrentTime.Text = Me.plyrVideoPlayer.Time.ToString
        'plyrVideoPlayer..Stop()
    End Sub

End Class