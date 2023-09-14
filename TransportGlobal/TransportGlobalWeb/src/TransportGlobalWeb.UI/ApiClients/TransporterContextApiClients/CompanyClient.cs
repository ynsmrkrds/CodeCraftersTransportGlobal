using RestSharp;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.TransporterContextConfigurationModels;
using TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Company;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Company;

namespace TransportGlobalWeb.UI.ApiClients.TransporterContextApiClients
{
    public class CompanyClient : BaseApiClient
    {
        private readonly CompanyEndpointsConfigurationModel _configurationModel;

        public CompanyClient(ApiEndpointsConfigurationModel apiEnpoints) : base(apiEnpoints)
        {
            _configurationModel = apiEnpoints!.TransporterContextEndpoints!.CompanyEndpoints!;
        }

        public ApiResponseModel<GetCompanyResponseModel>? GetOwnCompany()
        {
            RestRequest request = new(_configurationModel.GetOwnCompany, Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<GetCompanyResponseModel>(request);
        }

        public ApiResponseModel<GetCompanyResponseModel>? GetCompanyByID(int id)
        {
            RestRequest request = new($"{_configurationModel.CrudCompany}/{id}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<GetCompanyResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? CreateCompany(CreateCompanyRequestModel createCompanyRequestModel)
        {
            RestRequest request = new(_configurationModel.CrudCompany, Method.Post);
            request.AddBody(createCompanyRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? UpdateCompany(UpdateCompanyRequestModel updateCompanyRequestModel)
        {
            RestRequest request = new(_configurationModel.CrudCompany, Method.Put);
            request.AddBody(updateCompanyRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? DeleteCompany(int id)
        {
            RestRequest request = new($"{_configurationModel.CrudCompany}/{id}", Method.Delete);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }
    }
}
