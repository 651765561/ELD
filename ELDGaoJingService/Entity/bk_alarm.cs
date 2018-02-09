using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDGaoJingService.Entity
{
    /// <summary>
    /// bk_alarm:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class bk_alarm
    {
        public bk_alarm()
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
        public int fid
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string direction
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string lane
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime atime
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string plate
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int color
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int speed
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int threshold
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int length
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int wrong
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string reason
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int deal
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string feature
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int msec
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string device
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string bcolor
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string bcolors
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string alarm
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string extent
        {
            set;
            get;
        }
        #endregion Model

    }
}
