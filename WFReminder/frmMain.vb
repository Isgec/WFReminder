Public Class frmMain
  Delegate Sub ThreadedSub(ByVal lt As ListBox, ByVal lb As Label)
  Delegate Sub ThreadedShow(ByVal slzFile As String)
  Delegate Sub ThreadedNone()
  Dim WithEvents jp As JobProcessor = Nothing
  Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
    cmdStart.Enabled = False
    cmdStart.Text = "Loading..."
    ListBox1.Items.Clear()
    Dim tmp As ThreadedSub = AddressOf Start
    tmp.BeginInvoke(ListBox1, Label1, Nothing, Nothing)
  End Sub
  Private Sub Start(ByVal lt As ListBox, ByVal lb As Label)
    jp = New JobProcessor(lt, lb)
    jp.jpConfig = ConfigFile.GetFile(Application.StartupPath & "\Settings.xml")
    jp.jpConfig.StartupPath = Application.StartupPath
    jp.Start()
  End Sub

  Private Sub cmdStop_Click(sender As Object, e As EventArgs) Handles cmdStop.Click
    cmdStop.Enabled = False
    cmdStop.Text = "Closing..."
    jp.StopJob()
  End Sub

  Private Sub jp_JobStarted() Handles jp.JobStarted
    If cmdStart.InvokeRequired Then
      cmdStart.Invoke(New ThreadedNone(AddressOf jp_JobStarted))
    Else
      cmdStart.Enabled = False
      cmdStart.Text = "Start"
      cmdStop.Enabled = True
      'Other Initializations
    End If
  End Sub
  Private Sub jp_JobStopped() Handles jp.JobStopped
    If cmdStop.InvokeRequired Then
      cmdStop.Invoke(New ThreadedNone(AddressOf jp_JobStopped))
    Else
      cmdStop.Enabled = False
      cmdStop.Text = "Stop"
      cmdStart.Enabled = True
    End If
  End Sub
End Class
