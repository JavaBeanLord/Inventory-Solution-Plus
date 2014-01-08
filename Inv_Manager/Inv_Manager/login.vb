Public Class login


#Region "When form loads do what?"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'auto fill username box with data
        username.Text = ("DEMO")
        'disable username box / so user can not edit
        username.Enabled = False

        'start timers "to learn what they do see below"
        Timer1.Enabled = True
        Timer2.Enabled = True
        tri.Enabled = True

        'load try me counter with last saved time. 90 try me count
        Label4.Text = My.Settings.tryme



        ''reset password to password for testing only.
        ' My.Settings.password = ("password")


    End Sub
#End Region



#Region "Submit username & password to Server"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ''if password nothing show message box user error
        If userpassword.Text = Nothing Then
            MessageBox.Show("Password is Wrong or Blank")
            'if password is in database :settings for now" then display program
        ElseIf userpassword.Text = My.Settings.password Then
            Main.Show()
            Me.Hide()
        Else
            ''if password wrong show message box user error
            MessageBox.Show("Password is Wrong or Blank")
        End If

        'once complete with submit clear password/user information
        userpassword.Text = ("")
    End Sub


#End Region



#Region "Timer One Clear Password or Password Save"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'auto clear password
        userpassword.Text = ("")


    End Sub
#End Region



#Region "Server Statuse Bars"
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
#End Region

#Region "SavePassword CheckBox"
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles savepassword.CheckedChanged
        'show check password form "to learn more about this look in the Passwordver.vb form"
        PasswordVer.Show()
    End Sub
#End Region

#Region "Try Me Timer"
    Private Sub tri_Tick(sender As Object, e As EventArgs) Handles tri.Tick
        'take 1 from the counter per secound 90 day try me 400,000?
        Label4.Text = Label4.Text - 1
        'save settings auto so counter will start from last seen time.
        My.Settings.tryme = Label4.Text
        'if time below 5 ad should pop program should shutdown from use.
        'maybe just modify what the user can do with the free software?
        If My.Settings.tryme <= 5 Then
            'greate huge password hash#
            My.Settings.password = ("jf20f9ojer039ejk2-pifj22i309ej1iepej3")
        Else
            'no need for else as of yet
            'should place some sort of buy me ad or some thing.
        End If
    End Sub
#End Region

End Class
