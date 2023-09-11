using TransportGlobal.Application.ViewModels.TransporterContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetOwnVehicles
{
    public class GetOwnVehiclesQueryResponse
    {
        public ICollection<VehicleViewModel> Vehicles { get; set; }

        public GetOwnVehiclesQueryResponse(ICollection<VehicleViewModel> vehicles)
        {
            Vehicles = vehicles;
        }
    }
}
