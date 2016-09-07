using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow.Dal
{
    /// <summary>
    /// DbBase
    /// </summary>
    public class DbBase
    {
        public SqlConnection DbConnection = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="conn"></param>
        public DbBase(string conn)
        {
            DbConnection = new SqlConnection(conn);
        }
    }
}
