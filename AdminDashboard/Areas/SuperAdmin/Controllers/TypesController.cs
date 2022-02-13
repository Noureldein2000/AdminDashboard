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
            return View(new LookupTypesViewModel()
            {
                Fees = { Types = data.Fees.Select(x => MapToViewModel(x)).ToList(), IdentitfierType = LookupType.FeesType },
                Commissions = { Types = data.Commissions.Select(x => MapToViewModel(x)).ToList(), IdentitfierType = LookupType.CommissionType },
                Taxes = { Types = data.Taxes.Select(x => MapToViewModel(x)).ToList(), IdentitfierType = LookupType.TaxesType },
            });
        }

        [HttpPost]
        public JsonResult CreateLookupType(LookupTypeViewModel viewModel)
        {
            var model = _apiLookups.ApiLookupTypeAddLookupTypePost(new GeneralLookupTypeModel(
                  name: viewModel.Name,
                  nameAr: viewModel.NameAr,
                  identifierType: viewModel.IdentitfierType));
            return Json(MapToViewModel(model));
        }

        private LookupTypeViewModel MapToViewModel(GeneralLookupTypeModel model)
        {
            return new LookupTypeViewModel
            {
                Id = (int)model.Id,
                Name = model.Name,
                NameAr = model.NameAr,
                IdentitfierType = model.IdentifierType
            };
        }
    }
}
