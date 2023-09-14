using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnEmployees
{
    public class GetOwnEmployeesQueryResponse : BaseQueryListResponseDTO<EmployeeViewModel>
    {
        public GetOwnEmployeesQueryResponse(IEnumerable<EmployeeViewModel> list, PaginationModel paginationModel) : base(list, paginationModel)
        {
        }
    }
}
