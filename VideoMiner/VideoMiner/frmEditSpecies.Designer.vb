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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSpeciesCode = New System.Windows.Forms.TextBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cboCommonName = New System.Windows.Forms.ComboBox()
        Me.cboScientificName = New System.Windows.Forms.ComboBox()
        Me.radCommonName = New System.Windows.Forms.RadioButton()
        Me.radScientificName = New System.Windows.Forms.RadioButton()
        Me.lblSpeciesBtnTxt = New System.Windows.Forms.Label()
        Me.txtSpeciesBtnTxt = New System.Windows.Forms.TextBox()
        Me.cboButtonColors = New System.Windows.Forms.ComboBox()
        Me.lblButtonColor = New System.Windows.Forms.Label()
        Me.lblTaxonomicLevel = New System.Windows.Forms.Label()
        Me.txtTaxonomicLevel = New System.Windows.Forms.TextBox()
        Me.txtKeyboardShortcut = New System.Windows.Forms.TextBox()
        Me.lblKeyboardShortcut = New System.Windows.Forms.Label()
        Me.cmdChange = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(81, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Species Code:"
        '
        'txtSpeciesCode
        '
        Me.txtSpeciesCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpeciesCode.Location = New System.Drawing.Point(16, 170)
        Me.txtSpeciesCode.MaxLength = 50
        Me.txtSpeciesCode.Name = "txtSpeciesCode"
        Me.txtSpeciesCode.ReadOnly = True
        Me.txtSpeciesCode.Size = New System.Drawing.Size(85, 21)
        Me.txtSpeciesCode.TabIndex = 3
        Me.txtSpeciesCode.TabStop = False
        Me.txtSpeciesCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdOk
        '
        Me.cmdOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(136, 281)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(87, 23)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(229, 281)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(87, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cboCommonName
        '
        Me.cboCommonName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCommonName.FormattingEnabled = True
        Me.cboCommonName.Location = New System.Drawing.Point(17, 77)
        Me.cboCommonName.Name = "cboCommonName"
        Me.cboCommonName.Size = New System.Drawing.Size(411, 21)
        Me.cboCommonName.TabIndex = 6
        '
        'cboScientificName
        '
        Me.cboScientificName.Enabled = False
        Me.cboScientificName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboScientificName.FormattingEnabled = True
        Me.cboScientificName.Location = New System.Drawing.Point(17, 129)
        Me.cboScientificName.Name = "cboScientificName"
        Me.cboScientificName.Size = New System.Drawing.Size(411, 21)
        Me.cboScientificName.TabIndex = 8
        '
        'radCommonName
        '
        Me.radCommonName.AutoSize = True
        Me.radCommonName.Checked = True
        Me.radCommonName.Location = New System.Drawing.Point(17, 59)
        Me.radCommonName.Name = "radCommonName"
        Me.radCommonName.Size = New System.Drawing.Size(159, 17)
        Me.radCommonName.TabIndex = 11
        Me.radCommonName.TabStop = True
        Me.radCommonName.Text = "Species Common Name:"
        Me.radCommonName.UseVisualStyleBackColor = True
        '
        'radScientificName
        '
        Me.radScientificName.AutoSize = True
        Me.radScientificName.Location = New System.Drawing.Point(17, 109)
        Me.radScientificName.Name = "radScientificName"
        Me.radScientificName.Size = New System.Drawing.Size(160, 17)
        Me.radScientificName.TabIndex = 12
        Me.radScientificName.Text = "Species Scientific Name:"
        Me.radScientificName.UseVisualStyleBackColor = True
        '
        'lblSpeciesBtnTxt
        '
        Me.lblSpeciesBtnTxt.AutoSize = True
        Me.lblSpeciesBtnTxt.Location = New System.Drawing.Point(13, 13)
        Me.lblSpeciesBtnTxt.Name = "lblSpeciesBtnTxt"
        Me.lblSpeciesBtnTxt.Size = New System.Drawing.Size(77, 13)
        Me.lblSpeciesBtnTxt.TabIndex = 14
        Me.lblSpeciesBtnTxt.Text = "Button Text:"
        '
        'txtSpeciesBtnTxt
        '
        Me.txtSpeciesBtnTxt.Location = New System.Drawing.Point(17, 29)
        Me.txtSpeciesBtnTxt.MaxLength = 50
        Me.txtSpeciesBtnTxt.Name = "txtSpeciesBtnTxt"
        Me.txtSpeciesBtnTxt.Size = New System.Drawing.Size(411, 21)
        Me.txtSpeciesBtnTxt.TabIndex = 15
        '
        'cboButtonColors
        '
        Me.cboButtonColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboButtonColors.FormattingEnabled = True
        Me.cboButtonColors.Location = New System.Drawing.Point(122, 169)
        Me.cboButtonColors.Name = "cboButtonColors"
        Me.cboButtonColors.Size = New System.Drawing.Size(121, 22)
        Me.cboButtonColors.TabIndex = 16
        '
        'lblButtonColor
        '
        Me.lblButtonColor.AutoSize = True
        Me.lblButtonColor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblButtonColor.Location = New System.Drawing.Point(119, 153)
        Me.lblButtonColor.Name = "lblButtonColor"
        Me.lblButtonColor.Size = New System.Drawing.Size(80, 13)
        Me.lblButtonColor.TabIndex = 2
        Me.lblButtonColor.Text = "Button Color:"
        '
        'lblTaxonomicLevel
        '
        Me.lblTaxonomicLevel.AutoSize = True
        Me.lblTaxonomicLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxonomicLevel.Location = New System.Drawing.Point(262, 153)
        Me.lblTaxonomicLevel.Name = "lblTaxonomicLevel"
        Me.lblTaxonomicLevel.Size = New System.Drawing.Size(105, 13)
        Me.lblTaxonomicLevel.TabIndex = 2
        Me.lblTaxonomicLevel.Text = "Taxonomic Level:"
        '
        'txtTaxonomicLevel
        '
        Me.txtTaxonomicLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxonomicLevel.Location = New System.Drawing.Point(265, 170)
        Me.txtTaxonomicLevel.MaxLength = 50
        Me.txtTaxonomicLevel.Name = "txtTaxonomicLevel"
        Me.txtTaxonomicLevel.ReadOnly = True
        Me.txtTaxonomicLevel.Size = New System.Drawing.Size(85, 21)
        Me.txtTaxonomicLevel.TabIndex = 3
        Me.txtTaxonomicLevel.TabStop = False
        Me.txtTaxonomicLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtKeyboardShortcut
        '
        Me.txtKeyboardShortcut.Location = New System.Drawing.Point(17, 223)
        Me.txtKeyboardShortcut.Name = "txtKeyboardShortcut"
        Me.txtKeyboardShortcut.ReadOnly = True
        Me.txtKeyboardShortcut.Size = New System.Drawing.Size(100, 21)
        Me.txtKeyboardShortcut.TabIndex = 17
        '
        'lblKeyboardShortcut
        '
        Me.lblKeyboardShortcut.AutoSize = True
        Me.lblKeyboardShortcut.Location = New System.Drawing.Point(14, 207)
        Me.lblKeyboardShortcut.Name = "lblKeyboardShortcut"
        Me.lblKeyboardShortcut.Size = New System.Drawing.Size(113, 13)
        Me.lblKeyboardShortcut.TabIndex = 18
        Me.lblKeyboardShortcut.Text = "Keyboard Shortcut"
        '
        'cmdChange
        '
        Me.cmdChange.Location = New System.Drawing.Point(123, 221)
        Me.cmdChange.Name = "cmdChange"
        Me.cmdChange.Size = New System.Drawing.Size(75, 23)
        Me.cmdChange.TabIndex = 19
        Me.cmdChange.Text = "Change"
        Me.cmdChange.UseVisualStyleBackColor = True
        '
        'frmEditSpecies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 326)
        Me.Controls.Add(Me.cmdChange)
        Me.Controls.Add(Me.lblKeyboardShortcut)
        Me.Controls.Add(Me.txtKeyboardShortcut)
        Me.Controls.Add(Me.cboButtonColors)
        Me.Controls.Add(Me.txtSpeciesBtnTxt)
        Me.Controls.Add(Me.lblSpeciesBtnTxt)
        Me.Controls.Add(Me.radScientificName)
        Me.Controls.Add(Me.radCommonName)
        Me.Controls.Add(Me.cboScientificName)
        Me.Controls.Add(Me.cboCommonName)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtTaxonomicLevel)
        Me.Controls.Add(Me.txtSpeciesCode)
        Me.Controls.Add(Me.lblButtonColor)
        Me.Controls.Add(Me.lblTaxonomicLevel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditSpecies"
        Me.Text = "Edit Species"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSpeciesCode As System.Windows.Forms.TextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboCommonName As System.Windows.Forms.ComboBox
    Friend WithEvents cboScientificName As System.Windows.Forms.ComboBox
    Friend WithEvents radCommonName As System.Windows.Forms.RadioButton
    Friend WithEvents radScientificName As System.Windows.Forms.RadioButton
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
