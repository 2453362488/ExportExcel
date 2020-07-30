using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ExportExcel.common
{
    class MySqlUtil
    {
        /// <summary>
        /// 【字段】数据库连接字符串
        /// </summary>
        private string url = @"server=192.168.10.222,1433;database=wz2gj;user=sa;pwd=123456";

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public DataTable adapterFind(string sql)
        {
            MySqlConnection conn = new MySqlConnection(url);
            conn.Open(); //连接数据库
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable a = new DataTable();
            adapter.Fill(a);
            conn.Close();
            return a;
        }
    }
}
