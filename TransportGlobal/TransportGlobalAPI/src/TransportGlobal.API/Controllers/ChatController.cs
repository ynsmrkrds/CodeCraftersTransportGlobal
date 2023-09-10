using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandCreateChat;
using TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandDeleteChat;
using TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetChat;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;

namespace TransportGlobal.API.Controllers
{
    public class ChatController : BaseController
    {
        private readonly IMediator _mediator;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            GetChatQueryResponse queryResponse = await _mediator.Send(new GetChatQueryRequest());
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Chats));
        }

        [HttpPost]
        [Route("create")]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Create([FromBody] CreateChatCommandRequest request)
        {
            CreateChatCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteChatCommandResponse commandResponse = await _mediator.Send(new DeleteChatCommandRequest(id));
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
