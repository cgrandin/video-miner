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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.lblSpeciesCommonName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSpeciesCommonName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSpeciesCommonName.Location = New System.Drawing.Point(3, 7)
        Me.lblSpeciesCommonName.Name = "lblSpeciesCommonName"
        Me.lblSpeciesCommonName.Size = New System.Drawing.Size(155, 13)
        Me.lblSpeciesCommonName.TabIndex = 24
        Me.lblSpeciesCommonName.Text = "Species Common Name"
        '
        'cboCommonName
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboCommonName, 2)
        Me.cboCommonName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCommonName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCommonName.FormattingEnabled = True
        Me.cboCommonName.Location = New System.Drawing.Point(3, 23)
        Me.cboCommonName.Name = "cboCommonName"
        Me.cboCommonName.Size = New System.Drawing.Size(317, 21)
        Me.cboCommonName.TabIndex = 25
        '
        'lblSpeciesScientificName
        '
        Me.lblSpeciesScientificName.AutoSize = True
        Me.lblSpeciesScientificName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSpeciesScientificName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSpeciesScientificName.Location = New System.Drawing.Point(3, 59)
        Me.lblSpeciesScientificName.Name = "lblSpeciesScientificName"
        Me.lblSpeciesScientificName.Size = New System.Drawing.Size(155, 13)
        Me.lblSpeciesScientificName.TabIndex = 26
        Me.lblSpeciesScientificName.Text = "Species Scientific Name"
        '
        'cboScientificName
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboScientificName, 2)
        Me.cboScientificName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboScientificName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboScientificName.FormattingEnabled = True
        Me.cboScientificName.Location = New System.Drawing.Point(3, 75)
        Me.cboScientificName.Name = "cboScientificName"
        Me.cboScientificName.Size = New System.Drawing.Size(317, 21)
        Me.cboScientificName.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Species Code:"
        '
        'txtSpeciesCode
        '
        Me.txtSpeciesCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSpeciesCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpeciesCode.Location = New System.Drawing.Point(3, 127)
        Me.txtSpeciesCode.MaxLength = 50
        Me.txtSpeciesCode.Name = "txtSpeciesCode"
        Me.txtSpeciesCode.ReadOnly = True
        Me.txtSpeciesCode.Size = New System.Drawing.Size(155, 21)
        Me.txtSpeciesCode.TabIndex = 29
        Me.txtSpeciesCode.TabStop = False
        Me.txtSpeciesCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTaxonomicLevel
        '
        Me.txtTaxonomicLevel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTaxonomicLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxonomicLevel.Location = New System.Drawing.Point(164, 127)
        Me.txtTaxonomicLevel.MaxLength = 50
        Me.txtTaxonomicLevel.Name = "txtTaxonomicLevel"
        Me.txtTaxonomicLevel.ReadOnly = True
        Me.txtTaxonomicLevel.Size = New System.Drawing.Size(156, 21)
        Me.txtTaxonomicLevel.TabIndex = 31
        Me.txtTaxonomicLevel.TabStop = False
        Me.txtTaxonomicLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTaxonomicLevel
        '
        Me.lblTaxonomicLevel.AutoSize = True
        Me.lblTaxonomicLevel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTaxonomicLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxonomicLevel.Location = New System.Drawing.Point(164, 111)
        Me.lblTaxonomicLevel.Name = "lblTaxonomicLevel"
        Me.lblTaxonomicLevel.Size = New System.Drawing.Size(156, 13)
        Me.lblTaxonomicLevel.TabIndex = 30
        Me.lblTaxonomicLevel.Text = "Taxonomic Level:"
        '
        'cmdCancel
        '
        Me.cmdCancel.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(164, 159)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(140, 40)
        Me.cmdCancel.TabIndex = 33
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(18, 159)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(140, 40)
        Me.cmdOk.TabIndex = 32
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblSpeciesCommonName, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdCancel, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.cboCommonName, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdOk, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSpeciesScientificName, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTaxonomicLevel, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cboScientificName, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSpeciesCode, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTaxonomicLevel, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.32653!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.32653!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.32653!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.40816!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(323, 202)
        Me.TableLayoutPanel1.TabIndex = 34
        '
        'frmRareSpeciesLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 202)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblTaxonomicCodeValue)
        Me.Controls.Add(Me.lblSpeciesCodeValue)
        Me.Controls.Add(Me.lblLatinNameValue)
        Me.Controls.Add(Me.lblScientificNameValue)
        Me.Controls.Add(Me.lblCommonNameValue)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRareSpeciesLookup"
        Me.Text = "Rare Species Lookup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
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
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
