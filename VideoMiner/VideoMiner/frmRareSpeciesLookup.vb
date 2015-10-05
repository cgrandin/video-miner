Public Class frmRareSpeciesLookup
    ''' <summary>
    ''' Holds the data from queries issued to the database
    ''' </summary>
    Private m_species_table As DataTable
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
    Private WithEvents frmSpeciesEvent As frmSpeciesEvent

    Public Event SpeciesCodeChangedEvent(sender As System.Object, e As System.EventArgs)

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
#End Region

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmRareSpeciesLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Initialize member variables and controls to default state.
        ClearControls()

        ' The WHERE <> """" in the following three queries remove any null string species names from the lists
        Dim strQuery As String = "SELECT DISTINCT ScientificName FROM " & DB_SPECIES_CODE_TABLE & " WHERE ScientificName <> """" ORDER BY 1;"
        m_species_table = Database.GetDataTable(strQuery, DB_SPECIES_CODE_TABLE)
        PopulateComboBox(Me.cboScientificName, m_species_table)

        strQuery = "SELECT DISTINCT CommonName FROM " & DB_SPECIES_CODE_TABLE & " WHERE CommonName <> """" ORDER BY 1;"
        m_species_table = Database.GetDataTable(strQuery, DB_SPECIES_CODE_TABLE)
        PopulateComboBox(Me.cboCommonName, m_species_table)
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
    ''' Clears out all controls of their current values and resets member variables to a freshly loaded default state.
    ''' </summary>
    Public Sub ClearControls()
        m_speciesName = ""
        m_speciesScienceName = ""
        m_speciesCode = ""

        cboCommonName.SelectedIndex = -1
        cboCommonName.Text = "" ' In case the last thing in the box was "No common name available" which is at position -1.
        cboScientificName.SelectedIndex = -1

        txtSpeciesCode.Text = ""
        txtTaxonomicLevel.Text = ""
    End Sub

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

            ' Set fields on the form to reflect the change
            Dim index As Integer = cboScientificName.FindStringExact(m_speciesScienceName)
            cboScientificName.SelectedIndex = index
            txtSpeciesCode.Text = m_speciesCode
            txtTaxonomicLevel.Text = m_speciesTaxCode
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
                m_speciesCode = selected_table.Rows(0)("SpeciesCode")
                m_speciesTaxCode = selected_table.Rows(0)("TaxonomyClassLevelCode")
                txtSpeciesCode.Text = m_speciesCode
                txtTaxonomicLevel.Text = m_speciesTaxCode
                cboCommonName.SelectedIndex = -1
                cboCommonName.Text = "No common name available"
                Exit Sub
            End If
            m_speciesName = selected_table.Rows(0)("CommonName")
            m_speciesCode = selected_table.Rows(0)("SpeciesCode")
            m_speciesTaxCode = selected_table.Rows(0)("TaxonomyClassLevelCode")

            ' Set fields on the form to reflect the change
            Dim index As Integer = cboCommonName.FindStringExact(m_speciesName)
            cboCommonName.SelectedIndex = index
            txtSpeciesCode.Text = m_speciesCode
            txtTaxonomicLevel.Text = m_speciesTaxCode
        End If
    End Sub

    ''' <summary>
    ''' If the user has selected a species, this will fire an event telling the main form to record a record in the data table in the database.
    ''' </summary>
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If SpeciesName = "" Then
            frmSpeciesEvent = New frmSpeciesEvent(Me.SpeciesScienceName, Me.SpeciesCode)
        Else
            frmSpeciesEvent = New frmSpeciesEvent(Me.SpeciesName, Me.SpeciesCode)
        End If
        frmSpeciesEvent.Show()
    End Sub

    ''' <summary>
    ''' If user presses the cancel button, just hide the form since it is modeless.
    ''' </summary>
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Hide()
    End Sub

    ''' <summary>
    ''' Capture the event when the user presses the 'X' button top right. Instead of closing the form, just hide it.
    ''' </summary>
    Private Sub me_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    ''' <summary>
    ''' Tell Videominer that the user widhes to submit a database record addition for the species listed.
    ''' </summary>
    Private Sub species_entry_event(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmSpeciesEvent.NewSpeciesEntryEvent
        RaiseEvent SpeciesCodeChangedEvent(sender, e)
        Me.Hide()
    End Sub
End Class