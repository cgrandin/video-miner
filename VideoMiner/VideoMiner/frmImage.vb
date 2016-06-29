Imports System.Text.RegularExpressions
Imports System.IO
Imports System.IO.Path

Public Class frmImage
    ''' <summary>
    ''' Holds the path of the last known path for pictures.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strImagePath As String
    ''' <summary>
    ''' Hold the currently loaded image's filename with full path information.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strImageFile As String
    ''' <summary>
    ''' A list of the image files in the same directory as the currently loaded image.
    ''' </summary>
    Private m_lstImageFiles As List(Of String)
    ''' <summary>
    ''' The index of the last image file in the current m_lstImageFiles list.
    ''' </summary>
    Private m_intLastImageIndex As Integer = 0
    ''' <summary>
    ''' The index of the current image file in the current m_lstImageFiles list.
    ''' </summary>
    Private m_intImageIndex As Integer = 0
    ''' <summary>
    ''' The dictionary of the EXIF metadata for the currently loaded image.
    ''' </summary>
    Private m_dictEXIF As Dictionary(Of String, String)
    ''' <summary>
    ''' The factor for zooming; The mousewheel delta (typically +/-120) for a single
    ''' wheel notch will be divided by this number and the result will be used as the
    ''' multiplier for the zooming operation. Higher number means lower zoom scale.
    ''' </summary>
    Private m_intZoomFactor As Integer = 100

    Private ptPanStartPoint As New Point
    Event ImageFormClosingEvent()

    ''' <summary>
    ''' Set up the image file to start with and it's path.
    ''' Sets up the indexing so that when LoadImage() is called
    ''' everything will work without further error checks.
    ''' </summary>
    ''' <param name="strFilePath">The full path to the image</param>
    ''' <param name="strFileName">The filename of the image without path information</param>
    Public Sub New(strFilePath As String, strFileName As String)
        InitializeComponent()

        ' Double-buffering. Trying to reduce flickering on zooms.
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)

        m_strImagePath = strFilePath
        m_strImageFile = Combine(m_strImagePath, strFileName)
        Dim allFiles As String() = Directory.GetFiles(m_strImagePath)
        m_lstImageFiles = New List(Of String)
        Dim imageFileDirectory As FileInfo() = New DirectoryInfo(m_strImagePath).GetFiles()
        Dim extension As String
        Dim extensionList As String() = {".jpg", ".png", ".tiff", ".bmp", ".gif"}
        Dim strCurrFile As String
        m_intImageIndex = 0
        For Each logFile As FileInfo In imageFileDirectory
            extension = GetExtension(logFile.Name)
            If extensionList.Contains(extension.ToLower()) Then
                strCurrFile = Combine(m_strImagePath, logFile.Name)
                m_lstImageFiles.Add(strCurrFile)
                If strCurrFile = m_strImageFile Then
                    m_intImageIndex = m_lstImageFiles.Count - 1
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Load the image which was set up in the constructor.
    ''' </summary>
    Private Sub frmImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadImage()
    End Sub

    ''' <summary>
    ''' Loads the image found in the m_strImagePath with the name m_strImageFile.
    ''' The previous and next buttons will be greyed out if the first or last
    ''' files respectively are being shown.
    ''' The filename will be placed on the title bar with the index number of the image.
    ''' </summary>
    Private Sub LoadImage()
        m_strImageFile = m_lstImageFiles.Item(m_intImageIndex)
        ZoomPictureBox1.Image = Image.FromFile(m_strImageFile)

        Text = m_strImageFile & " (" & m_intImageIndex + 1 & " of " & m_lstImageFiles.Count & ")"
        getEXIFData()

        '        ' TODO: Fix next line, I added a dim in there to make it compile
        '        Dim strTimeDateSource As String = "EXIF"
        '        intTimeSource = 3
        '        txtTimeSource.Text = strTimeDateSource
        '        'txtTimeSource.ForeColor = Color.LimeGreen
        '        'txtTime.ForeColor = Color.LimeGreen
        '        txtTimeSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
        '        txtTimeSource.BackColor = Color.LightGray
        '        txtTimeSource.ForeColor = Color.LimeGreen
        '        txtTimeSource.TextAlign = HorizontalAlignment.Center
        '        txtTime.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
        '        txtTime.BackColor = Color.LightGray
        '        txtTime.ForeColor = Color.LimeGreen
        '        txtTime.TextAlign = HorizontalAlignment.Center
        '        txtTransectDate.Text = m_transect_date
        '        txtDateSource.Text = strTimeDateSource
        '        txtDateSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
        '        txtDateSource.BackColor = Color.LightGray
        '        txtDateSource.ForeColor = Color.LimeGreen
        '        txtDateSource.TextAlign = HorizontalAlignment.Center

        ' Disable the buttons depending on what the image list holds.
        ' This method ensures that all cases are covered, eg: a single file
        ' in a directory should prompt these buttons to both be greyed out.
        btnPrev.Enabled = True
        btnNext.Enabled = True
        If m_intImageIndex = 0 Then
            btnPrev.Enabled = False
        End If
        If m_intImageIndex = m_lstImageFiles.Count - 1 Then
            btnNext.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Go back to the previous picture in the current image directory.
    ''' </summary>
    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        m_intImageIndex -= 1
        LoadImage()
    End Sub

    ''' <summary>
    ''' Go forward to the next picture in the current image directory.
    ''' </summary>
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        m_intImageIndex += 1
        LoadImage()
    End Sub

    ''' <summary>
    ''' Write the text of how many pictures there are and which one you're currently on
    ''' in the top left corner.
    ''' </summary>
    Private Sub ZoomPictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ZoomPictureBox1.Paint
        Dim g As Graphics = e.Graphics
        g.DrawString(m_intImageIndex + 1 & " of " & m_lstImageFiles.Count,
            New Font("Arial", 14), Brushes.Red, New PointF(30.0F, 30.0F))
        ' Example of how to draw a line in the ZoomPictureBox.
        'g.DrawLine(System.Drawing.Pens.Red, ZoomPictureBox1.Left,
        ' ZoomPictureBox1.Top, ZoomPictureBox1.Right, ZoomPictureBox1.Bottom)
    End Sub

    ''' <summary>
    ''' Retreives the EXIF metadata from the image file given by m_strImageFile in the
    ''' directory m_strImagePath and places the data into the dictionary m_dictEXIF.
    ''' </summary>
    Private Sub getEXIFData()
        'lblGPSLocation.Visible = False
        'lblX.Visible = False
        'lblXValue.Visible = False
        'lblY.Visible = False
        'lblYValue.Visible = False
        'lblZ.Visible = False
        'lblZValue.Visible = False
        ' Set up and run the EXIF tool for the file selected
        Dim strExeDirname As String = GetDirectoryName(System.Windows.Forms.Application.ExecutablePath.ToString())
        Dim strCommand As String = Combine(strExeDirname, EXIF_FILE_NAME)
        Dim strArguments As String = String.Concat(EXIF_ARGS, Combine(m_strImagePath, m_strImageFile))
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(strCommand)
        oStartInfo.Arguments = strArguments
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oStartInfo
        oProcess.StartInfo.CreateNoWindow = True
        oProcess.Start()
        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
        End Using

        ' The return value from the exif tool is one long string. Here we split it up based
        ' on newlines, and then clean out those newlines from the resulting list of strings.
        Dim strEXIFOutputRaw As List(Of String) = New List(Of String)(sOutput.Split(vbCrLf))
        Dim strEXIFOutput As List(Of String) = strEXIFOutputRaw.Select(Function(str) str.Replace(vbLf, "")).ToList()
        ' The next line removes any extraneous list items that are either null or the NULL_STRING
        strEXIFOutput.RemoveAll(Function(str) String.IsNullOrEmpty(str))
        ' Now a dictionary is created with the keys being the string before the colon
        ' and the value being what is after the colon. All whitespace is removed.
        m_dictEXIF = New Dictionary(Of String, String)
        Dim key As String
        Dim value As String
        For Each item As String In strEXIFOutput
            ' RightToLeft is required to make the regex have a rightwise-greedy match
            ' which has the effect of removing the whitespace from the keys and values.
            Dim r As Regex = New Regex("^(.+) +: +(.+)$", RegexOptions.RightToLeft)
            Dim match As Match = r.Match(item)
            If match.Success Then
                key = match.Groups(1).Value
                value = match.Groups(2).Value
                m_dictEXIF.Add(key, value)
            End If
        Next
        'Dim strDate As String = NULL_STRING
        'Dim strLine As String
        'Dim strItems() As String
        'Dim dblDegrees As Double
        'Dim dblMinutes As Double
        'Dim dblSeconds As Double
        'Dim strGPS As String
        'Dim strGPSSplit() As String
        'Dim intNegative As Integer = 1
        'Dim blDateTime As Boolean = False
        'Dim blFileDateTime As Boolean = False
        'Dim blX As Boolean = False
        'Dim blY As Boolean = False
        'Dim blZ As Boolean = False
        'Dim blFlag As Boolean = False
        'Dim strFileDate As String = NULL_STRING
        'Dim strFileTime As String = NULL_STRING
        '' Read the line that has "DateTimeOriginal".
        '' TODO: Go over this whole algorithm. It is a big mess.
        'Dim strPhotoDecimalTime As String
        'Dim i As Integer

        ' Here is an example of how to grab the values based on keys for the dictionary.
        'If dictEXIFOutput.ContainsKey("DateTimeOriginal") Then
        '    If dictEXIFOutput.ContainsKey("SubSec") Then

        '    Else
        '        strDate = dictEXIFOutput.Item("DateTimeOriginal")
        '    End If
        'End If

        '        strItems = strLine.Split(":")
        '        strDate = strItems(3).Substring(0, 2) & "/" & strItems(2) & "/" & strItems(1).Substring(1, 4)
        'm_transect_date = strDate

        '        strPhotoDecimalTime = m_tsUserTime.ToString()
        '        blDateTime = True
        '    ElseIf strEXIFOutput(i).Contains("DateTimeOriginal") And strEXIFOutput(i).Contains("SubSec") Then
        '        strLine = strEXIFOutput(i)
        '        strItems = strLine.Split(":")
        '        strDate = strItems(3).Substring(0, 2) & "/" & strItems(2) & "/" & strItems(1).Substring(1, 4)
        '        m_transect_date = strDate
        '        strPhotoDecimalTime = strItems(3).Substring(3, 2) & ":" & strItems(4) & ":" & strItems(5)
        '        'strPhotoTime = ToMilitaryTime(strPhotoDecimalTime)
        '        blDateTime = True
        '    ElseIf strEXIFOutput(i).Contains("FileCreateDate") Then
        '        strLine = strEXIFOutput(i)
        '        strItems = strLine.Split(":")
        '        strDate = strItems(3).Substring(0, 2) & "/" & strItems(2) & "/" & strItems(1).Substring(1, 4)
        '        strFileDate = strDate
        '        strFileTime = ToMilitaryTime(strItems(3).Substring(3, 2) & ":" & strItems(4) & ":" & strItems(5).Substring(0, 2))
        '        blFileDateTime = True
        '    ElseIf strEXIFOutput(i).Contains("GPSLatitude") And Not strEXIFOutput(i).Contains("Ref") Then
        '        strLine = strEXIFOutput(i)
        '        strItems = strLine.Split(":")
        '        strGPS = strItems(1).Replace(" ", NULL_STRING)
        '        If strGPS.Contains("N") Then
        '            intNegative = 1
        '            strGPS = strGPS.Replace("N", NULL_STRING)
        '        ElseIf strGPS.Contains("S") Then
        '            intNegative = -1
        '            strGPS = strGPS.Replace("S", NULL_STRING)
        '        End If
        '        strGPS = strGPS.Replace("deg", "/")
        '        strGPS = strGPS.Replace("'", "/")

        '        strGPSSplit = strGPS.Split("/")
        '        dblDegrees = CDbl(strGPSSplit(0))
        '        dblMinutes = CDbl(strGPSSplit(1))
        '        dblSeconds = CDbl(strGPSSplit(2))
        '        'strY = FormatNumber((dblDegrees + (dblMinutes / 60) + (dblSeconds / 3600)) * intNegative, 5)
        '        blY = True
        '        Me.lblGPSLocation.Visible = True
        '        Me.lblGPSLocation.Text = "EXIF Location"
        '        Me.lblY.Visible = True
        '        Me.lblYValue.Visible = True
        '    ElseIf strEXIFOutput(i).Contains("GPSLongitude") And Not strEXIFOutput(i).Contains("Ref") Then
        '        strLine = strEXIFOutput(i)
        '        strItems = strLine.Split(":")
        '        strGPS = strItems(1).Replace(" ", NULL_STRING)
        '        If strGPS.Contains("E") Then
        '            intNegative = 1
        '            strGPS = strGPS.Replace("E", NULL_STRING)
        '        ElseIf strGPS.Contains("W") Then
        '            intNegative = -1
        '            strGPS = strGPS.Replace("W", NULL_STRING)
        '        End If
        '        strGPS = strGPS.Replace("deg", "/")
        '        strGPS = strGPS.Replace("'", "/")
        '        strGPS = strGPS.Replace("W", NULL_STRING)
        '        strGPSSplit = strGPS.Split("/")
        '        dblDegrees = CDbl(strGPSSplit(0))
        '        dblMinutes = CDbl(strGPSSplit(1))
        '        dblSeconds = CDbl(strGPSSplit(2))
        '        'strX = FormatNumber((dblDegrees + (dblMinutes / 60) + (dblSeconds / 3600)) * intNegative, 5)
        '        blX = True
        '        Me.lblGPSLocation.Visible = True
        '        Me.lblGPSLocation.Text = "EXIF Location"
        '        Me.lblX.Visible = True
        '        Me.lblXValue.Visible = True
        '    ElseIf strEXIFOutput(i).Contains("GPSAltitude") And Not strEXIFOutput(i).Contains("Ref") Then
        '        strLine = strEXIFOutput(i)
        '        strItems = strLine.Split(":")
        '        strGPS = strItems(1).Replace(" ", NULL_STRING)
        '        If strGPS.Contains("AboveSeaLevel") Then
        '            intNegative = 1
        '            strGPS = strGPS.Replace("AboveSeaLevel", NULL_STRING)
        '        ElseIf strGPS.Contains("BelowSeaLevel") Then
        '            intNegative = -1
        '            strGPS = strGPS.Replace("BelowSeaLevel", NULL_STRING)
        '        End If
        '        strGPS = strGPS.Replace("m", NULL_STRING)
        '        ' TODO: See what this does
        '        'strZ = FormatNumber(CDbl(strGPS) * intNegative, 2)
        '        blZ = True
        '        Me.lblGPSLocation.Visible = True
        '        Me.lblGPSLocation.Text = "EXIF Location"
        '        Me.lblZ.Visible = True
        '        Me.lblZValue.Visible = True
        '    End If
        '    intNegative = 1
        'Next
        'If blImageWarning = True Then
        '    Dim strMessage As String
        '    strMessage = "The following values were not found within the EXIF file, they will be set to blank:"

        '    If blDateTime = False Then
        '        If blFileDateTime = False Then
        '            strMessage = strMessage & vbCrLf & "Date and Time"
        '            m_transect_date = NULL_STRING
        '            'strPhotoTime = NULL_STRING
        '        Else
        '            m_transect_date = strFileDate
        '            'strPhotoTime = strFileTime
        '            strPhotoDecimalTime = m_tsUserTime.ToString()
        '        End If
        '    End If
        '            If blX = False Then
        ' strMessage = strMessage & vbCrLf & "X"
        '        End If
        '       If blY = False Then
        '          strMessage = strMessage & vbCrLf & "Y"
        '         strY = NULL_STRING
        '    End If
        '            If blZ = False Then
        'strMessage = strMessage & vbCrLf & "Z"
        'strZ = NULL_STRING
        'End If
        'strMessage = strMessage & vbCrLf & vbCrLf & "Do you wish to disable this warning for future images?"
        'If Not blDateTime Or Not blX Or Not blY Or Not blZ Then
        '    Dim intAnswer As Integer
        '    intAnswer = MessageBox.Show(strMessage, "Invalid EXIF Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        '    If intAnswer = vbYes Then
        '        blImageWarning = False
        '    End If
        'End If
        'End If
    End Sub


    Private Sub frmImage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RaiseEvent ImageFormClosingEvent()
    End Sub

    'Private Sub VideoMiner_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    '    Dim intIndex As Integer
    '    'MsgBox(strKeyboardShortcut)
    '    'MsgBox(e.KeyData)
    '    Select Case strKeyboardShortcut
    '        Case Keys.Space.ToString
    '            blHandled = True
    '            e.Handled = True
    '            If m_video_file_open Then
    '                If Not frmVideoPlayer.IsPlaying Then
    '                    playVideo()
    '                Else
    '                    pauseVideo()
    '                End If
    '            End If
    '        Case Keys.Enter.ToString
    '            MsgBox("Enter")
    '        Case Keys.Right.ToString
    '            blHandled = True
    '            e.Handled = True
    '            Dim intAnswer As Integer
    '            If image_open Then
    '                If (m_intImageIndex + 1) > (m_lstImageFiles.Count - 1) Then
    '                    intAnswer = MessageBox.Show("You have reached the last image in the folder, would you like to start again at the first image?", "Last Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                    If intAnswer = vbYes Then
    '                        m_intImageIndex = 0
    '                    Else
    '                        Exit Sub
    '                    End If
    '                Else
    '                    m_intImageIndex += 1
    '                End If
    '                LoadImg()
    '            End If
    '        Case Keys.Left.ToString
    '            blHandled = True
    '            e.Handled = True
    '            Dim intAnswer As Integer
    '            If image_open Then
    '                If (m_intImageIndex - 1) < 0 Then
    '                    intAnswer = MessageBox.Show("You have reached the first image in the folder, would you like to start again at the last image?", "First Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                    If intAnswer = vbYes Then
    '                        m_intImageIndex = m_lstImageFiles.Count - 1
    '                    Else
    '                        Exit Sub
    '                    End If
    '                Else
    '                    m_intImageIndex -= 1
    '                End If
    '                LoadImg()
    '            End If
    '        Case "Menu"
    '            e.SuppressKeyPress = True
    '        Case Else
    '            If strKeyboardShortcut <> NULL_STRING Then
    '                Dim d As DataTable = Database.GetDataTable("select DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor, KeyboardShortcut from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", DB_SPECIES_BUTTONS_TABLE)
    '                For Each r As DataRow In d.Rows
    '                    If r.Item("KeyboardShortcut").ToString = strKeyboardShortcut Then
    '                        intIndex = CInt(r.Item("DrawingOrder")) - 1
    '                        If Not speciesButtons(intIndex) Is Nothing Then
    '                            'SpeciesVariableButtonHandler(speciesButtons(intIndex), Nothing)
    '                        End If
    '                        Exit For
    '                    End If
    '                Next
    '            End If
    '    End Select
    '    strKeyboardShortcut = NULL_STRING
    '    strCurrentKey = NULL_STRING
    'End Sub

    ''' <summary>
    ''' Accept function keypresses in the form. The F1-F12 keys allow quick access to images 0-11.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmImage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyValue
            Case Keys.F1
                m_intImageIndex = 0
            Case Keys.F2
                m_intImageIndex = 1
            Case Keys.F3
                m_intImageIndex = 2
            Case Keys.F4
                m_intImageIndex = 3
            Case Keys.F5
                m_intImageIndex = 4
            Case Keys.F6
                m_intImageIndex = 5
            Case Keys.F7
                m_intImageIndex = 6
            Case Keys.F8
                m_intImageIndex = 7
            Case Keys.F9
                m_intImageIndex = 8
            Case Keys.F10
                m_intImageIndex = 19
            Case Keys.F11
                m_intImageIndex = 10
            Case Keys.F12
                m_intImageIndex = 11
        End Select
        LoadImage()
    End Sub

    ''' <summary>
    ''' Accepts the right and left arrow keys to make moving to previous and next images easier.
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim keyPressed As Keys = CType(msg.WParam.ToInt32(), Keys)
        Select Case keyPressed
            Case Keys.Right
                m_intImageIndex += 1
                LoadImage()
            Case Keys.Left
                m_intImageIndex -= 1
                LoadImage()
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class