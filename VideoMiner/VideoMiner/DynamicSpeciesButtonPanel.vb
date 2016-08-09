Imports System.Text.RegularExpressions
''' <summary>
''' A panel which supports loading of dynamic species buttons.
''' </summary>
''' <remarks></remarks>
Public Class DynamicSpeciesButtonPanel
    Inherits Panel

    Private Const NUM_ROWS As Integer = 8
    Private Const NUM_COLS As Integer = 6
#Region "Member variables"
    Private m_rare_species_lookup As Button
    Private m_edit_species_buttons As Button
    Private m_quick_entry As RadioButton
    Private m_detailed_entry As RadioButton
    Private m_abundance_entry As RadioButton
    Private m_quick_entry_label As Label
    Private WithEvents m_quick_entry_textbox As TextBox
    ''' <summary>
    ''' Necessary to hold the static controls in a 2 row by 3-column grid
    ''' </summary>
    Private m_static_button_panel As TableLayoutPanel
    ''' <summary>
    ''' Holds the three radio button choices in a 1-row, 3-col panel
    ''' This panel will stretch across the three columns in the first row of the static panel.
    ''' </summary>
    Private m_radio_panel As TableLayoutPanel
    ''' <summary>
    ''' Holds the two buttons Rare Species and Edit species in a 1-row, 2-col panel
    ''' This panel will stretch across the first two columns in the second row of the 
    ''' static panel
    ''' </summary>
    Private m_two_button_panel As TableLayoutPanel
    ''' <summary>
    ''' Holds the quick entry label and textbox in a 2-row, 1-col panel
    ''' This panel will be placed in the bottommost, rightmost cell of the static panel.
    ''' </summary>
    Private m_quick_entry_txt_panel As TableLayoutPanel
    ''' <summary>
    ''' Holds the dynamic buttons in a table layout panel. The number of rows will depend
    ''' on how many buttons are defined by the user.
    ''' </summary>
    Private m_dynamic_button_panel As TableLayoutPanel
    ''' <summary>
    ''' A two-row, one-column table layout panel which holds the m_static_button_panel on top
    ''' and the m_dynamic_button_panel on the bottom.
    ''' </summary>
    Private m_main_panel As TableLayoutPanel

    Private m_button_width As Integer
    Private m_button_height As Integer
    Private m_button_font As String
    ''' <summary>
    ''' The number of dynamic buttons currently on the panel
    ''' </summary>
    Private m_num_dynamic_buttons As Integer
    ''' <summary>
    ''' Array of Dynamic buttons. This will be redimensioned at runtime
    ''' </summary>
    Private m_dynamic_buttons As DynamicButton()
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
    Private m_which_entry_style As DynamicButton.WhichEntryStyleEnum
    ''' <summary>
    ''' The number to use for a quick species entry
    ''' </summary>
    Private m_quick_entry_num As Integer
#End Region

#Region "Events"
    Public Event RareSpeciesButtonPressed()
    Public Event EditSpeciesButtonPressed()
    ''' <summary>
    ''' Signals the parent that a button has been pressed on this panel and data entry has started.
    ''' </summary>
    Public Event StartDataEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Signals the parent that data entry has ended.
    ''' </summary>
    Public Event EndDataEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Fires when user presses Cancel or 'X' button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event DataEntryCanceled(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Fire event to have parent form check for dirty data or anything else prior to launching the button code.
    ''' </summary>
    Public Event CheckForDirtyDataEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Public Property WhichEntryStyle As DynamicButton.WhichEntryStyleEnum
        Get
            Return m_which_entry_style
        End Get
        Set(value As DynamicButton.WhichEntryStyleEnum)
            m_which_entry_style = value
            For i As Integer = 0 To m_num_dynamic_buttons - 1
                m_dynamic_buttons(i).WhichEntryStyle = value
            Next
        End Set
    End Property
#End Region

    ''' <summary>
    ''' Create the DynamicSpeciesButtonPanel object.
    ''' </summary>
    ''' <param name="strName">Name of the panel. Required for distinction between panels</param>
    ''' <param name="intButtonWidth">The width of all the buttons on the panel.</param>
    ''' <param name="intButtonHeight">The height of all the buttons on the panel.</param>
    ''' <param name="strButtonFont">The font for all the buttons on the panel.</param>
    Public Sub New(strname As String,
                   Optional intButtonWidth As Integer = 170,
                   Optional intButtonHeight As Integer = 44,
                   Optional strButtonFont As String = "Microsoft Sans Serif",
                   Optional whichEntryStyle As DynamicButton.WhichEntryStyleEnum = DynamicButton.WhichEntryStyleEnum.Detailed)
        m_rare_species_lookup = Nothing
        m_edit_species_buttons = Nothing
        m_quick_entry = Nothing
        m_detailed_entry = Nothing
        m_abundance_entry = Nothing
        m_quick_entry_label = Nothing
        m_quick_entry_textbox = Nothing

        Name = strname
        m_y_offset = 0
        m_gap = 2
        m_tuple = New Tuple(Of String, String, Boolean)(Nothing, Nothing, False)
        m_dict = New Dictionary(Of String, Tuple(Of String, String, Boolean))

        m_button_height = intButtonHeight
        m_button_width = intButtonWidth
        m_button_font = strButtonFont

        m_which_entry_style = whichEntryStyle
        m_quick_entry_num = 1

        m_static_button_panel = New TableLayoutPanel()
        m_static_button_panel.ColumnCount = 3
        m_static_button_panel.RowCount = 2
        m_static_button_panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
        m_static_button_panel.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))

        m_radio_panel = New TableLayoutPanel()
        m_radio_panel.ColumnCount = 3
        m_radio_panel.RowCount = 1
        m_radio_panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))

        m_quick_entry = New RadioButton()
        m_quick_entry.Name = "radQuickEntry"
        m_quick_entry.Text = "Quick Entry"
        m_quick_entry.Checked = False
        m_quick_entry.TextAlign = ContentAlignment.MiddleLeft
        AddHandler m_quick_entry.CheckedChanged, AddressOf radQuickEntry_CheckedChanged
        m_quick_entry.Dock = DockStyle.Fill
        m_radio_panel.Controls.Add(m_quick_entry, 0, 0)

        m_detailed_entry = New RadioButton()
        m_detailed_entry.Name = "radDetailedEntry"
        m_detailed_entry.Text = "Detailed Entry"
        m_detailed_entry.Checked = True
        m_detailed_entry.TextAlign = ContentAlignment.MiddleLeft
        AddHandler m_detailed_entry.CheckedChanged, AddressOf radDetailedEntry_CheckedChanged
        m_detailed_entry.Dock = DockStyle.Fill
        m_radio_panel.Controls.Add(m_detailed_entry, 1, 0)

        m_abundance_entry = New RadioButton()
        m_abundance_entry.Name = "radAbundanceEntry"
        m_abundance_entry.Text = "Abundance Entry"
        m_abundance_entry.Checked = False
        m_abundance_entry.TextAlign = ContentAlignment.MiddleLeft
        AddHandler m_abundance_entry.CheckedChanged, AddressOf radAbundanceEntry_CheckedChanged
        m_abundance_entry.Dock = DockStyle.Fill
        m_radio_panel.Controls.Add(m_abundance_entry, 2, 0)
        m_radio_panel.Dock = DockStyle.Fill
        m_radio_panel.ColumnStyles.Clear()
        For i As Integer = 0 To m_radio_panel.ColumnCount - 1
            m_radio_panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 1 / m_radio_panel.ColumnCount))
        Next

        m_static_button_panel.Controls.Add(m_radio_panel, 0, 0)
        m_static_button_panel.SetColumnSpan(m_radio_panel, 2)

        m_two_button_panel = New TableLayoutPanel()
        m_two_button_panel.ColumnCount = 2
        m_two_button_panel.RowCount = 1
        m_two_button_panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))

        m_rare_species_lookup = New Button()
        m_rare_species_lookup.Name = "btnRareSpeciesLookup"
        m_rare_species_lookup.Text = "Rare Species Lookup"
        m_rare_species_lookup.TextAlign = ContentAlignment.MiddleCenter
        m_rare_species_lookup.ForeColor = Color.Blue
        m_rare_species_lookup.Font = New Font(m_button_font, CInt(DEFAULT_BUTTON_TEXT_SIZE), FontStyle.Bold)
        AddHandler m_rare_species_lookup.Click, AddressOf btnRareSpeciesLookup_Click
        m_rare_species_lookup.Dock = DockStyle.Fill
        m_two_button_panel.Controls.Add(m_rare_species_lookup, 0, 0)

        m_edit_species_buttons = New Button()
        m_edit_species_buttons.Name = "btnEditSpeciesButtons"
        m_edit_species_buttons.Text = "Edit Species Buttons"
        m_edit_species_buttons.TextAlign = ContentAlignment.MiddleCenter
        m_edit_species_buttons.ForeColor = Color.Blue
        m_edit_species_buttons.Font = New Font(m_button_font, CInt(DEFAULT_BUTTON_TEXT_SIZE), FontStyle.Bold)
        AddHandler m_edit_species_buttons.Click, AddressOf btnEditSpeciesButtons_Click
        m_edit_species_buttons.Dock = DockStyle.Fill
        m_two_button_panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
        m_two_button_panel.Controls.Add(m_edit_species_buttons, 1, 0)
        m_two_button_panel.Dock = DockStyle.Fill
        m_static_button_panel.Controls.Add(m_two_button_panel, 1, 0)
        m_static_button_panel.SetColumnSpan(m_two_button_panel, 2)

        m_quick_entry_txt_panel = New TableLayoutPanel()
        m_quick_entry_txt_panel.ColumnCount = 2
        m_quick_entry_txt_panel.RowCount = 1

        m_quick_entry_label = New Label()
        m_quick_entry_label.Name = "lblQuickEntry"
        m_quick_entry_label.Text = "Quick Entry Count"
        m_quick_entry_label.TextAlign = ContentAlignment.MiddleCenter
        m_quick_entry_label.Dock = DockStyle.Fill
        m_quick_entry_label.Visible = False
        m_quick_entry_txt_panel.Controls.Add(m_quick_entry_label, 0, 0)

        m_quick_entry_textbox = New TextBox()
        m_quick_entry_textbox.Name = "txtQuickEntry"
        m_quick_entry_textbox.Text = "1"
        m_quick_entry_textbox.Dock = DockStyle.Fill
        m_quick_entry_textbox.Anchor = AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom
        m_quick_entry_textbox.Visible = False
        AddHandler m_quick_entry_textbox.TextChanged, AddressOf m_quick_entry_textbox_TextChanged
        m_quick_entry_txt_panel.RowStyles.Clear()
        For i As Integer = 0 To m_radio_panel.ColumnCount - 1
            m_radio_panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 1 / m_quick_entry_txt_panel.ColumnCount))
        Next
        m_quick_entry_txt_panel.Controls.Add(m_quick_entry_textbox, 1, 0)
        m_static_button_panel.Controls.Add(m_quick_entry_txt_panel, 3, 1)

        m_static_button_panel.GrowStyle = TableLayoutPanelGrowStyle.AddRows
        m_static_button_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink
        m_static_button_panel.BorderStyle = BorderStyle.FixedSingle
        m_static_button_panel.Dock = DockStyle.Top

        m_static_button_panel.ColumnStyles.Clear()
        For i As Integer = 0 To m_static_button_panel.ColumnCount - 1
            Dim cs As ColumnStyle = New ColumnStyle(SizeType.Absolute, m_button_width)
            m_static_button_panel.ColumnStyles.Add(cs)
        Next
        m_static_button_panel.RowStyles.Clear()
        For i As Integer = 0 To m_static_button_panel.RowCount - 1
            Dim scale As Integer = 1
            If i = 1 Then scale = 1.3
            Dim rs As RowStyle = New RowStyle(SizeType.Absolute, m_button_height * scale)
            'Dim rs As RowStyle = New RowStyle(SizeType.Percent, 50.0F)
            m_static_button_panel.RowStyles.Add(rs)
        Next

        m_main_panel = New TableLayoutPanel()
        m_main_panel.GrowStyle = TableLayoutPanelGrowStyle.AddRows
        m_main_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink
        m_main_panel.Dock = DockStyle.Fill
        m_main_panel.Controls.Add(m_static_button_panel)
        Controls.Add(m_main_panel)

        BorderStyle = BorderStyle.Fixed3D
        Dock = DockStyle.Fill
        AutoScroll = True
        m_num_dynamic_buttons = 0
        m_static_button_panel.Visible = False
        m_main_panel.Visible = False

        'm_static_button_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset
        'm_quick_entry_txt_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset
        'm_radio_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset
        'm_two_button_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset
    End Sub

    ''' <summary>
    ''' Fills the panel with the buttons described in the MS Access table given by strTableName
    ''' </summary>
    ''' <param name="strTableName">Name of the button description table in the MS Access database</param>
    Public Sub fillPanel(strTableName As String)
        If Not IsNothing(m_static_button_panel) Then
            m_static_button_panel.Visible = True
        End If
        Dim strKey As String = Database.GetPrimaryKeyFieldName(strTableName)
        Dim d As DataTable = Database.GetDataTable("select * from " & strTableName & " order by " & strKey, strTableName)
        m_num_dynamic_buttons = d.Rows.Count
        ReDim Preserve m_dynamic_buttons(m_num_dynamic_buttons)
        Dim i As Integer = 0
        For Each r As DataRow In d.Rows
            m_dynamic_buttons(i) = New DynamicButton(r, m_button_height, m_button_width, m_which_entry_style, m_quick_entry_num)
            AddHandler m_dynamic_buttons(i).StartDataEntryEvent, AddressOf startDataEntryEventHandler
            AddHandler m_dynamic_buttons(i).EndDataEntryEvent, AddressOf endDataEntryEventHandler
            AddHandler m_dynamic_buttons(i).DataEntryCanceled, AddressOf dataEntryCanceledHandler
            i += 1
        Next
        placeControls()
    End Sub

    ''' <summary>
    ''' Place the controls in the panel in a grid fashion.
    ''' </summary>
    Private Sub placeControls()
        If m_num_dynamic_buttons = 0 Then Exit Sub
        Dim intCol, intRow As Integer
        If IsNothing(m_dynamic_button_panel) Then
            m_dynamic_button_panel = New TableLayoutPanel()
        End If
        intRow = 0
        intCol = 0

        m_dynamic_button_panel.ColumnCount = NUM_COLS
        m_dynamic_button_panel.RowCount = NUM_ROWS
        m_dynamic_button_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset
        m_dynamic_button_panel.Dock = DockStyle.Fill

        m_dynamic_button_panel.RowStyles.Clear()
        For i As Integer = 0 To m_dynamic_button_panel.RowCount - 1
            Dim rs As RowStyle = New RowStyle(SizeType.Absolute, m_dynamic_buttons(0).ControlHeight * 1.3)
            m_dynamic_button_panel.RowStyles.Add(rs)
        Next
        m_dynamic_button_panel.ColumnStyles.Clear()
        For i As Integer = 0 To m_dynamic_button_panel.ColumnCount - 1
            Dim cs As ColumnStyle = New ColumnStyle(SizeType.Percent, 1 / NUM_COLS)
            'Dim cs As ColumnStyle = New ColumnStyle(SizeType.Absolute, m_dynamic_buttons(0).ControlWidth)
            m_dynamic_button_panel.ColumnStyles.Add(cs)
        Next
        ' The next two calls are required so that the scrollbars will dissappear when the
        ' number of buttons on the panel is reduced below that necessary for scrollbars.
        m_dynamic_button_panel.AutoScroll = False
        m_dynamic_button_panel.AutoScroll = True

        intCol = 0
        intRow = 0
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            m_dynamic_buttons(i).Dock = DockStyle.Top
            m_dynamic_button_panel.Controls.Add(m_dynamic_buttons(i), intCol, intRow)
            intRow += 1
            If intRow > (m_dynamic_button_panel.RowCount - 1) Then
                intRow = 0
                intCol += 1
            End If
        Next

        m_main_panel.Controls.Add(m_dynamic_button_panel)
        Controls.Add(m_main_panel)
        m_main_panel.Visible = True
    End Sub

    ''' <summary>
    ''' Removes all dynamic controls (DynamicButton and DynamicTextbox controls) from the panel.
    ''' </summary>
    Public Sub removeAllDynamicControls()
        Do While m_dynamic_button_panel.Controls.Count > 0
            RemoveHandler m_dynamic_buttons(0).StartDataEntryEvent, AddressOf startDataEntryEventHandler
            RemoveHandler m_dynamic_buttons(0).EndDataEntryEvent, AddressOf endDataEntryEventHandler
            m_dynamic_button_panel.Controls.RemoveAt(0)
        Loop
        m_num_dynamic_buttons = 0
        If Not IsNothing(m_main_panel) Then
            m_main_panel.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Build the dictionary of key/value pairs.
    ''' </summary>
    ''' <param name="btn">The button to build the dictionary for.</param>
    Private Sub buildDictionary(btn As DynamicButton)
        m_dict.Clear()
        m_dict = btn.Dictionary
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
    ''' Tell the program to issue a pause video command
    ''' </summary>
    ''' <param name="sender">The DynamicSpeciesButton that was pressed</param>
    Private Sub startDataEntryEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent StartDataEntryEvent(Me, EventArgs.Empty)
        'RaiseEvent StartDataEntryEvent(sender, e)
    End Sub

    ''' <summary>
    ''' Tell the program to issue a play video command
    ''' </summary>
    ''' <param name="sender">The DynamicSpeciesButton that was pressed</param>
    Private Sub endDataEntryEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_dict = sender.Dictionary
        RaiseEvent EndDataEntryEvent(Me, EventArgs.Empty)
        'RaiseEvent EndDataEntryEvent(sender, e)
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

    ''' <summary>
    ''' Change the quick entry number for all DynamicButtons on this panel
    ''' </summary>
    Public Sub changeQuickEntryNum(strQuickEntryNum As String)
        Dim regex As New Regex("^\d+$")
        Dim match As Match = regex.Match(m_quick_entry_textbox.Text)
        If Not match.Success Then
            m_quick_entry_textbox.Text = "1"
            MessageBox.Show("Only numeric characters are permitted in the 'Quick Entry Count' textbox.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        m_quick_entry_num = CInt(strQuickEntryNum)
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            m_dynamic_buttons(i).QuickEntryNum = m_quick_entry_num
        Next
    End Sub

    ''' <summary>
    ''' Bubbles the DataEntrytCanceledEvent up so that video can be set to play again when the user decides to cancel data entry.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dataEntryCanceledHandler(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent DataEntryCanceled(Me, EventArgs.Empty)
    End Sub

    Private Sub radQuickEntry_CheckedChanged()
        If m_quick_entry.Checked = True Then
            m_quick_entry_label.Visible = True
            m_quick_entry_textbox.Visible = True
        Else
            m_quick_entry_label.Visible = False
            m_quick_entry_textbox.Visible = False
        End If
        WhichEntryStyle = DynamicButton.WhichEntryStyleEnum.Quick
    End Sub

    Private Sub radDetailedEntry_CheckedChanged(sender As Object, e As EventArgs)
        WhichEntryStyle = DynamicButton.WhichEntryStyleEnum.Detailed
    End Sub

    Private Sub radAbundanceEntry_CheckedChanged(sender As Object, e As EventArgs)
        WhichEntryStyle = DynamicButton.WhichEntryStyleEnum.Abundance
    End Sub

    Private Sub btnRareSpeciesLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent RareSpeciesButtonPressed()
    End Sub

    Private Sub btnEditSpeciesButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent EditSpeciesButtonPressed()
    End Sub

    ''' <summary>
    ''' When the user changes the quick entry value, set all species buttons to have that value.
    ''' </summary>
    Private Sub m_quick_entry_textbox_TextChanged(sender As Object, e As EventArgs)
        changeQuickEntryNum(m_quick_entry_textbox.Text)
    End Sub

End Class
