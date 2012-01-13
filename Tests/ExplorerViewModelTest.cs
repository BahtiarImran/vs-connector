//
// Copyright © 2010, 2011 ThoughtWorks, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at:
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using ThoughtWorks.VisualStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVsConnector
{
    
    
    /// <summary>
    ///This is a test class for ExplorerViewModel_FavoritesDictionaryTest and is intended
    ///to contain all ExplorerViewModel_FavoritesDictionaryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExplorerViewModelTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        private static string _host;
        private static string _login;
        private static string _password;
        private static string _project;
        private static string MINGLE_LOCAL_HOST = "http://localhost:8080";
        //private const string MINGLE_LOCAL_HOST = "http://fmtstdsol01.thoughtworks.com:8080";
        private const string MINGLE_INTEGRATION_USER = "mingleuser";
        private const string MINGLE_INTEGRATION_PASSWORD = "secret";

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            // save settings as they existed before the test
            _host = MingleSettings.Host;
            _login = MingleSettings.Login;
            _password = MingleSettings.Password;
            _project = MingleSettings.Project;
            MingleSettings.Host = "myhost";
            MingleSettings.Login = "mingleuser";
            MingleSettings.Password = "secret";
            MingleSettings.Project = "test";
        }
        
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        public static void MyClassCleanup()
        {
            // restore settings as they were before the test
            MingleSettings.Host = _host;
            MingleSettings.Login = _login;
            MingleSettings.Password = _password;
            MingleSettings.Project = _project;
        }
        
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

        [TestMethod]
        public void TestIsManagedListOfScalars()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var card = model.GetOneCard(120);
            var p = card.Properties["Story Status"];
            Assert.IsTrue(p.IsManagedListOfScalars);
            p = card.Properties["Release"];
            Assert.IsFalse(p.IsManagedListOfScalars);
            p = card.Properties["Owner"];
            Assert.IsFalse(p.IsManagedListOfScalars);
        }

        [TestMethod]
        public void TestFavoritesRefresh()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            var actual = model.Favorites.Count;
            const int expected = 10;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual("Iteration Scoreboard", model.Favorites.Values[1].Name);
        }

        [TestMethod]
        public void TestGetProperties()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var p = model.PropertyDefinitions;
            Assert.IsInstanceOfType(p, typeof(Dictionary<string, CardProperty>));
            Assert.AreEqual(false, p["Priority"].IsNumeric);
            Assert.AreEqual("cp_priority", p["Priority"].ColumnName);
        }

        [TestMethod]
        public void TestGetPropertyScalarValue()
        {
            //var model = new ViewModel("card_property.xml");
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var card = model.GetOneCard(92);
            Assert.IsInstanceOfType(card, typeof(Card));
            Assert.AreEqual("Essential", card.Properties["Priority"].Value);
        }

        [TestMethod]
        public void TestGetCardProperties()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var card = model.GetOneCard(92);
            Assert.IsInstanceOfType(card, typeof(Card));
            var p = card.Properties["Priority"] as CardProperty;
            Assert.AreEqual("Essential", p.Value);
            Assert.AreEqual("managed text list", p.PropertyValuesDescription.ToLower());
            Assert.AreEqual(false, p.Hidden);
            Assert.AreEqual(4, p.PropertyValueDetails.Count);
            Assert.AreEqual("Critical", p.PropertyValueDetails[0]);
            Assert.AreEqual("Essential", p.PropertyValueDetails[1]);
            Assert.AreEqual("Non-Essential", p.PropertyValueDetails[2]);
            Assert.AreEqual("Nice to have", p.PropertyValueDetails[3]);
            try
            {
                Assert.AreEqual("Nice to have", p.PropertyValueDetails[4]);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }

            p = card.Properties["Added to Scope On"] as CardProperty;
            Assert.AreEqual("2008-01-02", p.Value);
            Assert.AreEqual(true, p.Hidden);

            p = card.Properties["Analysis Completed in Iteration"] as CardProperty;
            Assert.AreEqual(false, p.Hidden);
            Assert.AreEqual("35", p.Value);
            model.SelectProject("test");
            Assert.AreEqual("Iteration 2", model.GetOneCard(35).Name);
            
        }

        [TestMethod]
        public void TestProjectsRefresh()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            Assert.AreEqual(2, model.ProjectList.Count);
            Assert.AreEqual("test", model.ProjectList.Keys[1]);
        }

        [TestMethod]
        public void TestTeamMembersRefresh()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var team = model.Team;
            Assert.IsInstanceOfType(team, typeof(Team));
            Assert.IsInstanceOfType(team["mingleuser"], typeof(TeamMember));
            var actual = team.Count;
            const int expected = 3;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(true, team.ContainsKey("mingleuser"));
        }

        [TestMethod]
        public void TestCardTypesRefresh()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var target = model.CardTypes;
            var actual = target.Count;
            const int expected = 7;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPropertyDefinitionsRefresh()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var p = model.PropertyDefinitions;
            Assert.IsInstanceOfType(p, typeof(Dictionary<string, CardProperty>));
            Assert.AreEqual(false, p["Priority"].IsNumeric);
            Assert.AreEqual("cp_priority", p["Priority"].ColumnName);
        }

        [TestMethod]
        public void TestGetCardsForFavorite()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var earlier = DateTime.Now;
            var cardList = model.GetCardsForFavorite("Risks");
            var later = DateTime.Now;
            var span = later.Subtract(earlier);
            Assert.AreEqual(5, cardList.Count);
            if (span.Seconds > 1) Assert.Fail("GetCardsForFavorite is too slow: " + span.Duration());
        }

        //[TestMethod]
        //public void TestGetCardsForFavoriteSpeed()
        //{
        //    var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
        //    var mingle = new MingleServer(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
        //    var project = mingle.GetProject("test");
        //    var fs = new FileInfo("perflog.txt").OpenWrite();
        //    var log = new TextWriterTraceListener(fs);
        //    var begin = DateTime.Now;
        //    var cards = project.GetView("Stories - By Priority");
        //    var endGetView = DateTime.Now;
        //    var getViewTime = endGetView.Subtract(begin);
        //    var enumeratedCards = cards.ToList();
        //    var endEnumerateCards = DateTime.Now;
        //    var enumerateCardsTime = endEnumerateCards.Subtract(endGetView);
        //    log.WriteLine("GetView: " + getViewTime);
        //    log.WriteLine("Enumerate: +" + enumerateCardsTime);
        //    foreach (var card in enumeratedCards)
        //    {
        //        var beginCard = DateTime.Now;
        //        var oneCard = new Card(card, model);
        //        var endCard = DateTime.Now;
        //        log.WriteLine(string.Format("Card: {0} - {1}", card.Number, endCard.Subtract(beginCard)));
        //    }

        //}

        [TestMethod]
        public void TestSelectProject()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            Assert.AreEqual(true, model.SelectProject("test"));
            Assert.AreEqual(false, model.SelectProject(""));
        }

        [TestMethod]
        public void TestRefreshTransitions()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var transitions = model.Transitions;
            Assert.AreNotEqual(null, transitions);
            Assert.AreEqual(19, transitions.Count);
        }
        
        [TestMethod]
        [DeploymentItem("Tests\\data\\card_transit.xml")]
        [DeploymentItem("Tests\\data\\projects.xml")]
        public void TestCardTransitions()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            // Touch the Transitions property to populate the cache
            var t = model.Transitions;
            var transitions = model.GetOneCard(7).Transitions.ToList();
            Assert.AreNotEqual(null, transitions);
            Assert.AreEqual(11, transitions.Count());
        }

        [TestMethod]
        [DeploymentItem("Tests\\data\\projects.xml")]
        public void TestIntegrationCardUpdate()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var card = model.GetOneCard(120);
            Assert.IsInstanceOfType(card, typeof(Card));
            card.AddCardAttributeFilterToPostData("name", "Integration test is running");
            card.Update();
            Assert.AreEqual("Integration test is running", card.Name);
            card.AddCardAttributeFilterToPostData("name", "This is a card for testing");
            card.Update();
            Assert.AreEqual("This is a card for testing", card.Name);
        }

        [TestMethod]
        public void TestIntegrationCardCreate()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var card = model.CreateCard("Iteration", "test");
            Assert.IsInstanceOfType(card, typeof(Card));
        }

        [TestMethod]
        public void TestSetPropertyValue()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var card = model.GetOneCard(120);
            var p = card.Properties;
            card.SetPropertyOrAttributValue("description", "the quick brown fox jumped over the wall");
            card.SetPropertyOrAttributValue("Owner", "mark");
            card.Update();
            card = model.GetOneCard(120);
            Assert.AreEqual("the quick brown fox jumped over the wall", card.Description);
            Assert.AreEqual("mark", card.Properties["Owner"].Value);
            // Reset the data
            card.SetPropertyOrAttributValue("description", string.Empty);
            card.SetPropertyOrAttributValue("Owner", string.Empty);
            card.Update();
        }

        [TestMethod]
        public void TestCardValuedPropertyNotSet()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var card = model.GetOneCard(36);
            var p = card.Properties;
            card.SetPropertyOrAttributValue("Release", "32");
            card.Update();
        }

        [TestMethod]
        public void TestGetOneCard()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var card = model.GetOneCard(120);
            Assert.AreEqual("This is a card for testing", card.Name);
        }

        [TestMethod]
        public void TestGetCardsOfType()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var count = model.GetCardsOfType("Story").Count;
            Assert.AreEqual(37, count);
        }

        [TestMethod]
        public void TestGetMurmurs()
        {
            var model = new ViewModel(MINGLE_LOCAL_HOST, MINGLE_INTEGRATION_USER, MINGLE_INTEGRATION_PASSWORD);
            model.SelectProject("test");
            var m = model.GetMurmurs();
            Assert.IsInstanceOfType(m, typeof(IEnumerable<Murmur>));
            Assert.AreNotEqual(0, m.Count());
        }

    }
}

