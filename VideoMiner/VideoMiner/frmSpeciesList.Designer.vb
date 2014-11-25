<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpeciesList
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
        lstSpecies = New System.Windows.Forms.ListView
        cmdOk = New System.Windows.Forms.Button
        cmdMoveUp = New System.Windows.Forms.Button
        cmdMoveDown = New System.Windows.Forms.Button
        cmdInsertNew = New System.Windows.Forms.Button
        cmdEdit = New System.Windows.Forms.Button
        cmdDelete = New System.Windows.Forms.Button
        cmdMoveToTop = New System.Windows.Forms.Button
        cmdMoveToBottom = New System.Windows.Forms.Button
        SuspendLayout()
        '
        'lstSpecies
        '
        lstSpecies.AllowDrop = True
        lstSpecies.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        lstSpecies.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lstSpecies.FullRowSelect = True
        lstSpecies.HideSelection = False
        lstSpecies.Location = New System.Drawing.Point(2, 3)
        lstSpecies.MultiSelect = False
        lstSpecies.Name = "lstSpecies"
        lstSpecies.Size = New System.Drawing.Size(378, 284)
        lstSpecies.TabIndex = 3
        lstSpecies.UseCompatibleStateImageBehavior = False
        lstSpecies.View = System.Windows.Forms.View.Details
        '
        'cmdOk
        '
        cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdOk.Location = New System.Drawing.Point(105, 335)
        cmdOk.Name = "cmdOk"
        cmdOk.Size = New System.Drawing.Size(92, 23)
        cmdOk.TabIndex = 4
        cmdOk.Text = "OK"
        cmdOk.UseVisualStyleBackColor = True
        '
        'cmdMoveUp
        '
        cmdMoveUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        cmdMoveUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdMoveUp.Location = New System.Drawing.Point(386, 104)
        cmdMoveUp.Name = "cmdMoveUp"
        cmdMoveUp.Size = New System.Drawing.Size(113, 23)
        cmdMoveUp.TabIndex = 5
        cmdMoveUp.Text = "Move Up"
        cmdMoveUp.UseVisualStyleBackColor = True
        '
        'cmdMoveDown
        '
        cmdMoveDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        cmdMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdMoveDown.Location = New System.Drawing.Point(386, 133)
        cmdMoveDown.Name = "cmdMoveDown"
        cmdMoveDown.Size = New System.Drawing.Size(113, 23)
        cmdMoveDown.TabIndex = 6
        cmdMoveDown.Text = "Move Down"
        cmdMoveDown.UseVisualStyleBackColor = True
        '
        'cmdInsertNew
        '
        cmdInsertNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        cmdInsertNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdInsertNew.Location = New System.Drawing.Point(2, 293)
        cmdInsertNew.Name = "cmdInsertNew"
        cmdInsertNew.Size = New System.Drawing.Size(92, 23)
        cmdInsertNew.TabIndex = 7
        cmdInsertNew.Text = "Insert New"
        cmdInsertNew.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        cmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdEdit.Location = New System.Drawing.Point(105, 293)
        cmdEdit.Name = "cmdEdit"
        cmdEdit.Size = New System.Drawing.Size(92, 23)
        cmdEdit.TabIndex = 8
        cmdEdit.Text = "Edit"
        cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdDelete.Location = New System.Drawing.Point(207, 293)
        cmdDelete.Name = "cmdDelete"
        cmdDelete.Size = New System.Drawing.Size(92, 23)
        cmdDelete.TabIndex = 9
        cmdDelete.Text = "Delete"
        cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdMoveToTop
        '
        cmdMoveToTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        cmdMoveToTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdMoveToTop.Location = New System.Drawing.Point(386, 65)
        cmdMoveToTop.Name = "cmdMoveToTop"
        cmdMoveToTop.Size = New System.Drawing.Size(113, 23)
        cmdMoveToTop.TabIndex = 5
        cmdMoveToTop.Text = "Move To Top"
        cmdMoveToTop.UseVisualStyleBackColor = True
        '
        'cmdMoveToBottom
        '
        cmdMoveToBottom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        cmdMoveToBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdMoveToBottom.Location = New System.Drawing.Point(386, 172)
        cmdMoveToBottom.Name = "cmdMoveToBottom"
        cmdMoveToBottom.Size = New System.Drawing.Size(113, 23)
        cmdMoveToBottom.TabIndex = 6
        cmdMoveToBottom.Text = "Move To Bottom"
        cmdMoveToBottom.UseVisualStyleBackColor = True
        '
        'frmSpeciesList
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(511, 370)
        Controls.Add(cmdDelete)
        Controls.Add(cmdEdit)
        Controls.Add(cmdInsertNew)
        Controls.Add(cmdMoveToBottom)
        Controls.Add(cmdMoveDown)
        Controls.Add(cmdMoveToTop)
        Controls.Add(cmdMoveUp)
        Controls.Add(cmdOk)
        Controls.Add(lstSpecies)
        KeyPreview = True
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmSpeciesList"
        Text = "Species List"
        ResumeLayout(False)

    End Sub
    Friend WithEvents lstSpecies As System.Windows.Forms.ListView
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdMoveUp As System.Windows.Forms.Button
    Friend WithEvents cmdMoveDown As System.Windows.Forms.Button
    Friend WithEvents cmdInsertNew As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdMoveToTop As System.Windows.Forms.Button
    Friend WithEvents cmdMoveToBottom As System.Windows.Forms.Button
End Class
