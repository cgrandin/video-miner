<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigureButtons
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigureButtons))
        Me.cmdDeleteButton = New System.Windows.Forms.Button()
        Me.cmdEditButton = New System.Windows.Forms.Button()
        Me.cmdCreateNewButton = New System.Windows.Forms.Button()
        Me.cmdMoveDown = New System.Windows.Forms.Button()
        Me.cmdMoveUp = New System.Windows.Forms.Button()
        Me.cmdDone = New System.Windows.Forms.Button()
        Me.cmdMoveToPanel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdButtons = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdButtons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdDeleteButton
        '
        Me.cmdDeleteButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdDeleteButton.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteButton.Location = New System.Drawing.Point(118, 0)
        Me.cmdDeleteButton.Name = "cmdDeleteButton"
        Me.cmdDeleteButton.Size = New System.Drawing.Size(118, 38)
        Me.cmdDeleteButton.TabIndex = 16
        Me.cmdDeleteButton.Text = "Delete Button"
        Me.cmdDeleteButton.UseVisualStyleBackColor = True
        '
        'cmdEditButton
        '
        Me.cmdEditButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdEditButton.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditButton.Location = New System.Drawing.Point(0, 0)
        Me.cmdEditButton.Name = "cmdEditButton"
        Me.cmdEditButton.Size = New System.Drawing.Size(118, 38)
        Me.cmdEditButton.TabIndex = 15
        Me.cmdEditButton.Text = "Edit Button"
        Me.cmdEditButton.UseVisualStyleBackColor = True
        '
        'cmdCreateNewButton
        '
        Me.cmdCreateNewButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdCreateNewButton.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreateNewButton.Location = New System.Drawing.Point(236, 0)
        Me.cmdCreateNewButton.Name = "cmdCreateNewButton"
        Me.cmdCreateNewButton.Size = New System.Drawing.Size(118, 38)
        Me.cmdCreateNewButton.TabIndex = 14
        Me.cmdCreateNewButton.Text = "Add Button"
        Me.cmdCreateNewButton.UseVisualStyleBackColor = True
        '
        'cmdMoveDown
        '
        Me.cmdMoveDown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveDown.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveDown.Location = New System.Drawing.Point(3, 29)
        Me.cmdMoveDown.Name = "cmdMoveDown"
        Me.cmdMoveDown.Size = New System.Drawing.Size(97, 23)
        Me.cmdMoveDown.TabIndex = 13
        Me.cmdMoveDown.Text = "Move Down"
        Me.cmdMoveDown.UseVisualStyleBackColor = True
        '
        'cmdMoveUp
        '
        Me.cmdMoveUp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMoveUp.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveUp.Location = New System.Drawing.Point(3, 0)
        Me.cmdMoveUp.Name = "cmdMoveUp"
        Me.cmdMoveUp.Size = New System.Drawing.Size(97, 23)
        Me.cmdMoveUp.TabIndex = 12
        Me.cmdMoveUp.Text = "Move Up"
        Me.cmdMoveUp.UseVisualStyleBackColor = True
        '
        'cmdDone
        '
        Me.cmdDone.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdDone.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDone.Location = New System.Drawing.Point(3, 509)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(118, 39)
        Me.cmdDone.TabIndex = 11
        Me.cmdDone.Text = "Done"
        Me.cmdDone.UseVisualStyleBackColor = True
        '
        'cmdMoveToPanel
        '
        Me.cmdMoveToPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdMoveToPanel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveToPanel.Location = New System.Drawing.Point(3, 3)
        Me.cmdMoveToPanel.Name = "cmdMoveToPanel"
        Me.cmdMoveToPanel.Size = New System.Drawing.Size(357, 38)
        Me.cmdMoveToPanel.TabIndex = 14
        Me.cmdMoveToPanel.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmdMoveToPanel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdDone, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grdButtons, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(472, 551)
        Me.TableLayoutPanel1.TabIndex = 17
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdMoveUp)
        Me.Panel1.Controls.Add(Me.cmdMoveDown)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(366, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(103, 412)
        Me.Panel1.TabIndex = 15
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmdCreateNewButton)
        Me.Panel2.Controls.Add(Me.cmdDeleteButton)
        Me.Panel2.Controls.Add(Me.cmdEditButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 465)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(357, 38)
        Me.Panel2.TabIndex = 16
        '
        'grdButtons
        '
        Me.grdButtons.AllowUserToAddRows = False
        Me.grdButtons.AllowUserToDeleteRows = False
        Me.grdButtons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdButtons.Location = New System.Drawing.Point(3, 47)
        Me.grdButtons.MultiSelect = False
        Me.grdButtons.Name = "grdButtons"
        Me.grdButtons.ReadOnly = True
        Me.grdButtons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdButtons.Size = New System.Drawing.Size(357, 412)
        Me.grdButtons.TabIndex = 17
        '
        'frmConfigureButtons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 551)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfigureButtons"
        Me.Text = "Configure Buttons"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdButtons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdDeleteButton As System.Windows.Forms.Button
    Friend WithEvents cmdEditButton As System.Windows.Forms.Button
    Friend WithEvents cmdCreateNewButton As System.Windows.Forms.Button
    Friend WithEvents cmdMoveDown As System.Windows.Forms.Button
    Friend WithEvents cmdMoveUp As System.Windows.Forms.Button
    Friend WithEvents cmdDone As System.Windows.Forms.Button
    Friend WithEvents cmdMoveToPanel As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdButtons As DataGridView
End Class
