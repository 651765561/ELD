using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSendJingTaiMessage
{

    public class ELDobj
    {
        private const int WM_LED_NOTIFY = 1025;

        //CLEDSender LEDSender = new CLEDSender();

        //public TDeviceParam TDeviceParam { get; set; }
        /// <summary>
        /// 显示屏基色类型
        //COLOR_MODE_MONO = 1;  //单色
        // COLOR_MODE_DOUBLE = 2;  //双色
        //COLOR_MODE_THREE = 3;  //全彩无灰度
        //COLOR_MODE_FULLCOLOR = 4;  //全彩
        /// </summary>
        public int MakeRootColorIndex { set; get; }

        //设备控制参数
        public TSenderParam TSenderParam { get; set; }

        //设备通讯参数 (是TSenderParam 的一个属性)
        public TDeviceParam TDeviceParam { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public ELDRegion Region
        {
            get;
            set;
        }

    }
    //设备通讯参数
    public struct MyTDeviceParam
    {
        public int devType;
        public int locPort;
        public string rmtHost;
        public int rmtPort;
        public int dstAddr;

        /// <summary>
        ///取值（1：告警；0:文本；2：时钟;3:图片（路况））
        /// </summary>
        public int displayType
        {
            set;
            get;
        }
        /// <summary>
        /// 路口编号
        /// </summary>
        public int r_id
        {
            set;
            get;
        }
        /// <summary>
        /// 路口名称
        /// </summary>
        public string r_name
        {
            set;
            get;
        }
    }

    public enum ObjType
    {
        Text = 0,
        Picture = 1,
        DateTime = 2,
        Clock = 3
    }

    public class DisplayObj
    {


        /// <summary>
        ///   Text = 0,
        ///  Picture = 1,
        ///DateTime = 2,
        /// Clock = 3
        /// </summary>
        public int ObjTypeIndex { get; set; }

        public TextPro TextPro { get; set; }

        public PicturePro PicturePro { get; set; }

        public DateTimePro DateTimePro { get; set; }

        public ClockPro ClockPro { get; set; }
    }


    /// <summary>
    /// 22.	添加模拟时钟
    /// </summary>
    public class ClockPro
    {
        public int left
        {
            set;
            get;
        }

        public int top
        {
            get;
            set;
        }
        public int width { get; set; }

        public int height { get; set; }

        /// <summary>
        ///  transparent 是否透明 =1表示透明；=0表示不透明
        /// </summary>
        public int transparent { get; set; }
        /// <summary>
        ///   border 流水边框（未实现）
        /// </summary>
        public int border { get; set; }

        /// <summary>
        /// 秒偏移量
        /// </summary>
        public int offset { get; set; }

        /// <summary>
        /// 背景颜色
        /// </summary>
        public ushort bkcolor { get; set; }

        /// <summary>
        /// 边框颜色
        /// </summary>
        public ushort bordercolor { get; set; }

        /// <summary>
        /// 边框宽度
        /// </summary>
        public ushort borderwidth { get; set; }

        /// <summary>
        /// 边框形状 =0表示正方形；=1表示圆角方形；=2表示圆形
        /// </summary>
        public int bordershape { get; set; }

        public int dotradius { get; set; }

        public int adotwidth { get; set; }

        public ushort adotcolor { get; set; }

        public int bdotwidth { get; set; }

        public ushort bdotcolor { get; set; }

        public int hourwidth { get; set; }

        public ushort hourcolor { get; set; }

        public int minutewidth { get; set; }

        public ushort minutecolor { get; set; }

        public int secondwidth { get; set; }

        public ushort secondcolor { get; set; }

    }
    /// <summary>
    /// 20.	添加日期时间显示
    /// </summary>
    public class DateTimePro
    {
        public int alignment { get; set; }
        public int left
        {
            set;
            get;
        }

        public int top
        {
            get;
            set;
        }

        public int width { get; set; }

        public int height { get; set; }

        /// <summary>
        ///  transparent 是否透明 =1表示透明；=0表示不透明
        /// </summary>
        public int transparent { get; set; }
        /// <summary>
        ///   border 流水边框（未实现）
        /// </summary>
        public int border { get; set; }

        public string fontname { get; set; }

        public int fontsize { get; set; }

        public Int32 fontcolor { get; set; }

        public Int32 fontstyle { get; set; }

        /// <summary>
        /// 年偏移量
        /// </summary>
        public int year_offset { get; set; }

        /// <summary>
        /// 月偏移量
        /// </summary>
        public int month_offset { get; set; }

        /// <summary>
        /// 日偏移量
        /// </summary>
        public int day_offset { get; set; }

        public int sec_offset { get; set; }
        /// <summary>
        /// 显示格式: #y表示年 #m表示月 #d表示日 #h表示时 #n表示分 #s表示秒 #w表示星期 #c表示农历;
        /// 举例： format="#y年#m月#d日 #h时#n分#s秒 星期#w 农历#c"时，显示为"2009年06月27日 12时38分45秒 星期六 农历五月初五"
        /// 
        /// </summary>
        public string format { get; set; }
    }
    /// <summary>
    ///31.	添加图片文件播放
    ///  long (_stdcall *AddPicture)(WORD num, long left, long top, long width, long height, 
    /// long transparent, long border, char* filename, long inmethod, long inspeed, long outmethod, 
    /// long outspeed, long stopmethod, long stopspeed, long stoptime); //stoptime单位为毫秒
    /// </summary>
    public class PicturePro
    {
        public int alignment { get; set; }
        public int left
        {
            set;
            get;
        }

        public int top
        {
            get;
            set;
        }

        public int width { get; set; }

        public int height { get; set; }

        /// <summary>
        ///  transparent 是否透明 =1表示透明；=0表示不透明
        /// </summary>
        public int transparent { get; set; }
        /// <summary>
        ///   border 流水边框（未实现）
        /// </summary>
        public int border { get; set; }

        public string filename { get; set; }

        /// <summary>
        /// 字体滚动方式
        /// </summary>
        public int inmethod { get; set; }

        /// <summary>
        /// 引出速度(取值范围0-5，从快到慢)
        /// </summary>
        public int inspeed { get; set; }

        /// <summary>
        /// inmethod 优先于 outmethod
        /// </summary>
        public int outmethod { get; set; }

        /// <summary>
        /// 引出速度(取值范围0-5，从快到慢)
        /// </summary>
        public int outspeed { get; set; }

        /// <summary>
        ///  停留方式
        /// </summary>
        public int stopmethod { get; set; }

        /// <summary>
        /// 停留速度(取值范围0-5，从快到慢)
        /// </summary>
        public int stopspeed { get; set; }

        /// <summary>
        /// 停留时间(单位毫秒)
        /// </summary>
        public int stoptime { get; set; }
    }

    /*32.	添加文字播放
函数声明：
long (_stdcall *AddText)(WORD num, long left, long top, 
     * long width, long height, long transparent, long border, 
     * char* str, char* fontname, long fontsize, long fontcolor,
     * long fontstyle, long wordwrap, long inmethod, long inspeed, 
     * long outmethod, long outspeed, long stopmethod, long stopspeed,
     * long stoptime); //stoptime单位为毫秒
*/
    /// <summary>
    /// 文本属性
    /// </summary>
    public class TextPro
    {
        public int left
        {
            set;
            get;
        }

        public int top
        {
            get;
            set;
        }
        public int alignment { get; set; }
        public int width { get; set; }

        public int height { get; set; }

        /// <summary>
        ///  transparent 是否透明 =1表示透明；=0表示不透明
        /// </summary>
        public int transparent { get; set; }
        /// <summary>
        ///   border 流水边框（未实现）
        /// </summary>
        public int border { get; set; }

        public string str { get; set; }

        public string fontname { get; set; }

        public int fontsize { get; set; }

        public Int32 fontcolor { get; set; }

        public Int32 fontstyle { get; set; }
        public int wordwrap { get; set; }
        /// <summary>
        /// 字体滚动方式
        /// </summary>
        public int inmethod { get; set; }

        /// <summary>
        /// 引出速度(取值范围0-5，从快到慢)
        /// </summary>
        public int inspeed { get; set; }

        /// <summary>
        /// inmethod 优先于 outmethod
        /// </summary>
        public int outmethod { get; set; }

        /// <summary>
        /// 引出速度(取值范围0-5，从快到慢)
        /// </summary>
        public int outspeed { get; set; }

        /// <summary>
        ///  停留方式
        /// </summary>
        public int stopmethod { get; set; }

        /// <summary>
        /// 停留速度(取值范围0-5，从快到慢)
        /// </summary>
        public int stopspeed { get; set; }

        /// <summary>
        /// 停留时间(单位毫秒)
        /// </summary>
        public int stoptime { get; set; }
    }

    /// <summary>
    /// 区域对象
    /// </summary>
    public class ELDRegion
    {
        public int Region_Index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ELD_IP
        {
            set;
            get;
        }
        /// <summary>
        /// 路口编号(显示屏编号)
        /// </summary>
        public int road_id
        {
            set;
            get;
        }
        /// <summary>
        /// 取值（1：告警；0:文本；2：时钟;3:图片（路况））
        /// </summary>
        public int RegionType
        {
            get; set;

        }
        public int top
        {
            get;
            set;
        }

        public int left
        {
            get;
            set;
        }

        public int width
        {
            get;
            set;
        }

        public int height
        {
            get;
            set;
        }

        public int border
        {
            get;
            set;
        }
    }

}
