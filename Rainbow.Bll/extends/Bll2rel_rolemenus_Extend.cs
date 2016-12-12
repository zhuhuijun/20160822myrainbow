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
        /// 用于菜单的字典
        /// </summary>
        private static Dictionary<string, string> dics = new Dictionary<string, string>();
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static Bll2rel_rolemenus()
        {
            List<sys_menu> menus = Bll2sys_menu.GetAll();
            foreach (sys_menu one in menus)
            {
                dics.Add(one.id, one.menuname);
            }
        }
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
                datas = new List<rel_rolemenus>();
                for (int i = 0; i < menuarr.Count(); i++)
                {
                    rel_rolemenus tmp = new rel_rolemenus()
                    {
                        roleid = roleid,
                        menuid = menuarr[i]
                    };
                    datas.Add(tmp);
                }
                flag = DalFactory.Createrel_rolemenus().SaveRoleMenu(datas, roleid);
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
        /// <summary>
        /// 根据角色id获得菜单
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <returns></returns>
        public static string CreateMenuByRoleId(string roleid)
        {
            List<sys_menu> rolemenus = DalFactory.Createsys_menu().GetMenuByRoleId(roleid);
            string menustr = CreateMenu(rolemenus);
            return menustr;
        }
        /// <summary>
        /// 获得生成的菜单
        /// </summary>
        /// <param name="rolemenus"></param>
        /// <returns></returns>
        private static string CreateMenu(List<sys_menu> rolemenus)
        {
            List<sys_menu> menus = Bll2sys_menu.GetAll();
            StringBuilder sb = new StringBuilder();
            if (rolemenus.Count > 0)
            {
                //获得一级菜单
                List<sys_menu> first = rolemenus.Where(g => g.pid == "0").ToList();
                foreach (sys_menu one in first)
                {
                    StringBuilder firststr = new StringBuilder();
                    firststr.Append("<li>");
                    firststr.AppendFormat(@"<a href='#'><i class='fa fa fa-flag'></i>
                    <span class='nav-label'>{0}</span><span class='fa arrow'></span></a>", one.menuname);
                    //获得一级菜单下的二级菜单
                    List<sys_menu> Seconds =
                        rolemenus.Where(g => g.pid == one.id).ToList();
                    if (Seconds.Count > 0)
                    {
                        StringBuilder secondstr = new StringBuilder();
                        secondstr.Append("<ul class='nav nav-second-level'>");
                        foreach (sys_menu two in Seconds)
                        {
                            string tmp = String.Format(@"<li> <a class='J_menuItem' href='../{1}/Index'><i class='fa fa-flag'></i> <span class='nav-label'>{0}</span></a>
                            </li>", two.menuname, two.urlaction);
                            secondstr.Append(tmp);
                        }
                        secondstr.Append("</ul>");
                        firststr.Append(secondstr);
                    }
                    firststr.Append("</li>");
                    sb.Append(firststr);
                }
            }

            return sb.ToString();
        }
        /// <summary>
        /// 获得菜单的名称可能导致菜单生成不全因为是静态的
        /// </summary>
        /// <param name="menuid"></param>
        /// <returns></returns>
        private static string GetMenuName(string menuid)
        {
            string menuname = String.Empty;
            foreach (KeyValuePair<string, string> one in dics)
            {
                if (one.Key == menuid)
                {
                    menuname = one.Value;
                    break;
                }
            }
            return menuname;
        }
        /// <summary>
        /// 
        /// 获得控制器和Action
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <returns></returns>
        public static List<rel_rolemenus> GetControllerAndActions(string roleid)
        {
            return DalFactory.Createrel_rolemenus().GetControllerAndActions(roleid);
        }
    }
}
