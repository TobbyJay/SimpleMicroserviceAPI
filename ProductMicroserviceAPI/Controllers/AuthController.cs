using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductMicroserviceAPI.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginModel model)
		{
			// Implement your authentication logic here (e.g., validate user credentials)
			if (AuthenticateUser(model.Username, model.Password))
			{
				// Create and return a JWT token
				var token = GenerateJwtToken(model.Username);
				return Ok(new { token });
			}

			return Unauthorized();
		}

		private bool AuthenticateUser(string username, string password)
		{
			// Replace this with your authentication logic (e.g., check against a user database)
			return username == "yourusername" && password == "yourpassword";
		}

		private string GenerateJwtToken(string username)
		{
			// Create and sign a JWT token
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKey"));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: "Sample Issuer",
				audience: "Sample Audience",
				claims: new[] { new Claim(ClaimTypes.Name, username) },
				expires: DateTime.UtcNow.AddHours(1),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}

	public class LoginModel
	{
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
