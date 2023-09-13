using RestSharp;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.RequestModels;
using TransportGlobalWeb.UI.Models.ResponseModels;

namespace TransportGlobalWeb.UI.ApiClients
{
    public class UserContextClient : BaseApiClient
    {
        public UserContextClient(ApiEnpointsConfigurationModel apiEnpoints) : base(apiEnpoints)
        {
        }

        public ApiResponseModel<LoginResponseModel>? Login(LoginRequestModel loginRequestModel)
        {
            RestRequest request = new(apiEnpoints.UserContextEndpoints!.Login, Method.Post);
            request.AddBody(loginRequestModel, ContentType.Json);

            return SendRequest<LoginResponseModel>(request);
        }

        public List<string>? Register(RegisterRequestModel registerRequestModel)
        {
            RestRequest request = new(apiEnpoints.UserContextEndpoints!.Register, Method.Post);
            request.AddBody(registerRequestModel, ContentType.Json);

            ApiResponseModel<NonDataResponseModel>? apiResponse = SendRequest<NonDataResponseModel>(request);
            return apiResponse?.Messages;
        }
    }
}
