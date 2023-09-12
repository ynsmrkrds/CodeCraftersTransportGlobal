using MediatR;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnVehicles
{
    public class GetOwnVehiclesQueryRequest : IRequest<GetOwnVehiclesQueryResponse>
    {
        public PaginationModel Pagination { get; set; }

        public GetOwnVehiclesQueryRequest(PaginationModel pagination)
        {
            Pagination = pagination;
        }
    }
}
