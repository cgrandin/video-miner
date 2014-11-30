<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStringDataViewer
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
        Me.txtStringData = New System.Windows.Forms.TextBox()
        Me.cmdPause = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtStringData
        '
        Me.txtStringData.AcceptsReturn = True
        Me.txtStringData.AcceptsTab = True
        Me.txtStringData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStringData.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStringData.HideSelection = False
        Me.txtStringData.Location = New System.Drawing.Point(0, 0)
        Me.txtStringData.Multiline = True
        Me.txtStringData.Name = "txtStringData"
        Me.txtStringData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStringData.Size = New System.Drawing.Size(681, 925)
        Me.txtStringData.TabIndex = 0
        Me.txtStringData.WordWrap = False
        '
        'cmdPause
        '
        Me.cmdPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdPause.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPause.Location = New System.Drawing.Point(229, 874)
        Me.cmdPause.Name = "cmdPause"
        Me.cmdPause.Size = New System.Drawing.Size(196, 37)
        Me.cmdPause.TabIndex = 1
        Me.cmdPause.Text = "Pause"
        Me.cmdPause.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.cmdPause)
        Me.Panel1.Controls.Add(Me.txtStringData)
        Me.Panel1.Location = New System.Drawing.Point(-3, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(681, 925)
        Me.Panel1.TabIndex = 2
        '
        'frmStringDataViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 925)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmStringDataViewer"
        Me.Text = "frmStringDataViewer"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtStringData As System.Windows.Forms.TextBox
    Friend WithEvents cmdPause As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
