using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using Rainbow.Bll;
using Rainbow.Models;
using WebUtility;
using WebUtility.Security;

namespace Rainbow.UIs.Controllers
{

    public class HomeController : WebControllerBase
    {
        /// <summary>
        /// 主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string username=String.Empty;
            string userid=String.Empty;
            string rolename=String.Empty;
            string menustr=String.Empty;
            if (HttpContext.Session != null)
            {
                var curuser = HttpContext.Session["userinfo"];
                //用户信息的绑定
                if (curuser != null)
                {
                    bas_user userinfo = JsonConvert.DeserializeObject<bas_user>(curuser.ToString());
                    username = userinfo.realname;
                    userid = userinfo.id;
                    rolename = Bll2sys_role.GetById(userinfo.roleid).rowname;
                    menustr = Bll2rel_rolemenus.CreateMenuByRoleId(userinfo.roleid);
                }
                else
                {
                    return RedirectToAction("LoginOff", "LoginManager");
                }
            }
            ViewBag.RealName = username;
            //用户角色
            ViewBag.RoleName = rolename;
            //用户菜单的数据组织
            ViewBag.MenuStr = menustr;
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

    }
}