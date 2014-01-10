Public Class login
''Please See Login Module For Help

#Region "When form loads do what?"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isloading()
    End Sub
#End Region



#Region "Submit username & password to Server"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loginsubmit()
    End Sub
#End Region



#Region "Timer One Clear Password or Password Save"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        loginclear()
    End Sub
#End Region



#Region "Server Statuse Bars"
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        loginserverstatus()
    End Sub
#End Region



#Region "SavePassword CheckBox"
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles savepassword.CheckedChanged
        passwordVerShow()
    End Sub
#End Region



#Region "Try Me Timer"
    Private Sub tri_Tick(sender As Object, e As EventArgs) Handles tri.Tick
        TryMeNow()
    End Sub
#End Region

End Class
