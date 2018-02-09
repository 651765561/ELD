using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace ELDWebService_v2._0.BusinessLogic
{
    public class region
    {
        string sqlConnectionString = ConfigurationManager.ConnectionStrings["WServiceSqlConnString"].ToString();

        #region 自定义方法
        /// <summary>
        /// 获取分区信息
        /// </summary>
        /// <param name="eldIp">IP</param>
        /// <returns></returns>
        public List<Entity.region> Search(string eldIp)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  * from region   where  1=1 ");
            if (eldIp != "")
            {
                strSql.Append(" and ELD_IP like '%" + eldIp + "%'");
            }
            DataTable dt = Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0];
            var list = ConvertToList(dt);
            return list;
        }

        private List<Entity.region> ConvertToList(DataTable dt)
        {
            List<Entity.region> list = new List<Entity.region>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var r = dt.Rows[i];
                var m = DataRowToModel(r);
                list.Add(m);

            }
            return list;
        }
        #endregion

        #region 基础方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByELD_IP(string eldIp)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from region");
            strSql.Append(" where ELD_IP='" + eldIp + "'");
            int rows = int.Parse(Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0].Rows[0][0].ToString());
            return rows > 0;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByELD_IP(string eldIp, string regionType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from region");
            strSql.Append(" where ELD_IP='" + eldIp + "' and  Region_Type=" + regionType);
            int rows = int.Parse(Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0].Rows[0][0].ToString());
            return rows > 0;
        }
        public Entity.region GetModel(string eldIp)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from region where ELD_IP='" + eldIp + "' ");
            Entity.region model = new Entity.region();
            DataSet ds = Tools.getDataSet(strSql.ToString(), sqlConnectionString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.region DataRowToModel(DataRow row)
        {
            Entity.region model = new Entity.region();
            if (row != null)
            {
                if (row["seq"] != null && row["seq"].ToString() != "")
                {
                    model.seq = int.Parse(row["seq"].ToString());
                }
                if (row["Region_Index"] != null && row["Region_Index"].ToString() != "")
                {
                    model.Region_Index = int.Parse(row["Region_Index"].ToString());
                }
                if (row["road_id"] != null && row["road_id"].ToString() != "")
                {
                    model.road_id = int.Parse(row["road_id"].ToString());
                }
                if (row["left"] != null && row["left"].ToString() != "")
                {
                    model.left = int.Parse(row["left"].ToString());
                }
                if (row["top"] != null && row["top"].ToString() != "")
                {
                    model.top = int.Parse(row["top"].ToString());
                }
                if (row["width"] != null && row["width"].ToString() != "")
                {
                    model.width = int.Parse(row["width"].ToString());
                }
                if (row["height"] != null && row["height"].ToString() != "")
                {
                    model.height = int.Parse(row["height"].ToString());
                }
                if (row["border"] != null && row["border"].ToString() != "")
                {
                    model.border = int.Parse(row["border"].ToString());
                }
                if (row["Region_Type"] != null && row["Region_Type"].ToString() != "")
                {
                    model.Region_Type = int.Parse(row["Region_Type"].ToString());
                }
                if (row["ELD_IP"] != null)
                {
                    model.ELD_IP = row["ELD_IP"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.region model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update region set ");
            if (model.Region_Index != null)
            {
                strSql.Append("Region_Index=" + model.Region_Index + ",");
            }
            if (model.road_id != null)
            {
                strSql.Append("road_id=" + model.road_id + ",");
            }
            else
            {
                strSql.Append("road_id= null ,");
            }
            if (model.left != null)
            {
                strSql.Append("[left]=" + model.left + ",");
            }
            else
            {
                strSql.Append("[left]= null ,");
            }
            if (model.top != null)
            {
                strSql.Append("[top]=" + model.top + ",");
            }
            else
            {
                strSql.Append("[top]= null ,");
            }
            if (model.width != null)
            {
                strSql.Append("width=" + model.width + ",");
            }
            else
            {
                strSql.Append("width= null ,");
            }
            if (model.height != null)
            {
                strSql.Append("height=" + model.height + ",");
            }
            else
            {
                strSql.Append("height= null ,");
            }
            if (model.border != null)
            {
                strSql.Append("border=" + model.border + ",");
            }
            else
            {
                strSql.Append("border= null ,");
            }
            if (model.Region_Type != null)
            {
                strSql.Append("Region_Type=" + model.Region_Type + ",");
            }
            else
            {
                strSql.Append("Region_Type= null ,");
            }
            if (model.ELD_IP != null)
            {
                strSql.Append("ELD_IP='" + model.ELD_IP + "',");
            }
            else
            {
                strSql.Append("ELD_IP= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where seq=" + model.seq + "");
            int rowsAffected = Tools.ExecuteSql(strSql.ToString(), sqlConnectionString);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;

        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.region model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.Region_Index != null)
            {
                strSql1.Append("Region_Index,");
                strSql2.Append("" + model.Region_Index + ",");
            }
            if (model.road_id != null)
            {
                strSql1.Append("road_id,");
                strSql2.Append("" + model.road_id + ",");
            }
            if (model.left != null)
            {
                strSql1.Append("[left],");
                strSql2.Append("" + model.left + ",");
            }
            if (model.top != null)
            {
                strSql1.Append("[top],");
                strSql2.Append("" + model.top + ",");
            }
            if (model.width != null)
            {
                strSql1.Append("width,");
                strSql2.Append("" + model.width + ",");
            }
            if (model.height != null)
            {
                strSql1.Append("height,");
                strSql2.Append("" + model.height + ",");
            }
            if (model.border != null)
            {
                strSql1.Append("border,");
                strSql2.Append("" + model.border + ",");
            }
            if (model.Region_Type != null)
            {
                strSql1.Append("Region_Type,");
                strSql2.Append("" + model.Region_Type + ",");
            }
            if (model.ELD_IP != null)
            {
                strSql1.Append("ELD_IP,");
                strSql2.Append("'" + model.ELD_IP + "',");
            }
            strSql.Append("insert into region(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            int obj = Tools.ExecuteSql(strSql.ToString(), sqlConnectionString);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion


    }
}