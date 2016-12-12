using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rainbow.Bll;
using Rainbow.Models;
using Rainbow.UIs.Models;
using WebUtility;
using WebUtility.Security;

namespace Rainbow.UIs.Controllers
{
    [RequireAuthorize]
    public class ActioninfoManagerController : WebControllerBase
    {
        // GET: ActioninfoManager
        public ActionResult Index()
        {
            string btns = BtnCreate.GetBtn("actioninfomanager");
            ViewBag.Btns = btns;
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
            PageDataView<sys_action> datas = Bll2sys_action.GetPageData(requestStringPar, "createtime", 1);
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
        public ActionResult Add()
        {
            sys_action one = new sys_action();
            return View(one);
        }
        /// <summary>
        /// 添加的方法
        /// </summary>
        /// <param name="one"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(sys_action one)
        {
            one.id = Guid.NewGuid().ToString();
            one.createtime = DateTime.Now;
            bool add = Bll2sys_action.Insert(one);
            CRUDModel cm = CRUDModelHelper.GetRes(CRUD.ADD, add);
            return Json(cm, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("ParaError", "GlobalPage");
            }
            else
            {
                sys_action one = Bll2sys_action.GetById(id);
                return View(one);
            }
        }
        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="one"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(sys_action one)
        {
            bool edit = Bll2sys_action.Edit(one.id, one);
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
                bool del = Bll2sys_action.Delete(id);
                cm = CRUDModelHelper.GetRes(CRUD.DELETE, del);
            }
            return Json(cm, JsonRequestBehavior.AllowGet);
        }
    }
}
