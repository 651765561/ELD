using Quartz;
using ServiceSendJingTaiMessage.BusinessLogic;
using ServiceSendJingTaiMessage.Dapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceSendJingTaiMessage
{
    [DisallowConcurrentExecution]//加上并发限制
    public class SendELDMessageJob : IJob
    {
        private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
        public static readonly LogFileFolder Log = new LogFileFolder("ScanJob");
        public void Execute(IJobExecutionContext context)
        {

            try
            {
                //进入写锁，其他所有访问操作的线程都被阻塞。即写独占锁。
                cacheLock.EnterWriteLock();
                // 获取传递过来的参数            
                JobDataMap data = context.JobDetail.JobDataMap;
                string led_ip = data.Get("led_ip").ToString();
                var elDitem = data.Get("elDitem") as dynamic;
                var _scheduler = data.Get("_scheduler") as IScheduler;
                ELDService bll = new ELDService();
                TDeviceParam p = new TDeviceParam();
                CLEDSender LEDSender = new CLEDSender();
                p.devType = LEDSender.DEVICE_TYPE_UDP;
                p.locPort = ushort.Parse(elDitem.locport.ToString());
                p.rmtHost = led_ip;
                p.rmtPort = ushort.Parse(9999.ToString());
                p.dstAddr = 0;

                DBELD dbELD = new DBELD();
                Thread.SpinWait(1000);
                var messageList = dbELD.GetJingTaiXinForSendByIP(led_ip);
                if (messageList.Count <= 0)
                {
                    return;
                }
                //  string result= bll.AdjustTime(p);
                // Thread.Sleep(1000);
                string result = "校正显示屏时间完成";
                if (result.Trim() == "校正显示屏时间完成")
                {
                    //   dbELD.UpdateELDEnable(led_ip, 1);

                    //相机参数
                    MyTDeviceParam p1 = new MyTDeviceParam();
                    p1.devType = LEDSender.DEVICE_TYPE_UDP;
                    //获取相机基本信息
                    string ip = elDitem.led_ip;
                    var camera = dbELD.GetEldModel(ip);
                    p1.dstAddr = 0;
                    p1.locPort = camera.locport;
                    p1.rmtPort = camera.rmtport;
                    p1.rmtHost = led_ip;
                    for (int i = 0; i < messageList.Count; i++)
                    {
                        var item = messageList[i];
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
                        Thread.Sleep(1000);
                        if (str.Trim() == "数据传送完成")
                        {
                            int messageID = Convert.ToInt32(item.messageID);
                            WriteFile(@"d:\静态信息扫描ELD设备日志\", "静态信息扫描ELD" + led_ip, str);
                            //  bool flag = dbELD.Update_Led_send_prepare_Status(messageID, 1);
                        }
                        else
                        {
                            WriteFile(@"d:\静态信息扫描ELD设备日志\", "静态信息扫描ELD" + led_ip, str);
                            break;
                            int messageID = Convert.ToInt32(item.messageID);
                            // bool flag = dbELD.Update_Led_send_prepare_Status(messageID, 0);
                        }
                       
                    }


                }
                else
                {
                    dbELD.UpdateELDEnable(led_ip, 0);
                    dbELD.Update_Led_send_prepare_Status(led_ip, 0);
                    WriteFile(@"d:\静态信息扫描ELD设备日志\", "静态信息扫描ELD" + led_ip, "没数据");
                }
            }
            catch (Exception ex)
            {


            }

            finally { cacheLock.ExitWriteLock(); }

      
            //    WriteFile("ELD" + led_ip, led_ip);

        }
        public void WriteFile(string fpath, string filename, string str)
        {
            Console.WriteLine(DateTime.Now.ToString() + filename+ str);
            if (!Directory.Exists(fpath))
            {
                Directory.CreateDirectory(fpath);
            }
            string path = fpath + "\\" + filename + ".txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            //sw.Write(DateTime.Now.ToString() + ":" + str + "\r\n执行结果：" + Text + "\r\n");
            sw.Write(DateTime.Now.ToString() + ":" + str + "\r\n执行结果：");
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
