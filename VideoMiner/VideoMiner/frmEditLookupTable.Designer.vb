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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditLookupTable))
        Me.Cancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdDeleteRecord = New System.Windows.Forms.Button()
        Me.cmdAddRecord = New System.Windows.Forms.Button()
        Me.grdEditTable = New System.Windows.Forms.DataGridView()
        Me.lblTableName = New System.Windows.Forms.Label()
        Me.cboLookupTable = New System.Windows.Forms.ComboBox()
        Me.cmdEdit = New System.Windows.Forms.Button()
        CType(Me.grdEditTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.Location = New System.Drawing.Point(116, 69)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(105, 37)
        Me.Cancel.TabIndex = 21
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Enabled = False
        Me.cmdOK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(5, 69)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(105, 37)
        Me.cmdOK.TabIndex = 20
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdDeleteRecord
        '
        Me.cmdDeleteRecord.Enabled = False
        Me.cmdDeleteRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteRecord.Location = New System.Drawing.Point(346, 83)
        Me.cmdDeleteRecord.Name = "cmdDeleteRecord"
        Me.cmdDeleteRecord.Size = New System.Drawing.Size(113, 23)
        Me.cmdDeleteRecord.TabIndex = 18
        Me.cmdDeleteRecord.Text = "Delete Record"
        Me.cmdDeleteRecord.UseVisualStyleBackColor = True
        '
        'cmdAddRecord
        '
        Me.cmdAddRecord.Enabled = False
        Me.cmdAddRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddRecord.Location = New System.Drawing.Point(227, 83)
        Me.cmdAddRecord.Name = "cmdAddRecord"
        Me.cmdAddRecord.Size = New System.Drawing.Size(113, 23)
        Me.cmdAddRecord.TabIndex = 17
        Me.cmdAddRecord.Text = "Add Record"
        Me.cmdAddRecord.UseVisualStyleBackColor = True
        '
        'grdEditTable
        '
        Me.grdEditTable.AllowUserToAddRows = False
        Me.grdEditTable.AllowUserToDeleteRows = False
        Me.grdEditTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdEditTable.Enabled = False
        Me.grdEditTable.Location = New System.Drawing.Point(5, 112)
        Me.grdEditTable.Name = "grdEditTable"
        Me.grdEditTable.Size = New System.Drawing.Size(636, 272)
        Me.grdEditTable.TabIndex = 19
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableName.Location = New System.Drawing.Point(2, 9)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(81, 15)
        Me.lblTableName.TabIndex = 14
        Me.lblTableName.Text = "Lookup Table:"
        '
        'cboLookupTable
        '
        Me.cboLookupTable.FormattingEnabled = True
        Me.cboLookupTable.Location = New System.Drawing.Point(5, 29)
        Me.cboLookupTable.Name = "cboLookupTable"
        Me.cboLookupTable.Size = New System.Drawing.Size(216, 21)
        Me.cboLookupTable.TabIndex = 23
        '
        'cmdEdit
        '
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdit.Location = New System.Drawing.Point(227, 23)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(113, 27)
        Me.cmdEdit.TabIndex = 16
        Me.cmdEdit.Text = "Edit Table"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'frmEditLookupTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 401)
        Me.Controls.Add(Me.cboLookupTable)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdDeleteRecord)
        Me.Controls.Add(Me.cmdAddRecord)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.grdEditTable)
        Me.Controls.Add(Me.lblTableName)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEditLookupTable"
        Me.Text = "frmEditLookupTable"
        CType(Me.grdEditTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
