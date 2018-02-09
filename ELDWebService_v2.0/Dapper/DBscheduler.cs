using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDWebService_v2._0.Dapper
{
    public class DBscheduler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static List<dynamic> GetList(int state)
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @"select * from scheduler where state= " + state;
                List<dynamic> list = conn.Query<dynamic>(sqlCommandText).AsList<dynamic>();
                conn.Close();
                return list;
            }
        }

        public static List<dynamic> GetAllList()
        {
            using (IDbConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @"select * from scheduler  ";
                List<dynamic> list = conn.Query<dynamic>(sqlCommandText).AsList<dynamic>();
                conn.Close();
                return list;
            }
        }


    }
}
