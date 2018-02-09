using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mail;

namespace LuKuangService.Business
{
    public class BSHelper
    {
        #region 拼接json
        /// <summary>
        /// 拼接json
        /// </summary>
        /// <param name="code">返回码</param>
        /// <param name="message">返回信息</param>
        /// <param name="data">数据对象</param>
        /// <returns></returns>
        public static void ReturnJson(int code, string message, HttpContext content, string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                data = "{}";
            }
            content.Response.Write("{\"code\":\"" + code + "\",\"message\":\"" + message + "\",\"data\":" + data + "}");
            content.Response.End();
        }
        /// <summary>
        /// 拼接json
        /// </summary>
        /// <param name="code">返回码</param>
        /// <param name="message">返回信息</param>
        /// <param name="data">数据对象</param>
        /// <param name="count">分页总数</param>
        /// <returns></returns>
        public static void ReturnJson(int code, string message, HttpContext content, string data, int count)
        {
            if (String.IsNullOrEmpty(data))
            {
                data = "{}";
            }
            content.Response.Write("{\"code\":\"" + code + "\",\"message\":\"" + message + "\",\"data\":" + data + ",\"count\":\"" + count + "\"}");
            content.Response.End();
        }
        #endregion

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="formemail">发送人邮箱</param>
        /// <param name="username">发送人用户名</param>
        /// <param name="userpwd">发送人密码</param>
        /// <param name="smtpserver">发送人邮箱的smtp服务器</param>
        /// <param name="toemail">接受人邮箱</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <returns>是否成功</returns>
        public static bool SendEmail(string formemail, string username, string userpwd, string smtpserver, string toemail, string title, string content)
        {
            try
            {
                MailMessage objMailMessage;
                objMailMessage = new MailMessage();
                objMailMessage.From = formemail;
                objMailMessage.To = toemail;
                objMailMessage.Subject = title;
                objMailMessage.Body = content;
                objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", username);
                objMailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", userpwd);
                SmtpMail.SmtpServer = smtpserver;
                SmtpMail.Send(objMailMessage);
                return true;
            }
            catch
            {

                return false;
            }

        }
        #endregion

        #region 文件存储
        /// <summary>
        /// 文件存储
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string SaveFile(HttpPostedFile file, SavePath path)
        {
            if (file.ContentLength == 0) { return ""; }
            string savePath = CreateSavePath(file.FileName, path);
            file.SaveAs(AppDomain.CurrentDomain.BaseDirectory + savePath);
            return savePath;
        }
        /// <summary>
        /// 文件转存
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="path">转存位置</param>
        /// <returns>正式路径</returns>
        public static string TransferFile(string filePath, SavePath path)
        {
            try
            {
                FileInfo file = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + filePath);
                if (file == null)
                {
                    return "";
                }
                string officialPath = CreateSavePath(filePath, path);
                file.CopyTo(AppDomain.CurrentDomain.BaseDirectory + officialPath, true);
                return officialPath;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 获取文件保存路径
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string CreateSavePath(string filePath, SavePath path)
        {
            string postfix = filePath.Substring(filePath.LastIndexOf("."));
            string pPath = "/upload/" + pathStrs[Convert.ToInt32(path)];
            CreateDirectoryIfNotExists(AppDomain.CurrentDomain.BaseDirectory + pPath);
            string month = DateTime.Now.ToString("yyyyMM");
            pPath += "/" + month;
            CreateDirectoryIfNotExists(AppDomain.CurrentDomain.BaseDirectory + pPath);
            string fileName = pPath + "/" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + postfix;
            return fileName;
        }
        protected static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public enum SavePath
        {
            项目产品附件 = 0,
            项目执行Img = 1,
            突发事件图片 = 2,
            场地地图上传图片 = 3,
            临时文件 = 4,
            附件存储 = 5,
            公告编辑类型附件 = 6
        }
        protected static string[] pathStrs = { "projectproductattch", "projectactionimg", "suddenevent", "sitemappic", "tempupload", "attachment", "noticeeditattach" };
        #endregion

        /// <summary>
        /// 拼接分页HTML
        /// </summary>
        /// <param name="CurrentPageIndex">索引页</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="RecordCount">总条数</param>
        /// <param name="FunName">onClick名</param>
        /// <returns></returns>
        public static string PageView(int CurrentPageIndex, int PageSize, int RecordCount, string FunName)
        {
            string page = string.Empty;
            StringBuilder sb = new StringBuilder();

            int PageShow = 2;
            int tempPage = RecordCount / PageSize;
            int modePage = RecordCount % PageSize;
            int totalPage = tempPage + (modePage > 0 ? 1 : 0);
            int startNumber = 0;
            int lastNumber = 0;

            if (CurrentPageIndex == 1)
            {
                sb.Append("<a title=\"上一页\" disabled href=\"javascript:;\">上一页</a>");
            }
            else
            {
                sb.AppendFormat("<a title=\"上一页\" href=\"javascript:;\" onclick=\"{0}({1});return false;\">上一页</a>", FunName, CurrentPageIndex - 1);
            }
            // sb.Append("<span>");
            if (CurrentPageIndex <= (PageShow / 2 + 1) || totalPage <= PageShow)
                startNumber = 1;
            else
                startNumber = CurrentPageIndex - PageShow / 2;

            if (CurrentPageIndex >= (totalPage - PageShow / 2) || totalPage <= PageShow)
                lastNumber = totalPage;
            else
                lastNumber = CurrentPageIndex + PageShow / 2;

            if (startNumber != 1)
            {
                sb.AppendFormat("<a title=\"Go to page 1\" href=\"javascript:;\" onclick=\"{0}(1);return false;\">1</a>", FunName);
                if (startNumber != 2) sb.Append("<a href=\"javascript:;\">...</a>");
            }

            for (int p = startNumber; p <= lastNumber; p++)
            {
                if (CurrentPageIndex == p)
                {
                    sb.Append("<span class=\"tP\">" + p.ToString() + "</span>");
                }
                else
                {
                    sb.AppendFormat("<a title=\"Go to page " + p.ToString() + "\" href=\"javascript:;\" onclick=\"{0}(" + p.ToString() + ");return false;\">" + p.ToString() + "</a>", FunName);
                }
            }

            if (lastNumber != totalPage)
            {
                if (lastNumber != totalPage - 1) sb.Append("<a hred=\"javascript:;\">...</a>");
                sb.AppendFormat("<a title=\"Go to page " + totalPage.ToString() + "\" href=\"javascript:;\" onclick=\"{0}(" + totalPage.ToString() + ");return false;\">" + totalPage.ToString() + "</a>", FunName);
            }

            //sb.Append("</span>");

            if (CurrentPageIndex == totalPage)
                sb.Append("<a disabled href=\"javascript:;\">下一页</a>");
            else
                sb.AppendFormat("<a title=\"下一页\" href=\"javascript:;\" onclick=\"{0}(" + (CurrentPageIndex + 1) + ");return false;\">下一页</a>", FunName);

            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp; <label style=\"color:Orange; border:0px;cursor:none;\">" + RecordCount + "</label>条记录");
            sb.Append("&nbsp;共 <label style=\"color:Orange; border:0px;cursor:none;\">" + totalPage + "</label>页");

            return sb.ToString();
        }
    }
}
