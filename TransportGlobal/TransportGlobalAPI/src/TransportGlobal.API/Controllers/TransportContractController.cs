using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandAgreeTransportContract;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.CommandCreateTransportContract;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportContracts;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetOwnTransportContractsByUserType;
using TransportGlobal.Application.CQRSs.TransportContextCQRSs.QueryGetTransportContract;
using TransportGlobal.Application.DTOs.ResponseDTOs;
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
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.TransportContract));
        }

        [HttpGet]
        [Route("own/{page}/{size}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetOwn(int page, int size)
        {
            GetOwnTransportContractsQueryResponse queryResponse = await _mediator.Send(new GetOwnTransportContractsQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.TransportContracts));
        }

        [HttpPost]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Create([FromBody] CreateTransportContractCommandRequest request)
        {
            CreateTransportContractCommandResponse createTransportContractCommandResponse = await _mediator.Send(request);
            if (createTransportContractCommandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, createTransportContractCommandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, createTransportContractCommandResponse.Message));
        }

        [HttpPut]
        [Route("agree")]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Agree([FromBody] AgreeTransportContractCommandRequest request)
        {
            AgreeTransportContractCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
