Public Class Node
    ' Dependencies: Arc

    ' Node properties
    Public Property ID As String
    Public Property ArcsIn As List(Of Arc)
    Public Property ArcsOut As List(Of Arc)
    Public Property Demand As Decimal

    ' constructor
    Public Sub New()

    End Sub

    ' parametrized constructor
    Public Sub New(value As String)
        ID = value
        ArcsIn = New List(Of Arc)
        ArcsOut = New List(Of Arc)
    End Sub

    ' Override ToString function
    Public Overrides Function ToString() As String
        Dim str As String = "Node " & ID & ": Demand: " & Demand
        Return str
    End Function

End Class
