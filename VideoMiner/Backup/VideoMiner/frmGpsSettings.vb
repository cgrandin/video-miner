Imports Microsoft.Win32
Imports System.IO.Ports
Public Class frmGpsSettings
    Private Const GPSTimeout As Integer = 30
    Private blErrorFlag As Boolean = False

    Private Sub frmGpsSettings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myFormLibrary.frmGpsSettings = Nothing
    End Sub

    Private Sub frmGpsSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

        Try
            myFormLibrary.frmGpsSettings = Me

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

            If Not myFormLibrary.frmVideoMiner.m_SerialPort Is Nothing Then
                If myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then
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



        'Call EnableDisable()

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

    ' Handles clicking on the GPS connection button
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
            myFormLibrary.frmVideoMiner.tryCount = 0
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
                myFormLibrary.frmVideoMiner.lblGPSPortValue.Text = "OPEN"
                myFormLibrary.frmVideoMiner.lblGPSPortValue.ForeColor = Color.LimeGreen
                Me.lblGPSMessage.Text = "SEARCHING. . ."
                Me.lblGPSMessage.ForeColor = Color.Blue
                myFormLibrary.frmVideoMiner.lblGPSConnectionValue.Text = "SEARCHING. . ."
                myFormLibrary.frmVideoMiner.lblGPSConnectionValue.ForeColor = Color.Blue
                'AddHandler myFormLibrary.frmVideoMiner.aSerialPort.DataReceived, AddressOf myFormLibrary.frmVideoMiner.updateTextBox

                tmrGPSTimeout.Start()
                'myFormLibrary.frmVideoMiner.tmrGPSExpiry.Start()
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
                myFormLibrary.frmVideoMiner.lblGPSPortValue.Text = "CLOSED"
                myFormLibrary.frmVideoMiner.lblGPSPortValue.ForeColor = Color.Red
                Me.lblGPSMessage.Text = "NO GPS FIX"
                Me.lblGPSMessage.ForeColor = Color.Red
                myFormLibrary.frmVideoMiner.lblGPSConnectionValue.Text = "NO GPS FIX"
                myFormLibrary.frmVideoMiner.lblGPSConnectionValue.ForeColor = Color.Red
            End If
        Else                        ' If the user closes the connection
            'If Not myFormLibrary.frmVideoMiner.m_SerialPort Is Nothing Then

            If myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then
                Dim closePort As Thread
                closePort = New Thread(New ThreadStart(AddressOf CloseSerialPort))
                closePort.Start()
            End If
            'myFormLibrary.frmVideoMiner.m_SerialPort.Close()                ' Close the port
            If tmrGPSTimeout.Enabled Then
                tmrGPSTimeout.Stop()
            End If
            If myFormLibrary.frmVideoMiner.tmrGPSExpiry.Enabled Then
                myFormLibrary.frmVideoMiner.tmrGPSExpiry.Stop()
            End If
            If Not myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then     ' If the port is closed then reset the GPS elements
                Me.cmdConnection.Text = "Open GPS Connection"
                Me.cboBaudRate.Enabled = True
                Me.cboComPort.Enabled = True
                Me.cboParity.Enabled = True
                Me.cboStopBits.Enabled = True
                Me.txtDataBits.Enabled = True
                Me.radGPGGA.Enabled = True
                Me.radGPRMC.Enabled = True
                myFormLibrary.frmVideoMiner.tryCount = 0
                Me.lblGPSMessage.Text = "NO GPS FIX"
                Me.lblGPSMessage.ForeColor = Color.Red
                myFormLibrary.frmVideoMiner.lblGPSConnectionValue.Text = "NO GPS FIX"
                myFormLibrary.frmVideoMiner.lblGPSConnectionValue.ForeColor = Color.Red
                Me.lblGPSPortMessage.Text = "CLOSED"
                Me.lblGPSPortMessage.ForeColor = Color.Red
                myFormLibrary.frmVideoMiner.lblGPSPortValue.Text = "CLOSED"
                myFormLibrary.frmVideoMiner.lblGPSPortValue.ForeColor = Color.Red
                myFormLibrary.frmVideoMiner.txtNMEA.Text = ""
                Me.lblCurrentYValue.Text = ""
                Me.lblCurrentXValue.Text = ""
                Me.lblCurrentZValue.Text = ""
                Me.lblCurrentDateValue.Text = ""
                Me.lblCurrentTimeValue.Text = ""
                myFormLibrary.frmVideoMiner.lblXValue.Text = ""
                myFormLibrary.frmVideoMiner.lblYValue.Text = ""
                myFormLibrary.frmVideoMiner.lblZValue.Text = ""
                'RemoveHandler myFormLibrary.frmVideoMiner.m_SerialPort.DataReceived, AddressOf myFormLibrary.frmVideoMiner.updateTextBox

                'End If
            End If
        End If
    End Sub
    Public Sub CloseSerialPort()
        Try
            myFormLibrary.frmVideoMiner.m_SerialPort.Close()
            'myFormLibrary.frmVideoMiner.m_SerialPort = Nothing
        Catch ex As Exception
            MsgBox(ex)
        End Try
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

    ' Function to open the GPS port
    Public Function OpenGPS() As Boolean

        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        AddHandler currentDomain.UnhandledException, AddressOf UnHandledHandler
        Dim strPrompt As String = ""

        myFormLibrary.frmVideoMiner.m_SerialPort = m_PublicSerialPort

        Dim dr As DialogResult
        If myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then     ' If the serial port is already open then return true
            Return True
        End If

        'AddHandler myFormLibrary.frmVideoMiner.aSerialPort.ErrorReceived, AddressOf myFormLibrary.frmGpsSettings.HandleSerialError
        Try
            ' Set the serial port properties from the GPS object
            With myFormLibrary.frmVideoMiner.m_SerialPort
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
            myFormLibrary.frmVideoMiner.m_SerialPort.Close()
            Return False
        End Try
        If myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then     ' If the serial port is open then return true
            Return True
        End If

    End Function

    Private Sub HandleSerialError(ByVal sender As System.Object, ByVal e As SerialErrorReceivedEventArgs)
        MessageBox.Show("There was an error opening the GPS port: " & e.EventType & " Please check the settings and try again.", "GPS Port Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        blErrorFlag = True
        If myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then
            myFormLibrary.frmVideoMiner.m_SerialPort.Close()
            myFormLibrary.frmVideoMiner.m_SerialPort.DiscardInBuffer()
        End If
        If tmrGPSTimeout.Enabled = True Then
            tmrGPSTimeout.Stop()
        End If
    End Sub

    ' Handles the GPS Timeout tick event
    Private Sub tmrGPSTimeout_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGPSTimeout.Tick

        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        AddHandler currentDomain.UnhandledException, AddressOf UnHandledHandler

        myFormLibrary.frmVideoMiner.searchingCounter += 1
        If myFormLibrary.frmVideoMiner.searchingCounter >= 3 Then
            Me.lblGPSMessage.Text = "SEARCHING. . ."
            myFormLibrary.frmVideoMiner.lblGPSConnectionValue.Text = "SEARCHING. . ."
            Me.lblGPSMessage.ForeColor = Color.Blue
            myFormLibrary.frmVideoMiner.lblGPSConnectionValue.ForeColor = Color.Blue
            Me.lblCurrentXValue.Text = ""
            myFormLibrary.frmVideoMiner.lblXValue.ForeColor = Color.Red
            Me.lblCurrentYValue.Text = ""
            myFormLibrary.frmVideoMiner.lblYValue.ForeColor = Color.Red
            Me.lblCurrentZValue.Text = ""
            myFormLibrary.frmVideoMiner.lblZValue.ForeColor = Color.Red
            Me.lblCurrentDateValue.Text = ""
            myFormLibrary.frmVideoMiner.txtTransectDate.ForeColor = Color.Red
            Me.lblCurrentTimeValue.Text = ""
            myFormLibrary.frmVideoMiner.txtDateSource.ForeColor = Color.Red
            If myFormLibrary.frmVideoMiner.searchingCounter = (GPSTimeout + 3) Then
                Me.tmrGPSTimeout.Stop() ' Stop the timer

                ' Inform the user of the connection timeout
                Dim dr As DialogResult
                dr = MessageBox.Show("GPS session has timed out. Please make sure the GPS unit is turned on, also check the connection and try again.", "GPS Fix", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.cmdConnection.Text = "Open GPS Connection"

                ' Reset the try counter and close the serial port
                myFormLibrary.frmVideoMiner.searchingCounter = 0
                myFormLibrary.frmVideoMiner.m_SerialPort.Close()
                If Not myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then     ' If the port is closed then reset the GPS elements
                    Me.cmdConnection.Text = "Open GPS Connection"
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
                    myFormLibrary.frmVideoMiner.lblGPSConnectionValue.Text = "NO GPS FIX"
                    myFormLibrary.frmVideoMiner.lblGPSConnectionValue.ForeColor = Color.Red
                    Me.lblGPSPortMessage.Text = "CLOSED"
                    Me.lblGPSPortMessage.ForeColor = Color.Red
                    myFormLibrary.frmVideoMiner.lblGPSPortValue.Text = "CLOSED"
                    myFormLibrary.frmVideoMiner.lblGPSPortValue.ForeColor = Color.Red
                    myFormLibrary.frmVideoMiner.txtNMEA.Text = ""
                    Me.lblCurrentYValue.Text = ""
                    Me.lblCurrentXValue.Text = ""
                    Me.lblCurrentZValue.Text = ""
                    myFormLibrary.frmVideoMiner.lblXValue.Text = ""
                    myFormLibrary.frmVideoMiner.lblYValue.Text = ""
                    myFormLibrary.frmVideoMiner.lblZValue.Text = ""
                    myFormLibrary.frmVideoMiner.txtTime.ForeColor = Color.Red
                    myFormLibrary.frmVideoMiner.txtTimeSource.ForeColor = Color.Red
                    myFormLibrary.frmVideoMiner.txtDateSource.ForeColor = Color.Red
                End If
                Exit Sub
            End If
        End If



        'myFormLibrary.frmVideoMiner.tryCount += 1   ' Increment the try counter

        '' If there is no data being recieved from the port
        'If Me.lblCurrentYValue.Text = "" And lblCurrentXValue.Text = "" Then
        '    ' If the try counter is equal to the timeout constant
        '    If myFormLibrary.frmVideoMiner.tryCount = GPSTimeout Then
        '        Me.tmrGPSTimeout.Stop() ' Stop the timer

        '        ' Inform the user of the connection timeout
        '        Dim dr As DialogResult
        '        dr = MessageBox.Show("GPS session has timed out. Please make sure the GPS unit is turned on, also check the connection and try again.", "GPS Fix", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        Me.cmdConnection.Text = "Open GPS Connection"

        '        ' Reset the try counter and close the serial port
        '        myFormLibrary.frmVideoMiner.tryCount = 0
        '        myFormLibrary.frmVideoMiner.m_SerialPort.Close()
        '        If Not myFormLibrary.frmVideoMiner.m_SerialPort.IsOpen Then     ' If the port is closed then reset the GPS elements
        '            Me.cmdConnection.Text = "Open GPS Connection"
        '            Me.cmdConnection.Enabled = True
        '            Me.lblGPSMessage.Text = "NO GPS FIX"
        '            Me.lblGPSMessage.ForeColor = Color.Red
        '            Me.lblGPSPortMessage.Text = "CLOSED"
        '            Me.lblGPSPortMessage.ForeColor = Color.Red
        '            myFormLibrary.frmVideoMiner.txtNMEA.Text = ""
        '            Me.lblCurrentYValue.Text = ""
        '            Me.lblCurrentXValue.Text = ""
        '        End If
        '        Exit Sub
        '    End If
        'Else    ' If there is data being received then stop the timer and exit
        '    Me.tmrGPSTimeout.Stop()
        '    Exit Sub
        'End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
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