using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSendJingTaiMessage.BusinessLogic
{
  public static  class BLLMySql
    {
        static  string MySqlConnString = ConfigurationManager.AppSettings["mysqlconnectionString"].ToString();
        public static DataTable GetDataInof()
        {
          string   sqlCommandText = @" select l.locPort, l.rmtPort,r.led_ip,r.region,r.region_left,r.region_top,r.region_width,
                r.region_height,r.text_left,r.text_top,r.text_width,r.text_height,r.text_size,r.text_color,  r.text_in,r.text_out,r.text_stop,
                r.wordwrap,r.type,r.next_time,  s.id as messageID,s.led_id,s.led_region_id,s.type,s.origin_type,s.value,s.status 
                from led_region as r ,led_send_prepare  as s , led as l where  l.led_ip=r.led_ip and r.id=s.led_region_id and r.next_time=0  ";

            MySqlConnection myCon = new MySqlConnection(MySqlConnString);
            MySqlDataAdapter da = new MySqlDataAdapter(sqlCommandText, myCon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myCon.Close();

            return ds.Tables[0];
        }
        public static MySqlDataReader GetDataInofII()
        {
            string sqlCommandText = @" select l.locPort, l.rmtPort,r.led_ip,r.region,r.region_left,r.region_top,r.region_width,
                r.region_height,r.text_left,r.text_top,r.text_width,r.text_height,r.text_size,r.text_color,  r.text_in,r.text_out,r.text_stop,
                r.wordwrap,r.type,r.next_time,  s.id as messageID,s.led_id,s.led_region_id,s.type,s.origin_type,s.value,s.status 
                from led_region as r ,led_send_prepare  as s , led as l where  l.led_ip=r.led_ip and r.id=s.led_region_id and r.next_time=0  ";

            MySqlConnection myCon = new MySqlConnection(MySqlConnString);
            myCon.Open();
            MySqlCommand mycmd = myCon.CreateCommand();
            mycmd.CommandText = sqlCommandText;
            MySqlDataReader myreader = mycmd.ExecuteReader();
            myCon.Close();
            return myreader;

        }

    }
}
