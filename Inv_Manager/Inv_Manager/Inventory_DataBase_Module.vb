Imports MySql.Data.MySqlClient

Module Inventory_DataBase_Module
    ''Justin Edit 1/10/2014 Please see ServerSettingsModule
    Public connStr As String = "Database=localtest;" & _
          "Data Source=" & My.Settings.serverhost.ToString() & ";" & _
          "User Id=" & My.Settings.serveruser.ToString() & ";Password=" & My.Settings.serverpassword.ToString()
    Public connection As New MySqlConnection(connStr)
    Public selectedCompID As String
    Public selectedRow As Object

    Public Sub createNewTable()

    End Sub

    Public Sub loadTablesComboBox()
        Try
            Dim dataTable As DataTable = New DataTable
            Dim command As MySqlCommand = New MySqlCommand
            Dim adapter As New MySqlDataAdapter
            Dim reader As MySqlDataReader

            connection.Open()
            command.Connection = connection
            command.CommandText = "SHOW TABLES"

            adapter.SelectCommand = command
            reader = command.ExecuteReader()

            dataTable.Load(reader)

            Main.tablesCombobox.DataSource = dataTable
            Main.tablesCombobox.DisplayMember = "Tables_in_localtest"
            Main.tablesCombobox.ValueMember = "Tables_in_localtest"

            reader.Close()
            connection.Close()

        Catch ex As MySqlException
            MessageBox.Show("Error1: " & ex.Message)
        End Try
    End Sub

    Public Sub populateTextBoxes(e As DataGridViewCellEventArgs)
        selectedRow = Main.DataGridView1.Rows(e.RowIndex) ' gets selection from click handler

        selectedCompID = selectedRow.Cells(0).Value ' ID not seen by user

        Main.TextBox2.Text = selectedRow.Cells(1).Value ' product name
        Main.TextBox3.Text = selectedRow.Cells(6).Value ' price
        Main.TextBox4.Text = selectedRow.Cells(5).Value ' location
        Main.TextBox5.Text = selectedRow.Cells(7).Value ' quantity
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

        ElseIf Main.actionCombo.SelectedItem = "Update" Then
            sendQuery("UPDATE inventory SET Product='" & Main.TextBox2.Text & "', Price='" & Main.TextBox3.Text & _
                "', Location='" & Main.TextBox4.Text & "', Quantity='" & Main.TextBox5.Text & _
                "' WHERE CompID='" & selectedCompID & "'")

        ElseIf Main.actionCombo.SelectedItem = "Insert" Then
            sendQuery("INSERT INTO inventory (CompID, Product, Price, Location, Quantity) " & _
                         "VALUES ('" & Main.DataGridView1.RowCount + 1 & "', '" & Main.TextBox2.Text & "', '" & _
                         Main.TextBox3.Text & "', '" & Main.TextBox4.Text & "', '" & Main.TextBox5.Text & "')")

        ElseIf Main.actionCombo.SelectedItem = "Delete" Then
            sendQuery("DELETE FROM inventory WHERE CompID='" & selectedCompID & "'")

        ElseIf Main.actionCombo.SelectedItem = "List on eBay" Then
            ' show ebay tab and populate item textboxes
            loadEbayTab()
        End If
        loadInventoryTable(Main.tablesCombobox.Text)
        clearAll()
    End Sub

    Public Sub loadInventoryTable(selectedTable As String)
        Try
            Dim query As String = "SELECT * FROM " & selectedTable
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

    Public Function sendQuery(ByVal query As String) As Integer
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
