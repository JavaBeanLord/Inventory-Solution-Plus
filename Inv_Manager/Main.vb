Public Class Main

    Private Sub BetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BetaToolStripMenuItem.Click
        Beta.Show()

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True




    End Sub

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


    Private Sub Main_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        login.Show()
        login.Focus()


    End Sub 'Main_Closing


End Class