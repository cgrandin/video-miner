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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigureButtons))
        Me.cmdDeleteButton = New System.Windows.Forms.Button()
        Me.cmdEditButton = New System.Windows.Forms.Button()
        Me.cmdCreateNewButton = New System.Windows.Forms.Button()
        Me.cmdMoveDown = New System.Windows.Forms.Button()
        Me.cmdMoveUp = New System.Windows.Forms.Button()
        Me.cmdDone = New System.Windows.Forms.Button()
        Me.lstButtons = New System.Windows.Forms.ListView()
        Me.cmdMoveToPanel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdDeleteButton
        '
        Me.cmdDeleteButton.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteButton.Location = New System.Drawing.Point(260, 237)
        Me.cmdDeleteButton.Name = "cmdDeleteButton"
        Me.cmdDeleteButton.Size = New System.Drawing.Size(118, 30)
        Me.cmdDeleteButton.TabIndex = 16
        Me.cmdDeleteButton.Text = "Delete Button"
        Me.cmdDeleteButton.UseVisualStyleBackColor = True
        '
        'cmdEditButton
        '
        Me.cmdEditButton.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditButton.Location = New System.Drawing.Point(136, 237)
        Me.cmdEditButton.Name = "cmdEditButton"
        Me.cmdEditButton.Size = New System.Drawing.Size(118, 30)
        Me.cmdEditButton.TabIndex = 15
        Me.cmdEditButton.Text = "Edit Button"
        Me.cmdEditButton.UseVisualStyleBackColor = True
        '
        'cmdCreateNewButton
        '
        Me.cmdCreateNewButton.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreateNewButton.Location = New System.Drawing.Point(12, 237)
        Me.cmdCreateNewButton.Name = "cmdCreateNewButton"
        Me.cmdCreateNewButton.Size = New System.Drawing.Size(118, 30)
        Me.cmdCreateNewButton.TabIndex = 14
        Me.cmdCreateNewButton.Text = "Create New Button"
        Me.cmdCreateNewButton.UseVisualStyleBackColor = True
        '
        'cmdMoveDown
        '
        Me.cmdMoveDown.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveDown.Location = New System.Drawing.Point(288, 143)
        Me.cmdMoveDown.Name = "cmdMoveDown"
        Me.cmdMoveDown.Size = New System.Drawing.Size(90, 23)
        Me.cmdMoveDown.TabIndex = 13
        Me.cmdMoveDown.Text = "Move Down"
        Me.cmdMoveDown.UseVisualStyleBackColor = True
        '
        'cmdMoveUp
        '
        Me.cmdMoveUp.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveUp.Location = New System.Drawing.Point(288, 102)
        Me.cmdMoveUp.Name = "cmdMoveUp"
        Me.cmdMoveUp.Size = New System.Drawing.Size(90, 23)
        Me.cmdMoveUp.TabIndex = 12
        Me.cmdMoveUp.Text = "Move Up"
        Me.cmdMoveUp.UseVisualStyleBackColor = True
        '
        'cmdDone
        '
        Me.cmdDone.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDone.Location = New System.Drawing.Point(136, 293)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(118, 47)
        Me.cmdDone.TabIndex = 11
        Me.cmdDone.Text = "Done"
        Me.cmdDone.UseVisualStyleBackColor = True
        '
        'lstButtons
        '
        Me.lstButtons.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstButtons.FullRowSelect = True
        Me.lstButtons.HideSelection = False
        Me.lstButtons.Location = New System.Drawing.Point(12, 48)
        Me.lstButtons.MultiSelect = False
        Me.lstButtons.Name = "lstButtons"
        Me.lstButtons.Size = New System.Drawing.Size(270, 183)
        Me.lstButtons.TabIndex = 10
        Me.lstButtons.UseCompatibleStateImageBehavior = False
        Me.lstButtons.View = System.Windows.Forms.View.Details
        '
        'cmdMoveToPanel
        '
        Me.cmdMoveToPanel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveToPanel.Location = New System.Drawing.Point(12, 12)
        Me.cmdMoveToPanel.Name = "cmdMoveToPanel"
        Me.cmdMoveToPanel.Size = New System.Drawing.Size(270, 30)
        Me.cmdMoveToPanel.TabIndex = 14
        Me.cmdMoveToPanel.UseVisualStyleBackColor = True
        '
        'frmConfigureButtons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 397)
        Me.Controls.Add(Me.cmdDeleteButton)
        Me.Controls.Add(Me.cmdEditButton)
        Me.Controls.Add(Me.cmdMoveToPanel)
        Me.Controls.Add(Me.cmdCreateNewButton)
        Me.Controls.Add(Me.cmdMoveDown)
        Me.Controls.Add(Me.cmdMoveUp)
        Me.Controls.Add(Me.cmdDone)
        Me.Controls.Add(Me.lstButtons)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfigureButtons"
        Me.Text = "Configure Buttons"
        Me.ResumeLayout(False)

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
