Public Class Beta

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        user.Text = TrackBar1.Value & ("%")
        ProgressBar1.Value = My.Settings.finsh


        If TrackBar1.Value = 50 Then
            
        Else
            Me.BackColor = Color.White
        End If

    End Sub

    Private Sub Beta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Label1.Text = My.Settings.finsh.ToString & ("% ") & ("Current")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.finsh = TrackBar1.Value
        Label1.Text = My.Settings.finsh.ToString & ("%") & ("& Saved To System!")
        Timer2.Enabled = True


    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label1.Text = My.Settings.finsh.ToString & ("% ") & ("Current")
        Timer2.Enabled = False

    End Sub
End Class