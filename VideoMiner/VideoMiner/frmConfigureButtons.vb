Public Class frmConfigureButtons

#Region "Member variables"
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
#End Region

#Region "Events"
    Public Event DatabaseModifiedEvent()
#End Region

    ''' <summary>
    ''' Initialize the query, and extract the data that query defines into a DataSet with corresponding DataTable.
    ''' Populate the list and set up list attributes.
    ''' </summary>
    Public Sub New(strConfigureTable As String, strPanelName As String)
        InitializeComponent()
        m_table_name = strConfigureTable
        m_grd = New VideoMinerDataGridView(m_table_name, True)
        btnMoveToPanel.Text = "Move to " & strPanelName
        Panel4.Controls.Add(m_grd)
        m_grd.Dock = DockStyle.Fill
    End Sub

    Private Sub frmConfigureButtons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_has_modifications = False
    End Sub

    Private Sub m_grd_DataChanged() Handles m_grd.DataChanged
        m_has_modifications = True
        btnOK.Text = "Redraw buttons"
    End Sub

    ''' <summary>
    ''' Selected rows will be moved to the other panel.
    ''' </summary>
    Private Sub moveToPanel()
        Dim strMoveToTable As String
        Dim d As DataTable
        Dim r As DataRow
        If m_table_name = DB_HABITAT_BUTTONS_TABLE Then
            strMoveToTable = DB_TRANSECT_BUTTONS_TABLE
        Else
            strMoveToTable = DB_HABITAT_BUTTONS_TABLE
        End If
        Dim strKeyName As String = Database.GetPrimaryKeyFieldName(m_table_name)
        Dim lstSelectedKeys As List(Of DataRow) = m_grd.getSelectedRowsPrimaryKeys()
        If IsNothing(lstSelectedKeys) Then
            MessageBox.Show("A row must be selected for a move operation.",
                            "No rows selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        d = Database.GetDataTable("select * from " & m_table_name, m_table_name)
        Dim intLastKey As Integer
        Dim intNextKey As Integer
        m_grd.DGV.DataSource = Nothing
        For i As Integer = lstSelectedKeys.Count - 1 To 0 Step -1
            r = lstSelectedKeys(i)
            intLastKey = CInt(r.Item(strKeyName))
            intNextKey = Database.GetNextPrimaryKeyValue(strMoveToTable)
            If intNextKey = -1 Then
                ' The table had no rows in it, so start with a primary key of 1
                intNextKey = 1
            End If
            r.Item(strKeyName) = intNextKey
            If Not Database.InsertRow(r, strMoveToTable) Then
                MessageBox.Show("The database insert operation failed when trying to move the record to the " & strMoveToTable & " table",
                                "Insert failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If Not Database.DeleteRow(intLastKey, m_table_name) Then
                MessageBox.Show("The database delete operation failed when trying to move the record to the " & strMoveToTable & " table",
                                "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Next
        m_grd_DataChanged()
        m_grd.fetchData()
    End Sub

    ''' <summary>
    ''' Clicking this button results in the selected rows being moved to the other panel.
    ''' The database will also have the entries moved from one button table to the other.
    ''' </summary>
    Private Sub btnMoveToPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveToPanel.Click
        moveToPanel()
    End Sub

    ''' <summary>
    ''' Fire an event if there have been modifications so that the parent can redraw the buttons.
    ''' </summary>
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If m_has_modifications Then
            RaiseEvent DatabaseModifiedEvent()
        End If
        ' Tell the VideoMinerDataGridView that the form is closing, so it can close any child forms as well.
        m_grd.parentHiding()
        Hide()
    End Sub

    Private Sub m_grd_BeginEdit() Handles m_grd.BeginEditEvent
        setUnSynced()
    End Sub

    Private Sub m_grd_EndEdit(blSynced As Boolean) Handles m_grd.EndEditEvent
        If blSynced Then
            setSynced()
        Else
            setUnSynced()
        End If
    End Sub

    ''' <summary>
    ''' Set the buttons to indicate that the data are synced with the database
    ''' </summary>
    Private Sub setSynced() Handles m_grd.SyncedEvent
        btnMoveToPanel.Enabled = True
        btnOK.Enabled = True
    End Sub

    ''' <summary>
    ''' Set the buttons to indicate that the data are unsynced with the database
    ''' </summary>
    Private Sub setUnSynced() Handles m_grd.UnsyncedEvent
        btnMoveToPanel.Enabled = False
        btnOK.Enabled = False
    End Sub
End Class