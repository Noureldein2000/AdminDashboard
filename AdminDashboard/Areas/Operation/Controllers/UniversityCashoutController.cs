using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDashboard.Areas.Operation.Models;
using AdminDashboard.Models.SwaggerModels.SourceOFundSwaggerModels;
using AdminDashboard.SourceOfFundSwaggerClient;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Areas.Operation.Controllers
{
    [Area("Operation")]
    [Route("Operation/[controller]/{action}/{id?}")]
    [Authorize]
    public class UniversityCashoutController : Controller
    {
        private readonly IAccountsApi _accountsApi;

        public UniversityCashoutController(IAccountsApi accountsApi)
        {
            _accountsApi = accountsApi;
        }
        public IActionResult Index()
        {
            return View(new UniversityCashoutViewModelList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UniversityCashoutViewModelList model)
        {
            var generalTransferAccount = 92349;
            var checkbalances = _accountsApi.ApiAccountsCheckbalancesSeedPost(model.DataList.Select(s => new SeedBalancesModel(
                           accountId: s.AccountId,
                           amount: 100,
                           trasnsactionId: 0,
                           requestId: 0
                       )).ToList());

            if (checkbalances != null && !checkbalances.Value)
            {
                ModelState.AddModelError("File", "Error, one or more account type not exists");
                return View(model);
            }

            var sofResponse = _accountsApi.ApiAccountsAccountIdBalancesBalanceTypeIdGet(92349, 1);
            if (sofResponse == null || sofResponse.Code != 200)
            {
                ModelState.AddModelError("File", "Error, please check SOF service");
                return View(model);
            }

            var sumAmount = model.DataList.Sum(s => s.Amount);
            if ((decimal)sofResponse.TotalAvailableBalance <= sumAmount)
            {
                ModelState.AddModelError("File", "Error, Ledger account insufficient fund");
                return View(model);
            }

            Task.Run(() => _accountsApi.ApiAccountsAccountIdBalancesSeedPost(generalTransferAccount, model.DataList.Select(s => new SeedBalancesModel
                         (
                             accountId: s.AccountId,
                             amount: (double)s.Amount
                         //requestId: s.RequestId,
                         //trasnsactionId: s.TrasnactionId
                         )).ToList()));

            ViewBag.Succeeded = true;
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
