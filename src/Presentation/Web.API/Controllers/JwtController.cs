using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web.API.Models;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ApiControllerBase
    {
        public IConfiguration _configuration { get; set; }
        public JwtController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (user != null && user.Username != null && user.Password != null)
            {

                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if (jwt.Username == user.Username && jwt.Password == user.Password)
                {
                    var claims = new[] {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub,jwt.Subject),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                    new Claim("UserName",user.Username),
                    new Claim("Password",user.Password)
                };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                        );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Credentials");

                }
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }
    }
}
