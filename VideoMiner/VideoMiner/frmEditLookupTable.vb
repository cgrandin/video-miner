Imports System.Data.OleDb

Public Class frmEditLookupTable

#Region "Member variables"
    Private m_table_name As String
    Private m_data_table As DataTable
    Private m_IDField As String
    Private m_DescriptionField As String
    Private intRecordCount As Integer = 0
#End Region

#Region "Properties"

    Public Property TableName() As String
        Get
            Return m_table_name
        End Get
        Set(ByVal value As String)
            m_table_name = value
        End Set
    End Property

    Public Property IDField() As String
        Get
            Return m_IDField
        End Get
        Set(ByVal value As String)
            m_IDField = value
        End Set
    End Property

    Public Property DescriptionField() As String
        Get
            Return m_DescriptionField
        End Get
        Set(ByVal value As String)
            m_DescriptionField = value
        End Set
    End Property

#End Region

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub cboLookupTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLookupTable.SelectedIndexChanged
        Dim strCharactersAllowed As String = "abcdefghijklmnopqrstuvwxyz_"
        Dim txtName As String = cboLookupTable.SelectedItem
        If txtName <> "" Then
            cmdEdit.Enabled = True
        Else
            cmdEdit.Enabled = False
        End If
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        m_table_name = cboLookupTable.SelectedItem
        m_data_table = Database.GetDataTable("select * from " & m_table_name & " order by Code Asc;", m_table_name)
        grdEditTable.DataSource = m_data_table
        cmdAddRecord.Enabled = True
        grdEditTable.Enabled = True
        cmdEdit.Enabled = False
    End Sub

    Private Sub cmdAddRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRecord.Click
        Dim dr As DataRow = m_data_table.NewRow()
        Dim i As Integer = grdEditTable.Rows(grdEditTable.Rows.Count - 1).Cells(0).Value
        dr.Item(0) = i + 1
        m_data_table.Rows.Add(dr)
        grdEditTable.Rows.Item(i).Cells(0).Value = intRecordCount
        intRecordCount += 1
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Database.Update(m_data_table)
        Me.Hide()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Hide()
    End Sub

    Private Sub cmdDeleteRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRecord.Click
        For Each r As DataGridViewRow In grdEditTable.Rows
            If r.Selected = True Then
                grdEditTable.Rows.Remove(r)
            End If
        Next
    End Sub

    Private Sub grdNewTable_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grdEditTable.RowsAdded
        cmdDeleteRecord.Enabled = True
        cmdOK.Enabled = True
    End Sub

    Private Sub grdNewTable_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles grdEditTable.RowsRemoved
        If grdEditTable.RowCount = 0 Then
            cmdDeleteRecord.Enabled = False
            cmdOK.Enabled = False
        End If
    End Sub

    Private Sub frmEditLookupTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tblSchema As DataTable = Database.GetDataTableSchema()
        For i As Integer = 0 To tblSchema.Rows.Count - 1
            If tblSchema.Rows(i)!TABLE_TYPE.ToString = "TABLE" Then
                Dim strTableName As String
                strTableName = tblSchema.Rows(i)!TABLE_NAToString
                If strTableName.Contains("lu_") Then
                    cboLookupTable.Items.Add(strTableName)
                End If
            End If
        Next
    End Sub
End Class