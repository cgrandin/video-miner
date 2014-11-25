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
        ok = New System.Windows.Forms.Button
        Label6 = New System.Windows.Forms.Label
        speciesComboBox = New System.Windows.Forms.ComboBox
        btnCancel = New System.Windows.Forms.Button
        pnlSpeciesEvent = New System.Windows.Forms.Panel
        cmdScreenCapture = New System.Windows.Forms.Button
        SuspendLayout()
        '
        'ok
        '
        ok.Location = New System.Drawing.Point(52, 544)
        ok.Margin = New System.Windows.Forms.Padding(2)
        ok.Name = "ok"
        ok.Size = New System.Drawing.Size(90, 24)
        ok.TabIndex = 3
        ok.Text = "OK"
        ok.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(11, 20)
        Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(62, 17)
        Label6.TabIndex = 21
        Label6.Text = "Species:"
        '
        'speciesComboBox
        '
        speciesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        speciesComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold)
        speciesComboBox.FormattingEnabled = True
        speciesComboBox.Location = New System.Drawing.Point(80, 17)
        speciesComboBox.Name = "speciesComboBox"
        speciesComboBox.Size = New System.Drawing.Size(218, 25)
        speciesComboBox.TabIndex = 13
        '
        'btnCancel
        '
        btnCancel.Location = New System.Drawing.Point(147, 544)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New System.Drawing.Size(90, 24)
        btnCancel.TabIndex = 22
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        '
        'pnlSpeciesEvent
        '
        pnlSpeciesEvent.AutoScroll = True
        pnlSpeciesEvent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        pnlSpeciesEvent.Location = New System.Drawing.Point(4, 48)
        pnlSpeciesEvent.Name = "pnlSpeciesEvent"
        pnlSpeciesEvent.Size = New System.Drawing.Size(300, 473)
        pnlSpeciesEvent.TabIndex = 24
        '
        'cmdScreenCapture
        '
        cmdScreenCapture.BackColor = System.Drawing.SystemColors.Control
        cmdScreenCapture.BackgroundImage = CType(resources.GetObject("cmdScreenCapture.BackgroundImage"), System.Drawing.Image)
        cmdScreenCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        cmdScreenCapture.Location = New System.Drawing.Point(265, 543)
        cmdScreenCapture.Name = "cmdScreenCapture"
        cmdScreenCapture.Size = New System.Drawing.Size(33, 26)
        cmdScreenCapture.TabIndex = 58
        cmdScreenCapture.UseVisualStyleBackColor = False
        '
        'frmSpeciesEvent
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(309, 585)
        Controls.Add(cmdScreenCapture)
        Controls.Add(pnlSpeciesEvent)
        Controls.Add(btnCancel)
        Controls.Add(speciesComboBox)
        Controls.Add(Label6)
        Controls.Add(ok)
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        KeyPreview = True
        Margin = New System.Windows.Forms.Padding(2)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmSpeciesEvent"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Text = "Species Event"
        TopMost = True
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents speciesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlSpeciesEvent As System.Windows.Forms.Panel
    Friend WithEvents cmdScreenCapture As System.Windows.Forms.Button
End Class
