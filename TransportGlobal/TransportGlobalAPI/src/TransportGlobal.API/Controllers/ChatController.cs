using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.MessagingContextCQRSs.QueryGetOwnChats;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Models;

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
        [Route("own/{page}/{size}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> Get(int page, int size)
        {
            GetOwnChatsQueryResponse queryResponse = await _mediator.Send(new GetOwnChatsQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(queryResponse.Chats);
        }
    }
}
