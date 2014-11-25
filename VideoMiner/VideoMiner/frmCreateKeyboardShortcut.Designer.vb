<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateKeyboardShortcut
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
        txtCurrentShortcut = New System.Windows.Forms.TextBox
        cmdStart = New System.Windows.Forms.Button
        cmdOK = New System.Windows.Forms.Button
        cmdCancel = New System.Windows.Forms.Button
        SuspendLayout()
        '
        'txtCurrentShortcut
        '
        txtCurrentShortcut.Location = New System.Drawing.Point(12, 12)
        txtCurrentShortcut.Name = "txtCurrentShortcut"
        txtCurrentShortcut.ReadOnly = True
        txtCurrentShortcut.Size = New System.Drawing.Size(156, 20)
        txtCurrentShortcut.TabIndex = 0
        txtCurrentShortcut.TabStop = False
        '
        'cmdStart
        '
        cmdStart.Location = New System.Drawing.Point(174, 10)
        cmdStart.Name = "cmdStart"
        cmdStart.Size = New System.Drawing.Size(75, 23)
        cmdStart.TabIndex = 1
        cmdStart.Text = "Start Typing"
        cmdStart.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        cmdOK.Location = New System.Drawing.Point(12, 38)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(75, 23)
        cmdOK.TabIndex = 1
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        cmdCancel.Location = New System.Drawing.Point(93, 38)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New System.Drawing.Size(75, 23)
        cmdCancel.TabIndex = 1
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        '
        'frmCreateKeyboardShortcut
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(261, 72)
        Controls.Add(cmdCancel)
        Controls.Add(cmdOK)
        Controls.Add(cmdStart)
        Controls.Add(txtCurrentShortcut)
        KeyPreview = True
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmCreateKeyboardShortcut"
        Text = "Create Keyboard Shortcut"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents txtCurrentShortcut As System.Windows.Forms.TextBox
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
