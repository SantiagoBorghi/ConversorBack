using ConversorBack.DTOs;
using ConversorBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConversorBack.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public AuthController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;

        }

        [HttpPost("authenticate")]
        public IActionResult Autenticar(AuthDto authDto)
        {

            var user = _userService.Validate(authDto.Email, authDto.Password);

            if (user is null)
                return Unauthorized();


            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("nombre", user.Username));

            var jwtSecurityToken = new JwtSecurityToken(
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(3),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
    }
}
