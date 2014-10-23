<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpeciesEvent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSpeciesEvent))
        Me.ok = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.speciesComboBox = New System.Windows.Forms.ComboBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.pnlSpeciesEvent = New System.Windows.Forms.Panel
        Me.cmdScreenCapture = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(52, 544)
        Me.ok.Margin = New System.Windows.Forms.Padding(2)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(90, 24)
        Me.ok.TabIndex = 3
        Me.ok.Text = "OK"
        Me.ok.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 17)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Species:"
        '
        'speciesComboBox
        '
        Me.speciesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.speciesComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold)
        Me.speciesComboBox.FormattingEnabled = True
        Me.speciesComboBox.Location = New System.Drawing.Point(80, 17)
        Me.speciesComboBox.Name = "speciesComboBox"
        Me.speciesComboBox.Size = New System.Drawing.Size(218, 25)
        Me.speciesComboBox.TabIndex = 13
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(147, 544)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 24)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlSpeciesEvent
        '
        Me.pnlSpeciesEvent.AutoScroll = True
        Me.pnlSpeciesEvent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSpeciesEvent.Location = New System.Drawing.Point(4, 48)
        Me.pnlSpeciesEvent.Name = "pnlSpeciesEvent"
        Me.pnlSpeciesEvent.Size = New System.Drawing.Size(300, 473)
        Me.pnlSpeciesEvent.TabIndex = 24
        '
        'cmdScreenCapture
        '
        Me.cmdScreenCapture.BackColor = System.Drawing.SystemColors.Control
        Me.cmdScreenCapture.BackgroundImage = CType(resources.GetObject("cmdScreenCapture.BackgroundImage"), System.Drawing.Image)
        Me.cmdScreenCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdScreenCapture.Location = New System.Drawing.Point(265, 543)
        Me.cmdScreenCapture.Name = "cmdScreenCapture"
        Me.cmdScreenCapture.Size = New System.Drawing.Size(33, 26)
        Me.cmdScreenCapture.TabIndex = 58
        Me.cmdScreenCapture.UseVisualStyleBackColor = False
        '
        'frmSpeciesEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 585)
        Me.Controls.Add(Me.cmdScreenCapture)
        Me.Controls.Add(Me.pnlSpeciesEvent)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.speciesComboBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ok)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSpeciesEvent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Species Event"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents speciesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlSpeciesEvent As System.Windows.Forms.Panel
    Friend WithEvents cmdScreenCapture As System.Windows.Forms.Button
End Class
