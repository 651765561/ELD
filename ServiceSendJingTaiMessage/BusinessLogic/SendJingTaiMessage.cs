using Quartz;
using Quartz.Impl;
using ServiceSendJingTaiMessage.Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;


namespace ServiceSendJingTaiMessage.BusinessLogic
{
    public class SendJingTaiMessage
    {
        System.Timers.Timer t;

        bool flag = true;

        public SendJingTaiMessage()
        {
            //t = new System.Timers.Timer(1000 * 60 * 2);//实例化Timer类，设置时间间隔
            //t.Elapsed += new System.Timers.ElapsedEventHandler(Method2);//到达时间的时候执行事件
            //t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)
            //t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件
        }
        void Method1()
        {
            while (true)
            {
                //  Console.WriteLine(DateTime.Now.ToString() + "_" + Thread.CurrentThread.ManagedThreadId.ToString());
                if (flag)
                {
                    SendMessage();
                }

                Thread.CurrentThread.Join(1000 * 60 * 1);//阻止设定时间
            }
        }
        void Method2(object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString() + "_" + Thread.CurrentThread.ManagedThreadId.ToString());
            SendMessage();
        }

        public void run()
        {
            Thread thread = new Thread(new ThreadStart(Method1));
            thread.Start();
        }
        public void Start()
        {
            flag = true;
            //  t.Start();
            //
            Thread thread = new Thread(new ThreadStart(Method1));
            thread.Start();

            ///
            //Thread threadp = new Thread(new ThreadStart(SendJingTaiMessageToLed));
            //threadp.IsBackground = true;
            //threadp.Start();
        }
        public void Stop()
        {
            //  t.Stop();
            flag = false;
        }
        public void Continue(HostControl hostControl) { }

        private void SendMessage()
        {

            try
            {
                ELDService bll = new ELDService();
                TDeviceParam p = new TDeviceParam();
                CLEDSender LEDSender = new CLEDSender();
                DBELD dbELD = new DBELD();
                var list = dbELD.GetJingTaiXinForSendByIP();
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];

                    //相机参数
                    MyTDeviceParam p1 = new MyTDeviceParam();
                    p1.devType = LEDSender.DEVICE_TYPE_UDP;
                    //获取相机基本信息
                    string ip = item.led_ip;
                    //  var camera = dbELD.GetEldModel(ip);
                    p1.dstAddr = 0;
                    p1.locPort = item.locPort;
                    p1.rmtPort = item.rmtPort;
                    p1.rmtHost = ip;


                    //发送文本参数
                    DisplayObj displayTextObj = new DisplayObj();
                    displayTextObj.ObjTypeIndex = 0;
                    TextPro textPro = new TextPro();
                    textPro.top = item.text_top;
                    textPro.width = item.text_width;
                    textPro.border = 0;
                    //textPro.fontcolor = 0xff;
                    textPro.fontcolor = item.text_color;
                    textPro.fontname = "宋体";
                    textPro.fontsize = item.text_size;
                    textPro.fontstyle = LEDSender.WFS_NONE;
                    textPro.height = item.text_height;
                    textPro.inmethod = item.text_in;
                    textPro.inspeed = 1;
                    textPro.left = 0;
                    textPro.outmethod = item.text_out;
                    textPro.outspeed = 1;
                    textPro.alignment = 0;
                    textPro.stopmethod = item.text_stop;
                    textPro.stoptime = 1000;
                    textPro.transparent = LEDSender.V_TRUE;
                    textPro.wordwrap = item.wordwrap;
                    textPro.str = item.value;

                    displayTextObj.TextPro = textPro;
                    string str = "";
                    str = bll.SendObjToELD(p1, displayTextObj, item.region);
                    str = "IP:" + ip + ";" + str + ";发送内容：" + item.value;
                    Thread.Sleep(10);
                    if (str.Trim() == "数据传送完成")
                    {
                        int messageID = Convert.ToInt32(item.messageID);
                        bool flag = dbELD.Update_Led_send_prepare_Status(messageID, 1);
                        //   dbELD.UpdateELDEnable(ip, 0);
                    }
                    else
                    {
                        int messageID = Convert.ToInt32(item.messageID);
                        bool flag = dbELD.Update_Led_send_prepare_Status(messageID, 0);
                        //    dbELD.UpdateELDEnable(ip, 0);

                    }
                    WriteFile(@"d:\静态信息扫描ELD设备日志\", "静态信息扫描ELD" + ip, str);
                }

            }
            catch (Exception ex)
            {

                WriteFile(@"d:\静态信息扫描ELD设备日志\", "静态信息扫描ELD_Error", ex.ToString());
            }
        }
        public void SendJingTaiMessageToLed()
        {
            while (true)
            {
                ELDService bll = new ELDService();
                TDeviceParam p = new TDeviceParam();
                CLEDSender LEDSender = new CLEDSender();
                DBELD dbELD = new DBELD();
                var list = dbELD.GetJingTaiXinForSendByIP();
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];

                    //相机参数
                    MyTDeviceParam p1 = new MyTDeviceParam();
                    p1.devType = LEDSender.DEVICE_TYPE_UDP;
                    //获取相机基本信息
                    string ip = item.led_ip;
                    //  var camera = dbELD.GetEldModel(ip);
                    p1.dstAddr = 0;
                    p1.locPort = item.locPort;
                    p1.rmtPort = item.rmtPort;
                    p1.rmtHost = ip;


                    //发送文本参数
                    DisplayObj displayTextObj = new DisplayObj();
                    displayTextObj.ObjTypeIndex = 0;
                    TextPro textPro = new TextPro();
                    textPro.top = item.text_top;
                    textPro.width = item.text_width;
                    textPro.border = 0;
                    //  textPro.fontcolor = 0xff;
                    textPro.fontcolor = item.text_color;
                    textPro.fontname = "宋体";
                    textPro.fontsize = item.text_size;
                    textPro.fontstyle = LEDSender.WFS_NONE;
                    textPro.height = item.text_height;
                    textPro.inmethod = item.text_in;
                    textPro.inspeed = 1;
                    textPro.left = 0;
                    textPro.outmethod = item.text_out;
                    textPro.outspeed = 1;
                    textPro.alignment = 0;
                    textPro.stopmethod = item.text_stop;
                    textPro.stoptime = 1000;
                    textPro.transparent = LEDSender.V_TRUE;
                    textPro.wordwrap = item.wordwrap;
                    textPro.str = item.value;

                    displayTextObj.TextPro = textPro;

                    string str = bll.SendObjToELD(p1, displayTextObj, item.region);
                    //    Thread.Sleep(10);
                    //    //    if (str.Trim() == "数据传送完成")
                    //    //    {
                    //    //        int messageID = Convert.ToInt32(item.messageID);
                    //    //        bool flag = dbELD.Update_Led_send_prepare_Status(messageID, 1);
                    //    //        //   dbELD.UpdateELDEnable(ip, 0);

                    //    //    }
                    //    //    else
                    //    //    {
                    //    //        int messageID = Convert.ToInt32(item.messageID);
                    //    //        bool flag = dbELD.Update_Led_send_prepare_Status(messageID, 0);
                    //    //        //    dbELD.UpdateELDEnable(ip, 0);

                    //    //    }
                    //    WriteFile(@"d:\静态信息扫描ELD设备日志\", "静态信息扫描ELD" + ip, str);
                }
                //list = dbELD.GetJingTaiXinForSendByIP();
                Thread.Sleep(1000 * 1);
            }


        }
        public void WriteFile(string fpath, string filename, string str)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine(str);
            if (!Directory.Exists(fpath))
            {
                Directory.CreateDirectory(fpath);
            }
            string path = fpath + "\\" + filename + ".txt";

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            //sw.Write(DateTime.Now.ToString() + ":" + str + "\r\n执行结果：" + Text + "\r\n");
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
            fs.Close();
            System.IO.FileInfo fileInfo = null;
            fileInfo = new System.IO.FileInfo(path);
            /*单位转换成MB*/
            double fileSizeNum = System.Math.Ceiling(fileInfo.Length / (1024.0 * 1024.0));
            /*大于等于6Mb删除日志文件*/
            if (fileSizeNum >= 6)
            {
                File.Delete(path);
            }
        }
    }
}
