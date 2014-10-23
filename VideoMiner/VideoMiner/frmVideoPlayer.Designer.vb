<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVideoPlayer
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVideoPlayer))
        Me.tmrVideo = New System.Windows.Forms.Timer(Me.components)
        Me.lblLoading = New System.Windows.Forms.Label
        Me.lblCurrentTime = New System.Windows.Forms.Label
        Me.tmrCurrentTime = New System.Windows.Forms.Timer(Me.components)
        Me.lblDuration = New System.Windows.Forms.Label
        Me.trkCurrentPosition = New System.Windows.Forms.TrackBar
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.pnlHideVideo = New System.Windows.Forms.Panel
        Me.plyrVideoPlayer = New AxWMPLib.AxWindowsMediaPlayer
        Me.pctVideoStatus = New System.Windows.Forms.PictureBox
        CType(Me.trkCurrentPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlHideVideo.SuspendLayout()
        CType(Me.plyrVideoPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctVideoStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrVideo
        '
        Me.tmrVideo.Interval = 500
        '
        'lblLoading
        '
        Me.lblLoading.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLoading.AutoSize = True
        Me.lblLoading.BackColor = System.Drawing.Color.Black
        Me.lblLoading.Font = New System.Drawing.Font("Calibri", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.White
        Me.lblLoading.Location = New System.Drawing.Point(232, 244)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(180, 33)
        Me.lblLoading.TabIndex = 1
        Me.lblLoading.Text = "Loading Video "
        '
        'lblCurrentTime
        '
        Me.lblCurrentTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentTime.AutoSize = True
        Me.lblCurrentTime.BackColor = System.Drawing.Color.Black
        Me.lblCurrentTime.ForeColor = System.Drawing.Color.White
        Me.lblCurrentTime.Location = New System.Drawing.Point(65, 27)
        Me.lblCurrentTime.Name = "lblCurrentTime"
        Me.lblCurrentTime.Size = New System.Drawing.Size(64, 13)
        Me.lblCurrentTime.TabIndex = 3
        Me.lblCurrentTime.Text = "00:00:00.00"
        '
        'tmrCurrentTime
        '
        Me.tmrCurrentTime.Interval = 50
        '
        'lblDuration
        '
        Me.lblDuration.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDuration.AutoSize = True
        Me.lblDuration.BackColor = System.Drawing.Color.Black
        Me.lblDuration.ForeColor = System.Drawing.Color.White
        Me.lblDuration.Location = New System.Drawing.Point(572, 27)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(64, 13)
        Me.lblDuration.TabIndex = 3
        Me.lblDuration.Text = "00:00:00.00"
        '
        'trkCurrentPosition
        '
        Me.trkCurrentPosition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trkCurrentPosition.BackColor = System.Drawing.Color.Black
        Me.trkCurrentPosition.LargeChange = 1
        Me.trkCurrentPosition.Location = New System.Drawing.Point(56, 1)
        Me.trkCurrentPosition.Maximum = 100
        Me.trkCurrentPosition.Name = "trkCurrentPosition"
        Me.trkCurrentPosition.Size = New System.Drawing.Size(583, 42)
        Me.trkCurrentPosition.TabIndex = 7
        Me.trkCurrentPosition.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Black
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlHideVideo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.plyrVideoPlayer)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblDuration)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pctVideoStatus)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblCurrentTime)
        Me.SplitContainer1.Panel2.Controls.Add(Me.trkCurrentPosition)
        Me.SplitContainer1.Size = New System.Drawing.Size(639, 557)
        Me.SplitContainer1.SplitterDistance = 510
        Me.SplitContainer1.TabIndex = 9
        '
        'pnlHideVideo
        '
        Me.pnlHideVideo.Controls.Add(Me.lblLoading)
        Me.pnlHideVideo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHideVideo.Location = New System.Drawing.Point(0, 0)
        Me.pnlHideVideo.Name = "pnlHideVideo"
        Me.pnlHideVideo.Size = New System.Drawing.Size(639, 510)
        Me.pnlHideVideo.TabIndex = 3
        '
        'plyrVideoPlayer
        '
        Me.plyrVideoPlayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plyrVideoPlayer.Enabled = True
        Me.plyrVideoPlayer.Location = New System.Drawing.Point(0, 0)
        Me.plyrVideoPlayer.Name = "plyrVideoPlayer"
        Me.plyrVideoPlayer.OcxState = CType(resources.GetObject("plyrVideoPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.plyrVideoPlayer.Size = New System.Drawing.Size(639, 510)
        Me.plyrVideoPlayer.TabIndex = 4
        '
        'pctVideoStatus
        '
        Me.pctVideoStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pctVideoStatus.Location = New System.Drawing.Point(0, 1)
        Me.pctVideoStatus.Name = "pctVideoStatus"
        Me.pctVideoStatus.Size = New System.Drawing.Size(59, 42)
        Me.pctVideoStatus.TabIndex = 8
        Me.pctVideoStatus.TabStop = False
        '
        'frmVideoPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 557)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmVideoPlayer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmVideoPlayer"
        CType(Me.trkCurrentPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlHideVideo.ResumeLayout(False)
        Me.pnlHideVideo.PerformLayout()
        CType(Me.plyrVideoPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctVideoStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrVideo As System.Windows.Forms.Timer
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents lblCurrentTime As System.Windows.Forms.Label
    Friend WithEvents tmrCurrentTime As System.Windows.Forms.Timer
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents trkCurrentPosition As System.Windows.Forms.TrackBar
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pctVideoStatus As System.Windows.Forms.PictureBox
    Friend WithEvents pnlHideVideo As System.Windows.Forms.Panel
    Friend WithEvents plyrVideoPlayer As AxWMPLib.AxWindowsMediaPlayer
End Class
