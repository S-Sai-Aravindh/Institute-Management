using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Institute_Management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Institute_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly InstituteContext _context;

        public AuthController(InstituteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModule.User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        //public async Task<ActionResult<UserModule.User>> GetUser(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return user;
        //}

        //[HttpGet]
        public async Task<IActionResult> AuthenticateUser([FromQuery] string email, [FromQuery] string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest(new { message = "Email and Password are required." });
            }

            // Find user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            // Check if the passwords match (In production, use hashed passwords)
            if (user.Password != password)
            {
                return Unauthorized(new { message = "Invalid credentials." });
            }

            // Return user information if authenticated
            return Ok(new
            {
                message = "Login successful",
                UserId = user.UserId,
                Name = user.Name,
                Role = user.Role,
                Email = user.Email,
                ContactDetails = user.ContactDetails
            });
        }

        // Handles login via POST /api/auth
        [HttpPost]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserModule.User request)
        {
            return await Authenticate(request);
        }

        // Handles login via POST /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserModule.User request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Email and Password are required." });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            if (user.Password != request.Password) // Use hashed passwords in production
            {
                return Unauthorized(new { message = "Invalid credentials." });
            }

            return Ok(new
            {
                message = "Login successful",
                UserId = user.UserId,
                Name = user.Name,
                Role = user.Role,
                Email = user.Email,
                ContactDetails = user.ContactDetails
            });
        }

    }
}