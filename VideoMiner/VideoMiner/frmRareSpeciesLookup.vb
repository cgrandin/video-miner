Imports System.Data.OleDb

Public Class frmRareSpeciesLookup

    Private tblSpecies As DataTable
    Private tblSelection As DataTable


    Private Sub frmRareSpeciesLookup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        tblSpecies = Nothing
        myFormLibrary.frmRareSpeciesLookup = Nothing
    End Sub

    Private Sub frmRareSpeciesLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myFormLibrary.frmRareSpeciesLookup = Me

        Dim strQuery As String

        strQuery = "SELECT DISTINCT CommonName, LatinName, ScientificName, SpeciesCode, TaxonomyClassLevelCode " & _
                   "FROM lu_species_code;"

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand(strQuery, conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, "lu_species_code")

        tblSpecies = sub_data_set.Tables(0)



        If strRareSpeciesCode <> "" Then

            Dim r As DataRow

            For Each r In tblSpecies.Rows
                If r.Item("SpeciesCode") = strRareSpeciesCode Then
                    If Not r.Item("CommonName") Is DBNull.Value Then
                        Call PopulateSpeciesLists("CommonName")
                        cboSpecies.SelectedItem = r.Item("CommonName")
                    Else
                        If Not r.Item("ScientificName") Is DBNull.Value Then
                            Me.radScientificName.Checked = True
                            cboSpecies.SelectedItem = r.Item("ScientificName")
                            'Else
                            '    Me.radLatinName.Checked = True
                            '    cboSpecies.SelectedItem = r.Item("LatinName")
                        End If
                    End If
                End If
            Next
        Else
            Call PopulateSpeciesLists("CommonName")
        End If

    End Sub

    Private Sub PopulateSpeciesLists(ByVal strField As String)

        cboSpecies.Items.Clear()

        Dim r As DataRow

        For Each r In tblSpecies.Rows
            If r.Item(strField).ToString().Trim().Length > 0 Then
                cboSpecies.Items.Add(r.Item(strField).ToString())
            End If
        Next

    End Sub

    Private Sub PopulateLabels(ByVal strField As String)
        Dim r As DataRow

        For Each r In tblSpecies.Rows
            If Not r.Item(strField) Is DBNull.Value Then
                If r.Item(strField) = cboSpecies.SelectedItem Then
                    If r.Item("CommonName") Is DBNull.Value Then
                        Me.lblCommonNameValue.Text = ""
                    Else
                        Me.lblCommonNameValue.Text = r.Item("CommonName")
                    End If

                    'If r.Item("LatinName") Is DBNull.Value Then
                    '    Me.lblLatinNameValue.Text = ""
                    'Else
                    '    Me.lblLatinNameValue.Text = r.Item("LatinName")
                    'End If

                    If r.Item("ScientificName") Is DBNull.Value Then
                        Me.lblScientificNameValue.Text = ""
                    Else
                        Me.lblScientificNameValue.Text = r.Item("ScientificName")
                    End If


                    If r.Item("SpeciesCode") Is DBNull.Value Then
                        Me.lblSpeciesCodeValue.Text = ""
                    Else
                        Me.lblSpeciesCodeValue.Text = r.Item("SpeciesCode")
                    End If

                    If r.Item("TaxonomyClassLevelCode") Is DBNull.Value Then
                        Me.lblTaxonomicCodeValue.Text = ""
                    Else
                        Me.lblTaxonomicCodeValue.Text = r.Item("TaxonomyClassLevelCode")
                    End If
                    Exit For
                End If
            End If
        Next
    End Sub


    Private Sub cboSpecies_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSpecies.KeyUp
        tblSelection = tblSpecies

        Dim r() As DataRow


        If radCommonName.Checked Then
            r = tblSelection.Select(" CommonName LIKE '%" & Me.cboSpecies.Text & "%'")

            If r.Length <> 0 Then

                Me.cboSpecies.Items.Clear()

                Dim i As Integer = 0

                For i = 0 To r.Length - 1
                    Me.cboSpecies.Items.Add(r(i).Item("CommonName"))
                Next
            Else
                Me.cboSpecies.Text = Me.cboSpecies.Text.Substring(0, Me.cboSpecies.Text.Length - 1)
            End If
        ElseIf radScientificName.Checked Then
            r = tblSelection.Select(" ScientificName LIKE '" & Me.cboSpecies.Text & "%'")

            If r.Length <> 0 Then

                Me.cboSpecies.Items.Clear()

                Dim i As Integer = 0

                For i = 0 To r.Length - 1
                    Me.cboSpecies.Items.Add(r(i).Item("ScientificName"))
                Next
            Else
                Me.cboSpecies.Text = Me.cboSpecies.Text.Substring(0, Me.cboSpecies.Text.Length - 1)
            End If
            'Else
            '    r = tblSelection.Select(" LatinName LIKE '" & Me.cboSpecies.Text & "%'")

            '    If r.Length <> 0 Then
            '        Me.cboSpecies.Items.Clear()

            '        Dim i As Integer = 0

            '        For i = 0 To r.Length - 1
            '            Me.cboSpecies.Items.Add(r(i).Item("LatinName"))
            '        Next
            '    Else
            '        Me.cboSpecies.Text = Me.cboSpecies.Text.Substring(0, Me.cboSpecies.Text.Length - 1)
            '    End If
        End If

        Me.cboSpecies.SelectionStart = Me.cboSpecies.Text.Length

    End Sub

    Private Sub cboSpecies_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSpecies.SelectedIndexChanged

        If radCommonName.Checked Then
            Call PopulateLabels("CommonName")
            'ElseIf radLatinName.Checked Then
            '    Call PopulateLabels("LatinName")
        Else
            Call PopulateLabels("ScientificName")
        End If
        Me.cmdOK.Enabled = True


    End Sub

    Private Sub radCommonName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCommonName.CheckedChanged
        If Not tblSpecies Is Nothing Then
            Call PopulateSpeciesLists("CommonName")
        End If
    End Sub

    'Private Sub radLatinName_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radLatinName.CheckedChanged
    '    If Not tblSpecies Is Nothing Then
    '        Call PopulateSpeciesLists("LatinName")
    '    End If
    'End Sub

    Private Sub radScientificName_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radScientificName.CheckedChanged
        If Not tblSpecies Is Nothing Then
            Call PopulateSpeciesLists("ScientificName")
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        blRareSpecies = True

        myFormLibrary.frmVideoMiner.SpeciesCode = Me.lblSpeciesCodeValue.Text
        strRareSpeciesCode = Me.lblSpeciesCodeValue.Text

        If Me.lblCommonNameValue.Text = "" Then
            'If Me.lblScientificNameValue.Text = "" Then
            'myFormLibrary.frmVideoMiner.SpeciesName = Me.lblLatinNameValue.Text
            'Else
            myFormLibrary.frmVideoMiner.SpeciesName = Me.lblScientificNameValue.Text
            'End If
        Else
        myFormLibrary.frmVideoMiner.SpeciesName = Me.lblCommonNameValue.Text
        End If

            Call myFormLibrary.frmVideoMiner.SpeciesVariableButtonHandler(sender, e)

            blRareSpecies = False

    End Sub

    Private Sub cboSpecies_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSpecies.TextChanged
        If Me.cboSpecies.Text = "" Then
            Me.cmdOK.Enabled = False
            Me.lblCommonNameValue.Text = ""
            Me.lblScientificNameValue.Text = ""
            'Me.lblLatinNameValue.Text = ""
            Me.lblSpeciesCodeValue.Text = ""
            Me.lblTaxonomicCodeValue.Text = ""
        Else
            If Me.lblSpeciesCodeValue.Text = "" Then
                Me.cmdOK.Enabled = False
            Else
                Me.cmdOK.Enabled = True
            End If
        End If
    End Sub
End Class