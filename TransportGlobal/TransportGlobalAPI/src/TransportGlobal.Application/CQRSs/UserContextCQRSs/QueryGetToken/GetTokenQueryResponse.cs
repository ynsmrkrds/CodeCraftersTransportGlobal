using System.Text.Json.Serialization;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.QueryGetToken
{
    public class GetTokenQueryResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Token { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseConstantModel? Response { get; private set; }

        public GetTokenQueryResponse(string token)
        {
            Token = token;
        }

        public GetTokenQueryResponse(ResponseConstantModel response)
        {
            Response = response;
        }
    }
}
