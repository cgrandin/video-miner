Public Class frmEXIFViewer

    Private m_dict As Dictionary(Of String, String)
    Private m_rectParent As Rectangle
    Public Event EXIFViewerClosingEvent()

    Public Sub New(dict As Dictionary(Of String, String), rectLocation As Rectangle)
        InitializeComponent()

        m_dict = dict
        m_rectParent = rectLocation
    End Sub

    Private Sub frmEXIFViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Public Sub ReloadData(dict As Dictionary(Of String, String))
        DataGridView1.DataSource = Nothing
        m_dict = dict
        LoadData()
        Refresh()
        BringToFront()
    End Sub

    Private Sub LoadData()
        Dim lst As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
        For Each item As KeyValuePair(Of String, String) In m_dict
            lst.Add(item)
        Next
        DataGridView1.DataSource = lst
        ' Make sure the form opens in a place relative to its parent.
        ' These next two lines would make it appear in the center of the parent
        'Dim x As Integer = m_rectParent.Left + (m_rectParent.Width - Width) \ 2
        'Dim y As Integer = m_rectParent.Top + (m_rectParent.Height - Height) \ 2
        Dim x As Integer = m_rectParent.Left + 50
        Dim y As Integer = m_rectParent.Top + 100
        Location = New Drawing.Point(x, y)
    End Sub

    Private Sub frmEXIFViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RaiseEvent EXIFViewerClosingEvent()
    End Sub

End Class