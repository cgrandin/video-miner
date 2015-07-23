Imports System.Data.OleDb

Public Class frmDataCodes
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

    Public Sub New(conn As OleDbConnection)
        InitializeComponent()
        m_conn = conn
        m_table_name = DB_DATA_CODES_TABLE
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
            grdDataCodes.DataSource = m_data_table
        Catch ex As Exception
            MsgBox("There was an exception thrown while trying to load the " & m_table_name & _
                   " table from the MS Access database into the DataGridView. Message and Stack trace:" & vbCrLf & ex.Message() & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmDataCodes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        grdDataCodes.Columns.Item(0).Width = 100
        grdDataCodes.Columns.Item(1).Width = 250
        grdDataCodes.Columns.Item(0).DefaultCellStyle.ForeColor = Color.DarkGreen
        grdDataCodes.Columns.Item(0).DefaultCellStyle.SelectionForeColor = Color.DarkGreen
        grdDataCodes.Columns.Item(1).DefaultCellStyle.ForeColor = Color.Black
    End Sub
End Class