using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELDWebService_v2._0.Entity
{
    /// <summary>
    /// region:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class region
    {
        public region()
        { }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public int seq
        {
            set; get;
        }
        /// <summary>
        /// 屏幕分区编号
        /// </summary>
        public int Region_Index
        {
            set; get;
        }
        /// <summary>
        /// 路口编号(显示屏编号)
        /// </summary>
        public int road_id
        {
            set; get;
        }
        /// <summary>
        /// 分区左边距
        /// </summary>
        public int left
        {
            set; get;
        }
        /// <summary>
        /// 分区顶部边距
        /// </summary>
        public int top
        {
            set; get;
        }
        /// <summary>
        /// 分区宽度
        /// </summary>
        public int width
        {
            set; get;
        }
        /// <summary>
        /// 分区高度
        /// </summary>
        public int height
        {
            set; get;
        }
        /// <summary>
        /// 分区边框
        /// </summary>
        public int border
        {
            set; get;
        }
        /// <summary>
        /// （1：告警；0:文本；2：时钟;3:图片（路况））
        /// </summary>
        public int Region_Type
        {
            set; get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string ELD_IP
        {
            set; get;
        }
        #endregion Model

    }
}