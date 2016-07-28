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
    Public Sub New(strConfigureTable As String)
        InitializeComponent()
        m_table_name = strConfigureTable
        m_grd = New VideoMinerDataGridView(m_table_name, True)
        Panel4.Controls.Add(m_grd)
        m_grd.Dock = DockStyle.Fill
    End Sub

    Private Sub frmConfigureButtons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_has_modifications = False
    End Sub

    Private Sub m_grd_DataChanged() Handles m_grd.DataChanged
        m_has_modifications = True
    End Sub
    ''' <summary>
    ''' Clicking this button results in the selected rows being moved to the other panel.
    ''' The database will also have the entries moved from one button table to the other.
    ''' </summary>
    Private Sub cmdMoveToPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveToPanel.Click

        Dim strMoveToTable As String
        'Dim strMoveToPanel As String
        Dim d As DataTable
        Dim r As DataRow

        If m_table_name = DB_HABITAT_BUTTONS_TABLE Then
            strMoveToTable = DB_TRANSECT_BUTTONS_TABLE
            'strMoveToPanel = "TRANSECT DATA"
        Else
            strMoveToTable = DB_HABITAT_BUTTONS_TABLE
            'strMoveToPanel = "HABITAT DATA"
        End If
        Dim strKeyName As String = Database.GetPrimaryKeyFieldName(m_table_name)

        Dim lstSelectedKeys As List(Of DataRow) = m_grd.getSelectedRowsPrimaryKeys()
        If IsNothing(lstSelectedKeys) Then
            MessageBox.Show("A row must be selected for a move operation.",
                            "No rows selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        ' Get the source table's information
        d = Database.GetDataTable("select * from " & m_table_name, m_table_name)
        Dim intLastKey As Integer
        Dim intNextKey As Integer
        For i As Integer = 0 To lstSelectedKeys.Count - 1
            r = lstSelectedKeys(i)
            intLastKey = CInt(r.Item(strKeyName))
            intNextKey = Database.GetNextPrimaryKeyValue(strMoveToTable)
            r.Item(strKeyName) = intNextKey
            Database.InsertRow(r, strMoveToTable)
            Database.DeleteRow(intLastKey, m_table_name)
        Next
        m_has_modifications = True
        m_grd.fetchData()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If m_has_modifications Then
            RaiseEvent DatabaseModifiedEvent()
        End If
        m_grd.parentHiding()
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