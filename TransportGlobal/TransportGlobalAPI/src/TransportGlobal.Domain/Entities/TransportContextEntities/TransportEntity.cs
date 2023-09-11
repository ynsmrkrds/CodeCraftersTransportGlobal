using System.ComponentModel.DataAnnotations.Schema;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.TransportContextEntities
{
    public class TransportEntity : BaseEntity
    {
        [ForeignKey(nameof(TransportRequest))]
        public int TransportRequestID { get; set; }

        public TransportRequestEntity? TransportRequest { get; set; }

        public int VehicleID { get; set; }

        public double Price { get; set; }

        public TransportEntity(int transportRequestID, int vehicleID, double price)
        {
            TransportRequestID = transportRequestID;
            VehicleID = vehicleID;
            Price = price;
        }
    }
}
