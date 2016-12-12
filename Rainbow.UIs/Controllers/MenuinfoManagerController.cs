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
    /// <summary>
    /// 菜单管理的控制器
    /// </summary>
    [RequireAuthorize]
    public class MenuinfoManagerController : WebControllerBase
    {
        // GET: MenuinfoManager
        public ActionResult Index()
        {
            string btns = BtnCreate.GetBtn("menuinfomanager");
            ViewBag.Btns = btns;
            return View();
        }
        /// <summary>
        /// 数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetData()
        {
            string requestStringPar = Request["customPar"];
            var depts = Bll2sys_menu.GetAllWhere(requestStringPar);
            var nodeid = Request["nodeid"];
            var n_level = Request["n_level"];
            string deptID = string.IsNullOrEmpty(nodeid) ? "0" : nodeid;
            int level = 0;
            int ler = 0;
            bool r=int.TryParse(n_level, out ler);
            if (r)
            {
                level = level + 1;
            }
            var subDepts = depts.Where<sys_menu>(x => x.pid == deptID).ToList();
            var data = new
            {
                page = 1,
                total = 1,
                records = subDepts.Count,
                rows = (from dept in subDepts
                        select new
                        {
                            cell = new[]
                            {
                                dept.id,
                                dept.menuname,
                                dept.urlaction ,
                                dept.pid != "0" ? dept.pid: "",
                                level.ToString(),   //Level
                                deptID != "0" ? deptID : "null",    //ParentID
                                depts.Count<sys_menu>(x => x.pid == dept.id) == 0 ? "true":"false",  //isLeaf
                                "false", //expanded
                                "false"//loaded
                            }
                        })
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加用户的界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            sys_menu one = new sys_menu();
            return View(one);
        }
        /// <summary>
        /// 添加的方法
        /// </summary>
        /// <param name="one"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(sys_menu one)
        {
            one.id = Guid.NewGuid().ToString();
            one.createtime = DateTime.Now;
            bool add = Bll2sys_menu.Insert(one);
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
                sys_menu one = Bll2sys_menu.GetById(id);
                string pidname = "顶级节点";
                //获得父级菜单的名称
                if (one.pid !="0")
                {
                    sys_menu pone= Bll2sys_menu.GetById(one.pid);
                    if (pone != null)
                    {
                        pidname = pone.menuname;
                    }
                }
                ViewBag.pidname = pidname;
                return View(one);
            }
        }
        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="one"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(sys_menu one)
        {
            bool edit = Bll2sys_menu.Edit(one.id, new {pid=one.pid,menuname=one.menuname,
                urlaction =one.urlaction});
            CRUDModel cm = CRUDModelHelper.GetRes(CRUD.EDIT, edit);
            return Json(cm, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 菜单选项的树形结构
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTree()
        {
            List<sys_menu> menus = Bll2sys_menu.GetAllForTree();
            ViewBag.TreeData = menus;
            return View();
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
                //判断是否有关联的子级菜单
                int cou =Bll2sys_menu.GetWhereCount(new {pid = id});
                if (cou > 0)
                {
                    cm = new CRUDModel(CRUD.HAVELINK);
                }
                else
                {
                    bool del = Bll2sys_menu.DeleteWhere(new { id=id});
                    cm = CRUDModelHelper.GetRes(CRUD.DELETE, del);
                }
            }
            return Json(cm, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获得菜单下绑定的按钮的界面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetActionTree()
        {
            List<sys_menu> menus = Bll2sys_menu.GetTreeNodes();
            List<sys_action> actions = Bll2sys_action.GetAll();
            List<rel_menuactions> menuactions = Bll2rel_menuactions.GetAll();
            ViewBag.NoChilds = menus;
            ViewBag.Actions = actions;
            ViewBag.MenuActions = menuactions;
            return View();
        }
        /// <summary>
        /// 保存菜单和按钮的关联数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetActionTree(string menuid,List<String> actionids)
        {
            CRUDModel cm = null;
            if (string.IsNullOrEmpty(menuid)||actionids==null||actionids.Count<1)
            {
                cm = new CRUDModel();
            }
            else
            {
                bool add = Bll2sys_menu.SaveMenuAction(menuid, actionids);
                cm = CRUDModelHelper.GetRes(CRUD.MENUACTION, add);
            }
            return Json(cm, JsonRequestBehavior.DenyGet);
        }
    }
}