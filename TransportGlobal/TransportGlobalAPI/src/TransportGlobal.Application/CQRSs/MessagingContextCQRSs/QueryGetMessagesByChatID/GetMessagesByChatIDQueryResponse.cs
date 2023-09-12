using TransportGlobal.Application.ViewModels.MessagingContextViewModels;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetMessagesByChatID
{
    public class GetMessagesByChatIDQueryResponse
    {
        public List<MessageViewModel> Messages { get; set; }

        public GetMessagesByChatIDQueryResponse(List<MessageViewModel> messages)
        {
            Messages = messages;
        }
    }
}
