using TransportGlobalWeb.UI.Enums.TransportContextEnums;
using TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Company;
using TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Vehicle;
using TransportGlobalWeb.UI.Models.ResponseModels.TransportResponseModels.TransportRequest;
using TransportGlobalWeb.UI.Models.ResponseModels.UserResponseModels.User;

namespace TransportGlobalWeb.UI.Models.ResponseModels.TransportResponseModels.TransportContract
{
    public class GetTransportContractResponseModel : BaseResponseModel
    {
        public GetProfileResponseModel User { get; set; }

        public GetCompanyResponseModel Company { get; set; }

        public GetTransportRequestResponseModel TransportRequest { get; set; }

        public VehicleResponseModel Vehicle { get; set; }

        public double Price { get; set; }

        public TransportContractStatusType Status { get; set; }

        public GetTransportContractResponseModel(int id, DateTime createdDate, GetProfileResponseModel user, GetCompanyResponseModel company, GetTransportRequestResponseModel transportRequest, VehicleResponseModel vehicle, double price, TransportContractStatusType status) : base(id,createdDate)
        {
            User = user;
            Company = company;
            TransportRequest = transportRequest;
            Vehicle = vehicle;
            Price = price;
            Status = status;
        }
    }
}
