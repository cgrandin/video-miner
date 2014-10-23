Imports System.Data.OleDb

Public Class frmEditSpecies
    Private m_OriginalSpeciesName As String
    Private m_OpriginalSpeciesCode As String
    Private m_SpeciesName As String
    Private m_selIdx As Integer
    Private m_Edit_Insert As String = "Insert"

    Public Property OriginalSpeciesName() As String
        Get
            Return m_OriginalSpeciesName
        End Get
        Set(ByVal value As String)
            m_OriginalSpeciesName = value
        End Set
    End Property

    Public Property Edit_Insert() As String
        Get
            Return m_Edit_Insert
        End Get
        Set(ByVal value As String)
            m_Edit_Insert = value
        End Set
    End Property

    Public Property OriginalSpeciesCode() As String
        Get
            Return m_OpriginalSpeciesCode
        End Get
        Set(ByVal value As String)
            m_OpriginalSpeciesCode = value
        End Set
    End Property

    Public Property selIdx() As String
        Get
            Return m_selIdx
        End Get
        Set(ByVal value As String)
            m_selIdx = value
        End Set
    End Property


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub frmEditSpecies_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myFormLibrary.frmEditSpecies = Nothing
    End Sub

    Private Sub frmEditSpecies_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            myFormLibrary.frmEditSpecies = Me

            Dim strQuery As String
            Dim strColor As String
            If Edit_Insert = "Edit" Then

                strQuery = "SELECT DrawingOrder, ButtonText, ButtonCode, ButtonColor, KeyboardShortcut " & _
                            "FROM videominer_species_buttons " & _
                            "WHERE DrawingOrder = " & selIdx + 1

                Dim cmd As OleDbCommand = New OleDbCommand(strQuery, conn)
                Dim aDataReader As OleDb.OleDbDataReader
                aDataReader = cmd.ExecuteReader

                While aDataReader.Read()
                    If Not IsDBNull(aDataReader("ButtonText")) Then
                        Me.txtSpeciesBtnTxt.Text = aDataReader("ButtonText")
                    End If
                    If Not IsDBNull(aDataReader("ButtonCode")) Then
                        Me.txtSpeciesCode.Text = aDataReader("ButtonCode")
                    End If
                    If Not IsDBNull(aDataReader("KeyboardShortcut")) Then
                        Me.txtKeyboardShortcut.Text = aDataReader("KeyboardShortcut")
                    End If
                    If Not IsDBNull(aDataReader("ButtonColor")) Then
                        strColor = aDataReader("ButtonColor")
                    End If
                End While

                aDataReader.Close()
                aDataReader = Nothing

                cmd.Dispose()
                cmd = Nothing
            ElseIf Edit_Insert = "Insert" Then
                Me.txtSpeciesBtnTxt.Text = ""
                Me.txtSpeciesCode.Text = ""
            End If

            strQuery = "SELECT DISTINCT ScientificName " & _
                       "FROM lu_species_code " & _
                       "ORDER BY ScientificName;"

            Me.cboScientificName.Items.Clear()
            Call PopulateSpeciesLists(Me.cboScientificName, strQuery)

            'strQuery = "SELECT DISTINCT LatinName " & _
            '           "FROM lu_species_code " & _
            '           "ORDER BY LatinName;"

            'Me.cboLatinName.Items.Clear()
            'Call PopulateSpeciesLists(Me.cboLatinName, strQuery)

            strQuery = "SELECT DISTINCT CommonName " & _
                       "FROM lu_species_code " & _
                       "ORDER BY CommonName;"

            Me.cboCommonName.Items.Clear()
            Call PopulateSpeciesLists(Me.cboCommonName, strQuery)

            strQuery = "SELECT TaxonomyClassLevelCode FROM lu_species_code WHERE SpeciesCode = " & SingleQuote(Me.txtSpeciesCode.Text) & ";"

            Dim sub_data_set As DataSet = New DataSet()
            Dim sub_db_command As OleDbCommand = New OleDbCommand(strQuery, conn)
            Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
            sub_data_adapter.Fill(sub_data_set, "lu_species_code")

            Dim dt As DataTable
            Dim r As DataRow

            dt = sub_data_set.Tables.Item(0)
            For Each r In dt.Rows
                If Not IsDBNull(r.Item("TaxonomyClassLevelCode")) Then
                    Me.txtTaxonomicLevel.Text = r.Item("TaxonomyClassLevelCode")
                End If
            Next


            strQuery = "SELECT Color FROM lu_button_colors;"

            sub_data_set = New DataSet()
            sub_db_command = New OleDbCommand(strQuery, conn)
            sub_data_adapter = New OleDbDataAdapter(sub_db_command)
            sub_data_adapter.Fill(sub_data_set, "lu_button_colors")

            dt = sub_data_set.Tables.Item(0)

            For Each r In dt.Rows
                Me.cboButtonColors.Items.Add(r.Item("Color"))
            Next


            Me.cboButtonColors.SelectedItem = strColor
            Me.txtSpeciesCode.ForeColor = Color.Black
            Me.txtSpeciesCode.BackColor = Color.White
            Me.txtTaxonomicLevel.ForeColor = Color.Black
            Me.txtTaxonomicLevel.BackColor = Color.White
            Me.txtKeyboardShortcut.ForeColor = Color.Black
            Me.txtKeyboardShortcut.BackColor = Color.White
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try

    End Sub

    Private Sub PopulateSpeciesLists(ByRef cboBox As ComboBox, ByVal strQuery As String)

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand(strQuery, conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, "lu_species_code")
        Dim r As DataRow
        Dim d As DataTable
        d = sub_data_set.Tables(0)

        For Each r In d.Rows
            'Debug.WriteLine(r.Item("CommonName").ToString())
            If r.Item(0).ToString().Trim().Length > 0 Then
                cboBox.Items.Add(r.Item(0).ToString())
            End If
        Next

        'Me.txtSpeciesCode.Text = Me.OriginalSpeciesCode
        'Me.cboCommonName.Text = Me.OriginalSpeciesName

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        txtSpeciesBtnTxt.Enabled = True
        If Me.txtSpeciesCode.Text.Length = 0 Then
            MessageBox.Show("Please provide a species code.", "Species Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.txtSpeciesCode.Focus()
            Exit Sub
        End If

        'If Me.cboCommonName.Text.Length = 0 Then
        '    MessageBox.Show("Please provide a species name.", "Species Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End If

        Dim oComm As OleDbCommand
        Dim query As String

        Dim intNextId As Integer
        intNextId = GetNextSequenceId()

        ''Check to see if a button allready exists based on both button text and species code
        'query = "SELECT * FROM " & DB_SPECIES_BUTTONS_TABLE & " " & _
        '        "WHERE ButtonText = " & DoubleQuote(Me.txtSpeciesBtnTxt.Text) & " AND " & _
        '        "ButtonCode = " & DoubleQuote(Me.txtSpeciesCode.Text)

        'Check to see if a button allready exists based on species code

        'If Me.txtSpeciesCode.Text <> Me.OriginalSpeciesCode Then

        '    query = "SELECT * FROM " & DB_SPECIES_BUTTONS_TABLE & " " & _
        '                        "WHERE ButtonCode = " & DoubleQuote(Me.txtSpeciesCode.Text)

        '    Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
        '    Dim aDataReader As OleDb.OleDbDataReader
        '    aDataReader = cmd.ExecuteReader
        '    If aDataReader.HasRows Then
        '        MsgBox("This Species Code already exists", MsgBoxStyle.OkOnly, "Duplicate Entry")
        '        Exit Sub
        '    End If
        '    While aDataReader.Read()
        '        Me.txtSpeciesBtnTxt.Text = aDataReader("ButtonText")
        '        Me.txtSpeciesCode.Text = aDataReader("ButtonCode")
        '    End While

        '    aDataReader.Close()
        '    aDataReader = Nothing
        'End If

        If Edit_Insert = "Insert" Then


            'Insert as a new species
            query = "INSERT INTO " & DB_SPECIES_BUTTONS_TABLE & "(DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor, KeyboardShortcut) " & _
                    "VALUES (" & intNextId & ", " & _
                            DoubleQuote(Me.txtSpeciesBtnTxt.Text) & ", " & _
                            DoubleQuote(Me.txtSpeciesCode.Text) & ", " & _
                            DoubleQuote("SpeciesID") & ", " & _
                            "4, " & _
                            SingleQuote(Me.cboButtonColors.SelectedItem) & ", " & _
                            DoubleQuote(Me.txtKeyboardShortcut.Text) & _
                            ")"

            oComm = New OleDbCommand(query, conn)
            oComm.ExecuteNonQuery()

        ElseIf Edit_Insert = "Edit" Then
            'Update the selected species
            query = "UPDATE " & DB_SPECIES_BUTTONS_TABLE & " " & _
                    "SET ButtonText = " & DoubleQuote(Me.txtSpeciesBtnTxt.Text) & ", " & _
                    "    ButtonCode = " & DoubleQuote(Me.txtSpeciesCode.Text) & ", " & _
                    "    ButtonColor = " & DoubleQuote(Me.cboButtonColors.SelectedItem) & ", " & _
                    "    KeyboardShortcut = " & DoubleQuote(Me.txtKeyboardShortcut.Text) & " " & _
                    "WHERE ButtonText = " & DoubleQuote(Me.OriginalSpeciesName) & " AND " & _
                    "      ButtonCode = " & DoubleQuote(Me.OriginalSpeciesCode)

            oComm = New OleDbCommand(query, conn)
            oComm.ExecuteNonQuery()
        End If

        Me.Close()

    End Sub

    Private Function GetNextSequenceId() As Integer

        Dim intId As Integer = 0

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand("SELECT DrawingOrder FROM " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, DB_SPECIES_BUTTONS_TABLE)

        Dim d As DataTable
        d = sub_data_set.Tables(0)

        Dim r As DataRow
        For Each r In d.Rows
            If CType(r.Item("DrawingOrder"), Integer) > intId Then
                intId = CType(r.Item("DrawingOrder"), Integer)
            End If
        Next

        Return intId + 1

    End Function

    Private Sub GetSpeciesCode(ByVal strQuery As String)

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand(strQuery, conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, "lu_species_code")
        Dim r As DataRow
        Dim d As DataTable
        d = sub_data_set.Tables(0)

        For Each r In d.Rows
            'Debug.WriteLine(r.Item("SpeciesCode").ToString())
            Me.txtSpeciesCode.Text = r.Item("SpeciesCode").ToString()
            If Not IsDBNull(r.Item("TaxonomyClassLevelCode")) Then
                Me.txtTaxonomicLevel.Text = r.Item("TaxonomyClassLevelCode").ToString()
            End If
        Next

    End Sub

    Private Sub cboCommonName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCommonName.SelectedIndexChanged

        m_SpeciesName = Me.cboCommonName.Text

        If m_SpeciesName.Length > 0 Then

            Me.txtSpeciesBtnTxt.Text = m_SpeciesName

            Dim strQuery As String
            strQuery = "SELECT DISTINCT SpeciesCode, TaxonomyClassLevelCode " & _
                       "FROM lu_species_code " & _
                       "WHERE CommonName = " & DoubleQuote(m_SpeciesName) & _
                       "ORDER BY SpeciesCode;"

            'Me.cboLatinName.SelectedIndex = -1
            Me.cboScientificName.SelectedIndex = -1
            Me.txtSpeciesCode.Text = ""
            Me.txtTaxonomicLevel.Text = ""
            Call GetSpeciesCode(strQuery)
        End If

    End Sub

    Private Sub cboScientificName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboScientificName.SelectedIndexChanged

        m_SpeciesName = Me.cboScientificName.Text

        If m_SpeciesName.Length > 0 Then

            Me.txtSpeciesBtnTxt.Text = m_SpeciesName

            Dim strQuery As String
            strQuery = "SELECT DISTINCT SpeciesCode, TaxonomyClassLevelCode " & _
                       "FROM lu_species_code " & _
                       "WHERE ScientificName = " & DoubleQuote(m_SpeciesName) & _
                       "ORDER BY SpeciesCode;"

            Me.cboLatinName.SelectedIndex = -1
            Me.cboCommonName.SelectedIndex = -1
            Me.txtSpeciesCode.Text = ""

            Call GetSpeciesCode(strQuery)
        End If
    End Sub

    'Private Sub cboLatinName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLatinName.SelectedIndexChanged

    '    m_SpeciesName = Me.cboLatinName.Text

    '    If m_SpeciesName.Length > 0 Then

    '        Me.txtSpeciesBtnTxt.Text = m_SpeciesName

    '        Dim strQuery As String
    '        strQuery = "SELECT DISTINCT SpeciesCode, TaxonomyClassLevelCode " & _
    '                   "FROM lu_species_code " & _
    '                   "WHERE LatinName = " & DoubleQuote(m_SpeciesName) & _
    '                   "ORDER BY SpeciesCode;"

    '        'Me.cboScientificName.SelectedIndex = -1
    '        Me.cboCommonName.SelectedIndex = -1
    '        Me.txtSpeciesCode.Text = ""
    '        Me.txtTaxonomicLevel.Text = ""
    '        Call GetSpeciesCode(strQuery)
    '    End If
    'End Sub

    Private Sub radCommonName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCommonName.CheckedChanged
        Call EnableDisable()
    End Sub

    Private Sub EnableDisable()

        If radCommonName.Checked Then
            Me.cboCommonName.Enabled = True
            'Me.cboLatinName.Enabled = False
            Me.cboScientificName.Enabled = False
            'ElseIf radLatinName.Checked Then
            '    Me.cboCommonName.Enabled = False
            '    Me.cboLatinName.Enabled = True
            '    Me.cboScientificName.Enabled = False
        ElseIf radScientificName.Checked Then
            Me.cboCommonName.Enabled = False
            'Me.cboLatinName.Enabled = False
            Me.cboScientificName.Enabled = True
        End If

        Me.txtSpeciesCode.Text = ""
        Me.txtTaxonomicLevel.Text = ""
    End Sub

    Private Sub radScientificName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radScientificName.CheckedChanged
        Call EnableDisable()
    End Sub

    'Private Sub radLatinName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLatinName.CheckedChanged
    '    Call EnableDisable()
    'End Sub

    Private Sub cboButtonColors_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboButtonColors.DrawItem

        Dim fnt As Font
        Dim brsh As Brush

        brsh = New SolidBrush(Color.FromName(Me.cboButtonColors.Items(e.Index)))
        fnt = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)

        Dim rectangle As Rectangle = New Rectangle(2, e.Bounds.Top + 2, _
            e.Bounds.Height, e.Bounds.Height - 4)
        e.Graphics.FillRectangle(brsh, rectangle)

        e.DrawBackground()

        e.Graphics.DrawString(Me.cboButtonColors.Items(e.Index), fnt, brsh, e.Bounds.X, e.Bounds.Y)

        e.DrawFocusRectangle()

    End Sub

    Private Sub cboButtonColors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboButtonColors.SelectedIndexChanged
        Me.cboButtonColors.ForeColor = Color.FromName(Me.cboButtonColors.SelectedItem)
    End Sub

    Private Sub cmdChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChange.Click
        myFormLibrary.frmCreateKeyboardShortcut = New frmCreateKeyboardShortcut

        myFormLibrary.frmCreateKeyboardShortcut.ButtonText = Me.txtSpeciesBtnTxt.Text
        myFormLibrary.frmCreateKeyboardShortcut.KeyboardShortcut = Me.txtKeyboardShortcut.Text

        myFormLibrary.frmCreateKeyboardShortcut.ShowDialog()
    End Sub

End Class