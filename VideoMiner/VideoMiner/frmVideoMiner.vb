Option Explicit On
Option Strict On
' All times are stored as TimeSpan objects
Imports System.TimeSpan
Imports System.IO
Imports System.IO.Path
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Xml

''' <summary>
''' This is the main form for the program. Once launched, and an Open Database commend is issued,
''' the dynamic panels representing the 3 panels TRANSECT, HABITAT, and SPECIES will be loaded. Each of these
''' in turn load arrays of objects DynamicButton for SPECIES and DynamicTableButton for TRANSECT and HABITAT.
''' The Database module holds a global instance of the database so that it is consolidated for all forms.
''' 
''' </summary>
Public Class VideoMiner

#Region "Constants"
    Private Const XPATH_PREVIOUS_PROJECTS As String = "/PreviousProjects"

    Private Const XPATH_DATABASE_PATH As String = "/DatabasePath"
    Private Const XPATH_SESSION_PATH As String = "/SessionPath"
    Private Const XPATH_VIDEO_PATH As String = "/VideoPath"
    Private Const XPATH_IMAGE_PATH As String = "/ImagePath"

    Private Const XPATH_GPS_COM_PORT As String = "/GPS/ComPort"
    Private Const XPATH_GPS_NMEA_STRING As String = "/GPS/NMEA"
    Private Const XPATH_GPS_BAUD_RATE As String = "/GPS/BaudRate"
    Private Const XPATH_GPS_PARITY As String = "/GPS/Parity"
    Private Const XPATH_GPS_STOP_BITS As String = "/GPS/StopBits"
    Private Const XPATH_GPS_DATA_BITS As String = "/GPS/DataBits"
    Private Const XPATH_GPS_TIMEOUT As String = "/GPS/Timeout"

    Private Const XPATH_BUTTON_HEIGHT As String = "/ButtonFormat/ButtonSize/Height"
    Private Const XPATH_BUTTON_WIDTH As String = "/ButtonFormat/ButtonSize/Width"
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

    Private DEFAULT_QUICK_ENTRY_COUNT As String = "1"

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
    Public Const DIR_SEP As Char = "\"c
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

#Region "Member variables"
    ' These are the dynamic panels to be added to the splitcontainers at runtime
    Friend WithEvents m_pnlTransectData As DynamicTableButtonPanel
    Friend WithEvents m_pnlHabitatData As DynamicTableButtonPanel
    Friend WithEvents m_pnlSpeciesData As DynamicSpeciesButtonPanel
    ' These are the forms which this form creates and they report directly to this form only
    Private WithEvents m_frmAbout As AboutBox1
    Private WithEvents m_frmSpeciesList As frmSpeciesList
    Private WithEvents m_frmSetTime As frmSetTime
    Private WithEvents m_frmImage As frmImage
    Private WithEvents m_frmGpsSettings As frmGpsSettings
    'Private WithEvents m_frmEditSpecies As frmEditSpecies
    Private WithEvents m_frmViewDataTable As frmViewDataTable
    Private WithEvents m_frmConfigureSpecies As frmConfigureSpecies
    Private WithEvents m_frmSpeciesEvent As frmSpeciesEvent
    'Private WithEvents m_frmTableView As frmTableView
    'Private WithEvents m_frmAbundanceTableView As frmAbundanceTableView
    Private WithEvents m_frmRareSpeciesLookup As frmRareSpeciesLookup
    Private WithEvents m_frmRelayConfiguration As frmRelayConfiguration
    Private WithEvents m_frmKeyboardCommands As frmKeyboardCommands
    'Private WithEvents m_frmAddNewTable As frmAddNewTable
    Private WithEvents m_frmConfigureButtons As frmConfigureButtons
    Private WithEvents m_frmVideoPlayer As frmVideoPlayer
    Private WithEvents m_frmProjectNames As frmProjectNames
    Private WithEvents m_frmDataCodes As frmDataCodes
    Private WithEvents m_frmDeviceControl As frmDeviceControl
    Private WithEvents m_frmConfigureButtonFormat As frmConfigureButtonFormat
    'Private WithEvents m_frmAddValue As frmAddValue
    Private WithEvents m_frmEditLookupTable As frmEditLookupTable
    Private WithEvents m_grdDatabase As VideoMinerDataGridView
    Private WithEvents m_frmSelectDataColumns As frmSelectDataColumns

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
    ''' Holds the path of the last known path for pictures.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strImagePath As String
    ''' <summary>
    ''' Holds the path of the last known session's path as entered by the user in the OpenFileDialog.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_strSessionPath As String
    ''' <summary>
    ''' Holds the user time as set by the m_frmSetTime form.
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
    Private m_project_name As String = String.Empty
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
    Private m_blInTransect As Boolean = False
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
    ''' <summary>
    ''' Used to store the state of the video when a data entry button is clicked.
    ''' </summary>
    Private m_was_playing As Boolean

    ' GPS connection settings to initialize m_frmGpsSettings form with
    Private m_com_port As String
    Private m_nmea_string_type As String
    Private m_parity As String
    Private m_baud_rate As Integer
    Private m_stop_bits As Double
    Private m_data_bits As Integer
    Private m_timeout As Integer

    Private m_database_name As String
    Private m_database_columns As String

    Private m_tool_tip As ToolTip

    Public m_image_open As Boolean = False
    Public m_image_prefix As String
    Public m_image_file_names() As String
    Private m_is_on_bottom As Integer
    Private m_curr_code As String

    Public m_comment As String

    Private m_video_seconds As Integer = 0
    Private m_previous_video_seconds As Integer = 0
    Private m_gps_seconds As Integer = 0
    Private m_previous_gps_seconds As Integer = 0
    Private m_first_time As Boolean = False
    Private m_gps_first_time As Boolean = False

    ' The name of the current image including the path - used in open/save session only
    'Private currentImage As String

    Public m_time_source As Integer = 1
    ' Public dataColumns As Collection used in grid resizing
    'Public blupdateColumns As Boolean = True

    Private m_version As String


    Private m_gps_user_time As TimeSpan

    ''' <summary>
    ''' When the Record every second checkbox is checked, this will be set to true.
    ''' After the first timer tick, it will be set to False.
    ''' This is used so that the previous time can be stored and used in subsequent records.
    ''' The reason is that the timer ticks faster that every second and we need to make sure
    ''' the records are added only every second.
    ''' </summary>
    Private m_record_every_second_checked_first_time As Boolean = False
    ''' <summary>
    ''' This will be set to the current user time if m_record_every_second_checked_first_time is true
    ''' and used as a comparison to make sure a second has passed for the record entry when chkRecordEverySecond is checked.
    ''' </summary>
    Private m_previous_time As TimeSpan

    Private m_button_width As Integer
    Private m_button_height As Integer
    Private m_button_font As String

    Private m_previous_projects As Collection
#End Region

#Region "Delegate Function Declarations"
    Private Delegate Sub myDelegate()
#End Region

#Region "Relay Configuration"
    Private m_configuration_set As Boolean
    Private m_relay_setup As String
    Private m_parallel_com As String
    Private m_parallel_baud As Integer
    Private m_port_one_com As String
    Private m_port_two_com As String
    Private m_port_one_baud As Integer
    Private m_port_two_baud As Integer
    Private m_device_one_relay_one As String
    Private m_device_one_relay_two As String
    Private m_device_one_relay_three As String
    Private m_device_one_relay_four As String
    Private m_device_two_relay_one As String
    Private m_device_two_relay_two As String
    Private m_device_two_relay_three As String
    Private m_device_two_relay_four As String
#End Region

#Region "Properties"
#Region "VideoMiner Properties"
    Public ReadOnly Property Version As String
        Get
            Return m_version
        End Get
    End Property

    Public Property VideoFileName() As String
        Get
            If m_strVideoPath = String.Empty And m_strVideoFile = String.Empty Then
                Return "External Video"
            Else
                Return Combine(m_strVideoPath, m_strVideoFile)
            End If
        End Get
        Set(value As String)
            ' Only set for external video
            m_strVideoPath = String.Empty
            m_strVideoFile = String.Empty
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

    Public Property GPS_X() As Double
        Get
            Return CDbl(m_GPS_X)
        End Get
        Set(ByVal value As Double)
            m_GPS_X = CStr(value)
        End Set
    End Property

    Public Property GPS_Y() As Double
        Get
            Return CDbl(m_GPS_Y)
        End Get
        Set(ByVal value As Double)
            m_GPS_Y = CStr(value)
        End Set
    End Property

    Public Property GPS_Z() As Double
        Get
            Return CDbl(m_GPS_Z)
        End Get
        Set(ByVal value As Double)
            m_GPS_Z = CStr(value)
        End Set
    End Property

    Public Property ButtonWidth() As Integer
        Get
            Return m_button_width
        End Get
        Set(ByVal value As Integer)
            m_button_width = value
        End Set
    End Property

    Public Property ButtonHeight() As Integer
        Get
            Return m_button_height
        End Get
        Set(ByVal value As Integer)
            m_button_height = value
        End Set
    End Property

    Public Property ButtonFont() As String
        Get
            Return m_button_font
        End Get
        Set(ByVal value As String)
            m_button_font = value
        End Set
    End Property

#End Region
#Region "Relay Properties"
    Public Property ConfigurationSet() As Boolean
        Get
            Return m_configuration_set
        End Get
        Set(ByVal value As Boolean)
            m_configuration_set = value
        End Set
    End Property

    Public Property RelaySetup() As String
        Get
            Return m_relay_setup
        End Get
        Set(ByVal value As String)
            m_relay_setup = value
        End Set
    End Property

    Public Property ParallelCom() As String
        Get
            Return m_parallel_com
        End Get
        Set(ByVal value As String)
            m_parallel_com = value
        End Set
    End Property

    Public Property ParallelBaud() As Integer
        Get
            Return m_parallel_baud
        End Get
        Set(ByVal value As Integer)
            m_parallel_baud = value
        End Set
    End Property

    Public Property PortOneCom() As String
        Get
            Return m_port_one_com
        End Get
        Set(ByVal value As String)
            m_port_one_com = value
        End Set
    End Property

    Public Property PortTwoCom() As String
        Get
            Return m_port_two_com
        End Get
        Set(ByVal value As String)
            m_port_two_com = value
        End Set
    End Property

    Public Property PortOneBaud() As Integer
        Get
            Return m_port_one_baud
        End Get
        Set(ByVal value As Integer)
            m_port_one_baud = value
        End Set
    End Property

    Public Property PortTwoBaud() As Integer
        Get
            Return m_port_two_baud
        End Get
        Set(ByVal value As Integer)
            m_port_two_baud = value
        End Set
    End Property

    Public Property DeviceOneRelayOne() As String
        Get
            Return m_device_one_relay_one
        End Get
        Set(ByVal value As String)
            m_device_one_relay_one = value
        End Set
    End Property

    Public Property DeviceOneRelayTwo() As String
        Get
            Return m_device_one_relay_two
        End Get
        Set(ByVal value As String)
            m_device_one_relay_two = value
        End Set
    End Property

    Public Property DeviceOneRelayThree() As String
        Get
            Return m_device_one_relay_three
        End Get
        Set(ByVal value As String)
            m_device_one_relay_three = value
        End Set
    End Property

    Public Property DeviceOneRelayFour() As String
        Get
            Return m_device_one_relay_four
        End Get
        Set(ByVal value As String)
            m_device_one_relay_four = value
        End Set
    End Property

    Public Property DeviceTwoRelayOne() As String
        Get
            Return m_device_two_relay_one
        End Get
        Set(ByVal value As String)
            m_device_two_relay_one = value
        End Set
    End Property

    Public Property DeviceTwoRelayTwo() As String
        Get
            Return m_device_two_relay_two
        End Get
        Set(ByVal value As String)
            m_device_two_relay_two = value
        End Set
    End Property

    Public Property DeviceTwoRelayThree() As String
        Get
            Return m_device_two_relay_three
        End Get
        Set(ByVal value As String)
            m_device_two_relay_three = value
        End Set
    End Property

    Public Property DeviceTwoRelayFour() As String
        Get
            Return m_device_two_relay_four
        End Get
        Set(ByVal value As String)
            m_device_two_relay_four = value
        End Set
    End Property

#End Region
#End Region

#Region "Video Miner Controls"

    Public Sub New()
        InitializeComponent()
        m_frmSpeciesList = New frmSpeciesList
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

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
        m_version = aVersionInfo.ToString
        Text = Name & " - " & Version & " - BETA"

        ' Enable Key preview so that video player hotkeys can be instantiated from this forms event handler.
        Me.KeyPreview = True

        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height

        Dim aPoint As System.Drawing.Point
        aPoint.X = intX
        aPoint.Y = CInt(intY / 2)

        m_strWorkingPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        m_strConfigFilePath = Path.Combine(m_strWorkingPath, "Config")
        m_strConfigFile = Path.Combine(m_strConfigFilePath, VIDEOMINER_CONFIG_FILE_NAME)

        If Not loadConfigurationFile() Then
            Dim strWarning As String = "There was an error while loading the configuration file " & m_strConfigFile & ". Closing VideoMiner."
            MessageBox.Show(strWarning, "No configuration file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If

        m_db_file_open = False
        ' Disable all configuration menu items pertaining to the database
        DataCodeAssignmentsToolStripMenuItem.Enabled = False
        DataTableColumnsToolStripMenuItem.Enabled = False
        SpeciesButtonsToolStripMenuItem.Enabled = False
        ConfigureHabitatButtonToolStripMenuItem.Enabled = False
        ConfigureTransectButtonsToolStripMenuItem.Enabled = False
        ShowGridLinesToolStripMenuItem.Enabled = False
        EditLookupTableToolStripMenuItem.Enabled = False

        m_video_file_open = False
        video_file_unload()
        no_files_loaded()
        m_transect_name = UNNAMED_TRANSECT
        m_curr_code = CStr(BAD_ID)
        m_is_on_bottom = 0
        toggle_bottom()

        'lblDirtyData.Visible = False


        Me.SelectNextControl(Me.SplitContainer4.Panel2, False, True, True, True)

        Me.VideoTime = Zero

        ' Enable the Device Control menu based on if the configuration has been set
        ' This makes sure that the devices are not accessed until the configuration has been set
        'If Me.ConfigurationSet = False Then
        '    Me.DeviceControl.Enabled = False
        'Else
        '    Me.DeviceControl.Enabled = True
        'End If
        Dim strDate As String = String.Empty
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

        m_tool_tip = New ToolTip()
        ' Always show is required because the video window gets the focus if it's open.
        m_tool_tip.ShowAlways = True
        m_tool_tip.InitialDelay = 500
        m_tool_tip.AutoPopDelay = 5000
        m_tool_tip.ReshowDelay = 500

        ' Set the GPS values to a default of nothing. Once a GPS device is connected, these will be
        ' continuously updated by the incoming data handler.
        m_GPS_X = String.Empty
        m_GPS_Y = String.Empty
        m_GPS_Z = String.Empty

        ' Create some form instances here. These forms will remain hidden throughout the session, and ShowDialog will be called to show them
        m_frmGpsSettings = New frmGpsSettings(m_com_port, m_nmea_string_type, m_baud_rate, m_parity, m_stop_bits, m_data_bits, m_timeout)
        'm_frmGpsSettings.ShowDialog()
        m_frmSetTime = New frmSetTime(m_tsUserTime)

        ' Add DynamicPanels to the SplitContainerPanels
        m_pnlTransectData = New DynamicTableButtonPanel(PANEL_NAME_TRANSECT, True, Me.ButtonWidth, Me.ButtonHeight,
                                                      Me.ButtonFont, True, True)
        SplitContainer7.Panel1.Controls.Add(m_pnlTransectData)

        m_pnlHabitatData = New DynamicTableButtonPanel(PANEL_NAME_HABITAT, True, Me.ButtonWidth, Me.ButtonHeight,
            Me.ButtonFont, True, True)
        SplitContainer7.Panel2.Controls.Add(m_pnlHabitatData)

        m_pnlSpeciesData = New DynamicSpeciesButtonPanel(PANEL_NAME_SPECIES, Me.ButtonWidth, Me.ButtonHeight, Me.ButtonFont)
        m_pnlSpeciesData.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
        m_pnlSpeciesData.Dock = DockStyle.Fill
        'AddHandler m_pnlSpeciesData.NewSpeciesEntryEvent, AddressOf new_species_entry_handler
        SplitContainer6.Panel2.Controls.Add(m_pnlSpeciesData)

        ' Create this form once, since it loads comboboxes with large amounts of data.
        m_frmRareSpeciesLookup = New frmRareSpeciesLookup
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
                m_button_height = CInt(GetConfiguration(XPATH_BUTTON_HEIGHT))
                m_button_width = CInt(GetConfiguration(XPATH_BUTTON_WIDTH))
                m_button_font = GetConfiguration(XPATH_BUTTON_FONT)
                ' GPS settings
                m_com_port = GetConfiguration(XPATH_GPS_COM_PORT)
                If m_com_port = String.Empty Then
                    m_com_port = GPS_COM_PORT_DEFAULT
                    SaveConfiguration(XPATH_GPS_COM_PORT, m_com_port)
                End If
                m_nmea_string_type = GetConfiguration(XPATH_GPS_NMEA_STRING)
                If m_nmea_string_type = String.Empty Then
                    m_nmea_string_type = GPS_NMEA_DEFAULT
                    SaveConfiguration(XPATH_GPS_NMEA_STRING, m_nmea_string_type)
                End If
                strTmp = GetConfiguration(XPATH_GPS_BAUD_RATE)
                If strTmp = String.Empty Then
                    m_baud_rate = GPS_BAUD_RATE_DEFAULT
                    SaveConfiguration(XPATH_GPS_BAUD_RATE, CStr(m_baud_rate))
                Else
                    m_baud_rate = CInt(strTmp)
                End If
                m_parity = GetConfiguration(XPATH_GPS_PARITY)
                If m_parity = String.Empty Then
                    m_parity = GPS_PARITY_DEFAULT
                    SaveConfiguration(XPATH_GPS_PARITY, m_parity)
                End If
                strTmp = GetConfiguration(XPATH_GPS_STOP_BITS)
                If strTmp = String.Empty Then
                    m_stop_bits = GPS_STOP_BITS_DEFAULT
                    SaveConfiguration(XPATH_GPS_STOP_BITS, CStr(m_stop_bits))
                Else
                    m_stop_bits = CInt(strTmp)
                End If
                strTmp = GetConfiguration(XPATH_GPS_DATA_BITS)
                If strTmp = String.Empty Then
                    m_data_bits = GPS_DATA_BITS_DEFAULT
                    SaveConfiguration(XPATH_GPS_DATA_BITS, CStr(m_data_bits))
                Else
                    m_data_bits = CInt(strTmp)
                End If
                strTmp = GetConfiguration(XPATH_GPS_TIMEOUT)
                If strTmp = String.Empty Then
                    m_timeout = GPS_TIMEOUT_DEFAULT
                    SaveConfiguration(XPATH_GPS_TIMEOUT, CStr(m_timeout))
                Else
                    m_timeout = CInt(strTmp)
                End If
                ' Database settings
                m_database_name = GetConfiguration(XPATH_DATABASE_NAME)
                m_database_columns = GetConfiguration(XPATH_DATABASE_COLUMNS)
                'Relay settings
                m_configuration_set = CBool(GetConfiguration(XPATH_DEVICE_CONFIGURATION_SET))
                m_relay_setup = GetConfiguration(XPATH_DEVICE_SETUP)
                m_parallel_com = GetConfiguration(XPATH_DEVICE_PARALLEL_COM_PORT)
                m_parallel_baud = CInt(GetConfiguration(XPATH_DEVICE_PARALLEL_BAUD_RATE))
                PortOneCom = GetConfiguration(XPATH_DEVICE_TWOPORTS_DEVICE1_COM_PORT)
                m_port_one_baud = CInt(GetConfiguration(XPATH_DEVICE_TWOPORTS_DEVICE1_BAUD_RATE))
                m_port_two_com = GetConfiguration(XPATH_DEVICE_TWOPORTS_DEVICE2_COM_PORT)
                m_port_two_baud = CInt(GetConfiguration(XPATH_DEVICE_TWOPORTS_DEVICE2_BAUD_RATE))
                m_device_one_relay_one = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE1_RELAY1)
                m_device_one_relay_two = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE1_RELAY2)
                m_device_one_relay_three = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE1_RELAY3)
                m_device_one_relay_four = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE1_RELAY4)
                m_device_two_relay_one = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE2_RELAY1)
                m_device_two_relay_two = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE2_RELAY2)
                m_device_two_relay_three = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE2_RELAY3)
                m_device_two_relay_four = GetConfiguration(XPATH_DEVICE_RELAY_DEVICE2_RELAY4)
                ' Paths
                m_strDatabasePath = GetConfiguration(XPATH_DATABASE_PATH)
                m_strVideoPath = GetConfiguration(XPATH_VIDEO_PATH)
                m_strSessionPath = GetConfiguration(XPATH_SESSION_PATH)
                m_strImagePath = GetConfiguration(XPATH_IMAGE_PATH)
                ' If any of the three paths were not present in the XML file, set them to the working directory
                ' which is determined at program startup, not via XML file.
                If m_strDatabasePath = String.Empty Then
                    m_strDatabasePath = m_strWorkingPath
                    SaveConfiguration(XPATH_DATABASE_PATH, m_strDatabasePath)
                End If
                If m_strVideoPath = String.Empty Then
                    m_strVideoPath = m_strWorkingPath
                    SaveConfiguration(XPATH_VIDEO_PATH, m_strVideoPath)
                End If
                If m_strSessionPath = String.Empty Then
                    m_strSessionPath = m_strWorkingPath
                    SaveConfiguration(XPATH_SESSION_PATH, m_strSessionPath)
                End If
                If m_strImagePath = String.Empty Then
                    m_strImagePath = m_strWorkingPath
                    SaveConfiguration(XPATH_IMAGE_PATH, m_strImagePath)
                End If

                ' The list of previous project names
                m_previous_projects = GetConfigurationCollection(XPATH_PREVIOUS_PROJECTS)
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
    Public Function SaveConfiguration(ByVal xPath As String, ByVal strValue As String, Optional forceCreate As Boolean = False) As Boolean
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
        SaveConfiguration("/PreviousProjects/ProjectName", "testSave1", True)
        SaveConfiguration("/PreviousProjects/ProjectName", "testSave2", True)
        SaveConfiguration("/PreviousProjects/ProjectName", "testSave3", True)
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
        If docNode Is Nothing Or xPath Is Nothing Or xPath = String.Empty Or strValue Is Nothing Then
            Exit Sub
        End If
        ' The weird c below signifies that this is a char and not a string. Strange syntax but required with Option Strict On.
        Dim trimChars() As Char = {"/"c}
        xPath = xPath.TrimStart(trimChars)

        Dim newNode, currNode As XmlElement
        Dim names() As String = xPath.Split("/"c)
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
            currNode = CType(docNode.SelectSingleNode(VMCD & "/" & leftPath), XmlElement)
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
    ''' Retrieve the DataColumnVisibility values from the XML configuration file.
    ''' </summary>
    ''' <returns>An array of booleans or Nothing if DataColumnVisibility is not found in the XML file</returns>
    Public Function GetDataColumnVisibilityConfiguration() As Boolean()
        Dim retArray As Boolean()
        Dim strPath As String = VMCD & "/DataColumnVisibility"
        If File.Exists(m_strConfigFile) Then
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(m_strConfigFile)

            Dim nodeList As XmlNodeList = xmlDoc.SelectNodes(strPath)
            If nodeList Is Nothing Then
                Return Nothing
            End If

            Dim parentNode As XmlNode
            Dim strString As String = NULL_STRING
            For Each parentNode In nodeList
                ReDim retArray(parentNode.ChildNodes.Count - 1)
                If parentNode.HasChildNodes Then
                    For i As Integer = 0 To parentNode.ChildNodes.Count - 1
                        retArray(i) = Convert.ToBoolean(parentNode.ChildNodes(i).InnerXml)
                    Next
                End If
            Next
            Return retArray
        Else
            Return Nothing
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
            m_previous_projects = New Collection
            For Each parentNode In nodeList
                If parentNode.HasChildNodes Then
                    For Each childNode In parentNode.ChildNodes
                        If childNode.ChildNodes.Count > 0 Then
                            m_previous_projects.Add(childNode.InnerXml, childNode.InnerXml)
                        Else
                            m_previous_projects.Add(childNode.Value, childNode.Value)
                        End If
                        'Debug.WriteLine("strString: " & strString)
                    Next
                End If
            Next
            Return m_previous_projects
        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' Handles the keyboard shortcuts from the main Videominer window.
    ''' </summary>
    ''' <param name="e">The key that was pressed</param>
    Public Sub VideoMiner_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If Not Database.IsOpen Then Exit Sub
        ' If delete or shift were pressed, it could be to select or delete something from the data grid.
        If e.KeyValue = Keys.Delete Or e.KeyValue = Keys.ShiftKey Then Exit Sub
        ' If control key was pressed, it could be to clear a habitat type.
        ' If e.KeyValue = Keys.ControlKey Then Exit Sub
        ' If arrow keys were pressed, it could be to navigate the data grid.
        If e.KeyValue = Keys.Left Or
            e.KeyValue = Keys.Right Or
            e.KeyValue = Keys.Up Or
            e.KeyValue = Keys.Down Then
            Exit Sub
        End If
        ' Ignore Alt and Escape since they are used for other things in windows.
        If e.KeyValue = Keys.Menu Or e.KeyValue = Keys.Escape Then Exit Sub

        Dim kc As New KeysConverter
        Dim strKeyboardShortcut As String = kc.ConvertToString(e.KeyData)

        ' Fetch the record corresponding to the shortcut
        Dim d As DataTable = Database.GetDataTable("select DrawingOrder, ButtonText, ButtonCode, ButtonCodeName, DataCode, ButtonColor, KeyboardShortcut from " &
                                                   DB_SPECIES_BUTTONS_TABLE & " WHERE KeyboardShortcut = " & DoubleQuote(strKeyboardShortcut) &
                                                   " ORDER BY DrawingOrder;", DB_SPECIES_BUTTONS_TABLE)
        If d.Rows.Count > 0 Then
            ' The idea here is to cause a click of the button that corresponds to the shortcut, because the
            ' code to build the query is complex and already implemented in buttonDataChanged()
            'If Not grdVideoMinerDatabase.Focused Then
            m_pnlSpeciesData.ClickButton(CType(d.Rows(0).Item(1), String))
            'End If
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim k As Keys = CType(msg.WParam.ToInt32, Keys)
        Select Case k
            Case Keys.Enter
                'indicates you've handled the message sent by the enter key press here; basically, you're eating up these messages
                Return True
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
    End Function

    'Private Sub frmVideoMiner_Keypress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
    ' If grdVideoMinerDatabase.Focused Then
    '         e.Handled = True
    'End If
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
        m_frmAbout = New AboutBox1
        m_frmAbout.ShowDialog()
    End Sub

    ''' <summary>
    ''' When the user clicks "Open Database" in the file menu, open a dialog box where a database can be selected
    ''' and opened for use in the program.
    ''' Load OpenFileDialog object to prompt user to select a database to open.
    ''' When the user clicks OK, sub openDatabase and send it the path of the database to open.
    ''' </summary>
    Private Sub mnuOpenDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenDatabase.Click
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
        m_db_file_open = False
        m_grdDatabase.Hide()
        closeDatabase()
        no_files_loaded()
        'Me.cmdDefineAllTransectVariables.Visible = False
        Me.cmdAddComment.Visible = False
        cmdShowSetTimecode.Enabled = False
        cmdTransectStart.Enabled = False
        cmdOffBottom.Enabled = False
        'ResumeVideo.Enabled = True
        'Me.lblQuickSpeciesCount.Visible = False
        'Me.txtQuickSpeciesCount.Visible = False
        Me.txtPlaySeconds.Enabled = False
        Me.txtTransectDate.Enabled = False
        Me.txtProjectName.Enabled = False
        Me.chkRecordEachSecond.Enabled = False
        'mnuConfigureTools.Enabled = False
        DataCodeAssignmentsToolStripMenuItem.Enabled = False
        dictHabitatFieldValues = Nothing
        dictTempHabitatFieldValues = Nothing
        dictTransectFieldValues = Nothing
    End Sub

    ''' <summary>
    ''' When a user selects "Open a DV Device" from the file menu, the openDV() function to
    ''' see a dialogue where the user can open a DV file.
    ''' </summary>
    Private Sub mnuOpenDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openDV()
    End Sub

    Private Sub GPSSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGPSSettings.Click
        'If m_frmGpsSettings Is Nothing Then
        '    m_frmGpsSettings = New frmGpsSettings(m_com_port, m_nmea_string_type, m_baud_rate, m_parity, m_stop_bits, m_data_bits, m_timeout)
        'End If
        m_frmGpsSettings.ShowDialog()
    End Sub

    Private Sub mnuUseExternalVideo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUseExternalVideo.Click
        If Not m_frmVideoPlayer Is Nothing Then
            m_frmVideoPlayer.Close()
        End If
        If mnuUseExternalVideo.Checked Then
            VideoFileName = "External Video"
            m_frmSetTime.Show()
            m_frmSetTime.BringToFront()
            mnuOpenImg.Enabled = False
            mnuOpenFile.Enabled = False
        Else
            ' Return everything to no-loaded status
            VideoFileName = NULL_STRING
            mnuOpenImg.Enabled = True
            mnuOpenFile.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Ask user to input time that is shown on the video. This synchronizes the program with the video, and sets the label to the correct time.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdShowSetTimecode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowSetTimecode.Click
        If m_frmVideoPlayer Is Nothing Then
            MessageBox.Show("Please open a video file before setting the time.",
                            "Video File Not Open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        dataEntryStarted()
        m_frmSetTime.Show()
    End Sub

    ''' <summary>
    ''' This handler is called when the user clicks on the "Transect Start" button.
    ''' Pauses video, prompts user for a transect name, inserts new record in the DataGridView1
    ''' database table, and plays the video again.
    ''' Also inserts a record for On or Off bottom. If the transect is starting, On bottom will be recorded
    ''' If the transect is ending, Off bottom will be recorded.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TransectStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransectStart.Click
        Dim start_or_end As String
        ' Need to merge dictionaries for Habitat and Transect panels here to the Off Bottom/ On Bottom KeyValuePair
        Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = New Dictionary(Of String, Tuple(Of String, String, Boolean))
        Dim tuple As Tuple(Of String, String, Boolean)
        dict = dict.Union(m_pnlHabitatData.Dictionary).Union(m_pnlTransectData.Dictionary).ToDictionary(Function(x) x.Key, Function(y) y.Value)
        If Not m_blInTransect Then
            ' Currently not in a transect, so we start it here
            dataEntryStarted()
            m_transect_name = InputBox("Enter a name for this transect if you wish.", "Transect Name?")
            If m_transect_name = String.Empty Then
                m_transect_name = UNNAMED_TRANSECT
                txtTransectTextbox.Text = UNNAMED_TRANSECT
            Else
                txtTransectTextbox.Text = "Transect '" & m_transect_name & "'"
            End If
            dataEntryEnded()
            txtTransectTextbox.Text = "Transect '" & m_transect_name & "'"
            txtTransectTextbox.Font = New Font(String.Empty, STATUS_FONT_SIZE, FontStyle.Bold)
            txtTransectTextbox.BackColor = Color.LightGray
            txtTransectTextbox.ForeColor = Color.LimeGreen
            txtTransectTextbox.TextAlign = HorizontalAlignment.Center
            cmdTransectStart.Text = "Transect End"
            start_or_end = TRANSECT_START
            m_blInTransect = True
            tuple = New Tuple(Of String, String, Boolean)("1", "1", False)
            dict.Add(DATA_CODE, tuple)
            runInsertQuery(dict)
            m_grdDatabase.fetchData()
            m_grdDatabase.fetchData()
        Else
            ' Currently in a transect, so we end it here
            txtTransectTextbox.Text = NO_TRANSECT
            txtTransectTextbox.Font = New Font(String.Empty, STATUS_FONT_SIZE, FontStyle.Bold)
            txtTransectTextbox.BackColor = Color.LightGray
            txtTransectTextbox.ForeColor = Color.Red
            txtTransectTextbox.TextAlign = HorizontalAlignment.Center
            cmdTransectStart.Text = "Transect Start"
            start_or_end = TRANSECT_END
            m_blInTransect = False
            tuple = New Tuple(Of String, String, Boolean)("2", "2", False)
            dict.Add(DATA_CODE, tuple)
            m_transect_name = String.Empty
            runInsertQuery(dict)
            m_grdDatabase.fetchData()
        End If

        If dict.ContainsKey(DATA_CODE) Then
            dict.Remove(DATA_CODE)
        End If

        ' Need to remove the keys from the dictionary because the union operation is by reference and they will appear in
        ' pnlHabitat.Dictionary as well. Removing them from dict removes them from pnlHabitat.Dictionary as well.
        If dict.ContainsKey(DATA_CODE) Then
            dict.Remove(DATA_CODE)
        End If
        If dict.ContainsKey("OnBottom") Then
            dict.Remove("OnBottom")
        End If
    End Sub

    ''' <summary>
    ''' This event is called when the user clicks on the "Off Bottom" button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OffBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOffBottom.Click
        Dim tc As TimeSpan
        Dim strX As String = NULL_STRING
        Dim strY As String = NULL_STRING
        Dim strZ As String = NULL_STRING
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
            tc = m_tsUserTime
            strVideoTime = m_frmVideoPlayer.CurrentVideoTimeFormatted
        End If
        strVideoTextTime = strVideoTime
        toggle_bottom()
    End Sub

    ''' <summary>
    ''' Build a dictionary and run an insert query for a screenshot event. The Habitat and Transect panels' data will be merged into the dictionary prior to insertion.
    ''' </summary>
    ''' <param name="filename">The name of the file the screenshot was captured to</param>
    Private Sub runInsertQueryScreenshot(filename As String)
        Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = New Dictionary(Of String, Tuple(Of String, String, Boolean))
        Dim tuple As Tuple(Of String, String, Boolean)
        ' Merge the two dictionaries from HABITAT and TRANSECT panels
        For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In m_pnlTransectData.Dictionary
            dict.Add(kvp.Key, kvp.Value)
        Next
        For Each kvp As KeyValuePair(Of String, Tuple(Of String, String, Boolean)) In m_pnlHabitatData.Dictionary
            dict.Add(kvp.Key, kvp.Value)
        Next
        If dict.ContainsKey(DATA_CODE) Then
            dict.Remove(DATA_CODE)
        End If
        ' Add the datacode information for a screenshot event
        tuple = New Tuple(Of String, String, Boolean)("555", "555", True)
        dict.Add(DATA_CODE, tuple)
        ' Add the comment information for a screenshot event
        tuple = New Tuple(Of String, String, Boolean)(DoubleQuote("Screen Capture"), DoubleQuote("Screen Capture"), False)
        dict.Add("Comment", tuple)
        ' Add the filename information for a screenshot event
        tuple = New Tuple(Of String, String, Boolean)(DoubleQuote(filename), DoubleQuote(filename), False)
        dict.Add("ScreenCaptureName", tuple)
        If Database.IsOpen Then
            runInsertQuery(dict)
            m_grdDatabase.fetchData()
        End If
    End Sub

    Private Sub dataButtonNewEntry() Handles m_pnlSpeciesData.StartDataEntryEvent,
                                             m_pnlTransectData.StartDataEntryEvent,
                                             m_pnlHabitatData.StartDataEntryEvent
        dataEntryStarted()
    End Sub

    Private Sub dataButtonEntryFinished() Handles m_pnlSpeciesData.EndDataEntryEvent,
                                                  m_pnlTransectData.EndDataEntryEvent,
                                                  m_pnlHabitatData.EndDataEntryEvent,
                                                  m_frmRareSpeciesLookup.EndDataEntryEvent,
                                                  m_frmConfigureButtons.EndDataEntryEvent
        dataEntryEnded()
    End Sub
    ''' <summary>
    ''' Handle the entry of data by creating an insert query and
    ''' saving to the database.
    ''' </summary>
    Private Sub dataChanged(sender As System.Object, e As System.EventArgs) Handles m_pnlHabitatData.EndDataEntryEvent,
                                                                                    m_pnlTransectData.EndDataEntryEvent,
                                                                                    m_pnlSpeciesData.EndDataEntryEvent,
                                                                                    m_frmRareSpeciesLookup.EndDataEntryEvent

        If TypeOf sender Is DynamicSpeciesButtonPanel Then
            Dim pnl As DynamicSpeciesButtonPanel = CType(sender, DynamicSpeciesButtonPanel)
            Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = pnl.Dictionary
            ' If species panel, merge other two panel's dictionaries
            dict = dict.Union(m_pnlHabitatData.Dictionary).Union(m_pnlTransectData.Dictionary).ToDictionary(Function(x) x.Key, Function(y) y.Value)
            runInsertQuery(dict)
        ElseIf TypeOf sender Is DynamicTableButtonPanel Then
            Dim pnl As DynamicTableButtonPanel = CType(sender, DynamicTableButtonPanel)
            Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = pnl.Dictionary
            Select Case pnl.Name
                Case PANEL_NAME_HABITAT
                    ' merge the transect panel dictionary
                    Try
                        dict = dict.Union(m_pnlTransectData.Dictionary).ToDictionary(Function(x) x.Key, Function(y) y.Value)
                    Catch ex As Exception
                        MessageBox.Show("Error - the button you pressed has a duplicate on the " & PANEL_NAME_TRANSECT & " panel, and was already set. Delete duplicate buttons.",
                                        "Error - duplicate buttons",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                Case PANEL_NAME_TRANSECT
                    ' merge the habitat panel dictionary
                    Try
                        dict = dict.Union(m_pnlHabitatData.Dictionary).ToDictionary(Function(x) x.Key, Function(y) y.Value)
                    Catch ex As Exception
                        MessageBox.Show("Error - the button you pressed has a duplicate on the " & PANEL_NAME_HABITAT & " panel, and was already set. Delete duplicate buttons.",
                                        "Error - duplicate buttons",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error)
                        Exit Sub
                    End Try
            End Select
            runInsertQuery(dict)
        ElseIf TypeOf sender Is frmRareSpeciesLookup Then
            Dim frm As frmRareSpeciesLookup = CType(sender, frmRareSpeciesLookup)
            Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = frm.Dictionary
            dict = dict.Union(m_pnlHabitatData.Dictionary).Union(m_pnlTransectData.Dictionary).ToDictionary(Function(x) x.Key, Function(y) y.Value)
            runInsertQuery(dict)
        End If
        m_grdDatabase.fetchData()

    End Sub

    ''' <summary>
    ''' Brings up the edit species dialog (m_frmSpeciesList) which allows the user to change the order of the species buttons
    ''' and to delete them, edit them, or add new ones.
    ''' </summary>
    Private Sub cmdEdit_Click() Handles m_pnlSpeciesData.EditSpeciesButtonPressed
        SpeciesButtonsToolStripMenuItem_Click(Me, EventArgs.Empty)
        'dataEntryStarted()
        'm_frmSpeciesList.Show()
    End Sub

    ''' <summary>
    ''' When the user has changed the species buttons from the m_frmSpeciesEvent form, this function will remove and re-add the DynamicPanel
    ''' which contains the species buttons.
    ''' </summary>
    Private Sub speciesButtonsChanged() Handles m_frmSpeciesList.SpeciesButtonsChangedEvent
        m_pnlSpeciesData.fillPanel(DB_SPECIES_BUTTONS_TABLE)
    End Sub

    Public Sub mnuCapScr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        capture_screen_image()
    End Sub

    Private Sub cmdScreenCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScreenCapture.Click
        capture_screen_image()
    End Sub

    ''' <summary>
    ''' Capture a screenshot of the video at it's current position, and write a transection to the database.
    ''' </summary>
    Public Sub capture_screen_image() Handles m_frmVideoPlayer.CaptureScreenEvent
        If Not m_video_file_open Then
            MessageBox.Show("Cannot capture screen unless video is open.", "No Video Open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        ' Convert slashes in date to underscores, and colons in time to underscores
        Dim strDate As String = m_transect_date.ToString("d").Replace("/", "_")
        Dim strTime As String = (m_tsUserTime + m_frmVideoPlayer.CurrentVideoTime).ToString().Replace(":", "_")
        Dim strTodaysDate As String = Date.Today.ToString("d").Replace("/", "_")
        Dim strTodaysTime As String = TimeOfDay.ToString("h:mm:ss").Replace(":", "_")
        Dim strDefaultFilename As String
        If mnuNameOption_1.Checked Then
            strDefaultFilename = "Capture_" & Me.txtProjectName.Text & "_" & strDate & "_" & strTime
        ElseIf mnuNameOption_2.Checked Then
            strDefaultFilename = "Capture_" & Me.txtProjectName.Text & "_" & strTodaysDate & "_" & strTodaysTime
        ElseIf mnuNameOption_3.Checked Then
            strDefaultFilename = "Capture_" & strDate & "_" & strTime
        ElseIf mnuNameOption_4.Checked Then
            strDefaultFilename = "Capture_" & strTodaysDate & "_" & strTodaysTime
        ElseIf mnuNameOption_5.Checked Then
            strDefaultFilename = Me.txtProjectName.Text & "_" & strDate & "_" & strTime
        ElseIf mnuNameOption_6.Checked Then
            strDefaultFilename = Me.txtProjectName.Text & "_" & strTodaysDate & "_" & strTodaysTime
        ElseIf mnuNameOption_7.Checked Then
            strDefaultFilename = strDate & "_" & strTime
        ElseIf mnuNameOption_8.Checked Then
            strDefaultFilename = strTodaysDate & "_" & strTodaysTime
        Else
            strDefaultFilename = String.Empty
        End If
        Dim strFileName As String = m_frmVideoPlayer.captureScreen(strDate, strTime, strDefaultFilename)
        If strFileName <> String.Empty Then
            ' Add a record to the database and save the file.
            runInsertQueryScreenshot(strFileName)
        End If
    End Sub

    ''' <summary>
    ''' Add a new project name to the XML file when the user changes it inside frmProjectNames
    ''' </summary>
    Private Sub newProjectName() Handles m_frmProjectNames.NewProjectNameEvent
        ' Add the new item to the current collection of items and also write it into the XML file
        Dim name As String = m_frmProjectNames.getProjectName()
        m_previous_projects.Add(name, name) ' Key and value are identical, needed for removing from the collection which needs the key
        SaveConfiguration("/PreviousProjects/ProjectName", m_frmProjectNames.getProjectName(), True)
    End Sub

    ''' <summary>
    ''' Change the project name to what was chosen in the frmProjectName form.
    ''' </summary>
    Private Sub project_name_changed() Handles m_frmProjectNames.ProjectNameChangedEvent
        txtProjectName.Text = m_frmProjectNames.getProjectName()
    End Sub

    ''' <summary>
    ''' Delete the project name currently selected in the frmProjectName form.
    ''' </summary>
    Private Sub project_name_delete() Handles m_frmProjectNames.DeleteProjectNameEvent
        ' Delete the name from the XML file and current collection
        Dim key As String = m_frmProjectNames.getProjectNameToDelete()
        m_previous_projects.Remove(key)
        If Not DeleteXMLNode("/PreviousProjects/ProjectName", m_frmProjectNames.getProjectNameToDelete()) Then
            MessageBox.Show("Error - failed to delete the node from the XML file. Check the file and retry.", "Failed to edit XML file", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtProjectName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectName.Click
        If m_frmProjectNames Is Nothing Then
            m_frmProjectNames = New frmProjectNames
        End If
        m_frmProjectNames.PopulateProjectList(m_previous_projects)
        m_frmProjectNames.ShowDialog()
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
        Me.txtTransectDate.Text = AddZeros(CType(mnthCalendar.SelectionStart.Day, String), 2) & "/" & AddZeros(CType(mnthCalendar.SelectionStart.Month, String), 2) & "/" & Me.mnthCalendar.SelectionStart.Year
        m_transect_date = CDate(txtTransectDate.Text)
        Me.mnthCalendar.Visible = False
        Me.cmdCloseCalendar.Visible = False
    End Sub

    Private Sub cmdCloseCalendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseCalendar.Click
        Me.mnthCalendar.Visible = False
        Me.cmdCloseCalendar.Visible = False
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

    Private Sub cmdAddComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddComment.Click
        Dim tc As TimeSpan = New TimeSpan(CLng(VIDEO_TIME_LABEL))
        Dim strX As String = NULL_STRING
        Dim strY As String = NULL_STRING
        Dim strZ As String = NULL_STRING
        Dim query As String
        Dim blAquiredFix As Boolean = False
        m_comment = InputBox("Enter a comment to be inserted as a record", "Enter Comment")
        If m_comment = String.Empty Then
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
            tc = m_tsUserTime
            strVideoTime = m_frmVideoPlayer.CurrentVideoTimeFormatted

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
        Dim strCode As String = String.Empty
        Dim strName As String = String.Empty

        ' If the image is open and the video is closed then get the picture information from the EXIF file
        If m_image_open And m_video_file_open = False Then

            'getEXIFData()
            strVideoTextTime = strVideoTime

        End If
        ' ======================================Code by Xida Chen (end)===========================================
        Dim j As Integer

        Try

            If True Then
                '    If Me.chkRepeatVariables.Checked = False Then
                '                For j = 0 To intNumHabitatButtons - 1
                '               dictHabitatFieldValues(strHabitatButtonCodeNames(j).ToString) = "-9999"
                '              Next
            End If

            If tc.ToString() <> String.Empty Then
                ' Insert new record in database
                Dim numrows As Integer

                'query = createInsertQuery(COMMENT_ADDED, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING)
                'Database.ExecuteNonQuery(query)
                m_grdDatabase.fetchData()
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

            Dim strX As String = NULL_STRING
            Dim strY As String = NULL_STRING
            Dim strZ As String = NULL_STRING
            Dim query As String = String.Empty
            Dim blAquiredFix As Boolean = False

            m_comment = "Nothing in photo"

            'If they are using the video control then get the time from there.
            ' The time code is set to be VIDEO_TIME_LABEL initially.
            Dim strPhotoTime As String = VIDEO_TIME_LABEL
            Dim strPhotoTextTime As String = VIDEO_TIME_LABEL
            Dim strPhotoDecimalTime As String = VIDEO_TIME_DECIMAL_LABEL

            ' ======================================Code by Xida Chen (end)===========================================
            Dim j As Integer

            Try


                ' For j = 0 To intNumHabitatButtons - 1
                'dictHabitatFieldValues(strHabitatButtonCodeNames(j).ToString) = "-9999"
                'Next
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
                Dim strCode As String = String.Empty
                Dim strName As String = String.Empty

                If m_image_open And m_video_file_open = False Then

                    'getEXIFData()
                    strPhotoTextTime = strPhotoTime

                End If

                If tc <> String.Empty Then

                    ' Insert new record in database
                    Dim numrows As Integer

                    'query = createInsertQuery(NOTHING_IN_PHOTO, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING, NULL_STRING)
                    'Database.ExecuteNonQuery(query)
                    m_grdDatabase.fetchData()
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

    Private Sub ConfigureSpeciesEventToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not m_frmSpeciesEvent Is Nothing Then
            m_frmSpeciesEvent.Dispose()
            m_frmSpeciesEvent = Nothing
        End If

        m_frmConfigureSpecies = New frmConfigureSpecies
        m_frmConfigureSpecies.ShowDialog()

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

            If strFileName = String.Empty Or Not System.IO.File.Exists(strFileName) Then
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

            'TODO: fix getconfiguration to take a config filename for this
            blVideoOpen = CBool(GetConfiguration("SessionConfiguration/Video/Open"))
            strVideoFileName = GetConfiguration("SessionConfiguration/Video/FileName")
            strVideoTime = GetConfiguration("SessionConfiguration/Video/Position")

            blImageOpen = CBool(GetConfiguration("SessionConfiguration/Image/Open"))
            strImageFileName = GetConfiguration("SessionConfiguration/Image/FileName")

            blDatabaseOpen = CBool(GetConfiguration("SessionConfiguration/Database/Open"))
            strDatabaseFileName = GetConfiguration("SessionConfiguration/Database/FileName")
            strNumberRecordsShown = GetConfiguration("SessionConfiguration/Database/NumberRecordsShown")

            If blImageOpen = True Then
                If Not m_frmImage Is Nothing Then
                    m_frmImage.Close()
                End If
                If m_frmImage Is Nothing Then
                    'm_frmImage = New frmImage(m_strImagePath, m_strimagefile)
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
                        aPoint.Y = CInt(intY / 2)
                        m_frmImage.Location = aPoint
                        m_frmImage.WindowState = FormWindowState.Normal
                    Else
                        aPoint.X = intX + priMon.Bounds.Width
                        aPoint.Y = CInt(intY / 2)
                        m_frmImage.Location = aPoint
                        m_frmImage.WindowState = FormWindowState.Maximized
                    End If

                    m_frmImage.Show()
                End If
                VideoFileName = strImageFileName.Substring(strImageFileName.LastIndexOf("\") + 1, (strImageFileName.Length - strImageFileName.LastIndexOf("\") - 1))
                m_image_open = True
                ' Store the path of the current folder so that we can read 
                ' all the images under the current directory
                Dim m_strImagePath As String = strImageFileName.Substring(0, strImageFileName.LastIndexOf("\") + 1)
                Dim allFiles As String() = Directory.GetFiles(m_strImagePath)
                Dim cur_folder_files As String = String.Empty
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
                m_image_file_names = Split(cur_folder_files, "|")
                m_image_prefix = strImageFileName.Substring(0, strImageFileName.LastIndexOf("."))
                Me.cmdNothingInPhoto.Visible = True
                mnuOpenImg.Enabled = True
            End If
            If blVideoOpen Then
                If Not m_frmVideoPlayer Is Nothing Then
                    m_frmVideoPlayer.Close()
                End If
                'current_directory = strVideoFileName.Substring(0, strVideoFileName.LastIndexOf("\"))
                strVideoFilePath = strVideoFileName
                VideoFileName = strVideoFilePath.Substring(strVideoFilePath.LastIndexOf("\") + 1, strVideoFilePath.Length - strVideoFilePath.LastIndexOf("\") - 1)
                If m_frmVideoPlayer Is Nothing Then
                    m_frmVideoPlayer = New frmVideoPlayer(VideoFileName, VIDEO_TIME_FORMAT)
                    'm_frmVideoPlayer.pnlHideVideo.Visible = True
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
                        aPoint.Y = CInt(intY / 2)
                        m_frmVideoPlayer.Location = aPoint
                        m_frmVideoPlayer.WindowState = FormWindowState.Normal
                        'm_frmVideoPlayer.TopMost = True
                    Else
                        aPoint.X = intX + priMon.Bounds.Width
                        aPoint.Y = CInt(intY / 2)
                        m_frmVideoPlayer.Location = aPoint
                        m_frmVideoPlayer.WindowState = FormWindowState.Maximized
                        'm_frmVideoPlayer.TopMost = True
                    End If
                    Me.VideoTime = Parse(strVideoTime)
                    m_frmVideoPlayer.Show()

                Else
                    'm_frmVideoPlayer.pnlHideVideo.Visible = True
                    m_frmVideoPlayer.frmVideoPlayer_Load(Me, New System.EventArgs)
                End If
            End If
            'Me.Text = "Video Miner  " & Me.Version & " - " & Me.SessionName.Substring(Me.SessionName.LastIndexOf("\") + 1, (Me.SessionName.Length - 4) - Me.SessionName.LastIndexOf("\") - 1)
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
            'strFileName = Me.SessionName

            Dim blVideoOpen As Boolean
            Dim blImageOpen As Boolean
            Dim blDatabaseOpen As Boolean
            Dim strVideoFileName As String
            Dim strImageFileName As String
            Dim strDatabaseFileName As String
            Dim strVideoTime As String
            Dim strNumberRecordsShown As String

            If Not m_frmVideoPlayer Is Nothing Then
                blVideoOpen = True
                strVideoFileName = strVideoFilePath
                'strVideoTime = CStr(m_frmVideoPlayer.Ctlcontrols.currentPosition)
                strVideoTime = CStr(m_frmVideoPlayer.Position)
            Else
                blVideoOpen = False
                strVideoFileName = NULL_STRING
                strVideoTime = NULL_STRING
            End If

            If Not m_frmImage Is Nothing Then
                blImageOpen = True
                'strImageFileName = currentImage
            Else
                blImageOpen = False
                strImageFileName = NULL_STRING
            End If

            'If Not Me.grdVideoMinerDatabase.DataSource Is Nothing Then
            '    blDatabaseOpen = True
            '    strDatabaseFileName = m_strDatabaseFilePath
            'Else
            '    blDatabaseOpen = False
            '    strDatabaseFileName = NULL_STRING
            '    strNumberRecordsShown = NULL_STRING
            'End If
            SaveConfiguration("SessionConfiguration/Video/Open", CType(blVideoOpen, String))
            SaveConfiguration("SessionConfiguration/Video/FileName", strVideoFileName)
            SaveConfiguration("SessionConfiguration/Video/Position", strVideoTime)

            SaveConfiguration("SessionConfiguration/Image/Open", CType(blImageOpen, String))
            SaveConfiguration("SessionConfiguration/Image/FileName", strImageFileName)

            SaveConfiguration("SessionConfiguration/Database/Open", CType(blDatabaseOpen, String))
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

        Dim strFileName As String = String.Empty
        strFileName = sfd.FileName
        'Me.SessionName = strFileName

        If strFileName = String.Empty Then
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

        If Not m_frmVideoPlayer Is Nothing Then
            blVideoOpen = True
            strVideoFileName = strVideoFilePath
            strVideoTime = CStr(m_frmVideoPlayer.Position)
        Else
            blVideoOpen = False
            strVideoFileName = NULL_STRING
            strVideoTime = NULL_STRING
        End If

        If Not m_frmImage Is Nothing Then
            blImageOpen = True
            'strImageFileName = currentImage
        Else
            blImageOpen = False
            strImageFileName = NULL_STRING
        End If

        'If Not Me.grdVideoMinerDatabase.DataSource Is Nothing Then
        '    blDatabaseOpen = True
        '    strDatabaseFileName = m_strDatabaseFilePath
        'Else
        '    blDatabaseOpen = False
        '    strDatabaseFileName = NULL_STRING
        '    strNumberRecordsShown = "15"
        'End If

        Dim path As String

        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
        If (path.StartsWith("file:\")) Then
            path = path.Substring(6)    ' Remove unnecessary substring
        End If

        Dim ex As Exception

        ex = createXMLSessionFile(strFileName, blVideoOpen, strVideoFileName, strVideoTime, blImageOpen, strImageFileName, blDatabaseOpen, strDatabaseFileName, strNumberRecordsShown)
        If ex Is Nothing Then
            'Me.Text = "Video Miner  " & Me.Version & " - " & Me.SessionName.Substring(Me.SessionName.LastIndexOf("\") + 1, (Me.SessionName.Length - 4) - Me.SessionName.LastIndexOf("\") - 1)
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
            XMLWriter.WriteString(CType(blVideoOpen, String))
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
            XMLWriter.WriteString(CType(blImageOpen, String))
            XMLWriter.WriteEndElement()
            XMLWriter.WriteStartElement("FileName")
            XMLWriter.WriteString(strImage)
            XMLWriter.WriteEndElement()
            XMLWriter.WriteEndElement()

            XMLWriter.WriteStartElement("Database")
            XMLWriter.WriteStartElement("Open")
            XMLWriter.WriteString(CType(blDatabaseOpen, String))
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

    ''' <summary>
    ''' Disables buttons on main form when no file is loaded to prevent users from launching
    '''  functions while no database file is open.
    ''' </summary>
    Private Sub no_files_loaded()
        cmdShowSetTimecode.Enabled = False
        cmdTransectStart.Enabled = False
        cmdOffBottom.Enabled = False
        'Me.cmdEdit.Enabled = False
    End Sub

    ''' <summary>
    ''' Once the database is open, toggle the buttons depending on the video file status
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub database_is_open_toggle_visibility()
        DataTableColumnsToolStripMenuItem.Enabled = True
        SpeciesButtonsToolStripMenuItem.Enabled = True
        ConfigureHabitatButtonToolStripMenuItem.Enabled = True
        ConfigureTransectButtonsToolStripMenuItem.Enabled = True
        EditLookupTableToolStripMenuItem.Enabled = True
        ShowGridLinesToolStripMenuItem.Enabled = True
        If m_video_file_open Then
            txtTransectDate.Enabled = True
            txtProjectName.Enabled = True
            chkRecordEachSecond.Enabled = True
            mnuConfigureTools.Enabled = True
            DataCodeAssignmentsToolStripMenuItem.Enabled = True
            cmdShowSetTimecode.Enabled = True
            cmdTransectStart.Enabled = True
            cmdOffBottom.Enabled = True
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

        txtTransectDate.Enabled = True
        txtProjectName.Enabled = True
        chkRecordEachSecond.Enabled = True
        mnuConfigureTools.Enabled = True
        DataCodeAssignmentsToolStripMenuItem.Enabled = True
    End Sub

    ''' <summary>
    ''' Change text in OnOffBottomTextbox and on OffBottom button between "Off Bottom" and "On Bottom", and
    ''' insert a record in the database to reflect this change.
    ''' </summary>
    Private Sub toggle_bottom()
        If IsNothing(m_pnlHabitatData) Or IsNothing(m_pnlTransectData) Then
            Exit Sub
        End If
        If CBool(m_is_on_bottom) Then
            txtOnOffBottomTextbox.Text = OFF_BOTTOM_STRING
            txtOnOffBottomTextbox.Font = New Font(String.Empty, STATUS_FONT_SIZE, FontStyle.Bold)
            txtOnOffBottomTextbox.BackColor = Color.LightGray
            txtOnOffBottomTextbox.ForeColor = Color.Red
            txtOnOffBottomTextbox.TextAlign = HorizontalAlignment.Center
            cmdOffBottom.Text = ON_BOTTOM_STRING
            cmdOffBottom.Refresh()
            m_is_on_bottom = 0
        Else
            txtOnOffBottomTextbox.Text = ON_BOTTOM_STRING
            txtOnOffBottomTextbox.Font = New Font(String.Empty, STATUS_FONT_SIZE, FontStyle.Bold)
            txtOnOffBottomTextbox.BackColor = Color.LightGray
            txtOnOffBottomTextbox.ForeColor = Color.LimeGreen
            txtOnOffBottomTextbox.TextAlign = HorizontalAlignment.Center
            cmdOffBottom.Text = OFF_BOTTOM_STRING
            cmdOffBottom.Refresh()
            m_is_on_bottom = 1
        End If
        ' Need to merge dictionaries for Habitat and Transect panels here to the Off Bottom/ On Bottom KeyValuePair
        Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = New Dictionary(Of String, Tuple(Of String, String, Boolean))
        Dim tuple As Tuple(Of String, String, Boolean)
        dict = dict.Union(m_pnlHabitatData.Dictionary).Union(m_pnlTransectData.Dictionary).ToDictionary(Function(x) x.Key, Function(y) y.Value)

        tuple = New Tuple(Of String, String, Boolean)("3", CType(m_is_on_bottom, String), True)
        dict.Add("OnBottom", tuple)
        tuple = New Tuple(Of String, String, Boolean)("3", "3", False)
        dict.Add(DATA_CODE, tuple)

        runInsertQuery(dict)
        m_grdDatabase.fetchData()
        ' Need to remove the keys from the dictionary because the union operation is by reference and they will appear in
        ' pnlHabitat.Dictionary as well. Removing them from dict removes them from pnlHabitat.Dictionary as well.
        If dict.ContainsKey("OnBottom") Then
            dict.Remove("OnBottom")
        End If
        If dict.ContainsKey(DATA_CODE) Then
            dict.Remove(DATA_CODE)
        End If

    End Sub

    Private Function AddZeros(ByVal strNumber As String, ByVal intPlaces As Integer) As String
        Dim intLength As Integer
        intLength = Len(strNumber.ToString)

        Dim strZeros As String = String.Empty
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
    ''' Open an image.
    ''' </summary>
    Private Sub mnuOpenImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenImg.Click
        openImage()
    End Sub

    ''' <summary>
    ''' Open an image. Creates a new instance of m_frmImage. Greys out the video menu
    ''' as we should only have either video or image open, not both.
    ''' </summary>
    Private Sub openImage()
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.Title = OPEN_IMAGE_TITLE
        ofd.InitialDirectory = m_strImagePath
        ofd.Filter = "All types (*.*)|*.*|Joint Photographic Experts Group (*.jpg)|*.jpg|Graphics Interchange Format (*.gif)|*.gif|Portable Network Graphics (*.png)|*.png|Tagged Image File Format (*.tiff)|*.tiff"
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True
        ofd.Multiselect = False
        If ofd.ShowDialog() = DialogResult.OK Then
            m_strImagePath = GetDirectoryName(ofd.FileName)
            ' Store the new image path in XML file each time an image is opened
            SaveConfiguration(XPATH_IMAGE_PATH, m_strImagePath)
            If m_frmImage Is Nothing Then
                m_frmImage = New frmImage(m_strImagePath, GetFileName(ofd.FileName))
                If m_frmImage.ImageDirectoryEmpty Then
                    m_frmImage.ImageDirectoryEmptyMessage()
                    m_frmImage = Nothing
                    Exit Sub
                End If
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
                    aPoint.Y = CInt(intY / 2)
                    m_frmImage.Location = aPoint
                    m_frmImage.WindowState = FormWindowState.Normal
                Else
                    aPoint.X = intX + priMon.Bounds.Width
                    aPoint.Y = CInt(intY / 2)
                    m_frmImage.Location = aPoint
                    m_frmImage.WindowState = FormWindowState.Maximized
                End If
                m_frmImage.Show()
            End If
            m_image_open = True
            txtTimeSource.ForeColor = Color.LimeGreen
            Me.txtTime.ForeColor = Color.LimeGreen
            txtTimeSource.Text = "EXIF"
            m_time_source = 3
            txtTimeSource.Font = New Font(String.Empty, STATUS_FONT_SIZE, FontStyle.Bold)
            txtTimeSource.BackColor = Color.LightGray
            txtTimeSource.ForeColor = Color.LimeGreen
            txtTimeSource.TextAlign = HorizontalAlignment.Center
            txtTime.Font = New Font(String.Empty, STATUS_FONT_SIZE, FontStyle.Bold)
            txtTime.BackColor = Color.LightGray
            txtTime.ForeColor = Color.LimeGreen
            txtTime.TextAlign = HorizontalAlignment.Center
            txtTransectDate.Text = CType(m_transect_date, String)
            txtDateSource.Text = "EXIF"
            txtDateSource.Font = New Font(String.Empty, STATUS_FONT_SIZE, FontStyle.Bold)
            txtDateSource.BackColor = Color.LightGray
            txtDateSource.ForeColor = Color.LimeGreen
            txtDateSource.TextAlign = HorizontalAlignment.Center
            fldlgOpenFD.Reset()
            lblVideoControls.Visible = False
            cmdNothingInPhoto.Visible = True
            mnuOpenImg.Enabled = False
            mnuOpenFile.Enabled = False
            mnuUseExternalVideo.Enabled = False
        End If
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
            cmdShowSetTimecode.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Open a video file. Creates a new instance of m_frmVideoPlayer
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

        If m_frmVideoPlayer Is Nothing Then
            Try
                m_frmVideoPlayer = New frmVideoPlayer(VideoFileName, VIDEO_TIME_FORMAT)
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
                aPoint.Y = CInt(intY / 2)
                m_frmVideoPlayer.Location = aPoint
                m_frmVideoPlayer.WindowState = FormWindowState.Normal
                m_frmVideoPlayer.TopMost = True
            Else
                aPoint.X = intX + priMon.Bounds.Width
                aPoint.Y = CInt(Math.Floor(intY / 2.0))
                ' Use these settings when debugging, and comment out the windowstate and topmost lines below
                'aPoint.X = CInt(intX + priMon.Bounds.Width / 3)
                'aPoint.Y = CInt(intY / 4)
                m_frmVideoPlayer.Location = aPoint
                m_frmVideoPlayer.WindowState = FormWindowState.Maximized
                m_frmVideoPlayer.TopMost = True
            End If
            Me.VideoTime = Zero
            m_frmVideoPlayer.Show()
            'm_frmVideoPlayer.pnlHideVideo.Visible = True
            pnlVideoControls.Visible = True
            Me.txtTransectDate.Enabled = True
            Me.txtProjectName.Enabled = True
            Me.chkRecordEachSecond.Enabled = True
            Me.mnuConfigureTools.Enabled = True
            Me.DataCodeAssignmentsToolStripMenuItem.Enabled = True
            If Database.IsOpen Then
                Me.cmdTransectStart.Enabled = True
                Me.cmdOffBottom.Enabled = True
                Me.txtProjectName.Enabled = True
            End If

            ' In the future if the frames per second are returned properly, this will show that in the status bar..
            'Me.lblVideo.Text = "Video File '" & VideoFileName & "' is open (" & m_frmVideoPlayer.FPS & " frames per second)"
            Me.lblVideo.Text = "Video File '" & VideoFileName & "' is open"
            m_video_file_open = True
            mnuOpenImg.Enabled = False
            mnuOpenFile.Enabled = False
            mnuUseExternalVideo.Enabled = False
            pauseVideo()
            Return True
        Else
            'm_frmVideoPlayer.frmVideoPlayer_Load(Me, New System.EventArgs)
            'Me.VideoTime = m_frmVideoPlayer.CurrentVideoTime
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
                dblCurrentSeconds = m_frmVideoPlayer.Position
                strSeconds = dblCurrentSeconds.ToString.Split("."c)
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
        If m_frmVideoPlayer.IsPaused Or m_frmVideoPlayer.IsStopped Then
            playVideo()
            If Me.chkRecordEachSecond.Checked = True Then
                m_first_time = True
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
        If Not m_frmVideoPlayer Is Nothing Then
            m_frmVideoPlayer.Hide()
            m_frmVideoPlayer.Dispose()
            m_frmVideoPlayer = Nothing
        End If
        lblVideo.Text = VIDEO_FILE_STATUS_UNLOADED
        pnlVideoControls.Visible = False
        mnuOpenImg.Enabled = True
        mnuOpenFile.Enabled = True
        mnuUseExternalVideo.Enabled = True
        unsetTimes()
        cmdShowSetTimecode.Enabled = False
        Me.txtTransectDate.Enabled = False
        Me.txtProjectName.Enabled = False
        Me.chkRecordEachSecond.Enabled = False
        'Me.mnuConfigureTools.Enabled = False
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
        'm_frmVideoPlayer.Rate = m_dblVideoRate
        m_frmVideoPlayer.playVideo()
    End Sub

    ''' <summary>
    ''' Tell the video player to pause the video
    ''' </summary>
    Private Sub pauseVideo()
        'If Me.tmrRecordPerSecond.Enabled Then
        ' Me.tmrRecordPerSecond.Stop()
        ' End If
        m_frmVideoPlayer.pauseVideo()
    End Sub

    ''' <summary>
    ''' Tell the video player to stop the video
    ''' </summary>
    Private Sub stopVideo()
        'If Me.tmrRecordPerSecond.Enabled Then
        ' Me.tmrRecordPerSecond.Stop()
        ' End If
        m_frmVideoPlayer.stopVideo()
    End Sub

    ''' <summary>
    ''' If the video player is paused, show the play icon and set some variables
    ''' </summary>
    Public Sub playerPaused() Handles m_frmVideoPlayer.PauseEvent
        ' This is used to sense when the video player form pauses its video
        cmdPlayPause.BackgroundImage = My.Resources.Play_Icon
    End Sub

    ''' <summary>
    ''' If the video player is playing, show the pause icon and set some variables
    ''' </summary>
    Public Sub playerPlaying() Handles m_frmVideoPlayer.PlayEvent
        ' This is used to sense when the video player form starts playing its video
        cmdPlayPause.BackgroundImage = My.Resources.Pause_Icon
        setTimes()
    End Sub

    ''' <summary>
    ''' If the video player is stopped, show the play icon and set some variables
    ''' </summary>
    Public Sub playerStopped() Handles m_frmVideoPlayer.StopEvent
        ' This is used to sense when the video player form stops its video from inside.
        ' it is added as a handler and an event raised from the frmVideoPlayer class
        cmdPlayPause.BackgroundImage = My.Resources.Play_Icon
        Me.txtTimeSource.Text = m_frmVideoPlayer.CurrentVideoTimeFormatted
        setTimes()
    End Sub

    Private Sub recordEverySecond_CheckedChanged(sender As Object, e As EventArgs) Handles chkRecordEachSecond.CheckedChanged
        m_record_every_second_checked_first_time = Not m_record_every_second_checked_first_time
    End Sub

    ''' <summary>
    ''' Updates the time text on the form everytime the timer tick event is issued by the frmVideoPlayer form.
    ''' If the checkbox is set to store a record for every second of video, this does that also.
    ''' </summary>
    Public Sub timerTick() Handles m_frmVideoPlayer.TimerTickEvent
        Dim tsNewTime As TimeSpan
        Me.txtTimeSource.Text = m_frmVideoPlayer.CurrentVideoTimeFormatted
        If m_frmVideoPlayer.IsPlaying Or m_frmVideoPlayer.IsPaused Then
            tsNewTime = m_tsUserTime + m_frmVideoPlayer.CurrentVideoTime
            txtTime.Text = String.Format(VIDEO_TIME_FORMAT, tsNewTime.Hours, tsNewTime.Minutes, tsNewTime.Seconds, tsNewTime.Milliseconds)
        End If
        If m_frmVideoPlayer.IsPlaying And chkRecordEachSecond.Checked Then
            ' Check to see if one second has passed, and if so, store a record with the currently set values
            If m_record_every_second_checked_first_time Then
                m_previous_time = tsNewTime
                m_record_every_second_checked_first_time = False
            Else
                If tsNewTime.Subtract(m_previous_time).Seconds >= 1.0 Then
                    Dim dict As Dictionary(Of String, Tuple(Of String, String, Boolean)) = New Dictionary(Of String, Tuple(Of String, String, Boolean))
                    dict = dict.Union(m_pnlHabitatData.Dictionary).Union(m_pnlTransectData.Dictionary).ToDictionary(Function(x) x.Key, Function(y) y.Value)
                    runInsertQuery(dict)
                    m_grdDatabase.fetchData()
                    m_previous_time = tsNewTime
                End If
            End If
        End If
    End Sub

    Public Sub videoEnded() Handles m_frmVideoPlayer.VideoEndedEvent
        ' This is used to sense when the video ends its video from inside.
        ' it is added as a handler and an event raised from the m_frmVideoPlayer class
        cmdPlayPause.BackgroundImage = My.Resources.Play_Icon
        Me.txtTimeSource.Text = m_frmVideoPlayer.CurrentVideoTimeFormatted
        If m_tsUserTime <> Zero Then
            Dim tsNewTime As TimeSpan = m_tsUserTime + m_frmVideoPlayer.CurrentVideoTime
            txtTime.Text = String.Format(VIDEO_TIME_FORMAT, tsNewTime.Hours, tsNewTime.Minutes, tsNewTime.Seconds, tsNewTime.Milliseconds)
            'txtTime.
        End If
    End Sub

    Public Sub playerClosing() Handles m_frmVideoPlayer.ClosingEvent
        ' This is used to sense when the video player is closed (i.e. press the topright 'X' button)
        ' it is added as a handler and an event raised from the frmVideoPlayer class
        video_file_unload()
    End Sub

    Private Sub increaseRate()
        Try
            m_dblVideoRate = m_dblVideoRate + 0.25
            m_frmVideoPlayer.Rate = m_dblVideoRate
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
            m_frmVideoPlayer.Rate = m_dblVideoRate
            Me.lblVideoRate.Text = m_dblVideoRate & " X"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
        lblDatabase.Text = DB_FILE_STATUS_UNLOADED
        mnuOpenDatabase.Enabled = True
        DataCodeAssignmentsToolStripMenuItem.Enabled = False
        DataTableColumnsToolStripMenuItem.Enabled = False
        SpeciesButtonsToolStripMenuItem.Enabled = False
        ConfigureHabitatButtonToolStripMenuItem.Enabled = False
        ConfigureTransectButtonsToolStripMenuItem.Enabled = False
        EditLookupTableToolStripMenuItem.Enabled = False
        ShowGridLinesToolStripMenuItem.Enabled = False

        m_pnlTransectData.removeAllDynamicControls()
        m_pnlHabitatData.removeAllDynamicControls()
        m_pnlSpeciesData.removeAllDynamicControls()
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
            m_pnlTransectData.fillPanel(DB_TRANSECT_BUTTONS_TABLE)
            m_pnlHabitatData.fillPanel(DB_HABITAT_BUTTONS_TABLE)
            m_pnlSpeciesData.fillPanel(DB_SPECIES_BUTTONS_TABLE)
            Me.lblDatabase.Text = DB_FILE_STATUS_LOADED & m_db_filename & " is open"
            mnuOpenDatabase.Enabled = False
            mnuCloseDatabase.Enabled = True
            DataCodeAssignmentsToolStripMenuItem.Enabled = True
            m_grdDatabase = New VideoMinerDataGridView(DB_DATA_TABLE,
                                                       True,
                                                       VideoMinerDataGridView.RowOrderEnum.Descending,
                                                       True,
                                                       False)
            m_data_table = m_grdDatabase.DataTable
            SplitContainer1.Panel2.Controls.Add(m_grdDatabase)
            m_grdDatabase.Dock = DockStyle.Fill
            If IsNothing(m_frmSelectDataColumns) Then
                m_frmSelectDataColumns = New frmSelectDataColumns(m_data_table)
            End If
            Dim blDataColumnVis As Boolean() = GetDataColumnVisibilityConfiguration()
            If IsNothing(blDataColumnVis) Then
                DataTableModified()
            Else
                m_frmSelectDataColumns.SetVisibleColumns(blDataColumnVis)
            End If
            database_is_open_toggle_visibility()
        End If
    End Sub

    ''' <summary>
    ''' Creates and runs an 'INSERT INTO' query on the database for all of the given items in the dictionary.
    ''' Each item will be incorporated into a single query for insertion.
    ''' </summary>
    ''' <param name="dictTransect">A Dictionary object of Key/Value pairs where the keys are field names
    ''' as found in the main 'data' table in the database, and the values are a pair of codes, the first
    ''' one being the data code for the field being recorded to in the 'data' table and the second being
    ''' the data code itself as chosen by the user.</param>
    Private Sub runInsertQuery(dictTransect As Dictionary(Of String, Tuple(Of String, String, Boolean)))
        Dim intKey As Integer = Database.GetNextPrimaryKeyValue(DB_DATA_TABLE)
        If intKey <= 0 Then
            intKey = 1
        End If
        Dim names As String = "insert into " & DB_DATA_TABLE & " (ID,"
        Dim values As String = "values(" & CStr(intKey) & ","
        Dim strQuery As String

        If m_strVideoFile <> String.Empty Then
            names = names & "FileName,"
            values = values & SingleQuote(m_strVideoFile) & ","
        End If

        If m_project_name <> String.Empty Then
            names = names & "ProjectName,"
            values = values & SingleQuote(m_project_name) & ","
        End If

        If m_transect_name <> String.Empty Then
            names = names & "TransectName,"
            values = values & SingleQuote(m_transect_name) & ","
        End If

        If Not IsNothing(m_transect_date) Then
            names = names & "TransectDate,"
            values = values & SingleQuote(CType(m_transect_date, String)) & ","
        End If

        If Not IsNothing(m_tsUserTime) Then
            names = names & "TextTime,"
            Dim tmp As TimeSpan = m_tsUserTime
            If Not IsNothing(m_frmVideoPlayer) Then
                tmp = tmp + m_frmVideoPlayer.CurrentVideoTime
            End If
            values = values & SingleQuote(tmp.ToString("dd\.hh\:mm\:ss\.fff")) & ","
        End If

        If m_GPS_X <> NULL_STRING Then
            names = names & "X,"
            values = values & SingleQuote(m_GPS_X) & ","
        End If

        If m_GPS_Y <> NULL_STRING Then
            names = names & "Y,"
            values = values & SingleQuote(m_GPS_Y) & ","
        End If

        If m_GPS_Z <> NULL_STRING Then
            names = names & "Z,"
            values = values & SingleQuote(m_GPS_Z) & ","
        End If

        'Dim tsTime As TimeSpan = m_tsUserTime + m_frmVideoPlayer.CurrentVideoTime
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

    Private Sub txtQuickSpeciesCount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        modGlobals.numericTextboxValidation(e)
    End Sub

    ''' <summary>
    ''' Used to pause the video if data entry has started.
    ''' </summary>
    Private Sub dataEntryStarted()
        If Not m_frmVideoPlayer Is Nothing Then
            m_was_playing = m_frmVideoPlayer.IsPlaying
            If m_was_playing Then
                m_frmVideoPlayer.pauseVideo()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Used to play the video if data entry has ended.
    ''' </summary>
    Private Sub dataEntryEnded()
        If Not m_frmVideoPlayer Is Nothing Then
            If m_was_playing Then
                m_frmVideoPlayer.playVideo()
            End If
        End If
    End Sub

    ''' <summary>
    ''' For looking up and saving to the database a rare species (one not on the species buttons).
    ''' </summary>
    Private Sub cmdRareSpeciesLookup_Click() Handles m_pnlSpeciesData.RareSpeciesButtonPressed
        If IsNothing(m_data_table) Then
            Exit Sub
        End If
        If IsNothing(m_data_table.GetChanges()) Then
            dataEntryStarted()
            m_frmRareSpeciesLookup.Show()
        Else
            If MessageBox.Show("You have unsynced changes in your data table. Discard changes and record data anyway?", "Data table dirty", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                m_grdDatabase.fetchData() ' Cleans up the table first
                m_frmRareSpeciesLookup.Show()
            End If
        End If
    End Sub

    Private Sub KeyboardShortcutsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_frmKeyboardCommands = New frmKeyboardCommands
        m_frmKeyboardCommands.ShowDialog()
    End Sub

    Private Sub ConfigureHabitatButtonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureHabitatButtonToolStripMenuItem.Click
        dataEntryStarted()
        m_frmConfigureButtons = New frmConfigureButtons(DB_HABITAT_BUTTONS_TABLE, PANEL_NAME_HABITAT, PANEL_NAME_TRANSECT)
        m_frmConfigureButtons.ShowDialog()
    End Sub

    Private Sub ConfigureTransectButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureTransectButtonsToolStripMenuItem.Click
        dataEntryStarted()
        m_frmConfigureButtons = New frmConfigureButtons(DB_TRANSECT_BUTTONS_TABLE, PANEL_NAME_TRANSECT, PANEL_NAME_HABITAT)
        m_frmConfigureButtons.ShowDialog()
    End Sub

    Private Sub SpeciesButtonsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeciesButtonsToolStripMenuItem.Click
        dataEntryStarted()
        m_frmConfigureButtons = New frmConfigureButtons(DB_SPECIES_BUTTONS_TABLE, PANEL_NAME_SPECIES, PANEL_NAME_SPECIES, False)
        m_frmConfigureButtons.ShowDialog()
    End Sub

    ''' <summary>
    ''' The habitat and/or transect buttons in the database have been modified and need to be redrawn.
    ''' </summary>
    Private Sub m_frmConfigureButtons_DatabaseModifiedHandler() Handles m_frmConfigureButtons.DatabaseModifiedEvent
        m_pnlTransectData.removeAllDynamicControls()
        m_pnlTransectData.fillPanel(DB_TRANSECT_BUTTONS_TABLE)
        m_pnlHabitatData.removeAllDynamicControls()
        m_pnlHabitatData.fillPanel(DB_HABITAT_BUTTONS_TABLE)
        m_pnlSpeciesData.removeAllDynamicControls()
        m_pnlSpeciesData.fillPanel(DB_SPECIES_BUTTONS_TABLE)
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

    Private Sub NextImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'cmdNextImage_Click(sender, e)
    End Sub

    Private Sub PreviousImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'cmdPreviousImage_Click(sender, e)
    End Sub

    Private Sub cmdPrevious_Click(sender As Object, e As EventArgs) Handles cmdPrevious.Click
        m_frmVideoPlayer.stepBackward()
    End Sub

    Public Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        m_frmVideoPlayer.stepForward()
    End Sub

    Public Sub cmdPrevious_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.MouseHover
        m_tool_tip.Show("Vlc.DotNet control does not support reverse frame stepping", Me)
    End Sub

    Public Sub cmdPrevious_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.MouseLeave
        m_tool_tip.Hide(Me)
    End Sub

    Private Sub DeviceControlToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeviceControl.Click
        m_frmDeviceControl = New frmDeviceControl
        m_frmDeviceControl.ShowDialog()
    End Sub

    Private Sub RelayConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelayConfigurationToolStripMenuItem.Click
        m_frmRelayConfiguration = New frmRelayConfiguration

        ' Transfer the relay configuration variables to the relay configuration form
        m_frmRelayConfiguration.ConfigurationSet = Me.ConfigurationSet
        m_frmRelayConfiguration.RelaySetup = Me.RelaySetup
        m_frmRelayConfiguration.ParallelCom = Me.ParallelCom
        m_frmRelayConfiguration.ParallelBaud = Me.ParallelBaud
        m_frmRelayConfiguration.PortOneCom = Me.PortOneCom
        m_frmRelayConfiguration.PortOneBaud = Me.PortOneBaud
        m_frmRelayConfiguration.PortTwoCom = Me.PortTwoCom
        m_frmRelayConfiguration.PortTwoBaud = Me.PortTwoBaud
        m_frmRelayConfiguration.DeviceOneRelayOne = Me.DeviceOneRelayOne
        m_frmRelayConfiguration.DeviceOneRelayTwo = Me.DeviceOneRelayTwo
        m_frmRelayConfiguration.DeviceOneRelayThree = Me.DeviceOneRelayThree
        m_frmRelayConfiguration.DeviceOneRelayFour = Me.DeviceOneRelayFour
        m_frmRelayConfiguration.DeviceTwoRelayOne = Me.DeviceTwoRelayOne
        m_frmRelayConfiguration.DeviceTwoRelayTwo = Me.DeviceTwoRelayTwo
        m_frmRelayConfiguration.DeviceTwoRelayThree = Me.DeviceTwoRelayThree
        m_frmRelayConfiguration.DeviceTwoRelayFour = Me.DeviceTwoRelayFour

        m_frmRelayConfiguration.ShowDialog()
    End Sub

    ' Handles updating the NMEA text box
    Public Sub updateTextBox()
        'Try
        '    strTimeDateSource = "GPS"
        '    m_time_source = 4
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

        '    'If Not m_frmGpsSettings Is Nothing Then
        '    If Not m_frmGpsSettings Is Nothing Then
        '        m_frmGpsSettings.cmdConnection.Enabled = True
        '        m_frmGpsSettings.cmdConnection.Text = "Close GPS Connection"
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
        '    Dim strCaption As String = String.Empty

        '    ' If there is not a GPS fix then exit the sub routine
        '    If Not blAquiredFix Then
        '        If Not m_frmGpsSettings Is Nothing Then
        '            m_frmGpsSettings.lblGPSMessage.Text = "SEARCHING. . ."
        '            m_frmGpsSettings.lblGPSMessage.ForeColor = Color.Blue
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
        '    If Not m_frmGpsSettings Is Nothing Then
        '        m_frmGpsSettings.lblGPSMessage.Text = strCaption
        '        m_frmGpsSettings.lblGPSMessage.ForeColor = Color.LimeGreen
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
        '    If Not m_frmGpsSettings Is Nothing Then
        '        m_frmGpsSettings.lblCurrentYValue.Text = FormatNumber(Me.GPS_Y, 5)
        '        m_frmGpsSettings.lblCurrentXValue.Text = FormatNumber(Me.GPS_X, 5)
        '        m_frmGpsSettings.lblCurrentZValue.Text = FormatNumber(Me.GPS_Z, 2)
        '        m_frmGpsSettings.lblCurrentDateValue.Text = Me.GPSDate
        '        m_frmGpsSettings.lblCurrentTimeValue.Text = Me.GPSDateTime
        '    End If
        '    If Not m_frmSetTime Is Nothing Then
        '        m_frmSetTime.txtSetTime.Text = Me.GPSDateTime
        '    End If
        '    Me.lblYValue.Text = FormatNumber(Me.GPS_Y, 5)
        '    Me.lblXValue.Text = FormatNumber(Me.GPS_X, 5)
        '    Me.lblZValue.Text = FormatNumber(Me.GPS_Z, 2)

        '    Me.txtTimeSource.Text = strTimeDateSource
        '    Me.txtTimeSource.Font = New Font(String.Empty, STATUS_FONT_SIZE, FontStyle.Bold)
        '    Me.txtTimeSource.BackColor = Color.LightGray

        '    Me.txtTimeSource.TextAlign = HorizontalAlignment.Center
        '    Me.txtTime.Font = New Font(String.Empty, STATUS_FONT_SIZE, FontStyle.Bold)
        '    Me.txtTime.BackColor = Color.LightGray

        '    Me.txtTime.TextAlign = HorizontalAlignment.Center
        '    Me.txtTime.Text = Me.GPSDateTime

        '    Me.txtTransectDate.Text = Me.GPSDate
        '    Me.txtDateSource.Text = strTimeDateSource
        '    Me.txtDateSource.Font = New Font(String.Empty, STATUS_FONT_SIZE, FontStyle.Bold)
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
        '    'm_frmGpsSettings.lblCurrentTimeValue.Text = Me.GPSDateTime
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

    Private Sub DisableHabitatButtonsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If DisableHabitatButtonsToolStripMenuItem.Text = "Disable Habitat Buttons" Then
        '    DisableHabitatButtonsToolStripMenuItem.Text = "Enable Habitat Buttons"
        '    Dim item As Button
        '    For Each item In buttons
        '        If Not item Is Nothing Then
        '            item.Enabled = False
        '        End If
        '    Next
        'Else
        '    DisableHabitatButtonsToolStripMenuItem.Text = "Disable Habitat Buttons"
        '    Dim item As Button
        '    For Each item In buttons
        '        If Not item Is Nothing Then
        '            item.Enabled = True
        '        End If
        '    Next
        'End If
    End Sub

    Private Sub m_pnlSpeciesData_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If m_db_file_open Then

            Me.m_pnlSpeciesData.Controls.Clear()
        End If
    End Sub


    Private Sub txtTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTime.TextChanged
        If Me.txtTimeSource.Text = "VIDEO" Then
            If Me.txtTime.Text = VIDEO_TIME_LABEL Then
                Dim strDate As String() = txtTransectDate.Text.Split("/"c)
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

                m_transect_date = CDate(strNewDate)
                Me.txtTransectDate.Text = CType(m_transect_date, String)
            End If
        End If
    End Sub

    Private Sub EditLookupTableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditLookupTableToolStripMenuItem.Click
        m_frmEditLookupTable = New frmEditLookupTable
        m_frmEditLookupTable.ShowDialog()
    End Sub

    'Private Sub grdVideoMinerDatabase_ColumnDisplayIndexChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)
    '    If blupdateColumns Then
    '        If Not blOpenDatabase And Not blCloseDatabase Then
    '            Dim strColumns As String = String.Empty
    '            dataColumns = New Collection
    '            Dim dgColumn As DataGridViewColumn
    '            For Each dgColumn In grdVideoMinerDatabase.Columns
    '                dataColumns.Add(dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width)
    '                strColumns = strColumns & dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width & ","
    '            Next
    '            SaveConfiguration(XPATH_DATABASE_NAME, m_db_filename)
    '            SaveConfiguration(XPATH_DATABASE_COLUMNS, strColumns.Substring(0, strColumns.Length - 1))
    '        End If
    '    End If
    'End Sub

    'Private Sub grdVideoMinerDatabase_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)
    '    If blupdateColumns Then
    '        If Not blOpenDatabase And Not blCloseDatabase Then
    '            Dim strColumns As String = String.Empty
    '            dataColumns = New Collection
    '            Dim dgColumn As DataGridViewColumn
    '            For Each dgColumn In grdVideoMinerDatabase.Columns
    '                dataColumns.Add(dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width)
    '                strColumns = strColumns & dgColumn.Name & ":" & dgColumn.DisplayIndex & ":" & dgColumn.Width & ","
    '            Next
    '            SaveConfiguration(XPATH_DATABASE_NAME, m_db_filename)
    '            SaveConfiguration(XPATH_DATABASE_COLUMNS, strColumns.Substring(0, strColumns.Length - 1))
    '        End If
    '    End If
    'End Sub

    ''' <summary>
    ''' Set the User time (txtTime) textbox and source time (txtTimeSource) to show
    ''' </summary>
    Private Sub setTimes()
        Dim tsNewTime As TimeSpan
        If m_frmVideoPlayer IsNot Nothing Then
            tsNewTime = m_tsUserTime + m_frmVideoPlayer.CurrentVideoTime
        Else
            tsNewTime = m_tsUserTime
        End If
        ' Format the time according to the VIDEO_TIME_FORMAT
        txtTime.Text = String.Format(VIDEO_TIME_FORMAT, tsNewTime.Hours, tsNewTime.Minutes, tsNewTime.Seconds, tsNewTime.Milliseconds)
        txtTime.Font = New Font(String.Empty, 10, FontStyle.Bold)
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
        txtTime.Text = String.Empty
        txtTimeSource.Visible = False
        txtTimeSource.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Gets the new user defined time from the set time form and call setUserTime to apply
    ''' </summary>
    Private Sub time_changed() Handles m_frmSetTime.TimeChanged
        m_tsUserTime = m_frmSetTime.UserTime
        setTimes()
    End Sub

    Private Sub gps_connected() Handles m_frmGpsSettings.GPSConnectedEvent
        lblGPSPortValue.Text = "OPEN"
        lblGPSPortValue.ForeColor = Color.LimeGreen
        lblGPSConnectionValue.Text = "CONNECTED"
        lblGPSConnectionValue.ForeColor = Color.Blue

        m_frmSetTime.UserTime = m_gps_user_time
        m_frmSetTime.ChangeSource(frmSetTime.WhichTimeEnum.GPS)
    End Sub

    ''' <summary>
    ''' Handles the GPS disconnection. Location data are reset and the SetTime form is set up to be Video time instead.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub gps_disconnected() Handles m_frmGpsSettings.GPSDisconnectedEvent
        ' Clear out the last location data
        m_GPS_X = String.Empty
        m_GPS_Y = String.Empty
        m_GPS_Z = String.Empty
        lblGPSPortValue.Text = "CLOSED"
        lblGPSPortValue.ForeColor = Color.Red
        lblGPSConnectionValue.Text = "NO GPS FIX"
        lblGPSConnectionValue.ForeColor = Color.Red
        lblXValue.Text = String.Empty
        lblYValue.Text = String.Empty
        lblZValue.Text = String.Empty
        txtTime.ForeColor = Color.Red
        txtTimeSource.ForeColor = Color.Red
        txtDateSource.ForeColor = Color.Red

        txtNMEA.Text = String.Empty
        txtNMEA.Visible = False
        lblGPSLocation.Visible = False
        lblX.Visible = False
        lblY.Visible = False
        lblZ.Visible = False

        ' Revert to default of video time
        m_frmSetTime.TimeSource = frmSetTime.WhichTimeEnum.Video
        m_frmSetTime.rbVideoTime.Checked = True
    End Sub

    Private Sub gps_connecting() Handles m_frmGpsSettings.ConnectingSerialPortEvent
        lblGPSConnectionValue.Text = "SEARCHING. . ."
        lblGPSConnectionValue.ForeColor = Color.Blue
        lblXValue.ForeColor = Color.Red
        lblYValue.ForeColor = Color.Red
        lblZValue.ForeColor = Color.Red
        txtTransectDate.ForeColor = Color.Red
        txtDateSource.ForeColor = Color.Red
    End Sub

    Private Sub image_form_closing() Handles m_frmImage.ImageFormClosingEvent
        cmdNothingInPhoto.Visible = False
        m_image_open = False
        mnuOpenImg.Enabled = True
        mnuOpenFile.Enabled = True
        mnuUseExternalVideo.Enabled = True
        m_frmImage = Nothing
    End Sub

    Private Sub button_configuration_changed() Handles m_frmConfigureButtonFormat.ButtonConfigurationChangedEvent
        With m_frmConfigureButtonFormat
            ButtonHeight = CInt(.txtButtonHeight.Text)
            ButtonWidth = CInt(.txtButtonWidth.Text)
            ButtonFont = .cboButtonFont.Text
            'blupdateColumns = False
            m_pnlSpeciesData.Controls.Clear()
            'blupdateColumns = True
        End With
    End Sub

    Private Sub relay_configuration_changed() Handles m_frmRelayConfiguration.RelayConfigurationChangedEvent
        ConfigurationSet = m_frmRelayConfiguration.ConfigurationSet
        RelaySetup = m_frmRelayConfiguration.RelaySetup
        ParallelCom = m_frmRelayConfiguration.ParallelCom
        ParallelBaud = m_frmRelayConfiguration.ParallelBaud
    End Sub

    Private Sub right_arrow_pressed() Handles m_frmVideoPlayer.RightArrowPressedEvent
        If m_frmVideoPlayer.IsPlaying Then
            pauseVideo()
        ElseIf m_frmVideoPlayer.IsPaused Then
            m_frmVideoPlayer.stepForward()
        End If
    End Sub

    Private Sub frmVideoMiner_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles m_frmVideoPlayer.KeyDown
        Select Case e.KeyCode
            Case Keys.Left
                e.Handled = True
            Case Keys.Right
                If m_frmVideoPlayer.IsPlaying Then
                    pauseVideo()
                ElseIf m_frmVideoPlayer.IsPaused Then
                    m_frmVideoPlayer.stepForward()
                End If
                e.Handled = True
            Case Keys.Space
                If m_frmVideoPlayer.IsPlaying Then
                    pauseVideo()
                ElseIf m_frmVideoPlayer.IsPaused Then
                    playVideo()
                ElseIf m_frmVideoPlayer.IsStopped Then
                    playVideo()
                End If
                e.Handled = True
        End Select
    End Sub

    Private Sub txtFramesToSkip_MouseHover(sender As Object, e As EventArgs)
        m_tool_tip.Show("Number of frames to skip for frame stepping", Me)
    End Sub

    Private Sub txtFramesToSkip_MouseLeave(sender As Object, e As EventArgs)
        m_tool_tip.Hide(Me)
    End Sub

    ''' <summary>
    ''' Updates all GPS member variables for settings and saves the configuration for all of them (xml file)
    ''' </summary>
    Private Sub save_GPS_configuration() Handles m_frmGpsSettings.GPSVariablesChangedEvent
        m_com_port = m_frmGpsSettings.ComPort
        m_baud_rate = m_frmGpsSettings.BaudRate
        m_nmea_string_type = m_frmGpsSettings.NMEAStringType
        m_parity = m_frmGpsSettings.Parity
        m_stop_bits = m_frmGpsSettings.StopBits
        m_data_bits = m_frmGpsSettings.DataBits

        SaveConfiguration(XPATH_GPS_COM_PORT, m_com_port)
        SaveConfiguration(XPATH_GPS_BAUD_RATE, CStr(m_baud_rate))
        SaveConfiguration(XPATH_GPS_NMEA_STRING, m_nmea_string_type)
        SaveConfiguration(XPATH_GPS_PARITY, m_parity)
        SaveConfiguration(XPATH_GPS_STOP_BITS, CStr(m_stop_bits))
        SaveConfiguration(XPATH_GPS_DATA_BITS, CStr(m_data_bits))
        SaveConfiguration(XPATH_GPS_TIMEOUT, CStr(m_timeout))
    End Sub

    Private Delegate Sub RefreshGPSStatusDelegate()
    Private marshalRefreshGPSStatus As RefreshGPSStatusDelegate = New RefreshGPSStatusDelegate(AddressOf RefreshGPSStatus)

    ''' <summary>
    ''' Refresh the member variables and labels to reflect when the the GPS data changes. 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshGPSStatus()
        If m_frmGpsSettings.IsConnected Then
            m_gps_user_time = m_frmGpsSettings.GPSTime
            m_tsUserTime = m_frmGpsSettings.GPSTime
            ' Get the GPS location data into Videominer member variables
            m_GPS_X = m_frmGpsSettings.LatitudeString
            m_GPS_Y = m_frmGpsSettings.LongitudeString
            m_GPS_Z = m_frmGpsSettings.ElevationString
            lblXValue.Text = m_frmGpsSettings.LatitudeDegrees & Chr(&HB0) & "  " & m_frmGpsSettings.LatitudeMinutes & "'"
            lblYValue.Text = m_frmGpsSettings.LongitudeDegrees & Chr(&HB0) & "  " & m_frmGpsSettings.LongitudeMinutes & "'"
            lblZValue.Text = m_frmGpsSettings.Elevation & "m"
            txtNMEA.Text = m_frmGpsSettings.NMEAString
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
            m_tsUserTime = m_frmSetTime.UserTime
        End If
        txtTime.Text = pad0(m_tsUserTime.Hours) & ":" & pad0(m_tsUserTime.Minutes) & ":" & pad0(m_tsUserTime.Seconds)
    End Sub

    ''' <summary>
    ''' The Set Time form will request GPS time, and this function handles that
    ''' </summary>
    Private Sub m_frmSetTime_RequestGPS() Handles m_frmSetTime.RequestGPSTime
        If m_frmGpsSettings.IsConnected Then
            m_frmSetTime.UserTime = m_gps_user_time
            m_frmSetTime.ChangeSource(frmSetTime.WhichTimeEnum.GPS)
        Else
            m_frmGpsSettings.ShowDialog()
        End If
    End Sub

    ''' <summary>
    ''' Handles an event to grab the time from the m_frmSetTime form.
    ''' </summary>
    Private Sub m_frmSetTime_TimeSourceChanged() Handles m_frmSetTime.TimeSourceChange
    End Sub

    ''' <summary>
    ''' Handles an event to grab the latest data from the GPS device.
    ''' </summary>
    Private Sub m_frmGpsSettings_DataChanged() Handles m_frmGpsSettings.DataChangedEvent
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
                If m_frmVideoPlayer IsNot Nothing Then
                    m_frmVideoPlayer.Close()
                    m_frmVideoPlayer = Nothing
                End If
                If m_frmGpsSettings IsNot Nothing Then
                    m_frmGpsSettings.Close()
                    m_frmGpsSettings = Nothing
                End If
                If m_frmSetTime IsNot Nothing Then
                    m_frmSetTime.Close()
                    m_frmSetTime = Nothing
                End If
                e.Cancel = False
            End If
        End If
    End Sub

    Private Function MethodInvoker() As [Delegate]
        Throw New NotImplementedException
    End Function

    Private Sub radDetailedEntry_CheckedChanged(sender As Object, e As EventArgs)
        ' Tell the species panel that the buttons should all be detailed entry type
        If Not IsNothing(m_pnlSpeciesData) Then
            m_pnlSpeciesData.WhichEntryStyle = DynamicButton.WhichEntryStyleEnum.Detailed
        End If
    End Sub

    Private Sub radAbundanceEntry_CheckedChanged(sender As Object, e As EventArgs)
        ' Tell the species panel that the buttons should all be abundance entry type
        If Not IsNothing(m_pnlSpeciesData) Then
            m_pnlSpeciesData.WhichEntryStyle = DynamicButton.WhichEntryStyleEnum.Abundance
        End If
    End Sub

    ''' <summary>
    ''' Handles the DataEntrytCanceledEvent up so that video can be set to play again when the user decides to cancel data entry.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dataEntryCanceledHandler(ByVal sender As Object, ByVal e As EventArgs) Handles m_pnlHabitatData.DataEntryCanceled,
                                                                                               m_pnlTransectData.DataEntryCanceled,
                                                                                               m_pnlSpeciesData.DataEntryCanceled,
                                                                                               m_frmRareSpeciesLookup.DataEntryCanceled,
                                                                                               m_frmSpeciesList.DataEntryCanceled,
                                                                                               m_frmSetTime.DataEntryCanceled

        dataEntryEnded()
    End Sub

    ''' <summary>
    ''' Toggle Tooltip visibility
    ''' </summary>
    Private Sub mnuShowTooltips_Click(sender As Object, e As EventArgs) Handles mnuShowTooltips.Click
        If IsNothing(m_grdDatabase) Then
            Exit Sub
        End If
        If mnuShowTooltips.Checked Then
            mnuShowTooltips.Checked = False
            m_grdDatabase.DisableToolTips()
        Else
            mnuShowTooltips.Checked = True
            m_grdDatabase.EnableToolTips()
        End If
    End Sub

    ''' <summary>
    ''' Select the data table columns to show. This changes the select query used to populate the grid
    ''' </summary>
    Private Sub DataTableColumnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataTableColumnsToolStripMenuItem.Click
        m_frmSelectDataColumns.Show()
    End Sub

    ''' <summary>
    ''' Change the visibility of the datbase table columns for the main data table.
    ''' Also, save the configuration so it doesn't have to be done every time the app is opened.
    ''' </summary>
    Private Sub DataTableModified() Handles m_frmSelectDataColumns.DataTableModified
        Dim strColName As String
        Dim visibleCols As Boolean() = m_frmSelectDataColumns.VisibleColumns
        For i As Integer = 0 To visibleCols.Count - 1
            m_grdDatabase.DGV.Columns(i).Visible = m_frmSelectDataColumns.VisibleColumns(i)
            strColName = m_grdDatabase.DGV.Columns(i).Name
            SaveConfiguration("/DataColumnVisibility/" & strColName, m_frmSelectDataColumns.VisibleColumns(i).ToString(), False)
        Next
    End Sub

    ''' <summary>
    ''' Show or hide the grid lines in the three panels
    ''' </summary>
    Private Sub ShowGridLinesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowGridLinesToolStripMenuItem.Click
        ShowGridLinesToolStripMenuItem.Checked = Not ShowGridLinesToolStripMenuItem.Checked
        If ShowGridLinesToolStripMenuItem.Checked Then
            m_pnlTransectData.ShowGridLines = True
            m_pnlHabitatData.ShowGridLines = True
            m_pnlSpeciesData.ShowGridLines = True
        Else
            m_pnlTransectData.ShowGridLines = False
            m_pnlHabitatData.ShowGridLines = False
            m_pnlSpeciesData.ShowGridLines = False
        End If
    End Sub

    Private Sub DataCodesTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataCodeAssignmentsToolStripMenuItem.Click
        If IsNothing(m_frmViewDataTable) Then
            m_frmViewDataTable = New frmViewDataTable(DB_DATA_CODES_TABLE)
        End If
        m_frmViewDataTable.Show()
    End Sub

End Class