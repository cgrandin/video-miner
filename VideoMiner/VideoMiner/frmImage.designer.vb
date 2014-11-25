<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImage
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
        Panel1 = New System.Windows.Forms.Panel
        PictureBox1 = New System.Windows.Forms.PictureBox
        Panel1.SuspendLayout()
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'Panel1
        '
        Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Panel1.AutoScroll = True
        Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New System.Drawing.Point(12, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New System.Drawing.Size(677, 657)
        Panel1.TabIndex = 7
        '
        'PictureBox1
        '
        PictureBox1.Location = New System.Drawing.Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New System.Drawing.Size(250, 250)
        PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        '
        'frmImage
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        ClientSize = New System.Drawing.Size(701, 681)
        Controls.Add(Panel1)
        KeyPreview = True
        Name = "frmImage"
        StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Text = "frmImage"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
