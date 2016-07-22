Public Class frmConfigureButtons

#Region "Member variables"
    Private WithEvents m_frmAddButton As frmAddButton
    Private WithEvents m_grd As VideoMinerDataGridView
    ''' <summary>
    ''' The name of the table which this form represents, either
    ''' videominer_habitat_buttons or videominer_transect_buttons
    ''' </summary>
    Private m_table_name As String
    ''' <summary>
    ''' The data table containing the contents of the table given by m_table_name
    ''' </summary>
    Private m_data_table As DataTable
    Private m_button_name As String
    Private m_data_code As Integer
    Private m_field_name As String
    Private m_has_modifications As Boolean
    ''' <summary>
    ''' Enumeration describing which way to move the button definition in the list
    ''' </summary>
    Private Enum MoveDirection
        Up
        Down
    End Enum
    Private m_move_direction As MoveDirection
#End Region

#Region "Events"
    Public Event DatabaseModifiedEvent()
#End Region

    ''' <summary>
    ''' Initialize the query, and extract the data that query defines into a DataSet with corresponding DataTable.
    ''' Populate the list and set up list attributes.
    ''' </summary>
    Public Sub New(strConfigureTable As String)
        InitializeComponent()
        m_table_name = strConfigureTable
        m_grd = New VideoMinerDataGridView(m_table_name, False)
        Panel4.Controls.Add(m_grd)
    End Sub

    Private Sub frmConfigureButtons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '        populateTableList()
        m_has_modifications = False
    End Sub

    ''' <summary>
    ''' Fill the listbox with the current m_table_name table.
    ''' </summary>
    Private Sub populateTableList()
        'Dim strKeyName As String = Database.GetPrimaryKeyFieldName(m_table_name)
        'm_data_table = Database.GetDataTable("select * from " & m_table_name & " order by " & strKeyName & " Asc", m_table_name)
        'm_grd.DataSource = m_data_table
        '' See m_grd_DataBindingComplete function for hiding the primary key field
    End Sub

    ''' <summary>
    ''' Remove the Primary Key column from the view, so that users cannot change it
    ''' </summary>
    'Private Sub m_grd_DataBindingComplete(sender As Object, e As EventArgs) Handles m_grd.DataBindingComplete
    ' Remove primary key field from the table which is shown
    'Dim strPrimaryKeyName = Database.GetPrimaryKeyFieldName(m_table_name)
    'm_grd.Columns(strPrimaryKeyName).Visible = False
    'm_grd.Enabled = True
    'End Sub

    ''' <summary>
    ''' Clicking this button causes the currently selected item to move up one in the list.
    ''' The database will be modified; the primary keys for the item selected and the one above it
    ''' will be swapped.
    ''' </summary>
    Private Sub cmdMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveUp.Click
        m_move_direction = MoveDirection.Up
        moveRecord()
    End Sub

    ''' <summary>
    ''' Clicking this button causes the currently selected item to move down one in the list.
    ''' The database will be modified; the primary keys for the item selected and the one below it
    ''' will be swapped.
    ''' </summary>
    Private Sub cmdMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveDown.Click
        m_move_direction = MoveDirection.Down
        moveRecord()
    End Sub

    ''' <summary>
    ''' Move the first selected item up or down in order, and raise the event to the main form so that the buttons can
    ''' be redrawn to correspond to the new order.
    ''' The variable m_move_direction is used to determine move direction Up or Down.
    ''' This is accomplished by swapping the primary keys for the two records in the database.
    ''' </summary>
    Private Sub moveRecord()
        Dim i As Integer
        Dim r As DataGridViewRow
        Dim dr As DataRow
        Dim intSelectedIndex As Integer
        Dim intCurrKey As Integer
        Dim intOtherKey As Integer
        'If m_grd.SelectedRows.Count = 0 Then
        'MessageBox.Show("Please select a button from the table",
        '                   "No selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If
        intSelectedIndex = m_grd.FirstSelectedRowIndex
        Dim strKeyField As String = Database.GetPrimaryKeyFieldName(m_table_name)
        Dim intStart, intEnd, intStep As Integer
        If m_move_direction = MoveDirection.Up Then
            If intSelectedIndex <= 0 Then
                ' Only move up if the item is not at the top
                Exit Sub
            End If
            intStart = 0
            intEnd = m_grd.RowCount - 1
            intStep = 1
            intSelectedIndex -= 1
        Else
            If intSelectedIndex >= m_grd.RowCount - 1 Then
                ' Only move down if the item is not at the bottom
                Exit Sub
            End If
            intStart = m_grd.RowCount - 1
            intEnd = 0
            intStep = -1
            intSelectedIndex += 1
        End If
        ' Get the primary keys for the selected item and the one above or below it
        For i = intStart To intEnd Step intStep
            r = m_grd.Rows(i)
            dr = m_data_table.Rows(r.Index)
            If r.Selected Then
                intCurrKey = CInt(dr.Item(strKeyField))
                Exit For
            Else
                intOtherKey = CInt(dr.Item(strKeyField))
            End If
        Next
        Database.SwapTwoRecords(intCurrKey, intOtherKey, m_table_name)
        populateTableList()
        ' Set the selected row to be the same one that has just moved
        ' This allows user to move one item down or up quickly
        'm_grd.ClearSelection()
        'm_grd.Rows(intSelectedIndex).Selected = True
        m_has_modifications = True
    End Sub

    ''' <summary>
    ''' Clicking this button will bring up the 'add button' dialog which allows the definition of a new button.
    ''' </summary>
    Private Sub cmdCreateNewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateNewButton.Click
        m_frmAddButton = New frmAddButton(m_table_name)
        m_frmAddButton.ShowDialog()
    End Sub

    ''' <summary>
    ''' When the database has been modified by a child form, this will refresh the DataGridView
    ''' </summary>
    Private Sub frmAddButton_DatabaseModifiedHandler() Handles m_frmAddButton.DatabaseModifedEvent
        populateTableList()
        m_has_modifications = True
    End Sub

    ''' <summary>
    ''' Clicking this button will remove the selected button from the project, including from the database.
    ''' </summary>
    Private Sub cmdDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteButton.Click
        Dim r As DataGridViewRow
        Dim dr As DataRow
        Dim intSelectedIndex As Integer
        Dim intKey As Integer
        If m_grd.SelectedRowCount = 0 Then
            MessageBox.Show("Please select a button from the table",
                            "No selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        intSelectedIndex = m_grd.FirstSelectedRowIndex
        Dim strKeyField As String = Database.GetPrimaryKeyFieldName(m_table_name)
        If MessageBox.Show("Are you sure you want to delete this button?",
                           "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        ' Get the primary keys for the selected item and the one above or below it
        For i As Integer = 0 To m_grd.RowCount - 1
            r = m_grd.Rows(i)
            dr = m_data_table.Rows(r.Index)
            If r.Selected Then
                intKey = CInt(dr.Item(strKeyField))
                Exit For
            End If
        Next
        Database.DeleteRow(intKey, m_table_name)
        populateTableList()
        m_grd.ClearSelection()
        m_has_modifications = True
    End Sub

    ''' <summary>
    ''' Clicking this button results in the first selected button being moved to the other panel.
    ''' The database will also have the entry moved from one button table to the other.
    ''' </summary>
    Private Sub cmdMoveToPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveToPanel.Click
        Dim strMoveToTable As String
        Dim strMoveToPanel As String
        Dim d As DataTable
        Dim r As DataRow

        If m_table_name = DB_HABITAT_BUTTONS_TABLE Then
            strMoveToTable = DB_TRANSECT_BUTTONS_TABLE
            strMoveToPanel = "TRANSECT DATA"
        Else
            strMoveToTable = DB_HABITAT_BUTTONS_TABLE
            strMoveToPanel = "HABITAT DATA"
        End If
        Dim strKeyName As String = Database.GetPrimaryKeyFieldName(m_table_name)

        ' Get the source table's information
        d = Database.GetDataTable("select * from " & m_table_name, m_table_name)
        For Each r In d.Rows
            If r.Item(BUTTON_TEXT).ToString() = m_button_name Then
                Exit For
            End If
        Next
        ' At this point, r is a DataRow holding the button's record. The primary key needs to be changed
        ' to fit into the other table.
        Dim intLastKey As Integer = CInt(r.Item(strKeyName))
        Dim intNextKey As Integer = Database.GetNextPrimaryKeyValue(strMoveToTable)
        r.Item(strKeyName) = intNextKey
        d = Database.GetDataTable("select * from " & strMoveToTable, strMoveToTable)
        Database.InsertRow(r, strMoveToTable)
        Database.DeleteRow(intLastKey, m_table_name)
        populateTableList()
        m_has_modifications = True
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If m_has_modifications Then
            RaiseEvent DatabaseModifiedEvent()
        End If
        Hide()
    End Sub

    Private Sub me_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            If m_has_modifications Then
                RaiseEvent DatabaseModifiedEvent()
            End If
            Hide()
        End If
    End Sub

End Class