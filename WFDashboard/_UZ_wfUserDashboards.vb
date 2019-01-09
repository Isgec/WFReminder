Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel

Namespace SIS.WF
  Partial Public Class wfUserDashboards
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
    Public Shared Function UZ_wfUserDashboardsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal DashboardID As Int32) As List(Of SIS.WF.wfUserDashboards)
      Dim Results As List(Of SIS.WF.wfUserDashboards) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwf_LG_UserDashboardsSelectListSearch"
            Cmd.CommandText = "spwfUserDashboardsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwf_LG_UserDashboardsSelectListFilteres"
            Cmd.CommandText = "spwfUserDashboardsSelectListFilteres"
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
          Results = New List(Of SIS.WF.wfUserDashboards)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfUserDashboards(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_wfUserDashboardsInsert(ByVal Record As SIS.WF.wfUserDashboards) As SIS.WF.wfUserDashboards
      'Check all ready assigned
      Dim tmpUDB As SIS.WF.wfUserDashboards = SIS.WF.wfUserDashboards.wfUserDashboardsGetByID(Record.UserID, Record.DashboardID)
      If tmpUDB IsNot Nothing Then
        Throw New Exception("Authorization already given.")
      End If
      tmpUDB = wfUserDashboardsInsert(Record)
      '=====================================
      RefreshUserDBRows(tmpUDB)
      '=====================================
      Return tmpUDB
    End Function
    Public Shared Sub RefreshUserDBRows(ByVal tmpUDB As SIS.WF.wfUserDashboards)
      Dim tmpDBRows As List(Of SIS.WF.wfDBRows) = SIS.WF.wfDBRows.UZ_wfDBRowsSelectList(0, 99999, "", False, "", tmpUDB.DashboardID)

      For Each tmpR As SIS.WF.wfDBRows In tmpDBRows
        Dim Found As Boolean = True
        Dim tmpUR As SIS.WF.wfUserDBRows = SIS.WF.wfUserDBRows.wfUserDBRowsGetByID(tmpUDB.UserID, tmpUDB.DashboardID, tmpR.DBRows)
        If tmpUR Is Nothing Then
          Found = False
          tmpUR = New SIS.WF.wfUserDBRows
        End If
        If Not Found Then
          With tmpUR
            .ActionAllowed = tmpUDB.ActionAllowed
            .Active = tmpUDB.Active
            .DashboardID = tmpUDB.DashboardID
            .DBRows = tmpR.DBRows
            .UpdateAllowed = tmpUDB.UpdateAllowed
            .UserID = tmpUDB.UserID
            .ReminderCountThreshold = tmpR.ReminderCountThreshold
            .ReminderFrequencyDays = tmpR.ReminderFrequencyDays
            .ReminderLapsDaysAvg = tmpR.ReminderLapsDaysAvg
            .ReminderLapsDaysMax = tmpR.ReminderLapsDaysMax
            .ReminderOnAvg = tmpR.ReminderOnAvg
            .ReminderOnCount = tmpR.ReminderOnCount
            .ReminderOnMax = tmpR.ReminderOnMax
            If tmpR.ReminderCountDBDataID <> "" Then
              Dim xTmp As SIS.WF.wfDBData = tmpR.FK_WF_DBRows_ReminderCountDBDataID
              xTmp.DBDataID = 0
              If xTmp.FromERP Then
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & Convert.ToInt32(tmpUDB.UserID) & "'")
                'Similarly Replace DivisionID
              Else
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & tmpUDB.UserID & "'")
                'Similarly Replace DivisionID
              End If
              xTmp = SIS.WF.wfDBData.InsertData(xTmp)
              .ReminderCountDBDataID = xTmp.DBDataID
            End If
            If tmpR.ReminderAvgDBDataID <> "" Then
              Dim xTmp As SIS.WF.wfDBData = tmpR.FK_WF_DBRows_ReminderAVGDBDataID
              xTmp.DBDataID = 0
              If xTmp.FromERP Then
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & Convert.ToInt32(tmpUDB.UserID) & "'")
                'Similarly Replace DivisionID
              Else
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & tmpUDB.UserID & "'")
                'Similarly Replace DivisionID
              End If
              xTmp = SIS.WF.wfDBData.InsertData(xTmp)
              .ReminderAvgDBDataID = xTmp.DBDataID
            End If
            If tmpR.ReminderMaxDBDataID <> "" Then
              Dim xTmp As SIS.WF.wfDBData = tmpR.FK_WF_DBRows_ReminderMaxDBDataID
              xTmp.DBDataID = 0
              If xTmp.FromERP Then
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & Convert.ToInt32(tmpUDB.UserID) & "'")
                'Similarly Replace DivisionID
              Else
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & tmpUDB.UserID & "'")
                'Similarly Replace DivisionID
              End If
              xTmp = SIS.WF.wfDBData.InsertData(xTmp)
              .ReminderMaxDBDataID = xTmp.DBDataID
            End If
          End With
          tmpUR = SIS.WF.wfUserDBRows.InsertData(tmpUR)
        Else
          With tmpUR
            .Active = tmpUDB.Active
            '1. Count
            If .ReminderCountDBDataID <> "" Then
              SIS.WF.wfDBData.UZ_wfDBDataDelete(.FK_WF_UserDBRows_ReminderCountDBDataID)
            End If
            If tmpR.ReminderCountDBDataID <> "" Then
              Dim xTmp As SIS.WF.wfDBData = tmpR.FK_WF_DBRows_ReminderCountDBDataID
              xTmp.DBDataID = 0
              If xTmp.FromERP Then
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & Convert.ToInt32(tmpUDB.UserID) & "'")
                'Similarly Replace DivisionID
              Else
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & tmpUDB.UserID & "'")
                'Similarly Replace DivisionID
              End If
              xTmp = SIS.WF.wfDBData.InsertData(xTmp)
              .ReminderCountDBDataID = xTmp.DBDataID
            End If
            '2. Avg
            If .ReminderAvgDBDataID <> "" Then
              SIS.WF.wfDBData.UZ_wfDBDataDelete(.FK_WF_UserDBRows_ReminderAvgDBDataID)
            End If
            If tmpR.ReminderAvgDBDataID <> "" Then
              Dim xTmp As SIS.WF.wfDBData = tmpR.FK_WF_DBRows_ReminderAVGDBDataID
              xTmp.DBDataID = 0
              If xTmp.FromERP Then
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & Convert.ToInt32(tmpUDB.UserID) & "'")
                'Similarly Replace DivisionID
              Else
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & tmpUDB.UserID & "'")
                'Similarly Replace DivisionID
              End If
              xTmp = SIS.WF.wfDBData.InsertData(xTmp)
              .ReminderAvgDBDataID = xTmp.DBDataID
            End If
            '3. Max
            If .ReminderMaxDBDataID <> "" Then
              SIS.WF.wfDBData.UZ_wfDBDataDelete(.FK_WF_UserDBRows_ReminderMaxDBDataID)
            End If
            If tmpR.ReminderMaxDBDataID <> "" Then
              Dim xTmp As SIS.WF.wfDBData = tmpR.FK_WF_DBRows_ReminderMaxDBDataID
              xTmp.DBDataID = 0
              If xTmp.FromERP Then
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & Convert.ToInt32(tmpUDB.UserID) & "'")
                'Similarly Replace DivisionID
              Else
                xTmp.DataSQL = xTmp.DataSQL.Replace("@LoginID", "'" & tmpUDB.UserID & "'")
                'Similarly Replace DivisionID
              End If
              xTmp = SIS.WF.wfDBData.InsertData(xTmp)
              .ReminderMaxDBDataID = xTmp.DBDataID
            End If
          End With
          tmpUR = SIS.WF.wfUserDBRows.UpdateData(tmpUR)
        End If
      Next
      'Delete Removed Dashboard Rows
      Dim tmpUDBRows As List(Of SIS.WF.wfUserDBRows) = SIS.WF.wfUserDBRows.UZ_wfUserDBRowsSelectList(0, 99999, "", False, "", tmpUDB.UserID, tmpUDB.DashboardID)
      For Each tmpUDBR As SIS.WF.wfUserDBRows In tmpUDBRows
        Dim Found As Boolean = False
        For Each tmpR As SIS.WF.wfDBRows In tmpDBRows
          If tmpR.DBRows = tmpUDBR.DBRows Then
            Found = True
            Exit For
          End If
        Next
        If Not Found Then
          SIS.WF.wfUserDBRows.UZ_wfUserDBRowsDelete(tmpUDBR)
        End If
      Next
    End Sub
    Public Shared Function UZ_wfUserDashboardsUpdate(ByVal Record As SIS.WF.wfUserDashboards) As SIS.WF.wfUserDashboards
      Dim tmpUDB As SIS.WF.wfUserDashboards = wfUserDashboardsUpdate(Record)
      '=========================
      RefreshUserDBRows(tmpUDB)
      '=========================
      Return tmpUDB
    End Function
    Public Shared Function UZ_wfUserDashboardsDelete(ByVal Record As SIS.WF.wfUserDashboards) As Integer
      Dim tmpUDBRs As List(Of SIS.WF.wfUserDBRows) = SIS.WF.wfUserDBRows.UZ_wfUserDBRowsSelectList(0, 99999, "", False, "", Record.UserID, Record.DashboardID)
      For Each udbr As SIS.WF.wfUserDBRows In tmpUDBRs
        SIS.WF.wfUserDBRows.UZ_wfUserDBRowsDelete(udbr)
      Next
      Dim tmpDB As Integer = wfUserDashboardsDelete(Record)
      Return tmpDB
    End Function
  End Class
End Namespace
