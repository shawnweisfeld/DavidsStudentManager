Public Class _Default
    Inherits Page

    Dim students As List(Of Student)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        students = TryCast(Session("students"), List(Of Student))

        If (students Is Nothing) Then
            students = New List(Of Student)()
        End If

        RefreshGrid()

    End Sub

    Private Sub RefreshGrid()

        grdStudents.DataSource = students
        grdStudents.DataBind()

        Session("students") = students

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

End Class