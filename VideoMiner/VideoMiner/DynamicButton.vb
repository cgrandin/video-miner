﻿''' <summary>
''' A Videominer dynamic button. This button extends a regular button by holding the database table name,
''' an instance of the DataTable, the current data code, and the code name.
''' </summary>
''' <remarks></remarks>
Public Class DynamicButton
    Inherits Button

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
                ' TODO: Make a new form so the value can be validated here.. right now an exception is thrown and discarded
                Try
                    m_data_code = InputBox("Please enter a value for " & Name & ":", Name & "entry", )
                Catch ex As Exception
                    MessageBox.Show("Error on input, the value must be an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    m_data_code = Nothing
                End Try
            Else
                m_table_view.Visible = value
            End If
        End Set
    End Property
#End Region

    Public Event SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)

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
        If m_db_table_name = "UserEntered" Then
            ' In the database, the name 'UserEntered' is in place of the tablename, so we must ask user here for the code value
            m_data_code_name = buttonText
            m_data_code = Nothing
        Else
            m_data_table = Database.GetDataTable("select * from " & m_db_table_name & " order by 1;", m_db_table_name)
            m_data_code = dataCode
            m_data_code_name = dataCodeName
            ' Create new Table view form, but don't show it yet.
            m_table_view = New frmTableView(Me.Text, m_data_table)
        End If
    End Sub

    ''' <summary>
    ''' Creates the object, for the case in which the button refers to a species code.
    ''' </summary>
    ''' <param name="buttonText">Text to appear on the button</param>
    ''' <param name="buttonCode">Code for the button. If species button, this is the species code</param>
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
    End Sub

    ''' <summary>
    ''' Handle the changing by the user of the lookup table code found in frmTableView, and fire an event to the parent.
    ''' </summary>
    ''' <param name="comment">The comment supplied by the user. Can be the empty string.</param>
    Private Sub dataChanged(comment As String) Handles m_table_view.DataChanged
        DataCode = m_table_view.SelectedCode
        DataCodeName = m_table_view.SelectedCodeName
        DataComment = m_table_view.Comment
        ' Chain this event to the main form where a query can be run to place the changes in the database if necessary (if comment <> "").
        RaiseEvent SelectionChanged(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Handle the clearing of the data field in the table by resetting the DataCode and DataComment to Nothing and
    ''' firing an event to signal the parent.
    ''' </summary>
    Private Sub clearSpatialData() Handles m_table_view.ClearSpatialInformationEvent
        DataCode = -1
        DataCodeName = Nothing
        DataComment = NULL_STRING
        m_table_view.clearSelection()
        RaiseEvent SelectionChanged(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Click event handler. If Ctrl-clicked, the selection will be cleared. If left-clicked, the data form will be shown.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub clickMe(sender As Object, e As MouseEventArgs) Handles Me.Click
        If My.Computer.Keyboard.CtrlKeyDown Then
            If Not IsNothing(m_table_view) Then
                clearSpatialData()
            End If
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
End Class
