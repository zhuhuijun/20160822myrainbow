using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rainbow.UIs.Controllers
{
    public class GlobalPageController : Controller
    {
        // GET: GlobalPage
        public ActionResult ParaError()
        {
            return View();
        }
    }
}