<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddButton
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
        lblButtonText = New System.Windows.Forms.Label
        lblTableName = New System.Windows.Forms.Label
        lblDataCode = New System.Windows.Forms.Label
        lblFieldName = New System.Windows.Forms.Label
        txtButtonName = New System.Windows.Forms.TextBox
        cboTables = New System.Windows.Forms.ComboBox
        cmdCreateNewTable = New System.Windows.Forms.Button
        txtDataCode = New System.Windows.Forms.TextBox
        txtFieldName = New System.Windows.Forms.TextBox
        cmdOK = New System.Windows.Forms.Button
        cmdCancel = New System.Windows.Forms.Button
        lblCamelCase = New System.Windows.Forms.Label
        rdUseTable = New System.Windows.Forms.RadioButton
        rdInputValue = New System.Windows.Forms.RadioButton
        SuspendLayout()
        '
        'lblButtonText
        '
        lblButtonText.AutoSize = True
        lblButtonText.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblButtonText.Location = New System.Drawing.Point(12, 9)
        lblButtonText.Name = "lblButtonText"
        lblButtonText.Size = New System.Drawing.Size(142, 15)
        lblButtonText.TabIndex = 0
        lblButtonText.Text = "Text Displayed on Button"
        '
        'lblTableName
        '
        lblTableName.AutoSize = True
        lblTableName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTableName.Location = New System.Drawing.Point(11, 83)
        lblTableName.Name = "lblTableName"
        lblTableName.Size = New System.Drawing.Size(154, 15)
        lblTableName.TabIndex = 0
        lblTableName.Text = "Table Referenced by Button"
        '
        'lblDataCode
        '
        lblDataCode.AutoSize = True
        lblDataCode.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblDataCode.Location = New System.Drawing.Point(12, 131)
        lblDataCode.Name = "lblDataCode"
        lblDataCode.Size = New System.Drawing.Size(63, 15)
        lblDataCode.TabIndex = 0
        lblDataCode.Text = "Data Code"
        '
        'lblFieldName
        '
        lblFieldName.AutoSize = True
        lblFieldName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblFieldName.Location = New System.Drawing.Point(12, 183)
        lblFieldName.Name = "lblFieldName"
        lblFieldName.Size = New System.Drawing.Size(137, 15)
        lblFieldName.TabIndex = 0
        lblFieldName.Text = "Field Name in Database"
        '
        'txtButtonName
        '
        txtButtonName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtButtonName.Location = New System.Drawing.Point(16, 27)
        txtButtonName.MaxLength = 50
        txtButtonName.Name = "txtButtonName"
        txtButtonName.Size = New System.Drawing.Size(100, 23)
        txtButtonName.TabIndex = 1
        '
        'cboTables
        '
        cboTables.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cboTables.FormattingEnabled = True
        cboTables.Location = New System.Drawing.Point(15, 101)
        cboTables.MaxLength = 50
        cboTables.Name = "cboTables"
        cboTables.Size = New System.Drawing.Size(121, 23)
        cboTables.TabIndex = 2
        '
        'cmdCreateNewTable
        '
        cmdCreateNewTable.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdCreateNewTable.Location = New System.Drawing.Point(142, 101)
        cmdCreateNewTable.Name = "cmdCreateNewTable"
        cmdCreateNewTable.Size = New System.Drawing.Size(114, 23)
        cmdCreateNewTable.TabIndex = 3
        cmdCreateNewTable.Text = "Create New Table"
        cmdCreateNewTable.UseVisualStyleBackColor = True
        '
        'txtDataCode
        '
        txtDataCode.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtDataCode.Location = New System.Drawing.Point(15, 147)
        txtDataCode.Name = "txtDataCode"
        txtDataCode.Size = New System.Drawing.Size(100, 23)
        txtDataCode.TabIndex = 4
        '
        'txtFieldName
        '
        txtFieldName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtFieldName.Location = New System.Drawing.Point(15, 199)
        txtFieldName.MaxLength = 50
        txtFieldName.Name = "txtFieldName"
        txtFieldName.Size = New System.Drawing.Size(264, 23)
        txtFieldName.TabIndex = 4
        '
        'cmdOK
        '
        cmdOK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdOK.Location = New System.Drawing.Point(15, 241)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(122, 33)
        cmdOK.TabIndex = 5
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        cmdCancel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdCancel.Location = New System.Drawing.Point(157, 241)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New System.Drawing.Size(122, 33)
        cmdCancel.TabIndex = 5
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        '
        'lblCamelCase
        '
        lblCamelCase.AutoSize = True
        lblCamelCase.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblCamelCase.Location = New System.Drawing.Point(150, 183)
        lblCamelCase.Name = "lblCamelCase"
        lblCamelCase.Size = New System.Drawing.Size(128, 15)
        lblCamelCase.TabIndex = 0
        lblCamelCase.Text = "(CamelCase no spaces)"
        '
        'rdUseTable
        '
        rdUseTable.AutoSize = True
        rdUseTable.Location = New System.Drawing.Point(14, 63)
        rdUseTable.Name = "rdUseTable"
        rdUseTable.Size = New System.Drawing.Size(113, 17)
        rdUseTable.TabIndex = 6
        rdUseTable.TabStop = True
        rdUseTable.Text = "Use Lookup Table"
        rdUseTable.UseVisualStyleBackColor = True
        '
        'rdInputValue
        '
        rdInputValue.AutoSize = True
        rdInputValue.Location = New System.Drawing.Point(133, 63)
        rdInputValue.Name = "rdInputValue"
        rdInputValue.Size = New System.Drawing.Size(117, 17)
        rdInputValue.TabIndex = 6
        rdInputValue.TabStop = True
        rdInputValue.Text = "User Entered Value"
        rdInputValue.UseVisualStyleBackColor = True
        '
        'frmAddButton
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(300, 298)
        Controls.Add(rdInputValue)
        Controls.Add(rdUseTable)
        Controls.Add(lblCamelCase)
        Controls.Add(lblFieldName)
        Controls.Add(cmdCancel)
        Controls.Add(cmdOK)
        Controls.Add(txtFieldName)
        Controls.Add(txtDataCode)
        Controls.Add(cmdCreateNewTable)
        Controls.Add(cboTables)
        Controls.Add(txtButtonName)
        Controls.Add(lblDataCode)
        Controls.Add(lblTableName)
        Controls.Add(lblButtonText)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmAddButton"
        Text = "Add Button"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents lblButtonText As System.Windows.Forms.Label
    Friend WithEvents lblTableName As System.Windows.Forms.Label
    Friend WithEvents lblDataCode As System.Windows.Forms.Label
    Friend WithEvents lblFieldName As System.Windows.Forms.Label
    Friend WithEvents txtButtonName As System.Windows.Forms.TextBox
    Friend WithEvents cboTables As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCreateNewTable As System.Windows.Forms.Button
    Friend WithEvents txtDataCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFieldName As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblCamelCase As System.Windows.Forms.Label
    Friend WithEvents rdUseTable As System.Windows.Forms.RadioButton
    Friend WithEvents rdInputValue As System.Windows.Forms.RadioButton
End Class
