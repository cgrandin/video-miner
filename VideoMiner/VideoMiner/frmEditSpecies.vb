Imports System.Data.OleDb
''' <summary>
''' This form class allows the user to add a new species to the database table 'videominer_species_buttons' or to edit properties of an existing species
''' </summary>
Public Class frmEditSpecies
    Private WithEvents frmCreateKeyboardShortcut As frmCreateKeyboardShortcut
    Private m_species_table As DataTable
    Private m_button_colors_table As DataTable
    ''' <summary>
    ''' The currently selected species name
    ''' </summary>
    Private m_speciesName As String
    ''' <summary>
    ''' The currently selected species scientific name
    ''' </summary>
    Private m_speciesScienceName As String
    ''' <summary>
    ''' The currently selected species code
    ''' </summary>
    Private m_speciesCode As String
    ''' <summary>
    ''' The currently selected species' taxonomic level code
    ''' </summary>
    Private m_speciesTaxCode As String
    ''' <summary>
    ''' The currently selected button color
    ''' </summary>
    ''' <remarks></remarks>
    Private m_buttonColor As String
    ''' <summary>
    ''' The button text to be used for the species code
    ''' </summary>
    ''' <remarks></remarks>
    Private m_button_text As String
    ''' <summary>
    ''' The text representing a .NET keyboard shortcut
    ''' </summary>
    ''' <remarks></remarks>
    Private m_keyboard_shortcut As String

    Public Event SpeciesButtonsModified()

#Region "Properties"
    ''' <summary>
    ''' Returns the currently selected species' common name. Will return null string if there is no selection.
    ''' </summary>
    Public ReadOnly Property SpeciesName() As String
        Get
            Return m_speciesName
        End Get
    End Property

    ''' <summary>
    ''' Returns the currently selected species' scientific name. Will return null string if there is no selection.
    ''' </summary>
    Public ReadOnly Property SpeciesScienceName() As String
        Get
            Return m_speciesScienceName
        End Get
    End Property

    ''' <summary>
    ''' Returns the currently selected species' species code. Will return null string if there is no selection.
    ''' </summary>
    Public Property SpeciesCode() As String
        Get
            Return m_speciesCode
        End Get
        Set(value As String)
            m_speciesCode = value
        End Set
    End Property

    ''' <summary>
    ''' Returns the currently selected species' taxonomy family code. Will return null string if there is no selection.
    ''' </summary>
    Public ReadOnly Property SpeciesTaxCode() As String
        Get
            Return m_speciesTaxCode
        End Get
    End Property

    ''' <summary>
    ''' Returns the currently selected button color. Will return null string if there is no selection.
    ''' </summary>
    Public ReadOnly Property ButtonColor() As String
        Get
            Return m_buttonColor
        End Get
    End Property

    ''' <summary>
    ''' Returns the currently selected button color. Will return null string if there is no selection.
    ''' </summary>
    Public ReadOnly Property ButtonText() As String
        Get
            Return m_button_text
        End Get
    End Property

    ''' <summary>
    ''' Returns a text representation of the current keyboard shortcut for this species. Will return null string if there isn't one set up.
    ''' </summary>
    Public ReadOnly Property KeyboardShortcut() As String
        Get
            Return m_keyboard_shortcut
        End Get
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
    End Sub

    Private Sub added_new_shortcut() Handles frmCreateKeyboardShortcut.AddedNewShortcut
        txtKeyboardShortcut.Text = frmCreateKeyboardShortcut.txtCurrentShortcut.Text
    End Sub

    Private Sub frmEditSpecies_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Initialize currently selected species to null or empty string since user has not yet made a selection.
        m_speciesName = ""
        m_speciesScienceName = ""
        m_speciesCode = ""
        m_speciesTaxCode = ""
        m_buttonColor = "DarkSlateGray"
        m_keyboard_shortcut = ""

        ' The WHERE <> """" in the following three queries remove any null string species names from the lists
        Dim strQuery As String = "SELECT DISTINCT ScientificName FROM " & DB_SPECIES_CODE_TABLE & " WHERE ScientificName <> """" ORDER BY 1;"
        m_species_table = Database.GetDataTable(strQuery, DB_SPECIES_CODE_TABLE)
        PopulateComboBox(Me.cboScientificName, m_species_table)

        strQuery = "SELECT DISTINCT CommonName FROM " & DB_SPECIES_CODE_TABLE & " WHERE CommonName <> """" ORDER BY 1;"
        m_species_table = Database.GetDataTable(strQuery, DB_SPECIES_CODE_TABLE)
        PopulateComboBox(Me.cboCommonName, m_species_table)

        strQuery = "SELECT DISTINCT Color FROM " & DB_BUTTON_COLORS_TABLE & " WHERE Color <> """" ORDER BY 1;"
        m_button_colors_table = Database.GetDataTable(strQuery, DB_BUTTON_COLORS_TABLE)
        PopulateComboBox(Me.cboButtonColors, m_button_colors_table)
    End Sub

    ''' <summary>
    ''' Fill the combobox with a given column's contents
    ''' </summary>
    ''' <param name="cboBox">A reference to the combobox to populate</param>
    ''' <param name="dataTable">A single column data table containing values that you want to fill the combobox with</param>
    Private Sub PopulateComboBox(ByRef cboBox As ComboBox, ByRef dataTable As DataTable)
        With cboBox
            .DataSource = dataTable
            .DisplayMember = dataTable.Columns(0).ColumnName
            .ValueMember = dataTable.Columns(0).ColumnName
            .SelectedIndex = -1 ' If 0, the first item will be preselected, if -1, no items will be selected (default fresh loaded condition).
        End With
    End Sub

    ''' <summary>
    ''' Custom draw function for the button colors combobox so that the color names appear as the colors themselves.
    ''' </summary>
    Private Sub cboButtonColors_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboButtonColors.DrawItem
        Dim fnt As Font
        Dim str As String = cboButtonColors.GetItemText(sender.Items(e.Index))
        Dim brsh As Brush = New SolidBrush(Color.FromName(str))
        fnt = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)
        Dim rectangle As Rectangle = New Rectangle(2, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 4)
        e.Graphics.FillRectangle(brsh, rectangle)
        e.DrawBackground()
        e.Graphics.DrawString(str, fnt, brsh, e.Bounds.X, e.Bounds.Y)
        e.DrawFocusRectangle()
    End Sub

    ''' <summary>
    ''' When user presses OK, either add a new record to the database table videominer_species_buttons or change one already present.
    ''' </summary>
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.txtSpeciesCode.Text.Length = 0 Then
            MessageBox.Show("Please provide a species code.", "Species Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            'Me.txtSpeciesCode.Focus()
            Exit Sub
        End If

        'Check to see if a button already exists based on species code
        Dim strQuery As String = "SELECT * FROM " & DB_SPECIES_BUTTONS_TABLE & _
                                 " WHERE ButtonCode = " & DoubleQuote(m_speciesCode) & ";"

        Dim check_table As DataTable = Database.GetDataTable(strQuery, DB_SPECIES_BUTTONS_TABLE)
        If check_table.Rows.Count > 0 Then
            Dim intAnswer = MessageBox.Show("This Species Code already exists in the database. Do you want to overwrite the species button settings with the new values?", "Duplicate entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If intAnswer = vbYes Then
                ' Run the update query
                strQuery = "UPDATE " & DB_SPECIES_BUTTONS_TABLE & " SET ButtonText = " & DoubleQuote(ButtonText) & _
                           ", ButtonCode = " & DoubleQuote(SpeciesCode) & _
                           ", ButtonColor = " & DoubleQuote(ButtonColor) & _
                           ", KeyboardShortcut = " & DoubleQuote(KeyboardShortcut) & _
                           " WHERE ButtonText = " & DoubleQuote(SpeciesName) & _
                           " AND ButtonCode = " & DoubleQuote(SpeciesCode) & ";"
                Database.ExecuteNonQuery(strQuery)
            End If
            Exit Sub
        End If

        ' Insert as a new species
        Dim intNextId As Integer = GetNextSequenceId()
        strQuery = "INSERT INTO " & DB_SPECIES_BUTTONS_TABLE & "(DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor, KeyboardShortcut)" & _
                   " VALUES (" & intNextId & _
                   ", " & DoubleQuote(ButtonText) & _
                   ", " & DoubleQuote(SpeciesCode) & _
                   ", " & DoubleQuote("SpeciesID") & _
                   ", 4" & _
                   ", " & SingleQuote(ButtonColor) & _
                   ", " & DoubleQuote(KeyboardShortcut) & ");"
        Database.ExecuteNonQuery(strQuery)
        RaiseEvent SpeciesButtonsModified() ' Tell the parent form that we have made changes and the buttons need to be redrawn
        Me.Hide()
    End Sub

    ''' <summary>
    ''' Get the next unique ID from the species buttons table so that the new button can be inserted properly into the database table.
    ''' </summary>
    Private Function GetNextSequenceId() As Integer
        Dim strQuery = "SELECT Max(DrawingOrder) FROM " & DB_SPECIES_BUTTONS_TABLE & ";"
        Dim idTable As DataTable = Database.GetDataTable(strQuery, DB_SPECIES_BUTTONS_TABLE)
        Dim intId = idTable.Rows(0).Item(0) ' The query will only return 1 result because it is a MAX query.
        Return intId + 1
    End Function

    ''' <summary>
    ''' Whenever the selected index chages for the Common Name, set the other controls to match the Common Name.
    ''' </summary>
    Private Sub cboCommonName_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCommonName.SelectionChangeCommitted
        Dim item As DataRowView = TryCast(Me.cboCommonName.SelectedItem, DataRowView)
        If item IsNot Nothing Then
            m_speciesName = item.Row.Item(0).ToString()
            Dim strQuery As String = "SELECT DISTINCT ScientificName, SpeciesCode, TaxonomyClassLevelCode FROM " & DB_SPECIES_CODE_TABLE & _
                                     " WHERE CommonName = " & DoubleQuote(m_speciesName) & " ORDER BY SpeciesCode;"
            Dim selected_table As DataTable = Database.GetDataTable(strQuery, DB_SPECIES_CODE_TABLE)

            ' Set the scientific name, species code, and taxonomic name to match the selected common name
            m_speciesScienceName = selected_table.Rows(0)("ScientificName")
            m_speciesCode = selected_table.Rows(0)("SpeciesCode")
            m_speciesTaxCode = selected_table.Rows(0)("TaxonomyClassLevelCode")
            m_button_text = m_speciesName

            ' Set fields on the form to reflect the change
            Dim index As Integer = cboScientificName.FindStringExact(m_speciesScienceName)
            cboScientificName.SelectedIndex = index
            txtSpeciesCode.Text = m_speciesCode
            txtTaxonomicLevel.Text = m_speciesTaxCode
            txtSpeciesBtnTxt.Text = m_speciesName
        End If
    End Sub

    ''' <summary>
    ''' Whenever the selected index chages for the Common Name, set the other controls to match the Common Name.
    ''' </summary>
    Private Sub cboScientificName_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboScientificName.SelectionChangeCommitted
        Dim item As DataRowView = TryCast(Me.cboScientificName.SelectedItem, DataRowView)
        If item IsNot Nothing Then
            m_speciesScienceName = item.Row.Item(0).ToString()
            Dim strQuery As String = "SELECT DISTINCT CommonName, SpeciesCode, TaxonomyClassLevelCode FROM " & DB_SPECIES_CODE_TABLE & _
                                     " WHERE ScientificName = " & DoubleQuote(m_speciesScienceName) & " ORDER BY SpeciesCode;"
            Dim selected_table As DataTable = Database.GetDataTable(strQuery, DB_SPECIES_CODE_TABLE)

            ' Set the scientific name, species code, and taxonomic name to match the selected common name
            If IsDBNull(selected_table.Rows(0)("CommonName")) Then
                m_speciesName = ""
                m_button_text = m_speciesScienceName
                m_speciesCode = selected_table.Rows(0)("SpeciesCode")
                m_speciesTaxCode = selected_table.Rows(0)("TaxonomyClassLevelCode")
                txtSpeciesBtnTxt.Text = m_button_text
                txtSpeciesCode.Text = m_speciesCode
                txtTaxonomicLevel.Text = m_speciesTaxCode
                txtSpeciesBtnTxt.Text = m_button_text
                cboCommonName.SelectedIndex = -1
                cboCommonName.Text = "No common name available"
                Exit Sub
            End If
            m_speciesName = selected_table.Rows(0)("CommonName")
            m_speciesCode = selected_table.Rows(0)("SpeciesCode")
            m_speciesTaxCode = selected_table.Rows(0)("TaxonomyClassLevelCode")
            m_button_text = m_speciesName

            ' Set fields on the form to reflect the change
            Dim index As Integer = cboCommonName.FindStringExact(m_speciesName)
            cboCommonName.SelectedIndex = index
            txtSpeciesCode.Text = m_speciesCode
            txtTaxonomicLevel.Text = m_speciesTaxCode
            txtSpeciesBtnTxt.Text = m_button_text
        End If
    End Sub

    ''' <summary>
    ''' Handles the case when the user chages the selection in the Button Colors combobox. Simply sets a member variable when changed.
    ''' If the selection is null, DarkSlateGray will be used as the default
    ''' </summary>
    Private Sub cboButtonColor_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboButtonColors.SelectionChangeCommitted
        Dim item As DataRowView = TryCast(Me.cboButtonColors.SelectedItem, DataRowView)
        If item IsNot Nothing Then
            m_buttonColor = item.Row.Item(0).ToString()
        Else
            m_buttonColor = "DarkSlateGray"
        End If
    End Sub

    ''' <summary>
    ''' Fills the controls based on the current species code. Used from a parent form when it wants to populate the fields automatically with a supplied
    ''' species code value.
    ''' </summary>
    Public Sub FillControlsUsingSpeciesCode()
        If SpeciesCode <> "" Then
            ' Get the current setup for this species
            Dim strQuery As String = "SELECT DISTINCT ButtonText, ButtonCode, ButtonColor, KeyboardShortcut FROM " & DB_SPECIES_BUTTONS_TABLE & _
                                     " WHERE ButtonCode = " & DoubleQuote(SpeciesCode) & " ORDER BY ButtonCode;"
            Dim selected_table As DataTable = Database.GetDataTable(strQuery, DB_SPECIES_BUTTONS_TABLE)

            ' Get the other data from the species code table for this species.
            Dim strQueryExtra As String = "SELECT DISTINCT CommonName, ScientificName, TaxonomyClassLevelCode FROM " & DB_SPECIES_CODE_TABLE & _
                                          " WHERE SpeciesCode = " & DoubleQuote(SpeciesCode) & " ORDER BY SpeciesCode;"
            Dim selected_table_extra As DataTable = Database.GetDataTable(strQuery, DB_SPECIES_CODE_TABLE)

            m_button_text = selected_table.Rows(0)("ButtonText")
            m_buttonColor = selected_table.Rows(0)("ButtonColor")
            m_keyboard_shortcut = selected_table.Rows(0)("KeyboardShortcut")

            m_speciesScienceName = selected_table_extra.Rows(0)("ScientificName")
            m_speciesName = selected_table_extra.Rows(0)("CommonName")
            m_speciesTaxCode = selected_table_extra.Rows(0)("TaxonomyClassLevelCode")

            txtSpeciesBtnTxt.Text = ButtonText
            txtSpeciesCode.Text = SpeciesCode
            txtTaxonomicLevel.Text = m_speciesTaxCode

            Dim index As Integer = cboCommonName.FindStringExact(m_speciesName)
            cboCommonName.SelectedIndex = index

            index = cboScientificName.FindStringExact(m_speciesScienceName)
            cboScientificName.SelectedIndex = index

        End If
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

    Private Sub txtSpeciesBtnTxt_TextChanged(sender As Object, e As EventArgs) Handles txtSpeciesBtnTxt.TextChanged
        m_button_text = txtSpeciesBtnTxt.Text
    End Sub
End Class