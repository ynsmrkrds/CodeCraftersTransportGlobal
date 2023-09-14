namespace TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Company
{
    public class GetCompanyResponseModel : BaseResponseModel
    {
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public GetCompanyResponseModel(int id, DateTime createdDate, string name, string address, string phoneNumber, string email)
        {
            ID = id;
            CreatedDate = createdDate;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
