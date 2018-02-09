using LoopPlayWindowsService2._0.Entity.Partial;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace LoopPlayWindowsService2._0.BusinessLogic
{
    public class SendLoopPlayMessage
    {
        System.Timers.Timer t;

        bool flag = true;
        public SendLoopPlayMessage() { }
        public void Method1()
        {
            while (true)
            {
                //  Console.WriteLine(DateTime.Now.ToString() + "_" + Thread.CurrentThread.ManagedThreadId.ToString());
                if (flag)
                {
                    SendLoopPlayMessages();
                }

                Thread.CurrentThread.Join(1000 * 60 * 1);//阻止设定时间
            }
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

        public void SendLoopPlayMessages()
        {

            BLLMySql dbELD = new BLLMySql();
            var list = dbELD.SearchLoopPlayListII();
            int nexttime = dbELD.GetNextTime();
            CLEDSender LEDSender = new CLEDSender();
            ELDService bll = new ELDService();
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
                p1.locPort = item.locport;
                p1.rmtPort = item.rmtport;
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
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine(ip+str);
              //  WriteFile(@"d:\轮流播放\", "轮流播放" + ip, str);
                Thread.Sleep(10);
            }
            //间隔时间
            Thread.Sleep(1000*60* nexttime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fpath"></param>
        /// <param name="filename"></param>
        /// <param name="str"></param>
        public void WriteFile(string fpath, string filename, string str)
        {
            //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //Console.WriteLine(filename + str);
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
