using MediatR;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllCompanies
{
    public class GetAllCompaniesQueryRequest : IRequest<GetAllCompaniesQueryResponse>
    {
        public PaginationModel Pagination { get; set; }

        public GetAllCompaniesQueryRequest(PaginationModel pagination)
        {
            Pagination = pagination;
        }
    }
}
