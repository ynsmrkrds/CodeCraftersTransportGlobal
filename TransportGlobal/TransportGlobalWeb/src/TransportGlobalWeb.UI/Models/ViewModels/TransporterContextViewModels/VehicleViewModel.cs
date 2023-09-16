using TransportGlobalWeb.UI.Enums.TransporterContextEnums;

namespace TransportGlobalWeb.UI.Models.ViewModels.TransporterContextViewModels
{
    public class VehicleViewModel : BaseViewModel
    {
        public string IdentificationNumber { get; set; }

        public VehicleType Type { get; set; }

        public VehicleStatusType Status { get; set; }

        public VehicleViewModel(int id, DateTime createdDate, bool isDeleted, string identificationNumber, VehicleType type, VehicleStatusType status) : base(id, createdDate, isDeleted)
        {
            IdentificationNumber = identificationNumber;
            Type = type;
            Status = status;
        }
    }
}
