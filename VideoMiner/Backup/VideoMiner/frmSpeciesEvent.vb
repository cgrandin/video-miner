' ==========================================================================================================
' Name: SpeciesEventForm
' Description: This is a form that is loaded when the user selects a species from panel 2 while 
'              reviewing a video if detailed entry radio button is selected. The user can enter 
'              details about the sighting such as side, range,count, length, id confidence, 
'              height, and width. 
' ==========================================================================================================
Imports System.Data.OleDb

Public Class frmSpeciesEvent


#Region "Fields"
    Private m_SpeciesName As String
    Private m_SpeciesCode As String

    Private m_RangeChecked As Boolean
    Private m_IDConfidenceChecked As Boolean
    Private m_AbundanceChecked As Boolean
    Private m_CountChecked As Boolean
    Private m_HeightChecked As Boolean
    Private m_WidthChecked As Boolean
    Private m_LengthChecked As Boolean
    Private m_CommentsChecked As Boolean

    Private m_Range As String
    Private m_Side As String
    Private m_IDConfidence As String
    Private m_Abundance As String
    Private m_Count As String
    Private m_Height As String
    Private m_Width As String
    Private m_Length As String
    Private m_Comments As String

#End Region

#Region "Properties"

    Public Property SpeciesName() As String
        Get
            Return m_SpeciesName
        End Get
        Set(ByVal value As String)
            m_SpeciesName = value
        End Set
    End Property

    Public Property SpeciesCode() As String
        Get
            Return m_SpeciesCode
        End Get
        Set(ByVal value As String)
            m_SpeciesCode = value
        End Set
    End Property


    Public Property RangeChecked() As Boolean
        Get
            Return m_RangeChecked
        End Get
        Set(ByVal value As Boolean)
            m_RangeChecked = value
        End Set
    End Property

    Public Property IDConfidenceChecked() As Boolean
        Get
            Return m_IDConfidenceChecked
        End Get
        Set(ByVal value As Boolean)
            m_IDConfidenceChecked = value
        End Set
    End Property

    Public Property AbundanceChecked() As Boolean
        Get
            Return m_AbundanceChecked
        End Get
        Set(ByVal value As Boolean)
            m_AbundanceChecked = value
        End Set
    End Property

    Public Property CountChecked() As Boolean
        Get
            Return m_CountChecked
        End Get
        Set(ByVal value As Boolean)
            m_CountChecked = value
        End Set
    End Property

    Public Property HeightChecked() As Boolean
        Get
            Return m_HeightChecked
        End Get
        Set(ByVal value As Boolean)
            m_HeightChecked = value
        End Set
    End Property

    Public Property WidthChecked() As Boolean
        Get
            Return m_WidthChecked
        End Get
        Set(ByVal value As Boolean)
            m_WidthChecked = value
        End Set
    End Property

    Public Property LengthChecked() As Boolean
        Get
            Return m_LengthChecked
        End Get
        Set(ByVal value As Boolean)
            m_LengthChecked = value
        End Set
    End Property

    Public Property CommentsChecked() As Boolean
        Get
            Return m_CommentsChecked
        End Get
        Set(ByVal value As Boolean)
            m_CommentsChecked = value
        End Set
    End Property


    Public Property Range() As String
        Get
            Return m_Range
        End Get
        Set(ByVal value As String)
            m_Range = value
        End Set
    End Property

    Public Property Side() As String
        Get
            Return m_Side
        End Get
        Set(ByVal value As String)
            m_Side = value
        End Set
    End Property

    Public Property IDConfidence() As String
        Get
            Return m_IDConfidence
        End Get
        Set(ByVal value As String)
            m_IDConfidence = value
        End Set
    End Property

    Public Property Abundance() As String
        Get
            Return m_Abundance
        End Get
        Set(ByVal value As String)
            m_Abundance = value
        End Set
    End Property

    Public Property Count() As String
        Get
            Return m_Count
        End Get
        Set(ByVal value As String)
            m_Count = value
        End Set
    End Property

    Public Property SpeciesHeight() As String
        Get
            Return m_Height
        End Get
        Set(ByVal value As String)
            m_Height = value
        End Set
    End Property

    Public Property SpeciesWidth() As String
        Get
            Return m_Width
        End Get
        Set(ByVal value As String)
            m_Width = value
        End Set
    End Property

    Public Property Length() As String
        Get
            Return m_Length
        End Get
        Set(ByVal value As String)
            m_Length = value
        End Set
    End Property

    Public Property Comments() As String
        Get
            Return m_Comments
        End Get
        Set(ByVal value As String)
            m_Comments = value
        End Set
    End Property


#End Region



    Private Const NULL_STRING As String = ""
    Private Const COUNT_STRING As String = "1"
    Private Const LENGTH_STRING As String = "0"
    Private Const CENTER_SIDE As Integer = 0
    Private Const PORT_SIDE As Integer = 1
    Private Const STARBOARD_SIDE As Integer = 2

    Private centerButtonPressed As Boolean
    Private values_set As Boolean
    Private clControlNames As New Collection
    Private clControlValues As New Collection
    Private clLabelNames As New Collection


    Private Sub getProperties()


        Me.RangeChecked = myFormLibrary.frmVideoMiner.RangeChecked
        Me.IDConfidenceChecked = myFormLibrary.frmVideoMiner.IDConfidenceChecked
        Me.AbundanceChecked = myFormLibrary.frmVideoMiner.AbundanceChecked
        Me.CountChecked = myFormLibrary.frmVideoMiner.CountChecked
        Me.HeightChecked = myFormLibrary.frmVideoMiner.HeightChecked
        Me.WidthChecked = myFormLibrary.frmVideoMiner.WidthChecked
        Me.LengthChecked = myFormLibrary.frmVideoMiner.LengthChecked
        Me.CommentsChecked = myFormLibrary.frmVideoMiner.CommentsChecked

        Me.Range = checkActivated(myFormLibrary.frmVideoMiner.Range, Me.RangeChecked)
        Me.Side = checkActivated(myFormLibrary.frmVideoMiner.Side, Me.RangeChecked)
        Me.IDConfidence = checkActivated(myFormLibrary.frmVideoMiner.IDConfidence, Me.IDConfidenceChecked)
        Me.Abundance = checkActivated(myFormLibrary.frmVideoMiner.Abundance, Me.AbundanceChecked)
        Me.Count = checkActivated(myFormLibrary.frmVideoMiner.Count, Me.CountChecked)
        Me.SpeciesHeight = checkActivated(myFormLibrary.frmVideoMiner.SpeciesHeight, Me.HeightChecked)
        Me.SpeciesWidth = checkActivated(myFormLibrary.frmVideoMiner.SpeciesWidth, Me.WidthChecked)
        Me.Length = checkActivated(myFormLibrary.frmVideoMiner.Length, Me.LengthChecked)
        Me.Comments = checkActivated(myFormLibrary.frmVideoMiner.Comments, Me.CommentsChecked)


    End Sub

    Private Function checkActivated(ByVal strValue As String, ByVal blActive As Boolean)

        If blActive Then
            Return strValue
        Else
            Return ""
        End If

    End Function

    Private Sub loadCollection()

        If Me.RangeChecked Then
            clControlNames.Add("txtRange")
            clControlNames.Add("cboSide")
            clControlValues.Add(Range)
            clControlValues.Add(Side)
            clLabelNames.Add("Range")
            clLabelNames.Add("Side")
        End If

        If Me.IDConfidenceChecked Then
            clControlNames.Add("cboIDConfidence")
            clControlValues.Add(IDConfidence)
            clLabelNames.Add("ID Confidence")
        End If

        If Me.AbundanceChecked Then
            clControlNames.Add("cboAbundance")
            clControlValues.Add(Abundance)
            clLabelNames.Add("Abundance")
        End If

        If Me.CountChecked Then
            clControlNames.Add("txtCount")
            clControlValues.Add(Count)
            clLabelNames.Add("Count")
        End If

        If Me.HeightChecked Then
            clControlNames.Add("txtHeight")
            clControlValues.Add(SpeciesHeight)
            clLabelNames.Add("Height")
        End If

        If Me.WidthChecked Then
            clControlNames.Add("txtWidth")
            clControlValues.Add(SpeciesWidth)
            clLabelNames.Add("Width")
        End If

        If Me.LengthChecked Then
            clControlNames.Add("txtLength")
            clControlValues.Add(Length)
            clLabelNames.Add("Length")
        End If

        If Me.CommentsChecked Then
            clControlNames.Add("txtComments")
            clControlValues.Add(Comments)
            clLabelNames.Add("Comments")
        End If

        Dim i As Integer

        For i = 1 To clControlValues.Count
            If clControlValues.Item(i) = "NULL" Then

            End If
        Next

    End Sub

    Private Sub fillSpeciesEventPanel()


        Dim speciesControl As Control
        Dim row As DataRow
        Dim dt As DataTable

        Dim speciesTextBox As TextBox
        Dim speciesRichTextBox As RichTextBox
        Dim speciesEventComboBox As ComboBox
        Dim speciesEventLabel As Label
        Dim i As Integer
        Dim j As Integer

        Dim h As Integer = pnlSpeciesEvent.Height
        Dim sizex As Integer = 76
        Dim sizey As Integer = 21
        Dim gapy As Integer = 30
        Dim gapx As Integer = 20

        Dim intAdd As Integer = 0
        Dim intMultiply As Integer = 0
        Dim strButtonText As String = ""

        Dim intColumnCount As Integer
        Dim intCountPerColumn As Integer

        Dim blNumeric As Boolean = False

        Dim speciesFont As Font = New Font("Microsoft Sans Serif", 10.8, FontStyle.Bold)

        intColumnCount = 2
        intCountPerColumn = (clControlNames.Count / intColumnCount)

        For j = 1 To clControlNames.Count

            Select Case clControlNames.Item(j)

                Case "txtRange"

                    speciesTextBox = New TextBox
                    speciesEventLabel = New Label
                    speciesTextBox.Name = clControlNames.Item(j)
                    speciesEventLabel.Text = clLabelNames.Item(j)
                    speciesTextBox.Width = 121
                    speciesTextBox.Font = speciesFont

                    speciesTextBox.Text = clControlValues.Item(j)

                    speciesControl = speciesTextBox
                    blNumeric = True

                Case "cboSide"

                    speciesEventComboBox = New ComboBox
                    speciesEventLabel = New Label
                    speciesEventComboBox.Name = clControlNames.Item(j)
                    speciesEventLabel.Text = clLabelNames.Item(j)
                    speciesEventComboBox.Width = 121
                    speciesEventComboBox.Font = speciesFont
                    speciesEventComboBox.DropDownStyle = ComboBoxStyle.DropDownList

                    speciesEventComboBox.Items.Add("On Center")
                    speciesEventComboBox.Items.Add("Port")
                    speciesEventComboBox.Items.Add("Starboard")

                    speciesEventComboBox.SelectedIndex = clControlValues.Item(j)

                    If speciesEventComboBox.SelectedIndex = 0 Then
                        pnlSpeciesEvent.Controls.Item("txtRange").Text = ""
                        pnlSpeciesEvent.Controls.Item("txtRange").Enabled = False
                        Me.Range = ""
                    End If

                    AddHandler speciesEventComboBox.SelectedIndexChanged, AddressOf sideControl

                    speciesControl = speciesEventComboBox

                Case "cboIDConfidence"

                    speciesEventComboBox = New ComboBox
                    speciesEventLabel = New Label
                    speciesEventComboBox.Name = clControlNames.Item(j)
                    speciesEventLabel.Text = clLabelNames.Item(j)
                    Dim ConfID_data_set As DataSet = New DataSet
                    Dim ConfID_db_command As OleDbCommand = New OleDbCommand("SELECT ConfidenceID, ConfidenceIdDescription FROM " & DB_CONFIDENCE_IDS_TABLE & " ORDER BY ConfidenceID;", conn)
                    Dim ConfID_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(ConfID_db_command)
                    ConfID_data_adapter.Fill(ConfID_data_set, DB_CONFIDENCE_IDS_TABLE)

                    dt = ConfID_data_set.Tables(0)
                    For Each row In dt.Rows
                        speciesEventComboBox.Items.Add(New ValueDescriptionPair(row.Item(0).ToString(), row.Item(1).ToString()))
                    Next

                    speciesEventComboBox.Font = speciesFont
                    speciesEventComboBox.DropDownStyle = ComboBoxStyle.DropDownList

                    speciesEventComboBox.Text = clControlValues.Item(j)

                    speciesControl = speciesEventComboBox

                Case "cboAbundance"

                    speciesEventComboBox = New ComboBox
                    speciesEventLabel = New Label
                    speciesEventComboBox.Name = clControlNames.Item(j)
                    speciesEventLabel.Text = clLabelNames.Item(j)
                    Dim Abundance_Data_Set As DataSet = New DataSet
                    Dim Abundance_db_command As OleDbCommand = New OleDbCommand("SELECT ACFORScaleID, ACFORScaleDescription FROM " & DB_ABUNDANCE_TABLE & " ORDER BY ACFORScaleID;", conn)
                    Dim Abundance_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(Abundance_db_command)
                    Abundance_data_adapter.Fill(Abundance_Data_Set, DB_ABUNDANCE_TABLE)

                    dt = Nothing
                    row = Nothing

                    dt = Abundance_Data_Set.Tables(0)
                    For Each row In dt.Rows
                        speciesEventComboBox.Items.Add(New ValueDescriptionPair(row.Item(0).ToString(), row.Item(1).ToString()))
                    Next

                    speciesEventComboBox.Font = speciesFont
                    speciesEventComboBox.DropDownStyle = ComboBoxStyle.DropDownList

                    speciesEventComboBox.Text = clControlValues.Item(j)

                    speciesControl = speciesEventComboBox

                Case "txtCount"

                    speciesTextBox = New TextBox
                    speciesEventLabel = New Label
                    speciesTextBox.Name = clControlNames.Item(j)
                    speciesEventLabel.Text = clLabelNames.Item(j)
                    speciesTextBox.Width = 121
                    speciesTextBox.Font = speciesFont

                    speciesTextBox.Text = clControlValues.Item(j)

                    speciesControl = speciesTextBox

                    blNumeric = True

                Case "txtHeight"

                    speciesTextBox = New TextBox
                    speciesEventLabel = New Label
                    speciesTextBox.Name = clControlNames.Item(j)
                    speciesEventLabel.Text = clLabelNames.Item(j)
                    speciesTextBox.Width = 121
                    speciesTextBox.Font = speciesFont

                    speciesTextBox.Text = clControlValues.Item(j)

                    speciesControl = speciesTextBox

                    blNumeric = True

                Case "txtWidth"

                    speciesTextBox = New TextBox
                    speciesEventLabel = New Label
                    speciesTextBox.Name = clControlNames.Item(j)
                    speciesEventLabel.Text = clLabelNames.Item(j)
                    speciesTextBox.Width = 121
                    speciesTextBox.Font = speciesFont

                    speciesTextBox.Text = clControlValues.Item(j)

                    speciesControl = speciesTextBox

                    blNumeric = True

                Case "txtLength"

                    speciesTextBox = New TextBox
                    speciesEventLabel = New Label
                    speciesTextBox.Name = clControlNames.Item(j)
                    speciesEventLabel.Text = clLabelNames.Item(j)
                    speciesTextBox.Width = 121
                    speciesTextBox.Font = speciesFont

                    speciesTextBox.Text = clControlValues.Item(j)

                    speciesControl = speciesTextBox

                    blNumeric = True

                Case "txtComments"

                    speciesRichTextBox = New RichTextBox
                    speciesEventLabel = New Label
                    speciesRichTextBox.Name = clControlNames.Item(j)
                    speciesEventLabel.Text = clLabelNames.Item(j)
                    speciesRichTextBox.Font = speciesFont
                    speciesRichTextBox.Width = 261

                    speciesRichTextBox.Text = clControlValues.Item(j)

                    speciesControl = speciesRichTextBox
                    intMultiply += 1
                    intAdd += 1

            End Select


            Dim cellsizex = sizex + gapx
            Dim cellsizey = sizey + gapy



            If i Mod intColumnCount = 0 Or speciesControl.Name = "txtComments" Then
                speciesControl.Location = New System.Drawing.Point(gapx, 20 + gapy + (cellsizey * intMultiply))
                speciesEventLabel.Location = New System.Drawing.Point(speciesControl.Location.X, speciesControl.Location.Y - 15)
            Else
                speciesControl.Location = New System.Drawing.Point(140 + gapx, 20 + gapy + (cellsizey * intMultiply))
                speciesEventLabel.Location = New System.Drawing.Point(speciesControl.Location.X, speciesControl.Location.Y - 15)
            End If

            'AddHandler speciesControl.Leave, AddressOf LostFocusControlHandler
            If blNumeric = True Then
                AddHandler speciesControl.KeyPress, AddressOf numericTextboxValidation
            End If

            pnlSpeciesEvent.Controls.Add(speciesControl)
            pnlSpeciesEvent.Controls.Add(speciesEventLabel)

            If i Mod intColumnCount = intColumnCount - 1 Then
                intAdd += intColumnCount
                intMultiply += 1
            End If

            i = i + 1

            blNumeric = False

        Next

        For i = 0 To pnlSpeciesEvent.Controls.Count - 1

            If pnlSpeciesEvent.Controls.Item(i).Text = "NULL" Then
                pnlSpeciesEvent.Controls.Item(i).Text = ""
            End If

        Next

    End Sub

    Private Sub GetSpeciesVariables()

        Try
            Dim ctlControl As Control
            Dim ctlSpeciesControl As Control
            Dim row As DataRow
            Dim dt As DataTable

            For Each ctlControl In myFormLibrary.frmSpeciesEvent.pnlSpeciesEvent.Controls

                ctlSpeciesControl = ctlControl

                Select Case ctlSpeciesControl.Name
                    Case "txtRange"

                        Me.Range = ctlSpeciesControl.Text

                    Case "cboSide"

                        Select Case ctlSpeciesControl.Text
                            Case "On Center"
                                Me.Side = "0"
                            Case "Port"
                                Me.Side = "1"
                            Case "Starboard"
                                Me.Side = "2"
                        End Select
                    Case "cboIDConfidence"
                        Dim ConfID_data_set As DataSet = New DataSet
                        Dim ConfID_db_command As OleDbCommand = New OleDbCommand("SELECT ConfidenceID, ConfidenceIdDescription FROM " & DB_CONFIDENCE_IDS_TABLE & " WHERE ConfidenceIdDescription = " & SingleQuote(ctlSpeciesControl.Text) & ";", conn)
                        Dim ConfID_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(ConfID_db_command)
                        ConfID_data_adapter.Fill(ConfID_data_set, DB_CONFIDENCE_IDS_TABLE)

                        dt = Nothing
                        dt = ConfID_data_set.Tables(0)
                        Me.IDConfidence = dt.Rows.Item(0).Item(0).ToString()

                    Case "cboAbundance"

                        Dim Abundance_Data_Set As DataSet = New DataSet
                        Dim Abundance_db_command As OleDbCommand = New OleDbCommand("SELECT ACFORScaleID, ACFORScaleDescription FROM " & DB_ABUNDANCE_TABLE & " WHERE ACFORScaleDescription = " & SingleQuote(ctlSpeciesControl.Text) & ";", conn)
                        Dim Abundance_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(Abundance_db_command)
                        Abundance_data_adapter.Fill(Abundance_Data_Set, DB_ABUNDANCE_TABLE)

                        dt = Nothing
                        dt = Abundance_Data_Set.Tables(0)
                        Me.Abundance = dt.Rows.Item(0).Item(0).ToString()
                    Case "txtCount"

                        Me.Count = ctlSpeciesControl.Text
                    Case "txtHeight"

                        Me.SpeciesHeight = ctlSpeciesControl.Text
                    Case "txtWidth"

                        Me.SpeciesWidth = ctlSpeciesControl.Text
                    Case "txtLength"

                        Me.Length = ctlSpeciesControl.Text
                    Case "txtComments"
                        Me.Comments = ctlSpeciesControl.Text

                End Select

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub LostFocusControlHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim ctlSpeciesControl As Control

            ctlSpeciesControl = sender

            Select Case ctlSpeciesControl.Name
                Case "txtRange"

                    Me.Range = ctlSpeciesControl.Text

                Case "cboSide"

                    Select Case ctlSpeciesControl.Text
                        Case "On Center"
                            Me.Side = "0"
                        Case "Port"
                            Me.Side = "1"
                        Case "Starboard"
                            Me.Side = "2"
                    End Select
                Case "cboIDConfidence"
                    Me.IDConfidence = ctlSpeciesControl.Text

                Case "cboAbundance"

                    Me.Abundance = ctlSpeciesControl.Text
                Case "txtCount"

                    Me.Count = ctlSpeciesControl.Text
                Case "txtHeight"

                    Me.SpeciesHeight = ctlSpeciesControl.Text
                Case "txtWidth"

                    Me.SpeciesWidth = ctlSpeciesControl.Text
                Case "txtLength"

                    Me.Length = ctlSpeciesControl.Text
                Case "txtComments"
                    Me.Comments = ctlSpeciesControl.Text

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    ' ==========================================================================================================
    ' Name: SpeciesEventForm_Activated()
    ' Description: Every time the form SpeciesEventForm is activated, focus the cursor on the textbox portRangeTextbox.
    ' ==========================================================================================================
    Private Sub SpeciesEventForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'txtLeftRange.Focus()
    End Sub

    Private Sub SpeciesEventForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Call GetSpeciesVariables()

        myFormLibrary.frmVideoMiner.Range = Me.Range
        myFormLibrary.frmVideoMiner.Side = Me.Side
        myFormLibrary.frmVideoMiner.IDConfidence = Me.IDConfidence
        myFormLibrary.frmVideoMiner.Abundance = Me.Abundance
        myFormLibrary.frmVideoMiner.Count = Me.Count
        myFormLibrary.frmVideoMiner.SpeciesHeight = Me.SpeciesHeight
        myFormLibrary.frmVideoMiner.SpeciesWidth = Me.SpeciesWidth
        myFormLibrary.frmVideoMiner.Length = Me.Length
        myFormLibrary.frmVideoMiner.Comments = Me.Comments
        myFormLibrary.frmVideoMiner.SpeciesCode = Me.SpeciesCode


        myFormLibrary.frmSpeciesEvent = Nothing
    End Sub

    Private Sub SpeciesEventForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            Call ok_Click(Nothing, Nothing)
        End If

    End Sub

    ' ==========================================================================================================
    ' Name: SpeciesEventForm_Load()
    ' Description: Called when the form SpeciesEventForm is loaded to set the initial values of the texboxes
    '              and the onCenterButton.
    ' ==========================================================================================================
    Private Sub SpeciesEventForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myFormLibrary.frmSpeciesEvent = Me

        Call getProperties()

        Call loadCollection()

        Call fillSpeciesEventPanel()

        myFormLibrary.frmVideoMiner.blSpeciesValuesSet = False
        centerButtonPressed = False

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand("select * from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, DB_SPECIES_BUTTONS_TABLE)
        Dim r As DataRow
        Dim d As DataTable
        d = sub_data_set.Tables(0)
        For Each r In d.Rows
            Me.speciesComboBox.Items.Add(New ValueDescriptionPair(r.Item(2).ToString(), r.Item(1).ToString()))
        Next

        If blRareSpecies = True Then
            Me.speciesComboBox.Items.Add(New ValueDescriptionPair(Me.SpeciesCode, Me.SpeciesName))
        End If

        For i As Integer = 0 To Me.speciesComboBox.Items.Count - 1
            If Me.speciesComboBox.Items.Item(i).ToString = SpeciesName Then
                Me.speciesComboBox.SelectedIndex = i
            End If
        Next

    End Sub

    ' ==========================================================================================================
    ' Name: SpeciesEventForm_Paint()
    ' Description: When the SpeciesEventForm is displayed, draw a red arc at the bottom of the form with an
    '              attatched red line going to the top of the form. This line helps a user visualize the center line,
    '              and ranges to the left or right of the center line.
    ' ==========================================================================================================
    Private Sub pnlSpeciesEvent_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlSpeciesEvent.Paint
        Dim a As Graphics = e.Graphics
        Dim mypen As Pen
        mypen = New Pen(System.Drawing.Color.Red, 3)
        a = pnlSpeciesEvent.CreateGraphics
        a.Clear(pnlSpeciesEvent.BackColor)

        Dim intWidth As Integer
        intWidth = CType(pnlSpeciesEvent.Width, Integer)

        a.DrawArc(mypen, 0, 200, intWidth - 5, 200, 0, -180)

        Dim xCenter As Integer
        xCenter = CType(pnlSpeciesEvent.Width / 2, Integer)


        a.DrawLine(mypen, xCenter, 200, xCenter, 0)
        a.Dispose()
        mypen.Dispose()
    End Sub

    ' ==========================================================================================================
    ' Name: ok_Click()
    ' Description: Called when the user mouseclicks the ok button
    ' 1.) If the user has not selected "On Centerline" and either the portRangeTextbox or the starboardRangeTextBox
    '     are not filled in or are not numeric, alert the user to fill them in with an integer.
    ' 2.) Else if "On Centerline" has been selected or "On Centerline" has not been selected AND portRangeTextbox and
    '     starboardRangeTextBox have both been flled in, then, hide the SpeciesEventForm
    ' ==========================================================================================================
    Private Sub ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ok.Click

        Dim ItemSelected As String
        ItemSelected = CType(Me.speciesComboBox.SelectedItem, ValueDescriptionPair).Value
        Me.SpeciesCode = ItemSelected.ToString

        myFormLibrary.frmVideoMiner.blSpeciesValuesSet = True

        If Not myFormLibrary.frmRareSpeciesLookup Is Nothing Then
            myFormLibrary.frmRareSpeciesLookup.Close()
        End If

        Me.Close()
        Me.Dispose()
    End Sub

    ' ==========================================================================================================
    ' Name: validate_range()
    ' Description: Function to validate value being passed to it is not null and is numeric.
    ' ==========================================================================================================
    Private Function validate_range(ByVal t As TextBox) As Boolean
        If Not t.Text Like "#" _
                And Not t.Text Like "##" _
                And Not t.Text Like "###" _
                And Not t.Text Like "####" _
                And Not t.Text Like "#####" Then
            Return False
        End If
        Return True
    End Function


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        myFormLibrary.frmVideoMiner.blSpeciesValuesSet = False
        myFormLibrary.frmVideoMiner.blSpeciesCancelled = True
        Me.Close()
    End Sub

    ' Function used for validating text entered into a text box
    Public Sub numericTextboxValidation(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            ' Allow the following characters to be entered into the text box: 1,2,3,4,5,6,7,8,9,0,. and BACKSPACE
            Case "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "0"c, "."c, Convert.ToChar(8)
                e.Handled = False
                ' Dont allow the addition of other characters in the text box
            Case Else
                e.Handled = True
        End Select
    End Sub

    Public Sub sideControl(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim cboSide As ComboBox
        cboSide = sender

        If cboSide.SelectedIndex = 0 Then
            pnlSpeciesEvent.Controls.Item("txtRange").Text = ""
            pnlSpeciesEvent.Controls.Item("txtRange").Enabled = False
            Me.Range = ""
        Else
            pnlSpeciesEvent.Controls.Item("txtRange").Enabled = True
            Me.Range = pnlSpeciesEvent.Controls.Item("txtRange").Text
        End If

    End Sub

    Private Sub cmdScreenCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScreenCapture.Click
        myFormLibrary.frmVideoMiner.blScreenCaptureCalled = True
        Call myFormLibrary.frmVideoMiner.mnuCapScr_Click(sender, e)
        myFormLibrary.frmVideoMiner.blScreenCaptureCalled = False
    End Sub
End Class
