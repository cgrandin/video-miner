''' <summary>
''' A Videominer dynamic table button. This button extends a regular button by holding 
''' the database table name, an instance of the DataTable, the current data code,
''' and the code name. It also holds a textbox for the status of the variable.
''' When the button is pressed, a database table will be shown and the user can
''' select the row they want. Once the row is selected, the value will be shown in the Textbox.
''' </summary>
''' <remarks></remarks>
Public Class DynamicTableButton
    Inherits Button

    ''' <summary>
    ''' The default, uninitialized value for the DataValue property
    ''' </summary>
    Public Const UNINITIALIZED_DATA_VALUE = "NULL"

#Region "Member variables"
    ''' <summary>
    ''' The current value of the variable for this button.
    ''' </summary>
    Private txtStatus As TextBox
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
    ''' The value of the chosen data, i.e. from row selection in a table or entry such as Field of View.
    ''' It must be a string so that "NULL" can be passed to the SQL query if it was not chosen to be part of the query.
    ''' </summary>
    Private m_data_value As String
    ''' <summary>
    ''' Table of data found in the m_db_table_name table in the MS Access database.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_data_table As DataTable
    ''' <summary>
    ''' The table view of the m_data_table.
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
    Private m_current_comment As String
    ''' <summary>
    ''' Distinguishes between the two types of data this button can represent, database table
    ''' data (lookup tables stored as type DataTable) or UserEntered which are not a DataTable
    ''' and are entered via a form such as Field Of View.
    ''' </summary>
    Public Enum WhichTypeEnum
        DataTable
        UserEntered
    End Enum
    ''' <summary>
    ''' Holds the enumeration type for this instance
    ''' </summary>
    Private m_which_type As WhichTypeEnum
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
    ''' Signals the parent that a button has been pressed and we request that the video be paused while data entry takes place.
    ''' </summary>
    Public Event SignalVideoPause(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Signals the parent that the data entry is complete and to resume playback.
    ''' </summary>
    Public Event SignalVideoPlay(ByVal sender As System.Object, ByVal e As System.EventArgs)
#End Region

    ''' <summary>
    ''' Creates the button, for the case in which the button refers to a database code table.
    ''' </summary>
    ''' <param name="buttonText">Text to appear on the button</param>
    ''' <param name="tableName">Name of the MS Access database table </param>
    ''' <param name="dataCode">Code that is in the database table for this button</param>
    ''' <param name="dataCodeName">Name of the code that is in the database table for this button</param>
    ''' <param name="buttonColor">The microsoft color for this button's text (e.g. "DarkBlue")</param>
    ''' <param name="buttonFont">The font to use for this button (e.g. "Microsoft Sans Serif")</param>
    ''' <param name="buttonTextSize">The font size to use for this button's text (in pts)</param>
    ''' <remarks></remarks>
    Public Sub New(buttonText As String,
                   tableName As String,
                   dataCode As Integer,
                   dataCodeName As String,
                   buttonColor As String,
                   buttonFont As String,
                   buttonTextSize As Integer,
                   Optional whichType As WhichTypeEnum = WhichTypeEnum.DataTable)
        Dim d As DataTable
        Me.Name = buttonText
        Me.Text = buttonText
        m_db_table_name = tableName

        m_which_type = WhichTypeEnum.DataTable
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
        m_data_value = UNINITIALIZED_DATA_VALUE
    End Sub

    ''' <summary>
    ''' Handle the clearing of the data field in the table by resetting the DataCode and DataComment to Nothing and
    ''' firing an event to signal the parent.
    ''' </summary>
    Private Sub clearData() Handles m_table_view.ClearEvent
        m_data_value = UNINITIALIZED_DATA_VALUE
        m_current_comment = NULL_STRING
        If Not IsNothing(m_table_view) Then
            m_table_view.clearSelection()
        End If
        RaiseEvent DataChanged(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Show the associated data table form for this button.
    ''' </summary>
    Public Sub ShowForm(sender As Object, e As EventArgs)
        If My.Computer.Keyboard.CtrlKeyDown Then
            clearData()
            Exit Sub
        Else
            Me.DataFormVisible = True
        End If

        ' Raise an event to signal the beginning of the process of filling in a form which will be recorded to the database.
        ' For example, when the user presses a species button it will bring up the form needed to fill in the information for the species.
        ' The video needs to be paused at this point, and restarted when the user presses OK on the form which is being worked on
        RaiseEvent SignalVideoPause(Me, e)
    End Sub

End Class
