Imports Microsoft.Win32
Imports System.TimeSpan
Imports System.Text.RegularExpressions
Imports Vlc.DotNet.Core
Imports Vlc.DotNet.Forms
Imports Vlc.DotNet.Core.Medias

''' <summary>
''' The frmVideoPlayer class provides a form with an instance of the VLC.dotnet control, a trackbar to show the position of the video, a label for the current position,
''' a label for the duration of the video clip, and a picturebox which shows what is currently happening with the video (playing, stopped, paused).
''' </summary>
''' <remarks></remarks>
Public Class frmVideoPlayer
    ''' <summary>
    ''' Member variable to hold the video's duration or length.
    ''' </summary>
    Private m_tsDurationTime As TimeSpan
    ''' <summary>
    ''' Member variable to hold the video's current time.
    ''' </summary>
    Private m_tsCurrentVideoTime As TimeSpan
    ''' <summary>
    ''' Member variable to hold whether or not this is the first tick in the System.Timer's tick events
    ''' </summary>
    Private m_blFirstTick As Boolean
    ''' <summary>
    ''' Member variable to hold UNKNOWN
    ''' </summary>
    Private m_blChapter As Boolean
    ''' <summary>
    ''' Member variable to hold whether or not to record data every second
    ''' </summary>
    Private m_blRecordPerSecond As Boolean
    ''' <summary>
    ''' Member variable to hold whether or not the video is at the end
    ''' </summary>
    Private m_blIsEndOfVideo As Boolean
    ''' <summary>
    ''' Member variable to hold the rate the video will be played at
    ''' </summary>
    Private m_dblRate As Double
    ''' <summary>
    ''' Member variable to hold the filename
    ''' </summary>
    Private m_strFilename As String
    ''' <summary>
    ''' Member variable to hold the frames per second for the video
    ''' </summary>
    Private m_sngFPS As Single
    ''' <summary>
    ''' Member variable to hold the media (video file)
    ''' </summary>
    Private m_mbMedia As MediaBase
    ''' <summary>
    ''' Member variable to hold the transparent panel used to overlay the Vlc.DotNet control so that the user
    ''' can click on the video to toggle play/pause
    ''' </summary>
    Private WithEvents m_pnlTransparentPanel As TransparentPanel

    ''' <summary>
    ''' This property contains the position of the currently loaded video.
    ''' </summary>
    ''' <value>Between 0.0 and 1.0</value>
    ''' <returns>A number of type Single</returns>
    Public Property Position As Single
        Get
            Return plyrVideoPlayer.Position
        End Get
        Set(value As Single)
            plyrVideoPlayer.Position = value
        End Set
    End Property
    ''' <summary>
    ''' This property is readonly and contains a boolean which is True if the media state of the VLC.dotnet control is Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States.Playing
    ''' </summary>
    ''' <returns>True or False</returns>
    Public ReadOnly Property IsPlaying As Boolean
        ' The property is retreived directly from the video player's state information
        Get
            If m_mbMedia.State = Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States.Playing Then
                Return True
            End If
            Return False
        End Get
    End Property
    ''' <summary>
    ''' This property is readonly and contains a boolean which is True if the media state of the VLC.dotnet control is Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States.Stopped
    ''' </summary>
    ''' <returns>True or False</returns>
    Public ReadOnly Property IsStopped As Boolean
        ' The property is retreived directly from the video player's state information
        Get
            If m_mbMedia.State = Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States.Stopped Then
                Return True
            End If
            Return False
        End Get
    End Property
    ''' <summary>
    ''' This property is readonly and contains a boolean which is True if the media state of the VLC.dotnet control is Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States.Paused
    ''' </summary>
    ''' <returns>True or False</returns>
    Public ReadOnly Property IsPaused As Boolean
        ' The property is retreived directly from the video player's state information
        Get
            If m_mbMedia.State = Vlc.DotNet.Core.Interops.Signatures.LibVlc.Media.States.Paused Then
                Return True
            End If
            Return False
        End Get
    End Property
    ''' <summary>
    ''' This property contains a boolean which is True if the media has reached the end of the video
    ''' </summary>
    ''' <returns>True or False</returns>
    Public Property IsEndOfVideo As Boolean
        Get
            Return m_blIsEndOfVideo
        End Get
        Set(value As Boolean)
            m_blIsEndOfVideo = value
        End Set
    End Property
    ''' <summary>
    ''' This property is readonly and contains a System.Timespan object which represents the time at the current position of the video
    ''' </summary>
    ''' <returns>System.Timespan</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentVideoTime As TimeSpan
        Get
            Return m_tsCurrentVideoTime
        End Get
    End Property
    ''' <summary>
    ''' This property is readonly and contains a number of type 'Single' which represents the Frames per Second for the video.
    ''' </summary>
    ''' <returns>Single number</returns>
    ''' <remarks> Note this almost always returns 0 so it's use is limited</remarks>
    Public ReadOnly Property FPS As Single
        Get
            Return m_sngFPS
        End Get
    End Property
    ''' <summary>
    ''' This property contains a number of type 'Double' which represents the play rate for the video.
    ''' For normal playback this will be 1.0. For double spped, it will be 2.0
    ''' </summary>
    ''' <value>Double number greater or equal to 0.0</value>
    ''' <returns>Double number</returns>
    ''' <remarks></remarks>
    Public Property Rate As Double
        Get
            Return m_dblRate
        End Get
        Set(value As Double)
            m_dblRate = value
        End Set
    End Property
    ''' <summary>
    ''' This property contains a 'String' which represents the filename for the video.
    ''' </summary>
    ''' <returns>String</returns>
    Public Property Filename As String
        Get
            Return m_strFilename
        End Get
        Set(value As String)
            m_strFilename = value
        End Set
    End Property

    ''' <summary>
    ''' This event is triggered when the user pauses the video from within the fmrVideoPlayer form.
    ''' It is handled by myFormLibrary.frmVideoMiner.playerPaused.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Event PauseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' This event is triggered when the user plays the video from within the fmrVideoPlayer form.
    ''' It is handled by myFormLibrary.frmVideoMiner.playerPlaying.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Event PlayEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' This event is triggered when the user stops the video from within the fmrVideoPlayer form.
    ''' It is handled by myFormLibrary.frmVideoMiner.playerStopped.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Event StopEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' This event is triggered when the video has ended.
    ''' It is handled by plyrVideo_Ended.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Event EndedEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' This event is triggered when the video has ended.
    ''' It is handled by myFormLibrary.frmVideoMiner.videoEnded
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Event EndedBroadcastEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' This event is triggered when the frmVideoPlayer form is closed by clicking the 'X' top right of the window.
    ''' It is handled by myFormLibrary.frmVideoMiner.playerClosing
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Event ClosingEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ''' <summary>
    ''' Loads the fmrVideoPlayer form. All member variables are initialized, and the video file is opened as a new Vlc.DotNet.Core.Medias.PathMedia object.
    ''' A System.Timer is started to generate update events every 500ms.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Public Sub frmVideoPlayer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = m_strFilename
        m_tsDurationTime = Zero
        m_tsCurrentVideoTime = Zero
        m_blFirstTick = True
        m_blChapter = False
        m_blRecordPerSecond = False
        m_blIsEndOfVideo = False
        m_dblRate = 1.0
        Try
            m_mbMedia = New PathMedia(strVideoFilePath)
        Catch ex As Exception
            m_mbMedia = Nothing
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
        tmrVideo.Start()
    End Sub

    ''' <summary>
    ''' Unloads the frmVideoPLayer form. The player and timer are stopped and the ClosingEvent is fired
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.Windows.Forms.FormClosingEventArgs</param>
    Private Sub frmVideoPlayer_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If MessageBox.Show("Are you sure you want to close this video?", "Close video", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        ' Me.CausesValidation = True
        ' e.Cancel = True
        'Else
        ' Make sure to stop video so it's not running in the background
        plyrVideoPlayer.Stop()
        'myFormLibrary.frmVideoMiner.strPreviousClipTime = myFormLibrary.frmVideoMiner.txtTime.Text
        tmrVideo.Stop()
        AddHandler ClosingEvent, AddressOf myFormLibrary.frmVideoMiner.playerClosing
        RaiseEvent ClosingEvent(Nothing, Nothing)
        'End If
    End Sub

    ''' <summary>
    ''' Plays the video and change the picturebox icon to reflect this. Fires the PlayEvent.
    ''' </summary>
    ''' <returns>True or False for success. False is returned if the media was not loaded correctly or an exception was thrown</returns>
    ''' <remarks>If IsEndOfVideo is True and either IsStopped or IsPaused is True, 
    ''' that means that the player is at the end and the play request will attempt to reset the player to the beginning</remarks>
    Public Function playVideo() As Boolean
        If IsNothing(m_mbMedia) Or m_dblRate <= 0 Then
            Return False
        End If
        Try
            If IsPaused Or IsStopped Then
                If m_blIsEndOfVideo Then
                    ' It's sitting at the end of the video, so reset everything by calling stop, then play again
                    stopVideo()
                    plyrVideoPlayer.Play()
                Else
                    ' It's stopped or paused, but not at the end of the video, so just continue playing
                    plyrVideoPlayer.Play()
                End If
            Else
                ' It's not paused and not stopped, probably just loaded. Start from the beginning by calling play(mbMedia)
                plyrVideoPlayer.Play(m_mbMedia)
            End If
            plyrVideoPlayer.Rate = Rate
            m_sngFPS = plyrVideoPlayer.FPS
            pctVideoStatus.BackgroundImage = My.Resources.Play_Icon_Inverse
            AddHandler PlayEvent, AddressOf myFormLibrary.frmVideoMiner.playerPlaying
            RaiseEvent PlayEvent(Nothing, Nothing)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Pause the video and change the picturebox icon to reflect this. Fires the PauseEvent.
    ''' </summary>
    ''' <returns>True or False for success. Only returns False if an exception is thrown</returns>
    Public Function pauseVideo() As Boolean
        Try
            If IsPlaying Then
                plyrVideoPlayer.Pause()
                pctVideoStatus.BackgroundImage = My.Resources.Pause_Icon_Inverse
                AddHandler PauseEvent, AddressOf myFormLibrary.frmVideoMiner.playerPaused
                RaiseEvent PauseEvent(Nothing, Nothing)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Stop the video and change the picturebox icon to reflect this. Fires the StopEvent.
    ''' </summary>
    ''' <returns>True or False for success. Only returns False if an exception is thrown</returns>
    Public Function stopVideo() As Boolean
        Try
            'Don't put a statement like 'If IsPlaying Or IsPaused Then' here because some videos don't stop correctly at the end,
            ' i.e. they never quite reach their duration... (older vids)
            plyrVideoPlayer.Stop()
            pctVideoStatus.BackgroundImage = My.Resources.Stop_Icon_Inverse
            trkCurrentPosition.Value = 0
            lblCurrentTime.Text = VIDEO_TIME_DECIMAL_LABEL
            IsEndOfVideo = False
            AddHandler StopEvent, AddressOf myFormLibrary.frmVideoMiner.playerStopped
            RaiseEvent StopEvent(Nothing, Nothing)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Handles the System.timer tick event. If it is the first one, set up the duration label (the duration cannot be read until the video has started playing).
    ''' If the video has reached it's duration, fire EndedEvent. At all other times, update the label for the current time that the video has reached.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    ''' <remarks>On the first tick, adds a transparent panel to allow user clicks on the video, since the Vlc.DotNet control does not allow it.</remarks>
    Private Sub tmrVideo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrVideo.Tick
        Dim tsMediaTime As TimeSpan
        If IsPlaying Then
            If m_blFirstTick Then
                m_tsDurationTime = plyrVideoPlayer.Media.Duration
                lblDuration.Text = String.Format(VIDEO_TIME_FORMAT, m_tsDurationTime.Hours, m_tsDurationTime.Minutes, m_tsDurationTime.Seconds, m_tsDurationTime.Milliseconds)
                ' Add transparent panel to grab mouse events when user clicks video directly
                m_pnlTransparentPanel = New TransparentPanel
                plyrVideoPlayer.Controls.Add(m_pnlTransparentPanel)
                m_pnlTransparentPanel.Dock = System.Windows.Forms.DockStyle.Fill
                ' Make the video loading screen invisible
                pnlHideVideo.Visible = False
                m_blFirstTick = False
            End If
            ' Check to see if the video has reached the end.
            If plyrVideoPlayer.Time.Ticks >= m_tsDurationTime.Ticks Then
                ' The video played to or past the end of the video, so raise the EndReached event
                AddHandler EndedEvent, AddressOf plyrVideo_Ended
                RaiseEvent EndedEvent(Nothing, Nothing)
                Exit Sub
            End If
            ' Some videos do not reach the duration value, so we need a way to raise the event at the end of the video
            trkCurrentPosition.Value = plyrVideoPlayer.Time.Ticks / m_tsDurationTime.Ticks * 100.0
            tsMediaTime = plyrVideoPlayer.Time
            lblCurrentTime.Text = String.Format(VIDEO_TIME_FORMAT, tsMediaTime.Hours, tsMediaTime.Minutes, tsMediaTime.Seconds, tsMediaTime.Milliseconds)
            ' The following two lines are old calls from before I added VLC control back in -- Chris Grandin Nov 12, 2014
            'Call myFormLibrary.frmVideoMiner.enableDisableVideoMenu(True)
            'Call myFormLibrary.frmVideoMiner.video_file_load()
        ElseIf IsStopped Then
            lblCurrentTime.Text = VIDEO_TIME_DECIMAL_LABEL
        ElseIf IsPaused Then
            ' Do nothing
        End If
    End Sub

    ''' <summary>
    ''' Get the current time from the Position property and the duration of the video.
    ''' </summary>
    ''' <returns>A new System.Timespan object</returns>
    ''' <remarks>Multiplies the current position (which is between 0 and 1) by the duration of the video and
    ''' converts that to a Timespan object.</remarks>
    Private Function getCurrentTime() As TimeSpan
        Dim ms As Double = Position * m_tsDurationTime.TotalMilliseconds
        Return New TimeSpan(0, 0, 0, 0, ms)
    End Function

    ''' <summary>
    ''' This mouse handler handles both MouseDown and MouseMove Events for the trackbar. If you press on the trackbar and move it,
    ''' the video will pause,then seek to that spot and remain paused.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.Windows.Forms.MouseEventArgs</param>
    Private Sub trkCurrentPosition_MovePointer(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trkCurrentPosition.MouseDown, trkCurrentPosition.MouseMove
        Dim dblValue As Double
        Dim tsMediaTime As TimeSpan
        'Make sure the left button is pressed
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' Pause the video to start from a stable place
            pauseVideo()
            ' Move the trackbar indicator to where the mouse pointer is
            dblValue = (Convert.ToDouble(e.X) / Convert.ToDouble(trkCurrentPosition.Width)) * (trkCurrentPosition.Maximum - trkCurrentPosition.Minimum)
            If dblValue > 100.0 Then dblValue = 100.0 ' Sometimes the track can go past 100%
            If dblValue < 0.0 Then dblValue = 0.0 ' Sometimes the track can go negative
            trkCurrentPosition.Value = Convert.ToInt32(dblValue)
            plyrVideoPlayer.Position = trkCurrentPosition.Value / 100.0
            ' There is a problem with the vlc control. You cannot get the time after setting the position. You need to do a play() and pause() which causes
            ' other issues, including returning zero times much of the time. The alternative is to simply multiply the duration by the trackbar location, which is
            ' between 0 and 1, and set the time to that proportion. Not exact, but it makes it nicer and more user-friendly.
            'tsMediaTime = plyrVideoPlayer.Time ' This is the trouble line, plyrVideoPlayer.Time returns 00:00:00.00 after the position has been changed.
            plyrVideoPlayer.Refresh()
            tsMediaTime = getCurrentTime()
            lblCurrentTime.Text = String.Format(VIDEO_TIME_FORMAT, tsMediaTime.Hours, tsMediaTime.Minutes, tsMediaTime.Seconds, tsMediaTime.Milliseconds)
            lblCurrentTime.Refresh()
        End If
        'If myFormLibrary.frmVideoMiner.tmrRecordPerSecond.Enabled = True Then
        ' blRecordPerSecond = True
        ' myFormLibrary.frmVideoMiner.tmrRecordPerSecond.Stop()
        'End If
    End Sub

    ''' <summary>
    ''' The trackbar MouseUp event just pauses the video.
    ''' This is here to ensure the video remains paused after seeking with the trackbar
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.Windows.Forms.MouseEventArgs</param>
    Private Sub trkCurrentPosition_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trkCurrentPosition.MouseUp
        pauseVideo()
    End Sub

    ''' <summary>
    ''' This handles the user clicking on the video by using a transparent panel overlaid on the video.
    ''' The video will toggle between paused and playing. 
    ''' The Vlc.DotNet control does not capture MouseClick Events on its own so the transparent panel was needed.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.Windows.Forms.MouseEventArgs</param>
    ''' <remarks>If the user clicks the right mouse button, a simple help dialog will pop up</remarks>
    Private Sub m_pnlTransparentPanel_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_pnlTransparentPanel.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If IsPlaying Then
                pauseVideo()
            ElseIf IsPaused Or IsStopped Then
                playVideo()
            End If
        End If
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim cms As ContextMenuStrip = New ContextMenuStrip
            Dim item1 As ToolStripItem
            item1 = cms.Items.Add("Click for help")
            item1.Tag = 1
            AddHandler item1.Click, AddressOf videoContextMenuChoice
            cms.Show(m_pnlTransparentPanel, e.Location)
        End If
    End Sub

    ''' <summary>
    ''' This is the help dialog that appears when the user clicks the right mouse button in the video window.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Private Sub videoContextMenuChoice(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim item = CType(sender, ToolStripMenuItem)
        '    Dim selection = CInt(item.Tag)
        pauseVideo()
        MessageBox.Show("The Videominer player window contains the video you loaded with a trackbar for seeking and an icon showing you the current state of the video (playing, paused, stopped). You can left-click the video to toggle between playing and paused. To close the video simply click the 'X' on the top right of the player window.", _
                        "Videominer Player Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' This handles the Event 'EndReached' fired by the Vlc.DotNet control.
    ''' It will pause the video, change the current time label to equal the duration label, set the trackbar to position=1,
    '''  and then fire the EndedBroadcastEvent
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Private Sub plyrVideo_Ended(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plyrVideoPlayer.EndReached
        IsEndOfVideo = True
        ' Pause and set the label to be the duration and the trackbar to the end (the trackbar can be off by a bit).
        pauseVideo()
        lblCurrentTime.Text = lblDuration.Text
        lblCurrentTime.Refresh()
        trkCurrentPosition.Value = 100.0
        AddHandler EndedBroadcastEvent, AddressOf myFormLibrary.frmVideoMiner.videoEnded
        RaiseEvent EndedBroadcastEvent(Nothing, Nothing)
    End Sub

End Class