using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            bool ret =roledal.Delete(id);
        }
    }
}
