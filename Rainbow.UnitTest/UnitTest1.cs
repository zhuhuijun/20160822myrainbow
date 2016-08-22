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
    }
}
