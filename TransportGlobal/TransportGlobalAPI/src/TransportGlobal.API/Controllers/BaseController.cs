using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(T response)
        {
            HttpStatusCode statusCode = HttpStatusCode.OK;

            if (response!.GetType() == typeof(ResponseConstantModel))
            {
                return new ObjectResult(new APIResponseDTO(statusCode, (response as ResponseConstantModel)!))
                {
                    StatusCode = (int)statusCode
                };
            }

            return new ObjectResult(new APIResponseDTO(statusCode, response!))
            {
                StatusCode = (int)statusCode
            };
        }
    }
}
