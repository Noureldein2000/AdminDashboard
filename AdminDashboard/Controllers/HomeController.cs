using AdminDashboard.Models;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdminDashboard.Controllers
{
    //[Area("/")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRolesApi _rolesApi;
        public HomeController(ILogger<HomeController> logger, IRolesApi rolesApi)
        {
            _logger = logger;
            _rolesApi = rolesApi;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login()
        {
            string userId = User.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Home");
            }

            var userRole = _rolesApi.ApiRolesGetUserRoleGet(userId);
            if(userRole == null)
            {
                return RedirectToAction("Index", "Home");
            }

            switch (userRole.Role)
            {
                case "SuperAdmin":
                    return RedirectToAction("Index", "Home", new { area = "SuperAdmin" });
                case "Operation":
                    return RedirectToAction("Index", "Home", new { area = "Operation" });
                default:
                    return RedirectToAction("Index", "Home");
            }


        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index));
        }
    }
}
