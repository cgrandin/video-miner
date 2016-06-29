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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKeyboardCommands))
        Me.lblSpeciesEntry = New System.Windows.Forms.Label()
        Me.lblImageControl = New System.Windows.Forms.Label()
        Me.lblLeftArrow = New System.Windows.Forms.Label()
        Me.lblRightArrow = New System.Windows.Forms.Label()
        Me.lblLeftArrowValue = New System.Windows.Forms.Label()
        Me.lblNextImageValue = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.lstSpecies = New System.Windows.Forms.ListView()
        Me.cmdAssignShortcut = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblSpeciesEntry
        '
        Me.lblSpeciesEntry.AutoSize = True
        Me.lblSpeciesEntry.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpeciesEntry.Location = New System.Drawing.Point(12, 9)
        Me.lblSpeciesEntry.Name = "lblSpeciesEntry"
        Me.lblSpeciesEntry.Size = New System.Drawing.Size(116, 23)
        Me.lblSpeciesEntry.TabIndex = 0
        Me.lblSpeciesEntry.Text = "Species Entry"
        '
        'lblImageControl
        '
        Me.lblImageControl.AutoSize = True
        Me.lblImageControl.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageControl.Location = New System.Drawing.Point(12, 432)
        Me.lblImageControl.Name = "lblImageControl"
        Me.lblImageControl.Size = New System.Drawing.Size(121, 23)
        Me.lblImageControl.TabIndex = 0
        Me.lblImageControl.Text = "Image Control"
        '
        'lblLeftArrow
        '
        Me.lblLeftArrow.AutoSize = True
        Me.lblLeftArrow.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeftArrow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLeftArrow.Location = New System.Drawing.Point(34, 470)
        Me.lblLeftArrow.Name = "lblLeftArrow"
        Me.lblLeftArrow.Size = New System.Drawing.Size(85, 19)
        Me.lblLeftArrow.TabIndex = 0
        Me.lblLeftArrow.Text = "Left Arrow:"
        '
        'lblRightArrow
        '
        Me.lblRightArrow.AutoSize = True
        Me.lblRightArrow.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRightArrow.Location = New System.Drawing.Point(34, 495)
        Me.lblRightArrow.Name = "lblRightArrow"
        Me.lblRightArrow.Size = New System.Drawing.Size(96, 19)
        Me.lblRightArrow.TabIndex = 0
        Me.lblRightArrow.Text = "Right Arrow:"
        '
        'lblLeftArrowValue
        '
        Me.lblLeftArrowValue.AutoSize = True
        Me.lblLeftArrowValue.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeftArrowValue.Location = New System.Drawing.Point(145, 470)
        Me.lblLeftArrowValue.Name = "lblLeftArrowValue"
        Me.lblLeftArrowValue.Size = New System.Drawing.Size(108, 19)
        Me.lblLeftArrowValue.TabIndex = 0
        Me.lblLeftArrowValue.Text = "Previous Image"
        '
        'lblNextImageValue
        '
        Me.lblNextImageValue.AutoSize = True
        Me.lblNextImageValue.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNextImageValue.Location = New System.Drawing.Point(145, 495)
        Me.lblNextImageValue.Name = "lblNextImageValue"
        Me.lblNextImageValue.Size = New System.Drawing.Size(83, 19)
        Me.lblNextImageValue.TabIndex = 0
        Me.lblNextImageValue.Text = "Next Image"
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(105, 541)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(110, 30)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'lstSpecies
        '
        Me.lstSpecies.Location = New System.Drawing.Point(16, 50)
        Me.lstSpecies.Name = "lstSpecies"
        Me.lstSpecies.Size = New System.Drawing.Size(310, 311)
        Me.lstSpecies.TabIndex = 2
        Me.lstSpecies.UseCompatibleStateImageBehavior = False
        '
        'cmdAssignShortcut
        '
        Me.cmdAssignShortcut.Location = New System.Drawing.Point(16, 367)
        Me.cmdAssignShortcut.Name = "cmdAssignShortcut"
        Me.cmdAssignShortcut.Size = New System.Drawing.Size(110, 30)
        Me.cmdAssignShortcut.TabIndex = 3
        Me.cmdAssignShortcut.Text = "Assign Shortcut"
        Me.cmdAssignShortcut.UseVisualStyleBackColor = True
        '
        'frmKeyboardCommands
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 610)
        Me.Controls.Add(Me.cmdAssignShortcut)
        Me.Controls.Add(Me.lstSpecies)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblNextImageValue)
        Me.Controls.Add(Me.lblRightArrow)
        Me.Controls.Add(Me.lblLeftArrowValue)
        Me.Controls.Add(Me.lblLeftArrow)
        Me.Controls.Add(Me.lblImageControl)
        Me.Controls.Add(Me.lblSpeciesEntry)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKeyboardCommands"
        Me.Text = "Keyboard Shortcuts"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
