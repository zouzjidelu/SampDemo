using SampleWebApi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace SampleWebApi.Controllers
{
    public class BooksController : ApiController
    {
        private SampleDbContext db = new SampleDbContext();

        /// <summary>
        /// 通过jsonp的方式，接收callback参数。序列化数据，将数据通过response的content传递给前端。
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        //public HttpResponseMessage GetBooks(string callback)
        //{
        //    string book = Newtonsoft.Json.JsonConvert.SerializeObject(db.Books);
        //    string strformat = string.Format("{0}({1})", callback, book);
        //    return new HttpResponseMessage()
        //    {
        //        StatusCode = HttpStatusCode.OK,
        //        Content = new StringContent(strformat, Encoding.UTF8)
        //    };
        //}

        /// <summary>
        ///获取图书列表
        /// </summary>
        /// <returns></returns>
        [EnableCors(origins: "http://localhost:35856", headers: "*", methods: "*")]
        public List<Book> GetFirstBook()
        {
            return db.Books.ToList();
        }

        /// <summary>
        /// 根据bookid获取book实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// 修改图书信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.ID)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 添加图书
        /// </summary>
        /// <param name="book">图书信息</param>
        /// <returns></returns>

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.ID }, book);
        }

        /// <summary>
        /// 删除图书
        /// </summary>
        /// <param name="id">图书编号</param>
        /// <returns></returns>
        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        /// <summary>
        /// 资源释放
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 图书是否存在
        /// </summary>
        /// <param name="id">图书编号</param>
        /// <returns></returns>
        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.ID == id) > 0;
        }
      
    }
}