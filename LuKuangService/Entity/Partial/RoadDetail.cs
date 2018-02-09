using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuKuangService.Entity.Partial
{
   public class RoadDetail: LuKuangService.Entity.RoadDetail
    {
        public int RowNumber
        {
            get;
            set;
        }
        public string r_name
        {
            get;
            set;
        }

        public string picPath
        {
            get;
            set;
        }
        public bool IsCreatePicture
        {
            get;
            set;
        }
        /// <summary>
        /// 道路宽度
        /// </summary>
        public float r_width
        {
            get;
            set;
        }
    }
}
