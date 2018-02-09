
public class LEDSender2010 {

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
	
	public static final int PKP_PREFIX = 0x55;
	public static final int PKP_SUFFIX = 0xAA;
	public static final int PKP_FILLCH = 0xBB;

	public static final int ROOT_PLAY = 0x21;
	public static final int ROOT_DOWNLOAD = 0x22;

	public static final int COLOR_TYPE_DOUBLE = 0x2;
	public static final int COLOR_TYPE_THREE = 0x3;
	public static final int COLOR_TYPE_FULL = 0x4;

	public static final int PKC_BEGIN = 0;
	public static final int PKC_END = 1;
	public static final int PKC_DATA = 2;
	public static final int PKC_RESPOND = 3;

	public static final int PKC_ADJUST_TIME = 6;
	public static final int PKC_GET_PARAM = 7;
	public static final int PKC_SET_PARAM = 8;
	public static final int PKC_GET_POWER = 9;
	public static final int PKC_SET_POWER = 10;
	public static final int PKC_GET_BRIGHT = 11;
	public static final int PKC_SET_BRIGHT = 12;
	public static final int PKC_GET_POWER_SCHEDULE = 60;
	public static final int PKC_SET_POWER_SCHEDULE = 61;
	
	public static final int OBJECT_CHAPTER = 0x3F;
	public static final int OBJECT_REGION = 0x3E;
	public static final int OBJECT_LEAF = 0x30;
	public static final int OBJECT_WINDOW = 0x31;
	public static final int OBJECT_STRING = 0x33;
	public static final int OBJECT_STRING_DCLOCK = 0x35;
	public static final int OBJECT_PIXELS = 0x36;
	public static final int OBJECT_PIXELSSET = 0x37;
	public static final int OBJECT_STRINGS = 0x3C;
	
	public static final int DF_YEAR = 1;
	public static final int DF_MONTH = 2;
	public static final int DF_DAY = 3;
	public static final int DF_WEEK = 4;
	public static final int DF_HOUR = 5;
	public static final int DF_MINUTE = 6;
	public static final int DF_SECOND = 7;
	public static final int DF_USER = 8;

	/*
	typedef struct PKG_HEADER{
			WORD   Command;
			BYTE   srcAddr;
			BYTE   dstAddr;
			DWORD  SerialNo;
	}TPKG_Header, *PPKG_Header;
	*/
	static final int PKG_HEADER_STRUCT_SIZE = 8; //2+1+1+4
	static final int PKG_HEADER_COMMAND_OFFSET = 0;
	static final int PKG_HEADER_SRCADDR_OFFSET = 2;
	static final int PKG_HEADER_DSTADDR_OFFSET = 3;
	static final int PKG_HEADER_SERIALNO_OFFSET = 4;
	/*
	typedef struct _SYSTEMTIME {
	    WORD wYear;
	    WORD wMonth;
	    WORD wDayOfWeek;
	    WORD wDay;
	    WORD wHour;
	    WORD wMinute;
	    WORD wSecond;
	    WORD wMilliseconds;
	} SYSTEMTIME, *PSYSTEMTIME, *LPSYSTEMTIME;
	*/
	static final int SYSTEMTIME_SIZE = 16;
	static final int SYSTEMTIME_YEAR_OFFSET = 0;
	static final int SYSTEMTIME_MONTH_OFFSET = 2;
	static final int SYSTEMTIME_WEEK_OFFSET = 4;
	static final int SYSTEMTIME_DAY_OFFSET = 6;
	static final int SYSTEMTIME_HOUR_OFFSET = 8;
	static final int SYSTEMTIME_MINUTE_OFFSET = 10;
	static final int SYSTEMTIME_SECOND_OFFSET = 12;
	static final int SYSTEMTIME_MSECOND_OFFSET = 14;
	/*
	TPowerSchedule = packed record
	    Enabled:    DWord;
	    Mode:       DWord;
	    OpenTime:   array [0..20] of TTimeStamp;
	    CloseTime:  array [0..20] of TTimeStamp;
	    Checksum:   DWord;
	end;
	PPowerSchedule = ^TPowerSchedule;
	*/
	static final int PWOERSCHEDULE_SIZE = 348;
	static final int PWOERSCHEDULE_ENABLED_OFFSET = 0;
	static final int PWOERSCHEDULE_MODE_OFFSET = 4;
	static final int PWOERSCHEDULE_OPENTIME_OFFSET = 8;
	static final int PWOERSCHEDULE_CLOSETIME_OFFSET = 176;
	static final int PWOERSCHEDULE_SUNDAY_OPENTIME_OFFSET = 8;
	static final int PWOERSCHEDULE_SUNDAY_CLOSETIME_OFFSET = 176;
	static final int PWOERSCHEDULE_MONDAY_OPENTIME_OFFSET = 32;
	static final int PWOERSCHEDULE_MONDAY_CLOSETIME_OFFSET = 200;
	static final int PWOERSCHEDULE_TUESDAY_OPENTIME_OFFSET = 56;
	static final int PWOERSCHEDULE_TUESDAY_CLOSETIME_OFFSET = 224;
	static final int PWOERSCHEDULE_WEDNESDAY_OPENTIME_OFFSET = 80;
	static final int PWOERSCHEDULE_WEDNESDAY_CLOSETIME_OFFSET = 248;
	static final int PWOERSCHEDULE_THURSDAY_OPENTIME_OFFSET = 104;
	static final int PWOERSCHEDULE_THURSDAY_CLOSETIME_OFFSET = 272;
	static final int PWOERSCHEDULE_FRIDAY_OPENTIME_OFFSET = 128;
	static final int PWOERSCHEDULE_FRIDAY_CLOSETIME_OFFSET = 296;
	static final int PWOERSCHEDULE_SATURDAY_OPENTIME_OFFSET = 152;
	static final int PWOERSCHEDULE_SATURDAY_CLOSETIME_OFFSET = 320;

	/*
	//������ͷ��
	typedef struct ROOT{
		  WORD  id;              
		  WORD  color;           
		  DWORD size;            
		  DWORD count;           
		  long  survive;         
		  WORD  flag;            
		  WORD  Reserved;
		}TRoot, *PRoot;
	*/
	static final int ROOT_STRUCT_SIZE = 20; //2+2+4+4+4+2+2
	static final int ROOT_SIZE_OFFSET = 4;
	static final int ROOT_COUNT_OFFSET = 8;
	static final int ROOT_SURVIVE_OFFSET = 12;
	static final int ROOT_COLORTYPE_OFFSET = 2;
	/*
	typedef struct PLAYSCHEDULE{
	  WORD  kind;           //���żƻ�����0=ʼ�ղ��ţ�1=��ÿ����ֹʱ�䲥�ţ�3=��ָ������ֹ����ʱ�䲥��
	  WORD  week;           //�����յ���������Ч
	  TTimeStamp fromtime;  //��ʼʱ��
	  TTimeStamp totime;    //����ʱ��
	}TPlaySchedule, *PPlaySchedule;
	//�½����ݽṹ��
	typedef struct CHAPTER{
	  WORD  id;             //��ʶ����������У��
	  WORD  no;             //��Ŀ��ţ���0
	  WORD  wait;           //�Ƿ�ȴ��������(=1�ȴ�; =0��ʱ�����)
	  WORD  repeat;         //��Ŀ���Ŵ�����Ԥ��δʵ�֣���0
	  WORD  count;          //�߼��������� 
	  BYTE  compress;       //�Ƿ�ѹ����Ԥ��δʵ�֣���0
	  BYTE  priority;       //���ȼ���Ԥ��δʵ�֣���0
	  DWORD time;           //��Ŀ��ʾʱ������λ����
	  DWORD size;           //��ʶ�ý�Ŀ�ֽ���(���������ֽ����͸�Ԫ�ر����ֽ���֮��)
	  TPlaySchedule schedule; //���żƻ� 
	}TChapter, *PChapter;
	*/
	static final int CHAPTER_STRUCT_SIZE = 40; //2+2+2+2+2+1+1+4+4+20
	static final int CHAPTER_SIZE_OFFSET = 16;
	static final int CHAPTER_COUNT_OFFSET = 8;
	static final int CHAPTER_WAIT_OFFSET = 4;
	static final int CHAPTER_TIME_OFFSET = 12;
	/*
	//�������ݽṹ��
	typedef struct REGION{
	  WORD  id;             //��ʶ����������У��
	  WORD  no;             //�߼����ڱ�ţ���0
	  WORD  over;           //��Ŀ�Ƿ񲥷����(��modeΪ�ȴ����󲥷����ʱ�����ֶ���Ч���Լ�������ֶ���Ч)
	  WORD  count;          //ҳ����Ŀ
	  DWORD size;           //��ʶ���߼������ֽ���(���������ֽ����͸�Ԫ�ر����ֽ���֮��)
	  TRect rect;           //�߼�����λ�ô�С
	  BYTE  border; 
	  BYTE  Reserved1;
	  WORD  Reserved2;
	}TRegion, *PRegion;
	*/
	static final int REGION_STRUCT_SIZE = 32; //2+2+2+2+4+16+1+1+2
	static final int REGION_SIZE_OFFSET = 8;
	static final int REGION_COUNT_OFFSET = 6;
	static final int REGION_LEFT_OFFSET = 12;
	static final int REGION_TOP_OFFSET = 16;
	static final int REGION_RIGHT_OFFSET = 20;
	static final int REGION_BOTTOM_OFFSET = 24;
	/*
	//ҳ�����ݽṹ��
	typedef struct LEAF{
	  WORD  id;             //ҳ����(��ҳ���滻ʱ�����ݴ˱���滻)
	  WORD  no;
	  WORD  wait;           //�Ƿ�ȴ��������(=1�ȴ�; =0��ʱ�����)
	  WORD  serial;         //�Ƿ��з�ʽ���ţ���0
	  WORD  count;          //������Ŀ
	  WORD  Reserved;
	  DWORD time;           //ҳ����ʾʱ��
	  DWORD size;           //��ʶ��ҳ���ֽ���(���������ֽ����͸�Ԫ�ر����ֽ���֮��)
	  WORD  Reserved1;
	  WORD  Reserved2;
	}TLeaf, *PLeaf;
	*/
	static final int LEAF_STRUCT_SIZE = 24; //2+2+2+2+2+2+4+4+2+2
	static final int LEAF_SIZE_OFFSET = 16;
	static final int LEAF_COUNT_OFFSET = 8;
	static final int LEAF_WAIT_OFFSET = 4;
	static final int LEAF_TIME_OFFSET = 12;
	/*
	//����ͨ�����Խṹ��
	typedef struct OBJECT{
	  WORD  id;             //�����ʶ
	  BYTE  transparent;    //�Ƿ�͸��
	  BYTE  flag;           //һЩ����λ 
	  DWORD size;           //�����ֽ���
	  TRect rect;           //������ʾ����
	}TObject, *PObject;
	*/
	static final int OBJECT_STRUCT_SIZE = 24;  //2+1+1+4+16
	static final int OBJECT_TRANSPARENT_OFFSET = 2;
	static final int OBJECT_SIZE_OFFSET = 4;
	static final int OBJECT_LEFT_OFFSET = 8;
	static final int OBJECT_TOP_OFFSET = 12;
	static final int OBJECT_RIGHT_OFFSET = 16;
	static final int OBJECT_BOTTOM_OFFSET = 20;
	/*
	//�ಥ�Ŷ������ݽṹ����������TWindow������߶��TString����
	typedef struct WINDOWS{
	  TObject     object;     //�����һ�㶨��
	  BYTE        method;     //������ʽ
	  BYTE        speed;      //�����ٶ�
	  WORD        count;      //�����ĵ�Window����
	}TWindows, *PWindows;
	*/
	static final int STRINGS_STRUCT_SIZE = OBJECT_STRUCT_SIZE + 4;  //1+1+2
	static final int STRINGS_COUNT_OFFSET = OBJECT_STRUCT_SIZE + 2;
	/*
	//�������ֶ���
	typedef struct STRING{
	  WORD        id;
	  BYTE        inMethod;   //���뷽ʽ
	  BYTE        outMethod;  //������ʽ
	  BYTE        stopMethod; //ͣ����ʽ
	  BYTE        alignment;  //���뷽ʽ 
	  WORD        inSpeed;    //�����ٶ�
	  WORD        outSpeed;   //�����ٶ�
	  WORD        stopSpeed;  //ͣ���ٶ�(����Ϊ��˸ʱ����ʾ��˸�ٶ�)
	  DWORD       stoptime;   //ͣ��ʱ��
	  long        stopx;      //ͣ��λ��
	  DWORD       size;       //���ݳ���
	  DWORD       color;      //�ַ���ɫ
	  WORD        fontset;    //�ַ���(һ����� 0=16���� 1=24����)
	  WORD        Reserved2;
	}TString, *PString;
	*/
	static final int STRING_STRUCT_SIZE = 32;  //2+1+1+1+1+2+2+2+4+4+4+4+2+2
	static final int STRING_IN_METHOD_OFFSET = 2;
	static final int STRING_OUT_METHOD_OFFSET = 3;
	static final int STRING_STOP_METHOD_OFFSET = 4;
	static final int STRING_IN_SPEED_OFFSET = 6;
	static final int STRING_OUT_SPEED_OFFSET = 8;
	static final int STRING_STOP_SPEED_OFFSET = 10;
	static final int STRING_STOP_TIME_OFFSET = 12;
	static final int STRING_SIZE_OFFSET = 20;
	static final int STRING_COLOR_OFFSET = 24;
	static final int STRING_FONT_SET_OFFSET = 28;
	/*
	//��������ʱ�����
	typedef struct STRINGDCLOCK{
	  TObject     object;       //�����һ�㶨��
	  BYTE        type;         //���ͣ�����ʱ�䡢��սʱ��
	  BYTE        direct;       //����=0������=1��ʱ����ת90�ȣ�=2˳ʱ����ת90�� 
	  WORD        step;         //���� 
	  TTimeStamp  basetime;     //��׼ʱ��(��սʱ��ʹ��)
	  TTimeStamp  fromtime;     //��ʼʱ��(��սʱ��ʹ��)
	  TTimeStamp  totime;       //����ʱ��(��սʱ��ʹ��)
	  long        year_offset;  //��ƫ����
	  long        month_offset; //��ƫ����
	  long        day_offset;   //��ƫ����
	  long        time_offset;  //ʱ��ƫ����(����)
	  WORD        formats[MAX_DATETIME_FORMAT];  //��ʾ��ʽ[32]
	  DWORD       color;
	  BYTE        fontset;
	  BYTE        reserved;
	  WORD        reserved2;
	}TStringDClock, *PStringDClock;
	*/
	static final int SDCLOCK_STRUCT_SIZE = OBJECT_STRUCT_SIZE+116;  //2+1+1+1+1+2+2+2+4+4+4+4+2+2
	static final int SDCLOCK_FORMAT_OFFSET = 44;
	static final int SDCLOCK_COLOR_OFFSET = 108;
	static final int SDCLOCK_FONTSET_OFFSET = 112;


	/*
	typedef struct PKG_RESPOND{
		TPKG_Header Header;
		WORD Command;
		WORD Result;
	}TPKG_Respond, *PPKG_Respond;
	*/
	static final int RESPOND_STRUCT_SIZE = 12;
	static final int RESPOND_COMMAND_OFFSET = 0;
	static final int RESPOND_RESULT_OFFSET = 2;
	
	static int root_seek = -1;
	static int root_size = 0;
	static int root_count = 0;
	static int chapter_seek = -1;
	static int chapter_size = 0;
	static int chapter_count = 0;
	static int region_seek = -1;
	static int region_size = 0;
	static int region_count = 0;
	static int leaf_seek = -1;
	static int leaf_size = 0;
	static int leaf_count = 0;
	static int strings_seek = -1;
	static int strings_size = 0;
	static int strings_count = 0;
	static int data_seek = 0;

	public static byte[] data_stream;
	public static byte[] cmd_stream;
	public static byte[] packet_stream;
	public static int packet_size;
	
	public void print_stream(byte[] stream, int size){
		int i;
	    System.out.print("size="+size+"; "+"data=");    
		for (i=0; i<size; i++){
	        System.out.print(stream[i]);    
	        System.out.print(' ');    
		}
	    System.out.println();    
	}

	static byte lo_of_short(short value){
		return (byte)(value&0xFF);
	}

	static byte hi_of_short(short value){
		return (byte)((value>>8)&0xFF);
	}

	static short lo_of_int(int value){
		return (short)(value&0xFFFF);
	}
	
	static short hi_of_int(int value){
		return (short)((value>>16)&0xFFFF);
	}
	
	static void byteFill(byte[] buffer, int index, byte value){
		buffer[index]=value;
	}
	
	static int asByte(byte[] buffer, int index){
		return buffer[index];
	}

	static void shortFill(byte[] buffer, int index, short value){
		buffer[index]=lo_of_short(value);
		buffer[index+1]=hi_of_short(value);
	}

	static int asShort(byte[] buffer, int index){
		return buffer[index]+(buffer[index+1]<<8);
	}

	static void intFill(byte[] buffer, int index, int value){
		buffer[index]=lo_of_short(lo_of_int(value));
		buffer[index+1]=hi_of_short(lo_of_int(value));
		buffer[index+2]=lo_of_short(hi_of_int(value));
		buffer[index+3]=hi_of_short(hi_of_int(value));
	}
	
	static void timeFill(byte[] buffer, int index, int hour, int minute, int second){
		int time;
		time=((hour*60+minute)*60+second)*1000;
		intFill(buffer, index, time);
	}

	static void dateFill(byte[] buffer, int index, int year, int month, int day){
		int date;
		int MonthDays[][]={{31,28,31,30,31,30,31,31,30,31,30,31}, {31,29,31,30,31,30,31,31,30,31,30,31}};
		int i,y,m,d;

		y=year-1;
		for (m=0,d=year; d>100; d-=100, m++) ;
		if ((year&3)==0 && ((m&3)==0 || d!=0)) d=1; else d=0;
		  
		date=day;
		for (i=1; i<=month-1; i++) date+=MonthDays[d][i-1];
		date+=y*365+(y>>2)-(y/100)+(y/400);
		  
		intFill(buffer, index, date);
	}

	static void timestampFill(byte[] buffer, int index, int year, int month, int day, int hour, int minute, int second){
		timeFill(buffer, index, hour, minute, second);
		dateFill(buffer, index+4, year, month, day);
	}

	static int asInt(byte[] buffer, int index){
		return buffer[index]+(buffer[index+1]<<8)+(buffer[index+2]<<16)+(buffer[index+3]<<24);
	}

	static void blockFill(byte[] buffer, int index, int count, byte value){
		int i;
		for (i=index; i<index+count; i++){
			buffer[i]=value;
		}
	}

	public void blockCopy(byte[] obuffer, int ostart, byte[] ibuffer, int istart, int count){
		int x, y, i;
		x=ostart;
		y=istart;
		for (i=0; i<count; i++){
			obuffer[x++]=ibuffer[y++];
		}
	}

	public void stringCopy(byte[] obuffer, int ostart, String str, int len){
		int x, i;
		x=ostart;
		for (i=0; i<len; i++){
			obuffer[x++]=str.getBytes()[i];
		}
	}

	static int Pack(byte[] opacket, byte[] ipacket, int isize){
		int x, y;
		x=0;
		y=0;
		opacket[y++]=(byte)PKP_PREFIX;
		for (x=0; x<isize; x++){
			switch(ipacket[x]){
			case (byte)PKP_PREFIX:
				opacket[y++]=(byte)PKP_FILLCH;
				opacket[y++]=(byte)(PKP_PREFIX+1);
				break;
			case (byte)PKP_SUFFIX:
				opacket[y++]=(byte)PKP_FILLCH;
				opacket[y++]=(byte)(PKP_SUFFIX+1);
				break;
			case (byte)PKP_FILLCH:
				opacket[y++]=(byte)PKP_FILLCH;
				opacket[y++]=(byte)(PKP_FILLCH+1);
				break;
			default:
				opacket[y++]=ipacket[x];
				break;
			}
		}
		opacket[y++]=(byte)0x0;
		opacket[y++]=(byte)0x0;
		opacket[y++]=(byte)PKP_SUFFIX;
		return y;
	}

	static int Depack(byte[] opacket, byte[] ipacket, int isize){
		int x, y;
		x=1;
		y=0;
		while (x<isize-3){
			switch(ipacket[x]){
			case (byte)PKP_FILLCH:
				opacket[y++]=(byte)(ipacket[x+1]-1);
				break;
			default:
				opacket[y++]=ipacket[x];
				x++;
				break;
			}
		}
		return y;
	}

	public void MakeRoot(int roottype, int colortype) {
		root_seek=0;
		root_count=0;
		root_size=ROOT_STRUCT_SIZE;
		blockFill(data_stream, root_seek, root_size, (byte)0);
		shortFill(data_stream, root_seek, (short)roottype);
		shortFill(data_stream, root_seek+ROOT_COLORTYPE_OFFSET, (short)colortype);
		intFill(data_stream, root_seek+ROOT_SURVIVE_OFFSET, -1);
		intFill(data_stream, root_seek+ROOT_SIZE_OFFSET, root_size);
		intFill(data_stream, root_seek+ROOT_COUNT_OFFSET, root_count);
		data_seek=root_seek+root_size;
		//System.out.println("root="+data_seek);
	}

	//wait 1=�ȴ���Ŀ�ڲ����ݲ������  0=���ս�Ŀʱ�䳤�Ȳ���
	//time ��Ŀ����ʱ������λ����
	public void AddChapter(int wait, int time) {
		chapter_seek=data_seek;
		chapter_count=0;
		chapter_size=CHAPTER_STRUCT_SIZE;
		blockFill(data_stream, chapter_seek, chapter_size, (byte)0);
		shortFill(data_stream, chapter_seek, (short)OBJECT_CHAPTER);
		shortFill(data_stream, chapter_seek+CHAPTER_WAIT_OFFSET, (short)wait);
		intFill(data_stream, chapter_seek+CHAPTER_TIME_OFFSET, time);
		intFill(data_stream, chapter_seek+CHAPTER_SIZE_OFFSET, chapter_size);
		shortFill(data_stream, chapter_seek+CHAPTER_COUNT_OFFSET, (short)chapter_count);
		root_count++;
		intFill(data_stream, root_seek+ROOT_COUNT_OFFSET, root_count);
		root_size+=chapter_size;
		intFill(data_stream, root_seek+ROOT_SIZE_OFFSET, root_size);
		data_seek=chapter_seek+chapter_size;
		//System.out.println("chapter="+data_seek);
	}

	public void AddRegion(int left, int top, int width, int height) {
		region_seek=data_seek;
		region_count=0;
		region_size=REGION_STRUCT_SIZE;
		blockFill(data_stream, region_seek, region_size, (byte)0);
		shortFill(data_stream, region_seek, (short)OBJECT_REGION);
		intFill(data_stream, region_seek+REGION_LEFT_OFFSET, left);
		intFill(data_stream, region_seek+REGION_TOP_OFFSET, top);
		intFill(data_stream, region_seek+REGION_RIGHT_OFFSET, left+width);
		intFill(data_stream, region_seek+REGION_BOTTOM_OFFSET, top+height);
		intFill(data_stream, region_seek+REGION_SIZE_OFFSET, region_size);
		shortFill(data_stream, region_seek+REGION_COUNT_OFFSET, (short)region_count);
		chapter_count++;
		intFill(data_stream, chapter_seek+CHAPTER_COUNT_OFFSET, chapter_count);
		chapter_size+=region_size;
		intFill(data_stream, chapter_seek+CHAPTER_SIZE_OFFSET, chapter_size);
		root_size+=region_size;
		intFill(data_stream, root_seek+ROOT_SIZE_OFFSET, root_size);
		data_seek=region_seek+region_size;
		//System.out.println("region="+data_seek);
	}

	//wait 1=�ȴ�ҳ���ڲ����ݲ������  0=����ҳ��ʱ�䳤�Ȳ���
	//time ҳ�沥��ʱ������λ����
	public void AddLeaf(int wait, int time) {
		leaf_seek=data_seek;
		leaf_count=0;
		leaf_size=LEAF_STRUCT_SIZE;
		blockFill(data_stream, leaf_seek, leaf_size, (byte)0);
		shortFill(data_stream, leaf_seek, (short)OBJECT_LEAF);
		shortFill(data_stream, leaf_seek+LEAF_WAIT_OFFSET, (short)wait);
		intFill(data_stream, leaf_seek+LEAF_TIME_OFFSET, time);
		intFill(data_stream, leaf_seek+LEAF_SIZE_OFFSET, leaf_size);
		shortFill(data_stream, leaf_seek+LEAF_COUNT_OFFSET, (short)leaf_count);
		region_count++;
		shortFill(data_stream, region_seek+REGION_COUNT_OFFSET, (short)region_count);
		region_size+=leaf_size;
		intFill(data_stream, region_seek+REGION_SIZE_OFFSET, region_size);
		chapter_size+=leaf_size;
		intFill(data_stream, chapter_seek+CHAPTER_SIZE_OFFSET, chapter_size);
		root_size+=leaf_size;
		intFill(data_stream, root_seek+ROOT_SIZE_OFFSET, root_size);
		data_seek=leaf_seek+leaf_size;
		//System.out.println("leaf="+data_seek);
	}

	public void AddStrings(int left, int top, int width, int height) {
		strings_seek=data_seek;
		strings_count=0;
		strings_size=STRINGS_STRUCT_SIZE;
		blockFill(data_stream, strings_seek, strings_size, (byte)0);
		shortFill(data_stream, strings_seek, (short)OBJECT_STRINGS);
		blockFill(data_stream, strings_seek+OBJECT_TRANSPARENT_OFFSET, 1, (byte)1);
		intFill(data_stream, strings_seek+OBJECT_LEFT_OFFSET, left);
		intFill(data_stream, strings_seek+OBJECT_TOP_OFFSET, top);
		intFill(data_stream, strings_seek+OBJECT_RIGHT_OFFSET, left+width);
		intFill(data_stream, strings_seek+OBJECT_BOTTOM_OFFSET, top+height);
		shortFill(data_stream, strings_seek+STRINGS_COUNT_OFFSET, (short)strings_count);
		intFill(data_stream, strings_seek+OBJECT_SIZE_OFFSET, strings_size);
		leaf_count++;
		shortFill(data_stream, leaf_seek+LEAF_COUNT_OFFSET, (short)leaf_count);
		leaf_size+=strings_size;
		intFill(data_stream, leaf_seek+LEAF_SIZE_OFFSET, leaf_size);
		region_size+=strings_size;
		intFill(data_stream, region_seek+REGION_SIZE_OFFSET, region_size);
		chapter_size+=strings_size;
		intFill(data_stream, chapter_seek+CHAPTER_SIZE_OFFSET, chapter_size);
		root_size+=strings_size;
		intFill(data_stream, root_seek+ROOT_SIZE_OFFSET, root_size);
		data_seek=strings_seek+strings_size;
		//System.out.println("strings="+data_seek);
	}

	//inmethod ���뷽ʽ���ڴ�java�ļ����Ϸ��ж���
	//outmethod ������ʽ���ڴ�java�ļ����Ϸ��ж���
	//inspeed, outspeed ���������ٶȣ�0��5
	//stopmethod ͣ����ʽ������0
	//stopspeed ͣ���ٶȣ�����0
	//color 0xFF=�죬0xFF00=�̣�0xFFFF=��
	//fontset 0=16����1=24����
	public void AddChildString(String text, int inmethod, int inspeed, int outmethod, int outspeed, int stopmethod, int stopspeed, int stoptime, int color, int fontset) {
		int seek, size;
		String s=text;
		int len=s.replaceAll("[^\\x00-\\xff]", "**").length();	
		seek=data_seek;
		size=STRING_STRUCT_SIZE+len;
		size=((size+0x3)&(~0x3));
		blockFill(data_stream, seek, size, (byte)0);
		shortFill(data_stream, seek, (short)OBJECT_STRING);
		byteFill(data_stream, seek+STRING_IN_METHOD_OFFSET, (byte)inmethod);
		shortFill(data_stream, seek+STRING_IN_SPEED_OFFSET, (short)inspeed);
		byteFill(data_stream, seek+STRING_OUT_METHOD_OFFSET, (byte)outmethod);
		shortFill(data_stream, seek+STRING_OUT_SPEED_OFFSET, (short)outspeed);
		byteFill(data_stream, seek+STRING_STOP_METHOD_OFFSET, (byte)stopmethod);
		shortFill(data_stream, seek+STRING_STOP_SPEED_OFFSET, (short)stopspeed);
		intFill(data_stream, seek+STRING_STOP_TIME_OFFSET, stoptime);
		intFill(data_stream, seek+STRING_COLOR_OFFSET, color);
		shortFill(data_stream, seek+STRING_FONT_SET_OFFSET, (short)fontset);
		intFill(data_stream, seek+STRING_SIZE_OFFSET, size);
		stringCopy(data_stream, seek+STRING_STRUCT_SIZE, text, len);
		strings_count++;
		shortFill(data_stream, strings_seek+STRINGS_COUNT_OFFSET, (short)strings_count);
		strings_size+=size;
		intFill(data_stream, strings_seek+OBJECT_SIZE_OFFSET, strings_size);
		leaf_size+=size;
		intFill(data_stream, leaf_seek+LEAF_SIZE_OFFSET, leaf_size);
		region_size+=size;
		intFill(data_stream, region_seek+REGION_SIZE_OFFSET, region_size);
		chapter_size+=size;
		intFill(data_stream, chapter_seek+CHAPTER_SIZE_OFFSET, chapter_size);
		root_size+=size;
		intFill(data_stream, root_seek+ROOT_SIZE_OFFSET, root_size);
		data_seek=seek+size;
		//System.out.println("childstring="+data_seek);
	}
	
	//����ʱ����ʾ��ʽ������
	private void SDClockFormat(byte[] stream, int index, String format){
		if (format=="#y"){
			stream[index]=DF_YEAR;
			stream[index+1]=0;
		}else if (format=="#m"){
			stream[index]=DF_MONTH;
			stream[index+1]=0;
		}else if (format=="#w"){
			stream[index]=DF_WEEK;
			stream[index+1]=0;
		}else if (format=="#d"){
			stream[index]=DF_DAY;
			stream[index+1]=0;
		}else if (format=="#h"){
			stream[index]=DF_HOUR;
			stream[index+1]=0;
		}else if (format=="#n"){
			stream[index]=DF_MINUTE;
			stream[index+1]=0;
		}else if (format=="#s"){
			stream[index]=DF_SECOND;
			stream[index+1]=0;
		}else if (format=="��"){
			stream[index]=DF_USER;
			stream[index+1]=0;
		}else if (format=="��"){
			stream[index]=DF_USER;
			stream[index+1]=1;
		}else if (format=="��"){
			stream[index]=DF_USER;
			stream[index+1]=2;
		}else if (format=="ʱ"){
			stream[index]=DF_USER;
			stream[index+1]=3;
		}else if (format=="��"){
			stream[index]=DF_USER;
			stream[index+1]=4;
		}else if (format=="��"){
			stream[index]=DF_USER;
			stream[index+1]=5;
		}else if (format=="��"){
			stream[index]=DF_USER;
			stream[index+1]=6;
		}else if (format=="��"){
			stream[index]=DF_USER;
			stream[index+1]=7;
		}else if (format=="-"){
			stream[index]=DF_USER;
			stream[index+1]=8;
		}else if (format==":"){
			stream[index]=DF_USER;
			stream[index+1]=9;
		}else if (format==" "){
			stream[index]=DF_USER;
			stream[index+1]=10;
		}
	}
	
	public void AddStringDateTime(int left, int top, int width, int height, int color, int fontset, String[] formats, int formats_count) {
		int seek, size;
		int i;
		seek=data_seek;
		size=SDCLOCK_STRUCT_SIZE;
		blockFill(data_stream, seek, size, (byte)0);
		shortFill(data_stream, seek, (short)OBJECT_STRING_DCLOCK);
		blockFill(data_stream, seek+OBJECT_TRANSPARENT_OFFSET, 1, (byte)1);
		intFill(data_stream, seek+OBJECT_LEFT_OFFSET, left);
		intFill(data_stream, seek+OBJECT_TOP_OFFSET, top);
		intFill(data_stream, seek+OBJECT_RIGHT_OFFSET, left+width);
		intFill(data_stream, seek+OBJECT_BOTTOM_OFFSET, top+height);
		for (i=0; i<formats_count; i++){
			SDClockFormat(data_stream, seek+OBJECT_STRUCT_SIZE+SDCLOCK_FORMAT_OFFSET+(i<<1), formats[i]);
		}
		intFill(data_stream, seek+OBJECT_STRUCT_SIZE+SDCLOCK_COLOR_OFFSET, color);
		byteFill(data_stream, seek+OBJECT_STRUCT_SIZE+SDCLOCK_FONTSET_OFFSET, (byte)fontset);
		intFill(data_stream, seek+OBJECT_SIZE_OFFSET, size);
		leaf_count++;
		shortFill(data_stream, leaf_seek+LEAF_COUNT_OFFSET, (short)leaf_count);
		leaf_size+=size;
		intFill(data_stream, leaf_seek+LEAF_SIZE_OFFSET, leaf_size);
		region_size+=size;
		intFill(data_stream, region_seek+REGION_SIZE_OFFSET, region_size);
		chapter_size+=size;
		intFill(data_stream, chapter_seek+CHAPTER_SIZE_OFFSET, chapter_size);
		root_size+=size;
		intFill(data_stream, root_seek+ROOT_SIZE_OFFSET, root_size);
		data_seek=seek+size;
		//System.out.println("strings="+data_seek);
	}

	public void AddString(int left, int top, int width, int height, String text, int inmethod, int inspeed, int outmethod, int outspeed, int stopmethod, int stopspeed, int stoptime, int color, int fontset) {
		AddStrings(left, top, width, height);
		AddChildString(text, inmethod, inspeed, outmethod, outspeed, stopmethod, stopspeed, stoptime, color, fontset);
	}
	
	// ��ʼ��
	public int pkg_begin(byte[] packet, int addr) {
		blockFill(cmd_stream, 0, PKG_HEADER_STRUCT_SIZE, (byte)0);
		shortFill(cmd_stream, PKG_HEADER_COMMAND_OFFSET, (short)PKC_BEGIN);
		byteFill(cmd_stream, PKG_HEADER_DSTADDR_OFFSET, (byte)addr);
		return Pack(packet, cmd_stream, PKG_HEADER_STRUCT_SIZE);
	}
	
	// ������
	public int pkg_end(byte[] packet, int addr, int serial_no) {
		blockFill(cmd_stream, 0, PKG_HEADER_STRUCT_SIZE, (byte)0);
		shortFill(cmd_stream, PKG_HEADER_COMMAND_OFFSET, (short)PKC_END);
		byteFill(cmd_stream, PKG_HEADER_DSTADDR_OFFSET, (byte)addr);
		intFill(cmd_stream, PKG_HEADER_SERIALNO_OFFSET, serial_no);
		return Pack(packet, cmd_stream, PKG_HEADER_STRUCT_SIZE);
	}

	// ���ݰ�
	public int pkg_data(byte[] packet, int addr, int serial_no, int pkg_length) {
		int size;
		blockFill(cmd_stream, 0, PKG_HEADER_STRUCT_SIZE, (byte)0);
		shortFill(cmd_stream, PKG_HEADER_COMMAND_OFFSET, (short)PKC_DATA);
		byteFill(cmd_stream, PKG_HEADER_DSTADDR_OFFSET, (byte)addr);
		intFill(cmd_stream, PKG_HEADER_SERIALNO_OFFSET, serial_no);
		size=(data_seek-(serial_no-1)*pkg_length);
		if (size>0){
			if (size>pkg_length) size=pkg_length;
			blockCopy(cmd_stream, PKG_HEADER_STRUCT_SIZE, data_stream, (serial_no-1)*pkg_length, size);
			return Pack(packet, cmd_stream, PKG_HEADER_STRUCT_SIZE+size);
		}
		else{
			return 0;
		}
	}
	
	// ��ȡ���ݰ�����
	public int get_pkg_count(int pkg_length){
		if ((data_seek%pkg_length)>0){
			return data_seek/pkg_length+1;
		}
		else{
			return data_seek/pkg_length;
		}
	}

	public int parse_trans_respond(byte[] packet, int size, int command, int serialno){
		size=Depack(cmd_stream, packet, size);
		if (size==RESPOND_STRUCT_SIZE && asShort(cmd_stream, 0)==PKC_RESPOND &&
				asShort(cmd_stream, PKG_HEADER_STRUCT_SIZE+RESPOND_COMMAND_OFFSET)==command &&
				asInt(cmd_stream, PKG_HEADER_SERIALNO_OFFSET)==serialno){
			return 1;
		}
		return 0;
	}

	// ��ȡ��Դ״̬
	public int pkg_get_power(byte[] packet, int addr) {
		blockFill(cmd_stream, 0, PKG_HEADER_STRUCT_SIZE, (byte)0);
		shortFill(cmd_stream, PKG_HEADER_COMMAND_OFFSET, (short)PKC_GET_POWER);
		byteFill(cmd_stream, PKG_HEADER_DSTADDR_OFFSET, (byte)addr);
		return Pack(packet, cmd_stream, PKG_HEADER_STRUCT_SIZE);
	}
	
	// ���õ�Դ״̬��power=0�رյ�Դ��power=1�򿪵�Դ
	public int pkg_set_power(byte[] packet, int addr, int power) {
		blockFill(cmd_stream, 0, PKG_HEADER_STRUCT_SIZE, (byte)0);
		shortFill(cmd_stream, PKG_HEADER_COMMAND_OFFSET, (short)PKC_SET_POWER);
		byteFill(cmd_stream, PKG_HEADER_DSTADDR_OFFSET, (byte)addr);
		intFill(cmd_stream, PKG_HEADER_SERIALNO_OFFSET, power);
		return Pack(packet, cmd_stream, PKG_HEADER_STRUCT_SIZE);
	}

	// ��ȡ����
	public int pkg_get_bright(byte[] packet, int addr) {
		blockFill(cmd_stream, 0, PKG_HEADER_STRUCT_SIZE, (byte)0);
		shortFill(cmd_stream, PKG_HEADER_COMMAND_OFFSET, (short)PKC_GET_BRIGHT);
		byteFill(cmd_stream, PKG_HEADER_DSTADDR_OFFSET, (byte)addr);
		return Pack(packet, cmd_stream, PKG_HEADER_STRUCT_SIZE);
	}

	// �������ȣ�bright=0��7
	public int pkg_set_bright(byte[] packet, int addr, int bright) {
		blockFill(cmd_stream, 0, PKG_HEADER_STRUCT_SIZE, (byte)0);
		shortFill(cmd_stream, PKG_HEADER_COMMAND_OFFSET, (short)PKC_SET_BRIGHT);
		byteFill(cmd_stream, PKG_HEADER_DSTADDR_OFFSET, (byte)addr);
		intFill(cmd_stream, PKG_HEADER_SERIALNO_OFFSET, bright);
		return Pack(packet, cmd_stream, PKG_HEADER_STRUCT_SIZE);
	}

	// У��ʱ��
	public int pkg_adjust_time(byte[] packet, int addr, int year, int month, int day, int hour, int minute, int second) {
		blockFill(cmd_stream, 0, PKG_HEADER_STRUCT_SIZE+SYSTEMTIME_SIZE, (byte)0);
		shortFill(cmd_stream, PKG_HEADER_COMMAND_OFFSET, (short)PKC_ADJUST_TIME);
		byteFill(cmd_stream, PKG_HEADER_DSTADDR_OFFSET, (byte)addr);
		shortFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+SYSTEMTIME_YEAR_OFFSET, (short)year);
		shortFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+SYSTEMTIME_MONTH_OFFSET, (short)month);
		shortFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+SYSTEMTIME_DAY_OFFSET, (short)day);
		shortFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+SYSTEMTIME_HOUR_OFFSET, (short)hour);
		shortFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+SYSTEMTIME_MINUTE_OFFSET, (short)minute);
		shortFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+SYSTEMTIME_SECOND_OFFSET, (short)second);
		return Pack(packet, cmd_stream, PKG_HEADER_STRUCT_SIZE+SYSTEMTIME_SIZE);
	}

	// ���ö�ʱ�������ƻ�  -- ��һ��7��ÿ�ն�ʱ��������ÿ�տ��Զ���3��ʱ��
	public int pkg_power_schedule_weekday(byte[] packet, int addr, boolean enabled) {
		blockFill(cmd_stream, 0, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SIZE, (byte)0);
		shortFill(cmd_stream, PKG_HEADER_COMMAND_OFFSET, (short)PKC_SET_POWER_SCHEDULE);
		byteFill(cmd_stream, PKG_HEADER_DSTADDR_OFFSET, (byte)addr);
		if (enabled){
			intFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_ENABLED_OFFSET, 0x55AAAA55);
		}else{
			intFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_ENABLED_OFFSET, 0);
		}
		intFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_MODE_OFFSET, 0);

		//���գ�3��������ʱ�Σ���1����6ͬ��
		//   ʱ��1
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SUNDAY_OPENTIME_OFFSET, 2015, 9, 30, 9, 0, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SUNDAY_CLOSETIME_OFFSET, 2015, 9, 30, 12, 0, 0);
		//   ʱ��2
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SUNDAY_OPENTIME_OFFSET+8, 2015, 9, 30, 13, 30, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SUNDAY_CLOSETIME_OFFSET+8, 2015, 9, 30, 18, 22, 0);
		//   ʱ��3
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SUNDAY_OPENTIME_OFFSET+16, 2015, 9, 30, 18, 23, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SUNDAY_CLOSETIME_OFFSET+16, 2015, 9, 30, 21, 0, 0);
		//��һ
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_MONDAY_OPENTIME_OFFSET, 2015, 9, 30, 8, 30, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_MONDAY_CLOSETIME_OFFSET, 2015, 9, 30, 17, 0, 0);
		//�ܶ�
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_TUESDAY_OPENTIME_OFFSET, 2015, 9, 30, 8, 30, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_TUESDAY_CLOSETIME_OFFSET, 2015, 9, 30, 17, 0, 0);
		//����
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_WEDNESDAY_OPENTIME_OFFSET, 2015, 9, 30, 8, 30, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_WEDNESDAY_CLOSETIME_OFFSET, 2015, 9, 30, 17, 0, 0);
		//����
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_THURSDAY_OPENTIME_OFFSET, 2015, 9, 30, 8, 30, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_THURSDAY_CLOSETIME_OFFSET, 2015, 9, 30, 17, 0, 0);
		//����
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_FRIDAY_OPENTIME_OFFSET, 2015, 9, 30, 8, 30, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_FRIDAY_CLOSETIME_OFFSET, 2015, 9, 30, 17, 0, 0);
		//����
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SATURDAY_OPENTIME_OFFSET, 2015, 9, 30, 9, 0, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SATURDAY_CLOSETIME_OFFSET, 2015, 9, 30, 12, 0, 0);
		
		return Pack(packet, cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SIZE);
	}

	// ���ö�ʱ�������ƻ�  -- ��ָ������ֹ����ʱ�䲥�ţ�һ�����Զ���21��ʱ��
	public int pkg_power_schedule_period(byte[] packet, int addr, boolean enabled) {
		blockFill(cmd_stream, 0, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SIZE, (byte)0);
		shortFill(cmd_stream, PKG_HEADER_COMMAND_OFFSET, (short)PKC_SET_POWER_SCHEDULE);
		byteFill(cmd_stream, PKG_HEADER_DSTADDR_OFFSET, (byte)addr);
		if (enabled){
			intFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_ENABLED_OFFSET, 0x55AAAA55);
		}else{
			intFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_ENABLED_OFFSET, 0);
		}
		intFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_MODE_OFFSET, 1);

		//һ��21��ʱ�Σ�ÿ��ʱ��ƫ�������8���ֽ�
		//��������Ϊ����һ����3�죬��һ����һ����һ������1��
		//   ʱ��1
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_OPENTIME_OFFSET, 2015, 5, 1, 0, 0, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SUNDAY_CLOSETIME_OFFSET, 2015, 5, 3, 23, 59, 59);
		//   ʱ��2
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_OPENTIME_OFFSET+8, 2015, 6, 1, 0, 0, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_CLOSETIME_OFFSET+8, 2015, 6, 1, 23, 59, 59);
		//   ʱ��3
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_OPENTIME_OFFSET+16, 2015, 7, 1, 0, 0, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_CLOSETIME_OFFSET+16, 2015, 7, 1, 23, 59, 59);
		//   ʱ��4
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_OPENTIME_OFFSET+24, 2015, 8, 1, 0, 0, 0);
		timestampFill(cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_CLOSETIME_OFFSET+24, 2015, 8, 1, 23, 59, 59);
		//   ......
		
		return Pack(packet, cmd_stream, PKG_HEADER_STRUCT_SIZE+PWOERSCHEDULE_SIZE);
	}

	// ������ȡ��Դ״̬��Ӧ��
	public int parse_cmd_respond(byte[] packet, int size){
		size=Depack(cmd_stream, packet, size);
		if (size==RESPOND_STRUCT_SIZE && asShort(cmd_stream, 0)==PKC_RESPOND){
			switch(asShort(cmd_stream, PKG_HEADER_STRUCT_SIZE+RESPOND_COMMAND_OFFSET)){
			case PKC_GET_POWER:
				if (asInt(cmd_stream, PKG_HEADER_SERIALNO_OFFSET)==0){
					System.out.println("��ȡ��Դ״̬��ɣ���Դ�ر�");
				}else{
					System.out.println("��ȡ��Դ״̬��ɣ���Դ����");
				}
				break;
			case PKC_SET_POWER:
				if (asInt(cmd_stream, PKG_HEADER_SERIALNO_OFFSET)==0){
					System.out.println("���õ�Դ״̬��ɣ���Դ�ر�");
				}else{
					System.out.println("���õ�Դ״̬��ɣ���Դ����");
				}
				break;
			case PKC_GET_BRIGHT:
				System.out.println("��ȡ������ɣ�����="+asInt(cmd_stream, PKG_HEADER_SERIALNO_OFFSET));
				break;
			case PKC_SET_BRIGHT:
				System.out.println("����������ɣ�����="+asInt(cmd_stream, PKG_HEADER_SERIALNO_OFFSET));
				break;
			case PKC_ADJUST_TIME:
				System.out.println("У��ʱ�����");
				break;
			case PKC_SET_POWER_SCHEDULE:
				System.out.println("���ö�ʱ���������");
				break;
			}
		}
		return 0;
	}

    public LEDSender2010() {
		data_stream = new byte[65536];
		cmd_stream = new byte[576];
		packet_stream = new byte[1280];
    }    
}