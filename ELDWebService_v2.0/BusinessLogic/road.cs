using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace ELDWebService_v2._0.BusinessLogic
{
    public class road
    {
        string sqlConnectionString = ConfigurationManager.ConnectionStrings["WServiceSqlConnString"].ToString();
        #region 自定义方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eldRmtHost">显示器IP</param>
        /// <returns></returns>
        public bool DeleteByIp(string eldRmtHost)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from road ");
            strSql.Append(" where eld_rmtHost=" + eldRmtHost + "");
            int rowsAffected = Tools.ExecuteSql(strSql.ToString(), sqlConnectionString);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rName">路口名</param>
        /// <returns></returns>
        public bool DeleteByRoadName(string rName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from road ");
            strSql.Append(" where r_name=" + rName + "");
            int rowsAffected = Tools.ExecuteSql(strSql.ToString(), sqlConnectionString);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="rName"> 路口名</param>
        /// <param name="eldRmtHost">ip</param>
        /// <returns></returns>
        public List<Entity.Road> Search(string rName, string eldRmtHost)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  * from road   where  1=1 ");
            if (rName.Trim() != "")
            {
                strSql.Append(" and r_name like '%" + rName + "%'");
            }
            if (eldRmtHost.Trim() != "")
            {
                strSql.Append(" eld_rmtHost='" + eldRmtHost + "' ");
            }
            DataTable dt = Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0];
            var list = ConvertToList(dt);
            return list;
        }
        public List<Entity.Road> Search(string rName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  * from road   where  1=1 ");
            if (rName != "")
            {
                strSql.Append(" and r_name like '%" + rName + "%'");
            }
            DataTable dt = Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0];
            var list = ConvertToList(dt);
            return list;
        }
        public DataTable GetDataTable(string strSql)
        {
            DataTable dt = Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0];
            return dt;
        }

        public DataTable GetDataTableII(string strSql, string sqlConnectionString)
        {
            DataTable dt = Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0];
            return dt;
        }

        public List<Entity.Road> Search(int displayType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  * from road   where  displayType= " + displayType);

            DataTable dt = Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0];
            var list = ConvertToList(dt);
            return list;
        }
        private List<Entity.Road> ConvertToList(DataTable dt)
        {
            List<Entity.Road> list = new List<Entity.Road>();
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
        /// <param name="eldRmtHost"></param>
        /// <returns></returns>
        public bool Exists(string eldRmtHost)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from road");
            strSql.Append(" where  eld_rmtHost='" + eldRmtHost + "'");
            int rows = int.Parse(Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0].Rows[0][0].ToString());
            return rows > 0;
            // return DbHelperSQL.Exists(strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Road GetModel(int r_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" r_id,r_name,picPath,IsCreatePicture,r_width,eld_pictureWidth,eld_pictureHeight,eld_regionWidth,eld_regionHeight,eld_rmtHost,IsConnectELD,locPort,rmtHost,Remark,displayType,area,status ");
            strSql.Append(" from road ");
            strSql.Append(" where r_id=" + r_id + "");
            Entity.Road model = new Entity.Road();
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Entity.Road model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update road set ");
            if (model.r_name != null)
            {
                strSql.Append("r_name='" + model.r_name + "',");
            }
            else
            {
                strSql.Append("r_name= null ,");
            }
            if (model.picPath != null)
            {
                strSql.Append("picPath='" + model.picPath + "',");
            }
            else
            {
                strSql.Append("picPath= null ,");
            }
            if (model.IsCreatePicture != null)
            {
                strSql.Append("IsCreatePicture=" + (model.IsCreatePicture ? 1 : 0) + ",");
            }
            if (model.r_width != null)
            {
                strSql.Append("r_width=" + model.r_width + ",");
            }
            else
            {
                strSql.Append("r_width= null ,");
            }
            if (model.eld_pictureWidth != null)
            {
                strSql.Append("eld_pictureWidth=" + model.eld_pictureWidth + ",");
            }
            else
            {
                strSql.Append("eld_pictureWidth= null ,");
            }
            if (model.eld_pictureHeight != null)
            {
                strSql.Append("eld_pictureHeight=" + model.eld_pictureHeight + ",");
            }
            else
            {
                strSql.Append("eld_pictureHeight= null ,");
            }
            if (model.eld_regionWidth != null)
            {
                strSql.Append("eld_regionWidth=" + model.eld_regionWidth + ",");
            }
            else
            {
                strSql.Append("eld_regionWidth= null ,");
            }
            if (model.eld_regionHeight != null)
            {
                strSql.Append("eld_regionHeight=" + model.eld_regionHeight + ",");
            }
            else
            {
                strSql.Append("eld_regionHeight= null ,");
            }
            if (model.eld_rmtHost != null)
            {
                strSql.Append("eld_rmtHost='" + model.eld_rmtHost + "',");
            }
            else
            {
                strSql.Append("eld_rmtHost= null ,");
            }
            if (model.IsConnectELD != null)
            {
                strSql.Append("IsConnectELD=" + (model.IsConnectELD ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("IsConnectELD= null ,");
            }
            if (model.locPort != null)
            {
                strSql.Append("locPort=" + model.locPort + ",");
            }
            else
            {
                strSql.Append("locPort= null ,");
            }
            if (model.rmtPort != null)
            {
                strSql.Append("rmtPort=" + model.rmtPort + ",");
            }
            else
            {
                strSql.Append("rmtPort= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.displayType != null)
            {
                strSql.Append("displayType=" + model.displayType + ",");
            }
            else
            {
                strSql.Append("displayType= null ,");
            }
            if (model.area != null)
            {
                strSql.Append("area='" + model.area + "',");
            }
            else
            {
                strSql.Append("area= null ,");
            }
            if (model.status != null)
            {
                strSql.Append("status=" + model.status + ",");
            }
            else
            {
                strSql.Append("status= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where r_id=" + model.r_id + "");
            int rowsAffected = Tools.ExecuteSql(strSql.ToString(), sqlConnectionString);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateByIp(Entity.Road model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update road set ");
            if (model.r_name != null)
            {
                strSql.Append("r_name='" + model.r_name + "',");
            }
            else
            {
                strSql.Append("r_name= null ,");
            }
            if (model.picPath != null)
            {
                strSql.Append("picPath='" + model.picPath + "',");
            }
            else
            {
                strSql.Append("picPath= null ,");
            }
            if (model.IsCreatePicture != null)
            {
                strSql.Append("IsCreatePicture=" + (model.IsCreatePicture ? 1 : 0) + ",");
            }
            if (model.r_width != null)
            {
                strSql.Append("r_width=" + model.r_width + ",");
            }
            else
            {
                strSql.Append("r_width= null ,");
            }
            if (model.eld_pictureWidth != null)
            {
                strSql.Append("eld_pictureWidth=" + model.eld_pictureWidth + ",");
            }
            else
            {
                strSql.Append("eld_pictureWidth= null ,");
            }
            if (model.eld_pictureHeight != null)
            {
                strSql.Append("eld_pictureHeight=" + model.eld_pictureHeight + ",");
            }
            else
            {
                strSql.Append("eld_pictureHeight= null ,");
            }
            if (model.eld_regionWidth != null)
            {
                strSql.Append("eld_regionWidth=" + model.eld_regionWidth + ",");
            }
            else
            {
                strSql.Append("eld_regionWidth= null ,");
            }
            if (model.eld_regionHeight != null)
            {
                strSql.Append("eld_regionHeight=" + model.eld_regionHeight + ",");
            }
            else
            {
                strSql.Append("eld_regionHeight= null ,");
            }
            if (model.eld_rmtHost != null)
            {
                strSql.Append("eld_rmtHost='" + model.eld_rmtHost + "',");
            }
            else
            {
                strSql.Append("eld_rmtHost= null ,");
            }
            if (model.IsConnectELD != null)
            {
                strSql.Append("IsConnectELD=" + (model.IsConnectELD ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("IsConnectELD= null ,");
            }
            if (model.locPort != null)
            {
                strSql.Append("locPort=" + model.locPort + ",");
            }
            else
            {
                strSql.Append("locPort= null ,");
            }
            if (model.rmtPort != null)
            {
                strSql.Append("rmtPort=" + model.rmtPort + ",");
            }
            else
            {
                strSql.Append("rmtPort= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.displayType != null)
            {
                strSql.Append("displayType=" + model.displayType + ",");
            }
            else
            {
                strSql.Append("displayType= null ,");
            }
            if (model.area != null)
            {
                strSql.Append("area='" + model.area + "',");
            }
            else
            {
                strSql.Append("area= null ,");
            }

            if (model.IsDownloadPicture != null)
            {
                strSql.Append("IsDownloadPicture=" + (model.IsDownloadPicture ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("IsDownloadPicture= null ,");
            }

            if (model.status != null)
            {
                strSql.Append("status=" + model.status + ",");
            }
            else
            {
                strSql.Append("status= null ,");
            }

            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where eld_rmtHost='" + model.eld_rmtHost + "'");
            int rowsAffected = Tools.ExecuteSql(strSql.ToString(), sqlConnectionString);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eldRmtHost">IP</param>
        /// <returns></returns>
        public Entity.Road GetModelByeld_rmtHost(string eldRmtHost)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from road where eld_rmtHost='" + eldRmtHost + "' ");
            Entity.Road model = new Entity.Road();
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
        public Entity.Road DataRowToModel(DataRow row)
        {
            Entity.Road model = new Entity.Road();
            if (row != null)
            {
                if (row["r_id"] != null && row["r_id"].ToString() != "")
                {
                    model.r_id = int.Parse(row["r_id"].ToString());
                }
                if (row["r_name"] != null)
                {
                    model.r_name = row["r_name"].ToString();
                }
                if (row["picPath"] != null)
                {
                    model.picPath = row["picPath"].ToString();
                }
                if (row["IsCreatePicture"] != null && row["IsCreatePicture"].ToString() != "")
                {
                    if ((row["IsCreatePicture"].ToString() == "1") || (row["IsCreatePicture"].ToString().ToLower() == "true"))
                    {
                        model.IsCreatePicture = true;
                    }
                    else
                    {
                        model.IsCreatePicture = false;
                    }
                }
                if (row["r_width"] != null && row["r_width"].ToString() != "")
                {
                    model.r_width = decimal.Parse(row["r_width"].ToString());
                }
                if (row["eld_pictureWidth"] != null && row["eld_pictureWidth"].ToString() != "")
                {
                    model.eld_pictureWidth = int.Parse(row["eld_pictureWidth"].ToString());
                }
                if (row["eld_pictureHeight"] != null && row["eld_pictureHeight"].ToString() != "")
                {
                    model.eld_pictureHeight = int.Parse(row["eld_pictureHeight"].ToString());
                }
                if (row["eld_regionWidth"] != null && row["eld_regionWidth"].ToString() != "")
                {
                    model.eld_regionWidth = int.Parse(row["eld_regionWidth"].ToString());
                }
                if (row["eld_regionHeight"] != null && row["eld_regionHeight"].ToString() != "")
                {
                    model.eld_regionHeight = int.Parse(row["eld_regionHeight"].ToString());
                }
                if (row["eld_rmtHost"] != null)
                {
                    model.eld_rmtHost = row["eld_rmtHost"].ToString();
                }
                if (row["IsConnectELD"] != null && row["IsConnectELD"].ToString() != "")
                {
                    if ((row["IsConnectELD"].ToString() == "1") || (row["IsConnectELD"].ToString().ToLower() == "true"))
                    {
                        model.IsConnectELD = true;
                    }
                    else
                    {
                        model.IsConnectELD = false;
                    }
                }
                if (row["locPort"] != null && row["locPort"].ToString() != "")
                {
                    model.locPort = int.Parse(row["locPort"].ToString());
                }
                if (row["rmtPort"] != null && row["rmtPort"].ToString() != "")
                {
                    model.rmtPort = int.Parse(row["rmtPort"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["displayType"] != null && row["displayType"].ToString() != "")
                {
                    model.displayType = int.Parse(row["displayType"].ToString());
                }
                if (row["area"] != null)
                {
                    model.area = row["area"].ToString();
                }

                if (row["IsDownloadPicture"] != null && row["IsDownloadPicture"].ToString() != "")
                {
                    if ((row["IsDownloadPicture"].ToString() == "1") || (row["IsDownloadPicture"].ToString().ToLower() == "true"))
                    {
                        model.IsDownloadPicture = true;
                    }
                    else
                    {
                        model.IsDownloadPicture = false;
                    }
                }

                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
            }
            return model;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.Road model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.r_id != null)
            {
                strSql1.Append("r_id,");
                strSql2.Append("" + model.r_id + ",");
            }
            if (model.r_name != null)
            {
                strSql1.Append("r_name,");
                strSql2.Append("'" + model.r_name + "',");
            }
            if (model.picPath != null)
            {
                strSql1.Append("picPath,");
                strSql2.Append("'" + model.picPath + "',");
            }
            if (model.IsCreatePicture != null)
            {
                strSql1.Append("IsCreatePicture,");
                strSql2.Append("" + (model.IsCreatePicture ? 1 : 0) + ",");
            }
            if (model.r_width != null)
            {
                strSql1.Append("r_width,");
                strSql2.Append("" + model.r_width + ",");
            }
            if (model.eld_pictureWidth != null)
            {
                strSql1.Append("eld_pictureWidth,");
                strSql2.Append("" + model.eld_pictureWidth + ",");
            }
            if (model.eld_pictureHeight != null)
            {
                strSql1.Append("eld_pictureHeight,");
                strSql2.Append("" + model.eld_pictureHeight + ",");
            }
            if (model.eld_regionWidth != null)
            {
                strSql1.Append("eld_regionWidth,");
                strSql2.Append("" + model.eld_regionWidth + ",");
            }
            if (model.eld_regionHeight != null)
            {
                strSql1.Append("eld_regionHeight,");
                strSql2.Append("" + model.eld_regionHeight + ",");
            }
            if (model.eld_rmtHost != null)
            {
                strSql1.Append("eld_rmtHost,");
                strSql2.Append("'" + model.eld_rmtHost + "',");
            }
            if (model.IsConnectELD != null)
            {
                strSql1.Append("IsConnectELD,");
                strSql2.Append("" + (model.IsConnectELD ? 1 : 0) + ",");
            }
            if (model.locPort != null)
            {
                strSql1.Append("locPort,");
                strSql2.Append("" + model.locPort + ",");
            }
            if (model.rmtPort != null)
            {
                strSql1.Append("rmtPort,");
                strSql2.Append("" + model.rmtPort + ",");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.displayType != null)
            {
                strSql1.Append("displayType,");
                strSql2.Append("" + model.displayType + ",");
            }
            if (model.area != null)
            {
                strSql1.Append("area,");
                strSql2.Append("'" + model.area + "',");
            }
            if (model.IsDownloadPicture != null)
            {
                strSql1.Append("IsDownloadPicture,");
                strSql2.Append("" + (model.IsDownloadPicture ? 1 : 0) + ",");
            }
            if (model.status != null)
            {
                strSql1.Append("status,");
                strSql2.Append("" + model.status + ",");
            }
            strSql.Append("insert into road(");
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

        public bool Delete(int rId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from road ");
            strSql.Append(" where r_id=" + rId + "");
            int rowsAffected = Tools.ExecuteSql(strSql.ToString(), sqlConnectionString);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}