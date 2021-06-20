using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Api.DataAccess;
using ECommerce.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration) {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserModel userModel) {
            try {
                if (userModel == null)
                    return BadRequest("Login failed");

                var identityUser = await _userManager.FindByNameAsync(userModel.UserName);
                if (identityUser == null)
                    return BadRequest("Login failed");

                var result = _userManager.PasswordHasher.VerifyHashedPassword(
                    identityUser, identityUser.PasswordHash, userModel.Password);
                if (result == PasswordVerificationResult.Failed)
                    return BadRequest("Login failed");

                var authClaims = new List<Claim>
                {
                    new(ClaimTypes.Name, userModel.UserName),
                    new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new (ClaimTypes.Role, "Administrators")
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    userId = identityUser.Id,
                    expiration = token.ValidTo
                });
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserModel userModel) {
            try {
                if (userModel == null)
                    return BadRequest("Invalid Registration");

                var identityUser = new ApplicationUser {
                    UserName = userModel.UserName,
                    Email = userModel.UserName
                };

                var result = await _userManager.CreateAsync(identityUser, userModel.Password);
                if (result.Succeeded)
                    return Ok("User Registration Successful");

                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors) {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return BadRequest(new { Errors = dictionary });
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
