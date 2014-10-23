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
        Me.txtCommentBox = New System.Windows.Forms.TextBox
        Me.cmdComment = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.grdAbundance = New System.Windows.Forms.DataGridView
        CType(Me.grdAbundance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCommentBox
        '
        Me.txtCommentBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommentBox.BackColor = System.Drawing.SystemColors.Window
        Me.txtCommentBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCommentBox.Enabled = False
        Me.txtCommentBox.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtCommentBox.Location = New System.Drawing.Point(0, 248)
        Me.txtCommentBox.Multiline = True
        Me.txtCommentBox.Name = "txtCommentBox"
        Me.txtCommentBox.Size = New System.Drawing.Size(321, 22)
        Me.txtCommentBox.TabIndex = 11
        Me.txtCommentBox.Text = "Comment"
        Me.txtCommentBox.WordWrap = False
        '
        'cmdComment
        '
        Me.cmdComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdComment.Location = New System.Drawing.Point(1, 276)
        Me.cmdComment.Name = "cmdComment"
        Me.cmdComment.Size = New System.Drawing.Size(81, 23)
        Me.cmdComment.TabIndex = 10
        Me.cmdComment.Text = "Edit Comment"
        Me.cmdComment.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(246, 276)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        Me.cmdCancel.Visible = False
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
        Me.grdAbundance.Size = New System.Drawing.Size(321, 243)
        Me.grdAbundance.TabIndex = 7
        '
        'frmAbundanceTableView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 299)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtCommentBox)
        Me.Controls.Add(Me.cmdComment)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.grdAbundance)
        Me.Name = "frmAbundanceTableView"
        Me.Text = "Choose a Row..."
        CType(Me.grdAbundance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCommentBox As System.Windows.Forms.TextBox
    Friend WithEvents cmdComment As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents grdAbundance As System.Windows.Forms.DataGridView
End Class
