Imports System.data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

''' <summary>
''' This form will show a table which will be loaded from the database
''' </summary>
''' <remarks></remarks>
Public Class frmTableView
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

    Private m_Multiple As Boolean
    Private m_UserClosedForm As Boolean = False
    Private m_strSelectedButtonName As String = ""

    Private m_intNumButtons As Integer
    Private m_strButtonNames As String()
    Private m_strButtonCodeNames As String()
    Private m_dictFieldValues As Dictionary(Of String, String)
    Private m_txtTextBoxes As TextBox()

    Event ClearSpatialInformationEvent()

#Region "Properties"
    Public Property SelectedButtonName As String
        Get
            Return m_strSelectedButtonName
        End Get
        Set(value As String)
            m_strSelectedButtonName = value
        End Set
    End Property

    Public Property NumButtons As Integer
        Get
            Return m_intNumButtons
        End Get
        Set(value As Integer)
            m_intNumButtons = value
        End Set
    End Property

    Public Property ButtonNames As String()
        Get
            Return m_strButtonNames
        End Get
        Set(value As String())
            m_strButtonNames = value
        End Set
    End Property

    Public Property FieldValues As Dictionary(Of String, String)
        Get
            Return m_dictFieldValues
        End Get
        Set(value As Dictionary(Of String, String))
            m_dictFieldValues = value
        End Set
    End Property

    Public Property ButtonCodeNames As String()
        Get
            Return m_strButtonCodeNames
        End Get
        Set(value As String())
            m_strButtonCodeNames = value
        End Set
    End Property

    Public Property TextBoxes As TextBox()
        Get
            Return m_txtTextBoxes
        End Get
        Set(value As TextBox())
            m_txtTextBoxes = value
        End Set
    End Property

    Public Property Multiple() As Boolean
        Get
            Return m_Multiple
        End Get
        Set(ByVal value As Boolean)
            m_Multiple = value
        End Set
    End Property
    Public Property UserClosedForm() As Boolean
        Get
            Return m_UserClosedForm
        End Get
        Set(ByVal value As Boolean)
            m_UserClosedForm = value
        End Set
    End Property

#End Region

    Public Sub New(conn As OleDbConnection, ByVal table As String, ByVal intCurrentSpatialVariable As Integer, ByVal intNumButtons As Integer, ByVal strButtonNames As String(), ByRef dictFieldValues As Dictionary(Of String, String), ByVal strButtonCodeNames As String(), ByRef txtTextBoxes As TextBox())
        ' This is required by the Windows Form Designer.
        InitializeComponent()
        m_conn = conn
        m_table_name = table

        Try
            m_query = "select * from " & m_table_name & ";"
            m_data_cmd = New OleDbCommand(m_query, m_conn)
            m_data_adapter = New OleDbDataAdapter(m_data_cmd)
            m_data_set = New DataSet()
            m_data_command_builder = New OleDbCommandBuilder(m_data_adapter)
            m_data_command_builder.QuotePrefix = "["
            m_data_command_builder.QuoteSuffix = "]"
            m_data_adapter.Fill(m_data_set, m_table_name)
            m_data_table = m_data_set.Tables(m_table_name)
            DataGridView1.DataSource = m_data_table
        Catch ex As Exception
            MsgBox("There was an exception thrown while trying to load the " & m_table_name & _
                   " table from the MS Access database into the DataGridView. Message and Stack trace:" & vbCrLf & ex.Message() & vbCrLf & ex.StackTrace)
        End Try
        m_dictFieldValues = dictFieldValues
        m_intNumButtons = intNumButtons
        m_strButtonCodeNames = strButtonCodeNames
        m_strButtonNames = strButtonNames
        m_txtTextBoxes = txtTextBoxes

        ' Add any initialization after the InitializeComponent() call.
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Controls.Add(DataGridView1)

        If intCurrentSpatialVariable <> 8888 Then
            m_strSelectedButtonName = strButtonNames(intCurrentSpatialVariable)
        End If

    End Sub

    Private Sub TableViewForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.UserClosedForm = True
    End Sub


    Private Sub TableViewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = m_strSelectedButtonName
        m_UserClosedForm = False
        Me.btnSkipSpatial.Visible = True
        Me.btnClear.Visible = True
        Me.Width = DataGridView1.Width
        Me.Height = (DataGridView1.RowCount + 3) * DataGridView1.Rows(0).Height
        Me.txtCommentBox.Text = VideoMiner.strComment
        Refresh()
    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        'e.Cancel = True
        'MsgBox("This table is read only. Select a row to make your choice", MsgBoxStyle.Information, "Read only")
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        update_database()
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count = 1 Then
            Me.Hide()
        End If
    End Sub

    Private Sub update_database()
        Try
            m_data_adapter.Update(m_data_set, m_table_name)
        Catch ex As Exception
            MessageBox.Show("The value you entered would result in a key violation in the database table '" & m_table_name & "'" & vbCrLf & _
            "and therefore no changes were made to the database.", "Key Violation", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSkipSpatial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSkipSpatial.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        RaiseEvent ClearSpatialInformationEvent()
        blCleared = True
        Me.Close()
    End Sub

    Private Sub cmdComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdComment.Click
        If Me.cmdComment.Text = "Edit Comment" Then
            txtCommentBox.Enabled = True
            Me.btnClear.Enabled = False
            Me.btnSkipSpatial.Enabled = False
            Me.DataGridView1.Enabled = False
            Me.DataGridView1.DefaultCellStyle.ForeColor = Color.Gray
            Me.cmdComment.Text = "Done"
        Else
            txtCommentBox.Enabled = False
            Me.btnClear.Enabled = True
            Me.btnSkipSpatial.Enabled = True
            Me.DataGridView1.Enabled = True
            Me.DataGridView1.DefaultCellStyle.ForeColor = Color.Black
            Me.cmdComment.Text = "Edit Comment"
            'TODO: Make sure a comment here is put into the table in the DataGridView in the main form
        End If
    End Sub

    Private Sub cmdScreenCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScreenCapture.Click
        'TODO: Screen capturee... not sure why though
        'myFormLibrary.frmVideoMiner.blScreenCaptureCalled = True
        'myFormLibrary.frmVideoMiner.mnuCapScr_Click(sender, e)
        'myFormLibrary.frmVideoMiner.blScreenCaptureCalled = False
    End Sub
End Class