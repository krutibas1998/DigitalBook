using DigitalBook.Model;
using DigitalBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBook.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        //public static List<User> userlist = new List<User>();
        private readonly ConnectionDBContext dbContext;
        private readonly IUserService _userService;

        public ReaderController(IUserService userService, ConnectionDBContext dbContext)
        {
            _userService = userService;
            this.dbContext = dbContext;
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
