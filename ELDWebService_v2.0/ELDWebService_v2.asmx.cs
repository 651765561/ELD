using ELDWebService_v2._0.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ELDWebService_v2._0
{
    /// <summary>
    /// ELDWebService_v2 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ELDWebService_v2 : System.Web.Services.WebService
    {
        ELDService eLDService = new ELDService();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="myTDeviceParam"></param>
        /// <param name="arrEldRegion"></param>
        /// <param name="arrleafObj"></param>
        /// <param name="IsSave"></param>
        /// <returns></returns>
        [WebMethod(Description = "分区且实现内容填充（整屏写入）支持轮流播放【参数IsSave:是否保留分区和发布的信息】")]
        public string FenPingAndSendsDongTaiII(MyTDeviceParam myTDeviceParam, ELDRegion[] arrEldRegion, LeafObj[] arrleafObj, bool IsSave)
        {
            string str = eLDService.FenPingAndSendsDongTai(myTDeviceParam, arrEldRegion, arrleafObj,IsSave);
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="myTDeviceParam"></param>
        /// <param name="arrEldRegion"></param>
        /// <param name="arrleafObj"></param>
        /// <returns></returns>
        [WebMethod(Description = "分区且实现内容填充（整屏写入）支持轮流播放")]
        public string FenPingAndSendsDongTai(MyTDeviceParam myTDeviceParam, ELDRegion[] arrEldRegion, LeafObj[] arrleafObj)
        {
            string str = eLDService.FenPingAndSendsDongTai(myTDeviceParam, arrEldRegion, arrleafObj);
            return str;
        }

        /// <summary>
        /// 校正显示屏时间完成
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        [WebMethod(Description = " 返回 校正显示屏时间完成 表示可以连接设备 ")]
        public string AdjustTime(MyTDeviceParam myTDeviceParam)
        {
            string str = eLDService.AdjustTime(myTDeviceParam);
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myTDeviceParam"></param>
        /// <param name="arrEldRegion"></param>
        /// <param name="arrdisplayObj"></param>
        /// <returns></returns>
        //[WebMethod(Description = "分区且实现内容填充（整屏写入）")]
        public string FenPingAndSends(MyTDeviceParam myTDeviceParam, ELDRegion[] arrEldRegion, DisplayObj[] arrdisplayObj)
        {
            string str=  eLDService.FenPingAndSends(myTDeviceParam, arrEldRegion, arrdisplayObj);
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myTDeviceParam"></param>
        /// <param name="displayObj"></param>
        /// <param name="RegionIndex"></param>
        /// <returns></returns>
        //[WebMethod(Description = "向指定分区发送信息")]
        public string SendObjToELD(MyTDeviceParam myTDeviceParam, DisplayObj displayObj, int RegionIndex)
        {
            string str = eLDService.SendObjToELD(myTDeviceParam, displayObj, RegionIndex);
            return str;
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
