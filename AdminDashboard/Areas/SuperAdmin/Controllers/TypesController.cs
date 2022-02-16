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
            try
            {
                var model = _apiLookups.ApiLookupTypeAddLookupTypePost(new GeneralLookupTypeModel(
                  name: viewModel.Name,
                  nameAr: viewModel.NameAr,
                  identifierType: viewModel.IdentifierType));
                return Json(model);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public JsonResult Delete(int id, LookupType identifier)
        {
            try
            {
                _apiLookups.ApiLookupTypeDeleteLookupTypeIdDelete(id: id, lookup: identifier);
                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetLookupTypeById(int id, LookupType identifier)
        {
            try
            {
                var model = _apiLookups.ApiLookupTypeGetLookupTypeByIdIdGet(id: id, lookup: identifier);
                return Json(model);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        [HttpPost]
        public JsonResult EditLookupType(EditLookupTypeViewModel viewModel)
        {
            try
            {
                _apiLookups.ApiLookupTypeEditLookupTypePost(new GeneralLookupTypeModel(
                    id: viewModel.Id,
                     name: viewModel.Name,
                     nameAr: viewModel.NameAr,
                     identifierType: viewModel.IdentifierType));

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }
    }
}
