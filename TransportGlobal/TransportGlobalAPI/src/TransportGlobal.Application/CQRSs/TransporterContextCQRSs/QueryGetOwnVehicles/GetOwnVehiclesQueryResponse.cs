using TransportGlobal.Application.DTOs.CQRSDTOs;
using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Domain.Models;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnVehicles
{
    public class GetOwnVehiclesQueryResponse : BaseQueryListResponseDTO<VehicleViewModel>
    {
        public GetOwnVehiclesQueryResponse(IEnumerable<VehicleViewModel> list, PaginationModel paginationModel) : base(list, paginationModel)
        {
        }
    }
}
