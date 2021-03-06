﻿Public Class frmAddButton

#Region "Member variables"
    Private Const CREATE_NEW_TEXT = "Create New..."
    ''' <summary>
    ''' The name of the table which this form represents, either
    ''' videominer_habitat_buttons or videominer_transect_buttons
    ''' </summary>
    Private m_table_name As String
    ''' <summary>
    ''' The data table containing the contents of the table given by m_table_name
    ''' </summary>
    Private m_data_table As DataTable
    ''' <summary>
    ''' The name of the table that was selected in the combobox by the user
    ''' </summary>
    Private m_lookup_table_name As String

    Private m_button_name As String
    Private m_data_code As Integer
    Private m_field_name As String
    Private m_drawing_order As String

    'Private m_OldButtonName As String
    'Private m_OldTableName As String
    'Private m_OldDataCode As Integer
    'Private m_OldFieldName As String

    Private WithEvents m_frmAddNewTable As frmAddNewTable
    Private WithEvents m_frmViewDataTable As frmViewDataTable
#End Region

#Region "Properties"

    'Public Property ButtonName() As String
    '    Get
    '        Return m_button_name
    '    End Get
    '    Set(ByVal value As String)
    '        m_button_name = value
    '    End Set
    'End Property

    'Public Property DataCode() As Integer
    '    Get
    '        Return m_data_code
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_data_code = value
    '    End Set
    'End Property

    'Public Property FieldName() As String
    '    Get
    '        Return m_field_name
    '    End Get
    '    Set(ByVal value As String)
    '        m_field_name = value
    '    End Set
    'End Property

    'Public Property DrawingOrder() As Integer
    '    Get
    '        Return m_drawing_order
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_drawing_order = value
    '    End Set
    'End Property

    'Public Property OldButtonName() As String
    '    Get
    '        Return m_OldButtonName
    '    End Get
    '    Set(ByVal value As String)
    '        m_OldButtonName = value
    '    End Set
    'End Property

    'Public Property OldTableName() As String
    '    Get
    '        Return m_OldTableName
    '    End Get
    '    Set(ByVal value As String)
    '        m_OldTableName = value
    '    End Set
    'End Property

    'Public Property OldDataCode() As Integer
    '    Get
    '        Return m_OldDataCode
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_OldDataCode = value
    '    End Set
    'End Property

    'Public Property OldFieldName() As String
    '    Get
    '        Return m_OldFieldName
    '    End Get
    '    Set(ByVal value As String)
    '        m_OldFieldName = value
    '    End Set
    'End Property

#End Region

#Region "Events"
    Public Event AddNewTableEvent()
    Public Event DatabaseModifedEvent()
#End Region

    Public Sub New(strConfigureTable As String)
        InitializeComponent()
        m_table_name = strConfigureTable
        m_lookup_table_name = Nothing
        m_frmViewDataTable = New frmViewDataTable(DB_DATA_CODES_TABLE)
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
        If txtFieldName.Text.Length = 1 Then
            txtFieldName.Text = txtName.ToUpper
        Else
            txtFieldName.Text = txtName
        End If
        If did_change = False Then
            txtFieldName.Select(sel_s, 0)
        Else
            txtFieldName.Select(sel_s - 1, 0)
        End If
    End Sub

    Private Sub frmAddButton_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_frmViewDataTable.Close()
        m_frmViewDataTable = Nothing
    End Sub

    ''' <summary>
    ''' Allows the drawing of each item in the combobox to be controlled.
    ''' This is to make the 'Create New' item italicized and green.
    ''' </summary>
    Private Sub cboTables_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cboTables.DrawItem
        e.DrawBackground()
        Dim str As String = CType(sender, ComboBox).Items(e.Index).ToString()
        Dim f As Font
        Dim b As Brush
        If str = CREATE_NEW_TEXT Then
            f = New Font("Arial", 12, FontStyle.Italic)
            b = Brushes.Green
        Else
            f = New Font("Arial", 12, FontStyle.Regular)
            b = Brushes.Black
        End If
        e.Graphics.DrawString(str, f, b, e.Bounds.X, e.Bounds.Y)
    End Sub

    Private Sub cboTables_SelectionChanged(sender As Object, e As EventArgs) Handles cboTables.SelectedIndexChanged
        Dim cbo As ComboBox = CType(sender, ComboBox)
        If cbo.SelectedItem.ToString() = CREATE_NEW_TEXT Then
            cmdCreateNewTable()
        Else
            m_lookup_table_name = cboTables.SelectedItem.ToString()
        End If
    End Sub

    Private Sub cboTables_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTables.SelectionChangeCommitted
        Dim cbo As ComboBox = CType(sender, ComboBox)
        cbo.ResetText() ' Doesn't seem to work. Neither does cbo.selectedindex = -1
    End Sub

    Private Sub frmAddButton_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tblSchema As DataTable = Database.GetDataTableSchema()
        Dim strTableName As String
        ' Need this to make sure the DrawItem event is fired
        cboTables.DrawMode = DrawMode.OwnerDrawFixed
        ' Add a choice to 'Create new table...' to the combobox
        cboTables.Items.Add(CREATE_NEW_TEXT)
        ' Add the lookup table names to the combobox
        For i As Integer = 0 To tblSchema.Rows.Count - 1
            strTableName = tblSchema.Rows(i).Item("TABLE_NAME").ToString
            If Strings.Left(strTableName, 3) = "lu_" Then
                If strTableName <> DB_BUTTON_COLORS_TABLE And
                    strTableName <> DB_DATA_CODES_TABLE And
                    strTableName <> DB_SPECIES_CODE_TABLE Then
                    cboTables.Items.Add(strTableName)
                End If
            End If
        Next
        ' Make the lookup table the default choice
        rdUseTable.Checked = True
        '' If blButtonEdit Then
        'strQuery = "select ButtonText, TableName, DataCode, DataCodeName FROM " &
        '    m_table_name & " WHERE ButtonText = " & SingleQuote(Me.txtButtonName.Text)
        'Dim d As DataTable = Database.GetDataTable(strQuery, m_table_name)
        'Dim r As DataRow = d.Rows.Item(0)
        'If Not IsNothing(r) Then
        '    If r.Item(TABLE_NAME) = USER_ENTERED Then
        '        rdInputValue.Checked = True
        '        cboTables.Enabled = False
        '        'Me.cmdCreateNewTable.Enabled = False
        '    Else
        '        rdUseTable.Checked = True
        '        cboTables.SelectedItem = r.Item(TABLE_NAME)
        '    End If
        '    txtDataCode.Text = r.Item(DATA_CODE)
        '    txtFieldName.Text = r.Item(DATA_CODE_NAME)
        '    OldButtonName = Me.txtButtonName.Text
        '    OldTableName = Me.cboTables.SelectedItem
        '    OldDataCode = CInt(Me.txtDataCode.Text)
        '    OldFieldName = Me.txtFieldName.Text
        'End If
        'strEditTextBoxOldName = "txt" & Replace(txtButtonName.Text, "%", "Percent")
        'Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"
        'Dim txtName As String = strEditTextBoxOldName
        'Dim letter As String
        'For x As Integer = 0 To strEditTextBoxOldName.Length - 1
        '    letter = strEditTextBoxOldName.Substring(x, 1).ToUpper
        '    If strCharactersAllowed.Contains(letter) = False Then
        '        txtName = txtName.Replace(letter, String.Empty)
        '    End If
        'Next
        'strEditTextBoxOldName = txtName
        ''End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Hide()
    End Sub

    ''' <summary>
    ''' Make several queries to the database to add the button according to the specs on the form.
    ''' </summary>
    Private Sub addButton()
        If IsNothing(m_lookup_table_name) And Not rdInputValue.Checked Then Exit Sub
        m_button_name = txtButtonName.Text
        m_data_code = CInt(txtDataCode.Text)
        m_field_name = txtFieldName.Text

        Dim drButtons As DataRow
        Dim drDataCodes As DataRow
        Dim dtButtons As DataTable
        Dim dtDataCodes As DataTable
        Dim strKeyName As String = Database.GetPrimaryKeyFieldName(m_table_name)
        Dim strKeyNameDataCodeTable As String = Database.GetPrimaryKeyFieldName(DB_DATA_CODES_TABLE)
        Dim intNextKey As Integer = Database.GetNextPrimaryKeyValue(m_table_name)

        dtButtons = Database.GetDataTable("select * from " & m_table_name, m_table_name)
        For i As Integer = 0 To dtButtons.Rows.Count - 1
            drButtons = dtButtons.Rows.Item(i)
            If drButtons.Item(BUTTON_TEXT).ToString = m_button_name Then
                MessageBox.Show("The button name entered is already in use, please change the name and try again.",
                                "Button Name In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If CInt(drButtons.Item(DATA_CODE)) = m_data_code Then
                MessageBox.Show("The data code entered is already in use, please change the code and try again.",
                                "Data Code In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If drButtons.Item(DATA_CODE_NAME).ToString = m_field_name Then
                MessageBox.Show("The field name entered is already in use, please change the name and try again.",
                                "Field Name In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Next
        dtDataCodes = Database.GetDataTable("select * from " & DB_DATA_CODES_TABLE, DB_DATA_CODES_TABLE)
        For i As Integer = 0 To dtDataCodes.Rows.Count - 1
            drDataCodes = dtDataCodes.Rows.Item(i)
            If CInt(drDataCodes.Item(strKeyNameDataCodeTable)) = m_data_code Then
                MessageBox.Show("The data code entered is already used for '" &
                                drDataCodes.Item("Description").ToString() & "' , please change the code and try again.",
                                "Data Code In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Next
        Dim strTableName As String
        If rdInputValue.Checked = True Then
            strTableName = USER_ENTERED
        Else
            strTableName = m_lookup_table_name
        End If
        ' Modify the last DataRow for buttons table so that is has the values we want for the new data code record
        drButtons.Item(strKeyName) = intNextKey
        drButtons.Item(BUTTON_TEXT) = m_button_name
        drButtons.Item(TABLE_NAME) = strTableName
        drButtons.Item(DATA_CODE) = m_data_code
        drButtons.Item(DATA_CODE_NAME) = m_button_name & "ID"
        Database.InsertRow(drButtons, m_table_name)
        ' Modify the last DataRow for data codes table so that is has the values we want for the new data code record
        drDataCodes.Item("Code") = m_data_code
        drDataCodes.Item("Description") = m_button_name
        drDataCodes.Item("LookupTable") = m_table_name
        Database.InsertRow(drDataCodes, DB_DATA_CODES_TABLE)

        Database.AddColumn(DB_DATA_TABLE, m_field_name)
        ' Need to fire event to tell configurebuttons form that the database has changed
        RaiseEvent DatabaseModifedEvent()

        'Else
        '    If Me.DataCode <> Me.OldDataCode Then
        '        tblDataCodes = Database.GetDataTable("SELECT * FROM " & DB_DATA_CODES_TABLE & ";", DB_DATA_CODES_TABLE)
        '        For i As Integer = 0 To tblDataCodes.Rows.Count - 1
        '            r = tblDataCodes.Rows.Item(i)
        '            If CInt(r.Item("Code")) = Me.DataCode Then
        '                MessageBox.Show("The data code entered is already used for '" & r.Item("Description") & "' , please change the code and try again.", "Data Code In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                Exit Sub
        '            End If
        '        Next
        '    End If
        '    Dim strTableName As String
        '    If Me.rdInputValue.Checked = True Then
        '        strTableName = USER_ENTERED
        '    Else
        '        strTableName = Me.Table_Name
        '    End If
        '    Database.ExecuteNonQuery("UPDATE " & m_table_name & " SET ButtonText = " & SingleQuote(Me.ButtonName) & ", TableName = " & SingleQuote(strTableName) & ", " &
        '                             "DataCode = " & CInt(Me.txtDataCode.Text) & ", DataCodeName = " & SingleQuote(Me.FieldName) & " WHERE ButtonText = " & SingleQuote(Me.OldButtonName))
        '    If Me.FieldName <> Me.OldFieldName Then
        '        'TODO: Fix whatever this code is for..
        '        'Dim cnConnection As New ADODB.Connection
        '        'cnConnection.Open(DB_CONN_STRING & strDatabaseFilePath & "; Jet OLEDB:Engine Type=5;")
        '        'Dim catButtons As New ADOX.Catalog
        '        'catButtons.ActiveConnection = cnConnection
        '        'catButtons.Tables(DB_DATA_TABLE).Columns(Me.OldFieldName).Name = Me.FieldName
        '        'catButtons.ActiveConnection.close()
        '        'catButtons.ActiveConnection = Nothing
        '    End If
        '    strEditTextBoxNewName = "txt" & Replace(Me.txtButtonName.Text, "%", "Percent")
        '    Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"
        '    Dim txtName As String = strEditTextBoxNewName
        '    Dim Letter As String
        '    For x As Integer = 0 To strEditTextBoxNewName.Length - 1
        '        Letter = strEditTextBoxNewName.Substring(x, 1).ToUpper
        '        If strCharactersAllowed.Contains(Letter) = False Then
        '            txtName = txtName.Replace(Letter, String.Empty)
        '        End If
        '    Next
        '    strEditTextBoxNewName = txtName
        'End If
        'If Me.ButtonName <> Me.OldButtonName Or Me.DataCode <> Me.OldDataCode Then
        '    Database.ExecuteNonQuery("UPDATE " & DB_DATA_CODES_TABLE & " SET Code = " & Me.DataCode & ", Description = " & SingleQuote(Me.ButtonName) &
        '                             " WHERE Code = " & Me.OldDataCode & " AND Description = " & SingleQuote(Me.OldButtonName))
        'End If
        Hide()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        addButton()
    End Sub

    ''' <summary>
    ''' Handles the user's click of the Create New... selection in the combobox
    ''' </summary>
    Private Sub cmdCreateNewTable()
        'RaiseEvent AddNewTableEvent()
        'm_frmAddNewTable = New frmAddNewTable()
        MsgBox("New form appears")
    End Sub

    Private Sub rdUseTable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdUseTable.CheckedChanged
        Me.cboTables.Enabled = True
    End Sub

    Private Sub rdInputValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdInputValue.CheckedChanged
        Me.cboTables.Enabled = False
    End Sub

    Private Sub btnViewDataCodes_Click(sender As Object, e As EventArgs) Handles btnViewDataCodes.Click
        m_frmViewDataTable.Show()
    End Sub

End Class