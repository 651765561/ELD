unit uMain;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, LEDAPI, ExtCtrls, WinSock, DateUtils;

const
  WM_LED_NOTIFY = WM_USER + 1;
  WM_MULTI_LED_NOTIFY = WM_USER + 2;
  WM_TIMER_LED_NOTIFY = WM_USER + 3;

type
  TfrmMain = class(TForm)
    cmbDeviceType: TComboBox;
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    Label1: TLabel;
    mComPort: TEdit;
    mComSpeed: TComboBox;
    Label2: TLabel;
    Label3: TLabel;
    mRemoteIP: TEdit;
    Label4: TLabel;
    mLocalPort: TEdit;
    GroupBox3: TGroupBox;
    btnPowerOn: TButton;
    btnPowerOff: TButton;
    btnGetPower: TButton;
    btnSetBright: TButton;
    btnGetBright: TButton;
    btnAdjustTime: TButton;
    btnText: TButton;
    btnDIB: TButton;
    btnString: TButton;
    btnPicFile: TButton;
    btnDateTime: TButton;
    btnClock: TButton;
    GroupBox4: TGroupBox;
    btnPowerOn2: TButton;
    btnPowerOff2: TButton;
    btnGetPower2: TButton;
    btnSetBright2: TButton;
    btnGetBright2: TButton;
    btnAdjustTime2: TButton;
    btnText2: TButton;
    btnDIB2: TButton;
    btnString2: TButton;
    btnPicFile2: TButton;
    btnDateTime2: TButton;
    btnClock2: TButton;
    Image1: TImage;
    GroupBox5: TGroupBox;
    btnChapter: TButton;
    btnRegion: TButton;
    btnLeaf: TButton;
    btnObject: TButton;
    btnMultiObject: TButton;
    btnComTransfer: TButton;
    cmbColorType: TComboBox;
    eAddress: TEdit;
    Label5: TLabel;
    tmrMain: TTimer;
    GroupBox6: TGroupBox;
    btnTestRun: TButton;
    btnTestStop: TButton;
    eTestInterval: TEdit;
    Label6: TLabel;
    Label7: TLabel;
    btnThreadTest: TButton;
    tmrTestThread: TTimer;
    infoTestThread: TLabel;
    btnMultiScreen: TButton;
    lstMultiScreenOutput: TListBox;
    btnPowerSchedule: TButton;
    btnBrightSchedule: TButton;
    btnBoardParam: TButton;
    btnObject2: TButton;
    btnRtf: TButton;
    btnExString: TButton;
    btnTransferAck: TButton;
    btnSendDirectly: TButton;
    GroupBox7: TGroupBox;
    Label8: TLabel;
    Label9: TLabel;
    mTXTimeo: TEdit;
    mTXRepeat: TEdit;
    Label10: TLabel;
    mPackSize: TEdit;
    eExString: TEdit;
    tmrExString: TTimer;
    btnCounter: TButton;
    eExStringIndex: TEdit;
    btnTable: TButton;
    btnAddVoice: TButton;
    btnPlayVoice: TButton;
    btnExcel: TButton;
    btnTextMultiColor: TButton;
    btnSetWitch: TButton;
    oExStringRed: TCheckBox;
    oExStringGreen: TCheckBox;
    oExStringBlue: TCheckBox;
    oExStringMethod: TComboBox;
    oExStringDirect: TCheckBox;
    oExStringSpeed: TComboBox;
    btnCreateServerMulti: TButton;
    btnSendByReportName: TButton;
    btnChapterSchedule: TButton;
    chbRootDownload: TCheckBox;
    btnGetSnapShot: TButton;
    imgSnapShot: TImage;
    GroupBox8: TGroupBox;
    oRotate: TComboBox;
    oRotateText: TButton;
    oRotateWidth: TEdit;
    oRotateHeight: TEdit;
    Label11: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure btnPowerOnClick(Sender: TObject);
    procedure btnPowerOffClick(Sender: TObject);
    procedure btnGetPowerClick(Sender: TObject);
    procedure btnSetBrightClick(Sender: TObject);
    procedure btnGetBrightClick(Sender: TObject);
    procedure btnAdjustTimeClick(Sender: TObject);
    procedure btnTextClick(Sender: TObject);
    procedure btnStringClick(Sender: TObject);
    procedure btnDIBClick(Sender: TObject);
    procedure btnPicFileClick(Sender: TObject);
    procedure btnDateTimeClick(Sender: TObject);
    procedure btnClockClick(Sender: TObject);
    procedure btnPowerOn2Click(Sender: TObject);
    procedure btnPowerOff2Click(Sender: TObject);
    procedure btnGetPower2Click(Sender: TObject);
    procedure btnSetBright2Click(Sender: TObject);
    procedure btnGetBright2Click(Sender: TObject);
    procedure btnAdjustTime2Click(Sender: TObject);
    procedure btnText2Click(Sender: TObject);
    procedure btnString2Click(Sender: TObject);
    procedure btnDIB2Click(Sender: TObject);
    procedure btnPicFile2Click(Sender: TObject);
    procedure btnDateTime2Click(Sender: TObject);
    procedure btnClock2Click(Sender: TObject);
    procedure btnChapterClick(Sender: TObject);
    procedure btnRegionClick(Sender: TObject);
    procedure btnLeafClick(Sender: TObject);
    procedure btnObjectClick(Sender: TObject);
    procedure btnMultiObjectClick(Sender: TObject);
    procedure btnComTransferClick(Sender: TObject);
    procedure btnTestRunClick(Sender: TObject);
    procedure btnTestStopClick(Sender: TObject);
    procedure tmrMainTimer(Sender: TObject);
    procedure btnThreadTestClick(Sender: TObject);
    procedure tmrTestThreadTimer(Sender: TObject);
    procedure btnMultiScreenClick(Sender: TObject);
    procedure btnPowerScheduleClick(Sender: TObject);
    procedure btnBrightScheduleClick(Sender: TObject);
    procedure btnBoardParamClick(Sender: TObject);
    procedure btnObject2Click(Sender: TObject);
    procedure btnRtfClick(Sender: TObject);
    procedure btnExStringClick(Sender: TObject);
    procedure btnTransferAckClick(Sender: TObject);
    procedure btnSendDirectlyClick(Sender: TObject);
    procedure tmrExStringTimer(Sender: TObject);
    procedure btnCounterClick(Sender: TObject);
    procedure btnTableClick(Sender: TObject);
    procedure btnAddVoiceClick(Sender: TObject);
    procedure btnPlayVoiceClick(Sender: TObject);
    procedure btnExcelClick(Sender: TObject);
    procedure btnTextMultiColorClick(Sender: TObject);
    procedure btnSetWitchClick(Sender: TObject);
    procedure btnCreateServerMultiClick(Sender: TObject);
    procedure btnSendByReportNameClick(Sender: TObject);
    procedure btnChapterScheduleClick(Sender: TObject);
    procedure btnGetSnapShotClick(Sender: TObject);
    procedure oRotateTextClick(Sender: TObject);
  private
    FMyFlag: Integer;
  private
    { Private declarations }
    FParam: TSenderParam;
    FSending: Integer;
    FTempVal: Integer;
    function GetRootMode: Integer;
    function GetColorType: Integer;
    procedure GetDeviceParam(var Param: TSenderParam);
    procedure Parse(K: Integer);
    function GetParse(K: Integer): string;
    procedure Parse2(K: Integer);
    procedure OnLEDNotify(var msg: TMessage); message WM_LED_NOTIFY;
    procedure OnMultiLEDNotify(var msg: TMessage); message WM_MULTI_LED_NOTIFY;
    procedure OnTimerLEDNotify(var msg: TMessage); message WM_TIMER_LED_NOTIFY;
  private
    procedure DisposeSnapShot(ABuffer: PByte; ASize: Integer);
  protected
    procedure MakeMultiChapter;
  public
    { Public declarations }
  end;

var
  frmMain: TfrmMain;

implementation

{$R *.dfm}

uses
  uTestThread;

procedure TfrmMain.FormCreate(Sender: TObject);
begin
	LED_Startup;
  LED_CloseDeviceOnTerminate(1);
  //LED_BuildGammaTable(0);
  TestThread_Initialize;
  FTempVal := 0;
end;

procedure TfrmMain.FormDestroy(Sender: TObject);
begin
  TestThread_Terminate;
  LED_Cleanup;
end;

function TfrmMain.GetColorType: Integer;
begin
  case cmbColorType.ItemIndex of
    1: Result := COLOR_MODE_THREE;
    2: Result := COLOR_MODE_FULLCOLOR;
  else
    Result := COLOR_MODE_DOUBLE;
  end;
end;

function TfrmMain.GetRootMode: Integer;
begin
  if chbRootDownload.Checked then Result := ROOT_DOWNLOAD else Result := ROOT_PLAY;
end;

procedure TfrmMain.GetDeviceParam(var Param: TSenderParam);
begin
  ZeroMemory(@Param, SizeOf(TSenderParam));
  case cmbDeviceType.ItemIndex of
    0:
    begin
      Param.devParam.devType := DEVICE_TYPE_COM;
      Param.devParam.comPort := StrToIntDef(mComPort.Text, 1);
      case mComSpeed.ItemIndex of
        0: Param.devParam.comSpeed := SBR_57600;
        1: Param.devParam.comSpeed := SBR_38400;
        2: Param.devParam.comSpeed := SBR_19200;
        3: Param.devParam.comSpeed := SBR_14400;
        4: Param.devParam.comSpeed := SBR_9600;
      else Param.devParam.comSpeed := SBR_57600;
      end;
      Param.devParam.dstAddr := StrToIntDef(eAddress.Text, 0);
    end;
    1:
    begin
      Param.devParam.devType := DEVICE_TYPE_UDP;
      Param.devParam.locPort := StrToIntDef(mLocalPort.Text, 9001);
      StrCopy(Param.devParam.rmtHost, PChar(mRemoteIP.Text));
      Param.devParam.rmtPort := 6666;
      Param.devParam.dstAddr := StrToIntDef(eAddress.Text, 0);
    end;
    2:
    begin
      Param.devParam.devType := DEVICE_TYPE_TCP;
      Param.devParam.locPort := StrToIntDef(mLocalPort.Text, 9001);
      StrCopy(Param.devParam.rmtHost, PChar(mRemoteIP.Text));
      Param.devParam.rmtPort := 6666;
      Param.devParam.dstAddr := StrToIntDef(eAddress.Text, 0);
    end;
  end;
  Param.devParam.txTimeo := StrToIntDef(mTXTimeo.Text, 1000);
  Param.devParam.txRepeat := StrToIntDef(mTXRepeat.Text, 3);
  Param.devParam.pkpLength := StrToIntDef(mPackSize.Text, 512);
end;

procedure TfrmMain.DisposeSnapShot(ABuffer: PByte; ASize: Integer);
var
  AWidth, AHeight: Integer;
  X, Y: Integer;
  ABitmap: TBitmap;
  ADest: PByte;
  ASrc: DWord;
begin
  AWidth := PInteger(ABuffer)^;
  AHeight := PInteger(DWord(ABuffer) + 4)^;
  ABitmap := TBitmap.Create;
  ABitmap.Width := AWidth;
  ABitmap.Height := AHeight;
  ABitmap.PixelFormat := pf24Bit;
  for Y := 0 to AHeight - 1 do
  begin
    for X := 0 to AWidth - 1 do
    begin
      ADest := ABitmap.ScanLine[Y];
      Inc(ADest, 3 * X);
      ASrc := PDWord(DWord(ABuffer) + DWord(8 + Y * AWidth * 4 + X * 4))^;
      //ASrc := $FFFF;
      ADest^ := ((ASrc shr 16) and $FF);
      Inc(ADest);
      ADest^ := ((ASrc shr 8) and $FF);
      Inc(ADest);
      ADest^ := (ASrc and $FF);
    end;
  end;
  imgSnapShot.Picture.Bitmap.Width := 64;
  imgSnapShot.Picture.Bitmap.Height := 128;
  BitBlt(imgSnapShot.Picture.Bitmap.Canvas.Handle, 0, 0, AWidth, AHeight, ABitmap.Canvas.Handle, 0, 0, SRCCOPY);
  imgSnapShot.Refresh;
  FreeAndNil(ABitmap);
end;

procedure TfrmMain.OnLEDNotify(var msg: TMessage);
var
  notifyparam: TNotifyParamEx;
  I: Integer;
  AStr: string;
  ASize: DWord;
begin
  LED_GetNotifyBufferSize(@ASize, msg.WParam);
  if ASize < NOTIFY_BUFFER_LEN then ASize := NOTIFY_BUFFER_LEN;
  GetMem(notifyparam.Buffer, ASize);
  LED_GetNotifyParamEx(@notifyparam, msg.WParam);
	//LED_GetNotifyParam(@notifyparam, msg.WParam);
  case notifyparam.Notify of
		LM_TIMEOUT:
    begin
      Caption := '���ͳ�ʱ';
    end;
		LM_TX_COMPLETE:
    begin
			if notifyparam.Result = RESULT_FLASH then Caption := '���ݴ�����ɣ�����д��Flash'
			else Caption := '���ݴ������';
    end;
		LM_RESPOND:
    begin
			case notifyparam.Command of
				PKC_GET_POWER:
					if notifyparam.Status = LED_POWER_ON then Caption := '��ȡ��Դ״̬��ɣ���ǰΪ��Դ����״̬'
					else Caption := '��ȡ��Դ״̬��ɣ���ǰΪ��Դ�ر�״̬';
				PKC_SET_POWER:
					if notifyparam.Result = 99 then Caption := '��ǰΪ��ʱ������ģʽ'
					else if notifyparam.Status = LED_POWER_ON then Caption := '���õ�Դ״̬��ɣ���ǰΪ��Դ����״̬'
					else Caption := '���õ�Դ״̬��ɣ���ǰΪ��Դ�ر�״̬';
				PKC_GET_BRIGHT:
					Caption := Format('��ȡ������ɣ���ǰ����=%d', [notifyparam.Status]);
				PKC_SET_BRIGHT:
					if notifyparam.Result = 99 then Caption := '��ǰΪ��ʱ���ȵ���ģʽ'
					else Caption := Format('����������ɣ���ǰ����=%d', [notifyparam.Status]);
				PKC_ADJUST_TIME: Caption := 'У����ʾ��ʱ�����';
        PKC_COM_TRANSFER:
        begin
          Caption := '����ת�����(��������ָ������)';
        end;
        PKC_MODEM_TRANSFER: Caption := '485��ת�����';
        PKC_SET_POWER_SCHEDULE: Caption := '���ö�ʱ�������ƻ����';
        PKC_SET_BRIGHT_SCHEDULE: Caption := '���ö�ʱ���ȵ��ڼƻ����';
        PKC_SET_EXSTRING: Caption := '�����ⲿ�ַ������';
        PKC_GET_TRANSFER_ACK:
        begin
          AStr := Format('��ȡ����ת��Ӧ����ɣ�Ӧ�����ݳ���%d', [notifyParam.Size]);
          if notifyParam.Size > 0 then AStr := AStr + '�����ݣ�';
          for I := 0 to notifyParam.Size - 1 do
          begin
            AStr := AStr + Format('%0.2x ', [PByte(Integer(notifyParam.Buffer)+I)^]);
          end;
          Caption := AStr;
        end;
      end;
    end;
		LM_NOTIFY:
    begin
      case notifyparam.Result of
        NOTIFY_GET_SNAPSHOT:
        begin
          Caption := '��ȡץ���������';
          DisposeSnapShot(notifyParam.Buffer, notifyParam.Size);
        end;
        NOTIFY_GET_PLAY_BUFFER:
        begin
          {
          with g_Project.BoardManager.UserBoards[g_Project.ItemIndex] do
          begin
            AFileName := ExtractFilePath(Application.ExeName) + 'InBoard.txt';
            BufferSaveToTxtFile(AFileName, ANotify.Buffer, ANotify.Size);
            AFileName := ExtractFilePath(Application.ExeName) + 'InBoard.dat';
            BufferSaveToFile(AFileName, ANotify.Buffer, ANotify.Size);
            DoPreview(Handle, Width, Height, AFileName, ColorType + 1, Inverse);
          end;
          }
        end;
      end;
    end;
  end;
end;

procedure TfrmMain.Parse(K: Integer);
begin
  case K of
		R_DEVICE_READY:	Caption := '����ִ��������߷�������...';
		R_DEVICE_INVALID: Caption := '��ͨѶ�豸ʧ��(���ڲ����ڡ����ߴ����ѱ�ռ�á���������˿ڱ�ռ��)';
		R_DEVICE_BUSY: Caption := '�豸æ������ͨѶ��...';
    R_NOT_IN_REPORTLIST: Caption := '��ʾ��������';
  end;
end;

function TfrmMain.GetParse(K: Integer): string;
begin
  case K of
		R_DEVICE_READY:	Result := '����ִ��������߷�������...';
		R_DEVICE_INVALID: Result := '��ͨѶ�豸ʧ��(���ڲ����ڡ����ߴ����ѱ�ռ�á���������˿ڱ�ռ��)';
		R_DEVICE_BUSY: Result := '�豸æ������ͨѶ��...';
  end;
end;

procedure TfrmMain.btnPowerOnClick(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
	Parse(LED_SetPower(@FParam, LED_POWER_ON));
end;

procedure TfrmMain.btnPowerOffClick(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
	Parse(LED_SetPower(@FParam, LED_POWER_OFF));
end;

procedure TfrmMain.btnGetPowerClick(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
	Parse(LED_GetPower(@FParam));
end;

var FSwitchValue: Integer = 1;
procedure TfrmMain.btnSetWitchClick(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
	Parse(LED_SetSwitch(@FParam, FSwitchValue));
  if FSwitchValue = 0 then FSwitchValue := 1 else FSwitchValue := 0;
end;

procedure TfrmMain.btnSetBrightClick(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
	Parse(LED_SetBright(@FParam, 5));
end;

procedure TfrmMain.btnGetBrightClick(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
	Parse(LED_GetBright(@FParam));
end;

procedure TfrmMain.btnAdjustTimeClick(Sender: TObject);
//var
//  T: TSystemTime;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
	Parse(LED_AdjustTime(@FParam));
	//////////////////////////////////////////////////////////////////////////
  // ���Ҫָ����ʾ����ʱ�䣬ʹ��LED_AdjustTimeEx
	//GetLocalTime(T);
	//Parse(LED_AdjustTimeEx(@FParam, @T));
	//////////////////////////////////////////////////////////////////////////
end;

procedure TfrmMain.btnPlayVoiceClick(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
	Parse(LED_PlayVoice(@FParam, '��ӭʹ���������Ź���', 0, 5, 5, 5));
end;

procedure TfrmMain.btnPowerScheduleClick(Sender: TObject);
var
  ASchedule: TPowerSchedule;
  I: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  //��ʾ���ö�ʱ������������ֵ0
  ZeroMemory(@ASchedule, Sizeof(TPowerSchedule));
  ASchedule.Enabled := $55AAAA55;
  //����һ������
  ASchedule.Mode := 0;
  for I := 0 to 20 do                       
  begin
    ASchedule.OpenTime[I] := DateTimeToTimeStamp(StrToDateTime('09:00:00'));
    ASchedule.CloseTime[I] := DateTimeToTimeStamp(StrToDateTime('19:30:00'));
  end;
  {
  //����ָ����ֹ����ʱ��
  ASchedule.Mode := 1;
  ASchedule.OpenTime[0] := DateTimeToTimeStamp(StrToDateTime('2013-01-01 18:30:00'));
  ASchedule.CloseTime[0] := DateTimeToTimeStamp(StrToDateTime('2013-01-01 21:00:00'));
  ASchedule.OpenTime[1] := DateTimeToTimeStamp(StrToDateTime('2013-01-02 18:30:00'));
  ASchedule.CloseTime[1] := DateTimeToTimeStamp(StrToDateTime('2013-01-02 21:00:00'));
  //......
  }
	Parse(LED_SetPowerSchedule(@FParam, @ASchedule));
end;

procedure TfrmMain.btnBrightScheduleClick(Sender: TObject);
var
  ASchedule: TBrightSchedule;
begin
	GetDeviceParam(FParam);
	//FParam.notifyMode := NOTIFY_BLOCK;//
  FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  //��ʾ���ö�ʱ���ȵ��ڣ�����ֵ0
  ZeroMemory(@ASchedule, Sizeof(TBrightSchedule));
  ASchedule.Enabled := $55AAAA55;
  ASchedule.Bright[0] := 0;
  ASchedule.Bright[1] := 1;
  ASchedule.Bright[2] := 2;
  ASchedule.Bright[3] := 3;
  ASchedule.Bright[4] := 4;
  ASchedule.Bright[5] := 5;
  ASchedule.Bright[6] := 6;
  ASchedule.Bright[7] := 7;
  ASchedule.Bright[8] := 6;
  ASchedule.Bright[9] := 5;
  ASchedule.Bright[10] := 4;
  ASchedule.Bright[11] := 3;
  ASchedule.Bright[12] := 2;
  ASchedule.Bright[13] := 1;
  ASchedule.Bright[14] := 0;
  ASchedule.Bright[15] := 1;
  ASchedule.Bright[16] := 2;
  ASchedule.Bright[17] := 3;
  ASchedule.Bright[18] := 4;
  ASchedule.Bright[19] := 5;
  ASchedule.Bright[20] := 6;
  ASchedule.Bright[21] := 7;
  ASchedule.Bright[22] := 6;
  ASchedule.Bright[23] := 5;

	Parse(LED_SetBrightSchedule(@FParam, @ASchedule));
end;

procedure TfrmMain.btnTextClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000, WAIT_CHILD);

  AddRegion(K, 0, 0, 64, 48, 0);
  AddLeaf(K, 1000, WAIT_CHILD);
  AddText(K, 0, 0, 64, 16, 1, 0, '�������', '����', 12, RGB(255,255,0), 0, 0, 0, 1, 5, 2, 5, 0, 5, 5000);
  AddText(K, 0, 16, 64, 16, 1, 0, '�������', '����', 12, RGB(255,255,0), 0, 0, 0, 1, 5, 2, 5, 0, 5, 5000);
  AddText(K, 0, 32, 64, 16, 1, 0, '�������', '����', 12, RGB(255,255,0), 0, 0, 0, 1, 5, 2, 5, 0, 5, 5000);
  //AddText(K, 0, 0, 64, 16, 1, 0, '�������'#13#10'1234', '����', 12, RGB(255,255,0), WFS_BOLD, 0, 0, 2, 5, 0, 5, 1, 5, 5000);
  //AddText(K, 0, 0, 64, 16, 1, 0, 'AAAAAAAA', '����', 12, RGB(255,255,0), WFS_BOLD, 0, 0, 2, 5, 0, 5, 1, 5, 5000);
  //AddText(K, 0, 16, 64, 16, 1, 0, 'BBBBBBBB', '����', 12, RGB(255,255,0), WFS_BOLD, 0, 0, 2, 5, 0, 5, 1, 5, 5000);
  //AddText(K, 0, 32, 64, 16, 1, 0, 'CCCCCCCC', '����', 12, RGB(255,255,0), WFS_BOLD, 0, 0, 2, 5, 0, 5, 1, 5, 5000);
  //AddText(K, 0, 48, 64, 16, 1, 0, 'DDDDDDDD', '����', 12, RGB(255,255,0), WFS_BOLD, 0, 0, 2, 5, 0, 5, 1, 5, 5000);

  //AddWindows(K, 0, 0, 128, 64, 1, 0);
  //AddChildText(K, 'Hello world!', '����', 12, 255, 0, 0, 0, 1, 6, 2, 6, 1, 6, 3000);
  //AddChildText(K, 'Hello world!', '����', 12, 255, 0, 0, 0, 1, 6, 2, 6, 0, 3, 10000);

  //ѹ�����ݣ�����ͨѶ������
  LED_Compress(K);

  //��һ�䣬���ڵ���ʱԤ����Ŀ��ʵ��Ӧ���У�Ӧ��ע�͵�
  //LED_Preview(K, 64, 48, PChar(ExtractFilePath(Application.ExeName) + 'Preview.dat'));

  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnStringClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddString(K, 0, 0, 64, 32, 1, 0, '�������', FONTSET_16P, RGB(255,255,0), 2, 5, 1, 5, 0, 500, 10000);
  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnDIBClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddWindow(K, 0, 0, 64, 32, 1, 0, Image1.Canvas.Handle, Image1.Width, Image1.Height, 0, 1, 0, 1, 0, 0, 0, 5000);
  LED_Compress(K);
  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnPicFileClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddPicture(K, 0, 0, 64, 32, 1, 0, PChar(ExtractFilePath(Application.ExeName) + 'Demo.bmp'), 0, 1, 0, 1, 0, 0, 0, 5000);
  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnDateTimeClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  //AddGBDateTime(K, 0, 0, 64, 32, 1, 0, $FFFF, 0, 0, 0, 0, '#y��#m��#d��');
  AddDateTime(K, 0, 0, 64, 32, 1, 0, '����', 12, RGB(255,0,0), 0, 0, 0, 0, 0, '#y��#m��#d�� #h:#n:#s ����#w ũ��#c');
  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnCounterClick(Sender: TObject);
var
  K: Integer;
  T: TDateTime;
  ATime: TTimeStamp;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);

  //Ŀ�굹��ʱ������2020��1��1��00:00:00����ʱ
  T := EncodeDateTime(2020, 1, 1, 0, 0, 0, 0);
  ATime := DateTimeToTimeStamp(T);
  AddCounter(K, 0, 0, 64, 16, 1, 0, CT_COUNTDOWN, CF_HNS, 'Times New Roman', 12, $ff, 0, @ATime);

  //��ͨ����ʱ����ָ����ʱ�俪ʼ���ƣ�ֱ��00:00:00Ϊֹ��ֻȡʱ�䲿��
  //    ��ʾЧ��  1:29:00/01:28:59/01:28:58/....../00:00:01/00:00:00
  T := EncodeDateTime(2014, 1, 1, 1, 29, 0, 0);
  ATime := DateTimeToTimeStamp(T);
  AddCounter(K, 0, 16, 64, 16, 1, 0, CT_COUNTDOWN_EX, CF_HNS, 'Times New Roman', 12, $ff, 0, @ATime);

  //��ʼʱ������ʱ������2014��7��20��00:00:00�Ѿ����˶���ʱ������ʱ
  T := EncodeDateTime(2014, 7, 20, 0, 0, 0, 0);
  ATime := DateTimeToTimeStamp(T);
  AddCounter(K, 0, 32, 64, 16, 1, 0, CT_COUNTUP, CF_HNS, 'Times New Roman', 12, $ff, 0, @ATime);

  //��ͨ����ʱ����00:00:00��ʼ����ʱ����ָ����ʱ��ֹͣ
  //    ��ʾЧ��  00: 00:00/00:00:01/....../01:28:58/01:28:59/1:29:00
  T := EncodeDateTime(2014, 1, 1, 1, 29, 0, 0);
  ATime := DateTimeToTimeStamp(T);
  AddCounter(K, 0, 48, 64, 16, 1, 0, CT_COUNTUP_EX, CF_HNS, 'Times New Roman', 12, $ff, 0, @ATime);

  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnAddVoiceClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000, WAIT_CHILD);

  AddRegion(K, 0, 0, 128, 64, 0);
  AddLeaf(K, 1000, WAIT_CHILD);

  AddWindows(K, 0, 0, 128, 64, 1, 0);
  AddChildText(K, '��ӭ����', '����', 12, 255, 0, 0, 0, 1, 6, 2, 6, 1, 6, 3000);

  AddVoice(K, '��ӭ����', 1, 5, 0, 5, 5, 5);

  //ѹ�����ݣ�����ͨѶ������
  LED_Compress(K);

  //��һ�䣬���ڵ���ʱԤ����Ŀ��ʵ��Ӧ���У�Ӧ��ע�͵�
  //LED_Preview(K, 128, 32, PChar(ExtractFilePath(Application.ExeName) + 'Preview.dat'));

  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnExcelClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000, WAIT_CHILD);

  AddRegion(K, 0, 0, 128, 64, 0);
  AddLeaf(K, 1000, WAIT_CHILD);
  AddExcel(K, 0, 0, 64, 64, 1, 0, PChar(ExtractFilePath(Application.ExeName) + 'Demo.xls'), 0, RGB(255,0,0), RGB(0,255,0), 192, 1, 5, 2, 5, 0, 5, 3000);
  AddLeaf(K, 1000, WAIT_CHILD);
  AddExcel(K, 0, 0, 64, 64, 1, 0, PChar(ExtractFilePath(Application.ExeName) + 'Demo2.xls'), 0, RGB(255,0,0), RGB(0,255,0), 192, 1, 5, 2, 5, 0, 5, 3000);

  //ѹ�����ݣ�����ͨѶ������
  LED_Compress(K);

  //��һ�䣬���ڵ���ʱԤ����Ŀ��ʵ��Ӧ���У�Ӧ��ע�͵�
  //LED_Preview(K, 128, 32, PChar(ExtractFilePath(Application.ExeName) + 'Preview.dat'));

  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnTextMultiColorClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000, WAIT_CHILD);

  AddRegion(K, 0, 0, 128, 64, 0);
  AddLeaf(K, 1000, WAIT_CHILD);
  AddTextMultiColor(K, 0, 0, 128, 64, 1, 0, '��<R>ӭ<G>��<Y>��'#13#10'л<R>л<G>��<Y>��', '����', 12, $FFFF, 0, 0, 0, 0, 0, 1, 6, 2, 6, 0, 0, 1000);

  //ѹ�����ݣ�����ͨѶ������
  //LED_Compress(K);

  //��һ�䣬���ڵ���ʱԤ����Ŀ��ʵ��Ӧ���У�Ӧ��ע�͵�
  LED_Preview(K, 128, 32, PChar(ExtractFilePath(Application.ExeName) + 'Preview.dat'));
  //Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnClockClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddClock(K, 0, 0, 64, 64, 1, 0, 0, RGB(0,0,0), RGB(255,255,0), 1, SHAPE_CIRCLE, 30,
      3, RGB(255,255,0), 2, RGB(0,255,0), 3, RGB(255,255,0), 2, RGB(0,255,0), 1, RGB(255,0,0));
  //TMemoryStream(LED_GetStream(K)).SaveToFile(ExtractFilePath(Application.ExeName) + 'a.dat');
  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnTableClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddTable(K, 0, 0, 128, 64, 1, 'Table.ini', 'aaa|bbb|ccc|ddd'#13#10'111|222|333|444'#13#10'AAA|BBB|CCC|DDD', 1, 6, 2, 6, 0, 0, 1000);
  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnMultiObjectClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  //���һ��ͼƬ
  AddPicture(K, 0, 0, 64, 32, 1, 0, PChar(ExtractFilePath(Application.ExeName) + 'Demo.bmp'), 0, 1, 0, 1, 0, 0, 0, 5000);
  //���һ����ҳ����
  AddWindows(K, 0, 32, 64, 32, 1, 0);
  AddChildText(K, 'Hello World!', '����', 12, RGB(255,255,0), 0, 1, 0, 0, 6, 0, 6, 0, 0, 1000);
  AddChildText(K, '��������...', '����', 12, RGB(255,255,0), 0, 1, 0, 0, 6, 0, 6, 0, 0, 1000);
  //...... �˴����Լ������������

  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnChapterScheduleClick(Sender: TObject);
var
  I, K: Integer;
  AFromTime: TTimeStamp;
  AToTime: TTimeStamp;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);

  for I := 0 to 23 do
  begin
    AFromTime := DateTimeToTimeStamp(EncodeTime(I, 0, 0, 0));
    AToTime := DateTimeToTimeStamp(EncodeTime(I, 59, 59, 0));
    AddChapterEx(K, 1000, WAIT_CHILD, 0, 1, $7F, @AFromTime, @AToTime);
    AddRegion(K, 0, 0, 128, 64, 0);
    AddLeaf(K, 1000, WAIT_CHILD);
    AddText(K, 0, 0, 128, 64, 1, 0, PChar(Format('%d��Ŀ%d', [I+1, I+1])), '����', 12, RGB(255,255,0), 0, 0, 0, 1, 5, 2, 5, 0, 5, 5000);
  end;

  {
  //��Ŀ1 ��һ�������죬ÿ��8:30��12:00����
  AFromTime := DateTimeToTimeStamp(EncodeTime(8, 30, 0, 0));
  AToTime := DateTimeToTimeStamp(EncodeTime(12, 0, 0, 0));
  AddChapterEx(K, 1000, WAIT_CHILD, 0, 1, $2+$4+$6+$8+$10, @AFromTime, @AToTime);
  AddRegion(K, 0, 0, 64, 48, 0);
  AddLeaf(K, 1000, WAIT_CHILD);
  AddText(K, 0, 32, 64, 16, 1, 0, '��������Ӫҵ', '����', 12, RGB(255,255,0), 0, 0, 0, 1, 5, 2, 5, 0, 5, 5000);

  //��Ŀ2 ��һ�������죬ÿ��13:00��17:30�㲥��
  AFromTime := DateTimeToTimeStamp(EncodeTime(13, 0, 0, 0));
  AToTime := DateTimeToTimeStamp(EncodeTime(17, 30, 0, 0));
  AddChapterEx(K, 1000, WAIT_CHILD, 0, 1, $2+$4+$6+$8+$10, @AFromTime, @AToTime);
  AddRegion(K, 0, 0, 64, 48, 0);
  AddLeaf(K, 1000, WAIT_CHILD);
  AddText(K, 0, 32, 64, 16, 1, 0, '��������Ӫҵ', '����', 12, RGB(255,255,0), 0, 0, 0, 1, 5, 2, 5, 0, 5, 5000);

  //��Ŀ3 �����գ�ÿ��8:30��17:30�㲥��
  AFromTime := DateTimeToTimeStamp(EncodeTime(8, 30, 0, 0));
  AToTime := DateTimeToTimeStamp(EncodeTime(17, 30, 0, 0));
  AddChapterEx(K, 1000, WAIT_CHILD, 0, 1, $1+$20, @AFromTime, @AToTime);
  AddRegion(K, 0, 0, 64, 48, 0);
  AddLeaf(K, 1000, WAIT_CHILD);
  AddText(K, 0, 32, 64, 16, 1, 0, 'ף����ĩ�������!', '����', 12, RGB(255,255,0), 0, 0, 0, 1, 5, 2, 5, 0, 5, 5000);
  }

  //ѹ�����ݣ�����ͨѶ������
  LED_Compress(K);

  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnComTransferClick(Sender: TObject);
var
  P: array[0..63] of Byte;
begin
  //�Ӵ���ת����"1234"
  //01 02 00 20 00 04 78 03
  P[0] := $01;
  P[1] := $02;
  P[2] := $00;
  P[3] := $20;
  P[4] := $00;
  P[5] := $04;
  P[6] := $78;
  P[7] := $03;
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
	Parse(LED_ModemTransfer(@FParam, @P[0], 8));
end;

procedure TfrmMain.btnTransferAckClick(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
	Parse(LED_GetTransferAck(@FParam));
end;

var
  FExStringRotate: Integer = 0;
procedure TfrmMain.btnExStringClick(Sender: TObject);
var
  AStr: string;
  AExStringRotate: Integer;
  ASpeed: Integer;
  AMethod: Integer;
  AColor: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
  AStr := eExString.Text;
  //if (FTempVal < 0) or (FTempVal > 1) then FTempVal := 0;

	//Parse(LED_SetVarString(@FParam, 0, PChar(AStr), 2, $FFFF, 2, 5, 2, 6, 0, 0, 0));
  case FExStringRotate of
    1: FExStringRotate := 5; 5: FExStringRotate := 1; else FExStringRotate := 1;
  end;

  if oExStringDirect.Checked then AExStringRotate := 5 else AExStringRotate := 1;
  ASpeed := oExStringSpeed.ItemIndex + 1;
  case oExStringMethod.ItemIndex of
    1: AMethod := 2;
    2: AMethod := 4;
  else AMethod := 1;
  end;
  AColor := 0;
  if oExStringRed.Checked then AColor := AColor + $FF;
  if oExStringGreen.Checked then AColor := AColor + $FF00;
  if oExStringBlue.Checked then AColor := AColor + $FF0000;
  Parse(LED_SetVarString2(@FParam, 0, PChar(AStr), AExStringRotate, 0, 2, AColor, AMethod, ASpeed, 2, 6, 0, 0, 0));
	//Parse(LED_SetVarString2(@FParam, 0, PChar(AStr), FExStringRotate, 0, 2, $FF00FF, 2, 5, 2, 6, 0, 0, 0));
  //Parse(LED_SetVarStringSingle(@FParam, StrToIntDef(eExStringIndex.Text, 0), PChar(AStr), $FFFF));

  //Inc(FTempVal);
  //if FTempVal >= 4 then FTempVal := 0;
  //tmrExString.Enabled := not tmrExString.Enabled;
end;

procedure TfrmMain.Parse2(K: Integer);
var
	notifyparam: TNotifyParam;
begin
	if K>=0 then
	begin
		LED_GetNotifyParam(@notifyparam, K);
		case notifyparam.Notify of
			LM_TIMEOUT: Caption := '���ͳ�ʱ';
			LM_TX_COMPLETE:
      begin
				if notifyparam.Result = RESULT_FLASH then Caption := '���ݴ�����ɣ�����д��Flash'
        else Caption := '���ݴ������';
      end;
			LM_RESPOND:
      begin
        if notifyparam.Result = RESULT_FLASH then
        begin
          Caption := Format('���ݷ�����ɣ�����д��Flash...', []);
        end else
        begin
          case notifyparam.Command of
            PKC_GET_POWER:
            begin
              if notifyparam.Status = LED_POWER_ON then Caption := '��ȡ��Դ״̬��ɣ���ǰΪ��Դ����״̬'
              else Caption := '��ȡ��Դ״̬��ɣ���ǰΪ��Դ�ر�״̬';
            end;
            PKC_SET_POWER:
            begin
              if notifyparam.Result = 99 then Caption := '��ǰΪ��ʱ������ģʽ'
              else if notifyparam.Status = LED_POWER_ON then Caption := '���õ�Դ״̬��ɣ���ǰΪ��Դ����״̬'
              else Caption := '���õ�Դ״̬��ɣ���ǰΪ��Դ�ر�״̬';
            end;
            PKC_GET_BRIGHT:
            begin
              Caption := Format('��ȡ������ɣ���ǰ����=%d', [notifyparam.Status]);
            end;
            PKC_SET_BRIGHT:
            begin
              if notifyparam.Result = 99 then Caption := '��ǰΪ��ʱ���ȵ���ģʽ'
              else Caption := Format('����������ɣ���ǰ����=%d', [notifyparam.Status]);
            end;
            PKC_ADJUST_TIME:
            begin
              Caption := 'У����ʾ��ʱ�����';
            end;
            PKC_SET_PARAM:
            begin
              Caption := Format('���ò������', []);
            end;
          end;
        end;
			end;
			LM_NOTIFY:
      begin
        case notifyparam.Result of
          NOTIFY_SET_PARAM:
          begin
            Caption := Format('���ò������', []);
          end;
        end;
      end;
    end;
  end else
  begin
		case K of
      R_DEVICE_INVALID: Caption := '��ͨѶ�豸ʧ��(���ڲ����ڡ����ߴ����ѱ�ռ�á���������˿ڱ�ռ��)';
			R_DEVICE_BUSY: Caption := '�豸æ������ͨѶ��...';
    end;
	end;
end;

procedure TfrmMain.btnPowerOn2Click(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;
  Caption := '����ִ��������߷�������...';
  Refresh;
	Parse2(LED_SetPower(@FParam, LED_POWER_ON));
end;

procedure TfrmMain.btnPowerOff2Click(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;
  Caption := '����ִ��������߷�������...';
  Refresh;
	Parse2(LED_SetPower(@FParam, LED_POWER_OFF));
end;

procedure TfrmMain.btnGetPower2Click(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;
  Caption := '����ִ��������߷�������...';
  Refresh;
	Parse2(LED_GetPower(@FParam));
end;

procedure TfrmMain.btnSetBright2Click(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;
  Caption := '����ִ��������߷�������...';
  Refresh;
	Parse2(LED_SetBright(@FParam, 5));
end;

procedure TfrmMain.btnGetBright2Click(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;
  Caption := '����ִ��������߷�������...';
  Refresh;
	Parse2(LED_GetBright(@FParam));
end;

procedure TfrmMain.btnAdjustTime2Click(Sender: TObject);
//var
//  T: TSystemTime;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;
  Caption := '����ִ��������߷�������...';
  Refresh;
	Parse2(LED_AdjustTime(@FParam));
	//////////////////////////////////////////////////////////////////////////
  // ���Ҫָ����ʾ����ʱ�䣬ʹ��LED_AdjustTimeEx
	//GetLocalTime(T);
	//Parse2(LED_AdjustTimeEx(@FParam, @T));
	//////////////////////////////////////////////////////////////////////////
end;

procedure TfrmMain.btnText2Click(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddText(K, 0, 0, 64, 32, 1, 0, '�������AAAA', '����', 24, RGB(255,0,0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 5000);
  Caption := '����ִ��������߷�������...';
  Refresh;
  LED_Compress(K);
  Parse2(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnString2Click(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddString(K, 0, 0, 64, 32, 1, 0, '�������', FONTSET_16P, RGB(0,255,0), 1, 0, 1, 0, 0, 0, 5000);
  Caption := '����ִ��������߷�������...';
  Refresh;
  Parse2(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnDIB2Click(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddWindow(K, 0, 0, 64, 32, 1, 0, Image1.Canvas.Handle, Image1.Width, Image1.Height, 0, 1, 0, 1, 0, 0, 0, 5000);
  Caption := '����ִ��������߷�������...';
  Refresh;
  LED_Compress(K);
  Parse2(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnPicFile2Click(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddPicture(K, 0, 0, 64, 32, 1, 0, PChar(ExtractFilePath(Application.ExeName) + 'Demo.bmp'), 0, 1, 0, 1, 0, 0, 0, 5000);
  Caption := '����ִ��������߷�������...';
  Refresh;
  Parse2(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnDateTime2Click(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddDateTime(K, 0, 0, 64, 32, 1, 0, '����', 12, RGB(255,0,0), 0, 0, 0, 0, 0, '#y��#m��#d�� #h:#n:#s ����#w ũ��#c');
  Caption := '����ִ��������߷�������...';
  Refresh;
  Parse2(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnClock2Click(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 32, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddClock(K, 0, 0, 64, 64, 1, 0, RGB(0,0,0), RGB(255,255,0), 0, 1, SHAPE_CIRCLE, 30,
      3, RGB(255,255,0), 2, RGB(0,255,0), 3, RGB(255,255,0), 2, RGB(0,255,0), 1, RGB(255,0,0));
  Caption := '����ִ��������߷�������...';
  Refresh;
  Parse2(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnSendDirectlyClick(Sender: TObject);
var
  ABuffer: array[0..255] of Byte;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_NONE;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;
  //���緢����ʾ"123456"
  ABuffer[0] := $55;
  ABuffer[1] := $21;
  ABuffer[2] := $31;
  ABuffer[3] := $32;
  ABuffer[4] := $33;
  ABuffer[5] := $34;
  ABuffer[6] := $35;
  ABuffer[7] := $36;
  ABuffer[8] := $2A;
  ABuffer[9] := $AA;
  LED_SendBufferDirectly(@FParam, @ABuffer[0], 10);
end;

procedure TfrmMain.btnChapterClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  //��������У�ChapterIndex=0��ֻ���¿��ƿ��ڵ�1����Ŀ
  //���ChapterIndex=1��ֻ���¿��ƿ��ڵ�2����Ŀ
  //�Դ�����
  K := MakeChapter(ROOT_PLAY_CHAPTER, ACTMODE_REPLACE, 0, GetColorType, 5000, WAIT_CHILD);
  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 5000, WAIT_CHILD);
  if FMyFlag = 0 then
  begin
    AddText(K, 0, 0, 64, 16, 1, 0, '�������', '����', 12, RGB(255,0,0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 5000);
    FMyFlag := 1;
  end else
  begin
    AddText(K, 0, 0, 64, 16, 1, 0, '��ӭ����', '����', 12, RGB(255,0,0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 5000);
    FMyFlag := 0;
  end;
  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnRegionClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  //��������У�ChapterIndex=0��RegionIndex=0��ֻ���¿��ƿ��ڵ�1����Ŀ�еĵ�1������
  //���ChapterIndex=1��RegionIndex=2��ֻ���¿��ƿ��ڵ�2����Ŀ�еĵ�3������
  //�Դ�����
  K := MakeRegion(ROOT_PLAY_REGION, ACTMODE_REPLACE, 0, 0, GetColorType, 0, 0, 64, 64, 0);
  AddLeaf(K, 5000, WAIT_CHILD);
  if FMyFlag = 0 then
  begin
    AddText(K, 0, 0, 64, 16, 1, 0, '�������', '����', 12, RGB(255,0,0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 5000);
    FMyFlag := 1;
  end else
  begin
    AddText(K, 0, 0, 64, 16, 1, 0, '��ӭ����', '����', 12, RGB(255,0,0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 5000);
    FMyFlag := 0;
  end;
  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnLeafClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  //��������У�ChapterIndex=0��RegionIndex=0��LeafIndex=0��ֻ���¿��ƿ��ڵ�1����Ŀ�еĵ�1�������еĵ�1��ҳ��
  //���ChapterIndex=1��RegionIndex=2��LeafIndex=1��ֻ���¿��ƿ��ڵ�2����Ŀ�еĵ�3�������еĵ�2��ҳ��
  //�Դ�����
  K := MakeLeaf(ROOT_PLAY_LEAF, ACTMODE_REPLACE, 0, 0, 0, GetColorType, 1000, WAIT_USER_TIME);
  if FMyFlag = 0 then
  begin
    AddText(K, 0, 0, 64, 16, 1, 0, '�������', '����', 12, RGB(255,0,0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 5000);
    FMyFlag := 1;
  end else
  begin
    AddText(K, 0, 0, 64, 16, 1, 0, '��ӭ����', '����', 12, RGB(255,0,0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 5000);
    FMyFlag := 0;
  end;
  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnObjectClick(Sender: TObject);
var
  K: Integer;
  ABitmap: TBitmap;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  //��������У�ChapterIndex=0��RegionIndex=0��LeafIndex=0��ObjectIndex=0 ֻ���¿��ƿ��ڵ�1����Ŀ�еĵ�1�������еĵ�1��ҳ��ĵ�1������
  //���ChapterIndex=1��RegionIndex=2��LeafIndex=1��ObjectIndex=2ֻ���¿��ƿ��ڵ�2����Ŀ�еĵ�3�������еĵ�2��ҳ��ĵ�3������
  //�Դ�����
  K := MakeObject(ROOT_PLAY_OBJECT, ACTMODE_REPLACE, 0, 0, 0, 1, GetColorType);
  if FMyFlag = 0 then
  begin
    //AddText(K, 0, 0, 64, 16, 1, 0, '�������', '����', 12, RGB(255,0,0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 5000);
    AddTextEx3(K, 64, 32, 256, 32, 1, 0, '��ʾ������...��ʾ������...'#13#10'0123456789ABCDEFGHIJKLMN', '����', 24, RGB(255,255,0), WFS_BOLD, 0, 0, 0, 0, 0, 12, 0, 1, 5, 1, 5, 0, 0, 5000);
    FMyFlag := 1;
  end else
  begin
    //AddText(K, 0, 0, 64, 16, 1, 0, '��ӭ����', '����', 12, RGB(255,0,0), WFS_BOLD, 0, 0, 1, 0, 1, 0, 0, 0, 5000);
    //{
    //��λ���ͼƬ
    ABitmap := TBitmap.Create;
    ABitmap.Width := 256;
    ABitmap.Height := 32;
    ABitmap.Canvas.Brush.Color := 0;
    ABitmap.Canvas.FillRect(Rect(0,0,ABitmap.Width,ABitmap.Height));
    ABitmap.Canvas.Font.Name := '����';
    ABitmap.Canvas.Font.Size := 24;
    ABitmap.Canvas.Font.Color := RGB(255,0,0);
    ABitmap.Canvas.TextOut(0, 0, '1234');
    ABitmap.Canvas.Font.Color := RGB(0,255,0);
    ABitmap.Canvas.TextOut(128, 0, '5678');
    AddWindow(K, 0, 0, 256, 32, 1, 0, ABitmap.Canvas.Handle, 256, 32, 0, 1, 0, 1, 0, 0, 0, 5000);
    FreeAndNil(ABitmap);
    //}
    FMyFlag := 0;
  end;
  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnObject2Click(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  //��������У�ChapterIndex=0��RegionIndex=0��LeafIndex=0��ObjectIndex=0 ֻ���¿��ƿ��ڵ�1����Ŀ�еĵ�1�������еĵ�1��ҳ��ĵ�1������
  //���ChapterIndex=1��RegionIndex=2��LeafIndex=1��ObjectIndex=2ֻ���¿��ƿ��ڵ�2����Ŀ�еĵ�3�������еĵ�2��ҳ��ĵ�3������
  //�Դ�����
  if FMyFlag = 0 then
  begin
    K := MakeTextObject(1, 'лл�ݹ�', '����', 12, RGB(255,0,0), WFS_BOLD, 0, 0, 1, 5, 1, 5, 0, 0, 5000);
    FMyFlag := 1;
  end else
  begin
    K := MakeTextObject(1, '��ӭ����', '����', 12, RGB(0,255,0), WFS_BOLD, 0, 0, 1, 5, 1, 5, 0, 0, 5000);
    FMyFlag := 0;
  end;
  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnTestRunClick(Sender: TObject);
var
  K: Integer;
begin
  K := StrToIntDef(eTestInterval.Text, 1000);
  if K < 100 then K := 100;
  tmrMain.Interval := K;
  tmrMain.Enabled := True;
  FSending := 0;
end;

procedure TfrmMain.btnTestStopClick(Sender: TObject);
begin
  tmrMain.Enabled := False;
end;

procedure TfrmMain.OnTimerLEDNotify(var msg: TMessage);
var
  notifyparam: TNotifyParam;
begin
	LED_GetNotifyParam(@notifyparam, msg.WParam);
  case notifyparam.Notify of
		LM_TIMEOUT:
    begin
      Caption := '���ͳ�ʱ';
      FSending := 0;
    end;
		LM_TX_COMPLETE:
    begin
      Caption := '�������';
      FSending := 0;
    end;
  end;
end;

procedure TfrmMain.tmrMainTimer(Sender: TObject);
var
  K: Integer;
begin
  {
  if FSending = 0 then
  begin
    GetDeviceParam(FParam);
    FParam.notifyMode := NOTIFY_EVENT;
    FParam.wmHandle := Handle;
    FParam.wmMessage := WM_TIMER_LED_NOTIFY;

    K := MakeRoot(GetRootMode, GetColorType);
    AddChapter(K, 1000000, WAIT_CHILD);

    AddRegion(K, 0, 0, 64, 64, 0);
    AddLeaf(K, 10000, WAIT_CHILD);
    AddText(K, 0, 0, 64, 64, 1, 0, PChar(FormatDateTime('��������������������������������������������������������������������������������������������������������������������������������������������'#13#10'nn:ss.zzz', Now)), '����', 12, RGB(255,255,0), 0, 0, 0, 1, 5, 0, 5, 0, 5, 5000);

    //LED_Compress(K);
    K := LED_SendToScreen(@FParam, K);
    Parse(K);
    if K = R_DEVICE_READY then FSending := 1;
  end;
  }
  if FSending = 0 then
  begin
    GetDeviceParam(FParam);
    FParam.notifyMode := NOTIFY_EVENT;
    FParam.wmHandle := Handle;
    FParam.wmMessage := WM_TIMER_LED_NOTIFY;

    K := MakeRoot(GetRootMode, GetColorType);
    AddChapter(K, 1000, WAIT_CHILD);

    AddRegion(K, 0, 0, 128, 64, 0);
    AddLeaf(K, 1000, WAIT_CHILD);
    AddExcel(K, 0, 0, 128, 64, 1, 0, PChar(ExtractFilePath(Application.ExeName) + 'Demo.xls'), 0, RGB(255,0,0), RGB(0,255,0), 192, 0, 5, 2, 5, 0, 5, 3000);
    AddLeaf(K, 1000, WAIT_CHILD);
    AddExcel(K, 0, 0, 128, 64, 1, 0, PChar(ExtractFilePath(Application.ExeName) + 'Demo2.xls'), 0, RGB(255,0,0), RGB(0,255,0), 192, 0, 5, 2, 5, 0, 5, 3000);

    //ѹ�����ݣ�����ͨѶ������
    LED_Compress(K);

    K := LED_SendToScreen(@FParam, K);
    Parse(K);
    if K = R_DEVICE_READY then FSending := 1;
  end;
end;

procedure TfrmMain.MakeMultiChapter;
var
  I, K: Integer;
  ABitmap: TBitmap;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;

  ABitmap := TBitmap.Create;
  ABitmap.Width := 320;
  ABitmap.Height := 160;
  ABitmap.Canvas.Brush.Color := 0;
  ABitmap.Canvas.Font.Assign(Font);
  ABitmap.Canvas.Font.Color := RGB(255,255,0);
  ABitmap.Canvas.Font.Size := 12;
  ABitmap.Canvas.Font.Style := [fsBold];

  K := MakeRoot(GetRootMode, GetColorType);
  for I := 0 to 149 do
  begin
    AddChapter(K, 1000000, WAIT_CHILD);
    AddRegion(K, 0, 0, 64, 64, 0);
    AddLeaf(K, 10000, WAIT_CHILD);

    ABitmap.Canvas.FillRect(Rect(0,0,ABitmap.Width,ABitmap.Height));
    ABitmap.Canvas.TextOut(0, 0, IntToStr(I+1));

    AddWindow(K, 0, 0, 64, 64, 1, 0, ABitmap.Canvas.Handle, ABitmap.Width, ABitmap.Height, 0, 1, 6, 1, 6, 0, 0, 5000);
  end;

  FreeAndNil(ABitmap);

  Caption := '����ִ��������߷�������...';
  Refresh;
  LED_Compress(K);
  Parse2(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.btnThreadTestClick(Sender: TObject);
var
  I: Integer;
begin
  for I := 0 to TEST_THREAD_COUNT - 1 do
  begin
   	GetDeviceParam(SenderParam[I]);
    SenderParam[I].notifyMode := NOTIFY_BLOCK;
    //StrCopy(@SenderParam[I].devParam.rmtHost, PChar(Format('192.168.1.%d', [99+I])));
    StrCopy(@SenderParam[I].devParam.rmtHost, '127.0.0.1');
    SenderParam[I].devParam.rmtPort := 6666+I;
    SenderParam[I].devParam.locPort := 10001 + I;
    SenderParam[I].devParam.txTimeo := 32;
    SenderParam[I].devParam.txRepeat := 2;
  end;
  TestThread_Terminate;
  TestThread_Start(GetColorType);
  tmrTestThread.Enabled := True;
end;

procedure TfrmMain.tmrTestThreadTimer(Sender: TObject);
var
  I: Integer;
  AStr: string;
begin
  AStr := '';
  for I := 0 to TEST_THREAD_COUNT - 1 do
  begin
    AStr := Format('%s  Thread%d=%d:%d', [AStr, I, TestThread_GetCounter(I), TestThread_GetMakeIndex(I)]);
    if (I + 1) mod 4 = 0 then AStr := AStr + #13#10;
  end;
  infoTestThread.Caption := AStr;
end;

procedure TfrmMain.OnMultiLEDNotify(var msg: TMessage);
var
  notifyparam: TNotifyParam;
begin
	LED_GetNotifyParam(@notifyparam, msg.WParam);
  case notifyparam.Notify of
		LM_TIMEOUT:
    begin
      lstMultiScreenOutput.Items.Strings[msg.LParam] := Format('��ʾ��%d: ���ͳ�ʱ', [msg.LParam + 1]);
    end;
		LM_TX_COMPLETE:
    begin
      lstMultiScreenOutput.Items.Strings[msg.LParam] := Format('��ʾ��%d: �������', [msg.LParam + 1]);
    end;
  end;
end;

procedure TfrmMain.btnMultiScreenClick(Sender: TObject);
const
  SCREEN_COUNT = 3;
var
  I, K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_MULTI_LED_NOTIFY;


  lstMultiScreenOutput.Items.Clear;
  for I := 0 to SCREEN_COUNT - 1 do
  begin
    lstMultiScreenOutput.Items.Add('');
    K := MakeRoot(GetRootMode, GetColorType);
    AddChapter(K, 1000000, WAIT_CHILD);

    AddRegion(K, 0, 0, 64, 64, 0);
    AddLeaf(K, 10000, WAIT_CHILD);
    //AddText(K, 0, 0, 64, 16, 1, 0, '�������'#13#10'1234', '����', 12, RGB(255,255,0), WFS_BOLD, 0, 0, 2, 5, 0, 5, 1, 5, 5000);
    AddText(K, 0, 0, 64, 16, 1, 0, 'AAAAAAAA', '����', 12, RGB(255,255,0), WFS_BOLD, 0, 0, 2, 5, 0, 5, 1, 5, 5000);
    AddText(K, 0, 16, 64, 16, 1, 0, 'BBBBBBBB', '����', 12, RGB(255,255,0), WFS_BOLD, 0, 0, 2, 5, 0, 5, 1, 5, 5000);
    AddText(K, 0, 32, 64, 16, 1, 0, 'CCCCCCCC', '����', 12, RGB(255,255,0), WFS_BOLD, 0, 0, 2, 5, 0, 5, 1, 5, 5000);
    AddText(K, 0, 48, 64, 16, 1, 0, 'DDDDDDDD', '����', 12, RGB(255,255,0), WFS_BOLD, 0, 0, 2, 5, 0, 5, 1, 5, 5000);

    LED_Compress(K);
    Inc(FParam.devParam.locPort);
    StrCopy(FParam.devParam.rmtHost, PChar(Format('192.168.0.%d', [99+I])));
    FParam.wmLParam := I;
    FParam.devParam.txTimeo := 500;
    FParam.devParam.txRepeat := 2 + I;
    lstMultiScreenOutput.Items.Strings[I] := Format('��ʾ��%d: %s', [I + 1, GetParse(LED_SendToScreen(@FParam, K))]);
  end;
end;

function IsBroadCast(AHost: PChar): Boolean;
begin
  Result := ((inet_addr(AHost) and $ff000000)=$ff000000);
end;

procedure TfrmMain.btnBoardParamClick(Sender: TObject);
var
  paramIP, paramMac: string;
  paramAddr, paramWidth, paramHeight, paramColorType: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_BLOCK;
	FParam.wmHandle := 0;
	FParam.wmMessage := 0;
  Caption := '����ִ��������߷�������...';
  Refresh;

  if LED_Cache_GetBoardParam(@FParam) >= 0 then
  begin
    paramIP := LED_Cache_GetBoardParam_IP;
    paramMac := LED_Cache_GetBoardParam_Mac;
    paramAddr := LED_Cache_GetBoardParam_Addr;
    paramWidth := LED_Cache_GetBoardParam_Width;
    paramHeight := LED_Cache_GetBoardParam_Height;
    paramColorType := LED_Cache_GetBoardParam_ColorType;
    MessageBox(0,
        PChar(Format('Addr=%d'#13#10'IP=%s'#13#10'MAC=%s'#13#10'Width=%d'#13#10'Height=%d'#13#10'ColorType=%d',
        [paramAddr, paramIP, paramMac, paramWidth, paramHeight, paramColorType])),
        '��ȡ�������',
        MB_OK);
    LED_Cache_SetBoardParam_Addr(0);
    LED_Cache_SetBoardParam_IP('192.168.1.99');
    LED_Cache_SetBoardParam_Mac('00-BB-CC-DD-EE-FF');
    LED_Cache_SetBoardParam_Width(paramWidth);
    LED_Cache_SetBoardParam_Height(paramHeight);
    LED_Cache_SetBoardParam_ColorType(paramColorType); //1Ϊ��ɫ��2Ϊ˫ɫ
    Parse2(LED_Cache_SetBoardParam(@FParam));
  end else
  begin
    Caption := Format('��ȡ����ʧ��', []);
  end;
end;

procedure TfrmMain.btnRtfClick(Sender: TObject);
var
  K: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  K := MakeRoot(GetRootMode, GetColorType);
  AddChapter(K, 1000000, WAIT_CHILD);

  AddRegion(K, 0, 0, 64, 64, 0);
  AddLeaf(K, 10000, WAIT_CHILD);
  AddRtf(K, 0, 0, 64, 32, 1, 0, 'Demo.rtf', 0, 0, 3, 5, 0, 5, 1, 5, 0);

  LED_Compress(K);

  //��һ�䣬���ڵ���ʱԤ����Ŀ��ʵ��Ӧ���У�Ӧ��ע�͵�
  //LED_Preview(K, 128, 32, PChar(ExtractFilePath(Application.ExeName) + 'Preview.dat'));

  Parse(LED_SendToScreen(@FParam, K));
end;

procedure TfrmMain.tmrExStringTimer(Sender: TObject);
var
  AStr: string;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
  case tmrExString.Tag of
    0: AStr := eExString.Text;
    1: AStr := FormatDateTime('hh:nn:ss', Now);
  else AStr := '��ʾ������';
  end;
	Parse(LED_SetVarString(@FParam, 0, PChar(AStr), 0, $FF, 1, 6, 2, 6, 0, 0, 0));
  tmrExString.Tag := tmrExString.Tag + 1;
  if tmrExString.Tag >= 3 then tmrExString.Tag := 0;
end;

var
  FReportServerIndex: Integer = -1;

procedure TfrmMain.btnCreateServerMultiClick(Sender: TObject);
begin
  FReportServerIndex := LED_Report_CreateServer_Multi(StrToIntDef(mLocalPort.Text, 8899));
end;

procedure TfrmMain.btnSendByReportNameClick(Sender: TObject);
var
  K: Integer;
begin
  if FReportServerIndex >= 0 then
  begin
    GetDeviceParam(FParam);
    FParam.notifyMode := NOTIFY_MULTI;
    FParam.wmHandle := Handle;
    FParam.wmMessage := WM_LED_NOTIFY;

    K := MakeRoot(GetRootMode, GetColorType);
    AddChapter(K, 1000, WAIT_CHILD);
    AddRegion(K, 0, 0, 64, 48, 0);
    AddLeaf(K, 1000, WAIT_CHILD);
    AddText(K, 0, 0, 64, 16, 1, 0, '�������', '����', 12, RGB(255,255,0), 0, 0, 0, 1, 5, 2, 5, 0, 5, 5000);

    //ѹ�����ݣ�����ͨѶ������
    LED_Compress(K);

    Parse(LED_SendToScreen_ByReportName(@FParam, FReportServerIndex, 'LED1', K));
  end;
end;

procedure TfrmMain.btnGetSnapShotClick(Sender: TObject);
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;
	Parse(LED_GetSnapShot(@FParam));
end;

procedure TfrmMain.oRotateTextClick(Sender: TObject);
var
  K: Integer;
  CX, CY: Integer;
begin
	GetDeviceParam(FParam);
	FParam.notifyMode := NOTIFY_EVENT;
	FParam.wmHandle := Handle;
	FParam.wmMessage := WM_LED_NOTIFY;

  CX := StrToIntDef(oRotateWidth.Text, 64);
  CY := StrToIntDef(oRotateHeight.Text, 256);

  //�������ת��������������շ��͵�������
  case oRotate.ItemIndex of
    0: //��ת90��
    begin
      SetRotate(1, StrToIntDef(oRotateWidth.Text, 64), StrToIntDef(oRotateHeight.Text, 256));
      K := MakeRoot(GetRootMode, GetColorType);
      AddChapter(K, 1000, WAIT_CHILD);
      AddRegion(K, 0, 0, 64, 448, 0);
      AddLeaf(K, 1000, WAIT_CHILD);
      AddTextCenter(K, 0, 0, CX, CY, 1, '��'#13#10'��'#13#10'��'#13#10'��', '����', 24, RGB(255,255,0), 0, 0, 1, 0, 1, 5, 2, 5, 0, 5, 5000);
      LED_Compress(K);
      Parse(LED_SendToScreen(@FParam, K));
    end;
    1: //��ת270��
    begin
      SetRotate(2, StrToIntDef(oRotateWidth.Text, 64), StrToIntDef(oRotateHeight.Text, 256));
      K := MakeRoot(GetRootMode, GetColorType);
      AddChapter(K, 1000, WAIT_CHILD);
      AddRegion(K, 0, 0, 64, 448, 0);
      AddLeaf(K, 1000, WAIT_CHILD);
      AddTextCenter(K, 0, 0, CX, CY, 1, '��'#13#10'��'#13#10'��'#13#10'��', '����', 24, RGB(255,255,0), 0, 0, 1, 0, 1, 5, 2, 5, 0, 5, 5000);
      LED_Compress(K);
      Parse(LED_SendToScreen(@FParam, K));
    end;
    2: //��ת180��
    begin
      SetRotate(3, CX, CY);
      K := MakeRoot(GetRootMode, GetColorType);
      AddChapter(K, 1000, WAIT_CHILD);
      AddRegion(K, 0, 0, 64, 448, 0);
      AddLeaf(K, 1000, WAIT_CHILD);
      AddText(K, 0, 0, CX, CY, 1, 0, '�������', '����', 12, RGB(255,255,0), 0, 0, 0, 1, 5, 2, 5, 0, 5, 5000);
      LED_Compress(K);
      Parse(LED_SendToScreen(@FParam, K));
    end;
  end;
end;

end.
