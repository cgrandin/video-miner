Imports System.TimeSpan

Public Class frmSetTime

    ''' <summary>
    ''' Stores the Timespan object representing the user time
    ''' </summary>
    Private m_tsUserTime As TimeSpan

    ''' <summary>
    ''' UserTime is a TimeSpan property representing the user time
    ''' </summary>
    ''' <value>TimeSpan</value>
    ''' <returns>TimeSpan</returns>
    Public Property UserTime As TimeSpan
        Get
            Return m_tsUserTime
        End Get
        Set(value As TimeSpan)
            m_tsUserTime = value
        End Set
    End Property

    ''' <summary>
    ''' When the user clicks the 'OK' button this event is raised
    ''' </summary>
    Event TimeChanged()
    ''' <summary>
    ''' When the user clicks the 'Use GPS Time and Date' button this event is raised
    ''' </summary>
    ''' <remarks></remarks>
    Event UseGPSTime()
    ''' <summary>
    ''' When the user clicks the 'Use Computer Time and Date' button this event is raised
    ''' </summary>
    ''' <remarks></remarks>
    Event UseComputerTime()
    ''' <summary>
    ''' When the user clicks the 'Use Elapsed Time' button this event is raised
    ''' </summary>
    ''' <remarks></remarks>
    Event UseElapsedTime()
    ''' <summary>
    ''' When the user clicks the 'Continue from Last Clip' button this event is raised
    ''' </summary>
    ''' <remarks></remarks>
    Event UseContinueTime()

    ''' <summary>
    ''' Default constructor
    ''' </summary>
    ''' <remarks>Sets the UserTime property to TimeSpan.Zero</remarks>
    Public Sub New()
        InitializeComponent()
        m_tsUserTime = Zero
        cmdContinueFromLastClip.Enabled = False
        cmdUseElapsedTime.Enabled = False
        cmdNext.Enabled = False
        cmdPlayPause.Enabled = False
        cmdPrevious.Enabled = False
        cmdStop.Enabled = False
        TopLevel = True
        setSourceText("MANUAL")
    End Sub

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="tsUserTime">Sets the UserTime property in the constructor to tsUserTime</param>
    Public Sub New(tsUserTime As TimeSpan)
        InitializeComponent()
        m_tsUserTime = tsUserTime
        cmdContinueFromLastClip.Enabled = False
        cmdUseElapsedTime.Enabled = False
        cmdNext.Enabled = False
        cmdPlayPause.Enabled = False
        cmdPrevious.Enabled = False
        cmdStop.Enabled = False
        TopLevel = True
        setSourceText("MANUAL")
    End Sub

    ''' <summary>
    ''' Load the form, set the time textbox up to show the current user time.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmSetTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSetTime.Text = pad0(m_tsUserTime.Hours) & pad0(m_tsUserTime.Minutes) & pad0(m_tsUserTime.Seconds) & pad0(m_tsUserTime.Milliseconds)
    End Sub

    ''' <summary>
    ''' Handles when the user clicks the 'OK' button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Raises the TimeChanged Event before closing the form</remarks>
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            ' Extract the string version of the time in the textbox and convert it to a Timespan object
            m_tsUserTime = New TimeSpan(0, CInt(Strings.Left(txtSetTime.Text, 2)), CInt(Strings.Mid(txtSetTime.Text, 3, 2)), CInt(Strings.Mid(txtSetTime.Text, 5, 2)), CInt(Strings.Mid(txtSetTime.Text, 7, 2)))
            RaiseEvent TimeChanged()
            'If Not booUseExternalVideo Then
            'dblVideoTimeUserSet = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.currentPosition
            'End If
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("The time entered is invalid, please try again", "Invalid time", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ''' <summary>
    ''' Set the textbox to show GPS as the user time source
    ''' </summary>
    Public Sub setGPSInfo()
        setSourceText("GPS")
    End Sub

    ''' <summary>
    ''' Pad a string of length 1 with a zero. Used to make things like hours=0 into hours="00"
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function pad0(intValue As Integer) As String
        Dim strRep As String = CStr(intValue)
        If strRep.Length = 0 Then
            strRep = "00"
        ElseIf strRep.Length = 1 Then
            strRep = "0" & strRep
        End If
        Return strRep
    End Function

    ''' <summary>
    ''' Set the source text to reflect which is being used. Also set the textbox background and font
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setSourceText(strSource As String)
        txtTimeSource.Text = strSource
        txtTimeSource.Font = New Font("", 10, FontStyle.Bold)
        txtTimeSource.BackColor = Color.LightGray
        txtTimeSource.ForeColor = Color.LimeGreen
        txtTimeSource.TextAlign = HorizontalAlignment.Center
    End Sub

    ''' <summary>
    ''' Handle the click of the button to use the current computer time and date as the user time
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdUseComputerTimeDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseComputerTimeDate.Click
        Dim dtNow As DateTime = Now
        txtSetTime.Text = pad0(dtNow.Hour) & pad0(dtNow.Minute) & pad0(dtNow.Second) & pad0(dtNow.Millisecond)
        setSourceText("COMPUTER")
    End Sub

    ''' <summary>
    ''' Handle the click of the button to use the elapsed time and date as the user time
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdUseElapsedTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseElapsedTime.Click
        RaiseEvent UseElapsedTime()
        setSourceText("ELAPSED")
    End Sub

    ''' <summary>
    ''' Handle the click of the button to use the time and date at the end of the last video clip as the user time
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdContinueFromLastClip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContinueFromLastClip.Click
        RaiseEvent UseContinueTime()
        setSourceText("VIDEO")
    End Sub

    ''' <summary>
    ''' Handle the click of the button to use the GPS time and date as the user time
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdFromGps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseGPSTimeDate.Click
        RaiseEvent UseGPSTime()
        setSourceText("GPS")
    End Sub


    'Private Sub frmSetTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        cmdOk_Click(Nothing, Nothing)
    '    End If
    'End Sub

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