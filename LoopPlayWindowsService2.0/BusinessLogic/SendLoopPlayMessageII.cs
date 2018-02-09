using LoopPlayWindowsService2._0.Entity.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoopPlayWindowsService2._0.BusinessLogic
{
    public class SendLoopPlayMessageII
    {
        public void Play()
        {
            BLLMySql bll = new BLLMySql();
            int sendtimes = 0;
            Console.WriteLine("Run...");
            while (true)
            {
                var leds = bll.GetLeds();
                var list = bll.SearchLoopPlayListII();
                /*
                   var ls = persons1.GroupBy(a => a.Name).Select(g => (new { name = g.Key, count = g.Count(),
                   ageC = g.Sum(item => item.Age), moneyC = g.Sum(item => item.Money) }));
                 */
                var zhulist = list.ToList().GroupBy(p => p.led_ip).Select(g => (new { num = g.Count(), ip = g.Max(item => item.led_ip) })).ToList(); ;
                var maxNum = zhulist.Max(p => p.num);


                for (int j = 0; j < maxNum; j++)
                {

                    //  Console.WriteLine((sendtimes +1)+ "***********************************************************");
                    for (int i = 0; i < leds.Count; i++)
                    {
                        var item = leds[i];
                        var ip = item.led_ip;
                        var ipMessageList = list.Where(p => p.led_ip == ip).ToList();

                        if (ipMessageList == null || ipMessageList.Count <= 0)
                        {
                            continue;
                        }

                        var currentmax = ipMessageList.Count;
                        var playitem = ipMessageList[j];


                        var ip1 = playitem.led_ip;
                        var val1 = playitem.value;
                        int messageId = playitem.messageId;
                        var dd = playitem.PlayDateTime;
                        if (DateTime.Now >= dd)
                        {
                            SendInfor(playitem);
                            Console.WriteLine("Play:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "   IP  " + ip1 + "   Value " + val1);
                            UpdateSendTime(ipMessageList, j);
                           
                        }
                        //play




                        Thread.Sleep(10);

                    }
                    sendtimes++;
                    // Console.WriteLine("***********************************************************");
                    //  Thread.Sleep(1000 * 5);
                }
            }


          
            Console.Read();
        }

        private void SendInfor(Entity.LoopPlay item)
        {
            ELDService bll = new ELDService();
            CLEDSender LEDSender = new CLEDSender();
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
            Console.WriteLine(str);
        }

        private void UpdateSendTime(IList<Entity.LoopPlay> list, int index)
        {
            BLLMySql bll = new BLLMySql();
            DateTime dt = DateTime.Now;
            /*最后一条元素*/
            if (list.Count == index + 1)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var playitem = list[i];
                    int messageId = playitem.messageId;
                    int next_time = playitem.next_time;

                    dt = dt.AddMinutes(next_time);
                    bll.Update_led_send_prepare(messageId, 1, dt);
                }
            }
            else
            {
                for (int i = 0; i <= index; i++)
                {
                    int total = list.Count;
                    int num = total - (index+1);
                                             
                    var playitem = list[index];
                    int messageId = playitem.messageId;
                    int next_time = playitem.next_time * (num+ (index + 1));

                    dt = dt.AddMinutes(next_time);
                    bll.Update_led_send_prepare(messageId, 1, dt);

                }

            }


        }
        private void SendXInxi()
        {

        }
    }
}
