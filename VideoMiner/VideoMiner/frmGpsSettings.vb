Imports Microsoft.Win32
Imports System.IO.Ports
Imports System.Text.RegularExpressions

Public Class frmGpsSettings

    Private Const GPS_TIMEOUT As Integer = 30

#Region "Member variables"
    ''' <summary>
    ''' Value of default connection and read timeout in seconds
    ''' </summary>
    Public Const TIMEOUT_DEFAULT As Integer = 5
    ''' <summary>
    ''' Counter to keep track of timer ticks during connection attempt. Connection timeout counter.
    ''' </summary>
    Private m_intSearchingCounter As Integer = 0
    ''' <summary>
    ''' Counter to keep track of timer ticks for data received, used to make sure the data keep coming in once a connectioin is established
    ''' </summary>
    Private m_lngConnectedCounter As Long = 0
    ''' <summary>
    ''' The date and time of the last data received. Used with m_lngConnectedCounter to figure out if the connection has been terminated.
    ''' </summary>
    Private m_dtLastTimeDataReceived As DateTime

    Private m_blErrorFlag As Boolean
    Private WithEvents m_spSerialPort As SerialPort
    Private m_strComPort As String
    Private m_strNMEAStringType As String
    Private m_strParity As String
    Private m_intBaudRate As Integer
    Private m_dblStopBits As Double
    Private m_intDataBits As Integer
    Private m_intTimeout As Integer
    ' Connection variables
    Private m_blConnected As Boolean
    ' GPS data variables
    Private m_dblGPSX As Double
    Private m_dblGPSY As Double
    Private m_dblGPSZ As Double
    Private m_dblGPSTime As Double
    Private m_dtGPSTime As DateTime
    Private m_strCurrData As String
    Private m_blDataGood As Boolean
    ' Data viewer
    Private WithEvents m_frmStringDataViewer As frmStringDataViewer

    ' Threaded timer for connectivity
    ''' <summary>
    ''' Timer for the check to make sure connectivity is maintained.
    ''' </summary>
    ''' <remarks>Had to be a system threading timer due to SerialPort.DataReceived being in another thread</remarks>
    Dim m_tmrTimerItem As Threading.Timer
    ''' <summary>
    ''' Callback delegate for m_tmrTimerItem
    ''' </summary>
    ''' <remarks></remarks>
    Dim m_tmrcbTimerDelegate As Threading.TimerCallback

#End Region

#Region "Properties"
    ''' <summary>
    ''' Exposes the SerialPort Object
    ''' </summary>
    ''' <returns>SerialPort</returns>
    Public ReadOnly Property SerialPort As SerialPort
        Get
            Return m_spSerialPort
        End Get
    End Property

    ''' <summary>
    ''' The name of the ComPort, eg "COM1", "COM2", ...
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>String</returns>
    Public Property ComPort As String
        Get
            Return m_strComPort
        End Get
        Set(value As String)
            m_strComPort = value
        End Set
    End Property

    ''' <summary>
    ''' NMEA (National Marine Electronics Association) String type
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>String</returns>
    ''' <remarks>This String will be like "GPGGA", "GPRMC", ...</remarks>
    Public Property NMEAStringType As String
        Get
            Return m_strNMEAStringType
        End Get
        Set(value As String)
            m_strNMEAStringType = value
        End Set
    End Property

    ''' <summary>
    ''' Baud rate for the serial port connection
    ''' </summary>
    ''' <value>Integer</value>
    ''' <returns>Integer</returns>
    Public Property BaudRate As Integer
        Get
            Return m_intBaudRate
        End Get
        Set(value As Integer)
            m_intBaudRate = value
        End Set
    End Property

    ''' <summary>
    ''' Parity value for the serial port connection
    ''' </summary>
    ''' <value>Integer</value>
    ''' <returns>Integer</returns>
    Public Property Parity As String
        Get
            Return m_strParity
        End Get
        Set(value As String)
            m_strParity = value
        End Set
    End Property

    ''' <summary>
    ''' Parity enumeration value for the serial port connection
    ''' </summary>
    ''' <value>Parity</value>
    ''' <returns>Parity</returns>
    Public Property ParityEnumVal As System.IO.Ports.Parity
        Get
            If m_strParity = System.IO.Ports.Parity.Even.ToString() Then
                Return System.IO.Ports.Parity.Even
            End If
            If m_strParity = System.IO.Ports.Parity.Mark.ToString() Then
                Return System.IO.Ports.Parity.Mark
            End If
            If m_strParity = System.IO.Ports.Parity.None.ToString() Then
                Return System.IO.Ports.Parity.None
            End If
            If m_strParity = System.IO.Ports.Parity.Odd.ToString() Then
                Return System.IO.Ports.Parity.Odd
            End If
            If m_strParity = System.IO.Ports.Parity.Space.ToString() Then
                Return System.IO.Ports.Parity.Space
            End If
        End Get
        Set(value As System.IO.Ports.Parity)
            m_strParity = value.ToString()
        End Set
    End Property

    ''' <summary>
    ''' Stop bits value for the serial port connection
    ''' </summary>
    ''' <value>Integer</value>
    ''' <returns>Integer</returns>
    Public Property StopBits As Double
        Get
            Return m_dblStopBits
        End Get
        Set(value As Double)
            m_dblStopBits = value
        End Set
    End Property

    ''' <summary>
    ''' Stop bits enumeration for the serial port connection
    ''' </summary>
    Public Property StopBitsEnumVal As System.IO.Ports.StopBits
        Get
            If m_dblStopBits = 0 Then
                Return System.IO.Ports.StopBits.None
            End If
            If m_dblStopBits = 1 Then
                Return System.IO.Ports.StopBits.One
            End If
            If m_dblStopBits = 1.5 Then
                Return System.IO.Ports.StopBits.OnePointFive
            End If
            If m_dblStopBits = 2 Then
                Return System.IO.Ports.StopBits.Two
            End If
        End Get
        Set(value As System.IO.Ports.StopBits)
            If value = IO.Ports.StopBits.None Then
                m_dblStopBits = 0
            End If
            If value = IO.Ports.StopBits.One Then
                m_dblStopBits = 1
            End If
            If value = IO.Ports.StopBits.OnePointFive Then
                m_dblStopBits = 1.5
            End If
            If value = IO.Ports.StopBits.Two Then
                m_dblStopBits = 2
            End If
        End Set
    End Property

    ''' <summary>
    ''' Data bits value for the serial port connection
    ''' </summary>
    ''' <value>Integer</value>
    ''' <returns>Integer</returns>
    Public Property DataBits As Integer
        Get
            Return m_intDataBits
        End Get
        Set(value As Integer)
            m_intDataBits = value
        End Set
    End Property

    ''' <summary>
    ''' Length of time in seconds to timeout the connection operation
    ''' </summary>
    Public Property Timeout As Integer
        Get
            Return m_intTimeout
        End Get
        Set(value As Integer)
            m_intTimeout = value
        End Set
    End Property

    ''' <summary>
    ''' True if the serial port is connected, false otherwise
    ''' </summary>
    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_blConnected
        End Get
    End Property

    ''' <summary>
    ''' True if the Serial port is open
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsOpen As Boolean
        Get
            If m_spSerialPort Is Nothing Then
                Return False
            End If
            Return m_spSerialPort.IsOpen
        End Get
    End Property

    Public ReadOnly Property LatitudeDegrees As Integer
        Get
            Return m_dblGPSX \ 100
        End Get
    End Property

    Public ReadOnly Property LatitudeMinutes As Double
        Get
            Dim numberAsString As String = m_dblGPSX.ToString()
            Dim indexOfDecimalPoint As Integer = numberAsString.IndexOf(".")
            Dim numberOfDecimals As Integer = _
                numberAsString.Substring(indexOfDecimalPoint + 1).Length
            Dim s As Double = CDbl(m_dblGPSX Mod 100)
            s = Math.Round(s, numberOfDecimals)
            Return s
        End Get
    End Property

    Public ReadOnly Property LongitudeDegrees As Integer
        Get
            Return m_dblGPSY \ 100
        End Get
    End Property

    Public ReadOnly Property LongitudeMinutes As Double
        Get
            Dim numberAsString As String = m_dblGPSY.ToString()
            Dim indexOfDecimalPoint As Integer = numberAsString.IndexOf(".")
            Dim numberOfDecimals As Integer = _
                numberAsString.Substring(indexOfDecimalPoint + 1).Length
            Dim s As Double = CDbl(m_dblGPSY Mod 100)
            s = Math.Round(s, numberOfDecimals)
            If s < 0 Then
                s *= -1
            End If
            Return s
        End Get
    End Property

    Public ReadOnly Property Elevation As Integer
        Get
            Return m_dblGPSZ
        End Get
    End Property

    Public ReadOnly Property GPSTime As DateTime
        Get
            Dim hours As Integer = m_dblGPSTime \ 10000
            Dim minutes As Integer = (m_dblGPSTime - hours) \ 100
            Dim seconds As Integer = (m_dblGPSTime - hours) Mod 100
            m_dtGPSTime = New DateTime(0, 0, 0, hours, minutes, seconds)
            Return m_dtGPSTime
        End Get
    End Property

    Public ReadOnly Property GPSHours As Integer
        Get
            Return m_dblGPSTime \ 10000
        End Get
    End Property

    Public ReadOnly Property GPSMinutes As String
        Get
            Return pad0((m_dblGPSTime - GPSHours * 10000) \ 100)
        End Get
    End Property

    Public ReadOnly Property GPSSeconds As String
        Get
            Return pad0((m_dblGPSTime - GPSHours * 10000) Mod 100)
        End Get
    End Property
#End Region

#Region "Events"
    ''' <summary>
    ''' Used to signal that the class needs to be populated with serial port variables
    ''' </summary>
    ''' <remarks>The properties to be set are: ComPort, GPSStringType, BaudRate, Parity, StopBits, and DataBits</remarks>
    Event GPSConnectedEvent()
    Event GPSDisconnectedEvent()
    Event CloseSerialPortEvent()
    Event OpenSerialPortEvent()
    Event ConnectingPortEvent()
    Event GPSVariablesChangedEvent()
    Event NoCOMPortsEvent()
#End Region

    ''' <summary>
    ''' Creates a new instance of the GPS settings form.
    ''' Adds ComboBox choices for COM Port, Baud rate, Parity, Stop bits, and Data bits
    ''' </summary>
    Public Sub New(strComPort As String, strNMEAString As String, intBaudRate As Integer, strParity As String, dblStopBits As Double, intDataBits As Integer, Optional intTimeout As Integer = TIMEOUT_DEFAULT)
        InitializeComponent()
        m_blErrorFlag = False
        m_blConnected = False
        m_strComPort = strComPort
        m_strNMEAStringType = strNMEAString
        m_intBaudRate = intBaudRate
        m_strParity = strParity
        m_dblStopBits = dblStopBits
        m_intDataBits = intDataBits
        m_intTimeout = intTimeout
        m_dblGPSX = 0.0
        m_dblGPSY = 0.0
        m_dblGPSZ = 0.0
        m_dblGPSTime = 0.0
        m_strCurrData = ""
        m_blDataGood = False

        With Me.cboComPort
            If My.Computer.Ports.SerialPortNames.Count > 0 Then
                For Each sp As String In My.Computer.Ports.SerialPortNames
                    .Items.Add(sp)
                Next
                If .SelectedIndex = -1 Then
                    .SelectedIndex = 0
                End If
            End If
        End With
        With Me.cboBaudRate
            .Items.Add("110")
            .Items.Add("300")
            .Items.Add("600")
            .Items.Add("1200")
            .Items.Add("2400")
            .Items.Add("4800")
            .Items.Add("9600")
            .Items.Add("14400")
            .Items.Add("19200")
            .Items.Add("38400")
            .Items.Add("56000")
            .Items.Add("57600")
            .Items.Add("115200")
            .Items.Add("128000")
            .Items.Add("230400")
            .Items.Add("256000")
            .Items.Add("460800")
            .Items.Add("921600")
            If .SelectedIndex = -1 Then
                .SelectedIndex = 0
            End If
        End With
        With Me.cboParity
            .Items.Add("NONE")
            .Items.Add("EVEN")
            .Items.Add("MARK")
            .Items.Add("ODD")
            .Items.Add("SPACE")
            If .SelectedIndex = -1 Then
                .SelectedIndex = 0
            End If
        End With
        With Me.cboStopBits
            .Items.Add("1")
            .Items.Add("1.5")
            .Items.Add("2")
            If .SelectedIndex = -1 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub frmGpsSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' From MSDN for Windows.Forms.Control.CheckForIllegalCrossThreadCalls:
        ' When a thread other than the creating thread of a control tries to access one of that control's methods or properties,
        ' it often leads to unpredictable results. A common invalid thread activity is a call on the wrong thread that accesses
        ' the Control 's Handle property. Set CheckForIllegalCrossThreadCalls to true to find and diagnose this thread activity
        ' more easily while debugging. 
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

        If My.Computer.Ports.SerialPortNames.Count = 0 Then
            Me.Text = "NO COM PORTS FOUND"
            DisableAll()
            MessageBox.Show("There were no COM ports found on this system. If you are using a USB/Serial adapter, make sure it is connected to a device which is currently on and sending data.", "No COM Ports", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If m_strNMEAStringType = "GPGGA" Then
            Me.radGPGGA.Checked = True
        ElseIf m_strNMEAStringType = "GPRMC" Then
            Me.radGPRMC.Checked = True
        End If
        cboComPort.Text = m_strComPort
        cboBaudRate.Text = CStr(m_intBaudRate)
        cboParity.Text = m_strParity
        cboStopBits.Text = CStr(m_dblStopBits)
        txtDataBits.Text = CStr(m_intDataBits)
        txtTimeout.Text = CStr(m_intTimeout)
    End Sub

    ''' <summary>
    ''' Set the member variables to be what are in the form selections controls.
    ''' </summary>
    ''' <remarks>Closes the serial port if it is open, and sets it to Nothing</remarks>
    Private Sub SetSerialPortVariables()
        m_strComPort = Me.cboComPort.Text
        m_strNMEAStringType = NMEAStringType
        m_intBaudRate = CInt(cboBaudRate.Text)
        m_strParity = cboParity.Text
        m_dblStopBits = CDbl(cboStopBits.Text)
        m_intDataBits = CInt(txtDataBits.Text)
        m_intTimeout = CInt(txtTimeout.Text)
        m_spSerialPort = Nothing
        RaiseEvent GPSVariablesChangedEvent()
    End Sub

    ''' <summary>
    ''' Try to connect the serial port with the currently selected values on the textbox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConnectSerialPort()
        If m_spSerialPort Is Nothing Then
            m_spSerialPort = New SerialPort(m_strComPort, m_intBaudRate, ParityEnumVal, m_intDataBits, StopBitsEnumVal)
            m_spSerialPort.Handshake = Handshake.None
            m_spSerialPort.DtrEnable = True
            ' The 1000 is to convert seconds to ms for the ReadTimeout property of SerialPort
            m_spSerialPort.ReadTimeout = m_intTimeout * 1000
            m_blConnected = False
        End If
        If Not IsOpen Then
            Try
                m_spSerialPort.Open()
                lblGPSPortMessage.Text = "OPEN"
                lblGPSPortMessage.ForeColor = Color.LimeGreen
            Catch ex As Exception
                MessageBox.Show("Could not open GPS port: " & ex.Message & " Please check the settings and try again.", "GPS Port Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
        If Not m_blConnected Then
            cmdConnection.Text = "Connecting..."
            cmdConnection.Enabled = False
            cboBaudRate.Enabled = False
            cboComPort.Enabled = False
            cboParity.Enabled = False
            cboStopBits.Enabled = False
            txtDataBits.Enabled = False
            radGPGGA.Enabled = False
            radGPRMC.Enabled = False
            lblGPSMessage.Text = "SEARCHING. . ."
            lblGPSMessage.ForeColor = Color.Blue
            tmrGPSTimeout.Start()

            'CJG commented while removing myformlibrary
            'If myFormLibrary.frmVideoMiner.tmrGPSExpiry.Enabled Then
            ' myFormLibrary.frmVideoMiner.tmrGPSExpiry.Stop()
            'End If
        End If
    End Sub

    ''' <summary>
    ''' Refresh all window controls based on connectivity of the serial port object
    ''' </summary>
    Private Sub RefreshStatus()
        If IsOpen Then
            cmdConnection.Enabled = True
            cmdConnection.Text = "Close GPS Connection"
            lblGPSPortMessage.Text = "OPEN"
            lblGPSPortMessage.ForeColor = Color.LimeGreen
            cboBaudRate.Enabled = False
            cboComPort.Enabled = False
            cboParity.Enabled = False
            cboStopBits.Enabled = False
            txtDataBits.Enabled = False
            radGPGGA.Enabled = False
            radGPRMC.Enabled = False
        Else
            cmdConnection.Enabled = True
            cmdConnection.Text = "Open GPS Connection"
            lblGPSPortMessage.Text = "CLOSED"
            lblGPSPortMessage.ForeColor = Color.Red
            cboBaudRate.Enabled = True
            cboComPort.Enabled = True
            cboParity.Enabled = True
            cboStopBits.Enabled = True
            txtDataBits.Enabled = True
            radGPGGA.Enabled = True
            radGPRMC.Enabled = True
        End If
        If m_blConnected Then
            cmdConnection.Text = "Close GPS Connection"
            lblGPSMessage.Text = "CONNECTED"
            lblGPSMessage.ForeColor = Color.Blue
            ' Chr &HB0 is the degree symbol
            lblCurrentX.Text = "Lat: " & LatitudeDegrees & Chr(&HB0) & "  " & LatitudeMinutes & "'"
            lblCurrentY.Text = "Lon: " & LongitudeDegrees & Chr(&HB0) & "  " & LongitudeMinutes & "'"
            lblCurrentZ.Text = "Elev: " & CStr(m_dblGPSZ) & "m"
            lblCurrentTime.Text = "Time: " & GPSHours & ":" & GPSMinutes & ":" & GPSSeconds
        Else
            lblGPSMessage.Text = "NO GPS FIX"
            lblGPSMessage.ForeColor = Color.Red
            lblCurrentX.Text = "Lat: "
            lblCurrentY.Text = "Lon: "
            lblCurrentZ.Text = "Elev: "
            lblCurrentTime.Text = "Time: "
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        SetSerialPortVariables()
        'If Me.tmrGPSTimeout.Enabled Then
        ' Me.tmrGPSTimeout.Stop()
        ' End If
        'If Me.cmdConnection.Text = "Open GPS Connection" Then
        '    myFormLibrary.frmVideoMiner.tmrGPSExpiry.Start()
        'End If
        Me.Hide()
    End Sub

    ''' <summary>
    ''' Toogle to connect or disconnect the serial port
    ''' </summary>
    Private Sub cmdConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnection.Click
        'Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        'AddHandler currentDomain.UnhandledException, AddressOf UnHandledHandler
        If m_blConnected Then
            CloseSerialPort()
        Else
            SetSerialPortVariables()
            ConnectSerialPort()
        End If
        RefreshStatus()
    End Sub

    ''' <summary>
    ''' Creates a new thread to close the port because of an issue with the method
    ''' </summary>
    Private Sub ClosePortThread()
        Application.DoEvents()
        System.Threading.Thread.Sleep(2000)
        If Not m_spSerialPort Is Nothing Then
            m_spSerialPort.Close()
        End If
    End Sub

    ''' <summary>
    ''' Close the serial port and reset form member variables to reflect change
    ''' </summary>
    Public Sub CloseSerialPort()
        Try
            cmdConnection.Enabled = False
            cmdConnection.Text = "Disconnecting..."
            Dim closePort As Thread = New Thread(New ThreadStart(AddressOf ClosePortThread))
            closePort.Start()
            ' It only seems to work with this extra .Close() included
            m_spSerialPort.Close()
            'm_spSerialPort.DiscardInBuffer() ' This throws an exception: Port closed
        Catch ex As Exception
            MsgBox("Debug: Exception in CloseSerialPort: " & ex.Message)
        End Try
        m_spSerialPort = Nothing
        m_blConnected = False
        RaiseEvent CloseSerialPortEvent()
    End Sub

    ''' <summary>
    ''' Handles the connection timeout timer. If timeout period has expired, a ReadLine is done on the stream and
    ''' if it is unsuccessful the port will be closed and a message issued. If it succeeds then the connection is
    ''' assumed good.
    ''' </summary>
    Private Sub tmrGPSTimeout_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGPSTimeout.Tick
        'Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        'AddHandler currentDomain.UnhandledException, AddressOf UnHandledHandler
        m_intSearchingCounter += 1
        If m_intSearchingCounter >= m_intTimeout And Not m_blConnected Then
            Try
                If IsOpen Then
                    Dim strData As String = m_spSerialPort.ReadLine
                End If
            Catch ex As Exception
                tmrGPSTimeout.Stop()
                MessageBox.Show("GPS connection has timed out. Please check connection settings, and make sure the GPS device is turned on and is transimitting data then try again.", "GPS Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            End Try
            m_intSearchingCounter = 0
            If IsOpen Then
                CloseSerialPort()
            End If
            'RaiseEvent CloseSerialPortEvent()
            'RaiseEvent GPSDisconnectedEvent()
            RefreshStatus()
        End If
    End Sub

    ''' <summary>
    ''' Checks the current data string for compliance with the chosen NMEA string
    ''' If it is correct, the connected property will be set to true, 
    ''' the connection timeout timer will be stopped and the data will be extracted.
    ''' If any of the key fields (time, lat, long, elevation) are empty strings then
    ''' set the data as bad and exit.
    ''' </summary>
    Private Sub GetData(strData As String)
        m_blDataGood = False
        Dim pattern As String = "\$GPGGA.*"
        Dim myregex As Regex
        Dim mymatch As Match
        If radGPGGA.Checked Then
            pattern = "\$GPGGA.*"
        ElseIf radGPRMC.Checked Then
            pattern = "\$GPRMC.*"
        End If
        myregex = New Regex(pattern)
        mymatch = myregex.Match(strData)
        If mymatch.Success Then
            m_blConnected = True
            m_blDataGood = True
            m_strCurrData = strData
            Dim s() As String = Strings.Split(m_strCurrData, ",")
            If radGPGGA.Checked Then
                ' This is an example of the structure of a GPRMC message
                '(0)	"$GPGGA"
                '(1)	"235632"     (TIME = HHMMSS)
                '(2)	"4912.6036"  (LAT = DDMM.MMMM)
                '(3)	"N"          (LAT hemisphere)
                '(4)	"12357.4957" (LON = DDDMM.MMMM)
                '(5)	"W"          (If West, we multiply by -1)
                '(6)	"8"
                '(7)	"09"
                '(8)	"2.0"
                '(9)	"26.4"       (Elevation in meters)
                '(10)	"M"
                '(11)	"-17.9"
                '(12)	"M"
                '(13)	""
                '(14)	"*43 "
                If s(1) = "" Or s(2) = "" Or s(3) = "" Or s(4) = "" Or s(5) = "" Or s(9) = "" Then
                    m_blConnected = False
                    m_blDataGood = False
                    Exit Sub
                End If
                m_dblGPSTime = s(1)
                m_dblGPSX = s(2)
                m_dblGPSY = s(4)
                If s(3) = "W" Then
                    m_dblGPSY *= -1
                End If
                m_dblGPSZ = s(9)
            ElseIf radGPRMC.Checked Then
                ' This is an example of the structure of a GPRMC message
                '(0)	"$GPRMC"
                '(1)	"235500"
                '(2)	"V"
                '(3)	"4912.6036"
                '(4)	"N"
                '(5)	"12357.4957"
                '(6)	"W"
                '(7)	"0.0"
                '(8)	"0.0"
                '(9)	"050809"
                '(10)	"18.8"
                '(11)	"E"
                '(12)	"S*38 "
                If s(1) = "" Or s(3) = "" Or s(5) = "" Or s(6) = "" Then
                    m_blConnected = False
                    m_blDataGood = False
                    Exit Sub
                End If
                m_dblGPSTime = s(1)
                m_dblGPSX = s(3)
                m_dblGPSY = s(5)
                If s(6) = "W" Then
                    m_dblGPSY *= -1
                End If
                m_dblGPSZ = 0.0
            End If
        End If
    End Sub

    ''' <summary>
    ''' Used to hold parameters for calls to TimerTask. 
    ''' </summary>
    Private Class StateObjClass
        Public SomeValue As Integer
        Public TimerReference As System.Threading.Timer
        Public TimerCanceled As Boolean
    End Class

    ''' <summary>
    ''' Task to run when the threaded timer is started. The timer checks to make sure less than 'timeout' seconds has
    ''' occurred since the last successful data grab.
    ''' </summary>
    ''' <param name="StateObj">The thread state class (StateObjClass)</param>
    Private Sub TimerTask(ByVal StateObj As Object)
        Dim State As StateObjClass = CType(StateObj, StateObjClass)
        ' Use the interlocked class to increment the counter variable.
        System.Threading.Interlocked.Increment(State.SomeValue)
        System.Diagnostics.Debug.WriteLine("Launched new thread  " & Now.ToString)
        If State.TimerCanceled Then
            ' Dispose Requested.
            State.TimerReference.Dispose()
            System.Diagnostics.Debug.WriteLine("Done  " & Now)
        End If
        If m_blConnected Then
            Dim tsTimeDifference As TimeSpan = Now.Subtract(m_dtLastTimeDataReceived)
            If tsTimeDifference.Seconds > m_intTimeout Then
                'MessageBox.Show("Warning from tmrCheckConnection_Tick: GPS connection has been suddenly lost. Please check connection settings, and make sure the GPS unit is turned on and is transimitting data then try again.", "GPS Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                System.Diagnostics.Debug.WriteLine("Warning, gps connection suddenly lost!")
                m_blConnected = False
                m_blDataGood = False
                CloseSerialPort()
            End If
            RefreshStatus()
        End If
    End Sub

    ''' <summary>
    ''' Handles data coming in on the serial port. The first time this happens, the port
    ''' will be officially "connected"
    ''' </summary>
    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles m_spSerialPort.DataReceived
        Dim strData As String = ""
        Try
            strData = m_spSerialPort.ReadLine
        Catch ex As TimeoutException
            ' Handles the situation where the connection was working but then the device on the COM port was unplugged or stopped transmitting data.
            If m_blConnected Then
                MessageBox.Show("Warning from SerialPort_DataReceived: GPS connection has been suddenly lost. Please check connection settings, and make sure the GPS unit is turned on and is transimitting data then try again.", "GPS Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Warning: There is data received but it is likely that the baud rate is set too high. Please check connection settings, and make sure the GPS unit is turned on and is transimitting data then try again.", "GPS Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            End If
            m_blConnected = False
            CloseSerialPort()
        Catch ex As Exception
            m_blConnected = False
            CloseSerialPort()
        End Try

        GetData(strData) ' GetData sets m_blDataGood and m_blConnected so it must be called first here
        If m_blConnected And m_blDataGood Then
            tmrGPSTimeout.Stop()
            m_dtLastTimeDataReceived = DateTime.Now
            If m_tmrcbTimerDelegate Is Nothing Then
                m_tmrcbTimerDelegate = New Threading.TimerCallback(AddressOf TimerTask)
            End If
            If m_tmrTimerItem Is Nothing Then
                Dim StateObj As New StateObjClass
                StateObj.TimerCanceled = False
                StateObj.SomeValue = 1
                m_tmrTimerItem = New Threading.Timer(m_tmrcbTimerDelegate, StateObj, 2000, 2000)
                StateObj.TimerReference = m_tmrTimerItem
                ' Request Dispose of the timer object, sleep for 1 second to allow the first thread to complete
                System.Threading.Thread.Sleep(1000)
                StateObj.TimerCanceled = True
            End If
        End If
        If m_frmStringDataViewer IsNot Nothing Then
            m_frmStringDataViewer.AppendString(m_strCurrData)
        End If

        RefreshStatus()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Hide()
    End Sub

    Private Sub cmdViewPortData_Click(sender As Object, e As EventArgs) Handles cmdViewPortData.Click
        If m_frmStringDataViewer Is Nothing Then
            m_frmStringDataViewer = New frmStringDataViewer()
        End If
        m_frmStringDataViewer.ShowDialog()
    End Sub


    Private Sub StringDataForm_Closing() Handles m_frmStringDataViewer.ClosingEvent
        m_frmStringDataViewer = Nothing
    End Sub

    ''' <summary>
    ''' Prevent non-digits from being entered in DataBits textbox
    ''' </summary>
    Private Sub txtDataBits_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDataBits.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    ''' <summary>
    '''  Prevent non-digits from being entered in Timeout textbox
    ''' </summary>
    Private Sub txtTimeout_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimeout.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' Disables all controls on the form except the Cancel button.
    ''' Useful when there are no com ports available
    ''' </summary>
    Private Sub DisableAll()
        cmdConnection.Enabled = False
        cmdOK.Enabled = False
        cmdViewPortData.Enabled = False
        cboBaudRate.Enabled = False
        cboComPort.Enabled = False
        cboParity.Enabled = False
        cboStopBits.Enabled = False
        txtDataBits.Enabled = False
        radGPGGA.Enabled = False
        radGPRMC.Enabled = False
        txtTimeout.Enabled = False

        Label1.Enabled = False
        Label2.Enabled = False
        Label3.Enabled = False
        Label4.Enabled = False
        Label5.Enabled = False
        Label7.Enabled = False
        lblCurrentDate.Enabled = False
        lblCurrentDateValue.Enabled = False
        lblCurrentLocation.Enabled = False
        lblCurrentTime.Enabled = False
        lblCurrentX.Enabled = False
        lblCurrentXValue.Enabled = False
        lblCurrentY.Enabled = False
        lblCurrentYValue.Enabled = False
        lblCurrentZ.Enabled = False
        lblCurrentZValue.Enabled = False
        lblDateTime.Enabled = False
        lblGPSConnection.Enabled = False
        lblGPSMessage.Text = ""
        lblGPSMessage.Enabled = False
        lblGPSPort.Text = ""
        lblGPSPort.Enabled = False
        lblGPSPortMessage.Enabled = False
        lblTimeout.Enabled = False

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


    'Sub UnHandledHandler(ByVal sender As Object, ByVal args As UnhandledExceptionEventArgs)
    '    Dim e As Exception = DirectCast(args.ExceptionObject, Exception)

    '    Console.WriteLine("MyHandler caught : " + e.Message)
    '    Console.WriteLine("Runtime terminating: {0}", args.IsTerminating)

    '    Dim st As New StackTrace(e, True)
    '    Dim frame As StackFrame
    '    frame = st.GetFrame(0)
    '    Dim line As Integer
    '    line = frame.GetFileLineNumber
    '    MsgBox("At line " & line & " " & e.Message & ". The stack trace is as folows: " & e.StackTrace)

    'End Sub

    'Private Sub HandleSerialError(ByVal sender As System.Object, ByVal e As SerialErrorReceivedEventArgs)
    '    MessageBox.Show("There was an error opening the GPS port: " & e.EventType & " Please check the settings and try again.", "GPS Port Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '    m_blErrorFlag = True
    '    If m_spSerialPort.IsOpen Then
    '        m_spSerialPort.Close()
    '        m_spSerialPort.DiscardInBuffer()
    '    End If
    '    If tmrGPSTimeout.Enabled = True Then
    '        tmrGPSTimeout.Stop()
    '    End If
    'End Sub


End Class