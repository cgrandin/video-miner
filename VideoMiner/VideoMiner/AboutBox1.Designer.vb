<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox1
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

    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox1))
        TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        LogoPictureBox = New System.Windows.Forms.PictureBox()
        LabelProductName = New System.Windows.Forms.Label()
        LabelVersion = New System.Windows.Forms.Label()
        LabelCopyright = New System.Windows.Forms.Label()
        LabelCompanyName = New System.Windows.Forms.Label()
        TextBoxDescription = New System.Windows.Forms.TextBox()
        OKButton = New System.Windows.Forms.Button()
        LinkLabelGithub = New System.Windows.Forms.LinkLabel()
        LinkLabelEmail = New System.Windows.Forms.LinkLabel()
        TableLayoutPanel.SuspendLayout()
        CType(LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'TableLayoutPanel
        '
        TableLayoutPanel.ColumnCount = 2
        TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        TableLayoutPanel.Controls.Add(LogoPictureBox, 0, 0)
        TableLayoutPanel.Controls.Add(LabelProductName, 1, 0)
        TableLayoutPanel.Controls.Add(LabelVersion, 1, 1)
        TableLayoutPanel.Controls.Add(LabelCopyright, 1, 2)
        TableLayoutPanel.Controls.Add(LabelCompanyName, 1, 3)
        TableLayoutPanel.Controls.Add(TextBoxDescription, 1, 4)
        TableLayoutPanel.Controls.Add(OKButton, 1, 5)
        TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        TableLayoutPanel.Location = New System.Drawing.Point(9, 9)
        TableLayoutPanel.Name = "TableLayoutPanel"
        TableLayoutPanel.RowCount = 6
        TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        TableLayoutPanel.Size = New System.Drawing.Size(396, 258)
        TableLayoutPanel.TabIndex = 0
        '
        'LogoPictureBox
        '
        LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        LogoPictureBox.Location = New System.Drawing.Point(3, 3)
        LogoPictureBox.Name = "LogoPictureBox"
        TableLayoutPanel.SetRowSpan(LogoPictureBox, 6)
        LogoPictureBox.Size = New System.Drawing.Size(124, 252)
        LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        LogoPictureBox.TabIndex = 0
        LogoPictureBox.TabStop = False
        '
        'LabelProductName
        '
        LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill
        LabelProductName.Location = New System.Drawing.Point(136, 0)
        LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        LabelProductName.MaximumSize = New System.Drawing.Size(0, 17)
        LabelProductName.Name = "LabelProductName"
        LabelProductName.Size = New System.Drawing.Size(257, 17)
        LabelProductName.TabIndex = 0
        LabelProductName.Text = "Product Name"
        LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelVersion
        '
        LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill
        LabelVersion.Location = New System.Drawing.Point(136, 25)
        LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        LabelVersion.MaximumSize = New System.Drawing.Size(0, 17)
        LabelVersion.Name = "LabelVersion"
        LabelVersion.Size = New System.Drawing.Size(257, 17)
        LabelVersion.TabIndex = 0
        LabelVersion.Text = "Version"
        LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCopyright
        '
        LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
        LabelCopyright.Location = New System.Drawing.Point(136, 50)
        LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        LabelCopyright.MaximumSize = New System.Drawing.Size(0, 17)
        LabelCopyright.Name = "LabelCopyright"
        LabelCopyright.Size = New System.Drawing.Size(257, 17)
        LabelCopyright.TabIndex = 0
        LabelCopyright.Text = "Copyright"
        LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCompanyName
        '
        LabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
        LabelCompanyName.Location = New System.Drawing.Point(136, 75)
        LabelCompanyName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        LabelCompanyName.MaximumSize = New System.Drawing.Size(0, 17)
        LabelCompanyName.Name = "LabelCompanyName"
        LabelCompanyName.Size = New System.Drawing.Size(257, 17)
        LabelCompanyName.TabIndex = 0
        LabelCompanyName.Text = "Company Name"
        LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxDescription
        '
        TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
        TextBoxDescription.Location = New System.Drawing.Point(136, 103)
        TextBoxDescription.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        TextBoxDescription.Multiline = True
        TextBoxDescription.Name = "TextBoxDescription"
        TextBoxDescription.ReadOnly = True
        TextBoxDescription.Size = New System.Drawing.Size(257, 123)
        TextBoxDescription.TabIndex = 0
        TextBoxDescription.TabStop = False
        TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        '
        'OKButton
        '
        OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        OKButton.Location = New System.Drawing.Point(318, 232)
        OKButton.Name = "OKButton"
        OKButton.Size = New System.Drawing.Size(75, 23)
        OKButton.TabIndex = 0
        OKButton.Text = "&OK"
        '
        'LinkLabelGithub
        '
        LinkLabelGithub.AutoSize = True
        LinkLabelGithub.Location = New System.Drawing.Point(146, 237)
        LinkLabelGithub.Name = "LinkLabelGithub"
        LinkLabelGithub.Size = New System.Drawing.Size(119, 13)
        LinkLabelGithub.TabIndex = 1
        LinkLabelGithub.TabStop = True
        LinkLabelGithub.Text = "Source code on GitHub"
        '
        'LinkLabelEmail
        '
        LinkLabelEmail.AutoSize = True
        LinkLabelEmail.Location = New System.Drawing.Point(147, 254)
        LinkLabelEmail.Name = "LinkLabelEmail"
        LinkLabelEmail.Size = New System.Drawing.Size(75, 13)
        LinkLabelEmail.TabIndex = 2
        LinkLabelEmail.TabStop = True
        LinkLabelEmail.Text = "Email designer"
        '
        'AboutBox1
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        CancelButton = OKButton
        ClientSize = New System.Drawing.Size(414, 276)
        Controls.Add(LinkLabelEmail)
        Controls.Add(LinkLabelGithub)
        Controls.Add(TableLayoutPanel)
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "AboutBox1"
        Padding = New System.Windows.Forms.Padding(9)
        ShowInTaskbar = False
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Text = "AboutBox1"
        TableLayoutPanel.ResumeLayout(False)
        TableLayoutPanel.PerformLayout()
        CType(LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents LinkLabelGithub As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabelEmail As System.Windows.Forms.LinkLabel

End Class
