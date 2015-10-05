<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpeciesEvent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSpeciesEvent))
        Me.ok = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboSpecies = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlSpeciesEvent = New System.Windows.Forms.Panel()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.txtLength = New System.Windows.Forms.TextBox()
        Me.lblLength = New System.Windows.Forms.Label()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.cboAbundance = New System.Windows.Forms.ComboBox()
        Me.lblAbundance = New System.Windows.Forms.Label()
        Me.cboIDConfidence = New System.Windows.Forms.ComboBox()
        Me.lblIDConfidence = New System.Windows.Forms.Label()
        Me.cboSide = New System.Windows.Forms.ComboBox()
        Me.lblSide = New System.Windows.Forms.Label()
        Me.txtRange = New System.Windows.Forms.TextBox()
        Me.lblRange = New System.Windows.Forms.Label()
        Me.cmdScreenCapture = New System.Windows.Forms.Button()
        Me.rtxtComments = New System.Windows.Forms.RichTextBox()
        Me.pnlSpeciesEvent.SuspendLayout()
        Me.SuspendLayout()
        '
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(52, 544)
        Me.ok.Margin = New System.Windows.Forms.Padding(2)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(90, 24)
        Me.ok.TabIndex = 3
        Me.ok.Text = "OK"
        Me.ok.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 17)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Species:"
        '
        'cboSpecies
        '
        Me.cboSpecies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSpecies.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold)
        Me.cboSpecies.FormattingEnabled = True
        Me.cboSpecies.Location = New System.Drawing.Point(80, 17)
        Me.cboSpecies.Name = "cboSpecies"
        Me.cboSpecies.Size = New System.Drawing.Size(218, 25)
        Me.cboSpecies.TabIndex = 13
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(147, 544)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 24)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlSpeciesEvent
        '
        Me.pnlSpeciesEvent.AutoScroll = True
        Me.pnlSpeciesEvent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSpeciesEvent.Controls.Add(Me.lblComments)
        Me.pnlSpeciesEvent.Controls.Add(Me.rtxtComments)
        Me.pnlSpeciesEvent.Controls.Add(Me.txtLength)
        Me.pnlSpeciesEvent.Controls.Add(Me.lblLength)
        Me.pnlSpeciesEvent.Controls.Add(Me.txtWidth)
        Me.pnlSpeciesEvent.Controls.Add(Me.lblWidth)
        Me.pnlSpeciesEvent.Controls.Add(Me.txtHeight)
        Me.pnlSpeciesEvent.Controls.Add(Me.lblHeight)
        Me.pnlSpeciesEvent.Controls.Add(Me.txtCount)
        Me.pnlSpeciesEvent.Controls.Add(Me.lblCount)
        Me.pnlSpeciesEvent.Controls.Add(Me.cboAbundance)
        Me.pnlSpeciesEvent.Controls.Add(Me.lblAbundance)
        Me.pnlSpeciesEvent.Controls.Add(Me.cboIDConfidence)
        Me.pnlSpeciesEvent.Controls.Add(Me.lblIDConfidence)
        Me.pnlSpeciesEvent.Controls.Add(Me.cboSide)
        Me.pnlSpeciesEvent.Controls.Add(Me.lblSide)
        Me.pnlSpeciesEvent.Controls.Add(Me.txtRange)
        Me.pnlSpeciesEvent.Controls.Add(Me.lblRange)
        Me.pnlSpeciesEvent.Location = New System.Drawing.Point(4, 48)
        Me.pnlSpeciesEvent.Name = "pnlSpeciesEvent"
        Me.pnlSpeciesEvent.Size = New System.Drawing.Size(300, 473)
        Me.pnlSpeciesEvent.TabIndex = 24
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComments.Location = New System.Drawing.Point(9, 316)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(68, 13)
        Me.lblComments.TabIndex = 17
        Me.lblComments.Text = "Comments"
        '
        'txtLength
        '
        Me.txtLength.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtLength.Location = New System.Drawing.Point(168, 157)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(121, 21)
        Me.txtLength.TabIndex = 15
        '
        'lblLength
        '
        Me.lblLength.AutoSize = True
        Me.lblLength.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLength.Location = New System.Drawing.Point(166, 140)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(46, 13)
        Me.lblLength.TabIndex = 14
        Me.lblLength.Text = "Length"
        '
        'txtWidth
        '
        Me.txtWidth.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtWidth.Location = New System.Drawing.Point(11, 157)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(121, 21)
        Me.txtWidth.TabIndex = 13
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWidth.Location = New System.Drawing.Point(9, 140)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(40, 13)
        Me.lblWidth.TabIndex = 12
        Me.lblWidth.Text = "Width"
        '
        'txtHeight
        '
        Me.txtHeight.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtHeight.Location = New System.Drawing.Point(169, 114)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(121, 21)
        Me.txtHeight.TabIndex = 11
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeight.Location = New System.Drawing.Point(167, 97)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(44, 13)
        Me.lblHeight.TabIndex = 10
        Me.lblHeight.Text = "Height"
        '
        'txtCount
        '
        Me.txtCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtCount.Location = New System.Drawing.Point(10, 114)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(121, 21)
        Me.txtCount.TabIndex = 9
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.Location = New System.Drawing.Point(8, 97)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(40, 13)
        Me.lblCount.TabIndex = 8
        Me.lblCount.Text = "Count"
        '
        'cboAbundance
        '
        Me.cboAbundance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cboAbundance.FormattingEnabled = True
        Me.cboAbundance.Location = New System.Drawing.Point(170, 72)
        Me.cboAbundance.Name = "cboAbundance"
        Me.cboAbundance.Size = New System.Drawing.Size(121, 21)
        Me.cboAbundance.TabIndex = 7
        '
        'lblAbundance
        '
        Me.lblAbundance.AutoSize = True
        Me.lblAbundance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbundance.Location = New System.Drawing.Point(168, 56)
        Me.lblAbundance.Name = "lblAbundance"
        Me.lblAbundance.Size = New System.Drawing.Size(70, 13)
        Me.lblAbundance.TabIndex = 6
        Me.lblAbundance.Text = "Abundance"
        '
        'cboIDConfidence
        '
        Me.cboIDConfidence.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cboIDConfidence.FormattingEnabled = True
        Me.cboIDConfidence.Location = New System.Drawing.Point(11, 72)
        Me.cboIDConfidence.Name = "cboIDConfidence"
        Me.cboIDConfidence.Size = New System.Drawing.Size(121, 21)
        Me.cboIDConfidence.TabIndex = 5
        '
        'lblIDConfidence
        '
        Me.lblIDConfidence.AutoSize = True
        Me.lblIDConfidence.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDConfidence.Location = New System.Drawing.Point(8, 56)
        Me.lblIDConfidence.Name = "lblIDConfidence"
        Me.lblIDConfidence.Size = New System.Drawing.Size(85, 13)
        Me.lblIDConfidence.TabIndex = 4
        Me.lblIDConfidence.Text = "ID Confidence"
        '
        'cboSide
        '
        Me.cboSide.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cboSide.FormattingEnabled = True
        Me.cboSide.Location = New System.Drawing.Point(170, 30)
        Me.cboSide.Name = "cboSide"
        Me.cboSide.Size = New System.Drawing.Size(121, 21)
        Me.cboSide.TabIndex = 3
        '
        'lblSide
        '
        Me.lblSide.AutoSize = True
        Me.lblSide.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSide.Location = New System.Drawing.Point(168, 14)
        Me.lblSide.Name = "lblSide"
        Me.lblSide.Size = New System.Drawing.Size(31, 13)
        Me.lblSide.TabIndex = 2
        Me.lblSide.Text = "Side"
        '
        'txtRange
        '
        Me.txtRange.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtRange.Location = New System.Drawing.Point(10, 31)
        Me.txtRange.Name = "txtRange"
        Me.txtRange.Size = New System.Drawing.Size(121, 21)
        Me.txtRange.TabIndex = 1
        '
        'lblRange
        '
        Me.lblRange.AutoSize = True
        Me.lblRange.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRange.Location = New System.Drawing.Point(8, 14)
        Me.lblRange.Name = "lblRange"
        Me.lblRange.Size = New System.Drawing.Size(43, 13)
        Me.lblRange.TabIndex = 0
        Me.lblRange.Text = "Range"
        '
        'cmdScreenCapture
        '
        Me.cmdScreenCapture.BackColor = System.Drawing.SystemColors.Control
        Me.cmdScreenCapture.BackgroundImage = CType(resources.GetObject("cmdScreenCapture.BackgroundImage"), System.Drawing.Image)
        Me.cmdScreenCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdScreenCapture.Location = New System.Drawing.Point(265, 543)
        Me.cmdScreenCapture.Name = "cmdScreenCapture"
        Me.cmdScreenCapture.Size = New System.Drawing.Size(33, 26)
        Me.cmdScreenCapture.TabIndex = 58
        Me.cmdScreenCapture.UseVisualStyleBackColor = False
        '
        'rtxtComments
        '
        Me.rtxtComments.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.rtxtComments.Location = New System.Drawing.Point(12, 332)
        Me.rtxtComments.Name = "rtxtComments"
        Me.rtxtComments.Size = New System.Drawing.Size(278, 132)
        Me.rtxtComments.TabIndex = 16
        Me.rtxtComments.Text = ""
        '
        'frmSpeciesEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 585)
        Me.Controls.Add(Me.cmdScreenCapture)
        Me.Controls.Add(Me.pnlSpeciesEvent)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.cboSpecies)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ok)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSpeciesEvent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Species Event"
        Me.TopMost = True
        Me.pnlSpeciesEvent.ResumeLayout(False)
        Me.pnlSpeciesEvent.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSpecies As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlSpeciesEvent As System.Windows.Forms.Panel
    Friend WithEvents cmdScreenCapture As System.Windows.Forms.Button
    Friend WithEvents lblRange As System.Windows.Forms.Label
    Friend WithEvents txtRange As System.Windows.Forms.TextBox
    Friend WithEvents lblSide As System.Windows.Forms.Label
    Friend WithEvents cboSide As System.Windows.Forms.ComboBox
    Friend WithEvents lblIDConfidence As System.Windows.Forms.Label
    Friend WithEvents cboIDConfidence As System.Windows.Forms.ComboBox
    Friend WithEvents lblAbundance As System.Windows.Forms.Label
    Friend WithEvents cboAbundance As System.Windows.Forms.ComboBox
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents txtLength As System.Windows.Forms.TextBox
    Friend WithEvents lblLength As System.Windows.Forms.Label
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents rtxtComments As System.Windows.Forms.RichTextBox
End Class
