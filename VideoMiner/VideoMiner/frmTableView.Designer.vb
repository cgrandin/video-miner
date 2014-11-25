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
        DataGridView1 = New System.Windows.Forms.DataGridView
        btnSkipSpatial = New System.Windows.Forms.Button
        btnClear = New System.Windows.Forms.Button
        cmdComment = New System.Windows.Forms.Button
        txtCommentBox = New System.Windows.Forms.TextBox
        cmdScreenCapture = New System.Windows.Forms.Button
        CType(DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'DataGridView1
        '
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New System.Drawing.Point(0, 0)
        DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 24
        DataGridView1.Size = New System.Drawing.Size(321, 243)
        DataGridView1.TabIndex = 3
        '
        'btnSkipSpatial
        '
        btnSkipSpatial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        btnSkipSpatial.Location = New System.Drawing.Point(246, 276)
        btnSkipSpatial.Name = "btnSkipSpatial"
        btnSkipSpatial.Size = New System.Drawing.Size(75, 23)
        btnSkipSpatial.TabIndex = 4
        btnSkipSpatial.Text = "Skip"
        btnSkipSpatial.UseVisualStyleBackColor = True
        btnSkipSpatial.Visible = False
        '
        'btnClear
        '
        btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        btnClear.Location = New System.Drawing.Point(165, 276)
        btnClear.Name = "btnClear"
        btnClear.Size = New System.Drawing.Size(75, 23)
        btnClear.TabIndex = 5
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        btnClear.Visible = False
        '
        'cmdComment
        '
        cmdComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        cmdComment.Location = New System.Drawing.Point(1, 276)
        cmdComment.Name = "cmdComment"
        cmdComment.Size = New System.Drawing.Size(81, 23)
        cmdComment.TabIndex = 5
        cmdComment.Text = "Edit Comment"
        cmdComment.UseVisualStyleBackColor = True
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
        txtCommentBox.Size = New System.Drawing.Size(282, 22)
        txtCommentBox.TabIndex = 6
        txtCommentBox.Text = "Comment"
        txtCommentBox.WordWrap = False
        '
        'cmdScreenCapture
        '
        cmdScreenCapture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        cmdScreenCapture.BackColor = System.Drawing.SystemColors.Control
        cmdScreenCapture.BackgroundImage = CType(resources.GetObject("cmdScreenCapture.BackgroundImage"), System.Drawing.Image)
        cmdScreenCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        cmdScreenCapture.Location = New System.Drawing.Point(288, 246)
        cmdScreenCapture.Name = "cmdScreenCapture"
        cmdScreenCapture.Size = New System.Drawing.Size(33, 26)
        cmdScreenCapture.TabIndex = 59
        cmdScreenCapture.UseVisualStyleBackColor = False
        '
        'frmTableView
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        AutoSize = True
        ClientSize = New System.Drawing.Size(321, 299)
        Controls.Add(cmdScreenCapture)
        Controls.Add(txtCommentBox)
        Controls.Add(cmdComment)
        Controls.Add(btnClear)
        Controls.Add(btnSkipSpatial)
        Controls.Add(DataGridView1)
        Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Margin = New System.Windows.Forms.Padding(2)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmTableView"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Text = "Choose a row..."
        TopMost = True
        CType(DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSkipSpatial As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents cmdComment As System.Windows.Forms.Button
    Friend WithEvents txtCommentBox As System.Windows.Forms.TextBox
    Friend WithEvents cmdScreenCapture As System.Windows.Forms.Button
End Class
