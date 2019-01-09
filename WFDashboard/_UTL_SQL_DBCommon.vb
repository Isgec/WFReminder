Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.VisualBasic

Namespace SIS.SYS.SQLDatabase
  Partial Public Class DBCommon
    Implements IDisposable
    Public Shared Property UseJoomlaLive As Boolean = False
    Public Shared Property UseERPLive As Boolean = False
    Public Shared Property ERPLive As String = ""
    Public Shared Property ERPTest As String = ""
    Public Shared Property JoomlaLive As String = ""
    Public Shared Property JoomlaTest As String = ""

    Public Shared Function GetBaaNConnectionString() As String
      If UseERPLive Then
        Return ERPLive
      Else
        Return ERPTest
      End If
    End Function
    Public Shared Function GetConnectionString() As String
      If UseJoomlaLive Then
        Return JoomlaLive
      Else
        Return JoomlaTest
      End If
    End Function
    Public Shared Sub AddDBParameter(ByRef Cmd As SqlCommand, ByVal name As String, ByVal type As SqlDbType, ByVal size As Integer, ByVal value As Object)
      Dim Parm As SqlParameter = Cmd.CreateParameter()
      Parm.ParameterName = name
      Parm.SqlDbType = type
      Parm.Size = size
      Parm.Value = value
      Cmd.Parameters.Add(Parm)
    End Sub
#Region " IDisposable Support "
    Private disposedValue As Boolean = False    ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: free unmanaged resources when explicitly called
        End If

        ' TODO: free shared unmanaged resources
      End If
      Me.disposedValue = True
    End Sub
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class
End Namespace
