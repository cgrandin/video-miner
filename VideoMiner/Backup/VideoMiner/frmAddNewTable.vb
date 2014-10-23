Imports System.Data.OleDb

Public Class frmAddNewTable

#Region "Fields"
    Private m_TableName As String
    Private m_IDField As String
    Private m_DescriptionField As String

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


    Private Sub txtTableName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTableName.TextChanged
        Dim strCharactersAllowed As String = "abcdefghijklmnopqrstuvwxyz_"

        Dim txtName As String = Me.txtTableName.Text
        Dim Letter As String
        Dim sel_s As Integer = Me.txtTableName.SelectionStart
        Dim did_change As Boolean = False
        For x As Integer = 0 To Me.txtTableName.Text.Length - 1
            Letter = Me.txtTableName.Text.Substring(x, 1).ToLower
            If strCharactersAllowed.Contains(Letter) = False Then
                txtName = txtName.Replace(Letter, String.Empty)
                did_change = True
            End If
        Next
        Me.txtTableName.Text = txtName.ToLower
        If did_change = False Then
            Me.txtTableName.Select(sel_s, 0)
        Else
            Me.txtTableName.Select(sel_s - 1, 0)
        End If

        If Me.txtTableName.Text <> "" Then
            cmdCreate.Enabled = True
        Else
            cmdCreate.Enabled = False
        End If

    End Sub

    Private Sub cmdCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
        If Me.txtTableName.Text.Substring(0, 3) <> "lu_" Then
            Me.txtTableName.Text = "lu_" & Me.txtTableName.Text
        End If

        Dim tblSchema As DataTable

        tblSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, Nothing})

        Dim i As Integer

        For i = 0 To tblSchema.Rows.Count - 1

            If tblSchema.Rows(i)!TABLE_TYPE.ToString = "TABLE" Then

                Dim strTableName As String
                strTableName = tblSchema.Rows(i)!TABLE_NAME.ToString

                If strTableName = Me.txtTableName.Text Then

                    MessageBox.Show("The table name specified already exists, please change the name and try again", "Existing Table Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtTableName.Text = ""
                    Exit Sub

                End If
            End If
        Next

        Dim strName As String
        strName = Me.txtTableName.Text.Substring(2, Me.txtTableName.Text.Length - 2)

        For i = 0 To strName.Length - 1
            If strName(i) = "_" Then
                strName = strName.Substring(0, i + 1) & strName.Substring(i + 1, 1).ToUpper & strName.Substring(i + 2, (strName.Length - (i + 2)))
            End If
        Next

        Dim cr As Char
        Dim Letter As String

        For Each cr In strName
            Letter = cr
            If Letter = "_" Then
                strName = strName.Replace(Letter, String.Empty)
            End If
        Next


        Me.TableName = Me.txtTableName.Text
        Me.IDField = strName & "ID"
        Me.DescriptionField = strName & "Description"

        Me.grdNewTable.ColumnCount = 2
        Me.grdNewTable.Columns(0).Name = Me.IDField
        Me.grdNewTable.Columns(1).Name = Me.DescriptionField

        Me.cmdAddRecord.Enabled = True
        Me.cmdAddColumn.Enabled = True
        Me.grdNewTable.Enabled = True
        Me.cmdCreate.Enabled = False

    End Sub


    Private Sub cmdAddRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRecord.Click

        Dim i As Integer

        i = Me.grdNewTable.Rows.Add()

        Me.grdNewTable.Rows.Item(i).Cells(0).Value = intRecordCount

        intRecordCount += 1

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        Dim clColumns As New Collection
        Dim i As Integer

        For i = 0 To grdNewTable.ColumnCount - 1
            clColumns.Add(grdNewTable.Columns.Item(i).Name.ToString)
        Next



        Dim strQuery As String

        strQuery = "CREATE TABLE " & Me.TableName & " ("

        For i = 1 To clColumns.Count

            Select Case clColumns.Item(i)

                Case Me.IDField
                    strQuery = strQuery & Me.IDField & " INTEGER PRIMARY KEY"

                Case Me.DescriptionField
                    strQuery = strQuery & Me.DescriptionField & " TEXT(255)"

                Case Else
                    strQuery = strQuery & clColumns.Item(i) & " TEXT(255)"

            End Select
            If i = clColumns.Count Then
                strQuery = strQuery & ")"
            Else
                strQuery = strQuery & ", "
            End If
        Next

        Dim createCommand As OleDbCommand
        Dim insertCommand As OleDbCommand

        createCommand = New OleDbCommand(strQuery, conn)

        createCommand.ExecuteNonQuery()


        Dim j As Integer
        Dim k As Integer

        For i = 0 To grdNewTable.Rows.Count - 1

            strQuery = "INSERT INTO " & Me.TableName & "("
            For k = 1 To clColumns.Count

                strQuery = strQuery & clColumns.Item(k)

                If k = clColumns.Count Then
                    strQuery = strQuery & ") VALUES ("
                Else
                    strQuery = strQuery & ", "
                End If
            Next

            For j = 0 To grdNewTable.ColumnCount - 1

                If j = 0 Then

                    strQuery = strQuery & grdNewTable.Rows.Item(i).Cells(j).Value
                Else

                    Dim cr As Char
                    Dim strValue As String
                    Dim Letter As String

                    strValue = grdNewTable.Rows.Item(i).Cells(j).Value.ToString

                    For Each cr In strValue
                        Letter = cr
                        Letter = Letter.ToUpper
                        If Letter = "'" Then
                            strValue = strValue.Replace(Letter, String.Empty)
                        End If
                    Next

                    strQuery = strQuery & SingleQuote(strValue)
                End If
                If j = grdNewTable.ColumnCount - 1 Then
                    strQuery = strQuery & ");"
                Else
                    strQuery = strQuery & ", "
                End If

            Next
            insertCommand = New OleDbCommand(strQuery, conn)
            insertCommand.ExecuteNonQuery()
        Next

        Dim tblSchema As DataTable

        tblSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, Nothing})


        myFormLibrary.frmAddButton.cboTables.Items.Clear()

        For i = 0 To tblSchema.Rows.Count - 1

            If tblSchema.Rows(i)!TABLE_TYPE.ToString = "TABLE" Then

                Dim strTableName As String
                strTableName = tblSchema.Rows(i)!TABLE_NAME.ToString

                If strTableName.Substring(0, 3) = "lu_" Then

                    myFormLibrary.frmAddButton.cboTables.Items.Add(strTableName)
                End If

            End If
        Next


        myFormLibrary.frmAddButton.cboTables.SelectedItem = Me.TableName

        Me.Close()

    End Sub

    Private Sub frmAddNewTable_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myFormLibrary.frmAddNewTable = Nothing
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Call numericTextboxValidation(e)
    End Sub

    Private Sub cmdDeleteRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRecord.Click
        Dim r As DataGridViewRow

        For Each r In grdNewTable.Rows

            If r.Selected = True Then

                grdNewTable.Rows.Remove(r)

            End If

        Next

    End Sub

    Private Sub grdNewTable_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grdNewTable.RowsAdded

        cmdDeleteRecord.Enabled = True
        cmdOK.Enabled = True

    End Sub

    Private Sub grdNewTable_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles grdNewTable.RowsRemoved
        If Me.grdNewTable.RowCount = 0 Then
            cmdDeleteRecord.Enabled = False
            cmdOK.Enabled = False
        End If
    End Sub

    Private Sub cmdAddColumn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddColumn.Click

        Dim strColumnName As String

        strColumnName = InputBox("Please enter a column name. No spaces or symbols allowed.")

        Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

        Dim strName As String
        Dim i As Integer
        strName = strColumnName

        For i = 0 To strName.Length - 1
            If strName(i) = "_" Or strName(i) = " " Then
                strName = strName.Substring(0, i + 1) & strName.Substring(i + 1, 1).ToUpper & strName.Substring(i + 2, (strName.Length - (i + 2)))
            End If
        Next

        Dim cr As Char
        Dim Letter As String

        For Each cr In strName
            Letter = cr
            Letter = Letter.ToUpper
            If strCharactersAllowed.Contains(Letter) = False Then
                strName = strName.Replace(Letter, String.Empty)
            End If
        Next
        strColumnName = strName

        If strColumnName.Substring(0, 1) = strColumnName.Substring(0, 1).ToLower Then
            strColumnName = strColumnName.Substring(0, 1).ToUpper & strColumnName.Substring(1, strColumnName.Length - 1)
        End If

        Me.grdNewTable.Columns.Add(strColumnName, strColumnName)

    End Sub

End Class