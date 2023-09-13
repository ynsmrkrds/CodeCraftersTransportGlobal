using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCompleteTransportRequest;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportRequest;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandDeleteTransportRequest;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandUpdateTransportRequest;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportRequests;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetPendingTransportRequests;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetTransportRequest;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.API.Controllers
{
    public class TransportRequestController : BaseController
    {
        private readonly IMediator _mediator;

        public TransportRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> Get(int id)
        {
            GetTransportRequestQueryResponse queryResponse = await _mediator.Send(new GetTransportRequestQueryRequest(id));
            return CreateActionResult(queryResponse.TransportRequest);
        }

        [HttpGet]
        [Route("pendings/{page}/{size}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetPendings(int page, int size)
        {
            GetPendingTransportRequestsQueryResponse queryResponse = await _mediator.Send(new GetPendingTransportRequestsQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(queryResponse.TransportRequests);
        }

        [HttpGet]
        [Route("own/{page}/{size}")]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> GetOwn(int page, int size)
        {
            GetOwnTransportRequestsQueryResponse queryResponse = await _mediator.Send(new GetOwnTransportRequestsQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(queryResponse.TransportRequests);
        }

        [HttpPost]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Create([FromBody] CreateTransportRequestCommandRequest request)
        {
            CreateTransportRequestCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }

        [HttpPut]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Update([FromBody] UpdateTransportRequestCommandRequest request)
        {
            UpdateTransportRequestCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }

        [HttpPut]
        [Route("complete")]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Complete([FromBody] CompleteTransportRequestCommandRequest request)
        {
            CompleteTransportRequestCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteTransportRequestCommandResponse commandResponse = await _mediator.Send(new DeleteTransportRequestCommandRequest(id));
            return CreateActionResult(commandResponse.Response);
        }

    }
}
