using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandCreateVehicle;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandDeleteVehicle;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandUpdateVehicle;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllVehicles;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetVehicle;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.API.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{page}/{size}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetAll(int page, int size)
        {
            GetAllVehiclesQueryResponse queryResponse = await _mediator.Send(new GetAllVehiclesQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Vehicles));
        }

        [HttpGet]
        [Route("{page}/{size}?companyID={companyID}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetAllByCompanyID(int page, int size, [FromQuery] int companyID)
        {
            GetAllVehiclesQueryResponse queryResponse = await _mediator.Send(new GetAllVehiclesQueryRequest(new PaginationModel(page, size), companyID));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Vehicles));
        }

        [HttpGet]
        [Route("{id}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> Get(int id)
        {
            GetVehicleQueryResponse queryResponse = await _mediator.Send(new GetVehicleQueryRequest(id));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Vehicle));
        }

        [HttpPost]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Create([FromBody] CreateVehicleCommandRequest request)
        {
            CreateVehicleCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Update([FromBody] UpdateVehicleCommandRequest request)
        {
            UpdateVehicleCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpDelete]
        [Route("{id}")]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteVehicleCommandResponse commandResponse = await _mediator.Send(new DeleteVehicleCommandRequest(id));
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
