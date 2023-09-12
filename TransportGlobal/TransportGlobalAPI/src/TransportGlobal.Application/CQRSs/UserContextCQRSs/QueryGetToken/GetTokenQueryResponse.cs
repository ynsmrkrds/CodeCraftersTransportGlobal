using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.QueryGetToken
{
    public class GetTokenQueryResponse
    {
        public string Message { get; set; }

        public bool IsSuccesful { get; set; }

        public string? Token { get; set; }

        public GetTokenQueryResponse(ResponseConstantModel responseConstant, string? token = null)
        {
            Message = responseConstant.Message;
            IsSuccesful = responseConstant.IsSuccessful;
            Token = token;
        }
    }
}
