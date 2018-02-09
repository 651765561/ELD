#ifndef __ledsender__
#define __ledsender__

/*
   ����˵��
   
*/
#include <windows.h>

//ȱʡ���ݰ���С
#define DEFAULT_PKP_LENGTH     512

//IP��ַ��MAC��ַ���ȶ���
#define IP_ADDRESS_LENGTH      4
#define ETHER_ADDRESS_LENGTH   6

//ͨѶ�豸����
#define DEVICE_TYPE_COM    0  //����ͨѶ
#define DEVICE_TYPE_UDP    1  //����ͨѶ
#define DEVICE_TYPE_485    2  //485ͨѶ

//���ڻ���485ͨѶʹ�õ�ͨѶ�ٶ�(������)
#define SBR_57600          0
#define SBR_38400          1
#define SBR_19200          2
#define SBR_9600           3

//�Ƿ�ȴ���λ��Ӧ��ֱ�ӷ�����������
#define NOTIFY_NONE        1
//�Ƿ�������ʽ������ȵ�������ɻ��߳�ʱ���ŷ��أ�������������
#define NOTIFY_BLOCK       2
//�Ƿ񽫷��ͽ����Windows������Ϣ��ʽ�͵����õ�Ӧ��
#define NOTIFY_EVENT       4
//ʹ��һ�����ض˿ڣ��Ͷ��Ŀ��IPͨѶ
#define NOTIFY_MULTI       8

#define R_DEVICE_READY     0
#define R_DEVICE_INVALID   -1
#define R_DEVICE_BUSY      -2
#define R_FONTSET_INVALID  -3
#define R_DLL_INIT_IVALID  -4
#define R_IGNORE_RESPOND   -5

//Chapter��Leaf�У�����ʱ�����
#define WAIT_USE_TIME      0  //����ָ����ʱ�䳤�Ȳ��ţ���ʱ����е���һ��
#define WAIT_CHILD         1  //�ȴ�����Ŀ�Ĳ��ţ��������ָ����ʱ�䳤�ȣ�������Ŀ��û�в��꣬��ȴ�����

#define V_FALSE            0
#define V_TRUE             1

//��ʾ����ɫ����
#define COLOR_MODE_MONO              1  //��ɫ
#define COLOR_MODE_DOUBLE            2  //˫ɫ
#define COLOR_MODE_THREE             3  //�޻Ҷ�ȫ��
#define COLOR_MODE_FULLCOLOR         4  //ȫ��

//��ʾ��������
#define ROOT_UPDATE            0x13  //������λ������
#define ROOT_FONTSET           0x14  //�����ֿ�
#define ROOT_PLAY              0x21  //��Ŀ���ݣ����浽RAM�����綪ʧ
#define ROOT_DOWNLOAD          0x22  //��Ŀ���ݣ����浽Flash
#define ROOT_PLAY_CHAPTER      0x23  //������߸���ĳһ��Ŀ
#define ROOT_PLAY_REGION       0x25  //������߸���ĳһ����
#define ROOT_PLAY_LEAF         0x27  //������߸���ĳһҳ��
#define ROOT_PLAY_OBJECT       0x29  //������߸���ĳһ����

#define ACTMODE_INSERT         0  //�������
#define ACTMODE_REPLACE        1  //�滻����

//RAM��Ŀ����
#define ROOT_SURVIVE_ALWAYS    -1

//Windows�������Ͷ���
#define WFS_NONE               0x0   //��ͨ��ʽ
#define WFS_BOLD               0x01  //����
#define WFS_ITALIC             0x02  //б��
#define WFS_UNDERLINE          0x04  //�»���
#define WFS_STRIKEOUT          0x08  //ɾ����

//�����Ƴ���
#define FLOW_NONE          0
#define FLOW_RTS_CTS       1

//��λ��Ӧ���ʶ
#define LM_RX_COMPLETE         1
#define LM_TX_COMPLETE         2
#define LM_RESPOND             3
#define LM_TIMEOUT             4
#define LM_NOTIFY              5
#define LM_PARAM               6
#define LM_TX_PROGRESS         7
#define LM_RX_PROGRESS         8
#define RESULT_FLASH           0xff

//��Դ����״̬
#define LED_POWER_ON       1
#define LED_POWER_OFF      0

//�������ִ�С
#define FONT_SET_16        0      //16�����ַ�
#define FONT_SET_24        1      //24�����ַ�
  
//����ʱ������ʱtype����
#define CT_COUNTUP         0      //����ʱ
#define CT_COUNTDOWN       1      //����ʱ
//����ʱ������ʱformat����
#define CF_HNS             0      //ʱ���루���ֵ��
#define CF_HN              1      //ʱ�֣����ֵ��
#define CF_NS              2      //���루���ֵ��
#define CF_H               3      //ʱ�����ֵ��
#define CF_N               4      //�֣����ֵ��
#define CF_S               5      //�루���ֵ��
#define CF_DAY             6      //����������������
#define CF_HOUR            7      //Сʱ��������������
#define CF_MINUTE          8      //������������������
#define CF_SECOND          9      //����������������

//ģ��ʱ�ӱ߿���״
#define SHAPE_RECTANGLE    0      //����
#define SHAPE_ROUNDRECT    1      //Բ�Ƿ���
#define SHAPE_CIRCLE       2      //Բ��

//������붨��
#define PKC_RESPOND               3
#define PKC_QUERY                 4
#define PKC_OVERFLOW              5
#define PKC_ADJUST_TIME           6
#define PKC_GET_PARAM             7
#define PKC_SET_PARAM             8
#define PKC_GET_POWER             9
#define PKC_SET_POWER             10
#define PKC_GET_BRIGHT            11
#define PKC_SET_BRIGHT            12
#define PKC_COM_TRANSFER          21
#define PKC_GET_POWER_SCHEDULE    60
#define PKC_SET_POWER_SCHEDULE    61
#define PKC_GET_BRIGHT_SCHEDULE   62
#define PKC_SET_BRIGHT_SCHEDULE   63
#define PKC_SET_CURRENT_CHAPTER   66
#define PKC_GET_CURRENT_CHAPTER   67
#define PKC_NOTIFY                100
#define PKC_MODIFY_IP             7654
#define PKC_MODIFY_MAC            7655

#define NOTIFY_ROOT_DOWNLOAD      0x00010003  //����Flash���Ž�Ŀ
#define NOTIFY_SET_PARAM          0x00010004  //���ò���

#define NOTIFY_BUFFER_LEN		  512

typedef struct TIMESTAMP{
  long   time;
  long   date;
}TTimeStamp, *PTimeStamp;

typedef struct DEVICE_PARAM{
  WORD  devType;
  WORD  comSpeed;
  WORD  comPort;
  WORD  comFlow;
  WORD  locPort;
  WORD  rmtPort;
  WORD  srcAddr;
  WORD  dstAddr;
  char  rmtHost[16];
  DWORD txTimeo;   //���ͺ�ȴ�Ӧ��ʱ�� ====��ʱʱ��ӦΪtxTimeo*txRepeat
  DWORD txRepeat;  //ʧ���ط�����
  DWORD txMovewin; //��������
  DWORD key;
  long  pkpLength; //���ݰ���С
}TDeviceParam, *PDeviceParam;

typedef struct SENDER_PARAM{
  TDeviceParam devParam;
  long  wmHandle;
  long  wmMessage;
  long  wmLParam;
  long  notifyMode;
}TSenderParam, *PSenderParam;

typedef struct NOTIFY_PARAM{
  WORD  Notify;
  WORD  Command;
  long  Result;
  long  Status;
  TSenderParam Param;
  BYTE  Buffer[NOTIFY_BUFFER_LEN];
  DWORD Size;
}TNotifyParam, *PNotifyParam;

typedef struct POWER_SCHEDULE{
  DWORD Enabled;
  DWORD Mode;
  TTimeStamp OpenTime[21];
  TTimeStamp CloseTime[21];
  DWORD Checksum;
}TPowerSchedule, *PPowerSchedule;

typedef struct BRIGHT_SCHEDULE{
  DWORD Enabled;
  BYTE  Bright[24];
  DWORD Checksum;
}TBrightSchedule, *PBrightSchedule;

//��̬���ӿ��ʼ��
long (_stdcall *LED_Startup)(void);

//��̬���ӿ�����
long (_stdcall *LED_Cleanup)(void);

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/************************************************************************/
/* ���߿��ƿ��б���ؽӿں���                                           */
/************************************************************************/

typedef struct DEVINFO{
	char  dev_name[32];  //�豸����
	DWORD dev_id;        //�豸��ʶ
	DWORD dev_ip;        //�豸IP��ַ
	WORD  dev_addr;      //�豸��ַ
	WORD  dev_port;      //�豸�˿�
	DWORD reserved[5];   //ϵͳ����
}TDevInfo, *PDevInfo;

typedef struct DEVICEREPORT{
	TDevInfo devinfo;    //�豸��Ϣ
	double   timeupdate; //���ˢ��ʱ��
}TDeviceReport, *PDeviceReport;

//�������ƿ����߼�������
//  serverindex ���ƿ����߼���������(�����ڶ��socket udp�˿ڼ���)
//  localport ���ض˿�
long (_stdcall *LED_Report_CreateServer)(long serverindex, long localport);

//ɾ�����ƿ����߼�������
//  serverindex ���ƿ����߼���������
void (_stdcall *LED_Report_RemoveServer)(long serverindex);

//ɾ��ȫ�����ƿ����߼�������
void (_stdcall *LED_Report_RemoveAllServer)(void);

//��ÿ��ƿ������б�
//�����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
//  serverindex ���ƿ����߼���������
//  plist ��������б���û��ⲿ��������
//        ��������(NULL/0)�����������̬���ӿ��ڲ��Ļ�������������������Ľӿ�ȡ����ϸ��Ϣ
//  count ����ȡ����
//--����ֵ-- С��0��ʾʧ��(δ���������߼�������)�����ڵ���0��ʾ���ߵĿ��ƿ�����
long (_stdcall *LED_Report_GetOnlineList)(long serverindex, void* plist, long count);

//���ĳ�����߿��ƿ����ϱ����ƿ�����
//�����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
//  serverindex ���ƿ����߼���������
//  itemindex �ü�������������б��У����߿��ƿ��ı��
//--����ֵ-- ���߿��ƿ����ϱ����ƿ�����
char* (_stdcall *LED_Report_GetOnlineItemName)(long serverindex, long itemindex);

//���ĳ�����߿��ƿ����ϱ����ƿ�IP��ַ
//�����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
//  serverindex ���ƿ����߼���������
//  itemindex �ü�������������б��У����߿��ƿ��ı��
//--����ֵ-- ���߿��ƿ���IP��ַ
char* (_stdcall *LED_Report_GetOnlineItemHost)(long serverindex, long itemindex);

//���ĳ�����߿��ƿ����ϱ����ƿ�Զ��UDP�˿ں�
//�����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
//  serverindex ���ƿ����߼���������
//  itemindex �ü�������������б��У����߿��ƿ��ı��
//--����ֵ-- ���߿��ƿ���Զ��UDP�˿ں�
long (_stdcall *LED_Report_GetOnlineItemPort)(long serverindex, long itemindex);

//���ĳ�����߿��ƿ����ϱ����ƿ���ַ
//�����ȴ������ƿ����߼������񣬼�����LED_Report_CreateServer��ʹ�ã����򷵻�ֵ��Ч
//  serverindex ���ƿ����߼���������
//  itemindex �ü�������������б��У����߿��ƿ��ı��
//--����ֵ-- ���߿��ƿ���Ӳ����ַ
long (_stdcall *LED_Report_GetOnlineItemAddr)(long serverindex, long itemindex);

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/************************************************************************/
/* ��дͨѶ�����ӿں���������һЩ�޷����ݽṹ���ָ��Ŀ�������������   */
/************************************************************************/

//��д����ͨѶ������������ʱʹ��
//  index ����������
//  localport ���ض˿�
//  host ���ƿ�IP��ַ
//  remoteport Զ�̶˿�
//  address ���ƿ���ַ
//  notifymode ͨѶͬ���첽ģʽ
//  wmhandle ������Ϣ������
//  wmmessage ������Ϣ����Ϣ��
//--����ֵ-- С��0��ʾʧ�ܣ����ڵ���0��ʾ������id��
long (_stdcall *LED_UDP_SenderParam)(long index, long localport, char* host, long remoteport, long address, long notifymode, long wmhandle, long wmmessage);

//��д����ͨѶ������������ʱʹ��
//  index ����������
//  comport ���ں�
//  baudrate ������
//  address ���ƿ���ַ
//  notifymode ͨѶͬ���첽ģʽ
//  wmhandle ������Ϣ������
//  wmmessage ������Ϣ����Ϣ��
//--����ֵ-- С��0��ʾʧ�ܣ����ڵ���0��ʾ������id��
long (_stdcall *LED_COM_SenderParam)(long index, long comport, long baudrate, long address, long notifymode, long wmhandle, long wmmessage);

//��д����ͨѶ������������ʱʹ��
//  index ����������
//  localport ���ض˿�
//  serverindex ���߼���������
//  name ���ƿ�����(���ƿ��ϱ���������)
//  notifymode ͨѶͬ���첽ģʽ
//  wmhandle ������Ϣ������
//  wmmessage ������Ϣ����Ϣ��
//--����ֵ-- С��0��ʾʧ�ܣ����ڵ���0��ʾ������id��
long (_stdcall *LED_UDP_SenderParam_ByReportName)(long index, long localport, long serverindex, char* name, long notifymode, long wmhandle, long wmmessage);

//Ԥ����ʾ����
void (_stdcall *LED_Preview)(long index, long width, long height, char* previewfile);

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//��λ���ƿ���Ŀ���ţ�������ʾ���ƿ�Flash�д洢�Ľ�Ŀ
long (_stdcall *LED_ResetDisplay)(PSenderParam param);
long (_stdcall *LED_ResetDisplay2)(long senderparam_index);

//У��ʱ�䣬�Ե�ǰ�������ϵͳʱ��У�����ƿ���ʱ��
long (_stdcall *LED_AdjustTime)(PSenderParam param);
long (_stdcall *LED_AdjustTime2)(long senderparam_index);

//У��ʱ����չ����ָ����ʱ��У�����ƿ���ʱ��
long (_stdcall *LED_AdjustTimeEx)(PSenderParam param, LPSYSTEMTIME time);
long (_stdcall *LED_AdjustTimeEx2)(long senderparam_index, LPSYSTEMTIME time);

//���õ�ǰ��ʾ�Ľ�Ŀ
long (_stdcall *LED_SetCurChapter)(PSenderParam param, long value);
long (_stdcall *LED_SetCurChapter2)(long senderparam_index, long value);

//���õ�ǰ��ʾ�Ľ�Ŀ
long (_stdcall *LED_GetCurChapter)(PSenderParam param);
long (_stdcall *LED_GetCurChapter2)(long senderparam_index);

//���ÿ��ƿ���Դ value=LED_POWER_ON��ʾ������Դ value=LED_POWER_OFF��ʾ�رյ�Դ
long (_stdcall *LED_SetPower)(PSenderParam param, long value);
long (_stdcall *LED_SetPower2)(long senderparam_index, long value);

//����ת������
long (_stdcall *LED_ComTransfer)(PSenderParam param, BYTE* buffer, DWORD size);
long (_stdcall *LED_ComTransfer2)(long senderparam_index, BYTE* buffer, DWORD size);

//��ȡ���ƿ���Դ״̬
long (_stdcall *LED_GetPower)(PSenderParam param);
long (_stdcall *LED_GetPower2)(long senderparam_index);

//���ÿ��ƿ����� valueȡֵ��Χ0-7
long (_stdcall *LED_SetBright)(PSenderParam param, long value);
long (_stdcall *LED_SetBright2)(long senderparam_index, long value);

//��ȡ���ƿ�����
long (_stdcall *LED_GetBright)(PSenderParam param);
long (_stdcall *LED_GetBright2)(long senderparam_index);

//���ÿ��ƿ��Ķ�ʱ�������ƻ�
long (_stdcall *LED_SetPowerSchedule)(PSenderParam param, PPowerSchedule value);
long (_stdcall *LED_SetPowerSchedule2)(long senderparam_index, PPowerSchedule value);

//��ȡ���ƿ��Ķ�ʱ�������ƻ�
long (_stdcall *LED_GetPowerSchedule)(PSenderParam param);
long (_stdcall *LED_GetPowerSchedule2)(long senderparam_index);

//���ÿ��ƿ��Ķ�ʱ���ȵ��ڼƻ�
long (_stdcall *LED_SetBrightSchedule)(PSenderParam param, PBrightSchedule value);
long (_stdcall *LED_SetBrightSchedule2)(long senderparam_index, PBrightSchedule value);

//��ȡ���ƿ��Ķ�ʱ���ȵ��ڼƻ�
long (_stdcall *LED_GetBrightSchedule)(PSenderParam param);
long (_stdcall *LED_GetBrightSchedule2)(long senderparam_index);

//���ͽ�Ŀ���� indexΪMakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�����ķ���ֵ
long (_stdcall *LED_SendToScreen)(PSenderParam param, long index);
long (_stdcall *LED_SendToScreen2)(long senderparam_index, long index);

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// ���ڶԿ��ƿ�����һЩ��������
// ����Ϊ����ȡ���ƿ�����--��ȡ��������--
//                       --�޸ĸ�������--���޸ĺ�Ĳ���������ƿ�
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//��ȡ���ƿ�����
long (_stdcall *LED_Cache_GetBoardParam)(PSenderParam param);
long (_stdcall *LED_Cache_GetBoardParam2)(long senderparam_index);
//��ȡ��������
long (_stdcall *LED_Cache_GetBoardParam_SaveToFile)(char* filename);  //�����ƿ��ض��Ĳ�����д���ļ�
char* (_stdcall *LED_Cache_GetBoardParam_IP)(void);
char* (_stdcall *LED_Cache_GetBoardParam_Mac)(void);
long (_stdcall *LED_Cache_GetBoardParam_Addr)(void);
long (_stdcall *LED_Cache_GetBoardParam_Width)(void);
long (_stdcall *LED_Cache_GetBoardParam_Height)(void);
long (_stdcall *LED_Cache_GetBoardParam_Brightness)(void);
//�޸ĸ�������
long (_stdcall *LED_Cache_SetBoardParam_LoadFromFile)(char* filename);  //���ļ���ȡ���������浽��̬���ӿ��У��Թ�д�뵽���ƿ�
void (_stdcall *LED_Cache_SetBoardParam_IP)(char* value);
void (_stdcall *LED_Cache_SetBoardParam_Mac)(char* value);
void (_stdcall *LED_Cache_SetBoardParam_Addr)(long value);
void (_stdcall *LED_Cache_SetBoardParam_Width)(long value);
void (_stdcall *LED_Cache_SetBoardParam_Height)(long value);
void (_stdcall *LED_Cache_SetBoardParam_Brightness)(long value);
//���޸ĺ�Ĳ���������ƿ�
long (_stdcall *LED_Cache_SetBoardParam)(PSenderParam param);
long (_stdcall *LED_Cache_SetBoardParam2)(long senderparam_index);

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//��ȡ���ƿ�Ӧ����������
long (_stdcall *LED_GetNotifyParam)(PNotifyParam notify, long index);

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//��Ŀ������֯��ʽ
//  ROOT
//   |
//   |---Chapter(��Ŀ)
//   |      |
//   |      |---Region(����)
//   |      |     |
//   |      |     |---Leaf(ҳ��)
//   |      |     |    |
//   |      |     |    |---Object(����[���֡�ʱ�ӡ�ͼƬ��])
//   |      |     |    |
//   |      |     |    |---Object(����[���֡�ʱ�ӡ�ͼƬ��])
//   |      |     |    |
//   |      |     |    |   ......
//   |      |     |    |
//   |      |     |
//   |      |     |---Leaf(ҳ��)
//   |      |     |
//   |      |     |   ......
//   |      |     |
//   |      |
//   |      |---Region(����)
//   |      |
//   |      |   ......
//   |      |
//   |---Chapter(��Ŀ)
//   |
//   |   ......

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//���ɲ������ݣ���VisionShow����༭��Vsq�ļ����룬������Ҫ�·��Ľ�Ŀ���ݣ�
//  RootType Ϊ�������ͣ�=ROOT_PLAY��ʾ���¿��ƿ�RAM�еĽ�Ŀ(���綪ʧ)��=ROOT_DOWNLOAD��ʾ���¿��ƿ�Flash�еĽ�Ŀ(���粻��ʧ)
//  ColorMode Ϊ��ɫģʽ��ȡֵΪCOLOR_MODE_MONO����COLOR
//  survive ΪRAM��Ŀ����ʱ�䣬��RootType=ROOT_PLAYʱ��Ч����RAM��Ŀ���Ŵﵽʱ��󣬻ָ���ʾFLASH�еĽ�Ŀ
//  filename ��VisionShow����༭�Ľ�Ŀ�ļ�
long (_stdcall *MakeFromVsqFile)(char* filename, long RootType, long ColorMode, long survive = ROOT_SURVIVE_ALWAYS);

//���ɲ�������
//  RootType Ϊ�������ͣ�=ROOT_PLAY��ʾ���¿��ƿ�RAM�еĽ�Ŀ(���綪ʧ)��=ROOT_DOWNLOAD��ʾ���¿��ƿ�Flash�еĽ�Ŀ(���粻��ʧ)
//  ColorMode Ϊ��ɫģʽ��ȡֵΪCOLOR_MODE_MONO����COLOR
//  survive ΪRAM��Ŀ����ʱ�䣬��RootType=ROOT_PLAYʱ��Ч����RAM��Ŀ���Ŵﵽʱ��󣬻ָ���ʾFLASH�еĽ�Ŀ
long (_stdcall *MakeRoot)(long RootType, long ColorMode, long survive = ROOT_SURVIVE_ALWAYS);

//���ɽ�Ŀ���ݣ�������Ҫ����[AddRegion]->[AddLeaf]->[AddObject]->[AddWindows/AddDateTime��]
//  RootType ������ΪROOT_PLAY_CHAPTER
//  ActionMode ������Ϊ0
//  ChapterIndex Ҫ���µĽ�Ŀ���
//  ColorMode ͬMakeRoot�еĶ���
//  time ���ŵ�ʱ�䳤��
//  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
//                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
long (_stdcall *MakeChapter)(long RootType, long ActionMode, long ChapterIndex, long ColorMode, DWORD time, WORD wait);

//���ɷ�����������Ҫ����[AddLeaf]->[AddObject]->[AddWindows/AddDateTime��]
//  RootType ������ΪROOT_PLAY_REGION
//  ActionMode ������Ϊ0
//  ChapterIndex Ҫ���µĽ�Ŀ���
//  RegionIndex Ҫ���µķ������
//  ColorMode ͬMakeRoot�еĶ���
//  left��top��width��height ���ϡ���ȡ��߶�
//  border ��ˮ�߿�
long (_stdcall *MakeRegion)(long RootType, long ActionMode, long ChapterIndex, long RegionIndex, long ColorMode, long left, long top, long width, long height, long border);

//����ҳ�棬������Ҫ����[AddObject]->[AddWindows/AddDateTime��]
//  RootType ������ΪROOT_PLAY_LEAF
//  ActionMode ������Ϊ0
//  ChapterIndex Ҫ���µĽ�Ŀ���
//  RegionIndex Ҫ���µķ������
//  LeafIndex Ҫ���µ�ҳ�����
//  ColorMode ͬMakeRoot�еĶ���
//  time ���ŵ�ʱ�䳤��
//  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
//                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һҳ��
long (_stdcall *MakeLeaf)(long RootType, long ActionMode, long ChapterIndex, long RegionIndex, long LeafIndex, long ColorMode, DWORD time, WORD wait);

//���ɲ��Ŷ��󣬺�����Ҫ����[AddWindows/AddDateTime��]
//  RootType ������ΪROOT_PLAY_OBJECT
//  ActionMode ������Ϊ0
//  ChapterIndex Ҫ���µĽ�Ŀ���
//  RegionIndex Ҫ���µķ������
//  LeafIndex Ҫ���µ�ҳ�����
//  ObjectIndex Ҫ���µĶ������
//  ColorMode ͬMakeRoot�еĶ���
long (_stdcall *MakeObject)(long RootType, long ActionMode, long ChapterIndex, long RegionIndex, long LeafIndex, long ObjectIndex, long ColorMode);

//��ӽ�Ŀ
//  num ��Ŀ���ݻ�������ţ���MakeRoot�ķ���ֵ
//  time ���ŵ�ʱ�䳤��
//  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
//                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һ��Ŀ
long (_stdcall *AddChapter)(WORD num, DWORD time, WORD wait); //timeΪ����
//  priority ���ȼ�0-2
//  kind ���żƻ�ģʽ  =0ʼ�ղ���  =1��ÿ�����첥��  =2����ʼʱ�䲥��
//  week �ܶ���  bit0��bit6����ʾ���յ����� ��kind=1ʱ��Ч
//  fromtime ��ʼʱ��  ��kind=1ʱ��ֻʱ�䲿����Ч����kind=2ʱ������ʱ��ȫ��Ч
//  totime ����ʱ��  ��kind=1ʱ��ֻʱ�䲿����Ч����kind=2ʱ������ʱ��ȫ��Ч
long (_stdcall *AddChapterEx2)(WORD num, DWORD time, WORD wait, WORD priority, WORD kind, WORD week, char* fromtime, char* totime); //timeΪ����

//��ӷ���
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  border ��ˮ�߿�
long (_stdcall *AddRegion)(WORD num, long left, long top, long width, long height, long border);

//���ҳ��
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion�ķ���ֵ
//  time ���ŵ�ʱ�䳤��
//  wait �ȴ�ģʽ��=WAIT_CHILD����ʾ���ﵽ����ʱ�䳤��ʱ����Ҫ�ȴ��ӽ�Ŀ����������л���
//                 =WAIT_USE_TIME����ʾ���ﵽ����ʱ�䳤��ʱ�����ȴ��ӽ�Ŀ������ɣ�ֱ���л���һҳ��
long (_stdcall *AddLeaf)(WORD num, DWORD time, WORD wait); //timeΪ����

//�������ʱ����ʾ
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
//  border ��ˮ�߿�(δʵ��)
//  fontname ��������
//  fontsize �����С
//  fontcolor ������ɫ
//  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
//  year_offset ��ƫ����
//  month_offset ��ƫ����
//  day_offset ��ƫ����
//  sec_offset ��ƫ����
//  format ��ʾ��ʽ 
//      #y��ʾ�� #m��ʾ�� #d��ʾ�� #h��ʾʱ #n��ʾ�� #s��ʾ�� #w��ʾ���� #c��ʾũ��
//      ������ format="#y��#m��#d�� #hʱ#n��#s�� ����#w ũ��#c"ʱ����ʾΪ"2009��06��27�� 12ʱ38��45�� ������ ũ�����³���"
long (_stdcall *AddDateTime)(WORD num, long left, long top, long width, long height, long transparent, long border,
		char* fontname, long fontsize, long fontcolor, long fontstyle, 
        long year_offset, long month_offset, long day_offset, long sec_offset, char* format);

//�����սʱ����ʾ
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
//  border ��ˮ�߿�(δʵ��)
//  fontname ��������
//  fontsize �����С
//  fontcolor ������ɫ
//  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
//  format ��ʾ��ʽ 
//      #y��ʾ�� #m��ʾ�� #d��ʾ�� #h��ʾʱ #n��ʾ�� #s��ʾ��
//  basetime ��սʱ��
//  fromtime ��ʼʱ��
//  totime ����ʱ��
//  step ��ʱ����ʱ�䲽�������ٺ�����һ�룩
long (_stdcall *AddCampaignEx)(WORD num, long left, long top, long width, long height, long transparent, long border, 
		char* fontname, long fontsize, long fontcolor, long fontstyle, 
		char* format, PTimeStamp basetime, PTimeStamp fromtime, PTimeStamp totime, long step);

//���ģ��ʱ��
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
//  border ��ˮ�߿�(δʵ��)
//  offset ��ƫ����
//  bkcolor: ������ɫ
//  framecolor: �����ɫ
//  framewidth: �����ɫ
//  frameshape: �����״ =0��ʾ�����Σ�=1��ʾԲ�Ƿ��Σ�=2��ʾԲ��
//  dotradius: �̶Ⱦ���������İ뾶
//  adotwidth: 0369��̶ȴ�С
//  adotcolor: 0369��̶���ɫ
//  bdotwidth: ������̶ȴ�С
//  bdotcolor: ������̶���ɫ
//  hourwidth: ʱ���ϸ
//  hourcolor: ʱ����ɫ
//  minutewidth: �����ϸ
//  minutecolor: ������ɫ
//  secondwidth: �����ϸ
//  secondcolor: ������ɫ
long (_stdcall *AddClock)(WORD num, long left, long top, long width, long height, long transparent, long border, long offset,
		DWORD bkcolor, DWORD framecolor, DWORD framewidth, long frameshape,
		long dotradius, long adotwidth, DWORD adotcolor, long bdotwidth, DWORD bdotcolor,
        long hourwidth, DWORD hourcolor, long minutewidth, DWORD minutecolor, long secondwidth, DWORD secondcolor);

//��Ӷ���
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
//  border ��ˮ�߿�(δʵ��)
//  filename avi�ļ���
//  stretch: ͼ���Ƿ���������Ӧ�����С
long (_stdcall *AddMovie)(WORD num, long left, long top, long width, long height, long transparent, long border, char* filename, long stretch);

//���ͼƬ�鲥��
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
//  border ��ˮ�߿�(δʵ��)
long (_stdcall *AddWindows)(WORD num, long left, long top, long width, long height, long transparent, long border);

//���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  dc ԴͼƬDC���
//  width ͼƬ���
//  height ͼƬ�߶�
//  inmethod ���뷽ʽ(�������б�˵��)
//  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  outmethod ������ʽ(�������б�˵��)
//  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stopmethod ͣ����ʽ(�������б�˵��)
//  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stoptime ͣ��ʱ��(��λ����)
long (_stdcall *AddChildWindow)(WORD num, HDC dc, long width, long height, long alignment, long inmethod, long inspeed, long outmethod, long outspeed, long stopmethod, long stopspeed, long stoptime); //stoptime��λΪ��

//���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  filename ͼƬ�ļ���
//  inmethod ���뷽ʽ(�������б�˵��)
//  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  outmethod ������ʽ(�������б�˵��)
//  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stopmethod ͣ����ʽ(�������б�˵��)
//  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stoptime ͣ��ʱ��(��λ����)
long (_stdcall *AddChildPicture)(WORD num, char* filename, long alignment, long inmethod, long inspeed, long outmethod, long outspeed, long stopmethod, long stopspeed, long stoptime); //stoptime��λΪ��

//���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  str �����ַ���
//  fontname ��������
//  fontsize �����С
//  fontcolor ������ɫ
//  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
//  wordwrap �Ƿ��Զ����� =1�Զ����У�=0���Զ�����
//  inmethod ���뷽ʽ(�������б�˵��)
//  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  outmethod ������ʽ(�������б�˵��)
//  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stopmethod ͣ����ʽ(�������б�˵��)
//  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stoptime ͣ��ʱ��(��λ����)
long (_stdcall *AddChildText)(WORD num, char* str, char* fontname, long fontsize, long fontcolor, long fontstyle, long wordwrap, long alignment, long inmethod, long inspeed, long outmethod, long outspeed, long stopmethod, long stopspeed, long stoptime); //stoptime��λΪ����

//������������鲥��
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
//  border ��ˮ�߿�(δʵ��)
long (_stdcall *AddStrings)(WORD num, long left, long top, long width, long height, long transparent, long border);

//���ͼƬ�����ͼƬ �˺���Ҫ����AddWindows�������
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  str �����ַ���
//  fontset �ֿ� =FONTSET_16P��ʾ16�����ֿ⣻=FONTSET_24P��ʾ24�����ֿ�
//  color ��ɫ
//  inmethod ���뷽ʽ(�������б�˵��)
//  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  outmethod ������ʽ(�������б�˵��)
//  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stopmethod ͣ����ʽ(�������б�˵��)
//  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stoptime ͣ��ʱ��(��λ����)
long (_stdcall *AddChildString)(WORD num, char* str, long fontset, long color, long inmethod, long inspeed, long outmethod, long outspeed, long stopmethod, long stopspeed, long stoptime); //stoptime��λΪ����

//���ͼƬ���󲥷�
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
//  border ��ˮ�߿�(δʵ��)
//  dc ԴͼƬDC���
//  src_width ͼƬ���
//  src_height ͼƬ�߶�
//  inmethod ���뷽ʽ(�������б�˵��)
//  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  outmethod ������ʽ(�������б�˵��)
//  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stopmethod ͣ����ʽ(�������б�˵��)
//  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stoptime ͣ��ʱ��(��λ����)
long (_stdcall *AddWindow)(WORD num, long left, long top, long width, long height, long transparent, long border,
		HDC dc, long src_width, long src_height, long alignment, long inmethod, long inspeed, long outmethod, long outspeed, long stopmethod, long stopspeed, long stoptime); //stoptime��λΪ����

//���ͼƬ�ļ�����
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
//  border ��ˮ�߿�(δʵ��)
//  filename ͼƬ�ļ�
//  inmethod ���뷽ʽ(�������б�˵��)
//  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  outmethod ������ʽ(�������б�˵��)
//  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stopmethod ͣ����ʽ(�������б�˵��)
//  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stoptime ͣ��ʱ��(��λ����)
long (_stdcall *AddPicture)(WORD num, long left, long top, long width, long height, long transparent, long border,
		char* filename, long alignment, long inmethod, long inspeed, long outmethod, long outspeed, long stopmethod, long stopspeed, long stoptime); //stoptime��λΪ����

//������ֲ���
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
//  border ��ˮ�߿�(δʵ��)
//  str �����ַ���
//  fontname ��������
//  fontsize �����С
//  fontcolor ������ɫ
//  fontstyle ������ʽ ������=WFS_BOLD��ʾ���壻=WFS_ITALIC��ʾб�壻=WFS_BOLD+WFS_ITALIC��ʾ��б��
//  wordwrap �Ƿ��Զ����� =1�Զ����У�=0���Զ�����
//  alignment ���뷽ʽ 0���� 1���� 2����
//  inmethod ���뷽ʽ(�������б�˵��)
//  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  outmethod ������ʽ(�������б�˵��)
//  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stopmethod ͣ����ʽ(�������б�˵��)
//  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stoptime ͣ��ʱ��(��λ����)
long (_stdcall *AddText)(WORD num, long left, long top, long width, long height, long transparent, long border,
		char* str, char* fontname, long fontsize, long fontcolor, long fontstyle, long wordwrap, long alignment, 
		long inmethod, long inspeed, long outmethod, long outspeed, long stopmethod, long stopspeed, long stoptime); //stoptime��λΪ����
//������ֲ���(��ǿ)
//  ͬ����������ͬ��
//  bkcolor ����ɫ(˫ɫ��������)
//  vertical ��0
//  verspace �м��
//  horfit �����Լ������Ӧ  0���� 1����
long (_stdcall *AddTextEx2)(WORD num, long left, long top, long width, long height, long transparent, long border,
		char* str, char* fontname, long fontsize, long fontcolor, long fontstyle, long bkcolor, long wordwrap, 
		long vertical, long alignment, long verspace, long horfit, 
		long inmethod, long inspeed, long outmethod, long outspeed, long stopmethod, long stopspeed, long stoptime); //stoptime��λΪ����

//����������ֲ���
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
//  border ��ˮ�߿�(δʵ��)
//  str �����ַ���
//  fontset �ֿ� =FONTSET_16P��ʾ16�����ֿ⣻=FONTSET_24P��ʾ24�����ֿ�
//  color ��ɫ
//  inmethod ���뷽ʽ(�������б�˵��)
//  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  outmethod ������ʽ(�������б�˵��)
//  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stopmethod ͣ����ʽ(�������б�˵��)
//  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stoptime ͣ��ʱ��(��λ����)
long (_stdcall *AddString)(WORD num, long left, long top, long width, long height, long transparent, long border,
		char* str, long fontset, long color, long inmethod, long inspeed, long outmethod, long outspeed, long stopmethod, long stopspeed, long stoptime); //stoptime��λΪ����

//��ӱ��
//  num ��Ŀ���ݻ�������ţ���MakeRoot��MakeChapter��MakeRegion��MakeLeaf��MakeObject�ķ���ֵ
//  left��top��width��height ���ϡ���ȡ��߶�
//  transparent �Ƿ�͸�� =1��ʾ͸����=0��ʾ��͸��
//  profile ��������ļ�
//  content �������
//  inmethod ���뷽ʽ(�������б�˵��)
//  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  outmethod ������ʽ(�������б�˵��)
//  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stopmethod ͣ����ʽ(�������б�˵��)
//  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stoptime ͣ��ʱ��(��λ����)
long (_stdcall *AddTable)(WORD num, long left, long top, long width, long height, long transparent, char* profile, char* content,
            long inmethod, long inspeed, long outmethod, long outspeed, long stopmethod, long stopspeed, long stoptime);

///////////////////////////////////////////////////////////////////////////////////////////////////
// �����˲��г���Ŀר�Ŷ���
//�������ֲ��Ŷ���
//  ObjectIndex ��Ҫ�����滻���Ķ�����
//  width ������
//  height ����߶�
//  str �����ַ���
//  fontname ��������
//  fontsize �����С
//  fontcolor ������ɫ
//  FontStyle ��������
//  wordwrap �Զ�����
//  alignment ���뷽ʽ
//  inmethod ���뷽ʽ(�������б�˵��)
//  inspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  outmethod ������ʽ(�������б�˵��)
//  outspeed �����ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stopmethod ͣ����ʽ(�������б�˵��)
//  stopspeed ͣ���ٶ�(ȡֵ��Χ0-5���ӿ쵽��)
//  stoptime ͣ��ʱ��(��λ����)
//  istitle �Ƿ����
long (_stdcall *SZRC_MakeTextObject)(long ObjectIndex, long width, long height, 
		char* str, char* fontname, long fontsize, long fontcolor, long fontstyle, long wordwrap, long alignment,
		long inmethod, long inspeed, long outmethod, long outspeed, long stopmethod, long stopspeed, long stoptime, long istitle);

// ====���붯����ʽ�б�(��ֵ��0��ʼ)====
//    0 = '���',
//    1 = '������ʾ',
//    2 = '�����ʾ',
//    3 = '�Ϲ���ʾ',
//    4 = '�ҹ���ʾ',
//    5 = '�¹���ʾ',
//    6 = '���������ʾ',
//    7 = '�����Ϲ���ʾ',
//    8 = '�м�������չ��',
//    9 = '�м�������չ��',
//   10 = '�м�������չ��',
//   11 = '������������',
//   12 = '������������',
//   13 = '��������չ��',
//   14 = '��������չ��',
//   15 = '�����Ͻ�����',
//   16 = '�����½�����',
//   17 = '�����Ͻ�����',
//   18 = '�����½�����',
//   19 = '������������',
//   20 = '������������',
//   21 = '�����Ҷ��',
//   22 = '�����Ҷ��',
// =====================================

// ====����������ʽ�б�(��ֵ��0��ʼ)====
//    0 = '���',
//    1 = '����ʧ',
//    2 = '������ʧ',
//    3 = '�������м��£',
//    4 = '�������м��£',
//    5 = '�������м��£',
//    6 = '���������Ƴ�',
//    7 = '���������Ƴ�',
//    8 = '���������£',
//    9 = '�������Һ�£',
//   10 = '�����Ͻ��Ƴ�',
//   11 = '�����½��Ƴ�',
//   12 = '�����Ͻ��Ƴ�',
//   13 = '�����½��Ƴ�',
//   14 = '���������Ƴ�',
//   15 = '���������Ƴ�',
//   16 = '�����Ҷ��',
//   17 = '�����Ҷ��'
// =====================================

// ====ͣ��������ʽ�б�(��ֵ��0��ʼ)====
//    0 = '��̬��ʾ',
//    1 = '��˸��ʾ'
// =====================================

HINSTANCE hInstance;

void LED_Initialize(void)
{
  if ((hInstance=LoadLibrary("LEDSender2010.dll"))!=NULL)
  {
    LED_Startup=(long (_stdcall *)(void))GetProcAddress(hInstance,"LED_Startup");
    LED_Cleanup=(long (_stdcall *)(void))GetProcAddress(hInstance,"LED_Cleanup");

    LED_Preview=(void (_stdcall *)(long, long, long, char*))GetProcAddress(hInstance,"LED_Preview");

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //���߿��ƿ��б���ؽӿں���
    LED_Report_CreateServer=(long (_stdcall *)(long, long))GetProcAddress(hInstance,"LED_Report_CreateServer");
	LED_Report_RemoveServer=(void (_stdcall *)(long))GetProcAddress(hInstance,"LED_Report_RemoveServer");
	LED_Report_RemoveAllServer=(void (_stdcall *)(void))GetProcAddress(hInstance,"LED_Report_RemoveAllServer");
	LED_Report_GetOnlineList=(long (_stdcall *)(long, void*, long))GetProcAddress(hInstance,"LED_Report_GetOnlineList");
	LED_Report_GetOnlineItemName=(char* (_stdcall *)(long, long))GetProcAddress(hInstance,"LED_Report_GetOnlineItemName");
	LED_Report_GetOnlineItemHost=(char* (_stdcall *)(long, long))GetProcAddress(hInstance,"LED_Report_GetOnlineItemHost");
	LED_Report_GetOnlineItemPort=(long (_stdcall *)(long, long))GetProcAddress(hInstance,"LED_Report_GetOnlineItemPort");
	LED_Report_GetOnlineItemAddr=(long (_stdcall *)(long, long))GetProcAddress(hInstance,"LED_Report_GetOnlineItemAddr");
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    LED_ResetDisplay=(long (_stdcall *)(PSenderParam))GetProcAddress(hInstance,"LED_ResetDisplay");
    LED_AdjustTime=(long (_stdcall *)(PSenderParam))GetProcAddress(hInstance,"LED_AdjustTime");
    LED_AdjustTimeEx=(long (_stdcall *)(PSenderParam, LPSYSTEMTIME))GetProcAddress(hInstance,"LED_AdjustTimeEx");
    LED_SetCurChapter=(long (_stdcall *)(PSenderParam, long))GetProcAddress(hInstance,"LED_SetCurChapter");
    LED_GetCurChapter=(long (_stdcall *)(PSenderParam))GetProcAddress(hInstance,"LED_GetCurChapter");
    LED_SetPower=(long (_stdcall *)(PSenderParam, long))GetProcAddress(hInstance,"LED_SetPower");
    LED_GetPower=(long (_stdcall *)(PSenderParam))GetProcAddress(hInstance,"LED_GetPower");
    LED_SetBright=(long (_stdcall *)(PSenderParam, long))GetProcAddress(hInstance,"LED_SetBright");
    LED_GetBright=(long (_stdcall *)(PSenderParam))GetProcAddress(hInstance,"LED_GetBright");
    LED_SetPowerSchedule=(long (_stdcall *)(PSenderParam, PPowerSchedule))GetProcAddress(hInstance,"LED_SetPowerSchedule");
    LED_GetPowerSchedule=(long (_stdcall *)(PSenderParam))GetProcAddress(hInstance,"LED_GetPowerSchedule");
    LED_SetBrightSchedule=(long (_stdcall *)(PSenderParam, PBrightSchedule))GetProcAddress(hInstance,"LED_SetBrightSchedule");
    LED_GetBrightSchedule=(long (_stdcall *)(PSenderParam))GetProcAddress(hInstance,"LED_GetBrightSchedule");
    LED_SendToScreen=(long (_stdcall *)(PSenderParam, long))GetProcAddress(hInstance,"LED_SendToScreen");
    LED_ComTransfer=(long (_stdcall *)(PSenderParam, BYTE*, DWORD))GetProcAddress(hInstance,"LED_ComTransfer");

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //�˴���֮ǰͬ������������ͬ��ֻ�ǽ��ṹ��ָ�������ֳɶ����������������PB��java�ȿ������Ե���
    LED_UDP_SenderParam=(long (_stdcall *)(long, long, char*, long, long, long, long, long))GetProcAddress(hInstance,"LED_UDP_SenderParam");
    LED_COM_SenderParam=(long (_stdcall *)(long, long, long, long, long, long, long))GetProcAddress(hInstance,"LED_COM_SenderParam");
	LED_UDP_SenderParam_ByReportName=(long (_stdcall *)(long, long, long, char*, long, long, long))GetProcAddress(hInstance,"LED_UDP_SenderParam_ByReportName");
    LED_ResetDisplay2=(long (_stdcall *)(long))GetProcAddress(hInstance,"LED_ResetDisplay2");
    LED_AdjustTime2=(long (_stdcall *)(long))GetProcAddress(hInstance,"LED_AdjustTime2");
    LED_AdjustTimeEx2=(long (_stdcall *)(long, LPSYSTEMTIME))GetProcAddress(hInstance,"LED_AdjustTimeEx2");
    LED_SetCurChapter2=(long (_stdcall *)(long, long))GetProcAddress(hInstance,"LED_SetCurChapter2");
    LED_SetPower2=(long (_stdcall *)(long, long))GetProcAddress(hInstance,"LED_SetPower2");
    LED_GetPower2=(long (_stdcall *)(long))GetProcAddress(hInstance,"LED_GetPower2");
    LED_SetBright2=(long (_stdcall *)(long, long))GetProcAddress(hInstance,"LED_SetBright2");
    LED_GetBright2=(long (_stdcall *)(long))GetProcAddress(hInstance,"LED_GetBright2");
    LED_SetPowerSchedule2=(long (_stdcall *)(long, PPowerSchedule))GetProcAddress(hInstance,"LED_SetPowerSchedule2");
    LED_GetPowerSchedule2=(long (_stdcall *)(long))GetProcAddress(hInstance,"LED_GetPowerSchedule2");
    LED_SetBrightSchedule2=(long (_stdcall *)(long, PBrightSchedule))GetProcAddress(hInstance,"LED_SetBrightSchedule2");
    LED_GetBrightSchedule2=(long (_stdcall *)(long))GetProcAddress(hInstance,"LED_GetBrightSchedule2");
    LED_SendToScreen2=(long (_stdcall *)(long, long))GetProcAddress(hInstance,"LED_SendToScreen2");
    LED_ComTransfer2=(long (_stdcall *)(long, BYTE*, DWORD))GetProcAddress(hInstance,"LED_ComTransfer2");

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	//��ȡ���ƿ�����
    LED_Cache_GetBoardParam=(long (_stdcall *)(PSenderParam))GetProcAddress(hInstance,"LED_Cache_GetBoardParam");
    LED_Cache_GetBoardParam2=(long (_stdcall *)(long))GetProcAddress(hInstance,"LED_Cache_GetBoardParam2");
	//��ȡ��������
    LED_Cache_GetBoardParam_SaveToFile=(long (_stdcall *)(char*))GetProcAddress(hInstance,"LED_Cache_GetBoardParam_SaveToFile");
    LED_Cache_GetBoardParam_IP=(char* (_stdcall *)(void))GetProcAddress(hInstance,"LED_Cache_GetBoardParam_IP");
    LED_Cache_GetBoardParam_Mac=(char* (_stdcall *)(void))GetProcAddress(hInstance,"LED_Cache_GetBoardParam_Mac");
    LED_Cache_GetBoardParam_Addr=(long (_stdcall *)(void))GetProcAddress(hInstance,"LED_Cache_GetBoardParam_Addr");
    LED_Cache_GetBoardParam_Width=(long (_stdcall *)(void))GetProcAddress(hInstance,"LED_Cache_GetBoardParam_Width");
    LED_Cache_GetBoardParam_Height=(long (_stdcall *)(void))GetProcAddress(hInstance,"LED_Cache_GetBoardParam_Height");
    LED_Cache_GetBoardParam_Brightness=(long (_stdcall *)(void))GetProcAddress(hInstance,"LED_Cache_GetBoardParam_Brightness");
	//�޸ĸ�������
    LED_Cache_SetBoardParam_LoadFromFile=(long (_stdcall *)(char*))GetProcAddress(hInstance,"LED_Cache_SetBoardParam_LoadFromFile");
    LED_Cache_SetBoardParam_IP=(void (_stdcall *)(char*))GetProcAddress(hInstance,"LED_Cache_SetBoardParam_IP");
    LED_Cache_SetBoardParam_Mac=(void (_stdcall *)(char*))GetProcAddress(hInstance,"LED_Cache_SetBoardParam_Mac");
    LED_Cache_SetBoardParam_Addr=(void (_stdcall *)(long))GetProcAddress(hInstance,"LED_Cache_SetBoardParam_Addr");
    LED_Cache_SetBoardParam_Width=(void (_stdcall *)(long))GetProcAddress(hInstance,"LED_Cache_SetBoardParam_Width");
    LED_Cache_SetBoardParam_Height=(void (_stdcall *)(long))GetProcAddress(hInstance,"LED_Cache_SetBoardParam_Height");
    LED_Cache_SetBoardParam_Brightness=(void (_stdcall *)(long))GetProcAddress(hInstance,"LED_Cache_SetBoardParam_Brightness");
	//���޸ĺ�Ĳ���������ƿ�
    LED_Cache_SetBoardParam=(long (_stdcall *)(PSenderParam))GetProcAddress(hInstance,"LED_Cache_SetBoardParam");
    LED_Cache_SetBoardParam2=(long (_stdcall *)(long))GetProcAddress(hInstance,"LED_Cache_SetBoardParam2");

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    LED_GetNotifyParam=(long (_stdcall *)(PNotifyParam, long))GetProcAddress(hInstance,"LED_GetNotifyParam");

    MakeFromVsqFile=(long (_stdcall *)(char*, long, long, long))GetProcAddress(hInstance,"MakeFromVsqFile");
    MakeRoot=(long (_stdcall *)(long, long, long))GetProcAddress(hInstance,"MakeRoot");
    MakeChapter=(long (_stdcall *)(long, long, long, long, DWORD, WORD))GetProcAddress(hInstance,"MakeChapter");
    MakeRegion=(long (_stdcall *)(long, long, long, long, long, long, long, long, long, long))GetProcAddress(hInstance,"MakeRegion");
    MakeLeaf=(long (_stdcall *)(long, long, long, long, long, long, DWORD, WORD))GetProcAddress(hInstance,"MakeLeaf");
    MakeObject=(long (_stdcall *)(long, long, long, long, long, long, long))GetProcAddress(hInstance,"MakeObject");

    AddChapter=(long (_stdcall *)(WORD, DWORD, WORD))GetProcAddress(hInstance,"AddChapter");
    AddChapterEx2=(long (_stdcall *)(WORD, DWORD, WORD, WORD, WORD, WORD, char*, char*))GetProcAddress(hInstance,"AddChapterEx2");
    AddRegion=(long (_stdcall *)(WORD, long, long, long, long, long))GetProcAddress(hInstance,"AddRegion");
    AddLeaf=(long (_stdcall *)(WORD, DWORD, WORD))GetProcAddress(hInstance,"AddLeaf");

    AddDateTime=(long (_stdcall *)(WORD, long, long, long, long, long, long, char*, long, long, long, long, long, long, long, char*))GetProcAddress(hInstance,"AddDateTime");
	AddCampaignEx=(long (_stdcall *)(WORD, long, long, long, long, long, long, char*, long, long, long, char*, PTimeStamp, PTimeStamp, PTimeStamp, long))GetProcAddress(hInstance,"AddCampaignEx");
    AddClock=(long (_stdcall *)(WORD, long, long, long, long, long, long, long, DWORD, DWORD, DWORD, long, long, long, DWORD, long, DWORD, long, DWORD, long, DWORD, long, DWORD))GetProcAddress(hInstance,"AddClock");
    AddMovie=(long (_stdcall *)(WORD, long, long, long, long, long, long, char*, long))GetProcAddress(hInstance,"AddMovie");

    AddWindows=(long (_stdcall *)(WORD, long, long, long, long, long, long))GetProcAddress(hInstance,"AddWindows");
    AddChildWindow=(long (_stdcall *)(WORD, HDC, long, long, long, long, long, long, long, long, long, long))GetProcAddress(hInstance,"AddChildWindow");
    AddChildPicture=(long (_stdcall *)(WORD, char*, long, long, long, long, long, long, long, long))GetProcAddress(hInstance,"AddChildPicture");
    AddChildText=(long (_stdcall *)(WORD, char*, char*, long, long, long, long, long, long, long, long, long, long, long, long))GetProcAddress(hInstance,"AddChildText");
    AddStrings=(long (_stdcall *)(WORD, long, long, long, long, long, long))GetProcAddress(hInstance,"AddStrings");
    AddChildString=(long (_stdcall *)(WORD, char*, long, long, long, long, long, long, long, long, long))GetProcAddress(hInstance,"AddChildString");

    AddWindow=(long (_stdcall *)(WORD, long, long, long, long, long, long, HDC, long, long, long, long, long, long, long, long, long, long))GetProcAddress(hInstance,"AddWindow");
    AddPicture=(long (_stdcall *)(WORD, long, long, long, long, long, long, char*, long, long, long, long, long, long, long, long))GetProcAddress(hInstance,"AddPicture");
    AddText=(long (_stdcall *)(WORD, long, long, long, long, long, long, char*, char*, long, long, long, long, long, long, long, long, long, long, long, long))GetProcAddress(hInstance,"AddText");
    AddTextEx2=(long (_stdcall *)(WORD, long, long, long, long, long, long, char*, char*, long, long, long, long, long, long, long, long, long, long, long, long, long, long, long, long))GetProcAddress(hInstance,"AddTextEx2");
    AddString=(long (_stdcall *)(WORD, long, long, long, long, long, long, char*, long, long, long, long, long, long, long, long, long))GetProcAddress(hInstance,"AddString");
    AddTable=(long (_stdcall *)(WORD, long, long, long, long, long, char*, char*, long, long, long, long, long, long, long))GetProcAddress(hInstance,"AddTable");

	if (LED_Startup) LED_Startup();
  }
}

void LED_Destroy(void)
{
	if (hInstance!=NULL) 
	{
		LED_Cleanup();
		FreeLibrary(hInstance);
	}
}

#endif