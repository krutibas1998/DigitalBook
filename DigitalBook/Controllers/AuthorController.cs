using DigitalBook.Model;
using DigitalBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DigitalBook.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        //public static List<Book> books = new List<Book>();

        private readonly ConnectionDBContext dBContext;
        private readonly IBookService _bookServices;

        //public ConnectionDBContext dBContext { get; }

        public AuthorController(IBookService bookServices, ConnectionDBContext dBContext)
        {
            _bookServices = bookServices;
             this.dBContext = dBContext;
        }

        [HttpGet]
        public List<Book> GetBook()
        {
            return dBContext.Books.ToList();
        }

        [HttpPost]
        public ActionResult<string> insertBook([FromBody] Book book)
        {
            string result = _bookServices.AddBook(book);

            return Ok(result);
        }

        [HttpPut]
        public ActionResult<string> updateBook([FromBody] Book book)
        {
            string result = _bookServices.updateBook(Convert.ToInt32(book.bookId), book);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult<string> DeletedBook([FromBody]int bookId)
        {
            string result = _bookServices.DeletedBook(bookId);
            return Ok(result);
        }

    }
}