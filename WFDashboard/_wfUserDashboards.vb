Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WF
  <DataObject()> _
  Partial Public Class wfUserDashboards
    Private Shared _RecordCount As Integer
    Private _UserID As String = ""
    Private _DashboardID As Int32 = 0
    Private _Active As Boolean = False
    Private _ActionAllowed As Boolean = False
    Private _UpdateAllowed As Boolean = False
    Private _aspnet_Users1_UserFullName As String = ""
    Private _WF_Dashboards2_DBDescription As String = ""
    Private _FK_WF_UserDashboards_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_WF_UserDashboards_DashboardID As SIS.WF.wfDashboards = Nothing
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
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property WF_Dashboards2_DBDescription() As String
      Get
        Return _WF_Dashboards2_DBDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_Dashboards2_DBDescription = ""
         Else
           _WF_Dashboards2_DBDescription = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _DashboardID.ToString.PadRight(10, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _UserID & "|" & _DashboardID
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
    Public Class PKwfUserDashboards
      Private _UserID As String = ""
      Private _DashboardID As Int32 = 0
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
    End Class
    Public ReadOnly Property FK_WF_UserDashboards_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_WF_UserDashboards_UserID Is Nothing Then
          _FK_WF_UserDashboards_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_WF_UserDashboards_UserID
      End Get
    End Property
    Public ReadOnly Property FK_WF_UserDashboards_DashboardID() As SIS.WF.wfDashboards
      Get
        If _FK_WF_UserDashboards_DashboardID Is Nothing Then
          _FK_WF_UserDashboards_DashboardID = SIS.WF.wfDashboards.wfDashboardsGetByID(_DashboardID)
        End If
        Return _FK_WF_UserDashboards_DashboardID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfUserDashboardsSelectList(ByVal OrderBy As String) As List(Of SIS.WF.wfUserDashboards)
      Dim Results As List(Of SIS.WF.wfUserDashboards) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfUserDashboardsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfUserDashboardsGetNewRecord() As SIS.WF.wfUserDashboards
      Return New SIS.WF.wfUserDashboards()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfUserDashboardsGetByID(ByVal UserID As String, ByVal DashboardID As Int32) As SIS.WF.wfUserDashboards
      Dim Results As SIS.WF.wfUserDashboards = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfUserDashboardsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,UserID.ToString.Length, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,DashboardID.ToString.Length, DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.WF.wfUserDashboards(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfUserDashboardsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal DashboardID As Int32) As List(Of SIS.WF.wfUserDashboards)
      Dim Results As List(Of SIS.WF.wfUserDashboards) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfUserDashboardsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfUserDashboardsSelectListFilteres"
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
    Public Shared Function wfUserDashboardsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal DashboardID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfUserDashboardsGetByID(ByVal UserID As String, ByVal DashboardID As Int32, ByVal Filter_UserID As String, ByVal Filter_DashboardID As Int32) As SIS.WF.wfUserDashboards
      Return wfUserDashboardsGetByID(UserID, DashboardID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function wfUserDashboardsInsert(ByVal Record As SIS.WF.wfUserDashboards) As SIS.WF.wfUserDashboards
      Dim _Rec As SIS.WF.wfUserDashboards = SIS.WF.wfUserDashboards.wfUserDashboardsGetNewRecord()
      With _Rec
        .UserID = Record.UserID
        .DashboardID = Record.DashboardID
        .Active = Record.Active
        .ActionAllowed = Record.ActionAllowed
        .UpdateAllowed = Record.UpdateAllowed
      End With
      Return SIS.WF.wfUserDashboards.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.WF.wfUserDashboards) As SIS.WF.wfUserDashboards
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfUserDashboardsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,11, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionAllowed",SqlDbType.Bit,3, Record.ActionAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateAllowed",SqlDbType.Bit,3, Record.UpdateAllowed)
          Cmd.Parameters.Add("@Return_UserID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_UserID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DashboardID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DashboardID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.UserID = Cmd.Parameters("@Return_UserID").Value
          Record.DashboardID = Cmd.Parameters("@Return_DashboardID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function wfUserDashboardsUpdate(ByVal Record As SIS.WF.wfUserDashboards) As SIS.WF.wfUserDashboards
      Dim _Rec As SIS.WF.wfUserDashboards = SIS.WF.wfUserDashboards.wfUserDashboardsGetByID(Record.UserID, Record.DashboardID)
      With _Rec
        .Active = Record.Active
        .ActionAllowed = Record.ActionAllowed
        .UpdateAllowed = Record.UpdateAllowed
      End With
      Return SIS.WF.wfUserDashboards.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.WF.wfUserDashboards) As SIS.WF.wfUserDashboards
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfUserDashboardsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DashboardID",SqlDbType.Int,11, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,11, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActionAllowed",SqlDbType.Bit,3, Record.ActionAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateAllowed",SqlDbType.Bit,3, Record.UpdateAllowed)
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
    Public Shared Function wfUserDashboardsDelete(ByVal Record As SIS.WF.wfUserDashboards) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfUserDashboardsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,Record.UserID.ToString.Length, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DashboardID",SqlDbType.Int,Record.DashboardID.ToString.Length, Record.DashboardID)
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
'    Autocomplete Method
    Public Shared Function SelectwfUserDashboardsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfUserDashboardsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(10, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.WF.wfUserDashboards = New SIS.WF.wfUserDashboards(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
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
