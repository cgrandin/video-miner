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
        Me.chkRange = New System.Windows.Forms.CheckBox
        Me.chkIDConfidence = New System.Windows.Forms.CheckBox
        Me.chkAbundance = New System.Windows.Forms.CheckBox
        Me.chkCount = New System.Windows.Forms.CheckBox
        Me.chkHeight = New System.Windows.Forms.CheckBox
        Me.chkWidth = New System.Windows.Forms.CheckBox
        Me.chkLength = New System.Windows.Forms.CheckBox
        Me.chkComments = New System.Windows.Forms.CheckBox
        Me.lblDisplayed = New System.Windows.Forms.Label
        Me.lblDefaultValue = New System.Windows.Forms.Label
        Me.txtRangeValue = New System.Windows.Forms.TextBox
        Me.cboIDConfidence = New System.Windows.Forms.ComboBox
        Me.cboAbundance = New System.Windows.Forms.ComboBox
        Me.txtCount = New System.Windows.Forms.TextBox
        Me.txtHeight = New System.Windows.Forms.TextBox
        Me.txtWidth = New System.Windows.Forms.TextBox
        Me.txtLength = New System.Windows.Forms.TextBox
        Me.txtComments = New System.Windows.Forms.RichTextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cboSide = New System.Windows.Forms.ComboBox
        Me.lblSide = New System.Windows.Forms.Label
        Me.lblLRangeValue = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'chkRange
        '
        Me.chkRange.AutoSize = True
        Me.chkRange.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRange.Location = New System.Drawing.Point(12, 60)
        Me.chkRange.Name = "chkRange"
        Me.chkRange.Size = New System.Drawing.Size(60, 18)
        Me.chkRange.TabIndex = 2
        Me.chkRange.Text = "Range"
        Me.chkRange.UseVisualStyleBackColor = True
        '
        'chkIDConfidence
        '
        Me.chkIDConfidence.AutoSize = True
        Me.chkIDConfidence.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIDConfidence.Location = New System.Drawing.Point(12, 114)
        Me.chkIDConfidence.Name = "chkIDConfidence"
        Me.chkIDConfidence.Size = New System.Drawing.Size(102, 18)
        Me.chkIDConfidence.TabIndex = 2
        Me.chkIDConfidence.Text = "ID Confidence"
        Me.chkIDConfidence.UseVisualStyleBackColor = True
        '
        'chkAbundance
        '
        Me.chkAbundance.AutoSize = True
        Me.chkAbundance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAbundance.Location = New System.Drawing.Point(12, 159)
        Me.chkAbundance.Name = "chkAbundance"
        Me.chkAbundance.Size = New System.Drawing.Size(87, 18)
        Me.chkAbundance.TabIndex = 2
        Me.chkAbundance.Text = "Abundance"
        Me.chkAbundance.UseVisualStyleBackColor = True
        '
        'chkCount
        '
        Me.chkCount.AutoSize = True
        Me.chkCount.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCount.Location = New System.Drawing.Point(12, 206)
        Me.chkCount.Name = "chkCount"
        Me.chkCount.Size = New System.Drawing.Size(57, 18)
        Me.chkCount.TabIndex = 2
        Me.chkCount.Text = "Count"
        Me.chkCount.UseVisualStyleBackColor = True
        '
        'chkHeight
        '
        Me.chkHeight.AutoSize = True
        Me.chkHeight.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHeight.Location = New System.Drawing.Point(12, 255)
        Me.chkHeight.Name = "chkHeight"
        Me.chkHeight.Size = New System.Drawing.Size(62, 18)
        Me.chkHeight.TabIndex = 2
        Me.chkHeight.Text = "Height"
        Me.chkHeight.UseVisualStyleBackColor = True
        '
        'chkWidth
        '
        Me.chkWidth.AutoSize = True
        Me.chkWidth.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWidth.Location = New System.Drawing.Point(12, 305)
        Me.chkWidth.Name = "chkWidth"
        Me.chkWidth.Size = New System.Drawing.Size(59, 18)
        Me.chkWidth.TabIndex = 2
        Me.chkWidth.Text = "Width"
        Me.chkWidth.UseVisualStyleBackColor = True
        '
        'chkLength
        '
        Me.chkLength.AutoSize = True
        Me.chkLength.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLength.Location = New System.Drawing.Point(12, 351)
        Me.chkLength.Name = "chkLength"
        Me.chkLength.Size = New System.Drawing.Size(62, 18)
        Me.chkLength.TabIndex = 2
        Me.chkLength.Text = "Length"
        Me.chkLength.UseVisualStyleBackColor = True
        '
        'chkComments
        '
        Me.chkComments.AutoSize = True
        Me.chkComments.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkComments.Location = New System.Drawing.Point(12, 402)
        Me.chkComments.Name = "chkComments"
        Me.chkComments.Size = New System.Drawing.Size(83, 18)
        Me.chkComments.TabIndex = 2
        Me.chkComments.Text = "Comments"
        Me.chkComments.UseVisualStyleBackColor = True
        '
        'lblDisplayed
        '
        Me.lblDisplayed.AutoSize = True
        Me.lblDisplayed.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayed.Location = New System.Drawing.Point(9, 9)
        Me.lblDisplayed.Name = "lblDisplayed"
        Me.lblDisplayed.Size = New System.Drawing.Size(123, 18)
        Me.lblDisplayed.TabIndex = 3
        Me.lblDisplayed.Text = "Displayed on Form"
        '
        'lblDefaultValue
        '
        Me.lblDefaultValue.AutoSize = True
        Me.lblDefaultValue.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultValue.Location = New System.Drawing.Point(153, 9)
        Me.lblDefaultValue.Name = "lblDefaultValue"
        Me.lblDefaultValue.Size = New System.Drawing.Size(93, 18)
        Me.lblDefaultValue.TabIndex = 3
        Me.lblDefaultValue.Text = "Default Value"
        '
        'txtRangeValue
        '
        Me.txtRangeValue.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRangeValue.Location = New System.Drawing.Point(156, 60)
        Me.txtRangeValue.Name = "txtRangeValue"
        Me.txtRangeValue.Size = New System.Drawing.Size(76, 22)
        Me.txtRangeValue.TabIndex = 4
        '
        'cboIDConfidence
        '
        Me.cboIDConfidence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIDConfidence.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIDConfidence.FormattingEnabled = True
        Me.cboIDConfidence.Location = New System.Drawing.Point(156, 110)
        Me.cboIDConfidence.Name = "cboIDConfidence"
        Me.cboIDConfidence.Size = New System.Drawing.Size(170, 22)
        Me.cboIDConfidence.TabIndex = 8
        '
        'cboAbundance
        '
        Me.cboAbundance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAbundance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAbundance.FormattingEnabled = True
        Me.cboAbundance.Location = New System.Drawing.Point(156, 159)
        Me.cboAbundance.Name = "cboAbundance"
        Me.cboAbundance.Size = New System.Drawing.Size(170, 22)
        Me.cboAbundance.TabIndex = 8
        '
        'txtCount
        '
        Me.txtCount.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCount.Location = New System.Drawing.Point(156, 204)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(170, 22)
        Me.txtCount.TabIndex = 4
        '
        'txtHeight
        '
        Me.txtHeight.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.Location = New System.Drawing.Point(156, 253)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(170, 22)
        Me.txtHeight.TabIndex = 4
        '
        'txtWidth
        '
        Me.txtWidth.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWidth.Location = New System.Drawing.Point(156, 302)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(170, 22)
        Me.txtWidth.TabIndex = 4
        '
        'txtLength
        '
        Me.txtLength.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLength.Location = New System.Drawing.Point(156, 348)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(170, 22)
        Me.txtLength.TabIndex = 4
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.Location = New System.Drawing.Point(156, 400)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(170, 79)
        Me.txtComments.TabIndex = 9
        Me.txtComments.Text = ""
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(53, 519)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(109, 31)
        Me.cmdOK.TabIndex = 10
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(168, 519)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(109, 31)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cboSide
        '
        Me.cboSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSide.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSide.FormattingEnabled = True
        Me.cboSide.Location = New System.Drawing.Point(238, 60)
        Me.cboSide.Name = "cboSide"
        Me.cboSide.Size = New System.Drawing.Size(88, 22)
        Me.cboSide.TabIndex = 11
        '
        'lblSide
        '
        Me.lblSide.AutoSize = True
        Me.lblSide.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSide.Location = New System.Drawing.Point(235, 44)
        Me.lblSide.Name = "lblSide"
        Me.lblSide.Size = New System.Drawing.Size(31, 14)
        Me.lblSide.TabIndex = 3
        Me.lblSide.Text = "Side"
        '
        'lblLRangeValue
        '
        Me.lblLRangeValue.AutoSize = True
        Me.lblLRangeValue.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLRangeValue.Location = New System.Drawing.Point(153, 44)
        Me.lblLRangeValue.Name = "lblLRangeValue"
        Me.lblLRangeValue.Size = New System.Drawing.Size(76, 14)
        Me.lblLRangeValue.TabIndex = 3
        Me.lblLRangeValue.Text = "Range Value"
        '
        'frmConfigureSpecies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 573)
        Me.ControlBox = False
        Me.Controls.Add(Me.cboSide)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.cboAbundance)
        Me.Controls.Add(Me.cboIDConfidence)
        Me.Controls.Add(Me.txtLength)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.txtHeight)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.txtRangeValue)
        Me.Controls.Add(Me.lblSide)
        Me.Controls.Add(Me.lblLRangeValue)
        Me.Controls.Add(Me.lblDefaultValue)
        Me.Controls.Add(Me.lblDisplayed)
        Me.Controls.Add(Me.chkComments)
        Me.Controls.Add(Me.chkLength)
        Me.Controls.Add(Me.chkWidth)
        Me.Controls.Add(Me.chkHeight)
        Me.Controls.Add(Me.chkCount)
        Me.Controls.Add(Me.chkAbundance)
        Me.Controls.Add(Me.chkIDConfidence)
        Me.Controls.Add(Me.chkRange)
        Me.Name = "frmConfigureSpecies"
        Me.Text = "Configure Species Event"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
