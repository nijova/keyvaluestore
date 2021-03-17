using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace KeyValueStore
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string baseAddress = "http://localhost:5544/";
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(baseAddress);
            config.Routes.MapHttpRoute("Kvs", "{controller}/{key}");

            HttpSelfHostServer server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
            Console.ReadKey();
            server.CloseAsync().Wait();
        }
    }
}
