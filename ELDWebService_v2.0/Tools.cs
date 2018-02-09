using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ELDWebService_v2._0
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Tools
    {


        #region '数据库操作方法

        /// <summary>
        /// 检查SqlServer库是否正常连接
        /// </summary>
        /// <param name="sqlConnectionString">SqlServer库连接字符串</param>
        /// <param name="ErrorMsgString">--返回的异常信息(返回""空表示正确无误)(out参数,不必赋初值)</param>
        /// <returns>true-连接正常;false-连接失败</returns>
        public static bool checkDbConnection(string sqlConnectionString, out string ErrorMsgString)
        {
            SqlConnection Conn = new SqlConnection(sqlConnectionString);
            bool blConn = false;

            try
            {
                if (Conn.State != ConnectionState.Open)
                    Conn.Open();
                blConn = true;
                ErrorMsgString = "";//--返回的异常信息(返回""空表示正确无误)
            }
            catch (Exception ex)
            {
                // return false;
                blConn = false;
                ErrorMsgString = "连接Sql数据库出现异常:【" + ex.Message + "】";
            }
            finally
            {
                if (Conn != null && Conn.State != ConnectionState.Closed)
                    Conn.Close();
            }
            return blConn;
        }


        /// <summary>
        /// 保存数据到临时数据库表中（新增记录）
        /// </summary>
        /// <param name="sqlConnectionString">Sql数据库连接字符串</param>
        /// <param name="dt">数据表</param>
        /// <param name="ReturnMsgString">--返回结果信息(out参数,不必赋初值)(返回空值""表示正常)</param>
        public static void SaveDataToDatabase(string sqlConnectionString, DataTable dt, out string ReturnMsgString)
        {
            if (string.IsNullOrEmpty(sqlConnectionString))
            {
                //连接数据库字符串值不能为空！
                ReturnMsgString = "连接数据库字符串值不能为空!";
                return;
            }
            if (dt != null && dt.Rows.Count > 0)
            {

                // OleDbConnection conn = null;
                // OleDbTransaction tran = null;
                // OleDbCommand cmd = null;

                SqlConnection conn = null;
                SqlTransaction tran = null;
                SqlCommand cmd = null;

                try
                {
                    // conn = new OleDbConnection(connectionString);
                    conn = new SqlConnection(sqlConnectionString);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    tran = conn.BeginTransaction();//事物开始
                    DataColumnCollection columns = dt.Columns;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        StringBuilder sqlBuilder = new StringBuilder();
                        sqlBuilder.Append("insert into " + dt.TableName + " ");
                        //检索列
                        sqlBuilder.Append("(");
                        for (int n = 0; n < columns.Count; n++)
                        {
                            DataColumn col = columns[n];
                            sqlBuilder.Append(col.ColumnName);
                            if (n < columns.Count - 1)
                            {
                                sqlBuilder.Append(",");
                            }
                        }
                        sqlBuilder.Append(") ");
                        //设置参数
                        sqlBuilder.Append("values (");
                        for (int n = 0; n < columns.Count; n++)
                        {
                            DataColumn col = columns[n];
                            sqlBuilder.Append("@" + col.ColumnName);
                            if (n < columns.Count - 1)
                            {
                                sqlBuilder.Append(",");
                            }
                        }
                        sqlBuilder.Append(") ");

                        // cmd = new OleDbCommand(sqlBuilder.ToString(), conn);
                        cmd = new SqlCommand(sqlBuilder.ToString(), conn);

                        //设置参数
                        for (int n = 0; n < columns.Count; n++)
                        {
                            DataColumn col = columns[n];
                            switch (col.DataType.Name)
                            {
                                case "String"://OleDbType.VarChar
                                    cmd.Parameters.AddWithValue("@" + col.ColumnName, row[col.ColumnName].ToString());
                                    break;
                                case "Boolean"://OleDbType.Boolean
                                    cmd.Parameters.AddWithValue("@" + col.ColumnName, row[col.ColumnName]);
                                    break;
                                case "DateTime"://OleDbType.Date
                                    cmd.Parameters.AddWithValue("@" + col.ColumnName, row[col.ColumnName].ToString());
                                    break;
                                case "Object[]"://OleDbType.Binary
                                    object[] objs = row[col.ColumnName] as object[];
                                    byte[] bytes = new byte[objs.Length];
                                    for (int j = 0; j < objs.Length; j++)
                                    {
                                        byte b = Convert.ToByte(objs[j]);
                                        bytes[j] = b;
                                    }
                                    cmd.Parameters.AddWithValue("@" + col.ColumnName, bytes);
                                    break;
                                default://OleDbType.Integer；OleDbType.Decimal。
                                    cmd.Parameters.AddWithValue("@" + col.ColumnName, row[col.ColumnName]);
                                    break;
                            }
                        }

                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();//事物提交
                    ReturnMsgString = "";//返回空值""表示正确无误
                }
                catch (Exception ex)
                {
                    ReturnMsgString = ex.Message;
                    tran.Rollback();//事物回滚
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                    if (cmd != null)
                        cmd.Dispose();
                    if (tran != null)
                        tran.Dispose();
                }
            }
            else
            {
                //连接数据库字符串值不能为空！
                ReturnMsgString = "数据表无记录!";
            }

        }


        #endregion


        #region  '执行简单SQL语句

        /// <summary>
        /// 取得查询结果的第一行第一列数据
        /// </summary>
        /// <param name="sql">select语句</param>
        /// <returns></returns>
        public static object GetExecuteScalar(string sql, string sqlConnectionString)
        {
            object obj = null;
            if (!string.IsNullOrEmpty(sql))
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = null;
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        cmd = new SqlCommand(sql, conn);
                        obj = cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cmd != null)
                            cmd.Dispose();
                        //if (conn != null)
                        //    conn.Close();
                    }
                }
            }
            return obj;
        }


        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="strSelectSql">查询语句</param>
        /// <param name="sqlConnectionString">SQL Server数据库连接字符串</param>
        /// <returns>DataSet</returns>
        public static DataSet getDataSet(string strSelectSql, string sqlConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    //connection.Close();
                    // connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(strSelectSql, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }


        /// <summary>
        /// 执行【增删改】SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="strExecSql">增删改ExecSQL语句</param>
        /// <param name="sqlConnectionString">SqlServer数据库连接字符串</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string strExecSql, string sqlConnectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(strExecSql, connection))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // connection.Close();
                throw ex;
                // return -1;
            }
        }

        #endregion



        #region '存储过程操作

        /// <summary>
        /// 执行存储过程,取得数据集
        /// </summary>
        /// <param name="sqlConnectionString">SqlServer数据库连接字符串</param>
        /// <param name="storedProcName">存储过程名(必填)</param>
        /// <param name="parameters">存储过程参数(可null)</param>
        /// <param name="tableName">DataSet结果中的表名(必填!)</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string sqlConnectionString, string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                //  connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="sqlConnectionString">SqlServer数据库连接字符串</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数(可null)</param>
        /// <param name="rowsAffected">影响的行数(out参数,不必赋初值)</param>
        /// <returns></returns>
        public static int RunProcedure(string sqlConnectionString, string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    int result;
                    connection.Open();
                    SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                    rowsAffected = command.ExecuteNonQuery();
                    result = (int)command.Parameters["ReturnValue"].Value;
                    //Connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数(可空null)</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.
                        if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                            (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        command.Parameters.Add(parameter);
                    }
                }
            }

            return command;
        }

        #endregion


        #region '公共方法

        /// <summary>
        /// 判断一个字符串是否是整数(即:负整数+自然数)的字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>是则返回true，否则返回false</returns>
        public static bool IsInteger(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }


        //------------------------------------------------------------------------
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="strExpression">字符串</param>
        /// <returns></returns>
        //------------------------------------------------------------------------
        public static bool IsNumeric(string strExpression)
        {
            if (strExpression == null || strExpression.Length == 0)
                return false;
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(strExpression);
            foreach (byte c in bytestr)
            {
                if (c < 48 || c > 57)
                    return false;
            }
            return true;
        }

        //------------------------------------------------------------------------
        /// <summary>
        /// 判断输入是否为日期类型
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        //------------------------------------------------------------------------
        public static bool IsDateTime(string str)
        {
            if (str == null)
                return false;
            else
            {
                try
                {
                    DateTime d = DateTime.Parse(str);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion



        #region '导出到Excel文件中

        /// <summary>
        ///  导出DataTable数据到Excel文件中
        /// </summary>
        /// <param name="dt">表数据</param>
        /// <param name="file">文件的绝对路径名(如"E:\Data\Excel\dd.xls")</param>      
        /// <param name="strErrorMsg">返回异常信息(空""表示正常)(out参数,不必赋初值)</param>
        /// <returns>返回执行成功与否(true/false)</returns>
        public static bool dataTableToCsv(System.Data.DataTable dt, string file, out string strErrorMsg)
        {
            //http://www.douban.com/note/240083972/


            try
            {
                string title = "";
                FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
                //FileStream fs1 = File.Open(file, FileMode.Open, FileAccess.Read);
                StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    title += dt.Columns[i].ColumnName + "\t"; //栏位：自动跳到下一单元格
                }

                title = title.Substring(0, title.Length - 1) + "\n";
                sw.Write(title);

                string line = "";
                foreach (DataRow row in dt.Rows)
                {
                    line = "";
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        line += row[i].ToString().Trim() + "\t"; //内容：自动跳到下一单元格
                    }

                    line = line.Substring(0, line.Length - 1) + "\n";
                    sw.Write(line);
                }
                sw.Close();
                fs.Close();

                strErrorMsg = "";//空""表示正常
                return true;
            }
            catch (Exception ex)
            {
                strErrorMsg = ex.Message;
                return false;
            }
            //dataTableToCsv(dt, @"c:\1.xls"); //调用函数
            //System.Diagnostics.Process.Start(@"c:\1.xls"); //打开excel文件

        }

        #endregion




        #region '写日志

        /// <summary>
        /// 添加日志记录到EMC系统的SqlServer库表[log_EmcService] 方法
        /// </summary>
        /// <param name="FLogName">日志名称(不含日期yyyy-MM-dd)</param>
        /// <param name="FType">日志类型(1-普通,2-提醒;3-警告;4-严重)</param>
        /// <param name="FMessage">日志内容</param>
        /// <param name="sqlConnectionString">sqlServer数据库连接字符串</param>
        public static void AddLog(string FLogSource, string FLogName, int FType, string FMessage, string sqlConnectionString)
        {
            //  FLogName = FLogName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-dd");

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" INSERT INTO [log_EmcService] ");
            sbSql.Append(" ( [FLogSource],[FLogName],[FType],[FMessage],[FLogTime] ) ");
            sbSql.Append(" VALUES ( ");

            if (FLogSource.Trim() != "")
                sbSql.Append(" N'" + FLogSource.Trim() + "',");
            else
                sbSql.Append(" N'Service',");

            if (FLogName.Trim() != "")
                sbSql.Append(" N'" + FLogName.Trim() + "_" + DateTime.Now.ToString("yyyy-MM-dd") + "',");
            else
                sbSql.Append(" N'Server_" + DateTime.Now.ToString("yyyy-MM-dd") + "',");

            sbSql.Append("" + FType + ",");

            FMessage = FMessage.Replace("'", " ");
            FMessage = FMessage.Replace(",", "，");//半角,转为全角，
            FMessage = FMessage.Replace("[", "(");
            FMessage = FMessage.Replace("]", ")");
            FMessage = FMessage.Replace("{", "(");
            FMessage = FMessage.Replace("}", ")");

            FMessage = FMessage.Replace(":", " ");
            FMessage = FMessage.Replace("/", " ");
            //FMessage = FMessage.Replace("\r", " ");
            //FMessage = FMessage.Replace("\n", " ");
            //FMessage = FMessage.Replace(@"\", "、");


            FMessage = Regex.Replace(FMessage, @"[\n\r]", " ");//字符串里所有的的换行符都去掉
            FMessage = FMessage.TrimEnd((char[])"\n\r".ToCharArray()); //去掉末尾的换行符 

            FMessage = cleanString(FMessage);

            sbSql.Append(" N'" + FMessage.Trim() + "', ");
            sbSql.Append(" '" + DateTime.Now + "' ) ");


            string strSqlInsert = sbSql.ToString();

            // Tools.ExecuteSql(strSqlInsert, sqlConnectionString);

            ExecuteSql(strSqlInsert, sqlConnectionString);
        }



        /// <summary>
        /// string的replace函数替换掉这两个字符,每个字符的ASCII码，可以看出存在值分别为13、10的两个字符，造成换行
        /// </summary>
        /// <param name="newStr"></param>
        /// <returns></returns>
        private static string cleanString(string newStr)
        {
            string tempStr = newStr.Replace((char)13, (char)0);
            return tempStr.Replace((char)10, (char)0);
        }



        #endregion



    }
}