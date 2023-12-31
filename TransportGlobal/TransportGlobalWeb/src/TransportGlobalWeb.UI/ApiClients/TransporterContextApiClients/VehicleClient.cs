﻿using RestSharp;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.TransporterContextConfigurationModels;
using TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Vehicle;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ViewModels.TransporterContextViewModels;

namespace TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients
{
    public class VehicleClient : BaseApiClient
    {
        private readonly VehicleEndpointsConfigurationModel _configurationModel;

        public VehicleClient(ApiEndpointsConfigurationModel apiEnpoints) : base(apiEnpoints)
        {
            _configurationModel = apiEnpoints!.TransporterContextEndpoints!.VehicleEndpoints!;
        }

        public ApiResponseModel<ListResponseModel<VehicleViewModel>>? GetOwnVehicles(int page)
        {
            RestRequest request = new($"{_configurationModel.GetOwnVehicles}/{page}/{_apiEndpoints.PageSize}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<ListResponseModel<VehicleViewModel>>(request);
        }
        public ApiResponseModel<VehicleViewModel>? GetVehicleByID(int id)
        {
            RestRequest request = new($"{_configurationModel.CrudVehicle}/{id}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<VehicleViewModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? CreateVehicle(CreateVehicleRequestModel createVehicleRequestModel)
        {
            RestRequest request = new(_configurationModel.CrudVehicle, Method.Post);
            request.AddBody(createVehicleRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? UpdateVehicle(UpdateVehicleRequestModel updateVehicleRequestModel)
        {
            RestRequest request = new(_configurationModel.CrudVehicle, Method.Put);
            request.AddBody(updateVehicleRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? DeleteVehicle(int id)
        {
            RestRequest request = new($"{_configurationModel.CrudVehicle}/{id}", Method.Delete);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }
    }
}
