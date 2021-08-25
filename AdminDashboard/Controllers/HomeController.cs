using AdminDashboard.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Controllers
{
    //[Area("/")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            //var claims = User.Claims.ToList();
            //var roleClaims = claims.Select(r => r.Type == "role").ToList();

            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            //var idToken = await HttpContext.GetTokenAsync("id_token");
            //var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);
            //var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            System.Security.Claims.ClaimsPrincipal currentUser = User;
            bool IsAdmin = currentUser.IsInRole("SuperAdmin");
            if(!IsAdmin)
                return RedirectToAction("Index", "Home", new { area = "SuperAdmin" });

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
