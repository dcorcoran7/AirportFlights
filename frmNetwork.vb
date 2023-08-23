Public Class frmNetwork

    ' Dependencies: Map, Network, TArc

    ' module scope variables 
    Dim WithEvents myNet As New Network
    Dim myMap As Database
    Dim radius As Integer = 1000
    Dim nodesAdded As Integer = 0
    Dim arcsAdded As Integer = 0

    Dim AllPairsList As New List(Of Pair)
    Dim CurrPath As List(Of TArc)



    Private Class Pair
        'properties of Pair
        Public Property Orig As String
        Public Property Dest As String
        Public Property Path As List(Of TArc)
        Public Property Length As Decimal

        'default constructor
        Public Sub New()

        End Sub

        'parameterized constructor
        Public Sub New(o As String, d As String, p As List(Of TArc), l As Decimal)
            Orig = o
            Dest = d
            Path = p
            Length = l
        End Sub
    End Class



    ' builds network with respect to a given radius
    Public Sub BuildNetwork()
        myMap = New Database(radius)
        myNet.NodeSList.Clear()
        myNet.ArcSList.Clear()

        For Each dr In myMap.GetNodes
            myNet += (dr("Name"))
        Next


        For Each c1 In myNet.NodeSList.Keys
            For Each c2 In myNet.NodeSList.Keys
                Dim dist As Decimal = myMap.GetDistance(c1, c2)
                If c1 <> c2 And dist > 0 And dist < radius Then
                    myNet.AddArc(c1, c2)
                    Dim a As Arc = myNet.GetArc(c1, c2)
                    a.Cost = dist
                    a.Capacity = 1
                End If
            Next
        Next

        MessageBox.Show("Network has been created with " & myMap.GetNumNodes &
                        " nodes and " & myMap.GetNumArcs & " arcs.")

    End Sub

    ' handles user-defined NetworkChanged event
    Private Sub myNet_Changed(net As Network) Handles myNet.NetworkChanged
        nodesAdded = myNet.NodeSList.Count
        arcsAdded = myNet.ArcSList.Count
    End Sub

    ' builds network, finds all-pairs shortest path and displays in trvNetwork
    Private Sub btnAllPairsSP_Click(sender As Object, e As EventArgs) Handles btnAllPairsSP.Click
        AllPairsList.Clear()
        radius = CInt(cboRadius.Text)
        BuildNetwork()
        trvNetwork.Nodes(0).Nodes.Clear()

        ' HANDS ON EXERCISE ----- BEGIN -------------------------------------------

        'LNIQ to filter cities based on airport

        'myNet.NodeSList.Values 'CODE - City ei. PIT - Pittsburgh

        Dim cityList = From city In myNet.NodeSList.Values
                       Where city.ID < "G"
                       Order By city.ArcsOut.Count Descending


        ' HANDS ON EXERCISE ----- END -------------------------------------------


        Dim progForm As New frmProgress
        progForm.prbNodes.Minimum = 1
        progForm.prbNodes.Maximum = cityList.Count
        progForm.Show()

        Dim cnt As Integer = 0
        For Each city In cityList
            Dim c1 As String = city.ID
            Dim origTNode As New TreeNode(c1)
            trvNetwork.Nodes(0).Nodes.Add(origTNode)
            For Each c2 In myNet.NodeSList.Keys
                Dim length As Decimal
                Dim list As List(Of TArc) = myNet.ShortestPath(c1, c2, length)
                If list IsNot Nothing Then
                    AllPairsList.Add(New Pair(c1, c2, list, length))
                    Dim destTNode As New TreeNode(c2)
                    origTNode.Nodes.Add(destTNode)
                End If
            Next
            cnt += 1
            progForm.prbNodes.Value = cnt
            progForm.Refresh()
        Next
        progForm.Close()
    End Sub

    ' populates radius combobox
    Private Sub frmNetwork_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Integer = 1 To 10
            cboRadius.Items.Add(i * 250)
        Next
        cboRadius.SelectedIndex = 3
        trvNetwork.Nodes.Add(New TreeNode("Network"))
    End Sub


    ' finds origin/destination from selection in trvNetwork
    Private Sub trvNetwork_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvNetwork.AfterSelect
        Try
            lstPath.Items.Clear()
            Dim tn As TreeNode = trvNetwork.SelectedNode
            If tn.Text = "Network" Then
                GetSummary("Network")
            ElseIf tn.Parent.Text = "Network" Then
                GetSummary(tn.Text)
            Else
                Dim orig As String = tn.Parent.Text
                Dim dest As String = tn.Text


                ' HANDS ON EXERCISE ----- BEGIN -------------------------------------------

                Dim list = From p In AllPairsList
                           Where p.Orig = orig And p.Dest = dest

                CurrPath = list(0).Path


                ' HANDS ON EXERCISE ----- END -------------------------------------------


                For Each a In CurrPath
                    lstPath.Items.Add(a.ToString)
                Next

                MessageBox.Show("Distance from " & orig & " to " & dest &
                                " is " & list(0).Length & " miles.")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    ' returns the summmary for avg hops and destination count for a city or network
    Private Sub GetSummary(city As String)
        Dim lb As String = "A",
            ub As String = "Z"

        If city <> "Network" Then
            lb = city
            ub = city
        End If

        ' HANDS ON EXERCISE ----- BEGIN -------------------------------------------

        Dim list = From p In AllPairsList
                   Where p.Orig >= lb And p.Orig <= ub
                   Group By OrigCity = p.Orig
                       Into AvgHops = Average(p.Path.Count), DestCount = Count()
                   Order By AvgHops Descending
                   Select OrigCity, AvgHops, DestCount


        ' HANDS ON EXERCISE ----- END -------------------------------------------


        Dim str As String = "Summary of " & city
        For Each c In list
            str &= vbCrLf & "City : " & c.OrigCity & vbTab &
                            "Avg Hops : " & FormatNumber(c.AvgHops, 2) & vbTab &
                            "Dest Count : " & c.DestCount
        Next
        MessageBox.Show(str, "Summary")
    End Sub

    ' displays all trans paths for a given arc in a path
    Private Sub btnTransPaths_Click(sender As Object, e As EventArgs) Handles btnTransPaths.Click

        If lstPath.SelectedIndex >= 0 Then
            Dim a As TArc = CurrPath(lstPath.SelectedIndex)
            Dim str As String = "Trans paths for arc " & a.ID & ":"
            For Each od() As String In a.PathList
                str &= vbCrLf & "orig:" & od(0) & ", dest:" & od(1)
            Next
            MessageBox.Show(str)
        Else
            MessageBox.Show("Select an arc.")
        End If

    End Sub

    ' closes form
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
