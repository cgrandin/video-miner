''' <summary>
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
    Private m_disable_buttons_button As Button
    ''' <summary>
    ''' Necessary to hold the two buttons m_disable_buttons_button and m_define_all_button,
    ''' and m_repeat_for_every_record in a 2x2 grid.
    ''' </summary>
    Private m_static_button_panel As TableLayoutPanel
    ''' <summary>
    ''' Holds the dynamic buttons in a 2-column table layout panel. The number of rows will depend
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
    Public ReadOnly Property RepeatForEveryRecord As Boolean
        Get
            Return m_repeat_for_every_record.Checked
        End Get
    End Property
#End Region

    ''' <summary>
    ''' Create the DynamicTableButtonPanel object.
    ''' </summary>
    ''' <param name="strName">Name of the panel. Required for distinction between panels</param>
    ''' <param name="blIncludeDefineAllButton">True if you want to include a 'Define All' button.</param>
    ''' <param name="intButtonWidth">The width of all the buttons on the panel.</param>
    ''' <param name="intButtonHeight">The height of all the buttons on the panel.</param>
    ''' <param name="strButtonFont">The font for all the buttons on the panel.</param>
    ''' <param name="blIncludeRepeatCheckbox">True if you want to include a 'Repeat for each record' Checkbox on the panel.</param>
    ''' <param name="blRepeatIsChecked">If True, the 'Repeat for each record' checkbox will be checked on creation.</param>
    ''' <param name="intRepeatWidth">Width of the 'Repeat for each record' checkbox.</param>
    ''' <param name="intRepeatHeight">Height of the 'Repeat for each record' checkbox.</param>
    Public Sub New(strname As String,
                   Optional blIncludeDefineAllButton As Boolean = True,
                   Optional intButtonWidth As Integer = 170,
                   Optional intButtonHeight As Integer = 44,
                   Optional strButtonFont As String = DEFAULT_BUTTON_FONT,
                   Optional strButtonTextSize As String = DEFAULT_BUTTON_TEXT_SIZE,
                   Optional blIncludeRepeatCheckbox As Boolean = False,
                   Optional blRepeatIsChecked As Boolean = True,
                   Optional intRepeatWidth As Integer = 210,
                   Optional intRepeatHeight As Integer = 17)
        Name = strname
        m_repeat_for_every_record = Nothing
        m_define_all_button = Nothing
        m_disable_buttons_button = Nothing
        m_y_offset = 0
        m_gap = 1
        m_tuple = New Tuple(Of String, String, Boolean)(Nothing, Nothing, False)
        m_dict = New Dictionary(Of String, Tuple(Of String, String, Boolean))

        ' Load button constructs into member variables
        m_button_height = intButtonHeight
        m_button_width = intButtonWidth
        m_button_font = strButtonFont
        m_button_text_size = CInt(strButtonTextSize)

        m_static_button_panel = New TableLayoutPanel()
        m_static_button_panel.ColumnCount = 2
        m_static_button_panel.RowCount = 2

        If blIncludeRepeatCheckbox Then
            m_static_button_panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
            m_repeat_for_every_record = New CheckBox()
            m_repeat_for_every_record.Name = "chkRepeat"
            m_repeat_for_every_record.Text = "Repeat data for every record"
            m_repeat_for_every_record.Checked = blRepeatIsChecked
            m_repeat_for_every_record.TextAlign = ContentAlignment.MiddleLeft
            m_repeat_for_every_record.ThreeState = False
            AddHandler m_repeat_for_every_record.CheckedChanged, AddressOf repeatForEveryRecordHandler
            m_repeat_for_every_record.Dock = DockStyle.Fill
            m_static_button_panel.Controls.Add(m_repeat_for_every_record, 0, 0)
            ' Force the checkbox to take up both columns in the first row
            m_static_button_panel.SetCellPosition(m_repeat_for_every_record, New TableLayoutPanelCellPosition(0, 0))
            m_static_button_panel.SetColumnSpan(m_repeat_for_every_record, 2)
        End If
        If blIncludeDefineAllButton Then
            m_static_button_panel.RowStyles.Add(New RowStyle(SizeType.Percent, 50))
            m_define_all_button = New Button()
            m_define_all_button.Name = "btnDefineAll"
            m_define_all_button.Text = "Define All"
            m_define_all_button.TextAlign = ContentAlignment.MiddleCenter
            m_define_all_button.ForeColor = Color.Blue
            m_define_all_button.Font = New Font(m_button_font, m_button_text_size, FontStyle.Bold)
            AddHandler m_define_all_button.Click, AddressOf DefineAll
            m_define_all_button.Dock = DockStyle.Fill
            If blIncludeRepeatCheckbox Then
                m_static_button_panel.Controls.Add(m_define_all_button, 0, 1)
            Else
                m_static_button_panel.Controls.Add(m_define_all_button, 0, 0)
            End If
        End If
        ' Add a disable buttons button
        m_disable_buttons_button = New Button()
        m_disable_buttons_button.Name = "btnDisableButtons"
        m_disable_buttons_button.Text = "Disable Buttons"
        m_disable_buttons_button.TextAlign = ContentAlignment.MiddleCenter
        m_disable_buttons_button.ForeColor = Color.Blue
        m_disable_buttons_button.Font = New Font(m_button_font, m_button_text_size, FontStyle.Bold)
        AddHandler m_disable_buttons_button.Click, AddressOf DisableEnableButtons
        m_disable_buttons_button.Dock = DockStyle.Fill
        If blIncludeRepeatCheckbox Then
            If blIncludeDefineAllButton Then
                m_static_button_panel.Controls.Add(m_disable_buttons_button, 1, 1)
            Else
                m_static_button_panel.Controls.Add(m_disable_buttons_button, 0, 1)
            End If
        Else
            If blIncludeDefineAllButton Then
                m_static_button_panel.Controls.Add(m_disable_buttons_button, 1, 0)
            Else
                m_static_button_panel.Controls.Add(m_disable_buttons_button, 0, 0)
            End If
        End If
        m_static_button_panel.GrowStyle = TableLayoutPanelGrowStyle.AddRows
        m_static_button_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink
        m_static_button_panel.BorderStyle = BorderStyle.Fixed3D

        m_main_panel = New TableLayoutPanel()
        m_main_panel.GrowStyle = TableLayoutPanelGrowStyle.AddRows
        m_main_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink
        m_main_panel.BorderStyle = BorderStyle.Fixed3D
        m_static_button_panel.Dock = DockStyle.Top
        m_static_button_panel.RowStyles.Add(New RowStyle(SizeType.Percent, 70))
        m_static_button_panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))

        m_main_panel.Controls.Add(m_static_button_panel)
        Controls.Add(m_main_panel)
        m_y_offset = m_static_button_panel.Bottom + m_gap

        BorderStyle = BorderStyle.Fixed3D
        Dock = DockStyle.Fill
        AutoScroll = True
        m_num_dynamic_buttons = 0
        m_static_button_panel.Visible = False
        m_main_panel.Visible = False
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
        ReDim m_dynamic_buttons(m_num_dynamic_buttons)
        Dim i As Integer = 0
        For Each r As DataRow In d.Rows
            m_dynamic_buttons(i) = New DynamicTableButton(r, m_button_height, m_button_width, DynamicTableButton.WhichTypeEnum.DataTable)
            AddHandler m_dynamic_buttons(i).StartDataEntryEvent, AddressOf startDataEntryEventHandler
            AddHandler m_dynamic_buttons(i).EndDataEntryEvent, AddressOf endDataEntryEventHandler
            AddHandler m_dynamic_buttons(i).DataEntryCanceled, AddressOf dataEntryCanceledHandler
            i += 1
        Next
        placeControls()
    End Sub

    ''' <summary>
    ''' Returns the number of rows that should be used given the number of dynamic buttons
    ''' that must be placed.
    ''' </summary>
    Private Function getRowCount() As Integer
        If m_num_dynamic_buttons < 5 Then
            Return m_num_dynamic_buttons
        Else
            If m_num_dynamic_buttons Mod 2 = 0 Then
                Return (m_num_dynamic_buttons \ 2)
            Else
                Return (m_num_dynamic_buttons \ 2) + 1
            End If
        End If
    End Function

    ''' <summary>
    ''' Place the controls in the panel in a grid fashion.
    ''' </summary>
    Private Sub placeControls()
        If m_num_dynamic_buttons = 0 Then Exit Sub
        Dim intCol, intRow As Integer
        m_button_height = m_disable_buttons_button.Height * 2
        m_button_width = m_disable_buttons_button.Width
        If IsNothing(m_dynamic_button_panel) Then
            m_dynamic_button_panel = New TableLayoutPanel()
            m_dynamic_button_panel.ColumnCount = 2
            m_dynamic_button_panel.RowCount = getRowCount()
        End If
        intRow = 0
        intCol = 0
        m_dynamic_button_panel.Controls.Clear()
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            m_dynamic_buttons(i).Width = m_button_width
            m_dynamic_buttons(i).Height = m_button_height
            m_dynamic_buttons(i).Dock = DockStyle.Top
            'm_dynamic_buttons(i).Anchor = AnchorStyles.Left And AnchorStyles.Right
            m_dynamic_button_panel.Controls.Add(m_dynamic_buttons(i), intCol, intRow)
            If i = m_dynamic_button_panel.RowCount - 1 Then
                intRow = 0
                intCol += 1
            Else
                intRow += 1
            End If
        Next
        m_dynamic_button_panel.Dock = DockStyle.Fill
        m_dynamic_button_panel.GrowStyle = TableLayoutPanelGrowStyle.AddRows
        m_dynamic_button_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink
        m_dynamic_button_panel.BorderStyle = BorderStyle.Fixed3D

        m_main_panel.Dock = DockStyle.Fill
        For i As Integer = 0 To m_dynamic_button_panel.RowCount - 1
            Dim rs As RowStyle = New RowStyle(SizeType.Absolute, m_button_height)
            m_dynamic_button_panel.RowStyles.Add(rs)
        Next
        m_main_panel.Controls.Add(m_dynamic_button_panel)

        'm_dynamic_button_panel.RowStyles.Add(New RowStyle(SizeType.Absolute, m_button_height * 2))
        'm_dynamic_button_panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50))
        'For Each rs As RowStyle In m_dynamic_button_panel.RowStyles
        '    rs.SizeType = SizeType.Absolute
        '    rs.Height = m_button_height * 2
        'Next


        Controls.Add(m_main_panel)
        '        m_dynamic_button_panel.Visible = True
        m_main_panel.Visible = True
    End Sub

    ''' <summary>
    ''' Change the size of the dynamic buttons to be the same as the ones in the m_static_buttons_panel
    ''' </summary>
    Private Sub OnRezise_Form() Handles Me.Resize
        placeControls()
    End Sub

    ''' <summary>
    ''' Removes all dynamic controls (DynamicButton and DynamicTextbox controls) from the panel.
    ''' </summary>
    Public Sub removeAllDynamicControls()
        Do While m_dynamic_button_panel.Controls.Count > 0
            m_dynamic_button_panel.Controls.RemoveAt(0)
        Loop
        If Not IsNothing(m_main_panel) Then
            m_main_panel.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Build the dictionary for this panel. If the 'repeat_for_every_record' is present and checked,
    ''' The dictionaries for each button will be merged into one dictionary so that all items
    ''' will appear in a entry of the database.
    ''' </summary>
    Public Sub buildDictionary(Optional btn As DynamicTableButton = Nothing)
        m_dict.Clear()
        If IsNothing(m_repeat_for_every_record) Then
            If Not IsNothing(btn) Then
                m_dict = btn.Dictionary
            End If
        ElseIf Not m_repeat_for_every_record.Checked Then
            If Not IsNothing(btn) Then
                m_dict = btn.Dictionary
            End If
        Else
            For i As Integer = 0 To m_num_dynamic_buttons - 1
                If Not IsNothing(m_dynamic_buttons(i).Dictionary) Then
                    Try
                        m_dict = m_dict.Union(m_dynamic_buttons(i).Dictionary).ToDictionary(Function(x) x.Key, Function(y) y.Value)
                    Catch ex As Exception
                        MessageBox.Show("Error - the button you pressed has a duplicate on the panel, and was already set. Delete duplicate buttons.",
                                        "Error - duplicate buttons",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error)
                    End Try
                End If
            Next
        End If
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
    ''' from top to bottom.
    ''' </summary>
    Private Sub DefineAll(sender As Object, e As EventArgs)
        For i As Integer = m_num_dynamic_buttons - 1 To 0 Step -1
            m_dynamic_buttons(i).DataFormVisible = True
        Next
    End Sub

    ''' <summary>
    ''' Disable or Enable everything on the panel
    ''' </summary>
    Private Sub DisableEnableButtons(sender As Object, e As EventArgs)
        m_repeat_for_every_record.Enabled = Not m_repeat_for_every_record.Enabled
        m_define_all_button.Enabled = Not m_define_all_button.Enabled
        'm_static_button_panel.Enabled = Not m_static_button_panel.Enabled
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            m_dynamic_buttons(i).Enabled = Not m_dynamic_buttons(i).Enabled
        Next
        If m_disable_buttons_button.Text = "Disable Buttons" Then
            m_disable_buttons_button.Text = "Enable Buttons"
        Else
            m_disable_buttons_button.Text = "Disable Buttons"
        End If
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
                ' TODO: fix this connection
                'm_dynamic_buttons(i).PerformClick()
            End If
        Next
    End Sub

    ''' <summary>
    ''' Tell parent that data entry has started
    ''' </summary>
    ''' <param name="sender">The DynamicTableButton that was pressed</param>
    Private Sub startDataEntryEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent StartDataEntryEvent(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Tell parent that data entry has ended
    ''' </summary>
    ''' <param name="sender">The DynamicTableButton that was pressed</param>
    Private Sub endDataEntryEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        buildDictionary(CType(sender, DynamicTableButton))
        RaiseEvent EndDataEntryEvent(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Handles the checking/unchecking of the repeat control. The dictionary will be built so that
    ''' it is in the correct formation if the main form requests it for data entry.
    ''' </summary>
    Private Sub repeatForEveryRecordHandler()
        buildDictionary()
    End Sub

    ''' <summary>
    ''' Bubbles the DataEntrytCanceledEvent up so that video can be set to play again when the user decides to cancel data entry.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dataEntryCanceledHandler(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent DataEntryCanceled(Me, EventArgs.Empty)
    End Sub

End Class
