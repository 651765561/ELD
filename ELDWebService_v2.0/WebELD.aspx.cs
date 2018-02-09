using ELDWebService_v2._0.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELDWebService_v2._0
{
    public partial class WebELD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void but_fenpingAndWrite_Click(object sender, EventArgs e)
        {
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
            r1EldRegion.width = 125;
            r1EldRegion.left = 0;
            r1EldRegion.top = 0;
            r1EldRegion.ELD_IP = "192.168.0.101";
            r1EldRegion.road_id = 14;
            r1EldRegion.Region_Index = 0;

            ELDRegion r2EldRegion = new ELDRegion();
            r2EldRegion.border = 0;
            r2EldRegion.height = 32;
            r2EldRegion.width = 125;
            r2EldRegion.left = 125;
            r2EldRegion.top = 0;
            r2EldRegion.RegionType = 0;
            r2EldRegion.ELD_IP = "192.168.0.101";
            r2EldRegion.road_id = 14;
            r2EldRegion.RegionType = 0;

            ELDRegion[] arrEldRegion = { r1EldRegion, r2EldRegion };
            //text object
            /*Text 对象*/
            DisplayObj displayTextObj = new DisplayObj();

            displayTextObj.ObjTypeIndex = 0;
            TextPro textPro = new TextPro();
            textPro.top = 0;
            textPro.width = 125;
            textPro.border = 0;
            textPro.fontcolor = 0xff;
            textPro.fontname = "宋体";
            textPro.fontsize = 12;
            textPro.fontstyle = LEDSender.WFS_NONE;
            textPro.height = 32;
            textPro.inmethod = 1;
            textPro.inspeed = 1;
            textPro.left = 0;
            textPro.outmethod = 1;
            textPro.outspeed = 1;
            textPro.alignment = 0;
            textPro.stoptime = 1000;
            textPro.transparent = LEDSender.V_TRUE;
            textPro.wordwrap = 1;
            textPro.str = txt_region1.Text.Trim();

            displayTextObj.TextPro = textPro;


            DisplayObj displayTextObj1 = new DisplayObj();

            displayTextObj1.ObjTypeIndex = 0;
            TextPro textPro1 = new TextPro();
            textPro1.top = 0;
            textPro1.width = 125;
            textPro1.border = 0;
            textPro1.fontcolor = 0xff;
            textPro1.fontname = "宋体";
            textPro1.fontsize = 12;
            textPro1.fontstyle = LEDSender.WFS_NONE;
            textPro1.height = 32;
            textPro1.inmethod = 1;
            textPro1.inspeed = 1;
            textPro1.left = 0;
            textPro1.outmethod = 1;
            textPro1.outspeed = 1;
            textPro1.alignment = 0;
            textPro1.stoptime = 1000;
            textPro1.transparent = LEDSender.V_TRUE;
            textPro1.wordwrap = 1;
            textPro1.str = txt_region2.Text.Trim();

            displayTextObj1.TextPro = textPro1;

            DisplayObj[] arrdisplayObj = { displayTextObj, displayTextObj1 };

            string str = bll.FenPingAndSends(myTDeviceParam, arrEldRegion, arrdisplayObj);
            Response.Write(str);
        }

        protected void but2_fenping2_Click(object sender, EventArgs e)
        {
            CLEDSender LEDSender = new CLEDSender();
            ELDService bll = new ELDService();
            MyTDeviceParam myTDeviceParam = new MyTDeviceParam();
            myTDeviceParam.devType = LEDSender.DEVICE_TYPE_UDP;
            myTDeviceParam.locPort = 8877;
            myTDeviceParam.rmtHost = txt_ip.Text.Trim();
            myTDeviceParam.rmtPort = 6666;
            myTDeviceParam.dstAddr = 0;
            myTDeviceParam.devType = 1;
            myTDeviceParam.displayType = 0;
            myTDeviceParam.r_id = 151;
            myTDeviceParam.r_name = "生产部";



            ELDRegion r1EldRegion = new ELDRegion();
            r1EldRegion.border = 0;
            r1EldRegion.height = 64;
            r1EldRegion.width = 80;
            r1EldRegion.left = 0;
            r1EldRegion.top = 0;
            r1EldRegion.ELD_IP = txt_ip.Text.Trim();
            r1EldRegion.road_id = 151;
            r1EldRegion.Region_Index = 0;
            r1EldRegion.RegionType = 0;


            ELDRegion r2EldRegion = new ELDRegion();
            r2EldRegion.border = 0;
            r2EldRegion.height = 64;
            r2EldRegion.width = 80;
            r2EldRegion.left = 80;
            r2EldRegion.top = 0;
            r2EldRegion.RegionType = 0;
            r2EldRegion.ELD_IP = txt_ip.Text.Trim();
            r2EldRegion.road_id = 151;
            r2EldRegion.Region_Index = 1;

            ELDRegion[] arrEldRegion = { r1EldRegion, r2EldRegion };

            LeafObj leaf1 = new LeafObj();
            leaf1.Next_time = int.Parse(txt_next_time1.Text);
            leaf1.DisplayObjList = new List<DisplayObj>();
            LeafObj leaf2 = new LeafObj();
            leaf2.Next_time = int.Parse(txt_next_time2.Text); ;
            leaf2.DisplayObjList = new List<DisplayObj>();
            LeafObj[] arrleaf = { leaf1, leaf2 };
            //text object
            /*Text 对象*/
            DisplayObj displayTextObj1_1 = new DisplayObj();

            displayTextObj1_1.ObjTypeIndex = 0;
            TextPro textPro1_1 = new TextPro();
            textPro1_1.top = 0;
            textPro1_1.width = 80;
            textPro1_1.border = 0;
            textPro1_1.fontcolor = 255;
            textPro1_1.fontname = "宋体";
            textPro1_1.fontsize = 12;
            textPro1_1.fontstyle = LEDSender.WFS_NONE;
            textPro1_1.height = 64;
            textPro1_1.inmethod = 1;
            textPro1_1.inspeed = 1;
            textPro1_1.left = 0;
            textPro1_1.outmethod = 1;
            textPro1_1.outspeed = 1;
            textPro1_1.alignment = 0;
            textPro1_1.stoptime = 1000;
            //  textPro1_1.transparent = LEDSender.V_TRUE;
            textPro1_1.transparent = 0;
            textPro1_1.wordwrap = 1;
            textPro1_1.str = txt2_r1_1.Text.Trim();

            displayTextObj1_1.TextPro = textPro1_1;
            leaf1.DisplayObjList.Add(displayTextObj1_1);
            // leaf1displyList.Add(displayTextObj1_1);
            //
            DisplayObj displayTextObj1_2 = new DisplayObj();

            displayTextObj1_2.ObjTypeIndex = 0;
            TextPro textPro1_2 = new TextPro();
            textPro1_2.top = 0;
            textPro1_2.width = 80;
            textPro1_2.border = 0;
            textPro1_2.fontcolor = 255;
            textPro1_2.fontname = "宋体";
            textPro1_2.fontsize = 12;
            textPro1_2.fontstyle = LEDSender.WFS_NONE;
            textPro1_2.height = 64;
            textPro1_2.inmethod = 1;
            textPro1_2.inspeed = 1;
            textPro1_2.left = 0;
            textPro1_2.outmethod = 1;
            textPro1_2.outspeed = 1;
            textPro1_2.alignment = 0;
            textPro1_2.stoptime = 1000;
            //  textPro1_2.transparent = LEDSender.V_TRUE;
            textPro1_2.transparent = 0;
            textPro1_2.wordwrap = 1;
            textPro1_2.str = txt2_r1_2.Text.Trim();

            displayTextObj1_2.TextPro = textPro1_2;
            // leaf1displyList.Add(displayTextObj1_2);

            leaf1.DisplayObjList.Add(displayTextObj1_2);
            //

            //2区
            DisplayObj displayTextObj2_1 = new DisplayObj();

            displayTextObj2_1.ObjTypeIndex = 0;
            TextPro textPro2_1 = new TextPro();
            textPro2_1.top = 0;
            textPro2_1.width = 80;
            textPro2_1.border = 0;
            textPro2_1.fontcolor = 255;
            textPro2_1.fontname = "宋体";
            textPro2_1.fontsize = 12;
            textPro2_1.fontstyle = LEDSender.WFS_NONE;
            textPro2_1.height = 64;
            textPro2_1.inmethod = 1;
            textPro2_1.inspeed = 1;
            textPro2_1.left = 0;
            textPro2_1.outmethod = 1;
            textPro2_1.outspeed = 1;
            textPro2_1.alignment = 0;
            textPro2_1.stoptime = 1000;
            //  textPro2_1.transparent = LEDSender.V_TRUE;
            textPro2_1.transparent = 0;
             textPro2_1.wordwrap = 1;
            textPro2_1.str = txt2_r2_1.Text.Trim();

            displayTextObj2_1.TextPro = textPro2_1;
            leaf2.DisplayObjList.Add(displayTextObj2_1);

            DisplayObj displayTextObj2_2 = new DisplayObj();

            displayTextObj2_2.ObjTypeIndex = 0;
            TextPro textPro2_2 = new TextPro();
            textPro2_2.top = 0;
            textPro2_2.width = 80;
            textPro2_2.border = 0;
            // textPro2_2.fontcolor = 0xff;
            textPro2_2.fontcolor = 255;
            textPro2_2.fontname = "宋体";
            textPro2_2.fontsize = 12;
            textPro2_2.fontstyle = LEDSender.WFS_NONE;
            textPro2_2.height = 64;
            textPro2_2.inmethod = 1;
            textPro2_2.inspeed = 1;
            textPro2_2.left = 0;
            textPro2_2.outmethod = 1;
            textPro2_2.outspeed = 1;
            textPro2_2.alignment = 0;
            textPro2_2.stoptime = 1000;
             // textPro2_2.transparent = LEDSender.V_TRUE;
            textPro2_2.transparent = 0;
            textPro2_2.wordwrap = 1;
            textPro2_2.str = txt2_r2_2.Text.Trim();

            displayTextObj2_2.TextPro = textPro2_2;
            leaf2.DisplayObjList.Add(displayTextObj2_2);

            string str = bll.FenPingAndSendsDongTai(myTDeviceParam, arrEldRegion, arrleaf);
            Response.Write("result:" + str);

            // DisplayObj[] arrdisplayObj = { displayTextObj, displayTextObj1 };
        }

        protected void but_uploadFile_Click(object sender, EventArgs e)
        {
            UpLoadFile();
        }

        private void UpLoadFile()
        {
            string fileName = txt_imgName.Text.Trim();
            //  string fromImgPath = ConfigurationManager.AppSettings["fromImgPath"].ToString();
            //  string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();
            FileService fileService = new FileService();
            string path = @"D:\" + fileName;
            FileInfo imgFile = new FileInfo(path);
            string filename = Path.GetFileName(path);
            byte[] imgByte = new byte[imgFile.Length];//1.初始化用于存放图片的字节数组  
            System.IO.FileStream imgStream = imgFile.OpenRead();//2.初始化读取图片内容的文件流  
            imgStream.Read(imgByte, 0, Convert.ToInt32(imgFile.Length));//3.将图片内容通过文件流读取到字节数组  
            string str = fileService.UploadFile(imgByte, filename);//4.发送到服务器  
            Response.Write(str);
            // fileService.DrawII(127, "3.bmp");
            // 
        }
        protected void but_createLukuang_Click(object sender, EventArgs e)
        {
            string fileName = txt_imgName.Text.Trim();
            string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();
            
            FileService fileService = new FileService();
            fileService.DrawPicture(127, fileName);
            Response.Write("生成路况完毕");
        }

        protected void but_sendimg_Click(object sender, EventArgs e)
        {
            string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();
            string fileName = txt_imgName.Text.Trim();
            toImgPath = toImgPath + fileName;
            FileService fileService = new FileService();
            string str = fileService.SendImgToELD(fileName);
            Response.Write(str);
        }

        protected void but_sendimgII_Click(object sender, EventArgs e)
        {
            SendImg();
        }

        private void SendImg()
        {
            CLEDSender LEDSender = new CLEDSender();
            MyTDeviceParam myTDeviceParam = new MyTDeviceParam();
            myTDeviceParam.devType = LEDSender.DEVICE_TYPE_UDP;
            myTDeviceParam.locPort = 9092;
            myTDeviceParam.rmtHost = txt_ip.Text.Trim();
            myTDeviceParam.rmtPort = 6666;
            myTDeviceParam.dstAddr = 0;
            myTDeviceParam.devType = 1;
            //  myTDeviceParam.displayType = 2;
            myTDeviceParam.displayType = 0;
            myTDeviceParam.r_id = 14;
            myTDeviceParam.r_name = "yyy";

            ELDRegion r1EldRegion = new ELDRegion();
            r1EldRegion.border = 0;
            r1EldRegion.height = 64;
            r1EldRegion.width = 160;
            r1EldRegion.left = 0;
            r1EldRegion.top = 0;
            r1EldRegion.ELD_IP = txt_ip.Text.Trim();
            r1EldRegion.road_id = 153;
            r1EldRegion.Region_Index = 0;

            ELDRegion[] arrEldRegion = { r1EldRegion };

            LeafObj leaf1 = new LeafObj();
            leaf1.Next_time = 6;
            leaf1.DisplayObjList = new List<DisplayObj>();

            LeafObj[] arrleaf = { leaf1 };

            DisplayObj displayTextObj1_1 = new DisplayObj();
            displayTextObj1_1.ObjTypeIndex = 1;

            PicturePro picturePro = new PicturePro();
            picturePro.top = 0;
            picturePro.width = 160;
            picturePro.border = 0;
            picturePro.height = 64;
            picturePro.inmethod = 1;
            picturePro.inspeed = 1;
            picturePro.left = 0;
            picturePro.outmethod = 1;
            picturePro.outspeed = 1;
            picturePro.alignment = 0;
            picturePro.stoptime = 1000;
            picturePro.transparent = LEDSender.V_TRUE;
            // picturePro.filename = txt_imgName.Text.Trim();

            displayTextObj1_1.PicturePro = picturePro;
            leaf1.DisplayObjList.Add(displayTextObj1_1);

            displayTextObj1_1.PicturePro = picturePro;
            FileService fileService = new FileService();
            string str = "";
           
             str = fileService.SendImgToELD(txt_imgName.Text.Trim(), myTDeviceParam, arrEldRegion, arrleaf);
           
             
            Response.Write(str);
        }
        protected void but_uploadFileMySql_Click(object sender, EventArgs e)
        {
            UpLoadFile();
        }

        protected void but_createLukuangMySqlDB_Click(object sender, EventArgs e)
        {
            string fileName = txt_imgName.Text.Trim();
            string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();

            FileService fileService = new FileService();
            int fontsize = int.Parse(txt_fontsize.Text);
            fileService.DrawPictureMysql(127, fileName);
            Response.Write("生成路况完毕");
        }

        protected void but_sendimgMySqlDB_Click(object sender, EventArgs e)
        {
            SendImg();
        }

        protected void but_sendimgIIMySqlDB_Click(object sender, EventArgs e)
        {
            SendImg();
        }
    }
}