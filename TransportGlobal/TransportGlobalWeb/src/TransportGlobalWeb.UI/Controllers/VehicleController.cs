using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients;
using TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Company;
using TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Vehicle;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Company;
using TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Vehicle;

namespace TransportGlobalWeb.UI.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly VehicleClient _vehicleClient;

        public VehicleController(VehicleClient vehicleClient)
        {
            _vehicleClient = vehicleClient;
        }

        public IActionResult GetOwnVehicles(int page = 0)
        {
            ApiResponseModel<GetOwnVehiclesResponseModel>? apiResponse = _vehicleClient.GetOwnVehicles(page);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            ViewData["Page"] = page;

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult GetVehicleByID(int id)
        {
            ApiResponseModel<VehicleResponseModel>? apiResponse = _vehicleClient.GetVehicleByID(id);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult CreateVehicle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateVehicle(CreateVehicleRequestModel createVehicleRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _vehicleClient.CreateVehicle(createVehicleRequestModel);
            return CreateActionResult(apiResponse, null);
        }

        public IActionResult UpdateVehicle(int id)
        {
            ApiResponseModel<VehicleResponseModel>? apiResponse = _vehicleClient.GetVehicleByID(id);

            IActionResult onData()
            {
                UpdateVehicleRequestModel requestModel = new()
                {
                    ID = apiResponse!.Data!.ID,
                    Status = apiResponse!.Data!.Status,
                };
                return View(requestModel);
            }

            return CreateActionResult(apiResponse, onData);
        }

        [HttpPost]
        public IActionResult UpdateVehicle(UpdateVehicleRequestModel updateVehicleRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _vehicleClient.UpdateVehicle(updateVehicleRequestModel);
            return CreateActionResult(apiResponse, null, updateVehicleRequestModel);
        }

        public IActionResult DeleteVehicle(int id)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _vehicleClient.DeleteVehicle(id);
            return CreateActionResult(apiResponse, null, actionName: "GetOwnVehicles");
        }
    }
}
