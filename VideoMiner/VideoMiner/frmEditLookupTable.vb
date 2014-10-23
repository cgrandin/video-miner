Imports System.Data.OleDb
Public Class frmEditLookupTable

#Region "Fields"
    Private m_TableName As String
    Private m_IDField As String
    Private m_DescriptionField As String
    Private dbAdapter As OleDbDataAdapter
    Private ds As DataSet
#End Region

#Region "Properties"

    Public Property TableName() As String
        Get
            Return m_TableName
        End Get
        Set(ByVal value As String)
            m_TableName = value
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

    Private intRecordCount As Integer = 0


    Private Sub cboLookupTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLookupTable.SelectedIndexChanged
        Dim strCharactersAllowed As String = "abcdefghijklmnopqrstuvwxyz_"

        Dim txtName As String = Me.cboLookupTable.SelectedItem

        If txtName <> "" Then
            cmdEdit.Enabled = True
        Else
            cmdEdit.Enabled = False
        End If

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        

        Me.TableName = Me.cboLookupTable.SelectedItem

        dbAdapter = New OleDbDataAdapter("SELECT * FROM " & Me.TableName, conn)
        ds = New DataSet
        dbAdapter.Fill(ds)
        Me.grdEditTable.DataSource = ds.Tables(0)

        Me.cmdAddRecord.Enabled = True
        Me.grdEditTable.Enabled = True
        Me.cmdEdit.Enabled = False

    End Sub


    Private Sub cmdAddRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRecord.Click

        Dim dr As DataRow = ds.Tables(0).NewRow()
        Dim i As Integer
        i = Me.grdEditTable.Rows(Me.grdEditTable.Rows.Count - 1).Cells(0).Value
        dr.Item(0) = i + 1
        ds.Tables(0).Rows.Add(dr)

        'Me.grdEditTable.Rows.Item(i).Cells(0).Value = intRecordCount

        intRecordCount += 1

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        Try
            Dim cmnd As OleDbCommandBuilder = New OleDbCommandBuilder(dbAdapter)
            dbAdapter.UpdateCommand = cmnd.GetUpdateCommand()
            dbAdapter.Update(ds, ds.Tables(0).TableName)
        Catch ex As Exception
            MsgBox("Could not add records to table")
        End Try

        Me.Close()

    End Sub

    Private Sub frmAddNewTable_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myFormLibrary.frmAddNewTable = Nothing
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub


    Private Sub cmdDeleteRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRecord.Click
        Dim r As DataGridViewRow

        For Each r In grdEditTable.Rows

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
        If Me.grdEditTable.RowCount = 0 Then
            cmdDeleteRecord.Enabled = False
            cmdOK.Enabled = False
        End If
    End Sub


    Private Sub frmEditLookupTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tblSchema As DataTable

        tblSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, Nothing})

        Dim i As Integer

        For i = 0 To tblSchema.Rows.Count - 1

            If tblSchema.Rows(i)!TABLE_TYPE.ToString = "TABLE" Then

                Dim strTableName As String
                strTableName = tblSchema.Rows(i)!TABLE_NAME.ToString

                If strTableName.Contains("lu_") Then
                    Me.cboLookupTable.Items.Add(strTableName)
                End If
            End If
        Next
    End Sub
End Class