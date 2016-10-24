using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Rainbow.Models;

namespace Rainbow.Dal
{
    public partial class sys_menuDal
    {
        /// <summary>
        /// 条件查询的方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<sys_menu> GetAllWhere(string sql)
        {
            using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                return sqlConnection.Query<sys_menu>("SELECT * FROM sys_menu WHERE " + sql).ToList();
            }
        }
    }
}
