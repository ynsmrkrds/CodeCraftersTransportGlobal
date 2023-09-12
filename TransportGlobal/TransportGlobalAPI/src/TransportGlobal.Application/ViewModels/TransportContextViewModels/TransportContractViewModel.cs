using TransportGlobal.Application.ViewModels.TransporterContextViewModels;
using TransportGlobal.Application.ViewModels.UserContextViewModels;

namespace TransportGlobal.Application.ViewModels.TransportContextViewModels
{
    public class TransportContractViewModel : BaseViewModel
    {
        public UserViewModel User { get; set; }

        public CompanyViewModel Company { get; set; }

        public TransportRequestViewModel TransportRequest { get; set; }

        public VehicleViewModel Vehicle { get; set; }

        public double Price { get; set; }

        public TransportContractViewModel(int id, DateTime createdDate, bool isDeleted, UserViewModel user, CompanyViewModel company, TransportRequestViewModel transportRequest, VehicleViewModel vehicle, double price) : base(id, createdDate, isDeleted)
        {
            User = user;
            Company = company;
            TransportRequest = transportRequest;
            Vehicle = vehicle;
            Price = price;
        }
    }
}
