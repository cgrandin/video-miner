<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGpsSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        Label1 = New System.Windows.Forms.Label
        cboComPort = New System.Windows.Forms.ComboBox
        Label2 = New System.Windows.Forms.Label
        cboBaudRate = New System.Windows.Forms.ComboBox
        Label3 = New System.Windows.Forms.Label
        cboParity = New System.Windows.Forms.ComboBox
        Label4 = New System.Windows.Forms.Label
        txtDataBits = New System.Windows.Forms.TextBox
        Label5 = New System.Windows.Forms.Label
        cboStopBits = New System.Windows.Forms.ComboBox
        cmdOK = New System.Windows.Forms.Button
        lblGPSPortMessage = New System.Windows.Forms.Label
        cmdConnection = New System.Windows.Forms.Button
        StatusStrip1 = New System.Windows.Forms.StatusStrip
        ToolStripStatusLabelX = New System.Windows.Forms.ToolStripStatusLabel
        ToolStripStatusLabelY = New System.Windows.Forms.ToolStripStatusLabel
        ToolStripStatusLabelZ = New System.Windows.Forms.ToolStripStatusLabel
        ToolStripStatusLabelTime = New System.Windows.Forms.ToolStripStatusLabel
        Label7 = New System.Windows.Forms.Label
        radGPGGA = New System.Windows.Forms.RadioButton
        radGPRMC = New System.Windows.Forms.RadioButton
        GroupBox1 = New System.Windows.Forms.GroupBox
        lblCurrentTime = New System.Windows.Forms.Label
        lblCurrentTimeValue = New System.Windows.Forms.Label
        lblCurrentDateValue = New System.Windows.Forms.Label
        lblCurrentDate = New System.Windows.Forms.Label
        lblCurrentZValue = New System.Windows.Forms.Label
        lblCurrentZ = New System.Windows.Forms.Label
        lblCurrentYValue = New System.Windows.Forms.Label
        lblCurrentY = New System.Windows.Forms.Label
        lblCurrentXValue = New System.Windows.Forms.Label
        lblCurrentX = New System.Windows.Forms.Label
        lblDateTime = New System.Windows.Forms.Label
        lblCurrentLocation = New System.Windows.Forms.Label
        lblGPSConnection = New System.Windows.Forms.Label
        lblGPSMessage = New System.Windows.Forms.Label
        lblGPSPort = New System.Windows.Forms.Label
        tmrGPSTimeout = New System.Windows.Forms.Timer(components)
        StatusStrip1.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(14, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(62, 13)
        Label1.TabIndex = 0
        Label1.Text = "COM Port:"
        '
        'cboComPort
        '
        cboComPort.FormattingEnabled = True
        cboComPort.Location = New System.Drawing.Point(12, 25)
        cboComPort.Name = "cboComPort"
        cboComPort.Size = New System.Drawing.Size(121, 21)
        cboComPort.TabIndex = 1
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(172, 9)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(71, 13)
        Label2.TabIndex = 2
        Label2.Text = "BAUD Rate:"
        '
        'cboBaudRate
        '
        cboBaudRate.FormattingEnabled = True
        cboBaudRate.Location = New System.Drawing.Point(170, 25)
        cboBaudRate.Name = "cboBaudRate"
        cboBaudRate.Size = New System.Drawing.Size(121, 21)
        cboBaudRate.TabIndex = 3
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(14, 49)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(44, 13)
        Label3.TabIndex = 4
        Label3.Text = "Parity:"
        '
        'cboParity
        '
        cboParity.FormattingEnabled = True
        cboParity.Location = New System.Drawing.Point(12, 65)
        cboParity.Name = "cboParity"
        cboParity.Size = New System.Drawing.Size(121, 21)
        cboParity.TabIndex = 5
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.Location = New System.Drawing.Point(172, 49)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(61, 13)
        Label4.TabIndex = 6
        Label4.Text = "Data Bits:"
        '
        'txtDataBits
        '
        txtDataBits.Location = New System.Drawing.Point(170, 65)
        txtDataBits.Name = "txtDataBits"
        txtDataBits.Size = New System.Drawing.Size(121, 21)
        txtDataBits.TabIndex = 7
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(14, 89)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(60, 13)
        Label5.TabIndex = 8
        Label5.Text = "Stop Bits:"
        '
        'cboStopBits
        '
        cboStopBits.FormattingEnabled = True
        cboStopBits.Location = New System.Drawing.Point(12, 105)
        cboStopBits.Name = "cboStopBits"
        cboStopBits.Size = New System.Drawing.Size(121, 21)
        cboStopBits.TabIndex = 9
        '
        'cmdOK
        '
        cmdOK.Location = New System.Drawing.Point(115, 331)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(75, 23)
        cmdOK.TabIndex = 10
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'lblGPSPortMessage
        '
        lblGPSPortMessage.AutoSize = True
        lblGPSPortMessage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblGPSPortMessage.ForeColor = System.Drawing.Color.Red
        lblGPSPortMessage.Location = New System.Drawing.Point(110, 62)
        lblGPSPortMessage.Name = "lblGPSPortMessage"
        lblGPSPortMessage.Size = New System.Drawing.Size(56, 16)
        lblGPSPortMessage.TabIndex = 13
        lblGPSPortMessage.Text = "CLOSED"
        lblGPSPortMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdConnection
        '
        cmdConnection.Location = New System.Drawing.Point(6, 20)
        cmdConnection.Name = "cmdConnection"
        cmdConnection.Size = New System.Drawing.Size(171, 23)
        cmdConnection.TabIndex = 14
        cmdConnection.Text = "Open GPS Connection"
        cmdConnection.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {ToolStripStatusLabelX, ToolStripStatusLabelY, ToolStripStatusLabelZ, ToolStripStatusLabelTime})
        StatusStrip1.Location = New System.Drawing.Point(0, 366)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New System.Drawing.Size(304, 22)
        StatusStrip1.TabIndex = 16
        StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelX
        '
        ToolStripStatusLabelX.Name = "ToolStripStatusLabelX"
        ToolStripStatusLabelX.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabelY
        '
        ToolStripStatusLabelY.Name = "ToolStripStatusLabelY"
        ToolStripStatusLabelY.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabelZ
        '
        ToolStripStatusLabelZ.Name = "ToolStripStatusLabelZ"
        ToolStripStatusLabelZ.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabelTime
        '
        ToolStripStatusLabelTime.Name = "ToolStripStatusLabelTime"
        ToolStripStatusLabelTime.Size = New System.Drawing.Size(0, 17)
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(172, 93)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(109, 13)
        Label7.TabIndex = 17
        Label7.Text = "NMEA String Type:"
        '
        'radGPGGA
        '
        radGPGGA.AutoSize = True
        radGPGGA.Checked = True
        radGPGGA.Location = New System.Drawing.Point(170, 109)
        radGPGGA.Name = "radGPGGA"
        radGPGGA.Size = New System.Drawing.Size(64, 17)
        radGPGGA.TabIndex = 18
        radGPGGA.TabStop = True
        radGPGGA.Text = "GPGGA"
        radGPGGA.UseVisualStyleBackColor = True
        '
        'radGPRMC
        '
        radGPRMC.AutoSize = True
        radGPRMC.Location = New System.Drawing.Point(240, 109)
        radGPRMC.Name = "radGPRMC"
        radGPRMC.Size = New System.Drawing.Size(65, 17)
        radGPRMC.TabIndex = 19
        radGPRMC.TabStop = True
        radGPRMC.Text = "GPRMC"
        radGPRMC.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        GroupBox1.Controls.Add(lblCurrentTime)
        GroupBox1.Controls.Add(lblCurrentTimeValue)
        GroupBox1.Controls.Add(lblCurrentDateValue)
        GroupBox1.Controls.Add(lblCurrentDate)
        GroupBox1.Controls.Add(lblCurrentZValue)
        GroupBox1.Controls.Add(lblCurrentZ)
        GroupBox1.Controls.Add(lblCurrentYValue)
        GroupBox1.Controls.Add(lblCurrentY)
        GroupBox1.Controls.Add(lblCurrentXValue)
        GroupBox1.Controls.Add(lblCurrentX)
        GroupBox1.Controls.Add(lblDateTime)
        GroupBox1.Controls.Add(lblCurrentLocation)
        GroupBox1.Controls.Add(lblGPSConnection)
        GroupBox1.Controls.Add(lblGPSMessage)
        GroupBox1.Controls.Add(lblGPSPort)
        GroupBox1.Controls.Add(lblGPSPortMessage)
        GroupBox1.Controls.Add(cmdConnection)
        GroupBox1.Location = New System.Drawing.Point(12, 132)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New System.Drawing.Size(279, 193)
        GroupBox1.TabIndex = 20
        GroupBox1.TabStop = False
        '
        'lblCurrentTime
        '
        lblCurrentTime.AutoSize = True
        lblCurrentTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCurrentTime.Location = New System.Drawing.Point(120, 142)
        lblCurrentTime.Name = "lblCurrentTime"
        lblCurrentTime.Size = New System.Drawing.Size(62, 13)
        lblCurrentTime.TabIndex = 12
        lblCurrentTime.Text = "Time(GMT):"
        '
        'lblCurrentTimeValue
        '
        lblCurrentTimeValue.AutoSize = True
        lblCurrentTimeValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCurrentTimeValue.Location = New System.Drawing.Point(188, 142)
        lblCurrentTimeValue.Name = "lblCurrentTimeValue"
        lblCurrentTimeValue.Size = New System.Drawing.Size(0, 13)
        lblCurrentTimeValue.TabIndex = 12
        '
        'lblCurrentDateValue
        '
        lblCurrentDateValue.AutoSize = True
        lblCurrentDateValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCurrentDateValue.Location = New System.Drawing.Point(188, 126)
        lblCurrentDateValue.Name = "lblCurrentDateValue"
        lblCurrentDateValue.Size = New System.Drawing.Size(0, 13)
        lblCurrentDateValue.TabIndex = 12
        '
        'lblCurrentDate
        '
        lblCurrentDate.AutoSize = True
        lblCurrentDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCurrentDate.Location = New System.Drawing.Point(120, 126)
        lblCurrentDate.Name = "lblCurrentDate"
        lblCurrentDate.Size = New System.Drawing.Size(34, 13)
        lblCurrentDate.TabIndex = 12
        lblCurrentDate.Text = "Date:"
        '
        'lblCurrentZValue
        '
        lblCurrentZValue.AutoSize = True
        lblCurrentZValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCurrentZValue.Location = New System.Drawing.Point(46, 158)
        lblCurrentZValue.Name = "lblCurrentZValue"
        lblCurrentZValue.Size = New System.Drawing.Size(0, 13)
        lblCurrentZValue.TabIndex = 12
        '
        'lblCurrentZ
        '
        lblCurrentZ.AutoSize = True
        lblCurrentZ.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCurrentZ.Location = New System.Drawing.Point(6, 158)
        lblCurrentZ.Name = "lblCurrentZ"
        lblCurrentZ.Size = New System.Drawing.Size(17, 13)
        lblCurrentZ.TabIndex = 12
        lblCurrentZ.Text = "Z:"
        '
        'lblCurrentYValue
        '
        lblCurrentYValue.AutoSize = True
        lblCurrentYValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCurrentYValue.Location = New System.Drawing.Point(46, 142)
        lblCurrentYValue.Name = "lblCurrentYValue"
        lblCurrentYValue.Size = New System.Drawing.Size(0, 13)
        lblCurrentYValue.TabIndex = 12
        '
        'lblCurrentY
        '
        lblCurrentY.AutoSize = True
        lblCurrentY.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCurrentY.Location = New System.Drawing.Point(6, 142)
        lblCurrentY.Name = "lblCurrentY"
        lblCurrentY.Size = New System.Drawing.Size(17, 13)
        lblCurrentY.TabIndex = 12
        lblCurrentY.Text = "Y:"
        '
        'lblCurrentXValue
        '
        lblCurrentXValue.AutoSize = True
        lblCurrentXValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCurrentXValue.Location = New System.Drawing.Point(46, 126)
        lblCurrentXValue.Name = "lblCurrentXValue"
        lblCurrentXValue.Size = New System.Drawing.Size(0, 13)
        lblCurrentXValue.TabIndex = 12
        '
        'lblCurrentX
        '
        lblCurrentX.AutoSize = True
        lblCurrentX.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCurrentX.Location = New System.Drawing.Point(6, 126)
        lblCurrentX.Name = "lblCurrentX"
        lblCurrentX.Size = New System.Drawing.Size(17, 13)
        lblCurrentX.TabIndex = 12
        lblCurrentX.Text = "X:"
        '
        'lblDateTime
        '
        lblDateTime.AutoSize = True
        lblDateTime.Location = New System.Drawing.Point(117, 110)
        lblDateTime.Name = "lblDateTime"
        lblDateTime.Size = New System.Drawing.Size(114, 13)
        lblDateTime.TabIndex = 12
        lblDateTime.Text = "GPS Date and Time"
        '
        'lblCurrentLocation
        '
        lblCurrentLocation.AutoSize = True
        lblCurrentLocation.Location = New System.Drawing.Point(3, 110)
        lblCurrentLocation.Name = "lblCurrentLocation"
        lblCurrentLocation.Size = New System.Drawing.Size(80, 13)
        lblCurrentLocation.TabIndex = 12
        lblCurrentLocation.Text = "GPS Location"
        '
        'lblGPSConnection
        '
        lblGPSConnection.AutoSize = True
        lblGPSConnection.Location = New System.Drawing.Point(6, 83)
        lblGPSConnection.Name = "lblGPSConnection"
        lblGPSConnection.Size = New System.Drawing.Size(98, 13)
        lblGPSConnection.TabIndex = 12
        lblGPSConnection.Text = "GPS Connection:"
        '
        'lblGPSMessage
        '
        lblGPSMessage.AutoSize = True
        lblGPSMessage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblGPSMessage.ForeColor = System.Drawing.Color.Red
        lblGPSMessage.Location = New System.Drawing.Point(110, 81)
        lblGPSMessage.Name = "lblGPSMessage"
        lblGPSMessage.Size = New System.Drawing.Size(77, 16)
        lblGPSMessage.TabIndex = 13
        lblGPSMessage.Text = "NO GPS FIX"
        lblGPSMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGPSPort
        '
        lblGPSPort.AutoSize = True
        lblGPSPort.Location = New System.Drawing.Point(6, 62)
        lblGPSPort.Name = "lblGPSPort"
        lblGPSPort.Size = New System.Drawing.Size(59, 13)
        lblGPSPort.TabIndex = 12
        lblGPSPort.Text = "GPS Port:"
        '
        'tmrGPSTimeout
        '
        tmrGPSTimeout.Interval = 1000
        '
        'frmGpsSettings
        '
        AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(304, 388)
        ControlBox = False
        Controls.Add(GroupBox1)
        Controls.Add(radGPRMC)
        Controls.Add(radGPGGA)
        Controls.Add(Label7)
        Controls.Add(StatusStrip1)
        Controls.Add(cmdOK)
        Controls.Add(cboStopBits)
        Controls.Add(Label5)
        Controls.Add(txtDataBits)
        Controls.Add(Label4)
        Controls.Add(cboParity)
        Controls.Add(Label3)
        Controls.Add(cboBaudRate)
        Controls.Add(Label2)
        Controls.Add(cboComPort)
        Controls.Add(Label1)
        Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmGpsSettings"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Text = "GPS Settings"
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboComPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboParity As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDataBits As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboStopBits As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents lblGPSPortMessage As System.Windows.Forms.Label
    Friend WithEvents cmdConnection As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelX As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelY As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelZ As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents radGPGGA As System.Windows.Forms.RadioButton
    Friend WithEvents radGPRMC As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblGPSPort As System.Windows.Forms.Label
    Friend WithEvents lblGPSConnection As System.Windows.Forms.Label
    Friend WithEvents lblGPSMessage As System.Windows.Forms.Label
    Friend WithEvents lblCurrentLocation As System.Windows.Forms.Label
    Friend WithEvents lblCurrentTime As System.Windows.Forms.Label
    Friend WithEvents lblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents lblCurrentZ As System.Windows.Forms.Label
    Friend WithEvents lblCurrentY As System.Windows.Forms.Label
    Friend WithEvents lblCurrentX As System.Windows.Forms.Label
    Friend WithEvents lblDateTime As System.Windows.Forms.Label
    Friend WithEvents lblCurrentTimeValue As System.Windows.Forms.Label
    Friend WithEvents lblCurrentDateValue As System.Windows.Forms.Label
    Friend WithEvents lblCurrentZValue As System.Windows.Forms.Label
    Friend WithEvents lblCurrentYValue As System.Windows.Forms.Label
    Friend WithEvents lblCurrentXValue As System.Windows.Forms.Label
    Friend WithEvents tmrGPSTimeout As System.Windows.Forms.Timer
End Class
