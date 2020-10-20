using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UstaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using UstaApi.Models.Auth;

namespace UstaApi.Controllers
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private List<AppUser> appUsers = new List<AppUser>
        {
            
            new AppUser {Name = "Rustam", Surname = "Aliyev", Password="Nazmeke31!", UserName = "RusAl311", Email = "rustamm.aliyev@gmail.com", UserRole = "Admin"},
            new AppUser {Name = "Mehdi", Surname = "Mammadov", Password="Nazmeke31@", UserName = "Mmuxa", Email = "muxa@muxa.com", UserRole = "User"}
        };

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] AppUser login)
        {
            IActionResult response = Unauthorized();
            AppUser user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJWTToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }

            return response;
            
        }

        AppUser AuthenticateUser(AppUser loginCredentials)
        {
            AppUser user = appUsers.SingleOrDefault(x => x.UserName == loginCredentials.UserName && x.Password == loginCredentials.Password);
            return user;
        }

        string GenerateJWTToken(AppUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"])); 
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); 
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("name", userInfo.Name.ToString()),
                new Claim("role",userInfo.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }; 
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"], 
                audience: _config["Jwt:Audience"], 
                claims: claims, 
                expires: DateTime.Now.AddMinutes(30), 
                signingCredentials: credentials
                ); 
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}