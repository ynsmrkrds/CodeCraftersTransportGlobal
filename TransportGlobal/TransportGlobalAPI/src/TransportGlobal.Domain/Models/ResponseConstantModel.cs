namespace TransportGlobal.Domain.Models
{
    public class ResponseConstantModel
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }

        public ResponseConstantModel(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
