using System.ComponentModel.DataAnnotations.Schema;
using TransportGlobal.Domain.Entities.ReviewContextEntities;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Enums.TransportContextEnums;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.TransportContextEntities
{
    public class TransportContractEntity : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        public UserEntity? User { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }

        public CompanyEntity? Company { get; set; }

        [ForeignKey(nameof(TransportRequest))]
        public int TransportRequestID { get; set; }

        public TransportRequestEntity? TransportRequest { get; set; }

        [ForeignKey(nameof(Vehicle))]
        public int VehicleID { get; set; }

        public VehicleEntity? Vehicle { get; set; }

        public double Price { get; set; }

        public TransportContractStatusType Status { get; set; }

        public ReviewEntity? Review { get; set; }

        public TransportContractEntity(int userID, int companyID, int transportRequestID, int vehicleID, double price, TransportContractStatusType status)
        {
            UserID = userID;
            CompanyID = companyID;
            TransportRequestID = transportRequestID;
            VehicleID = vehicleID;
            Price = price;
            Status = status;
        }
    }
}
