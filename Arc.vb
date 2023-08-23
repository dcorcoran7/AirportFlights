Public Class Arc
    ' Dependencies: Node

    ' Arc properties
    Public Property ID As String
    Public Property Tail As Node
    Public Property Head As Node
    Public Property Capacity As Decimal
    Public Property Cost As Decimal
    Public Property Flow As Decimal

    ' constructor
    Public Sub New()

    End Sub

    ' parametrized constructor
    Public Sub New(t As Node, h As Node)
        Try
            If t Is Nothing Or h Is Nothing Then
                Throw New Exception("Tail or head node does not exist.")
            End If
            Tail = t
            Head = h
            ID = Tail.ID & "-TO-" & Head.ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Arc error")
        End Try
    End Sub

    ' Override ToString function
    Public Overrides Function ToString() As String
        Dim str As String = "(" & Tail.ID & ", " & Head.ID & ") " &
            "Capa: " & Capacity & " Cost: " & Cost
        Return str
    End Function

End Class
