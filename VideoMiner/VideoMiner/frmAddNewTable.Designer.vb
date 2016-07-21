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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddNewTable))
        Me.lblTableName = New System.Windows.Forms.Label()
        Me.grdNewTable = New System.Windows.Forms.DataGridView()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.cmdCreate = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.cmdAddRecord = New System.Windows.Forms.Button()
        Me.cmdDeleteRecord = New System.Windows.Forms.Button()
        Me.cmdAddColumn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.grdNewTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTableName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableName.Location = New System.Drawing.Point(3, 17)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(549, 15)
        Me.lblTableName.TabIndex = 0
        Me.lblTableName.Text = "New Table Name"
        '
        'grdNewTable
        '
        Me.grdNewTable.AllowUserToAddRows = False
        Me.grdNewTable.AllowUserToDeleteRows = False
        Me.grdNewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNewTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNewTable.Enabled = False
        Me.grdNewTable.Location = New System.Drawing.Point(3, 87)
        Me.grdNewTable.Name = "grdNewTable"
        Me.grdNewTable.Size = New System.Drawing.Size(549, 509)
        Me.grdNewTable.TabIndex = 10
        '
        'txtTableName
        '
        Me.txtTableName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTableName.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableName.Location = New System.Drawing.Point(3, 35)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(549, 27)
        Me.txtTableName.TabIndex = 3
        '
        'cmdCreate
        '
        Me.cmdCreate.Enabled = False
        Me.cmdCreate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreate.Location = New System.Drawing.Point(558, 35)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(90, 26)
        Me.cmdCreate.TabIndex = 4
        Me.cmdCreate.Text = "Create Table"
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdOK.Enabled = False
        Me.cmdOK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(0, 0)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(105, 48)
        Me.cmdOK.TabIndex = 11
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Cancel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.Location = New System.Drawing.Point(444, 0)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(105, 48)
        Me.Cancel.TabIndex = 12
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'cmdAddRecord
        '
        Me.cmdAddRecord.Enabled = False
        Me.cmdAddRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddRecord.Location = New System.Drawing.Point(0, 32)
        Me.cmdAddRecord.Name = "cmdAddRecord"
        Me.cmdAddRecord.Size = New System.Drawing.Size(90, 23)
        Me.cmdAddRecord.TabIndex = 8
        Me.cmdAddRecord.Text = "Add Record"
        Me.cmdAddRecord.UseVisualStyleBackColor = True
        '
        'cmdDeleteRecord
        '
        Me.cmdDeleteRecord.Enabled = False
        Me.cmdDeleteRecord.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteRecord.Location = New System.Drawing.Point(0, 61)
        Me.cmdDeleteRecord.Name = "cmdDeleteRecord"
        Me.cmdDeleteRecord.Size = New System.Drawing.Size(90, 23)
        Me.cmdDeleteRecord.TabIndex = 9
        Me.cmdDeleteRecord.Text = "Delete Record"
        Me.cmdDeleteRecord.UseVisualStyleBackColor = True
        '
        'cmdAddColumn
        '
        Me.cmdAddColumn.Enabled = False
        Me.cmdAddColumn.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddColumn.Location = New System.Drawing.Point(0, 3)
        Me.cmdAddColumn.Name = "cmdAddColumn"
        Me.cmdAddColumn.Size = New System.Drawing.Size(90, 23)
        Me.cmdAddColumn.TabIndex = 13
        Me.cmdAddColumn.Text = "Add Column"
        Me.cmdAddColumn.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtTableName, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grdNewTable, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTableName, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdCreate, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(654, 653)
        Me.TableLayoutPanel1.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdOK)
        Me.Panel1.Controls.Add(Me.Cancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 602)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(549, 48)
        Me.Panel1.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmdDeleteRecord)
        Me.Panel2.Controls.Add(Me.cmdAddColumn)
        Me.Panel2.Controls.Add(Me.cmdAddRecord)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(558, 87)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(93, 509)
        Me.Panel2.TabIndex = 12
        '
        'frmAddNewTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 653)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddNewTable"
        Me.Text = "Add New Table"
        CType(Me.grdNewTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

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
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
