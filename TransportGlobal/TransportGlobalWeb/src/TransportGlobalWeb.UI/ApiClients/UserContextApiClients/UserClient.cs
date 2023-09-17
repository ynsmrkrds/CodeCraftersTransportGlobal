using RestSharp;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.UserContextConfigurationModels;
using TransportGlobalWeb.UI.Models.RequestModels.UserContextRequestModels.User;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.UserResponseModels.User;
using TransportGlobalWeb.UI.Models.ViewModels.UserContextViewModels;

namespace TransportGlobalWeb.UI.ApiClients.UserContextApiClients
{
    public class UserClient : BaseApiClient
    {
        private readonly UserEndpointsConfigurationModel _configurationModel;

        public UserClient(ApiEndpointsConfigurationModel apiEndpoints) : base(apiEndpoints)
        {
            _configurationModel = apiEndpoints.UserContextEndpoints!.UserEndpoints!;
        }

        public ApiResponseModel<LoginResponseModel>? Login(LoginRequestModel loginRequestModel)
        {
            RestRequest request = new(_configurationModel.Login, Method.Post);
            request.AddBody(loginRequestModel, ContentType.Json);

            return SendRequest<LoginResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? Register(RegisterRequestModel registerRequestModel)
        {
            RestRequest request = new(_configurationModel.Register, Method.Post);
            request.AddBody(registerRequestModel, ContentType.Json);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<UserViewModel>? GetProfile()
        {
            RestRequest request = new(_configurationModel.GetProfile, Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<UserViewModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? UpdateProfile(UpdateProfileRequestModel updateProfileRequestModel)
        {
            RestRequest request = new(_configurationModel.UpdateProfile, Method.Put);
            request.AddBody(updateProfileRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? UpdatePassword(UpdatePasswordRequestModel updatePasswordRequestModel)
        {
            RestRequest request = new(_configurationModel.UpdatePassword, Method.Put);
            request.AddBody(updatePasswordRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }
    }
}
