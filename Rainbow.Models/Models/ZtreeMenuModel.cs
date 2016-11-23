using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow.Models
{
    /// <summary>
    /// 树形菜单ztree的结构实体
    /// </summary>
    public class ZtreeMenuModel
    {
        public string id { get; set; }
        public string pid { get; set; }
        public string name { get; set; }
        public bool ischeck { get; set; }
        public bool isparent { get; set; } 
    }
}
