using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELD_CreateLuKuang.Model
{
    /// <summary>
	/// scheduler:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class M_scheduler
    {
        public M_scheduler()
        { }
        #region Model
        private int _id;
        private string _groupname;
        private string _jobname;
        private string _trigggername;
        private int? _state = 0;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string groupName
        {
            set { _groupname = value; }
            get { return _groupname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jobName
        {
            set { _jobname = value; }
            get { return _jobname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string trigggerName
        {
            set { _trigggername = value; }
            get { return _trigggername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? state
        {
            set { _state = value; }
            get { return _state; }
        }
        #endregion Model

    }
}
