''' <summary>
''' This form will show a table which is supplied in the constructor as a DataTable.
''' It will allow the user to select a row, which will cause a query to insert the data
''' in the database
''' </summary>
Public Class frmTableView
    Private m_table_name As String
    Private m_data_table As DataTable

#Region "Properties"
    ''' <summary>
    ''' If a row is selected, return the first cell's value from that row.
    ''' If no row is selected, return the empty string.
    ''' </summary>
    Public ReadOnly Property SelectedCode As String
        Get
            If DataGridView1.SelectedRows.Count = 1 Then
                Return DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            Else
                Return NULL_STRING
            End If
        End Get
    End Property

    ''' <summary>
    ''' If a row is selected, return the second cell's value from that row
    ''' If no row is selected, return the empty string.
    ''' </summary>
    Public ReadOnly Property SelectedCodeName As String
        Get
            If DataGridView1.SelectedRows.Count = 1 Then
                Return DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
            Else
                Return NULL_STRING
            End If
        End Get
    End Property

    ''' <summary>
    ''' Return the contents of the comment box, which may be an empty string.
    ''' </summary>
    Public ReadOnly Property Comment As String
        Get
            Return txtCommentBox.Text
        End Get
    End Property
#End Region

#Region "Events"
    ''' <summary>
    ''' If user presses Clear button, this will fire so that the main form can update its dynamic buttons and textboxes
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ClearSpatialInformationEvent()

    ''' <summary>
    ''' If user edits the comment box, this event will be raised so that the main form can write a record to the database
    ''' </summary>
    ''' <param name="comment">A comment as input by user into the comment box, or the empty string if there is no comment.</param>
    ''' <remarks></remarks>
    Public Event DataChanged(comment As String)
#End Region

    'Public Sub New(ByVal table As String, ByRef dictFieldValues As Dictionary(Of String, String))
    Public Sub New(data_table As DataTable)
        ' This is required by the Windows Form Designer.
        InitializeComponent()
        m_data_table = data_table
        DataGridView1.DataSource = m_data_table
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
            RaiseEvent DataChanged(txtCommentBox.Text)
            Me.Hide()
        End If
    End Sub

    Private Sub btnSkipSpatial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSkipSpatial.Click
        Me.Hide()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        RaiseEvent ClearSpatialInformationEvent()
        Me.Hide()
    End Sub

    Private Sub cmdScreenCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScreenCapture.Click
        'TODO: Screen capture... not sure why though
        'myFormLibrary.frmVideoMiner.blScreenCaptureCalled = True
        'myFormLibrary.frmVideoMiner.mnuCapScr_Click(sender, e)
        'myFormLibrary.frmVideoMiner.blScreenCaptureCalled = False
    End Sub

End Class