''' <summary>
''' A Videominer dynamic table button and textbox on a small panel.
''' When the button is pressed, a database table will be shown and the user can
''' select the row they want. Once the row is selected, the value will be shown in the Textbox.
''' The DynamicTextbox shows the current status of the variable the button
''' represents.
''' </summary>
''' <remarks></remarks>
Public Class DynamicTableButton
    Inherits SplitContainer

#Region "Member variables"
    ''' <summary>
    ''' The button used to issue a data changed event for the variable the button represents.
    ''' </summary>
    Private m_btnButton As DynamicButton
    ''' <summary>
    ''' A textbox attached below the button which shows the current value of the variable for the button.
    ''' </summary>
    Private m_txtStatus As DynamicTextbox
    ''' <summary>
    ''' The form showing the data table requested.
    ''' </summary>
    Private WithEvents m_frmTableView As frmTableView

    ''' <summary>
    ''' Distinguishes between the two types of data this button can represent, database table
    ''' data (lookup tables stored as type DataTable) or UserEntered which are not a DataTable
    ''' and are entered via a form such as Field Of View.
    ''' </summary>
    Public Enum WhichTypeEnum
        DataTable
        UserEntered
    End Enum
    ''' <summary>
    ''' Holds the enumeration type for this instance
    ''' </summary>
    Private m_which_type As WhichTypeEnum
#End Region

#Region "Events"
    ''' <summary>
    ''' This event will be fired when the user clicks the button.
    ''' </summary>
    Public Event StartDataEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' This event will propagate an event sent by either m_frmSpeciesEvent, m_frmAbundanceTableView, or m_frmTableView.
    ''' It is sent to signal the end of the data entry, i.e. when the subforms mentioned are closed.
    ''' </summary>
    Public Event EndDataEntryEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
#End Region

#Region "Properties"
    Public Property ButtonCode As String
        Get
            Return m_btnButton.ButtonCode
        End Get
        Set(value As String)
            m_btnButton.ButtonCode = value
        End Set
    End Property
    ''' <summary>
    ''' Data code used for table-based data. e.g. table lu_survey_mode is associated with data code 9 in the lu_data_codes table
    ''' </summary>
    Public Property DataCode As Integer
        Get
            Return m_btnButton.DataCode
        End Get
        Set(value As Integer)
            m_btnButton.DataCode = value
        End Set
    End Property
    Public Property DataCodeName As String
        Get
            Return m_btnButton.DataCodeName
        End Get
        Set(value As String)
            m_btnButton.DataCodeName = value
        End Set
    End Property
    Public Property DataValue As String
        Get
            Return m_btnButton.DataValue
        End Get
        Set(value As String)
            m_btnButton.DataValue = value
        End Set
    End Property
    Public Property DataComment As String
        Get
            Return m_btnButton.DataComment
        End Get
        Set(value As String)
            m_btnButton.DataComment = value
        End Set
    End Property
    Public Property Dictionary As Dictionary(Of String, Tuple(Of String, String, Boolean))
        Get
            Return m_btnButton.Dictionary
        End Get
        Set(value As Dictionary(Of String, Tuple(Of String, String, Boolean)))
            m_btnButton.Dictionary = value
        End Set
    End Property

    ''' <summary>
    ''' Width of the control
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ControlWidth As Integer
        Get
            Return ClientSize.Width
        End Get
    End Property
    ''' <summary>
    ''' Height of the control, including button and textbox
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ControlHeight As Integer
        Get
            Return ClientSize.Height
        End Get
    End Property

#End Region
    ''' <summary>
    ''' Creates the button, for the case in which the button refers to a database code table.
    ''' </summary>
    ''' <param name="row">A DataRow object holding a row of data used to initialize the button</param>
    ''' <param name="whichType">Used to signify the difference between database-table based forms or a user form.</param>
    ''' <remarks></remarks>
    Public Sub New(row As DataRow,
                   intHeight As Integer,
                   intWidth As Integer,
                   Optional whichType As WhichTypeEnum = WhichTypeEnum.DataTable)
        m_which_type = whichType
        m_btnButton = New DynamicButton(row, intHeight, intWidth, DynamicButton.WhichEntryStyleEnum.Table)
        m_txtStatus = New DynamicTextbox(m_btnButton.ButtonFont, m_btnButton.ButtonTextSize)
        Me.Orientation = Orientation.Horizontal
        Panel1.Controls.Add(m_btnButton)
        Panel2.Controls.Add(m_txtStatus)
        m_btnButton.Dock = DockStyle.Fill
        m_txtStatus.Dock = DockStyle.Fill
        m_txtStatus.Text = m_btnButton.ButtonText
    End Sub

    ''' <summary>
    ''' Handle the clearing of the data field in the table by resetting the DataCode and DataComment to Nothing and
    ''' firing an event to signal the parent.
    ''' </summary>
    Private Sub clearData() Handles m_frmTableView.ClearEvent
        If Not IsNothing(m_frmTableView) Then
            m_frmTableView.clearSelection()
        End If
        'RaiseEvent DataChanged(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Show the associated data table form for this button.
    ''' </summary>
    Public Sub ShowForm(sender As Object, e As EventArgs)
        If My.Computer.Keyboard.CtrlKeyDown Then
            clearData()
            Exit Sub
        Else
            'Me.DataFormVisible = True
        End If

        ' Raise an event to signal the beginning of the process of filling in a form which will be recorded to the database.
        ' For example, when the user presses a species button it will bring up the form needed to fill in the information for the species.
        ' The video needs to be paused at this point, and restarted when the user presses OK on the form which is being worked on
        'RaiseEvent SignalVideoPause(Me, e)
    End Sub

    ''' <summary>
    ''' Bubbles the EndDataEntryEvent up.
    ''' </summary>
    Private Sub endDataEntryEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_frmTableView.EndDataEntryEvent
        Dictionary = m_frmTableView.Dictionary
        RaiseEvent EndDataEntryEvent(Me, EventArgs.Empty)
    End Sub

End Class
