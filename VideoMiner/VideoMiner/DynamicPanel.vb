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
    Public Sub New(strPanelName As String, Optional blIncludeDefineAllButton As Boolean = True, Optional intButtonWidth As Integer = 170, Optional intButtonHeight As Integer = 44,
                   Optional strButtonFont As String = "Microsoft Sans Serif", Optional intButtonTextSize As Integer = 8,
                   Optional blIncludeRepeatCheckbox As Boolean = False, Optional blRepeatIsChecked As Boolean = True, Optional intRepeatWidth As Integer = 210,
                   Optional intRepeatHeight As Integer = 17)

        m_label = Nothing
        m_repeat_for_every_record = Nothing
        m_define_all_button = Nothing
        m_y_offset = 0
        m_gap = 2

        'Panel label load
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
            AddHandler m_dynamic_buttons(i).SelectionChanged, AddressOf SelectionChanged
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
                'm_dynamic_buttons(i).Location = New System.Drawing.Point(m_gap + (cellsizex * intMultiply), m_y_offset + m_gap + (cellsizey * (i - intAdd)))
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
    ''' in a query being run to insert data into the database.
    ''' </summary>
    ''' <param name="sender">The DynamicButton that raised the event</param>
    Private Sub SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As DynamicButton = DirectCast(sender, DynamicButton)
        ' Find associated DynamicTextbox, so we can change the text to reflect the change
        For i As Integer = 0 To m_num_dynamic_buttons - 1
            If m_dynamic_textboxes(i).ControlCode = btn.ControlCode Then
                If btn.DataCodeName Is Nothing Then
                    ' The data have been cleared, so change the textbox to reflect this
                    m_dynamic_textboxes(i).setNoData()
                Else
                    m_dynamic_textboxes(i).setData(btn.DataCodeName)
                End If
            End If
        Next


        Dim query As String
        If btn.DataComment <> "" Then
            ' Insert a new record into the database
            'query = createInsertQuery(btn.Code, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
            'Database.ExecuteNonQuery(query)
            'fetch_data()
        End If
    End Sub

    ''' <summary>
    ''' When user clicks the 'DEFINE ALL' button, it is the same as if they clicked all the dynamic buttons in sequence.
    ''' This is a convinience button.
    ''' </summary>
    Private Sub DefineAll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each btn As DynamicButton In m_dynamic_buttons
            btn.DataFormVisible = True
        Next
    End Sub

End Class
