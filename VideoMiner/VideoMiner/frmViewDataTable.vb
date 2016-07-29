Public Class frmViewDataTable

    Private m_table_name As String
    Private m_data_table As DataTable

    Public ReadOnly Property UsedDataCodes As DataGridViewColumn
        Get
            Dim strKey As String = Database.GetPrimaryKeyFieldName(DB_DATA_CODES_TABLE)
            Return grdDataTable.Columns(strKey)
        End Get
    End Property

    Public Sub New(strTableName As String)
        InitializeComponent()
        m_table_name = strTableName
    End Sub

    Private Sub frmViewDataTable_Load(sender As Object, e As EventArgs) Handles Me.Load
        m_data_table = Database.GetDataTable("select * from " & m_table_name, m_table_name)
        grdDataTable.DataSource = m_data_table
        grdDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub frmViewDataTable_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Hide()
        End If
    End Sub
End Class