using TransportGlobalWeb.UI.Models.ConstantModels;

namespace TransportGlobalWeb.UI.Models.ResponseModels
{
    public class ApiResponseModel<T> where T : IApiData
    {
        public T? Data { get; private set; }

        public ResponseConstantModel? Response { get; private set; }

        public List<ExceptionConstantModel>? Errors { get; private set; }

        public ApiResponseModel(T? data, ResponseConstantModel? response = null, List<ExceptionConstantModel>? errors = null)
        {
            Data = data;
            Response = response;
            Errors = errors;
        }
    }
}
