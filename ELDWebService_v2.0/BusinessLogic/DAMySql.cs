using Dapper;
using ELDWebService_v2._0.Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace ELDWebService_v2._0.BusinessLogic
{
    public class DAMySql
    {
        #region road 数据信息
        /// <summary>
        /// 获取道路信息
        /// </summary>
        /// <returns></returns>
        public List<Entity.Road> GetRoadList()
        {
            
            using (MySqlConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @" select * from road order by r_id asc";
                List<Entity.Road> list = conn.Query<Entity.Road>(sqlCommandText).AsList<Entity.Road>();
                //Entity.led model = conn.QueryFirst<Entity.led>(sqlCommandText);
                //model.led_name = Latin2GBK(model.led_name);
                //model.led_area = Latin2GBK(model.led_area);
                conn.Close();
                return list;
            }


        }

        public void AddRoad(Entity.Road model)
        {
            using (MySqlConnection conn = DapperService.MySqlConnection())
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into road(");
                strSql.Append("r_id,r_name,picPath,IsCreatePicture,r_width,eld_pictureWidth,eld_pictureHeight,eld_regionWidth,eld_regionHeight,eld_rmtHost,IsConnectELD,locPort,rmtPort,Remark,displayType,area,IsDownloadPicture,status");
                strSql.Append(")");
                strSql.Append(" values (");
                strSql.Append("" + model.r_id + ",");
                strSql.Append("'" + model.r_name + "',");
                strSql.Append("'" + model.picPath + "',");
                strSql.Append("" + model.IsCreatePicture + ",");
                strSql.Append("" + model.r_width + ",");
                strSql.Append("" + model.eld_pictureWidth + ",");
                strSql.Append("" + model.eld_pictureHeight + ",");
                strSql.Append("" + model.eld_regionWidth + ",");
                strSql.Append("" + model.eld_regionHeight + ",");
                strSql.Append("'" + model.eld_rmtHost + "',");
                strSql.Append("" + model.IsConnectELD + ",");
                strSql.Append("" + model.locPort + ",");
                strSql.Append("" + model.rmtPort + ",");
                strSql.Append("'" + model.Remark + "',");
                strSql.Append("" + model.displayType + ",");
                strSql.Append("'" + model.area + "',");
                strSql.Append("" + model.IsDownloadPicture + ",");
                strSql.Append("" + model.status + "");
                strSql.Append(")");
                MySqlCommand cmd = conn.CreateCommand();
                int rows = conn.Execute(strSql.ToString());
                conn.Close();
           
            }
              
        }
        #endregion

        #region roadDetail
        public List<Entity.RoadDetail> GetRoadDetailList(int r_id)
        {
            using (MySqlConnection conn = DapperService.MySqlConnection())
            {
                string sqlCommandText = @" select * from roaddetail  where r_id =" + r_id;

                List<Entity.RoadDetail> list = conn.Query<Entity.RoadDetail>(sqlCommandText).AsList<Entity.RoadDetail>();
                //model.led_name = Latin2GBK(model.led_name);
                //model.led_area = Latin2GBK(model.led_area);
                conn.Close();
                return list;
            }
        }
        #endregion
    }
}