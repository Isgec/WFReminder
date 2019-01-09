Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WF
  <DataObject()> _
  Partial Public Class wfDBData
    Private Shared _RecordCount As Integer
    Private _DBDataID As Int32 = 0
    Private _Description As String = ""
    Private _IsProcedure As Boolean = False
    Private _FromERP As Boolean = False
    Private _IsList As Boolean = False
    Private _IsErpAFSCall As Boolean = False
    Private _AFSDllName As String = ""
    Private _AFSFunctionName As String = ""
    Private _AFSParameters As String = ""
    Private _DataSQL As String = ""
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
    Public Property DBDataID() As Int32
      Get
        Return _DBDataID
      End Get
      Set(ByVal value As Int32)
        _DBDataID = value
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
    Public Property IsProcedure() As Boolean
      Get
        Return _IsProcedure
      End Get
      Set(ByVal value As Boolean)
        _IsProcedure = value
      End Set
    End Property
    Public Property FromERP() As Boolean
      Get
        Return _FromERP
      End Get
      Set(ByVal value As Boolean)
        _FromERP = value
      End Set
    End Property
    Public Property IsList() As Boolean
      Get
        Return _IsList
      End Get
      Set(ByVal value As Boolean)
        _IsList = value
      End Set
    End Property
    Public Property IsErpAFSCall() As Boolean
      Get
        Return _IsErpAFSCall
      End Get
      Set(ByVal value As Boolean)
        _IsErpAFSCall = value
      End Set
    End Property
    Public Property AFSDllName() As String
      Get
        Return _AFSDllName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AFSDllName = ""
         Else
           _AFSDllName = value
         End If
      End Set
    End Property
    Public Property AFSFunctionName() As String
      Get
        Return _AFSFunctionName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AFSFunctionName = ""
         Else
           _AFSFunctionName = value
         End If
      End Set
    End Property
    Public Property AFSParameters() As String
      Get
        Return _AFSParameters
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AFSParameters = ""
         Else
           _AFSParameters = value
         End If
      End Set
    End Property
    Public Property DataSQL() As String
      Get
        Return _DataSQL
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DataSQL = ""
         Else
           _DataSQL = value
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
        Return _DBDataID
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
    Public Class PKwfDBData
      Private _DBDataID As Int32 = 0
      Public Property DBDataID() As Int32
        Get
          Return _DBDataID
        End Get
        Set(ByVal value As Int32)
          _DBDataID = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBDataSelectList(ByVal OrderBy As String) As List(Of SIS.WF.wfDBData)
      Dim Results As List(Of SIS.WF.wfDBData) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DBDataID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBDataSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDBData)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDBData(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBDataGetNewRecord() As SIS.WF.wfDBData
      Return New SIS.WF.wfDBData()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBDataGetByID(ByVal DBDataID As Int32) As SIS.WF.wfDBData
      Dim Results As SIS.WF.wfDBData = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBDataSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBDataID",SqlDbType.Int,DBDataID.ToString.Length, DBDataID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.WF.wfDBData(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBDataSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.WF.wfDBData)
      Dim Results As List(Of SIS.WF.wfDBData) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DBDataID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfDBDataSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfDBDataSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDBData)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDBData(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function wfDBDataSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function wfDBDataInsert(ByVal Record As SIS.WF.wfDBData) As SIS.WF.wfDBData
      Dim _Rec As SIS.WF.wfDBData = SIS.WF.wfDBData.wfDBDataGetNewRecord()
      With _Rec
        .Description = Record.Description
        .IsProcedure = Record.IsProcedure
        .FromERP = Record.FromERP
        .IsList = Record.IsList
        .IsErpAFSCall = Record.IsErpAFSCall
        .AFSDllName = Record.AFSDllName
        .AFSFunctionName = Record.AFSFunctionName
        .AFSParameters = Record.AFSParameters
        .DataSQL = Record.DataSQL
      End With
      Return SIS.WF.wfDBData.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.WF.wfDBData) As SIS.WF.wfDBData
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBDataInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsProcedure",SqlDbType.Bit,3, Record.IsProcedure)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromERP",SqlDbType.Bit,3, Record.FromERP)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsList",SqlDbType.Bit,3, Record.IsList)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsErpAFSCall",SqlDbType.Bit,3, Record.IsErpAFSCall)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AFSDllName",SqlDbType.NVarChar,151, Iif(Record.AFSDllName= "" ,Convert.DBNull, Record.AFSDllName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AFSFunctionName",SqlDbType.NVarChar,151, Iif(Record.AFSFunctionName= "" ,Convert.DBNull, Record.AFSFunctionName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AFSParameters",SqlDbType.NVarChar,251, Iif(Record.AFSParameters= "" ,Convert.DBNull, Record.AFSParameters))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DataSQL",SqlDbType.NVarChar,4001, Iif(Record.DataSQL= "" ,Convert.DBNull, Record.DataSQL))
          Cmd.Parameters.Add("@Return_DBDataID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DBDataID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.DBDataID = Cmd.Parameters("@Return_DBDataID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function wfDBDataUpdate(ByVal Record As SIS.WF.wfDBData) As SIS.WF.wfDBData
      Dim _Rec As SIS.WF.wfDBData = SIS.WF.wfDBData.wfDBDataGetByID(Record.DBDataID)
      With _Rec
        .Description = Record.Description
        .IsProcedure = Record.IsProcedure
        .FromERP = Record.FromERP
        .IsList = Record.IsList
        .IsErpAFSCall = Record.IsErpAFSCall
        .AFSDllName = Record.AFSDllName
        .AFSFunctionName = Record.AFSFunctionName
        .AFSParameters = Record.AFSParameters
        .DataSQL = Record.DataSQL
      End With
      Return SIS.WF.wfDBData.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.WF.wfDBData) As SIS.WF.wfDBData
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBDataUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBDataID",SqlDbType.Int,11, Record.DBDataID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsProcedure",SqlDbType.Bit,3, Record.IsProcedure)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromERP",SqlDbType.Bit,3, Record.FromERP)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsList",SqlDbType.Bit,3, Record.IsList)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsErpAFSCall",SqlDbType.Bit,3, Record.IsErpAFSCall)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AFSDllName",SqlDbType.NVarChar,151, Iif(Record.AFSDllName= "" ,Convert.DBNull, Record.AFSDllName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AFSFunctionName",SqlDbType.NVarChar,151, Iif(Record.AFSFunctionName= "" ,Convert.DBNull, Record.AFSFunctionName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AFSParameters",SqlDbType.NVarChar,251, Iif(Record.AFSParameters= "" ,Convert.DBNull, Record.AFSParameters))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DataSQL",SqlDbType.NVarChar,4001, Iif(Record.DataSQL= "" ,Convert.DBNull, Record.DataSQL))
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
    Public Shared Function wfDBDataDelete(ByVal Record As SIS.WF.wfDBData) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBDataDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBDataID",SqlDbType.Int,Record.DBDataID.ToString.Length, Record.DBDataID)
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
    Public Shared Function SelectwfDBDataAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBDataAutoCompleteList"
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
            Dim Tmp As SIS.WF.wfDBData = New SIS.WF.wfDBData(Reader)
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
