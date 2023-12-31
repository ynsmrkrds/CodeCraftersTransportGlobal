﻿using RestSharp;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.TransportContextConfiguraitonModels;
using TransportGlobalWeb.UI.Models.RequestModels.TransportContextRequestModels.TransportRequest;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ViewModels.TransportContextViewModels;

namespace TransportGlobalWeb.UI.ApiClients.TransportContextApiClients
{
    public class TransportRequestClient : BaseApiClient
    {
        private readonly TransportRequestEndpointsConfigurationModel _configurationModel;
        public TransportRequestClient(ApiEndpointsConfigurationModel apiEndpoints) : base(apiEndpoints)
        {
            _configurationModel = apiEndpoints.TransportContextEndpoints!.TransportRequestEndpoints!;
        }

        public ApiResponseModel<ListResponseModel<TransportRequestViewModel>>? GetOwnTransportRequests(int page)
        {
            RestRequest request = new($"{_configurationModel.GetOwnTransportRequest}/{page}/{_apiEndpoints.PageSize}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<ListResponseModel<TransportRequestViewModel>>(request);
        }

        public ApiResponseModel<ListResponseModel<TransportRequestViewModel>>? GetPendingTransportRequests(int page)
        {
            RestRequest request = new($"{_configurationModel.GetPendingTransportRequests}/{page}/{_apiEndpoints.PageSize}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<ListResponseModel<TransportRequestViewModel>>(request);
        }

        public ApiResponseModel<TransportRequestViewModel>? GetTransportRequestByID(int id)
        {
            RestRequest request = new($"{_configurationModel.CrudTransportRequest}/{id}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<TransportRequestViewModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? CreateTransportRequest(CreateTransportRequestRequestModel createTransportRequestModel)
        {
            RestRequest request = new(_configurationModel.CrudTransportRequest, Method.Post);
            request.AddBody(createTransportRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? UpdateTransportRequest(UpdateTransportRequestModel updateTransportRequestModel)
        {
            RestRequest request = new(_configurationModel.CrudTransportRequest, Method.Put);
            request.AddBody(updateTransportRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? DeleteTransportRequest(int id)
        {
            RestRequest request = new($"{_configurationModel.CrudTransportRequest}/{id}", Method.Delete);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? CompleteTransportRequest(CompleteTransportRequestRequestModel completeTransportRequestRequestModel)
        {
            RestRequest request = new(_configurationModel.CompleteTransportRequest, Method.Put);
            request.AddBody(completeTransportRequestRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }
    }
}
