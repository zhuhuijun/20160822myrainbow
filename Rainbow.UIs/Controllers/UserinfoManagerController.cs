using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rainbow.Bll;
using Rainbow.Models;

namespace Rainbow.UIs.Controllers
{
    /// <summary>
    /// 用户管理的控制器
    /// </summary>
    public class UserinfoManagerController : Controller
    {
        // GET: UserinfoManager
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分页的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetData()
        {
            string requestStringPar = Request["customPar"];
            string page = Request["page"];//当前页
            int pageIndex = Convert.ToInt32(page);//当前页
            string paras = "[{'paraname':'UserName','paravalue':'ap','searchop':''}]";
            PageDataView<bas_user> datas = Bll2bas_user.GetPageData(requestStringPar, "id", 1);
            var pm = new 
            {
                page = datas.CurrentPage,
                records = datas.TotalNum,
                total = datas.TotalPageCount,
                rows = datas.Items
            };
            return Json(pm, JsonRequestBehavior.AllowGet);
        }
    }
}