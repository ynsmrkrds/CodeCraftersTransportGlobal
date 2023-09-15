using TransportGlobalWeb.UI.Enums.TransporterContextEnums;

namespace TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Vehicle
{
    public class UpdateVehicleRequestModel
    {
        public int ID { get; set; }

        public VehicleStatusType Status { get; set; }
    }
}
