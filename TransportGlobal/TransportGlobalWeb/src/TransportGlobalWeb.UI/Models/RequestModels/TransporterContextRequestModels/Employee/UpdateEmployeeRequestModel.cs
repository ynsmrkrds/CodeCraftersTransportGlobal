using TransportGlobalWeb.UI.Enums.TransporterContextEnums;

namespace TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Employee
{
    public class UpdateEmployeeRequestModel
    {
        public int ID { get; set; }

        public int? VehicleID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public EmployeeTitle Title { get; set; }
    }
}
