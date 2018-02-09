import com.sun.jna.Library;
import com.sun.jna.Native;

//import com.sun.jna.win32.*;

public class SetCurChapterDemo {
	public interface LedControl extends Library {

		// 当前路径是在项目下，而不是bin输出目录下。
		LedControl INSTANCE = (LedControl) Native.loadLibrary("LEDSender2010",
				LedControl.class);

		// 发送和执行命令错误代码
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
		public static final int PKC_SET_CURRENT_CHAPTER = 66;

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

		// 获取控制卡应答结果的数据
		int LED_GetNotifyParam_Notify(int index);

		int LED_GetNotifyParam_Command(int index);

		int LED_GetNotifyParam_Result(int index);

		int LED_GetNotifyParam_Status(int index);

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

		// 生成节目数据，后续需要调用[AddRegion]->[AddLeaf]->[AddObject]->[AddWindows/AddDateTime等]
		// RootType 必须设为ROOT_PLAY_CHAPTER
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

		// ====引入动作方式列表(数值从0开始)====
		// 0 = '随机',
		// 1 = '立即显示',
		// 2 = '左滚显示',
		// 3 = '上滚显示',
		// 4 = '右滚显示',
		// 5 = '下滚显示',
		// 6 = '连续左滚显示',
		// 7 = '连续下滚显示',
		// 8 = '中间向上下展开',
		// 9 = '中间向两边展开',
		// 10 = '中间向四周展开',
		// 11 = '从右向左移入',
		// 12 = '从左向右移入',
		// 13 = '从左向右展开',
		// 14 = '从右向左展开',
		// 15 = '从右上角移入',
		// 16 = '从右下角移入',
		// 17 = '从左上角移入',
		// 18 = '从左下角移入',
		// 19 = '从上向下移入',
		// 20 = '从下向上移入',
		// 21 = '横向百叶窗',
		// 22 = '纵向百叶窗',
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

	public static void parse_res(int r) {
		if (r >= 0) {
			int notify = LedControl.INSTANCE.LED_GetNotifyParam_Notify(r);
			if (notify == LedControl.LM_TIMEOUT) {
				System.out.println("发送节目或者执行命令超时");
			} else if (notify == LedControl.LM_TX_COMPLETE) {
				int result = LedControl.INSTANCE.LED_GetNotifyParam_Result(r);
				if (result == LedControl.RESULT_FLASH) {
					System.out.println("发送节目或者执行命令完成，正在写入Flash");
				} else {
					System.out.println("发送节目或者执行命令完成");
				}
			} else if (notify == LedControl.LM_RESPOND) {
				int command = LedControl.INSTANCE.LED_GetNotifyParam_Command(r);
				if (command == LedControl.PKC_GET_POWER) {
					int status = LedControl.INSTANCE
							.LED_GetNotifyParam_Status(r);
					if (status == 1) {
						System.out.println("读取电源完成，当前电源状态为开启");
					} else {
						System.out.println("读取电源完成，当前电源状态为关闭");
					}
				} else if (command == LedControl.PKC_SET_POWER) {
					int status = LedControl.INSTANCE
							.LED_GetNotifyParam_Status(r);
					if (status == 1) {
						System.out.println("设置电源完成，当前电源状态为开启");
					} else {
						System.out.println("设置电源完成，当前电源状态为关闭");
					}
				} else if (command == LedControl.PKC_GET_BRIGHT) {
					int status = LedControl.INSTANCE
							.LED_GetNotifyParam_Status(r);
					System.out.println("读取亮度完成，当前亮度为" + status);
				} else if (command == LedControl.PKC_SET_BRIGHT) {
					int status = LedControl.INSTANCE
							.LED_GetNotifyParam_Status(r);
					System.out.println("设置亮度完成，当前亮度为" + status);
				} else if (command == LedControl.PKC_ADJUST_TIME) {
					System.out.println("校正时间完成");
				} else if (command == LedControl.PKC_SET_CURRENT_CHAPTER) {
					System.out.println("设置当前播放节目完成");
				}
			} else if (notify == LedControl.LM_NOTIFY) {

			}
		} else if (r == LedControl.R_DEVICE_INVALID) {
			System.out.println("打开通讯端口失败");
		} else if (r == LedControl.R_DEVICE_BUSY) {
			System.out.println("该通讯 端口忙，正在发送节目或者执行命令");
		}
	}

	public static void main(String[] args) {

		// TODO Auto-generated method stub

		int s = LedControl.INSTANCE.LED_UDP_SenderParam(0, 9999,
				"192.168.1.95", 6666, 0, 2, 0, 0);
		System.out.println("发送返回值s = " + s);

		int r;
		if (s >= 0) {
			System.out.println("正在设置当前播放节目，编号为" + 2);
			r = LedControl.INSTANCE.LED_SetCurChapter2(s, 2);
			parse_res(r);
		}

		LedControl.INSTANCE.LED_Cleanup();
		System.out.println("运行结束!");

	}
}
