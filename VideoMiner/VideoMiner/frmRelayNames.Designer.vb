<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelayNames
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
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        txtRelay1 = New System.Windows.Forms.TextBox
        txtRelay2 = New System.Windows.Forms.TextBox
        txtRelay3 = New System.Windows.Forms.TextBox
        txtRelay4 = New System.Windows.Forms.TextBox
        lblDescription = New System.Windows.Forms.Label
        cmdOK = New System.Windows.Forms.Button
        cmdCancel = New System.Windows.Forms.Button
        SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 41)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(77, 13)
        Label1.TabIndex = 0
        Label1.Text = "Relay 1 Name:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(12, 72)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(77, 13)
        Label2.TabIndex = 0
        Label2.Text = "Relay 2 Name:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(12, 104)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(77, 13)
        Label3.TabIndex = 0
        Label3.Text = "Relay 3 Name:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(12, 133)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(77, 13)
        Label4.TabIndex = 0
        Label4.Text = "Relay 4 Name:"
        '
        'txtRelay1
        '
        txtRelay1.Location = New System.Drawing.Point(95, 38)
        txtRelay1.Name = "txtRelay1"
        txtRelay1.Size = New System.Drawing.Size(185, 20)
        txtRelay1.TabIndex = 1
        '
        'txtRelay2
        '
        txtRelay2.Location = New System.Drawing.Point(95, 69)
        txtRelay2.Name = "txtRelay2"
        txtRelay2.Size = New System.Drawing.Size(185, 20)
        txtRelay2.TabIndex = 1
        '
        'txtRelay3
        '
        txtRelay3.Location = New System.Drawing.Point(95, 101)
        txtRelay3.Name = "txtRelay3"
        txtRelay3.Size = New System.Drawing.Size(185, 20)
        txtRelay3.TabIndex = 1
        '
        'txtRelay4
        '
        txtRelay4.Location = New System.Drawing.Point(95, 130)
        txtRelay4.Name = "txtRelay4"
        txtRelay4.Size = New System.Drawing.Size(185, 20)
        txtRelay4.TabIndex = 1
        '
        'lblDescription
        '
        lblDescription.AutoSize = True
        lblDescription.Location = New System.Drawing.Point(9, 9)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New System.Drawing.Size(279, 13)
        lblDescription.TabIndex = 2
        lblDescription.Text = "Type in the desired relay names or leave blank for default."
        '
        'cmdOK
        '
        cmdOK.Location = New System.Drawing.Point(58, 177)
        cmdOK.Name = "cmdOK"
        cmdOK.Size = New System.Drawing.Size(75, 23)
        cmdOK.TabIndex = 3
        cmdOK.Text = "OK"
        cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        cmdCancel.Location = New System.Drawing.Point(139, 177)
        cmdCancel.Name = "cmdCancel"
        cmdCancel.Size = New System.Drawing.Size(75, 23)
        cmdCancel.TabIndex = 3
        cmdCancel.Text = "Cancel"
        cmdCancel.UseVisualStyleBackColor = True
        '
        'frmRelayNames
        '
        AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(292, 212)
        Controls.Add(cmdCancel)
        Controls.Add(cmdOK)
        Controls.Add(lblDescription)
        Controls.Add(txtRelay4)
        Controls.Add(txtRelay3)
        Controls.Add(txtRelay2)
        Controls.Add(txtRelay1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "frmRelayNames"
        Text = "Relay Names"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRelay1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRelay2 As System.Windows.Forms.TextBox
    Friend WithEvents txtRelay3 As System.Windows.Forms.TextBox
    Friend WithEvents txtRelay4 As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
