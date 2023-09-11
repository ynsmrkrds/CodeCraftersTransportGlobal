using System.ComponentModel.DataAnnotations;
using TransportGlobal.Domain.Enums.TransporterContextEnums;

namespace TransportGlobal.Application.ViewModels.TransporterContextViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public int? VehicleID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }

        public EmployeeTitle Title { get; set; }

        public bool IsDeleted { get; set; }

        public EmployeeViewModel(int id, DateTime createdDate, int? vehicleID, string name, string surname, string email, EmployeeTitle title, bool isDeleted) : base(id, createdDate)
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
