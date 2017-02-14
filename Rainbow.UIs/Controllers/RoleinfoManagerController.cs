using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rainbow.Bll;
using Rainbow.Bll.extends;
using Rainbow.Models;
using Rainbow.UIs.Models;
using WebUtility;
using WebUtility.Security;

namespace Rainbow.UIs.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    [RequireAuthorize]
    public class RoleinfoManagerController : WebControllerBase
    {
        // GET: RoleinfoManager
        public ActionResult Index()
        {
            string btns = BtnCreate.GetBtn("roleinfomanager");
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
        public ActionResult Add()
        {
            sys_role role = new sys_role();
            return View(role);
        }
        /// <summary>
        /// 添加的方法
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
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
        public ActionResult Edit(string id)
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
                int usercount = Bll2bas_user.GetWhereCount(new {roleid = id});
                if (usercount > 0)
                {
                    cm = new CRUDModel(CRUD.ROLELINK);
                }
                else
                {
                    bool del = Bll2rel_rolemenus.DeleteRole(id);
                    cm = CRUDModelHelper.GetRes(CRUD.DELETE, del);
                }

            }
            return Json(cm, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 创建角色分配菜单视图的界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SetPrivilege(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("ParaError", "GlobalPage");
            }
            else
            {
                ViewBag.roleid = id;
                ViewBag.TreeDatas = Bll2RoleinfoTree.GetZTreeDatas(id);
                return View();
            }
        }
        /// <summary>
        /// 保存角色的菜单值
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="menuids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetPrivilege(string roleid, string menuids)
        {
            CRUDModel cm = null;
            if (string.IsNullOrEmpty(roleid) || string.IsNullOrEmpty(menuids))
            {
                cm = new CRUDModel();
            }
            else
            {
                bool flag = Bll2rel_rolemenus.SaveRoleMenu(roleid, menuids);
                cm = CRUDModelHelper.GetRes(CRUD.ROLEMENU, flag);
            }
            return Json(cm, JsonRequestBehavior.DenyGet);
        }
    }
}