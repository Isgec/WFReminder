Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel

Namespace SIS.WF
  Partial Public Class wfDBRows
    Public ReadOnly Property GetIcon As String
      Get
        Dim mRet As String = "fa fa-2x fa-address-card"
        If MainDBIconID <> "" Then
          mRet = "fa fa-2x fa-" & FK_WF_DBRows_MainDBIconID.IconName
        End If
        Return mRet
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DAWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DAWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DAWF(ByVal DashboardID As Int32, ByVal DBRows As Int32) As SIS.WF.wfDBRows
      Dim Results As SIS.WF.wfDBRows = wfDBRowsGetByID(DashboardID, DBRows)
      Dim mFrom As Integer = 0
      Dim mCount As Integer = 50
      Dim uList As List(Of SIS.WF.wfUserDBRows) = SIS.WF.wfUserDBRows.UZ_wfUserDBRowsSelectListForAllUsers(mFrom, mCount, "", False, "", DBRows, DashboardID)
      Do While uList.Count > 0
        For Each usr As SIS.WF.wfUserDBRows In uList
          usr.Active = False
          SIS.WF.wfUserDBRows.UpdateData(usr)
        Next
        mFrom += mCount
        uList = SIS.WF.wfUserDBRows.UZ_wfUserDBRowsSelectListForAllUsers(mFrom, mCount, "", False, "", DBRows, DashboardID)
      Loop
      Return Results
    End Function
    Public ReadOnly Property AAWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property AAWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function AAWF(ByVal DashboardID As Int32, ByVal DBRows As Int32) As SIS.WF.wfDBRows
      Dim Results As SIS.WF.wfDBRows = wfDBRowsGetByID(DashboardID, DBRows)
      Dim mFrom As Integer = 0
      Dim mCount As Integer = 50

      Dim uList As List(Of SIS.WF.wfUserDBRows) = SIS.WF.wfUserDBRows.UZ_wfUserDBRowsSelectListForAllUsers(mFrom, mCount, "", False, "", DBRows, DashboardID)
      Do While uList.Count > 0
        For Each usr As SIS.WF.wfUserDBRows In uList
          usr.Active = True
          SIS.WF.wfUserDBRows.UpdateData(usr)
        Next
        mFrom += mCount
        uList = SIS.WF.wfUserDBRows.UZ_wfUserDBRowsSelectListForAllUsers(mFrom, mCount, "", False, "", DBRows, DashboardID)
      Loop
      Return Results
    End Function
    Public ReadOnly Property RAWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RAWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function RAWF(ByVal DashboardID As Int32, ByVal DBRows As Int32) As SIS.WF.wfDBRows
      Dim Results As SIS.WF.wfDBRows = wfDBRowsGetByID(DashboardID, DBRows)
      Dim mFrom As Integer = 0
      Dim mCount As Integer = 50

      Dim uList As List(Of SIS.WF.wfUserDBRows) = SIS.WF.wfUserDBRows.UZ_wfUserDBRowsSelectListForAllUsers(mFrom, mCount, "", False, "", DBRows, DashboardID)
      Do While uList.Count > 0
        For Each usr As SIS.WF.wfUserDBRows In uList
          usr.Active = False
          SIS.WF.wfUserDBRows.UZ_wfUserDBRowsDelete(usr)
        Next
        mFrom += mCount
        uList = SIS.WF.wfUserDBRows.UZ_wfUserDBRowsSelectListForAllUsers(mFrom, mCount, "", False, "", DBRows, DashboardID)
      Loop
      Return Results
    End Function
    Public ReadOnly Property CopyWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CopyWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function CopyWF(ByVal DashboardID As Int32, ByVal DBRows As Int32) As SIS.WF.wfDBRows
      Dim Results As SIS.WF.wfDBRows = wfDBRowsGetByID(DashboardID, DBRows)
      Dim tmpCols As List(Of SIS.WF.wfDBRowCols) = SIS.WF.wfDBRowCols.UZ_wfDBRowColsSelectList(0, 99999, "", False, "", Results.DashboardID, Results.DBRows)
      Results.DBRows = 0
      Results = SIS.WF.wfDBRows.InsertData(Results)
      For Each col As SIS.WF.wfDBRowCols In tmpCols
        col.DBRows = Results.DBRows
        col.DBCols = 0
        col = SIS.WF.wfDBRowCols.InsertData(col)
      Next
      'Also Distribute Row to Users
      Dim mFrom As Integer = 0
      Dim mCount As Integer = 50
      Dim uList As List(Of SIS.WF.wfUserDashboards) = SIS.WF.wfUserDashboards.UZ_wfUserDashboardsSelectList(mFrom, mCount, "", False, "", "", DashboardID)
      Do While uList.Count > 0
        For Each usr As SIS.WF.wfUserDashboards In uList
          Dim tmpUDBRow As New SIS.WF.wfUserDBRows
          With tmpUDBRow
            .Active = Not Results.NotToDraw
            .DashboardID = DashboardID
            .DBRows = Results.DBRows
            .UserID = usr.UserID
            .ReminderAvgDBDataID = Results.ReminderAvgDBDataID
            .ReminderCountDBDataID = Results.ReminderCountDBDataID
            .ReminderCountThreshold = Results.ReminderCountThreshold
            .ReminderFrequencyDays = Results.ReminderFrequencyDays
            .ReminderLapsDaysAvg = Results.ReminderLapsDaysAvg
            .ReminderLapsDaysMax = Results.ReminderLapsDaysMax
            .ReminderMaxDBDataID = Results.ReminderMaxDBDataID
            .ReminderOnAvg = Results.ReminderOnAvg
            .ReminderOnCount = Results.ReminderOnCount
            .ReminderOnMax = Results.ReminderOnMax
          End With
          tmpUDBRow = SIS.WF.wfUserDBRows.InsertData(tmpUDBRow)
        Next
        mFrom += mCount
        uList = SIS.WF.wfUserDashboards.UZ_wfUserDashboardsSelectList(mFrom, mCount, "", False, "", "", DashboardID)
      Loop
      Return Results
    End Function
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal DashboardID As Int32, ByVal DBRows As Int32) As SIS.WF.wfDBRows
      RAWF(DashboardID, DBRows)
      Dim Results As SIS.WF.wfDBRows = wfDBRowsGetByID(DashboardID, DBRows)
      Dim tmpCols As List(Of SIS.WF.wfDBRowCols) = SIS.WF.wfDBRowCols.UZ_wfDBRowColsSelectList(0, 99999, "", False, "", DashboardID, DBRows)
      For Each col As SIS.WF.wfDBRowCols In tmpCols
        SIS.WF.wfDBRowCols.wfDBRowColsDelete(col)
      Next
      SIS.WF.wfDBRows.wfDBRowsDelete(Results)
      Return Results
    End Function

    Public Shared Function UZ_wfDBRowsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DashboardID As Int32) As List(Of SIS.WF.wfDBRows)
      Dim Results As List(Of SIS.WF.wfDBRows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "Sequence DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwf_LG_DBRowsSelectListSearch"
            Cmd.CommandText = "spwfDBRowsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwf_LG_DBRowsSelectListFilteres"
            Cmd.CommandText = "spwfDBRowsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DashboardID", SqlDbType.Int, 10, IIf(DashboardID = Nothing, 0, DashboardID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HTTPContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDBRows)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDBRows(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_wfDBRowsInsert(ByVal Record As SIS.WF.wfDBRows) As SIS.WF.wfDBRows
      Dim _Result As SIS.WF.wfDBRows = wfDBRowsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfDBRowsUpdate(ByVal Record As SIS.WF.wfDBRows) As SIS.WF.wfDBRows
      Dim _Result As SIS.WF.wfDBRows = wfDBRowsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfDBRowsDelete(ByVal Record As SIS.WF.wfDBRows) As Integer
      Dim _Result As Integer = wfDBRowsDelete(Record)
      Return _Result
    End Function
    Public Shared Function wfDBRowsSelectListByParentID(ByVal OrderBy As String, ByVal DashboardID As Int32, ByVal parentDBRowID As Integer) As List(Of SIS.WF.wfDBRows)
      Dim Results As List(Of SIS.WF.wfDBRows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DBRows DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwf_LG_DBRowsSelectListByParentRowID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DashboardID", SqlDbType.Int, 10, IIf(DashboardID = Nothing, 0, DashboardID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DBRowID", SqlDbType.Int, 10, IIf(DashboardID = Nothing, 0, parentDBRowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HTTPContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDBRows)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDBRows(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectRootDBRows(ByVal DashboardID As Int32) As List(Of SIS.WF.wfDBRows)
      Dim Results As List(Of SIS.WF.wfDBRows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwf_LG_DBRowsSelectListRoot"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DashboardID", SqlDbType.Int, 10, IIf(DashboardID = Nothing, 0, DashboardID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HTTPContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDBRows)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDBRows(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
