using Dapper;
using ELDWebService_v2._0.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDWebService_v2._0.BusinessLogic
{
    public class DA
    {
        #region led 表

        #endregion

        #region road 数据信息
        /// <summary>
        /// 获取道路信息
        /// </summary>
        /// <returns></returns>
        public List<Entity.Road> GetRoadList()
        {
            using (IDbConnection conn = DapperService.SqlConnection())
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

        #endregion
        #region roadDetail
        public List<Entity.RoadDetail> GetRoadDetailList(int r_id)
        {
            using (IDbConnection conn = DapperService.SqlConnection())
            {
                string sqlCommandText = @" select * from roaddetail  where r_id =" + r_id;

                List < Entity.RoadDetail > list = conn.Query<Entity.RoadDetail>(sqlCommandText).AsList<Entity.RoadDetail>();
                //model.led_name = Latin2GBK(model.led_name);
                //model.led_area = Latin2GBK(model.led_area);
                conn.Close();
                return list;
            }
        }
        #endregion
    }
}
