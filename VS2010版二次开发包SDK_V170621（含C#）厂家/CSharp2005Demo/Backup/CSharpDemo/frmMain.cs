using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices; // 用 DllImport 需用此 命名空间

namespace CSharpDemo
{
    public partial class frmMain : Form
    {
        private const int WM_LED_NOTIFY = 1025;

        CLEDSender LEDSender = new CLEDSender();

        public frmMain()
        {
            InitializeComponent();
        }

        private void OnLEDNotify(UInt32 msg, UInt32 wParam, UInt32 lParam)
        {
            int i;
            TNotifyParam notifyparam = new TNotifyParam();
            LEDSender.Do_LED_GetNotifyParam_BufferToFile(ref notifyparam, "C:\\play.dat", (int)wParam);

            if (notifyparam.notify==LEDSender.LM_TIMEOUT)
            {
                Text = "命令执行超时";
            }
            else if (notifyparam.notify==LEDSender.LM_TX_COMPLETE)
            {
                if (notifyparam.result == LEDSender.RESULT_FLASH)
                {
                    Text = "数据传送完成，正在写入Flash";
                }
                else
                {
                    Text = "数据传送完成";
                }
            }
            else if (notifyparam.notify == LEDSender.LM_NOTIFY)
            {
                if (notifyparam.result == LEDSender.NOTIFY_GET_PLAY_BUFFER)
                {
                    Text = "当前播放节目数据读取完成";
                    LEDSender.Do_LED_PreviewFile(128, 64, "C:\\play.dat");
                }
            }
            else if (notifyparam.notify == LEDSender.LM_RESPOND)
            {
                if (notifyparam.command == LEDSender.PKC_GET_POWER)
                {
                    if (notifyparam.status == LEDSender.LED_POWER_ON) Text = "读取电源状态完成，当前为电源开启状态";
                    else if (notifyparam.status == LEDSender.LED_POWER_OFF) Text = "读取电源状态完成，当前为电源关闭状态";
                }
                else if (notifyparam.command == LEDSender.PKC_SET_POWER)
                {
                    if (notifyparam.result == 99) Text = "当前为定时开关屏模式";
                    else if (notifyparam.status == LEDSender.LED_POWER_ON) Text = "设置电源状态完成，当前为电源开启状态";
                    else Text = "设置电源状态完成，当前为电源关闭状态";
                }
                else if (notifyparam.command == LEDSender.PKC_GET_BRIGHT)
                {
                    Text = string.Format("读取亮度完成，当前亮度={0:D}", notifyparam.status);
                }
                else if (notifyparam.command == LEDSender.PKC_SET_BRIGHT)
                {
                    if (notifyparam.result == 99) Text = "当前为定时亮度调节模式";
                    else Text = string.Format("设置亮度完成，当前亮度={0:D}", notifyparam.status);
                }
                else if (notifyparam.command == LEDSender.PKC_ADJUST_TIME)
                {
                    Text = "校正显示屏时间完成";
                }
                else if (notifyparam.command == LEDSender.PKC_COM_TRANSFER)
                {
                    Text = "串口转发数据完成";
                }
                else if (notifyparam.command == LEDSender.PKC_MODEM_TRANSFER)
                {
                    Text = "485口转发数据完成";
                }
                else if (notifyparam.command == LEDSender.PKC_GET_TEMPERATURE_HUMIDITY)
                {
                    Text = string.Format("读取亮度完成，当前温度={0:D}, 湿度={1:D}", notifyparam.status & 0xFFFF, notifyparam.status >> 16);
                }
                else if (notifyparam.command == LEDSender.PKC_GET_CHAPTER_COUNT)
                {
                    Text = string.Format("读取节目数量完成，节目数量={0:D}", notifyparam.status);
                }
                else if (notifyparam.command == LEDSender.PKC_SET_CURRENT_CHAPTER)
                {
                    Text = string.Format("设置当前播放节目完成");
                }
                else if (notifyparam.command == LEDSender.PKC_GET_CURRENT_CHAPTER)
                {
                    Text = string.Format("设置当前播放节目完成，当前播放节目={0:D}", notifyparam.status);
                }
                else if (notifyparam.command == LEDSender.PKC_SET_POWER_SCHEDULE)
                {
                    Text = string.Format("设置定时开关屏计划完成");
                }
                else if (notifyparam.command == LEDSender.PKC_SET_BRIGHT_SCHEDULE)
                {
                    Text = string.Format("设置定时亮度调节计划完成");
                }
                else if (notifyparam.command == LEDSender.PKC_SET_EXSTRING)
                {
                    Text = string.Format("变量字符串完成");
                }
                else if (notifyparam.command == LEDSender.PKC_GET_TRANSFER_ACK)
                {
                    Text = string.Format("读取转发应答完成");
                    if (notifyparam.size > 0)
                    {
                        Text = Text + " ";
                        for (i = 0; i < notifyparam.size; i++)
                        {
                            Text = Text + string.Format("{1:D},", notifyparam.buffer[i]);
                        }
                    }
                }
            }
        }

        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            switch(m.Msg)
            {
                case WM_LED_NOTIFY:
                    OnLEDNotify((UInt32)m.Msg, (UInt32)m.WParam, (UInt32)m.LParam);
                    break;
                default:
                    base.DefWndProc(ref m);//调用基类函数处理非自定义消息。
                    break;
            }
        }
        
        private void GetDeviceParam(ref TDeviceParam param)
        {
            switch (cmbDevType.SelectedIndex)
            {
                case 0:
                    param.devType = LEDSender.DEVICE_TYPE_COM;
                    break;
                case 1:
                    param.devType = LEDSender.DEVICE_TYPE_UDP;
                    break;
            }
            param.comPort = (ushort)Convert.ToInt16(eCommPort.Text);
            param.comSpeed = (ushort)cmbBaudRate.SelectedIndex;
            param.locPort = (ushort)Convert.ToInt16(eLocalPort.Text);
            param.rmtHost = eRemoteHost.Text;
            param.rmtPort = 6666;
            param.dstAddr = (ushort)Convert.ToInt16(eAddress.Text); ;
        }

        private void GetDeviceParamWithoutStruct(Int32 param_index, Int32 notifymode, Int32 wmhandle, Int32 wmmessage)
        {
            switch (cmbDevType.SelectedIndex)
            {
                case 0:
                    LEDSender.Do_LED_COM_SenderParam(param_index, (Int32)Convert.ToInt16(eCommPort.Text), (Int32)cmbBaudRate.SelectedIndex, 0, notifymode, wmhandle, wmmessage);
                    break;
                case 1:
                    LEDSender.Do_LED_UDP_SenderParam(param_index, (Int32)Convert.ToInt16(eLocalPort.Text), eRemoteHost.Text, 6666, 0, notifymode, wmhandle, wmmessage);
                    break;
            }
        }

        private int GetColorType()
        {
            switch(cmbColorType.SelectedIndex){
                case 1: return LEDSender.COLOR_MODE_THREE; 
                case 2: return LEDSender.COLOR_MODE_FULLCOLOR; 
                default: return LEDSender.COLOR_MODE_DOUBLE;
            }
        }

        public void EncodeDateTime(ref TSystemTime t, ushort year, ushort month, ushort day, ushort hour, ushort minute, ushort second, ushort milliseconds)
        {
            t.wYear = year;
            t.wMonth = month;
            t.wDay = day;
            t.wHour = hour;
            t.wMinute = minute;
            t.wSecond = second;
            t.wMilliseconds = milliseconds;
        }

        public int MonthDays(int ryear, int month)
        {
            int r=0;
            switch (ryear)
            {
                case 0:
                    switch (month) 
                    {
                        case 0:
                        case 2:
                        case 4:
                        case 6:
                        case 7:
                        case 9:
                        case 11:
                            r = 31;
                            break;
                        case 3:
                        case 5:
                        case 8:
                        case 10:
                            r = 30;
                            break;
                        case 1:
                            r = 28;
                            break;
                    }
                    break;
                case 1:
                    switch (month)
                    {
                        case 0:
                        case 2:
                        case 4:
                        case 6:
                        case 7:
                        case 9:
                        case 11:
                            r = 31;
                            break;
                        case 3:
                        case 5:
                        case 8:
                        case 10:
                            r = 30;
                            break;
                        case 1:
                            r = 29;
                            break;
                    }
                    break;
            }
            return r;
        }

        public void SystemTimeToTimeStamp(ref TSystemTime itime, ref TTimeStamp otime)
        {
            Int32  i,y,m,d;

            y=itime.wYear-1;
            for (m=0,d=itime.wYear; d>100; d-=100, m++) ;

            if (((itime.wYear & 3)==0) && ((m & 3)==0 || (d!=0))) d=1;
            else d=0;
  
            otime.date=itime.wDay;
            for (i=1; i<=itime.wMonth-1; i++) otime.date+=MonthDays(d, i-1);
            otime.date+=y*365+(y>>2)-(y/100)+(y/400);
  
            otime.time=itime.wHour*60*60000+itime.wMinute*60000+itime.wSecond*1000+itime.wMilliseconds;
        }

        private void Parse(Int32 K)
        {
            if (K == LEDSender.R_DEVICE_READY) Text = "正在执行命令或者发送数据...";
            else if (K == LEDSender.R_DEVICE_INVALID) Text = "打开通讯设备失败(串口不存在、或者串口已被占用、或者网络端口被占用)";
            else if (K == LEDSender.R_DEVICE_BUSY) Text = "设备忙，正在通讯中...";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbDevType.SelectedIndex = 1;
            cmbColorType.SelectedIndex = 0;
            cmbBaudRate.SelectedIndex = 0;
            cmbRotateMode.SelectedIndex = 1;
            LEDSender.Do_LED_Startup();
            //LEDSender.Do_LED_CloseDeviceOnTerminate(1);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            LEDSender.Do_LED_Cleanup();
        }

        private void btnPowerOn_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_SetPower(ref param, 1));
        }

        private void btnPowerOff_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_SetPower(ref param, 0));
        }

        private void btnGetPower_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_GetPower(ref param));
        }

        private void btnSetBright_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_SetBright(ref param, 4));
        }

        private void btnGetBright_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_GetBright(ref param));
        }

        private void btnAdjustTime_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_AdjustTime(ref param));
        }

        private void btnVarString_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_SetVarStringSingle(ref param, Convert.ToInt32(oVarIndex.Value), oVarString.Text, 0xFFFF));
        }

        private void btnPowerSchedule_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            TPowerSchedule schedule = new TPowerSchedule();
            TSystemTime T = new TSystemTime();

            schedule.Enabled = 0x55AAAA55;  //启用定时开关屏功能，=0禁用
            schedule.Mode = 0;  //按照一周七天模式

            schedule.OpenTime = new TTimeStamp[21];
            schedule.CloseTime = new TTimeStamp[21];

            //注意，在此模式下，只取时间，日期（年月日）会被忽略掉，可以随意填写。
            //下面例子为每日8点开屏，17点关屏
            EncodeDateTime(ref T, 2012, 5, 2, 8, 0, 0, 0);
            SystemTimeToTimeStamp(ref T, ref schedule.OpenTime[0]); 	//周日
            SystemTimeToTimeStamp(ref T, ref schedule.OpenTime[3]);     //周一
            SystemTimeToTimeStamp(ref T, ref schedule.OpenTime[6]);     //周二
            SystemTimeToTimeStamp(ref T, ref schedule.OpenTime[9]);     //周三
            SystemTimeToTimeStamp(ref T, ref schedule.OpenTime[12]);	//周四
            SystemTimeToTimeStamp(ref T, ref schedule.OpenTime[15]);	//周五
            SystemTimeToTimeStamp(ref T, ref schedule.OpenTime[18]);	//周六
            EncodeDateTime(ref T, 2012, 5, 2, 17, 0, 0, 0);
            SystemTimeToTimeStamp(ref T, ref schedule.CloseTime[0]); 	//周日
            SystemTimeToTimeStamp(ref T, ref schedule.CloseTime[3]);    //周一
            SystemTimeToTimeStamp(ref T, ref schedule.CloseTime[6]);    //周二
            SystemTimeToTimeStamp(ref T, ref schedule.CloseTime[9]);    //周三
            SystemTimeToTimeStamp(ref T, ref schedule.CloseTime[12]);	//周四
            SystemTimeToTimeStamp(ref T, ref schedule.CloseTime[15]);	//周五
            SystemTimeToTimeStamp(ref T, ref schedule.CloseTime[18]);	//周六

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_SetPowerSchedule(ref param, ref schedule));
        }

        private void btnBrightSchedule_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            TBrightSchedule schedule = new TBrightSchedule();

            schedule.Enabled = 0x55AAAA55;  //启用定时开关屏功能，=0禁用

            schedule.Bright = new byte[24];

            schedule.Bright[0] = 3; //0-1点
            schedule.Bright[1] = 3;	//1-2点
            schedule.Bright[2] = 3;	//2-3点
            schedule.Bright[3] = 3;	//3-4点
            schedule.Bright[4] = 3;	//4-5点
            schedule.Bright[5] = 3;	//5-6点
            schedule.Bright[6] = 5;	//6-7点
            schedule.Bright[7] = 5;	//7-8点
            schedule.Bright[8] = 7;	//8-9点
            schedule.Bright[9] = 7;	//9-10点
            schedule.Bright[10] = 7;	//10-11点
            schedule.Bright[11] = 7;	//11-12点
            schedule.Bright[12] = 7;	//12-13点
            schedule.Bright[13] = 7;	//13-14点
            schedule.Bright[14] = 7;	//14-15点
            schedule.Bright[15] = 7;	//15-16点
            schedule.Bright[16] = 7;	//16-17点
            schedule.Bright[17] = 7;	//17-18点
            schedule.Bright[18] = 6;	//18-19点
            schedule.Bright[19] = 5;	//19-20点
            schedule.Bright[20] = 3;	//20-21点
            schedule.Bright[21] = 3;	//21-22点
            schedule.Bright[22] = 3;	//22-23点
            schedule.Bright[23] = 3;	//23-24点

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_SetBrightSchedule(ref param, ref schedule));
        }

        private void btnChapterCount_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_GetChapterCount(ref param));
        }

        private void btnSetCurChapter_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_SetCurChapter(ref param, 0));
        }

        private void btnGetCurChapter_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_GetCurChapter(ref param));
        }

        private void btnGetDisplay_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_GetPlayContent(ref param));
        }

        private void btnChapterEx_Click(object sender, EventArgs e)
        {
            TTimeStamp fromtime = new TTimeStamp();
            TTimeStamp totime = new TTimeStamp();
            TSystemTime T = new TSystemTime();
            
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            //此例程，按照每周周一、周三的8点到13点播放该节目
	        //开始时间 08:00:00  当按照每日时间播放时，fromtime和totime中的日期部分将被忽略掉 
            EncodeDateTime(ref T, 2013, 1, 1, 8, 0, 0, 0);
	        SystemTimeToTimeStamp(ref T, ref fromtime);
	        //结束时间 17:30:00
            EncodeDateTime(ref T, 2013, 1, 1, 17, 30, 0, 0);
	        SystemTimeToTimeStamp(ref T, ref totime);
            LEDSender.Do_AddChapterEx(K, 30000, LEDSender.WAIT_CHILD, 0, 1, (ushort)(LEDSender.CS_MON + LEDSender.CS_WED), ref fromtime, ref totime);
            //LEDSender.Do_AddChapterEx(K, 30000, LEDSender.WAIT_CHILD, 0, 1, 127, ref fromtime, ref totime);
            LEDSender.Do_AddRegion(K, 0, 0, 64, 64, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //自动换行的文字
            LEDSender.Do_AddTextEx(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world!", "宋体", 12, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 0, 6, 5, 1, 5, 0, 0, 3000);

            //此例程，按照每周周一、周三的8点到13点播放该节目
            //开始时间 08:00:00  当按照每日时间播放时，fromtime和totime中的日期部分将被忽略掉 
            EncodeDateTime(ref T, 2013, 1, 1, 8, 0, 0, 0);
            SystemTimeToTimeStamp(ref T, ref fromtime);
            //结束时间 17:00:00
            EncodeDateTime(ref T, 2013, 1, 1, 17, 0, 0, 0);
            SystemTimeToTimeStamp(ref T, ref totime);
            LEDSender.Do_AddChapterEx(K, 30000, LEDSender.WAIT_CHILD, 0, 1, (ushort)(LEDSender.CS_MON + LEDSender.CS_WED), ref fromtime, ref totime);
            //LEDSender.Do_AddChapterEx(K, 30000, LEDSender.WAIT_CHILD, 0, 1, 127, ref fromtime, ref totime);
            LEDSender.Do_AddRegion(K, 0, 0, 64, 64, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //自动换行的文字
            LEDSender.Do_AddTextEx(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "HELLO WORLD!", "宋体", 12, 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 0, 6, 5, 1, 5, 0, 0, 3000);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);

            //------------------------------------------------------------------------
            //第1分区
            LEDSender.Do_AddRegion(K, 0, 0, 64, 16, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //自动换行的文字
            LEDSender.Do_AddTextEx(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "111111111", "宋体", 12, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 0, 6, 5, 1, 5, 0, 0, 3000);
            //非自动换行的文字
            //LEDSender.Do_AddTextEx(K, 0, 16, 64, 32, LEDSender.V_TRUE, 0, "Hello world! Hello world! Hello World!", "宋体", 12, 0xff00, LEDSender.WFS_NONE, LEDSender.V_FALSE, 0, 0, 0, 7, 5, 1, 5, 0, 0, 3000);

            //第2页面
            //LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //非自动换行的文字(此函数可支持纵向显示)
            //LEDSender.Do_AddTextEx(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world!", "宋体", 12, 0xffff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 0, 0, 5, 0, 5, 0, 0, 5000);


            //------------------------------------------------------------------------
            //第2分区
            LEDSender.Do_AddRegion(K, 0, 16, 64, 16, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //自动换行的文字
            LEDSender.Do_AddTextEx(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "22222222", "宋体", 12, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 0, 6, 5, 1, 5, 0, 0, 3000);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnTextNoStruct_Click(object sender, EventArgs e)
        {
            Int32 param_index = 0;
            ushort K;

            GetDeviceParamWithoutStruct(param_index, (Int32)LEDSender.NOTIFY_EVENT, (Int32)Handle, WM_LED_NOTIFY);
 
            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 160, 128, 0);
            //添加表头
            LEDSender.Do_AddLeaf(K, 10000000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, 0, 0, 64, 16, 1, 0, "目的地        货物  数量  车长", "宋体", 12, 255, 0, 0, 0, 1, 5, 1, 5, 0, 0, 1000);
            LEDSender.Do_AddWindows(K, 0, 16, 64, 48, 1, 0);
            LEDSender.Do_AddChildText(K, "第1行\r\n第2行\r\n第3行\r\n第4行\r\n第5行", "宋体", 12, 255, 0, 0, 0, 3, 5, 0, 5, 0, 0, 20000);
            LEDSender.Do_AddChildText(K, "第6行\r\n第7行\r\n第8行\r\n第9行\r\n第10行", "宋体", 12, 255, 0, 0, 0, 3, 5, 0, 5, 0, 0, 20000);


            Parse(LEDSender.Do_LED_SendToScreen2(param_index, K));
        }

        private void btnDib_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;
            Graphics G;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 64, 64, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            G = Graphics.FromHwnd(pictureBox.Handle);
            //G = Graphics.FromHwnd(this.Handle);
            LEDSender.Do_AddWindow(K, 0, 0, 64, 64, LEDSender.V_TRUE, 0, (uint)G.GetHdc(), pictureBox.Image.Width, pictureBox.Image.Height, 0, 1, 1, 1, 1, 1, 0, 3000);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnPicFile_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddPicture(K, 0, 0, 128, 16, LEDSender.V_TRUE, 0, "C:\\Demo.bmp", 0, 2, 1, 1, 1, 1, 0, 1000);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnString_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //16点阵字体
            LEDSender.Do_AddString(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world! Hello world! Hello World!", LEDSender.FONT_SET_16, 0xff, 0, 1, 1, 1, 0, 1, 1000);

            //第2页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //24点阵字体
            LEDSender.Do_AddString(K, 0, 0, 64, 32, LEDSender.V_TRUE, 0, "Hello world! Hello world! Hello World!", LEDSender.FONT_SET_24, 0xff00, 3, 1, 1, 1, 1, 1, 1000);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnDateTime_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 64, 64, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddDateTimeEx(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, 0, "Times New Roman", 12, 0xffff, LEDSender.WFS_NONE, 0, 0, 0, 0, "#y-#m-#d");

            //第2页面
            //LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
              //此函数支持纵向显示
            //LEDSender.Do_AddDateTimeEx(K, 0, 16, 64, 32, LEDSender.V_TRUE, 0, 0, "Times New Roman", 12, 0xff00, LEDSender.WFS_NONE, 0, 0, 0, 0, "#h:#n:#s");

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnCountUp_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;
            TTimeStamp basetime = new TTimeStamp();
            TSystemTime T = new TSystemTime();
            DateTime dtNow = System.DateTime.Now;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);

            //目标时间正计时
            //    是指以指定的时间，开始计时。
            //    比如当前是2012-5-18 17:41:30，你调用函数时，指定的目标时间为2012-5-18 16:41:30，那么就是相对于2012-5-18 16:41:30这个时间的正计时，
            //    显示效果：01:00:00/01:00:01/01:00:02/......
            EncodeDateTime(ref T, (ushort)dtNow.Year, (ushort)dtNow.Month, (ushort)dtNow.Day, 1, 0, 0, 0);
            SystemTimeToTimeStamp(ref T, ref basetime);
            LEDSender.Do_AddCounter(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, LEDSender.CT_COUNTUP, LEDSender.CF_HNS, "Times New Roman", 12, 0xff, LEDSender.WFS_NONE, ref basetime);

            //普通正计时
            //    从00:00:00开始计时，到指定的时间停止计时
            //    显示效果：00:00:00/00:00:01/00:00:02/....../01:28:59/01:29:00
            EncodeDateTime(ref T, 1899, 1, 1, 1, 29, 0, 0);
            SystemTimeToTimeStamp(ref T, ref basetime);
            LEDSender.Do_AddCounter(K, 0, 16, 64, 16, LEDSender.V_TRUE, 0, LEDSender.CT_COUNTUP_EX, LEDSender.CF_HNS, "Times New Roman", 12, 0xff, LEDSender.WFS_NONE, ref basetime);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnCountDown_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;
            TTimeStamp basetime=new TTimeStamp();
            TSystemTime T = new TSystemTime();
            DateTime dtNow = System.DateTime.Now;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);

            //目标时间倒计时
            //    是指以指定的时间为目标，进行倒计时。
            //    比如当前是2012-5-18 17:41:30，你调用函数时，指定的目标时间为2012-5-18 19:41:30，那么就是相对于2012-5-18 19:41:30这个时间的倒计时，
            //    显示效果：02:00:00/01:59:59/01:59:58/......
            EncodeDateTime(ref T, (ushort)dtNow.Year, (ushort)dtNow.Month, (ushort)dtNow.Day, 23, 59, 59, 0);
	        SystemTimeToTimeStamp(ref T, ref basetime);
            LEDSender.Do_AddCounter(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, LEDSender.CT_COUNTDOWN, LEDSender.CF_HNS, "Times New Roman", 12, 0xff, LEDSender.WFS_NONE, ref basetime);

            //普通倒计时
            //    从指定的时间开始计时，到00:00:00停止计时
            //    显示效果：01:29:00/01:28:59/01:28:58/....../00:00:01/00:00:00
            EncodeDateTime(ref T, 1899, 1, 1, 1, 29, 0, 0);
            SystemTimeToTimeStamp(ref T, ref basetime);
            LEDSender.Do_AddCounter(K, 0, 16, 64, 16, LEDSender.V_TRUE, 0, LEDSender.CT_COUNTDOWN_EX, LEDSender.CF_HNS, "Times New Roman", 12, 0xff, LEDSender.WFS_NONE, ref basetime);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnCampaign_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;
            TTimeStamp basetime=new TTimeStamp();
            TTimeStamp fromtime = new TTimeStamp();
            TTimeStamp totime = new TTimeStamp();
            TSystemTime T = new TSystemTime();
            
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddDateTime(K, 0, 0, 256, 16, LEDSender.V_TRUE, 0, "Times New Roman", 12, 0xff, LEDSender.WFS_NONE, 0, 0, 0, 0, "#y-#m-#d");

	        //作战时间 2020-06-01 07:00:00
            EncodeDateTime(ref T, 2020, 6, 1, 7, 0, 0, 0);
	        SystemTimeToTimeStamp(ref T, ref basetime);
	        //开始时间 2012-05-02 09:00:00
            EncodeDateTime(ref T, 2012, 5, 2, 9, 0, 0, 0);
            SystemTimeToTimeStamp(ref T, ref fromtime);
            //结束时间 2012-05-02 10:00:00
            EncodeDateTime(ref T, 2012, 5, 2, 10, 0, 0, 0);
            SystemTimeToTimeStamp(ref T, ref totime);
            LEDSender.Do_AddCampaign(K, 0, 16, 256, 16, LEDSender.V_TRUE, 0, "Times New Roman", 12, 0xff, LEDSender.WFS_NONE, "#h-#n-#s", ref basetime, ref fromtime, ref totime, 1000);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnClock_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 64, 64, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddClockEx2(K, 0, 0, 64, 64, LEDSender.V_TRUE, 0, 0, 0, 0x0, 0xffff, 1, LEDSender.SHAPE_ROUNDRECT, 30, 3, 0xff00, 2, 0xffff, 0, 1, 0xff, 3, 0xffff, 2, 0xff00, 1, 0xff);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnTemperature_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 64, 64, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddTemperature(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Times New Roman", 12, 0xffff, LEDSender.WFS_NONE);
            LEDSender.Do_AddHumidity(K, 0, 16, 64, 16, LEDSender.V_TRUE, 0, "Times New Roman", 12, 0xffff, LEDSender.WFS_NONE);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnGetTemperature_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_GetTemperatureHumidity(ref param));
        }

        private void btnComTransfer_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_ComTransferHex(ref param, "552131323323AA", 10));
            //如果是485口转发，请使用下面这句
            //Parse(LEDSender.Do_LED_ModemTransferHex(ref param, "552131323323AA", 10));
        }

        private void btnTransferAck_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Parse(LEDSender.Do_LED_GetTransferAck(ref param));
        }

        private void btnVsqFile_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            K = (ushort)LEDSender.Do_MakeFromVsqFile("D:\\MyWorks\\ACard2008\\MyPlayer\\demo.vsq", LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void Parse2(Int32 K)
        { 
            TNotifyParam notifyparam = new TNotifyParam();
            if (K >= 0)
            {
                LEDSender.Do_LED_GetNotifyParam(ref notifyparam, K);

                if (notifyparam.notify == LEDSender.LM_TIMEOUT)
                {
                    Text = "命令执行超时";
                }
                else if (notifyparam.notify == LEDSender.LM_TX_COMPLETE)
                {
                    if (notifyparam.result == LEDSender.RESULT_FLASH)
                    {
                        Text = "数据传送完成，正在写入Flash";
                    }
                    else
                    {
                        Text = "数据传送完成";
                    }
                }
                else if (notifyparam.notify == LEDSender.LM_RESPOND)
                {
                    if (notifyparam.command == LEDSender.PKC_GET_POWER)
                    {
                        if (notifyparam.status == LEDSender.LED_POWER_ON) Text = "读取电源状态完成，当前为电源开启状态";
                        else if (notifyparam.status == LEDSender.LED_POWER_OFF) Text = "读取电源状态完成，当前为电源关闭状态";
                    }
                    else if (notifyparam.command == LEDSender.PKC_SET_POWER)
                    {
                        if (notifyparam.result == 99) Text = "当前为定时开关屏模式";
                        else if (notifyparam.status == LEDSender.LED_POWER_ON) Text = "设置电源状态完成，当前为电源开启状态";
                        else Text = "设置电源状态完成，当前为电源关闭状态";
                    }
                    else if (notifyparam.command == LEDSender.PKC_GET_BRIGHT)
                    {
                        Text = string.Format("读取亮度完成，当前亮度={0:D}", notifyparam.status);
                    }
                    else if (notifyparam.command == LEDSender.PKC_SET_BRIGHT)
                    {
                        if (notifyparam.result == 99) Text = "当前为定时亮度调节模式";
                        else Text = string.Format("设置亮度完成，当前亮度={0:D}", notifyparam.status);
                    }
                    else if (notifyparam.command == LEDSender.PKC_ADJUST_TIME)
                    {
                        Text = "校正显示屏时间完成";
                    }
                }
            }
            else if (K == LEDSender.R_DEVICE_INVALID) Text = "打开通讯设备失败(串口不存在、或者串口已被占用、或者网络端口被占用)";
            else if (K == LEDSender.R_DEVICE_BUSY) Text = "设备忙，正在通讯中...";
        }

        private void btnPowerOn2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_SetPower(ref param, 1));
        }

        private void btnPowerOff2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_SetPower(ref param, 0));
        }

        private void btnGetPower2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_GetPower(ref param));
        }

        private void btnSetBright2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_SetBright(ref param, 4));
        }

        private void btnGetBright2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_GetBright(ref param));
        }

        private void btnAdjustTime2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_AdjustTime(ref param));
        }

        private void btnText2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //自动换行的文字
            LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world! HELLO WORLD!", "宋体", 12, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 1, 1, 1, 0, 1, 3);
            //非自动换行的文字
            LEDSender.Do_AddText(K, 0, 16, 64, 32, LEDSender.V_TRUE, 0, "Hello world! Hello world! Hello World!", "宋体", 12, 0xff00, LEDSender.WFS_NONE, LEDSender.V_FALSE, 0, 2, 1, 1, 1, 1, 1, 3);

            //第2页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //非自动换行的文字
            LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world!", "宋体", 12, 0xffff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 1, 1, 1, 1, 1, 5);

            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnDib2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //LEDSender.Do_AddWindow(K, 0, 0, 64, 16, LEDSender.V_TRUE, pictureBox.Handle, pictureBox.Image.Width, pictureBox.Image.Height, 0, 0, 1, 1, 1, 0, 1, 3);

            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnPicFile2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddPicture(K, 0, 0, 128, 16, LEDSender.V_TRUE, 0, "C:\\Demo.bmp", 0, 2, 1, 1, 1, 1, 0, 1000);

            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnString2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //16点阵字体
            LEDSender.Do_AddString(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world! Hello world! Hello World!", LEDSender.FONT_SET_16, 0xff, 0, 1, 1, 1, 0, 1, 1000);

            //第2页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //24点阵字体
            LEDSender.Do_AddString(K, 0, 0, 64, 32, LEDSender.V_TRUE, 0, "Hello world! Hello world! Hello World!", LEDSender.FONT_SET_24, 0xff00, 3, 1, 1, 1, 1, 1, 1000);

            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnDateTime2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddDateTime(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Times New Roman", 12, 0xff, LEDSender.WFS_NONE, 0, 0, 0, 0, "#y-#m-#d");

            //第2页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddDateTime(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Times New Roman", 12, 0xff00, LEDSender.WFS_NONE, 0, 0, 0, 0, "#h:#n:#s");

            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnClock2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddClock(K, 0, 0, 64, 64, LEDSender.V_TRUE, 0, 0, 0x0, 0xffff, 1, LEDSender.SHAPE_ROUNDRECT, 30, 3, 0xff00, 2, 0xffff, 3, 0xffff, 2, 0xff00, 1, 0xff);

            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnVsqFile2_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            K = (ushort)LEDSender.Do_MakeFromVsqFile("D:\\MyWorks\\ACard2008\\MyPlayer\\demo.vsq", LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);

            Text = "正在执行命令或者发送数据...";
            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnChapter_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            //这个操作中，ChapterIndex=0，只更新控制卡内第1个节目
            //如果ChapterIndex=1，只更新控制卡内第2个节目
            //以此类推
            K = (ushort)LEDSender.Do_MakeChapter(LEDSender.ROOT_PLAY_CHAPTER, LEDSender.ACTMODE_REPLACE, 0, GetColorType(), 5000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world! HELLO WORLD!", "宋体", 12, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 1, 1, 1, 0, 1, 3);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnRegion_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            //这个操作中，ChapterIndex=0，RegionIndex=0，只更新控制卡内第1个节目中的第1个分区
            //如果ChapterIndex=1，RegionIndex=2，只更新控制卡内第2个节目中的第3个分区
            //以此类推

            //更新第1分区
            K = (ushort)LEDSender.Do_MakeRegion(LEDSender.ROOT_PLAY_REGION, LEDSender.ACTMODE_REPLACE, 0, 0, GetColorType(), 0, 0, 64, 16, 0);
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "更新1分区", "宋体", 12, 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 1, 1, 1, 0, 1, 3);

            //更新第2分区
            //K = (ushort)LEDSender.Do_MakeRegion(LEDSender.ROOT_PLAY_REGION, LEDSender.ACTMODE_REPLACE, 0, 1, GetColorType(), 0, 16, 64, 16, 0);
            //LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "更新2分区", "宋体", 12, 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 1, 1, 1, 0, 1, 3);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnLeaf_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            //这个操作中，ChapterIndex=0，RegionIndex=0，LeafIndex=0，只更新控制卡内第1个节目中的第1个分区中的第1个页面
            //如果ChapterIndex=1，RegionIndex=2，LeafIndex=1，只更新控制卡内第2个节目中的第3个分区中的第2个页面
            //以此类推
            K = (ushort)LEDSender.Do_MakeLeaf(LEDSender.ROOT_PLAY_LEAF, LEDSender.ACTMODE_REPLACE, 0, 0, 0, GetColorType(), 5000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world! HELLO WORLD!", "宋体", 12, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 1, 1, 1, 0, 1, 3);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnOnlineServerStartup_Click(object sender, EventArgs e)
        {
            if (LEDSender.Do_LED_Report_CreateServer(0, 8888) > 0)
            {
                Text = "在线控制卡监听服务启动成功，在8888端口进行监听";
            }
            else
            {
                Text = "在线控制卡监听服务已启动，8888端口当前被占用，请检查是否有其它应用程序使用该端口";
            }
            //可以创建多个监听服务，例如继续调用LED_Report_CreateServer(1, 8889);
            //则表示创建了两个监听，一个在8888端口，一个在8889端口
        }

        private void btnOnlineServerCleanup_Click(object sender, EventArgs e)
        {
            LEDSender.Do_LED_Report_RemoveServer(0);
            //或者调用 LED_Report_RemoveAllServer();
        }

        private void btnOnlineGetList_Click(object sender, EventArgs e)
        {
            int devcount;
            int I;
            String S;

            //将在线控制卡列表保存在动态链接库的缓冲区中，然后调用相应接口读取详细信息
            devcount = LEDSender.Do_LED_Report_GetOnlineList(0);

            S = "在线控制卡数量=" + Convert.ToString(devcount) + "\r\n名称 IP地址 端口 硬件地址\r\n";
            for (I = 0; I < devcount; I++)
            {
                S = S + LEDSender.Do_LED_Report_GetOnlineItemName(0, I) + " " +
                        LEDSender.Do_LED_Report_GetOnlineItemHost(0, I) + " " +
                        Convert.ToString(LEDSender.Do_LED_Report_GetOnlineItemPort(0, I)) + " " +
                        Convert.ToString(LEDSender.Do_LED_Report_GetOnlineItemAddr(0, I)) + "\r\n";
            }

            System.Windows.Forms.MessageBox.Show(S);
        }

        private void btnObject_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            //这个操作中，ChapterIndex=0，RegionIndex=0，LeafIndex=0，ObjectIndex=0 只更新控制卡内第1个节目中的第1个分区中的第1个页面中的第1个对象
            //如果ChapterIndex=1，RegionIndex=2，LeafIndex=1，ObjectIndex=2只更新控制卡内第2个节目中的第3个分区中的第2个页面中的第3个对象
            //以此类推
            K = (ushort)LEDSender.Do_MakeObject(LEDSender.ROOT_PLAY_OBJECT, LEDSender.ACTMODE_REPLACE, 0, 0, 0, 0, GetColorType());
            LEDSender.Do_AddText(K, 0, 0, 64, 64, LEDSender.V_TRUE, 0, "Hello world!\r\nHELLO WORLD!", "宋体", 12, 0xffff, LEDSender.WFS_NONE, LEDSender.V_FALSE, 0, 0, 5, 0, 5, 0, 1, 3);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnTimerTest_Click(object sender, EventArgs e)
        {
            if (timerMain.Enabled)
            {
                timerMain.Enabled = false;
                btnTimerTest.Text = "启动定时发送测试";
            }
            else
            {
                timerMain.Interval = 5000;
                timerMain.Enabled = true;
                btnTimerTest.Text = "停止定时发送测试";
            }
        }

        //UInt32 serialno = 0;

        private void timerMain_Tick(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            //ushort I;
            ushort K;
            //string text;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, 0, 0, 256, 64, LEDSender.V_TRUE, 0, "欢迎光临", "宋体", 12, 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 1, 5, 1, 1, 0, 1, 3000);
            LEDSender.Do_AddText(K, 0, 64, 256, 64, LEDSender.V_TRUE, 0, "欢迎光临欢迎光临欢迎光临欢迎光临", "宋体", 128, 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 1, 5, 1, 1, 0, 1, 3000);
            Text = "<" + param.devParam.rmtHost + ">正在发送数据...";
            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));

            /*
            for (I = 166; I <= 169; I++)
            {
                param.devParam.rmtHost = "192.168.1." + I;
                K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
                LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
                LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);
                LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
                text = "IP=" + I + "\r\n" + "序列号=" + serialno;
                serialno++;
                LEDSender.Do_AddText(K, 0, 0, 256, 64, LEDSender.V_TRUE, 0, text, "宋体", 12, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 1, 5, 1, 1, 0, 1, 3000);
                Text = "<" + param.devParam.rmtHost + ">正在发送数据...";
                Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
            }
            */
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 128, 32, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);

            LEDSender.Do_AddTable(K, 0, 0, 256, 64, LEDSender.V_TRUE, "Table.ini", "[ Color=$FF BkColor=$FF00 ]aaa|[ Color=$FF00 BkColor=$FF ]bbb|[Y]ccc\r\n111|222|333", 1, 5, 1, 1, 0, 1, 3000);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnCanvas_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;
            Int32 cy1, cy2, cy3;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, 1024, 512, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000000, LEDSender.WAIT_CHILD);

            /*
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 一些画直线、矩形、椭圆形、单行文字的例子
            LEDSender.Do_UserCanvas_Init(64, 64);
            LEDSender.Do_UserCanvas_Draw_Line(0, 0, 64, 64, 3, 0xffff);
            LEDSender.Do_UserCanvas_Draw_Rectangle(1, 1, 64, 64, 2, 0xff00, 0x1000000);
            LEDSender.Do_UserCanvas_Draw_Ellipse(16, 16, 48, 48, 2, 0xff, 0xff00);
            LEDSender.Do_UserCanvas_Draw_Text(0, 0, 64, 16, "测试", "宋体", 9, 0xffff, 0, 0);
            LEDSender.Do_AddUserCanvas(K, 0, 0, 64, 64, LEDSender.V_TRUE, 0, 1, 5, 2, 1, 0, 1, 3000);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            */

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 制作一个多行文字的显示效果，并且使用不同的颜色
            cy1 = LEDSender.Do_UserCanvas_Calc_MatrixHeight(128, "明月几时有，把酒问青天。不知天上宫阙，今夕是何年？", "宋体", 12, 0xFF, 0);
            cy2 = LEDSender.Do_UserCanvas_Calc_MatrixHeight(128, "我欲乘风归去，唯恐琼楼玉宇，高处不胜寒。起舞弄清影，何似在人间。", "楷体GB_2312", 12, 0xFF00, 0);
            cy3 = LEDSender.Do_UserCanvas_Calc_MatrixHeight(128, "转朱阁，低绮户，照无眠。不应有恨，何事长向别时圆。人有悲欢离合，月有阴晴圆缺，此事古难全。", "隶书", 12, 0xFFFF, 0);
            LEDSender.Do_UserCanvas_Init(128, cy1+cy2+cy3);
            LEDSender.Do_UserCanvas_Draw_TextEx(0, 0, 128, cy1, "明月几时有，把酒问青天。不知天上宫阙，今夕是何年？", "宋体", 12, 0xFF, 0, 0);
            LEDSender.Do_UserCanvas_Draw_TextEx(0, cy1, 128, cy2, "我欲乘风归去，唯恐琼楼玉宇，高处不胜寒。起舞弄清影，何似在人间。", "楷体GB_2312", 12, 0xFF00, 0, 0);
            LEDSender.Do_UserCanvas_Draw_TextEx(0, cy1 + cy2, 128, cy3, "转朱阁，低绮户，照无眠。不应有恨，何事长向别时圆。人有悲欢离合，月有阴晴圆缺，此事古难全。", "隶书", 12, 0xFFFF, 0, 0);
            LEDSender.Do_AddUserCanvas(K, 0, 0, 128, 64, LEDSender.V_TRUE, 0, 7, 5, 2, 1, 0, 1, 3000);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));

            //此接口用于预览生成节目的显示效果
            //LEDSender.Do_LED_Preview(K, 160, 128, "C:\\Commit.dat");
        }

        private void btnBoardParam_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = (UInt32)WM_LED_NOTIFY;
            Text = "正在执行命令或者发送数据...";
            if (LEDSender.Do_LED_Cache_GetBoardParam(ref param) >= 0)
            {
                LEDSender.Do_LED_Cache_SetBoardParam_IP("192.168.0.99");
                LEDSender.Do_LED_Cache_SetBoardParam_Mac("01-01-F1-DE-1A-02");
                LEDSender.Do_LED_Cache_SetBoardParam_Addr(0);
                LEDSender.Do_LED_Cache_SetBoardParam_Width(256);
                LEDSender.Do_LED_Cache_SetBoardParam_Height(64);
                LEDSender.Do_LED_Cache_SetBoardParam_Brightness(7);
                LEDSender.Do_LED_Cache_SetBoardParam_Frequency(LEDSender.Do_LED_Cache_GetBoardParam_Frequency());
                Parse2(LEDSender.Do_LED_Cache_SetBoardParam(ref param));
            }
            else
            {
                Text = "读取控制卡参数失败";
            }
        }

        private void btnMultiCard_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;
            int x, y, cx, cy;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_BLOCK;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            x = 0;
            y = 0;
            cx = 320;
            cy = 176;

            //----------------------------

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);

            LEDSender.Do_AddChapter(K, 1000, LEDSender.WAIT_USE_TIME);
            LEDSender.Do_AddRegion(K, x, y, cx, cy, 0);
            LEDSender.Do_AddLeaf(K, 1000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, x, y, cx, cy, LEDSender.V_TRUE, 0, "行人通过马路时，请注意安全。珍惜生命，严禁酒后驾车。开车时请您系好安全带。", "宋体", 24, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 1, 1, 1, 1, 0, 1, 3);

            LEDSender.Do_AddChapter(K, 1000, LEDSender.WAIT_USE_TIME);
            LEDSender.Do_AddRegion(K, x, y, cx, cy, 0);
            LEDSender.Do_AddLeaf(K, 1000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, x, y, cx, cy, LEDSender.V_TRUE, 0, "行人通过马路时，请注意安全。珍惜生命，严禁酒后驾车。开车时请您系好安全带。", "宋体", 24, 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 1, 1, 1, 1, 0, 1, 3);

            Text = "正在发送1...";
            param.devParam.rmtHost = "43.35.162.36";
            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));

            //----------------------------

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);

            LEDSender.Do_AddChapter(K, 1000, LEDSender.WAIT_USE_TIME);
            LEDSender.Do_AddRegion(K, x, y, cx, cy, 0);
            LEDSender.Do_AddLeaf(K, 1000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, x, y, cx, cy, LEDSender.V_TRUE, 0, "行人通过马路时，请注意安全。珍惜生命，严禁酒后驾车。开车时请您系好安全带。", "宋体", 24, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 1, 1, 1, 1, 0, 1, 3);

            LEDSender.Do_AddChapter(K, 1000, LEDSender.WAIT_USE_TIME);
            LEDSender.Do_AddRegion(K, x, y, cx, cy, 0);
            LEDSender.Do_AddLeaf(K, 1000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, x, y, cx, cy, LEDSender.V_TRUE, 0, "行人通过马路时，请注意安全。珍惜生命，严禁酒后驾车。开车时请您系好安全带。", "宋体", 24, 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 1, 1, 1, 1, 0, 1, 3);

            Text = "正在发送2...";
            param.devParam.rmtHost = "43.35.162.37";
            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));

            //----------------------------

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);

            LEDSender.Do_AddChapter(K, 1000, LEDSender.WAIT_USE_TIME);
            LEDSender.Do_AddRegion(K, x, y, cx, cy, 0);
            LEDSender.Do_AddLeaf(K, 1000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, x, y, cx, cy, LEDSender.V_TRUE, 0, "行人通过马路时，请注意安全。珍惜生命，严禁酒后驾车。开车时请您系好安全带。", "宋体", 24, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 1, 1, 1, 1, 0, 1, 3);

            LEDSender.Do_AddChapter(K, 1000, LEDSender.WAIT_USE_TIME);
            LEDSender.Do_AddRegion(K, x, y, cx, cy, 0);
            LEDSender.Do_AddLeaf(K, 1000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, x, y, cx, cy, LEDSender.V_TRUE, 0, "行人通过马路时，请注意安全。珍惜生命，严禁酒后驾车。开车时请您系好安全带。", "宋体", 24, 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 1, 1, 1, 1, 0, 1, 3);

            Text = "正在发送3...";
            param.devParam.rmtHost = "43.35.162.35";
            Parse2(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnRotatePicture_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;
            ushort AWidth, AHeight;

            OpenFileDialog ofd = new OpenFileDialog();//新建打开文件对话框
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//设置初始文件目录
            ofd.Filter = "图片文件(*.bmp)|*.bmp";//设置打开文件类型
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = ofd.FileName;//FileName就是要打开的文件路径

                //下边可以添加用户代码     
                AWidth = (ushort)Convert.ToInt16(eRotateWidth.Text);
                AHeight = (ushort)Convert.ToInt16(eRotateHeight.Text);
                LEDSender.Do_SetRotate(cmbRotateMode.SelectedIndex, AWidth, AHeight);

                GetDeviceParam(ref param.devParam);
                param.notifyMode = LEDSender.NOTIFY_EVENT;
                param.wmHandle = (UInt32)Handle;
                param.wmMessage = WM_LED_NOTIFY;

                K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
                LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
                LEDSender.Do_AddRegion(K, 0, 0, AWidth, AHeight, 0);

                //第1页面
                LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
                LEDSender.Do_AddPicture(K, 0, 0, AWidth, AHeight, LEDSender.V_TRUE, 0, FileName, 0, 1, 1, 1, 1, 0, 0, 1000);

                Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
            }
        }

        private void btnRotateText_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;
            ushort AWidth, AHeight;

            //下边可以添加用户代码     
            AWidth = (ushort)Convert.ToInt16(eRotateWidth.Text);
            AHeight = (ushort)Convert.ToInt16(eRotateHeight.Text);
            LEDSender.Do_SetRotate(cmbRotateMode.SelectedIndex, AWidth, AHeight);

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 30000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddRegion(K, 0, 0, AWidth, AHeight, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "Hello world! HELLO WORLD!", "宋体", 12, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 1, 1, 1, 0, 1, 3);

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

        private void btnImportProtocol_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            string str;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_NONE;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            //此处str存放的是光带协议，首字节是0x55，末字节是0xAA
            //如下面例子，发送 0x55,0x40,0x30,0x31,0x32,0x33,0x32,0xAA
            //相当于0x55+"@123*"+0xAA
            str = "5540303132332AAA";
            LEDSender.Do_LED_SendHexDirectly(ref param, str);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ushort K;
            String txt; 

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 86400000, LEDSender.WAIT_CHILD);

            LEDSender.Do_AddRegion(K, 0, 0, 160, 128, 0);
            //LEDSender.Do_AddLeaf(K, 1000, LEDSender.WAIT_CHILD);
            //LEDSender.Do_AddTextEx(K, 0, 0, 160, 128, 1, 0, "明月几时有，把酒问青天。", "宋体", 12, 65535, 0, 1, 0, 0, 0, 3, 5, 2, 5, 0, 0, 3000);
            //LEDSender.Do_AddLeaf(K, 1000, LEDSender.WAIT_CHILD);
            //LEDSender.Do_AddTextEx(K, 0, 0, 160, 128, 1, 0, "明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。", "宋体", 12, 65535, 0, 1, 0, 0, 0, 7, 5, 2, 5, 0, 0, 3000);
            txt = "01明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "02明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "03明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "04明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "05明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "06明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "07明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "08明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "09明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "10明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "11明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "12明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "13明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "14明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "15明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "16明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "17明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "18明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "19明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            txt = txt + "20明月几时有，把酒问青天。不知天上宫阙，今夕是何年？我欲乘风归去，惟恐琼楼玉宇，高处不胜寒。";
            LEDSender.Do_AddLeaf(K, 1000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddTextEx(K, 0, 0, 160, 96, 1, 0, txt, "宋体", 9, 0xFF, 0, 1, 0, 0, 0, 7, 5, 2, 5, 0, 0, 3000);
            /*
            //------------------------------------------------------------------------
            //第1分区
            LEDSender.Do_AddRegion(K, 0, 0, 64, 48, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 5000, LEDSender.WAIT_CHILD);
            //自动换行的文字
            LEDSender.Do_AddText(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "欢迎光临", "宋体", 12, 0xff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 6, 0, 6, 0, 0, 1000);
            //自动换行的文字
            LEDSender.Do_AddTextEx(K, 0, 16, 64, 48, LEDSender.V_TRUE, 0, "同一个世界，同一个梦想", "宋体", 12, 0xff00, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 8, 3, 6, 2, 6, 0, 0, 0);

            //第2页面
            LEDSender.Do_AddLeaf(K, 5000, LEDSender.WAIT_CHILD);
            LEDSender.Do_AddString(K, 0, 0, 64, 64, 1, 0, "16点阵宋体文字示例", 0, 0xff, 2, 5, 0, 5, 0, 0, 1000);

            //第2页面
            LEDSender.Do_AddLeaf(K, 5000, LEDSender.WAIT_CHILD);
            //日期时间
            LEDSender.Do_AddDateTimeEx(K, 0, 4, 64, 16, LEDSender.V_TRUE, 0, 0, "Times New Roman", 12, 0xff, LEDSender.WFS_NONE, 0, 0, 0, 0, "#m月#d日");
            LEDSender.Do_AddDateTimeEx(K, 0, 24, 64, 16, LEDSender.V_TRUE, 0, 0, "Times New Roman", 12, 0xff00, LEDSender.WFS_NONE, 0, 0, 0, 0, "#h:#n:#s");


            ///*
            //------------------------------------------------------------------------
            //第2分区
            LEDSender.Do_AddRegion(K, 0, 48, 64, 16, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 10000, LEDSender.WAIT_CHILD);
            //自动换行的文字
            LEDSender.Do_AddTextEx(K, 0, 0, 64, 16, LEDSender.V_TRUE, 0, "显示屏测试...", "宋体", 12, 0xffff, LEDSender.WFS_NONE, LEDSender.V_TRUE, 0, 0, 0, 6, 5, 1, 5, 0, 0, 3000);
            //*/

            //此接口用于预览生成节目的显示效果
            LEDSender.Do_LED_Preview(K, 160, 128, "C:\\Commit.dat");
        }

        private void btnScheduleText_Click(object sender, EventArgs e)
        {
            TSenderParam param = new TSenderParam();
            ushort K;

            GetDeviceParam(ref param.devParam);
            param.notifyMode = LEDSender.NOTIFY_EVENT;
            param.wmHandle = (UInt32)Handle;
            param.wmMessage = WM_LED_NOTIFY;

            K = (ushort)LEDSender.Do_MakeRoot(LEDSender.ROOT_PLAY, GetColorType(), LEDSender.SURVIVE_ALWAYS);
            LEDSender.Do_AddChapter(K, 86400000, LEDSender.WAIT_CHILD);

            //------------------------------------------------------------------------
            //第1分区
            LEDSender.Do_AddRegion(K, 0, 0, 64, 16, 0);

            //第1页面
            LEDSender.Do_AddLeaf(K, 86400000, LEDSender.WAIT_CHILD);

            LEDSender.Do_AddWindows(K, 0, 0, 64, 16, 1, 0);
            LEDSender.Do_AddChildText(K, "00000000  ", "宋体", 12, 255, 0, 0, 0, 6, 5, 0, 5, 0, 0, 0);
            LEDSender.Do_AddChildScheduleText(K, "11111111  ", "宋体", 12, 255, 0, 0, 0, 6, 5, 0, 5, 0, 0, 0, 1, (ushort)(LEDSender.CS_EVERYDAY), "11:03:00", "15:06:59");
            LEDSender.Do_AddChildScheduleText(K, "22222222  ", "宋体", 12, 255, 0, 0, 0, 6, 5, 0, 5, 0, 0, 0, 1, (ushort)(LEDSender.CS_EVERYDAY), "14:41:00", "15:08:59");
            LEDSender.Do_AddChildScheduleText(K, "33333333  ", "宋体", 12, 255, 0, 0, 0, 6, 5, 0, 5, 0, 0, 0, 1, (ushort)(LEDSender.CS_EVERYDAY), "12:08:00", "15:09:59");
            LEDSender.Do_AddChildScheduleText(K, "44444444  ", "宋体", 12, 255, 0, 0, 0, 6, 5, 0, 5, 0, 0, 0, 1, (ushort)(LEDSender.CS_EVERYDAY), "15:10:00", "15:59:59");

            Parse(LEDSender.Do_LED_SendToScreen(ref param, K));
        }

     }
}
