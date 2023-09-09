using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandUpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            string token = TokenHelper.Instance().GetTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            int userID = TokenHelper.Instance().DecodeToken(token).UserID;

            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);
            _mapper.Map(request, userEntity);
            _userRepository.Update(userEntity);

            int effectedRows = _userRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdateUserCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdateUserCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
