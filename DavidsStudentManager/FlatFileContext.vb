Imports System.IO

Public Class FlatFileContext

    Public Sub New()
        Students = New List(Of Student)()
        Dim path = HttpContext.Current.Server.MapPath("students.txt")

        If File.Exists(path) Then

            For Each line As String In File.ReadAllLines(path)
                Dim parts = line.Split(",")
                Dim stu = New Student()
                stu.ID = CInt(parts(0))
                stu.FirstName = parts(1)
                stu.LastName = parts(2)

                Students.Add(stu)
            Next
        End If
    End Sub

    Private _students As List(Of Student)
    Public Property Students() As List(Of Student)
        Get
            Return _students
        End Get
        Set(ByVal value As List(Of Student))
            _students = value
        End Set
    End Property

    Public Sub SaveChanges()
        Dim path = HttpContext.Current.Server.MapPath("students.txt")
        Dim lines = New List(Of String)

        For Each stu As Student In Students
            lines.Add(String.Join(",", stu.ID, stu.FirstName, stu.LastName))
        Next

        File.WriteAllLines(path, lines)
    End Sub

End Class
