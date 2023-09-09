using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandUpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdatePasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);

            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);
            if (userEntity.PasswordHash != EncryptionHelper.Encrypt(request.CurrentPassword)) return Task.FromResult(new UpdatePasswordCommandResponse(ResponseConstants.CurrentPasswordIncorrect));

            userEntity.PasswordHash = EncryptionHelper.Encrypt(request.NewPassword);
            _userRepository.Update(userEntity);

            int effectedRows = _userRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdatePasswordCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdatePasswordCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
