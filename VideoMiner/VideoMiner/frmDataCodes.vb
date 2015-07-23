Imports System.Data.OleDb

Public Class frmDataCodes
    ' Data, table, and query objects
    Private m_table_name As String
    Private m_data_table As DataTable

    Public Sub New()
        InitializeComponent()
        m_table_name = DB_DATA_CODES_TABLE
        m_data_table = Database.GetDataTable("select * from " & m_table_name & " order by Code Asc;", m_table_name)
        grdDataCodes.DataSource = m_data_table
    End Sub

    Private Sub frmDataCodes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        grdDataCodes.Columns.Item(0).Width = 100
        grdDataCodes.Columns.Item(1).Width = 250
        grdDataCodes.Columns.Item(0).DefaultCellStyle.ForeColor = Color.DarkGreen
        grdDataCodes.Columns.Item(0).DefaultCellStyle.SelectionForeColor = Color.DarkGreen
        grdDataCodes.Columns.Item(1).DefaultCellStyle.ForeColor = Color.Black
    End Sub
End Class