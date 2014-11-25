Imports System.IO.Ports
Imports MSCommLib

Public Class frmDeviceControl

    Private frmRelayConfiguration As frmRelayConfiguration
    Private arrLabels As ArrayList
    Private intTimeout As Integer = 0

    Private Sub frmDeviceControl_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.AllRelaySerialPort.Close()
    End Sub

    Private Sub frmDeviceControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim byteStatus As Byte
        Dim i As Integer
        Dim lblLabel As Windows.Forms.Label
        Dim arrStatus(7) As Integer
        Dim data(3) As Byte

        ' Add all the labels to the arraylist for use later on
        arrLabels = New ArrayList

        arrLabels.Add(Me.lblRelay1)
        arrLabels.Add(Me.lblRelay2)
        arrLabels.Add(Me.lblRelay3)
        arrLabels.Add(Me.lblRelay4)
        arrLabels.Add(Me.lblRelay5)
        arrLabels.Add(Me.lblRelay6)
        arrLabels.Add(Me.lblRelay7)
        arrLabels.Add(Me.lblRelay8)

        ' Open the serial port
        Me.AllRelaySerialPort.Open()

        ' Only enable the relay board with the device number 1
        data(0) = 254
        data(1) = 252
        data(2) = 1
        AllRelaySerialPort.Write(data, 0, 3)

        ' Clear the contents of the command byte and the serial port input buffer
        Array.Clear(data, 0, data.Length)
        AllRelaySerialPort.DiscardInBuffer()

        ' Send the request to read the status of all relays
        data(0) = 254
        data(1) = 24

        Try
            AllRelaySerialPort.Write(data, 0, 2)

            While AllRelaySerialPort.BytesToRead = 0
            End While

            ' Get the byte representing all relay's status
            MsgBox(AllRelaySerialPort.BytesToRead)
            byteStatus = AllRelaySerialPort.ReadByte
            MsgBox(byteStatus)

        Catch ex As TimeoutException
            MessageBox.Show("The read operation has timed out, please check the connection and try again", "Timeout Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

        For i = 0 To 3
            ' Get the status of Relay i
            arrStatus(i) = (byteStatus And CByte((1 << i))) > 0
        Next

        ' Clear the contents of the command byte
        Array.Clear(data, 0, data.Length)

        ' Only enable the relay board with the device number 2
        data(0) = 254
        data(1) = 252
        data(2) = 2
        AllRelaySerialPort.Write(data, 0, 3)

        ' Clear the contents of the command byte and the serial port input buffer
        Array.Clear(data, 0, data.Length)
        AllRelaySerialPort.DiscardInBuffer()
        byteStatus = Nothing

        ' Send the request to read the status of all relays
        data(0) = 254
        data(1) = 24

        Try
            AllRelaySerialPort.Write(data, 0, 2)

            While AllRelaySerialPort.BytesToRead = 0
            End While

            byteStatus = AllRelaySerialPort.ReadByte
        Catch ex As TimeoutException
            MessageBox.Show("The read operation has timed out, please check the connection and try again", "Timeout Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

        For i = 0 To 3
            ' Get the status of Relay i
            arrStatus(i + 4) = (byteStatus And CByte((1 << i))) > 0
        Next

        For i = 0 To 7

            lblLabel = arrLabels.Item(i)

            ' Modify the label according to the status
            If arrStatus(i) = 0 Then
                lblLabel.Text = "OFF"
                lblLabel.ForeColor = Color.Red
            Else
                lblLabel.Text = "ON"
                lblLabel.ForeColor = Color.Green
            End If
        Next

    End Sub

    Private Sub cmdRelayConfiguration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllRelayConfiguration.Click
        frmRelayConfiguration = New frmRelayConfiguration
        frmRelayConfiguration.ShowDialog()
    End Sub

    Private Sub EnableRelayBoard(ByVal intDevice As Integer)

        Dim data(3) As Byte

        ' Only enable the relay board with the device number 1
        data(0) = 254
        data(1) = 252
        data(2) = intDevice
        AllRelaySerialPort.Write(data, 0, 3)

    End Sub

    Private Function GetRelayStatus(ByVal intRelay As Integer) As Integer

        AllRelaySerialPort.DiscardInBuffer()

        Dim data(2) As Byte

        Dim intStatus As Integer
        ' Send the request for the status of the relay
        data(0) = 254
        data(1) = (intRelay + 15)
        Try
            AllRelaySerialPort.Write(data, 0, 2)

ReadBuffer:
            ' Wait for the Read Buffer to be filled
            While AllRelaySerialPort.BytesToRead = 0
            End While

            intStatus = AllRelaySerialPort.ReadByte()
            If intStatus = 85 Then
                GoTo ReadBuffer
            End If

        Catch ex As TimeoutException
            MessageBox.Show("The read operation has timed out, please check the connection and try again", "Timeout Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End Try
        ' Return the value returned by the read buffer
        Return intStatus

    End Function

    Private Sub TurnOnRelay(ByVal intRelay As Integer)

        Dim data(2) As Byte

        ' Turn on the specified relay
        data(0) = 254
        data(1) = (intRelay + 7)

        AllRelaySerialPort.Write(data, 0, 2)
    End Sub

    Private Sub TurnOffRelay(ByVal intRelay As Integer)

        Dim data(2) As Byte

        ' Turn off the specified relay
        data(0) = 254
        data(1) = (intRelay - 1)

        AllRelaySerialPort.Write(data, 0, 2)

    End Sub

    Private Sub cmdToggleRelay1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleRelay1.Click

        EnableRelayBoard(1)

        ' Get the status of Relay 1
        Dim intStatus As Integer
        intStatus = GetRelayStatus(1)

        If intStatus = 0 Then
            ' Turn on Relay 1
            TurnOnRelay(1)
        Else
            TurnOffRelay(1)
        End If

        ' Get the status of Relay 1
        intStatus = GetRelayStatus(1)

        ' Modify the label according to the status
        If intStatus = 0 Then
            Me.lblRelay1.Text = "OFF"
            Me.lblRelay1.ForeColor = Color.Red
        Else
            Me.lblRelay1.Text = "ON"
            Me.lblRelay1.ForeColor = Color.Green
        End If

    End Sub

    Private Sub cmdToggleRelay2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleRelay2.Click

        EnableRelayBoard(1)

        ' Get the status of Relay 2
        Dim intStatus As Integer
        intStatus = GetRelayStatus(2)

        If intStatus = 0 Then
            ' Turn on Relay 2
            TurnOnRelay(2)
        Else
            TurnOffRelay(2)
        End If

        ' Get the status of Relay 2
        intStatus = GetRelayStatus(2)

        ' Modify the label according to the status
        If intStatus = 0 Then
            Me.lblRelay2.Text = "OFF"
            Me.lblRelay2.ForeColor = Color.Red
        Else
            Me.lblRelay2.Text = "ON"
            Me.lblRelay2.ForeColor = Color.Green
        End If

    End Sub

    Private Sub cmdToggleRelay3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleRelay3.Click

        EnableRelayBoard(1)

        ' Get the status of Relay 3
        Dim intStatus As Integer
        intStatus = GetRelayStatus(3)

        If intStatus = 0 Then
            ' Turn on Relay 3
            TurnOnRelay(3)
        Else
            TurnOffRelay(3)
        End If

        ' Get the status of Relay 3
        intStatus = GetRelayStatus(3)

        ' Modify the label according to the status
        If intStatus = 0 Then
            Me.lblRelay3.Text = "OFF"
            Me.lblRelay3.ForeColor = Color.Red
        Else
            Me.lblRelay3.Text = "ON"
            Me.lblRelay3.ForeColor = Color.Green
        End If

    End Sub

    Private Sub cmdToggleRelay4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleRelay4.Click

        EnableRelayBoard(1)

        ' Get the status of Relay 4
        Dim intStatus As Integer
        intStatus = GetRelayStatus(4)

        If intStatus = 0 Then
            ' Turn on Relay 4
            TurnOnRelay(4)
        Else
            TurnOffRelay(4)
        End If

        ' Get the status of Relay 4
        intStatus = GetRelayStatus(4)

        ' Modify the label according to the status
        If intStatus = 0 Then
            Me.lblRelay4.Text = "OFF"
            Me.lblRelay4.ForeColor = Color.Red
        Else
            Me.lblRelay4.Text = "ON"
            Me.lblRelay4.ForeColor = Color.Green
        End If

    End Sub

    Private Sub cmdToggleRelay5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleRelay5.Click

        EnableRelayBoard(2)

        ' Get the status of Relay 1
        Dim intStatus As Integer
        intStatus = GetRelayStatus(1)

        If intStatus = 0 Then
            ' Turn on Relay 1
            TurnOnRelay(1)
        Else
            TurnOffRelay(1)
        End If

        ' Get the status of Relay 1
        intStatus = GetRelayStatus(1)

        ' Modify the label according to the status
        If intStatus = 0 Then
            Me.lblRelay5.Text = "OFF"
            Me.lblRelay5.ForeColor = Color.Red
        Else
            Me.lblRelay5.Text = "ON"
            Me.lblRelay5.ForeColor = Color.Green
        End If

    End Sub

    Private Sub cmdToggleRelay6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleRelay6.Click
        EnableRelayBoard(2)

        ' Get the status of Relay 2
        Dim intStatus As Integer
        intStatus = GetRelayStatus(2)

        If intStatus = 0 Then
            ' Turn on Relay 2
            TurnOnRelay(2)
        Else
            TurnOffRelay(2)
        End If

        ' Get the status of Relay 2
        intStatus = GetRelayStatus(2)

        ' Modify the label according to the status
        If intStatus = 0 Then
            Me.lblRelay6.Text = "OFF"
            Me.lblRelay6.ForeColor = Color.Red
        Else
            Me.lblRelay6.Text = "ON"
            Me.lblRelay6.ForeColor = Color.Green
        End If
    End Sub

    Private Sub cmdToggleRelay7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleRelay7.Click
        EnableRelayBoard(2)

        ' Get the status of Relay 3
        Dim intStatus As Integer
        intStatus = GetRelayStatus(3)

        If intStatus = 0 Then
            ' Turn on Relay 3
            TurnOnRelay(3)
        Else
            TurnOffRelay(3)
        End If

        ' Get the status of Relay 3
        intStatus = GetRelayStatus(3)

        ' Modify the label according to the status
        If intStatus = 0 Then
            Me.lblRelay7.Text = "OFF"
            Me.lblRelay7.ForeColor = Color.Red
        Else
            Me.lblRelay7.Text = "ON"
            Me.lblRelay7.ForeColor = Color.Green
        End If
    End Sub

    Private Sub cmdToggleRelay8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleRelay8.Click
        EnableRelayBoard(2)

        ' Get the status of Relay 4
        Dim intStatus As Integer
        intStatus = GetRelayStatus(4)

        If intStatus = 0 Then
            ' Turn on Relay 4
            TurnOnRelay(4)
        Else
            TurnOffRelay(4)
        End If

        ' Get the status of Relay 4
        intStatus = GetRelayStatus(4)

        ' Modify the label according to the status
        If intStatus = 0 Then
            Me.lblRelay8.Text = "OFF"
            Me.lblRelay8.ForeColor = Color.Red
        Else
            Me.lblRelay8.Text = "ON"
            Me.lblRelay8.ForeColor = Color.Green
        End If
    End Sub

    Private Sub cmdToggleAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleAll.Click

        Dim data(3) As Byte
        Dim byteStatus
        Dim arrStatus(7) As Integer
        Dim i As Integer
        Dim lblLabel As Windows.Forms.Label


        ' Only enable the relay board with the device number 1
        data(0) = 254
        data(1) = 252
        data(2) = 1
        AllRelaySerialPort.Write(data, 0, 3)

        ' Clear the contents of the command byte and the serial port input buffer
        Array.Clear(data, 0, data.Length)
        AllRelaySerialPort.DiscardInBuffer()

        ' Invert the status of all relays on device number 1
        data(0) = 254
        data(1) = 31

        AllRelaySerialPort.Write(data, 0, 2)

        ' Clear the contents of the command byte
        Array.Clear(data, 0, data.Length)

        ' Send the request to read the status of all relays
        data(0) = 254
        data(1) = 24

        Try
            AllRelaySerialPort.Write(data, 0, 2)

            While AllRelaySerialPort.BytesToRead = 0
            End While

            ' Get the byte representing all relay's status
            'MsgBox(AllRelaySerialPort.BytesToRead)
            byteStatus = AllRelaySerialPort.ReadByte
            'MsgBox(byteStatus)

        Catch ex As TimeoutException
            MessageBox.Show("The read operation has timed out, please check the connection and try again", "Timeout Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        For i = 0 To 3
            ' Get the status of Relay i
            arrStatus(i) = (byteStatus And CByte((1 << i))) > 0
        Next

        ' Clear the contents of the command byte
        Array.Clear(data, 0, data.Length)

        ' Only enable the relay board with the device number 2
        data(0) = 254
        data(1) = 252
        data(2) = 2
        AllRelaySerialPort.Write(data, 0, 3)

        ' Clear the contents of the command byte and the serial port input buffer
        Array.Clear(data, 0, data.Length)
        AllRelaySerialPort.DiscardInBuffer()
        byteStatus = Nothing

        ' Invert the status of all relays on device number 2
        data(0) = 254
        data(1) = 31

        AllRelaySerialPort.Write(data, 0, 2)

        ' Clear the contents of the command byte
        Array.Clear(data, 0, data.Length)

        ' Send the request to read the status of all relays
        data(0) = 254
        data(1) = 24

        Try
            AllRelaySerialPort.Write(data, 0, 2)

            While AllRelaySerialPort.BytesToRead = 0
            End While

            byteStatus = AllRelaySerialPort.ReadByte
        Catch ex As TimeoutException
            MessageBox.Show("The read operation has timed out, please check the connection and try again", "Timeout Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        For i = 0 To 3
            ' Get the status of Relay i
            arrStatus(i + 4) = (byteStatus And CByte((1 << i))) > 0
        Next

        For i = 0 To 7

            lblLabel = arrLabels.Item(i)

            ' Modify the label according to the status
            If arrStatus(i) = 0 Then
                lblLabel.Text = "OFF"
                lblLabel.ForeColor = Color.Red
            Else
                lblLabel.Text = "ON"
                lblLabel.ForeColor = Color.Green
            End If
        Next


    End Sub
End Class