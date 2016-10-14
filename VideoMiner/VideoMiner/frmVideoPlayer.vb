Imports System.TimeSpan
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Path

''' <summary>
''' The frmVideoPlayer class provides a form with an instance of the axWindowsMediaPlayer cvontrol,
''' a trackbar to show the position of th   e video, a label for the current position,
''' a label for the duration of the video clip, and a picturebox which shows what is currently
''' happening with the video (playing, stopped, paused).
''' </summary>
Public Class frmVideoPlayer
    ''' <summary>
    ''' The currently playing media file
    ''' </summary>
    Private m_currentMedia As WMPLib.IWMPMedia
    ''' <summary>
    ''' Default format for the time labels
    ''' Format is Hours:Minutes:Seconds.DecimalPartOfSeconds
    ''' D4 = 4 decimal places for that item
    ''' </summary>
    ''' <remarks></remarks>
    Private Shadows Const VIDEO_TIME_FORMAT As String = "{0:D2}:{1:D2}:{2:D2}.{3:D4}"
    ''' <summary>
    ''' Default number of frames to skip when incrementally stepping through the frames
    ''' </summary>
    ''' <remarks></remarks>
    Private Const FRAMES_TO_SKIP As Integer = 1000
    ''' <summary>
    ''' Member variable to hold the time format to show on the video labels and in
    ''' CurrentVideoTimeFormatted property
    ''' </summary>
    Private m_strVideoTimeFormat As String
    ''' <summary>
    ''' Member variable to hold the video's duration or length.
    ''' </summary>
    Private m_tsDurationTime As TimeSpan
    ''' <summary>
    ''' Member variable to hold the video's current time
    ''' </summary>
    Private m_tsCurrentVideoTime As TimeSpan
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
    ''' The number of frames to skip when incrementally stepping forward through frames
    ''' </summary>
    Private m_intFramesToSkip As Integer
    ''' <summary>
    ''' Member variable to hold the transparent panel used to overlay the Vlc.DotNet control so that the user
    ''' can click on the video to toggle play/pause
    ''' </summary>
    Private WithEvents m_pnlTransparentPanel As TransparentPanel

    ''' <summary>
    ''' This property contains the position of the currently loaded video.
    ''' </summary>
    ''' <value>Seconds from the beginning of the video</value>
    ''' <returns>A number of type Double</returns>
    Public Property Position As Double
        Get
            Return plyrVideoPlayer.Ctlcontrols.currentPosition
        End Get
        Set(value As Double)
            plyrVideoPlayer.Ctlcontrols.currentPosition = value
        End Set
    End Property
    ''' <summary>
    ''' This property is readonly and contains a boolean which is True if
    ''' the video is currently playing and False otherwise.
    ''' </summary>
    ''' <returns>True or False</returns>
    Public ReadOnly Property IsPlaying As Boolean
        ' The property is retreived directly from the video player's state information
        Get
            Return plyrVideoPlayer.playState = WMPLib.WMPPlayState.wmppsPlaying
        End Get
    End Property
    ''' <summary>
    ''' This property is readonly and contains a boolean which is True if
    ''' the video is currently stopped and False otherwise.
    ''' </summary>
    ''' <returns>True or False</returns>
    Public ReadOnly Property IsStopped As Boolean
        Get
            Return plyrVideoPlayer.playState = WMPLib.WMPPlayState.wmppsStopped
        End Get
    End Property
    ''' <summary>
    ''' This property is readonly and contains a boolean which is True if
    ''' the video is currently paused and False otherwise.
    ''' </summary>
    ''' <returns>True or False</returns>
    Public ReadOnly Property IsPaused As Boolean
        ' The property is retreived directly from the video player's state information
        Get
            Return plyrVideoPlayer.playState = WMPLib.WMPPlayState.wmppsPaused
        End Get
    End Property
    ''' <summary>
    ''' This property contains a boolean which is True if the video has reached its end.
    ''' </summary>
    ''' <returns>True or False</returns>
    Public ReadOnly Property IsEndOfVideo As Boolean
        Get
            Return plyrVideoPlayer.playState = WMPLib.WMPPlayState.wmppsMediaEnded
        End Get
    End Property
    ''' <summary>
    ''' This property is readonly and returns a formatted string representing the time at the current
    ''' position of the video. The formatting string is defined in the constructor (either default or custom).
    ''' </summary>
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
    ''' <remarks> Note this almost always returns 0 so its use is limited</remarks>
    Public ReadOnly Property FPS As Single
        Get
            Return m_sngFPS
        End Get
    End Property
    ''' <summary>
    ''' This property contains a number of type 'Double' which represents the play rate for the video.
    ''' For normal playback this will be 1.0. For double speed, it will be 2.0
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
            plyrVideoPlayer.settings.rate = value
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
    ''' This event is triggered when the user stops the video from within this form.
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
    ''' If the F10 key is pressed inside this form, this event will be raised to signal that
    ''' we want to take a screen grab.
    ''' </summary>
    Event CaptureScreenEvent()

    ''' <summary>
    ''' Default constructor. The label time format will be the default. Current time and Duration are set to zero.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New(strFilename As String, Optional intFramesToSkip As Integer = FRAMES_TO_SKIP)
        InitializeComponent()
        'plyrVideoPlayer.uiMode = "none"
        'plyrVideoPlayer.windowlessVideo = True
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
        'plyrVideoPlayer.uiMode = "none"
        'plyrVideoPlayer.windowlessVideo = True
        m_strFilename = strFilename
        m_strVideoTimeFormat = videoTimeFormat
        m_tsCurrentVideoTime = Zero
        m_tsDurationTime = Zero
        m_intFramesToSkip = intFramesToSkip
        ' Add transparent panel to grab mouse events when user clicks video directly
        m_pnlTransparentPanel = New TransparentPanel
        plyrVideoPlayer.Controls.Add(m_pnlTransparentPanel)
        m_pnlTransparentPanel.Dock = System.Windows.Forms.DockStyle.Fill
    End Sub

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
        m_blRecordPerSecond = False
        m_blIsEndOfVideo = False
        m_dblRate = 1.0
        Try
            m_currentMedia = plyrVideoPlayer.newMedia(m_strFilename)
            plyrVideoPlayer.currentMedia = m_currentMedia
        Catch ex As Exception
            plyrVideoPlayer = Nothing
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
        tmrVideo.Start()
    End Sub

    ''' <summary>
    ''' Get the current codec being run in the video window
    ''' </summary>
    ''' <param name="format">The image format on the current video</param>
    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()
        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing
    End Function

    ''' <summary>
    ''' Convert a Bitmap to a different type
    ''' </summary>
    ''' <param name="BMPFullPath">The full path of the bitmap file</param>
    ''' <param name="imgFormat">The format of the image captured from the video</param>
    Private Function ConvertBMP(ByVal BMPFullPath As String, ByVal imgFormat As ImageFormat) As Boolean
        Dim bAns As Boolean = False
        Dim strNewFileName As String
        Dim strNewFilePath As String
        Dim strNewFile As String = String.Empty
        'Try
        Using bmp1 As New Bitmap(BMPFullPath)
            'Dim jgpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
            Dim encoder As ImageCodecInfo = GetEncoder(imgFormat)
            ' Create an Encoder object based on the GUID 
            ' for the Quality parameter category. 
            Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
            ' Create an EncoderParameters object. 
            ' An EncoderParameters object is an array of EncoderParameter 
            ' objects. In this case, there is only one 
            ' EncoderParameter object in the array. 
            Dim myEncoderParameters As New EncoderParameters(1)
            ' 100 is the quality of jpeg from 0-100. 0 for worst, 100 for best.
            Dim myEncoderParameter As New EncoderParameter(myEncoder, 100&)
            myEncoderParameters.Param(0) = myEncoderParameter
            strNewFilePath = GetDirectoryName(BMPFullPath)
            strNewFileName = GetFileNameWithoutExtension(BMPFullPath)
            If imgFormat.Equals(ImageFormat.Jpeg) Then
                strNewFile = Combine(strNewFilePath, strNewFileName & ".jpg")
            End If
            If strNewFile <> String.Empty Then
                bmp1.Save(strNewFile, encoder, myEncoderParameters)
                bAns = True
            End If
        End Using
        Return bAns
    End Function

    ''' <summary>
    ''' Takes a frame grab of the current frame in the video player's window.
    ''' A Save Dialog will be opened and the user can choose where to save the file.
    ''' The controls of the windows media player will appear in the image unless the shot is taken
    ''' when the player is in full screen mode.
    ''' </summary>
    Public Function captureScreen(ByVal strDate As String, ByVal strTime As String, ByVal strDefaultFilename As String) As String
        pauseVideo()
        Dim bitmap As New Bitmap(plyrVideoPlayer.Width, plyrVideoPlayer.Height)
        Dim g As Graphics = Graphics.FromImage(bitmap)
        Dim gg As Graphics = plyrVideoPlayer.CreateGraphics()
        gg.SmoothingMode = Drawing2D.SmoothingMode.HighQuality And Drawing2D.SmoothingMode.AntiAlias
        Me.BringToFront()
        g.CopyFromScreen(plyrVideoPlayer.PointToScreen(New System.Drawing.Point()).X,
                         plyrVideoPlayer.PointToScreen(New System.Drawing.Point()).Y,
                         0,
                         0,
                         New System.Drawing.Size(plyrVideoPlayer.Width, plyrVideoPlayer.Height))
        Dim svDlgFileDialogScrCap As New System.Windows.Forms.SaveFileDialog
        svDlgFileDialogScrCap.Filter = "Joint Photographic Experts Group (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp"
        ' For some internal GDI+ reason, the other conversions don't work. Only BMP->JPG works.
        'svDlgFileDialogScrCap.Filter = "Joint Photographic Experts Group (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|Portable Network Graphics (*.png)|*.png|Tagged Image File Format (*.tiff)|*.tiff"
        svDlgFileDialogScrCap.Title = "Save Screen Capture as..."

        svDlgFileDialogScrCap.FileName = strDefaultFilename
        ' Open a save as dialog to specify the path and name for the bitmap.
        If svDlgFileDialogScrCap.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Return String.Empty
        End If
        Dim strFilename As String = svDlgFileDialogScrCap.FileName.ToString()
        Dim baseFilename As String = Combine(GetDirectoryName(strFilename), GetFileNameWithoutExtension(strFilename))
        Dim bmpFilename As String = baseFilename & ".bmp"

        Using ms As New MemoryStream
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
            Dim ret As Image = Image.FromStream(ms)
            ret.Save(bmpFilename)
        End Using
        If svDlgFileDialogScrCap.FilterIndex = 1 Then
            If ConvertBMP(bmpFilename, ImageFormat.Jpeg) Then
                File.Delete(bmpFilename)
            Else
                MessageBox.Show("There was a problem in the conversion routine. The file is a BMP instead.")
            End If
        End If
        Return strFilename
    End Function

    Private Sub frmVideoPlayer_Keydown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            ' Must raise event to VideoMiner main form, because it has the transect information
            ' and must record the data in the database.
            RaiseEvent CaptureScreenEvent()
        End If
    End Sub

    Private Sub frmVideoPlayer_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles plyrVideoPlayer.Resize
    End Sub

    ''' <summary>
    ''' If user pressed the maimize button, set the player to fullscreen mode
    ''' </summary>
    Private Sub frmVideoPlayer_Maximized(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then
            plyrVideoPlayer.fullScreen = True
        End If
    End Sub

    Private Sub plyrVideoPlayer_DoubleClick(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_DoubleClickEvent) Handles plyrVideoPlayer.DoubleClickEvent
        MsgBox("the player was double clicked")
        'Me.MaximizeBox = True
    End Sub

    Private Sub frmVideoPlayer_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles Me.DoubleClick
        ' Do nothing because we want the media player double click handler to deal with it.
        'MsgBox("the form was double clicked")
    End Sub

    ''' <summary>
    ''' Handles things once the video is fully loaded. This is needed to accurately get the dureation
    ''' of the video because some are larger than others and will take longer to load.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub plyrVideoPlayer_OpenStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_OpenStateChangeEvent) Handles plyrVideoPlayer.OpenStateChange
        m_tsDurationTime = TimeSpan.FromSeconds(m_currentMedia.duration)
        'lblDuration.Text = getFormattedDurationString()
        ' Make the video loading screen invisible
        'pnlHideVideo.Visible = False
    End Sub

    ''' <summary>
    ''' Unloads the frmVideoPLayer form. The player and timer are stopped and the ClosingEvent is fired
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.Windows.Forms.FormClosingEventArgs</param>
    Private Sub frmVideoPlayer_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        plyrVideoPlayer.Ctlcontrols.stop()
        plyrVideoPlayer.Dispose()
        tmrVideo.Stop()
        RaiseEvent ClosingEvent()
    End Sub

    ''' <summary>
    ''' Plays the video and change the picturebox icon to reflect this. Fires the PlayEvent.
    ''' </summary>
    ''' <returns>True or False for success. False is returned if the media was not loaded correctly or an exception was thrown</returns>
    ''' <remarks>If IsEndOfVideo is True and either IsStopped or IsPaused is True, 
    ''' that means that the player is at the end and the play request will attempt to reset the player to the beginning</remarks>
    Public Function playVideo() As Boolean
        If IsNothing(plyrVideoPlayer) Or m_dblRate <= 0 Then
            Return False
        End If
        Try
            If IsPaused Or IsStopped Then
                If m_blIsEndOfVideo Then
                    ' It's sitting at the end of the video, so reset everything by calling stop, then play again
                    stopVideo()
                    plyrVideoPlayer.Ctlcontrols.play()
                Else
                    ' It's stopped or paused, but not at the end of the video, so just continue playing
                    plyrVideoPlayer.Ctlcontrols.play()
                End If
            Else
                ' It's not paused and not stopped, probably just loaded. Start from the beginning by calling play(mbMedia)
                plyrVideoPlayer.Ctlcontrols.play()
            End If
            plyrVideoPlayer.settings.rate = CType(Rate, Single)
            'm_sngFPS = plyrVideoPlayer.fps
            'pctVideoStatus.BackgroundImage = My.Resources.Play_Icon_Inverse
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
            plyrVideoPlayer.Ctlcontrols.pause()
            'pctVideoStatus.BackgroundImage = My.Resources.Pause_Icon_Inverse
            RaiseEvent PauseEvent()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Update the trackbar position and the timer text to reflect changes
    ''' </summary>
    Private Sub updateUI()
        ' None of my attempts to fetch SMPTE timecode have worked, despite many attempts.
        ' Searches online reveled nothing about how to do this.
        'Try
        'https://msdn.microsoft.com/en-us/library/windows/desktop/dd564733%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396
        ' Cast the interface returned by player.Ctlcontrols to an IWMPControls3 interface
        ' so that you can use the currentPositionTimecode property.
        'Dim controls As WMPLib.IWMPControls3 = plyrVideoPlayer.Ctlcontrols
        'Try
        '    Debug.WriteLine(CType(controls.currentPositionTimecode, Object))

        'Catch ex As Exception
        '    Debug.WriteLine("Exception thrown.. Message: " & ex.Message)

        'End Try
        'm_tsCurrentVideoTime = TimeSpan.Parse(controls.currentPositionTimecode)
        ' Seek to a frame using SMPTE time code.
        'Controls.currentPositionTimecode = "[00000]01:00:30.05"

        'm_tsCurrentVideoTime = plyrVideoPlayer.Controls.currentpositiontimecode
        'Catch ex As Exception
        m_tsCurrentVideoTime = TimeSpan.FromSeconds(plyrVideoPlayer.Ctlcontrols.currentPosition)
        'End Try
    End Sub

    ''' <summary>
    ''' Stop the video and change the picturebox icon to reflect this. Fires the StopEvent.
    ''' </summary>
    ''' <returns>True or False for success. Only returns False if an exception is thrown</returns>
    Public Function stopVideo() As Boolean
        Try
            'Don't put a statement like 'If IsPlaying Or IsPaused Then' here because some videos don't stop correctly at the end,
            ' i.e. they never quite reach their duration... (older vids)
            ' Update Jun 2016 - I don't know if this is true with Windows Media Player. It was with VLC.NET
            plyrVideoPlayer.Ctlcontrols.stop()
            'pctVideoStatus.BackgroundImage = My.Resources.Stop_Icon_Inverse
            'trkCurrentPosition.Value = 0
            m_tsCurrentVideoTime = Zero
            updateUI()
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
    Private Sub tmrVideo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrVideo.Tick
        If IsPlaying Then
            If plyrVideoPlayer.playState = WMPLib.WMPPlayState.wmppsMediaEnded Then
                endOfVideo()
                Exit Sub
            End If
            ' Update the current video time based on the SMPTE timecode when present, or the position if it isn't.
            updateUI()
            RaiseEvent TimerTickEvent()
        End If
    End Sub

    ''' <summary>
    ''' Step forward a number of frames in the video and adjust player controls accordingly
    ''' </summary>
    ''' <param name="intFramesToSkip">Number of frames to skip, typically between 50 and 1000</param>
    ''' <returns>Boolean if the stepping succeeded</returns>
    Public Function stepForward(intFramesToSkip As Integer) As Boolean
        m_intFramesToSkip = intFramesToSkip
        pauseVideo()
        If IsStopped Then Return False
        For i As Integer = 0 To m_intFramesToSkip
            Dim ctlcontrols As WMPLib.IWMPControls = plyrVideoPlayer.Ctlcontrols
            Dim ctlcontrols2 As WMPLib.IWMPControls2 = DirectCast(ctlcontrols, WMPLib.IWMPControls2)
            ctlcontrols2.step(1)
            updateUI()
            RaiseEvent TimerTickEvent()
        Next
        Return True
    End Function

    ''' <summary>
    ''' Calculates the current percentage of the video which has been seen based on the
    ''' current time of the player
    ''' </summary>
    ''' <returns>A Double between 0 and 100</returns>
    Private Function getCurrentPercentComplete() As Double
        Return plyrVideoPlayer.Ctlcontrols.currentPosition / CDbl(m_tsDurationTime.Seconds) * 100.0
    End Function

    ''' <summary>
    ''' This mouse handler handles both MouseDown and MouseMove Events for the trackbar. If you press on the trackbar and move it,
    ''' the video will pause,then seek to that spot and remain paused.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.Windows.Forms.MouseEventArgs</param>
    'Private Sub trkCurrentPosition_MovePointer(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trkCurrentPosition.MouseDown, trkCurrentPosition.MouseMove
    '    Dim dblValue As Double
    '    'Make sure it was the left button that was pressed
    '    If e.Button = Windows.Forms.MouseButtons.Left Then
    '        pauseVideo()
    '        'dblValue = (Convert.ToDouble(e.X) / Convert.ToDouble(trkCurrentPosition.Width)) * (trkCurrentPosition.Maximum - trkCurrentPosition.Minimum)
    '        If dblValue > 100.0 Then dblValue = 100.0 ' Sometimes the track can go past 100%
    '        If dblValue < 0.0 Then dblValue = 0.0 ' Sometimes the track can go negative
    '        'trkCurrentPosition.Value = Convert.ToInt32(dblValue)
    '        plyrVideoPlayer.Ctlcontrols.currentPosition = getCurrentPercentComplete()
    '        updateUI()
    '    End If
    '    ' TODO: Implement the tmrPerSecond stuff
    '    'If myFormLibrary.frmVideoMiner.tmrRecordPerSecond.Enabled = True Then
    '    ' blRecordPerSecond = True
    '    ' myFormLibrary.frmVideoMiner.tmrRecordPerSecond.Stop()
    '    'End If
    'End Sub

    ''' <summary>
    ''' The trackbar MouseUp event just pauses the video.
    ''' This is here to ensure the video remains paused after seeking with the trackbar
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.Windows.Forms.MouseEventArgs</param>
    'Private Sub trkCurrentPosition_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trkCurrentPosition.MouseUp
    '    'plyrVideoPlayer.Ctlcontrols.currentPosition = CType(trkCurrentPosition.Value / 100.0, Single)
    '    plyrVideoPlayer.Refresh()
    '    pauseVideo()
    'End Sub

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

    ' ''' <summary>
    ' ''' Toggles maximized/normal window state if user double clicks the mouse on the video
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    Private Sub m_pnlTransparentPanel_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_pnlTransparentPanel.DoubleClick
        If Me.WindowState <> FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
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
        MessageBox.Show("The Videominer player window contains the video you loaded with a trackbar for seeking and an icon showing you " &
                        "the current state of the video (playing, paused, stopped)." & vbCrLf & vbCrLf &
                        "Left-click the video to toggle between Pause/Play." & vbCrLf &
                        "Close the video by clicking the 'X' on the top right of the player window." & vbCrLf &
                        "Press Right arrow to do frame stepping" & vbCrLf &
                        "Press Spacebar to toggle Pause/Play",
                        "Videominer Player Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' This handles the Event 'EndReached' fired by the Vlc.DotNet control.
    ''' </summary>
    Private Sub plyrVideo_Ended(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles plyrVideoPlayer.PlayStateChange
        If e.newState = WMPLib.WMPPlayState.wmppsMediaEnded Then
            endOfVideo()
        End If
    End Sub

    ''' <summary>
    ''' The end of the video has been reached. Do some updating on the form and raise the VideoEnded event.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub endOfVideo()
        ' Pause and set the label to be the duration and the trackbar to the end (the trackbar can be off by a bit).
        ' This is for cosmetic reasons, as the video is no longer playing
        pauseVideo()
        m_tsCurrentVideoTime = m_tsDurationTime
        'lblCurrentTime.Text = lblDuration.Text
        'lblCurrentTime.Refresh()
        'trkCurrentPosition.Value = 100
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
    'Private Sub lblDuration_TextChanged(sender As System.Object, e As System.EventArgs) Handles lblDuration.TextChanged
    '    'lblDuration.Tag = lblDuration.Size
    'End Sub

    ''' <summary>
    ''' When the duration label automatically resizes due to extra decimal points being shown,
    ''' this will make it grow left so that it remains looking good.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Works in tandem with lblDuration_TextChanged(sender As System.Object, e As System.EventArgs) Handles lblDuration.TextChanged</remarks>
    'Private Sub lblDuration_Resize(sender As System.Object, e As System.EventArgs) Handles lblDuration.Resize
    '    Dim TempSize As New Size(New System.Drawing.Point(0))
    '    'If lblDuration.Tag Is Nothing Then lblDuration.Tag = lblDuration.Size
    '    TempSize = DirectCast(lblDuration.Tag, Size)
    '    'lblDuration.Location = New System.Drawing.Point(lblDuration.Location.X - (lblDuration.Size.Width - TempSize.Width), lblDuration.Location.Y)
    'End Sub

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

    Private Sub plyrVideoPlayer_MediaError(ByVal sender As Object,
    ByVal e As AxWMPLib._WMPOCXEvents_MediaErrorEvent) Handles plyrVideoPlayer.MediaError
        MessageBox.Show("The Videominer player (Windows media player) encounterer an error while loading the media. Error message:" &
                        vbCrLf & vbCrLf & e.ToString())
    End Sub
End Class