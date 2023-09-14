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

        public ApiResponseModel<NonDataResponseModel>? Register(RegisterRequestModel registerRequestModel)
        {
            RestRequest request = new(apiEnpoints.UserContextEndpoints!.Register, Method.Post);
            request.AddBody(registerRequestModel, ContentType.Json);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<GetProfileResponseModel>? GetProfile()
        {
            RestRequest request = new(apiEnpoints.UserContextEndpoints!.GetProfile, Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<GetProfileResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? UpdateProfile(UpdateProfileRequestModel updateProfileRequestModel)
        {
            RestRequest request = new(apiEnpoints.UserContextEndpoints!.UpdateProfile, Method.Put);
            request.AddBody(updateProfileRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? UpdatePassword(UpdatePasswordRequestModel updatePasswordRequestModel)
        {
            RestRequest request = new(apiEnpoints.UserContextEndpoints!.UpdatePassword, Method.Put);
            request.AddBody(updatePasswordRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }
    }
}
