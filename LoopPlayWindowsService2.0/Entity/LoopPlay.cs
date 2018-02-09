using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopPlayWindowsService2._0.Entity
{
    public class LoopPlay
    {
        public int messageId { get; set; }
        public bool isloop { get; set; }
        public int region { get; set; }
        public int wordwrap { get; set; }
        public int text_stop { get; set; }
        public int text_out { get; set; }
        public int text_in { get; set; }
        public int rmtport { get; set; }
        public int text_top { get; set; }
        public int text_left { get; set; }
        public string led_name { get; set; }
        public int r_id { get; set; }
        public int locport { get; set; }
        public string led_ip { get; set; }

        public int regionIndex { get; set; }
        public int text_color { get; set; }
        public int text_size { get; set; }
        public int text_height { get; set; }
        public int text_width { get; set; }

        public string fontname { get; set; }
        /// <summary>
        /// 停留时间
        /// </summary>
        public int next_time { get; set; }

        public DateTime PlayDateTime { get; set; }

        /// <summary>
        /// 显示内容
        /// </summary>
        public string value { get; set; }

    }
}
