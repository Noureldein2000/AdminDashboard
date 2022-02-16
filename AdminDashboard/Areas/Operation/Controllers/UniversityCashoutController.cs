using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDashboard.Areas.Operation.Models;
using AdminDashboard.Constants;
using AdminDashboard.Services;
using ExcelDataReader;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace AdminDashboard.Areas.Operation.Controllers
{
    [Area("Operation")]
    [Route("Operation/[controller]/{action}/{id?}")]
    [Authorize]
    public class UniversityCashoutController : Controller
    {
        private readonly IIntegrations _integrations;

        public UniversityCashoutController(IIntegrations integrations)
        {
            _integrations = integrations;
        }
        public async Task<IActionResult> Index()
        {
            return View(new UniversityCashoutViewModelList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UniversityCashoutViewModelList model)
        {
            var serviceId = 639;
            var result = await _integrations.InvokeSeedUniversityCashout(serviceId, new AdminDashboard.Models.UniversityCashoutSeedListModel
            {
                Accounts = model.DataList.Select(x => new AdminDashboard.Models.UniversityCashoutSeedModel
                {
                    AccountId = x.AccountId,
                    Amount = x.Amount
                }).ToList()
            });

            ViewBag.Succeeded = result.Select(x => x.Key).FirstOrDefault();
            ViewBag.ResultData = result.Select(x => x.Value).FirstOrDefault();
            if (result.Select(x => x.Key).FirstOrDefault() != ResponceStatus.Success)
            {
                return View(new UniversityCashoutViewModelList
                {
                    DataList = model.DataList
                });
            }
            return View(new UniversityCashoutViewModelList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Upload(IFormFile upload)
        {
            var viewModelList = new List<UniversityCashoutViewModel>();
            var viewModel = new UniversityCashoutViewModelList();

            if (!ModelState.IsValid)
            {
                return View(nameof(Index), viewModel);
            }

            if (upload == null || upload.Length <= 0)
            {
                ModelState.AddModelError("File", "Please Upload Your file");
                return View(nameof(Index), viewModel);
            }

            IExcelDataReader reader = null;

            using (var memoryStream = new MemoryStream())
            {
                await upload.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length >= 2097152)
                {
                    ModelState.AddModelError("File", "The file is too large.");
                    return View(nameof(Index), viewModel);
                }

                if (upload.FileName.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(memoryStream);
                }
                else if (upload.FileName.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(memoryStream);
                }
                else
                {
                    ModelState.AddModelError("File", "This file format is not supported");
                    return View(nameof(Index), viewModel);
                }
                DataTable dt_ = new DataTable();
                try
                {
                    dt_ = reader.AsDataSet().Tables[0];

                    // validate columns names
                    if (dt_.Rows[0][0].ToString() != "AccountID" || dt_.Rows[0][1].ToString() != "Amount")
                    {
                        ModelState.AddModelError("File", "Please make sure that table has 2 columns headers (fist col: AccountID) and (second col: Amount)");
                        return View(nameof(Index), viewModel);
                    }

                    for (int row_ = 1; row_ < dt_.Rows.Count; row_++)
                    {
                        viewModelList.Add(new UniversityCashoutViewModel
                        {
                            AccountId = int.Parse(dt_.Rows[row_][0].ToString()),
                            Amount = decimal.Parse(dt_.Rows[row_][1].ToString())
                        });
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("File", "Unable to Upload file!");
                    return View(nameof(Index), viewModel);
                }
                reader.Close();
                reader.Dispose();
            }
            viewModel.DataList = viewModelList;
            return View(nameof(Index), viewModel);
        }


    }
}
