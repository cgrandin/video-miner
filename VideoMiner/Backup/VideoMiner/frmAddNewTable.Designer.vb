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
        Me.lblTableName = New System.Windows.Forms.Label
        Me.grdNewTable = New System.Windows.Forms.DataGridView
        Me.txtTableName = New System.Windows.Forms.TextBox
        Me.cmdCreate = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.cmdAddRecord = New System.Windows.Forms.Button
        Me.cmdDeleteRecord = New System.Windows.Forms.Button
        Me.cmdAddColumn = New System.Windows.Forms.Button
        CType(Me.grdNewTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableName.Location = New System.Drawing.Point(9, 9)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(96, 15)
        Me.lblTableName.TabIndex = 0
        Me.lblTableName.Text = "New Table Name"
        '
        'grdNewTable
        '
        Me.grdNewTable.AllowUserToAddRows = False
        Me.grdNewTable.AllowUserToDeleteRows = False
        Me.grdNewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNewTable.Enabled = False
        Me.grdNewTable.Location = New System.Drawing.Point(12, 112)
        Me.grdNewTable.Name = "grdNewTable"
        Me.grdNewTable.Size = New System.Drawing.Size(636, 272)
        Me.grdNewTable.TabIndex = 10
        '
        'txtTableName
        '
        Me.txtTableName.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableName.Location = New System.Drawing.Point(12, 25)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(151, 27)
        Me.txtTableName.TabIndex = 3
        '
        'cmdCreate
        '
        Me.cmdCreate.Enabled = False
        Me.cmdCreate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreate.Location = New System.Drawing.Point(169, 25)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(113, 27)
        Me.cmdCreate.TabIndex = 4
        Me.cmdCreate.Text = "Create Table"
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Enabled = False
        Me.cmdOK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(12, 69)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(105, 37)
        Me.cmdOK.TabIndex = 11
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.Location = New System.Drawing.Point(123, 69)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(105, 37)
        Me.Cancel.TabIndex = 12
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'cmdAddRecord
        '
        Me.cmdAddRecord.Enabled = False
        Me.cmdAddRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddRecord.Location = New System.Drawing.Point(416, 83)
        Me.cmdAddRecord.Name = "cmdAddRecord"
        Me.cmdAddRecord.Size = New System.Drawing.Size(113, 23)
        Me.cmdAddRecord.TabIndex = 8
        Me.cmdAddRecord.Text = "Add Record"
        Me.cmdAddRecord.UseVisualStyleBackColor = True
        '
        'cmdDeleteRecord
        '
        Me.cmdDeleteRecord.Enabled = False
        Me.cmdDeleteRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteRecord.Location = New System.Drawing.Point(535, 83)
        Me.cmdDeleteRecord.Name = "cmdDeleteRecord"
        Me.cmdDeleteRecord.Size = New System.Drawing.Size(113, 23)
        Me.cmdDeleteRecord.TabIndex = 9
        Me.cmdDeleteRecord.Text = "Delete Record"
        Me.cmdDeleteRecord.UseVisualStyleBackColor = True
        '
        'cmdAddColumn
        '
        Me.cmdAddColumn.Enabled = False
        Me.cmdAddColumn.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddColumn.Location = New System.Drawing.Point(297, 83)
        Me.cmdAddColumn.Name = "cmdAddColumn"
        Me.cmdAddColumn.Size = New System.Drawing.Size(113, 23)
        Me.cmdAddColumn.TabIndex = 13
        Me.cmdAddColumn.Text = "Add Column"
        Me.cmdAddColumn.UseVisualStyleBackColor = True
        '
        'frmAddNewTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 399)
        Me.Controls.Add(Me.cmdAddColumn)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdDeleteRecord)
        Me.Controls.Add(Me.cmdAddRecord)
        Me.Controls.Add(Me.cmdCreate)
        Me.Controls.Add(Me.txtTableName)
        Me.Controls.Add(Me.grdNewTable)
        Me.Controls.Add(Me.lblTableName)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddNewTable"
        Me.Text = "Add New Table"
        CType(Me.grdNewTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
