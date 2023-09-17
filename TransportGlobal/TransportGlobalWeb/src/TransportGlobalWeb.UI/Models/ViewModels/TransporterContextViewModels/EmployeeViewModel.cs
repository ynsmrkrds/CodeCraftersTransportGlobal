using System.ComponentModel.DataAnnotations;
using TransportGlobalWeb.UI.Enums.TransporterContextEnums;

namespace TransportGlobalWeb.UI.Models.ViewModels.TransporterContextViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public int? VehicleID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }

        public string Email { get; set; }

        public EmployeeTitle Title { get; set; }

        public EmployeeViewModel(int id, DateTime createdDate, bool isDeleted, int? vehicleID, string name, string surname, string email, EmployeeTitle title) : base(id, createdDate, isDeleted)
        {
            VehicleID = vehicleID;
            Name = name;
            Surname = surname;
            Email = email;
            Title = title;
        }
    }
}
