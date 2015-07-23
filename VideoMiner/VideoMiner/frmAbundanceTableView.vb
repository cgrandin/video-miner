Imports System.Data.OleDb

Public Class frmAbundanceTableView

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

    Private blCanceled As Boolean
    Private m_Multiple As Boolean
    Private m_UserClosedForm As Boolean = False
    Private strSelectedButtonName As String = ""
#End Region

#Region "Properties"
    Public Property Canceled() As Boolean
        Get
            Return blCanceled
        End Get
        Set(ByVal value As Boolean)
            blCanceled = value
        End Set
    End Property
#End Region


    Public Sub New(conn As OleDbConnection)
        InitializeComponent()
        m_conn = conn
        m_table_name = DB_ABUNDANCE_TABLE
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
            grdAbundance.DataSource = m_data_table
        Catch ex As Exception
            MsgBox("There was an exception thrown while trying to load the " & m_table_name & _
                   " table from the MS Access database into the DataGridView. Message and Stack trace:" & vbCrLf & ex.Message() & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub TableViewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmdCancel.Visible = True
        Width = grdAbundance.Width
        Height = (grdAbundance.RowCount + 5) * grdAbundance.Rows(0).Height
        'txtCommentBox.Text = VideoMiner.strComment
    End Sub

    Private Sub grdAbundance_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdAbundance.CellBeginEdit
        'e.Cancel = True
        'MsgBox("This table is read only. Select a row to make your choice", MsgBoxStyle.Information, "Read only")
    End Sub

    Private Sub grdAbundance_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAbundance.CellEndEdit
        update_database()
    End Sub

    Private Sub grdAbundance_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAbundance.SelectionChanged
        If grdAbundance.SelectedRows.Count = 1 Then
            If txtCommentBox.Text = "Comment" Then
                txtCommentBox.Text = ""
            End If
            Canceled = False
            Hide()
        End If
    End Sub

    Private Sub update_database()
        Try
            m_data_adapter.Update(m_data_table)
        Catch ex As Exception
            MsgBox("The value you entered would result in a key violation in the database table '" & m_table_name & "'" & vbCrLf & _
            "and therefore no changes were made to the database.", MsgBoxStyle.Exclamation, "Key Violation")
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Canceled = True
        Hide()
    End Sub

    Private Sub cmdComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdComment.Click
        If cmdComment.Text = "Edit Comment" Then
            txtCommentBox.Enabled = True
            cmdCancel.Enabled = False
            grdAbundance.Enabled = False
            grdAbundance.DefaultCellStyle.ForeColor = Color.Gray
            cmdComment.Text = "Done"
        Else
            txtCommentBox.Enabled = False
            cmdCancel.Enabled = True
            grdAbundance.Enabled = True
            grdAbundance.DefaultCellStyle.ForeColor = Color.Black
            cmdComment.Text = "Edit Comment"
            'TODO: Main form must access this value through event handling 
            'myFormLibrary.frmVideoMiner.strComment = txtCommentBox.Text
        End If
    End Sub

End Class