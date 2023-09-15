using TransportGlobalWeb.UI.Enums.UserContextEnums;

namespace TransportGlobalWeb.UI.Models.ResponseModels.UserResponseModels.User
{
    public class GetProfileResponseModel : BaseResponseModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public UserType Type { get; set; }

        public GetProfileResponseModel(int id, DateTime createdDate, string name, string surname, string email, UserType type) : base(id, createdDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Type = type;
        }
    }
}
