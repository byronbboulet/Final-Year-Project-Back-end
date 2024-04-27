using Microsoft.AspNetCore.Mvc;
using MentalHealthAppAPI.Data;
using MentalHealthAppAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MentalHealthAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // POST: api/Users/signup
        [HttpPost("signup")]
        public async Task<ActionResult<User>> Signup(User userDto)
        {
            if (await _context.Users.AnyAsync(x => x.Username == userDto.Username))
            {
                return BadRequest("Username is already taken.");
            }

            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = userDto.PasswordHash,
                ProfileImage = userDto.ProfileImage
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { user.Id, user.Username, user.Email });
        }

        // POST: api/Users/login
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null || user.PasswordHash != loginDto.Password)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { user.Id, user.Username, user.Email, user.ProfileImage });
        }
    }
}
