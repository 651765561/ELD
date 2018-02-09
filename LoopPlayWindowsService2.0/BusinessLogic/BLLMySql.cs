using Dapper;
using LoopPlayWindowsService2._0.Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopPlayWindowsService2._0.BusinessLogic
{
    public class BLLMySql
    {

        static string MySqlConnString = ConfigurationManager.AppSettings["mysqlconnectionString"].ToString();

        public int Update_led_send_prepare(int messageId,int isloop,DateTime playtime)
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @" UPDATE led_send_prepare set isloop="+ isloop + " ,playtime='"+ playtime .ToString("yyyy-MM-dd HH:mm:ss")+ "' where   id=  "+ messageId;

                return conn.Execute(sqlCommandText);
                 
            }
        }
        public IList<dynamic> GetLeds()
        {
            //IList<dynamic> list = null;
            //MySqlConnection myCon = new MySqlConnection(MySqlConnString);
            //StringBuilder str = new StringBuilder();
            //str.Append(" SELECT * FROM led ");

            //return list;
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @"select * from led  ";
                List<dynamic> list = conn.Query<dynamic>(sqlCommandText).AsList<dynamic>();
                conn.Close();
                return list;
            }
        }

        /// <summary>
        /// 获取轮流播放信息
        /// </summary>
        /// <returns></returns>
        public IList<Entity.LoopPlay> SearchLoopPlayListII()
        {
            MySqlConnection myCon = new MySqlConnection(MySqlConnString);
            StringBuilder str = new StringBuilder();
            str.Append("  SELECT  a.playtime,a.id as messageId,a.isloop, c.region, c.wordwrap, c.text_stop, c.text_out, c.text_in,b.rmtport, b.locport,b.led_ip,b.id as r_id ,b.led_name,c.region as regionIndex,c.text_left,c.text_top,c.text_width,c.text_height,a.`value`, ");
            str.Append("  c.text_size,c.text_color,c.wordwrap,c.text_in,c.text_out,c.text_stop,c.next_time ");
            str.Append(" FROM distrib.led_send_prepare AS a,distrib.led AS b,distrib.led_region AS c WHERE a.led_id = b.id AND a.led_region_id = c.id AND c.next_time>0 ");

            MySqlDataAdapter da = new MySqlDataAdapter(str.ToString(), myCon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myCon.Close();
            List<Entity.LoopPlay> list = new List<Entity.LoopPlay>();
            list = ConvertToList(ds.Tables[0]);
            return list;
        }
        public List<Entity.LoopPlay> SearchLoopPlayList()
        {
            /*
             SELECT b.locport,b.led_ip,b.id,b.led_name,c.region as regionIndex,c.text_left,c.text_top,c.text_width,c.text_height,a.`value`,
             * c.text_size,c.text_color,c.wordwrap,c.text_in,c.text_out,c.text_stop,c.next_time
             * FROM distrib.led_send_prepare AS a,distrib.led AS b,distrib.led_region AS c WHERE a.led_id = b.id AND a.led_region_id = c.id
             */
            MySqlConnection myCon = new MySqlConnection(MySqlConnString);
            StringBuilder str = new StringBuilder();
            str.Append("  SELECT b.locport,b.led_ip,b.id as r_id ,b.led_name,c.region as regionIndex,c.text_left,c.text_top,c.text_width,c.text_height,a.`value`, ");
            str.Append(" c.text_size,c.text_color,c.wordwrap,c.text_in,c.text_out,c.text_stop,c.next_time ");
            str.Append(" FROM distrib.led_send_prepare AS a,distrib.led AS b,distrib.led_region AS c WHERE a.led_id = b.id AND a.led_region_id = c.id ");
            //  MySqlDataAdapter da = new MySqlDataAdapter("SELECT b.led_ip,c.region as regionIndex,c.next_time,a.`value` FROM distrib.led_send_prepare AS a,distrib.led AS b,distrib.led_region AS c WHERE a.led_id = b.id AND a.led_region_id = c.id ", myCon);
            MySqlDataAdapter da = new MySqlDataAdapter(str.ToString(), myCon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myCon.Close();
            List<Entity.LoopPlay> list = new List<Entity.LoopPlay>();
            list = ConvertToList(ds.Tables[0]);
            return list;
        }
        public int GetNextTime()
        {
            int num = 1;
            MySqlConnection myCon = new MySqlConnection(MySqlConnString);
            StringBuilder str = new StringBuilder();
            myCon.Open();
            str.Append("select  MIN(r.next_time)  as NextTime from led_region as r ,led_send_prepare  as s , led as l where  l.led_ip=r.led_ip and r.id=s.led_region_id and r.next_time>0 ");
            MySqlCommand cmd = myCon.CreateCommand();
            cmd.CommandText = str.ToString();
            MySqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                num = int.Parse(read["NextTime"].ToString());
            }

            return num;
        }
        public List<Entity.LoopPlay> SearchLoopPlayList(string led_ip)
        {
            /*
             SELECT b.locport,b.led_ip,b.id,b.led_name,c.region as regionIndex,c.text_left,c.text_top,c.text_width,c.text_height,a.`value`,
             * c.text_size,c.text_color,c.wordwrap,c.text_in,c.text_out,c.text_stop,c.next_time
             * FROM distrib.led_send_prepare AS a,distrib.led AS b,distrib.led_region AS c WHERE a.led_id = b.id AND a.led_region_id = c.id
             */
            MySqlConnection myCon = new MySqlConnection(MySqlConnString);
            StringBuilder str = new StringBuilder();
            str.Append("  SELECT b.locport,b.led_ip,b.id as r_id ,b.led_name,c.region as regionIndex,c.text_left,c.text_top,c.text_width,c.text_height,a.`value`, ");
            str.Append(" c.text_size,c.text_color,c.wordwrap,c.text_in,c.text_out,c.text_stop,c.next_time ");
            str.Append(" FROM distrib.led_send_prepare AS a,distrib.led AS b,distrib.led_region AS c WHERE a.led_id = b.id AND a.led_region_id = c.id ");
            if (led_ip.Trim() != "")
            {
                str.Append("and b.led_ip='" + led_ip + "'");
            }

            //  MySqlDataAdapter da = new MySqlDataAdapter("SELECT b.led_ip,c.region as regionIndex,c.next_time,a.`value` FROM distrib.led_send_prepare AS a,distrib.led AS b,distrib.led_region AS c WHERE a.led_id = b.id AND a.led_region_id = c.id ", myCon);
            MySqlDataAdapter da = new MySqlDataAdapter(str.ToString(), myCon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myCon.Close();
            List<Entity.LoopPlay> list = new List<Entity.LoopPlay>();
            list = ConvertToList(ds.Tables[0]);
            return list;
        }
        private List<Entity.LoopPlay> ConvertToList(DataTable dt)
        {
            List<Entity.LoopPlay> list = new List<Entity.LoopPlay>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var r = dt.Rows[i];
                var m = DataRowToModel(r);
                list.Add(m);

            }
            return list;
        }
        public static Entity.LoopPlay DataRowToModel(DataRow row)
        {
            Entity.LoopPlay model = new Entity.LoopPlay();
            //messageId
            if (row["messageId"] != null && row["messageId"].ToString() != "")
            {
                model.messageId = int.Parse(row["messageId"].ToString());
            }
            //isloop
            if (row["isloop"] != null && row["isloop"].ToString() != "" && row["isloop"].ToString().Trim() == "1")
            {
                model.isloop = true;
            }
            else
            {
                model.isloop = false;
            }
            //region
            if (row["region"] != null && row["region"].ToString() != "")
            {
                model.region = int.Parse(row["region"].ToString());
            }
            //wordwrap
            if (row["wordwrap"] != null && row["wordwrap"].ToString() != "")
            {
                model.wordwrap = int.Parse(row["wordwrap"].ToString());
            }
            //text_stop
            if (row["text_stop"] != null && row["text_stop"].ToString() != "")
            {
                model.text_stop = int.Parse(row["text_stop"].ToString());
            }
            //text_out
            if (row["text_out"] != null && row["text_out"].ToString() != "")
            {
                model.text_out = int.Parse(row["text_out"].ToString());
            }
            //text_in
            if (row["text_in"] != null && row["text_in"].ToString() != "")
            {
                model.text_in = int.Parse(row["text_in"].ToString());
            }
            //rmtport
            if (row["rmtport"] != null && row["rmtport"].ToString() != "")
            {
                model.rmtport = int.Parse(row["rmtport"].ToString());
            }
            if (row["next_time"] != null && row["next_time"].ToString() != "")
            {
                model.next_time = int.Parse(row["next_time"].ToString());
            }
            if (row["value"] != null && row["value"].ToString() != "")
            {
                model.value = Latin2GBK(row["value"].ToString());
            }
            if (row["led_ip"] != null && row["led_ip"].ToString() != "")
            {
                model.led_ip = row["led_ip"].ToString();
            }
            if (row["regionIndex"] != null && row["regionIndex"].ToString() != "")
            {
                model.regionIndex = int.Parse(row["regionIndex"].ToString());
            }
            if (row["led_name"] != null && row["led_name"].ToString() != "")
            {
                model.led_name = Latin2GBK(row["led_name"].ToString());
            }
            if (row["locport"] != null && row["locport"].ToString() != "")
            {
                model.locport = int.Parse(row["locport"].ToString());
            }
            if (row["r_id"] != null && row["r_id"].ToString() != "")
            {
                model.r_id = int.Parse(row["r_id"].ToString());
            }

            if (row["text_left"] != null && row["text_left"].ToString() != "")
            {
                model.text_left = int.Parse(row["text_left"].ToString());
            }
            if (row["text_top"] != null && row["text_top"].ToString() != "")
            {
                model.text_top = int.Parse(row["text_top"].ToString());
            }
            if (row["text_width"] != null && row["text_width"].ToString() != "")
            {
                model.text_width = int.Parse(row["text_width"].ToString());
            }
            if (row["text_size"] != null && row["text_size"].ToString() != "")
            {
                model.text_size = int.Parse(row["text_size"].ToString());
            }
            if (row["text_color"] != null && row["text_color"].ToString() != "")
            {
                model.text_color = int.Parse(row["text_color"].ToString());
            }
            if (row["text_height"] != null && row["text_height"].ToString() != "")
            {
                model.text_height = int.Parse(row["text_height"].ToString());
            }
            //playtime

            if (row["playtime"] != null && row["playtime"].ToString() != "")
            {
                model.PlayDateTime = DateTime.Parse(row["playtime"].ToString());
            }
            return model;
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
    }
}
