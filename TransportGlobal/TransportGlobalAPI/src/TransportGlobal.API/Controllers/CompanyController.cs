using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateCompany;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandDeleteCompany;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandUpdateCompany;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetCompany;
using TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnCompany;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;

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
        [Route("{id}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> Get(int id)
        {
            GetCompanyQueryResponse queryResponse = await _mediator.Send(new GetCompanyQueryRequest(id));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Company));
        }

        [HttpGet]
        [Route("own")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetOwnCompany()
        {
            GetOwnCompanyQueryResponse queryResponse = await _mediator.Send(new GetOwnCompanyQueryRequest());
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
