using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rainbow.Commons;
using Rainbow.IDal;
using Rainbow.Models;

namespace Rainbow.Bll
{
    public partial class Bll2sys_menu
    {
        /// <summary>
        /// 树形结构使用的数据
        /// </summary>
        /// <returns></returns>
        public static List<sys_menu> GetAllForTree()
        {
            List<sys_menu> datas = new List<sys_menu>()
            {
                new sys_menu() {id="0",menuname = "顶级节点",pid = "0"}
            };
            List<sys_menu> olds = GetAll();
            datas.AddRange(olds);
            return datas;
        }
        /// <summary>
        /// 获得查询参数
        /// </summary>
        /// <param name="conwhere"></param>
        /// <returns></returns>
        public static List<sys_menu> GetAllWhere(string conwhere)
        {
            string wheresql = SearchHelper.GetSearchParaSql(conwhere);
            return DalFactory.Createsys_menu().GetAllWhere(wheresql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<sys_menu> GetTreeNodes()
        {
            //1.获得所有的菜单选项
            List<sys_menu> menus = GetAll();
            //2.获得所有无子级节点的菜单
            List<sys_menu> nochilds = menus.Where(menu => menus.FirstOrDefault(g => g.pid == menu.id) == null).ToList();
            //3.为无子级的节点元素拼接菜单行为的选项
            return nochilds;
        }
        /// <summary>
        /// 菜单和行为的关联保存的方法
        /// </summary>
        /// <param name="menuid"></param>
        /// <param name="actionid"></param>
        /// <returns></returns>
        public static bool SaveMenuAction(string menuid, List<string> actionid)
        {
            return DalFactory.Createsys_menu().SaveMenuAction(menuid,actionid);
        }
    }
}
