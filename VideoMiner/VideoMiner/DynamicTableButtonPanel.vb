﻿''' <summary>
''' A panel that holds dynamic buttons which load database table forms when pressed.
''' </summary>
''' <remarks></remarks>
Public Class DynamicTableButtonPanel
    Inherits Panel

#Region "Member variables"
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
    Private m_dynamic_buttons As DynamicTableButton()
    ''' <summary>
    ''' Lets the fillPanel functioin know at what vertical level to start placing dynamic buttons
    ''' </summary>
    Private m_y_offset As Integer
    ''' <summary>
    ''' Gap between dynamic buttons (and the other controls)
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
    ''' Data code used for table-based data. e.g. table lu_survey_mode is associated with data code 9 in the lu_data_codes table
    ''' </summary>
    ''' <remarks></remarks>
    Private m_data_code As Integer
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
    Public ReadOnly Property RepeatForEveryRecord As Boolean
        Get
            Return m_repeat_for_every_record.Checked
        End Get
    End Property
#End Region

#Region "Events"
    Public Event DataChanged(sender As System.Object, e As System.EventArgs)
    ''' <summary>
    ''' Signals the parent that a button has been pressed on this panel and data entry has started.
    ''' </summary>
    Public Event StartDataEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Signals the parent that data entry has ended.
    ''' </summary>
    Public Event EndDataEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Fire event to have parent form check for dirty data or anything else prior to launching the button code.
    ''' </summary>
    Public Event CheckForDirtyDataEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
#End Region

    ''' <summary>
    ''' Create the DynamicTableButtonPanel object.
    ''' </summary>
    ''' <param name="blIncludeDefineAllButton">True if you want to include a 'Define All' button.</param>
    ''' <param name="intButtonWidth">The width of all the buttons on the panel.</param>
    ''' <param name="intButtonHeight">The height of all the buttons on the panel.</param>
    ''' <param name="strButtonFont">The font for all the buttons on the panel.</param>
    ''' <param name="intButtonTextSize">The font size (pts) for all the buttons on the panel.</param>
    ''' <param name="blIncludeRepeatCheckbox">True if you want to include a 'Repeat for each record' Checkbox on the panel.</param>
    ''' <param name="blRepeatIsChecked">If True, the 'Repeat for each record' checkbox will be checked on creation.</param>
    ''' <param name="intRepeatWidth">Width of the 'Repeat for each record' checkbox.</param>
    ''' <param name="intRepeatHeight">Height of the 'Repeat for each record' checkbox.</param>
    Public Sub New(Optional blIncludeDefineAllButton As Boolean = True,
                   Optional intButtonWidth As Integer = 170,
                   Optional intButtonHeight As Integer = 44,
                   Optional strButtonFont As String = "Microsoft Sans Serif",
                   Optional intButtonTextSize As Integer = 8,
                   Optional blIncludeRepeatCheckbox As Boolean = False,
                   Optional blRepeatIsChecked As Boolean = True,
                   Optional intRepeatWidth As Integer = 210,
                   Optional intRepeatHeight As Integer = 17)

        m_repeat_for_every_record = Nothing
        m_define_all_button = Nothing
        m_y_offset = 0
        m_gap = 2
        m_tuple = New Tuple(Of String, String, Boolean)(Nothing, Nothing, False)
        m_dict = New Dictionary(Of String, Tuple(Of String, String, Boolean))

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
            m_define_all_button.Visible = False
            AddHandler m_define_all_button.Click, AddressOf DefineAll
            Controls.Add(m_define_all_button)
        Else
            m_define_all_button = Nothing
        End If
        If blIncludeRepeatCheckbox Then
            Controls.Add(m_repeat_for_every_record)
        End If
        BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        Dock = DockStyle.Fill
        AutoScroll = True
        m_num_dynamic_buttons = 0
    End Sub

    ''' <summary>
    ''' Fills the panel with the buttons described in the MS Access table given by strTableName
    ''' </summary>
    ''' <param name="strTableName">Name of the button description table in the MS Access database</param>
    Public Sub fillPanel(strTableName As String)
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
        Dim i As Integer = 0
        For Each r As DataRow In d.Rows
            m_dynamic_buttons(i) = New DynamicTableButton(r, m_button_height, m_button_width, DynamicTableButton.WhichTypeEnum.DataTable)
            AddHandler m_dynamic_buttons(i).StartDataEntryEvent, AddressOf startDataEntryEventHandler
            AddHandler m_dynamic_buttons(i).EndDataEntryEvent, AddressOf endDataEntryEventHandler
            'AddHandler m_dynamic_buttons(i).DataChanged, AddressOf PanelDataChanged
            'AddHandler m_dynamic_buttons(i).Click, AddressOf button_CheckForDirtyDataEvent
            i += 1
        Next
        placeControls()
    End Sub

    ''' <summary>
    ''' Place the controls in the panel in a grid fashion.
    ''' </summary>
    Private Sub placeControls()
        Dim intAdd As Integer = 0
        Dim intMultiply As Integer = 0
        Dim cellsizex As Integer = m_button_width + m_gap
        Dim cellsizey As Integer = m_button_height + m_gap
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            cellsizex = m_dynamic_buttons(i).ControlWidth + m_gap
            cellsizey = m_dynamic_buttons(i).ControlHeight + m_gap
            'cellsizey = (1.5 * m_dynamic_buttons(i).ControlHeight) + m_gap
            m_dynamic_buttons(i).Location = New System.Drawing.Point(m_gap + (cellsizex * intMultiply), m_y_offset + (cellsizey * (i - intAdd)))
            Me.Controls.Add(m_dynamic_buttons(i))
            If i Mod 5 = 4 Then
                intAdd += 5
                intMultiply += 1
            End If
        Next
    End Sub

    ''' <summary>
    ''' Removes all dynamic controls (DynamicButton and DynamicTextbox controls) from the panel.
    ''' </summary>
    Public Sub removeAllDynamicControls()
        Me.Controls.RemoveAt(0)
        If Not IsNothing(m_repeat_for_every_record) Then
            m_repeat_for_every_record.Visible = False
        End If
        If Not IsNothing(m_define_all_button) Then
            m_define_all_button.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Handles the case where the user changed a selection in a code table (frmTableView). This may result
    ''' in a query being run to insert data into the database. This also handles the case in which
    ''' the table is a "UserEntered" type such as the FOV button which asks the user for a value
    ''' </summary>
    ''' <param name="sender">The DynamicButton that raised the event</param>
    Private Sub PanelDataChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As DynamicTableButton = DirectCast(sender, DynamicTableButton)
        ' Find associated DynamicTextbox, so we can change the text to reflect the change
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            If btn.DataValue <> UNINITIALIZED_DATA_VALUE Then
                buildDictionary(btn)
                RaiseEvent DataChanged(Me, e)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Build the dictionary of key/value pairs. This will be one item if the checkbox is nothing or not checked
    ''' and all items if the checkbox is checked.
    ''' </summary>
    ''' <param name="btn">The button to build the dictionary for, unless the checkbox is checked in which case this is ignored.</param>
    Private Sub buildDictionary(btn As DynamicTableButton)
        m_dict.Clear()
        If IsNothing(m_repeat_for_every_record) Then
            ' One button's data
            m_dict.Add(btn.DataCodeName, m_tuple)
        ElseIf Not m_repeat_for_every_record.Checked Then
            ' One button's data
            If btn.DataValue <> UNINITIALIZED_DATA_VALUE Then
                m_tuple = New Tuple(Of String, String, Boolean)(btn.DataCode, btn.DataValue, True)
                m_dict.Add(btn.DataCodeName, m_tuple)
            End If
        Else
            ' All buttons data
            For i As Integer = 0 To m_num_dynamic_buttons - 1
                ' If the button has data selected...
                If m_dynamic_buttons(i).DataValue <> UNINITIALIZED_DATA_VALUE Then
                    m_tuple = New Tuple(Of String, String, Boolean)(m_dynamic_buttons(i).DataCode, m_dynamic_buttons(i).DataValue, btn.Name = m_dynamic_buttons(i).Name)
                    m_dict.Add(m_dynamic_buttons(i).DataCodeName, m_tuple)
                    ' Insert the comment if it exists for only the button which was pressed
                    If btn.Name = m_dynamic_buttons(i).Name Then
                        m_tuple = New Tuple(Of String, String, Boolean)(m_dynamic_buttons(i).DataComment, DoubleQuote(m_dynamic_buttons(i).DataComment), False)
                        If m_dict.ContainsKey("Comment") Then
                            m_dict.Remove("Comment")
                        End If
                        m_dict.Add("Comment", m_tuple)
                    End If
                End If
            Next
        End If
        'm_tuple = New Tuple(Of String, String, Boolean)(btn.DataCode, btn.DataValue, True)
        'm_dict.Add(btn.DataCodeName, m_tuple)
    End Sub

    ''' <summary>
    ''' Build the dictionary of key/value pairs for all values which have been set on this panel.
    ''' The 'repeat for every record' checkbox must exist and be checked for this to work.
    ''' Note that there will be no 'True' items because this call is made for a summary of the items, not for a single button press.
    ''' This sub should not be used to make a single record entry into the database or the DataCode field will be missing.
    ''' </summary>
    Public Sub buildDictionary()
        m_dict.Clear()
        ' If the checkbox is not present or it's unchecked, leave the dictionary blank
        If IsNothing(m_repeat_for_every_record) Then Exit Sub
        If Not m_repeat_for_every_record.Checked Then Exit Sub

        For i As Integer = 0 To m_num_dynamic_buttons - 1
            If m_dynamic_buttons(i).DataValue <> UNINITIALIZED_DATA_VALUE Then
                m_tuple = New Tuple(Of String, String, Boolean)(m_dynamic_buttons(i).DataCode, m_dynamic_buttons(i).DataValue, False)
                m_dict.Add(m_dynamic_buttons(i).DataCodeName, m_tuple)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Allow the 'Define All' button to be pressed
    ''' </summary>
    Public Sub EnableDefineAllButton()
        If Not IsNothing(m_define_all_button) Then
            m_define_all_button.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Do not allow the 'Define All' button to be pressed
    ''' </summary>
    Public Sub DisableDefineAllButton()
        If Not IsNothing(m_define_all_button) Then
            m_define_all_button.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' When user clicks the 'DEFINE ALL' button, it is the same as if they clicked all the dynamic buttons in sequence.
    ''' This is a convinience button. The windows are opened in reverse order so that they will be in the correct order
    ''' ' from top to bottom.
    ''' </summary>
    Private Sub DefineAll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = m_num_dynamic_buttons - 1 To 0 Step -1
            'm_dynamic_buttons(i).DataFormVisible = True
        Next
    End Sub

    ''' <summary>
    ''' Tell the program to issue a pause video command
    ''' </summary>
    ''' <param name="sender">The DynamicButton that was pressed</param>
    Private Sub signal_video_pause(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'RaiseEvent SignalVideoPause(sender, e)
    End Sub

    ''' <summary>
    ''' Tell the program to issue a play video command
    ''' </summary>
    ''' <param name="sender">The DynamicButton that was pressed</param>
    Private Sub signal_video_play(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'RaiseEvent SignalVideoPlay(sender, e)
    End Sub

    ''' <summary>
    ''' If a DynamicButton is pressed, this will send that DynamicButton object as an argument to the event
    ''' </summary>
    ''' <param name="sender">The DynamicButton that was pressed</param>
    Private Sub button_CheckForDirtyDataEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent CheckForDirtyDataEvent(sender, e)
    End Sub

    ''' <summary>
    ''' The dynamic button with the text 'str' will be clicked programmatically.
    ''' This is so that when keyboard shortcuts are used in the main Videominer form,
    ''' the correct button will be clicked causing the cascading events which lead to
    ''' correct entry into the database.
    ''' </summary>
    ''' <param name="str"></param>
    Public Sub ClickButton(str As String)
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            If m_dynamic_buttons(i).Text = str Then
                'm_dynamic_buttons(i).PerformClick()
            End If
        Next
    End Sub

    ''' <summary>
    ''' Tell the program to issue a pause video command
    ''' </summary>
    ''' <param name="sender">The DynamicSpeciesButton that was pressed</param>
    Private Sub startDataEntryEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent StartDataEntryEvent(sender, e)
    End Sub

    ''' <summary>
    ''' Tell the program to issue a play video command
    ''' </summary>
    ''' <param name="sender">The DynamicSpeciesButton that was pressed</param>
    Private Sub endDataEntryEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent EndDataEntryEvent(sender, e)
    End Sub

End Class
