using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ExportExcel.common
{
    /// <summary>
    /// 数据库库操作工具
    /// </summary>
    public class DBHelp
    {

        /// <summary>
        /// 【字段】数据库连接对象
        /// </summary>
        private SqlConnection conn;
        /// <summary>
        /// 【字段】数据库连接字符串
        /// </summary>
        private string url = @"Data Source=192.168.10.222,1433;Initial Catalog=wz2gj;User ID=sa;pwd=123456";
        /// <summary>
        /// 【字段】数据库执行SQl语句执行的对象
        /// </summary>
        private SqlCommand comm;
        /// <summary>
        /// 【字段】数据集
        /// </summary>
        private DataSet ds;
        /// <summary>
        /// 【字段】适配器：数据库离线执行SQl的对象
        /// </summary>
        private SqlDataAdapter adapter;

        public string Url {
            get { return url; }
            set { url = value; }
        }

        /// <summary>
        /// 【属性】 对象名.属性  默认会执行 get 或 set  
        ///  获取SqlCommand对象的时候 内部自动完成SqlCommand的构建
        /// </summary>
        public SqlCommand Command
        {
            get
            {
                //【ADO.Net】第三步构建SqlCommand 并且设置连接对象
                comm = new SqlCommand();
                comm.Connection = Connection;
                return comm;
            }
        }

        /// <summary>
        /// 【属性】 对象名.属性  默认会执行 get 或 set  
        ///  获取SqlConnection对象的时候 内部自动完成SqlConnection的构建
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                //【ADO.Net】第一步构建数据库连接对象 SqlConnection
                conn = new SqlConnection(url);
                //【ADO.Net】第二步开启数据库连接 Open
                conn.Open();
                return conn;
            }
        }

        /// <summary>
        /// 【离线查询的方法】使用 SqlDataAdapter 适配器执行离线查询吧结果加载到 DataSet 数据集中
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <returns></returns>
        public DataTable adapterFind(string sql)
        {
            /*
             * 【ADO.Net】第四步构建SqlDataAdapter实现离线查询
             * 设置执行的的SQL语句和执行SQL语句所需的SQlConnection
             */
            adapter = new SqlDataAdapter(sql, Connection);
            ds = new DataSet();
            adapter.Fill(ds, "a");

            /**
             * 【ADO.Net】第五步关闭数据连接
             * */
            conn.Close();
            return ds.Tables[0];
        }
    }
}
