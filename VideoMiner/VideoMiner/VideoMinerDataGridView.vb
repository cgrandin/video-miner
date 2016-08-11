Imports System.ComponentModel

''' <summary>
''' 
''' </summary>
Public Class VideoMinerDataGridView

#Region "Constants and Pseudo-Constants"
    Private Const ROW_HEADER_WIDTH As Integer = 60
    Private Const SYNCED_TEXT As String = "Data Table Synced"
    Private Const UNSYNCED_TEXT As String = "Data Table Unsynced"

    Private CLEAN_BACKCOLOR As Color = Color.White
    Private CLEAN_SELECTION_BACKCOLOR As Color = SystemColors.Highlight
    Private CLEAN_FORECOLOR As Color = Color.Black

    Private DIRTY_ROW_BACKCOLOR As Color = Color.Salmon
    Private DIRTY_CELL_BACKCOLOR As Color = Color.Firebrick
    Private DIRTY_SELECTION_BACKCOLOR As Color = Color.DarkSalmon
    Private DIRTY_FORECOLOR As Color = Color.AntiqueWhite
#End Region

#Region "Member variables"
    ''' <summary>
    ''' Whether or not the grid is synced with the database
    ''' </summary>
    Private m_synced As Boolean
    ''' <summary>
    ''' Name of the table that is bound to the DataGridView
    ''' </summary>
    Private m_table_name As String
    ''' <summary>
    ''' DataTable of the data found in the table given by m_table_name
    ''' </summary>
    Private m_data_table As DataTable
    ''' <summary>
    ''' Name of the primary key field in the table
    ''' </summary>
    Private m_primary_key_field As String
    ''' <summary>
    ''' Show the column which holds the Primary Keys?
    ''' </summary>
    Private m_show_primary_key_field As Boolean
    ''' <summary>
    ''' The current row that is being displayed. This is used so that after a data entry event,
    ''' the view won't jump back to the beginning of the grid.
    ''' </summary>
    Private m_curr_row As Integer
    ''' <summary>
    ''' The current column that is being displayed. This is used so that after a data entry event,
    ''' the view won't jump back to the beginning of the grid.
    ''' </summary>
    Private m_curr_col As Integer
    ''' <summary>
    ''' Coloring of a row in the data grid. This structure represents a single row in the grid.
    ''' The two cell lists hold the background and foreground colors for the cells in the row.
    ''' If the columns are allowed to be sorted, this would be required to recolor the cells
    ''' after the sort.
    ''' </summary>
    Structure stcRowColoring
        Public isDirty As Boolean
        ' The primary key in the database. Since the key can be changed in the grid,
        ' this is required to hold the real key so that any queries can be constructed correctly.
        Public dbPrimaryKey As Integer
        ' The row's background color
        Public rowBackColor As Color
        ' The row's background selection color
        Public rowBackSelectColor As Color
        ' The list of foreground colors for each cell in the row
        Public cellForegroundCols As List(Of Color)
        ' The list of background colors for each cell in the row
        Public cellBackgroundCols As List(Of Color)
    End Structure
    ''' <summary>
    ''' A list of row colorings to keep track of dirty cells when the columns are sorted.
    ''' </summary>
    Private m_arr_coloring As List(Of stcRowColoring)
    ''' <summary>
    ''' A form showing the data code table so user can see all the currently-assigned data codes
    ''' </summary>
    Private WithEvents m_frmViewDataTable As frmViewDataTable
    ''' <summary>
    ''' When the user clicks on a cell in the column which is called KeyboardShortcuts, a form will appear
    ''' allowing them to set it up.
    ''' </summary>
    Private WithEvents m_frmCreateKeyboardShortcut As frmCreateKeyboardShortcut
    ''' <summary>
    ''' Enumeration describing which way to move the button definition in the list
    ''' </summary>
    Private Enum MoveDirection
        Up
        Down
    End Enum
    Private Enum CellStatus
        Clean
        Dirty
    End Enum
    ''' <summary>
    ''' Order the rows are displayed by Primary key id
    ''' </summary>
    Public Enum RowOrderEnum
        Ascending
        Descending
    End Enum
    Private m_row_order As RowOrderEnum
    ''' <summary>
    ''' Show or hide the last column buttons, i.e. Move, add row, delete, show data codes buttons
    ''' </summary>
    Private m_show_buttons As Boolean
    Private m_show_tooltips As Boolean
    ' Tooltip members
    Dim m_move_up_tooltip As ToolTip
    Dim m_move_down_tooltip As ToolTip
    Dim m_add_row_tooltip As ToolTip
    Dim m_delete_rows_tooltip As ToolTip
    Dim m_show_data_codes_tooltip As ToolTip
    Dim m_sync_tooltip As ToolTip
    Dim m_revert_tooltip As ToolTip

#End Region

#Region "Properties"
    Public ReadOnly Property IsSynced As Boolean
        Get
            Return m_synced
        End Get
    End Property
    Public ReadOnly Property DGV As DataGridView
        Get
            Return grd
        End Get
    End Property

    Public ReadOnly Property DataTable As DataTable
        Get
            Return m_data_table
        End Get
    End Property
    Public Property ShowTooltips
        Get
            Return m_show_tooltips
        End Get
        Set(value)
            m_show_tooltips = CBool(value)
        End Set
    End Property
#End Region

#Region "Events"
    Public Event BeginEditEvent()
    Public Event EndEditEvent(blSynced As Boolean)
    Public Event DataChanged()
    Public Event SyncedEvent()
    Public Event UnsyncedEvent()
    Public Event CellClick()
    Public Event SelectionChanged()
#End Region

    Public Sub New(tableName As String,
                   Optional showPrimaryKeyField As Boolean = True,
                   Optional rowOrder As RowOrderEnum = RowOrderEnum.Ascending,
                   Optional showToolTips As Boolean = True,
                   Optional showButtons As Boolean = True)
        InitializeComponent()
        m_table_name = tableName
        m_primary_key_field = Database.GetPrimaryKeyFieldName(m_table_name)
        m_show_primary_key_field = showPrimaryKeyField
        m_row_order = rowOrder
        m_show_tooltips = showToolTips
        m_show_buttons = showButtons
        m_arr_coloring = New List(Of stcRowColoring)
        grd.AllowUserToAddRows = False
        m_frmViewDataTable = New frmViewDataTable(DB_DATA_CODES_TABLE)

        If Not m_show_buttons Then
            TableLayoutPanel1.ColumnStyles(4).Width = 0
        End If

        ' Add tooltips
        m_move_up_tooltip = New ToolTip()
        m_move_up_tooltip.SetToolTip(btnMoveUp, "Move the selected row up the table")
        m_move_down_tooltip = New ToolTip()
        m_move_down_tooltip.SetToolTip(btnMoveDown, "Move the selected row down the table")

        m_add_row_tooltip = New ToolTip()
        m_add_row_tooltip.SetToolTip(btnAddRow, "Adds a new row to the database table. The new row will be a copy " & vbCrLf &
                             "of the most recent row or an empty row if the table is empty")

        m_delete_rows_tooltip = New ToolTip()
        m_delete_rows_tooltip.SetToolTip(btnDeleteRows, "Deletes the selected rows from the database. You can also press the 'delete' key " & vbCrLf &
                                 "or right-click to delete rows")

        m_show_data_codes_tooltip = New ToolTip()
        m_show_data_codes_tooltip.SetToolTip(btnDataCodes, "Show the database table 'Data Codes'")

        m_sync_tooltip = New ToolTip()
        m_sync_tooltip.SetToolTip(btnSync, "Save the modified data (colored cells) to the database")

        m_revert_tooltip = New ToolTip()
        m_revert_tooltip.SetToolTip(btnRevert, "Discard the modified data (colored cells) and reload the " & vbCrLf &
                            "database data into the grid")

        If m_show_tooltips Then
            EnableToolTips()
        Else
            DisableToolTips()
        End If
        fetchData()
    End Sub

    Public Sub DisableToolTips()
        m_move_up_tooltip.Active = False
        m_move_down_tooltip.Active = False
        m_add_row_tooltip.Active = False
        m_delete_rows_tooltip.Active = False
        m_show_data_codes_tooltip.Active = False
        m_sync_tooltip.Active = False
        m_revert_tooltip.Active = False
    End Sub

    Public Sub EnableToolTips()
        m_move_up_tooltip.Active = True
        m_move_down_tooltip.Active = True
        m_add_row_tooltip.Active = True
        m_delete_rows_tooltip.Active = True
        m_show_data_codes_tooltip.Active = True
        m_sync_tooltip.Active = True
        m_revert_tooltip.Active = True
    End Sub

    ''' <summary>
    ''' Fetch the data from the database, and enable/disble buttons according to what was retreived.
    ''' </summary>
    Public Sub fetchData()
        Dim strQuery As String = "select * from " & m_table_name & " order by " & m_primary_key_field
        If m_row_order = RowOrderEnum.Ascending Then
            strQuery = strQuery & " asc"
        Else
            strQuery = strQuery & " desc"
        End If
        m_data_table = Database.GetDataTable(strQuery, m_table_name)
        grd.DataSource = m_data_table
        disableColumnSorting()
        m_curr_row = 0
        m_curr_col = 0
        If grd.Rows.Count > 0 Then
            If Not IsNothing(grd.FirstDisplayedCell) Then
                m_curr_row = grd.FirstDisplayedCell.RowIndex + 1
                If grd.ColumnCount > 0 Then
                    m_curr_col = grd.FirstDisplayedCell.ColumnIndex
                End If
            End If
        End If
        If grd.Rows.Count = 0 Then
            btnSync.Enabled = False
            btnRevert.Enabled = False
        Else
            btnSync.Enabled = True
            btnRevert.Enabled = True
        End If
        If m_curr_col <> 0 And m_curr_col < grd.ColumnCount Then
            grd.FirstDisplayedScrollingColumnIndex = m_curr_col
        End If
        setSynced()
    End Sub

    ''' <summary>
    ''' Hide the primary key column in the DataGridView
    ''' </summary>
    Private Sub grd_DataBindingComplete(sender As Object, e As EventArgs) Handles grd.DataBindingComplete
        If Not m_show_primary_key_field Then
            grd.Columns(m_primary_key_field).Visible = False
        End If
        grd.Enabled = True
        writePrimaryKeysInRowHeaders()
    End Sub

    ''' <summary>
    ''' Set the control to reflect that the DataGridView is synced with the database.
    ''' Set up the color array information to be all clean.
    ''' </summary>
    Private Sub setSynced()
        Dim tmpStruct As stcRowColoring
        ' Set up row coloring to be all clean
        m_arr_coloring.Clear()
        For row As Integer = 0 To grd.RowCount - 1
            tmpStruct = New stcRowColoring()
            tmpStruct.isDirty = False
            tmpStruct.dbPrimaryKey = CInt(m_data_table.Rows(row).Item(m_primary_key_field))
            tmpStruct.rowBackColor = CLEAN_BACKCOLOR
            tmpStruct.rowBackSelectColor = CLEAN_SELECTION_BACKCOLOR
            tmpStruct.cellForegroundCols = New List(Of Color)()
            tmpStruct.cellBackgroundCols = New List(Of Color)()
            For cell As Integer = 0 To grd.ColumnCount - 1
                tmpStruct.cellForegroundCols.Add(CLEAN_FORECOLOR)
                tmpStruct.cellBackgroundCols.Add(CLEAN_BACKCOLOR)
            Next
            m_arr_coloring.Add(tmpStruct)
        Next
        lblSync.ForeColor = Color.LimeGreen
        lblSync.Text = SYNCED_TEXT
        btnSync.Enabled = False
        btnRevert.Enabled = False
        btnAddRow.Enabled = True
        btnMoveUp.Enabled = True
        btnMoveDown.Enabled = True
        btnDeleteRows.Enabled = True
        m_synced = True
        grd_CellClick(New Object, New DataGridViewCellEventArgs(Nothing, Nothing))
        grd_SelectionChanged(New Object, EventArgs.Empty)
        RaiseEvent SyncedEvent()
    End Sub

    ''' <summary>
    ''' Set the control to reflect that the DataGridView is not synced with the database
    ''' </summary>
    Private Sub setUnsynced()
        lblSync.ForeColor = Color.Red
        lblSync.Text = UNSYNCED_TEXT
        btnSync.Enabled = True
        btnRevert.Enabled = True
        btnAddRow.Enabled = False
        btnMoveUp.Enabled = False
        btnMoveDown.Enabled = False
        btnDeleteRows.Enabled = False
        m_synced = False
        grd_CellClick(New Object, New DataGridViewCellEventArgs(Nothing, Nothing))
        grd_SelectionChanged(New Object, EventArgs.Empty)
        RaiseEvent UnsyncedEvent()
    End Sub

    ''' <summary>
    ''' Set the row headers to be the Primary key values, and make sure the header is wide enough.
    ''' </summary>
    Private Sub writePrimaryKeysInRowHeaders()
        If m_show_primary_key_field Then
            grd.RowHeadersWidth = ROW_HEADER_WIDTH
            For i As Integer = 0 To grd.Rows.Count - 1
                grd.Rows(i).HeaderCell.Value = grd.Rows(i).Cells(0).Value.ToString()
            Next
        End If
    End Sub

    ''' <summary>
    ''' Disable the ColumnSort feature in the DataGridView
    ''' </summary>
    Private Sub disableColumnSorting()
        For Each col As DataGridViewColumn In grd.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    ''' <summary>
    ''' Give column and row-specific error message to user if incorrect data type was entered.
    ''' Avoids errors/exceptions during the update to the database.
    ''' </summary>
    Private Sub grd_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grd.DataError
        Dim strFieldName As String = grd.Columns(e.ColumnIndex).HeaderText
        If strFieldName = BUTTON_FONT Or strFieldName = BUTTON_COLOR Then Exit Sub
        ' Set the cell to be clean because the DataError will noit allow you to leave the cell until you put in a good value
        setCell(e.RowIndex, e.ColumnIndex, CellStatus.Clean)
        ' Get Primary Key value and use that as row since the user can see it labelled on the row headers
        Dim row As Integer = CInt(grd.Rows(e.RowIndex).Cells(0).Value.ToString())
        Dim colType As String = m_data_table.Columns(e.ColumnIndex).DataType.ToString()
        MessageBox.Show("Error in column '" & strFieldName & "', row " & row & ": Value must be of type " &
        colType & ".", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    ''' Returns true if the row in the database for the supplied Primary Key 'intKey'
    ''' has exactly the same data as the row in the DataRow variable dr.
    ''' </summary>
    ''' <returns></returns>
    Private Function compareGridAndDatabaseRows(intKey As Integer, dr As DataRow) As Boolean
        Dim drDatabase = Database.GetDataRow(intKey, m_table_name)
        Dim i As Integer
        For i = 0 To dr.ItemArray.Length - 1
            If dr(i).ToString() <> drDatabase(i).ToString() Then
                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Apply the coloring to the DataGridView as laid out in the m_arr_coloring list
    ''' </summary>
    Private Sub applyColoring()
        Dim row As Integer
        Dim col As Integer
        For row = 0 To grd.RowCount - 1
            grd.Rows(row).DefaultCellStyle.BackColor = m_arr_coloring(row).rowBackColor
            grd.Rows(row).DefaultCellStyle.SelectionBackColor = m_arr_coloring(row).rowBackSelectColor
            For col = 0 To grd.ColumnCount - 1
                grd.Rows(row).Cells(col).Style.BackColor = m_arr_coloring(row).cellBackgroundCols(col)
                grd.Rows(row).Cells(col).Style.ForeColor = m_arr_coloring(row).cellForegroundCols(col)
            Next
        Next
    End Sub

    ''' <summary>
    ''' Set the coloring on the grid to reflect the status of the cell given by the
    ''' row and col coordinates in the DataGridView.
    ''' The background color for the whole row is also changed here.
    ''' </summary>
    Private Sub setCell(row As Integer, col As Integer, status As CellStatus)
        Dim tmpStruct As stcRowColoring
        If status = CellStatus.Clean Then
            If Not m_arr_coloring(row).isDirty Then
                tmpStruct = m_arr_coloring(row)
                tmpStruct.rowBackColor = CLEAN_BACKCOLOR
                tmpStruct.rowBackSelectColor = CLEAN_SELECTION_BACKCOLOR
                tmpStruct.cellBackgroundCols(col) = CLEAN_BACKCOLOR
                tmpStruct.cellForegroundCols(col) = CLEAN_FORECOLOR
                tmpStruct.isDirty = False
                m_arr_coloring(row) = tmpStruct
            End If
        Else
            tmpStruct = m_arr_coloring(row)
            tmpStruct.rowBackColor = DIRTY_ROW_BACKCOLOR
            tmpStruct.rowBackSelectColor = DIRTY_SELECTION_BACKCOLOR
            tmpStruct.cellBackgroundCols(col) = DIRTY_CELL_BACKCOLOR
            tmpStruct.cellForegroundCols(col) = DIRTY_FORECOLOR
            tmpStruct.isDirty = True
            m_arr_coloring(row) = tmpStruct
        End If
    End Sub

    ''' <summary>
    ''' Sets the coloring array to hold the primary key that is found in the database.
    ''' Only sets it if the row is not dirty, which means the database key was in the cell
    ''' before the edit happened.
    ''' </summary>
    Private Sub setPrimaryKey(row As Integer, intKey As Integer)
        Dim tmpStruct As stcRowColoring
        If Not m_arr_coloring(row).isDirty Then
            tmpStruct = m_arr_coloring(row)
            tmpStruct.dbPrimaryKey = intKey
            m_arr_coloring(row) = tmpStruct
        End If
    End Sub

    ''' <summary>
    ''' Gets the primary key from the coloring array. This will be the one that is actually in the
    ''' database, not the one currently appearing in the grid.
    ''' </summary>
    ''' <param name="row"></param>
    Private Function getPrimaryKey(row As Integer) As Integer
        Return m_arr_coloring(row).dbPrimaryKey
    End Function

    ''' <summary>
    ''' Store the database primary key for the cell being edited if it is a primary key cell.
    ''' </summary>
    Private Sub grd_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles grd.CellBeginEdit
        Dim colName As String = grd.Columns(e.ColumnIndex).Name
        If colName = m_primary_key_field Then
            setPrimaryKey(e.RowIndex, CInt(grd.Rows(e.RowIndex).Cells(e.ColumnIndex).Value))
        End If
        lblSync.ForeColor = Color.Red
        lblSync.Text = UNSYNCED_TEXT
        btnSync.Enabled = True
        btnRevert.Enabled = True
        btnAddRow.Enabled = False
        btnMoveUp.Enabled = False
        btnMoveDown.Enabled = False
        btnDeleteRows.Enabled = False
        btnSync.Enabled = False
        btnRevert.Enabled = False
    End Sub

    ''' <summary>
    ''' Compare the row's data to what is in the database table. If they are the same,
    ''' set the control to be synced with the database.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub grd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grd.CellValueChanged
        If IsNothing(m_arr_coloring) Or e.ColumnIndex = -1 Then
            Exit Sub
        End If
        Dim drvRow As DataRowView = DirectCast(grd.Rows(e.RowIndex).DataBoundItem, DataRowView)
        Dim dr As DataRow = drvRow.Row
        If compareGridAndDatabaseRows(getPrimaryKey(e.RowIndex), dr) Then
            setCell(e.RowIndex, e.ColumnIndex, CellStatus.Clean)
        Else
            setCell(e.RowIndex, e.ColumnIndex, CellStatus.Dirty)
        End If
        setUnsynced()
    End Sub

    ''' <summary>
    ''' Apply coloring to the grid whenever formatting takes place.
    ''' </summary>
    Private Sub grd_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles grd.CellFormatting
        applyColoring()
    End Sub

    ''' <summary>
    ''' When a cell is left, do a quick check to see if the values were left the same as what's in the
    ''' database. If they all are, make the row clean again.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub grd_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles grd.CellLeave
        Try
            Dim drvRow As DataRowView = DirectCast(grd.Rows(e.RowIndex).DataBoundItem, DataRowView)
            Dim dr As DataRow = drvRow.Row
            ' Get the primary key value in the row, so we can retrieve the correct database record to compare with
            Dim intKey As Integer = m_arr_coloring(e.RowIndex).dbPrimaryKey
            If compareGridAndDatabaseRows(intKey, dr) Then
                setCell(e.RowIndex, e.ColumnIndex, CellStatus.Clean)
                ' Set controls correctly dependinng on whether or not the grid was synced before this operation
                If m_synced Then
                    setSynced()
                Else
                    setUnsynced()
                End If
                RaiseEvent EndEditEvent(m_synced)
            End If
        Catch ex As Exception
            ' This empty try/catch is required because the CellLeave sub is called many times during the building of the
            ' grid and we only want to deal with it when the used actually does something.
        Finally
            ' If the cell contains a combobox, remove it leaving only the chosen item's text behind in the cell
            If TypeOf sender(e.ColumnIndex, e.RowIndex) Is DataGridViewComboBoxCell Then
                Dim cell As DataGridViewComboBoxCell = DirectCast(grd(e.ColumnIndex, e.RowIndex), DataGridViewComboBoxCell)
                cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            End If
        End Try

    End Sub

    ''' <summary>
    ''' Update the MS Access database table 'data' with values from the DataGridView object.
    ''' </summary>
    Private Sub updateDatabaseWithGridValues()
        Database.Update(m_data_table, m_table_name)
        fetchData()
    End Sub

    Private Sub deleteSelectedRowsHandler(sender As Object, e As EventArgs)
        deleteSelectedRows()
    End Sub

    ''' <summary>
    ''' Deletes selected rows from the MS access database as well as in the grid view. A confirmation box will verify this.
    ''' </summary>
    Public Sub deleteSelectedRows(Optional showWarning As Boolean = True)
        Dim blDoDelete As Boolean = False
        If grd.SelectedRows.Count = 0 Then
            MessageBox.Show("At least one row must be selected for a delete operation.",
                               "No rows selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If showWarning Then
            If MessageBox.Show("Are you sure you want to delete all selected rows from the database and save all changes to the database?",
                               "Delete rows and sync changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
                blDoDelete = True
            End If
        End If
        If blDoDelete Then
            For Each row As DataGridViewRow In grd.SelectedRows
                grd.Rows.Remove(row)
            Next
            updateDatabaseWithGridValues()
            RaiseEvent DataChanged()
        End If
    End Sub

    ''' <summary>
    ''' Key events for the data grid. The arrow keys will move to adjacent cells, the Enter key will submit the edit (if applicable)
    ''' and move to the next cell down or, if it is currently the last row, the next cell on the right, or if neither of those,
    ''' the top left-most cell. Pressing the 'delete' key will delete rows from the grid view and the database.
    ''' </summary>
    Private Sub grd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grd.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                deleteSelectedRows()
        End Select
    End Sub

    Private Sub grd_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles grd.UserDeletedRow
        If grd.Rows.Count = 0 Then
            fetchData()
        End If
    End Sub

    ''' <summary>
    ''' Allow keys to be captured while the editor is focussed on an individual cell
    ''' </summary>
    Private Sub grdVideoMinerDatabase_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles grd.EditingControlShowing
        If Not TypeOf sender Is TextBox Then Exit Sub
        Dim tb As TextBox = CType(e.Control, TextBox)
        AddHandler tb.PreviewKeyDown, AddressOf TextBox_PreviewKeyDown
    End Sub

    ''' <summary>
    ''' Sets up the Enter or Return key to be captured by the TextBox, which is a cell in the DataGridView.
    ''' This is the only way that the Enter key can be used to submit a value when editing a cell.
    ''' </summary>
    Private Sub TextBox_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            e.IsInputKey = True
        End If
    End Sub

    ''' <summary>
    ''' Captures right click in the DataGridView. This will delete rows from the grid view and the database.
    ''' </summary>
    ''' <remarks>If no rows are selected, a message will tell you to select rows and then press delete</remarks>
    Private Sub grd_RightClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grd.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim cms As ContextMenuStrip = New ContextMenuStrip
            Dim item1 As ToolStripItem
            If grd.SelectedRows.Count > 0 Then
                item1 = cms.Items.Add("Delete selected rows (or use delete key)")
                item1.Tag = 1
                AddHandler item1.Click, AddressOf deleteSelectedRowsHandler
            Else
                item1 = cms.Items.Add("Delete rows by selecting them and pressing delete.")
                item1.Tag = 1
            End If
            cms.Show(grd, e.Location)
        End If
    End Sub

    ''' <summary>
    ''' Validate the cell values if user makes them NULL. Avoids errors/exceptions during the update to the database.
    ''' </summary>
    Private Sub grd_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles grd.CellValidating
        ' Get column name from cell that was changed
        Dim strFieldName As String = grd.Columns(e.ColumnIndex).HeaderText
        Dim s As String = e.FormattedValue.ToString()
        Select Case strFieldName
            Case m_primary_key_field
                If s = NULL_STRING Then
                    MessageBox.Show("Error in column '" & m_primary_key_field & "', row " & e.RowIndex.ToString() &
                                    ": Value must be a non-null integer.", "Validation Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                Else
                    ' Check to see that the ID is unique in the grid to avoid exceptions when update query is run later
                    Dim isUnique As Boolean = True
                    For Each row As DataGridViewRow In grd.Rows
                        If Not row.IsNewRow Then
                            Dim cell As DataGridViewCell = row.Cells(m_primary_key_field)
                            ' Compare new and old values as long as it is not the same row
                            If cell.Value.ToString = e.FormattedValue.ToString And cell.RowIndex <> e.RowIndex Then
                                isUnique = False
                            End If
                        End If
                    Next
                    If Not isUnique Then
                        MessageBox.Show("Error in column '" & m_primary_key_field & "', row " & e.RowIndex.ToString() &
                                        ": The value is not unique. '" & m_primary_key_field & "' is the primary key and must have a unique value.",
                                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        e.Cancel = True
                    End If
                End If
            Case (DATA_CODE)
                If s = NULL_STRING Then
                    MessageBox.Show("Error in column 'DataCode', row " & e.RowIndex.ToString() & ": Value must be a non-null integer.",
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Reload the grid from the access database. A confirmation box will be displayed and if the user aggrees then any changes in the grid will
    ''' be discarded and the database will be reloaded from scratch
    ''' </summary>
    Private Sub btnRevertDatabase_Click(sender As Object, e As EventArgs) Handles btnRevert.Click
        If MessageBox.Show("Are you sure you want to discard all unsynced changes in the grid and revert to the database data?",
                           "Are you sure?", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            fetchData()
        End If
    End Sub

    Private Sub btnSync_Click(sender As Object, e As EventArgs) Handles btnSync.Click
        updateDatabaseWithGridValues()
        RaiseEvent DataChanged()
    End Sub

    ''' <summary>
    ''' Add a new empty row to the database and the DataGridView.
    ''' </summary>
    Private Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        Dim dr As DataRow
        Dim intNextKey As Integer = Database.GetNextPrimaryKeyValue(m_table_name)
        If intNextKey <= 0 Then
            ' The table is empty so we need to insert a n empty row with a primary key of 1
            intNextKey = 1
            dr = m_data_table.NewRow()
        Else
            ' The table is not empty, so we copy the last row and change the key to be the last
            ' row's key + 1
            dr = Database.GetRow(intNextKey - 1, m_table_name)
        End If
        dr.Item(m_primary_key_field) = intNextKey
        Database.InsertRow(dr, m_table_name)
        RaiseEvent DataChanged()
        fetchData()
    End Sub

    Private Sub btnDataCodes_Click(sender As Object, e As EventArgs) Handles btnDataCodes.Click
        m_frmViewDataTable.Show()
    End Sub

    ''' <summary>
    ''' Move the selected item up or down in the table, and raise the event to the parent.
    ''' The implmentation effectively swaps the two primary keys for the two records.
    ''' If there is more than one selected row, a messagebox will be issued and the event cancelled.
    ''' The variable direction is used to determine move direction Up or Down.
    ''' </summary>
    Private Sub moveRecord(direction As MoveDirection)
        Dim i As Integer
        Dim r As DataGridViewRow
        Dim dr As DataRow
        Dim intSelectedIndex As Integer
        Dim intCurrKey As Integer
        Dim intOtherKey As Integer
        If grd.SelectedRows.Count > 1 Then
            MessageBox.Show("Only one row can be selected for a move operation.",
                               "Too many rows selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If grd.SelectedRows.Count = 0 Then
            MessageBox.Show("A row must be selected for a move operation.",
                               "No rows selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        intSelectedIndex = grd.SelectedRows(0).Index
        Dim intStart, intEnd, intStep As Integer
        If direction = MoveDirection.Up Then
            If intSelectedIndex <= 0 Then
                ' Only move up if the item is not at the top
                Exit Sub
            End If
            intStart = 0
            intEnd = grd.RowCount - 1
            intStep = 1
            intSelectedIndex -= 1
        Else
            If intSelectedIndex >= grd.RowCount - 1 Then
                ' Only move down if the item is not at the bottom
                Exit Sub
            End If
            intStart = grd.RowCount - 1
            intEnd = 0
            intStep = -1
            intSelectedIndex += 1
        End If
        ' Get the primary keys for the selected item and the one above or below it
        For i = intStart To intEnd Step intStep
            r = grd.Rows(i)
            dr = m_data_table.Rows(r.Index)
            If r.Selected Then
                intCurrKey = CInt(dr.Item(m_primary_key_field))
                Exit For
            Else
                intOtherKey = CInt(dr.Item(m_primary_key_field))
            End If
        Next
        Database.SwapTwoRecords(intCurrKey, intOtherKey, m_table_name)
        fetchData()
        ' Set the selected row to be the same one that has just moved
        ' This allows user to move one item down or up quickly
        grd.ClearSelection()
        grd.Rows(intSelectedIndex).Selected = True
        RaiseEvent DataChanged()
    End Sub

    Private Sub btnMoveUp_Click(sender As Object, e As EventArgs) Handles btnMoveUp.Click
        moveRecord(MoveDirection.Up)
    End Sub

    Private Sub btnMoveDown_Click(sender As Object, e As EventArgs) Handles btnMoveDown.Click
        moveRecord(MoveDirection.Down)
    End Sub

    ''' <summary>
    ''' Returns a list of the currently selected rows.
    ''' </summary>
    ''' <returns>A list of DataRows. Nothing if there are no selected rows.</returns>
    Public Function getSelectedRowsPrimaryKeys() As List(Of DataRow)
        If grd.SelectedRows.Count = 0 Then
            Return Nothing
        End If
        Dim retList As List(Of DataRow) = New List(Of DataRow)()
        Dim tmp As DataGridViewSelectedRowCollection = grd.SelectedRows
        Dim dgvRow As DataRowView
        Dim dr As DataRow
        For i As Integer = 0 To tmp.Count - 1
            dgvRow = CType(tmp(i).DataBoundItem, DataRowView)
            dr = dgvRow.Row
            retList.Add(dr)
        Next
        Return retList
    End Function

    ''' <summary>
    ''' If the parent is being hidden, this will close the child datacodes form.
    ''' </summary>
    Public Sub parentHiding()
        If Not IsNothing(m_frmViewDataTable) Then
            m_frmViewDataTable.Close()
        End If
    End Sub

    Private Sub btnDeleteRows_Click(sender As Object, e As EventArgs) Handles btnDeleteRows.Click
        deleteSelectedRows()
    End Sub

    Private Sub setButtonDisabledEnabled()
        If grd.SelectedRows.Count = 0 Then
            btnDeleteRows.Enabled = False
            btnMoveUp.Enabled = False
            btnMoveDown.Enabled = False
        Else
            btnDeleteRows.Enabled = m_synced
            btnMoveUp.Enabled = m_synced
            btnMoveDown.Enabled = m_synced
        End If
    End Sub

    Private Sub grd_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd.CellClick
        setButtonDisabledEnabled()
        RaiseEvent CellClick()
    End Sub

    Private Sub grd_SelectionChanged(sender As Object, e As EventArgs) Handles grd.SelectionChanged
        setButtonDisabledEnabled()
        RaiseEvent SelectionChanged()
    End Sub

    ''' <summary>
    ''' Check which column the cell belongs to, if KeyboardShortcuts, launch the form to accept the new shortcut.
    ''' If Button color or button font, add a combobox for those and handle the drawing of them
    ''' in the cb_DataGridViewComboBoxCell_DrawItem subroutine.
    ''' </summary>
    Private Sub grd_CellBeginEditSpecialCells(sender As Object, e As DataGridViewCellCancelEventArgs) Handles grd.CellBeginEdit
        If grd.SelectedCells.Count <> 1 Then Exit Sub
        ' Get the name of the column which has the selected cell
        Dim strColname As String = grd.Columns(grd.SelectedCells(0).ColumnIndex).Name
        If strColname = KEYBOARD_SHORTCUT Then
            recordKeyboardShortcut()
        ElseIf strColname = BUTTON_COLOR Then
            recordButtonColor()
        ElseIf strColname = BUTTON_FONT Then
            recordButtonFont()
        End If
    End Sub

    ''' <summary>
    ''' Add a combobox to the currently selected cell, and add the installed font items to the combobox.
    ''' </summary>
    Private Sub recordButtonFont()
        Dim colIndex As Integer = grd.SelectedCells(0).ColumnIndex
        Dim rowIndex As Integer = grd.SelectedCells(0).RowIndex
        Dim cb As DataGridViewComboBoxCell = New DataGridViewComboBoxCell()
        Dim objFontFamily As FontFamily
        Dim objFontCollection As Text.FontCollection = New System.Drawing.Text.InstalledFontCollection()
        For Each objFontFamily In objFontCollection.Families
            cb.Items.Add(objFontFamily.Name)
        Next
        grd(colIndex, rowIndex) = cb
    End Sub

    ''' <summary>
    ''' This is required to properly cast the DataGridViewComboBoxCell into a ComboBox.
    ''' The cb_DataGridViewComboBoxCell_DrawItem sub will handle the drawing of the
    ''' comboboxes.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub grd_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grd.EditingControlShowing
        If TypeOf e.Control Is ComboBox Then
            Dim cb As ComboBox = TryCast(e.Control, ComboBox)
            cb.DrawMode = DrawMode.OwnerDrawFixed
            RemoveHandler cb.DrawItem, AddressOf cb_DataGridViewComboBoxCell_DrawItem
            AddHandler cb.DrawItem, AddressOf cb_DataGridViewComboBoxCell_DrawItem
        End If
    End Sub

    ''' <summary>
    ''' Draw each item of the combobox. For the BUTTON_FONT type, the font listed will be applied.
    ''' For the BUTTON_COLOR type, the color listed will be applied.
    ''' </summary>
    Private Sub cb_DataGridViewComboBoxCell_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs)
        If e.Index = -1 Then Exit Sub
        Dim strColname As String = grd.Columns(grd.SelectedCells(0).ColumnIndex).Name
        e.DrawBackground()
        If (e.State And DrawItemState.Focus) <> 0 Then
            e.DrawFocusRectangle()
        End If
        Dim cb As ComboBox = TryCast(sender, ComboBox)
        If IsNothing(cb) Then Exit Sub
        Dim objBrush As Brush = Nothing
        Try
            If strColname = BUTTON_FONT Then
                objBrush = New SolidBrush(e.ForeColor)
                Dim strFontName As String = cb.Items(e.Index).ToString()
                Dim fntFont As Font
                Dim fntFamily As FontFamily
                fntFamily = New FontFamily(strFontName)
                If fntFamily.IsStyleAvailable(FontStyle.Regular) Then
                    fntFont = New Font(fntFamily, 8, FontStyle.Regular)
                ElseIf fntFamily.IsStyleAvailable(FontStyle.Bold) Then
                    fntFont = New Font(fntFamily, 8, FontStyle.Bold)
                ElseIf fntFamily.IsStyleAvailable(FontStyle.Italic) Then
                    fntFont = New Font(fntFamily, 8, FontStyle.Italic)
                End If
                e.Graphics.DrawString(strFontName, fntFont, objBrush, e.Bounds)
            ElseIf strColname = BUTTON_COLOR Then
                Dim dt As DataTable = DirectCast(cb.DataSource, DataTable)
                e.Graphics.DrawString(dt.Rows(e.Index).Item("Color").ToString(), e.Font,
                                      New SolidBrush(Color.FromName(dt.Rows(e.Index).Item("Color").ToString())), e.Bounds)
            End If
        Catch

        Finally
            If Not IsNothing(objBrush) Then
                objBrush = Nothing
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Add a combobox to the currently selected cell, and add the colors listed in the lu_button_colors
    ''' database table to the combobox.
    ''' </summary>
    Private Sub recordButtonColor()
        Dim colIndex As Integer = grd.SelectedCells(0).ColumnIndex
        Dim rowIndex As Integer = grd.SelectedCells(0).RowIndex
        Dim cb As DataGridViewComboBoxCell = New DataGridViewComboBoxCell()
        With cb
            Dim strQuery As String = "select * from " & DB_BUTTON_COLORS_TABLE & " order by 1"
            Dim dt As DataTable = Database.GetDataTable(strQuery, DB_BUTTON_COLORS_TABLE)
            .DataSource = dt
            .DisplayMember = "Color"
            .ValueMember = "Color"
        End With
        grd(colIndex, rowIndex) = cb
    End Sub

    ''' <summary>
    ''' Launch a form to capture a keyboard shortcut combination and record the new value in the cell.
    ''' </summary>
    Private Sub recordKeyboardShortcut()
        ' Get the primary key for that row
        Dim strKey As String = Database.GetPrimaryKeyFieldName(m_table_name)
        Dim rowIndex As Integer = grd.SelectedCells(0).RowIndex
        Dim intKey As Integer = CInt(grd.Rows(rowIndex).Cells(strKey).Value.ToString())
        Dim dr As DataRow = Database.GetDataRow(intKey, m_table_name)
        m_frmCreateKeyboardShortcut = New frmCreateKeyboardShortcut()
        m_frmCreateKeyboardShortcut.ButtonText = m_table_name
        m_frmCreateKeyboardShortcut.KeyboardShortcut = dr(KEYBOARD_SHORTCUT).ToString()
        m_frmCreateKeyboardShortcut.ShowDialog()
        grd.Rows(rowIndex).Cells(KEYBOARD_SHORTCUT).Value = m_frmCreateKeyboardShortcut.KeyboardShortcut
    End Sub
End Class
