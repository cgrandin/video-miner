Imports System.Data.OleDb

Public Class frmEditLookupTable

#Region "Member variables"
    Private m_table_name As String
    Private m_data_table As DataTable
    Private m_IDField As String
    Private m_DescriptionField As String
    ''' <summary>
    ''' A newly added datarow. Used when user presses the 'Add Record' button
    ''' </summary>
    Private m_data_row As DataRow
    ''' <summary>
    ''' An enumeration for the type of query to be executed
    ''' Update is when a record that exists is to be modified
    ''' Insert is when a new row is to be added to the table
    ''' Delete is when a row which exists is to be removed from the table.
    ''' </summary>
    Private Enum CommandType
        Update
        Insert
        Delete
    End Enum
    Private m_command_type As CommandType

#End Region

#Region "Properties"
    Public Property TableName() As String
        Get
            Return m_table_name
        End Get
        Set(ByVal value As String)
            m_table_name = value
        End Set
    End Property

    Public Property IDField() As String
        Get
            Return m_IDField
        End Get
        Set(ByVal value As String)
            m_IDField = value
        End Set
    End Property

    Public Property DescriptionField() As String
        Get
            Return m_DescriptionField
        End Get
        Set(ByVal value As String)
            m_DescriptionField = value
        End Set
    End Property
#End Region

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmEditLookupTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tblSchema As DataTable = Database.GetDataTableSchema()
        Dim strTableName As String
        For i As Integer = 0 To tblSchema.Rows.Count - 1
            strTableName = tblSchema.Rows(i).Item("TABLE_NAME").ToString
            If Strings.Left(strTableName, 3) = "lu_" Then
                cboLookupTable.Items.Add(strTableName)
            End If
        Next
        m_command_type = CommandType.Update
    End Sub

    Private Sub cboLookupTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLookupTable.SelectedIndexChanged
        Dim strCharactersAllowed As String = "abcdefghijklmnopqrstuvwxyz_"
        Dim txtName As String = cboLookupTable.SelectedItem.ToString()
        If txtName <> NULL_STRING Then
            cmdEdit.Enabled = True
        Else
            cmdEdit.Enabled = False
        End If
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        m_table_name = cboLookupTable.SelectedItem.ToString()
        m_data_table = Database.GetDataTable("select * from " & m_table_name & ";", m_table_name)
        grdEditTable.DataSource = m_data_table
        ' See grdEditTable_DataBindingComplete function for hiding the primary key field
    End Sub

    ''' <summary>
    ''' Remove the Primary Key column from the view, so that users cannot change it
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub grdEditTable_DataBindingComplete(sender As Object, e As EventArgs) Handles grdEditTable.DataBindingComplete
        ' Remove primary key field from the table which is shown
        Dim strPrimaryKeyName = Database.GetPrimaryKeyFieldName(m_table_name)
        grdEditTable.Columns(strPrimaryKeyName).Visible = False
        cmdAddRecord.Enabled = True
        grdEditTable.Enabled = True
        cmdEdit.Enabled = False
    End Sub

    Private Sub cmdAddRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRecord.Click
        Dim dr As DataRow = m_data_table.NewRow()

        ' Change the Primary key to be the next one available.
        Dim intNewKey As Integer = Database.GetNextPrimaryKeyValue(m_table_name)
        Dim strKeyField As String = Database.GetPrimaryKeyFieldName(m_table_name)
        dr.Item(strKeyField) = intNewKey

        Dim i As Integer = grdEditTable.Rows.Count
        m_data_table.Rows.Add(dr)
        m_command_type = CommandType.Insert
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If m_command_type = CommandType.Insert Then
            m_data_row = m_data_table.Rows(m_data_table.Rows.Count - 1)
            ' Change primary key row
            Database.InsertRow(m_data_row, m_table_name)
        Else
            Database.Update(m_data_table, m_table_name)
        End If
        m_command_type = CommandType.Update
        Hide()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        m_command_type = CommandType.Update
        Hide()
    End Sub

    Private Sub cmdDeleteRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRecord.Click
        Dim dr As DataRow
        Dim intKey As Integer
        Dim strKeyField As String = Database.GetPrimaryKeyFieldName(m_table_name)
        For Each r As DataGridViewRow In grdEditTable.Rows
            If r.Selected = True Then
                dr = m_data_table.Rows(r.Index)
                intKey = CInt(dr.Item(strKeyField))
                m_data_table.Rows.Remove(dr)
                Database.DeleteRow(intKey, m_table_name)
            End If
        Next
        m_command_type = CommandType.Delete
    End Sub

    Private Sub grdNewTable_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grdEditTable.RowsAdded
        cmdDeleteRecord.Enabled = True
        cmdOK.Enabled = True
    End Sub

    Private Sub grdNewTable_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles grdEditTable.RowsRemoved
        If grdEditTable.RowCount = 0 Then
            cmdDeleteRecord.Enabled = False
            cmdOK.Enabled = False
        End If
    End Sub

End Class