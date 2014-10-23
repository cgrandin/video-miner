Public Class frmAssignDevice

    Private m_ChangeNumber As Integer

    Public Property ChangeNumber() As Integer
        Get
            Return m_ChangeNumber
        End Get
        Set(ByVal value As Integer)
            m_ChangeNumber = value
        End Set
    End Property

    Private Sub frmAssignDevice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        AssignSerialPort.Close()
        myFormLibrary.frmAssignDevice = Nothing
    End Sub

    Private Sub frmAssignDevice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myFormLibrary.frmAssignDevice = Me

        Dim data(2) As Byte
        Dim intDeviceNumber As Integer
        Dim serPort As System.IO.Ports.SerialPort
        serPort = Me.AssignSerialPort
        serPort.Open()

        Me.cmdChange.Text = Me.cmdChange.Text & Me.ChangeNumber


        ' Request the device number from the device currently wired into the serial port booster
        data(0) = 254
        data(1) = 247
        Try
            serPort.Write(data, 0, 2)

            While serPort.BytesToRead = 0
            End While

            ' Read the device number from the serial port
            intDeviceNumber = serPort.ReadByte

        Catch ex As TimeoutException

            MessageBox.Show("Could not read the device number from the wired device.   Check the wiring configuration and make sure the Data Out jumper is set to OC.", "Device Timeout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

        ' Set the device number label to the device number
        Me.lblDeviceNumber.Text = intDeviceNumber


    End Sub

    Private Sub cmdKeepConfiguration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKeepConfiguration.Click
        ' Close the form as the device number does not need to be changed
        Me.Close()
    End Sub

    Private Sub cmdChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChange.Click
        Dim serPort As System.IO.Ports.SerialPort
        serPort = Me.AssignSerialPort

        Dim data(3) As Byte

        data(0) = 254
        data(1) = 255
        data(2) = Me.ChangeNumber

        serPort.Write(data, 0, 3)

        serPort.DiscardInBuffer()

        'While serPort.BytesToRead = 0
        'End While

        MessageBox.Show("The device number has been changed successfully", "Device Number Changed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Me.Close()

    End Sub
End Class