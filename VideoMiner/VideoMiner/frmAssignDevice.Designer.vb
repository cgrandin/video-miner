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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssignDevice))
        Me.lblCurrentDevice = New System.Windows.Forms.Label()
        Me.lblDeviceNumber = New System.Windows.Forms.Label()
        Me.cmdChange = New System.Windows.Forms.Button()
        Me.cmdKeepConfiguration = New System.Windows.Forms.Button()
        Me.AssignSerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.SuspendLayout()
        '
        'lblCurrentDevice
        '
        Me.lblCurrentDevice.AutoSize = True
        Me.lblCurrentDevice.Location = New System.Drawing.Point(12, 32)
        Me.lblCurrentDevice.Name = "lblCurrentDevice"
        Me.lblCurrentDevice.Size = New System.Drawing.Size(213, 13)
        Me.lblCurrentDevice.TabIndex = 0
        Me.lblCurrentDevice.Text = "The device wired in is currently assigned to:"
        '
        'lblDeviceNumber
        '
        Me.lblDeviceNumber.AutoSize = True
        Me.lblDeviceNumber.Location = New System.Drawing.Point(231, 32)
        Me.lblDeviceNumber.Name = "lblDeviceNumber"
        Me.lblDeviceNumber.Size = New System.Drawing.Size(0, 13)
        Me.lblDeviceNumber.TabIndex = 1
        '
        'cmdChange
        '
        Me.cmdChange.Location = New System.Drawing.Point(14, 76)
        Me.cmdChange.Name = "cmdChange"
        Me.cmdChange.Size = New System.Drawing.Size(131, 23)
        Me.cmdChange.TabIndex = 2
        Me.cmdChange.Text = "Change Device to "
        Me.cmdChange.UseVisualStyleBackColor = True
        '
        'cmdKeepConfiguration
        '
        Me.cmdKeepConfiguration.Location = New System.Drawing.Point(151, 76)
        Me.cmdKeepConfiguration.Name = "cmdKeepConfiguration"
        Me.cmdKeepConfiguration.Size = New System.Drawing.Size(131, 23)
        Me.cmdKeepConfiguration.TabIndex = 3
        Me.cmdKeepConfiguration.Text = "Keep Device Number"
        Me.cmdKeepConfiguration.UseVisualStyleBackColor = True
        '
        'AssignSerialPort
        '
        Me.AssignSerialPort.ReadTimeout = 5000
        '
        'frmAssignDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 131)
        Me.Controls.Add(Me.cmdKeepConfiguration)
        Me.Controls.Add(Me.cmdChange)
        Me.Controls.Add(Me.lblDeviceNumber)
        Me.Controls.Add(Me.lblCurrentDevice)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAssignDevice"
        Me.Text = "Assign Device as Number "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCurrentDevice As System.Windows.Forms.Label
    Friend WithEvents lblDeviceNumber As System.Windows.Forms.Label
    Friend WithEvents cmdChange As System.Windows.Forms.Button
    Friend WithEvents cmdKeepConfiguration As System.Windows.Forms.Button
    Friend WithEvents AssignSerialPort As System.IO.Ports.SerialPort
End Class
