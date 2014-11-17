Public NotInheritable Class AboutBox1

    Private m_ttGithub As ToolTip
    Private m_ttEmail As ToolTip

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description

        m_ttGithub = New ToolTip
        m_ttEmail = New ToolTip
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub LinkLabelGithub_MouseHover(sender As Object, e As System.EventArgs) Handles LinkLabelGithub.MouseHover
        m_ttGithub.Show(GITHUB_URL, LinkLabelGithub)
    End Sub

    Private Sub LinkLabelGithub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelGithub.LinkClicked
        System.Diagnostics.Process.Start(GITHUB_URL)
    End Sub

    Private Sub LinkLabelEmail_MouseHover(sender As Object, e As System.EventArgs) Handles LinkLabelEmail.MouseHover
        m_ttGithub.Show(DESIGNER_EMAIL, LinkLabelEmail)
    End Sub

    Private Sub LinkLabelEmail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelEmail.LinkClicked
        System.Diagnostics.Process.Start(DESIGNER_EMAIL)
    End Sub

End Class
