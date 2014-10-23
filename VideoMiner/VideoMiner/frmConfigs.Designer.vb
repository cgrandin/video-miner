<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigs
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
        Me.components = New System.ComponentModel.Container
        Me.lblTemplate = New System.Windows.Forms.Label
        Me.cboTemplates = New System.Windows.Forms.ComboBox
        Me.listFields = New System.Windows.Forms.ListView
        Me.cmdInsert = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.cmdRemove = New System.Windows.Forms.Button
        Me.txtKeyColumn = New System.Windows.Forms.TextBox
        Me.tabControl = New System.Windows.Forms.TabControl
        Me.tabLegendFields = New System.Windows.Forms.TabPage
        Me.grpLegend = New System.Windows.Forms.GroupBox
        Me.tabOthers = New System.Windows.Forms.TabPage
        Me.grpStartUp = New System.Windows.Forms.GroupBox
        Me.chkAutoStart = New System.Windows.Forms.CheckBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.dlgFolderBrowser = New System.Windows.Forms.FolderBrowserDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdGetStorageFolder = New System.Windows.Forms.Button
        Me.chkDefaultTemplates = New System.Windows.Forms.CheckBox
        Me.lblStorageFolder = New System.Windows.Forms.Label
        Me.txtTemplateStorage = New System.Windows.Forms.TextBox
        Me.tabControl.SuspendLayout()
        Me.tabLegendFields.SuspendLayout()
        Me.grpLegend.SuspendLayout()
        Me.tabOthers.SuspendLayout()
        Me.grpStartUp.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTemplate
        '
        Me.lblTemplate.AutoSize = True
        Me.lblTemplate.Location = New System.Drawing.Point(8, 12)
        Me.lblTemplate.Name = "lblTemplate"
        Me.lblTemplate.Size = New System.Drawing.Size(61, 13)
        Me.lblTemplate.TabIndex = 0
        Me.lblTemplate.Text = "Template"
        '
        'cboTemplates
        '
        Me.cboTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTemplates.FormattingEnabled = True
        Me.cboTemplates.Location = New System.Drawing.Point(75, 9)
        Me.cboTemplates.Name = "cboTemplates"
        Me.cboTemplates.Size = New System.Drawing.Size(241, 21)
        Me.cboTemplates.TabIndex = 1
        '
        'listFields
        '
        Me.listFields.FullRowSelect = True
        Me.listFields.HideSelection = False
        Me.listFields.Location = New System.Drawing.Point(9, 20)
        Me.listFields.MultiSelect = False
        Me.listFields.Name = "listFields"
        Me.listFields.Size = New System.Drawing.Size(356, 253)
        Me.listFields.TabIndex = 2
        Me.listFields.UseCompatibleStateImageBehavior = False
        Me.listFields.View = System.Windows.Forms.View.Details
        '
        'cmdInsert
        '
        Me.cmdInsert.Enabled = False
        Me.cmdInsert.Location = New System.Drawing.Point(9, 279)
        Me.cmdInsert.Name = "cmdInsert"
        Me.cmdInsert.Size = New System.Drawing.Size(75, 23)
        Me.cmdInsert.TabIndex = 3
        Me.cmdInsert.Text = "Insert"
        Me.cmdInsert.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.Location = New System.Drawing.Point(90, 279)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.cmdEdit.TabIndex = 3
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdRemove
        '
        Me.cmdRemove.Enabled = False
        Me.cmdRemove.Location = New System.Drawing.Point(290, 279)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(75, 23)
        Me.cmdRemove.TabIndex = 3
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'txtKeyColumn
        '
        Me.txtKeyColumn.Location = New System.Drawing.Point(322, 9)
        Me.txtKeyColumn.Name = "txtKeyColumn"
        Me.txtKeyColumn.ReadOnly = True
        Me.txtKeyColumn.Size = New System.Drawing.Size(52, 21)
        Me.txtKeyColumn.TabIndex = 4
        Me.txtKeyColumn.Visible = False
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tabLegendFields)
        Me.tabControl.Controls.Add(Me.tabOthers)
        Me.tabControl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControl.Location = New System.Drawing.Point(3, 12)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(395, 375)
        Me.tabControl.TabIndex = 6
        '
        'tabLegendFields
        '
        Me.tabLegendFields.Controls.Add(Me.txtKeyColumn)
        Me.tabLegendFields.Controls.Add(Me.grpLegend)
        Me.tabLegendFields.Controls.Add(Me.cboTemplates)
        Me.tabLegendFields.Controls.Add(Me.lblTemplate)
        Me.tabLegendFields.Location = New System.Drawing.Point(4, 22)
        Me.tabLegendFields.Name = "tabLegendFields"
        Me.tabLegendFields.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLegendFields.Size = New System.Drawing.Size(387, 349)
        Me.tabLegendFields.TabIndex = 0
        Me.tabLegendFields.Text = "Legend Fields"
        Me.tabLegendFields.UseVisualStyleBackColor = True
        '
        'grpLegend
        '
        Me.grpLegend.Controls.Add(Me.listFields)
        Me.grpLegend.Controls.Add(Me.cmdRemove)
        Me.grpLegend.Controls.Add(Me.cmdInsert)
        Me.grpLegend.Controls.Add(Me.cmdEdit)
        Me.grpLegend.Location = New System.Drawing.Point(9, 33)
        Me.grpLegend.Name = "grpLegend"
        Me.grpLegend.Size = New System.Drawing.Size(371, 310)
        Me.grpLegend.TabIndex = 6
        Me.grpLegend.TabStop = False
        '
        'tabOthers
        '
        Me.tabOthers.Controls.Add(Me.grpStartUp)
        Me.tabOthers.Location = New System.Drawing.Point(4, 22)
        Me.tabOthers.Name = "tabOthers"
        Me.tabOthers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOthers.Size = New System.Drawing.Size(387, 349)
        Me.tabOthers.TabIndex = 3
        Me.tabOthers.Text = "Misc"
        Me.tabOthers.UseVisualStyleBackColor = True
        '
        'grpStartUp
        '
        Me.grpStartUp.Controls.Add(Me.chkAutoStart)
        Me.grpStartUp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpStartUp.Location = New System.Drawing.Point(5, 6)
        Me.grpStartUp.Name = "grpStartUp"
        Me.grpStartUp.Size = New System.Drawing.Size(374, 46)
        Me.grpStartUp.TabIndex = 8
        Me.grpStartUp.TabStop = False
        Me.grpStartUp.Text = "Start Up"
        '
        'chkAutoStart
        '
        Me.chkAutoStart.AutoSize = True
        Me.chkAutoStart.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkAutoStart.Location = New System.Drawing.Point(9, 19)
        Me.chkAutoStart.Name = "chkAutoStart"
        Me.chkAutoStart.Size = New System.Drawing.Size(222, 17)
        Me.chkAutoStart.TabIndex = 0
        Me.chkAutoStart.Text = "Run ArcMap-MapIT! automatically."
        Me.chkAutoStart.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(244, 393)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(116, 23)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Exit Without Saving"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(38, 393)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(116, 23)
        Me.cmdOK.TabIndex = 8
        Me.cmdOK.Text = "Save and Exit"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 300
        Me.ToolTip1.ReshowDelay = 60
        '
        'cmdGetStorageFolder
        '
        Me.cmdGetStorageFolder.Image = Global.MapIt.My.Resources.Resources.open
        Me.cmdGetStorageFolder.Location = New System.Drawing.Point(345, 42)
        Me.cmdGetStorageFolder.Name = "cmdGetStorageFolder"
        Me.cmdGetStorageFolder.Size = New System.Drawing.Size(23, 23)
        Me.cmdGetStorageFolder.TabIndex = 7
        Me.cmdGetStorageFolder.UseVisualStyleBackColor = True
        '
        'chkDefaultTemplates
        '
        Me.chkDefaultTemplates.AutoSize = True
        Me.chkDefaultTemplates.Location = New System.Drawing.Point(125, 22)
        Me.chkDefaultTemplates.Name = "chkDefaultTemplates"
        Me.chkDefaultTemplates.Size = New System.Drawing.Size(82, 17)
        Me.chkDefaultTemplates.TabIndex = 2
        Me.chkDefaultTemplates.Text = "Use Default"
        Me.chkDefaultTemplates.UseVisualStyleBackColor = True
        '
        'lblStorageFolder
        '
        Me.lblStorageFolder.AutoSize = True
        Me.lblStorageFolder.Location = New System.Drawing.Point(6, 23)
        Me.lblStorageFolder.Name = "lblStorageFolder"
        Me.lblStorageFolder.Size = New System.Drawing.Size(76, 13)
        Me.lblStorageFolder.TabIndex = 1
        Me.lblStorageFolder.Text = "Storage Folder"
        '
        'txtTemplateStorage
        '
        Me.txtTemplateStorage.Location = New System.Drawing.Point(9, 44)
        Me.txtTemplateStorage.Name = "txtTemplateStorage"
        Me.txtTemplateStorage.Size = New System.Drawing.Size(330, 20)
        Me.txtTemplateStorage.TabIndex = 0
        '
        'frmConfigs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 423)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.tabControl)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmConfigs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MapIT! Configuration Editor"
        Me.TopMost = True
        Me.tabControl.ResumeLayout(False)
        Me.tabLegendFields.ResumeLayout(False)
        Me.tabLegendFields.PerformLayout()
        Me.grpLegend.ResumeLayout(False)
        Me.tabOthers.ResumeLayout(False)
        Me.grpStartUp.ResumeLayout(False)
        Me.grpStartUp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTemplate As System.Windows.Forms.Label
    Friend WithEvents cboTemplates As System.Windows.Forms.ComboBox
    Friend WithEvents listFields As System.Windows.Forms.ListView
    Friend WithEvents cmdInsert As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents txtKeyColumn As System.Windows.Forms.TextBox
    Friend WithEvents tabControl As System.Windows.Forms.TabControl
    Friend WithEvents tabLegendFields As System.Windows.Forms.TabPage
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents dlgFolderBrowser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents grpLegend As System.Windows.Forms.GroupBox
    Friend WithEvents tabOthers As System.Windows.Forms.TabPage
    Friend WithEvents grpStartUp As System.Windows.Forms.GroupBox
    Friend WithEvents chkAutoStart As System.Windows.Forms.CheckBox
    Friend WithEvents cmdGetStorageFolder As System.Windows.Forms.Button
    Friend WithEvents chkDefaultTemplates As System.Windows.Forms.CheckBox
    Friend WithEvents lblStorageFolder As System.Windows.Forms.Label
    Friend WithEvents txtTemplateStorage As System.Windows.Forms.TextBox
End Class
