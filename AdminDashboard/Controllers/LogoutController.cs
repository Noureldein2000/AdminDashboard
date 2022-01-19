using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Controllers
{
    [Route("[controller]")]
    public class LogoutController : Controller
    {
        private readonly IAccountApi _accountApi;
        public LogoutController(IAccountApi accountApi)
        {
            _accountApi = accountApi;
        }
        public async Task<IActionResult> Logout()
        {

            _accountApi.logo
            return SignOut("Cookies", "oidc");
            //await HttpContext.SignOutAsync();
            //return RedirectToAction("Index", "Home");
        }
    }
}
