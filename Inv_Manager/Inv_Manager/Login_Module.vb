Module Login_Module


#Region "Login Form Load"
    Public Sub isloading()
        'auto fill username box with data
        login.username.Text = ("DEMO")
        'disable username box / so user can not edit
        login.username.Enabled = False

        'start timers "to learn what they do see below"
        login.Timer1.Enabled = True
        login.Timer2.Enabled = True
        login.tri.Enabled = True

        'load try me counter with last saved time. 90 try me count
        login.Label4.Text = My.Settings.tryme

        ''reset password to password for testing only.
        ' My.Settings.password = ("password")
    End Sub
#End Region


#Region "Login Form Submit Button"
    Public Sub loginsubmit()
        ''if password nothing show message box user error
        If login.userpassword.Text = Nothing Then
            MessageBox.Show("Password is Wrong or Blank")
            'if password is in database :settings for now" then display program
        ElseIf login.userpassword.Text = My.Settings.password Then
            Main.Show()
            login.Hide()
        Else
            ''if password wrong show message box user error
            MessageBox.Show("Password is Wrong or Blank")
        End If
        'once complete with submit clear password/user information
        login.userpassword.Text = ("")
    End Sub
#End Region



#Region "Timer One Clear Password"
    Public Sub loginclear()
        login.userpassword.Text = ("")
    End Sub
#End Region



#Region "Server Status Bars"
    Public Sub loginserverstatus()
        ''Test timer if 
        If login.ProgressBar1.Value <= 99 Then
            login.ProgressBar1.Value = login.ProgressBar1.Value + 1
        ElseIf login.ProgressBar1.Value = 100 Then
            login.ProgressBar1.Value = 100
            login.Timer2.Enabled = False
        End If

        If login.ProgressBar2.Value <= 99 Then
            login.ProgressBar2.Value = login.ProgressBar1.Value + 1
        ElseIf login.ProgressBar2.Value = 100 Then
            login.ProgressBar2.Value = 100
            login.Timer2.Enabled = False
        End If

        If login.ProgressBar3.Value <= 99 Then
            login.ProgressBar3.Value = login.ProgressBar1.Value + 1
        ElseIf login.ProgressBar3.Value = 100 Then
            login.ProgressBar3.Value = 100
            login.Timer2.Enabled = False
        End If
        ''output prot text
        login.port80.Text = ("Port : 80  ") & login.ProgressBar1.Value & ("%")
        login.port3306.Text = ("Port : 3306  ") & login.ProgressBar1.Value & ("%")
        login.port8080.Text = ("Port : 8080  ") & login.ProgressBar1.Value & ("%")
    End Sub
#End Region



#Region "SavePassword CheckBox"
    Public Sub passwordVerShow()
        'show check password form "to learn more about this look in the Passwordver.vb form"
        PasswordVer.Show()
    End Sub
#End Region



#Region "Try Me Timer"
    Public Sub TryMeNow()
        'take 1 from the counter per secound 90 day try me 400,000?
        login.Label4.Text = login.Label4.Text - 1
        'save settings auto so counter will start from last seen time.
        My.Settings.tryme = login.Label4.Text
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
End Module
