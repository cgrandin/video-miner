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
    Public Const BUTTON_CODE As String = "ButtonCode"
    Public Const BUTTON_CODE_NAME As String = "ButtonCodeName"
    Public Const KEYBOARD_SHORTCUT As String = "KeyboardShortcut"
    Public Const USER_ENTERED As String = "UserEntered"
    Public Const DEFAULT_BUTTON_FONT As String = "Microsoft Sans Serif"
    Public Const DEFAULT_BUTTON_TEXT_SIZE As String = "10"

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
    Public strRareSpeciesCode As String = ""
    Public blButtonEdit As Boolean = False

    'Public strDatabaseFilePath As String
    Public strVideoFilePath As String

    Public blCleared As Boolean = False
    Public blRefresh As Boolean = False
    Public blNewButton As Boolean = False
    Public strUserTime As String = ""

    Public filePath As String = ""
    Public strConfigFilePath As String = ""

    Public strEditTextBoxOldName As String = ""
    Public strEditTextBoxNewName As String = ""

    Public m_PublicSerialPort As New IO.Ports.SerialPort

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
            strHour = dtRealTime.Hour
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
    ''' <remarks>Used to raise events from a side-thread to the UI thread by marshaling the call
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
