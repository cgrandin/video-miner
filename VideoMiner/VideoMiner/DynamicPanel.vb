''' <summary>
''' A panel which supports loading of dynamic buttons and dynamic textboxes and may include a
''' 'DEFINE ALL' button which runs the Click events for each button in the panel in succession.
''' </summary>
''' <remarks></remarks>
Public Class DynamicPanel
    Inherits Panel

#Region "Member variables"
    ''' <summary>
    ''' Panel label, typically which kind of data are stored in panel buttons
    ''' </summary>
    Private m_label As Label
    ''' <summary>
    ''' If checked, the data will be recorded for every insert
    ''' </summary>
    ''' <remarks>This may or may not be shown in the panel</remarks>
    Private m_repeat_for_every_record As CheckBox
    ''' <summary>
    ''' The 'DEFINE ALL' button which simply opens all dynamic buttons on the panel up in succession,
    ''' allowing the user to define all attributes at once.
    ''' </summary>
    ''' <remarks>This may or may not be shown in the panel</remarks>
    Private m_define_all_button As Button
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
    Private m_dynamic_buttons As DynamicButton()
    ''' <summary>
    ''' Array of Dynamic textboxes. This will be redimensioned at runtime. This is the same length as the m_dynamic_buttons array
    ''' </summary>
    Private m_dynamic_textboxes As DynamicTextbox()
    ''' <summary>
    ''' Lets the fillPanel functioin know at what vertical level to start placing dynamic buttons
    ''' </summary>
    Private m_y_offset As Integer
    ''' <summary>
    ''' Gap between dynamic buttons (and the other controls)
    ''' </summary>
    Private m_gap As Integer
    ''' <summary>
    ''' The number of non-dynamic controls on the panel, i.e. label and repeat checkbox and DEFINE ALL button would make 3.
    ''' </summary>
    Private m_num_static_controls As Integer
    ''' <summary>
    ''' Distinguishes between the two types of data this panel can hold, DynamicButtons linked to database table
    ''' data (lookup tables stored as type DataTable) or singular data which are not a DataTable, and have a keyboard shortcut.
    ''' Typically the singular type is used for species code entry buttons.
    ''' </summary>
    Public Enum WhichTypeEnum
        DataTable
        Singular
    End Enum
    ''' <summary>
    ''' Holds the enumeration type for this instance
    ''' </summary>
    Private m_which_type As WhichTypeEnum
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
    ''' Data code used for table-based data. e.g. table lu_survey_mode is associated with data code 9 in the lu_data_codes table
    ''' </summary>
    ''' <remarks></remarks>
    Private m_data_code As Integer

#End Region

#Region "Properties"
    ''' <summary>
    ''' Enumeration type for this instance. See WhichTypeEnum for descriptions.
    ''' </summary>
    Public Property WhichType As WhichTypeEnum
        Get
            Return m_which_type
        End Get
        Set(value As WhichTypeEnum)
            m_which_type = value
        End Set
    End Property

    ''' Dictionary of key/value pairs that hold the currently selected data (most recently-pressed button's data) for this panel.
    ''' If the repeat checkbox is visible and checked, the dictionary will hold the key/value pairs for all buttons on the panel,
    ''' not just the most recently-pressed button's data.
    Public ReadOnly Property Dictionary As Dictionary(Of String, Tuple(Of String, String, Boolean))
        Get
            Return m_dict
        End Get
    End Property

    Public ReadOnly Property RepeatForEveryRecord As Boolean
        Get
            Return m_repeat_for_every_record.Checked
        End Get
    End Property
#End Region

#Region "Events"
    Public Event DataChanged(sender As System.Object, e As System.EventArgs)
    ''' <summary>
    ''' This event will propagate or bubble up the same event raised from within the DynamicButton class. It signals that the user wants to enter a new record in the database
    ''' for a species sighting.
    ''' </summary>
    Public Event NewSpeciesEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Signals the parent that a button has been pressed on this panel and we request that the video be paused while data entry takes place.
    ''' </summary>
    Public Event SignalVideoPause(ByVal sender As System.Object, ByVal e As System.EventArgs)

#End Region

    ''' <summary>
    ''' Create the DynamicPanel object.
    ''' </summary>
    ''' <param name="strPanelName">Name for the Panel.</param>
    ''' <param name="blIncludeDefineAllButton">True if you want to include a 'Define All' button.</param>
    ''' <param name="intButtonWidth">The width of all the buttons on the panel.</param>
    ''' <param name="intButtonHeight">The height of all the buttons on the panel.</param>
    ''' <param name="strButtonFont">The font for all the buttons on the panel.</param>
    ''' <param name="intButtonTextSize">The font size (pts) for all the buttons on the panel.</param>
    ''' <param name="blIncludeRepeatCheckbox">True if you want to include a 'Repeat for each record' Checkbox on the panel.</param>
    ''' <param name="blRepeatIsChecked">If True, the 'Repeat for each record' checkbox will be checked on creation.</param>
    ''' <param name="intRepeatWidth">Width of the 'Repeat for each record' checkbox.</param>
    ''' <param name="intRepeatHeight">Height of the 'Repeat for each record' checkbox.</param>
    Public Sub New(strPanelName As String, Optional blIncludeDefineAllButton As Boolean = True, Optional intButtonWidth As Integer = 170,
                   Optional intButtonHeight As Integer = 44, Optional strButtonFont As String = "Microsoft Sans Serif", Optional intButtonTextSize As Integer = 8,
                   Optional blIncludeRepeatCheckbox As Boolean = False, Optional blRepeatIsChecked As Boolean = True, Optional intRepeatWidth As Integer = 210,
                   Optional intRepeatHeight As Integer = 17)

        Name = strPanelName

        m_label = Nothing
        m_repeat_for_every_record = Nothing
        m_define_all_button = Nothing
        m_y_offset = 0
        m_gap = 2
        m_tuple = New Tuple(Of String, String, Boolean)(Nothing, Nothing, False)
        m_dict = New Dictionary(Of String, Tuple(Of String, String, Boolean))

        'Panel label load`
        m_label = New Label()
        m_label.Name = "lblPanel"
        m_label.Text = strPanelName
        m_label.TextAlign = ContentAlignment.TopLeft
        m_label.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        m_label.Left = 3
        m_label.Top = 3
        m_y_offset = m_label.Bottom + m_gap
        m_num_static_controls = 1

        ' Load button constructs into member variables
        m_button_height = intButtonHeight
        m_button_width = intButtonWidth
        m_button_font = strButtonFont
        m_button_text_size = intButtonTextSize

        If blIncludeRepeatCheckbox Then
            m_repeat_for_every_record = New CheckBox()
            m_repeat_for_every_record.Name = "chkRepeat"
            m_repeat_for_every_record.Text = "Repeat data for every record"
            m_repeat_for_every_record.Checked = blRepeatIsChecked
            m_repeat_for_every_record.TextAlign = ContentAlignment.MiddleLeft
            m_repeat_for_every_record.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            m_repeat_for_every_record.Width = intRepeatWidth
            m_repeat_for_every_record.Height = intRepeatHeight
            m_repeat_for_every_record.ThreeState = False
            m_repeat_for_every_record.Left = 6
            m_repeat_for_every_record.Top = 19
            m_y_offset = m_repeat_for_every_record.Bottom + m_gap
            m_repeat_for_every_record.Visible = False
            m_num_static_controls += 1
        Else
            m_repeat_for_every_record = Nothing
        End If
        If blIncludeDefineAllButton Then
            m_define_all_button = New Button()
            m_define_all_button.Name = "btnDefineAll"
            m_define_all_button.Text = "Define All"
            m_define_all_button.TextAlign = ContentAlignment.MiddleCenter
            m_define_all_button.ForeColor = Color.Blue
            m_define_all_button.Font = New Font(m_button_font, m_button_text_size, FontStyle.Bold)
            m_define_all_button.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            m_define_all_button.Width = m_button_width
            m_define_all_button.Height = m_button_height
            m_define_all_button.Left = 6
            If blIncludeRepeatCheckbox Then
                m_define_all_button.Top = 36
            Else
                m_define_all_button.Top = 19
            End If
            m_y_offset = m_define_all_button.Bottom + m_gap
            m_num_static_controls += 1
            m_define_all_button.Visible = False
            AddHandler m_define_all_button.Click, AddressOf DefineAll
            Me.Controls.Add(m_define_all_button)
        Else
            m_define_all_button = Nothing
        End If
        If blIncludeRepeatCheckbox Then
            Me.Controls.Add(m_repeat_for_every_record)
        End If

        Me.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        Me.Dock = DockStyle.Fill
        Me.Controls.Add(m_label)

        Me.AutoScroll = True
        m_num_dynamic_buttons = 0

    End Sub

    ''' <summary>
    ''' Destructor. Dispose of dynamic arrays of DynamicButtons and Textboxes correctly
    ''' </summary>
    Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not IsDisposed Then
            If disposing Then

            End If
        End If
    End Sub

    ''' <summary>
    ''' Fills the panel with the buttons described in the MS Access table given by strTableName
    ''' </summary>
    ''' <param name="strTableName">Name of the button description table in the MS Access database</param>
    Public Sub fillPanel(strTableName As String)
        ' If any dynamic buttons are currently loaded, remove them all
        removeAllDynamicControls()

        If Not IsNothing(m_repeat_for_every_record) Then
            m_repeat_for_every_record.Visible = True
        End If
        If Not IsNothing(m_define_all_button) Then
            m_define_all_button.Visible = True
        End If

        Dim d As DataTable = Database.GetDataTable("select * from " & strTableName & " order by DrawingOrder;", strTableName)
        m_num_dynamic_buttons = d.Rows.Count
        ReDim m_dynamic_buttons(m_num_dynamic_buttons)
        If WhichType = WhichTypeEnum.DataTable Then
            ReDim m_dynamic_textboxes(m_num_dynamic_buttons)
        End If
        Dim i As Integer = 0

        ' TODO: There should be a better way than using a 7 here. Maybe another field in the database telling the class what it is.
        If d.Columns.Count = 7 Then
            Me.WhichType = WhichTypeEnum.Singular
        Else
            Me.WhichType = WhichTypeEnum.DataTable
        End If
        For Each r As DataRow In d.Rows
            If WhichType = WhichTypeEnum.Singular Then
                ' It's a singular-data button
                m_dynamic_buttons(i) = New DynamicButton(r.Item(0),
                                                         r.Item(1).ToString(),
                                                         r.Item(2).ToString(),
                                                         r.Item(3).ToString(),
                                                         r.Item(4),
                                                         r.Item(5).ToString(),
                                                         r.Item(6).ToString(),
                                                         m_button_font,
                                                         m_button_text_size)
                ' Adds a handler for each button for the event which is fired originally by the SpeciesEvent form, and bubbled through the DynamicButton class.
                AddHandler m_dynamic_buttons(i).NewSpeciesEntryEvent, AddressOf new_species_entry_handler
                AddHandler m_dynamic_buttons(i).SignalVideoPause, AddressOf signal_video_pause
            Else
                ' It's a table-data button
                m_dynamic_buttons(i) = New DynamicButton(r.Item(0),
                                                         r.Item(1).ToString(),
                                                         r.Item(2).ToString(),
                                                         r.Item(3),
                                                         r.Item(4).ToString(),
                                                         r.Item(5).ToString(),
                                                         m_button_font,
                                                         m_button_text_size)
                m_dynamic_textboxes(i) = New DynamicTextbox(r.Item(0), r.Item(1).ToString(), m_button_font, m_button_text_size)
            End If
            AddHandler m_dynamic_buttons(i).DataChanged, AddressOf PanelDataChanged
            AddHandler m_dynamic_buttons(i).SignalVideoPause, AddressOf signal_video_pause
            i += 1
        Next
        placeControls()
    End Sub

    ''' <summary>
    ''' Place the controls in the panel in a grid fashion. The two different enumeration types require two different algorithms,
    ''' because one includes textboxes and one doesn't
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
        If WhichType = WhichTypeEnum.Singular Then
            For i As Integer = 0 To m_num_dynamic_buttons - 1
                m_dynamic_buttons(i).Size = New Size(sizex, sizey)
                m_dynamic_buttons(i).Location = New System.Drawing.Point(m_gap + (cellsizex * (i - intAdd)), m_y_offset + (cellsizey * intMultiply))
                Me.Controls.Add(m_dynamic_buttons(i))
                If i Mod intCountPerRow = intCountPerRow - 1 Then
                    intAdd += intCountPerRow
                    intMultiply += 1
                End If
            Next
        ElseIf WhichType = WhichTypeEnum.DataTable Then
            For i As Integer = 0 To m_num_dynamic_buttons - 1
                m_dynamic_buttons(i).Size = New Size(sizex, sizey)
                m_dynamic_textboxes(i).Size = New Size(sizex, sizey / 2)
                cellsizex = sizex + m_gap
                cellsizey = (1.5 * sizey) + m_gap
                m_dynamic_buttons(i).Location = New System.Drawing.Point(m_gap + (cellsizex * intMultiply), m_y_offset + (cellsizey * (i - intAdd)))
                m_dynamic_textboxes(i).Location = New System.Drawing.Point(m_gap + (cellsizex * intMultiply), (cellsizey * (i - intAdd)) + (sizey + m_y_offset + m_gap))
                Me.Controls.Add(m_dynamic_buttons(i))
                Me.Controls.Add(m_dynamic_textboxes(i))
                If i Mod 5 = 4 Then
                    intAdd += 5
                    intMultiply += 1
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' Removes all dynamic controls (DynamicButton and DynamicTextbox controls) from the panel.
    ''' </summary>
    Public Sub removeAllDynamicControls()
        Do While Me.Controls.Count > m_num_static_controls
            Me.Controls.RemoveAt(m_num_static_controls)
        Loop
        If Not IsNothing(m_repeat_for_every_record) Then
            m_repeat_for_every_record.Visible = False
        End If
        If Not IsNothing(m_define_all_button) Then
            m_define_all_button.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Handles the case where the user changed a selection in a code table. This may result
    ''' in a query being run to insert data into the database. This also handles the case in which
    ''' the table is a "UserEntered" type such as the FOV button which asks the user for a value
    ''' </summary>
    ''' <param name="sender">The DynamicButton that raised the event</param>
    Private Sub PanelDataChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As DynamicButton = DirectCast(sender, DynamicButton)
        ' Find associated DynamicTextbox, so we can change the text to reflect the change
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            If m_dynamic_textboxes(i).ControlCode = btn.ControlCode Then
                If btn.DataValue = DynamicButton.UNINITIALIZED_DATA_VALUE Then
                    ' The data have been cleared, so change the textbox to reflect this
                    m_dynamic_textboxes(i).setNoData()
                Else
                    m_dynamic_textboxes(i).setData(btn.DataDescription)
                    buildDictionary(btn)
                    RaiseEvent DataChanged(Me, e)
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Build the dictionary of key/value pairs. This will be one item if the checkbox is nothing or not checked
    ''' and all items if the checkbox is checked.
    ''' </summary>
    ''' <param name="btn">The button to build the dictionary for, unless the checkbox is checked in which case this is ignored.</param>
    Private Sub buildDictionary(btn As DynamicButton)
        ' Clear the dictionary from the previous time if necessary
        m_dict.Clear()
        If IsNothing(m_repeat_for_every_record) Then
            ' One button's data
            m_tuple = New Tuple(Of String, String, Boolean)(btn.DataCode, btn.DataValue, True)
            m_dict.Add(btn.DataCodeName, m_tuple)
        ElseIf Not m_repeat_for_every_record.Checked Then
            ' One button's data
            If btn.DataValue <> DynamicButton.UNINITIALIZED_DATA_VALUE Then
                m_tuple = New Tuple(Of String, String, Boolean)(btn.DataCode, btn.DataValue, True)
                m_dict.Add(btn.DataCodeName, m_tuple)
            End If
        Else
            ' All button's data
            For i As Integer = 0 To m_num_dynamic_buttons - 1
                ' If the button has data selected...
                If m_dynamic_buttons(i).DataValue <> DynamicButton.UNINITIALIZED_DATA_VALUE Then
                    m_tuple = New Tuple(Of String, String, Boolean)(m_dynamic_buttons(i).DataCode, m_dynamic_buttons(i).DataValue, btn.Name = m_dynamic_buttons(i).Name)
                    m_dict.Add(m_dynamic_buttons(i).DataCodeName, m_tuple)
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' When user clicks the 'DEFINE ALL' button, it is the same as if they clicked all the dynamic buttons in sequence.
    ''' This is a convinience button.
    ''' </summary>
    Private Sub DefineAll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            m_dynamic_buttons(i).DataFormVisible = True
        Next
    End Sub

    ''' <summary>
    ''' Handles the event request to insert a new entry into the database. Checks the setting from the Habitat panel, if set to record habitat on every record, 
    ''' the current dictionary will be merged with the species dict, and the result will be inserted into the database.
    ''' </summary>
    Private Sub new_species_entry_handler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim s As frmSpeciesEvent = CType(sender, frmSpeciesEvent)
        m_dict = s.Dictionary
        RaiseEvent DataChanged(Me, e)
    End Sub

    Private Sub signal_video_pause(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent SignalVideoPause(sender, e)
    End Sub
End Class
