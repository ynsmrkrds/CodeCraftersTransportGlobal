using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.TransportContextEntities
{
    public class TransportEntity : BaseEntity
    {
        public int TransportRequestID { get; set; }

        public int VehicleID { get; set; }

        public TransportEntity(int transportRequestID, int vehicleID)
        {
            TransportRequestID = transportRequestID;
            VehicleID = vehicleID;
        }
    }
}
