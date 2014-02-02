Public Class MemoryContext

    Public Sub New()

        If (HttpContext.Current.Session Is Nothing OrElse HttpContext.Current.Session("students") Is Nothing) Then
            _students = New List(Of Student)()
        Else
            _students = TryCast(HttpContext.Current.Session("students"), List(Of Student))
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
        HttpContext.Current.Session("students") = _students

    End Sub
End Class
