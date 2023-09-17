using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients.TransportContextApiClients;
using TransportGlobalWeb.UI.Enums;
using TransportGlobalWeb.UI.Enums.UserContextEnums;
using TransportGlobalWeb.UI.Helpers;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.CookieModels;
using TransportGlobalWeb.UI.Models.RequestModels.TransportContextRequestModels.TransportRequest;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ViewModels.TransportContextViewModels;

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
                ApiResponseModel<ListResponseModel<TransportRequestViewModel>>? apiResponse = _transportRequestClient.GetOwnTransportRequests(page);

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
                ApiResponseModel<ListResponseModel<TransportRequestViewModel>>? apiResponse = _transportRequestClient.GetPendingTransportRequests(page);

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
            ApiResponseModel<TransportRequestViewModel>? apiResponse = _transportRequestClient.GetTransportRequestByID(id);

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
        public IActionResult CreateTransportRequest(CreateTransportRequestRequestModel createTransportRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _transportRequestClient.CreateTransportRequest(createTransportRequestModel);

            return CreateActionResult(apiResponse, null);
        }

        public IActionResult UpdateTransportRequest(int id)
        {
            ApiResponseModel<TransportRequestViewModel>? apiResponse = _transportRequestClient.GetTransportRequestByID(id);

            IActionResult onData()
            {
                UpdateTransportRequestModel requestModel = new()
                {
                    ID = apiResponse!.Data!.ID,
                    TransportType = apiResponse!.Data!.TransportType,
                    DeliveryAddress = apiResponse!.Data!.DeliveryAddress,
                    LoadingAddress = apiResponse!.Data!.LoadingAddress,
                    Volume = apiResponse!.Data!.Volume,
                    Weight = apiResponse!.Data!.Weight,
                    TransportDate = apiResponse!.Data!.TransportDate,
                };
                return View(requestModel);
            }

            return CreateActionResult(apiResponse, onData);
        }

        [HttpPost]
        public IActionResult UpdateTransportRequest(UpdateTransportRequestModel updateTransportRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _transportRequestClient.UpdateTransportRequest(updateTransportRequestModel);
            return CreateActionResult(apiResponse, null, model: updateTransportRequestModel);
        }

        public IActionResult CompleteTransportRequest(int id)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _transportRequestClient.CompleteTransportRequest(new CompleteTransportRequestRequestModel() { ID = id });
            return CreateActionResult(apiResponse, null, actionName: "GetOwnTransportContracts", controllerName: "TransportContract");
        }

        public IActionResult DeleteTransportRequest(int id)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _transportRequestClient.DeleteTransportRequest(id);
            return CreateActionResult(apiResponse, null, actionName: "Index");
        }
    }
}
