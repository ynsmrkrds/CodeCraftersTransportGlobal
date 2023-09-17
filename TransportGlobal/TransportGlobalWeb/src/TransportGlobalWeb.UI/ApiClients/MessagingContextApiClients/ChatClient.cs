using RestSharp;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.MessagingContextConfigurationModels;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ViewModels.MessagingContextViewModels;

namespace TransportGlobalWeb.UI.ApiClients.MessagingContextApiClients
{
    public class ChatClient : BaseApiClient
    {
        private readonly ChatEndpointsConfigurationModel _configurationModel;

        public ChatClient(ApiEndpointsConfigurationModel apiEndpoints) : base(apiEndpoints)
        {
            _configurationModel = apiEndpoints!.MessagingContextEndpoints!.ChatEndpoints!;
        }

        public ApiResponseModel<ListResponseModel<ChatViewModel>>? GetOwnChats(int page)
        {
            RestRequest request = new($"{_configurationModel.GetOwnChats}/{page}/{_apiEndpoints.PageSize}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<ListResponseModel<ChatViewModel>>(request);
        }
    }
}
