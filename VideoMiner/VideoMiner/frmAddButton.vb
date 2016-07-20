Imports System.Data.OleDb
Imports ADOX
Imports ADODB

Public Class frmAddButton

#Region "Member variables"
    ' Data, table, and query objects
    Private m_table_name As String
    Private m_data_table As DataTable
    Private m_data_set As DataSet

    Private m_ButtonName As String
    Private m_TableName As String
    Private m_DataCode As Integer
    Private m_FieldName As String
    Private m_DrawingOrder As String

    Private m_OldButtonName As String
    Private m_OldTableName As String
    Private m_OldDataCode As Integer
    Private m_OldFieldName As String
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

    Public Property OldButtonName() As String
        Get
            Return m_OldButtonName
        End Get
        Set(ByVal value As String)
            m_OldButtonName = value
        End Set
    End Property

    Public Property OldTableName() As String
        Get
            Return m_OldTableName
        End Get
        Set(ByVal value As String)
            m_OldTableName = value
        End Set
    End Property

    Public Property OldDataCode() As Integer
        Get
            Return m_OldDataCode
        End Get
        Set(ByVal value As Integer)
            m_OldDataCode = value
        End Set
    End Property

    Public Property OldFieldName() As String
        Get
            Return m_OldFieldName
        End Get
        Set(ByVal value As String)
            m_OldFieldName = value
        End Set
    End Property

#End Region

    Event LockUpdateEvent()
    Event UnlockUpdateEvent()
    Event RefreshDatabaseEvent()
    Event AddNewTableEvent()

    Public Sub New(strConfigureTable As String)
        InitializeComponent()
        m_table_name = strConfigureTable
    End Sub

    Private Sub txtDataCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDataCode.KeyPress
        numericTextboxValidation(e)
    End Sub

    Private Sub txtFieldName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFieldName.TextChanged
        Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim txtName As String = Me.txtFieldName.Text
        Dim Letter As String
        Dim sel_s As Integer = Me.txtFieldName.SelectionStart
        Dim did_change As Boolean = False
        For x As Integer = 0 To Me.txtFieldName.Text.Length - 1
            Letter = Me.txtFieldName.Text.Substring(x, 1).ToUpper
            If strCharactersAllowed.Contains(Letter) = False Then
                txtName = txtName.Replace(Letter, String.Empty)
                did_change = True
            End If
        Next
        If Me.txtFieldName.Text.Length = 1 Then
            Me.txtFieldName.Text = txtName.ToUpper
        Else
            Me.txtFieldName.Text = txtName
        End If
        If did_change = False Then
            Me.txtFieldName.Select(sel_s, 0)
        Else
            Me.txtFieldName.Select(sel_s - 1, 0)
        End If
    End Sub

    Private Sub frmAddButton_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        blButtonEdit = False
    End Sub

    Private Sub frmAddButton_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tblSchema As DataTable = Database.GetDataTableSchema()
        For i As Integer = 0 To tblSchema.Rows.Count - 1
            If tblSchema.Rows(i)!TABLE_TYPE.ToString = "TABLE" Then
                Dim strTableName As String
                strTableName = tblSchema.Rows(i)!TABLE_NAME.ToString
                If strTableName.Substring(0, 3) = "lu_" Then
                    If strTableName <> DB_BUTTON_COLORS_TABLE And strTableName <> DB_DATA_CODES_TABLE And strTableName <> DB_SPECIES_CODE_TABLE Then
                        Me.cboTables.Items.Add(strTableName)
                    End If
                End If
            End If
        Next
        If blButtonEdit Then
            Dim d As DataTable = Database.GetDataTable("SELECT ButtonText, TableName, DataCode, DataCodeName FROM " & m_table_name & " WHERE ButtonText = " & SingleQuote(Me.txtButtonName.Text) & ";", m_table_name)
            Dim r As DataRow = d.Rows.Item(0)
            If Not r Is Nothing Then
                If r.Item("TableName") = "UserEntered" Then
                    Me.rdInputValue.Checked = True
                    Me.cboTables.Enabled = False
                    Me.cmdCreateNewTable.Enabled = False
                Else
                    Me.rdUseTable.Checked = True
                    Me.cboTables.SelectedItem = r.Item("TableName")
                End If
                Me.txtDataCode.Text = r.Item("DataCode")
                Me.txtFieldName.Text = r.Item("DataCodeName")
                Me.OldButtonName = Me.txtButtonName.Text
                Me.OldTableName = Me.cboTables.SelectedItem
                Me.OldDataCode = CInt(Me.txtDataCode.Text)
                Me.OldFieldName = Me.txtFieldName.Text
            End If
            strEditTextBoxOldName = "txt" & Replace(Me.txtButtonName.Text, "%", "Percent")
            Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"
            Dim txtName As String = strEditTextBoxOldName
            Dim letter As String
            For x As Integer = 0 To strEditTextBoxOldName.Length - 1
                letter = strEditTextBoxOldName.Substring(x, 1).ToUpper
                If strCharactersAllowed.Contains(letter) = False Then
                    txtName = txtName.Replace(letter, String.Empty)
                End If
            Next
            strEditTextBoxOldName = txtName
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Hide()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.ButtonName = Me.txtButtonName.Text
        Me.TableName = Me.cboTables.SelectedItem
        Me.DataCode = CInt(Me.txtDataCode.Text)
        Me.FieldName = Me.txtFieldName.Text
        Dim strInsertQuery As String
        Dim numrows As Integer

        Dim tblDrawingOrder As DataTable
        Dim tblDataCodes As DataTable
        Dim r As DataRow
        If blButtonEdit = False Then
            blNewButton = True
            tblDrawingOrder = Database.GetDataTable("SELECT * FROM " & m_table_name & ";", m_table_name)
            Dim intValue As Integer = 0
            For i As Integer = 0 To tblDrawingOrder.Rows.Count - 1
                r = tblDrawingOrder.Rows.Item(i)
                If r.Item("ButtonText").ToString = Me.ButtonName Then
                    MessageBox.Show("The button name entered is already in use, please change the name and try again.", "Button Name In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                'If CInt(r.Item("DataCode")) = Me.DataCode Then
                '    MessageBox.Show("The data code entered is already in use, please change the code and try again.", "Data Code In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Exit Sub
                'End If
                If r.Item("DataCodeName").ToString = Me.FieldName Then
                    MessageBox.Show("The field name entered is already in use, please change the name and try again.", "Field Name In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If CInt(r.Item("DrawingOrder")) > intValue Then
                    intValue = CInt(r.Item("DrawingOrder"))
                End If
            Next
            tblDataCodes = Database.GetDataTable("SELECT * FROM " & DB_DATA_CODES_TABLE & ";", DB_DATA_CODES_TABLE)
            For i As Integer = 0 To tblDataCodes.Rows.Count - 1
                r = tblDataCodes.Rows.Item(i)
                If CInt(r.Item("Code")) = Me.DataCode Then
                    MessageBox.Show("The data code entered is already used for '" & r.Item("Description") & "' , please change the code and try again.", "Data Code In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Next
            Me.DrawingOrder = intValue + 1
            Dim strTableName As String
            If Me.rdInputValue.Checked = True Then
                strTableName = "UserEntered"
            Else
                strTableName = Me.TableName
            End If
            Database.ExecuteNonQuery("INSERT INTO " & m_table_name & "(DrawingOrder, ButtonText, TableName, DataCode, DataCodeName, ButtonColor) " & _
                "VALUES (" & Me.DrawingOrder & ", " & SingleQuote(Me.ButtonName) & ", " & SingleQuote(strTableName) & ", " & Me.DataCode & ", " & SingleQuote(Me.FieldName) & ", 'DarkBlue')")
            Database.ExecuteNonQuery("ALTER TABLE data ADD COLUMN " & Me.FieldName & " TEXT(50)")
        Else
            If Me.DataCode <> Me.OldDataCode Then
                tblDataCodes = Database.GetDataTable("SELECT * FROM " & DB_DATA_CODES_TABLE & ";", DB_DATA_CODES_TABLE)
                For i As Integer = 0 To tblDataCodes.Rows.Count - 1
                    r = tblDataCodes.Rows.Item(i)
                    If CInt(r.Item("Code")) = Me.DataCode Then
                        MessageBox.Show("The data code entered is already used for '" & r.Item("Description") & "' , please change the code and try again.", "Data Code In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Next
            End If
            Dim strTableName As String
            If Me.rdInputValue.Checked = True Then
                strTableName = "UserEntered"
            Else
                strTableName = Me.TableName
            End If
            Database.ExecuteNonQuery("UPDATE " & m_table_name & " SET ButtonText = " & SingleQuote(Me.ButtonName) & ", TableName = " & SingleQuote(strTableName) & ", " & _
                                     "DataCode = " & CInt(Me.txtDataCode.Text) & ", DataCodeName = " & SingleQuote(Me.FieldName) & " WHERE ButtonText = " & SingleQuote(Me.OldButtonName))
            If Me.FieldName <> Me.OldFieldName Then
                'TODO: Fix whatever this code is for..
                'Dim cnConnection As New ADODB.Connection
                'cnConnection.Open(DB_CONN_STRING & strDatabaseFilePath & "; Jet OLEDB:Engine Type=5;")
                'Dim catButtons As New ADOX.Catalog
                'catButtons.ActiveConnection = cnConnection
                'catButtons.Tables(DB_DATA_TABLE).Columns(Me.OldFieldName).Name = Me.FieldName
                'catButtons.ActiveConnection.close()
                'catButtons.ActiveConnection = Nothing
            End If
            strEditTextBoxNewName = "txt" & Replace(Me.txtButtonName.Text, "%", "Percent")
            Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"
            Dim txtName As String = strEditTextBoxNewName
            Dim Letter As String
            For x As Integer = 0 To strEditTextBoxNewName.Length - 1
                Letter = strEditTextBoxNewName.Substring(x, 1).ToUpper
                If strCharactersAllowed.Contains(Letter) = False Then
                    txtName = txtName.Replace(Letter, String.Empty)
                End If
            Next
            strEditTextBoxNewName = txtName
        End If
        If Me.ButtonName <> Me.OldButtonName Or Me.DataCode <> Me.OldDataCode Then
            Database.ExecuteNonQuery("UPDATE " & DB_DATA_CODES_TABLE & " SET Code = " & Me.DataCode & ", Description = " & SingleQuote(Me.ButtonName) & _
                                     " WHERE Code = " & Me.OldDataCode & " AND Description = " & SingleQuote(Me.OldButtonName))
        End If
        RaiseEvent RefreshDatabaseEvent()
        blNewButton = False
        Me.Hide()
    End Sub

    Private Sub cmdCreateNewTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateNewTable.Click
        RaiseEvent AddNewTableEvent()
        ' CJG commented out while getting rid of myformlibrary
        'myFormLibrary.frmAddNewTable = New frmAddNewTable
        'myFormLibrary.frmAddNewTable.ShowDialog()
    End Sub

    Private Sub rdUseTable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdUseTable.CheckedChanged
        Me.cboTables.Enabled = True
        Me.cmdCreateNewTable.Enabled = True
    End Sub

    Private Sub rdInputValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdInputValue.CheckedChanged
        Me.cboTables.Enabled = False
        Me.cmdCreateNewTable.Enabled = False
    End Sub
End Class