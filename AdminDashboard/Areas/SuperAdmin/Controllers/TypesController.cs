using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Route("SuperAdmin/[controller]/{action}/{id?}")]
    [Authorize]
    public class TypesController : Controller
    {
        private readonly ILookupTypeApi _apiLookups;
        public TypesController(ILookupTypeApi apiLookups)
        {
            _apiLookups = apiLookups;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _apiLookups.ApiLookupTypeGetAllLookupTypesGetAsync();
            var groupedData = data.GeneralLookups.GroupBy(d => d.IdentifierType).Select(d => new LookupTypesViewModel
            {
                IdentifierType = d.Key,
                GeneralLookups = d.Select(s => new LookupTypeViewModel
                { 
                    Id = (int)s.Id,
                    Name = s.Name,
                    NameAr = s.NameAr
                }).ToList()
            }).ToList();

            return View(groupedData);
        }

        [HttpPost]
        public JsonResult CreateLookupType(AddLookupTypeViewModel viewModel)
        {
            var model = _apiLookups.ApiLookupTypeAddLookupTypePost(new GeneralLookupTypeModel(
                  name: viewModel.Name,
                  nameAr: viewModel.NameAr,
                  identifierType: viewModel.IdentifierType));
            return Json(model);
        }
    }
}
