Imports Microsoft.Win32
Imports System.IO.Ports
Public Class frmGpsSettings
    Private Const GPSTimeout As Integer = 30
    Private blErrorFlag As Boolean = False
    Private m_spSerialPort As IO.Ports.SerialPort
    Public m_intSearchingCounter As Integer = 0

    Event GPSConnectedEvent()
    Event GPSDisconnectedEvent()
    Event CloseSerialPortEvent()
    Event OpenSerialPortEvent()
    Event ConnectingPortEvent()

    ''' <summary>
    ''' Create a new instance of the GPS settings form.
    ''' </summary>
    ''' <param name="serialPort">A serial port object, could be Nothing, Closed, or Open</param>
    ''' <remarks></remarks>
    Public Sub New(serialPort As IO.Ports.SerialPort)
        InitializeComponent()
        m_spSerialPort = SerialPort
    End Sub

    Private Sub frmGpsSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

        Try
            Dim regKey As RegistryKey
            regKey = Registry.CurrentUser.CreateSubKey("Software\VideoMiner")

            Dim strGPSStringType As String = regKey.GetValue("GPSStringType")
            If strGPSStringType = "GPGGA" Then
                Me.radGPGGA.Checked = True
                ' below line required id check changed functionality no longer implemented
                'Me.radGPRMC.Checked = False
            ElseIf strGPSStringType = "GPRMC" Then
                Me.radGPRMC.Checked = True
                ' below line required id check changed functionality no longer implemented
                'Me.radGPGGA.Checked = True
            End If

            Dim strComPort As String
            If regKey.GetValue("ComPort") = "" Then
                strComPort = "COM10"
            Else
                strComPort = regKey.GetValue("ComPort")
            End If
            Me.cboComPort.Text = strComPort

            Dim strBaudRate As String
            If regKey.GetValue("BaudRate") = "" Then
                strBaudRate = "4800"
            Else
                strBaudRate = regKey.GetValue("BaudRate")
            End If
            Me.cboBaudRate.Text = strBaudRate

            Dim strParity As String
            If regKey.GetValue("Parity") = "" Then
                strParity = "NONE"
            Else
                strParity = regKey.GetValue("Parity")
            End If
            Me.cboParity.Text = strParity

            Dim strStopBits As String
            If regKey.GetValue("StopBits") = "" Then
                strStopBits = "1"
            Else
                strStopBits = regKey.GetValue("StopBits")
            End If
            Me.cboStopBits.Text = strStopBits

            Dim strDataBits As String
            If regKey.GetValue("DataBits") = "" Then
                strDataBits = "8"
            Else
                strDataBits = regKey.GetValue("DataBits")
            End If
            Me.txtDataBits.Text = strDataBits

            If Not m_spSerialPort Is Nothing Then
                If m_spSerialPort.IsOpen Then
                    tmrGPSTimeout.Start()
                    'Me.lblGPSMessage.Text = "GPS FIX"
                    'Me.lblGPSMessage.ForeColor = Color.Green
                    Me.lblGPSPortMessage.Text = "OPEN"
                    Me.lblGPSPortMessage.ForeColor = Color.Green
                    Me.cmdConnection.Text = "Close GPS Connection"
                    Me.cboBaudRate.Enabled = False
                    Me.cboComPort.Enabled = False
                    Me.cboParity.Enabled = False
                    Me.cboStopBits.Enabled = False
                    Me.txtDataBits.Enabled = False
                    Me.radGPGGA.Enabled = False
                    Me.radGPRMC.Enabled = False
                Else
                    Me.lblGPSMessage.Text = "NO GPS FIX"
                    Me.lblGPSMessage.ForeColor = Color.Red
                    Me.lblGPSPortMessage.Text = "CLOSED"
                    Me.lblGPSPortMessage.ForeColor = Color.Red
                    Me.cboBaudRate.Enabled = True
                    Me.cboComPort.Enabled = True
                    Me.cboParity.Enabled = True
                    Me.cboStopBits.Enabled = True
                    Me.txtDataBits.Enabled = True
                    Me.radGPGGA.Enabled = True
                    Me.radGPRMC.Enabled = True
                End If
            End If
        Catch ex As Exception
            Dim st As New StackTrace(ex, True)
            Dim frame As StackFrame
            frame = st.GetFrame(0)
            Dim line As Integer
            line = frame.GetFileLineNumber
            MsgBox("At line " & line & " " & ex.Message)
        End Try

        'EnableDisable()

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.CreateSubKey("Software\VideoMiner")
        If Me.radGPGGA.Checked = True Then
            regKey.SetValue("GPSStringType", "GPGGA")
        ElseIf Me.radGPRMC.Checked = True Then
            regKey.SetValue("GPSStringType", "GPRMC")
        End If
        regKey.SetValue("ComPort", Me.cboComPort.Text)
        regKey.SetValue("BaudRate", Me.cboBaudRate.Text)
        regKey.SetValue("Parity", Me.cboParity.Text)
        regKey.SetValue("StopBits", Me.cboStopBits.Text)
        regKey.SetValue("DataBits", Me.txtDataBits.Text)
        If Me.tmrGPSTimeout.Enabled Then
            Me.tmrGPSTimeout.Stop()
        End If
        'If Me.cmdConnection.Text = "Open GPS Connection" Then
        '    myFormLibrary.frmVideoMiner.tmrGPSExpiry.Start()
        'End If
        Me.Close()
        'Me.Hide()
    End Sub

    Private Sub EnableDisable()

        'MsgBox(myPortLibrary.aPort.IsOpen)
        If Not myPortLibrary.aPort Is Nothing Then
            If myPortLibrary.aPort.IsOpen Then
                Me.lblGPSPortMessage.Text = "Open"
                Me.cmdConnection.Text = "Close"
            Else
                Me.lblGPSPortMessage.Text = "Closed"
                Me.cmdConnection.Text = "Open"
            End If
        Else
            MsgBox("myPortLibrary.aPort Is Nothing")
        End If

    End Sub

    Private Sub cmdConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnection.Click
        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        AddHandler currentDomain.UnhandledException, AddressOf UnHandledHandler
        ' If the user opens the connection
        If Me.cmdConnection.Text = "Open GPS Connection" Then
            Me.cmdConnection.Enabled = False
            Me.cboBaudRate.Enabled = False
            Me.cboComPort.Enabled = False
            Me.cboParity.Enabled = False
            Me.cboStopBits.Enabled = False
            Me.txtDataBits.Enabled = False
            Me.radGPGGA.Enabled = False
            Me.radGPRMC.Enabled = False
            ' CJG commented out while removing the myformlibrary stuff
            'myFormLibrary.frmVideoMiner.tryCount = 0
            Dim blGPSOpen As Boolean = OpenGPS()    ' Open GPS connection
            If blErrorFlag = True Then
                blErrorFlag = False
                Me.cboBaudRate.Enabled = True
                Me.cboComPort.Enabled = True
                Me.cboParity.Enabled = True
                Me.cboStopBits.Enabled = True
                Me.txtDataBits.Enabled = True
                Me.radGPGGA.Enabled = True
                Me.radGPRMC.Enabled = True
                Exit Sub
            End If
            If blGPSOpen Then       ' If the port is opened then change the GPS elements to show its open
                Me.lblGPSPortMessage.Text = "OPEN"
                Me.lblGPSPortMessage.ForeColor = Color.LimeGreen
                Me.lblGPSMessage.Text = "SEARCHING. . ."
                Me.lblGPSMessage.ForeColor = Color.Blue
                RaiseEvent GPSConnectedEvent()

                tmrGPSTimeout.Start()
            Else                    ' If the port is closed then change the GPS elements to show its closed
                Me.cmdConnection.Enabled = True
                Me.cboBaudRate.Enabled = True
                Me.cboComPort.Enabled = True
                Me.cboParity.Enabled = True
                Me.cboStopBits.Enabled = True
                Me.txtDataBits.Enabled = True
                Me.radGPGGA.Enabled = True
                Me.radGPRMC.Enabled = True
                Me.lblGPSPortMessage.Text = "CLOSED"
                Me.lblGPSPortMessage.ForeColor = Color.Red
                Me.lblGPSMessage.Text = "NO GPS FIX"
                Me.lblGPSMessage.ForeColor = Color.Red
                RaiseEvent GPSDisconnectedEvent()
            End If
        Else                        ' If the user closes the connection
            'If Not myFormLibrary.frmVideoMiner.m_SerialPort Is Nothing Then

            If m_spSerialPort.IsOpen Then
                Dim closePort As Thread = New Thread(New ThreadStart(AddressOf CloseSerialPort))
                closePort.Start()
            End If
            If tmrGPSTimeout.Enabled Then
                tmrGPSTimeout.Stop()
            End If
            'CJG commented while removing myformlibrary
            'If myFormLibrary.frmVideoMiner.tmrGPSExpiry.Enabled Then
            ' myFormLibrary.frmVideoMiner.tmrGPSExpiry.Stop()
            'End If
            If Not m_spSerialPort.IsOpen Then     ' If the port is closed then reset the GPS elements
                Me.cmdConnection.Text = "Open GPS Connection"
                Me.cboBaudRate.Enabled = True
                Me.cboComPort.Enabled = True
                Me.cboParity.Enabled = True
                Me.cboStopBits.Enabled = True
                Me.txtDataBits.Enabled = True
                Me.radGPGGA.Enabled = True
                Me.radGPRMC.Enabled = True
                Me.lblGPSMessage.Text = "NO GPS FIX"
                Me.lblGPSMessage.ForeColor = Color.Red
                Me.lblGPSPortMessage.Text = "CLOSED"
                Me.lblGPSPortMessage.ForeColor = Color.Red
                Me.lblCurrentYValue.Text = ""
                Me.lblCurrentXValue.Text = ""
                Me.lblCurrentZValue.Text = ""
                Me.lblCurrentDateValue.Text = ""
                Me.lblCurrentTimeValue.Text = ""
                RaiseEvent GPSDisconnectedEvent()
            End If
        End If
    End Sub

    Public Sub CloseSerialPort()
        RaiseEvent CloseSerialPortEvent()
    End Sub

    Sub UnHandledHandler(ByVal sender As Object, ByVal args As UnhandledExceptionEventArgs)
        Dim e As Exception = DirectCast(args.ExceptionObject, Exception)

        Console.WriteLine("MyHandler caught : " + e.Message)
        Console.WriteLine("Runtime terminating: {0}", args.IsTerminating)

        Dim st As New StackTrace(e, True)
        Dim frame As StackFrame
        frame = st.GetFrame(0)
        Dim line As Integer
        line = frame.GetFileLineNumber
        MsgBox("At line " & line & " " & e.Message & ". The stack trace is as folows: " & e.StackTrace)

    End Sub

    Public Function OpenGPS() As Boolean

        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        AddHandler currentDomain.UnhandledException, AddressOf UnHandledHandler
        Dim strPrompt As String = ""

        'CJG removing myformlibrary
        'myFormLibrary.frmVideoMiner.m_SerialPort = m_PublicSerialPort

        Dim dr As DialogResult
        If m_spSerialPort.IsOpen Then
            Return True
        End If

        Try
            With m_spSerialPort
                .PortName = CType(Me.cboComPort.Text, String)
                .BaudRate = CType(Val(Me.cboBaudRate.Text), Integer)

                Select Case Me.cboParity.Text
                    Case "NONE"
                        .Parity = Parity.None
                    Case "EVEN"
                        .Parity = Parity.Even
                    Case "MARK"
                        .Parity = Parity.Mark
                    Case "ODD"
                        .Parity = Parity.Odd
                    Case "Space"
                        .Parity = Parity.Space
                End Select

                Select Case Me.cboStopBits.Text
                    Case "1"
                        .StopBits = StopBits.One
                    Case "2"
                        .StopBits = StopBits.Two
                    Case "1.5"
                        .StopBits = StopBits.OnePointFive
                    Case Else
                        .StopBits = StopBits.None
                End Select

                .DataBits = CType(Val(Me.txtDataBits.Text), Integer)
                .Handshake = Handshake.None
                .Open()
            End With
        Catch ex As Exception
            dr = MessageBox.Show("Could not open GPS port: " & ex.Message & " Please check the configuration file and try again.", "GPS Port Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            RaiseEvent CloseSerialPortEvent()
            Return False
        End Try
        If m_spSerialPort.IsOpen Then
            Return True
        End If
    End Function

    Private Sub HandleSerialError(ByVal sender As System.Object, ByVal e As SerialErrorReceivedEventArgs)
        MessageBox.Show("There was an error opening the GPS port: " & e.EventType & " Please check the settings and try again.", "GPS Port Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        blErrorFlag = True
        If m_spSerialPort.IsOpen Then
            m_spSerialPort.Close()
            m_spSerialPort.DiscardInBuffer()
        End If
        If tmrGPSTimeout.Enabled = True Then
            tmrGPSTimeout.Stop()
        End If
    End Sub

    Private Sub tmrGPSTimeout_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGPSTimeout.Tick

        'Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        'AddHandler currentDomain.UnhandledException, AddressOf UnHandledHandler

        m_intSearchingCounter += 1
        If m_intSearchingCounter >= 3 Then
            Me.lblGPSMessage.Text = "SEARCHING. . ."
            Me.lblGPSMessage.ForeColor = Color.Blue
            Me.lblCurrentXValue.Text = ""
            Me.lblCurrentYValue.Text = ""
            Me.lblCurrentZValue.Text = ""
            Me.lblCurrentDateValue.Text = ""
            Me.lblCurrentTimeValue.Text = ""
            RaiseEvent ConnectingPortEvent()
            If m_intSearchingCounter = (GPSTimeout + 3) Then
                tmrGPSTimeout.Stop()
                Dim dr As DialogResult = MessageBox.Show("GPS session has timed out. Please make sure the GPS unit is turned on, also check the connection and try again.", "GPS Fix", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.cmdConnection.Text = "Open GPS Connection"
                m_intSearchingCounter = 0
                RaiseEvent CloseSerialPortEvent()
                Me.cmdConnection.Enabled = True
                Me.cboBaudRate.Enabled = True
                Me.cboComPort.Enabled = True
                Me.cboParity.Enabled = True
                Me.cboStopBits.Enabled = True
                Me.txtDataBits.Enabled = True
                Me.radGPGGA.Enabled = True
                Me.radGPRMC.Enabled = True
                Me.lblGPSMessage.Text = "NO GPS FIX"
                Me.lblGPSMessage.ForeColor = Color.Red
                Me.lblGPSPortMessage.Text = "CLOSED"
                Me.lblGPSPortMessage.ForeColor = Color.Red
                Me.lblCurrentYValue.Text = ""
                Me.lblCurrentXValue.Text = ""
                Me.lblCurrentZValue.Text = ""
                RaiseEvent GPSDisconnectedEvent()
            End If
        End If
    End Sub

    Public Sub New()
        InitializeComponent()
        With Me.cboComPort
            .Items.Add("COM1")
            .Items.Add("COM2")
            .Items.Add("COM3")
            .Items.Add("COM4")
            .Items.Add("COM5")
            .Items.Add("COM6")
            .Items.Add("COM7")
            .Items.Add("COM8")
            .Items.Add("COM9")
            .Items.Add("COM10")
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
        End With

        With Me.cboParity
            .Items.Add("NONE")
            .Items.Add("EVEN")
            .Items.Add("MARK")
            .Items.Add("ODD")
            .Items.Add("SPACE")
        End With

        With Me.cboStopBits
            .Items.Add("1")
            .Items.Add("1.5")
            .Items.Add("2")
        End With

    End Sub
End Class