using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security;
using System.Xml.Linq;
using ThoughtWorksCoreLib;
using ThoughtWorksMingleLib;

namespace Mocks
{
    public class MingleProject : IMingleProject
    {
        public string TestData { get; set; }

        private static SecureString SecureStr
        {
            get 
            { 
                var ss = new SecureString();
                foreach (var c in "secure".ToCharArray()) ss.AppendChar(c);
                return ss;
            }
        }

        public static ThoughtWorksMingleLib.MingleServer FakeMingle
        {
            get
            {
                return new ThoughtWorksMingleLib.MingleServer("a", "b", SecureStr);
            }
        }
        /// <summary>
        /// Returns a SortedList of XML objects with children from an XML file"/>
        /// </summary>
        /// <param name="fileName">Path to the file</param>
        /// <param name="keyTag">Name of the Element to use as the sorting key</param>
        /// <param name="valueTag">Name of the Element to use as the object value</param>
        /// <param name="exception">Exception caught (if any)</param>
        /// <returns></returns>
        public Dictionary<string, object> GetDictionaryOfObjects(string fileName, string keyTag, string valueTag, out System.Exception exception)
        {
            var dictionary = new Dictionary<string, object>();
            exception = null;

            try
            {
                var xml = new FileInfo(fileName).OpenText().ReadToEnd();
                foreach (var e in XElement.Load(xml).Elements(valueTag))
                {
                    dictionary.Add(e.Element(keyTag).Value, e);
                }
            }
            catch (System.Exception ex)
            {
                exception = ex;
            }

            return dictionary;
        }

        public MingleCardCollection GetCards(Collection<string> filters)
        {
            var p = new ThoughtWorksMingleLib.MingleProject("test", FakeMingle);
            var x = new MingleCardCollection(p);
            foreach(var c in XElement.Parse(new FileInfo(TestData).OpenText().ReadToEnd()).Elements("card"))
                x.Add(new MingleCard(c.ToString(), p));
            return x;
        }

        public MingleCardTypeCollection GetCardTypes()
        {
            var p = new ThoughtWorksMingleLib.MingleProject("test", FakeMingle);
            var x = new MingleCardTypeCollection(p);
            foreach (var c in XElement.Parse(new FileInfo(TestData).OpenText().ReadToEnd()).Elements("card_type"))
                x.Add(new MingleCardType(c.ToString()));
            return x;
        }

        public MingleTransitionCollection GetTransitions()
        {
            var p = new ThoughtWorksMingleLib.MingleProject("test", FakeMingle);
            var x = new MingleTransitionCollection(p);
            foreach (var c in XElement.Parse(new FileInfo(TestData).OpenText().ReadToEnd()).Elements("transition"))
                x.Add(c.Element("name").Value, new MingleTransition(c.ToString(),p));
            return x;
        }

        public MingleProjectMemberCollection GetTeam()
        {
            var team = new FileInfo("team.xml").OpenText().ReadToEnd();
            return new MingleProjectMemberCollection(new ThoughtWorksMingleLib.MingleProject("test", FakeMingle)).Parse(team) as MingleProjectMemberCollection;
        }

        public MinglePropertyDefinitionCollection GetProperties()
        {
            throw new NotImplementedException();
        }

        public MingleFavoriteCollection GetFavorites()
        {
            var favorites = new FileInfo("favorites.xml").OpenText().ReadToEnd();
            return new MingleFavoriteCollection(new ThoughtWorksMingleLib.MingleProject("test", FakeMingle)).Parse(favorites) as MingleFavoriteCollection;
        }

        public Hashtable GetCardValuedProperties(bool transitionOnly)
        {
            throw new NotImplementedException();
        }

        public string GetCardType(string cardNumber)
        {
            return "Story";
        }

        public MingleCardCollection GetIndirectCardsByNumber(string cardNumber)
        {
            throw new NotImplementedException();
        }

        public List<string> GetIndirectCardsByTypeName(string cardType, bool forceRead)
        {
            throw new NotImplementedException();
        }

        public XDocument ExecMql(string mql)
        {
            throw new NotImplementedException();
        }

        public MingleCardCollection GetView(string name)
        {
            throw new NotImplementedException();
        }

        public string RunMacro(string macro)
        {
            throw new NotImplementedException();
        }

        public MingleCard CreateCard(string type, string name)
        {
            throw new NotImplementedException();
        }

        public string ProjectId
        {
            get { throw new NotImplementedException(); }
        }

        public MinglePropertyDefinitionCollection Properties
        {
            get { throw new NotImplementedException(); }
        }

        public MingleTransitionCollection Transitions
        {
            get { throw new NotImplementedException(); }
        }

        public IMingleServer Mingle
        {
            get { throw new NotImplementedException(); }
        }
    }

    /// <summary>
    /// A mock MingleServer. Set TestData with name of data file of XML.
    /// </summary>
    public class MingleServer : IMingleServer, IMockMingle
    {
        public MingleServer ()
        {
            TestData = string.Empty;
        }

        public MingleServer(string testDataFileName)
        {
            TestData = testDataFileName;
        }

        internal string TestData;

        private string GetTestData()
        {
            return new FileInfo(TestData).OpenText().ReadToEnd();
        }

        /// <summary>
        /// Set connection information to be used in subsequent requests
        /// </summary>
        /// <param name="host">Mingle host URL</param>
        /// <param name="login">Mingle login id</param>
        /// <param name="password">Mingle password</param>
        /// <param name="exception"></param>
        public void SetConnectionInfo(string host, string login, string password, out Exception exception)
        {
            exception = null;
        }

        /// <summary>
        /// Set connection information to be used in subsequent requests
        /// </summary>
        /// <param name="host">Mingle host URL</param>
        /// <param name="login">Mingle login id</param>
        /// <param name="password">Mingle password</param>
        /// <param name="exception"></param>
        public void SetConnectionInfo(string host, string login, SecureString password, out Exception exception)
        {
            exception = null;
        }

        /// <summary>
        /// Performs a GET operation on the Mingle API
        /// </summary>
        /// <param name="project"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string project, string url)
        {
            return GetTestData();
        }

        /// <summary>
        /// Performs a GET operation on the Mingle API with a query string
        /// </summary>
        /// <param name="project"></param>
        /// <param name="url"></param>
        /// <param name="paramaters"></param>
        /// <returns></returns>
        public string Get(string project, string url, IEnumerable<string> paramaters)
        {
            return GetTestData();
        }

        /// <summary>
        /// Performs a PUT operation on the Mingle API with associated POST data
        /// </summary>
        /// <param name="project"></param>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        public ThoughtWorksCoreLib.IResponse Put(string project, string url, IEnumerable<string> postData)
        {
            var headers = new NameValueCollection();
            headers.Add("Location", "http://localhost:8080/api/v2/tests/cards/120.xml");
            return new Web.Response(headers, GetTestData());
        }

        /// <summary>
        /// Performs a POST operation on the Mingle API with associated POST data
        /// </summary>
        /// <param name="project"></param>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="absoluteUrl"></param>
        public ThoughtWorksCoreLib.IResponse Post(string project, string url, IEnumerable<string> postData)
        {
            var headers = new NameValueCollection();
            headers.Add("Location", "http://localhost:8080/api/v2/tests/cards/120.xml");
            return new Web.Response(headers, GetTestData());
        }

        /// <summary>
        /// Returns a Sorted list of project names and identifiers
        /// </summary>
        /// <returns></returns>
        public SortedList<string, string> GetProjectList()
        {
            var data = new FileInfo("projects.xml").OpenText().ReadToEnd();
            var projects = XElement.Parse(data);
            var s = new SortedList<string, string>();
            foreach (var p in projects.Elements("project")) s.Add(p.Element("name").Value, p.Element("identifier").Value);
            return s;
        }

        public ThoughtWorksMingleLib.MingleProject GetProject(string projectId)
        {
            return new ThoughtWorksMingleLib.MingleProject(projectId, this);
        }

        public void TestDataFile(string data)
        {
            TestData = data;
        }
    }

    /// <summary>
    /// This interface augments the mock MingleServer with testing hooks
    /// </summary>
    public interface IMockMingle
    {
        /// <summary>
        /// Inject different test data with a data file name
        /// </summary>
        /// <param name="data"></param>
        void TestDataFile(string data);
    }
}