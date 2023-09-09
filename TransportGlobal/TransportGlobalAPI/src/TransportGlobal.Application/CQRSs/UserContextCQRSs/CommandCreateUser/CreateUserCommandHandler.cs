using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandCreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (_userRepository.IsExistsWithSameEmail(request.Email)) return Task.FromResult(new CreateUserCommandResponse(ResponseConstants.ExistsUserWithSameEmail));

            UserEntity userEntity = _mapper.Map<UserEntity>(request);
            userEntity.PasswordHash = EncryptionHelper.Encrypt(request.Password);
            _userRepository.Add(userEntity);

            int effectedRows = _userRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateUserCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateUserCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
