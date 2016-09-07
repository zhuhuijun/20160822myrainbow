using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rainbow.Bll;
using Rainbow.Dal;
using Rainbow.IDal;

namespace Rainbow.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Isys_roleDal roledal = new sys_roleDal();
            var one = roledal.GetById("1cfef3dd-cd77-467e-ad44-a43821e6e650");
        }
        /// <summary>
        /// 删除的测试
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            Isys_roleDal roledal = new sys_roleDal();
            string id = "9f6c53e5-5707-4d30-813d-c88677f8e882";
            var one = roledal.GetById(id);
            bool ret = roledal.Delete(id);
        }
        [TestMethod]
        public void DeleteWhere()
        {
            Isys_roleDal roledal = new sys_roleDal();
            string id = "3";
            var one = roledal.DeleteWhere(new { id = id });
        }
        /// <summary>
        /// 修改方法
        /// </summary>
        [TestMethod]
        public void update()
        {
            Isys_roleDal roledal = new sys_roleDal();
            string id = "3870b4c6-3991-4c46-bcad-ce2c3bf0b7c0";
            var one = roledal.EditWhere(new { createtime = "2016-07-29 11:14:08.830" }, new { rowname = "owner2" });
        }

        /// <summary>
        /// 修改方法
        /// </summary>
        [TestMethod]
        public void update2()
        {
            Isys_roleDal roledal = new sys_roleDal();
            string id = "185f5e6d-490c-4347-a6cf-3d45bd95b8cb";
            var one = roledal.Edit(id, new { rowname = "owner2" });
        }

        [TestMethod]
        public void GetDb()
        {
            Ibas_userDal userdal = new bas_userDal();
            string id = "1";
            userdal.getById1("1");
        }

        [TestMethod]
        public void GetDbPage()
        {
            var data = Bll2bas_user.GetPageData("","id",1);
        }
        [TestMethod]
        public void GetByPara()
        {
            string paras = "[{'paraname':'UserName','paravalue':'ap','searchop':''}]";
            var datas = Bll2bas_user.GetPageData(paras,"id", 1);
        }
    }
}
