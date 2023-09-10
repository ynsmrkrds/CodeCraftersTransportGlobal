using MediatR;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllVehicles
{
    public class GetAllVehiclesQueryRequest : IRequest<GetAllVehiclesQueryResponse>
    {
        public PaginationModel Pagination { get; set; }

        public int? CompanyID { get; set; }

        public GetAllVehiclesQueryRequest(PaginationModel pagination, int? companyID = null)
        {
            Pagination = pagination;
            CompanyID = companyID;
        }
    }
}
