<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImage))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ZoomPictureBox1 = New ZPBlib.ZoomPictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.EXIFDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnPrev10 = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnNext10 = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.ZoomPictureBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MenuStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(701, 763)
        Me.SplitContainer1.SplitterDistance = 680
        Me.SplitContainer1.TabIndex = 9
        '
        'ZoomPictureBox1
        '
        Me.ZoomPictureBox1.BackColor = System.Drawing.Color.Black
        Me.ZoomPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ZoomPictureBox1.EnableMouseDragging = True
        Me.ZoomPictureBox1.EnableMouseWheelZooming = True
        Me.ZoomPictureBox1.Image = Nothing
        Me.ZoomPictureBox1.ImagePosition = New System.Drawing.Point(0, 0)
        Me.ZoomPictureBox1.Location = New System.Drawing.Point(0, 24)
        Me.ZoomPictureBox1.MaximumZoomFactor = 64.0R
        Me.ZoomPictureBox1.MinimumImageHeight = 10
        Me.ZoomPictureBox1.MinimumImageWidth = 10
        Me.ZoomPictureBox1.MouseWheelDivisor = 4000
        Me.ZoomPictureBox1.Name = "ZoomPictureBox1"
        Me.ZoomPictureBox1.Size = New System.Drawing.Size(701, 656)
        Me.ZoomPictureBox1.TabIndex = 1
        Me.ZoomPictureBox1.ZoomFactor = 0R
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXIFDataToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(701, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EXIFDataToolStripMenuItem
        '
        Me.EXIFDataToolStripMenuItem.Name = "EXIFDataToolStripMenuItem"
        Me.EXIFDataToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.EXIFDataToolStripMenuItem.Text = "EXIF data"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnPrev, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnNext, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPrev10, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnNext10, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(701, 79)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnPrev
        '
        Me.btnPrev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrev.Location = New System.Drawing.Point(108, 3)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(239, 73)
        Me.btnPrev.TabIndex = 0
        Me.btnPrev.Text = "<"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnPrev10
        '
        Me.btnPrev10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPrev10.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrev10.Location = New System.Drawing.Point(3, 3)
        Me.btnPrev10.Name = "btnPrev10"
        Me.btnPrev10.Size = New System.Drawing.Size(99, 73)
        Me.btnPrev10.TabIndex = 3
        Me.btnPrev10.Text = "<<10"
        Me.btnPrev10.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(353, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(239, 73)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = ">"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnNext10
        '
        Me.btnNext10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNext10.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext10.Location = New System.Drawing.Point(598, 3)
        Me.btnNext10.Name = "btnNext10"
        Me.btnNext10.Size = New System.Drawing.Size(100, 73)
        Me.btnNext10.TabIndex = 2
        Me.btnNext10.Text = ">>10"
        Me.btnNext10.UseVisualStyleBackColor = True
        '
        'frmImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(701, 763)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmImage"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ZoomPictureBox1 As ZPBlib.ZoomPictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents EXIFDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnPrev10 As Button
    Friend WithEvents btnNext10 As Button
End Class
