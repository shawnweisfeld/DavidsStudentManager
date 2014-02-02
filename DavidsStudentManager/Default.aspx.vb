Imports System.IO
Imports System.Data.Entity

Public Class _Default
    Inherits Page

    'Dim myContext As New AppDbContext()
    'Dim myContext As New FlatFileContext()
    Dim myContext As MemoryContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        myContext = New MemoryContext()

        RefreshGrid()

    End Sub

    Private Sub RefreshGrid()

        grdStudents.DataSource = myContext.Students.ToList()
        grdStudents.DataBind()

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim stu = New Student()
        'stu.ID = GetNextID()
        stu.FirstName = txtFirstName.Text
        stu.LastName = txtLastName.Text

        myContext.Students.Add(stu)
        myContext.SaveChanges()

        RefreshGrid()

        txtFirstName.Text = String.Empty
        txtLastName.Text = String.Empty

    End Sub

    'Public Function GetNextID() As Integer

    '    If (students.Any()) Then
    '        Return students.Max(Function(x) x.ID) + 1
    '    Else
    '        Return 1
    '    End If

    'End Function


End Class