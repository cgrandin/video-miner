Option Strict Off
' The following 3 imports are necessary for using ADO.NET, which permits database access.
' All times are stored as TimeSpan objects
Imports System.TimeSpan
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Path
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Xml
Imports System.ComponentModel

''' <summary>
''' This is the main form for the program, and instantiates most of the other forms.
''' </summary>
Public Class VideoMiner

#Region "Constants"
    Private Const XPATH_PREVIOUS_PROJECTS As String = "/PreviousProjects"

    Private Const XPATH_DATABASE_PATH As String = "/DatabasePath"
    Private Const XPATH_SESSION_PATH As String = "/SessionPath"
    Private Const XPATH_VIDEO_PATH As String = "/VideoPath"
    Private Const XPATH_IMAGE_PATH As String = "/m_strImagePath"

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

    Private Const PANEL_NAME_SPECIES As String = "SPECIES DATA"
    Private Const PANEL_NAME_HABITAT As String = "HABITAT DATA"
    Private Const PANEL_NAME_TRANSECT As String = "TRANSECT DATA"

    Private Const VIDEO_TIME_FORMAT As String = "{0:D2}:{1:D2}:{2:D2}.{3:D3}" ' D3 = 3 decimal places
    Private Const VIDEO_FRAME_STEP_DEFAULT As Integer = 500
    Public Const DB_ADO_CONN_STRING_1 As String = "Data Source="
    Public Const DB_ADO_CONN_STRING_2 As String = ";Initial Catalog=data"
    Public Const BAD_ID As Long = -1
    Public Const OPEN_DB_TITLE As String = "Open Database"
    Public Const OPEN_VID_TITLE As String = "Open Video"
    Public Const OPEN_IMAGE_TITLE As String = "Open Image"
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

    Public Const ON_OFF_BOTTOM_NOT_ASSIGNED As Integer = -1
    Public Const SPECIES_ID_NOT_ASSIGNED As Integer = -1
    Public Const SPECIES_NAME_NOT_ASSIGNED As String = NULL_STRING
    Public Const SPECIES_COUNT_NOT_ASSIGNED As Integer = -1

#End Region

#Region "Variables"
    ' These are the dynamic panels to be added to the splitcontainers at runtime
    Friend WithEvents pnlTransectData As DynamicPanel
    Friend WithEvents pnlHabitatData As DynamicPanel
    Friend WithEvents pnlSpeciesData As DynamicPanel
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
    ''' Holds the path of the last known path for pictures as entered by the user in the OpenFileDialog
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strImagePath As String
    ''' <summary>
    ''' Hold the currently loaded image's filename without path information
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strImageFile As String
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
    Private m_dblVideoRate As Double = 1.0
    ''' <summary>
    ''' Are we in a transect currently or not?
    ''' </summary>
    ''' <remarks></remarks>
    Private m_blInTransect As Boolean = vbFalse

    ''' <summary>
    ''' Holds the data table for the actual project data being recorded
    ''' </summary>
    Private m_data_table As DataTable
    ''' <summary>
    ''' Holds the data code table for the project. This will be passed to the various DynamicPanels
    ''' so that they can link their data to the proper data code
    ''' </summary>
    Private m_data_codes_table As DataTable
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
    Private Transect_Textboxes() As DynamicTextbox
    Private strTransectButtonCodeNames() As String
    Private Transect_Buttons() As DynamicButton
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

    ''' <summary>
    ''' Coloring of a row in the data grid. When a field is sorted by clicking the column header, the coloring is recorded, then the grid is sorted,
    ''' then the coloring is re-applied by using the key field 'ID'. This structure represents a single row in the grid. The two cell arrays hold the
    ''' background and foreground colors for the cells in the row.
    ''' </summary>
    Structure stcRowColoring
        Public id As String
        Public rowCol As Color
        Public cellForegroundCols As Color()
        Public cellBackgroundCols As Color()
    End Structure
    ''' <summary>
    ''' An array of row colorings to keep track of dirty cells when the columns are sorted.
    ''' </summary>
    Private arrColoring As stcRowColoring()
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

    Public Property VideoFileName() As String
        Get
            If m_strVideoPath = NULL_STRING And m_strVideoFile = NULL_STRING Then
                Return "External Video"
            Else
                Return Combine(m_strVideoPath, m_strVideoFile)
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
        frmSpeciesList = New frmSpeciesList
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
        Text = Name & " - " & Version & " - BETA"

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
        video_file_unload()
        no_files_loaded()
        m_transect_name = UNNAMED_TRANSECT
        curr_code = BAD_ID
        is_on_bottom = 0
        toggle_bottom()

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
        m_transect_date = DateTime.ParseExact(strDate, "dd/MM/yyyy", Nothing)
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

        ' Add DynamicPanels to the SplitContainerPanels
        pnlTransectData = New DynamicPanel(PANEL_NAME_TRANSECT, True, Me.ButtonWidth, Me.ButtonHeight, Me.ButtonFont, Me.ButtonTextSize, True, True)
        SplitContainer7.Panel1.Controls.Add(pnlTransectData)

        pnlHabitatData = New DynamicPanel(PANEL_NAME_HABITAT, True, Me.ButtonWidth, Me.ButtonHeight, Me.ButtonFont, Me.ButtonTextSize, True, True)
        SplitContainer7.Panel2.Controls.Add(pnlHabitatData)

        pnlSpeciesData = New DynamicPanel(PANEL_NAME_SPECIES, False, Me.ButtonWidth, Me.ButtonHeight, Me.ButtonFont, Me.ButtonTextSize, False)
        pnlSpeciesData.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        pnlSpeciesData.Dock = DockStyle.Fill
        'AddHandler pnlSpeciesData.NewSpeciesEntryEvent, AddressOf new_species_entry_handler
        SplitContainer8.Panel2.Controls.Add(pnlSpeciesData)

        ' Create this form once, since it loads comboboxes with large amounts of data.
        frmRareSpeciesLookup = New frmRareSpeciesLookup

    End Sub

    ''' <summary>
    ''' Handles the event request to insert a new entry into the database.
    ''' </summary>
    Private Sub new_species_entry_handler(speciesName As String, speciesCode As String, range As String, side As String,
                                          idConfidence As String, abundance As String, count As String, height As String,
                                          width As String, length As String, comments As String)

        'MsgBox("Made it here! - Videominer main form")
        ' Here is where the call to build the query goes...
    End Sub

    Private Sub signal_video_pause(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlHabitatData.SignalVideoPause, pnlTransectData.SignalVideoPause, pnlSpeciesData.SignalVideoPause
        'frmVideoPlayer.pauseVideo()
    End Sub

    ''' <summary>
    ''' Load the metadata found in the VideoMiner configuration file into member variables.
    ''' If the configuration file is not found, defaults will be assigned for GPS settings
    ''' and the path variables.
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
                m_strImagePath = GetConfiguration(XPATH_IMAGE_PATH)
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
                If m_strImagePath = NULL_STRING Then
                    m_strImagePath = m_strWorkingPath
                    SaveConfiguration(XPATH_IMAGE_PATH, m_strImagePath)
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

    ''' <summary>
    ''' Test for SaveConfiguration function. Can be deleted once project complete.
    ''' </summary>
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
                                'SpeciesVariableButtonHandler(speciesButtons(intIndex), Nothing)
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
            SaveConfiguration(XPATH_DATABASE_PATH, m_strDatabasePath)
            openDatabase()
        End If
    End Sub

    ''' <summary>
    ''' When the user clicks "Close Database" in the file menu, close the currently open database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCloseDatabase.Click
        blCloseDatabase = True
        grdVideoMinerDatabase.DataSource = Nothing
        m_db_file_open = False
        'db_file_unload()
        closeDatabase()
        no_files_loaded()
        'Me.cmdDefineAllTransectVariables.Visible = False
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
        'refresh_database()
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

            VideoFileName = "External Video"
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

        ' Create the insert query for the transect start/stop button
        ' Need to merge dictionaries for Habitat and Transect panels here to the Off Bottom/ On Bottom  KeyValuePair
        Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = pnlHabitatData.Dictionary
        Dim tuple As Tuple(Of String, String, Boolean)

        For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In pnlTransectData.Dictionary
            If dict.ContainsKey(kvp.Key) Then
                dict.Remove(kvp.Key)
            End If
            dict.Add(kvp.Key, kvp.Value)
        Next
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
            'tuple = New Tuple(Of String, String, Boolean)("3", is_on_bottom, True)
            'dict.Add("OnBottom", tuple)
            If dict.ContainsKey("DataCode") Then
                dict.Remove("DataCode")
            End If
            tuple = New Tuple(Of String, String, Boolean)(1, "1", False)
            dict.Add("DataCode", tuple)
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
            If dict.ContainsKey("DataCode") Then
                dict.Remove("DataCode")
            End If
            tuple = New Tuple(Of String, String, Boolean)(2, "2", False)
            dict.Add("DataCode", tuple)
            m_transect_name = NULL_STRING
        End If
        runInsertQuery(dict)
        fetch_data()
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


        toggle_bottom()

        If blVideoWasPlaying = True Then
            playVideo()
            blVideoWasPlaying = False
        End If


    End Sub

    ''' <summary>
    ''' Handler to check to make sure that the Data grid is not dirty. If it isn't, or the user says to disregard changes and save the record anyway,
    ''' the appropriate thing will happen for data recording (species event form will be shown or data table form sill be shown, or quick entry will happen).
    ''' </summary>
    Private Sub button_CheckForDirtyDataEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlHabitatData.CheckForDirtyDataEvent, pnlTransectData.CheckForDirtyDataEvent, pnlSpeciesData.CheckForDirtyDataEvent
        If TypeOf sender Is DynamicButton Then
            Dim btn As DynamicButton = CType(sender, DynamicButton)
            ' If the data table is not dirty...
            If IsNothing(m_data_table.GetChanges()) Then
                If btn.WhichType = DynamicButton.WhichTypeEnum.Singular Then
                    If radQuickEntry.Checked Then
                        btn.RecordQuick(txtQuickSpeciesCount.Text)
                    ElseIf radAbundanceEntry.Checked Then
                        btn.RecordAbundance()
                    Else
                        btn.ShowDataForm()
                    End If
                Else
                    btn.ShowDataForm()
                End If
            Else
                If My.Computer.Keyboard.CtrlKeyDown Then
                    btn.ShowDataForm()
                    Exit Sub
                End If
                If MessageBox.Show("You have unsynced changes in your data table. Discard changes and record data anyway?", "Data table dirty", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    fetch_data() ' Cleans up the table first
                    If btn.WhichType = DynamicButton.WhichTypeEnum.Singular Then
                        If radQuickEntry.Checked Then
                            btn.RecordQuick(txtQuickSpeciesCount.Text)
                        Else
                            btn.ShowDataForm()
                        End If
                    Else
                        btn.ShowDataForm()
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Build a dictionary and run an insert query for a screenshot event. The Habitat and Transect panels' data will be merged into the dictionary prior to insertion.
    ''' </summary>
    ''' <param name="filename">The name of the file the screenshot was captured to</param>
    Private Sub runInsertQueryScreenshot(filename As String)
        Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = New Dictionary(Of String, Tuple(Of String, String, Boolean))
        Dim tuple As Tuple(Of String, String, Boolean)
        pnlHabitatData.buildDictionary()
        pnlTransectData.buildDictionary()
        ' Merge the two dictionaries from HABITAT and TRANSECT panels
        For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In pnlTransectData.Dictionary
            dict.Add(kvp.Key, kvp.Value)
        Next
        For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In pnlHabitatData.Dictionary
            dict.Add(kvp.Key, kvp.Value)
        Next
        If dict.ContainsKey("DataCode") Then
            dict.Remove("DataCode")
        End If
        ' Add the datacode information for a screenshot event
        tuple = New Tuple(Of String, String, Boolean)("555", "555", True)
        dict.Add("DataCode", tuple)
        ' Add the comment information for a screenshot event
        tuple = New Tuple(Of String, String, Boolean)(DoubleQuote("Screen Capture"), DoubleQuote("Screen Capture"), False)
        dict.Add("Comment", tuple)
        ' Add the filename information for a screenshot event
        tuple = New Tuple(Of String, String, Boolean)(DoubleQuote(filename), DoubleQuote(filename), False)
        dict.Add("ScreenCaptureName", tuple)
        runInsertQuery(dict)
        fetch_data()
    End Sub

    ''' <summary>
    ''' Handle the changing of button data by creating an insert query and saving to the database
    ''' </summary>
    Private Sub buttonDataChanged(sender As System.Object, e As System.EventArgs) Handles pnlHabitatData.DataChanged, pnlTransectData.DataChanged, pnlSpeciesData.DataChanged
        Dim panel As DynamicPanel = CType(sender, DynamicPanel)
        Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = panel.Dictionary
        Dim tuple As Tuple(Of String, String, Boolean)
        ' If the calling panel is the species panel, check the setting of the habitat and transect panels and if set to record on every record,
        ' merge the two dictionaries before running the insert query.
        Select Case panel.Name
            Case PANEL_NAME_SPECIES
                pnlHabitatData.buildDictionary()
                pnlTransectData.buildDictionary()
                ' Merge the two dictionaries from HABITAT and TRANSECT panels
                For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In pnlTransectData.Dictionary
                    dict.Add(kvp.Key, kvp.Value)
                Next
                For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In pnlHabitatData.Dictionary
                    dict.Add(kvp.Key, kvp.Value)
                Next
                If dict.ContainsKey("DataCode") Then
                    dict.Remove("DataCode")
                End If
                ' Add the datacode information for a species event
                tuple = New Tuple(Of String, String, Boolean)("4", "4", True)
                dict.Add("DataCode", tuple)
            Case PANEL_NAME_HABITAT
                pnlTransectData.buildDictionary()
                ' Merge the dictionary from TRANSECT panel
                For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In pnlTransectData.Dictionary
                    dict.Add(kvp.Key, kvp.Value)
                Next
                ' Need to add the DataCode, based on which of the dictionary entries has it's key.item3 set to True, i.e. which button was pressed
                ' before this dictionary was made.
                For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In dict
                    If kvp.Value.Item3 Then
                        tuple = New Tuple(Of String, String, Boolean)(kvp.Value.Item1, kvp.Value.Item1, True)
                    End If
                Next
                dict.Add("DataCode", tuple)
            Case PANEL_NAME_TRANSECT
                ' Merge the dictionary from TRANSECT panel
                ' Need to add the DataCode, based on which of the dictionary entries has it's key.item3 set to True, i.e. which button was pressed
                ' before this dictionary was made.
                pnlHabitatData.buildDictionary()
                For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In pnlHabitatData.Dictionary
                    dict.Add(kvp.Key, kvp.Value)
                Next
                For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In dict
                    If kvp.Value.Item3 Then
                        tuple = New Tuple(Of String, String, Boolean)(kvp.Value.Item1, kvp.Value.Item1, True)
                    End If
                Next
                dict.Add("DataCode", tuple)
        End Select

        runInsertQuery(dict)
        fetch_data()
        ' frmVideoPlayer.playVideo()
    End Sub

    ''' <summary>
    ''' Handles the storage of a record from when the user chooses a species from the Rare species form.
    ''' </summary>
    ''' <param name="sender">Instance of the frmRareSpeciesForm</param>
    Private Sub rareSpeciesDataChanged(sender As System.Object, e As System.EventArgs) Handles frmRareSpeciesLookup.SpeciesCodeChangedEvent
        Dim frm As frmSpeciesEvent = CType(sender, frmSpeciesEvent)
        Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = frm.Dictionary
        Dim tuple As Tuple(Of String, String, Boolean)
        ' Need to merge the dictionaries from TRANSECT and HABITAT panels before adding
        pnlTransectData.buildDictionary()
        ' Merge the dictionary from TRANSECT panel
        For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In pnlTransectData.Dictionary
            dict.Add(kvp.Key, kvp.Value)
        Next
        pnlHabitatData.buildDictionary()
        ' Merge the dictionary from TRANSECT panel
        For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In pnlHabitatData.Dictionary
            dict.Add(kvp.Key, kvp.Value)
        Next
        ' Need to add the DataCode of '4' in for a species record.
        '        If frm.Dictionary.ContainsKey("DataCode") Then
        'frm.Dictionary.Remove("DataCode")
        'End If
        tuple = New Tuple(Of String, String, Boolean)("4", "4", True)
        dict.Add("DataCode", tuple)

        runInsertQuery(dict)
        fetch_data()
    End Sub

    ''' <summary>
    ''' Brings up the edit species dialog (frmSpeciesList) which allows the user to change the order of the species buttons
    ''' and to delete them, edit them, or add new ones.
    ''' </summary>
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        frmSpeciesList.Show()
    End Sub

    ''' <summary>
    ''' When the user has changed the species buttons from the frmSpeciesEvent form, this function will remove and re-add the DynamicPanel
    ''' which contains the species buttons.
    ''' </summary>
    Private Sub speciesButtonsChanged() Handles frmSpeciesList.SpeciesButtonsChangedEvent
        pnlSpeciesData.fillPanel(DB_SPECIES_BUTTONS_TABLE)
    End Sub

    Public Sub mnuCapScr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCapScr.Click
        capture_screen_image()
    End Sub

    Private Sub cmdScreenCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScreenCapture.Click
        capture_screen_image()
    End Sub

    ''' <summary>
    ''' Capture a screenshot of the video at it's current position, and write a transection to the database.
    ''' </summary>
    Public Sub capture_screen_image() Handles frmVideoPlayer.CaptureScreenEvent
        If Not m_video_file_open Then
            MessageBox.Show("Cannot capture screen unless video is open.", "No Video Open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        ' Convert slashes in date to underscores, and colons in time to underscores
        Dim strDate As String = m_transect_date.ToString("d").Replace("/", "_")
        Dim strTime As String = (m_tsUserTime + frmVideoPlayer.CurrentVideoTime).ToString().Replace(":", "_")
        Dim strDefaultFilename As String = "Capture_" & Me.txtProjectName.Text & "_" & strDate & "_" & strTime
        Dim strFileName As String = frmVideoPlayer.captureScreen(strDate, strTime, strDefaultFilename)
        ' Enter record into the database
        If Database.IsOpen And strFileName <> NULL_STRING Then
            runInsertQueryScreenshot(strFileName)
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
        End If
    End Sub

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

                    'query = createInsertQuery(NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                    'Database.ExecuteNonQuery(query)
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
                    'query = createInsertQuery(NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                    ' Database.ExecuteNonQuery(query)
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

    Private Sub chkRepeatVariables_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer
        If True Then
            'If Me.chkRepeatVariables.Checked = True Then
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

            If True Then
                '    If Me.chkRepeatVariables.Checked = False Then
                For j = 0 To intNumHabitatButtons - 1
                    dictHabitatFieldValues(strHabitatButtonCodeNames(j).ToString) = "-9999"
                Next
            End If

            If tc.ToString() <> NULL_STRING Then
                ' Insert new record in database
                Dim numrows As Integer

                'query = createInsertQuery(COMMENT_ADDED, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                'Database.ExecuteNonQuery(query)
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

                    'query = createInsertQuery(NOTHING_IN_PHOTO, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS, NS)
                    'Database.ExecuteNonQuery(query)
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
            SaveConfiguration(XPATH_SESSION_PATH, m_strSessionPath)
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
                VideoFileName = strImageFileName.Substring(strImageFileName.LastIndexOf("\") + 1, (strImageFileName.Length - strImageFileName.LastIndexOf("\") - 1))

                ' set the flag "image_open" to be true.
                image_open = True
                ' Store the path of the current folder so that we can read 
                ' all the images under the current directory
                Dim m_strImagePath As String = strImageFileName.Substring(0, strImageFileName.LastIndexOf("\") + 1)
                Dim allFiles As String() = Directory.GetFiles(m_strImagePath)
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
                VideoFileName = strVideoFilePath.Substring(strVideoFilePath.LastIndexOf("\") + 1, strVideoFilePath.Length - strVideoFilePath.LastIndexOf("\") - 1)
                If frmVideoPlayer Is Nothing Then
                    frmVideoPlayer = New frmVideoPlayer(VideoFileName, VIDEO_TIME_FORMAT)
                    'frmVideoPlayer.pnlHideVideo.Visible = True
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
                    'frmVideoPlayer.pnlHideVideo.Visible = True
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

    Private Function createXMLSessionFile(ByVal strFileName As String, ByVal blVideoOpen As Boolean, ByVal strVideo As String, ByVal strTime As String,
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
    ''' Once the database is open, toggle the buttons depending on the video file status
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub database_is_open_toggle_visibility()
        Me.radQuickEntry.Visible = True
        Me.radDetailedEntry.Visible = True
        Me.radAbundanceEntry.Visible = True
        Me.cmdEdit.Visible = True
        Me.cmdUpdateDatabase.Visible = True
        Me.cmdRevertDatabase.Visible = True
        Me.lblDirtyData.Visible = True
        Me.cmdRareSpeciesLookup.Visible = True

        If m_video_file_open Then
            Me.txtTransectDate.Enabled = True
            Me.txtProjectName.Enabled = True
            Me.chkRecordEachSecond.Enabled = True
            Me.mnuConfigureTools.Enabled = True
            Me.mnuRefreshForm.Enabled = True
            Me.KeyboardShortcutsToolStripMenuItem.Enabled = True
            Me.DataCodeAssignmentsToolStripMenuItem.Enabled = True
            Me.cmdShowSetTimecode.Enabled = True
            Me.cmdTransectStart.Enabled = True
            Me.cmdOffBottom.Enabled = True
        End If
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
        Me.mnuConfigureTools.Enabled = True
        Me.mnuRefreshForm.Enabled = True
        Me.KeyboardShortcutsToolStripMenuItem.Enabled = True
        Me.DataCodeAssignmentsToolStripMenuItem.Enabled = True

    End Sub

    ''' <summary>
    ''' Change text in OnOffBottomTextbox and on OffBottom button between "Off Bottom" and "On Bottom", and insert a record in the database to reflect this change
    ''' </summary>
    Private Sub toggle_bottom()
        If IsNothing(pnlHabitatData) Or IsNothing(pnlTransectData) Then
            Exit Sub
        End If
        If is_on_bottom Then
            txtOnOffBottomTextbox.Text = OFF_BOTTOM_STRING
            txtOnOffBottomTextbox.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            txtOnOffBottomTextbox.BackColor = Color.LightGray
            txtOnOffBottomTextbox.ForeColor = Color.Red
            txtOnOffBottomTextbox.TextAlign = HorizontalAlignment.Center
            cmdOffBottom.Text = ON_BOTTOM_STRING
            cmdOffBottom.Refresh()
            is_on_bottom = 0
        Else
            txtOnOffBottomTextbox.Text = ON_BOTTOM_STRING
            txtOnOffBottomTextbox.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            txtOnOffBottomTextbox.BackColor = Color.LightGray
            txtOnOffBottomTextbox.ForeColor = Color.LimeGreen
            txtOnOffBottomTextbox.TextAlign = HorizontalAlignment.Center
            cmdOffBottom.Text = OFF_BOTTOM_STRING
            cmdOffBottom.Refresh()
            is_on_bottom = 1
        End If
        ' Need to merge dictionaries for Habitat and Transect panels here to the Off Bottom/ On Bottom  KeyValuePair
        Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = pnlHabitatData.Dictionary
        Dim tuple As Tuple(Of String, String, Boolean)

        For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In pnlTransectData.Dictionary
            If dict.ContainsKey(kvp.Key) Then
                dict.Remove(kvp.Key)
            End If
            dict.Add(kvp.Key, kvp.Value)
        Next
        If dict.ContainsKey("OnBottom") Then
            dict.Remove("OnBottom")
        End If
        tuple = New Tuple(Of String, String, Boolean)("3", is_on_bottom, True)
        dict.Add("OnBottom", tuple)
        If dict.ContainsKey("DataCode") Then
            dict.Remove("DataCode")
        End If
        tuple = New Tuple(Of String, String, Boolean)(3, "3", False)
        dict.Add("DataCode", tuple)

        runInsertQuery(dict)
        fetch_data()
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

    ''' <summary>
    ''' Open an image in windows media player
    ''' </summary>
    Private Sub mnuOpenImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenImg.Click
        openImage()
    End Sub

    ''' <summary>
    ''' Open a video file. Creates a new instance of frmVideoPlayer
    ''' </summary>
    ''' <returns>Boolean representing success</returns>
    ''' <remarks>Returns True if the user chose an existing file to play, False is they pressed cancel or clicked the 'X'</remarks>
    Private Function openImage() As Boolean
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.Title = OPEN_IMAGE_TITLE
        ofd.InitialDirectory = m_strImagePath
        ofd.Filter = "All types (*.*)|*.*|Joint Photographic Experts Group (*.jpg)|*.jpg|Graphics Interchange Format (*.gif)|*.gif|Portable Network Graphics (*.png)|*.png|Tagged Image File Format (*.tiff)|*.tiff"
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True
        ofd.Multiselect = False
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_strImagePath = Path.GetDirectoryName(ofd.FileName)
            ' Store the new image path in XML file each time an image is opened
            SaveConfiguration(XPATH_IMAGE_PATH, m_strImagePath)
            m_strImageFile = GetFileName(ofd.FileName)
            If frmImage Is Nothing Then
                frmImage = New frmImage()
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
            currentImage = m_strImageFile
            frmImage.PictureBox1.Image = Image.FromFile(Combine(m_strImagePath, m_strImageFile))
            image_open = True
            ' Retrieve all files in the directory selected
            Dim allFiles As String() = Directory.GetFiles(m_strImagePath)
            imageFilesList = New List(Of String)
            Dim imageFileDirectory As FileInfo() = New DirectoryInfo(m_strImagePath).GetFiles()
            Dim extensionList As String() = {".jpg", ".png", ".tiff", ".bmp", ".gif"}
            For Each logFile As IO.FileInfo In imageFileDirectory
                Dim extension As String = GetExtension(logFile.Name)
                If extensionList.Contains(extension.ToLower()) Then
                    imageFilesList.Add(logFile.Name)
                End If
            Next
            Dim j As String = Combine(m_strImagePath, m_strImageFile)
            frmImage.PictureBox1.Image = New Bitmap(Combine(m_strImagePath, m_strImageFile))
            frmImage.Text = Combine(m_strImagePath & m_strImageFile)
            'TODO: Implement EXIF data for the pictures. Both saving and loading. Huge task.
            Dim dictEXIF As Dictionary(Of String, String) = getEXIFData()
            'Me.txtTimeSource.ForeColor = Color.LimeGreen
            'Me.txtTime.ForeColor = Color.LimeGreen
            'txtTimeSource.Text = "EXIF"
            'intTimeSource = 3
            'txtTimeSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            'txtTimeSource.BackColor = Color.LightGray
            'txtTimeSource.ForeColor = Color.LimeGreen
            'txtTimeSource.TextAlign = HorizontalAlignment.Center
            'txtTime.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            'txtTime.BackColor = Color.LightGray
            'txtTime.ForeColor = Color.LimeGreen
            'txtTime.TextAlign = HorizontalAlignment.Center
            'txtTransectDate.Text = m_transect_date
            'txtDateSource.Text = "EXIF"
            'txtDateSource.Font = New Font(NULL_STRING, STATUS_FONT_SIZE, FontStyle.Bold)
            'txtDateSource.BackColor = Color.LightGray
            'txtDateSource.ForeColor = Color.LimeGreen
            'txtDateSource.TextAlign = HorizontalAlignment.Center

            ' We try to store the name of all the files under this folder
            ' and then separate each file name using "|".
            'For i = 0 To allFiles.Length - 1
            '    tempFileName = allFiles(i)
            '    'MsgBox(VideoFileName & " : " & tempFileName.Substring(tempFileName.LastIndexOf("\") + 1, tempFileName.Length - 1 - tempFileName.LastIndexOf("\")))
            '    Dim subPostFix As String = tempFileName.Substring(tempFileName.Length - 4, 4)
            '    If subPostFix = ".JPG" Or subPostFix = ".jpg" Or subPostFix = ".bmp" Or subPostFix = ".BMP" _
            '      Or subPostFix = ".gif" Or subPostFix = ".GIF" Or subPostFix = ".png" Or subPostFix = ".PNG" Then
            '        cur_folder_files = String.Concat(cur_folder_files, tempFileName.Substring(tempFileName.LastIndexOf("\") + 1, tempFileName.Length - 1 - tempFileName.LastIndexOf("\")), "|")
            '        MsgBox(tempFileName.Substring(tempFileName.LastIndexOf("\") + 1, tempFileName.Length - 1 - tempFileName.LastIndexOf("\")))
            '        intIndex += 1
            '    End If

            '    If VideoFileName = tempFileName.Substring(tempFileName.LastIndexOf("\") + 1, tempFileName.Length - 1 - tempFileName.LastIndexOf("\")) Then
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

            'fldlgOpenFD.Reset()

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
        Else
            Return False
        End If


        Return True
    End Function

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
    '                    intAnswer = MessageBox.Show("You have reached the last image In the folder, would you Like To start again at the first image?", "Last Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
    '                    intAnswer = MessageBox.Show("You have reached the first image In the folder, would you Like To start again at the last image?", "First Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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

    ''' <summary>
    ''' Retreives the EXIF metadata from the image file given by m_strImageFile in the
    ''' directory m_strImagePath.
    ''' </summary>
    Private Function getEXIFData() As Dictionary(Of String, String)
        lblGPSLocation.Visible = False
        lblX.Visible = False
        lblXValue.Visible = False
        lblY.Visible = False
        lblYValue.Visible = False
        lblZ.Visible = False
        lblZValue.Visible = False
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
        Dim dictEXIFOutput As Dictionary(Of String, String) = New Dictionary(Of String, String)
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
                dictEXIFOutput.Add(key, value)
            End If
        Next
        Return dictEXIFOutput
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
    End Function
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
                    w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width / 4
                    h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height / 4
                Case "50%"
                    w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width / 2
                    h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height / 2
                Case "75%"
                    w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width / 1.3333
                    h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height / 1.3333
                Case "100%"
                    w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width
                    h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height
                Case "200%"
                    w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width * 2
                    h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height * 2
                Case Else
                    Dim intValue As Integer
                    Dim dblImageSize As Double
                    intValue = cboZoom.Text.Substring(0, cboZoom.Text.Length - 1)

                    If intValue <= 100 Then
                        dblImageSize = 100 / intValue
                        w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width / dblImageSize
                        h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height / dblImageSize
                    Else
                        dblImageSize = intValue / 100
                        w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width * dblImageSize
                        h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height * dblImageSize
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


    ''' <summary>
    ''' This Function is() the common part For the Next 4 functions.
    ''' Basic it takes the width Of height Of the image And redraw the
    ''' Image inside the display window.
    ''' </summary>
    ''' <param name="w"></param>
    ''' <param name="h"></param>
    Public Sub redraw_Image(ByVal w As Integer, ByVal h As Integer)
        Try
            Dim bmp As Bitmap = New Bitmap(Image.FromFile(m_strImagePath & imageFilesList(image_index)), w, h)
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
                w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width / 4
                h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height / 4
            Case "50%"
                w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width / 2
                h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height / 2
            Case "75%"
                w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width / 1.3333
                h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height / 1.3333
            Case "100%"
                w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width
                h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height
            Case "200%"
                w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width * 2
                h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height * 2
            Case Else
                Dim intValue As Integer
                Dim dblImageSize As Double
                intValue = cboZoom.Text.Substring(0, cboZoom.Text.Length - 1)

                If intValue <= 100 Then
                    dblImageSize = 100 / intValue
                    w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width / dblImageSize
                    h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height / dblImageSize
                Else
                    dblImageSize = intValue / 100
                    w = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Width * dblImageSize
                    h = Image.FromFile(m_strImagePath & imageFilesList(image_index)).Height * dblImageSize
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

            Dim Dir As String = m_strImagePath & imageFilesList(image_index)
            Dim bmp As Bitmap = New Bitmap(Image.FromFile(Dir), w, h)
            Dim g As Graphics = Graphics.FromImage(bmp)
            frmImage.PictureBox1.Image = bmp
            frmImage.Text = imageFilesList(image_index)
            VideoFileName = imageFilesList(image_index)
            currentImage = m_strImagePath & imageFilesList(image_index)
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
            pauseVideo()
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
        ofd.Filter = "All types (*.*)|*.*|MPEG types|*.m*|Windows Media Video (*.wmv)|*.wmv|Audio Video Interleaved (*.avi)|*.avi|Quicktime (*.qt, *.mov)|*.qt;*.mov|Video OBject (*.vob)|*.vob"
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True
        ofd.Multiselect = False
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_strVideoPath = Path.GetDirectoryName(ofd.FileName)
            ' Store the new video path in XML file each time a video is opened
            SaveConfiguration(XPATH_VIDEO_PATH, m_strVideoPath)
            m_strVideoFile = Path.GetFileName(ofd.FileName)
        Else
            Return False
        End If

        If frmVideoPlayer Is Nothing Then
            Try
                frmVideoPlayer = New frmVideoPlayer(VideoFileName, VIDEO_TIME_FORMAT)
            Catch ex As Exception
                MessageBox.Show("Error creating the video player form. Error message is: " & vbCrLf & ex.Message)
                Return False
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
                frmVideoPlayer.TopMost = True
            Else
                'aPoint.X = intX + priMon.Bounds.Width

                'aPoint.Y = intY / 2
                ' Use these settings when debugging, and comment out the windowstate and topmost lines below
                aPoint.X = intX + priMon.Bounds.Width / 3
                aPoint.Y = intY / 4
                frmVideoPlayer.Location = aPoint
                'frmVideoPlayer.WindowState = FormWindowState.Maximized
                'frmVideoPlayer.TopMost = True
            End If
            Me.VideoTime = Zero
            frmVideoPlayer.Show()
            'frmVideoPlayer.pnlHideVideo.Visible = True
            pnlVideoControls.Visible = True
            Me.txtTransectDate.Enabled = True
            Me.txtProjectName.Enabled = True
            Me.chkRecordEachSecond.Enabled = True
            Me.mnuConfigureTools.Enabled = True
            Me.mnuRefreshForm.Enabled = True
            Me.KeyboardShortcutsToolStripMenuItem.Enabled = True
            Me.DataCodeAssignmentsToolStripMenuItem.Enabled = True
            If Database.IsOpen Then
                Me.cmdTransectStart.Enabled = True
                Me.cmdOffBottom.Enabled = True
                Me.txtProjectName.Enabled = True
            End If

            ' In the future if the frames per second are returned properly, this will show that in the status bar..
            'Me.lblVideo.Text = "Video File '" & VideoFileName & "' is open (" & frmVideoPlayer.FPS & " frames per second)"
            Me.lblVideo.Text = "Video File '" & VideoFileName & "' is open"
            m_video_file_open = True
            Return True
        Else
            'frmVideoPlayer.frmVideoPlayer_Load(Me, New System.EventArgs)
            'Me.VideoTime = frmVideoPlayer.CurrentVideoTime
            Return False
        End If
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

    ''' <summary>
    ''' When the video file is closed, change labels and timecodes to reflect the closure
    ''' </summary>
    Public Sub video_file_unload()
        If Not frmVideoPlayer Is Nothing Then
            frmVideoPlayer.Hide()
            frmVideoPlayer.Dispose()
            frmVideoPlayer = Nothing
        End If
        lblVideo.Text = VIDEO_FILE_STATUS_UNLOADED
        pnlVideoControls.Visible = False
        toggleVideoMenu(True)
        unsetTimes()
        cmdShowSetTimecode.Enabled = False
        Me.txtTransectDate.Enabled = False
        Me.txtProjectName.Enabled = False
        Me.chkRecordEachSecond.Enabled = False
        Me.mnuConfigureTools.Enabled = False
        Me.mnuRefreshForm.Enabled = False
        Me.KeyboardShortcutsToolStripMenuItem.Enabled = False
        Me.DataCodeAssignmentsToolStripMenuItem.Enabled = False
        If Database.IsOpen Then
            Me.cmdTransectStart.Enabled = False
            Me.cmdOffBottom.Enabled = False
            Me.txtProjectName.Enabled = False
        End If
        m_video_file_open = False
    End Sub

    ''' <summary>
    ''' Tell the video player to play the video
    ''' </summary>
    Private Sub playVideo()
        'frmVideoPlayer.Rate = m_dblVideoRate
        frmVideoPlayer.playVideo()
    End Sub

    ''' <summary>
    ''' Tell the video player to pause the video
    ''' </summary>
    Private Sub pauseVideo()
        'If Me.tmrRecordPerSecond.Enabled Then
        ' Me.tmrRecordPerSecond.Stop()
        ' End If
        frmVideoPlayer.pauseVideo()
    End Sub

    ''' <summary>
    ''' Tell the video player to stop the video
    ''' </summary>
    Private Sub stopVideo()
        'If Me.tmrRecordPerSecond.Enabled Then
        ' Me.tmrRecordPerSecond.Stop()
        ' End If
        frmVideoPlayer.stopVideo()
    End Sub

    ''' <summary>
    ''' If the video player is paused, show the play icon and set some variables
    ''' </summary>
    Public Sub playerPaused() Handles frmVideoPlayer.PauseEvent
        ' This is used to sense when the video player form pauses its video
        cmdPlayPause.BackgroundImage = My.Resources.Play_Icon
        FfwdCount = 0
        RwndCOunt = 0
    End Sub

    ''' <summary>
    ''' If the video player is playing, show the pause icon and set some variables
    ''' </summary>
    Public Sub playerPlaying() Handles frmVideoPlayer.PlayEvent
        ' This is used to sense when the video player form starts playing its video
        cmdPlayPause.BackgroundImage = My.Resources.Pause_Icon
        setTimes()
        FfwdCount = 0
        RwndCOunt = 0
    End Sub

    ''' <summary>
    ''' If the video player is stopped, show the play icon and set some variables
    ''' </summary>
    Public Sub playerStopped() Handles frmVideoPlayer.StopEvent
        ' This is used to sense when the video player form stops its video from inside.
        ' it is added as a handler and an event raised from the frmVideoPlayer class
        cmdPlayPause.BackgroundImage = My.Resources.Play_Icon
        Me.txtTimeSource.Text = frmVideoPlayer.CurrentVideoTimeFormatted
        setTimes()
        FfwdCount = 0
        RwndCOunt = 0
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
    ''' Closes the MS Access database, and resets all controls to the unloaded state.
    ''' </summary>
    Private Sub closeDatabase()
        If Database.IsOpen Then
            Database.Close()
        End If
        Me.lblDatabase.Text = DB_FILE_STATUS_UNLOADED
        mnuOpenDatabase.Enabled = True
        mnuCloseDatabase.Enabled = False
        pnlTransectData.removeAllDynamicControls()
        pnlHabitatData.removeAllDynamicControls()
        pnlSpeciesData.removeAllDynamicControls()
    End Sub

    ''' <summary>
    ''' Opens the MS Access database and fills the DynamicPanels with buttons. Set up visibility on other VideoMiner buttons
    ''' </summary>
    Public Sub openDatabase()
        Database.Name = m_strDatabaseFilePath
        Database.Open()
        If Database.IsOpen Then
            m_db_filename = get_rel_filename(m_strDatabaseFilePath)
            m_db_file_open = True
            pnlTransectData.fillPanel(DB_TRANSECT_BUTTONS_TABLE)
            pnlHabitatData.fillPanel(DB_HABITAT_BUTTONS_TABLE)
            pnlSpeciesData.fillPanel(DB_SPECIES_BUTTONS_TABLE)
            Me.lblDatabase.Text = DB_FILE_STATUS_LOADED & m_db_filename & " is open"
            mnuOpenDatabase.Enabled = False
            mnuCloseDatabase.Enabled = True
            fetch_data()
            database_is_open_toggle_visibility()
        End If
    End Sub

    ''' <summary>
    ''' Fetch the data table from the MS Access database into the DataGridView and sets the next unique ID that the database can recieve.
    ''' </summary>
    ''' <remarks>Order of the rows will be by decending primary key ('ID' field)</remarks>
    Private Sub fetch_data()
        ' Save the scrollbar position before refetch
        Dim saveRow As Integer = 0
        Dim saveColumn As Integer = 0
        If grdVideoMinerDatabase.Rows.Count > 0 Then
            saveRow = grdVideoMinerDatabase.FirstDisplayedCell.RowIndex + 1
            If grdVideoMinerDatabase.ColumnCount > 0 Then
                saveColumn = grdVideoMinerDatabase.FirstDisplayedCell.ColumnIndex
            End If
        End If

        m_data_codes_table = Database.GetDataTable("select * from " & DB_DATA_CODES_TABLE & " order by 1;", DB_DATA_CODES_TABLE)
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

        ' Restore the scrollbar positions. Only retore the vertical one if the check box is checked in the configure menu.
        If Not AlwaysShowNewestRecordToolStripMenuItem.Checked And saveRow <> 0 And saveRow < grdVideoMinerDatabase.Rows.Count Then
            grdVideoMinerDatabase.FirstDisplayedScrollingRowIndex = saveRow
        End If
        If saveColumn <> 0 And saveColumn < grdVideoMinerDatabase.ColumnCount Then
            grdVideoMinerDatabase.FirstDisplayedScrollingColumnIndex = saveColumn
        End If
        ' Set the row headers to be the ID column values, and make sure the header is wide enough
        grdVideoMinerDatabase.RowHeadersWidth = 60
        For i As Integer = 0 To grdVideoMinerDatabase.Rows.Count - 1
            grdVideoMinerDatabase.Rows(i).HeaderCell.Value = grdVideoMinerDatabase.Rows(i).Cells(0).Value.ToString()
        Next
        ' If data was freshly fetched, no grid cells wil be dirty, so we can allow the 'Define All' buttons to be pressed
        pnlTransectData.EnableDefineAllButton()
        pnlHabitatData.EnableDefineAllButton()

        ' Make the colun headers on the DataGridView non-clickable. If they are clickable, the coloring introduced when data is dirty will dissapear on the sort.
        ' TODO: Store the coloring data in a data structure and re-apply the coloring after the sort.
        'For col As Integer = 0 To grdVideoMinerDatabase.ColumnCount - 1
        ' grdVideoMinerDatabase.Columns(col).SortMode = DataGridViewColumnSortMode.NotSortable
        ' Next

    End Sub

    ''' <summary>
    ''' Creates and runs an 'INSERT INTO' query on the database for all of the given items in the dictionary. Each item will be incorporated into a single query for insertion.
    ''' </summary>
    ''' <param name="dictTransect">A Dictionary object of Key/Value pairs where the keys are field names as found in the main 'data' table in the database, and the values are a pair
    ''' of codes, the first one being the data code for the field being recorded to in the 'data' table and the second being the data code itself as chosen by the user.</param>
    Private Sub runInsertQuery(dictTransect As Dictionary(Of String, Tuple(Of String, String, Boolean)))
        Dim names As String = "insert into " & DB_DATA_TABLE & " (ID,"
        Dim values As String = "values(" & m_db_id_num & ","
        Dim strQuery As String

        If m_strVideoFile <> NULL_STRING Then
            names = names & "FileName,"
            values = values & SingleQuote(m_strVideoFile) & ","
        End If

        If m_project_name <> NULL_STRING Then
            names = names & "ProjectName,"
            values = values & SingleQuote(m_project_name) & ","
        End If

        If m_transect_name <> NULL_STRING Then
            names = names & "TransectName,"
            values = values & SingleQuote(m_transect_name) & ","
        End If

        If Not IsNothing(m_transect_date) Then
            names = names & "TransectDate,"
            values = values & SingleQuote(m_transect_date) & ","
        End If

        If Not IsNothing(m_tsUserTime) Then
            names = names & "TextTime,"
            Dim tmp As TimeSpan = m_tsUserTime
            If Not IsNothing(frmVideoPlayer) Then
                tmp = tmp + frmVideoPlayer.CurrentVideoTime
            End If
            values = values & SingleQuote(tmp.ToString("dd\.hh\:mm\:ss\.fff")) & ","
        End If

        If m_GPS_X <> "" Then
            names = names & "X,"
            values = values & SingleQuote(m_GPS_X) & ","
        End If

        If m_GPS_Y <> "" Then
            names = names & "Y,"
            values = values & SingleQuote(m_GPS_Y) & ","
        End If

        If m_GPS_Z <> "" Then
            names = names & "Z,"
            values = values & SingleQuote(m_GPS_Z) & ","
        End If

        'Dim tsTime As TimeSpan = m_tsUserTime + frmVideoPlayer.CurrentVideoTime
        'If tsTime <> Zero Then
        ' Dim dt As DateTime = m_transect_date + tsTime
        ' Dim st As String = pad0(tsTime.Hours) & ":" & pad0(tsTime.Minutes) & ":" & pad0(tsTime.Seconds)
        ' Dim std As String = pad0(tsTime.Hours) & ":" & pad0(tsTime.Minutes) & ":" & pad0(tsTime.Seconds) & "." & pad0(tsTime.Milliseconds)
        ' names = names & "Format(TimeCode, 'hh:mm:ss') as TimeCode,TextTime,TextTimeDecimal,"
        ' values = values & SingleQuote(dt) & "," & SingleQuote(st) & "," & SingleQuote(std) & ","
        ' End If

        For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In dictTransect
            ' Key is the name of the field as found in the 'data' table. For example, ProtocolID.
            names = names & kvp.Key.ToString() & ","
            ' Item1 of the value part is the code for the data field. For example, in the lu_data_codes table, Protocol is code 14.
            ' Item2 is the data code itself as found in each lookup (lu) table in the database. For example, in the lu_protocol table,
            '       this code would be one of 1, 2, 3, or 4.
            values = values & kvp.Value.Item2.ToString() & ","
        Next
        ' Replace the last character in the names and values strings, which are commas, with a right parenthesis.
        names = names.Substring(0, names.Length - 1) & ")"
        values = values.Substring(0, values.Length - 1) & ")"
        strQuery = names & values

        Database.ExecuteNonQuery(strQuery)
    End Sub

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

    ''' <summary>
    ''' For looking up and saving to the database a rare species (one not on the species buttons).
    ''' </summary>
    Private Sub cmdRareSpeciesLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRareSpeciesLookup.Click
        If IsNothing(m_data_table.GetChanges()) Then
            frmRareSpeciesLookup.Show()
        Else
            If MessageBox.Show("You have unsynced changes in your data table. Discard changes and record data anyway?", "Data table dirty", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                fetch_data() ' Cleans up the table first
                frmRareSpeciesLookup.Show()
            End If
        End If
    End Sub

    Private Sub KeyboardShortcutsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeyboardShortcutsToolStripMenuItem.Click
        frmKeyboardCommands = New frmKeyboardCommands
        frmKeyboardCommands.ShowDialog()
    End Sub

    Private Sub ConfigureHabitatButtonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureHabitatButtonToolStripMenuItem.Click
        strConfigureTable = DB_HABITAT_BUTTONS_TABLE
        frmConfigureButtons = New frmConfigureButtons
        frmConfigureButtons.cmdMoveToPanel.Text = "Move To " & PANEL_NAME_TRANSECT
        frmConfigureButtons.ShowDialog()
    End Sub

    Private Sub ConfigureTransectButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureTransectButtonsToolStripMenuItem.Click
        strConfigureTable = DB_TRANSECT_BUTTONS_TABLE
        frmConfigureButtons = New frmConfigureButtons
        frmConfigureButtons.cmdMoveToPanel.Text = "Move To " & PANEL_NAME_HABITAT
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

    Private Sub pnlSpeciesData_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If m_db_file_open Then

            Me.pnlSpeciesData.Controls.Clear()
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
    ''' Writes the ID numbers in the row headers, and sets the width to fit.
    ''' </summary>
    Private Sub grdVideoMinerDatabase_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grdVideoMinerDatabase.ColumnHeaderMouseClick
        'Set the row headers to be the ID column values, and make sure the header is wide enough
        grdVideoMinerDatabase.RowHeadersWidth = 60
        For i As Integer = 0 To grdVideoMinerDatabase.Rows.Count - 1
            grdVideoMinerDatabase.Rows(i).HeaderCell.Value = grdVideoMinerDatabase.Rows(i).Cells(0).Value.ToString()
        Next
    End Sub

    ''' <summary>
    ''' When the user clicks a column header, record the cell color data so that any that are dirty will remain so after the sort takes place.
    ''' </summary>
    Private Sub grdVideoMinerDatabase_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grdVideoMinerDatabase.CellMouseDown
        If e.RowIndex = -1 Then
            ReDim arrColoring(grdVideoMinerDatabase.RowCount - 1)
            For row As Integer = 0 To grdVideoMinerDatabase.RowCount - 1
                arrColoring(row) = New stcRowColoring
                arrColoring(row).id = grdVideoMinerDatabase.Rows(row).Cells(0).Value
                arrColoring(row).rowCol = grdVideoMinerDatabase.Rows(row).DefaultCellStyle.BackColor
                ReDim arrColoring(row).cellForegroundCols(grdVideoMinerDatabase.ColumnCount - 1)
                ReDim arrColoring(row).cellBackgroundCols(grdVideoMinerDatabase.ColumnCount - 1)
                For cell As Integer = 0 To grdVideoMinerDatabase.ColumnCount - 1
                    arrColoring(row).cellForegroundCols(cell) = grdVideoMinerDatabase.Rows(row).Cells(cell).Style.ForeColor
                    arrColoring(row).cellBackgroundCols(cell) = grdVideoMinerDatabase.Rows(row).Cells(cell).Style.BackColor
                Next
            Next
        End If
    End Sub

    Delegate Sub UpdateColoringDelegate()
    Private marshalUpdateColoring As UpdateColoringDelegate = New UpdateColoringDelegate(AddressOf UpdateColoring)

    ''' <summary>
    ''' Marshalled sub used to re-apply the coloring of the dirty data cells in the data grid. This must be marshalled to ensure it happens after the
    ''' DataBinding Event has taken place.
    ''' </summary>
    Private Sub UpdateColoring()
        Dim id As String
        For row As Integer = 0 To grdVideoMinerDatabase.RowCount - 1
            ' Get the ID found in the current row
            id = grdVideoMinerDatabase.Rows(row).Cells(0).Value
            ' Find the id in the coloring array
            For i As Integer = 0 To arrColoring.Length - 1
                If arrColoring(i).id = id Then
                    ' Apply the coloring to this row and move on
                    grdVideoMinerDatabase.Rows(row).DefaultCellStyle.BackColor = arrColoring(i).rowCol
                    For cell As Integer = 0 To grdVideoMinerDatabase.ColumnCount - 1
                        grdVideoMinerDatabase.Rows(row).Cells(cell).Style.ForeColor = arrColoring(i).cellForegroundCols(cell)
                        grdVideoMinerDatabase.Rows(row).Cells(cell).Style.BackColor = arrColoring(i).cellBackgroundCols(cell)
                    Next
                End If
            Next
        Next
        arrColoring = Nothing
    End Sub

    ''' <summary>
    ''' Apply coloring to the data grid after it has been sorted
    ''' </summary>
    Private Sub grdVideoMinerDatabase_Sorted(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles grdVideoMinerDatabase.DataBindingComplete
        ' Prevent initial data binding from failing
        If IsNothing(arrColoring) Then Exit Sub
        If e.ListChangedType <> ListChangedType.Reset Then Exit Sub
        Me.BeginInvoke(marshalUpdateColoring)
    End Sub


    ''' <summary>
    ''' Triggered when any cell value is changed in the grid. Will update a label telling the user that the data is no longer synced with the database,
    ''' and color the row of cells salmon.
    ''' If the user just types the same value that was in the cell to begin with, the row will be unchanged.
    ''' </summary>
    Private Sub grdVideoMinerDatabase_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles grdVideoMinerDatabase.CurrentCellDirtyStateChanged
        rowWasGood = (grdVideoMinerDatabase.Rows(grdVideoMinerDatabase.CurrentRow.Index).DefaultCellStyle.BackColor <> Color.Salmon)
        If grdVideoMinerDatabase.IsCurrentCellDirty Then
            lblDirtyData.ForeColor = Color.Red
            lblDirtyData.Text = "Data unsynced"
            grdVideoMinerDatabase.Rows(grdVideoMinerDatabase.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Salmon
            grdVideoMinerDatabase.Rows(grdVideoMinerDatabase.CurrentRow.Index).DefaultCellStyle.SelectionBackColor = Color.DarkSalmon
            grdVideoMinerDatabase.CurrentCell.Style.ForeColor = Color.AntiqueWhite
            grdVideoMinerDatabase.CurrentCell.Style.BackColor = Color.Firebrick
            pnlTransectData.DisableDefineAllButton()
            pnlHabitatData.DisableDefineAllButton()
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
            grdVideoMinerDatabase.CurrentCell.Style.BackColor = Color.White
            grdVideoMinerDatabase.CurrentCell.Style.ForeColor = Color.Black
        End If
        ' Get ID number and use that as row since the user can see it labelled on the row headers
        Dim row As Integer = grdVideoMinerDatabase.Rows(e.RowIndex).Cells(0).Value.ToString()
        Select Case strFieldName
            Case "ID"
                MessageBox.Show("Error in column 'ID', row " & row & ": Value must be a non-null integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "TransectDate"
                MessageBox.Show("Error in column 'TransectDate', row " & row & ": Value must be a DateTime (mm/dd/yyyy).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "TimeCode"
                MessageBox.Show("Error in column 'TimeCode', row " & row & ": Value must be a DateTime (mm/dd/yyyy).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "TimeSource"
                MessageBox.Show("Error in column 'TimeSource', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "OnBottom"
                MessageBox.Show("Error in column 'OnBottom', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "DominantSubstrate"
                MessageBox.Show("Error in column 'DominantSubstrate', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "DominantPercent"
                MessageBox.Show("Error in column 'DominantPercent', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "SubdominantSubstrate"
                MessageBox.Show("Error in column 'SubdominantSubstrate', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "SubdominantPercent"
                MessageBox.Show("Error in column 'SubdominantPercent', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "SurveyModeID"
                MessageBox.Show("Error in column 'SurveyModeID', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ReliefID"
                MessageBox.Show("Error in column 'ReliefID', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "DisturbanceID"
                MessageBox.Show("Error in column 'DisturbanceID', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ProtocolID"
                MessageBox.Show("Error in column 'ProtocolID', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ImageQualityID"
                MessageBox.Show("Error in column 'ImageQualityID', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "SpeciesCount"
                MessageBox.Show("Error in column 'SpeciesCount', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Side"
                MessageBox.Show("Error in column 'Side', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Range"
                MessageBox.Show("Error in column 'Range', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Length"
                MessageBox.Show("Error in column 'Length', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Height"
                MessageBox.Show("Error in column 'Height', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Width"
                MessageBox.Show("Error in column 'Width', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Abundance"
                MessageBox.Show("Error in column 'Abundance', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "IDConfidence"
                MessageBox.Show("Error in column 'IDConfidence', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "DataCode"
                MessageBox.Show("Error in column 'DataCode', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "X"
                MessageBox.Show("Error in column 'X', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Y"
                MessageBox.Show("Error in column 'Y', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "Z"
                MessageBox.Show("Error in column 'Z', row " & row & ": Value must be an integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ElapsedTime"
                MessageBox.Show("Error in column 'ElapsedTime', row " & row & ": Value must be a DateTime.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ReviewedDate"
                MessageBox.Show("Error in column 'ReviewedDate', row " & row & ": Value must be a DateTime.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "ReviewedTime"
                MessageBox.Show("Error in column 'ReviewedTime', row " & row & ": Value must be a DateTime.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub grdVideoMinerDatabase_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles grdVideoMinerDatabase.UserDeletedRow
        If grdVideoMinerDatabase.Rows.Count = 0 Then
            fetch_data()
        End If
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

    Private Sub cmdUpdateDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateDatabase.Click
        updateDatabaseWithGridValues()
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
                updateDatabaseWithGridValues()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Update the MS Access database table 'data' with values from the DataGridView object.
    ''' </summary>
    Private Sub updateDatabaseWithGridValues()
        Database.Update(m_data_table, DB_DATA_TABLE)
        lblDirtyData.ForeColor = Color.LimeGreen
        lblDirtyData.Text = "Data synced"
        For i As Integer = 0 To grdVideoMinerDatabase.RowCount - 1
            For cell As Integer = 0 To grdVideoMinerDatabase.Rows(i).Cells.Count - 1
                'Reset all cell backcolors and forecolors
                grdVideoMinerDatabase.Rows(i).Cells(cell).Style.ForeColor = Color.Black
                grdVideoMinerDatabase.Rows(i).Cells(cell).Style.BackColor = Color.White
            Next
        Next
        fetch_data() ' triggers code to check for 0 rows situation and disable buttons if so.
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
    ''' Reload the grid from the access database. A confirmation box will be displayed and if the user aggrees then any changes in the grid will
    ''' be discarded and the database will be reloaded from scratch
    ''' </summary>
    Private Sub cmdRevertDatabase_Click(sender As Object, e As EventArgs) Handles cmdRevertDatabase.Click
        If MessageBox.Show("Are you sure you want to discard all unsynced changes in the grid and revert to the database data?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
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
                SaveConfiguration(XPATH_DATABASE_NAME, m_db_filename)
                SaveConfiguration(XPATH_DATABASE_COLUMNS, strColumns.Substring(0, strColumns.Length - 1))
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
                SaveConfiguration(XPATH_DATABASE_NAME, m_db_filename)
                SaveConfiguration(XPATH_DATABASE_COLUMNS, strColumns.Substring(0, strColumns.Length - 1))
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

    'Private Sub species_button_configuration_changed() Handles frmSpeciesEvent.SpeciesButtonConfigurationChangedEvent
    'Range = frmSpeciesEvent.Range
    'Side = frmSpeciesEvent.Side
    'IDConfidence = frmSpeciesEvent.IDConfidence
    'Abundance = frmSpeciesEvent.Abundance
    'Count = frmSpeciesEvent.Count
    'SpeciesHeight = frmSpeciesEvent.SpeciesHeight
    'SpeciesWidth = frmSpeciesEvent.SpeciesWidth
    'Length = frmSpeciesEvent.Length
    'Comments = frmSpeciesEvent.Comments
    'SpeciesCode = frmSpeciesEvent.SpeciesCode
    'End Sub

    Private Sub gps_connected() Handles frmGpsSettings.GPSConnectedEvent
        lblGPSPortValue.Text = "OPEN"
        lblGPSPortValue.ForeColor = Color.LimeGreen
        lblGPSConnectionValue.Text = "CONNECTED"
        lblGPSConnectionValue.ForeColor = Color.Blue

        frmSetTime.UserTime = m_GPSUserTime
        frmSetTime.ChangeSource(Global.VideoMiner.frmSetTime.WhichTimeEnum.GPS)
    End Sub

    ''' <summary>
    ''' Handles the GPS disconnection. Location data are reset and the SetTime form is set up to be Video time instead.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub gps_disconnected() Handles frmGpsSettings.GPSDisconnectedEvent
        ' Clear out the last location data
        m_GPS_X = NULL_STRING
        m_GPS_Y = NULL_STRING
        m_GPS_Z = NULL_STRING
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

        ' Revert to default of video time
        frmSetTime.TimeSource = Global.VideoMiner.frmSetTime.WhichTimeEnum.Video
        frmSetTime.rbVideoTime.Checked = True
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
        'SpeciesVariableButtonHandler(Me, Nothing)
    End Sub

    Private Sub relay_configuration_changed() Handles frmRelayConfiguration.RelayConfigurationChangedEvent
        ConfigurationSet = frmRelayConfiguration.ConfigurationSet
        RelaySetup = frmRelayConfiguration.RelaySetup
        ParallelCom = frmRelayConfiguration.ParallelCom
        ParallelBaud = frmRelayConfiguration.ParallelBaud
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
    ''' Handles an event to grab the latest data from the GPS device.
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

    ''' <summary>
    ''' If user changes the selection, just refresh the data so that the new selection is reflected.
    ''' </summary>
    Private Sub AlwaysShowNewestRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlwaysShowNewestRecordToolStripMenuItem.Click
        fetch_data()
    End Sub

    Private Function MethodInvoker() As [Delegate]
        Throw New NotImplementedException
    End Function

End Class