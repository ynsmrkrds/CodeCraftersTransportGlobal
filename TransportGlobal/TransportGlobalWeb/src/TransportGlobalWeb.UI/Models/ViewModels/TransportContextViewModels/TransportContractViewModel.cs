using TransportGlobalWeb.UI.Enums.TransportContextEnums;
using TransportGlobalWeb.UI.Models.ViewModels.TransporterContextViewModels;
using TransportGlobalWeb.UI.Models.ViewModels.UserContextViewModels;

namespace TransportGlobalWeb.UI.Models.ViewModels.TransportContextViewModels
{
    public class TransportContractViewModel : BaseViewModel
    {
        public UserViewModel User { get; set; }

        public CompanyViewModel Company { get; set; }

        public TransportRequestViewModel TransportRequest { get; set; }

        public VehicleViewModel Vehicle { get; set; }

        public double Price { get; set; }

        public TransportContractStatusType Status { get; set; }

        public TransportContractViewModel(int id, DateTime createdDate, bool isDeleted, UserViewModel user, CompanyViewModel company, TransportRequestViewModel transportRequest, VehicleViewModel vehicle, double price, TransportContractStatusType status) : base(id, createdDate, isDeleted)
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
