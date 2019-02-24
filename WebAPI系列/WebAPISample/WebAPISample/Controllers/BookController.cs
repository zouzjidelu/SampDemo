using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    public class BookController : ApiController
    {
        private static List<Book> books;
        static BookController()
        {
            books = new List<Book>()
            {
                new Book{ ID=1,Name="c#",Price=30},
                new Book{ ID=2,Name="c++",Price=32},
                new Book{ ID=3,Name="java",Price=33},
            };
        }

        public HttpResponseMessage GetJsonBooks()
        {
            //HttpContentExtensions

            //HttpContentExtensions.ReadAsAsync<Book>(new HttpRequestMessage().Content);

            return new HttpResponseMessage() { Content = new ObjectContent<List<Book>>(books, new JsonMediaTypeFormatter() { }) };
        }

        public HttpResponseMessage GetXmlBooks()
        {
            return new HttpResponseMessage() { Content = new ObjectContent<List<Book>>(books, new XmlMediaTypeFormatter() { }) };
        }

        public HttpResponseMessage GetTextBooks()
        {
            return new HttpResponseMessage() { Content = new StringContent("ss") };
        }

        public HttpResponseMessage GetFormUrlEncodeBooks()
        {
            //new Dictionary<string, string> { { "name1", "" }, }
            
            return new HttpResponseMessage()
            {
                Content = new ObjectContent<List<Book>>(books, new FormUrlEncodedContent() { })
            };
        }


    }
}
