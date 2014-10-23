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
        Me.lblButtonText = New System.Windows.Forms.Label
        Me.lblTableName = New System.Windows.Forms.Label
        Me.lblDataCode = New System.Windows.Forms.Label
        Me.lblFieldName = New System.Windows.Forms.Label
        Me.txtButtonName = New System.Windows.Forms.TextBox
        Me.cboTables = New System.Windows.Forms.ComboBox
        Me.cmdCreateNewTable = New System.Windows.Forms.Button
        Me.txtDataCode = New System.Windows.Forms.TextBox
        Me.txtFieldName = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblCamelCase = New System.Windows.Forms.Label
        Me.rdUseTable = New System.Windows.Forms.RadioButton
        Me.rdInputValue = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'lblButtonText
        '
        Me.lblButtonText.AutoSize = True
        Me.lblButtonText.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblButtonText.Location = New System.Drawing.Point(12, 9)
        Me.lblButtonText.Name = "lblButtonText"
        Me.lblButtonText.Size = New System.Drawing.Size(142, 15)
        Me.lblButtonText.TabIndex = 0
        Me.lblButtonText.Text = "Text Displayed on Button"
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableName.Location = New System.Drawing.Point(11, 83)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(154, 15)
        Me.lblTableName.TabIndex = 0
        Me.lblTableName.Text = "Table Referenced by Button"
        '
        'lblDataCode
        '
        Me.lblDataCode.AutoSize = True
        Me.lblDataCode.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataCode.Location = New System.Drawing.Point(12, 131)
        Me.lblDataCode.Name = "lblDataCode"
        Me.lblDataCode.Size = New System.Drawing.Size(63, 15)
        Me.lblDataCode.TabIndex = 0
        Me.lblDataCode.Text = "Data Code"
        '
        'lblFieldName
        '
        Me.lblFieldName.AutoSize = True
        Me.lblFieldName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFieldName.Location = New System.Drawing.Point(12, 183)
        Me.lblFieldName.Name = "lblFieldName"
        Me.lblFieldName.Size = New System.Drawing.Size(137, 15)
        Me.lblFieldName.TabIndex = 0
        Me.lblFieldName.Text = "Field Name in Database"
        '
        'txtButtonName
        '
        Me.txtButtonName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtButtonName.Location = New System.Drawing.Point(16, 27)
        Me.txtButtonName.MaxLength = 50
        Me.txtButtonName.Name = "txtButtonName"
        Me.txtButtonName.Size = New System.Drawing.Size(100, 23)
        Me.txtButtonName.TabIndex = 1
        '
        'cboTables
        '
        Me.cboTables.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTables.FormattingEnabled = True
        Me.cboTables.Location = New System.Drawing.Point(15, 101)
        Me.cboTables.MaxLength = 50
        Me.cboTables.Name = "cboTables"
        Me.cboTables.Size = New System.Drawing.Size(121, 23)
        Me.cboTables.TabIndex = 2
        '
        'cmdCreateNewTable
        '
        Me.cmdCreateNewTable.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreateNewTable.Location = New System.Drawing.Point(142, 101)
        Me.cmdCreateNewTable.Name = "cmdCreateNewTable"
        Me.cmdCreateNewTable.Size = New System.Drawing.Size(114, 23)
        Me.cmdCreateNewTable.TabIndex = 3
        Me.cmdCreateNewTable.Text = "Create New Table"
        Me.cmdCreateNewTable.UseVisualStyleBackColor = True
        '
        'txtDataCode
        '
        Me.txtDataCode.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataCode.Location = New System.Drawing.Point(15, 147)
        Me.txtDataCode.Name = "txtDataCode"
        Me.txtDataCode.Size = New System.Drawing.Size(100, 23)
        Me.txtDataCode.TabIndex = 4
        '
        'txtFieldName
        '
        Me.txtFieldName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFieldName.Location = New System.Drawing.Point(15, 199)
        Me.txtFieldName.MaxLength = 50
        Me.txtFieldName.Name = "txtFieldName"
        Me.txtFieldName.Size = New System.Drawing.Size(264, 23)
        Me.txtFieldName.TabIndex = 4
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(15, 241)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(122, 33)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(157, 241)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(122, 33)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblCamelCase
        '
        Me.lblCamelCase.AutoSize = True
        Me.lblCamelCase.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamelCase.Location = New System.Drawing.Point(150, 183)
        Me.lblCamelCase.Name = "lblCamelCase"
        Me.lblCamelCase.Size = New System.Drawing.Size(128, 15)
        Me.lblCamelCase.TabIndex = 0
        Me.lblCamelCase.Text = "(CamelCase no spaces)"
        '
        'rdUseTable
        '
        Me.rdUseTable.AutoSize = True
        Me.rdUseTable.Location = New System.Drawing.Point(14, 63)
        Me.rdUseTable.Name = "rdUseTable"
        Me.rdUseTable.Size = New System.Drawing.Size(113, 17)
        Me.rdUseTable.TabIndex = 6
        Me.rdUseTable.TabStop = True
        Me.rdUseTable.Text = "Use Lookup Table"
        Me.rdUseTable.UseVisualStyleBackColor = True
        '
        'rdInputValue
        '
        Me.rdInputValue.AutoSize = True
        Me.rdInputValue.Location = New System.Drawing.Point(133, 63)
        Me.rdInputValue.Name = "rdInputValue"
        Me.rdInputValue.Size = New System.Drawing.Size(117, 17)
        Me.rdInputValue.TabIndex = 6
        Me.rdInputValue.TabStop = True
        Me.rdInputValue.Text = "User Entered Value"
        Me.rdInputValue.UseVisualStyleBackColor = True
        '
        'frmAddButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 298)
        Me.Controls.Add(Me.rdInputValue)
        Me.Controls.Add(Me.rdUseTable)
        Me.Controls.Add(Me.lblCamelCase)
        Me.Controls.Add(Me.lblFieldName)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtFieldName)
        Me.Controls.Add(Me.txtDataCode)
        Me.Controls.Add(Me.cmdCreateNewTable)
        Me.Controls.Add(Me.cboTables)
        Me.Controls.Add(Me.txtButtonName)
        Me.Controls.Add(Me.lblDataCode)
        Me.Controls.Add(Me.lblTableName)
        Me.Controls.Add(Me.lblButtonText)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddButton"
        Me.Text = "Add Button"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
