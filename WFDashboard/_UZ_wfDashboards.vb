Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel

Namespace SIS.WF
  Partial Public Class wfDashboards
    Public ReadOnly Property GetDBDescription As String
      Get
        Dim mRet As String = DBDescription
        If DBTitle <> "" Then
          mRet = DBTitle
        End If
        Return mRet
      End Get
    End Property
    Public ReadOnly Property GetIcon As String
      Get
        Dim mRet As String = "fa fa-2x fa-address-card"
        If DBIconID <> "" Then
          mRet = "fa fa-2x fa-" & FK_WF_Dashboards_DBIconID.IconName
        End If
        Return mRet
      End Get
    End Property
    Public ReadOnly Property GetIconStyle As String
      Get
        Dim mRet As String = "font-size:24px;color:lightblue;text-shadow:2px 2px 4px #000000;"
        If DBIconID <> "" Then
          If FK_WF_Dashboards_DBIconID.IconStyle <> "" Then
            mRet = FK_WF_Dashboards_DBIconID.IconStyle
          End If
        End If
        Return mRet
      End Get
    End Property
    Public ReadOnly Property GetCPHStyle As String
      Get
        Dim mRet As String = "cph cph-gray"
        If TitleStyle <> "" Then
          mRet = "cph " & TitleStyle
        End If
        Return mRet
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If Active Then
        If InitializedByMe Then
          mRet = Drawing.Color.Crimson
        Else
          mRet = Drawing.Color.Green
        End If
      End If
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
    Public Shared Function DAWF(ByVal DashboardID As Int32) As SIS.WF.wfDashboards
      Dim Results As SIS.WF.wfDashboards = wfDashboardsGetByID(DashboardID)
      Dim mFrom As Integer = 0
      Dim mCount As Integer = 50
      Dim uList As List(Of SIS.WF.wfUserDashboards) = SIS.WF.wfUserDashboards.UZ_wfUserDashboardsSelectList(mFrom, mCount, "", False, "", "", DashboardID)
      Do While uList.Count > 0
        For Each usr As SIS.WF.wfUserDashboards In uList
          usr.Active = False
          SIS.WF.wfUserDashboards.UpdateData(usr)
        Next
        mFrom += mCount
        uList = SIS.WF.wfUserDashboards.UZ_wfUserDashboardsSelectList(mFrom, mCount, "", False, "", "", DashboardID)
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
    Public Shared Function AAWF(ByVal DashboardID As Int32) As SIS.WF.wfDashboards
      Dim Results As SIS.WF.wfDashboards = wfDashboardsGetByID(DashboardID)
      Dim mFrom As Integer = 0
      Dim mCount As Integer = 50
      Dim uList As List(Of SIS.WF.wfUserDashboards) = SIS.WF.wfUserDashboards.UZ_wfUserDashboardsSelectList(mFrom, mCount, "", False, "", "", DashboardID)
      Do While uList.Count > 0
        For Each usr As SIS.WF.wfUserDashboards In uList
          usr.Active = True
          SIS.WF.wfUserDashboards.UpdateData(usr)
        Next
        mFrom += mCount
        uList = SIS.WF.wfUserDashboards.UZ_wfUserDashboardsSelectList(mFrom, mCount, "", False, "", "", DashboardID)
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
    Public Shared Function RAWF(ByVal DashboardID As Int32) As SIS.WF.wfDashboards
      Dim Results As SIS.WF.wfDashboards = wfDashboardsGetByID(DashboardID)
      Dim mFrom As Integer = 0
      Dim mCount As Integer = 50

      Dim uList As List(Of SIS.WF.wfUserDashboards) = SIS.WF.wfUserDashboards.UZ_wfUserDashboardsSelectList(mFrom, mCount, "", False, "", "", DashboardID)
      Do While uList.Count > 0
        For Each usr As SIS.WF.wfUserDashboards In uList
          usr.Active = False
          SIS.WF.wfUserDashboards.UZ_wfUserDashboardsDelete(usr)
        Next
        mFrom += mCount
        uList = SIS.WF.wfUserDashboards.UZ_wfUserDashboardsSelectList(mFrom, mCount, "", False, "", "", DashboardID)
      Loop
      Return Results
    End Function
    Public ReadOnly Property SHWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SHWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SHWF(ByVal DashboardID As Int32) As SIS.WF.wfDashboards
      Dim Results As SIS.WF.wfDashboards = wfDashboardsGetByID(DashboardID)
      Dim mFrom As Integer = 0
      Dim mCount As Integer = 50
      Dim uList As List(Of SIS.WF.wfUserDashboards) = SIS.WF.wfUserDashboards.UZ_wfUserDashboardsSelectList(mFrom, mCount, "", False, "", "", DashboardID)
      Do While uList.Count > 0
        For Each usr As SIS.WF.wfUserDashboards In uList
          usr.Active = Results.Active
          usr = SIS.WF.wfUserDashboards.UZ_wfUserDashboardsUpdate(usr)
        Next
        mFrom += mCount
        uList = SIS.WF.wfUserDashboards.UZ_wfUserDashboardsSelectList(mFrom, mCount, "", False, "", "", DashboardID)
      Loop
      Return Results
    End Function
    Public ReadOnly Property SRWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SRWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SRWF(ByVal DashboardID As Int32) As SIS.WF.wfDashboards
      Dim Results As SIS.WF.wfDashboards = wfDashboardsGetByID(DashboardID)
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
    Public Shared Function DeleteWF(ByVal DashboardID As Int32) As SIS.WF.wfDashboards
      'Revoke from All Users
      RAWF(DashboardID)
      '===================
      Dim tmpDB As SIS.WF.wfDashboards = wfDashboardsGetByID(DashboardID)
      Dim tmpDBRs As List(Of SIS.WF.wfDBRows) = SIS.WF.wfDBRows.UZ_wfDBRowsSelectList(0, 99999, "", False, "", DashboardID)
      For Each dbr As SIS.WF.wfDBRows In tmpDBRs
        Dim tmpCols As List(Of SIS.WF.wfDBRowCols) = SIS.WF.wfDBRowCols.UZ_wfDBRowColsSelectList(0, 99999, "", False, "", dbr.DashboardID, dbr.DBRows)
        For Each col As SIS.WF.wfDBRowCols In tmpCols
          SIS.WF.wfDBRowCols.wfDBRowColsDelete(col)
        Next
        SIS.WF.wfDBRows.wfDBRowsDelete(dbr)
      Next
      SIS.WF.wfDashboards.wfDashboardsDelete(tmpDB)
      Return tmpDB
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
    Public Shared Function CopyWF(ByVal DashboardID As Int32) As SIS.WF.wfDashboards
      Dim tmpDB As SIS.WF.wfDashboards = wfDashboardsGetByID(DashboardID)
      tmpDB.DashboardID = 0
      tmpDB = SIS.WF.wfDashboards.InsertData(tmpDB)
      Dim tmpDBRs As List(Of SIS.WF.wfDBRows) = SIS.WF.wfDBRows.UZ_wfDBRowsSelectList(0, 99999, "", False, "", DashboardID)
      For Each dbr As SIS.WF.wfDBRows In tmpDBRs
        Dim tmpCols As List(Of SIS.WF.wfDBRowCols) = SIS.WF.wfDBRowCols.UZ_wfDBRowColsSelectList(0, 99999, "", False, "", dbr.DashboardID, dbr.DBRows)
        dbr.DashboardID = tmpDB.DashboardID
        dbr.DBRows = 0
        dbr = SIS.WF.wfDBRows.InsertData(dbr)
        For Each col As SIS.WF.wfDBRowCols In tmpCols
          col.DashboardID = dbr.DashboardID
          col.DBRows = dbr.DBRows
          col.DBCols = 0
          col = SIS.WF.wfDBRowCols.InsertData(col)
        Next
      Next
      Return tmpDB
    End Function
    Public Shared Function UZ_wfDashboardsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.WF.wfDashboards)
      Dim Results As List(Of SIS.WF.wfDashboards) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DashboardID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfDashboardsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwf_LG_DashboardsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HTTPContext.Current.Session("LoginID"))
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
    Public Shared Function UZ_wfDashboardsInsert(ByVal Record As SIS.WF.wfDashboards) As SIS.WF.wfDashboards
      Dim _Result As SIS.WF.wfDashboards = wfDashboardsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfDashboardsUpdate(ByVal Record As SIS.WF.wfDashboards) As SIS.WF.wfDashboards
      Dim _Result As SIS.WF.wfDashboards = wfDashboardsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfDashboardsDelete(ByVal Record As SIS.WF.wfDashboards) As Integer
      Dim _Result As Integer = wfDashboardsDelete(Record)
      Return _Result
    End Function
  End Class
End Namespace
