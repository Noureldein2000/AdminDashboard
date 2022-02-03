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

        //List<LookupType> fees = new List<LookupType>()
        //{
        //    new LookupType {Id=1,Name="Service Fees1",NameAr="رسوم الخدمة1" },
        //    new LookupType {Id=2,Name="Service Fees2",NameAr="رسوم الخدمة2" },
        //    new LookupType {Id=3,Name="Service Fees3",NameAr="3رسوم الخدمة" }
        //};

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _apiLookups.ApiLookupTypeGetAllLookupTypesGetAsync();
            return View(new LookupTypeViewModel()
            {
                Fees = data.Fees.Select(x => MapToViewModel(x)).ToList(),
                Commissions = data.Commissions.Select(x => MapToViewModel(x)).ToList(),
                Taxes = data.Taxes.Select(x => MapToViewModel(x)).ToList(),
            });
        }

        [HttpPost]
        public JsonResult CreateLookupType(GeneralLookupTypeViewModel viewModel)
        {
            var model = _apiLookups.ApiLookupTypeAddLookupTypePost(new GeneralLookupTypeModel(
                  name: viewModel.Name,
                  nameAr: viewModel.NameAr,
                  identifierType: viewModel.IdentitfierType));
            return Json(MapToViewModel(model));
        }

        private GeneralLookupTypeViewModel MapToViewModel(GeneralLookupTypeModel model)
        {
            return new GeneralLookupTypeViewModel
            {
                Id = (int)model.Id,
                Name = model.Name,
                NameAr = model.NameAr,
                IdentitfierType = (int)model.IdentifierType
            };
        }
    }
}
