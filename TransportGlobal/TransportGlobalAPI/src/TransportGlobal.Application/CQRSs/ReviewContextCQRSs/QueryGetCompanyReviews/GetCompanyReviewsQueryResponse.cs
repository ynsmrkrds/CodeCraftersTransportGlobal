using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Application.ViewModels.ReviewContextViewModels;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.QueryGetCompanyReviews
{
    public class GetCompanyReviewsQueryResponse : BaseQueryListResponseDTO<ReviewViewModel>
    {
        public GetCompanyReviewsQueryResponse(IEnumerable<ReviewViewModel> list, PaginationModel paginationModel) : base(list, paginationModel)
        {
        }
    }
}
