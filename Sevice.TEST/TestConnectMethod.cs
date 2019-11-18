using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOZAP;
using System.ServiceModel;

namespace Sevice.TEST
{
    [TestClass]
    public class TestConnectMethod
    {
        [TestMethod]
        public void TestGetUsrMethod()
        {
            Service testService = new Service();

            List<User> users = testService.GetUsr();

            User[] usrs = users.ToArray();
            Assert.AreEqual(usrs[0].name, "vadik");
            Assert.AreEqual(usrs[1].name, "artem");
            Assert.AreEqual(usrs[2].name, "iluxa");
            Assert.AreEqual(usrs[3].name, "soroka");
            Assert.AreEqual(usrs[4].name, "romchik");
            Assert.AreEqual(usrs[5].name, "solyara");
        }
    }
}
