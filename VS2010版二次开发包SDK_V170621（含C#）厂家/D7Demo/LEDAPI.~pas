unit LedAPI;

interface

uses
  Windows, SysUtils, Classes, Messages, Graphics;

const
  ETHER_ADDRESS_LENGTH = 6;
  IP_ADDRESS_LENGTH = 4;

const
  LedSender = 'LedSender2010.dll';

const
  NOTIFY_BUFFER_LEN = 512;

const
  DEVICE_TYPE_COM  = 0;
  DEVICE_TYPE_UDP  = 1;
  DEVICE_TYPE_TCP  = 3;
  DEVICE_TYPE_NONE = $ffff;

const
  ROOT_SURVIVE_ALWAYS = -1;

const
  R_DEVICE_INVALID    = -1;
  R_DEVICE_BUSY       = -2;
  R_DEVICE_READY      = 0;
  R_FONTSET_INVALID   = -3;
  R_DLL_INIT_IVALID   = -4;
  R_IGNORE_RESPOND    = -5;
  R_NOT_IN_REPORTLIST = -8;

//发送应答模式
const
  NOTIFY_NONE      =  1;
  NOTIFY_BLOCK     =  2;
  NOTIFY_EVENT     =  4;
  NOTIFY_MULTI     =  8;

//串口通讯速率常量
const
  SBR_57600   = 0;
  SBR_38400   = 1;
  SBR_19200   = 2;
  SBR_14400   = 3;
  SBR_9600    = 4;

//返回应答标识定义
const
  LM_RX_COMPLETE   = 1;
  LM_TX_COMPLETE   = 2;
  LM_RESPOND       = 3;
  LM_TIMEOUT       = 4;
  LM_NOTIFY        = 5;
  LM_PARAM         = 6;
  LM_TX_PROGRESS   = 7;
  LM_RX_PROGRESS   = 8;
  RESULT_INVALID   = 0;
  RESULT_OK        = 1;
  RESULT_NULL      = 2;
  RESULT_TRANSMIT  = $f;
  RESULT_FLASH     = $ff;

//节目组织定义
const

////////////////////////////////////////////////////////////////////////////////
  ROOT_UPDATE            = $13;
  ROOT_FONTSET           = $14;

  ROOT_PLAY              = $21;
  ROOT_DOWNLOAD          = $22;
  ROOT_PLAY_CHAPTER      = $23;
  ROOT_DOWNLOAD_CHAPTER  = $24;
  ROOT_PLAY_REGION       = $25;
  ROOT_DOWNLOAD_REGION   = $26;
  ROOT_PLAY_LEAF         = $27;
  ROOT_DOWNLOAD_LEAF     = $28;
  ROOT_PLAY_OBJECT       = $29;
  ROOT_DOWNLOAD_OBJECT   = $2a;

  ROOT_PLAY2              = $31;
  ROOT_DOWNLOAD2          = $32;
  ROOT_PLAY_CHAPTER2      = $33;
  ROOT_DOWNLOAD_CHAPTER2  = $34;
  ROOT_PLAY_REGION2       = $35;
  ROOT_DOWNLOAD_REGION2   = $36;
  ROOT_PLAY_LEAF2         = $37;
  ROOT_DOWNLOAD_LEAF2     = $38;
  ROOT_PLAY_OBJECT2       = $39;
  ROOT_DOWNLOAD_OBJECT2   = $3a;

  ROOT_PLAY3              = $41;
  ROOT_DOWNLOAD3          = $42;
  ROOT_PLAY_CHAPTER3      = $43;
  ROOT_DOWNLOAD_CHAPTER3  = $44;
  ROOT_PLAY_REGION3       = $45;
  ROOT_DOWNLOAD_REGION3   = $46;
  ROOT_PLAY_LEAF3         = $47;
  ROOT_DOWNLOAD_LEAF3     = $48;
  ROOT_PLAY_OBJECT3       = $49;
  ROOT_DOWNLOAD_OBJECT3   = $4a;
////////////////////////////////////////////////////////////////////////////////

  ACTMODE_INSERT = 0;  //插入操作
  ACTMODE_REPLACE = 1; //替换操作

  WAIT_USER_TIME = 0; //表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一幕
  WAIT_CHILD = 1;     //表示当达到播放时间长度时，需要等待子节目播放完成再切换；

  COLOR_MODE_UNICOLOR        = 1;      //单色显示屏
  COLOR_MODE_DOUBLE          = 2;      //双色显示屏
  COLOR_MODE_THREE           = 3;      //全彩无灰度
  COLOR_MODE_FULLCOLOR       = 4;      //全彩

//对齐方式定义
  ALIGN_LEFT = 0;
  ALIGN_TOP = 0;
  ALIGN_CENTER = 1;
  ALIGN_RIGHT = 2;
  ALIGN_BOTTOM = 2;

//时间格式定义，用于AddDateTime函数中format参数
  DF_YMD           = 1;      //年月日  "2004年12月31日"
  DF_HN            = 2;      //时分    "19:20"
  DF_HNS           = 3;      //时分秒  "19:20:30"
  DF_Y             = 4;      //年      "2004"
  DF_M             = 5;      //月      "12" "01" 注意：始终显示两位数字
  DF_D             = 6;      //日
  DF_H             = 7;      //时
  DF_N             = 8;      //分
  DF_S             = 9;      //秒
  DF_W             = 10;     //星期    "星期三"

//正计时、倒计时format参数
  CT_COUNTUP       = 0;      //起始时间正计时
  CT_COUNTDOWN     = 1;      //目标时间倒计时
  CT_COUNTUP_EX    = 2;      //普通正计时
  CT_COUNTDOWN_EX  = 3;      //普通倒计时
  CF_HNS           = 0;      //时分秒（相对值）
  CF_HN            = 1;      //时分（相对值）
  CF_NS            = 2;      //分秒（相对值）
  CF_H             = 3;      //时（相对值）
  CF_N             = 4;      //分（相对值）
  CF_S             = 5;      //秒（相对值）
  CF_DAY           = 6;      //天数（绝对数量）
  CF_HOUR          = 7;      //小时数（绝对数量）
  CF_MINUTE        = 8;      //分钟数（绝对数量）
  CF_SECOND        = 9;      //秒数（绝对数量）
  CF_WEEK          = 10;     //星期数（绝对数量）

  //模拟时钟边框形状参数
  SHAPE_RECTANGLE  = 0;    //方形
  SHAPE_ROUNDRECT  = 1;    //圆角方形
  SHAPE_CIRCLE     = 2;    //圆形

  LED_POWER_ON     = 1;      //显示屏电源打开
  LED_POWER_OFF    = 0;      //显示屏电源已关闭

  FONTSET_16P      = 0;      //16点阵字符
  FONTSET_24P      = 1;      //24点阵字符

  WFS_BOLD         = $1;  //粗体
  WFS_ITALIC       = $2;  //斜体
  WFS_UNDERLINE    = $4;  //下划线
  WFS_STRIKEOUT    = $8;  //删除线

  PKC_BEGIN           =  0;
  PKC_END             =  1;
  PKC_DATA            =  2;
  PKC_RESPOND         =  3;
  PKC_QUERY           =  4;
  PKC_OVERFLOW        =  5;
  PKC_ADJUST_TIME     =  6;
  PKC_GET_PARAM       =  7;
  PKC_SET_PARAM       =  8;
  PKC_GET_POWER       =  9;
  PKC_SET_POWER       = 10;
  PKC_GET_BRIGHT      = 11;
  PKC_SET_BRIGHT      = 12;
  PKC_COM_TRANSFER    = 21;
  PKC_MODEM_TRANSFER  = 22;
  PKC_GET_EXSTRING    = 28;
  PKC_SET_EXSTRING    = 29;
  PKC_SAVE_EXSTRING   = 30;
  PKC_GET_TRANSFER_ACK = 33;

  PKC_GET_POWER_SCHEDULE  = 60;
  PKC_SET_POWER_SCHEDULE  = 61;
  PKC_GET_BRIGHT_SCHEDULE = 62;
  PKC_SET_BRIGHT_SCHEDULE = 63;
  PKC_GET_CHAPTER_COUNT   = 66;  //读取节目数量
  PKC_GET_CURRENT_CHAPTER = 67;  //设置当前播放的节目
  PKC_SET_CURRENT_CHAPTER = 68;  //设置当前播放的节目
  PKC_GET_LEAF_COUNT      = 69;  //读取页面数量
  PKC_GET_CURRENT_LEAF    = 70;  //设置当前播放的页面
  PKC_SET_CURRENT_LEAF    = 71;  //设置当前播放的页面
  PKC_DSP_RESET       = 99;
  PKC_NOTIFY          = 100;
  PKC_GET_DISPLAY_BUFFER = 8925;

//下位机返回的命令代码
const
  NOTIFY_ROOT_UPDATE          = $00010001;  //在线更新控制卡程序
  NOTIFY_ROOT_UPDATE_ERROR    = $00020001;  //下载字库失败
  NOTIFY_ROOT_FONTSET         = $00010002;  //下载字库成功
  NOTIFY_ROOT_FONTSET_ERROR   = $00020002;  //下载字库失败
  NOTIFY_ROOT_DOWNLOAD        = $00010003;  //更新Flash播放节目
  NOTIFY_SET_PARAM            = $00010004;  //设置参数
  NOTIFY_SET_POWER_SCHEDULE   = $00010005;  //设置定时开关屏
  NOTIFY_SET_BRIGHT_SCHEDULE  = $00010006;  //设置定时亮度调节
  NOTIFY_SET_POWER_FLASH      = $0001000a;  //设置电源状态并保存到Flash
  NOTIFY_SET_BRIGHT_FLASH     = $0001000b;  //设置亮度并保存到Flash
  NOTIFY_GET_PLAY_BUFFER      = $00011001;  //读取控制卡显示内容
  NOTIFY_GET_SNAPSHOT         = $00013001;  //读取当前抓屏显示

type
  PTimeStamp = ^TTimeStamp;

  TDeviceParam = packed record
    devType:    Word;
    comSpeed:   Word;
    comPort:    Word;
    comFlow:    Word;
    locPort:    Word;
    rmtPort:    Word;
    srcAddr:    Word;
    dstAddr:    Word;
    rmtHost:    array[0..15] of Char;
    txTimeo:    DWord;   //发送后等待应答时间 ====超时时间应为txTimeo*txRepeat
    txRepeat:   DWord;   //失败重发次数
    txSlide:    DWord;   //划动窗口
    Key:        DWord;   //密钥
    pkpLength:  Integer; //数据包大小
  end;
  PDeviceParam = ^TDeviceParam;

  TSenderParam = packed record
    devParam:   TDeviceParam;
    wmHandle:   Integer;
    wmMessage:  Integer;
    wmLParam:   Integer;
    notifyMode: Integer;
  end;
  PSenderParam = ^TSenderParam;

  TNotifyParam = packed record
    Notify:     Word;
    Command:    Word;
    Result:     Integer;
    Status:     Integer;
    DevParam:   TDeviceParam;
    Buffer:     array[0..NOTIFY_BUFFER_LEN-1] of Byte;
    Size:       DWord;
  end;
  PNotifyParam = ^TNotifyParam;

  TNotifyParamEx = packed record
    Notify:     Word;
    Command:    Word;
    Result:     Integer;
    Status:     Integer;
    DevParam:   TDeviceParam;
    Buffer:     PByte;
    Size:       DWord;
  end;
  PNotifyParamEx = ^TNotifyParamEx;

  TPowerSchedule = packed record
    Enabled:    DWord;
    Mode:       DWord;
    OpenTime:   array [0..20] of TTimeStamp;
    CloseTime:  array [0..20] of TTimeStamp;
    Checksum:   DWord;
  end;
  PPowerSchedule = ^TPowerSchedule;

  TBrightSchedule = packed record
    Enabled:    DWord;
    Bright:     array [0..23] of Byte;
    Checksum:   DWord;
  end;
  PBrightSchedule = ^TBrightSchedule;

  TScanParam = packed record
    //Buffer:    array[0..123] of Byte;
    //Ident:     Word;
    //CRC:       Word;
    Cols:      Byte;
    Rows:      Byte;
    Mode:      Byte;
    Multiple:  Byte;
    BlockSize: DWord;
    Increase:  DWord;
    Line:      array[0..15] of Byte;
    Position:  array[0..511] of Word;
  end;
  PScanParam = ^TScanParam;

  TSystemParam = packed record
    Width:        Word;
    Height:       Word;
    ColorType:    Word;
    Frequency:    Word;
    Flag:         DWord;
    Uart:         DWord;
    MacAddr:      array [0..ETHER_ADDRESS_LENGTH-1] of Byte;
    IPAddr:       array [0..IP_ADDRESS_LENGTH-1] of Byte;
    GateMacAddr:  array [0..ETHER_ADDRESS_LENGTH-1] of Byte;
    RemoteHost:   array [0..IP_ADDRESS_LENGTH-1] of Byte;
    Brightness:   Byte;
    Import:       Byte;
    RootCount:    Byte;
    Reserved:     Byte;
    ROM_Size:     DWord;
    Left:         Integer;
    Top:          Integer;
    ScanMode:     Word;
    RemotePort:   Word;
    Line_Order:   Word;
    OE_Time:      Word;
    Shift_Freq:   Word;
    Refresh_Freq: Word;
    GateIP:       array [0..IP_ADDRESS_LENGTH-1] of Byte;
    IPMask:       array [0..IP_ADDRESS_LENGTH-1] of Byte;
    Name:         array [0..31] of Char;
    Ident:        DWord;
    Address:      DWord;
    PKPRxTimeo:   DWord;
    PKPTxTimeo:   DWord;
    PKPTxRepeat:  DWord;
  end;
  PSystemParam = ^TSystemParam;

function EncodeFontStyle(A: TFontStyles): DWord; stdcall; external LEDSender;
function DecodeFontStyle(A: DWord): TFontStyles; stdcall; external LEDSender;
function CheckPowerSchedule(Schedule: PPowerSchedule): Integer; stdcall; external LEDSender;
function CheckBrightSchedule(Schedule: PBrightSchedule): Integer; stdcall; external LEDSender;
function GetBorderFitSize(ASize: PSize; ABorder: Integer): Integer; stdcall; external LEDSender;
function GetBorderFitRect(ARect: PRect; ABorder: Integer): Integer; stdcall; external LEDSender;
function GetBorderFitRectEx(Outer: PRect; Inner: PRect; ABorder: Integer): Integer; stdcall; external LEDSender;

procedure SyncApplication(App: DWord); stdcall; external LedSender;

procedure LED_BuildGammaTable(fPrec: Double); stdcall; external LedSender;

function LED_Startup: Integer; stdcall; external LedSender;
procedure LED_Cleanup; stdcall; external LedSender;

function LED_Compress(Num: Word): Integer; stdcall; external LedSender;
function LED_Compress_Vscpp(Num: Word): Integer; stdcall; external LedSender;

function LED_GetDevice(AParam: PSenderParam): Integer; stdcall; external LedSender;
procedure LED_CloseDeviceOnTerminate(AValue: Integer); stdcall; external LedSender;

procedure LED_Preview(Index: Integer; Width: Integer; Height: Integer; PreviewFile: PChar); stdcall; external LedSender;

function LED_SetPrevChapter(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_SetNextChapter(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_SetCurChapter(AParam: PSenderParam; Value: Integer): Integer; stdcall; external LedSender;
function LED_GetCurChapter(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_GetChapterCount(AParam: PSenderParam): Integer; stdcall; external LedSender;

function LED_SetPrevLeaf(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_SetNextLeaf(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_SetCurLeaf(AParam: PSenderParam; Value: Integer): Integer; stdcall; external LedSender;
function LED_GetCurLeaf(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_GetLeafCount(AParam: PSenderParam): Integer; stdcall; external LedSender;

function LED_Query(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_GetPlayContent(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_GetSnapShot(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_ResetDisplay(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_SetUnitTest(AParam: PSenderParam; Value: Integer; Index: Integer): Integer; stdcall; external LedSender;
function LED_AdjustTime(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_AdjustTimeEx(AParam: PSenderParam; ATime: PSystemTime): Integer; stdcall; external LedSender;
function LED_SendToScreen(AParam: PSenderParam; Index: Integer): Integer; stdcall; external LedSender;
function LED_SendBufferDirectly(AParam: PSenderParam; ABuffer: PByte; ASize: Integer): Integer; stdcall; external LedSender;
function LED_SendStringDirectly(AParam: PSenderParam; AText: PChar): Integer; stdcall; external LedSender;
function LED_SendHexDirectly(AParam: PSenderParam; AText: PChar): Integer; stdcall; external LedSender;
function LED_SetPower(AParam: PSenderParam; Value: Integer): Integer; stdcall; external LedSender;
function LED_GetPower(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_SetSwitch(AParam: PSenderParam; Value: Integer): Integer; stdcall; external LedSender;
function LED_SetBright(AParam: PSenderParam; Value: Integer): Integer; stdcall; external LedSender;
function LED_GetBright(AParam: PSenderParam): Integer; stdcall; external LEDSender;
function LED_SetPowerSchedule(AParam: PSenderParam; Value: PPowerSchedule): Integer; stdcall; external LedSender;
function LED_GetPowerSchedule(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_SetBrightSchedule(AParam: PSenderParam; Value: PBrightSchedule): Integer; stdcall; external LedSender;
function LED_GetBrightSchedule(AParam: PSenderParam): Integer; stdcall; external LEDSender;
function LED_SetBoardParam(AParam: PSenderParam; Value: TSystemParam): Integer; stdcall; external LedSender;
function LED_GetBoardParam(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_SetScanParam(AParam: PSenderParam; Value: TScanParam): Integer; stdcall; external LedSender;
function LED_GetScanParam(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_SetVarString(AParam: PSenderParam; AIndex: Integer; Str: PChar; FontSet: Integer; Color: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LedSender;
function LED_SetVarString2(AParam: PSenderParam; AIndex: Integer; Str: PChar; Rotate: Integer; Survive: Integer; FontSet: Integer; Color: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LedSender;
function LED_SetVarStringSingle(AParam: PSenderParam; AIndex: Integer; Str: PChar; Color: Integer): Integer; stdcall; external LedSender;
//串口转发数据接口，此函数需要以网络方式发送，控制卡将ABuffer中的数据从控制卡的232串口转发出去
function LED_ComTransfer(AParam: PSenderParam; ABuffer: PByte; ASize: DWord): Integer; stdcall; external LedSender;
function LED_ModemTransfer(AParam: PSenderParam; ABuffer: PByte; ASize: DWord): Integer; stdcall; external LedSender;
function LED_GetTransferAck(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_GetTransferAck2(SenderParamIndex: Integer): Integer; stdcall; external LedSender;
// 控制语音播放
// Str: 播放语音内容
// Speeker: 语音声音类型（分男声、女声等）0-5
// Volumn: 音量 0-10
// Speed: 语速 0-10
// Tone: 语调 0-10
function LED_PlayVoice(AParam: PSenderParam; Str: PChar; Speaker: Integer; Volumn: Integer; Speed: Integer; Tone: Integer): Integer; stdcall; external LEDSender;

function LED_Cache_GetBoardParam(AParam: PSenderParam): Integer; stdcall; external LedSender;
function LED_Cache_GetBoardParam_ColorType: Integer; stdcall; external LedSender;
function LED_Cache_GetBoardParam_IP: PChar; stdcall; external LedSender;
function LED_Cache_GetBoardParam_Mac: PChar; stdcall; external LedSender;
function LED_Cache_GetBoardParam_Addr: Integer; stdcall; external LedSender;
function LED_Cache_GetBoardParam_Width: Integer; stdcall; external LedSender;
function LED_Cache_GetBoardParam_Height: Integer; stdcall; external LedSender;
procedure LED_Cache_SetBoardParam_ColorType(Value: Integer); stdcall; external LedSender;
procedure LED_Cache_SetBoardParam_IP(Value: PChar); stdcall; external LedSender;
procedure LED_Cache_SetBoardParam_Mac(Value: PChar); stdcall; external LedSender;
procedure LED_Cache_SetBoardParam_Addr(Value: Integer); stdcall; external LedSender;
procedure LED_Cache_SetBoardParam_Width(Value: Integer); stdcall; external LedSender;
procedure LED_Cache_SetBoardParam_Height(Value: Integer); stdcall; external LedSender;
function LED_Cache_SetBoardParam(AParam: PSenderParam): Integer; stdcall; external LedSender;

function LED_DownLoadFontSet(AParam: PSenderParam; FileName: PChar; PacketSize: DWord = $ffffffff): Integer; stdcall; external LedSender;
function LED_UpdateFirmware(AParam: PSenderParam; FileName: PChar; PacketSize: DWord = $ffffffff): Integer; stdcall; external LedSender;

function LED_GetNotifyBufferSize(oSize: PDWord; Index: Integer): Integer; stdcall; external LedSender;
function LED_GetNotifyParam(ANotify: PNotifyParam; Index: Integer): Boolean; stdcall; external LEDSender;
function LED_GetNotifyParamEx(ANotify: PNotifyParamEx; Index: Integer): Integer; stdcall; external LEDSender;
function LED_GetStream(Index: Integer): Pointer; stdcall; external LEDSender;

//    同时用某一端口进行上报包监听和收发数据
function LED_Report_CreateServer_Multi(LocalPort: Integer): Integer; stdcall; external LEDSender;
function LED_GetOnline_ByReportName(AParam: PSenderParam; ServerIndex: Integer; Name: PChar): Integer; stdcall; external LEDSender;
function LED_SendToScreen_ByReportName(AParam: PSenderParam; ServerIndex: Integer; Name: PChar; Index: Integer): Integer; stdcall; external LEDSender;

//旋转处理  此函数请在MakeRoot前调用
//    RotateKey: 旋转方式 0不旋转 1旋转90度 2旋转180度 3旋转270度
//    MetrixCX:  屏宽度
//    MetrixCY:  屏高度
function SetRotate(RotateKey: Integer; MetrixCX, MetrixCY: Integer): Integer; stdcall; external LEDSender;

function VsqRelativeFiles(FileName: PChar): PChar; stdcall; external LEDSender;
function MakeFromVsqFile(FileName: PChar; RootType: Integer; ColorMode: Integer; Survive: Integer = ROOT_SURVIVE_ALWAYS): Integer; stdcall; external LEDSender;

function MakeRoot(RootType: Integer; ColorMode: Integer; Survive: Integer = ROOT_SURVIVE_ALWAYS): Integer; stdcall; external LEDSender;
function MakeChapter(RootType: Integer; ActionMode: Integer; ChapterIndex: Word; ColorMode: Integer;
    Time: DWord; Wait: Word): Integer; stdcall; external LEDSender;
function MakeChapterEx(RootType: Integer; ActionMode: Integer; ChapterIndex: Word; ColorMode: Integer;
    Time: DWord; Wait: Word; Kind: Word; Week: Word; FromTime: PTimeStamp; ToTime: PTimeStamp): Integer; stdcall; external LEDSender;
function MakeRegion(RootType: Integer; ActionMode: Integer; ChapterIndex, RegionIndex: Word; ColorMode: Integer; 
    X, Y, CX, CY: Integer; Border: Integer): Integer; stdcall; external LEDSender;
function MakeLeaf(RootType: Integer; ActionMode: Integer; ChapterIndex, RegionIndex, LeafIndex: Word; ColorMode: Integer;
    Time: DWord; Wait: Word): Integer; stdcall; external LEDSender;
function MakeObject(RootType: Integer; ActionMode: Integer; ChapterIndex, RegionIndex, LeafIndex, ObjectIndex: Word; ColorMode: Integer): Integer; stdcall; external LEDSender;
function MakeTextObject(ObjectIndex: Integer; Str: PChar; FontName: PChar; FontSize, FontColor, FontStyle: Integer; WordWrap: Integer; Alignment: Integer;
    inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;

function AddChapter(Num: Word; Time: DWord; Wait: Word): Integer; stdcall; external LEDSender;
//添加节目
//  num 节目数据缓冲区编号，是MakeRoot的返回值
//  time 播放的时间长度(单位为毫秒)
//  wait 等待模式，=WAIT_CHILD，表示当达到播放时间长度时，需要等待子节目播放完成再切换；
//                 =WAIT_USE_TIME，表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一节目
//  priority 优先级，如果同时有不同优先级的节目，那么只播放高优先级的节目
//  kind 播放计划类型，=0始终播放，=1按照一周每日时间播放，=2按照指定起止日期时间播放，=3不播放
//  week 一周有效日期，bit0到bit6表示周日到周六有效，当kind=1时，本参数起作用
//                     周日=$1，周一=$2，周二=$4，周三=$8，周四=$10，周五=$20，周六=$40
//                     此值可以相加，表示多天有效
//  fromtime 有效起始时间
//  totime 有效结束时间
function AddChapterEx(Num: Word; Time: DWord; Wait: Word; Priority: Word; Kind: Word; Week: Word; FromTime: PTimeStamp; ToTime: PTimeStamp): Integer; stdcall; external LEDSender;
function AddRegion(Num: Word; X, Y, CX, CY: Integer; Border: Integer): Integer; stdcall; external LEDSender;
function AddLeaf(Num: Word; Time: DWord; Wait: Word): Integer; stdcall;  external LEDSender;

function AddGBDateTime(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; FontSet, FontColor: Integer; YearOffset, MonthOffset, DayOffset: Integer; SecOffset: Integer; AFormat: PChar): Integer; stdcall; external LEDSender;
function AddDateTime(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; FontName: PChar; FontSize, FontColor, FontStyle: Integer; YearOffset, MonthOffset, DayOffset, TimeOffset: Integer; AFormat: PChar): Integer; stdcall; external LEDSender;
function AddCampaign(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; FontName: PChar; FontSize, FontColor, FontStyle: Integer; AFormat: PChar; ABaseTime, AFromTime, AToTime: PTimeStamp): Integer; stdcall; external LEDSender;
function AddCampaignEx(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; FontName: PChar; FontSize, FontColor, FontStyle: Integer; AFormat: PChar; ABaseTime, AFromTime, AToTime: PTimeStamp; AStep: Integer): Integer; stdcall; external LEDSender;
function AddCircleCounter(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Flag: Integer; FontName: PChar; FontSize, FontColor, FontStyle: Integer; AFormat: PChar; AFromTime, AToTime: PTimeStamp): Integer; stdcall; external LEDSender;
function AddCounter(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; AType: Integer; AFormat: Integer; FontName: PChar; FontSize, FontColor, FontStyle: Integer; BaseTime: PTimeStamp): Integer; stdcall; external LEDSender;
function AddClock(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; Offset: Integer;
    BkColor: DWord; FrameColor: DWord; FrameWidth: Integer; FrameShape: Integer;
    DotRadius: Integer; ADotWidth: Integer; ADotColor: DWord; BDotWidth: Integer; BDotColor: DWord;
    HourWidth: Integer; HourColor: DWord; MinuteWidth: Integer; MinuteColor: DWord; SecondWidth: Integer; SecondColor: DWord): Integer; stdcall; external LEDSender;
function AddClockEx(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; Offset: Integer;
    BkColor: DWord; FrameColor: DWord; FrameWidth: Integer; FrameShape: Integer;
    DotRadius: Integer;
    ADotWidth: Integer; ADotColor: DWord;
    BDotWidth: Integer; BDotColor: DWord;
    CDotVisible: DWord; CDotWidth: Integer; CDotColor: DWord;
    HourWidth: Integer; HourColor: DWord; MinuteWidth: Integer; MinuteColor: DWord; SecondWidth: Integer; SecondColor: DWord): Integer; stdcall; external LEDSender;

function AddMovie(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; FileName: PChar; Stretch: Integer): Integer; stdcall; external LEDSender;

//语音播放功能
// Str: 播放语音内容
// Interval: 语音循环多次播放时，两次播放之间的时间间隔(单位：秒)
// Times: 语音播放的次数
// Speeker: 语音声音类型（分男声、女声等）0-5
// Volumn: 音量 0-10
// Speed: 语速 0-10
// Tone: 语调 0-10
function AddVoice(Num: Word; Str: PChar; Interval: DWord; Times: DWord; Speaker: Integer; Volumn: Integer; Speed: Integer; Tone: Integer): Integer; stdcall; external LEDSender;

function AddTemperature(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; FontName: PChar; FontSize, FontColor, FontStyle: Integer): Integer; stdcall; external LEDSender;
function AddHumidity(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; FontName: PChar; FontSize, FontColor, FontStyle: Integer): Integer; stdcall; external LEDSender;
function AddImport(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; FontName: PChar; FontSize, FontColor, FontStyle: Integer; AIndex: Integer): Integer; stdcall; external LEDSender;
function AddImportEx(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; FontName: PChar; FontSize, FontColor, FontStyle: Integer; AFlicker: Integer; ASpeed: Integer; AMultiColor: Integer; AIndex: Integer): Integer; stdcall; external LEDSender;
function AddAsciiImport(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Flag: Integer; FontName: PChar; FontSize, FontColor, FontStyle: Integer; AFlicker: Integer; ASpeed: Integer; AMultiColor: Integer; AIndex: Integer): Integer; stdcall; external LEDSender;
function AddTabSheet(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; AIndex: Integer): Integer; stdcall; external LEDSender;
function AddTabSheetEx(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; AFlicker: Integer; ASpeed: Integer; AIndex: Integer): Integer; stdcall; external LEDSender;
function AddTextSheet(Num: Word; Str: PChar; FontName: PChar; FontSize, FontColor, FontStyle: Integer; WordWrap: Integer): Integer; stdcall; external LEDSender;
function AddWindowSheet(Num: Word;  dc: HDC; Width, Height: Integer): Integer; stdcall; external LEDSender;

function AddWindows(Num: Word; X, Y, CX, CY: Integer; ATransparent: Integer; Border: Integer): Integer; stdcall; external LEDSender;
function AddChildWindow(Num: Word; dc: HDC; Width, Height: Integer; Alignment: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddChildText(Num: Word; Str: PChar; FontName: PChar; FontSize, FontColor, FontStyle: Integer; WordWrap: Integer; Alignment: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddChildTextEx(Num: Word; Str: PChar; FontName: PChar; FontSize, FontColor, FontStyle: Integer; AutoFitSize: Integer; WordWrap: Integer; Vertical: Integer; Alignment: Integer; VerSpace: Integer; HorizontalFit: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddStrings(Num: Word; X, Y, CX, CY: Integer; ATransparent: Integer; Border: Integer): Integer; stdcall; external LEDSender;
function AddChildString(Num: Word; Str: PChar; Alignment: Integer; FontSet: Integer; Color: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddChildPicture(Num: Word; FileName: PChar; Alignment: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;

function AddWindow(Num: Word; X, Y, CX, CY: Integer; ATransparent: Integer; Border: Integer;
    dc: HDC; Width, Height: Integer; Alignment: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddText(Num: Word; X, Y, CX, CY: Integer; ATransparent: Integer; Border: Integer;
    Str: PChar; FontName: PChar; FontSize, FontColor, FontStyle: Integer; WordWrap: Integer;
    Alignment: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddTextEx(Num: Word; X, Y, CX, CY: Integer; ATransparent: Integer; Border: Integer;
    Str: PChar; FontName: PChar; FontSize, FontColor, FontStyle: Integer; BkColor: Integer; WordWrap: Integer;
    Alignment: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddTextEx2(Num: Word; X, Y, CX, CY: Integer; ATransparent: Integer; Border: Integer;
    Str: PChar; FontName: PChar; FontSize, FontColor, FontStyle: Integer; BkColor: Integer; WordWrap: Integer; Vertical: Integer;
    Alignment: Integer; VerSpace: Integer; HorizontalFit: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddTextEx3(Num: Word; X, Y, CX, CY: Integer; ATransparent: Integer; Border: Integer;
    Str: PChar; FontName: PChar; FontSize, FontColor, FontStyle: Integer; BkColor: Integer; AutoFitSize: Integer; WordWrap: Integer; Vertical: Integer;
    Alignment: Integer; VerSpace: Integer; HorFit: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddTextCenter(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer;
    Str: PChar; FontName: PChar; FontSize, FontColor, FontStyle: Integer; BkColor: Integer; WordWrap: Integer;
    VerticalSpace: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddRtf(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Flag: Integer;
    FileName: PChar; Alignment: Integer; WordWrap: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddString(Num: Word; X, Y, CX, CY: Integer; ATransparent: Integer; Border: Integer;
    Str: PChar; FontSet: Integer; Color: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddPicture(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Flag: Integer;
    FileName: PChar; Alignment: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddTable(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; AProfile: PChar;
    AContent: PChar; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddExcel(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Flag: Integer;
    FileName: PChar; Alignment: Integer; TextColor: Integer; BorderColor: Integer; SplitValue: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;
function AddTextMultiColor(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Flag: Integer;
    Str: PChar; FontName: PChar; FontSize, FontColor, FontStyle: Integer; BkColor: Integer; Vertical: Integer;
    Alignment: Integer; VerticalSpace: Integer; inMethod, inSpeed, outMethod, outSpeed, stopMethod, stopSpeed, stopTime: Integer): Integer; stdcall; external LEDSender;

function AddEffect(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer; EffectStyle: Integer;
    Str: PChar; FontName: PChar; FontSize, FontColor, FontStyle: Integer; Speed, frmTime, stopTime: DWord; changeColor: DWord): Integer; stdcall; external LEDSender;
function AddEffectFromDC(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer;
    EffectStyle: Integer; dc: HDC; Width: Integer; Height: Integer; Speed, frmTime, stopTime: DWord; changeColor: DWord): Integer; stdcall; external LEDSender;
function AddEffectFromPicFile(Num: Word; X, Y, CX, CY: Integer; Transparent: Integer; Border: Integer;
    EffectStyle: Integer; PicFile: PChar; Speed, frmTime, stopTime: DWord; changeColor: DWord): Integer; stdcall; external LEDSender;

// ====引入动作方式列表(数值从0开始)====
//    0 = '随机',
//    1 = '立即显示',
//    2 = '左滚显示',
//    3 = '上滚显示',
//    4 = '右滚显示',
//    5 = '下滚显示',
//    6 = '连续左滚显示',
//    7 = '连续上滚显示',
//    8 = '连续右滚显示',
//    9 = '连续下滚显示',
//   10 = '中间向上下展开',
//   11 = '中间向两边展开',
//   12 = '中间向四周展开',
//   13 = '从右向左移入',
//   14 = '从左向右移入',
//   15 = '从左向右展开',
//   16 = '从右向左展开',
//   17 = '从右上角移入',
//   18 = '从右下角移入',
//   19 = '从左上角移入',
//   20 = '从左下角移入',
//   21 = '从上向下移入',
//   22 = '从下向上移入',
//   23 = '横向百叶窗',
//   24 = '纵向百叶窗',
// =====================================

// ====引出动作方式列表(数值从0开始)====
//    0 = '随机',
//    1 = '不消失',
//    2 = '立即消失',
//    3 = '上下向中间合拢',
//    4 = '两边向中间合拢',
//    5 = '四周向中间合拢',
//    6 = '从左向右移出',
//    7 = '从右向左移出',
//    8 = '从右向左合拢',
//    9 = '从左向右合拢',
//   10 = '从右上角移出',
//   11 = '从右下角移出',
//   12 = '从左上角移出',
//   13 = '从左下角移出',
//   14 = '从下向上移出',
//   15 = '从上向下移出',
//   16 = '横向百叶窗',
//   17 = '纵向百叶窗'
// =====================================

// ====停留动作方式列表(数值从0开始)====
//    0 = '静态显示',
//    1 = '闪烁显示'
// =====================================

implementation

end.

