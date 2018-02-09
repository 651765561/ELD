import com.sun.jna.Library;
import com.sun.jna.Native;

//import com.sun.jna.win32.*;

public class SetCurChapterDemo {
	public interface LedControl extends Library {

		// ��ǰ·��������Ŀ�£�������bin���Ŀ¼�¡�
		LedControl INSTANCE = (LedControl) Native.loadLibrary("LEDSender2010",
				LedControl.class);

		// ���ͺ�ִ������������
		public static final int R_DEVICE_INVALID = -1;
		public static final int R_DEVICE_BUSY = -2;

		// ���ͺ�ִ������Ӧ�����
		public static final int LM_RX_COMPLETE = 1;
		public static final int LM_TX_COMPLETE = 2;
		public static final int LM_RESPOND = 3;
		public static final int LM_TIMEOUT = 4;
		public static final int LM_NOTIFY = 5;
		public static final int RESULT_FLASH = 0xff;

		// ������붨��
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

		// �������ƿ����߼�������
		// serverindex ���ƿ����߼���������(�����ڶ��socket udp�˿ڼ���)
		// localport ���ض˿�
		int LED_Report_CreateServer(int serverindex, int localport);

		// ɾ�����ƿ����߼�������
		// serverindex ���ƿ����߼���������
		int LED_Report_RemoveServer(int serverindex);

		// ɾ��ȫ�����ƿ����߼�������
		int LED_Report_RemoveAllServer();

		// ��ÿ��ƿ������б�
		// �����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
		// serverindex ���ƿ����߼���������
		// plist ��������б���û��ⲿ��������void* ��Ӧʲô���ͣ�
		// ��������(NULL/0)�����������̬���ӿ��ڲ��Ļ�������������������Ľӿ�ȡ����ϸ��Ϣ
		// count ����ȡ����
		// --����ֵ-- С��0��ʾʧ��(δ���������߼�������)�����ڵ���0��ʾ���ߵĿ��ƿ�����
		int LED_Report_GetOnlineList(int serverindex, String plist, int count);

		// ���ĳ�����߿��ƿ����ϱ����ƿ�����
		// �����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
		// serverindex ���ƿ����߼���������
		// itemindex �ü�������������б��У����߿��ƿ��ı��
		// --����ֵ-- ���߿��ƿ����ϱ����ƿ�����
		String LED_Report_GetOnlineItemName(int serverindex, int itemindex);

		// ���ĳ�����߿��ƿ����ϱ����ƿ�IP��ַ
		// �����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
		// serverindex ���ƿ����߼���������
		// itemindex �ü�������������б��У����߿��ƿ��ı��
		// --����ֵ-- ���߿��ƿ���IP��ַ
		String LED_Report_GetOnlineItemHost(int serverindex, int itemindex);

		// ���ĳ�����߿��ƿ����ϱ����ƿ�Զ��UDP�˿ں�
		// �����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
		// serverindex ���ƿ����߼���������
		// itemindex �ü�������������б��У����߿��ƿ��ı��
		// --����ֵ-- ���߿��ƿ���Զ��UDP�˿ں�
		int LED_Report_GetOnlineItemPort(int serverindex, int itemindex);

		// ���ĳ�����߿��ƿ����ϱ����ƿ���ַ
		// �����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
		// serverindex ���ƿ����߼���������
		// itemindex �ü�������������б��У����߿��ƿ��ı��
		// --����ֵ-- ���߿��ƿ���Ӳ����ַ
		int LED_Report_GetOnlineItemAddr(int serverindex, int itemindex);

		// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/************************************************************************/
		/* ��дͨѶ�����ӿں���������һЩ�޷����ݽṹ���ָ��Ŀ������������� */
		/************************************************************************/

		// ��д����ͨѶ������������ʱʹ��
		// index ����������
		// localport ���ض˿�
		// host ���ƿ�IP��ַ
		// remoteport Զ�̶˿�
		// address ���ƿ���ַ
		// notifymode ͨѶͬ���첽ģʽ
		// wmhandle ������Ϣ������
		// wmmessage ������Ϣ����Ϣ��
		// --����ֵ-- С��0��ʾʧ�ܣ����ڵ���0��ʾ������id��
		int LED_UDP_SenderParam(int index, int localport, String host,
				int remoteport, int address, int notifymode, int wmhandle,
				int wmmessage);

		// ��д����ͨѶ������������ʱʹ��
		// index ����������
		// comport ���ں�
		// baudrate ������
		// address ���ƿ���ַ
		// notifymode ͨѶͬ���첽ģʽ
		// wmhandle ������Ϣ������
		// wmmessage ������Ϣ����Ϣ��
		// --����ֵ-- С��0��ʾʧ�ܣ����ڵ���0��ʾ������id��
		int LED_COM_SenderParam(int index, int comport, int baudrate,
				int address, int notifymode, int wmhandle, int wmmessage);

		// ��д����ͨѶ������������ʱʹ��
		// index ����������
		// localport ���ض˿�
		// serverindex ���߼���������
		// name ���ƿ�����(���ƿ��ϱ���������)
		// notifymode ͨѶͬ���첽ģʽ
		// wmhandle ������Ϣ������
		// wmmessage ������Ϣ����Ϣ��
		// --����ֵ-- С��0��ʾʧ�ܣ����ڵ���0��ʾ������id��
		int LED_UDP_SenderParam_ByReportName(int index, int localport,
				int serverindex, String name, int notifymode, int wmhandle,
				int wmmessage);

		// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// ��̬���ӿ�����
		// *ע�⣺�˺���ֻ�������������˳�ʱ������һ�Ρ������й����У����ܵ��á�
		void LED_Cleanup();

		// ���ÿ��ƿ���Դ value=LED_POWER_ON��ʾ������Դ value=LED_POWER_OFF��ʾ�رյ�Դ
		int LED_SetPower2(int senderparam_index, int power);

		// ��ȡ���ƿ���Դ״̬
		int LED_GetPower2(int senderparam_index);

		// ���ÿ��ƿ����� valueȡֵ��Χ0-7
		int LED_SetBright2(int senderparam_index, int value);

		// ��ȡ���ƿ�����
		int LED_GetBright2(int senderparam_index);

		// ��λ���ƿ���Ŀ���ţ�������ʾ���ƿ�Flash�д洢�Ľ�Ŀ
		int LED_ResetDisplay2(int senderparam_index);

		// У��ʱ�䣬�Ե�ǰ�������ϵͳʱ��У�����ƿ���ʱ��
		int LED_AdjustTime2(int senderparam_index);

		// У��ʱ����չ����ָ����ʱ��У�����ƿ���ʱ��
		int LED_AdjustTimeEx2(int senderparam_index, int year, int month,
				int day, int hour, int minute, int second);

		// ���õ�ǰ��ʾ�Ľ�Ŀ
		int LED_SetCurChapter2(int senderparam_index, int value);

		// ���ÿ��ƿ��Ķ�ʱ�������ƻ�
		// eanbled: =0��ʾ���ö�ʱ���������� =1��ʾ���ö�ʱ����������
		// mode: =0��ʾһ�����쿪�����ƻ� =1��ʾ����ʱ�䶨ʱ�������ƻ�
		// AOpenTX, ACloseTX: ������ʱ�䡣
		// ��mode=0ʱ��ÿ�����ʾһ�������������ʱ�䣬һ��7�죬��21��
		// ��mode=1ʱ��21�鿪��������ʱ��
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

		// ��ȡ���ƿ��Ķ�ʱ�������ƻ�
		int LED_GetPowerSchedule2(int senderparam_index);

		// ���ÿ��ƿ��Ķ�ʱ���ȵ��ڼƻ�
		int LED_GetBrightSchedule2(int senderparam_index);

		// ���ͽ�Ŀ����
		// indexΪMakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�����ķ���ֵ
		int LED_SendToScreen2(int senderparam_index, int index);

		// ��ȡ���ƿ�Ӧ����������
		int LED_GetNotifyParam_Notify(int index);

		int LED_GetNotifyParam_Command(int index);

		int LED_GetNotifyParam_Result(int index);

		int LED_GetNotifyParam_Status(int index);

		// ���ɲ������ݣ���VS2010����༭��Vsq�ļ����룬������Ҫ�·��Ľ�Ŀ���ݣ�
		// RootType
		// Ϊ�������ͣ�=ROOT_PLAY��ʾ���¿��ƿ�RAM�еĽ�Ŀ(���綪ʧ)��=ROOT_DOWNLOAD��ʾ���¿��ƿ�Flash�еĽ�Ŀ(���粻��ʧ)
		// ColorMode Ϊ��ɫģʽ��ȡֵΪCOLOR_MODE_MONO����COLOR
		// survive ΪRAM��Ŀ����ʱ�䣬��RootType=ROOT_PLAYʱ��Ч����RAM��Ŀ���Ŵﵽʱ��󣬻ָ���ʾFLASH�еĽ�Ŀ
		// survive=ROOT_SURVIVE_ALWAYS
		// filename ��VisionShow����༭�Ľ�Ŀ�ļ�
		int MakeFromVsqFile(String filename, int RootType, int ColorMode,
				int survive);

		// ���ɲ�������
		// RootType
		// Ϊ�������ͣ�=ROOT_PLAY��ʾ���¿��ƿ�RAM�еĽ�Ŀ(���綪ʧ)��=ROOT_DOWNLOAD��ʾ���¿��ƿ�Flash�еĽ�Ŀ(���粻��ʧ)
		// ColorMode Ϊ��ɫģʽ��ȡֵΪCOLOR_MODE_MONO����COLOR
		// survive ΪRAM��Ŀ����ʱ�䣬��RootType=ROOT_PLAYʱ��Ч����RAM��Ŀ���Ŵﵽʱ��󣬻ָ���ʾFLASH�еĽ�Ŀ
		// survive = ROOT_SURVIVE_ALWAYS
		int MakeRoot(int RootType, int ColorMode, int survive);

		// ���ɽ�Ŀ���ݣ�������Ҫ����[AddRegion]->[AddLeaf]->[AddObject]->[AddWindows/AddDateTime��]
		// RootType ������ΪROOT_PLAY_CHAPTER
		// ActionMode ������Ϊ0
		// ChapterIndex Ҫ���µĽ�Ŀ���
		// ColorMode ͬMakeRoot�еĶ���
		// time ���ŵ�ʱ�䳤��
		// wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
		// =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
		int MakeChapter(int RootType, int ActionMode, int ChapterIndex,
				int ColorMode, int time, int wait);

		// ���ɷ�����������Ҫ����[AddLeaf]->[AddObject]->[AddWindows/AddDateTime��]
		// RootType ������ΪROOT_PLAY_REGION
		// ActionMode ������Ϊ0
		// ChapterIndex Ҫ���µĽ�Ŀ���
		// RegionIndex Ҫ���µķ������
		// ColorMode ͬMakeRoot�еĶ���
		// left��top��width��height ���ϡ���ȡ��߶�
		// border ��ˮ�߿�
		int MakeRegion(int RootType, int ActionMode, int ChapterIndex,
				int RegionIndex, int ColorMode, int left, int top, int width,
				int height, int border);

		// ����ҳ�棬������Ҫ����[AddObject]->[AddWindows/AddDateTime��]
		// RootType ������ΪROOT_PLAY_LEAF
		// ActionMode ������Ϊ0
		// ChapterIndex Ҫ���µĽ�Ŀ���
		// RegionIndex Ҫ���µķ������
		// LeafIndex Ҫ���µ�ҳ�����
		// ColorMode ͬMakeRoot�еĶ���
		// time ���ŵ�ʱ�䳤��
		// wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
		// =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һҳ��
		int MakeLeaf(int RootType, int ActionMode, int ChapterIndex,
				int RegionIndex, int LeafIndex, int ColorMode, int time,
				int wait);

		// ���ɲ��Ŷ��󣬺�����Ҫ����[AddWindows/AddDateTime��]
		// RootType ������ΪROOT_PLAY_LEAF
		// ActionMode ������Ϊ0
		// ChapterIndex Ҫ���µĽ�Ŀ���
		// RegionIndex Ҫ���µķ������
		// LeafIndex Ҫ���µ�ҳ�����
		// ObjectIndex Ҫ���µĶ������
		// ColorMode ͬMakeRoot�еĶ���
		int MakeObject(int RootType, int ActionMode, int ChapterIndex,
				int RegionIndex, int LeafIndex, int ObjectIndex, int ColorMode);

		// ��ӽ�Ŀ
		// num ��Ŀ���ݻ�������ţ���MakeRoot�ķ���ֵ
		// time ���ŵ�ʱ�䳤��
		// wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
		// =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
		int AddChapter(short num, int time, short wait);// timeΪ����

		// ��ӷ���
		// num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// border ��ˮ�߿�
		int AddRegion(short num, int left, int top, int width, int height,
				int border);

		// ���ҳ��
		// num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion�ķ���ֵ
		// time ���ŵ�ʱ�䳤��
		// wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
		// =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һҳ��
		int AddLeaf(short num, int time, short wait);// timeΪ����

		// �������ʱ����ʾ
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
		// border ��ˮ�߿�(δʵ��)
		// fontname ��������
		// fontsize �����С
		// fontcolor ������ɫ
		// fontstyle ������ʽ
		// ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
		// year_offset ��ƫ����
		// month_offset ��ƫ����
		// day_offset ��ƫ����
		// sec_offset ��ƫ����
		// format ��ʾ��ʽ
		// #y��ʾ�� #m��ʾ�� #d��ʾ�� #h��ʾʱ #n��ʾ�� #s��ʾ�� #w��ʾ���� #c��ʾũ��
		// ������
		// format="#y��#m��#d�� #hʱ#n��#s�� ����#w ũ��#c"ʱ����ʾΪ"2009��06��27�� 12ʱ38��45�� ������ ũ�����³���"
		int AddDateTime(short num, int left, int top, int width, int height,
				int transparent, int border, String fontname, int fontsize,
				int fontcolor, int fontstyle, int year_offset,
				int month_offset, int day_offset, int sec_offset, String format);

		// ���ģ��ʱ��
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
		// border ��ˮ�߿�(δʵ��)
		// offset ��ƫ����
		// bkcolor: ������ɫ
		// framecolor: �����ɫ
		// framewidth: �����ɫ
		// frameshape: �����״ =0��ʾ�����Σ�=1��ʾԲ�Ƿ��Σ�=2��ʾԲ��
		// dotradius: �̶Ⱦ���������İ뾶
		// adotwidth: 0369��̶ȴ�С
		// adotcolor: 0369��̶���ɫ
		// bdotwidth: ������̶ȴ�С
		// bdotcolor: ������̶���ɫ
		// hourwidth: ʱ���ϸ
		// hourcolor: ʱ����ɫ
		// minutewidth: �����ϸ
		// minutecolor: ������ɫ
		// secondwidth: �����ϸ
		// secondcolor: ������ɫ
		int AddClock(short num, int left, int top, int width, int height,
				int transparent, int border, int offset, short bkcolor,
				short framecolor, short framewidth, int frameshape,
				int dotradius, int adotwidth, short adotcolor, int bdotwidth,
				short bdotcolor, int hourwidth, short hourcolor,
				int minutewidth, short minutecolor, int secondwidth,
				short secondcolor);

		// ��Ӷ���
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
		// border ��ˮ�߿�(δʵ��)
		// filename avi�ļ���
		// stretch: ͼ���Ƿ���������Ӧ�����С
		int AddMovie(short num, int left, int top, int width, int height,
				int transparent, int border, String filename, int stretch);

		// ���ͼƬ�鲥��
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
		// border ��ˮ�߿�(δʵ��)
		int AddWindows(short num, int left, int top, int width, int height,
				int transparent, int border);

		// ���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// dc ԴͼƬDC���
		// width ͼƬ���
		// height ͼƬ�߶�
		// inmethod ���뷽ʽ(�������б�˵��)
		// inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// outmethod ������ʽ(�������б�˵��)
		// outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stopmethod ͣ����ʽ(�������б�˵��)
		// stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stoptime ͣ��ʱ��(��λ����)
		// -------long (_stdcall *AddChildWindow)(WORD num, HDC dc, long width,
		// long height, long alignment, long inmethod, long inspeed, long
		// outmethod, long outspeed, long stopmethod, long stopspeed, long
		// stoptime); //stoptime��λΪ��

		// ���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// filename ͼƬ�ļ���
		// inmethod ���뷽ʽ(�������б�˵��)
		// inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// outmethod ������ʽ(�������б�˵��)
		// outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stopmethod ͣ����ʽ(�������б�˵��)
		// stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stoptime ͣ��ʱ��(��λ����)
		int AddChildPicture(short num, String filename, int alignment,
				int inmethod, int inspeed, int outmethod, int outspeed,
				int stopmethod, int stopspeed, int stoptime); // stoptime��λΪ��

		// ���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// str �����ַ���
		// fontname ��������
		// fontsize �����С
		// fontcolor ������ɫ
		// fontstyle ������ʽ
		// ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
		// wordwrap �Ƿ��Զ����� =1�Զ����У�=0���Զ�����
		// inmethod ���뷽ʽ(�������б�˵��)
		// inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// outmethod ������ʽ(�������б�˵��)
		// outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stopmethod ͣ����ʽ(�������б�˵��)
		// stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stoptime ͣ��ʱ��(��λ����)
		int AddChildText(short num, String str, String fontname, int fontsize,
				int fontcolor, int fontstyle, int wordwrap, int alignment,
				int inmethod, int inspeed, int outmethod, int outspeed,
				int stopmethod, int stopspeed, int stoptime); // stoptime��λΪ����

		// ������������鲥��
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
		// border ��ˮ�߿�(δʵ��)
		int AddStrings(short num, int left, int top, int width, int height,
				int transparent, int border);

		// ���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// str �����ַ���
		// fontset �ֿ� =FONTSET_16P��ʾ16�����ֿ⣻=FONTSET_24P��ʾ24�����ֿ�
		// color ��ɫ
		// inmethod ���뷽ʽ(�������б�˵��)
		// inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// outmethod ������ʽ(�������б�˵��)
		// outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stopmethod ͣ����ʽ(�������б�˵��)
		// stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stoptime ͣ��ʱ��(��λ����)
		int AddChildString(short num, String str, int fontset, int color,
				int inmethod, int inspeed, int outmethod, int outspeed,
				int stopmethod, int stopspeed, int stoptime); // stoptime��λΪ����

		// ���ͼƬ���󲥷�
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
		// border ��ˮ�߿�(δʵ��)
		// dc ԴͼƬDC���
		// src_width ͼƬ���
		// src_height ͼƬ�߶�
		// inmethod ���뷽ʽ(�������б�˵��)
		// inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// outmethod ������ʽ(�������б�˵��)
		// outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stopmethod ͣ����ʽ(�������б�˵��)
		// stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stoptime ͣ��ʱ��(��λ����)
		// long (_stdcall *AddWindow)(WORD num, long left, long top, long width,
		// long height, long transparent, long border,
		// HDC dc, long src_width, long src_height, long alignment, long
		// inmethod, long inspeed, long outmethod, long outspeed, long
		// stopmethod, long stopspeed, long stoptime); //stoptime��λΪ����

		// ���ͼƬ�ļ�����
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
		// border ��ˮ�߿�(δʵ��)
		// filename ͼƬ�ļ�
		// inmethod ���뷽ʽ(�������б�˵��)
		// inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// outmethod ������ʽ(�������б�˵��)
		// outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stopmethod ͣ����ʽ(�������б�˵��)
		// stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stoptime ͣ��ʱ��(��λ����)
		int AddPicture(short num, int left, int top, int width, int height,
				int transparent, int border, String filename, int alignment,
				int inmethod, int inspeed, int outmethod, int outspeed,
				int stopmethod, int stopspeed, int stoptime); // stoptime��λΪ����

		// ������ֲ���
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
		// border ��ˮ�߿�(δʵ��)
		// str �����ַ���
		// fontname ��������
		// fontsize �����С
		// fontcolor ������ɫ
		// fontstyle ������ʽ
		// ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
		// wordwrap �Ƿ��Զ����� =1�Զ����У�=0���Զ�����
		// inmethod ���뷽ʽ(�������б�˵��)
		// inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// outmethod ������ʽ(�������б�˵��)
		// outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stopmethod ͣ����ʽ(�������б�˵��)
		// stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stoptime ͣ��ʱ��(��λ����)
		int AddText(short num, int left, int top, int width, int height,
				int transparent, int border, String str, String fontname,
				int fontsize, int fontcolor, int fontstyle, int wordwrap,
				int alignment, int inmethod, int inspeed, int outmethod,
				int outspeed, int stopmethod, int stopspeed, int stoptime); // stoptime��λΪ����

		// ����������ֲ���
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
		// border ��ˮ�߿�(δʵ��)
		// str �����ַ���
		// fontset �ֿ� =FONTSET_16P��ʾ16�����ֿ⣻=FONTSET_24P��ʾ24�����ֿ�
		// color ��ɫ
		// inmethod ���뷽ʽ(�������б�˵��)
		// inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// outmethod ������ʽ(�������б�˵��)
		// outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stopmethod ͣ����ʽ(�������б�˵��)
		// stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stoptime ͣ��ʱ��(��λ����)
		int AddString(short num, int left, int top, int width, int height,
				int transparent, int border, String str, int fontset,
				int color, int inmethod, int inspeed, int outmethod,
				int outspeed, int stopmethod, int stopspeed, int stoptime); // stoptime��λΪ����

		// ====���붯����ʽ�б�(��ֵ��0��ʼ)====
		// 0 = '���',
		// 1 = '������ʾ',
		// 2 = '�����ʾ',
		// 3 = '�Ϲ���ʾ',
		// 4 = '�ҹ���ʾ',
		// 5 = '�¹���ʾ',
		// 6 = '���������ʾ',
		// 7 = '�����¹���ʾ',
		// 8 = '�м�������չ��',
		// 9 = '�м�������չ��',
		// 10 = '�м�������չ��',
		// 11 = '������������',
		// 12 = '������������',
		// 13 = '��������չ��',
		// 14 = '��������չ��',
		// 15 = '�����Ͻ�����',
		// 16 = '�����½�����',
		// 17 = '�����Ͻ�����',
		// 18 = '�����½�����',
		// 19 = '������������',
		// 20 = '������������',
		// 21 = '�����Ҷ��',
		// 22 = '�����Ҷ��',
		// =====================================

		// ====����������ʽ�б�(��ֵ��0��ʼ)====
		// 0 = '���',
		// 1 = '����ʧ',
		// 2 = '������ʧ',
		// 3 = '�������м��£',
		// 4 = '�������м��£',
		// 5 = '�������м��£',
		// 6 = '���������Ƴ�',
		// 7 = '���������Ƴ�',
		// 8 = '���������£',
		// 9 = '�������Һ�£',
		// 10 = '�����Ͻ��Ƴ�',
		// 11 = '�����½��Ƴ�',
		// 12 = '�����Ͻ��Ƴ�',
		// 13 = '�����½��Ƴ�',
		// 14 = '���������Ƴ�',
		// 15 = '���������Ƴ�',
		// 16 = '�����Ҷ��',
		// 17 = '�����Ҷ��'
		// =====================================

		// ====ͣ��������ʽ�б�(��ֵ��0��ʼ)====
		// 0 = '��̬��ʾ',
		// 1 = '��˸��ʾ'
		// =====================================

		// ��д����ͨѶ������������ʱʹ��
		// index ����������
		// localport ���ض˿�
		// host ���ƿ�IP��ַ
		// remoteport Զ�̶˿�
		// address ���ƿ���ַ
		// notifymode ͨѶͬ���첽ģʽ
		// wmhandle ������Ϣ������
		// wmmessage ������Ϣ����Ϣ��
		// --����ֵ-- С��0��ʾʧ�ܣ����ڵ���0��ʾ������id��

	}

	public static void parse_res(int r) {
		if (r >= 0) {
			int notify = LedControl.INSTANCE.LED_GetNotifyParam_Notify(r);
			if (notify == LedControl.LM_TIMEOUT) {
				System.out.println("���ͽ�Ŀ����ִ�����ʱ");
			} else if (notify == LedControl.LM_TX_COMPLETE) {
				int result = LedControl.INSTANCE.LED_GetNotifyParam_Result(r);
				if (result == LedControl.RESULT_FLASH) {
					System.out.println("���ͽ�Ŀ����ִ��������ɣ�����д��Flash");
				} else {
					System.out.println("���ͽ�Ŀ����ִ���������");
				}
			} else if (notify == LedControl.LM_RESPOND) {
				int command = LedControl.INSTANCE.LED_GetNotifyParam_Command(r);
				if (command == LedControl.PKC_GET_POWER) {
					int status = LedControl.INSTANCE
							.LED_GetNotifyParam_Status(r);
					if (status == 1) {
						System.out.println("��ȡ��Դ��ɣ���ǰ��Դ״̬Ϊ����");
					} else {
						System.out.println("��ȡ��Դ��ɣ���ǰ��Դ״̬Ϊ�ر�");
					}
				} else if (command == LedControl.PKC_SET_POWER) {
					int status = LedControl.INSTANCE
							.LED_GetNotifyParam_Status(r);
					if (status == 1) {
						System.out.println("���õ�Դ��ɣ���ǰ��Դ״̬Ϊ����");
					} else {
						System.out.println("���õ�Դ��ɣ���ǰ��Դ״̬Ϊ�ر�");
					}
				} else if (command == LedControl.PKC_GET_BRIGHT) {
					int status = LedControl.INSTANCE
							.LED_GetNotifyParam_Status(r);
					System.out.println("��ȡ������ɣ���ǰ����Ϊ" + status);
				} else if (command == LedControl.PKC_SET_BRIGHT) {
					int status = LedControl.INSTANCE
							.LED_GetNotifyParam_Status(r);
					System.out.println("����������ɣ���ǰ����Ϊ" + status);
				} else if (command == LedControl.PKC_ADJUST_TIME) {
					System.out.println("У��ʱ�����");
				} else if (command == LedControl.PKC_SET_CURRENT_CHAPTER) {
					System.out.println("���õ�ǰ���Ž�Ŀ���");
				}
			} else if (notify == LedControl.LM_NOTIFY) {

			}
		} else if (r == LedControl.R_DEVICE_INVALID) {
			System.out.println("��ͨѶ�˿�ʧ��");
		} else if (r == LedControl.R_DEVICE_BUSY) {
			System.out.println("��ͨѶ �˿�æ�����ڷ��ͽ�Ŀ����ִ������");
		}
	}

	public static void main(String[] args) {

		// TODO Auto-generated method stub

		int s = LedControl.INSTANCE.LED_UDP_SenderParam(0, 9999,
				"192.168.1.95", 6666, 0, 2, 0, 0);
		System.out.println("���ͷ���ֵs = " + s);

		int r;
		if (s >= 0) {
			System.out.println("�������õ�ǰ���Ž�Ŀ�����Ϊ" + 2);
			r = LedControl.INSTANCE.LED_SetCurChapter2(s, 2);
			parse_res(r);
		}

		LedControl.INSTANCE.LED_Cleanup();
		System.out.println("���н���!");

	}
}
