using TransportGlobal.Application.ViewModels.MessagingContextViewModels;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetMessage
{
    public class GetMessageQueryResponse
    {
        public List<MessageViewModel> Messages { get; set; }

        public GetMessageQueryResponse(List<MessageViewModel> messages)
        {
            Messages = messages;
        }
    }
}
