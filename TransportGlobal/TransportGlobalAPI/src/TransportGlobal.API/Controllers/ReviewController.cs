using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandCreateReview;
using TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandDeleteReview;
using TransportGlobal.Application.CQRSs.ReviewContextCQRSs.QueryGetCompanyReviews;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.API.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("company/{companyID}/{page}/{size}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetCompanyReview(int companyID, int page, int size)
        {
            GetCompanyReviewsQueryResponse queryResponse = await _mediator.Send(new GetCompanyReviewsQueryRequest(companyID, new PaginationModel(page, size)));
            return CreateActionResult(queryResponse);
        }

        [HttpPost]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Create([FromBody] CreateReviewCommandRequest request)
        {
            CreateReviewCommandResponse commandResponse = await _mediator.Send(request);
            return CreateActionResult(commandResponse.Response);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteReviewCommandResponse commandResponse = await _mediator.Send(new DeleteReviewCommandRequest(id));
            return CreateActionResult(commandResponse.Response);
        }
    }
}
