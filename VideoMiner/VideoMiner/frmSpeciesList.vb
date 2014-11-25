Imports System.Data.OleDb
Public Class frmSpeciesList

    Dim frmEditSpecies As frmEditSpecies

    Event RefreshDatabaseEvent()

    Private Sub frmSpeciesList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Try
            Me.lstSpecies.Items.Clear()
            Dim sub_data_set As DataSet = New DataSet()

            Dim sub_db_command As OleDbCommand = New OleDbCommand("select DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", conn)
            Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)

            sub_data_adapter.Fill(sub_data_set, DB_SPECIES_BUTTONS_TABLE)

            Dim r As DataRow
            Dim taxRow As DataRow
            Dim d As DataTable
            Dim taxData As DataTable
            d = sub_data_set.Tables(0)

            Dim itm As ListViewItem
            For Each r In d.Rows
                itm = New ListViewItem
                itm.Text = ""

                itm.SubItems.Add(r.Item("ButtonText").ToString())
                itm.SubItems.Add(r.Item("ButtonCode").ToString())


                Dim tax_data_set As DataSet = New DataSet()
                Dim tax_db_command As OleDbCommand = New OleDbCommand("Select SpeciesCode, TaxonomyClassLevelCode from lu_species_code WHERE SpeciesCode = " & SingleQuote(r.Item("ButtonCode")) & ";", conn)
                Dim tax_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(tax_db_command)
                tax_data_adapter.Fill(tax_data_set, "lu_species_code")
                taxData = tax_data_set.Tables(0)
                taxRow = taxData.Rows.Item(0)

                itm.SubItems.Add(taxRow.Item("TaxonomyClassLevelCode").ToString())

                Me.lstSpecies.Items.Add(itm)
            Next
        Catch ex As Exception

        End Try


    End Sub


    Public Sub New()
        InitializeComponent()
        With Me.lstSpecies
            .Visible = True
            .FullRowSelect = True
            .View = View.Details
            .HeaderStyle = ColumnHeaderStyle.Nonclickable
            .HideSelection = False
            .Focus()
            .Columns.Add("", 0, HorizontalAlignment.Left)
            .Columns.Add("Button Text", 157, HorizontalAlignment.Left)
            .Columns.Add("Species Code", 90, HorizontalAlignment.Left)
            .Columns.Add("Taxonomic Code", 110, HorizontalAlignment.Left)
        End With
    End Sub

    Private Sub cmdMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveUp.Click

        If Me.lstSpecies.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstSpecies.SelectedItems(0).Index
            'MsgBox(intSelectedIndex)
            MoveListViewItem(intSelectedIndex - 1)
        Else
            MsgBox("Please select a species from the list")
        End If
    End Sub

    Private Sub cmdMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveDown.Click

        If Me.lstSpecies.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstSpecies.SelectedItems(0).Index
            'MsgBox(intSelectedIndex)
            MoveListViewItem(intSelectedIndex + 1)
        Else
            MsgBox("Please select a species from the list")
        End If

    End Sub

    Private Sub cmdMoveToTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveToTop.Click

        If Me.lstSpecies.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstSpecies.SelectedItems(0).Index
            'MsgBox(intSelectedIndex)
            MoveListViewItem(0)
        Else
            MsgBox("Please select a species from the list")
        End If

    End Sub

    Private Sub cmdMoveToBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveToBottom.Click
        If Me.lstSpecies.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstSpecies.SelectedItems(0).Index
            'MsgBox(intSelectedIndex)
            MoveListViewItem(Me.lstSpecies.Items.Count - 1)
        Else
            MsgBox("Please select a species from the list")
        End If

    End Sub

    Private Sub MoveListViewItem(ByVal moveToIndex As Integer)
        Me.lstSpecies.Focus()
        Dim index As Integer = 0
        Dim item As ListViewItem
        index = Me.lstSpecies.SelectedIndices.Item(0)
        item = Me.lstSpecies.SelectedItems.Item(0)
        Me.lstSpecies.Items.RemoveAt(index)
        Me.lstSpecies.Items.Insert(moveToIndex, item)
        Me.lstSpecies.Items(moveToIndex).Selected = True
        Me.lstSpecies.Items(moveToIndex).Focused = True
        Me.lstSpecies.EnsureVisible(moveToIndex)
        Me.lstSpecies.Refresh()

        'Dim i As Integer
        'Dim cache As String
        'Dim selIdx As Integer

        'With Me.lstSpecies
        '    If .SelectedIndices.Count = 0 Then
        '        Exit Sub
        '    Else
        '        selIdx = .SelectedIndices.Item(0)
        '    End If

        '    If moveUp Then
        '        ' ignore moveup of row(0)
        '        If selIdx = 0 Then
        '            Exit Sub
        '        End If

        '        ' move the subitems for the previous row
        '        ' to cache so we can move the selected row up
        '        Dim strFields As String = ""

        '        For i = 0 To .Items(selIdx).SubItems.Count - 1
        '            cache = .Items(selIdx - 1).SubItems(i).Text

        '            .Items(selIdx - 1).SubItems(i).Text = .Items(selIdx).SubItems(i).Text
        '            .Items(selIdx).SubItems(i).Text = cache
        '        Next
        '        .Items(selIdx - 1).Selected = True
        '        .Items(selIdx - 1).Focused = True
        '        .EnsureVisible(selIdx - 1)
        '        .Refresh()
        '        .Focus()
        '    Else
        '        ' ignore move down of last row
        '        If selIdx = .Items.Count - 1 Then
        '            Exit Sub
        '        End If
        '        ' move the subitems for the next row
        '        ' to cache so we can move the selected row down
        '        For i = 0 To .Items(selIdx).SubItems.Count - 1
        '            cache = .Items(selIdx + 1).SubItems(i).Text
        '            .Items(selIdx + 1).SubItems(i).Text = .Items(selIdx).SubItems(i).Text
        '            .Items(selIdx).SubItems(i).Text = cache
        '        Next

        '        .Items(selIdx + 1).Selected = True
        '        .Items(selIdx + 1).Focused = True
        '        .EnsureVisible(selIdx)
        '        .Refresh()
        '        .Focus()
        '    End If
        'End With

        UpdateDrawingOrder()

    End Sub

    Private Sub cmdInsertNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsertNew.Click
        'Me.UpdateDrawingOrder()
        'frmEditSpecies.txtSpeciesBtnTxt.Enabled = False
        frmEditSpecies = New frmEditSpecies
        With frmEditSpecies
            .OriginalSpeciesName = ""
            .OriginalSpeciesCode = ""
            .cboCommonName.Text = ""
            .cboLatinName.Text = ""
            .cboScientificName.Text = ""
            .Edit_Insert = "Insert"
            .ShowDialog()
        End With
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If Me.lstSpecies.SelectedItems.Count = 0 Then
                MsgBox("Please select a species from the list")
                Exit Sub
            End If
            frmEditSpecies = New frmEditSpecies
            With frmEditSpecies
                .Edit_Insert = "Edit"
                .cboCommonName.Text = ""
                .cboLatinName.Text = ""
                .cboScientificName.Text = ""
            End With
            'Me.UpdateDrawingOrder()

            Dim selIdx As Integer = Me.lstSpecies.SelectedIndices.Item(0)
            Dim strOriginalSpeciesName As String = Me.lstSpecies.Items(selIdx).SubItems(1).Text
            Dim strOriginalSpeciesCode As String = Me.lstSpecies.Items(selIdx).SubItems(2).Text

            With frmEditSpecies
                .selIdx = selIdx
                .OriginalSpeciesName = strOriginalSpeciesName
                .OriginalSpeciesCode = strOriginalSpeciesCode
                .ShowDialog()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click

        Me.UpdateDrawingOrder()

        Me.Close()

    End Sub

    Private Sub UpdateDrawingOrder()

        Dim oComm As OleDbCommand
        Dim query As String

        Dim strSpeciesName As String
        Dim strSpeciesCode As String

        query = "UPDATE " & DB_SPECIES_BUTTONS_TABLE & " " & _
                "SET DrawingOrder = DrawingOrder + 1000"
        oComm = New OleDbCommand(query, conn)
        oComm.ExecuteNonQuery()

        For i As Integer = 0 To Me.lstSpecies.Items.Count - 1

            strSpeciesName = Me.lstSpecies.Items(i).SubItems(1).Text
            strSpeciesCode = Me.lstSpecies.Items(i).SubItems(2).Text

            query = "UPDATE " & DB_SPECIES_BUTTONS_TABLE & " " & _
                    "SET DrawingOrder = " & i + 1 & " " & _
                    "WHERE ButtonText = " & DoubleQuote(strSpeciesName) & " AND " & _
                    "      ButtonCode = " & DoubleQuote(strSpeciesCode)

            oComm = New OleDbCommand(query, conn)
            oComm.ExecuteNonQuery()

        Next

        RaiseEvent RefreshDatabaseEvent()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim selIdx As Integer
        Try
            selIdx = Me.lstSpecies.SelectedIndices.Item(0)
        Catch ex As Exception
            selIdx = 0
        End Try

        If Me.lstSpecies.SelectedItems.Count = 0 Then
            MsgBox("Please select a species from the list")
            Exit Sub
        End If

        Dim dr As DialogResult
        dr = MessageBox.Show("Are you sure you want to delete this species button?", "Delete Species Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dr = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Me.UpdateDrawingOrder()

        Dim strSpeciesName As String = Me.lstSpecies.Items(selIdx).SubItems(1).Text
        Dim strSpeciesCode As String = Me.lstSpecies.Items(selIdx).SubItems(2).Text

        Dim oComm As OleDbCommand
        Dim query As String

        query = "DELETE * FROM " & DB_SPECIES_BUTTONS_TABLE & " " & _
                "WHERE ButtonText = " & SingleQuote(strSpeciesName) & " AND " & _
                "      ButtonCode = " & SingleQuote(strSpeciesCode)

        oComm = New OleDbCommand(query, conn)
        oComm.ExecuteNonQuery()

        frmSpeciesList_Activated(Nothing, Nothing)

    End Sub

    Private Sub lstSpecies_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstSpecies.DragDrop
        'Return if the items are not selected in the ListView control.
        If lstSpecies.SelectedItems.Count = 0 Then Return
        'Returns the location of the mouse pointer in the ListView control.
        Dim p As System.Drawing.Point = lstSpecies.PointToClient(New System.Drawing.Point(e.X, e.Y))
        'Obtain the item that is located at the specified location of the mouse pointer.
        Dim dragToItem As ListViewItem = lstSpecies.GetItemAt(p.X, p.Y)
        If dragToItem Is Nothing Then Return
        'Obtain the index of the item at the mouse pointer.
        Dim dragIndex As Integer = dragToItem.Index
        Dim i As Integer
        Dim sel(lstSpecies.SelectedItems.Count) As ListViewItem
        For i = 0 To lstSpecies.SelectedItems.Count - 1
            sel(i) = lstSpecies.SelectedItems.Item(i)
        Next
        For i = 0 To lstSpecies.SelectedItems.Count - 1
            'Obtain the ListViewItem to be dragged to the target location.
            Dim dragItem As ListViewItem = sel(i)
            Dim itemIndex As Integer = dragIndex
            If itemIndex = dragItem.Index Then Return
            If dragItem.Index < itemIndex Then
                itemIndex = itemIndex + 1
            Else
                itemIndex = dragIndex + i
            End If
            'Insert the item in the specified location.
            Dim insertitem As ListViewItem = dragItem.Clone
            lstSpecies.Items.Insert(itemIndex, insertitem)
            'Removes the item from the initial location while 
            'the item is moved to the new location.
            lstSpecies.Items.Remove(dragItem)
        Next
        UpdateDrawingOrder()
    End Sub

    Private Sub lstSpecies_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstSpecies.DragEnter
        Dim i As Integer
        For i = 0 To e.Data.GetFormats().Length - 1
            If e.Data.GetFormats()(i).Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection") Then
                'The data from the drag source is moved to the target.
                e.Effect = DragDropEffects.Move
            End If
        Next
    End Sub

  
    Private Sub lstSpecies_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lstSpecies.ItemDrag
        lstSpecies.DoDragDrop(lstSpecies.SelectedItems, DragDropEffects.Move)
    End Sub

End Class