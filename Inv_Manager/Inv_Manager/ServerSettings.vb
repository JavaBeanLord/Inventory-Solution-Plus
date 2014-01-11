Public Class ServerSettings

    Private Sub serversavebtn_Click(sender As Object, e As EventArgs) Handles serversavebtn.Click
        serverhostsetting()
        serverusersetting()
        serverpasswordsetting()
        clearserversettings()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        serverinfonow()
    End Sub

    Private Sub ServerSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        serverinfonow()
    End Sub
End Class