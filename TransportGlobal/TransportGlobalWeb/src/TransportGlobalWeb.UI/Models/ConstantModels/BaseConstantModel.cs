namespace TransportGlobalWeb.UI.Models.ConstantModels
{
    public abstract class BaseConstantModel
    {
        public bool IsSuccessful { get; private set; }

        public string Message { get; private set; }

        protected BaseConstantModel(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
