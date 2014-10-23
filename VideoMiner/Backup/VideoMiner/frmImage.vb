'==========================================================================================================
' The functions in this class corresponds to the operations in the window which displays the image
'==========================================================================================================
' ======================================Code by Xida Chen (begin)===========================================
Public Class frmImage

    Private ptPanStartPoint As New Point


    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        ptPanStartPoint = New Point(e.X, e.Y)
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then

            Dim DeltaX As Integer = (ptPanStartPoint.X - e.X)
            Dim DeltaY As Integer = (ptPanStartPoint.Y - e.Y)

            Panel1.AutoScrollPosition = New Drawing.Point((DeltaX - Panel1.AutoScrollPosition.X), (DeltaY - Panel1.AutoScrollPosition.Y))

        End If
    End Sub

    Private Sub frmImage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        myFormLibrary.frmVideoMiner.pnlImageControls.Visible = False

        'Me.PictureBox1.Image.Dispose()
        'Me.PictureBox1.Image = Nothing
        myFormLibrary.frmVideoMiner.cmdNothingInPhoto.Visible = False
        myFormLibrary.frmVideoMiner.image_open = False
        myFormLibrary.frmImage = Nothing

        Call myFormLibrary.frmVideoMiner.enableDisableImageMenu(False)

    End Sub

    Private Sub frmImage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim intIndex As Integer

        Select Case e.KeyValue
            Case Keys.F1
                intIndex = 0
            Case Keys.F2
                intIndex = 1
            Case Keys.F3
                intIndex = 2
            Case Keys.F4
                intIndex = 3
            Case Keys.F5
                intIndex = 4
            Case Keys.F6
                intIndex = 5
            Case Keys.F7
                intIndex = 6
            Case Keys.F8
                intIndex = 7
            Case Keys.F9
                intIndex = 8
            Case Keys.F10
                intIndex = 19
            Case Keys.F11
                intIndex = 10
            Case Keys.F12
                intIndex = 11
            Case Else
                Exit Sub
        End Select

        Try
            If Not myFormLibrary.frmVideoMiner.speciesButtons(intIndex) Is Nothing Then
                Call myFormLibrary.frmVideoMiner.SpeciesVariableButtonHandler(myFormLibrary.frmVideoMiner.speciesButtons(intIndex), Nothing)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean


        Dim keyPressed As Keys = CType(msg.WParam.ToInt32(), Keys)
        Dim intAnswer As Integer

        Select Case keyPressed
            Case Keys.Right
                If (myFormLibrary.frmVideoMiner.image_index + 1) > (myFormLibrary.frmVideoMiner.imageFilesList.Count - 1) Then
                    intAnswer = MessageBox.Show("You have reached the last image in the folder, would you like to start again at the first image?", "Last Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If intAnswer = vbYes Then
                        myFormLibrary.frmVideoMiner.image_index = 0
                    Else
                        Exit Function
                    End If
                Else
                    myFormLibrary.frmVideoMiner.image_index += 1
                End If
                myFormLibrary.frmVideoMiner.LoadImg()

            Case Keys.Left
                If (myFormLibrary.frmVideoMiner.image_index - 1) < 0 Then
                    intAnswer = MessageBox.Show("You have reached the first image in the folder, would you like to start again at the last image?", "First Image Reached", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If intAnswer = vbYes Then
                        myFormLibrary.frmVideoMiner.image_index = myFormLibrary.frmVideoMiner.imageFilesList.Count - 1
                    Else
                        Exit Function
                    End If
                Else
                    myFormLibrary.frmVideoMiner.image_index -= 1
                End If
                myFormLibrary.frmVideoMiner.LoadImg()

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)

        End Select
    End Function

    Private Sub frmImage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myFormLibrary.frmImage = Me
        myFormLibrary.frmVideoMiner.pnlImageControls.Visible = True
        myFormLibrary.frmVideoMiner.pnlVideoControls.Visible = False
    End Sub
End Class