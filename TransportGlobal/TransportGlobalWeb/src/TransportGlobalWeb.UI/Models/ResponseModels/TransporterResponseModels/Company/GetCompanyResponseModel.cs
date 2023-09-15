namespace TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Company
{
    public class GetCompanyResponseModel : BaseResponseModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public GetCompanyResponseModel(int id, DateTime createdDate, string name, string address, string phoneNumber, string email, bool isDeleted) : base(id, createdDate)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            IsDeleted = isDeleted;
        }
    }
}
