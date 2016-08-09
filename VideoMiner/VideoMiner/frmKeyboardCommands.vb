Public Class frmKeyboardCommands

    Private WithEvents m_frmCreateKeyboardShortcut As frmCreateKeyboardShortcut

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
            .Columns.Add(NULL_STRING, 0, HorizontalAlignment.Left)
            .Columns.Add("Button Text", 160, HorizontalAlignment.Left)
            .Columns.Add("Keyboard Shortcut", 160, HorizontalAlignment.Left)
        End With
    End Sub

    ''' <summary>
    ''' Fetch the data from the database for the species buttons table, ordered by drawing order,
    ''' and add the Button text and keyboard shortcuts to the list as columns.
    ''' </summary>
    Private Sub frmKeyboardCommands_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        populateTable()
    End Sub

    Private Sub populateTable()
        Me.lstSpecies.Items.Clear()
        Dim d As DataTable = Database.GetDataTable("select DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor, KeyboardShortcut from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", DB_SPECIES_BUTTONS_TABLE)
        Dim itm As ListViewItem
        For Each r As DataRow In d.Rows
            itm = New ListViewItem
            itm.Text = NULL_STRING
            itm.SubItems.Add(r.Item(BUTTON_TEXT).ToString())
            itm.SubItems.Add(r.Item(KEYBOARD_SHORTCUT).ToString())
            Me.lstSpecies.Items.Add(itm)
        Next
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        RaiseEvent RefreshDatabaseEvent()
        Me.Hide()
    End Sub

    ''' <summary>
    ''' Brings up a dialog box where you can add, edit, or delete a keyboard shortcut for a species.
    ''' </summary>
    Private Sub cmdAssignShortcut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAssignShortcut.Click
        If Me.lstSpecies.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a species button from the list", "Choose species", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If m_frmCreateKeyboardShortcut Is Nothing Then
            m_frmCreateKeyboardShortcut = New frmCreateKeyboardShortcut()
        End If
        Dim selIdx As Integer = Me.lstSpecies.SelectedIndices.Item(0)
        m_frmCreateKeyboardShortcut.ButtonText = Me.lstSpecies.Items(selIdx).SubItems(1).Text
        m_frmCreateKeyboardShortcut.KeyboardShortcut = Me.lstSpecies.Items(selIdx).SubItems(2).Text
        m_frmCreateKeyboardShortcut.ShowDialog()
    End Sub

    Private Sub cmdDeleteShortcut_Click(sender As Object, e As EventArgs) Handles cmdDeleteShortcut.Click
        If Me.lstSpecies.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a species button from the list", "Choose species", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim selIdx As Integer = Me.lstSpecies.SelectedIndices.Item(0)
        Dim strSpecies As String = Me.lstSpecies.Items(selIdx).SubItems(1).Text
        Dim strKeyboardShortcut As String = Me.lstSpecies.Items(selIdx).SubItems(2).Text
        Dim strQuery As String
        strQuery = "UPDATE " & DB_SPECIES_BUTTONS_TABLE &
                   " SET KeyboardShortCut = " & DoubleQuote(String.Empty) &
                   " WHERE ButtonText = " & DoubleQuote(strSpecies)
        Database.ExecuteNonQuery(strQuery)
        populateTable()
    End Sub
End Class