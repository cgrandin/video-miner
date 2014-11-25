<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigureButtonFormat
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
        lblButtonSize = New System.Windows.Forms.Label
        lblButtonHeight = New System.Windows.Forms.Label
        lblButtonWidth = New System.Windows.Forms.Label
        lblButtonText = New System.Windows.Forms.Label
        lblButtonFont = New System.Windows.Forms.Label
        lblButtonTextSize = New System.Windows.Forms.Label
        txtButtonHeight = New System.Windows.Forms.TextBox
        txtButtonWidth = New System.Windows.Forms.TextBox
        cboButtonFont = New System.Windows.Forms.ComboBox
        cboButtonTextSize = New System.Windows.Forms.ComboBox
        lblPreview = New System.Windows.Forms.Label
        cmdPreviewButton = New System.Windows.Forms.Button
        cmdOK = New System.Windows.Forms.Button
        cmdCancel = New System.Windows.Forms.Button
        SuspendLayout()
        '
        'lblButtonSize
        '
        lblButtonSize.AutoSize = True
        lblButtonSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblButtonSize.Location = New System.Drawing.Point(12, 9)
        lblButtonSize.Name = "lblButtonSize"
        lblButtonSize.Size = New System.Drawing.Size(96, 17)
        lblButtonSize.TabIndex = 0
        lblButtonSize.Text = "Button Size:"
        '
        'lblButtonHeight
        '
        lblButtonHeight.AutoSize = True
        lblButtonHeight.Location = New System.Drawing.Point(12, 35)
        lblButtonHeight.Name = "lblButtonHeight"
        lblButtonHeight.Size = New System.Drawing.Size(41, 13)
        lblButtonHeight.TabIndex = 0
        lblButtonHeight.Text = "Height:"
        '
        'lblButtonWidth
        '
        lblButtonWidth.AutoSize = True
        lblButtonWidth.Location = New System.Drawing.Point(12, 61)
        lblButtonWidth.Name = "lblButtonWidth"
        lblButtonWidth.Size = New System.Drawing.Size(38, 13)
        lblButtonWidth.TabIndex = 0
        lblButtonWidth.Text = "Width:"
        '
        'lblButtonText
        '
        lblButtonText.AutoSize = True
        lblButtonText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblButtonText.Location = New System.Drawing.Point(12, 90)
        lblButtonText.Name = "lblButtonText"
        lblButtonText.Size = New System.Drawing.Size(96, 17)
        lblButtonText.TabIndex = 0
        lblButtonText.Text = "Button Text:"
        '
        'lblButtonFont
        '
        lblButtonFont.AutoSize = True
        lblButtonFont.Location = New System.Drawing.Point(12, 113)
        lblButtonFont.Name = "lblButtonFont"
        lblButtonFont.Size = New System.Drawing.Size(31, 13)
        lblButtonFont.TabIndex = 0
        lblButtonFont.Text = "Font:"
        '
        'lblButtonTextSize
        '
        lblButtonTextSize.AutoSize = True
        lblButtonTextSize.Location = New System.Drawing.Point(12, 140)
        lblButtonTextSize.Name = "lblButtonTextSize"
        lblButtonTextSize.Size = New System.Drawing.Size(54, 13)
        lblButtonTextSize.TabIndex = 0
        lblButtonTextSize.Text = "Text Size:"
        '
        'txtButtonHeight
        '
        txtButtonHeight.Location = New System.Drawing.Point(72, 32)
        txtButtonHeight.Name = "txtButtonHeight"
        txtButtonHeight.Size = New System.Drawing.Size(100, 20)
        txtButtonHeight.TabIndex = 1
        '
        'txtButtonWidth
        '
        txtButtonWidth.Location = New System.Drawing.Point(72, 58)
        txtButtonWidth.Name = "txtButtonWidth"
        txtButtonWidth.Size = New System.Drawing.Size(100, 20)
        txtButtonWidth.TabIndex = 1
        '
        'cboButtonFont
        '
        cboButtonFont.FormattingEnabled = True
        cboButtonFont.Location = New System.Drawing.Point(72, 110)
        cboButtonFont.Name = "cboButtonFont"
        cboButtonFont.Size = New System.Drawing.Size(200, 21)
        cboButtonFont.TabIndex = 2
        '
        'cboButtonTextSize
        '
        cboButtonTextSize.FormattingEnabled = True
        cboButtonTextSize.Location = New System.Drawing.Point(72, 137)
        cboButtonTextSize.Name = "cboButtonTextSize"
        cboButtonTextSize.Size = New System.Drawing.Size(100, 21)
        cboButtonTextSize.TabIndex = 2
        '
        'lblPreview
        '
        lblPreview.AutoSize = True
        lblPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblPreview.Location = New System.Drawing.Point(12, 169)
        lblPreview.Name = "lblPreview"
        lblPreview.Size = New System.Drawing.Size(48, 13)
        lblPreview.TabIndex = 0
        lblPreview.Text = "Preview:"
        '
        'cmdPreviewButton
        '
        cmdPreviewButton.Location = New System.Drawing.Point(15, 185)
        cmdPreviewButton.Name = "cmdPreviewButton"
        cmdPreviewButton.Size = New System.Drawing.Size(75, 23)
        cmdPreviewButton.TabIndex = 3
        cmdPreviewButton.Text = "Button Text"
        cmdPreviewButton.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        cmdOK.Location = New System.Drawing.Point(56, 259)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(75, 23)
        cmdOK.TabIndex = 5
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        cmdCancel.Location = New System.Drawing.Point(137, 259)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New System.Drawing.Size(75, 23)
        cmdCancel.TabIndex = 5
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        '
        'frmConfigureButtonFormat
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(284, 293)
        ControlBox = False
        Controls.Add(cmdCancel)
        Controls.Add(cmdOK)
        Controls.Add(cmdPreviewButton)
        Controls.Add(cboButtonTextSize)
        Controls.Add(cboButtonFont)
        Controls.Add(txtButtonWidth)
        Controls.Add(txtButtonHeight)
        Controls.Add(lblButtonWidth)
        Controls.Add(lblButtonHeight)
        Controls.Add(lblPreview)
        Controls.Add(lblButtonTextSize)
        Controls.Add(lblButtonFont)
        Controls.Add(lblButtonText)
        Controls.Add(lblButtonSize)
        MaximizeBox = False
        Name = "frmConfigureButtonFormat"
        ShowIcon = False
        Text = "Configure Button Format"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents lblButtonSize As System.Windows.Forms.Label
    Friend WithEvents lblButtonHeight As System.Windows.Forms.Label
    Friend WithEvents lblButtonWidth As System.Windows.Forms.Label
    Friend WithEvents lblButtonText As System.Windows.Forms.Label
    Friend WithEvents lblButtonFont As System.Windows.Forms.Label
    Friend WithEvents lblButtonTextSize As System.Windows.Forms.Label
    Friend WithEvents txtButtonHeight As System.Windows.Forms.TextBox
    Friend WithEvents txtButtonWidth As System.Windows.Forms.TextBox
    Friend WithEvents cboButtonFont As System.Windows.Forms.ComboBox
    Friend WithEvents cboButtonTextSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblPreview As System.Windows.Forms.Label
    Friend WithEvents cmdPreviewButton As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
