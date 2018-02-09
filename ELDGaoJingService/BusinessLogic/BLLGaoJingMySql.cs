using Dapper;
using ELDGaoJingService.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDGaoJingService.BusinessLogic
{
    public class BLLGaoJingMySql
    {
        #region 获取ELD显示设备信息
        public Entity.led GetLedByIp(string ip)
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @" select * from led where led_ip='" + ip + "' ";

                Entity.led model = conn.QueryFirst<Entity.led>(sqlCommandText);
                model.led_name = Latin2GBK(model.led_name);
                model.led_area = Latin2GBK(model.led_area);
                conn.Close();
                return model;
            }
        }

        #endregion
        #region 区域信息
        
        /// <summary>
        /// 获取某个显示屏的分区信息
        /// </summary>
        /// <param name="led_ip"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public  Entity.led_region Getled_regionModel(string led_ip , int region )
        {

            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @" SELECT * from  led_region  where led_ip='"+ led_ip + "' and region=  "+ region;
                Entity.led_region model = conn.QueryFirst<Entity.led_region>(sqlCommandText);
                conn.Close();
                return model;
            }
        }
        #endregion

        #region 告警信息
        public List<dynamic> GetGaojingList()
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @" SELECT  a.message,l.* from alram as a , led_region as l where a.ip=l.led_ip and l.type=1  ";
                List<dynamic> list = conn.Query<dynamic>(sqlCommandText).AsList<dynamic>();
                conn.Close();
                return list;
            }
        }

        private Entity.bk_alarm GetLastBk_Alarm()
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @" SELECT * FROM bk_alarm ORDER BY  UNIX_TIMESTAMP(atime) DESC  LIMIT 1 ";
                var m = conn.QueryFirst<Entity.bk_alarm>(sqlCommandText);

                return m;
            }

        }


        public string GetBkAlarmMessage()
        {
            var m = GetLastBk_Alarm();
            string str = m.atime.ToString("yyyy/MM/dd HH:mm:ss") + Latin2GBK(m.plate + m.name + m.direction + m.reason);
            return str;

        }
        public String Latin2GBK(String str)
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

        public List<Entity.led_region> GetGaoJingELDAndRegion()
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @" SELECT * from  led_region where type=1 ";
                List<Entity.led_region> list = conn.Query<Entity.led_region>(sqlCommandText).AsList<Entity.led_region>();
                conn.Close();
                return list;
            }
        }
        #endregion

    }
}
