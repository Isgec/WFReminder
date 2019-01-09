Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.Text

Namespace SIS.WF
  Partial Public Class wfDBData
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
    Public Shared Function CopyWF(ByVal DBDataID As Int32) As SIS.WF.wfDBData
      Dim Results As SIS.WF.wfDBData = wfDBDataGetByID(DBDataID)
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
    Public Shared Function DeleteWF(ByVal DBDataID As Int32) As SIS.WF.wfDBData
      Dim Results As SIS.WF.wfDBData = wfDBDataGetByID(DBDataID)
      Return Results
    End Function
    Public Shared Function UZ_wfDBDataSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.WF.wfDBData)
      Dim Results As List(Of SIS.WF.wfDBData) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DBDataID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwf_LG_DBDataSelectListSearch"
            Cmd.CommandText = "spwfDBDataSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwf_LG_DBDataSelectListFilteres"
            Cmd.CommandText = "spwfDBDataSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HTTPContext.Current.Session("LoginID"))
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
    Public Shared Function UZ_wfDBDataInsert(ByVal Record As SIS.WF.wfDBData) As SIS.WF.wfDBData
      Dim _Result As SIS.WF.wfDBData = wfDBDataInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfDBDataUpdate(ByVal Record As SIS.WF.wfDBData) As SIS.WF.wfDBData
      Dim _Result As SIS.WF.wfDBData = wfDBDataUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfDBDataDelete(ByVal Record As SIS.WF.wfDBData) As Integer
      Dim _Result As Integer = wfDBDataDelete(Record)
      Return _Result
    End Function
    Public Shared Function getDataSet(ByVal dataID As Integer, Optional ByVal LoginID As String = "") As DataTable
      Return getDataSet(SIS.WF.wfDBData.wfDBDataGetByID(dataID), LoginID)
    End Function
    Public Shared Function getDataSet(ByVal dbData As wfDBData, Optional ByVal LoginID As String = "") As DataTable
      If LoginID = "" Then
        LoginID = HTTPContext.Current.Session("LoginID")
      End If
      Dim Results As DataTable = Nothing
      If dbData.FromERP Then
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            If dbData.IsProcedure Then
              Cmd.CommandType = CommandType.StoredProcedure
              Cmd.CommandText = dbData.DataSQL
              SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, Convert.ToInt32(LoginID))
            Else
              Cmd.CommandType = CommandType.Text
              Cmd.CommandText = dbData.DataSQL.Replace("@LoginID", Convert.ToInt32(LoginID))
            End If
            Results = New DataTable
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            Results.Load(Reader)
            Reader.Close()
          End Using
        End Using
      Else
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            If dbData.IsProcedure Then
              Cmd.CommandType = CommandType.StoredProcedure
              Cmd.CommandText = dbData.DataSQL
              SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, LoginID)
            Else
              Cmd.CommandType = CommandType.Text
              Cmd.CommandText = dbData.DataSQL.Replace("@LoginID", LoginID)
            End If
            Results = New DataTable
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            Results.Load(Reader)
            Reader.Close()
          End Using
        End Using
      End If
      Return Results
    End Function

    Public Shared Function getThreshold(ByVal dataID As Integer) As Integer
      Return getThreshold(SIS.WF.wfDBData.wfDBDataGetByID(dataID))
    End Function
    Public Shared Function getThreshold(ByVal dbData As wfDBData) As Integer
      Dim Result As Integer = 0
      If dbData.FromERP Then
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            If dbData.IsProcedure Then
              Cmd.CommandType = CommandType.StoredProcedure
              Cmd.CommandText = dbData.DataSQL
            Else
              Cmd.CommandType = CommandType.Text
              Cmd.CommandText = dbData.DataSQL
            End If
            Con.Open()
            Result = Cmd.ExecuteScalar
          End Using
        End Using
      Else
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            If dbData.IsProcedure Then
              Cmd.CommandType = CommandType.StoredProcedure
              Cmd.CommandText = dbData.DataSQL
            Else
              Cmd.CommandType = CommandType.Text
              Cmd.CommandText = dbData.DataSQL
            End If
            Con.Open()
            Result = Cmd.ExecuteScalar
          End Using
        End Using
      End If
      Return Result
    End Function
    Public Shared Function GetPlaneHTMLTableFromDT(ByVal dt As DataTable) As String
      If dt Is Nothing Then Return "No Data Found"
      Dim tbl As New Table
      If dt.Rows.Count > 0 Then
        'Create Tabel Header
        Dim trh As New TableHeaderRow
        trh.TableSection = TableRowSection.TableHeader
        For Each column As DataColumn In dt.Columns
          If column.ColumnName.ToLower = "wf_pk" Then Continue For
          Dim tch As New TableHeaderCell
          tch.Text = column.ColumnName
          trh.Cells.Add(tch)
        Next
        If trh.Controls.Count > 0 Then tbl.Rows.Add(trh)
      End If
      'Create Rows
      For Each row As DataRow In dt.Rows
        Dim tr As New TableRow
        tr.TableSection = TableRowSection.TableBody
        For Each column As DataColumn In dt.Columns
          If column.ColumnName.ToLower = "wf_pk" Then
            Continue For
          End If
          Dim td As New TableCell
          td.Text = row(column.ColumnName)
          tr.Controls.Add(td)
        Next
        tbl.Rows.Add(tr)
      Next

      Dim sb As StringBuilder = New StringBuilder()
      Dim sw As IO.StringWriter = New IO.StringWriter(sb)
      Dim writer As Web.UI.HtmlTextWriter = New Web.UI.HtmlTextWriter(sw)
      Try
        tbl.RenderControl(writer)
      Catch ex As Exception
      End Try
      Return sb.ToString
    End Function
  End Class
End Namespace
