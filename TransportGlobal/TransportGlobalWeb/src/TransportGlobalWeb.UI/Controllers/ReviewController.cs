using Microsoft.AspNetCore.Mvc;
using TransportGlobalWeb.UI.ApiClients.ReviewContextApiClients;
using TransportGlobalWeb.UI.Models.RequestModels.ReviewContextRequestModels.Review;
using TransportGlobalWeb.UI.Models.ResponseModels;
using TransportGlobalWeb.UI.Models.ResponseModels.ReviewResponseModels.Review;

namespace TransportGlobalWeb.UI.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly ReviewClient _reviewClient;

        public ReviewController(ReviewClient reviewClient)
        {
            _reviewClient = reviewClient;
        }

        public IActionResult GetCompanyReviews(int id, int page = 0)
        {
            ApiResponseModel<GetCompanyReviewsResponseModel>? apiResponse = _reviewClient.GetCompanyReviews(id, page);

            IActionResult onData()
            {
                return View(apiResponse!.Data!);
            }

            ViewData["Page"] = page;
            ViewData["CompanyID"] = id;

            return CreateActionResult(apiResponse, onData);
        }

        public IActionResult CreateReview(int transportContractID)
        {
            ViewData["TransportContractID"] = transportContractID;
            return View();
        }

        [HttpPost]
        public IActionResult CreateReview(CreateReviewRequestModel createReviewRequestModel)
        {
            ApiResponseModel<NonDataResponseModel>? apiResponse = _reviewClient.CreateReview(createReviewRequestModel);

            ViewData["TransportContractID"] = createReviewRequestModel.TransportContractID;

            return CreateActionResult(apiResponse, null);
        }
    }
}
