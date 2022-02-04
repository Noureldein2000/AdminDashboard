using AdminDashboard.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Controllers
{
   
    [Area("SuperAdmin")]
    [Route("SuperAdmin/[controller]")]
    [Authorize]
    public class HomeController : BaseController
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
