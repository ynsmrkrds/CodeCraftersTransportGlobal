using TransportGlobalWeb.UI.Enums.TransporterContextEnums;

namespace TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Vehicle
{
    public class VehicleResponseModel : BaseResponseModel
    {
        public string IdentificationNumber { get; set; }

        public VehicleType Type { get; set; }

        public VehicleStatusType Status { get; set; }

        public bool IsDeleted { get; set; }

        public VehicleResponseModel(int id, DateTime createdDate, string identificationNumber, VehicleType type, VehicleStatusType status, bool isDeleted) : base(id, createdDate)
        {
            IdentificationNumber = identificationNumber;
            Type = type;
            Status = status;
            IsDeleted = isDeleted;
        }
    }
}
