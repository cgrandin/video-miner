<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeyboardCommands
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
        lblSpeciesEntry = New System.Windows.Forms.Label
        lblImageControl = New System.Windows.Forms.Label
        lblLeftArrow = New System.Windows.Forms.Label
        lblRightArrow = New System.Windows.Forms.Label
        lblLeftArrowValue = New System.Windows.Forms.Label
        lblNextImageValue = New System.Windows.Forms.Label
        cmdOK = New System.Windows.Forms.Button
        lstSpecies = New System.Windows.Forms.ListView
        cmdAssignShortcut = New System.Windows.Forms.Button
        SuspendLayout()
        '
        'lblSpeciesEntry
        '
        lblSpeciesEntry.AutoSize = True
        lblSpeciesEntry.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblSpeciesEntry.Location = New System.Drawing.Point(12, 9)
        lblSpeciesEntry.Name = "lblSpeciesEntry"
        lblSpeciesEntry.Size = New System.Drawing.Size(116, 23)
        lblSpeciesEntry.TabIndex = 0
        lblSpeciesEntry.Text = "Species Entry"
        '
        'lblImageControl
        '
        lblImageControl.AutoSize = True
        lblImageControl.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblImageControl.Location = New System.Drawing.Point(12, 432)
        lblImageControl.Name = "lblImageControl"
        lblImageControl.Size = New System.Drawing.Size(121, 23)
        lblImageControl.TabIndex = 0
        lblImageControl.Text = "Image Control"
        '
        'lblLeftArrow
        '
        lblLeftArrow.AutoSize = True
        lblLeftArrow.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblLeftArrow.ForeColor = System.Drawing.SystemColors.ControlText
        lblLeftArrow.Location = New System.Drawing.Point(34, 470)
        lblLeftArrow.Name = "lblLeftArrow"
        lblLeftArrow.Size = New System.Drawing.Size(85, 19)
        lblLeftArrow.TabIndex = 0
        lblLeftArrow.Text = "Left Arrow:"
        '
        'lblRightArrow
        '
        lblRightArrow.AutoSize = True
        lblRightArrow.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblRightArrow.Location = New System.Drawing.Point(34, 495)
        lblRightArrow.Name = "lblRightArrow"
        lblRightArrow.Size = New System.Drawing.Size(96, 19)
        lblRightArrow.TabIndex = 0
        lblRightArrow.Text = "Right Arrow:"
        '
        'lblLeftArrowValue
        '
        lblLeftArrowValue.AutoSize = True
        lblLeftArrowValue.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblLeftArrowValue.Location = New System.Drawing.Point(145, 470)
        lblLeftArrowValue.Name = "lblLeftArrowValue"
        lblLeftArrowValue.Size = New System.Drawing.Size(108, 19)
        lblLeftArrowValue.TabIndex = 0
        lblLeftArrowValue.Text = "Previous Image"
        '
        'lblNextImageValue
        '
        lblNextImageValue.AutoSize = True
        lblNextImageValue.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblNextImageValue.Location = New System.Drawing.Point(145, 495)
        lblNextImageValue.Name = "lblNextImageValue"
        lblNextImageValue.Size = New System.Drawing.Size(83, 19)
        lblNextImageValue.TabIndex = 0
        lblNextImageValue.Text = "Next Image"
        '
        'cmdOK
        '
        cmdOK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdOK.Location = New System.Drawing.Point(105, 541)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(110, 30)
        cmdOK.TabIndex = 1
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'lstSpecies
        '
        lstSpecies.Location = New System.Drawing.Point(16, 50)
        lstSpecies.Name = "lstSpecies"
        lstSpecies.Size = New System.Drawing.Size(310, 311)
        lstSpecies.TabIndex = 2
        lstSpecies.UseCompatibleStateImageBehavior = False
        '
        'cmdAssignShortcut
        '
        cmdAssignShortcut.Location = New System.Drawing.Point(16, 367)
        cmdAssignShortcut.Name = "cmdAssignShortcut"
        cmdAssignShortcut.Size = New System.Drawing.Size(110, 30)
        cmdAssignShortcut.TabIndex = 3
        cmdAssignShortcut.Text = "Assign Shortcut"
        cmdAssignShortcut.UseVisualStyleBackColor = True
        '
        'frmKeyboardCommands
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(338, 610)
        Controls.Add(cmdAssignShortcut)
        Controls.Add(lstSpecies)
        Controls.Add(cmdOK)
        Controls.Add(lblNextImageValue)
        Controls.Add(lblRightArrow)
        Controls.Add(lblLeftArrowValue)
        Controls.Add(lblLeftArrow)
        Controls.Add(lblImageControl)
        Controls.Add(lblSpeciesEntry)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmKeyboardCommands"
        Text = "Keyboard Shortcuts"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents lblSpeciesEntry As System.Windows.Forms.Label
    Friend WithEvents lblImageControl As System.Windows.Forms.Label
    Friend WithEvents lblLeftArrow As System.Windows.Forms.Label
    Friend WithEvents lblRightArrow As System.Windows.Forms.Label
    Friend WithEvents lblLeftArrowValue As System.Windows.Forms.Label
    Friend WithEvents lblNextImageValue As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents lstSpecies As System.Windows.Forms.ListView
    Friend WithEvents cmdAssignShortcut As System.Windows.Forms.Button
End Class
