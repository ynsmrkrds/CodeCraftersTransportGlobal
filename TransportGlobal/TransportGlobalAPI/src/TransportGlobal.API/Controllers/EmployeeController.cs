using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateEmployee;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandDeleteEmployee;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateEmployee;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetEmployee;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnEmployees;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetVehicleEmployees;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.API.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Get(int id)
        {
            GetEmployeeQueryResponse queryResponse = await _mediator.Send(new GetEmployeeQueryRequest(id));
            return CreateActionResult(queryResponse.Employee);
        }

        [HttpGet]
        [Route("own/{page}/{size}")]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> GetOwnEmployees(int page, int size)
        {
            GetOwnEmployeesQueryResponse queryResponse = await _mediator.Send(new GetOwnEmployeesQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(queryResponse);
        }

        [HttpGet]
        [Route("vehicle/{vehicleID}/{page}/{size}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetVehicleEmployees(int vehicleID, int page, int size)
        {
            GetVehicleEmployeesQueryResponse queryResponse = await _mediator.Send(new GetVehicleEmployeesQueryRequest(vehicleID, new PaginationModel(page, size)));
            return CreateActionResult(queryResponse);
        }

        [HttpPost]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommandRequest request)
        {
            CreateEmployeeCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }

        [HttpPut]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommandRequest request)
        {
            UpdateEmployeeCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteEmployeeCommandResponse commandResponse = await _mediator.Send(new DeleteEmployeeCommandRequest(id));
            return CreateActionResult(commandResponse.Response);
        }
    }
}
