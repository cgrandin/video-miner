Imports System.Text.RegularExpressions

Public Class frmSpeciesEvent

#Region "Member variables"
    ''' <summary>
    ''' Holds the species name
    ''' </summary>
    Private m_speciesName As String
    ''' <summary>
    ''' Holds the species code
    ''' </summary>
    Private m_speciesCode As String
    ''' <summary>
    ''' Holds the currently entered range
    ''' </summary>
    Private m_range As String
    ''' <summary>
    ''' Holds the currently selected Side code as found in the database table lu_observed_side
    ''' </summary>
    Private m_side As Integer
    ''' <summary>
    ''' Holds the currently selected ConfidenceID code as found in the database table lu_confidence_ids
    ''' </summary>
    Private m_IDConfidence As String
    ''' <summary>
    ''' Holds the currently selected Abundance code as found in the database table lu_acfor_scale
    ''' </summary>
    Private m_Abundance As String
    ''' <summary>
    ''' Holds the currently entered count
    ''' </summary>
    Private m_Count As String
    ''' <summary>
    ''' Holds the currently entered height
    ''' </summary>
    Private m_Height As String
    ''' <summary>
    ''' Holds the currently entered width
    ''' </summary>
    Private m_Width As String
    ''' <summary>
    ''' Holds the currently entered length of the specimen
    ''' </summary>
    Private m_Length As String
    ''' <summary>
    ''' Holds the currently entered comments
    ''' </summary>
    Private m_Comments As String
    ''' <summary>
    ''' A tuple for the Dictionary object, m_dict.
    ''' </summary>
    Private m_tuple As Tuple(Of String, String, Boolean)
    ''' <summary>
    ''' Dictionary of key/value pairs that hold the currently selected data for this species event.
    ''' The first parameter is the name of the field in the database table lu_data. The tuple is a triplet of data code (from lu_data_codes),
    ''' the data value to be inserted, and a boolean for whether or not the item was the one pressed (in case there are more than one in the dictionary).
    ''' </summary>
    Private m_dict As Dictionary(Of String, Tuple(Of String, String, Boolean))
#End Region

    Public Event NewSpeciesEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)

#Region "Properties"
    Public Property SpeciesData() As Dictionary(Of String, Tuple(Of String, String, Boolean))
        Get
            Return m_dict
        End Get
        Set(ByVal value As Dictionary(Of String, Tuple(Of String, String, Boolean)))
            m_dict = value
        End Set
    End Property

    Public Property SpeciesName() As String
        Get
            Return m_speciesName
        End Get
        Set(ByVal value As String)
            m_speciesName = value
        End Set
    End Property

    Public Property SpeciesCode() As String
        Get
            Return m_speciesCode
        End Get
        Set(ByVal value As String)
            m_speciesCode = value
        End Set
    End Property

    Public Property Range() As String
        Get
            Return m_range
        End Get
        Set(ByVal value As String)
            m_range = value
        End Set
    End Property

    Public Property Side() As String
        Get
            Return m_side
        End Get
        Set(ByVal value As String)
            m_side = value
        End Set
    End Property

    Public Property IDConfidence() As String
        Get
            Return m_IDConfidence
        End Get
        Set(ByVal value As String)
            m_IDConfidence = value
        End Set
    End Property

    Public Property Abundance() As String
        Get
            Return m_Abundance
        End Get
        Set(ByVal value As String)
            m_Abundance = value
        End Set
    End Property

    Public Property Count() As String
        Get
            Return m_Count
        End Get
        Set(ByVal value As String)
            m_Count = value
        End Set
    End Property

    Public Property SpeciesHeight() As String
        Get
            Return m_Height
        End Get
        Set(ByVal value As String)
            m_Height = value
        End Set
    End Property

    Public Property SpeciesWidth() As String
        Get
            Return m_Width
        End Get
        Set(ByVal value As String)
            m_Width = value
        End Set
    End Property

    Public Property SpeciesLength() As String
        Get
            Return m_Length
        End Get
        Set(ByVal value As String)
            m_Length = value
        End Set
    End Property

    Public Property Comments() As String
        Get
            Return m_Comments
        End Get
        Set(ByVal value As String)
            m_Comments = value
        End Set
    End Property

    Public ReadOnly Property Dictionary As Dictionary(Of String, Tuple(Of String, String, Boolean))
        Get
            Return m_dict
        End Get
    End Property
#End Region

    Public Sub New(species_name As String)
        InitializeComponent()
        SpeciesName = species_name
        Me.Text = "Species Event - " & SpeciesName
        m_tuple = New Tuple(Of String, String, Boolean)(Nothing, Nothing, False)
        m_dict = New Dictionary(Of String, Tuple(Of String, String, Boolean))
    End Sub

    ''' <summary>
    ''' When the form is loaded, Populate the comboboxes with vlues from the database and hardcoded items for 'Side', 'ID Confidence', and 'Abundance'.
    ''' Also sets the count to 1.
    ''' </summary>
    Private Sub SpeciesEventForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Populate the species combobox
        Dim strQuery As String = "select DrawingOrder, ButtonText, ButtonCode from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;"
        Dim data_table As DataTable = Database.GetDataTable(strQuery, DB_SPECIES_BUTTONS_TABLE)
        With cboSpecies
            .DataSource = data_table
            .DisplayMember = data_table.Columns(1).ColumnName
            .ValueMember = data_table.Columns(2).ColumnName
            .SelectedIndex = -1 ' If 0, the first item will be preselected, if -1, no items will be selected (default fresh loaded condition).
        End With
        ' Populate the 'Side' combobox. Uses the table lu_observed_side from the database
        strQuery = "SELECT * FROM " & DB_OBSERVED_SIDE_TABLE & " ORDER BY Code;"
        Dim dtSide As DataTable = Database.GetDataTable(strQuery, DB_OBSERVED_SIDE_TABLE)
        With cboSide
            .DataSource = dtSide
            .DisplayMember = dtSide.Columns(0).ColumnName
            .ValueMember = dtSide.Columns(1).ColumnName
            .SelectedIndex = 0
        End With
        ' Populate the 'ID Confidence' combobox
        strQuery = "SELECT * FROM " & DB_CONFIDENCE_IDS_TABLE & " ORDER BY ConfidenceId;"
        Dim dtIDConfidence As DataTable = Database.GetDataTable(strQuery, DB_CONFIDENCE_IDS_TABLE)
        With cboIDConfidence
            .DataSource = dtIDConfidence
            .DisplayMember = dtIDConfidence.Columns(1).ColumnName
            .ValueMember = dtIDConfidence.Columns(0).ColumnName
            .SelectedIndex = 0
        End With
        ' Populate the 'Abundance' combobox
        strQuery = "SELECT * FROM " & DB_ABUNDANCE_TABLE & " ORDER BY ACFORScaleID;"
        Dim dtAbundance As DataTable = Database.GetDataTable(strQuery, DB_ABUNDANCE_TABLE)
        With cboAbundance
            .DataSource = dtAbundance
            .DisplayMember = dtAbundance.Columns(1).ColumnName
            .ValueMember = dtAbundance.Columns(0).ColumnName
            .SelectedIndex = 0
        End With
        ' Set the count to a default of 1
        txtCount.Text = 1
    End Sub

    ''' <summary>
    '''  When the SpeciesEventForm is displayed, draw a red arc at the bottom of the form with an
    '''  attatched red line going to the top of the form. This line helps a user visualize the center line,
    '''  and ranges to the left or right of the center line.
    ''' </summary>
    Private Sub pnlSpeciesEvent_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlSpeciesEvent.Paint
        Dim a As Graphics = e.Graphics
        Dim mypen As Pen = New Pen(System.Drawing.Color.Red, 3)
        a = pnlSpeciesEvent.CreateGraphics
        a.Clear(pnlSpeciesEvent.BackColor)
        Dim intWidth As Integer = CType(pnlSpeciesEvent.Width, Integer)
        a.DrawArc(mypen, 0, 200, intWidth - 5, 200, 0, -180)
        Dim xCenter As Integer = CType(pnlSpeciesEvent.Width / 2, Integer)
        a.DrawLine(mypen, xCenter, 200, xCenter, 0)
        a.Dispose()
        mypen.Dispose()
    End Sub

    ''' <summary>
    ''' If the user has selected 'Port' or 'Starboard' in the Side combobox and the Range is the empty string or zero,
    ''' alert the user to fill them in with an integer before allowing the submission for insertion into the database.
    ''' </summary>
    Private Sub ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ok.Click
        ' The codes 1 and 2 below reflect Port and Starboard. The commented out if statement shows what is really going on here.
        'If cboSide.SelectedItem = "Port" Or cboSide.SelectedItem = "Starboard" Then
        If cboSide.SelectedValue = 1 Or cboSide.SelectedValue = 2 Then
            If txtRange.Text = "" Or CType(txtRange.Text, Integer) = 0 Then
                txtRange.Select(0, txtRange.Text.Length)
                MessageBox.Show("You must enter a value greater than zero in the Range textbox when you choose 'Port' or 'Starboard' for 'Side'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Else
            ' User chose 'On Center'. Make sure that the Range is either empty string or 0
            If txtRange.Text <> "" And txtRange.Text <> "0" Then
                txtRange.Select(0, txtRange.Text.Length)
                MessageBox.Show("You have entered a value in the Range textbox and also chosen 'On Center' for 'Side'. Either change your selection for 'Side' or remove your entry from the 'Range' textbox.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If
        ' Record all member variables to reflect all the changes which have been validated. Also check for empty strings and change them to "NULL"
        ' so the query won't break later.
        SpeciesName = cboSpecies.Text
        SpeciesCode = cboSpecies.SelectedValue
        Range = txtRange.Text
        If Range = "" Then
            Range = "NULL"
        End If
        Side = cboSide.SelectedValue
        If Side = "" Then
            Side = "NULL"
        End If
        IDConfidence = cboIDConfidence.SelectedValue
        If IDConfidence = "" Then
            IDConfidence = "NULL"
        End If
        Abundance = cboAbundance.SelectedValue
        If Abundance = "" Then
            Abundance = "NULL"
        End If
        Count = txtCount.Text
        If Count = "" Then
            Count = "NULL"
        End If
        SpeciesHeight = txtHeight.Text
        If SpeciesHeight = "" Then
            SpeciesHeight = "NULL"
        End If
        SpeciesWidth = txtWidth.Text
        If SpeciesWidth = "" Then
            SpeciesWidth = "NULL"
        End If
        SpeciesLength = txtLength.Text
        If SpeciesLength = "" Then
            SpeciesLength = "NULL"
        End If
        Comments = rtxtComments.Text
        If Comments = "" Then
            ' This one is a bit different, this needs to be "" instead of NULL.
            Comments = ""
        End If
        ' build the dictionary of data..
        buildDictionary()
        ' Raise Event to tell parent form that we wish a record to be added to the database
        RaiseEvent NewSpeciesEntryEvent(Me, e)
        Me.Hide()
    End Sub

    ''' <summary>
    ''' Build the dictionary of key/value pairs for the data the user chose.
    ''' </summary>
    Private Sub buildDictionary()
        ' Clear the dictionary from the previous time if necessary
        m_dict.Clear()
        ' The first parameter is the name of the field in the database table lu_data. The tuple is a triplet of data code (from lu_data_codes), which is 4 for a species entry,
        ' the data value to be inserted, and a boolean for whether or not the item was the one pressed (in case there are more than one in the dictionary).
        m_tuple = New Tuple(Of String, String, Boolean)("4", DoubleQuote(SpeciesName), True)
        m_dict.Add("SpeciesName", m_tuple)
        m_tuple = New Tuple(Of String, String, Boolean)("4", DoubleQuote(SpeciesCode), False)
        m_dict.Add("SpeciesID", m_tuple)
        m_tuple = New Tuple(Of String, String, Boolean)("4", Side, False)
        m_dict.Add("Side", m_tuple)
        m_tuple = New Tuple(Of String, String, Boolean)("4", Range, False)
        m_dict.Add("Range", m_tuple)
        m_tuple = New Tuple(Of String, String, Boolean)("4", SpeciesLength, False)
        m_dict.Add("Length", m_tuple)
        m_tuple = New Tuple(Of String, String, Boolean)("4", SpeciesHeight, False)
        m_dict.Add("Height", m_tuple)
        m_tuple = New Tuple(Of String, String, Boolean)("4", SpeciesWidth, False)
        m_dict.Add("Width", m_tuple)
        m_tuple = New Tuple(Of String, String, Boolean)("4", Abundance, False)
        m_dict.Add("Abundance", m_tuple)
        m_tuple = New Tuple(Of String, String, Boolean)("4", IDConfidence, False)
        m_dict.Add("IDConfidence", m_tuple)
        m_tuple = New Tuple(Of String, String, Boolean)("4", DoubleQuote(Comments), False)
        m_dict.Add("Comment", m_tuple)
    End Sub


    Private Sub cmdScreenCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScreenCapture.Click
        'CJG
        'myFormLibrary.frmVideoMiner.blScreenCaptureCalled = True
        'myFormLibrary.frmVideoMiner.mnuCapScr_Click(sender, e)
        'myFormLibrary.frmVideoMiner.blScreenCaptureCalled = False
    End Sub

    ''' <summary>
    ''' This code is run everytime the form's show function is called. It resets the species combobox back to it's correct default species name
    ''' </summary>
    Public Sub formShown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            Dim index As Integer = cboSpecies.FindStringExact(SpeciesName)
            cboSpecies.SelectedIndex = index
        End If
    End Sub

    ''' <summary>
    ''' Validate that the count texbox only has digits in it (an integer). And it must have at least one digit (no empty strings).
    ''' </summary>
    Private Sub txt_Validating_NonNull(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCount.Validating
        Dim tb As TextBox = CType(sender, TextBox)
        ' This regular expression allows 1 or more digits.
        ' So it covers integers but does not allow for the empty string.
        Dim regex As New Regex("^\d+$")
        Dim match As Match = regex.Match(tb.Text)
        If Not match.Success Then
            e.Cancel = True
            tb.Select(0, tb.Text.Length)
            MessageBox.Show("Only numeric characters are permitted in the '" & Strings.Right(tb.Name, tb.Name.Length - 3) & "' textbox.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    ''' <summary>
    ''' Validate that the non-count texboxes only have empty strings, integers, or real numbers.
    ''' </summary>
    Private Sub txt_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtHeight.Validating, txtLength.Validating, txtWidth.Validating, txtRange.Validating
        Dim tb As TextBox = CType(sender, TextBox)
        ' This regular expression allows for the empty string, or 1 or more digits followed by optional single decimal point and more digits.
        ' So it covers simply leaving the box (empty string), integers, or decimal numbers.
        Dim regex As New Regex("^(\d+(\.\d+)?)*$")
        Dim match As Match = regex.Match(tb.Text)
        If Not match.Success Then
            e.Cancel = True
            ' Select the erroneous text so the user can change without having to do anything else.
            tb.Select(0, tb.Text.Length)
            MessageBox.Show("Only a blank, integers or decimal numbers are permitted in the '" & Strings.Right(tb.Name, tb.Name.Length - 3) & "' textbox.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    ''' <summary>
    ''' When user presses cancel, hide the form instead of closing it. It is created only once and needs to remain persistent.
    ''' </summary>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
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

End Class

