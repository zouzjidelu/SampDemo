using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;

namespace OauthSample.WebApi
{
    /// <summary>
    /// 图书控制器
    /// </summary>
    public class BookController : ApiController
    {
        private readonly static BookStore bookStore = new BookStore();
        
        [ResourceAuthorize("GetBooks","Book")]
        public IEnumerable<Book> GetBooks()
        {
            return bookStore.GetBooks();
        }

        [ResourceAuthorize("GetBook","Book")]
        public Book GetBook(int bookId)
        {
            return bookStore.GetBook(bookId);
        }

        [ResourceAuthorize("AddBook", "Book")]
        public void AddBook(Book book)
        {
            bookStore.AddBook(book);
        }
    }
}
