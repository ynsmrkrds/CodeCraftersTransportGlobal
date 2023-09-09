namespace TransportGlobal.Domain.Models
{
    public class TokenModel
    {
        public int UserID { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public TokenModel(int userID, string email, string name, string surname)
        {
            UserID = userID;
            Email = email;
            Name = name;
            Surname = surname;
        }
    }
}
