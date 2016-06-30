<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDataCodes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataCodes))
        Me.grdDataCodes = New System.Windows.Forms.DataGridView()
        CType(Me.grdDataCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDataCodes
        '
        Me.grdDataCodes.AllowUserToAddRows = False
        Me.grdDataCodes.AllowUserToDeleteRows = False
        Me.grdDataCodes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDataCodes.Location = New System.Drawing.Point(0, 0)
        Me.grdDataCodes.Name = "grdDataCodes"
        Me.grdDataCodes.Size = New System.Drawing.Size(399, 419)
        Me.grdDataCodes.TabIndex = 0
        '
        'frmDataCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 419)
        Me.Controls.Add(Me.grdDataCodes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDataCodes"
        Me.Text = "Current Data Codes"
        CType(Me.grdDataCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdDataCodes As DataGridView
End Class
