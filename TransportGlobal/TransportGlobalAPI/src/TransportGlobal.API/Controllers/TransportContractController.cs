﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandAgreeTransportContract;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportContract;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportContracts;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportContractsByUserType;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetTransportContract;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.API.Controllers
{
    public class TransportContractController : BaseController
    {
        private readonly IMediator _mediator;

        public TransportContractController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> Get(int id)
        {
            GetTransportContractQueryResponse queryResponse = await _mediator.Send(new GetTransportContractQueryRequest(id));
            return CreateActionResult(queryResponse.TransportContract);
        }

        [HttpGet]
        [Route("own/{page}/{size}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetOwn(int page, int size)
        {
            GetOwnTransportContractsQueryResponse queryResponse = await _mediator.Send(new GetOwnTransportContractsQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(queryResponse);
        }

        [HttpPost]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Create([FromBody] CreateTransportContractCommandRequest request)
        {
            CreateTransportContractCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }

        [HttpPut]
        [Route("agree")]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Agree([FromBody] AgreeTransportContractCommandRequest request)
        {
            AgreeTransportContractCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }
    }
}
