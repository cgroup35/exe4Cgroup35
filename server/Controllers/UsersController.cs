using exe1HW.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace exe1HW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            User u = new User();
            return u.Read();
        }

        // GET api/<UsersController>/5
        [HttpGet("email/{email}/password/{password}")]
        public List<User> Get(string email,string password)
        {
            User u = new User();
            return u.ReadByEmail(email,password);
        }

        // POST api/<UsersController>
        [HttpPost]
        public int Post([FromBody] User user)
        {
            return user.Insert();
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public int Put([FromBody] User user)
        {
            
            return user.Update();
        }
        [HttpPut("admin")]
        public List<User> Putadmin([FromBody] User user)
        {

            return user.UpdateAdmin();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{email}")]
        public IActionResult Delete(string  email)
        {
            
            User u = new User();
            List<User> ulist = new List<User>();
            ulist = u.Delete(email);
            if (ulist.Count>0)
            {
                return Ok(ulist);
            }
            return BadRequest("Error: This user have at least one vacation. can't delete user with an order.");
        }
    }
}
