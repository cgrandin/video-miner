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
        grdDataCodes = New System.Windows.Forms.DataGridView
        lblDataCode = New System.Windows.Forms.Label
        lblDataCodeEvent = New System.Windows.Forms.Label
        CType(grdDataCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'grdDataCodes
        '
        grdDataCodes.AllowUserToAddRows = False
        grdDataCodes.AllowUserToDeleteRows = False
        grdDataCodes.AllowUserToResizeColumns = False
        grdDataCodes.AllowUserToResizeRows = False
        grdDataCodes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        grdDataCodes.BackgroundColor = System.Drawing.SystemColors.Control
        grdDataCodes.BorderStyle = System.Windows.Forms.BorderStyle.None
        grdDataCodes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        grdDataCodes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        grdDataCodes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        grdDataCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        grdDataCodes.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        grdDataCodes.DefaultCellStyle = DataGridViewCellStyle1
        grdDataCodes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        grdDataCodes.GridColor = System.Drawing.SystemColors.Control
        grdDataCodes.Location = New System.Drawing.Point(12, 39)
        grdDataCodes.MultiSelect = False
        grdDataCodes.Name = "grdDataCodes"
        grdDataCodes.ReadOnly = True
        grdDataCodes.RowHeadersVisible = False
        grdDataCodes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdDataCodes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control
        grdDataCodes.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        grdDataCodes.RowTemplate.Height = 30
        grdDataCodes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        grdDataCodes.Size = New System.Drawing.Size(375, 368)
        grdDataCodes.TabIndex = 0
        '
        'lblDataCode
        '
        lblDataCode.AutoSize = True
        lblDataCode.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblDataCode.ForeColor = System.Drawing.SystemColors.ControlText
        lblDataCode.Location = New System.Drawing.Point(12, 17)
        lblDataCode.Name = "lblDataCode"
        lblDataCode.Size = New System.Drawing.Size(79, 19)
        lblDataCode.TabIndex = 1
        lblDataCode.Text = "Data Code"
        '
        'lblDataCodeEvent
        '
        lblDataCodeEvent.AutoSize = True
        lblDataCodeEvent.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblDataCodeEvent.Location = New System.Drawing.Point(112, 17)
        lblDataCodeEvent.Name = "lblDataCodeEvent"
        lblDataCodeEvent.Size = New System.Drawing.Size(122, 19)
        lblDataCodeEvent.TabIndex = 1
        lblDataCodeEvent.Text = "Data Code Event"
        '
        'frmDataCodes
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(399, 419)
        Controls.Add(lblDataCodeEvent)
        Controls.Add(lblDataCode)
        Controls.Add(grdDataCodes)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmDataCodes"
        Text = "Current Data Codes"
        CType(grdDataCodes, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents grdDataCodes As System.Windows.Forms.DataGridView
    Friend WithEvents lblDataCode As System.Windows.Forms.Label
    Friend WithEvents lblDataCodeEvent As System.Windows.Forms.Label
End Class
