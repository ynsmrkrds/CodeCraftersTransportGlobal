﻿using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TransportGlobalWeb.UI.Enums;
using TransportGlobalWeb.UI.Helpers;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.CookieModels;
using TransportGlobalWeb.UI.Models.ResponseModels;

namespace TransportGlobalWeb.UI.ApiClients
{
    public abstract class BaseApiClient
    {
        protected readonly RestClient _restClient;
        protected readonly ApiEnpointsConfigurationModel apiEnpoints;

        public BaseApiClient(ApiEnpointsConfigurationModel apiEnpoints)
        {
            _restClient = new(new RestClientOptions()
            {
                BaseUrl = new Uri(apiEnpoints.BaseUrl!),
            });

            this.apiEnpoints = apiEnpoints;
        }

        public ApiResponseModel<T>? SendRequest<T>(RestRequest restRequest) where T : BaseResponseModel
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