Imports System.Data.OleDb

Public Class frmEditLookupTable

#Region "Member variables"
    ' OLE objects
    Private m_conn As OleDbConnection
    Private m_data_cmd As OleDbCommand
    Private m_data_adapter As OleDbDataAdapter
    Private m_data_command_builder As OleDbCommandBuilder

    ' Data, table, and query objects
    Private m_query As String
    Private m_table_name As String
    Private m_data_table As DataTable
    Private m_data_set As DataSet

    Private m_IDField As String
    Private m_DescriptionField As String
    Private intRecordCount As Integer = 0
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

    Public Sub New(conn As OleDbConnection)
        InitializeComponent()
        m_conn = conn
    End Sub

    Private Sub cboLookupTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLookupTable.SelectedIndexChanged
        Dim strCharactersAllowed As String = "abcdefghijklmnopqrstuvwxyz_"
        Dim txtName As String = cboLookupTable.SelectedItem
        If txtName <> "" Then
            cmdEdit.Enabled = True
        Else
            cmdEdit.Enabled = False
        End If
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        m_table_name = cboLookupTable.SelectedItem
        Try
            m_query = "select * from " & m_table_name & " order by Code Asc;"
            m_data_cmd = New OleDbCommand(m_query, m_conn)
            m_data_adapter = New OleDbDataAdapter(m_data_cmd)
            m_data_set = New DataSet()
            m_data_command_builder = New OleDbCommandBuilder(m_data_adapter)
            m_data_command_builder.QuotePrefix = "["
            m_data_command_builder.QuoteSuffix = "]"
            m_data_adapter.Fill(m_data_set, m_table_name)
            m_data_table = m_data_set.Tables(m_table_name)
            grdEditTable.DataSource = m_data_table
        Catch ex As Exception
            MsgBox("There was an exception thrown while trying to load the " & m_table_name & _
                   " table from the MS Access database into the DataGridView. Message and Stack trace:" & vbCrLf & ex.Message() & vbCrLf & ex.StackTrace)
        End Try
        cmdAddRecord.Enabled = True
        grdEditTable.Enabled = True
        cmdEdit.Enabled = False
    End Sub

    Private Sub cmdAddRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRecord.Click
        Dim dr As DataRow = m_data_table.NewRow()
        Dim i As Integer = grdEditTable.Rows(grdEditTable.Rows.Count - 1).Cells(0).Value
        dr.Item(0) = i + 1
        m_data_table.Rows.Add(dr)
        grdEditTable.Rows.Item(i).Cells(0).Value = intRecordCount
        intRecordCount += 1
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            m_data_adapter.Update(m_data_table)
        Catch ex As Exception
            MsgBox("The value you entered would result in a key violation in the database table '" & m_table_name & "'" & vbCrLf & _
            "and therefore no changes were made to the database.", MsgBoxStyle.Exclamation, "Key Violation")
        End Try
        Me.Hide()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Hide()
    End Sub

    Private Sub cmdDeleteRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRecord.Click
        For Each r As DataGridViewRow In grdEditTable.Rows
            If r.Selected = True Then
                grdEditTable.Rows.Remove(r)
            End If
        Next
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

    Private Sub frmEditLookupTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tblSchema As DataTable
        tblSchema = m_conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, Nothing})
        For i As Integer = 0 To tblSchema.Rows.Count - 1
            If tblSchema.Rows(i)!TABLE_TYPE.ToString = "TABLE" Then
                Dim strTableName As String
                strTableName = tblSchema.Rows(i)!TABLE_NAToString
                If strTableName.Contains("lu_") Then
                    cboLookupTable.Items.Add(strTableName)
                End If
            End If
        Next
    End Sub
End Class