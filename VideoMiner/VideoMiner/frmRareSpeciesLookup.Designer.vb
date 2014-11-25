<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRareSpeciesLookup
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
        radLatinName = New System.Windows.Forms.RadioButton
        radScientificName = New System.Windows.Forms.RadioButton
        radCommonName = New System.Windows.Forms.RadioButton
        cboSpecies = New System.Windows.Forms.ComboBox
        lblSearchSpeciesBy = New System.Windows.Forms.Label
        lblCommonName = New System.Windows.Forms.Label
        lblScientificName = New System.Windows.Forms.Label
        lblLatinName = New System.Windows.Forms.Label
        lblSpeciesCode = New System.Windows.Forms.Label
        lblCommonNameValue = New System.Windows.Forms.Label
        lblScientificNameValue = New System.Windows.Forms.Label
        lblLatinNameValue = New System.Windows.Forms.Label
        lblSpeciesCodeValue = New System.Windows.Forms.Label
        cmdOK = New System.Windows.Forms.Button
        cmdCancel = New System.Windows.Forms.Button
        lblTaxonomicCode = New System.Windows.Forms.Label
        lblTaxonomicCodeValue = New System.Windows.Forms.Label
        SuspendLayout()
        '
        'radLatinName
        '
        radLatinName.AutoSize = True
        radLatinName.Enabled = False
        radLatinName.Location = New System.Drawing.Point(25, 76)
        radLatinName.Name = "radLatinName"
        radLatinName.Size = New System.Drawing.Size(123, 17)
        radLatinName.TabIndex = 20
        radLatinName.Text = "Species Latin Name:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        radLatinName.UseVisualStyleBackColor = True
        radLatinName.Visible = False
        '
        'radScientificName
        '
        radScientificName.AutoSize = True
        radScientificName.Location = New System.Drawing.Point(25, 76)
        radScientificName.Name = "radScientificName"
        radScientificName.Size = New System.Drawing.Size(143, 17)
        radScientificName.TabIndex = 19
        radScientificName.Text = "Species Scientific Name:"
        radScientificName.UseVisualStyleBackColor = True
        '
        'radCommonName
        '
        radCommonName.AutoSize = True
        radCommonName.Checked = True
        radCommonName.Location = New System.Drawing.Point(25, 53)
        radCommonName.Name = "radCommonName"
        radCommonName.Size = New System.Drawing.Size(141, 17)
        radCommonName.TabIndex = 18
        radCommonName.TabStop = True
        radCommonName.Text = "Species Common Name:"
        radCommonName.UseVisualStyleBackColor = True
        '
        'cboSpecies
        '
        cboSpecies.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cboSpecies.FormattingEnabled = True
        cboSpecies.Location = New System.Drawing.Point(25, 99)
        cboSpecies.Name = "cboSpecies"
        cboSpecies.Size = New System.Drawing.Size(333, 21)
        cboSpecies.Sorted = True
        cboSpecies.TabIndex = 15
        '
        'lblSearchSpeciesBy
        '
        lblSearchSpeciesBy.AutoSize = True
        lblSearchSpeciesBy.Location = New System.Drawing.Point(22, 26)
        lblSearchSpeciesBy.Name = "lblSearchSpeciesBy"
        lblSearchSpeciesBy.Size = New System.Drawing.Size(100, 13)
        lblSearchSpeciesBy.TabIndex = 21
        lblSearchSpeciesBy.Text = "Search Species By:"
        '
        'lblCommonName
        '
        lblCommonName.AutoSize = True
        lblCommonName.Location = New System.Drawing.Point(22, 157)
        lblCommonName.Name = "lblCommonName"
        lblCommonName.Size = New System.Drawing.Size(82, 13)
        lblCommonName.TabIndex = 22
        lblCommonName.Text = "Common Name:"
        '
        'lblScientificName
        '
        lblScientificName.AutoSize = True
        lblScientificName.Location = New System.Drawing.Point(22, 190)
        lblScientificName.Name = "lblScientificName"
        lblScientificName.Size = New System.Drawing.Size(84, 13)
        lblScientificName.TabIndex = 22
        lblScientificName.Text = "Scientific Name:"
        '
        'lblLatinName
        '
        lblLatinName.AutoSize = True
        lblLatinName.Enabled = False
        lblLatinName.Location = New System.Drawing.Point(22, 190)
        lblLatinName.Name = "lblLatinName"
        lblLatinName.Size = New System.Drawing.Size(64, 13)
        lblLatinName.TabIndex = 22
        lblLatinName.Text = "Latin Name:"
        lblLatinName.Visible = False
        '
        'lblSpeciesCode
        '
        lblSpeciesCode.AutoSize = True
        lblSpeciesCode.Location = New System.Drawing.Point(22, 223)
        lblSpeciesCode.Name = "lblSpeciesCode"
        lblSpeciesCode.Size = New System.Drawing.Size(76, 13)
        lblSpeciesCode.TabIndex = 22
        lblSpeciesCode.Text = "Species Code:"
        '
        'lblCommonNameValue
        '
        lblCommonNameValue.AutoSize = True
        lblCommonNameValue.Location = New System.Drawing.Point(112, 157)
        lblCommonNameValue.Name = "lblCommonNameValue"
        lblCommonNameValue.Size = New System.Drawing.Size(0, 13)
        lblCommonNameValue.TabIndex = 23
        '
        'lblScientificNameValue
        '
        lblScientificNameValue.AutoSize = True
        lblScientificNameValue.Location = New System.Drawing.Point(112, 190)
        lblScientificNameValue.Name = "lblScientificNameValue"
        lblScientificNameValue.Size = New System.Drawing.Size(0, 13)
        lblScientificNameValue.TabIndex = 23
        '
        'lblLatinNameValue
        '
        lblLatinNameValue.AutoSize = True
        lblLatinNameValue.Enabled = False
        lblLatinNameValue.Location = New System.Drawing.Point(112, 190)
        lblLatinNameValue.Name = "lblLatinNameValue"
        lblLatinNameValue.Size = New System.Drawing.Size(0, 13)
        lblLatinNameValue.TabIndex = 23
        lblLatinNameValue.Visible = False
        '
        'lblSpeciesCodeValue
        '
        lblSpeciesCodeValue.AutoSize = True
        lblSpeciesCodeValue.Location = New System.Drawing.Point(112, 223)
        lblSpeciesCodeValue.Name = "lblSpeciesCodeValue"
        lblSpeciesCodeValue.Size = New System.Drawing.Size(0, 13)
        lblSpeciesCodeValue.TabIndex = 23
        '
        'cmdOK
        '
        cmdOK.Enabled = False
        cmdOK.Location = New System.Drawing.Point(69, 319)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(112, 37)
        cmdOK.TabIndex = 24
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        cmdCancel.Location = New System.Drawing.Point(187, 319)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New System.Drawing.Size(112, 37)
        cmdCancel.TabIndex = 25
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        '
        'lblTaxonomicCode
        '
        lblTaxonomicCode.AutoSize = True
        lblTaxonomicCode.Location = New System.Drawing.Point(22, 255)
        lblTaxonomicCode.Name = "lblTaxonomicCode"
        lblTaxonomicCode.Size = New System.Drawing.Size(90, 13)
        lblTaxonomicCode.TabIndex = 22
        lblTaxonomicCode.Text = "Taxonomic Code:"
        '
        'lblTaxonomicCodeValue
        '
        lblTaxonomicCodeValue.AutoSize = True
        lblTaxonomicCodeValue.Location = New System.Drawing.Point(112, 255)
        lblTaxonomicCodeValue.Name = "lblTaxonomicCodeValue"
        lblTaxonomicCodeValue.Size = New System.Drawing.Size(0, 13)
        lblTaxonomicCodeValue.TabIndex = 23
        '
        'frmRareSpeciesLookup
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(377, 370)
        Controls.Add(cmdCancel)
        Controls.Add(cmdOK)
        Controls.Add(lblTaxonomicCodeValue)
        Controls.Add(lblSpeciesCodeValue)
        Controls.Add(lblLatinNameValue)
        Controls.Add(lblScientificNameValue)
        Controls.Add(lblCommonNameValue)
        Controls.Add(lblTaxonomicCode)
        Controls.Add(lblSpeciesCode)
        Controls.Add(lblLatinName)
        Controls.Add(lblScientificName)
        Controls.Add(lblCommonName)
        Controls.Add(lblSearchSpeciesBy)
        Controls.Add(radLatinName)
        Controls.Add(radScientificName)
        Controls.Add(radCommonName)
        Controls.Add(cboSpecies)
        Name = "frmRareSpeciesLookup"
        Text = "Rare Species Lookup"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents radLatinName As System.Windows.Forms.RadioButton
    Friend WithEvents radScientificName As System.Windows.Forms.RadioButton
    Friend WithEvents radCommonName As System.Windows.Forms.RadioButton
    Friend WithEvents cboSpecies As System.Windows.Forms.ComboBox
    Friend WithEvents lblSearchSpeciesBy As System.Windows.Forms.Label
    Friend WithEvents lblCommonName As System.Windows.Forms.Label
    Friend WithEvents lblScientificName As System.Windows.Forms.Label
    Friend WithEvents lblLatinName As System.Windows.Forms.Label
    Friend WithEvents lblSpeciesCode As System.Windows.Forms.Label
    Friend WithEvents lblCommonNameValue As System.Windows.Forms.Label
    Friend WithEvents lblScientificNameValue As System.Windows.Forms.Label
    Friend WithEvents lblLatinNameValue As System.Windows.Forms.Label
    Friend WithEvents lblSpeciesCodeValue As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblTaxonomicCode As System.Windows.Forms.Label
    Friend WithEvents lblTaxonomicCodeValue As System.Windows.Forms.Label
End Class
