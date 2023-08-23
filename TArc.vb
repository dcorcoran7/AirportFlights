Public Class TArc
    ' Dependencies: Arc, Node

    ' Inherited Base
    Inherits Arc

    ' TArc Properties
    Public Property PathList As New List(Of String())

    ' default constructor
    Public Sub New()

    End Sub

    ' parametrized constructor
    Public Sub New(t As Node, h As Node)
        MyBase.New(t, h)
    End Sub

    ' Override ToString function
    Public Overrides Function ToString() As String
        Return MyBase.ToString & ", Trans Paths: " & PathList.Count
    End Function

End Class
