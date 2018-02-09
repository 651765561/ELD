using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSendJingTaiMessage.Dapper
{
    public class DBELD
    {
        #region  led  表操作

        /// <summary>
        /// 获取所有eld设备信息
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetAllLedList()
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @"SELECT * from led ";


                //  sqlCommandText = @"SELECT * from led_region ";
                List<dynamic> list = conn.Query<dynamic>(sqlCommandText).ToList<dynamic>();
                conn.Close();
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    item.led_name = Latin2GBK(item.led_name);
                    item.led_area = Latin2GBK(item.led_area);
                }
                return list;
            }
        }

        /// <summary>
        /// 修改ELD设备状态
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public bool UpdateELDEnable(string ip, int enable)
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @"update led set ENABLE="+ enable + " where led_ip='"+ ip + "'";
                bool flag = conn.Execute(sqlCommandText) > 0;
                conn.Close();
                conn.Dispose();
                return flag;
            }
        }

        #endregion
        #region 发送文字信息表  led_send_prepare
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="IsSend"></param>
        /// <returns></returns>
        public bool Update_Led_send_prepare_Status(string ip, int IsSend)
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @"update  led_send_prepare set `status`="+ IsSend + 
                    " where  led_region_id in(select id from led_region where  led_ip='"+ip+"')";
                bool flag = conn.Execute(sqlCommandText) > 0;
                conn.Close();
                conn.Dispose();
                return flag;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="IsSend"></param>
        /// <returns></returns>
        public bool Update_Led_send_prepare_Status(int messageId, int IsSend)
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @"update led_send_prepare set `status`=" + IsSend + " where id=" + messageId;
                bool flag = conn.Execute(sqlCommandText) > 0;
                conn.Close();
                conn.Dispose();
                return flag;
            }
        }
        #endregion

        public List<dynamic> GetJingTaiXinForSendByIP(string ip) {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @"select *,s.id as messageID  from led_region  as r ,led_send_prepare 
                                as s where  r.id=s.led_region_id and r.next_time=0  and r.led_ip='"+ ip + "'  ";

                StringBuilder str = new StringBuilder();
                str.Append(" select  r.led_ip,r.region,r.region_left,r.region_top,r.region_width,r.region_height, ");
                str.Append(" r.text_left,r.text_top,r.text_width,r.text_height,r.text_size,r.text_color, ");
                str.Append(" r.text_in,r.text_out,r.text_stop,r.wordwrap,r.type,r.next_time, ");
                str.Append(" s.id as messageID,s.led_id,s.led_region_id,s.type,s.origin_type,s.value,s.status ");
                str.Append("  from led_region as r ,led_send_prepare  as s ");
                str.Append(" where  r.id=s.led_region_id and r.next_time=0  ");
                str.Append("and r.led_ip = '"+ ip + "'  ");
                sqlCommandText = str.ToString();
                //  sqlCommandText = @"SELECT * from led_region ";
                List<dynamic> list = conn.Query<dynamic>(sqlCommandText).ToList<dynamic>();
                conn.Close();
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    item.value = Latin2GBK(item.value);
                }
                return list;
            }
        }
        public List<dynamic> GetJingTaiXinForSendByIP()
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string    sqlCommandText = @" select l.locPort, l.rmtPort,r.led_ip,r.region,r.region_left,r.region_top,r.region_width, r.region_height,r.text_left,r.text_top,r.text_width,r.text_height,r.text_size,r.text_color,  r.text_in,r.text_out,r.text_stop,r.wordwrap,r.type,r.next_time,  s.id as messageID,s.led_id,s.led_region_id,s.type,s.origin_type,s.value,s.status  from led_region as r ,led_send_prepare  as s , led as l where  l.led_ip=r.led_ip and r.id=s.led_region_id and r.next_time=0  ";


                //StringBuilder str = new StringBuilder();
                //str.Append(" select  r.led_ip,r.region,r.region_left,r.region_top,r.region_width,r.region_height, ");
                //str.Append(" r.text_left,r.text_top,r.text_width,r.text_height,r.text_size,r.text_color, ");
                //str.Append(" r.text_in,r.text_out,r.text_stop,r.wordwrap,r.type,r.next_time, ");
                //str.Append(" s.id as messageID,s.led_id,s.led_region_id,s.type,s.origin_type,s.value,s.status ");
                //str.Append("  from led_region as r ,led_send_prepare  as s ");
                //str.Append(" where  r.id=s.led_region_id and r.next_time=0  ");
                
                //  sqlCommandText = @"SELECT * from led_region ";
                List<dynamic> list = conn.Query<dynamic>(sqlCommandText).ToList<dynamic>();
                conn.Close();
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    item.value = Latin2GBK(item.value);
                }
                return list;
            }
        }
        public List<dynamic> GetJingTaiXinForSendByIP(string ip,int sendState)
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @"select *,s.id as messageID  from led_region  as r ,led_send_prepare  as s where  r.id=s.led_region_id and r.next_time=0 and s.status="+sendState+"  and r.led_ip='" + ip + "'  ";


                //  sqlCommandText = @"SELECT * from led_region ";
                List<dynamic> list = conn.Query<dynamic>(sqlCommandText).ToList<dynamic>();
                conn.Close();
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    item.value = Latin2GBK(item.value);
                }
                return list;
            }
        }
        /// <summary>
        /// 获取待发送的静态信息
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetJingTaiXinForSend()
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @"select *,s.id as messageID  from led_region  as r ,led_send_prepare  as s where  r.id=s.led_region_id and r.next_time=0 and s.status=0  ";


                //  sqlCommandText = @"SELECT * from led_region ";
                List<dynamic> list = conn.Query<dynamic>(sqlCommandText).ToList<dynamic>();
                conn.Close();
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    item.value = Latin2GBK(item.value);
                }
                return list;
            }
        }

        public dynamic GetEldModel(string ip)
        {
            dynamic model;
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                var sql = @"SELECT CrsIp,CrsName FROM crossing where crsCode=@crsCode";
                sql = @"SELECT * from led where led_ip=@ip";
                var result = conn.QueryFirstOrDefault(sql, new { ip });
                conn.Close();
                conn.Dispose();
                return result;
            }

        }
        public static String Latin2GBK(String str)
        {
            try
            {
                byte[] bytesStr = Encoding.GetEncoding("latin1").GetBytes(str);
                return Encoding.GetEncoding("GB2312").GetString(bytesStr);
            }
            catch
            {
                return str;
            }
        }

        /// <summary>
        /// 获取待发送的静态信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetJingTaiXinForSendII()
        {
            using (MySqlConnection conn = DapperService.MySqlConnection())
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select *  from led_region  as r ,led_send_prepare  as s where  r.id=s.led_region_id and r.next_time=0 and s.`status`=0", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
        }

        ///// <summary>
        ///// 修改静态信息发布状态
        ///// update led_send_prepare set `status`=0 where id=0
        ///// </summary>
        ///// <returns></returns>
        //public bool UpdateLed_send_prepare_State(int MessageId,int status) {
        //    bool flag = false;
        //    using (IDbConnection conn = DapperService.MySqlConnection())
        //    {
        //        conn.Open();
        //        conn.Execute("update led_send_prepare set `status`="+ status + " where id="+ MessageId);
        //        conn.Close();
        //    }
        //        return flag;
        //}
    }
}
