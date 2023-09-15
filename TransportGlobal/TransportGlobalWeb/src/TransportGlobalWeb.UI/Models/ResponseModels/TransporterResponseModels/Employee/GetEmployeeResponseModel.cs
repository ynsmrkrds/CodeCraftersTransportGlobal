using TransportGlobalWeb.UI.Enums.TransporterContextEnums;

namespace TransportGlobalWeb.UI.Models.ResponseModels.TransporterResponseModels.Employee
{
    public class GetEmployeeResponseModel : BaseResponseModel
    {
        public int? VehicleID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public EmployeeTitle Title { get; set; }

        public bool IsDeleted { get; set; }

        public GetEmployeeResponseModel(int id, DateTime createdDate, int? vehicleID, string name, string surname, string email, EmployeeTitle title, bool isDeleted) : base(id, createdDate)
        {
            VehicleID = vehicleID;
            Name = name;
            Surname = surname;
            Email = email;
            Title = title;
            IsDeleted = isDeleted;
        }
    }
}
