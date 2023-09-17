using RestSharp;
using TransportGlobalWeb.UI.Models.ConfigurationModels;
using TransportGlobalWeb.UI.Models.ConfigurationModels.MessagingContextConfigurationModels;
using TransportGlobalWeb.UI.Models.RequestModels.MessagingContextRequestModels.Message;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ViewModels.MessagingContextViewModels;

namespace TransportGlobalWeb.UI.ApiClients.MessagingContextApiClients
{
    public class MessageClient : BaseApiClient
    {
        private readonly MessageEndpointsConfigurationModel _configurationModel;

        public MessageClient(ApiEndpointsConfigurationModel apiEndpoints) : base(apiEndpoints)
        {
            _configurationModel = apiEndpoints!.MessagingContextEndpoints!.MessageEndpoints!;
        }

        public ApiResponseModel<ListResponseModel<MessageViewModel>>? GetMessagesByChatID(int chatID, int page)
        {
            RestRequest request = new($"{_configurationModel.GetMessageByChatID}/{chatID}/{page}/{_apiEndpoints.PageSize}", Method.Get);
            request = AddAuthorizationHeader(request);

            return SendRequest<ListResponseModel<MessageViewModel>>(request);
        }

        public ApiResponseModel<NonDataResponseModel>? CreateMessage(CreateMessageRequestModel createMessageRequestModel)
        {
            RestRequest request = new(_configurationModel.CrudMessage, Method.Post);
            request.AddBody(createMessageRequestModel, ContentType.Json);
            request = AddAuthorizationHeader(request);

            return SendRequest<NonDataResponseModel>(request);
        }
    }
}
