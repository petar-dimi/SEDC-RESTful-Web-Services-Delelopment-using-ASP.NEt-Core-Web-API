using Homework_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetUsers()
        {
            return Ok(StaticDb.Users);
        }

      
        [HttpGet("{name}")]
        public ActionResult<string> GetUser(string name)
        {
            var user = StaticDb.Users.FirstOrDefault(u => u.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
