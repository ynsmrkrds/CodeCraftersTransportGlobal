using MediatR;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnEmployees
{
    public class GetOwnEmployeesQueryRequest : IRequest<GetOwnEmployeesQueryResponse>
    {
        public PaginationModel Pagination { get; set; }

        public GetOwnEmployeesQueryRequest(PaginationModel pagination)
        {
            Pagination = pagination;
        }
    }
}
