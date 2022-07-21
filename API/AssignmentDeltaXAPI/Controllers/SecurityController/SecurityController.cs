using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace AssignmentDeltaXAPI.Controllers.SecurityController
{
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private static User user = new();
        public SecurityController(IConfiguration _configuration)
        {
            this._configuration = _configuration;
            
        }
        [HttpPost]
        [Route("/register")]
        public ActionResult<User> postSecurity(UserDataTransferObject userDto)
        {
           
            createPassword(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.username = userDto.Username;

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDataTransferObject request)
        {
            if (user.username != request.Username)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

            return Ok(token);
        }
        void createPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
