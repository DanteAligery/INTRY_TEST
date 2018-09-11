using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace INTRY.API
{
    [TestFixture]
    public class API
    {
        static String realm = "test-squadspace.squadsoft.ru";
        static String userName = "lesnikov";
        static String password = "qoO5QOE9";
        static String CorrectUserName = "lesnikov";
        static String IncorrectUserName = "qwerty";
        static String CorrectUserPWD = "qoO5QOE9";
        static String IncorrectUserPWD = "HOHOHO";
        static String URL;
        static String postURL;
        static String PostPATH = "/_vti_bin/Intry/FeedService.svc/CreateUserPost";
        public static Uri mainUri;
        static Uri postURI;
        static StreamWriter stream;
        static StreamReader sr;

        public static IEnumerable<TestCaseData> loginTestData
        {
            get
            {
                yield return new TestCaseData(CorrectUserName, CorrectUserPWD, "OK");
                yield return new TestCaseData(IncorrectUserName, CorrectUserPWD, "Unauthorized");
                yield return new TestCaseData(CorrectUserName, IncorrectUserPWD, "Unauthorized");
                yield return new TestCaseData(IncorrectUserName, IncorrectUserPWD, "Unauthorized");
            }
        }
        [OneTimeSetUp]
        public void setup()
        {
        }
        public class post
        {
            public int userId { get; set; }
            public string text { get; set; }
            public Array docs { get; set; }
            public Array mentions { get; set; }
        }

        [Test, TestCaseSource(nameof(loginTestData))]
        public static async Task authorization(String a, String b, String expectedresult)
        {
            UriBuilder Builder = new UriBuilder();
            Builder.Scheme = "http";
            Builder.Host = realm;
            Uri mainUri = Builder.Uri;
            URL = mainUri.ToString();
            Console.WriteLine("Стучимся на URL: " + URL);

            String basicAUTH = a + ":" + b;
            Console.WriteLine("Перадаём данные для авторизации: " + basicAUTH);

            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(basicAUTH);
            String basicAUTHencoded = System.Convert.ToBase64String(data);
            Console.WriteLine("Данные для авторизации в base64: " + basicAUTHencoded);

            CredentialCache cache = new CredentialCache();
            cache.Add(mainUri, "NTLM", new NetworkCredential(a, b, ""));
            HttpClientHandler handler = new HttpClientHandler();
            handler.AllowAutoRedirect = true;
            handler.Credentials = cache;
            HttpClient client = new HttpClient(handler);
            HttpResponseMessage rs = await client.GetAsync(mainUri);
            String status = rs.StatusCode.ToString();
            Console.WriteLine(status);
            Assert.AreEqual(status, expectedresult);
        }

        [Test]
        //public async Task postAsync() {
        public async Task postAsync() { 
            UriBuilder Builder = new UriBuilder();
            Builder.Scheme = "http";
            Builder.Host = realm;
            Uri mainUri = Builder.Uri;
            URL = mainUri.ToString();
            Console.WriteLine("Стучимся на URL: " + URL);

            UriBuilder Builder_post = new UriBuilder();
            Builder_post.Scheme = "http";
            Builder_post.Host = realm;
            Builder_post.Path = PostPATH;
            Uri postURI = Builder_post.Uri;
            String postURL = postURI.ToString();
            Console.WriteLine("URL для POST: " + postURL);
            

            String basicAUTH = userName + ":" + password;
            Console.WriteLine("Перадаём данные для авторизации: " + basicAUTH);

            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(basicAUTH);
            String basicAUTHencoded = System.Convert.ToBase64String(data);
            Console.WriteLine("Данные для авторизации в base64: " + basicAUTHencoded);

            CredentialCache cache = new CredentialCache();
            cache.Add(mainUri, "NTLM", new NetworkCredential(userName, password, ""));
            HttpClientHandler handler = new HttpClientHandler();
            handler.AllowAutoRedirect = true;
            handler.Credentials = cache;
            HttpClient client = new HttpClient(handler);
            HttpResponseMessage rs = await client.GetAsync(mainUri);
            Console.WriteLine("Статус авторизации: " + rs.StatusCode.ToString());

            post Postjson = new post()
            {
                text = "test",
                userId = 8,
                docs = null,
                mentions = null,
            };

            String json = JsonConvert.SerializeObject(Postjson, Formatting.Indented);
            Console.WriteLine("Передаваемый json: "+ json);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postURL);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Credentials = cache;
            using (stream = new StreamWriter(request.GetRequestStream()))
            {
                stream.WriteAsync(json);
                stream.Flush();
                stream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (sr = new StreamReader(response.GetResponseStream()))
            {
                var result = sr.ReadToEnd();
                Console.WriteLine("Ответный json: " + result.ToString());
            }
        }
    }
}
