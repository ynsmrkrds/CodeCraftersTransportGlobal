using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
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
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.TransportRequest));
        }

        [HttpGet]
        [Route("pendings/{page}/{size}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetPendings(int page, int size)
        {
            GetPendingTransportRequestsQueryResponse queryResponse = await _mediator.Send(new GetPendingTransportRequestsQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.TransportRequests));
        }

        [HttpGet]
        [Route("own/{page}/{size}")]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> GetOwn(int page, int size)
        {
            GetOwnTransportRequestsQueryResponse queryResponse = await _mediator.Send(new GetOwnTransportRequestsQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.TransportRequests));
        }

        [HttpPost]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Create([FromBody] CreateTransportRequestCommandRequest request)
        {
            CreateTransportRequestCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Update([FromBody] UpdateTransportRequestCommandRequest request)
        {
            UpdateTransportRequestCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpDelete]
        [Route("{id}")]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteTransportRequestCommandResponse commandResponse = await _mediator.Send(new DeleteTransportRequestCommandRequest(id));
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

    }
}
