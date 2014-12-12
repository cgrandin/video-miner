<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetTime
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.rbVideoTime = New System.Windows.Forms.RadioButton()
        Me.rbComputerTime = New System.Windows.Forms.RadioButton()
        Me.rbGPSTime = New System.Windows.Forms.RadioButton()
        Me.rbContinueTime = New System.Windows.Forms.RadioButton()
        Me.rbManualTime = New System.Windows.Forms.RadioButton()
        Me.txtSetTime = New WaterMarkTextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.5!)
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 15)
        Me.Label1.TabIndex = 0
        '
        'cmdOk
        '
        Me.cmdOk.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(12, 178)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(150, 30)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'rbVideoTime
        '
        Me.rbVideoTime.AutoSize = True
        Me.rbVideoTime.Location = New System.Drawing.Point(12, 65)
        Me.rbVideoTime.Name = "rbVideoTime"
        Me.rbVideoTime.Size = New System.Drawing.Size(85, 17)
        Me.rbVideoTime.TabIndex = 63
        Me.rbVideoTime.TabStop = True
        Me.rbVideoTime.Text = "Video time"
        Me.rbVideoTime.UseVisualStyleBackColor = True
        '
        'rbComputerTime
        '
        Me.rbComputerTime.AutoSize = True
        Me.rbComputerTime.Location = New System.Drawing.Point(12, 90)
        Me.rbComputerTime.Name = "rbComputerTime"
        Me.rbComputerTime.Size = New System.Drawing.Size(110, 17)
        Me.rbComputerTime.TabIndex = 64
        Me.rbComputerTime.TabStop = True
        Me.rbComputerTime.Text = "Computer time"
        Me.rbComputerTime.UseVisualStyleBackColor = True
        '
        'rbGPSTime
        '
        Me.rbGPSTime.AutoSize = True
        Me.rbGPSTime.Location = New System.Drawing.Point(12, 115)
        Me.rbGPSTime.Name = "rbGPSTime"
        Me.rbGPSTime.Size = New System.Drawing.Size(78, 17)
        Me.rbGPSTime.TabIndex = 65
        Me.rbGPSTime.TabStop = True
        Me.rbGPSTime.Text = "GPS Time"
        Me.rbGPSTime.UseVisualStyleBackColor = True
        '
        'rbContinueTime
        '
        Me.rbContinueTime.AutoSize = True
        Me.rbContinueTime.Location = New System.Drawing.Point(12, 142)
        Me.rbContinueTime.Name = "rbContinueTime"
        Me.rbContinueTime.Size = New System.Drawing.Size(163, 17)
        Me.rbContinueTime.TabIndex = 66
        Me.rbContinueTime.TabStop = True
        Me.rbContinueTime.Text = "Continue from last video"
        Me.rbContinueTime.UseVisualStyleBackColor = True
        '
        'rbManualTime
        '
        Me.rbManualTime.AutoSize = True
        Me.rbManualTime.Location = New System.Drawing.Point(12, 42)
        Me.rbManualTime.Name = "rbManualTime"
        Me.rbManualTime.Size = New System.Drawing.Size(95, 17)
        Me.rbManualTime.TabIndex = 67
        Me.rbManualTime.TabStop = True
        Me.rbManualTime.Text = "Manual time"
        Me.rbManualTime.UseVisualStyleBackColor = True
        '
        'txtSetTime
        '
        Me.txtSetTime.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSetTime.Location = New System.Drawing.Point(12, 7)
        Me.txtSetTime.Name = "txtSetTime"
        Me.txtSetTime.Size = New System.Drawing.Size(150, 26)
        Me.txtSetTime.TabIndex = 1
        Me.txtSetTime.WaterMarkColor = System.Drawing.Color.Gray
        Me.txtSetTime.WaterMarkText = "Water Mark"
        '
        'frmSetTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(179, 225)
        Me.ControlBox = False
        Me.Controls.Add(Me.rbManualTime)
        Me.Controls.Add(Me.rbContinueTime)
        Me.Controls.Add(Me.rbGPSTime)
        Me.Controls.Add(Me.rbComputerTime)
        Me.Controls.Add(Me.rbVideoTime)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtSetTime)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Set Time Offset"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    'Friend WithEvents txtSetTime As System.Windows.Forms.TextBox
    Friend WithEvents txtSetTime As WaterMarkTextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents rbVideoTime As System.Windows.Forms.RadioButton
    Friend WithEvents rbComputerTime As System.Windows.Forms.RadioButton
    Friend WithEvents rbGPSTime As System.Windows.Forms.RadioButton
    Friend WithEvents rbContinueTime As System.Windows.Forms.RadioButton
    Friend WithEvents rbManualTime As System.Windows.Forms.RadioButton
End Class
