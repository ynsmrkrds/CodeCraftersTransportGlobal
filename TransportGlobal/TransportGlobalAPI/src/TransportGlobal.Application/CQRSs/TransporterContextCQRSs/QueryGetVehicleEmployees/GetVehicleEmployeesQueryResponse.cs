using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetVehicleEmployees
{
    public class GetVehicleEmployeesQueryResponse : BaseQueryListResponseDTO<EmployeeViewModel>
    {
        public GetVehicleEmployeesQueryResponse(IEnumerable<EmployeeViewModel> list, PaginationModel paginationModel) : base(list, paginationModel)
        {
        }
    }
}
