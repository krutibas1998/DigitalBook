using DigitalBook.Model;
using DigitalBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigitalBook.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        

        private readonly ConnectionDBContext dBContext;
        private readonly IBookService _bookServices;


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
         
        [HttpPost("insertBook")]
            
            
        public ActionResult<string> insertBook([FromBody] Book book)
        {
           // var identity = HttpContext.User.Identities as ClaimsIdentity;
            string result = _bookServices.AddBook(book);
            //if (identity == null)
            //{
            //    return Unauthorized("You don't have permission!!");
            //}
            //AppClaims appClaims = new AppClaims(identity);
            //if (appClaims.userType.ToUpper() != "A")
            //{
            //    return Unauthorized("You don't have permission!!");
            //}

            //string result = _bookServices.AddBook(book);

            return Ok(result);
        }
        [HttpPost("LogIn")]
        public ActionResult<string> LogIn([FromBody] User user)
        {
            string result = _bookServices.LogIn(user);

            return result;
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