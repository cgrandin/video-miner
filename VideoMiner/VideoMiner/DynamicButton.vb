''' <summary>
''' A Videominer dynamic button. This button extends a regular button by holding the database table name,
''' an instance of the DataTable, the current data code, and the code name.
''' </summary>
''' <remarks></remarks>
Public Class DynamicButton
    Inherits Button

    Dim WithEvents frmSpeciesEvent As frmSpeciesEvent

    ''' <summary>
    ''' The default, uninitialized value for the DataValue property
    ''' </summary>
    ''' <remarks>This is set in the constructors</remarks>
    Public Const UNINITIALIZED_DATA_VALUE = "NULL"

#Region "Member variables"
    ''' <summary>
    ''' A unique key so that this DynamicButton can be linked to a corresponding DynamicTextbox later.
    ''' One and only one DynamicTextbox will have the same control code as this.
    ''' </summary>
    Private m_control_code As Integer
    ''' <summary>
    ''' Name of the MS Access table associated with this button
    ''' </summary>
    Private m_db_table_name As String
    ''' <summary>
    ''' Text to appear on the button
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
    ''' A String representing a keyboard shortcut. This is what can be pressed to trigger a Click event on the button.
    ''' </summary>
    Private m_keyboard_shortcut As String
    ''' <summary>
    ''' Data code for this button as found in the lu_data_codes table.
    ''' This is NOT the code chosen by the user in the table view, this is the
    ''' code for this particular table.
    ''' </summary>
    Private m_data_code As Integer
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
    ''' The value of the chosen data, i.e.e from row selection in a table, entry such as Field of View, or from clicking a species event button.
    ''' It must be a string so that "NULL" can be passed to the SQL query if it was not chosen to be part of the query.
    ''' </summary>
    Private m_data_value As String
    ''' <summary>
    ''' Table of data found in the m_db_table_name table in the MS Access database. This may not be set if the button type is for a species.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_data_table As DataTable
    ''' <summary>
    ''' The table view of the m_data_table. This may not be set if the button type is for a species.
    ''' </summary>
    Private WithEvents m_table_view As frmTableView
    ''' <summary>
    ''' Currently selected code for the variable that m_table_name represents.
    ''' This is changed when the user selects a new row in the underlying table view form.     
    ''' </summary>
    Private m_current_data_code As String
    ''' <summary>
    ''' Currently selected code name for the variable that m_table_name represents.
    ''' This is changed when the user selects a new row in the underlying table view form.     
    ''' </summary>
    Private m_current_data_code_name As String
    ''' <summary>
    ''' Currently entered comment in the frmTableView
    ''' </summary>
    ''' <remarks></remarks>
    Private m_current_comment As String
#End Region

#Region "Properties"

    Public Property ControlCode As Integer
        Get
            Return m_control_code
        End Get
        Set(value As Integer)
            m_control_code = value
        End Set
    End Property

    Public Property TableName As String
        Get
            Return m_db_table_name
        End Get
        Set(value As String)
            m_db_table_name = value
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

    Public Property ForeColorString As String
        Get
            Return Me.ForeColor.ToString()
        End Get
        Set(value As String)
            Dim colConvert As ColorConverter = New ColorConverter()
            Try
                Me.ForeColor = colConvert.ConvertFromString(value)
            Catch ex As Exception
                Me.ForeColor = Color.Black
            End Try
        End Set
    End Property

    Public Property DataFormVisible As Boolean
        Get
            Return m_table_view.Visible
        End Get
        Set(value As Boolean)
            If m_db_table_name = "UserEntered" Then
                Dim frmFOV As New frmFOV
                If frmFOV.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    DataCode = 16
                    DataValue = frmFOV.Data
                    DataCodeName = "FieldOfView"
                    DataDescription = DataValue
                    RaiseEvent DataChanged(Me, Nothing)
                End If
            Else
                ' The check here for nothing distinguishes between the species buttons and the other (habitat and transect buttons).
                ' If m_table_view is nothing, the handler Button_Click which was added dynamically will be run for the species event buttons only
                If m_table_view IsNot Nothing Then
                    m_table_view.Visible = value
                End If
            End If
        End Set
    End Property

#End Region

#Region "Events"
    ''' <summary>
    ''' Fired when the button data has changed.
    ''' </summary>
    Public Event DataChanged(ByVal sender As Object, ByVal e As EventArgs)
    ''' <summary>
    ''' This event will propagate or bubble up the same event raised from within the frmSpeciesEvent class.
    ''' </summary>
    Public Event NewSpeciesEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)

#End Region

    ''' <summary>
    ''' Creates the object, for the case in which the button refers to a database code table.
    ''' </summary>
    ''' <param name="buttonText">Text to appear on the button</param>
    ''' <param name="tableName">Name of the MS Access database table </param>
    ''' <param name="dataCode">Code that is in the database table for this button</param>
    ''' <param name="dataCodeName">Name of the code that is in the database table for this button</param>
    ''' <param name="buttonColor">The microsoft color for this button's text (e.g. "DarkBlue")</param>
    ''' <param name="buttonFont">The font to use for this button (e.g. "Microsoft Sans Serif")</param>
    ''' <param name="buttonTextSize">The font size to use for this button's text (in pts)</param>
    ''' <remarks></remarks>
    Public Sub New(controlCode As Integer, buttonText As String, tableName As String, dataCode As Integer, dataCodeName As String, buttonColor As String, buttonFont As String, buttonTextSize As Integer)
        Dim d As DataTable
        Me.ControlCode = controlCode
        Me.Name = buttonText
        Me.Text = buttonText
        m_db_table_name = tableName

        Dim colConvert As ColorConverter = New ColorConverter()
        Try
            Me.ForeColor = colConvert.ConvertFromString(buttonColor)
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
        m_data_code_name = dataCodeName
        If m_db_table_name = "UserEntered" Then
            ' In the database, the name 'UserEntered' is in place of the tablename, so we must ask user here for the code value
            d = Database.GetDataTable("select * from " & DB_DATA_CODES_TABLE & " where Description = '" & buttonText & "';", DB_DATA_CODES_TABLE)
            m_data_code = d.Rows(0).Item(0)
        Else
            m_data_table = Database.GetDataTable("select * from " & m_db_table_name & " order by 1;", m_db_table_name)
            d = Database.GetDataTable("select * from " & DB_DATA_CODES_TABLE & " where LookupTable = '" & m_db_table_name & "';", DB_DATA_CODES_TABLE)
            m_data_code = d.Rows(0).Item(0)
            ' Create new Table view form, but don't show it yet.
            m_table_view = New frmTableView(Me.Text, m_data_table)
        End If
        If d.Rows.Count > 1 Then
            ' There may be more than one rows which have the same lookup table. e.g. substrate or substrate percent tables will do this
            ' so this tries to match the first 8 characters and use that one.
            ' TODO: Fix this. It works for now, but if two descriptions start with the same 8 letters, there will be erroneous data
            For i As Integer = 0 To d.Rows.Count - 1
                If Strings.Left(m_data_code_name, 8) = Strings.Left(d.Rows(i).Item("Description"), 8) Then
                    m_data_code = d.Rows(i).Item(0)
                End If
            Next
        End If
        DataValue = UNINITIALIZED_DATA_VALUE
    End Sub

    ''' <summary>
    ''' Creates the object, for the case in which the button refers to a singular datum (such as species code).
    ''' </summary>
    ''' <param name="buttonText">Text to appear on the button</param>
    ''' <param name="buttonCode">Code for the button. If singulars button, this is the (species) code</param>
    ''' <param name="buttonCodeName">Name for the button code, (e.g. SpeciesID)</param>
    ''' <param name="dataCode">Data Code that is in the database table for this button type</param>
    ''' <param name="buttonColor">The microsoft color for this button's text (e.g. "DarkBlue")</param>
    ''' <param name="keyboardShortcut">Keyboard shortcut that will run the Click event for this button</param>
    ''' <param name="buttonFont">The font to use for this button (e.g. "Microsoft Sans Serif")</param>
    ''' <param name="buttonTextSize">The font size to use for this button's text (in pts)</param>
    ''' <remarks></remarks>
    Public Sub New(controlCode As Integer, buttonText As String, buttonCode As String, buttonCodeName As String, dataCode As Integer, buttonColor As String, keyboardShortcut As String, buttonFont As String, buttonTextSize As Integer)
        Me.ControlCode = controlCode
        Me.Name = buttonText
        Me.Text = buttonText
        Dim colConvert As ColorConverter = New ColorConverter()
        Try
            Me.ForeColor = colConvert.ConvertFromString(buttonColor)
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
        m_data_table = Nothing
        m_db_table_name = Nothing
        m_table_view = Nothing
        m_button_code = buttonCode
        m_button_code_name = buttonCodeName
        m_keyboard_shortcut = keyboardShortcut
        DataValue = UNINITIALIZED_DATA_VALUE
        ' The species event form is unique for each dynamic button and is created once when the dynamic button is created
        frmSpeciesEvent = New frmSpeciesEvent(buttonText)
        ' Handler for when the user presses a species button, it should just call up the Species Event form with the button's data sent as sender
        AddHandler Me.Click, AddressOf Me.Button_Click
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSpeciesEvent.Show()
    End Sub

    ''' <summary>
    ''' Handle the changing by the user of the lookup table code found in frmTableView, and fire an event to the parent.
    ''' </summary>
    ''' <param name="comment">The comment supplied by the user. Can be the empty string.</param>
    Private Sub dataHasChanged(comment As String) Handles m_table_view.DataChanged
        DataValue = m_table_view.SelectedCode
        DataDescription = m_table_view.SelectedCodeName
        DataComment = m_table_view.Comment
        ' Chain this event to the main form where a query can be run to place the changes in the database if necessary (if comment <> "").
        RaiseEvent DataChanged(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Handle the clearing of the data field in the table by resetting the DataCode and DataComment to Nothing and
    ''' firing an event to signal the parent.
    ''' </summary>
    Private Sub clearData() Handles m_table_view.ClearEvent
        DataValue = UNINITIALIZED_DATA_VALUE
        DataComment = NULL_STRING
        If Not IsNothing(m_table_view) Then
            m_table_view.clearSelection()
        End If
        RaiseEvent DataChanged(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Click event handler. If Ctrl-clicked, the selection will be cleared. If left-clicked, the data form will be shown.
    ''' </summary>
    Public Sub clickMe(sender As Object, e As MouseEventArgs) Handles Me.Click
        If My.Computer.Keyboard.CtrlKeyDown Then
            'If Not IsNothing(m_table_view) Then
            clearData()
            'End If
        Else
        Me.DataFormVisible = True
        End If
    End Sub

    ''' <summary>
    ''' Places the table view forms in the center of the screen.
    ''' </summary>
    Private Sub myLocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        If Not IsNothing(m_table_view) Then
            m_table_view.StartPosition = FormStartPosition.Manual
            m_table_view.Location = System.Windows.Forms.Cursor.Position
        End If
    End Sub

    ''' <summary>
    ''' Handles the event request to insert a new entry into the database. The species event form which corresponds to this button has been populated, validated, and the values are ready to be extracted.
    ''' This just bubbles the event up to the parent.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub new_species_entry_handler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmSpeciesEvent.NewSpeciesEntryEvent
        'Pass the species event object along
        RaiseEvent NewSpeciesEntryEvent(sender, e)
    End Sub
End Class
