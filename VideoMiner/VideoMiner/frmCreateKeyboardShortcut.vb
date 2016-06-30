Public Class frmCreateKeyboardShortcut

    Private m_ButtonText As String
    Private m_KeyboardShortcut As String

    Event AddedNewShortcut()

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

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmCreateKeyboardShortcut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If blTyping = True Then
            If strCurrentKey <> CStr(e.KeyValue) Then
                strCurrentKey = CStr(e.KeyValue)
                Dim key As Object
                For Each key In value
                    If e.KeyValue = key Then
                        If key.ToString <> "Menu" And key.ToString <> "LWin" And key.ToString <> "RWin" Then
                            If txtCurrentShortcut.Text = "" Then
                                txtCurrentShortcut.Text = key.ToString
                            Else
                                txtCurrentShortcut.Text = txtCurrentShortcut.Text & "+" & key.ToString
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
        txtCurrentShortcut.Text = KeyboardShortcut
    End Sub

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        If cmdStart.Text = "Start Typing" Then
            txtCurrentShortcut.Text = ""
            blTyping = True
            cmdStart.Text = "Stop Typing"
            cmdOK.Enabled = False
            cmdCancel.Enabled = False
        Else
            blTyping = False
            cmdStart.Text = "Start Typing"
            cmdOK.Enabled = True
            cmdCancel.Enabled = True
            Dim strQuery As String = "SELECT KeyboardShortcut FROM " & DB_SPECIES_BUTTONS_TABLE & " WHERE KeyboardShortcut = " & DoubleQuote(txtCurrentShortcut.Text)
            Dim dt As DataTable = Database.GetDataTable(strQuery, DB_SPECIES_BUTTONS_TABLE)
            If dt.Rows.Count <> 0 Then
                MsgBox("That keyboard shortcut is already in use, please enter a new one.")
                txtCurrentShortcut.Text = KeyboardShortcut
            End If
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim strQuery As String
        strQuery = "UPDATE " & DB_SPECIES_BUTTONS_TABLE &
                   " SET KeyboardShortCut = " & DoubleQuote(txtCurrentShortcut.Text) &
                   " WHERE ButtonText = " & DoubleQuote(ButtonText)
        Database.ExecuteNonQuery(strQuery)
        RaiseEvent AddedNewShortcut()
        Close()
    End Sub
End Class