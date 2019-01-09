Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WF
  <DataObject()> _
  Partial Public Class wfUserDBRows
    Private Shared _RecordCount As Integer
    Private _UserID As String = ""
    Private _DashboardID As Int32 = 0
    Private _DBRows As Int32 = 0
    Private _Active As Boolean = False
    Private _ActionAllowed As Boolean = False
    Private _UpdateAllowed As Boolean = False
    Private _RunDate As String = ""
    Private _NextRunDate As String = ""
    Private _ReminderMaxDBDataID As String = ""
    Private _ReminderLapsDaysMax As Int32 = 0
    Private _ReminderFrequencyDays As Int32 = 0
    Private _ReminderCountDBDataID As String = ""
    Private _ReminderOnCount As Boolean = False
    Private _ReminderOnAvg As Boolean = False
    Private _ReminderCountThreshold As Int32 = 0
    Private _ReminderLapsDaysAvg As Int32 = 0
    Private _ReminderOnMax As Boolean = False
    Private _ReminderAvgDBDataID As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _WF_DBRows2_Description As String = ""
    Private _WF_UserDashboards3_DashboardID As Int32 = 0
    Private _WF_DBData4_Description As String = ""
    Private _WF_DBData5_Description As String = ""
    Private _WF_DBData6_Description As String = ""
    Private _FK_WF_UserDBRows_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_WF_UserDBRows_DBRows As SIS.WF.wfDBRows = Nothing
    Private _FK_WF_UserDBRows_UserDashboard As SIS.WF.wfUserDashboards = Nothing
    Private _FK_WF_UserDBRows_ReminderCountDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_UserDBRows_ReminderAvgDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_UserDBRows_ReminderMaxDBDataID As SIS.WF.wfDBData = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property UserID() As String
      Get
        Return _UserID
      End Get
      Set(ByVal value As String)
        _UserID = value
      End Set
    End Property
    Public Property DashboardID() As Int32
      Get
        Return _DashboardID
      End Get
      Set(ByVal value As Int32)
        _DashboardID = value
      End Set
    End Property
    Public Property DBRows() As Int32
      Get
        Return _DBRows
      End Get
      Set(ByVal value As Int32)
        _DBRows = value
      End Set
    End Property
    Public Property Active() As Boolean
      Get
        Return _Active
      End Get
      Set(ByVal value As Boolean)
        _Active = value
      End Set
    End Property
    Public Property ActionAllowed() As Boolean
      Get
        Return _ActionAllowed
      End Get
      Set(ByVal value As Boolean)
        _ActionAllowed = value
      End Set
    End Property
    Public Property UpdateAllowed() As Boolean
      Get
        Return _UpdateAllowed
      End Get
      Set(ByVal value As Boolean)
        _UpdateAllowed = value
      End Set
    End Property
    Public Property RunDate() As String
      Get
        If Not _RunDate = String.Empty Then
          Return Convert.ToDateTime(_RunDate).ToString("dd/MM/yyyy")
        End If
        Return _RunDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RunDate = ""
         Else
           _RunDate = value
         End If
      End Set
    End Property
    Public Property NextRunDate() As String
      Get
        If Not _NextRunDate = String.Empty Then
          Return Convert.ToDateTime(_NextRunDate).ToString("dd/MM/yyyy")
        End If
        Return _NextRunDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _NextRunDate = ""
         Else
           _NextRunDate = value
         End If
      End Set
    End Property
    Public Property ReminderMaxDBDataID() As String
      Get
        Return _ReminderMaxDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReminderMaxDBDataID = ""
         Else
           _ReminderMaxDBDataID = value
         End If
      End Set
    End Property
    Public Property ReminderLapsDaysMax() As Int32
      Get
        Return _ReminderLapsDaysMax
      End Get
      Set(ByVal value As Int32)
        _ReminderLapsDaysMax = value
      End Set
    End Property
    Public Property ReminderFrequencyDays() As Int32
      Get
        Return _ReminderFrequencyDays
      End Get
      Set(ByVal value As Int32)
        _ReminderFrequencyDays = value
      End Set
    End Property
    Public Property ReminderCountDBDataID() As String
      Get
        Return _ReminderCountDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReminderCountDBDataID = ""
         Else
           _ReminderCountDBDataID = value
         End If
      End Set
    End Property
    Public Property ReminderOnCount() As Boolean
      Get
        Return _ReminderOnCount
      End Get
      Set(ByVal value As Boolean)
        _ReminderOnCount = value
      End Set
    End Property
    Public Property ReminderOnAvg() As Boolean
      Get
        Return _ReminderOnAvg
      End Get
      Set(ByVal value As Boolean)
        _ReminderOnAvg = value
      End Set
    End Property
    Public Property ReminderCountThreshold() As Int32
      Get
        Return _ReminderCountThreshold
      End Get
      Set(ByVal value As Int32)
        _ReminderCountThreshold = value
      End Set
    End Property
    Public Property ReminderLapsDaysAvg() As Int32
      Get
        Return _ReminderLapsDaysAvg
      End Get
      Set(ByVal value As Int32)
        _ReminderLapsDaysAvg = value
      End Set
    End Property
    Public Property ReminderOnMax() As Boolean
      Get
        Return _ReminderOnMax
      End Get
      Set(ByVal value As Boolean)
        _ReminderOnMax = value
      End Set
    End Property
    Public Property ReminderAvgDBDataID() As String
      Get
        Return _ReminderAvgDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReminderAvgDBDataID = ""
         Else
           _ReminderAvgDBDataID = value
         End If
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property WF_DBRows2_Description() As String
      Get
        Return _WF_DBRows2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBRows2_Description = ""
         Else
           _WF_DBRows2_Description = value
         End If
      End Set
    End Property
    Public Property WF_UserDashboards3_DashboardID() As Int32
      Get
        Return _WF_UserDashboards3_DashboardID
      End Get
      Set(ByVal value As Int32)
        _WF_UserDashboards3_DashboardID = value
      End Set
    End Property
    Public Property WF_DBData4_Description() As String
      Get
        Return _WF_DBData4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData4_Description = ""
         Else
           _WF_DBData4_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData5_Description() As String
      Get
        Return _WF_DBData5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData5_Description = ""
         Else
           _WF_DBData5_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData6_Description() As String
      Get
        Return _WF_DBData6_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData6_Description = ""
         Else
           _WF_DBData6_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _UserID & "|" & _DashboardID & "|" & _DBRows
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKwfUserDBRows
      Private _UserID As String = ""
      Private _DashboardID As Int32 = 0
      Private _DBRows As Int32 = 0
      Public Property UserID() As String
        Get
          Return _UserID
        End Get
        Set(ByVal value As String)
          _UserID = value
        End Set
      End Property
      Public Property DashboardID() As Int32
        Get
          Return _DashboardID
        End Get
        Set(ByVal value As Int32)
          _DashboardID = value
        End Set
      End Property
      Public Property DBRows() As Int32
        Get
          Return _DBRows
        End Get
        Set(ByVal value As Int32)
          _DBRows = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_WF_UserDBRows_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_WF_UserDBRows_UserID Is Nothing Then
          _FK_WF_UserDBRows_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_WF_UserDBRows_UserID
      End Get
    End Property
    Public ReadOnly Property FK_WF_UserDBRows_DBRows() As SIS.WF.wfDBRows
      Get
        If _FK_WF_UserDBRows_DBRows Is Nothing Then
          _FK_WF_UserDBRows_DBRows = SIS.WF.wfDBRows.wfDBRowsGetByID(_DashboardID, _DBRows)
        End If
        Return _FK_WF_UserDBRows_DBRows
      End Get
    End Property
    Public ReadOnly Property FK_WF_UserDBRows_UserDashboard() As SIS.WF.wfUserDashboards
      Get
        If _FK_WF_UserDBRows_UserDashboard Is Nothing Then
          _FK_WF_UserDBRows_UserDashboard = SIS.WF.wfUserDashboards.wfUserDashboardsGetByID(_UserID, _DashboardID)
        End If
        Return _FK_WF_UserDBRows_UserDashboard
      End Get
    End Property
    Public ReadOnly Property FK_WF_UserDBRows_ReminderCountDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_UserDBRows_ReminderCountDBDataID Is Nothing Then
          _FK_WF_UserDBRows_ReminderCountDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_ReminderCountDBDataID)
        End If
        Return _FK_WF_UserDBRows_ReminderCountDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_UserDBRows_ReminderAvgDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_UserDBRows_ReminderAvgDBDataID Is Nothing Then
          _FK_WF_UserDBRows_ReminderAvgDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_ReminderAvgDBDataID)
        End If
        Return _FK_WF_UserDBRows_ReminderAvgDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_UserDBRows_ReminderMaxDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_UserDBRows_ReminderMaxDBDataID Is Nothing Then
          _FK_WF_UserDBRows_ReminderMaxDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_ReminderMaxDBDataID)
        End If
        Return _FK_WF_UserDBRows_ReminderMaxDBDataID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfUserDBRowsGetNewRecord() As SIS.WF.wfUserDBRows
      Return New SIS.WF.wfUserDBRows()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfUserDBRowsGetByID(ByVal UserID As String, ByVal DashboardID As Int32, ByVal DBRows As Int32) As SIS.WF.wfUserDBRows
      Dim Results As SIS.WF.wfUserDBRows = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfUserDBRowsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,UserID.ToString.Length, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,DashboardID.ToString.Length, DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBRows",SqlDbType.Int,DBRows.ToString.Length, DBRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.WF.wfUserDBRows(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfUserDBRowsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal DashboardID As Int32) As List(Of SIS.WF.wfUserDBRows)
      Dim Results As List(Of SIS.WF.wfUserDBRows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfUserDBRowsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfUserDBRowsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID",SqlDbType.NVarChar,8, IIf(UserID Is Nothing, String.Empty,UserID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DashboardID",SqlDbType.Int,10, IIf(DashboardID = Nothing, 0,DashboardID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function wfUserDBRowsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal DashboardID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfUserDBRowsGetByID(ByVal UserID As String, ByVal DashboardID As Int32, ByVal DBRows As Int32, ByVal Filter_UserID As String, ByVal Filter_DashboardID As Int32) As SIS.WF.wfUserDBRows
      Return wfUserDBRowsGetByID(UserID, DashboardID, DBRows)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function wfUserDBRowsInsert(ByVal Record As SIS.WF.wfUserDBRows) As SIS.WF.wfUserDBRows
      Dim _Rec As SIS.WF.wfUserDBRows = SIS.WF.wfUserDBRows.wfUserDBRowsGetNewRecord()
      With _Rec
        .UserID = Record.UserID
        .DashboardID = Record.DashboardID
        .DBRows = Record.DBRows
        .Active = Record.Active
        .ActionAllowed = Record.ActionAllowed
        .UpdateAllowed = Record.UpdateAllowed
        .RunDate = Record.RunDate
        .NextRunDate = Record.NextRunDate
        .ReminderMaxDBDataID = Record.ReminderMaxDBDataID
        .ReminderLapsDaysMax = Record.ReminderLapsDaysMax
        .ReminderFrequencyDays = Record.ReminderFrequencyDays
        .ReminderCountDBDataID = Record.ReminderCountDBDataID
        .ReminderOnCount = Record.ReminderOnCount
        .ReminderOnAvg = Record.ReminderOnAvg
        .ReminderCountThreshold = Record.ReminderCountThreshold
        .ReminderLapsDaysAvg = Record.ReminderLapsDaysAvg
        .ReminderOnMax = Record.ReminderOnMax
        .ReminderAvgDBDataID = Record.ReminderAvgDBDataID
      End With
      Return SIS.WF.wfUserDBRows.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.WF.wfUserDBRows) As SIS.WF.wfUserDBRows
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfUserDBRowsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,11, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBRows",SqlDbType.Int,11, Record.DBRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionAllowed",SqlDbType.Bit,3, Record.ActionAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateAllowed",SqlDbType.Bit,3, Record.UpdateAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RunDate",SqlDbType.DateTime,21, Iif(Record.RunDate= "" ,Convert.DBNull, Record.RunDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NextRunDate",SqlDbType.DateTime,21, Iif(Record.NextRunDate= "" ,Convert.DBNull, Record.NextRunDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderMaxDBDataID",SqlDbType.Int,11, Iif(Record.ReminderMaxDBDataID= "" ,Convert.DBNull, Record.ReminderMaxDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderLapsDaysMax",SqlDbType.Int,11, Record.ReminderLapsDaysMax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderFrequencyDays",SqlDbType.Int,11, Record.ReminderFrequencyDays)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderCountDBDataID",SqlDbType.Int,11, Iif(Record.ReminderCountDBDataID= "" ,Convert.DBNull, Record.ReminderCountDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnCount",SqlDbType.Bit,3, Record.ReminderOnCount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnAvg",SqlDbType.Bit,3, Record.ReminderOnAvg)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderCountThreshold",SqlDbType.Int,11, Record.ReminderCountThreshold)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderLapsDaysAvg",SqlDbType.Int,11, Record.ReminderLapsDaysAvg)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnMax",SqlDbType.Bit,3, Record.ReminderOnMax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderAvgDBDataID",SqlDbType.Int,11, Iif(Record.ReminderAvgDBDataID= "" ,Convert.DBNull, Record.ReminderAvgDBDataID))
          Cmd.Parameters.Add("@Return_UserID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_UserID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DashboardID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DashboardID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DBRows", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DBRows").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.UserID = Cmd.Parameters("@Return_UserID").Value
          Record.DashboardID = Cmd.Parameters("@Return_DashboardID").Value
          Record.DBRows = Cmd.Parameters("@Return_DBRows").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function wfUserDBRowsUpdate(ByVal Record As SIS.WF.wfUserDBRows) As SIS.WF.wfUserDBRows
      Dim _Rec As SIS.WF.wfUserDBRows = SIS.WF.wfUserDBRows.wfUserDBRowsGetByID(Record.UserID, Record.DashboardID, Record.DBRows)
      With _Rec
        .Active = Record.Active
        .ActionAllowed = Record.ActionAllowed
        .UpdateAllowed = Record.UpdateAllowed
        .RunDate = Record.RunDate
        .NextRunDate = Record.NextRunDate
        .ReminderMaxDBDataID = Record.ReminderMaxDBDataID
        .ReminderLapsDaysMax = Record.ReminderLapsDaysMax
        .ReminderFrequencyDays = Record.ReminderFrequencyDays
        .ReminderCountDBDataID = Record.ReminderCountDBDataID
        .ReminderOnCount = Record.ReminderOnCount
        .ReminderOnAvg = Record.ReminderOnAvg
        .ReminderCountThreshold = Record.ReminderCountThreshold
        .ReminderLapsDaysAvg = Record.ReminderLapsDaysAvg
        .ReminderOnMax = Record.ReminderOnMax
        .ReminderAvgDBDataID = Record.ReminderAvgDBDataID
      End With
      Return SIS.WF.wfUserDBRows.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.WF.wfUserDBRows) As SIS.WF.wfUserDBRows
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfUserDBRowsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DashboardID",SqlDbType.Int,11, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBRows",SqlDbType.Int,11, Record.DBRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,11, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBRows",SqlDbType.Int,11, Record.DBRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionAllowed",SqlDbType.Bit,3, Record.ActionAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateAllowed",SqlDbType.Bit,3, Record.UpdateAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RunDate",SqlDbType.DateTime,21, Iif(Record.RunDate= "" ,Convert.DBNull, Record.RunDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NextRunDate",SqlDbType.DateTime,21, Iif(Record.NextRunDate= "" ,Convert.DBNull, Record.NextRunDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderMaxDBDataID",SqlDbType.Int,11, Iif(Record.ReminderMaxDBDataID= "" ,Convert.DBNull, Record.ReminderMaxDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderLapsDaysMax",SqlDbType.Int,11, Record.ReminderLapsDaysMax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderFrequencyDays",SqlDbType.Int,11, Record.ReminderFrequencyDays)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderCountDBDataID",SqlDbType.Int,11, Iif(Record.ReminderCountDBDataID= "" ,Convert.DBNull, Record.ReminderCountDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnCount",SqlDbType.Bit,3, Record.ReminderOnCount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnAvg",SqlDbType.Bit,3, Record.ReminderOnAvg)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderCountThreshold",SqlDbType.Int,11, Record.ReminderCountThreshold)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderLapsDaysAvg",SqlDbType.Int,11, Record.ReminderLapsDaysAvg)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnMax",SqlDbType.Bit,3, Record.ReminderOnMax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderAvgDBDataID",SqlDbType.Int,11, Iif(Record.ReminderAvgDBDataID= "" ,Convert.DBNull, Record.ReminderAvgDBDataID))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function wfUserDBRowsDelete(ByVal Record As SIS.WF.wfUserDBRows) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfUserDBRowsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,Record.UserID.ToString.Length, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DashboardID",SqlDbType.Int,Record.DashboardID.ToString.Length, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBRows",SqlDbType.Int,Record.DBRows.ToString.Length, Record.DBRows)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
