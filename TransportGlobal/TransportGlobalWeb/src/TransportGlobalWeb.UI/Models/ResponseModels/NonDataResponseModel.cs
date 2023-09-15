namespace TransportGlobalWeb.UI.Models.ResponseModels
{
    public abstract class NonDataResponseModel : BaseResponseModel
    {
        protected NonDataResponseModel() : base(0, DateTime.Now)
        {
        }
    }
}
