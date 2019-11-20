using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WOZAP;
using DataBase;
using System.ServiceModel;


namespace Sevice.TEST
{
    [TestClass]
    public class TestConnect
    {
        [TestMethod]
        public void TestGetUsrMethod()
        {
            Service testService = new Service();

            List<WOZAP.User> users = testService.GetUsr();

            WOZAP.User[] usrs = users.ToArray();
            Assert.AreEqual(usrs[0].name, "vadik");
            Assert.AreEqual(usrs[1].name, "artem");
            Assert.AreEqual(usrs[2].name, "iluxa");
            Assert.AreEqual(usrs[3].name, "soroka");
            Assert.AreEqual(usrs[4].name, "romchik");
            Assert.AreEqual(usrs[5].name, "solyara");
            Assert.AreNotEqual(usrs[0].name, "iluxa");
            Assert.AreNotEqual(usrs[1].name, "iluxa");
            Assert.AreNotEqual(usrs[3].name, "iluxa");
            Assert.AreNotEqual(usrs[4].name, "iluxa");
            Assert.AreNotEqual(usrs[5].name, "iluxa");
        }

        //[TestMethod]
        /*public void TestConnectMethod()
        {
            MockDataBase db = new MockDataBase();
            Service testService = new Service(db);

            //testService.Connect("artem");
            Assert.AreEqual("artem", db.users[0]);
        }*/

        [TestMethod]
        public void TestConstructMethod()
        {
            Service testService = new Service();

            Assert.AreEqual("vadik", testService.GetUsr().ToArray()[0].name);
            Assert.AreEqual("artem", testService.GetUsr().ToArray()[1].name);
        }
    }
}
