using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients.TransportContextApiClients;
using TransportGlobalWeb.UI.Enums;
using TransportGlobalWeb.UI.Enums.UserContextEnums;
using TransportGlobalWeb.UI.Helpers;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.CookieModels;
using TransportGlobalWeb.UI.Models.RequestModels.TransportContextRequestModels.TransportRequest;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.TransportResponseModels.TransportRequest;

namespace TransportGlobalWeb.UI.Controllers
{
    public class TransportRequestController : BaseController
    {
        private readonly TransportRequestClient _transportRequestClient;
        private readonly ApiEndpointsConfigurationModel _configurationModel;

        public TransportRequestController(TransportRequestClient transportRequestClient, ApiEndpointsConfigurationModel configurationModel)
        {
            _transportRequestClient = transportRequestClient;
            _configurationModel = configurationModel;
        }

        public IActionResult Index(int page = 0)
        {
            string? userCookieJson = CookieHelper.GetCookie(CookieKey.User);
            UserCookieModel? userCookieModel = userCookieJson == null ? null : BaseCookieModel.FromJson<UserCookieModel>(userCookieJson);


            if (userCookieModel!.UserType == UserType.Customer)
            {
                ApiResponseModel<GetAllTransportRequestsResponseModel>? apiResponse = _transportRequestClient.GetOwnTransportRequests(page);

                IActionResult onData()
                {
                    return View(apiResponse!.Data!);
                }

                ViewData["Page"] = page;
                ViewData["UserType"] = userCookieModel.UserType;

                return CreateActionResult(apiResponse, onData);
            }
            else if (userCookieModel.UserType == UserType.Shipper)
            {
                ApiResponseModel<GetAllTransportRequestsResponseModel>? apiResponse = _transportRequestClient.GetPendingTransportRequests(page);

                IActionResult onData()
                {
                    return View(apiResponse!.Data!);
                }

                ViewData["Page"] = page;
                ViewData["UserType"] = userCookieModel.UserType;

                return CreateActionResult(apiResponse, onData);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IActionResult GetTransportRequestByID(int id)
        {
            ApiResponseModel<GetTransportRequestResponseModel>? apiResponse = _transportRequestClient.GetTransportRequestByID(id);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult CreateTransportRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTransportRequest(CreateTransportRequestModel createTransportRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _transportRequestClient.CreateTransportRequest(createTransportRequestModel);

            return CreateActionResult(apiResponse, null);
        }

        public IActionResult UpdateTransportRequest(int id)
        {
            ApiResponseModel<GetTransportRequestResponseModel>? apiResponse = _transportRequestClient.GetTransportRequestByID(id);

            IActionResult onData()
            {
                UpdateTransportRequestModel requestModel = new()
                {
                    ID = apiResponse!.Data!.ID,
                    TransportType = apiResponse!.Data!.TransportType,
                    DeliveryAddress = apiResponse!.Data!.DeliveryAddress,
                    LoadingAddress = apiResponse!.Data!.LoadingAddress,
                    Volume = apiResponse!.Data!.Volume,
                    Weight = apiResponse!.Data!.Weight
                };
                return View(requestModel);
            }

            return CreateActionResult(apiResponse, onData);
        }

        [HttpPost]
        public IActionResult UpdateTransportRequest(UpdateTransportRequestModel updateTransportRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _transportRequestClient.UpdateTransportRequest(updateTransportRequestModel);
            return CreateActionResult(apiResponse, null, updateTransportRequestModel);
        }

        public IActionResult DeleteTransportRequest(int id)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _transportRequestClient.DeleteTransportRequest(id);
            return CreateActionResult(apiResponse, null, actionName: "Index");
        }
    }
}
