Public Class frmAddValue
    Private m_value As String

    Public Property strValue() As String
        Get
            Return m_value
        End Get
        Set(ByVal value As String)
            m_value = value
        End Set
    End Property

    Private Sub frmAddValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call cmdOK_Click(sender, e)
        End If
    End Sub

    Private Sub frmAddValue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'myFormLibrary.frmAddValue = Me
        'Me.txtValue.Text = Me.strValue
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.strValue = Me.txtValue.Text
        If Me.strValue = "" Then
            Me.strValue = "-9999"
        End If
        Me.Hide()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If Me.strValue = "" Then
            Me.strValue = "-9999"
        End If
        Me.Hide()
    End Sub

    Public Sub New(ByVal strUserValue As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If strUserValue = "-9999" Then
            strUserValue = ""
        End If
        myFormLibrary.frmAddValue = Me
        Me.txtValue.Text = strUserValue
        Me.strValue = strUserValue
    End Sub

    Private Sub txtValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValue.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call cmdOK_Click(sender, e)
        End If
    End Sub
End Class