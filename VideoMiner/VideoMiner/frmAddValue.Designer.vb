<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddValue
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
        txtValue = New System.Windows.Forms.TextBox
        cmdOK = New System.Windows.Forms.Button
        cmdCancel = New System.Windows.Forms.Button
        lblExpression = New System.Windows.Forms.Label
        SuspendLayout()
        '
        'txtValue
        '
        txtValue.Location = New System.Drawing.Point(12, 25)
        txtValue.MaxLength = 50
        txtValue.Name = "txtValue"
        txtValue.Size = New System.Drawing.Size(246, 20)
        txtValue.TabIndex = 0
        '
        'cmdOK
        '
        cmdOK.Location = New System.Drawing.Point(12, 51)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(120, 25)
        cmdOK.TabIndex = 1
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        cmdCancel.Location = New System.Drawing.Point(138, 51)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New System.Drawing.Size(120, 25)
        cmdCancel.TabIndex = 2
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        '
        'lblExpression
        '
        lblExpression.AutoSize = True
        lblExpression.Location = New System.Drawing.Point(9, 9)
        lblExpression.Name = "lblExpression"
        lblExpression.Size = New System.Drawing.Size(39, 13)
        lblExpression.TabIndex = 3
        lblExpression.Text = "Label1"
        '
        'frmAddValue
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(272, 90)
        ControlBox = False
        Controls.Add(lblExpression)
        Controls.Add(cmdCancel)
        Controls.Add(cmdOK)
        Controls.Add(txtValue)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmAddValue"
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Text = "frmAddValue"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblExpression As System.Windows.Forms.Label
End Class
