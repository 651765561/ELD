Attribute VB_Name = "LEDAPI"
Option Explicit

'通讯方式常量
Public Const DEVICE_TYPE_COM = 0
Public Const DEVICE_TYPE_UDP = 1
Public Const DEVICE_TYPE_485 = 2

'串行通讯速度常量
Public Const SBR_57600 = 0
Public Const SBR_38400 = 1
Public Const SBR_19200 = 2
Public Const SBR_9600 = 3

'是否等待下位机应答，直接发送所有数据
Public Const NOTIFY_NONE = 1
'是否阻塞方式；是则等到发送完成或者超时，才返回；否则立即返回
Public Const NOTIFY_BLOCK = 2
'是否将发送结果以Windows窗体消息方式送到调用得应用
Public Const NOTIFY_EVENT = 4

Public Const R_DEVICE_READY = 0
Public Const R_DEVICE_INVALID = -1
Public Const R_DEVICE_BUSY = -2
Public Const R_FONTSET_INVALID = -3
Public Const R_DLL_INIT_IVALID = -4
Public Const R_IGNORE_RESPOND = -5

'Chapter和Leaf中，播放时间控制
Public Const WAIT_USE_TIME = 0   '按照指定的时间长度播放，到时间就切到下一个
Public Const WAIT_CHILD = 1      '等待子项目的播放，如果到了指定的时间长度，而子项目还没有播完，则等待播完

Public Const V_FALSE = 0
Public Const V_TRUE = 1

'显示屏类型常量
Public Const COLOR_MODE_UNICOLOR = 1         '单色显示屏
Public Const COLOR_MODE_DOUBLE = 2           '双色显示屏
Public Const COLOR_MODE_THREE = 3            '全彩无灰度
Public Const COLOR_MODE_FULLCOLOR = 4        '全彩

'显示数据命令
Public Const ROOT_UPDATE = 19            '更新下位机程序
Public Const ROOT_FONTSET = 20           '下载字库
Public Const ROOT_PLAY = 33              '节目数据，保存到RAM，掉电丢失
Public Const ROOT_DOWNLOAD = 34          '节目数据，保存到Flash
Public Const ROOT_PLAY_CHAPTER = 35      '插入或者更新某一节目
Public Const ROOT_PLAY_REGION = 37       '插入或者更新某一分区/区域
Public Const ROOT_PLAY_LEAF = 39         '插入或者更新某一页面
Public Const ROOT_PLAY_OBJECT = 41       '插入或者更新某一对象

Public Const ACTMODE_INSERT = 0  '插入操作
Public Const ACTMODE_REPLACE = 1  '替换操作

'Windows字体类型定义
Public Const WFS_NONE = 0                '普通样式
Public Const WFS_BOLD = 1                '粗体
Public Const WFS_ITALIC = 2              '斜体
Public Const WFS_UNDERLINE = 4           '下划线
Public Const WFS_STRIKEOUT = 8           '删除线

'流控制常量
Public Const FLOW_NONE = 0
Public Const FLOW_RTS_CTS = 1

'内码文字字体
Public Const FONT_SET_16 = 0             '16点阵字体
Public Const FONT_SET_24 = 1             '24点阵字体

'RAM节目播放
Public Const ROOT_SURVIVE_ALWAYS = -1

'下位机应答标识
Public Const LM_RX_COMPLETE = 1
Public Const LM_TX_COMPLETE = 2
Public Const LM_RESPOND = 3
Public Const LM_TIMEOUT = 4
Public Const LM_NOTIFY = 5
Public Const LM_PARAM = 6
Public Const LM_TX_PROGRESS = 7
Public Const LM_RX_PROGRESS = 8
Public Const RESULT_FLASH = 65535

'电源状态常量
Public Const LED_POWER_OFF = 0
Public Const LED_POWER_ON = 1

'正计时、倒计时type参数
Public Const CT_COUNTUP = 0             '正计时
Public Const CT_COUNTDOWN = 1           '倒计时
'正计时、倒计时format参数
Public Const CF_HNS = 0                 '时分秒（相对值）
Public Const CF_HN = 1                  '时分（相对值）
Public Const CF_NS = 2                  '分秒（相对值）
Public Const CF_H = 3                   '时（相对值）
Public Const CF_N = 4                   '分（相对值）
Public Const CF_S = 5                   '秒（相对值）
Public Const CF_DAY = 6                 '天数（绝对数量）
Public Const CF_HOUR = 7                '小时数（绝对数量）
Public Const CF_MINUTE = 8              '分钟数（绝对数量）
Public Const CF_SECOND = 9              '秒数（绝对数量）

'模拟时钟边框形状
Public Const SHAPE_RECTANGLE = 0        '方形
Public Const SHAPE_ROUNDRECT = 1        '圆角方形
Public Const SHAPE_CIRCLE = 2           '圆形

'命令定义
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

'通讯设备参数结构
Type TDeviceParam
  devType As Integer    '通讯类型，DEVICE_TYPE_COM(0)为串口通讯，DEVICE_TYPE_UDP(1)为网络通讯
  comSpeed As Integer   '串口通讯速度(SBR_57600/SBR_38400/SBR_19200/SBR_9600)
  comPort As Integer    '串口号
  comFlow As Integer    '串口流控制
  locPort As Integer    '网络通讯本地端口
  rmtPort As Integer    '网络通讯远程控制卡端口
  srcAddr As Integer    '上位机地址，填0
  dstAddr As Integer    '控制卡地址
  'rmtHost(256) As Byte  '控制卡IP地址
  rmtHost0 As Byte      '控制卡IP地址（rmtHost0-rmtHost15)
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
  txTimeo As Long       '发送后等待应答时间 ====超时时间应为txTimeo*txRepeat
  txRepeat As Long      '失败重发次数
  txSlide As Long       '滑动窗口
  key As Long
  pkpLength As Long     '数据包大小
End Type

Type TSenderParam
  devParam As TDeviceParam  '通讯参数
  wmHandle As Long          '应用程序用于接收应答消息的窗体句柄
  wmMessage As Long         '窗体的消息值
  wmLParam As Long          '消息返回时的LParam参数
  notifyMode As Long        '发送过程的消息处理模式，取值为：NOTIFY_NONE/NOTIFY_BLOCK/NOTIFY_EVENT
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

'动态链接库初始化
Declare Function LED_Startup Lib "LEDSender2010.dll" () As Long

'动态链接库销毁
Declare Function LED_Cleanup Lib "LEDSender2010.dll" () As Long

'复位控制卡节目播放，重新显示控制卡Flash中存储的节目
Declare Function LED_Reset Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'网口数据串口转发
Declare Function LED_ComTransfer Lib "LEDSender2010.dll" (Param As TSenderParam, data As Byte, ByVal Size As Long) As Long
Declare Function LED_ComTransfer_Dapu Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal data0 As Byte, ByVal data1 As Byte) As Long

'校正时间，以当前计算机的系统时间校正控制卡的时钟
Declare Function LED_AdjustTime Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'校正时间扩展，以指定的时间校正控制卡的时钟
Declare Function LED_AdjustTimeEx Lib "LEDSender2010.dll" (Param As TSenderParam, time As TSystemTime) As Long

'直接发送字符串
Declare Function LED_SendStringDirectly Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal value As String) As Long

'直接发送数据
Declare Function LED_SendBufferDirectly Lib "LEDSender2010.dll" (Param As TSenderParam, Buffer As Byte, ByVal Size As Long) As Long

'－－－－变量协议相关函数－－－－
'变量协议初始化
Declare Function Import_Init Lib "LEDSender2010.dll" () As Long

'变量协议添加整数
Declare Function Import_AddInt Lib "LEDSender2010.dll" (ByVal AFormat As String, ByVal value As Long) As Long

'变量协议添加浮点数
Declare Function Import_AddFloat Lib "LEDSender2010.dll" (ByVal AFormat As String, ByVal value As Single) As Long

'变量协议发送
Declare Function Import_Send Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'设置控制卡电源 value=LED_POWER_ON表示开启电源 value=LED_POWER_OFF表示关闭电源
Declare Function LED_SetPower Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal value As Long) As Long

'读取控制卡电源状态
Declare Function LED_GetPower Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'设置控制卡5V输出 value=1 value=0
Declare Function LED_SetSwitch Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal value As Long) As Long

'读取控制卡5V输出状态
Declare Function LED_GetSwitch Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'设置控制卡亮度 value取值范围0-7
Declare Function LED_SetBright Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal value As Long) As Long

'读取控制卡亮度
Declare Function LED_GetBright Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'设置控制卡的定时开关屏计划
Declare Function LED_SetPowerSchedule Lib "LEDSender2010.dll" (Param As TSenderParam, value As TPowerSchedule) As Long

'读取控制卡的定时开关屏计划
Declare Function LED_GetPowerShedule Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'设置控制卡的定时亮度调节计划
Declare Function LED_SetBrightSchedule Lib "LEDSender2010.dll" (Param As TSenderParam, value As TBrightSchedule) As Long

'读取控制卡的定时亮度调节计划
Declare Function LED_GetBrightSchedule Lib "LEDSender2010.dll" (Param As TSenderParam) As Long

'发送节目数据 index为MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject函数的返回值
Declare Function LED_SendToScreen Lib "LEDSender2010.dll" (Param As TSenderParam, ByVal index As Long) As Long

'获取控制卡应答结果的数据
Declare Function LED_GetNotifyParam Lib "LEDSender2010.dll" (notify As TNotifyParam, ByVal index As Long) As Long

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

'节目数据组织形式
'  ROOT
'   |
'   |---Chapter(节目)
'   |      |
'   |      |---Region(区域/分区)
'   |      |     |
'   |      |     |---Leaf(页面)
'   |      |     |    |
'   |      |     |    |---Object(对象[文字、时钟、图片等])
'   |      |     |    |
'   |      |     |    |---Object(对象[文字、时钟、图片等])
'   |      |     |    |
'   |      |     |    |   ......
'   |      |     |    |
'   |      |     |
'   |      |     |---Leaf(页面)
'   |      |     |
'   |      |     |   ......
'   |      |     |
'   |      |
'   |      |---Region(区域/分区)
'   |      |
'   |      |   ......
'   |      |
'   |---Chapter(节目)
'   |
'   |   ......


'生成节目数据
'  RootType 为节目类型；=ROOT_PLAY表示更新控制卡RAM中的节目(掉电丢失)；=ROOT_DOWNLOAD表示更新控制卡Flash中的节目(掉电不丢失)
'  ColorMode 为颜色模式；取值为COLOR_MODE_MONO或者COLOR
'  survive 为RAM节目生存时间，在RootType=ROOT_PLAY时有效，当RAM节目播放达到时间后，恢复显示FLASH中的节目
Declare Function MakeRoot Lib "LEDSender2010.dll" (ByVal RootType As Long, ByVal ColorMode As Long, Optional ByVal Survive As Long = ROOT_SURVIVE_ALWAYS) As Long

'生成节目数据，后续需要调用[AddRegion]->[AddLeaf]->[AddObject]->[AddWindows/AddDateTime等]
'  RootType 必须设为ROOT_PLAY_CHAPTER
'  ActionMode 必须设为0
'  ChapterIndex 要更新的节目序号
'  ColorMode 同MakeRoot中的定义
'  time 播放的时间长度
'  wait 等待模式，=WAIT_CHILD，表示当达到播放时间长度时，需要等待子节目播放完成再切换；
'                 =WAIT_USE_TIME，表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一节目
Declare Function MakeChapter Lib "LEDSender2010.dll" (ByVal RootType As Long, ByVal ActionMode As Long, ByVal ChapterIndex As Long, ByVal ColorMode As Long, ByVal time As Long, ByVal wait As Integer) As Long

'生成分区/区域，后续需要调用[AddLeaf]->[AddObject]->[AddWindows/AddDateTime等]
'  RootType 必须设为ROOT_PLAY_REGION
'  ActionMode 必须设为0
'  ChapterIndex 要更新的节目序号
'  RegionIndex 要更新的分区/区域序号
'  ColorMode 同MakeRoot中的定义
'  left、top、width、height 左、上、宽度、高度
'  border 流水边框
Declare Function MakeRegion Lib "LEDSender2010.dll" (ByVal RootType As Long, ByVal ActionMode As Long, ByVal ChapterIndex As Long, ByVal RegionIndex As Long, ByVal ColorMode As Long, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal border As Long) As Long

'生成页面，后续需要调用[AddObject]->[AddWindows/AddDateTime等]
'  RootType 必须设为ROOT_PLAY_LEAF
'  ActionMode 必须设为0
'  ChapterIndex 要更新的节目序号
'  RegionIndex 要更新的分区/区域序号
'  LeafIndex 要更新的页面序号
'  ColorMode 同MakeRoot中的定义
'  time 播放的时间长度
'  wait 等待模式，=WAIT_CHILD，表示当达到播放时间长度时，需要等待子节目播放完成再切换；
'                 =WAIT_USE_TIME，表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一页面
Declare Function MakeLeaf Lib "LEDSender2010.dll" (ByVal RootType As Long, ByVal ActionMode As Long, ByVal ChapterIndex As Long, ByVal RegionIndex As Long, ByVal LeafIndex As Long, ByVal ColorMode As Long, ByVal time As Long, ByVal wait As Integer) As Long

'生成播放对象，后续需要调用[AddWindows/AddDateTime等]
'  RootType 必须设为ROOT_PLAY_LEAF
'  ActionMode 必须设为0
'  ChapterIndex 要更新的节目序号
'  RegionIndex 要更新的分区/区域序号
'  LeafIndex 要更新的页面序号
'  ObjectIndex 要更新的对象序号
'  ColorMode 同MakeRoot中的定义
Declare Function MakeObject Lib "LEDSender2010.dll" (ByVal RootType As Long, ByVal ActionMode As Long, ByVal ChapterIndex As Long, ByVal RegionIndex As Long, ByVal LeafIndex As Long, ByVal ObjectIndex As Long, ByVal ColorMode As Long) As Long

'添加节目
'  num 节目数据缓冲区编号，是MakeRoot的返回值
'  time 播放的时间长度，单位为毫秒
'  wait 等待模式，=WAIT_CHILD，表示当达到播放时间长度时，需要等待子节目播放完成再切换；
'                 =WAIT_USE_TIME，表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一节目
Declare Function AddChapter Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal time As Long, ByVal wait As Integer) As Long

'添加分区/区域
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter的返回值
'  left、top、width、height 左、上、宽度、高度
'  border 流水边框
Declare Function AddRegion Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal border As Long) As Long

'添加页面
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion的返回值
'  time 播放的时间长度，单位为毫秒
'  wait 等待模式，=WAIT_CHILD，表示当达到播放时间长度时，需要等待子节目播放完成再切换；
'                 =WAIT_USE_TIME，表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一页面
Declare Function AddLeaf Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal time As Long, ByVal wait As Integer) As Long

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

'添加日期时间显示
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  left、top、width、height 左、上、宽度、高度
'  transparent 是否透明 =1表示透明；=0表示不透明
'  border 流水边框(未实现)
'  fontname 字体名称
'  fontsize 字体大小
'  fontcolor 字体颜色
'  fontstyle 字体样式 举例：=WFS_BOLD表示粗体；=WFS_ITALIC表示斜体；=WFS_BOLD+WFS_ITALIC表示粗斜体
'  year_offset 年偏移量
'  month_offset 月偏移量
'  day_offset 日偏移量
'  sec_offset 秒偏移量
'  format 显示格式
'      #y表示年 #m表示月 #d表示日 #h表示时 #n表示分 #s表示秒 #w表示星期 #c表示农历
'      举例： format="#y年#m月#d日 #h时#n分#s秒 星期#w 农历#c"时，显示为"2009年06月27日 12时38分45秒 星期六 农历五月初五"
Declare Function AddDateTime Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal fontname As String, ByVal fontsize As Long, ByVal fontcolor As Long, ByVal fontstyle As Long, ByVal year_offset As Long, ByVal month_offset As Long, ByVal day_offset As Long, ByVal sec_offset As Long, ByVal format As String) As Long

'添加模拟时钟
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  left、top、width、height 左、上、宽度、高度
'  transparent 是否透明 =1表示透明；=0表示不透明
'  border 流水边框(未实现)
'  offset 秒偏移量
'  bkcolor: 背景颜色
'  bordercolor: 边框颜色
'  borderwidth: 边框颜色
'  bordershape: 边框形状 =0表示正方形；=1表示圆角方形；=2表示圆形
'  dotradius: 刻度距离表盘中心半径
'  adotwidth: 0369点刻度大小
'  adotcolor: 0369点刻度颜色
'  bdotwidth: 其他点刻度大小
'  bdotcolor: 其他点刻度颜色
'  hourwidth: 时针粗细
'  hourcolor: 时针颜色
'  minutewidth: 分针粗细
'  minutecolor: 分针颜色
'  secondwidth: 秒针粗细
'  secondcolor: 秒针颜色
Declare Function AddClock Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal offset As Long, ByVal bkcolor As Long, ByVal bordercolor As Long, ByVal borderwidth As Long, ByVal bordershape As Long, ByVal dotradius As Long, ByVal adotwidth As Long, ByVal adotcolor As Long, ByVal bdotwidth As Long, ByVal bdotcolor As Long, ByVal hourwidth As Long, ByVal hourcolor As Long, ByVal minutewidth As Long, ByVal minutecolor As Long, ByVal secondwidth As Long, ByVal secondcolor As Long) As Long

'添加动画
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  left、top、width、height 左、上、宽度、高度
'  filename avi文件名
'  stretch: 图像是否拉伸以适应对象大小
Declare Function AddMovie Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal filename As String, ByVal stretch As Long) As Long

'添加图片组播放
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  left、top、width、height 左、上、宽度、高度
'  transparent 是否透明 =1表示透明；=0表示不透明
'  border 流水边框(未实现)
Declare Function AddWindows Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long) As Long

'添加图片组的子图片 此函数要跟在AddWindows后面调用
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  dc 源图片DC句柄
'  width 图片宽度
'  height 图片高度
'  inmethod 引入方式(下面有列表说明)
'  inspeed 引入速度(取值范围0-5，从快到慢)
'  outmethod 引出方式(下面有列表说明)
'  outspeed 引出速度(取值范围0-5，从快到慢)
'  stopmethod 停留方式(下面有列表说明)
'  stopspeed 停留速度(取值范围0-5，从快到慢)
'  stoptime 停留时间(单位毫秒)
Declare Function AddChildWindow Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal dc As Long, ByVal src_width As Long, ByVal src_height As Long, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'添加图片组的子图片 此函数要跟在AddWindows后面调用
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  filename 图片文件名
'  inmethod 引入方式(下面有列表说明)
'  inspeed 引入速度(取值范围0-5，从快到慢)
'  outmethod 引出方式(下面有列表说明)
'  outspeed 引出速度(取值范围0-5，从快到慢)
'  stopmethod 停留方式(下面有列表说明)
'  stopspeed 停留速度(取值范围0-5，从快到慢)
'  stoptime 停留时间(单位毫秒)
Declare Function AddChildPicture Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal filename As String, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'添加图片组的子图片 此函数要跟在AddWindows后面调用
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  str 文字字符串
'  fontname 字体名称
'  fontsize 字体大小
'  fontcolor 字体颜色
'  fontstyle 字体样式 举例：=WFS_BOLD表示粗体；=WFS_ITALIC表示斜体；=WFS_BOLD+WFS_ITALIC表示粗斜体
'  wordwrap 是否自动换行 =1自动换行；=0不自动换行
'  inmethod 引入方式(下面有列表说明)
'  inspeed 引入速度(取值范围0-5，从快到慢)
'  outmethod 引出方式(下面有列表说明)
'  outspeed 引出速度(取值范围0-5，从快到慢)
'  stopmethod 停留方式(下面有列表说明)
'  stopspeed 停留速度(取值范围0-5，从快到慢)
'  stoptime 停留时间(单位毫秒)
Declare Function AddChildText Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal str As String, ByVal fontname As String, ByVal fontsize As Long, ByVal fontcolor As Long, ByVal fontstyle As Long, ByVal wordwrap As Long, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'添加内码文字组播放
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  left、top、width、height 左、上、宽度、高度
'  transparent 是否透明 =1表示透明；=0表示不透明
'  border 流水边框(未实现)
Declare Function AddStrings Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long) As Long

'添加图片组的子图片 此函数要跟在AddWindows后面调用
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  str 文字字符串
'  fontset 字库 =FONTSET_16P表示16点阵字库；=FONTSET_24P表示24点阵字库
'  color 颜色
'  inmethod 引入方式(下面有列表说明)
'  inspeed 引入速度(取值范围0-5，从快到慢)
'  outmethod 引出方式(下面有列表说明)
'  outspeed 引出速度(取值范围0-5，从快到慢)
'  stopmethod 停留方式(下面有列表说明)
'  stopspeed 停留速度(取值范围0-5，从快到慢)
'  stoptime 停留时间(单位毫秒)
Declare Function AddChildString Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal str As String, ByVal fontset As Long, ByVal color As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'添加图片点阵播放
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  left、top、width、height 左、上、宽度、高度
'  transparent 是否透明 =1表示透明；=0表示不透明
'  border 流水边框(未实现)
'  dc 源图片DC句柄
'  src_width 图片宽度
'  src_height 图片高度
'  inmethod 引入方式(下面有列表说明)
'  inspeed 引入速度(取值范围0-5，从快到慢)
'  outmethod 引出方式(下面有列表说明)
'  outspeed 引出速度(取值范围0-5，从快到慢)
'  stopmethod 停留方式(下面有列表说明)
'  stopspeed 停留速度(取值范围0-5，从快到慢)
'  stoptime 停留时间(单位毫秒)
Declare Function AddWindow Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal dc As Long, ByVal src_width As Long, ByVal src_height As Long, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'添加图片文件播放
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  left、top、width、height 左、上、宽度、高度
'  transparent 是否透明 =1表示透明；=0表示不透明
'  border 流水边框(未实现)
'  filename 图片文件
'  inmethod 引入方式(下面有列表说明)
'  inspeed 引入速度(取值范围0-5，从快到慢)
'  outmethod 引出方式(下面有列表说明)
'  outspeed 引出速度(取值范围0-5，从快到慢)
'  stopmethod 停留方式(下面有列表说明)
'  stopspeed 停留速度(取值范围0-5，从快到慢)
'  stoptime 停留时间(单位毫秒)
Declare Function AddPicture Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal filename As String, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'添加表格播放
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  left、top、width、height 左、上、宽度、高度
'  transparent 是否透明 =1表示透明；=0表示不透明
'  profile 表格定义文件
'  content 表格内容
'  inmethod 引入方式(下面有列表说明)
'  inspeed 引入速度(取值范围0-5，从快到慢)
'  outmethod 引出方式(下面有列表说明)
'  outspeed 引出速度(取值范围0-5，从快到慢)
'  stopmethod 停留方式(下面有列表说明)
'  stopspeed 停留速度(取值范围0-5，从快到慢)
'  stoptime 停留时间(单位毫秒)
Declare Function AddTable Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal profile As String, ByVal content As String, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'添加文字播放
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  left、top、width、height 左、上、宽度、高度
'  transparent 是否透明 =1表示透明；=0表示不透明
'  border 流水边框(未实现)
'  str 文字字符串
'  fontname 字体名称
'  fontsize 字体大小
'  fontcolor 字体颜色
'  fontstyle 字体样式 举例：=WFS_BOLD表示粗体；=WFS_ITALIC表示斜体；=WFS_BOLD+WFS_ITALIC表示粗斜体
'  wordwrap 是否自动换行 =1自动换行；=0不自动换行
'  inmethod 引入方式(下面有列表说明)
'  inspeed 引入速度(取值范围0-5，从快到慢)
'  outmethod 引出方式(下面有列表说明)
'  outspeed 引出速度(取值范围0-5，从快到慢)
'  stopmethod 停留方式(下面有列表说明)
'  stopspeed 停留速度(取值范围0-5，从快到慢)
'  stoptime 停留时间(单位毫秒)
Declare Function AddText Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal str As String, ByVal fontname As String, ByVal fontsize As Long, ByVal fontcolor As Long, ByVal fontstyle As Long, ByVal wordwrap As Long, ByVal alignment As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

'添加内码文字播放
'  num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
'  left、top、width、height 左、上、宽度、高度
'  transparent 是否透明 =1表示透明；=0表示不透明
'  border 流水边框(未实现)
'  str 文字字符串
'  fontset 字库 =FONTSET_16P表示16点阵字库；=FONTSET_24P表示24点阵字库
'  color 颜色
'  inmethod 引入方式(下面有列表说明)
'  inspeed 引入速度(取值范围0-5，从快到慢)
'  outmethod 引出方式(下面有列表说明)
'  outspeed 引出速度(取值范围0-5，从快到慢)
'  stopmethod 停留方式(下面有列表说明)
'  stopspeed 停留速度(取值范围0-5，从快到慢)
'  stoptime 停留时间(单位毫秒)
Declare Function AddString Lib "LEDSender2010.dll" (ByVal Num As Integer, ByVal left As Long, ByVal top As Long, ByVal width As Long, ByVal height As Long, ByVal transparent As Long, ByVal border As Long, ByVal str As String, ByVal fontset As Long, ByVal color As Long, ByVal inmethod As Long, ByVal inspeed As Long, ByVal outmethod As Long, ByVal outspeed As Long, ByVal stopmethod As Long, ByVal stopspeed As Long, ByVal stoptime As Long) As Long

' ====引入动作方式列表(数值从0开始)====
'    0 = '随机',
'    1 = '立即显示',
'    2 = '左滚显示',
'    3 = '上滚显示',
'    4 = '右滚显示',
'    5 = '连续左滚显示',
'    6 = '连续下滚显示',
'    7 = '下滚显示',
'    8 = '中间向上下展开',
'    9 = '中间向两边展开',
'   10 = '中间向四周展开',
'   11 = '从右向左移入',
'   12 = '从左向右移入',
'   13 = '从左向右展开',
'   14 = '从右向左展开',
'   15 = '从右上角移入',
'   16 = '从右下角移入',
'   17 = '从左上角移入',
'   18 = '从左下角移入',
'   19 = '从上向下移入',
'   20 = '从下向上移入',
'   21 = '横向百叶窗',
'   22 = '纵向百叶窗',
' =====================================

' ====引出动作方式列表(数值从0开始)====
'    0 = '随机',
'    1 = '不消失',
'    2 = '立即消失',
'    3 = '上下向中间合拢',
'    4 = '两边向中间合拢',
'    5 = '四周向中间合拢',
'    6 = '从左向右移出',
'    7 = '从右向左移出',
'    8 = '从右向左合拢',
'    9 = '从左向右合拢',
'   10 = '从右上角移出',
'   11 = '从右下角移出',
'   12 = '从左上角移出',
'   13 = '从左下角移出',
'   14 = '从下向上移出',
'   15 = '从上向下移出',
'   16 = '横向百叶窗',
'   17 = '纵向百叶窗'
' =====================================

' ====停留动作方式列表(数值从0开始)====
'    0 = '静态显示',
'    1 = '闪烁显示'
' =====================================

