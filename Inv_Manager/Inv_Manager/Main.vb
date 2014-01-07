Imports MySql.Data.MySqlClient

Public Class Main

    Private connStr As String = "Database=localtest;" & _
            "Data Source=127.0.0.1;" & _
            "User Id=root;Password=password"
    Private selectedCompID As String

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

        ''Etahn Code
        Try
            Dim query As String = "SELECT * FROM inventory"
            Dim connection As New MySqlConnection(connStr)
            Dim da As New MySqlDataAdapter(query, connection)
            Dim ds As New DataSet()

            If da.Fill(ds) Then
                DataGridView1.DataSource = ds.Tables(0)
            End If

            connection.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        'end Ethan Code
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

    Private Sub searchtb_KeyDown(sender As Object, e As KeyEventArgs) Handles searchtb.KeyDown
        If e.KeyCode = Keys.Enter Then
            If searchtb.Text = Nothing Then
                MsgBox("Please choose a type of item.")
            Else
                retrieveDataToDataGrid(searchtb.Text)
            End If
        End If
    End Sub

    Public Sub retrieveDataToDataGrid(compName As String)
        Try
            Dim query As String = "SELECT * FROM inventory WHERE CompName = '" & compName & "'"
            Dim connection As New MySqlConnection(connStr)
            Dim da As New MySqlDataAdapter(query, connection)
            Dim ds As New DataSet()

            If da.Fill(ds) Then
                DataGridView1.DataSource = ds.Tables(0)
            End If

            connection.Close()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Function updateRecord(ByVal query As String) As Integer
        Try
            Dim rowsEffected As Integer = 0
            Dim connection As New MySqlConnection(connStr)
            Dim cmd As New MySqlCommand(query, connection)

            connection.Open()

            rowsEffected = cmd.ExecuteNonQuery()

            connection.Close()

            Return rowsEffected
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub TestConnection()
        Dim connection As New MySqlConnection(connStr)
        Try
            connection.Open()
            MsgBox("Connection is okay. MySQL version: " & connection.ServerVersion)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

#End Region

  
End Class