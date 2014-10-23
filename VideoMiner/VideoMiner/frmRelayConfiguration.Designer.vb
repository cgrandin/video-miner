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
        Me.cboSerialPortRB1 = New System.Windows.Forms.ComboBox
        Me.cboBaudRateRB1 = New System.Windows.Forms.ComboBox
        Me.lblSerialPortRB1 = New System.Windows.Forms.Label
        Me.lblBaudRateRB1 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cboRelayBoardSetup = New System.Windows.Forms.ComboBox
        Me.lblRelayBoardSetup = New System.Windows.Forms.Label
        Me.lblRelayBoard1 = New System.Windows.Forms.Label
        Me.lblRelayBoard2 = New System.Windows.Forms.Label
        Me.cboSerialPortRB2 = New System.Windows.Forms.ComboBox
        Me.cboBaudRateRB2 = New System.Windows.Forms.ComboBox
        Me.lblSerialPortRB2 = New System.Windows.Forms.Label
        Me.lblBaudRateRB2 = New System.Windows.Forms.Label
        Me.lblRelay1NameRB1 = New System.Windows.Forms.Label
        Me.lblRelay2NameRB1 = New System.Windows.Forms.Label
        Me.lblRelay3NameRB1 = New System.Windows.Forms.Label
        Me.lblRelay4NameRB1 = New System.Windows.Forms.Label
        Me.cmdChangeRelayNamesRB1 = New System.Windows.Forms.Button
        Me.lblRelay1ValueRB1 = New System.Windows.Forms.Label
        Me.lblRelay2ValueRB1 = New System.Windows.Forms.Label
        Me.lblRelay3ValueRB1 = New System.Windows.Forms.Label
        Me.lblRelay4ValueRB1 = New System.Windows.Forms.Label
        Me.lblRelay1NameRB2 = New System.Windows.Forms.Label
        Me.lblRelay2NameRB2 = New System.Windows.Forms.Label
        Me.lblRelay3NameRB2 = New System.Windows.Forms.Label
        Me.lblRelay4NameRB2 = New System.Windows.Forms.Label
        Me.cmdChangeRelayNamesRB2 = New System.Windows.Forms.Button
        Me.lblRelay1ValueRB2 = New System.Windows.Forms.Label
        Me.lblRelay2ValueRB2 = New System.Windows.Forms.Label
        Me.lblRelay3ValueRB2 = New System.Windows.Forms.Label
        Me.lblRelay4ValueRB2 = New System.Windows.Forms.Label
        Me.cboParallelSerialPort = New System.Windows.Forms.ComboBox
        Me.cboParallelBaudRate = New System.Windows.Forms.ComboBox
        Me.lblParallelSerialPort = New System.Windows.Forms.Label
        Me.lblParallelBaudRate = New System.Windows.Forms.Label
        Me.cmdAssignDeviceRB1 = New System.Windows.Forms.Button
        Me.cmdAssignDeviceRB2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cboSerialPortRB1
        '
        Me.cboSerialPortRB1.FormattingEnabled = True
        Me.cboSerialPortRB1.Location = New System.Drawing.Point(86, 160)
        Me.cboSerialPortRB1.Name = "cboSerialPortRB1"
        Me.cboSerialPortRB1.Size = New System.Drawing.Size(89, 21)
        Me.cboSerialPortRB1.Sorted = True
        Me.cboSerialPortRB1.TabIndex = 0
        '
        'cboBaudRateRB1
        '
        Me.cboBaudRateRB1.FormattingEnabled = True
        Me.cboBaudRateRB1.Location = New System.Drawing.Point(86, 187)
        Me.cboBaudRateRB1.Name = "cboBaudRateRB1"
        Me.cboBaudRateRB1.Size = New System.Drawing.Size(89, 21)
        Me.cboBaudRateRB1.TabIndex = 1
        '
        'lblSerialPortRB1
        '
        Me.lblSerialPortRB1.AutoSize = True
        Me.lblSerialPortRB1.Location = New System.Drawing.Point(16, 163)
        Me.lblSerialPortRB1.Name = "lblSerialPortRB1"
        Me.lblSerialPortRB1.Size = New System.Drawing.Size(58, 13)
        Me.lblSerialPortRB1.TabIndex = 3
        Me.lblSerialPortRB1.Text = "Serial Port:"
        '
        'lblBaudRateRB1
        '
        Me.lblBaudRateRB1.AutoSize = True
        Me.lblBaudRateRB1.Location = New System.Drawing.Point(16, 190)
        Me.lblBaudRateRB1.Name = "lblBaudRateRB1"
        Me.lblBaudRateRB1.Size = New System.Drawing.Size(61, 13)
        Me.lblBaudRateRB1.TabIndex = 3
        Me.lblBaudRateRB1.Text = "Baud Rate:"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(121, 414)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(202, 414)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cboRelayBoardSetup
        '
        Me.cboRelayBoardSetup.FormattingEnabled = True
        Me.cboRelayBoardSetup.Location = New System.Drawing.Point(121, 28)
        Me.cboRelayBoardSetup.Name = "cboRelayBoardSetup"
        Me.cboRelayBoardSetup.Size = New System.Drawing.Size(254, 21)
        Me.cboRelayBoardSetup.TabIndex = 6
        '
        'lblRelayBoardSetup
        '
        Me.lblRelayBoardSetup.AutoSize = True
        Me.lblRelayBoardSetup.Location = New System.Drawing.Point(16, 31)
        Me.lblRelayBoardSetup.Name = "lblRelayBoardSetup"
        Me.lblRelayBoardSetup.Size = New System.Drawing.Size(99, 13)
        Me.lblRelayBoardSetup.TabIndex = 7
        Me.lblRelayBoardSetup.Text = "Relay Board Setup:"
        '
        'lblRelayBoard1
        '
        Me.lblRelayBoard1.AutoSize = True
        Me.lblRelayBoard1.Location = New System.Drawing.Point(16, 132)
        Me.lblRelayBoard1.Name = "lblRelayBoard1"
        Me.lblRelayBoard1.Size = New System.Drawing.Size(74, 13)
        Me.lblRelayBoard1.TabIndex = 8
        Me.lblRelayBoard1.Text = "Relay Board 1"
        '
        'lblRelayBoard2
        '
        Me.lblRelayBoard2.AutoSize = True
        Me.lblRelayBoard2.Location = New System.Drawing.Point(238, 132)
        Me.lblRelayBoard2.Name = "lblRelayBoard2"
        Me.lblRelayBoard2.Size = New System.Drawing.Size(74, 13)
        Me.lblRelayBoard2.TabIndex = 8
        Me.lblRelayBoard2.Text = "Relay Board 2"
        '
        'cboSerialPortRB2
        '
        Me.cboSerialPortRB2.FormattingEnabled = True
        Me.cboSerialPortRB2.Location = New System.Drawing.Point(308, 160)
        Me.cboSerialPortRB2.Name = "cboSerialPortRB2"
        Me.cboSerialPortRB2.Size = New System.Drawing.Size(89, 21)
        Me.cboSerialPortRB2.Sorted = True
        Me.cboSerialPortRB2.TabIndex = 0
        '
        'cboBaudRateRB2
        '
        Me.cboBaudRateRB2.FormattingEnabled = True
        Me.cboBaudRateRB2.Location = New System.Drawing.Point(308, 187)
        Me.cboBaudRateRB2.Name = "cboBaudRateRB2"
        Me.cboBaudRateRB2.Size = New System.Drawing.Size(89, 21)
        Me.cboBaudRateRB2.TabIndex = 1
        '
        'lblSerialPortRB2
        '
        Me.lblSerialPortRB2.AutoSize = True
        Me.lblSerialPortRB2.Location = New System.Drawing.Point(238, 163)
        Me.lblSerialPortRB2.Name = "lblSerialPortRB2"
        Me.lblSerialPortRB2.Size = New System.Drawing.Size(58, 13)
        Me.lblSerialPortRB2.TabIndex = 3
        Me.lblSerialPortRB2.Text = "Serial Port:"
        '
        'lblBaudRateRB2
        '
        Me.lblBaudRateRB2.AutoSize = True
        Me.lblBaudRateRB2.Location = New System.Drawing.Point(238, 190)
        Me.lblBaudRateRB2.Name = "lblBaudRateRB2"
        Me.lblBaudRateRB2.Size = New System.Drawing.Size(61, 13)
        Me.lblBaudRateRB2.TabIndex = 3
        Me.lblBaudRateRB2.Text = "Baud Rate:"
        '
        'lblRelay1NameRB1
        '
        Me.lblRelay1NameRB1.AutoSize = True
        Me.lblRelay1NameRB1.Location = New System.Drawing.Point(16, 250)
        Me.lblRelay1NameRB1.Name = "lblRelay1NameRB1"
        Me.lblRelay1NameRB1.Size = New System.Drawing.Size(77, 13)
        Me.lblRelay1NameRB1.TabIndex = 9
        Me.lblRelay1NameRB1.Text = "Relay 1 Name:"
        '
        'lblRelay2NameRB1
        '
        Me.lblRelay2NameRB1.AutoSize = True
        Me.lblRelay2NameRB1.Location = New System.Drawing.Point(16, 276)
        Me.lblRelay2NameRB1.Name = "lblRelay2NameRB1"
        Me.lblRelay2NameRB1.Size = New System.Drawing.Size(77, 13)
        Me.lblRelay2NameRB1.TabIndex = 9
        Me.lblRelay2NameRB1.Text = "Relay 2 Name:"
        '
        'lblRelay3NameRB1
        '
        Me.lblRelay3NameRB1.AutoSize = True
        Me.lblRelay3NameRB1.Location = New System.Drawing.Point(16, 304)
        Me.lblRelay3NameRB1.Name = "lblRelay3NameRB1"
        Me.lblRelay3NameRB1.Size = New System.Drawing.Size(77, 13)
        Me.lblRelay3NameRB1.TabIndex = 9
        Me.lblRelay3NameRB1.Text = "Relay 3 Name:"
        '
        'lblRelay4NameRB1
        '
        Me.lblRelay4NameRB1.AutoSize = True
        Me.lblRelay4NameRB1.Location = New System.Drawing.Point(16, 331)
        Me.lblRelay4NameRB1.Name = "lblRelay4NameRB1"
        Me.lblRelay4NameRB1.Size = New System.Drawing.Size(77, 13)
        Me.lblRelay4NameRB1.TabIndex = 9
        Me.lblRelay4NameRB1.Text = "Relay 4 Name:"
        '
        'cmdChangeRelayNamesRB1
        '
        Me.cmdChangeRelayNamesRB1.Location = New System.Drawing.Point(19, 364)
        Me.cmdChangeRelayNamesRB1.Name = "cmdChangeRelayNamesRB1"
        Me.cmdChangeRelayNamesRB1.Size = New System.Drawing.Size(123, 21)
        Me.cmdChangeRelayNamesRB1.TabIndex = 10
        Me.cmdChangeRelayNamesRB1.Text = "Change Relay Names"
        Me.cmdChangeRelayNamesRB1.UseVisualStyleBackColor = True
        '
        'lblRelay1ValueRB1
        '
        Me.lblRelay1ValueRB1.AutoSize = True
        Me.lblRelay1ValueRB1.Location = New System.Drawing.Point(99, 250)
        Me.lblRelay1ValueRB1.Name = "lblRelay1ValueRB1"
        Me.lblRelay1ValueRB1.Size = New System.Drawing.Size(43, 13)
        Me.lblRelay1ValueRB1.TabIndex = 11
        Me.lblRelay1ValueRB1.Text = "Relay 1"
        '
        'lblRelay2ValueRB1
        '
        Me.lblRelay2ValueRB1.AutoSize = True
        Me.lblRelay2ValueRB1.Location = New System.Drawing.Point(99, 276)
        Me.lblRelay2ValueRB1.Name = "lblRelay2ValueRB1"
        Me.lblRelay2ValueRB1.Size = New System.Drawing.Size(43, 13)
        Me.lblRelay2ValueRB1.TabIndex = 11
        Me.lblRelay2ValueRB1.Text = "Relay 2"
        '
        'lblRelay3ValueRB1
        '
        Me.lblRelay3ValueRB1.AutoSize = True
        Me.lblRelay3ValueRB1.Location = New System.Drawing.Point(99, 304)
        Me.lblRelay3ValueRB1.Name = "lblRelay3ValueRB1"
        Me.lblRelay3ValueRB1.Size = New System.Drawing.Size(43, 13)
        Me.lblRelay3ValueRB1.TabIndex = 11
        Me.lblRelay3ValueRB1.Text = "Relay 3"
        '
        'lblRelay4ValueRB1
        '
        Me.lblRelay4ValueRB1.AutoSize = True
        Me.lblRelay4ValueRB1.Location = New System.Drawing.Point(99, 331)
        Me.lblRelay4ValueRB1.Name = "lblRelay4ValueRB1"
        Me.lblRelay4ValueRB1.Size = New System.Drawing.Size(43, 13)
        Me.lblRelay4ValueRB1.TabIndex = 11
        Me.lblRelay4ValueRB1.Text = "Relay 4"
        '
        'lblRelay1NameRB2
        '
        Me.lblRelay1NameRB2.AutoSize = True
        Me.lblRelay1NameRB2.Location = New System.Drawing.Point(238, 250)
        Me.lblRelay1NameRB2.Name = "lblRelay1NameRB2"
        Me.lblRelay1NameRB2.Size = New System.Drawing.Size(77, 13)
        Me.lblRelay1NameRB2.TabIndex = 9
        Me.lblRelay1NameRB2.Text = "Relay 1 Name:"
        '
        'lblRelay2NameRB2
        '
        Me.lblRelay2NameRB2.AutoSize = True
        Me.lblRelay2NameRB2.Location = New System.Drawing.Point(238, 276)
        Me.lblRelay2NameRB2.Name = "lblRelay2NameRB2"
        Me.lblRelay2NameRB2.Size = New System.Drawing.Size(77, 13)
        Me.lblRelay2NameRB2.TabIndex = 9
        Me.lblRelay2NameRB2.Text = "Relay 2 Name:"
        '
        'lblRelay3NameRB2
        '
        Me.lblRelay3NameRB2.AutoSize = True
        Me.lblRelay3NameRB2.Location = New System.Drawing.Point(238, 304)
        Me.lblRelay3NameRB2.Name = "lblRelay3NameRB2"
        Me.lblRelay3NameRB2.Size = New System.Drawing.Size(77, 13)
        Me.lblRelay3NameRB2.TabIndex = 9
        Me.lblRelay3NameRB2.Text = "Relay 3 Name:"
        '
        'lblRelay4NameRB2
        '
        Me.lblRelay4NameRB2.AutoSize = True
        Me.lblRelay4NameRB2.Location = New System.Drawing.Point(238, 331)
        Me.lblRelay4NameRB2.Name = "lblRelay4NameRB2"
        Me.lblRelay4NameRB2.Size = New System.Drawing.Size(77, 13)
        Me.lblRelay4NameRB2.TabIndex = 9
        Me.lblRelay4NameRB2.Text = "Relay 4 Name:"
        '
        'cmdChangeRelayNamesRB2
        '
        Me.cmdChangeRelayNamesRB2.Location = New System.Drawing.Point(241, 364)
        Me.cmdChangeRelayNamesRB2.Name = "cmdChangeRelayNamesRB2"
        Me.cmdChangeRelayNamesRB2.Size = New System.Drawing.Size(123, 21)
        Me.cmdChangeRelayNamesRB2.TabIndex = 10
        Me.cmdChangeRelayNamesRB2.Text = "Change Relay Names"
        Me.cmdChangeRelayNamesRB2.UseVisualStyleBackColor = True
        '
        'lblRelay1ValueRB2
        '
        Me.lblRelay1ValueRB2.AutoSize = True
        Me.lblRelay1ValueRB2.Location = New System.Drawing.Point(321, 250)
        Me.lblRelay1ValueRB2.Name = "lblRelay1ValueRB2"
        Me.lblRelay1ValueRB2.Size = New System.Drawing.Size(43, 13)
        Me.lblRelay1ValueRB2.TabIndex = 11
        Me.lblRelay1ValueRB2.Text = "Relay 1"
        '
        'lblRelay2ValueRB2
        '
        Me.lblRelay2ValueRB2.AutoSize = True
        Me.lblRelay2ValueRB2.Location = New System.Drawing.Point(321, 276)
        Me.lblRelay2ValueRB2.Name = "lblRelay2ValueRB2"
        Me.lblRelay2ValueRB2.Size = New System.Drawing.Size(43, 13)
        Me.lblRelay2ValueRB2.TabIndex = 11
        Me.lblRelay2ValueRB2.Text = "Relay 2"
        '
        'lblRelay3ValueRB2
        '
        Me.lblRelay3ValueRB2.AutoSize = True
        Me.lblRelay3ValueRB2.Location = New System.Drawing.Point(321, 304)
        Me.lblRelay3ValueRB2.Name = "lblRelay3ValueRB2"
        Me.lblRelay3ValueRB2.Size = New System.Drawing.Size(43, 13)
        Me.lblRelay3ValueRB2.TabIndex = 11
        Me.lblRelay3ValueRB2.Text = "Relay 3"
        '
        'lblRelay4ValueRB2
        '
        Me.lblRelay4ValueRB2.AutoSize = True
        Me.lblRelay4ValueRB2.Location = New System.Drawing.Point(321, 331)
        Me.lblRelay4ValueRB2.Name = "lblRelay4ValueRB2"
        Me.lblRelay4ValueRB2.Size = New System.Drawing.Size(43, 13)
        Me.lblRelay4ValueRB2.TabIndex = 11
        Me.lblRelay4ValueRB2.Text = "Relay 4"
        '
        'cboParallelSerialPort
        '
        Me.cboParallelSerialPort.DropDownWidth = 89
        Me.cboParallelSerialPort.FormattingEnabled = True
        Me.cboParallelSerialPort.Location = New System.Drawing.Point(121, 55)
        Me.cboParallelSerialPort.Name = "cboParallelSerialPort"
        Me.cboParallelSerialPort.Size = New System.Drawing.Size(95, 21)
        Me.cboParallelSerialPort.TabIndex = 12
        '
        'cboParallelBaudRate
        '
        Me.cboParallelBaudRate.DropDownWidth = 89
        Me.cboParallelBaudRate.FormattingEnabled = True
        Me.cboParallelBaudRate.Location = New System.Drawing.Point(121, 82)
        Me.cboParallelBaudRate.Name = "cboParallelBaudRate"
        Me.cboParallelBaudRate.Size = New System.Drawing.Size(95, 21)
        Me.cboParallelBaudRate.TabIndex = 12
        '
        'lblParallelSerialPort
        '
        Me.lblParallelSerialPort.AutoSize = True
        Me.lblParallelSerialPort.Location = New System.Drawing.Point(16, 58)
        Me.lblParallelSerialPort.Name = "lblParallelSerialPort"
        Me.lblParallelSerialPort.Size = New System.Drawing.Size(58, 13)
        Me.lblParallelSerialPort.TabIndex = 3
        Me.lblParallelSerialPort.Text = "Serial Port:"
        '
        'lblParallelBaudRate
        '
        Me.lblParallelBaudRate.AutoSize = True
        Me.lblParallelBaudRate.Location = New System.Drawing.Point(16, 85)
        Me.lblParallelBaudRate.Name = "lblParallelBaudRate"
        Me.lblParallelBaudRate.Size = New System.Drawing.Size(61, 13)
        Me.lblParallelBaudRate.TabIndex = 3
        Me.lblParallelBaudRate.Text = "Baud Rate:"
        '
        'cmdAssignDeviceRB1
        '
        Me.cmdAssignDeviceRB1.Location = New System.Drawing.Point(19, 216)
        Me.cmdAssignDeviceRB1.Name = "cmdAssignDeviceRB1"
        Me.cmdAssignDeviceRB1.Size = New System.Drawing.Size(156, 22)
        Me.cmdAssignDeviceRB1.TabIndex = 13
        Me.cmdAssignDeviceRB1.Text = "Assign Relay Board"
        Me.cmdAssignDeviceRB1.UseVisualStyleBackColor = True
        '
        'cmdAssignDeviceRB2
        '
        Me.cmdAssignDeviceRB2.Location = New System.Drawing.Point(241, 216)
        Me.cmdAssignDeviceRB2.Name = "cmdAssignDeviceRB2"
        Me.cmdAssignDeviceRB2.Size = New System.Drawing.Size(156, 22)
        Me.cmdAssignDeviceRB2.TabIndex = 13
        Me.cmdAssignDeviceRB2.Text = "Assign Relay Board"
        Me.cmdAssignDeviceRB2.UseVisualStyleBackColor = True
        '
        'frmRelayConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 462)
        Me.Controls.Add(Me.cmdAssignDeviceRB2)
        Me.Controls.Add(Me.cmdAssignDeviceRB1)
        Me.Controls.Add(Me.cboParallelBaudRate)
        Me.Controls.Add(Me.cboParallelSerialPort)
        Me.Controls.Add(Me.lblRelay4ValueRB2)
        Me.Controls.Add(Me.lblRelay4ValueRB1)
        Me.Controls.Add(Me.lblRelay3ValueRB2)
        Me.Controls.Add(Me.lblRelay3ValueRB1)
        Me.Controls.Add(Me.lblRelay2ValueRB2)
        Me.Controls.Add(Me.lblRelay2ValueRB1)
        Me.Controls.Add(Me.lblRelay1ValueRB2)
        Me.Controls.Add(Me.lblRelay1ValueRB1)
        Me.Controls.Add(Me.cmdChangeRelayNamesRB2)
        Me.Controls.Add(Me.cmdChangeRelayNamesRB1)
        Me.Controls.Add(Me.lblRelay4NameRB2)
        Me.Controls.Add(Me.lblRelay4NameRB1)
        Me.Controls.Add(Me.lblRelay3NameRB2)
        Me.Controls.Add(Me.lblRelay3NameRB1)
        Me.Controls.Add(Me.lblRelay2NameRB2)
        Me.Controls.Add(Me.lblRelay2NameRB1)
        Me.Controls.Add(Me.lblRelay1NameRB2)
        Me.Controls.Add(Me.lblRelay1NameRB1)
        Me.Controls.Add(Me.lblRelayBoard2)
        Me.Controls.Add(Me.lblRelayBoard1)
        Me.Controls.Add(Me.lblRelayBoardSetup)
        Me.Controls.Add(Me.cboRelayBoardSetup)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblBaudRateRB2)
        Me.Controls.Add(Me.lblBaudRateRB1)
        Me.Controls.Add(Me.lblSerialPortRB2)
        Me.Controls.Add(Me.cboBaudRateRB2)
        Me.Controls.Add(Me.lblParallelBaudRate)
        Me.Controls.Add(Me.lblParallelSerialPort)
        Me.Controls.Add(Me.lblSerialPortRB1)
        Me.Controls.Add(Me.cboSerialPortRB2)
        Me.Controls.Add(Me.cboBaudRateRB1)
        Me.Controls.Add(Me.cboSerialPortRB1)
        Me.Name = "frmRelayConfiguration"
        Me.Text = "Relay Configuration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
