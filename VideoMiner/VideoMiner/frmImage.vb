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
    ''' The factor for zooming; The mousewheel delta will be divided by this number.
    ''' </summary>
    Private m_intZoomFactor As Integer = 10

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
        PictureBox1.Image = Image.FromFile(m_strImageFile)
        ScaleImage()

        Text = m_strImageFile & " (" & m_intImageIndex + 1 & " of " & m_lstImageFiles.Count & ")"
        getEXIFData()

        '    ' Detemine the size of the image shown in the window
        '    Dim w, h As Integer

        '    Select Case Me.cboZoom.SelectedItem
        '        Case "25%"
        '            w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width / 4
        '            h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height / 4
        '        Case "50%"
        '            w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width / 2
        '            h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height / 2
        '        Case "75%"
        '            w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width / 1.3333
        '            h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height / 1.3333
        '        Case "100%"
        '            w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width
        '            h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height
        '        Case "200%"
        '            w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width * 2
        '            h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height * 2
        '        Case Else
        '            Dim intValue As Integer
        '            Dim dblImageSize As Double
        '            intValue = cboZoom.Text.Substring(0, cboZoom.Text.Length - 1)

        '            If intValue <= 100 Then
        '                dblImageSize = 100 / intValue
        '                w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width / dblImageSize
        '                h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height / dblImageSize
        '            Else
        '                dblImageSize = intValue / 100
        '                w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width * dblImageSize
        '                h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height * dblImageSize
        '            End If
        '    End Select
        '    Try
        '        ' Display the image in the picture box.
        '        'Dim bmp As Bitmap = New Bitmap(Image.FromFile(currentImage), w, h)
        '        'Dim g As Graphics = Graphics.FromImage(bmp)
        '        'frmImage.PictureBox1.Image.Dispose()
        '        'frmImage.PictureBox1.Image = Nothing
        '        'GC.Collect()
        '        'frmImage.PictureBox1.Image = bmp
        '        'frmImage.Text = Me.fileNames(m_intImageIndex)
        '        'blSizeChanged = True
        '        frmImage.PictureBox1.Image.Dispose()
        '        frmImage.PictureBox1.Image = Nothing
        '        GC.Collect()

        '        Dim Dir As String = m_lstImageFiles(m_intImageIndex)
        '        Dim bmp As Bitmap = New Bitmap(Image.FromFile(Dir), w, h)
        '        Dim g As Graphics = Graphics.FromImage(bmp)
        '        frmImage.PictureBox1.Image = bmp
        '        frmImage.Text = m_lstImageFiles(m_intImageIndex)
        '        VideoFileName = m_lstImageFiles(m_intImageIndex)
        '        currentImage = m_lstImageFiles(m_intImageIndex)
        '        getEXIFData()
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
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try

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

    Private Sub pictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        'Whenever the 
        ' Create a local version of the graphics object for the PictureBox.

        'Dim g As Graphics = e.Graphics
        ' Draw a string on the PictureBox.
        'g.DrawString("This is a diagonal line drawn on the control",
        'New Font("Arial", 10), Brushes.Red, New PointF(30.0F, 30.0F))
        ' Draw a line in the PictureBox.
        'g.DrawLine(System.Drawing.Pens.Red, PictureBox1.Left,
        ' PictureBox1.Top, PictureBox1.Right, PictureBox1.Bottom)
    End Sub

    ''' <summary>
    ''' Required to make the mouse wheel zooming work
    ''' </summary>
    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.Focus()
    End Sub

    Private Sub PictureBox_MouseWheel(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseWheel
        ' Get current mouse position reletive to the picturebox
        Dim pntMousePosition As Drawing.Point = MousePosition
        ' Set up the new bounds of the picture, based on the e.Delta value
        ' which is how much the wheel was moved

        'Dim ZoomFactor As Double = ZoomFactor + (e.Delta / 10)
        'SplitContainer1.Panel1.AutoScroll = False
        'SplitContainer1.Panel1.AutoScroll = True
    End Sub

    Private Sub ScaleImage()
        Dim imageSize As Size = PictureBox1.Image.Size
        ' Dim aspectRatio As Double = imageSize.Height / imageSize.Width
        Dim dblScaleHeight As Double = PictureBox1.Height / imageSize.Height
        Dim dblScaleWidth As Double = PictureBox1.Width / imageSize.Width
        Dim dblScale As Double = Math.Min(dblScaleHeight, dblScaleWidth)
        Dim intNewHeight As Integer = Math.Floor(imageSize.Height * dblScale)
        Dim intNewWidth As Integer = Math.Floor(imageSize.Width * dblScale)
        Dim bmpResized As Bitmap = New Bitmap(PictureBox1.Image, New Size(intNewWidth, intNewHeight))
        PictureBox1.Image = bmpResized

        'If imageSize.Height > PictureBox1.Height Then
        '    Dim diff As Integer = imageSize.Height - PictureBox1.Height
        '    Dim bmpResized As Bitmap = New Bitmap(imageSize, New Size(imageSize.Width - diff, imageSize.Height - diff))
        '    PictureBox1.Image = bmpResized
        'End If
        'If i.Width > PictureBox1.Width Then
        '    Dim diff As Integer = i.Width - PictureBox1.Width
        '    Dim Resized As Bitmap = New Bitmap(i, New Size(i.Width - diff, i.Height - diff))
        '    i = Resized
        'End If
        'PictureBox1.Width = Convert.ToInt32(Math.Round(Me.PictureBox1.Height / aspectRatio))
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

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        ptPanStartPoint = New Point(e.X, e.Y)
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim DeltaX As Integer = (ptPanStartPoint.X - e.X)
            Dim DeltaY As Integer = (ptPanStartPoint.Y - e.Y)
            SplitContainer1.Panel1.AutoScrollPosition = New Drawing.Point((DeltaX - SplitContainer1.Panel1.AutoScrollPosition.X), (DeltaY - SplitContainer1.Panel1.AutoScrollPosition.Y))
        End If
    End Sub

    'Private Sub cboZoom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZoom.KeyPress
    '    numericTextboxValidation(e)
    'End Sub

    'Private Sub cboZoom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZoom.LostFocus
    '    Me.cboZoom.SelectedIndex = intCurrentZoom
    'End Sub

    'Private Sub cboZoom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZoom.SelectedIndexChanged

    '    If Me.pnlImageControls.Visible = True Then
    '        Dim w As Integer
    '        Dim h As Integer

    '        Select Case Me.cboZoom.SelectedItem
    '            Case "25%"
    '                w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width / 4
    '                h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height / 4
    '            Case "50%"
    '                w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width / 2
    '                h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height / 2
    '            Case "75%"
    '                w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width / 1.3333
    '                h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height / 1.3333
    '            Case "100%"
    '                w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width
    '                h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height
    '            Case "200%"
    '                w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width * 2
    '                h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height * 2
    '            Case Else
    '                Dim intValue As Integer
    '                Dim dblImageSize As Double
    '                intValue = cboZoom.Text.Substring(0, cboZoom.Text.Length - 1)

    '                If intValue <= 100 Then
    '                    dblImageSize = 100 / intValue
    '                    w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width / dblImageSize
    '                    h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height / dblImageSize
    '                Else
    '                    dblImageSize = intValue / 100
    '                    w = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Width * dblImageSize
    '                    h = Image.FromFile(m_lstImageFiles(m_intImageIndex)).Height * dblImageSize
    '                End If
    '        End Select

    '        redraw_Image(w, h)

    '        intCurrentZoom = Me.cboZoom.SelectedIndex
    '    End If

    'End Sub

    '''' <summary>
    '''' This Function is the common part For the Next 4 functions.
    '''' Basic it takes the width Of height Of the image And redraw the
    '''' Image inside the display window.
    '''' </summary>
    '''' <param name="w"></param>
    '''' <param name="h"></param>
    Public Sub redraw_Image(ByVal w As Integer, ByVal h As Integer)
        Try
            Dim bmp As Bitmap = New Bitmap(Image.FromFile(m_lstImageFiles(m_intImageIndex)), w, h)
            Dim g As Graphics = Graphics.FromImage(bmp)
            PictureBox1.Image.Dispose()
            PictureBox1.Image = Nothing
            GC.Collect()
            PictureBox1.Width = w
            PictureBox1.Height = h
            PictureBox1.Image = bmp
            'blSizeChanged = True
        Catch ex As Exception
            MsgBox("The image size you selected is too big, please try again")
            'blSizeChanged = False
            Exit Sub
        End Try

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
    Private Sub frmImage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim intIndex As Integer
        Select Case e.KeyValue
            Case Keys.F1
                intIndex = 0
            Case Keys.F2
                intIndex = 1
            Case Keys.F3
                intIndex = 2
            Case Keys.F4
                intIndex = 3
            Case Keys.F5
                intIndex = 4
            Case Keys.F6
                intIndex = 5
            Case Keys.F7
                intIndex = 6
            Case Keys.F8
                intIndex = 7
            Case Keys.F9
                intIndex = 8
            Case Keys.F10
                intIndex = 19
            Case Keys.F11
                intIndex = 10
            Case Keys.F12
                intIndex = 11
            Case Else
                Exit Sub
        End Select

        ' CJG while removing myformslibrary
        'Try
        '    If Not myFormLibrary.frmVideoMiner.speciesButtons(intIndex) Is Nothing Then
        '        myFormLibrary.frmVideoMiner.SpeciesVariableButtonHandler(myFormLibrary.frmVideoMiner.speciesButtons(intIndex), Nothing)
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    ' CJG while removing myformslibrary
    ' TODO: Fix this!!!
    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
    '    Dim keyPressed As Keys = CType(msg.WParam.ToInt32(), Keys)
    '    Dim intAnswer As Integer

    '    Select Case keyPressed
    '        Case Keys.Right
    '            If (myFormLibrary.frmVideoMiner.image_index + 1) > (myFormLibrary.frmVideoMiner.imageFilesList.Count - 1) Then
    '                intAnswer = MessageBox.Show("You have reached the last image in the folder, would you like to start again at the first image?", "Last Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                If intAnswer = vbYes Then
    '                    myFormLibrary.frmVideoMiner.image_index = 0
    '                Else
    '                    Exit Function
    '                End If
    '            Else
    '                myFormLibrary.frmVideoMiner.image_index += 1
    '            End If
    '            myFormLibrary.frmVideoMiner.LoadImg()

    '        Case Keys.Left
    '            If (myFormLibrary.frmVideoMiner.image_index - 1) < 0 Then
    '                intAnswer = MessageBox.Show("You have reached the first image in the folder, would you like to start again at the last image?", "First Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                If intAnswer = vbYes Then
    '                    myFormLibrary.frmVideoMiner.image_index = myFormLibrary.frmVideoMiner.imageFilesList.Count - 1
    '                Else
    '                    Exit Function
    '                End If
    '            Else
    '                myFormLibrary.frmVideoMiner.image_index -= 1
    '            End If
    '            myFormLibrary.frmVideoMiner.LoadImg()

    '        Case Else
    '            Return MyBase.ProcessCmdKey(msg, keyData)

    '    End Select
    'End Function

End Class