using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Helper
{
    public class DbHelper
    {

        /// <summary>
        /// 流程驱动
        /// </summary>
        public System.Data.SqlClient.SqlConnection connActivity = new System.Data.SqlClient.SqlConnection() { ConnectionString = ConfigurationManager.AppSettings["ActivityConnecting"] };
        /// <summary>
        /// 门户系统
        /// </summary>
        public System.Data.SqlClient.SqlConnection connPortal = new System.Data.SqlClient.SqlConnection() { ConnectionString = ConfigurationManager.AppSettings["PortalConnecting"] };
        /// <summary>
        /// 研究院
        /// </summary>
        public System.Data.SqlClient.SqlConnection connlvElecCenter = new System.Data.SqlClient.SqlConnection() { ConnectionString = ConfigurationManager.AppSettings["lvElecCenterConnecting"] };
        /// <summary>
        /// 获取指定SQL的数据信息
        /// </summary>
        /// <param name="Sql">sql</param>
        /// <param name="conn">连接对象</param>
        /// <returns></returns>
        public DataSet GetDataSet(string Sql, SqlConnection conn)
        {
            DataSet ds = new DataSet();
            try
            {
                // 定义数据库连接
                //初始化连接字符串
                conn.Open();
                //添加命令，从数据库中得到数据
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sql;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
        public DataSet GetDataSet(string sql, SqlParameter[] pms, SqlConnection conn)
        {
            DataSet ds = new DataSet();
            try
            {
                // 定义数据库连接
                //初始化连接字符串
                conn.Open();
                //添加命令，从数据库中得到数据
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                if (pms != null)
                {

                    foreach (var item in pms)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
        /// <summary>
        /// 判断是否可以连接数据库
        /// 首先判断默认的连接字符则判断默认连接是否存在，若可用则判断默认连接是否可用，否则判断门户数据库是否可用
        /// </summary>
        /// <returns></returns>
        public bool IsConnectionOpen()
        {
            if (GlobalSwitch.defaultconn == null)
            {
                return IsConnection(connPortal);
            }
            else
            {
                return IsConnection(GlobalSwitch.defaultconn);
            }
        }
        private bool IsConnection(SqlConnection conn)
        {
            bool isConnection = false;
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    isConnection = true;
                }
            }
            catch
            {
                isConnection = false;

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return isConnection;
        }
    }
}
