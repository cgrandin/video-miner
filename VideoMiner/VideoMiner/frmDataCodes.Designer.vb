<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataCodes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grdDataCodes = New System.Windows.Forms.DataGridView
        Me.lblDataCode = New System.Windows.Forms.Label
        Me.lblDataCodeEvent = New System.Windows.Forms.Label
        CType(Me.grdDataCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDataCodes
        '
        Me.grdDataCodes.AllowUserToAddRows = False
        Me.grdDataCodes.AllowUserToDeleteRows = False
        Me.grdDataCodes.AllowUserToResizeColumns = False
        Me.grdDataCodes.AllowUserToResizeRows = False
        Me.grdDataCodes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDataCodes.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grdDataCodes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdDataCodes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.grdDataCodes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grdDataCodes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.grdDataCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDataCodes.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDataCodes.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdDataCodes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdDataCodes.GridColor = System.Drawing.SystemColors.Control
        Me.grdDataCodes.Location = New System.Drawing.Point(12, 39)
        Me.grdDataCodes.MultiSelect = False
        Me.grdDataCodes.Name = "grdDataCodes"
        Me.grdDataCodes.ReadOnly = True
        Me.grdDataCodes.RowHeadersVisible = False
        Me.grdDataCodes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdDataCodes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        Me.grdDataCodes.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDataCodes.RowTemplate.Height = 30
        Me.grdDataCodes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDataCodes.Size = New System.Drawing.Size(375, 368)
        Me.grdDataCodes.TabIndex = 0
        '
        'lblDataCode
        '
        Me.lblDataCode.AutoSize = True
        Me.lblDataCode.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDataCode.Location = New System.Drawing.Point(12, 17)
        Me.lblDataCode.Name = "lblDataCode"
        Me.lblDataCode.Size = New System.Drawing.Size(79, 19)
        Me.lblDataCode.TabIndex = 1
        Me.lblDataCode.Text = "Data Code"
        '
        'lblDataCodeEvent
        '
        Me.lblDataCodeEvent.AutoSize = True
        Me.lblDataCodeEvent.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataCodeEvent.Location = New System.Drawing.Point(112, 17)
        Me.lblDataCodeEvent.Name = "lblDataCodeEvent"
        Me.lblDataCodeEvent.Size = New System.Drawing.Size(122, 19)
        Me.lblDataCodeEvent.TabIndex = 1
        Me.lblDataCodeEvent.Text = "Data Code Event"
        '
        'frmDataCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 419)
        Me.Controls.Add(Me.lblDataCodeEvent)
        Me.Controls.Add(Me.lblDataCode)
        Me.Controls.Add(Me.grdDataCodes)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDataCodes"
        Me.Text = "Current Data Codes"
        CType(Me.grdDataCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdDataCodes As System.Windows.Forms.DataGridView
    Friend WithEvents lblDataCode As System.Windows.Forms.Label
    Friend WithEvents lblDataCodeEvent As System.Windows.Forms.Label
End Class
