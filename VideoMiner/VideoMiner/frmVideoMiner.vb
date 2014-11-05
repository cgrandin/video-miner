' This application is an example for using the VideoMinerPlayer OCX control
' The buttons and menu items control various methods within the OCX library
' The delegates must be used to invoke the functions inside the OCX from a .NET application 

'Imports System.io
' The following 3 imports are necessary for using ADO.NET, which permits database access.
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.TimeSpan
Imports Microsoft.VisualBasic
Imports System.IO.Ports
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Path
Imports Microsoft.Win32
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Xml
Imports System.Reflection
Imports System.Threading

' ==========================================================================================================
' Name: VideoMiner
' Description: This is the main form of the program.
' ==========================================================================================================
Public Class VideoMiner

#Region "Fields"
#Region "VideoMiner Fields"
    Private m_RangeChecked As Boolean
    Private m_IDConfidenceChecked As Boolean
    Private m_AbundanceChecked As Boolean
    Private m_CountChecked As Boolean
    Private m_HeightChecked As Boolean
    Private m_WidthChecked As Boolean
    Private m_LengthChecked As Boolean
    Private m_CommentsChecked As Boolean

    Private m_SpeciesCode As String
    Private m_SpeciesName As String

    Private m_FileName As String
    Private m_ScreenCaptureName As String
    Private m_ElapsedTime As String

    Private m_Side As String
    Private m_Range As String
    Private m_IDConfidence As String
    Private m_Abundance As String
    Private m_Count As String
    Private m_Height As String
    Private m_Width As String
    Private m_Length As String
    Private m_Comments As String

    Private m_FfwdCount As Integer
    Private m_RwndCount As Integer

    Private m_VideoTime As TimeSpan
    Private m_SessionName As String
    Private m_Version As String

    Private m_GPSDate As String
    Private m_GPSDateTime As String
    Private m_GPSUserTime As String
    Private m_GPS_X As Double
    Private m_GPS_Y As Double
    Private m_GPS_Z As Double

    Private m_ButtonWidth As Integer
    Private m_ButtonHeight As Integer
    Private m_ButtonTextSize As Integer
    Private m_ButtonFont As String
#End Region
#Region "Relay Configuration"
    Private m_ConfigurationSet As Boolean
    Private m_RelaySetup As String
    Private m_ParallelCom As String
    Private m_ParallelBaud As Integer
    Private m_PortOneCom As String
    Private m_PortTwoCom As String
    Private m_PortOneBaud As Integer
    Private m_PortTwoBaud As Integer
    Private m_DeviceOneRelayOne As String
    Private m_DeviceOneRelayTwo As String
    Private m_DeviceOneRelayThree As String
    Private m_DeviceOneRelayFour As String
    Private m_DeviceTwoRelayOne As String
    Private m_DeviceTwoRelayTwo As String
    Private m_DeviceTwoRelayThree As String
    Private m_DeviceTwoRelayFour As String
#End Region

#End Region

#Region "Properties"
#Region "VideoMiner Properties"
    Public Property SpeciesCode() As String
        Get
            Return m_SpeciesCode
        End Get
        Set(ByVal value As String)
            m_SpeciesCode = value
        End Set
    End Property

    Public Property SpeciesName() As String
        Get
            Return m_SpeciesName
        End Get
        Set(ByVal value As String)
            m_SpeciesName = value
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return m_FileName
        End Get
        Set(ByVal value As String)
            m_FileName = value
        End Set
    End Property

    Public Property ScreenCaptureName() As String
        Get
            Return m_ScreenCaptureName
        End Get
        Set(ByVal value As String)
            m_ScreenCaptureName = value
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


    Public Property Side() As String
        Get
            Return m_Side
        End Get
        Set(ByVal value As String)
            m_Side = value
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

    Public Property FfwdCount() As Integer
        Get
            Return m_FfwdCount
        End Get
        Set(ByVal value As Integer)
            m_FfwdCount = value
        End Set
    End Property

    Public Property RwndCOunt() As Integer
        Get
            Return m_RwndCount
        End Get
        Set(ByVal value As Integer)
            m_RwndCount = value
        End Set
    End Property

    Public Property ElapsedTime() As String
        Get
            Return m_ElapsedTime
        End Get
        Set(ByVal value As String)
            m_ElapsedTime = value
        End Set
    End Property

    Public Property VideoTime() As TimeSpan
        Get
            Return m_VideoTime
        End Get
        Set(ByVal value As TimeSpan)
            m_VideoTime = value
        End Set
    End Property

    Public Property SessionName() As String
        Get
            Return m_SessionName
        End Get
        Set(ByVal value As String)
            m_SessionName = value
        End Set
    End Property

    Public Property Version() As String
        Get
            Return m_Version
        End Get
        Set(ByVal value As String)
            m_Version = value
        End Set
    End Property

    Public Property GPSDate() As String
        Get
            Return m_GPSDate
        End Get
        Set(ByVal value As String)
            m_GPSDate = value
        End Set
    End Property

    Public Property GPSDateTime() As String
        Get
            Return m_GPSDateTime
        End Get
        Set(ByVal value As String)
            m_GPSDateTime = value
        End Set
    End Property

    Public Property GPSUserTime() As String
        Get
            Return m_GPSUserTime
        End Get
        Set(ByVal value As String)
            m_GPSUserTime = value
        End Set
    End Property

    Public Property GPS_X() As Double
        Get
            Return m_GPS_X
        End Get
        Set(ByVal value As Double)
            m_GPS_X = value
        End Set
    End Property

    Public Property GPS_Y() As Double
        Get
            Return m_GPS_Y
        End Get
        Set(ByVal value As Double)
            m_GPS_Y = value
        End Set
    End Property

    Public Property GPS_Z() As Double
        Get
            Return m_GPS_Z
        End Get
        Set(ByVal value As Double)
            m_GPS_Z = value
        End Set
    End Property

    Public Property ButtonWidth() As Integer
        Get
            Return m_ButtonWidth
        End Get
        Set(ByVal value As Integer)
            m_ButtonWidth = value
        End Set
    End Property
    Public Property ButtonHeight() As Integer
        Get
            Return m_ButtonHeight
        End Get
        Set(ByVal value As Integer)
            m_ButtonHeight = value
        End Set
    End Property
    Public Property ButtonTextSize() As Integer
        Get
            Return m_ButtonTextSize
        End Get
        Set(ByVal value As Integer)
            m_ButtonTextSize = value
        End Set
    End Property
    Public Property ButtonFont() As String
        Get
            Return m_ButtonFont
        End Get
        Set(ByVal value As String)
            m_ButtonFont = value
        End Set
    End Property

#End Region
#Region "Relay Properties"
    Public Property ConfigurationSet() As Boolean
        Get
            Return m_ConfigurationSet
        End Get
        Set(ByVal value As Boolean)
            m_ConfigurationSet = value
        End Set
    End Property

    Public Property RelaySetup() As String
        Get
            Return m_RelaySetup
        End Get
        Set(ByVal value As String)
            m_RelaySetup = value
        End Set
    End Property

    Public Property ParallelCom() As String
        Get
            Return m_ParallelCom
        End Get
        Set(ByVal value As String)
            m_ParallelCom = value
        End Set
    End Property

    Public Property ParallelBaud() As Integer
        Get
            Return m_ParallelBaud
        End Get
        Set(ByVal value As Integer)
            m_ParallelBaud = value
        End Set
    End Property

    Public Property PortOneCom() As String
        Get
            Return m_PortOneCom
        End Get
        Set(ByVal value As String)
            m_PortOneCom = value
        End Set
    End Property

    Public Property PortTwoCom() As String
        Get
            Return m_PortTwoCom
        End Get
        Set(ByVal value As String)
            m_PortTwoCom = value
        End Set
    End Property

    Public Property PortOneBaud() As Integer
        Get
            Return m_PortOneBaud
        End Get
        Set(ByVal value As Integer)
            m_PortOneBaud = value
        End Set
    End Property

    Public Property PortTwoBaud() As Integer
        Get
            Return m_PortTwoBaud
        End Get
        Set(ByVal value As Integer)
            m_PortTwoBaud = value
        End Set
    End Property

    Public Property DeviceOneRelayOne() As String
        Get
            Return m_DeviceOneRelayOne
        End Get
        Set(ByVal value As String)
            m_DeviceOneRelayOne = value
        End Set
    End Property

    Public Property DeviceOneRelayTwo() As String
        Get
            Return m_DeviceOneRelayTwo
        End Get
        Set(ByVal value As String)
            m_DeviceOneRelayTwo = value
        End Set
    End Property

    Public Property DeviceOneRelayThree() As String
        Get
            Return m_DeviceOneRelayThree
        End Get
        Set(ByVal value As String)
            m_DeviceOneRelayThree = value
        End Set
    End Property

    Public Property DeviceOneRelayFour() As String
        Get
            Return m_DeviceOneRelayFour
        End Get
        Set(ByVal value As String)
            m_DeviceOneRelayFour = value
        End Set
    End Property

    Public Property DeviceTwoRelayOne() As String
        Get
            Return m_DeviceTwoRelayOne
        End Get
        Set(ByVal value As String)
            m_DeviceTwoRelayOne = value
        End Set
    End Property

    Public Property DeviceTwoRelayTwo() As String
        Get
            Return m_DeviceTwoRelayTwo
        End Get
        Set(ByVal value As String)
            m_DeviceTwoRelayTwo = value
        End Set
    End Property

    Public Property DeviceTwoRelayThree() As String
        Get
            Return m_DeviceTwoRelayThree
        End Get
        Set(ByVal value As String)
            m_DeviceTwoRelayThree = value
        End Set
    End Property

    Public Property DeviceTwoRelayFour() As String
        Get
            Return m_DeviceTwoRelayFour
        End Get
        Set(ByVal value As String)
            m_DeviceTwoRelayFour = value
        End Set
    End Property

#End Region
#End Region

#Region "Constants"
    ' Constants
    Public Const DB_NAME As String = "testVideoMiner.mdb"
    Public Const DB_ADO_CONN_STRING_1 As String = "Data Source="
    Public Const DB_ADO_CONN_STRING_2 As String = ";Initial Catalog=data"
    Public Const BAD_ID As Long = -1
    Public Const VIDEO_PLAYER_NAME As String = "VideoMinerPlayer"
    Public Const OPEN_DB_TITLE As String = "Open Database"
    Public Const OPEN_VID_TITLE As String = "Open Video File"
    Public Const DB_FILE_FILTER As String = "MS Access files (*.mdb)|*.mdb"
    Public Const DB_FILE_STATUS_LOADED As String = "Database '"
    Public Const VIDEO_FILE_STATUS_LOADED As String = "Video file is open"
    Public Const DB_FILE_STATUS_UNLOADED As String = "No database open"
    Public Const VIDEO_FILE_STATUS_UNLOADED As String = "No video file open"
    Public Const IS_OPEN As String = "' is open"
    Public Const STATUS_FONT_SIZE As Integer = 10
    Public Const DIR_SEP As String = "\"
    Public Const NULL_STRING As String = ""
    Public Const ABOUT_STAMP As String = "VideoMiner 1.0 © Chris Grandin 2008"
    Public Const UNNAMED_TRANSECT As String = "Unnamed Transect"
    Public Const NO_TRANSECT As String = "No Transect"
    Public Const NO_SUBSTRATE As String = "No Substrate"
    Public Const NO_BIOCOVER As String = "No Biocover"
    Public Const NO_RELIEF As String = "No Relief"
    Public Const NO_COMPLEXITY As String = "No Complexity"
    Public Const OFF_BOTTOM_STRING As String = "Off bottom"
    Public Const ON_BOTTOM_STRING As String = "On bottom"
#End Region

#Region "Variables"
    ' Member variables
    Public strMilliseconds As String = "00"
    Public current_directory As String
    Public video_file_open As Boolean
    Private select_string As String
    Private insert_string As String
    Private transect_name As String
    Private project_name As String = ""
    Private transect_date As String = ""
    Private substrate_name As String
    Private substrate_code As String

    Public strKeyboardShortcut As String = ""
    Public strCurrentKey As String = ""
    Private value As Array = [Enum].GetValues(GetType(Keys))

    Public image_open As Boolean = False
    Public image_prefix As String
    Public fileNames() As String
    Private relief_name As String
    Private relief_code As String
    Private is_on_bottom As Integer
    Private curr_code As String
    Private curr_name As String
    Private blHandled As Boolean = False

    ' Variables to store form values
    Public strWidth As String
    Public strComment As String
    Private strSide As String
    Private strRange As String
    Private strLength As String
    Private strHeight As String
    Private strAbundance As String
    Private strIdConfidence As String
    Private strSpeciesCount As String
    Private strSpeciesCode As String

    Public blSpeciesValuesSet As Boolean = False

    Private intVideoSeconds As Integer = 0
    Private intPreviousVideoSeconds As Integer = 0
    Private intGPSSeconds As Integer = 0
    Private intPreviousGPSSeconds As Integer = 0
    Private blFirstTime As Boolean = False
    Private blGPSFirstTime As Boolean = False

    ' Variables to store Play for Seconds variables
    Private dblPlaySecondsTC As Double = 0
    Private strPlaySecondsVideoTime As String = VIDEO_TIME_LABEL
    Private intPlayForSeconds As Integer
    Private intPlayForSecondsTimerCount As Integer = 0
    Private intStartPlaySeconds As Integer
    Private intCurrentPlaySeconds As Integer
    Private intEndPlaySeconds As Integer = 0
    Private dblVideoRate As Double = 1


    ' Comparison value for reord every second functionality    
    Public intLastVideoSecond As Integer = 0
    Public intLastVideoMinute As Integer = 0
    Public intLastVideoHour As Integer = 0
    Public intVideoStopCounter As Integer = 0
    Public blSpeciesCancelled As Boolean = False
    Private blIsDuplicateTime As Boolean = False

    ' Database variables
    Public db_filename As String
    Public db_file_open As Boolean
    Private db_id_num As Long
    Private data_cmd As OleDbCommand
    Private data_adapter As OleDbDataAdapter
    Private data_set As DataSet
    Private data_table As DataTable
    Private data_binding As BindingSource
    Private data_command_builder As OleDbCommandBuilder
    Private last_data_row As DataRow

    ' User buttons
    Dim button_height As Integer = 44
    Dim button_width As Integer = 154

    ' For the habitat variables
    Public textboxes() As TextBox
    Public strHabitatButtonCodeNames() As String ' name of the fields where the data came from when user clicks a user button
    Private buttons() As Button
    Private intHabitatButtonCodes() As Integer
    Private strHabitatButtonTables() As String
    Private strHabitatButtonUserCodeChoice() As String
    Private strHabitatButtonUserNameChoice() As String
    Private strHabitatButtonColors() As String
    Private intNumHabitatButtons As Integer

    ' Transect variables
    Public Transect_Textboxes() As TextBox
    Public strTransectButtonCodeNames() As String
    Private Transect_Buttons() As Button
    Private intTransectButtonCodes() As Integer
    Private strTransectButtonTables() As String
    Private strTransectButtonUserCodeChoice() As String
    Private strTransectButtonUserNameChoice() As String
    Private strTransectButtonColors() As String
    Private intNumTransectButtons As Integer

    ' for the species variables
    Public speciesButtons() As Button
    Private strSpeciesButtonCodes() As String ' species codes
    Private strSpeciesButtonNames() As String
    Private strSpeciesButtonCodeNames() As String ' name of the fields where the data came from when user clicks a user button
    Private intSpeciesButtonUserCodeChoice() As Integer
    Private strSpeciesButtonUserNameChoice() As String
    Private strSpeciesButtonColors() As String
    Private intNumSpeciesButtons As Integer

    ' Collection and dictionaries to handle dynamically updating the habitat species values
    Private colTableFields As Collection
    Private colTransectFields As Collection

    'Private frmImageForm As frmImage
    Private lastImageIndex As Integer = 0
    Public image_index As Integer = 0

    ' The name of the current image including the path
    Private currentImage As String
    Private strFileType As String
    Private intCurrentZoom As Integer
    Private blSizeChanged As Boolean = False

    Private intNumberDisplayRecords As Integer = 0
    Private intDefaultNumberDisplayRecords As Integer = 15
    Private strQuickEntryCount As String = ""
    Private strDefaultQuickEntryCount As String = "1"

    Private blVideoWasPlaying As Boolean = False

    Public imageFilesList As List(Of String)
    Public imagePath As String = ""

    Public WithEvents aSerialPort As IO.Ports.SerialPort = m_PublicSerialPort
    Public m_SerialPort As IO.Ports.SerialPort
    Public tryCount As Integer = 0
    Public aquiredTryCount As Integer = 0
    Public searchingCounter As Integer = 0
    Public strPreviousGPSTime As String = ""
    Public dblGPSExpiry As Double = 0


    Public strTimeDateSource As String = "ELAPSED"
    Public strPreviousClipTime As String = VIDEO_TIME_DECIMAL_LABEL
    Public blUseGPSTime As Boolean = False
    Public blUseComputerTime As Boolean = False
    Public blUseElapsedTime As Boolean = False
    Public blUseVideoTime As Boolean = False
    Public intTimeSource As Integer = 1
    Public blImageWarning As Boolean = True
    Public blScreenCaptureCalled As Boolean = False
    Public blOpenDatabase As Boolean = False
    Public blCloseDatabase As Boolean = False
    Public dblVideoStartPosition As Double = 0
    'Public txtNMEAStringData As String = ""

    Public dataColumns As Collection
    Public blupdateColumns As Boolean = True

#End Region

#Region "Delegate Function Declarations"
    ' Delegates for ActiveX object
    ' Do not remove the following 10 lines, they are required for access to the VideoMinerPlayer activex object's functions
    Public Delegate Function InvokeOpenFile() As Integer
    Public Delegate Function InvokeOpenDV() As Integer
    Public Delegate Sub InvokePlay()
    Public Delegate Sub InvokeStepRev()
    Public Delegate Sub InvokeStepFwd()
    Public Delegate Sub InvokePause()
    Public Delegate Sub InvokeStop()
    Public Delegate Sub InvokeToggleMenuVisibility()
    Public Delegate Sub InvokeOpenSession()
    Public Delegate Sub InvokeSaveSession()
    Public Delegate Sub InvokeSaveSessionAs()
    'Public Declare Unicode Sub InvokeScrCap Lib "DVTapeControllerLib.dll" Alias "_readFile@4" (ByVal strFileName As String)
    Public Delegate Sub InvokeScrCap(ByVal strFileName As String)
    Public Delegate Function InvokeGetTimeCode() As String
    Public Delegate Function InvokeSetTimeCode(ByVal x As String) As Integer
    Private Delegate Sub myDelegate()
    Private Delegate Sub updateTextBoxCallback()

#End Region

#Region "Video Miner Controls"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case CType(msg.WParam.ToInt32, Keys)
            Case Keys.Enter
                'indicates you've handled the message sent by the enter key press here; basically, you're eating up these messages
                Return True
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
    End Function

    ' ==========================================================================================================
    ' Name: frmVideoMiner_Load
    ' Description: The following code is run when the form loads. 
    ' 1.) Disable buttons that are not be used until video and database files are opened.
    ' 2.) Load configuration file
    ' 3.) Change informative text to read no video and no db loaded.
    ' 4.) Set variables to initial state.
    ' ==========================================================================================================
    Private Sub frmVideoMiner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myFormLibrary.frmVideoMiner = Me

        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

        Dim assembly As System.Reflection.Assembly
        Dim asType As Type
        Dim strVersion As String
        asType = MyBase.GetType
        assembly = System.Reflection.Assembly.GetAssembly(asType)
        Dim aAssemblyInfo As New AssemblyInfo(assembly)
        Dim aVersionInfo As Version
        aVersionInfo = aAssemblyInfo.Version
        strVersion = aVersionInfo.Major & "." & _
        aVersionInfo.Minor & "." & _
        aVersionInfo.Build & "." & _
        aVersionInfo.Revision

        Me.Version = strVersion
        Me.Text = "Video Miner " & Me.Version & " BETA"

        filePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        Dim strRegFilePath As String = Registry.GetValue("HKEY_CURRENT_USER\VideoMiner", "FilePath", Nothing)
        Dim strConfigFilePath As String
        If strRegFilePath = "" Then
            'Registry key not available
            Dim strCurrDir As String = Directory.GetCurrentDirectory()
            strConfigFilePath = Path.Combine(strCurrDir, "Config")
        Else
            'Use registry key if available, otherwise use the current working directory
            strConfigFilePath = Path.Combine(strRegFilePath, "Config")
        End If

        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.CreateSubKey("Software\VideoMiner")
        regKey.SetValue("GPSStringType", "GPGGA")

        ' Enable Key preview so that video player hotkeys can be instantiated from this forms event handler.
        Me.KeyPreview = True

        Dim aPort As SerialPort
        aPort = New SerialPort
        myPortLibrary.aPort = aPort

        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        Console.WriteLine(intX & ":" & intY)

        Dim aPoint As System.Drawing.Point
        aPoint.X = intX
        aPoint.Y = intY / 2

        Dim strConfigFile As String = Path.Combine(strConfigFilePath, "VideoMinerConfigurationDetails.xml")
        If File.Exists(strConfigFile) Then
            Me.ButtonHeight = CInt(GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/ButtonFormat/ButtonSize/Height"))
            Me.ButtonWidth = CInt(GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/ButtonFormat/ButtonSize/Width"))
            Me.ButtonTextSize = CInt(GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/ButtonFormat/ButtonText/TextSize"))
            Me.ButtonFont = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/ButtonFormat/ButtonText/Font")
        Else
            Dim strWarning As String = "The configuration file " & strConfigFile & " does not exist. Closing VideoMiner."
            MessageBox.Show(strWarning, "No configuration file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If

        current_directory = Environment.SpecialFolder.Personal
        db_file_open = False
        video_file_open = False
        db_file_unload()
        video_file_unload()
        no_files_loaded()
        transect_name = UNNAMED_TRANSECT
        transect_stopped(NULL_STRING, NULL_STRING, NULL_STRING & ".00", "NULL", "NULL", "NULL")
        curr_code = BAD_ID
        is_on_bottom = 0
        toggle_bottom(NULL_STRING, NULL_STRING, NULL_STRING & ".00", "NULL", "NULL", "NULL")

        Me.cboZoom.Items.Add("25%")
        Me.cboZoom.Items.Add("50%")
        Me.cboZoom.Items.Add("75%")
        Me.cboZoom.Items.Add("100%")
        Me.cboZoom.Items.Add("200%")

        Me.cboZoom.Text = "100%"

        Me.cmdPreviousImage.Enabled = False
        Me.cmdNextImage.Enabled = False
        Me.cboZoom.Enabled = False

        Me.txtDisplayRecords.Text = intDefaultNumberDisplayRecords
        intNumberDisplayRecords = intDefaultNumberDisplayRecords

        Me.txtQuickSpeciesCount.Text = strDefaultQuickEntryCount
        strQuickEntryCount = strDefaultQuickEntryCount

        Me.SelectNextControl(Me.SplitContainer4.Panel2, False, True, True, True)

        Me.VideoTime = Zero

        ' Get the device control settings from the configuration file
        If File.Exists(strConfigFile) Then
            Call GetDeviceSettingsFromFile(strConfigFile)
        Else
            Dim strWarning As String = "The configuration file " & strConfigFile & " does not exist. Closing VideoMiner."
            MessageBox.Show(strWarning, "No configuration file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If

        ' Enable the Device Control menu based on if the configuration has been set
        ' This makes sure that the devices are not accessed until the configuration has been set
        'If Me.ConfigurationSet = False Then
        '    Me.DeviceControl.Enabled = False
        'Else
        '    Me.DeviceControl.Enabled = True
        'End If
        Dim strDate As String = ""
        If Now.Day >= 10 Then
            strDate = CStr(Now.Day)
        Else
            strDate = "0" & CStr(Now.Day)
        End If
        If Now.Month >= 10 Then
            strDate = strDate & "/" & CStr(Now.Month)
        Else
            strDate = strDate & "/0" & CStr(Now.Month)
        End If

        If Now.Year >= 10 Then
            strDate = strDate & "/" & CStr(Now.Year)
        Else
            strDate = strDate & "/0" & CStr(Now.Year)
        End If
        Me.txtTransectDate.Text = strDate
        transect_date = strDate

    End Sub

    Public Sub GetDeviceSettingsFromFile(strConfigFile As String)
        Me.ConfigurationSet = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/ConfigurationSet")
        Me.RelaySetup = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/Setup")
        Me.ParallelCom = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/Parallel/ComPort")
        Me.ParallelBaud = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/Parallel/BaudRate")
        Me.PortOneCom = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/TwoPorts/Device1/ComPort")
        Me.PortOneBaud = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/TwoPorts/Device1/BaudRate")
        Me.PortTwoCom = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/TwoPorts/Device2/ComPort")
        Me.PortTwoBaud = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/TwoPorts/Device2/BaudRate")

        Me.DeviceOneRelayOne = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/RelayNames/Device1/Relay1")
        Me.DeviceOneRelayTwo = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/RelayNames/Device1/Relay2")
        Me.DeviceOneRelayThree = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/RelayNames/Device1/Relay3")
        Me.DeviceOneRelayFour = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/RelayNames/Device1/Relay4")
        Me.DeviceTwoRelayOne = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/RelayNames/Device2/Relay1")
        Me.DeviceTwoRelayTwo = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/RelayNames/Device2/Relay2")
        Me.DeviceTwoRelayThree = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/RelayNames/Device2/Relay3")
        Me.DeviceTwoRelayFour = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DeviceControl/RelayNames/Device2/Relay4")
    End Sub

    'Private Sub VideoMiner_KeyupForVideoform(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

    '    If e.Control Then
    '        Select Case e.KeyCode
    '            Case Keys.Up
    '                playVideo()
    '            Case Keys.Down
    '                pauseVideo()
    '                'Case Keys.Right
    '                '    StepFwd()
    '                'Case Keys.Left
    '                '    StepRev()
    '        End Select
    '    End If

    'End Sub
    Private Sub VideoMiner_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim intIndex As Integer
        'MsgBox(strKeyboardShortcut)
        'MsgBox(e.KeyData)
        Select Case strKeyboardShortcut
            Case Keys.Space.ToString
                blHandled = True
                e.Handled = True
                If video_file_open Then
                    If myFormLibrary.frmVideoPlayer.blIsPlaying = False Then
                        playVideo()
                    Else
                        pauseVideo()
                    End If
                End If
            Case Keys.Enter.ToString
                MsgBox("Enter")
            Case Keys.Right.ToString
                blHandled = True
                e.Handled = True
                Dim intAnswer As Integer
                If image_open Then
                    If (myFormLibrary.frmVideoMiner.image_index + 1) > (myFormLibrary.frmVideoMiner.imageFilesList.Count - 1) Then
                        intAnswer = MessageBox.Show("You have reached the last image in the folder, would you like to start again at the first image?", "Last Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If intAnswer = vbYes Then
                            myFormLibrary.frmVideoMiner.image_index = 0
                        Else
                            Exit Sub
                        End If
                    Else
                        myFormLibrary.frmVideoMiner.image_index += 1
                    End If
                    myFormLibrary.frmVideoMiner.LoadImg()
                End If
            Case Keys.Left.ToString
                blHandled = True
                e.Handled = True
                Dim intAnswer As Integer
                If image_open Then
                    If (myFormLibrary.frmVideoMiner.image_index - 1) < 0 Then
                        intAnswer = MessageBox.Show("You have reached the first image in the folder, would you like to start again at the last image?", "First Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If intAnswer = vbYes Then
                            myFormLibrary.frmVideoMiner.image_index = myFormLibrary.frmVideoMiner.imageFilesList.Count - 1
                        Else
                            Exit Sub
                        End If
                    Else
                        myFormLibrary.frmVideoMiner.image_index -= 1
                    End If
                    myFormLibrary.frmVideoMiner.LoadImg()
                End If
            Case "Menu"
                e.SuppressKeyPress = True
            Case Else
                If strKeyboardShortcut <> "" Then
                    Dim sub_data_set As DataSet = New DataSet()

                    Dim sub_db_command As OleDbCommand = New OleDbCommand("select DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor, KeyboardShortcut from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", conn)
                    Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)

                    sub_data_adapter.Fill(sub_data_set, DB_SPECIES_BUTTONS_TABLE)

                    Dim r As DataRow
                    Dim d As DataTable
                    d = sub_data_set.Tables(0)
                    For Each r In d.Rows
                        If r.Item("KeyboardShortcut").ToString = strKeyboardShortcut Then
                            intIndex = CInt(r.Item("DrawingOrder")) - 1
                            If Not speciesButtons(intIndex) Is Nothing Then
                                Call SpeciesVariableButtonHandler(speciesButtons(intIndex), Nothing)
                            End If
                            Exit For
                        End If
                    Next
                End If
        End Select
        strKeyboardShortcut = ""
        strCurrentKey = ""
        Try


        Catch ex As Exception

        End Try
    End Sub
    Public Sub VideoMiner_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If strCurrentKey <> CStr(e.KeyValue) Then
            strCurrentKey = CStr(e.KeyValue)
            Dim key As Object
            For Each key In value
                If e.KeyValue = key Then
                    If strKeyboardShortcut = "" Then
                        strKeyboardShortcut = key.ToString
                    Else
                        strKeyboardShortcut = strKeyboardShortcut & "+" & key.ToString
                    End If
                    If e.KeyValue = Keys.Alt Then
                        e.SuppressKeyPress = True
                    End If
                End If

            Next
        End If
    End Sub

    Private Sub mnuOpenFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOpenFile.Click
        Me.strPreviousClipTime = Me.txtTime.Text
        If Not myFormLibrary.frmImage Is Nothing Then
            Dim intAnswer As Integer = MessageBox.Show("The image file '" & Me.FileName & "' is currently open. In order to open a video, the image will be closed.  Do you want to continue?", "Image File Open", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If intAnswer = vbNo Then
                Exit Sub
            Else
                myFormLibrary.frmImage.Close()
                If myFormLibrary.frmVideoMiner.m_SerialPort Is Nothing Then
                    myFormLibrary.frmVideoMiner.lblGPSLocation.Visible = False
                    myFormLibrary.frmVideoMiner.lblX.Visible = False
                    myFormLibrary.frmVideoMiner.lblXValue.Visible = False
                    myFormLibrary.frmVideoMiner.lblY.Visible = False
                    myFormLibrary.frmVideoMiner.lblYValue.Visible = False
                    myFormLibrary.frmVideoMiner.lblZ.Visible = False
                    myFormLibrary.frmVideoMiner.lblZValue.Visible = False
                End If
            End If
        End If

        If openFile() Then
            video_file_open = True
            playVideo()
        End If

        'If video_file_open Then
        ' myFormLibrary.frmSetTime = New frmSetTime
        ' myFormLibrary.frmSetTime.TopLevel = True
        ' myFormLibrary.frmSetTime.BringToFront()
        ' myFormLibrary.frmSetTime.ShowDialog()
        ' End If

    End Sub

    ' ==========================================================================================================
    ' Name: mnuOpenSession_Click
    ' Description: When user selects "Open Session" from the file menu, call sub openSession() and open a dialogue
    '  where the user can restore a previous session that was being run in the program via a VideoMiner Session file
    '  (*.vps). This restores the last video that was being played.
    ' ==========================================================================================================
    Private Sub mnuOpenSession_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOpenSession.Click
        openSession()
        Me.mnuSaveSession.Enabled = True
    End Sub

    ' ==========================================================================================================
    ' Name: mnuSaveSession_Click
    ' Description: call sub saveSession() when the user selects Save Session from the file menu, and open a dialogue  
    ' where the user can save the current VideoMiner Session file (*.vps). This saves which video is currently being played.
    ' ==========================================================================================================
    Private Sub mnuSaveSession_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSaveSession.Click
        saveSession()
    End Sub

    ' ==========================================================================================================
    ' Name: mnuSaveSessionAs_Click
    ' Description: call sub saveSessionAs() and open a dialogue where the user can save the current state
    ' that is being run in the program as a new VideoMiner Session file (*.vps). This saves which video is currently being played.
    ' ==========================================================================================================
    Private Sub mnuSaveSessionAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSaveSessionAs.Click
        saveSessionAs()
        Me.mnuSaveSession.Enabled = True
    End Sub

    ' ==========================================================================================================
    ' Name: mnuPlay_Click
    ' Description: call sub playVideo() when the user selects "Play" from the video menu.
    ' ==========================================================================================================
    Private Sub mnuPlay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPlay.Click
        playVideo()

    End Sub

    ' ==========================================================================================================
    ' Name: mnuPause_Click
    ' Description: call sub pauseVideo() when the user selects "Pause" from the video menu.
    ' ==========================================================================================================
    Private Sub mnuPause_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPause.Click
        pauseVideo()

    End Sub

    ' ==========================================================================================================
    ' Name: mnuStop_Click
    ' Description: call sub stopStream() when the user selects "Stop" from the video menu.
    ' ==========================================================================================================
    Private Sub mnuStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuStop.Click
        stopVideo()

    End Sub

    ' ==========================================================================================================
    ' Name: mnuAbout_Click()
    ' Description: When a user selects about from the menu bar, display the message:
    '               "VideoMiner 1.0 © Chris Grandin 2008"       
    ' ==========================================================================================================
    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        'MsgBox(ABOUT_STAMP)
    End Sub

    '==========================================================================================================================
    ' Name: mnuOpenDatabase_Click
    ' Description: When the user clicks "Open Database" in the file menu, open a dialogue where a database can be selected
    ' and opened for use in the program.
    ' 1.) Load OpenFileDialog object to prompt user to select a database to open.
    ' 2.) When the user clicks OK, call sub openDatabase and send it the path of the database to open.
    '==========================================================================================================================

    Private Sub mnuOpenDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenDatabase.Click
        blOpenDatabase = True
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.Title = OPEN_DB_TITLE
        ofd.InitialDirectory = current_directory
        ofd.Filter = DB_FILE_FILTER
        ofd.FilterIndex = 2
        ofd.RestoreDirectory = True
        ofd.Multiselect = False

        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            current_directory = ofd.FileName.Substring(0, ofd.FileName.LastIndexOf("\"))
            strDatabaseFilePath = ofd.FileName
            openDatabase(ofd.FileName) ' ofd.FileName returns full path filename
            If Not conn Is Nothing Then
                files_loaded()
            End If
        End If
        blOpenDatabase = False
    End Sub
    ' ==========================================================================================================
    ' Name: CloseDatabase_Click
    ' Description: When the user selects close database from the file menu, close the currently open database.
    ' ==========================================================================================================
    Public Sub CloseDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCloseDatabase.Click
        blCloseDatabase = True
        conn.Close()
        conn = Nothing
        data_cmd = Nothing
        data_adapter = Nothing
        grdVideoMinerDatabase.DataSource = Nothing
        db_file_open = False
        db_file_unload()
        no_files_loaded()
        Me.cmdDefineAllSpatialVariables.Visible = False
        Me.cmdDefineAllTransectVariables.Visible = False
        Me.cmdAddComment.Visible = False
        Me.lblDisplayRecords.Visible = False
        Me.txtDisplayRecords.Visible = False
        Me.cmdRefreshDatabase.Visible = False
        Me.cmdDeleteLastRecord.Visible = False

        cmdShowSetTimecode.Enabled = False
        cmdTransectStart.Enabled = False
        cmdTransectEnd.Enabled = False
        cmdOffBottom.Enabled = False
        'ResumeVideo.Enabled = True
        Me.radQuickEntry.Visible = False
        Me.radDetailedEntry.Visible = False
        Me.radDetailedEntry.Checked = True
        Me.radAbundanceEntry.Visible = False
        Me.cmdEdit.Visible = False
        Me.cmdRareSpeciesLookup.Visible = False
        'Me.lblQuickSpeciesCount.Visible = False
        'Me.txtQuickSpeciesCount.Visible = False

        Me.txtPlaySeconds.Enabled = False
        Me.txtTransectDate.Enabled = False
        Me.txtProjectName.Enabled = False
        Me.chkRecordEachSecond.Enabled = False
        Me.chkRepeatVariables.Visible = False
        Me.mnuConfigureTools.Enabled = False
        Me.mnuRefreshForm.Enabled = False
        Me.KeyboardShortcutsToolStripMenuItem.Enabled = False
        Me.DataCodeAssignmentsToolStripMenuItem.Enabled = False

        dictHabitatFieldValues = Nothing
        dictTempHabitatFieldValues = Nothing
        dictTransectFieldValues = Nothing
        blCloseDatabase = False
    End Sub

    ' ==========================================================================================================
    ' Name: mnuRefreshForm_Click
    ' Description: When the user selects "Refresh Data" from the file menu, Refresh the database so that any changes
    ' that have been made to the database will be shown/available within the program.
    ' 1.) Close the database by calling CloseDatabase_Click()
    ' 2.) Open the database by calling openDatabase()
    ' ==========================================================================================================
    Private Sub mnuRefreshForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefreshForm.Click
        myFormLibrary.frmVideoMiner.blupdateColumns = False
        Call RefreshDatabase(sender, e)
        myFormLibrary.frmVideoMiner.blupdateColumns = False
    End Sub

    ' ==========================================================================================================
    ' Name: mnuOpenDV_Click
    ' Description: When a user selects "Open a DV Device" from the file menu, call the openDV() function to
    '              see a dialogue where the user can open a DV file.
    ' ==========================================================================================================
    Private Sub mnuOpenDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openDV()
    End Sub

    Private Sub GPSSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGPSSettings.Click
        If myFormLibrary.frmGpsSettings Is Nothing Then
            myFormLibrary.frmGpsSettings = New frmGpsSettings

        End If

        myFormLibrary.frmGpsSettings.ShowDialog()
    End Sub

    Private Sub mnuUseExternalVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUseExternalVideo.Click


        'MsgBox(Me.UseExternalVideoToolStripMenuItem.Checked)
        booUseExternalVideo = Me.mnuUseExternalVideo.Checked
        If booUseExternalVideo Then
            Me.mnuPlay.Enabled = False
            Me.mnuStop.Enabled = False
            Me.mnuPause.Enabled = False
            Me.mnuOpenFile.Enabled = False

            'booUseGPSTimeCodes = True
            'Me.mnuUseGPSTimeCodes.Checked = True
            'Me.mnuUseGPSTimeCodes.Enabled = False

            If Not myFormLibrary.frmVideoPlayer Is Nothing Then
                myFormLibrary.frmVideoPlayer.Close()
            End If

            Me.FileName = "External Video"

            myFormLibrary.frmSetTime = New frmSetTime
            myFormLibrary.frmSetTime.cmdContinueFromLastClip.Enabled = False
            myFormLibrary.frmSetTime.cmdUseElapsedTime.Enabled = False
            myFormLibrary.frmSetTime.cmdNext.Enabled = False
            myFormLibrary.frmSetTime.cmdPlayPause.Enabled = False
            myFormLibrary.frmSetTime.cmdPrevious.Enabled = False
            myFormLibrary.frmSetTime.cmdStop.Enabled = False

            myFormLibrary.frmSetTime.TopLevel = True
            myFormLibrary.frmSetTime.BringToFront()
            myFormLibrary.frmSetTime.ShowDialog()
        Else

            'Me.mnuPlay.Enabled = True
            'Me.mnuStop.Enabled = True
            'Me.mnuPause.Enabled = True
            Me.mnuOpenFile.Enabled = True

            booUseGPSTimeCodes = False
            Me.mnuUseGPSTimeCodes.Checked = False
            'Me.mnuUseGPSTimeCodes.Enabled = True

        End If
    End Sub
    Public Sub CloseSerialPort()
        Try
            myFormLibrary.frmVideoMiner.m_SerialPort.Close()
            If Not Me.m_SerialPort.IsOpen Then     ' If the port is closed then reset the GPS elements
                Me.tryCount = 0
                Me.lblGPSConnectionValue.Text = "NO GPS FIX"
                Me.lblGPSConnectionValue.ForeColor = Color.Red
                Me.lblGPSPortValue.Text = "CLOSED"
                Me.lblGPSPortValue.ForeColor = Color.Red
                Me.txtNMEA.Text = ""
                Me.lblXValue.Text = ""
                Me.lblYValue.Text = ""
                Me.lblZValue.Text = ""
                Me.txtTime.ForeColor = Color.Red
                Me.txtTimeSource.ForeColor = Color.Red
                Me.txtDateSource.ForeColor = Color.Red
                booUseGPSTimeCodes = False
                Me.mnuUseGPSTimeCodes.Checked = False
                Me.lblGPSConnection.Visible = False
                Me.lblGPSConnectionValue.Visible = False
                Me.lblGPSPort.Visible = False
                Me.lblGPSPortValue.Visible = False
                Me.lblGPSLocation.Visible = False
                Me.lblX.Visible = False
                Me.lblXValue.Visible = False
                Me.lblY.Visible = False
                Me.lblYValue.Visible = False
                Me.lblZ.Visible = False
                Me.lblZValue.Visible = False
            End If
            myFormLibrary.frmVideoMiner.m_SerialPort = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub mnuUseGPSTimeCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUseGPSTimeCodes.Click
        If Me.mnuUseGPSTimeCodes.Checked Then
            Me.lblGPSConnection.Visible = True
            Me.lblGPSConnectionValue.Visible = True
            Me.lblGPSPort.Visible = True
            Me.lblGPSPortValue.Visible = True
            Me.lblGPSLocation.Visible = True
            Me.lblGPSLocation.Text = "GPS Location"
            Me.lblX.Visible = True
            Me.lblXValue.Visible = True
            Me.lblY.Visible = True
            Me.lblYValue.Visible = True
            Me.lblZ.Visible = True
            Me.lblZValue.Visible = True
            If myFormLibrary.frmGpsSettings Is Nothing Then
                myFormLibrary.frmGpsSettings = New frmGpsSettings
            End If
            myFormLibrary.frmGpsSettings.TopMost = True
            myFormLibrary.frmGpsSettings.BringToFront()
            myFormLibrary.frmGpsSettings.ShowDialog()
            If Not Me.m_SerialPort Is Nothing Then
                If Not Me.m_SerialPort.IsOpen Then
                    booUseGPSTimeCodes = False
                    Me.mnuUseGPSTimeCodes.Checked = False
                    Me.mnuUseGPSTimeCodes.Checked = False
                    Me.lblGPSConnection.Visible = False
                    Me.lblGPSConnectionValue.Visible = False
                    Me.lblGPSPort.Visible = False
                    Me.lblGPSPortValue.Visible = False
                    Me.lblGPSLocation.Visible = False
                    Me.lblX.Visible = False
                    Me.lblXValue.Visible = False
                    Me.lblY.Visible = False
                    Me.lblYValue.Visible = False
                    Me.lblZ.Visible = False
                    Me.lblZValue.Visible = False
                    Exit Sub
                End If
                booUseGPSTimeCodes = True

            Else
                booUseGPSTimeCodes = False
                Me.mnuUseGPSTimeCodes.Checked = False
                Me.lblGPSConnection.Visible = False
                Me.lblGPSConnectionValue.Visible = False
                Me.lblGPSPort.Visible = False
                Me.lblGPSPortValue.Visible = False
                Me.lblGPSLocation.Visible = False
                Me.lblX.Visible = False
                Me.lblXValue.Visible = False
                Me.lblY.Visible = False
                Me.lblYValue.Visible = False
                Me.lblZ.Visible = False
                Me.lblZValue.Visible = False
            End If
        Else
            If Me.m_SerialPort.IsOpen Then
                Dim closePort As Thread
                closePort = New Thread(New ThreadStart(AddressOf CloseSerialPort))
                closePort.Start()
            End If
            If myFormLibrary.frmVideoMiner.tmrGPSExpiry.Enabled Then
                myFormLibrary.frmVideoMiner.tmrGPSExpiry.Stop()
            End If
            If Not myFormLibrary.frmGpsSettings Is Nothing Then
                myFormLibrary.frmGpsSettings.Close()
            End If
            'myFormLibrary.frmVideoMiner.m_SerialPort.Close()                ' Close the port
            'If myFormLibrary.frmGpsSettings.tmrGPSTimeout.Enabled Then
            '    myFormLibrary.frmGpsSettings.tmrGPSTimeout.Stop()
            'End If

        End If

    End Sub

    Private Sub cmdShowSetTimecode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowSetTimecode.Click
        '================================================================================================================================
        ' Name: vidShowSetTimecode_Click
        ' Description: This event is called when the user clicks on the "Set Time" button.
        '              1) Pause Video
        '              2) Store time code for Video Control
        '              2) Ask user to input time that is shown on the video. This synchronizes the program with the video.
        '              3) Ensure that the time entered is in the correct format.
        '================================================================================================================================

        If myFormLibrary.frmVideoPlayer Is Nothing Then
            MessageBox.Show("Please open a video file before setting the time.", "Video File Not Open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ' Pause Video
        pauseVideo()

        ' Get the time code from the video control
        Dim strTimeCode As String = getTimeCode()
        Dim arrTimeCode() As String = strTimeCode.Split(":")

        myFormLibrary.frmSetTime = New frmSetTime
        myFormLibrary.frmSetTime.TopLevel = True
        myFormLibrary.frmSetTime.BringToFront()
        myFormLibrary.frmSetTime.ShowDialog()

        ' Take the user entered time and create a datetime object from it
        'dtUserTime = New DateTime(Now().Year, Now().Month, Now().Day, CType(strUserTime.Substring(0, 2), Integer), CType(strUserTime.Substring(2, 2), Integer), CType(strUserTime.Substring(4, 2), Integer))

        'Get the number of seconds from the dtTimeCode
        'Dim ts As TimeSpan = CDate(CDate(DateTime.Today & " " & strTimeCode)).Subtract(CDate(DateTime.Today))
        'Dim dblSeconds As Double = ((ts.Hours * 60) + ts.Minutes) * 60 + ts.Seconds

        'Dim dtPointTime As New DateTime
        'dtPointTime = dtUserTime.AddSeconds(strTimeCode)

        'dtUserTime = dtPointTime

    End Sub

    Private Sub TransectStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransectStart.Click
        ' ==========================================================================================================
        ' Name: TransectStart_Click()
        ' Description: This event is called when the user clicks on the "Transect Start" button.
        ' 1.) Pause Video
        ' 2.) Retrieve Time Code From Video Controler
        ' 3.) Prompt user to enter a name for the new transect.
        ' 4.) call transect_started() which will: prompt user for transect name, disable/enable buttons, insert new record
        '     into the data table, load/refresh the the DataGridView1 database table view
        ' 5.) Play Video.
        ' ==========================================================================================================

        Dim tc As String
        pauseVideo()

        Dim strX As String = "NULL"
        Dim strY As String = "NULL"
        Dim strZ As String = "NULL"
        Dim blAquiredFix As Boolean = False
        'If they are using the video control then get the time from there.
        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL

        If Not booUseGPSTimeCodes Then
            tc = getTimeCode()
            If video_file_open Then
                strVideoTime = GetVideoTime(tc, strVideoDecimalTime)
            End If
        Else
            'Otherwise get the time from the NMEA string.
            blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If
        strVideoTextTime = strVideoTime
        ' The GPRMC NMEA String does not contain elevation values. Enter null into database
        ' if GPRMC is the chosen string type.
        'Dim regKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\VideoMiner")
        'Dim strGPSStringType As String = regKey.GetValue("GPSStringType")

        transect_name = InputBox("Enter a name for this transect if you wish.", "Transect Name?")
        If transect_name = NULL_STRING Then
            transect_name = UNNAMED_TRANSECT
        End If
        If strVideoTime = "" Then
            MessageBox.Show("Could not read the NMEA string. Please ensure that the GPS port is open.", "GPS Port", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        transect_started(strVideoTime, strVideoTextTime, strVideoDecimalTime, strX, strY, strZ)
    End Sub

    Private Sub TransectEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransectEnd.Click
        ' ==========================================================================================================
        ' Name: TransectEnd_Click()
        ' Description: This event is called when the user clicks on the "Transect End" button.
        ' 1.) Pause Video
        ' 2.) Retrieve Time Code From Video Controler
        ' 3.) Call transect_stopped() which will change text on main form, add record to database table, and refresh DataGridView1
        ' 4.) Play Video
        ' ==========================================================================================================

        Dim tc As String
        pauseVideo()

        Dim strX As String = "NULL"
        Dim strY As String = "NULL"
        Dim strZ As String = "NULL"
        Dim blAquiredFix As Boolean = False

        ' The GPRMC NMEA String does not contain elevation values. Enter null into database
        ' if GPRMC is the chosen string type.
        'Dim regKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\VideoMiner")
        'Dim strGPSStringType As String = regKey.GetValue("GPSStringType")

        'If they are using the video control then get the time from there.
        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
        If Not booUseGPSTimeCodes Then
            tc = getTimeCode()
            If video_file_open Then
                strVideoTime = GetVideoTime(tc, strVideoDecimalTime)
            End If
        Else
            'Otherwise get the time from the NMEA string.
            blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If
        strVideoTextTime = strVideoTime
        If strVideoTime = "" Then
            MessageBox.Show("Could not read the NMEA string. Please ensure that the GPS port is open.", "GPS Port", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If


        transect_stopped(strVideoTime, strVideoTextTime, strVideoDecimalTime, strX, strY, strZ)

    End Sub

    Private Sub OffBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOffBottom.Click
        ' ==========================================================================================================
        ' Name: OffBottom_Click
        ' Description: This event is called when the user clicks on the "Off Bottom" button.
        ' 1.) Pause Video
        ' 2.) Retrieve Time Code From Video Controler
        ' 3.) Call toggle_bottom() which 
        '           - Toggles button OffBottom and text box OnOffBottomTextbox between reading "On Bottom" and "Off Bottom"
        '           - If time code is not null, a record is added to the database table with variables for the fields:
        '           - id,TimeCode,DataCode,transect,OnBottom
        ' 4.) Play Video
        ' ==========================================================================================================

        Dim tc As String
        Dim strX As String = "NULL"
        Dim strY As String = "NULL"
        Dim strZ As String = "NULL"
        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
        Dim blAquiredFix As Boolean = False
        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.

            ' The GPRMC NMEA String does not contain elevation values. Enter null into database
            ' if GPRMC is the chosen string type.
            blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If

        If video_file_open And Not booUseGPSTimeCodes Then
            If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.IsPlaying Then
                blVideoWasPlaying = True
            Else
                blVideoWasPlaying = False
            End If
            pauseVideo()
            tc = getTimeCode()
            strVideoTime = GetVideoTime(tc, strVideoDecimalTime)

        End If
        strVideoTextTime = strVideoTime


        toggle_bottom(strVideoTime, strVideoTextTime, strVideoDecimalTime, strX, strY, strZ)

        If blVideoWasPlaying = True Then
            playVideo()
            blVideoWasPlaying = False
        End If


    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        myFormLibrary.frmSpeciesList = New frmSpeciesList
        myFormLibrary.frmSpeciesList.ShowDialog()
        pnlSpeciesData.Controls.Clear()
        fillSpeciesVariableButtonPanel()
    End Sub

    ' ==========================================================================================================
    ' ======================================Code by Xida Chen (begin)===========================================
    ' Name: mnuCapScr_Click
    ' Description: Capture the screen, as well as writing a transection to the database.
    '               The value of all the field in the transection are set to be 0.
    '               This function is called when the user selects "Video-->Capture Screen"
    ' ==========================================================================================================
    Public Sub mnuCapScr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapScr.Click
        ' Make sure that the video is open, otherwise pop up a window
        ' to tell user that no video is open.
        If video_file_open = False Then
            MsgBox("Must open video first.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
        Dim tc As String = VIDEO_TIME_LABEL
        Dim strX As String = "NULL"
        Dim strY As String = "NULL"
        Dim strZ As String = "NULL"
        Dim blAquiredFix As Boolean = False

        ' Get the video time
        pauseVideo()
        tc = getTimeCode()
        strVideoTime = GetVideoTime(tc, strVideoDecimalTime)
        strVideoTextTime = strVideoTime
        Dim strVideoTimeNoColon As String
        strVideoTimeNoColon = Replace(strVideoTime, ":", "")

        ' First, call the function in the dvTapeController to capture the screen
        ' We assume that the capture screen function is only used for video, not 
        ' for still images.

        Dim blank As String = ""

        ' Set the default name to display in screen capture save as dialog
        Dim strDefaultName As String = ""
        'Dim dtTransectDate As Date = (Me.txtTransectDate.Text)
        'Dim strTransectDate As String = dtTransectDate.Year & AddZeros(dtTransectDate.Month, 2) & AddZeros(dtTransectDate.Day, 2)
        Dim strTextBoxTransectDate As String = Me.txtTransectDate.Text
        Dim strTransectDate As String = Mid(strTextBoxTransectDate, 7, 4) & Mid(strTextBoxTransectDate, 4, 2) & Mid(strTextBoxTransectDate, 1, 2)
        Dim strTransectTime As String = ""
        If booUseGPSTimeCodes Then
            blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            strVideoTextTime = strVideoTime
            If Not blAquiredFix Then
                Exit Sub
            End If
            strTransectTime = Replace(tc, ":", "")

        Else
            strTransectTime = strVideoTimeNoColon
        End If
        Dim strTodaysDate As String = Now.Year & AddZeros(Now.Month, 2) & AddZeros(Now.Day, 2)
        Dim strTodaysTime As String = AddZeros(Now.Hour, 2) & AddZeros(Now.Minute, 2) & AddZeros(Now.Second, 2)

        If mnuNameOption_1.Checked Then
            strDefaultName = "Capture_" & Me.txtProjectName.Text & "_" & strTransectDate & "_" & strTransectTime
        ElseIf mnuNameOption_2.Checked Then
            strDefaultName = "Capture_" & Me.txtProjectName.Text & "_" & strTodaysDate & "_" & strTodaysTime
        ElseIf mnuNameOption_3.Checked Then
            strDefaultName = "Capture_" & strTransectDate & "_" & strTransectTime
        ElseIf mnuNameOption_4.Checked Then
            strDefaultName = "Capture_" & strTodaysDate & "_" & strTodaysTime
        ElseIf mnuNameOption_5.Checked Then
            strDefaultName = Me.txtProjectName.Text & "_" & strTransectDate & "_" & strTransectTime
        ElseIf mnuNameOption_6.Checked Then
            strDefaultName = Me.txtProjectName.Text & "_" & strTodaysDate & "_" & strTodaysTime
        ElseIf mnuNameOption_7.Checked Then
            strDefaultName = strTransectDate & "_" & strTransectTime
        ElseIf mnuNameOption_8.Checked Then
            strDefaultName = strTodaysDate & "_" & strTodaysTime
        ElseIf MnuNameOption_9.Checked Then
            strDefaultName = ""
        End If

        ' Specify the name to be displayed in the save window dialog
        Me.svDlgFileDialogScrCap.FileName = strDefaultName
        ' Open a save as dialog to specify the path and name for the bitmap.
        If Me.svDlgFileDialogScrCap.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim strFileName As String
        strFileName = Me.svDlgFileDialogScrCap.FileName.ToString()
        If svDlgFileDialogScrCap.FilterIndex = 2 Then
            strFileName = strFileName.Replace("Jpeg", "bmp")
        End If
        Try
            SendKeys.Send("^{PRTSC}")
            Application.DoEvents()
            Dim screen = Clipboard.GetDataObject
            Dim bmp As Bitmap = CType(screen.getdata(GetType(System.Drawing.Bitmap)), Bitmap)
            bmp.SetResolution(400, 400)
            'bmp.Save(strFileName)

            Dim p As System.Drawing.Point = New System.Drawing.Point(0, 0)
            Dim screenPosition As System.Drawing.Point = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.PointToScreen(p)


            Dim rect As New Rectangle(screenPosition.X, screenPosition.Y, myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Width, myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Height)
            Dim cropped As Bitmap = bmp.Clone(rect, bmp.PixelFormat)
            cropped.SetResolution(400, 400)
            cropped.Save(strFileName, Imaging.ImageFormat.Jpeg)
            Clipboard.Clear()
            cropped = Nothing
        Catch ex As System.OutOfMemoryException
            SendKeys.Send("^{PRTSC}")
            Application.DoEvents()
            Dim screen = Clipboard.GetDataObject
            Dim bmp As Bitmap = CType(screen.getdata(GetType(System.Drawing.Bitmap)), Bitmap)
            bmp.SetResolution(400, 400)
            'bmp.Save(strFileName)

            Dim p As System.Drawing.Point = New System.Drawing.Point(0, 0)
            Dim screenPosition As System.Drawing.Point = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.PointToScreen(p)


            Dim rect As New Rectangle(screenPosition.X, screenPosition.Y, myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Width, myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Height)
            Dim cropped As Bitmap = bmp.Clone(rect, bmp.PixelFormat)
            cropped.SetResolution(400, 400)
            cropped.Save(strFileName, Imaging.ImageFormat.Jpeg)
            Clipboard.Clear()
            cropped = Nothing
        End Try
        'Dim CropRect As New Rectangle(screenPosition.X, screenPosition.Y, myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Width, myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Height)
        'Dim CropImage As Bitmap = New Bitmap(CropRect.Width, CropRect.Height)
        'Using grp = Graphics.FromImage(CropImage)
        '    grp.drawimage(bmp, New Rectangle(0, 0, CropRect.Width, CropRect.Height))
        '    CropImage.Save(strFileName)
        'End Using



        '' Create a graphics object for the live video stream and set the bitmap to be the dimensions of the picture box
        'Dim GR As Graphics = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.CreateGraphics
        'Dim bmpCapture As New Bitmap(myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Width, myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Height)
        'Dim pbhdc As IntPtr = GR.GetHdc     ' Set up a handle to the graphics object
        'Dim bmpGraphics As Graphics = Graphics.FromImage(bmpCapture)
        'Dim bmpHdc As IntPtr = bmpGraphics.GetHdc


        '' Use the library to get a screen capture of the picture box area
        'BitBlt(bmpHdc, 0, 0, myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Width, myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Height, pbhdc, 0, 0, COPY)
        'GR.ReleaseHdc(pbhdc)
        'bmpGraphics.ReleaseHdc(bmpHdc)

        'bmpCapture.Save(strFileName)

        Try
            'If the user selected *.Jpeg, convert the bmp.
            If svDlgFileDialogScrCap.FilterIndex = 2 Then
                'Save bmp as jpg 'ConvertBMP(strFileName, ImageFormat.Jpeg)        'ConvertBMP(strFileName, ImageFormat.Emf)        'ConvertBMP(strFileName, ImageFormat.Exif)        'ConvertBMP(strFileName, ImageFormat.Gif)        'ConvertBMP(strFileName, ImageFormat.Icon)        'ConvertBMP(strFileName, ImageFormat.MemoryBmp)        'ConvertBMP(strFileName, ImageFormat.Png)        'ConvertBMP(strFileName, ImageFormat.Tiff)        'ConvertBMP(strFileName, ImageFormat.Wmf)        
                ConvertBMP(strFileName, ImageFormat.Jpeg)
                'If System.IO.File.Exists(strFileName) = True Then
                '    System.IO.File.Delete(strFileName)
                'End If

            End If
        Catch ex As Exception
            MsgBox("The file extension you created is invalid, please try again.")
            Exit Sub
        End Try


        Dim strDate() As String
        Dim strDateTime As String
        strDate = transect_date.Split("/")
        strDateTime = strDate(2) & ":" & strDate(1) & ":" & strDate(0)
        strDateTime = strDateTime & " " & Me.txtTime.Text
        Dim arguments As String
        Dim exePathStr As String = System.Windows.Forms.Application.ExecutablePath.ToString()
        Dim command As String = String.Concat("""", exePathStr.Substring(0, exePathStr.LastIndexOf("\") + 1), "exiftool.exe")
        arguments = String.Concat("""", " -FileModifyDate=", DoubleQuote(strDateTime) & " ", """", strFileName, """")
        Console.WriteLine(command & arguments)
        'MsgBox(command & arguments)
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(command & arguments)
        'oStartInfo.Arguments = arguments
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oStartInfo
        oProcess.StartInfo.CreateNoWindow = True
        oProcess.Start()
        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
        End Using
        Console.WriteLine(sOutput)
        Dim strFileNamePath As String
        strFileNamePath = Path.GetFileName(strFileName)
        Me.FileName = Mid(Me.FileName, 1, 50)
        Me.ScreenCaptureName = strFileNamePath
        If Not myFormLibrary.frmSpeciesEvent Is Nothing Then
            myFormLibrary.frmSpeciesEvent.cmdScreenCapture.BackColor = Color.LimeGreen
        End If
        If Not myFormLibrary.frmTableView Is Nothing Then
            myFormLibrary.frmTableView.cmdScreenCapture.BackColor = Color.LimeGreen
        End If
        If blScreenCaptureCalled = False Then
            ' Next, write a transection to the database
            Dim numrows As Integer
            Dim query As String
            Dim oComm As OleDbCommand


            strSpeciesCode = "NULL"
            strSpeciesCount = "NULL"
            strSide = "NULL"
            strRange = "NULL"
            strLength = "NULL"
            strHeight = "NULL"
            strWidth = "NULL"
            strAbundance = "NULL"
            strIdConfidence = "NULL"
            strComment = "Screen Capture"

            query = createInsertQuery(transect_date, "Screen Capture", strVideoTime, strVideoTextTime, strVideoDecimalTime, "555", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)
            Me.ScreenCaptureName = ""

            ' Write this transaction to the database if open.
            Try
                oComm = New OleDbCommand(query, conn)
                numrows = oComm.ExecuteNonQuery()
                fetch_data()
            Catch ex As Exception
                If ex.Message.StartsWith("Syntax") Then
                    MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
                Else
                    MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                End If
                Exit Sub
            End Try
        End If

    End Sub
    Private Sub VaryQualityLevel(ByVal strFilePath As String)
        ' Get a bitmap. 
        Dim bmp1 As New Bitmap(strFilePath)
        Dim jgpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)

        ' Create an Encoder object based on the GUID 
        ' for the Quality parameter category. 
        Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

        ' Create an EncoderParameters object. 
        ' An EncoderParameters object has an array of EncoderParameter 
        ' objects. In this case, there is only one 
        ' EncoderParameter object in the array. 
        Dim myEncoderParameters As New EncoderParameters(1)

        Dim myEncoderParameter As New EncoderParameter(myEncoder, 100&)
        myEncoderParameters.Param(0) = myEncoderParameter
        bmp1.Save(strFilePath, jgpEncoder, myEncoderParameters)

    End Sub 'VaryQualityLevel

    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo

        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing

    End Function
    ' ==========================================================================================================
    ' Name: mnuOpenImg_Click
    ' Description: Select the image file for processing, extracting EXIF info as well, also get all the images under
    '              selected directory.
    '              This function is called when the user selects "File->Open Image File"
    ' ==========================================================================================================
    Private Sub mnuOpenImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenImg.Click

        If Not myFormLibrary.frmVideoPlayer Is Nothing Then

            Dim intAnswer As Integer

            intAnswer = MessageBox.Show("The video file '" & Me.FileName & "' is currently open.  In order to open an image, the video will be closed.  Do you want to continue?", "Video File Open", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If intAnswer = vbNo Then
                Exit Sub
            Else
                myFormLibrary.frmVideoPlayer.Close()
            End If

        End If

        If Me.tmrComputerTime.Enabled Then
            Me.tmrComputerTime.Stop()
        End If
        Dim strFileName As String

        ' Set the default folder for the pop up dialog
        ' which requires the user to select an image.
        ' The image format could be .bmp, .jpg, .gif or .png
        fldlgOpenFD.InitialDirectory = CurDir()
        fldlgOpenFD.Title = "Open an Image File"
        fldlgOpenFD.Filter = "Image Files(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
        Dim DidWork As Integer = fldlgOpenFD.ShowDialog()

        ' If user selects an image
        If DidWork <> Windows.Forms.DialogResult.Cancel Then
            ' Get the name of the file selected and show this file
            ' in the window frmImage.
            strFileName = fldlgOpenFD.FileName
            If myFormLibrary.frmImage Is Nothing Then
                myFormLibrary.frmImage = New frmImage


                Dim intX As Integer = 0
                Dim intY As Integer = 0

                Dim intMonitorCount As Integer = 0
                Dim mon As Screen
                Dim secMon As Screen
                Dim priMon As Screen

                For Each mon In Screen.AllScreens
                    If Not mon.Primary Then
                        secMon = mon
                    Else
                        priMon = mon
                    End If
                    intMonitorCount += 1
                Next

                Dim aPoint As System.Drawing.Point

                If intMonitorCount = 1 Then
                    aPoint.X = intX
                    aPoint.Y = intY / 2
                    myFormLibrary.frmImage.Location = aPoint
                    myFormLibrary.frmImage.WindowState = FormWindowState.Normal
                Else
                    aPoint.X = intX + priMon.Bounds.Width
                    aPoint.Y = intY / 2
                    myFormLibrary.frmImage.Location = aPoint
                    myFormLibrary.frmImage.WindowState = FormWindowState.Maximized
                End If

                myFormLibrary.frmImage.Show()
            End If
            currentImage = strFileName
            'myFormLibrary.frmImage.PictureBox1.Image = Image.FromFile(strFileName)
            'myFormLibrary.frmImage.Text = strFileName.Substring(strFileName.LastIndexOf("\") + 1, (strFileName.Length - strFileName.LastIndexOf("\") - 1))
            Me.FileName = strFileName.Substring(strFileName.LastIndexOf("\") + 1, (strFileName.Length - strFileName.LastIndexOf("\") - 1))

            ' set the flag "image_open" to be true.
            image_open = True
            ' Store the path of the current folder so that we can read 
            ' all the images under the current directory
            imagePath = strFileName.Substring(0, strFileName.LastIndexOf("\") + 1)
            Dim allFiles As String() = Directory.GetFiles(imagePath)
            Dim cur_folder_files As String = ""
            Dim i As Integer
            Dim intIndex As Integer = 0
            Dim tempFileName As String


            Try
                imageFilesList = New List(Of String)
                Dim imageFileDirectory As IO.FileInfo() = New IO.DirectoryInfo(imagePath).GetFiles()
                For Each logFile As IO.FileInfo In imageFileDirectory
                    Dim subPostFix As String = logFile.Name.Substring(logFile.Name.Length - 4, 4)
                    If subPostFix = ".JPG" Or subPostFix = ".jpg" Or subPostFix = ".bmp" Or subPostFix = ".BMP" Or subPostFix = ".gif" Or subPostFix = ".GIF" Or subPostFix = ".png" Or subPostFix = ".PNG" Then
                        imageFilesList.Add(logFile.Name)
                    End If
                Next

                For i = 0 To imageFilesList.Count - 1
                    If imageFilesList(i) = Me.FileName Then
                        intIndex = i
                        Exit For
                    End If
                Next

                myFormLibrary.frmImage.PictureBox1.Image = New Bitmap(imagePath & imageFilesList(intIndex))
                myFormLibrary.frmImage.Text = imageFilesList(intIndex)
                image_index = intIndex
                Call getEXIFData(Me.txtTime.Text, "", Me.lblXValue.Text, Me.lblYValue.Text, Me.lblZValue.Text)
                'Me.txtTimeSource.ForeColor = Color.LimeGreen
                'Me.txtTime.ForeColor = Color.LimeGreen
                Me.txtTimeSource.Text = "EXIF"
                intTimeSource = 3
                Me.txtTimeSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
                Me.txtTimeSource.BackColor = Color.LightGray
                Me.txtTimeSource.ForeColor = Color.LimeGreen
                Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
                Me.txtTime.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
                Me.txtTime.BackColor = Color.LightGray
                Me.txtTime.ForeColor = Color.LimeGreen
                Me.txtTime.TextAlign = HorizontalAlignment.Center
                Me.txtTransectDate.Text = transect_date
                Me.txtDateSource.Text = "EXIF"
                Me.txtDateSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
                Me.txtDateSource.BackColor = Color.LightGray
                Me.txtDateSource.ForeColor = Color.LimeGreen
                Me.txtDateSource.TextAlign = HorizontalAlignment.Center
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            ' We try to store the name of all the files under this folder
            ' and then separate each file name using "|".
            'For i = 0 To allFiles.Length - 1
            '    tempFileName = allFiles(i)
            '    'MsgBox(Me.FileName & " : " & tempFileName.Substring(tempFileName.LastIndexOf("\") + 1, tempFileName.Length - 1 - tempFileName.LastIndexOf("\")))
            '    Dim subPostFix As String = tempFileName.Substring(tempFileName.Length - 4, 4)
            '    If subPostFix = ".JPG" Or subPostFix = ".jpg" Or subPostFix = ".bmp" Or subPostFix = ".BMP" _
            '      Or subPostFix = ".gif" Or subPostFix = ".GIF" Or subPostFix = ".png" Or subPostFix = ".PNG" Then
            '        cur_folder_files = String.Concat(cur_folder_files, tempFileName.Substring(tempFileName.LastIndexOf("\") + 1, tempFileName.Length - 1 - tempFileName.LastIndexOf("\")), "|")
            '        MsgBox(tempFileName.Substring(tempFileName.LastIndexOf("\") + 1, tempFileName.Length - 1 - tempFileName.LastIndexOf("\")))
            '        intIndex += 1
            '    End If

            '    If Me.FileName = tempFileName.Substring(tempFileName.LastIndexOf("\") + 1, tempFileName.Length - 1 - tempFileName.LastIndexOf("\")) Then
            '        Me.image_index = intIndex
            '    End If
            'Next i
            'MsgBox(image_index)
            'cur_folder_files = cur_folder_files.Substring(0, cur_folder_files.Length() - 1)
            '' Store the name of all image files in an array
            '' We use the letter "|" to separate each file because "|" can not
            '' be a part of a file name
            'fileNames = Split(cur_folder_files, "|")
            'image_prefix = strFileName.Substring(0, strFileName.LastIndexOf("."))







            fldlgOpenFD.Reset()

            Me.cmdPreviousImage.Enabled = True
            Me.cmdNextImage.Enabled = True
            Me.cboZoom.Enabled = True
            Me.cmdPreviousImage.Visible = True
            Me.cmdNextImage.Visible = True
            Me.cboZoom.Visible = True
            Me.lblImageSize.Visible = True
            'Me.lblVideoControls.Visible = True
            'Me.lblVideoControls.Text = "Photo Controls"


            Me.cmdNothingInPhoto.Visible = True

            intCurrentZoom = Me.cboZoom.SelectedIndex

            Call enableDisableImageMenu(True)

        End If
    End Sub

    Private Sub txtProjectName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectName.Click
        myFormLibrary.frmProjectNames = New frmProjectNames
        myFormLibrary.frmProjectNames.ShowDialog()
    End Sub
    ' ======================================Code by Xida Chen (end)===========================================

    Private Sub txtProjectName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectName.Leave
        project_name = txtProjectName.Text
    End Sub


    Private Sub txtTransectDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransectDate.Click
        Me.txtTransectDate.ForeColor = Color.Black
        Me.mnthCalendar.Visible = True
        Me.cmdCloseCalendar.Visible = True
    End Sub

    Private Sub mnthCalendar_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mnthCalendar.DateSelected
        Me.txtTransectDate.Text = AddZeros(Me.mnthCalendar.SelectionStart.Day, 2) & "/" & AddZeros(Me.mnthCalendar.SelectionStart.Month, 2) & "/" & Me.mnthCalendar.SelectionStart.Year
        transect_date = Me.txtTransectDate.Text
        Me.mnthCalendar.Visible = False
        Me.cmdCloseCalendar.Visible = False
    End Sub

    Private Sub cmdCloseCalendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseCalendar.Click
        Me.mnthCalendar.Visible = False
        Me.cmdCloseCalendar.Visible = False
    End Sub


    Private Sub cmdDefineAllSpatialVariables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefineAllSpatialVariables.Click

        Dim tc As String = VIDEO_TIME_LABEL

        Dim strX As String = "NULL"
        Dim strY As String = "NULL"
        Dim strZ As String = "NULL"

        Dim query As String = ""
        Dim strCode As String = ""
        Dim strName As String = ""
        Dim blFlag As Boolean = False
        Dim blAquiredFix As Boolean = False
        'If they are using the video control then get the time from there.
        ' The time code is set to be VIDEO_TIME_LABEL initially.
        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
        ' do the following only when the video is open:
        ' pause stream and get the time code
        ' If the video is not open, then we cannot pause the
        ' video stream, and there is no need to get the TimeCode.
        If video_file_open Then
            If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.IsPlaying Then
                blVideoWasPlaying = True
                pauseVideo()
            Else
                blVideoWasPlaying = False
            End If
            tc = getTimeCode()
            strVideoTime = GetVideoTime(tc, strVideoDecimalTime)
            strVideoTextTime = strVideoTime
        End If

        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.

            ' The GPRMC NMEA String does not contain elevation values. Enter null into database
            ' if GPRMC is the chosen string type.
            blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If
        strVideoTextTime = strVideoTime
        ' If an image is open and a video is closed, get the photo information from the EXIF file
        If image_open And video_file_open = False Then
            Call getEXIFData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            strVideoTextTime = strVideoTime
        End If

        Try

            Dim i As Integer
            For i = 0 To strHabitatButtonCodeNames.Length - 2

                If strHabitatButtonTables(i) = "UserEntered" Then
                    Dim strValue As String
                    myFormLibrary.frmAddValue = New frmAddValue(dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString))
                    myFormLibrary.frmAddValue.lblExpression.Text = "Please enter a value for " & strHabitatButtonNames(i) & ":"
                    myFormLibrary.frmAddValue.Text = strHabitatButtonNames(i) & " Entry"
                    myFormLibrary.frmAddValue.cmdCancel.Text = "Skip"
                    myFormLibrary.frmAddValue.ShowDialog()

                    strValue = myFormLibrary.frmAddValue.strValue

                    strHabitatButtonUserCodeChoice(i) = strValue
                    myFormLibrary.frmAddValue.Close()
                    myFormLibrary.frmAddValue = Nothing
                    dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = strHabitatButtonUserCodeChoice(i).ToString
                    dictTempHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = strHabitatButtonUserCodeChoice(i).ToString
                    strHabitatButtonUserNameChoice(i) = strValue
                    If strValue = "-9999" Then
                        ClearSpatial(strHabitatButtonNames(i), intNumHabitatButtons, strHabitatButtonNames, dictHabitatFieldValues, strHabitatButtonCodeNames, textboxes)
                    Else
                        Dim _fontfamily As FontFamily
                        _fontfamily = New FontFamily(Me.ButtonFont)
                        textboxes(i).Text = strHabitatButtonUserNameChoice(i)
                        textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                        textboxes(i).BackColor = Color.LightGray
                        textboxes(i).ForeColor = Color.LimeGreen
                        textboxes(i).TextAlign = HorizontalAlignment.Center
                    End If

                Else

                    Dim sub_form As frmTableView = New frmTableView(strHabitatButtonTables(i), i, intNumHabitatButtons, strHabitatButtonNames, dictHabitatFieldValues, strHabitatButtonCodeNames, textboxes)
                    sub_form.Multiple = True
                    sub_form.ShowDialog()
                    If Not sub_form.UserClosedForm Then
                        strCode = sub_form.DataGridView1.SelectedRows(0).Cells(0).Value & ""
                        strHabitatButtonUserCodeChoice(i) = strCode
                        dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = strHabitatButtonUserCodeChoice(i).ToString
                        dictTempHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = strHabitatButtonUserCodeChoice(i).ToString

                        strName = sub_form.DataGridView1.SelectedRows(0).Cells(1).Value & ""

                        If strName.Length = 0 Then
                            strName = strCode
                        End If
                        strHabitatButtonUserNameChoice(i) = strName
                        Dim _fontfamily As FontFamily
                        _fontfamily = New FontFamily(Me.ButtonFont)
                        textboxes(i).Text = strHabitatButtonUserNameChoice(i)
                        textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                        textboxes(i).BackColor = Color.LightGray
                        textboxes(i).ForeColor = Color.LimeGreen
                        textboxes(i).TextAlign = HorizontalAlignment.Center
                    End If
                End If
            Next



            strSpeciesCode = "NULL"
            strSpeciesCount = "NULL"
            strSide = "NULL"
            strRange = "NULL"
            strLength = "NULL"
            strHeight = "NULL"
            strWidth = "NULL"
            strAbundance = "NULL"
            strIdConfidence = "NULL"

            query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, "999", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)
            Me.ScreenCaptureName = ""
            'Debug.WriteLine(query)
            Dim numrows As Integer
            Dim oComm As OleDbCommand
            oComm = New OleDbCommand(query, conn)
            numrows = oComm.ExecuteNonQuery()
            fetch_data()

            If blVideoWasPlaying = True Then
                playVideo()
                blVideoWasPlaying = False
            End If

        Catch ex As Exception
            If ex.Message.StartsWith("Syntax") Then
                MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
            Else
                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End If
        End Try
    End Sub

    Private Sub cmdDefineAllTransectVariables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefineAllTransectVariables.Click
        Dim tc As String = VIDEO_TIME_LABEL

        Dim strX As String = "NULL"
        Dim strY As String = "NULL"
        Dim strZ As String = "NULL"

        Dim query As String = ""
        Dim strCode As String = ""
        Dim strName As String = ""
        Dim blFlag As Boolean = False
        Dim blAquiredFix As Boolean = False
        'If they are using the video control then get the time from there.
        ' The time code is set to be VIDEO_TIME_LABEL initially.
        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
        ' do the following only when the video is open:
        ' pause stream and get the time code
        ' If the video is not open, then we cannot pause the
        ' video stream, and there is no need to get the TimeCode.
        If video_file_open Then
            If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.IsPlaying Then
                blVideoWasPlaying = True
                pauseVideo()
            Else
                blVideoWasPlaying = False
            End If
            tc = getTimeCode()
            strVideoTime = GetVideoTime(tc, strVideoDecimalTime)

        End If

        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.

            ' The GPRMC NMEA String does not contain elevation values. Enter null into database
            ' if GPRMC is the chosen string type.
            blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If
        strVideoTextTime = strVideoTime
        ' If an image is open and a video is closed, get the photo information from the EXIF file
        If image_open And video_file_open = False Then
            Call getEXIFData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            strVideoTextTime = strVideoTime
        End If
        Try
            Dim i As Integer
            For i = 0 To strTransectButtonCodeNames.Length - 2

                If strTransectButtonTables(i) = "UserEntered" Then
                    Dim strValue As String
                    myFormLibrary.frmAddValue = New frmAddValue(dictTransectFieldValues(strTransectButtonCodeNames(i).ToString))
                    myFormLibrary.frmAddValue.lblExpression.Text = "Please enter a value for " & strTransectButtonNames(i) & ":"
                    myFormLibrary.frmAddValue.Text = strTransectButtonNames(i) & " Entry"
                    myFormLibrary.frmAddValue.cmdCancel.Text = "Skip"
                    myFormLibrary.frmAddValue.ShowDialog()

                    strValue = myFormLibrary.frmAddValue.strValue
                    myFormLibrary.frmAddValue.Close()
                    myFormLibrary.frmAddValue = Nothing
                    strTransectButtonUserCodeChoice(i) = strValue
                    dictTransectFieldValues(strTransectButtonCodeNames(i).ToString) = strTransectButtonUserCodeChoice(i).ToString
                    strTransectButtonUserNameChoice(i) = strValue
                    If strValue = "-9999" Then
                        ClearSpatial(strTransectButtonNames(i), intNumTransectButtons, strTransectButtonNames, dictTransectFieldValues, strTransectButtonCodeNames, Transect_Textboxes)
                    Else
                        Dim _fontfamily As FontFamily
                        _fontfamily = New FontFamily(Me.ButtonFont)
                        Transect_Textboxes(i).Text = strTransectButtonUserNameChoice(i)
                        Transect_Textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                        Transect_Textboxes(i).BackColor = Color.LightGray
                        Transect_Textboxes(i).ForeColor = Color.LimeGreen
                        Transect_Textboxes(i).TextAlign = HorizontalAlignment.Center
                    End If


                Else


                    Dim sub_form As frmTableView = New frmTableView(strTransectButtonTables(i), i, intNumTransectButtons, strTransectButtonNames, dictTransectFieldValues, strTransectButtonCodeNames, Transect_Textboxes)
                    sub_form.Multiple = True
                    sub_form.ShowDialog()
                    If Not sub_form.UserClosedForm Then
                        strCode = sub_form.DataGridView1.SelectedRows(0).Cells(0).Value & ""
                        strTransectButtonUserCodeChoice(i) = strCode
                        dictTransectFieldValues(strTransectButtonCodeNames(i).ToString) = strTransectButtonUserCodeChoice(i).ToString

                        strName = sub_form.DataGridView1.SelectedRows(0).Cells(1).Value & ""

                        If strName.Length = 0 Then
                            strName = strCode
                        End If
                        strTransectButtonUserNameChoice(i) = strName
                        Dim _fontfamily As FontFamily
                        _fontfamily = New FontFamily(Me.ButtonFont)
                        Transect_Textboxes(i).Text = strTransectButtonUserNameChoice(i)
                        Transect_Textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                        Transect_Textboxes(i).BackColor = Color.LightGray
                        Transect_Textboxes(i).ForeColor = Color.LimeGreen
                        Transect_Textboxes(i).TextAlign = HorizontalAlignment.Center
                    End If
                End If
            Next

            If Me.strComment <> "" Then

                strSpeciesCode = "NULL"
                strSpeciesCount = "NULL"
                strSide = "NULL"
                strRange = "NULL"
                strLength = "NULL"
                strHeight = "NULL"
                strWidth = "NULL"
                strAbundance = "NULL"
                strIdConfidence = "NULL"

                query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, intTransectButtonCodes(i), "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                'Debug.WriteLine(query)
                Dim numrows As Integer
                Dim oComm As OleDbCommand
                oComm = New OleDbCommand(query, conn)
                numrows = oComm.ExecuteNonQuery()
                fetch_data()

            End If

            Me.strComment = ""


            If blVideoWasPlaying = True Then
                playVideo()
                blVideoWasPlaying = False
            End If

        Catch ex As Exception
            If ex.Message.StartsWith("Syntax") Then
                MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
            Else
                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End If
        End Try
    End Sub
    Private Sub tmrRecordPerSecond_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRecordPerSecond.Tick
        'Insert A record into the database every second that video is played.
        ' This will include all continuous variables.

        Dim tc As String = VIDEO_TIME_LABEL
        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
        Dim strX As String = "NULL"
        Dim strY As String = "NULL"
        Dim strZ As String = "NULL"

        Dim query As String = ""
        Try
            If video_file_open Then
                'pauseVideo()
                tc = getTimeCode()
                strVideoTime = GetVideoTime(tc, strVideoDecimalTime)
                strVideoTextTime = strVideoTime

                ' Create a variable intCurrVideoSeconds to store the current video times second value.
                ' Another global vaiable stores the second value at which the last record was created
                ' Since we only want to create a record if a second has past, and the timer and thus
                ' this procedure is called every .45 seconds, intCurrVideoSeconds is compared to 
                ' the global variable to see if a second has passed. if not, exit and check again
                ' next timer tick
                ' 00:00:00

                intVideoSeconds = CInt(Mid(strVideoTime, 7, 2))

                If blFirstTime Then
                    intPreviousVideoSeconds = intVideoSeconds
                    blFirstTime = False
                End If

                If intVideoSeconds = intPreviousVideoSeconds Then
                    intVideoStopCounter += 1
                    If intVideoStopCounter = 15 Then
                        tmrRecordPerSecond.Stop()
                        intVideoStopCounter = 0
                    End If
                    Exit Sub
                Else

                    intVideoStopCounter = 0
                    intPreviousVideoSeconds = intVideoSeconds

                    strSpeciesCode = "NULL"
                    strSpeciesCount = "NULL"
                    strSide = "NULL"
                    strRange = "NULL"
                    strLength = "NULL"
                    strHeight = "NULL"
                    strWidth = "NULL"
                    strAbundance = "NULL"
                    strIdConfidence = "NULL"
                    strComment = "NULL"

                    query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, "NULL", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                    Dim numrows As Integer
                    Dim oComm As OleDbCommand
                    oComm = New OleDbCommand(query, conn)
                    numrows = oComm.ExecuteNonQuery()
                    fetch_data()

                    Exit Sub
                End If
            End If
            If booUseGPSTimeCodes Then
                'Otherwise get the time from the NMEA string. 

                ' The GPRMC NMEA String does not contain elevation values. Enter null into database
                ' if GPRMC is the chosen string type.
                Call getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)

                intGPSSeconds = CInt(Mid(tc, 7, 2))

                If blGPSFirstTime Then
                    intPreviousGPSSeconds = intGPSSeconds
                    blGPSFirstTime = False
                End If

                If intGPSSeconds = intPreviousGPSSeconds Then
                    Exit Sub
                Else
                    intPreviousGPSSeconds = intGPSSeconds

                    strSpeciesCode = "NULL"
                    strSpeciesCount = "NULL"
                    strSide = "NULL"
                    strRange = "NULL"
                    strLength = "NULL"
                    strHeight = "NULL"
                    strWidth = "NULL"
                    strAbundance = "NULL"
                    strIdConfidence = "NULL"
                    strComment = "NULL"

                    query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, "NULL", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                    Dim numrows As Integer
                    Dim oComm As OleDbCommand
                    oComm = New OleDbCommand(query, conn)
                    numrows = oComm.ExecuteNonQuery()
                    fetch_data()
                End If
            End If
        Catch ex As Exception
            If ex.Message.StartsWith("Syntax") Then
                MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
            Else
                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End If
        End Try

    End Sub

    'Private Sub tmrPlayForSeconds_Tick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrPlayForSeconds.Tick

    '    Dim dblCurrentSeconds As Double

    '    Dim strSeconds As String()

    '    If myFormLibrary.frmVideoPlayer Is Nothing Then
    '        tmrPlayForSeconds.Stop()
    '        Exit Sub
    '    End If
    '    dblCurrentSeconds = myFormLibrary.frmVideoPlayer.dblCurrentVideoTime

    '    strSeconds = dblCurrentSeconds.ToString.Split(".")
    '    intCurrentPlaySeconds = CInt(strSeconds(0))
    '    Dim strVideoTextTime As String = VIDEO_TIME_LABEL
    '    Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL 
    '    strPlaySecondsVideoTime = GetVideoTime(dblCurrentSeconds, strVideoDecimalTime)
    '    strVideoTextTime = strPlaySecondsVideoTime

    '    ' Check to see if the end play time string is equal to the current video time string
    '    ' If so the pause the video and stop the timer
    '    If intCurrentPlaySeconds = intEndPlaySeconds Then

    '        pauseVideo()
    '        Me.tmrPlayForSeconds.Stop()
    '        myFormLibrary.frmVideoPlayer.blIsPlaying = False
    '        Me.tmrPlayForSeconds.Enabled = False
    '        If Me.chkDefineAll.Checked = True Then
    '            Call Me.cmdDefineAllTransectVariables_Click(sender, e)
    '            Call Me.cmdDefineAllSpatialVariables_Click(sender, e)
    '        End If
    '    End If
    '    If Me.chkRecordEachSecond.Checked = True Then
    '        Dim query As String = ""
    '        Dim strX As String = "NULL"
    '        Dim strY As String = "NULL"
    '        Dim strZ As String = "NULL"

    '        If blFirstTime Then
    '            intPreviousVideoSeconds = intCurrentPlaySeconds
    '            blFirstTime = False
    '        End If

    '        If intCurrentPlaySeconds <> intPreviousVideoSeconds Then
    '            Try
    '                intPreviousVideoSeconds = intCurrentPlaySeconds

    '                strSpeciesCode = "NULL"
    '                strSpeciesCount = "NULL"
    '                strSide = "NULL"
    '                strRange = "NULL"
    '                strLength = "NULL"
    '                strHeight = "NULL"
    '                strWidth = "NULL"
    '                strAbundance = "NULL"
    '                strIdConfidence = "NULL"
    '                strComment = "NULL"

    '                query = createInsertQuery(transect_date, transect_name, strPlaySecondsVideoTime, strVideoTextTime, strVideoDecimalTime, "NULL", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

    '                Dim numrows As Integer
    '                Dim oComm As OleDbCommand
    '                oComm = New OleDbCommand(query, conn)
    '                numrows = oComm.ExecuteNonQuery()
    '                fetch_data()
    '            Catch ex As Exception
    '                If ex.Message.StartsWith("Syntax") Then
    '                    MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
    '                Else
    '                    MsgBox(ex.Message & vbCrLf & ex.StackTrace)
    '                End If
    '            End Try

    '        End If
    '    End If



    'End Sub

    Private Sub chkRepeatVariables_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRepeatVariables.CheckedChanged
        Dim i As Integer
        If Me.chkRepeatVariables.Checked = True Then
            ' If the user checks the repeat box, set all original variables to temporary variables
            If Not dictHabitatFieldValues Is Nothing Or Not dictTempHabitatFieldValues Is Nothing Then
                For i = 0 To intNumHabitatButtons - 1
                    dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = dictTempHabitatFieldValues(strHabitatButtonCodeNames(i).ToString)

                    ' and clear all the temporary values.
                    dictTempHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = "-9999"
                Next
            End If
        Else
            ' If the user unchecks the repeat box, save the original variables in the temporary variables
            ' so that they are still available in the event the box is checked back on.
            If Not dictHabitatFieldValues Is Nothing Or Not dictTempHabitatFieldValues Is Nothing Then
                For i = 0 To intNumHabitatButtons - 1
                    dictTempHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString)

                    ' Clear all original variables so that the values are not repeated on consecutive records.
                    dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = "-9999"
                Next
            End If
        End If

    End Sub

    Private Sub mnuNameOption_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNameOption_1.Click
        For Each item As ToolStripMenuItem In Me.mnuNameOptionRoot.DropDownItems
            item.Checked = False
        Next item
        Me.mnuNameOption_1.Checked = True
    End Sub
    Private Sub mnuNameOption_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNameOption_2.Click
        For Each item As ToolStripMenuItem In Me.mnuNameOptionRoot.DropDownItems
            item.Checked = False
        Next item
        Me.mnuNameOption_2.Checked = True
    End Sub
    Private Sub mnuNameOption_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNameOption_3.Click
        For Each item As ToolStripMenuItem In Me.mnuNameOptionRoot.DropDownItems
            item.Checked = False
        Next item
        Me.mnuNameOption_3.Checked = True
    End Sub
    Private Sub mnuNameOption_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNameOption_4.Click
        For Each item As ToolStripMenuItem In Me.mnuNameOptionRoot.DropDownItems
            item.Checked = False
        Next item
        Me.mnuNameOption_4.Checked = True
    End Sub
    Private Sub mnuNameOption_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNameOption_5.Click
        For Each item As ToolStripMenuItem In Me.mnuNameOptionRoot.DropDownItems
            item.Checked = False
        Next item
        Me.mnuNameOption_5.Checked = True
    End Sub
    Private Sub mnuNameOption_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNameOption_6.Click
        For Each item As ToolStripMenuItem In Me.mnuNameOptionRoot.DropDownItems
            item.Checked = False
        Next item
        Me.mnuNameOption_6.Checked = True
    End Sub
    Private Sub mnuNameOption_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNameOption_7.Click
        For Each item As ToolStripMenuItem In Me.mnuNameOptionRoot.DropDownItems
            item.Checked = False
        Next item
        Me.mnuNameOption_7.Checked = True
    End Sub
    Private Sub mnuNameOption_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNameOption_8.Click
        For Each item As ToolStripMenuItem In Me.mnuNameOptionRoot.DropDownItems
            item.Checked = False
        Next item
        Me.mnuNameOption_8.Checked = True
    End Sub
    Private Sub mnuNameOption_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNameOption_9.Click
        For Each item As ToolStripMenuItem In Me.mnuNameOptionRoot.DropDownItems
            item.Checked = False
        Next item
        Me.MnuNameOption_9.Checked = True
    End Sub

    Private Sub chkRecordEachSecond_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecordEachSecond.CheckedChanged
        If Me.chkRecordEachSecond.Checked = False Then
            Me.tmrRecordPerSecond.Stop()
        Else
            Dim tc As String = VIDEO_TIME_LABEL
            Dim strVideoTime As String = VIDEO_TIME_LABEL
            Dim strVideoTextTime As String = VIDEO_TIME_LABEL
            Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
            Dim strX As String = ""
            Dim strY As String = ""
            Dim strZ As String = ""

            If Not myFormLibrary.frmVideoPlayer Is Nothing Then
                'If myFormLibrary.frmVideoPlayer.blIsPlaying Then

                tc = getTimeCode()
                strVideoTime = GetVideoTime(tc, strVideoDecimalTime)
                strVideoTextTime = strVideoTime
                intPreviousVideoSeconds = CInt(Mid(strVideoTime, 7, 2))
                If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.IsPlaying Then
                    Me.tmrRecordPerSecond.Start()
                End If
                'End If
            Else
                Me.tmrRecordPerSecond.Start()
                'Call getGPSData(tc, strVideoTime, strX, strY, strZ)

            End If

        End If
    End Sub

    Private Sub cmdAddComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddComment.Click

        Dim tc As String = VIDEO_TIME_LABEL

        Dim strX As String = "NULL"
        Dim strY As String = "NULL"
        Dim strZ As String = "NULL"
        Dim query As String
        Dim blAquiredFix As Boolean = False

        strComment = InputBox("Enter a comment to be inserted as a record", "Enter Comment")
        If strComment = NULL_STRING Then
            If video_file_open Then
                playVideo()
            End If
            Exit Sub
        End If
        'If they are using the video control then get the time from there.
        ' The time code is set to be VIDEO_TIME_LABEL initially.
        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
        ' do the following only when the video is open:
        ' pause stream and get the time code
        ' If the video is not open, then we cannot pause the
        ' video stream, and there is no need to get the TimeCode.
        If video_file_open Then
            pauseVideo()
            tc = getTimeCode()
            strVideoTime = GetVideoTime(tc, strVideoDecimalTime)

        End If
        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.

            ' The GPRMC NMEA String does not contain elevation values. Enter null into database
            ' if GPRMC is the chosen string type.
            blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If
        strVideoTextTime = strVideoTime
        Dim strCode As String = ""
        Dim strName As String = ""

        ' If the image is open and the video is closed then get the picture information from the EXIF file
        If image_open And video_file_open = False Then

            Call getEXIFData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            strVideoTextTime = strVideoTime

        End If
        ' ======================================Code by Xida Chen (end)===========================================
        Dim j As Integer

        Try

            If Me.chkRepeatVariables.Checked = False Then
                For j = 0 To intNumHabitatButtons - 1
                    dictHabitatFieldValues(strHabitatButtonCodeNames(j).ToString) = "-9999"
                Next
            End If

            If tc <> NULL_STRING Then
                ' Insert new record in database
                Dim numrows As Integer


                strSpeciesCode = "NULL"
                strSpeciesCount = "NULL"
                strSide = "NULL"
                strRange = "NULL"
                strLength = "NULL"
                strHeight = "NULL"
                strWidth = "NULL"
                strAbundance = "NULL"
                strIdConfidence = "NULL"

                'If transect_date = "" Then
                query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, "666", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                Dim oComm As New OleDbCommand(query, conn)
                numrows = oComm.ExecuteNonQuery()
                fetch_data()
            Else
                MessageBox.Show("There is no GPS data being recieved at this time, therefore the record was not entered into the database", "No GPS Data Recieved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            If ex.Message.StartsWith("Syntax") Then
                MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
            Else
                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End If
        End Try
    End Sub


    Private Sub cmdNothingInPhoto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNothingInPhoto.Click

        If db_file_open = True Then
            Dim tc As String = VIDEO_TIME_LABEL

            Dim strX As String = "NULL"
            Dim strY As String = "NULL"
            Dim strZ As String = "NULL"
            Dim query As String = ""
            Dim blAquiredFix As Boolean = False

            strComment = "Nothing in photo"

            'If they are using the video control then get the time from there.
            ' The time code is set to be VIDEO_TIME_LABEL initially.
            Dim strPhotoTime As String = VIDEO_TIME_LABEL
            Dim strPhotoTextTime As String = VIDEO_TIME_LABEL
            Dim strPhotoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL

            ' ======================================Code by Xida Chen (end)===========================================
            Dim j As Integer

            Try


                For j = 0 To intNumHabitatButtons - 1
                    dictHabitatFieldValues(strHabitatButtonCodeNames(j).ToString) = "-9999"
                Next
                If booUseGPSTimeCodes Then

                    'Otherwise get the time from the NMEA string.

                    ' The GPRMC NMEA String does not contain elevation values. Enter null into database
                    ' if GPRMC is the chosen string type.
                    blAquiredFix = getGPSData(tc, strPhotoTime, strPhotoDecimalTime, strX, strY, strZ)
                    If Not blAquiredFix Then
                        Exit Sub
                    End If
                End If
                strPhotoTextTime = strPhotoTime
                Dim strCode As String = ""
                Dim strName As String = ""

                If image_open And video_file_open = False Then

                    Call getEXIFData(strPhotoTime, strPhotoDecimalTime, strX, strY, strZ)
                    strPhotoTextTime = strPhotoTime

                End If

                If tc <> NULL_STRING Then

                    ' Insert new record in database
                    Dim numrows As Integer


                    strSpeciesCode = "NULL"
                    strSpeciesCount = "NULL"
                    strSide = "NULL"
                    strRange = "NULL"
                    strLength = "NULL"
                    strHeight = "NULL"
                    strWidth = "NULL"
                    strAbundance = "NULL"
                    strIdConfidence = "NULL"

                    query = createInsertQuery(transect_date, transect_name, strPhotoTime, strPhotoTextTime, strPhotoDecimalTime, "777", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                    Dim oComm As New OleDbCommand(query, conn)
                    numrows = oComm.ExecuteNonQuery()
                    fetch_data()
                Else
                    MessageBox.Show("There is no GPS data being recieved at this time, therefore the record was not entered into the database", "No GPS Data Recieved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ex As Exception
                If ex.Message.StartsWith("Syntax") Then
                    MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
                Else
                    MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                End If
            End Try
        End If

    End Sub

    Private Sub ConfigureSpeciesEventToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureSpeciesEventToolStripMenuItem.Click
        If Not myFormLibrary.frmSpeciesEvent Is Nothing Then
            myFormLibrary.frmSpeciesEvent.Dispose()
            myFormLibrary.frmSpeciesEvent = Nothing
        End If

        myFormLibrary.frmConfigureSpecies = New frmConfigureSpecies
        myFormLibrary.frmConfigureSpecies.ShowDialog()

    End Sub

#End Region

#Region "Video Miner Functions"


    ' ==========================================================================================================
    ' Name: openSession()
    ' Description: Open a session which has saved the previous state of the program in VideoMiner Session file (*.vps)
    '              This will open the video that was being played when the session was saved.
    ' ==========================================================================================================
    Private Sub openSession()
        Try
            Dim ofd As OpenFileDialog = New OpenFileDialog
            ofd.Title = "Open Session"
            ofd.InitialDirectory = current_directory
            ofd.Filter = "XML Files (*.xml)|*.xml"
            ofd.FilterIndex = 1
            ofd.RestoreDirectory = True
            ofd.Multiselect = False

            ofd.ShowDialog()

            Dim strFileName As String = ""
            strFileName = ofd.FileName
            Me.SessionName = strFileName

            If strFileName = "" Or System.IO.File.Exists(strFileName) = False Then
                Exit Sub
            End If

            Dim blVideoOpen As Boolean
            Dim blImageOpen As Boolean
            Dim blDatabaseOpen As Boolean
            Dim strVideoFileName As String
            Dim strImageFileName As String
            Dim strDatabaseFileName As String
            Dim strVideoTime As String
            Dim strNumberRecordsShown As String

            blVideoOpen = GetConfiguration(strFileName, "SessionConfiguration/Video/Open")
            strVideoFileName = GetConfiguration(strFileName, "SessionConfiguration/Video/FileName")
            strVideoTime = GetConfiguration(strFileName, "SessionConfiguration/Video/Position")

            blImageOpen = GetConfiguration(strFileName, "SessionConfiguration/Image/Open")
            strImageFileName = GetConfiguration(strFileName, "SessionConfiguration/Image/FileName")

            blDatabaseOpen = GetConfiguration(strFileName, "SessionConfiguration/Database/Open")
            strDatabaseFileName = GetConfiguration(strFileName, "SessionConfiguration/Database/FileName")
            strNumberRecordsShown = GetConfiguration(strFileName, "SessionConfiguration/Database/NumberRecordsShown")

            If blDatabaseOpen = True Then
                If Not Me.grdVideoMinerDatabase.DataSource Is Nothing Then
                    Call CloseDatabase_Click(Nothing, Nothing)
                End If
                openDatabase(strDatabaseFileName) ' ofd.FileName returns full path filename
                files_loaded()
                strDatabaseFilePath = strDatabaseFileName
            End If

            If blImageOpen = True Then

                If Not myFormLibrary.frmImage Is Nothing Then
                    myFormLibrary.frmImage.Close()
                End If

                If myFormLibrary.frmImage Is Nothing Then
                    myFormLibrary.frmImage = New frmImage


                    Dim intX As Integer = 0
                    Dim intY As Integer = 0

                    Dim intMonitorCount As Integer = 0
                    Dim mon As Screen
                    Dim secMon As Screen
                    Dim priMon As Screen

                    For Each mon In Screen.AllScreens
                        If Not mon.Primary Then
                            secMon = mon
                        Else
                            priMon = mon
                        End If
                        intMonitorCount += 1
                    Next

                    Dim aPoint As System.Drawing.Point

                    If intMonitorCount = 1 Then
                        aPoint.X = intX
                        aPoint.Y = intY / 2
                        myFormLibrary.frmImage.Location = aPoint
                        myFormLibrary.frmImage.WindowState = FormWindowState.Normal
                    Else
                        aPoint.X = intX + priMon.Bounds.Width
                        aPoint.Y = intY / 2
                        myFormLibrary.frmImage.Location = aPoint
                        myFormLibrary.frmImage.WindowState = FormWindowState.Maximized
                    End If

                    myFormLibrary.frmImage.Show()
                End If
                currentImage = strFileName
                myFormLibrary.frmImage.PictureBox1.Image = Image.FromFile(strImageFileName)
                myFormLibrary.frmImage.Text = strImageFileName.Substring(strImageFileName.LastIndexOf("\") + 1, (strImageFileName.Length - strImageFileName.LastIndexOf("\") - 1))
                Me.FileName = strImageFileName.Substring(strImageFileName.LastIndexOf("\") + 1, (strImageFileName.Length - strImageFileName.LastIndexOf("\") - 1))

                ' set the flag "image_open" to be true.
                image_open = True
                ' Store the path of the current folder so that we can read 
                ' all the images under the current directory
                Dim imagePath As String = strImageFileName.Substring(0, strImageFileName.LastIndexOf("\") + 1)
                Dim allFiles As String() = Directory.GetFiles(imagePath)
                Dim cur_folder_files As String = ""
                Dim i As Integer
                Dim tempFileName As String
                ' We try to store the name of all the files under this folder
                ' and then separate each file name using "|".
                For i = 0 To allFiles.Length - 1
                    tempFileName = allFiles(i)
                    Dim subPostFix As String = tempFileName.Substring(tempFileName.Length - 4, 4)
                    If subPostFix = ".JPG" Or subPostFix = ".jpg" Or subPostFix = ".bmp" Or subPostFix = ".BMP" _
                      Or subPostFix = ".gif" Or subPostFix = ".GIF" Or subPostFix = ".png" Or subPostFix = ".PNG" Then
                        cur_folder_files = String.Concat(cur_folder_files, tempFileName.Substring(tempFileName.LastIndexOf("\") + 1, tempFileName.Length - 1 - tempFileName.LastIndexOf("\")), "|")
                    End If
                Next i
                cur_folder_files = cur_folder_files.Substring(0, cur_folder_files.Length() - 1)
                ' Store the name of all image files in an array
                ' We use the letter "|" to separate each file because "|" can not
                ' be a part of a file name
                fileNames = Split(cur_folder_files, "|")
                image_prefix = strImageFileName.Substring(0, strImageFileName.LastIndexOf("."))


                Me.cmdPreviousImage.Enabled = True
                Me.cmdNextImage.Enabled = True
                Me.cboZoom.Enabled = True
                Me.cmdPreviousImage.Visible = True
                Me.cmdNextImage.Visible = True
                Me.cboZoom.Visible = True
                Me.lblImageSize.Visible = True
                'Me.lblVideoControls.Visible = True
                'Me.lblVideoControls.Text = "Photo Controls"


                Me.cmdNothingInPhoto.Visible = True

                intCurrentZoom = Me.cboZoom.SelectedIndex

                Call enableDisableImageMenu(True)
            End If

            If blVideoOpen = True Then

                If Not myFormLibrary.frmVideoPlayer Is Nothing Then

                    myFormLibrary.frmVideoPlayer.Close()

                End If

                current_directory = strVideoFileName.Substring(0, strVideoFileName.LastIndexOf("\"))
                strVideoFilePath = strVideoFileName
                Me.FileName = strVideoFilePath.Substring(strVideoFilePath.LastIndexOf("\") + 1, strVideoFilePath.Length - strVideoFilePath.LastIndexOf("\") - 1)

                If myFormLibrary.frmVideoPlayer Is Nothing Then


                    myFormLibrary.frmVideoPlayer = New frmVideoPlayer
                    myFormLibrary.frmVideoPlayer.pnlHideVideo.Visible = True

                    Dim intX As Integer = 0
                    Dim intY As Integer = 0

                    Dim intMonitorCount As Integer = 0
                    Dim mon As Screen
                    Dim secMon As Screen
                    Dim priMon As Screen

                    For Each mon In Screen.AllScreens
                        If Not mon.Primary Then
                            secMon = mon
                        Else
                            priMon = mon
                        End If
                        intMonitorCount += 1
                    Next

                    Dim aPoint As System.Drawing.Point

                    If intMonitorCount = 1 Then
                        aPoint.X = intX
                        aPoint.Y = intY / 2
                        myFormLibrary.frmVideoPlayer.Location = aPoint
                        myFormLibrary.frmVideoPlayer.WindowState = FormWindowState.Normal
                        myFormLibrary.frmVideoPlayer.TopMost = True
                    Else
                        aPoint.X = intX + priMon.Bounds.Width
                        aPoint.Y = intY / 2
                        myFormLibrary.frmVideoPlayer.Location = aPoint
                        myFormLibrary.frmVideoPlayer.WindowState = FormWindowState.Maximized
                        myFormLibrary.frmVideoPlayer.TopMost = True
                    End If

                    Me.VideoTime = Parse(strVideoTime)
                    myFormLibrary.frmVideoPlayer.Show()

                Else
                    myFormLibrary.frmVideoPlayer.pnlHideVideo.Visible = True
                    Call myFormLibrary.frmVideoPlayer.frmVideoPlayer_Load(Me, New System.EventArgs)
                End If
            End If

            Me.Text = "Video Miner  " & Me.Version & " - " & Me.SessionName.Substring(Me.SessionName.LastIndexOf("\") + 1, (Me.SessionName.Length - 4) - Me.SessionName.LastIndexOf("\") - 1)

        Catch ex As Exception

        End Try

    End Sub

    ' ==========================================================================================================
    ' Name: saveSession()
    ' Description: Save session in current VideoMiner Session file (*.xml).
    '              This will save which video is being played.
    ' ==========================================================================================================
    Private Sub saveSession()
        Try
            Dim strFileName As String
            strFileName = Me.SessionName

            Dim blVideoOpen As Boolean
            Dim blImageOpen As Boolean
            Dim blDatabaseOpen As Boolean
            Dim strVideoFileName As String
            Dim strImageFileName As String
            Dim strDatabaseFileName As String
            Dim strVideoTime As String
            Dim strNumberRecordsShown As String

            If Not myFormLibrary.frmVideoPlayer Is Nothing Then
                blVideoOpen = True
                strVideoFileName = strVideoFilePath
                'strVideoTime = CStr(myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.currentPosition)
                strVideoTime = CStr(myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Position)
            Else
                blVideoOpen = False
                strVideoFileName = "NULL"
                strVideoTime = "NULL"
            End If

            If Not myFormLibrary.frmImage Is Nothing Then
                blImageOpen = True
                strImageFileName = currentImage
            Else
                blImageOpen = False
                strImageFileName = "NULL"
            End If

            If Not Me.grdVideoMinerDatabase.DataSource Is Nothing Then
                blDatabaseOpen = True
                strDatabaseFileName = strDatabaseFilePath
                strNumberRecordsShown = CStr(intNumberDisplayRecords)
            Else
                blDatabaseOpen = False
                strDatabaseFileName = "NULL"
                strNumberRecordsShown = "NULL"
            End If


            Call SaveXmlSettings(strFileName, "SessionConfiguration/Video/Open", blVideoOpen)
            Call SaveXmlSettings(strFileName, "SessionConfiguration/Video/FileName", strVideoFileName)
            Call SaveXmlSettings(strFileName, "SessionConfiguration/Video/Position", strVideoTime)

            Call SaveXmlSettings(strFileName, "SessionConfiguration/Image/Open", blImageOpen)
            Call SaveXmlSettings(strFileName, "SessionConfiguration/Image/FileName", strImageFileName)

            Call SaveXmlSettings(strFileName, "SessionConfiguration/Database/Open", blDatabaseOpen)
            Call SaveXmlSettings(strFileName, "SessionConfiguration/Database/FileName", strDatabaseFileName)
            Call SaveXmlSettings(strFileName, "SessionConfiguration/Database/NumberRecordsShown", strNumberRecordsShown)

        Catch ex As Exception
            MessageBox.Show("the following error occurred while saving the file: " & ex.Message & ".  Please try again.", "Error Saving Session", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    ' ==========================================================================================================
    ' Name: saveSessionAs()
    ' Description: Save session in a new VideoMiner Session file (*.xml).
    '              This will save which video is being played.
    ' ==========================================================================================================
    Private Sub saveSessionAs()

        Dim sfd As SaveFileDialog = New SaveFileDialog
        sfd.Title = "Save Session As"
        sfd.InitialDirectory = current_directory
        sfd.Filter = "XML Files (*.xml)|*.xml"
        sfd.RestoreDirectory = True

        sfd.ShowDialog()

        Dim strFileName As String = ""
        strFileName = sfd.FileName
        Me.SessionName = strFileName

        If strFileName = "" Then
            Exit Sub
        End If
        'If System.IO.File.Exists(strFileName) Then
        '    Call saveSession()
        '    Exit Sub
        'End If

        Dim blVideoOpen As Boolean
        Dim blImageOpen As Boolean
        Dim blDatabaseOpen As Boolean
        Dim strVideoFileName As String
        Dim strImageFileName As String
        Dim strDatabaseFileName As String
        Dim strVideoTime As String
        Dim strNumberRecordsShown As String

        If Not myFormLibrary.frmVideoPlayer Is Nothing Then
            blVideoOpen = True
            strVideoFileName = strVideoFilePath
            strVideoTime = CStr(myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Position)
        Else
            blVideoOpen = False
            strVideoFileName = "NULL"
            strVideoTime = "NULL"
        End If

        If Not myFormLibrary.frmImage Is Nothing Then
            blImageOpen = True
            strImageFileName = currentImage
        Else
            blImageOpen = False
            strImageFileName = "NULL"
        End If

        If Not Me.grdVideoMinerDatabase.DataSource Is Nothing Then
            blDatabaseOpen = True
            strDatabaseFileName = strDatabaseFilePath
            strNumberRecordsShown = CStr(intNumberDisplayRecords)
        Else
            blDatabaseOpen = False
            strDatabaseFileName = "NULL"
            strNumberRecordsShown = "15"
        End If

        Dim path As String

        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
        If (path.StartsWith("file:\")) Then
            path = path.Substring(6)    ' Remove unnecessary substring
        End If

        Dim ex As Exception

        ex = createXMLSessionFile(strFileName, blVideoOpen, strVideoFileName, strVideoTime, blImageOpen, strImageFileName, blDatabaseOpen, strDatabaseFileName, strNumberRecordsShown)
        If ex Is Nothing Then
            Me.Text = "Video Miner  " & Me.Version & " - " & Me.SessionName.Substring(Me.SessionName.LastIndexOf("\") + 1, (Me.SessionName.Length - 4) - Me.SessionName.LastIndexOf("\") - 1)
        Else
            MessageBox.Show("The following error occured while saving the file: " & ex.Message & ".  Please try again.", "Error Saving Session", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        'Call SaveXmlSettings(strFileName, "SaveSessionConfiguration/Video/Open", blVideoOpen)
        'Call SaveXmlSettings(strFileName, "SaveSessionConfiguration/Video/FileName", strVideoFileName)
        'Call SaveXmlSettings(strFileName, "SaveSessionConfiguration/Video/Position", strVideoTime)

        'Call SaveXmlSettings(strFileName, "SaveSessionConfiguration/Image/Open", blImageOpen)
        'Call SaveXmlSettings(strFileName, "SaveSessionConfiguration/Image/FileName", strImageFileName)

        'Call SaveXmlSettings(strFileName, "SaveSessionConfiguration/Database/Open", blDatabaseOpen)
        'Call SaveXmlSettings(strFileName, "SaveSessionConfiguration/Database/FileName", strDatabaseFileName)
        'Call SaveXmlSettings(strFileName, "SaveSessionConfiguration/Database/NumberRecordsShown", strNumberRecordsShown)


    End Sub


    Private Function createXMLSessionFile(ByVal strFileName As String, ByVal blVideoOpen As Boolean, ByVal strVideo As String, ByVal strTime As String, _
                                          ByVal blImageOpen As Boolean, ByVal strImage As String, ByVal blDatabaseOpen As Boolean, ByVal strDatabase As String, ByVal strRecords As String) As Exception
        Try
            Dim XMLWriter As XmlTextWriter
            XMLWriter = New XmlTextWriter(strFileName, System.Text.Encoding.UTF8)

            XMLWriter.WriteStartDocument(True)
            XMLWriter.Formatting = Formatting.Indented
            XMLWriter.Indentation = 2
            XMLWriter.WriteStartElement("SessionConfiguration")

            XMLWriter.WriteStartElement("Video")
            XMLWriter.WriteStartElement("Open")
            XMLWriter.WriteString(blVideoOpen)
            XMLWriter.WriteEndElement()
            XMLWriter.WriteStartElement("FileName")
            XMLWriter.WriteString(strVideo)
            XMLWriter.WriteEndElement()
            XMLWriter.WriteStartElement("Position")
            XMLWriter.WriteString(strTime)
            XMLWriter.WriteEndElement()
            XMLWriter.WriteEndElement()

            XMLWriter.WriteStartElement("Image")
            XMLWriter.WriteStartElement("Open")
            XMLWriter.WriteString(blImageOpen)
            XMLWriter.WriteEndElement()
            XMLWriter.WriteStartElement("FileName")
            XMLWriter.WriteString(strImage)
            XMLWriter.WriteEndElement()
            XMLWriter.WriteEndElement()

            XMLWriter.WriteStartElement("Database")
            XMLWriter.WriteStartElement("Open")
            XMLWriter.WriteString(blDatabaseOpen)
            XMLWriter.WriteEndElement()
            XMLWriter.WriteStartElement("FileName")
            XMLWriter.WriteString(strDatabase)
            XMLWriter.WriteEndElement()
            XMLWriter.WriteStartElement("NumberRecordsShown")
            XMLWriter.WriteString(strRecords)
            XMLWriter.WriteEndElement()
            XMLWriter.WriteEndElement()

            XMLWriter.WriteEndElement()

            XMLWriter.WriteEndDocument()
            XMLWriter.Close()
            Return Nothing
        Catch ex As Exception
            Return ex
        End Try

    End Function

    ' Function to save the XML settings to a file
    Private Function Save_XmlSettings(ByVal strConfigFile As String, ByVal strPath As String, ByVal strValue As String) As Boolean

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

    ' ==========================================================================================================
    ' Name: openDV()
    ' Description: Opens the DV tape by calling delegate function
    ' 1.) Load Video File
    ' 2.) If a database file is loaded already, run the files_loaded() function to Enable Buttons on main form (eg: set transect)
    ' ==========================================================================================================
    Private Function openDV() As Integer

        'Dim retval As Integer = c.Invoke(New InvokeOpenFile(AddressOf d.OpenDV))
        'If retval Then
        '    video_file_open = True
        '    video_file_load()
        '    If db_file_open Then
        '        files_loaded()
        '    End If
        'End If
        'Return retval
    End Function

    ' ==========================================================================================================
    ' Name: getTimeCode()
    ' Description: Opens the DV tape by calling delegate function
    ' 1.) Retrieve the time code from Video Controller
    ' ==========================================================================================================
    Private Function getTimeCode() As String

        Dim dblValue As Double = 0
        Try
            dblValue = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Position
        Catch ex As Exception

        End Try

        Return dblValue

    End Function

    Private Function openFile() As Boolean
        ' Returns True if the user chose a file to play, False is they pressed cancel or clicked the 'X'
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.Title = OPEN_VID_TITLE
        ofd.InitialDirectory = current_directory
        ofd.Filter = "Media Files (*.mpg,*.mpeg,*.avi,*.wma,*.wav,*.wmv,*.qt)|*.mpg;*.mpeg;*.avi;*.wma;*.wav;*.wmv;*.qt|All Files (*.*)|*.*"
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True
        ofd.Multiselect = False

        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'If ofd.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            current_directory = ofd.FileName.Substring(0, ofd.FileName.LastIndexOf("\"))
            strVideoFilePath = ofd.FileName
            Me.FileName = strVideoFilePath.Substring(strVideoFilePath.LastIndexOf("\") + 1, strVideoFilePath.Length - strVideoFilePath.LastIndexOf("\") - 1)
        Else
            Return False
        End If

        If myFormLibrary.frmVideoPlayer Is Nothing Then
            Try
                myFormLibrary.frmVideoPlayer = New frmVideoPlayer
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            myFormLibrary.frmVideoPlayer.pnlHideVideo.Visible = True

            Dim intX As Integer = 0
            Dim intY As Integer = 0

            Dim priMon, secMon As Screen

            priMon = Screen.AllScreens(0)
            If Screen.AllScreens.Length > 1 Then
                ' There is more than one display, make second one the default for video
                secMon = Screen.AllScreens(1)
            Else
                secMon = Nothing
            End If

            Dim aPoint As System.Drawing.Point

            If secMon Is Nothing Then
                aPoint.X = intX
                aPoint.Y = intY / 2
                myFormLibrary.frmVideoPlayer.Location = aPoint
                myFormLibrary.frmVideoPlayer.WindowState = FormWindowState.Normal
                myFormLibrary.frmVideoPlayer.TopMost = True
            Else
                'aPoint.X = intX + priMon.Bounds.Width
                'aPoint.Y = intY / 2
                aPoint.X = intX + priMon.Bounds.Width / 3
                aPoint.Y = intY / 4
                myFormLibrary.frmVideoPlayer.Location = aPoint
                'myFormLibrary.frmVideoPlayer.WindowState = FormWindowState.Maximized
                myFormLibrary.frmVideoPlayer.TopMost = True
            End If

            Me.VideoTime = Zero
            myFormLibrary.frmVideoPlayer.Show()
            'dblVideoTimeUserSet = 0
        Else
            myFormLibrary.frmVideoPlayer.pnlHideVideo.Visible = True
            Call myFormLibrary.frmVideoPlayer.frmVideoPlayer_Load(Me, New System.EventArgs)
            Me.VideoTime = frmVideoPlayer.tsCurrentVideoTime
        End If
        Return True
    End Function

    Public Sub enableDisableVideoMenu(ByVal mnuState As Boolean)

        Dim mnuItem As ToolStripMenuItem

        For Each mnuItem In mnuVideoTools.DropDownItems

            If mnuItem.Text <> "Open Video" And mnuItem.Text <> "Use External Video" Then
                mnuItem.Enabled = mnuState
            End If

        Next

    End Sub

    ' ==========================================================================================================
    ' Name: get_rel_filename()
    ' Description: Returns the filename without its path.
    ' ==========================================================================================================
    Private Function get_rel_filename(ByVal fullpath As String) As String
        Dim arr() As String = fullpath.Split(DIR_SEP)
        If arr.Length = 0 Then
            Return fullpath
        End If
        Return arr(arr.Length - 1)
    End Function

    ' ==========================================================================================================
    ' Name: no_files_loaded()
    ' Description: Disables buttons on main form when no file is loaded to prevent users from launching
    '  functions while no database file is open.
    ' 1.) Disable Set Time Code Button
    ' 2.) Disable Transect Start Button
    ' 3.) Enable Transect End Button
    ' 4.) Disable Off Bottom Buttom
    ' 5.) Disable Resume Video Button
    ' ==========================================================================================================
    Private Sub no_files_loaded()
        cmdShowSetTimecode.Enabled = False
        cmdTransectStart.Enabled = False
        cmdTransectEnd.Enabled = False
        cmdOffBottom.Enabled = False
        'Me.cmdEdit.Enabled = False
    End Sub

    ' ==========================================================================================================
    ' Name: files_loaded()
    ' Description: Enables/Disables buttons on main form when a file is loaded.
    ' 1.) Enable Set Time Code Button
    ' 2.) Enable Transect Start Button
    ' 3.) Disable Transect End Button
    ' 4.) Enable Off Bottom Buttom
    ' 5.) Enable Resume Video Button
    ' ==========================================================================================================
    Private Sub files_loaded()
        cmdShowSetTimecode.Enabled = True
        cmdTransectStart.Enabled = True
        cmdTransectEnd.Enabled = False
        cmdOffBottom.Enabled = True
        'ResumeVideo.Enabled = True
        Me.radQuickEntry.Visible = True
        Me.radDetailedEntry.Visible = True
        Me.radAbundanceEntry.Visible = True
        Me.cmdEdit.Visible = True
        Me.lblDisplayRecords.Visible = True
        Me.txtDisplayRecords.Visible = True
        Me.cmdRefreshDatabase.Visible = True
        Me.cmdDeleteLastRecord.Visible = True
        Me.cmdRareSpeciesLookup.Visible = True

        Me.txtTransectDate.Enabled = True
        Me.txtProjectName.Enabled = True
        Me.chkRecordEachSecond.Enabled = True
        Me.chkRepeatVariables.Visible = True
        Me.mnuConfigureTools.Enabled = True
        Me.mnuRefreshForm.Enabled = True
        Me.KeyboardShortcutsToolStripMenuItem.Enabled = True
        Me.DataCodeAssignmentsToolStripMenuItem.Enabled = True

    End Sub

    ' ==========================================================================================================
    ' Name: transect_started()
    ' Description: Function called when user presses transect start button
    ' 1.) Dispaly Transect name in TransectTextbox
    ' 2.) Disable the transect start button
    ' 3.) Enable the Transect end button
    ' 4.) Insert record into the database table "data" with variables for fields: id,TimeCode,DataCode,transect,OnBottom
    ' 5.) Load/Refresh the DataGridView1 database table view at bottom of main form using fetch_data().
    ' ==========================================================================================================
    Private Sub transect_started(ByVal tc As String, ByVal tcText As String, ByVal tcDecimal As String, ByVal strX As String, ByVal strY As String, ByVal strZ As String)

        If transect_name = UNNAMED_TRANSECT Then
            txtTransectTextbox.Text = UNNAMED_TRANSECT
        Else
            txtTransectTextbox.Text = "Transect '" & transect_name & "'"
        End If

        txtTransectTextbox.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
        txtTransectTextbox.BackColor = Color.LightGray
        txtTransectTextbox.ForeColor = Color.LimeGreen
        txtTransectTextbox.TextAlign = HorizontalAlignment.Center
        cmdTransectStart.Enabled = False
        cmdTransectEnd.Enabled = True

        ' Insert new record in database
        Dim numrows As Integer
        Dim query As String

        strSpeciesCode = "NULL"
        strSpeciesCount = "NULL"
        strSide = "NULL"
        strRange = "NULL"
        strLength = "NULL"
        strHeight = "NULL"
        strWidth = "NULL"
        strAbundance = "NULL"
        strIdConfidence = "NULL"
        strComment = "NULL"
        Try
            'If transect_date = "" Then
            query = createInsertQuery(transect_date, transect_name, tc, tcText, tcDecimal, "1", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

            Dim oComm As New OleDbCommand(query, conn)
            numrows = oComm.ExecuteNonQuery()
            fetch_data()
        Catch ex As Exception
            If ex.Message.StartsWith("Syntax") Then
                MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
            Else
                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End If
        End Try
    End Sub

    ' ==========================================================================================================
    ' Name: transect_stopped()
    ' Description: Function called when user presses transect start button
    ' 1.) Change text of TransectTextbox to read "No Transect"
    ' 2.) If a database and a video are open Enable the transect start button
    ' 3.) If a database and a video are open Disable the Transect end button
    ' 4.) If the time code variable "tc" is not blank, Insert record into the database table "data" with variables for 
    '     fields: id,TimeCode,DataCode,transect,OnBottom
    ' 5.) Load/Refresh the DataGridView1 database table view at bottom of main form using fetch_data().
    ' ==========================================================================================================
    Private Sub transect_stopped(ByVal tc As String, ByVal tcText As String, ByVal tcDecimal As String, ByVal strX As String, ByVal strY As String, ByVal strZ As String)
        txtTransectTextbox.Text = NO_TRANSECT
        txtTransectTextbox.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
        txtTransectTextbox.BackColor = Color.LightGray
        txtTransectTextbox.ForeColor = Color.Red
        txtTransectTextbox.TextAlign = HorizontalAlignment.Center
        'If db_file_open And video_file_open Then
        cmdTransectStart.Enabled = True
        cmdTransectEnd.Enabled = False
        'End If
        If tc <> NULL_STRING Then
            ' Insert new record in database
            Dim numrows As Integer
            Dim query As String = ""

            strSpeciesCode = "NULL"
            strSpeciesCount = "NULL"
            strSide = "NULL"
            strRange = "NULL"
            strLength = "NULL"
            strHeight = "NULL"
            strWidth = "NULL"
            strAbundance = "NULL"
            strIdConfidence = "NULL"
            strComment = "NULL"
            Try
                'If transect_date = "" Then
                query = createInsertQuery(transect_date, transect_name, tc, tcText, tcDecimal, "2", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                Dim oComm As New OleDbCommand(query, conn)
                numrows = oComm.ExecuteNonQuery()
                fetch_data()
            Catch ex As Exception
                If ex.Message.StartsWith("Syntax") Then
                    MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
                Else
                    MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                End If
            End Try
        End If
    End Sub

    ' ==========================================================================================================
    ' Name: toggle_bottom
    ' Description: Change text in OnOffBottomTextbox and on OffBottom button between "Off Bottom" and "On Bottom"
    '                   Possible states of variable is_on_bottom:
    '                       is_on_bottom = 0 (Off Bottom)        is_on_bottom = 1 (On Bottom)
    ' 1.) If variable is_on_bottom = 0 (Off Bottom) when OffBottom button clicked, then:
    '           - Change OnOffBottomTextbox to read "On Bottom"
    '           - Change OffBottom button to read "Off Bottom"
    '           - Change variable is_on_bottom to equal 1 (On Bottom)
    ' 2.) Else If variable is_on_bottom = 1 (On Bottom) when OffBottom button is clicked, then:
    '           - Change OnOffBottomTextbox to read "Off Bottom"
    '           - Change OffBottom button to read "On Bottom"
    '           - Change variable is_on_bottom to equal 0 (Off Bottom)
    ' 3.) If the time code variable "tc" is not blank, Insert record into the database table "data" with variables for 
    '     fields: id,TimeCode,DataCode,transect,OnBottom
    ' 4.) Load/Refresh the DataGridView1 database table view at bottom of main form using fetch_data().
    ' ==========================================================================================================
    Private Sub toggle_bottom(ByVal tc As String, ByVal tcText As String, ByVal tcDecimal As String, ByVal strX As String, ByVal strY As String, ByVal strZ As String)

        If is_on_bottom = 0 Then
            txtOnOffBottomTextbox.Text = ON_BOTTOM_STRING
            txtOnOffBottomTextbox.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            txtOnOffBottomTextbox.BackColor = Color.LightGray
            txtOnOffBottomTextbox.ForeColor = Color.LimeGreen
            txtOnOffBottomTextbox.TextAlign = HorizontalAlignment.Center
            cmdOffBottom.Text = OFF_BOTTOM_STRING
            cmdOffBottom.Refresh()
            is_on_bottom = 1
        Else
            txtOnOffBottomTextbox.Text = OFF_BOTTOM_STRING
            txtOnOffBottomTextbox.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            txtOnOffBottomTextbox.BackColor = Color.LightGray
            txtOnOffBottomTextbox.ForeColor = Color.Red
            txtOnOffBottomTextbox.TextAlign = HorizontalAlignment.Center
            cmdOffBottom.Text = ON_BOTTOM_STRING
            cmdOffBottom.Refresh()
            is_on_bottom = 0
        End If
        If tc <> NULL_STRING Then
            Dim numrows As Integer

            If tc = "" Then
                tc = VIDEO_TIME_LABEL
            End If
            Dim query As String = ""


            strSpeciesCode = "NULL"
            strSpeciesCount = "NULL"
            strSide = "NULL"
            strRange = "NULL"
            strLength = "NULL"
            strHeight = "NULL"
            strWidth = "NULL"
            strAbundance = "NULL"
            strIdConfidence = "NULL"
            strComment = "NULL"
            Try
                'If transect_date = "" Then
                query = createInsertQuery(transect_date, transect_name, tc, tcText, tcDecimal, "3", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                Dim oComm As New OleDbCommand(query, conn)
                numrows = oComm.ExecuteNonQuery()
                fetch_data()
            Catch ex As Exception
                If ex.Message.StartsWith("Syntax") Then
                    MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
                Else
                    MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                End If
            End Try
        End If
    End Sub

    Private Function AddZeros(ByVal strNumber As String, ByVal intPlaces As Integer) As String
        Dim intLength As Integer
        intLength = Len(strNumber.ToString)

        Dim strZeros As String = ""
        Dim i As Integer

        For i = 1 To intPlaces - intLength
            strZeros = strZeros & "0"
        Next

        Return strZeros & strNumber.ToString

    End Function

    'Private Sub EnableMiddleRow(ByVal booEnable As Boolean)
    '    Me.txtProjectName.Enabled = booEnable
    '    Me.txtTransectDate.Enabled = booEnable
    '    Me.cmdPlayForSeconds.Enabled = booEnable
    '    Me.txtPlaySeconds.Enabled = booEnable
    '    Me.chkRepeatVariables.Enabled = booEnable
    'End Sub

    Private Function getGPSData(ByRef tc As String, ByRef strVideoTime As String, ByRef strVideoDecimalTime As String, ByRef strX As String, ByRef strY As String, ByRef strZ As String) As Boolean

        'If m_SerialPort.IsOpen() Then
        '    Dim regKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\VideoMiner")
        '    Dim strGPSStringType As String = regKey.GetValue("GPSStringType")

        '    Dim blAquiredFix As Boolean = False
        '    Dim m_CurrentPoint As Point

        '    Call updateTextBox()

        '    m_CurrentPoint = New Point
        '    With m_CurrentPoint
        '        .NMEA = Me.txtNMEA.Text
        '        blAquiredFix = .GetPoint     ' Returns true if there is a valid location
        '    End With
        '    If blAquiredFix Then
        '        tc = Me.GPSDateTime
        '        strX = Me.GPS_X.ToString
        '        strY = Me.GPS_Y.ToString
        '        If strGPSStringType = "GPGGA" Then
        '            strZ = Me.GPS_Z.ToString
        '        End If
        '        strVideoTime = tc

        '        transect_date = Me.GPSDate
        '        Me.txtTransectDate.Text = transect_date
        '        Return True
        '    Else
        '        MessageBox.Show("The GPS string is empty. It is possible is that the GPS is not receiving a GPS fix.", "GPS String Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        Return False
        '    End If
        'Else
        '    MessageBox.Show("You have selected 'Use GPS Timecodes', but the GPS port is closed.  Please make sure that it is open before entering data.", "GPS Port Closed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If
        strX = Me.lblXValue.Text
        strY = Me.lblYValue.Text
        strZ = Me.lblZValue.Text
        transect_date = Me.GPSDate
        strVideoTime = Me.GPSDateTime
        strVideoDecimalTime = strVideoTime & ".00"
        Return True

    End Function

#End Region

#Region "Image Functions"

    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean


    '    If Not myFormLibrary.frmImage Is Nothing Then
    '        Dim keyPressed As Keys = CType(msg.WParam.ToInt32(), Keys)
    '        Dim intAnswer As Integer

    '        Select Case keyPressed

    '            Case Keys.Right

    '                image_index += 1
    '                ' If the index of the image is larger than the number
    '                ' of images in the folder, then set it to 0, which means
    '                ' the first image in the folder is displayed.
    '                If image_index >= fileNames.Length Then
    '                    intAnswer = MessageBox.Show("You have reached the last image in the folder, would you like to start again at the first image?", "Last Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                    If intAnswer = vbYes Then
    '                        image_index = 0
    '                    Else
    '                        image_index -= 1
    '                        Exit Function
    '                    End If
    '                End If
    '                ' Call this function to load the image and display it in the window
    '                LoadImg()

    '            Case Keys.Left
    '                image_index -= 1
    '                ' If the index of the image is smaller than 0, then set 
    '                ' it to be the second last image
    '                If image_index < 0 Then
    '                    intAnswer = MessageBox.Show("You have reached the first image in the folder, would you like to start again at the last image?", "First Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                    If intAnswer = vbYes Then
    '                        image_index = fileNames.Length - 1
    '                    Else
    '                        image_index += 1
    '                        Exit Function
    '                    End If
    '                End If
    '                ' Call this function to load the image and display it in the window
    '                LoadImg()

    '            Case Else
    '                Return MyBase.ProcessCmdKey(msg, keyData)

    '        End Select
    '    End If
    'End Function


    Private Sub getEXIFData(ByRef strPhotoTime As String, ByRef strPhotoDecimalTime As String, ByRef strX As String, ByRef strY As String, ByRef strZ As String)
        Me.lblGPSLocation.Visible = False
        Me.lblX.Visible = False
        Me.lblXValue.Visible = False
        Me.lblY.Visible = False
        Me.lblYValue.Visible = False
        Me.lblZ.Visible = False
        Me.lblZValue.Visible = False
        Dim arguments As String
        Dim exePathStr As String = System.Windows.Forms.Application.ExecutablePath.ToString()
        Dim command As String = String.Concat("""", exePathStr.Substring(0, exePathStr.LastIndexOf("\") + 1), "exiftool.exe")
        arguments = String.Concat("""", " -s ", """", imagePath & Me.FileName, """")
        Console.WriteLine(command & arguments)
        'MsgBox(command & arguments)
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(command & arguments)
        'oStartInfo.Arguments = arguments
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oStartInfo
        oProcess.StartInfo.CreateNoWindow = True
        oProcess.Start()
        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
        End Using
        Console.WriteLine(sOutput)

        Dim strEXIFOutput() As String
        strEXIFOutput = sOutput.Split(vbCrLf)
        Dim i As Integer
        Dim strDate As String = ""
        Dim strLine As String
        Dim strItems() As String
        Dim dblDegrees As Double
        Dim dblMinutes As Double
        Dim dblSeconds As Double
        Dim strGPS As String
        Dim strGPSSplit() As String
        Dim intNegative As Integer = 1
        Dim blDateTime As Boolean = False
        Dim blFileDateTime As Boolean = False
        Dim blX As Boolean = False
        Dim blY As Boolean = False
        Dim blZ As Boolean = False
        Dim blFlag As Boolean = False
        Dim strFileDate As String = ""
        Dim strFileTime As String = ""
        ' Read the line that has "DateTimeOriginal".
        For i = 0 To strEXIFOutput.Length - 1
            If strEXIFOutput(i).Contains("DateTimeOriginal") And Not strEXIFOutput(i).Contains("SubSec") Then
                strLine = strEXIFOutput(i)
                strItems = strLine.Split(":")
                strDate = strItems(3).Substring(0, 2) & "/" & strItems(2) & "/" & strItems(1).Substring(1, 4)
                transect_date = strDate
                strPhotoTime = ToMilitaryTime(strItems(3).Substring(3, 2) & ":" & strItems(4) & ":" & strItems(5))
                strPhotoDecimalTime = strPhotoTime & ".00"
                blDateTime = True
            ElseIf strEXIFOutput(i).Contains("DateTimeOriginal") And strEXIFOutput(i).Contains("SubSec") Then
                strLine = strEXIFOutput(i)
                strItems = strLine.Split(":")
                strDate = strItems(3).Substring(0, 2) & "/" & strItems(2) & "/" & strItems(1).Substring(1, 4)
                transect_date = strDate
                strPhotoDecimalTime = strItems(3).Substring(3, 2) & ":" & strItems(4) & ":" & strItems(5)
                strPhotoTime = ToMilitaryTime(strPhotoDecimalTime)
                blDateTime = True
            ElseIf strEXIFOutput(i).Contains("FileCreateDate") Then
                strLine = strEXIFOutput(i)
                strItems = strLine.Split(":")
                strDate = strItems(3).Substring(0, 2) & "/" & strItems(2) & "/" & strItems(1).Substring(1, 4)
                strFileDate = strDate
                strFileTime = ToMilitaryTime(strItems(3).Substring(3, 2) & ":" & strItems(4) & ":" & strItems(5).Substring(0, 2))
                blFileDateTime = True
            ElseIf strEXIFOutput(i).Contains("GPSLatitude") And Not strEXIFOutput(i).Contains("Ref") Then
                strLine = strEXIFOutput(i)
                strItems = strLine.Split(":")
                strGPS = strItems(1).Replace(" ", "")
                If strGPS.Contains("N") Then
                    intNegative = 1
                    strGPS = strGPS.Replace("""N", "")
                ElseIf strGPS.Contains("S") Then
                    intNegative = -1
                    strGPS = strGPS.Replace("""S", "")
                End If
                strGPS = strGPS.Replace("deg", "/")
                strGPS = strGPS.Replace("'", "/")

                strGPSSplit = strGPS.Split("/")
                dblDegrees = CDbl(strGPSSplit(0))
                dblMinutes = CDbl(strGPSSplit(1))
                dblSeconds = CDbl(strGPSSplit(2))
                strY = FormatNumber((dblDegrees + (dblMinutes / 60) + (dblSeconds / 3600)) * intNegative, 5)
                blY = True
                Me.lblGPSLocation.Visible = True
                Me.lblGPSLocation.Text = "EXIF Location"
                Me.lblY.Visible = True
                Me.lblYValue.Visible = True
            ElseIf strEXIFOutput(i).Contains("GPSLongitude") And Not strEXIFOutput(i).Contains("Ref") Then
                strLine = strEXIFOutput(i)
                strItems = strLine.Split(":")
                strGPS = strItems(1).Replace(" ", "")
                If strGPS.Contains("E") Then
                    intNegative = 1
                    strGPS = strGPS.Replace("""E", "")
                ElseIf strGPS.Contains("W") Then
                    intNegative = -1
                    strGPS = strGPS.Replace("""W", "")
                End If
                strGPS = strGPS.Replace("deg", "/")
                strGPS = strGPS.Replace("'", "/")
                strGPS = strGPS.Replace("""W", "")
                strGPSSplit = strGPS.Split("/")
                dblDegrees = CDbl(strGPSSplit(0))
                dblMinutes = CDbl(strGPSSplit(1))
                dblSeconds = CDbl(strGPSSplit(2))
                strX = FormatNumber((dblDegrees + (dblMinutes / 60) + (dblSeconds / 3600)) * intNegative, 5)
                blX = True
                Me.lblGPSLocation.Visible = True
                Me.lblGPSLocation.Text = "EXIF Location"
                Me.lblX.Visible = True
                Me.lblXValue.Visible = True
            ElseIf strEXIFOutput(i).Contains("GPSAltitude") And Not strEXIFOutput(i).Contains("Ref") Then
                strLine = strEXIFOutput(i)
                strItems = strLine.Split(":")
                strGPS = strItems(1).Replace(" ", "")
                If strGPS.Contains("AboveSeaLevel") Then
                    intNegative = 1
                    strGPS = strGPS.Replace("AboveSeaLevel", "")
                ElseIf strGPS.Contains("BelowSeaLevel") Then
                    intNegative = -1
                    strGPS = strGPS.Replace("BelowSeaLevel", "")
                End If
                strGPS = strGPS.Replace("m", "")
                strZ = FormatNumber(CDbl(strGPS) * intNegative, 2)
                blZ = True
                Me.lblGPSLocation.Visible = True
                Me.lblGPSLocation.Text = "EXIF Location"
                Me.lblZ.Visible = True
                Me.lblZValue.Visible = True
            End If
            intNegative = 1
        Next
        If blImageWarning = True Then
            Dim strMessage As String
            strMessage = "The following values were not found within the EXIF file, they will be set to blank:"

            If blDateTime = False Then
                If blFileDateTime = False Then
                    strMessage = strMessage & vbCrLf & "Date and Time"
                    transect_date = ""
                    strPhotoTime = ""
                Else
                    transect_date = strFileDate
                    strPhotoTime = strFileTime
                    strPhotoDecimalTime = strPhotoTime & ".00"
                End If
            End If
            If blX = False Then
                strMessage = strMessage & vbCrLf & "X"
                strX = ""
            End If
            If blY = False Then
                strMessage = strMessage & vbCrLf & "Y"
                strY = ""
            End If
            If blZ = False Then
                strMessage = strMessage & vbCrLf & "Z"
                strZ = ""
            End If
            strMessage = strMessage & vbCrLf & vbCrLf & "Do you wish to disable this warning for future images?"
            If Not blDateTime Or Not blX Or Not blY Or Not blZ Then
                Dim intAnswer As Integer
                intAnswer = MessageBox.Show(strMessage, "Invalid EXIF Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If intAnswer = vbYes Then
                    blImageWarning = False
                End If
            End If
        End If
    End Sub

    Public Sub enableDisableImageMenu(ByVal mnuState As Boolean)

        Dim mnuItem As ToolStripMenuItem

        For Each mnuItem In mnuImageTools.DropDownItems

            If mnuItem.Text <> "Open Image" Then
                mnuItem.Enabled = mnuState
            End If

        Next

    End Sub

    Private Sub cboZoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZoom.Click
        Me.cboZoom.Text = ""
    End Sub

    Private Sub cboZoom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZoom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim intValue As Integer = 0
            Dim intImageSize As Double = 0
            Dim w As Integer = 0
            Dim h As Integer = 0
            Dim strZoomValue As String = ""
            Dim c As Char

            For Each c In cboZoom.Text
                If IsNumeric(c) Then
                    strZoomValue = strZoomValue & c
                End If
            Next

            intValue = strZoomValue

            If intValue <= 250 Then
                If intValue <= 100 Then
                    intImageSize = 100 / intValue
                    w = Image.FromFile(currentImage).Width / intImageSize
                    h = Image.FromFile(currentImage).Height / intImageSize
                Else
                    intImageSize = intValue / 100
                    w = Image.FromFile(currentImage).Width * intImageSize
                    h = Image.FromFile(currentImage).Height * intImageSize
                End If

                redraw_Image(w, h)

                Me.cboZoom.Text = strZoomValue & "%"
                If lastImageIndex <> 0 Then
                    Me.cboZoom.Items.RemoveAt(lastImageIndex)
                End If
                Me.cboZoom.Items.Add(Me.cboZoom.Text)
                lastImageIndex = Me.cboZoom.Items.IndexOf(cboZoom.Text)
                intCurrentZoom = lastImageIndex
            Else
                cboZoom.Text = cboZoom.Items.Item(intCurrentZoom)
            End If
        End If
    End Sub

    Private Sub cboZoom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZoom.KeyPress
        Call numericTextboxValidation(e)
    End Sub

    Private Sub cboZoom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZoom.LostFocus
        Me.cboZoom.SelectedIndex = intCurrentZoom
    End Sub

    Private Sub cboZoom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZoom.SelectedIndexChanged

        If Me.pnlImageControls.Visible = True Then
            Dim w As Integer
            Dim h As Integer

            Select Case Me.cboZoom.SelectedItem
                Case "25%"
                    w = Image.FromFile(imagePath & imageFilesList(image_index)).Width / 4
                    h = Image.FromFile(imagePath & imageFilesList(image_index)).Height / 4
                Case "50%"
                    w = Image.FromFile(imagePath & imageFilesList(image_index)).Width / 2
                    h = Image.FromFile(imagePath & imageFilesList(image_index)).Height / 2
                Case "75%"
                    w = Image.FromFile(imagePath & imageFilesList(image_index)).Width / 1.3333
                    h = Image.FromFile(imagePath & imageFilesList(image_index)).Height / 1.3333
                Case "100%"
                    w = Image.FromFile(imagePath & imageFilesList(image_index)).Width
                    h = Image.FromFile(imagePath & imageFilesList(image_index)).Height
                Case "200%"
                    w = Image.FromFile(imagePath & imageFilesList(image_index)).Width * 2
                    h = Image.FromFile(imagePath & imageFilesList(image_index)).Height * 2
                Case Else
                    Dim intValue As Integer
                    Dim dblImageSize As Double
                    intValue = cboZoom.Text.Substring(0, cboZoom.Text.Length - 1)

                    If intValue <= 100 Then
                        dblImageSize = 100 / intValue
                        w = Image.FromFile(imagePath & imageFilesList(image_index)).Width / dblImageSize
                        h = Image.FromFile(imagePath & imageFilesList(image_index)).Height / dblImageSize
                    Else
                        dblImageSize = intValue / 100
                        w = Image.FromFile(imagePath & imageFilesList(image_index)).Width * dblImageSize
                        h = Image.FromFile(imagePath & imageFilesList(image_index)).Height * dblImageSize
                    End If
            End Select

            redraw_Image(w, h)

            intCurrentZoom = Me.cboZoom.SelectedIndex
        End If

    End Sub


    Private Sub cmdNextImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextImage.Click

        Dim intAnswer As Integer

        If (image_index + 1) > (imageFilesList.Count - 1) Then
            intAnswer = MessageBox.Show("You have reached the last image in the folder, would you like to start again at the first image?", "Last Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If intAnswer = vbYes Then
                image_index = 0
            Else
                Exit Sub
            End If
        Else
            image_index += 1
        End If
        LoadImg()
    End Sub

    Private Sub cmdPreviousImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousImage.Click
        Dim intAnswer As Integer

        If (image_index - 1) < 0 Then
            intAnswer = MessageBox.Show("You have reached the first image in the folder, would you like to start again at the last image?", "First Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If intAnswer = vbYes Then
                image_index = imageFilesList.Count - 1
            Else
                Exit Sub
            End If
        Else
            image_index -= 1
        End If
        LoadImg()
    End Sub



    ' This function is the common part for the next 4 functions.
    ' Basic it takes the width of height of the image and redraw the
    ' image inside the display window.
    Public Sub redraw_Image(ByVal w As Integer, ByVal h As Integer)
        Try
            Dim bmp As Bitmap = New Bitmap(Image.FromFile(imagePath & imageFilesList(image_index)), w, h)
            Dim g As Graphics = Graphics.FromImage(bmp)
            myFormLibrary.frmImage.PictureBox1.Image.Dispose()
            myFormLibrary.frmImage.PictureBox1.Image = Nothing
            GC.Collect()
            myFormLibrary.frmImage.PictureBox1.Width = w
            myFormLibrary.frmImage.PictureBox1.Height = h
            myFormLibrary.frmImage.PictureBox1.Image = bmp
            blSizeChanged = True
        Catch ex As Exception
            MsgBox("The image size you selected is too big, please try again")
            blSizeChanged = False
            Exit Sub
        End Try

    End Sub

    Public Sub LoadImg()


        ' And delete the .txt file generated by the EXIF tool for the previous image.
        System.IO.File.Delete(String.Concat(currentImage.Substring(0, currentImage.LastIndexOf(".")), ".txt"))
        ' When either one of the button ">" or "<" is pressed, the name of
        ' the current image should be updated.


        'currentImage = String.Concat(Me.image_prefix.Substring(0, Me.image_prefix.LastIndexOf("\") + 1), Me.fileNames(image_index))
        'Me.image_prefix = currentImage.Substring(0, currentImage.LastIndexOf("."))

        If imageFilesList.Count = 0 Then
            Exit Sub
        End If


        'If blForward Then
        '    If (image_index + 1) > (imageFilesList.Count - 1) Then
        '        intAnswer = MessageBox.Show("You have reached the last image in the folder, would you like to start again at the first image?", "Last Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '        If intAnswer = vbYes Then
        '            image_index = 0
        '        Else
        '            Exit Sub
        '        End If
        '    Else
        '        image_index += 1
        '    End If
        'Else
        '    If (image_index - 1) < 0 Then
        '        intAnswer = MessageBox.Show("You have reached the first image in the folder, would you like to start again at the last image?", "First Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '        If intAnswer = vbYes Then
        '            image_index = imageFilesList.Count - 1
        '        Else
        '            Exit Sub
        '        End If
        '    Else
        '        image_index -= 1
        '    End If
        'End If

        ' Detemine the size of the image shown in the window
        Dim w, h As Integer

        Select Case Me.cboZoom.SelectedItem
            Case "25%"
                w = Image.FromFile(imagePath & imageFilesList(image_index)).Width / 4
                h = Image.FromFile(imagePath & imageFilesList(image_index)).Height / 4
            Case "50%"
                w = Image.FromFile(imagePath & imageFilesList(image_index)).Width / 2
                h = Image.FromFile(imagePath & imageFilesList(image_index)).Height / 2
            Case "75%"
                w = Image.FromFile(imagePath & imageFilesList(image_index)).Width / 1.3333
                h = Image.FromFile(imagePath & imageFilesList(image_index)).Height / 1.3333
            Case "100%"
                w = Image.FromFile(imagePath & imageFilesList(image_index)).Width
                h = Image.FromFile(imagePath & imageFilesList(image_index)).Height
            Case "200%"
                w = Image.FromFile(imagePath & imageFilesList(image_index)).Width * 2
                h = Image.FromFile(imagePath & imageFilesList(image_index)).Height * 2
            Case Else
                Dim intValue As Integer
                Dim dblImageSize As Double
                intValue = cboZoom.Text.Substring(0, cboZoom.Text.Length - 1)

                If intValue <= 100 Then
                    dblImageSize = 100 / intValue
                    w = Image.FromFile(imagePath & imageFilesList(image_index)).Width / dblImageSize
                    h = Image.FromFile(imagePath & imageFilesList(image_index)).Height / dblImageSize
                Else
                    dblImageSize = intValue / 100
                    w = Image.FromFile(imagePath & imageFilesList(image_index)).Width * dblImageSize
                    h = Image.FromFile(imagePath & imageFilesList(image_index)).Height * dblImageSize
                End If
        End Select


        Try
            ' Display the image in the picture box.
            'Dim bmp As Bitmap = New Bitmap(Image.FromFile(currentImage), w, h)
            'Dim g As Graphics = Graphics.FromImage(bmp)
            'myFormLibrary.frmImage.PictureBox1.Image.Dispose()
            'myFormLibrary.frmImage.PictureBox1.Image = Nothing
            'GC.Collect()
            'myFormLibrary.frmImage.PictureBox1.Image = bmp
            'myFormLibrary.frmImage.Text = Me.fileNames(image_index)
            'blSizeChanged = True
            myFormLibrary.frmImage.PictureBox1.Image.Dispose()
            myFormLibrary.frmImage.PictureBox1.Image = Nothing
            GC.Collect()

            Dim Dir As String = imagePath & imageFilesList(image_index)
            Dim bmp As Bitmap = New Bitmap(Image.FromFile(Dir), w, h)
            Dim g As Graphics = Graphics.FromImage(bmp)
            myFormLibrary.frmImage.PictureBox1.Image = bmp
            myFormLibrary.frmImage.Text = imageFilesList(image_index)
            Me.FileName = imageFilesList(image_index)
            currentImage = imagePath & imageFilesList(image_index)
            Call getEXIFData(Me.txtTime.Text, "", Me.lblXValue.Text, Me.lblYValue.Text, Me.lblZValue.Text)
            strTimeDateSource = "EXIF"
            intTimeSource = 3
            Me.txtTimeSource.Text = strTimeDateSource
            'Me.txtTimeSource.ForeColor = Color.LimeGreen
            'Me.txtTime.ForeColor = Color.LimeGreen
            Me.txtTimeSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            Me.txtTimeSource.BackColor = Color.LightGray
            Me.txtTimeSource.ForeColor = Color.LimeGreen
            Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
            Me.txtTime.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            Me.txtTime.BackColor = Color.LightGray
            Me.txtTime.ForeColor = Color.LimeGreen
            Me.txtTime.TextAlign = HorizontalAlignment.Center
            Me.txtTransectDate.Text = transect_date
            Me.txtDateSource.Text = strTimeDateSource
            Me.txtDateSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            Me.txtDateSource.BackColor = Color.LightGray
            Me.txtDateSource.ForeColor = Color.LimeGreen
            Me.txtDateSource.TextAlign = HorizontalAlignment.Center
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Function ConvertBMP(ByVal BMPFullPath As String, ByVal imgFormat As ImageFormat) As Boolean

        Dim bAns As Boolean
        Dim strNewFileName As String
        Dim strNewFilePath As String
        Dim strNewFile As String

        Try

            ' Get a bitmap. 
            Dim bmp1 As New Bitmap(BMPFullPath)
            Dim jgpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)

            ' Create an Encoder object based on the GUID 
            ' for the Quality parameter category. 
            Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

            ' Create an EncoderParameters object. 
            ' An EncoderParameters object has an array of EncoderParameter 
            ' objects. In this case, there is only one 
            ' EncoderParameter object in the array. 
            Dim myEncoderParameters As New EncoderParameters(1)

            Dim myEncoderParameter As New EncoderParameter(myEncoder, 100&)
            myEncoderParameters.Param(0) = myEncoderParameter
            strNewFilePath = GetDirectoryName(BMPFullPath)
            strNewFileName = GetFileNameWithoutExtension(BMPFullPath)

            strNewFile = strNewFilePath & "\" & strNewFileName & ".jpg"

            bmp1.Save(strNewFile, jgpEncoder, myEncoderParameters)
            bmp1 = Nothing
            ''bitmap class in system.drawing.imaging
            'Dim objBmp As New Bitmap(BMPFullPath)

            ''below 2 functions in system.io.path
            'strNewFilePath = GetDirectoryName(BMPFullPath)
            'strNewFileName = GetFileNameWithoutExtension(BMPFullPath)

            'strNewFile = strNewFilePath & "\" & strNewFileName & "." & imgFormat.ToString
            'objBmp.Save(strNewFile, imgFormat)
            'objBmp.Dispose()
            bAns = True 'return true on success
        Catch
            bAns = False 'return false on error
        End Try
        Return bAns

    End Function

#End Region

#Region "Video Functions"

    Private Sub cmdPlayForSeconds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlayForSeconds.Click
        Try
            ' Check to make sure that the entered value is numeric
            If IsNumeric(Me.txtPlaySeconds.Text) Then

                Dim dblCurrentSeconds As Double

                Dim strSeconds As String()
                Dim intCurrentSeconds As Integer

                dblCurrentSeconds = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Position
                'dblCurrentSeconds = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.currentPosition

                strSeconds = dblCurrentSeconds.ToString.Split(".")
                intCurrentSeconds = CInt(strSeconds(0))

                intPlayForSeconds = CInt(Me.txtPlaySeconds.Text)
                Me.tmrPlayForSeconds.Interval = 100
                Me.tmrPlayForSeconds.Enabled = True

                intEndPlaySeconds = intCurrentSeconds + intPlayForSeconds

                playVideo()
                Me.tmrPlayForSeconds.Start()

            Else
                MsgBox("Please Enter a Numeric Value", MsgBoxStyle.OkOnly)
                Me.txtPlaySeconds.Focus()
                Exit Sub
            End If
        Catch ex As Exception

        End Try


    End Sub

    Public Sub cmdPlayPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlayPause.Click
        ' If the video is paused or stopped..
        If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.IsPaused Or Not myFormLibrary.frmVideoPlayer.plyrVideoPlayer.IsPlaying Then
            playVideo()
            If Me.chkRecordEachSecond.Checked = True Then
                blFirstTime = True
                Me.tmrRecordPerSecond.Start()
            End If
        Else
            ' If it is already playing then pause it.
            pauseVideo()
        End If
    End Sub

    Private Sub playVideo()
        Try
            myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Play()
            myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Rate = dblVideoRate
            myFormLibrary.frmVideoPlayer.blIsPlaying = True
            myFormLibrary.frmVideoPlayer.tmrVideo.Start()
            FfwdCount = 0
            RwndCOunt = 0
            Me.cmdPlayPause.BackgroundImage = Image.FromFile(filePath & "\Pause_Icon.png")
            myFormLibrary.frmVideoPlayer.pctVideoStatus.BackgroundImage = Image.FromFile(filePath & "\Play_Icon_Inverse.png")
            'myFormLibrary.frmVideoPlayer.pctVideoStatus.Image = Image.FromFile(filePath & "\Play_Icon.png")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.tmrRecordPerSecond.Stop()
            myFormLibrary.frmVideoPlayer.blIsPlaying = False
        End Try

    End Sub

    Private Sub pauseVideo()
        Try
            myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Pause()
            If Me.tmrRecordPerSecond.Enabled Then
                Me.tmrRecordPerSecond.Stop()
            End If
            If myFormLibrary.frmVideoPlayer.tmrVideo.Enabled Then
                myFormLibrary.frmVideoPlayer.tmrVideo.Stop()
            End If
            myFormLibrary.frmVideoPlayer.blIsPlaying = False
            Me.cmdPlayPause.BackgroundImage = Image.FromFile(filePath & "\Play_Icon.png")
            myFormLibrary.frmVideoPlayer.pctVideoStatus.BackgroundImage = Image.FromFile(filePath & "\Pause_Icon_Inverse.png")
            'myFormLibrary.frmVideoPlayer.pctVideoStatus.Image = Image.FromFile(filePath & "\Pause_Icon.png")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        FfwdCount = 0
        RwndCOunt = 0
    End Sub

    Private Sub stopVideo()
        Try
            myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Stop()
            'myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.stop()
            If Me.tmrRecordPerSecond.Enabled Then
                Me.tmrRecordPerSecond.Stop()
            End If
            myFormLibrary.frmVideoPlayer.tmrVideo.Stop()
            myFormLibrary.frmVideoPlayer.blIsPlaying = False
            myFormLibrary.frmVideoPlayer.trkCurrentPosition.Value = 0
            Me.cmdPlayPause.BackgroundImage = Image.FromFile(filePath & "\Play_icon.png")
            myFormLibrary.frmVideoPlayer.pctVideoStatus.BackgroundImage = Image.FromFile(filePath & "\Stop_Icon_Inverse.png")
            myFormLibrary.frmVideoPlayer.lblCurrentTime.Text = VIDEO_TIME_DECIMAL_LABEL
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        FfwdCount = 0
        RwndCOunt = 0
    End Sub


    Private Sub increaseRate()
        Try
            dblVideoRate = dblVideoRate + 0.25
            myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Rate = dblVideoRate
            Me.lblVideoRate.Text = dblVideoRate & " X"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub decreaseRate()
        Try
            If dblVideoRate <> 0.25 Then
                dblVideoRate = dblVideoRate - 0.25
            End If
            myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Rate = dblVideoRate
            Me.lblVideoRate.Text = dblVideoRate & " X"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub StepForward()
        ' This function steps forward the video by 10% based on where the video is currently and the duration of the video
        ' I am going to try to make this button a frame stepper, using keyframes.

        myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Pause()
        myFormLibrary.frmVideoPlayer.plyrVideoPlayer.NextFrame()
        Dim dblCurrentPosition = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Position * 100.0
    End Sub

    'Private Sub StepForward_old()
    '    ' This function steps forward the video by 10% based on where the video is currently and the duration of the video
    '    ' I am going to try to make this button a frame stepper, using keyframes.
    '    'Debug.Print(myFormLibrary.frmVideoPlayer.plyrVideoPlayer.playlist.isPlaying)

    '    Dim dblDurationSeconds As Double = 0
    '    Dim dblCurrentSeconds As Double = 0

    '    dblCurrentSeconds = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Position
    '    dblDurationSeconds = myFormLibrary.frmVideoPlayer.dblDuration


    '    'dblCurrentSeconds = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.currentPosition
    '    'dblDurationSeconds = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.currentMedia.duration

    '    Dim dblDuration As Double
    '    dblDuration = myFormLibrary.frmVideoPlayer.dblDuration
    '    'dblDuration = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.currentMedia.duration
    '    Dim intValue As Integer

    '    intValue = CInt((dblCurrentSeconds / dblDuration) * 100)


    '    Select Case intValue

    '        Case Is < 10
    '            intValue = 10
    '        Case Is < 20
    '            intValue = 20
    '        Case Is < 30
    '            intValue = 30
    '        Case Is < 40
    '            intValue = 40
    '        Case Is < 50
    '            intValue = 50
    '        Case Is < 60
    '            intValue = 60
    '        Case Is < 70
    '            intValue = 70
    '        Case Is < 80
    '            intValue = 80
    '        Case Is < 90
    '            intValue = 90
    '        Case Is < 100
    '            intValue = 100
    '        Case Else
    '            Exit Sub
    '    End Select

    '    myFormLibrary.frmVideoPlayer.blChapter = True
    '    myFormLibrary.frmVideoPlayer.trkCurrentPosition.Value = intValue


    '    'plyrVideoPlayer.Ctlcontrols.currentPosition = dblValue * plyrVideoPlayer.currentMedia.duration

    '    Dim strCurrentTime As String = ""
    '    Dim strDurationTime As String = ""


    '    'dblCurrentSeconds = plyrVideoPlayer.Ctlcontrols.currentPosition
    '    'dblDurationSeconds = plyrVideoPlayer.currentMedia.duration - dblCurrentSeconds



    '    myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Position = myFormLibrary.frmVideoPlayer.dblDuration * (intValue / 100)
    '    'strCurrentTime = createTimeString(myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Position)
    '    'strDurationTime = createTimeString(dblDurationSeconds)
    '    myFormLibrary.frmVideoPlayer.lblCurrentTime.Text = strCurrentTime
    '    myFormLibrary.frmVideoPlayer.lblDuration.Text = strDurationTime

    '    'If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.input.state = 2 Then
    '    '    MsgBox("Buffering")
    '    'Else
    '    '    MsgBox("Playing")
    '    'End If

    'End Sub

    'Private Sub StepBackward()
    '    Dim dblDurationSeconds As Double = 0
    '    Dim dblCurrentSeconds As Double = 0

    '    dblCurrentSeconds = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Position
    '    dblDurationSeconds = myFormLibrary.frmVideoPlayer.dblDuration

    '    'dblCurrentSeconds = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.currentPosition
    '    'dblDurationSeconds = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.currentMedia.duration

    '    Dim dblDuration As Double
    '    dblDuration = myFormLibrary.frmVideoPlayer.dblDuration
    '    'dblDuration = myFormLibrary.frmVideoPlayer.plyrVideoPlayer.currentMedia.duration
    '    Dim intValue As Integer

    '    intValue = CInt((dblCurrentSeconds / dblDuration) * 100)


    '    Select Case intValue
    '        Case Is > 90
    '            intValue = 90
    '        Case Is > 80
    '            intValue = 80
    '        Case Is > 70
    '            intValue = 70
    '        Case Is > 60
    '            intValue = 60
    '        Case Is > 50
    '            intValue = 50
    '        Case Is > 40
    '            intValue = 40
    '        Case Is > 30
    '            intValue = 30
    '        Case Is > 20
    '            intValue = 20
    '        Case Is > 10
    '            intValue = 10
    '        Case Is > 0
    '            intValue = 0
    '            dblCurrentSeconds = 0
    '        Case Else
    '            Exit Sub
    '    End Select

    '    myFormLibrary.frmVideoPlayer.blChapter = True
    '    myFormLibrary.frmVideoPlayer.trkCurrentPosition.Value = intValue


    '    'plyrVideoPlayer.Ctlcontrols.currentPosition = dblValue * plyrVideoPlayer.currentMedia.duration

    '    Dim strCurrentTime As String = ""
    '    Dim strDurationTime As String = ""


    '    'dblCurrentSeconds = plyrVideoPlayer.Ctlcontrols.currentPosition
    '    'dblDurationSeconds = plyrVideoPlayer.currentMedia.duration - dblCurrentSeconds



    '    myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Position = myFormLibrary.frmVideoPlayer.dblDuration * (intValue / 100)
    '    'strCurrentTime = createTimeString(myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Position)
    '    'strDurationTime = createTimeString(dblDurationSeconds)
    '    myFormLibrary.frmVideoPlayer.lblCurrentTime.Text = strCurrentTime
    '    myFormLibrary.frmVideoPlayer.lblDuration.Text = strDurationTime
    'End Sub

    Private Function FormatTimeCode(ByVal str As String) As String

        Dim strTime As String = ""
        Dim dr As DialogResult

        If (str.Length <> 8) Then
            dr = MessageBox.Show("The time code must be 8 digits in length (HHMMSSmm).", "Time Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Return strTime
        End If

        Dim strHour As String = str.Substring(0, 2)
        Dim intHour As Integer = CType(strHour, Integer)
        If (intHour < 0) Or (intHour > 23) Then
            dr = MessageBox.Show("You have entered a hour value of: " & strHour & ", which is invalid.", "Time Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Return strTime
        End If

        Dim strMinute As String = str.Substring(2, 2)
        Dim intMinute As Integer = CType(strMinute, Integer)
        If (intMinute < 0) Or (intMinute > 59) Then
            dr = MessageBox.Show("You have entered a minute value of: " & strMinute & ", which is invalid.", "Time Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Return strTime
        End If

        Dim strSecond As String = str.Substring(4, 2)
        Dim intSecond As Integer = CType(strSecond, Integer)
        If (intSecond < 0) Or (intSecond > 59) Then
            dr = MessageBox.Show("You have entered a second value of: " & strSecond & ", which is invalid.", "Time Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Return strTime
        End If

        Dim strMilliseconds As String = str.Substring(6, 2)
        Dim intMilliseconds As Integer = CType(strMilliseconds, Integer)
        If (intMilliseconds < 0) Or (intMilliseconds > 99) Then
            dr = MessageBox.Show("You have entered a milli-second value of: " & strMilliseconds & ", which is invalid.", "Time Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Return strTime
        End If

        strTime = strHour & ":" & strMinute & ":" & strSecond & "." & strMilliseconds
        Return strTime

    End Function

    ' ==========================================================================================================
    ' Name: video_file_load()
    ' Description: Open a new window to display video chosen by user.
    ' 1.) Change the text of text box VideoFileStatus at top of program to read the name of whichever video is loaded.
    ' ==========================================================================================================
    Public Sub video_file_load()

        Me.lblVideo.Text = "Video File '" & Me.FileName & "' is open"
        Me.video_file_open = True

        ' MsgBox("Ensure time is set to correspond with video before creating transect observations.", MsgBoxStyle.OkOnly)
    End Sub

    ' ==========================================================================================================
    ' Name: video_file_unload()
    ' Description: Function called when user closes a video.
    ' 1.) Change the text of text box VideoFileStatus at top of program to read "No Video Loaded".
    ' ==========================================================================================================
    Public Sub video_file_unload()

        Me.lblVideo.Text = VIDEO_FILE_STATUS_UNLOADED
        Me.video_file_open = False

    End Sub

#End Region

#Region "Database Functions"

    ' ==========================================================================================================
    ' Name: db_file_load()
    ' Description: Function called when a database is opened
    ' 1.) Change the text of text box DatabaseFileStatus at top of program to read Name of opened database.
    ' 2.) Enable option "Close Database" in the file menu. (this is disabled until you open a database)
    ' 3.) Disable option "Open Database" in the file menu. (this is disabled until you close a database)
    ' ==========================================================================================================
    Private Sub db_file_load()
        'DatabaseFileStatus.Text = DB_FILE_STATUS_LOADED + db_filename + IS_OPEN
        'DatabaseFileStatus.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
        'DatabaseFileStatus.BackColor = Color.LightGray
        'DatabaseFileStatus.ForeColor = Color.LimeGreen
        'DatabaseFileStatus.TextAlign = HorizontalAlignment.Center
        If Not conn Is Nothing Then
            Me.lblDatabase.Text = DB_FILE_STATUS_LOADED & db_filename & " is open"

            mnuOpenDatabase.Enabled = False
            mnuCloseDatabase.Enabled = True
        End If
    End Sub

    ' ==========================================================================================================
    ' Name: db_file_unload()
    ' Description: Function called when a database is closed
    ' 1.) Change the text of text box DatabaseFileStatus at top of program to read "no database loaded"
    ' 2.) Enable option "Open Database" in the file menu. (this is disabled until you close a database)
    ' 3.) Disable option "Close Database" in the file menu. (this is disabled until you open a database)
    ' 4.) Remove buttons from panel1 and panel2
    ' ==========================================================================================================
    Public Sub db_file_unload()

        'DatabaseFileStatus.Text = DB_FILE_STATUS_UNLOADED
        'DatabaseFileStatus.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
        'DatabaseFileStatus.BackColor = Color.LightGray
        'DatabaseFileStatus.ForeColor = Color.Red
        'DatabaseFileStatus.TextAlign = HorizontalAlignment.Center

        Me.lblDatabase.Text = DB_FILE_STATUS_UNLOADED

        mnuOpenDatabase.Enabled = True
        mnuCloseDatabase.Enabled = False
        Dim i As Integer
        If Not IsNothing(Transect_Buttons) Then
            For i = 0 To intNumTransectButtons - 1
                Transect_Buttons(i).Dispose()
                Transect_Buttons(i) = Nothing
                Transect_Textboxes(i).Dispose()
                Transect_Textboxes(i) = Nothing

            Next
            intNumTransectButtons = 0
        End If

        If Not IsNothing(buttons) Then
            For i = 0 To intNumHabitatButtons - 1
                buttons(i).Dispose()
                buttons(i) = Nothing
                textboxes(i).Dispose()
                textboxes(i) = Nothing

            Next
            intNumHabitatButtons = 0
            For i = 0 To intNumSpeciesButtons - 1
                speciesButtons(i).Dispose()
                speciesButtons(i) = Nothing

            Next
            intNumSpeciesButtons = 0
        End If
    End Sub

    ' ==========================================================================================================
    ' Name: openDatabase
    ' Description: Opens a database for use in the program.
    ' 1.) If the database can not be loaded, inform the user.
    ' 2.) Load one button for each record in the videominer_habitat_buttons table into Panel1: fill_spatialvariable_button_panel()
    ' 3.) Load one button for each record in the videominer_species_buttons table into Panel2: fill_speciesvariable_button_panel()
    ' ==========================================================================================================
    Public Sub openDatabase(ByVal strDBFileName As String)
        Dim connection_string As String
        connection_string = DB_CONN_STRING + strDBFileName

        Try
            conn = New OleDbConnection(connection_string)
            conn.Open()
        Catch ex As Exception
            MsgBox("The file" + strDBFileName + " was not found.", MsgBoxStyle.Exclamation, "File not found")
        Finally
            db_filename = get_rel_filename(strDBFileName)
            db_file_open = True
            fillTransectVariableButtonPanel()
            fillSpatialVariableButtonPanel()
            fillSpeciesVariableButtonPanel()
            fillHabitatFieldsCollection()
            fillDataCodesTable()
            If Not conn Is Nothing Then
                db_file_load()
                If video_file_open Then
                    files_loaded()
                    video_file_load()
                End If
                fetch_data()
            End If
        End Try
    End Sub


    Private Sub fillDataCodesTable()

        Dim clDataCodes As New Collection
        Dim clDataCodeDescriptions As New Collection

        Dim strQuery As String
        Dim tblDataCodes As DataTable

        Dim oComm As OleDbCommand

        Try
            strQuery = "DELETE * FROM lu_data_codes WHERE Code > 4 AND Code < 555;"

            oComm = New OleDbCommand(strQuery, conn)
            oComm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("You do not have the permissions to perform operations on this database, make sure you have full control over the file", "Could Not Open Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call CloseDatabase_Click(Nothing, Nothing)
            Exit Sub
        End Try


        strQuery = "SELECT * FROM videominer_habitat_buttons;"

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand(strQuery, conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, "videominer_habitat_buttons")

        tblDataCodes = sub_data_set.Tables(0)

        Dim r As DataRow

        For Each r In tblDataCodes.Rows
            clDataCodes.Add(r.Item("DataCode"))
            clDataCodeDescriptions.Add(r.Item("ButtonText"))
        Next

        strQuery = "SELECT * FROM videominer_transect_buttons;"

        sub_data_set = Nothing
        sub_data_set = New DataSet
        sub_db_command = New OleDbCommand(strQuery, conn)
        sub_data_adapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, "videominer_transect_buttons")

        tblDataCodes = sub_data_set.Tables(0)

        For Each r In tblDataCodes.Rows
            clDataCodes.Add(r.Item("DataCode"))
            clDataCodeDescriptions.Add(r.Item("ButtonText"))
        Next

        strQuery = "SELECT * FROM videominer_species_buttons WHERE DataCode <> 4;"

        sub_data_set = Nothing
        sub_data_set = New DataSet
        sub_db_command = New OleDbCommand(strQuery, conn)
        sub_data_adapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, "videominer_transect_buttons")

        tblDataCodes = sub_data_set.Tables(0)

        For Each r In tblDataCodes.Rows
            clDataCodes.Add(r.Item("DataCode"))
            clDataCodeDescriptions.Add(r.Item("ButtonText"))
        Next

        strQuery = "SELECT * FROM lu_data_codes;"

        sub_data_set = Nothing
        sub_data_set = New DataSet
        sub_db_command = New OleDbCommand(strQuery, conn)
        sub_data_adapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, "lu_data_codes")

        tblDataCodes = sub_data_set.Tables(0)

        Dim i As Integer

        For Each r In tblDataCodes.Rows

            For i = 1 To clDataCodes.Count

                If r.Item("Code") = clDataCodes.Item(i) Then
                    clDataCodes.Remove(i)
                    clDataCodeDescriptions.Remove(i)
                    i -= 1
                End If

            Next

        Next

        Dim insertCommand As OleDbCommand

        Try
            For i = 1 To clDataCodes.Count

                strQuery = "INSERT INTO lu_data_codes (Code, Description) VALUES(" & clDataCodes.Item(i) & ", " & SingleQuote(clDataCodeDescriptions.Item(i)) & ")"

                insertCommand = New OleDbCommand(strQuery, conn)
                insertCommand.ExecuteNonQuery()

            Next
        Catch ex As Exception
            MessageBox.Show("You do not have the permissions to perform operations on this database, make sure you have full control over the file", "Could Not Open Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call CloseDatabase_Click(Nothing, Nothing)
            Exit Sub
        End Try
    End Sub

    ' ==========================================================================================================
    ' Name: fetch_data()
    ' Description: Display the "data" table from database in the DataGridView1 Data grid View.
    ' 1.) Open a connection to the database.
    ' 2.) Select all records from the database table "data" in descending order based on id field.
    ' 3.) Display the selected records from the database in the data grid view DataGridView1.
    ' ==========================================================================================================
    Private Sub fetch_data()
        Dim i As Integer

        Dim clSelectItems As New Collection
        blupdateColumns = False
        select_string = "SELECT TOP " & intNumberDisplayRecords
        insert_string = "INSERT INTO " & DB_DATA_TABLE & "("
        For i = 1 To colTableFields.Count

            Select Case colTableFields.Item(i)

                Case "SpeciesID"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "SpeciesName"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "SpeciesCount"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Side"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Range"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Length"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Height"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Width"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Abundance"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "IDConfidence"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Comment"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "DataCode"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "X"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Y"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Z"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "FileName"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "ScreenCaptureName"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Format(ElapsedTime, 'hh:mm:ss') as ElapsedTime"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Format(ReviewedDate, 'm/dd/yyyy') as ReviewDate"
                    clSelectItems.Add(colTableFields.Item(i))
                Case "Format(ReviewedTime, 'hh:mm:ss') as ReviewTime"
                    clSelectItems.Add(colTableFields.Item(i))
                Case Else
                    select_string = select_string & " " & colTableFields.Item(i) & ","
            End Select


            If colTableFields.Item(i) = "Format(TimeCode, 'hh:mm:ss') as TimeCode" Then
                insert_string = insert_string & "TimeCode"
            ElseIf colTableFields.Item(i) = "Format(ElapsedTime, 'hh:mm:ss') as ElapsedTime" Then
                insert_string = insert_string & "ElapsedTime"
            ElseIf colTableFields.Item(i) <> "Format(ReviewedDate, 'm/dd/yyyy') as ReviewDate" And colTableFields.Item(i) <> "Format(ReviewedTime, 'hh:mm:ss') as ReviewTime" Then
                insert_string = insert_string & colTableFields.Item(i)
            End If

            If i <> colTableFields.Count Then
                If colTableFields.Item(i) <> "Format(ReviewedDate, 'm/dd/yyyy') as ReviewDate" And colTableFields.Item(i) <> "Format(ReviewedTime, 'hh:mm:ss') as ReviewTime" Then
                    insert_string = insert_string & ","
                End If
            End If

        Next

        For i = 1 To clSelectItems.Count

            select_string = select_string & " " & clSelectItems.Item(i)

            If i <> clSelectItems.Count Then
                select_string = select_string & ","
            End If

        Next

        select_string = select_string & " FROM " & DB_DATA_TABLE & " ORDER BY ID DESC;"

        If insert_string.Substring(insert_string.Length - 1, 1) = "," Then
            insert_string = insert_string.Substring(0, insert_string.Length - 1)
        End If
        insert_string = insert_string & ") "

        Dim strConfigFile As String = strConfigFilePath & "\VideoMinerConfigurationDetails.xml"
        Dim strDatabaseName As String = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/Database/Configuration/DatabaseName")
        Dim strColumns As String = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/Database/Configuration/Columns")
        Dim strColumnArray() As String = strColumns.Split(",")
        dataColumns = New Collection
        For i = 0 To strColumnArray.Count - 1
            dataColumns.Add(strColumnArray(i))
        Next

        Dim query As String
        query = select_string
        data_cmd = New OleDbCommand(query, conn)
        data_adapter = New OleDbDataAdapter(query, conn)
        data_set = New DataSet
        data_table = New DataTable()
        data_binding = New BindingSource()
        Dim intIDColumn As Integer = 0
        Try
            data_command_builder = New OleDbCommandBuilder(data_adapter)
            data_adapter.Fill(data_set, DB_DATA_TABLE)
            AddHandler data_set.Tables(DB_DATA_TABLE).RowDeleted, AddressOf data_rows_deleted
            'data_binding.DataSource = data_set.Tables(DB_DATA_TABLE)
            data_table = data_set.Tables(DB_DATA_TABLE)
            Dim j As Integer
            If strDatabaseName = db_filename Then
                For j = 1 To dataColumns.Count
                    Dim strItem As String = dataColumns.Item(j)
                    Dim strColumn() As String = strItem.Split(":")
                    If strColumn(0) = "ID" Then
                        intIDColumn = CInt(strColumn(1))
                    End If
                    data_table.Columns(strColumn(0)).SetOrdinal(CInt(strColumn(1)))
                Next
            End If
            data_binding.DataSource = data_table
            grdVideoMinerDatabase.DataSource = data_binding

            If Not dataColumns Is Nothing Then
                Dim grdColumn As DataGridViewColumn
                For j = 1 To dataColumns.Count
                    Dim strItem As String = dataColumns.Item(j)
                    Dim strColumn() As String = strItem.Split(":")
                    For Each grdColumn In grdVideoMinerDatabase.Columns
                        If grdColumn.Name = strColumn(0) Then
                            grdColumn.Width = CInt(strColumn(2))
                            Exit For
                        End If
                    Next
                Next
            End If



        Catch ex As Exception
            MsgBox("There was an exception thrown while trying to set up the database view. Message and Stack trace:" & vbCrLf & ex.Message() & vbCrLf & ex.StackTrace)
        Finally
            If data_set.Tables(0).Rows.Count > 0 Then
                db_id_num = data_table.Rows(0).Item(intIDColumn) + 1 ' retrieve id from database, assumes id ordered descending
            Else
                db_id_num = 1
            End If
        End Try
        If Me.grdVideoMinerDatabase.Rows.Count = 0 Then
            Me.cmdDeleteLastRecord.Enabled = False
        Else
            Me.cmdDeleteLastRecord.Enabled = True
        End If
        blupdateColumns = True
    End Sub

    ' ==========================================================================================================
    ' Name: DataGridView1_CellEndEdit
    ' Description: Once the user has chosen to delete a record from the database, call the rows_deleted()
    '              function to perform this action.
    ' ==========================================================================================================
    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        rows_deleted()
    End Sub

    ' ==========================================================================================================
    ' Name: data_rows_deleted
    ' Description: Once the user has chosen to delete a record from the database, call the rows_deleted()
    '              function to perform this action.
    ' ==========================================================================================================
    Private Sub data_rows_deleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        rows_deleted()
    End Sub

    ' ==========================================================================================================
    ' Name: rows_deleted()
    ' Description: Called when the user deletes a record from the "data" table in the data grid view DataGridView1
    '   1.) Delete whichever record the user chose in DataGridView1 from the database itself.
    ' ==========================================================================================================
    Private Sub rows_deleted()
        'update the database
        data_binding.EndEdit()
        Dim comm_builder As OleDbCommandBuilder = New OleDbCommandBuilder(data_adapter)
        Try
            data_adapter.Update(data_set, DB_DATA_TABLE)
            data_set.AcceptChanges()
        Catch ex As Exception
            MsgBox("The value you entered would result in a key violation in the database table '" & DB_DATA_TABLE & "'" & vbCrLf & _
            "and therefore no changes were made to the database.", MsgBoxStyle.Exclamation, "Key Violation")
        End Try
    End Sub

    ' Function to create a query for a detailed insert statement
    Private Function createInsertQuery(ByVal strTransectDate As String, ByVal strTransectName As String, ByVal strVideoTime As String, ByVal strVideoTextTime As String, ByVal strVideoDecimalTime As String, ByVal strDataCode As String, ByVal strSpecies_Name As String, _
                                       ByVal strX As String, ByVal strY As String, ByVal strZ As String, ByVal strSpeciesCode As String, ByVal strSpeciesCount As String, ByVal strSide As String, ByVal strRange As String, _
                                       ByVal strLength As String, ByVal strHeight As String, ByVal strWidth As String, ByVal strAbundance As String, ByVal strIdConfidence As String, ByVal strComment As String) As String
        Dim i As Integer
        Dim j As Integer
        Dim strQuery As String
        strQuery = insert_string & "VALUES ("

        If myFormLibrary.frmVideoPlayer Is Nothing Then
            myFormLibrary.frmVideoMiner.ElapsedTime = ""
        End If

        ' Parse through all the field names in the collection and attach the associated variables with the field names
        For i = 1 To colTableFields.Count
            Select Case colTableFields.Item(i).ToString
                Case "ID"
                    strQuery = strQuery & db_id_num
                Case "ProjectName"
                    If project_name = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(project_name)
                    End If
                Case "TransectName"
                    If transect_name = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(transect_name)
                    End If
                Case "TransectDate"
                    If strTransectDate = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        Try
                            Dim strDate As New Date(CInt(strTransectDate.Substring(6, 4)), CInt(strTransectDate.Substring(3, 2)), CInt(strTransectDate.Substring(0, 2)))
                            strQuery = strQuery & SingleQuote(strDate)
                        Catch ex As Exception
                            strQuery = strQuery & "NULL"
                        End Try
                    End If
                Case "Format(TimeCode, 'hh:mm:ss') as TimeCode"
                    If strVideoTime = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(strVideoTime) '& ", " & SingleQuote(strVideoTime)
                    End If
                Case "TextTime"
                    If strVideoTextTime = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(strVideoTextTime)
                    End If
                Case "TextTimeDecimal"
                    If strVideoDecimalTime = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(strVideoDecimalTime)
                    End If
                Case "Milliseconds"
                    If strMilliseconds = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(strMilliseconds)
                    End If
                Case "OnBottom"
                    If is_on_bottom = -9999 Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & is_on_bottom
                    End If
                Case "SpeciesID"
                    If strSpeciesCode = "NULL" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(strSpeciesCode)
                    End If
                Case "SpeciesName"
                    If strSpecies_Name = "NULL" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(strSpecies_Name)
                    End If
                Case "SpeciesCount"
                    If strSpeciesCount = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strSpeciesCount
                    End If
                Case "Side"
                    If strSide = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strSide
                    End If
                Case "Range"
                    If strRange = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strRange
                    End If
                Case "Length"
                    If strLength = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strLength
                    End If
                Case "Height"
                    If strHeight = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strHeight
                    End If
                Case "Width"
                    If strWidth = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strWidth
                    End If
                Case "Abundance"
                    If strAbundance = "NULL" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strAbundance
                    End If
                Case "IDConfidence"
                    If strIdConfidence = "NULL" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strIdConfidence
                    End If
                Case "Comment"
                    If strComment = "NULL" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(strComment)
                    End If
                Case "DataCode"
                    If strDataCode = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strDataCode
                    End If
                Case "X"
                    If strX = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strX
                    End If
                Case "Y"
                    If strY = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strY
                    End If
                Case "Z"
                    If strZ = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & strZ
                    End If
                Case "FileName"
                    If Me.FileName = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(Me.FileName)
                    End If
                Case "ScreenCaptureName"
                    If Me.FileName = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(Me.ScreenCaptureName)
                    End If
                Case "TimeSource"
                    strQuery = strQuery & intTimeSource
                Case "Format(ElapsedTime, 'hh:mm:ss') as ElapsedTime"
                    If Me.ElapsedTime = "" Then
                        strQuery = strQuery & "NULL"
                    Else
                        strQuery = strQuery & SingleQuote(Me.ElapsedTime)
                    End If
                Case "Format(ReviewedDate, 'm/dd/yyyy') as ReviewDate"
                    GoTo SkipInsertComma
                Case "Format(ReviewedTime, 'hh:mm:ss') as ReviewTime"
                    GoTo SkipInsertComma
                Case Else
                    ' Cycle through all the spatial variable button names using them as keys to access the dictionary object
                    For j = 0 To intNumHabitatButtons - 1
                        If strHabitatButtonCodeNames(j).ToString = colTableFields.Item(i).ToString Then
                            If dictHabitatFieldValues(strHabitatButtonCodeNames(j).ToString) <> "-9999" Then
                                strQuery = strQuery & SingleQuote(dictHabitatFieldValues(strHabitatButtonCodeNames(j).ToString))
                            Else
                                strQuery = strQuery & Replace(dictHabitatFieldValues(strHabitatButtonCodeNames(j).ToString), "-9999", "Null")
                            End If
                            GoTo InsertComma
                        End If
                    Next j

                    For j = 0 To intNumTransectButtons - 1
                        If strTransectButtonCodeNames(j).ToString = colTableFields.Item(i).ToString Then
                            If dictTransectFieldValues(strTransectButtonCodeNames(j).ToString) <> "-9999" Then
                                strQuery = strQuery & SingleQuote(dictTransectFieldValues(strTransectButtonCodeNames(j).ToString))
                            Else
                                strQuery = strQuery & Replace(dictTransectFieldValues(strTransectButtonCodeNames(j).ToString), "-9999", "Null")
                            End If
                            GoTo InsertComma
                        End If
                    Next

            End Select
InsertComma:
            If i <> colTableFields.Count Then
                strQuery = strQuery & ","
            End If
SkipInsertComma:
        Next i

        If strQuery.Substring(strQuery.Length - 1, 1) = "," Then
            strQuery = strQuery.Substring(0, strQuery.Length - 1)
        End If
        strQuery = strQuery & ");"

        If Me.chkRepeatVariables.Checked = False Then

            Dim blHasValues As Boolean = False
            If Not dictHabitatFieldValues Is Nothing Or Not dictTempHabitatFieldValues Is Nothing Then

                For i = 0 To intNumHabitatButtons - 1
                    If dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) <> "-9999" Then
                        blHasValues = True
                        Exit For
                    End If
                Next

                For i = 0 To intNumHabitatButtons - 1
                    If blHasValues = True Then
                        dictTempHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString)
                    End If
                    ' Clear all original variables so that the values are not repeated on consecutive records.
                    dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = "-9999"
                Next
            End If

        End If

        Me.strComment = ""

        Return strQuery

    End Function


#End Region

#Region "Habitat Variable Functions"
    ' ==========================================================================================================
    ' Name: ClearSpatial()
    ' Description: This sub is called when the user selects the clear button within the define all habitat values
    '              sequence. Depending on what habitat value table the user is currently within, the 
    '              current value will be cleared.
    ' ==========================================================================================================
    Public Sub ClearSpatial(ByVal strButtonName As String, ByVal intNumButtons As Integer, ByVal strButtonNames As String(), ByRef dictFieldValues As Dictionary(Of String, String), ByVal strButtonCodeNames As String(), ByRef txtTextBoxes As TextBox())
        Dim i As Integer
        For i = 0 To intNumButtons - 1
            If strButtonName = strButtonNames(i) Then
                ' Depending on the button selected, set the substrate variable to non value.

                dictFieldValues(strButtonCodeNames(i).ToString) = "-9999"
                Dim _fontfamily As FontFamily
                _fontfamily = New FontFamily(Me.ButtonFont)
                'Set the button and text back to non value state. 
                txtTextBoxes(i).Text = "No " & strButtonNames(i)
                txtTextBoxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                txtTextBoxes(i).BackColor = Color.LightGray
                txtTextBoxes(i).ForeColor = Color.Red
                txtTextBoxes(i).TextAlign = HorizontalAlignment.Center
            End If
        Next
    End Sub

    ' ==========================================================================================================
    ' Name: fill_spatialvariable_button_panel()
    ' Description:  Prepare panel1 once both a database and a video file are opened.
    ' 1.) Load one button for each record in the videominer_habitat_buttons table into Panel1.
    ' 2.) Set the button click event to call SpatialVariableButtonHandler()
    ' ==========================================================================================================

    Public Sub fillSpatialVariableButtonPanel()
        If dictHabitatFieldValues Is Nothing Then
            dictHabitatFieldValues = New Dictionary(Of String, String)
        Else
            dictHabitatFieldValues = Nothing
            dictHabitatFieldValues = New Dictionary(Of String, String)
        End If

        If dictTempHabitatFieldValues Is Nothing Then
            dictTempHabitatFieldValues = New Dictionary(Of String, String)
        Else
            dictTempHabitatFieldValues = Nothing
            dictTempHabitatFieldValues = New Dictionary(Of String, String)
        End If

        If Me.pnlHabitatData.Controls.Count <> 0 Then
            Dim ctl As Control
            Dim txt As TextBox

            For Each ctl In pnlHabitatData.Controls
                If ctl.Name <> "lblHabitatData" And ctl.Name <> "cmdDefineAllSpatialVariables" And ctl.Name <> "chkRepeatVariables" Then
                    Me.pnlHabitatData.Controls.Remove(ctl)
                End If
            Next
        End If

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand("select * from " & DB_BUTTONS_TABLE & " ORDER BY DrawingOrder;", conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, DB_BUTTONS_TABLE)
        Dim r As DataRow
        Dim d As DataTable
        d = sub_data_set.Tables(0)
        intNumHabitatButtons = d.Rows.Count
        ReDim buttons(intNumHabitatButtons)
        ReDim textboxes(intNumHabitatButtons)
        ReDim strHabitatButtonNames(intNumHabitatButtons)
        ReDim intHabitatButtonCodes(intNumHabitatButtons)
        ReDim strHabitatButtonTables(intNumHabitatButtons)
        ReDim strHabitatButtonCodeNames(intNumHabitatButtons)
        ReDim strHabitatButtonUserCodeChoice(intNumHabitatButtons)
        ReDim strHabitatButtonUserNameChoice(intNumHabitatButtons)
        ReDim strHabitatButtonColors(intNumHabitatButtons)
        Dim h As Integer = pnlHabitatData.Height
        Dim w As Integer = pnlHabitatData.Width
        Dim i As Integer = 0
        Dim sizex As Integer = Me.ButtonWidth
        Dim sizey As Integer = Me.ButtonHeight
        Dim gap As Integer = 5

        Dim intAdd As Integer = 0
        Dim intMultiply As Integer = 0

        For Each r In d.Rows
            strHabitatButtonNames(i) = New String(r.Item(1).ToString())
            strHabitatButtonTables(i) = New String(r.Item(2).ToString())
            intHabitatButtonCodes(i) = r.Item(3)
            strHabitatButtonCodeNames(i) = New String(r.Item(4).ToString())

            ' Fill temporary dictionary values with button code names and populate with empty strings
            dictTempHabitatFieldValues.Add(strHabitatButtonCodeNames(i).ToString, -9999)
            dictHabitatFieldValues.Add(strHabitatButtonCodeNames(i).ToString, -9999)
            strHabitatButtonColors(i) = New String(r.Item(5).ToString())

            buttons(i) = New Button()
            textboxes(i) = New TextBox()
            buttons(i).Name = strHabitatButtonNames(i)
            Dim colConvert As ColorConverter = New ColorConverter()
            Try
                buttons(i).ForeColor = colConvert.ConvertFromString(strHabitatButtonColors(i))
            Catch ex As Exception
                buttons(i).ForeColor = Color.Black
            End Try

            Dim newFont As Font
            Dim _fontfamily As FontFamily
            _fontfamily = New FontFamily(Me.ButtonFont)
            If _fontfamily.IsStyleAvailable(FontStyle.Regular) Then
                newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Regular)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Bold) Then
                newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Italic) Then
                newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Italic)
            End If

            buttons(i).Font = newFont

            buttons(i).Text = strHabitatButtonNames(i)
            buttons(i).Size = New Size(sizex, sizey)
            textboxes(i).Size = New Size(sizex, sizey / 2)
            textboxes(i).ReadOnly = True
            Dim cellsizex = sizex + gap
            Dim cellsizey = (1.5 * sizey) + gap

            buttons(i).Location = New System.Drawing.Point(gap + (cellsizex * intMultiply), 85 + gap + (cellsizey * (i - intAdd)))
            textboxes(i).Location = New System.Drawing.Point(gap + (cellsizex * intMultiply), (cellsizey * (i - intAdd)) + (sizey + 85 + gap))


            textboxes(i).Text = "No " & strHabitatButtonNames(i)
            textboxes(i).Name = "txt" & Replace(strHabitatButtonNames(i), "%", "Percent")

            Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"

            Dim txtName As String = textboxes(i).Name
            Dim Letter As String
            For x As Integer = 0 To textboxes(i).Name.Length - 1
                Letter = textboxes(i).Name.Substring(x, 1).ToUpper
                If strCharactersAllowed.Contains(Letter) = False Then
                    txtName = txtName.Replace(Letter, String.Empty)
                End If
            Next
            textboxes(i).Name = txtName

            textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
            textboxes(i).BackColor = Color.LightGray
            textboxes(i).ForeColor = Color.Red
            textboxes(i).TextAlign = HorizontalAlignment.Center
            textboxes(i).ReadOnly = True
            AddHandler buttons(i).Click, AddressOf SpatialVariableButtonHandler

            pnlHabitatData.Controls.Add(buttons(i))
            pnlHabitatData.Controls.Add(textboxes(i))

            If i Mod 6 = 5 Then
                intAdd += 6
                intMultiply += 1
            End If

            i = i + 1
        Next
        Me.cmdDefineAllSpatialVariables.Visible = True
        Me.cmdAddComment.Visible = True
    End Sub

    ' ==========================================================================================================
    ' Name: SpatialVariableButtonHandler
    ' Description: Called when a spatial button from Panel1 is clicked.
    ' 1.) When a user clicks a button, pull up that buttons corresponding list of choices. For example, selecting the
    '     relief button allows the user to select a relief type from the datbase table lu_relief_type.
    ' 2.) Insert a record into the database table "data" with values for the fields:
    '           id,TimeCode,DataCode,transect,OnBottom and the id field that corresponds to the button that was pressed.
    '     - The id field is filleed with the user selected type (see step 1).
    '     - The possible id fields that correspond to the buttons are (at the time these commets were written):
    '       DataCode_name, DominantSubstrate, relief_id, complexity_id, biocover_id, biocover_thickness_id, spatial1_id
    ' ==========================================================================================================
    Private Sub SpatialVariableButtonHandler(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim btn As Button = sender
        Dim i As Integer
        Dim j As Integer
        Dim query As String = ""
        Dim strCode As String = ""
        Dim strName As String = ""
        Dim blAquiredFix As Boolean = False
        Dim tc As String = VIDEO_TIME_LABEL
        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL

        Dim strX As String = "NULL"
        Dim strY As String = "NULL"
        Dim strZ As String = "NULL"

        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.

            ' The GPRMC NMEA String does not contain elevation values. Enter null into database
            ' if GPRMC is the chosen string type.
            blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If

        ' Give the user the ability to cear a substrate type or percent by ctrl clicking the button
        If My.Computer.Keyboard.CtrlKeyDown Then
            For i = 0 To intNumHabitatButtons - 1
                If btn.Name = strHabitatButtonNames(i) Then
                    ' Depending on the button selected, set the substrate variable to non value.

                    dictHabitatFieldValues.Item(strHabitatButtonCodeNames(i).ToString) = -9999
                    Dim newFont As Font
                    Dim _fontfamily As FontFamily
                    _fontfamily = New FontFamily(Me.ButtonFont)
                    If _fontfamily.IsStyleAvailable(FontStyle.Regular) Then
                        newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Regular)
                    ElseIf _fontfamily.IsStyleAvailable(FontStyle.Bold) Then
                        newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                    ElseIf _fontfamily.IsStyleAvailable(FontStyle.Italic) Then
                        newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Italic)
                    End If
                    'Set the button and text back to non value state. 
                    textboxes(i).Text = "No " & strHabitatButtonNames(i)
                    textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                    textboxes(i).BackColor = Color.LightGray
                    textboxes(i).ForeColor = Color.Red
                    textboxes(i).TextAlign = HorizontalAlignment.Center
                End If
            Next
            Exit Sub
        End If




        ' ======================================Code by Xida Chen (begin)===========================================
        'If they are using the video control then get the time from there.
        ' The time code is set to be VIDEO_TIME_LABEL initially.

        ' do the following only when the video is open:
        ' pause stream and get the time code
        ' If the video is not open, then we cannot pause the
        ' video stream, and there is no need to get the TimeCode.
        If video_file_open And Not booUseGPSTimeCodes Then
            If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.IsPlaying Then
                blVideoWasPlaying = True
            Else
                blVideoWasPlaying = False
            End If
            pauseVideo()
            tc = getTimeCode()
            strVideoTime = GetVideoTime(tc, strVideoDecimalTime)
        End If

        strVideoTextTime = strVideoTime
        ' ======================================Code by Xida Chen (end)===========================================
        Dim strHabitatValue As String = ""
        For i = 0 To intNumHabitatButtons - 1
            If btn.Name = strHabitatButtonNames(i) Then

                If strHabitatButtonTables(i) = "UserEntered" Then
                    Dim strValue As String
                    Dim strPreviousValue As String = dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString)
                    myFormLibrary.frmAddValue = New frmAddValue(dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString))
                    myFormLibrary.frmAddValue.lblExpression.Text = "Please enter a value for " & btn.Text & ":"
                    myFormLibrary.frmAddValue.Text = btn.Text & " Entry"
                    myFormLibrary.frmAddValue.ShowDialog()

                    strValue = myFormLibrary.frmAddValue.strValue
                    myFormLibrary.frmAddValue.Close()
                    myFormLibrary.frmAddValue = Nothing
                    If strValue = strPreviousValue Then
                        Exit Sub
                    End If
                    'strValue = InputBox("Please enter a value for " & btn.Text & " (limit 50 characters):", btn.Text & " Entry")
                    If strValue = "-9999" Then
                        ' If the image is open and the video is closed then get the picture information from the EXIF file
                        If image_open And video_file_open = False Then

                            Call getEXIFData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
                            strVideoTextTime = strVideoTime

                        End If

                        ClearSpatial(btn.Name, intNumHabitatButtons, strHabitatButtonNames, dictHabitatFieldValues, strHabitatButtonCodeNames, textboxes)
                        strSpeciesCode = "NULL"
                        strSpeciesCount = "NULL"
                        strSide = "NULL"
                        strRange = "NULL"
                        strLength = "NULL"
                        strHeight = "NULL"
                        strWidth = "NULL"
                        strAbundance = "NULL"
                        strIdConfidence = "NULL"

                        query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, "888", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                        'Debug.WriteLine(query)
                        Dim numrows As Integer
                        Dim oComm As OleDbCommand
                        oComm = New OleDbCommand(query, conn)
                        numrows = oComm.ExecuteNonQuery()
                        fetch_data()
                        Exit Sub
                    End If

                    strHabitatButtonUserCodeChoice(i) = strValue
                    dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = strHabitatButtonUserCodeChoice(i)
                    dictTempHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = strHabitatButtonUserCodeChoice(i)
                    If Me.chkRepeatVariables.Checked = False Then
                        For j = 0 To intNumHabitatButtons - 1
                            If strHabitatButtonCodeNames(j).ToString <> strHabitatButtonCodeNames(i).ToString Then
                                dictHabitatFieldValues(strHabitatButtonCodeNames(j).ToString) = "-9999"
                            End If
                        Next
                    End If
                    strHabitatButtonUserNameChoice(i) = strValue
                Else


                    Dim sub_form As frmTableView = New frmTableView(strHabitatButtonTables(i), i, intNumHabitatButtons, strHabitatButtonNames, dictHabitatFieldValues, strHabitatButtonCodeNames, textboxes)
                    sub_form.Multiple = False
                    sub_form.ShowDialog()




                    Try
                        If sub_form.DataGridView1.SelectedRows.Count = 0 Then
                            If blCleared = True Then


                                ' If the image is open and the video is closed then get the picture information from the EXIF file
                                If image_open And video_file_open = False Then

                                    Call getEXIFData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
                                    strVideoTextTime = strVideoTime

                                End If

                                strSpeciesCode = "NULL"
                                strSpeciesCount = "NULL"
                                strSide = "NULL"
                                strRange = "NULL"
                                strLength = "NULL"
                                strHeight = "NULL"
                                strWidth = "NULL"
                                strAbundance = "NULL"
                                strIdConfidence = "NULL"

                                query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, "888", "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                                'Debug.WriteLine(query)
                                Dim numrows As Integer
                                Dim oComm As OleDbCommand
                                oComm = New OleDbCommand(query, conn)
                                numrows = oComm.ExecuteNonQuery()
                                fetch_data()

                            End If
                            blCleared = False

                            Exit Sub
                        End If
                        'Console.WriteLine(DataGridView1.SelectedRows(0).Cells(0).Value)
                        strCode = sub_form.DataGridView1.SelectedRows(0).Cells(0).Value & ""
                        strHabitatButtonUserCodeChoice(i) = strCode
                        ' Depending on which button is selected, define the applicable spatial variable.
                        ' The other varaibles are cleared to prevent subsequent records being created from
                        ' having repeated values if the repeat check box is off.
                        dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = strHabitatButtonUserCodeChoice(i)
                        dictTempHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = strHabitatButtonUserCodeChoice(i)
                        If Me.chkRepeatVariables.Checked = False Then
                            For j = 0 To intNumHabitatButtons - 1
                                If strHabitatButtonCodeNames(j).ToString <> strHabitatButtonCodeNames(i).ToString Then
                                    dictHabitatFieldValues(strHabitatButtonCodeNames(j).ToString) = "-9999"
                                End If
                            Next
                        End If

                        strName = sub_form.DataGridView1.SelectedRows(0).Cells(1).Value & ""

                        If strName.Length = 0 Then
                            strName = strCode
                        End If
                        strHabitatButtonUserNameChoice(i) = strName


                    Catch ex As Exception
                        If ex.Message.StartsWith("Syntax") Then
                            MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
                        Else
                            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                        End If

                    End Try
                End If
                Dim newFont As Font
                Dim _fontfamily As FontFamily
                _fontfamily = New FontFamily(Me.ButtonFont)
                textboxes(i).Text = strHabitatButtonUserNameChoice(i)
                textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                textboxes(i).BackColor = Color.LightGray
                textboxes(i).ForeColor = Color.LimeGreen
                textboxes(i).TextAlign = HorizontalAlignment.Center
                ' If the image is open and the video is closed then get the picture information from the EXIF file
                If image_open And video_file_open = False Then

                    Call getEXIFData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
                    strVideoTextTime = strVideoTime

                End If

                If tc <> NULL_STRING Then

                    ' Insert new record in database
                    Dim numrows As Integer


                    strSpeciesCode = "NULL"
                    strSpeciesCount = "NULL"
                    strSide = "NULL"
                    strRange = "NULL"
                    strLength = "NULL"
                    strHeight = "NULL"
                    strWidth = "NULL"
                    strAbundance = "NULL"
                    strIdConfidence = "NULL"

                    'If transect_date = "" Then
                    query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, intHabitatButtonCodes(i), "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                    Dim oComm As New OleDbCommand(query, conn)
                    numrows = oComm.ExecuteNonQuery()
                    fetch_data()

                    If blVideoWasPlaying = True Then
                        playVideo()
                        blVideoWasPlaying = False
                    End If
                Else
                    MessageBox.Show("There is no GPS data being recieved at this time, therefore the record was not entered into the database", "No GPS Data Recieved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            End If
        Next
        If Not myFormLibrary.frmImage Is Nothing Then
            myFormLibrary.frmImage.Focus()
        End If
        Me.ScreenCaptureName = ""
    End Sub


    Public Sub fillHabitatFieldsCollection()

        colTableFields = Nothing
        colTableFields = New Collection

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand("select * from " & DB_DATA_TABLE, conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, DB_DATA_TABLE)
        Dim dc As DataColumn
        Dim d As DataTable
        d = sub_data_set.Tables(0)

        Dim i As Integer

        For i = 0 To d.Columns.Count - 1
            dc = d.Columns.Item(i)

            If dc.ColumnName = "TimeCode" Then
                colTableFields.Add("Format(TimeCode, 'hh:mm:ss') as TimeCode")
            ElseIf dc.ColumnName = "ReviewedDate" Then
                colTableFields.Add("Format(ReviewedDate, 'm/dd/yyyy') as ReviewDate")
            ElseIf dc.ColumnName = "ReviewedTime" Then
                colTableFields.Add("Format(ReviewedTime, 'hh:mm:ss') as ReviewTime")
            ElseIf dc.ColumnName = "ElapsedTime" Then
                colTableFields.Add("Format(ElapsedTime, 'hh:mm:ss') as ElapsedTime")
            Else
                colTableFields.Add(dc.ColumnName)
            End If
        Next


    End Sub

#End Region

#Region "Transect Variable Functions"

    Public Sub fillTransectVariableButtonPanel()
        If dictTransectFieldValues Is Nothing Then
            dictTransectFieldValues = New Dictionary(Of String, String)
        Else
            dictTransectFieldValues = Nothing
            dictTransectFieldValues = New Dictionary(Of String, String)
        End If

        If Me.pnlTransectData.Controls.Count <> 0 Then

            Dim ctl As Control

            For Each ctl In pnlTransectData.Controls
                If ctl.Name <> "lblTransectData" And ctl.Name <> "cmdDefineAllTransectVariables" Then
                    pnlTransectData.Controls.Remove(ctl)
                End If
            Next

        End If


        Dim dsTransect As DataSet = New DataSet()
        Dim commandTransect As OleDbCommand = New OleDbCommand("select * from " & DB_TRANSECT_BUTTONS_TABLE & " ORDER BY DrawingOrder;", conn)
        Dim adaptCommand As OleDbDataAdapter = New OleDbDataAdapter(commandTransect)
        adaptCommand.Fill(dsTransect, DB_TRANSECT_BUTTONS_TABLE)
        Dim r As DataRow
        Dim d As DataTable
        d = dsTransect.Tables(0)
        intNumTransectButtons = d.Rows.Count
        ReDim Transect_Buttons(intNumTransectButtons)
        ReDim Transect_Textboxes(intNumTransectButtons)
        ReDim strTransectButtonNames(intNumTransectButtons)
        ReDim intTransectButtonCodes(intNumTransectButtons)
        ReDim strTransectButtonTables(intNumTransectButtons)
        ReDim strTransectButtonCodeNames(intNumTransectButtons)
        ReDim strTransectButtonUserCodeChoice(intNumTransectButtons)
        ReDim strTransectButtonUserNameChoice(intNumTransectButtons)
        ReDim strTransectButtonColors(intNumTransectButtons)
        Dim h As Integer = pnlTransectData.Height
        Dim w As Integer = pnlTransectData.Width
        Dim i As Integer = 0
        Dim sizex As Integer = Me.ButtonWidth
        Dim sizey As Integer = Me.ButtonHeight
        Dim gap As Integer = 5

        Dim intAdd As Integer = 0
        Dim intMultiply As Integer = 0

        For Each r In d.Rows
            strTransectButtonNames(i) = New String(r.Item(1).ToString())
            strTransectButtonTables(i) = New String(r.Item(2).ToString())
            intTransectButtonCodes(i) = r.Item(3)
            strTransectButtonCodeNames(i) = New String(r.Item(4).ToString())

            ' Fill dictionary values with button code names and populate with empty strings
            dictTransectFieldValues.Add(strTransectButtonCodeNames(i).ToString, -9999)
            strTransectButtonColors(i) = New String(r.Item(5).ToString())

            Transect_Buttons(i) = New Button()
            Transect_Textboxes(i) = New TextBox()
            Transect_Buttons(i).Name = strTransectButtonNames(i)
            Dim colConvert As ColorConverter = New ColorConverter()
            Try
                Transect_Buttons(i).ForeColor = colConvert.ConvertFromString(strTransectButtonColors(i))
            Catch ex As Exception
                Transect_Buttons(i).ForeColor = Color.Black
            End Try

            Dim newFont As Font
            Dim _fontfamily As FontFamily
            _fontfamily = New FontFamily(Me.ButtonFont)
            If _fontfamily.IsStyleAvailable(FontStyle.Regular) Then
                newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Regular)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Bold) Then
                newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Italic) Then
                newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Italic)
            End If

            Transect_Buttons(i).Font = newFont

            Transect_Buttons(i).Text = strTransectButtonNames(i)
            Transect_Buttons(i).Size = New Size(sizex, sizey)
            Transect_Textboxes(i).Size = New Size(sizex, sizey / 2)
            Transect_Textboxes(i).ReadOnly = True
            Dim cellsizex = sizex + gap
            Dim cellsizey = (1.5 * sizey) + gap

            Transect_Buttons(i).Location = New System.Drawing.Point(gap + (cellsizex * intMultiply), 70 + gap + (cellsizey * (i - intAdd)))
            Transect_Textboxes(i).Location = New System.Drawing.Point(gap + (cellsizex * intMultiply), (cellsizey * (i - intAdd)) + (sizey + 70 + gap))


            Transect_Textboxes(i).Text = "No " & strTransectButtonNames(i)

            Transect_Textboxes(i).Name = "txt" & Replace(strTransectButtonNames(i), "%", "Percent")

            Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"

            Dim txtName As String = Transect_Textboxes(i).Name
            Dim Letter As String
            For x As Integer = 0 To Transect_Textboxes(i).Name.Length - 1
                Letter = Transect_Textboxes(i).Name.Substring(x, 1).ToUpper
                If strCharactersAllowed.Contains(Letter) = False Then
                    txtName = txtName.Replace(Letter, String.Empty)
                End If
            Next
            Transect_Textboxes(i).Name = txtName

            Transect_Textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
            Transect_Textboxes(i).BackColor = Color.LightGray
            Transect_Textboxes(i).ForeColor = Color.Red
            Transect_Textboxes(i).TextAlign = HorizontalAlignment.Center
            Transect_Textboxes(i).ReadOnly = True
            AddHandler Transect_Buttons(i).Click, AddressOf TransectVariableButtonHandler

            pnlTransectData.Controls.Add(Transect_Buttons(i))
            pnlTransectData.Controls.Add(Transect_Textboxes(i))

            If i Mod 5 = 4 Then
                intAdd += 5
                intMultiply += 1
            End If

            i = i + 1
        Next
        Me.cmdDefineAllTransectVariables.Visible = True
    End Sub


    Private Sub TransectVariableButtonHandler(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim btn As Button = sender
        Dim i As Integer

        ' Give the user the ability to cear a substrate type or percent by ctrl clicking the button
        If My.Computer.Keyboard.CtrlKeyDown Then
            For i = 0 To intNumTransectButtons - 1
                If btn.Name = strTransectButtonNames(i) Then
                    ' Depending on the button selected, set the substrate variable to non value.
                    dictHabitatFieldValues.Item(strTransectButtonCodeNames(i).ToString) = -9999
                    Dim _fontfamily As FontFamily
                    _fontfamily = New FontFamily(Me.ButtonFont)
                    'Set the button and text back to non value state. 
                    Transect_Textboxes(i).Text = "No " & strTransectButtonNames(i)
                    Transect_Textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                    Transect_Textboxes(i).BackColor = Color.LightGray
                    Transect_Textboxes(i).ForeColor = Color.Red
                    Transect_Textboxes(i).TextAlign = HorizontalAlignment.Center
                    Transect_Textboxes(i).ReadOnly = True
                End If
            Next
            Exit Sub
        End If


        Dim tc As String = VIDEO_TIME_LABEL

        Dim strX As String = "NULL"
        Dim strY As String = "NULL"
        Dim strZ As String = "NULL"

        Dim query As String = ""


        ' ======================================Code by Xida Chen (begin)===========================================
        'If they are using the video control then get the time from there.
        ' The time code is set to be VIDEO_TIME_LABEL initially.
        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
        ' do the following only when the video is open:
        ' pause stream and get the time code
        ' If the video is not open, then we cannot pause the
        ' video stream, and there is no need to get the TimeCode.
        If video_file_open Then
            If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.IsPlaying Then
                If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.IsPlaying Then
                    blVideoWasPlaying = True
                Else
                    blVideoWasPlaying = False
                End If
                pauseVideo()
            End If
            tc = getTimeCode()
            strVideoTime = GetVideoTime(tc, strVideoDecimalTime)

        End If

        Dim strCode As String = ""
        Dim strName As String = ""
        Dim blAquiredFix As Boolean = False
        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.

            blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If

        End If
        strVideoTextTime = strVideoTime
        ' If the image is open and the video is closed then get the picture information from the EXIF file
        'If image_open And video_file_open = False Then

        '    Call getEXIFData(strVideoTime)

        'End If
        ' ======================================Code by Xida Chen (end)===========================================

        For i = 0 To intNumTransectButtons - 1
            If btn.Name = strTransectButtonNames(i) Then
                Dim _fontfamily As FontFamily
                If strTransectButtonTables(i) = "UserEntered" Then
                    Dim strValue As String
                    myFormLibrary.frmAddValue = New frmAddValue(dictTransectFieldValues(strTransectButtonCodeNames(i).ToString))
                    myFormLibrary.frmAddValue.lblExpression.Text = "Please enter a value for " & btn.Text & ":"
                    myFormLibrary.frmAddValue.Text = btn.Text & " Entry"
                    myFormLibrary.frmAddValue.ShowDialog()

                    strValue = myFormLibrary.frmAddValue.strValue
                    myFormLibrary.frmAddValue.Close()
                    myFormLibrary.frmAddValue = Nothing

                    strTransectButtonUserCodeChoice(i) = strValue
                    dictTransectFieldValues(strTransectButtonCodeNames(i).ToString) = strTransectButtonUserCodeChoice(i)
                    strTransectButtonUserNameChoice(i) = strValue
                    If strValue = "-9999" Then
                        ClearSpatial(strTransectButtonNames(i), intNumTransectButtons, strTransectButtonNames, dictTransectFieldValues, strTransectButtonCodeNames, Transect_Textboxes)
                    Else
                        'Dim _fontfamily As FontFamily
                        _fontfamily = New FontFamily(Me.ButtonFont)
                        Transect_Textboxes(i).Text = strTransectButtonUserNameChoice(i)
                        Transect_Textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                        Transect_Textboxes(i).BackColor = Color.LightGray
                        Transect_Textboxes(i).ForeColor = Color.LimeGreen
                        Transect_Textboxes(i).TextAlign = HorizontalAlignment.Center
                    End If
                Else
                    Dim sub_form As frmTableView = New frmTableView(strTransectButtonTables(i), i, intNumTransectButtons, strTransectButtonNames, dictTransectFieldValues, strTransectButtonCodeNames, Transect_Textboxes)
                    sub_form.cmdScreenCapture.Visible = False
                    sub_form.Multiple = False
                    sub_form.ShowDialog()

                    Try
                        If sub_form.DataGridView1.SelectedRows.Count = 0 Then
                            blCleared = False
                            Me.strComment = ""
                            Exit Sub
                        End If
                        'Console.WriteLine(DataGridView1.SelectedRows(0).Cells(0).Value)
                        strCode = sub_form.DataGridView1.SelectedRows(0).Cells(0).Value & ""
                        strTransectButtonUserCodeChoice(i) = strCode

                        ' Depending on which button is selected, define the applicable spatial variable.
                        ' The other varaibles are cleared to prevent subsequent records being created from
                        ' having repeated values if the repeat check box is off.
                        dictTransectFieldValues(strTransectButtonCodeNames(i).ToString) = strTransectButtonUserCodeChoice(i)



                        If Me.strComment <> "" Then

                            strSpeciesCode = "NULL"
                            strSpeciesCount = "NULL"
                            strSide = "NULL"
                            strRange = "NULL"
                            strLength = "NULL"
                            strHeight = "NULL"
                            strWidth = "NULL"
                            strAbundance = "NULL"
                            strIdConfidence = "NULL"

                            query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, intTransectButtonCodes(i), "NULL", strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                            'Debug.WriteLine(query)
                            Dim numrows As Integer
                            Dim oComm As OleDbCommand
                            oComm = New OleDbCommand(query, conn)
                            numrows = oComm.ExecuteNonQuery()
                            fetch_data()

                        End If

                        Me.strComment = ""

                        strName = sub_form.DataGridView1.SelectedRows(0).Cells(1).Value & ""

                        If strName.Length = 0 Then
                            strName = strCode
                        End If
                        strTransectButtonUserNameChoice(i) = strName
                        'Dim _fontfamily As FontFamily
                        _fontfamily = New FontFamily(Me.ButtonFont)
                        Transect_Textboxes(i).Text = strTransectButtonUserNameChoice(i)
                        Transect_Textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                        Transect_Textboxes(i).BackColor = Color.LightGray
                        Transect_Textboxes(i).ForeColor = Color.LimeGreen
                        Transect_Textboxes(i).TextAlign = HorizontalAlignment.Center
                    Catch ex As Exception
                        If ex.Message.StartsWith("Syntax") Then
                            MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
                        Else
                            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                        End If
                    End Try
                End If
                ''Dim _fontfamily As FontFamily
                '_fontfamily = New FontFamily(Me.ButtonFont)
                'Transect_Textboxes(i).Text = strTransectButtonUserNameChoice(i)
                'Transect_Textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                'Transect_Textboxes(i).BackColor = Color.LightGray
                'Transect_Textboxes(i).ForeColor = Color.LimeGreen
                'Transect_Textboxes(i).TextAlign = HorizontalAlignment.Center

                If blVideoWasPlaying = True Then
                    playVideo()
                    blVideoWasPlaying = False
                End If


            End If
        Next
        If Not myFormLibrary.frmImage Is Nothing Then
            myFormLibrary.frmImage.Focus()
        End If
        Me.ScreenCaptureName = ""
    End Sub

#End Region

#Region "Species Variable Functions"

    ' ==========================================================================================================
    ' Name: fill_speciesvariable_button_panel()
    ' Description:  Once both a database and a video file are opened, prepare panel2
    ' 1.) Load one button for each record in the videominer_species_buttons table into Panel2.
    ' 2.) Set the button click event to call SpeciesVariableButtonHandler()
    ' ==========================================================================================================
    Public Sub fillSpeciesVariableButtonPanel()

        Dim sub_data_set As DataSet = New DataSet()
        Dim sub_db_command As OleDbCommand = New OleDbCommand("select * from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", conn)
        Dim sub_data_adapter As OleDbDataAdapter = New OleDbDataAdapter(sub_db_command)
        sub_data_adapter.Fill(sub_data_set, DB_SPECIES_BUTTONS_TABLE)
        Dim r As DataRow
        Dim d As DataTable
        d = sub_data_set.Tables(0)
        intNumSpeciesButtons = d.Rows.Count

        ReDim speciesButtons(intNumSpeciesButtons)
        ReDim strSpeciesButtonNames(intNumSpeciesButtons)
        ReDim strSpeciesButtonCodes(intNumSpeciesButtons)
        ReDim strSpeciesButtonCodeNames(intNumSpeciesButtons)
        ReDim intSpeciesButtonUserCodeChoice(intNumSpeciesButtons)
        ReDim strSpeciesButtonUserNameChoice(intNumSpeciesButtons)
        ReDim strSpeciesButtonColors(intNumSpeciesButtons)
        Dim h As Integer = pnlSpeciesData.Height
        Dim w As Integer = pnlSpeciesData.Width
        Dim i As Integer = 0
        Dim sizex As Integer = Me.ButtonWidth
        Dim sizey As Integer = Me.ButtonHeight
        Dim gap As Integer = 5

        Dim intAdd As Integer = 0
        Dim intMultiply As Integer = 0
        Dim strButtonText As String = ""

        'Dim intColumnCount As Integer
        'Dim intCountPerColumn As Integer
        Dim intCountPerRow As Integer
        Dim cellsizex = sizex + gap
        Dim cellsizey = sizey + gap

        'intColumnCount = 3
        'intCountPerColumn = (intNumSpeciesButtons / intColumnCount) + 1

        intCountPerRow = Math.Floor(w / (cellsizex))


        For Each r In d.Rows

            strSpeciesButtonNames(i) = New String(r.Item(1).ToString())
            strSpeciesButtonCodes(i) = New String(r.Item(2).ToString())
            strSpeciesButtonCodeNames(i) = New String(r.Item(4).ToString())
            strSpeciesButtonColors(i) = New String(r.Item(5).ToString())
            speciesButtons(i) = New Button()
            speciesButtons(i).Name = strSpeciesButtonNames(i)
            speciesButtons(i).TabStop = False
            Dim colConvert As ColorConverter = New ColorConverter()
            Try
                Dim c As Color = DirectCast(colConvert.ConvertFromString(strSpeciesButtonColors(i)), Color)
                speciesButtons(i).ForeColor = c
            Catch ex As Exception
                speciesButtons(i).ForeColor = Color.Black
            End Try
            Dim newFont As Font
            Dim _fontfamily As FontFamily
            _fontfamily = New FontFamily(Me.ButtonFont)
            If _fontfamily.IsStyleAvailable(FontStyle.Regular) Then
                newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Regular)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Bold) Then
                newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
            ElseIf _fontfamily.IsStyleAvailable(FontStyle.Italic) Then
                newFont = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Italic)
            End If

            speciesButtons(i).Font = newFont
            If r.Item("KeyboardShortcut").ToString <> "" Then
                strButtonText = strSpeciesButtonNames(i) & " (" & r.Item("KeyboardShortcut") & ")"
            Else
                strButtonText = strSpeciesButtonNames(i)
            End If

            'If i <= 11 Then
            '    strButtonText = strSpeciesButtonNames(i) & " (F" & i + 1 & ")"
            'Else
            '    
            'End If

            speciesButtons(i).Text = strButtonText
            speciesButtons(i).Size = New Size(sizex, sizey)

            'speciesButtons(i).Location = New System.Drawing.Point(gap + (cellsizex * intMultiply), 20 + gap + (cellsizey * (i - intAdd)))
            speciesButtons(i).Location = New System.Drawing.Point(gap + (cellsizex * (i - intAdd)), 10 + gap + (cellsizey * intMultiply))

            AddHandler speciesButtons(i).Click, AddressOf SpeciesVariableButtonHandler
            pnlSpeciesData.Controls.Add(speciesButtons(i))

            If i Mod intCountPerRow = intCountPerRow - 1 Then
                intAdd += intCountPerRow
                intMultiply += 1
            End If

            i = i + 1
        Next
    End Sub


    ' ==========================================================================================================
    ' Name: SpeciesVariableButtonHandler
    ' Description: Called when a species button from Panel2 is clicked. The button click event is dependant on the 
    '              Radio button selection for detailed vs quick entry. 
    '
    '     If the detailed entry radio button radDetailedEntry is selected:
    ' 1.) Open the form SpeciesEventForm and prompt the user to enter information about the species sighting 
    '     in the video such as Range, Height, count etc which will be added to the database in step 2.
    ' 2.) Insert a record into the database table "data" with variables for the fields: id,TimeCode,DataCode,transect,
    '     OnBottom,SpeciesID,SpeciesCount,Side,Length,range,IDConfidence,Abundance,height,width
    '
    '     If the quick entry radio button radQuickEntry is selected:
    ' 1.) Insert a record into the database table "data" with variables for the fields: id,TimeCode,DataCode,transect,
    '     OnBottom,SpeciesID,SpeciesCount,Side,Length,range,IDConfidence,Abundance,height,width.
    '       - Values of 0(zero) will be entered into the table for values that would have been defined by the user in
    '         the SpeciesEventForm if they had selected detailed entry.
    ' ==========================================================================================================
    ' ==========================================================================================================
    Public Sub SpeciesVariableButtonHandler(ByVal sender As Object, ByVal e As EventArgs)
        If blHandled = True Then
            blHandled = False
            Exit Sub
        End If

        Dim btn As Button = sender
        Dim i As Integer
        Dim tc As String = VIDEO_TIME_LABEL

        Dim strX As String = "NULL"
        Dim strY As String = "NULL"
        Dim strZ As String = "NULL"

        Dim query As String = ""

        ' The GPRMC NMEA String does not contain elevation values. Enter null into database
        ' if GPRMC is the chosen string type.
        'Dim regKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\VideoMiner")
        'Dim strGPSStringType As String = regKey.GetValue("GPSStringType")

        ' ======================================Code by Xida Chen (begin)===========================================
        ' If they are using the video control then get the time from there.
        ' The time code is set to be VIDEO_TIME_LABEL initially.
        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
        ' do the following only when the video is open:
        ' pause stream and get the time code
        ' If the video is not open, then we cannot pause the
        ' video stream, and there is no need to get the TimeCode.
        If video_file_open Then
            If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.IsPlaying Then
                pauseVideo()
            End If
            tc = getTimeCode()
            strVideoTime = GetVideoTime(tc, strVideoDecimalTime)
        ElseIf booUseExternalVideo Then
            strVideoTime = GetVideoTime(0, strVideoDecimalTime)
        End If

        ' ======================================Code by Xida Chen (end)===========================================

        Dim numrows As Integer
        Dim oComm As OleDbCommand

        Dim strWidth As String = ""
        Dim blAquiredFix As Boolean = False
        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.

            blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If
        strVideoTextTime = strVideoTime

        If blRareSpecies = False Then

            For i = 0 To intNumSpeciesButtons - 1
                If btn.Name = strSpeciesButtonNames(i) Then
                    'Query Species name based on button text column from data table
                    Dim strBtnTxtQuery As String
                    strBtnTxtQuery = "SELECT ButtonText, DataCode FROM videominer_species_buttons WHERE " & _
                                    "ButtonCode = " & SingleQuote(strSpeciesButtonCodes(i))

                    Dim cmd As OleDbCommand = New OleDbCommand(strBtnTxtQuery, conn)
                    Dim aDataReader As OleDb.OleDbDataReader
                    aDataReader = cmd.ExecuteReader

                    Dim strSpecies_Name As String
                    aDataReader.Read()
                    strSpecies_Name = aDataReader("ButtonText")
                    intSpeciesButtonUserCodeChoice(i) = aDataReader("DataCode")


                    If Me.radDetailedEntry.Checked Then
                        Call GetSettingsFromFile()
                        myFormLibrary.frmSpeciesEvent = New frmSpeciesEvent
                        myFormLibrary.frmSpeciesEvent.Location = New System.Drawing.Point(btn.Location.X, btn.Location.Y)
                        myFormLibrary.frmSpeciesEvent.SpeciesName = strSpeciesButtonNames(i)
                        myFormLibrary.frmSpeciesEvent.ShowDialog()

                        If blSpeciesValuesSet Then
                            Try


                                ' If an image is open and the video is closed then get the picture information from the EXIF file
                                If image_open And video_file_open = False Then

                                    Call getEXIFData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
                                    strVideoTextTime = strVideoTime

                                End If
                                strSpeciesButtonUserNameChoice(i) = 666

                                If tc <> NULL_STRING Then
                                    ' Insert new record in database

                                    If Me.SpeciesWidth Is Nothing Then
                                        strWidth = "Null"
                                    Else
                                        strWidth = Me.SpeciesWidth
                                    End If


                                    strSpeciesCode = Me.SpeciesCode
                                    strSpeciesCount = Me.Count
                                    If Me.Side = "0" Then
                                        strSide = ""
                                    Else
                                        strSide = Me.Side
                                    End If
                                    strRange = Me.Range
                                    strLength = Me.Length
                                    strHeight = Me.SpeciesHeight
                                    strWidth = Me.SpeciesWidth
                                    strAbundance = Me.Abundance
                                    strIdConfidence = Me.IDConfidence
                                    strComment = Me.Comments

                                    'If transect_date = "" Then
                                    query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, intSpeciesButtonUserCodeChoice(i), strSpecies_Name, strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)
                                    Me.ScreenCaptureName = ""
                                    oComm = New OleDbCommand(query, conn)
                                    numrows = oComm.ExecuteNonQuery()
                                    fetch_data()
                                Else
                                    MessageBox.Show("There is no GPS data being recieved at this time, therefore the record was not entered into the database", "No GPS Data Recieved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                            Catch ex As Exception
                                If ex.Message.StartsWith("Syntax") Then
                                    MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
                                Else
                                    MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                                End If
                            End Try
                        End If

                    ElseIf radQuickEntry.Checked Then 'quick entry
                        'intSpeciesButtonUserCodeChoice(i) = aDataReader("DataCode")
                        Try


                            ' If an image is open and the video is closed then get the picture information from the EXIF file
                            If image_open And video_file_open = False Then

                                Call getEXIFData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
                                strVideoTextTime = strVideoTime

                            End If
                            strSpeciesButtonUserNameChoice(i) = 666

                            strSpeciesCode = strSpeciesButtonCodes(i)
                            strSpeciesCount = strQuickEntryCount
                            strSide = "NULL"
                            strRange = "NULL"
                            strLength = "NULL"
                            strHeight = "NULL"
                            strWidth = "NULL"
                            strAbundance = "NULL"
                            strIdConfidence = "NULL"
                            strComment = "NULL"

                            'If transect_date = "" Then
                            query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, intSpeciesButtonUserCodeChoice(i), strSpecies_Name, strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                            oComm = New OleDbCommand(query, conn)
                            numrows = oComm.ExecuteNonQuery()
                            fetch_data()
                        Catch ex As Exception
                            If ex.Message.StartsWith("Syntax") Then
                                MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
                            Else
                                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                            End If
                        End Try
                    ElseIf radAbundanceEntry.Checked Then
                        Try
                            myFormLibrary.frmAbundanceTableView = New frmAbundanceTableView
                            myFormLibrary.frmAbundanceTableView.ShowDialog()

                            ' If an image is open and the video is closed then get the picture information from the EXIF file
                            If image_open And video_file_open = False Then

                                Call getEXIFData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
                                strVideoTextTime = strVideoTime

                            End If
                            If myFormLibrary.frmAbundanceTableView.Canceled = False Then
                                If myFormLibrary.frmAbundanceTableView.grdAbundance.SelectedRows.Count <> 0 Then

                                    strSpeciesButtonUserNameChoice(i) = 666

                                    strSpeciesCode = strSpeciesButtonCodes(i)
                                    strSpeciesCount = "NULL"
                                    strSide = "NULL"
                                    strRange = "NULL"
                                    strLength = "NULL"
                                    strHeight = "NULL"
                                    strWidth = "NULL"
                                    strAbundance = myFormLibrary.frmAbundanceTableView.grdAbundance.SelectedRows(0).Cells(0).Value
                                    strIdConfidence = "NULL"
                                    If myFormLibrary.frmAbundanceTableView.txtCommentBox.Text <> "" Or myFormLibrary.frmAbundanceTableView.txtCommentBox.Text <> "Comment" Then
                                        strComment = myFormLibrary.frmAbundanceTableView.txtCommentBox.Text
                                    Else
                                        strComment = "NULL"
                                    End If

                                    'If transect_date = "" Then
                                    query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, intSpeciesButtonUserCodeChoice(i), strSpecies_Name, strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                                    oComm = New OleDbCommand(query, conn)
                                    numrows = oComm.ExecuteNonQuery()
                                    fetch_data()
                                    myFormLibrary.frmAbundanceTableView.Close()
                                End If
                            End If
                        Catch ex As Exception
                            If ex.Message.StartsWith("Syntax") Then
                                MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
                            Else
                                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                            End If
                        End Try
                    End If
                End If
            Next
        Else
            If booUseGPSTimeCodes Then
                blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
                If Not blAquiredFix Then
                    Exit Sub
                End If
            End If
            strVideoTextTime = strVideoTime
            Call GetSettingsFromFile()
            myFormLibrary.frmSpeciesEvent = New frmSpeciesEvent
            myFormLibrary.frmSpeciesEvent.Location = New System.Drawing.Point(btn.Location.X, btn.Location.Y)
            myFormLibrary.frmSpeciesEvent.SpeciesName = Me.SpeciesName
            myFormLibrary.frmSpeciesEvent.SpeciesCode = Me.SpeciesCode
            myFormLibrary.frmSpeciesEvent.ShowDialog()

            If blSpeciesCancelled = True Then
                blSpeciesCancelled = False
                Exit Sub
            End If

            If blSpeciesValuesSet Then
                Try
                    ' If an image is open and the video is closed then get the picture information from the EXIF file
                    If image_open And video_file_open = False Then

                        Call getEXIFData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
                        strVideoTextTime = strVideoTime

                    End If
                    strSpeciesButtonUserNameChoice(i) = 666

                    If tc <> NULL_STRING Then
                        ' Insert new record in database

                        If Me.SpeciesWidth Is Nothing Then
                            strWidth = "Null"
                        Else
                            strWidth = Me.SpeciesWidth
                        End If


                        strSpeciesCount = Me.Count
                        If Me.Side = "0" Then
                            strSide = ""
                        Else
                            strSide = Me.Side
                        End If
                        strRange = Me.Range
                        strLength = Me.Length
                        strHeight = Me.SpeciesHeight
                        strWidth = Me.SpeciesWidth
                        strAbundance = Me.Abundance
                        strIdConfidence = Me.IDConfidence
                        strComment = Me.Comments

                        'If transect_date = "" Then
                        query = createInsertQuery(transect_date, transect_name, strVideoTime, strVideoTextTime, strVideoDecimalTime, "4", Me.SpeciesName, strX, strY, strZ, Me.SpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

                        oComm = New OleDbCommand(query, conn)
                        numrows = oComm.ExecuteNonQuery()
                        fetch_data()
                    Else
                        MessageBox.Show("There is no GPS data being recieved at this time, therefore the record was not entered into the database", "No GPS Data Recieved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Catch ex As Exception
                    If ex.Message.StartsWith("Syntax") Then
                        MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
                    Else
                        MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                    End If
                End Try
            End If

        End If
        If Not myFormLibrary.frmImage Is Nothing Then
            myFormLibrary.frmImage.Focus()
        End If
        If Not myFormLibrary.frmVideoPlayer Is Nothing Then
            If Me.chkResumeVideo.Checked Then
                playVideo()
            End If
        End If
    End Sub

    Public Sub GetSettingsFromFile()
        Dim path As String
        Dim strConfigFile As String

        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
        If (path.StartsWith("file:\")) Then
            path = path.Substring(6)    ' Remove unnecessary substring
        End If

        strConfigFile = strConfigFilePath & "\VideoMinerConfigurationDetails.xml"

        Me.RangeChecked = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Range/Displayed")
        Me.IDConfidenceChecked = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/IDConfidence/Displayed")
        Me.AbundanceChecked = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Abundance/Displayed")
        Me.CountChecked = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Count/Displayed")
        Me.HeightChecked = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Height/Displayed")
        Me.WidthChecked = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Width/Displayed")
        Me.LengthChecked = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Length/Displayed")
        Me.CommentsChecked = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Comments/Displayed")

        Me.Range = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Range/DefaultValue")
        Me.Side = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Side/DefaultValue")
        Me.IDConfidence = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/IDConfidence/DefaultValue")
        Me.Abundance = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Abundance/DefaultValue")
        Me.Count = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Count/DefaultValue")
        Me.SpeciesHeight = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Height/DefaultValue")
        Me.SpeciesWidth = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Width/DefaultValue")
        Me.Length = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Length/DefaultValue")
        Me.Comments = GetConfiguration(strConfigFile, "VideoMinerConfigurationDetails/DetailedSpeciesEventConfiguration/Comments/DefaultValue")



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

#End Region

    Private Sub txtDisplayRecords_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisplayRecords.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(Keys.Return) Then
            Call Me.cmdRefreshDatabase_Click(sender, e)
        Else
            Call modGlobals.numericTextboxValidation(e)
        End If

    End Sub

    Private Sub txtPlaySeconds_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlaySeconds.KeyPress
        Call modGlobals.numericTextboxValidation(e)
    End Sub

    Private Sub cmdRefreshDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefreshDatabase.Click

        If Me.txtDisplayRecords.Text = "" Then
            Me.txtDisplayRecords.Text = intDefaultNumberDisplayRecords
        End If

        intNumberDisplayRecords = CInt(Me.txtDisplayRecords.Text)

        fetch_data()

    End Sub

    Private Sub txtDisplayRecords_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisplayRecords.LostFocus
        If Me.txtDisplayRecords.Text = "" Or Me.txtDisplayRecords.Text = 0 Then
            Me.txtDisplayRecords.Text = intNumberDisplayRecords
        End If
    End Sub

    Private Sub txtQuickSpeciesCount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuickSpeciesCount.KeyPress
        Call modGlobals.numericTextboxValidation(e)
    End Sub

    Private Sub txtQuickSpeciesCount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuickSpeciesCount.LostFocus
        If Me.txtQuickSpeciesCount.Text = "0" Then
            Me.txtDisplayRecords.Text = ""
        End If

        strQuickEntryCount = Me.txtQuickSpeciesCount.Text
    End Sub

    Private Sub radQuickEntry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radQuickEntry.CheckedChanged
        If Me.radQuickEntry.Checked = True Then
            Me.lblQuickSpeciesCount.Visible = True
            Me.txtQuickSpeciesCount.Visible = True
        Else
            Me.lblQuickSpeciesCount.Visible = False
            Me.txtQuickSpeciesCount.Visible = False
        End If
    End Sub

    Private Sub cmdRareSpeciesLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRareSpeciesLookup.Click

        Try
            myFormLibrary.frmRareSpeciesLookup = New frmRareSpeciesLookup
            myFormLibrary.frmRareSpeciesLookup.ShowDialog()
        Catch ex As Exception

            myFormLibrary.frmRareSpeciesLookup.ShowDialog()
        End Try
    End Sub

    Private Sub KeyboardShortcutsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeyboardShortcutsToolStripMenuItem.Click
        myFormLibrary.frmKeyboardCommands = New frmKeyboardCommands
        myFormLibrary.frmKeyboardCommands.ShowDialog()
    End Sub

    Private Sub ConfigureHabitatButtonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureHabitatButtonToolStripMenuItem.Click
        strConfigureTable = DB_BUTTONS_TABLE
        myFormLibrary.frmConfigureButtons = New frmConfigureButtons
        myFormLibrary.frmConfigureButtons.cmdMoveToPanel.Text = "Move To TRANSECT DATA"
        myFormLibrary.frmConfigureButtons.ShowDialog()
    End Sub

    Private Sub ConfigureTransectButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureTransectButtonsToolStripMenuItem.Click
        strConfigureTable = DB_TRANSECT_BUTTONS_TABLE
        myFormLibrary.frmConfigureButtons = New frmConfigureButtons
        myFormLibrary.frmConfigureButtons.cmdMoveToPanel.Text = "Move To HABITAT DATA"
        myFormLibrary.frmConfigureButtons.ShowDialog()
    End Sub

    Public Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        Call stopVideo()
    End Sub

    Private Sub cmdIncreaseRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIncreaseRate.Click

        increaseRate()
        'If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.settings.isAvailable("rate") Then
        ' Call increaseRate()
        'Else
        'If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.isAvailable("FastForward") And myFormLibrary.frmVideoPlayer.plyrVideoPlayer.playState <> WMPLib.WMPPlayState.wmppsScanForward Then
        ' myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.fastForward()
        ' Me.LblRate.Text = "5.0 X"
        ' End If

        'End If


    End Sub

    Private Sub cmdDecreaseRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDecreaseRate.Click

        decreaseRate()
        'If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.settings.isAvailable("rate") Then
        ' Call decreaseRate()
        'Else
        'If myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.isAvailable("FastForward") And myFormLibrary.frmVideoPlayer.plyrVideoPlayer.playState = WMPLib.WMPPlayState.wmppsScanForward Then
        'myFormLibrary.frmVideoPlayer.plyrVideoPlayer.Ctlcontrols.play()
        'Me.LblRate.Text = "1.0 X"
        'End If
        'End If


    End Sub

    Private Sub mnuImageZoom25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageZoom25.Click

        Me.cboZoom.SelectedItem = "25%"

    End Sub

    Private Sub mnuImageZoom50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageZoom50.Click

        Me.cboZoom.SelectedItem = "50%"

    End Sub

    Private Sub mnuImageZoom75_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageZoom75.Click

        Me.cboZoom.SelectedItem = "75%"

    End Sub

    Private Sub mnuImageZoom100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageZoom100.Click

        Me.cboZoom.SelectedItem = "100%"

    End Sub

    Private Sub mnuImageZoom200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageZoom200.Click

        Me.cboZoom.SelectedItem = "200%"

    End Sub

    Private Sub NextImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextImageToolStripMenuItem.Click

        Call cmdNextImage_Click(sender, e)

    End Sub

    Private Sub PreviousImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousImageToolStripMenuItem.Click

        Call cmdPreviousImage_Click(sender, e)

    End Sub

    Private Sub CloseImageFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseImageFileToolStripMenuItem.Click

        myFormLibrary.frmImage.Close()

    End Sub

    Private Sub CloseVideoFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseVideoFileToolStripMenuItem.Click
        myFormLibrary.frmVideoPlayer.Close()
    End Sub

    Public Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        Call StepForward()
    End Sub

    Public Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        'Call StepBackward()
    End Sub

    'Private Sub chkResumeVideo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkResumeVideo.CheckedChanged
    '    If chkResumeVideo.Checked = True Then
    '        booResumeVideo = True
    '    Else
    '        booResumeVideo = False
    '    End If
    'End Sub

    Private Sub DataCodeAssignmentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataCodeAssignmentsToolStripMenuItem.Click
        myFormLibrary.frmDataCodes = New frmDataCodes
        myFormLibrary.frmDataCodes.ShowDialog()
    End Sub

    Private Sub DeviceControlToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeviceControl.Click
        myFormLibrary.frmDeviceControl = New frmDeviceControl
        myFormLibrary.frmDeviceControl.ShowDialog()
    End Sub

    Private Sub RelayConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelayConfigurationToolStripMenuItem.Click
        myFormLibrary.frmRelayConfiguration = New frmRelayConfiguration

        ' Transfer the relay configuration variables to the relay configuration form
        myFormLibrary.frmRelayConfiguration.ConfigurationSet = Me.ConfigurationSet
        myFormLibrary.frmRelayConfiguration.RelaySetup = Me.RelaySetup
        myFormLibrary.frmRelayConfiguration.ParallelCom = Me.ParallelCom
        myFormLibrary.frmRelayConfiguration.ParallelBaud = Me.ParallelBaud
        myFormLibrary.frmRelayConfiguration.PortOneCom = Me.PortOneCom
        myFormLibrary.frmRelayConfiguration.PortOneBaud = Me.PortOneBaud
        myFormLibrary.frmRelayConfiguration.PortTwoCom = Me.PortTwoCom
        myFormLibrary.frmRelayConfiguration.PortTwoBaud = Me.PortTwoBaud
        myFormLibrary.frmRelayConfiguration.DeviceOneRelayOne = Me.DeviceOneRelayOne
        myFormLibrary.frmRelayConfiguration.DeviceOneRelayTwo = Me.DeviceOneRelayTwo
        myFormLibrary.frmRelayConfiguration.DeviceOneRelayThree = Me.DeviceOneRelayThree
        myFormLibrary.frmRelayConfiguration.DeviceOneRelayFour = Me.DeviceOneRelayFour
        myFormLibrary.frmRelayConfiguration.DeviceTwoRelayOne = Me.DeviceTwoRelayOne
        myFormLibrary.frmRelayConfiguration.DeviceTwoRelayTwo = Me.DeviceTwoRelayTwo
        myFormLibrary.frmRelayConfiguration.DeviceTwoRelayThree = Me.DeviceTwoRelayThree
        myFormLibrary.frmRelayConfiguration.DeviceTwoRelayFour = Me.DeviceTwoRelayFour

        myFormLibrary.frmRelayConfiguration.ShowDialog()
    End Sub

    ' Handles data being received from the serial port
    Private Sub DataRecieved(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles aSerialPort.DataReceived
        'If Not myFormLibrary.frmGpsSettings Is Nothing Then
        ' Set the delegate for the invokation
        Dim del As myDelegate
        del = New myDelegate(AddressOf updateTextBox)

        Try
            myFormLibrary.frmVideoMiner.txtNMEA.Invoke(del)  ' Invoke the method to update the NMEA text box
        Catch ex As Exception

        End Try
        'End If
    End Sub

    ' Handles updating the NMEA text box
    Public Sub updateTextBox()

        Try
            strTimeDateSource = "GPS"
            intTimeSource = 4
            Dim blAquiredFix As Boolean = False
            Dim m_CurrentPoint As Point
            'If Me.txtNMEA.InvokeRequired Then
            'Dim d As New updateTextBoxCallback(AddressOf updateTextBox)
            'Me.BeginInvoke(d)
            'Else
            ' Read the data from the serial port
            'MsgBox(Me.txtNMEA.InvokeRequired)

            With myFormLibrary.frmVideoMiner.txtNMEA
                .Text &= aSerialPort.ReadExisting
                .WordWrap = False
                .ScrollToCaret()
            End With
            myFormLibrary.frmVideoMiner.searchingCounter = 0
            'MsgBox(myFormLibrary.frmVideoMiner.txtNMEA.Text)
            'aSerialPort.DiscardInBuffer()

            'If Not myFormLibrary.frmGpsSettings Is Nothing Then
            If Not myFormLibrary.frmGpsSettings Is Nothing Then
                myFormLibrary.frmGpsSettings.cmdConnection.Enabled = True
                myFormLibrary.frmGpsSettings.cmdConnection.Text = "Close GPS Connection"
            End If
            ' Create a new point object and populate it with the location from the NMEA string

            m_CurrentPoint = New Point
            With m_CurrentPoint
                .NMEA = myFormLibrary.frmVideoMiner.txtNMEA.Text
                blAquiredFix = .GetPoint     ' Returns true if there is a valid location
            End With
            tryCount += 1       ' Increment the try counter
            Dim strCaption As String = ""

            ' If there is not a GPS fix then exit the sub routine
            If Not blAquiredFix Then
                If Not myFormLibrary.frmGpsSettings Is Nothing Then
                    myFormLibrary.frmGpsSettings.lblGPSMessage.Text = "SEARCHING. . ."
                    myFormLibrary.frmGpsSettings.lblGPSMessage.ForeColor = Color.Blue
                End If
                Me.lblGPSConnectionValue.Text = "SEARCHING. . ."
                Me.lblGPSConnectionValue.ForeColor = Color.Blue
                Exit Sub
            End If
            Me.txtTimeSource.ForeColor = Color.LimeGreen
            Me.txtTime.ForeColor = Color.LimeGreen
            Me.txtDateSource.ForeColor = Color.LimeGreen
            Me.tmrGPSExpiry.Stop()
            Me.dblGPSExpiry = 0
            Me.tmrGPSExpiry.Start()
            aquiredTryCount = 0
            strCaption = "GPS FIX"
            If Not myFormLibrary.frmGpsSettings Is Nothing Then
                myFormLibrary.frmGpsSettings.lblGPSMessage.Text = strCaption
                myFormLibrary.frmGpsSettings.lblGPSMessage.ForeColor = Color.LimeGreen
            End If
            Me.lblGPSConnectionValue.Text = strCaption
            Me.lblGPSConnectionValue.ForeColor = Color.LimeGreen
            Me.lblYValue.ForeColor = Color.LimeGreen
            Me.lblXValue.ForeColor = Color.LimeGreen
            Me.lblZValue.ForeColor = Color.LimeGreen

            ' Change the value of X from positive to negative if necessary
            If Me.GPS_X > 0 Then
                Me.GPS_X *= -1
            End If

            ' Format the values to include 5 decimal places
            If Not myFormLibrary.frmGpsSettings Is Nothing Then
                myFormLibrary.frmGpsSettings.lblCurrentYValue.Text = FormatNumber(Me.GPS_Y, 5)
                myFormLibrary.frmGpsSettings.lblCurrentXValue.Text = FormatNumber(Me.GPS_X, 5)
                myFormLibrary.frmGpsSettings.lblCurrentZValue.Text = FormatNumber(Me.GPS_Z, 2)
                myFormLibrary.frmGpsSettings.lblCurrentDateValue.Text = Me.GPSDate
                myFormLibrary.frmGpsSettings.lblCurrentTimeValue.Text = Me.GPSDateTime
            End If
            If Not myFormLibrary.frmSetTime Is Nothing Then
                myFormLibrary.frmSetTime.txtSetTime.Text = Me.GPSDateTime
            End If
            Me.lblYValue.Text = FormatNumber(Me.GPS_Y, 5)
            Me.lblXValue.Text = FormatNumber(Me.GPS_X, 5)
            Me.lblZValue.Text = FormatNumber(Me.GPS_Z, 2)

            Me.txtTimeSource.Text = strTimeDateSource
            Me.txtTimeSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            Me.txtTimeSource.BackColor = Color.LightGray

            Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
            Me.txtTime.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            Me.txtTime.BackColor = Color.LightGray

            Me.txtTime.TextAlign = HorizontalAlignment.Center
            Me.txtTime.Text = Me.GPSDateTime

            Me.txtTransectDate.Text = Me.GPSDate
            Me.txtDateSource.Text = strTimeDateSource
            Me.txtDateSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            Me.txtDateSource.BackColor = Color.LightGray
            '
            Me.txtDateSource.TextAlign = HorizontalAlignment.Center
            'If dblGPSExpiry < 1 Then
            '    Me.txtTimeSource.ForeColor = Color.LimeGreen
            '    Me.txtTime.ForeColor = Color.LimeGreen
            '    Me.txtTime.Text = Me.GPSDateTime
            '    Me.txtDateSource.ForeColor = Color.LimeGreen
            'Else
            '    Me.txtTimeSource.ForeColor = Color.Red
            '    Me.txtTime.ForeColor = Color.Red
            '    Me.txtTime.Text = Me.GPSDateTime
            '    Me.txtDateSource.ForeColor = Color.Red
            'End If
            'myFormLibrary.frmGpsSettings.lblCurrentTimeValue.Text = Me.GPSDateTime
            'End If
            '     End If
        Catch ex As Exception
            'Dim st As New StackTrace(ex, True)
            'Dim frame As StackFrame
            'frame = st.GetFrame(0)
            'Dim line As Integer
            'line = frame.GetFileLineNumber
            'MsgBox("At line " & line & " " & ex.Message & " Stack trace: " & st.ToString)
        End Try

    End Sub

    Private Sub DisableHabitatButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisableHabitatButtonsToolStripMenuItem.Click
        If DisableHabitatButtonsToolStripMenuItem.Text = "Disable Habitat Buttons" Then
            DisableHabitatButtonsToolStripMenuItem.Text = "Enable Habitat Buttons"
            Dim item As Button
            For Each item In buttons
                If Not item Is Nothing Then
                    item.Enabled = False
                End If
            Next
        Else
            DisableHabitatButtonsToolStripMenuItem.Text = "Disable Habitat Buttons"
            Dim item As Button
            For Each item In buttons
                If Not item Is Nothing Then
                    item.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub pnlSpeciesData_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSpeciesData.SizeChanged
        If db_file_open Then

            Me.pnlSpeciesData.Controls.Clear()
            Call fillSpeciesVariableButtonPanel()
        End If
    End Sub

    Private Sub cmdDeleteLastRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLastRecord.Click
        Dim row As DataGridViewRow
        Dim IDValue As Integer = Me.grdVideoMinerDatabase.Rows.Item(0).Cells("ID").Value

        For Each row In Me.grdVideoMinerDatabase.Rows
            If row.Cells("ID").Value >= IDValue Then
                IDValue = row.Cells("ID").Value
            End If
        Next

        Dim intAnswer As Integer
        intAnswer = MessageBox.Show("Are you sure you want to permanently delete the record with ID as " & IDValue & "?  This action cannot be undone.", "Delete Last Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If intAnswer = vbYes Then
            Dim deleteQuery As String
            deleteQuery = "DELETE FROM " & DB_DATA_TABLE & " WHERE ID = " & IDValue
            Dim numrows As Integer
            Dim oComm As OleDbCommand
            oComm = New OleDbCommand(deleteQuery, conn)
            numrows = oComm.ExecuteNonQuery()
            fetch_data()
        End If
    End Sub

    Private Sub ConfigureButtonFormatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureButtonFormatToolStripMenuItem.Click
        If Not myFormLibrary.frmConfigureButtonFormat Is Nothing Then
            myFormLibrary.frmConfigureButtonFormat.Dispose()
            myFormLibrary.frmConfigureButtonFormat = Nothing
        End If

        myFormLibrary.frmConfigureButtonFormat = New frmConfigureButtonFormat
        myFormLibrary.frmConfigureButtonFormat.ShowDialog()
    End Sub

    Private Sub cmdScreenCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScreenCapture.Click
        Call Me.mnuCapScr_Click(sender, e)
    End Sub

    Private Sub tmrGPSExpiry_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGPSExpiry.Tick
        If Me.txtTime.Text <> strPreviousGPSTime Then
            strPreviousGPSTime = Me.txtTime.Text
            Me.txtTimeSource.ForeColor = Color.LimeGreen
            Me.txtTime.ForeColor = Color.LimeGreen
            Me.txtDateSource.ForeColor = Color.LimeGreen
        Else
            'If dblGPSExpiry > 0.5 Then
            Me.txtTimeSource.ForeColor = Color.Red
            Me.txtTime.ForeColor = Color.Red
            Me.txtDateSource.ForeColor = Color.Red
            'End If
            'dblGPSExpiry += 0.5
        End If
    End Sub

    Private Sub tmrComputerTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrComputerTime.Tick
        Dim strTime As String = ""
        If Now.Hour >= 10 Then
            strTime = CStr(Now.Hour)
        Else
            strTime = "0" & CStr(Now.Hour)
        End If
        If Now.Minute >= 10 Then
            strTime = strTime & ":" & CStr(Now.Minute)
        Else
            strTime = strTime & ":0" & CStr(Now.Minute)
        End If
        If Now.Second >= 10 Then
            strTime = strTime & ":" & CStr(Now.Second)
        Else
            strTime = strTime & ":0" & CStr(Now.Second)
        End If
        Me.txtTime.Text = strTime
        Me.txtTime.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
        Me.txtTime.BackColor = Color.LightGray
        Me.txtTime.ForeColor = Color.LimeGreen
        Me.txtTimeSource.BackColor = Color.LightGray
        Me.txtTimeSource.ForeColor = Color.LimeGreen
        Me.txtDateSource.BackColor = Color.LightGray
        Me.txtDateSource.ForeColor = Color.LimeGreen

        Dim strDate As String = ""
        If Now.Day >= 10 Then
            strDate = CStr(Now.Day)
        Else
            strDate = "0" & CStr(Now.Day)
        End If
        If Now.Month >= 10 Then
            strDate = strDate & "/" & CStr(Now.Month)
        Else
            strDate = strDate & "/0" & CStr(Now.Month)
        End If
        If Now.Year >= 10 Then
            strDate = strDate & "/" & CStr(Now.Year)
        Else
            strDate = strDate & "/0" & CStr(Now.Year)
        End If

        transect_date = strDate
        Me.txtTransectDate.Text = transect_date
        If Not myFormLibrary.frmSetTime Is Nothing Then
            myFormLibrary.frmSetTime.txtSetTime.Text = strTime
        End If

    End Sub

    Private Sub txtTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTime.TextChanged
        If Me.txtTimeSource.Text = "VIDEO" Then
            If Me.txtTime.Text = VIDEO_TIME_LABEL Then
                Dim strDate = Me.txtTransectDate.Text.Split("/")
                Dim dtDate As New Date(CInt(strDate(2)), CInt(strDate(1)), CInt(strDate(0)))
                Dim dtNewDate As Date
                dtNewDate = dtDate.AddDays(1)
                Dim strNewDate As String
                If dtNewDate.Day >= 10 Then
                    strNewDate = CStr(dtNewDate.Day)
                Else
                    strNewDate = "0" & CStr(dtNewDate.Day)
                End If
                If dtNewDate.Month >= 10 Then
                    strNewDate = strNewDate & "/" & CStr(dtNewDate.Month)
                Else
                    strNewDate = strNewDate & "/0" & CStr(dtNewDate.Month)
                End If
                If dtNewDate.Year >= 10 Then
                    strNewDate = strNewDate & "/" & CStr(dtNewDate.Year)
                Else
                    strNewDate = strNewDate & "/0" & CStr(dtNewDate.Year)
                End If

                transect_date = strNewDate
                Me.txtTransectDate.Text = transect_date
            End If
        End If
    End Sub

    Private Sub EditLookupTableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditLookupTableToolStripMenuItem.Click
        myFormLibrary.frmEditLookupTable = New frmEditLookupTable
        myFormLibrary.frmEditLookupTable.ShowDialog()
    End Sub

    Private Sub grdVideoMinerDatabase_ColumnDisplayIndexChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles grdVideoMinerDatabase.ColumnDisplayIndexChanged
        If blupdateColumns Then
            If Not blOpenDatabase And Not blCloseDatabase Then
                Dim strColumns As String = ""
                dataColumns = New Collection
                Dim dgColumn As DataGridViewColumn
                For Each dgColumn In grdVideoMinerDatabase.Columns
                    dataColumns.Add(dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width)
                    strColumns = strColumns & dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width & ","
                Next
                Dim strConfigFile As String = strConfigFilePath & "\VideoMinerConfigurationDetails.xml"
                SaveXmlSettings(strConfigFile, "VideoMinerConfigurationDetails/Database/Configuration/DatabaseName", db_filename)
                SaveXmlSettings(strConfigFile, "VideoMinerConfigurationDetails/Database/Configuration/Columns", strColumns.Substring(0, strColumns.Length - 1))
            End If
        End If
    End Sub

    Private Sub grdVideoMinerDatabase_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles grdVideoMinerDatabase.ColumnWidthChanged
        If blupdateColumns Then
            If Not blOpenDatabase And Not blCloseDatabase Then
                Dim strColumns As String = ""
                dataColumns = New Collection
                Dim dgColumn As DataGridViewColumn
                For Each dgColumn In grdVideoMinerDatabase.Columns
                    dataColumns.Add(dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width)
                    strColumns = strColumns & dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width & ","
                Next
                Dim strConfigFile As String = strConfigFilePath & "\VideoMinerConfigurationDetails.xml"
                SaveXmlSettings(strConfigFile, "VideoMinerConfigurationDetails/Database/Configuration/DatabaseName", db_filename)
                SaveXmlSettings(strConfigFile, "VideoMinerConfigurationDetails/Database/Configuration/Columns", strColumns.Substring(0, strColumns.Length - 1))
            End If
        End If
    End Sub

End Class