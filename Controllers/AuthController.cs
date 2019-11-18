using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using server.data;
using server.Dtos;
using server.Models;

namespace server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthRepository _repo;
		private readonly IConfiguration _config;
		public AuthController(IAuthRepository repo, IConfiguration config)
		{
			_config = config;
			_repo = repo;
		}

        [HttpPost("register")]
		public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
		{
			Console.WriteLine("params:");
			
			Console.WriteLine(userForRegisterDto.Username);
			Console.WriteLine(userForRegisterDto.Password);
			
			var username = userForRegisterDto.Username;
			var password = userForRegisterDto.Password;
			// validate request
			username = username.ToLower();

			if (await _repo.UserExists(username))
			{
				return BadRequest("Username already exist");
			}

			var userToCreate = new User
			{
				Username = username
			};

			var createdUser = await _repo.Register(userToCreate, password);
			//TODO: come back and change this into CreatedAtRoute(...)
			return StatusCode(201);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
		{
			var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
			if (userFromRepo == null)
			{
				return Unauthorized();
			}
			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
				new Claim(ClaimTypes.Name, userFromRepo.Username),
			};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
		}
	}
}
