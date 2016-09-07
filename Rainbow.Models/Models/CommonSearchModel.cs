using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow.Models
{
    public class CommonSearchModel
    {
        /// <summary>
        /// 查询的参数
        /// </summary>
        public string paraname { get; set; }
        /// <summary>
        /// 参数的值
        /// </summary>
        public string paravalue { get; set; }
        /// <summary>
        /// 匹配的操作符
        /// </summary>

        private string _searchop = "like";

        public string searchop
        {

            get { return _searchop; }
            set { _searchop = value; }
        }
    }
}
