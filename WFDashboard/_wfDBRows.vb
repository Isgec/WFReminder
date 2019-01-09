Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WF
  <DataObject()> _
  Partial Public Class wfDBRows
    Private Shared _RecordCount As Integer
    Private _DashboardID As Int32 = 0
    Private _DBRows As Int32 = 0
    Private _Description As String = ""
    Private _DBTitle As String = ""
    Private _Sequence As Int32 = 0
    Private _DBRowTypeID As String = ""
    Private _TitleStyle As String = ""
    Private _cssRow As String = ""
    Private _ShowHeader As Boolean = False
    Private _GraphTypeID As String = ""
    Private _ConvertForGraph As Boolean = False
    Private _NotToDraw As Boolean = False
    Private _ParentDBRows As String = ""
    Private _MainDBDataID As String = ""
    Private _MainDBIconID As String = ""
    Private _IsDV As Boolean = False
    Private _DVTypeID As String = ""
    Private _DVDescription As String = ""
    Private _DVDBIconID As String = ""
    Private _DVDBDataID As String = ""
    Private _IsDVUpdatable As Boolean = False
    Private _IsDVRemarks As Boolean = False
    Private _DVRemarksText As String = ""
    Private _DVRemarksDBIconID As String = ""
    Private _IsDVForward As Boolean = False
    Private _DVForwardText As String = ""
    Private _DVFDBIconID As String = ""
    Private _DVForwardDBDataID As String = ""
    Private _IsDVReverse As Boolean = False
    Private _DVReverseText As String = ""
    Private _DVRDBIconID As String = ""
    Private _DVReverseDBDataID As String = ""
    Private _IsDVAttachment As Boolean = False
    Private _IsDVAttachmentMulti As Boolean = False
    Private _DVAttachmentText As String = ""
    Private _DVAttachmentDBIconID As String = ""
    Private _DVFAlert As Boolean = False
    Private _DVFAlertEMail As Boolean = False
    Private _DVFASubject As String = ""
    Private _DVFABodyTemplate As String = ""
    Private _DVFEMailDBDataID As String = ""
    Private _DVFAlertSMS As Boolean = False
    Private _DVFASMSText As String = ""
    Private _DVFSMSDBDataID As String = ""
    Private _DVRAlert As Boolean = False
    Private _DVRAlertEMail As Boolean = False
    Private _DVRSMSDBDataID As String = ""
    Private _DVRASubject As String = ""
    Private _DVRABodyTemplate As String = ""
    Private _DVREMailDBDataID As String = ""
    Private _DVRAlertSMS As Boolean = False
    Private _DVRASMSText As String = ""
    Private _ReminderOnCount As Boolean = False
    Private _ReminderCountThreshold As Int32 = 0
    Private _ReminderCountDBDataID As String = ""
    Private _ReminderOnAvg As Boolean = False
    Private _ReminderLapsDaysAvg As Int32 = 0
    Private _ReminderAvgDBDataID As String = ""
    Private _ReminderOnMax As Boolean = False
    Private _ReminderLapsDaysMax As Int32 = 0
    Private _ReminderMaxDBDataID As String = ""
    Private _ReminderFrequencyDays As Int32 = 0
    Private _ReminderAlertEMail As Boolean = False
    Private _ReminderEMailDBDataID As String = ""
    Private _ReminderASubject As String = ""
    Private _ReminderABodyTemplate As String = ""
    Private _ReminderAlertSMS As Boolean = False
    Private _ReminderSMSDBDataID As String = ""
    Private _ReminderASMSText As String = ""
    Private _WF_Dashboards1_DBDescription As String = ""
    Private _WF_DBRows2_Description As String = ""
    Private _WF_DBRowTypes3_Description As String = ""
    Private _WF_GraphTypes4_Description As String = ""
    Private _WF_DetailViewTypes5_DVTypeDescription As String = ""
    Private _WF_DBData6_Description As String = ""
    Private _WF_DBData7_Description As String = ""
    Private _WF_DBData8_Description As String = ""
    Private _WF_DBData9_Description As String = ""
    Private _WF_DBData10_Description As String = ""
    Private _WF_DBData11_Description As String = ""
    Private _WF_DBData12_Description As String = ""
    Private _WF_DBData13_Description As String = ""
    Private _WF_DBData14_Description As String = ""
    Private _WF_DBData15_Description As String = ""
    Private _WF_DBData16_Description As String = ""
    Private _WF_DBIcons17_IconName As String = ""
    Private _WF_DBIcons18_IconName As String = ""
    Private _WF_DBIcons19_IconName As String = ""
    Private _WF_DBIcons20_IconName As String = ""
    Private _WF_DBIcons21_IconName As String = ""
    Private _WF_DBIcons22_IconName As String = ""
    Private _WF_DBData23_Description As String = ""
    Private _WF_DBData24_Description As String = ""
    Private _FK_WF_DBRows_DashboardID As SIS.WF.wfDashboards = Nothing
    Private _FK_WF_DBRows_ParentDBRows As SIS.WF.wfDBRows = Nothing
    Private _FK_WF_DBRows_DBRowTypes As SIS.WF.wfDBRowTypes = Nothing
    Private _FK_WF_DBRows_GraphTypeID As SIS.WF.wfGraphTypes = Nothing
    Private _FK_WF_DBRows_DVTypeID As SIS.WF.wfDetailViewTypes = Nothing
    Private _FK_WF_DBRows_DVReverseDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_DVFEMailDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_DVFSMSDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_DVREMailDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_DVRSMSDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_ReminderCountDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_ReminderAVGDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_ReminderMaxDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_MainDBID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_DVDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_DVForwardDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_MainDBIconID As SIS.WF.wfDBIcons = Nothing
    Private _FK_WF_DBRows_DVDBIconID As SIS.WF.wfDBIcons = Nothing
    Private _FK_WF_DBRows_DVRemarksDBIconID As SIS.WF.wfDBIcons = Nothing
    Private _FK_WF_DBRows_DVFDBIconID As SIS.WF.wfDBIcons = Nothing
    Private _FK_WF_DBRows_DVRDBIconID As SIS.WF.wfDBIcons = Nothing
    Private _FK_WF_DBRows_DVAttachmentDBIconID As SIS.WF.wfDBIcons = Nothing
    Private _FK_WF_DBRows_ReminderEMailDBDataID As SIS.WF.wfDBData = Nothing
    Private _FK_WF_DBRows_ReminderSMSDBDataID As SIS.WF.wfDBData = Nothing
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
    Public Property DBRows() As Int32
      Get
        Return _DBRows
      End Get
      Set(ByVal value As Int32)
        _DBRows = value
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
    Public Property Sequence() As Int32
      Get
        Return _Sequence
      End Get
      Set(ByVal value As Int32)
        _Sequence = value
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
    Public Property cssRow() As String
      Get
        Return _cssRow
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _cssRow = ""
         Else
           _cssRow = value
         End If
      End Set
    End Property
    Public Property ShowHeader() As Boolean
      Get
        Return _ShowHeader
      End Get
      Set(ByVal value As Boolean)
        _ShowHeader = value
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
    Public Property NotToDraw() As Boolean
      Get
        Return _NotToDraw
      End Get
      Set(ByVal value As Boolean)
        _NotToDraw = value
      End Set
    End Property
    Public Property ParentDBRows() As String
      Get
        Return _ParentDBRows
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ParentDBRows = ""
         Else
           _ParentDBRows = value
         End If
      End Set
    End Property
    Public Property MainDBDataID() As String
      Get
        Return _MainDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MainDBDataID = ""
         Else
           _MainDBDataID = value
         End If
      End Set
    End Property
    Public Property MainDBIconID() As String
      Get
        Return _MainDBIconID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MainDBIconID = ""
         Else
           _MainDBIconID = value
         End If
      End Set
    End Property
    Public Property IsDV() As Boolean
      Get
        Return _IsDV
      End Get
      Set(ByVal value As Boolean)
        _IsDV = value
      End Set
    End Property
    Public Property DVTypeID() As String
      Get
        Return _DVTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVTypeID = ""
         Else
           _DVTypeID = value
         End If
      End Set
    End Property
    Public Property DVDescription() As String
      Get
        Return _DVDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVDescription = ""
         Else
           _DVDescription = value
         End If
      End Set
    End Property
    Public Property DVDBIconID() As String
      Get
        Return _DVDBIconID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVDBIconID = ""
         Else
           _DVDBIconID = value
         End If
      End Set
    End Property
    Public Property DVDBDataID() As String
      Get
        Return _DVDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVDBDataID = ""
         Else
           _DVDBDataID = value
         End If
      End Set
    End Property
    Public Property IsDVUpdatable() As Boolean
      Get
        Return _IsDVUpdatable
      End Get
      Set(ByVal value As Boolean)
        _IsDVUpdatable = value
      End Set
    End Property
    Public Property IsDVRemarks() As Boolean
      Get
        Return _IsDVRemarks
      End Get
      Set(ByVal value As Boolean)
        _IsDVRemarks = value
      End Set
    End Property
    Public Property DVRemarksText() As String
      Get
        Return _DVRemarksText
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVRemarksText = ""
         Else
           _DVRemarksText = value
         End If
      End Set
    End Property
    Public Property DVRemarksDBIconID() As String
      Get
        Return _DVRemarksDBIconID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVRemarksDBIconID = ""
         Else
           _DVRemarksDBIconID = value
         End If
      End Set
    End Property
    Public Property IsDVForward() As Boolean
      Get
        Return _IsDVForward
      End Get
      Set(ByVal value As Boolean)
        _IsDVForward = value
      End Set
    End Property
    Public Property DVForwardText() As String
      Get
        Return _DVForwardText
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVForwardText = ""
         Else
           _DVForwardText = value
         End If
      End Set
    End Property
    Public Property DVFDBIconID() As String
      Get
        Return _DVFDBIconID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVFDBIconID = ""
         Else
           _DVFDBIconID = value
         End If
      End Set
    End Property
    Public Property DVForwardDBDataID() As String
      Get
        Return _DVForwardDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVForwardDBDataID = ""
         Else
           _DVForwardDBDataID = value
         End If
      End Set
    End Property
    Public Property IsDVReverse() As Boolean
      Get
        Return _IsDVReverse
      End Get
      Set(ByVal value As Boolean)
        _IsDVReverse = value
      End Set
    End Property
    Public Property DVReverseText() As String
      Get
        Return _DVReverseText
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVReverseText = ""
         Else
           _DVReverseText = value
         End If
      End Set
    End Property
    Public Property DVRDBIconID() As String
      Get
        Return _DVRDBIconID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVRDBIconID = ""
         Else
           _DVRDBIconID = value
         End If
      End Set
    End Property
    Public Property DVReverseDBDataID() As String
      Get
        Return _DVReverseDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVReverseDBDataID = ""
         Else
           _DVReverseDBDataID = value
         End If
      End Set
    End Property
    Public Property IsDVAttachment() As Boolean
      Get
        Return _IsDVAttachment
      End Get
      Set(ByVal value As Boolean)
        _IsDVAttachment = value
      End Set
    End Property
    Public Property IsDVAttachmentMulti() As Boolean
      Get
        Return _IsDVAttachmentMulti
      End Get
      Set(ByVal value As Boolean)
        _IsDVAttachmentMulti = value
      End Set
    End Property
    Public Property DVAttachmentText() As String
      Get
        Return _DVAttachmentText
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVAttachmentText = ""
         Else
           _DVAttachmentText = value
         End If
      End Set
    End Property
    Public Property DVAttachmentDBIconID() As String
      Get
        Return _DVAttachmentDBIconID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVAttachmentDBIconID = ""
         Else
           _DVAttachmentDBIconID = value
         End If
      End Set
    End Property
    Public Property DVFAlert() As Boolean
      Get
        Return _DVFAlert
      End Get
      Set(ByVal value As Boolean)
        _DVFAlert = value
      End Set
    End Property
    Public Property DVFAlertEMail() As Boolean
      Get
        Return _DVFAlertEMail
      End Get
      Set(ByVal value As Boolean)
        _DVFAlertEMail = value
      End Set
    End Property
    Public Property DVFASubject() As String
      Get
        Return _DVFASubject
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVFASubject = ""
         Else
           _DVFASubject = value
         End If
      End Set
    End Property
    Public Property DVFABodyTemplate() As String
      Get
        Return _DVFABodyTemplate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVFABodyTemplate = ""
         Else
           _DVFABodyTemplate = value
         End If
      End Set
    End Property
    Public Property DVFEMailDBDataID() As String
      Get
        Return _DVFEMailDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVFEMailDBDataID = ""
         Else
           _DVFEMailDBDataID = value
         End If
      End Set
    End Property
    Public Property DVFAlertSMS() As Boolean
      Get
        Return _DVFAlertSMS
      End Get
      Set(ByVal value As Boolean)
        _DVFAlertSMS = value
      End Set
    End Property
    Public Property DVFASMSText() As String
      Get
        Return _DVFASMSText
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVFASMSText = ""
         Else
           _DVFASMSText = value
         End If
      End Set
    End Property
    Public Property DVFSMSDBDataID() As String
      Get
        Return _DVFSMSDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVFSMSDBDataID = ""
         Else
           _DVFSMSDBDataID = value
         End If
      End Set
    End Property
    Public Property DVRAlert() As Boolean
      Get
        Return _DVRAlert
      End Get
      Set(ByVal value As Boolean)
        _DVRAlert = value
      End Set
    End Property
    Public Property DVRAlertEMail() As Boolean
      Get
        Return _DVRAlertEMail
      End Get
      Set(ByVal value As Boolean)
        _DVRAlertEMail = value
      End Set
    End Property
    Public Property DVRSMSDBDataID() As String
      Get
        Return _DVRSMSDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVRSMSDBDataID = ""
         Else
           _DVRSMSDBDataID = value
         End If
      End Set
    End Property
    Public Property DVRASubject() As String
      Get
        Return _DVRASubject
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVRASubject = ""
         Else
           _DVRASubject = value
         End If
      End Set
    End Property
    Public Property DVRABodyTemplate() As String
      Get
        Return _DVRABodyTemplate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVRABodyTemplate = ""
         Else
           _DVRABodyTemplate = value
         End If
      End Set
    End Property
    Public Property DVREMailDBDataID() As String
      Get
        Return _DVREMailDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVREMailDBDataID = ""
         Else
           _DVREMailDBDataID = value
         End If
      End Set
    End Property
    Public Property DVRAlertSMS() As Boolean
      Get
        Return _DVRAlertSMS
      End Get
      Set(ByVal value As Boolean)
        _DVRAlertSMS = value
      End Set
    End Property
    Public Property DVRASMSText() As String
      Get
        Return _DVRASMSText
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DVRASMSText = ""
         Else
           _DVRASMSText = value
         End If
      End Set
    End Property
    Public Property ReminderOnCount() As Boolean
      Get
        Return _ReminderOnCount
      End Get
      Set(ByVal value As Boolean)
        _ReminderOnCount = value
      End Set
    End Property
    Public Property ReminderCountThreshold() As Int32
      Get
        Return _ReminderCountThreshold
      End Get
      Set(ByVal value As Int32)
        _ReminderCountThreshold = value
      End Set
    End Property
    Public Property ReminderCountDBDataID() As String
      Get
        Return _ReminderCountDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReminderCountDBDataID = ""
         Else
           _ReminderCountDBDataID = value
         End If
      End Set
    End Property
    Public Property ReminderOnAvg() As Boolean
      Get
        Return _ReminderOnAvg
      End Get
      Set(ByVal value As Boolean)
        _ReminderOnAvg = value
      End Set
    End Property
    Public Property ReminderLapsDaysAvg() As Int32
      Get
        Return _ReminderLapsDaysAvg
      End Get
      Set(ByVal value As Int32)
        _ReminderLapsDaysAvg = value
      End Set
    End Property
    Public Property ReminderAvgDBDataID() As String
      Get
        Return _ReminderAvgDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReminderAvgDBDataID = ""
         Else
           _ReminderAvgDBDataID = value
         End If
      End Set
    End Property
    Public Property ReminderOnMax() As Boolean
      Get
        Return _ReminderOnMax
      End Get
      Set(ByVal value As Boolean)
        _ReminderOnMax = value
      End Set
    End Property
    Public Property ReminderLapsDaysMax() As Int32
      Get
        Return _ReminderLapsDaysMax
      End Get
      Set(ByVal value As Int32)
        _ReminderLapsDaysMax = value
      End Set
    End Property
    Public Property ReminderMaxDBDataID() As String
      Get
        Return _ReminderMaxDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReminderMaxDBDataID = ""
         Else
           _ReminderMaxDBDataID = value
         End If
      End Set
    End Property
    Public Property ReminderFrequencyDays() As Int32
      Get
        Return _ReminderFrequencyDays
      End Get
      Set(ByVal value As Int32)
        _ReminderFrequencyDays = value
      End Set
    End Property
    Public Property ReminderAlertEMail() As Boolean
      Get
        Return _ReminderAlertEMail
      End Get
      Set(ByVal value As Boolean)
        _ReminderAlertEMail = value
      End Set
    End Property
    Public Property ReminderEMailDBDataID() As String
      Get
        Return _ReminderEMailDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReminderEMailDBDataID = ""
         Else
           _ReminderEMailDBDataID = value
         End If
      End Set
    End Property
    Public Property ReminderASubject() As String
      Get
        Return _ReminderASubject
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReminderASubject = ""
         Else
           _ReminderASubject = value
         End If
      End Set
    End Property
    Public Property ReminderABodyTemplate() As String
      Get
        Return _ReminderABodyTemplate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReminderABodyTemplate = ""
         Else
           _ReminderABodyTemplate = value
         End If
      End Set
    End Property
    Public Property ReminderAlertSMS() As Boolean
      Get
        Return _ReminderAlertSMS
      End Get
      Set(ByVal value As Boolean)
        _ReminderAlertSMS = value
      End Set
    End Property
    Public Property ReminderSMSDBDataID() As String
      Get
        Return _ReminderSMSDBDataID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReminderSMSDBDataID = ""
         Else
           _ReminderSMSDBDataID = value
         End If
      End Set
    End Property
    Public Property ReminderASMSText() As String
      Get
        Return _ReminderASMSText
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReminderASMSText = ""
         Else
           _ReminderASMSText = value
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
    Public Property WF_DBRowTypes3_Description() As String
      Get
        Return _WF_DBRowTypes3_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBRowTypes3_Description = ""
         Else
           _WF_DBRowTypes3_Description = value
         End If
      End Set
    End Property
    Public Property WF_GraphTypes4_Description() As String
      Get
        Return _WF_GraphTypes4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_GraphTypes4_Description = ""
         Else
           _WF_GraphTypes4_Description = value
         End If
      End Set
    End Property
    Public Property WF_DetailViewTypes5_DVTypeDescription() As String
      Get
        Return _WF_DetailViewTypes5_DVTypeDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DetailViewTypes5_DVTypeDescription = ""
         Else
           _WF_DetailViewTypes5_DVTypeDescription = value
         End If
      End Set
    End Property
    Public Property WF_DBData6_Description() As String
      Get
        Return _WF_DBData6_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData6_Description = ""
         Else
           _WF_DBData6_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData7_Description() As String
      Get
        Return _WF_DBData7_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData7_Description = ""
         Else
           _WF_DBData7_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData8_Description() As String
      Get
        Return _WF_DBData8_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData8_Description = ""
         Else
           _WF_DBData8_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData9_Description() As String
      Get
        Return _WF_DBData9_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData9_Description = ""
         Else
           _WF_DBData9_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData10_Description() As String
      Get
        Return _WF_DBData10_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData10_Description = ""
         Else
           _WF_DBData10_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData11_Description() As String
      Get
        Return _WF_DBData11_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData11_Description = ""
         Else
           _WF_DBData11_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData12_Description() As String
      Get
        Return _WF_DBData12_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData12_Description = ""
         Else
           _WF_DBData12_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData13_Description() As String
      Get
        Return _WF_DBData13_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData13_Description = ""
         Else
           _WF_DBData13_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData14_Description() As String
      Get
        Return _WF_DBData14_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData14_Description = ""
         Else
           _WF_DBData14_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData15_Description() As String
      Get
        Return _WF_DBData15_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData15_Description = ""
         Else
           _WF_DBData15_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData16_Description() As String
      Get
        Return _WF_DBData16_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData16_Description = ""
         Else
           _WF_DBData16_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBIcons17_IconName() As String
      Get
        Return _WF_DBIcons17_IconName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBIcons17_IconName = ""
         Else
           _WF_DBIcons17_IconName = value
         End If
      End Set
    End Property
    Public Property WF_DBIcons18_IconName() As String
      Get
        Return _WF_DBIcons18_IconName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBIcons18_IconName = ""
         Else
           _WF_DBIcons18_IconName = value
         End If
      End Set
    End Property
    Public Property WF_DBIcons19_IconName() As String
      Get
        Return _WF_DBIcons19_IconName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBIcons19_IconName = ""
         Else
           _WF_DBIcons19_IconName = value
         End If
      End Set
    End Property
    Public Property WF_DBIcons20_IconName() As String
      Get
        Return _WF_DBIcons20_IconName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBIcons20_IconName = ""
         Else
           _WF_DBIcons20_IconName = value
         End If
      End Set
    End Property
    Public Property WF_DBIcons21_IconName() As String
      Get
        Return _WF_DBIcons21_IconName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBIcons21_IconName = ""
         Else
           _WF_DBIcons21_IconName = value
         End If
      End Set
    End Property
    Public Property WF_DBIcons22_IconName() As String
      Get
        Return _WF_DBIcons22_IconName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBIcons22_IconName = ""
         Else
           _WF_DBIcons22_IconName = value
         End If
      End Set
    End Property
    Public Property WF_DBData23_Description() As String
      Get
        Return _WF_DBData23_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData23_Description = ""
         Else
           _WF_DBData23_Description = value
         End If
      End Set
    End Property
    Public Property WF_DBData24_Description() As String
      Get
        Return _WF_DBData24_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WF_DBData24_Description = ""
         Else
           _WF_DBData24_Description = value
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
        Return _DashboardID & "|" & _DBRows
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
    Public Class PKwfDBRows
      Private _DashboardID As Int32 = 0
      Private _DBRows As Int32 = 0
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
    End Class
    Public ReadOnly Property FK_WF_DBRows_DashboardID() As SIS.WF.wfDashboards
      Get
        If _FK_WF_DBRows_DashboardID Is Nothing Then
          _FK_WF_DBRows_DashboardID = SIS.WF.wfDashboards.wfDashboardsGetByID(_DashboardID)
        End If
        Return _FK_WF_DBRows_DashboardID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_ParentDBRows() As SIS.WF.wfDBRows
      Get
        If _FK_WF_DBRows_ParentDBRows Is Nothing Then
          _FK_WF_DBRows_ParentDBRows = SIS.WF.wfDBRows.wfDBRowsGetByID(_DashboardID, _ParentDBRows)
        End If
        Return _FK_WF_DBRows_ParentDBRows
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DBRowTypes() As SIS.WF.wfDBRowTypes
      Get
        If _FK_WF_DBRows_DBRowTypes Is Nothing Then
          _FK_WF_DBRows_DBRowTypes = SIS.WF.wfDBRowTypes.wfDBRowTypesGetByID(_DBRowTypeID)
        End If
        Return _FK_WF_DBRows_DBRowTypes
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_GraphTypeID() As SIS.WF.wfGraphTypes
      Get
        If _FK_WF_DBRows_GraphTypeID Is Nothing Then
          _FK_WF_DBRows_GraphTypeID = SIS.WF.wfGraphTypes.wfGraphTypesGetByID(_GraphTypeID)
        End If
        Return _FK_WF_DBRows_GraphTypeID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVTypeID() As SIS.WF.wfDetailViewTypes
      Get
        If _FK_WF_DBRows_DVTypeID Is Nothing Then
          _FK_WF_DBRows_DVTypeID = SIS.WF.wfDetailViewTypes.wfDetailViewTypesGetByID(_DVTypeID)
        End If
        Return _FK_WF_DBRows_DVTypeID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVReverseDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_DVReverseDBDataID Is Nothing Then
          _FK_WF_DBRows_DVReverseDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_DVReverseDBDataID)
        End If
        Return _FK_WF_DBRows_DVReverseDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVFEMailDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_DVFEMailDBDataID Is Nothing Then
          _FK_WF_DBRows_DVFEMailDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_DVFEMailDBDataID)
        End If
        Return _FK_WF_DBRows_DVFEMailDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVFSMSDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_DVFSMSDBDataID Is Nothing Then
          _FK_WF_DBRows_DVFSMSDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_DVFSMSDBDataID)
        End If
        Return _FK_WF_DBRows_DVFSMSDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVREMailDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_DVREMailDBDataID Is Nothing Then
          _FK_WF_DBRows_DVREMailDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_DVREMailDBDataID)
        End If
        Return _FK_WF_DBRows_DVREMailDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVRSMSDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_DVRSMSDBDataID Is Nothing Then
          _FK_WF_DBRows_DVRSMSDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_DVRSMSDBDataID)
        End If
        Return _FK_WF_DBRows_DVRSMSDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_ReminderCountDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_ReminderCountDBDataID Is Nothing Then
          _FK_WF_DBRows_ReminderCountDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_ReminderCountDBDataID)
        End If
        Return _FK_WF_DBRows_ReminderCountDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_ReminderAVGDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_ReminderAVGDBDataID Is Nothing Then
          _FK_WF_DBRows_ReminderAVGDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_ReminderAvgDBDataID)
        End If
        Return _FK_WF_DBRows_ReminderAVGDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_ReminderMaxDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_ReminderMaxDBDataID Is Nothing Then
          _FK_WF_DBRows_ReminderMaxDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_ReminderMaxDBDataID)
        End If
        Return _FK_WF_DBRows_ReminderMaxDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_MainDBID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_MainDBID Is Nothing Then
          _FK_WF_DBRows_MainDBID = SIS.WF.wfDBData.wfDBDataGetByID(_MainDBDataID)
        End If
        Return _FK_WF_DBRows_MainDBID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_DVDBDataID Is Nothing Then
          _FK_WF_DBRows_DVDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_DVDBDataID)
        End If
        Return _FK_WF_DBRows_DVDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVForwardDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_DVForwardDBDataID Is Nothing Then
          _FK_WF_DBRows_DVForwardDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_DVForwardDBDataID)
        End If
        Return _FK_WF_DBRows_DVForwardDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_MainDBIconID() As SIS.WF.wfDBIcons
      Get
        If _FK_WF_DBRows_MainDBIconID Is Nothing Then
          _FK_WF_DBRows_MainDBIconID = SIS.WF.wfDBIcons.wfDBIconsGetByID(_MainDBIconID)
        End If
        Return _FK_WF_DBRows_MainDBIconID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVDBIconID() As SIS.WF.wfDBIcons
      Get
        If _FK_WF_DBRows_DVDBIconID Is Nothing Then
          _FK_WF_DBRows_DVDBIconID = SIS.WF.wfDBIcons.wfDBIconsGetByID(_DVDBIconID)
        End If
        Return _FK_WF_DBRows_DVDBIconID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVRemarksDBIconID() As SIS.WF.wfDBIcons
      Get
        If _FK_WF_DBRows_DVRemarksDBIconID Is Nothing Then
          _FK_WF_DBRows_DVRemarksDBIconID = SIS.WF.wfDBIcons.wfDBIconsGetByID(_DVRemarksDBIconID)
        End If
        Return _FK_WF_DBRows_DVRemarksDBIconID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVFDBIconID() As SIS.WF.wfDBIcons
      Get
        If _FK_WF_DBRows_DVFDBIconID Is Nothing Then
          _FK_WF_DBRows_DVFDBIconID = SIS.WF.wfDBIcons.wfDBIconsGetByID(_DVFDBIconID)
        End If
        Return _FK_WF_DBRows_DVFDBIconID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVRDBIconID() As SIS.WF.wfDBIcons
      Get
        If _FK_WF_DBRows_DVRDBIconID Is Nothing Then
          _FK_WF_DBRows_DVRDBIconID = SIS.WF.wfDBIcons.wfDBIconsGetByID(_DVRDBIconID)
        End If
        Return _FK_WF_DBRows_DVRDBIconID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_DVAttachmentDBIconID() As SIS.WF.wfDBIcons
      Get
        If _FK_WF_DBRows_DVAttachmentDBIconID Is Nothing Then
          _FK_WF_DBRows_DVAttachmentDBIconID = SIS.WF.wfDBIcons.wfDBIconsGetByID(_DVAttachmentDBIconID)
        End If
        Return _FK_WF_DBRows_DVAttachmentDBIconID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_ReminderEMailDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_ReminderEMailDBDataID Is Nothing Then
          _FK_WF_DBRows_ReminderEMailDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_ReminderEMailDBDataID)
        End If
        Return _FK_WF_DBRows_ReminderEMailDBDataID
      End Get
    End Property
    Public ReadOnly Property FK_WF_DBRows_ReminderSMSDBDataID() As SIS.WF.wfDBData
      Get
        If _FK_WF_DBRows_ReminderSMSDBDataID Is Nothing Then
          _FK_WF_DBRows_ReminderSMSDBDataID = SIS.WF.wfDBData.wfDBDataGetByID(_ReminderSMSDBDataID)
        End If
        Return _FK_WF_DBRows_ReminderSMSDBDataID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBRowsSelectList(ByVal OrderBy As String) As List(Of SIS.WF.wfDBRows)
      Dim Results As List(Of SIS.WF.wfDBRows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DBRows DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDBRows)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDBRows(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBRowsGetNewRecord() As SIS.WF.wfDBRows
      Return New SIS.WF.wfDBRows()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBRowsGetByID(ByVal DashboardID As Int32, ByVal DBRows As Int32) As SIS.WF.wfDBRows
      Dim Results As SIS.WF.wfDBRows = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,DashboardID.ToString.Length, DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBRows",SqlDbType.Int,DBRows.ToString.Length, DBRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.WF.wfDBRows(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBRowsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DashboardID As Int32) As List(Of SIS.WF.wfDBRows)
      Dim Results As List(Of SIS.WF.wfDBRows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DBRows DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfDBRowsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfDBRowsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DashboardID",SqlDbType.Int,10, IIf(DashboardID = Nothing, 0,DashboardID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WF.wfDBRows)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WF.wfDBRows(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function wfDBRowsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DashboardID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBRowsGetByID(ByVal DashboardID As Int32, ByVal DBRows As Int32, ByVal Filter_DashboardID As Int32) As SIS.WF.wfDBRows
      Return wfDBRowsGetByID(DashboardID, DBRows)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function wfDBRowsInsert(ByVal Record As SIS.WF.wfDBRows) As SIS.WF.wfDBRows
      Dim _Rec As SIS.WF.wfDBRows = SIS.WF.wfDBRows.wfDBRowsGetNewRecord()
      With _Rec
        .DashboardID = Record.DashboardID
        .Description = Record.Description
        .DBTitle = Record.DBTitle
        .Sequence = Record.Sequence
        .DBRowTypeID = Record.DBRowTypeID
        .TitleStyle = Record.TitleStyle
        .cssRow = Record.cssRow
        .ShowHeader = Record.ShowHeader
        .GraphTypeID = Record.GraphTypeID
        .ConvertForGraph = Record.ConvertForGraph
        .NotToDraw = Record.NotToDraw
        .ParentDBRows = Record.ParentDBRows
        .MainDBDataID = Record.MainDBDataID
        .MainDBIconID = Record.MainDBIconID
        .IsDV = Record.IsDV
        .DVTypeID = Record.DVTypeID
        .DVDescription = Record.DVDescription
        .DVDBIconID = Record.DVDBIconID
        .DVDBDataID = Record.DVDBDataID
        .IsDVUpdatable = Record.IsDVUpdatable
        .IsDVRemarks = Record.IsDVRemarks
        .DVRemarksText = Record.DVRemarksText
        .DVRemarksDBIconID = Record.DVRemarksDBIconID
        .IsDVForward = Record.IsDVForward
        .DVForwardText = Record.DVForwardText
        .DVFDBIconID = Record.DVFDBIconID
        .DVForwardDBDataID = Record.DVForwardDBDataID
        .IsDVReverse = Record.IsDVReverse
        .DVReverseText = Record.DVReverseText
        .DVRDBIconID = Record.DVRDBIconID
        .DVReverseDBDataID = Record.DVReverseDBDataID
        .IsDVAttachment = Record.IsDVAttachment
        .IsDVAttachmentMulti = Record.IsDVAttachmentMulti
        .DVAttachmentText = Record.DVAttachmentText
        .DVAttachmentDBIconID = Record.DVAttachmentDBIconID
        .DVFAlert = Record.DVFAlert
        .DVFAlertEMail = Record.DVFAlertEMail
        .DVFASubject = Record.DVFASubject
        .DVFABodyTemplate = Record.DVFABodyTemplate
        .DVFEMailDBDataID = Record.DVFEMailDBDataID
        .DVFAlertSMS = Record.DVFAlertSMS
        .DVFASMSText = Record.DVFASMSText
        .DVFSMSDBDataID = Record.DVFSMSDBDataID
        .DVRAlert = Record.DVRAlert
        .DVRAlertEMail = Record.DVRAlertEMail
        .DVRSMSDBDataID = Record.DVRSMSDBDataID
        .DVRASubject = Record.DVRASubject
        .DVRABodyTemplate = Record.DVRABodyTemplate
        .DVREMailDBDataID = Record.DVREMailDBDataID
        .DVRAlertSMS = Record.DVRAlertSMS
        .DVRASMSText = Record.DVRASMSText
        .ReminderOnCount = Record.ReminderOnCount
        .ReminderCountThreshold = Record.ReminderCountThreshold
        .ReminderCountDBDataID = Record.ReminderCountDBDataID
        .ReminderOnAvg = Record.ReminderOnAvg
        .ReminderLapsDaysAvg = Record.ReminderLapsDaysAvg
        .ReminderAvgDBDataID = Record.ReminderAvgDBDataID
        .ReminderOnMax = Record.ReminderOnMax
        .ReminderLapsDaysMax = Record.ReminderLapsDaysMax
        .ReminderMaxDBDataID = Record.ReminderMaxDBDataID
        .ReminderFrequencyDays = Record.ReminderFrequencyDays
        .ReminderAlertEMail = Record.ReminderAlertEMail
        .ReminderEMailDBDataID = Record.ReminderEMailDBDataID
        .ReminderASubject = Record.ReminderASubject
        .ReminderABodyTemplate = Record.ReminderABodyTemplate
        .ReminderAlertSMS = Record.ReminderAlertSMS
        .ReminderSMSDBDataID = Record.ReminderSMSDBDataID
        .ReminderASMSText = Record.ReminderASMSText
      End With
      Return SIS.WF.wfDBRows.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.WF.wfDBRows) As SIS.WF.wfDBRows
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,11, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBTitle",SqlDbType.NVarChar,101, Iif(Record.DBTitle= "" ,Convert.DBNull, Record.DBTitle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Record.Sequence)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBRowTypeID",SqlDbType.Int,11, Iif(Record.DBRowTypeID= "" ,Convert.DBNull, Record.DBRowTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TitleStyle",SqlDbType.NVarChar,251, Iif(Record.TitleStyle= "" ,Convert.DBNull, Record.TitleStyle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cssRow",SqlDbType.NVarChar,51, Iif(Record.cssRow= "" ,Convert.DBNull, Record.cssRow))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShowHeader",SqlDbType.Bit,3, Record.ShowHeader)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GraphTypeID",SqlDbType.Int,11, Iif(Record.GraphTypeID= "" ,Convert.DBNull, Record.GraphTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConvertForGraph",SqlDbType.Bit,3, Record.ConvertForGraph)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotToDraw",SqlDbType.Bit,3, Record.NotToDraw)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentDBRows",SqlDbType.Int,11, Iif(Record.ParentDBRows= "" ,Convert.DBNull, Record.ParentDBRows))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainDBDataID",SqlDbType.Int,11, Iif(Record.MainDBDataID= "" ,Convert.DBNull, Record.MainDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainDBIconID",SqlDbType.Int,11, Iif(Record.MainDBIconID= "" ,Convert.DBNull, Record.MainDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDV",SqlDbType.Bit,3, Record.IsDV)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVTypeID",SqlDbType.Int,11, Iif(Record.DVTypeID= "" ,Convert.DBNull, Record.DVTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVDescription",SqlDbType.NVarChar,101, Iif(Record.DVDescription= "" ,Convert.DBNull, Record.DVDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVDBIconID",SqlDbType.Int,11, Iif(Record.DVDBIconID= "" ,Convert.DBNull, Record.DVDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVDBDataID",SqlDbType.Int,11, Iif(Record.DVDBDataID= "" ,Convert.DBNull, Record.DVDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVUpdatable",SqlDbType.Bit,3, Record.IsDVUpdatable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVRemarks",SqlDbType.Bit,3, Record.IsDVRemarks)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRemarksText",SqlDbType.NVarChar,51, Iif(Record.DVRemarksText= "" ,Convert.DBNull, Record.DVRemarksText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRemarksDBIconID",SqlDbType.Int,11, Iif(Record.DVRemarksDBIconID= "" ,Convert.DBNull, Record.DVRemarksDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVForward",SqlDbType.Bit,3, Record.IsDVForward)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVForwardText",SqlDbType.NVarChar,51, Iif(Record.DVForwardText= "" ,Convert.DBNull, Record.DVForwardText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFDBIconID",SqlDbType.Int,11, Iif(Record.DVFDBIconID= "" ,Convert.DBNull, Record.DVFDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVForwardDBDataID",SqlDbType.Int,11, Iif(Record.DVForwardDBDataID= "" ,Convert.DBNull, Record.DVForwardDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVReverse",SqlDbType.Bit,3, Record.IsDVReverse)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVReverseText",SqlDbType.NVarChar,51, Iif(Record.DVReverseText= "" ,Convert.DBNull, Record.DVReverseText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRDBIconID",SqlDbType.Int,11, Iif(Record.DVRDBIconID= "" ,Convert.DBNull, Record.DVRDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVReverseDBDataID",SqlDbType.Int,11, Iif(Record.DVReverseDBDataID= "" ,Convert.DBNull, Record.DVReverseDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVAttachment",SqlDbType.Bit,3, Record.IsDVAttachment)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVAttachmentMulti",SqlDbType.Bit,3, Record.IsDVAttachmentMulti)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVAttachmentText",SqlDbType.NVarChar,51, Iif(Record.DVAttachmentText= "" ,Convert.DBNull, Record.DVAttachmentText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVAttachmentDBIconID",SqlDbType.Int,11, Iif(Record.DVAttachmentDBIconID= "" ,Convert.DBNull, Record.DVAttachmentDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFAlert",SqlDbType.Bit,3, Record.DVFAlert)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFAlertEMail",SqlDbType.Bit,3, Record.DVFAlertEMail)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFASubject",SqlDbType.NVarChar,101, Iif(Record.DVFASubject= "" ,Convert.DBNull, Record.DVFASubject))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFABodyTemplate",SqlDbType.NVarChar,101, Iif(Record.DVFABodyTemplate= "" ,Convert.DBNull, Record.DVFABodyTemplate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFEMailDBDataID",SqlDbType.Int,11, Iif(Record.DVFEMailDBDataID= "" ,Convert.DBNull, Record.DVFEMailDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFAlertSMS",SqlDbType.Bit,3, Record.DVFAlertSMS)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFASMSText",SqlDbType.NVarChar,501, Iif(Record.DVFASMSText= "" ,Convert.DBNull, Record.DVFASMSText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFSMSDBDataID",SqlDbType.Int,11, Iif(Record.DVFSMSDBDataID= "" ,Convert.DBNull, Record.DVFSMSDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRAlert",SqlDbType.Bit,3, Record.DVRAlert)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRAlertEMail",SqlDbType.Bit,3, Record.DVRAlertEMail)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRSMSDBDataID",SqlDbType.Int,11, Iif(Record.DVRSMSDBDataID= "" ,Convert.DBNull, Record.DVRSMSDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRASubject",SqlDbType.NVarChar,101, Iif(Record.DVRASubject= "" ,Convert.DBNull, Record.DVRASubject))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRABodyTemplate",SqlDbType.NVarChar,101, Iif(Record.DVRABodyTemplate= "" ,Convert.DBNull, Record.DVRABodyTemplate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVREMailDBDataID",SqlDbType.Int,11, Iif(Record.DVREMailDBDataID= "" ,Convert.DBNull, Record.DVREMailDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRAlertSMS",SqlDbType.Bit,3, Record.DVRAlertSMS)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRASMSText",SqlDbType.NVarChar,501, Iif(Record.DVRASMSText= "" ,Convert.DBNull, Record.DVRASMSText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnCount",SqlDbType.Bit,3, Record.ReminderOnCount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderCountThreshold",SqlDbType.Int,11, Record.ReminderCountThreshold)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderCountDBDataID",SqlDbType.Int,11, Iif(Record.ReminderCountDBDataID= "" ,Convert.DBNull, Record.ReminderCountDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnAvg",SqlDbType.Bit,3, Record.ReminderOnAvg)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderLapsDaysAvg",SqlDbType.Int,11, Record.ReminderLapsDaysAvg)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderAvgDBDataID",SqlDbType.Int,11, Iif(Record.ReminderAvgDBDataID= "" ,Convert.DBNull, Record.ReminderAvgDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnMax",SqlDbType.Bit,3, Record.ReminderOnMax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderLapsDaysMax",SqlDbType.Int,11, Record.ReminderLapsDaysMax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderMaxDBDataID",SqlDbType.Int,11, Iif(Record.ReminderMaxDBDataID= "" ,Convert.DBNull, Record.ReminderMaxDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderFrequencyDays",SqlDbType.Int,11, Record.ReminderFrequencyDays)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderAlertEMail",SqlDbType.Bit,3, Record.ReminderAlertEMail)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderEMailDBDataID",SqlDbType.Int,11, Iif(Record.ReminderEMailDBDataID= "" ,Convert.DBNull, Record.ReminderEMailDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderASubject",SqlDbType.NVarChar,101, Iif(Record.ReminderASubject= "" ,Convert.DBNull, Record.ReminderASubject))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderABodyTemplate",SqlDbType.NVarChar,101, Iif(Record.ReminderABodyTemplate= "" ,Convert.DBNull, Record.ReminderABodyTemplate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderAlertSMS",SqlDbType.Bit,3, Record.ReminderAlertSMS)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderSMSDBDataID",SqlDbType.Int,11, Iif(Record.ReminderSMSDBDataID= "" ,Convert.DBNull, Record.ReminderSMSDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderASMSText",SqlDbType.NVarChar,501, Iif(Record.ReminderASMSText= "" ,Convert.DBNull, Record.ReminderASMSText))
          Cmd.Parameters.Add("@Return_DashboardID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DashboardID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DBRows", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DBRows").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.DashboardID = Cmd.Parameters("@Return_DashboardID").Value
          Record.DBRows = Cmd.Parameters("@Return_DBRows").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function wfDBRowsUpdate(ByVal Record As SIS.WF.wfDBRows) As SIS.WF.wfDBRows
      Dim _Rec As SIS.WF.wfDBRows = SIS.WF.wfDBRows.wfDBRowsGetByID(Record.DashboardID, Record.DBRows)
      With _Rec
        .Description = Record.Description
        .DBTitle = Record.DBTitle
        .Sequence = Record.Sequence
        .DBRowTypeID = Record.DBRowTypeID
        .TitleStyle = Record.TitleStyle
        .cssRow = Record.cssRow
        .ShowHeader = Record.ShowHeader
        .GraphTypeID = Record.GraphTypeID
        .ConvertForGraph = Record.ConvertForGraph
        .NotToDraw = Record.NotToDraw
        .ParentDBRows = Record.ParentDBRows
        .MainDBDataID = Record.MainDBDataID
        .MainDBIconID = Record.MainDBIconID
        .IsDV = Record.IsDV
        .DVTypeID = Record.DVTypeID
        .DVDescription = Record.DVDescription
        .DVDBIconID = Record.DVDBIconID
        .DVDBDataID = Record.DVDBDataID
        .IsDVUpdatable = Record.IsDVUpdatable
        .IsDVRemarks = Record.IsDVRemarks
        .DVRemarksText = Record.DVRemarksText
        .DVRemarksDBIconID = Record.DVRemarksDBIconID
        .IsDVForward = Record.IsDVForward
        .DVForwardText = Record.DVForwardText
        .DVFDBIconID = Record.DVFDBIconID
        .DVForwardDBDataID = Record.DVForwardDBDataID
        .IsDVReverse = Record.IsDVReverse
        .DVReverseText = Record.DVReverseText
        .DVRDBIconID = Record.DVRDBIconID
        .DVReverseDBDataID = Record.DVReverseDBDataID
        .IsDVAttachment = Record.IsDVAttachment
        .IsDVAttachmentMulti = Record.IsDVAttachmentMulti
        .DVAttachmentText = Record.DVAttachmentText
        .DVAttachmentDBIconID = Record.DVAttachmentDBIconID
        .DVFAlert = Record.DVFAlert
        .DVFAlertEMail = Record.DVFAlertEMail
        .DVFASubject = Record.DVFASubject
        .DVFABodyTemplate = Record.DVFABodyTemplate
        .DVFEMailDBDataID = Record.DVFEMailDBDataID
        .DVFAlertSMS = Record.DVFAlertSMS
        .DVFASMSText = Record.DVFASMSText
        .DVFSMSDBDataID = Record.DVFSMSDBDataID
        .DVRAlert = Record.DVRAlert
        .DVRAlertEMail = Record.DVRAlertEMail
        .DVRSMSDBDataID = Record.DVRSMSDBDataID
        .DVRASubject = Record.DVRASubject
        .DVRABodyTemplate = Record.DVRABodyTemplate
        .DVREMailDBDataID = Record.DVREMailDBDataID
        .DVRAlertSMS = Record.DVRAlertSMS
        .DVRASMSText = Record.DVRASMSText
        .ReminderOnCount = Record.ReminderOnCount
        .ReminderCountThreshold = Record.ReminderCountThreshold
        .ReminderCountDBDataID = Record.ReminderCountDBDataID
        .ReminderOnAvg = Record.ReminderOnAvg
        .ReminderLapsDaysAvg = Record.ReminderLapsDaysAvg
        .ReminderAvgDBDataID = Record.ReminderAvgDBDataID
        .ReminderOnMax = Record.ReminderOnMax
        .ReminderLapsDaysMax = Record.ReminderLapsDaysMax
        .ReminderMaxDBDataID = Record.ReminderMaxDBDataID
        .ReminderFrequencyDays = Record.ReminderFrequencyDays
        .ReminderAlertEMail = Record.ReminderAlertEMail
        .ReminderEMailDBDataID = Record.ReminderEMailDBDataID
        .ReminderASubject = Record.ReminderASubject
        .ReminderABodyTemplate = Record.ReminderABodyTemplate
        .ReminderAlertSMS = Record.ReminderAlertSMS
        .ReminderSMSDBDataID = Record.ReminderSMSDBDataID
        .ReminderASMSText = Record.ReminderASMSText
      End With
      Return SIS.WF.wfDBRows.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.WF.wfDBRows) As SIS.WF.wfDBRows
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DashboardID",SqlDbType.Int,11, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBRows",SqlDbType.Int,11, Record.DBRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DashboardID",SqlDbType.Int,11, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBTitle",SqlDbType.NVarChar,101, Iif(Record.DBTitle= "" ,Convert.DBNull, Record.DBTitle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Record.Sequence)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DBRowTypeID",SqlDbType.Int,11, Iif(Record.DBRowTypeID= "" ,Convert.DBNull, Record.DBRowTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TitleStyle",SqlDbType.NVarChar,251, Iif(Record.TitleStyle= "" ,Convert.DBNull, Record.TitleStyle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cssRow",SqlDbType.NVarChar,51, Iif(Record.cssRow= "" ,Convert.DBNull, Record.cssRow))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShowHeader",SqlDbType.Bit,3, Record.ShowHeader)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GraphTypeID",SqlDbType.Int,11, Iif(Record.GraphTypeID= "" ,Convert.DBNull, Record.GraphTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConvertForGraph",SqlDbType.Bit,3, Record.ConvertForGraph)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotToDraw",SqlDbType.Bit,3, Record.NotToDraw)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentDBRows",SqlDbType.Int,11, Iif(Record.ParentDBRows= "" ,Convert.DBNull, Record.ParentDBRows))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainDBDataID",SqlDbType.Int,11, Iif(Record.MainDBDataID= "" ,Convert.DBNull, Record.MainDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MainDBIconID",SqlDbType.Int,11, Iif(Record.MainDBIconID= "" ,Convert.DBNull, Record.MainDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDV",SqlDbType.Bit,3, Record.IsDV)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVTypeID",SqlDbType.Int,11, Iif(Record.DVTypeID= "" ,Convert.DBNull, Record.DVTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVDescription",SqlDbType.NVarChar,101, Iif(Record.DVDescription= "" ,Convert.DBNull, Record.DVDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVDBIconID",SqlDbType.Int,11, Iif(Record.DVDBIconID= "" ,Convert.DBNull, Record.DVDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVDBDataID",SqlDbType.Int,11, Iif(Record.DVDBDataID= "" ,Convert.DBNull, Record.DVDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVUpdatable",SqlDbType.Bit,3, Record.IsDVUpdatable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVRemarks",SqlDbType.Bit,3, Record.IsDVRemarks)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRemarksText",SqlDbType.NVarChar,51, Iif(Record.DVRemarksText= "" ,Convert.DBNull, Record.DVRemarksText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRemarksDBIconID",SqlDbType.Int,11, Iif(Record.DVRemarksDBIconID= "" ,Convert.DBNull, Record.DVRemarksDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVForward",SqlDbType.Bit,3, Record.IsDVForward)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVForwardText",SqlDbType.NVarChar,51, Iif(Record.DVForwardText= "" ,Convert.DBNull, Record.DVForwardText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFDBIconID",SqlDbType.Int,11, Iif(Record.DVFDBIconID= "" ,Convert.DBNull, Record.DVFDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVForwardDBDataID",SqlDbType.Int,11, Iif(Record.DVForwardDBDataID= "" ,Convert.DBNull, Record.DVForwardDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVReverse",SqlDbType.Bit,3, Record.IsDVReverse)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVReverseText",SqlDbType.NVarChar,51, Iif(Record.DVReverseText= "" ,Convert.DBNull, Record.DVReverseText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRDBIconID",SqlDbType.Int,11, Iif(Record.DVRDBIconID= "" ,Convert.DBNull, Record.DVRDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVReverseDBDataID",SqlDbType.Int,11, Iif(Record.DVReverseDBDataID= "" ,Convert.DBNull, Record.DVReverseDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVAttachment",SqlDbType.Bit,3, Record.IsDVAttachment)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsDVAttachmentMulti",SqlDbType.Bit,3, Record.IsDVAttachmentMulti)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVAttachmentText",SqlDbType.NVarChar,51, Iif(Record.DVAttachmentText= "" ,Convert.DBNull, Record.DVAttachmentText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVAttachmentDBIconID",SqlDbType.Int,11, Iif(Record.DVAttachmentDBIconID= "" ,Convert.DBNull, Record.DVAttachmentDBIconID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFAlert",SqlDbType.Bit,3, Record.DVFAlert)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFAlertEMail",SqlDbType.Bit,3, Record.DVFAlertEMail)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFASubject",SqlDbType.NVarChar,101, Iif(Record.DVFASubject= "" ,Convert.DBNull, Record.DVFASubject))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFABodyTemplate",SqlDbType.NVarChar,101, Iif(Record.DVFABodyTemplate= "" ,Convert.DBNull, Record.DVFABodyTemplate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFEMailDBDataID",SqlDbType.Int,11, Iif(Record.DVFEMailDBDataID= "" ,Convert.DBNull, Record.DVFEMailDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFAlertSMS",SqlDbType.Bit,3, Record.DVFAlertSMS)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFASMSText",SqlDbType.NVarChar,501, Iif(Record.DVFASMSText= "" ,Convert.DBNull, Record.DVFASMSText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVFSMSDBDataID",SqlDbType.Int,11, Iif(Record.DVFSMSDBDataID= "" ,Convert.DBNull, Record.DVFSMSDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRAlert",SqlDbType.Bit,3, Record.DVRAlert)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRAlertEMail",SqlDbType.Bit,3, Record.DVRAlertEMail)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRSMSDBDataID",SqlDbType.Int,11, Iif(Record.DVRSMSDBDataID= "" ,Convert.DBNull, Record.DVRSMSDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRASubject",SqlDbType.NVarChar,101, Iif(Record.DVRASubject= "" ,Convert.DBNull, Record.DVRASubject))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRABodyTemplate",SqlDbType.NVarChar,101, Iif(Record.DVRABodyTemplate= "" ,Convert.DBNull, Record.DVRABodyTemplate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVREMailDBDataID",SqlDbType.Int,11, Iif(Record.DVREMailDBDataID= "" ,Convert.DBNull, Record.DVREMailDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRAlertSMS",SqlDbType.Bit,3, Record.DVRAlertSMS)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DVRASMSText",SqlDbType.NVarChar,501, Iif(Record.DVRASMSText= "" ,Convert.DBNull, Record.DVRASMSText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnCount",SqlDbType.Bit,3, Record.ReminderOnCount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderCountThreshold",SqlDbType.Int,11, Record.ReminderCountThreshold)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderCountDBDataID",SqlDbType.Int,11, Iif(Record.ReminderCountDBDataID= "" ,Convert.DBNull, Record.ReminderCountDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnAvg",SqlDbType.Bit,3, Record.ReminderOnAvg)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderLapsDaysAvg",SqlDbType.Int,11, Record.ReminderLapsDaysAvg)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderAvgDBDataID",SqlDbType.Int,11, Iif(Record.ReminderAvgDBDataID= "" ,Convert.DBNull, Record.ReminderAvgDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderOnMax",SqlDbType.Bit,3, Record.ReminderOnMax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderLapsDaysMax",SqlDbType.Int,11, Record.ReminderLapsDaysMax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderMaxDBDataID",SqlDbType.Int,11, Iif(Record.ReminderMaxDBDataID= "" ,Convert.DBNull, Record.ReminderMaxDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderFrequencyDays",SqlDbType.Int,11, Record.ReminderFrequencyDays)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderAlertEMail",SqlDbType.Bit,3, Record.ReminderAlertEMail)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderEMailDBDataID",SqlDbType.Int,11, Iif(Record.ReminderEMailDBDataID= "" ,Convert.DBNull, Record.ReminderEMailDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderASubject",SqlDbType.NVarChar,101, Iif(Record.ReminderASubject= "" ,Convert.DBNull, Record.ReminderASubject))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderABodyTemplate",SqlDbType.NVarChar,101, Iif(Record.ReminderABodyTemplate= "" ,Convert.DBNull, Record.ReminderABodyTemplate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderAlertSMS",SqlDbType.Bit,3, Record.ReminderAlertSMS)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderSMSDBDataID",SqlDbType.Int,11, Iif(Record.ReminderSMSDBDataID= "" ,Convert.DBNull, Record.ReminderSMSDBDataID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReminderASMSText",SqlDbType.NVarChar,501, Iif(Record.ReminderASMSText= "" ,Convert.DBNull, Record.ReminderASMSText))
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
    Public Shared Function wfDBRowsDelete(ByVal Record As SIS.WF.wfDBRows) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DashboardID",SqlDbType.Int,Record.DashboardID.ToString.Length, Record.DashboardID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DBRows",SqlDbType.Int,Record.DBRows.ToString.Length, Record.DBRows)
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
    Public Shared Function SelectwfDBRowsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBRowsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.WF.wfDBRows = New SIS.WF.wfDBRows(Reader)
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
