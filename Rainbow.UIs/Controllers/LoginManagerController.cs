using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Rainbow.Bll;
using Rainbow.Commons;
using Rainbow.Models;
using Rainbow.Resources;
using Rainbow.UIs.Models;

namespace Rainbow.UIs.Controllers
{
    /// <summary>
    /// 登陆管理的控制器 
    /// </summary>
    public class LoginManagerController : Controller
    {
        // GET: LoginManager
        public ActionResult Login(UserLoginModel user)
        {
            bool isLogin = false;
            if (User.Identity.IsAuthenticated)
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                bas_user sysUser = null;

                if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
                {
                    AccountModel amodel = new AccountModel();
                    bas_user usercurr = amodel.ValidateUserLogin(user.UserName, user.Password);
                    if (usercurr != null)
                    {
                        //创建用户ticket信息
                        amodel.CreateLoginUserTicket(user.UserName, user.Password);
                        //读取用户权限数据
                        amodel.GetUserAuthorities(usercurr.roleid);
                        return Redirect(Url.Action("Index", "Home"));
                    }
                    else
                    {
                        user.ErrorMsg = CommonResource.LoginErrorUserNameOrPassword;
                    }
                }

            }
            if (!isLogin)
                return View(user);
            else
                return Redirect(Url.Action("Index", "Home"));
        }
        /// <summary>
        /// 退出系统登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOff()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return Redirect("/LoginManager/Login");
        }
    }

}