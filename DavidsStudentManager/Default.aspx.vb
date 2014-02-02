Imports System.IO
Public Class _Default
    Inherits Page

    Dim students As List(Of Student)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        'GetFromMemory()
        GetFromFlatFile()

        RefreshGrid()

    End Sub

    Private Sub RefreshGrid()

        grdStudents.DataSource = students
        grdStudents.DataBind()

        'SaveToMemory()
        SaveToFlatFile()

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim stu = New Student()
        stu.ID = GetNextID()
        stu.FirstName = txtFirstName.Text
        stu.LastName = txtLastName.Text

        students.Add(stu)

        RefreshGrid()

        txtFirstName.Text = String.Empty
        txtLastName.Text = String.Empty

    End Sub

    Public Function GetNextID() As Integer

        If (students.Any()) Then
            Return students.Max(Function(x) x.ID) + 1
        Else
            Return 1
        End If

    End Function

    Private Sub GetFromMemory()

        students = TryCast(Session("students"), List(Of Student))

        If (students Is Nothing) Then
            students = New List(Of Student)()
        End If


    End Sub

    Private Sub SaveToMemory()

        Session("students") = students

    End Sub


    Private Sub GetFromFlatFile()

        students = New List(Of Student)()

        If File.Exists(Server.MapPath("students.txt")) Then

            For Each line As String In File.ReadAllLines(Server.MapPath("students.txt"))
                Dim parts = line.Split(",")
                Dim stu = New Student()
                stu.ID = CInt(parts(0))
                stu.FirstName = parts(1)
                stu.LastName = parts(2)

                students.Add(stu)
            Next
        End If

    End Sub

    Private Sub SaveToFlatFile()

        Dim lines = New List(Of String)

        For Each stu As Student In students
            lines.Add(String.Join(",", stu.ID, stu.FirstName, stu.LastName))
        Next

        File.WriteAllLines(Server.MapPath("students.txt"), lines)

    End Sub

End Class