''' <summary>
''' A panel which supports loading of dynamic species buttons.
''' </summary>
''' <remarks></remarks>
Public Class DynamicSpeciesButtonPanel
    Inherits Panel

#Region "Member variables"
    Private m_button_width As Integer
    Private m_button_height As Integer
    Private m_button_font As String
    Private m_button_text_size As Integer
    ''' <summary>
    ''' The number of dynamic buttons currently on the panel
    ''' </summary>
    Private m_num_dynamic_buttons As Integer
    ''' <summary>
    ''' Array of Dynamic buttons. This will be redimensioned at runtime
    ''' </summary>
    Private m_dynamic_buttons As DynamicSpeciesButton()
    ''' <summary>
    ''' Lets the fillPanel function know at what vertical level to start placing dynamic buttons
    ''' </summary>
    Private m_y_offset As Integer
    ''' <summary>
    ''' Gap between dynamic buttons.
    ''' </summary>
    Private m_gap As Integer
    ''' <summary>
    ''' A tuple for the Dictionary object, m_dict.
    ''' </summary>
    Private m_tuple As Tuple(Of String, String, Boolean)
    ''' <summary>
    ''' Dictionary of key/value pairs that hold the currently selected data (most recently-pressed button's data) for this panel.
    ''' If the repeat checkbox is visible and checked, the dictionary will hold the key/value pairs for all buttons on the panel,
    ''' not just the most recently-pressed button's data.
    ''' The first parameter is the name of the field in the database table lu_data. The tuple is a triplet of data code (from lu_data_codes),
    ''' the data value to be inserted, and a boolean for whether or not the item was the one pressed (in case there are more than one in the dictionary).
    ''' </summary>
    Private m_dict As Dictionary(Of String, Tuple(Of String, String, Boolean))
    ''' <summary>
    ''' Data code used for species buttons. Should be 4 for species events.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_data_code As Integer
    ''' <summary>
    ''' Holds the enumeration type for this instance
    ''' </summary>
    Private m_which_entry_style As DynamicSpeciesButton.WhichEntryStyleEnum
#End Region

#Region "Properties"
    ''' Dictionary of key/value pairs that hold the currently set data for this panel.
    ''' If the repeat checkbox is visible and checked, the dictionary will hold the key/value pairs for all buttons on the panel,
    ''' not just the most recently-pressed button's data.
    Public ReadOnly Property Dictionary As Dictionary(Of String, Tuple(Of String, String, Boolean))
        Get
            Return m_dict
        End Get
    End Property
    Public Property WhichEntryStyle As DynamicSpeciesButton.WhichEntryStyleEnum
        Get
            Return m_which_entry_style
        End Get
        Set(value As DynamicSpeciesButton.WhichEntryStyleEnum)
            m_which_entry_style = value
        End Set
    End Property
#End Region

#Region "Events"
    ''' <summary>
    ''' This event will propagate or bubble up the same event raised from within the DynamicSpeciesButton class.
    ''' It signals that the user wants to enter a new record in the database for a species event.
    ''' </summary>
    Public Event NewSpeciesEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Signals the parent that a button has been pressed on this panel and we request that the video be paused while data entry takes place.
    ''' </summary>
    Public Event SignalVideoPause(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Signals the parent that data entry has ended and we request that the video be returned to playing.
    ''' </summary>
    Public Event SignalVideoPlay(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Fire event to have parent form check for dirty data or anything else prior to launching the button code.
    ''' </summary>
    Public Event CheckForDirtyDataEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)

#End Region

    ''' <summary>
    ''' Create the DynamicSpeciesButtonPanel object.
    ''' </summary>
    ''' <param name="intButtonWidth">The width of all the buttons on the panel.</param>
    ''' <param name="intButtonHeight">The height of all the buttons on the panel.</param>
    ''' <param name="strButtonFont">The font for all the buttons on the panel.</param>
    ''' <param name="intButtonTextSize">The font size (pts) for all the buttons on the panel.</param>
    Public Sub New(Optional intButtonWidth As Integer = 170,
                   Optional intButtonHeight As Integer = 44,
                   Optional strButtonFont As String = "Microsoft Sans Serif",
                   Optional intButtonTextSize As Integer = 8)

        m_y_offset = 0
        m_gap = 2
        m_tuple = New Tuple(Of String, String, Boolean)(Nothing, Nothing, False)
        m_dict = New Dictionary(Of String, Tuple(Of String, String, Boolean))

        ' Load button constructs into member variables
        m_button_height = intButtonHeight
        m_button_width = intButtonWidth
        m_button_font = strButtonFont
        m_button_text_size = intButtonTextSize

        Me.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        Me.Dock = DockStyle.Fill

        Me.AutoScroll = True
        m_num_dynamic_buttons = 0
    End Sub

    ''' <summary>
    ''' Fills the panel with the buttons described in the MS Access table given by strTableName
    ''' </summary>
    ''' <param name="strTableName">Name of the button description table in the MS Access database</param>
    Public Sub fillPanel(strTableName As String)
        ' If any dynamic buttons are currently loaded, remove them all
        removeAllDynamicControls()
        Dim d As DataTable = Database.GetDataTable("select * from " & strTableName & " order by DrawingOrder;", strTableName)
        m_num_dynamic_buttons = d.Rows.Count
        ReDim m_dynamic_buttons(m_num_dynamic_buttons)
        Dim i As Integer = 0

        For Each r As DataRow In d.Rows
            m_dynamic_buttons(i) = New DynamicSpeciesButton(r.Item(1).ToString(),
                                                            r.Item(2).ToString(),
                                                            r.Item(3).ToString(),
                                                            r.Item(4),
                                                            r.Item(5).ToString(),
                                                            r.Item(6).ToString(),
                                                            m_button_font,
                                                            m_button_text_size,
                                                            m_which_entry_style)
            AddHandler m_dynamic_buttons(i).NewSpeciesEntryEvent, AddressOf new_species_entry_handler
            AddHandler m_dynamic_buttons(i).SignalVideoPause, AddressOf signal_video_pause
            AddHandler m_dynamic_buttons(i).SignalVideoPlay, AddressOf signal_video_play
            AddHandler m_dynamic_buttons(i).Click, AddressOf button_CheckForDirtyDataEvent
            i += 1
        Next
        placeControls()
    End Sub

    ''' <summary>
    ''' Place the controls in the panel in a grid fashion.
    ''' </summary>
    Private Sub placeControls()
        Dim h As Integer = Me.Height
        Dim w As Integer = Me.Width
        Dim sizex As Integer = m_button_width
        Dim sizey As Integer = m_button_height
        Dim intAdd As Integer = 0
        Dim intMultiply As Integer = 0
        Dim intCountPerRow As Integer
        Dim cellsizex As Integer = sizex + m_gap
        Dim cellsizey As Integer = sizey + m_gap
        intCountPerRow = Math.Floor(w / (cellsizex))
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            m_dynamic_buttons(i).Size = New Size(sizex, sizey)
            m_dynamic_buttons(i).Location = New System.Drawing.Point(m_gap + (cellsizex * (i - intAdd)), m_y_offset + (cellsizey * intMultiply))
            Me.Controls.Add(m_dynamic_buttons(i))
            If i Mod intCountPerRow = intCountPerRow - 1 Then
                intAdd += intCountPerRow
                intMultiply += 1
            End If
        Next
    End Sub

    ''' <summary>
    ''' Removes all dynamic controls (DynamicButton and DynamicTextbox controls) from the panel.
    ''' </summary>
    Public Sub removeAllDynamicControls()
        Do While Controls.Count > 0
            Controls.RemoveAt(0)
        Loop
    End Sub

    ''' <summary>
    ''' Build the dictionary of key/value pairs.
    ''' </summary>
    ''' <param name="btn">The button to build the dictionary for.</param>
    Private Sub buildDictionary(btn As DynamicSpeciesButton)
        m_dict.Clear()
        If btn.DataValue <> DynamicSpeciesButton.UNINITIALIZED_DATA_VALUE Then
            m_tuple = New Tuple(Of String, String, Boolean)(btn.DataCode, btn.DataValue, True)
            m_dict.Add(btn.DataCodeName, m_tuple)
        End If
        'm_tuple = New Tuple(Of String, String, Boolean)(btn.DataCode, btn.DataValue, True)
        'm_dict.Add(btn.DataCodeName, m_tuple)
    End Sub

    ''' <summary>
    ''' Set all dynamic buttons to have the same WhichEntryStyle as this panel.
    ''' </summary>
    Private Sub setWhichEntryStyleButtons()
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            m_dynamic_buttons(i).WhichEntryStyle = m_which_entry_style
        Next
    End Sub

    ''' <summary>
    ''' Handles the event request to insert a new entry into the database.
    ''' Checks the setting from the Habitat panel, if set to record habitat on every record, 
    ''' the current dictionary will be merged with the species dict, and the result will be inserted into the database.
    ''' </summary>
    Private Sub new_species_entry_handler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim s As frmSpeciesEvent = CType(sender, frmSpeciesEvent)
        m_dict = s.Dictionary
        'RaiseEvent DataChanged(Me, e)
    End Sub

    ''' <summary>
    ''' Tell the program to issue a pause video command
    ''' </summary>
    ''' <param name="sender">The DynamicSpeciesButton that was pressed</param>
    Private Sub signal_video_pause(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent SignalVideoPause(sender, e)
    End Sub

    ''' <summary>
    ''' Tell the program to issue a play video command
    ''' </summary>
    ''' <param name="sender">The DynamicSpeciesButton that was pressed</param>
    Private Sub signal_video_play(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent SignalVideoPlay(sender, e)
    End Sub

    ''' <summary>
    ''' If a DynamicSpeciesButton is pressed, this will send that DynamicSpeciesButton object as an argument to the event
    ''' </summary>
    ''' <param name="sender">The DynamicSpeciesButton that was pressed</param>
    Private Sub button_CheckForDirtyDataEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent CheckForDirtyDataEvent(sender, e)
    End Sub

    ''' <summary>
    ''' The dynamic button with the text 'strSpecies' will be clicked programmatically.
    ''' This is so that when keyboard shortcuts are used in the main Videominer form,
    ''' the correct button will be clicked causing the cascading events which lead to
    ''' correct entry into the database
    ''' </summary>
    ''' <param name="strSpecies"></param>
    Public Sub ClickButton(strSpecies As String)
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            If m_dynamic_buttons(i).Text = strSpecies Then
                m_dynamic_buttons(i).PerformClick()
            End If
        Next
    End Sub
End Class
