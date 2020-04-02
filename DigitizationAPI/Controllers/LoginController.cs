using DigitizationAPI.DbContexts;
using DigitizationAPI.Entities;
using DigitizationAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DigitizationAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _iConfig;
        private readonly IndividualsDbContext _individualsDbContext;

        public LoginController(IConfiguration iConfig, IndividualsDbContext context)
        {
            _iConfig = iConfig ?? throw new Exception(nameof(iConfig));
            _individualsDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost("login")]
        public IActionResult login([FromBody] UserLoginDto userLoginDto)
        {
            IActionResult response = Unauthorized();

            User user = _individualsDbContext.Users.Where(i => i.Username == userLoginDto.Username
                                        && i.Password == userLoginDto.Password).FirstOrDefault();

            if (user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }
            return response;
        }

        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iConfig["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _iConfig["JWT:Issuer"],
                audience: _iConfig["JWT:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
                );

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }
    }
}
