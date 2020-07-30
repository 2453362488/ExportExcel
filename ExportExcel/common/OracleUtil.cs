using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ExportExcel.common
{
    class OracleUtil
    {
        /// <summary>
        /// 【字段】数据库连接字符串
        /// </summary>
        private string url = @"User Id=admin;Password=123;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.1)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=test)))";

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public DataTable adapterFind(string sql)
        {
            OracleConnection conn = new OracleConnection(url);
            conn.Open(); //连接数据库
            OracleDataAdapter adapter = new OracleDataAdapter(sql, conn);
            DataTable a = new DataTable();
            adapter.Fill(a);
            conn.Close();
            return a;
        }
    }
}
