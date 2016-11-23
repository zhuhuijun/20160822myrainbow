using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rainbow.Models;

namespace Rainbow.Bll.extends
{
    /// <summary>
    /// 角色与行为进行关联时操作的功能
    /// </summary>
    public class Bll2RoleinfoTree
    {
        /// <summary>
        /// 获得树形菜单的数据
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public static List<ZtreeMenuModel> GetZTreeDatas(string roleid)
        {
            List<ZtreeMenuModel> res = new List<ZtreeMenuModel>();
            List<sys_menu> menus = Bll2sys_menu.GetAll();
            //1.获得1级节点将节点数据的isparent置为true,其它为false
            List<sys_menu> firsts = menus.Where(g => g.pid == "0").ToList();
            if (firsts.Count > 0)
            {
                GetFirstData(firsts, ref res);
                //2.获得所有无子级节点的菜单
                List<sys_menu> nochilds = menus.Where(menu => menus.FirstOrDefault(g => g.pid == menu.id) == null).ToList();
                GetNoChildData(nochilds, ref res);
                //3.为无子级的元素拼接行为数据
                List<sys_menu> nofirst = menus.Except(firsts).ToList();
                //4.获得中间节点
                List<sys_menu> middList = nofirst.Except(nochilds).ToList();
                if (middList.Count > 0)
                {
                    GetMiddleData(middList, ref res);
                }
                //获得角色的所有菜单
                List<rel_rolemenus> rolemenus = Bll2rel_rolemenus.GetAll().Where(g=>g.roleid==roleid).ToList();
                //循环遍历原有的数据为其选中的字段赋值
                foreach (var tt in res)
                {
                    if (rolemenus.Count(g => g.menuid == tt.id) > 0)
                    {
                        tt.ischeck = true;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 获得顶级的菜单的树形数据
        /// </summary>
        /// <param name="firsts"></param>
        /// <param name="trees">结果树</param>
        /// <returns></returns>
        private static void GetFirstData(List<sys_menu> firsts, ref List<ZtreeMenuModel> trees)
        {
            trees.AddRange(firsts.Select(tmp => new ZtreeMenuModel()
            {
                id = tmp.id,
                pid = tmp.pid,
                isparent = true,
                ischeck = false,
                name = tmp.menuname
            }));
        }

        /// <summary>
        /// 中间元素拼接树形数据
        /// </summary>
        /// <param name="firsts"></param>
        /// <param name="trees"></param>
        private static void GetMiddleData(List<sys_menu> firsts, ref List<ZtreeMenuModel> trees)
        {
            trees.AddRange(firsts.Select(tmp => new ZtreeMenuModel()
            {
                id = tmp.id,
                pid = tmp.pid,
                isparent = false,
                ischeck = false,
                name = tmp.menuname
            }));
        }

        /// <summary>
        /// 为无子级元素添加节点数据
        /// </summary>
        /// <param name="firsts"></param>
        /// <param name="trees"></param>
        private static void GetNoChildData(List<sys_menu> firsts, ref List<ZtreeMenuModel> trees)
        {
            List<sys_action> actions = Bll2sys_action.GetAll();
            List<rel_menuactions> menuactions = Bll2rel_menuactions.GetAll();
            foreach (sys_menu tmp in firsts)
            {
                ZtreeMenuModel one = new ZtreeMenuModel()
                {
                    id = tmp.id,
                    pid = tmp.pid,
                    isparent = false,
                    ischeck = false,
                    name = tmp.menuname
                };
                trees.Add(one);
                //添加action菜单
                List<rel_menuactions> myactions = menuactions.Where(t => t.menuid == tmp.id).ToList();
                foreach (rel_menuactions mya in myactions)
                {
                    sys_action action1 = actions.FirstOrDefault(f => f.id == mya.actionid);
                    if (action1 != null)
                    {
                        ZtreeMenuModel one2 = new ZtreeMenuModel()
                        {
                            id = tmp.id + "*" + mya.actionid,
                            pid = tmp.id,
                            isparent = false,
                            ischeck = false,
                            name = action1.actionname
                        };
                        trees.Add(one2);
                    }
                }
            }
        }
    }
}
