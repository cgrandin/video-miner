<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeyboardCommands
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKeyboardCommands))
        Me.cmdDeleteShortcut = New System.Windows.Forms.Button()
        Me.cmdAssignShortcut = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lstSpecies = New System.Windows.Forms.ListView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdOK = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdDeleteShortcut
        '
        Me.cmdDeleteShortcut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdDeleteShortcut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteShortcut.Location = New System.Drawing.Point(223, 3)
        Me.cmdDeleteShortcut.Name = "cmdDeleteShortcut"
        Me.cmdDeleteShortcut.Size = New System.Drawing.Size(106, 51)
        Me.cmdDeleteShortcut.TabIndex = 1
        Me.cmdDeleteShortcut.Text = "Delete shortcut"
        Me.cmdDeleteShortcut.UseVisualStyleBackColor = True
        '
        'cmdAssignShortcut
        '
        Me.cmdAssignShortcut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdAssignShortcut.Location = New System.Drawing.Point(3, 3)
        Me.cmdAssignShortcut.Name = "cmdAssignShortcut"
        Me.cmdAssignShortcut.Size = New System.Drawing.Size(104, 51)
        Me.cmdAssignShortcut.TabIndex = 3
        Me.cmdAssignShortcut.Text = "Assign Shortcut"
        Me.cmdAssignShortcut.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstSpecies)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(332, 499)
        Me.SplitContainer1.SplitterDistance = 438
        Me.SplitContainer1.TabIndex = 4
        '
        'lstSpecies
        '
        Me.lstSpecies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstSpecies.Location = New System.Drawing.Point(0, 0)
        Me.lstSpecies.Name = "lstSpecies"
        Me.lstSpecies.Size = New System.Drawing.Size(332, 438)
        Me.lstSpecies.TabIndex = 2
        Me.lstSpecies.UseCompatibleStateImageBehavior = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmdOK, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdAssignShortcut, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdDeleteShortcut, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(332, 57)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'cmdOK
        '
        Me.cmdOK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(113, 3)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(104, 51)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'frmKeyboardCommands
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 499)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKeyboardCommands"
        Me.Text = "Keyboard Shortcuts"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdDeleteShortcut As System.Windows.Forms.Button
    Friend WithEvents cmdAssignShortcut As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lstSpecies As ListView
    Friend WithEvents cmdOK As Button
End Class
