using ELDWebService_v2._0.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuKuangService
{
    class Program
    {
         
      public  static void Main(string[] args)
        {
           
            

            try
            {
                fileService.WebServiceFileSoapClient fileservice = new fileService.WebServiceFileSoapClient();
                /*上传图片文件*/
                Console.WriteLine("输入图片名称");
                string fileName = Console.ReadLine();
                Console.WriteLine("你输入的信息是：");
                Console.WriteLine(fileName);
                Console.Read();

                string path = @"D:\" + fileName;
                FileInfo imgFile = new FileInfo(path);
                string filename = Path.GetFileName(path);
                byte[] imgByte = new byte[imgFile.Length];//1.初始化用于存放图片的字节数组  
                System.IO.FileStream imgStream = imgFile.OpenRead();//2.初始化读取图片内容的文件流  
                imgStream.Read(imgByte, 0, Convert.ToInt32(imgFile.Length));//3.将图片内容通过文件流读取到字节数组  
                string str = fileservice.UploadFile(imgByte, filename);//4.发送到服务器  
                Console.WriteLine(str);
                Console.Read();
                /*生成路况*/
                fileservice.DrawPicture(127, fileName);
                Console.WriteLine("生成路况完毕");
                Console.WriteLine("输入任何信息发布信息到显示屏");
                Console.Read();
                /*向显示器发送图片*/
                CLEDSender LEDSender = new CLEDSender();

                fileService.MyTDeviceParam myTDeviceParam = new fileService.MyTDeviceParam();
                myTDeviceParam.devType = LEDSender.DEVICE_TYPE_UDP;
                myTDeviceParam.locPort = 9092;
                myTDeviceParam.rmtHost = "192.168.0.102";
                myTDeviceParam.rmtPort = 6666;
                myTDeviceParam.dstAddr = 0;
                myTDeviceParam.devType = 1;
                myTDeviceParam.displayType = 2;
                myTDeviceParam.r_id = 14;
                myTDeviceParam.r_name = "yyy";

                fileService.ELDRegion r1EldRegion = new fileService.ELDRegion();
                r1EldRegion.border = 0;
                r1EldRegion.height = 64;
                r1EldRegion.width = 160;
                r1EldRegion.left = 0;
                r1EldRegion.top = 0;
                r1EldRegion.ELD_IP = "192.168.0.102";
                r1EldRegion.road_id = 14;
                r1EldRegion.Region_Index = 0;

                fileService.ELDRegion[] arrEldRegion = { r1EldRegion };

                fileService.LeafObj leaf1 = new fileService.LeafObj();
                leaf1.Next_time = 10;
          
                leaf1.DisplayObjList = new List<fileService.DisplayObj>().ToArray();

                fileService.LeafObj[] arrleaf = { leaf1 };

                fileService.DisplayObj displayTextObj1_1 = new fileService.DisplayObj();
                displayTextObj1_1.ObjTypeIndex = 1;

                fileService.PicturePro picturePro = new fileService.PicturePro();
                picturePro.top = 0;
                picturePro.width = 256;
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
                leaf1.DisplayObjList= new fileService.DisplayObj[]{ displayTextObj1_1} ;

                displayTextObj1_1.PicturePro = picturePro;
         
                string str1 = fileservice.SendImgToELD(filename, myTDeviceParam, arrEldRegion, arrleaf);
                Console.WriteLine(str1);
                Console.Read();

            }
            catch (Exception ex)
            {
                Console.Write(ex);

            }

        }

    }
}
