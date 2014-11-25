<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeviceControl
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
        components = New System.ComponentModel.Container
        AllRelaySerialPort = New System.IO.Ports.SerialPort(components)
        cmdToggleRelay4 = New System.Windows.Forms.Button
        lblRelay4 = New System.Windows.Forms.Label
        lblRelay3 = New System.Windows.Forms.Label
        cmdToggleRelay3 = New System.Windows.Forms.Button
        cmdToggleRelay5 = New System.Windows.Forms.Button
        lblRelay5 = New System.Windows.Forms.Label
        lblRelay2 = New System.Windows.Forms.Label
        cmdToggleRelay2 = New System.Windows.Forms.Button
        cmdToggleRelay6 = New System.Windows.Forms.Button
        lblRelay6 = New System.Windows.Forms.Label
        lblRelay1 = New System.Windows.Forms.Label
        cmdToggleRelay7 = New System.Windows.Forms.Button
        lblRelay7 = New System.Windows.Forms.Label
        cmdToggleRelay8 = New System.Windows.Forms.Button
        lblRelay8 = New System.Windows.Forms.Label
        cmdToggleRelay1 = New System.Windows.Forms.Button
        cmdToggleAll = New System.Windows.Forms.Button
        cmdAllRelayConfiguration = New System.Windows.Forms.Button
        lblRelayBoard1 = New System.Windows.Forms.Label
        lblRelayBoard2 = New System.Windows.Forms.Label
        PortOneSerialPort = New System.IO.Ports.SerialPort(components)
        PortTwoSerialPort = New System.IO.Ports.SerialPort(components)
        SuspendLayout()
        '
        'AllRelaySerialPort
        '
        AllRelaySerialPort.ReadTimeout = 5000
        '
        'cmdToggleRelay4
        '
        cmdToggleRelay4.Location = New System.Drawing.Point(12, 181)
        cmdToggleRelay4.Name = "cmdToggleRelay4"
        cmdToggleRelay4.Size = New System.Drawing.Size(96, 23)
        cmdToggleRelay4.TabIndex = 0
        cmdToggleRelay4.Text = "Toggle Relay 4"
        cmdToggleRelay4.UseVisualStyleBackColor = True
        '
        'lblRelay4
        '
        lblRelay4.AutoSize = True
        lblRelay4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRelay4.ForeColor = System.Drawing.Color.Red
        lblRelay4.Location = New System.Drawing.Point(114, 186)
        lblRelay4.Name = "lblRelay4"
        lblRelay4.Size = New System.Drawing.Size(30, 13)
        lblRelay4.TabIndex = 1
        lblRelay4.Text = "OFF"
        '
        'lblRelay3
        '
        lblRelay3.AutoSize = True
        lblRelay3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRelay3.ForeColor = System.Drawing.Color.Red
        lblRelay3.Location = New System.Drawing.Point(114, 157)
        lblRelay3.Name = "lblRelay3"
        lblRelay3.Size = New System.Drawing.Size(30, 13)
        lblRelay3.TabIndex = 1
        lblRelay3.Text = "OFF"
        '
        'cmdToggleRelay3
        '
        cmdToggleRelay3.Location = New System.Drawing.Point(12, 152)
        cmdToggleRelay3.Name = "cmdToggleRelay3"
        cmdToggleRelay3.Size = New System.Drawing.Size(96, 23)
        cmdToggleRelay3.TabIndex = 0
        cmdToggleRelay3.Text = "Toggle Relay 3"
        cmdToggleRelay3.UseVisualStyleBackColor = True
        '
        'cmdToggleRelay5
        '
        cmdToggleRelay5.Location = New System.Drawing.Point(194, 94)
        cmdToggleRelay5.Name = "cmdToggleRelay5"
        cmdToggleRelay5.Size = New System.Drawing.Size(96, 23)
        cmdToggleRelay5.TabIndex = 0
        cmdToggleRelay5.Text = "Toggle Relay 1"
        cmdToggleRelay5.UseVisualStyleBackColor = True
        '
        'lblRelay5
        '
        lblRelay5.AutoSize = True
        lblRelay5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRelay5.ForeColor = System.Drawing.Color.Red
        lblRelay5.Location = New System.Drawing.Point(296, 99)
        lblRelay5.Name = "lblRelay5"
        lblRelay5.Size = New System.Drawing.Size(30, 13)
        lblRelay5.TabIndex = 1
        lblRelay5.Text = "OFF"
        '
        'lblRelay2
        '
        lblRelay2.AutoSize = True
        lblRelay2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRelay2.ForeColor = System.Drawing.Color.Red
        lblRelay2.Location = New System.Drawing.Point(114, 128)
        lblRelay2.Name = "lblRelay2"
        lblRelay2.Size = New System.Drawing.Size(30, 13)
        lblRelay2.TabIndex = 1
        lblRelay2.Text = "OFF"
        '
        'cmdToggleRelay2
        '
        cmdToggleRelay2.Location = New System.Drawing.Point(12, 123)
        cmdToggleRelay2.Name = "cmdToggleRelay2"
        cmdToggleRelay2.Size = New System.Drawing.Size(96, 23)
        cmdToggleRelay2.TabIndex = 0
        cmdToggleRelay2.Text = "Toggle Relay 2"
        cmdToggleRelay2.UseVisualStyleBackColor = True
        '
        'cmdToggleRelay6
        '
        cmdToggleRelay6.Location = New System.Drawing.Point(194, 123)
        cmdToggleRelay6.Name = "cmdToggleRelay6"
        cmdToggleRelay6.Size = New System.Drawing.Size(96, 23)
        cmdToggleRelay6.TabIndex = 0
        cmdToggleRelay6.Text = "Toggle Relay 2"
        cmdToggleRelay6.UseVisualStyleBackColor = True
        '
        'lblRelay6
        '
        lblRelay6.AutoSize = True
        lblRelay6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRelay6.ForeColor = System.Drawing.Color.Red
        lblRelay6.Location = New System.Drawing.Point(296, 128)
        lblRelay6.Name = "lblRelay6"
        lblRelay6.Size = New System.Drawing.Size(30, 13)
        lblRelay6.TabIndex = 1
        lblRelay6.Text = "OFF"
        '
        'lblRelay1
        '
        lblRelay1.AutoSize = True
        lblRelay1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRelay1.ForeColor = System.Drawing.Color.Red
        lblRelay1.Location = New System.Drawing.Point(114, 99)
        lblRelay1.Name = "lblRelay1"
        lblRelay1.Size = New System.Drawing.Size(30, 13)
        lblRelay1.TabIndex = 1
        lblRelay1.Text = "OFF"
        '
        'cmdToggleRelay7
        '
        cmdToggleRelay7.Location = New System.Drawing.Point(194, 152)
        cmdToggleRelay7.Name = "cmdToggleRelay7"
        cmdToggleRelay7.Size = New System.Drawing.Size(96, 23)
        cmdToggleRelay7.TabIndex = 0
        cmdToggleRelay7.Text = "Toggle Relay 3"
        cmdToggleRelay7.UseVisualStyleBackColor = True
        '
        'lblRelay7
        '
        lblRelay7.AutoSize = True
        lblRelay7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRelay7.ForeColor = System.Drawing.Color.Red
        lblRelay7.Location = New System.Drawing.Point(296, 157)
        lblRelay7.Name = "lblRelay7"
        lblRelay7.Size = New System.Drawing.Size(30, 13)
        lblRelay7.TabIndex = 1
        lblRelay7.Text = "OFF"
        '
        'cmdToggleRelay8
        '
        cmdToggleRelay8.Location = New System.Drawing.Point(194, 181)
        cmdToggleRelay8.Name = "cmdToggleRelay8"
        cmdToggleRelay8.Size = New System.Drawing.Size(96, 23)
        cmdToggleRelay8.TabIndex = 0
        cmdToggleRelay8.Text = "Toggle Relay 4"
        cmdToggleRelay8.UseVisualStyleBackColor = True
        '
        'lblRelay8
        '
        lblRelay8.AutoSize = True
        lblRelay8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRelay8.ForeColor = System.Drawing.Color.Red
        lblRelay8.Location = New System.Drawing.Point(296, 186)
        lblRelay8.Name = "lblRelay8"
        lblRelay8.Size = New System.Drawing.Size(30, 13)
        lblRelay8.TabIndex = 1
        lblRelay8.Text = "OFF"
        '
        'cmdToggleRelay1
        '
        cmdToggleRelay1.Location = New System.Drawing.Point(12, 94)
        cmdToggleRelay1.Name = "cmdToggleRelay1"
        cmdToggleRelay1.Size = New System.Drawing.Size(96, 23)
        cmdToggleRelay1.TabIndex = 0
        cmdToggleRelay1.Text = "Toggle Relay 1"
        cmdToggleRelay1.UseVisualStyleBackColor = True
        '
        'cmdToggleAll
        '
        cmdToggleAll.Location = New System.Drawing.Point(99, 222)
        cmdToggleAll.Name = "cmdToggleAll"
        cmdToggleAll.Size = New System.Drawing.Size(106, 23)
        cmdToggleAll.TabIndex = 2
        cmdToggleAll.Text = "Toggle All"
        cmdToggleAll.UseVisualStyleBackColor = True
        '
        'cmdAllRelayConfiguration
        '
        cmdAllRelayConfiguration.Location = New System.Drawing.Point(99, 12)
        cmdAllRelayConfiguration.Name = "cmdAllRelayConfiguration"
        cmdAllRelayConfiguration.Size = New System.Drawing.Size(126, 23)
        cmdAllRelayConfiguration.TabIndex = 5
        cmdAllRelayConfiguration.Text = "Relay Configuration"
        cmdAllRelayConfiguration.UseVisualStyleBackColor = True
        '
        'lblRelayBoard1
        '
        lblRelayBoard1.AutoSize = True
        lblRelayBoard1.Location = New System.Drawing.Point(12, 65)
        lblRelayBoard1.Name = "lblRelayBoard1"
        lblRelayBoard1.Size = New System.Drawing.Size(74, 13)
        lblRelayBoard1.TabIndex = 6
        lblRelayBoard1.Text = "Relay Board 1"
        '
        'lblRelayBoard2
        '
        lblRelayBoard2.AutoSize = True
        lblRelayBoard2.Location = New System.Drawing.Point(191, 65)
        lblRelayBoard2.Name = "lblRelayBoard2"
        lblRelayBoard2.Size = New System.Drawing.Size(74, 13)
        lblRelayBoard2.TabIndex = 6
        lblRelayBoard2.Text = "Relay Board 2"
        '
        'PortOneSerialPort
        '
        PortOneSerialPort.ReadTimeout = 5000
        '
        'PortTwoSerialPort
        '
        PortTwoSerialPort.ReadTimeout = 5000
        '
        'frmDeviceControl
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(339, 301)
        Controls.Add(lblRelayBoard2)
        Controls.Add(lblRelayBoard1)
        Controls.Add(cmdAllRelayConfiguration)
        Controls.Add(cmdToggleAll)
        Controls.Add(cmdToggleRelay1)
        Controls.Add(lblRelay8)
        Controls.Add(cmdToggleRelay8)
        Controls.Add(cmdToggleRelay4)
        Controls.Add(lblRelay7)
        Controls.Add(lblRelay4)
        Controls.Add(cmdToggleRelay7)
        Controls.Add(lblRelay3)
        Controls.Add(lblRelay1)
        Controls.Add(cmdToggleRelay3)
        Controls.Add(lblRelay6)
        Controls.Add(cmdToggleRelay5)
        Controls.Add(cmdToggleRelay6)
        Controls.Add(lblRelay5)
        Controls.Add(cmdToggleRelay2)
        Controls.Add(lblRelay2)
        Name = "frmDeviceControl"
        Text = "Device Control"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents AllRelaySerialPort As System.IO.Ports.SerialPort
    Friend WithEvents cmdAllRelayConfiguration As System.Windows.Forms.Button
    Friend WithEvents cmdToggleAll As System.Windows.Forms.Button
    Friend WithEvents cmdToggleRelay1 As System.Windows.Forms.Button
    Friend WithEvents lblRelay8 As System.Windows.Forms.Label
    Friend WithEvents cmdToggleRelay8 As System.Windows.Forms.Button
    Friend WithEvents lblRelay7 As System.Windows.Forms.Label
    Friend WithEvents cmdToggleRelay7 As System.Windows.Forms.Button
    Friend WithEvents lblRelay1 As System.Windows.Forms.Label
    Friend WithEvents lblRelay6 As System.Windows.Forms.Label
    Friend WithEvents cmdToggleRelay6 As System.Windows.Forms.Button
    Friend WithEvents cmdToggleRelay2 As System.Windows.Forms.Button
    Friend WithEvents lblRelay2 As System.Windows.Forms.Label
    Friend WithEvents lblRelay5 As System.Windows.Forms.Label
    Friend WithEvents cmdToggleRelay5 As System.Windows.Forms.Button
    Friend WithEvents cmdToggleRelay3 As System.Windows.Forms.Button
    Friend WithEvents lblRelay3 As System.Windows.Forms.Label
    Friend WithEvents lblRelay4 As System.Windows.Forms.Label
    Friend WithEvents cmdToggleRelay4 As System.Windows.Forms.Button
    Friend WithEvents lblRelayBoard1 As System.Windows.Forms.Label
    Friend WithEvents lblRelayBoard2 As System.Windows.Forms.Label
    Friend WithEvents PortOneSerialPort As System.IO.Ports.SerialPort
    Friend WithEvents PortTwoSerialPort As System.IO.Ports.SerialPort
End Class
