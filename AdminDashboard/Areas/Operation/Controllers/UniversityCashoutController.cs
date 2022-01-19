using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Areas.Operation.Controllers
{
    [Area("Operation")]
    [Route("Operation/[controller]/{action}/{id?}")]
    [Authorize]
    public class UniversityCashoutController : Controller
    {
        public UniversityCashoutController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
