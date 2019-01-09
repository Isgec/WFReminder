Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WF
  <DataObject()> _
  Partial Public Class wfDBRowCols
    Private Shared _RecordCount As Integer
    Private _DBCols As Int32 = 0
    Private _Description As String = ""
    Private _DBFieldName As String = ""
    Private _cssHeader As String = ""
    Private _cssCell As String = ""
    Private _Sequence As Int32 = 0
    Private _DashboardID As String = ""
    Private _DBRows As String = ""
    Private _LinkURL As String = ""
    Private _WF_Dashboards1_DBDescription As String = ""
    Private _WF_DBRows2_Description As String = ""
    Private _FK_WF_DBRowCols_DashboardID As SIS.WF.wfDashboards = Nothing
    Private _FK_WF_DBRowCols_DBRows As SIS.WF.wfDBRows = Nothing
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
    Public Property DBCols() As Int32
      Get
        Return _DBCols
      End Get
      Set(ByVal value As Int32)
        _DBCols = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Description = ""
         Else
           _Description = value
         End If
      End Set
    End Property
    Public Property DBFieldName() As String
      Get
        Return _DBFieldName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DBFieldName = ""
         Else
           _DBFieldName = value
         End If
      End Set
    End Property
    Public Property cssHeader() As String
      Get
        Return _cssHeader
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _cssHeader = ""
         Else
           _cssHeader = value
         End If
      End Set
    End Property
    Public Property cssCell() As String
      Get
        Return _cssCell
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _cssCell = ""
         Else
           _cssCell = value
         End If
      End Set
    End Property
    Public Property Sequence() As Int32
      Get
        Return _Sequence
      End Get
      Set(ByVal value As Int32)
        _Sequence = value
      End Set
    End Property
    Public Property DashboardID() As String
      Get
        Return _DashboardID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DashboardID = ""
         Else
           _DashboardID = value
         End If
      End Set
    End Property
    Public Property DBRows() As String
      Get
        Return _DBRows
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DBRows = ""
         Else
           _DBRows = value
         End If
      End Set
    End Property
    Public Property LinkURL() As String
      Get
        Return _LinkURL
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _LinkURL = ""
         Else
           _LinkURL = value
         End If
      End Set
    End Property
    Public Property WF_Dashboards1_DBDescription() As String
      Get
        Return _WF_Dashboards1_DBDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_Dashboards1_DBDescription = ""
         Else
           _WF_Dashboards1_DBDescription = value
         End If
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
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _DashboardID & "|" & _DBRows & "|" & _DBCols
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
    Public Class PKwfDBRowCols
      Private _DashboardID As Int32 = 0
      Private _DBRows As Int32 = 0
      Private _DBCols As Int32 = 0
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
      Public Property DBCols() As Int32
        Get
          Return _DBCols
        End Get
        Set(ByVal value As Int32)
          _DBCols = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_WF_DBRowCols_DashboardID() As SIS.WF.wfDashboards
      Get
        If _FK_WF_DBRowCols_DashboardID Is Nothing Then
          _FK_WF_DBRowCols_DashboardID = SIS.WF.wfDashboards.wfDashboardsGetByID(_DashboardID)
        End If
        Return _FK_WF_DBRowCols_DashboardID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRowCols_DBRows() As SIS.WF.wfDBRows
      Get
        If _FK_WF_DBRowCols_DBRows Is Nothing Then
          _FK_WF_DBRowCols_DBRows = SIS.WF.wfDBRows.wfDBRowsGetByID(_DashboardID, _DBRows)
        End If
        Return _FK_WF_DBRowCols_DBRows
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBRowColsSelectList(ByVal OrderBy As String) As List(Of SIS.WF.wfDBRowCols)
      Dim Results As List(Of SIS.WF.wfDBRowCols) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DBCols DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowColsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDBRowCols)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDBRowCols(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBRowColsGetNewRecord() As SIS.WF.wfDBRowCols
      Return New SIS.WF.wfDBRowCols()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBRowColsGetByID(ByVal DashboardID As Int32, ByVal DBRows As Int32, ByVal DBCols As Int32) As SIS.WF.wfDBRowCols
      Dim Results As SIS.WF.wfDBRowCols = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowColsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,DashboardID.ToString.Length, DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBRows",SqlDbType.Int,DBRows.ToString.Length, DBRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBCols",SqlDbType.Int,DBCols.ToString.Length, DBCols)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.WF.wfDBRowCols(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBRowColsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DashboardID As Int32, ByVal DBRows As Int32) As List(Of SIS.WF.wfDBRowCols)
      Dim Results As List(Of SIS.WF.wfDBRowCols) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DBCols DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfDBRowColsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfDBRowColsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DashboardID",SqlDbType.Int,10, IIf(DashboardID = Nothing, 0,DashboardID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DBRows",SqlDbType.Int,10, IIf(DBRows = Nothing, 0,DBRows))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDBRowCols)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDBRowCols(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function wfDBRowColsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DashboardID As Int32, ByVal DBRows As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBRowColsGetByID(ByVal DashboardID As Int32, ByVal DBRows As Int32, ByVal DBCols As Int32, ByVal Filter_DashboardID As Int32, ByVal Filter_DBRows As Int32) As SIS.WF.wfDBRowCols
      Return wfDBRowColsGetByID(DashboardID, DBRows, DBCols)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function wfDBRowColsInsert(ByVal Record As SIS.WF.wfDBRowCols) As SIS.WF.wfDBRowCols
      Dim _Rec As SIS.WF.wfDBRowCols = SIS.WF.wfDBRowCols.wfDBRowColsGetNewRecord()
      With _Rec
        .Description = Record.Description
        .DBFieldName = Record.DBFieldName
        .cssHeader = Record.cssHeader
        .cssCell = Record.cssCell
        .Sequence = Record.Sequence
        .DashboardID = Record.DashboardID
        .DBRows = Record.DBRows
        .LinkURL = Record.LinkURL
      End With
      Return SIS.WF.wfDBRowCols.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.WF.wfDBRowCols) As SIS.WF.wfDBRowCols
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowColsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBFieldName",SqlDbType.NVarChar,51, Iif(Record.DBFieldName= "" ,Convert.DBNull, Record.DBFieldName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cssHeader",SqlDbType.NVarChar,51, Iif(Record.cssHeader= "" ,Convert.DBNull, Record.cssHeader))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cssCell",SqlDbType.NVarChar,51, Iif(Record.cssCell= "" ,Convert.DBNull, Record.cssCell))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Record.Sequence)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,11, Iif(Record.DashboardID= "" ,Convert.DBNull, Record.DashboardID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBRows",SqlDbType.Int,11, Iif(Record.DBRows= "" ,Convert.DBNull, Record.DBRows))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkURL",SqlDbType.NVarChar,501, Iif(Record.LinkURL= "" ,Convert.DBNull, Record.LinkURL))
          Cmd.Parameters.Add("@Return_DashboardID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DashboardID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DBRows", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DBRows").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DBCols", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DBCols").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.DashboardID = Cmd.Parameters("@Return_DashboardID").Value
          Record.DBRows = Cmd.Parameters("@Return_DBRows").Value
          Record.DBCols = Cmd.Parameters("@Return_DBCols").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function wfDBRowColsUpdate(ByVal Record As SIS.WF.wfDBRowCols) As SIS.WF.wfDBRowCols
      Dim _Rec As SIS.WF.wfDBRowCols = SIS.WF.wfDBRowCols.wfDBRowColsGetByID(Record.DashboardID, Record.DBRows, Record.DBCols)
      With _Rec
        .Description = Record.Description
        .DBFieldName = Record.DBFieldName
        .cssHeader = Record.cssHeader
        .cssCell = Record.cssCell
        .Sequence = Record.Sequence
        .LinkURL = Record.LinkURL
      End With
      Return SIS.WF.wfDBRowCols.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.WF.wfDBRowCols) As SIS.WF.wfDBRowCols
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowColsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBCols",SqlDbType.Int,11, Record.DBCols)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DashboardID",SqlDbType.Int,11, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBRows",SqlDbType.Int,11, Record.DBRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBFieldName",SqlDbType.NVarChar,51, Iif(Record.DBFieldName= "" ,Convert.DBNull, Record.DBFieldName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cssHeader",SqlDbType.NVarChar,51, Iif(Record.cssHeader= "" ,Convert.DBNull, Record.cssHeader))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cssCell",SqlDbType.NVarChar,51, Iif(Record.cssCell= "" ,Convert.DBNull, Record.cssCell))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Record.Sequence)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,11, Iif(Record.DashboardID= "" ,Convert.DBNull, Record.DashboardID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBRows",SqlDbType.Int,11, Iif(Record.DBRows= "" ,Convert.DBNull, Record.DBRows))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkURL",SqlDbType.NVarChar,501, Iif(Record.LinkURL= "" ,Convert.DBNull, Record.LinkURL))
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
    Public Shared Function wfDBRowColsDelete(ByVal Record As SIS.WF.wfDBRowCols) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowColsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DashboardID",SqlDbType.Int,Record.DashboardID.ToString.Length, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBRows",SqlDbType.Int,Record.DBRows.ToString.Length, Record.DBRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBCols",SqlDbType.Int,Record.DBCols.ToString.Length, Record.DBCols)
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
    Public Shared Function SelectwfDBRowColsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowColsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.WF.wfDBRowCols = New SIS.WF.wfDBRowCols(Reader)
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
