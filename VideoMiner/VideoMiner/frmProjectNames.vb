Imports System.IO
Imports System.Xml

Public Class frmProjectNames

    Private m_ProjectName As String
    Private m_ProjectNameToDelete As String

    Event ProjectNameChangedEvent()
    Event NewProjectNameEvent()
    Event DeleteProjectNameEvent()

    ''' <summary>
    ''' Return the name of the currently chosen project name
    ''' </summary>
    Public Function getProjectName() As String
        Return m_ProjectName
    End Function

    ''' <summary>
    ''' Return the name of the currently chosen project name to be deleted
    ''' </summary>
    Public Function getProjectNameToDelete() As String
        Return m_ProjectNameToDelete
    End Function

    ''' <summary>
    ''' Place all names in the supplied list Collection into the ListBox.
    ''' Refreshes the list everytime it is called, i.e. clears the list and rebuilds
    ''' it based on the list Collection
    ''' </summary>
    Public Function PopulateProjectList(list As Collection) As Boolean
        lstProjects.Items.Clear()
        Dim i As Integer
        Try
            For i = 1 To list.Count
                lstProjects.Items.Add(list.Item(i))
            Next
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Function writeProjectName(ByVal strConfigFile As String, ByVal strPath As String, ByVal strItem As String) As Boolean
        ' Check if the specified configuration file exists
        If File.Exists(strConfigFile) Then

            ' Load the config file into the document object
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(strConfigFile)

            ' Load the config file nodes into the Node list object
            Dim nodeList As XmlNodeList
            nodeList = xmlDoc.SelectNodes(strPath)
            If nodeList Is Nothing Then
                Return False
            End If

            ' Create the Parent and Child node objects and cycle through the file
            Dim parentNode As XmlNode
            parentNode = nodeList.Item(0)
            Dim childNode As XmlNode


            childNode = xmlDoc.CreateElement("ProjectName")
            childNode.InnerText = strItem

            parentNode.AppendChild(childNode)

            xmlDoc.Save(strConfigFile)      ' Save the config file
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Enable or disable the delete button depending on whether or not there is a valid selection
    ''' </summary>
    Private Sub lstProjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProjects.SelectedIndexChanged
        If Me.lstProjects.SelectedItems.Count = 0 Then
            Me.cmdDelete.Enabled = False
        Else
            Me.cmdDelete.Enabled = True
            Me.txtProject.Text = Me.lstProjects.SelectedItem
        End If
    End Sub

    ''' <summary>
    ''' Enable or disable the delete button depending on whether or not there is a valid selection
    ''' </summary>
    Private Sub txtProject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProject.TextChanged
        If Me.txtProject.Text.Length <> 0 Then
            Me.cmdOK.Enabled = True
        Else
            Me.cmdOK.Enabled = False
        End If
        'If Me.lstProjects.SelectedItems.Count <> 0 Then
        '    If Me.txtProject.Text <> Me.lstProjects.SelectedItem Then
        '        Me.lstProjects.SetSelected(Me.lstProjects.SelectedIndex, False)
        '    End If
        'End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        m_ProjectName = txtProject.Text
        RaiseEvent ProjectNameChangedEvent()

        Dim inList As Boolean = vbFalse
        For Each item As Object In lstProjects.Items
            If txtProject.Text = item.ToString Then
                inList = vbTrue
            End If
        Next
        If Not inList Then
            RaiseEvent NewProjectNameEvent() ' This will tell the handler to write the new name to XML file
        End If

        Me.Hide()
        'writeProjectName(strConfigFile, VMCD & "/PreviousProjects", Me.txtProject.Text)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Hide()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'deleteProjectName(strConfigFile, VMCD & "/PreviousProjects", Me.lstProjects.SelectedItem)
        m_ProjectNameToDelete = lstProjects.SelectedItem
        Me.lstProjects.Items.Remove(lstProjects.SelectedItem)
        Me.txtProject.Text = NULL_STRING
        RaiseEvent DeleteProjectNameEvent()
    End Sub

    Private Function deleteProjectName(ByVal strConfigFile As String, ByVal strPath As String, ByVal strItem As String) As Boolean

        ' Check if the specified configuration file exists
        If File.Exists(strConfigFile) Then

            ' Load the config file into the document object
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(strConfigFile)

            ' Load the config file nodes into the Node list object
            Dim nodeList As XmlNodeList
            nodeList = xmlDoc.SelectNodes(strPath)
            If nodeList Is Nothing Then
                Return False
            End If

            ' Create the Parent and Child node objects and cycle through the file
            Dim parentNode As XmlNode
            Dim childNode As XmlNode
            For Each parentNode In nodeList
                If parentNode.HasChildNodes Then
                    For Each childNode In parentNode.ChildNodes
                        If childNode IsNot Nothing Then
                            If childNode.InnerText = strItem Then
                                parentNode.RemoveChild(childNode)
                                Exit For
                            End If
                            ' Set the XML value
                        End If
                    Next
                End If
            Next
            xmlDoc.Save(strConfigFile)      ' Save the config file
            Return True
        Else
            Return False
        End If
    End Function

End Class