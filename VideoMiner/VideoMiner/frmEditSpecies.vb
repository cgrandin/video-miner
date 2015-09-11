Imports System.Data.OleDb
''' <summary>
''' This form class allows the user to add a new species to the database table 'videominer_species_buttons' or to edit properties of an existing species
''' </summary>
Public Class frmEditSpecies
    Private WithEvents frmCreateKeyboardShortcut As frmCreateKeyboardShortcut
    Private m_conn As OleDbConnection
    Private m_species_table As DataTable
    Private m_originalSpeciesName As String
    Private m_opriginalSpeciesCode As String
    Private m_speciesName As String
    Private m_selIdx As Integer
    Private m_edit_Insert As String = "Insert"

#Region "Properties"
    Public Property OriginalSpeciesName() As String
        Get
            Return m_originalSpeciesName
        End Get
        Set(ByVal value As String)
            m_originalSpeciesName = value
        End Set
    End Property

    Public Property Edit_Insert() As String
        Get
            Return m_edit_Insert
        End Get
        Set(ByVal value As String)
            m_edit_Insert = value
        End Set
    End Property

    Public Property OriginalSpeciesCode() As String
        Get
            Return m_opriginalSpeciesCode
        End Get
        Set(ByVal value As String)
            m_opriginalSpeciesCode = value
        End Set
    End Property

    Public Property selIdx() As String
        Get
            Return m_selIdx
        End Get
        Set(ByVal value As String)
            m_selIdx = value
        End Set
    End Property
#End Region

    ''' <summary>
    ''' In this constructor, the various comboboxes will be populated so that it only happens once. There are over 7000 records in the species table and this will speed things up in the program.
    ''' </summary>
    Public Sub New()
        InitializeComponent()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Hide()
        'Me.Dispose()
    End Sub

    Private Sub added_new_shortcut() Handles frmCreateKeyboardShortcut.AddedNewShortcut
        txtKeyboardShortcut.Text = frmCreateKeyboardShortcut.txtCurrentShortcut.Text
    End Sub

    Private Sub frmEditSpecies_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strScienceName As String = "SELECT DISTINCT ScientificName FROM " & DB_SPECIES_CODE_TABLE & " ORDER BY ScientificName;"
        m_species_table = Database.GetDataTable(strScienceName, DB_SPECIES_CODE_TABLE)
        PopulateSpeciesLists(Me.cboScientificName, m_species_table)

        Dim strCommonName As String = "SELECT DISTINCT CommonName FROM " & DB_SPECIES_CODE_TABLE & " ORDER BY CommonName;"
        m_species_table = Database.GetDataTable(strCommonName, DB_SPECIES_CODE_TABLE)
        PopulateSpeciesLists(Me.cboCommonName, m_species_table)
        'Try
        '    Dim strQuery As String
        '    Dim strColor As String
        '    If Edit_Insert = "Edit" Then

        '        strQuery = "SELECT DrawingOrder, ButtonText, ButtonCode, ButtonColor, KeyboardShortcut " & _
        '                    "FROM " & DB_SPECIES_BUTTONS_TABLE & _
        '                    " WHERE DrawingOrder = " & selIdx + 1

        '        Dim cmd As OleDbCommand = New OleDbCommand(strQuery, m_conn)
        '        Dim aDataReader As OleDb.OleDbDataReader
        '        aDataReader = cmd.ExecuteReader

        '        While aDataReader.Read()
        '            If Not IsDBNull(aDataReader("ButtonText")) Then
        '                Me.txtSpeciesBtnTxt.Text = aDataReader("ButtonText")
        '            End If
        '            If Not IsDBNull(aDataReader("ButtonCode")) Then
        '                Me.txtSpeciesCode.Text = aDataReader("ButtonCode")
        '            End If
        '            If Not IsDBNull(aDataReader("KeyboardShortcut")) Then
        '                Me.txtKeyboardShortcut.Text = aDataReader("KeyboardShortcut")
        '            End If
        '            If Not IsDBNull(aDataReader("ButtonColor")) Then
        '                strColor = aDataReader("ButtonColor")
        '            End If
        '        End While

        '        aDataReader.Close()
        '        aDataReader = Nothing

        '        cmd.Dispose()
        '        cmd = Nothing
        '    ElseIf Edit_Insert = "Insert" Then
        '        Me.txtSpeciesBtnTxt.Text = ""
        '        Me.txtSpeciesCode.Text = ""
        '    End If



        '    strQuery = "SELECT TaxonomyClassLevelCode FROM " & DB_SPECIES_CODE_TABLE & " WHERE SpeciesCode = " & SingleQuote(Me.txtSpeciesCode.Text) & ";"

        '    Dim sub_data_set As DataSet = New DataSet()
        '    Dim sub_db_command As OleDbCommand = New OleDbCommand(strQuery, m_conn)
        '    Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        '    sub_data_adapter.Fill(sub_data_set, DB_SPECIES_CODE_TABLE)

        '    Dim dt As DataTable
        '    Dim r As DataRow

        '    dt = sub_data_set.Tables.Item(0)
        '    For Each r In dt.Rows
        '        If Not IsDBNull(r.Item("TaxonomyClassLevelCode")) Then
        '            Me.txtTaxonomicLevel.Text = r.Item("TaxonomyClassLevelCode")
        '        End If
        '    Next


        '    strQuery = "SELECT Color FROM " & DB_BUTTON_COLORS_TABLE & ";"

        '    sub_data_set = New DataSet()
        '    sub_db_command = New OleDbCommand(strQuery, m_conn)
        '    sub_data_adapter = New OleDbDataAdapter(sub_db_command)
        '    sub_data_adapter.Fill(sub_data_set, DB_BUTTON_COLORS_TABLE)

        '    dt = sub_data_set.Tables.Item(0)

        '    For Each r In dt.Rows
        '        Me.cboButtonColors.Items.Add(r.Item("Color"))
        '    Next


        '    Me.cboButtonColors.SelectedItem = strColor
        '    Me.txtSpeciesCode.ForeColor = Color.Black
        '    Me.txtSpeciesCode.BackColor = Color.White
        '    Me.txtTaxonomicLevel.ForeColor = Color.Black
        '    Me.txtTaxonomicLevel.BackColor = Color.White
        '    Me.txtKeyboardShortcut.ForeColor = Color.Black
        '    Me.txtKeyboardShortcut.BackColor = Color.White
        'Catch ex As Exception
        '    MsgBox(ex.StackTrace)
        'End Try

    End Sub

    ''' <summary>
    ''' Fill the combobox with a given column's contents
    ''' </summary>
    ''' <param name="cboBox">A reference to the combobox to populate</param>
    ''' <param name="dataTable">A single column data table containing values that you want to fill the combobox with</param>
    Private Sub PopulateSpeciesLists(ByRef cboBox As ComboBox, ByRef dataTable As DataTable)
        With cboBox
            .DataSource = dataTable
            .DisplayMember = dataTable.Columns(0).ColumnName
            .ValueMember = dataTable.Columns(0).ColumnName
            .SelectedIndex = 0
        End With
        'cboBox.DataSource = dataTable
        'For Each r As DataRow In dataTable.Rows
        'cboBox.Items.Add(r.Item(0).ToString())

        'If r.Item(0).ToString().Trim().Length > 0 Then
        ' cboBox.Items.Add(r.Item(0).ToString())
        ' End If
        'Next
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        txtSpeciesBtnTxt.Enabled = True
        If Me.txtSpeciesCode.Text.Length = 0 Then
            MessageBox.Show("Please provide a species code.", "Species Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.txtSpeciesCode.Focus()
            Exit Sub
        End If

        'If Me.cboCommonName.Text.Length = 0 Then
        '    MessageBox.Show("Please provide a species name.", "Species Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End If

        Dim oComm As OleDbCommand
        Dim query As String

        Dim intNextId As Integer
        intNextId = GetNextSequenceId()

        ''Check to see if a button allready exists based on both button text and species code
        'query = "SELECT * FROM " & DB_SPECIES_BUTTONS_TABLE & " " & _
        '        "WHERE ButtonText = " & DoubleQuote(Me.txtSpeciesBtnTxt.Text) & " AND " & _
        '        "ButtonCode = " & DoubleQuote(Me.txtSpeciesCode.Text)

        'Check to see if a button allready exists based on species code

        'If Me.txtSpeciesCode.Text <> Me.OriginalSpeciesCode Then

        '    query = "SELECT * FROM " & DB_SPECIES_BUTTONS_TABLE & " " & _
        '                        "WHERE ButtonCode = " & DoubleQuote(Me.txtSpeciesCode.Text)

        '    Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
        '    Dim aDataReader As OleDb.OleDbDataReader
        '    aDataReader = cmd.ExecuteReader
        '    If aDataReader.HasRows Then
        '        MsgBox("This Species Code already exists", MsgBoxStyle.OkOnly, "Duplicate Entry")
        '        Exit Sub
        '    End If
        '    While aDataReader.Read()
        '        Me.txtSpeciesBtnTxt.Text = aDataReader("ButtonText")
        '        Me.txtSpeciesCode.Text = aDataReader("ButtonCode")
        '    End While

        '    aDataReader.Close()
        '    aDataReader = Nothing
        'End If

        If Edit_Insert = "Insert" Then


            'Insert as a new species
            query = "INSERT INTO " & DB_SPECIES_BUTTONS_TABLE & "(DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor, KeyboardShortcut) " & _
                    "VALUES (" & intNextId & ", " & _
                            DoubleQuote(Me.txtSpeciesBtnTxt.Text) & ", " & _
                            DoubleQuote(Me.txtSpeciesCode.Text) & ", " & _
                            DoubleQuote("SpeciesID") & ", " & _
                            "4, " & _
                            SingleQuote(Me.cboButtonColors.SelectedItem) & ", " & _
                            DoubleQuote(Me.txtKeyboardShortcut.Text) & _
                            ")"

            oComm = New OleDbCommand(query, m_conn)
            oComm.ExecuteNonQuery()

        ElseIf Edit_Insert = "Edit" Then
            'Update the selected species
            query = "UPDATE " & DB_SPECIES_BUTTONS_TABLE & " " & _
                    "SET ButtonText = " & DoubleQuote(Me.txtSpeciesBtnTxt.Text) & ", " & _
                    "    ButtonCode = " & DoubleQuote(Me.txtSpeciesCode.Text) & ", " & _
                    "    ButtonColor = " & DoubleQuote(Me.cboButtonColors.SelectedItem) & ", " & _
                    "    KeyboardShortcut = " & DoubleQuote(Me.txtKeyboardShortcut.Text) & " " & _
                    "WHERE ButtonText = " & DoubleQuote(Me.OriginalSpeciesName) & " AND " & _
                    "      ButtonCode = " & DoubleQuote(Me.OriginalSpeciesCode)

            oComm = New OleDbCommand(query, m_conn)
            oComm.ExecuteNonQuery()
        End If

        Me.Close()

    End Sub

    Private Function GetNextSequenceId() As Integer

        Dim intId As Integer = 0

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand("SELECT DrawingOrder FROM " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", m_conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, DB_SPECIES_BUTTONS_TABLE)

        Dim d As DataTable
        d = sub_data_set.Tables(0)

        Dim r As DataRow
        For Each r In d.Rows
            If CType(r.Item("DrawingOrder"), Integer) > intId Then
                intId = CType(r.Item("DrawingOrder"), Integer)
            End If
        Next

        Return intId + 1

    End Function

    Private Sub GetSpeciesCode(ByVal strQuery As String)

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand(strQuery, m_conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, DB_SPECIES_CODE_TABLE)
        Dim r As DataRow
        Dim d As DataTable
        d = sub_data_set.Tables(0)

        For Each r In d.Rows
            'Debug.WriteLine(r.Item("SpeciesCode").ToString())
            Me.txtSpeciesCode.Text = r.Item("SpeciesCode").ToString()
            If Not IsDBNull(r.Item("TaxonomyClassLevelCode")) Then
                Me.txtTaxonomicLevel.Text = r.Item("TaxonomyClassLevelCode").ToString()
            End If
        Next

    End Sub

    Private Sub cboCommonName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cboCommonName.SelectedIndexChanged

        m_speciesName = Me.cboCommonName.Text

        If m_speciesName.Length > 0 Then

            Me.txtSpeciesBtnTxt.Text = m_speciesName

            Dim strQuery As String
            strQuery = "SELECT DISTINCT SpeciesCode, TaxonomyClassLevelCode FROM " & DB_SPECIES_CODE_TABLE & _
                       "WHERE CommonName = " & DoubleQuote(m_speciesName) & _
                       "ORDER BY SpeciesCode;"

            'Me.cboLatinName.SelectedIndex = -1
            Me.cboScientificName.SelectedIndex = -1
            Me.txtSpeciesCode.Text = ""
            Me.txtTaxonomicLevel.Text = ""
            GetSpeciesCode(strQuery)
        End If

    End Sub

    Private Sub cboScientificName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cboScientificName.SelectedIndexChanged

        m_speciesName = Me.cboScientificName.Text

        If m_speciesName.Length > 0 Then

            Me.txtSpeciesBtnTxt.Text = m_speciesName

            Dim strQuery As String
            strQuery = "SELECT DISTINCT SpeciesCode, TaxonomyClassLevelCode FROM " & DB_SPECIES_CODE_TABLE & _
                       "WHERE ScientificName = " & DoubleQuote(m_speciesName) & _
                       "ORDER BY SpeciesCode;"

            Me.cboCommonName.SelectedIndex = -1
            Me.txtSpeciesCode.Text = ""

            GetSpeciesCode(strQuery)
        End If
    End Sub

    'Private Sub cboLatinName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLatinName.SelectedIndexChanged

    '    m_SpeciesName = Me.cboLatinName.Text

    '    If m_SpeciesName.Length > 0 Then

    '        Me.txtSpeciesBtnTxt.Text = m_SpeciesName

    '        Dim strQuery As String
    '        strQuery = "SELECT DISTINCT SpeciesCode, TaxonomyClassLevelCode FROM " DB_SPECIES_CODE_TABLE & _
    '                   "WHERE LatinName = " & DoubleQuote(m_SpeciesName) & _
    '                   "ORDER BY SpeciesCode;"

    '        'Me.cboScientificName.SelectedIndex = -1
    '        Me.cboCommonName.SelectedIndex = -1
    '        Me.txtSpeciesCode.Text = ""
    '        Me.txtTaxonomicLevel.Text = ""
    '        GetSpeciesCode(strQuery)
    '    End If
    'End Sub

    Private Sub radCommonName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCommonName.CheckedChanged
        EnableDisable()
    End Sub

    Private Sub EnableDisable()

        If radCommonName.Checked Then
            Me.cboCommonName.Enabled = True
            'Me.cboLatinName.Enabled = False
            Me.cboScientificName.Enabled = False
            'ElseIf radLatinName.Checked Then
            '    Me.cboCommonName.Enabled = False
            '    Me.cboLatinName.Enabled = True
            '    Me.cboScientificName.Enabled = False
        ElseIf radScientificName.Checked Then
            Me.cboCommonName.Enabled = False
            'Me.cboLatinName.Enabled = False
            Me.cboScientificName.Enabled = True
        End If

        Me.txtSpeciesCode.Text = ""
        Me.txtTaxonomicLevel.Text = ""
    End Sub

    Private Sub radScientificName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radScientificName.CheckedChanged
        EnableDisable()
    End Sub

    'Private Sub radLatinName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLatinName.CheckedChanged
    '    EnableDisable()
    'End Sub

    Private Sub cboButtonColors_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboButtonColors.DrawItem

        Dim fnt As Font
        Dim brsh As Brush

        brsh = New SolidBrush(Color.FromName(Me.cboButtonColors.Items(e.Index)))
        fnt = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)

        Dim rectangle As Rectangle = New Rectangle(2, e.Bounds.Top + 2, _
            e.Bounds.Height, e.Bounds.Height - 4)
        e.Graphics.FillRectangle(brsh, rectangle)

        e.DrawBackground()

        e.Graphics.DrawString(Me.cboButtonColors.Items(e.Index), fnt, brsh, e.Bounds.X, e.Bounds.Y)

        e.DrawFocusRectangle()

    End Sub

    Private Sub cboButtonColors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboButtonColors.SelectedIndexChanged
        Me.cboButtonColors.ForeColor = Color.FromName(Me.cboButtonColors.SelectedItem)
    End Sub

    Private Sub cmdChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChange.Click
        frmCreateKeyboardShortcut = New frmCreateKeyboardShortcut

        frmCreateKeyboardShortcut.ButtonText = Me.txtSpeciesBtnTxt.Text
        frmCreateKeyboardShortcut.KeyboardShortcut = Me.txtKeyboardShortcut.Text

        frmCreateKeyboardShortcut.ShowDialog()
    End Sub

    Private Sub me_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

End Class