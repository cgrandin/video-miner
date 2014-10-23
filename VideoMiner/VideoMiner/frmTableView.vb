Imports System.data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class frmTableView

    Private table_name As String
    Private sub_data_set As DataSet
    Private query As String
    Private sub_db_command
    Private sub_data_adapter As OleDbDataAdapter
    Private sub_data_binding As BindingSource
    Private sub_data_command_builder As OleDbCommandBuilder
    Private m_Multiple As Boolean
    Private m_UserClosedForm As Boolean = False
    Private strSelectedButtonName As String = ""

    Private m_intNumButtons As Integer
    Private m_strButtonNames As String()
    Private m_strButtonCodeNames As String()
    Private m_dictFieldValues As Dictionary(Of String, String)
    Private m_txtTextBoxes As TextBox()


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

    Public Sub New(ByVal table As String, ByVal intCurrentSpatialVariable As Integer, ByVal intNumButtons As Integer, ByVal strButtonNames As String(), ByRef dictFieldValues As Dictionary(Of String, String), ByVal strButtonCodeNames As String(), ByRef txtTextBoxes As TextBox())
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        table_name = table

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
            strSelectedButtonName = strButtonNames(intCurrentSpatialVariable)
        End If

    End Sub

    Private Sub TableViewForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.UserClosedForm = True
        myFormLibrary.frmTableView = Nothing
    End Sub


    Private Sub TableViewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        myFormLibrary.frmTableView = Me
        Me.Text = strSelectedButtonName

        m_UserClosedForm = False
        'If Me.m_Multiple Then
        Me.btnSkipSpatial.Visible = True
        Me.btnClear.Visible = True
        'End If
        sub_data_set = New DataSet()
        query = "select * from " & table_name & ";"
        sub_db_command = New OleDbCommand(query, conn)
        sub_data_adapter = New OleDbDataAdapter(sub_db_command)
        sub_data_binding = New BindingSource()
        sub_data_command_builder = New OleDbCommandBuilder(sub_data_adapter)
        sub_data_adapter.Fill(sub_data_set, table_name)
        sub_data_binding.DataSource = sub_data_set.Tables(table_name)
        DataGridView1.DataSource = sub_data_binding

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
        'update the database
        sub_data_binding.EndEdit()
        Dim comm_builder As OleDbCommandBuilder = New OleDbCommandBuilder(sub_data_adapter)
        Try
            sub_data_adapter.Update(sub_data_set, table_name)
            sub_data_set.AcceptChanges()
        Catch ex As Exception
            MsgBox("The value you entered would result in a key violation in the database table '" & table_name & "'" & vbCrLf & _
            "and therefore no changes were made to the database.", MsgBoxStyle.Exclamation, "Key Violation")
        End Try
    End Sub

    Private Sub btnSkipSpatial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSkipSpatial.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        myFormLibrary.frmVideoMiner.ClearSpatial(strSelectedButtonName, m_intNumButtons, m_strButtonNames, m_dictFieldValues, m_strButtonCodeNames, m_txtTextBoxes)
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
            VideoMiner.strComment = Me.txtCommentBox.Text
        End If

    End Sub

    Private Sub cmdScreenCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScreenCapture.Click
        myFormLibrary.frmVideoMiner.blScreenCaptureCalled = True
        Call myFormLibrary.frmVideoMiner.mnuCapScr_Click(sender, e)
        myFormLibrary.frmVideoMiner.blScreenCaptureCalled = False
    End Sub
End Class