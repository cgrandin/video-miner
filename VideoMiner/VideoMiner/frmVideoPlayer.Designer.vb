Imports Vlc.DotNet.Core
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVideoPlayer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        tmrVideo = New System.Windows.Forms.Timer(components)
        lblLoading = New System.Windows.Forms.Label()
        lblCurrentTime = New System.Windows.Forms.Label()
        lblDuration = New System.Windows.Forms.Label()
        trkCurrentPosition = New System.Windows.Forms.TrackBar()
        SplitContainer1 = New System.Windows.Forms.SplitContainer()
        pnlHideVideo = New System.Windows.Forms.Panel()
        'plyrVideoPlayer = New Vlc.DotNet.Forms.VlcControl()
        pctVideoStatus = New System.Windows.Forms.PictureBox()
        CType(trkCurrentPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        pnlHideVideo.SuspendLayout()
        CType(pctVideoStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'tmrVideo
        '
        '
        'lblLoading
        '
        lblLoading.Anchor = System.Windows.Forms.AnchorStyles.None
        lblLoading.AutoSize = True
        lblLoading.BackColor = System.Drawing.Color.Black
        lblLoading.Font = New System.Drawing.Font("Calibri", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblLoading.ForeColor = System.Drawing.Color.White
        lblLoading.Location = New System.Drawing.Point(232, 244)
        lblLoading.Name = "lblLoading"
        lblLoading.Size = New System.Drawing.Size(180, 33)
        lblLoading.TabIndex = 1
        lblLoading.Text = "Loading Video "
        '
        'lblCurrentTime
        '
        lblCurrentTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        lblCurrentTime.AutoSize = True
        lblCurrentTime.BackColor = System.Drawing.Color.Black
        lblCurrentTime.ForeColor = System.Drawing.Color.White
        lblCurrentTime.Location = New System.Drawing.Point(65, 27)
        lblCurrentTime.Name = "lblCurrentTime"
        lblCurrentTime.Size = New System.Drawing.Size(70, 13)
        lblCurrentTime.TabIndex = 3
        lblCurrentTime.Text = "00:00:00.000"
        '
        'lblDuration
        '
        lblDuration.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        lblDuration.AutoSize = True
        lblDuration.BackColor = System.Drawing.Color.Black
        lblDuration.ForeColor = System.Drawing.Color.White
        lblDuration.Location = New System.Drawing.Point(566, 27)
        lblDuration.Name = "lblDuration"
        lblDuration.Size = New System.Drawing.Size(70, 13)
        lblDuration.TabIndex = 3
        lblDuration.Text = "00:00:00.000"
        '
        'trkCurrentPosition
        '
        trkCurrentPosition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        trkCurrentPosition.BackColor = System.Drawing.Color.Black
        trkCurrentPosition.LargeChange = 1
        trkCurrentPosition.Location = New System.Drawing.Point(56, 1)
        trkCurrentPosition.Maximum = 100
        trkCurrentPosition.Name = "trkCurrentPosition"
        trkCurrentPosition.Size = New System.Drawing.Size(583, 45)
        trkCurrentPosition.TabIndex = 7
        trkCurrentPosition.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'SplitContainer1
        '
        SplitContainer1.BackColor = System.Drawing.Color.Black
        SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        SplitContainer1.Location = New System.Drawing.Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        SplitContainer1.Panel1.Controls.Add(pnlHideVideo)
        SplitContainer1.Panel1.Controls.Add(plyrVideoPlayer)
        '
        'SplitContainer1.Panel2
        '
        SplitContainer1.Panel2.Controls.Add(lblDuration)
        SplitContainer1.Panel2.Controls.Add(pctVideoStatus)
        SplitContainer1.Panel2.Controls.Add(lblCurrentTime)
        SplitContainer1.Panel2.Controls.Add(trkCurrentPosition)
        SplitContainer1.Size = New System.Drawing.Size(639, 557)
        SplitContainer1.SplitterDistance = 510
        SplitContainer1.TabIndex = 9
        '
        'pnlHideVideo
        '
        pnlHideVideo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        pnlHideVideo.BackColor = System.Drawing.Color.Black
        pnlHideVideo.Controls.Add(lblLoading)
        pnlHideVideo.ForeColor = System.Drawing.SystemColors.ControlText
        pnlHideVideo.Location = New System.Drawing.Point(0, 0)
        pnlHideVideo.Name = "pnlHideVideo"
        pnlHideVideo.Size = New System.Drawing.Size(639, 510)
        pnlHideVideo.TabIndex = 3
        '
        'plyrVideoPlayer
        '
        plyrVideoPlayer.Dock = System.Windows.Forms.DockStyle.Fill
        plyrVideoPlayer.Location = New System.Drawing.Point(0, 0)
        plyrVideoPlayer.Name = "plyrVideoPlayer"
        plyrVideoPlayer.settings.rate = 0.0
        plyrVideoPlayer.Size = New System.Drawing.Size(639, 510)
        plyrVideoPlayer.TabIndex = 4
        '
        'pctVideoStatus
        '
        pctVideoStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        pctVideoStatus.Location = New System.Drawing.Point(0, 1)
        pctVideoStatus.Name = "pctVideoStatus"
        pctVideoStatus.Size = New System.Drawing.Size(59, 42)
        pctVideoStatus.TabIndex = 8
        pctVideoStatus.TabStop = False
        '
        'frmVideoPlayer
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(639, 557)
        Controls.Add(SplitContainer1)
        Name = "frmVideoPlayer"
        StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Text = "frmVideoPlayer"
        CType(trkCurrentPosition, System.ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        pnlHideVideo.ResumeLayout(False)
        pnlHideVideo.PerformLayout()
        CType(pctVideoStatus, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Friend WithEvents tmrVideo As System.Windows.Forms.Timer
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents lblCurrentTime As System.Windows.Forms.Label
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents trkCurrentPosition As System.Windows.Forms.TrackBar
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pctVideoStatus As System.Windows.Forms.PictureBox
    Friend WithEvents pnlHideVideo As System.Windows.Forms.Panel
    Friend WithEvents plyrVideoPlayer As AxWMPLib.AxWindowsMediaPlayer
End Class
