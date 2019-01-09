Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Imports System.Net.Mail
Imports WFDashboard
Imports System.Windows.Forms
Public Class JobProcessor
  Inherits TimerSupport
  Implements IDisposable

  Private Property _jpConfig As ConfigFile = Nothing
  Public Event JobStarted()
  Public Event JobStopped()
  Public Event ProcessedFile(ByVal slzFile As String)
  Private lst As Windows.Forms.ListBox = Nothing
  Private lbl As Windows.Forms.Label = Nothing
  Delegate Sub showMsg(ByVal str As String)
  Public Property jpConfig As ConfigFile
    Get
      Return _jpConfig
    End Get
    Set(value As ConfigFile)
      _jpConfig = value
      Me.Interval = _jpConfig.IntervalInMiliSeconds
      SIS.SYS.SQLDatabase.DBCommon.UseJoomlaLive = _jpConfig.UseJoomlaLive
      SIS.SYS.SQLDatabase.DBCommon.UseERPLive = _jpConfig.UseERPLive
      SIS.SYS.SQLDatabase.DBCommon.ERPTest = _jpConfig.ERPTest
      SIS.SYS.SQLDatabase.DBCommon.ERPLive = _jpConfig.ERPLive
      SIS.SYS.SQLDatabase.DBCommon.JoomlaTest = _jpConfig.JoomlaTest
      SIS.SYS.SQLDatabase.DBCommon.JoomlaLive = _jpConfig.JoomlaLive
    End Set
  End Property
  Public Sub msg(ByVal str As String)
    If lbl.InvokeRequired Then
      lbl.Invoke(New showMsg(AddressOf sMsg), str)
    End If
  End Sub
  Public Sub sMsg(ByVal str As String)
    lst.Items.Insert(0, str)
    Try
      lst.Items.RemoveAt(100)
    Catch ex As Exception
    End Try
    lbl.Text = str
  End Sub
  Public Overrides Sub Process()
    Try
      Dim mPage As Integer = 0
      Dim mSize As Integer = 20
      Dim I As Integer = 0
      Dim tmpRows As List(Of SIS.WF.wfUserDBRows) = SIS.WF.wfUserDBRows.getUserDBRowsForReminder(mPage, mSize)
      msg("====================")
      msg("Total Count : " & SIS.WF.wfUserDBRows.RecordCount)
      Do While tmpRows.Count > 0
        For Each tmpR As SIS.WF.wfUserDBRows In tmpRows
          I += 1
          msg("Processing : " & I & " => " & tmpR.FK_WF_UserDBRows_DBRows.Description)
          Try
            doRemind(tmpR)
            msg("Reminder Send : " & I & " => " & tmpR.FK_WF_UserDBRows_DBRows.Description)
          Catch ex As Exception
            msg("Error : " & ex.Message)
          End Try
          If IsStopping Then
            msg("Cancelled")
            Exit Do
          End If
        Next
        mPage += mSize
        tmpRows = SIS.WF.wfUserDBRows.getUserDBRowsForReminder(mPage, mSize)
      Loop
      If Not IsStopping Then
        msg("Processing Completed")
      End If
    Catch ex As Exception
      msg(ex.Message)
    End Try
  End Sub
  Private Enum RemindFor
    None = 0
    ForCount = 1
    ForAvg = 2
    ForMax = 3
  End Enum
  Private Sub doRemind(ByVal tmpR As SIS.WF.wfUserDBRows)
    Dim Threshold As Integer = 0
    Dim tmpFor As RemindFor = RemindFor.None
    If tmpR.ReminderOnCount Then
      If tmpR.ReminderCountDBDataID <> "" Then
        Threshold = SIS.WF.wfDBData.getThreshold(tmpR.ReminderCountDBDataID)
      End If
      If Threshold >= tmpR.ReminderCountThreshold Then
        tmpFor = RemindFor.ForCount
      End If
    End If
    If tmpFor = RemindFor.None Then
      If tmpR.ReminderOnAvg Then
        If tmpR.ReminderAvgDBDataID <> "" Then
          Threshold = SIS.WF.wfDBData.getThreshold(tmpR.ReminderAvgDBDataID)
        End If
        If Threshold >= tmpR.ReminderLapsDaysAvg Then
          tmpFor = RemindFor.ForAvg
        End If
      End If
    End If
    If tmpFor = RemindFor.None Then
      If tmpR.ReminderOnMax Then
        If tmpR.ReminderMaxDBDataID <> "" Then
          Threshold = SIS.WF.wfDBData.getThreshold(tmpR.ReminderMaxDBDataID)
        End If
        If Threshold >= tmpR.ReminderLapsDaysMax Then
          tmpFor = RemindFor.ForMax
        End If
      End If
    End If
    If tmpFor <> RemindFor.None Then
      Try
        SendReminder(tmpR, Threshold, tmpFor)
        UpdateNextRun(tmpR)
      Catch ex As Exception
      End Try
    Else
      msg("No Reminder to send")
    End If
  End Sub
  Private Sub UpdateNextRun(ByVal tmpR As SIS.WF.wfUserDBRows)
    msg("Updating Next RunDate")
    tmpR.RunDate = DateAndTime.Today
    If tmpR.ReminderFrequencyDays <= 0 Then
      tmpR.ReminderFrequencyDays = 1
    End If
    tmpR.NextRunDate = DateAndTime.Today.AddDays(tmpR.ReminderFrequencyDays)
    tmpR = SIS.WF.wfUserDBRows.UpdateData(tmpR)
    msg("Updated Next RunDate")
  End Sub
  Private Sub SendReminder(ByVal tmpR As SIS.WF.wfUserDBRows, ByVal Threshold As Integer, ByVal tmpFor As RemindFor)
    Dim tRow As SIS.WF.wfDBRows = tmpR.FK_WF_UserDBRows_DBRows
    '1. EMail Alert
    If tRow.ReminderAlertEMail Then
      'Get Target E-Mail IDs
      Dim aTo As New ArrayList
      If tRow.ReminderEMailDBDataID <> "" Then
        Dim tmpData As SIS.WF.wfDBData = tRow.FK_WF_DBRows_ReminderEMailDBDataID
        If tmpData.IsList Then
          Dim tmpTo() As String = tmpData.DataSQL.Split(",".ToCharArray)
          For Each x As String In tmpTo
            aTo.Add(x)
          Next
        Else
          Dim dt As DataTable = SIS.WF.wfDBData.getDataSet(tRow.ReminderEMailDBDataID, tmpR.UserID)
          For Each x As DataRow In dt.Rows
            aTo.Add(x(0))
          Next
        End If
      End If
      If aTo.Count > 0 Then
        'Target E-Mail IDs Found
        Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
        Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
        oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
        With oMsg
          .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
          .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
          For Each str As String In aTo
            Dim ad As MailAddress = New MailAddress(str.Trim, str.Trim)
            If Not .To.Contains(ad) Then
              .To.Add(ad)
            End If
          Next

          '.Subject = "Reminder : " & tRow.Description
          .Subject = "Reminder from Workflow Dashboard :" & tRow.Description
        End With
        With oMsg
          If .To.Count <= 0 Then
            .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
          End If
          .IsBodyHtml = True
          Dim Limit As String = ""
          Dim sb As StringBuilder = New StringBuilder()
          sb.Append("<table>")
          sb.Append("<tr><td colspan=""4"" style=""color:red;""><b>")
          Select Case tmpFor
            Case RemindFor.ForCount
              sb.Append("Count of data in current status exceeded the threshold defined for reminder.")
              Limit = tmpR.ReminderCountThreshold
            Case RemindFor.ForAvg
              sb.Append("Average Laps days in current status exceeded the threshold defined for reminder.")
              Limit = tmpR.ReminderLapsDaysAvg
            Case RemindFor.ForMax
              sb.Append("Laps days in current status exceeded the Maximum threshold defined for reminder.")
              Limit = tmpR.ReminderLapsDaysMax
          End Select
          sb.Append("</b></td></tr>")
          sb.Append("<tr>")
          sb.Append("<td style=""text-align:center;""><b>Threshold</b>")
          sb.Append("</td>")
          sb.Append("<td  style=""text-align:center;"">")
          sb.Append(Limit)
          sb.Append("</td>")
          sb.Append("<td style=""text-align:center;""><b>Current Value</b>")
          sb.Append("</td>")
          sb.Append("<td style=""text-align:center;"">")
          sb.Append(Threshold)
          sb.Append("</td>")
          sb.Append("</tr>")
          sb.Append("</table>")

          sb.Append("<br/>")
          sb.Append("<br/>")
          If tRow.IsDV Then
            If tRow.DVDBDataID <> "" Then
              sb.Append(SIS.WF.wfDBData.GetPlaneHTMLTableFromDT(SIS.WF.wfDBData.getDataSet(tRow.DVDBDataID, tmpR.UserID)))
            End If
          End If

          Dim Header As String = ""
          Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
          Header = Header & "<head>"
          Header = Header & "<title></title>"
          Header = Header & "<style>"
          Header = Header & "table{"

          Header = Header & "border: solid 1pt black;"
          Header = Header & "border-collapse:collapse;"
          Header = Header & "font-family: Tahoma;}"

          Header = Header & "th{background-color:darkcyan;color:aliceblue;"
          Header = Header & "border: solid 1pt black;"
          Header = Header & "font-family: Tahoma;"
          Header = Header & "font-size: 12px;"
          Header = Header & "vertical-align:top;}"

          Header = Header & "td{"
          Header = Header & "border: solid 1pt black;"
          Header = Header & "font-family: Tahoma;"
          Header = Header & "font-size: 12px;"
          Header = Header & "vertical-align:top;}"

          Header = Header & "</style>"
          Header = Header & "</head>"
          Header = Header & "<body>"
          Header = Header & sb.ToString
          Header = Header & "</body></html>"
          .Body = Header
        End With
        Try
          oClient.Send(oMsg)
        Catch ex As Exception
        End Try

      End If
    End If
    '2. SMS Alert Not Implemented
  End Sub
  Public Overrides Sub Started()
    msg("Checking Configuration.")
    'Create Objects
    RaiseEvent JobStarted()
  End Sub

  Public Overrides Sub Stopped()
    'Destroy Objects
    msg("Stopped")
    RaiseEvent JobStopped()
  End Sub
  Sub New(ByVal lt As Windows.Forms.ListBox, ByVal lb As Windows.Forms.Label)
    lst = lt
    lbl = lb
  End Sub

  Sub New()
    'dummy
  End Sub

#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not disposedValue Then
      If disposing Then
        ' TODO: dispose managed state (managed objects).
        lst.Dispose()
        lbl.Dispose()
      End If

      ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
      ' TODO: set large fields to null.
    End If
    disposedValue = True
  End Sub

  ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
  'Protected Overrides Sub Finalize()
  '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
  '    Dispose(False)
  '    MyBase.Finalize()
  'End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    Dispose(True)
    ' TODO: uncomment the following line if Finalize() is overridden above.
    ' GC.SuppressFinalize(Me)
  End Sub
#End Region
End Class
