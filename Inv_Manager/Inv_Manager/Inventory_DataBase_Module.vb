Imports MySql.Data.MySqlClient

Module Inventory_DataBase_Module
    ''Justin Edit 1/10/2014 Please see ServerSettingsModule
    Public connStr As String = "Database=localtest;" & _
          "Data Source=" & My.Settings.serverhost.ToString() & ";" & _
          "User Id=" & My.Settings.serveruser.ToString() & ";Password=" & My.Settings.serverpassword.ToString()
    Public selectedCompID As String


    Public Sub populateTextBoxes(e As DataGridViewCellEventArgs)
        Dim selectedRow As Object = Main.DataGridView1.Rows(e.RowIndex)

        selectedCompID = selectedRow.Cells(0).Value

        Main.TextBox2.Text = selectedRow.Cells(1).Value
        Main.TextBox3.Text = selectedRow.Cells(2).Value
        Main.TextBox4.Text = selectedRow.Cells(3).Value
        Main.TextBox5.Text = selectedRow.Cells(4).Value

        'actionCombo.SelectedItem = "Update"
    End Sub

    Public Sub checkForEmptiness()
        If Main.TextBox2.Text = "" And Main.TextBox3.Text = "" And Main.TextBox4.Text = "" And Main.TextBox5.Text = "" Then
            MsgBox("Please fill at least one field.")
        Else
            performDesiredAction()
        End If
    End Sub

    Public Sub performDesiredAction()
        If selectedCompID = Nothing And Main.actionCombo.SelectedItem = "Update" Then
            MsgBox("Please select an item or enter a new one.")

        ElseIf Main.actionCombo.SelectedItem = "Insert" Then
            updateRecord("INSERT INTO inventory (CompID, CompName, Manufacturer, OperatingSys, Quantity) " & _
                         "VALUES ('" & Main.DataGridView1.RowCount + 1 & "', '" & Main.TextBox2.Text & "', '" & _
                         Main.TextBox3.Text & "', '" & Main.TextBox4.Text & "', '" & Main.TextBox5.Text & "')")

        ElseIf Main.actionCombo.SelectedItem = "Update" Then
            updateRecord("UPDATE inventory SET CompName='" & Main.TextBox2.Text & "', Manufacturer='" & Main.TextBox3.Text & _
                "', OperatingSys='" & Main.TextBox4.Text & "', Quantity='" & Main.TextBox5.Text & _
                "' WHERE CompID='" & selectedCompID & "'")

        ElseIf Main.actionCombo.SelectedItem = "Delete" Then
            updateRecord("DELETE FROM inventory WHERE CompID='" & selectedCompID & "'")

        ElseIf Main.actionCombo.SelectedItem = "List on eBay" Then
            ' show ebay tab

        End If
        loadInventoryTable()
        clearAll()
    End Sub

    Public Sub loadInventoryTable()
        Try
            Dim query As String = "SELECT * FROM inventory"
            Dim connection As New MySqlConnection(connStr)
            Dim da As New MySqlDataAdapter(query, connection)
            Dim ds As New DataSet()

            If da.Fill(ds) Then
                Main.DataGridView1.DataSource = ds.Tables(0)
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
                Main.DataGridView1.DataSource = ds.Tables(0)
            End If

            connection.Close()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    ' Takes any UPDATE or INSERT command
    Public Function updateRecord(ByVal query As String) As Integer
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

    Public Sub TestConnection()
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
        Main.TextBox2.Text = ""
        Main.TextBox3.Text = ""
        Main.TextBox4.Text = ""
        Main.TextBox5.Text = ""
    End Sub
End Module
