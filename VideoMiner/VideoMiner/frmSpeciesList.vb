''' <summary>
''' This form allows the user to change the order and/or information about the species in the database table 'videominer_species_buttons'. It also allows
''' for new species to be enetered (new buttons) or for species to be deleted (removes buttons).
''' </summary>
''' <remarks>The changes made by the user are enacted by first making changes to the database, then firing an event to the main videominer form, where the dynamic panel will be
''' deleted and recreated using the constructor code found in the DynamicPanel class.</remarks>
Public Class frmSpeciesList

    Dim frmEditSpecies As frmEditSpecies

    Event SpeciesButtonsChangedEvent()

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

    ''' <summary>
    ''' Fires when the List becomes active, and calls a function to fill the list from the database.
    ''' </summary>
    Private Sub frmSpeciesList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        fillSpeciesList()
    End Sub

    ''' <summary>
    ''' Fills in the species list from the database
    ''' </summary>
    Private Sub fillSpeciesList()
        Dim taxRow As DataRow
        Dim taxData As DataTable
        Dim itm As ListViewItem
        Me.lstSpecies.Items.Clear()
        Dim d As DataTable = Database.GetDataTable("select DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", DB_SPECIES_BUTTONS_TABLE)
        For Each r As DataRow In d.Rows
            itm = New ListViewItem
            itm.Text = ""
            itm.SubItems.Add(r.Item("ButtonText").ToString())
            itm.SubItems.Add(r.Item("ButtonCode").ToString())
            taxData = Database.GetDataTable("Select SpeciesCode, TaxonomyClassLevelCode from " & DB_SPECIES_CODE_TABLE & " WHERE SpeciesCode = " & SingleQuote(r.Item("ButtonCode")) & ";", DB_SPECIES_CODE_TABLE)
            taxRow = taxData.Rows.Item(0)
            itm.SubItems.Add(taxRow.Item("TaxonomyClassLevelCode").ToString())
            Me.lstSpecies.Items.Add(itm)
        Next
    End Sub

    ''' <summary>
    ''' Move the selected row up by one, and make this change in the database. If the selected item is the first one, do nothing.
    ''' </summary>
    Private Sub cmdMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveUp.Click
        If Me.lstSpecies.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstSpecies.SelectedItems(0).Index
            If intSelectedIndex > 0 Then
                MoveListViewItem(intSelectedIndex - 1)
            End If
        Else
            MessageBox.Show("Please select a species from the list first.", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Move the selected row down by one, and make this change in the database. If the selected item is the last one, do nothing.
    ''' </summary>
    Private Sub cmdMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveDown.Click
        If Me.lstSpecies.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstSpecies.SelectedItems(0).Index
            If intSelectedIndex < Me.lstSpecies.Items.Count - 1 Then
                MoveListViewItem(intSelectedIndex + 1)
            End If
        Else
            MessageBox.Show("Please select a species from the list first.", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    ''' <summary>
    ''' Move the selected row up to the top, and make this change in the database. If the selected item is the first one, do nothing.
    ''' </summary>
    Private Sub cmdMoveToTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveToTop.Click
        If Me.lstSpecies.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstSpecies.SelectedItems(0).Index
            If intSelectedIndex > 0 Then
                MoveListViewItem(0)
            End If
        Else
            MessageBox.Show("Please select a species from the list first.", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Move the selected row down to the bottom, and make this change in the database. If the selected item is the last one, do nothing.
    ''' </summary>
    Private Sub cmdMoveToBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveToBottom.Click
        If Me.lstSpecies.SelectedItems.Count > 0 Then
            Dim intSelectedIndex As Integer
            intSelectedIndex = Me.lstSpecies.SelectedItems(0).Index
            If intSelectedIndex < Me.lstSpecies.Items.Count - 1 Then
                MoveListViewItem(Me.lstSpecies.Items.Count - 1)
            End If
        Else
            MessageBox.Show("Please select a species from the list first.", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Moves the selected item from wherever it is to the given index.
    ''' </summary>
    ''' <param name="moveToIndex">Index to move the selected item to. 0 is the first element.</param>
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

    ''' <summary>
    ''' Change the database to relect the user change in order in the list. Once the database has been modified, raise an event to the main form so that
    ''' the dynamic panel can be redrawn.
    ''' </summary>
    Private Sub UpdateDrawingOrder()
        Dim strSpeciesName As String
        Dim strSpeciesCode As String
        Database.ExecuteNonQuery("UPDATE " & DB_SPECIES_BUTTONS_TABLE & " SET DrawingOrder = DrawingOrder + 1000")
        For i As Integer = 0 To Me.lstSpecies.Items.Count - 1
            strSpeciesName = Me.lstSpecies.Items(i).SubItems(1).Text
            strSpeciesCode = Me.lstSpecies.Items(i).SubItems(2).Text
            Database.ExecuteNonQuery("UPDATE " & DB_SPECIES_BUTTONS_TABLE & " SET DrawingOrder = " & i + 1 & " " & _
                    "WHERE ButtonText = " & DoubleQuote(strSpeciesName) & " AND ButtonCode = " & DoubleQuote(strSpeciesCode))
        Next
        RaiseEvent SpeciesButtonsChangedEvent()
    End Sub

    ''' <summary>
    ''' When the user clicks the delete button, whatever list item is selected will be deleted from the database and removed from the button collection.
    ''' A confirmation dialog will be issued first.
    ''' </summary>
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If Me.lstSpecies.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a species from the list first.", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Me.lstSpecies.SelectedItems.Count > 0 Then
            Dim selIdx As Integer = Me.lstSpecies.SelectedItems(0).Index
            Dim dr As DialogResult = MessageBox.Show("Are you sure you want to delete this species button?", "Delete Species Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dr = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            Dim strSpeciesName As String = Me.lstSpecies.Items(selIdx).SubItems(1).Text
            Dim strSpeciesCode As String = Me.lstSpecies.Items(selIdx).SubItems(2).Text
            Database.ExecuteNonQuery("DELETE * FROM " & DB_SPECIES_BUTTONS_TABLE & " WHERE ButtonText = " & SingleQuote(strSpeciesName) & " AND " & _
                    " ButtonCode = " & SingleQuote(strSpeciesCode))
            ' Redraw the buttons and refill the list with the fresh data which has one item removed.
            UpdateDrawingOrder()
            fillSpeciesList()
        End If
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