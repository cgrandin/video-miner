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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetTime))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSetTime = New System.Windows.Forms.TextBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdUseGPSTimeDate = New System.Windows.Forms.Button()
        Me.cmdContinueFromLastClip = New System.Windows.Forms.Button()
        Me.cmdUseElapsedTime = New System.Windows.Forms.Button()
        Me.cmdUseComputerTimeDate = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdPrevious = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdPlayPause = New System.Windows.Forms.Button()
        Me.txtTimeSource = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.5!)
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Set TimeCode (HHMMSSmm)"
        '
        'txtSetTime
        '
        Me.txtSetTime.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSetTime.Location = New System.Drawing.Point(12, 31)
        Me.txtSetTime.Name = "txtSetTime"
        Me.txtSetTime.Size = New System.Drawing.Size(183, 26)
        Me.txtSetTime.TabIndex = 1
        Me.txtSetTime.Text = "00000000"
        '
        'cmdOk
        '
        Me.cmdOk.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(120, 139)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(150, 30)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdUseGPSTimeDate
        '
        Me.cmdUseGPSTimeDate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUseGPSTimeDate.Location = New System.Drawing.Point(12, 58)
        Me.cmdUseGPSTimeDate.Name = "cmdUseGPSTimeDate"
        Me.cmdUseGPSTimeDate.Size = New System.Drawing.Size(183, 21)
        Me.cmdUseGPSTimeDate.TabIndex = 3
        Me.cmdUseGPSTimeDate.Text = "Use GPS Time and Date"
        Me.cmdUseGPSTimeDate.UseVisualStyleBackColor = True
        '
        'cmdContinueFromLastClip
        '
        Me.cmdContinueFromLastClip.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.cmdContinueFromLastClip.Location = New System.Drawing.Point(199, 30)
        Me.cmdContinueFromLastClip.Name = "cmdContinueFromLastClip"
        Me.cmdContinueFromLastClip.Size = New System.Drawing.Size(183, 21)
        Me.cmdContinueFromLastClip.TabIndex = 3
        Me.cmdContinueFromLastClip.Text = "Continue From Last Clip"
        Me.cmdContinueFromLastClip.UseVisualStyleBackColor = True
        '
        'cmdUseElapsedTime
        '
        Me.cmdUseElapsedTime.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUseElapsedTime.Location = New System.Drawing.Point(12, 85)
        Me.cmdUseElapsedTime.Name = "cmdUseElapsedTime"
        Me.cmdUseElapsedTime.Size = New System.Drawing.Size(183, 21)
        Me.cmdUseElapsedTime.TabIndex = 3
        Me.cmdUseElapsedTime.Text = "Use Elapsed Time"
        Me.cmdUseElapsedTime.UseVisualStyleBackColor = True
        '
        'cmdUseComputerTimeDate
        '
        Me.cmdUseComputerTimeDate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUseComputerTimeDate.Location = New System.Drawing.Point(12, 112)
        Me.cmdUseComputerTimeDate.Name = "cmdUseComputerTimeDate"
        Me.cmdUseComputerTimeDate.Size = New System.Drawing.Size(183, 21)
        Me.cmdUseComputerTimeDate.TabIndex = 3
        Me.cmdUseComputerTimeDate.Text = "Use Computer Time and Date"
        Me.cmdUseComputerTimeDate.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.BackgroundImage = CType(resources.GetObject("cmdNext.BackgroundImage"), System.Drawing.Image)
        Me.cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdNext.Location = New System.Drawing.Point(312, 80)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(26, 26)
        Me.cmdNext.TabIndex = 61
        Me.cmdNext.UseVisualStyleBackColor = True
        Me.cmdNext.Visible = False
        '
        'cmdPrevious
        '
        Me.cmdPrevious.BackgroundImage = CType(resources.GetObject("cmdPrevious.BackgroundImage"), System.Drawing.Image)
        Me.cmdPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdPrevious.Location = New System.Drawing.Point(280, 80)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(26, 26)
        Me.cmdPrevious.TabIndex = 60
        Me.cmdPrevious.UseVisualStyleBackColor = True
        Me.cmdPrevious.Visible = False
        '
        'cmdStop
        '
        Me.cmdStop.BackgroundImage = CType(resources.GetObject("cmdStop.BackgroundImage"), System.Drawing.Image)
        Me.cmdStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdStop.Location = New System.Drawing.Point(248, 80)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(26, 26)
        Me.cmdStop.TabIndex = 58
        Me.cmdStop.UseVisualStyleBackColor = True
        Me.cmdStop.Visible = False
        '
        'cmdPlayPause
        '
        Me.cmdPlayPause.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPlayPause.BackgroundImage = CType(resources.GetObject("cmdPlayPause.BackgroundImage"), System.Drawing.Image)
        Me.cmdPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdPlayPause.Location = New System.Drawing.Point(217, 80)
        Me.cmdPlayPause.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPlayPause.Name = "cmdPlayPause"
        Me.cmdPlayPause.Size = New System.Drawing.Size(26, 26)
        Me.cmdPlayPause.TabIndex = 59
        Me.cmdPlayPause.UseVisualStyleBackColor = False
        Me.cmdPlayPause.Visible = False
        '
        'txtTimeSource
        '
        Me.txtTimeSource.Location = New System.Drawing.Point(199, 3)
        Me.txtTimeSource.Name = "txtTimeSource"
        Me.txtTimeSource.ReadOnly = True
        Me.txtTimeSource.Size = New System.Drawing.Size(183, 21)
        Me.txtTimeSource.TabIndex = 62
        '
        'frmSetTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 187)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtTimeSource)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.cmdPlayPause)
        Me.Controls.Add(Me.cmdUseComputerTimeDate)
        Me.Controls.Add(Me.cmdUseElapsedTime)
        Me.Controls.Add(Me.cmdContinueFromLastClip)
        Me.Controls.Add(Me.cmdUseGPSTimeDate)
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
        Me.Text = "Set Time"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSetTime As System.Windows.Forms.TextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdUseGPSTimeDate As System.Windows.Forms.Button
    Friend WithEvents cmdContinueFromLastClip As System.Windows.Forms.Button
    Friend WithEvents cmdUseElapsedTime As System.Windows.Forms.Button
    Friend WithEvents cmdUseComputerTimeDate As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdPlayPause As System.Windows.Forms.Button
    Friend WithEvents txtTimeSource As System.Windows.Forms.TextBox
End Class
