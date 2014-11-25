Imports System.IO
Imports System.Xml

Public Class frmProjectNames

    Public strConfigFile As String
    Private clProjectNames As Collection

    Event ProjectNameChangedEvent()

    Private Sub frmProjectNames_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strPath As String

        strPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
        If (strPath.StartsWith("file:\")) Then
            strPath = strPath.Substring(6)    ' Remove unnecessary substring
        End If

        strConfigFile = strPath & "\VideoMinerConfigurationDetails.xml"

        clProjectNames = New Collection

        GetProjectNames(strConfigFile, VMCD & "/PreviousProjects")

        Dim i As Integer

        For i = 1 To clProjectNames.Count
            lstProjects.Items.Add(clProjectNames.Item(i))
        Next

    End Sub

    ' Function to get the values from an XML config file
    Public Function GetProjectNames(ByVal strConfigFile As String, ByVal strPath As String) As String

        ' Check if the specified configuration file exists
        If File.Exists(strConfigFile) Then

            ' Load the config file into the document object
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(strConfigFile)

            ' Load the config file nodes into the Node List object
            Dim nodeList As XmlNodeList
            nodeList = xmlDoc.SelectNodes(strPath)
            If nodeList Is Nothing Then
                Return ""
            End If

            ' Create the parent and child node objects and cycle through the file
            Dim parentNode As XmlNode
            Dim childNode As XmlNode
            Dim strString As String = ""
            For Each parentNode In nodeList
                If parentNode.HasChildNodes Then
                    For Each childNode In parentNode.ChildNodes
                        If childNode.ChildNodes.Count > 0 Then
                            clProjectNames.Add(childNode.InnerXml)
                        Else
                            clProjectNames.Add(childNode.Value)      ' Get the value for the specified child node
                        End If
                        'Debug.WriteLine("strString: " & strString)
                    Next
                End If
            Next
            If strString.Length > 0 Then
                strString = strString.Substring(0, strString.Length - 1)
            End If

            Return strString
        Else
            Return ""
        End If

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

    Private Sub lstProjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProjects.SelectedIndexChanged

        If Me.lstProjects.SelectedItems.Count = 0 Then
            Me.cmdDelete.Enabled = False
        Else
            Me.cmdDelete.Enabled = True
            Me.txtProject.Text = Me.lstProjects.SelectedItem
        End If


    End Sub

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
        Dim i As Integer
        For i = 1 To clProjectNames.Count
            If Me.txtProject.Text = clProjectNames.Item(i) Then
                RaiseEvent ProjectNameChangedEvent()
                Me.Close()
                Exit Sub
            End If
        Next
        writeProjectName(strConfigFile, VMCD & "/PreviousProjects", Me.txtProject.Text)
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

        deleteProjectName(strConfigFile, VMCD & "/PreviousProjects", Me.lstProjects.SelectedItem)

        Me.lstProjects.Items.Remove(lstProjects.SelectedItem)
        Me.txtProject.Text = ""

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