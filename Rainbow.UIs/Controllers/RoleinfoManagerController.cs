using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rainbow.Bll;
using Rainbow.Models;

namespace Rainbow.UIs.Controllers
{
    public class RoleinfoManagerController : Controller
    {
        // GET: RoleinfoManager
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
            PageDataView<sys_role> datas = Bll2sys_role.GetPageData(requestStringPar, "createtime", 1);
            var pm = new
            {
                page = datas.CurrentPage,
                records = datas.TotalNum,
                total = datas.TotalPageCount,
                rows = datas.Items
            };
            return Json(pm, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加用户的界面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUI()
        {
            sys_role role = new sys_role();
            return View(role);
        }
        /// <summary>
        /// 添加的方法
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public ActionResult Add(sys_role role)
        {
            role.id = Guid.NewGuid().ToString();
            role.createtime = DateTime.Now;
            bool add = Bll2sys_role.Insert(role);
            CRUDModel cm = CRUDModelHelper.GetRes(CRUD.ADD, add);
            return Json(cm, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditUI(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("ParaError", "GlobalPage");
            }
            else
            {
                sys_role one = Bll2sys_role.GetById(id);
                return View(one);
            }
        }
        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="one"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(sys_role one)
        {
            bool edit = Bll2sys_role.Edit(one.id, one);
            CRUDModel cm = CRUDModelHelper.GetRes(CRUD.EDIT, edit);
            return Json(cm, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(string id)
        {
            CRUDModel cm = null;
            if (string.IsNullOrEmpty(id))
            {
                cm = new CRUDModel();
            }
            else
            {
                bool del = Bll2sys_role.Delete(id);
                cm = CRUDModelHelper.GetRes(CRUD.DELETE, del);
            }
            return Json(cm, JsonRequestBehavior.AllowGet);
        }
    }
}