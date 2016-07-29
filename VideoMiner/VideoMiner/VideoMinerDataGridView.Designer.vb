<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VideoMinerDataGridView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.grd = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSync = New System.Windows.Forms.Button()
        Me.btnRevert = New System.Windows.Forms.Button()
        Me.lblSync = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDeleteRows = New System.Windows.Forms.Button()
        Me.btnDataCodes = New System.Windows.Forms.Button()
        Me.btnAddRow = New System.Windows.Forms.Button()
        Me.btnMoveDown = New System.Windows.Forms.Button()
        Me.btnMoveUp = New System.Windows.Forms.Button()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grd
        '
        Me.grd.AllowUserToOrderColumns = True
        Me.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.grd, 4)
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Location = New System.Drawing.Point(3, 33)
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(899, 180)
        Me.grd.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grd, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSync, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRevert, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSync, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1005, 216)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnSync
        '
        Me.btnSync.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSync.Location = New System.Drawing.Point(3, 3)
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(194, 24)
        Me.btnSync.TabIndex = 1
        Me.btnSync.Text = "Sync data (save to database)"
        Me.btnSync.UseVisualStyleBackColor = True
        '
        'btnRevert
        '
        Me.btnRevert.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRevert.Location = New System.Drawing.Point(203, 3)
        Me.btnRevert.Name = "btnRevert"
        Me.btnRevert.Size = New System.Drawing.Size(194, 24)
        Me.btnRevert.TabIndex = 2
        Me.btnRevert.Text = "Revert data (reload from database)"
        Me.btnRevert.UseVisualStyleBackColor = True
        '
        'lblSync
        '
        Me.lblSync.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSync.AutoSize = True
        Me.lblSync.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSync.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblSync.Location = New System.Drawing.Point(403, 3)
        Me.lblSync.Name = "lblSync"
        Me.lblSync.Size = New System.Drawing.Size(120, 24)
        Me.lblSync.TabIndex = 3
        Me.lblSync.Text = "Not initialized"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnDeleteRows)
        Me.Panel1.Controls.Add(Me.btnDataCodes)
        Me.Panel1.Controls.Add(Me.btnAddRow)
        Me.Panel1.Controls.Add(Me.btnMoveDown)
        Me.Panel1.Controls.Add(Me.btnMoveUp)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(908, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(94, 180)
        Me.Panel1.TabIndex = 5
        '
        'btnDeleteRows
        '
        Me.btnDeleteRows.Location = New System.Drawing.Point(0, 85)
        Me.btnDeleteRows.Name = "btnDeleteRows"
        Me.btnDeleteRows.Size = New System.Drawing.Size(94, 23)
        Me.btnDeleteRows.TabIndex = 8
        Me.btnDeleteRows.Text = "Delete Rows"
        Me.btnDeleteRows.UseVisualStyleBackColor = True
        '
        'btnDataCodes
        '
        Me.btnDataCodes.Location = New System.Drawing.Point(0, 131)
        Me.btnDataCodes.Name = "btnDataCodes"
        Me.btnDataCodes.Size = New System.Drawing.Size(94, 23)
        Me.btnDataCodes.TabIndex = 7
        Me.btnDataCodes.Text = "Data Codes..."
        Me.btnDataCodes.UseVisualStyleBackColor = True
        '
        'btnAddRow
        '
        Me.btnAddRow.Location = New System.Drawing.Point(0, 58)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Size = New System.Drawing.Size(94, 23)
        Me.btnAddRow.TabIndex = 6
        Me.btnAddRow.Text = "Add Row"
        Me.btnAddRow.UseVisualStyleBackColor = True
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Location = New System.Drawing.Point(0, 31)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(94, 23)
        Me.btnMoveDown.TabIndex = 5
        Me.btnMoveDown.Text = "Move Down"
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Location = New System.Drawing.Point(0, 3)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(94, 23)
        Me.btnMoveUp.TabIndex = 4
        Me.btnMoveUp.Text = "Move Up"
        Me.btnMoveUp.UseVisualStyleBackColor = True
        '
        'VideoMinerDataGridView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "VideoMinerDataGridView"
        Me.Size = New System.Drawing.Size(1005, 216)
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grd As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnSync As Button
    Friend WithEvents btnRevert As Button
    Friend WithEvents lblSync As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnMoveDown As Button
    Friend WithEvents btnMoveUp As Button
    Friend WithEvents btnAddRow As Button
    Friend WithEvents btnDataCodes As Button
    Friend WithEvents btnDeleteRows As Button
End Class
