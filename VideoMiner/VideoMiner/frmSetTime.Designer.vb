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
        Label1 = New System.Windows.Forms.Label
        txtSetTime = New System.Windows.Forms.TextBox
        cmdOk = New System.Windows.Forms.Button
        cmdUseGPSTimeDate = New System.Windows.Forms.Button
        cmdContinueFromLastClip = New System.Windows.Forms.Button
        cmdUseElapsedTime = New System.Windows.Forms.Button
        cmdUseComputerTimeDate = New System.Windows.Forms.Button
        cmdNext = New System.Windows.Forms.Button
        cmdPrevious = New System.Windows.Forms.Button
        cmdStop = New System.Windows.Forms.Button
        cmdPlayPause = New System.Windows.Forms.Button
        txtTimeSource = New System.Windows.Forms.TextBox
        SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(9, 15)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(173, 13)
        Label1.TabIndex = 0
        Label1.Text = "Set TimeCode (HHMMSSmm):"
        '
        'txtSetTime
        '
        txtSetTime.Location = New System.Drawing.Point(12, 31)
        txtSetTime.Name = "txtSetTime"
        txtSetTime.Size = New System.Drawing.Size(183, 21)
        txtSetTime.TabIndex = 1
        txtSetTime.Text = "00000000"
        '
        'cmdOk
        '
        cmdOk.Location = New System.Drawing.Point(120, 139)
        cmdOk.Name = "cmdOk"
        cmdOk.Size = New System.Drawing.Size(150, 30)
        cmdOk.TabIndex = 2
        cmdOk.Text = "OK"
        cmdOk.UseVisualStyleBackColor = True
        '
        'cmdUseGPSTimeDate
        '
        cmdUseGPSTimeDate.Location = New System.Drawing.Point(12, 58)
        cmdUseGPSTimeDate.Name = "cmdUseGPSTimeDate"
        cmdUseGPSTimeDate.Size = New System.Drawing.Size(183, 21)
        cmdUseGPSTimeDate.TabIndex = 3
        cmdUseGPSTimeDate.Text = "Use GPS Time and Date"
        cmdUseGPSTimeDate.UseVisualStyleBackColor = True
        '
        'cmdContinueFromLastClip
        '
        cmdContinueFromLastClip.Location = New System.Drawing.Point(199, 30)
        cmdContinueFromLastClip.Name = "cmdContinueFromLastClip"
        cmdContinueFromLastClip.Size = New System.Drawing.Size(183, 21)
        cmdContinueFromLastClip.TabIndex = 3
        cmdContinueFromLastClip.Text = "Continue From Last Clip"
        cmdContinueFromLastClip.UseVisualStyleBackColor = True
        '
        'cmdUseElapsedTime
        '
        cmdUseElapsedTime.Location = New System.Drawing.Point(12, 85)
        cmdUseElapsedTime.Name = "cmdUseElapsedTime"
        cmdUseElapsedTime.Size = New System.Drawing.Size(183, 21)
        cmdUseElapsedTime.TabIndex = 3
        cmdUseElapsedTime.Text = "Use Elapsed Time"
        cmdUseElapsedTime.UseVisualStyleBackColor = True
        '
        'cmdUseComputerTimeDate
        '
        cmdUseComputerTimeDate.Location = New System.Drawing.Point(12, 112)
        cmdUseComputerTimeDate.Name = "cmdUseComputerTimeDate"
        cmdUseComputerTimeDate.Size = New System.Drawing.Size(183, 21)
        cmdUseComputerTimeDate.TabIndex = 3
        cmdUseComputerTimeDate.Text = "Use Computer Time and Date"
        cmdUseComputerTimeDate.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        cmdNext.BackgroundImage = CType(resources.GetObject("cmdNext.BackgroundImage"), System.Drawing.Image)
        cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        cmdNext.Location = New System.Drawing.Point(312, 80)
        cmdNext.Name = "cmdNext"
        cmdNext.Size = New System.Drawing.Size(26, 26)
        cmdNext.TabIndex = 61
        cmdNext.UseVisualStyleBackColor = True
        '
        'cmdPrevious
        '
        cmdPrevious.BackgroundImage = CType(resources.GetObject("cmdPrevious.BackgroundImage"), System.Drawing.Image)
        cmdPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        cmdPrevious.Location = New System.Drawing.Point(280, 80)
        cmdPrevious.Name = "cmdPrevious"
        cmdPrevious.Size = New System.Drawing.Size(26, 26)
        cmdPrevious.TabIndex = 60
        cmdPrevious.UseVisualStyleBackColor = True
        '
        'cmdStop
        '
        cmdStop.BackgroundImage = CType(resources.GetObject("cmdStop.BackgroundImage"), System.Drawing.Image)
        cmdStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        cmdStop.Location = New System.Drawing.Point(248, 80)
        cmdStop.Name = "cmdStop"
        cmdStop.Size = New System.Drawing.Size(26, 26)
        cmdStop.TabIndex = 58
        cmdStop.UseVisualStyleBackColor = True
        '
        'cmdPlayPause
        '
        cmdPlayPause.BackColor = System.Drawing.SystemColors.Control
        cmdPlayPause.BackgroundImage = CType(resources.GetObject("cmdPlayPause.BackgroundImage"), System.Drawing.Image)
        cmdPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        cmdPlayPause.Location = New System.Drawing.Point(217, 80)
        cmdPlayPause.Margin = New System.Windows.Forms.Padding(2)
        cmdPlayPause.Name = "cmdPlayPause"
        cmdPlayPause.Size = New System.Drawing.Size(26, 26)
        cmdPlayPause.TabIndex = 59
        cmdPlayPause.UseVisualStyleBackColor = False
        '
        'txtTimeSource
        '
        txtTimeSource.Location = New System.Drawing.Point(199, 3)
        txtTimeSource.Name = "txtTimeSource"
        txtTimeSource.ReadOnly = True
        txtTimeSource.Size = New System.Drawing.Size(183, 21)
        txtTimeSource.TabIndex = 62
        '
        'frmSetTime
        '
        AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(396, 187)
        ControlBox = False
        Controls.Add(txtTimeSource)
        Controls.Add(cmdNext)
        Controls.Add(cmdPrevious)
        Controls.Add(cmdStop)
        Controls.Add(cmdPlayPause)
        Controls.Add(cmdUseComputerTimeDate)
        Controls.Add(cmdUseElapsedTime)
        Controls.Add(cmdContinueFromLastClip)
        Controls.Add(cmdUseGPSTimeDate)
        Controls.Add(cmdOk)
        Controls.Add(txtSetTime)
        Controls.Add(Label1)
        Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        KeyPreview = True
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmSetTime"
        StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Text = "Set Time"
        ResumeLayout(False)
        PerformLayout()

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
