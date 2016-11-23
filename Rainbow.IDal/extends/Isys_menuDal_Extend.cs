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
        /// <summary>
        /// 保存菜单关联的行为
        /// </summary>
        /// <param name="menuid">菜单的id</param>
        /// <param name="actionid">行为的id</param>
        /// <returns></returns>
        bool SaveMenuAction(string menuid, List<string> actionid);
    }
}
