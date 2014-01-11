Imports MySql.Data.MySqlClient

Public Class Main

#Region "Beta Tool ToolStrip Menu"
    Private Sub BetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BetaToolStripMenuItem.Click
        'Show Beta From To EUser
        Beta.Show()
    End Sub
#End Region

#Region "When Main Form Opens Do What?"
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'search text box and button modify
        searchtb.Text = ("Search").ToString
        searchtb.ReadOnly = True
        'end test box & button modify

        'Timer for complete bar "bottom of gui"
        Timer1.Enabled = True
        ''end Timer Complete

        loadInventoryTable()

        actionCombo.SelectedItem = "Update"
    End Sub
#End Region

#Region "Timer For Complete Bar Main Form"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If My.Settings.finsh <= 49 Then
            Panel1.BackColor = Color.Red
        ElseIf My.Settings.finsh <= 74 Then
            Panel1.BackColor = Color.Yellow
        ElseIf My.Settings.finsh <= 99 Then
            Panel1.BackColor = Color.Green
        End If

        Label1.Text = ("Program is ") & My.Settings.finsh & ("% Complete!")
        ProgressBar1.Value = My.Settings.finsh

    End Sub
#End Region


#Region "If Form Closing Do What?"
    Private Sub Main_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'When form closing show login screen
        login.Show()
        'when form closed focus on login screen
        login.Focus()
    End Sub 'Main_Closing
#End Region

#Region "Search box click event"
    Private Sub searchtb_Click(sender As Object, e As EventArgs) Handles searchtb.Click

        If searchtb.Text = ("Search").ToString Then
            searchtb.Text = ("").ToString
            searchtb.ReadOnly = False
        End If

    End Sub
#End Region

#Region "DataGrid Interaction"

    Private Sub refreshButton_Click(sender As Object, e As EventArgs) Handles refreshButton.Click
        loadInventoryTable()
        clearAll()
    End Sub

    Private Sub searchbtn_Click(sender As Object, e As EventArgs) Handles searchbtn.Click
        If searchtb.Text = Nothing Or searchbtn.Text = "Search" Then
            MsgBox("Please choose a type of item.")
        Else
            retrieveDataToDataGrid(searchtb.Text)
        End If
    End Sub

    Private Sub searchtb_KeyDown(sender As Object, e As KeyEventArgs) Handles searchtb.KeyDown
        If e.KeyCode = Keys.Enter Then
            If searchtb.Text = Nothing Then
                MsgBox("Please choose a type of item.")
            Else
                retrieveDataToDataGrid(searchtb.Text)
            End If
        End If
    End Sub

    Private Sub textBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            checkForEmptiness()
        End If
    End Sub

    Private Sub textBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            checkForEmptiness()
        End If
    End Sub

    Private Sub textBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            checkForEmptiness()
        End If
    End Sub

    Private Sub textBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            checkForEmptiness()
        End If
    End Sub

    Private Sub output_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        populateTextBoxes(e)
    End Sub

    Private Sub actionCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles actionCombo.SelectedIndexChanged
        clearAll()
    End Sub

    Private Sub enterButton_Click(sender As Object, e As EventArgs) Handles enterButton.Click
        checkForEmptiness()
    End Sub

#End Region

    Private Sub ServerSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServerSettingsToolStripMenuItem.Click
        ServerSettings.Show()

    End Sub
End Class