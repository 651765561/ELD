using ELDWebService_v2._0.BusinessLogic;
using ELDWebService_v2._0.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace ELDWebService_v2._0
{
    public class FileService
    {
        /// <summary>  
        /// 上传文件到远程服务器  
        /// </summary>  
        /// <param name="fileBytes">文件流</param>  
        /// <param name="fileName">文件名</param>  
        /// <returns></returns>   

        public string UploadFileII(byte[] fileBytes, string fileName, string path)
        {
            try
            {
                if (System.IO.Directory.Exists(path) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(path);
                }
                MemoryStream memoryStream = new MemoryStream(fileBytes); //1.定义并实例化一个内存流，以存放提交上来的字节数组。  
                FileStream fileUpload = new FileStream(path + "\\" + fileName, FileMode.Create); ///2.定义实际文件对象，保存上载的文件。  
                memoryStream.WriteTo(fileUpload); ///3.把内存流里的数据写入物理文件  
                memoryStream.Close();
                fileUpload.Close();
                fileUpload = null;
                memoryStream = null;
                return "文件已经上传成功";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UploadFile(byte[] fileBytes, string fileName)
        {
            try
            {
                string path = ConfigurationManager.AppSettings["fromImgPath"].ToString();
                if (System.IO.Directory.Exists(path) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(path);
                }
                MemoryStream memoryStream = new MemoryStream(fileBytes); //1.定义并实例化一个内存流，以存放提交上来的字节数组。  
                FileStream fileUpload = new FileStream(path + "\\" + fileName, FileMode.Create); ///2.定义实际文件对象，保存上载的文件。  
                memoryStream.WriteTo(fileUpload); ///3.把内存流里的数据写入物理文件  
                memoryStream.Close();
                fileUpload.Close();
                fileUpload = null;
                memoryStream = null;
                return "文件已经上传成功";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 判断图片是否索引像素格式,是否是引发异常的像素格式
        /// </summary>
        /// <param name="imagePixelFormat">图片的像素格式</param>
        /// <returns></returns>
        private bool IsIndexedPixelFormat(System.Drawing.Imaging.PixelFormat imagePixelFormat)
        {
            PixelFormat[] pixelFormatArray = {
                                            PixelFormat.Format1bppIndexed
                                            ,PixelFormat.Format4bppIndexed
                                            ,PixelFormat.Format8bppIndexed
                                            ,PixelFormat.Undefined
                                            ,PixelFormat.DontCare
                                            ,PixelFormat.Format16bppArgb1555
                                            ,PixelFormat.Format16bppGrayScale
                                        };
            foreach (PixelFormat pf in pixelFormatArray)
            {
                if (imagePixelFormat == pf)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取生成路况图片所在路径
        /// </summary>
        /// <returns></returns>
        public string GetSendPath()
        {
            string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();
            return toImgPath;
        }
        public string DrawPicture(int r_id, string filename)
        {
            string fromImgPath = ConfigurationManager.AppSettings["fromImgPath"].ToString();
            string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();

            if (System.IO.Directory.Exists(toImgPath) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(toImgPath);
            }
            fromImgPath = fromImgPath + filename;
            toImgPath = toImgPath + filename;

            using (System.Drawing.Image img = System.Drawing.Image.FromFile(fromImgPath))
            {
                TongYongDraw(127, img, toImgPath, 10);

            }
            return "图片生成完毕";
        }

        public string DrawPictureMysql(int r_id, string filename)
        {
            string fromImgPath = ConfigurationManager.AppSettings["fromImgPath"].ToString();
            string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();

            if (System.IO.Directory.Exists(toImgPath) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(toImgPath);
            }
            fromImgPath = fromImgPath + filename;
            toImgPath = toImgPath + filename;

            using (System.Drawing.Image img = System.Drawing.Image.FromFile(fromImgPath))
            {
                TongYongDrawMysql(r_id, img, toImgPath);

            }
            return "图片生成完毕";
        }

        public string DrawPictureMysql(int r_id, string filename, int fontsize, string text)
        {
            string fromImgPath = ConfigurationManager.AppSettings["fromImgPath"].ToString();
            string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();

            if (System.IO.Directory.Exists(toImgPath) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(toImgPath);
            }
            fromImgPath = fromImgPath + filename;
            toImgPath = toImgPath + filename;

            using (System.Drawing.Image img = System.Drawing.Image.FromFile(fromImgPath))
            {
                TongYongDrawMysql(127, img, toImgPath, fontsize, text);

            }
            return "图片生成完毕";
        }
        public void TongYongDrawMysql(int r_id, System.Drawing.Image img, string toImgPath, int fontsize, string text)
        {
            DAMySql dA = new DAMySql();
            var roadDetailList = dA.GetRoadDetailList(r_id);
            if (roadDetailList == null || roadDetailList.Count <= 0)
            {
                return;
            }
            Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
            Color c = Color.FromArgb(255, 000, 255, 000);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
            {

                g.DrawImage(img, 0, 0);


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
                    Pen pen1 = new Pen(c, model.roadwidth);

                    g.DrawLine(pen1, new PointF(int.Parse(model.x1), int.Parse(model.y1)), new PointF(int.Parse(model.x2), int.Parse(model.y2)));
                    pen1.Dispose();
                }
                //文字竖向展示

                //var stringFormatFlags = StringFormatFlags.DirectionVertical;
                //g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + roadModel.r_name, myFont, new SolidBrush(c), 6, 6, new StringFormat(stringFormatFlags));
                if (text.Trim() != "")
                {
                    Font myFont = new Font("字体", fontsize, FontStyle.Bold);
                    g.DrawString(text, myFont, new SolidBrush(c), 2, 0);
                }


                g.Dispose();
                bmp.Save(toImgPath, ImageFormat.Bmp);

                bmp.Dispose();
            }
        }
        public void TongYongDrawMysql(int r_id, System.Drawing.Image img, string toImgPath)
        {
            DAMySql dA = new DAMySql();
            var roadDetailList = dA.GetRoadDetailList(r_id);
            if (roadDetailList == null || roadDetailList.Count <= 0)
            {
                return;
            }
            img.Save("d:/1222.bmp");
            //Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
           // Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
            Color c = Color.FromArgb(255, 000, 255, 000);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img))
            {

                g.DrawImage(img, 0, 0);
                //Font myFont = new Font("字体", fontsize, FontStyle.Bold);

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
                    Pen pen1 = new Pen(c, model.roadwidth);

                    g.DrawLine(pen1, new PointF(int.Parse(model.x1), int.Parse(model.y1)), new PointF(int.Parse(model.x2), int.Parse(model.y2)));
                    pen1.Dispose();
                }
                //文字竖向展示

                //var stringFormatFlags = StringFormatFlags.DirectionVertical;
                //g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + roadModel.r_name, myFont, new SolidBrush(c), 6, 6, new StringFormat(stringFormatFlags));
                //g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") , myFont, new SolidBrush(c), 2, 0);
                g.Dispose();
                img.Save(toImgPath, ImageFormat.Bmp);

                img.Dispose();
            }
        }
        public void TongYongDraw(int r_id, System.Drawing.Image img, string toImgPath, int fontsize)
        {
            DA dA = new DA();
            var roadDetailList = dA.GetRoadDetailList(r_id);
            if (roadDetailList == null || roadDetailList.Count <= 0)
            {
                return;
            }
          //  Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
            Color c = Color.FromArgb(255, 000, 255, 000);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img))
            {

                g.DrawImage(img, 0, 0);
                Font myFont = new Font("字体", fontsize, FontStyle.Bold);

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
                    Pen pen1 = new Pen(c, model.roadwidth);

                    g.DrawLine(pen1, new PointF(int.Parse(model.x1), int.Parse(model.y1)), new PointF(int.Parse(model.x2), int.Parse(model.y2)));
                    pen1.Dispose();
                }
                //文字竖向展示

                //var stringFormatFlags = StringFormatFlags.DirectionVertical;
                //g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + roadModel.r_name, myFont, new SolidBrush(c), 6, 6, new StringFormat(stringFormatFlags));
                g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "DDD", myFont, new SolidBrush(c), 2, 0);
                g.Dispose();
                img.Save(toImgPath, ImageFormat.Bmp);

                img.Dispose();
            }
        }


        public string SendImgToELD(string fileName, MyTDeviceParam myTDeviceParam, ELDRegion[] arrEldRegion, LeafObj[] arrleaf)
        {

            string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();
            string imgpath = toImgPath + fileName;
            ELDService eLDService = new ELDService();
            CLEDSender LEDSender = new CLEDSender();
            ELDService bll = new ELDService();
            arrleaf[0].DisplayObjList[0].PicturePro.filename = imgpath;
            string str = eLDService.FenPingAndSendsDongTai(myTDeviceParam, arrEldRegion, arrleaf, false);
            Console.WriteLine(str);
            return str;
        }


        public string SendImgToELD(string fileName)
        {
            string toImgPath = ConfigurationManager.AppSettings["toImgPath"].ToString();
            string imgpath = toImgPath + fileName;
            ELDService eLDService = new ELDService();
            CLEDSender LEDSender = new CLEDSender();
            ELDService bll = new ELDService();
            MyTDeviceParam myTDeviceParam = new MyTDeviceParam();
            myTDeviceParam.devType = LEDSender.DEVICE_TYPE_UDP;
            myTDeviceParam.locPort = 9092;
            myTDeviceParam.rmtHost = "192.168.0.102";
            myTDeviceParam.rmtPort = 6666;
            myTDeviceParam.dstAddr = 0;
            myTDeviceParam.devType = 1;
            myTDeviceParam.displayType = 2;
            myTDeviceParam.r_id = 14;
            myTDeviceParam.r_name = "yyy";

            ELDRegion r1EldRegion = new ELDRegion();
            r1EldRegion.border = 0;
            r1EldRegion.height = 64;
            r1EldRegion.width = 160;
            r1EldRegion.left = 0;
            r1EldRegion.top = 0;
            r1EldRegion.ELD_IP = "192.168.0.102";
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
            picturePro.height = 64;
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

            string str = eLDService.FenPingAndSendsDongTai(myTDeviceParam, arrEldRegion, arrleaf, false);
            Console.WriteLine(str);
            return str;
        }



    }
}