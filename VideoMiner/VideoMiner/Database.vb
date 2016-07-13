﻿Imports System.Data.OleDb
''' <summary>
''' This module encapsulates the reading and writing to an MS Access database using the OLEDB interface
''' </summary>
''' <remarks></remarks>
Public Module Database

    ''' <summary>
    ''' Connection string header fragment. The full path of the MS Access database will be appended
    ''' to this string to get the full connection string.
    ''' </summary>
    Public Const DB_CONN_STRING As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="

#Region "Member variables"
    ''' <summary>
    ''' The full-path name of the MS Access database file (mdb file).
    ''' </summary>
    Private m_strDatabaseFilePath As String
    Private m_conn As OleDbConnection
    Private m_data_table As DataTable
    Private m_data_cmd As OleDbCommand
    ''' <summary>
    ''' The data adapter for the 'data' table in the database
    ''' </summary>
    ''' <remarks>A seperate data adapter is needed for each table which may be modified by the Update function</remarks>
    Private m_data_adapter_data As OleDbDataAdapter
    ''' <summary>
    ''' The data adapter for the 'species_buttons' table in the database
    ''' </summary>
    ''' <remarks>A seperate data adapter is needed for each table which may be modified by the Update function</remarks>
    Private m_data_adapter_species_buttons As OleDbDataAdapter
    Private m_data_command_builder As OleDbCommandBuilder
    Private m_data_set As DataSet
    Private m_data_binding As BindingSource
    Private m_db_file_open As Boolean
    Private m_db_filename As String
    Private m_db_id_num As Long
#End Region

#Region "Properties"
    ''' <summary>
    ''' The full path name of the MS Access database file (.mdb file)
    ''' </summary>
    Public Property Name As String
        Get
            Return m_strDatabaseFilePath
        End Get
        Set(ByVal value As String)
            m_strDatabaseFilePath = value
        End Set
    End Property

    ''' <summary>
    ''' The full connection string for the data source.
    ''' </summary>
    Private ReadOnly Property ConnectionString As String
        Get
            Return DB_CONN_STRING & m_strDatabaseFilePath
        End Get
    End Property

    ''' <summary>
    ''' Whether or not the database has been opened using the Open() function
    ''' </summary>
    Public ReadOnly Property IsOpen As Boolean
        Get
            Return m_conn IsNot Nothing
        End Get
    End Property

#End Region

    ''' <summary>
    ''' Opens the database. Returns True if successful, false otherwise.
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>If an exception is thrown, a messagebox will appear and False will be returned</remarks>
    Public Function Open() As Boolean
        Try
            m_conn = New OleDbConnection(ConnectionString)
            m_conn.Open()
        Catch ex As Exception
            MessageBox.Show("Error loading database. Check that the file " & m_strDatabaseFilePath & " exists and is not corrupted." & vbCrLf & vbCrLf & "Exception:" & vbCrLf & _
                            ex.Message, "Error loading database file", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Closes the database. Returns True if successful, false otherwise.
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>If an exception is thrown, a messagebox will appear and False will be returned</remarks>
    Public Function Close() As Boolean
        Try
            m_conn.Close()
            m_conn = Nothing
        Catch ex As Exception
            MessageBox.Show("Error closing database. Exception:" & vbCrLf & ex.Message, "Error loading database file", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Runs a schema table for the MS Access database
    ''' </summary>
    ''' <returns>A DataTable which holds the database schema or Nothing</returns>
    ''' <remarks>If an exception is thrown or the database connection is not open, a messagebox will appear and Nothing will be returned.</remarks>
    Public Function GetDataTableSchema() As DataTable
        If Not IsOpen Then
            MessageBox.Show("The database has not been opened yet.", "Database not open", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End If
        Try
            m_data_table = m_conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, Nothing})
        Catch ex As Exception
            MessageBox.Show("Error fetching schema data from database. Exception:" & vbCrLf & ex.Message, "Error loading data from query", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
        Return m_data_table
    End Function

    ''' <summary>
    ''' Runs a query on a given table and returns the resulting data.
    ''' </summary>
    ''' <param name="query">A legal SQL query for an MS Access database</param>
    ''' <param name="tableName">The name of the table used in the query</param>
    ''' <returns>A DataTable which holds the data queried for or Nothing</returns>
    ''' <remarks>If an exception is thrown or the database connection is not open, a messagebox will appear and Nothing will be returned.</remarks>
    Public Function GetDataTable(query As String, tableName As String) As DataTable
        Dim data_adapter As OleDbDataAdapter
        If Not IsOpen Then
            MessageBox.Show("The database has not been opened yet.", "Database not open", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End If
        Try
            m_data_cmd = New OleDbCommand(query, m_conn)
            If tableName = DB_DATA_TABLE Then
                m_data_adapter_data = New OleDbDataAdapter(m_data_cmd)
            Else
                data_adapter = New OleDbDataAdapter(m_data_cmd)
            End If
            m_data_set = New DataSet()
            m_data_command_builder = New OleDbCommandBuilder(m_data_adapter_data)
            m_data_command_builder.QuotePrefix = "["
            m_data_command_builder.QuoteSuffix = "]"
            If tableName = DB_DATA_TABLE Then
                m_data_adapter_data.Fill(m_data_set, tableName)
            Else
                data_adapter.Fill(m_data_set, tableName)
            End If
            m_data_table = m_data_set.Tables(tableName)
        Catch ex As Exception
            MessageBox.Show("Error fetching data from database. Check that the table " & tableName & " exists and is able to support the query submitted." & _
                            vbCrLf & vbCrLf & "Query:" & vbCrLf & query & vbCrLf & vbCrLf & "Exception:" & vbCrLf & ex.Message, "Error loading data from query", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
        Return m_data_table
    End Function

    ''' <summary>
    ''' Executes a query on the database which does not return data. Examples are UPDATE, DELETE, or INSERT queries.
    ''' Also create table queries are allowed.
    ''' </summary>
    ''' <param name="query">The query to execute on the MS Access database</param>
    ''' <returns>True if the query was successful, false otherwise and false if an exception was thrown</returns>
    ''' <remarks>If an exception is thrown or the database connection is not open, a messagebox will appear and False will be returned.</remarks>
    Public Function ExecuteNonQuery(query As String) As Boolean
        If Not IsOpen Then
            MessageBox.Show("The database has not been opened yet.", "Database not open", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Try
            Dim oComm As OleDbCommand = New OleDbCommand(query, m_conn)
            oComm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error executing non-data-query on database. Check that the database is able to support the query submitted." & _
                            vbCrLf & vbCrLf & " Query: " & vbCrLf & query & vbCrLf & vbCrLf & "Exception:" & vbCrLf & ex.Message, "Error loading data from query", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Runs an update query on the data adapter with the given data_table for the main data recording table.
    ''' </summary>
    ''' <returns>True if successful, false otherwise</returns>
    ''' <remarks>If an exception is thrown or the database connection is not open, a messagebox will appear and False will be returned.</remarks>
    Public Function Update(data_table As DataTable, tableName As String) As Boolean
        Try
            If tableName = DB_DATA_TABLE Then
                m_data_adapter_data.Update(data_table)
            End If
        Catch ex As Exception
            MessageBox.Show("Error executing update on database table." & vbCrLf & vbCrLf & "Exception:" &
                            vbCrLf & ex.Message, "Error updating table", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Runs an update query on the data adapter with the given lookup table (named pattern lu_*).
    ''' Used to save changes to the database table from outside.
    ''' </summary>
    ''' <returns>True if successful, false otherwise</returns>
    ''' <remarks>If an exception is thrown or the database connection is not open, a messagebox will appear and False will be returned.</remarks>
    Public Function UpdateLookup(data_table As DataTable, tableName As String) As Boolean
        If Not IsOpen Then
            MessageBox.Show("The database has not been opened yet.", "Database not open", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End If

        Try
            Dim query As String = "select * from " & tableName & ";"
            Dim data_cmd As OleDbCommand = New OleDbCommand(query, m_conn)
            Dim data_adapter As OleDbDataAdapter = New OleDbDataAdapter(data_cmd)
            Dim data_cb As OleDbCommandBuilder = New OleDbCommandBuilder(data_adapter)
            Dim data_set As DataSet = New DataSet()
            data_adapter.Fill(data_set, tableName)
            data_adapter.InsertCommand = data_cb.GetInsertCommand()
            data_adapter.DeleteCommand = data_cb.GetDeleteCommand
            data_adapter.UpdateCommand = data_cb.GetUpdateCommand()
            data_adapter.Update(data_table)
        Catch ex As Exception
            MessageBox.Show("Error executing update on database table." & vbCrLf & vbCrLf & "Exception:" &
                            vbCrLf & ex.Message, "Error updating table", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return True
    End Function

End Module
