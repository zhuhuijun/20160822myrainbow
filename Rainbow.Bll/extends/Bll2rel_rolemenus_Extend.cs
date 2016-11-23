using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rainbow.IDal;
using Rainbow.Models;

namespace Rainbow.Bll
{
    public partial class Bll2rel_rolemenus
    {
        /// <summary>
        /// 保存角色的菜单
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <param name="menuids">菜单id</param>
        /// <returns></returns>
        public static bool SaveRoleMenu(string roleid, string menuids)
        {
            List<rel_rolemenus> datas = null;
            bool flag = false;
            menuids = menuids.Remove(menuids.Length - 1, 1);
            string[] menuarr = menuids.Split(',');
            if (menuarr.Any())
            {
                datas=new List<rel_rolemenus>();
                for (int i = 0; i < menuarr.Count(); i++)
                {
                    rel_rolemenus tmp=new rel_rolemenus()
                    {
                        roleid = roleid,
                        menuid = menuarr[i]
                    };
                    datas.Add(tmp);
                }
                flag = DalFactory.Createrel_rolemenus().SaveRoleMenu(datas,roleid);
            }
            return flag;
        }
        /// <summary>
        /// 删除角色和角色下的关联数据
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public static bool DeleteRole(string roleid)
        {
            return DalFactory.Createrel_rolemenus().DeleteRole(roleid);
        }
    }
}
