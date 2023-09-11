using TransportGlobal.Application.ViewModels.TransporterContextViewModels;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.QueryGetVehicle
{
    public class GetVehicleQueryResponse
    {
        public VehicleViewModel Vehicle { get; set; }

        public GetVehicleQueryResponse(VehicleViewModel vehicle)
        {
            Vehicle = vehicle;
        }
    }
}
