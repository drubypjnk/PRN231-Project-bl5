using BussinessObject.DTO;
using BussinessObject.Models;
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
		[HttpPost]
		public IActionResult Login([FromBody] UserDTO userDTO)
		{			
			var u = _context.Users.FirstOrDefault(x=>x.Username == userDTO.Username && x.Password == userDTO.Password);
			if(u != null) 
			{
				var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
				var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

				var tokenOptions = new JwtSecurityToken(
					_configuration["Jwt:Issuer"],
					_configuration["Jwt:Issuer"],
					null,
					expires: DateTime.Now.AddMinutes(120),
					signingCredentials: signingCredentials
					);
				var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
				return Ok(new { Token = tokenString });
			}
			else
			{
				return BadRequest();
			}
			
		}
		[HttpGet]
		[Authorize]
		public IActionResult Get()
		{
			return Ok(_context.Users.ToList());
		}

		[HttpGet("SearchByUserName/{username}")]
		[Authorize]
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
		[Authorize]
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
		[Authorize]
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
	}
}
