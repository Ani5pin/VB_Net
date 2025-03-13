'Imports System.Data.SqlClient

'Public Class EmployeeDataAccess
'    ' Connection String for SQL Server
'    Private Shared connectionString As String = "Server=(localdb)\MSSQLLocalDB;Database=EmployeeDB;Integrated Security=True"

'    ' Function to get database connection
'    Public Shared Function GetConnection() As SqlConnection
'        Return New SqlConnection(connectionString)
'    End Function
'End Class


Imports System.Configuration
Imports System.Data.SqlClient

Public Class EmployeeDataAccess
    ' Function to Get Database Connection
    Public Shared Function GetConnection() As SqlConnection
        Dim connString As String = ConfigurationManager.ConnectionStrings("EmployeeDBConnection").ConnectionString
        Return New SqlConnection(connString)
    End Function

    ' Function to Add Employee
    Public Shared Sub AddEmployee(name As String, age As Integer, department As String)
        Dim query As String = "INSERT INTO Employees (Name, Age, Department) VALUES (@Name, @Age, @Department)"

        Using con As SqlConnection = GetConnection(),
              cmd As New SqlCommand(query, con)

            cmd.Parameters.AddWithValue("@Name", name)
            cmd.Parameters.AddWithValue("@Age", age)
            cmd.Parameters.AddWithValue("@Department", department)

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Using
    End Sub

    ' Function to Get All Employees
    Public Shared Function GetEmployees() As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM Employees"

        Using con As SqlConnection = GetConnection(),
              cmd As New SqlCommand(query, con),
              adapter As New SqlDataAdapter(cmd)

            adapter.Fill(dt)
        End Using

        Return dt
    End Function

    ' Function to Search Employees by Name
    Public Shared Function SearchEmployees(name As String) As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM Employees WHERE Name LIKE @Name"

        Using con As SqlConnection = GetConnection(),
              cmd As New SqlCommand(query, con),
              adapter As New SqlDataAdapter(cmd)

            cmd.Parameters.AddWithValue("@Name", "%" & name & "%")
            adapter.Fill(dt)
        End Using

        Return dt
    End Function

    ' Function to Update Employee
    Public Shared Sub UpdateEmployee(id As Integer, name As String, age As Integer, department As String)
        Dim query As String = "UPDATE Employee SET Name = @Name, Age = @Age, Department = @Department WHERE ID = @ID"

        Using con As SqlConnection = GetConnection(),
              cmd As New SqlCommand(query, con)

            cmd.Parameters.AddWithValue("@ID", id)
            cmd.Parameters.AddWithValue("@Name", name)
            cmd.Parameters.AddWithValue("@Age", age)
            cmd.Parameters.AddWithValue("@Department", department)

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Using
    End Sub

    ' Function to Delete Employee
    Public Shared Sub DeleteEmployee(id As Integer)
        Dim query As String = "DELETE FROM Employees WHERE ID = @ID"

        Using con As SqlConnection = GetConnection(),
              cmd As New SqlCommand(query, con)

            cmd.Parameters.AddWithValue("@ID", id)

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Using
    End Sub
End Class
