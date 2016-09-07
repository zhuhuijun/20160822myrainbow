using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rainbow.Models;

namespace Rainbow.Commons
{
    public class SearchHelper
    {
        /// <summary>
        /// 将查询参数进行解析以便于构造sql语句
        /// </summary>
        /// <param name="searchwhere"></param>
        /// <returns></returns>
        public static string GetSearchParaSql(string searchwhere)
        {
            StringBuilder sb = new StringBuilder(" 1=1 ");
            if (!string.IsNullOrEmpty(searchwhere))
            {
                try
                {
                    List<CommonSearchModel> paras = JsonConvert.DeserializeObject<List<CommonSearchModel>>(searchwhere);
                    paras =
                        paras.Where(t => !string.IsNullOrEmpty(t.paraname) && !string.IsNullOrEmpty(t.paravalue))
                            .ToList();

                    if (paras != null && paras.Count > 0)
                    {
                        //参数防注入字段的过滤
                        List<CommonSearchModel> paras2 = new List<CommonSearchModel>();
                        foreach (CommonSearchModel csm in paras)
                        {
                            CommonSearchModel newone = new CommonSearchModel();
                            newone.paraname = FilterSql(csm.paraname);
                            newone.paravalue = FilterSql(csm.paravalue);
                            newone.searchop = csm.searchop;
                            paras2.Add(newone);
                        }
                        //拼接sql
                        foreach (CommonSearchModel csm in paras2)
                        {
                            switch (csm.searchop.ToLower())
                            {
                                case "eq":
                                    break;
                                default:
                                    sb.AppendFormat("AND  {0} like '%{1}%'  ", csm.paraname, csm.paravalue);
                                    break;
                            }

                        }
                    }

                    return sb.ToString();
                }
                catch (Exception ex)
                {
                    return sb.ToString();
                }
            }

            return sb.ToString();
        }
        /// <summary>
        /// 处理特殊的字符串防止sql注入
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FilterSql(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            s = s.Trim().ToLower();
            //s = ClearScript(s);
            s = s.Replace("=", "");
            s = s.Replace("'", "");
            s = s.Replace(";", "");
            s = s.Replace(" or ", "");
            s = s.Replace("select", "");
            s = s.Replace("update", "");
            s = s.Replace("insert", "");
            s = s.Replace("delete", "");
            s = s.Replace("declare", "");
            s = s.Replace("exec", "");
            s = s.Replace("drop", "");
            s = s.Replace("create", "");
            s = s.Replace("%", "");
            s = s.Replace("--", "");
            return s;
        }
    }
}
