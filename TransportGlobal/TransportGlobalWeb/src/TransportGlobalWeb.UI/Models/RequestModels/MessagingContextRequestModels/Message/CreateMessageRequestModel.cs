namespace TransportGlobalWeb.UI.Models.RequestModels.MessagingContextRequestModels.Message
{
    public class CreateMessageRequestModel
    {
        public int ChatID { get; set; }

        public string Content { get; set; } = string.Empty;
    }
}
