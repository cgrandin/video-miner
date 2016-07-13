Imports System.TimeSpan
Imports System.Text.RegularExpressions

Public Class frmSetTime

    ''' <summary>
    ''' Used to keep track of which time the m_tsUserTime variable is set to
    ''' </summary>
    Public Enum WhichTimeEnum
        Manual
        Video
        Computer
        GPS
        Cont
    End Enum

    ''' <summary>
    ''' Keeps track of which time the m_tsUserTime variabel is set to
    ''' </summary>
    Private m_enumWhichTime As WhichTimeEnum

    ''' <summary>
    ''' Stores the Timespan object representing the user time
    ''' </summary>
    Private m_tsUserTime As TimeSpan

    ''' <summary>
    ''' One of the WhichTimeEnum enumeration values, representing which type of time is currently in use
    ''' </summary>
    Public Property WhichTime As WhichTimeEnum
        Get
            Return m_enumWhichTime
        End Get
        Set(value As WhichTimeEnum)
            m_enumWhichTime = value
        End Set
    End Property

    ''' <summary>
    ''' UserTime is a TimeSpan property representing the user time
    ''' </summary>
    Public Property UserTime As TimeSpan
        Get
            Return m_tsUserTime
        End Get
        Set(value As TimeSpan)
            m_tsUserTime = value
            setTextTime()
        End Set
    End Property

    ''' <summary>
    ''' The Timesource in use, one of the values in the WhichTimeEnum enumerationm
    ''' </summary> 
    Public Property TimeSource As WhichTimeEnum
        Get
            Return m_enumWhichTime
        End Get
        Set(value As WhichTimeEnum)
            ChangeSource(value)
        End Set
    End Property

    ''' <summary>
    ''' When the user clicks the 'OK' button this event is raised
    ''' </summary>
    Event TimeChanged()
    ''' <summary>
    ''' Signal that the user has requested a time source change, eg. from COMPUTER to GPS
    ''' </summary>
    Event TimeSourceChange()
    ''' <summary>
    ''' When the user clicks the 'GPS Time' radiobutton this event is raised
    ''' </summary>
    Event RequestGPSTime()
    ''' <summary>
    ''' When the user clicks the 'Continue from Last Clip' radiobutton this event is raised
    ''' </summary>
    Event RequestContinueTime()
    ''' <summary>
    ''' Fires when user presses Cancel or 'X' button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event DataEntryCanceled(ByVal sender As System.Object, ByVal e As System.EventArgs)


    ''' <summary>
    ''' Default constructor
    ''' </summary>
    ''' <remarks>Sets the UserTime property to TimeSpan.Zero</remarks>
    Public Sub New()
        InitializeComponent()
        m_tsUserTime = Zero
        TopLevel = True
    End Sub

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="tsUserTime">Sets the UserTime property in the constructor to tsUserTime</param>
    Public Sub New(tsUserTime As TimeSpan)
        InitializeComponent()
        m_tsUserTime = tsUserTime
        TopLevel = True
    End Sub

    ''' <summary>
    ''' Load the form, set the time textbox up to show the current user time.
    ''' </summary>
    Private Sub frmSetTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbVideoTime.Checked = True
        m_enumWhichTime = WhichTimeEnum.Video
        ChangeSource(m_enumWhichTime)
    End Sub

    ''' <summary>
    ''' Handles when the user clicks the 'OK' button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        processOK()
    End Sub

    ''' <summary>
    ''' Change the time source type. Also set the textbox background, font, and value
    ''' </summary>
    Public Sub ChangeSource(enumWhichSource As WhichTimeEnum)
        m_enumWhichTime = enumWhichSource
        If m_enumWhichTime = WhichTimeEnum.Manual Then
            m_tsUserTime = Zero
            txtSetTime.Enabled = True
            txtSetTime.Text = ""
            txtSetTime.WaterMarkText = "HHMMSSmm"
        End If
        If m_enumWhichTime = WhichTimeEnum.Video Then
            m_tsUserTime = Zero
            txtSetTime.Enabled = False
            setTextTime()
        End If
        If m_enumWhichTime = WhichTimeEnum.Computer Then
            Dim dtNow As DateTime = Now
            m_tsUserTime = New TimeSpan(Now.Ticks)
            txtSetTime.Enabled = False
            setTextTime()
        End If
        If m_enumWhichTime = WhichTimeEnum.GPS Then
            ' Tell calling form to populate the text field
            txtSetTime.Enabled = False
            setTextTime()
        End If
        If m_enumWhichTime = WhichTimeEnum.Cont Then
            ' Tell calling form to populate the text field
            txtSetTime.Enabled = False
        End If
        Me.Refresh()
    End Sub

    ''' <summary>
    ''' Set the text in the Time TextBox to be the hours, minutes, seconds, and milliseconds (rounded to 2 decimal places) of the current time
    ''' </summary>
    Private Sub setTextTime()
        Dim ms As Double = CDbl(m_tsUserTime.Milliseconds) / 1000.0
        Dim msRound As Integer = Math.Round(ms * 100.0, 2)
        txtSetTime.Text = pad0(m_tsUserTime.Hours) & pad0(m_tsUserTime.Minutes) & pad0(m_tsUserTime.Seconds) & pad0(msRound)
    End Sub

    ''' <summary>
    ''' Stores the text time as written in the TextBox into a member variable stored as a Timespan object.
    ''' </summary>
    Private Sub getTextTime()
        m_tsUserTime = New TimeSpan(0, CInt(Strings.Left(txtSetTime.Text, 2)), CInt(Strings.Mid(txtSetTime.Text, 3, 2)), CInt(Strings.Mid(txtSetTime.Text, 5, 2)), CInt(Strings.Mid(txtSetTime.Text, 7, 2)))
    End Sub

    ''' <summary>
    ''' Handle the click of the radiobutton to allow the user to manually set the time
    ''' </summary>
    Private Sub rbManualTime_Click(sender As Object, e As EventArgs) Handles rbManualTime.Click
        ChangeSource(WhichTimeEnum.Manual)
    End Sub

    ''' <summary>
    ''' Handle the click of the button to set the time to zero
    ''' </summary>
    Private Sub rbVideoTime_Click(sender As Object, e As EventArgs) Handles rbVideoTime.Click
        ChangeSource(WhichTimeEnum.Video)
    End Sub

    ''' <summary>
    ''' Handle the click of the button to set the time to the current time on this computer
    ''' </summary>
    Private Sub rbComputerTime_Click(sender As Object, e As EventArgs) Handles rbComputerTime.Click
        ChangeSource(WhichTimeEnum.Computer)
    End Sub

    ''' <summary>
    ''' Handle the click of the button to set the time to the GPS connection's time
    ''' </summary>
    Private Sub rbGPSTime_Click(sender As Object, e As EventArgs) Handles rbGPSTime.Click
        RaiseEvent RequestGPSTime()
    End Sub

    ''' <summary>
    ''' Handle the click of the button to set the time to the GPS connection's time
    ''' </summary>
    Private Sub rbContinueTime_Click(sender As Object, e As EventArgs) Handles rbContinueTime.Click
        RaiseEvent RequestContinueTime()
    End Sub

    ''' <summary>
    ''' Check the user input to make sure it is a valid time. Returns True if valid, False otherwise
    ''' </summary>
    Private Function validateTimeEntry() As Boolean
        Dim c As Char() = txtSetTime.Text.ToCharArray()
        If Not Regex.IsMatch(txtSetTime.Text, "^[0-9]+$") Or c.Length <> 8 Then
            MessageBox.Show("Error in time entry. You must use exactly 8 digits, leading zeroes are required. No other characters are allowed.", "Time Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        ' At this point, we know that it is a string of 8 digits. Now to make sure it is a real time
        ' Convert the char array to an array of integers
        Dim i() As Integer = Array.ConvertAll(c, Function(x) Int32.Parse(x))
        If i(0) > 2 Then
            MessageBox.Show("Error in time entry. The first hours digit must not exceed 2. You entered " & i(0) & ".", "Time Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If i(0) = 2 Then
            If i(1) > 3 Then
                MessageBox.Show("Error in time entry. When the first hours digit is 2, the second hours digit must not exceed 3. You entered " & i(1) & ".", "Time Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If
        If i(2) > 5 Then
            MessageBox.Show("Error in time entry. The first minutes digit must not exceed 5. You entered " & i(2) & ".", "Time Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If i(4) > 5 Then
            MessageBox.Show("Error in time entry. The first seconds digit must not exceed 5. You entered " & i(4) & ".", "Time Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Processes a click of the OK button or when the Enter key is pressed. Verifies that the time in the textbox it of correct format and if so, Raises the TimeChanged Event before hiding the form.
    ''' </summary>
    Private Sub processOK()
        If m_enumWhichTime = WhichTimeEnum.Manual Then
            If validateTimeEntry() Then
                ' Store the TextBox time into private member variable
                getTextTime()
                RaiseEvent TimeChanged()
                RaiseEvent DataEntryCanceled(Me, EventArgs.Empty)
                Hide()
            End If
        Else
            getTextTime()
            RaiseEvent TimeChanged()
            RaiseEvent DataEntryCanceled(Me, EventArgs.Empty)
            Hide()
        End If
    End Sub

    Private Sub frmSetTime_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            processOK()
            e.Handled = True
        End If
    End Sub

End Class
