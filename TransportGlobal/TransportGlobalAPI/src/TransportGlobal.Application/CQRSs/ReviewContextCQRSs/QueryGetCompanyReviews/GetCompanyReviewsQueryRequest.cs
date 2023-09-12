using MediatR;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.ReviewContextCQRSs.QueryGetCompanyReviews
{
    public class GetCompanyReviewsQueryRequest : IRequest<GetCompanyReviewsQueryResponse>
    {
        public int CompanyID { get; set; }

        public PaginationModel Pagination { get; set; }

        public GetCompanyReviewsQueryRequest(int companyID, PaginationModel pagination)
        {
            CompanyID = companyID;
            Pagination = pagination;
        }
    }
}
