VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "��ʾ��VB��������"
   ClientHeight    =   7350
   ClientLeft      =   1140
   ClientTop       =   1275
   ClientWidth     =   9645
   BeginProperty Font 
      Name            =   "����"
      Size            =   9
      Charset         =   134
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   ScaleHeight     =   7350
   ScaleWidth      =   9645
   Begin VB.ComboBox mColorType 
      Height          =   300
      ItemData        =   "Form1.frx":0000
      Left            =   2520
      List            =   "Form1.frx":000D
      Style           =   2  'Dropdown List
      TabIndex        =   49
      Top             =   120
      Width           =   2295
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   500
      Left            =   7440
      Top             =   1920
   End
   Begin VB.Frame Frame5 
      Caption         =   "�ֲ���������"
      Height          =   4455
      Left            =   7320
      TabIndex        =   39
      Top             =   2520
      Width           =   2175
      Begin VB.CommandButton btnChapter 
         Caption         =   "ֻ����1����Ŀ"
         Height          =   495
         Left            =   240
         TabIndex        =   42
         Top             =   360
         Width           =   1695
      End
      Begin VB.CommandButton btnRegion 
         Caption         =   "ֻ����1������"
         Height          =   495
         Left            =   240
         TabIndex        =   41
         Top             =   1080
         Width           =   1695
      End
      Begin VB.CommandButton btnLeaf 
         Caption         =   "ֻ����1��ҳ��"
         Height          =   495
         Left            =   240
         TabIndex        =   40
         Top             =   1800
         Width           =   1695
      End
   End
   Begin VB.Frame Frame4 
      Caption         =   "������ʽ��ִ�������ʱ������������ֱ�����Ӧ����ʱ��������"
      Height          =   1935
      Left            =   120
      TabIndex        =   26
      Top             =   5040
      Width           =   7095
      Begin VB.CommandButton btnTimer 
         Caption         =   "��ʱ���Ͳ���"
         Height          =   375
         Left            =   4920
         TabIndex        =   48
         Top             =   1320
         Width           =   2055
      End
      Begin VB.CommandButton btnPowerOff2 
         Caption         =   "�رյ�Դ"
         Height          =   375
         Left            =   1320
         TabIndex        =   38
         Top             =   360
         Width           =   975
      End
      Begin VB.CommandButton btnGetPower2 
         Caption         =   "��ȡ��Դ״̬"
         Height          =   375
         Left            =   2400
         TabIndex        =   37
         Top             =   360
         Width           =   1335
      End
      Begin VB.CommandButton btnGetBright2 
         Caption         =   "��ȡ����"
         Height          =   375
         Left            =   4920
         TabIndex        =   36
         Top             =   360
         Width           =   975
      End
      Begin VB.CommandButton btnAdjustTime2 
         Caption         =   "У��ʱ��"
         Height          =   375
         Left            =   6000
         TabIndex        =   35
         Top             =   360
         Width           =   975
      End
      Begin VB.CommandButton btnPowerOn2 
         Caption         =   "�򿪵�Դ"
         Height          =   375
         Left            =   240
         TabIndex        =   34
         Top             =   360
         Width           =   975
      End
      Begin VB.CommandButton btnSetBright2 
         Caption         =   "��������"
         Height          =   375
         Left            =   3840
         TabIndex        =   33
         Top             =   360
         Width           =   975
      End
      Begin VB.CommandButton btnString2 
         Caption         =   "������������"
         Height          =   375
         Left            =   1680
         TabIndex        =   32
         Top             =   840
         Width           =   1335
      End
      Begin VB.CommandButton btnText2 
         Caption         =   "���͵�������"
         Height          =   375
         Left            =   240
         TabIndex        =   31
         Top             =   840
         Width           =   1335
      End
      Begin VB.CommandButton btnPicFile2 
         Caption         =   "����ͼƬ�ļ�"
         Height          =   375
         Left            =   1680
         TabIndex        =   30
         Top             =   1320
         Width           =   1335
      End
      Begin VB.CommandButton btnDIB2 
         Caption         =   "���͵���ͼ��"
         Height          =   375
         Left            =   240
         TabIndex        =   29
         Top             =   1320
         Width           =   1335
      End
      Begin VB.CommandButton btnDateTime2 
         Caption         =   "��������ʱ��"
         Height          =   375
         Left            =   3120
         TabIndex        =   28
         Top             =   840
         Width           =   1335
      End
      Begin VB.CommandButton btnClock2 
         Caption         =   "����ģ��ʱ��"
         Height          =   375
         Left            =   3120
         TabIndex        =   27
         Top             =   1320
         Width           =   1335
      End
   End
   Begin VB.TextBox mPictureFile 
      Height          =   375
      Left            =   1200
      TabIndex        =   13
      Text            =   "C:\test.bmp"
      Top             =   2040
      Width           =   6015
   End
   Begin VB.PictureBox Picture1 
      AutoSize        =   -1  'True
      BorderStyle     =   0  'None
      FillStyle       =   0  'Solid
      Height          =   480
      Left            =   120
      Picture         =   "Form1.frx":002B
      ScaleHeight     =   32
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   64
      TabIndex        =   12
      Top             =   1920
      Width           =   960
   End
   Begin VB.Frame Frame3 
      Caption         =   "�첽��ʽ��ʹ�ô�����Ϣ��ʽ�������ִ�н��"
      Height          =   2295
      Left            =   120
      TabIndex        =   11
      Top             =   2520
      Width           =   7095
      Begin VB.CommandButton btnSwitchOff 
         Caption         =   "�ر�5V���"
         Height          =   375
         Left            =   1680
         TabIndex        =   47
         Top             =   1800
         Width           =   1335
      End
      Begin VB.CommandButton btnSwitchOn 
         Caption         =   "��5V���"
         Height          =   375
         Left            =   240
         TabIndex        =   46
         Top             =   1800
         Width           =   1335
      End
      Begin VB.CommandButton btnSendStringDirect 
         Caption         =   "ֱ�ӷ�������"
         Height          =   375
         Left            =   5640
         TabIndex        =   45
         Top             =   840
         Width           =   1335
      End
      Begin VB.CommandButton btnTable 
         Caption         =   "���ͱ��"
         Height          =   375
         Left            =   4560
         TabIndex        =   44
         Top             =   840
         Width           =   975
      End
      Begin VB.CommandButton btnComTransfer 
         Caption         =   "���紮��ת��"
         Height          =   375
         Left            =   4560
         TabIndex        =   43
         Top             =   1320
         Width           =   2415
      End
      Begin VB.CommandButton btnClock 
         Caption         =   "����ģ��ʱ��"
         Height          =   375
         Left            =   3120
         TabIndex        =   25
         Top             =   1320
         Width           =   1335
      End
      Begin VB.CommandButton btnDateTime 
         Caption         =   "��������ʱ��"
         Height          =   375
         Left            =   3120
         TabIndex        =   24
         Top             =   840
         Width           =   1335
      End
      Begin VB.CommandButton btnDIB 
         Caption         =   "���͵���ͼ��"
         Height          =   375
         Left            =   240
         TabIndex        =   23
         Top             =   1320
         Width           =   1335
      End
      Begin VB.CommandButton btnPicFile 
         Caption         =   "����ͼƬ�ļ�"
         Height          =   375
         Left            =   1680
         TabIndex        =   22
         Top             =   1320
         Width           =   1335
      End
      Begin VB.CommandButton btnText 
         Caption         =   "���͵�������"
         Height          =   375
         Left            =   240
         TabIndex        =   21
         Top             =   840
         Width           =   1335
      End
      Begin VB.CommandButton btnString 
         Caption         =   "������������"
         Height          =   375
         Left            =   1680
         TabIndex        =   20
         Top             =   840
         Width           =   1335
      End
      Begin VB.CommandButton btnSetBright 
         Caption         =   "��������"
         Height          =   375
         Left            =   3840
         TabIndex        =   19
         Top             =   360
         Width           =   975
      End
      Begin VB.CommandButton btnPowerOn 
         Caption         =   "�򿪵�Դ"
         Height          =   375
         Left            =   240
         TabIndex        =   18
         Top             =   360
         Width           =   975
      End
      Begin VB.CommandButton btnAdjustTime 
         Caption         =   "У��ʱ��"
         Height          =   375
         Left            =   6000
         TabIndex        =   17
         Top             =   360
         Width           =   975
      End
      Begin VB.CommandButton btnGetBright 
         Caption         =   "��ȡ����"
         Height          =   375
         Left            =   4920
         TabIndex        =   16
         Top             =   360
         Width           =   975
      End
      Begin VB.CommandButton btnGetPower 
         Caption         =   "��ȡ��Դ״̬"
         Height          =   375
         Left            =   2400
         TabIndex        =   15
         Top             =   360
         Width           =   1335
      End
      Begin VB.CommandButton btnPowerOff 
         Caption         =   "�رյ�Դ"
         Height          =   375
         Left            =   1320
         TabIndex        =   14
         Top             =   360
         Width           =   975
      End
   End
   Begin VB.ComboBox mDeviceType 
      Height          =   300
      ItemData        =   "Form1.frx":186D
      Left            =   120
      List            =   "Form1.frx":1877
      Style           =   2  'Dropdown List
      TabIndex        =   10
      Top             =   120
      Width           =   2295
   End
   Begin VB.Frame Frame2 
      Caption         =   "����ͨѶ"
      Height          =   1215
      Left            =   3480
      TabIndex        =   5
      Top             =   600
      Width           =   3735
      Begin VB.TextBox mLocalPort 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   1320
         TabIndex        =   9
         Text            =   "9002"
         Top             =   720
         Width           =   1935
      End
      Begin VB.TextBox mRemoteIP 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   1320
         TabIndex        =   6
         Text            =   "192.168.1.99"
         Top             =   360
         Width           =   1935
      End
      Begin VB.Label Label5 
         Caption         =   "���ƿ�IP"
         Height          =   255
         Left            =   360
         TabIndex        =   8
         Top             =   360
         Width           =   975
      End
      Begin VB.Label Label4 
         Caption         =   "���ض˿ں�"
         Height          =   255
         Left            =   360
         TabIndex        =   7
         Top             =   720
         Width           =   975
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "����ͨѶ"
      Height          =   1215
      Left            =   120
      TabIndex        =   0
      Top             =   600
      Width           =   3255
      Begin VB.ComboBox mComSpeed 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   315
         ItemData        =   "Form1.frx":188F
         Left            =   1080
         List            =   "Form1.frx":189F
         Style           =   2  'Dropdown List
         TabIndex        =   4
         Top             =   720
         Width           =   1695
      End
      Begin VB.TextBox mComPort 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   1080
         TabIndex        =   1
         Text            =   "1"
         Top             =   360
         Width           =   1695
      End
      Begin VB.Label Label3 
         Caption         =   "������"
         Height          =   255
         Left            =   360
         TabIndex        =   3
         Top             =   720
         Width           =   615
      End
      Begin VB.Label Label2 
         Caption         =   "���ں�"
         Height          =   255
         Left            =   360
         TabIndex        =   2
         Top             =   360
         Width           =   615
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit
Dim FParam As TSenderParam

Private Sub btnAdjustTime_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  Parse (LED_AdjustTime(FParam))
End Sub

Private Sub btnChapter_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  
  '��������У�ChapterIndex=0��ֻ���¿��ƿ��ڵ�1����Ŀ
  '���ChapterIndex=1��ֻ���¿��ƿ��ڵ�2����Ŀ
  '�Դ�����
  K = MakeChapter(ROOT_PLAY_CHAPTER, ACTMODE_REPLACE, 0, GetColorType(), 10000, WAIT_CHILD)
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddText K, 0, 0, 64, 32, 1, 0, "���", "����", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000
  Parse (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnClock_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddClock K, 0, 0, 64, 64, 1, 0, 0, RGB(0, 0, 0), RGB(255, 255, 0), 1, SHAPE_CIRCLE, 30, 3, RGB(255, 255, 0), 2, RGB(0, 255, 0), 3, RGB(255, 255, 0), 2, RGB(0, 255, 0), 1, RGB(255, 0, 0)
  Parse (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnSendStringDirect_Click()
  Dim Buffer(16) As Byte
  GetDeviceParam
  FParam.notifyMode = NOTIFY_NONE
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  Import_Init
  Import_AddInt "%d", 120
  Import_AddInt "%d", 35
  Import_AddFloat "%0.2f", 35.9
  Import_Send FParam
  
'  Buffer(0) = &H55
'  Buffer(1) = &H21
'  Buffer(2) = &H31
'  Buffer(3) = &H32
'  Buffer(4) = &H33
'  Buffer(5) = &H34
'  Buffer(6) = &H2F
'  Buffer(7) = &H35
'  Buffer(8) = &H36
'  Buffer(9) = &H37
'  Buffer(10) = &H38
'  Buffer(11) = &H23
'  Buffer(12) = &HAA
'  LED_SendBufferDirectly FParam, Buffer(0), 13
'  LED_SendStringDirectly FParam, Chr(85) + "!1234/5678#" + Chr(170)
End Sub

Private Sub btnSwitchOff_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  Parse (LED_SetSwitch(FParam, 0))
End Sub

Private Sub btnSwitchOn_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  Parse (LED_SetSwitch(FParam, 1))
End Sub

Private Sub btnTable_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddTable K, 0, 0, 64, 64, 1, "table.ini", "[R]aaa|[Y]bbb|[G]ccc" & Chr(13) & Chr(10) & "[R]333|[Y]444|[G]555", 1, 0, 1, 0, 0, 0, 1000
  Parse (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnComTransfer_Click()
  Dim data(16) As Byte
  Dim i
  For i = 1 To 16
    data(i) = i
  Next i
    
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  Parse (LED_ComTransfer(FParam, data(0), 16))
End Sub

Private Sub btnDateTime_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddDateTime K, 0, 0, 64, 32, 1, 0, "����", 12, RGB(0, 255, 0), 0, 0, 0, 0, 0, "#y��#m��#d�� #h:#n:#s ����#w ũ��#c"
  Parse (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnDIB_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddWindow K, 0, 0, 64, 32, 1, 0, Picture1.hDC, Picture1.ScaleWidth, Picture1.ScaleHeight, 0, 1, 0, 1, 0, 0, 0, 1000
  Parse (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnGetBright_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  Parse (LED_GetBright(FParam))
End Sub

Private Sub btnGetPower_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  Parse (LED_GetPower(FParam))
End Sub

Private Sub btnLeaf_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  
  '��������У�ChapterIndex=0��RegionIndex=0��LeafIndex=0��ֻ���¿��ƿ��ڵ�1����Ŀ�еĵ�1�������еĵ�1��ҳ��
  '���ChapterIndex=1��RegionIndex=2��LeafIndex=1��ֻ���¿��ƿ��ڵ�2����Ŀ�еĵ�3�������еĵ�2��ҳ��
  '�Դ�����
  K = MakeLeaf(ROOT_PLAY_LEAF, ACTMODE_REPLACE, 0, 0, 0, GetColorType(), 5000, WAIT_CHILD)
  AddText K, 0, 0, 64, 32, 1, 0, "���", "����", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000
  Parse (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnPicFile_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddPicture K, 0, 0, 64, 32, 1, 0, mPictureFile.Text, 0, 1, 0, 1, 0, 0, 0, 1000
  Parse (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnPowerOff_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  Parse (LED_SetPower(FParam, LED_POWER_OFF))
End Sub


Private Sub btnPowerOn_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  Parse (LED_SetPower(FParam, LED_POWER_ON))
End Sub

Private Sub Parse(ByVal K As Long)
  If K = R_DEVICE_READY Then
    Caption = "����ִ��������߷�������..."
    SendStatus = 1
  ElseIf K = R_DEVICE_INVALID Then
    Caption = "��ͨѶ�豸ʧ��(���ڲ����ڡ����ߴ����ѱ�ռ�á���������˿ڱ�ռ��)"
  ElseIf K = R_DEVICE_BUSY Then
    Caption = "�豸æ������ͨѶ��..."
  End If
End Sub

Private Sub GetDeviceParam()
  Dim i
  If mDeviceType.ListIndex = 0 Then
    FParam.devParam.devType = DEVICE_TYPE_COM
  Else
    FParam.devParam.devType = DEVICE_TYPE_UDP
  End If
  FParam.devParam.comPort = mComPort.Text
  FParam.devParam.comSpeed = mComSpeed.ListIndex
  'For i = 0 To 255
  '  FParam.devParam.rmtHost(i) = 0
  'Next i
  i = 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost0 = Asc(Mid(mRemoteIP.Text, 1, 1))
  Else
    FParam.devParam.rmtHost0 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost1 = Asc(Mid(mRemoteIP.Text, 2, 1))
  Else
    FParam.devParam.rmtHost1 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost2 = Asc(Mid(mRemoteIP.Text, 3, 1))
  Else
    FParam.devParam.rmtHost2 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost3 = Asc(Mid(mRemoteIP.Text, 4, 1))
  Else
    FParam.devParam.rmtHost3 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost4 = Asc(Mid(mRemoteIP.Text, 5, 1))
  Else
    FParam.devParam.rmtHost4 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost5 = Asc(Mid(mRemoteIP.Text, 6, 1))
  Else
    FParam.devParam.rmtHost5 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost6 = Asc(Mid(mRemoteIP.Text, 7, 1))
  Else
    FParam.devParam.rmtHost6 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost7 = Asc(Mid(mRemoteIP.Text, 8, 1))
  Else
    FParam.devParam.rmtHost7 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost8 = Asc(Mid(mRemoteIP.Text, 9, 1))
  Else
    FParam.devParam.rmtHost8 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost9 = Asc(Mid(mRemoteIP.Text, 10, 1))
  Else
    FParam.devParam.rmtHost9 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost10 = Asc(Mid(mRemoteIP.Text, 11, 1))
  Else
    FParam.devParam.rmtHost10 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost11 = Asc(Mid(mRemoteIP.Text, 12, 1))
  Else
    FParam.devParam.rmtHost11 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost12 = Asc(Mid(mRemoteIP.Text, 13, 1))
  Else
    FParam.devParam.rmtHost12 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost13 = Asc(Mid(mRemoteIP.Text, 14, 1))
  Else
    FParam.devParam.rmtHost13 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost14 = Asc(Mid(mRemoteIP.Text, 15, 1))
  Else
    FParam.devParam.rmtHost14 = 0
  End If
  i = i + 1
  If i <= Len(mRemoteIP.Text) Then
    FParam.devParam.rmtHost15 = Asc(Mid(mRemoteIP.Text, 16, 1))
  Else
    FParam.devParam.rmtHost15 = 0
  End If
  'For i = 1 To Len(mRemoteIP.Text)
  '  FParam.devParam.rmtHost(i - 1) = Asc(Mid(mRemoteIP.Text, i, 1))
  'Next i
  FParam.devParam.locPort = mLocalPort.Text
  FParam.devParam.rmtPort = 6666
  FParam.devParam.comFlow = 0
  FParam.devParam.dstAddr = 0
  FParam.devParam.srcAddr = 0
  FParam.devParam.txTimeo = 80
  FParam.devParam.txRepeat = 5
  FParam.devParam.txSlide = 0
  FParam.notifyMode = 0
  FParam.wmHandle = 0
  FParam.wmLParam = 0
  FParam.wmMessage = 0
End Sub

Private Function GetColorType() As Long
  If mColorType.ListIndex = 1 Then
    GetColorType = COLOR_MODE_THREE
  ElseIf mColorType.ListIndex = 2 Then
    GetColorType = COLOR_MODE_FULLCOLOR
  Else
    GetColorType = COLOR_MODE_DOUBLE
  End If
End Function

Private Sub btnRegion_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  
  '��������У�ChapterIndex=0��RegionIndex=0��ֻ���¿��ƿ��ڵ�1����Ŀ�еĵ�1������
  '���ChapterIndex=1��RegionIndex=2��ֻ���¿��ƿ��ڵ�2����Ŀ�еĵ�3������
  '�Դ�����
  K = MakeRegion(ROOT_PLAY_REGION, ACTMODE_REPLACE, 0, 0, GetColorType(), 0, 0, 64, 64, 0)
  AddLeaf K, 10000, WAIT_CHILD
  AddText K, 0, 0, 64, 32, 1, 0, "���", "����", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000
  Parse (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnSetBright_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  Parse (LED_SetBright(FParam, 4))
End Sub

Private Sub btnString_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddString K, 0, 0, 64, 32, 1, 0, "���", 1, RGB(255, 0, 0), 1, 0, 1, 0, 0, 0, 1000
  Parse (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnText_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_EVENT
  FParam.wmHandle = Me.hWnd
  FParam.wmMessage = WM_LED_NOTIFY
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddText K, 0, 0, 64, 32, 1, 0, "���", "����", 12, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000
  Parse (LED_SendToScreen(FParam, K))
End Sub

Private Sub Parse2(ByVal K As Long)
  Dim notifyparam As TNotifyParam
  If K >= 0 Then
    LED_GetNotifyParam notifyparam, K
    If notifyparam.notify = LM_TIMEOUT Then
      Form1.Caption = "���ͳ�ʱ"
    ElseIf notifyparam.notify = LM_TX_COMPLETE Then
      If notifyparam.Result = RESULT_FLASH Then
        Form1.Caption = "���ݴ�����ɣ�����д��Flash"
      Else
        Form1.Caption = "���ݴ������"
      End If
    ElseIf notifyparam.notify = LM_RESPOND Then
      If notifyparam.Command = PKC_GET_POWER Then
        If notifyparam.Status = LED_POWER_ON Then
          Form1.Caption = "��ȡ��Դ״̬��ɣ���ǰΪ��Դ����״̬"
        Else
          Form1.Caption = "��ȡ��Դ״̬��ɣ���ǰΪ��Դ�ر�״̬"
        End If
      ElseIf notifyparam.Command = PKC_SET_POWER Then
        If notifyparam.Result = 99 Then
          Form1.Caption = "��ǰΪ��ʱ������ģʽ"
        ElseIf notifyparam.Status = LED_POWER_ON Then
          Form1.Caption = "���õ�Դ״̬��ɣ���ǰΪ��Դ����״̬"
        Else
          Form1.Caption = "���õ�Դ״̬��ɣ���ǰΪ��Դ�ر�״̬"
        End If
      ElseIf notifyparam.Command = PKC_GET_BRIGHT Then
        Form1.Caption = "��ȡ������ɣ���ǰ����=" & notifyparam.Status
      ElseIf notifyparam.Command = PKC_SET_BRIGHT Then
        If notifyparam.Result = 99 Then
          Form1.Caption = "��ǰΪ��ʱ���ȵ���ģʽ"
        Else
          Form1.Caption = "����������ɣ���ǰ����=" & notifyparam.Status
        End If
      ElseIf notifyparam.Command = PKC_ADJUST_TIME Then
        Form1.Caption = "У����ʾ��ʱ�����"
      End If
    ElseIf notifyparam.notify = LM_NOTIFY Then
    End If
  ElseIf K = R_DEVICE_INVALID Then
    Caption = "��ͨѶ�豸ʧ��(���ڲ����ڡ����ߴ����ѱ�ռ�á���������˿ڱ�ռ��)"
  ElseIf K = R_DEVICE_BUSY Then
    Caption = "�豸æ������ͨѶ��..."
  End If
End Sub

Private Sub btnPowerOn2_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_BLOCK
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_SetPower(FParam, LED_POWER_ON))
End Sub

Private Sub btnPowerOff2_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_BLOCK
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_SetPower(FParam, LED_POWER_OFF))
End Sub

Private Sub btnGetPower2_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_BLOCK
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_GetPower(FParam))
End Sub

Private Sub btnSetBright2_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_BLOCK
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_SetBright(FParam, 4))
End Sub

Private Sub btnGetBright2_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_BLOCK
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_GetBright(FParam))
End Sub

Private Sub btnAdjustTime2_Click()
  GetDeviceParam
  FParam.notifyMode = NOTIFY_BLOCK
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_AdjustTime(FParam))
End Sub

Private Sub btnText2_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_BLOCK
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddText K, 0, 0, 64, 32, 1, 0, "���", "����", 12, RGB(0, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000
  AddText K, 0, 32, 64, 32, 1, 0, "���������������", "����", 128, RGB(255, 255, 0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 1000
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnString2_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_NONE
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddString K, 0, 0, 64, 32, 1, 0, "���", 1, RGB(255, 0, 0), 1, 0, 1, 0, 0, 0, 1000
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnDIB2_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_BLOCK
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddWindow K, 0, 0, 64, 32, 1, 0, Picture1.hDC, Picture1.ScaleWidth, Picture1.ScaleHeight, 0, 1, 0, 1, 0, 0, 0, 1000
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnPicFile2_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_BLOCK
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddPicture K, 0, 0, 64, 32, 1, 0, mPictureFile.Text, 0, 1, 0, 1, 0, 0, 0, 1000
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnDateTime2_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_BLOCK
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddDateTime K, 0, 0, 64, 32, 1, 0, "����", 12, RGB(0, 255, 0), 0, 0, 0, 0, 0, "#y��#m��#d�� #h:#n:#s ����#w ũ��#c"
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnClock2_Click()
  Dim K As Long
  
  GetDeviceParam
  FParam.notifyMode = NOTIFY_BLOCK
  FParam.wmHandle = 0
  FParam.wmMessage = 0
  
  K = MakeRoot(ROOT_PLAY, GetColorType())
  AddChapter K, 10000, WAIT_CHILD
  AddRegion K, 0, 0, 64, 64, 0
  AddLeaf K, 10000, WAIT_CHILD
  AddClock K, 0, 0, 64, 64, 1, 0, 0, RGB(0, 0, 0), RGB(255, 255, 0), 1, SHAPE_CIRCLE, 30, 3, RGB(255, 255, 0), 2, RGB(0, 255, 0), 3, RGB(255, 255, 0), 2, RGB(0, 255, 0), 1, RGB(255, 0, 0)
  Caption = "����ִ��������߷�������..."
  Parse2 (LED_SendToScreen(FParam, K))
End Sub

Private Sub btnTimer_Click()
  Timer1.Enabled = True
End Sub

Private Sub Form_Load()
  LED_Startup
  mDeviceType.ListIndex = 1
  mColorType.ListIndex = 0
  mComSpeed.ListIndex = 0
  Hook Me.hWnd
  SendStatus = 0
End Sub

Private Sub Form_unLoad(Cancel As Integer)
  LED_Cleanup
  UnHook Me.hWnd
End Sub

Private Sub Timer1_Timer()
  btnText2_Click
  'btnComTransfer_Click
End Sub
