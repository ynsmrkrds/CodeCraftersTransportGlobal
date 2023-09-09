using MediatR;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandUpdateUser
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public UpdateUserCommandRequest(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
