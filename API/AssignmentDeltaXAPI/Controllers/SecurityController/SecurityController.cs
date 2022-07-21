using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace AssignmentDeltaXAPI.Controllers.SecurityController
{
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpPost]
        [Route("/register")]
        public ActionResult<User> postSecurity(UserDataTransferObject userDto)
        {
            createPassword(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new();
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.username = userDto.Username;

            return Ok(user);
        }
        void createPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
