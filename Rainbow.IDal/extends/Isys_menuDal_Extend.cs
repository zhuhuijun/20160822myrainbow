using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Rainbow.Models;

namespace Rainbow.IDal
{
    public partial interface Isys_menuDal
    {
        /// <summary>
        /// 条件查询的方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        List<sys_menu> GetAllWhere(string sql);
    }
}
