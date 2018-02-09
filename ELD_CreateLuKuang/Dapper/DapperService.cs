using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELD_CreateLuKuang.Dapper
{
    public class DapperService
    {

        public static SqlConnection SqlConnection()
        {
            string sqlconnectionString = ConfigurationManager.AppSettings["sqlconnectionString"].ToString();
            var connection = new SqlConnection(sqlconnectionString);
            connection.Open();
            return connection;
        }
        public static MySqlConnection MySqlConnection()
        {
          
            string mysqlconnectionString = ConfigurationManager.AppSettings["mysqlconnectionString"].ToString();
            var connection = new MySqlConnection(mysqlconnectionString);
            connection.Open();
            return connection;
        }
    }

}
