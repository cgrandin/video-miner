<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditSpecies
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
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        txtSpeciesCode = New System.Windows.Forms.TextBox
        cmdOk = New System.Windows.Forms.Button
        cmdCancel = New System.Windows.Forms.Button
        cboCommonName = New System.Windows.Forms.ComboBox
        cboScientificName = New System.Windows.Forms.ComboBox
        cboLatinName = New System.Windows.Forms.ComboBox
        radCommonName = New System.Windows.Forms.RadioButton
        radScientificName = New System.Windows.Forms.RadioButton
        radLatinName = New System.Windows.Forms.RadioButton
        lblSpeciesBtnTxt = New System.Windows.Forms.Label
        txtSpeciesBtnTxt = New System.Windows.Forms.TextBox
        cboButtonColors = New System.Windows.Forms.ComboBox
        lblButtonColor = New System.Windows.Forms.Label
        lblTaxonomicLevel = New System.Windows.Forms.Label
        txtTaxonomicLevel = New System.Windows.Forms.TextBox
        txtKeyboardShortcut = New System.Windows.Forms.TextBox
        lblKeyboardShortcut = New System.Windows.Forms.Label
        cmdChange = New System.Windows.Forms.Button
        SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(81, 61)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(0, 13)
        Label1.TabIndex = 0
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(14, 153)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(84, 13)
        Label2.TabIndex = 2
        Label2.Text = "Species Code:"
        '
        'txtSpeciesCode
        '
        txtSpeciesCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtSpeciesCode.Location = New System.Drawing.Point(16, 170)
        txtSpeciesCode.MaxLength = 50
        txtSpeciesCode.Name = "txtSpeciesCode"
        txtSpeciesCode.ReadOnly = True
        txtSpeciesCode.Size = New System.Drawing.Size(85, 21)
        txtSpeciesCode.TabIndex = 3
        txtSpeciesCode.TabStop = False
        txtSpeciesCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdOk
        '
        cmdOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdOk.Location = New System.Drawing.Point(136, 281)
        cmdOk.Name = "cmdOk"
        cmdOk.Size = New System.Drawing.Size(87, 23)
        cmdOk.TabIndex = 4
        cmdOk.Text = "OK"
        cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        cmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdCancel.Location = New System.Drawing.Point(229, 281)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New System.Drawing.Size(87, 23)
        cmdCancel.TabIndex = 5
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        '
        'cboCommonName
        '
        cboCommonName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cboCommonName.FormattingEnabled = True
        cboCommonName.Location = New System.Drawing.Point(17, 77)
        cboCommonName.Name = "cboCommonName"
        cboCommonName.Size = New System.Drawing.Size(411, 21)
        cboCommonName.TabIndex = 6
        '
        'cboScientificName
        '
        cboScientificName.Enabled = False
        cboScientificName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cboScientificName.FormattingEnabled = True
        cboScientificName.Location = New System.Drawing.Point(17, 129)
        cboScientificName.Name = "cboScientificName"
        cboScientificName.Size = New System.Drawing.Size(411, 21)
        cboScientificName.TabIndex = 8
        '
        'cboLatinName
        '
        cboLatinName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cboLatinName.FormattingEnabled = True
        cboLatinName.Location = New System.Drawing.Point(17, 129)
        cboLatinName.Name = "cboLatinName"
        cboLatinName.Size = New System.Drawing.Size(411, 21)
        cboLatinName.TabIndex = 10
        cboLatinName.Visible = False
        '
        'radCommonName
        '
        radCommonName.AutoSize = True
        radCommonName.Checked = True
        radCommonName.Location = New System.Drawing.Point(17, 59)
        radCommonName.Name = "radCommonName"
        radCommonName.Size = New System.Drawing.Size(159, 17)
        radCommonName.TabIndex = 11
        radCommonName.TabStop = True
        radCommonName.Text = "Species Common Name:"
        radCommonName.UseVisualStyleBackColor = True
        '
        'radScientificName
        '
        radScientificName.AutoSize = True
        radScientificName.Location = New System.Drawing.Point(17, 109)
        radScientificName.Name = "radScientificName"
        radScientificName.Size = New System.Drawing.Size(160, 17)
        radScientificName.TabIndex = 12
        radScientificName.Text = "Species Scientific Name:"
        radScientificName.UseVisualStyleBackColor = True
        '
        'radLatinName
        '
        radLatinName.AutoSize = True
        radLatinName.Enabled = False
        radLatinName.Location = New System.Drawing.Point(17, 109)
        radLatinName.Name = "radLatinName"
        radLatinName.Size = New System.Drawing.Size(137, 17)
        radLatinName.TabIndex = 13
        radLatinName.Text = "Species Latin Name:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        radLatinName.UseVisualStyleBackColor = True
        radLatinName.Visible = False
        '
        'lblSpeciesBtnTxt
        '
        lblSpeciesBtnTxt.AutoSize = True
        lblSpeciesBtnTxt.Location = New System.Drawing.Point(13, 13)
        lblSpeciesBtnTxt.Name = "lblSpeciesBtnTxt"
        lblSpeciesBtnTxt.Size = New System.Drawing.Size(77, 13)
        lblSpeciesBtnTxt.TabIndex = 14
        lblSpeciesBtnTxt.Text = "Button Text:"
        '
        'txtSpeciesBtnTxt
        '
        txtSpeciesBtnTxt.Location = New System.Drawing.Point(17, 29)
        txtSpeciesBtnTxt.MaxLength = 50
        txtSpeciesBtnTxt.Name = "txtSpeciesBtnTxt"
        txtSpeciesBtnTxt.Size = New System.Drawing.Size(411, 21)
        txtSpeciesBtnTxt.TabIndex = 15
        '
        'cboButtonColors
        '
        cboButtonColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        cboButtonColors.FormattingEnabled = True
        cboButtonColors.Location = New System.Drawing.Point(122, 169)
        cboButtonColors.Name = "cboButtonColors"
        cboButtonColors.Size = New System.Drawing.Size(121, 22)
        cboButtonColors.TabIndex = 16
        '
        'lblButtonColor
        '
        lblButtonColor.AutoSize = True
        lblButtonColor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblButtonColor.Location = New System.Drawing.Point(119, 153)
        lblButtonColor.Name = "lblButtonColor"
        lblButtonColor.Size = New System.Drawing.Size(80, 13)
        lblButtonColor.TabIndex = 2
        lblButtonColor.Text = "Button Color:"
        '
        'lblTaxonomicLevel
        '
        lblTaxonomicLevel.AutoSize = True
        lblTaxonomicLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTaxonomicLevel.Location = New System.Drawing.Point(262, 153)
        lblTaxonomicLevel.Name = "lblTaxonomicLevel"
        lblTaxonomicLevel.Size = New System.Drawing.Size(105, 13)
        lblTaxonomicLevel.TabIndex = 2
        lblTaxonomicLevel.Text = "Taxonomic Level:"
        '
        'txtTaxonomicLevel
        '
        txtTaxonomicLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtTaxonomicLevel.Location = New System.Drawing.Point(265, 170)
        txtTaxonomicLevel.MaxLength = 50
        txtTaxonomicLevel.Name = "txtTaxonomicLevel"
        txtTaxonomicLevel.ReadOnly = True
        txtTaxonomicLevel.Size = New System.Drawing.Size(85, 21)
        txtTaxonomicLevel.TabIndex = 3
        txtTaxonomicLevel.TabStop = False
        txtTaxonomicLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtKeyboardShortcut
        '
        txtKeyboardShortcut.Location = New System.Drawing.Point(17, 223)
        txtKeyboardShortcut.Name = "txtKeyboardShortcut"
        txtKeyboardShortcut.ReadOnly = True
        txtKeyboardShortcut.Size = New System.Drawing.Size(100, 21)
        txtKeyboardShortcut.TabIndex = 17
        '
        'lblKeyboardShortcut
        '
        lblKeyboardShortcut.AutoSize = True
        lblKeyboardShortcut.Location = New System.Drawing.Point(14, 207)
        lblKeyboardShortcut.Name = "lblKeyboardShortcut"
        lblKeyboardShortcut.Size = New System.Drawing.Size(113, 13)
        lblKeyboardShortcut.TabIndex = 18
        lblKeyboardShortcut.Text = "Keyboard Shortcut"
        '
        'cmdChange
        '
        cmdChange.Location = New System.Drawing.Point(123, 221)
        cmdChange.Name = "cmdChange"
        cmdChange.Size = New System.Drawing.Size(75, 23)
        cmdChange.TabIndex = 19
        cmdChange.Text = "Change"
        cmdChange.UseVisualStyleBackColor = True
        '
        'frmEditSpecies
        '
        AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(440, 326)
        Controls.Add(cmdChange)
        Controls.Add(lblKeyboardShortcut)
        Controls.Add(txtKeyboardShortcut)
        Controls.Add(cboButtonColors)
        Controls.Add(txtSpeciesBtnTxt)
        Controls.Add(lblSpeciesBtnTxt)
        Controls.Add(radLatinName)
        Controls.Add(radScientificName)
        Controls.Add(radCommonName)
        Controls.Add(cboLatinName)
        Controls.Add(cboScientificName)
        Controls.Add(cboCommonName)
        Controls.Add(cmdCancel)
        Controls.Add(cmdOk)
        Controls.Add(txtTaxonomicLevel)
        Controls.Add(txtSpeciesCode)
        Controls.Add(lblButtonColor)
        Controls.Add(lblTaxonomicLevel)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmEditSpecies"
        Text = "Edit Species"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSpeciesCode As System.Windows.Forms.TextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboCommonName As System.Windows.Forms.ComboBox
    Friend WithEvents cboScientificName As System.Windows.Forms.ComboBox
    Friend WithEvents cboLatinName As System.Windows.Forms.ComboBox
    Friend WithEvents radCommonName As System.Windows.Forms.RadioButton
    Friend WithEvents radScientificName As System.Windows.Forms.RadioButton
    Friend WithEvents radLatinName As System.Windows.Forms.RadioButton
    Friend WithEvents lblSpeciesBtnTxt As System.Windows.Forms.Label
    Friend WithEvents txtSpeciesBtnTxt As System.Windows.Forms.TextBox
    Friend WithEvents cboButtonColors As System.Windows.Forms.ComboBox
    Friend WithEvents lblButtonColor As System.Windows.Forms.Label
    Friend WithEvents lblTaxonomicLevel As System.Windows.Forms.Label
    Friend WithEvents txtTaxonomicLevel As System.Windows.Forms.TextBox
    Friend WithEvents txtKeyboardShortcut As System.Windows.Forms.TextBox
    Friend WithEvents lblKeyboardShortcut As System.Windows.Forms.Label
    Friend WithEvents cmdChange As System.Windows.Forms.Button
End Class
