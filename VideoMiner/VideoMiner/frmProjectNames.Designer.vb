<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectNames
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjectNames))
        Me.lstProjects = New System.Windows.Forms.ListBox()
        Me.txtProject = New System.Windows.Forms.TextBox()
        Me.lblSelect = New System.Windows.Forms.Label()
        Me.lblPreviousProjects = New System.Windows.Forms.Label()
        Me.lblProjectName = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstProjects
        '
        Me.lstProjects.FormattingEnabled = True
        Me.lstProjects.Location = New System.Drawing.Point(12, 48)
        Me.lstProjects.Name = "lstProjects"
        Me.lstProjects.Size = New System.Drawing.Size(268, 134)
        Me.lstProjects.Sorted = True
        Me.lstProjects.TabIndex = 0
        '
        'txtProject
        '
        Me.txtProject.Location = New System.Drawing.Point(12, 230)
        Me.txtProject.Name = "txtProject"
        Me.txtProject.Size = New System.Drawing.Size(268, 20)
        Me.txtProject.TabIndex = 1
        '
        'lblSelect
        '
        Me.lblSelect.AutoSize = True
        Me.lblSelect.Location = New System.Drawing.Point(12, 9)
        Me.lblSelect.Name = "lblSelect"
        Me.lblSelect.Size = New System.Drawing.Size(171, 13)
        Me.lblSelect.TabIndex = 2
        Me.lblSelect.Text = "Enter new project or select from list"
        '
        'lblPreviousProjects
        '
        Me.lblPreviousProjects.AutoSize = True
        Me.lblPreviousProjects.Location = New System.Drawing.Point(12, 32)
        Me.lblPreviousProjects.Name = "lblPreviousProjects"
        Me.lblPreviousProjects.Size = New System.Drawing.Size(92, 13)
        Me.lblPreviousProjects.TabIndex = 3
        Me.lblPreviousProjects.Text = "Previous Projects:"
        '
        'lblProjectName
        '
        Me.lblProjectName.AutoSize = True
        Me.lblProjectName.Location = New System.Drawing.Point(9, 214)
        Me.lblProjectName.Name = "lblProjectName"
        Me.lblProjectName.Size = New System.Drawing.Size(74, 13)
        Me.lblProjectName.TabIndex = 3
        Me.lblProjectName.Text = "Project Name:"
        '
        'cmdOK
        '
        Me.cmdOK.Enabled = False
        Me.cmdOK.Location = New System.Drawing.Point(56, 277)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(137, 277)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(196, 188)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(84, 22)
        Me.cmdDelete.TabIndex = 5
        Me.cmdDelete.Text = "Delete Project"
        Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'frmProjectNames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 310)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblProjectName)
        Me.Controls.Add(Me.lblPreviousProjects)
        Me.Controls.Add(Me.lblSelect)
        Me.Controls.Add(Me.txtProject)
        Me.Controls.Add(Me.lstProjects)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProjectNames"
        Me.Text = "Project Name"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstProjects As System.Windows.Forms.ListBox
    Friend WithEvents txtProject As System.Windows.Forms.TextBox
    Friend WithEvents lblSelect As System.Windows.Forms.Label
    Friend WithEvents lblPreviousProjects As System.Windows.Forms.Label
    Friend WithEvents lblProjectName As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
End Class
