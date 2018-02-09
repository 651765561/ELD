import java.util.Calendar;

public class ProtocolDemo {

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
	
	public static MyUdpSocket my_udp;
	public static LEDSender2010 ledsender = new LEDSender2010();
	//public static String ledhost = "127.0.0.1";
	//public static int ledport=6677;
	public static String ledhost = "192.168.1.99";
	public static int ledport=6666;
	public static int addr = 0;
	
	public static void mysleep(int msec){
        try{  
            Thread.sleep(msec);  
            }  
            catch (InterruptedException e){  
             e.printStackTrace();  
            }  
	}
	
	//����UDP����bufferΪ�������ݣ�sizeΪ�������ݳ���
	public static void udp_send(byte[] buffer, int size){
		byte[] packet = new byte[size];
        ledsender.blockCopy(packet, 0, buffer, 0, size);
        ledsender.print_stream(packet, size);
        try {    
        	my_udp.send(ledhost, ledport, packet, size);
        } catch (Exception ex) {    
            ex.printStackTrace();    
        }
	}
	
	//����UDP����bufferΪ�������ݣ�sizeΪ�������ݳ���
	public static int udp_receive(byte[] buffer){
		int i;
		int size=0;
		for (i=0; i<30; i++){
			size=my_udp.receive();
			if(size>0) {
				my_udp.get_receive_packet(buffer, size);
				break;
			}
		}
		return size;
	}

	public static void do_command(byte[] buffer, int size){
		byte[] packet = new byte[1280];
		int tx, tx_repeat=5;
		int isize=0;
		for (tx=0; tx<tx_repeat; tx++){
	        udp_send(buffer, size);
	        isize=udp_receive(packet);
			if (isize>0) break;
		}
		if (isize>0){
			ledsender.parse_cmd_respond(packet, isize);
		}else{
			System.out.println("��ʱ");
		}
	}
	
	public static void demo_power_on(){
		int size;
		byte[] packet = new byte[1280];
        size=ledsender.pkg_set_power(packet, (byte)0, 1);
		System.out.println("�򿪵�Դ...");
        do_command(packet, size);
	}
	
	public static void demo_power_off(){
		int size;
		byte[] packet = new byte[1280];
        size=ledsender.pkg_set_power(packet, (byte)0, 0);
		System.out.println("�رյ�Դ...");
        do_command(packet, size);
	}
	
	public static void demo_get_power(){
		int size;
		byte[] packet = new byte[1280];
        size=ledsender.pkg_get_power(packet, (byte)0);
		System.out.println("��ȡ��Դ״̬...");
        do_command(packet, size);
	}
	
	public static void demo_set_bright(){
		int size;
		byte[] packet = new byte[1280];
        size=ledsender.pkg_set_bright(packet, (byte)0, 7);
		System.out.println("��������...");
        do_command(packet, size);
	}

	public static void demo_get_bright(){
		int size;
		byte[] packet = new byte[1280];
        size=ledsender.pkg_get_bright(packet, (byte)0);
		System.out.println("��ȡ����...");
        do_command(packet, size);
	}
	
	public static void demo_adjust_time(){
		int size;
		byte[] packet = new byte[1280];
		Calendar calendar = Calendar.getInstance();
		if (calendar.get(Calendar.AM_PM)==0){
			size=ledsender.pkg_adjust_time(packet, (byte)0, calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH)+1, calendar.get(Calendar.DATE), calendar.get(Calendar.HOUR), calendar.get(Calendar.MINUTE), calendar.get(Calendar.SECOND));
		}else{
			size=ledsender.pkg_adjust_time(packet, (byte)0, calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH)+1, calendar.get(Calendar.DATE), calendar.get(Calendar.HOUR)+12, calendar.get(Calendar.MINUTE), calendar.get(Calendar.SECOND));
		}
		System.out.println("У��ʱ��...");
		do_command(packet, size);
	}

	public static void demo_power_schedule(){
		int size;
		byte[] packet = new byte[1280];
		//��һ��7��ÿ�ն�ʱ��������ÿ�տ��Զ���3��ʱ��
        size=ledsender.pkg_power_schedule_weekday(packet, (byte)0, true);
		//��ָ������ֹ����ʱ�䲥�ţ�һ�����Զ���21��ʱ��
        //size=ledsender.pkg_power_schedule_period(packet, (byte)0, true);
		System.out.println("���ö�ʱ�������ƻ�...");
        do_command(packet, size);
	}
	public static void demo_play(){
		int size=0;
		byte[] packet = new byte[1280];
		int i, k;
		int tx, tx_repeat=5;
		boolean ok;
		String[] formats={"#y", "��", "#m", "��", "#d", "��", " ", "#h", ":", "#n", ":", "#s"};

		//���ɽ�Ŀ����
		ledsender.MakeRoot(LEDSender2010.ROOT_PLAY, LEDSender2010.COLOR_TYPE_DOUBLE);
		ledsender.AddChapter(1, 10000);
		ledsender.AddRegion(0, 0, 64, 32);
		//16��������
		ledsender.AddLeaf(1, 2000);
		ledsender.AddString(0, 0, 64, 32, "Hello world", 1, 5, 2, 5, 0, 0, 1000, 0xFFFF, 0);
		//16��������ʱ�䣬��ʽyyyy��mm��dd�� hh:nn:ss
		ledsender.AddLeaf(1, 2000);
		ledsender.AddStringDateTime(-120, 0, 256, 32, 0xFFFF, 0, formats, 12);
		//24��������
		ledsender.AddLeaf(1, 2000);
		ledsender.AddString(0, 0, 64, 32, "��ӭ����abc", 2, 0, 2, 0, 0, 0, 0, 0xFF, 1);
		//24��������ʱ�䣬��ʽyyyy��mm��dd��
		ledsender.AddLeaf(1, 2000);
		ledsender.AddStringDateTime(0, 0, 256, 32, 0xFFFF, 1, formats, 6);
		
		//����ΪͨѶ���룬�������ݵĲ�ִ��������
		//    ������UDPͨѶ������

		//��ʼ��
		ok=false;
		System.out.println("������ʼ��...�����к�=0");
		for (tx=0; tx<tx_repeat; tx++){
			size=ledsender.pkg_begin(packet, addr);
			udp_send(packet, size);
			size=udp_receive(packet);
			if (size>0 && ledsender.parse_trans_respond(packet, size, LEDSender2010.PKC_BEGIN, 0)==1){
				System.out.println("��ʼ��������ɣ����к�=0");
				ok=true;
				break;
			}
		}
		if (size==0){
			System.out.println("��ʱ");
			return;
		}else if (!ok){
			System.out.println("��ʼ��Ӧ��У��ʧ��");
			return;
		}

		//���ݰ�
		k=ledsender.get_pkg_count(512);
		i=1;
		while (i<=k){
			ok=false;
			System.out.println("�������ݰ�...�����к�="+i);
			for (tx=0; tx<tx_repeat; tx++){
				size=ledsender.pkg_data(packet, addr, i, 512);
				udp_send(packet, size);
				size=udp_receive(packet);
				if (size>0 && ledsender.parse_trans_respond(packet, size, LEDSender2010.PKC_DATA, i)==1){
					System.out.println("���ݰ�������ɣ����к�="+i);
					ok=true;
					break;
				}
			}
			if (size==0){
				System.out.println("��ʱ");
				return;
			}else if (!ok){
				System.out.println("���ݰ�Ӧ��У��ʧ��");
				return;
			}
			i++;
		}

		//������
		ok=false;
		System.out.println("���ͽ�����...�����к�="+i);
		for (tx=0; tx<tx_repeat; tx++){
			size=ledsender.pkg_end(packet, addr, i);
	        udp_send(packet, size);
			size=udp_receive(packet);
			if (size>0 && ledsender.parse_trans_respond(packet, size, LEDSender2010.PKC_END, i)==1){
				System.out.println("������������ɣ����к�="+i);
				ok=true;
				break;
			}
		}
		if (size==0){
			System.out.println("��ʱ");
			return;
		}else if (!ok){
			System.out.println("������Ӧ��У��ʧ��");
			return;
		}
	}

	public static void main(String[] args) {

		// TODO Auto-generated method stub
		
        try {    
    		my_udp = new MyUdpSocket(8868);
        } catch (Exception ex) {    
            ex.printStackTrace();    
        }
        
        demo_play();
        demo_power_off();
        demo_power_on();
        demo_get_power();
        demo_set_bright();
        demo_get_bright();
        demo_adjust_time();
        demo_power_schedule();
        
		System.out.println("���н���.");
	}

}
