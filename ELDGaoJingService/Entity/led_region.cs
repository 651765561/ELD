using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDGaoJingService.Entity
{
    /// <summary>
	/// led_region:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class led_region
    {
        public led_region()
        { }
        #region Model
        /// <summary>
        /// auto_increment
        /// </summary>
        public int id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string led_ip
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int region
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int region_left
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int region_top
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int region_width
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int region_height
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int text_left
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int text_top
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int text_width
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int text_height
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int text_size
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int text_color
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int text_in
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int text_out
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int text_stop
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int wordwrap
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int type
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int next_time
        {
            set;
            get;
        }
        #endregion Model

    }
}
