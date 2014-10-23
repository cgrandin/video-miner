Imports Microsoft.Win32
Public Class Point

#Region "Fields"
    Private m_X As Double = 0.0
    Private m_Y As Double = 0.0
    Private m_Z As Double = 0.0
    Private m_GpsTime As String = ""
    Private m_GpsUserTime As String = ""
    Private m_GpsDate As String = ""
    Private m_NMEA As String
#End Region

#Region "Constructor"
    Public Sub New(Optional ByVal dblX As Double = 0, Optional ByVal dblY As Double = 0)
        m_X = dblX
        m_Y = dblY
    End Sub
#End Region

#Region "Properties"

    Public Property X() As Double
        Get
            Return m_X
        End Get
        Set(ByVal value As Double)
            m_X = value
        End Set
    End Property

    Public Property Y() As Double
        Get
            Return m_Y
        End Get
        Set(ByVal value As Double)
            m_Y = value
        End Set
    End Property

    Public Property Z() As Double
        Get
            Return m_Z
        End Get
        Set(ByVal value As Double)
            m_Z = value
        End Set
    End Property

    Public Property GpsDateTime() As String
        Get
            Return m_GpsTime
        End Get
        Set(ByVal value As String)
            m_GpsTime = value
        End Set
    End Property

    Public Property GpsDate() As String
        Get
            Return m_GpsDate
        End Get
        Set(ByVal value As String)
            m_GpsDate = value
        End Set
    End Property

    Public Property GpsUserTime() As String
        Get
            Return m_GpsUserTime
        End Get
        Set(ByVal value As String)
            m_GpsUserTime = value
        End Set
    End Property

    Public Property NMEA() As String
        Get
            Return m_NMEA
        End Get
        Set(ByVal value As String)
            m_NMEA = value
        End Set
    End Property

#End Region

#Region "Methods"

    ' Method to get a point location from a NMEA string
    Public Function GetPoint() As Boolean
        Dim booAquiredFix As Boolean = False

        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.CreateSubKey("Software\VideoMiner")
        Dim strGPSStringType As String = ""
        strGPSStringType = regKey.GetValue("GPSStringType")
        If NMEA <> "" Then
            ' Split the NMEA string into readable segments
            Dim arrSentence() As String
            arrSentence = Split(NMEA, "$")

            ' if there isnt any data then make the point equal to zero
            If UBound(arrSentence) < 0 Then
                X = 0.0
                Y = 0.0
            End If

            Dim arrValues() As String
            Dim i As Integer

            ' Cycle through the the string array
            For i = 0 To UBound(arrSentence)
                arrValues = Split(arrSentence(i), ",")

                ' If the segment is titled GPGGA
                If Trim(UCase(arrValues(0).ToString)) = "GPGGA" Then

                    ' If there is no locational data then make the point equal to zero
                    If Trim(arrValues(2).ToString = "" Or Trim(arrValues(4).ToString = "")) Then
                        X = 0.0
                        Y = 0.0
                    Else    ' Pull out all raw locational data
                        Dim dblRawLat As Double
                        dblRawLat = CType(arrValues(2), Double)
                        'rawY = dblRawLat

                        Dim dblRawLon As Double
                        dblRawLon = CType(arrValues(4), Double)
                        'RawX = dblRawLon

                        If dblRawLat.ToString.Length > 0 Then

                            ' Convert raw data to decimal degrees
                            X = dm2dd(dblRawLon)
                            Y = dm2dd(dblRawLat)
                            booAquiredFix = True
                        Else
                            X = 0.0
                            Y = 0.0
                        End If
                        Dim dblElevation As Double = 0.0
                        Try
                            dblElevation = CType(arrValues(9), Double) ' In Meters.
                            If dblElevation.ToString.Length > 0 Then
                                Z = dblElevation
                            Else
                                Z = 0.0
                            End If
                        Catch ex As Exception

                        End Try

                        myFormLibrary.frmVideoMiner.GPS_X = X
                        myFormLibrary.frmVideoMiner.GPS_Y = Y
                        myFormLibrary.frmVideoMiner.GPS_Z = Z
                        Dim intHours As Integer = 0
                        intHours = CType(Mid(arrValues(1), 1, 2), Integer)
                        Dim strHours As String
                        If intHours <= 9 Then
                            strHours = "0" & intHours.ToString
                        Else
                            strHours = intHours.ToString
                        End If

                        Dim intMinutes As Integer = 0
                        intMinutes = CType(Mid(arrValues(1), 3, 2), Integer)
                        Dim strMinutes As String
                        If intMinutes <= 9 Then
                            strMinutes = "0" & intMinutes.ToString
                        Else
                            strMinutes = intMinutes.ToString
                        End If

                        Dim intSeconds As Integer
                        intSeconds = CType(Mid(arrValues(1), 5, 2), Integer)
                        Dim strSeconds As String
                        If intSeconds <= 9 Then
                            strSeconds = "0" & intSeconds.ToString
                        Else
                            strSeconds = intSeconds.ToString
                        End If

                        myFormLibrary.frmVideoMiner.GPSUserTime = strHours & strMinutes & strSeconds & "00"
                        myFormLibrary.frmVideoMiner.GPSDateTime = strHours & ":" & strMinutes & ":" & strSeconds
                    End If
                End If
                If Trim(UCase(arrValues(0).ToString)) = "GPRMC" Then
                    Dim intDays As Integer = 0
                    Dim strDays As String = ""
                    Dim intMonths As Integer = 0
                    Dim strMonths As String = ""
                    Dim intYears As Integer = 0
                    Dim strYears As String = ""
                    Try

                        intDays = CType(Mid(arrValues(9), 1, 2), Integer)
                        If intDays <= 9 Then
                            strDays = "0" & intDays.ToString
                        Else
                            strDays = intDays.ToString
                        End If
                    Catch
                    End Try

                    Try

                        intMonths = CType(Mid(arrValues(9), 3, 2), Integer)

                        If intMonths <= 9 Then
                            strMonths = "0" & intMonths.ToString
                        Else
                            strMonths = intMonths.ToString
                        End If
                    Catch
                    End Try

                    Try

                        intYears = CType(Mid(arrValues(9), 5, 2), Integer)

                        If intYears <= 9 Then
                            strYears = "200" & intYears.ToString
                        Else
                            strYears = "20" & intYears.ToString
                        End If

                    Catch
                    End Try
                    If strDays <> "" And strMonths <> "" And strYears <> "" Then
                        myFormLibrary.frmVideoMiner.GPSDate = strDays & "/" & strMonths & "/" & strYears
                    End If
                End If
            Next
        End If
        Return booAquiredFix
        'Try
        '    Dim booAquiredFix As Boolean = False

        '    Dim regKey As RegistryKey
        '    regKey = Registry.CurrentUser.CreateSubKey("Software\VideoMiner")
        '    Dim strGPSStringType As String = ""
        '    strGPSStringType = regKey.GetValue("GPSStringType")
        '    If NMEA = "" Then
        '        X = 0.0
        '        Y = 0.0
        '        Return booAquiredFix
        '    End If
        '    ' Split the NMEA string into readable segments
        '    Dim arrSentence() As String
        '    arrSentence = Split(NMEA, "$")

        '    ' if there isnt any data then make the point equal to zero
        '    If UBound(arrSentence) < 0 Then
        '        X = 0.0
        '        Y = 0.0
        '        Return booAquiredFix
        '    End If

        '    Dim arrValues() As String
        '    Dim i As Integer

        '    ' Cycle through the the string array
        '    For i = 0 To UBound(arrSentence)
        '        arrValues = Split(arrSentence(i), ",")

        '        If UBound(arrValues) <> 0 Then
        '            ' If the segment is titled GPGGA
        '            If Trim(UCase(arrValues(0).ToString)) = "GPGGA" Then

        '                ' If there is no locational data then make the point equal to zero
        '                If Trim(arrValues(2).ToString = "" Or Trim(arrValues(4).ToString = "")) Then
        '                    X = 0.0
        '                    Y = 0.0
        '                Else    ' Pull out all raw locational data
        '                    Dim dblRawLat As Double
        '                    dblRawLat = CType(arrValues(2), Double)
        '                    'rawY = dblRawLat

        '                    Dim dblRawLon As Double
        '                    dblRawLon = CType(arrValues(4), Double)
        '                    'RawX = dblRawLon
        '                    If dblRawLat.ToString.Length > 0 Then

        '                        ' Convert raw data to decimal degrees
        '                        X = dm2dd(dblRawLon)
        '                        Y = dm2dd(dblRawLat)
        '                        booAquiredFix = True
        '                    Else
        '                        X = 0.0
        '                        Y = 0.0
        '                    End If
        '                    Dim dblElevation As Double = 0.0
        '                    Try
        '                        dblElevation = CType(arrValues(9), Double) ' In Meters.
        '                        If dblElevation.ToString.Length > 0 Then
        '                            Z = dblElevation
        '                        Else
        '                            Z = 0.0
        '                        End If
        '                    Catch ex As Exception

        '                    End Try

        '                    myFormLibrary.frmVideoMiner.GPS_X = X
        '                    myFormLibrary.frmVideoMiner.GPS_Y = Y
        '                    myFormLibrary.frmVideoMiner.GPS_Z = Z

        '                    Dim intHours As Integer = 0
        '                    intHours = CType(Mid(arrValues(1), 1, 2), Integer)
        '                    Dim strHours As String
        '                    If intHours <= 9 Then
        '                        strHours = "0" & intHours.ToString
        '                    Else
        '                        strHours = intHours.ToString
        '                    End If

        '                    Dim intMinutes As Integer = 0
        '                    intMinutes = CType(Mid(arrValues(1), 3, 2), Integer)
        '                    Dim strMinutes As String
        '                    If intMinutes <= 9 Then
        '                        strMinutes = "0" & intMinutes.ToString
        '                    Else
        '                        strMinutes = intMinutes.ToString
        '                    End If

        '                    Dim intSeconds As Integer
        '                    intSeconds = CType(Mid(arrValues(1), 5, 2), Integer)
        '                    Dim strSeconds As String
        '                    If intSeconds <= 9 Then
        '                        strSeconds = "0" & intSeconds.ToString
        '                    Else
        '                        strSeconds = intSeconds.ToString
        '                    End If

        '                    myFormLibrary.frmVideoMiner.GPSUserTime = strHours & strMinutes & strSeconds & "00"
        '                    myFormLibrary.frmVideoMiner.GPSDateTime = strHours & ":" & strMinutes & ":" & strSeconds
        '                End If
        '            End If

        '            If Trim(UCase(arrValues(0).ToString)) = "GPRMC" Then
        '                Dim intDays As Integer = 0
        '                Dim strDays As String = ""
        '                Dim intMonths As Integer = 0
        '                Dim strMonths As String = ""
        '                Dim intYears As Integer = 0
        '                Dim strYears As String = ""
        '                Try

        '                    intDays = CType(Mid(arrValues(9), 1, 2), Integer)
        '                    If intDays <= 9 Then
        '                        strDays = "0" & intDays.ToString
        '                    Else
        '                        strDays = intDays.ToString
        '                    End If
        '                Catch
        '                End Try

        '                Try

        '                    intMonths = CType(Mid(arrValues(9), 3, 2), Integer)

        '                    If intMonths <= 9 Then
        '                        strMonths = "0" & intMonths.ToString
        '                    Else
        '                        strMonths = intMonths.ToString
        '                    End If
        '                Catch
        '                End Try

        '                Try

        '                    intYears = CType(Mid(arrValues(9), 5, 2), Integer)

        '                    If intYears <= 9 Then
        '                        strYears = "200" & intYears.ToString
        '                    Else
        '                        strYears = "20" & intYears.ToString
        '                    End If

        '                Catch
        '                End Try
        '                myFormLibrary.frmVideoMiner.GPSDate = strDays & "/" & strMonths & "/" & strYears
        '            End If
        '        End If
        '    Next

        '    Return booAquiredFix
        'Catch ex As Exception
        '    Dim st As New StackTrace(ex, True)
        '    Dim frame As StackFrame
        '    frame = st.GetFrame(0)
        '    Dim line As Integer
        '    line = frame.GetFileLineNumber
        '    MsgBox("At line " & line & " " & ex.Message & " Stack trace: " & st.ToString)
        'End Try
    End Function


    Private Function dm2dd(ByVal dblCoordinate As Double) As Double

        Try
            Dim aPos As Integer

            If dblCoordinate Mod 1 = 0 Then
                aPos = InStr(1, dblCoordinate.ToString & ".0", ".", vbTextCompare)
            Else
                aPos = InStr(1, dblCoordinate.ToString, ".", vbTextCompare)
            End If

            Dim strDeg As String
            strDeg = Mid(dblCoordinate.ToString, 1, aPos - 1)

            Dim intDeg As Integer
            intDeg = Math.Floor(CType(strDeg, Integer) / 100)

            Dim strMin As String
            strMin = Mid(dblCoordinate.ToString, aPos - 2, Len(dblCoordinate.ToString))

            Dim intMin As Double
            intMin = CType(strMin, Double) / 60

            Dim tmp As Double
            tmp = intDeg + intMin

            Return tmp
        Catch ex As Exception
        End Try
    End Function

#End Region

End Class
