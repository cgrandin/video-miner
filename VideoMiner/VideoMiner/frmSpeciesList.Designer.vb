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
        Me.lstSpecies = New System.Windows.Forms.ListView()
        Me.cmdMoveUp = New System.Windows.Forms.Button()
        Me.cmdMoveDown = New System.Windows.Forms.Button()
        Me.cmdInsertNew = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdMoveToTop = New System.Windows.Forms.Button()
        Me.cmdMoveToBottom = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstSpecies
        '
        Me.lstSpecies.AllowDrop = True
        Me.lstSpecies.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstSpecies.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSpecies.FullRowSelect = True
        Me.lstSpecies.HideSelection = False
        Me.lstSpecies.Location = New System.Drawing.Point(2, 3)
        Me.lstSpecies.MultiSelect = False
        Me.lstSpecies.Name = "lstSpecies"
        Me.lstSpecies.Size = New System.Drawing.Size(474, 483)
        Me.lstSpecies.TabIndex = 3
        Me.lstSpecies.UseCompatibleStateImageBehavior = False
        Me.lstSpecies.View = System.Windows.Forms.View.Details
        '
        'cmdMoveUp
        '
        Me.cmdMoveUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveUp.Location = New System.Drawing.Point(482, 37)
        Me.cmdMoveUp.Name = "cmdMoveUp"
        Me.cmdMoveUp.Size = New System.Drawing.Size(113, 27)
        Me.cmdMoveUp.TabIndex = 5
        Me.cmdMoveUp.Text = "Move Up"
        Me.cmdMoveUp.UseVisualStyleBackColor = True
        '
        'cmdMoveDown
        '
        Me.cmdMoveDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveDown.Location = New System.Drawing.Point(482, 72)
        Me.cmdMoveDown.Name = "cmdMoveDown"
        Me.cmdMoveDown.Size = New System.Drawing.Size(113, 27)
        Me.cmdMoveDown.TabIndex = 6
        Me.cmdMoveDown.Text = "Move Down"
        Me.cmdMoveDown.UseVisualStyleBackColor = True
        '
        'cmdInsertNew
        '
        Me.cmdInsertNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdInsertNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsertNew.Location = New System.Drawing.Point(2, 492)
        Me.cmdInsertNew.Name = "cmdInsertNew"
        Me.cmdInsertNew.Size = New System.Drawing.Size(112, 27)
        Me.cmdInsertNew.TabIndex = 7
        Me.cmdInsertNew.Text = "Insert New"
        Me.cmdInsertNew.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdit.Location = New System.Drawing.Point(139, 492)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(112, 27)
        Me.cmdEdit.TabIndex = 8
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(268, 492)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(112, 27)
        Me.cmdDelete.TabIndex = 9
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdMoveToTop
        '
        Me.cmdMoveToTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveToTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveToTop.Location = New System.Drawing.Point(482, 3)
        Me.cmdMoveToTop.Name = "cmdMoveToTop"
        Me.cmdMoveToTop.Size = New System.Drawing.Size(113, 27)
        Me.cmdMoveToTop.TabIndex = 5
        Me.cmdMoveToTop.Text = "Move To Top"
        Me.cmdMoveToTop.UseVisualStyleBackColor = True
        '
        'cmdMoveToBottom
        '
        Me.cmdMoveToBottom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveToBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveToBottom.Location = New System.Drawing.Point(482, 107)
        Me.cmdMoveToBottom.Name = "cmdMoveToBottom"
        Me.cmdMoveToBottom.Size = New System.Drawing.Size(113, 27)
        Me.cmdMoveToBottom.TabIndex = 6
        Me.cmdMoveToBottom.Text = "Move To Bottom"
        Me.cmdMoveToBottom.UseVisualStyleBackColor = True
        '
        'frmSpeciesList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 525)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdInsertNew)
        Me.Controls.Add(Me.cmdMoveToBottom)
        Me.Controls.Add(Me.cmdMoveDown)
        Me.Controls.Add(Me.cmdMoveToTop)
        Me.Controls.Add(Me.cmdMoveUp)
        Me.Controls.Add(Me.lstSpecies)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSpeciesList"
        Me.Text = "Species List"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstSpecies As System.Windows.Forms.ListView
    Friend WithEvents cmdMoveUp As System.Windows.Forms.Button
    Friend WithEvents cmdMoveDown As System.Windows.Forms.Button
    Friend WithEvents cmdInsertNew As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdMoveToTop As System.Windows.Forms.Button
    Friend WithEvents cmdMoveToBottom As System.Windows.Forms.Button
End Class
