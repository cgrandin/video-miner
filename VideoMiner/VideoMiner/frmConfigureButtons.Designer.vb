<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigureButtons
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
        cmdDeleteButton = New System.Windows.Forms.Button
        cmdEditButton = New System.Windows.Forms.Button
        cmdCreateNewButton = New System.Windows.Forms.Button
        cmdMoveDown = New System.Windows.Forms.Button
        cmdMoveUp = New System.Windows.Forms.Button
        cmdDone = New System.Windows.Forms.Button
        lstButtons = New System.Windows.Forms.ListView
        cmdMoveToPanel = New System.Windows.Forms.Button
        SuspendLayout()
        '
        'cmdDeleteButton
        '
        cmdDeleteButton.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdDeleteButton.Location = New System.Drawing.Point(260, 237)
        cmdDeleteButton.Name = "cmdDeleteButton"
        cmdDeleteButton.Size = New System.Drawing.Size(118, 30)
        cmdDeleteButton.TabIndex = 16
        cmdDeleteButton.Text = "Delete Button"
        cmdDeleteButton.UseVisualStyleBackColor = True
        '
        'cmdEditButton
        '
        cmdEditButton.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdEditButton.Location = New System.Drawing.Point(136, 237)
        cmdEditButton.Name = "cmdEditButton"
        cmdEditButton.Size = New System.Drawing.Size(118, 30)
        cmdEditButton.TabIndex = 15
        cmdEditButton.Text = "Edit Button"
        cmdEditButton.UseVisualStyleBackColor = True
        '
        'cmdCreateNewButton
        '
        cmdCreateNewButton.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdCreateNewButton.Location = New System.Drawing.Point(12, 237)
        cmdCreateNewButton.Name = "cmdCreateNewButton"
        cmdCreateNewButton.Size = New System.Drawing.Size(118, 30)
        cmdCreateNewButton.TabIndex = 14
        cmdCreateNewButton.Text = "Create New Button"
        cmdCreateNewButton.UseVisualStyleBackColor = True
        '
        'cmdMoveDown
        '
        cmdMoveDown.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdMoveDown.Location = New System.Drawing.Point(288, 143)
        cmdMoveDown.Name = "cmdMoveDown"
        cmdMoveDown.Size = New System.Drawing.Size(90, 23)
        cmdMoveDown.TabIndex = 13
        cmdMoveDown.Text = "Move Down"
        cmdMoveDown.UseVisualStyleBackColor = True
        '
        'cmdMoveUp
        '
        cmdMoveUp.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdMoveUp.Location = New System.Drawing.Point(288, 102)
        cmdMoveUp.Name = "cmdMoveUp"
        cmdMoveUp.Size = New System.Drawing.Size(90, 23)
        cmdMoveUp.TabIndex = 12
        cmdMoveUp.Text = "Move Up"
        cmdMoveUp.UseVisualStyleBackColor = True
        '
        'cmdDone
        '
        cmdDone.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdDone.Location = New System.Drawing.Point(136, 293)
        cmdDone.Name = "cmdDone"
        cmdDone.Size = New System.Drawing.Size(118, 47)
        cmdDone.TabIndex = 11
        cmdDone.Text = "Done"
        cmdDone.UseVisualStyleBackColor = True
        '
        'lstButtons
        '
        lstButtons.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lstButtons.FullRowSelect = True
        lstButtons.HideSelection = False
        lstButtons.Location = New System.Drawing.Point(12, 48)
        lstButtons.MultiSelect = False
        lstButtons.Name = "lstButtons"
        lstButtons.Size = New System.Drawing.Size(270, 183)
        lstButtons.TabIndex = 10
        lstButtons.UseCompatibleStateImageBehavior = False
        lstButtons.View = System.Windows.Forms.View.Details
        '
        'cmdMoveToPanel
        '
        cmdMoveToPanel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdMoveToPanel.Location = New System.Drawing.Point(12, 12)
        cmdMoveToPanel.Name = "cmdMoveToPanel"
        cmdMoveToPanel.Size = New System.Drawing.Size(270, 30)
        cmdMoveToPanel.TabIndex = 14
        cmdMoveToPanel.UseVisualStyleBackColor = True
        '
        'frmConfigureButtons
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(395, 397)
        Controls.Add(cmdDeleteButton)
        Controls.Add(cmdEditButton)
        Controls.Add(cmdMoveToPanel)
        Controls.Add(cmdCreateNewButton)
        Controls.Add(cmdMoveDown)
        Controls.Add(cmdMoveUp)
        Controls.Add(cmdDone)
        Controls.Add(lstButtons)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmConfigureButtons"
        Text = "Configure Buttons"
        ResumeLayout(False)

    End Sub
    Friend WithEvents cmdDeleteButton As System.Windows.Forms.Button
    Friend WithEvents cmdEditButton As System.Windows.Forms.Button
    Friend WithEvents cmdCreateNewButton As System.Windows.Forms.Button
    Friend WithEvents cmdMoveDown As System.Windows.Forms.Button
    Friend WithEvents cmdMoveUp As System.Windows.Forms.Button
    Friend WithEvents cmdDone As System.Windows.Forms.Button
    Friend WithEvents lstButtons As System.Windows.Forms.ListView
    Friend WithEvents cmdMoveToPanel As System.Windows.Forms.Button
End Class
