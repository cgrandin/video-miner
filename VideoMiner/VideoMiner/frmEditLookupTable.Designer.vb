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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.grdEditTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cancel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.Location = New System.Drawing.Point(401, 0)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(105, 41)
        Me.Cancel.TabIndex = 21
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdOK.Enabled = False
        Me.cmdOK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(0, 0)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(105, 41)
        Me.cmdOK.TabIndex = 20
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdDeleteRecord
        '
        Me.cmdDeleteRecord.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteRecord.Enabled = False
        Me.cmdDeleteRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteRecord.Location = New System.Drawing.Point(3, 35)
        Me.cmdDeleteRecord.Name = "cmdDeleteRecord"
        Me.cmdDeleteRecord.Size = New System.Drawing.Size(116, 23)
        Me.cmdDeleteRecord.TabIndex = 18
        Me.cmdDeleteRecord.Text = "Delete Record"
        Me.cmdDeleteRecord.UseVisualStyleBackColor = True
        '
        'cmdAddRecord
        '
        Me.cmdAddRecord.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddRecord.Enabled = False
        Me.cmdAddRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddRecord.Location = New System.Drawing.Point(3, 3)
        Me.cmdAddRecord.Name = "cmdAddRecord"
        Me.cmdAddRecord.Size = New System.Drawing.Size(119, 26)
        Me.cmdAddRecord.TabIndex = 17
        Me.cmdAddRecord.Text = "Add Record"
        Me.cmdAddRecord.UseVisualStyleBackColor = True
        '
        'grdEditTable
        '
        Me.grdEditTable.AllowUserToAddRows = False
        Me.grdEditTable.AllowUserToDeleteRows = False
        Me.grdEditTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdEditTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEditTable.Enabled = False
        Me.grdEditTable.Location = New System.Drawing.Point(3, 59)
        Me.grdEditTable.Name = "grdEditTable"
        Me.grdEditTable.Size = New System.Drawing.Size(506, 462)
        Me.grdEditTable.TabIndex = 19
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTableName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableName.Location = New System.Drawing.Point(3, 13)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(506, 15)
        Me.lblTableName.TabIndex = 14
        Me.lblTableName.Text = "Lookup Table:"
        '
        'cboLookupTable
        '
        Me.cboLookupTable.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboLookupTable.FormattingEnabled = True
        Me.cboLookupTable.Location = New System.Drawing.Point(3, 31)
        Me.cboLookupTable.Name = "cboLookupTable"
        Me.cboLookupTable.Size = New System.Drawing.Size(506, 21)
        Me.cboLookupTable.TabIndex = 23
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdit.Location = New System.Drawing.Point(515, 31)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(122, 22)
        Me.cmdEdit.TabIndex = 16
        Me.cmdEdit.Text = "Edit Table"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grdEditTable, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLookupTable, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdEdit, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTableName, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(640, 571)
        Me.TableLayoutPanel1.TabIndex = 24
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdAddRecord)
        Me.Panel1.Controls.Add(Me.cmdDeleteRecord)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(515, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(122, 462)
        Me.Panel1.TabIndex = 24
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmdOK)
        Me.Panel2.Controls.Add(Me.Cancel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 527)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(506, 41)
        Me.Panel2.TabIndex = 25
        '
        'frmEditLookupTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 571)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEditLookupTable"
        Me.Text = "Edit lookup table"
        CType(Me.grdEditTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteRecord As System.Windows.Forms.Button
    Friend WithEvents cmdAddRecord As System.Windows.Forms.Button
    Friend WithEvents grdEditTable As System.Windows.Forms.DataGridView
    Friend WithEvents lblTableName As System.Windows.Forms.Label
    Friend WithEvents cboLookupTable As System.Windows.Forms.ComboBox
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
