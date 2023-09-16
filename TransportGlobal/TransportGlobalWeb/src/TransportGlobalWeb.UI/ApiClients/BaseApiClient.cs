using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TransportGlobalWeb.UI.Enums;
using TransportGlobalWeb.UI.Helpers;
using TransportGlobalWeb.UI.Models;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.CookieModels;
using TransportGlobalWeb.UI.Models.ResponseModels;

namespace TransportGlobalWeb.UI.ApiClients
{
    public abstract class BaseApiClient
    {
        protected readonly RestClient _restClient;
        protected readonly ApiEndpointsConfigurationModel _apiEndpoints;

        public BaseApiClient(ApiEndpointsConfigurationModel apiEndpoints)
        {
            _restClient = new(new RestClientOptions()
            {
                BaseUrl = new Uri(apiEndpoints.BaseUrl!),
            });

            _apiEndpoints = apiEndpoints;
        }

        public ApiResponseModel<T>? SendRequest<T>(RestRequest restRequest) where T : IApiData
        {
            RestResponse response = _restClient.Execute(restRequest);
            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.BadRequest) return null;

            return JsonConvert.DeserializeObject<ApiResponseModel<T>>(response.Content!)!;
        }

        public RestRequest AddAuthorizationHeader(RestRequest request)
        {
            string token = BaseCookieModel.FromJson<UserCookieModel>(CookieHelper.GetCookie(CookieKey.User)!)!.Token;
            request.AddHeader("Authorization", $"Bearer {token}");

            return request;
        }
    }
}