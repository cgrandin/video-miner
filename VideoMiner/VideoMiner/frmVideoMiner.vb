' The following 3 imports are necessary for using ADO.NET, which permits database access.
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
' All times are stored as TimeSpan objects
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

''' <summary>
''' This is the main form for the program, and instantiates most of the other forms.
''' </summary>
Public Class VideoMiner

#Region "Constants"
    Private Const XPATH_PREVIOUS_PROJECTS As String = "/PreviousProjects"

    Private Const XPATH_DATABASE_PATH As String = "/DatabasePath"
    Private Const XPATH_SESSION_PATH As String = "/SessionPath"
    Private Const XPATH_VIDEO_PATH As String = "/VideoPath"

    Private Const XPATH_GPS_COM_PORT As String = "/GPS/ComPort"
    Private Const XPATH_GPS_NMEA_STRING As String = "/GPS/NMEA"
    Private Const XPATH_GPS_BAUD_RATE As String = "/GPS/BaudRate"
    Private Const XPATH_GPS_PARITY As String = "/GPS/Parity"
    Private Const XPATH_GPS_STOP_BITS As String = "/GPS/StopBits"
    Private Const XPATH_GPS_DATA_BITS As String = "/GPS/DataBits"
    Private Const XPATH_GPS_TIMEOUT As String = "/GPS/Timeout"

    Private Const XPATH_BUTTON_HEIGHT As String = "/ButtonFormat/ButtonSize/Height"
    Private Const XPATH_BUTTON_WIDTH As String = "/ButtonFormat/ButtonSize/Width"
    Private Const XPATH_BUTTON_TEXTSIZE As String = "/ButtonFormat/ButtonText/TextSize"
    Private Const XPATH_BUTTON_FONT As String = "/ButtonFormat/ButtonText/Font"

    Private Const XPATH_DATABASE_NAME As String = "/Database/Configuration/DatabaseName"
    Private Const XPATH_DATABASE_COLUMNS As String = "/Database/Configuration/Columns"

    Private Const XPATH_DEVICE_CONFIGURATION_SET As String = "/DeviceControl/ConfigurationSet"
    Private Const XPATH_DEVICE_SETUP As String = "/DeviceControl/Setup"
    Private Const XPATH_DEVICE_PARALLEL_COM_PORT As String = "/DeviceControl/Parallel/ComPort"
    Private Const XPATH_DEVICE_PARALLEL_BAUD_RATE As String = "/DeviceControl/Parallel/BaudRate"
    Private Const XPATH_DEVICE_TWOPORTS_DEVICE1_COM_PORT As String = "/DeviceControl/TwoPorts/Device1/ComPort"
    Private Const XPATH_DEVICE_TWOPORTS_DEVICE1_BAUD_RATE As String = "/DeviceControl/TwoPorts/Device1/BaudRate"
    Private Const XPATH_DEVICE_TWOPORTS_DEVICE2_COM_PORT As String = "/DeviceControl/TwoPorts/Device2/ComPort"
    Private Const XPATH_DEVICE_TWOPORTS_DEVICE2_BAUD_RATE As String = "/DeviceControl/TwoPorts/Device2/BaudRate"
    Private Const XPATH_DEVICE_RELAY_DEVICE1_RELAY1 As String = "/DeviceControl/RelayNames/Device1/Relay1"
    Private Const XPATH_DEVICE_RELAY_DEVICE1_RELAY2 As String = "/DeviceControl/RelayNames/Device1/Relay2"
    Private Const XPATH_DEVICE_RELAY_DEVICE1_RELAY3 As String = "/DeviceControl/RelayNames/Device1/Relay3"
    Private Const XPATH_DEVICE_RELAY_DEVICE1_RELAY4 As String = "/DeviceControl/RelayNames/Device1/Relay4"
    Private Const XPATH_DEVICE_RELAY_DEVICE2_RELAY1 As String = "/DeviceControl/RelayNames/Device2/Relay1"
    Private Const XPATH_DEVICE_RELAY_DEVICE2_RELAY2 As String = "/DeviceControl/RelayNames/Device2/Relay2"
    Private Const XPATH_DEVICE_RELAY_DEVICE2_RELAY3 As String = "/DeviceControl/RelayNames/Device2/Relay3"
    Private Const XPATH_DEVICE_RELAY_DEVICE2_RELAY4 As String = "/DeviceControl/RelayNames/Device2/Relay4"

    Private Const XPATH_RANGE_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Range/Displayed"
    Private Const XPATH_IDCONFIDENCE_DISPLAY As String = "/DetailedSpeciesEventConfiguration/IDConfidence/Displayed"
    Private Const XPATH_ABUNDANCE_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Abundance/Displayed"
    Private Const XPATH_COUNT_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Count/Displayed"
    Private Const XPATH_HEIGHT_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Height/Displayed"
    Private Const XPATH_WIDTH_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Width/Displayed"
    Private Const XPATH_LENGTH_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Length/Displayed"
    Private Const XPATH_COMMENTS_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Comments/Displayed"

    Private Const XPATH_RANGE_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Range/DefaultValue"
    Private Const XPATH_IDCONFIDENCE_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/IDConfidence/DefaultValue"
    Private Const XPATH_ABUNDANCE_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Abundance/DefaultValue"
    Private Const XPATH_COUNT_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Count/DefaultValue"
    Private Const XPATH_HEIGHT_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Height/DefaultValue"
    Private Const XPATH_WIDTH_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Width/DefaultValue"
    Private Const XPATH_LENGTH_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Length/DefaultValue"
    Private Const XPATH_COMMENTS_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Comments/DefaultValue"

    Private Const GPS_COM_PORT_DEFAULT As String = "COM10"
    Private Const GPS_NMEA_DEFAULT As String = "GPGGA"
    Private Const GPS_BAUD_RATE_DEFAULT As Integer = 4800
    Private Const GPS_PARITY_DEFAULT As String = "NONE"
    Private Const GPS_STOP_BITS_DEFAULT As Integer = 1
    Private Const GPS_DATA_BITS_DEFAULT As Integer = 8
    Private Const GPS_TIMEOUT_DEFAULT As Integer = 5

    Private Const VIDEO_TIME_FORMAT As String = "{0:D2}:{1:D2}:{2:D2}.{3:D3}" ' D3 = 3 decimal places
    Private Const VIDEO_FRAME_STEP_DEFAULT As Integer = 500
    Public Const DB_ADO_CONN_STRING_1 As String = "Data Source="
    Public Const DB_ADO_CONN_STRING_2 As String = ";Initial Catalog=data"
    Public Const BAD_ID As Long = -1
    Public Const OPEN_DB_TITLE As String = "Open Database"
    Public Const OPEN_VID_TITLE As String = "Open Video"
    Public Const OPEN_EXT_VID As String = "Use External Video"
    Public Const DB_FILE_FILTER As String = "MS Access files (*.mdb)|*.mdb"
    Public Const DB_FILE_STATUS_LOADED As String = "Database '"
    Public Const VIDEO_FILE_STATUS_LOADED As String = "Video file is open"
    Public Const DB_FILE_STATUS_UNLOADED As String = "No database open"
    Public Const VIDEO_FILE_STATUS_UNLOADED As String = "No video file open"
    Public Const STATUS_FONT_SIZE As Integer = 10
    Public Const DIR_SEP As String = "\"
    Public Const NULL_STRING As String = ""
    Public Const NS As String = "NULL"
    Public Const UNNAMED_TRANSECT As String = "Unnamed Transect"
    Public Const NO_TRANSECT As String = "No Transect"
    Public Const NO_SUBSTRATE As String = "No Substrate"
    Public Const NO_BIOCOVER As String = "No Biocover"
    Public Const NO_RELIEF As String = "No Relief"
    Public Const NO_COMPLEXITY As String = "No Complexity"
    Public Const OFF_BOTTOM_STRING As String = "Off bottom"
    Public Const ON_BOTTOM_STRING As String = "On bottom"

    Public Const TRANSECT_START As String = "1"
    Public Const TRANSECT_END As String = "2"
    Public Const ON_OFF_BOTTOM As String = "3"
    Public Const SPECIES_EVENT As String = "4"
    Public Const DOMINANT_SUBSTRATE As String = "5"
    Public Const DOMINANT_SUBSTRATE_PERCENT As String = "6"
    Public Const SUBDOMINANT_SUBSTRATE As String = "7"
    Public Const SUBDOMINANT_SUBSTRATE_PERCENT As String = "8"
    Public Const SURVEY_MODE As String = "9"
    Public Const VIDEO_OR_IMAGE_QUALITY As String = "11"
    Public Const RELIEF As String = "12"
    Public Const DISTURBANCE As String = "13"
    Public Const PROTOCOL As String = "14"
    Public Const COMPLEXITY As String = "15"
    Public Const FOV As String = "16"
    Public Const SCREEN_CAPTURE As String = "555"
    Public Const COMMENT_ADDED As String = "666"
    Public Const NOTHING_IN_PHOTO As String = "777"
    Public Const INDIVIDUAL_HABITAT_VARIABLE_CLEARED As String = "888"
    Public Const ALL_HABITAT_VARIABLES_CLEARED As String = "999"

#End Region

#Region "Variables"
    ' These are the forms which this form creates and they report directly to this form only
    Private WithEvents frmSpeciesList As frmSpeciesList
    Private WithEvents frmSetTime As frmSetTime
    Private WithEvents frmImage As frmImage
    Private WithEvents frmGpsSettings As frmGpsSettings
    Private WithEvents frmEditSpecies As frmEditSpecies
    Private WithEvents frmConfigureSpecies As frmConfigureSpecies
    Private WithEvents frmSpeciesEvent As frmSpeciesEvent
    Private WithEvents frmTableView As frmTableView
    Private WithEvents frmAbundanceTableView As frmAbundanceTableView
    Private WithEvents frmRareSpeciesLookup As frmRareSpeciesLookup
    Private WithEvents frmRelayConfiguration As frmRelayConfiguration
    Private WithEvents frmKeyboardCommands As frmKeyboardCommands
    Private WithEvents frmAddNewTable As frmAddNewTable
    Private WithEvents frmConfigureButtons As frmConfigureButtons
    Private WithEvents frmVideoPlayer As frmVideoPlayer
    Private WithEvents frmProjectNames As frmProjectNames
    Private WithEvents frmDataCodes As frmDataCodes
    Private WithEvents frmDeviceControl As frmDeviceControl
    Private WithEvents frmConfigureButtonFormat As frmConfigureButtonFormat
    Private WithEvents frmAddValue As frmAddValue
    Private WithEvents frmEditLookupTable As frmEditLookupTable

    ''' <summary>
    ''' The working directory of the software
    ''' </summary>
    Private m_strWorkingPath As String
    ''' <summary>
    ''' The configuration directory for the software
    ''' </summary>
    ''' <remarks>This will be the directory given by (m_strWorkingPath)\Config</remarks>
    Private m_strConfigFilePath As String
    ''' <summary>
    ''' The full path for the configuration file
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strConfigFile As String
    ''' <summary>
    ''' Holds the last known database path as entered by the user in the OpenFileDialog
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strDatabasePath As String
    ''' <summary>
    ''' Holds the full path filename as entered by the user in the OpenFileDialog
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strDatabaseFilePath As String
    ''' <summary>
    ''' Holds the last known video file path as entered by the user in the OpenFileDialog
    ''' Does not hold the filename itself
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strVideoPath As String
    ''' <summary>
    ''' Hold the currently loaded video's filename without path information
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strVideoFile As String
    ''' <summary>
    ''' Holds the path of the last known session's path as entered by the user in the OpenFileDialog
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strSessionPath As String
    ''' <summary>
    ''' Holds the user time as set by the frmSetTime form.
    ''' This is the master time object to be used by all functions when data are recorded.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_tsUserTime As TimeSpan
    ''' <summary>
    ''' Holds the GPS X value (latitude). If a GPS device is not connected, this will be a default
    ''' value as set in the load function for this form.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_GPS_X As String
    ''' <summary>
    ''' Holds the GPS Y value (longitude). If a GPS device is not connected, this will be a default
    ''' value as set in the load function for this form.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_GPS_Y As String
    ''' <summary>
    ''' Holds the GPS Z value (elevation). If a GPS device is not connected, or the NMEA sting
    ''' does not support elevation, this will be a default value as set in the load function for this form.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_GPS_Z As String
    ''' <summary>
    ''' Name of the current project
    ''' </summary>
    ''' <remarks></remarks>
    Private m_project_name As String = NULL_STRING
    ''' <summary>
    ''' Name of the current transect
    ''' </summary>
    ''' <remarks></remarks>
    Private m_transect_name As String
    ''' <summary>
    ''' Date for the current transect
    ''' </summary>
    ''' <remarks></remarks>
    Private m_transect_date As DateTime
    ''' <summary>
    ''' Is there a video file currently open or not.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_video_file_open As Boolean
    ''' <summary>
    ''' Relative rate at which to play the video. 1=regular speed.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_dblVideoRate As Double = 1
    ''' <summary>
    ''' Are we in a transect currently or not?
    ''' </summary>
    ''' <remarks></remarks>
    Private m_blInTransect As Boolean = vbFalse

    ''' <summary>
    ''' Holds the data table for the actual project data being recorded
    ''' </summary>
    Private m_data_table As DataTable
    Private m_db_file_open As Boolean
    Private m_db_filename As String
    Private m_db_id_num As Long

    ' GPS connection settings to initialize frmGpsSettings form with
    Private m_strComPort As String
    Private m_strNMEAStringType As String
    Private m_strParity As String
    Private m_intBaudRate As Integer
    Private m_dblStopBits As Double
    Private m_intDataBits As Integer
    Private m_intTimeout As Integer

    Private m_strDatabaseName As String
    Private m_strDatabaseColumns As String

    Private ttToolTip As ToolTip
    Private select_string As String
    Private insert_string As String
    Private substrate_name As String
    Private substrate_code As String

    Public strKeyboardShortcut As String = NULL_STRING
    Public strCurrentKey As String = NULL_STRING
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


    ' Comparison value for reord every second functionality    
    Public intLastVideoSecond As Integer = 0
    Public intLastVideoMinute As Integer = 0
    Public intLastVideoHour As Integer = 0
    Public intVideoStopCounter As Integer = 0
    Public blSpeciesCancelled As Boolean = False
    Private blIsDuplicateTime As Boolean = False

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
    Private Transect_Textboxes() As TextBox
    Private strTransectButtonCodeNames() As String
    Private Transect_Buttons() As Button
    Private intTransectButtonCodes() As Integer
    Private strTransectButtonTables() As String
    Private strTransectButtonUserCodeChoice() As String
    Private strTransectButtonUserNameChoice() As String
    Private strTransectButtonColors() As String
    Private intNumTransectButtons As Integer

    ' for the species variables
    Private speciesButtons() As Button
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
    Private strQuickEntryCount As String = NULL_STRING
    Private strDefaultQuickEntryCount As String = "1"

    Private blVideoWasPlaying As Boolean = False

    Public imageFilesList As List(Of String)
    Public imagePath As String = NULL_STRING

    Public tryCount As Integer = 0
    Public aquiredTryCount As Integer = 0
    Public strPreviousGPSTime As String = NULL_STRING
    Public dblGPSExpiry As Double = 0

    '    Public strTimeDateSource As String = "ELAPSED"
    '    Public strPreviousClipTime As String = VIDEO_TIME_DECIMAL_LABEL
    Public intTimeSource As Integer = 1
    Public blImageWarning As Boolean = True
    Public blScreenCaptureCalled As Boolean = False
    Public blOpenDatabase As Boolean = False
    Public blCloseDatabase As Boolean = False
    Public dblVideoStartPosition As Double = 0
    'Public txtNMEAStringData As String = NULL_STRING

    Public dataColumns As Collection
    Public blupdateColumns As Boolean = True

    Private frmAbout As AboutBox1
    Private strAbout As String

#End Region

#Region "Delegate Function Declarations"
    Private Delegate Sub myDelegate()
#End Region

#Region "Fields"
#Region "VideoMiner Fields"
    Private m_strVersion As String
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

    Private m_SessionName As String

    Private m_GPSUserTime As TimeSpan

    Private m_ButtonWidth As Integer
    Private m_ButtonHeight As Integer
    Private m_ButtonTextSize As Integer
    Private m_ButtonFont As String

    Private m_PreviousProjects As Collection
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
    Public ReadOnly Property Version As String
        Get
            Return m_strVersion
        End Get
    End Property

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
            If m_strVideoPath = NULL_STRING And m_strVideoFile = NULL_STRING Then
                Return "External Video"
            Else
                Return m_strVideoPath & "/" & m_strVideoFile
            End If
        End Get
        Set(value As String)
            ' Only set for external video
            m_strVideoPath = NULL_STRING
            m_strVideoFile = NULL_STRING
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
            Return m_tsUserTime
        End Get
        Set(ByVal value As TimeSpan)
            m_tsUserTime = value
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

#Region "Video Miner Controls"

    Public Sub New()
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

    ''' <summary>
    ''' Get version name from assembly, read and process the Config file, and setup the form controls for an unloaded state.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    ''' <remarks> From MSDN for Windows.Forms.Control.CheckForIllegalCrossThreadCalls:
    ''' When a thread other than the creating thread of a control tries to access one of that control's methods or properties,
    ''' it often leads to unpredictable results. A common invalid thread activity is a call on the wrong thread that accesses
    ''' the Control 's Handle property. Set CheckForIllegalCrossThreadCalls to true to find and diagnose this thread activity
    ''' more easily while debugging. </remarks>
    Private Sub frmVideoMiner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        AddHandler currentDomain.UnhandledException, AddressOf UnHandledHandler
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = True

        Dim asType As Type = MyBase.GetType
        Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetAssembly(asType)
        Dim aAssemblyInfo As New AssemblyInfo(assembly)
        Dim aVersionInfo As Version = aAssemblyInfo.Version
        m_strVersion = aVersionInfo.ToString
        Text = Name & " - " & Version

        ' Enable Key preview so that video player hotkeys can be instantiated from this forms event handler.
        Me.KeyPreview = True

        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height

        Dim aPoint As System.Drawing.Point
        aPoint.X = intX
        aPoint.Y = intY / 2

        m_strWorkingPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        m_strConfigFilePath = Path.Combine(m_strWorkingPath, "Config")
        m_strConfigFile = Path.Combine(m_strConfigFilePath, VIDEOMINER_CONFIG_FILE_NAME)

        If Not loadConfigurationFile() Then
            Dim strWarning As String = "There was an error while loading the configuration file " & m_strConfigFile & ". Closing VideoMiner."
            MessageBox.Show(strWarning, "No configuration file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If

        m_db_file_open = False
        m_video_file_open = False
        db_file_unload()
        video_file_unload()
        no_files_loaded()
        m_transect_name = UNNAMED_TRANSECT
        curr_code = BAD_ID
        is_on_bottom = 0
        toggle_bottom(NULL_STRING, NULL_STRING, NULL_STRING & ".00", NS, NS, NS)

        lblDirtyData.Visible = False

        Me.cboZoom.Items.Add("25%")
        Me.cboZoom.Items.Add("50%")
        Me.cboZoom.Items.Add("75%")
        Me.cboZoom.Items.Add("100%")
        Me.cboZoom.Items.Add("200%")
        Me.cboZoom.Text = "100%"

        Me.cmdPreviousImage.Enabled = False
        Me.cmdNextImage.Enabled = False
        Me.cboZoom.Enabled = False

        intNumberDisplayRecords = intDefaultNumberDisplayRecords

        Me.txtQuickSpeciesCount.Text = strDefaultQuickEntryCount
        strQuickEntryCount = strDefaultQuickEntryCount

        Me.SelectNextControl(Me.SplitContainer4.Panel2, False, True, True, True)

        Me.VideoTime = Zero

        ' Enable the Device Control menu based on if the configuration has been set
        ' This makes sure that the devices are not accessed until the configuration has been set
        'If Me.ConfigurationSet = False Then
        '    Me.DeviceControl.Enabled = False
        'Else
        '    Me.DeviceControl.Enabled = True
        'End If
        Dim strDate As String = NULL_STRING
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
        m_transect_date = strDate
        m_tsUserTime = Zero

        ttToolTip = New ToolTip()
        ' Always show is required because the video window gets the focus if it's open.
        ttToolTip.ShowAlways = True
        ttToolTip.InitialDelay = 500
        ttToolTip.AutoPopDelay = 5000
        ttToolTip.ReshowDelay = 500

        ' Set the GPS values to a default of nothing. Once a GPS device is connected, these will be
        ' continuously updated by the incoming data handler.
        m_GPS_X = NULL_STRING
        m_GPS_Y = NULL_STRING
        m_GPS_Z = NULL_STRING

        ' Create some form instances here. These forms will remain hidden throughout the session, and ShowDialog will be called to show them
        frmGpsSettings = New frmGpsSettings(m_strComPort, m_strNMEAStringType, m_intBaudRate, m_strParity, m_dblStopBits, m_intDataBits, m_intTimeout)
        'frmGpsSettings.ShowDialog()
        frmSetTime = New frmSetTime(m_tsUserTime)

    End Sub

    ''' <summary>
    ''' Load the metadata found in the VideoMiner configuration file into member variables.
    ''' If the configuration file is not found, defaults will be assigned for GPS settings and the path variables
    ''' </summary>
    ''' <returns>True if all member variables were populated. False if an exceptioon was thrown or the file does not exist</returns>
    Private Function loadConfigurationFile() As Boolean
        Dim strTmp As String
        Try
            If File.Exists(m_strConfigFile) Then
                ' Button settings
                m_ButtonHeight = CInt(GetConfiguration(XPATH_BUTTON_HEIGHT))
                m_ButtonWidth = CInt(GetConfiguration(XPATH_BUTTON_WIDTH))
                m_ButtonTextSize = CInt(GetConfiguration(XPATH_BUTTON_TEXTSIZE))
                m_ButtonFont = GetConfiguration(XPATH_BUTTON_FONT)
                ' GPS settings
                m_strComPort = GetConfiguration(XPATH_GPS_COM_PORT)
                If m_strComPort = NULL_STRING Then
                    m_strComPort = GPS_COM_PORT_DEFAULT
                    SaveConfiguration(XPATH_GPS_COM_PORT, m_strComPort)
                End If
                m_strNMEAStringType = GetConfiguration(XPATH_GPS_NMEA_STRING)
                If m_strNMEAStringType = NULL_STRING Then
                    m_strNMEAStringType = GPS_NMEA_DEFAULT
                    SaveConfiguration(XPATH_GPS_NMEA_STRING, m_strNMEAStringType)
                End If
                strTmp = GetConfiguration(XPATH_GPS_BAUD_RATE)
                If strTmp = NULL_STRING Then
                    m_intBaudRate = GPS_BAUD_RATE_DEFAULT
                    SaveConfiguration(XPATH_GPS_BAUD_RATE, CStr(m_intBaudRate))
                Else
                    m_intBaudRate = CInt(strTmp)
                End If
                m_strParity = GetConfiguration(XPATH_GPS_PARITY)
                If m_strParity = NULL_STRING Then
                    m_strParity = GPS_PARITY_DEFAULT
                    SaveConfiguration(XPATH_GPS_PARITY, m_strParity)
                End If
                strTmp = GetConfiguration(XPATH_GPS_STOP_BITS)
                If strTmp = NULL_STRING Then
                    m_dblStopBits = GPS_STOP_BITS_DEFAULT
                    SaveConfiguration(XPATH_GPS_STOP_BITS, CStr(m_dblStopBits))
                Else
                    m_dblStopBits = CInt(strTmp)
                End If
                strTmp = GetConfiguration(XPATH_GPS_DATA_BITS)
                If strTmp = NULL_STRING Then
                    m_intDataBits = GPS_DATA_BITS_DEFAULT
                    SaveConfiguration(XPATH_GPS_DATA_BITS, CStr(m_intDataBits))
                Else
                    m_intDataBits = CInt(strTmp)
                End If
                strTmp = GetConfiguration(XPATH_GPS_TIMEOUT)
                If strTmp = NULL_STRING Then
                    m_intTimeout = GPS_TIMEOUT_DEFAULT
                    SaveConfiguration(XPATH_GPS_TIMEOUT, CStr(m_intTimeout))
                Else
                    m_intTimeout = CInt(strTmp)
                End If
                ' Database settings
                m_strDatabaseName = GetConfiguration(XPATH_DATABASE_NAME)
                m_strDatabaseColumns = GetConfiguration(XPATH_DATABASE_COLUMNS)
                'Relay settings
                m_ConfigurationSet = CBool(GetConfiguration(XPATH_DEVICE_CONFIGURATION_SET))
                m_RelaySetup = GetConfiguration(XPATH_DEVICE_SETUP)
                m_ParallelCom = GetConfiguration(XPATH_DEVICE_PARALLEL_COM_PORT)
                m_ParallelBaud = CInt(GetConfiguration(XPATH_DEVICE_PARALLEL_BAUD_RATE))
                PortOneCom = GetConfiguration(XPATH_DEVICE_TWOPORTS_DEVICE1_COM_PORT)
                m_PortOneBaud = CInt(GetConfiguration(XPATH_DEVICE_TWOPORTS_DEVICE1_BAUD_RATE))
                m_PortTwoCom = GetConfiguration(XPATH_DEVICE_TWOPORTS_DEVICE2_COM_PORT)
                m_PortTwoBaud = CInt(GetConfiguration(XPATH_DEVICE_TWOPORTS_DEVICE2_BAUD_RATE))
                m_DeviceOneRelayOne = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE1_RELAY1)
                m_DeviceOneRelayTwo = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE1_RELAY2)
                m_DeviceOneRelayThree = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE1_RELAY3)
                m_DeviceOneRelayFour = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE1_RELAY4)
                m_DeviceTwoRelayOne = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE2_RELAY1)
                m_DeviceTwoRelayTwo = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE2_RELAY2)
                m_DeviceTwoRelayThree = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE2_RELAY3)
                m_DeviceTwoRelayFour = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE2_RELAY4)
                ' Paths
                m_strDatabasePath = GetConfiguration(XPATH_DATABASE_PATH)
                m_strVideoPath = GetConfiguration(XPATH_VIDEO_PATH)
                m_strSessionPath = GetConfiguration(XPATH_SESSION_PATH)
                ' If any of the three paths were not present in the XML file, set them to the working directory
                ' which is determined at program startup, not via XML file.
                If m_strDatabasePath = NULL_STRING Then
                    m_strDatabasePath = m_strWorkingPath
                    SaveConfiguration(XPATH_DATABASE_PATH, m_strDatabasePath)
                End If
                If m_strVideoPath = NULL_STRING Then
                    m_strVideoPath = m_strWorkingPath
                    SaveConfiguration(XPATH_VIDEO_PATH, m_strVideoPath)
                End If
                If m_strSessionPath = NULL_STRING Then
                    m_strSessionPath = m_strWorkingPath
                    SaveConfiguration(XPATH_SESSION_PATH, m_strSessionPath)
                End If

                ' The list of previous project names
                m_PreviousProjects = GetConfigurationCollection(XPATH_PREVIOUS_PROJECTS)
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Save a single variable's value to the XML configuration file. If the variable does not exist,
    ''' a new node, and any parent nodes which are required will be added to the XML document.
    ''' If forceCreate is true, the node will be created even if one with the same name already exists.
    ''' This makes dynamic lists possible.
    ''' </summary>
    ''' <param name="xPath">An XPath String representing the XML node name</param>
    ''' <param name="strValue">The value to save in the node represented by xPath</param>
    ''' <returns>A Boolean representing success or failure</returns>
    Public Function SaveConfiguration(ByVal xPath As String, ByVal strValue As String, Optional forceCreate As Boolean = vbFalse) As Boolean
        Dim strPath As String = VMCD & xPath
        If File.Exists(m_strConfigFile) Then
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(m_strConfigFile)

            Dim nodeList As XmlNodeList
            ' Note that SelectNodes method requires the Document name as part of the xPath
            ' but creating a new one does not, so here is strPath and the CreateXMLNode call
            ' several lines below uses xPath (without document name)
            nodeList = xmlDoc.SelectNodes(strPath)
            If nodeList Is Nothing Then
                Return False
            End If
            If nodeList.Count = 0 Or forceCreate Then
                ' The variable doesn't exist in the xml file, so create a new node
                CreateXMLNode(xmlDoc, Nothing, xPath, strValue)
            Else
                ' Create the Parent and Child node objects and cycle through the file
                Dim parentNode, childNode As XmlNode
                For Each parentNode In nodeList
                    If parentNode.HasChildNodes Then
                        For Each childNode In parentNode.ChildNodes
                            If childNode IsNot Nothing Then
                                childNode.InnerText = strValue      ' Set the XML value
                            End If
                        Next
                    End If
                Next
            End If
            xmlDoc.Save(m_strConfigFile)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub testSaveConfiguration()
        m_strConfigFile = "C:\github\video-miner\VideoMiner\VideoMiner\bin\Debug\Config\VideoMinerConfigurationDetails.xml"
        SaveConfiguration("/X/Y/Z/DBP", "The Phantom Menace")
        SaveConfiguration("/X/Y/A/DBP", "Attack of the Clones")
        SaveConfiguration("/X/C/DBP", "Revenge of the Sith")
        SaveConfiguration("/a/b/c/d/e/f/g/h/i/j/k/l/m/n/o/p", "A New Hope")
        SaveConfiguration("/a/b/c/d/e/f/g/h/i/j/k/l/m/n/o/p", "The Empire Strikes Back")
        ' Test forcibly creating the node, even if it has the same name
        SaveConfiguration("/PreviousProjects/ProjectName", "testSave1", vbTrue)
        SaveConfiguration("/PreviousProjects/ProjectName", "testSave2", vbTrue)
        SaveConfiguration("/PreviousProjects/ProjectName", "testSave3", vbTrue)
    End Sub

    ''' <summary>
    ''' Delete a node represented by the string 'xPath'
    ''' eg. if xPath = "X/Y/Z", the function will delete the node Z.
    ''' </summary>
    ''' <param name="xPath">An XPath String representing the node tag you wish to delete</param>
    ''' <param name="strValue">The value to delete. There can be more than one node with the same tag, so this is required to diferrentiate.</param>
    ''' <remarks>xPath is a "/" seperated string where "/" represents node breaks.
    ''' i.e. "X/Y/Z" represents X is parent of Y, Y is parent of Z and Z is the node to delete, as long as it has
    ''' value equal to strValue</remarks>
    Private Function DeleteXMLNode(xPath As String, ByVal strValue As String) As Boolean
        Dim strPath As String = VMCD & xPath
        If File.Exists(m_strConfigFile) Then
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(m_strConfigFile)

            Dim nodeList As XmlNodeList
            ' Note that SelectNodes method requires the Document name as part of the xPath
            ' but creating a new one does not, so here is strPath and the CreateXMLNode call
            ' several lines below uses xPath (without document name)
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
                            If childNode.InnerText = strValue Then
                                parentNode.RemoveChild(childNode)
                                ' Remove the current node as well, since it is just an empty tag now
                                parentNode.ParentNode.RemoveChild(parentNode)
                                Exit For
                            End If
                        End If
                    Next
                End If
            Next
            xmlDoc.Save(m_strConfigFile)
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Recursively create a node and any required parent nodes represented by the string 'xPath'
    ''' eg. if xPath = "X/Y/Z", the function will insert a node with parents if necessary X->Y->Z
    ''' where "Z" is the base case and assumed to be the innerText of the child node.
    ''' </summary>
    ''' <param name="docNode">A reference to an XmlDocument root node</param>
    ''' <param name="node">A reference to a parent to add a new node to. If Nothing, assume docNode is the parent</param>
    ''' <param name="xPath">An XPath String representing the node you wish to add</param>
    ''' <param name="strValue">String representing the value to set the variable to</param>
    ''' <param name="leftPath">String representing the xPath to the left of the current node</param>
    ''' <remarks>xPath is a "/" seperated string where "/" represents node breaks.
    ''' i.e. "X/Y/Z" represents X is parent of Y, Y is parent of Z and Z is the variable with a value to set</remarks>
    Private Sub CreateXMLNode(ByRef docNode As XmlDocument, ByRef node As XmlElement, xPath As String, strValue As String, Optional leftPath As String = NULL_STRING)
        If docNode Is Nothing Or xPath Is Nothing Or xPath = NULL_STRING Or strValue Is Nothing Then
            Exit Sub
        End If

        Dim trimChars() As Char = {"/"}
        xPath = xPath.TrimStart(trimChars)

        Dim newNode, currNode As XmlElement
        Dim names() As String = xPath.Split("/")
        Dim currentPath As String = names(0)
        Dim rightPath(names.Length - 2) As String
        Dim nextPath As String

        newNode = Nothing
        If names Is Nothing Or names.Length <= 0 Then
            Exit Sub
        ElseIf names.Length = 1 Then
            ' base case, create node and set value to xPath, which is a single string without any "/"'s
            newNode = docNode.CreateElement(xPath)
            newNode.InnerText = strValue
            If node IsNot Nothing Then
                ' This is a child of another node, not the document node
                node.AppendChild(newNode)
            Else
                ' This is a child of the document node directly
                docNode.DocumentElement.AppendChild(newNode)
            End If
        Else
            ' not base case, create node if necessary and recursively call rest of list
            Dim currName As String = names(0)
            For i As Integer = 1 To names.Length - 1
                rightPath(i - 1) = names(i)
            Next
            nextPath = String.Join("/", rightPath)
            ' Check to see if the currName node exists. If not, create it then recurse either way
            leftPath = leftPath & "/" & currName
            currNode = docNode.SelectSingleNode(VMCD & "/" & leftPath)
            If currNode Is Nothing Then
                newNode = docNode.CreateElement(currName)
                If node IsNot Nothing Then
                    node.AppendChild(newNode)
                Else
                    docNode.DocumentElement.AppendChild(newNode)
                End If
                CreateXMLNode(docNode, newNode, nextPath, strValue, leftPath)
            Else
                CreateXMLNode(docNode, currNode, nextPath, strValue, leftPath)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Get a single variable's value for a given node from the XML configuration file.
    ''' </summary>
    ''' <param name="xPath">An XPath String representing the XML node name, with children seperated by "/"</param>
    ''' <returns>A String, the value of the requested XML node</returns>
    Public Function GetConfiguration(ByVal xPath As String) As String
        Dim strPath As String = VMCD & xPath
        If File.Exists(m_strConfigFile) Then
            ' Load the config file into the document object
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(m_strConfigFile)

            ' Load the config file nodes into the Node List object
            Dim nodeList As XmlNodeList = xmlDoc.SelectNodes(strPath)
            If nodeList Is Nothing Then
                Return NULL_STRING
            End If

            ' Create the parent and child node objects and cycle through the file
            Dim parentNode, childNode As XmlNode
            Dim strString As String = NULL_STRING
            For Each parentNode In nodeList
                If parentNode.HasChildNodes Then
                    For Each childNode In parentNode.ChildNodes
                        If childNode.ChildNodes.Count > 0 Then
                            strString &= childNode.InnerXml & ","
                        Else
                            strString &= childNode.Value & ","
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
            Return NULL_STRING
        End If

    End Function

    ''' <summary>
    ''' Get a collection of variables values for a given node from the XML configuration file.
    ''' </summary>
    ''' <param name="xPath">An XPath String representing the XML node name, with children seperated by "/"</param>
    ''' <returns>A Collection containing the children's values for the requested XML node</returns>
    Public Function GetConfigurationCollection(ByVal xPath As String) As Collection
        Dim strPath As String = VMCD & xPath
        If File.Exists(m_strConfigFile) Then
            ' Load the config file into the document object
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(m_strConfigFile)

            ' Load the config file nodes into the Node List object
            Dim nodeList As XmlNodeList = xmlDoc.SelectNodes(strPath)
            If nodeList Is Nothing Then
                Return Nothing
            End If

            ' Create the parent and child node objects and cycle through the file
            Dim parentNode, childNode As XmlNode
            m_PreviousProjects = New Collection
            For Each parentNode In nodeList
                If parentNode.HasChildNodes Then
                    For Each childNode In parentNode.ChildNodes
                        If childNode.ChildNodes.Count > 0 Then
                            m_PreviousProjects.Add(childNode.InnerXml, childNode.InnerXml)
                        Else
                            m_PreviousProjects.Add(childNode.Value, childNode.Value)
                        End If
                        'Debug.WriteLine("strString: " & strString)
                    Next
                End If
            Next
            Return m_PreviousProjects
        Else
            Return Nothing
        End If

    End Function

    Private Sub VideoMiner_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim intIndex As Integer
        'MsgBox(strKeyboardShortcut)
        'MsgBox(e.KeyData)
        Select Case strKeyboardShortcut
            Case Keys.Space.ToString
                blHandled = True
                e.Handled = True
                If m_video_file_open Then
                    If Not frmVideoPlayer.IsPlaying Then
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
                End If
            Case Keys.Left.ToString
                blHandled = True
                e.Handled = True
                Dim intAnswer As Integer
                If image_open Then
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
                End If
            Case "Menu"
                e.SuppressKeyPress = True
            Case Else
                If strKeyboardShortcut <> NULL_STRING Then
                    Dim d As DataTable = Database.GetDataTable("select DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor, KeyboardShortcut from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", DB_SPECIES_BUTTONS_TABLE)
                    For Each r As DataRow In d.Rows
                        If r.Item("KeyboardShortcut").ToString = strKeyboardShortcut Then
                            intIndex = CInt(r.Item("DrawingOrder")) - 1
                            If Not speciesButtons(intIndex) Is Nothing Then
                                SpeciesVariableButtonHandler(speciesButtons(intIndex), Nothing)
                            End If
                            Exit For
                        End If
                    Next
                End If
        End Select
        strKeyboardShortcut = NULL_STRING
        strCurrentKey = NULL_STRING
    End Sub

    'Public Sub VideoMiner_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '    If strCurrentKey <> CStr(e.KeyValue) Then
    '        strCurrentKey = CStr(e.KeyValue)
    '        Dim key As Object
    '        For Each key In value
    '            If e.KeyValue = key Then
    '                If strKeyboardShortcut = NULL_STRING Then
    '                    strKeyboardShortcut = key.ToString
    '                Else
    '                    strKeyboardShortcut = strKeyboardShortcut & "+" & key.ToString
    '                End If
    '                If e.KeyValue = Keys.Alt Then
    '                    e.SuppressKeyPress = True
    '                End If
    '            End If

    '        Next
    '    End If
    'End Sub

    ''' <summary>
    ''' When user selects "Open Session" from the file menu, sub openSession() and open a dialogue
    ''' where the user can restore a previous session that was being run in the program via a VideoMiner Session file.
    ''' This restores the last video that was being played.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Private Sub mnuOpenSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenSession.Click
        openSession()
        Me.mnuSaveSession.Enabled = True
    End Sub

    ''' <summary>
    ''' sub saveSession() when the user selects Save Session from the file menu, and open a dialogue
    ''' where the user can save the current VideoMiner Session file. This saves which video is currently being played.
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    ''' <remarks></remarks>
    Private Sub mnuSaveSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveSession.Click
        saveSession()
    End Sub

    ''' <summary>
    ''' sub saveSessionAs() and open a dialogue where the user can save the current state
    ''' that is being run in the program as a new VideoMiner Session file.
    ''' This saves which video is currently being played.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuSaveSessionAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSaveSessionAs.Click
        saveSessionAs()
        Me.mnuSaveSession.Enabled = True
    End Sub

    ''' <summary>
    ''' When a user selects about from the menu bar, display the ABOUT message by opening the AboutBox1 form
    ''' </summary>
    ''' <param name="sender">System.Object</param>
    ''' <param name="e">System.EventArgs</param>
    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformationToolStripMenuItem.Click
        frmAbout = New AboutBox1
        frmAbout.ShowDialog()
    End Sub

    ''' <summary>
    ''' When the user clicks "Open Database" in the file menu, open a dialog box where a database can be selected
    ''' and opened for use in the program.
    ''' Load OpenFileDialog object to prompt user to select a database to open.
    ''' When the user clicks OK, sub openDatabase and send it the path of the database to open.
    ''' </summary>
    Private Sub mnuOpenDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenDatabase.Click
        blOpenDatabase = True
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.Title = OPEN_DB_TITLE
        ofd.InitialDirectory = m_strDatabasePath
        ofd.Filter = DB_FILE_FILTER
        ofd.FilterIndex = 2
        ofd.RestoreDirectory = True
        ofd.Multiselect = False
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_strDatabasePath = ofd.FileName.Substring(0, ofd.FileName.LastIndexOf("\"))
            m_strDatabaseFilePath = ofd.FileName  ' ofd.FileName returns full path filename
            ' write the database path to the XML file
            SaveConfiguration("/DatabasePath", m_strDatabasePath)
            openDatabase()
        End If
    End Sub

    ''' <summary>
    ''' When the user clicks "Close Database" in the file menu, close the currently open database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCloseDatabase.Click
        blCloseDatabase = True
        Database.Close()
        grdVideoMinerDatabase.DataSource = Nothing
        m_db_file_open = False
        db_file_unload()
        no_files_loaded()
        Me.cmdDefineAllSpatialVariables.Visible = False
        Me.cmdDefineAllTransectVariables.Visible = False
        Me.cmdAddComment.Visible = False
        Me.cmdUpdateDatabase.Visible = False
        Me.cmdRevertDatabase.Visible = False
        cmdShowSetTimecode.Enabled = False
        cmdTransectStart.Enabled = False
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

    ''' <summary>
    ''' When the user clicks "Refresh database", it will reload the database into the form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mnuRefreshForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefreshForm.Click
        refresh_database()
    End Sub

    ' ==========================================================================================================
    ' Name: mnuOpenDV_Click
    ' Description: When a user selects "Open a DV Device" from the file menu, the openDV() function to
    '              see a dialogue where the user can open a DV file.
    ' ==========================================================================================================
    Private Sub mnuOpenDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openDV()
    End Sub

    Private Sub GPSSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGPSSettings.Click
        'If frmGpsSettings Is Nothing Then
        '    frmGpsSettings = New frmGpsSettings(m_strComPort, m_strNMEAStringType, m_intBaudRate, m_strParity, m_dblStopBits, m_intDataBits, m_intTimeout)
        'End If
        frmGpsSettings.ShowDialog()
    End Sub

    Private Sub mnuUseExternalVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUseExternalVideo.Click
        'MsgBox(Me.UseExternalVideoToolStripMenuItem.Checked)
        booUseExternalVideo = Me.mnuUseExternalVideo.Checked
        If booUseExternalVideo Then
            Me.mnuOpenFile.Enabled = False

            'booUseGPSTimeCodes = True
            'Me.mnuUseGPSTimeCodes.Checked = True
            'Me.mnuUseGPSTimeCodes.Enabled = False

            If Not frmVideoPlayer Is Nothing Then
                frmVideoPlayer.Close()
            End If

            Me.FileName = "External Video"
            frmSetTime.Show()
            frmSetTime.BringToFront()
        Else
            'Me.mnuPlay.Enabled = True
            'Me.mnuStop.Enabled = True
            'Me.mnuPause.Enabled = True
            Me.mnuOpenFile.Enabled = True

            booUseGPSTimeCodes = False

        End If
    End Sub

    ''' <summary>
    ''' Ask user to input time that is shown on the video. This synchronizes the program with the video, and sets the label to the correct time.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdShowSetTimecode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowSetTimecode.Click
        If frmVideoPlayer Is Nothing Then
            MessageBox.Show("Please open a video file before setting the time.", "Video File Not Open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        pauseVideo()
        frmSetTime.Show()
    End Sub

    ''' <summary>
    ''' This handler is called when the user clicks on the "Transect Start" button.
    ''' Pauses video, prompts user for a transect name, inserts new record in the DataGridView1
    ''' database table, and plays the video again.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TransectStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransectStart.Click
        pauseVideo()
        Dim start_or_end As String

        If Not m_blInTransect Then
            ' Currently not in a transect, so we start it here
            m_transect_name = InputBox("Enter a name for this transect if you wish.", "Transect Name?")
            If m_transect_name = NULL_STRING Then
                m_transect_name = UNNAMED_TRANSECT
                txtTransectTextbox.Text = UNNAMED_TRANSECT
            Else
                txtTransectTextbox.Text = "Transect '" & m_transect_name & "'"
            End If
            txtTransectTextbox.Text = "Transect '" & m_transect_name & "'"
            txtTransectTextbox.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            txtTransectTextbox.BackColor = Color.LightGray
            txtTransectTextbox.ForeColor = Color.LimeGreen
            txtTransectTextbox.TextAlign = HorizontalAlignment.Center
            cmdTransectStart.Text = "Transect End"
            start_or_end = TRANSECT_START
            m_blInTransect = vbTrue
        Else
            ' Currently in a transect, so we end it here
            txtTransectTextbox.Text = NO_TRANSECT
            txtTransectTextbox.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            txtTransectTextbox.BackColor = Color.LightGray
            txtTransectTextbox.ForeColor = Color.Red
            txtTransectTextbox.TextAlign = HorizontalAlignment.Center
            cmdTransectStart.Text = "Transect Start"
            start_or_end = TRANSECT_END
            m_blInTransect = vbFalse
        End If

        Dim numrows As Integer
        Dim query As String = NULL_STRING
        Try
            query = createInsertQuery(start_or_end, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
            Database.ExecuteNonQuery(query)
            fetch_data()
        Catch ex As Exception
            If ex.Message.StartsWith("Syntax") Then
                MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
            Else
                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End If
        End Try

    End Sub

    Private Sub OffBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOffBottom.Click
        ' ==========================================================================================================
        ' Name: OffBottom_Click
        ' Description: This event is called when the user clicks on the "Off Bottom" button.
        ' 1.) Pause Video
        ' 2.) Retrieve Time Code From Video Controler
        ' 3.) toggle_bottom() which 
        '           - Toggles button OffBottom and text box OnOffBottomTextbox between reading "On Bottom" and "Off Bottom"
        '           - If time code is not null, a record is added to the database table with variables for the fields:
        '           - id,TimeCode,DataCode,transect,OnBottom
        ' 4.) Play Video
        ' ==========================================================================================================

        Dim tc As TimeSpan

        Dim strX As String = NS
        Dim strY As String = NS
        Dim strZ As String = NS
        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
        Dim blAquiredFix As Boolean = False
        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.

            ' The GPRMC NMEA String does not contain elevation values. Enter null into database
            ' if GPRMC is the chosen string type.
            blAquiredFix = getGPSData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If

        If m_video_file_open And Not booUseGPSTimeCodes Then
            If frmVideoPlayer.IsPlaying Then
                blVideoWasPlaying = True
            Else
                blVideoWasPlaying = False
            End If
            pauseVideo()
            tc = getTimeCode()
            strVideoTime = frmVideoPlayer.CurrentVideoTimeFormatted
            'strVideoTime = GetVideoTime(tc, strVideoDecimalTime)

        End If
        strVideoTextTime = strVideoTime


        toggle_bottom(strVideoTime, strVideoTextTime, strVideoDecimalTime, strX, strY, strZ)

        If blVideoWasPlaying = True Then
            playVideo()
            blVideoWasPlaying = False
        End If


    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        frmSpeciesList = New frmSpeciesList
        frmSpeciesList.ShowDialog()
        pnlSpeciesData.Controls.Clear()
        fillSpeciesVariableButtonPanel()
    End Sub

    Public Sub mnuCapScr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapScr.Click
        ' Capture the screen, as well as writing a transection to the database.
        ' The value of all the field in the transaction are set to be 0.

    End Sub

    ' ==========================================================================================================
    ' ======================================Code by Xida Chen (begin)===========================================
    ' Name: mnuCapScr_Click
    ' Description: Capture the screen, as well as writing a transection to the database.
    '               The value of all the field in the transection are set to be 0.
    '               This function is called when the user selects "Video-->Capture Screen"
    ' ==========================================================================================================
    'Public Sub mnuCapScr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapScr.Click
    '    ' Make sure that the video is open, otherwise pop up a window
    '    ' to tell user that no video is open.
    '    If video_file_open = False Then
    '        MsgBox("Must open video first.", MsgBoxStyle.OkOnly)
    '        Exit Sub
    '    End If

    '    Dim strVideoTime As String = VIDEO_TIME_LABEL
    '    Dim strVideoTextTime As String = VIDEO_TIME_LABEL
    '    Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
    '    Dim tc As String = VIDEO_TIME_LABEL
    '    Dim strX As String = NS
    '    Dim strY As String = NS
    '    Dim strZ As String = NS
    '    Dim blAquiredFix As Boolean = False

    '    ' Get the video time
    '    pauseVideo()
    '    tc = getTimeCode()
    '    strVideoTime = GetVideoTime(tc, strVideoDecimalTime)
    '    strVideoTextTime = strVideoTime
    '    Dim strVideoTimeNoColon As String
    '    strVideoTimeNoColon = Replace(strVideoTime, ":", NULL_STRING)

    '    ' First, the function in the dvTapeController to capture the screen
    '    ' We assume that the capture screen function is only used for video, not 
    '    ' for still images.

    '    Dim blank As String = NULL_STRING

    '    ' Set the default name to display in screen capture save as dialog
    '    Dim strDefaultName As String = NULL_STRING
    '    'Dim dtTransectDate As Date = (Me.txtTransectDate.Text)
    '    'Dim strTransectDate As String = dtTransectDate.Year & AddZeros(dtTransectDate.Month, 2) & AddZeros(dtTransectDate.Day, 2)
    '    Dim strTextBoxTransectDate As String = Me.txtTransectDate.Text
    '    Dim strTransectDate As String = Mid(strTextBoxTransectDate, 7, 4) & Mid(strTextBoxTransectDate, 4, 2) & Mid(strTextBoxTransectDate, 1, 2)
    '    Dim strTransectTime As String = NULL_STRING
    '    If booUseGPSTimeCodes Then
    '        blAquiredFix = getGPSData(tc, strVideoTime, strVideoDecimalTime, strX, strY, strZ)
    '        strVideoTextTime = strVideoTime
    '        If Not blAquiredFix Then
    '            Exit Sub
    '        End If
    '        strTransectTime = Replace(tc, ":", NULL_STRING)

    '    Else
    '        strTransectTime = strVideoTimeNoColon
    '    End If
    '    Dim strTodaysDate As String = Now.Year & AddZeros(Now.Month, 2) & AddZeros(Now.Day, 2)
    '    Dim strTodaysTime As String = AddZeros(Now.Hour, 2) & AddZeros(Now.Minute, 2) & AddZeros(Now.Second, 2)

    '    If mnuNameOption_1.Checked Then
    '        strDefaultName = "Capture_" & Me.txtProjectName.Text & "_" & strTransectDate & "_" & strTransectTime
    '    ElseIf mnuNameOption_2.Checked Then
    '        strDefaultName = "Capture_" & Me.txtProjectName.Text & "_" & strTodaysDate & "_" & strTodaysTime
    '    ElseIf mnuNameOption_3.Checked Then
    '        strDefaultName = "Capture_" & strTransectDate & "_" & strTransectTime
    '    ElseIf mnuNameOption_4.Checked Then
    '        strDefaultName = "Capture_" & strTodaysDate & "_" & strTodaysTime
    '    ElseIf mnuNameOption_5.Checked Then
    '        strDefaultName = Me.txtProjectName.Text & "_" & strTransectDate & "_" & strTransectTime
    '    ElseIf mnuNameOption_6.Checked Then
    '        strDefaultName = Me.txtProjectName.Text & "_" & strTodaysDate & "_" & strTodaysTime
    '    ElseIf mnuNameOption_7.Checked Then
    '        strDefaultName = strTransectDate & "_" & strTransectTime
    '    ElseIf mnuNameOption_8.Checked Then
    '        strDefaultName = strTodaysDate & "_" & strTodaysTime
    '    ElseIf MnuNameOption_9.Checked Then
    '        strDefaultName = NULL_STRING
    '    End If

    '    ' Specify the name to be displayed in the save window dialog
    '    Me.svDlgFileDialogScrCap.FileName = strDefaultName
    '    ' Open a save as dialog to specify the path and name for the bitmap.
    '    If Me.svDlgFileDialogScrCap.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
    '        Exit Sub
    '    End If
    '    Dim strFileName As String
    '    strFileName = Me.svDlgFileDialogScrCap.FileName.ToString()
    '    If svDlgFileDialogScrCap.FilterIndex = 2 Then
    '        strFileName = strFileName.Replace("Jpeg", "bmp")
    '    End If
    '    Try
    '        SendKeys.Send("^{PRTSC}")
    '        Application.DoEvents()
    '        Dim screen = Clipboard.GetDataObject
    '        Dim bmp As Bitmap = CType(screen.getdata(GetType(System.Drawing.Bitmap)), Bitmap)
    '        bmp.SetResolution(400, 400)
    '        'bmp.Save(strFileName)

    '        Dim p As System.Drawing.Point = New System.Drawing.Point(0, 0)
    '        Dim screenPosition As System.Drawing.Point = frmVideoPlayer.PointToScreen(p)
    '        Dim rect As New Rectangle(screenPosition.X, screenPosition.Y, frmVideoPlayer.Width, frmVideoPlayer.Height)
    '        Dim cropped As Bitmap = bmp.Clone(rect, bmp.PixelFormat)
    '        cropped.SetResolution(400, 400)
    '        cropped.Save(strFileName, Imaging.ImageFormat.Jpeg)
    '        Clipboard.Clear()
    '        cropped = Nothing
    '    Catch ex As System.OutOfMemoryException
    '        SendKeys.Send("^{PRTSC}")
    '        Application.DoEvents()
    '        Dim screen = Clipboard.GetDataObject
    '        Dim bmp As Bitmap = CType(screen.getdata(GetType(System.Drawing.Bitmap)), Bitmap)
    '        bmp.SetResolution(400, 400)
    '        'bmp.Save(strFileName)
    '        Dim p As System.Drawing.Point = New System.Drawing.Point(0, 0)
    '        Dim screenPosition As System.Drawing.Point = frmVideoPlayer.PointToScreen(p)
    '        Dim rect As New Rectangle(screenPosition.X, screenPosition.Y, frmVideoPlayer.Width, frmVideoPlayer.Height)
    '        Dim cropped As Bitmap = bmp.Clone(rect, bmp.PixelFormat)
    '        cropped.SetResolution(400, 400)
    '        cropped.Save(strFileName, Imaging.ImageFormat.Jpeg)
    '        Clipboard.Clear()
    '        cropped = Nothing
    '    End Try
    '    'Dim CropRect As New Rectangle(screenPosition.X, screenPosition.Y, frmVideoPlayer.Width, frmVideoPlayer.Height)
    '    'Dim CropImage As Bitmap = New Bitmap(CropRect.Width, CropRect.Height)
    '    'Using grp = Graphics.FromImage(CropImage)
    '    '    grp.drawimage(bmp, New Rectangle(0, 0, CropRect.Width, CropRect.Height))
    '    '    CropImage.Save(strFileName)
    '    'End Using

    '    '' Create a graphics object for the live video stream and set the bitmap to be the dimensions of the picture box
    '    'Dim GR As Graphics = frmVideoPlayer.CreateGraphics
    '    'Dim bmpCapture As New Bitmap(frmVideoPlayer.Width, frmVideoPlayer.Height)
    '    'Dim pbhdc As IntPtr = GR.GetHdc     ' Set up a handle to the graphics object
    '    'Dim bmpGraphics As Graphics = Graphics.FromImage(bmpCapture)
    '    'Dim bmpHdc As IntPtr = bmpGraphics.GetHdc

    '    '' Use the library to get a screen capture of the picture box area
    '    'BitBlt(bmpHdc, 0, 0, frmVideoPlayer.Width, frmVideoPlayer.Height, pbhdc, 0, 0, COPY)
    '    'GR.ReleaseHdc(pbhdc)
    '    'bmpGraphics.ReleaseHdc(bmpHdc)

    '    'bmpCapture.Save(strFileName)

    '    Try
    '        'If the user selected *.Jpeg, convert the bmp.
    '        If svDlgFileDialogScrCap.FilterIndex = 2 Then
    '            'Save bmp as jpg 'ConvertBMP(strFileName, ImageFormat.Jpeg)        'ConvertBMP(strFileName, ImageFormat.Emf)        'ConvertBMP(strFileName, ImageFormat.Exif)        'ConvertBMP(strFileName, ImageFormat.Gif)        'ConvertBMP(strFileName, ImageFormat.Icon)        'ConvertBMP(strFileName, ImageFormat.MemoryBmp)        'ConvertBMP(strFileName, ImageFormat.Png)        'ConvertBMP(strFileName, ImageFormat.Tiff)        'ConvertBMP(strFileName, ImageFormat.Wmf)        
    '            ConvertBMP(strFileName, ImageFormat.Jpeg)
    '            'If System.IO.File.Exists(strFileName) = True Then
    '            '    System.IO.File.Delete(strFileName)
    '            'End If

    '        End If
    '    Catch ex As Exception
    '        MsgBox("The file extension you created is invalid, please try again.")
    '        Exit Sub
    '    End Try

    '    Dim strDate() As String
    '    Dim strDateTime As String
    '    strDate = transect_date.Split("/")
    '    strDateTime = strDate(2) & ":" & strDate(1) & ":" & strDate(0)
    '    strDateTime = strDateTime & " " & Me.txtTime.Text
    '    Dim arguments As String
    '    Dim exePathStr As String = System.Windows.Forms.Application.ExecutablePath.ToString()
    '    Dim command As String = String.Concat(NULL_STRINGNULL_STRING, exePathStr.Substring(0, exePathStr.LastIndexOf("\") + 1), "exiftool.exe")
    '    arguments = String.Concat(NULL_STRINGNULL_STRING, " -FileModifyDate=", DoubleQuote(strDateTime) & " ", NULL_STRINGNULL_STRING, strFileName, NULL_STRINGNULL_STRING)
    '    Console.WriteLine(command & arguments)
    '    'MsgBox(command & arguments)
    '    Dim oProcess As New Process()
    '    Dim oStartInfo As New ProcessStartInfo(command & arguments)
    '    'oStartInfo.Arguments = arguments
    '    oStartInfo.UseShellExecute = False
    '    oStartInfo.RedirectStandardOutput = True
    '    oProcess.StartInfo = oStartInfo
    '    oProcess.StartInfo.CreateNoWindow = True
    '    oProcess.Start()
    '    Dim sOutput As String
    '    Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
    '        sOutput = oStreamReader.ReadToEnd()
    '    End Using
    '    Console.WriteLine(sOutput)
    '    Dim strFileNamePath As String
    '    strFileNamePath = Path.GetFileName(strFileName)
    '    Me.FileName = Mid(Me.FileName, 1, 50)
    '    Me.ScreenCaptureName = strFileNamePath
    '    If Not frmSpeciesEvent Is Nothing Then
    '        frmSpeciesEvent.cmdScreenCapture.BackColor = Color.LimeGreen
    '    End If
    '    If Not frmTableView Is Nothing Then
    '        frmTableView.cmdScreenCapture.BackColor = Color.LimeGreen
    '    End If
    '    If blScreenCaptureCalled = False Then
    '        ' Next, write a transection to the database
    '        Dim numrows As Integer
    '        Dim query As String
    '        Dim oComm As OleDbCommand


    '        strSpeciesCode = NS
    '        strSpeciesCount = NS
    '        strSide = NS
    '        strRange = NS
    '        strLength = NS
    '        strHeight = NS
    '        strWidth = NS
    '        strAbundance = NS
    '        strIdConfidence = NS
    '        strComment = "Screen Capture"

    '        query = createInsertQuery(transect_date, "Screen Capture", strVideoTime, strVideoTextTime, strVideoDecimalTime, "555", NS, strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)
    '        Me.ScreenCaptureName = NULL_STRING

    '        ' Write this transaction to the database if open.
    '        Try
    '            oComm = New OleDbCommand(query, conn)
    '            numrows = oComm.ExecuteNonQuery()
    '            fetch_data()
    '        Catch ex As Exception
    '            If ex.Message.StartsWith("Syntax") Then
    '                MsgBox(ex.Message & vbCrLf & ex.StackTrace & " " & query)
    '            Else
    '                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
    '            End If
    '            Exit Sub
    '        End Try
    '    End If

    'End Sub

    'Private Sub VaryQualityLevel(ByVal strFilePath As String)
    '    ' Get a bitmap. 
    '    Dim bmp1 As New Bitmap(strFilePath)
    '    Dim jgpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)

    '    ' Create an Encoder object based on the GUID 
    '    ' for the Quality parameter category. 
    '    Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

    '    ' Create an EncoderParameters object. 
    '    ' An EncoderParameters object has an array of EncoderParameter 
    '    ' objects. In this case, there is only one 
    '    ' EncoderParameter object in the array. 
    '    Dim myEncoderParameters As New EncoderParameters(1)

    '    Dim myEncoderParameter As New EncoderParameter(myEncoder, 100&)
    '    myEncoderParameters.Param(0) = myEncoderParameter
    '    bmp1.Save(strFilePath, jgpEncoder, myEncoderParameters)

    'End Sub 'VaryQualityLevel

    'Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo

    '    Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

    '    Dim codec As ImageCodecInfo
    '    For Each codec In codecs
    '        If codec.FormatID = format.Guid Then
    '            Return codec
    '        End If
    '    Next codec
    '    Return Nothing

    'End Function
    ' ==========================================================================================================
    ' Name: mnuOpenImg_Click
    ' Description: Select the image file for processing, extracting EXIF info as well, also get all the images under
    '              selected directory.
    '              This function is called when the user selects "File->Open Image File"
    ' ==========================================================================================================
    Private Sub mnuOpenImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenImg.Click

        If Not frmVideoPlayer Is Nothing Then

            Dim intAnswer As Integer

            intAnswer = MessageBox.Show("The video file '" & Me.FileName & "' is currently open.  In order to open an image, the video will be closed.  Do you want to continue?", "Video File Open", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If intAnswer = vbNo Then
                Exit Sub
            Else
                frmVideoPlayer.Close()
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
            If frmImage Is Nothing Then
                frmImage = New frmImage
                pnlImageControls.Visible = True
                pnlVideoControls.Visible = False

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
                    frmImage.Location = aPoint
                    frmImage.WindowState = FormWindowState.Normal
                Else
                    aPoint.X = intX + priMon.Bounds.Width
                    aPoint.Y = intY / 2
                    frmImage.Location = aPoint
                    frmImage.WindowState = FormWindowState.Maximized
                End If

                frmImage.Show()
            End If
            currentImage = strFileName
            'frmImage.PictureBox1.Image = Image.FromFile(strFileName)
            'frmImage.Text = strFileName.Substring(strFileName.LastIndexOf("\") + 1, (strFileName.Length - strFileName.LastIndexOf("\") - 1))
            Me.FileName = strFileName.Substring(strFileName.LastIndexOf("\") + 1, (strFileName.Length - strFileName.LastIndexOf("\") - 1))

            ' set the flag "image_open" to be true.
            image_open = True
            ' Store the path of the current folder so that we can read 
            ' all the images under the current directory
            imagePath = strFileName.Substring(0, strFileName.LastIndexOf("\") + 1)
            Dim allFiles As String() = Directory.GetFiles(imagePath)
            Dim cur_folder_files As String = NULL_STRING
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

                frmImage.PictureBox1.Image = New Bitmap(imagePath & imageFilesList(intIndex))
                frmImage.Text = imageFilesList(intIndex)
                image_index = intIndex
                getEXIFData()
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
                Me.txtTransectDate.Text = m_transect_date
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

            enableDisableImageMenu(True)

        End If
    End Sub

    ' ======================================Code by Xida Chen (end)===========================================

    ''' <summary>
    ''' Add a new project name to the XML file when the user changes it inside frmProjectNames
    ''' </summary>
    Private Sub newProjectName() Handles frmProjectNames.NewProjectNameEvent
        ' Add the new item to the current collection of items and also write it into the XML file
        Dim name As String = frmProjectNames.getProjectName()
        m_PreviousProjects.Add(name, name) ' Key and value are identical, needed for removing from the collection which needs the key
        SaveConfiguration("/PreviousProjects/ProjectName", frmProjectNames.getProjectName(), vbTrue)
    End Sub

    ''' <summary>
    ''' Change the project name to what was chosen in the frmProjectName form.
    ''' </summary>
    Private Sub project_name_changed() Handles frmProjectNames.ProjectNameChangedEvent
        txtProjectName.Text = frmProjectNames.getProjectName()
    End Sub

    ''' <summary>
    ''' Delete the project name currently selected in the frmProjectName form.
    ''' </summary>
    Private Sub project_name_delete() Handles frmProjectNames.DeleteProjectNameEvent
        ' Delete the name from the XML file and current collection
        Dim key As String = frmProjectNames.getProjectNameToDelete()
        m_PreviousProjects.Remove(key)
        If Not DeleteXMLNode("/PreviousProjects/ProjectName", frmProjectNames.getProjectNameToDelete()) Then
            MessageBox.Show("Error - failed to delete the node from the XML file. Check the file and retry.", "Failed to edit XML file", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtProjectName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectName.Click
        If frmProjectNames Is Nothing Then
            frmProjectNames = New frmProjectNames
        End If
        frmProjectNames.PopulateProjectList(m_PreviousProjects)
        frmProjectNames.ShowDialog()
    End Sub

    Private Sub txtProjectName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectName.Leave
        m_project_name = txtProjectName.Text
    End Sub

    Private Sub txtTransectDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransectDate.Click
        Me.txtTransectDate.ForeColor = Color.Black
        Me.mnthCalendar.Visible = True
        Me.cmdCloseCalendar.Visible = True
    End Sub

    Private Sub mnthCalendar_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mnthCalendar.DateSelected
        Me.txtTransectDate.Text = AddZeros(Me.mnthCalendar.SelectionStart.Day, 2) & "/" & AddZeros(Me.mnthCalendar.SelectionStart.Month, 2) & "/" & Me.mnthCalendar.SelectionStart.Year
        m_transect_date = Me.txtTransectDate.Text
        Me.mnthCalendar.Visible = False
        Me.cmdCloseCalendar.Visible = False
    End Sub

    Private Sub cmdCloseCalendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseCalendar.Click
        Me.mnthCalendar.Visible = False
        Me.cmdCloseCalendar.Visible = False
    End Sub

    Private Sub cmdDefineAllSpatialVariables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefineAllSpatialVariables.Click
        Dim query As String = NULL_STRING
        Dim strCode As String = NULL_STRING
        Dim strName As String = NULL_STRING
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
        If m_video_file_open Then
            If frmVideoPlayer.IsPlaying Then
                blVideoWasPlaying = True
                pauseVideo()
            Else
                blVideoWasPlaying = False
            End If
            strVideoTime = frmVideoPlayer.CurrentVideoTimeFormatted
            strVideoTextTime = strVideoTime
        End If

        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.

            ' The GPRMC NMEA String does not contain elevation values. Enter null into database
            ' if GPRMC is the chosen string type.
            blAquiredFix = getGPSData(strVideoTime, strVideoDecimalTime, "", "", "")
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If
        strVideoTextTime = strVideoTime
        ' If an image is open and a video is closed, get the photo information from the EXIF file
        If image_open And m_video_file_open = False Then
            getEXIFData()
            strVideoTextTime = strVideoTime
        End If

        Try

            Dim i As Integer
            For i = 0 To strHabitatButtonCodeNames.Length - 2

                If strHabitatButtonTables(i) = "UserEntered" Then
                    Dim strValue As String
                    frmAddValue = New frmAddValue(dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString))
                    frmAddValue.lblExpression.Text = "Please enter a value for " & strHabitatButtonNames(i) & ":"
                    frmAddValue.Text = strHabitatButtonNames(i) & " Entry"
                    frmAddValue.cmdCancel.Text = "Skip"
                    frmAddValue.ShowDialog()

                    strValue = frmAddValue.strValue

                    strHabitatButtonUserCodeChoice(i) = strValue
                    frmAddValue.Close()
                    frmAddValue = Nothing
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
                        strCode = sub_form.DataGridView1.SelectedRows(0).Cells(0).Value & NULL_STRING
                        strHabitatButtonUserCodeChoice(i) = strCode
                        dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = strHabitatButtonUserCodeChoice(i).ToString
                        dictTempHabitatFieldValues(strHabitatButtonCodeNames(i).ToString) = strHabitatButtonUserCodeChoice(i).ToString

                        strName = sub_form.DataGridView1.SelectedRows(0).Cells(1).Value & NULL_STRING

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

            query = createInsertQuery(ALL_HABITAT_VARIABLES_CLEARED, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
            Me.ScreenCaptureName = NULL_STRING
            Dim numrows As Integer
            Database.ExecuteNonQuery(query)
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

    ''' <summary>
    ''' When user clicks this button, it is the same as if they clicked all the transect variable buttons in sequence.
    ''' This is a convinience button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdDefineAllTransectVariables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefineAllTransectVariables.Click
        Dim query As String = NULL_STRING
        Dim strCode As String = NULL_STRING
        Dim strName As String = NULL_STRING
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
        If m_video_file_open Then
            If frmVideoPlayer.IsPlaying Then
                blVideoWasPlaying = True
                pauseVideo()
            Else
                blVideoWasPlaying = False
            End If
            strVideoTime = frmVideoPlayer.CurrentVideoTimeFormatted
        End If

        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.

            ' The GPRMC NMEA String does not contain elevation values. Enter null into database
            ' if GPRMC is the chosen string type.
            blAquiredFix = getGPSData(strVideoTime, strVideoDecimalTime, "", "", "")
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If
        strVideoTextTime = strVideoTime
        ' If an image is open and a video is closed, get the photo information from the EXIF file
        If image_open And m_video_file_open = False Then
            getEXIFData()
            strVideoTextTime = strVideoTime
        End If
        Try
            Dim i As Integer
            For i = 0 To strTransectButtonCodeNames.Length - 2

                If strTransectButtonTables(i) = "UserEntered" Then
                    Dim strValue As String
                    frmAddValue = New frmAddValue(dictTransectFieldValues(strTransectButtonCodeNames(i).ToString))
                    frmAddValue.lblExpression.Text = "Please enter a value for " & strTransectButtonNames(i) & ":"
                    frmAddValue.Text = strTransectButtonNames(i) & " Entry"
                    frmAddValue.cmdCancel.Text = "Skip"
                    frmAddValue.ShowDialog()

                    strValue = frmAddValue.strValue
                    frmAddValue.Close()
                    frmAddValue = Nothing
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
                        strCode = sub_form.DataGridView1.SelectedRows(0).Cells(0).Value & NULL_STRING
                        strTransectButtonUserCodeChoice(i) = strCode
                        dictTransectFieldValues(strTransectButtonCodeNames(i).ToString) = strTransectButtonUserCodeChoice(i).ToString

                        strName = sub_form.DataGridView1.SelectedRows(0).Cells(1).Value & NULL_STRING

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

            If Me.strComment <> NULL_STRING Then
                query = createInsertQuery(intTransectButtonCodes(i), NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                Database.ExecuteNonQuery(query)
                fetch_data()
            End If
            Me.strComment = NULL_STRING
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

        Dim tc As TimeSpan = New TimeSpan(VIDEO_TIME_LABEL)

        Dim strVideoTime As String = VIDEO_TIME_LABEL
        Dim strVideoTextTime As String = VIDEO_TIME_LABEL
        Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
        Dim strX As String = NS
        Dim strY As String = NS
        Dim strZ As String = NS

        Dim query As String = NULL_STRING
        Try
            If m_video_file_open Then
                'pauseVideo()
                tc = getTimeCode()
                strVideoTime = frmVideoPlayer.CurrentVideoTimeFormatted
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

                    query = createInsertQuery(NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                    Database.ExecuteNonQuery(query)
                    fetch_data()
                    Exit Sub
                End If
            End If
            If booUseGPSTimeCodes Then
                'Otherwise get the time from the NMEA string. 

                ' The GPRMC NMEA String does not contain elevation values. Enter null into database
                ' if GPRMC is the chosen string type.
                getGPSData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)

                'intGPSSeconds = CInt(Mid(tc, 7, 2))

                If blGPSFirstTime Then
                    intPreviousGPSSeconds = intGPSSeconds
                    blGPSFirstTime = False
                End If

                If intGPSSeconds = intPreviousGPSSeconds Then
                    Exit Sub
                Else
                    intPreviousGPSSeconds = intGPSSeconds
                    query = createInsertQuery(NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                    Database.ExecuteNonQuery(query)
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

    '    If frmVideoPlayer Is Nothing Then
    '        tmrPlayForSeconds.Stop()
    '        Exit Sub
    '    End If
    '    dblCurrentSeconds = frmVideoPlayer.dblCurrentVideoTime

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
    '        frmVideoPlayer.blIsPlaying = False
    '        Me.tmrPlayForSeconds.Enabled = False
    '        If Me.chkDefineAll.Checked = True Then
    '            Me.cmdDefineAllTransectVariables_Click(sender, e)
    '            Me.cmdDefineAllSpatialVariables_Click(sender, e)
    '        End If
    '    End If
    '    If Me.chkRecordEachSecond.Checked = True Then
    '        Dim query As String = NULL_STRING
    '        Dim strX As String = NS
    '        Dim strY As String = NS
    '        Dim strZ As String = NS

    '        If blFirstTime Then
    '            intPreviousVideoSeconds = intCurrentPlaySeconds
    '            blFirstTime = False
    '        End If

    '        If intCurrentPlaySeconds <> intPreviousVideoSeconds Then
    '            Try
    '                intPreviousVideoSeconds = intCurrentPlaySeconds

    '                strSpeciesCode = NS
    '                strSpeciesCount = NS
    '                strSide = NS
    '                strRange = NS
    '                strLength = NS
    '                strHeight = NS
    '                strWidth = NS
    '                strAbundance = NS
    '                strIdConfidence = NS
    '                strComment = NS

    '                query = createInsertQuery(transect_date, transect_name, strPlaySecondsVideoTime, strVideoTextTime, strVideoDecimalTime, NS, NS, strX, strY, strZ, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)

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
            Dim tc As TimeSpan = New TimeSpan(VIDEO_TIME_LABEL)

            Dim strVideoTime As String = VIDEO_TIME_LABEL
            Dim strVideoTextTime As String = VIDEO_TIME_LABEL
            Dim strVideoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL
            Dim strX As String = NULL_STRING
            Dim strY As String = NULL_STRING
            Dim strZ As String = NULL_STRING

            If Not frmVideoPlayer Is Nothing Then
                'If frmVideoPlayer.blIsPlaying Then

                tc = getTimeCode()
                strVideoTime = frmVideoPlayer.CurrentVideoTimeFormatted
                strVideoTextTime = strVideoTime
                intPreviousVideoSeconds = CInt(Mid(strVideoTime, 7, 2))
                If frmVideoPlayer.IsPlaying Then
                    Me.tmrRecordPerSecond.Start()
                End If
                'End If
            Else
                Me.tmrRecordPerSecond.Start()
                'getGPSData(tc, strVideoTime, strX, strY, strZ)

            End If

        End If
    End Sub

    Private Sub cmdAddComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddComment.Click

        Dim tc As TimeSpan = New TimeSpan(VIDEO_TIME_LABEL)


        Dim strX As String = NS
        Dim strY As String = NS
        Dim strZ As String = NS
        Dim query As String
        Dim blAquiredFix As Boolean = False

        strComment = InputBox("Enter a comment to be inserted as a record", "Enter Comment")
        If strComment = NULL_STRING Then
            If m_video_file_open Then
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
        If m_video_file_open Then
            pauseVideo()
            tc = getTimeCode()
            strVideoTime = frmVideoPlayer.CurrentVideoTimeFormatted

        End If
        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.

            ' The GPRMC NMEA String does not contain elevation values. Enter null into database
            ' if GPRMC is the chosen string type.
            blAquiredFix = getGPSData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If
        strVideoTextTime = strVideoTime
        Dim strCode As String = NULL_STRING
        Dim strName As String = NULL_STRING

        ' If the image is open and the video is closed then get the picture information from the EXIF file
        If image_open And m_video_file_open = False Then

            getEXIFData()
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

            If tc.ToString() <> NULL_STRING Then
                ' Insert new record in database
                Dim numrows As Integer

                query = createInsertQuery(COMMENT_ADDED, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                Database.ExecuteNonQuery(query)
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

        If m_db_file_open = True Then
            Dim tc As String = VIDEO_TIME_LABEL

            Dim strX As String = NS
            Dim strY As String = NS
            Dim strZ As String = NS
            Dim query As String = NULL_STRING
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
                    blAquiredFix = getGPSData(strPhotoTime, strPhotoDecimalTime, strX, strY, strZ)
                    If Not blAquiredFix Then
                        Exit Sub
                    End If
                End If
                strPhotoTextTime = strPhotoTime
                Dim strCode As String = NULL_STRING
                Dim strName As String = NULL_STRING

                If image_open And m_video_file_open = False Then

                    getEXIFData()
                    strPhotoTextTime = strPhotoTime

                End If

                If tc <> NULL_STRING Then

                    ' Insert new record in database
                    Dim numrows As Integer

                    query = createInsertQuery(NOTHING_IN_PHOTO, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                    Database.ExecuteNonQuery(query)
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
        If Not frmSpeciesEvent Is Nothing Then
            frmSpeciesEvent.Dispose()
            frmSpeciesEvent = Nothing
        End If

        frmConfigureSpecies = New frmConfigureSpecies
        frmConfigureSpecies.ShowDialog()

    End Sub

#End Region

#Region "Video Miner Functions"

    ''' <summary>
    ''' Open a session which has saved the previous state of the program in VideoMiner Session file (*.xml)
    ''' This will open the video that was being played when the session was saved.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub openSession()
        Try
            Dim ofd As OpenFileDialog = New OpenFileDialog
            ofd.Title = "Open Session"
            ofd.InitialDirectory = m_strSessionPath
            ofd.Filter = "XML Files (*.xml)|*.xml"
            ofd.FilterIndex = 1
            ofd.RestoreDirectory = True
            ofd.Multiselect = False

            ofd.ShowDialog()

            Dim strFileName As String = ofd.FileName

            ' Store the chosen session path in the XML file
            m_strSessionPath = Path.GetDirectoryName(ofd.FileName)
            SaveConfiguration("/SessionPath", m_strSessionPath)
            Me.SessionName = strFileName

            If strFileName = NULL_STRING Or Not System.IO.File.Exists(strFileName) Then
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

            'CJG need to fix getconfiguration to take a config filename for this
            blVideoOpen = GetConfiguration("SessionConfiguration/Video/Open")
            strVideoFileName = GetConfiguration("SessionConfiguration/Video/FileName")
            strVideoTime = GetConfiguration("SessionConfiguration/Video/Position")

            blImageOpen = GetConfiguration("SessionConfiguration/Image/Open")
            strImageFileName = GetConfiguration("SessionConfiguration/Image/FileName")

            blDatabaseOpen = GetConfiguration("SessionConfiguration/Database/Open")
            strDatabaseFileName = GetConfiguration("SessionConfiguration/Database/FileName")
            strNumberRecordsShown = GetConfiguration("SessionConfiguration/Database/NumberRecordsShown")

            If blDatabaseOpen = True Then
                If Not Me.grdVideoMinerDatabase.DataSource Is Nothing Then
                    CloseDatabase_Click(Nothing, Nothing)
                End If
                openDatabase()
                files_loaded()
                m_strDatabaseFilePath = strDatabaseFileName
            End If

            If blImageOpen = True Then
                If Not frmImage Is Nothing Then
                    frmImage.Close()
                End If
                If frmImage Is Nothing Then
                    frmImage = New frmImage
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
                        frmImage.Location = aPoint
                        frmImage.WindowState = FormWindowState.Normal
                    Else
                        aPoint.X = intX + priMon.Bounds.Width
                        aPoint.Y = intY / 2
                        frmImage.Location = aPoint
                        frmImage.WindowState = FormWindowState.Maximized
                    End If

                    frmImage.Show()
                End If
                currentImage = strFileName
                frmImage.PictureBox1.Image = Image.FromFile(strImageFileName)
                frmImage.Text = strImageFileName.Substring(strImageFileName.LastIndexOf("\") + 1, (strImageFileName.Length - strImageFileName.LastIndexOf("\") - 1))
                Me.FileName = strImageFileName.Substring(strImageFileName.LastIndexOf("\") + 1, (strImageFileName.Length - strImageFileName.LastIndexOf("\") - 1))

                ' set the flag "image_open" to be true.
                image_open = True
                ' Store the path of the current folder so that we can read 
                ' all the images under the current directory
                Dim imagePath As String = strImageFileName.Substring(0, strImageFileName.LastIndexOf("\") + 1)
                Dim allFiles As String() = Directory.GetFiles(imagePath)
                Dim cur_folder_files As String = NULL_STRING
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
                enableDisableImageMenu(True)
            End If
            If blVideoOpen Then
                If Not frmVideoPlayer Is Nothing Then
                    frmVideoPlayer.Close()
                End If
                'current_directory = strVideoFileName.Substring(0, strVideoFileName.LastIndexOf("\"))
                strVideoFilePath = strVideoFileName
                Me.FileName = strVideoFilePath.Substring(strVideoFilePath.LastIndexOf("\") + 1, strVideoFilePath.Length - strVideoFilePath.LastIndexOf("\") - 1)
                If frmVideoPlayer Is Nothing Then
                    frmVideoPlayer = New frmVideoPlayer(FileName, VIDEO_TIME_FORMAT)
                    frmVideoPlayer.pnlHideVideo.Visible = True
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
                        frmVideoPlayer.Location = aPoint
                        frmVideoPlayer.WindowState = FormWindowState.Normal
                        'frmVideoPlayer.TopMost = True
                    Else
                        aPoint.X = intX + priMon.Bounds.Width
                        aPoint.Y = intY / 2
                        frmVideoPlayer.Location = aPoint
                        frmVideoPlayer.WindowState = FormWindowState.Maximized
                        'frmVideoPlayer.TopMost = True
                    End If
                    Me.VideoTime = Parse(strVideoTime)
                    frmVideoPlayer.Show()

                Else
                    frmVideoPlayer.pnlHideVideo.Visible = True
                    frmVideoPlayer.frmVideoPlayer_Load(Me, New System.EventArgs)
                End If
            End If
            Me.Text = "Video Miner  " & Me.Version & " - " & Me.SessionName.Substring(Me.SessionName.LastIndexOf("\") + 1, (Me.SessionName.Length - 4) - Me.SessionName.LastIndexOf("\") - 1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception was thrown", MessageBoxButtons.OK)
        End Try
    End Sub

    ''' <summary>
    ''' Save the session, i.e. which database and which video and the video's position
    ''' </summary>
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

            If Not frmVideoPlayer Is Nothing Then
                blVideoOpen = True
                strVideoFileName = strVideoFilePath
                'strVideoTime = CStr(frmVideoPlayer.Ctlcontrols.currentPosition)
                strVideoTime = CStr(frmVideoPlayer.Position)
            Else
                blVideoOpen = False
                strVideoFileName = NS
                strVideoTime = NS
            End If

            If Not frmImage Is Nothing Then
                blImageOpen = True
                strImageFileName = currentImage
            Else
                blImageOpen = False
                strImageFileName = NS
            End If

            If Not Me.grdVideoMinerDatabase.DataSource Is Nothing Then
                blDatabaseOpen = True
                strDatabaseFileName = m_strDatabaseFilePath
                strNumberRecordsShown = CStr(intNumberDisplayRecords)
            Else
                blDatabaseOpen = False
                strDatabaseFileName = NS
                strNumberRecordsShown = NS
            End If


            SaveConfiguration("SessionConfiguration/Video/Open", blVideoOpen)
            SaveConfiguration("SessionConfiguration/Video/FileName", strVideoFileName)
            SaveConfiguration("SessionConfiguration/Video/Position", strVideoTime)

            SaveConfiguration("SessionConfiguration/Image/Open", blImageOpen)
            SaveConfiguration("SessionConfiguration/Image/FileName", strImageFileName)

            SaveConfiguration("SessionConfiguration/Database/Open", blDatabaseOpen)
            SaveConfiguration("SessionConfiguration/Database/FileName", strDatabaseFileName)
            SaveConfiguration("SessionConfiguration/Database/NumberRecordsShown", strNumberRecordsShown)

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
        sfd.InitialDirectory = m_strSessionPath
        sfd.Filter = "XML Files (*.xml)|*.xml"
        sfd.RestoreDirectory = True

        sfd.ShowDialog()

        Dim strFileName As String = NULL_STRING
        strFileName = sfd.FileName
        Me.SessionName = strFileName

        If strFileName = NULL_STRING Then
            Exit Sub
        End If
        'If System.IO.File.Exists(strFileName) Then
        '    saveSession()
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

        If Not frmVideoPlayer Is Nothing Then
            blVideoOpen = True
            strVideoFileName = strVideoFilePath
            strVideoTime = CStr(frmVideoPlayer.Position)
        Else
            blVideoOpen = False
            strVideoFileName = NS
            strVideoTime = NS
        End If

        If Not frmImage Is Nothing Then
            blImageOpen = True
            strImageFileName = currentImage
        Else
            blImageOpen = False
            strImageFileName = NS
        End If

        If Not Me.grdVideoMinerDatabase.DataSource Is Nothing Then
            blDatabaseOpen = True
            strDatabaseFileName = m_strDatabaseFilePath
            strNumberRecordsShown = CStr(intNumberDisplayRecords)
        Else
            blDatabaseOpen = False
            strDatabaseFileName = NS
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


        'SaveConfiguration(strFileName, "SaveSessionConfiguration/Video/Open", blVideoOpen)
        'SaveConfiguration(strFileName, "SaveSessionConfiguration/Video/FileName", strVideoFileName)
        'SaveConfiguration(strFileName, "SaveSessionConfiguration/Video/Position", strVideoTime)

        'SaveConfiguration(strFileName, "SaveSessionConfiguration/Image/Open", blImageOpen)
        'SaveConfiguration(strFileName, "SaveSessionConfiguration/Image/FileName", strImageFileName)

        'SaveConfiguration(strFileName, "SaveSessionConfiguration/Database/Open", blDatabaseOpen)
        'SaveConfiguration(strFileName, "SaveSessionConfiguration/Database/FileName", strDatabaseFileName)
        'SaveConfiguration(strFileName, "SaveSessionConfiguration/Database/NumberRecordsShown", strNumberRecordsShown)


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

    ''' <summary>
    ''' Function to save the XML settings to a file
    ''' </summary>
    ''' <param name="strPath"></param>
    ''' <param name="strValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Save_XmlSettings(ByVal strPath As String, ByVal strValue As String) As Boolean
        If File.Exists(m_strConfigFile) Then
            ' Load the config file into the document object
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(m_strConfigFile)

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
            xmlDoc.Save(m_strConfigFile)
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

    ''' <summary>
    ''' Return the current timecode.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function getTimeCode() As TimeSpan
        Return m_tsUserTime
    End Function

    ''' <summary>
    ''' Enable or disable the video menu items
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub toggleVideoMenu(ByVal mnuState As Boolean)
        ' Enable (mnuState=True) or Disable (mnuState=False) the menu item for opening video or opening external video
        Dim mnuItem As ToolStripMenuItem
        For Each mnuItem In mnuVideoTools.DropDownItems
            If mnuItem.Text = OPEN_VID_TITLE Or mnuItem.Text = OPEN_EXT_VID Then
                mnuItem.Enabled = mnuState
            Else
                mnuItem.Enabled = Not mnuState
            End If
        Next
    End Sub
    ''' <summary>
    ''' Returns the filename without its path
    ''' </summary>
    ''' <remarks></remarks>
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
        cmdOffBottom.Enabled = False
        cmdUpdateDatabase.Visible = False
        cmdRevertDatabase.Visible = False
        lblDirtyData.Visible = False
        'Me.cmdEdit.Enabled = False
    End Sub

    ''' <summary>
    ''' Toggle enabled/disabled for: Set Time Code Button, Transect Start Button, On/Off Bottom Button, Resume Video Button
    ''' </summary>
    Private Sub files_loaded()
        cmdShowSetTimecode.Enabled = True
        cmdTransectStart.Enabled = True
        cmdOffBottom.Enabled = True
        'ResumeVideo.Enabled = True
        Me.radQuickEntry.Visible = True
        Me.radDetailedEntry.Visible = True
        Me.radAbundanceEntry.Visible = True
        Me.cmdEdit.Visible = True
        Me.cmdUpdateDatabase.Visible = True
        Me.cmdRevertDatabase.Visible = True
        Me.lblDirtyData.Visible = True
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

            If tc = NULL_STRING Then
                tc = VIDEO_TIME_LABEL
            End If
            Dim query As String = NULL_STRING

            Try
                query = createInsertQuery(ON_OFF_BOTTOM, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                Database.ExecuteNonQuery(query)
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

        Dim strZeros As String = NULL_STRING
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

    Private Function getGPSData(ByRef strVideoTime As String, ByRef strVideoDecimalTime As String, ByRef strX As String, ByRef strY As String, ByRef strZ As String) As Boolean
        strX = Me.lblXValue.Text
        strY = Me.lblYValue.Text
        strZ = Me.lblZValue.Text
        strVideoDecimalTime = strVideoTime & ".00"
        Return True

    End Function

#End Region

#Region "Image Functions"

    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean


    '    If Not frmImage Is Nothing Then
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
    '                ' this function to load the image and display it in the window
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
    '                ' this function to load the image and display it in the window
    '                LoadImg()

    '            Case Else
    '                Return MyBase.ProcessCmdKey(msg, keyData)

    '        End Select
    '    End If
    'End Function


    Private Sub getEXIFData()
        Me.lblGPSLocation.Visible = False
        Me.lblX.Visible = False
        Me.lblXValue.Visible = False
        Me.lblY.Visible = False
        Me.lblYValue.Visible = False
        Me.lblZ.Visible = False
        Me.lblZValue.Visible = False
        Dim arguments As String
        Dim exePathStr As String = System.Windows.Forms.Application.ExecutablePath.ToString()
        Dim command As String = String.Concat(NULL_STRING, NULL_STRING, exePathStr.Substring(0, exePathStr.LastIndexOf("\") + 1), "exiftool.exe")
        arguments = String.Concat(NULL_STRING, NULL_STRING, " -s ", NULL_STRING, NULL_STRING, imagePath & Me.FileName, NULL_STRING, NULL_STRING)
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
        Dim strDate As String = NULL_STRING
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
        Dim strFileDate As String = NULL_STRING
        Dim strFileTime As String = NULL_STRING
        ' Read the line that has "DateTimeOriginal".
        ' TODO: Go over this whole algorithm. It is a big mess.
        Dim strPhotoDecimalTime As String
        For i = 0 To strEXIFOutput.Length - 1
            If strEXIFOutput(i).Contains("DateTimeOriginal") And Not strEXIFOutput(i).Contains("SubSec") Then
                strLine = strEXIFOutput(i)
                strItems = strLine.Split(":")
                strDate = strItems(3).Substring(0, 2) & "/" & strItems(2) & "/" & strItems(1).Substring(1, 4)
                m_transect_date = strDate

                'strPhotoTime = ToMilitaryTime(strItems(3).Substring(3, 2) & ":" & strItems(4) & ":" & strItems(5))
                strPhotoDecimalTime = m_tsUserTime.ToString()
                blDateTime = True
            ElseIf strEXIFOutput(i).Contains("DateTimeOriginal") And strEXIFOutput(i).Contains("SubSec") Then
                strLine = strEXIFOutput(i)
                strItems = strLine.Split(":")
                strDate = strItems(3).Substring(0, 2) & "/" & strItems(2) & "/" & strItems(1).Substring(1, 4)
                m_transect_date = strDate
                strPhotoDecimalTime = strItems(3).Substring(3, 2) & ":" & strItems(4) & ":" & strItems(5)
                'strPhotoTime = ToMilitaryTime(strPhotoDecimalTime)
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
                strGPS = strItems(1).Replace(" ", NULL_STRING)
                If strGPS.Contains("N") Then
                    intNegative = 1
                    strGPS = strGPS.Replace("N", NULL_STRING)
                ElseIf strGPS.Contains("S") Then
                    intNegative = -1
                    strGPS = strGPS.Replace("S", NULL_STRING)
                End If
                strGPS = strGPS.Replace("deg", "/")
                strGPS = strGPS.Replace("'", "/")

                strGPSSplit = strGPS.Split("/")
                dblDegrees = CDbl(strGPSSplit(0))
                dblMinutes = CDbl(strGPSSplit(1))
                dblSeconds = CDbl(strGPSSplit(2))
                'strY = FormatNumber((dblDegrees + (dblMinutes / 60) + (dblSeconds / 3600)) * intNegative, 5)
                blY = True
                Me.lblGPSLocation.Visible = True
                Me.lblGPSLocation.Text = "EXIF Location"
                Me.lblY.Visible = True
                Me.lblYValue.Visible = True
            ElseIf strEXIFOutput(i).Contains("GPSLongitude") And Not strEXIFOutput(i).Contains("Ref") Then
                strLine = strEXIFOutput(i)
                strItems = strLine.Split(":")
                strGPS = strItems(1).Replace(" ", NULL_STRING)
                If strGPS.Contains("E") Then
                    intNegative = 1
                    strGPS = strGPS.Replace("E", NULL_STRING)
                ElseIf strGPS.Contains("W") Then
                    intNegative = -1
                    strGPS = strGPS.Replace("W", NULL_STRING)
                End If
                strGPS = strGPS.Replace("deg", "/")
                strGPS = strGPS.Replace("'", "/")
                strGPS = strGPS.Replace("W", NULL_STRING)
                strGPSSplit = strGPS.Split("/")
                dblDegrees = CDbl(strGPSSplit(0))
                dblMinutes = CDbl(strGPSSplit(1))
                dblSeconds = CDbl(strGPSSplit(2))
                'strX = FormatNumber((dblDegrees + (dblMinutes / 60) + (dblSeconds / 3600)) * intNegative, 5)
                blX = True
                Me.lblGPSLocation.Visible = True
                Me.lblGPSLocation.Text = "EXIF Location"
                Me.lblX.Visible = True
                Me.lblXValue.Visible = True
            ElseIf strEXIFOutput(i).Contains("GPSAltitude") And Not strEXIFOutput(i).Contains("Ref") Then
                strLine = strEXIFOutput(i)
                strItems = strLine.Split(":")
                strGPS = strItems(1).Replace(" ", NULL_STRING)
                If strGPS.Contains("AboveSeaLevel") Then
                    intNegative = 1
                    strGPS = strGPS.Replace("AboveSeaLevel", NULL_STRING)
                ElseIf strGPS.Contains("BelowSeaLevel") Then
                    intNegative = -1
                    strGPS = strGPS.Replace("BelowSeaLevel", NULL_STRING)
                End If
                strGPS = strGPS.Replace("m", NULL_STRING)
                ' TODO: See what this does
                'strZ = FormatNumber(CDbl(strGPS) * intNegative, 2)
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
                    m_transect_date = NULL_STRING
                    'strPhotoTime = NULL_STRING
                Else
                    m_transect_date = strFileDate
                    'strPhotoTime = strFileTime
                    strPhotoDecimalTime = m_tsUserTime.ToString()
                End If
            End If
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
        Me.cboZoom.Text = NULL_STRING
    End Sub

    Private Sub cboZoom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZoom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim intValue As Integer = 0
            Dim intImageSize As Double = 0
            Dim w As Integer = 0
            Dim h As Integer = 0
            Dim strZoomValue As String = NULL_STRING
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
        numericTextboxValidation(e)
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
            frmImage.PictureBox1.Image.Dispose()
            frmImage.PictureBox1.Image = Nothing
            GC.Collect()
            frmImage.PictureBox1.Width = w
            frmImage.PictureBox1.Height = h
            frmImage.PictureBox1.Image = bmp
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
            'frmImage.PictureBox1.Image.Dispose()
            'frmImage.PictureBox1.Image = Nothing
            'GC.Collect()
            'frmImage.PictureBox1.Image = bmp
            'frmImage.Text = Me.fileNames(image_index)
            'blSizeChanged = True
            frmImage.PictureBox1.Image.Dispose()
            frmImage.PictureBox1.Image = Nothing
            GC.Collect()

            Dim Dir As String = imagePath & imageFilesList(image_index)
            Dim bmp As Bitmap = New Bitmap(Image.FromFile(Dir), w, h)
            Dim g As Graphics = Graphics.FromImage(bmp)
            frmImage.PictureBox1.Image = bmp
            frmImage.Text = imageFilesList(image_index)
            Me.FileName = imageFilesList(image_index)
            currentImage = imagePath & imageFilesList(image_index)
            getEXIFData()
            ' TODO: Fix next line, I added a dim in there to make it compile
            Dim strTimeDateSource As String = "EXIF"
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
            Me.txtTransectDate.Text = m_transect_date
            Me.txtDateSource.Text = strTimeDateSource
            Me.txtDateSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            Me.txtDateSource.BackColor = Color.LightGray
            Me.txtDateSource.ForeColor = Color.LimeGreen
            Me.txtDateSource.TextAlign = HorizontalAlignment.Center
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Public Function ConvertBMP(ByVal BMPFullPath As String, ByVal imgFormat As ImageFormat) As Boolean

    '    Dim bAns As Boolean
    '    Dim strNewFileName As String
    '    Dim strNewFilePath As String
    '    Dim strNewFile As String

    '    Try

    '        ' Get a bitmap. 
    '        Dim bmp1 As New Bitmap(BMPFullPath)
    '        Dim jgpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)

    '        ' Create an Encoder object based on the GUID 
    '        ' for the Quality parameter category. 
    '        Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

    '        ' Create an EncoderParameters object. 
    '        ' An EncoderParameters object has an array of EncoderParameter 
    '        ' objects. In this case, there is only one 
    '        ' EncoderParameter object in the array. 
    '        Dim myEncoderParameters As New EncoderParameters(1)

    '        Dim myEncoderParameter As New EncoderParameter(myEncoder, 100&)
    '        myEncoderParameters.Param(0) = myEncoderParameter
    '        strNewFilePath = GetDirectoryName(BMPFullPath)
    '        strNewFileName = GetFileNameWithoutExtension(BMPFullPath)

    '        strNewFile = strNewFilePath & "\" & strNewFileName & ".jpg"

    '        bmp1.Save(strNewFile, jgpEncoder, myEncoderParameters)
    '        bmp1 = Nothing
    '        ''bitmap class in system.drawing.imaging
    '        'Dim objBmp As New Bitmap(BMPFullPath)

    '        ''below 2 functions in system.io.path
    '        'strNewFilePath = GetDirectoryName(BMPFullPath)
    '        'strNewFileName = GetFileNameWithoutExtension(BMPFullPath)

    '        'strNewFile = strNewFilePath & "\" & strNewFileName & "." & imgFormat.ToString
    '        'objBmp.Save(strNewFile, imgFormat)
    '        'objBmp.Dispose()
    '        bAns = True 'return true on success
    '    Catch
    '        bAns = False 'return false on error
    '    End Try
    '    Return bAns

    'End Function

#End Region

#Region "Video Functions"

    ''' <summary>
    ''' Handles the menu click event for the opening of a video file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuOpenFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOpenFile.Click
        If openVideo() Then
            toggleVideoMenu(False)
            playVideo()
            cmdShowSetTimecode.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Open a video file. Creates a new instance of frmVideoPlayer
    ''' </summary>
    ''' <returns>Boolean representing success</returns>
    ''' <remarks>Returns True if the user chose an existing file to play, False is they pressed cancel or clicked the 'X'</remarks>
    Private Function openVideo() As Boolean
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.Title = OPEN_VID_TITLE
        ofd.InitialDirectory = m_strVideoPath
        ofd.Filter = "Media Files (*.mpg,*.mpeg,*.avi,*.wma,*.wav,*.wmv,*.qt)|*.mpg;*.mpeg;*.avi;*.wma;*.wav;*.wmv;*.qt|All Files (*.*)|*.*"
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True
        ofd.Multiselect = False
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_strVideoPath = Path.GetDirectoryName(ofd.FileName)
            ' Store the new video path in XML file each time a video is opened
            SaveConfiguration("/VideoPath", m_strVideoPath)
            m_strVideoFile = Path.GetFileName(ofd.FileName)
        Else
            Return False
        End If

        If frmVideoPlayer Is Nothing Then
            Try
                frmVideoPlayer = New frmVideoPlayer(FileName, VIDEO_TIME_FORMAT)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            ' Figure out where to put the video player form. If there are two screens connected,
            ' put the video on the second screen, maximized. If only one screen, put it on the same screen,
            ' as an unmaximized window.
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
                frmVideoPlayer.Location = aPoint
                frmVideoPlayer.WindowState = FormWindowState.Normal
                'frmVideoPlayer.TopMost = True
            Else
                'TODO: fix back to 2 monitors for non-debug version
                'aPoint.X = intX + priMon.Bounds.Width
                'aPoint.Y = intY / 2
                aPoint.X = intX + priMon.Bounds.Width / 3
                aPoint.Y = intY / 4
                frmVideoPlayer.Location = aPoint
                'frmVideoPlayer.WindowState = FormWindowState.Maximized
                'frmVideoPlayer.TopMost = True
            End If
            Me.VideoTime = Zero
            frmVideoPlayer.Show()
        Else
            frmVideoPlayer.frmVideoPlayer_Load(Me, New System.EventArgs)
            Me.VideoTime = frmVideoPlayer.CurrentVideoTime
        End If
        frmVideoPlayer.pnlHideVideo.Visible = True
        pnlVideoControls.Visible = True
        ' In the future if the frames per second are returned properly, this will show that in the status bar..
        'Me.lblVideo.Text = "Video File '" & Me.FileName & "' is open (" & frmVideoPlayer.FPS & " frames per second)"
        Me.lblVideo.Text = "Video File '" & Me.FileName & "' is open"
        m_video_file_open = True
        Return True
    End Function

    Private Sub cmdPlayForSeconds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlayForSeconds.Click
        Try
            ' Check to make sure that the entered value is numeric
            If IsNumeric(Me.txtPlaySeconds.Text) Then
                Dim dblCurrentSeconds As Double
                Dim strSeconds As String()
                Dim intCurrentSeconds As Integer
                dblCurrentSeconds = frmVideoPlayer.Position
                strSeconds = dblCurrentSeconds.ToString.Split(".")
                intCurrentSeconds = CInt(strSeconds(0))
                'intPlayForSeconds = CInt(Me.txtPlaySeconds.Text)
                Me.tmrPlayForSeconds.Interval = 100
                Me.tmrPlayForSeconds.Enabled = True
                'intEndPlaySeconds = intCurrentSeconds + intPlayForSeconds
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
        If frmVideoPlayer.IsPaused Or frmVideoPlayer.IsStopped Then
            playVideo()
            If Me.chkRecordEachSecond.Checked = True Then
                blFirstTime = True
                'Me.tmrRecordPerSecond.Start()
            End If
        Else
            ' If it is already playing then pause it.
            pauseVideo()
        End If
    End Sub

    Public Sub video_file_unload()
        If Not frmVideoPlayer Is Nothing Then
            frmVideoPlayer.Dispose()
            frmVideoPlayer = Nothing
        End If
        lblVideo.Text = VIDEO_FILE_STATUS_UNLOADED
        pnlVideoControls.Visible = False
        toggleVideoMenu(True)
        unsetTimes()
        cmdShowSetTimecode.Enabled = False
        m_video_file_open = False
    End Sub

    Private Sub playVideo()
        frmVideoPlayer.Rate = m_dblVideoRate
        If frmVideoPlayer.playVideo() Then
            setTimes()
            FfwdCount = 0
            RwndCOunt = 0
        End If
    End Sub

    Private Sub pauseVideo()
        'If Me.tmrRecordPerSecond.Enabled Then
        ' Me.tmrRecordPerSecond.Stop()
        ' End If
        If frmVideoPlayer.pauseVideo() Then
            FfwdCount = 0
            RwndCOunt = 0
        End If
    End Sub

    Private Sub stopVideo()
        'If Me.tmrRecordPerSecond.Enabled Then
        ' Me.tmrRecordPerSecond.Stop()
        ' End If
        If frmVideoPlayer.stopVideo() Then
            setTimes()
            FfwdCount = 0
            RwndCOunt = 0
        End If
    End Sub

    Public Sub playerPaused() Handles frmVideoPlayer.PauseEvent
        ' This is used to sense when the video player form pauses its video from inside.
        ' it is added as a handler and an event raised from the frmVideoPlayer class
        cmdPlayPause.BackgroundImage = My.Resources.Play_Icon
    End Sub

    Public Sub playerPlaying() Handles frmVideoPlayer.PlayEvent
        ' This is used to sense when the video player form starts playing its video from inside.
        ' it is added as a handler and an event raised from the frmVideoPlayer class
        cmdPlayPause.BackgroundImage = My.Resources.Pause_Icon
    End Sub

    Public Sub playerStopped() Handles frmVideoPlayer.StopEvent
        ' This is used to sense when the video player form stops its video from inside.
        ' it is added as a handler and an event raised from the frmVideoPlayer class
        cmdPlayPause.BackgroundImage = My.Resources.Play_Icon
        Me.txtTimeSource.Text = frmVideoPlayer.CurrentVideoTimeFormatted
    End Sub

    ''' <summary>
    ''' Updates the time text on the form everytime the timer tick event is issued by the frmVideoPlayer form
    ''' </summary>
    Public Sub timerTick() Handles frmVideoPlayer.TimerTickEvent
        Me.txtTimeSource.Text = frmVideoPlayer.CurrentVideoTimeFormatted
        If frmVideoPlayer.IsPlaying Or frmVideoPlayer.IsPaused Then
            Dim tsNewTime As TimeSpan = m_tsUserTime + frmVideoPlayer.CurrentVideoTime
            txtTime.Text = String.Format(VIDEO_TIME_FORMAT, tsNewTime.Hours, tsNewTime.Minutes, tsNewTime.Seconds, tsNewTime.Milliseconds)
        End If
    End Sub

    Public Sub videoEnded() Handles frmVideoPlayer.VideoEndedEvent
        ' This is used to sense when the video ends its video from inside.
        ' it is added as a handler and an event raised from the frmVideoPlayer class
        cmdPlayPause.BackgroundImage = My.Resources.Play_Icon
        Me.txtTimeSource.Text = frmVideoPlayer.CurrentVideoTimeFormatted
        If m_tsUserTime <> Zero Then
            Dim tsNewTime As TimeSpan = m_tsUserTime + frmVideoPlayer.CurrentVideoTime
            txtTime.Text = String.Format(VIDEO_TIME_FORMAT, tsNewTime.Hours, tsNewTime.Minutes, tsNewTime.Seconds, tsNewTime.Milliseconds)
            'txtTime.
        End If
    End Sub

    Public Sub playerClosing() Handles frmVideoPlayer.ClosingEvent
        ' This is used to sense when the video player is closed (i.e. press the topright 'X' button)
        ' it is added as a handler and an event raised from the frmVideoPlayer class
        video_file_unload()
    End Sub

    Private Sub increaseRate()
        Try
            m_dblVideoRate = m_dblVideoRate + 0.25
            frmVideoPlayer.Rate = m_dblVideoRate
            Me.lblVideoRate.Text = m_dblVideoRate & " X"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub decreaseRate()
        Try
            If m_dblVideoRate <> 0.25 Then
                m_dblVideoRate = m_dblVideoRate - 0.25
            End If
            frmVideoPlayer.Rate = m_dblVideoRate
            Me.lblVideoRate.Text = m_dblVideoRate & " X"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Stepforward()
        If txtFramesToSkip.Text = NULL_STRING Then
            frmVideoPlayer.stepForward(VIDEO_FRAME_STEP_DEFAULT)
        Else
            frmVideoPlayer.stepForward(CInt(txtFramesToSkip.Text))
        End If
    End Sub

#End Region

#Region "Database Functions"
    ''' <summary>
    ''' Enable some controls when the database is opened
    ''' </summary>
    Private Sub db_file_load()
        If Database.IsOpen Then
            Me.lblDatabase.Text = DB_FILE_STATUS_LOADED & m_db_filename & " is open"
            mnuOpenDatabase.Enabled = False
            mnuCloseDatabase.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Set some controls to be invisible once the database has been closed, and remove the dynamic panel buttons.
    ''' </summary>
    Public Sub db_file_unload()
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
            Do While pnlHabitatData.Controls.Count <> 0
                pnlTransectData.Controls.RemoveAt(0)
            Loop
            For i = 0 To intNumHabitatButtons - 1
                buttons(i).Dispose()
                buttons(i) = Nothing
                textboxes(i).Dispose()
                textboxes(i) = Nothing
            Next
            intNumHabitatButtons = 0
            ' Making the panel invisible makes the remove operations much faster
            pnlSpeciesData.Visible = False
            ' The Do.While is the only method that works for removing controls propery. Other methods, i.e. For..Each and For..Next
            ' will have the index changing while the controls are being removed which will mess it up and leave some on the panel.
            Do While pnlSpeciesData.Controls.Count <> 0
                pnlSpeciesData.Controls.RemoveAt(0)
            Loop
            intNumSpeciesButtons = 0
            pnlSpeciesData.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' Opens the MS Access database, loads one button for each record in the DB_HABITAT_BUTTONS_TABLE table into Panel1: fill_spatialvariable_button_panel(),
    ''' and loads one button for each record in the DB_SPECIES_BUTTONS_TABLE table into Panel2: fill_speciesvariable_button_panel().
    ''' </summary>
    Public Sub openDatabase()
        Database.Name = m_strDatabaseFilePath
        Database.Open()
        If Database.IsOpen Then
            m_db_filename = get_rel_filename(m_strDatabaseFilePath)
            m_db_file_open = True
            fillTransectVariableButtonPanel()
            fillSpatialVariableButtonPanel()
            fillSpeciesVariableButtonPanel()
            fillHabitatFieldsCollection()
            fillDataCodesTable()
            db_file_load()
            If m_video_file_open Then
                files_loaded()
                Me.lblVideo.Text = "Video File '" & Me.FileName & "' is open"
                m_video_file_open = True
            End If
            fetch_data()
            files_loaded()
        End If
    End Sub

    Private Sub fillDataCodesTable()
        Dim clDataCodes As New Collection
        Dim clDataCodeDescriptions As New Collection
        'Dim strQuery As String
        'Dim tblDataCodes As DataTable
        'Dim oComm As OleDbCommand
        Dim d As DataTable
        Dim r As DataRow
        If Database.ExecuteNonQuery("DELETE * FROM " & DB_DATA_CODES_TABLE & " WHERE Code > 4 AND Code < 555;") Then
            d = Database.GetDataTable("SELECT * FROM " & DB_HABITAT_BUTTONS_TABLE & ";", DB_HABITAT_BUTTONS_TABLE)
            For Each r In d.Rows
                clDataCodes.Add(r.Item("DataCode"))
                clDataCodeDescriptions.Add(r.Item("ButtonText"))
            Next
            d = Database.GetDataTable("SELECT * FROM " & DB_TRANSECT_BUTTONS_TABLE & ";", DB_TRANSECT_BUTTONS_TABLE)
            For Each r In d.Rows
                clDataCodes.Add(r.Item("DataCode"))
                clDataCodeDescriptions.Add(r.Item("ButtonText"))
            Next
            d = Database.GetDataTable("SELECT * FROM " & DB_SPECIES_BUTTONS_TABLE & " WHERE DataCode <> 4;", DB_SPECIES_BUTTONS_TABLE)
            For Each r In d.Rows
                clDataCodes.Add(r.Item("DataCode"))
                clDataCodeDescriptions.Add(r.Item("ButtonText"))
            Next
            d = Database.GetDataTable("SELECT * FROM " & DB_DATA_CODES_TABLE & ";", DB_DATA_CODES_TABLE)
            Dim i As Integer
            For Each r In d.Rows
                For i = 1 To clDataCodes.Count
                    If r.Item("Code") = clDataCodes.Item(i) Then
                        clDataCodes.Remove(i)
                        clDataCodeDescriptions.Remove(i)
                        i -= 1
                    End If
                Next
            Next
            For i = 1 To clDataCodes.Count
                If Not Database.ExecuteNonQuery("INSERT INTO " & DB_DATA_CODES_TABLE & " (Code, Description) VALUES(" & clDataCodes.Item(i) & ", " & SingleQuote(clDataCodeDescriptions.Item(i)) & ")") Then
                    CloseDatabase_Click(Nothing, Nothing)
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' Fetch the data table from the MS Access database into the DataGridView and sets the next unique ID that the database can recieve.
    ''' </summary>
    ''' <remarks>Order of the rows will be by decending primary key ('ID' field)</remarks>
    Private Sub fetch_data()
        m_data_table = Database.GetDataTable("SELECT * FROM " & DB_DATA_TABLE & " ORDER BY ID DESC;", DB_DATA_TABLE) ' DESC is important here, see comment below on m_db_id_num
        grdVideoMinerDatabase.DataSource = m_data_table
        Dim intIDColumn As Integer = 0
        If m_data_table.Rows.Count > 0 Then
            m_db_id_num = m_data_table.Rows(0).Item(intIDColumn) + 1 ' m_db_id_num is the next unique primary key to use in inserting data into database (assumes decending order)
        Else
            m_db_id_num = 1
        End If
        If Me.grdVideoMinerDatabase.Rows.Count = 0 Then
            Me.cmdUpdateDatabase.Enabled = False
            Me.cmdRevertDatabase.Enabled = False
        Else
            Me.cmdUpdateDatabase.Enabled = True
            Me.cmdRevertDatabase.Enabled = True
        End If
        blupdateColumns = True
    End Sub

    ''' <summary>
    ''' Creates a string which is an 'INSERT INTO' query in access database format.
    ''' </summary>
    ''' <param name="strDataCode">Code for the data. This code is found in the DB_DATA_CODES_TABLE table in the access database</param>
    ''' <param name="strSpeciesName">Species name as found in the DB_SPECIES_CODE_TABLE table</param>
    ''' <param name="strSpeciesCode">Species code as found in the DB_SPECIES_CODE_TABLE table</param>
    ''' <param name="strSpeciesCount">Count of the species given by strSpeciesCode and strSpeciesName</param>
    ''' <param name="strSide">Which side the observation was on given by table DB_OBSERVED_SIDE_TABLE (0=center,1=port,2=starboard)</param>
    ''' <param name="strRange">Distance of observation from the centerline in cm</param>
    ''' <param name="strLength">Length in cm of the observed species</param>
    ''' <param name="strHeight">Height measurement for species where length is not the standard measurement (e.g. Tunicate)</param>
    ''' <param name="strWidth">Width measurement for species where length is not the standard measurement</param>
    ''' <param name="strAbundance">Abundance of the species seen (TODO:update this definition)</param>
    ''' <param name="strIdConfidence">Confidence value for species ID. See table DB_CONFIDENCE_IDS_TABLE (1=high,2=med,3=low)</param>
    ''' <param name="strComment">Video reviewer's comments</param>
    ''' <remarks></remarks>
    Private Function createInsertQuery(strDataCode As String, strSpeciesName As String, _
                                       strSpeciesCode As String, strSpeciesCount As String, strSide As String, strRange As String, _
                                       strLength As String, strHeight As String, strWidth As String, strAbundance As String,
                                       strIdConfidence As String, strComment As String) As String
        Dim i As Integer
        Dim j As Integer

        Dim strQuery As String = "INSERT INTO " & DB_DATA_TABLE & "(ID,TransectDate,TimeCode,TextTime,TextTimeDecimal,TimeSource,ProjectName,TransectName,OnBottom," & _
                                 "DominantSubstrate,DominantPercent,SubdominantSubstrate,SubdominantPercent,SurveyModeID,ReliefID,DisturbanceID,ProtocolID," & _
                                 "ImageQualityID,SpeciesName,SpeciesID,SpeciesCount,Side,Range,Length,Height,Width,Abundance,IDConfidence,Comment,DataCode," & _
                                 "X,Y,Z,FileName,ScreenCaptureName,ElapsedTime,ReviewedDate,ReviewedTime,ComplexityID,FieldOfView) VALUES("

        ' Parse through all the field names in the collection and attach the associated variables with the field names
        For i = 1 To colTableFields.Count
            Select Case colTableFields.Item(i).ToString
                Case "ID"
                    strQuery = strQuery & m_db_id_num
                Case "ProjectName"
                    If m_project_name = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & SingleQuote(m_project_name)
                    End If
                Case "TransectName"
                    If m_transect_name = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & SingleQuote(m_transect_name)
                    End If
                Case "TransectDate"
                    Try
                        strQuery = strQuery & SingleQuote(m_transect_date)
                    Catch ex As Exception
                        strQuery = strQuery & NS
                    End Try
                Case "Format(TimeCode, 'hh:mm:ss') as TimeCode"
                    Dim tsTime As TimeSpan = m_tsUserTime + frmVideoPlayer.CurrentVideoTime
                    If tsTime = Zero Then
                        strQuery = strQuery & NS
                    Else
                        Dim dt As DateTime = m_transect_date + tsTime
                        strQuery = strQuery & SingleQuote(dt) '& ", " & SingleQuote(strVideoTime)
                    End If
                Case "TextTime"
                    Dim tsTime As TimeSpan = m_tsUserTime + frmVideoPlayer.CurrentVideoTime
                    If tsTime = Zero Then
                        strQuery = strQuery & NS
                    Else
                        Dim strTextTime As String = pad0(tsTime.Hours) & ":" & pad0(tsTime.Minutes) & ":" & pad0(tsTime.Seconds)
                        strQuery = strQuery & SingleQuote(strTextTime)
                    End If
                Case "TextTimeDecimal"
                    Dim tsTime As TimeSpan = m_tsUserTime + frmVideoPlayer.CurrentVideoTime
                    If tsTime = Zero Then
                        strQuery = strQuery & NS
                    Else
                        Dim strDecimalTime As String = pad0(tsTime.Hours) & ":" & pad0(tsTime.Minutes) & ":" & pad0(tsTime.Seconds) & "." & pad0(tsTime.Milliseconds)
                        strQuery = strQuery & SingleQuote(strDecimalTime)
                    End If
                Case "OnBottom"
                    If is_on_bottom = -9999 Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & is_on_bottom
                    End If
                Case "SpeciesID"
                    If strSpeciesCode = NS Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & SingleQuote(strSpeciesCode)
                    End If
                Case "SpeciesName"
                    If strSpeciesName = NS Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & SingleQuote(strSpeciesName)
                    End If
                Case "SpeciesCount"
                    If strSpeciesCount = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & strSpeciesCount
                    End If
                Case "Side"
                    If strSide = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & strSide
                    End If
                Case "Range"
                    If strRange = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & strRange
                    End If
                Case "Length"
                    If strLength = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & strLength
                    End If
                Case "Height"
                    If strHeight = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & strHeight
                    End If
                Case "Width"
                    If strWidth = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & strWidth
                    End If
                Case "Abundance"
                    If strAbundance = NS Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & strAbundance
                    End If
                Case "IDConfidence"
                    If strIdConfidence = NS Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & strIdConfidence
                    End If
                Case "Comment"
                    If strComment = NS Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & SingleQuote(strComment)
                    End If
                Case "DataCode"
                    If strDataCode = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & strDataCode
                    End If
                Case "X"
                    If m_GPS_X = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & m_GPS_X
                    End If
                Case "Y"
                    If m_GPS_Y = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & m_GPS_Y
                    End If
                Case "Z"
                    If m_GPS_Z = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & m_GPS_Z
                    End If
                Case "FileName"
                    If Me.FileName = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & SingleQuote(Me.FileName)
                    End If
                Case "ScreenCaptureName"
                    If Me.FileName = NULL_STRING Then
                        strQuery = strQuery & NS
                    Else
                        strQuery = strQuery & SingleQuote(Me.ScreenCaptureName)
                    End If
                Case "TimeSource"
                    strQuery = strQuery & intTimeSource
                Case "Format(ElapsedTime, 'hh:mm:ss') as ElapsedTime"
                    If Me.ElapsedTime = NULL_STRING Then
                        strQuery = strQuery & NS
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
                                strQuery = strQuery & Replace(dictHabitatFieldValues(strHabitatButtonCodeNames(j).ToString), "-9999", NS)
                            End If
                            GoTo InsertComma
                        End If
                    Next j
                    For j = 0 To intNumTransectButtons - 1
                        If strTransectButtonCodeNames(j).ToString = colTableFields.Item(i).ToString Then
                            If dictTransectFieldValues(strTransectButtonCodeNames(j).ToString) <> "-9999" Then
                                strQuery = strQuery & SingleQuote(dictTransectFieldValues(strTransectButtonCodeNames(j).ToString))
                            Else
                                strQuery = strQuery & Replace(dictTransectFieldValues(strTransectButtonCodeNames(j).ToString), "-9999", NS)
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
        ' TODO: Fix this, values for ComplexityID and FieldOfView are not being found..
        strQuery = strQuery & ",NULL,NULL"

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
    ' 1.) Load one button for each record in the DB_HABITAT_BUTTONS_TABLE table into Panel1.
    ' 2.) Set the button click event to SpatialVariableButtonHandler()
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
        Dim d As DataTable = Database.GetDataTable("select * from " & DB_HABITAT_BUTTONS_TABLE & " ORDER BY DrawingOrder;", DB_HABITAT_BUTTONS_TABLE)
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
        For Each r As DataRow In d.Rows
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
    '     relief button allows the user to select a relief type from the datbase table DB_RELIEF_TABLE.
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
        Dim query As String = NULL_STRING
        Dim strCode As String = NULL_STRING
        Dim strName As String = NULL_STRING
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
        If m_video_file_open And Not booUseGPSTimeCodes Then
            If frmVideoPlayer.IsPlaying Then
                blVideoWasPlaying = True
            Else
                blVideoWasPlaying = False
            End If
            pauseVideo()
        End If

        ' ======================================Code by Xida Chen (end)===========================================
        Dim strHabitatValue As String = NULL_STRING
        For i = 0 To intNumHabitatButtons - 1
            If btn.Name = strHabitatButtonNames(i) Then

                If strHabitatButtonTables(i) = "UserEntered" Then
                    Dim strValue As String
                    Dim strPreviousValue As String = dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString)
                    frmAddValue = New frmAddValue(dictHabitatFieldValues(strHabitatButtonCodeNames(i).ToString))
                    frmAddValue.lblExpression.Text = "Please enter a value for " & btn.Text & ":"
                    frmAddValue.Text = btn.Text & " Entry"
                    frmAddValue.ShowDialog()

                    strValue = frmAddValue.strValue
                    frmAddValue.Close()
                    frmAddValue = Nothing
                    If strValue = strPreviousValue Then
                        Exit Sub
                    End If
                    'strValue = InputBox("Please enter a value for " & btn.Text & " (limit 50 characters):", btn.Text & " Entry")
                    If strValue = "-9999" Then
                        ' If the image is open and the video is closed then get the picture information from the EXIF file
                        If image_open And m_video_file_open = False Then

                            getEXIFData()
                        End If

                        ClearSpatial(btn.Name, intNumHabitatButtons, strHabitatButtonNames, dictHabitatFieldValues, strHabitatButtonCodeNames, textboxes)
                        query = createInsertQuery(INDIVIDUAL_HABITAT_VARIABLE_CLEARED, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                        Database.ExecuteNonQuery(query)
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
                                If image_open And m_video_file_open = False Then

                                    getEXIFData()

                                End If

                                query = createInsertQuery(INDIVIDUAL_HABITAT_VARIABLE_CLEARED, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                                Database.ExecuteNonQuery(query)
                                fetch_data()
                            End If
                            blCleared = False

                            Exit Sub
                        End If
                        'Console.WriteLine(DataGridView1.SelectedRows(0).Cells(0).Value)
                        strCode = sub_form.DataGridView1.SelectedRows(0).Cells(0).Value & NULL_STRING
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

                        strName = sub_form.DataGridView1.SelectedRows(0).Cells(1).Value & NULL_STRING

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
                Dim _fontfamily As FontFamily
                _fontfamily = New FontFamily(Me.ButtonFont)
                textboxes(i).Text = strHabitatButtonUserNameChoice(i)
                textboxes(i).Font = New Font(_fontfamily, Me.ButtonTextSize, FontStyle.Bold)
                textboxes(i).BackColor = Color.LightGray
                textboxes(i).ForeColor = Color.LimeGreen
                textboxes(i).TextAlign = HorizontalAlignment.Center
                ' If the image is open and the video is closed then get the picture information from the EXIF file
                If image_open And m_video_file_open = False Then

                    getEXIFData()

                End If

                If VideoTime.ToString <> NULL_STRING Then
                    Dim numrows As Integer

                    query = createInsertQuery(intHabitatButtonCodes(i), NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                    Database.ExecuteNonQuery(query)
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
        If Not frmImage Is Nothing Then
            frmImage.Focus()
        End If
        Me.ScreenCaptureName = NULL_STRING
    End Sub


    Public Sub fillHabitatFieldsCollection()
        colTableFields = Nothing
        colTableFields = New Collection
        Dim d As DataTable = Database.GetDataTable("select * from " & DB_DATA_TABLE, DB_DATA_TABLE)
        Dim dc As DataColumn
        For i As Integer = 0 To d.Columns.Count - 1
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

    ''' <summary>
    ''' Load a table in from the currently loaded MS Access database
    ''' </summary>
    ''' <param name="name">The name of the table</param>
    ''' <returns>True if the table was loaded successfully, false otherwise</returns>
    Private Function get_table(name As String) As Boolean
        Return False
    End Function

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
        Dim d As DataTable = Database.GetDataTable("select * from " & DB_TRANSECT_BUTTONS_TABLE & " order by DrawingOrder;", DB_TRANSECT_BUTTONS_TABLE)
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

        For Each r As DataRow In d.Rows
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
        'Dim tc As TimeSpan = New TimeSpan(VIDEO_TIME_LABEL)
        Dim strX As String = NS
        Dim strY As String = NS
        Dim strZ As String = NS
        Dim query As String = NULL_STRING
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
        If m_video_file_open Then
            If frmVideoPlayer.IsPlaying Then
                If frmVideoPlayer.IsPlaying Then
                    blVideoWasPlaying = True
                Else
                    blVideoWasPlaying = False
                End If
                pauseVideo()
            End If
            'tc = getTimeCode()
            strVideoTime = frmVideoPlayer.CurrentVideoTimeFormatted

        End If
        Dim strCode As String = NULL_STRING
        Dim strName As String = NULL_STRING
        Dim blAquiredFix As Boolean = False
        If booUseGPSTimeCodes Then
            'Otherwise get the time from the NMEA string.
            blAquiredFix = getGPSData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
            If Not blAquiredFix Then
                Exit Sub
            End If
        End If
        strVideoTextTime = strVideoTime
        ' If the image is open and the video is closed then get the picture information from the EXIF file
        'If image_open And video_file_open = False Then

        '    getEXIFData(strVideoTime)

        'End If
        ' ======================================Code by Xida Chen (end)===========================================
        For i = 0 To intNumTransectButtons - 1
            If btn.Name = strTransectButtonNames(i) Then
                Dim _fontfamily As FontFamily
                If strTransectButtonTables(i) = "UserEntered" Then
                    Dim strValue As String
                    frmAddValue = New frmAddValue(dictTransectFieldValues(strTransectButtonCodeNames(i).ToString))
                    frmAddValue.lblExpression.Text = "Please enter a value for " & btn.Text & ":"
                    frmAddValue.Text = btn.Text & " Entry"
                    frmAddValue.ShowDialog()
                    strValue = frmAddValue.strValue
                    frmAddValue.Close()
                    frmAddValue = Nothing
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
                            Me.strComment = NULL_STRING
                            Exit Sub
                        End If
                        'Console.WriteLine(DataGridView1.SelectedRows(0).Cells(0).Value)
                        strCode = sub_form.DataGridView1.SelectedRows(0).Cells(0).Value & NULL_STRING
                        strTransectButtonUserCodeChoice(i) = strCode
                        ' Depending on which button is selected, define the applicable spatial variable.
                        ' The other varaibles are cleared to prevent subsequent records being created from
                        ' having repeated values if the repeat check box is off.
                        dictTransectFieldValues(strTransectButtonCodeNames(i).ToString) = strTransectButtonUserCodeChoice(i)
                        If Me.strComment <> NULL_STRING Then
                            query = createInsertQuery(intTransectButtonCodes(i), NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                            Database.ExecuteNonQuery(query)
                            fetch_data()
                        End If
                        Me.strComment = NULL_STRING
                        strName = sub_form.DataGridView1.SelectedRows(0).Cells(1).Value & NULL_STRING
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
        If Not frmImage Is Nothing Then
            frmImage.Focus()
        End If
        Me.ScreenCaptureName = NULL_STRING
    End Sub

#End Region

#Region "Species Variable Functions"
    ''' <summary>
    ''' Load one button for each record in the DB_SPECIES_BUTTONS_TABLE table into 'Species DATA' Panel.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub fillSpeciesVariableButtonPanel()
        Dim d As DataTable = Database.GetDataTable("select * from " & DB_SPECIES_BUTTONS_TABLE & " ORDER BY DrawingOrder;", DB_SPECIES_BUTTONS_TABLE)
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
        Dim strButtonText As String = NULL_STRING
        Dim intCountPerRow As Integer
        Dim cellsizex As Integer = sizex + gap
        Dim cellsizey As Integer = sizey + gap
        intCountPerRow = Math.Floor(w / (cellsizex))
        For Each r As DataRow In d.Rows
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
            If r.Item("KeyboardShortcut").ToString <> NULL_STRING Then
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
        '        If blHandled = True Then
        ' blHandled = False
        ' Exit Sub
        ' End If

        Dim btn As Button = sender
        Dim i As Integer

        Dim query As String = NULL_STRING

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
        If m_video_file_open Then
            If frmVideoPlayer.IsPlaying Then
                pauseVideo()
            End If
            strVideoTime = frmVideoPlayer.CurrentVideoTimeFormatted
        ElseIf booUseExternalVideo Then
            strVideoTime = frmVideoPlayer.CurrentVideoTimeFormatted
        End If
        ' ======================================Code by Xida Chen (end)===========================================
        Dim numrows As Integer
        Dim oComm As OleDbCommand
        Dim strWidth As String = NULL_STRING
        Dim blAquiredFix As Boolean = False
        '        If booUseGPSTimeCodes Then
        ' 'Otherwise get the time from the NMEA string.
        '
        '        blAquiredFix = getGPSData(strVideoTime, strVideoDecimalTime, strX, strY, strZ)
        '        If Not blAquiredFix Then
        ' Exit Sub
        ' End If
        ' End If
        strVideoTextTime = strVideoTime
        If blRareSpecies = False Then
            For i = 0 To intNumSpeciesButtons - 1
                If btn.Name = strSpeciesButtonNames(i) Then
                    Dim d As DataTable = Database.GetDataTable("SELECT ButtonText, DataCode FROM " & DB_SPECIES_BUTTONS_TABLE & " WHERE ButtonCode = " & SingleQuote(strSpeciesButtonCodes(i)), DB_SPECIES_BUTTONS_TABLE)
                    Dim strSpecies_Name As String = d.Rows(0).Item("ButtonText")
                    intSpeciesButtonUserCodeChoice(i) = d.Rows(0).Item("DataCode")

                    If Me.radDetailedEntry.Checked Then
                        frmSpeciesEvent = New frmSpeciesEvent(RangeChecked, IDConfidenceChecked, AbundanceChecked, CountChecked, HeightChecked, WidthChecked, LengthChecked, CommentsChecked, _
                                                              Range, Side, IDConfidence, Abundance, Count, Height, Width, Length, Comments)
                        frmSpeciesEvent.Location = New System.Drawing.Point(btn.Location.X, btn.Location.Y)
                        frmSpeciesEvent.SpeciesName = strSpeciesButtonNames(i)
                        frmSpeciesEvent.ShowDialog()
                        If blSpeciesValuesSet Then
                            Try
                                ' If an image is open and the video is closed then get the picture information from the EXIF file
                                If image_open And m_video_file_open = False Then
                                    getEXIFData()
                                    strVideoTextTime = strVideoTime
                                End If
                                strSpeciesButtonUserNameChoice(i) = 666
                                If m_tsUserTime.ToString() <> NULL_STRING Then
                                    ' Insert new record in database
                                    If Me.SpeciesWidth Is Nothing Then
                                        strWidth = NS
                                    Else
                                        strWidth = Me.SpeciesWidth
                                    End If
                                    strSpeciesCode = Me.SpeciesCode
                                    strSpeciesCount = Me.Count
                                    If Me.Side = "0" Then
                                        strSide = NULL_STRING
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
                                    'If transect_date = NULL_STRING Then
                                    query = createInsertQuery(intSpeciesButtonUserCodeChoice(i), strSpecies_Name, strSpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)
                                    Database.ExecuteNonQuery(query)
                                    Me.ScreenCaptureName = NULL_STRING
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
                            If image_open And m_video_file_open = False Then
                                getEXIFData()
                                strVideoTextTime = strVideoTime
                            End If
                            strSpeciesButtonUserNameChoice(i) = 666
                            strSpeciesCode = strSpeciesButtonCodes(i)
                            strSpeciesCount = strQuickEntryCount
                            query = createInsertQuery(intSpeciesButtonUserCodeChoice(i), strSpecies_Name, strSpeciesCode, strSpeciesCount, NS, NS, NS, NS, NS, NS, NS, NS)
                            Database.ExecuteNonQuery(query)
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
                            frmAbundanceTableView = New frmAbundanceTableView
                            frmAbundanceTableView.ShowDialog()
                            ' If an image is open and the video is closed then get the picture information from the EXIF file
                            If image_open And m_video_file_open = False Then
                                getEXIFData()
                                strVideoTextTime = strVideoTime
                            End If
                            If frmAbundanceTableView.Canceled = False Then
                                If frmAbundanceTableView.grdAbundance.SelectedRows.Count <> 0 Then
                                    strSpeciesButtonUserNameChoice(i) = 666
                                    strSpeciesCode = strSpeciesButtonCodes(i)
                                    strAbundance = frmAbundanceTableView.grdAbundance.SelectedRows(0).Cells(0).Value
                                    If frmAbundanceTableView.txtCommentBox.Text <> NULL_STRING Or frmAbundanceTableView.txtCommentBox.Text <> "Comment" Then
                                        strComment = frmAbundanceTableView.txtCommentBox.Text
                                    Else
                                        strComment = NS
                                    End If
                                    query = createInsertQuery(intSpeciesButtonUserCodeChoice(i), strSpecies_Name, strSpeciesCode, NS, NS, NS, NS, NS, NS, strAbundance, NS, strComment)
                                    Database.ExecuteNonQuery(query)
                                    fetch_data()
                                    frmAbundanceTableView.Close()
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
            'If booUseGPSTimeCodes Then
            ' blAquiredFix = getGPSData()
            ' If Not blAquiredFix Then
            ' Exit Sub
            'End If
        End If
        strVideoTextTime = strVideoTime
        frmSpeciesEvent = New frmSpeciesEvent(RangeChecked, IDConfidenceChecked, AbundanceChecked, CountChecked, HeightChecked, WidthChecked, LengthChecked, CommentsChecked, _
                                              Range, Side, IDConfidence, Abundance, Count, Height, Width, Length, Comments)
        frmSpeciesEvent.Location = New System.Drawing.Point(btn.Location.X, btn.Location.Y)
        frmSpeciesEvent.SpeciesName = Me.SpeciesName
        frmSpeciesEvent.SpeciesCode = Me.SpeciesCode
        frmSpeciesEvent.ShowDialog()
        If blSpeciesCancelled = True Then
            blSpeciesCancelled = False
            Exit Sub
        End If
        If blSpeciesValuesSet Then
            Try
                ' If an image is open and the video is closed then get the picture information from the EXIF file
                If image_open And m_video_file_open = False Then
                    getEXIFData()
                    strVideoTextTime = strVideoTime
                End If
                strSpeciesButtonUserNameChoice(i) = 666
                If m_tsUserTime.ToString() <> NULL_STRING Then
                    ' Insert new record in database
                    If Me.SpeciesWidth Is Nothing Then
                        strWidth = NS
                    Else
                        strWidth = Me.SpeciesWidth
                    End If
                    strSpeciesCount = Me.Count
                    If Me.Side = "0" Then
                        strSide = NULL_STRING
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
                    'If transect_date = NULL_STRING Then
                    query = createInsertQuery(SPECIES_EVENT, Me.SpeciesName, Me.SpeciesCode, strSpeciesCount, strSide, strRange, strLength, strHeight, strWidth, strAbundance, strIdConfidence, strComment)
                    Database.ExecuteNonQuery(query)
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

        If Not frmImage Is Nothing Then
            frmImage.Focus()
        End If
        If Not frmVideoPlayer Is Nothing Then
            If Me.chkResumeVideo.Checked Then
                playVideo()
            End If
        End If
    End Sub

    'Public Sub GetSettingsFromFile()
    '    RangeChecked = GetConfiguration("/DetailedSpeciesEventConfiguration/Range/Displayed")
    '    IDConfidenceChecked = GetConfiguration("/DetailedSpeciesEventConfiguration/IDConfidence/Displayed")
    '    AbundanceChecked = GetConfiguration("/DetailedSpeciesEventConfiguration/Abundance/Displayed")
    '    CountChecked = GetConfiguration("/DetailedSpeciesEventConfiguration/Count/Displayed")
    '    HeightChecked = GetConfiguration("/DetailedSpeciesEventConfiguration/Height/Displayed")
    '    WidthChecked = GetConfiguration("/DetailedSpeciesEventConfiguration/Width/Displayed")
    '    LengthChecked = GetConfiguration("/DetailedSpeciesEventConfiguration/Length/Displayed")
    '    CommentsChecked = GetConfiguration("/DetailedSpeciesEventConfiguration/Comments/Displayed")

    '    Range = GetConfiguration("/DetailedSpeciesEventConfiguration/Range/DefaultValue")
    '    Side = GetConfiguration("/DetailedSpeciesEventConfiguration/Side/DefaultValue")
    '    IDConfidence = GetConfiguration("/DetailedSpeciesEventConfiguration/IDConfidence/DefaultValue")
    '    Abundance = GetConfiguration("/DetailedSpeciesEventConfiguration/Abundance/DefaultValue")
    '    Count = GetConfiguration("/DetailedSpeciesEventConfiguration/Count/DefaultValue")
    '    SpeciesHeight = GetConfiguration("/DetailedSpeciesEventConfiguration/Height/DefaultValue")
    '    SpeciesWidth = GetConfiguration("/DetailedSpeciesEventConfiguration/Width/DefaultValue")
    '    Length = GetConfiguration("/DetailedSpeciesEventConfiguration/Length/DefaultValue")
    '    Comments = GetConfiguration("/DetailedSpeciesEventConfiguration/Comments/DefaultValue")
    'End Sub

#End Region

    Private Sub txtPlaySeconds_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlaySeconds.KeyPress
        modGlobals.numericTextboxValidation(e)
    End Sub

    Private Sub txtQuickSpeciesCount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuickSpeciesCount.KeyPress
        modGlobals.numericTextboxValidation(e)
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
            frmRareSpeciesLookup = New frmRareSpeciesLookup
            frmRareSpeciesLookup.ShowDialog()
        Catch ex As Exception

            frmRareSpeciesLookup.ShowDialog()
        End Try
    End Sub

    Private Sub KeyboardShortcutsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeyboardShortcutsToolStripMenuItem.Click
        frmKeyboardCommands = New frmKeyboardCommands
        frmKeyboardCommands.ShowDialog()
    End Sub

    Private Sub ConfigureHabitatButtonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureHabitatButtonToolStripMenuItem.Click
        strConfigureTable = DB_HABITAT_BUTTONS_TABLE
        frmConfigureButtons = New frmConfigureButtons
        frmConfigureButtons.cmdMoveToPanel.Text = "Move To TRANSECT DATA"
        frmConfigureButtons.ShowDialog()
    End Sub

    Private Sub ConfigureTransectButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureTransectButtonsToolStripMenuItem.Click
        strConfigureTable = DB_TRANSECT_BUTTONS_TABLE
        frmConfigureButtons = New frmConfigureButtons
        frmConfigureButtons.cmdMoveToPanel.Text = "Move To HABITAT DATA"
        frmConfigureButtons.ShowDialog()
    End Sub

    Public Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        stopVideo()
    End Sub

    Private Sub cmdIncreaseRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIncreaseRate.Click
        increaseRate()
    End Sub

    Private Sub cmdDecreaseRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDecreaseRate.Click
        decreaseRate()
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
        cmdNextImage_Click(sender, e)
    End Sub

    Private Sub PreviousImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousImageToolStripMenuItem.Click
        cmdPreviousImage_Click(sender, e)
    End Sub

    Private Sub CloseImageFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseImageFileToolStripMenuItem.Click
        frmImage.Close()
    End Sub

    Private Sub CloseVideoFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmVideoPlayer.Close()
    End Sub

    Public Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        Stepforward()
    End Sub

    Public Sub cmdPrevious_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.MouseHover
        ttToolTip.Show("Vlc.DotNet control does not support reverse frame stepping", Me)
    End Sub

    Public Sub cmdPrevious_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.MouseLeave
        ttToolTip.Hide(Me)
    End Sub

    Private Sub DataCodeAssignmentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataCodeAssignmentsToolStripMenuItem.Click
        frmDataCodes = New frmDataCodes
        frmDataCodes.ShowDialog()
    End Sub

    Private Sub DeviceControlToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeviceControl.Click
        frmDeviceControl = New frmDeviceControl
        frmDeviceControl.ShowDialog()
    End Sub

    Private Sub RelayConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelayConfigurationToolStripMenuItem.Click
        frmRelayConfiguration = New frmRelayConfiguration

        ' Transfer the relay configuration variables to the relay configuration form
        frmRelayConfiguration.ConfigurationSet = Me.ConfigurationSet
        frmRelayConfiguration.RelaySetup = Me.RelaySetup
        frmRelayConfiguration.ParallelCom = Me.ParallelCom
        frmRelayConfiguration.ParallelBaud = Me.ParallelBaud
        frmRelayConfiguration.PortOneCom = Me.PortOneCom
        frmRelayConfiguration.PortOneBaud = Me.PortOneBaud
        frmRelayConfiguration.PortTwoCom = Me.PortTwoCom
        frmRelayConfiguration.PortTwoBaud = Me.PortTwoBaud
        frmRelayConfiguration.DeviceOneRelayOne = Me.DeviceOneRelayOne
        frmRelayConfiguration.DeviceOneRelayTwo = Me.DeviceOneRelayTwo
        frmRelayConfiguration.DeviceOneRelayThree = Me.DeviceOneRelayThree
        frmRelayConfiguration.DeviceOneRelayFour = Me.DeviceOneRelayFour
        frmRelayConfiguration.DeviceTwoRelayOne = Me.DeviceTwoRelayOne
        frmRelayConfiguration.DeviceTwoRelayTwo = Me.DeviceTwoRelayTwo
        frmRelayConfiguration.DeviceTwoRelayThree = Me.DeviceTwoRelayThree
        frmRelayConfiguration.DeviceTwoRelayFour = Me.DeviceTwoRelayFour

        frmRelayConfiguration.ShowDialog()
    End Sub

    ' Handles updating the NMEA text box
    Public Sub updateTextBox()
        'Try
        '    strTimeDateSource = "GPS"
        '    intTimeSource = 4
        '    Dim blAquiredFix As Boolean = False
        '    Dim m_CurrentPoint As Point
        '    'If Me.txtNMEA.InvokeRequired Then
        '    'Dim d As New updateTextBoxCallback(AddressOf updateTextBox)
        '    'Me.BeginInvoke(d)
        '    'Else
        '    ' Read the data from the serial port
        '    'MsgBox(Me.txtNMEA.InvokeRequired)

        '    With txtNMEA
        '        .Text &= aSerialPort.ReadExisting
        '        .WordWrap = False
        '        .ScrollToCaret()
        '    End With
        '    'CJG
        '    'searchingCounter = 0
        '    'MsgBox(frmVideoMiner.txtNMEA.Text)
        '    'aSerialPort.DiscardInBuffer()

        '    'If Not frmGpsSettings Is Nothing Then
        '    If Not frmGpsSettings Is Nothing Then
        '        frmGpsSettings.cmdConnection.Enabled = True
        '        frmGpsSettings.cmdConnection.Text = "Close GPS Connection"
        '    End If
        '    ' Create a new point object and populate it with the location from the NMEA string

        '    m_CurrentPoint = New Point
        '    With m_CurrentPoint
        '        .NMEA = txtNMEA.Text
        '        blAquiredFix = .GetPoint     ' Returns true if there is a valid location
        '        If blAquiredFix Then
        '            GPS_X = .X
        '            GPS_Y = .Y
        '            GPS_Z = .Z
        '            GPSUserTime = m_CurrentPoint.GpsUserTime
        '            GPSDateTime = m_CurrentPoint.GpsDateTime
        '            GPSDate = m_CurrentPoint.GpsDate
        '        End If
        '    End With
        '    tryCount += 1       ' Increment the try counter
        '    Dim strCaption As String = NULL_STRING

        '    ' If there is not a GPS fix then exit the sub routine
        '    If Not blAquiredFix Then
        '        If Not frmGpsSettings Is Nothing Then
        '            frmGpsSettings.lblGPSMessage.Text = "SEARCHING. . ."
        '            frmGpsSettings.lblGPSMessage.ForeColor = Color.Blue
        '        End If
        '        Me.lblGPSConnectionValue.Text = "SEARCHING. . ."
        '        Me.lblGPSConnectionValue.ForeColor = Color.Blue
        '        Exit Sub
        '    End If
        '    Me.txtTimeSource.ForeColor = Color.LimeGreen
        '    Me.txtTime.ForeColor = Color.LimeGreen
        '    Me.txtDateSource.ForeColor = Color.LimeGreen
        '    Me.tmrGPSExpiry.Stop()
        '    Me.dblGPSExpiry = 0
        '    Me.tmrGPSExpiry.Start()
        '    aquiredTryCount = 0
        '    strCaption = "GPS FIX"
        '    If Not frmGpsSettings Is Nothing Then
        '        frmGpsSettings.lblGPSMessage.Text = strCaption
        '        frmGpsSettings.lblGPSMessage.ForeColor = Color.LimeGreen
        '    End If
        '    Me.lblGPSConnectionValue.Text = strCaption
        '    Me.lblGPSConnectionValue.ForeColor = Color.LimeGreen
        '    Me.lblYValue.ForeColor = Color.LimeGreen
        '    Me.lblXValue.ForeColor = Color.LimeGreen
        '    Me.lblZValue.ForeColor = Color.LimeGreen

        '    ' Change the value of X from positive to negative if necessary
        '    If Me.GPS_X > 0 Then
        '        Me.GPS_X *= -1
        '    End If

        '    ' Format the values to include 5 decimal places
        '    If Not frmGpsSettings Is Nothing Then
        '        frmGpsSettings.lblCurrentYValue.Text = FormatNumber(Me.GPS_Y, 5)
        '        frmGpsSettings.lblCurrentXValue.Text = FormatNumber(Me.GPS_X, 5)
        '        frmGpsSettings.lblCurrentZValue.Text = FormatNumber(Me.GPS_Z, 2)
        '        frmGpsSettings.lblCurrentDateValue.Text = Me.GPSDate
        '        frmGpsSettings.lblCurrentTimeValue.Text = Me.GPSDateTime
        '    End If
        '    If Not frmSetTime Is Nothing Then
        '        frmSetTime.txtSetTime.Text = Me.GPSDateTime
        '    End If
        '    Me.lblYValue.Text = FormatNumber(Me.GPS_Y, 5)
        '    Me.lblXValue.Text = FormatNumber(Me.GPS_X, 5)
        '    Me.lblZValue.Text = FormatNumber(Me.GPS_Z, 2)

        '    Me.txtTimeSource.Text = strTimeDateSource
        '    Me.txtTimeSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
        '    Me.txtTimeSource.BackColor = Color.LightGray

        '    Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
        '    Me.txtTime.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
        '    Me.txtTime.BackColor = Color.LightGray

        '    Me.txtTime.TextAlign = HorizontalAlignment.Center
        '    Me.txtTime.Text = Me.GPSDateTime

        '    Me.txtTransectDate.Text = Me.GPSDate
        '    Me.txtDateSource.Text = strTimeDateSource
        '    Me.txtDateSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
        '    Me.txtDateSource.BackColor = Color.LightGray
        '    '
        '    Me.txtDateSource.TextAlign = HorizontalAlignment.Center
        '    'If dblGPSExpiry < 1 Then
        '    '    Me.txtTimeSource.ForeColor = Color.LimeGreen
        '    '    Me.txtTime.ForeColor = Color.LimeGreen
        '    '    Me.txtTime.Text = Me.GPSDateTime
        '    '    Me.txtDateSource.ForeColor = Color.LimeGreen
        '    'Else
        '    '    Me.txtTimeSource.ForeColor = Color.Red
        '    '    Me.txtTime.ForeColor = Color.Red
        '    '    Me.txtTime.Text = Me.GPSDateTime
        '    '    Me.txtDateSource.ForeColor = Color.Red
        '    'End If
        '    'frmGpsSettings.lblCurrentTimeValue.Text = Me.GPSDateTime
        '    'End If
        '    '     End If
        'Catch ex As Exception
        '    'Dim st As New StackTrace(ex, True)
        '    'Dim frame As StackFrame
        '    'frame = st.GetFrame(0)
        '    'Dim line As Integer
        '    'line = frame.GetFileLineNumber
        '    'MsgBox("At line " & line & " " & ex.Message & " Stack trace: " & st.ToString)
        'End Try

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
        If m_db_file_open Then

            Me.pnlSpeciesData.Controls.Clear()
            fillSpeciesVariableButtonPanel()
        End If
    End Sub

#Region "DataGridView functions and handlers"
    ''' <summary>
    ''' Whether or not the row is synced properly with the database. Used when the user edits a cell value. The cell's row
    ''' will immediately be colored since the data are now 'dirty' but if the value is of the wrong type (not validated)
    ''' then this is required to put the row back into the condition it was in before the current edit attempt.
    ''' </summary>
    Private rowWasGood As Boolean

    ''' <summary>
    ''' Triggered when any cell value is changed in the grid. Will update a label telling the user that the data is no longer synced with the database.
    ''' If the user just types the same value that was in the cell to begin with, the row will be unchanged.
    ''' </summary>
    Private Sub grdVideoMinerDatabase_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles grdVideoMinerDatabase.CurrentCellDirtyStateChanged
        rowWasGood = (grdVideoMinerDatabase.Rows(grdVideoMinerDatabase.CurrentRow.Index).DefaultCellStyle.BackColor <> Color.Salmon)
        If grdVideoMinerDatabase.IsCurrentCellDirty Then
            lblDirtyData.ForeColor = Color.Red
            lblDirtyData.Text = "Data unsynced"
            grdVideoMinerDatabase.Rows(grdVideoMinerDatabase.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Salmon
            grdVideoMinerDatabase.Rows(grdVideoMinerDatabase.CurrentRow.Index).DefaultCellStyle.SelectionBackColor = Color.DarkSalmon
        End If
    End Sub

    ''' <summary>
    ''' Give column and row-specific error message to user. Avoids errors/exceptions during the update to the database.
    ''' </summary>
    Private Sub grdVideoMinerDatabase_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdVideoMinerDatabase.DataError
        Dim strFieldName As String = grdVideoMinerDatabase.Columns(e.ColumnIndex).HeaderText
        If rowWasGood Then
            ' Reset the background color back to white and the selection color back to default 'HighLight'
            grdVideoMinerDatabase.Rows(grdVideoMinerDatabase.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
            grdVideoMinerDatabase.Rows(grdVideoMinerDatabase.CurrentRow.Index).DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        End If
        Select Case strFieldName
            Case "ID"
                MessageBox.Show("Error in column 'ID', row " & e.RowIndex.ToString() & ": Value must be a non-null integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "TransectDate"
                MessageBox.Show("Error in column 'TransectDate', row " & e.RowIndex.ToString() & ": Value must be a DateTime (mm/dd/yyyy).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "TimeCode"
                MessageBox.Show("Error in column 'TimeCode', row " & e.RowIndex.ToString() & ": Value must be a DateTime (mm/dd/yyyy).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "TimeSource"
                MessageBox.Show("Error in column 'TimeSource', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "OnBottom"
                MessageBox.Show("Error in column 'OnBottom', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "DominantSubstrate"
                MessageBox.Show("Error in column 'DominantSubstrate', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "DominantPercent"
                MessageBox.Show("Error in column 'DominantPercent', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "SubdominantSubstrate"
                MessageBox.Show("Error in column 'SubdominantSubstrate', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "SubdominantPercent"
                MessageBox.Show("Error in column 'SubdominantPercent', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "SurveyModeID"
                MessageBox.Show("Error in column 'SurveyModeID', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ReliefID"
                MessageBox.Show("Error in column 'ReliefID', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "DisturbanceID"
                MessageBox.Show("Error in column 'DisturbanceID', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ProtocolID"
                MessageBox.Show("Error in column 'ProtocolID', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ImageQualityID"
                MessageBox.Show("Error in column 'ImageQualityID', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "SpeciesCount"
                MessageBox.Show("Error in column 'SpeciesCount', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Side"
                MessageBox.Show("Error in column 'Side', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Range"
                MessageBox.Show("Error in column 'Range', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Length"
                MessageBox.Show("Error in column 'Length', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Height"
                MessageBox.Show("Error in column 'Height', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Width"
                MessageBox.Show("Error in column 'Width', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Abundance"
                MessageBox.Show("Error in column 'Abundance', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "IDConfidence"
                MessageBox.Show("Error in column 'IDConfidence', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "DataCode"
                MessageBox.Show("Error in column 'DataCode', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "X"
                MessageBox.Show("Error in column 'X', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Y"
                MessageBox.Show("Error in column 'Y', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Z"
                MessageBox.Show("Error in column 'Z', row " & e.RowIndex.ToString() & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ElapsedTime"
                MessageBox.Show("Error in column 'ElapsedTime', row " & e.RowIndex.ToString() & ": Value must be a DateTime.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ReviewedDate"
                MessageBox.Show("Error in column 'ReviewedDate', row " & e.RowIndex.ToString() & ": Value must be a DateTime.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ReviewedTime"
                MessageBox.Show("Error in column 'ReviewedTime', row " & e.RowIndex.ToString() & ": Value must be a DateTime.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub

    ''' <summary>
    ''' Key events for the data grid. The arrow keys will move to adjacent cells, the Enter key will submit the edit (if applicable)
    ''' and move to the next cell down or, if it is currently the last row, the next cell on the right, or if neither of those,
    ''' the top left-most cell. Pressing the 'delete' key will delete rows from the grid view and the database.
    ''' </summary>
    Private Sub grdVideoMinerDatabase_KeyDown(ByVal sender As DataGridView, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdVideoMinerDatabase.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                deleteSelectedRows(sender, e)
        End Select
    End Sub

    ''' <summary>
    ''' Allow keys to be captured while the editor is focussed on an individual cell
    ''' </summary>
    Private Sub grdVideoMinerDatabase_EditingControlShowing(ByVal sender As DataGridView, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdVideoMinerDatabase.EditingControlShowing
        Dim tb As TextBox = CType(e.Control, TextBox)
        AddHandler tb.PreviewKeyDown, AddressOf TextBox_PreviewKeyDown
    End Sub

    ''' <summary>
    ''' Sets up the Enter or Return key to be captured by the TextBox, which is a cell in the DataGridView.
    ''' This is the only way that the Enter key can be used to submit a value when editing a cell.
    ''' </summary>
    Private Sub TextBox_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            e.IsInputKey = True
        End If
    End Sub

    ''' <summary>
    ''' Deletes selected rows from the MS access database as well as in the grid view. A confirmation box will verify this.
    ''' </summary>
    Private Sub deleteSelectedRows(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grdVideoMinerDatabase.SelectedRows.Count > 0 Then
            If MessageBox.Show("Are you sure you want to delete all selected rows from the database? They will be gone forever.", "Delete rows?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
                For Each row As DataGridViewRow In grdVideoMinerDatabase.SelectedRows
                    grdVideoMinerDatabase.Rows.Remove(row)
                Next
                cmdUpdateDatabase_Click(sender, e)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Captures right click in the DataGridView. This will delete rows from the grid view and the database.
    ''' </summary>
    ''' <remarks>If no rows are selected, a message will tell you to select rows and then press delete</remarks>
    Private Sub grdVideoMinerDatabase_RightClick(ByVal sender As DataGridView, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdVideoMinerDatabase.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim cms As ContextMenuStrip = New ContextMenuStrip
            Dim item1 As ToolStripItem
            If grdVideoMinerDatabase.SelectedRows.Count > 0 Then
                item1 = cms.Items.Add("Delete selected rows (or use delete key)")
                item1.Tag = 1
                AddHandler item1.Click, AddressOf deleteSelectedRows
            Else
                item1 = cms.Items.Add("Delete rows by selecting them and pressing delete.")
                item1.Tag = 1
            End If
            cms.Show(grdVideoMinerDatabase, e.Location)
        End If
    End Sub

    ''' <summary>
    ''' Validate the cell values if user makes them NULL. Avoids errors/exceptions during the update to the database.
    ''' </summary>
    Private Sub grdVideoMinerDatabase_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles grdVideoMinerDatabase.CellValidating
        ' Get column name from cell that was changed
        Dim strFieldName As String = grdVideoMinerDatabase.Columns(e.ColumnIndex).HeaderText
        Dim s = e.FormattedValue.ToString()
        Select Case strFieldName
            Case "ID"
                If s = String.Empty Then
                    MessageBox.Show("Error in column 'ID', row " & e.RowIndex.ToString() & ": Value must be a non-null integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                Else
                    ' Check to see that the ID is unique in the grid to avoid exceptions when update query is run later
                    Dim isUnique As Boolean = True
                    For Each row As DataGridViewRow In grdVideoMinerDatabase.Rows
                        If Not row.IsNewRow Then
                            Dim cell As DataGridViewCell = row.Cells("ID")
                            ' Compare new and old values as long as it is not the same row
                            If cell.Value.ToString = e.FormattedValue.ToString And cell.RowIndex <> e.RowIndex Then
                                isUnique = False
                            End If
                        End If
                    Next
                    If Not isUnique Then
                        MessageBox.Show("Error in column 'ID', row " & e.RowIndex.ToString() & ": The value is not unique. 'ID' is the primary key and must have a unique value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        e.Cancel = True
                    End If
                End If
            Case ("DataCode")
                If s = String.Empty Then
                    MessageBox.Show("Error in column 'DataCode', row " & e.RowIndex.ToString() & ": Value must be a non-null integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Update the MS Access database table bound to the data adapter. This allows changes made within the DataGridView to be
    ''' updated inside the actual database.
    ''' </summary>
    Private Sub cmdUpdateDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateDatabase.Click
        Database.Update(m_data_table)
        lblDirtyData.ForeColor = Color.LimeGreen
        lblDirtyData.Text = "Data synced"
        For i As Integer = 0 To grdVideoMinerDatabase.RowCount - 1
            ' Reset the background color back to white and the selection color back to default 'HighLight'
            grdVideoMinerDatabase.Rows(i).DefaultCellStyle.BackColor = Color.White
            grdVideoMinerDatabase.Rows(i).DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Next
    End Sub

    ''' <summary>
    ''' Reload the grid from the access database. A confirmation box will be displayed and if the user aggrees then any changes in the grid will
    ''' be discarded and the database will be reloaded from scratch
    ''' </summary>
    Private Sub cmdRevertDatabase_Click(sender As Object, e As EventArgs) Handles cmdRevertDatabase.Click
        If MessageBox.Show("Are you sure you want to discard all unsynced changes in the grid and revert to the database data?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) Then
            fetch_data()
            lblDirtyData.ForeColor = Color.LimeGreen
            lblDirtyData.Text = "Data synced"
        End If
    End Sub
#End Region


    Private Sub ConfigureButtonFormatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureButtonFormatToolStripMenuItem.Click
        If Not frmConfigureButtonFormat Is Nothing Then
            frmConfigureButtonFormat.Dispose()
            frmConfigureButtonFormat = Nothing
        End If

        frmConfigureButtonFormat = New frmConfigureButtonFormat(m_ButtonHeight, m_ButtonWidth, m_ButtonFont, m_ButtonTextSize)
        frmConfigureButtonFormat.ShowDialog()
    End Sub

    Private Sub cmdScreenCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScreenCapture.Click
        Me.mnuCapScr_Click(sender, e)
    End Sub

    Private Sub tmrGPSExpiry_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        Dim strTime As String = NULL_STRING
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

        Dim strDate As String = NULL_STRING
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

        m_transect_date = strDate
        Me.txtTransectDate.Text = m_transect_date

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

                m_transect_date = strNewDate
                Me.txtTransectDate.Text = m_transect_date
            End If
        End If
    End Sub

    Private Sub EditLookupTableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditLookupTableToolStripMenuItem.Click
        frmEditLookupTable = New frmEditLookupTable
        frmEditLookupTable.ShowDialog()
    End Sub

    Private Sub refresh_database() Handles frmConfigureButtons.RefreshDatabaseEvent, frmKeyboardCommands.RefreshDatabaseEvent, frmSpeciesList.RefreshDatabaseEvent
        blupdateColumns = False
        RefreshDatabase()
        blupdateColumns = True
    End Sub

    Private Sub update_buttons() Handles frmConfigureButtons.UpdateButtons
        Dim txt As TextBox

        For Each txt In textboxes
            If Not txt Is Nothing Then
                If Not txt.Text.StartsWith("No ") Then
                    With txt
                        .BackColor = Color.LightGray
                        .ForeColor = Color.LimeGreen
                        .TextAlign = HorizontalAlignment.Center
                    End With
                End If
            End If
        Next

        For Each txt In Transect_Textboxes
            If Not txt Is Nothing Then
                If Not txt.Text.StartsWith("No ") Then
                    With txt
                        .BackColor = Color.LightGray
                        .ForeColor = Color.LimeGreen
                        .TextAlign = HorizontalAlignment.Center
                    End With
                End If
            End If
        Next
    End Sub

    Public Sub RefreshDatabase()
        blRefresh = True
        Dim dictTempValues As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim dictTempTextBoxValues As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Dim i As Integer

        For i = 0 To strHabitatButtonCodeNames.Length - 2
            dictTempValues.Add(strHabitatButtonCodeNames(i).ToString, dictHabitatFieldValues.Item(strHabitatButtonCodeNames(i).ToString))
        Next

        For i = 0 To strTransectButtonCodeNames.Length - 2
            dictTempValues.Add(strTransectButtonCodeNames(i).ToString, dictTransectFieldValues.Item(strTransectButtonCodeNames(i).ToString))
        Next

        For i = 0 To pnlHabitatData.Controls.Count - 1
            If pnlHabitatData.Controls.Item(i).Name.Substring(0, 3) = "txt" Then
                If pnlHabitatData.Controls.Item(i).Name = strEditTextBoxOldName Then
                    dictTempTextBoxValues.Add(strEditTextBoxNewName, pnlHabitatData.Controls.Item(i).Text)
                Else
                    dictTempTextBoxValues.Add(pnlHabitatData.Controls.Item(i).Name, pnlHabitatData.Controls.Item(i).Text)
                End If
            End If
        Next
        For i = 0 To pnlTransectData.Controls.Count - 1
            If pnlTransectData.Controls.Item(i).Name.Substring(0, 3) = "txt" Then
                If pnlTransectData.Controls.Item(i).Name = strEditTextBoxOldName Then
                    dictTempTextBoxValues.Add(strEditTextBoxNewName, pnlTransectData.Controls.Item(i).Text)
                Else
                    dictTempTextBoxValues.Add(pnlTransectData.Controls.Item(i).Name, pnlTransectData.Controls.Item(i).Text)
                End If
            End If
            'If myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).NaSubstring(0, 3) = "txt" Then
            '    dictTempTextBoxValues.Add(myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Name, myFormLibrary.frmVideoMiner.pnlTransectData.Controls.Item(i).Text)
            'End If
        Next
        'Dim strNewButtonName As String
        'Dim strNewTextBoxName As String

        'CJG
        'If blNewButton Then
        '    strNewButtonName = myFormLibrary.frmAddButton.ButtonName
        '    strNewTextBoxName = "txt" & Replace(strNewButtonName, "%", "Percent")
        '    Dim strCharactersAllowed As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_"

        '    Dim txtName As String = strNewTextBoxName
        '    Dim Letter As String
        '    For x As Integer = 0 To strNewTextBoxNaLength - 1
        '        Letter = strNewTextBoxNaSubstring(x, 1).ToUpper
        '        If strCharactersAllowed.Contains(Letter) = False Then
        '            txtName = txtNaReplace(Letter, String.Empty)
        '        End If
        '    Next

        '    strNewTextBoxName = txtName

        '    dictTempTextBoxValues.Add(strNewTextBoxName, "No " & strNewButtonName)

        'End If
        grdVideoMinerDatabase.DataSource = Nothing
        db_file_unload()
        'myFormLibrary.frmVideoMiner.fillTransectVariableButtonPanel()
        'myFormLibrary.frmVideoMiner.fillSpatialVariableButtonPanel()
        'myFormLibrary.frmVideoMiner.fillHabitatFieldsCollection()
        openDatabase()
        For i = 0 To pnlHabitatData.Controls.Count - 1
            If pnlHabitatData.Controls.Item(i).Name.Substring(0, 3) = "txt" Then
                pnlHabitatData.Controls.Item(i).Text = dictTempTextBoxValues.Item(pnlHabitatData.Controls.Item(i).Name)
            End If

        Next
        For i = 0 To pnlTransectData.Controls.Count - 1
            If pnlTransectData.Controls.Item(i).Name.Substring(0, 3) = "txt" Then
                pnlTransectData.Controls.Item(i).Text = dictTempTextBoxValues.Item(pnlTransectData.Controls.Item(i).Name)
            End If
        Next
        Dim kvPair As KeyValuePair(Of String, String)
        For Each kvPair In dictTempValues
            If dictHabitatFieldValues.ContainsKey(kvPair.Key) Then
                dictHabitatFieldValues.Item(kvPair.Key) = kvPair.Value
            ElseIf dictTransectFieldValues.ContainsKey(kvPair.Key) Then
                dictTransectFieldValues.Item(kvPair.Key) = kvPair.Value
            End If
        Next

        blRefresh = False
        pnlHabitatData.Refresh()
        pnlSpeciesData.Refresh()
        pnlTransectData.Refresh()
    End Sub

    Private Sub grdVideoMinerDatabase_ColumnDisplayIndexChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles grdVideoMinerDatabase.ColumnDisplayIndexChanged
        If blupdateColumns Then
            If Not blOpenDatabase And Not blCloseDatabase Then
                Dim strColumns As String = NULL_STRING
                dataColumns = New Collection
                Dim dgColumn As DataGridViewColumn
                For Each dgColumn In grdVideoMinerDatabase.Columns
                    dataColumns.Add(dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width)
                    strColumns = strColumns & dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width & ","
                Next
                SaveConfiguration("/Database/Configuration/DatabaseName", m_db_filename)
                SaveConfiguration("/Database/Configuration/Columns", strColumns.Substring(0, strColumns.Length - 1))
            End If
        End If
    End Sub

    Private Sub grdVideoMinerDatabase_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles grdVideoMinerDatabase.ColumnWidthChanged
        If blupdateColumns Then
            If Not blOpenDatabase And Not blCloseDatabase Then
                Dim strColumns As String = NULL_STRING
                dataColumns = New Collection
                Dim dgColumn As DataGridViewColumn
                For Each dgColumn In grdVideoMinerDatabase.Columns
                    dataColumns.Add(dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width)
                    strColumns = strColumns & dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width & ","
                Next
                SaveConfiguration("/Database/Configuration/DatabaseName", m_db_filename)
                SaveConfiguration("/Database/Configuration/Columns", strColumns.Substring(0, strColumns.Length - 1))
            End If
        End If
    End Sub

    ''' <summary>
    ''' Set the User time (txtTime) textbox and source time (txtTimeSource) to show
    ''' </summary>
    Private Sub setTimes()
        Dim tsNewTime As TimeSpan
        If frmVideoPlayer IsNot Nothing Then
            tsNewTime = m_tsUserTime + frmVideoPlayer.CurrentVideoTime
        Else
            tsNewTime = m_tsUserTime
        End If
        ' Format the time according to the VIDEO_TIME_FORMAT
        txtTime.Text = String.Format(VIDEO_TIME_FORMAT, tsNewTime.Hours, tsNewTime.Minutes, tsNewTime.Seconds, tsNewTime.Milliseconds)
        txtTime.Font = New Font(NULL_STRING, 10, FontStyle.Bold)
        txtTime.BackColor = Color.LightGray
        txtTime.ForeColor = Color.LimeGreen
        txtTime.TextAlign = HorizontalAlignment.Center
        txtTime.Visible = True
        txtTimeSource.Visible = True
    End Sub

    ''' <summary>
    ''' Set the user time (txtTime) textbox and source time textbox (txtTimeSource) to dissappear
    ''' </summary>
    Private Sub unsetTimes()
        txtTime.Visible = False
        txtTime.Text = NULL_STRING
        txtTimeSource.Visible = False
        txtTimeSource.Text = NULL_STRING
    End Sub

    ''' <summary>
    ''' Gets the new user defined time from the set time form and call setUserTime to apply
    ''' </summary>
    Private Sub time_changed() Handles frmSetTime.TimeChanged
        m_tsUserTime = frmSetTime.UserTime
        setTimes()
    End Sub

    Private Sub species_configuration_update() Handles frmConfigureSpecies.SpeciesConfigurationUpdate
        RangeChecked = frmConfigureSpecies.RangeChecked
        IDConfidenceChecked = frmConfigureSpecies.IDConfidenceChecked
        AbundanceChecked = frmConfigureSpecies.AbundanceChecked
        CountChecked = frmConfigureSpecies.CountChecked
        HeightChecked = frmConfigureSpecies.HeightChecked
        WidthChecked = frmConfigureSpecies.WidthChecked
        LengthChecked = frmConfigureSpecies.LengthChecked
        CommentsChecked = frmConfigureSpecies.CommentsChecked

        Range = frmConfigureSpecies.Range
        Side = frmConfigureSpecies.Side
        IDConfidence = frmConfigureSpecies.IDConfidence
        Abundance = frmConfigureSpecies.Abundance
        Count = frmConfigureSpecies.Count
        SpeciesHeight = frmConfigureSpecies.SpeciesHeight
        SpeciesWidth = frmConfigureSpecies.SpeciesWidth
        Length = frmConfigureSpecies.Length
        Comments = frmConfigureSpecies.Comments
    End Sub

    Private Sub species_button_configuration_changed() Handles frmSpeciesEvent.SpeciesButtonConfigurationChangedEvent
        Range = frmSpeciesEvent.Range
        Side = frmSpeciesEvent.Side
        IDConfidence = frmSpeciesEvent.IDConfidence
        Abundance = frmSpeciesEvent.Abundance
        Count = frmSpeciesEvent.Count
        SpeciesHeight = frmSpeciesEvent.SpeciesHeight
        SpeciesWidth = frmSpeciesEvent.SpeciesWidth
        Length = frmSpeciesEvent.Length
        Comments = frmSpeciesEvent.Comments
        SpeciesCode = frmSpeciesEvent.SpeciesCode
    End Sub

    Private Sub gps_connected() Handles frmGpsSettings.GPSConnectedEvent
        lblGPSPortValue.Text = "OPEN"
        lblGPSPortValue.ForeColor = Color.LimeGreen
        lblGPSConnectionValue.Text = "CONNECTED"
        lblGPSConnectionValue.ForeColor = Color.Blue

        frmSetTime.UserTime = m_GPSUserTime
        frmSetTime.ChangeSource(Global.VideoMiner.frmSetTime.WhichTimeEnum.GPS)
    End Sub

    Private Sub gps_disconnected() Handles frmGpsSettings.GPSDisconnectedEvent
        lblGPSPortValue.Text = "CLOSED"
        lblGPSPortValue.ForeColor = Color.Red
        lblGPSConnectionValue.Text = "NO GPS FIX"
        lblGPSConnectionValue.ForeColor = Color.Red
        lblXValue.Text = NULL_STRING
        lblYValue.Text = NULL_STRING
        lblZValue.Text = NULL_STRING
        txtTime.ForeColor = Color.Red
        txtTimeSource.ForeColor = Color.Red
        txtDateSource.ForeColor = Color.Red

        txtNMEA.Text = NULL_STRING
        txtNMEA.Visible = False
        lblGPSLocation.Visible = False
        lblX.Visible = False
        lblY.Visible = False
        lblZ.Visible = False

        frmSetTime.TimeSource = Global.VideoMiner.frmSetTime.WhichTimeEnum.Video
    End Sub

    Private Sub gps_connecting() Handles frmGpsSettings.ConnectingSerialPortEvent
        lblGPSConnectionValue.Text = "SEARCHING. . ."
        lblGPSConnectionValue.ForeColor = Color.Blue
        lblXValue.ForeColor = Color.Red
        lblYValue.ForeColor = Color.Red
        lblZValue.ForeColor = Color.Red
        txtTransectDate.ForeColor = Color.Red
        txtDateSource.ForeColor = Color.Red
    End Sub

    Private Sub image_form_closing() Handles frmImage.ImageFormClosingEvent
        pnlImageControls.Visible = False
        cmdNothingInPhoto.Visible = False
        image_open = False
        enableDisableImageMenu(False)
        frmImage = Nothing
    End Sub

    Private Sub button_configuration_changed() Handles frmConfigureButtonFormat.ButtonConfigurationChangedEvent
        With frmConfigureButtonFormat
            ButtonHeight = CInt(.txtButtonHeight.Text)
            ButtonWidth = CInt(.txtButtonWidth.Text)
            ButtonFont = .cboButtonFont.Text
            ButtonTextSize = CInt(.cboButtonTextSize.Text)
            blupdateColumns = False
            pnlSpeciesData.Controls.Clear()
            blupdateColumns = True
        End With
    End Sub

    Private Sub species_code_changed() Handles frmRareSpeciesLookup.SpeciesCodeChangedEvent
        SpeciesCode = frmRareSpeciesLookup.lblSpeciesCodeValue.Text
        If frmRareSpeciesLookup.lblCommonNameValue.Text = NULL_STRING Then
            SpeciesName = frmRareSpeciesLookup.lblScientificNameValue.Text
        Else
            SpeciesName = frmRareSpeciesLookup.lblCommonNameValue.Text
        End If
        SpeciesVariableButtonHandler(Me, Nothing)
    End Sub

    Private Sub relay_configuration_changed() Handles frmRelayConfiguration.RelayConfigurationChangedEvent
        ConfigurationSet = frmRelayConfiguration.ConfigurationSet
        RelaySetup = frmRelayConfiguration.RelaySetup
        ParallelCom = frmRelayConfiguration.ParallelCom
        ParallelBaud = frmRelayConfiguration.ParallelBaud
    End Sub

    Private Sub clear_spatial_information() Handles frmTableView.ClearSpatialInformationEvent
        With frmTableView
            ClearSpatial(.SelectedButtonName, .NumButtons, .ButtonNames, .FieldValues, .ButtonCodeNames, .TextBoxes)
        End With
    End Sub

    Private Sub right_arrow_pressed() Handles frmVideoPlayer.RightArrowPressedEvent
        If frmVideoPlayer.IsPlaying Then
            pauseVideo()
        ElseIf frmVideoPlayer.IsPaused Then
            Stepforward()
        End If
    End Sub

    'Private Sub frmVideoMiner_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, frmVideoPlayer.KeyDown
    Private Sub frmVideoMiner_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles frmVideoPlayer.KeyDown
        Select Case e.KeyCode
            Case Keys.Left
                e.Handled = True
            Case Keys.Right
                If frmVideoPlayer.IsPlaying Then
                    pauseVideo()
                ElseIf frmVideoPlayer.IsPaused Then
                    Stepforward()
                End If
                e.Handled = True
            Case Keys.Space
                If frmVideoPlayer.IsPlaying Then
                    pauseVideo()
                ElseIf frmVideoPlayer.IsPaused Then
                    playVideo()
                ElseIf frmVideoPlayer.IsStopped Then
                    playVideo()
                End If
                e.Handled = True
        End Select
    End Sub

    Private Sub txtFramesToSkip_MouseHover(sender As Object, e As EventArgs) Handles txtFramesToSkip.MouseHover
        ttToolTip.Show("Number of frames to skip for frame stepping", Me)
    End Sub

    Private Sub txtFramesToSkip_MouseLeave(sender As Object, e As EventArgs) Handles txtFramesToSkip.MouseLeave
        ttToolTip.Hide(Me)
    End Sub

    ''' <summary>
    ''' Updates all GPS member variables for settings and saves the configuration for all of them (xml file)
    ''' </summary>
    Private Sub save_GPS_configuration() Handles frmGpsSettings.GPSVariablesChangedEvent
        m_strComPort = frmGpsSettings.ComPort
        m_intBaudRate = frmGpsSettings.BaudRate
        m_strNMEAStringType = frmGpsSettings.NMEAStringType
        m_strParity = frmGpsSettings.Parity
        m_dblStopBits = frmGpsSettings.StopBits
        m_intDataBits = frmGpsSettings.DataBits

        SaveConfiguration(XPATH_GPS_COM_PORT, m_strComPort)
        SaveConfiguration(XPATH_GPS_BAUD_RATE, CStr(m_intBaudRate))
        SaveConfiguration(XPATH_GPS_NMEA_STRING, m_strNMEAStringType)
        SaveConfiguration(XPATH_GPS_PARITY, m_strParity)
        SaveConfiguration(XPATH_GPS_STOP_BITS, CStr(m_dblStopBits))
        SaveConfiguration(XPATH_GPS_DATA_BITS, CStr(m_intDataBits))
        SaveConfiguration(XPATH_GPS_TIMEOUT, CStr(m_intTimeout))
    End Sub

    Private Delegate Sub RefreshGPSStatusDelegate()
    Private marshalRefreshGPSStatus As RefreshGPSStatusDelegate = New RefreshGPSStatusDelegate(AddressOf RefreshGPSStatus)

    ''' <summary>
    ''' Refresh the member variables and labels to reflect when the the GPS data changes. 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshGPSStatus()
        If frmGpsSettings.IsConnected Then
            m_GPSUserTime = frmGpsSettings.GPSTime
            m_tsUserTime = frmGpsSettings.GPSTime
            ' Get the GPS location data into Videominer member variables
            m_GPS_X = frmGpsSettings.LatitudeString
            m_GPS_Y = frmGpsSettings.LongitudeString
            m_GPS_Z = frmGpsSettings.ElevationString
            lblXValue.Text = frmGpsSettings.LatitudeDegrees & Chr(&HB0) & "  " & frmGpsSettings.LatitudeMinutes & "'"
            lblYValue.Text = frmGpsSettings.LongitudeDegrees & Chr(&HB0) & "  " & frmGpsSettings.LongitudeMinutes & "'"
            lblZValue.Text = frmGpsSettings.Elevation & "m"
            txtNMEA.Text = frmGpsSettings.NMEAString
            lblX.Visible = True
            lblY.Visible = True
            lblZ.Visible = True
            lblXValue.Visible = True
            lblYValue.Visible = True
            lblZValue.Visible = True
            lblGPSLocation.Visible = True
            txtNMEA.Visible = True
        Else
            lblX.Visible = False
            lblY.Visible = False
            lblZ.Visible = False
            lblXValue.Visible = False
            lblYValue.Visible = False
            lblZValue.Visible = False
            txtNMEA.Visible = False
            lblGPSLocation.Visible = False
            m_tsUserTime = frmSetTime.UserTime
        End If
        txtTime.Text = pad0(m_tsUserTime.Hours) & ":" & pad0(m_tsUserTime.Minutes) & ":" & pad0(m_tsUserTime.Seconds)
    End Sub

    ''' <summary>
    ''' The Set Time form will request GPS time, and this function handles that
    ''' </summary>
    Private Sub frmSetTime_RequestGPS() Handles frmSetTime.RequestGPSTime
        If frmGpsSettings.IsConnected Then
            frmSetTime.UserTime = m_GPSUserTime
            frmSetTime.ChangeSource(frmSetTime.WhichTimeEnum.GPS)
        Else
            frmGpsSettings.ShowDialog()
        End If
    End Sub

    ''' <summary>
    ''' Handles an event to grab the time from the frmSetTime form.
    ''' </summary>
    Private Sub frmSetTime_TimeSourceChanged() Handles frmSetTime.TimeSourceChange
    End Sub

    ''' <summary>
    ''' Handles an event to grab the latests data from the GPS device.
    ''' </summary>
    Private Sub frmGpsSettings_DataChanged() Handles frmGpsSettings.DataChangedEvent
        If Me.InvokeRequired Then
            Me.Invoke(marshalRefreshGPSStatus)
        Else
            RefreshGPSStatus()
        End If
    End Sub

    ''' <summary>
    ''' Handle everything not handled by .NET handlers. This will catch crossthread exceptions as well.
    ''' Important as it gives a message about the error and the stack trace at the time the exception was thrown.
    ''' </summary>
    Sub UnHandledHandler(ByVal sender As Object, ByVal args As System.UnhandledExceptionEventArgs)
        Dim e As Exception = DirectCast(args.ExceptionObject, Exception)

        Console.WriteLine("MyHandler caught : " + e.Message)
        Console.WriteLine("Runtime terminating: {0}", args.IsTerminating)

        Dim st As New StackTrace(e, True)
        Dim frame As StackFrame
        frame = st.GetFrame(0)
        Dim line As Integer
        line = frame.GetFileLineNumber
        MsgBox("At line " & line & " " & e.Message & ". The stack trace is as folows: " & e.StackTrace)

    End Sub

    ''' <summary>
    ''' When the user clicks the X to close the application, this handles that and closes any open forms and sets them up for garbage collection
    ''' </summary>
    Private Sub Me_Closing(sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Are you sure you want to completely close VideoMiner?", "Close VideoMiner?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        Else
            If e.CloseReason = CloseReason.UserClosing Then
                If frmVideoPlayer IsNot Nothing Then
                    frmVideoPlayer.Close()
                    frmVideoPlayer = Nothing
                End If
                If frmGpsSettings IsNot Nothing Then
                    frmGpsSettings.Close()
                    frmGpsSettings = Nothing
                End If
                If frmSetTime IsNot Nothing Then
                    frmSetTime.Close()
                    frmSetTime = Nothing
                End If
                e.Cancel = False
            End If
        End If
    End Sub


    Private Sub VideoMiner_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub

End Class