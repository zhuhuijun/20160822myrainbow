using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rainbow.Models;

namespace Rainbow.IDal
{
    /// <summary>
    /// 角色设置菜单的功能
    /// </summary>
    public partial interface Irel_rolemenusDal
    {
        /// <summary>
        /// 角色和菜单的关联数据
        /// </summary>
        /// <param name="rolemenus"></param>
        /// <param name="roleid">角色id</param>
        /// <returns></returns>
        bool SaveRoleMenu(List<rel_rolemenus> rolemenus,string roleid);
        /// <summary>
        /// 删除角色时需要将对应的菜单删除
        /// 提示是否有关联的用户
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        bool DeleteRole(string roleid);
        /// <summary>
        /// 获得控制器和角色
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        List<rel_rolemenus> GetControllerAndActions(string roleid);
    }
}
