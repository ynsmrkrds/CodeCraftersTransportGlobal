namespace TransportGlobalWeb.UI.Models.ResponseModels.MessagingResponseModels.Message
{
    public class GetMessagesByChatIDResponseModel : BaseListResponseModel<MessageResponseModel>
    {
        public GetMessagesByChatIDResponseModel(ICollection<MessageResponseModel> list, int totalCount) : base(list, totalCount)
        {
        }
    }
}
