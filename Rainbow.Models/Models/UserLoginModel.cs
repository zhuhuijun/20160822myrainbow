using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow.Models
{
    public class UserLoginModel
    {
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 用户验证码
        /// </summary>
        public string UserAuthCode { get; set; }
        /// <summary>
        /// 登录错误提示信息
        /// </summary>
        public string ErrorMsg { get; set; }
        /// <summary>
        /// 用户角色组
        /// </summary>
        public string[] Roles { get; set; }
    }
}
