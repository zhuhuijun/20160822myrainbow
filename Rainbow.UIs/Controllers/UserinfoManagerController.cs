using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rainbow.Bll;
using Rainbow.Commons;
using Rainbow.Models;
using Rainbow.UIs.Models;
using WebUtility;
using WebUtility.Security;

namespace Rainbow.UIs.Controllers
{
    /// <summary>
    /// 用户管理的控制器
    /// </summary>
    [RequireAuthorize]
    public class UserinfoManagerController : WebControllerBase
    {
        // GET: UserinfoManager
        public ActionResult Index()
        {
            string btns = BtnCreate.GetBtn("userinfomanager");
            ViewBag.Btns = btns;
            //根据控制器去生成该页面的按钮
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
        /// <summary>
        /// 添加用户的界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            bas_user user = new bas_user();
            ViewBag.roles = new SelectList(Bll2sys_role.GetAll(), "id", "rowname");
            return View(user);
        }
        /// <summary>
        /// 添加的方法
        /// </summary>
        /// <param name="one"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(bas_user one)
        {
            one.id = Guid.NewGuid().ToString();
            one.userpwd = MD5Helper.EncryptString(one.userpwd);
            one.createdate = DateTime.Now;
            bool add = Bll2bas_user.Insert(one);
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
                bas_user one = Bll2bas_user.GetById(id);
                ViewBag.roles = new SelectList(Bll2sys_role.GetAll(), "id", "rowname");
                return View(one);
            }
        }
        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="one"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(bas_user one)
        {
            var newone = new
            {
                roleid = one.roleid,
                username = one.username,
                realname = one.realname,
                phonenum = one.phonenum,
                emailaddress = one.emailaddress
            };
            bool edit = Bll2bas_user.Edit(one.id, newone);
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
                bool del = Bll2bas_user.Delete(id);
                cm = CRUDModelHelper.GetRes(CRUD.DELETE, del);
            }
            return Json(cm, JsonRequestBehavior.AllowGet);
        }
    }
}