<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditLookupTable
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
        Cancel = New System.Windows.Forms.Button
        cmdOK = New System.Windows.Forms.Button
        cmdDeleteRecord = New System.Windows.Forms.Button
        cmdAddRecord = New System.Windows.Forms.Button
        grdEditTable = New System.Windows.Forms.DataGridView
        lblTableName = New System.Windows.Forms.Label
        cboLookupTable = New System.Windows.Forms.ComboBox
        cmdEdit = New System.Windows.Forms.Button
        CType(grdEditTable, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'Cancel
        '
        Cancel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Cancel.Location = New System.Drawing.Point(116, 69)
        Cancel.Name = "Cancel"
        Cancel.Size = New System.Drawing.Size(105, 37)
        Cancel.TabIndex = 21
        Cancel.Text = "Cancel"
        Cancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        cmdOK.Enabled = False
        cmdOK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdOK.Location = New System.Drawing.Point(5, 69)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(105, 37)
        cmdOK.TabIndex = 20
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'cmdDeleteRecord
        '
        cmdDeleteRecord.Enabled = False
        cmdDeleteRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdDeleteRecord.Location = New System.Drawing.Point(346, 83)
        cmdDeleteRecord.Name = "cmdDeleteRecord"
        cmdDeleteRecord.Size = New System.Drawing.Size(113, 23)
        cmdDeleteRecord.TabIndex = 18
        cmdDeleteRecord.Text = "Delete Record"
        cmdDeleteRecord.UseVisualStyleBackColor = True
        '
        'cmdAddRecord
        '
        cmdAddRecord.Enabled = False
        cmdAddRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdAddRecord.Location = New System.Drawing.Point(227, 83)
        cmdAddRecord.Name = "cmdAddRecord"
        cmdAddRecord.Size = New System.Drawing.Size(113, 23)
        cmdAddRecord.TabIndex = 17
        cmdAddRecord.Text = "Add Record"
        cmdAddRecord.UseVisualStyleBackColor = True
        '
        'grdEditTable
        '
        grdEditTable.AllowUserToAddRows = False
        grdEditTable.AllowUserToDeleteRows = False
        grdEditTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        grdEditTable.Enabled = False
        grdEditTable.Location = New System.Drawing.Point(5, 112)
        grdEditTable.Name = "grdEditTable"
        grdEditTable.Size = New System.Drawing.Size(636, 272)
        grdEditTable.TabIndex = 19
        '
        'lblTableName
        '
        lblTableName.AutoSize = True
        lblTableName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblTableName.Location = New System.Drawing.Point(2, 9)
        lblTableName.Name = "lblTableName"
        lblTableName.Size = New System.Drawing.Size(81, 15)
        lblTableName.TabIndex = 14
        lblTableName.Text = "Lookup Table:"
        '
        'cboLookupTable
        '
        cboLookupTable.FormattingEnabled = True
        cboLookupTable.Location = New System.Drawing.Point(5, 29)
        cboLookupTable.Name = "cboLookupTable"
        cboLookupTable.Size = New System.Drawing.Size(216, 21)
        cboLookupTable.TabIndex = 23
        '
        'cmdEdit
        '
        cmdEdit.Enabled = False
        cmdEdit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cmdEdit.Location = New System.Drawing.Point(227, 23)
        cmdEdit.Name = "cmdEdit"
        cmdEdit.Size = New System.Drawing.Size(113, 27)
        cmdEdit.TabIndex = 16
        cmdEdit.Text = "Edit Table"
        cmdEdit.UseVisualStyleBackColor = True
        '
        'frmEditLookupTable
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(658, 401)
        Controls.Add(cboLookupTable)
        Controls.Add(Cancel)
        Controls.Add(cmdOK)
        Controls.Add(cmdDeleteRecord)
        Controls.Add(cmdAddRecord)
        Controls.Add(cmdEdit)
        Controls.Add(grdEditTable)
        Controls.Add(lblTableName)
        Name = "frmEditLookupTable"
        Text = "frmEditLookupTable"
        CType(grdEditTable, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteRecord As System.Windows.Forms.Button
    Friend WithEvents cmdAddRecord As System.Windows.Forms.Button
    Friend WithEvents grdEditTable As System.Windows.Forms.DataGridView
    Friend WithEvents lblTableName As System.Windows.Forms.Label
    Friend WithEvents cboLookupTable As System.Windows.Forms.ComboBox
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
End Class
