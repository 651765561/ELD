using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuKuangService.Entity
{
    /// <summary>
    /// road:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Road
    {
        public Road()
        { }
        #region Model

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
        /// <summary>
        /// 
        /// </summary>
        public string picPath
        {
            set;
            get;
        }
        /// <summary>
        /// 是否启用 （0：不生成图片;1:生成图片）
        /// </summary>
        public bool IsCreatePicture
        {
            set;
            get;
        }
        /// <summary>
        /// 道路宽度
        /// </summary>
        public decimal r_width
        {
            set;
            get;
        }
        /// <summary>
        /// eld屏 图片宽度
        /// </summary>
        public int eld_pictureWidth
        {
            set;
            get;
        }
        /// <summary>
        /// eld屏图片高度
        /// </summary>
        public int eld_pictureHeight
        {
            set;
            get;
        }
        /// <summary>
        /// led屏区域宽度
        /// </summary>
        public int eld_regionWidth
        {
            set;
            get;
        }
        /// <summary>
        /// led屏 区域高度
        /// </summary>
        public int eld_regionHeight
        {
            set;
            get;
        }
        /// <summary>
        /// led屏远程IP
        /// </summary>
        public string eld_rmtHost
        {
            set;
            get;
        }
        /// <summary>
        /// 是否连接ELD屏
        /// </summary>
        public bool IsConnectELD
        {
            set;
            get;
        }
        /// <summary>
        /// 本地端口
        /// </summary>
        public int locPort
        {
            set;
            get;
        }
        /// <summary>
        /// 远程端口
        /// </summary>
        public int rmtPort
        {
            set;
            get;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set;
            get;
        }
        /// <summary>
        /// （1：告警；0:文本；2：时钟;3:图片（路况））
        /// </summary>
        public int displayType
        {
            set;
            get;
        }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string area
        {
            set;
            get;
        }
        /// <summary>
        /// 是否下载原图
        /// </summary>
        public bool IsDownloadPicture
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int status
        {
            set;
            get;
        }

        #endregion Model

    }
}