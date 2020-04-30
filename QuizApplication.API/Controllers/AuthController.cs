using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using QuizApplication.API.Models;
using QuizApplication.API.Services;

namespace QuizApplication.API.Controllers
{
[Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly IPasswordHasher<IdentityUser> hasher;
        private readonly ILogger<AuthController> logger;
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(IConfiguration config, SignInManager<IdentityUser> signInManager, IConfiguration configuration,
            IPasswordHasher<IdentityUser> hasher, ILogger<AuthController> logger, UserManager<IdentityUser> userManager )
        { 
            _config = config;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.hasher = hasher;
            this.logger = logger;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var returnMessage = "";
            if (!ModelState.IsValid)
                return BadRequest("Onvolledige gegevens.");
            try
            {
                var result = await signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, false);

                if (result.Succeeded)
                    return Ok("Welkom " + loginDTO.UserName);
                throw new Exception("User or password not found.");

            }
            catch (Exception ex)
            {

                returnMessage = $"Foutief of ongeldig request: {ex.InnerException.Message}";
                ModelState.AddModelError("", returnMessage);
            }
            return BadRequest(returnMessage);
        }


        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateJwtToken([FromBody]LoginDTO identityDTO)
        {
            try
            {
                var jwtsvc = new JWTServices<IdentityUser>(configuration,
                logger, userManager, hasher);
                var token = await jwtsvc.GenerateJwtToken(identityDTO);
                return Ok(token);
            }
            catch (Exception exc)
            {
                logger.LogError($"Exception thrown when creating JWT: {exc}");
            }
            //Bij niet succesvolle authenticatie wordt een Badrequest (=zo weinig

            return BadRequest("Failed to generate JWT token");
        }


    }
}
