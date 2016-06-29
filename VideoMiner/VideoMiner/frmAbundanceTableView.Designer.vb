<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbundanceTableView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbundanceTableView))
        Me.txtCommentBox = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.grdAbundance = New System.Windows.Forms.DataGridView()
        Me.lblComment = New System.Windows.Forms.Label()
        CType(Me.grdAbundance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCommentBox
        '
        Me.txtCommentBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommentBox.BackColor = System.Drawing.SystemColors.Window
        Me.txtCommentBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCommentBox.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtCommentBox.Location = New System.Drawing.Point(0, 288)
        Me.txtCommentBox.Multiline = True
        Me.txtCommentBox.Name = "txtCommentBox"
        Me.txtCommentBox.Size = New System.Drawing.Size(321, 22)
        Me.txtCommentBox.TabIndex = 11
        Me.txtCommentBox.WordWrap = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(246, 316)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'grdAbundance
        '
        Me.grdAbundance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdAbundance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAbundance.Location = New System.Drawing.Point(0, 0)
        Me.grdAbundance.Margin = New System.Windows.Forms.Padding(2)
        Me.grdAbundance.Name = "grdAbundance"
        Me.grdAbundance.RowTemplate.Height = 24
        Me.grdAbundance.Size = New System.Drawing.Size(321, 260)
        Me.grdAbundance.TabIndex = 7
        '
        'lblComment
        '
        Me.lblComment.AutoSize = True
        Me.lblComment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComment.Location = New System.Drawing.Point(-3, 269)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(65, 13)
        Me.lblComment.TabIndex = 61
        Me.lblComment.Text = "Comment:"
        '
        'frmAbundanceTableView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 339)
        Me.Controls.Add(Me.lblComment)
        Me.Controls.Add(Me.txtCommentBox)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.grdAbundance)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbundanceTableView"
        Me.Text = "Choose a Row..."
        CType(Me.grdAbundance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCommentBox As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents grdAbundance As System.Windows.Forms.DataGridView
    Friend WithEvents lblComment As System.Windows.Forms.Label
End Class
