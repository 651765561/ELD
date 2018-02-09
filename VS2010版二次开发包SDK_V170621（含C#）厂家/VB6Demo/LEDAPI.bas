Attribute VB_Name = "LEDAPI"
Option Explicit

'ͨѶ��ʽ����
Public Const DEVICE_TYPE_COM = 0
Public Const DEVICE_TYPE_UDP = 1
Public Const DEVICE_TYPE_485 = 2

'����ͨѶ�ٶȳ���
Public Const SBR_57600 = 0
Public Const SBR_38400 = 1
Public Const SBR_19200 = 2
Public Const SBR_9600 = 3

'�Ƿ�ȴ���λ��Ӧ��ֱ�ӷ�����������
Public Const NOTIFY_NONE = 1
'�Ƿ�������ʽ������ȵ�������ɻ��߳�ʱ���ŷ��أ�������������
Public Const NOTIFY_BLOCK = 2
'�Ƿ񽫷��ͽ����Windows������Ϣ��ʽ�͵����õ�Ӧ��
Public Const NOTIFY_EVENT = 4

Public Const R_DEVICE_READY = 0
Public Const R_DEVICE_INVALID = -1
Public Const R_DEVICE_BUSY = -2
Public Const R_FONTSET_INVALID = -3
Public Const R_DLL_INIT_IVALID = -4
Public Const R_IGNORE_RESPOND = -5

'Chapter��Leaf�У�����ʱ�����
Public Const WAIT_USE_TIME = 0   '����ָ����ʱ�䳤�Ȳ��ţ���ʱ����е���һ��
Public Const WAIT_CHILD = 1      '�ȴ�����Ŀ�Ĳ��ţ��������ָ����ʱ�䳤�ȣ�������Ŀ��û�в��꣬��ȴ�����

Public Const V_FALSE = 0
Public Const V_TRUE = 1

'��ʾ�����ͳ���
Public Const COLOR_MODE_UNICOLOR = 1         '��ɫ��ʾ��
Public Const COLOR_MODE_DOUBLE = 2           '˫ɫ��ʾ��
Public Const COLOR_MODE_THREE = 3            'ȫ���޻Ҷ�
Public Const COLOR_MODE_FULLCOLOR = 4        'ȫ��

'��ʾ��������
Public Const ROOT_UPDATE = 19            '������λ������
Public Const ROOT_FONTSET = 20           '�����ֿ�
Public Const ROOT_PLAY = 33              '��Ŀ���ݣ����浽RAM�����綪ʧ
Public Const ROOT_DOWNLOAD = 34          '��Ŀ���ݣ����浽Flash
Public Const ROOT_PLAY_CHAPTER = 35      '������߸���ĳһ��Ŀ
Public Const ROOT_PLAY_REGION = 37       '������߸���ĳһ����/����
Public Const ROOT_PLAY_LEAF = 39         '������߸���ĳһҳ��
Public Const ROOT_PLAY_OBJECT = 41       '������߸���ĳһ����

Public Const ACTMODE_INSERT = 0  '�������
Public Const ACTMODE_REPLACE = 1  '�滻����

'Windows�������Ͷ���
Public Const WFS_NONE = 0                '��ͨ��ʽ
Public Const WFS_BOLD = 1                '����
Public Const WFS_ITALIC = 2              'б��
Public Const WFS_UNDERLINE = 4           '�»���
Public Const WFS_STRIKEOUT = 8           'ɾ����

'�����Ƴ���
Public Const FLOW_NONE = 0
Public Const FLOW_RTS_CTS = 1

'������������
Public Const FONT_SET_16 = 0             '16��������
Public Const FONT_SET_24 = 1             '24��������

'RAM��Ŀ����
Public Const ROOT_SURVIVE_ALWAYS = -1

'��λ��Ӧ���ʶ
Public Const LM_RX_COMPLETE = 1
Public Const LM_TX_COMPLETE = 2
Public Const LM_RESPOND = 3
Public Const LM_TIMEOUT = 4
Public Const LM_NOTIFY = 5
Public Const LM_PARAM = 6
Public Const LM_TX_PROGRESS = 7
Public Const LM_RX_PROGRESS = 8
Public Const RESULT_FLASH = 65535

'��Դ״̬����
Public Const LED_POWER_OFF = 0
Public Const LED_POWER_ON = 1

'����ʱ������ʱtype����
Public Const CT_COUNTUP = 0             '����ʱ
Public Const CT_COUNTDOWN = 1           '����ʱ
'����ʱ������ʱformat����
Public Const CF_HNS = 0                 'ʱ���루���ֵ��
Public Const CF_HN = 1                  'ʱ�֣����ֵ��
Public Const CF_NS = 2                  '���루���ֵ��
Public Const CF_H = 3                   'ʱ�����ֵ��
Public Const CF_N = 4                   '�֣����ֵ��
Public Const CF_S = 5                   '�루���ֵ��
Public Const CF_DAY = 6                 '����������������
Public Const CF_HOUR = 7                'Сʱ��������������
Public Const CF_MINUTE = 8              '������������������
Public Const CF_SECOND = 9              '����������������

'ģ��ʱ�ӱ߿���״
Public Const SHAPE_RECTANGLE = 0        '����
Public Const SHAPE_ROUNDRECT = 1        'Բ�Ƿ���
Public Const SHAPE_CIRCLE = 2           'Բ��

'�����
Public Const PKC_RESPOND = 3
Public Const PKC_QUERY = 4
Public Const PKC_OVERFLOW = 5
Public Const PKC_ADJUST_TIME = 6
Public Const PKC_GET_PARAM = 7
Public Const PKC_SET_PARAM = 8
Public Const PKC_GET_POWER = 9
Public Const PKC_SET_POWER = 10
Public Const PKC_GET_BRIGHT = 11
Public Const PKC_SET_BRIGHT = 12
Public Const PKC_COM_TRANSFER = 21
Public Const PKC_GET_SWITCH = 26
Public Const PKC_SET_SWITCH = 27
Public Const PKC_GET_POWER_SCHEDULE = 60
Public Const PKC_SET_POWER_SCHEDULE = 61
Public Const PKC_GET_BRIGHT_SCHEDULE = 62
Public Const PKC_SET_BRIGHT_SCHEDULE = 63
Public Const PKC_NOTIFY = 100
Public Const PKC_MODIFY_IP = 7654
Public Const PKC_MODIFY_MAC = 7655

Public Const NOTIFY_BUFFER_LEN = 512


Type rect
  left As Long
  top  As Long
  right As Long
  bottom As Long
End Type

Type TSystemTime
  wYear As Integer
  wMonth As Integer
  wDayOfWeek As Integer
  wDay As Integer
  wHour As Integer
  wMinute As Integer
  wSecond As Integer
  wMilliseconds As Integer
End Type

Type TTimeStamp
  date As Long
  time As Long
End Type

'ͨѶ�豸�����ṹ
Type TDeviceParam
  devType As Integer    'ͨѶ���ͣ�DEVICE_TYPE_COM(0)Ϊ����ͨѶ��DEVICE_TYPE_UDP(1)Ϊ����ͨѶ
  comSpeed As Integer   '����ͨѶ�ٶ�(SBR_57600/SBR_38400/SBR_19200/SBR_9600)
  comPort As Integer    '���ں�
  comFlow As Integer    '����������
  locPort As Integer    '����ͨѶ���ض˿�
  rmtPort As Integer    '����ͨѶԶ�̿��ƿ��˿�
  srcAddr As Integer    '��λ����ַ����0
  dstAddr As Integer    '���ƿ���ַ
  'rmtHost(256) As Byte  '���ƿ�IP��ַ
  rmtHost0 As Byte      '���ƿ�IP��ַ��rmtHost0-rmtHost15)
  rmtHost1 As Byte
  rmtHost2 As Byte
  rmtHost3 As Byte
  rmtHost4 As Byte
  rmtHost5 As Byte
  rmtHost6 As Byte
  rmtHost7 As Byte
  rmtHost8 As Byte
  rmtHost9 As Byte
  rmtHost10 As Byte
  rmtHost11 As Byte
  rmtHost12 As Byte
  rmtHost13 As Byte
  rmtHost14 As Byte
  rmtHost15 As Byte
  txTimeo As Long       '���ͺ�ȴ�Ӧ��ʱ�� ====��ʱʱ��ӦΪtxTimeo*txRepeat
  txRepeat As Long      'ʧ���ط�����
  txSlide As Long       '��������
  key As Long
  pkpLength As Long     '���ݰ���С
End Type

Type TSenderParam
  devParam As TDeviceParam  'ͨѶ����
  wmHandle As Long          'Ӧ�ó������ڽ���Ӧ����Ϣ�Ĵ�����
  wmMessage As Long         '�������Ϣֵ
  wmLParam As Long          '��Ϣ����ʱ��LParam����
  notifyMode As Long        '���͹��̵���Ϣ����ģʽ��ȡֵΪ��NOTIFY_NONE/NOTIFY_BLOCK/NOTIFY_EVENT
End Type

Type TNotifyParam
  notify As Integer
  Command As Integer
  Result As Long
  Status As Long
  Param As TDeviceParam
  Buffer(NOTIFY_BUFFER_LEN) As Byte
  Size As Long
End Type

Type TPowerSchedule
  Enabled As Long
  Mode As Long
  OpenTime(21) As TTimeStamp
  CloseTime(21) As TTimeStamp
  Checksum As Long
End Type

Type TBrightSchedule
  Enabled As Long
  Bright(24) As Byte
  Checksum As Long
End Type

'��̬���ӿ��ʼ��
Declare Function LED_Startup Lib "LEDSender2010.dll" () As Long

'��̬���ӿ�����
Declare Function LED_Cleanup Lib "LEDSender2010.dll" () As Long

'��λ���ƿ���Ŀ���ţ�������ʾ���ƿ�Flash�д洢�Ľ�Ŀ
Declare Function LED_Reset Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'�������ݴ���ת��
Declare Function LED_ComTransfer Lib "LEDSender2010.dll" (Param As TSenderParam, data As Byte, ByVal Size As Long) As Long
Declare Function LED_ComTransfer_Dapu Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal data0 As Byte, ByVal data1 As Byte) As Long

'У��ʱ�䣬�Ե�ǰ�������ϵͳʱ��У�����ƿ���ʱ��
Declare Function LED_AdjustTime Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'У��ʱ����չ����ָ����ʱ��У�����ƿ���ʱ��
Declare Function LED_AdjustTimeEx Lib "LEDSender2010.dll" (Param As TSenderParam, time As TSystemTime) As Long

'ֱ�ӷ����ַ���
Declare Function LED_SendStringDirectly Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal value As String) As Long

'ֱ�ӷ�������
Declare Function LED_SendBufferDirectly Lib "LEDSender2010.dll" (Param As TSenderParam, Buffer As Byte, ByVal Size As Long) As Long

'������������Э����غ�����������
'����Э���ʼ��
Declare Function Import_Init Lib "LEDSender2010.dll" () As Long

'����Э���������
Declare Function Import_AddInt Lib "LEDSender2010.dll" (ByVal AFormat As String, ByVal value As Long) As Long

'����Э����Ӹ�����
Declare Function Import_AddFloat Lib "LEDSender2010.dll" (ByVal AFormat As String, ByVal value As Single) As Long

'����Э�鷢��
Declare Function Import_Send Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'���ÿ��ƿ���Դ value=LED_POWER_ON��ʾ������Դ value=LED_POWER_OFF��ʾ�رյ�Դ
Declare Function LED_SetPower Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal value As Long) As Long

'��ȡ���ƿ���Դ״̬
Declare Function LED_GetPower Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'���ÿ��ƿ�5V��� value=1 value=0
Declare Function LED_SetSwitch Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal value As Long) As Long

'��ȡ���ƿ�5V���״̬
Declare Function LED_GetSwitch Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'���ÿ��ƿ����� valueȡֵ��Χ0-7
Declare Function LED_SetBright Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal value As Long) As Long

'��ȡ���ƿ�����
Declare Function LED_GetBright Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'���ÿ��ƿ��Ķ�ʱ�������ƻ�
Declare Function LED_SetPowerSchedule Lib "LEDSender2010.dll" (Param As TSenderParam, value As TPowerSchedule) As Long

'��ȡ���ƿ��Ķ�ʱ�������ƻ�
Declare Function LED_GetPowerShedule Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'���ÿ��ƿ��Ķ�ʱ���ȵ��ڼƻ�
Declare Function LED_SetBrightSchedule Lib "LEDSender2010.dll" (Param As TSenderParam, value As TBrightSchedule) As Long

'��ȡ���ƿ��Ķ�ʱ���ȵ��ڼƻ�
Declare Function LED_GetBrightSchedule Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'���ͽ�Ŀ���� indexΪMakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�����ķ���ֵ
Declare Function LED_SendToScreen Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal index As Long) As Long

'��ȡ���ƿ�Ӧ����������
Declare Function LED_GetNotifyParam Lib "LEDSender2010.dll" (notify As TNotifyParam, ByVal index As Long) As Long

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

'��Ŀ������֯��ʽ
'  ROOT
'   |
'   |---Chapter(��Ŀ)
'   |      |
'   |      |---Region(����/����)
'   |      |     |
'   |      |     |---Leaf(ҳ��)
'   |      |     |    |
'   |      |     |    |---Object(����[���֡�ʱ�ӡ�ͼƬ��])
'   |      |     |    |
'   |      |     |    |---Object(����[���֡�ʱ�ӡ�ͼƬ��])
'   |      |     |    |
'   |      |     |    |   ......
'   |      |     |    |
'   |      |     |
'   |      |     |---Leaf(ҳ��)
'   |      |     |
'   |      |     |   ......
'   |      |     |
'   |      |
'   |      |---Region(����/����)
'   |      |
'   |      |   ......
'   |      |
'   |---Chapter(��Ŀ)
'   |
'   |   ......


'���ɽ�Ŀ����
'  RootType Ϊ��Ŀ���ͣ�=ROOT_PLAY��ʾ���¿��ƿ�RAM�еĽ�Ŀ(���綪ʧ)��=ROOT_DOWNLOAD��ʾ���¿��ƿ�Flash�еĽ�Ŀ(���粻��ʧ)
'  ColorMode Ϊ��ɫģʽ��ȡֵΪCOLOR_MODE_MONO����COLOR
'  survive ΪRAM��Ŀ����ʱ�䣬��RootType=ROOT_PLAYʱ��Ч����RAM��Ŀ���Ŵﵽʱ��󣬻ָ���ʾFLASH�еĽ�Ŀ
Declare Function MakeRoot Lib "LEDSender2010.dll" (ByVal RootType As Long, ByVal ColorMode As Long, Optional ByVal Survive As Long = ROOT_SURVIVE_ALWAYS) As Long

'���ɽ�Ŀ���ݣ�������Ҫ����[AddRegion]->[AddLeaf]->[AddObject]->[AddWindows/AddDateTime��]
'  RootType ������ΪROOT_PLAY_CHAPTER
'  ActionMode ������Ϊ0
'  ChapterIndex Ҫ���µĽ�Ŀ���
'  ColorMode ͬMakeRoot�еĶ���
'  time ���ŵ�ʱ�䳤��
'  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
'                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
Declare Function MakeChapter Lib "LEDSender2010.dll" (ByVal RootType As Long, ByVal ActionMode As Long, ByVal ChapterIndex As Long, ByVal ColorMode As Long, ByVal time As Long, ByVal wait As Integer) As Long

'���ɷ���/���򣬺�����Ҫ����[AddLeaf]->[AddObject]->[AddWindows/AddDateTime��]
'  RootType ������ΪROOT_PLAY_REGION
'  ActionMode ������Ϊ0
'  ChapterIndex Ҫ���µĽ�Ŀ���
'  RegionIndex Ҫ���µķ���/�������
'  ColorMode ͬMakeRoot�еĶ���
'  left��top��width��height ���ϡ���ȡ��߶�
'  border ��ˮ�߿�
Declare Function MakeRegion Lib "LEDSender2010.dll" (ByVal RootType As Long, ByVal ActionMode As Long, ByVal ChapterIndex As Long, ByVal RegionIndex As Long, ByVal ColorMode As Long, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal border As Long) As Long

'����ҳ�棬������Ҫ����[AddObject]->[AddWindows/AddDateTime��]
'  RootType ������ΪROOT_PLAY_LEAF
'  ActionMode ������Ϊ0
'  ChapterIndex Ҫ���µĽ�Ŀ���
'  RegionIndex Ҫ���µķ���/�������
'  LeafIndex Ҫ���µ�ҳ�����
'  ColorMode ͬMakeRoot�еĶ���
'  time ���ŵ�ʱ�䳤��
'  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
'                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һҳ��
Declare Function MakeLeaf Lib "LEDSender2010.dll" (ByVal RootType As Long, ByVal ActionMode As Long, ByVal ChapterIndex As Long, ByVal RegionIndex As Long, ByVal LeafIndex As Long, ByVal ColorMode As Long, ByVal time As Long, ByVal wait As Integer) As Long

'���ɲ��Ŷ��󣬺�����Ҫ����[AddWindows/AddDateTime��]
'  RootType ������ΪROOT_PLAY_LEAF
'  ActionMode ������Ϊ0
'  ChapterIndex Ҫ���µĽ�Ŀ���
'  RegionIndex Ҫ���µķ���/�������
'  LeafIndex Ҫ���µ�ҳ�����
'  ObjectIndex Ҫ���µĶ������
'  ColorMode ͬMakeRoot�еĶ���
Declare Function MakeObject Lib "LEDSender2010.dll" (ByVal RootType As Long, ByVal ActionMode As Long, ByVal ChapterIndex As Long, ByVal RegionIndex As Long, ByVal LeafIndex As Long, ByVal ObjectIndex As Long, ByVal ColorMode As Long) As Long

'��ӽ�Ŀ
'  num ��Ŀ���ݻ�������ţ���MakeRoot�ķ���ֵ
'  time ���ŵ�ʱ�䳤�ȣ���λΪ����
'  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
'                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
Declare Function AddChapter Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal time As Long, ByVal wait As Integer) As Long

'��ӷ���/����
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter�ķ���ֵ
'  left��top��width��height ���ϡ���ȡ��߶�
'  border ��ˮ�߿�
Declare Function AddRegion Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal border As Long) As Long

'���ҳ��
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion�ķ���ֵ
'  time ���ŵ�ʱ�䳤�ȣ���λΪ����
'  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
'                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һҳ��
Declare Function AddLeaf Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal time As Long, ByVal wait As Integer) As Long

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

'�������ʱ����ʾ
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  left��top��width��height ���ϡ���ȡ��߶�
'  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
'  border ��ˮ�߿�(δʵ��)
'  fontname ��������
'  fontsize �����С
'  fontcolor ������ɫ
'  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
'  year_offset ��ƫ����
'  month_offset ��ƫ����
'  day_offset ��ƫ����
'  sec_offset ��ƫ����
'  format ��ʾ��ʽ
'      #y��ʾ�� #m��ʾ�� #d��ʾ�� #h��ʾʱ #n��ʾ�� #s��ʾ�� #w��ʾ���� #c��ʾũ��
'      ������ format="#y��#m��#d�� #hʱ#n��#s�� ����#w ũ��#c"ʱ����ʾΪ"2009��06��27�� 12ʱ38��45�� ������ ũ�����³���"
Declare Function AddDateTime Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal fontname As String, ByVal fontsize As Long, ByVal fontcolor As Long, ByVal fontstyle As Long, ByVal year_offset As Long, ByVal month_offset As Long, ByVal day_offset As Long, ByVal sec_offset As Long, ByVal format As String) As Long

'���ģ��ʱ��
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  left��top��width��height ���ϡ���ȡ��߶�
'  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
'  border ��ˮ�߿�(δʵ��)
'  offset ��ƫ����
'  bkcolor: ������ɫ
'  bordercolor: �߿���ɫ
'  borderwidth: �߿���ɫ
'  bordershape: �߿���״ =0��ʾ�����Σ�=1��ʾԲ�Ƿ��Σ�=2��ʾԲ��
'  dotradius: �̶Ⱦ���������İ뾶
'  adotwidth: 0369��̶ȴ�С
'  adotcolor: 0369��̶���ɫ
'  bdotwidth: ������̶ȴ�С
'  bdotcolor: ������̶���ɫ
'  hourwidth: ʱ���ϸ
'  hourcolor: ʱ����ɫ
'  minutewidth: �����ϸ
'  minutecolor: ������ɫ
'  secondwidth: �����ϸ
'  secondcolor: ������ɫ
Declare Function AddClock Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal offset As Long, ByVal bkcolor As Long, ByVal bordercolor As Long, ByVal borderwidth As Long, ByVal bordershape As Long, ByVal dotradius As Long, ByVal adotwidth As Long, ByVal adotcolor As Long, ByVal bdotwidth As Long, ByVal bdotcolor As Long, ByVal hourwidth As Long, ByVal hourcolor As Long, ByVal minutewidth As Long, ByVal minutecolor As Long, ByVal secondwidth As Long, ByVal secondcolor As Long) As Long

'��Ӷ���
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  left��top��width��height ���ϡ���ȡ��߶�
'  filename avi�ļ���
'  stretch: ͼ���Ƿ���������Ӧ�����С
Declare Function AddMovie Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal filename As String, ByVal stretch As Long) As Long

'���ͼƬ�鲥��
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  left��top��width��height ���ϡ���ȡ��߶�
'  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
'  border ��ˮ�߿�(δʵ��)
Declare Function AddWindows Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long) As Long

'���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  dc ԴͼƬDC���
'  width ͼƬ���
'  height ͼƬ�߶�
'  inmethod ���뷽ʽ(�������б�˵��)
'  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  outmethod ������ʽ(�������б�˵��)
'  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stopmethod ͣ����ʽ(�������б�˵��)
'  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stoptime ͣ��ʱ��(��λ����)
Declare Function AddChildWindow Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal dc As Long, ByVal src_width As Long, ByVal src_height As Long, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  filename ͼƬ�ļ���
'  inmethod ���뷽ʽ(�������б�˵��)
'  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  outmethod ������ʽ(�������б�˵��)
'  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stopmethod ͣ����ʽ(�������б�˵��)
'  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stoptime ͣ��ʱ��(��λ����)
Declare Function AddChildPicture Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal filename As String, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  str �����ַ���
'  fontname ��������
'  fontsize �����С
'  fontcolor ������ɫ
'  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
'  wordwrap �Ƿ��Զ����� =1�Զ����У�=0���Զ�����
'  inmethod ���뷽ʽ(�������б�˵��)
'  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  outmethod ������ʽ(�������б�˵��)
'  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stopmethod ͣ����ʽ(�������б�˵��)
'  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stoptime ͣ��ʱ��(��λ����)
Declare Function AddChildText Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal str As String, ByVal fontname As String, ByVal fontsize As Long, ByVal fontcolor As Long, ByVal fontstyle As Long, ByVal wordwrap As Long, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'������������鲥��
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  left��top��width��height ���ϡ���ȡ��߶�
'  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
'  border ��ˮ�߿�(δʵ��)
Declare Function AddStrings Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long) As Long

'���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  str �����ַ���
'  fontset �ֿ� =FONTSET_16P��ʾ16�����ֿ⣻=FONTSET_24P��ʾ24�����ֿ�
'  color ��ɫ
'  inmethod ���뷽ʽ(�������б�˵��)
'  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  outmethod ������ʽ(�������б�˵��)
'  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stopmethod ͣ����ʽ(�������б�˵��)
'  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stoptime ͣ��ʱ��(��λ����)
Declare Function AddChildString Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal str As String, ByVal fontset As Long, ByVal color As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'���ͼƬ���󲥷�
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  left��top��width��height ���ϡ���ȡ��߶�
'  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
'  border ��ˮ�߿�(δʵ��)
'  dc ԴͼƬDC���
'  src_width ͼƬ���
'  src_height ͼƬ�߶�
'  inmethod ���뷽ʽ(�������б�˵��)
'  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  outmethod ������ʽ(�������б�˵��)
'  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stopmethod ͣ����ʽ(�������б�˵��)
'  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stoptime ͣ��ʱ��(��λ����)
Declare Function AddWindow Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal dc As Long, ByVal src_width As Long, ByVal src_height As Long, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'���ͼƬ�ļ�����
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  left��top��width��height ���ϡ���ȡ��߶�
'  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
'  border ��ˮ�߿�(δʵ��)
'  filename ͼƬ�ļ�
'  inmethod ���뷽ʽ(�������б�˵��)
'  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  outmethod ������ʽ(�������б�˵��)
'  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stopmethod ͣ����ʽ(�������б�˵��)
'  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stoptime ͣ��ʱ��(��λ����)
Declare Function AddPicture Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal filename As String, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'��ӱ�񲥷�
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  left��top��width��height ���ϡ���ȡ��߶�
'  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
'  profile ������ļ�
'  content �������
'  inmethod ���뷽ʽ(�������б�˵��)
'  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  outmethod ������ʽ(�������б�˵��)
'  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stopmethod ͣ����ʽ(�������б�˵��)
'  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stoptime ͣ��ʱ��(��λ����)
Declare Function AddTable Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal profile As String, ByVal content As String, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'������ֲ���
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  left��top��width��height ���ϡ���ȡ��߶�
'  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
'  border ��ˮ�߿�(δʵ��)
'  str �����ַ���
'  fontname ��������
'  fontsize �����С
'  fontcolor ������ɫ
'  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
'  wordwrap �Ƿ��Զ����� =1�Զ����У�=0���Զ�����
'  inmethod ���뷽ʽ(�������б�˵��)
'  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  outmethod ������ʽ(�������б�˵��)
'  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stopmethod ͣ����ʽ(�������б�˵��)
'  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stoptime ͣ��ʱ��(��λ����)
Declare Function AddText Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal str As String, ByVal fontname As String, ByVal fontsize As Long, ByVal fontcolor As Long, ByVal fontstyle As Long, ByVal wordwrap As Long, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'����������ֲ���
'  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
'  left��top��width��height ���ϡ���ȡ��߶�
'  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
'  border ��ˮ�߿�(δʵ��)
'  str �����ַ���
'  fontset �ֿ� =FONTSET_16P��ʾ16�����ֿ⣻=FONTSET_24P��ʾ24�����ֿ�
'  color ��ɫ
'  inmethod ���뷽ʽ(�������б�˵��)
'  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  outmethod ������ʽ(�������б�˵��)
'  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stopmethod ͣ����ʽ(�������б�˵��)
'  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
'  stoptime ͣ��ʱ��(��λ����)
Declare Function AddString Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal str As String, ByVal fontset As Long, ByVal color As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

' ====���붯����ʽ�б�(��ֵ��0��ʼ)====
'    0 = '���',
'    1 = '������ʾ',
'    2 = '�����ʾ',
'    3 = '�Ϲ���ʾ',
'    4 = '�ҹ���ʾ',
'    5 = '���������ʾ',
'    6 = '�����¹���ʾ',
'    7 = '�¹���ʾ',
'    8 = '�м�������չ��',
'    9 = '�м�������չ��',
'   10 = '�м�������չ��',
'   11 = '������������',
'   12 = '������������',
'   13 = '��������չ��',
'   14 = '��������չ��',
'   15 = '�����Ͻ�����',
'   16 = '�����½�����',
'   17 = '�����Ͻ�����',
'   18 = '�����½�����',
'   19 = '������������',
'   20 = '������������',
'   21 = '�����Ҷ��',
'   22 = '�����Ҷ��',
' =====================================

' ====����������ʽ�б�(��ֵ��0��ʼ)====
'    0 = '���',
'    1 = '����ʧ',
'    2 = '������ʧ',
'    3 = '�������м��£',
'    4 = '�������м��£',
'    5 = '�������м��£',
'    6 = '���������Ƴ�',
'    7 = '���������Ƴ�',
'    8 = '���������£',
'    9 = '�������Һ�£',
'   10 = '�����Ͻ��Ƴ�',
'   11 = '�����½��Ƴ�',
'   12 = '�����Ͻ��Ƴ�',
'   13 = '�����½��Ƴ�',
'   14 = '���������Ƴ�',
'   15 = '���������Ƴ�',
'   16 = '�����Ҷ��',
'   17 = '�����Ҷ��'
' =====================================

' ====ͣ��������ʽ�б�(��ֵ��0��ʼ)====
'    0 = '��̬��ʾ',
'    1 = '��˸��ʾ'
' =====================================

