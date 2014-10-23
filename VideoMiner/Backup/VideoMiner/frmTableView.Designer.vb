<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTableView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTableView))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.btnSkipSpatial = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.cmdComment = New System.Windows.Forms.Button
        Me.txtCommentBox = New System.Windows.Forms.TextBox
        Me.cmdScreenCapture = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(321, 243)
        Me.DataGridView1.TabIndex = 3
        '
        'btnSkipSpatial
        '
        Me.btnSkipSpatial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSkipSpatial.Location = New System.Drawing.Point(246, 276)
        Me.btnSkipSpatial.Name = "btnSkipSpatial"
        Me.btnSkipSpatial.Size = New System.Drawing.Size(75, 23)
        Me.btnSkipSpatial.TabIndex = 4
        Me.btnSkipSpatial.Text = "Skip"
        Me.btnSkipSpatial.UseVisualStyleBackColor = True
        Me.btnSkipSpatial.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(165, 276)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        Me.btnClear.Visible = False
        '
        'cmdComment
        '
        Me.cmdComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdComment.Location = New System.Drawing.Point(1, 276)
        Me.cmdComment.Name = "cmdComment"
        Me.cmdComment.Size = New System.Drawing.Size(81, 23)
        Me.cmdComment.TabIndex = 5
        Me.cmdComment.Text = "Edit Comment"
        Me.cmdComment.UseVisualStyleBackColor = True
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
        Me.txtCommentBox.Size = New System.Drawing.Size(282, 22)
        Me.txtCommentBox.TabIndex = 6
        Me.txtCommentBox.Text = "Comment"
        Me.txtCommentBox.WordWrap = False
        '
        'cmdScreenCapture
        '
        Me.cmdScreenCapture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdScreenCapture.BackColor = System.Drawing.SystemColors.Control
        Me.cmdScreenCapture.BackgroundImage = CType(resources.GetObject("cmdScreenCapture.BackgroundImage"), System.Drawing.Image)
        Me.cmdScreenCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdScreenCapture.Location = New System.Drawing.Point(288, 246)
        Me.cmdScreenCapture.Name = "cmdScreenCapture"
        Me.cmdScreenCapture.Size = New System.Drawing.Size(33, 26)
        Me.cmdScreenCapture.TabIndex = 59
        Me.cmdScreenCapture.UseVisualStyleBackColor = False
        '
        'frmTableView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(321, 299)
        Me.Controls.Add(Me.cmdScreenCapture)
        Me.Controls.Add(Me.txtCommentBox)
        Me.Controls.Add(Me.cmdComment)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSkipSpatial)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTableView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choose a row..."
        Me.TopMost = True
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSkipSpatial As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents cmdComment As System.Windows.Forms.Button
    Friend WithEvents txtCommentBox As System.Windows.Forms.TextBox
    Friend WithEvents cmdScreenCapture As System.Windows.Forms.Button
End Class
