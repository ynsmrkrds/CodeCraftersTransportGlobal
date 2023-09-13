using System.Net;
using System.Text.Json.Serialization;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.DTOs.ResponseDTOs
{
    public class APIResponseDTO
    {
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Data { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseConstantModel? Response { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ExceptionConstantModel>? Errors { get; private set; }

        public APIResponseDTO(HttpStatusCode statusCode, object data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public APIResponseDTO(HttpStatusCode statusCode, ResponseConstantModel response)
        {
            StatusCode = statusCode;
            Response = response;
        }

        public APIResponseDTO(HttpStatusCode statusCode, List<ExceptionConstantModel> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        public APIResponseDTO(HttpStatusCode statusCode, ExceptionConstantModel error)
        {
            StatusCode = statusCode;
            Errors = new List<ExceptionConstantModel>() { error };
        }
    }
}
