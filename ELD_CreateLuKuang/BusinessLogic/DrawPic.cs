using ELD_CreateLuKuang.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ELD_CreateLuKuang.BusinessLogic
{
    public class DrawPic
    {

        public DrawPic() {

        }
        public void CreateRoadPic()
        {
            DA dA = new DA();
            var roadList = dA.GetRoadList();
            for (int i = 0; i < roadList.Count; i++)
            { var roadItem = roadList[i];
                int r_id = roadItem.r_id;
                var roadDetailList = dA.GetRoadDetailList(r_id);
                if (roadDetailList != null && roadDetailList.Count > 0)
                {
                    string fromImgPath = ConfigurationManager.AppSettings["fromImgPath"].ToString();
                    string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();
                    if (!System.IO.Directory.Exists(toImgPath))
                    {
                        Directory.CreateDirectory(toImgPath);
                    }
                    string filename = roadItem.picPath;
                    fromImgPath = fromImgPath + filename;
                    toImgPath = toImgPath + filename;

                    DrawPicII(r_id, filename);


                }
            }
           
        }

        private void DrawPicII(int r_id,string filename) {
            DA dA = new DA();
            string fromImgPath = ConfigurationManager.AppSettings["fromImgPath"].ToString();
            string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();
            fromImgPath = fromImgPath + filename;
            toImgPath = toImgPath + filename;
            var roadDetailList = dA.GetRoadDetailList(r_id);
            if (roadDetailList == null || roadDetailList.Count <= 0)
            {
                return;
            }
            System.Drawing.Image bmp = System.Drawing.Bitmap.FromFile(fromImgPath);

            Color c = Color.FromArgb(255, 000, 255, 000);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
            for (int m = 0; m < roadDetailList.Count; m++)
            {
                var model = roadDetailList[m];
                if (model.status == 0)
                {
                    c = Color.FromArgb(255, 000, 255, 000);
                }
                else if (model.status == 1)
                {
                    c = Color.FromArgb(255, 255, 000);
                }
                else
                {
                    c = Color.FromArgb(255, 000, 000);
                }
                Pen pen1 = new Pen(c, 40);

                g.DrawLine(pen1, new PointF(int.Parse(model.x1), int.Parse(model.y1)), new PointF(int.Parse(model.x2), int.Parse(model.y2)));
                pen1.Dispose();
            }
            //
            Font myFont = new Font("微软雅黑", 21, FontStyle.Bold);
            //文字竖向展示

            //var stringFormatFlags = StringFormatFlags.DirectionVertical;
            //g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + roadModel.r_name, myFont, new SolidBrush(c), 6, 6, new StringFormat(stringFormatFlags));
            g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "DDD", myFont, new SolidBrush(c), 2, 0);
            g.Dispose();
            myFont.Dispose();

            //  Thread.CurrentThread.Join(1000 * 2);//阻止设定时间
            bmp.Save(toImgPath, ImageFormat.Bmp);
           
            bmp.Dispose();
            GC.Collect();
            SendImgToELD(toImgPath);
        }

        private void SendImgToELD(string imgpath) {
            ELDService eLDService = new ELDService();
            CLEDSender LEDSender = new CLEDSender();
            ELDService bll = new ELDService();
            MyTDeviceParam myTDeviceParam = new MyTDeviceParam();
            myTDeviceParam.devType = LEDSender.DEVICE_TYPE_UDP;
            myTDeviceParam.locPort = 9092;
            myTDeviceParam.rmtHost = "192.168.0.101";
            myTDeviceParam.rmtPort = 6666;
            myTDeviceParam.dstAddr = 0;
            myTDeviceParam.devType = 1;
            myTDeviceParam.displayType = 2;
            myTDeviceParam.r_id = 14;
            myTDeviceParam.r_name = "yyy";

            ELDRegion r1EldRegion = new ELDRegion();
            r1EldRegion.border = 0;
            r1EldRegion.height = 32;
            r1EldRegion.width = 256;
            r1EldRegion.left = 0;
            r1EldRegion.top = 0;
            r1EldRegion.ELD_IP = "192.168.0.101";
            r1EldRegion.road_id = 14;
            r1EldRegion.Region_Index = 0;

            ELDRegion[] arrEldRegion = { r1EldRegion };

            LeafObj leaf1 = new LeafObj();
            leaf1.Next_time = 10;
            leaf1.DisplayObjList = new List<DisplayObj>();

            LeafObj[] arrleaf = { leaf1 };

            DisplayObj displayTextObj1_1 = new DisplayObj();
            displayTextObj1_1.ObjTypeIndex = 1;

            PicturePro picturePro = new PicturePro();
            picturePro.top = 0;
            picturePro.width = 256;
            picturePro.border = 0;
            picturePro.height = 32;
            picturePro.inmethod = 1;
            picturePro.inspeed = 1;
            picturePro.left = 0;
            picturePro.outmethod = 1;
            picturePro.outspeed = 1;
            picturePro.alignment = 0;
            picturePro.stoptime = 1000;
            picturePro.transparent = LEDSender.V_TRUE;
            picturePro.filename = imgpath;

            displayTextObj1_1.PicturePro = picturePro;
            leaf1.DisplayObjList.Add(displayTextObj1_1);

            displayTextObj1_1.PicturePro = picturePro;

         string str=   eLDService.FenPingAndSendsDongTai(myTDeviceParam, arrEldRegion, arrleaf, false);
            Console.WriteLine(str);
        }
    }
}
