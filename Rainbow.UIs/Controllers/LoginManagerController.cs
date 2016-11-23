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

namespace Rainbow.UIs.Controllers
{
    /// <summary>
    /// 登陆管理的控制器 
    /// </summary>
    public class LoginManagerController : Controller
    {
        bool isLogin = false;
        // GET: LoginManager
        public ActionResult Login(UserLoginModel user)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                bas_user sysUser = null;
                if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
                {
                    sysUser = Bll2bas_user.GetWhere(new { username = user.UserName, userpwd = MD5Helper.EncryptString(user.Password) }).ToList().FirstOrDefault();
                    if (sysUser != null)
                    {
                        FormsAuthentication.SetAuthCookie(sysUser.id + "|" + sysUser.username + "|" + sysUser.userpwd, false);
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