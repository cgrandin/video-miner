<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelayConfiguration
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        cboSerialPortRB1 = New System.Windows.Forms.ComboBox
        cboBaudRateRB1 = New System.Windows.Forms.ComboBox
        lblSerialPortRB1 = New System.Windows.Forms.Label
        lblBaudRateRB1 = New System.Windows.Forms.Label
        cmdOK = New System.Windows.Forms.Button
        cmdCancel = New System.Windows.Forms.Button
        cboRelayBoardSetup = New System.Windows.Forms.ComboBox
        lblRelayBoardSetup = New System.Windows.Forms.Label
        lblRelayBoard1 = New System.Windows.Forms.Label
        lblRelayBoard2 = New System.Windows.Forms.Label
        cboSerialPortRB2 = New System.Windows.Forms.ComboBox
        cboBaudRateRB2 = New System.Windows.Forms.ComboBox
        lblSerialPortRB2 = New System.Windows.Forms.Label
        lblBaudRateRB2 = New System.Windows.Forms.Label
        lblRelay1NameRB1 = New System.Windows.Forms.Label
        lblRelay2NameRB1 = New System.Windows.Forms.Label
        lblRelay3NameRB1 = New System.Windows.Forms.Label
        lblRelay4NameRB1 = New System.Windows.Forms.Label
        cmdChangeRelayNamesRB1 = New System.Windows.Forms.Button
        lblRelay1ValueRB1 = New System.Windows.Forms.Label
        lblRelay2ValueRB1 = New System.Windows.Forms.Label
        lblRelay3ValueRB1 = New System.Windows.Forms.Label
        lblRelay4ValueRB1 = New System.Windows.Forms.Label
        lblRelay1NameRB2 = New System.Windows.Forms.Label
        lblRelay2NameRB2 = New System.Windows.Forms.Label
        lblRelay3NameRB2 = New System.Windows.Forms.Label
        lblRelay4NameRB2 = New System.Windows.Forms.Label
        cmdChangeRelayNamesRB2 = New System.Windows.Forms.Button
        lblRelay1ValueRB2 = New System.Windows.Forms.Label
        lblRelay2ValueRB2 = New System.Windows.Forms.Label
        lblRelay3ValueRB2 = New System.Windows.Forms.Label
        lblRelay4ValueRB2 = New System.Windows.Forms.Label
        cboParallelSerialPort = New System.Windows.Forms.ComboBox
        cboParallelBaudRate = New System.Windows.Forms.ComboBox
        lblParallelSerialPort = New System.Windows.Forms.Label
        lblParallelBaudRate = New System.Windows.Forms.Label
        cmdAssignDeviceRB1 = New System.Windows.Forms.Button
        cmdAssignDeviceRB2 = New System.Windows.Forms.Button
        SuspendLayout()
        '
        'cboSerialPortRB1
        '
        cboSerialPortRB1.FormattingEnabled = True
        cboSerialPortRB1.Location = New System.Drawing.Point(86, 160)
        cboSerialPortRB1.Name = "cboSerialPortRB1"
        cboSerialPortRB1.Size = New System.Drawing.Size(89, 21)
        cboSerialPortRB1.Sorted = True
        cboSerialPortRB1.TabIndex = 0
        '
        'cboBaudRateRB1
        '
        cboBaudRateRB1.FormattingEnabled = True
        cboBaudRateRB1.Location = New System.Drawing.Point(86, 187)
        cboBaudRateRB1.Name = "cboBaudRateRB1"
        cboBaudRateRB1.Size = New System.Drawing.Size(89, 21)
        cboBaudRateRB1.TabIndex = 1
        '
        'lblSerialPortRB1
        '
        lblSerialPortRB1.AutoSize = True
        lblSerialPortRB1.Location = New System.Drawing.Point(16, 163)
        lblSerialPortRB1.Name = "lblSerialPortRB1"
        lblSerialPortRB1.Size = New System.Drawing.Size(58, 13)
        lblSerialPortRB1.TabIndex = 3
        lblSerialPortRB1.Text = "Serial Port:"
        '
        'lblBaudRateRB1
        '
        lblBaudRateRB1.AutoSize = True
        lblBaudRateRB1.Location = New System.Drawing.Point(16, 190)
        lblBaudRateRB1.Name = "lblBaudRateRB1"
        lblBaudRateRB1.Size = New System.Drawing.Size(61, 13)
        lblBaudRateRB1.TabIndex = 3
        lblBaudRateRB1.Text = "Baud Rate:"
        '
        'cmdOK
        '
        cmdOK.Location = New System.Drawing.Point(121, 414)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(75, 23)
        cmdOK.TabIndex = 5
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        cmdCancel.Location = New System.Drawing.Point(202, 414)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New System.Drawing.Size(75, 23)
        cmdCancel.TabIndex = 5
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        '
        'cboRelayBoardSetup
        '
        cboRelayBoardSetup.FormattingEnabled = True
        cboRelayBoardSetup.Location = New System.Drawing.Point(121, 28)
        cboRelayBoardSetup.Name = "cboRelayBoardSetup"
        cboRelayBoardSetup.Size = New System.Drawing.Size(254, 21)
        cboRelayBoardSetup.TabIndex = 6
        '
        'lblRelayBoardSetup
        '
        lblRelayBoardSetup.AutoSize = True
        lblRelayBoardSetup.Location = New System.Drawing.Point(16, 31)
        lblRelayBoardSetup.Name = "lblRelayBoardSetup"
        lblRelayBoardSetup.Size = New System.Drawing.Size(99, 13)
        lblRelayBoardSetup.TabIndex = 7
        lblRelayBoardSetup.Text = "Relay Board Setup:"
        '
        'lblRelayBoard1
        '
        lblRelayBoard1.AutoSize = True
        lblRelayBoard1.Location = New System.Drawing.Point(16, 132)
        lblRelayBoard1.Name = "lblRelayBoard1"
        lblRelayBoard1.Size = New System.Drawing.Size(74, 13)
        lblRelayBoard1.TabIndex = 8
        lblRelayBoard1.Text = "Relay Board 1"
        '
        'lblRelayBoard2
        '
        lblRelayBoard2.AutoSize = True
        lblRelayBoard2.Location = New System.Drawing.Point(238, 132)
        lblRelayBoard2.Name = "lblRelayBoard2"
        lblRelayBoard2.Size = New System.Drawing.Size(74, 13)
        lblRelayBoard2.TabIndex = 8
        lblRelayBoard2.Text = "Relay Board 2"
        '
        'cboSerialPortRB2
        '
        cboSerialPortRB2.FormattingEnabled = True
        cboSerialPortRB2.Location = New System.Drawing.Point(308, 160)
        cboSerialPortRB2.Name = "cboSerialPortRB2"
        cboSerialPortRB2.Size = New System.Drawing.Size(89, 21)
        cboSerialPortRB2.Sorted = True
        cboSerialPortRB2.TabIndex = 0
        '
        'cboBaudRateRB2
        '
        cboBaudRateRB2.FormattingEnabled = True
        cboBaudRateRB2.Location = New System.Drawing.Point(308, 187)
        cboBaudRateRB2.Name = "cboBaudRateRB2"
        cboBaudRateRB2.Size = New System.Drawing.Size(89, 21)
        cboBaudRateRB2.TabIndex = 1
        '
        'lblSerialPortRB2
        '
        lblSerialPortRB2.AutoSize = True
        lblSerialPortRB2.Location = New System.Drawing.Point(238, 163)
        lblSerialPortRB2.Name = "lblSerialPortRB2"
        lblSerialPortRB2.Size = New System.Drawing.Size(58, 13)
        lblSerialPortRB2.TabIndex = 3
        lblSerialPortRB2.Text = "Serial Port:"
        '
        'lblBaudRateRB2
        '
        lblBaudRateRB2.AutoSize = True
        lblBaudRateRB2.Location = New System.Drawing.Point(238, 190)
        lblBaudRateRB2.Name = "lblBaudRateRB2"
        lblBaudRateRB2.Size = New System.Drawing.Size(61, 13)
        lblBaudRateRB2.TabIndex = 3
        lblBaudRateRB2.Text = "Baud Rate:"
        '
        'lblRelay1NameRB1
        '
        lblRelay1NameRB1.AutoSize = True
        lblRelay1NameRB1.Location = New System.Drawing.Point(16, 250)
        lblRelay1NameRB1.Name = "lblRelay1NameRB1"
        lblRelay1NameRB1.Size = New System.Drawing.Size(77, 13)
        lblRelay1NameRB1.TabIndex = 9
        lblRelay1NameRB1.Text = "Relay 1 Name:"
        '
        'lblRelay2NameRB1
        '
        lblRelay2NameRB1.AutoSize = True
        lblRelay2NameRB1.Location = New System.Drawing.Point(16, 276)
        lblRelay2NameRB1.Name = "lblRelay2NameRB1"
        lblRelay2NameRB1.Size = New System.Drawing.Size(77, 13)
        lblRelay2NameRB1.TabIndex = 9
        lblRelay2NameRB1.Text = "Relay 2 Name:"
        '
        'lblRelay3NameRB1
        '
        lblRelay3NameRB1.AutoSize = True
        lblRelay3NameRB1.Location = New System.Drawing.Point(16, 304)
        lblRelay3NameRB1.Name = "lblRelay3NameRB1"
        lblRelay3NameRB1.Size = New System.Drawing.Size(77, 13)
        lblRelay3NameRB1.TabIndex = 9
        lblRelay3NameRB1.Text = "Relay 3 Name:"
        '
        'lblRelay4NameRB1
        '
        lblRelay4NameRB1.AutoSize = True
        lblRelay4NameRB1.Location = New System.Drawing.Point(16, 331)
        lblRelay4NameRB1.Name = "lblRelay4NameRB1"
        lblRelay4NameRB1.Size = New System.Drawing.Size(77, 13)
        lblRelay4NameRB1.TabIndex = 9
        lblRelay4NameRB1.Text = "Relay 4 Name:"
        '
        'cmdChangeRelayNamesRB1
        '
        cmdChangeRelayNamesRB1.Location = New System.Drawing.Point(19, 364)
        cmdChangeRelayNamesRB1.Name = "cmdChangeRelayNamesRB1"
        cmdChangeRelayNamesRB1.Size = New System.Drawing.Size(123, 21)
        cmdChangeRelayNamesRB1.TabIndex = 10
        cmdChangeRelayNamesRB1.Text = "Change Relay Names"
        cmdChangeRelayNamesRB1.UseVisualStyleBackColor = True
        '
        'lblRelay1ValueRB1
        '
        lblRelay1ValueRB1.AutoSize = True
        lblRelay1ValueRB1.Location = New System.Drawing.Point(99, 250)
        lblRelay1ValueRB1.Name = "lblRelay1ValueRB1"
        lblRelay1ValueRB1.Size = New System.Drawing.Size(43, 13)
        lblRelay1ValueRB1.TabIndex = 11
        lblRelay1ValueRB1.Text = "Relay 1"
        '
        'lblRelay2ValueRB1
        '
        lblRelay2ValueRB1.AutoSize = True
        lblRelay2ValueRB1.Location = New System.Drawing.Point(99, 276)
        lblRelay2ValueRB1.Name = "lblRelay2ValueRB1"
        lblRelay2ValueRB1.Size = New System.Drawing.Size(43, 13)
        lblRelay2ValueRB1.TabIndex = 11
        lblRelay2ValueRB1.Text = "Relay 2"
        '
        'lblRelay3ValueRB1
        '
        lblRelay3ValueRB1.AutoSize = True
        lblRelay3ValueRB1.Location = New System.Drawing.Point(99, 304)
        lblRelay3ValueRB1.Name = "lblRelay3ValueRB1"
        lblRelay3ValueRB1.Size = New System.Drawing.Size(43, 13)
        lblRelay3ValueRB1.TabIndex = 11
        lblRelay3ValueRB1.Text = "Relay 3"
        '
        'lblRelay4ValueRB1
        '
        lblRelay4ValueRB1.AutoSize = True
        lblRelay4ValueRB1.Location = New System.Drawing.Point(99, 331)
        lblRelay4ValueRB1.Name = "lblRelay4ValueRB1"
        lblRelay4ValueRB1.Size = New System.Drawing.Size(43, 13)
        lblRelay4ValueRB1.TabIndex = 11
        lblRelay4ValueRB1.Text = "Relay 4"
        '
        'lblRelay1NameRB2
        '
        lblRelay1NameRB2.AutoSize = True
        lblRelay1NameRB2.Location = New System.Drawing.Point(238, 250)
        lblRelay1NameRB2.Name = "lblRelay1NameRB2"
        lblRelay1NameRB2.Size = New System.Drawing.Size(77, 13)
        lblRelay1NameRB2.TabIndex = 9
        lblRelay1NameRB2.Text = "Relay 1 Name:"
        '
        'lblRelay2NameRB2
        '
        lblRelay2NameRB2.AutoSize = True
        lblRelay2NameRB2.Location = New System.Drawing.Point(238, 276)
        lblRelay2NameRB2.Name = "lblRelay2NameRB2"
        lblRelay2NameRB2.Size = New System.Drawing.Size(77, 13)
        lblRelay2NameRB2.TabIndex = 9
        lblRelay2NameRB2.Text = "Relay 2 Name:"
        '
        'lblRelay3NameRB2
        '
        lblRelay3NameRB2.AutoSize = True
        lblRelay3NameRB2.Location = New System.Drawing.Point(238, 304)
        lblRelay3NameRB2.Name = "lblRelay3NameRB2"
        lblRelay3NameRB2.Size = New System.Drawing.Size(77, 13)
        lblRelay3NameRB2.TabIndex = 9
        lblRelay3NameRB2.Text = "Relay 3 Name:"
        '
        'lblRelay4NameRB2
        '
        lblRelay4NameRB2.AutoSize = True
        lblRelay4NameRB2.Location = New System.Drawing.Point(238, 331)
        lblRelay4NameRB2.Name = "lblRelay4NameRB2"
        lblRelay4NameRB2.Size = New System.Drawing.Size(77, 13)
        lblRelay4NameRB2.TabIndex = 9
        lblRelay4NameRB2.Text = "Relay 4 Name:"
        '
        'cmdChangeRelayNamesRB2
        '
        cmdChangeRelayNamesRB2.Location = New System.Drawing.Point(241, 364)
        cmdChangeRelayNamesRB2.Name = "cmdChangeRelayNamesRB2"
        cmdChangeRelayNamesRB2.Size = New System.Drawing.Size(123, 21)
        cmdChangeRelayNamesRB2.TabIndex = 10
        cmdChangeRelayNamesRB2.Text = "Change Relay Names"
        cmdChangeRelayNamesRB2.UseVisualStyleBackColor = True
        '
        'lblRelay1ValueRB2
        '
        lblRelay1ValueRB2.AutoSize = True
        lblRelay1ValueRB2.Location = New System.Drawing.Point(321, 250)
        lblRelay1ValueRB2.Name = "lblRelay1ValueRB2"
        lblRelay1ValueRB2.Size = New System.Drawing.Size(43, 13)
        lblRelay1ValueRB2.TabIndex = 11
        lblRelay1ValueRB2.Text = "Relay 1"
        '
        'lblRelay2ValueRB2
        '
        lblRelay2ValueRB2.AutoSize = True
        lblRelay2ValueRB2.Location = New System.Drawing.Point(321, 276)
        lblRelay2ValueRB2.Name = "lblRelay2ValueRB2"
        lblRelay2ValueRB2.Size = New System.Drawing.Size(43, 13)
        lblRelay2ValueRB2.TabIndex = 11
        lblRelay2ValueRB2.Text = "Relay 2"
        '
        'lblRelay3ValueRB2
        '
        lblRelay3ValueRB2.AutoSize = True
        lblRelay3ValueRB2.Location = New System.Drawing.Point(321, 304)
        lblRelay3ValueRB2.Name = "lblRelay3ValueRB2"
        lblRelay3ValueRB2.Size = New System.Drawing.Size(43, 13)
        lblRelay3ValueRB2.TabIndex = 11
        lblRelay3ValueRB2.Text = "Relay 3"
        '
        'lblRelay4ValueRB2
        '
        lblRelay4ValueRB2.AutoSize = True
        lblRelay4ValueRB2.Location = New System.Drawing.Point(321, 331)
        lblRelay4ValueRB2.Name = "lblRelay4ValueRB2"
        lblRelay4ValueRB2.Size = New System.Drawing.Size(43, 13)
        lblRelay4ValueRB2.TabIndex = 11
        lblRelay4ValueRB2.Text = "Relay 4"
        '
        'cboParallelSerialPort
        '
        cboParallelSerialPort.DropDownWidth = 89
        cboParallelSerialPort.FormattingEnabled = True
        cboParallelSerialPort.Location = New System.Drawing.Point(121, 55)
        cboParallelSerialPort.Name = "cboParallelSerialPort"
        cboParallelSerialPort.Size = New System.Drawing.Size(95, 21)
        cboParallelSerialPort.TabIndex = 12
        '
        'cboParallelBaudRate
        '
        cboParallelBaudRate.DropDownWidth = 89
        cboParallelBaudRate.FormattingEnabled = True
        cboParallelBaudRate.Location = New System.Drawing.Point(121, 82)
        cboParallelBaudRate.Name = "cboParallelBaudRate"
        cboParallelBaudRate.Size = New System.Drawing.Size(95, 21)
        cboParallelBaudRate.TabIndex = 12
        '
        'lblParallelSerialPort
        '
        lblParallelSerialPort.AutoSize = True
        lblParallelSerialPort.Location = New System.Drawing.Point(16, 58)
        lblParallelSerialPort.Name = "lblParallelSerialPort"
        lblParallelSerialPort.Size = New System.Drawing.Size(58, 13)
        lblParallelSerialPort.TabIndex = 3
        lblParallelSerialPort.Text = "Serial Port:"
        '
        'lblParallelBaudRate
        '
        lblParallelBaudRate.AutoSize = True
        lblParallelBaudRate.Location = New System.Drawing.Point(16, 85)
        lblParallelBaudRate.Name = "lblParallelBaudRate"
        lblParallelBaudRate.Size = New System.Drawing.Size(61, 13)
        lblParallelBaudRate.TabIndex = 3
        lblParallelBaudRate.Text = "Baud Rate:"
        '
        'cmdAssignDeviceRB1
        '
        cmdAssignDeviceRB1.Location = New System.Drawing.Point(19, 216)
        cmdAssignDeviceRB1.Name = "cmdAssignDeviceRB1"
        cmdAssignDeviceRB1.Size = New System.Drawing.Size(156, 22)
        cmdAssignDeviceRB1.TabIndex = 13
        cmdAssignDeviceRB1.Text = "Assign Relay Board"
        cmdAssignDeviceRB1.UseVisualStyleBackColor = True
        '
        'cmdAssignDeviceRB2
        '
        cmdAssignDeviceRB2.Location = New System.Drawing.Point(241, 216)
        cmdAssignDeviceRB2.Name = "cmdAssignDeviceRB2"
        cmdAssignDeviceRB2.Size = New System.Drawing.Size(156, 22)
        cmdAssignDeviceRB2.TabIndex = 13
        cmdAssignDeviceRB2.Text = "Assign Relay Board"
        cmdAssignDeviceRB2.UseVisualStyleBackColor = True
        '
        'frmRelayConfiguration
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(421, 462)
        Controls.Add(cmdAssignDeviceRB2)
        Controls.Add(cmdAssignDeviceRB1)
        Controls.Add(cboParallelBaudRate)
        Controls.Add(cboParallelSerialPort)
        Controls.Add(lblRelay4ValueRB2)
        Controls.Add(lblRelay4ValueRB1)
        Controls.Add(lblRelay3ValueRB2)
        Controls.Add(lblRelay3ValueRB1)
        Controls.Add(lblRelay2ValueRB2)
        Controls.Add(lblRelay2ValueRB1)
        Controls.Add(lblRelay1ValueRB2)
        Controls.Add(lblRelay1ValueRB1)
        Controls.Add(cmdChangeRelayNamesRB2)
        Controls.Add(cmdChangeRelayNamesRB1)
        Controls.Add(lblRelay4NameRB2)
        Controls.Add(lblRelay4NameRB1)
        Controls.Add(lblRelay3NameRB2)
        Controls.Add(lblRelay3NameRB1)
        Controls.Add(lblRelay2NameRB2)
        Controls.Add(lblRelay2NameRB1)
        Controls.Add(lblRelay1NameRB2)
        Controls.Add(lblRelay1NameRB1)
        Controls.Add(lblRelayBoard2)
        Controls.Add(lblRelayBoard1)
        Controls.Add(lblRelayBoardSetup)
        Controls.Add(cboRelayBoardSetup)
        Controls.Add(cmdCancel)
        Controls.Add(cmdOK)
        Controls.Add(lblBaudRateRB2)
        Controls.Add(lblBaudRateRB1)
        Controls.Add(lblSerialPortRB2)
        Controls.Add(cboBaudRateRB2)
        Controls.Add(lblParallelBaudRate)
        Controls.Add(lblParallelSerialPort)
        Controls.Add(lblSerialPortRB1)
        Controls.Add(cboSerialPortRB2)
        Controls.Add(cboBaudRateRB1)
        Controls.Add(cboSerialPortRB1)
        Name = "frmRelayConfiguration"
        Text = "Relay Configuration"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents cboSerialPortRB1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboBaudRateRB1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblSerialPortRB1 As System.Windows.Forms.Label
    Friend WithEvents lblBaudRateRB1 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboRelayBoardSetup As System.Windows.Forms.ComboBox
    Friend WithEvents lblRelayBoardSetup As System.Windows.Forms.Label
    Friend WithEvents lblRelayBoard1 As System.Windows.Forms.Label
    Friend WithEvents lblRelayBoard2 As System.Windows.Forms.Label
    Friend WithEvents cboSerialPortRB2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboBaudRateRB2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblSerialPortRB2 As System.Windows.Forms.Label
    Friend WithEvents lblBaudRateRB2 As System.Windows.Forms.Label
    Friend WithEvents lblRelay1NameRB1 As System.Windows.Forms.Label
    Friend WithEvents lblRelay2NameRB1 As System.Windows.Forms.Label
    Friend WithEvents lblRelay3NameRB1 As System.Windows.Forms.Label
    Friend WithEvents lblRelay4NameRB1 As System.Windows.Forms.Label
    Friend WithEvents cmdChangeRelayNamesRB1 As System.Windows.Forms.Button
    Friend WithEvents lblRelay1ValueRB1 As System.Windows.Forms.Label
    Friend WithEvents lblRelay2ValueRB1 As System.Windows.Forms.Label
    Friend WithEvents lblRelay3ValueRB1 As System.Windows.Forms.Label
    Friend WithEvents lblRelay4ValueRB1 As System.Windows.Forms.Label
    Friend WithEvents lblRelay1NameRB2 As System.Windows.Forms.Label
    Friend WithEvents lblRelay2NameRB2 As System.Windows.Forms.Label
    Friend WithEvents lblRelay3NameRB2 As System.Windows.Forms.Label
    Friend WithEvents lblRelay4NameRB2 As System.Windows.Forms.Label
    Friend WithEvents cmdChangeRelayNamesRB2 As System.Windows.Forms.Button
    Friend WithEvents lblRelay1ValueRB2 As System.Windows.Forms.Label
    Friend WithEvents lblRelay2ValueRB2 As System.Windows.Forms.Label
    Friend WithEvents lblRelay3ValueRB2 As System.Windows.Forms.Label
    Friend WithEvents lblRelay4ValueRB2 As System.Windows.Forms.Label
    Friend WithEvents cboParallelSerialPort As System.Windows.Forms.ComboBox
    Friend WithEvents cboParallelBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents lblParallelSerialPort As System.Windows.Forms.Label
    Friend WithEvents lblParallelBaudRate As System.Windows.Forms.Label
    Friend WithEvents cmdAssignDeviceRB1 As System.Windows.Forms.Button
    Friend WithEvents cmdAssignDeviceRB2 As System.Windows.Forms.Button
End Class
