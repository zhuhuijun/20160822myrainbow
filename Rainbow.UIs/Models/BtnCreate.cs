using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Rainbow.Bll;
using Rainbow.Models;
using WebUtility;

namespace Rainbow.UIs.Models
{
    /// <summary>
    /// 样式帮助类
    /// </summary>
    public class ClazzHelper
    {
        private static Dictionary<string, string> classdic = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        static ClazzHelper()
        {
            classdic = new Dictionary<string, string>()
            {
                {"add","btn btn-success btn-xs op,fa fa-plus"},
                {"edit","btn btn-primary btn-xs op,fa fa-sort-amount-asc"},
                {"delete","btn btn-danger btn-xs op,fa fa-sort-amount-asc"},
                {"setprivilege","btn btn-danger btn-xs op,fa fa-sort-amount-asc"},
                {"default","btn btn-success btn-xs op,fa fa-plus" }
            };
        }
        /// <summary>
        /// 根据key来获得样式
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string[] getClazz(string key)
        {
            string clazzstr = String.Empty;
            foreach (KeyValuePair<string, string> tmp in classdic)
            {
                if (tmp.Key.Contains(key))
                {
                    clazzstr = tmp.Value;
                    break;
                }
            }
            return !string.IsNullOrEmpty(clazzstr) ? clazzstr.Split(',') : classdic["default"].Split(',');
        }
    }
    /// <summary>
    /// 创建按钮的帮助类
    /// </summary>
    public class BtnCreate
    {
        /// <summary>
        /// 创建自己的按钮
        /// </summary>
        /// <param name="controllername"></param>
        /// <returns></returns>
        public static string GetBtn(string controllername)
        {
            UserAuthModel[] UserAuthList = HttpContext.Current.Session["USER_AUTHORITIES"] as UserAuthModel[];
            StringBuilder sb = new StringBuilder();
            if (UserAuthList != null && UserAuthList.Any())
            {
                UserAuthModel auth = UserAuthList.FirstOrDefault(a => a.Controller == controllername);
                if (auth != null)
                {
                    string actions = auth.Actions;
                    string[] actionarr = actions.Split(',');
                    Dictionary<string, string> actionsdic = new Dictionary<string, string>();
                    List<sys_action> acdb = Bll2sys_action.GetAll();
                    foreach (string aa in actionarr)
                    {
                        if (aa.ToLower().IndexOf("index", StringComparison.Ordinal) < 0 && aa.ToLower().IndexOf("getdata", StringComparison.Ordinal) < 0)
                        {
                            var firstOrDefault = acdb.FirstOrDefault(g => g.actioncode == aa.ToLower());
                            if (firstOrDefault != null)
                            {
                                string valued = firstOrDefault.actionname;
                                actionsdic.Add(aa.ToLower(), valued);
                            }

                        }
                    }
                    if (actionsdic.Count > 0)
                    {
                        string las = CreateSignalBtn(actionsdic);
                        sb.Append(las);
                    }
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 根据单个的action去创建相应的按钮
        /// </summary>
        /// <param name="actions"></param>
        /// <returns></returns>
        private static string CreateSignalBtn(Dictionary<string, string> actions)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> tt in actions)
            {
               string[] clazzarr= ClazzHelper.getClazz(tt.Key);
                sb.AppendFormat("<button type='button' class=\"{0}\" op='{1}'><i class=\"{2}\"></i> {3}</button> ", 
                    clazzarr[0],
                    tt.Key,
                    clazzarr[1],
                    tt.Value);
            }
            return sb.ToString();
        }
    }
}