using TransportGlobalWeb.UI.Enums.TransporterContextEnums;

namespace TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Vehicle
{
    public class CreateVehicleRequestModel
    {
        public string IdentificationNumber { get; set; } = string.Empty;

        public VehicleType Type { get; set; }
    }
}
