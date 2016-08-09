Public Class frmAbundanceTableView

#Region "Member variables"
    Private m_table_name As String
    Private m_data_table As DataTable
    Private m_data_value As String

    Private m_Multiple As Boolean
    Private strSelectedButtonName As String = NULL_STRING

    Private prevWidth As Integer
    Private prevWindowState As FormWindowState
#End Region

#Region "Properties"
    ''' <summary>
    ''' If a row is selected, return the first cell's value from that row.
    ''' If no row is selected, return the empty string.
    ''' </summary>
    Public ReadOnly Property SelectedCode As String
        Get
            If grdAbundance.SelectedRows.Count = 1 Then
                Return grdAbundance.SelectedRows(0).Cells(0).Value.ToString()
            Else
                Return String.Empty
            End If
        End Get
    End Property

    ''' <summary>
    ''' If a row is selected, return the second cell's value from that row
    ''' If no row is selected, return the empty string.
    ''' </summary>
    Public ReadOnly Property SelectedCodeName As String
        Get
            If grdAbundance.SelectedRows.Count = 1 Then
                Return grdAbundance.SelectedRows(0).Cells(1).Value.ToString()
            Else
                Return String.Empty
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

    ''' <summary>
    ''' Tell the parent that the data have changed
    ''' </summary>
    Public Event DataChanged(sender As System.Object, e As System.EventArgs)
    ''' <summary>
    ''' Fires when user presses Cancel or 'X' button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event DataEntryCanceled(ByVal sender As System.Object, ByVal e As System.EventArgs)


    Public Sub New()
        InitializeComponent()
        m_table_name = DB_ABUNDANCE_TABLE
        m_data_table = Database.GetDataTable("SELECT * FROM " & m_table_name & " order by ACFORScaleID Asc;", m_table_name)
        grdAbundance.DataSource = m_data_table
        grdAbundance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdAbundance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        grdAbundance.MultiSelect = False
        ' TODO: Make the grid editable and linked to database
        grdAbundance.ReadOnly = True
    End Sub

    ''' <summary>
    ''' Once the form loads, resize the grid so that there is no horizontal scrollbar
    ''' </summary>
    Private Sub ResizeGrid()
        If prevWidth = 0 Then
            prevWidth = grdAbundance.Width
        End If
        If prevWidth = grdAbundance.Width Then
            Exit Sub
        End If
        Dim fixedWidth As Integer = SystemInformation.VerticalScrollBarWidth + grdAbundance.RowHeadersWidth + 2
        Dim mul As Integer = 100 * (grdAbundance.Width - fixedWidth) / (prevWidth - fixedWidth)
        Dim columnWidth As Integer
        Dim total As Integer = 0
        Dim lastVisibleCol As DataGridViewColumn = Nothing
        For i As Integer = 0 To grdAbundance.ColumnCount - 1
            If grdAbundance.Columns(i).Visible Then
                columnWidth = (grdAbundance.Columns(i).Width * mul + 50) / 100
                grdAbundance.Columns(i).Width = Math.Max(columnWidth, grdAbundance.Columns(i).MinimumWidth)
                total = total + grdAbundance.Columns(i).Width
                lastVisibleCol = grdAbundance.Columns(i)
            End If
        Next
        If IsNothing(lastVisibleCol) Then
            Exit Sub
        End If
        columnWidth = grdAbundance.Width - total + lastVisibleCol.Width - fixedWidth
        lastVisibleCol.Width = Math.Max(columnWidth, lastVisibleCol.MinimumWidth)
        prevWidth = grdAbundance.Width
    End Sub


    Private Sub TableViewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prevWidth = Width
        prevWindowState = WindowState
        ResizeGrid()
        Refresh()
        'Location = MousePosition()
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
                txtCommentBox.Text = NULL_STRING
            End If
            RaiseEvent DataChanged(Me, e)
            Hide()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        RaiseEvent DataEntryCanceled(sender, e)
        Hide()
    End Sub

    ''' <summary>
    ''' Capture the press of the 'X' button and hide instead of closing to avoid an exception on re-opening
    ''' </summary>
    Private Sub frmTableView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            RaiseEvent DataEntryCanceled(sender, e)
            Me.Hide()
        End If
    End Sub

End Class