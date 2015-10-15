<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFOV
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
        Me.txtFOV = New System.Windows.Forms.TextBox()
        Me.lblFOV = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtFOV
        '
        Me.txtFOV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFOV.Location = New System.Drawing.Point(14, 29)
        Me.txtFOV.Name = "txtFOV"
        Me.txtFOV.Size = New System.Drawing.Size(206, 21)
        Me.txtFOV.TabIndex = 3
        '
        'lblFOV
        '
        Me.lblFOV.AutoSize = True
        Me.lblFOV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOV.Location = New System.Drawing.Point(12, 9)
        Me.lblFOV.Name = "lblFOV"
        Me.lblFOV.Size = New System.Drawing.Size(208, 13)
        Me.lblFOV.TabIndex = 2
        Me.lblFOV.Text = "Enter the Camera Field of View (cm)"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(121, 61)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 24)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(26, 61)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 24)
        Me.btnOK.TabIndex = 23
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmFOV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(232, 95)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtFOV)
        Me.Controls.Add(Me.lblFOV)
        Me.Name = "frmFOV"
        Me.Text = "Field Of View"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFOV As System.Windows.Forms.TextBox
    Friend WithEvents lblFOV As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
