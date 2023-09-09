using System.Net;
using System.Text.Json.Serialization;

namespace TransportGlobal.Application.DTOs.ResponseDTOs
{
    public class APIResponseDTO
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Data { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Messages { get; set; }

        public APIResponseDTO(HttpStatusCode statusCode, object data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public APIResponseDTO(HttpStatusCode statusCode, List<string> messages)
        {
            StatusCode = statusCode;
            Messages = messages;
        }

        public APIResponseDTO(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Messages = new List<string>() { message };
        }
    }
}
