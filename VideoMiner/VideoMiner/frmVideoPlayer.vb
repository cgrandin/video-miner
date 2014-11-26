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
    ''' Default format for the time labels
    ''' </summary>
    ''' <remarks></remarks>
    Private Shadows Const VIDEO_TIME_FORMAT As String = "{0:D2}:{1:D2}:{2:D2}.{3:D4}" ' D4 = 4 decimal places
    ''' <summary>
    ''' Default number of frames to skip when incrementally stepping through the frames
    ''' </summary>
    ''' <remarks></remarks>
    Private Const FRAMES_TO_SKIP As Integer = 1000
    ''' <summary>
    ''' Member variable to hold the time format to show on the video labels and in CurrentVideoTimeFormatted property
    ''' </summary>
    Private m_strVideoTimeFormat As String
    ''' <summary>
    ''' Member variable to hold the video's duration or length.
    ''' </summary>
    Private m_tsDurationTime As TimeSpan
    ''' <summary>
    ''' Member variable to hold the video's current ti
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
    ''' The number of frames to skip when incrementally stepping forward through frames
    ''' </summary>
    Private m_intFramesToSkip As Integer
    ''' <summary>
    ''' Member variable to hold the transparent panel used to overlay the Vlc.DotNet control so that the user
    ''' can click on the video to toggle play/pause
    ''' </summary>
    Private WithEvents m_pnlTransparentPanel As TransparentPanel

    ''' <summary>
    ''' Default constructor. The label time format will be the default. Current time and Duration are set to zero.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New(strFilename As String, Optional intFramesToSkip As Integer = FRAMES_TO_SKIP)
        InitializeComponent()
        m_strFilename = strFilename
        m_strVideoTimeFormat = VIDEO_TIME_FORMAT
        m_tsCurrentVideoTime = Zero
        m_tsDurationTime = Zero
        m_intFramesToSkip = intFramesToSkip
    End Sub

    ''' <summary>
    ''' Constructor with custom time format string. Should look something like this: "{0:D2}:{1:D2}:{2:D2}.{3:D2}"
    ''' Current time and Duration are set to zero.
    ''' </summary>
    ''' <param name="videoTimeFormat"></param>
    ''' <remarks></remarks>
    Sub New(strFilename As String, ByVal videoTimeFormat As String, Optional intFramesToSkip As Integer = FRAMES_TO_SKIP)
        InitializeComponent()
        m_strFilename = strFilename
        m_strVideoTimeFormat = videoTimeFormat
        m_tsCurrentVideoTime = Zero
        m_tsDurationTime = Zero
        m_intFramesToSkip = intFramesToSkip
    End Sub

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
    ''' This property is readonly and returns a formatted string representing the time at the current position of the video.
    ''' The formatting string is defined in the constructor (either default or custom).
    ''' </summary>
    ''' <returns>System.Timespan</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentVideoTimeFormatted As String
        Get
            Return getFormattedCurrentVideoTimeString()
        End Get
    End Property
    ''' <summary>
    ''' This property is readonly and returns a System.Timespan object representing the time at the current position of the video.
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
            plyrVideoPlayer.Rate = value
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
    ''' This event is triggered when the user pauses the video from within this form.
    ''' </summary>
    Event PauseEvent()
    ''' <summary>
    ''' This event is triggered when the user plays the video from within this form.
    ''' </summary>
    Event PlayEvent()
    ''' <summary>
    ''' This event is triggered when the user stops the video from within this
    ''' </summary>
    Event StopEvent()
    ''' <summary>
    ''' This event is triggered when the video has ended.
    ''' </summary>
    Event VideoEndedEvent()
    ''' <summary>
    ''' This event is triggered when the frmVideoPlayer form is closed by clicking the 'X' top right of the window.
    ''' </summary>
    Event ClosingEvent()
    ''' <summary>
    ''' This event is triggered when the timer ticks. It is used to send a signal so that
    ''' the parent will always have access to the correct data (current time) from the video.
    ''' </summary>
    Event TimerTickEvent()
    ''' <summary>
    ''' If the Right arrow key is pressed inside this form, this event will be raised
    ''' </summary>
    ''' <remarks></remarks>
    Event RightArrowPressedEvent()

    ''' <summary>
    ''' Loads the fmrVideoPlayer form. All member variables are initialized, and the video file is opened as a new Vlc.DotNet.Core.Medias.PathMedia object.
    ''' A System.Timer is started to generate update events every 500ms.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Public Sub frmVideoPlayer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' So that the form receives the key events before the child controls
        KeyPreview = True
        Text = m_strFilename
        m_tsDurationTime = Zero
        m_tsCurrentVideoTime = Zero
        m_blFirstTick = True
        m_blChapter = False
        m_blRecordPerSecond = False
        m_blIsEndOfVideo = False
        m_dblRate = 1.0
        Try
            m_mbMedia = New PathMedia(m_strFilename)
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
        ' CausesValidation = True
        ' e.Cancel = True
        'Else
        ' Make sure to stop video so it's not running in the background
        plyrVideoPlayer.Stop()
        'myFormLibrary.frmVideoMiner.strPreviousClipTime = myFormLibrary.frmVideoMiner.txtTime.Text
        tmrVideo.Stop()
        RaiseEvent ClosingEvent()
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
            RaiseEvent PlayEvent()
        Catch ex As Exception
            MessageBox.Show("Error in Vlc.DotNet while calling Play(" & m_strFilename & ") - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                RaiseEvent PauseEvent()
            Else
                pctVideoStatus.BackgroundImage = My.Resources.Pause_Icon_Inverse
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
            m_tsCurrentVideoTime = Zero
            lblCurrentTime.Text = getFormattedCurrentVideoTimeString()
            IsEndOfVideo = False
            RaiseEvent StopEvent()
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
        If IsPlaying Then
            If m_blFirstTick Then
                m_tsDurationTime = plyrVideoPlayer.Media.Duration
                lblDuration.Text = getFormattedDurationString()
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
                ' The video played to or past the end of the video
                endOfVideo()
                Exit Sub
            End If
            trkCurrentPosition.Value = plyrVideoPlayer.Time.Ticks / m_tsDurationTime.Ticks * 100.0
            m_tsCurrentVideoTime = plyrVideoPlayer.Time
            lblCurrentTime.Text = getFormattedCurrentVideoTimeString()
            RaiseEvent TimerTickEvent()
        End If
    End Sub

    ''' <summary>
    ''' Step forward a number of frames in the video and adjust player controls accordingly
    ''' </summary>
    ''' <param name="intFramesToSkip">Number of frames to skip, typically between 50 and 1000</param>
    ''' <returns>Boolean if the stepping succeeded</returns>
    ''' <remarks>This is highly dependent on the Vlc.DotNet control and can be buggy depending on the filetype</remarks>
    Public Function stepForward(intFramesToSkip) As Boolean
        m_intFramesToSkip = intFramesToSkip
        pauseVideo()
        If IsStopped Then Return False
        For i As Integer = 0 To m_intFramesToSkip
            plyrVideoPlayer.NextFrame()
            plyrVideoPlayer.Refresh()
            m_tsCurrentVideoTime = getCurrentTime()
            lblCurrentTime.Text = getFormattedCurrentVideoTimeString()
            ' Don't try to update the trackbar, it won't work after using the NextFrame method of Vlc.DotNet
            RaiseEvent TimerTickEvent()
        Next
        Return True
    End Function

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
        'Dim tsMediaTime As TimeSpan
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
            'tsMediaTime = getCurrentTime()
            m_tsCurrentVideoTime = getCurrentTime()
            lblCurrentTime.Text = getFormattedCurrentVideoTimeString()
            'lblCurrentTime.Text = String.Format(VIDEO_TIME_FORMAT, tsMediaTime.Hours, tsMediaTime.Minutes, tsMediaTime.Seconds, tsMediaTime.Milliseconds)
            'lblCurrentTime.Refresh()
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
        plyrVideoPlayer.Position = trkCurrentPosition.Value / 100.0
        plyrVideoPlayer.Refresh()
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
    ''' </summary>
    Private Sub plyrVideo_Ended() Handles plyrVideoPlayer.EndReached
        endOfVideo()
    End Sub

    ''' <summary>
    ''' The end of the video has been reached. Do some updating on the form and raise the VideoEnded event.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub endOfVideo()
        IsEndOfVideo = True
        ' Pause and set the label to be the duration and the trackbar to the end (the trackbar can be off by a bit).
        ' This is for cosmetic reasons, as the video is no longer playing
        pauseVideo()
        m_tsCurrentVideoTime = m_tsDurationTime
        lblCurrentTime.Text = lblDuration.Text
        lblCurrentTime.Refresh()
        trkCurrentPosition.Value = 100.0
        RaiseEvent VideoEndedEvent()
    End Sub

    ''' <summary>
    ''' Returns a formatted string for the current video time
    ''' </summary>
    ''' <returns>A formatted string or an unformatted string if an exception was thrown</returns>
    ''' <remarks></remarks>
    Private Function getFormattedCurrentVideoTimeString() As String
        Try
            Return String.Format(m_strVideoTimeFormat, m_tsCurrentVideoTime.Hours, m_tsCurrentVideoTime.Minutes, m_tsCurrentVideoTime.Seconds, m_tsCurrentVideoTime.Milliseconds)
        Catch ex As Exception
            Return m_tsCurrentVideoTime.ToString()
        End Try
    End Function

    ''' <summary>
    ''' Returns a formatted string for the duration video time
    ''' </summary>
    ''' <returns>A formatted string or an unformatted string if an exception was thrown</returns>
    ''' <remarks></remarks>
    Private Function getFormattedDurationString() As String
        Try
            Return String.Format(m_strVideoTimeFormat, m_tsDurationTime.Hours, m_tsDurationTime.Minutes, m_tsDurationTime.Seconds, m_tsDurationTime.Milliseconds)
        Catch ex As Exception
            Return m_tsDurationTime.ToString()
        End Try
    End Function

    ''' <summary>
    ''' Handles the case when extra decimal points are being shown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Works in tandem with lblDuration_Resize(sender As System.Object, e As System.EventArgs) Handles lblDuration.Resize</remarks>
    Private Sub lblDuration_TextChanged(sender As System.Object, e As System.EventArgs) Handles lblDuration.TextChanged
        lblDuration.Tag = lblDuration.Size
    End Sub

    ''' <summary>
    ''' When the duration label automatically resizes due to extra decimal points being shown,
    ''' this will make it grow left so that it remains looking good.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Works in tandem with lblDuration_TextChanged(sender As System.Object, e As System.EventArgs) Handles lblDuration.TextChanged</remarks>
    Private Sub lblDuration_Resize(sender As System.Object, e As System.EventArgs) Handles lblDuration.Resize
        Dim TempSize As New Size(New System.Drawing.Point(0))
        If lblDuration.Tag Is Nothing Then lblDuration.Tag = lblDuration.Size
        TempSize = DirectCast(lblDuration.Tag, Size)
        lblDuration.Location = New System.Drawing.Point(lblDuration.Location.X - (lblDuration.Size.Width - TempSize.Width), lblDuration.Location.Y)
    End Sub

    ''' <summary>
    ''' Required to override the default behaviour of the arrow keypresses in the form
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="keyData"></param>
    ''' <returns>True if the right arrow was pressed</returns>
    ''' <remarks>Raises the RightArrowPressedEvent</remarks>
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Right
                RaiseEvent RightArrowPressedEvent()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


End Class