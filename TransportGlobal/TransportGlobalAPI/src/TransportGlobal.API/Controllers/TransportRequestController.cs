using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransport;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportRequest;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandDeleteTransportRequest;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandUpdateTransportRequest;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetPendingTransportRequest;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetTransportRequest;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;

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
        [Route("getTransportRequest/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetTransportRequestQueryResponse queryResponse = await _mediator.Send(new GetTransportRequestQueryRequest(id));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse));
        }

        [HttpGet]
        [Route("getTransportRequest")]
        public async Task<IActionResult> GetJustPending()
        {
            GetTransportRequestPendingQueryResponse queryResponse = await _mediator.Send(new GetTransportRequestPendingQueryRequest());
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse));
        }

        [HttpPost]
        [Route("createTransportRequest")]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Create([FromBody] CreateTransportRequestCommandRequest request)
        {
            CreateTransportRequestCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Route("updateTransportRequest")]
        public async Task<IActionResult> Update([FromBody] UpdateTransportRequestCommandRequest request)
        {
            UpdateTransportRequestCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpDelete]
        [Route("deleteTransportRequest/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteTransportRequestCommandResponse commandResponse = await _mediator.Send(new DeleteTransportRequestCommandRequest(id));
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

    }
}
