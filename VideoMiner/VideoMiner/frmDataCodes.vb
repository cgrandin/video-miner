Imports System.Data.OleDb

Public Class frmDataCodes

    Private Sub frmDataCodes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim query As String
        Dim data_cmd As OleDbCommand
        Dim data_adapter As OleDbDataAdapter
        Dim data_set As DataSet
        Dim data_table As DataTable
        Dim data_binding As BindingSource
        Dim data_command_builder As OleDbCommandBuilder


        query = "SELECT * FROM lu_data_codes ORDER BY Code Asc;"
        data_cmd = New OleDbCommand(query, conn)
        data_adapter = New OleDbDataAdapter(query, conn)
        data_set = New DataSet
        data_table = New DataTable()
        data_binding = New BindingSource()
        Try
            data_command_builder = New OleDbCommandBuilder(data_adapter)
            data_adapter.Fill(data_set, DB_DATA_TABLE)
            data_binding.DataSource = data_set.Tables(DB_DATA_TABLE)
            grdDataCodes.DataSource = data_binding

            grdDataCodes.Columns.Item(0).Width = 100
            grdDataCodes.Columns.Item(1).Width = 250

            grdDataCodes.Columns.Item(0).DefaultCellStyle.ForeColor = Color.DarkGreen
            grdDataCodes.Columns.Item(0).DefaultCellStyle.SelectionForeColor = Color.DarkGreen
            grdDataCodes.Columns.Item(1).DefaultCellStyle.ForeColor = Color.Black


        Catch ex As Exception
        End Try
    End Sub
End Class