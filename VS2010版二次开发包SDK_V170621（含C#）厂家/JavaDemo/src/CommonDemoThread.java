import com.sun.jna.Library;
import com.sun.jna.Native;

//import com.sun.jna.win32.*;

public class CommonDemoThread {
	public interface LedControl extends Library {

		// 当前路径是在项目下，而不是bin输出目录下。
		LedControl INSTANCE = (LedControl) Native.loadLibrary("LEDSender2010",
				LedControl.class);

		// 发送和执行命令错误代码
		public static final int R_DEVICE_READY = 0;
		public static final int R_DEVICE_INVALID = -1;
		public static final int R_DEVICE_BUSY = -2;

		// 发送和执行命令应答代码
		public static final int LM_RX_COMPLETE = 1;
		public static final int LM_TX_COMPLETE = 2;
		public static final int LM_RESPOND = 3;
		public static final int LM_TIMEOUT = 4;
		public static final int LM_NOTIFY = 5;
		public static final int RESULT_FLASH = 0xff;

		// 命令代码定义
		public static final int PKC_RESPOND = 3;
		public static final int PKC_QUERY = 4;
		public static final int PKC_OVERFLOW = 5;
		public static final int PKC_ADJUST_TIME = 6;
		public static final int PKC_GET_PARAM = 7;
		public static final int PKC_SET_PARAM = 8;
		public static final int PKC_GET_POWER = 9;
		public static final int PKC_SET_POWER = 10;
		public static final int PKC_GET_BRIGHT = 11;
		public static final int PKC_SET_BRIGHT = 12;

		// 下位机返回的命令代码
		// 下位机返回的命令代码
		public static final int NOTIFY_ROOT_DOWNLOAD = 0x00010003;
		public static final int NOTIFY_SET_PARAM = 0x00010004;
		public static final int NOTIFY_GET_PLAY_BUFFER = 0x00011001; // 读取控制卡显示内容

		// 发送和执行命令应答代码
		public static final int POWER_ON = 1;
		public static final int POWER_OFF = 0;

		// 节目数据命令类型
		public static final int ROOT_PLAY = 0x21;
		public static final int ROOT_DOWNLOAD = 0x22;
		public static final int ROOT_PLAY_CHAPTER = 0x23; // 局部更新--节目
		public static final int ROOT_PLAY_REGION = 0x25; // 局部更新--分区
		public static final int ROOT_PLAY_LEAF = 0x27; // 局部更新--页面
		public static final int ROOT_PLAY_OBJECT = 0x29; // 局部更新--对象

		// 局部更新操作类型
		public static final int MODE_INSERT = 0x00;
		public static final int MODE_REPLACE = 0x01;

		// 节目基色类型
		public static final int COLOR_MODE_MONO = 0x1; // 单路信号
		public static final int COLOR_MODE_DOUBLE = 0x2; // 单双色(双路信号)
		public static final int COLOR_MODE_THREE = 0x3; // 全彩无灰度
		public static final int COLOR_MODE_FULLCOLOR = 0x4; // 全彩

		// 播放时间模式
		public static final int MODE_WAIT_CHILD = 0x1;
		public static final int MODE_USE_TIME = 0x0;

		// 创建控制卡在线监听服务
		// serverindex 控制卡在线监听服务编号(可以在多个socket udp端口监听)
		// localport 本地端口
		int LED_Report_CreateServer(int serverindex, int localport);

		// 删除控制卡在线监听服务
		// serverindex 控制卡在线监听服务编号
		int LED_Report_RemoveServer(int serverindex);

		// 删除全部控制卡在线监听服务
		int LED_Report_RemoveAllServer();

		// 获得控制卡在线列表
		// 必须先创建控制卡在线监听服务，即调用LED_Report_CreateServer后使用，否则返回值无效
		// serverindex 控制卡在线监听服务编号
		// plist 输出在线列表的用户外部缓冲区，void* 对应什么类型？
		// 如果传入空(NULL/0)，则输出到动态链接库内部的缓冲区，继续调用下面的接口取得详细信息
		// count 最大读取个数
		// --返回值-- 小于0表示失败(未创建该在线监听服务)，大于等于0表示在线的控制卡数量
		int LED_Report_GetOnlineList(int serverindex, String plist, int count);

		// 获得某个在线控制卡的上报控制卡名称
		// 必须先创建控制卡在线监听服务，即调用LED_Report_CreateServer后使用，否则返回值无效
		// serverindex 控制卡在线监听服务编号
		// itemindex 该监听服务的在线列表中，在线控制卡的编号
		// --返回值-- 在线控制卡的上报控制卡名称
		String LED_Report_GetOnlineItemName(int serverindex, int itemindex);

		// 获得某个在线控制卡的上报控制卡IP地址
		// 必须先创建控制卡在线监听服务，即调用LED_Report_CreateServer后使用，否则返回值无效
		// serverindex 控制卡在线监听服务编号
		// itemindex 该监听服务的在线列表中，在线控制卡的编号
		// --返回值-- 在线控制卡的IP地址
		String LED_Report_GetOnlineItemHost(int serverindex, int itemindex);

		// 获得某个在线控制卡的上报控制卡远程UDP端口号
		// 必须先创建控制卡在线监听服务，即调用LED_Report_CreateServer后使用，否则返回值无效
		// serverindex 控制卡在线监听服务编号
		// itemindex 该监听服务的在线列表中，在线控制卡的编号
		// --返回值-- 在线控制卡的远程UDP端口号
		int LED_Report_GetOnlineItemPort(int serverindex, int itemindex);

		// 获得某个在线控制卡的上报控制卡地址
		// 必须先创建控制卡在线监听服务，即调用LED_Report_CreateServer后使用，否则返回值无效
		// serverindex 控制卡在线监听服务编号
		// itemindex 该监听服务的在线列表中，在线控制卡的编号
		// --返回值-- 在线控制卡的硬件地址
		int LED_Report_GetOnlineItemAddr(int serverindex, int itemindex);

		// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/************************************************************************/
		/* 填写通讯参数接口函数，用于一些无法传递结构体和指针的开发环境来调用 */
		/************************************************************************/

		// 填写网络通讯参数，供发送时使用
		// index 参数数组编号
		// localport 本地端口
		// host 控制卡IP地址
		// remoteport 远程端口
		// address 控制卡地址
		// notifymode 通讯同步异步模式
		// wmhandle 接收消息窗体句柄
		// wmmessage 接收消息的消息号
		// --返回值-- 小于0表示失败，大于等于0表示参数的id号
		int LED_UDP_SenderParam(int index, int localport, String host,
				int remoteport, int address, int notifymode, int wmhandle,
				int wmmessage);
		// txtimeo 超时等待时间
		// txrepeat 失败重发次数
		int LED_UDP_SenderParamEx(int index, int localport, String host,
				int remoteport, int address, int notifymode, int wmhandle,
				int wmmessage, int txtimeo, int txrepeat);

		// 填写串口通讯参数，供发送时使用
		// index 参数数组编号
		// comport 串口号
		// baudrate 波特率
		// address 控制卡地址
		// notifymode 通讯同步异步模式
		// wmhandle 接收消息窗体句柄
		// wmmessage 接收消息的消息号
		// --返回值-- 小于0表示失败，大于等于0表示参数的id号
		int LED_COM_SenderParam(int index, int comport, int baudrate,
				int address, int notifymode, int wmhandle, int wmmessage);

		// 填写网络通讯参数，供发送时使用
		// index 参数数组编号
		// localport 本地端口
		// serverindex 在线监听服务编号
		// name 控制卡名称(控制卡上报来的名称)
		// notifymode 通讯同步异步模式
		// wmhandle 接收消息窗体句柄
		// wmmessage 接收消息的消息号
		// --返回值-- 小于0表示失败，大于等于0表示参数的id号
		int LED_UDP_SenderParam_ByReportName(int index, int localport,
				int serverindex, String name, int notifymode, int wmhandle,
				int wmmessage);

		// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// 动态链接库销毁
		// *注意：此函数只能在整个程序退出时，调用一次。在运行过程中，不能调用。
		void LED_Cleanup();

		// 设置控制卡电源 value=LED_POWER_ON表示开启电源 value=LED_POWER_OFF表示关闭电源
		int LED_SetPower2(int senderparam_index, int power);

		// 读取控制卡电源状态
		int LED_GetPower2(int senderparam_index);

		// 设置控制卡亮度 value取值范围0-7
		int LED_SetBright2(int senderparam_index, int value);

		// 读取控制卡亮度
		int LED_GetBright2(int senderparam_index);

		// 复位控制卡节目播放，重新显示控制卡Flash中存储的节目
		int LED_ResetDisplay2(int senderparam_index);

		// 校正时间，以当前计算机的系统时间校正控制卡的时钟
		int LED_AdjustTime2(int senderparam_index);

		// 校正时间扩展，以指定的时间校正控制卡的时钟
		int LED_AdjustTimeEx2(int senderparam_index, int year, int month,
				int day, int hour, int minute, int second);

		// 读取控制卡内播放的节目
		int LED_GetPlayContent2(int senderparam_index);

		// 设置当前显示的节目
		int LED_SetCurChapter2(int senderparam_index, int value);

		// 设置控制卡的定时开关屏计划
		// eanbled: =0表示禁用定时开关屏功能 =1表示启用定时开关屏功能
		// mode: =0表示一周七天开关屏计划 =1表示绝对时间定时开关屏计划
		// AOpenTX, ACloseTX: 开关屏时间。
		// 当mode=0时，每三组表示一天的三个开关屏时间，一共7天，共21组
		// 当mode=1时，21组开关屏日期时间
		int LED_SetPowerSchedule2(int senderparam_index, int enabled, int mode,
				String AOpenT0, String ACloseT0, String AOpenT1,
				String ACloseT1, String AOpenT2, String ACloseT2,
				String AOpenT3, String ACloseT3, String AOpenT4,
				String ACloseT4, String AOpenT5, String ACloseT5,
				String AOpenT6, String ACloseT6, String AOpenT7,
				String ACloseT7, String AOpenT8, String ACloseT8,
				String AOpenT9, String ACloseT9, String AOpenT10,
				String ACloseT10, String AOpenT11, String ACloseT11,
				String AOpenT12, String ACloseT12, String AOpenT13,
				String ACloseT13, String AOpenT14, String ACloseT14,
				String AOpenT15, String ACloseT15, String AOpenT16,
				String ACloseT16, String AOpenT17, String ACloseT17,
				String AOpenT18, String ACloseT18, String AOpenT19,
				String ACloseT19, String AOpenT20, String ACloseT20);

		// 读取控制卡的定时开关屏计划
		int LED_GetPowerSchedule2(int senderparam_index);

		// 设置控制卡的定时亮度调节计划
		int LED_GetBrightSchedule2(int senderparam_index);

		// 发送节目数据
		// index为MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject函数的返回值
		int LED_SendToScreen2(int senderparam_index, int index);

		// 读取控制卡参数
		int LED_Cache_GetBoardParam2(int senderparam_index);

		// 读取控制卡IP地址
		String LED_Cache_GetBoardParam_IP();

		// 设置控制卡IP地址
		void LED_Cache_SetBoardParam_IP(String value);

		// 设置控制卡参数
		int LED_Cache_SetBoardParam2(int senderparam_index);

		// 获取控制卡应答结果的数据
		int LED_GetNotifyParam_Notify(int index);
		int LED_GetNotifyParam_Command(int index);
		int LED_GetNotifyParam_Result(int index);
		int LED_GetNotifyParam_Status(int index);
		String LED_GetNotifyParam_Host(int index);

		// 获取控制卡应答结果的数据，同时将控制卡回读数据保存到文件
		int LED_GetNotifyParam_Buffer(String filename, int index);

		// 预览播放节目数据文件
		void LED_PreviewFileEx(String previewapp, int width, int height,
				String previewfile);

		// 将节目文件导出图片组
		void LED_PreviewFile_Export(String previewapp, int width, int height,
				int rgreverse, String previewfile);

		// 设置动态链接库输入的字符集编码
		// value 字符集编号 0=GB编码 1=UTF8 2=Unicode(未实现)
		void SetGlobalCharset(int value);

		// 设置RGB信号顺序
		// value 信号顺序：1)对于单双色 =0红绿 =1绿红；2)对于全彩无灰度、全彩 =0红绿蓝 =1红蓝绿 =2绿红蓝 =3绿蓝红
		// =4蓝红绿 =5蓝绿红'
		int SetSignalOrder(int value);

		// 设置点阵旋转
		// rotate 旋转方式：=0不旋转 =1逆时针旋转90度 =2顺时针旋转90度
		// width 显示屏宽度(旋转后)
		// height 显示屏高度(旋转后)
		int SetRotate(int rotate, int width, int height);

		// 生成播放数据（从VS2010软件编辑的Vsq文件载入，并生成要下发的节目数据）
		// RootType
		// 为播放类型；=ROOT_PLAY表示更新控制卡RAM中的节目(掉电丢失)；=ROOT_DOWNLOAD表示更新控制卡Flash中的节目(掉电不丢失)
		// ColorMode 为颜色模式；取值为COLOR_MODE_MONO或者COLOR
		// survive 为RAM节目生存时间，在RootType=ROOT_PLAY时有效，当RAM节目播放达到时间后，恢复显示FLASH中的节目
		// survive=ROOT_SURVIVE_ALWAYS
		// filename 由VisionShow软件编辑的节目文件
		int MakeFromVsqFile(String filename, int RootType, int ColorMode,
				int survive);

		// 生成播放数据
		// RootType
		// 为播放类型；=ROOT_PLAY表示更新控制卡RAM中的节目(掉电丢失)；=ROOT_DOWNLOAD表示更新控制卡Flash中的节目(掉电不丢失)
		// ColorMode 为颜色模式；取值为COLOR_MODE_MONO或者COLOR
		// survive 为RAM节目生存时间，在RootType=ROOT_PLAY时有效，当RAM节目播放达到时间后，恢复显示FLASH中的节目
		// survive = ROOT_SURVIVE_ALWAYS
		int MakeRoot(int RootType, int ColorMode, int survive);

		int MakeRootEx(int RootType, int ColorMode, int survive,
				int ARotateKey, int AMetrixCX, int AMetrixCY);

		// 生成节目数据，后续需要调用[AddRegion]->[AddLeaf]->[AddObject]->[AddWindows/AddDateTime等]
		// ActionMode 必须设为0
		// ChapterIndex 要更新的节目序号
		// ColorMode 同MakeRoot中的定义
		// time 播放的时间长度
		// wait 等待模式，=WAIT_CHILD，表示当达到播放时间长度时，需要等待子节目播放完成再切换；
		// =WAIT_USE_TIME，表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一节目
		int MakeChapter(int RootType, int ActionMode, int ChapterIndex,
				int ColorMode, int time, int wait);

		// 生成分区，后续需要调用[AddLeaf]->[AddObject]->[AddWindows/AddDateTime等]
		// RootType 必须设为ROOT_PLAY_REGION
		// ActionMode 必须设为0
		// ChapterIndex 要更新的节目序号
		// RegionIndex 要更新的分区序号
		// ColorMode 同MakeRoot中的定义
		// left、top、width、height 左、上、宽度、高度
		// border 流水边框
		int MakeRegion(int RootType, int ActionMode, int ChapterIndex,
				int RegionIndex, int ColorMode, int left, int top, int width,
				int height, int border);

		// 生成页面，后续需要调用[AddObject]->[AddWindows/AddDateTime等]
		// RootType 必须设为ROOT_PLAY_LEAF
		// ActionMode 必须设为0
		// ChapterIndex 要更新的节目序号
		// RegionIndex 要更新的分区序号
		// LeafIndex 要更新的页面序号
		// ColorMode 同MakeRoot中的定义
		// time 播放的时间长度
		// wait 等待模式，=WAIT_CHILD，表示当达到播放时间长度时，需要等待子节目播放完成再切换；
		// =WAIT_USE_TIME，表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一页面
		int MakeLeaf(int RootType, int ActionMode, int ChapterIndex,
				int RegionIndex, int LeafIndex, int ColorMode, int time,
				int wait);

		// 生成播放对象，后续需要调用[AddWindows/AddDateTime等]
		// RootType 必须设为ROOT_PLAY_LEAF
		// ActionMode 必须设为0
		// ChapterIndex 要更新的节目序号
		// RegionIndex 要更新的分区序号
		// LeafIndex 要更新的页面序号
		// ObjectIndex 要更新的对象序号
		// ColorMode 同MakeRoot中的定义
		int MakeObject(int RootType, int ActionMode, int ChapterIndex,
				int RegionIndex, int LeafIndex, int ObjectIndex, int ColorMode);

		// 添加节目
		// num 节目数据缓冲区编号，是MakeRoot的返回值
		// time 播放的时间长度
		// wait 等待模式，=WAIT_CHILD，表示当达到播放时间长度时，需要等待子节目播放完成再切换；
		// =WAIT_USE_TIME，表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一节目
		int AddChapter(short num, int time, short wait);// time为毫秒

		// 添加节目
		// num 节目数据缓冲区编号，是MakeRoot的返回值
		// time 播放的时间长度
		// wait 等待模式，=WAIT_CHILD，表示当达到播放时间长度时，需要等待子节目播放完成再切换；
		// =WAIT_USE_TIME，表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一节目
		// priority 优先级，置0
		// kind 计划模式，=0始终播放，=1按一周每日播放，=2按起止时间播放，=3不播放
		// week 一周定义，当kind=1时有效，从bit0-bit6表示周日到周六
		// fromtime、totime，起止时间，当kind=1时，表示每日的起止时间，当kind=2时，表示从某年某月某日某时间开始，到某年某月某日某时间结束
		int AddChapterEx2(short num, int time, short wait, short priority,
				short kind, short week, String fromtime, String totime);// time为毫秒

		// 添加分区
		// num 节目数据缓冲区编号，是MakeRoot、MakeChapter的返回值
		// left、top、width、height 左、上、宽度、高度
		// border 流水边框
		int AddRegion(short num, int left, int top, int width, int height,
				int border);

		// 添加页面
		// num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion的返回值
		// time 播放的时间长度
		// wait 等待模式，=WAIT_CHILD，表示当达到播放时间长度时，需要等待子节目播放完成再切换；
		// =WAIT_USE_TIME，表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一页面
		int AddLeaf(short num, int time, short wait);// time为毫秒

		// 添加页面
		// num 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion的返回值
		// time 播放的时间长度
		// wait 等待模式，=WAIT_CHILD，表示当达到播放时间长度时，需要等待子节目播放完成再切换；
		// =WAIT_USE_TIME，表示当达到播放时间长度时，不等待子节目播放完成，直接切换下一页面
		int AddLeafEx(short num, int time, short wait, int bkcolor);// time为毫秒

		int AddLeafExA(short num, int time, short wait, int x1, int y1,
				int cx1, int cy1, int bkcolor1, int x2, int y2, int cx2,
				int cy2, int bkcolor2, int x3, int y3, int cx3, int cy3,
				int bkcolor3, int x4, int y4, int cx4, int cy4, int bkcolor4);// time为毫秒

		// 添加日期时间显示
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// left、top、width、height 左、上、宽度、高度
		// transparent 是否透明 =1表示透明；=0表示不透明
		// border 流水边框(未实现)
		// fontname 字体名称
		// fontsize 字体大小
		// fontcolor 字体颜色
		// fontstyle 字体样式
		// 举例：=WFS_BOLD表示粗体；=WFS_ITALIC表示斜体；=WFS_BOLD+WFS_ITALIC表示粗斜体
		// year_offset 年偏移量
		// month_offset 月偏移量
		// day_offset 日偏移量
		// sec_offset 秒偏移量
		// format 显示格式
		// #y表示年 #m表示月 #d表示日 #h表示时 #n表示分 #s表示秒 #w表示星期 #c表示农历
		// 举例：
		// format="#y年#m月#d日 #h时#n分#s秒 星期#w 农历#c"时，显示为"2009年06月27日 12时38分45秒 星期六 农历五月初五"
		int AddDateTime(short num, int left, int top, int width, int height,
				int transparent, int border, String fontname, int fontsize,
				int fontcolor, int fontstyle, int year_offset,
				int month_offset, int day_offset, int sec_offset, String format);

		int AddDateTimeEx(short num, int left, int top, int width, int height,
				int transparent, int border, int vertical, String fontname,
				int fontsize, int fontcolor, int fontstyle, int year_offset,
				int month_offset, int day_offset, int sec_offset, String format);

		// 添加模拟时钟
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// left、top、width、height 左、上、宽度、高度
		// transparent 是否透明 =1表示透明；=0表示不透明
		// border 流水边框(未实现)
		// offset 秒偏移量
		// bkcolor: 背景颜色
		// framecolor: 表框颜色
		// framewidth: 表框颜色
		// frameshape: 表框形状 =0表示正方形；=1表示圆角方形；=2表示圆形
		// dotradius: 刻度距离表盘中心半径
		// adotwidth: 0369点刻度大小
		// adotcolor: 0369点刻度颜色
		// bdotwidth: 其他点刻度大小
		// bdotcolor: 其他点刻度颜色
		// hourwidth: 时针粗细
		// hourcolor: 时针颜色
		// minutewidth: 分针粗细
		// minutecolor: 分针颜色
		// secondwidth: 秒针粗细
		// secondcolor: 秒针颜色
		int AddClock(short num, int left, int top, int width, int height,
				int transparent, int border, int offset, short bkcolor,
				short framecolor, short framewidth, int frameshape,
				int dotradius, int adotwidth, short adotcolor, int bdotwidth,
				short bdotcolor, int hourwidth, short hourcolor,
				int minutewidth, short minutecolor, int secondwidth,
				short secondcolor);

		// 添加动画
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// left、top、width、height 左、上、宽度、高度
		// transparent 是否透明 =1表示透明；=0表示不透明
		// border 流水边框(未实现)
		// filename avi文件名
		// stretch: 图像是否拉伸以适应对象大小
		int AddMovie(short num, int left, int top, int width, int height,
				int transparent, int border, String filename, int stretch);

		// 添加图片组播放
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// left、top、width、height 左、上、宽度、高度
		// transparent 是否透明 =1表示透明；=0表示不透明
		// border 流水边框(未实现)
		int AddWindows(short num, int left, int top, int width, int height,
				int transparent, int border);

		// 添加图片组的子图片 此函数要跟在AddWindows后面调用
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// dc 源图片DC句柄
		// width 图片宽度
		// height 图片高度
		// inmethod 引入方式(下面有列表说明)
		// inspeed 引入速度(取值范围0-5，从快到慢)
		// outmethod 引出方式(下面有列表说明)
		// outspeed 引出速度(取值范围0-5，从快到慢)
		// stopmethod 停留方式(下面有列表说明)
		// stopspeed 停留速度(取值范围0-5，从快到慢)
		// stoptime 停留时间(单位毫秒)
		// -------long (_stdcall *AddChildWindow)(WORD num, HDC dc, long width,
		// long height, long alignment, long inmethod, long inspeed, long
		// outmethod, long outspeed, long stopmethod, long stopspeed, long
		// stoptime); //stoptime单位为秒

		// 添加图片组的子图片 此函数要跟在AddWindows后面调用
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// filename 图片文件名
		// inmethod 引入方式(下面有列表说明)
		// inspeed 引入速度(取值范围0-5，从快到慢)
		// outmethod 引出方式(下面有列表说明)
		// outspeed 引出速度(取值范围0-5，从快到慢)
		// stopmethod 停留方式(下面有列表说明)
		// stopspeed 停留速度(取值范围0-5，从快到慢)
		// stoptime 停留时间(单位毫秒)
		int AddChildPicture(short num, String filename, int alignment,
				int inmethod, int inspeed, int outmethod, int outspeed,
				int stopmethod, int stopspeed, int stoptime); // stoptime单位为秒

		// 添加图片组的子图片 此函数要跟在AddWindows后面调用
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// str 文字字符串
		// fontname 字体名称
		// fontsize 字体大小
		// fontcolor 字体颜色
		// fontstyle 字体样式
		// 举例：=WFS_BOLD表示粗体；=WFS_ITALIC表示斜体；=WFS_BOLD+WFS_ITALIC表示粗斜体
		// wordwrap 是否自动换行 =1自动换行；=0不自动换行
		// inmethod 引入方式(下面有列表说明)
		// inspeed 引入速度(取值范围0-5，从快到慢)
		// outmethod 引出方式(下面有列表说明)
		// outspeed 引出速度(取值范围0-5，从快到慢)
		// stopmethod 停留方式(下面有列表说明)
		// stopspeed 停留速度(取值范围0-5，从快到慢)
		// stoptime 停留时间(单位毫秒)
		int AddChildText(short num, String str, String fontname, int fontsize,
				int fontcolor, int fontstyle, int wordwrap, int alignment,
				int inmethod, int inspeed, int outmethod, int outspeed,
				int stopmethod, int stopspeed, int stoptime); // stoptime单位为毫秒

		// 添加内码文字组播放
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// left、top、width、height 左、上、宽度、高度
		// transparent 是否透明 =1表示透明；=0表示不透明
		// border 流水边框(未实现)
		int AddStrings(short num, int left, int top, int width, int height,
				int transparent, int border);

		// 添加图片组的子图片 此函数要跟在AddWindows后面调用
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// str 文字字符串
		// fontset 字库 =FONTSET_16P表示16点阵字库；=FONTSET_24P表示24点阵字库
		// color 颜色
		// inmethod 引入方式(下面有列表说明)
		// inspeed 引入速度(取值范围0-5，从快到慢)
		// outmethod 引出方式(下面有列表说明)
		// outspeed 引出速度(取值范围0-5，从快到慢)
		// stopmethod 停留方式(下面有列表说明)
		// stopspeed 停留速度(取值范围0-5，从快到慢)
		// stoptime 停留时间(单位毫秒)
		int AddChildString(short num, String str, int fontset, int color,
				int inmethod, int inspeed, int outmethod, int outspeed,
				int stopmethod, int stopspeed, int stoptime); // stoptime单位为毫秒

		// 添加图片点阵播放
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// left、top、width、height 左、上、宽度、高度
		// transparent 是否透明 =1表示透明；=0表示不透明
		// border 流水边框(未实现)
		// dc 源图片DC句柄
		// src_width 图片宽度
		// src_height 图片高度
		// inmethod 引入方式(下面有列表说明)
		// inspeed 引入速度(取值范围0-5，从快到慢)
		// outmethod 引出方式(下面有列表说明)
		// outspeed 引出速度(取值范围0-5，从快到慢)
		// stopmethod 停留方式(下面有列表说明)
		// stopspeed 停留速度(取值范围0-5，从快到慢)
		// stoptime 停留时间(单位毫秒)
		// long (_stdcall *AddWindow)(WORD num, long left, long top, long width,
		// long height, long transparent, long border,
		// HDC dc, long src_width, long src_height, long alignment, long
		// inmethod, long inspeed, long outmethod, long outspeed, long
		// stopmethod, long stopspeed, long stoptime); //stoptime单位为毫秒

		// 添加图片文件播放
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// left、top、width、height 左、上、宽度、高度
		// transparent 是否透明 =1表示透明；=0表示不透明
		// border 流水边框(未实现)
		// filename 图片文件
		// inmethod 引入方式(下面有列表说明)
		// inspeed 引入速度(取值范围0-5，从快到慢)
		// outmethod 引出方式(下面有列表说明)
		// outspeed 引出速度(取值范围0-5，从快到慢)
		// stopmethod 停留方式(下面有列表说明)
		// stopspeed 停留速度(取值范围0-5，从快到慢)
		// stoptime 停留时间(单位毫秒)
		int AddPicture(short num, int left, int top, int width, int height,
				int transparent, int border, String filename, int alignment,
				int inmethod, int inspeed, int outmethod, int outspeed,
				int stopmethod, int stopspeed, int stoptime); // stoptime单位为毫秒

		// 添加文字播放
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// left、top、width、height 左、上、宽度、高度
		// transparent 是否透明 =1表示透明；=0表示不透明
		// border 流水边框(未实现)
		// str 文字字符串
		// fontname 字体名称
		// fontsize 字体大小
		// fontcolor 字体颜色
		// fontstyle 字体样式
		// 举例：=WFS_BOLD表示粗体；=WFS_ITALIC表示斜体；=WFS_BOLD+WFS_ITALIC表示粗斜体
		// wordwrap 是否自动换行 =1自动换行；=0不自动换行
		// inmethod 引入方式(下面有列表说明)
		// inspeed 引入速度(取值范围0-5，从快到慢)
		// outmethod 引出方式(下面有列表说明)
		// outspeed 引出速度(取值范围0-5，从快到慢)
		// stopmethod 停留方式(下面有列表说明)
		// stopspeed 停留速度(取值范围0-5，从快到慢)
		// stoptime 停留时间(单位毫秒)
		int AddText(short num, int left, int top, int width, int height,
				int transparent, int border, String str, String fontname,
				int fontsize, int fontcolor, int fontstyle, int wordwrap,
				int alignment, int inmethod, int inspeed, int outmethod,
				int outspeed, int stopmethod, int stopspeed, int stoptime); // stoptime单位为毫秒

		int AddTextEx4(short num, int left, int top, int width, int height,
				int transparent, int border, String str, int charset,
				String fontname, int fontsize, int fontcolor, int fontstyle,
				int bkcolor, int autofitsize, int wordwrap, int vertical,
				int alignment, int verticalspace, int horizontalfit,
				int inmethod, int inspeed, int outmethod, int outspeed,
				int stopmethod, int stopspeed, int stoptime); // stoptime单位为毫秒

		// 添加内码文字播放
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// left、top、width、height 左、上、宽度、高度
		// transparent 是否透明 =1表示透明；=0表示不透明
		// border 流水边框(未实现)
		// str 文字字符串
		// fontset 字库 =FONTSET_16P表示16点阵字库；=FONTSET_24P表示24点阵字库
		// color 颜色
		// inmethod 引入方式(下面有列表说明)
		// inspeed 引入速度(取值范围0-5，从快到慢)
		// outmethod 引出方式(下面有列表说明)
		// outspeed 引出速度(取值范围0-5，从快到慢)
		// stopmethod 停留方式(下面有列表说明)
		// stopspeed 停留速度(取值范围0-5，从快到慢)
		// stoptime 停留时间(单位毫秒)
		int AddString(short num, int left, int top, int width, int height,
				int transparent, int border, String str, int fontset,
				int color, int inmethod, int inspeed, int outmethod,
				int outspeed, int stopmethod, int stopspeed, int stoptime); // stoptime单位为毫秒

		// 添加表格
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// left、top、width、height 左、上、宽度、高度
		// transparent 是否透明 =1表示透明；=0表示不透明
		// profile 表格配置文件
		// content 表格内容，行之间以回车换行分割，列之间以'|'分割
		// inmethod 引入方式(下面有列表说明)
		// inspeed 引入速度(取值范围0-5，从快到慢)
		// outmethod 引出方式(下面有列表说明)
		// outspeed 引出速度(取值范围0-5，从快到慢)
		// stopmethod 停留方式(下面有列表说明)
		// stopspeed 停留速度(取值范围0-5，从快到慢)
		// stoptime 停留时间(单位毫秒)
		int AddTable(short num, int left, int top, int width, int height,
				int transparent, String profile, String content, int inmethod,
				int inspeed, int outmethod, int outspeed, int stopmethod,
				int stopspeed, int stoptime);

		// 添加Excel播放
		// num
		// 节目数据缓冲区编号，是MakeRoot、MakeChapter、MakeRegion、MakeLeaf、MakeObject的返回值
		// left、top、width、height 左、上、宽度、高度
		// transparent 是否透明 =1表示透明；=0表示不透明
		// border 流水边框(未实现)
		// filename Excel文件名
		// alignment 对齐方式
		// textcolor 文字颜色
		// bordercolor 表格线颜色
		// splitvalue 阈值
		// inmethod 引入方式(下面有列表说明)
		// inspeed 引入速度(取值范围0-5，从快到慢)
		// outmethod 引出方式(下面有列表说明)
		// outspeed 引出速度(取值范围0-5，从快到慢)
		// stopmethod 停留方式(下面有列表说明)
		// stopspeed 停留速度(取值范围0-5，从快到慢)
		// stoptime 停留时间(单位毫秒)
		int AddExcel(short num, int left, int top, int width, int height,
				int transparent, int border, String filename, int alignment,
				int textcolor, int bordercolor, int splitvalue, int inmethod,
				int inspeed, int outmethod, int outspeed, int stopmethod,
				int stopspeed, int stoptime);

		// ====引入动作方式列表(数值从0开始)====
		// 0 = '随机',
		// 1 = '立即显示',
		// 2 = '左滚显示',
		// 3 = '上滚显示',
		// 4 = '右滚显示',
		// 5 = '下滚显示',
		// 6 = '连续左滚显示',
		// 7 = '连续上滚显示',
		// 8 = '连续右滚',
		// 9 = '连续下滚',
		// 10 = '中间向上下展开',
		// 11 = '中间向两边展开',
		// 12 = '中间向四周展开',
		// 13 = '从右向左移入',
		// 14 = '从左向右移入',
		// 15 = '从左向右展开',
		// 16 = '从右向左展开',
		// 17 = '从右上角移入',
		// 18 = '从右下角移入',
		// 19 = '从左上角移入',
		// 20 = '从左下角移入',
		// 21 = '从上向下移入',
		// 22 = '从下向上移入',
		// 23 = '横向百叶窗',
		// 24 = '纵向百叶窗',
		// =====================================

		// ====引出动作方式列表(数值从0开始)====
		// 0 = '随机',
		// 1 = '不消失',
		// 2 = '立即消失',
		// 3 = '上下向中间合拢',
		// 4 = '两边向中间合拢',
		// 5 = '四周向中间合拢',
		// 6 = '从左向右移出',
		// 7 = '从右向左移出',
		// 8 = '从右向左合拢',
		// 9 = '从左向右合拢',
		// 10 = '从右上角移出',
		// 11 = '从右下角移出',
		// 12 = '从左上角移出',
		// 13 = '从左下角移出',
		// 14 = '从下向上移出',
		// 15 = '从上向下移出',
		// 16 = '横向百叶窗',
		// 17 = '纵向百叶窗'
		// =====================================

		// ====停留动作方式列表(数值从0开始)====
		// 0 = '静态显示',
		// 1 = '闪烁显示'
		// =====================================

		// 填写网络通讯参数，供发送时使用
		// index 参数数组编号
		// localport 本地端口
		// host 控制卡IP地址
		// remoteport 远程端口
		// address 控制卡地址
		// notifymode 通讯同步异步模式
		// wmhandle 接收消息窗体句柄
		// wmmessage 接收消息的消息号
		// --返回值-- 小于0表示失败，大于等于0表示参数的id号

	}

	private static final String demo_host = "192.168.1.99";
	private static final int demo_local_port = 9999;
	private static final int the_color_mode = LedControl.COLOR_MODE_DOUBLE;

	// 监听显示屏上报注册在线包
	public static void ListenReport(int r) {
		LedControl.INSTANCE.LED_Report_CreateServer(0, 8888);
		int devcount = 0;
		while (true) {
			devcount = LedControl.INSTANCE.LED_Report_GetOnlineList(0, null, 0);
			System.out.println("发送返回值devcount =" + devcount);
			for (int I = 0; I < devcount; I++) {
				String name = LedControl.INSTANCE.LED_Report_GetOnlineItemName(
						0, I);
				System.out.println("发送返回值name =" + name);
				String host = LedControl.INSTANCE.LED_Report_GetOnlineItemHost(
						0, I);
				System.out.println("发送返回值host =" + host);
				int port = LedControl.INSTANCE.LED_Report_GetOnlineItemPort(0,
						I);
				System.out.println("发送返回值port =" + port);
				int addr = LedControl.INSTANCE.LED_Report_GetOnlineItemAddr(0,
						I);
				System.out.println("发送返回值addr =" + addr);
			}
			if (devcount > 0)
				break;
		}
		LedControl.INSTANCE.LED_Report_RemoveServer(0);
	}

	// 命令执行结果解析
	public static void parse(int r) {

		// LED_SendToScreen2的返回值为R_DEVICE_READY，表示进入了发送过程
		System.out.println(r);
		if (r == LedControl.R_DEVICE_READY) {
			System.out.println("正在发送节目或者执行命令...");
			// 查询发送的结果
			while (true) {
				//Thread.sleep(50);
				int notify = LedControl.INSTANCE.LED_GetNotifyParam_Notify(r);
				if (notify == LedControl.LM_TIMEOUT) {
					System.out.println("发送节目或者执行命令超时");
					break;
				} else if (notify == LedControl.LM_TX_COMPLETE) {
					int result = LedControl.INSTANCE
							.LED_GetNotifyParam_Result(r);
					if (result == LedControl.RESULT_FLASH) {
						System.out.println("发送节目或者执行命令完成，正在写入Flash");
					} else {
						System.out.println("发送节目或者执行命令完成");
						break;
					}
				} else if (notify == LedControl.LM_RESPOND) {
					int command = LedControl.INSTANCE
							.LED_GetNotifyParam_Command(r);
					if (command == LedControl.PKC_GET_POWER) {
						int status = LedControl.INSTANCE
								.LED_GetNotifyParam_Status(r);
						if (status == 1) {
							System.out.println("读取电源完成，当前电源状态为开启");
						} else {
							System.out.println("读取电源完成，当前电源状态为关闭");
						}
						break;
					} else if (command == LedControl.PKC_SET_POWER) {
						int status = LedControl.INSTANCE
								.LED_GetNotifyParam_Status(r);
						if (status == 1) {
							System.out.println("设置电源完成，当前电源状态为开启");
						} else {
							System.out.println("设置电源完成，当前电源状态为关闭");
						}
						break;
					} else if (command == LedControl.PKC_GET_BRIGHT) {
						int status = LedControl.INSTANCE
								.LED_GetNotifyParam_Status(r);
						System.out.println("读取亮度完成，当前亮度为" + status);
						break;
					} else if (command == LedControl.PKC_SET_BRIGHT) {
						int status = LedControl.INSTANCE
								.LED_GetNotifyParam_Status(r);
						System.out.println("设置亮度完成，当前亮度为" + status);
						break;
					} else if (command == LedControl.PKC_ADJUST_TIME) {
						System.out.println("校正时间完成");
						break;
					}
				} else if (notify == LedControl.LM_NOTIFY) {
					int result = LedControl.INSTANCE
							.LED_GetNotifyParam_Result(r);
					if (result == LedControl.NOTIFY_GET_PLAY_BUFFER) {
						LedControl.INSTANCE.LED_GetNotifyParam_Buffer(
								"preview.dat", r);
						LedControl.INSTANCE.LED_PreviewFile_Export(
								"SimuLED.exe", 320, 192, 1, "C:\\preview.bmp");
						LedControl.INSTANCE.LED_PreviewFileEx("SimuLED.exe",
								320, 192, "preview.dat");
						System.out.println("读取控制卡内播放内容完成");
						break;
					} else if (result == LedControl.NOTIFY_SET_PARAM) {
						System.out.println("设置控制卡参数完成");
						break;
					}
				}
			}
		} else if (r == LedControl.R_DEVICE_INVALID) {
			System.out.println("打开通讯端口失败");
		} else if (r == LedControl.R_DEVICE_BUSY) {
			System.out.println("该通讯 端口忙，正在发送节目或者执行命令");
		}
	}

	// 打开电源
	public static void demo_power_on() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);
		int r = LedControl.INSTANCE.LED_SetPower2(dev, LedControl.POWER_ON);
		parse(r);
	}

	// 关闭电源
	public static void demo_power_off() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);
		int r = LedControl.INSTANCE.LED_SetPower2(dev, LedControl.POWER_OFF);
		parse(r);
	}

	// 校正时间
	public static void demo_adjust_time() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);
		int r = LedControl.INSTANCE.LED_AdjustTime2(dev);
		parse(r);
	}

	// 设置控制卡IP地址
	public static void demo_set_ip() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);
		int r = LedControl.INSTANCE.LED_Cache_GetBoardParam2(dev);
		if (r >= 0) {
			LedControl.INSTANCE.LED_Cache_SetBoardParam_IP("192.168.0.99");
			r = LedControl.INSTANCE.LED_Cache_SetBoardParam2(dev);
			parse(r);
		}
	}

	// 回读控制卡节目
	public static void demo_get_play_content() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);
		int r = LedControl.INSTANCE.LED_GetPlayContent2(dev);
		parse(r);
	}

	public static void demo_preview_file() {
		LedControl.INSTANCE.LED_PreviewFile_Export("SimuLED.exe", 320, 192, 0,
				"preview.dat");
		LedControl.INSTANCE.LED_PreviewFileEx("SimuLED.exe", 320, 192,
				"preview.dat");
	}

	// 图片文件发送例程
	public static void demo_picture() {
		int k;
		// wmhandle参数需要传-1，表示返回结果写入wmmessage指定的单元内
		// wmmessage参数传入返回结果数组编号，用于查询返回结果。（LED_SendToScreen2的返回值会返回wmmessage传入的值）
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 4, -1, 0);

		k = LedControl.INSTANCE.MakeRoot(LedControl.ROOT_PLAY, the_color_mode,
				-1); // -1表示节目始终播放
		LedControl.INSTANCE.AddChapter((short) k, 30000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddRegion((short) k, 0, 0, 64, 32, 0);

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		// 注意，如果图片文件发送不上屏，请使用绝对路径，例如"D:\\Test\\Demo.bmp"
		LedControl.INSTANCE.AddPicture((short) k, 0, 0, 64, 32, 1, 0,
				"Demo.bmp", 0, 0, 5, 2, 5, 0, 5, 3000); // stoptime单位为毫秒

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// Excel文件发送例程
	public static void demo_excel() {
		int k;
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 4, -1, 0);

		k = LedControl.INSTANCE.MakeRoot(LedControl.ROOT_PLAY, the_color_mode,
				-1); // -1表示节目始终播放
		LedControl.INSTANCE.AddChapter((short) k, 30000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddRegion((short) k, 0, 0, 64, 32, 0);

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddExcel((short) k, 0, 0, 96, 24, 1, 0,
				"D:\\YUJIANG\\VS2010\\D7_SDK\\JavaDemo\\Demo.xls", 0, 0xFF,
				0xFF00, 192, 0, 5, 2, 5, 0, 5, 3000);

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddExcel((short) k, 0, 0, 96, 24, 1, 0,
				"D:\\YUJIANG\\VS2010\\D7_SDK\\JavaDemo\\Demo2.xls", 0, 0xFF,
				0xFF00, 192, 0, 5, 2, 5, 0, 5, 3000);

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// 节目发送例程，里面包含如何添加文字、日期时间、图片
	public static void demo_send() {
		int k;
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 4, -1, 0);

		k = LedControl.INSTANCE.MakeRoot(LedControl.ROOT_PLAY, the_color_mode,
				-1); // -1表示节目始终播放
		LedControl.INSTANCE.AddChapter((short) k, 30000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddRegion((short) k, 0, 0, 64, 32, 0);

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		// LedControl.INSTANCE.AddDateTime((short) k, 0, 0, 96, 24, 1, 0, "宋体",
		// 12, 0xFFFF, 0x0, 0, 0, 0, 0, "#h:#n:#s");
		LedControl.INSTANCE.AddText((short) k, 0, 0, 96, 24, 1, 0,
				"显示屏测试。\r\nHello world.", "宋体", 24, 0xFFFF, 0x0, 1, 0, 1, 5, 2,
				5, 0, 5, 3000); // stoptime单位为毫秒

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// 旋转节目发送例程
	public static void demo_rotate_send() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		// rotate 旋转方式：=0不旋转 =1逆时针旋转90度 =2顺时针旋转90度
		// width 显示屏宽度(旋转后)
		// height 显示屏高度(旋转后)
		// LedControl.INSTANCE.SetRotate(1, 32, 64);

		int k = LedControl.INSTANCE.MakeRootEx(LedControl.ROOT_PLAY,
				the_color_mode, -1, 1, 32, 64); // -1表示节目始终播放
		// int k = LedControl.INSTANCE.MakeRoot(LedControl.ROOT_PLAY,
		// the_color_mode, -1); //-1表示节目始终播放
		LedControl.INSTANCE.AddChapter((short) k, 30000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddRegion((short) k, 0, 0, 32, 64, 0);

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddDateTimeEx((short) k, 0, 0, 32, 16, 1, 0, 0,
				"宋体", 12, 0xFFFF, 0x0, 0, 0, 0, 0, "#y年#m月#d日");
		LedControl.INSTANCE.AddDateTimeEx((short) k, 0, 16, 32, 16, 1, 0, 0,
				"宋体", 12, 0xFFFF, 0x0, 0, 0, 0, 0, "#h:#n:#s");

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddTextEx4((short) k, 0, 0, 32, 16, 1, 0, "显示屏测试。",
				0, "宋体", 12, 0xFFFF, 0x0, 0, 0, 1, 0, 0, 0, 0, 0, 5, 2, 5, 0,
				5, 3000); // stoptime单位为毫秒

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddPicture((short) k, 0, 0, 32, 32, 1, 0,
				"Demo.bmp", 0, 0, 5, 2, 5, 0, 5, 3000); // stoptime单位为毫秒

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// 节目播放计划例子
	public static void demo_chapter_schedule() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		int k = LedControl.INSTANCE.MakeRoot(LedControl.ROOT_PLAY,
				the_color_mode, -1); // -1表示节目始终播放
		LedControl.INSTANCE.AddChapterEx2((short) k, 30000,
				(short) LedControl.MODE_WAIT_CHILD, (short) 0, (short) 1,
				(short) 0x7F, "08:00:00", "17:00:00");
		LedControl.INSTANCE.AddRegion((short) k, 0, 0, 96, 24, 0);

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddText((short) k, 0, 0, 96, 24, 1, 0,
				"显示屏测试。\r\nHello world.", "宋体", 24, 0xFFFF, 0x0, 1, 0, 0, 5, 2,
				5, 0, 5, 3000); // stoptime单位为毫秒

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// 局部更新例程：只更新一个节目
	public static void demo_chapter_modify() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		// 更新第1个节目
		int k = LedControl.INSTANCE.MakeChapter(LedControl.ROOT_PLAY_CHAPTER,
				LedControl.MODE_REPLACE, 0, the_color_mode, 30000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddRegion((short) k, 0, 0, 96, 24, 0);
		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddText((short) k, 0, 0, 96, 24, 1, 0,
				"显示屏测试。\r\nHello world.", "宋体", 24, 0xFFFF, 0x0, 1, 0, 0, 5, 2,
				5, 0, 5, 3000); // stoptime单位为毫秒

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// 局部更新例程：只更新一个分区
	public static void demo_region_modify() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		// 更新第1个节目里的第1个分区
		int k = LedControl.INSTANCE
				.MakeRegion(LedControl.ROOT_PLAY_REGION,
						LedControl.MODE_REPLACE, 0, 0, the_color_mode, 0, 0,
						128, 32, 0);
		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddText((short) k, 0, 0, 64, 32, 1, 0,
				"显示屏测试。\r\nHello world.", "宋体", 12, 0xFFFF, 0x0, 1, 0, 0, 5, 2,
				5, 0, 5, 3000); // stoptime单位为毫秒

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// 局部更新例程：只更新一个页面
	public static void demo_leaf_modify() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		// 更新第1个节目里的第1个分区里的第1个页面
		int k = LedControl.INSTANCE.MakeLeaf(LedControl.ROOT_PLAY_LEAF,
				LedControl.MODE_REPLACE, 0, 0, 0, the_color_mode, 5000,
				LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddText((short) k, 0, 0, 96, 24, 1, 0,
				"显示屏测试。\r\nHello world.", "宋体", 24, 0xFFFF, 0x0, 1, 0, 0, 5, 2,
				5, 0, 5, 3000); // stoptime单位为毫秒

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// 局部更新例程：只更新一个对象
	public static void demo_object_modify() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		// 更新第1个节目里的第1个分区里的第1个页面
		int k = LedControl.INSTANCE.MakeObject(LedControl.ROOT_PLAY_OBJECT,
				LedControl.MODE_REPLACE, 0, 0, 0, 0, the_color_mode);
		LedControl.INSTANCE.AddText((short) k, 0, 0, 64, 16, 1, 0, "显示屏测试。",
				"宋体", 12, 0xFFFF, 0x0, 1, 0, 0, 5, 2, 5, 0, 5, 3000); // stoptime单位为毫秒

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	public static void main(String[] args) {

		// TODO Auto-generated method stub
		System.out.println("程序启动");

		// demo_picture(); // 关于结果查询，请进入demo_picture函数的定义，里面有相关注释。
		 demo_excel();
		// demo_power_on();
		// demo_send();

		// demo_chapter_schedule();
		// demo_region_modify();
		// demo_object_modify();
		// demo_get_play_content();
		// demo_preview_file();

		// demo_set_ip();
		// demo_rotate_send();

		// 此句，只能在整个程序退出时，调用1次。不能在程序中多次调用。
		LedControl.INSTANCE.LED_Cleanup();
		System.out.println("程序退出");
	}

}
