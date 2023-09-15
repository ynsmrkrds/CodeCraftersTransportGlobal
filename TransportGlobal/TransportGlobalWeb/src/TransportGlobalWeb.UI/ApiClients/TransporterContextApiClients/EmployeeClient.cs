using RestSharp;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.TransporterContextConfigurationModels;
using TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Employee;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Employee;

namespace TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients
{
    public class EmployeeClient : BaseApiClient
    {
        private readonly EmployeeEndpointsConfigurationModel _configurationModel;

        public EmployeeClient(ApiEndpointsConfigurationModel apiEndpoints) : base(apiEndpoints)
        {
            _configurationModel = apiEndpoints!.TransporterContextEndpoints!.EmployeeEndpoints!;
        }

        public ApiResponseModel<GetOwnEmployeesResponseModel>? GetOwnEmployees(int page)
        {
            RestRequest request = new($"{_configurationModel.GetOwnEmployees}/{page}/{_apiEndpoints.PageSize}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<GetOwnEmployeesResponseModel>(request);
        }

        public ApiResponseModel<GetVehicleEmployeesResponseModel>? GetVehicleEmployees(int vehicleID, int page)
        {
            RestRequest request = new($"{_configurationModel.GetVehicleEmployees}/{vehicleID}/{page}/{_apiEndpoints.PageSize}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<GetVehicleEmployeesResponseModel>(request);
        }

        public ApiResponseModel<GetEmployeeResponseModel>? GetEmployeeByID(int id)
        {
            RestRequest request = new($"{_configurationModel.CrudEmployee}/{id}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<GetEmployeeResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? CreateEmployee(CreateEmployeeRequestModel createEmployeeRequestModel)
        {
            RestRequest request = new(_configurationModel.CrudEmployee, Method.Post);
            request.AddBody(createEmployeeRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? UpdateEmployee(UpdateEmployeeRequestModel updateEmployeeRequestModel)
        {
            RestRequest request = new(_configurationModel.CrudEmployee, Method.Put);
            request.AddBody(updateEmployeeRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? DeleteEmployee(int id)
        {
            RestRequest request = new($"{_configurationModel.CrudEmployee}/{id}", Method.Delete);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }
    }
}
