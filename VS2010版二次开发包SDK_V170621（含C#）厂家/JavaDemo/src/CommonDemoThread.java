import com.sun.jna.Library;
import com.sun.jna.Native;

//import com.sun.jna.win32.*;

public class CommonDemoThread {
	public interface LedControl extends Library {

		// ��ǰ·��������Ŀ�£�������bin���Ŀ¼�¡�
		LedControl INSTANCE = (LedControl) Native.loadLibrary("LEDSender2010",
				LedControl.class);

		// ���ͺ�ִ������������
		public static final int R_DEVICE_READY = 0;
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

		// ��λ�����ص��������
		// ��λ�����ص��������
		public static final int NOTIFY_ROOT_DOWNLOAD = 0x00010003;
		public static final int NOTIFY_SET_PARAM = 0x00010004;
		public static final int NOTIFY_GET_PLAY_BUFFER = 0x00011001; // ��ȡ���ƿ���ʾ����

		// ���ͺ�ִ������Ӧ�����
		public static final int POWER_ON = 1;
		public static final int POWER_OFF = 0;

		// ��Ŀ������������
		public static final int ROOT_PLAY = 0x21;
		public static final int ROOT_DOWNLOAD = 0x22;
		public static final int ROOT_PLAY_CHAPTER = 0x23; // �ֲ�����--��Ŀ
		public static final int ROOT_PLAY_REGION = 0x25; // �ֲ�����--����
		public static final int ROOT_PLAY_LEAF = 0x27; // �ֲ�����--ҳ��
		public static final int ROOT_PLAY_OBJECT = 0x29; // �ֲ�����--����

		// �ֲ����²�������
		public static final int MODE_INSERT = 0x00;
		public static final int MODE_REPLACE = 0x01;

		// ��Ŀ��ɫ����
		public static final int COLOR_MODE_MONO = 0x1; // ��·�ź�
		public static final int COLOR_MODE_DOUBLE = 0x2; // ��˫ɫ(˫·�ź�)
		public static final int COLOR_MODE_THREE = 0x3; // ȫ���޻Ҷ�
		public static final int COLOR_MODE_FULLCOLOR = 0x4; // ȫ��

		// ����ʱ��ģʽ
		public static final int MODE_WAIT_CHILD = 0x1;
		public static final int MODE_USE_TIME = 0x0;

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
		// txtimeo ��ʱ�ȴ�ʱ��
		// txrepeat ʧ���ط�����
		int LED_UDP_SenderParamEx(int index, int localport, String host,
				int remoteport, int address, int notifymode, int wmhandle,
				int wmmessage, int txtimeo, int txrepeat);

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

		// ��ȡ���ƿ��ڲ��ŵĽ�Ŀ
		int LED_GetPlayContent2(int senderparam_index);

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

		// ��ȡ���ƿ�����
		int LED_Cache_GetBoardParam2(int senderparam_index);

		// ��ȡ���ƿ�IP��ַ
		String LED_Cache_GetBoardParam_IP();

		// ���ÿ��ƿ�IP��ַ
		void LED_Cache_SetBoardParam_IP(String value);

		// ���ÿ��ƿ�����
		int LED_Cache_SetBoardParam2(int senderparam_index);

		// ��ȡ���ƿ�Ӧ����������
		int LED_GetNotifyParam_Notify(int index);
		int LED_GetNotifyParam_Command(int index);
		int LED_GetNotifyParam_Result(int index);
		int LED_GetNotifyParam_Status(int index);
		String LED_GetNotifyParam_Host(int index);

		// ��ȡ���ƿ�Ӧ���������ݣ�ͬʱ�����ƿ��ض����ݱ��浽�ļ�
		int LED_GetNotifyParam_Buffer(String filename, int index);

		// Ԥ�����Ž�Ŀ�����ļ�
		void LED_PreviewFileEx(String previewapp, int width, int height,
				String previewfile);

		// ����Ŀ�ļ�����ͼƬ��
		void LED_PreviewFile_Export(String previewapp, int width, int height,
				int rgreverse, String previewfile);

		// ���ö�̬���ӿ�������ַ�������
		// value �ַ������ 0=GB���� 1=UTF8 2=Unicode(δʵ��)
		void SetGlobalCharset(int value);

		// ����RGB�ź�˳��
		// value �ź�˳��1)���ڵ�˫ɫ =0���� =1�̺죻2)����ȫ���޻Ҷȡ�ȫ�� =0������ =1������ =2�̺��� =3������
		// =4������ =5���̺�'
		int SetSignalOrder(int value);

		// ���õ�����ת
		// rotate ��ת��ʽ��=0����ת =1��ʱ����ת90�� =2˳ʱ����ת90��
		// width ��ʾ�����(��ת��)
		// height ��ʾ���߶�(��ת��)
		int SetRotate(int rotate, int width, int height);

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

		int MakeRootEx(int RootType, int ColorMode, int survive,
				int ARotateKey, int AMetrixCX, int AMetrixCY);

		// ���ɽ�Ŀ���ݣ�������Ҫ����[AddRegion]->[AddLeaf]->[AddObject]->[AddWindows/AddDateTime��]
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

		// ��ӽ�Ŀ
		// num ��Ŀ���ݻ�������ţ���MakeRoot�ķ���ֵ
		// time ���ŵ�ʱ�䳤��
		// wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
		// =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
		// priority ���ȼ�����0
		// kind �ƻ�ģʽ��=0ʼ�ղ��ţ�=1��һ��ÿ�ղ��ţ�=2����ֹʱ�䲥�ţ�=3������
		// week һ�ܶ��壬��kind=1ʱ��Ч����bit0-bit6��ʾ���յ�����
		// fromtime��totime����ֹʱ�䣬��kind=1ʱ����ʾÿ�յ���ֹʱ�䣬��kind=2ʱ����ʾ��ĳ��ĳ��ĳ��ĳʱ�俪ʼ����ĳ��ĳ��ĳ��ĳʱ�����
		int AddChapterEx2(short num, int time, short wait, short priority,
				short kind, short week, String fromtime, String totime);// timeΪ����

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

		// ���ҳ��
		// num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion�ķ���ֵ
		// time ���ŵ�ʱ�䳤��
		// wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
		// =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һҳ��
		int AddLeafEx(short num, int time, short wait, int bkcolor);// timeΪ����

		int AddLeafExA(short num, int time, short wait, int x1, int y1,
				int cx1, int cy1, int bkcolor1, int x2, int y2, int cx2,
				int cy2, int bkcolor2, int x3, int y3, int cx3, int cy3,
				int bkcolor3, int x4, int y4, int cx4, int cy4, int bkcolor4);// timeΪ����

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

		int AddDateTimeEx(short num, int left, int top, int width, int height,
				int transparent, int border, int vertical, String fontname,
				int fontsize, int fontcolor, int fontstyle, int year_offset,
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

		int AddTextEx4(short num, int left, int top, int width, int height,
				int transparent, int border, String str, int charset,
				String fontname, int fontsize, int fontcolor, int fontstyle,
				int bkcolor, int autofitsize, int wordwrap, int vertical,
				int alignment, int verticalspace, int horizontalfit,
				int inmethod, int inspeed, int outmethod, int outspeed,
				int stopmethod, int stopspeed, int stoptime); // stoptime��λΪ����

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

		// ��ӱ��
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
		// profile ��������ļ�
		// content ������ݣ���֮���Իس����зָ��֮����'|'�ָ�
		// inmethod ���뷽ʽ(�������б�˵��)
		// inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// outmethod ������ʽ(�������б�˵��)
		// outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stopmethod ͣ����ʽ(�������б�˵��)
		// stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stoptime ͣ��ʱ��(��λ����)
		int AddTable(short num, int left, int top, int width, int height,
				int transparent, String profile, String content, int inmethod,
				int inspeed, int outmethod, int outspeed, int stopmethod,
				int stopspeed, int stoptime);

		// ���Excel����
		// num
		// ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
		// left��top��width��height ���ϡ���ȡ��߶�
		// transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
		// border ��ˮ�߿�(δʵ��)
		// filename Excel�ļ���
		// alignment ���뷽ʽ
		// textcolor ������ɫ
		// bordercolor �������ɫ
		// splitvalue ��ֵ
		// inmethod ���뷽ʽ(�������б�˵��)
		// inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// outmethod ������ʽ(�������б�˵��)
		// outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stopmethod ͣ����ʽ(�������б�˵��)
		// stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
		// stoptime ͣ��ʱ��(��λ����)
		int AddExcel(short num, int left, int top, int width, int height,
				int transparent, int border, String filename, int alignment,
				int textcolor, int bordercolor, int splitvalue, int inmethod,
				int inspeed, int outmethod, int outspeed, int stopmethod,
				int stopspeed, int stoptime);

		// ====���붯����ʽ�б�(��ֵ��0��ʼ)====
		// 0 = '���',
		// 1 = '������ʾ',
		// 2 = '�����ʾ',
		// 3 = '�Ϲ���ʾ',
		// 4 = '�ҹ���ʾ',
		// 5 = '�¹���ʾ',
		// 6 = '���������ʾ',
		// 7 = '�����Ϲ���ʾ',
		// 8 = '�����ҹ�',
		// 9 = '�����¹�',
		// 10 = '�м�������չ��',
		// 11 = '�м�������չ��',
		// 12 = '�м�������չ��',
		// 13 = '������������',
		// 14 = '������������',
		// 15 = '��������չ��',
		// 16 = '��������չ��',
		// 17 = '�����Ͻ�����',
		// 18 = '�����½�����',
		// 19 = '�����Ͻ�����',
		// 20 = '�����½�����',
		// 21 = '������������',
		// 22 = '������������',
		// 23 = '�����Ҷ��',
		// 24 = '�����Ҷ��',
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

	private static final String demo_host = "192.168.1.99";
	private static final int demo_local_port = 9999;
	private static final int the_color_mode = LedControl.COLOR_MODE_DOUBLE;

	// ������ʾ���ϱ�ע�����߰�
	public static void ListenReport(int r) {
		LedControl.INSTANCE.LED_Report_CreateServer(0, 8888);
		int devcount = 0;
		while (true) {
			devcount = LedControl.INSTANCE.LED_Report_GetOnlineList(0, null, 0);
			System.out.println("���ͷ���ֵdevcount =" + devcount);
			for (int I = 0; I < devcount; I++) {
				String name = LedControl.INSTANCE.LED_Report_GetOnlineItemName(
						0, I);
				System.out.println("���ͷ���ֵname =" + name);
				String host = LedControl.INSTANCE.LED_Report_GetOnlineItemHost(
						0, I);
				System.out.println("���ͷ���ֵhost =" + host);
				int port = LedControl.INSTANCE.LED_Report_GetOnlineItemPort(0,
						I);
				System.out.println("���ͷ���ֵport =" + port);
				int addr = LedControl.INSTANCE.LED_Report_GetOnlineItemAddr(0,
						I);
				System.out.println("���ͷ���ֵaddr =" + addr);
			}
			if (devcount > 0)
				break;
		}
		LedControl.INSTANCE.LED_Report_RemoveServer(0);
	}

	// ����ִ�н������
	public static void parse(int r) {

		// LED_SendToScreen2�ķ���ֵΪR_DEVICE_READY����ʾ�����˷��͹���
		System.out.println(r);
		if (r == LedControl.R_DEVICE_READY) {
			System.out.println("���ڷ��ͽ�Ŀ����ִ������...");
			// ��ѯ���͵Ľ��
			while (true) {
				//Thread.sleep(50);
				int notify = LedControl.INSTANCE.LED_GetNotifyParam_Notify(r);
				if (notify == LedControl.LM_TIMEOUT) {
					System.out.println("���ͽ�Ŀ����ִ�����ʱ");
					break;
				} else if (notify == LedControl.LM_TX_COMPLETE) {
					int result = LedControl.INSTANCE
							.LED_GetNotifyParam_Result(r);
					if (result == LedControl.RESULT_FLASH) {
						System.out.println("���ͽ�Ŀ����ִ��������ɣ�����д��Flash");
					} else {
						System.out.println("���ͽ�Ŀ����ִ���������");
						break;
					}
				} else if (notify == LedControl.LM_RESPOND) {
					int command = LedControl.INSTANCE
							.LED_GetNotifyParam_Command(r);
					if (command == LedControl.PKC_GET_POWER) {
						int status = LedControl.INSTANCE
								.LED_GetNotifyParam_Status(r);
						if (status == 1) {
							System.out.println("��ȡ��Դ��ɣ���ǰ��Դ״̬Ϊ����");
						} else {
							System.out.println("��ȡ��Դ��ɣ���ǰ��Դ״̬Ϊ�ر�");
						}
						break;
					} else if (command == LedControl.PKC_SET_POWER) {
						int status = LedControl.INSTANCE
								.LED_GetNotifyParam_Status(r);
						if (status == 1) {
							System.out.println("���õ�Դ��ɣ���ǰ��Դ״̬Ϊ����");
						} else {
							System.out.println("���õ�Դ��ɣ���ǰ��Դ״̬Ϊ�ر�");
						}
						break;
					} else if (command == LedControl.PKC_GET_BRIGHT) {
						int status = LedControl.INSTANCE
								.LED_GetNotifyParam_Status(r);
						System.out.println("��ȡ������ɣ���ǰ����Ϊ" + status);
						break;
					} else if (command == LedControl.PKC_SET_BRIGHT) {
						int status = LedControl.INSTANCE
								.LED_GetNotifyParam_Status(r);
						System.out.println("����������ɣ���ǰ����Ϊ" + status);
						break;
					} else if (command == LedControl.PKC_ADJUST_TIME) {
						System.out.println("У��ʱ�����");
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
						System.out.println("��ȡ���ƿ��ڲ����������");
						break;
					} else if (result == LedControl.NOTIFY_SET_PARAM) {
						System.out.println("���ÿ��ƿ��������");
						break;
					}
				}
			}
		} else if (r == LedControl.R_DEVICE_INVALID) {
			System.out.println("��ͨѶ�˿�ʧ��");
		} else if (r == LedControl.R_DEVICE_BUSY) {
			System.out.println("��ͨѶ �˿�æ�����ڷ��ͽ�Ŀ����ִ������");
		}
	}

	// �򿪵�Դ
	public static void demo_power_on() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);
		int r = LedControl.INSTANCE.LED_SetPower2(dev, LedControl.POWER_ON);
		parse(r);
	}

	// �رյ�Դ
	public static void demo_power_off() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);
		int r = LedControl.INSTANCE.LED_SetPower2(dev, LedControl.POWER_OFF);
		parse(r);
	}

	// У��ʱ��
	public static void demo_adjust_time() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);
		int r = LedControl.INSTANCE.LED_AdjustTime2(dev);
		parse(r);
	}

	// ���ÿ��ƿ�IP��ַ
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

	// �ض����ƿ���Ŀ
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

	// ͼƬ�ļ���������
	public static void demo_picture() {
		int k;
		// wmhandle������Ҫ��-1����ʾ���ؽ��д��wmmessageָ���ĵ�Ԫ��
		// wmmessage�������뷵�ؽ�������ţ����ڲ�ѯ���ؽ������LED_SendToScreen2�ķ���ֵ�᷵��wmmessage�����ֵ��
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 4, -1, 0);

		k = LedControl.INSTANCE.MakeRoot(LedControl.ROOT_PLAY, the_color_mode,
				-1); // -1��ʾ��Ŀʼ�ղ���
		LedControl.INSTANCE.AddChapter((short) k, 30000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddRegion((short) k, 0, 0, 64, 32, 0);

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		// ע�⣬���ͼƬ�ļ����Ͳ���������ʹ�þ���·��������"D:\\Test\\Demo.bmp"
		LedControl.INSTANCE.AddPicture((short) k, 0, 0, 64, 32, 1, 0,
				"Demo.bmp", 0, 0, 5, 2, 5, 0, 5, 3000); // stoptime��λΪ����

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// Excel�ļ���������
	public static void demo_excel() {
		int k;
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 4, -1, 0);

		k = LedControl.INSTANCE.MakeRoot(LedControl.ROOT_PLAY, the_color_mode,
				-1); // -1��ʾ��Ŀʼ�ղ���
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

	// ��Ŀ�������̣�����������������֡�����ʱ�䡢ͼƬ
	public static void demo_send() {
		int k;
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 4, -1, 0);

		k = LedControl.INSTANCE.MakeRoot(LedControl.ROOT_PLAY, the_color_mode,
				-1); // -1��ʾ��Ŀʼ�ղ���
		LedControl.INSTANCE.AddChapter((short) k, 30000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddRegion((short) k, 0, 0, 64, 32, 0);

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		// LedControl.INSTANCE.AddDateTime((short) k, 0, 0, 96, 24, 1, 0, "����",
		// 12, 0xFFFF, 0x0, 0, 0, 0, 0, "#h:#n:#s");
		LedControl.INSTANCE.AddText((short) k, 0, 0, 96, 24, 1, 0,
				"��ʾ�����ԡ�\r\nHello world.", "����", 24, 0xFFFF, 0x0, 1, 0, 1, 5, 2,
				5, 0, 5, 3000); // stoptime��λΪ����

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// ��ת��Ŀ��������
	public static void demo_rotate_send() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		// rotate ��ת��ʽ��=0����ת =1��ʱ����ת90�� =2˳ʱ����ת90��
		// width ��ʾ�����(��ת��)
		// height ��ʾ���߶�(��ת��)
		// LedControl.INSTANCE.SetRotate(1, 32, 64);

		int k = LedControl.INSTANCE.MakeRootEx(LedControl.ROOT_PLAY,
				the_color_mode, -1, 1, 32, 64); // -1��ʾ��Ŀʼ�ղ���
		// int k = LedControl.INSTANCE.MakeRoot(LedControl.ROOT_PLAY,
		// the_color_mode, -1); //-1��ʾ��Ŀʼ�ղ���
		LedControl.INSTANCE.AddChapter((short) k, 30000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddRegion((short) k, 0, 0, 32, 64, 0);

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddDateTimeEx((short) k, 0, 0, 32, 16, 1, 0, 0,
				"����", 12, 0xFFFF, 0x0, 0, 0, 0, 0, "#y��#m��#d��");
		LedControl.INSTANCE.AddDateTimeEx((short) k, 0, 16, 32, 16, 1, 0, 0,
				"����", 12, 0xFFFF, 0x0, 0, 0, 0, 0, "#h:#n:#s");

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddTextEx4((short) k, 0, 0, 32, 16, 1, 0, "��ʾ�����ԡ�",
				0, "����", 12, 0xFFFF, 0x0, 0, 0, 1, 0, 0, 0, 0, 0, 5, 2, 5, 0,
				5, 3000); // stoptime��λΪ����

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddPicture((short) k, 0, 0, 32, 32, 1, 0,
				"Demo.bmp", 0, 0, 5, 2, 5, 0, 5, 3000); // stoptime��λΪ����

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// ��Ŀ���żƻ�����
	public static void demo_chapter_schedule() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		int k = LedControl.INSTANCE.MakeRoot(LedControl.ROOT_PLAY,
				the_color_mode, -1); // -1��ʾ��Ŀʼ�ղ���
		LedControl.INSTANCE.AddChapterEx2((short) k, 30000,
				(short) LedControl.MODE_WAIT_CHILD, (short) 0, (short) 1,
				(short) 0x7F, "08:00:00", "17:00:00");
		LedControl.INSTANCE.AddRegion((short) k, 0, 0, 96, 24, 0);

		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddText((short) k, 0, 0, 96, 24, 1, 0,
				"��ʾ�����ԡ�\r\nHello world.", "����", 24, 0xFFFF, 0x0, 1, 0, 0, 5, 2,
				5, 0, 5, 3000); // stoptime��λΪ����

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// �ֲ��������̣�ֻ����һ����Ŀ
	public static void demo_chapter_modify() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		// ���µ�1����Ŀ
		int k = LedControl.INSTANCE.MakeChapter(LedControl.ROOT_PLAY_CHAPTER,
				LedControl.MODE_REPLACE, 0, the_color_mode, 30000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddRegion((short) k, 0, 0, 96, 24, 0);
		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddText((short) k, 0, 0, 96, 24, 1, 0,
				"��ʾ�����ԡ�\r\nHello world.", "����", 24, 0xFFFF, 0x0, 1, 0, 0, 5, 2,
				5, 0, 5, 3000); // stoptime��λΪ����

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// �ֲ��������̣�ֻ����һ������
	public static void demo_region_modify() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		// ���µ�1����Ŀ��ĵ�1������
		int k = LedControl.INSTANCE
				.MakeRegion(LedControl.ROOT_PLAY_REGION,
						LedControl.MODE_REPLACE, 0, 0, the_color_mode, 0, 0,
						128, 32, 0);
		LedControl.INSTANCE.AddLeaf((short) k, 3000,
				(short) LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddText((short) k, 0, 0, 64, 32, 1, 0,
				"��ʾ�����ԡ�\r\nHello world.", "����", 12, 0xFFFF, 0x0, 1, 0, 0, 5, 2,
				5, 0, 5, 3000); // stoptime��λΪ����

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// �ֲ��������̣�ֻ����һ��ҳ��
	public static void demo_leaf_modify() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		// ���µ�1����Ŀ��ĵ�1��������ĵ�1��ҳ��
		int k = LedControl.INSTANCE.MakeLeaf(LedControl.ROOT_PLAY_LEAF,
				LedControl.MODE_REPLACE, 0, 0, 0, the_color_mode, 5000,
				LedControl.MODE_WAIT_CHILD);
		LedControl.INSTANCE.AddText((short) k, 0, 0, 96, 24, 1, 0,
				"��ʾ�����ԡ�\r\nHello world.", "����", 24, 0xFFFF, 0x0, 1, 0, 0, 5, 2,
				5, 0, 5, 3000); // stoptime��λΪ����

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	// �ֲ��������̣�ֻ����һ������
	public static void demo_object_modify() {
		int dev = LedControl.INSTANCE.LED_UDP_SenderParam(0, demo_local_port,
				demo_host, 6666, 0, 2, -1, 0);

		// ���µ�1����Ŀ��ĵ�1��������ĵ�1��ҳ��
		int k = LedControl.INSTANCE.MakeObject(LedControl.ROOT_PLAY_OBJECT,
				LedControl.MODE_REPLACE, 0, 0, 0, 0, the_color_mode);
		LedControl.INSTANCE.AddText((short) k, 0, 0, 64, 16, 1, 0, "��ʾ�����ԡ�",
				"����", 12, 0xFFFF, 0x0, 1, 0, 0, 5, 2, 5, 0, 5, 3000); // stoptime��λΪ����

		int r = LedControl.INSTANCE.LED_SendToScreen2(dev, k);
		parse(r);
	}

	public static void main(String[] args) {

		// TODO Auto-generated method stub
		System.out.println("��������");

		// demo_picture(); // ���ڽ����ѯ�������demo_picture�����Ķ��壬���������ע�͡�
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

		// �˾䣬ֻ�������������˳�ʱ������1�Ρ������ڳ����ж�ε��á�
		LedControl.INSTANCE.LED_Cleanup();
		System.out.println("�����˳�");
	}

}
