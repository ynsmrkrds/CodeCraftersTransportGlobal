using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.MessagingContextCQRSs.CommandCreateMessage;
using TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetMessagesByChatID;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Models;

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
        [Route("chat/{chatID}/{page}/{size}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetMessagesByChatID(int chatID, int page, int size)
        {
            GetMessagesByChatIDQueryResponse queryResponse = await _mediator.Send(new GetMessagesByChatIDQueryRequest(chatID, new PaginationModel(page, size)));
            return CreateActionResult(queryResponse);
        }

        [HttpPost]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> Create([FromBody] CreateMessageCommandRequest request)
        {
            CreateMessageCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }
    }
}
