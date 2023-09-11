using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.TransporterContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.TransporterContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.TransporterContextCQRSs.CommandCreateVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommandRequest, CreateVehicleCommandResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository, IUserRepository userRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<CreateVehicleCommandResponse> Handle(CreateVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            if (_userRepository.HasCompany(userID) == false) return Task.FromResult(new CreateVehicleCommandResponse(ResponseConstants.UserHasNotCompany));

            if (_vehicleRepository.IsExistsWithSameIdentificationNumber(request.IdentificationNumber)) return Task.FromResult(new CreateVehicleCommandResponse(ResponseConstants.ExistsVehicleWithSameIdentificationNumber));

            VehicleEntity vehicleEntity = _mapper.Map<CreateVehicleCommandRequest, VehicleEntity>(request);
            vehicleEntity.CompanyID = userEntity.ActiveCompany!.ID;

            _vehicleRepository.Add(vehicleEntity);

            int effectedRows = _vehicleRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateVehicleCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateVehicleCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
