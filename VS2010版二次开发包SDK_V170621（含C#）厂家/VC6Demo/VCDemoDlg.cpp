// VCDemoDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VCDemo.h"
#include "VCDemoDlg.h"
#include "winsock.h"
#include "LEDAPI.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define WM_LED_NOTIFY WM_USER+1

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CVCDemoDlg dialog

CVCDemoDlg::CVCDemoDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CVCDemoDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CVCDemoDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CVCDemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CVCDemoDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CVCDemoDlg, CDialog)
	//{{AFX_MSG_MAP(CVCDemoDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_POWERON, OnBtnPoweron)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BTN_POWEROFF, OnBtnPoweroff)
	ON_BN_CLICKED(IDC_BTN_ADJUSTTIME, OnBtnAdjusttime)
	ON_BN_CLICKED(IDC_BTN_SETBRIGHT, OnBtnSetbright)
	ON_BN_CLICKED(IDC_BTN_GETPOWER, OnBtnGetpower)
	ON_BN_CLICKED(IDC_BTN_GETBRIGHT, OnBtnGetbright)
	ON_BN_CLICKED(IDC_BTN_TEXT, OnBtnText)
	ON_BN_CLICKED(IDC_BTN_DIB, OnBtnDib)
	ON_BN_CLICKED(IDC_BTN_STRING, OnBtnString)
	ON_BN_CLICKED(IDC_BTN_DCLOCK, OnBtnDclock)
	ON_MESSAGE(WM_LED_NOTIFY, OnLEDNotify)
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_BTN_PIC_FILE, OnBtnPicFile)
	ON_BN_CLICKED(IDC_BTN_TIMER, OnBtnTimer)
	ON_BN_CLICKED(IDC_BTN_THREAD, OnBtnThread)
	ON_BN_CLICKED(IDC_BTN_ACLOCK, OnBtnAclock)
	ON_BN_CLICKED(IDC_BTN_POWERON2, OnBtnPoweron2)
	ON_BN_CLICKED(IDC_BTN_POWEROFF2, OnBtnPoweroff2)
	ON_BN_CLICKED(IDC_BTN_GETPOWER2, OnBtnGetpower2)
	ON_BN_CLICKED(IDC_BTN_GETBRIGHT2, OnBtnGetbright2)
	ON_BN_CLICKED(IDC_BTN_SETBRIGHT2, OnBtnSetbright2)
	ON_BN_CLICKED(IDC_BTN_ADJUSTTIME2, OnBtnAdjusttime2)
	ON_BN_CLICKED(IDC_BTN_TEXT2, OnBtnText2)
	ON_BN_CLICKED(IDC_BTN_DIB2, OnBtnDib2)
	ON_BN_CLICKED(IDC_BTN_STRING2, OnBtnString2)
	ON_BN_CLICKED(IDC_BTN_PIC_FILE2, OnBtnPicFile2)
	ON_BN_CLICKED(IDC_BTN_DCLOCK2, OnBtnDclock2)
	ON_BN_CLICKED(IDC_BTN_ACLOCK2, OnBtnAclock2)
	ON_BN_CLICKED(IDC_BTN_VSQ, OnBtnVsq)
	ON_BN_CLICKED(IDC_BTN_CHAPTER_BACK, OnBtnChapterBack)
	ON_BN_CLICKED(IDC_BTN_CHAPTER_NEXT, OnBtnChapterNext)
	ON_BN_CLICKED(IDC_BTN_CHAPTER, OnBtnChapter)
	ON_BN_CLICKED(IDC_BTN_REGION, OnBtnRegion)
	ON_BN_CLICKED(IDC_BTN_LEAF, OnBtnLeaf)
	ON_BN_CLICKED(IDC_BTN_OBJECT, OnBtnObject)
	ON_BN_CLICKED(IDC_BTN_RESETDISPLAY, OnBtnResetdisplay)
	ON_BN_CLICKED(IDC_BTN_POWERON3, OnBtnPoweron3)
	ON_BN_CLICKED(IDC_BTN_ONLINE, OnBtnOnline)
	ON_BN_CLICKED(IDC_BTN_ONLINE_START, OnBtnOnlineStart)
	ON_BN_CLICKED(IDC_BTN_ONLINE_STOP, OnBtnOnlineStop)
	ON_BN_CLICKED(IDC_BTN_CAMPAIGN, OnBtnCampaign)
	ON_BN_CLICKED(IDC_BTN_BOARD_PARAM, OnBtnBoardParam)
	ON_BN_CLICKED(IDC_BTN_COM_TRANSFER, OnBtnComTransfer)
	ON_BN_CLICKED(IDC_BTN_POWERSCHEDULE, OnBtnPowerschedule)
	ON_BN_CLICKED(IDC_BTN_PREVIEW, OnBtnPreview)
	ON_BN_CLICKED(IDC_BTN_MULTI, OnBtnMulti)
	ON_BN_CLICKED(IDC_BTN_GET_CUR_CHAPTER, OnBtnGetCurChapter)
	ON_BN_CLICKED(IDC_BTN_TABLE, OnBtnTable)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CVCDemoDlg message handlers

long my_flag = 0;
long my_index = 0;

void SystemTimeToTimeStamp(LPSYSTEMTIME itime, PTimeStamp otime)
{
  static DWORD MonthDays[2][12]={{31,28,31,30,31,30,31,31,30,31,30,31},{31,29,31,30,31,30,31,31,30,31,30,31}};
  long  i,y,m,d;

  y=itime->wYear-1;
  for (m=0,d=itime->wYear; d>100; d-=100, m++) ;

  if (((itime->wYear & 3)==0) && ((m & 3)==0 || (d!=0))) d=1;
  else d=0;
  
  otime->date=itime->wDay;
  for (i=1; i<=itime->wMonth-1; i++) otime->date+=MonthDays[d][i-1];
  otime->date+=y*365+(y>>2)-(y/100)+(y/400);
  
  otime->time=itime->wHour*60*60000+itime->wMinute*60000+itime->wSecond*1000+itime->wMilliseconds;
}

BOOL CVCDemoDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	LED_Initialize();

	((CComboBox*)GetDlgItem(IDC_COMBO_DEVICE_TYPE))->SetCurSel(1);
	((CComboBox*)GetDlgItem(IDC_COMBO_COLOR_TYPE))->SetCurSel(0);
	GetDlgItem(IDC_EDIT_DSTADDR)->SetWindowText("0");

	GetDlgItem(IDC_EDIT_COM_PORT)->SetWindowText("1");
	((CComboBox*)GetDlgItem(IDC_COMBO_COM_SPEED))->SetCurSel(0);
	
	GetDlgItem(IDC_EDIT_REMOTE_IP)->SetWindowText("192.168.2.99");
	GetDlgItem(IDC_EDIT_LOCAL_PORT)->SetWindowText("8889");

	m_VsqFile=0;

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CVCDemoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CVCDemoDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CVCDemoDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CVCDemoDlg::OnDestroy() 
{
	CDialog::OnDestroy();
	
	// TODO: Add your message handler code here
	LED_Destroy();
}

void CVCDemoDlg::GetDeviceParam(LPVOID param)
{
	PDeviceParam p=(PDeviceParam)param;
	int I;
	CString S;
	I=1;
	GetDlgItem(IDC_EDIT_DSTADDR)->GetWindowText(S);
	sscanf(S.GetBuffer(0), "%d", &I);
    p->dstAddr=I;
	if (((CComboBox*)GetDlgItem(IDC_COMBO_DEVICE_TYPE))->GetCurSel()==0)
	{
		p->devType = DEVICE_TYPE_COM;
		I=1;
		GetDlgItem(IDC_EDIT_COM_PORT)->GetWindowText(S);
		sscanf(S.GetBuffer(0), "%d", &I);
		p->comPort = I;
		p->comSpeed=((CComboBox*)GetDlgItem(IDC_COMBO_COM_SPEED))->GetCurSel();
        p->pkpLength=DEFAULT_PKP_LENGTH;
	}
	else
	{
		p->devType = DEVICE_TYPE_UDP;
		I=8889;
		GetDlgItem(IDC_EDIT_LOCAL_PORT)->GetWindowText(S);
		sscanf(S.GetBuffer(0), "%d", &I);
		p->locPort = I;
		p->rmtPort = 6666;
		GetDlgItem(IDC_EDIT_REMOTE_IP)->GetWindowText(S);
		strcpy(p->rmtHost, S.GetBuffer(0));
        p->pkpLength=DEFAULT_PKP_LENGTH;
	}
}

long CVCDemoDlg::GetColorType()
{
	switch(((CComboBox*)GetDlgItem(IDC_COMBO_COLOR_TYPE))->GetCurSel()){
		case 1: return COLOR_MODE_THREE;
		case 2: return COLOR_MODE_FULLCOLOR;
		default: return COLOR_MODE_DOUBLE;
	}
}

long chapterid=0;

void CVCDemoDlg::OnLEDNotify(WPARAM wParam, LPARAM lParam) 
{
	// TODO: Add your control notification handler code here
	TNotifyParam notifyparam;
	CString str;
	LED_GetNotifyParam(&notifyparam, wParam);
	switch(notifyparam.Notify){
		case LM_TIMEOUT:
			SetWindowText("发送超时");
			break;
		case LM_TX_COMPLETE:
			if (notifyparam.Result==RESULT_FLASH)
			{
				SetWindowText("数据传送完成，正在写入Flash");
			}
			else
			{
				SetWindowText("数据传送完成");
			}
			break;
		case LM_RESPOND:
			switch(notifyparam.Command){
			    case PKC_COM_TRANSFER:
					SetWindowText("串口转发数据完成");
					break;
				case PKC_GET_POWER:
					if (notifyparam.Status==LED_POWER_ON) SetWindowText("读取电源状态完成，当前为电源开启状态");
					else SetWindowText("读取电源状态完成，当前为电源关闭状态");
					break;
				case PKC_SET_POWER:
					if (notifyparam.Result==99) SetWindowText("当前为定时开关屏模式");
					else if (notifyparam.Status==LED_POWER_ON) SetWindowText("设置电源状态完成，当前为电源开启状态");
					else SetWindowText("设置电源状态完成，当前为电源关闭状态");
					break;
				case PKC_GET_BRIGHT:
					str.Format("读取亮度完成，当前亮度=%d", notifyparam.Status);
					SetWindowText(str.GetBuffer(0));
					break;
				case PKC_SET_BRIGHT:
					if (notifyparam.Result==99) SetWindowText("当前为定时亮度调节模式");
					else
					{
						str.Format("设置亮度完成，当前亮度=%d", notifyparam.Status);
						SetWindowText(str.GetBuffer(0));
					}
					break;
				case PKC_ADJUST_TIME:
					SetWindowText("校正显示屏时间完成");
					break;
				case PKC_SET_CURRENT_CHAPTER:
					chapterid=notifyparam.Status;
					break;
				case PKC_GET_CURRENT_CHAPTER:
					str.Format("读取当前节目编号完成，当前编号=%d", notifyparam.Status);
					SetWindowText(str.GetBuffer(0));
					break;
				case PKC_SET_POWER_SCHEDULE:
					str.Format("设置定时开关屏完成");
					SetWindowText(str.GetBuffer(0));
					break;
			}
			break;
		case LM_NOTIFY:
			switch(notifyparam.Result){
				case NOTIFY_ROOT_DOWNLOAD:
					str.Format("节目下载写入Flash完成");
					SetWindowText(str.GetBuffer(0));
					break;
			}
			break;
	}
}

void CVCDemoDlg::OnBtnPoweron() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	Parse(LED_SetPower(&param, LED_POWER_ON));
}

void CVCDemoDlg::OnBtnPoweroff() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	Parse(LED_SetPower(&param, LED_POWER_OFF));
}

void CVCDemoDlg::OnBtnGetpower() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	Parse(LED_GetPower(&param));
}

void CVCDemoDlg::OnBtnAdjusttime() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	Parse(LED_AdjustTime(&param));
	//////////////////////////////////////////////////////////////////////////
    // 如果要指定显示屏的时间，使用LED_AdjustTimeEx
	//SYSTEMTIME time;
	//GetLocalTime(&time);
	//LED_AdjustTimeEx(&param, &time);
	//////////////////////////////////////////////////////////////////////////
}

void CVCDemoDlg::OnBtnPowerschedule() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	TPowerSchedule schedule;
	SYSTEMTIME T;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	ZeroMemory(&schedule, sizeof(TPowerSchedule));
	schedule.Enabled=0x55AAAA55;  //启用定时开关屏功能，=0禁用
	schedule.Mode=0;  //按照一周七天模式  
	//注意，在此模式下，只取时间，日期（年月日）会被忽略掉，可以随意填写。
	//下面例子为每日8点开屏，17点关屏
	T.wYear=2012;
	T.wMonth=5;
	T.wDay=2;
	T.wHour=8;
	T.wMinute=0;
	T.wSecond=0;
	T.wMilliseconds=0;
	SystemTimeToTimeStamp(&T, &schedule.OpenTime[0]);	//周日
	SystemTimeToTimeStamp(&T, &schedule.OpenTime[3]);   //周一
	SystemTimeToTimeStamp(&T, &schedule.OpenTime[6]);   //周二
	SystemTimeToTimeStamp(&T, &schedule.OpenTime[9]);   //周三
	SystemTimeToTimeStamp(&T, &schedule.OpenTime[12]);	//周四
	SystemTimeToTimeStamp(&T, &schedule.OpenTime[15]);	//周五
	SystemTimeToTimeStamp(&T, &schedule.OpenTime[18]);	//周六
	T.wYear=2012;
	T.wMonth=5;
	T.wDay=2;
	T.wHour=17;
	T.wMinute=0;
	T.wSecond=0;
	T.wMilliseconds=0;
	SystemTimeToTimeStamp(&T, &schedule.CloseTime[0]);	//周日
	SystemTimeToTimeStamp(&T, &schedule.CloseTime[3]);	//周一
	SystemTimeToTimeStamp(&T, &schedule.CloseTime[6]);	//周二
	SystemTimeToTimeStamp(&T, &schedule.CloseTime[9]);	//周三
	SystemTimeToTimeStamp(&T, &schedule.CloseTime[12]);	//周四
	SystemTimeToTimeStamp(&T, &schedule.CloseTime[15]);	//周五
	SystemTimeToTimeStamp(&T, &schedule.CloseTime[18]);	//周六

	Parse(LED_SetPowerSchedule(&param, &schedule));
}

void CVCDemoDlg::OnBtnSetbright() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	Parse(LED_SetBright(&param, 5));
}

void CVCDemoDlg::OnBtnGetbright()
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	Parse(LED_GetBright(&param));
}

void CVCDemoDlg::OnBtnMulti() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());

	AddChapterEx2(K, 3000000, WAIT_CHILD, 0, 1, 0x7F, "2014-8-1 00:00:00", "2014-8-1 23:59:59");
	AddRegion(K, 0, 0, 64, 32, 0);
	AddLeaf(K, 10000, WAIT_CHILD);
	AddWindows(K, 0, 0, 64, 32, 1, 0);
	AddChildText(K, "Hello world!", "宋体", 12, RGB(255,255,0), 0, 0, 0, 0, 6, 0, 6, 0, 0, 0);
	AddChildPicture(K, "C:\\Demo.bmp", 0, 0, 6, 0, 6, 0, 0, 0);

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnText() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());

	/*
	AddChapter(K, 3000000, WAIT_CHILD);

	AddRegion(K, 0, 0, 64, 16, 0);

	//第1页面
	AddLeaf(K, 10000, WAIT_CHILD);
	//自动换行的文字
    if (my_flag)
    {
	    AddText(K, 0, 0, 32, 16, V_TRUE, 0, "同一个世界同一个世界同一个世界同一个世界", "宋体", 12, RGB(255,255,0), WFS_NONE, V_TRUE, 0, 7, 5, 1, 5, 0, 1, 3000);
        my_flag=0;
    }
    else
    {
	    AddText(K, 0, 0, 32, 16, V_TRUE, 0, "同一个梦想同一个梦想同一个梦想同一个梦想", "宋体", 12, RGB(255,255,0), WFS_NONE, V_TRUE, 0, 7, 5, 1, 5, 0, 1, 3000);
        my_flag=1;
    }
	//AddText(K, 0, 0, 64, 16, V_TRUE, 0, "Hello world! HELLO WORLD!", "宋体", 12, RGB(0,255,0), WFS_NONE, V_TRUE, 0, 0, 0, 1, 1, 1, 0, 1, 3);
	//非自动换行的文字
	//AddText(K, 0, 16, 64, 32, V_TRUE, 0, "Hello world! Hello world! Hello World!", "宋体", 12, RGB(255,0,0), WFS_NONE, V_FALSE, 0, 2, 1, 1, 1, 1, 1, 3);

	//第2页面
	//AddLeaf(K, 10000, WAIT_CHILD);
	//非自动换行的文字
	//AddText(K, 0, 0, 64, 16, V_TRUE, 0, "Hello world!", "宋体", 12, RGB(255,255,0), WFS_NONE, V_TRUE, 0, 0, 0, 1, 1, 1, 1, 1, 5);
	*/

	//////////////////////////////////////////////////////////////////////////////////////
	// 2分区节目
	AddChapter(K, 3000000, WAIT_CHILD);
	AddRegion(K, 0, 0, 64, 16, 0);
	AddLeaf(K, 10000, WAIT_CHILD);
    AddText(K, 0, 0, 32, 16, V_TRUE, 0, "同一个世界同一个世界同一个世界同一个世界", "宋体", 12, RGB(255,255,0), WFS_NONE, V_TRUE, 0, 7, 5, 1, 5, 0, 1, 3000);
	AddRegion(K, 32, 0, 32, 16, 0);
	AddLeaf(K, 10000, WAIT_CHILD);
    AddTextEx2(K, 0, 0, 32, 16, V_TRUE, 0, "明月几时有，把酒问青天，不知天上宫阙，今夕是何年。我欲乘风归去，唯恐琼楼玉宇，高处不胜寒。起舞弄清影，何似在人间。转朱阁，低绮户，照无眠。不应有恨，何事长向别时圆。人有悲欢离合，月有阴晴圆缺，此事古难全。但愿人长久，千里共婵娟。", 
		"宋体", 12, RGB(0,255,0), WFS_NONE, 0, V_TRUE, 0, 0, 4, 0, 7, 5, 1, 5, 0, 1, 3000);

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnDib() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;
	HDC dc;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);
	AddLeaf(K, 10000, WAIT_CHILD);
	dc = ::GetDC(NULL);
	AddWindow(K, 0, 0, 128, 16, V_TRUE, 0, dc, 128, 64, 0, 1, 1, 1, 1, 1, 1, 1000);
	::ReleaseDC(NULL, dc);

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnString() 
{
	// TODO: Add your control notification handler code here
//////////////////////////////////////////////////////////////////////////
//  注意，要使用内码文字，控制卡必须先下载字库，
//  否则发送完会没有显示内容
//////////////////////////////////////////////////////////////////////////

	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 64, 32, 0);

	//第1页面
	AddLeaf(K, 10000, WAIT_CHILD);
	//16点阵字体
	AddString(K, 0, 0, 64, 16, V_TRUE, 0, "Hello world! Hello world! Hello World!", FONT_SET_16, RGB(255,0,0), 0, 1, 1, 1, 0, 1, 1000);

	//第2页面
	AddLeaf(K, 10000, WAIT_CHILD);
	//24点阵字体
	AddString(K, 0, 0, 64, 32, V_TRUE, 0, "Hello world! Hello world! Hello World!", FONT_SET_24, RGB(255,0,0), 3, 1, 1, 1, 1, 1, 1000);

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnDclock() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);

	//第1页面
	AddLeaf(K, 5000, WAIT_CHILD);
	AddDateTime(K, 0, 0, 64, 16, V_TRUE, 0, "Times New Roman", 12, RGB(255,0,0), WFS_NONE, 0, 0, 0, 0, "#y-#m-#d");
	AddDateTime(K, 0, 16, 64, 32, V_TRUE, 0, "Times New Roman", 12, RGB(0,255,0), WFS_NONE, 0, 0, 0, 0, "#h:#n:#s");

	//第2页面
	AddLeaf(K, 5000, WAIT_CHILD);
	AddDateTime(K, 0, 0, 64, 16, V_TRUE, 0, "Times New Roman", 12, RGB(255,0,0), WFS_NONE, 0, 0, 0, 0, "星期#w");
	AddDateTime(K, 0, 16, 64, 32, V_TRUE, 0, "Times New Roman", 12, RGB(0,255,0), WFS_NONE, 0, 0, 0, 0, "#c");

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnTable() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);

	//第1页面
	AddLeaf(K, 5000, WAIT_CHILD);
	AddTable(K, 0, 0, 128, 64, V_TRUE, "Table.ini", "aaa|bbb|ccc\r\n111|222|333\r\nAAA|BBB|CCC", 0, 6, 2, 6, 0, 1, 1000);

	Parse(LED_SendToScreen(&param, K));
}

BYTE HexToByte(char c)
{
	if (c>='0' && c<='9')
	{
		return (BYTE)c-0x30;
	}
	else if (c>='A' && c<='F')
	{
		return (BYTE)(c-'A')+10;
	}
	else if (c>='a' && c<='f')
	{
		return (BYTE)(c-'a')+10;
	}
	else
	{
		return 0;
	}
}

void CVCDemoDlg::OnBtnComTransfer() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	BYTE buffer[16];
	CString str;
	int i, k, m;
	char c;

	memset(buffer, 0, 16);
	GetDlgItemText(IDC_EDIT_COMTRANSFER, str);
	str.TrimLeft();
	str.TrimRight();
	k=0;
	m=0;
	for (i=0; i<str.GetLength() && k<16; i++)
	{
	  c=str.GetAt(i);
	  if (c==' ')
	  {
		k++;
		m=0;
	  }
	  else
	  {
		if (m==0)
		{
          buffer[k]=buffer[k]+(HexToByte(c)<<4);
		  m++;
		}
		else
		{
          buffer[k]=buffer[k]+HexToByte(c);
		}
	  }
	}
	k++;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	Parse(LED_ComTransfer(&param, buffer, k));
}

void CVCDemoDlg::OnBtnCampaign() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;
	SYSTEMTIME T;
	TTimeStamp basetime, fromtime, totime;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);

	//第1页面
	AddLeaf(K, 5000, WAIT_CHILD);
	AddDateTime(K, 0, 0, 256, 16, V_TRUE, 0, "Times New Roman", 12, RGB(255,0,0), WFS_NONE, 0, 0, 0, 0, "#y-#m-#d");

	//作战时间 2020-06-01 07:00:00
	T.wYear=2020;
	T.wMonth=6;
	T.wDay=1;
	T.wHour=7;
	T.wMinute=0;
	T.wSecond=0;
	T.wMilliseconds=0;
	SystemTimeToTimeStamp(&T, &basetime);
	//开始时间 2012-05-02 09:00:00
	T.wYear=2012;
	T.wMonth=5;
	T.wDay=2;
	T.wHour=9;
	T.wMinute=0;
	T.wSecond=0;
	T.wMilliseconds=0;
	SystemTimeToTimeStamp(&T, &fromtime);
	//结束时间 2012-05-02 10:00:00
	T.wYear=2012;
	T.wMonth=5;
	T.wDay=2;
	T.wHour=10;
	T.wMinute=0;
	T.wSecond=0;
	T.wMilliseconds=0;
	SystemTimeToTimeStamp(&T, &totime);
	AddCampaignEx(K, 0, 16, 256, 16, V_TRUE, 0, "Times New Roman", 12, RGB(0,255,0), WFS_NONE, "#h:#m:#s", &basetime, &fromtime, &totime, 100);

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnAclock() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);

	//第1页面
	AddLeaf(K, 5000, WAIT_CHILD);
	AddClock(K, 0, 0, 64, 64, V_TRUE, 0, 0, RGB(0,0,0), RGB(255,255,0), 1, SHAPE_ROUNDRECT, 30, 3, RGB(0,255,0), 2, RGB(255,255,0), 
		3, RGB(255,255,0), 2, RGB(0,255,0), 1, RGB(255,0,0));

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnPicFile() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);
	AddLeaf(K, 10000, WAIT_CHILD);
	AddPicture(K, 0, 0, 128, 16, V_TRUE, 0, "C:\\Demo.bmp", 0, 2, 1, 1, 1, 1, 0, 1000);

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnVsq() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	if (m_VsqFile) 
	{
		K = MakeFromVsqFile("D:\\MyWorks\\ACard2008\\MyPlayer\\board1_2.vsq", ROOT_PLAY, GetColorType());
		//K = MakeFromVsqFile("D:\\MyWorks\\VS2009\\test1.vsq", ROOT_PLAY, GetColorType());
		m_VsqFile=0;
	}
	else
	{
		K = MakeFromVsqFile("D:\\MyWorks\\ACard2008\\MyPlayer\\test2.vsq", ROOT_PLAY, GetColorType());
		//K = MakeFromVsqFile("D:\\MyWorks\\VS2009\\test1.vsq", ROOT_PLAY, GetColorType());
		m_VsqFile=1;
	}

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnGetCurChapter() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	LED_GetCurChapter(&param);
}

void CVCDemoDlg::OnBtnChapterBack() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	if (chapterid>0) chapterid--;
	LED_SetCurChapter(&param, chapterid);
}

void CVCDemoDlg::OnBtnChapterNext() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	chapterid++;
	LED_SetCurChapter(&param, chapterid);
}

void CVCDemoDlg::OnBtnResetdisplay() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	LED_ResetDisplay(&param);
}

void CVCDemoDlg::Parse(long K)
{
	switch(K){
		case R_DEVICE_READY:
			SetWindowText("正在执行命令或者发送数据...");
			break;
		case R_DEVICE_INVALID:
			SetWindowText("打开通讯设备失败(串口不存在、或者串口已被占用、或者网络端口被占用)");
			break;
		case R_DEVICE_BUSY:
			SetWindowText("设备忙，正在通讯中...");
			break;
	}
}

//线程函数，线程里调用的发送过程都采用阻塞方式
UINT Thread_Proc(LPVOID thread_param)
{
	HWND hWnd=*((HWND*)thread_param);
	TSenderParam param;
	int K, R;
	TNotifyParam notifyparam;
	CString str;

	memset(&param, 0, sizeof(TSenderParam));
	param.devParam.devType=DEVICE_TYPE_UDP;
	param.devParam.locPort=9001;
	strcpy(param.devParam.rmtHost, "192.168.2.99");
	param.devParam.rmtPort=6666;

	param.notifyMode = NOTIFY_BLOCK;
	//param.wmHandle = (long)hWnd;
	//param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, COLOR_MODE_DOUBLE);
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);

	//第1页面
	AddLeaf(K, 5000, WAIT_CHILD);
	//16点阵字体
	AddDateTime(K, 0, 0, 64, 16, V_TRUE, 0, "Times New Roman", 12, RGB(255,0,0), WFS_NONE, 0, 0, 0, 0, "#y-#m-#d");
	AddDateTime(K, 0, 16, 64, 32, V_TRUE, 0, "Times New Roman", 12, RGB(0,255,0), WFS_NONE, 0, 0, 0, 0, "#h:#m:#s");

	//第2页面
	AddLeaf(K, 5000, WAIT_CHILD);
	//16点阵字体
	AddDateTime(K, 0, 0, 64, 16, V_TRUE, 0, "Times New Roman", 12, RGB(255,0,0), WFS_NONE, 0, 0, 0, 0, "星期#w");
	AddDateTime(K, 0, 16, 64, 32, V_TRUE, 0, "Times New Roman", 12, RGB(0,255,0), WFS_NONE, 0, 0, 0, 0, "#c");

	SetWindowText(hWnd, "正在执行命令或者发送数据...");
	R=LED_SendToScreen(&param, K);
	if (R>=0)
	{
		LED_GetNotifyParam(&notifyparam, R);
		switch(notifyparam.Notify){
			case LM_TIMEOUT:
				SetWindowText(hWnd, "发送超时");
				break;
			case LM_TX_COMPLETE:
				if (notifyparam.Result==RESULT_FLASH)
				{
					SetWindowText(hWnd, "数据传送完成，正在写入Flash");
				}
				else
				{
					SetWindowText(hWnd, "数据传送完成");
				}
				break;
			case LM_RESPOND:
				switch(notifyparam.Command){
					case PKC_GET_POWER:
						if (notifyparam.Status==LED_POWER_ON) SetWindowText(hWnd, "读取电源状态完成，当前为电源开启状态");
						else SetWindowText(hWnd, "读取电源状态完成，当前为电源关闭状态");
						break;
					case PKC_SET_POWER:
						if (notifyparam.Result==99) SetWindowText(hWnd, "当前为定时开关屏模式");
						else if (notifyparam.Status==LED_POWER_ON) SetWindowText(hWnd, "设置电源状态完成，当前为电源开启状态");
						else SetWindowText(hWnd, "设置电源状态完成，当前为电源关闭状态");
						break;
					case PKC_GET_BRIGHT:
						str.Format("读取亮度完成，当前亮度=%d", notifyparam.Status);
						SetWindowText(hWnd, str.GetBuffer(0));
						break;
					case PKC_SET_BRIGHT:
						if (notifyparam.Result==99) SetWindowText(hWnd, "当前为定时亮度调节模式");
						else
						{
							str.Format("设置亮度完成，当前亮度=%d", notifyparam.Status);
							SetWindowText(hWnd, str.GetBuffer(0));
						}
						break;
					case PKC_ADJUST_TIME:
						SetWindowText(hWnd, "校正显示屏时间完成");
						break;
				}
				break;
			case LM_NOTIFY:
				break;
		}
	}
	else
	{
 		switch(R){ 
			case R_DEVICE_INVALID:
				SetWindowText(hWnd, "打开通讯设备失败(串口不存在、或者串口已被占用、或者网络端口被占用)");
				break;
			case R_DEVICE_BUSY:
				SetWindowText(hWnd, "设备忙，正在通讯中...");
				break;
		}
	}
	
	return 0;
}

void CVCDemoDlg::OnTimer(UINT nIDEvent) 
{
	// TODO: Add your message handler code here and/or call default
	switch (nIDEvent){
		case 0:
			//OnBtnText(); //定制执行发送过程，用于测试
			//OnBtnVsq();
            //OnBtnRegion();
			OnBtnObject();
			break;
		case 1:
			AfxBeginThread(Thread_Proc, &this->m_hWnd); //定时启动一个新的发送线程
			break;
		case 2:
			OnBtnDclock();
			break;
	}
	
	CDialog::OnTimer(nIDEvent);
}

void CVCDemoDlg::OnBtnTimer() 
{
	// TODO: Add your control notification handler code here
	SetTimer(0, 1000, NULL);
}

void CVCDemoDlg::OnBtnThread() 
{
	// TODO: Add your control notification handler code here
	SetTimer(1, 1000, NULL);
}

//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////

void CVCDemoDlg::Parse2(long K)
{
	TNotifyParam notifyparam;
	CString str;

	if (K>=0)
	{
		LED_GetNotifyParam(&notifyparam, K);
		switch(notifyparam.Notify){
			case LM_TIMEOUT:
				SetWindowText("发送超时");
				break;
			case LM_TX_COMPLETE:
				if (notifyparam.Result==RESULT_FLASH)
				{
					SetWindowText("数据传送完成，正在写入Flash");
				}
				else
				{
					SetWindowText("数据传送完成");
				}
				break;
			case LM_RESPOND:
				switch(notifyparam.Command){
					case PKC_GET_POWER:
						if (notifyparam.Status==LED_POWER_ON) SetWindowText("读取电源状态完成，当前为电源开启状态");
						else SetWindowText("读取电源状态完成，当前为电源关闭状态");
						break;
					case PKC_SET_POWER:
						if (notifyparam.Result==99) SetWindowText("当前为定时开关屏模式");
						else if (notifyparam.Status==LED_POWER_ON) SetWindowText("设置电源状态完成，当前为电源开启状态");
						else SetWindowText("设置电源状态完成，当前为电源关闭状态");
						break;
					case PKC_GET_BRIGHT:
						str.Format("读取亮度完成，当前亮度=%d", notifyparam.Status);
						SetWindowText(str.GetBuffer(0));
						break;
					case PKC_SET_BRIGHT:
						if (notifyparam.Result==99) SetWindowText("当前为定时亮度调节模式");
						else
						{
							str.Format("设置亮度完成，当前亮度=%d", notifyparam.Status);
							SetWindowText(str.GetBuffer(0));
						}
						break;
					case PKC_ADJUST_TIME:
						SetWindowText("校正显示屏时间完成");
						break;
					case PKC_SET_PARAM:
						SetWindowText("设置控制卡参数完成");
						break;
				}
				break;
			case LM_NOTIFY:
				switch(notifyparam.Result){
					case NOTIFY_SET_PARAM:
						SetWindowText("设置控制卡参数完成");
						break;
				}
				break;
		}
	}
	else
	{
		switch(K){
			case R_DEVICE_INVALID:
				SetWindowText("打开通讯设备失败(串口不存在、或者串口已被占用、或者网络端口被占用)");
				break;
			case R_DEVICE_BUSY:
				SetWindowText("设备忙，正在通讯中...");
				break;
		}
	}
}

void CVCDemoDlg::OnBtnPoweron2() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_SetPower(&param, LED_POWER_ON));
}

void CVCDemoDlg::OnBtnPoweroff2() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_SetPower(&param, LED_POWER_OFF));
}

void CVCDemoDlg::OnBtnGetpower2() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_GetPower(&param));
}

void CVCDemoDlg::OnBtnGetbright2() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_GetBright(&param));
}

void CVCDemoDlg::OnBtnSetbright2() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_SetBright(&param, 5));
}

void CVCDemoDlg::OnBtnAdjusttime2() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;
	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_AdjustTime(&param));
	//////////////////////////////////////////////////////////////////////////
    // 如果要指定显示屏的时间，使用LED_AdjustTimeEx
	//SYSTEMTIME time;
	//GetLocalTime(&time);
	//LED_AdjustTimeEx(&param, &time);
	//////////////////////////////////////////////////////////////////////////
}

void CVCDemoDlg::OnBtnText2() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);

	//第1页面
	AddLeaf(K, 10000, WAIT_CHILD);
	//自动换行的文字
	AddText(K, 0, 0, 64, 16, V_TRUE, 0, "Hello world! HELLO WORLD!", "宋体", 12, RGB(0,255,0), WFS_NONE, V_TRUE, 0, 0, 1, 1, 1, 0, 1, 3);
	//非自动换行的文字
	AddText(K, 0, 16, 64, 32, V_TRUE, 0, "Hello world! Hello world! Hello World!", "宋体", 12, RGB(255,0,0), WFS_NONE, V_FALSE, 0, 2, 1, 1, 1, 1, 1, 3);

	//第2页面
	AddLeaf(K, 10000, WAIT_CHILD);
	//非自动换行的文字
	AddText(K, 0, 0, 64, 16, V_TRUE, 0, "Hello world!", "宋体", 12, RGB(255,255,0), WFS_NONE, V_TRUE, 0, 0, 1, 1, 1, 1, 1, 5);

	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnDib2() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;
	HDC dc;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);
	AddLeaf(K, 10000, WAIT_CHILD);
	dc = ::GetDC(NULL);
	AddWindow(K, 0, 0, 128, 16, V_TRUE, 0, dc, 128, 64, 0, 1, 1, 1, 1, 1, 1, 1000);
	::ReleaseDC(NULL, dc);

	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnString2() 
{
	// TODO: Add your control notification handler code here
//////////////////////////////////////////////////////////////////////////
//  注意，要使用内码文字，控制卡必须先下载字库，
//  否则发送完会没有显示内容
//////////////////////////////////////////////////////////////////////////

	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 64, 32, 0);

	//第1页面
	AddLeaf(K, 10000, WAIT_CHILD);
	//16点阵字体
	AddString(K, 0, 0, 64, 16, V_TRUE, 0, "Hello world! Hello world! Hello World!", FONT_SET_16, RGB(255,0,0), 0, 1, 1, 1, 0, 1, 1000);

	//第2页面
	AddLeaf(K, 10000, WAIT_CHILD);
	//24点阵字体
	AddString(K, 0, 0, 64, 32, V_TRUE, 0, "Hello world! Hello world! Hello World!", FONT_SET_24, RGB(255,0,0), 3, 1, 1, 1, 1, 1, 1000);

	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnPicFile2() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;
	HDC dc;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);
	AddLeaf(K, 10000, WAIT_CHILD);
	dc = ::GetDC(NULL);
	AddPicture(K, 0, 0, 128, 16, V_TRUE, 0, "C:\\Demo.bmp", 0, 2, 1, 1, 1, 1, 0, 1000);
	::ReleaseDC(NULL, dc);

	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnDclock2() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);

	//第1页面
	AddLeaf(K, 5000, WAIT_CHILD);
	//16点阵字体
	AddDateTime(K, 0, 0, 64, 16, V_TRUE, 0, "Times New Roman", 12, RGB(255,0,0), WFS_NONE, 0, 0, 0, 0, "#y-#m-#d");
	AddDateTime(K, 0, 16, 64, 32, V_TRUE, 0, "Times New Roman", 12, RGB(0,255,0), WFS_NONE, 0, 0, 0, 0, "#h:#m:#s");

	//第2页面
	AddLeaf(K, 5000, WAIT_CHILD);
	//16点阵字体
	AddDateTime(K, 0, 0, 64, 16, V_TRUE, 0, "Times New Roman", 12, RGB(255,0,0), WFS_NONE, 0, 0, 0, 0, "星期#w");
	AddDateTime(K, 0, 16, 64, 32, V_TRUE, 0, "Times New Roman", 12, RGB(0,255,0), WFS_NONE, 0, 0, 0, 0, "#c");

	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnAclock2() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

	K = MakeRoot(ROOT_PLAY, GetColorType());
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);

	//第1页面
	AddLeaf(K, 5000, WAIT_CHILD);
	//16点阵字体
	AddClock(K, 0, 0, 64, 64, V_TRUE, 0, 0, RGB(0,0,0), RGB(255,255,0), 1, SHAPE_CIRCLE, 30, 3, RGB(0,255,0), 2, RGB(255,255,0), 
		3, RGB(255,255,0), 2, RGB(0,255,0), 1, RGB(255,0,0));

	SetWindowText("正在执行命令或者发送数据...");
	Parse2(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnChapter() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

    //这个操作中，ChapterIndex=0，只更新控制卡内第1个节目
    //如果ChapterIndex=1，只更新控制卡内第2个节目
    //以此类推
	K = MakeChapter(ROOT_PLAY_CHAPTER, ACTMODE_REPLACE, 0, GetColorType(), 5000, WAIT_CHILD);
	AddRegion(K, 0, 0, 128, 32, 0);
	AddLeaf(K, 10000, WAIT_CHILD);
    if (my_flag)
    {
    	//自动换行的文字
        AddText(K, 0, 0, 64, 16, V_TRUE, 0, "你好朋友", "宋体", 12, RGB(0,255,0), WFS_NONE, V_TRUE, 0, 0, 0, 1, 1, 0, 1, 3000);
        my_flag=0;
    }
    else
    {
    	//自动换行的文字
        AddText(K, 0, 0, 64, 16, V_TRUE, 0, "欢迎来访", "宋体", 12, RGB(0,255,0), WFS_NONE, V_TRUE, 0, 0, 0, 1, 1, 0, 1, 3000);
        my_flag=1;
    }

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnRegion() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

    //这个操作中，ChapterIndex=0，RegionIndex=0，只更新控制卡内第1个节目中的第1个分区
    //如果ChapterIndex=1，RegionIndex=2，只更新控制卡内第2个节目中的第3个分区
    //以此类推
	K = MakeRegion(ROOT_PLAY_REGION, ACTMODE_REPLACE, 0, 0, GetColorType(), 0, 0, 192, 16, 0);
	AddLeaf(K, 10000, WAIT_CHILD);
    if (my_flag)
    {
    	//自动换行的文字
        //AddText(K, 0, 0, 64, 16, V_TRUE, 0, "你好朋友", "宋体", 12, RGB(0,255,0), WFS_NONE, V_TRUE, 0, 0, 0, 1, 1, 0, 1, 3000);
        AddString(K, 0, 0, 32, 16, V_TRUE, 0, "你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友你好朋友", FONT_SET_16, RGB(255,255,0), 6, 5, 0, 5, 0, 0, 3000);
        my_flag=0;
    }
    else
    {
    	//自动换行的文字
        //AddText(K, 0, 0, 64, 16, V_TRUE, 0, "欢迎来访欢迎来访欢迎来访", "宋体", 12, RGB(0,255,0), WFS_NONE, V_TRUE, 0, 0, 0, 1, 1, 0, 1, 3000);
        AddString(K, 0, 0, 32, 16, V_TRUE, 0, "欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访欢迎来访", FONT_SET_16, RGB(255,255,0), 4, 5, 0, 5, 0, 0, 3000);
        my_flag=1;
    }

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnLeaf() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

    //这个操作中，ChapterIndex=0，RegionIndex=0，LeafIndex=0，只更新控制卡内第1个节目中的第1个分区中的第1个页面
    //如果ChapterIndex=1，RegionIndex=2，LeafIndex=1，只更新控制卡内第2个节目中的第3个分区中的第2个页面
    //以此类推
	K = MakeLeaf(ROOT_PLAY_LEAF, ACTMODE_REPLACE, 0, 0, 0, GetColorType(), 5000, WAIT_CHILD);
    if (my_flag)
    {
    	//自动换行的文字
        AddText(K, 0, 0, 64, 16, V_TRUE, 0, "你好朋友", "宋体", 12, RGB(0,255,0), WFS_NONE, V_TRUE, 0, 0, 0, 1, 1, 0, 1, 3000);
        my_flag=0;
    }
    else
    {
    	//自动换行的文字
        AddText(K, 0, 0, 64, 16, V_TRUE, 0, "欢迎来访", "宋体", 12, RGB(0,255,0), WFS_NONE, V_TRUE, 0, 0, 0, 1, 1, 0, 1, 3000);
        my_flag=1;
    }

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnObject() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	int K;
	long x, y, cx, cy;

	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_EVENT;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

    //这个操作中，ChapterIndex=0，RegionIndex=0，LeafIndex=0，ObjectIndex=0，只更新控制卡内第1个节目中的第1个分区中的第1个页面的第1个对象
    //如果ChapterIndex=1，RegionIndex=2，LeafIndex=1，只更新控制卡内第2个节目中的第3个分区中的第2个页面
    //以此类推
	switch(my_index){
	case 0: 
		K = MakeObject(ROOT_PLAY_OBJECT, ACTMODE_REPLACE, 0, 0, 0, 1, GetColorType());
		x=11;
		y=43;
		cx=516;
		cy=20;
		break;
	case 1: 
		K = MakeObject(ROOT_PLAY_OBJECT, ACTMODE_REPLACE, 0, 0, 0, 2, GetColorType());
		x=11;
		y=65;
		cx=516;
		cy=20;
		break;
	case 2: 
		K = MakeObject(ROOT_PLAY_OBJECT, ACTMODE_REPLACE, 0, 0, 0, 3, GetColorType());
		x=11;
		y=87;
		cx=516;
		cy=20;
		break;
	case 3: 
		K = MakeObject(ROOT_PLAY_OBJECT, ACTMODE_REPLACE, 0, 0, 0, 30, GetColorType());
		break;
	case 4: 
		K = MakeObject(ROOT_PLAY_OBJECT, ACTMODE_REPLACE, 0, 0, 0, 32, GetColorType());
		break;
	case 5: 
		K = MakeObject(ROOT_PLAY_OBJECT, ACTMODE_REPLACE, 0, 0, 0, 33, GetColorType());
		break;
	}
	my_index++;
	if (my_index>=3) my_index=0;
    
    if (my_flag)
    {
	    AddText(K, x, y, cx, cy, V_TRUE, 0, "同一个世界同一个世界同一个世界同一个世界", "宋体", 12, RGB(255,255,0), WFS_NONE, V_TRUE, 0, 1, 5, 1, 5, 0, 1, 3000);
        my_flag=0;
    }
    else
    {
	    AddText(K, x, y, cx, cy, V_TRUE, 0, "梦想同一个梦想同一个梦想同一个梦想同一个", "宋体", 12, RGB(255,255,0), WFS_NONE, V_TRUE, 0, 1, 5, 1, 5, 0, 1, 3000);
        my_flag=1;
    }
	/*
    if (my_flag)
    {
        AddText(K, 11, 43, 516, 20, V_TRUE, 0, "AAAAAAAAAAAAAAAAAAAAAAAA", "宋体", 12, RGB(0,255,0), WFS_NONE, V_TRUE, 0, 1, 0, 1, 1, 0, 1, 3000);
        my_flag=0;
    }
    else
    {
        AddText(K, 11, 43, 516, 20, V_TRUE, 0, "ZZZZZZZZZZZZZZZZZZZZZZZZ", "宋体", 12, RGB(255,0,0), WFS_NONE, V_TRUE, 0, 1, 0, 1, 1, 0, 1, 3000);
        my_flag=1;
    }
	*/

	Parse(LED_SendToScreen(&param, K));
}

void CVCDemoDlg::OnBtnPoweron3() 
{
	// TODO: Add your control notification handler code here
	long I=-1;
	TSenderParam param;
	GetDeviceParam(&param.devParam);
	if (param.devParam.devType==DEVICE_TYPE_UDP)
	{
		I=LED_UDP_SenderParam(0, param.devParam.locPort, param.devParam.rmtHost, param.devParam.rmtPort, param.devParam.dstAddr, NOTIFY_BLOCK, 0, 0);
	}else
	if (param.devParam.devType==DEVICE_TYPE_COM)
	{
		I=LED_COM_SenderParam(0, param.devParam.comPort, param.devParam.comSpeed, param.devParam.dstAddr, NOTIFY_BLOCK, 0, 0);
	}

	if (I>=0)
	{
		SetWindowText("正在执行命令或者发送数据...");
		Parse2(LED_SetPower2(0, LED_POWER_ON));
	}
}

void CVCDemoDlg::OnBtnOnlineStart() 
{
	// TODO: Add your control notification handler code here
	if (LED_Report_CreateServer(0, 8888))
	{
		MessageBox("在线控制卡监听服务启动成功，在8888端口进行监听");
	}
	else
	{
		MessageBox("在线控制卡监听服务已启动，8888端口当前被占用，请检查是否有其它应用程序使用该端口");
	}
	//可以创建多个监听服务，例如继续调用LED_Report_CreateServer(1, 8889);
	//则表示创建了两个监听，一个在8888端口，一个在8889端口
}

void CVCDemoDlg::OnBtnOnlineStop() 
{
	// TODO: Add your control notification handler code here
	LED_Report_RemoveServer(0);
	//或者调用 LED_Report_RemoveAllServer();
}

void CVCDemoDlg::OnBtnOnline() 
{
	// TODO: Add your control notification handler code here

	TDeviceReport devices[1024];
	in_addr inaddr;
	long devcount;
	long I;
	CString s, s1;

	//第1种方式，直接导出在线控制卡列表
	devcount=LED_Report_GetOnlineList(0, (void*)devices, 1024);
	s.Format("在线控制卡数量=%d\r\n名称 IP地址 端口 硬件地址\r\n", devcount);
	for (I=0; I<devcount; I++)
	{
		inaddr.S_un.S_addr=devices[I].devinfo.dev_ip;
		s1.Format("%s  %s  %d  %d\r\n", 
			devices[I].devinfo.dev_name, 
			inet_ntoa(inaddr), 
			devices[I].devinfo.dev_port, 
			devices[I].devinfo.dev_addr);
		s+=s1;
	}
	MessageBox(s);

	//第2种方式，将在线控制卡列表保存在动态链接库的缓冲区中，然后调用相应接口读取详细信息
	devcount=LED_Report_GetOnlineList(0, NULL, 0);
	s.Format("在线控制卡数量=%d\r\n名称 IP地址 端口 硬件地址\r\n", devcount);
	for (I=0; I<devcount; I++)
	{
		s1.Format("%s  %s  %d  %d\r\n", 
			LED_Report_GetOnlineItemName(0, I),
			LED_Report_GetOnlineItemHost(0, I),
			LED_Report_GetOnlineItemPort(0, I),
			LED_Report_GetOnlineItemAddr(0, I));
		s+=s1;
	}
	MessageBox(s);

}

void CVCDemoDlg::OnBtnBoardParam() 
{
	// TODO: Add your control notification handler code here
	TSenderParam param;
	memset(&param, 0, sizeof(TSenderParam));
	GetDeviceParam(&param.devParam);
	param.notifyMode = NOTIFY_BLOCK;
	param.wmHandle = (long)m_hWnd;
	param.wmMessage = WM_LED_NOTIFY;

/*	//例程1：提取各个参数的例程
	if (LED_Cache_GetBoardParam(&param)>=0)
	{
		CString str;
		str.Format("IP=%s, Mac=%s, Addr=%d, Width=%d, Height=%d, Brightness=%d",
			LED_Cache_GetBoardParam_IP(),
			LED_Cache_GetBoardParam_Mac(),
			LED_Cache_GetBoardParam_Addr(),
			LED_Cache_GetBoardParam_Width(),
			LED_Cache_GetBoardParam_Height(),
			LED_Cache_GetBoardParam_Brightness());
		AfxMessageBox(str.GetBuffer(0));

		LED_Cache_SetBoardParam_IP(LED_Cache_GetBoardParam_IP());
		LED_Cache_SetBoardParam_Mac("01-01-F1-DE-1A-02");
		LED_Cache_SetBoardParam_Addr(0);
		LED_Cache_SetBoardParam_Width(256);
		LED_Cache_SetBoardParam_Height(64);
		LED_Cache_SetBoardParam_Brightness(7);
		Parse2(LED_Cache_SetBoardParam(&param));
	}
	else
	{
		AfxMessageBox("读取控制卡参数失败");
	}
*/

///*	//例程2：从控制卡读取参数，并保存到文件中
	if (LED_Cache_GetBoardParam(&param)>=0)
	{
		LED_Cache_GetBoardParam_SaveToFile("C:\\LEDConfig.dat");
	}
	else
	{
		AfxMessageBox("读取控制卡参数失败");
	}
//*/

/*	//例程3：从文件载入控制卡参数，并设置到控制卡中
	if (LED_Cache_SetBoardParam_LoadFromFile("C:\\LEDConfig.dat")==1)
	{
		Parse2(LED_Cache_SetBoardParam(&param));
	}
*/
}

void CVCDemoDlg::OnBtnPreview() 
{
	// TODO: Add your control notification handler code here
	int K;
	K = MakeRoot(ROOT_PLAY, GetColorType());

	// 2分区节目
	AddChapter(K, 30000, WAIT_CHILD);
	AddRegion(K, 0, 0, 64, 64, 0);
	AddLeaf(K, 10000, WAIT_CHILD);
    AddText(K, 0, 0, 64, 16, V_TRUE, 0, "同一个世界同一个世界同一个世界同一个世界", "宋体", 12, RGB(255,255,0), WFS_NONE, V_TRUE, 0, 7, 5, 1, 5, 0, 1, 3000);
	AddDateTime(K, 0, 24, 64, 16, V_TRUE, 0, "Times New Roman", 12, RGB(255,0,0), WFS_NONE, 0, 0, 0, 0, "#y-#m-#d");
	AddDateTime(K, 0, 48, 64, 32, V_TRUE, 0, "Times New Roman", 12, RGB(0,255,0), WFS_NONE, 0, 0, 0, 0, "#h:#n:#s");

	LED_Preview(K, 128, 64, "C:\\Preview.dat");
}
