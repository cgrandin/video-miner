Public Class frmConfigureButtons

#Region "Member variables"
    Private frmAddButton As frmAddButton
    Private m_table_name As String
    Private m_data_table As DataTable
    Private m_ButtonName As String
    Private m_TableName As String
    Private m_DataCode As Integer
    Private m_FieldName As String
    Private m_DrawingOrder As String
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
    Public Sub New()
        InitializeComponent()
        m_table_name = strConfigureTable
        m_data_table = Database.GetDataTable("select * from " & m_table_name & " order by DrawingOrder Asc;", m_table_name)
        'grdEditTable.DataSource = m_data_table
        Dim itm As ListViewItem
        For Each r As DataRow In m_data_table.Rows
            itm = New ListViewItem
            itm.Text = ""
            itm.SubItems.Add(r.Item("ButtonText").ToString())
            itm.SubItems.Add(r.Item("TableName").ToString())
            Me.lstButtons.Items.Add(itm)
        Next
        With Me.lstButtons
            .Visible = True
            .FullRowSelect = True
            .View = View.Details
            .HeaderStyle = ColumnHeaderStyle.Nonclickable
            .HideSelection = False
            .Focus()
            .Columns.Add("", 0, HorizontalAlignment.Left)
            .Columns.Add("Button Text", 150, HorizontalAlignment.Left)
            .Columns.Add("Referenced Table", 150, HorizontalAlignment.Left)
        End With
    End Sub

    ''' <summary>
    ''' Clicking this button calls the function that moves the first selected item up in the list, and raises the event to the main form so that the buttons can
    ''' be redrawn to correspond to the new order.
    ''' </summary>
    Private Sub cmdMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveUp.Click
        If Me.lstButtons.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstButtons.SelectedItems(0).Index
            MoveListViewItem(True)
        Else
            MessageBox.Show("Please select a button from the list", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Clicking this button calls the function that moves the first selected item down in the list, and raises the event to the main form so that the buttons can
    ''' be redrawn to correspond to the new order.
    ''' </summary>
    Private Sub cmdMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveDown.Click
        If Me.lstButtons.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstButtons.SelectedItems(0).Index
            MoveListViewItem(False)
        Else
            MessageBox.Show("Please select a button from the list", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Move the first selected item up in the list, and raise the event to the main form so that the buttons can
    ''' be redrawn to correspond to the new order.
    ''' </summary>
    ''' <param name="moveUp">If true, the item will be moved up the list (when possible). If false, it will be moved down (when possible)</param>
    Private Sub MoveListViewItem(ByVal moveUp As Boolean)
        Dim i As Integer
        Dim cache As String
        Dim selIdx As Integer
        With Me.lstButtons
            If .SelectedIndices.Count = 0 Then
                Exit Sub
            Else
                selIdx = .SelectedIndices.Item(0)
            End If
            If moveUp Then
                ' ignore moveup of row(0)
                If selIdx = 0 Then
                    Exit Sub
                End If
                ' move the subitems for the previous row
                ' to cache so we can move the selected row up
                Dim strFields As String = ""
                For i = 0 To .Items(selIdx).SubItems.Count - 1
                    cache = .Items(selIdx - 1).SubItems(i).Text
                    .Items(selIdx - 1).SubItems(i).Text = .Items(selIdx).SubItems(i).Text
                    .Items(selIdx).SubItems(i).Text = cache
                Next
                .Items(selIdx - 1).Selected = True
                .Items(selIdx - 1).Focused = True
                .EnsureVisible(selIdx - 1)
                .Refresh()
                .Focus()
            Else
                ' ignore move down of last row
                If selIdx = .Items.Count - 1 Then
                    Exit Sub
                End If
                ' move the subitems for the next row
                ' to cache so we can move the selected row down
                For i = 0 To .Items(selIdx).SubItems.Count - 1
                    cache = .Items(selIdx + 1).SubItems(i).Text
                    .Items(selIdx + 1).SubItems(i).Text = .Items(selIdx).SubItems(i).Text
                    .Items(selIdx).SubItems(i).Text = cache
                Next
                .Items(selIdx + 1).Selected = True
                .Items(selIdx + 1).Focused = True
                .EnsureVisible(selIdx)
                .Refresh()
                .Focus()
            End If
        End With
        UpdateDrawingOrder(m_table_name)
    End Sub

    ''' <summary>
    ''' Clicking this button will bring up the 'add button' dialog which allows the definition of a new button.
    ''' </summary>
    Private Sub cmdCreateNewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateNewButton.Click
        Me.UpdateDrawingOrder(m_table_name)
        frmAddButton = New frmAddButton
        frmAddButton.ShowDialog()
    End Sub

    ''' <summary>
    ''' Clicking this button will bring up the 'add button' dialog which will allow the editing of the current button's attributes.
    ''' </summary>
    Private Sub cmdEditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditButton.Click
        If Me.lstButtons.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a button from the list", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        blButtonEdit = True
        frmAddButton = New frmAddButton
        frmAddButton.Text = "Edit " & Me.lstButtons.SelectedItems.Item(0).SubItems(1).Text.ToString & " Button"
        frmAddButton.txtButtonName.Text = Me.lstButtons.SelectedItems.Item(0).SubItems(1).Text.ToString
        'Me.UpdateDrawingOrder(m_table_name)
        frmAddButton.ShowDialog()
    End Sub

    ''' <summary>
    ''' Pressing this button will Hide the dialog
    ''' </summary>
    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click
        'Me.UpdateDrawingOrder()
        Me.Hide()
    End Sub

    ''' <summary>
    ''' Changes the database values for the 'DrawingOrder' field to reflect the change in drawing order.
    ''' </summary>
    Private Sub UpdateDrawingOrder(ByVal strTable As String)
        Dim strButtonName As String
        Dim d As DataTable
        Database.ExecuteNonQuery("UPDATE " & strTable & " SET DrawingOrder = DrawingOrder + 1000")
        If strTable = m_table_name Then
            For i As Integer = 0 To Me.lstButtons.Items.Count - 1
                strButtonName = Me.lstButtons.Items(i).SubItems(1).Text
                Database.ExecuteNonQuery("UPDATE " & strTable & " SET DrawingOrder = " & i + 1 & " WHERE ButtonText = " & SingleQuote(strButtonName))
            Next
        Else
            d = Database.GetDataTable("SELECT ButtonText FROM " & strTable & " ORDER BY DrawingOrder ASC", strTable)
            Dim i As Integer = 0
            For Each r As DataRow In d.Rows
                strButtonName = r.Item("ButtonText")
                Database.ExecuteNonQuery("UPDATE " & strTable & " SET DrawingOrder = " & i + 1 & " WHERE ButtonText = " & SingleQuote(strButtonName))
                i += 1
            Next
        End If
        RaiseEvent RefreshDatabaseEvent()
        RaiseEvent UpdateButtons()
    End Sub

    ''' <summary>
    ''' Clicking this button will remove the selected button from the project, including from the database.
    ''' </summary>
    Private Sub cmdDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteButton.Click
        Dim d As DataTable
        Dim selIdx As Integer
        Try
            selIdx = Me.lstButtons.SelectedIndices.Item(0)
        Catch ex As Exception
            selIdx = 0
        End Try

        If Me.lstButtons.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a button from the list", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.ButtonName = Me.lstButtons.Items(selIdx).SubItems(1).Text
        d = Database.GetDataTable("select * from " & m_table_name, m_table_name)
        For Each r As DataRow In d.Rows
            If r.Item("ButtonText") = Me.ButtonName Then
                Me.FieldName = r.Item("DataCodeName")
                Me.DataCode = r.Item("DataCode")
                Exit For
            End If
        Next
        If MessageBox.Show("By deleting this button the field '" & Me.FieldName & "' will be removed from the '" & DB_DATA_TABLE & "' table in the database.  Are you sure you want to delete this button?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Database.ExecuteNonQuery("DELETE * FROM " & m_table_name & " WHERE ButtonText = " & SingleQuote(Me.ButtonName))
        Me.UpdateDrawingOrder(m_table_name)
        'RefreshDatabase(Me, New EventArgs)
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
            selIdx = Me.lstButtons.SelectedIndices.Item(0)
        Catch ex As Exception
            selIdx = 0
        End Try
        If Me.lstButtons.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a button from the list", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If MessageBox.Show("Are you sure you want to move the " & Me.lstButtons.Items(selIdx).SubItems(1).Text & " button to " & strMoveToPanel & "?", "Move Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
                Exit Sub
            End If
        End If
        Me.ButtonName = Me.lstButtons.Items(selIdx).SubItems(1).Text
        d = Database.GetDataTable("select * from " & m_table_name, m_table_name)
        Dim strQuery As String = "select * from " & m_table_name
        For Each r In d.Rows
            If r.Item("ButtonText") = Me.ButtonName Then
                Me.FieldName = r.Item("DataCodeName")
                Me.DataCode = r.Item("DataCode")
                Me.TableName = r.Item("TableName")
                Exit For
            End If
        Next
        d = Database.GetDataTable("SELECT * FROM " & strMoveToTable & ";", strMoveToTable)
        Dim intValue As Integer = 0
        For i As Integer = 0 To d.Rows.Count - 1
            r = m_data_table.Rows.Item(i)
            If CInt(r.Item("DrawingOrder")) > intValue Then
                intValue = CInt(r.Item("DrawingOrder"))
            End If
        Next
        Me.DrawingOrder = intValue + 1
        Database.ExecuteNonQuery("INSERT INTO " & strMoveToTable & "(DrawingOrder, ButtonText, TableName, DataCode, DataCodeName, ButtonColor) " & _
                    "VALUES (" & Me.DrawingOrder & ", " & SingleQuote(Me.ButtonName) & ", " & SingleQuote(Me.TableName) & ", " & Me.DataCode & ", " & SingleQuote(Me.FieldName) & ", 'DarkBlue')")
        Database.ExecuteNonQuery("DELETE * FROM " & m_table_name & " " & _
                "WHERE ButtonText = " & SingleQuote(Me.ButtonName))
        Me.UpdateDrawingOrder(strMoveToTable)
        If strMoveToTable = DB_TRANSECT_BUTTONS_TABLE Then
            dictTransectFieldValues.Add(Me.ButtonName, Me.DataCode)
            dictHabitatFieldValues.Remove(Me.ButtonName)
        Else
            dictTransectFieldValues.Remove(Me.ButtonName)
            dictHabitatFieldValues.Add(Me.ButtonName, Me.DataCode)
        End If
        RaiseEvent RefreshDatabaseEvent()
    End Sub
End Class