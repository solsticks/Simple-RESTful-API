using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RestfulAPI.Web.DTOs;
using RestfulAPI.Web.Entities;
using RestfulAPI.Web.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulAPI.Web.Controllers
{
    [Authorize (AuthenticationSchemes = "Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repository;


        public UserController(ILogger<UserController> logger, UserManager<User> userManager, IConfiguration configuration, IUserRepository repository)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
            _repository = repository;
        }
  
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _repository.GetUsers();
            return Ok(users);
        }


        [HttpGet("page")]
        public IActionResult GetByPage(int pageNumber)
        {
            var UserList = _repository.GetUsersByPage(pageNumber);
            return Ok(UserList);
        }

        // POST api/<UserController>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO user)
        {
            if(user.Password != user.ConfirmPassword)
            {
                return BadRequest("Password mismatch");
            }
            if (ModelState.IsValid)
            {
                var result = await _repository.RegisterNewUser(user);
                if (result)
                {
                    return Ok("Registration Successful");
                }
            }
            return BadRequest();
        }
        [AllowAnonymous]
        [HttpPost("getToken")]
        public IActionResult GetToken([FromBody]EmailDTO email) // this is where the token is generated
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Email == email.Email);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.LastName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult Login(EmailDTO email) // this logs a user in if the email already exist
        {
            var userDetails = _repository.GetLoggedinUserDetails(email);
            if(userDetails != null)
            {
                return Ok(userDetails);
            }
            return BadRequest("Email does not exist");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
