using RestSharp;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.TransporterContextConfigurationModels;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Vehicle;

namespace TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients
{
    public class VehicleClient : BaseApiClient
    {
        private readonly VehicleEndpointsConfigurationModel _configurationModel;

        public VehicleClient(ApiEndpointsConfigurationModel apiEnpoints) : base(apiEnpoints)
        {
            _configurationModel = apiEnpoints!.TransporterContextEndpoints!.VehicleEndpoints!;
        }

        public ApiResponseModel<GetOwnVehiclesResponseModel>? GetOwnVehicles(int page)
        {
            RestRequest request = new($"{_configurationModel.GetOwnVehicles}/{page}/{_apiEndpoints.PageSize}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<GetOwnVehiclesResponseModel>(request);
        }
    }
}
