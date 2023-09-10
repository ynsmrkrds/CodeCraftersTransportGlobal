using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandCreateMessage;
using TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetMessage;
using TransportGlobal.Application.DTOs.ResponseDTOs;

namespace TransportGlobal.API.Controllers
{
    public class MessageController : BaseController
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            GetMessageQueryResponse queryResponse = await _mediator.Send(new GetMessageQueryRequest());
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Messages));
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> Create([FromBody] CreateMessageCommandRequest request)
        {
            CreateMessageCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
