using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients.TransportContextApiClients;
using TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.RequestModels.TransportContextRequestModels.TransportContract;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ViewModels.TransportContextViewModels;
using TransportGlobalWeb.UI.Models.ViewModels.TransporterContextViewModels;

namespace TransportGlobalWeb.UI.Controllers
{
    public class TransportContractController : BaseController
    {
        private readonly TransportContractClient _transportContractClient;
        private readonly VehicleClient _vehicleClient;

        private readonly ApiEndpointsConfigurationModel _configurationModel;

        public TransportContractController(TransportContractClient transportContractClient, VehicleClient vehicleClient, ApiEndpointsConfigurationModel configurationModel)
        {
            _transportContractClient = transportContractClient;
            _vehicleClient = vehicleClient;
            _configurationModel = configurationModel;
        }

        public IActionResult GetOwnTransportContracts(int page = 0)
        {
            ApiResponseModel<ListResponseModel<TransportContractViewModel>>? apiResponse = _transportContractClient.GetOwnTransportContracts(page);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            ViewData["Page"] = page;

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult GetTransportContractByID(int id)
        {
            ApiResponseModel<TransportContractViewModel>? apiResponse = _transportContractClient.GetTransportRequestByID(id);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult CreateTransportContract(int transportRequestID)
        {
            ViewData["TransportRequestID"] = transportRequestID;

            AddOwnVehiclesListToView();

            return View();
        }

        [HttpPost]
        public IActionResult CreateTransportContract(CreateTransportContractRequestModel createTransportContractRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _transportContractClient.CreateTransportContract(createTransportContractRequestModel);

            ViewData["TransportRequestID"] = createTransportContractRequestModel.TransportRequestID;

            AddOwnVehiclesListToView();

            return CreateActionResult(apiResponse, null);
        }

        public IActionResult AgreeTransportContract(int id)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _transportContractClient.AgreeTransportContract(new AgreeTransportContractRequestModel() { ID = id });
            return CreateActionResult(apiResponse, null, actionName: "GetTransportContractByID", controllerName: "TransportContract", routeValues: new { id });
        }

        private void AddOwnVehiclesListToView()
        {
            List<VehicleViewModel> vehicles = new();

            ApiResponseModel<ListResponseModel<VehicleViewModel>>? apiResponse = _vehicleClient.GetOwnVehicles(0);
            if (apiResponse?.Data != null)
            {
                double totalPageCount = Math.Ceiling((double)(apiResponse!.Data!.TotalCount / (double)_configurationModel.PageSize!));
                int page = 0;
                vehicles.AddRange(apiResponse.Data.List);

                for (int i = page + 1; i < totalPageCount; i++)
                {
                    apiResponse = _vehicleClient.GetOwnVehicles(i);
                    if (apiResponse?.Data == null)
                    {
                        i--;
                        continue;
                    }

                    vehicles.AddRange(apiResponse.Data.List);
                }
            }

            ViewData["Vehicles"] = vehicles;
        }
    }
}
