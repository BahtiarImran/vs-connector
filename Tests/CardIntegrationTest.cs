using System.Linq;
using ThoughtWorks.VisualStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ThoughtWorksMingleLib;

namespace Tests
{
    
    
    /// <summary>
    ///This is a test class for CardIntegrationTest and is intended
    ///to contain all CardIntegrationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CardIntegrationTest
    {
        private static string _host;
        private static string _login;
        private static string _password;
        private static string _project;
        private static string _mingleHost;
        private const string MINGLE_INTEGRATION_USER = "mingleuser";
        private const string MINGLE_INTEGRATION_PASSWORD = "secret";

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            _host = MingleSettings.Host;
            _login = MingleSettings.Login;
            _password = MingleSettings.Password;
            _project = MingleSettings.Project;
            MingleSettings.Host = "myhost";
            MingleSettings.Login = "mingleuser";
            MingleSettings.Password = "secret";
            MingleSettings.Project = "test";
            _mingleHost = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MINGLETARGET")) ?
                "http://127.0.0.1:8080" : Environment.GetEnvironmentVariable("MINGLETARGET");
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            // restore settings as they were before the test
            MingleSettings.Host = _host;
            MingleSettings.Login = _login;
            MingleSettings.Password = _password;
            MingleSettings.Project = _project;
        }

        #region Additional test attributes
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Transitions
        ///</summary>
        [TestMethod()]
        public void TransitionsIntegrationTest()
        {
            Assert.AreEqual(19, new MingleServer(_mingleHost, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD).GetProject("test").Transitions.Count);
            var model = new ViewModel(_mingleHost, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            Assert.AreEqual(1, model.GetOneCard(126).Transitions.Count());
        }

        [TestMethod()]
        public void TestCardName()
        {
            var model = new ViewModel(_mingleHost, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var card = model.GetOneCard(126);
            Assert.AreEqual("ready to test", card.Name);
            card.AddCardAttributeFilterToPostData("name", "xxx");
            card.Update();
            var card2 = model.GetOneCard(126);
            Assert.AreEqual("xxx", card2.Name);
            card.AddCardAttributeFilterToPostData("name", "ready to test");
            card.Update();
        }

        [TestMethod()]
        public void TestCardDescription()
        {
            var model = new ViewModel(_mingleHost, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var card = model.GetOneCard(126);
            Assert.AreEqual("ready to test", card.Description);
            card.AddCardAttributeFilterToPostData("description", "xxx");
            card.Update();
            var card2 = model.GetOneCard(126);
            Assert.AreEqual("xxx", card2.Description);
            card.AddCardAttributeFilterToPostData("description", "ready to test");
            card.Update();
        }
    }
}
