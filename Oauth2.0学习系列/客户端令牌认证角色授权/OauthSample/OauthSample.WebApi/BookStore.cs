using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OauthSample.WebApi
{
    /// <summary>
    /// 图书存储器
    /// </summary>
    public class BookStore
    {
        public readonly static List<Book> books = new List<Book>();

        static BookStore()
        {
            books.Add(new Book { ID = 1, Name = "c#", Price = 30 });
            books.Add(new Book { ID = 2, Name = "c++", Price = 23.5 });
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            return this.GetBooks().FirstOrDefault(b => b.ID == id);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}
