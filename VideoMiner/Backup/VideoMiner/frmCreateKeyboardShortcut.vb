Public Class frmCreateKeyboardShortcut

    Private m_ButtonText As String
    Private m_KeyboardShortcut As String
    Public Property ButtonText() As String
        Get
            Return m_ButtonText
        End Get
        Set(ByVal value As String)
            m_ButtonText = value
        End Set
    End Property

    Public Property KeyboardShortcut() As String
        Get
            Return m_KeyboardShortcut
        End Get
        Set(ByVal value As String)
            m_KeyboardShortcut = value
        End Set
    End Property

    Private blTyping As Boolean = False
    Private strCurrentKey As String = ""
    Private value As Array = [Enum].GetValues(GetType(Keys))

    Private Sub frmCreateKeyboardShortcut_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myFormLibrary.frmCreateKeyboardShortcut = Nothing
    End Sub
    Private Sub frmCreateKeyboardShortcut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If blTyping = True Then
            If strCurrentKey <> CStr(e.KeyValue) Then
                strCurrentKey = CStr(e.KeyValue)
                Dim key As Object
                For Each key In value
                    If e.KeyValue = key Then
                        If key.ToString <> "Menu" And key.ToString <> "LWin" And key.ToString <> "RWin" Then
                            If Me.txtCurrentShortcut.Text = "" Then
                                Me.txtCurrentShortcut.Text = key.ToString
                            Else
                                Me.txtCurrentShortcut.Text = Me.txtCurrentShortcut.Text & "+" & key.ToString
                            End If
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub frmCreateKeyboardShortcut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        strCurrentKey = ""
    End Sub

    Private Sub frmCreateKeyboardShortcut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myFormLibrary.frmCreateKeyboardShortcut = Me
        Me.txtCurrentShortcut.Text = Me.KeyboardShortcut
    End Sub

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        If Me.cmdStart.Text = "Start Typing" Then
            Me.txtCurrentShortcut.Text = ""
            blTyping = True
            Me.cmdStart.Text = "Stop Typing"
            Me.cmdOK.Enabled = False
            Me.cmdCancel.Enabled = False
        Else
            blTyping = False
            Me.cmdStart.Text = "Start Typing"
            Me.cmdOK.Enabled = True
            Me.cmdCancel.Enabled = True
            Dim query As String
            Dim oComm As OleDb.OleDbCommand
            query = "SELECT KeyboardShortcut FROM " & DB_SPECIES_BUTTONS_TABLE & " WHERE KeyboardShortcut = " & DoubleQuote(Me.txtCurrentShortcut.Text)
            Dim sub_data_set As DataSet = New DataSet()
            oComm = New OleDb.OleDbCommand(query, conn)
            Dim sub_data_adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(oComm)
            sub_data_adapter.Fill(sub_data_set, DB_SPECIES_BUTTONS_TABLE)
            Dim r As DataRow
            Dim d As DataTable
            d = sub_data_set.Tables(0)
            If d.Rows.Count <> 0 Then
                MsgBox("That keyboard shortcut is already in use, please enter a new one.")
                Me.txtCurrentShortcut.Text = Me.KeyboardShortcut
            End If
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Dim query As String
            Dim oComm As OleDb.OleDbCommand
            query = "UPDATE " & DB_SPECIES_BUTTONS_TABLE & " " & _
                        "SET KeyboardShortCut = " & DoubleQuote(Me.txtCurrentShortcut.Text) & " " & _
                        "WHERE ButtonText = " & DoubleQuote(Me.ButtonText)

            oComm = New OleDb.OleDbCommand(query, conn)
            oComm.ExecuteNonQuery()
            If Not myFormLibrary.frmEditSpecies Is Nothing Then
                myFormLibrary.frmEditSpecies.txtKeyboardShortcut.Text = Me.txtCurrentShortcut.Text
            End If
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub
End Class