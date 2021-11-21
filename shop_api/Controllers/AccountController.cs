using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace shop_api.Controllers
{
    [ApiController]
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signinManager;
        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signinMgr)
        {
            userManager = userMgr;
            signinManager = signinMgr;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<string> Login(string login, string pass)
        {
            if (login == null || pass == null) return "";
            IdentityUser user = await userManager.FindByNameAsync(login);
            if (user != null)
            {
                await signinManager.SignOutAsync();

                var sr = await signinManager.PasswordSignInAsync(user, pass, false, false);

                if (sr.Succeeded)
                {
                    var claims = new List<Claim> { 
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserName)
                    };
                    
                    ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                    var now = System.DateTime.UtcNow;
                    // создаем JWT-токен
                    var jwt = new JwtSecurityToken(
                            issuer: AuthOptions.ISSUER,
                            audience: AuthOptions.AUDIENCE,
                            notBefore: now,
                            claims: claimsIdentity.Claims,
                            expires: now.Add(System.TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                    return encodedJwt;
                }
            }
            return "";
        }

        [HttpPost("Logout")]
        public async Task<bool> Logout()
        {
            await signinManager.SignOutAsync();
            return true;
        }
    }
}
