Public Class frmAbundanceTableView

#Region "Member variables"
    Private m_table_name As String
    Private m_data_table As DataTable
    Private m_data_value As String

    Private m_Multiple As Boolean
    Private strSelectedButtonName As String = ""
#End Region

#Region "Properties"
    ''' <summary>
    ''' If a row is selected, return the second cell's value from that row
    ''' If no row is selected, return the empty string.
    ''' </summary>
    Public ReadOnly Property SelectedCodeName As String
        Get
            If grdAbundance.SelectedRows.Count = 1 Then
                Return grdAbundance.SelectedRows(0).Cells(1).Value.ToString()
            Else
                Return NULL_STRING
            End If
        End Get
    End Property

#End Region

    ''' <summary>
    ''' Tell the parent that the data have changed
    ''' </summary>
    Public Event DataChanged(sender As System.Object, e As System.EventArgs)

    Public Sub New()
        InitializeComponent()
        m_table_name = DB_ABUNDANCE_TABLE
        m_data_table = Database.GetDataTable("SELECT * FROM " & m_table_name & " order by ACFORScaleID Asc;", m_table_name)
        grdAbundance.DataSource = m_data_table
        grdAbundance.DataSource = m_data_table
        grdAbundance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdAbundance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        grdAbundance.MultiSelect = False
        ' TODO: Make the grid editable and linked to database
        grdAbundance.ReadOnly = True
    End Sub

    Private Sub TableViewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmdCancel.Visible = True
        Width = grdAbundance.Width
        Height = (grdAbundance.RowCount + 5) * grdAbundance.Rows(0).Height
        Location = MousePosition()
        'txtCommentBox.Text = VideoMiner.strComment
    End Sub

    Private Sub grdAbundance_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdAbundance.CellBeginEdit
        'e.Cancel = True
        'MsgBox("This table is read only. Select a row to make your choice", MsgBoxStyle.Information, "Read only")
    End Sub

    'Private Sub grdAbundance_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAbundance.CellEndEdit
    '    Database.Update(m_data_table, DB_DATA_TABLE)
    'End Sub

    Private Sub grdAbundance_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAbundance.SelectionChanged
        If grdAbundance.SelectedRows.Count = 1 Then
            If txtCommentBox.Text = "Comment" Then
                txtCommentBox.Text = ""
            End If
            RaiseEvent DataChanged(Me, e)
            Hide()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Hide()
    End Sub

    Private Sub cmdComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdComment.Click
        If cmdComment.Text = "Edit Comment" Then
            txtCommentBox.Enabled = True
            cmdCancel.Enabled = False
            grdAbundance.Enabled = False
            grdAbundance.DefaultCellStyle.ForeColor = Color.Gray
            cmdComment.Text = "Done"
        Else
            txtCommentBox.Enabled = False
            cmdCancel.Enabled = True
            grdAbundance.Enabled = True
            grdAbundance.DefaultCellStyle.ForeColor = Color.Black
            cmdComment.Text = "Edit Comment"
        End If
    End Sub

End Class