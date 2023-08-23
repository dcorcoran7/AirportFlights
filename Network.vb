Public Class Network
    ' Dependencies: Arc, Node, TArc

    ' Node and arc lists
    Public Property NodeSList As New SortedList(Of String, Node)
    Public Property ArcSList As New SortedList(Of String, Arc)

    ' signals when there is a change in network
    Public Event NetworkChanged(net As Network)

    ' default constructor
    Public Sub New()

    End Sub

    ' read-only property example 1
    Public ReadOnly Property NodeCount As Integer
        Get
            Return NodeSList.Count
        End Get
    End Property

    ' read-only property example 2
    Public ReadOnly Property ArcCount As Integer
        Get
            Return ArcSList.Count
        End Get
    End Property

    ' returns a node given id
    Public Function GetNode(id As String) As Node
        Try
            If Not NodeSList.ContainsKey(id) Then
                Throw New Exception("Node " & id & " does not exist.")
            End If
            Return NodeSList(id)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Node error")
            Return Nothing
        End Try
    End Function

    ' returns arc given tail and head node ids  
    Public Function GetArc(t As String, h As String) As Arc
        Try
            Dim id As String = t & "-TO-" & h
            If Not ArcSList.ContainsKey(id) Then
                Throw New Exception("Arc" & id & " does not exist.")
            End If
            Return ArcSList(id)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Arc error")
            Return Nothing
        End Try
    End Function

    ' adds node to the network if it doesn't already exist
    Public Function AddNode(id As String) As Boolean
        Try
            If NodeSList.ContainsKey(id) Then
                Throw New Exception("Node " & id & " already exists.")
            End If
            Dim node As New Node(id)
            NodeSList.Add(id, node)
            RaiseEvent NetworkChanged(Me)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Node exists")
            Return False
        End Try
    End Function

    ' shared operator to add a node to network via id
    Public Shared Operator +(net As Network, id As String) As Network
        net.AddNode(id)
        Return net
    End Operator

    ' adds arc with tail and head node ids
    Public Function AddArc(tailID As String, headID As String) As Boolean

        If Not NodeSList.ContainsKey(tailID) Then
            AddNode(tailID)
        End If

        If Not NodeSList.ContainsKey(headID) Then
            AddNode(headID)
        End If

        Dim t As Node = GetNode(tailID)
        Dim h As Node = GetNode(headID)
        Dim a = New TArc(t, h)
        If ArcSList.ContainsKey(a.ID) Then
            MessageBox.Show("Arc " & a.ID & " already exists.")
            Return False
        Else
            ArcSList.Add(a.ID, a)
            t.ArcsOut.Add(a)
            h.ArcsIn.Add(a)
            RaiseEvent NetworkChanged(Me)
            Return True
        End If

    End Function

    ' finds shortes path between an origin node and a destination node
    Public Function ShortestPath(orig As String, dest As String, ByRef length As Decimal) As List(Of TArc)
        Dim permList As New List(Of String)
        Dim tempList As New List(Of String)
        Dim labelList As New SortedList(Of String, Decimal)
        Dim trackList As New SortedList(Of String, Arc)
        Dim inf As Decimal = 1000000000


        ' initialization
        For Each a In ArcSList.Values
            a.Flow = 0
        Next
        For Each n In NodeSList.Values
            tempList.Add(n.ID)
            labelList.Add(n.ID, inf)
            trackList.Add(n.ID, Nothing)
        Next

        Try
            If Not NodeSList.ContainsKey(orig) Or Not NodeSList.ContainsKey(dest) Then
                Throw New Exception("Error in origin or destination")
            End If
            If orig = dest Then
                Throw New Exception("Origin and destination are the same")
            End If

            permList.Add(orig)
            labelList(orig) = 0
            tempList.Remove(orig)

            Do Until permList.Contains(dest) ' tempList.Count > 0
                'Update labels
                For Each a2 In ArcSList.Values
                    If permList.Contains(a2.Tail.ID) And tempList.Contains(a2.Head.ID) Then
                        Dim newlabel = labelList(a2.Tail.ID) + a2.Cost
                        If newlabel < labelList(a2.Head.ID) Then
                            labelList(a2.Head.ID) = newlabel
                            trackList(a2.Head.ID) = a2
                        End If
                    End If
                Next
                'find smallest labeled temp node
                Dim minlabel As Integer = inf
                Dim minID As String = Nothing
                For Each t In tempList
                    If labelList(t) < minlabel Then
                        minlabel = labelList(t)
                        minID = t
                    End If
                Next
                If minID = Nothing And tempList.Count > 0 Then
                    Throw New Exception("No path exists.")
                End If
                'make smallest labeled temp node permanent
                permList.Add(minID)
                tempList.Remove(minID)

            Loop

            ' backtrack shortest path
            Dim path As New List(Of TArc)
            Dim a As TArc = trackList(dest)
            a.Flow = 1
            Do
                path.Insert(0, a)
                If a.Tail.ID <> orig And a.Head.ID <> dest Then
                    Dim origdest(1) As String
                    origdest(0) = orig
                    origdest(1) = dest
                    a.PathList.Add(origdest)
                End If
                a = trackList(a.Tail.ID)
                If a IsNot Nothing Then
                    a.Flow = 1
                End If
            Loop Until a Is Nothing
            length = labelList(dest)
            Return path
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error")
            Return Nothing
        End Try
    End Function

End Class
