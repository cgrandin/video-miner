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
        Me.lblButtonSize = New System.Windows.Forms.Label
        Me.lblButtonHeight = New System.Windows.Forms.Label
        Me.lblButtonWidth = New System.Windows.Forms.Label
        Me.lblButtonText = New System.Windows.Forms.Label
        Me.lblButtonFont = New System.Windows.Forms.Label
        Me.lblButtonTextSize = New System.Windows.Forms.Label
        Me.txtButtonHeight = New System.Windows.Forms.TextBox
        Me.txtButtonWidth = New System.Windows.Forms.TextBox
        Me.cboButtonFont = New System.Windows.Forms.ComboBox
        Me.cboButtonTextSize = New System.Windows.Forms.ComboBox
        Me.lblPreview = New System.Windows.Forms.Label
        Me.cmdPreviewButton = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblButtonSize
        '
        Me.lblButtonSize.AutoSize = True
        Me.lblButtonSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblButtonSize.Location = New System.Drawing.Point(12, 9)
        Me.lblButtonSize.Name = "lblButtonSize"
        Me.lblButtonSize.Size = New System.Drawing.Size(96, 17)
        Me.lblButtonSize.TabIndex = 0
        Me.lblButtonSize.Text = "Button Size:"
        '
        'lblButtonHeight
        '
        Me.lblButtonHeight.AutoSize = True
        Me.lblButtonHeight.Location = New System.Drawing.Point(12, 35)
        Me.lblButtonHeight.Name = "lblButtonHeight"
        Me.lblButtonHeight.Size = New System.Drawing.Size(41, 13)
        Me.lblButtonHeight.TabIndex = 0
        Me.lblButtonHeight.Text = "Height:"
        '
        'lblButtonWidth
        '
        Me.lblButtonWidth.AutoSize = True
        Me.lblButtonWidth.Location = New System.Drawing.Point(12, 61)
        Me.lblButtonWidth.Name = "lblButtonWidth"
        Me.lblButtonWidth.Size = New System.Drawing.Size(38, 13)
        Me.lblButtonWidth.TabIndex = 0
        Me.lblButtonWidth.Text = "Width:"
        '
        'lblButtonText
        '
        Me.lblButtonText.AutoSize = True
        Me.lblButtonText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblButtonText.Location = New System.Drawing.Point(12, 90)
        Me.lblButtonText.Name = "lblButtonText"
        Me.lblButtonText.Size = New System.Drawing.Size(96, 17)
        Me.lblButtonText.TabIndex = 0
        Me.lblButtonText.Text = "Button Text:"
        '
        'lblButtonFont
        '
        Me.lblButtonFont.AutoSize = True
        Me.lblButtonFont.Location = New System.Drawing.Point(12, 113)
        Me.lblButtonFont.Name = "lblButtonFont"
        Me.lblButtonFont.Size = New System.Drawing.Size(31, 13)
        Me.lblButtonFont.TabIndex = 0
        Me.lblButtonFont.Text = "Font:"
        '
        'lblButtonTextSize
        '
        Me.lblButtonTextSize.AutoSize = True
        Me.lblButtonTextSize.Location = New System.Drawing.Point(12, 140)
        Me.lblButtonTextSize.Name = "lblButtonTextSize"
        Me.lblButtonTextSize.Size = New System.Drawing.Size(54, 13)
        Me.lblButtonTextSize.TabIndex = 0
        Me.lblButtonTextSize.Text = "Text Size:"
        '
        'txtButtonHeight
        '
        Me.txtButtonHeight.Location = New System.Drawing.Point(72, 32)
        Me.txtButtonHeight.Name = "txtButtonHeight"
        Me.txtButtonHeight.Size = New System.Drawing.Size(100, 20)
        Me.txtButtonHeight.TabIndex = 1
        '
        'txtButtonWidth
        '
        Me.txtButtonWidth.Location = New System.Drawing.Point(72, 58)
        Me.txtButtonWidth.Name = "txtButtonWidth"
        Me.txtButtonWidth.Size = New System.Drawing.Size(100, 20)
        Me.txtButtonWidth.TabIndex = 1
        '
        'cboButtonFont
        '
        Me.cboButtonFont.FormattingEnabled = True
        Me.cboButtonFont.Location = New System.Drawing.Point(72, 110)
        Me.cboButtonFont.Name = "cboButtonFont"
        Me.cboButtonFont.Size = New System.Drawing.Size(200, 21)
        Me.cboButtonFont.TabIndex = 2
        '
        'cboButtonTextSize
        '
        Me.cboButtonTextSize.FormattingEnabled = True
        Me.cboButtonTextSize.Location = New System.Drawing.Point(72, 137)
        Me.cboButtonTextSize.Name = "cboButtonTextSize"
        Me.cboButtonTextSize.Size = New System.Drawing.Size(100, 21)
        Me.cboButtonTextSize.TabIndex = 2
        '
        'lblPreview
        '
        Me.lblPreview.AutoSize = True
        Me.lblPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreview.Location = New System.Drawing.Point(12, 169)
        Me.lblPreview.Name = "lblPreview"
        Me.lblPreview.Size = New System.Drawing.Size(48, 13)
        Me.lblPreview.TabIndex = 0
        Me.lblPreview.Text = "Preview:"
        '
        'cmdPreviewButton
        '
        Me.cmdPreviewButton.Location = New System.Drawing.Point(15, 185)
        Me.cmdPreviewButton.Name = "cmdPreviewButton"
        Me.cmdPreviewButton.Size = New System.Drawing.Size(75, 23)
        Me.cmdPreviewButton.TabIndex = 3
        Me.cmdPreviewButton.Text = "Button Text"
        Me.cmdPreviewButton.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(56, 259)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(137, 259)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmConfigureButtonFormat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 293)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdPreviewButton)
        Me.Controls.Add(Me.cboButtonTextSize)
        Me.Controls.Add(Me.cboButtonFont)
        Me.Controls.Add(Me.txtButtonWidth)
        Me.Controls.Add(Me.txtButtonHeight)
        Me.Controls.Add(Me.lblButtonWidth)
        Me.Controls.Add(Me.lblButtonHeight)
        Me.Controls.Add(Me.lblPreview)
        Me.Controls.Add(Me.lblButtonTextSize)
        Me.Controls.Add(Me.lblButtonFont)
        Me.Controls.Add(Me.lblButtonText)
        Me.Controls.Add(Me.lblButtonSize)
        Me.MaximizeBox = False
        Me.Name = "frmConfigureButtonFormat"
        Me.ShowIcon = False
        Me.Text = "Configure Button Format"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
