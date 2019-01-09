Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel

Namespace SIS.WF
  Partial Public Class wfUserDBRows
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
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
      Dim mRet As Boolean = False
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
    Public Shared Function UZ_wfUserDBRowsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal DashboardID As Int32) As List(Of SIS.WF.wfUserDBRows)
      Dim Results As List(Of SIS.WF.wfUserDBRows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwf_LG_UserDBRowsSelectListSearch"
            Cmd.CommandText = "spwfUserDBRowsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwf_LG_UserDBRowsSelectListFilteres"
            Cmd.CommandText = "spwfUserDBRowsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID", SqlDbType.NVarChar, 8, IIf(UserID Is Nothing, String.Empty, UserID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DashboardID", SqlDbType.Int, 10, IIf(DashboardID = Nothing, 0, DashboardID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HTTPContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfUserDBRows)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfUserDBRows(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_wfUserDBRowsInsert(ByVal Record As SIS.WF.wfUserDBRows) As SIS.WF.wfUserDBRows
      Dim _Result As SIS.WF.wfUserDBRows = wfUserDBRowsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfUserDBRowsUpdate(ByVal Record As SIS.WF.wfUserDBRows) As SIS.WF.wfUserDBRows
      Dim _Result As SIS.WF.wfUserDBRows = wfUserDBRowsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfUserDBRowsDelete(ByVal Record As SIS.WF.wfUserDBRows) As Integer
      If Record.ReminderCountDBDataID <> "" Then
        SIS.WF.wfDBData.UZ_wfDBDataDelete(Record.FK_WF_UserDBRows_ReminderCountDBDataID)
      End If
      If Record.ReminderAvgDBDataID <> "" Then
        SIS.WF.wfDBData.UZ_wfDBDataDelete(Record.FK_WF_UserDBRows_ReminderAvgDBDataID)
      End If
      If Record.ReminderMaxDBDataID <> "" Then
        SIS.WF.wfDBData.UZ_wfDBDataDelete(Record.FK_WF_UserDBRows_ReminderMaxDBDataID)
      End If
      Dim _Result As Integer = wfUserDBRowsDelete(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfUserDBRowsSelectListForAllUsers(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DBRowID As Integer, ByVal DashboardID As Int32) As List(Of SIS.WF.wfUserDBRows)
      Dim Results As List(Of SIS.WF.wfUserDBRows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwf_LG_UserDBRowsSelectListFilteresForAllUsers"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DBRowID", SqlDbType.Int, 10, IIf(DBRowID = Nothing, 0, DBRowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DashboardID", SqlDbType.Int, 10, IIf(DashboardID = Nothing, 0, DashboardID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HTTPContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfUserDBRows)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfUserDBRows(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Sub ReminderReset(ByVal DashboardID As Integer, ByVal DBRowID As Integer)
      Dim usr As String = HTTPContext.Current.Session("LoginID")
      Dim uDBR As SIS.WF.wfUserDBRows = SIS.WF.wfUserDBRows.wfUserDBRowsGetByID(usr, DashboardID, DBRowID)
      Dim sDBR As SIS.WF.wfDBRows = uDBR.FK_WF_UserDBRows_DBRows
      With uDBR
        .ReminderOnCount = sDBR.ReminderOnCount
        .ReminderCountThreshold = sDBR.ReminderCountThreshold
        .ReminderOnAvg = sDBR.ReminderOnAvg
        .ReminderLapsDaysAvg = sDBR.ReminderLapsDaysAvg
        .ReminderOnMax = sDBR.ReminderOnMax
        .ReminderLapsDaysMax = sDBR.ReminderLapsDaysMax
        .ReminderFrequencyDays = sDBR.ReminderFrequencyDays
      End With
      SIS.WF.wfUserDBRows.UpdateData(uDBR)
    End Sub
    Public Shared Sub ReminderUpdate(ByVal DashboardID As Integer, ByVal DBRowID As Integer, ByVal nv As String)
      Dim usr As String = HTTPContext.Current.Session("LoginID")
      Dim aNV() As String = nv.Split(",".ToCharArray)
      Dim ReminderOnCount As Boolean = Convert.ToBoolean(aNV(0))
      Dim ReminderCountThreshold As Integer = 0
      If aNV(1) <> "" Then
        Try
          ReminderCountThreshold = Convert.ToInt32(aNV(1))
        Catch ex As Exception
        End Try
      End If
      Dim ReminderOnAvg As Boolean = Convert.ToBoolean(aNV(2))
      Dim ReminderLapsDaysAvg As Integer = 0
      If aNV(3) <> "" Then
        Try
          ReminderLapsDaysAvg = Convert.ToInt32(aNV(3))
        Catch ex As Exception
        End Try
      End If
      Dim ReminderOnMax As Boolean = Convert.ToBoolean(aNV(4))
      Dim ReminderLapsDaysMax As Integer = 0
      If aNV(5) <> "" Then
        Try
          ReminderLapsDaysMax = Convert.ToInt32(aNV(5))
        Catch ex As Exception
        End Try
      End If
      Dim ReminderFrequencyDays As Integer = 0
      If aNV(6) <> "" Then
        Try
          ReminderFrequencyDays = Convert.ToInt32(aNV(6))
        Catch ex As Exception
        End Try
      End If
      Dim uDBR As SIS.WF.wfUserDBRows = SIS.WF.wfUserDBRows.wfUserDBRowsGetByID(usr, DashboardID, DBRowID)
      With uDBR
        If Not ReminderOnCount AndAlso Not ReminderOnAvg AndAlso Not ReminderOnMax Then
          .RunDate = ""
          .NextRunDate = ""
        Else
          If .ReminderFrequencyDays <> ReminderFrequencyDays Then
            .RunDate = Now.ToString("dd/MM/yyyy")
            .NextRunDate = Now.AddDays(ReminderFrequencyDays)
          End If
        End If
        .ReminderOnCount = ReminderOnCount
        .ReminderCountThreshold = ReminderCountThreshold
        .ReminderOnAvg = ReminderOnAvg
        .ReminderLapsDaysAvg = ReminderLapsDaysAvg
        .ReminderOnMax = ReminderOnMax
        .ReminderLapsDaysMax = ReminderLapsDaysMax
        .ReminderFrequencyDays = ReminderFrequencyDays
      End With
      SIS.WF.wfUserDBRows.UpdateData(uDBR)
    End Sub
    Public Shared Function getUserDBRowsForReminder(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer) As List(Of SIS.WF.wfUserDBRows)
      Dim Results As List(Of SIS.WF.wfUserDBRows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwf_LG_UserDBRowsForReminder"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfUserDBRows)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfUserDBRows(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function

  End Class
End Namespace
