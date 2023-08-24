using BussinessObject.DTO;
using BussinessObject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Warehouse_Management.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenController : ControllerBase
	{
		private readonly PRN231_BL5Context _context;
		private readonly IConfiguration _configuration;
		public AuthenController(PRN231_BL5Context context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}
		private List<User> _users = new List<User>();
        
		[HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            var user = await _context.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Username == userDTO.Username && u.Password == userDTO.Password);
            if (user == null)
            {
                return BadRequest();
            }

            var jwtSection = _configuration.GetSection("JWT");
            var secretKey = jwtSection["SecretKey"];
            var key = Encoding.UTF8.GetBytes(secretKey);

            var roles = user.Roles.Select(role => role.RoleName).ToArray();
            var claims = new List<Claim>
            {
                  new Claim(ClaimTypes.Name, user.Username)

             };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Audience = "AudienceKey",
                Issuer = "IssuerKey",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            user.Token = tokenString;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok(tokenString);
        }
        [HttpGet]
		
		public IActionResult Get()
		{
			return Ok(_context.Users.ToList());
		}

		[HttpGet("SearchByUserName/{username}")]
		
		public IActionResult SearchUser(string username)
		{
			var user = new List<User>();
			try
			{
				using(var context = new PRN231_BL5Context())
				{
					user = context.Users.Where(x => x.Username.Contains(username)).ToList();
				}
			}catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return Ok(user);
		}

		[HttpGet("SearchById/{id}")]
		
		public IActionResult SearchById(int id)
		{
			var user = new List<User>();
			try
			{
				using(var context = new PRN231_BL5Context())
				{
					user = context.Users.Where(x => x.UserId == id).ToList();
				}
			}catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return Ok(user);
		}

		[HttpPut("{id}/{deleteFlag}")]
		
		public IActionResult UpdateDeleteFlag(bool deleteFlag, int id)
		{
			using(var context = new PRN231_BL5Context())
			{
				var user = context.Users.Find(id);
				if(user != null)
				{
					user.DeleteFlag = deleteFlag;
					context.Users.Update(user);
					context.SaveChanges();
				}
			}
			return Ok();
		}

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Ok("Logout successfull");
        }
    }
}
