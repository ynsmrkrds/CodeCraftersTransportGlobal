using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandCreateEmployee;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandDeleteEmployee;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandUpdateEmployee;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllEmployees;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetEmployee;
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
        [Route("{page}/{size}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetAll(int page, int size)
        {
            GetAllEmployeesQueryResponse queryResponse = await _mediator.Send(new GetAllEmployeesQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Employees));
        }

        [HttpGet]
        [Route("{page}/{size}?companyID={companyID}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetAllByCompanyID(int page, int size, [FromQuery] int companyID)
        {
            GetAllEmployeesQueryResponse queryResponse = await _mediator.Send(new GetAllEmployeesQueryRequest(new PaginationModel(page, size), companyID: companyID));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Employees));
        }

        [HttpGet]
        [Route("{page}/{size}?vehicleID={vehicleID}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetAllByVehicleID(int page, int size, [FromQuery] int vehicleID)
        {
            GetAllEmployeesQueryResponse queryResponse = await _mediator.Send(new GetAllEmployeesQueryRequest(new PaginationModel(page, size), vehicleID: vehicleID));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Employees));
        }

        [HttpGet]
        [Route("{id}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> Get(int id)
        {
            GetEmployeeQueryResponse queryResponse = await _mediator.Send(new GetEmployeeQueryRequest(id));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Employee));
        }

        [HttpPost]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommandRequest request)
        {
            CreateEmployeeCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommandRequest request)
        {
            UpdateEmployeeCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpDelete]
        [Route("{id}")]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteEmployeeCommandResponse commandResponse = await _mediator.Send(new DeleteEmployeeCommandRequest(id));
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
