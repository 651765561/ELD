using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDWebService_v2._0.Entity
{
    /// <summary>
    /// roadDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RoadDetail
    {
        public RoadDetail()
        { }
        #region Model
        
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int r_id
        {
            set;
            get;
        }
        /// <summary>
        /// 0: 畅通 绿色 ;1:一般 黄色 ；2：拥堵 红色
        /// </summary>
        public int status
        {
            set;
            get;
        }
        /// <summary>
        /// 路口 路段起始x坐标
        /// </summary>
        public string x1
        {
            set;
            get;
        }
        /// <summary>
        /// 路口 路段起始y坐标
        /// </summary>
        public string y1
        {
            set;
            get;
        }
        /// <summary>
        /// 路口 路段末端x坐标
        /// </summary>
        public string x2
        {
            set;
            get;
        }
        /// <summary>
        /// 路口 路段末端y坐标
        /// </summary>
        public string y2
        {
            set;
            get;
        }
        /// <summary>
        /// 道路宽度
        /// </summary>
        public int roadwidth { get; set; }
        /// <summary>
        /// 路口路段名称
        /// </summary>
        public string detailName
        {
            set;
            get;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set;
            get;
        }
        #endregion Model

    }
}
