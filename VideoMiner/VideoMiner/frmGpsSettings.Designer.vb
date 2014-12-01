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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboComPort = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboBaudRate = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboParity = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDataBits = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboStopBits = New System.Windows.Forms.ComboBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.lblGPSPortMessage = New System.Windows.Forms.Label()
        Me.cmdConnection = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.radGPGGA = New System.Windows.Forms.RadioButton()
        Me.radGPRMC = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdViewPortData = New System.Windows.Forms.Button()
        Me.lblCurrentTime = New System.Windows.Forms.Label()
        Me.lblCurrentTimeValue = New System.Windows.Forms.Label()
        Me.lblCurrentDateValue = New System.Windows.Forms.Label()
        Me.lblCurrentDate = New System.Windows.Forms.Label()
        Me.lblCurrentZValue = New System.Windows.Forms.Label()
        Me.lblCurrentZ = New System.Windows.Forms.Label()
        Me.lblCurrentYValue = New System.Windows.Forms.Label()
        Me.lblCurrentY = New System.Windows.Forms.Label()
        Me.lblCurrentXValue = New System.Windows.Forms.Label()
        Me.lblCurrentX = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.lblCurrentLocation = New System.Windows.Forms.Label()
        Me.lblGPSConnection = New System.Windows.Forms.Label()
        Me.lblGPSMessage = New System.Windows.Forms.Label()
        Me.lblGPSPort = New System.Windows.Forms.Label()
        Me.txtTimeout = New System.Windows.Forms.TextBox()
        Me.lblTimeout = New System.Windows.Forms.Label()
        Me.tmrGPSTimeout = New System.Windows.Forms.Timer(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "COM Port:"
        '
        'cboComPort
        '
        Me.cboComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComPort.FormattingEnabled = True
        Me.cboComPort.Location = New System.Drawing.Point(12, 25)
        Me.cboComPort.Name = "cboComPort"
        Me.cboComPort.Size = New System.Drawing.Size(121, 21)
        Me.cboComPort.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(172, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "BAUD Rate:"
        '
        'cboBaudRate
        '
        Me.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBaudRate.FormattingEnabled = True
        Me.cboBaudRate.Location = New System.Drawing.Point(170, 25)
        Me.cboBaudRate.Name = "cboBaudRate"
        Me.cboBaudRate.Size = New System.Drawing.Size(121, 21)
        Me.cboBaudRate.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Parity:"
        '
        'cboParity
        '
        Me.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParity.FormattingEnabled = True
        Me.cboParity.Location = New System.Drawing.Point(12, 65)
        Me.cboParity.Name = "cboParity"
        Me.cboParity.Size = New System.Drawing.Size(121, 21)
        Me.cboParity.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(172, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Data Bits:"
        '
        'txtDataBits
        '
        Me.txtDataBits.Location = New System.Drawing.Point(170, 65)
        Me.txtDataBits.Name = "txtDataBits"
        Me.txtDataBits.Size = New System.Drawing.Size(121, 21)
        Me.txtDataBits.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Stop Bits:"
        '
        'cboStopBits
        '
        Me.cboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStopBits.FormattingEnabled = True
        Me.cboStopBits.Location = New System.Drawing.Point(12, 105)
        Me.cboStopBits.Name = "cboStopBits"
        Me.cboStopBits.Size = New System.Drawing.Size(121, 21)
        Me.cboStopBits.TabIndex = 9
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(82, 366)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 32)
        Me.cmdOK.TabIndex = 10
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'lblGPSPortMessage
        '
        Me.lblGPSPortMessage.AutoSize = True
        Me.lblGPSPortMessage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGPSPortMessage.ForeColor = System.Drawing.Color.Red
        Me.lblGPSPortMessage.Location = New System.Drawing.Point(164, 73)
        Me.lblGPSPortMessage.Name = "lblGPSPortMessage"
        Me.lblGPSPortMessage.Size = New System.Drawing.Size(56, 16)
        Me.lblGPSPortMessage.TabIndex = 13
        Me.lblGPSPortMessage.Text = "CLOSED"
        Me.lblGPSPortMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdConnection
        '
        Me.cmdConnection.Location = New System.Drawing.Point(2, 20)
        Me.cmdConnection.Name = "cmdConnection"
        Me.cmdConnection.Size = New System.Drawing.Size(121, 39)
        Me.cmdConnection.TabIndex = 14
        Me.cmdConnection.Text = "Open GPS Connection"
        Me.cmdConnection.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(172, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "NMEA String Type:"
        '
        'radGPGGA
        '
        Me.radGPGGA.AutoSize = True
        Me.radGPGGA.Checked = True
        Me.radGPGGA.Location = New System.Drawing.Point(170, 109)
        Me.radGPGGA.Name = "radGPGGA"
        Me.radGPGGA.Size = New System.Drawing.Size(64, 17)
        Me.radGPGGA.TabIndex = 18
        Me.radGPGGA.TabStop = True
        Me.radGPGGA.Text = "GPGGA"
        Me.radGPGGA.UseVisualStyleBackColor = True
        '
        'radGPRMC
        '
        Me.radGPRMC.AutoSize = True
        Me.radGPRMC.Location = New System.Drawing.Point(240, 109)
        Me.radGPRMC.Name = "radGPRMC"
        Me.radGPRMC.Size = New System.Drawing.Size(65, 17)
        Me.radGPRMC.TabIndex = 19
        Me.radGPRMC.TabStop = True
        Me.radGPRMC.Text = "GPRMC"
        Me.radGPRMC.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdViewPortData)
        Me.GroupBox1.Controls.Add(Me.lblCurrentTime)
        Me.GroupBox1.Controls.Add(Me.lblCurrentTimeValue)
        Me.GroupBox1.Controls.Add(Me.lblCurrentDateValue)
        Me.GroupBox1.Controls.Add(Me.lblCurrentDate)
        Me.GroupBox1.Controls.Add(Me.lblCurrentZValue)
        Me.GroupBox1.Controls.Add(Me.lblCurrentZ)
        Me.GroupBox1.Controls.Add(Me.lblCurrentYValue)
        Me.GroupBox1.Controls.Add(Me.lblCurrentY)
        Me.GroupBox1.Controls.Add(Me.lblCurrentXValue)
        Me.GroupBox1.Controls.Add(Me.lblCurrentX)
        Me.GroupBox1.Controls.Add(Me.lblDateTime)
        Me.GroupBox1.Controls.Add(Me.lblCurrentLocation)
        Me.GroupBox1.Controls.Add(Me.lblGPSConnection)
        Me.GroupBox1.Controls.Add(Me.lblGPSMessage)
        Me.GroupBox1.Controls.Add(Me.lblGPSPort)
        Me.GroupBox1.Controls.Add(Me.lblGPSPortMessage)
        Me.GroupBox1.Controls.Add(Me.cmdConnection)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 155)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 204)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'cmdViewPortData
        '
        Me.cmdViewPortData.Location = New System.Drawing.Point(160, 20)
        Me.cmdViewPortData.Name = "cmdViewPortData"
        Me.cmdViewPortData.Size = New System.Drawing.Size(115, 39)
        Me.cmdViewPortData.TabIndex = 15
        Me.cmdViewPortData.Text = "View port data"
        Me.cmdViewPortData.UseVisualStyleBackColor = True
        '
        'lblCurrentTime
        '
        Me.lblCurrentTime.AutoSize = True
        Me.lblCurrentTime.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentTime.Location = New System.Drawing.Point(164, 153)
        Me.lblCurrentTime.Name = "lblCurrentTime"
        Me.lblCurrentTime.Size = New System.Drawing.Size(82, 15)
        Me.lblCurrentTime.TabIndex = 12
        Me.lblCurrentTime.Text = "Time(GMT):"
        '
        'lblCurrentTimeValue
        '
        Me.lblCurrentTimeValue.AutoSize = True
        Me.lblCurrentTimeValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentTimeValue.Location = New System.Drawing.Point(188, 142)
        Me.lblCurrentTimeValue.Name = "lblCurrentTimeValue"
        Me.lblCurrentTimeValue.Size = New System.Drawing.Size(0, 13)
        Me.lblCurrentTimeValue.TabIndex = 12
        '
        'lblCurrentDateValue
        '
        Me.lblCurrentDateValue.AutoSize = True
        Me.lblCurrentDateValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentDateValue.Location = New System.Drawing.Point(188, 126)
        Me.lblCurrentDateValue.Name = "lblCurrentDateValue"
        Me.lblCurrentDateValue.Size = New System.Drawing.Size(0, 13)
        Me.lblCurrentDateValue.TabIndex = 12
        '
        'lblCurrentDate
        '
        Me.lblCurrentDate.AutoSize = True
        Me.lblCurrentDate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentDate.Location = New System.Drawing.Point(164, 133)
        Me.lblCurrentDate.Name = "lblCurrentDate"
        Me.lblCurrentDate.Size = New System.Drawing.Size(42, 15)
        Me.lblCurrentDate.TabIndex = 12
        Me.lblCurrentDate.Text = "Date:"
        '
        'lblCurrentZValue
        '
        Me.lblCurrentZValue.AutoSize = True
        Me.lblCurrentZValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentZValue.Location = New System.Drawing.Point(46, 158)
        Me.lblCurrentZValue.Name = "lblCurrentZValue"
        Me.lblCurrentZValue.Size = New System.Drawing.Size(0, 13)
        Me.lblCurrentZValue.TabIndex = 12
        '
        'lblCurrentZ
        '
        Me.lblCurrentZ.AutoSize = True
        Me.lblCurrentZ.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentZ.Location = New System.Drawing.Point(15, 173)
        Me.lblCurrentZ.Name = "lblCurrentZ"
        Me.lblCurrentZ.Size = New System.Drawing.Size(19, 15)
        Me.lblCurrentZ.TabIndex = 12
        Me.lblCurrentZ.Text = "Z:"
        '
        'lblCurrentYValue
        '
        Me.lblCurrentYValue.AutoSize = True
        Me.lblCurrentYValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentYValue.Location = New System.Drawing.Point(46, 142)
        Me.lblCurrentYValue.Name = "lblCurrentYValue"
        Me.lblCurrentYValue.Size = New System.Drawing.Size(0, 13)
        Me.lblCurrentYValue.TabIndex = 12
        '
        'lblCurrentY
        '
        Me.lblCurrentY.AutoSize = True
        Me.lblCurrentY.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentY.Location = New System.Drawing.Point(15, 152)
        Me.lblCurrentY.Name = "lblCurrentY"
        Me.lblCurrentY.Size = New System.Drawing.Size(19, 15)
        Me.lblCurrentY.TabIndex = 12
        Me.lblCurrentY.Text = "Y:"
        '
        'lblCurrentXValue
        '
        Me.lblCurrentXValue.AutoSize = True
        Me.lblCurrentXValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentXValue.Location = New System.Drawing.Point(46, 126)
        Me.lblCurrentXValue.Name = "lblCurrentXValue"
        Me.lblCurrentXValue.Size = New System.Drawing.Size(0, 13)
        Me.lblCurrentXValue.TabIndex = 12
        '
        'lblCurrentX
        '
        Me.lblCurrentX.AutoSize = True
        Me.lblCurrentX.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentX.Location = New System.Drawing.Point(15, 131)
        Me.lblCurrentX.Name = "lblCurrentX"
        Me.lblCurrentX.Size = New System.Drawing.Size(19, 15)
        Me.lblCurrentX.TabIndex = 12
        Me.lblCurrentX.Text = "X:"
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Location = New System.Drawing.Point(164, 115)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(114, 13)
        Me.lblDateTime.TabIndex = 12
        Me.lblDateTime.Text = "GPS Date and Time"
        '
        'lblCurrentLocation
        '
        Me.lblCurrentLocation.AutoSize = True
        Me.lblCurrentLocation.Location = New System.Drawing.Point(12, 115)
        Me.lblCurrentLocation.Name = "lblCurrentLocation"
        Me.lblCurrentLocation.Size = New System.Drawing.Size(80, 13)
        Me.lblCurrentLocation.TabIndex = 12
        Me.lblCurrentLocation.Text = "GPS Location"
        '
        'lblGPSConnection
        '
        Me.lblGPSConnection.AutoSize = True
        Me.lblGPSConnection.Location = New System.Drawing.Point(12, 95)
        Me.lblGPSConnection.Name = "lblGPSConnection"
        Me.lblGPSConnection.Size = New System.Drawing.Size(98, 13)
        Me.lblGPSConnection.TabIndex = 12
        Me.lblGPSConnection.Text = "GPS Connection:"
        '
        'lblGPSMessage
        '
        Me.lblGPSMessage.AutoSize = True
        Me.lblGPSMessage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGPSMessage.ForeColor = System.Drawing.Color.Red
        Me.lblGPSMessage.Location = New System.Drawing.Point(164, 92)
        Me.lblGPSMessage.Name = "lblGPSMessage"
        Me.lblGPSMessage.Size = New System.Drawing.Size(77, 16)
        Me.lblGPSMessage.TabIndex = 13
        Me.lblGPSMessage.Text = "NO GPS FIX"
        Me.lblGPSMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGPSPort
        '
        Me.lblGPSPort.AutoSize = True
        Me.lblGPSPort.Location = New System.Drawing.Point(12, 74)
        Me.lblGPSPort.Name = "lblGPSPort"
        Me.lblGPSPort.Size = New System.Drawing.Size(69, 13)
        Me.lblGPSPort.TabIndex = 12
        Me.lblGPSPort.Text = "Serial Port:"
        '
        'txtTimeout
        '
        Me.txtTimeout.Location = New System.Drawing.Point(169, 135)
        Me.txtTimeout.Name = "txtTimeout"
        Me.txtTimeout.Size = New System.Drawing.Size(121, 21)
        Me.txtTimeout.TabIndex = 17
        '
        'lblTimeout
        '
        Me.lblTimeout.AutoSize = True
        Me.lblTimeout.Location = New System.Drawing.Point(14, 139)
        Me.lblTimeout.Name = "lblTimeout"
        Me.lblTimeout.Size = New System.Drawing.Size(95, 13)
        Me.lblTimeout.TabIndex = 16
        Me.lblTimeout.Text = "Timeout (secs):"
        '
        'tmrGPSTimeout
        '
        Me.tmrGPSTimeout.Interval = 1000
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(163, 366)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 32)
        Me.cmdCancel.TabIndex = 21
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmGpsSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 407)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtTimeout)
        Me.Controls.Add(Me.lblTimeout)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.radGPRMC)
        Me.Controls.Add(Me.radGPGGA)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cboStopBits)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDataBits)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboParity)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboBaudRate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboComPort)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGpsSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "GPS Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdViewPortData As System.Windows.Forms.Button
    Friend WithEvents lblTimeout As System.Windows.Forms.Label
    Friend WithEvents txtTimeout As System.Windows.Forms.TextBox
End Class
