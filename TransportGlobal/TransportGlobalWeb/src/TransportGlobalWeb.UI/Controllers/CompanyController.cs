using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients;
using TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Company;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ViewModels.TransporterContextViewModels;

namespace TransportGlobalWeb.UI.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly CompanyClient _companyClient;

        public CompanyController(CompanyClient companyClient)
        {
            _companyClient = companyClient;
        }

        public IActionResult GetOwnCompany()
        {
            ApiResponseModel<CompanyViewModel>? apiResponse = _companyClient.GetOwnCompany();

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult GetCompanyByID(int id)
        {
            ApiResponseModel<CompanyViewModel>? apiResponse = _companyClient.GetCompanyByID(id);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCompany(CreateCompanyRequestModel createCompanyRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _companyClient.CreateCompany(createCompanyRequestModel);
            return CreateActionResult(apiResponse, null);
        }

        public IActionResult UpdateCompany()
        {
            ApiResponseModel<CompanyViewModel>? apiResponse = _companyClient.GetOwnCompany();

            IActionResult onData()
            {
                UpdateCompanyRequestModel requestModel = new()
                {
                    ID = apiResponse!.Data!.ID,
                    Address = apiResponse!.Data!.Address,
                    Email = apiResponse!.Data!.Email,
                    Name = apiResponse!.Data!.Name,
                    PhoneNumber = apiResponse!.Data!.PhoneNumber
                };
                return View(requestModel);
            }

            return CreateActionResult(apiResponse, onData);
        }

        [HttpPost]
        public IActionResult UpdateCompany(UpdateCompanyRequestModel updateCompanyRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _companyClient.UpdateCompany(updateCompanyRequestModel);
            return CreateActionResult(apiResponse, null, updateCompanyRequestModel);
        }

        public IActionResult DeleteCompany(int id)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _companyClient.DeleteCompany(id);
            return CreateActionResult(apiResponse, null, actionName: "GetOwnCompany");
        }
    }
}
