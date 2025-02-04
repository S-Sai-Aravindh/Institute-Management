using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Institute_Management.Models;
//using Institute_Management.Models.UserModule.cs;
//using Institute_Management.DTOs;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest("Invalid login request.");
            }

            // Find the user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || user.Password != loginDto.Password) // In production, use hashed passwords
            {
                return Unauthorized("Invalid email or password.");
            }

            // Return user role and any other necessary information
            return Ok(new
            {
                user.UserId,
                user.Name,
                user.Role,
                user.Email,
                user.Password
            });
        }
    }
}
