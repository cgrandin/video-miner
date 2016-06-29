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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeviceControl))
        Me.AllRelaySerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.cmdToggleRelay4 = New System.Windows.Forms.Button()
        Me.lblRelay4 = New System.Windows.Forms.Label()
        Me.lblRelay3 = New System.Windows.Forms.Label()
        Me.cmdToggleRelay3 = New System.Windows.Forms.Button()
        Me.cmdToggleRelay5 = New System.Windows.Forms.Button()
        Me.lblRelay5 = New System.Windows.Forms.Label()
        Me.lblRelay2 = New System.Windows.Forms.Label()
        Me.cmdToggleRelay2 = New System.Windows.Forms.Button()
        Me.cmdToggleRelay6 = New System.Windows.Forms.Button()
        Me.lblRelay6 = New System.Windows.Forms.Label()
        Me.lblRelay1 = New System.Windows.Forms.Label()
        Me.cmdToggleRelay7 = New System.Windows.Forms.Button()
        Me.lblRelay7 = New System.Windows.Forms.Label()
        Me.cmdToggleRelay8 = New System.Windows.Forms.Button()
        Me.lblRelay8 = New System.Windows.Forms.Label()
        Me.cmdToggleRelay1 = New System.Windows.Forms.Button()
        Me.cmdToggleAll = New System.Windows.Forms.Button()
        Me.cmdAllRelayConfiguration = New System.Windows.Forms.Button()
        Me.lblRelayBoard1 = New System.Windows.Forms.Label()
        Me.lblRelayBoard2 = New System.Windows.Forms.Label()
        Me.PortOneSerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.PortTwoSerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.SuspendLayout()
        '
        'AllRelaySerialPort
        '
        Me.AllRelaySerialPort.ReadTimeout = 5000
        '
        'cmdToggleRelay4
        '
        Me.cmdToggleRelay4.Location = New System.Drawing.Point(12, 181)
        Me.cmdToggleRelay4.Name = "cmdToggleRelay4"
        Me.cmdToggleRelay4.Size = New System.Drawing.Size(96, 23)
        Me.cmdToggleRelay4.TabIndex = 0
        Me.cmdToggleRelay4.Text = "Toggle Relay 4"
        Me.cmdToggleRelay4.UseVisualStyleBackColor = True
        '
        'lblRelay4
        '
        Me.lblRelay4.AutoSize = True
        Me.lblRelay4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelay4.ForeColor = System.Drawing.Color.Red
        Me.lblRelay4.Location = New System.Drawing.Point(114, 186)
        Me.lblRelay4.Name = "lblRelay4"
        Me.lblRelay4.Size = New System.Drawing.Size(30, 13)
        Me.lblRelay4.TabIndex = 1
        Me.lblRelay4.Text = "OFF"
        '
        'lblRelay3
        '
        Me.lblRelay3.AutoSize = True
        Me.lblRelay3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelay3.ForeColor = System.Drawing.Color.Red
        Me.lblRelay3.Location = New System.Drawing.Point(114, 157)
        Me.lblRelay3.Name = "lblRelay3"
        Me.lblRelay3.Size = New System.Drawing.Size(30, 13)
        Me.lblRelay3.TabIndex = 1
        Me.lblRelay3.Text = "OFF"
        '
        'cmdToggleRelay3
        '
        Me.cmdToggleRelay3.Location = New System.Drawing.Point(12, 152)
        Me.cmdToggleRelay3.Name = "cmdToggleRelay3"
        Me.cmdToggleRelay3.Size = New System.Drawing.Size(96, 23)
        Me.cmdToggleRelay3.TabIndex = 0
        Me.cmdToggleRelay3.Text = "Toggle Relay 3"
        Me.cmdToggleRelay3.UseVisualStyleBackColor = True
        '
        'cmdToggleRelay5
        '
        Me.cmdToggleRelay5.Location = New System.Drawing.Point(194, 94)
        Me.cmdToggleRelay5.Name = "cmdToggleRelay5"
        Me.cmdToggleRelay5.Size = New System.Drawing.Size(96, 23)
        Me.cmdToggleRelay5.TabIndex = 0
        Me.cmdToggleRelay5.Text = "Toggle Relay 1"
        Me.cmdToggleRelay5.UseVisualStyleBackColor = True
        '
        'lblRelay5
        '
        Me.lblRelay5.AutoSize = True
        Me.lblRelay5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelay5.ForeColor = System.Drawing.Color.Red
        Me.lblRelay5.Location = New System.Drawing.Point(296, 99)
        Me.lblRelay5.Name = "lblRelay5"
        Me.lblRelay5.Size = New System.Drawing.Size(30, 13)
        Me.lblRelay5.TabIndex = 1
        Me.lblRelay5.Text = "OFF"
        '
        'lblRelay2
        '
        Me.lblRelay2.AutoSize = True
        Me.lblRelay2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelay2.ForeColor = System.Drawing.Color.Red
        Me.lblRelay2.Location = New System.Drawing.Point(114, 128)
        Me.lblRelay2.Name = "lblRelay2"
        Me.lblRelay2.Size = New System.Drawing.Size(30, 13)
        Me.lblRelay2.TabIndex = 1
        Me.lblRelay2.Text = "OFF"
        '
        'cmdToggleRelay2
        '
        Me.cmdToggleRelay2.Location = New System.Drawing.Point(12, 123)
        Me.cmdToggleRelay2.Name = "cmdToggleRelay2"
        Me.cmdToggleRelay2.Size = New System.Drawing.Size(96, 23)
        Me.cmdToggleRelay2.TabIndex = 0
        Me.cmdToggleRelay2.Text = "Toggle Relay 2"
        Me.cmdToggleRelay2.UseVisualStyleBackColor = True
        '
        'cmdToggleRelay6
        '
        Me.cmdToggleRelay6.Location = New System.Drawing.Point(194, 123)
        Me.cmdToggleRelay6.Name = "cmdToggleRelay6"
        Me.cmdToggleRelay6.Size = New System.Drawing.Size(96, 23)
        Me.cmdToggleRelay6.TabIndex = 0
        Me.cmdToggleRelay6.Text = "Toggle Relay 2"
        Me.cmdToggleRelay6.UseVisualStyleBackColor = True
        '
        'lblRelay6
        '
        Me.lblRelay6.AutoSize = True
        Me.lblRelay6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelay6.ForeColor = System.Drawing.Color.Red
        Me.lblRelay6.Location = New System.Drawing.Point(296, 128)
        Me.lblRelay6.Name = "lblRelay6"
        Me.lblRelay6.Size = New System.Drawing.Size(30, 13)
        Me.lblRelay6.TabIndex = 1
        Me.lblRelay6.Text = "OFF"
        '
        'lblRelay1
        '
        Me.lblRelay1.AutoSize = True
        Me.lblRelay1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelay1.ForeColor = System.Drawing.Color.Red
        Me.lblRelay1.Location = New System.Drawing.Point(114, 99)
        Me.lblRelay1.Name = "lblRelay1"
        Me.lblRelay1.Size = New System.Drawing.Size(30, 13)
        Me.lblRelay1.TabIndex = 1
        Me.lblRelay1.Text = "OFF"
        '
        'cmdToggleRelay7
        '
        Me.cmdToggleRelay7.Location = New System.Drawing.Point(194, 152)
        Me.cmdToggleRelay7.Name = "cmdToggleRelay7"
        Me.cmdToggleRelay7.Size = New System.Drawing.Size(96, 23)
        Me.cmdToggleRelay7.TabIndex = 0
        Me.cmdToggleRelay7.Text = "Toggle Relay 3"
        Me.cmdToggleRelay7.UseVisualStyleBackColor = True
        '
        'lblRelay7
        '
        Me.lblRelay7.AutoSize = True
        Me.lblRelay7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelay7.ForeColor = System.Drawing.Color.Red
        Me.lblRelay7.Location = New System.Drawing.Point(296, 157)
        Me.lblRelay7.Name = "lblRelay7"
        Me.lblRelay7.Size = New System.Drawing.Size(30, 13)
        Me.lblRelay7.TabIndex = 1
        Me.lblRelay7.Text = "OFF"
        '
        'cmdToggleRelay8
        '
        Me.cmdToggleRelay8.Location = New System.Drawing.Point(194, 181)
        Me.cmdToggleRelay8.Name = "cmdToggleRelay8"
        Me.cmdToggleRelay8.Size = New System.Drawing.Size(96, 23)
        Me.cmdToggleRelay8.TabIndex = 0
        Me.cmdToggleRelay8.Text = "Toggle Relay 4"
        Me.cmdToggleRelay8.UseVisualStyleBackColor = True
        '
        'lblRelay8
        '
        Me.lblRelay8.AutoSize = True
        Me.lblRelay8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelay8.ForeColor = System.Drawing.Color.Red
        Me.lblRelay8.Location = New System.Drawing.Point(296, 186)
        Me.lblRelay8.Name = "lblRelay8"
        Me.lblRelay8.Size = New System.Drawing.Size(30, 13)
        Me.lblRelay8.TabIndex = 1
        Me.lblRelay8.Text = "OFF"
        '
        'cmdToggleRelay1
        '
        Me.cmdToggleRelay1.Location = New System.Drawing.Point(12, 94)
        Me.cmdToggleRelay1.Name = "cmdToggleRelay1"
        Me.cmdToggleRelay1.Size = New System.Drawing.Size(96, 23)
        Me.cmdToggleRelay1.TabIndex = 0
        Me.cmdToggleRelay1.Text = "Toggle Relay 1"
        Me.cmdToggleRelay1.UseVisualStyleBackColor = True
        '
        'cmdToggleAll
        '
        Me.cmdToggleAll.Location = New System.Drawing.Point(99, 222)
        Me.cmdToggleAll.Name = "cmdToggleAll"
        Me.cmdToggleAll.Size = New System.Drawing.Size(106, 23)
        Me.cmdToggleAll.TabIndex = 2
        Me.cmdToggleAll.Text = "Toggle All"
        Me.cmdToggleAll.UseVisualStyleBackColor = True
        '
        'cmdAllRelayConfiguration
        '
        Me.cmdAllRelayConfiguration.Location = New System.Drawing.Point(99, 12)
        Me.cmdAllRelayConfiguration.Name = "cmdAllRelayConfiguration"
        Me.cmdAllRelayConfiguration.Size = New System.Drawing.Size(126, 23)
        Me.cmdAllRelayConfiguration.TabIndex = 5
        Me.cmdAllRelayConfiguration.Text = "Relay Configuration"
        Me.cmdAllRelayConfiguration.UseVisualStyleBackColor = True
        '
        'lblRelayBoard1
        '
        Me.lblRelayBoard1.AutoSize = True
        Me.lblRelayBoard1.Location = New System.Drawing.Point(12, 65)
        Me.lblRelayBoard1.Name = "lblRelayBoard1"
        Me.lblRelayBoard1.Size = New System.Drawing.Size(74, 13)
        Me.lblRelayBoard1.TabIndex = 6
        Me.lblRelayBoard1.Text = "Relay Board 1"
        '
        'lblRelayBoard2
        '
        Me.lblRelayBoard2.AutoSize = True
        Me.lblRelayBoard2.Location = New System.Drawing.Point(191, 65)
        Me.lblRelayBoard2.Name = "lblRelayBoard2"
        Me.lblRelayBoard2.Size = New System.Drawing.Size(74, 13)
        Me.lblRelayBoard2.TabIndex = 6
        Me.lblRelayBoard2.Text = "Relay Board 2"
        '
        'PortOneSerialPort
        '
        Me.PortOneSerialPort.ReadTimeout = 5000
        '
        'PortTwoSerialPort
        '
        Me.PortTwoSerialPort.ReadTimeout = 5000
        '
        'frmDeviceControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 301)
        Me.Controls.Add(Me.lblRelayBoard2)
        Me.Controls.Add(Me.lblRelayBoard1)
        Me.Controls.Add(Me.cmdAllRelayConfiguration)
        Me.Controls.Add(Me.cmdToggleAll)
        Me.Controls.Add(Me.cmdToggleRelay1)
        Me.Controls.Add(Me.lblRelay8)
        Me.Controls.Add(Me.cmdToggleRelay8)
        Me.Controls.Add(Me.cmdToggleRelay4)
        Me.Controls.Add(Me.lblRelay7)
        Me.Controls.Add(Me.lblRelay4)
        Me.Controls.Add(Me.cmdToggleRelay7)
        Me.Controls.Add(Me.lblRelay3)
        Me.Controls.Add(Me.lblRelay1)
        Me.Controls.Add(Me.cmdToggleRelay3)
        Me.Controls.Add(Me.lblRelay6)
        Me.Controls.Add(Me.cmdToggleRelay5)
        Me.Controls.Add(Me.cmdToggleRelay6)
        Me.Controls.Add(Me.lblRelay5)
        Me.Controls.Add(Me.cmdToggleRelay2)
        Me.Controls.Add(Me.lblRelay2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDeviceControl"
        Me.Text = "Device Control"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
