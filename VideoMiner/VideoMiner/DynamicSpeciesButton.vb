''' <summary>
''' A Videominer dynamic species button. This button extends a regular button by holding 
''' the database table name, an instance of the DataTable, the current data code,
''' and the code name.
''' </summary>
''' <remarks></remarks>
Public Class DynamicSpeciesButton
    Inherits Button

    ''' <summary>
    ''' The default, uninitialized value for the DataValue property
    ''' </summary>
    ''' <remarks>This is set in the constructors</remarks>
    Public Const UNINITIALIZED_DATA_VALUE = "NULL"

#Region "Member variables"
    ''' <summary>
    ''' The instance of the species event form for this button.
    ''' </summary>
    Dim WithEvents m_frmSpeciesEvent As frmSpeciesEvent
    ''' <summary>
    ''' Code for the button. This may not be set if the button type is for a data table.
    ''' </summary>
    Private m_button_code As String
    ''' <summary>
    ''' Name for the button code. This may not be set if the button type is for a data table.
    ''' </summary>
    Private m_button_code_name As String
    ''' <summary>
    ''' A String representing a keyboard shortcut. This is what can be pressed to trigger a Click event on the button.
    ''' </summary>
    Private m_keyboard_shortcut As String
    ''' <summary>
    ''' The table view of the abundance table.
    ''' </summary>
    Private WithEvents m_abundance_table As frmAbundanceTableView
    Public Enum WhichEntryStyleEnum
        Quick
        Detailed
        Abundance
    End Enum
    ''' <summary>
    ''' Holds the style of entry for species data
    ''' </summary>
    Private m_which_entry_style As WhichEntryStyleEnum
    ''' <summary>
    ''' Data code for a Species Event (4)
    ''' </summary>
    Private m_data_code As Integer = 4
    ''' <summary>
    ''' Name of the data code (description) as found in the lu_data_codes table.
    ''' This is NOT the code chosen by the user in the table view, this is the
    ''' code for this particular table.
    ''' </summary>
    Private m_data_code_name As String
    ''' <summary>
    ''' A description of the data code
    ''' </summary>
    Private m_data_code_description As String
    ''' <summary>
    ''' The value of the chosen data from clicking a species event button.
    ''' It must be a string so that "NULL" can be passed to the SQL query if it was not chosen to be part of the query.
    ''' </summary>
    Private m_data_value As String
    ''' <summary>
    ''' Currently entered comment
    ''' </summary>
    Private m_current_comment As String
#End Region

#Region "Properties"
    Public Property ButtonCode As String
        Get
            Return m_button_code
        End Get
        Set(value As String)
            m_button_code = value
        End Set
    End Property
    ''' <summary>
    ''' Data code used for table-based data. e.g. table lu_survey_mode is associated with data code 9 in the lu_data_codes table
    ''' </summary>
    Public Property DataCode As Integer
        Get
            Return m_data_code
        End Get
        Set(value As Integer)
            m_data_code = value
        End Set
    End Property
    Public Property DataCodeName As String
        Get
            Return m_data_code_name
        End Get
        Set(value As String)
            m_data_code_name = value
        End Set
    End Property
    Public Property DataValue As String
        Get
            Return m_data_value
        End Get
        Set(value As String)
            m_data_value = value
        End Set
    End Property
    Public Property DataDescription As String
        Get
            Return m_data_code_description
        End Get
        Set(value As String)
            m_data_code_description = value
        End Set
    End Property
    Public Property DataComment As String
        Get
            Return m_current_comment
        End Get
        Set(value As String)
            m_current_comment = value
        End Set
    End Property
    ''' <summary>
    ''' Enumeration type for style of entry for this panel. Only applies to species panels.
    ''' See WhichEntryStyleEnum for descriptions.
    ''' </summary>
    Public Property WhichEntryStyle As WhichEntryStyleEnum
        Get
            Return m_which_entry_style
        End Get
        Set(value As WhichEntryStyleEnum)
            m_which_entry_style = value
        End Set
    End Property

#End Region

#Region "Events"
    ''' <summary>
    ''' This event will propagate or bubble up the same event raised from within the frmSpeciesEvent class.
    ''' </summary>
    Public Event NewSpeciesEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Signals the parent that a button has been pressed and we request that the video be paused while data entry takes place.
    ''' </summary>
    Public Event SignalVideoPause(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Signals the parent that the data entry is complete and to resime playback.
    ''' </summary>
    Public Event SignalVideoPlay(ByVal sender As System.Object, ByVal e As System.EventArgs)
#End Region

    ''' <summary>
    ''' Creates a new species button.
    ''' </summary>
    ''' <param name="buttonText">Text to appear on the button</param>
    ''' <param name="buttonCode">Species code</param>
    ''' <param name="buttonCodeName">Name for the button code, (e.g. SpeciesID)</param>
    ''' <param name="buttonColor">The microsoft color for this button's text (e.g. "DarkBlue")</param>
    ''' <param name="keyboardShortcut">Keyboard shortcut that will run the Click event for this button</param>
    ''' <param name="buttonFont">The font to use for this button (e.g. "Microsoft Sans Serif")</param>
    ''' <param name="buttonTextSize">The font size to use for this button's text (in pts)</param>
    ''' <param name="whichEntryStyle">Entry style (quick, detailed, abundance) for a species button.</param>
    ''' <remarks></remarks>
    Public Sub New(buttonText As String,
                   buttonCode As String,
                   buttonCodeName As String,
                   dataCode As String,
                   buttonColor As String,
                   keyboardShortcut As String,
                   buttonFont As String,
                   buttonTextSize As Integer,
                   Optional whichEntryStyle As WhichEntryStyleEnum = WhichEntryStyleEnum.Detailed)
        Me.Name = buttonText
        Me.Text = buttonText
        Dim colConvert As ColorConverter = New ColorConverter()
        Try
            Me.ForeColor = CType(colConvert.ConvertFromString(buttonColor), Color)
        Catch ex As Exception
            Me.ForeColor = Color.Black
        End Try
        Dim font_family As FontFamily = New FontFamily(buttonFont)
        If font_family.IsStyleAvailable(FontStyle.Regular) Then
            Me.Font = New Font(font_family, buttonTextSize, FontStyle.Regular)
        ElseIf font_family.IsStyleAvailable(FontStyle.Bold) Then
            Me.Font = New Font(font_family, buttonTextSize, FontStyle.Bold)
        ElseIf font_family.IsStyleAvailable(FontStyle.Italic) Then
            Me.Font = New Font(font_family, buttonTextSize, FontStyle.Italic)
        End If
        m_button_code = buttonCode
        m_button_code_name = buttonCodeName
        m_keyboard_shortcut = keyboardShortcut
        m_which_entry_style = whichEntryStyle

        m_data_value = UNINITIALIZED_DATA_VALUE
        m_frmSpeciesEvent = New frmSpeciesEvent(buttonText)
    End Sub

    ''' <summary>
    ''' Show the species event form for the current species.
    ''' </summary>
    Public Sub ShowForm(sender As Object, e As EventArgs)
        If m_which_entry_style = WhichEntryStyleEnum.Detailed Then
            RecordDetailed()
        ElseIf m_which_entry_style = WhichEntryStyleEnum.Quick Then
            RecordQuick()
        ElseIf m_which_entry_style = WhichEntryStyleEnum.Abundance Then
            RecordAbundance()
        End If
        ' Raise an event to signal the beginning of the process of entering a species event.
        ' The video needs to be paused at this point, and restarted when the user presses OK on the spceies event
        ' Form which Is being worked on.
        RaiseEvent SignalVideoPause(Me, e)
    End Sub

    ''' <summary>
    ''' Open the species event form to record a detailed species event.
    ''' </summary>
    Private Sub RecordDetailed()
        m_frmSpeciesEvent.Show()
    End Sub
    ''' <summary>
    ''' Record count value to the frmSpeciesEvent.
    ''' </summary>
    Public Sub RecordQuick(Optional count As String = NULL_STRING)
        m_frmSpeciesEvent.Acknowledge(count)
    End Sub

    ''' <summary>
    ''' Record an abundance only event.
    ''' </summary>
    Public Sub RecordAbundance()
        m_abundance_table = New frmAbundanceTableView
        m_abundance_table.Show()
    End Sub

    ''' <summary>
    ''' Handle the changing by the user of the lookup table code found in frmTableView, and fire an event to the parent.
    ''' </summary>
    Private Sub abundanceDataChanged(sender As System.Object, e As System.EventArgs) Handles m_abundance_table.DataChanged
        m_data_value = m_abundance_table.SelectedCode
        m_data_code_description = m_abundance_table.SelectedCodeName
        m_current_comment = m_abundance_table.Comment
        m_data_code_name = "DataCode"
        m_data_code = 4
        m_frmSpeciesEvent.Acknowledge(NULL_STRING, m_abundance_table.SelectedCode, m_abundance_table.Comment)
    End Sub

    ''' <summary>
    ''' Raise ane event when the species form has raised one (User pressed OK or Cancel
    ''' on the species form).
    ''' </summary>
    Private Sub signal_video_play() Handles m_frmSpeciesEvent.SignalPlay
        RaiseEvent SignalVideoPlay(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Handles the event request to insert a new entry into the database. The species event form which corresponds to this button has been populated, validated, and the values are ready to be extracted.
    ''' This just bubbles the event up to the parent.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub new_species_entry_handler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_frmSpeciesEvent.NewSpeciesEntryEvent
        RaiseEvent NewSpeciesEntryEvent(sender, e)
    End Sub
End Class
