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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRelay1 = New System.Windows.Forms.TextBox
        Me.txtRelay2 = New System.Windows.Forms.TextBox
        Me.txtRelay3 = New System.Windows.Forms.TextBox
        Me.txtRelay4 = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Relay 1 Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Relay 2 Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Relay 3 Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Relay 4 Name:"
        '
        'txtRelay1
        '
        Me.txtRelay1.Location = New System.Drawing.Point(95, 38)
        Me.txtRelay1.Name = "txtRelay1"
        Me.txtRelay1.Size = New System.Drawing.Size(185, 20)
        Me.txtRelay1.TabIndex = 1
        '
        'txtRelay2
        '
        Me.txtRelay2.Location = New System.Drawing.Point(95, 69)
        Me.txtRelay2.Name = "txtRelay2"
        Me.txtRelay2.Size = New System.Drawing.Size(185, 20)
        Me.txtRelay2.TabIndex = 1
        '
        'txtRelay3
        '
        Me.txtRelay3.Location = New System.Drawing.Point(95, 101)
        Me.txtRelay3.Name = "txtRelay3"
        Me.txtRelay3.Size = New System.Drawing.Size(185, 20)
        Me.txtRelay3.TabIndex = 1
        '
        'txtRelay4
        '
        Me.txtRelay4.Location = New System.Drawing.Point(95, 130)
        Me.txtRelay4.Name = "txtRelay4"
        Me.txtRelay4.Size = New System.Drawing.Size(185, 20)
        Me.txtRelay4.TabIndex = 1
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(9, 9)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(279, 13)
        Me.lblDescription.TabIndex = 2
        Me.lblDescription.Text = "Type in the desired relay names or leave blank for default."
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(58, 177)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(139, 177)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmRelayNames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 212)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.txtRelay4)
        Me.Controls.Add(Me.txtRelay3)
        Me.Controls.Add(Me.txtRelay2)
        Me.Controls.Add(Me.txtRelay1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmRelayNames"
        Me.Text = "Relay Names"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
