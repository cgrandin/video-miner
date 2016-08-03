Public Class frmSelectDataColumns
    Private m_data_table As DataTable
    ''' <summary>
    ''' An array of integers holding the data table column indices that are being shown.
    ''' </summary>
    Private m_show_indices As Boolean()
    Public Event DataTableModified()

    ''' <summary>
    ''' An array of booleans, 1 for each column of the data table.
    ''' True means the column is visible, False means it is hidden.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property VisibleColumns As Boolean()
        Get
            Return m_show_indices
        End Get
    End Property

    Public Sub New(dt As DataTable)
        InitializeComponent()
        m_data_table = dt
        ReDim m_show_indices(m_data_table.Columns.Count - 1)
        ' Add all fields found in the database table to the list
        For col As Integer = 0 To m_data_table.Columns.Count - 1
            clbData.Items.Add(m_data_table.Columns(col).ColumnName)
        Next
        clbData.CheckOnClick = True
        checkAll()
    End Sub

    Private Sub checkAll()
        For idx As Integer = 0 To clbData.Items.Count - 1
            clbData.SetItemCheckState(idx, CheckState.Checked)
            m_show_indices(idx) = True
        Next
    End Sub

    ''' <summary>
    ''' Record into array the visibility settings as set by user.
    ''' </summary>
    Private Sub recordVisibility()
        For idx As Integer = 0 To clbData.Items.Count - 1
            If clbData.GetItemCheckState(idx) = CheckState.Checked Then
                m_show_indices(idx) = True
            Else
                m_show_indices(idx) = False
            End If
        Next
    End Sub

    ''' <summary>
    ''' Set the checked items to have the visibility as supplied by the argument blVis.
    ''' Fires the DataTableModified Event
    ''' </summary>
    ''' <param name="blVis"></param>
    Public Sub SetVisibleColumns(blVis As Boolean())
        Try
            For idx As Integer = 0 To clbData.Items.Count - 1
                If blVis(idx) Then
                    m_show_indices(idx) = True
                    clbData.SetItemChecked(idx, True)
                Else
                    m_show_indices(idx) = False
                    clbData.SetItemChecked(idx, False)
                End If
            Next
            RaiseEvent DataTableModified()
        Catch ex As Exception
            ' This happens if there was one or more child nodes missing from the DataColumnVisibility node
            ' in the XML file. We could post an errorbox, but the program will default to fully selected and
            ' fix the problem itself.
        End Try
    End Sub

    ''' <summary>
    ''' When the form is closed, save the changes and raise an event so that the grid can be changed in the main form.
    ''' </summary>
    Private Sub me_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            recordVisibility()
            Hide()
            RaiseEvent DataTableModified()
        End If
    End Sub

End Class