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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddButton))
        Me.lblButtonText = New System.Windows.Forms.Label()
        Me.lblTableName = New System.Windows.Forms.Label()
        Me.lblDataCode = New System.Windows.Forms.Label()
        Me.txtButtonName = New System.Windows.Forms.TextBox()
        Me.cboTables = New System.Windows.Forms.ComboBox()
        Me.txtDataCode = New System.Windows.Forms.TextBox()
        Me.txtFieldName = New System.Windows.Forms.TextBox()
        Me.rdUseTable = New System.Windows.Forms.RadioButton()
        Me.rdInputValue = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFieldName = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.btnViewDataCodes = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblButtonText
        '
        Me.lblButtonText.AutoSize = True
        Me.lblButtonText.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblButtonText.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblButtonText.Location = New System.Drawing.Point(3, 11)
        Me.lblButtonText.Name = "lblButtonText"
        Me.lblButtonText.Size = New System.Drawing.Size(147, 15)
        Me.lblButtonText.TabIndex = 0
        Me.lblButtonText.Text = "Text Displayed on Button"
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTableName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableName.Location = New System.Drawing.Point(3, 98)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(147, 15)
        Me.lblTableName.TabIndex = 0
        Me.lblTableName.Text = "Table Reference"
        '
        'lblDataCode
        '
        Me.lblDataCode.AutoSize = True
        Me.lblDataCode.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblDataCode.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataCode.Location = New System.Drawing.Point(3, 159)
        Me.lblDataCode.Name = "lblDataCode"
        Me.lblDataCode.Size = New System.Drawing.Size(147, 15)
        Me.lblDataCode.TabIndex = 0
        Me.lblDataCode.Text = "Data Code"
        '
        'txtButtonName
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtButtonName, 2)
        Me.txtButtonName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtButtonName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtButtonName.Location = New System.Drawing.Point(3, 29)
        Me.txtButtonName.MaxLength = 50
        Me.txtButtonName.Name = "txtButtonName"
        Me.txtButtonName.Size = New System.Drawing.Size(301, 23)
        Me.txtButtonName.TabIndex = 1
        '
        'cboTables
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboTables, 2)
        Me.cboTables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTables.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTables.FormattingEnabled = True
        Me.cboTables.Location = New System.Drawing.Point(3, 116)
        Me.cboTables.MaxLength = 50
        Me.cboTables.Name = "cboTables"
        Me.cboTables.Size = New System.Drawing.Size(301, 23)
        Me.cboTables.TabIndex = 2
        '
        'txtDataCode
        '
        Me.txtDataCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDataCode.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataCode.Location = New System.Drawing.Point(3, 177)
        Me.txtDataCode.Name = "txtDataCode"
        Me.txtDataCode.Size = New System.Drawing.Size(147, 23)
        Me.txtDataCode.TabIndex = 4
        '
        'txtFieldName
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtFieldName, 2)
        Me.txtFieldName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFieldName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFieldName.Location = New System.Drawing.Point(3, 247)
        Me.txtFieldName.MaxLength = 50
        Me.txtFieldName.Name = "txtFieldName"
        Me.txtFieldName.Size = New System.Drawing.Size(301, 23)
        Me.txtFieldName.TabIndex = 4
        '
        'rdUseTable
        '
        Me.rdUseTable.AutoSize = True
        Me.rdUseTable.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rdUseTable.Location = New System.Drawing.Point(3, 67)
        Me.rdUseTable.Name = "rdUseTable"
        Me.rdUseTable.Size = New System.Drawing.Size(147, 17)
        Me.rdUseTable.TabIndex = 6
        Me.rdUseTable.TabStop = True
        Me.rdUseTable.Text = "Use Lookup Table"
        Me.rdUseTable.UseVisualStyleBackColor = True
        '
        'rdInputValue
        '
        Me.rdInputValue.AutoSize = True
        Me.rdInputValue.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rdInputValue.Location = New System.Drawing.Point(156, 67)
        Me.rdInputValue.Name = "rdInputValue"
        Me.rdInputValue.Size = New System.Drawing.Size(148, 17)
        Me.rdInputValue.TabIndex = 6
        Me.rdInputValue.TabStop = True
        Me.rdInputValue.Text = "User Entered Value"
        Me.rdInputValue.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtButtonName, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblButtonText, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rdInputValue, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFieldName, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.rdUseTable, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTableName, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTables, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDataCode, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDataCode, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFieldName, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.btnViewDataCodes, 1, 6)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.255219!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.16319!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25522!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25522!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.16319!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.25522!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.16319!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.16319!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.16319!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.16319!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(307, 320)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'lblFieldName
        '
        Me.lblFieldName.AutoSize = True
        Me.lblFieldName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblFieldName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFieldName.Location = New System.Drawing.Point(3, 229)
        Me.lblFieldName.Name = "lblFieldName"
        Me.lblFieldName.Size = New System.Drawing.Size(147, 15)
        Me.lblFieldName.TabIndex = 0
        Me.lblFieldName.Text = "Field Name in Database"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cmdOK, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmdCancel, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 282)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(301, 35)
        Me.TableLayoutPanel2.TabIndex = 7
        '
        'cmdOK
        '
        Me.cmdOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdOK.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(5, 3)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(142, 29)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdCancel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(153, 3)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(140, 29)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'btnViewDataCodes
        '
        Me.btnViewDataCodes.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnViewDataCodes.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.btnViewDataCodes.Location = New System.Drawing.Point(156, 177)
        Me.btnViewDataCodes.Name = "btnViewDataCodes"
        Me.btnViewDataCodes.Size = New System.Drawing.Size(148, 23)
        Me.btnViewDataCodes.TabIndex = 8
        Me.btnViewDataCodes.Text = "View data codes"
        Me.btnViewDataCodes.UseVisualStyleBackColor = True
        '
        'frmAddButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 320)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddButton"
        Me.Text = "Add Button"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblButtonText As System.Windows.Forms.Label
    Friend WithEvents lblTableName As System.Windows.Forms.Label
    Friend WithEvents lblDataCode As System.Windows.Forms.Label
    Friend WithEvents txtButtonName As System.Windows.Forms.TextBox
    Friend WithEvents cboTables As System.Windows.Forms.ComboBox
    Friend WithEvents txtDataCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFieldName As System.Windows.Forms.TextBox
    Friend WithEvents rdUseTable As System.Windows.Forms.RadioButton
    Friend WithEvents rdInputValue As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents lblFieldName As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnViewDataCodes As Button
End Class
