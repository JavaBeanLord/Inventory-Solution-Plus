Module ServerSettingsModule
    Public Sub serverhostsetting()
        If ServerSettings.serverhost.Text = Nothing Then
            MessageBox.Show("Please Type Host Name!")
        Else
            My.Settings.serverhost = ServerSettings.serverhost.Text
        End If
    End Sub

    Public Sub serverusersetting()
        If ServerSettings.serverhost.Text = Nothing Then
            MessageBox.Show("Please Type User Name!")
        Else
            My.Settings.serveruser = ServerSettings.serveruser.Text
        End If
    End Sub

    Public Sub serverpasswordsetting()
        If ServerSettings.serverpassword.Text = Nothing Then
            MessageBox.Show("Please Type User PassWord!")
        Else
            My.Settings.serverpassword = ServerSettings.serverpassword.Text
        End If
    End Sub

    Public Sub serverinfonow()
        ServerSettings.serverstatus.Text = "MySQL Host: " & My.Settings.serverhost.ToString()
        ServerSettings.userstatus.Text = "MySQL User: " & My.Settings.serveruser.ToString
        ServerSettings.passwordstatus.Text = "MySQL PassWord: " & My.Settings.serverpassword.ToString
    End Sub

    Public Sub clearserversettings()
        ServerSettings.serverstatus.Text = ""
        ServerSettings.userstatus.Text = ""
        ServerSettings.passwordstatus.Text = ""
    End Sub
End Module
