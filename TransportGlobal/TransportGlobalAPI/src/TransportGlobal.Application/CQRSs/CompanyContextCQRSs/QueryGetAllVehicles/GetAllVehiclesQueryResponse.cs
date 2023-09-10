
using TransportGlobal.Application.ViewModels.CompanyContextViewModels;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetAllVehicles
{
    public class GetAllVehiclesQueryResponse
    {
        public ICollection<VehicleViewModel> Vehicles { get; set; }

        public GetAllVehiclesQueryResponse(ICollection<VehicleViewModel> vehicles)
        {
            Vehicles = vehicles;
        }
    }
}
