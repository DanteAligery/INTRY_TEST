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
using System.Collections.Specialized;

namespace INTRY.API
{
    [TestFixture]
    public class API
    {
        static String realm = "test-squadspace.squadsoft.ru";
        static String userName = "lesnikov";
        static String password = "qoO5QOE90";
        static String URL;
        static String PostPATH = "/_vti_bin/Intry/FeedService.svc/CreateUserPost";
        public static Uri mainUri;
        static Uri postURI;

        public void makeURI()
        {
            
        }


        [Test]
        public static async Task Authorization()
        {
            UriBuilder Builder = new UriBuilder();
            Builder.Scheme = "http";
            Builder.Host = realm;
            Uri mainUri = Builder.Uri;
            URL = mainUri.ToString();
            Console.WriteLine("Стучимся на URL: " + URL);


            String basicAUTH = userName + ":" + password;
            Console.WriteLine("Перадаём данные для авторизации: " + basicAUTH);

            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(basicAUTH);
            String basicAUTHencoded = System.Convert.ToBase64String(data);
            Console.WriteLine("Данные для авторизации в base64: " + basicAUTHencoded);

            CredentialCache cache = new CredentialCache();
            cache.Add(mainUri, "NTLM", new NetworkCredential(userName, password,""));
            HttpClientHandler handler = new HttpClientHandler();
            handler.AllowAutoRedirect = true;
            handler.Credentials = cache;
            HttpClient client = new HttpClient(handler);
            HttpResponseMessage rs = await client.GetAsync(mainUri);
            
            if (rs.IsSuccessStatusCode)
            {
                Console.WriteLine("Авторизация пройдена. StatusCode: " + rs.StatusCode.ToString());
            }
            else
            {
                Console.WriteLine("Авторизация не пройдена. Status code: ", rs.StatusCode.ToString());
            }

        }
        [Test]
        public static async Task postAsync() {
            UriBuilder Builder = new UriBuilder();
            Builder.Scheme = "http";
            Builder.Host = realm;
            Uri mainUri = Builder.Uri;
            URL = mainUri.ToString();
            Console.WriteLine(URL);


            String basicAUTH = userName + ":" + password;
            Console.WriteLine(basicAUTH);

            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(basicAUTH);
            String basicAUTHencoded = System.Convert.ToBase64String(data);

            CredentialCache cache = new CredentialCache();
            cache.Add(mainUri, "NTLM", new NetworkCredential(userName, password, ""));
            HttpClientHandler handler = new HttpClientHandler();
            handler.AllowAutoRedirect = true;
            handler.Credentials = cache;
            HttpClient client = new HttpClient(handler);
            HttpResponseMessage rs = await client.GetAsync(mainUri);

            UriBuilder Builder_post = new UriBuilder();
            Builder_post.Scheme = "http";
            Builder_post.Host = realm;
            Builder_post.Path = PostPATH;
            Uri postURI = Builder.Uri;
            String postURL = postURI.ToString();
            Console.WriteLine(postURL);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postURL);
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            UTF8Encoding encoding = new UTF8Encoding();




            var bytes = encoding.GetBytes("123");

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;

            using (var newStream = request.GetRequestStream())
            {
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
            }
            request.GetResponse();
        }


        /*
        var values = new Dictionary<string, string>
            {
                { "thing1", "hello" },
                { "thing2", "world" }
            };

        var content = new FormUrlEncodedContent(values);
        var response = await client.PostAsync(postURL, content);
        /*
        using (var client = new WebClient())
        {
            var param = new NameValueCollection();
            param.Add("userId", "8");
            var response = client.UploadValues(postURL, param);

        }
        */
        //CredentialCache cache = new CredentialCache();

        /*   
    CredentialsProvider credsProvider = new BasicCredentialsProvider();
    credsProvider.setCredentials(AuthScope.ANY, new NTCredentials(userName, password, LentaURl, domain));
    CloseableHttpClient client = HttpClientBuilder.create().setDefaultCredentialsProvider(credsProvider).build();
    /*
    HttpPost httpPost = new HttpPost(post);
    ObjectMapper mapper = new ObjectMapper();
    ObjectNode node = mapper.createObjectNode();
    node.put("text", "test");
    node.put("userId", 8);
    node.putNull("media");
    node.putArray("docs");
    node.putArray("mentions");
    String json = node.toString();
    StringEntity ent = new StringEntity(json);
    httpPost.setEntity(ent);
    httpPost.addHeader("content-type", "application/json");
    //System.out.println("Executing request " + httpPost.getRequestLine());
    CloseableHttpResponse responsePOST = client.execute(httpPost);
    int answerPOST = responsePOST.getStatusLine().getStatusCode(); 
        */


    }
    
}
