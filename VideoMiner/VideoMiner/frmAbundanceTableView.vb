Imports System.Data.OleDb

Public Class frmAbundanceTableView

#Region "Member variables"
    Private m_table_name As String
    Private m_data_table As DataTable

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

    Public Sub New()
        InitializeComponent()
        m_table_name = DB_ABUNDANCE_TABLE
        m_data_table = Database.GetDataTable("select * from " & m_table_name & " order by Code Asc;", m_table_name)
        grdAbundance.DataSource = m_data_table
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
        Database.Update(m_data_table, DB_DATA_TABLE)
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
        End If
    End Sub

End Class