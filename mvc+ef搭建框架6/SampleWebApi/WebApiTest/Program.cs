using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApiTest
{
    class Program
    {
        /// <summary>
        /// 通过httpclient调用webapi接口
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            HttpClient httpClient = HttpClientFactory.Create(new MyMessageHandler()); //new HttpClient(new MyMessageHandler());
            httpClient.BaseAddress = new System.Uri("http://127.0.0.1:8888");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
            HttpResponseMessage httpResponse = httpClient.GetAsync("api/Books").Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                string result = httpResponse.Content.ReadAsStringAsync().Result;
                List<Book> list = JsonConvert.DeserializeObject<List<Book>>(result);
                foreach (var item in list)
                {
                    Console.WriteLine("Name：" + item.Name);
                }
            }
            else
            {
                System.Console.WriteLine(httpResponse.StatusCode + httpResponse.ReasonPhrase);
            }

            Console.ReadKey();
        }
    }
    public class Book
    {
        /// <summary>
        /// 图书编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 图书名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图书价格
        /// </summary>
        public double Price { get; set; }
    }
}
