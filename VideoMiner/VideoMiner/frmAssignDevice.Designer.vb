<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssignDevice
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
        lblCurrentDevice = New System.Windows.Forms.Label
        lblDeviceNumber = New System.Windows.Forms.Label
        cmdChange = New System.Windows.Forms.Button
        cmdKeepConfiguration = New System.Windows.Forms.Button
        AssignSerialPort = New System.IO.Ports.SerialPort(components)
        SuspendLayout()
        '
        'lblCurrentDevice
        '
        lblCurrentDevice.AutoSize = True
        lblCurrentDevice.Location = New System.Drawing.Point(12, 32)
        lblCurrentDevice.Name = "lblCurrentDevice"
        lblCurrentDevice.Size = New System.Drawing.Size(213, 13)
        lblCurrentDevice.TabIndex = 0
        lblCurrentDevice.Text = "The device wired in is currently assigned to:"
        '
        'lblDeviceNumber
        '
        lblDeviceNumber.AutoSize = True
        lblDeviceNumber.Location = New System.Drawing.Point(231, 32)
        lblDeviceNumber.Name = "lblDeviceNumber"
        lblDeviceNumber.Size = New System.Drawing.Size(0, 13)
        lblDeviceNumber.TabIndex = 1
        '
        'cmdChange
        '
        cmdChange.Location = New System.Drawing.Point(14, 76)
        cmdChange.Name = "cmdChange"
        cmdChange.Size = New System.Drawing.Size(131, 23)
        cmdChange.TabIndex = 2
        cmdChange.Text = "Change Device to "
        cmdChange.UseVisualStyleBackColor = True
        '
        'cmdKeepConfiguration
        '
        cmdKeepConfiguration.Location = New System.Drawing.Point(151, 76)
        cmdKeepConfiguration.Name = "cmdKeepConfiguration"
        cmdKeepConfiguration.Size = New System.Drawing.Size(131, 23)
        cmdKeepConfiguration.TabIndex = 3
        cmdKeepConfiguration.Text = "Keep Device Number"
        cmdKeepConfiguration.UseVisualStyleBackColor = True
        '
        'AssignSerialPort
        '
        AssignSerialPort.ReadTimeout = 5000
        '
        'frmAssignDevice
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(294, 131)
        Controls.Add(cmdKeepConfiguration)
        Controls.Add(cmdChange)
        Controls.Add(lblDeviceNumber)
        Controls.Add(lblCurrentDevice)
        Name = "frmAssignDevice"
        Text = "Assign Device as Number "
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents lblCurrentDevice As System.Windows.Forms.Label
    Friend WithEvents lblDeviceNumber As System.Windows.Forms.Label
    Friend WithEvents cmdChange As System.Windows.Forms.Button
    Friend WithEvents cmdKeepConfiguration As System.Windows.Forms.Button
    Friend WithEvents AssignSerialPort As System.IO.Ports.SerialPort
End Class
