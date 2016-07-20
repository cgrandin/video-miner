Imports System.Data.OleDb
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
    ''' Create table queries are also allowed.
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
                ' Use 'data' table adapter which is kept open
                m_data_adapter_data.Update(data_table)
            Else
                ' Use temporary data adapter for a table other than 'data'
                Dim query As String = "select * from " & tableName & ";"
                Dim data_cmd As OleDbCommand = New OleDbCommand(query, m_conn)
                Dim data_adapter As OleDbDataAdapter = New OleDbDataAdapter(data_cmd)
                Dim data_cb As OleDbCommandBuilder = New OleDbCommandBuilder(data_adapter)
                data_cb.QuotePrefix = "["
                data_cb.QuoteSuffix = "]"
                data_adapter.Update(data_table)
            End If
        Catch ex As Exception
            MessageBox.Show("Error executing update on database table." & vbCrLf & vbCrLf & "Exception:" &
                            vbCrLf & ex.Message, "Error updating table", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Runs an insert query to insert a new row of data in the table given by tableName.
    ''' It is up to the caller to make sure the data match the table being inserted into.
    ''' </summary>
    ''' <returns>True if successful, false otherwise</returns>
    ''' <remarks>If an exception is thrown or the database connection is not open, a messagebox will appear and False will be returned.</remarks>
    Public Function InsertRow(data_row As DataRow, tableName As String) As Boolean
        If Not IsOpen Then
            MessageBox.Show("The database has not been opened yet.", "Database not open", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Try
            Dim data_table As DataTable = GetDataTable("select * from " & tableName, tableName)
            Dim names As String = "insert into " & tableName & " ("
            Dim values As String = "values("

            ' Loop through the table to get the column names, and add the new values to the query
            For i As Integer = 0 To data_table.Columns.Count - 1
                names = names & data_table.Columns(i).ColumnName
                values = values & SingleQuote(data_row(i).ToString())
                If i <> data_table.Columns.Count - 1 Then
                    names = names & ","
                    values = values & ","
                End If
            Next
            names = names & ") "
            values = values & ")"
            Dim query As String = names & values
            Dim data_cmd As OleDbCommand = New OleDbCommand(query, m_conn)
            data_cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error executing update on database table." & vbCrLf & vbCrLf & "Exception:" &
                            vbCrLf & ex.Message, "Error updating table", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Runs a delete query to delete the row which has the primary key value given by intPrimaryKey
    ''' from the table given by tableName.
    ''' </summary>
    ''' <returns>True if successful, False is the primary key was not found in the table or if an exception is thrown</returns>
    Public Function DeleteRow(intPrimaryKey As Integer, tableName As String) As Boolean
        Try
            Dim strKeyField As String = Database.GetPrimaryKeyFieldName(tableName)
            Dim query As String = "delete from " & tableName & " where " & strKeyField & " = " & intPrimaryKey
            Dim data_cmd As OleDbCommand = New OleDbCommand(query, m_conn)
            data_cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error executing delete on database table." & vbCrLf & vbCrLf & "Exception:" &
                            vbCrLf & ex.Message, "Error deleting row from table", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' Returns the name of the primary key field in the table given by tableName.
    ''' If the table does not contain a primary key column or the database is not open,
    ''' 'Nothing' will be returned.
    ''' Assumes the primary key is made up of one column only. If there is more than one, only the first
    ''' will be returned.
    Public Function GetPrimaryKeyFieldName(tablename As String) As String
        If Not IsOpen Then
            MessageBox.Show("The database has not been opened yet.", "Database not open", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End If

        Try
            Dim schema As DataTable
            schema = m_conn.GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys, New Object() {Nothing, Nothing, tablename})
            Dim intColOrdinalForName As Integer = schema.Columns("COLUMN_NAME").Ordinal
            Dim r As DataRow = schema.Rows(0)
            Return (r.ItemArray(intColOrdinalForName).ToString())
        Catch ex As Exception
            MessageBox.Show("Error getting Primary key field name on database table." & vbCrLf & vbCrLf & "Exception:" &
                            vbCrLf & ex.Message, "Error extracting field name", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Returns the next primary key value that should be used in the table given by tableName.
    ''' If the table does not contain a primary key column or the database is not open, -1 will be returned.
    ''' Assumes the primary key is made up of one column only. If there is more than one, only the first
    ''' will be used. This will cause an error with tables that have more than one primary key field.
    ''' </summary>
    ''' <param name="tableName">Name of the table to get the next key value for</param>
    ''' <returns></returns>
    Public Function GetNextPrimaryKeyValue(tableName As String) As Integer
        If Not IsOpen Then
            MessageBox.Show("The database has not been opened yet.", "Database not open", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End If

        Try
            Dim strPrimaryKeyName As String = GetPrimaryKeyFieldName(tableName)
            If Not IsNothing(strPrimaryKeyName) Then
                Dim query As String = "select " & strPrimaryKeyName & " from " & tableName & " order by 1"
                Dim data_cmd As OleDbCommand = New OleDbCommand(query, m_conn)
                Dim data_adapter As OleDbDataAdapter = New OleDbDataAdapter(data_cmd)
                Dim data_cb As OleDbCommandBuilder = New OleDbCommandBuilder(data_adapter)
                Dim data_set As DataSet = New DataSet()
                data_adapter.Fill(data_set, tableName)
                Dim dt As DataTable = data_set.Tables(0)
                Dim intNewPrimaryKey As Integer = CInt(dt.Rows(dt.Rows.Count - 1).Item(0)) + 1
                Return intNewPrimaryKey
            Else
                Return -1
            End If
        Catch ex As Exception
            MessageBox.Show("Error getting next Primary key value on database table." & vbCrLf & vbCrLf & "Exception:" &
                            vbCrLf & ex.Message, "Error extracting value", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Swap two records in the database table given by tableName. The two records with the primary keys
    ''' intKey1 and intKey2 will be deleted, and reinserted with their primary keys swapped.
    ''' </summary>
    Public Function SwapTwoRecords(intKey1 As Integer, intKey2 As Integer, tableName As String) As Boolean
        Try
            Dim strKeyName As String = GetPrimaryKeyFieldName(tableName)
            Dim r1 As DataRow = GetDataRow(intKey1, tableName)
            Dim r2 As DataRow = GetDataRow(intKey2, tableName)
            ' Delete both records from the table
            Database.DeleteRow(intKey1, tableName)
            Database.DeleteRow(intKey2, tableName)
            ' Swap the keys
            r1.Item(strKeyName) = intKey2
            r2.Item(strKeyName) = intKey1
            ' Insert the swapped records into the database
            Database.InsertRow(r1, tableName)
            Database.InsertRow(r2, tableName)
            Return True
        Catch ex As Exception
            MessageBox.Show("Error swapping two records." & vbCrLf & vbCrLf & "Exception:" &
        vbCrLf & ex.Message, "Error swapping", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Returns the DataRow for the given key intKey in table tableName.
    ''' Returns Nothing if the key is not in the table.
    ''' </summary>
    ''' <param name="intKey"></param>
    Public Function GetDataRow(intKey As Integer, tableName As String) As DataRow
        Dim strKeyName As String = GetPrimaryKeyFieldName(tableName)
        Dim d As DataTable = GetDataTable("select * from " & tableName, tableName)
        Dim r As DataRow
        For i As Integer = 0 To d.Rows.Count - 1
            r = d.Rows(i)
            If CInt(r.Item(strKeyName)) = intKey Then
                Return r
            End If
        Next
        Return Nothing
    End Function
End Module
