Imports System.Xml
Imports System.IO
Imports System.Data.OleDb

Public Class frmConfigureSpecies

    Event SpeciesConfigurationUpdate()

#Region "Fields"
    Private m_conn As OleDbConnection
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
    Public Property RangeChecked() As Boolean
        Get
            Return chkRange.Checked
        End Get
        Set(ByVal value As Boolean)
            chkRange.Checked = value
        End Set
    End Property

    Public Property IDConfidenceChecked() As Boolean
        Get
            Return chkIDConfidence.Checked
        End Get
        Set(ByVal value As Boolean)
            chkIDConfidence.Checked = value
        End Set
    End Property

    Public Property AbundanceChecked() As Boolean
        Get
            Return chkAbundance.Checked
        End Get
        Set(ByVal value As Boolean)
            chkAbundance.Checked = value
        End Set
    End Property

    Public Property CountChecked() As Boolean
        Get
            Return chkCount.Checked
        End Get
        Set(ByVal value As Boolean)
            chkCount.Checked = value
        End Set
    End Property

    Public Property HeightChecked() As Boolean
        Get
            Return chkHeight.Checked
        End Get
        Set(ByVal value As Boolean)
            chkHeight.Checked = value
        End Set
    End Property

    Public Property WidthChecked() As Boolean
        Get
            Return chkWidth.Checked
        End Get
        Set(ByVal value As Boolean)
            chkWidth.Checked = value
        End Set
    End Property

    Public Property LengthChecked() As Boolean
        Get
            Return chkLength.Checked
        End Get
        Set(ByVal value As Boolean)
            chkLength.Checked = value
        End Set
    End Property

    Public Property CommentsChecked() As Boolean
        Get
            Return chkComments.Checked
        End Get
        Set(ByVal value As Boolean)
            chkComments.Checked = value
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

    Dim path As String
    Dim strConfigFile As String
    Dim dt As DataTable
    Dim row As DataRow

    Public Sub New(conn As OleDbConnection)
        InitializeComponent()
        m_conn = conn
    End Sub

    Private Sub frmConfigureSpecies_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Create a new dataset object containing the confidence id and description
        Dim ConfID_data_set As DataSet = New DataSet
        Dim ConfID_db_command As OleDbCommand = New OleDbCommand("SELECT ConfidenceID, ConfidenceIdDescription FROM " & DB_CONFIDENCE_IDS_TABLE & " ORDER BY ConfidenceID;", m_conn)
        Dim ConfID_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(ConfID_db_command)
        ConfID_data_adapter.Fill(ConfID_data_set, DB_CONFIDENCE_IDS_TABLE)

        ' Cycle through the dataset and input the confidence id and description as a value pair into the confidence combobox
        dt = ConfID_data_set.Tables(0)
        For Each row In dt.Rows
            Me.cboIDConfidence.Items.Add(New ValueDescriptionPair(row.Item(0).ToString(), row.Item(1).ToString()))
        Next

        ' Create a new dataset object containing the Abundance Scale ID and description
        Dim Abundance_Data_Set As DataSet = New DataSet
        Dim Abundance_db_command As OleDbCommand = New OleDbCommand("SELECT ACFORScaleID, ACFORScaleDescription FROM " & DB_ABUNDANCE_TABLE & " ORDER BY ACFORScaleID;", m_conn)
        Dim ACFOR_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(Abundance_db_command)
        ACFOR_data_adapter.Fill(Abundance_Data_Set, DB_ABUNDANCE_TABLE)

        dt = Nothing
        row = Nothing

        ' Cycle through the dataset and input the the abundace scale id and descripiton as a value pair into the abundance combobox
        dt = Abundance_Data_Set.Tables(0)
        For Each row In dt.Rows
            cboAbundance.Items.Add(New ValueDescriptionPair(row.Item(0).ToString(), row.Item(1).ToString()))
        Next

        ' Add the side items to the Side combobox
        Me.cboSide.Items.Add("On Center")
        Me.cboSide.Items.Add("Port")
        Me.cboSide.Items.Add("Starboard")

        ' Check to see if the string values are NULL
        Me.Range = checkString(Me.Range)
        Me.Side = checkString(Me.Side)
        Me.IDConfidence = checkString(Me.IDConfidence)
        Me.Abundance = checkString(Me.Abundance)
        Me.Count = checkString(Me.Count)
        Me.SpeciesHeight = checkString(Me.SpeciesHeight)
        Me.SpeciesWidth = checkString(Me.SpeciesWidth)
        Me.Length = checkString(Me.Length)
        Me.Comments = checkString(Me.Comments)

        ' Modify the checked property of each checkbox according to the value found in the xml configuration file
        Me.chkRange.Checked = Me.RangeChecked
        Me.chkIDConfidence.Checked = Me.IDConfidenceChecked
        Me.chkAbundance.Checked = Me.AbundanceChecked
        Me.chkCount.Checked = Me.CountChecked
        Me.chkHeight.Checked = Me.HeightChecked
        Me.chkWidth.Checked = Me.WidthChecked
        Me.chkLength.Checked = Me.LengthChecked
        Me.chkComments.Checked = Me.CommentsChecked

        ' Modify the text property of each textbox/combobox according to the value found in the xml configuration file
        Me.txtRangeValue.Text = Me.Range
        Me.cboSide.SelectedIndex = Me.Side
        Me.cboIDConfidence.Text = Me.IDConfidence
        Me.cboAbundance.Text = Me.Abundance
        Me.txtCount.Text = Me.Count
        Me.txtHeight.Text = Me.SpeciesHeight
        Me.txtWidth.Text = Me.SpeciesWidth
        Me.txtLength.Text = Me.Length
        Me.txtComments.Text = Me.Comments

        ' Enable or disable the corresponding control according to the state of each checkbox
        enableDisable(Me.txtRangeValue, chkRange.Checked)
        enableDisable(Me.cboSide, chkRange.Checked)
        enableDisable(Me.cboIDConfidence, chkIDConfidence.Checked)
        enableDisable(Me.cboAbundance, chkAbundance.Checked)
        enableDisable(Me.txtCount, chkCount.Checked)
        enableDisable(Me.txtHeight, chkHeight.Checked)
        enableDisable(Me.txtWidth, chkWidth.Checked)
        enableDisable(Me.txtLength, chkLength.Checked)
        enableDisable(Me.txtComments, chkComments.Checked)

    End Sub

    ' Function to enable or disable a form based on the boolean value passed as a parameter
    Private Sub enableDisable(ByRef control As Windows.Forms.Control, ByVal blValue As Boolean)

        If blValue = True Then
            control.Enabled = True
        Else
            control.Enabled = False
        End If

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
        If (path.StartsWith("file:\")) Then
            path = path.Substring(6)    ' Remove unnecessary substring
        End If


        Me.Range = checkString(Me.txtRangeValue.Text)
        Me.Side = checkString(Me.cboSide.SelectedIndex)
        Me.IDConfidence = checkString(Me.cboIDConfidence.Text)
        Me.Abundance = checkString(Me.cboAbundance.Text)
        Me.Count = checkString(Me.txtCount.Text)
        Me.SpeciesHeight = checkString(Me.txtHeight.Text)
        Me.SpeciesWidth = checkString(Me.txtWidth.Text)
        Me.Length = checkString(Me.txtRangeValue.Text)
        Me.Comments = checkString(Me.txtComments.Text)

        'CJG This needs to be done in the main form via events..
        'strConfigFile = path & "\VideoMinerConfigurationDetails.xml"
        'SaveConfiguration
        RaiseEvent SpeciesConfigurationUpdate()
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub


    Private Function checkString(ByVal strValue As String) As String

        If strValue = "" Then
            strValue = "NULL"
        ElseIf strValue = "NULL" Then
            strValue = ""
        End If

        Return strValue
    End Function

    Private Sub chkRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRange.CheckedChanged
        enableDisable(Me.txtRangeValue, chkRange.Checked)
        enableDisable(Me.cboSide, chkRange.Checked)
    End Sub

    Private Sub chkIDConfidence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIDConfidence.CheckedChanged
        enableDisable(Me.cboIDConfidence, chkIDConfidence.Checked)
    End Sub

    Private Sub chkAbundance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAbundance.CheckedChanged
        enableDisable(Me.cboAbundance, chkAbundance.Checked)
    End Sub

    Private Sub chkCount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCount.CheckedChanged
        enableDisable(Me.txtCount, chkCount.Checked)
    End Sub

    Private Sub chkHeight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeight.CheckedChanged
        enableDisable(Me.txtHeight, chkHeight.Checked)
    End Sub

    Private Sub chkWidth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWidth.CheckedChanged
        enableDisable(Me.txtWidth, chkWidth.Checked)
    End Sub

    Private Sub chkLength_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLength.CheckedChanged
        enableDisable(Me.txtLength, chkLength.Checked)
    End Sub

    Private Sub chkComments_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkComments.CheckedChanged
        enableDisable(Me.txtComments, chkComments.Checked)
    End Sub

    Private Sub cboSide_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSide.SelectedIndexChanged
        If cboSide.SelectedItem = "On Center" Then
            Me.txtRangeValue.Text = ""
            Me.txtRangeValue.Enabled = False
        Else
            Me.txtRangeValue.Enabled = True
        End If
    End Sub

    Private Sub txtAbundance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        modGlobals.numericTextboxValidation(e)
    End Sub

    Private Sub txtCount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCount.KeyPress
        modGlobals.numericTextboxValidation(e)
    End Sub

    Private Sub txtHeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHeight.KeyPress
        modGlobals.numericTextboxValidation(e)
    End Sub

    Private Sub txtLength_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLength.KeyPress
        modGlobals.numericTextboxValidation(e)
    End Sub

    Private Sub txtRangeValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRangeValue.KeyPress
        modGlobals.numericTextboxValidation(e)
    End Sub

    Private Sub txtWidth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWidth.KeyPress
        modGlobals.numericTextboxValidation(e)
    End Sub
End Class