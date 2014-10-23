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
        Me.radLatinName = New System.Windows.Forms.RadioButton
        Me.radScientificName = New System.Windows.Forms.RadioButton
        Me.radCommonName = New System.Windows.Forms.RadioButton
        Me.cboSpecies = New System.Windows.Forms.ComboBox
        Me.lblSearchSpeciesBy = New System.Windows.Forms.Label
        Me.lblCommonName = New System.Windows.Forms.Label
        Me.lblScientificName = New System.Windows.Forms.Label
        Me.lblLatinName = New System.Windows.Forms.Label
        Me.lblSpeciesCode = New System.Windows.Forms.Label
        Me.lblCommonNameValue = New System.Windows.Forms.Label
        Me.lblScientificNameValue = New System.Windows.Forms.Label
        Me.lblLatinNameValue = New System.Windows.Forms.Label
        Me.lblSpeciesCodeValue = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblTaxonomicCode = New System.Windows.Forms.Label
        Me.lblTaxonomicCodeValue = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'radLatinName
        '
        Me.radLatinName.AutoSize = True
        Me.radLatinName.Enabled = False
        Me.radLatinName.Location = New System.Drawing.Point(25, 76)
        Me.radLatinName.Name = "radLatinName"
        Me.radLatinName.Size = New System.Drawing.Size(123, 17)
        Me.radLatinName.TabIndex = 20
        Me.radLatinName.Text = "Species Latin Name:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.radLatinName.UseVisualStyleBackColor = True
        Me.radLatinName.Visible = False
        '
        'radScientificName
        '
        Me.radScientificName.AutoSize = True
        Me.radScientificName.Location = New System.Drawing.Point(25, 76)
        Me.radScientificName.Name = "radScientificName"
        Me.radScientificName.Size = New System.Drawing.Size(143, 17)
        Me.radScientificName.TabIndex = 19
        Me.radScientificName.Text = "Species Scientific Name:"
        Me.radScientificName.UseVisualStyleBackColor = True
        '
        'radCommonName
        '
        Me.radCommonName.AutoSize = True
        Me.radCommonName.Checked = True
        Me.radCommonName.Location = New System.Drawing.Point(25, 53)
        Me.radCommonName.Name = "radCommonName"
        Me.radCommonName.Size = New System.Drawing.Size(141, 17)
        Me.radCommonName.TabIndex = 18
        Me.radCommonName.TabStop = True
        Me.radCommonName.Text = "Species Common Name:"
        Me.radCommonName.UseVisualStyleBackColor = True
        '
        'cboSpecies
        '
        Me.cboSpecies.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSpecies.FormattingEnabled = True
        Me.cboSpecies.Location = New System.Drawing.Point(25, 99)
        Me.cboSpecies.Name = "cboSpecies"
        Me.cboSpecies.Size = New System.Drawing.Size(333, 21)
        Me.cboSpecies.Sorted = True
        Me.cboSpecies.TabIndex = 15
        '
        'lblSearchSpeciesBy
        '
        Me.lblSearchSpeciesBy.AutoSize = True
        Me.lblSearchSpeciesBy.Location = New System.Drawing.Point(22, 26)
        Me.lblSearchSpeciesBy.Name = "lblSearchSpeciesBy"
        Me.lblSearchSpeciesBy.Size = New System.Drawing.Size(100, 13)
        Me.lblSearchSpeciesBy.TabIndex = 21
        Me.lblSearchSpeciesBy.Text = "Search Species By:"
        '
        'lblCommonName
        '
        Me.lblCommonName.AutoSize = True
        Me.lblCommonName.Location = New System.Drawing.Point(22, 157)
        Me.lblCommonName.Name = "lblCommonName"
        Me.lblCommonName.Size = New System.Drawing.Size(82, 13)
        Me.lblCommonName.TabIndex = 22
        Me.lblCommonName.Text = "Common Name:"
        '
        'lblScientificName
        '
        Me.lblScientificName.AutoSize = True
        Me.lblScientificName.Location = New System.Drawing.Point(22, 190)
        Me.lblScientificName.Name = "lblScientificName"
        Me.lblScientificName.Size = New System.Drawing.Size(84, 13)
        Me.lblScientificName.TabIndex = 22
        Me.lblScientificName.Text = "Scientific Name:"
        '
        'lblLatinName
        '
        Me.lblLatinName.AutoSize = True
        Me.lblLatinName.Enabled = False
        Me.lblLatinName.Location = New System.Drawing.Point(22, 190)
        Me.lblLatinName.Name = "lblLatinName"
        Me.lblLatinName.Size = New System.Drawing.Size(64, 13)
        Me.lblLatinName.TabIndex = 22
        Me.lblLatinName.Text = "Latin Name:"
        Me.lblLatinName.Visible = False
        '
        'lblSpeciesCode
        '
        Me.lblSpeciesCode.AutoSize = True
        Me.lblSpeciesCode.Location = New System.Drawing.Point(22, 223)
        Me.lblSpeciesCode.Name = "lblSpeciesCode"
        Me.lblSpeciesCode.Size = New System.Drawing.Size(76, 13)
        Me.lblSpeciesCode.TabIndex = 22
        Me.lblSpeciesCode.Text = "Species Code:"
        '
        'lblCommonNameValue
        '
        Me.lblCommonNameValue.AutoSize = True
        Me.lblCommonNameValue.Location = New System.Drawing.Point(112, 157)
        Me.lblCommonNameValue.Name = "lblCommonNameValue"
        Me.lblCommonNameValue.Size = New System.Drawing.Size(0, 13)
        Me.lblCommonNameValue.TabIndex = 23
        '
        'lblScientificNameValue
        '
        Me.lblScientificNameValue.AutoSize = True
        Me.lblScientificNameValue.Location = New System.Drawing.Point(112, 190)
        Me.lblScientificNameValue.Name = "lblScientificNameValue"
        Me.lblScientificNameValue.Size = New System.Drawing.Size(0, 13)
        Me.lblScientificNameValue.TabIndex = 23
        '
        'lblLatinNameValue
        '
        Me.lblLatinNameValue.AutoSize = True
        Me.lblLatinNameValue.Enabled = False
        Me.lblLatinNameValue.Location = New System.Drawing.Point(112, 190)
        Me.lblLatinNameValue.Name = "lblLatinNameValue"
        Me.lblLatinNameValue.Size = New System.Drawing.Size(0, 13)
        Me.lblLatinNameValue.TabIndex = 23
        Me.lblLatinNameValue.Visible = False
        '
        'lblSpeciesCodeValue
        '
        Me.lblSpeciesCodeValue.AutoSize = True
        Me.lblSpeciesCodeValue.Location = New System.Drawing.Point(112, 223)
        Me.lblSpeciesCodeValue.Name = "lblSpeciesCodeValue"
        Me.lblSpeciesCodeValue.Size = New System.Drawing.Size(0, 13)
        Me.lblSpeciesCodeValue.TabIndex = 23
        '
        'cmdOK
        '
        Me.cmdOK.Enabled = False
        Me.cmdOK.Location = New System.Drawing.Point(69, 319)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(112, 37)
        Me.cmdOK.TabIndex = 24
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(187, 319)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(112, 37)
        Me.cmdCancel.TabIndex = 25
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblTaxonomicCode
        '
        Me.lblTaxonomicCode.AutoSize = True
        Me.lblTaxonomicCode.Location = New System.Drawing.Point(22, 255)
        Me.lblTaxonomicCode.Name = "lblTaxonomicCode"
        Me.lblTaxonomicCode.Size = New System.Drawing.Size(90, 13)
        Me.lblTaxonomicCode.TabIndex = 22
        Me.lblTaxonomicCode.Text = "Taxonomic Code:"
        '
        'lblTaxonomicCodeValue
        '
        Me.lblTaxonomicCodeValue.AutoSize = True
        Me.lblTaxonomicCodeValue.Location = New System.Drawing.Point(112, 255)
        Me.lblTaxonomicCodeValue.Name = "lblTaxonomicCodeValue"
        Me.lblTaxonomicCodeValue.Size = New System.Drawing.Size(0, 13)
        Me.lblTaxonomicCodeValue.TabIndex = 23
        '
        'frmRareSpeciesLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 370)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblTaxonomicCodeValue)
        Me.Controls.Add(Me.lblSpeciesCodeValue)
        Me.Controls.Add(Me.lblLatinNameValue)
        Me.Controls.Add(Me.lblScientificNameValue)
        Me.Controls.Add(Me.lblCommonNameValue)
        Me.Controls.Add(Me.lblTaxonomicCode)
        Me.Controls.Add(Me.lblSpeciesCode)
        Me.Controls.Add(Me.lblLatinName)
        Me.Controls.Add(Me.lblScientificName)
        Me.Controls.Add(Me.lblCommonName)
        Me.Controls.Add(Me.lblSearchSpeciesBy)
        Me.Controls.Add(Me.radLatinName)
        Me.Controls.Add(Me.radScientificName)
        Me.Controls.Add(Me.radCommonName)
        Me.Controls.Add(Me.cboSpecies)
        Me.Name = "frmRareSpeciesLookup"
        Me.Text = "Rare Species Lookup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
