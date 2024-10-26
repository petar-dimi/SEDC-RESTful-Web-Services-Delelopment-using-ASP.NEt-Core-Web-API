using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Register
        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest("All fields are required.");
            }

            if (StaticDb.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest("User with this email already exists.");
            }

            StaticDb.Users.Add(user);
            return CreatedAtAction(nameof(Register), user);
        }

        // Login
        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] User loginUser)
        {
            var user = StaticDb.Users.FirstOrDefault(u => u.Email == loginUser.Email && u.Password == loginUser.Password);
            if (user == null) return Unauthorized();

            // Generate JWT token
            var token = GenerateToken(user);
            return Ok(new { Token = token });
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKey"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
