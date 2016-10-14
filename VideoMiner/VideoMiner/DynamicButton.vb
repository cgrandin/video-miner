''' <summary>
''' A Videominer dynamic button. This button extends a regular button by holding 
''' the database table name, an instance of the DataTable, the current data code,
''' and the code name.
''' </summary>
''' <remarks></remarks>
Public Class DynamicButton
    Inherits Button

#Region "Member variables"
    ''' <summary>
    ''' Name of the MS Access table associated with this button
    ''' </summary>
    Private m_table_name As String
    ''' <summary>
    ''' Table of data found in the m_db_table_name table in the MS Access database.
    ''' Used only if m_which_entry_style = Table.
    ''' </summary>
    Private m_data_table As DataTable
    ''' <summary>
    ''' An instance of the table view form of the m_db_data_table used if m_which_entry_style = Table
    ''' </summary>
    Private WithEvents m_frmTableView As frmTableView
    ''' <summary>
    ''' The instance of the species event form used if m_which_entry_style = Quick or Detailed.
    ''' </summary>
    Dim WithEvents m_frmSpeciesEvent As frmSpeciesEvent
    ''' <summary>
    ''' An instance of the abundance table view form used if m_which_entry_style = Abundance.
    ''' </summary>
    Private WithEvents m_frmAbundanceTableView As frmAbundanceTableView
    ''' <summary>
    ''' Drawing order number for this button
    ''' </summary>
    Private m_drawing_order As String
    ''' <summary>
    ''' Text for the button.
    ''' </summary>
    Private m_button_text As String
    ''' <summary>
    ''' Code for the button. This may not be set if the button type is for a data table.
    ''' </summary>
    Private m_button_code As String
    ''' <summary>
    ''' Name for the button code. This may not be set if the button type is for a data table.
    ''' </summary>
    Private m_button_code_name As String
    ''' <summary>
    ''' Data code as seen in the database table 'lu_data_codes'
    ''' </summary>
    Private m_data_code As String
    ''' <summary>
    ''' Data code name as seen in the database table 'data'
    ''' </summary>
    Private m_data_code_name As String
    ''' <summary>
    ''' Microsoft palette color to use for the button text (e.g. DarkOrchid)
    ''' </summary>
    Private m_button_color As String
    ''' <summary>
    ''' Font family, e.g. 'Arial'. If invalid, 'Microsoft Sans Serif' will be used
    ''' </summary>
    Private m_button_font As String
    ''' <summary>
    ''' Font size for the button text. If invalid, 10 will be used.
    ''' </summary>
    Private m_button_text_size As String
    ''' <summary>
    ''' A String representing a keyboard shortcut. This is what can be pressed to trigger a Click event on the button.
    ''' </summary>
    Private m_keyboard_shortcut As String
    ''' <summary>
    ''' Enumeration for which type of data entry this button represents.
    ''' Quick means that no frmSpeciesEvent will be opened, data entered upon buttonpress
    ''' Detailed opens a frmSpeciesEvent form for detailed entry
    ''' Abundance opens an abundance table for row selection by user.
    ''' Table opens a database table for row selection by user.
    ''' </summary>
    Public Enum WhichEntryStyleEnum
        Quick
        Detailed
        Abundance
        Table
    End Enum
    ''' <summary>
    ''' Holds the style of entry for species data
    ''' </summary>
    Private m_which_entry_style As WhichEntryStyleEnum
    ''' <summary>
    ''' The value of the chosen data from clicking the button and submitting the forms which appear.
    ''' It must be a string so that UNINITIALIZED_DATA_VALUE can be passed to the SQL query if it was not chosen to be part of the query.
    ''' </summary>
    Private m_data_value As String
    ''' <summary>
    ''' Currently entered comment
    ''' </summary>
    Private m_current_comment As String
    ''' <summary>
    ''' Dictionary of key/value pairs that hold the currently selected data.
    ''' The first parameter is the name of the field in the database table lu_data, the second is the tuple above.
    ''' </summary>
    Private m_dict As Dictionary(Of String, Tuple(Of String, String, Boolean))
    ''' <summary>
    ''' The number to use for a quick species entry
    ''' </summary>
    Private m_quick_entry_num As Integer
#End Region

#Region "Events"
    ''' <summary>
    ''' This event will be fired when the user clicks the button.
    ''' </summary>
    Public Event StartDataEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' This event will propagate an event sent by either m_frmSpeciesEvent, m_frmAbundanceTableView, or m_frmTableView.
    ''' It is sent to signal the end of the data entry, i.e. when the subforms mentioned are closed.
    ''' </summary>
    Public Event EndDataEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Fires when user presses Cancel or 'X' button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event DataEntryCanceled(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Fires when the frmTableView or frmAbundanceTableView is cleared via its clear button or a ctrl-click of this button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event ClearEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
#End Region

#Region "Properties"
    Public Property DataFormVisible As Boolean
        Set(value As Boolean)
            If Not IsNothing(m_frmTableView) Then
                m_frmTableView.Visible = True
            End If
        End Set
        Get
            If Not IsNothing(m_frmTableView) Then
                Return m_frmTableView.Visible
            End If
            Return False
        End Get
    End Property

    Public Property ButtonText As String
        Get
            Return m_button_text
        End Get
        Set(value As String)
            m_button_text = value
        End Set
    End Property
    Public Property ButtonCode As String
        Get
            Return m_button_code
        End Get
        Set(value As String)
            m_button_code = value
        End Set
    End Property
    Public Property ButtonFont As String
        Get
            Return m_button_font
        End Get
        Set(value As String)
            m_button_font = value
        End Set
    End Property
    Public Property ButtonTextSize As String
        Get
            Return m_button_text_size
        End Get
        Set(value As String)
            m_button_text_size = value
        End Set
    End Property

    ''' <summary>
    ''' Data code used for table-based data. e.g. table lu_survey_mode is associated with data code 9 in the lu_data_codes table
    ''' </summary>
    Public Property DataCode As String
        Get
            Return m_data_code
        End Get
        Set(value As String)
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
    Public Property DataComment As String
        Get
            Return m_current_comment
        End Get
        Set(value As String)
            m_current_comment = value
        End Set
    End Property
    Public ReadOnly Property DataDescription As String
        Get
            If m_table_name = USER_ENTERED Then
                Return m_button_text
            Else
                Return m_frmTableView.DataDescription
            End If
        End Get
    End Property

    Public Property Dictionary As Dictionary(Of String, Tuple(Of String, String, Boolean))
        Get
            Return m_dict
        End Get
        Set(value As Dictionary(Of String, Tuple(Of String, String, Boolean)))
            m_dict = value
        End Set
    End Property
    Public ReadOnly Property DictionaryHasItems As Boolean
        Get
            Return m_frmTableView.DictionaryHasItems
        End Get
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

    Public Property QuickEntryNum As Integer
        Get
            Return m_quick_entry_num
        End Get
        Set(value As Integer)
            m_quick_entry_num = value
        End Set
    End Property
    ''' <summary>
    ''' Width of the control
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ControlWidth As Integer
        Get
            Return ClientSize.Width
        End Get
    End Property
    ''' <summary>
    ''' Height of the control, including button and textbox
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ControlHeight As Integer
        Get
            Return ClientSize.Height
        End Get
    End Property

#End Region

    ''' <summary>
    ''' Creates a new dynamic button with the defaults supplied.
    ''' </summary>
    ''' <params row>A data row which holds a single row of data from a database 'button' table</params>
    ''' <remarks></remarks>
    Public Sub New(row As DataRow,
                   intHeight As Integer,
                   intWidth As Integer,
                   Optional whichEntryStyle As WhichEntryStyleEnum = WhichEntryStyleEnum.Detailed,
                   Optional intQuickEntryNum As Integer = 1)
        ' The Try/Catch blocks are used so that if any columns are missing, at least the ones that
        ' are present will be used. This allows for data tables of several formats to have their
        ' rows used to creatte a new DynamicButton.
        Try
            m_drawing_order = row.Item(DRAWING_ORDER).ToString()
        Catch ex As Exception
            m_drawing_order = UNINITIALIZED_DATA_VALUE
        End Try
        Try
            m_button_text = row.Item(BUTTON_TEXT).ToString()
        Catch ex As Exception
            m_button_text = UNINITIALIZED_DATA_VALUE
        End Try
        Try
            m_button_code = row.Item(BUTTON_CODE).ToString()
        Catch ex As Exception
            m_button_code = UNINITIALIZED_DATA_VALUE
        End Try
        Try
            m_button_code_name = row.Item(BUTTON_CODE_NAME).ToString()
        Catch ex As Exception
            m_button_code_name = UNINITIALIZED_DATA_VALUE
        End Try
        Try
            m_button_code_name = row.Item(BUTTON_CODE_NAME).ToString()
        Catch ex As Exception
            m_button_code_name = UNINITIALIZED_DATA_VALUE
        End Try
        Try
            m_data_code = row.Item(DATA_CODE_NAME).ToString()
        Catch ex As Exception
            m_data_code = UNINITIALIZED_DATA_VALUE
        End Try
        Try
            m_data_code_name = row.Item(DATA_CODE_NAME).ToString()
        Catch ex As Exception
            m_data_code_name = UNINITIALIZED_DATA_VALUE
        End Try
        Try
            m_button_color = row.Item(BUTTON_COLOR).ToString()
        Catch ex As Exception
            m_button_color = UNINITIALIZED_DATA_VALUE
        End Try
        Try
            m_button_font = row.Item(BUTTON_FONT).ToString()
        Catch ex As Exception
            m_button_font = DEFAULT_BUTTON_FONT
        End Try
        If m_button_font = String.Empty Then
            m_button_font = DEFAULT_BUTTON_FONT
        End If
        Try
            m_button_text_size = row.Item(BUTTON_TEXT_SIZE).ToString()
        Catch ex As Exception
            m_button_text_size = DEFAULT_BUTTON_TEXT_SIZE
        End Try
        If m_button_text_size = String.Empty Then
            m_button_text_size = DEFAULT_BUTTON_TEXT_SIZE
        End If
        Try
            m_keyboard_shortcut = row.Item(KEYBOARD_SHORTCUT).ToString()
        Catch ex As Exception
            m_keyboard_shortcut = UNINITIALIZED_DATA_VALUE
        End Try
        Try
            m_table_name = row(TABLE_NAME).ToString()
        Catch ex As Exception
            m_table_name = UNINITIALIZED_DATA_VALUE
        End Try
        m_which_entry_style = whichEntryStyle
        m_data_value = UNINITIALIZED_DATA_VALUE
        m_dict = Nothing

        m_quick_entry_num = intQuickEntryNum

        Me.Name = m_button_text
        Me.Text = m_button_text
        Me.Size = New Size(intWidth, intHeight)

        Dim colConvert As ColorConverter = New ColorConverter()
        Try
            Me.ForeColor = CType(colConvert.ConvertFromString(m_button_color), Color)
        Catch ex As Exception
            Me.ForeColor = Color.Black
        End Try
        Dim font_family As FontFamily
        Try
            font_family = New FontFamily(m_button_font)
        Catch ex As Exception
            font_family = New FontFamily(DEFAULT_BUTTON_FONT)
        End Try
        If font_family.IsStyleAvailable(FontStyle.Regular) Then
            Me.Font = New Font(font_family, Convert.ToSingle(m_button_text_size, Globalization.CultureInfo.InvariantCulture), FontStyle.Regular)
        ElseIf font_family.IsStyleAvailable(FontStyle.Bold) Then
            Me.Font = New Font(font_family, Convert.ToSingle(m_button_text_size, Globalization.CultureInfo.InvariantCulture), FontStyle.Bold)
        ElseIf font_family.IsStyleAvailable(FontStyle.Italic) Then
            Me.Font = New Font(font_family, Convert.ToSingle(m_button_text_size, Globalization.CultureInfo.InvariantCulture), FontStyle.Italic)
        End If

        If m_which_entry_style = WhichEntryStyleEnum.Table Then
            Try
                Dim d As DataTable
                If m_table_name = USER_ENTERED Then
                    ' In the database, the name 'UserEntered' is in place of the tablename, so we must ask user here for the code value
                    d = Database.GetDataTable("select * from " & DB_DATA_CODES_TABLE & " where Description = '" & m_button_text & "'", DB_DATA_CODES_TABLE)
                    m_data_code = d.Rows(0).Item(0).ToString()
                Else
                    m_data_table = Database.GetDataTable("select * from " & m_table_name & " order by 1", m_table_name)
                    d = Database.GetDataTable("select * from " & DB_DATA_CODES_TABLE & " where LookupTable = '" & m_table_name & "'", DB_DATA_CODES_TABLE)
                    m_data_code = d.Rows(0).Item(0).ToString()
                    ' Create new Table view form, but don't show it yet.
                    m_frmTableView = New frmTableView(Me.Text, m_data_table)
                    ' Set up the correct datacode for the form
                    m_frmTableView.DataCode = m_data_code
                    m_frmTableView.DataCodeName = m_data_code_name
                End If
                If d.Rows.Count > 1 Then
                    ' There may be more than one row which have the same lookup table. e.g. substrate or substrate percent tables will do this
                    ' so this tries to match the first 8 characters and use that one.
                    ' TODO: Fix this. It works for now, but if two descriptions start with the same 8 letters, there will be erroneous data
                    For i As Integer = 0 To d.Rows.Count - 1
                        If Strings.Left(m_data_code_name, 8) = Strings.Left(d.Rows(i).Item("Description").ToString(), 8) Then
                            m_data_code = d.Rows(i).Item(0).ToString()
                        End If
                    Next
                End If

            Catch ex As Exception
                MessageBox.Show("There was an error creating the button '" & m_button_text &
                                "'. Make sure to check all button tables in the database and make sure they contain valid rows. Also check the '" &
                                DB_DATA_CODES_TABLE & "' and make sure it contains a row with the name '" & m_button_text & "' in the Description column." &
                                vbCrLf & vbCrLf &
                                "Exception message:" & vbCrLf & ex.Message,
                                "Error loading button", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            m_frmAbundanceTableView = New frmAbundanceTableView()
            m_frmSpeciesEvent = New frmSpeciesEvent(m_button_text)
        End If
        AddHandler Me.Click, AddressOf ShowForm
    End Sub

    ''' <summary>
    ''' Show the correct form based on the WhichTypeEnum value.
    ''' </summary>
    Public Sub ShowForm(sender As Object, e As EventArgs)
        RaiseEvent StartDataEntryEvent(Me, e)
        If m_which_entry_style = WhichEntryStyleEnum.Detailed Then
            RecordDetailed()
        ElseIf m_which_entry_style = WhichEntryStyleEnum.Quick Then
            RecordQuick()
        ElseIf m_which_entry_style = WhichEntryStyleEnum.Abundance Then
            RecordAbundance()
        ElseIf m_which_entry_style = WhichEntryStyleEnum.Table Then
            If My.Computer.Keyboard.CtrlKeyDown Then
                If Not m_table_name = USER_ENTERED Then
                    m_frmTableView.clearData()
                End If
                Exit Sub
            End If
            RecordTable()
        End If
    End Sub

    ''' <summary>
    ''' Open the species event form to record a detailed species event.
    ''' </summary>
    Private Sub RecordDetailed()
        If Not IsNothing(m_frmSpeciesEvent) Then
            m_frmSpeciesEvent.Show()
        End If
    End Sub
    ''' <summary>
    ''' Record count value to the frmSpeciesEvent.
    ''' </summary>
    Public Sub RecordQuick()
        If Not IsNothing(m_frmSpeciesEvent) Then
            m_frmSpeciesEvent.Acknowledge(CType(m_quick_entry_num, String))
        End If
    End Sub

    ''' <summary>
    ''' Record an abundance only event.
    ''' </summary>
    Public Sub RecordAbundance()
        If Not IsNothing(m_frmAbundanceTableView) Then
            m_frmAbundanceTableView.Show()
        End If
    End Sub

    ''' <summary>
    ''' Record an data table row selection event.
    ''' </summary>
    Public Sub RecordTable()
        If Not IsNothing(m_frmTableView) Then
            ' It is a lookup-table based button
            m_frmTableView.Show()
        Else
            ' It is a UserEntered type of button
            userEnteredData()
        End If
    End Sub

    ''' <summary>
    ''' Launches an inputbox asking the user for the value (integer) for the desired variable.
    ''' </summary>
    Private Sub userEnteredData()
        Dim intInput As Integer
        Dim blValid As Boolean = False
        While Not blValid
            m_data_value = InputBox("Enter integer value for the selected variable", "Enter value...")
            If m_data_value = NULL_STRING Then
                Exit Sub
            End If
            blValid = Integer.TryParse(m_data_value, intInput)
        End While
        If IsNothing(m_dict) Then
            m_dict = New Dictionary(Of String, Tuple(Of String, String, Boolean))
        Else
            m_dict.Clear()
        End If
        Dim tuple As Tuple(Of String, String, Boolean) = New Tuple(Of String, String, Boolean)(m_data_code, m_data_value, True)
        m_dict.Add(m_data_code_name, tuple)
        RaiseEvent EndDataEntryEvent(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Handle the changing by the user of the abundance data found in frmAbundanceTableView
    ''' </summary>
    Private Sub abundanceDataChanged(sender As System.Object, e As System.EventArgs) Handles m_frmAbundanceTableView.DataChanged
        If m_which_entry_style = WhichEntryStyleEnum.Abundance Then
            m_data_value = m_frmAbundanceTableView.SelectedCode
            'm_data_code_description = m_frmAbundanceTableView.SelectedCodeName
            m_current_comment = m_frmAbundanceTableView.Comment
            m_data_code_name = DATA_CODE
            m_data_code = "4"
            m_frmSpeciesEvent.Acknowledge(NULL_STRING, m_frmAbundanceTableView.SelectedCode, m_frmAbundanceTableView.Comment)
        End If
    End Sub

    ''' <summary>
    ''' Handle the clearing of the data field in the table by resetting the DataCode and DataComment to Nothing and
    ''' firing an event to signal the parent.
    ''' </summary>
    Public Sub clearData() Handles m_frmTableView.ClearEvent
        If Not IsNothing(m_frmTableView) Then
            m_frmTableView.clearSelection()
        End If
        RaiseEvent EndDataEntryEvent(Me, EventArgs.Empty)
        RaiseEvent ClearEvent(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Bubbles the EndDataEntryEvent up.
    ''' </summary>
    Private Sub endDataEntryEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_frmSpeciesEvent.EndDataEntryEvent,
                                                                                                             m_frmTableView.EndDataEntryEvent
        m_dict = sender.Dictionary
        RaiseEvent EndDataEntryEvent(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Bubbles the DataEntryCanceledEvent up so that video can be set to play again when the user decides to cancel data entry.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dataEntryCanceledHandler(ByVal sender As Object, ByVal e As EventArgs) Handles m_frmSpeciesEvent.DataEntryCanceled,
                                                                                               m_frmTableView.DataEntryCanceled,
                                                                                               m_frmAbundanceTableView.DataEntryCanceled
        RaiseEvent DataEntryCanceled(Me, EventArgs.Empty)
    End Sub
End Class
