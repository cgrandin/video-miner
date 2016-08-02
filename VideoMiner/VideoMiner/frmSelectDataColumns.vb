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
        ReDim m_show_indices(m_data_table.Columns.Count)
        ' Add all fields found in the database table to the list
        For col As Integer = 0 To m_data_table.Columns.Count - 1
            clbData.Items.Add(m_data_table.Columns(col).ColumnName)
        Next
        checkAll()
    End Sub

    Private Sub checkAll()
        For idx As Integer = 0 To clbData.Items.Count - 1
            clbData.SetItemCheckState(idx, CheckState.Checked)
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

    Private Sub me_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            recordVisibility()
            Hide()
            RaiseEvent DataTableModified()
        End If
    End Sub

End Class