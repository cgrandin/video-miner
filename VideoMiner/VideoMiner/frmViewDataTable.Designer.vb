<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewDataTable
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
        Me.grdDataTable = New System.Windows.Forms.DataGridView()
        CType(Me.grdDataTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDataTable
        '
        Me.grdDataTable.AllowUserToAddRows = False
        Me.grdDataTable.AllowUserToDeleteRows = False
        Me.grdDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDataTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDataTable.Location = New System.Drawing.Point(0, 0)
        Me.grdDataTable.Name = "grdDataTable"
        Me.grdDataTable.ReadOnly = True
        Me.grdDataTable.Size = New System.Drawing.Size(377, 482)
        Me.grdDataTable.TabIndex = 0
        '
        'frmViewDataTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(377, 482)
        Me.Controls.Add(Me.grdDataTable)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewDataTable"
        Me.Text = "Data table viewer"
        Me.TopMost = True
        CType(Me.grdDataTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdDataTable As DataGridView
End Class
