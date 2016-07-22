Public Class frmConfigureButtons

#Region "Member variables"
    Private WithEvents m_frmAddButton As frmAddButton
    Private m_table_name As String
    Private m_data_table As DataTable
    Private m_ButtonName As String
    Private m_TableName As String
    Private m_DataCode As Integer
    Private m_FieldName As String
    Private m_DrawingOrder As String
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
    Public Event UpdateButtonDrawingOrder()
    Public Event UpdateButtons()
    Public Event RefreshDatabaseEvent()
#End Region

#Region "Properties"
    Public Property ButtonName() As String
        Get
            Return m_ButtonName
        End Get
        Set(ByVal value As String)
            m_ButtonName = value
        End Set
    End Property

    Public Property TableName() As String
        Get
            Return m_TableName
        End Get
        Set(ByVal value As String)
            m_TableName = value
        End Set
    End Property

    Public Property DataCode() As Integer
        Get
            Return m_DataCode
        End Get
        Set(ByVal value As Integer)
            m_DataCode = value
        End Set
    End Property

    Public Property FieldName() As String
        Get
            Return m_FieldName
        End Get
        Set(ByVal value As String)
            m_FieldName = value
        End Set
    End Property

    Public Property DrawingOrder() As Integer
        Get
            Return m_DrawingOrder
        End Get
        Set(ByVal value As Integer)
            m_DrawingOrder = value
        End Set
    End Property
#End Region

    ''' <summary>
    ''' Initialize the query, and extract the data that query defines into a DataSet with corresponding DataTable.
    ''' Populate the list and set up list attributes.
    ''' </summary>
    Public Sub New(strConfigureTable As String)
        InitializeComponent()
        m_table_name = strConfigureTable
    End Sub

    Private Sub frmConfigureButtons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateTableList()
    End Sub

    ''' <summary>
    ''' Fill the listbox with the current m_table_name table.
    ''' </summary>
    Private Sub populateTableList()
        Dim strKeyName As String = Database.GetPrimaryKeyFieldName(m_table_name)
        m_data_table = Database.GetDataTable("select * from " & m_table_name & " order by " & strKeyName & " Asc", m_table_name)
        grdButtons.DataSource = m_data_table
        ' See grdButtons_DataBindingComplete function for hiding the primary key field
    End Sub

    ''' <summary>
    ''' Remove the Primary Key column from the view, so that users cannot change it
    ''' </summary>
    Private Sub grdButtons_DataBindingComplete(sender As Object, e As EventArgs) Handles grdButtons.DataBindingComplete
        ' Remove primary key field from the table which is shown
        Dim strPrimaryKeyName = Database.GetPrimaryKeyFieldName(m_table_name)
        grdButtons.Columns(strPrimaryKeyName).Visible = False
        grdButtons.Enabled = True
    End Sub


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
        If grdButtons.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a button from the table",
                            "No selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        intSelectedIndex = grdButtons.SelectedRows(0).Index
        Dim strKeyField As String = Database.GetPrimaryKeyFieldName(m_table_name)
        Dim intStart, intEnd, intStep As Integer
        If m_move_direction = MoveDirection.Up Then
            If intSelectedIndex <= 0 Then
                ' Only move up if the item is not at the top
                Exit Sub
            End If
            intStart = 0
            intEnd = grdButtons.Rows.Count - 1
            intStep = 1
            intSelectedIndex -= 1
        Else
            If intSelectedIndex >= grdButtons.Rows.Count - 1 Then
                ' Only move down if the item is not at the bottom
                Exit Sub
            End If
            intStart = grdButtons.Rows.Count - 1
            intEnd = 0
            intStep = -1
            intSelectedIndex += 1
        End If
        ' Get the primary keys for the selected item and the one above or below it
        For i = intStart To intEnd Step intStep
            r = grdButtons.Rows(i)
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
        grdButtons.ClearSelection()
        grdButtons.Rows(intSelectedIndex).Selected = True
    End Sub

    ''' <summary>
    ''' Clicking this button will bring up the 'add button' dialog which allows the definition of a new button.
    ''' </summary>
    Private Sub cmdCreateNewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateNewButton.Click
        m_frmAddButton = New frmAddButton(m_table_name)
        m_frmAddButton.ShowDialog()
    End Sub

    ''' <summary>
    ''' Clicking this button will bring up the 'add button' dialog which will allow the editing of the current button's attributes.
    ''' </summary>
    Private Sub cmdEditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditButton.Click
        If grdButtons.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a button from the list", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'blButtonEdit = True
        m_frmAddButton = New frmAddButton(m_table_name)
        'frmAddButton.Text = "Edit " & Me.lstButtons.SelectedItems.Item(0).SubItems(1).Text.ToString & " Button"
        'frmAddButton.txtButtonName.Text = Me.lstButtons.SelectedItems.Item(0).SubItems(1).Text.ToString
        m_frmAddButton.ShowDialog()
        populateTableList()
    End Sub

    ''' <summary>
    ''' Pressing this button will Hide the dialog
    ''' </summary>
    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click
        'Me.UpdateDrawingOrder()
        Me.Hide()
    End Sub

    ''' <summary>
    ''' When the database has been modified by a child form, this will refresh the DataGridView
    ''' </summary>
    Private Sub frmAddButton_DatabaseModifiedHandler() Handles m_frmAddButton.DatabaseModifedEvent
        populateTableList()
    End Sub

    ''' <summary>
    ''' Clicking this button will remove the selected button from the project, including from the database.
    ''' </summary>
    Private Sub cmdDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteButton.Click
        Dim r As DataGridViewRow
        Dim dr As DataRow
        Dim intSelectedIndex As Integer
        Dim intKey As Integer
        If grdButtons.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a button from the table",
                            "No selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        intSelectedIndex = grdButtons.SelectedRows(0).Index
        Dim strKeyField As String = Database.GetPrimaryKeyFieldName(m_table_name)
        If MessageBox.Show("Are you sure you want to delete this button?",
                           "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        ' Get the primary keys for the selected item and the one above or below it
        For i As Integer = 0 To grdButtons.Rows.Count - 1
            r = grdButtons.Rows(i)
            dr = m_data_table.Rows(r.Index)
            If r.Selected Then
                intKey = CInt(dr.Item(strKeyField))
                Exit For
            End If
        Next
        Database.DeleteRow(intKey, m_table_name)
        populateTableList()
        grdButtons.ClearSelection()
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
        Dim selIdx As Integer
        Try
            ' selIdx = Me.lstButtons.SelectedIndices.Item(0)
        Catch ex As Exception
            selIdx = 0
        End Try
        If grdButtons.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a button from the list", "No selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            'If MessageBox.Show("Are you sure you want to move the " & Me.lstButtons.Items(selIdx).SubItems(1).Text &
            '                   " button to " & strMoveToPanel & "?", "Move Button", MessageBoxButtons.YesNo,
            'MessageBoxIcon.Question) = vbNo Then
            'Exit Sub
        End If
        'End If
        'm_ButtonName = Me.lstButtons.Items(selIdx).SubItems(1).Text
        Dim strKeyName As String = Database.GetPrimaryKeyFieldName(m_table_name)

        ' Get the source table's information
        d = Database.GetDataTable("select * from " & m_table_name, m_table_name)
        For Each r In d.Rows
            If r.Item(BUTTON_TEXT).ToString() = m_ButtonName Then
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
        RaiseEvent RefreshDatabaseEvent()
    End Sub

End Class