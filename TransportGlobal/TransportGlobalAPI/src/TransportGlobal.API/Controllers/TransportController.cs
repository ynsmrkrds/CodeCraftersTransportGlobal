using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransport;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;

namespace TransportGlobal.API.Controllers
{

    public class TransportController : BaseController
    {
        private readonly IMediator _mediator;

        public TransportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Create([FromBody] CreateTransportCommandRequest request)
        {
            CreateTransportCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
