using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandCreateCompany;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandDeleteCompany;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandUpdateCompany;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllCompanies;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetCompany;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.API.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{page}/{size}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetAll(int page, int size)
        {
            GetAllCompaniesQueryResponse queryResponse = await _mediator.Send(new GetAllCompaniesQueryRequest(new PaginationModel(page, size)));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Companies));
        }

        [HttpGet]
        [Route("{id}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> Get(int id)
        {
            GetCompanyQueryResponse queryResponse = await _mediator.Send(new GetCompanyQueryRequest(id));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Company));
        }

        [HttpPost]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommandRequest request)
        {
            CreateCompanyCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommandRequest request)
        {
            UpdateCompanyCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpDelete]
        [Route("{id}")]
        [Authority(UserType.Shipper)]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteCompanyCommandResponse commandResponse = await _mediator.Send(new DeleteCompanyCommandRequest(id));
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
