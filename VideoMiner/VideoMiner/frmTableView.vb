''' <summary>
''' This form will show a table which is supplied in the constructor as a DataTable.
''' It will allow the user to select a row, which will cause a query to insert the data
''' in the database
''' </summary>
Public Class frmTableView
    Private m_data_table As DataTable
    Private prevWidth As Integer
    Private prevWindowState As FormWindowState
    ''' <summary>
    ''' Data code name as seen in the database table 'data'
    ''' </summary>
    Private m_data_code_name As String
    ''' <summary>
    ''' Data code as seen in the database table 'lu_data_codes'
    ''' </summary>
    Private m_data_code As String
    ''' <summary>
    ''' Data value as selected by the user (from the currently selected row)
    ''' </summary>
    Private m_data_value As String
    ''' <summary>
    ''' A tuple which represents the data which were chosen
    ''' </summary>
    Private m_tuple As Tuple(Of String, String, Boolean)
    ''' <summary>
    ''' Dictionary of key/value pairs that hold the currently selected data.
    ''' The first parameter is the name of the field in the database table lu_data, the second is the tuple above.
    ''' </summary>
    Private m_dict As Dictionary(Of String, Tuple(Of String, String, Boolean))

#Region "Properties"
    Public ReadOnly Property DataValue As String
        Get
            Return m_data_value
        End Get
    End Property
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

    ''' <summary>
    ''' If a row is selected, return the first cell's value from that row.
    ''' If no row is selected, return the empty string.
    ''' </summary>
    Public ReadOnly Property SelectedCode As String
        Get
            If DataGridView1.SelectedRows.Count = 1 Then
                Return DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            Else
                Return NULL_STRING
            End If
        End Get
    End Property

    ''' <summary>
    ''' If a row is selected, return the second cell's value from that row
    ''' If no row is selected, return the empty string.
    ''' </summary>
    Public ReadOnly Property SelectedCodeName As String
        Get
            If DataGridView1.SelectedRows.Count = 1 Then
                Return DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
            Else
                Return NULL_STRING
            End If
        End Get
    End Property

    ''' <summary>
    ''' Return the contents of the comment box, which may be an empty string.
    ''' </summary>
    Public ReadOnly Property Comment As String
        Get
            Return txtCommentBox.Text
        End Get
    End Property

    Public ReadOnly Property Dictionary As Dictionary(Of String, Tuple(Of String, String, Boolean))
        Get
            Return m_dict
        End Get
    End Property

#End Region

#Region "Events"
    ''' <summary>
    ''' If user presses Clear button, this will fire so that the main form can update its dynamic buttons and textboxes
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ClearEvent()
    ''' <summary>
    ''' Fires when a new row is selected.
    ''' </summary>
    Public Event EndDataEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
#End Region

    Public Sub New(titleText As String, dataTable As DataTable)
        InitializeComponent()
        Me.Text = titleText
        m_data_table = dataTable
        DataGridView1.DataSource = m_data_table
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.MultiSelect = False
        ' TODO: Make the grid editable and linked to database
        DataGridView1.ReadOnly = True
        Controls.Add(DataGridView1)

        m_tuple = New Tuple(Of String, String, Boolean)(Nothing, Nothing, False)
        m_dict = New Dictionary(Of String, Tuple(Of String, String, Boolean))

        'If intCurrentSpatialVariable <> 8888 Then
        ' m_strSelectedButtonName = strButtonNames(intCurrentSpatialVariable)
        ' End If
    End Sub

    Private Sub TableViewForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Me.UserClosedForm = True
    End Sub

    ''' <summary>
    ''' Capture the press of the 'X' button and hide instead of closing to avoid an exception on re-opening
    ''' </summary>
    Private Sub frmTableView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    ''' <summary>
    ''' Once the form loads, resize the grid so that there is no horizontal scrollbar
    ''' </summary>
    Private Sub ResizeGrid()
        If prevWidth = 0 Then
            prevWidth = DataGridView1.Width
        End If
        If prevWidth = DataGridView1.Width Then
            Exit Sub
        End If
        Dim fixedWidth As Integer = SystemInformation.VerticalScrollBarWidth + DataGridView1.RowHeadersWidth + 2
        Dim mul As Integer = 100 * (DataGridView1.Width - fixedWidth) / (prevWidth - fixedWidth)
        Dim columnWidth As Integer
        Dim total As Integer = 0
        Dim lastVisibleCol As DataGridViewColumn = Nothing
        For i As Integer = 0 To DataGridView1.ColumnCount - 1
            If DataGridView1.Columns(i).Visible Then
                columnWidth = (DataGridView1.Columns(i).Width * mul + 50) / 100
                DataGridView1.Columns(i).Width = Math.Max(columnWidth, DataGridView1.Columns(i).MinimumWidth)
                total = total + DataGridView1.Columns(i).Width
                lastVisibleCol = DataGridView1.Columns(i)
            End If
        Next
        If IsNothing(lastVisibleCol) Then
            Exit Sub
        End If
        columnWidth = DataGridView1.Width - total + lastVisibleCol.Width - fixedWidth
        lastVisibleCol.Width = Math.Max(columnWidth, lastVisibleCol.MinimumWidth)
        prevWidth = DataGridView1.Width
    End Sub

    Private Sub TableViewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnSkipSpatial.Visible = True
        Me.btnClear.Visible = True
        prevWidth = Width
        prevWindowState = WindowState
        ResizeGrid()
        Refresh()
    End Sub

    ''' <summary>
    ''' Handles the event when the user selects a row of the table. If the comment box is not empty, it will raise an event so that the main form can
    ''' insert a new record in the database to capture the comment.
    ''' </summary>
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count = 1 Then
            buildDictionary()
            RaiseEvent EndDataEntryEvent(Me, e)
            Me.Hide()
        End If
    End Sub


    ''' <summary>
    ''' Build the dictionary of key/value pairs for the data the user chose.
    ''' </summary>
    Private Sub buildDictionary()
        ' Clear the dictionary from the previous time if necessary
        m_dict.Clear()
        ' The first parameter is the name of the field in the database table lu_data. The tuple is a triplet of data code (from lu_data_codes), which is 4 for a species entry,
        ' the data value to be inserted, and a boolean for whether or not the item was the one pressed (in case there are more than one in the dictionary).
        m_data_value = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        m_tuple = New Tuple(Of String, String, Boolean)(m_data_code, m_data_value, True)
        m_dict.Add(m_data_code_name, m_tuple)
    End Sub

    Private Sub btnSkipSpatial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSkipSpatial.Click
        Me.Hide()
        'RaiseEvent SignalPlay(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' If the clear button is pressed, clear the selected row so that there is no selection, and raise an event to the parent.
    ''' </summary>
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clearSelection()
        RaiseEvent ClearEvent()
        Me.Hide()
        'RaiseEvent SignalPlay(Me, EventArgs.Empty)
    End Sub

    Private Sub cmdScreenCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScreenCapture.Click
        'TODO: Screen capture... not sure why though
    End Sub

    ''' <summary>
    ''' Clear the datagrid selection and empty the comment box
    ''' </summary>
    Public Sub clearSelection()
        DataGridView1.ClearSelection()
        txtCommentBox.Clear()
    End Sub

End Class