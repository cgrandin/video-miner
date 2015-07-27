''' <summary>
''' A Videominer dynamic button. This button extends a regular button by holding the database table name, current data code, and code name.
''' </summary>
''' <remarks></remarks>
Public Class DynamicButton
    Inherits Button

#Region "Member variables"
    ''' <summary>
    ''' Name of the MS Access table associated with this button
    ''' </summary>
    Private m_db_table_name As String
    ''' <summary>
    ''' Data code for this button as found in the lu_data_codes table.
    ''' This is NOT the code chosen by the user in the table view, this is the
    ''' code for this particular table.
    ''' </summary>
    Private m_code As Integer
    ''' <summary>
    ''' Name of the data code (description) as found in the lu_data_codes table.
    ''' This is NOT the code chosen by the user in the table view, this is the
    ''' code for this particular table.
    ''' </summary>
    Private m_code_name As String
    ''' <summary>
    ''' Table of data found in the m_db_table_name table in the MS Access database
    ''' </summary>
    ''' <remarks></remarks>
    Private m_data_table As DataTable
    ''' <summary>
    ''' The table view of the m_data_table
    ''' </summary>
    Private WithEvents m_table_view As frmTableView
    ''' <summary>
    ''' Dictionary of Key-value pairs for the first and second columns of the table m_table_name.
    ''' </summary>
    Private m_dict As Dictionary(Of String, String)
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
    Public Property TableName As String
        Get
            Return m_db_table_name
        End Get
        Set(value As String)
            m_db_table_name = value
        End Set
    End Property

    Public Property Code As Integer
        Get
            Return m_code
        End Get
        Set(value As Integer)
            m_code = value
        End Set
    End Property

    Public Property CodeName As String
        Get
            Return m_code_name
        End Get
        Set(value As String)
            m_code_name = value
        End Set
    End Property

    Public Property Comment As String
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

    Public ReadOnly Property Dictionary As Dictionary(Of String, String)
        Get
            Return m_dict
        End Get
    End Property

    Public Property DataFormVisible As Boolean
        Get
            Return m_table_view.Visible
        End Get
        Set(value As Boolean)
            m_table_view.Visible = value
        End Set
    End Property
#End Region

    Public Event SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub New(name As String, tableName As String, code As Integer, codeNm As String, foreColorString As String, buttonFont As String, buttonTextSize As Integer)
        Me.Name = name
        Me.Text = name
        m_db_table_name = tableName
        m_data_table = Database.GetDataTable("select * from " & m_db_table_name, m_db_table_name)
        m_code = code
        m_code_name = codeNm
        Dim colConvert As ColorConverter = New ColorConverter()
        Try
            Me.ForeColor = colConvert.ConvertFromString(foreColorString)
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
        ' Create new Table view form, but don't show it yet.
        m_table_view = New frmTableView(m_data_table)
        ' Populate dictionary for the given table contents
        m_dict = New Dictionary(Of String, String)
        For Each row As DataRow In m_data_table.Rows
            m_dict(row.Item(1)) = row.Item(0)
        Next
        m_current_data_code = Nothing
        m_current_data_code_name = Nothing
        m_current_comment = Nothing
    End Sub

    Private Sub transectDataChanged() Handles m_table_view.DataChanged
        m_current_data_code = m_table_view.GetCurrentlySelectedCode
        m_current_data_code_name = m_table_view.GetCurrentlySelectedCodeName
        m_current_comment = m_table_view.GetCurrentComment
        RaiseEvent SelectionChanged(Me, EventArgs.Empty)
    End Sub
End Class
