''' <summary>
''' This form will show a table which is supplied in the constructor as a DataTable.
''' It will allow the suer to select a row, which will cause a query to insert the data
''' in the database
''' </summary>
Public Class frmTableView
    Private m_table_name As String
    Private m_data_table As DataTable

#Region "Properties"
    Public ReadOnly Property GetCurrentlySelectedCode As String
        Get
            Return DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        End Get
    End Property

    Public ReadOnly Property GetCurrentlySelectedCodeName As String
        Get
            Return DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
        End Get
    End Property

    Public ReadOnly Property GetCurrentComment As String
        Get
            Return txtCommentBox.Text
        End Get
    End Property
#End Region

    ''' <summary>
    ''' If user presses Clear button, this will fire so that the main form can update its dynamic buttons and textboxes
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ClearSpatialInformationEvent()

    ''' <summary>
    ''' If user edits the comment box, this event will be raised so that the main form can write a record to the database
    ''' </summary>
    ''' <remarks></remarks>
    Public Event DataChanged()

    'Public Sub New(ByVal table As String, ByRef dictFieldValues As Dictionary(Of String, String))
    Public Sub New(data_table As DataTable)
        ' This is required by the Windows Form Designer.
        InitializeComponent()
        m_data_table = data_table
        DataGridView1.DataSource = m_data_table

        ' Add any initialization after the InitializeComponent() call.
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Controls.Add(DataGridView1)
        'If intCurrentSpatialVariable <> 8888 Then
        ' m_strSelectedButtonName = strButtonNames(intCurrentSpatialVariable)
        ' End If
    End Sub

    Private Sub TableViewForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Me.UserClosedForm = True
    End Sub

    ''' <summary>
    ''' Capture the press of the 'X' button and hide instead of closing to avoid an exception on re-opening
    ''' </summary>
    Private Sub frmTableView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub TableViewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Text = m_strSelectedButtonName
        'm_UserClosedForm = False
        Me.btnSkipSpatial.Visible = True
        Me.btnClear.Visible = True
        Me.Width = DataGridView1.Width
        Me.Height = (DataGridView1.RowCount + 3) * DataGridView1.Rows(0).Height
        Me.txtCommentBox.Text = VideoMiner.strComment
        Refresh()
    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        'e.Cancel = True
        'MsgBox("This table is read only. Select a row to make your choice", MsgBoxStyle.Information, "Read only")
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        'Database.Update(m_data_table)
    End Sub

    ''' <summary>
    ''' Handles the event when the user selects a row of the table. If the comment box is not empty, it will raise an event so that the main form can
    ''' insert a new record in the database to capture the comment.
    ''' </summary>
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count = 1 Then
            If txtCommentBox.Text <> "" Then
                RaiseEvent DataChanged()
            End If
            Me.Hide()
        End If
    End Sub

    Private Sub btnSkipSpatial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSkipSpatial.Click
        Me.Hide()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        RaiseEvent ClearSpatialInformationEvent()
        blCleared = True
        Me.Hide()
    End Sub

    '    Private Sub cmdComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If Me.cmdComment.Text = "Edit Comment" Then
    '            txtCommentBox.Enabled = True
    '            Me.btnClear.Enabled = False
    '            Me.btnSkipSpatial.Enabled = False
    '            Me.DataGridView1.Enabled = False
    '            Me.DataGridView1.DefaultCellStyle.ForeColor = Color.Gray
    '            Me.cmdComment.Text = "Done"
    '        Else
    '            txtCommentBox.Enabled = False
    '            Me.btnClear.Enabled = True
    '            Me.btnSkipSpatial.Enabled = True
    '            Me.DataGridView1.Enabled = True
    '            Me.DataGridView1.DefaultCellStyle.ForeColor = Color.Black
    '            Me.cmdComment.Text = "Edit Comment"
    'TODO: Make sure a comment here is put into the table in the DataGridView in the main form
    '        End If
    '    End Sub

    Private Sub cmdScreenCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScreenCapture.Click
        'TODO: Screen capturee... not sure why though
        'myFormLibrary.frmVideoMiner.blScreenCaptureCalled = True
        'myFormLibrary.frmVideoMiner.mnuCapScr_Click(sender, e)
        'myFormLibrary.frmVideoMiner.blScreenCaptureCalled = False
    End Sub

End Class