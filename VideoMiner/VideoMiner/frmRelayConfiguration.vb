Imports System.IO.Ports

Public Class frmRelayConfiguration

    Private frmRelayNames As frmRelayNames
    Private frmAssignDevice As frmAssignDevice

    Event RelayConfigurationChangedEvent()

#Region "Fields"
    Private m_ConfigurationSet As Boolean
    Private m_RelaySetup As String
    Private m_ParallelCom As String
    Private m_ParallelBaud As Integer
    Private m_PortOneCom As String
    Private m_PortTwoCom As String
    Private m_PortOneBaud As Integer
    Private m_PortTwoBaud As Integer
    Private m_DeviceOneRelayOne As String
    Private m_DeviceOneRelayTwo As String
    Private m_DeviceOneRelayThree As String
    Private m_DeviceOneRelayFour As String
    Private m_DeviceTwoRelayOne As String
    Private m_DeviceTwoRelayTwo As String
    Private m_DeviceTwoRelayThree As String
    Private m_DeviceTwoRelayFour As String
#End Region

#Region "Relay Properties"

    Public Property ConfigurationSet() As Boolean
        Get
            Return m_ConfigurationSet
        End Get
        Set(ByVal value As Boolean)
            m_ConfigurationSet = value
        End Set
    End Property

    Public Property RelaySetup() As String
        Get
            Return m_RelaySetup
        End Get
        Set(ByVal value As String)
            m_RelaySetup = value
        End Set
    End Property

    Public Property ParallelCom() As String
        Get
            Return m_ParallelCom
        End Get
        Set(ByVal value As String)
            m_ParallelCom = value
        End Set
    End Property

    Public Property ParallelBaud() As Integer
        Get
            Return m_ParallelBaud
        End Get
        Set(ByVal value As Integer)
            m_ParallelBaud = value
        End Set
    End Property

    Public Property PortOneCom() As String
        Get
            Return m_PortOneCom
        End Get
        Set(ByVal value As String)
            m_PortOneCom = value
        End Set
    End Property

    Public Property PortTwoCom() As String
        Get
            Return m_PortTwoCom
        End Get
        Set(ByVal value As String)
            m_PortTwoCom = value
        End Set
    End Property

    Public Property PortOneBaud() As Integer
        Get
            Return m_PortOneBaud
        End Get
        Set(ByVal value As Integer)
            m_PortOneBaud = value
        End Set
    End Property

    Public Property PortTwoBaud() As Integer
        Get
            Return m_PortTwoBaud
        End Get
        Set(ByVal value As Integer)
            m_PortTwoBaud = value
        End Set
    End Property

    Public Property DeviceOneRelayOne() As String
        Get
            Return m_DeviceOneRelayOne
        End Get
        Set(ByVal value As String)
            m_DeviceOneRelayOne = value
        End Set
    End Property

    Public Property DeviceOneRelayTwo() As String
        Get
            Return m_DeviceOneRelayTwo
        End Get
        Set(ByVal value As String)
            m_DeviceOneRelayTwo = value
        End Set
    End Property

    Public Property DeviceOneRelayThree() As String
        Get
            Return m_DeviceOneRelayThree
        End Get
        Set(ByVal value As String)
            m_DeviceOneRelayThree = value
        End Set
    End Property

    Public Property DeviceOneRelayFour() As String
        Get
            Return m_DeviceOneRelayFour
        End Get
        Set(ByVal value As String)
            m_DeviceOneRelayFour = value
        End Set
    End Property

    Public Property DeviceTwoRelayOne() As String
        Get
            Return m_DeviceTwoRelayOne
        End Get
        Set(ByVal value As String)
            m_DeviceTwoRelayOne = value
        End Set
    End Property

    Public Property DeviceTwoRelayTwo() As String
        Get
            Return m_DeviceTwoRelayTwo
        End Get
        Set(ByVal value As String)
            m_DeviceTwoRelayTwo = value
        End Set
    End Property

    Public Property DeviceTwoRelayThree() As String
        Get
            Return m_DeviceTwoRelayThree
        End Get
        Set(ByVal value As String)
            m_DeviceTwoRelayThree = value
        End Set
    End Property

    Public Property DeviceTwoRelayFour() As String
        Get
            Return m_DeviceTwoRelayFour
        End Get
        Set(ByVal value As String)
            m_DeviceTwoRelayFour = value
        End Set
    End Property

#End Region

    Private Sub frmRelayConfiguration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strPorts As String()
        Dim strPort As String

        cboRelayBoardSetup.Items.Add("Wired in Parallel to One COM Port")
        'cboRelayBoardSetup.Items.Add("Wired Separately to Two COM Ports")


        ' Get all available Ports on the computer
        strPorts = SerialPort.GetPortNames
        For Each strPort In strPorts
            cboSerialPortRB1.Items.Add(strPort)
            cboSerialPortRB2.Items.Add(strPort)
            cboParallelSerialPort.Items.Add(strPort)
        Next

        ' Add the available Baud Rates to all comboboxes
        cboBaudRateRB1.Items.Add("1200")
        cboBaudRateRB1.Items.Add("2400")
        cboBaudRateRB1.Items.Add("9600")
        cboBaudRateRB1.Items.Add("19200")

        cboBaudRateRB2.Items.Add("1200")
        cboBaudRateRB2.Items.Add("2400")
        cboBaudRateRB2.Items.Add("9600")
        cboBaudRateRB2.Items.Add("19200")

        cboParallelBaudRate.Items.Add("1200")
        cboParallelBaudRate.Items.Add("2400")
        cboParallelBaudRate.Items.Add("9600")
        cboParallelBaudRate.Items.Add("19200")

        ' Select the combobox items based off of the configuration file
        If RelaySetup = "Parallel" Then
            cboRelayBoardSetup.SelectedIndex = 0
        Else
            cboRelayBoardSetup.SelectedIndex = 1
        End If

        cboParallelSerialPort.SelectedItem = ParallelCom
        cboParallelBaudRate.SelectedItem = CStr(ParallelBaud)
        cboSerialPortRB1.SelectedItem = PortOneCom
        cboSerialPortRB2.SelectedItem = PortTwoCom
        cboBaudRateRB1.SelectedItem = CStr(PortOneBaud)
        cboBaudRateRB2.SelectedItem = CStr(PortTwoBaud)

        ' Modify the label text properties based on the relay names found in the configuration file
        lblRelay1ValueRB1.Text = DeviceOneRelayOne
        lblRelay2ValueRB1.Text = DeviceOneRelayTwo
        lblRelay3ValueRB1.Text = DeviceOneRelayThree
        lblRelay4ValueRB1.Text = DeviceOneRelayFour
        lblRelay1ValueRB2.Text = DeviceTwoRelayOne
        lblRelay2ValueRB2.Text = DeviceTwoRelayTwo
        lblRelay3ValueRB2.Text = DeviceTwoRelayThree
        lblRelay4ValueRB2.Text = DeviceTwoRelayFour

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        ' Store the configuration as set
        ConfigurationSet = True
        RaiseEvent RelayConfigurationChangedEvent()
        Close()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cboRelayBoardSetup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRelayBoardSetup.SelectedIndexChanged

        ' If the selected item is Wired in Parallel then enable/disable the appropriate controls
        If cboRelayBoardSetup.SelectedIndex = 0 Then

            cboParallelSerialPort.Enabled = True
            cboParallelBaudRate.Enabled = True
            cmdAssignDeviceRB1.Enabled = True
            cmdAssignDeviceRB2.Enabled = True

            cboSerialPortRB1.Enabled = False
            cboSerialPortRB2.Enabled = False
            cboBaudRateRB1.Enabled = False
            cboBaudRateRB2.Enabled = False

            ' Store the relay board setup configuration
            RelaySetup = "Parallel"

            'Else    ' Else enable/disable the opposite

            '    cboParallelSerialPort.Enabled = False
            '    cboParallelBaudRate.Enabled = False
            '    cmdAssignDeviceRB1.Enabled = False
            '    cmdAssignDeviceRB2.Enabled = False

            '    cboSerialPortRB1.Enabled = True
            '    cboSerialPortRB2.Enabled = True
            '    cboBaudRateRB1.Enabled = True
            '    cboBaudRateRB2.Enabled = True

            '    ' Store the relay board setup configuration
            '    RelaySetup = "TwoPorts"

        End If
    End Sub

    Private Sub cmdChangeRelayNamesRB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeRelayNamesRB1.Click

        ' Input the current relay name values into the relay name form
        frmRelayNames = New frmRelayNames

        frmRelayNames.Relay1Name = lblRelay1ValueRB1.Text
        frmRelayNames.Relay2Name = lblRelay2ValueRB1.Text
        frmRelayNames.Relay3Name = lblRelay3ValueRB1.Text
        frmRelayNames.Relay4Name = lblRelay4ValueRB1.Text

        frmRelayNames.ShowDialog()

        ' Get the relay name values from the relay name form and update the corresponding labels
        lblRelay1ValueRB1.Text = frmRelayNames.Relay1Name
        lblRelay2ValueRB1.Text = frmRelayNames.Relay2Name
        lblRelay3ValueRB1.Text = frmRelayNames.Relay3Name
        lblRelay4ValueRB1.Text = frmRelayNames.Relay4Name

        ' Store the Relay Name configuration
        DeviceOneRelayOne = lblRelay1ValueRB1.Text
        DeviceOneRelayTwo = lblRelay2ValueRB1.Text
        DeviceOneRelayThree = lblRelay3ValueRB1.Text
        DeviceOneRelayFour = lblRelay4ValueRB1.Text

        frmRelayNames.Close()
        frmRelayNames = Nothing

    End Sub

    Private Sub cmdChangeRelayNamesRB2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeRelayNamesRB2.Click

        ' Input the current relay name values into the relay name form
        frmRelayNames = New frmRelayNames

        frmRelayNames.Relay1Name = lblRelay1ValueRB2.Text
        frmRelayNames.Relay2Name = lblRelay2ValueRB2.Text
        frmRelayNames.Relay3Name = lblRelay3ValueRB2.Text
        frmRelayNames.Relay4Name = lblRelay4ValueRB2.Text

        frmRelayNames.ShowDialog()

        ' Get the relay name values from the relay name form and update the corresponding labels
        lblRelay1ValueRB2.Text = frmRelayNames.Relay1Name
        lblRelay2ValueRB2.Text = frmRelayNames.Relay2Name
        lblRelay3ValueRB2.Text = frmRelayNames.Relay3Name
        lblRelay4ValueRB2.Text = frmRelayNames.Relay4Name

        ' Store the Relay Name configuration
        DeviceTwoRelayOne = lblRelay1ValueRB2.Text
        DeviceTwoRelayTwo = lblRelay2ValueRB2.Text
        DeviceTwoRelayThree = lblRelay3ValueRB2.Text
        DeviceTwoRelayFour = lblRelay4ValueRB2.Text

        frmRelayNames.Close()
        frmRelayNames = Nothing

    End Sub

    Private Sub cmdAssignDeviceRB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAssignDeviceRB1.Click
        Dim result As Integer
        result = MessageBox.Show("Please make sure that only the device you wish to assign is wired into the RSB Serial Booster before clicking OK.", "Assigned Device Wired in", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        If result = vbOK Then
            frmAssignDevice = New frmAssignDevice
            frmAssignDevice.ChangeNumber = 1
            frmAssignDevice.Text &= 1
            frmAssignDevice.ShowDialog()
        End If

    End Sub

    Private Sub cmdAssignDeviceRB2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAssignDeviceRB2.Click
        Dim result As Integer
        result = MessageBox.Show("Please make sure that only the device you wish to assign is wired into the RSB Serial Booster before clicking OK.", "Assigned Device Wired in", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        If result = vbOK Then
            frmAssignDevice = New frmAssignDevice
            frmAssignDevice.ChangeNumber = 2
            frmAssignDevice.Text &= 2
            frmAssignDevice.ShowDialog()
        End If
    End Sub

    Private Sub cboParallelSerialPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboParallelSerialPort.SelectedIndexChanged
        ' Store the Parallel Com port
        ParallelCom = cboParallelSerialPort.SelectedItem
    End Sub

    Private Sub cboParallelBaudRate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboParallelBaudRate.SelectedIndexChanged
        ' Store the Parallel baud rate
        ParallelBaud = cboParallelBaudRate.SelectedItem
    End Sub

    Private Sub cboSerialPortRB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSerialPortRB1.SelectedIndexChanged
        ' Store the Com port for Port One
        PortOneCom = cboSerialPortRB1.SelectedItem
    End Sub

    Private Sub cboBaudRateRB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBaudRateRB1.SelectedIndexChanged
        ' Store the baud rate for Port One
        PortOneBaud = cboBaudRateRB1.SelectedItem
    End Sub

    Private Sub cboSerialPortRB2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSerialPortRB2.SelectedIndexChanged
        ' Store the Com port for Port Two
        PortTwoCom = cboSerialPortRB2.SelectedItem
    End Sub

    Private Sub cboBaudRateRB2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBaudRateRB2.SelectedIndexChanged
        ' Store the baud rate for Port Two
        PortTwoBaud = cboBaudRateRB2.SelectedItem
    End Sub
End Class