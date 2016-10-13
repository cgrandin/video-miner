''' <summary>
''' A Videominer dynamic button and textbox on a small panel.
''' When the button is pressed, a database table will be shown and the user can
''' select the row they want. Once the row is selected, the value will be shown in the Textbox.
''' The DynamicTextbox shows the current status of the variable the button
''' represents.
''' </summary>
''' <remarks></remarks>
Public Class DynamicTableButton
    Inherits ExTableLayoutPanel

    ''' <summary>
    ''' This is the multiplier for the button height, to make sure it fits the text on it.
    ''' </summary>
    Private Const BUTTON_SCALE As Double = 1.3

#Region "Member variables"
    ''' <summary>
    ''' The button used to issue a data changed event for the variable the button represents.
    ''' </summary>
    Private WithEvents m_btnButton As DynamicButton
    ''' <summary>
    ''' A textbox attached below the button which shows the current value of the variable for the button.
    ''' </summary>
    Private m_txtStatus As DynamicTextbox
    Private m_textbox_text_size As Integer

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

#Region "Properties"
    Public Property ButtonCode As String
        Get
            Return m_btnButton.ButtonCode
        End Get
        Set(value As String)
            m_btnButton.ButtonCode = value
        End Set
    End Property

    Public Property DataFormVisible As Boolean
        Set(value As Boolean)
            If m_which_type = WhichTypeEnum.DataTable Then
                m_btnButton.DataFormVisible = True
            End If
        End Set
        Get
            Return m_btnButton.DataFormVisible
        End Get
    End Property

    Public Property Dictionary As Dictionary(Of String, Tuple(Of String, String, Boolean))
        Get
            Return m_btnButton.Dictionary
        End Get
        Set(value As Dictionary(Of String, Tuple(Of String, String, Boolean)))
            m_btnButton.Dictionary = value
        End Set
    End Property

    Public ReadOnly Property DictionaryHasItems As Boolean
        Get
            Return m_btnButton.DictionaryHasItems
        End Get
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
            Return CInt(m_btnButton.Height * BUTTON_SCALE + m_txtStatus.Height)
        End Get
    End Property

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
    ''' <summary>
    ''' Fires when user presses Cancel or 'X' button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event DataEntryCanceled(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        m_textbox_text_size = CInt(row.Item(TEXTBOX_TEXT_SIZE))
        RowCount = 2
        ColumnCount = 1
        AutoScroll = False
        AutoSize = True
        AutoSizeMode = AutoSizeMode.GrowAndShrink

        m_btnButton = New DynamicButton(row, intHeight, intWidth, DynamicButton.WhichEntryStyleEnum.Table)
        AddHandler m_btnButton.StartDataEntryEvent, AddressOf startDataEntryEventHandler
        AddHandler m_btnButton.EndDataEntryEvent, AddressOf endDataEntryEventHandler
        m_btnButton.Dock = DockStyle.Fill

        m_txtStatus = New DynamicTextbox(m_btnButton.ButtonFont, CStr(m_textbox_text_size))
        m_txtStatus.Dock = DockStyle.Fill

        RowStyles.Clear()
        Dim rs As RowStyle = New RowStyle(SizeType.Absolute, CInt(m_btnButton.Height * BUTTON_SCALE))
        RowStyles.Add(rs)
        rs = New RowStyle(SizeType.Absolute, m_txtStatus.Height)
        RowStyles.Add(rs)

        Controls.Add(m_btnButton)
        Controls.Add(m_txtStatus)
        m_txtStatus.setNoData(m_btnButton.ButtonText)
        'CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset
    End Sub

    Private Sub clearEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_btnButton.ClearEvent
        m_txtStatus.setNoData(m_btnButton.ButtonText)
    End Sub
    ''' <summary>
    ''' Tell parent that data entry has started
    ''' </summary>
    Private Sub startDataEntryEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent StartDataEntryEvent(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Tell parent that data entry has ended
    ''' </summary>
    Private Sub endDataEntryEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Change text to reflect the change in the data
        m_txtStatus.setData(m_btnButton.DataDescription)
        RaiseEvent EndDataEntryEvent(Me, EventArgs.Empty)
    End Sub

    Friend Sub ShowForm(sender As Object, e As EventArgs)
        Throw New NotImplementedException()
    End Sub

    ''' <summary>
    ''' Bubbles the DataEntrytCanceledEvent up so that video can be set to play again when the user decides to cancel data entry.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dataEntryCanceledHandler(ByVal sender As Object, ByVal e As EventArgs) Handles m_btnButton.DataEntryCanceled
        RaiseEvent DataEntryCanceled(Me, EventArgs.Empty)
    End Sub

End Class
