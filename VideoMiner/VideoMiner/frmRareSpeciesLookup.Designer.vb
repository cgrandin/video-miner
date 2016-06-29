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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRareSpeciesLookup))
        Me.lblCommonNameValue = New System.Windows.Forms.Label()
        Me.lblScientificNameValue = New System.Windows.Forms.Label()
        Me.lblLatinNameValue = New System.Windows.Forms.Label()
        Me.lblSpeciesCodeValue = New System.Windows.Forms.Label()
        Me.lblTaxonomicCodeValue = New System.Windows.Forms.Label()
        Me.lblSpeciesCommonName = New System.Windows.Forms.Label()
        Me.cboCommonName = New System.Windows.Forms.ComboBox()
        Me.lblSpeciesScientificName = New System.Windows.Forms.Label()
        Me.cboScientificName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSpeciesCode = New System.Windows.Forms.TextBox()
        Me.txtTaxonomicLevel = New System.Windows.Forms.TextBox()
        Me.lblTaxonomicLevel = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
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
        'lblTaxonomicCodeValue
        '
        Me.lblTaxonomicCodeValue.AutoSize = True
        Me.lblTaxonomicCodeValue.Location = New System.Drawing.Point(112, 255)
        Me.lblTaxonomicCodeValue.Name = "lblTaxonomicCodeValue"
        Me.lblTaxonomicCodeValue.Size = New System.Drawing.Size(0, 13)
        Me.lblTaxonomicCodeValue.TabIndex = 23
        '
        'lblSpeciesCommonName
        '
        Me.lblSpeciesCommonName.AutoSize = True
        Me.lblSpeciesCommonName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSpeciesCommonName.Location = New System.Drawing.Point(12, 9)
        Me.lblSpeciesCommonName.Name = "lblSpeciesCommonName"
        Me.lblSpeciesCommonName.Size = New System.Drawing.Size(138, 13)
        Me.lblSpeciesCommonName.TabIndex = 24
        Me.lblSpeciesCommonName.Text = "Species Common Name"
        '
        'cboCommonName
        '
        Me.cboCommonName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCommonName.FormattingEnabled = True
        Me.cboCommonName.Location = New System.Drawing.Point(12, 25)
        Me.cboCommonName.Name = "cboCommonName"
        Me.cboCommonName.Size = New System.Drawing.Size(411, 21)
        Me.cboCommonName.TabIndex = 25
        '
        'lblSpeciesScientificName
        '
        Me.lblSpeciesScientificName.AutoSize = True
        Me.lblSpeciesScientificName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSpeciesScientificName.Location = New System.Drawing.Point(11, 61)
        Me.lblSpeciesScientificName.Name = "lblSpeciesScientificName"
        Me.lblSpeciesScientificName.Size = New System.Drawing.Size(139, 13)
        Me.lblSpeciesScientificName.TabIndex = 26
        Me.lblSpeciesScientificName.Text = "Species Scientific Name"
        '
        'cboScientificName
        '
        Me.cboScientificName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboScientificName.FormattingEnabled = True
        Me.cboScientificName.Location = New System.Drawing.Point(12, 77)
        Me.cboScientificName.Name = "cboScientificName"
        Me.cboScientificName.Size = New System.Drawing.Size(411, 21)
        Me.cboScientificName.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Species Code:"
        '
        'txtSpeciesCode
        '
        Me.txtSpeciesCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpeciesCode.Location = New System.Drawing.Point(15, 120)
        Me.txtSpeciesCode.MaxLength = 50
        Me.txtSpeciesCode.Name = "txtSpeciesCode"
        Me.txtSpeciesCode.ReadOnly = True
        Me.txtSpeciesCode.Size = New System.Drawing.Size(111, 21)
        Me.txtSpeciesCode.TabIndex = 29
        Me.txtSpeciesCode.TabStop = False
        Me.txtSpeciesCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTaxonomicLevel
        '
        Me.txtTaxonomicLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxonomicLevel.Location = New System.Drawing.Point(136, 120)
        Me.txtTaxonomicLevel.MaxLength = 50
        Me.txtTaxonomicLevel.Name = "txtTaxonomicLevel"
        Me.txtTaxonomicLevel.ReadOnly = True
        Me.txtTaxonomicLevel.Size = New System.Drawing.Size(136, 21)
        Me.txtTaxonomicLevel.TabIndex = 31
        Me.txtTaxonomicLevel.TabStop = False
        Me.txtTaxonomicLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTaxonomicLevel
        '
        Me.lblTaxonomicLevel.AutoSize = True
        Me.lblTaxonomicLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxonomicLevel.Location = New System.Drawing.Point(134, 103)
        Me.lblTaxonomicLevel.Name = "lblTaxonomicLevel"
        Me.lblTaxonomicLevel.Size = New System.Drawing.Size(105, 13)
        Me.lblTaxonomicLevel.TabIndex = 30
        Me.lblTaxonomicLevel.Text = "Taxonomic Level:"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(215, 152)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(87, 23)
        Me.cmdCancel.TabIndex = 33
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(122, 152)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(87, 23)
        Me.cmdOk.TabIndex = 32
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmRareSpeciesLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 187)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtTaxonomicLevel)
        Me.Controls.Add(Me.lblTaxonomicLevel)
        Me.Controls.Add(Me.txtSpeciesCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboScientificName)
        Me.Controls.Add(Me.lblSpeciesScientificName)
        Me.Controls.Add(Me.cboCommonName)
        Me.Controls.Add(Me.lblSpeciesCommonName)
        Me.Controls.Add(Me.lblTaxonomicCodeValue)
        Me.Controls.Add(Me.lblSpeciesCodeValue)
        Me.Controls.Add(Me.lblLatinNameValue)
        Me.Controls.Add(Me.lblScientificNameValue)
        Me.Controls.Add(Me.lblCommonNameValue)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRareSpeciesLookup"
        Me.Text = "Rare Species Lookup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCommonNameValue As System.Windows.Forms.Label
    Friend WithEvents lblScientificNameValue As System.Windows.Forms.Label
    Friend WithEvents lblLatinNameValue As System.Windows.Forms.Label
    Friend WithEvents lblSpeciesCodeValue As System.Windows.Forms.Label
    Friend WithEvents lblTaxonomicCodeValue As System.Windows.Forms.Label
    Friend WithEvents lblSpeciesCommonName As System.Windows.Forms.Label
    Friend WithEvents cboCommonName As System.Windows.Forms.ComboBox
    Friend WithEvents lblSpeciesScientificName As System.Windows.Forms.Label
    Friend WithEvents cboScientificName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSpeciesCode As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxonomicLevel As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxonomicLevel As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
End Class
