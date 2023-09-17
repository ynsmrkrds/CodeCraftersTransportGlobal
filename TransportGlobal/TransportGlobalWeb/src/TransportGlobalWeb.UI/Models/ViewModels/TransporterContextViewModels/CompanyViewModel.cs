namespace TransportGlobalWeb.UI.Models.ViewModels.TransporterContextViewModels
{
    public class CompanyViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public CompanyViewModel(int id, DateTime createdDate, bool isDeleted, string name, string address, string phoneNumber, string email) : base(id, createdDate, isDeleted)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
