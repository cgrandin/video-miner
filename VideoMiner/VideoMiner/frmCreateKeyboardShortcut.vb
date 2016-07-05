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

    'Private value As Array = [Enum].GetValues(GetType(Keys))

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case CType(msg.WParam.ToInt32, Keys)
            Case Keys.Enter
                cmdOK_Click(Me, EventArgs.Empty)
                Return True
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
    End Function

    ''' <summary>
    ''' Read user keypresses, and show them in the textbox.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmCreateKeyboardShortcut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim kc As KeysConverter = New KeysConverter()
        Dim strKey As String = kc.ConvertToString(e.KeyCode)

        If strKey <> "Menu" And
           strKey <> "LWin" And
           strKey <> "RWin" And
           strKey <> "ControlKey" And
           strKey <> "ShiftKey" Then
            If e.Modifiers = Keys.Control Then
                strKey = "Control+" & strKey
            End If
            If e.Modifiers = Keys.Shift Then
                strKey = "Shift+" & strKey
            End If
            txtCurrentShortcut.Text = strKey
        End If
    End Sub

    Private Sub frmCreateKeyboardShortcut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCurrentShortcut.Text = KeyboardShortcut
        txtCurrentShortcut.Enabled = True
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim strQuery As String
        ' Check to see if the entered shortcut is valid
        strQuery = "SELECT KeyboardShortcut FROM " & DB_SPECIES_BUTTONS_TABLE &
                   " WHERE KeyboardShortcut = " & DoubleQuote(txtCurrentShortcut.Text)
        Dim dt As DataTable = Database.GetDataTable(strQuery, DB_SPECIES_BUTTONS_TABLE)
        If dt.Rows.Count <> 0 Then
            MessageBox.Show("That keyboard shortcut is already in use, please try again.",
                            "Shortcut already used", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCurrentShortcut.Text = KeyboardShortcut
        Else
            strQuery = "UPDATE " & DB_SPECIES_BUTTONS_TABLE &
                       " SET KeyboardShortCut = " & DoubleQuote(txtCurrentShortcut.Text) &
                       " WHERE ButtonText = " & DoubleQuote(ButtonText)
            Database.ExecuteNonQuery(strQuery)
            RaiseEvent AddedNewShortcut()
            Close()
        End If
    End Sub

End Class