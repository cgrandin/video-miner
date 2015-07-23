Public Class frmKeyboardCommands

    Event RefreshDatabaseEvent()

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
            .Columns.Add("Button Text", 160, HorizontalAlignment.Left)
            .Columns.Add("Keyboard Shortcut", 160, HorizontalAlignment.Left)
        End With
    End Sub

    Private Sub frmKeyboardCommands_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.lstSpecies.Items.Clear()
        Dim d As DataTable = Database.GetDataTable("select DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor, KeyboardShortcut from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", DB_SPECIES_BUTTONS_TABLE)
        Dim itm As ListViewItem
        For Each r As DataRow In d.Rows
            itm = New ListViewItem
            itm.Text = ""
            itm.SubItems.Add(r.Item("ButtonText").ToString())
            itm.SubItems.Add(r.Item("KeyboardShortcut").ToString())
            Me.lstSpecies.Items.Add(itm)
        Next
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        RaiseEvent RefreshDatabaseEvent()
        Me.Hide()
    End Sub

    Private Sub cmdAssignShortcut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAssignShortcut.Click
        If Me.lstSpecies.SelectedItems.Count = 0 Then
            MsgBox("Please select a species button from the list")
            Exit Sub
        End If
        frmCreateKeyboardShortcut = New frmCreateKeyboardShortcut
        Dim selIdx As Integer = Me.lstSpecies.SelectedIndices.Item(0)
        frmCreateKeyboardShortcut.ButtonText = Me.lstSpecies.Items(selIdx).SubItems(1).Text
        frmCreateKeyboardShortcut.KeyboardShortcut = Me.lstSpecies.Items(selIdx).SubItems(2).Text
        frmCreateKeyboardShortcut.ShowDialog()
    End Sub
End Class