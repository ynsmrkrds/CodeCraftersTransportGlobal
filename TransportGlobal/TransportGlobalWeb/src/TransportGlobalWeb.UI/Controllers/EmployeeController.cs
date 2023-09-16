using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Employee;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Employee;
using TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Vehicle;

namespace TransportGlobalWeb.UI.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly EmployeeClient _employeeClient;
        private readonly VehicleClient _vehicleClient;
        private readonly ApiEndpointsConfigurationModel _configurationModel;

        public EmployeeController(EmployeeClient employeeClient, VehicleClient vehicleClient, ApiEndpointsConfigurationModel configurationModel)
        {
            _employeeClient = employeeClient;
            _vehicleClient = vehicleClient;
            _configurationModel = configurationModel;
        }

        public IActionResult GetOwnEmployees(int page = 0)
        {
            ApiResponseModel<GetOwnEmployeesResponseModel>? apiResponse = _employeeClient.GetOwnEmployees(page);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            ViewData["Page"] = page;

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult GetVehicleEmployees(int id, int page = 0)
        {
            ApiResponseModel<GetVehicleEmployeesResponseModel>? apiResponse = _employeeClient.GetVehicleEmployees(id, page);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            ViewData["Page"] = page;
            ViewData["VehicleID"] = id;

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult GetEmployeeByID(int id)
        {
            ApiResponseModel<GetEmployeeResponseModel>? apiResponse = _employeeClient.GetEmployeeByID(id);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult CreateEmployee()
        {
            AddOwnVehiclesListToView();

            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(CreateEmployeeRequestModel createEmployeeRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _employeeClient.CreateEmployee(createEmployeeRequestModel);
            AddOwnVehiclesListToView();

            return CreateActionResult(apiResponse, null);
        }

        public IActionResult UpdateEmployee(int id)
        {
            ApiResponseModel<GetEmployeeResponseModel>? apiResponse = _employeeClient.GetEmployeeByID(id);

            IActionResult onData()
            {
                UpdateEmployeeRequestModel requestModel = new()
                {
                    ID = apiResponse!.Data!.ID,
                    VehicleID = apiResponse!.Data!.VehicleID,
                    Name = apiResponse!.Data!.Name,
                    Surname = apiResponse!.Data!.Surname,
                    Email = apiResponse!.Data!.Email,
                    Title = apiResponse!.Data!.Title,
                };

                return View(requestModel);
            }

            AddOwnVehiclesListToView();

            return CreateActionResult(apiResponse, onData);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(UpdateEmployeeRequestModel updateEmployeeRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _employeeClient.UpdateEmployee(updateEmployeeRequestModel);
            AddOwnVehiclesListToView();

            return CreateActionResult(apiResponse, null, updateEmployeeRequestModel);
        }

        public IActionResult DeleteEmployee(int id)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _employeeClient.DeleteEmployee(id);
            return CreateActionResult(apiResponse, null, actionName: "GetOwnEmployees");
        }


        private void AddOwnVehiclesListToView()
        {
            List<VehicleResponseModel> vehicles = new();

            ApiResponseModel<GetOwnVehiclesResponseModel>? apiResponse = _vehicleClient.GetOwnVehicles(0);
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
