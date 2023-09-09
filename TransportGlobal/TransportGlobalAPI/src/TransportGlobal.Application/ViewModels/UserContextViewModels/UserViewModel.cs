using TransportGlobal.Domain.Enums.UserContextEnums;

namespace TransportGlobal.Application.ViewModels.UserContextViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public UserType Type { get; set; }

        public UserViewModel(int id, DateTime createdDate, string name, string surname, string email, UserType type) : base(id, createdDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Type = type;
        }
    }
}
