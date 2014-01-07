Public Class login

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        username.Text = ("DEMO")
        username.Enabled = False
        Timer1.Enabled = True
        Timer2.Enabled = True


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If userpassword.Text = Nothing Then
            MessageBox.Show("Password is Wrong or Blank")

        ElseIf userpassword.Text = My.Settings.password Then
            Main.Show()
            Me.Hide()
        Else
            MessageBox.Show("Password is Wrong or Blank")
        End If
        userpassword.Text = ("")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        userpassword.Text = ("")
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ''Test timer if 
        If ProgressBar1.Value <= 99 Then
            ProgressBar1.Value = ProgressBar1.Value + 1
        ElseIf ProgressBar1.Value = 100 Then
            ProgressBar1.Value = 100
            Timer2.Enabled = False
        End If

        If ProgressBar2.Value <= 99 Then
            ProgressBar2.Value = ProgressBar1.Value + 1
        ElseIf ProgressBar2.Value = 100 Then
            ProgressBar2.Value = 100
            Timer2.Enabled = False
        End If

        If ProgressBar3.Value <= 99 Then
            ProgressBar3.Value = ProgressBar1.Value + 1
        ElseIf ProgressBar3.Value = 100 Then
            ProgressBar3.Value = 100
            Timer2.Enabled = False
        End If
        ''output prot text
        port80.Text = ("Port : 80  ") & ProgressBar1.Value & ("%")
        port3306.Text = ("Port : 3306  ") & ProgressBar1.Value & ("%")
        port8080.Text = ("Port : 8080  ") & ProgressBar1.Value & ("%")


      




    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        PasswordVer.Show()

    End Sub
End Class
