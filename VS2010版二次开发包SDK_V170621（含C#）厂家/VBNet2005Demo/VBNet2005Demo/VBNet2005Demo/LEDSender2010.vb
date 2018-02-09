Option Explicit On
Imports System.Runtime.InteropServices

Module LEDAPI

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
    Public Const COLOR_MODE_FULLCOLOR_16BIT = 3  '16λȫ��ɫ��ʾ��
    Public Const COLOR_MODE_FULLCOLOR_32BIT = 4  '32λȫ��ɫ��ʾ��
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
    Public Const PKC_GET_POWER_SCHEDULE = 60
    Public Const PKC_SET_POWER_SCHEDULE = 61
    Public Const PKC_GET_BRIGHT_SCHEDULE = 62
    Public Const PKC_SET_BRIGHT_SCHEDULE = 63
    Public Const PKC_NOTIFY = 100
    Public Const PKC_MODIFY_IP = 7654
    Public Const PKC_MODIFY_MAC = 7655
    Public Const NOTIFY_BUFFER_LEN = 512

    Structure rect
        Dim left As Integer
        Dim top As Integer
        Dim right As Integer
        Dim bottom As Integer
    End Structure

    Structure TSystemTime
        Dim wYear As Short
        Dim wMonth As Short
        Dim wDayOfWeek As Short
        Dim wDay As Short
        Dim wHour As Short
        Dim wMinute As Short
        Dim wSecond As Short
        Dim wMilliseconds As Short
    End Structure

    Structure TTimeStamp
        Dim isDate As Integer
        Dim time As Integer
    End Structure

    'ͨѶ�豸�����ṹ
    Structure TDeviceParam
        Dim devType As Short    'ͨѶ���ͣ�DEVICE_TYPE_COM(0)Ϊ����ͨѶ��DEVICE_TYPE_UDP(1)Ϊ����ͨѶ
        Dim comSpeed As Short   '����ͨѶ�ٶ�(SBR_57600/SBR_38400/SBR_19200/SBR_9600)
        Dim comPort As Short    '���ں�
        Dim comFlow As Short    '����������
        Dim locPort As Short    '����ͨѶ���ض˿�
        Dim rmtPort As Short    '����ͨѶԶ�̿��ƿ��˿�
        Dim srcAddr As Short    '��λ����ַ����0
        Dim dstAddr As Short    '���ƿ���ַ
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=16)> Dim rmtHost As String '���ƿ�IP��ַ
        'Dim rmtHost0 As Byte      '���ƿ�IP��ַ��rmtHost0-rmtHost15)
        'Dim rmtHost1 As Byte
        'Dim rmtHost2 As Byte
        'Dim rmtHost3 As Byte
        'Dim rmtHost4 As Byte
        'Dim rmtHost5 As Byte
        'Dim rmtHost6 As Byte
        'Dim rmtHost7 As Byte
        'Dim rmtHost8 As Byte
        'Dim rmtHost9 As Byte
        'Dim rmtHost10 As Byte
        'Dim rmtHost11 As Byte
        'Dim rmtHost12 As Byte
        'Dim rmtHost13 As Byte
        'Dim rmtHost14 As Byte
        'Dim rmtHost15 As Byte
        Dim txTimeo As Integer          '���ͺ�ȴ�Ӧ��ʱ�� ====��ʱʱ��ӦΪtxTimeo*txRepeat
        Dim txRepeat As Integer      'ʧ���ط�����
        Dim txSlide As Integer       '��������
        Dim key As Integer
        Dim pkpLength As Integer      '���ݰ���С
    End Structure

    Public Structure TSenderParam
        Dim devParam As TDeviceParam  'ͨѶ����
        Dim wmHandle As Integer           'Ӧ�ó������ڽ���Ӧ����Ϣ�Ĵ�����
        Dim wmMessage As Integer         '�������Ϣֵ
        Dim wmLParam As Integer          '��Ϣ����ʱ��LParam����
        Dim notifyMode As Integer        '���͹��̵���Ϣ����ģʽ��ȡֵΪ��NOTIFY_NONE/NOTIFY_BLOCK/NOTIFY_EVENT
    End Structure

    Structure TNotifyParam
        Dim notify As Short
        Dim Command As Short
        Dim Result As Integer
        Dim Status As Integer
        Dim Param As TDeviceParam
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=NOTIFY_BUFFER_LEN)> Dim Buffer As String
        Dim size As Integer
    End Structure

    Structure TPowerSchedule
        Dim Enabled As Integer
        Dim Mode As Integer
        <MarshalAs(UnmanagedType.Struct, SizeConst:=21)> Dim OpenTime() As TTimeStamp
        <MarshalAs(UnmanagedType.Struct, SizeConst:=21)> Dim CloseTime() As TTimeStamp
        Dim Checksum As Integer
    End Structure

    Structure TBrightSchedule
        Dim Enabled As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=24)> Dim Bright As String
        Dim Checksum As Integer
    End Structure

    '��̬���ӿ��ʼ��
    Declare Function LED_Startup Lib "LEDSender2010.dll" () As Integer

    '��̬���ӿ�����
    Declare Function LED_Cleanup Lib "LEDSender2010.dll" () As Integer

    '��λ���ƿ���Ŀ���ţ�������ʾ���ƿ�Flash�д洢�Ľ�Ŀ
    Declare Function LED_ResetDisplay Lib "LEDSender2010.dll" (ByRef Param As TSenderParam) As Integer

    '�������ݴ���ת��
    Declare Function LED_ComTransfer Lib "LEDSender2010.dll" (ByRef Param As TSenderParam, ByVal data() As Byte, ByVal size As Integer) As Integer
    Declare Function LED_ComTransfer_Dapu Lib "LEDSender2010.dll" (ByRef Param As TSenderParam, ByVal data0 As Byte, ByVal data1 As Byte) As Integer

    'У��ʱ�䣬�Ե�ǰ�������ϵͳʱ��У�����ƿ���ʱ��
    Declare Function LED_AdjustTime Lib "LEDSender2010.dll" (ByRef Param As TSenderParam) As Integer

    'У��ʱ����չ����ָ����ʱ��У�����ƿ���ʱ��
    ' Declare Function LED_AdjustTimeEx Lib "LEDSender2010.dll" (ByVal Param As TSenderParam, ByVal time As TSystemTime) As Integer
    '���ÿ��ƿ���Դ value=LED_POWER_ON��ʾ������Դ value=LED_POWER_OFF��ʾ�رյ�Դ
    Declare Function LED_SetPower Lib "LEDSender2010.dll" (ByRef Param As TSenderParam, ByVal value As Integer) As Integer

    '��ȡ���ƿ���Դ״̬
    Declare Function LED_GetPower Lib "LEDSender2010.dll" (ByRef Param As TSenderParam) As Integer

    '���ÿ��ƿ����� valueȡֵ��Χ0-7
    Declare Function LED_SetBright Lib "LEDSender2010.dll" (ByRef Param As TSenderParam, ByVal value As Integer) As Integer

    '��ȡ���ƿ�����
    Declare Function LED_GetBright Lib "LEDSender2010.dll" (ByRef Param As TSenderParam) As Integer

    '���ÿ��ƿ��Ķ�ʱ�������ƻ�
    Declare Function LED_SetPowerSchedule Lib "LEDSender2010.dll" (ByVal Param As TSenderParam, ByVal value As TPowerSchedule) As Integer

    '��ȡ���ƿ��Ķ�ʱ�������ƻ�
    Declare Function LED_GetPowerShedule Lib "LEDSender2010.dll" (ByVal Param As TSenderParam) As Integer

    '���ÿ��ƿ��Ķ�ʱ���ȵ��ڼƻ�
    Declare Function LED_SetBrightSchedule Lib "LEDSender2010.dll" (ByVal Param As TSenderParam, ByVal value As TBrightSchedule) As Integer

    '��ȡ���ƿ��Ķ�ʱ���ȵ��ڼƻ�
    Declare Function LED_GetBrightSchedule Lib "LEDSender2010.dll" (ByVal Param As TSenderParam) As Integer

    '���ͽ�Ŀ���� indexΪMakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�����ķ���ֵ
    Declare Function LED_SendToScreen Lib "LEDSender2010.dll" (ByRef Param As TSenderParam, ByVal index As Integer) As Integer

    '��ȡ���ƿ�Ӧ����������
    Declare Function LED_GetNotifyParam Lib "LEDSender2010.dll" (ByRef notify As TNotifyParam, ByVal index As Integer) As Integer
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
    Declare Function MakeRoot Lib "LEDSender2010.dll" (ByVal RootType As Integer, ByVal ColorMode As Integer, Optional ByVal Survive As Integer = ROOT_SURVIVE_ALWAYS) As Integer

    '���ɽ�Ŀ���ݣ�������Ҫ����[AddRegion]->[AddLeaf]->[AddObject]->[AddWindows/AddDateTime��]
    '  RootType ������ΪROOT_PLAY_CHAPTER
    '  ActionMode ������Ϊ0
    '  ChapterIndex Ҫ���µĽ�Ŀ���
    '  ColorMode ͬMakeRoot�еĶ���
    '  time ���ŵ�ʱ�䳤��
    '  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
    '                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
    Declare Function MakeChapter Lib "LEDSender2010.dll" (ByVal RootType As Integer, ByVal ActionMode As Integer, ByVal ChapterIndex As Integer, ByVal ColorMode As Integer, ByVal time As Integer, ByVal wait As Integer) As Integer

    '���ɷ���/���򣬺�����Ҫ����[AddLeaf]->[AddObject]->[AddWindows/AddDateTime��]
    '  RootType ������ΪROOT_PLAY_REGION
    '  ActionMode ������Ϊ0
    '  ChapterIndex Ҫ���µĽ�Ŀ���
    '  RegionIndex Ҫ���µķ���/�������
    '  ColorMode ͬMakeRoot�еĶ���
    '  left��top��width��height ���ϡ���ȡ��߶�
    '  border ��ˮ�߿�
    Declare Function MakeRegion Lib "LEDSender2010.dll" (ByVal RootType As Integer, ByVal ActionMode As Integer, ByVal ChapterIndex As Integer, ByVal RegionIndex As Integer, ByVal ColorMode As Integer, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal border As Integer) As Integer

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
    Declare Function MakeLeaf Lib "LEDSender2010.dll" (ByVal RootType As Integer, ByVal ActionMode As Integer, ByVal ChapterIndex As Integer, ByVal RegionIndex As Integer, ByVal LeafIndex As Integer, ByVal ColorMode As Integer, ByVal time As Integer, ByVal wait As Integer) As Integer

    '���ɲ��Ŷ��󣬺�����Ҫ����[AddWindows/AddDateTime��]
    '  RootType ������ΪROOT_PLAY_LEAF
    '  ActionMode ������Ϊ0
    '  ChapterIndex Ҫ���µĽ�Ŀ���
    '  RegionIndex Ҫ���µķ���/�������
    '  LeafIndex Ҫ���µ�ҳ�����
    '  ObjectIndex Ҫ���µĶ������
    '  ColorMode ͬMakeRoot�еĶ���
    Declare Function MakeObject Lib "LEDSender2010.dll" (ByVal RootType As Integer, ByVal ActionMode As Integer, ByVal ChapterIndex As Integer, ByVal RegionIndex As Integer, ByVal LeafIndex As Integer, ByVal ObjectIndex As Integer, ByVal ColorMode As Integer) As Integer

    '��ӽ�Ŀ
    '  num ��Ŀ���ݻ�������ţ���MakeRoot�ķ���ֵ
    '  time ���ŵ�ʱ�䳤�ȣ���λΪ����
    '  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
    '                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
    Declare Function AddChapter Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal time As Integer, ByVal wait As Short) As Integer

    '��ӷ���/����
    '  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter�ķ���ֵ
    '  left��top��width��height ���ϡ���ȡ��߶�
    '  border ��ˮ�߿�
    Declare Function AddRegion Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal border As Integer) As Integer

    '���ҳ��
    '  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion�ķ���ֵ
    '  time ���ŵ�ʱ�䳤�ȣ���λΪ����
    '  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
    '                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һҳ��
    Declare Function AddLeaf Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal time As Integer, ByVal wait As Short) As Integer

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
    Declare Function AddDateTime Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal transparent As Integer, ByVal border As Integer, ByVal fontname As String, ByVal fontsize As Integer, ByVal fontcolor As Integer, ByVal fontstyle As Integer, ByVal year_offset As Integer, ByVal month_offset As Integer, ByVal day_offset As Integer, ByVal sec_offset As Integer, ByVal format As String) As Integer

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
    Declare Function AddClock Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal transparent As Integer, ByVal border As Integer, ByVal offset As Integer, ByVal bkcolor As Integer, ByVal bordercolor As Integer, ByVal borderwidth As Integer, ByVal bordershape As Integer, ByVal dotradius As Integer, ByVal adotwidth As Integer, ByVal adotcolor As Integer, ByVal bdotwidth As Integer, ByVal bdotcolor As Integer, ByVal hourwidth As Integer, ByVal hourcolor As Integer, ByVal minutewidth As Integer, ByVal minutecolor As Integer, ByVal secondwidth As Integer, ByVal secondcolor As Integer) As Integer

    '��Ӷ���
    '  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
    '  left��top��width��height ���ϡ���ȡ��߶�
    '  filename avi�ļ���
    '  stretch: ͼ���Ƿ���������Ӧ�����С
    Declare Function AddMovie Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal transparent As Integer, ByVal border As Integer, ByVal filename As String, ByVal stretch As Integer) As Integer

    '���ͼƬ�鲥��
    '  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
    '  left��top��width��height ���ϡ���ȡ��߶�
    '  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
    '  border ��ˮ�߿�(δʵ��)
    Declare Function AddWindows Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal transparent As Integer, ByVal border As Integer) As Integer

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
    Declare Function AddChildWindow Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal dc As Integer, ByVal src_width As Integer, ByVal src_height As Integer, ByVal alignment As Integer, ByVal inmethod As Integer, ByVal inspeed As Integer, ByVal outmethod As Integer, ByVal outspeed As Integer, ByVal stopmethod As Integer, ByVal stopspeed As Integer, ByVal stoptime As Integer) As Integer

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
    Declare Function AddChildPicture Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal filename As String, ByVal alignment As Integer, ByVal inmethod As Integer, ByVal inspeed As Integer, ByVal outmethod As Integer, ByVal outspeed As Integer, ByVal stopmethod As Integer, ByVal stopspeed As Integer, ByVal stoptime As Integer) As Integer

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
    Declare Function AddChildText Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal str As String, ByVal fontname As String, ByVal fontsize As Integer, ByVal fontcolor As Integer, ByVal fontstyle As Integer, ByVal wordwrap As Integer, ByVal alignment As Integer, ByVal inmethod As Integer, ByVal inspeed As Integer, ByVal outmethod As Integer, ByVal outspeed As Integer, ByVal stopmethod As Integer, ByVal stopspeed As Integer, ByVal stoptime As Integer) As Integer

    '������������鲥��
    '  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
    '  left��top��width��height ���ϡ���ȡ��߶�
    '  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
    '  border ��ˮ�߿�(δʵ��)
    Declare Function AddStrings Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal transparent As Integer, ByVal border As Integer) As Integer

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
    Declare Function AddChildString Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal str As String, ByVal fontset As Integer, ByVal color As Integer, ByVal inmethod As Integer, ByVal inspeed As Integer, ByVal outmethod As Integer, ByVal outspeed As Integer, ByVal stopmethod As Integer, ByVal stopspeed As Integer, ByVal stoptime As Integer) As Integer

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
    Declare Function AddWindow Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal transparent As Integer, ByVal border As Integer, ByVal dc As Integer, ByVal src_width As Integer, ByVal src_height As Integer, ByVal alignment As Integer, ByVal inmethod As Integer, ByVal inspeed As Integer, ByVal outmethod As Integer, ByVal outspeed As Integer, ByVal stopmethod As Integer, ByVal stopspeed As Integer, ByVal stoptime As Integer) As Integer

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
    Declare Function AddPicture Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal transparent As Integer, ByVal border As Integer, ByVal filename As String, ByVal alignment As Integer, ByVal inmethod As Integer, ByVal inspeed As Integer, ByVal outmethod As Integer, ByVal outspeed As Integer, ByVal stopmethod As Integer, ByVal stopspeed As Integer, ByVal stoptime As Integer) As Integer

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
    Declare Function AddTable Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal transparent As Integer, ByVal profile As String, ByVal content As String, ByVal inmethod As Integer, ByVal inspeed As Integer, ByVal outmethod As Integer, ByVal outspeed As Integer, ByVal stopmethod As Integer, ByVal stopspeed As Integer, ByVal stoptime As Integer) As Integer

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
    Declare Function AddText Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal transparent As Integer, ByVal border As Integer, ByVal str As String, ByVal fontname As String, ByVal fontsize As Integer, ByVal fontcolor As Integer, ByVal fontstyle As Integer, ByVal wordwrap As Integer, ByVal alignment As Integer, ByVal inmethod As Integer, ByVal inspeed As Integer, ByVal outmethod As Integer, ByVal outspeed As Integer, ByVal stopmethod As Integer, ByVal stopspeed As Integer, ByVal stoptime As Integer) As Integer

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
    Declare Function AddString Lib "LEDSender2010.dll" (ByVal Num As Short, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer, ByVal transparent As Integer, ByVal border As Integer, ByVal str As String, ByVal fontset As Integer, ByVal color As Integer, ByVal inmethod As Integer, ByVal inspeed As Integer, ByVal outmethod As Integer, ByVal outspeed As Integer, ByVal stopmethod As Integer, ByVal stopspeed As Integer, ByVal stoptime As Integer) As Integer
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

End Module
