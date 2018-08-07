using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using System.Net.Http;
using System.Net;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        //static IWebDriver Cdriver;
        static String realm = "test-squadspace.squadsoft.ru";
        static String userName = "lesnikov";
        static String password = "qoO5QOE9";
        //public UriBuilder Builder;
        static String URL;

        public void prepare()
        {
        //    
        }

        [Test]
        public static async Task TestMethodAsync()
        {
            UriBuilder Builder = new UriBuilder();
            Builder.Scheme = "http";
            Builder.Host = realm;
            Uri mainUri = Builder.Uri;
            URL = mainUri.ToString();
            Console.Write(URL);

            String basicAUTH = userName + ":" + password;
            Console.Write(basicAUTH);

            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(basicAUTH);
            String basicAUTHencoded = System.Convert.ToBase64String(data);
            
            HttpClient client = new HttpClient();
            //client.BaseAddress = mainUri;
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", basicAUTHencoded);

            //var headers = client.DefaultRequestHeaders;
            client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("WWW-Authenticate", "NTLM");
            client.DefaultRequestHeaders.Add("WWW-Authenticate", "Basic" + " " + basicAUTHencoded);
            HttpResponseMessage response = new HttpResponseMessage();
            response = await client.GetAsync(mainUri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            //var response = client.GetStringAsync(mainUri).Result;
            //String responseContent = response.ToString();
            //Console.WriteLine(responseContent);

            //server server = new server(@"C:\Users\dante\Documents\soft\browsermob-proxy-2.1.4\bin\browsermob-proxy.bat");
            //Cdriver = new ChromeDriver();
            //Cdriver.Navigate().GoToUrl(URL);
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);

        }
        public void cleanup()
        {
            //Cdriver.Quit();
        }
    }
}
