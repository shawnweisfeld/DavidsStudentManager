Imports System.Data.Entity

Public Class AppDbContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("DefaultConnection")

    End Sub

    Private _students As DbSet(Of Student)
    Public Property Students() As DbSet(Of Student)
        Get
            Return _students
        End Get
        Set(ByVal value As DbSet(Of Student))
            _students = value
        End Set
    End Property


End Class
