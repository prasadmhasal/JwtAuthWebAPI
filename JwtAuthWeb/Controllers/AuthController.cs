using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JwtAuthWeb.Entities;
using JwtAuthWeb.Model;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using JwtAuthWeb.Services;
using Microsoft.AspNetCore.Authorization;

namespace JwtAuthWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthservices service;
        public AuthController(IAuthservices service)
        {
          this.service = service;
        }
        private static User user = new();
        private readonly IConfiguration configuration;

        [HttpPost("register")]

        public async Task<ActionResult<User?>> Register(Userdto request)
        {

            var user = await service.RegisterAsync(request);
            if (user == null) 
            {
                return BadRequest("User Alreday Exists");
            }

            return Ok(user);

        }

        [HttpPost("Login")]
        public  async Task<ActionResult<TokenResponceDto>> Login(Userdto request)
        {
            var token = await service.LoginAsync(request);
            if (token is null )
            {
                return BadRequest("User/Password Are Incorrected");
            }
            return Ok(token);


        }


        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponceDto>> RefreshToken(RefreshRequestToken request)
        {
            var token = await service.RefreshTokenAsync(request);
            if (token is null)
            {
                return BadRequest("Token Invalid Or Expire");
            }
            return Ok(token);


        }

        [HttpGet("Auth-endpoint")]
        [Authorize]

        public ActionResult AuthCheck()
        {
            return Ok();
        }

        [HttpGet("Admin-endpoint")]
        [Authorize(Roles ="Admin")]

        public ActionResult AdminCheck()
        {
            return Ok();
        }

        [HttpPost("User-DeActivate")]

        public async Task<ActionResult> DeActivateUser(UserDecativationDto request)
        {
            var user = await service.DeActivateUser(request);
            if (user is null)
            {
                return BadRequest("User Not Found / Or User Alredy DeAtived ");
            }
            return Ok(user);
        }



    }
}
