﻿using RestSharp;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.TransportContextConfiguraitonModels;
using TransportGlobalWeb.UI.Models.RequestModels.TransportContextRequestModels.TransportContract;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.TransportResponseModels.TransportContract;

namespace TransportGlobalWeb.UI.ApiClients.TransportContextApiClients
{
    public class TransportContractClient : BaseApiClient
    {
        private readonly TransportContractEndpointsConfigurationModel _configurationModel;
        public TransportContractClient(ApiEndpointsConfigurationModel apiEndpoints) : base(apiEndpoints)
        {
            _configurationModel = apiEndpoints.TransportContextEndpoints!.TransportContractEndpoints!;
        }

        public ApiResponseModel<GetOwnTransportContractResponseModel>? GetOwnTransportContracts(int page)
        {
            RestRequest request = new($"{_configurationModel.GetOwnTransportContracts}/{page}/{_apiEndpoints.PageSize}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<GetOwnTransportContractResponseModel>(request);
        }

        public ApiResponseModel<GetTransportContractResponseModel>? GetTransportRequestByID(int id)
        {
            RestRequest request = new($"{_configurationModel.CrudTransportContract}/{id}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<GetTransportContractResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? CreateTransportContract(CreateTransportContractRequestModel createTransportContractRequestModel)
        {
            RestRequest request = new(_configurationModel.CrudTransportContract, Method.Post);
            request.AddBody(createTransportContractRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? AgreeTransportContract(AgreeTransportContractRequestModel agreeTransportContractRequestModel)
        {
            RestRequest request = new(_configurationModel.AgreeTransportContract, Method.Put);
            request.AddBody(agreeTransportContractRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }
    }
}
