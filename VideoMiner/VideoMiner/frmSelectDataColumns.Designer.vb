<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectDataColumns
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectDataColumns))
        Me.clbData = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'clbData
        '
        Me.clbData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbData.FormattingEnabled = True
        Me.clbData.Location = New System.Drawing.Point(0, 0)
        Me.clbData.Name = "clbData"
        Me.clbData.Size = New System.Drawing.Size(269, 600)
        Me.clbData.TabIndex = 0
        '
        'frmSelectDataColumns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(269, 600)
        Me.Controls.Add(Me.clbData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelectDataColumns"
        Me.Text = "Select visible data columns"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents clbData As CheckedListBox
End Class
