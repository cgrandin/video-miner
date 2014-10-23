Imports System.IO.Ports

Public Class frmRelayConfiguration

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

    Private Sub frmRelayConfiguration_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myFormLibrary.frmRelayConfiguration = Nothing
    End Sub

    Private Sub frmRelayConfiguration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myFormLibrary.frmRelayConfiguration = Me

        Dim strPorts As String()
        Dim strPort As String

        Me.cboRelayBoardSetup.Items.Add("Wired in Parallel to One COM Port")
        'Me.cboRelayBoardSetup.Items.Add("Wired Separately to Two COM Ports")


        ' Get all available Ports on the computer
        strPorts = SerialPort.GetPortNames
        For Each strPort In strPorts
            Me.cboSerialPortRB1.Items.Add(strPort)
            Me.cboSerialPortRB2.Items.Add(strPort)
            Me.cboParallelSerialPort.Items.Add(strPort)
        Next

        ' Add the available Baud Rates to all comboboxes
        Me.cboBaudRateRB1.Items.Add("1200")
        Me.cboBaudRateRB1.Items.Add("2400")
        Me.cboBaudRateRB1.Items.Add("9600")
        Me.cboBaudRateRB1.Items.Add("19200")

        Me.cboBaudRateRB2.Items.Add("1200")
        Me.cboBaudRateRB2.Items.Add("2400")
        Me.cboBaudRateRB2.Items.Add("9600")
        Me.cboBaudRateRB2.Items.Add("19200")

        Me.cboParallelBaudRate.Items.Add("1200")
        Me.cboParallelBaudRate.Items.Add("2400")
        Me.cboParallelBaudRate.Items.Add("9600")
        Me.cboParallelBaudRate.Items.Add("19200")

        ' Select the combobox items based off of the configuration file
        If Me.RelaySetup = "Parallel" Then
            Me.cboRelayBoardSetup.SelectedIndex = 0
        Else
            Me.cboRelayBoardSetup.SelectedIndex = 1
        End If

        Me.cboParallelSerialPort.SelectedItem = Me.ParallelCom
        Me.cboParallelBaudRate.SelectedItem = CStr(Me.ParallelBaud)
        Me.cboSerialPortRB1.SelectedItem = Me.PortOneCom
        Me.cboSerialPortRB2.SelectedItem = Me.PortTwoCom
        Me.cboBaudRateRB1.SelectedItem = CStr(Me.PortOneBaud)
        Me.cboBaudRateRB2.SelectedItem = CStr(Me.PortTwoBaud)

        ' Modify the label text properties based on the relay names found in the configuration file
        Me.lblRelay1ValueRB1.Text = Me.DeviceOneRelayOne
        Me.lblRelay2ValueRB1.Text = Me.DeviceOneRelayTwo
        Me.lblRelay3ValueRB1.Text = Me.DeviceOneRelayThree
        Me.lblRelay4ValueRB1.Text = Me.DeviceOneRelayFour
        Me.lblRelay1ValueRB2.Text = Me.DeviceTwoRelayOne
        Me.lblRelay2ValueRB2.Text = Me.DeviceTwoRelayTwo
        Me.lblRelay3ValueRB2.Text = Me.DeviceTwoRelayThree
        Me.lblRelay4ValueRB2.Text = Me.DeviceTwoRelayFour

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        ' Store the configuration as set
        Me.ConfigurationSet = True

        myFormLibrary.frmVideoMiner.ConfigurationSet = Me.ConfigurationSet
        myFormLibrary.frmVideoMiner.RelaySetup = Me.RelaySetup
        myFormLibrary.frmVideoMiner.ParallelCom = Me.ParallelCom
        myFormLibrary.frmVideoMiner.ParallelBaud = Me.ParallelBaud
        ' FINISH ME HERE

        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cboRelayBoardSetup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRelayBoardSetup.SelectedIndexChanged

        ' If the selected item is Wired in Parallel then enable/disable the appropriate controls
        If Me.cboRelayBoardSetup.SelectedIndex = 0 Then

            Me.cboParallelSerialPort.Enabled = True
            Me.cboParallelBaudRate.Enabled = True
            Me.cmdAssignDeviceRB1.Enabled = True
            Me.cmdAssignDeviceRB2.Enabled = True

            Me.cboSerialPortRB1.Enabled = False
            Me.cboSerialPortRB2.Enabled = False
            Me.cboBaudRateRB1.Enabled = False
            Me.cboBaudRateRB2.Enabled = False

            ' Store the relay board setup configuration
            Me.RelaySetup = "Parallel"

            'Else    ' Else enable/disable the opposite

            '    Me.cboParallelSerialPort.Enabled = False
            '    Me.cboParallelBaudRate.Enabled = False
            '    Me.cmdAssignDeviceRB1.Enabled = False
            '    Me.cmdAssignDeviceRB2.Enabled = False

            '    Me.cboSerialPortRB1.Enabled = True
            '    Me.cboSerialPortRB2.Enabled = True
            '    Me.cboBaudRateRB1.Enabled = True
            '    Me.cboBaudRateRB2.Enabled = True

            '    ' Store the relay board setup configuration
            '    Me.RelaySetup = "TwoPorts"

        End If
    End Sub

    Private Sub cmdChangeRelayNamesRB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeRelayNamesRB1.Click

        ' Input the current relay name values into the relay name form
        myFormLibrary.frmRelayNames = New frmRelayNames

        myFormLibrary.frmRelayNames.Relay1Name = Me.lblRelay1ValueRB1.Text
        myFormLibrary.frmRelayNames.Relay2Name = Me.lblRelay2ValueRB1.Text
        myFormLibrary.frmRelayNames.Relay3Name = Me.lblRelay3ValueRB1.Text
        myFormLibrary.frmRelayNames.Relay4Name = Me.lblRelay4ValueRB1.Text

        myFormLibrary.frmRelayNames.ShowDialog()

        ' Get the relay name values from the relay name form and update the corresponding labels
        Me.lblRelay1ValueRB1.Text = myFormLibrary.frmRelayNames.Relay1Name
        Me.lblRelay2ValueRB1.Text = myFormLibrary.frmRelayNames.Relay2Name
        Me.lblRelay3ValueRB1.Text = myFormLibrary.frmRelayNames.Relay3Name
        Me.lblRelay4ValueRB1.Text = myFormLibrary.frmRelayNames.Relay4Name

        ' Store the Relay Name configuration
        Me.DeviceOneRelayOne = Me.lblRelay1ValueRB1.Text
        Me.DeviceOneRelayTwo = Me.lblRelay2ValueRB1.Text
        Me.DeviceOneRelayThree = Me.lblRelay3ValueRB1.Text
        Me.DeviceOneRelayFour = Me.lblRelay4ValueRB1.Text

        myFormLibrary.frmRelayNames.Close()
        myFormLibrary.frmRelayNames = Nothing

    End Sub

    Private Sub cmdChangeRelayNamesRB2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeRelayNamesRB2.Click

        ' Input the current relay name values into the relay name form
        myFormLibrary.frmRelayNames = New frmRelayNames

        myFormLibrary.frmRelayNames.Relay1Name = Me.lblRelay1ValueRB2.Text
        myFormLibrary.frmRelayNames.Relay2Name = Me.lblRelay2ValueRB2.Text
        myFormLibrary.frmRelayNames.Relay3Name = Me.lblRelay3ValueRB2.Text
        myFormLibrary.frmRelayNames.Relay4Name = Me.lblRelay4ValueRB2.Text

        myFormLibrary.frmRelayNames.ShowDialog()

        ' Get the relay name values from the relay name form and update the corresponding labels
        Me.lblRelay1ValueRB2.Text = myFormLibrary.frmRelayNames.Relay1Name
        Me.lblRelay2ValueRB2.Text = myFormLibrary.frmRelayNames.Relay2Name
        Me.lblRelay3ValueRB2.Text = myFormLibrary.frmRelayNames.Relay3Name
        Me.lblRelay4ValueRB2.Text = myFormLibrary.frmRelayNames.Relay4Name

        ' Store the Relay Name configuration
        Me.DeviceTwoRelayOne = Me.lblRelay1ValueRB2.Text
        Me.DeviceTwoRelayTwo = Me.lblRelay2ValueRB2.Text
        Me.DeviceTwoRelayThree = Me.lblRelay3ValueRB2.Text
        Me.DeviceTwoRelayFour = Me.lblRelay4ValueRB2.Text

        myFormLibrary.frmRelayNames.Close()
        myFormLibrary.frmRelayNames = Nothing

    End Sub

    Private Sub cmdAssignDeviceRB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAssignDeviceRB1.Click
        Dim result As Integer
        result = MessageBox.Show("Please make sure that only the device you wish to assign is wired into the RSB Serial Booster before clicking OK.", "Assigned Device Wired in", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        If result = vbOK Then
            myFormLibrary.frmAssignDevice = New frmAssignDevice
            myFormLibrary.frmAssignDevice.ChangeNumber = 1
            myFormLibrary.frmAssignDevice.Text &= 1
            myFormLibrary.frmAssignDevice.ShowDialog()
        End If

    End Sub

    Private Sub cmdAssignDeviceRB2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAssignDeviceRB2.Click
        Dim result As Integer
        result = MessageBox.Show("Please make sure that only the device you wish to assign is wired into the RSB Serial Booster before clicking OK.", "Assigned Device Wired in", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        If result = vbOK Then
            myFormLibrary.frmAssignDevice = New frmAssignDevice
            myFormLibrary.frmAssignDevice.ChangeNumber = 2
            myFormLibrary.frmAssignDevice.Text &= 2
            myFormLibrary.frmAssignDevice.ShowDialog()
        End If
    End Sub

    Private Sub cboParallelSerialPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboParallelSerialPort.SelectedIndexChanged
        ' Store the Parallel Com port
        Me.ParallelCom = Me.cboParallelSerialPort.SelectedItem
    End Sub

    Private Sub cboParallelBaudRate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboParallelBaudRate.SelectedIndexChanged
        ' Store the Parallel baud rate
        Me.ParallelBaud = Me.cboParallelBaudRate.SelectedItem
    End Sub

    Private Sub cboSerialPortRB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSerialPortRB1.SelectedIndexChanged
        ' Store the Com port for Port One
        Me.PortOneCom = Me.cboSerialPortRB1.SelectedItem
    End Sub

    Private Sub cboBaudRateRB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBaudRateRB1.SelectedIndexChanged
        ' Store the baud rate for Port One
        Me.PortOneBaud = Me.cboBaudRateRB1.SelectedItem
    End Sub

    Private Sub cboSerialPortRB2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSerialPortRB2.SelectedIndexChanged
        ' Store the Com port for Port Two
        Me.PortTwoCom = Me.cboSerialPortRB2.SelectedItem
    End Sub

    Private Sub cboBaudRateRB2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBaudRateRB2.SelectedIndexChanged
        ' Store the baud rate for Port Two
        Me.PortTwoBaud = Me.cboBaudRateRB2.SelectedItem
    End Sub
End Class