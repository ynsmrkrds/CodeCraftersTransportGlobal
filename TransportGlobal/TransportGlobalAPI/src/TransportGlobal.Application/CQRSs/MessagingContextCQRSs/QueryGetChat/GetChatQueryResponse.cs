using TransportGlobal.Application.ViewModels.MessagingContextViewModels;

namespace TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetChat
{
    public class GetChatQueryResponse
    {
        public List<ChatViewModel> Chats { get; set; }

        public GetChatQueryResponse(List<ChatViewModel> chats)
        {
            Chats = chats;
        }
    }
}
