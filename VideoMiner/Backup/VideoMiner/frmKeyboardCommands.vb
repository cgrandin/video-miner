Imports System.Data.OleDb

Public Class frmKeyboardCommands

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' -------------------------------------------------
        ' Initialize Form elements
        ' -------------------------------------------------
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

        myFormLibrary.frmKeyboardCommands = Me

    End Sub



    Private Sub frmKeyboardCommands_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myFormLibrary.frmKeyboardCommands = Nothing
    End Sub

    Private Sub frmKeyboardCommands_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Try
            Me.lstSpecies.Items.Clear()
            Dim sub_data_set As DataSet = New DataSet()

            Dim sub_db_command As OleDbCommand = New OleDbCommand("select DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor, KeyboardShortcut from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", conn)
            Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)

            sub_data_adapter.Fill(sub_data_set, DB_SPECIES_BUTTONS_TABLE)

            Dim d As DataTable
            Dim r As DataRow
            d = sub_data_set.Tables(0)

            Dim itm As ListViewItem
            For Each r In d.Rows
                itm = New ListViewItem
                itm.Text = ""

                itm.SubItems.Add(r.Item("ButtonText").ToString())
                itm.SubItems.Add(r.Item("KeyboardShortcut").ToString())

                Me.lstSpecies.Items.Add(itm)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        myFormLibrary.frmVideoMiner.blupdateColumns = False
        Call RefreshDatabase(Me, New EventArgs)
        myFormLibrary.frmVideoMiner.blupdateColumns = False
        Me.Close()
    End Sub

    Private Sub cmdAssignShortcut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAssignShortcut.Click
        If Me.lstSpecies.SelectedItems.Count = 0 Then
            MsgBox("Please select a species button from the list")
            Exit Sub
        End If

        myFormLibrary.frmCreateKeyboardShortcut = New frmCreateKeyboardShortcut

        Dim selIdx As Integer = Me.lstSpecies.SelectedIndices.Item(0)
        myFormLibrary.frmCreateKeyboardShortcut.ButtonText = Me.lstSpecies.Items(selIdx).SubItems(1).Text
        myFormLibrary.frmCreateKeyboardShortcut.KeyboardShortcut = Me.lstSpecies.Items(selIdx).SubItems(2).Text

        myFormLibrary.frmCreateKeyboardShortcut.ShowDialog()

    End Sub
End Class