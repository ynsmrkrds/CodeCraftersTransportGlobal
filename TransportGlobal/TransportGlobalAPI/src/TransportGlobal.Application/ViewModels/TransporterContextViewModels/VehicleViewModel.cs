using TransportGlobal.Domain.Enums.TransporterContextEnums;

namespace TransportGlobal.Application.ViewModels.TransporterContextViewModels
{
    public class VehicleViewModel : BaseViewModel
    {
        public string IdentificationNumber { get; set; }

        public VehicleType Type { get; set; }

        public VehicleStatusType Status { get; set; }

        public bool IsDeleted { get; set; }

        public VehicleViewModel(int id, DateTime createdDate, string identificationNumber, VehicleType type, VehicleStatusType status, bool isDeleted) : base(id, createdDate)
        {
            IdentificationNumber = identificationNumber;
            Type = type;
            Status = status;
            IsDeleted = isDeleted;
        }
    }
}
