using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminDashboard.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Areas.Operation.Controllers
{
    [Area("Operation")]
    [Route("Operation/[controller]")]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
