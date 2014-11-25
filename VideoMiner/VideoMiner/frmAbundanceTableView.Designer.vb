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
        txtCommentBox = New System.Windows.Forms.TextBox
        cmdComment = New System.Windows.Forms.Button
        cmdCancel = New System.Windows.Forms.Button
        grdAbundance = New System.Windows.Forms.DataGridView
        CType(grdAbundance, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'txtCommentBox
        '
        txtCommentBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        txtCommentBox.BackColor = System.Drawing.SystemColors.Window
        txtCommentBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        txtCommentBox.Enabled = False
        txtCommentBox.ForeColor = System.Drawing.Color.SeaGreen
        txtCommentBox.Location = New System.Drawing.Point(0, 248)
        txtCommentBox.Multiline = True
        txtCommentBox.Name = "txtCommentBox"
        txtCommentBox.Size = New System.Drawing.Size(321, 22)
        txtCommentBox.TabIndex = 11
        txtCommentBox.Text = "Comment"
        txtCommentBox.WordWrap = False
        '
        'cmdComment
        '
        cmdComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        cmdComment.Location = New System.Drawing.Point(1, 276)
        cmdComment.Name = "cmdComment"
        cmdComment.Size = New System.Drawing.Size(81, 23)
        cmdComment.TabIndex = 10
        cmdComment.Text = "Edit Comment"
        cmdComment.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        cmdCancel.Location = New System.Drawing.Point(246, 276)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New System.Drawing.Size(75, 23)
        cmdCancel.TabIndex = 8
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        cmdCancel.Visible = False
        '
        'grdAbundance
        '
        grdAbundance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        grdAbundance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        grdAbundance.Location = New System.Drawing.Point(0, 0)
        grdAbundance.Margin = New System.Windows.Forms.Padding(2)
        grdAbundance.Name = "grdAbundance"
        grdAbundance.RowTemplate.Height = 24
        grdAbundance.Size = New System.Drawing.Size(321, 243)
        grdAbundance.TabIndex = 7
        '
        'frmAbundanceTableView
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(321, 299)
        ControlBox = False
        Controls.Add(txtCommentBox)
        Controls.Add(cmdComment)
        Controls.Add(cmdCancel)
        Controls.Add(grdAbundance)
        Name = "frmAbundanceTableView"
        Text = "Choose a Row..."
        CType(grdAbundance, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents txtCommentBox As System.Windows.Forms.TextBox
    Friend WithEvents cmdComment As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents grdAbundance As System.Windows.Forms.DataGridView
End Class
