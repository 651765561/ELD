using ELDWebService_v2._0.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ELDWebService_v2._0
{
    /// <summary>
    /// WebServiceFile 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceFile : System.Web.Services.WebService
    {
        FileService fileService = new FileService();
        //[WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region 文件处理

      
        [WebMethod(Description = "获取生成路况图片所在路径")]
        public string GetSendPath()
        {
            string path=fileService.GetSendPath();
            return path;
        }
        /// <summary>  
        /// 上传文件到远程服务器  
        /// </summary>  
        /// <param name="fileBytes">文件流</param>  
        /// <param name="fileName">文件名</param>  
        /// <returns></returns>   
        [WebMethod(Description = "上传文件到远程服务器.fileBytes：文件流；fileName：文件名;")]
        public string UploadFile(byte[] fileBytes, string fileName)
        {
            string str = fileService.UploadFile(fileBytes, fileName);
            return str;

        }
        [WebMethod(Description = "mySql生成路况图片.r_id：编号；fileName：文件名;")]
        public string DrawPictureMysql(int r_id, string filename)
        {
           string str= fileService.DrawPictureMysql(r_id,filename);
            return str;
        }

        [WebMethod(Description = "mySql生成路况图片.r_id：编号；fileName：文件名;fontsize:字体大小;text:显示文字")]
        public string DrawPictureMysqlII(int r_id, string filename,int fontsize,string text)
        {
            string str = fileService.DrawPictureMysql(r_id, filename, fontsize, text);
            return str;
        }

        [WebMethod(Description = "向显示器发送图片.fileName：图片名称；MyTDeviceParam：MyTDeviceParam;。。。")]
        public string SendImgToELD(string fileName, MyTDeviceParam myTDeviceParam, ELDRegion[] arrEldRegion, LeafObj[] arrleaf)
        {
            string str = fileService.SendImgToELD(fileName, myTDeviceParam, arrEldRegion, arrleaf);
            return str;
        }

        /// <summary>
        /// Webservice中的下载文件处理函数
        /// </summary>

        /// <param name="strFilePath">文件路径</param>
        /// <returns>返回文件流</returns>
        //[WebMethod(Description = "下载服务器站点文件，传递文件相对路径{strFilePath：文件名称}")]
        public byte[] DownloadFile(string strFilePath)
        {
            FileStream fs = null;
            string currentUploadFolderPath = Server.MapPath(ConfigurationManager.AppSettings["UploadFileFolder"]);
            string currentUploadFilePath = currentUploadFolderPath + strFilePath;
            if (File.Exists(currentUploadFilePath))
            {
                try
                {
                    //打开现有文件以进行读取。
                    fs = File.OpenRead(currentUploadFilePath);
                    int b1;
                    System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
                    while ((b1 = fs.ReadByte()) != -1)
                    {
                        tempStream.WriteByte(((byte)b1));
                    }
                    return tempStream.ToArray();
                }
                catch (Exception ex)
                {
                    return new byte[0];
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                return new byte[0];
            }
        }
        #endregion
    }
}
