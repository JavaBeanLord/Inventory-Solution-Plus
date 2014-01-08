Imports MySql.Data.MySqlClient

Public Class Main

    Private connStr As String = "Database=localtest;" & _
            "Data Source=127.0.0.1;" & _
            "User Id=Ethan;Password=password"
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

        loadInventoryTable()

        actionCombo.SelectedItem = "Insert"
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

    Private Sub refreshButton_Click(sender As Object, e As EventArgs) Handles refreshButton.Click
        loadInventoryTable()
    End Sub

    Private Sub searchtb_KeyDown(sender As Object, e As KeyEventArgs) Handles searchtb.KeyDown
        If e.KeyCode = Keys.Enter Then
            If searchtb.Text = Nothing Then
                MsgBox("Please choose a type of item.")
            Else
                retrieveDataToDataGrid(searchtb.Text)
            End If
        End If
    End Sub

    Private Sub output_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim selectedRow As Object = DataGridView1.Rows(e.RowIndex)

        selectedCompID = selectedRow.Cells(0).Value

        TextBox2.Text = selectedRow.Cells(1).Value
        TextBox3.Text = selectedRow.Cells(2).Value
        TextBox4.Text = selectedRow.Cells(3).Value
        TextBox5.Text = selectedRow.Cells(4).Value

        actionCombo.SelectedItem = "Update"
    End Sub

    Private Sub actionCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles actionCombo.SelectedIndexChanged
        clearAll()
    End Sub

    Private Sub enterButton_Click(sender As Object, e As EventArgs) Handles enterButton.Click
        checkForEmptiness()
    End Sub

    Public Sub checkForEmptiness()
        If TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And TextBox5.Text = "" Then
            MsgBox("Please fill at least one field.")
        Else
            performDesiredAction()
        End If
    End Sub

    Public Sub performDesiredAction()
        If selectedCompID = Nothing And actionCombo.SelectedItem = "Update" Then
            MsgBox("Please select an item or enter a new one.")

        ElseIf actionCombo.SelectedItem = "Insert" Then
            updateRecord("INSERT INTO inventory (CompID, CompName, Manufacturer, OperatingSys, Quantity) " & _
                         "VALUES ('" & DataGridView1.RowCount & "', '" & TextBox2.Text & "', '" & _
                         TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "')")

        ElseIf actionCombo.SelectedItem = "Update" Then
            updateRecord("UPDATE inventory SET CompName='" & TextBox2.Text & "', Manufacturer='" & TextBox3.Text & _
                "', OperatingSys='" & TextBox4.Text & "', Quantity='" & TextBox5.Text & _
                "' WHERE CompID='" & selectedCompID & "'")

        ElseIf actionCombo.SelectedItem = "Delete" Then
            updateRecord("DELETE FROM inventory WHERE CompID='" & selectedCompID & "'")
        End If
        loadInventoryTable()
        clearAll()
    End Sub

    Private Sub loadInventoryTable()
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
    End Sub

    ' Takes name of computer as key word
    ' needs to incorporate other fields as key words
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

    ' Takes any UPDATE or INSERT command
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

    Public Sub clearAll()
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

#End Region
End Class