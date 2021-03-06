﻿Imports System.Data.OleDb

Public Class frmAbundanceTableView

    Private blCanceled As Boolean
    Public Property Canceled() As Boolean
        Get
            Return blCanceled
        End Get
        Set(ByVal value As Boolean)
            blCanceled = value
        End Set
    End Property



    Private table_name As String
    Private sub_data_set As DataSet
    Private query As String
    Private sub_db_command
    Private sub_data_adapter As OleDbDataAdapter
    Private sub_data_binding As BindingSource
    Private sub_data_command_builder As OleDbCommandBuilder
    Private m_Multiple As Boolean
    Private m_UserClosedForm As Boolean = False
    Private strSelectedButtonName As String = ""


    Private Sub TableViewForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        myFormLibrary.frmAbundanceTableView = Nothing
    End Sub


    Private Sub TableViewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        myFormLibrary.frmAbundanceTableView = Me

        table_name = "lu_acfor_scale"

        'If Me.m_Multiple Then
        Me.cmdCancel.Visible = True
        'End If
        sub_data_set = New DataSet()
        query = "select * from " & table_name & ";"
        sub_db_command = New OleDbCommand(query, conn)
        sub_data_adapter = New OleDbDataAdapter(sub_db_command)
        sub_data_binding = New BindingSource()
        sub_data_command_builder = New OleDbCommandBuilder(sub_data_adapter)
        sub_data_adapter.Fill(sub_data_set, table_name)
        sub_data_binding.DataSource = sub_data_set.Tables(table_name)
        grdAbundance.DataSource = sub_data_binding

        Me.Width = grdAbundance.Width
        Me.Height = (grdAbundance.RowCount + 5) * grdAbundance.Rows(0).Height

        'Me.txtCommentBox.Text = VideoMiner.strComment

        Refresh()

    End Sub

    Private Sub grdAbundance_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdAbundance.CellBeginEdit
        'e.Cancel = True
        'MsgBox("This table is read only. Select a row to make your choice", MsgBoxStyle.Information, "Read only")
    End Sub

    Private Sub grdAbundance_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAbundance.CellEndEdit
        update_database()
    End Sub

    Private Sub grdAbundance_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAbundance.SelectionChanged
        If grdAbundance.SelectedRows.Count = 1 Then
            If Me.txtCommentBox.Text = "Comment" Then
                Me.txtCommentBox.Text = ""
            End If
            Me.Canceled = False
            Me.Hide()
        End If
    End Sub

    Private Sub update_database()
        'update the database
        sub_data_binding.EndEdit()
        Dim comm_builder As OleDbCommandBuilder = New OleDbCommandBuilder(sub_data_adapter)
        Try
            sub_data_adapter.Update(sub_data_set, table_name)
            sub_data_set.AcceptChanges()
        Catch ex As Exception
            MsgBox("The value you entered would result in a key violation in the database table '" & table_name & "'" & vbCrLf & _
            "and therefore no changes were made to the database.", MsgBoxStyle.Exclamation, "Key Violation")
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Canceled = True
        Me.Hide()
    End Sub

    Private Sub cmdComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdComment.Click

        If Me.cmdComment.Text = "Edit Comment" Then
            txtCommentBox.Enabled = True
            Me.cmdCancel.Enabled = False
            Me.grdAbundance.Enabled = False
            Me.grdAbundance.DefaultCellStyle.ForeColor = Color.Gray
            Me.cmdComment.Text = "Done"
        Else
            txtCommentBox.Enabled = False
            Me.cmdCancel.Enabled = True
            Me.grdAbundance.Enabled = True
            Me.grdAbundance.DefaultCellStyle.ForeColor = Color.Black
            Me.cmdComment.Text = "Edit Comment"
            myFormLibrary.frmVideoMiner.strComment = Me.txtCommentBox.Text
        End If

    End Sub

End Class