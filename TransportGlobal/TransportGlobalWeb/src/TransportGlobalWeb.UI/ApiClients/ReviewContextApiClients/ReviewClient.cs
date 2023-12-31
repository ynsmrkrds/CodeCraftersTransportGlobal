﻿using RestSharp;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.ReviewContextConfigurationModels;
using TransportGlobalWeb.UI.Models.RequestModels.ReviewContextRequestModels.Review;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ViewModels.ReviewContextViewModels;

namespace TransportGlobalWeb.UI.ApiClients.ReviewContextApiClients
{
    public class ReviewClient : BaseApiClient
    {
        private readonly ReviewEndpointsConfigurationModel _configurationModel;

        public ReviewClient(ApiEndpointsConfigurationModel apiEndpoints) : base(apiEndpoints)
        {
            _configurationModel = apiEndpoints.ReviewContextEndpoints!.ReviewEndpoints!;
        }

        public ApiResponseModel<ListResponseModel<ReviewViewModel>>? GetCompanyReviews(int companyID, int page)
        {
            RestRequest request = new($"{_configurationModel.GetCompanyReviews}/{companyID}/{page}/{_apiEndpoints.PageSize}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<ListResponseModel<ReviewViewModel>>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? CreateReview(CreateReviewRequestModel createReviewRequestModel)
        {
            RestRequest request = new(_configurationModel.CrudReview, Method.Post);
            request.AddBody(createReviewRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }
    }
}
