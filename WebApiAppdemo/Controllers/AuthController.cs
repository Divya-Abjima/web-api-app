using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiAppdemo.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public class AuthRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }
        private class UserInfo
        {
            public int UserId { get; set; }
            public string UserName { get; set;}
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool IsAdmin { get; set; }

            public UserInfo(int userId, string userName, string firstName, string lastName, bool isAdmin)
            {
                UserId = userId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
                IsAdmin = isAdmin;
            }
            
        }
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthRequestBody authRequestBody)
        {
            //validate credentials
            var user = ValidateUser(authRequestBody.UserName, authRequestBody.Password);
            if(user== null)
            {
                return Unauthorized();
            }

            //create token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);
            var clainsForToken = new List<Claim>();
            clainsForToken.Add(new Claim("sub", user.UserId.ToString()));
            clainsForToken.Add(new Claim("given_name", user.FirstName));
            clainsForToken.Add(new Claim("family_name", user.LastName));
            clainsForToken.Add(new Claim("admin", user.IsAdmin.ToString().ToLower()));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                clainsForToken,
                DateTime.UtcNow,                      //start of token validity
                DateTime.UtcNow.AddHours(1),          //end of token validity
                signingCredentials);
            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return tokenToReturn;
        }

        private UserInfo ValidateUser(string? userName, string? password)
        {
            return new UserInfo(
                1,
                userName ?? "",
                "Divya",
                "Udayan",
                true);
        }
    }
}
