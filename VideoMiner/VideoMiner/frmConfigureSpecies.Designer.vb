<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigureSpecies
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
        chkRange = New System.Windows.Forms.CheckBox
        chkIDConfidence = New System.Windows.Forms.CheckBox
        chkAbundance = New System.Windows.Forms.CheckBox
        chkCount = New System.Windows.Forms.CheckBox
        chkHeight = New System.Windows.Forms.CheckBox
        chkWidth = New System.Windows.Forms.CheckBox
        chkLength = New System.Windows.Forms.CheckBox
        chkComments = New System.Windows.Forms.CheckBox
        lblDisplayed = New System.Windows.Forms.Label
        lblDefaultValue = New System.Windows.Forms.Label
        txtRangeValue = New System.Windows.Forms.TextBox
        cboIDConfidence = New System.Windows.Forms.ComboBox
        cboAbundance = New System.Windows.Forms.ComboBox
        txtCount = New System.Windows.Forms.TextBox
        txtHeight = New System.Windows.Forms.TextBox
        txtWidth = New System.Windows.Forms.TextBox
        txtLength = New System.Windows.Forms.TextBox
        txtComments = New System.Windows.Forms.RichTextBox
        cmdOK = New System.Windows.Forms.Button
        cmdCancel = New System.Windows.Forms.Button
        cboSide = New System.Windows.Forms.ComboBox
        lblSide = New System.Windows.Forms.Label
        lblLRangeValue = New System.Windows.Forms.Label
        SuspendLayout()
        '
        'chkRange
        '
        chkRange.AutoSize = True
        chkRange.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        chkRange.Location = New System.Drawing.Point(12, 60)
        chkRange.Name = "chkRange"
        chkRange.Size = New System.Drawing.Size(60, 18)
        chkRange.TabIndex = 2
        chkRange.Text = "Range"
        chkRange.UseVisualStyleBackColor = True
        '
        'chkIDConfidence
        '
        chkIDConfidence.AutoSize = True
        chkIDConfidence.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        chkIDConfidence.Location = New System.Drawing.Point(12, 114)
        chkIDConfidence.Name = "chkIDConfidence"
        chkIDConfidence.Size = New System.Drawing.Size(102, 18)
        chkIDConfidence.TabIndex = 2
        chkIDConfidence.Text = "ID Confidence"
        chkIDConfidence.UseVisualStyleBackColor = True
        '
        'chkAbundance
        '
        chkAbundance.AutoSize = True
        chkAbundance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        chkAbundance.Location = New System.Drawing.Point(12, 159)
        chkAbundance.Name = "chkAbundance"
        chkAbundance.Size = New System.Drawing.Size(87, 18)
        chkAbundance.TabIndex = 2
        chkAbundance.Text = "Abundance"
        chkAbundance.UseVisualStyleBackColor = True
        '
        'chkCount
        '
        chkCount.AutoSize = True
        chkCount.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        chkCount.Location = New System.Drawing.Point(12, 206)
        chkCount.Name = "chkCount"
        chkCount.Size = New System.Drawing.Size(57, 18)
        chkCount.TabIndex = 2
        chkCount.Text = "Count"
        chkCount.UseVisualStyleBackColor = True
        '
        'chkHeight
        '
        chkHeight.AutoSize = True
        chkHeight.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        chkHeight.Location = New System.Drawing.Point(12, 255)
        chkHeight.Name = "chkHeight"
        chkHeight.Size = New System.Drawing.Size(62, 18)
        chkHeight.TabIndex = 2
        chkHeight.Text = "Height"
        chkHeight.UseVisualStyleBackColor = True
        '
        'chkWidth
        '
        chkWidth.AutoSize = True
        chkWidth.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        chkWidth.Location = New System.Drawing.Point(12, 305)
        chkWidth.Name = "chkWidth"
        chkWidth.Size = New System.Drawing.Size(59, 18)
        chkWidth.TabIndex = 2
        chkWidth.Text = "Width"
        chkWidth.UseVisualStyleBackColor = True
        '
        'chkLength
        '
        chkLength.AutoSize = True
        chkLength.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        chkLength.Location = New System.Drawing.Point(12, 351)
        chkLength.Name = "chkLength"
        chkLength.Size = New System.Drawing.Size(62, 18)
        chkLength.TabIndex = 2
        chkLength.Text = "Length"
        chkLength.UseVisualStyleBackColor = True
        '
        'chkComments
        '
        chkComments.AutoSize = True
        chkComments.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        chkComments.Location = New System.Drawing.Point(12, 402)
        chkComments.Name = "chkComments"
        chkComments.Size = New System.Drawing.Size(83, 18)
        chkComments.TabIndex = 2
        chkComments.Text = "Comments"
        chkComments.UseVisualStyleBackColor = True
        '
        'lblDisplayed
        '
        lblDisplayed.AutoSize = True
        lblDisplayed.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblDisplayed.Location = New System.Drawing.Point(9, 9)
        lblDisplayed.Name = "lblDisplayed"
        lblDisplayed.Size = New System.Drawing.Size(123, 18)
        lblDisplayed.TabIndex = 3
        lblDisplayed.Text = "Displayed on Form"
        '
        'lblDefaultValue
        '
        lblDefaultValue.AutoSize = True
        lblDefaultValue.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblDefaultValue.Location = New System.Drawing.Point(153, 9)
        lblDefaultValue.Name = "lblDefaultValue"
        lblDefaultValue.Size = New System.Drawing.Size(93, 18)
        lblDefaultValue.TabIndex = 3
        lblDefaultValue.Text = "Default Value"
        '
        'txtRangeValue
        '
        txtRangeValue.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtRangeValue.Location = New System.Drawing.Point(156, 60)
        txtRangeValue.Name = "txtRangeValue"
        txtRangeValue.Size = New System.Drawing.Size(76, 22)
        txtRangeValue.TabIndex = 4
        '
        'cboIDConfidence
        '
        cboIDConfidence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cboIDConfidence.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cboIDConfidence.FormattingEnabled = True
        cboIDConfidence.Location = New System.Drawing.Point(156, 110)
        cboIDConfidence.Name = "cboIDConfidence"
        cboIDConfidence.Size = New System.Drawing.Size(170, 22)
        cboIDConfidence.TabIndex = 8
        '
        'cboAbundance
        '
        cboAbundance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cboAbundance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cboAbundance.FormattingEnabled = True
        cboAbundance.Location = New System.Drawing.Point(156, 159)
        cboAbundance.Name = "cboAbundance"
        cboAbundance.Size = New System.Drawing.Size(170, 22)
        cboAbundance.TabIndex = 8
        '
        'txtCount
        '
        txtCount.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtCount.Location = New System.Drawing.Point(156, 204)
        txtCount.Name = "txtCount"
        txtCount.Size = New System.Drawing.Size(170, 22)
        txtCount.TabIndex = 4
        '
        'txtHeight
        '
        txtHeight.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtHeight.Location = New System.Drawing.Point(156, 253)
        txtHeight.Name = "txtHeight"
        txtHeight.Size = New System.Drawing.Size(170, 22)
        txtHeight.TabIndex = 4
        '
        'txtWidth
        '
        txtWidth.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtWidth.Location = New System.Drawing.Point(156, 302)
        txtWidth.Name = "txtWidth"
        txtWidth.Size = New System.Drawing.Size(170, 22)
        txtWidth.TabIndex = 4
        '
        'txtLength
        '
        txtLength.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtLength.Location = New System.Drawing.Point(156, 348)
        txtLength.Name = "txtLength"
        txtLength.Size = New System.Drawing.Size(170, 22)
        txtLength.TabIndex = 4
        '
        'txtComments
        '
        txtComments.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtComments.Location = New System.Drawing.Point(156, 400)
        txtComments.Name = "txtComments"
        txtComments.Size = New System.Drawing.Size(170, 79)
        txtComments.TabIndex = 9
        txtComments.Text = ""
        '
        'cmdOK
        '
        cmdOK.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdOK.Location = New System.Drawing.Point(53, 519)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(109, 31)
        cmdOK.TabIndex = 10
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        cmdCancel.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdCancel.Location = New System.Drawing.Point(168, 519)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New System.Drawing.Size(109, 31)
        cmdCancel.TabIndex = 10
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        '
        'cboSide
        '
        cboSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cboSide.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cboSide.FormattingEnabled = True
        cboSide.Location = New System.Drawing.Point(238, 60)
        cboSide.Name = "cboSide"
        cboSide.Size = New System.Drawing.Size(88, 22)
        cboSide.TabIndex = 11
        '
        'lblSide
        '
        lblSide.AutoSize = True
        lblSide.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblSide.Location = New System.Drawing.Point(235, 44)
        lblSide.Name = "lblSide"
        lblSide.Size = New System.Drawing.Size(31, 14)
        lblSide.TabIndex = 3
        lblSide.Text = "Side"
        '
        'lblLRangeValue
        '
        lblLRangeValue.AutoSize = True
        lblLRangeValue.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblLRangeValue.Location = New System.Drawing.Point(153, 44)
        lblLRangeValue.Name = "lblLRangeValue"
        lblLRangeValue.Size = New System.Drawing.Size(76, 14)
        lblLRangeValue.TabIndex = 3
        lblLRangeValue.Text = "Range Value"
        '
        'frmConfigureSpecies
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(345, 573)
        ControlBox = False
        Controls.Add(cboSide)
        Controls.Add(cmdCancel)
        Controls.Add(cmdOK)
        Controls.Add(txtComments)
        Controls.Add(cboAbundance)
        Controls.Add(cboIDConfidence)
        Controls.Add(txtLength)
        Controls.Add(txtWidth)
        Controls.Add(txtHeight)
        Controls.Add(txtCount)
        Controls.Add(txtRangeValue)
        Controls.Add(lblSide)
        Controls.Add(lblLRangeValue)
        Controls.Add(lblDefaultValue)
        Controls.Add(lblDisplayed)
        Controls.Add(chkComments)
        Controls.Add(chkLength)
        Controls.Add(chkWidth)
        Controls.Add(chkHeight)
        Controls.Add(chkCount)
        Controls.Add(chkAbundance)
        Controls.Add(chkIDConfidence)
        Controls.Add(chkRange)
        Name = "frmConfigureSpecies"
        Text = "Configure Species Event"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents chkRange As System.Windows.Forms.CheckBox
    Friend WithEvents chkIDConfidence As System.Windows.Forms.CheckBox
    Friend WithEvents chkAbundance As System.Windows.Forms.CheckBox
    Friend WithEvents chkCount As System.Windows.Forms.CheckBox
    Friend WithEvents chkHeight As System.Windows.Forms.CheckBox
    Friend WithEvents chkWidth As System.Windows.Forms.CheckBox
    Friend WithEvents chkLength As System.Windows.Forms.CheckBox
    Friend WithEvents chkComments As System.Windows.Forms.CheckBox
    Friend WithEvents lblDisplayed As System.Windows.Forms.Label
    Friend WithEvents lblDefaultValue As System.Windows.Forms.Label
    Friend WithEvents txtRangeValue As System.Windows.Forms.TextBox
    Friend WithEvents cboIDConfidence As System.Windows.Forms.ComboBox
    Friend WithEvents cboAbundance As System.Windows.Forms.ComboBox
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtLength As System.Windows.Forms.TextBox
    Friend WithEvents txtComments As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboSide As System.Windows.Forms.ComboBox
    Friend WithEvents lblSide As System.Windows.Forms.Label
    Friend WithEvents lblLRangeValue As System.Windows.Forms.Label
End Class
