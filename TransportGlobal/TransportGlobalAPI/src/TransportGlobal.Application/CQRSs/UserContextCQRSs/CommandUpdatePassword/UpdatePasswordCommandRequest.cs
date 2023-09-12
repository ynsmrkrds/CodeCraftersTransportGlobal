using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandUpdatePassword
{
    public class UpdatePasswordCommandRequest : IRequest<UpdatePasswordCommandResponse>
    {
        public string CurrentPassword { get; set; }

        [StringLength(50, MinimumLength = 6)]
        public string NewPassword { get; set; }

        public UpdatePasswordCommandRequest(string currentPassword, string newPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }
    }
}
