using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportGlobal.API.Extensions.Attributes;
using TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandCreateReview;
using TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandDeleteReview;
using TransportGlobal.Application.CQRSs.ReviewContextCQRSs.QueryGetAllReviews;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Enums.UserContextEnums;

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
        [Route("?transportID={transportID}")]
        [Authority(UserType.Customer, UserType.Shipper)]
        public async Task<IActionResult> GetAll([FromQuery] int transportID)
        {
            GetAllReviewsQueryResponse queryResponse = await _mediator.Send(new GetAllReviewsQueryRequest(transportID));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Reviews));
        }

        [HttpPost]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Create([FromBody] CreateReviewCommandRequest request)
        {
            CreateReviewCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse));
        }

        [HttpPost]
        [Authority(UserType.Customer)]
        public async Task<IActionResult> Delete([FromBody] DeleteReviewCommandRequest request)
        {
            DeleteReviewCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
