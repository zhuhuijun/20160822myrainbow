using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rainbow.UIs.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// 登录的页面
        /// </summary>
        /// <returns></returns>
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
    }
}