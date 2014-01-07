Public Class PasswordVer

    Private Sub PasswordVer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mask.Checked = True
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Mask.Checked = True Then
            masterpassword.PasswordChar = ("*")
        Else
            masterpassword.PasswordChar = ("")
        End If
    End Sub
End Class