using DigitalBook.Model;
using DigitalBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DigitalBook.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
       
        private readonly ConnectionDBContext dbContext;
        private readonly IUserService _userService;

        public ReaderController(IUserService userService, ConnectionDBContext dbContext)
        {
            _userService = userService;
            this.dbContext = dbContext;
            
        }
        [HttpGet("GetAllBook")]
        public List<Book> GetBook()
        {
            return dbContext.Books.ToList();
        }
        [HttpPost("SearchBooks")]
        public List<Book> SearchBook([FromBody] Book book)
        {
            try
            {
               return _userService.SearchBook(book);
            }
            catch(Exception ex)
            {
                return new List<Book>();
            }
            
            
        }
        [HttpPost("BuyBook")]
        public ActionResult<string> BuyBook([FromBody] Payment payment)
        {
            string result = _userService.Buy(payment);

            return Ok(result);
        }

        [HttpGet]
        public List<User> GetUser()
        {

            return dbContext.Users.ToList();
        }

        [HttpPost]
        public ActionResult<string> AddUser([FromBody] User user)
        {
            string result = _userService.AddUser(user);

            return Ok(result);
        }


        [HttpPut]
        public ActionResult<string> ModifiedUser([FromBody] User user)
        {
            string result = _userService.ModifiedUser(Convert.ToInt32( user.userId), user);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult<string> deleteUser([FromBody] int userId)
        {
            string result = _userService.DeletedUser(userId);
            return Ok(result);
        }


    }
}
