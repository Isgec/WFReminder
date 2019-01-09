Imports System.Xml
Public Class ConfigFile
  Public Property IntervalInMiliSeconds As String = ""
  Public Property LogFolderPath As String = ""
  Public Property CreateLog As Boolean = False
  Public Property UseJoomlaLive As Boolean = False
  Public Property UseERPLive As Boolean = False
  Public Property ERPLive As String = ""
  Public Property ERPTest As String = ""
  Public Property JoomlaLive As String = ""
  Public Property JoomlaTest As String = ""
  'Derived Property
  Public Property StartupPath As String = ""
  Public Shared Function GetFile(ByVal FilePath As String) As ConfigFile
    Dim tmp As ConfigFile = Nothing
    If IO.File.Exists(FilePath) Then
      Dim rd As XmlReader = Nothing
      Try
        tmp = New ConfigFile
        rd = XmlReader.Create(FilePath)
        While rd.Read
          If rd.NodeType = XmlNodeType.Element Then
            Select Case rd.Name
              Case "IntervalInMiliSeconds"
                rd.Read()
                tmp.IntervalInMiliSeconds = rd.Value.Trim
              Case "LogFolderPath"
                rd.Read()
                tmp.LogFolderPath = rd.Value.Trim
              Case "CreateLog"
                Try
                  rd.Read()
                  tmp.CreateLog = Convert.ToBoolean(rd.Value.Trim)
                Catch ex As Exception
                End Try
              Case "UseJoomlaLive"
                Try
                  rd.Read()
                  tmp.UseJoomlaLive = Convert.ToBoolean(rd.Value.Trim)
                Catch ex As Exception
                End Try
              Case "UseERPLive"
                Try
                  rd.Read()
                  tmp.UseERPLive = Convert.ToBoolean(rd.Value.Trim)
                Catch ex As Exception
                End Try
              Case "ERPLive"
                rd.Read()
                tmp.ERPLive = rd.Value.Trim
              Case "ERPTest"
                rd.Read()
                tmp.ERPTest = rd.Value.Trim
              Case "JoomlaLive"
                rd.Read()
                tmp.JoomlaLive = rd.Value.Trim
              Case "JoomlaTest"
                rd.Read()
                tmp.JoomlaTest = rd.Value.Trim
            End Select
          End If
        End While
        rd.Close()
      Catch ex As Exception
      End Try
    End If
    Return tmp
  End Function
End Class
