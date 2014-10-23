Imports System.Data.OleDb

Public Class frmConfigureButtons

#Region "Fields"
    Private m_ButtonName As String
    Private m_TableName As String
    Private m_DataCode As Integer
    Private m_FieldName As String
    Private m_DrawingOrder As String
#End Region

#Region "Properties"
    Public Property ButtonName() As String
        Get
            Return m_ButtonName
        End Get
        Set(ByVal value As String)
            m_ButtonName = value
        End Set
    End Property

    Public Property TableName() As String
        Get
            Return m_TableName
        End Get
        Set(ByVal value As String)
            m_TableName = value
        End Set
    End Property

    Public Property DataCode() As Integer
        Get
            Return m_DataCode
        End Get
        Set(ByVal value As Integer)
            m_DataCode = value
        End Set
    End Property

    Public Property FieldName() As String
        Get
            Return m_FieldName
        End Get
        Set(ByVal value As String)
            m_FieldName = value
        End Set
    End Property

    Public Property DrawingOrder() As Integer
        Get
            Return m_DrawingOrder
        End Get
        Set(ByVal value As Integer)
            m_DrawingOrder = value
        End Set
    End Property
#End Region


    Public Sub frmConfigureButtons_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Try
            Me.lstButtons.Items.Clear()
            Dim sub_data_set As DataSet = New DataSet()
            Dim sub_db_command As OleDbCommand = New OleDbCommand("select DrawingOrder, ButtonText, TableName, DataCode, DataCodeName, ButtonColor from " & strConfigureTable & " ORDER BY DrawingOrder;", conn)
            Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
            sub_data_adapter.Fill(sub_data_set, strConfigureTable)
            Dim r As DataRow
            Dim d As DataTable
            d = sub_data_set.Tables(0)

            Dim itm As ListViewItem
            For Each r In d.Rows
                itm = New ListViewItem
                itm.Text = ""

                itm.SubItems.Add(r.Item("ButtonText").ToString())
                itm.SubItems.Add(r.Item("TableName").ToString())
                Me.lstButtons.Items.Add(itm)
            Next
        Catch ex As Exception

        End Try


    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' -------------------------------------------------
        ' Initialize Form elements
        ' -------------------------------------------------
        With Me.lstButtons
            .Visible = True
            .FullRowSelect = True
            .View = View.Details
            .HeaderStyle = ColumnHeaderStyle.Nonclickable
            .HideSelection = False
            .Focus()
            .Columns.Add("", 0, HorizontalAlignment.Left)
            .Columns.Add("Button Text", 150, HorizontalAlignment.Left)
            .Columns.Add("Referenced Table", 150, HorizontalAlignment.Left)
        End With

        myFormLibrary.frmConfigureButtons = Me

    End Sub

    Private Sub cmdMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveUp.Click

        If Me.lstButtons.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstButtons.SelectedItems(0).Index
            'MsgBox(intSelectedIndex)
            Call MoveListViewItem(True)
        Else
            MsgBox("Please select a button from the list")
        End If
    End Sub

    Private Sub MoveListViewItem(ByVal moveUp As Boolean)

        Dim i As Integer
        Dim cache As String
        Dim selIdx As Integer

        With Me.lstButtons
            If .SelectedIndices.Count = 0 Then
                Exit Sub
            Else
                selIdx = .SelectedIndices.Item(0)
            End If

            If moveUp Then
                ' ignore moveup of row(0)
                If selIdx = 0 Then
                    Exit Sub
                End If

                ' move the subitems for the previous row
                ' to cache so we can move the selected row up
                Dim strFields As String = ""

                For i = 0 To .Items(selIdx).SubItems.Count - 1
                    cache = .Items(selIdx - 1).SubItems(i).Text

                    .Items(selIdx - 1).SubItems(i).Text = .Items(selIdx).SubItems(i).Text
                    .Items(selIdx).SubItems(i).Text = cache
                Next
                .Items(selIdx - 1).Selected = True
                .Items(selIdx - 1).Focused = True
                .EnsureVisible(selIdx - 1)
                .Refresh()
                .Focus()
            Else
                ' ignore move down of last row
                If selIdx = .Items.Count - 1 Then
                    Exit Sub
                End If
                ' move the subitems for the next row
                ' to cache so we can move the selected row down
                For i = 0 To .Items(selIdx).SubItems.Count - 1
                    cache = .Items(selIdx + 1).SubItems(i).Text
                    .Items(selIdx + 1).SubItems(i).Text = .Items(selIdx).SubItems(i).Text
                    .Items(selIdx).SubItems(i).Text = cache
                Next

                .Items(selIdx + 1).Selected = True
                .Items(selIdx + 1).Focused = True
                .EnsureVisible(selIdx)
                .Refresh()
                .Focus()
            End If
        End With
        Call UpdateDrawingOrder(strConfigureTable)
    End Sub

    Private Sub cmdMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveDown.Click

        If Me.lstButtons.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstButtons.SelectedItems(0).Index
            'MsgBox(intSelectedIndex)
            Call MoveListViewItem(False)
        Else
            MsgBox("Please select a species from the list")
        End If

    End Sub

    Private Sub cmdCreateNewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateNewButton.Click

        Call Me.UpdateDrawingOrder(strConfigureTable)

        myFormLibrary.frmAddButton = New frmAddButton

        myFormLibrary.frmAddButton.ShowDialog()
    End Sub

    Private Sub cmdEditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditButton.Click

        If Me.lstButtons.SelectedItems.Count = 0 Then
            MsgBox("Please select a button from the list")
            Exit Sub
        End If

        blButtonEdit = True

        myFormLibrary.frmAddButton = New frmAddButton
        myFormLibrary.frmAddButton.Text = "Edit " & Me.lstButtons.SelectedItems.Item(0).SubItems(1).Text.ToString & " Button"
        myFormLibrary.frmAddButton.txtButtonName.Text = Me.lstButtons.SelectedItems.Item(0).SubItems(1).Text.ToString

        'Call Me.UpdateDrawingOrder(strConfigureTable)

        myFormLibrary.frmAddButton.ShowDialog()
    End Sub

    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click

        'Call Me.UpdateDrawingOrder()

        Me.Close()

    End Sub

    Private Sub UpdateDrawingOrder(ByVal strTable As String)

        Dim oComm As OleDbCommand
        Dim query As String

        Dim strButtonName As String

        query = "UPDATE " & strTable & " " & _
                "SET DrawingOrder = DrawingOrder + 1000"
        oComm = New OleDbCommand(query, conn)
        oComm.ExecuteNonQuery()

        If strTable = strConfigureTable Then

            For i As Integer = 0 To Me.lstButtons.Items.Count - 1

                strButtonName = Me.lstButtons.Items(i).SubItems(1).Text

                query = "UPDATE " & strTable & " " & _
                        "SET DrawingOrder = " & i + 1 & " " & _
                        "WHERE ButtonText = " & SingleQuote(strButtonName)

                oComm = New OleDbCommand(query, conn)
                oComm.ExecuteNonQuery()

            Next
        Else
            query = "SELECT ButtonText FROM " & strTable & " ORDER BY DrawingOrder ASC"

            Dim sub_data_set As DataSet = New DataSet()
            Dim sub_db_command As OleDbCommand = New OleDbCommand(query, conn)
            Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
            sub_data_adapter.Fill(sub_data_set, strConfigureTable)
            Dim r As DataRow
            Dim d As DataTable
            d = sub_data_set.Tables(0)

            Dim i As Integer = 0

            For Each r In d.Rows

                strButtonName = r.Item("ButtonText")

                query = "UPDATE " & strTable & " " & _
                        "SET DrawingOrder = " & i + 1 & " " & _
                        "WHERE ButtonText = " & SingleQuote(strButtonName)

                oComm = New OleDbCommand(query, conn)
                oComm.ExecuteNonQuery()

                i += 1

            Next
        End If
        myFormLibrary.frmVideoMiner.blupdateColumns = False
        Call RefreshDatabase(Me, New EventArgs)
        myFormLibrary.frmVideoMiner.blupdateColumns = True
        Dim txt As TextBox

        For Each txt In myFormLibrary.frmVideoMiner.textboxes
            If Not txt Is Nothing Then
                If Not txt.Text.StartsWith("No ") Then
                    txt.BackColor = Color.LightGray
                    txt.ForeColor = Color.LimeGreen
                    txt.TextAlign = HorizontalAlignment.Center
                End If
            End If
        Next

        For Each txt In myFormLibrary.frmVideoMiner.Transect_Textboxes
            If Not txt Is Nothing Then
                If Not txt.Text.StartsWith("No ") Then
                    txt.BackColor = Color.LightGray
                    txt.ForeColor = Color.LimeGreen
                    txt.TextAlign = HorizontalAlignment.Center
                End If
            End If
        Next


    End Sub

    Private Sub cmdDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteButton.Click
        Dim selIdx As Integer
        Try
            selIdx = Me.lstButtons.SelectedIndices.Item(0)
        Catch ex As Exception
            selIdx = 0
        End Try

        If Me.lstButtons.SelectedItems.Count = 0 Then
            MsgBox("Please select a button from the list")
            Exit Sub
        End If

        Me.ButtonName = Me.lstButtons.Items(selIdx).SubItems(1).Text

        Dim strQuery As String

        strQuery = "SELECT * FROM " & strConfigureTable

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand(strQuery, conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, strConfigureTable)

        Dim dt As DataTable
        Dim r As DataRow

        dt = sub_data_set.Tables.Item(0)

        For Each r In dt.Rows

            If r.Item("ButtonText") = Me.ButtonName Then

                Me.FieldName = r.Item("DataCodeName")
                Me.DataCode = r.Item("DataCode")
                Exit For
            End If
        Next

        Dim dr As DialogResult
        dr = MessageBox.Show("By deleting this button the field '" & Me.FieldName & "' will be removed from the '" & DB_DATA_TABLE & "' table in the database.  Are you sure you want to delete this button?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dr = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If



        Dim oComm As OleDbCommand
        Dim query As String

        Try
            query = "DELETE * FROM " & strConfigureTable & " " & _
                    "WHERE ButtonText = " & SingleQuote(Me.ButtonName)

            oComm = New OleDbCommand(query, conn)
            oComm.ExecuteNonQuery()

            query = "ALTER TABLE " & DB_DATA_TABLE & " DROP " & Me.FieldName

            oComm = New OleDbCommand(query, conn)
            oComm.ExecuteNonQuery()

            query = "DELETE * FROM lu_data_codes WHERE Code = " & Me.DataCode
            oComm = New OleDbCommand(query, conn)
            oComm.ExecuteNonQuery()

            Call frmConfigureButtons_Activated(Nothing, Nothing)

            Call Me.UpdateDrawingOrder(strConfigureTable)
        Catch ex As Exception
            MessageBox.Show("Could not delete the selected button due to the exception: " & ex.ToString, "Delete Button Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
            'Call RefreshDatabase(Me, New EventArgs)

    End Sub

    Private Sub frmSpeciesList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myFormLibrary.frmConfigureButtons = Nothing
    End Sub

    Private Sub cmdMoveToPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveToPanel.Click
        Dim strMoveToTable As String
        Dim strMoveToPanel As String

        If strConfigureTable = DB_BUTTONS_TABLE Then
            strMoveToTable = DB_TRANSECT_BUTTONS_TABLE
            strMoveToPanel = "TRANSECT DATA"
        Else
            strMoveToTable = DB_BUTTONS_TABLE
            strMoveToPanel = "HABITAT DATA"
        End If

        Dim selIdx As Integer
        Try
            selIdx = Me.lstButtons.SelectedIndices.Item(0)
        Catch ex As Exception
            selIdx = 0
        End Try

        If Me.lstButtons.SelectedItems.Count = 0 Then
            MsgBox("Please select a button from the list")
            Exit Sub
        Else
            Dim answer As Integer
            answer = MessageBox.Show("Are you sure you want to move the " & Me.lstButtons.Items(selIdx).SubItems(1).Text & " button to " & strMoveToPanel & "?", "Move Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = vbNo Then
                Exit Sub
            End If
        End If

        Me.ButtonName = Me.lstButtons.Items(selIdx).SubItems(1).Text

        Dim strQuery As String

        strQuery = "SELECT * FROM " & strConfigureTable

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand(strQuery, conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, strConfigureTable)

        Dim dt As DataTable
        Dim r As DataRow

        dt = sub_data_set.Tables.Item(0)

        For Each r In dt.Rows

            If r.Item("ButtonText") = Me.ButtonName Then

                Me.FieldName = r.Item("DataCodeName")
                Me.DataCode = r.Item("DataCode")
                Me.TableName = r.Item("TableName")
                Exit For
            End If
        Next

        strQuery = "SELECT * FROM " & strMoveToTable & ";"

        sub_data_set = New DataSet()
        sub_db_command = New OleDbCommand(strQuery, conn)
        sub_data_adapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, strConfigureTable)

        dt = sub_data_set.Tables(0)

        Dim i As Integer
        Dim intValue As Integer = 0

        For i = 0 To dt.Rows.Count - 1

            r = dt.Rows.Item(i)

            If CInt(r.Item("DrawingOrder")) > intValue Then
                intValue = CInt(r.Item("DrawingOrder"))
            End If

        Next

        Me.DrawingOrder = intValue + 1

        strQuery = "INSERT INTO " & strMoveToTable & "(DrawingOrder, ButtonText, TableName, DataCode, DataCodeName, ButtonColor) "

        strQuery = strQuery & "VALUES (" & Me.DrawingOrder & ", " & SingleQuote(Me.ButtonName) & ", " & SingleQuote(Me.TableName) & ", " & Me.DataCode & ", " & SingleQuote(Me.FieldName) & ", 'DarkBlue')"

        Dim oComm As New OleDbCommand(strQuery, conn)
        oComm.ExecuteNonQuery()

        strQuery = "DELETE * FROM " & strConfigureTable & " " & _
                "WHERE ButtonText = " & SingleQuote(Me.ButtonName)

        oComm = New OleDbCommand(strQuery, conn)
        oComm.ExecuteNonQuery()

        Call Me.UpdateDrawingOrder(strMoveToTable)

        Call frmConfigureButtons_Activated(sender, e)

        If strMoveToTable = DB_TRANSECT_BUTTONS_TABLE Then
            dictTransectFieldValues.Add(Me.ButtonName, Me.DataCode)
            dictHabitatFieldValues.Remove(Me.ButtonName)
        Else
            dictTransectFieldValues.Remove(Me.ButtonName)
            dictHabitatFieldValues.Add(Me.ButtonName, Me.DataCode)
        End If
        'Call RefreshDatabase(sender, e)

    End Sub
End Class