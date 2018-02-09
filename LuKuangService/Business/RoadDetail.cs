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
   public class RoadDetail
    {
        string sqlConnectionString = ConfigurationManager.ConnectionStrings["WServiceSqlConnString"].ToString();
        public RoadDetail()
        {
            
        }

        #region 自定义方法
        /// <summary>
        /// 路口编号
        /// </summary>
        /// <param name="r_id"></param>
        /// <returns></returns>
        public IList<LuKuangService.Entity.Partial.RoadDetail> SearchDetails(int r_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select r.r_name,r.picPath,r.r_width,d.* from road as r,  roaddetail as d  ");
            strSql.Append(" where r.r_id=d.r_id and r.r_id=" + r_id);
            DataTable dt = Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0];
            IList<LuKuangService.Entity.Partial.RoadDetail> list = new List<LuKuangService.Entity.Partial.RoadDetail>();
            list = ConvertToList(dt);
            return list;
        }
        public IList<LuKuangService.Entity.Partial.RoadDetail> SearchAll()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select r.r_name,r.picPath,r.r_width,d.* from road as r,  roaddetail as d  ");
            strSql.Append(" where r.r_id=d.r_id");
            DataTable dt = Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0];
            IList<LuKuangService.Entity.Partial.RoadDetail> list = new List<LuKuangService.Entity.Partial.RoadDetail>();
            list = ConvertToList(dt);
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rName">路口名称</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<LuKuangService.Entity.Partial.RoadDetail> SearchPagedList(string rName, int pageIndex, int pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select r.r_name,r.picPath,r.r_width,d.* from road as r,  roaddetail as d  ");
            strSql.Append(" where r.r_id=d.r_id ");
            if (rName != "")
            {
                strSql.Append(" and r.r_name like '%" + rName + "%'");
            }

            DataTable dt = Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0];
            var list = new List<LuKuangService.Entity.Partial.RoadDetail>();
            list = ConvertToList(dt).ToList();
            return new PagedList<LuKuangService.Entity.Partial.RoadDetail>(list, pageIndex, pageSize);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rName">路口名称</param>
        /// <returns></returns>
        public IList<LuKuangService.Entity.Partial.RoadDetail> Search(string rName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select r.r_name,r.picPath,d.* from road as r,  roaddetail as d  ");
            strSql.Append(" where r.r_id=d.r_id ");
            if (rName != "")
            {
                strSql.Append(" and r.r_name like '%" + rName + "%'");
            }

            DataTable dt = Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0];
            IList<LuKuangService.Entity.Partial.RoadDetail> list = new List<LuKuangService.Entity.Partial.RoadDetail>();
            list = ConvertToList(dt);
            return list;
        }
        private List<LuKuangService.Entity.Partial.RoadDetail> ConvertToList(DataTable td)
        {
            var dt = td;
            List<LuKuangService.Entity.Partial.RoadDetail> list = new List<LuKuangService.Entity.Partial.RoadDetail>();
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
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from roaddetail");
            strSql.Append(" where id=SQL2012id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            int rows = int.Parse(Tools.getDataSet(strSql.ToString(), sqlConnectionString).Tables[0].Rows[0][0].ToString());
            return rows > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LuKuangService.Entity.RoadDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into roaddetail(");
            strSql.Append("r_id,status,x1,y1,x2,y2,detailName,remark)");
            strSql.Append(" values (");
            strSql.Append("SQL2012r_id,SQL2012status,SQL2012x1,SQL2012y1,SQL2012x2,SQL2012y2,SQL2012detailName,SQL2012remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012r_id", SqlDbType.Int,4),
                    new SqlParameter("SQL2012status", SqlDbType.Int,4),
                    new SqlParameter("SQL2012picPath", SqlDbType.VarChar,120),
                    new SqlParameter("SQL2012x1", SqlDbType.VarChar,50),
                    new SqlParameter("SQL2012y1", SqlDbType.VarChar,50),
                    new SqlParameter("SQL2012x2", SqlDbType.VarChar,50),
                    new SqlParameter("SQL2012y2", SqlDbType.VarChar,50),
                    new SqlParameter("SQL2012detailName", SqlDbType.VarChar,50),
                    new SqlParameter("SQL2012remark", SqlDbType.VarChar,150)};
            parameters[0].Value = model.r_id;
            parameters[1].Value = model.status;

            parameters[3].Value = model.x1;
            parameters[4].Value = model.y1;
            parameters[5].Value = model.x2;
            parameters[6].Value = model.y2;
            parameters[7].Value = model.detailName;
            parameters[8].Value = model.remark;

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
        public bool Update(LuKuangService.Entity.RoadDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update roaddetail set ");
            strSql.Append("r_id=SQL2012r_id,");
            strSql.Append("status=SQL2012status,");
            strSql.Append("x1=SQL2012x1,");
            strSql.Append("y1=SQL2012y1,");
            strSql.Append("x2=SQL2012x2,");
            strSql.Append("y2=SQL2012y2,");
            strSql.Append("detailName=SQL2012detailName,");
            strSql.Append("remark=SQL2012remark");
            strSql.Append(" where id=SQL2012id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012r_id", SqlDbType.Int,4),
                    new SqlParameter("SQL2012status", SqlDbType.Int,4),
                    new SqlParameter("SQL2012x1", SqlDbType.VarChar,50),
                    new SqlParameter("SQL2012y1", SqlDbType.VarChar,50),
                    new SqlParameter("SQL2012x2", SqlDbType.VarChar,50),
                    new SqlParameter("SQL2012y2", SqlDbType.VarChar,50),
                    new SqlParameter("SQL2012detailName", SqlDbType.VarChar,50),
                    new SqlParameter("SQL2012remark", SqlDbType.VarChar,150),
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)};
            parameters[0].Value = model.r_id;
            parameters[1].Value = model.status;

            parameters[3].Value = model.x1;
            parameters[4].Value = model.y1;
            parameters[5].Value = model.x2;
            parameters[6].Value = model.y2;
            parameters[7].Value = model.detailName;
            parameters[8].Value = model.remark;
            parameters[9].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from roaddetail ");
            strSql.Append(" where id=SQL2012id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from roaddetail ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public LuKuangService.Entity.RoadDetail GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,r_id,status,picPath,x1,y1,x2,y2,detailName,remark from roaddetail ");
            strSql.Append(" where id=SQL2012id");
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            LuKuangService.Entity.RoadDetail model = new LuKuangService.Entity.RoadDetail();
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
        public LuKuangService.Entity.Partial.RoadDetail DataRowToModel(DataRow row)
        {
            LuKuangService.Entity.Partial.RoadDetail model = new LuKuangService.Entity.Partial.RoadDetail();
            if (row != null)
            {
                if (row.Table.Columns.Contains("RowNumber") && row["RowNumber"] != null &&
                      row["RowNumber"].ToString() != "")
                {
                    model.RowNumber = int.Parse(row["RowNumber"].ToString());
                }
                if (row.Table.Columns.Contains("r_width") && row["r_width"] != null &&
                     row["r_width"].ToString() != "")
                {
                    model.r_width = float.Parse(row["r_width"].ToString());
                }

                if (row.Table.Columns.Contains("isCreatePicture") && row["isCreatePicture"] != null && row["isCreatePicture"].ToString() != "")
                {
                    model.IsCreatePicture = bool.Parse(row["isCreatePicture"].ToString());
                }
                if (row.Table.Columns.Contains("r_name") && row["r_name"] != null && row["r_name"].ToString() != "")
                {
                    model.r_name = row["r_name"].ToString();
                }
                if (row.Table.Columns.Contains("picPath") && row["picPath"] != null && row["picPath"].ToString() != "")
                {
                    model.picPath = row["picPath"].ToString();
                }
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["r_id"] != null && row["r_id"].ToString() != "")
                {
                    model.r_id = int.Parse(row["r_id"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }

                if (row["x1"] != null)
                {
                    model.x1 = row["x1"].ToString();
                }
                if (row["y1"] != null)
                {
                    model.y1 = row["y1"].ToString();
                }
                if (row["x2"] != null)
                {
                    model.x2 = row["x2"].ToString();
                }
                if (row["y2"] != null)
                {
                    model.y2 = row["y2"].ToString();
                }
                if (row["detailName"] != null)
                {
                    model.detailName = row["detailName"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
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
            strSql.Append("select id,r_id,status,picPath,x1,y1,x2,y2,detailName,remark ");
            strSql.Append(" FROM roaddetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Tools.getDataSet(strSql.ToString(), sqlConnectionString); ;
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
            strSql.Append(" id,r_id,status,picPath,x1,y1,x2,y2,detailName,remark ");
            strSql.Append(" FROM roaddetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return Tools.getDataSet(strSql.ToString(), sqlConnectionString); ;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM roaddetail ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from roaddetail T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return Tools.getDataSet(strSql.ToString(), sqlConnectionString);
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012PageSize", SqlDbType.Int),
                    new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
                    new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
                    new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
                    new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "roadDetail";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
    }
}
