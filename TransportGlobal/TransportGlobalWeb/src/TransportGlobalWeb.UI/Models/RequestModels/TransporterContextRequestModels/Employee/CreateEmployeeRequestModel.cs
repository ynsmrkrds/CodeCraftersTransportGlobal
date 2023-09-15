using TransportGlobalWeb.UI.Enums.TransporterContextEnums;

namespace TransportGlobalWeb.UI.Models.RequestModels.TransporterContextRequestModels.Employee
{
    public class CreateEmployeeRequestModel
    {
        private int? vehicleID;

        public int? VehicleID
        {
            get
            {
                return vehicleID;
            }
            set
            {
                if (value == 0)
                {
                    vehicleID = null;
                }
                else
                {
                    vehicleID = value;
                }
            }
        }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public EmployeeTitle Title { get; set; }
    }
}
