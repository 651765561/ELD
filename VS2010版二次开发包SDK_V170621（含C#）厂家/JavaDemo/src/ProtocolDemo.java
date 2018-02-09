import java.util.Calendar;

public class ProtocolDemo {

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
	
	//发送UDP包，buffer为发送数据，size为发送数据长度
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
	
	//接收UDP包，buffer为接收数据，size为接收数据长度
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
			System.out.println("超时");
		}
	}
	
	public static void demo_power_on(){
		int size;
		byte[] packet = new byte[1280];
        size=ledsender.pkg_set_power(packet, (byte)0, 1);
		System.out.println("打开电源...");
        do_command(packet, size);
	}
	
	public static void demo_power_off(){
		int size;
		byte[] packet = new byte[1280];
        size=ledsender.pkg_set_power(packet, (byte)0, 0);
		System.out.println("关闭电源...");
        do_command(packet, size);
	}
	
	public static void demo_get_power(){
		int size;
		byte[] packet = new byte[1280];
        size=ledsender.pkg_get_power(packet, (byte)0);
		System.out.println("读取电源状态...");
        do_command(packet, size);
	}
	
	public static void demo_set_bright(){
		int size;
		byte[] packet = new byte[1280];
        size=ledsender.pkg_set_bright(packet, (byte)0, 7);
		System.out.println("设置亮度...");
        do_command(packet, size);
	}

	public static void demo_get_bright(){
		int size;
		byte[] packet = new byte[1280];
        size=ledsender.pkg_get_bright(packet, (byte)0);
		System.out.println("读取亮度...");
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
		System.out.println("校正时间...");
		do_command(packet, size);
	}

	public static void demo_power_schedule(){
		int size;
		byte[] packet = new byte[1280];
		//按一周7天每日定时开关屏，每日可以定义3个时段
        size=ledsender.pkg_power_schedule_weekday(packet, (byte)0, true);
		//按指定的起止日期时间播放，一共可以定义21个时段
        //size=ledsender.pkg_power_schedule_period(packet, (byte)0, true);
		System.out.println("设置定时开关屏计划...");
        do_command(packet, size);
	}
	public static void demo_play(){
		int size=0;
		byte[] packet = new byte[1280];
		int i, k;
		int tx, tx_repeat=5;
		boolean ok;
		String[] formats={"#y", "年", "#m", "月", "#d", "日", " ", "#h", ":", "#n", ":", "#s"};

		//生成节目数据
		ledsender.MakeRoot(LEDSender2010.ROOT_PLAY, LEDSender2010.COLOR_TYPE_DOUBLE);
		ledsender.AddChapter(1, 10000);
		ledsender.AddRegion(0, 0, 64, 32);
		//16点阵文字
		ledsender.AddLeaf(1, 2000);
		ledsender.AddString(0, 0, 64, 32, "Hello world", 1, 5, 2, 5, 0, 0, 1000, 0xFFFF, 0);
		//16点阵日期时间，格式yyyy年mm月dd日 hh:nn:ss
		ledsender.AddLeaf(1, 2000);
		ledsender.AddStringDateTime(-120, 0, 256, 32, 0xFFFF, 0, formats, 12);
		//24点阵文字
		ledsender.AddLeaf(1, 2000);
		ledsender.AddString(0, 0, 64, 32, "欢迎光临abc", 2, 0, 2, 0, 0, 0, 0, 0xFF, 1);
		//24点阵日期时间，格式yyyy年mm月dd日
		ledsender.AddLeaf(1, 2000);
		ledsender.AddStringDateTime(0, 0, 256, 32, 0xFFFF, 1, formats, 6);
		
		//下面为通讯代码，包括数据的拆分打包、发送
		//    由于是UDP通讯，增加

		//起始包
		ok=false;
		System.out.println("发送起始包...，序列号=0");
		for (tx=0; tx<tx_repeat; tx++){
			size=ledsender.pkg_begin(packet, addr);
			udp_send(packet, size);
			size=udp_receive(packet);
			if (size>0 && ledsender.parse_trans_respond(packet, size, LEDSender2010.PKC_BEGIN, 0)==1){
				System.out.println("起始包发送完成，序列号=0");
				ok=true;
				break;
			}
		}
		if (size==0){
			System.out.println("超时");
			return;
		}else if (!ok){
			System.out.println("起始包应答校验失败");
			return;
		}

		//数据包
		k=ledsender.get_pkg_count(512);
		i=1;
		while (i<=k){
			ok=false;
			System.out.println("发送数据包...，序列号="+i);
			for (tx=0; tx<tx_repeat; tx++){
				size=ledsender.pkg_data(packet, addr, i, 512);
				udp_send(packet, size);
				size=udp_receive(packet);
				if (size>0 && ledsender.parse_trans_respond(packet, size, LEDSender2010.PKC_DATA, i)==1){
					System.out.println("数据包发送完成，序列号="+i);
					ok=true;
					break;
				}
			}
			if (size==0){
				System.out.println("超时");
				return;
			}else if (!ok){
				System.out.println("数据包应答校验失败");
				return;
			}
			i++;
		}

		//结束包
		ok=false;
		System.out.println("发送结束包...，序列号="+i);
		for (tx=0; tx<tx_repeat; tx++){
			size=ledsender.pkg_end(packet, addr, i);
	        udp_send(packet, size);
			size=udp_receive(packet);
			if (size>0 && ledsender.parse_trans_respond(packet, size, LEDSender2010.PKC_END, i)==1){
				System.out.println("结束包发送完成，序列号="+i);
				ok=true;
				break;
			}
		}
		if (size==0){
			System.out.println("超时");
			return;
		}else if (!ok){
			System.out.println("结束包应答校验失败");
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
        
		System.out.println("运行结束.");
	}

}
