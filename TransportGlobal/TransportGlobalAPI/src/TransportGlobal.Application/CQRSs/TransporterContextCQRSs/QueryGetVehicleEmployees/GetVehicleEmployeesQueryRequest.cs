using MediatR;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetVehicleEmployees
{
    public class GetVehicleEmployeesQueryRequest : IRequest<GetVehicleEmployeesQueryResponse>
    {
        public int VehicleID { get; set; }

        public PaginationModel Pagination { get; set; }

        public GetVehicleEmployeesQueryRequest(int vehicleID, PaginationModel pagination)
        {
            VehicleID = vehicleID;
            Pagination = pagination;
        }
    }
}
