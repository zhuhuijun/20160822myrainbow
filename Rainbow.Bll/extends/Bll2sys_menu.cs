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
            return DalFactory.Createsys_menu().SaveMenuAction(menuid, actionid);
        }
        /// <summary>
        /// 获得控制器和行为
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public static string GetControllerAndActions(string roleid)
        {
            Dictionary<string, string> controllerDic = new Dictionary<string, string>();
            List<rel_rolemenus> menuandaction = Bll2rel_rolemenus.GetControllerAndActions(roleid);
            List<sys_menu> menus = Bll2sys_menu.GetAll();
            List<sys_action> actions = Bll2sys_action.GetAll();
            //1.将控制器和行为的主键进行分离
            foreach (rel_rolemenus tmp in menuandaction)
            {
                string[] tmparr = tmp.menuid.Split('*');
                var firstOrDefault = menus.FirstOrDefault(g => g.id == tmparr[0]);
                if (firstOrDefault != null)
                {
                    string controllername = firstOrDefault.urlaction;
                    var sysAction = actions.FirstOrDefault(g => g.id == tmparr[1]);
                    if (sysAction != null)
                    {
                        string action = sysAction.actioncode;
                        action = AppendActions(action);
                        if (!string.IsNullOrEmpty(controllername) && !string.IsNullOrEmpty(action))
                        {
                            //如果有此控制器就继续追加行为
                            if (controllerDic.ContainsKey(controllername))
                            {
                                string val = controllerDic[controllername];
                                string newval = val + "," + action;
                                controllerDic[controllername] = newval;
                            }
                            else//如果没有就添加
                            {
                                controllerDic.Add(controllername, action);
                            }

                        }
                    }
                }
            }
            string retl = DicToStr(controllerDic);
            return retl;
        }
        /// <summary>
        /// 将字典转为字符串
        /// </summary>
        /// <param name="dics"></param>
        /// <returns></returns>
        private static string DicToStr(Dictionary<string, string> dics)
        {
            StringBuilder sb = new StringBuilder();

            if (dics.Count > 0)
            {
                sb.Append("[ ");
                foreach (KeyValuePair<string, string> tmp in dics)
                {
                    StringBuilder ss = new StringBuilder("{");
                    ss.AppendFormat("\"controller\": \"{0}\", \"actions\":\"{1}\"", tmp.Key.ToLower(), tmp.Value.ToLower());
                    ss.Append(" },");
                    sb.Append(ss);
                }
                sb = sb.Remove(sb.Length - 1, 1);
                sb.Append(" ]");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 额外的行为
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private static string AppendActions(string action)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(action);
            switch (action.ToLower())
            {
                case "index":
                    sb.Append(",GetData");
                    break;
            }
            return sb.ToString();
        }
    }
}
