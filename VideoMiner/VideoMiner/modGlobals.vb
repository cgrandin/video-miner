Imports System.Data.OleDb
Imports System.IO.Ports
Imports System.Xml
Imports System.IO

Module modGlobals

    Public Class myPortLibrary

        Public Shared aPort As SerialPort

    End Class

    Public Const DB_DATA_TABLE As String = "data"
    Public Const DB_SPECIES_BUTTONS_TABLE As String = "videominer_species_buttons"
    Public Const DB_BUTTONS_TABLE As String = "videominer_habitat_buttons"
    Public Const DB_TRANSECT_BUTTONS_TABLE As String = "videominer_transect_buttons"
    Public Const DB_CONFIDENCE_IDS_TABLE As String = "lu_confidence_ids"
    Public Const DB_ABUNDANCE_TABLE As String = "lu_acfor_scale"

    Public Const DB_CONN_STRING As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="

    Public conn As OleDbConnection
    'Public booResumeVideo As Boolean = True
    Public blRareSpecies As Boolean = False

    Public dictHabitatFieldValues As Dictionary(Of String, String)
    Public dictTempHabitatFieldValues As Dictionary(Of String, String)
    Public dictTransectFieldValues As Dictionary(Of String, String)

    Public dtUserTime As DateTime
    Public dblVideoTimeUserSet As Double = 0
    Public booUseExternalVideo As Boolean = False
    Public booUseGPSTimeCodes As Boolean = False
    Public strHabitatButtonNames() As String
    Public strTransectButtonNames() As String
    Public strRareSpeciesCode As String = ""
    Public strConfigureTable As String = ""
    Public blButtonEdit As Boolean = False

    Public strDatabaseFilePath As String
    Public strVideoFilePath As String

    Public blCleared As Boolean = False
    Public blRefresh As Boolean = False
    Public blNewButton As Boolean = False
    Public strUserTime As String = ""

    Public filePath As String = ""
    Public strConfigFilePath As String = ""

    Public strEditTextBoxOldName As String = ""
    Public strEditTextBoxNewName As String = ""

    
    Public m_PublicSerialPort As New IO.Ports.SerialPort
    


    'Public strNewButtonName As String
    'Public strNewTextBoxName As String

    ' Library function to perform an image capture
    Public Declare Auto Function BitBlt Lib "gdi32.dll" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, _
                                                         ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, _
                                                         ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As System.Int32) As Boolean
    Public Const COPY As Integer = &HCC0020



    Public Class myFormLibrary

        Public Shared frmVideoMiner As VideoMiner
        Public Shared frmSpeciesList As frmSpeciesList
        Public Shared frmSetTime As frmSetTime
        Public Shared frmImage As frmImage
        Public Shared frmGpsSettings As frmGpsSettings
        Public Shared frmEditSpecies As frmEditSpecies
        Public Shared frmConfigureSpecies As frmConfigureSpecies
        Public Shared frmSpeciesEvent As frmSpeciesEvent
        Public Shared frmTableView As frmTableView
        Public Shared frmAbundanceTableView As frmAbundanceTableView
        Public Shared frmRareSpeciesLookup As frmRareSpeciesLookup
        Public Shared frmKeyboardCommands As frmKeyboardCommands
        Public Shared frmAddButton As frmAddButton
        Public Shared frmAddNewTable As frmAddNewTable
        Public Shared frmConfigureButtons As frmConfigureButtons
        Public Shared frmVideoPlayer As frmVideoPlayer
        Public Shared frmProjectNames As frmProjectNames
        Public Shared frmDataCodes As frmDataCodes
        Public Shared frmDeviceControl As frmDeviceControl
        Public Shared frmRelayConfiguration As frmRelayConfiguration
        Public Shared frmRelayNames As frmRelayNames
        Public Shared frmAssignDevice As frmAssignDevice
        Public Shared frmConfigureButtonFormat As frmConfigureButtonFormat
        Public Shared frmCreateKeyboardShortcut As frmCreateKeyboardShortcut
        Public Shared frmAddValue As frmAddValue
        Public Shared frmEditLookupTable As frmEditLookupTable

    End Class
   

    Public Function SingleQuote(ByVal strValue As String) As String
        Return "'" & strValue & "'"
    End Function

    Public Function DoubleQuote(ByVal strValue As String) As String
        Return """" & strValue & """"
    End Function

    Public Function GetVideoTime(ByVal tc As Double, ByRef tcDecimalTime As String) As String
        Try
            'If tc = 0 Then
            '    Return "00:00:00"
            'End If

            'Get the number of seconds from the dtTimeCode
            'Dim ts As TimeSpan = CDate(DateTime.Today & " " & tc).Subtract(CDate(DateTime.Today))
            'Dim dblSeconds As Double = ((ts.Hours * 60) + ts.Minutes) * 60 + ts.Seconds
            If myFormLibrary.frmVideoMiner.blUseComputerTime Then
                tcDecimalTime = myFormLibrary.frmVideoMiner.txtTime.Text & "." & Format(Now.Millisecond, "##")
                Return myFormLibrary.frmVideoMiner.txtTime.Text
            End If
            Dim dblSecondsAddition As Double

            Dim intMilliseconds As Integer
            Dim intSeconds As Integer
            Dim strTime As String()

            dblSecondsAddition = tc - dblVideoTimeUserSet

            strTime = dblSecondsAddition.ToString.Split(".")

            intSeconds = CInt(strTime(0))
            If (dblSecondsAddition - intSeconds) < 0 Then
                intMilliseconds = (dblSecondsAddition - intSeconds) * -1000
            Else
                intMilliseconds = (dblSecondsAddition - intSeconds) * 1000
            End If


            Dim dtPointTime As New DateTime
            dtPointTime = dtUserTime.AddSeconds(dblSecondsAddition)

            ' set the strMilliseconds variable in the videominer form
            myFormLibrary.frmVideoMiner.strMilliseconds = intMilliseconds

            ' Convert the real time to military time
            Dim strMilitaryTime As String
            strMilitaryTime = ToMilitaryTime(dtPointTime)
            tcDecimalTime = strMilitaryTime & "." & intMilliseconds

            myFormLibrary.frmVideoMiner.ElapsedTime = createElapsedTimeString(tc)

            Return strMilitaryTime
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function ToMilitaryTime(ByVal dtRealTime As DateTime) As String

        Dim strTime As String
        If dtRealTime.Millisecond > 500 Then
            dtRealTime.AddSeconds(1)
        End If
        strTime = dtRealTime.ToString("hh:mm:ss")

        Dim strHour As String
        If dtRealTime.Hour <= 9 Then
            strHour = "0" & dtRealTime.Hour.ToString
        Else
            strHour = dtRealTime.Hour
        End If

        Return strHour & strTime.Substring(2, 6)

    End Function

    Public Function createTimeString(ByVal dblTime As Double) As String

        Dim dblSeconds As Double = 0
        Dim intMinutes As Integer = 0
        Dim intHours As Integer = 0
        Dim strTime As String = ""

        dblSeconds = dblTime

        ' Make sure that the seconds value is not over 60 seconds, if so increment the minutes variable
        ' and subtract 60 from the seconds variable
        Do While dblSeconds >= 60
            dblSeconds = dblSeconds - 60
            intMinutes += 1
        Loop

        ' Make sure that the minutes value is not over 60 seconds, if so increment the hours variable
        ' and subtract 60 from the minutes variable
        Do While intMinutes >= 60
            intMinutes = intMinutes - 60
            intHours += 1
        Loop

        If intHours < 10 Then
            strTime = "0" & intHours & ":"
        Else
            strTime = intHours & ":"
        End If

        If intMinutes < 10 Then
            strTime = strTime & "0" & intMinutes & ":"
        Else
            strTime = strTime & intMinutes & ":"
        End If


        If dblSeconds < 10 Then
            strTime = strTime & "0" & Math.Round(dblSeconds, 3)
        Else
            strTime = strTime & Math.Round(dblSeconds, 3)
        End If

        Return strTime

    End Function


    Public Function createElapsedTimeString(ByVal dblTime As Double) As String

        Dim dblSeconds As Double = 0
        Dim intMinutes As Integer = 0
        Dim intHours As Integer = 0
        Dim strTime As String = ""

        dblSeconds = Math.Round(dblTime, 0)

        ' Make sure that the seconds value is not over 60 seconds, if so increment the minutes variable
        ' and subtract 60 from the seconds variable
        Do While dblSeconds >= 60
            dblSeconds = dblSeconds - 60
            intMinutes += 1
        Loop

        ' Make sure that the minutes value is not over 60 seconds, if so increment the hours variable
        ' and subtract 60 from the minutes variable
        Do While intMinutes >= 60
            intMinutes = intMinutes - 60
            intHours += 1
        Loop

        If intHours < 10 Then
            strTime = "0" & intHours & ":"
        Else
            strTime = intHours & ":"
        End If

        If intMinutes < 10 Then
            strTime = strTime & "0" & intMinutes & ":"
        Else
            strTime = strTime & intMinutes & ":"
        End If


        If dblSeconds < 10 Then
            strTime = strTime & "0" & Math.Round(dblSeconds, 0)
        Else
            strTime = strTime & Math.Round(dblSeconds, 0)
        End If

        Return strTime

    End Function

    ' Function used for validating text entered into a text box
    Public Sub numericTextboxValidation(ByRef e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            ' Allow the following characters to be entered into the text box: 1,2,3,4,5,6,7,8,9,0,. and BACKSPACE
            Case "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "0"c, "."c, Convert.ToChar(8)
                e.Handled = False
                ' Dont allow the addition of other characters in the text box
            Case Else
                e.Handled = True
        End Select
    End Sub


    Public Sub RefreshDatabase(ByVal sender As System.Object, ByVal e As System.EventArgs)

        blRefresh = True

        'myFormLibrary.frmVideoMiner.CloseDatabase_Click(sender, e)
        Dim dictTempValues As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim dictTempTextBoxValues As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Dim i As Integer

        For i = 0 To myFormLibrary.frmVideoMiner.strHabitatButtonCodeNames.Length - 2
            dictTempValues.Add(myFormLibrary.frmVideoMiner.strHabitatButtonCodeNames(i).ToString, dictHabitatFieldValues.Item(myFormLibrary.frmVideoMiner.strHabitatButtonCodeNames(i).ToString))
        Next

        For i = 0 To myFormLibrary.frmVideoMiner.strTransectButtonCodeNames.Length - 2
            dictTempValues.Add(myFormLibrary.frmVideoMiner.strTransectButtonCodeNames(i).ToString, dictTransectFieldValues.Item(myFormLibrary.frmVideoMiner.strTransectButtonCodeNames(i).ToString))
        Next

        For i = 0 To myFormLibrary.frmVideoMiner.pnlHabitatData.Controls.Count - 1

            If myFormLibrary.frmVideoMiner.pnlHabitatData.Controls.Item(i).Name.Substring(0, 3) = "txt" Then
                If myFormLibrary.frmVideoMiner.pnlHabitatData.Controls.Item(i).Name = strEditTextBoxOldName Then
                    dictTempTextBoxValues.Add(strEditTextBoxNewName, myFormLibrary.frmVideoMiner.pnlHabitatData.Controls.Item(i).Text)
                Else
                    dictTempTextBoxValues.Add(myFormLibrary.frmVideoMiner.pnlHabitatData.Controls.Item(i).Name, myFormLibrary.frmVideoMiner.pnlHabitatData.Controls.Item(i).Text)
                End If
            End If

        Next

        For i = 0 To myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Count - 1

            If myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Name.Substring(0, 3) = "txt" Then
                If myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Name = strEditTextBoxOldName Then
                    dictTempTextBoxValues.Add(strEditTextBoxNewName, myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Text)
                Else
                    dictTempTextBoxValues.Add(myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Name, myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Text)
                End If
            End If

            'If myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Name.Substring(0, 3) = "txt" Then
            '    dictTempTextBoxValues.Add(myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Name, myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Text)
            'End If

        Next

        Dim strNewButtonName As String
        Dim strNewTextBoxName As String

        If blNewButton = True Then

            strNewButtonName = myFormLibrary.frmAddButton.ButtonName
            strNewTextBoxName = "txt" & Replace(strNewButtonName, "%", "Percent")

            Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"

            Dim txtName As String = strNewTextBoxName
            Dim Letter As String
            For x As Integer = 0 To strNewTextBoxName.Length - 1
                Letter = strNewTextBoxName.Substring(x, 1).ToUpper
                If strCharactersAllowed.Contains(Letter) = False Then
                    txtName = txtName.Replace(Letter, String.Empty)
                End If
            Next

            strNewTextBoxName = txtName

            dictTempTextBoxValues.Add(strNewTextBoxName, "No " & strNewButtonName)

        End If

        myFormLibrary.frmVideoMiner.grdVideoMinerDatabase.DataSource = Nothing
        myFormLibrary.frmVideoMiner.db_file_unload()

        'myFormLibrary.frmVideoMiner.fillTransectVariableButtonPanel()
        'myFormLibrary.frmVideoMiner.fillSpatialVariableButtonPanel()
        'myFormLibrary.frmVideoMiner.fillHabitatFieldsCollection()

        myFormLibrary.frmVideoMiner.openDatabase(strDatabaseFilePath)

        For i = 0 To myFormLibrary.frmVideoMiner.pnlHabitatData.Controls.Count - 1

            If myFormLibrary.frmVideoMiner.pnlHabitatData.Controls.Item(i).Name.Substring(0, 3) = "txt" Then
                myFormLibrary.frmVideoMiner.pnlHabitatData.Controls.Item(i).Text = dictTempTextBoxValues.Item(myFormLibrary.frmVideoMiner.pnlHabitatData.Controls.Item(i).Name)
            End If

        Next
        For i = 0 To myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Count - 1

            If myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Name.Substring(0, 3) = "txt" Then
                myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Text = dictTempTextBoxValues.Item(myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Name)
            End If

        Next

        Dim kvPair As KeyValuePair(Of String, String)

        For Each kvPair In dictTempValues

            If dictHabitatFieldValues.ContainsKey(kvPair.Key) Then
                dictHabitatFieldValues.Item(kvPair.Key) = kvPair.Value
            ElseIf dictTransectFieldValues.ContainsKey(kvPair.Key) Then
                dictTransectFieldValues.Item(kvPair.Key) = kvPair.Value
            End If

        Next


        blRefresh = False
        myFormLibrary.frmVideoMiner.pnlHabitatData.Refresh()
        myFormLibrary.frmVideoMiner.pnlSpeciesData.Refresh()
        myFormLibrary.frmVideoMiner.pnlTransectData.Refresh()
    End Sub
    ' Function to get the values from an XML config file
    Public Function GetConfiguration(ByVal strConfigFile As String, ByVal strPath As String) As String

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
                            strString &= childNode.InnerXml & ","
                        Else
                            strString &= childNode.Value & ","      ' Get the value for the specified child node
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
    ' Function to save the XML settings to a file
    Public Function SaveXmlSettings(ByVal strConfigFile As String, ByVal strPath As String, ByVal strValue As String) As Boolean

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
                            childNode.InnerText = strValue      ' Set the XML value
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
End Module
