Imports System.Data.OleDb
Imports System.IO.Ports
Imports System.Xml
Imports System.IO

''' <summary>
''' This module defines 'Global' variables and functions.
''' </summary>
''' <remarks>Think hard before adding something here, especially new classes. The program should
''' remain object-oriented as much as possible and adding things here will likely break that</remarks>
Module modGlobals
    Public Const VMCD = "VideoMinerConfigurationDetails"
    Public Const VIDEOMINER_CONFIG_FILE_NAME = VMCD & ".xml"
    Public Const DB_DATA_TABLE As String = "data"
    Public Const EXIF_FILE_NAME As String = "exiftool.exe"
    Public Const EXIF_ARGS As String = " -s "

    Public Const DB_ABUNDANCE_TABLE As String = "lu_acfor_scale"
    Public Const DB_BUTTON_COLORS_TABLE As String = "lu_button_colors"
    Public Const DB_COMPLEXITY_TABLE As String = "lu_complexity"
    Public Const DB_CONFIDENCE_IDS_TABLE As String = "lu_confidence_ids"
    Public Const DB_DATA_CODES_TABLE As String = "lu_data_codes"
    Public Const DB_DISTURBANCE_TABLE As String = "lu_disturbance"
    Public Const DB_IMAGE_QUALITY_TABLE As String = "lu_image_quality"
    Public Const DB_OBSERVED_SIDE_TABLE As String = "lu_observed_side"
    Public Const DB_PERCENT_TABLE As String = "lu_percent"
    Public Const DB_PROTOCOL_TABLE As String = "lu_protocol"
    Public Const DB_RELIEF_TABLE As String = "lu_relief"
    Public Const DB_SPECIES_CODE_TABLE As String = "lu_species_code"
    Public Const DB_SUBSTRATE_TABLE As String = "lu_substrate"
    Public Const DB_SURVEY_MODE_TABLE As String = "lu_survey_mode"
    Public Const DB_TIME_SOURCE_TABLE As String = "lu_time_source"
    Public Const DB_HABITAT_BUTTONS_TABLE As String = "videominer_habitat_buttons"
    Public Const DB_SPECIES_BUTTONS_TABLE As String = "videominer_species_buttons"
    Public Const DB_TRANSECT_BUTTONS_TABLE As String = "videominer_transect_buttons"

    Public Const DB_CONN_STRING As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="

    Public Const GITHUB_URL As String = "https://github.com/cgrandin/video-miner"
    Public Const DESIGNER_EMAIL As String = "mailto:chris.grandin@dfo-mpo.gc.ca"
    Public Const VIDEO_TIME_LABEL As String = "00:00:00"
    Public Const VIDEO_TIME_DECIMAL_LABEL As String = "00:00:00.000"
    Public Const VIDEO_TIME_FORMAT As String = "{0:D2}:{1:D2}:{2:D2}.{3:D4}"

    Public Const NULL_STRING As String = ""
    Public Const UNINITIALIZED_DATA_VALUE = "NULL"

    ' Names of database columns
    Public Const DRAWING_ORDER As String = "DrawingOrder"
    Public Const BUTTON_TEXT As String = "ButtonText"
    Public Const TABLE_NAME As String = "TableName"
    Public Const DATA_CODE As String = "DataCode"
    Public Const DATA_CODE_NAME As String = "DataCodeName"
    Public Const BUTTON_COLOR As String = "ButtonColor"
    Public Const BUTTON_FONT As String = "ButtonFont"
    Public Const BUTTON_TEXT_SIZE As String = "ButtonTextSize"
    Public Const TEXTBOX_TEXT_SIZE As String = "TextboxTextSize"
    Public Const BUTTON_CODE As String = "ButtonCode"
    Public Const BUTTON_CODE_NAME As String = "ButtonCodeName"
    Public Const KEYBOARD_SHORTCUT As String = "KeyboardShortcut"
    Public Const USER_ENTERED As String = "UserEntered"
    Public Const DEFAULT_BUTTON_FONT As String = "Microsoft Sans Serif"
    Public Const DEFAULT_BUTTON_TEXT_SIZE As String = "10"
    Public Const DEFAULT_TEXTBOX_TEXT_SIZE As String = "10"

    Public Const XPATH_PREVIOUS_PROJECTS As String = "/PreviousProjects"

    Public Const XPATH_DATABASE_PATH As String = "/DatabasePath"
    Public Const XPATH_SESSION_PATH As String = "/SessionPath"
    Public Const XPATH_VIDEO_PATH As String = "/VideoPath"
    Public Const XPATH_IMAGE_PATH As String = "/ImagePath"

    Public Const XPATH_GPS_COM_PORT As String = "/GPS/ComPort"
    Public Const XPATH_GPS_NMEA_STRING As String = "/GPS/NMEA"
    Public Const XPATH_GPS_BAUD_RATE As String = "/GPS/BaudRate"
    Public Const XPATH_GPS_PARITY As String = "/GPS/Parity"
    Public Const XPATH_GPS_STOP_BITS As String = "/GPS/StopBits"
    Public Const XPATH_GPS_DATA_BITS As String = "/GPS/DataBits"
    Public Const XPATH_GPS_TIMEOUT As String = "/GPS/Timeout"

    Public Const XPATH_BUTTON_HEIGHT As String = "/ButtonFormat/ButtonSize/Height"
    Public Const XPATH_BUTTON_WIDTH As String = "/ButtonFormat/ButtonSize/Width"
    Public Const XPATH_BUTTON_FONT As String = "/ButtonFormat/ButtonText/Font"

    Public Const XPATH_DATABASE_NAME As String = "/Database/Configuration/DatabaseName"
    Public Const XPATH_DATABASE_COLUMNS As String = "/Database/Configuration/Columns"

    Public Const XPATH_DEVICE_CONFIGURATION_SET As String = "/DeviceControl/ConfigurationSet"
    Public Const XPATH_DEVICE_SETUP As String = "/DeviceControl/Setup"
    Public Const XPATH_DEVICE_PARALLEL_COM_PORT As String = "/DeviceControl/Parallel/ComPort"
    Public Const XPATH_DEVICE_PARALLEL_BAUD_RATE As String = "/DeviceControl/Parallel/BaudRate"
    Public Const XPATH_DEVICE_TWOPORTS_DEVICE1_COM_PORT As String = "/DeviceControl/TwoPorts/Device1/ComPort"
    Public Const XPATH_DEVICE_TWOPORTS_DEVICE1_BAUD_RATE As String = "/DeviceControl/TwoPorts/Device1/BaudRate"
    Public Const XPATH_DEVICE_TWOPORTS_DEVICE2_COM_PORT As String = "/DeviceControl/TwoPorts/Device2/ComPort"
    Public Const XPATH_DEVICE_TWOPORTS_DEVICE2_BAUD_RATE As String = "/DeviceControl/TwoPorts/Device2/BaudRate"
    Public Const XPATH_DEVICE_RELAY_DEVICE1_RELAY1 As String = "/DeviceControl/RelayNames/Device1/Relay1"
    Public Const XPATH_DEVICE_RELAY_DEVICE1_RELAY2 As String = "/DeviceControl/RelayNames/Device1/Relay2"
    Public Const XPATH_DEVICE_RELAY_DEVICE1_RELAY3 As String = "/DeviceControl/RelayNames/Device1/Relay3"
    Public Const XPATH_DEVICE_RELAY_DEVICE1_RELAY4 As String = "/DeviceControl/RelayNames/Device1/Relay4"
    Public Const XPATH_DEVICE_RELAY_DEVICE2_RELAY1 As String = "/DeviceControl/RelayNames/Device2/Relay1"
    Public Const XPATH_DEVICE_RELAY_DEVICE2_RELAY2 As String = "/DeviceControl/RelayNames/Device2/Relay2"
    Public Const XPATH_DEVICE_RELAY_DEVICE2_RELAY3 As String = "/DeviceControl/RelayNames/Device2/Relay3"
    Public Const XPATH_DEVICE_RELAY_DEVICE2_RELAY4 As String = "/DeviceControl/RelayNames/Device2/Relay4"

    Public Const XPATH_RANGE_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Range/Displayed"
    Public Const XPATH_IDCONFIDENCE_DISPLAY As String = "/DetailedSpeciesEventConfiguration/IDConfidence/Displayed"
    Public Const XPATH_ABUNDANCE_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Abundance/Displayed"
    Public Const XPATH_COUNT_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Count/Displayed"
    Public Const XPATH_HEIGHT_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Height/Displayed"
    Public Const XPATH_WIDTH_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Width/Displayed"
    Public Const XPATH_LENGTH_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Length/Displayed"
    Public Const XPATH_COMMENTS_DISPLAY As String = "/DetailedSpeciesEventConfiguration/Comments/Displayed"

    Public Const XPATH_RANGE_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Range/DefaultValue"
    Public Const XPATH_IDCONFIDENCE_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/IDConfidence/DefaultValue"
    Public Const XPATH_ABUNDANCE_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Abundance/DefaultValue"
    Public Const XPATH_COUNT_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Count/DefaultValue"
    Public Const XPATH_HEIGHT_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Height/DefaultValue"
    Public Const XPATH_WIDTH_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Width/DefaultValue"
    Public Const XPATH_LENGTH_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Length/DefaultValue"
    Public Const XPATH_COMMENTS_DEFAULT_VALUE As String = "/DetailedSpeciesEventConfiguration/Comments/DefaultValue"

    Public Const GPS_COM_PORT_DEFAULT As String = "COM10"
    Public Const GPS_NMEA_DEFAULT As String = "GPGGA"
    Public Const GPS_BAUD_RATE_DEFAULT As Integer = 4800
    Public Const GPS_PARITY_DEFAULT As String = "NONE"
    Public Const GPS_STOP_BITS_DEFAULT As Integer = 1
    Public Const GPS_DATA_BITS_DEFAULT As Integer = 8
    Public Const GPS_TIMEOUT_DEFAULT As Integer = 5

    Public Const PANEL_NAME_SPECIES As String = "SPECIES DATA"
    Public Const PANEL_NAME_HABITAT As String = "HABITAT DATA"
    Public Const PANEL_NAME_TRANSECT As String = "TRANSECT DATA"

    Public DEFAULT_QUICK_ENTRY_COUNT As String = "1"

    Public Const VIDEO_FRAME_STEP_DEFAULT As Integer = 500
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
    Public Const SCREEN_CAPTURE_COMMENT As String = "Screen Capture"
    Public Const COMMENT_ADDED As String = "666"
    Public Const COMMENT_ADDED_FIELD_NAME As String = "Comment"
    Public Const NOTHING_IN_PHOTO As String = "777"
    Public Const NOTHING_IN_PHOTO_COMMENT As String = "Nothing In Photo"
    Public Const INDIVIDUAL_HABITAT_VARIABLE_CLEARED As String = "888"
    Public Const ALL_HABITAT_VARIABLES_CLEARED As String = "999"

    Public Const ON_OFF_BOTTOM_NOT_ASSIGNED As Integer = -1
    Public Const SPECIES_ID_NOT_ASSIGNED As Integer = -1
    Public Const SPECIES_NAME_NOT_ASSIGNED As String = NULL_STRING
    Public Const SPECIES_COUNT_NOT_ASSIGNED As Integer = -1

    Public blRareSpecies As Boolean = False

    Public dictHabitatFieldValues As Dictionary(Of String, String)
    Public dictTempHabitatFieldValues As Dictionary(Of String, String)
    Public dictTransectFieldValues As Dictionary(Of String, String)

    Public dtUserTime As DateTime
    Public dblVideoTimeUserSet As Double = 0
    Public booUseExternalVideo As Boolean = False
    Public booUseGPSTimeCodes As Boolean = False
    Public strHabitatButtonNames() As String
    Public strTransectButtonNames() As String
    Public strRareSpeciesCode As String = NULL_STRING
    Public blButtonEdit As Boolean = False

    Public strVideoFilePath As String

    ' Library function to perform an image capture
    Public Declare Auto Function BitBlt Lib "gdi32.dll" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, _
                                                         ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, _
                                                         ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As System.Int32) As Boolean
    Public Const COPY As Integer = &HCC0020

    ''' <summary>
    ''' Place single quotes (') around a String
    ''' </summary>
    ''' <param name="strValue">The string to place single quotes around</param>
    ''' <returns>A single quoted String</returns>
    ''' <remarks>Used for database query string building in VideoMiner</remarks>
    Public Function SingleQuote(ByVal strValue As String) As String
        Return "'" & strValue & "'"
    End Function

    ''' <summary>
    ''' Place double quotes (") around a String
    ''' </summary>
    ''' <param name="strValue">The string to place double quotes around</param>
    ''' <returns>A double quoted String</returns>
    ''' <remarks>Used for database query string building in VideoMiner</remarks>
    Public Function DoubleQuote(ByVal strValue As String) As String
        Return """" & strValue & """"
    End Function

    ''' <summary>
    ''' Validates text entered into TextBoxes in the project
    ''' </summary>
    ''' <param name="e">System.Windows.Forms.KeyPressEventArgs</param>
    ''' <remarks>Allows only digits, period, and backspace to be used in a TextBox</remarks>
    Public Sub numericTextboxValidation(ByRef e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            ' Allow the following characters to be entered into the text box: 1,2,3,4,5,6,7,8,9,0,. and BACKSPACE
            Case "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "0"c, "."c, Convert.ToChar(8)
                e.Handled = False
                ' Dont allow the addition of other characters in the text box
            Case Else
                e.Handled = True
        End Select
    End Sub

    ''' <summary>
    ''' Change a given time into military (24 hour) time
    ''' </summary>
    ''' <param name="dtRealTime">DateTime</param>
    ''' <returns>String representing the time in 24-hour format</returns>
    ''' <remarks>If the number of milliseconds in the time is greater than 500, the seconds will be rounded up by one</remarks>
    Public Function ToMilitaryTime(ByVal dtRealTime As DateTime) As String
        Dim strTime As String
        If dtRealTime.Millisecond > 500 Then
            dtRealTime.AddSeconds(1)
        End If
        strTime = dtRealTime.ToString("hh:mm:ss")
        Dim strHour As String
        If dtRealTime.Hour <= 9 Then
            strHour = "0" & dtRealTime.Hour.ToString
        Else
            strHour = dtRealTime.Hour.ToString()
        End If
        Return strHour & strTime.Substring(2, 6)
    End Function

    ''' <summary>
    ''' Pad a string of length 1 with a zero. Used to make things like hours=0 into hours="00"
    ''' </summary>
    Public Function pad0(intValue As Integer) As String
        Dim strRep As String = CStr(intValue)
        If strRep.Length = 0 Then
            strRep = "00"
        ElseIf strRep.Length = 1 Then
            strRep = "0" & strRep
        End If
        Return strRep
    End Function

    ''' <summary>
    ''' Will raise an event across threads
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="anAction"></param>
    ''' <param name="Arg"></param>
    ''' <param name="ThrowMainFormMissingError"></param>
    ''' <remarks>Used to raise events from a side-thread to the UI thread by marshalling the call
    ''' Example:
    ''' Write a subroutine to raise the event
    ''' Protected Overridable Sub GPSConnected()
    '''    RaiseEvent GPSConnectedEvent()
    ''' End Sub
    ''' Then invoke it like this:
    '''   InvokeAction(AddressOf GPSConnected, New EventArgs())
    ''' Code from:
    ''' http://www.codeproject.com/Articles/21168/Raising-Events-from-Other-Threads
    ''' </remarks>
    Public Sub InvokeAction(Of T)(ByVal anAction As System.Action(Of T), ByVal Arg As T, Optional ByVal ThrowMainFormMissingError As Boolean = True)
        If Not ThrowMainFormMissingError AndAlso Application.OpenForms.Count = 0 Then Return
        With Application.OpenForms(0)
            If .InvokeRequired Then
                .Invoke(anAction, Arg)
            Else
                anAction(Arg)
            End If
        End With
    End Sub

End Module
