using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELD_CreateLuKuang.Entity
{
    /// <summary>
	/// led:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class Led
    {
        public Led()
        { }
        #region Model
        private int _id;
        private string _led_ip;
        private string _number;
        private int _width;
        private int _height;
        private string _led_name;
        private string _led_area;
        private int _locport;
        private int _rmtport;
        private int _led_model;
        private int _led_region;
        private int _enable = 0;
        private string _latlng;
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
        public string led_ip
        {
            set { _led_ip = value; }
            get { return _led_ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int width
        {
            set { _width = value; }
            get { return _width; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string led_name
        {
            set { _led_name = value; }
            get { return _led_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string led_area
        {
            set { _led_area = value; }
            get { return _led_area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int locport
        {
            set { _locport = value; }
            get { return _locport; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int rmtport
        {
            set { _rmtport = value; }
            get { return _rmtport; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int led_model
        {
            set { _led_model = value; }
            get { return _led_model; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int led_region
        {
            set { _led_region = value; }
            get { return _led_region; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int enable
        {
            set { _enable = value; }
            get { return _enable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string latlng
        {
            set { _latlng = value; }
            get { return _latlng; }
        }
        #endregion Model

    }
}
