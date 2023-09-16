namespace TransportGlobalWeb.UI.Models.ResponseModels.MessagingResponseModels.Chat
{
    public class GetOwnChatsResponseModel : BaseListResponseModel<ChatResponseModel>
    {
        public GetOwnChatsResponseModel(ICollection<ChatResponseModel> list, int totalCount) : base(list, totalCount)
        {
        }
    }
}
