Imports System.Data.SqlClient

Public Class Form1
    ' Load Employees when the Form Opens
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployees()
    End Sub

    ' Function to Load Employees into DataGridView
    Private Sub LoadEmployees()
        dgvEmployees.DataSource = EmployeeDataAccess.GetEmployees()
    End Sub

    ' Add Employee Button Click Event
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Get values from textboxes
        Dim name As String = txtName.Text
        Dim age As Integer
        Dim department As String = txtDepartment.Text

        ' Validate Age Input
        If Not Integer.TryParse(txtAge.Text, age) Then
            MessageBox.Show("Please enter a valid age!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Call the function to add employee
        EmployeeDataAccess.AddEmployee(name, age, department)

        ' Confirmation Message
        MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Clear input fields
        txtName.Clear()
        txtAge.Clear()
        txtDepartment.Clear()

        ' Reload DataGridView
        LoadEmployees()
    End Sub

    ' Search Employee Button Click Event
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchName As String = txtName.Text
        dgvEmployees.DataSource = EmployeeDataAccess.SearchEmployees(searchName)
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub

    ' Update Employee Button Click Event
    'Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
    '    ' Check if a row is selected
    '    If dgvEmployees.SelectedRows.Count = 0 Then
    '        MessageBox.Show("Please select a record to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return
    '    End If

    '    ' Get selected employee ID
    '    Dim id As Integer = Convert.ToInt32(dgvEmployees.SelectedRows(0).Cells("ID").Value)
    '    Dim name As String = txtName.Text
    '    Dim age As Integer
    '    Dim department As String = txtDepartment.Text

    '    ' Validate Age Input
    '    If Not Integer.TryParse(txtAge.Text, age) Then
    '        MessageBox.Show("Please enter a valid age!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return
    '    End If

    '    ' Call Update function
    '    EmployeeDataAccess.UpdateEmployee(id, name, age, department)
    '    MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    ' Reload DataGridView
    '    LoadEmployees()
    'End Sub

    ' Delete Employee Button Click Event
    'Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    '    ' Check if a row is selected
    '    If dgvEmployees.SelectedRows.Count = 0 Then
    '        MessageBox.Show("Please select a record to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return
    '    End If

    '    ' Get selected employee ID
    '    Dim id As Integer = Convert.ToInt32(dgvEmployees.SelectedRows(0).Cells("ID").Value)

    '    ' Confirm before deletion
    '    If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '        EmployeeDataAccess.DeleteEmployee(id)
    '        MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        ' Reload DataGridView
    '        LoadEmployees()
    '    End If
    'End Sub
End Class
