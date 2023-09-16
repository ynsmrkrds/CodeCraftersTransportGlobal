namespace TransportGlobalWeb.UI.Models.RequestModels.TransportContextRequestModels.TransportContract
{
    public class CreateTransportContractRequestModel
    {
        public int TransportRequestID { get; set; }

        public int VehicleID { get; set; }

        public double Price { get; set; }
    }
}
