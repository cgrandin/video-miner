Public Class frmConfigureSpecies

#Region "Member variables"
    Private m_range As String
    Private m_side As String
    Private m_id_confidence As String
    Private m_abundance As String
    Private m_count As String
    Private m_height As String
    Private m_width As String
    Private m_length As String
    Private m_comments As String
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
            Return m_range
        End Get
        Set(ByVal value As String)
            m_range = value
        End Set
    End Property

    Public Property Side() As String
        Get
            Return m_side
        End Get
        Set(ByVal value As String)
            m_side = value
        End Set
    End Property

    Public Property IDConfidence() As String
        Get
            Return m_id_confidence
        End Get
        Set(ByVal value As String)
            m_id_confidence = value
        End Set
    End Property

    Public Property Abundance() As String
        Get
            Return m_abundance
        End Get
        Set(ByVal value As String)
            m_abundance = value
        End Set
    End Property

    Public Property Count() As String
        Get
            Return m_count
        End Get
        Set(ByVal value As String)
            m_count = value
        End Set
    End Property

    Public Property SpeciesHeight() As String
        Get
            Return m_height
        End Get
        Set(ByVal value As String)
            m_height = value
        End Set
    End Property

    Public Property SpeciesWidth() As String
        Get
            Return m_width
        End Get
        Set(ByVal value As String)
            m_width = value
        End Set
    End Property

    Public Property Length() As String
        Get
            Return m_length
        End Get
        Set(ByVal value As String)
            m_length = value
        End Set
    End Property

    Public Property Comments() As String
        Get
            Return m_comments
        End Get
        Set(ByVal value As String)
            m_comments = value
        End Set
    End Property
#End Region

    Public Event SpeciesConfigurationUpdate()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmConfigureSpecies_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim d As DataTable = Database.GetDataTable("select ConfidenceID, ConfidenceIdDescription from " &
                                                   DB_CONFIDENCE_IDS_TABLE & " order by ConfidenceID", DB_CONFIDENCE_IDS_TABLE)
        Dim row As DataRow
        For Each row In d.Rows
            cboIDConfidence.Items.Add(New ValueDescriptionPair(row.Item(0).ToString(), row.Item(1).ToString()))
        Next
        d = Database.GetDataTable("select ACFORScaleID, ACFORScaleDescription from " &
                                  DB_ABUNDANCE_TABLE & " order by ACFORScaleID", DB_ABUNDANCE_TABLE)
        For Each row In d.Rows
            cboAbundance.Items.Add(New ValueDescriptionPair(row.Item(0).ToString(), row.Item(1).ToString()))
        Next
        ' Add the side items to the Side combobox
        cboSide.Items.Add("On Center")

        cboSide.Items.Add("Port")
        cboSide.Items.Add("Starboard")
        ' Check to see if the string values are NULL
        m_range = checkString(m_range)
        m_side = checkString(m_side)
        m_id_confidence = checkString(m_id_confidence)
        m_abundance = checkString(m_abundance)
        m_count = checkString(m_count)
        m_height = checkString(m_height)
        m_width = checkString(m_width)
        m_length = checkString(Length)
        m_comments = checkString(Comments)
        ' Modify the checked property of each checkbox according to the value found in the xml configuration file
        chkRange.Checked = RangeChecked
        chkIDConfidence.Checked = IDConfidenceChecked
        chkAbundance.Checked = AbundanceChecked
        chkCount.Checked = CountChecked
        chkHeight.Checked = HeightChecked
        chkWidth.Checked = WidthChecked
        chkLength.Checked = LengthChecked
        chkComments.Checked = CommentsChecked
        ' Modify the text property of each textbox/combobox according to the value found in the xml configuration file
        txtRangeValue.Text = m_range
        'cboSide.SelectedIndex = CInt(m_side)
        cboIDConfidence.Text = m_id_confidence
        cboAbundance.Text = m_abundance
        txtCount.Text = m_count
        txtHeight.Text = m_height
        txtWidth.Text = m_width
        txtLength.Text = Length
        txtComments.Text = Comments
        ' Enable or disable the corresponding control according to the state of each checkbox
        txtRangeValue.Enabled = chkRange.Checked
        cboSide.Enabled = chkRange.Checked
        cboIDConfidence.Enabled = chkIDConfidence.Checked
        cboAbundance.Enabled = chkAbundance.Checked
        txtCount.Enabled = chkCount.Checked
        txtHeight.Enabled = chkHeight.Checked
        txtWidth.Enabled = chkWidth.Checked
        txtLength.Enabled = chkLength.Checked
        txtComments.Enabled = chkComments.Checked
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        m_range = checkString(txtRangeValue.Text)
        m_side = checkString(cboSide.SelectedIndex.ToString())
        m_id_confidence = checkString(cboIDConfidence.Text)
        m_abundance = checkString(cboAbundance.Text)
        m_count = checkString(txtCount.Text)
        m_height = checkString(txtHeight.Text)
        m_width = checkString(txtWidth.Text)
        m_length = checkString(txtRangeValue.Text)
        m_comments = checkString(txtComments.Text)
        RaiseEvent SpeciesConfigurationUpdate()
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Function checkString(ByVal strValue As String) As String
        If strValue = NULL_STRING Then
            strValue = UNINITIALIZED_DATA_VALUE
        ElseIf strValue = UNINITIALIZED_DATA_VALUE Then
            strValue = NULL_STRING
        End If
        Return strValue
    End Function

    Private Sub chkRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRange.CheckedChanged
        txtRangeValue.Enabled = chkRange.Checked
        cboSide.Enabled = chkRange.Checked
    End Sub

    Private Sub chkIDConfidence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIDConfidence.CheckedChanged
        cboIDConfidence.Enabled = chkIDConfidence.Checked
    End Sub

    Private Sub chkAbundance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAbundance.CheckedChanged
        cboAbundance.Enabled = chkAbundance.Checked
    End Sub

    Private Sub chkCount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCount.CheckedChanged
        txtCount.Enabled = chkCount.Checked
    End Sub

    Private Sub chkHeight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeight.CheckedChanged
        txtHeight.Enabled = chkHeight.Checked
    End Sub

    Private Sub chkWidth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWidth.CheckedChanged
        txtWidth.Enabled = chkWidth.Checked
    End Sub

    Private Sub chkLength_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLength.CheckedChanged
        txtLength.Enabled = chkLength.Checked
    End Sub

    Private Sub chkComments_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkComments.CheckedChanged
        txtComments.Enabled = chkComments.Checked
    End Sub

    Private Sub cboSide_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSide.SelectedIndexChanged
        If cboSide.SelectedItem.ToString() = "On Center" Then
            txtRangeValue.Text = NULL_STRING
            txtRangeValue.Enabled = False
        Else
            txtRangeValue.Enabled = True
        End If
    End Sub

    Private Sub txtAbundance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        numericTextboxValidation(e)
    End Sub

    Private Sub txtCount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCount.KeyPress
        numericTextboxValidation(e)
    End Sub

    Private Sub txtHeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHeight.KeyPress
        numericTextboxValidation(e)
    End Sub

    Private Sub txtLength_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLength.KeyPress
        numericTextboxValidation(e)
    End Sub

    Private Sub txtRangeValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRangeValue.KeyPress
        numericTextboxValidation(e)
    End Sub

    Private Sub txtWidth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWidth.KeyPress
        numericTextboxValidation(e)
    End Sub
End Class