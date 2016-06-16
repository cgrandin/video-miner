<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVideoPlayer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVideoPlayer))
        Me.plyrVideoPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        Me.tmrVideo = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.plyrVideoPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'plyrVideoPlayer
        '
        Me.plyrVideoPlayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plyrVideoPlayer.Enabled = True
        Me.plyrVideoPlayer.Location = New System.Drawing.Point(0, 0)
        Me.plyrVideoPlayer.Name = "plyrVideoPlayer"
        Me.plyrVideoPlayer.OcxState = CType(resources.GetObject("plyrVideoPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.plyrVideoPlayer.Size = New System.Drawing.Size(710, 584)
        Me.plyrVideoPlayer.TabIndex = 0
        '
        'tmrVideo
        '
        '
        'frmVideoPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 584)
        Me.Controls.Add(Me.plyrVideoPlayer)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "frmVideoPlayer"
        Me.Text = "frmVideoPlayer"
        CType(Me.plyrVideoPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents plyrVideoPlayer As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents tmrVideo As Windows.Forms.Timer
    Friend WithEvents Timer1 As Windows.Forms.Timer
End Class
