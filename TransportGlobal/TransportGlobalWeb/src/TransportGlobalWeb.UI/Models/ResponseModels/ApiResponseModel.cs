namespace TransportGlobalWeb.UI.Models.ResponseModels
{
    public class ApiResponseModel<T> where T : BaseResponseModel
    {
        public T? Data { get; set; }

        public List<string>? Messages { get; set; }

        public ApiResponseModel(T? data, List<string>? messages = null)
        {
            Data = data;
            Messages = messages;
        }
    }
}
