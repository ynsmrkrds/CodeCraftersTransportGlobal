using MediatR;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllEmployees
{
    public class GetAllEmployeesQueryRequest : IRequest<GetAllEmployeesQueryResponse>
    {
        public PaginationModel Pagination { get; set; }

        public int? CompanyID { get; set; }

        public int? VehicleID { get; set; }

        public GetAllEmployeesQueryRequest(PaginationModel pagination, int? companyID = null, int? vehicleID = null)
        {
            Pagination = pagination;
            CompanyID = companyID;
            VehicleID = vehicleID;
        }
    }
}
