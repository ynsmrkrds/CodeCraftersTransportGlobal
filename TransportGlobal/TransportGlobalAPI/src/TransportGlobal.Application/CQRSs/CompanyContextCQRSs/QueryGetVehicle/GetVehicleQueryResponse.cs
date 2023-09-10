using TransportGlobal.Application.ViewModels.CompanyContextViewModels;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.QueryGetVehicle
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
