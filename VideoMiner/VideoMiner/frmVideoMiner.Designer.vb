<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VideoMiner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VideoMiner))
        Me.mnStrVideoMinerMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenDatabase = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCloseDatabase = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenSession = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveSession = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveSessionAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRefreshForm = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVideoTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUseExternalVideo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCapScr = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNameOptionRoot = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNameOption_1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNameOption_2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNameOption_3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNameOption_4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNameOption_5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNameOption_6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNameOption_7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNameOption_8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuNameOption_9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImageTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenImg = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfigureTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataTableColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigureTransectButtonsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigureHabitatButtonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeciesButtonsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditLookupTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuShowTooltips = New System.Windows.Forms.ToolStripMenuItem()
        Me.GPSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGPSSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeviceControl = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelayConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeyboardShortcutsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataCodeAssignmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblDatabase = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblVideo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.lblZValue = New System.Windows.Forms.Label()
        Me.lblYValue = New System.Windows.Forms.Label()
        Me.lblGPSConnectionValue = New System.Windows.Forms.Label()
        Me.lblZ = New System.Windows.Forms.Label()
        Me.lblY = New System.Windows.Forms.Label()
        Me.lblGPSLocation = New System.Windows.Forms.Label()
        Me.lblGPSConnection = New System.Windows.Forms.Label()
        Me.lblXValue = New System.Windows.Forms.Label()
        Me.lblGPSPortValue = New System.Windows.Forms.Label()
        Me.lblX = New System.Windows.Forms.Label()
        Me.lblGPSPort = New System.Windows.Forms.Label()
        Me.txtNMEA = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.mnthCalendar = New System.Windows.Forms.MonthCalendar()
        Me.cmdOffBottom = New System.Windows.Forms.Button()
        Me.cmdCloseCalendar = New System.Windows.Forms.Button()
        Me.pnlVideoControls = New System.Windows.Forms.Panel()
        Me.txtFramesToSkip = New System.Windows.Forms.TextBox()
        Me.chkDefineAll = New System.Windows.Forms.CheckBox()
        Me.chkResumeVideo = New System.Windows.Forms.CheckBox()
        Me.cmdScreenCapture = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdPrevious = New System.Windows.Forms.Button()
        Me.lblVideoRate = New System.Windows.Forms.Label()
        Me.LblRate = New System.Windows.Forms.Label()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.lblVideoControls = New System.Windows.Forms.Label()
        Me.cmdPlayPause = New System.Windows.Forms.Button()
        Me.cmdIncreaseRate = New System.Windows.Forms.Button()
        Me.cmdDecreaseRate = New System.Windows.Forms.Button()
        Me.cmdPlayForSeconds = New System.Windows.Forms.Button()
        Me.txtPlaySeconds = New System.Windows.Forms.TextBox()
        Me.txtTransectDate = New System.Windows.Forms.TextBox()
        Me.chkRecordEachSecond = New System.Windows.Forms.CheckBox()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.txtTimeSource = New System.Windows.Forms.TextBox()
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.txtDateSource = New System.Windows.Forms.TextBox()
        Me.txtTransectTextbox = New System.Windows.Forms.TextBox()
        Me.lblProjectName = New System.Windows.Forms.Label()
        Me.txtOnOffBottomTextbox = New System.Windows.Forms.TextBox()
        Me.lblTransectDate = New System.Windows.Forms.Label()
        Me.cmdTransectStart = New System.Windows.Forms.Button()
        Me.cmdShowSetTimecode = New System.Windows.Forms.Button()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer7 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer8 = New System.Windows.Forms.SplitContainer()
        Me.pnlSpeciesEntryControls = New System.Windows.Forms.Panel()
        Me.cmdRareSpeciesLookup = New System.Windows.Forms.Button()
        Me.radQuickEntry = New System.Windows.Forms.RadioButton()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.radAbundanceEntry = New System.Windows.Forms.RadioButton()
        Me.radDetailedEntry = New System.Windows.Forms.RadioButton()
        Me.lblQuickSpeciesCount = New System.Windows.Forms.Label()
        Me.txtQuickSpeciesCount = New System.Windows.Forms.TextBox()
        Me.cmdAddComment = New System.Windows.Forms.Button()
        Me.cmdNothingInPhoto = New System.Windows.Forms.Button()
        Me.fldlgOpenFD = New System.Windows.Forms.OpenFileDialog()
        Me.tmrRecordPerSecond = New System.Windows.Forms.Timer(Me.components)
        Me.tmrPlayForSeconds = New System.Windows.Forms.Timer(Me.components)
        Me.svDlgFileDialogScrCap = New System.Windows.Forms.SaveFileDialog()
        Me.svDlgFileDialogSession = New System.Windows.Forms.SaveFileDialog()
        Me.tmrComputerTime = New System.Windows.Forms.Timer(Me.components)
        Me.mnStrVideoMinerMenu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.pnlVideoControls.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        CType(Me.SplitContainer7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer7.SuspendLayout()
        CType(Me.SplitContainer8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer8.Panel1.SuspendLayout()
        Me.SplitContainer8.SuspendLayout()
        Me.pnlSpeciesEntryControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnStrVideoMinerMenu
        '
        Me.mnStrVideoMinerMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.mnuVideoTools, Me.mnuImageTools, Me.mnuConfigureTools, Me.GPSToolStripMenuItem, Me.DeviceToolStripMenuItem, Me.mnuHelp})
        Me.mnStrVideoMinerMenu.Location = New System.Drawing.Point(0, 0)
        Me.mnStrVideoMinerMenu.Name = "mnStrVideoMinerMenu"
        Me.mnStrVideoMinerMenu.Size = New System.Drawing.Size(1098, 24)
        Me.mnStrVideoMinerMenu.TabIndex = 30
        Me.mnStrVideoMinerMenu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenDatabase, Me.mnuCloseDatabase, Me.mnuOpenSession, Me.mnuSaveSession, Me.mnuSaveSessionAs, Me.mnuRefreshForm})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'mnuOpenDatabase
        '
        Me.mnuOpenDatabase.Name = "mnuOpenDatabase"
        Me.mnuOpenDatabase.Size = New System.Drawing.Size(156, 22)
        Me.mnuOpenDatabase.Text = "Open Database"
        '
        'mnuCloseDatabase
        '
        Me.mnuCloseDatabase.Enabled = False
        Me.mnuCloseDatabase.Name = "mnuCloseDatabase"
        Me.mnuCloseDatabase.Size = New System.Drawing.Size(156, 22)
        Me.mnuCloseDatabase.Text = "Close Database"
        '
        'mnuOpenSession
        '
        Me.mnuOpenSession.Name = "mnuOpenSession"
        Me.mnuOpenSession.Size = New System.Drawing.Size(156, 22)
        Me.mnuOpenSession.Text = "Open Session"
        '
        'mnuSaveSession
        '
        Me.mnuSaveSession.Enabled = False
        Me.mnuSaveSession.Name = "mnuSaveSession"
        Me.mnuSaveSession.Size = New System.Drawing.Size(156, 22)
        Me.mnuSaveSession.Text = "Save Session"
        '
        'mnuSaveSessionAs
        '
        Me.mnuSaveSessionAs.Name = "mnuSaveSessionAs"
        Me.mnuSaveSessionAs.Size = New System.Drawing.Size(156, 22)
        Me.mnuSaveSessionAs.Text = "Save Session As"
        '
        'mnuRefreshForm
        '
        Me.mnuRefreshForm.Enabled = False
        Me.mnuRefreshForm.Name = "mnuRefreshForm"
        Me.mnuRefreshForm.Size = New System.Drawing.Size(156, 22)
        Me.mnuRefreshForm.Text = "Refresh Data"
        '
        'mnuVideoTools
        '
        Me.mnuVideoTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenFile, Me.mnuUseExternalVideo, Me.mnuCapScr, Me.mnuNameOptionRoot})
        Me.mnuVideoTools.Name = "mnuVideoTools"
        Me.mnuVideoTools.Size = New System.Drawing.Size(49, 20)
        Me.mnuVideoTools.Text = "Video"
        '
        'mnuOpenFile
        '
        Me.mnuOpenFile.Name = "mnuOpenFile"
        Me.mnuOpenFile.Size = New System.Drawing.Size(230, 22)
        Me.mnuOpenFile.Text = "Open Video"
        '
        'mnuUseExternalVideo
        '
        Me.mnuUseExternalVideo.CheckOnClick = True
        Me.mnuUseExternalVideo.Name = "mnuUseExternalVideo"
        Me.mnuUseExternalVideo.Size = New System.Drawing.Size(230, 22)
        Me.mnuUseExternalVideo.Text = "Use External Video"
        '
        'mnuCapScr
        '
        Me.mnuCapScr.Enabled = False
        Me.mnuCapScr.Name = "mnuCapScr"
        Me.mnuCapScr.Size = New System.Drawing.Size(230, 22)
        Me.mnuCapScr.Text = "Capture Screen"
        '
        'mnuNameOptionRoot
        '
        Me.mnuNameOptionRoot.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNameOption_1, Me.mnuNameOption_2, Me.mnuNameOption_3, Me.mnuNameOption_4, Me.mnuNameOption_5, Me.mnuNameOption_6, Me.mnuNameOption_7, Me.mnuNameOption_8, Me.MnuNameOption_9})
        Me.mnuNameOptionRoot.Enabled = False
        Me.mnuNameOptionRoot.Name = "mnuNameOptionRoot"
        Me.mnuNameOptionRoot.Size = New System.Drawing.Size(230, 22)
        Me.mnuNameOptionRoot.Text = "Capture Screen Default Name"
        '
        'mnuNameOption_1
        '
        Me.mnuNameOption_1.CheckOnClick = True
        Me.mnuNameOption_1.Name = "mnuNameOption_1"
        Me.mnuNameOption_1.Size = New System.Drawing.Size(343, 22)
        Me.mnuNameOption_1.Text = "Capture_[Project]_[Transect_Date]_[Transect_Time]"
        '
        'mnuNameOption_2
        '
        Me.mnuNameOption_2.CheckOnClick = True
        Me.mnuNameOption_2.Name = "mnuNameOption_2"
        Me.mnuNameOption_2.Size = New System.Drawing.Size(343, 22)
        Me.mnuNameOption_2.Text = "Capture_[Project]_[Todays_Date]_[Todays_Time]"
        '
        'mnuNameOption_3
        '
        Me.mnuNameOption_3.CheckOnClick = True
        Me.mnuNameOption_3.Name = "mnuNameOption_3"
        Me.mnuNameOption_3.Size = New System.Drawing.Size(343, 22)
        Me.mnuNameOption_3.Text = "Capture_[Transect_Date]_[Transect_Time]"
        '
        'mnuNameOption_4
        '
        Me.mnuNameOption_4.CheckOnClick = True
        Me.mnuNameOption_4.Name = "mnuNameOption_4"
        Me.mnuNameOption_4.Size = New System.Drawing.Size(343, 22)
        Me.mnuNameOption_4.Text = "Capture_[Todays_Date]_[Todays_Time]"
        '
        'mnuNameOption_5
        '
        Me.mnuNameOption_5.CheckOnClick = True
        Me.mnuNameOption_5.Name = "mnuNameOption_5"
        Me.mnuNameOption_5.Size = New System.Drawing.Size(343, 22)
        Me.mnuNameOption_5.Text = "[Project]_[Transect_Date]_[Transect_Time]"
        '
        'mnuNameOption_6
        '
        Me.mnuNameOption_6.CheckOnClick = True
        Me.mnuNameOption_6.Name = "mnuNameOption_6"
        Me.mnuNameOption_6.Size = New System.Drawing.Size(343, 22)
        Me.mnuNameOption_6.Text = "[Project]_[Todays_Date]_[Todays_Time]"
        '
        'mnuNameOption_7
        '
        Me.mnuNameOption_7.CheckOnClick = True
        Me.mnuNameOption_7.Name = "mnuNameOption_7"
        Me.mnuNameOption_7.Size = New System.Drawing.Size(343, 22)
        Me.mnuNameOption_7.Text = "[Transect_Date]_[Transect_Time]"
        '
        'mnuNameOption_8
        '
        Me.mnuNameOption_8.CheckOnClick = True
        Me.mnuNameOption_8.Name = "mnuNameOption_8"
        Me.mnuNameOption_8.Size = New System.Drawing.Size(343, 22)
        Me.mnuNameOption_8.Text = "[Todays_Date]_[Todays_Time]"
        '
        'MnuNameOption_9
        '
        Me.MnuNameOption_9.Checked = True
        Me.MnuNameOption_9.CheckOnClick = True
        Me.MnuNameOption_9.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MnuNameOption_9.Name = "MnuNameOption_9"
        Me.MnuNameOption_9.Size = New System.Drawing.Size(343, 22)
        Me.MnuNameOption_9.Text = "None"
        '
        'mnuImageTools
        '
        Me.mnuImageTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenImg})
        Me.mnuImageTools.Name = "mnuImageTools"
        Me.mnuImageTools.Size = New System.Drawing.Size(52, 20)
        Me.mnuImageTools.Text = "Image"
        '
        'mnuOpenImg
        '
        Me.mnuOpenImg.Name = "mnuOpenImg"
        Me.mnuOpenImg.Size = New System.Drawing.Size(139, 22)
        Me.mnuOpenImg.Text = "Open Image"
        '
        'mnuConfigureTools
        '
        Me.mnuConfigureTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataTableColumnsToolStripMenuItem, Me.ConfigureTransectButtonsToolStripMenuItem, Me.ConfigureHabitatButtonToolStripMenuItem, Me.SpeciesButtonsToolStripMenuItem, Me.EditLookupTableToolStripMenuItem, Me.mnuShowTooltips})
        Me.mnuConfigureTools.Name = "mnuConfigureTools"
        Me.mnuConfigureTools.Size = New System.Drawing.Size(72, 20)
        Me.mnuConfigureTools.Text = "Configure"
        '
        'DataTableColumnsToolStripMenuItem
        '
        Me.DataTableColumnsToolStripMenuItem.Name = "DataTableColumnsToolStripMenuItem"
        Me.DataTableColumnsToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.DataTableColumnsToolStripMenuItem.Text = "Data column visibility"
        '
        'ConfigureTransectButtonsToolStripMenuItem
        '
        Me.ConfigureTransectButtonsToolStripMenuItem.Name = "ConfigureTransectButtonsToolStripMenuItem"
        Me.ConfigureTransectButtonsToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ConfigureTransectButtonsToolStripMenuItem.Text = "Transect Buttons"
        '
        'ConfigureHabitatButtonToolStripMenuItem
        '
        Me.ConfigureHabitatButtonToolStripMenuItem.Name = "ConfigureHabitatButtonToolStripMenuItem"
        Me.ConfigureHabitatButtonToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ConfigureHabitatButtonToolStripMenuItem.Text = "Habitat Buttons"
        '
        'SpeciesButtonsToolStripMenuItem
        '
        Me.SpeciesButtonsToolStripMenuItem.Name = "SpeciesButtonsToolStripMenuItem"
        Me.SpeciesButtonsToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.SpeciesButtonsToolStripMenuItem.Text = "Species Buttons"
        '
        'EditLookupTableToolStripMenuItem
        '
        Me.EditLookupTableToolStripMenuItem.Name = "EditLookupTableToolStripMenuItem"
        Me.EditLookupTableToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.EditLookupTableToolStripMenuItem.Text = "Edit Lookup Tables"
        '
        'mnuShowTooltips
        '
        Me.mnuShowTooltips.Checked = True
        Me.mnuShowTooltips.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuShowTooltips.Name = "mnuShowTooltips"
        Me.mnuShowTooltips.Size = New System.Drawing.Size(188, 22)
        Me.mnuShowTooltips.Text = "Show Tooltips"
        '
        'GPSToolStripMenuItem
        '
        Me.GPSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGPSSettings})
        Me.GPSToolStripMenuItem.Name = "GPSToolStripMenuItem"
        Me.GPSToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.GPSToolStripMenuItem.Text = "GPS"
        '
        'mnuGPSSettings
        '
        Me.mnuGPSSettings.Name = "mnuGPSSettings"
        Me.mnuGPSSettings.Size = New System.Drawing.Size(160, 22)
        Me.mnuGPSSettings.Text = "GPS Connection"
        '
        'DeviceToolStripMenuItem
        '
        Me.DeviceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeviceControl, Me.RelayConfigurationToolStripMenuItem})
        Me.DeviceToolStripMenuItem.Name = "DeviceToolStripMenuItem"
        Me.DeviceToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.DeviceToolStripMenuItem.Text = "Device"
        Me.DeviceToolStripMenuItem.Visible = False
        '
        'DeviceControl
        '
        Me.DeviceControl.Name = "DeviceControl"
        Me.DeviceControl.Size = New System.Drawing.Size(179, 22)
        Me.DeviceControl.Text = "Device Control"
        '
        'RelayConfigurationToolStripMenuItem
        '
        Me.RelayConfigurationToolStripMenuItem.Name = "RelayConfigurationToolStripMenuItem"
        Me.RelayConfigurationToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.RelayConfigurationToolStripMenuItem.Text = "Relay Configuration"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KeyboardShortcutsToolStripMenuItem, Me.DataCodeAssignmentsToolStripMenuItem, Me.InformationToolStripMenuItem})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnuHelp.Text = "Help"
        '
        'KeyboardShortcutsToolStripMenuItem
        '
        Me.KeyboardShortcutsToolStripMenuItem.Enabled = False
        Me.KeyboardShortcutsToolStripMenuItem.Name = "KeyboardShortcutsToolStripMenuItem"
        Me.KeyboardShortcutsToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.KeyboardShortcutsToolStripMenuItem.Text = "Keyboard Shortcuts"
        '
        'DataCodeAssignmentsToolStripMenuItem
        '
        Me.DataCodeAssignmentsToolStripMenuItem.Enabled = False
        Me.DataCodeAssignmentsToolStripMenuItem.Name = "DataCodeAssignmentsToolStripMenuItem"
        Me.DataCodeAssignmentsToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.DataCodeAssignmentsToolStripMenuItem.Text = "Data Code Assignments"
        '
        'InformationToolStripMenuItem
        '
        Me.InformationToolStripMenuItem.Name = "InformationToolStripMenuItem"
        Me.InformationToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.InformationToolStripMenuItem.Text = "About"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDatabase, Me.ToolStripStatusLabel1, Me.lblVideo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 3)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1098, 22)
        Me.StatusStrip1.TabIndex = 45
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblDatabase
        '
        Me.lblDatabase.ForeColor = System.Drawing.Color.Red
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'lblVideo
        '
        Me.lblVideo.ForeColor = System.Drawing.Color.Red
        Me.lblVideo.Name = "lblVideo"
        Me.lblVideo.Size = New System.Drawing.Size(0, 17)
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.SplitContainer4)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer5.Size = New System.Drawing.Size(1098, 705)
        Me.SplitContainer5.SplitterDistance = 676
        Me.SplitContainer5.TabIndex = 46
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.IsSplitterFixed = True
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblZValue)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblYValue)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblGPSConnectionValue)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblZ)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblY)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblGPSLocation)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblGPSConnection)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblXValue)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblGPSPortValue)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblX)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblGPSPort)
        Me.SplitContainer4.Panel1.Controls.Add(Me.txtNMEA)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer4.Size = New System.Drawing.Size(1098, 676)
        Me.SplitContainer4.SplitterDistance = 46
        Me.SplitContainer4.TabIndex = 45
        '
        'lblZValue
        '
        Me.lblZValue.AutoSize = True
        Me.lblZValue.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblZValue.Location = New System.Drawing.Point(426, 28)
        Me.lblZValue.Name = "lblZValue"
        Me.lblZValue.Size = New System.Drawing.Size(0, 13)
        Me.lblZValue.TabIndex = 60
        Me.lblZValue.Visible = False
        '
        'lblYValue
        '
        Me.lblYValue.AutoSize = True
        Me.lblYValue.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblYValue.Location = New System.Drawing.Point(322, 28)
        Me.lblYValue.Name = "lblYValue"
        Me.lblYValue.Size = New System.Drawing.Size(0, 13)
        Me.lblYValue.TabIndex = 60
        Me.lblYValue.Visible = False
        '
        'lblGPSConnectionValue
        '
        Me.lblGPSConnectionValue.AutoSize = True
        Me.lblGPSConnectionValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGPSConnectionValue.ForeColor = System.Drawing.Color.Red
        Me.lblGPSConnectionValue.Location = New System.Drawing.Point(108, 19)
        Me.lblGPSConnectionValue.Name = "lblGPSConnectionValue"
        Me.lblGPSConnectionValue.Size = New System.Drawing.Size(77, 13)
        Me.lblGPSConnectionValue.TabIndex = 60
        Me.lblGPSConnectionValue.Text = "NO GPS FIX"
        Me.lblGPSConnectionValue.Visible = False
        '
        'lblZ
        '
        Me.lblZ.AutoSize = True
        Me.lblZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZ.Location = New System.Drawing.Point(401, 28)
        Me.lblZ.Name = "lblZ"
        Me.lblZ.Size = New System.Drawing.Size(19, 13)
        Me.lblZ.TabIndex = 60
        Me.lblZ.Text = "Z:"
        Me.lblZ.Visible = False
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblY.Location = New System.Drawing.Point(299, 28)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(19, 13)
        Me.lblY.TabIndex = 60
        Me.lblY.Text = "Y:"
        Me.lblY.Visible = False
        '
        'lblGPSLocation
        '
        Me.lblGPSLocation.AutoSize = True
        Me.lblGPSLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGPSLocation.Location = New System.Drawing.Point(204, 3)
        Me.lblGPSLocation.Name = "lblGPSLocation"
        Me.lblGPSLocation.Size = New System.Drawing.Size(89, 13)
        Me.lblGPSLocation.TabIndex = 60
        Me.lblGPSLocation.Text = "GPS Location:"
        Me.lblGPSLocation.Visible = False
        '
        'lblGPSConnection
        '
        Me.lblGPSConnection.AutoSize = True
        Me.lblGPSConnection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGPSConnection.Location = New System.Drawing.Point(3, 19)
        Me.lblGPSConnection.Name = "lblGPSConnection"
        Me.lblGPSConnection.Size = New System.Drawing.Size(104, 13)
        Me.lblGPSConnection.TabIndex = 60
        Me.lblGPSConnection.Text = "GPS Connection:"
        Me.lblGPSConnection.Visible = False
        '
        'lblXValue
        '
        Me.lblXValue.AutoSize = True
        Me.lblXValue.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblXValue.Location = New System.Drawing.Point(227, 28)
        Me.lblXValue.Name = "lblXValue"
        Me.lblXValue.Size = New System.Drawing.Size(0, 13)
        Me.lblXValue.TabIndex = 60
        Me.lblXValue.Visible = False
        '
        'lblGPSPortValue
        '
        Me.lblGPSPortValue.AutoSize = True
        Me.lblGPSPortValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGPSPortValue.ForeColor = System.Drawing.Color.Red
        Me.lblGPSPortValue.Location = New System.Drawing.Point(108, 3)
        Me.lblGPSPortValue.Name = "lblGPSPortValue"
        Me.lblGPSPortValue.Size = New System.Drawing.Size(56, 13)
        Me.lblGPSPortValue.TabIndex = 60
        Me.lblGPSPortValue.Text = "CLOSED"
        Me.lblGPSPortValue.Visible = False
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblX.Location = New System.Drawing.Point(204, 28)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(19, 13)
        Me.lblX.TabIndex = 60
        Me.lblX.Text = "X:"
        Me.lblX.Visible = False
        '
        'lblGPSPort
        '
        Me.lblGPSPort.AutoSize = True
        Me.lblGPSPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGPSPort.Location = New System.Drawing.Point(3, 3)
        Me.lblGPSPort.Name = "lblGPSPort"
        Me.lblGPSPort.Size = New System.Drawing.Size(63, 13)
        Me.lblGPSPort.TabIndex = 60
        Me.lblGPSPort.Text = "GPS Port:"
        Me.lblGPSPort.Visible = False
        '
        'txtNMEA
        '
        Me.txtNMEA.Location = New System.Drawing.Point(294, 3)
        Me.txtNMEA.Name = "txtNMEA"
        Me.txtNMEA.Size = New System.Drawing.Size(390, 20)
        Me.txtNMEA.TabIndex = 48
        Me.txtNMEA.Visible = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1098, 626)
        Me.SplitContainer1.SplitterDistance = 497
        Me.SplitContainer1.TabIndex = 22
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.mnthCalendar)
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmdOffBottom)
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmdCloseCalendar)
        Me.SplitContainer3.Panel1.Controls.Add(Me.pnlVideoControls)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtTransectDate)
        Me.SplitContainer3.Panel1.Controls.Add(Me.chkRecordEachSecond)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtProjectName)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtTimeSource)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtTime)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtDateSource)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtTransectTextbox)
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblProjectName)
        Me.SplitContainer3.Panel1.Controls.Add(Me.txtOnOffBottomTextbox)
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblTransectDate)
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmdTransectStart)
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmdShowSetTimecode)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer3.Size = New System.Drawing.Size(1098, 497)
        Me.SplitContainer3.SplitterDistance = 208
        Me.SplitContainer3.TabIndex = 43
        '
        'mnthCalendar
        '
        Me.mnthCalendar.Location = New System.Drawing.Point(12, 163)
        Me.mnthCalendar.MaxSelectionCount = 1
        Me.mnthCalendar.Name = "mnthCalendar"
        Me.mnthCalendar.ShowToday = False
        Me.mnthCalendar.ShowTodayCircle = False
        Me.mnthCalendar.TabIndex = 50
        Me.mnthCalendar.Visible = False
        '
        'cmdOffBottom
        '
        Me.cmdOffBottom.Enabled = False
        Me.cmdOffBottom.Location = New System.Drawing.Point(12, 221)
        Me.cmdOffBottom.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdOffBottom.Name = "cmdOffBottom"
        Me.cmdOffBottom.Size = New System.Drawing.Size(186, 25)
        Me.cmdOffBottom.TabIndex = 43
        Me.cmdOffBottom.Text = "On Bottom"
        Me.cmdOffBottom.UseVisualStyleBackColor = True
        '
        'cmdCloseCalendar
        '
        Me.cmdCloseCalendar.ForeColor = System.Drawing.Color.Black
        Me.cmdCloseCalendar.Location = New System.Drawing.Point(190, 83)
        Me.cmdCloseCalendar.Name = "cmdCloseCalendar"
        Me.cmdCloseCalendar.Size = New System.Drawing.Size(16, 20)
        Me.cmdCloseCalendar.TabIndex = 50
        Me.cmdCloseCalendar.Text = "X"
        Me.cmdCloseCalendar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdCloseCalendar.UseVisualStyleBackColor = True
        Me.cmdCloseCalendar.Visible = False
        '
        'pnlVideoControls
        '
        Me.pnlVideoControls.Controls.Add(Me.txtFramesToSkip)
        Me.pnlVideoControls.Controls.Add(Me.chkDefineAll)
        Me.pnlVideoControls.Controls.Add(Me.chkResumeVideo)
        Me.pnlVideoControls.Controls.Add(Me.cmdScreenCapture)
        Me.pnlVideoControls.Controls.Add(Me.cmdNext)
        Me.pnlVideoControls.Controls.Add(Me.cmdPrevious)
        Me.pnlVideoControls.Controls.Add(Me.lblVideoRate)
        Me.pnlVideoControls.Controls.Add(Me.LblRate)
        Me.pnlVideoControls.Controls.Add(Me.cmdStop)
        Me.pnlVideoControls.Controls.Add(Me.lblVideoControls)
        Me.pnlVideoControls.Controls.Add(Me.cmdPlayPause)
        Me.pnlVideoControls.Controls.Add(Me.cmdIncreaseRate)
        Me.pnlVideoControls.Controls.Add(Me.cmdDecreaseRate)
        Me.pnlVideoControls.Controls.Add(Me.cmdPlayForSeconds)
        Me.pnlVideoControls.Controls.Add(Me.txtPlaySeconds)
        Me.pnlVideoControls.Location = New System.Drawing.Point(10, 331)
        Me.pnlVideoControls.Name = "pnlVideoControls"
        Me.pnlVideoControls.Size = New System.Drawing.Size(195, 162)
        Me.pnlVideoControls.TabIndex = 38
        Me.pnlVideoControls.Visible = False
        '
        'txtFramesToSkip
        '
        Me.txtFramesToSkip.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFramesToSkip.Location = New System.Drawing.Point(111, 3)
        Me.txtFramesToSkip.Name = "txtFramesToSkip"
        Me.txtFramesToSkip.Size = New System.Drawing.Size(29, 18)
        Me.txtFramesToSkip.TabIndex = 60
        Me.txtFramesToSkip.Text = "500"
        '
        'chkDefineAll
        '
        Me.chkDefineAll.AutoSize = True
        Me.chkDefineAll.Location = New System.Drawing.Point(3, 112)
        Me.chkDefineAll.Name = "chkDefineAll"
        Me.chkDefineAll.Size = New System.Drawing.Size(164, 17)
        Me.chkDefineAll.TabIndex = 59
        Me.chkDefineAll.Text = "Define All After Play Seconds"
        Me.chkDefineAll.UseVisualStyleBackColor = True
        '
        'chkResumeVideo
        '
        Me.chkResumeVideo.AutoSize = True
        Me.chkResumeVideo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkResumeVideo.Location = New System.Drawing.Point(3, 128)
        Me.chkResumeVideo.Name = "chkResumeVideo"
        Me.chkResumeVideo.Size = New System.Drawing.Size(116, 30)
        Me.chkResumeVideo.TabIndex = 58
        Me.chkResumeVideo.Text = "Resume Video" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "After Species Entry"
        Me.chkResumeVideo.UseVisualStyleBackColor = True
        '
        'cmdScreenCapture
        '
        Me.cmdScreenCapture.BackgroundImage = CType(resources.GetObject("cmdScreenCapture.BackgroundImage"), System.Drawing.Image)
        Me.cmdScreenCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdScreenCapture.Location = New System.Drawing.Point(145, 22)
        Me.cmdScreenCapture.Name = "cmdScreenCapture"
        Me.cmdScreenCapture.Size = New System.Drawing.Size(33, 26)
        Me.cmdScreenCapture.TabIndex = 57
        Me.cmdScreenCapture.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.BackgroundImage = CType(resources.GetObject("cmdNext.BackgroundImage"), System.Drawing.Image)
        Me.cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdNext.Location = New System.Drawing.Point(109, 22)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(33, 26)
        Me.cmdNext.TabIndex = 57
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdPrevious
        '
        Me.cmdPrevious.BackgroundImage = CType(resources.GetObject("cmdPrevious.BackgroundImage"), System.Drawing.Image)
        Me.cmdPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdPrevious.Enabled = False
        Me.cmdPrevious.Location = New System.Drawing.Point(74, 22)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(33, 26)
        Me.cmdPrevious.TabIndex = 56
        Me.cmdPrevious.UseVisualStyleBackColor = True
        '
        'lblVideoRate
        '
        Me.lblVideoRate.AutoSize = True
        Me.lblVideoRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVideoRate.ForeColor = System.Drawing.Color.Blue
        Me.lblVideoRate.Location = New System.Drawing.Point(45, 58)
        Me.lblVideoRate.Name = "lblVideoRate"
        Me.lblVideoRate.Size = New System.Drawing.Size(46, 17)
        Me.lblVideoRate.TabIndex = 55
        Me.lblVideoRate.Text = "1.0 X"
        '
        'LblRate
        '
        Me.LblRate.AutoSize = True
        Me.LblRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRate.Location = New System.Drawing.Point(2, 58)
        Me.LblRate.Name = "LblRate"
        Me.LblRate.Size = New System.Drawing.Size(47, 17)
        Me.LblRate.TabIndex = 55
        Me.LblRate.Text = "Rate:"
        '
        'cmdStop
        '
        Me.cmdStop.BackgroundImage = CType(resources.GetObject("cmdStop.BackgroundImage"), System.Drawing.Image)
        Me.cmdStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdStop.Location = New System.Drawing.Point(38, 22)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(33, 26)
        Me.cmdStop.TabIndex = 38
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'lblVideoControls
        '
        Me.lblVideoControls.AutoSize = True
        Me.lblVideoControls.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVideoControls.Location = New System.Drawing.Point(3, 1)
        Me.lblVideoControls.Name = "lblVideoControls"
        Me.lblVideoControls.Size = New System.Drawing.Size(100, 15)
        Me.lblVideoControls.TabIndex = 54
        Me.lblVideoControls.Text = "Video Controls"
        '
        'cmdPlayPause
        '
        Me.cmdPlayPause.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPlayPause.BackgroundImage = CType(resources.GetObject("cmdPlayPause.BackgroundImage"), System.Drawing.Image)
        Me.cmdPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdPlayPause.Location = New System.Drawing.Point(2, 22)
        Me.cmdPlayPause.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdPlayPause.Name = "cmdPlayPause"
        Me.cmdPlayPause.Size = New System.Drawing.Size(33, 26)
        Me.cmdPlayPause.TabIndex = 46
        Me.cmdPlayPause.UseVisualStyleBackColor = False
        '
        'cmdIncreaseRate
        '
        Me.cmdIncreaseRate.BackgroundImage = CType(resources.GetObject("cmdIncreaseRate.BackgroundImage"), System.Drawing.Image)
        Me.cmdIncreaseRate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdIncreaseRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdIncreaseRate.Location = New System.Drawing.Point(144, 54)
        Me.cmdIncreaseRate.Name = "cmdIncreaseRate"
        Me.cmdIncreaseRate.Size = New System.Drawing.Size(33, 26)
        Me.cmdIncreaseRate.TabIndex = 38
        Me.cmdIncreaseRate.UseVisualStyleBackColor = True
        '
        'cmdDecreaseRate
        '
        Me.cmdDecreaseRate.BackgroundImage = CType(resources.GetObject("cmdDecreaseRate.BackgroundImage"), System.Drawing.Image)
        Me.cmdDecreaseRate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdDecreaseRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDecreaseRate.Location = New System.Drawing.Point(110, 54)
        Me.cmdDecreaseRate.Name = "cmdDecreaseRate"
        Me.cmdDecreaseRate.Size = New System.Drawing.Size(33, 26)
        Me.cmdDecreaseRate.TabIndex = 38
        Me.cmdDecreaseRate.UseVisualStyleBackColor = True
        '
        'cmdPlayForSeconds
        '
        Me.cmdPlayForSeconds.Location = New System.Drawing.Point(6, 89)
        Me.cmdPlayForSeconds.Name = "cmdPlayForSeconds"
        Me.cmdPlayForSeconds.Size = New System.Drawing.Size(80, 21)
        Me.cmdPlayForSeconds.TabIndex = 40
        Me.cmdPlayForSeconds.Text = "Play Seconds"
        Me.cmdPlayForSeconds.UseVisualStyleBackColor = True
        '
        'txtPlaySeconds
        '
        Me.txtPlaySeconds.Location = New System.Drawing.Point(91, 89)
        Me.txtPlaySeconds.Name = "txtPlaySeconds"
        Me.txtPlaySeconds.Size = New System.Drawing.Size(86, 20)
        Me.txtPlaySeconds.TabIndex = 41
        '
        'txtTransectDate
        '
        Me.txtTransectDate.BackColor = System.Drawing.SystemColors.Window
        Me.txtTransectDate.Enabled = False
        Me.txtTransectDate.Location = New System.Drawing.Point(11, 82)
        Me.txtTransectDate.MaxLength = 50
        Me.txtTransectDate.Name = "txtTransectDate"
        Me.txtTransectDate.ReadOnly = True
        Me.txtTransectDate.Size = New System.Drawing.Size(177, 20)
        Me.txtTransectDate.TabIndex = 49
        '
        'chkRecordEachSecond
        '
        Me.chkRecordEachSecond.AutoSize = True
        Me.chkRecordEachSecond.Enabled = False
        Me.chkRecordEachSecond.Location = New System.Drawing.Point(13, 290)
        Me.chkRecordEachSecond.Name = "chkRecordEachSecond"
        Me.chkRecordEachSecond.Size = New System.Drawing.Size(173, 17)
        Me.chkRecordEachSecond.TabIndex = 39
        Me.chkRecordEachSecond.Text = "Record Every Second of Video"
        Me.chkRecordEachSecond.UseVisualStyleBackColor = True
        '
        'txtProjectName
        '
        Me.txtProjectName.Enabled = False
        Me.txtProjectName.Location = New System.Drawing.Point(11, 138)
        Me.txtProjectName.MaxLength = 50
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(186, 20)
        Me.txtProjectName.TabIndex = 47
        '
        'txtTimeSource
        '
        Me.txtTimeSource.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTimeSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimeSource.ForeColor = System.Drawing.Color.LimeGreen
        Me.txtTimeSource.Location = New System.Drawing.Point(11, 51)
        Me.txtTimeSource.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTimeSource.Name = "txtTimeSource"
        Me.txtTimeSource.ReadOnly = True
        Me.txtTimeSource.Size = New System.Drawing.Size(186, 13)
        Me.txtTimeSource.TabIndex = 45
        Me.txtTimeSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTime
        '
        Me.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTime.ForeColor = System.Drawing.Color.LimeGreen
        Me.txtTime.Location = New System.Drawing.Point(11, 34)
        Me.txtTime.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.ReadOnly = True
        Me.txtTime.Size = New System.Drawing.Size(186, 13)
        Me.txtTime.TabIndex = 45
        Me.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDateSource
        '
        Me.txtDateSource.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDateSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateSource.ForeColor = System.Drawing.Color.LimeGreen
        Me.txtDateSource.Location = New System.Drawing.Point(13, 107)
        Me.txtDateSource.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDateSource.Name = "txtDateSource"
        Me.txtDateSource.ReadOnly = True
        Me.txtDateSource.Size = New System.Drawing.Size(184, 13)
        Me.txtDateSource.TabIndex = 45
        '
        'txtTransectTextbox
        '
        Me.txtTransectTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTransectTextbox.ForeColor = System.Drawing.Color.LimeGreen
        Me.txtTransectTextbox.Location = New System.Drawing.Point(11, 192)
        Me.txtTransectTextbox.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTransectTextbox.Name = "txtTransectTextbox"
        Me.txtTransectTextbox.ReadOnly = True
        Me.txtTransectTextbox.Size = New System.Drawing.Size(186, 13)
        Me.txtTransectTextbox.TabIndex = 45
        '
        'lblProjectName
        '
        Me.lblProjectName.AutoSize = True
        Me.lblProjectName.Location = New System.Drawing.Point(8, 122)
        Me.lblProjectName.Name = "lblProjectName"
        Me.lblProjectName.Size = New System.Drawing.Size(74, 13)
        Me.lblProjectName.TabIndex = 46
        Me.lblProjectName.Text = "Project Name:"
        '
        'txtOnOffBottomTextbox
        '
        Me.txtOnOffBottomTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOnOffBottomTextbox.Location = New System.Drawing.Point(12, 250)
        Me.txtOnOffBottomTextbox.Margin = New System.Windows.Forms.Padding(2)
        Me.txtOnOffBottomTextbox.Name = "txtOnOffBottomTextbox"
        Me.txtOnOffBottomTextbox.ReadOnly = True
        Me.txtOnOffBottomTextbox.Size = New System.Drawing.Size(185, 13)
        Me.txtOnOffBottomTextbox.TabIndex = 44
        '
        'lblTransectDate
        '
        Me.lblTransectDate.AutoSize = True
        Me.lblTransectDate.Location = New System.Drawing.Point(8, 66)
        Me.lblTransectDate.Name = "lblTransectDate"
        Me.lblTransectDate.Size = New System.Drawing.Size(156, 13)
        Me.lblTransectDate.TabIndex = 48
        Me.lblTransectDate.Text = "Transect Date DD/MM/YYYY: "
        '
        'cmdTransectStart
        '
        Me.cmdTransectStart.Enabled = False
        Me.cmdTransectStart.Location = New System.Drawing.Point(11, 163)
        Me.cmdTransectStart.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdTransectStart.Name = "cmdTransectStart"
        Me.cmdTransectStart.Size = New System.Drawing.Size(186, 25)
        Me.cmdTransectStart.TabIndex = 41
        Me.cmdTransectStart.Text = "Transect Start"
        Me.cmdTransectStart.UseVisualStyleBackColor = True
        '
        'cmdShowSetTimecode
        '
        Me.cmdShowSetTimecode.Enabled = False
        Me.cmdShowSetTimecode.Location = New System.Drawing.Point(13, 5)
        Me.cmdShowSetTimecode.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdShowSetTimecode.Name = "cmdShowSetTimecode"
        Me.cmdShowSetTimecode.Size = New System.Drawing.Size(184, 25)
        Me.cmdShowSetTimecode.TabIndex = 40
        Me.cmdShowSetTimecode.Text = "Set Time"
        Me.cmdShowSetTimecode.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer6)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.cmdAddComment)
        Me.SplitContainer2.Panel2.Controls.Add(Me.cmdNothingInPhoto)
        Me.SplitContainer2.Size = New System.Drawing.Size(886, 497)
        Me.SplitContainer2.SplitterDistance = 423
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer6.Name = "SplitContainer6"
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.AutoScroll = True
        Me.SplitContainer6.Panel1.Controls.Add(Me.SplitContainer7)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.AutoScroll = True
        Me.SplitContainer6.Panel2.Controls.Add(Me.SplitContainer8)
        Me.SplitContainer6.Size = New System.Drawing.Size(886, 423)
        Me.SplitContainer6.SplitterDistance = 394
        Me.SplitContainer6.TabIndex = 44
        '
        'SplitContainer7
        '
        Me.SplitContainer7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer7.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer7.Name = "SplitContainer7"
        Me.SplitContainer7.Size = New System.Drawing.Size(394, 423)
        Me.SplitContainer7.SplitterDistance = 197
        Me.SplitContainer7.TabIndex = 0
        '
        'SplitContainer8
        '
        Me.SplitContainer8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer8.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer8.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer8.Name = "SplitContainer8"
        Me.SplitContainer8.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer8.Panel1
        '
        Me.SplitContainer8.Panel1.Controls.Add(Me.pnlSpeciesEntryControls)
        Me.SplitContainer8.Size = New System.Drawing.Size(488, 423)
        Me.SplitContainer8.SplitterDistance = 79
        Me.SplitContainer8.SplitterWidth = 1
        Me.SplitContainer8.TabIndex = 0
        '
        'pnlSpeciesEntryControls
        '
        Me.pnlSpeciesEntryControls.AutoScroll = True
        Me.pnlSpeciesEntryControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSpeciesEntryControls.Controls.Add(Me.cmdRareSpeciesLookup)
        Me.pnlSpeciesEntryControls.Controls.Add(Me.radQuickEntry)
        Me.pnlSpeciesEntryControls.Controls.Add(Me.cmdEdit)
        Me.pnlSpeciesEntryControls.Controls.Add(Me.radAbundanceEntry)
        Me.pnlSpeciesEntryControls.Controls.Add(Me.radDetailedEntry)
        Me.pnlSpeciesEntryControls.Controls.Add(Me.lblQuickSpeciesCount)
        Me.pnlSpeciesEntryControls.Controls.Add(Me.txtQuickSpeciesCount)
        Me.pnlSpeciesEntryControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSpeciesEntryControls.Location = New System.Drawing.Point(0, 0)
        Me.pnlSpeciesEntryControls.Name = "pnlSpeciesEntryControls"
        Me.pnlSpeciesEntryControls.Size = New System.Drawing.Size(488, 79)
        Me.pnlSpeciesEntryControls.TabIndex = 38
        '
        'cmdRareSpeciesLookup
        '
        Me.cmdRareSpeciesLookup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRareSpeciesLookup.Location = New System.Drawing.Point(6, 29)
        Me.cmdRareSpeciesLookup.Name = "cmdRareSpeciesLookup"
        Me.cmdRareSpeciesLookup.Size = New System.Drawing.Size(140, 44)
        Me.cmdRareSpeciesLookup.TabIndex = 59
        Me.cmdRareSpeciesLookup.Text = "Rare Species Lookup"
        Me.cmdRareSpeciesLookup.UseVisualStyleBackColor = True
        Me.cmdRareSpeciesLookup.Visible = False
        '
        'radQuickEntry
        '
        Me.radQuickEntry.AutoSize = True
        Me.radQuickEntry.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radQuickEntry.Location = New System.Drawing.Point(5, 3)
        Me.radQuickEntry.Name = "radQuickEntry"
        Me.radQuickEntry.Size = New System.Drawing.Size(99, 20)
        Me.radQuickEntry.TabIndex = 44
        Me.radQuickEntry.Text = "Quick Entry"
        Me.radQuickEntry.UseVisualStyleBackColor = True
        Me.radQuickEntry.Visible = False
        '
        'cmdEdit
        '
        Me.cmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdit.Location = New System.Drawing.Point(152, 29)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(140, 44)
        Me.cmdEdit.TabIndex = 45
        Me.cmdEdit.Text = "Edit Species List"
        Me.cmdEdit.UseVisualStyleBackColor = True
        Me.cmdEdit.Visible = False
        '
        'radAbundanceEntry
        '
        Me.radAbundanceEntry.AutoSize = True
        Me.radAbundanceEntry.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radAbundanceEntry.Location = New System.Drawing.Point(232, 3)
        Me.radAbundanceEntry.Name = "radAbundanceEntry"
        Me.radAbundanceEntry.Size = New System.Drawing.Size(138, 20)
        Me.radAbundanceEntry.TabIndex = 43
        Me.radAbundanceEntry.Text = "Abundance Entry"
        Me.radAbundanceEntry.UseVisualStyleBackColor = True
        Me.radAbundanceEntry.Visible = False
        '
        'radDetailedEntry
        '
        Me.radDetailedEntry.AutoSize = True
        Me.radDetailedEntry.Checked = True
        Me.radDetailedEntry.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDetailedEntry.Location = New System.Drawing.Point(108, 3)
        Me.radDetailedEntry.Name = "radDetailedEntry"
        Me.radDetailedEntry.Size = New System.Drawing.Size(118, 20)
        Me.radDetailedEntry.TabIndex = 43
        Me.radDetailedEntry.TabStop = True
        Me.radDetailedEntry.Text = "Detailed Entry"
        Me.radDetailedEntry.UseVisualStyleBackColor = True
        Me.radDetailedEntry.Visible = False
        '
        'lblQuickSpeciesCount
        '
        Me.lblQuickSpeciesCount.AutoSize = True
        Me.lblQuickSpeciesCount.Location = New System.Drawing.Point(298, 32)
        Me.lblQuickSpeciesCount.Name = "lblQuickSpeciesCount"
        Me.lblQuickSpeciesCount.Size = New System.Drawing.Size(62, 26)
        Me.lblQuickSpeciesCount.TabIndex = 45
        Me.lblQuickSpeciesCount.Text = "Quick Entry" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Count"
        Me.lblQuickSpeciesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblQuickSpeciesCount.Visible = False
        '
        'txtQuickSpeciesCount
        '
        Me.txtQuickSpeciesCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuickSpeciesCount.Location = New System.Drawing.Point(366, 32)
        Me.txtQuickSpeciesCount.Name = "txtQuickSpeciesCount"
        Me.txtQuickSpeciesCount.Size = New System.Drawing.Size(38, 23)
        Me.txtQuickSpeciesCount.TabIndex = 39
        Me.txtQuickSpeciesCount.Visible = False
        '
        'cmdAddComment
        '
        Me.cmdAddComment.Location = New System.Drawing.Point(0, 34)
        Me.cmdAddComment.Name = "cmdAddComment"
        Me.cmdAddComment.Size = New System.Drawing.Size(154, 30)
        Me.cmdAddComment.TabIndex = 37
        Me.cmdAddComment.Text = "Add Comment"
        Me.cmdAddComment.UseVisualStyleBackColor = True
        Me.cmdAddComment.Visible = False
        '
        'cmdNothingInPhoto
        '
        Me.cmdNothingInPhoto.Location = New System.Drawing.Point(160, 34)
        Me.cmdNothingInPhoto.Name = "cmdNothingInPhoto"
        Me.cmdNothingInPhoto.Size = New System.Drawing.Size(154, 30)
        Me.cmdNothingInPhoto.TabIndex = 55
        Me.cmdNothingInPhoto.Text = "Nothing In Photo"
        Me.cmdNothingInPhoto.UseVisualStyleBackColor = True
        Me.cmdNothingInPhoto.Visible = False
        '
        'tmrRecordPerSecond
        '
        Me.tmrRecordPerSecond.Interval = 200
        '
        'tmrPlayForSeconds
        '
        Me.tmrPlayForSeconds.Interval = 10
        '
        'tmrComputerTime
        '
        Me.tmrComputerTime.Interval = 500
        '
        'VideoMiner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1098, 729)
        Me.Controls.Add(Me.SplitContainer5)
        Me.Controls.Add(Me.mnStrVideoMinerMenu)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnStrVideoMinerMenu
        Me.Name = "VideoMiner"
        Me.Text = "VideoMiner 3.1.0.0 BETA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnStrVideoMinerMenu.ResumeLayout(False)
        Me.mnStrVideoMinerMenu.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.Panel2.PerformLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.pnlVideoControls.ResumeLayout(False)
        Me.pnlVideoControls.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer6.ResumeLayout(False)
        CType(Me.SplitContainer7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer7.ResumeLayout(False)
        Me.SplitContainer8.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer8.ResumeLayout(False)
        Me.pnlSpeciesEntryControls.ResumeLayout(False)
        Me.pnlSpeciesEntryControls.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnStrVideoMinerMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenDatabase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenSession As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveSession As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveSessionAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCloseDatabase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVideoTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRefreshForm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUseExternalVideo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblDatabase As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblVideo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents mnuCapScr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fldlgOpenFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tmrRecordPerSecond As System.Windows.Forms.Timer
    Friend WithEvents tmrPlayForSeconds As System.Windows.Forms.Timer
    Friend WithEvents svDlgFileDialogScrCap As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuNameOptionRoot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNameOption_1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNameOption_2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNameOption_4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNameOption_5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNameOption_3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNameOption_6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNameOption_7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNameOption_8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuNameOption_9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents radQuickEntry As System.Windows.Forms.RadioButton
    Friend WithEvents radDetailedEntry As System.Windows.Forms.RadioButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblVideoControls As System.Windows.Forms.Label
    Friend WithEvents txtPlaySeconds As System.Windows.Forms.TextBox
    Friend WithEvents cmdPlayForSeconds As System.Windows.Forms.Button
    Friend WithEvents txtTransectDate As System.Windows.Forms.TextBox
    Friend WithEvents chkRecordEachSecond As System.Windows.Forms.CheckBox
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents cmdPlayPause As System.Windows.Forms.Button
    Friend WithEvents txtTransectTextbox As System.Windows.Forms.TextBox
    Friend WithEvents lblProjectName As System.Windows.Forms.Label
    Friend WithEvents txtOnOffBottomTextbox As System.Windows.Forms.TextBox
    Friend WithEvents lblTransectDate As System.Windows.Forms.Label
    Friend WithEvents cmdTransectStart As System.Windows.Forms.Button
    Friend WithEvents cmdShowSetTimecode As System.Windows.Forms.Button
    Friend WithEvents cmdNothingInPhoto As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer6 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer7 As System.Windows.Forms.SplitContainer
    Friend WithEvents mnthCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents cmdCloseCalendar As System.Windows.Forms.Button
    Friend WithEvents mnuConfigureTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtQuickSpeciesCount As System.Windows.Forms.TextBox
    Friend WithEvents lblQuickSpeciesCount As System.Windows.Forms.Label
    Friend WithEvents cmdRareSpeciesLookup As System.Windows.Forms.Button
    Friend WithEvents KeyboardShortcutsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigureHabitatButtonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigureTransectButtonsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdDecreaseRate As System.Windows.Forms.Button
    Friend WithEvents cmdIncreaseRate As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents pnlVideoControls As System.Windows.Forms.Panel
    Friend WithEvents mnuImageTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenImg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GPSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGPSSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblRate As System.Windows.Forms.Label
    Friend WithEvents lblVideoRate As System.Windows.Forms.Label
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents chkResumeVideo As System.Windows.Forms.CheckBox
    Friend WithEvents DataCodeAssignmentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents radAbundanceEntry As System.Windows.Forms.RadioButton
    Friend WithEvents svDlgFileDialogSession As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeviceControl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelayConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtNMEA As System.Windows.Forms.TextBox
    Friend WithEvents cmdScreenCapture As System.Windows.Forms.Button
    Friend WithEvents chkDefineAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblGPSPort As System.Windows.Forms.Label
    Friend WithEvents lblZValue As System.Windows.Forms.Label
    Friend WithEvents lblYValue As System.Windows.Forms.Label
    Friend WithEvents lblGPSConnectionValue As System.Windows.Forms.Label
    Friend WithEvents lblZ As System.Windows.Forms.Label
    Friend WithEvents lblY As System.Windows.Forms.Label
    Friend WithEvents lblGPSConnection As System.Windows.Forms.Label
    Friend WithEvents lblXValue As System.Windows.Forms.Label
    Friend WithEvents lblGPSPortValue As System.Windows.Forms.Label
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents txtDateSource As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeSource As System.Windows.Forms.TextBox
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents lblGPSLocation As System.Windows.Forms.Label
    Friend WithEvents tmrComputerTime As System.Windows.Forms.Timer
    Friend WithEvents EditLookupTableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlSpeciesEntryControls As System.Windows.Forms.Panel
    Friend WithEvents InformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtFramesToSkip As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddComment As System.Windows.Forms.Button
    Friend WithEvents SplitContainer8 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdOffBottom As Button
    Friend WithEvents mnuShowTooltips As ToolStripMenuItem
    Friend WithEvents DataTableColumnsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpeciesButtonsToolStripMenuItem As ToolStripMenuItem
End Class
