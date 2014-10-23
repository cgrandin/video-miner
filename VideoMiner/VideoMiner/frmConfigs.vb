' =================================================================================
' MapIT! Solution Version 1.0 ** ENHANCEMENTS MADE FOR NEXT RELEASE **
' Coastal Resource Mapping Ltd. 2007
' MapIT Project
' Configurations Form
'
' Description
' This is the Configurations Form that loads all of MapIT! config XML settings (except
' Print/Export settings) onto the form and allows the user to edit them.  This
' includes:
' - Auto-Start MapIT! ON/OFF
' - Save Report On/OFF
' - Report save directory / default
' - Template Storage Folder / default
' - For each Template:
'    = Driving Table column (e.g. ACTIVITY$.activity_pk)
'    = Legend Field data source (For each of <A> ... <Z>)
' - Default Opening Layer (name)
' - Opening Layer Labeling field (e.g. OPENING$.file_id)
' 
' These settings are saved when user click on the "Save and Exit" button, otherwise
' they are not saved.
'
' Note: All of the settings, including the path to the config file,
' are loaded from source file (instead of from Main Form or Global Variables).
' This will ensure that Config Form is independent of the Main Form (or
' any other interface), and can be launched anywhere.
' 
' This Form will FAIL if:
' - MapIT! registry entry had an error.
' - Config XML file data structure compromised.
' - Config file missing.
' In which case the user is responsible to reinstall MapIT!
'
' Last updated: Aug-2007 by Ray Chien
' Created by: Ray Chien
' =================================================================================
Imports System.IO
Imports Microsoft.Win32
Imports System.Windows.Forms
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class frmConfigs

    ' --------------------------------------------
    ' Form-level variables/values
    ' TODO: Can we centralize this list of templates definition?
    ' --------------------------------------------
    Private allTemplates() As String = {"rts_referrallocation", _
                                    "siteplan", _
                                    "planting", _
                                    "silvicultureactivity", _
                                    "harvest", _
                                    "postharvestblockstatus"}

    'TODO: with each Hashtable, be aware that the keys cannot duplicate.
    Private allFields As Hashtable
    Private allKeyColumns As Hashtable

    Private strPreviousTemplate As String = ""

    ' References to the current Document and Map Frames
    Private m_Doc As IMxDocument
    Private m_MapITDataFrame As IMapFrame


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' -------------------------------------------------
        ' Initialize Form elements
        ' -------------------------------------------------
        With Me.listFields
            .Visible = True
            .FullRowSelect = True
            .View = View.Details
            .HeaderStyle = ColumnHeaderStyle.Nonclickable
            .HideSelection = False
            .Focus()
            .Columns.Add("", 0, HorizontalAlignment.Left)
            .Columns.Add("Tag", 45, HorizontalAlignment.Left)
            .Columns.Add("Source Column", 140, HorizontalAlignment.Left)
            .Columns.Add("Type", 80, HorizontalAlignment.Left)
            .Columns.Add("Decimal", 70, HorizontalAlignment.Left)
        End With

        ' -------------------------------------------------
        ' Initialize Help tools
        ' -------------------------------------------------
        With ToolTip1
            ' Legend Fields Tab
            .SetToolTip(Me.cboTemplates, "The template currently being edited")
            .SetToolTip(Me.txtKeyColumn, "The data field where unique identifiers of each map is stored")
            .SetToolTip(Me.listFields, "These are the legend fields and their corresponding source data columns")
            .SetToolTip(Me.cmdInsert, "Insert a new legend field at this position")
            .SetToolTip(Me.cmdEdit, "Edit the data source for a legend field")
            .SetToolTip(Me.cmdRemove, "Remove selected legend field")
            ' Misc Tab
            .SetToolTip(Me.chkDefaultTemplates, "Check to use the default MapIT! Template directory located inside MapIT installation folder")
            .SetToolTip(Me.txtTemplateStorage, "Path to the storage folder of templates")
        End With

        ' -------------------------------------------------
        ' Load Additional Elements from the current Document
        ' -------------------------------------------------
        m_Doc = m_application.Document

        ' -------------------------------------------------
        ' Candidates for: Opening Layer
        ' Note: this is loaded from the MapIT MapFrame
        ' If the MapFrame is not found, nothing is loaded.
        ' -------------------------------------------------
        'm_MapITDataFrame = FindDataFrame("MapIT")
        'If Not m_MapITDataFrame Is Nothing Then
        '    For Each strLayer As String In GetFeatureLayers(m_MapITDataFrame)
        '        cboOpeningLayer.Items.Add(strLayer)
        '    Next
        'End If

        ' -------------------------------------------------
        ' Candidates for: KeyMap Data Frame
        ' Note: If there's no Map(?), nothing is loaded.
        ' -------------------------------------------------
        'For i As Integer = 0 To m_Doc.Maps.Count - 1
        '    cboKeyMapDataFrame.Items.Add(m_Doc.Maps.Item(i).Name)
        'Next


    End Sub

    ' =============================================
    ' Load procedures of the Configurations Form
    ' Reads all Config file XML data into the respective controls
    ' =============================================
    Private Sub frmConfigs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Add self to library
        myFormLibrary.frmConfigs = Me

        allFields = New Hashtable
        allKeyColumns = New Hashtable

        Try

            ' -------------------------------------------------
            ' Get location to mapitdll_config XML File
            ' -------------------------------------------------
            ' Read Registry for:
            ' Location of the MapITLauncher Installation -> location of XML Config.
            'Dim regKey As RegistryKey

            'regKey = Registry.CurrentUser.OpenSubKey("Software\MapIT")
            'If regKey Is Nothing Then
            '    Throw New Exception("MapIT installation not found in Registry." & vbNewLine & "Please re-install MapIT! from setup file.")
            'End If

            'Dim strInstallDir As String
            'strInstallDir = regKey.GetValue("InstallDir")
            'If strInstallDir Is Nothing Then
            '    Throw New Exception("MapIT registry corrupted." & vbNewLine & "Please re-install MapIT! from setup file.")
            'End If
            ' Constructs file path to Configuration XML file.
            'Dim strInstallDir As String
            'strInstallDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)

            m_configfilepath = m_Installpath & strMapItDllConfig

            ' -------------------------------------------------
            ' Read From mapitdll_config XML File
            ' -------------------------------------------------
            If File.Exists(m_configfilepath) Then

                Dim objConfigFile As New clsXMLFile(m_configfilepath)

                ' ---------------------------------------------
                ' Loading: Layers Labels Group
                ' ---------------------------------------------
                ' Gets the Default Opening from <MapIT_Dll><Layers><opening>
                'Me.cboOpeningLayer.Text = objConfigFile.GetValue("MapIT_Dll/Layers/Opening")
                ' Gets the Default Label field from <MapIT_Dll><Layers><LabelField>
                ' This field will be used later when the Opening Layer is joined to the OPENING$ table.
                'Me.txtLabelField.Text = objConfigFile.GetValue("MapIT_Dll/Layers/LabelField")

                ' ---------------------------------------------
                ' Loading: Scale Bar Group
                ' ---------------------------------------------
                'Boolean.TryParse(objConfigFile.GetValue("MapIT_Dll/Scalebar/ManageScalebar"), Me.chkScaleBarON.Checked)
                '' Get the Scalebar Option (whether or not it's ON or OFF, the option is loaded and kept)
                'Select Case objConfigFile.GetValue("MapIT_Dll/Scalebar/ScalebarOption")
                '    Case "Auto"
                '        Me.radScaleBarAutoFit.Checked = True
                '    Case "FitSize"
                '        Me.radScaleBarKeepDivSize.Checked = True
                '    Case "FitNumber"
                '        Me.radScaleBarKeepDivNum.Checked = True
                '    Case Else
                '        Me.radScaleBarAutoFit.Checked = True
                'End Select

                ' ---------------------------------------------
                ' Loading: KeyMap Group
                ' ---------------------------------------------
                '' The DataFrame Name of the KeyMap
                'Me.cboKeyMapDataFrame.Text = objConfigFile.GetValue("MapIT_Dll/KeyMap/Layer")
                '' CheckBox Center KeyMap on Map Vicinity
                'Boolean.TryParse(objConfigFile.GetValue("MapIT_Dll/KeyMap/AutoCenter"), Me.chkKMCenter.Checked)
                '' CheckBox Set KeyMap Scale + RadioButtons Scale Type
                'Select Case objConfigFile.GetValue("MapIT_Dll/KeyMap/ScaleType").ToLower.Trim
                '    Case "none"         ' No Scaling
                '        Me.chkKMScale.Checked = False
                '    Case "relative"     ' Scale as X times the Map Extent
                '        Me.chkKMScale.Checked = True
                '        Me.radKMScaleMultiply.Checked = True
                '    Case "absolute"     ' Scale as an absolute Map Scale
                '        Me.chkKMScale.Checked = True
                '        Me.radKMScaleSet.Checked = True
                'End Select
                '' KeyMap Scale Values / Parameters
                'Me.txtKeyMapScaleMultiply.Text = objConfigFile.GetValue("MapIT_Dll/KeyMap/ScaleRelative")
                '' KeyMap Scale Values / Parameters
                'Me.txtKeyMapScaleSet.Text = objConfigFile.GetValue("MapIT_Dll/KeyMap/ScaleAbsolute")

                ' ---------------------------------------------
                ' Loading: Auto-Start Group
                ' ---------------------------------------------
                If Not Boolean.TryParse(objConfigFile.GetValue("MapIT_Dll/Launch/AutoCallMapIT"), Me.chkAutoStart.Checked) Then
                    Me.chkAutoStart.Checked = False
                End If

                ' ---------------------------------------------
                ' Loading: Reports Group
                ' ---------------------------------------------
                '' Report Output Directory - default is Map Output.
                'Dim strReportOutput As String
                'strReportOutput = objConfigFile.GetValue("MapIT_Dll/Report/ReportDir")
                'Select Case strReportOutput
                '    Case "Temp"
                '        radSaveTemp.Checked = True
                '    Case "Output", ""
                '        radSaveOutput.Checked = True
                '    Case Else
                '        radSaveCustom.Checked = True
                '        Me.txtReportOutput.Text = strReportOutput
                'End Select
                '' Report Saved Checkbox - Default is UNCHECKED.
                'If Not Boolean.TryParse(objConfigFile.GetValue("MapIT_Dll/Report/SaveReport"), Me.chkSaveReport.Checked) Then
                '    Me.chkSaveReport.Checked = False
                'End If

                ' -------------------------------------------------
                ' Loading: Templates Group
                ' -------------------------------------------------
                ' Templates Storage folder.  Default is Default. :P
                Dim strTemplateStorage As String = ""
                strTemplateStorage = objConfigFile.GetValue("MapIT_Dll/Templates/StorageFolder")
                If strTemplateStorage = "Default" Then
                    Me.chkDefaultTemplates.Checked = True
                Else
                    Me.txtTemplateStorage.Text = strTemplateStorage
                End If

                ' -------------------------------------------------
                ' Loading: Legend Fields Tab
                ' Loads the Legend table / Activity related settings
                ' -------------------------------------------------
                ' Load all of the Templates' Legend tables into memory, for use
                ' when the Templates combo box gets a selection and read from.

                ' Gets the Legends Fields associated with each template
                Dim Fields()() As String
                For Each aTemplate As String In allTemplates
                    ' Gets the array of the legends fields
                    Fields = objConfigFile.GetArrayValues("MapIT_Dll/Templates/" & aTemplate, m_LegendKeys)
                    ' Store it into the value of the hashtable baby
                    allFields.Add(aTemplate, Fields)
                    ' Gets the Key Column of the template
                    allKeyColumns.Add(aTemplate, objConfigFile.GetValue("MapIT_Dll/Templates/" & aTemplate & "/ActivityKey"))
                Next

                ' Adds all template names to the combo box
                For Each aTemplate As String In allTemplates
                    Me.cboTemplates.Items.Add(aTemplate)
                Next
                ' Default select one of the items
                Me.cboTemplates.SelectedIndex = 0

            Else
                ' -------------------------------------------------
                ' Create new config XML file
                ' -------------------------------------------------

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub


#Region "Legends Tab Functions and Subs"

    ' =============================================
    ' Event: Template Combobox changes value
    ' All legend field values (updated) on the form for the current(old) template
    ' is saved back to the allFields Hash (internal variable).
    ' Then, the legend fields ListValue box is re-loaded with data from
    ' the new template.  The internal allFields Hash remembers the values
    ' so the user retain the changes when coming back to the same template.
    ' =============================================
    Private Sub cboTemplates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTemplates.SelectedIndexChanged

        Me.listFields.SelectedIndices.Clear()
        UpdateTemplateLegend()

        If allFields.ContainsKey(cboTemplates.Text) And _
           allKeyColumns.ContainsKey(cboTemplates.Text) Then

            Me.listFields.Items.Clear()
            Dim itm As ListViewItem
            Dim i As Integer = 0

            ' --------------------------------------------
            ' Clear the yellow highlighting for the KeyColumn.
            ' --------------------------------------------
            'MarkControlError(txtKeyColumn, False)
            ' --------------------------------------------
            ' Put the current Key Column for this Template
            ' If Template is not activity driven, this field is disabled.
            ' --------------------------------------------
            Me.txtKeyColumn.Text = allKeyColumns(cboTemplates.Text)
            If Not IsTemplateActivityDriven(cboTemplates.Text) Then
                Me.txtKeyColumn.Enabled = False
            Else
                Me.txtKeyColumn.Enabled = True
            End If

            ' --------------------------------------------
            ' Loop through the array of strings obtained from the allFields() Hash Value
            ' --------------------------------------------
            Dim LegendsFields()() As String = allFields(cboTemplates.Text)
            For i = 0 To UBound(LegendsFields(0))
                itm = New ListViewItem
                itm.Text = ""

                ' First column: Tag - a letter from the LegendFields array.
                itm.SubItems.Add(m_LegendKeys(i))

                ' Second column: The field representing this tag.
                itm.SubItems.Add(LegendsFields(0)(i))

                ' Third/Fourth column: The format info of this tag - if there is a tag.
                itm.SubItems.Add("")
                itm.SubItems.Add("")
                If LegendsFields(0)(i) <> "" Then
                    Dim myFormats As Hashtable = ParamString2Hashtable(LegendsFields(1)(i))
                    If myFormats.ContainsKey("type") Then
                        itm.SubItems(3).Text = myFormats("type").ToString
                        If myFormats.ContainsKey("decimal") Then
                            itm.SubItems(4).Text = myFormats("decimal").ToString
                        End If
                    Else
                        itm.SubItems(3).Text = "Auto"
                    End If
                End If

                ' Adds this item into the ListView
                Me.listFields.Items.Add(itm)

            Next

            ' --------------------------------------------
            ' Save the current Template name - when combobox changes will be saved into this.
            ' --------------------------------------------
            strPreviousTemplate = cboTemplates.Text

        End If

    End Sub

    ' =============================================
    ' Event: Legend Fields box selection changes
    ' When selection changes, if it happens to remove all selection, then
    ' the Insert/Edit/Remove buttons are disabled.
    ' =============================================
    Private Sub listFields_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listFields.SelectedIndexChanged

        If listFields.SelectedItems.Count = 0 Then
            cmdEdit.Enabled = False
            cmdRemove.Enabled = False
            cmdInsert.Enabled = False
        Else
            cmdEdit.Enabled = True
            cmdRemove.Enabled = True
            cmdInsert.Enabled = True
        End If

    End Sub

    ' =============================================
    ' Event: Legend Fields box double clicked.
    ' When user doubleclicks on the ListValue box, it's equivalent to clicking on Edit.
    ' =============================================
    Private Sub listFields_DoubleClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listFields.DoubleClick
        Call EditListValue()

    End Sub

    ' =============================================
    ' Event: Edit button clicked.
    ' Executes the Edit function.
    ' =============================================
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        Call EditListValue()

    End Sub

    ' =============================================
    ' Event: Insert button clicked.
    ' Executes the Insert function.
    ' =============================================
    Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click
        InsertListValue()
    End Sub

    ' =============================================
    ' Event: Remove button clicked.
    ' Executes the Remove function.
    ' =============================================
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        DeleteListValue()
    End Sub

    ' =============================================
    ' Subroutine for Editing the Legend Fields
    ' Takes the selected item and create a new FieldValue Form instance for it.
    ' When it returns with OK, the new value is updated to the ListValue box.
    ' =============================================
    Private Sub EditListValue()

        Dim myFieldEditWindow As frmFieldValue

        ' No selection - no need to run.
        If listFields.SelectedItems.Count = 0 Then Exit Sub

        With listFields.SelectedItems(0)

            myFieldEditWindow = New frmFieldValue(.SubItems(1).Text, .SubItems(2).Text, .SubItems(3).Text, .SubItems(4).Text)

            If myFieldEditWindow.ShowDialog() = Windows.Forms.DialogResult.OK Then

                .SubItems(2).Text = myFieldEditWindow.FinalValue

                ' If the field itself is empty, formatting is removed.
                If .SubItems(2).Text <> "" Then
                    .SubItems(3).Text = myFieldEditWindow.FinalType
                    .SubItems(4).Text = myFieldEditWindow.FinalDecimal
                Else
                    .SubItems(3).Text = ""
                    .SubItems(4).Text = ""
                End If


            End If

        End With

    End Sub

    ' =============================================
    ' Subroutine for Inserting the Legend Fields
    ' Shifts all rows after (including) the selected row one place down,
    ' basically removing the last possible row (Z), and performs an Edit on the
    ' selected row.
    ' =============================================
    Private Sub InsertListValue()

        ' Dim myFieldEditWindow As frmFieldValue
        Dim i As Integer
        Dim j As Integer

        ' No selection - no need to run.
        If listFields.SelectedItems.Count = 0 Then Exit Sub

        ' Get the first selected item
        With listFields

            ' Exit harmlessly if the user decided not to 'push off' the last row.
            If .Items(.Items.Count - 1).SubItems(2).Text <> "" Then
                If MessageBox.Show("Existing Field " & .Items(.Items.Count - 1).SubItems(1).Text & " will be deleted! Continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            End If

            i = .Items.Count - 1
            Do While i > .SelectedItems(0).Index
                ' Replace text value of the items
                j = 2
                Do While j < .Items(i).SubItems.Count
                    .Items(i).SubItems(j).Text = .Items(i - 1).SubItems(j).Text
                    j += 1
                Loop
                ' Decrement on list
                i -= 1
            Loop

            ' Clears the current Item value
            j = 2
            Do While j < .SelectedItems(0).SubItems.Count
                .SelectedItems(0).SubItems(j).Text = ""
                j += 1
            Loop
            ' Performs the Edit
            EditListValue()

        End With

    End Sub

    ' =============================================
    ' Deletes the selected item in the ListValue Box
    ' and shifts all rows after it one place up, putting empty value to the last
    ' row (Z).
    ' =============================================
    Private Sub DeleteListValue()

        Dim i As Integer
        Dim j As Integer

        ' No selection - no need to run.
        If listFields.SelectedItems.Count = 0 Then Exit Sub

        ' Delete Value - 
        ' Remove the second column of this item only, and move everything up one place.
        With listFields

            i = .SelectedItems(0).Index
            Do While i < .Items.Count - 1
                ' Replace text value of the items
                j = 2
                Do While j < .Items(i).SubItems.Count
                    .Items(i).SubItems(j).Text = .Items(i + 1).SubItems(j).Text
                    j += 1
                Loop
                ' Decrement on list
                i += 1
            Loop

            ' Clear the last item.
            j = 2
            Do While j < .Items(i).SubItems.Count
                .Items(i).SubItems(j).Text = ""
                j += 1
            Loop
        End With

    End Sub

    ' =============================================
    ' Save all transient Legend field data in the ListValue box
    ' to the allFields Hashtable, and also the Key Column textbox value
    ' to the allKeyColumns Hashtable.
    ' =============================================
    Private Sub UpdateTemplateLegend()

        Dim i As Integer
        Dim saveFields(1)() As String
        If strPreviousTemplate <> "" Then

            ' Update Key Column Value
            allKeyColumns(strPreviousTemplate) = Me.txtKeyColumn.Text

            ' Update legends ListValue items
            ' Store values into an array, then put the array into a Hashtable
            ReDim saveFields(0)(Me.listFields.Items.Count - 1)
            ReDim saveFields(1)(Me.listFields.Items.Count - 1)
            For i = 0 To Me.listFields.Items.Count - 1
                saveFields(0)(i) = Me.listFields.Items(i).SubItems(2).Text
                saveFields(1)(i) = MakeFormatString(Me.listFields.Items(i).SubItems(3).Text, _
                                                    Me.listFields.Items(i).SubItems(4).Text)
            Next
            allFields(strPreviousTemplate) = saveFields.Clone

        End If

    End Sub

#End Region

#Region "Map Tab Functions and Subs"

    'Private Sub chkScaleBarON_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkScaleBarON.Checked Then
    '        radScaleBarKeepDivSize.Enabled = True
    '        radScaleBarKeepDivNum.Enabled = True
    '        radScaleBarAutoFit.Enabled = True
    '    Else
    '        radScaleBarKeepDivSize.Enabled = False
    '        radScaleBarKeepDivNum.Enabled = False
    '        radScaleBarAutoFit.Enabled = False
    '    End If
    'End Sub

    'Private Sub chkKMScale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    panKMScaleStuff.Enabled = chkKMScale.Checked

    'End Sub

#End Region

#Region "Misc Tab Functions and Sub"

    ' =============================================
    ' Event: Storage Folder Browse Button click
    ' Launches the Folder picker window
    ' =============================================


    ' =============================================
    ' Event: Report Save Folder Browse Button click
    ' Launches the Folder picker window
    ' =============================================
    'Private Sub cmdGetReportFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Directory.Exists(Me.txtReportOutput.Text) Then
    '        dlgFolderBrowser.SelectedPath = Me.txtReportOutput.Text
    '    End If
    '    If dlgFolderBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        Me.txtReportOutput.Text = dlgFolderBrowser.SelectedPath
    '    End If

    'End Sub

    ' =============================================
    ' Event: Default Storage Folder checked/unchecked
    ' Disables/enables the folder textbox and Browse button
    ' =============================================
    Private Sub chkDefaultTemplates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkDefaultTemplates.Checked Then
            Me.txtTemplateStorage.Enabled = False
            Me.cmdGetStorageFolder.Enabled = False
        Else
            Me.txtTemplateStorage.Enabled = True
            Me.cmdGetStorageFolder.Enabled = True
        End If
    End Sub

    ' =============================================
    ' Event: Save Report checked/unchecked
    ' Disables/enables the Report save options and browse button
    ' =============================================
    'Private Sub chkSaveReport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkSaveReport.Checked Then
    '        Me.txtReportOutput.Enabled = True
    '        Me.cmdGetReportFolder.Enabled = True
    '        radSaveOutput.Enabled = True
    '        radSaveTemp.Enabled = True
    '        radSaveCustom.Enabled = True
    '    Else
    '        Me.txtReportOutput.Enabled = False
    '        Me.cmdGetReportFolder.Enabled = False
    '        radSaveOutput.Enabled = False
    '        radSaveTemp.Enabled = False
    '        radSaveCustom.Enabled = False
    '    End If
    'End Sub

    ' =============================================
    ' Event: Report Save radiobutton "Custom" checked/unchecked
    ' Enables/Disables the Report output directory and browse button
    ' =============================================
    'Private Sub radSaveCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If radSaveCustom.Checked And radSaveCustom.Enabled Then
    '        Me.txtReportOutput.Enabled = True
    '        Me.cmdGetReportFolder.Enabled = True
    '    Else
    '        Me.txtReportOutput.Enabled = False
    '        Me.cmdGetReportFolder.Enabled = False
    '    End If
    'End Sub

    ' =============================================
    ' Event: Template Storagefolder textbox changed
    ' Validate that the field contains a valid directory.
    ' =============================================
    Private Sub txtTemplateStorage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Directory.Exists(txtTemplateStorage.Text) And _
               txtTemplateStorage.Text <> "" Then
            WarningMsg("The directory does not exist")
        End If
    End Sub

    ' =============================================
    ' Event: Report Output folder textbox changed
    ' Validate that the field contains a valid directory.
    ' =============================================
    'Private Sub txtReportOutput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not Directory.Exists(txtReportOutput.Text) And _
    '           txtReportOutput.Text <> "" Then
    '        WarningMsg("The directory does not exist")
    '    End If
    'End Sub

#End Region

    ' =============================================
    ' Cancel: Exit the Form
    ' =============================================
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If MessageBox.Show("All changes will be discarded", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    ' =============================================
    ' Submitting the Form: Validate and Save Config
    ' =============================================
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        
        Try
            ' -------------------------------------------------
            ' Store values for the current Template session
            ' -------------------------------------------------
            UpdateTemplateLegend()

            ' -------------------------------------------------
            ' Validations
            ' -------------------------------------------------
            If CheckValidation() Then
                ' -------------------------------------------------
                ' Saving Configuration
                ' -------------------------------------------------
                SaveConfigToXMLFile(m_configfilepath)
            End If

            ShowGoodMsg("MapIT! Configuration saved." & vbNewLine & "Please restart MapIT! for the changes to be effective")

            Me.Close()

        Catch ex As Exception

            ' XML Related Errors: advise the user that the file has been corrupt and
            ' require MapIT reinstall.
            If ex.Message.Contains("XML") Then
                ErrorMsg(ex.Message & vbNewLine & vbNewLine & _
                         "MapIT! Configuration file is missing or corrupt. Please re-install MapIT!")

            Else
                ' Other Errors: generate a conclusion that the save was unsuccessful.
                WarningMsg(ex.Message & vbNewLine & vbNewLine & _
                         "MapIT! Configuration not saved.")

            End If

        End Try

    End Sub

    ' =============================================
    ' The function that actually saves the Configuration
    ' =============================================
    Sub SaveConfigToXMLFile(ByVal SavePath As String)

        Dim mySaveXML As New clsXMLFile(SavePath)
        Dim myHash As New Hashtable

        ' -------------------------------------------------
        ' Layers and Labels Tab
        ' -------------------------------------------------
        myHash.Clear()
        'myHash.Add("Opening", Me.cboOpeningLayer.Text)
        'myHash.Add("LabelField", Me.txtLabelField.Text)

        ' Assuming at this point we have already got the config file path (during Load)
        mySaveXML.SetHashValues("MapIT_Dll/Layers", myHash, True, False)

        ' ---------------------------------------------
        ' Scalebar Group
        ' ---------------------------------------------
        'myHash.Clear()
        'myHash.Add("ManageScalebar", Me.chkScaleBarON.Checked.ToString)
        'If Me.radScaleBarAutoFit.Checked Then
        '    myHash.Add("ScalebarOption", "Auto")
        'ElseIf Me.radScaleBarKeepDivNum.Checked Then
        '    myHash.Add("ScalebarOption", "FitNumber")
        'ElseIf Me.radScaleBarKeepDivSize.Checked Then
        '    myHash.Add("ScalebarOption", "FitSize")
        'Else
        '    myHash.Add("ScalebarOption", "Auto")
        'End If

        'mySaveXML.SetHashValues("MapIT_Dll/Scalebar", myHash, True, True)

        ' ---------------------------------------------
        ' KeyMap Group
        ' ---------------------------------------------
        'myHash.Clear()
        'myHash.Add("Layer", Me.cboKeyMapDataFrame.Text)
        'myHash.Add("AutoCenter", Me.chkKMCenter.Checked.ToString)
        'If Me.chkKMScale.Checked Then
        '    If Me.radKMScaleMultiply.Checked Then
        '        myHash.Add("ScaleType", "Relative")
        '    ElseIf Me.radKMScaleSet.Checked Then
        '        myHash.Add("ScaleType", "Absolute")
        '    Else
        '        myHash.Add("ScaleType", "None")
        '    End If
        'Else
        '    myHash.Add("ScaleType", "None")
        'End If
        '' TODO: Change them both to <scale> tags if needed in the future.
        '' This requires a lot of new coding on the XMLFIle Class.
        'myHash.Add("ScaleRelative", Me.txtKeyMapScaleMultiply.Text)
        'myHash.Add("ScaleAbsolute", Me.txtKeyMapScaleSet.Text)

        'mySaveXML.SetHashValues("MapIT_Dll/KeyMap", myHash, True, True)

        ' -------------------------------------------------
        ' Start Up
        ' -------------------------------------------------
        myHash.Clear()
        myHash.Add("AutoCallMapIT", Me.chkAutoStart.Checked.ToString)
        mySaveXML.SetHashValues("MapIT_Dll/Launch", myHash, True, False)

        ' -------------------------------------------------
        ' Report Settings
        ' -------------------------------------------------
        'myHash.Clear()
        'If Me.radSaveTemp.Checked Then
        '    myHash.Add("ReportDir", "Temp")
        'ElseIf Me.radSaveOutput.Checked Then
        '    myHash.Add("ReportDir", "Output")
        'Else
        '    myHash.Add("ReportDir", Me.txtReportOutput.Text)
        'End If
        'myHash.Add("SaveReport", Me.chkSaveReport.Checked.ToString)
        'mySaveXML.SetHashValues("MapIT_Dll/Report", myHash, True, True)

        ' -------------------------------------------------
        ' Templates Tab
        ' -------------------------------------------------
        myHash.Clear()
        If Me.chkDefaultTemplates.Checked Or Me.txtTemplateStorage.Text = "" Then
            myHash.Add("StorageFolder", "Default")
        Else
            myHash.Add("StorageFolder", Me.txtTemplateStorage.Text)
        End If
        mySaveXML.SetHashValues("MapIT_Dll/Templates", myHash, True, False) ' Important: Templates section has other elements Do not Delete.

        ' -------------------------------------------------
        ' Legend table / Activity related settings
        ' -------------------------------------------------
        ' For each Template
        Dim aLegendData(1) As String
        For Each strTemplate As String In allTemplates

            ' Create a hashtable containing the Activity Key, and no attributes
            myHash.Clear()
            aLegendData(0) = allKeyColumns(strTemplate)
            aLegendData(1) = ""
            myHash.Add("ActivityKey", aLegendData.Clone)

            ' And fill out all of the A-Z Columns where a value is found.
            Dim i As Integer = 0
            Dim LegendsData()() As String = allFields(strTemplate)
            For i = 0 To UBound(LegendsData(0))
                If Not LegendsData(0)(i) Is Nothing And LegendsData(0)(i) <> "" Then
                    aLegendData(0) = LegendsData(0)(i)
                    aLegendData(1) = LegendsData(1)(i)
                    myHash.Add(m_LegendKeys(i), aLegendData.Clone)
                End If
            Next

            ' Update the Template related data in each sub-section
            mySaveXML.SetHashValues("MapIT_Dll/Templates/" & strTemplate, _
                             myHash, True, True)
        Next

    End Sub

    ' =============================================
    ' Validate the Configuration
    ' =============================================
    Function CheckValidation() As Boolean

        Try
            ' Activity-Based Key Column must not be blank.
            'MarkControlError(Me.txtKeyColumn, False)
            For Each strTemplate As String In allTemplates

                ' Create a hashtable containing the Activity Key, and no attributes
                If IsTemplateActivityDriven(strTemplate) And _
                   allKeyColumns(strTemplate).ToString.Trim = "" Then

                    Me.cboTemplates.Text = strTemplate
                    'MarkControlError(Me.txtKeyColumn, True)
                    Throw New Exception("Key Column required for template " & strTemplate & ".mxd")

                End If

            Next ' End checking all Templates

            ' Opening Layer must not be blank
            'If cboOpeningLayer.Text.Trim = "" Then
            '    ' Highlight Opening Layer
            '    MarkControlError(cboOpeningLayer, True)
            '    Throw New Exception("Opening Layer must not be saved as blank")
            'Else
            '    MarkControlError(cboOpeningLayer, False)
            'End If

            ' KeyMap DataFrame - must not be blank
            'If cboKeyMapDataFrame.Text.Trim = "" Then
            '    ' Highlight Opening Layer
            '    'MarkControlError(cboKeyMapDataFrame, True)
            '    Throw New Exception("KeyMap DataFrame must not be saved as blank")
            'Else
            '    'MarkControlError(cboKeyMapDataFrame, False)
            'End If

            ' KeyMap Scale values must be numeric.
            'If Not IsNumeric(Me.txtKeyMapScaleMultiply.Text) Then
            '    'MarkControlError(txtKeyMapScaleMultiply, True)
            '    Throw New Exception("Scale multiples must be numeric")
            'Else
            '    'MarkControlError(txtKeyMapScaleMultiply, False)
            'End If

            'If Not IsNumeric(Me.txtKeyMapScaleSet.Text) Then
            '    'MarkControlError(txtKeyMapScaleSet, True)
            '    Throw New Exception("Scale value must be numeric")
            'Else
            '    'MarkControlError(txtKeyMapScaleSet, False)
            'End If

            ' Paths must be either blank, or valid directories.
            'If Not Directory.Exists(Me.txtReportOutput.Text) And _
            '   Me.txtReportOutput.Text.Trim <> "" Then
            '    'MarkControlError(txtReportOutput, True)
            '    Throw New Exception("Report Output Folder must exist")
            'Else
            '    'MarkControlError(txtReportOutput, False)
            'End If

            If Not Directory.Exists(Me.txtTemplateStorage.Text) And _
               Me.txtTemplateStorage.Text.Trim <> "" Then
                'MarkControlError(txtTemplateStorage, True)
                Throw New Exception("Template Storage Folder must exist")
            Else
                'MarkControlError(txtTemplateStorage, False)
            End If

            ' All Validated
            Return True

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return False

        End Try

    End Function


    '=================================================================
    ' Sub GetFeatureLayers(ByVal strDefaultOpening As String)
    '=================================================================
    ' This function is being ported to Config Form from originally in
    ' the Main Form. :)
    '=================================================================
    Public Function GetFeatureLayers(ByRef aMapFrame As IMapFrame) As Collection

        Dim sProcName As String
        sProcName = "GetFeatureLayers"
        Dim Layers As New Collection

        Try

            Dim pMap As IMap
            pMap = aMapFrame.Map 'pDoc.FocusMap

            Dim pLayer As IFeatureLayer
            Dim i As Integer
            Dim pFeatClass As IFeatureClass

            ' Populates the String Array with the featurelayer names
            'frmForm.cboLayers.Items.Clear()
            For i = 0 To pMap.LayerCount - 1
                If Not pMap.Layer(i) Is Nothing Then
                    If TypeOf pMap.Layer(i) Is IFeatureLayer Then
                        pLayer = pMap.Layer(i)
                        If Not pLayer Is Nothing Then
                            If pLayer.Selectable Then
                                pFeatClass = pLayer.FeatureClass
                                If (pFeatClass.FeatureType <> esriFeatureType.esriFTAnnotation) And (pFeatClass.FeatureType <> esriFeatureType.esriFTCoverageAnnotation) Then
                                    Layers.Add(pLayer.Name)
                                End If
                            End If
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            WarningMsg(ex.Message)
        End Try

        Return Layers

    End Function

    ' =============================================
    ' Check to see if the current Template is Activity-Driven.
    ' Hard-coded: see if this can be embedded in XML Configuration. TODO.
    ' =============================================
    Public Function IsTemplateActivityDriven(ByVal strDocName As String)

        ' OPENING driven templates: Site Plan, PHBS, Harvest
        Select Case strDocName
            Case "siteplan", "postharvestblockstatus", "harvest", "rts_referrallocation"
                Return False
            Case Else
                Return True
        End Select

    End Function


    '=================================================================
    ' MarkControlError
    '=================================================================
    ' Marks the given Control with an 'ERROR' color (yellow), or remove it.
    ' Bring focus to this control and make sure it is visible to user
    ' e.g. not hidden inside a tab page.
    '=================================================================
    'Public Sub MarkControlError(ByRef aControl As Windows.Forms.Control, ByVal Mark As Boolean)

    '    If Mark Then
    '        ' Highlight the background color.
    '        aControl.BackColor = Drawing.Color.Yellow

    '        ' Focus to this Control, bring all of its parent controls to visible.
    '        aControl.Focus()
    '        Dim bControl As Control = aControl.Parent
    '        Do While Not bControl Is Me
    '            bControl.Visible = True

    '            ' Tab Control specific
    '            If TypeOf bControl Is TabPage Then
    '                Dim cControl As TabControl = bControl.Parent
    '                cControl.SelectedTab = bControl
    '            End If

    '            bControl = bControl.Parent
    '        Loop
    '    Else
    '        ' Remove highlight, set the color back to default.
    '        aControl.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.Window)
    '    End If

    'End Sub

    Private Sub cmdBrowseCompanyFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub lblCompany2Personal_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)



    End Sub

End Class