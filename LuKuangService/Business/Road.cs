using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuKuangService.Business
{
    public class Road
    {
        string sqlConnectionString = ConfigurationManager.ConnectionStrings["WServiceSqlConnString"].ToString();
        public Road()
        { }

        #region 自定义方法

        public List<LuKuangService.Entity.Road> Search(string rName)
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

        private List<LuKuangService.Entity.Road> ConvertToList(DataTable dt)
        {
            List<LuKuangService.Entity.Road> list = new List<LuKuangService.Entity.Road>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var r = dt.Rows[i];
                var m = DataRowToModel(r);
                list.Add(m);

            }
            return list;
        }
        #endregion
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int r_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from road");
            strSql.Append(" where r_id=SQL2012r_id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012r_id", SqlDbType.Int,4)
            };
            parameters[0].Value = r_id;

            int rows = int.Parse(Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0].Rows[0][0].ToString());
            return rows > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LuKuangService.Entity.Road model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into road(");
            strSql.Append("r_name)");
            strSql.Append(" values (");
            strSql.Append("SQL2012r_name)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012r_name", SqlDbType.VarChar,50)};
            parameters[0].Value = model.r_name;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(LuKuangService.Entity.Road model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update road set ");
            strSql.Append("r_name=SQL2012r_name");
            strSql.Append(" where r_id=SQL2012r_id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012r_name", SqlDbType.VarChar,50),
                    new SqlParameter("SQL2012r_id", SqlDbType.Int,4)};
            parameters[0].Value = model.r_name;
            parameters[1].Value = model.r_id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int r_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from road ");
            strSql.Append(" where r_id=SQL2012r_id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012r_id", SqlDbType.Int,4)
            };
            parameters[0].Value = r_id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string r_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from road ");
            strSql.Append(" where r_id in (" + r_idlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public LuKuangService.Entity.Road GetModel(int r_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *  from road ");
            strSql.Append(" where r_id=" + r_id);


            LuKuangService.Entity.Road model = new LuKuangService.Entity.Road();

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
        public LuKuangService.Entity.Road DataRowToModel(DataRow row)
        {
            LuKuangService.Entity.Road model = new LuKuangService.Entity.Road();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select r_id,r_name ");
            strSql.Append(" FROM road ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = Tools.getDataSet(strSql.ToString(), sqlConnectionString);
            return ds;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" r_id,r_name ");
            strSql.Append(" FROM road ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return Tools.getDataSet(strSql.ToString(), sqlConnectionString);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM road ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            var ds = Tools.getDataSet(strSql.ToString(), sqlConnectionString);
            object obj = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                obj = ds.Tables[0].Rows[0][0];
            }
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.r_id desc");
            }
            strSql.Append(")AS Row, T.*  from road T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return Tools.getDataSet(strSql.ToString(), sqlConnectionString);
        }
        #endregion  BasicMethod
    }
}
