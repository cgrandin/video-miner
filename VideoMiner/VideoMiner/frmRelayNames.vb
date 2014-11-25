Public Class frmRelayNames

    Private m_Relay1 As String
    Private m_Relay2 As String
    Private m_Relay3 As String
    Private m_Relay4 As String


    Public Property Relay1Name() As String
        Get
            Return m_Relay1
        End Get
        Set(ByVal value As String)
            m_Relay1 = value
        End Set
    End Property

    Public Property Relay2Name() As String
        Get
            Return m_Relay2
        End Get
        Set(ByVal value As String)
            m_Relay2 = value
        End Set
    End Property

    Public Property Relay3Name() As String
        Get
            Return m_Relay3
        End Get
        Set(ByVal value As String)
            m_Relay3 = value
        End Set
    End Property

    Public Property Relay4Name() As String
        Get
            Return m_Relay4
        End Get
        Set(ByVal value As String)
            m_Relay4 = value
        End Set
    End Property

    Private Sub frmRelayNames_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtRelay1.Text = Relay1Name
        txtRelay2.Text = Relay2Name
        txtRelay3.Text = Relay3Name
        txtRelay4.Text = Relay4Name

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Relay1Name = txtRelay1.Text
        Relay2Name = txtRelay2.Text
        Relay3Name = txtRelay3.Text
        Relay4Name = txtRelay4.Text
        Close()
    End Sub
End Class