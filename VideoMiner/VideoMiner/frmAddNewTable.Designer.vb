<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddNewTable
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
        lblTableName = New System.Windows.Forms.Label
        grdNewTable = New System.Windows.Forms.DataGridView
        txtTableName = New System.Windows.Forms.TextBox
        cmdCreate = New System.Windows.Forms.Button
        cmdOK = New System.Windows.Forms.Button
        Cancel = New System.Windows.Forms.Button
        cmdAddRecord = New System.Windows.Forms.Button
        cmdDeleteRecord = New System.Windows.Forms.Button
        cmdAddColumn = New System.Windows.Forms.Button
        CType(grdNewTable, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'lblTableName
        '
        lblTableName.AutoSize = True
        lblTableName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTableName.Location = New System.Drawing.Point(9, 9)
        lblTableName.Name = "lblTableName"
        lblTableName.Size = New System.Drawing.Size(96, 15)
        lblTableName.TabIndex = 0
        lblTableName.Text = "New Table Name"
        '
        'grdNewTable
        '
        grdNewTable.AllowUserToAddRows = False
        grdNewTable.AllowUserToDeleteRows = False
        grdNewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        grdNewTable.Enabled = False
        grdNewTable.Location = New System.Drawing.Point(12, 112)
        grdNewTable.Name = "grdNewTable"
        grdNewTable.Size = New System.Drawing.Size(636, 272)
        grdNewTable.TabIndex = 10
        '
        'txtTableName
        '
        txtTableName.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        txtTableName.Location = New System.Drawing.Point(12, 25)
        txtTableName.Name = "txtTableName"
        txtTableName.Size = New System.Drawing.Size(151, 27)
        txtTableName.TabIndex = 3
        '
        'cmdCreate
        '
        cmdCreate.Enabled = False
        cmdCreate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdCreate.Location = New System.Drawing.Point(169, 25)
        cmdCreate.Name = "cmdCreate"
        cmdCreate.Size = New System.Drawing.Size(113, 27)
        cmdCreate.TabIndex = 4
        cmdCreate.Text = "Create Table"
        cmdCreate.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        cmdOK.Enabled = False
        cmdOK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdOK.Location = New System.Drawing.Point(12, 69)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(105, 37)
        cmdOK.TabIndex = 11
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Cancel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Cancel.Location = New System.Drawing.Point(123, 69)
        Cancel.Name = "Cancel"
        Cancel.Size = New System.Drawing.Size(105, 37)
        Cancel.TabIndex = 12
        Cancel.Text = "Cancel"
        Cancel.UseVisualStyleBackColor = True
        '
        'cmdAddRecord
        '
        cmdAddRecord.Enabled = False
        cmdAddRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdAddRecord.Location = New System.Drawing.Point(416, 83)
        cmdAddRecord.Name = "cmdAddRecord"
        cmdAddRecord.Size = New System.Drawing.Size(113, 23)
        cmdAddRecord.TabIndex = 8
        cmdAddRecord.Text = "Add Record"
        cmdAddRecord.UseVisualStyleBackColor = True
        '
        'cmdDeleteRecord
        '
        cmdDeleteRecord.Enabled = False
        cmdDeleteRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdDeleteRecord.Location = New System.Drawing.Point(535, 83)
        cmdDeleteRecord.Name = "cmdDeleteRecord"
        cmdDeleteRecord.Size = New System.Drawing.Size(113, 23)
        cmdDeleteRecord.TabIndex = 9
        cmdDeleteRecord.Text = "Delete Record"
        cmdDeleteRecord.UseVisualStyleBackColor = True
        '
        'cmdAddColumn
        '
        cmdAddColumn.Enabled = False
        cmdAddColumn.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdAddColumn.Location = New System.Drawing.Point(297, 83)
        cmdAddColumn.Name = "cmdAddColumn"
        cmdAddColumn.Size = New System.Drawing.Size(113, 23)
        cmdAddColumn.TabIndex = 13
        cmdAddColumn.Text = "Add Column"
        cmdAddColumn.UseVisualStyleBackColor = True
        '
        'frmAddNewTable
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(660, 399)
        Controls.Add(cmdAddColumn)
        Controls.Add(Cancel)
        Controls.Add(cmdOK)
        Controls.Add(cmdDeleteRecord)
        Controls.Add(cmdAddRecord)
        Controls.Add(cmdCreate)
        Controls.Add(txtTableName)
        Controls.Add(grdNewTable)
        Controls.Add(lblTableName)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmAddNewTable"
        Text = "Add New Table"
        CType(grdNewTable, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents lblTableName As System.Windows.Forms.Label
    Friend WithEvents grdNewTable As System.Windows.Forms.DataGridView
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents cmdCreate As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents cmdAddRecord As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteRecord As System.Windows.Forms.Button
    Friend WithEvents cmdAddColumn As System.Windows.Forms.Button
End Class
