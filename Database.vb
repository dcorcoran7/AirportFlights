
Imports System.Data.SqlClient

Public Class Database

    ' Dependencies: None

    ' Database Properties
    Private myDataSet As New DataSet
    Private nodesDA As SqlDataAdapter
    Private arcsDA As SqlDataAdapter

    ' Parametrized Constructor
    Public Sub New(radius As Integer)
        nodesDA = GetDataAdapter("SELECT * FROM vwActiveAirports")
        nodesDA.Fill(myDataSet, "Nodes")
        arcsDA = GetDataAdapter("SELECT * FROM vwActiveFlights WHERE Distance <= " & radius)
        arcsDA.Fill(myDataSet, "Arcs")
    End Sub

    ' Establishes the connection via the adapter
    Public Function GetDataAdapter(mySQL As String)
        Dim connStr As String = "Server=tcp:bitcoursework.database.windows.net,1433;Initial Catalog=bit_2020;Persist Security Info=False;User ID=bit3444_hw3;Password='BIT_3444_91717_202009';
MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Return New SqlDataAdapter(mySQL, connStr)
    End Function


    Public Function GetNodes() As DataRowCollection
        Return myDataSet.Tables("Nodes").Rows
    End Function


    ' returns number of nodes from the Nodes table
    Public Function GetNumNodes() As Integer
        Return myDataSet.Tables("Nodes").Rows.Count
    End Function

    ' returns number of arcs from the Arcs table
    Public Function GetNumArcs() As Integer
        Return myDataSet.Tables("Arcs").Rows.Count
    End Function

    ' returns Node name given Node ID
    Public Function GetNodeName(id As String) As String
        Dim r() As DataRow = myDataSet.Tables("Nodes").Select("ID = '" & id & "'")
        If r.Length > 0 Then
            Return r(0)("Name")
        Else
            Return Nothing
        End If
    End Function

    ' returns Node ID given Node Name
    Public Function GetNodeID(name As String) As String
        Dim r() As DataRow = myDataSet.Tables("Nodes").Select("Name = '" & name & "'")
        If r.Length > 0 Then
            Return r(0)("ID")
        Else
            Return -1
        End If
    End Function

    ' returns distancbe between two Nodes given their names
    Public Function GetDistance(name1 As String, name2 As String) As Decimal
        Dim i1 As String = GetNodeID(name1)
        Dim i2 As String = GetNodeID(name2)
        Dim r() As DataRow = myDataSet.Tables("Arcs").Select("Tail = '" & i1 & "' AND Head = '" & i2 & "'")
        If r.Length > 0 Then
            Return r(0)("Distance")
        Else
            Return -1
        End If
    End Function

    ' modifys arc distance given tail and head Node Name
    Public Sub ModifyArc(name1 As String, name2 As String, dist As Decimal)
        Dim i1 As String = GetNodeID(name1)
        Dim i2 As String = GetNodeID(name2)
        Dim r() As DataRow = myDataSet.Tables("Arcs").Select("Tail = '" & i1 & "' AND Head = '" & i2 & "'")
        r(0).BeginEdit()
        r(0)("Distance") = dist
        r(0).EndEdit()
    End Sub



End Class
