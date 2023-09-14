using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients;
using TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Company;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Company;

namespace TransportGlobalWeb.UI.Controllers
{
    public class TransporterController : BaseController
    {
        private readonly CompanyClient _transporterContextClient;

        public TransporterController(CompanyClient transporterContextClient)
        {
            _transporterContextClient = transporterContextClient;
        }

        [HttpGet]
        public IActionResult GetOwnCompany()
        {
            ApiResponseModel<GetCompanyResponseModel>? apiResponse = _transporterContextClient.GetOwnCompany();

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            return CreateActionResult(apiResponse, onData);
        }

        [HttpGet]
        public IActionResult GetCompany(int id)
        {
            ApiResponseModel<GetCompanyResponseModel>? apiResponse = _transporterContextClient.GetCompanyByID(id);

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
           ApiResponseModel<NonDataResponseModel>? apiResponse = _transporterContextClient.CreateCompany(createCompanyRequestModel);
            return CreateActionResult(apiResponse, null);
        }

        public IActionResult UpdateCompany()
        {
            ApiResponseModel<GetCompanyResponseModel>? apiResponse = _transporterContextClient.GetOwnCompany();

            IActionResult onData()
            {
                UpdateCompanyRequestModel requestModel = new()
                {
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
            ApiResponseModel<NonDataResponseModel>? apiResponse = _transporterContextClient.UpdateCompany(updateCompanyRequestModel);
            return CreateActionResult(apiResponse, null, updateCompanyRequestModel);
        }

        public IActionResult DeleteCompany(int id)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _transporterContextClient.DeleteCompany(id);

            return CreateActionResult(apiResponse, null, id);
        }
    }
}
