Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WF
  <DataObject()> _
  Partial Public Class wfDashboards
    Private Shared _RecordCount As Integer
    Private _DashboardID As Int32 = 0
    Private _DBDescription As String = ""
    Private _DBTitle As String = ""
    Private _TitleStyle As String = ""
    Private _Active As Boolean = False
    Private _InitializedByMe As Boolean = False
    Private _DBIconID As String = ""
    Private _NotToDraw As Boolean = False
    Private _DBRowTypeID As String = ""
    Private _GraphTypeID As String = ""
    Private _ConvertForGraph As Boolean = False
    Private _WF_DBRowTypes1_Description As String = ""
    Private _WF_GraphTypes2_Description As String = ""
    Private _WF_DBIcons3_IconName As String = ""
    Private _FK_WF_Dashboards_DBRowTypeID As SIS.WF.wfDBRowTypes = Nothing
    Private _FK_WF_Dashboards_GraphTypeID As SIS.WF.wfGraphTypes = Nothing
    Private _FK_WF_Dashboards_DBIconID As SIS.WF.wfDBIcons = Nothing
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
    Public Property DashboardID() As Int32
      Get
        Return _DashboardID
      End Get
      Set(ByVal value As Int32)
        _DashboardID = value
      End Set
    End Property
    Public Property DBDescription() As String
      Get
        Return _DBDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DBDescription = ""
         Else
           _DBDescription = value
         End If
      End Set
    End Property
    Public Property DBTitle() As String
      Get
        Return _DBTitle
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DBTitle = ""
         Else
           _DBTitle = value
         End If
      End Set
    End Property
    Public Property TitleStyle() As String
      Get
        Return _TitleStyle
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TitleStyle = ""
         Else
           _TitleStyle = value
         End If
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
    Public Property InitializedByMe() As Boolean
      Get
        Return _InitializedByMe
      End Get
      Set(ByVal value As Boolean)
        _InitializedByMe = value
      End Set
    End Property
    Public Property DBIconID() As String
      Get
        Return _DBIconID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DBIconID = ""
         Else
           _DBIconID = value
         End If
      End Set
    End Property
    Public Property NotToDraw() As Boolean
      Get
        Return _NotToDraw
      End Get
      Set(ByVal value As Boolean)
        _NotToDraw = value
      End Set
    End Property
    Public Property DBRowTypeID() As String
      Get
        Return _DBRowTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DBRowTypeID = ""
         Else
           _DBRowTypeID = value
         End If
      End Set
    End Property
    Public Property GraphTypeID() As String
      Get
        Return _GraphTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _GraphTypeID = ""
         Else
           _GraphTypeID = value
         End If
      End Set
    End Property
    Public Property ConvertForGraph() As Boolean
      Get
        Return _ConvertForGraph
      End Get
      Set(ByVal value As Boolean)
        _ConvertForGraph = value
      End Set
    End Property
    Public Property WF_DBRowTypes1_Description() As String
      Get
        Return _WF_DBRowTypes1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBRowTypes1_Description = ""
         Else
           _WF_DBRowTypes1_Description = value
         End If
      End Set
    End Property
    Public Property WF_GraphTypes2_Description() As String
      Get
        Return _WF_GraphTypes2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_GraphTypes2_Description = ""
         Else
           _WF_GraphTypes2_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBIcons3_IconName() As String
      Get
        Return _WF_DBIcons3_IconName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBIcons3_IconName = ""
         Else
           _WF_DBIcons3_IconName = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _DBDescription.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _DashboardID
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
    Public Class PKwfDashboards
      Private _DashboardID As Int32 = 0
      Public Property DashboardID() As Int32
        Get
          Return _DashboardID
        End Get
        Set(ByVal value As Int32)
          _DashboardID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_WF_Dashboards_DBRowTypeID() As SIS.WF.wfDBRowTypes
      Get
        If _FK_WF_Dashboards_DBRowTypeID Is Nothing Then
          _FK_WF_Dashboards_DBRowTypeID = SIS.WF.wfDBRowTypes.wfDBRowTypesGetByID(_DBRowTypeID)
        End If
        Return _FK_WF_Dashboards_DBRowTypeID
      End Get
    End Property
    Public ReadOnly Property FK_WF_Dashboards_GraphTypeID() As SIS.WF.wfGraphTypes
      Get
        If _FK_WF_Dashboards_GraphTypeID Is Nothing Then
          _FK_WF_Dashboards_GraphTypeID = SIS.WF.wfGraphTypes.wfGraphTypesGetByID(_GraphTypeID)
        End If
        Return _FK_WF_Dashboards_GraphTypeID
      End Get
    End Property
    Public ReadOnly Property FK_WF_Dashboards_DBIconID() As SIS.WF.wfDBIcons
      Get
        If _FK_WF_Dashboards_DBIconID Is Nothing Then
          _FK_WF_Dashboards_DBIconID = SIS.WF.wfDBIcons.wfDBIconsGetByID(_DBIconID)
        End If
        Return _FK_WF_Dashboards_DBIconID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDashboardsSelectList(ByVal OrderBy As String) As List(Of SIS.WF.wfDashboards)
      Dim Results As List(Of SIS.WF.wfDashboards) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DashboardID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDashboardsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDashboards)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDashboards(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDashboardsGetNewRecord() As SIS.WF.wfDashboards
      Return New SIS.WF.wfDashboards()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDashboardsGetByID(ByVal DashboardID As Int32) As SIS.WF.wfDashboards
      Dim Results As SIS.WF.wfDashboards = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDashboardsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,DashboardID.ToString.Length, DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.WF.wfDashboards(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDashboardsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.WF.wfDashboards)
      Dim Results As List(Of SIS.WF.wfDashboards) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DashboardID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfDashboardsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfDashboardsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDashboards)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDashboards(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function wfDashboardsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function wfDashboardsInsert(ByVal Record As SIS.WF.wfDashboards) As SIS.WF.wfDashboards
      Dim _Rec As SIS.WF.wfDashboards = SIS.WF.wfDashboards.wfDashboardsGetNewRecord()
      With _Rec
        .DBDescription = Record.DBDescription
        .DBTitle = Record.DBTitle
        .TitleStyle = Record.TitleStyle
        .Active = Record.Active
        .InitializedByMe = Record.InitializedByMe
        .DBIconID = Record.DBIconID
        .NotToDraw = Record.NotToDraw
        .DBRowTypeID = Record.DBRowTypeID
        .GraphTypeID = Record.GraphTypeID
        .ConvertForGraph = Record.ConvertForGraph
      End With
      Return SIS.WF.wfDashboards.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.WF.wfDashboards) As SIS.WF.wfDashboards
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDashboardsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBDescription",SqlDbType.NVarChar,51, Iif(Record.DBDescription= "" ,Convert.DBNull, Record.DBDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBTitle",SqlDbType.NVarChar,101, Iif(Record.DBTitle= "" ,Convert.DBNull, Record.DBTitle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TitleStyle",SqlDbType.NVarChar,251, Iif(Record.TitleStyle= "" ,Convert.DBNull, Record.TitleStyle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitializedByMe",SqlDbType.Bit,3, Record.InitializedByMe)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBIconID",SqlDbType.Int,11, Iif(Record.DBIconID= "" ,Convert.DBNull, Record.DBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotToDraw",SqlDbType.Bit,3, Record.NotToDraw)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBRowTypeID",SqlDbType.Int,11, Iif(Record.DBRowTypeID= "" ,Convert.DBNull, Record.DBRowTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GraphTypeID",SqlDbType.Int,11, Iif(Record.GraphTypeID= "" ,Convert.DBNull, Record.GraphTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConvertForGraph",SqlDbType.Bit,3, Record.ConvertForGraph)
          Cmd.Parameters.Add("@Return_DashboardID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DashboardID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.DashboardID = Cmd.Parameters("@Return_DashboardID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function wfDashboardsUpdate(ByVal Record As SIS.WF.wfDashboards) As SIS.WF.wfDashboards
      Dim _Rec As SIS.WF.wfDashboards = SIS.WF.wfDashboards.wfDashboardsGetByID(Record.DashboardID)
      With _Rec
        .DBDescription = Record.DBDescription
        .DBTitle = Record.DBTitle
        .TitleStyle = Record.TitleStyle
        .Active = Record.Active
        .InitializedByMe = Record.InitializedByMe
        .DBIconID = Record.DBIconID
        .NotToDraw = Record.NotToDraw
        .DBRowTypeID = Record.DBRowTypeID
        .GraphTypeID = Record.GraphTypeID
        .ConvertForGraph = Record.ConvertForGraph
      End With
      Return SIS.WF.wfDashboards.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.WF.wfDashboards) As SIS.WF.wfDashboards
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDashboardsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DashboardID",SqlDbType.Int,11, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBDescription",SqlDbType.NVarChar,51, Iif(Record.DBDescription= "" ,Convert.DBNull, Record.DBDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBTitle",SqlDbType.NVarChar,101, Iif(Record.DBTitle= "" ,Convert.DBNull, Record.DBTitle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TitleStyle",SqlDbType.NVarChar,251, Iif(Record.TitleStyle= "" ,Convert.DBNull, Record.TitleStyle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitializedByMe",SqlDbType.Bit,3, Record.InitializedByMe)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBIconID",SqlDbType.Int,11, Iif(Record.DBIconID= "" ,Convert.DBNull, Record.DBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotToDraw",SqlDbType.Bit,3, Record.NotToDraw)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBRowTypeID",SqlDbType.Int,11, Iif(Record.DBRowTypeID= "" ,Convert.DBNull, Record.DBRowTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GraphTypeID",SqlDbType.Int,11, Iif(Record.GraphTypeID= "" ,Convert.DBNull, Record.GraphTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConvertForGraph",SqlDbType.Bit,3, Record.ConvertForGraph)
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
    Public Shared Function wfDashboardsDelete(ByVal Record As SIS.WF.wfDashboards) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDashboardsDelete"
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
    Public Shared Function SelectwfDashboardsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDashboardsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.WF.wfDashboards = New SIS.WF.wfDashboards(Reader)
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
