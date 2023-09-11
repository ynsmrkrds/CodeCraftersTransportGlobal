﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateVehicle;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandDeleteVehicle;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateVehicle;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnVehicles;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetVehicle;
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
        [Route("{id}")]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Get(int id)
        {
            GetVehicleQueryResponse queryResponse = await _mediator.Send(new GetVehicleQueryRequest(id));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Vehicle));
        }

        [HttpGet]
        [Route("own/{page}/{size}")]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> GetOwnVehicles(int page, int size)
        {
            GetOwnVehiclesQueryResponse queryResponse = await _mediator.Send(new GetOwnVehiclesQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Vehicles));
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