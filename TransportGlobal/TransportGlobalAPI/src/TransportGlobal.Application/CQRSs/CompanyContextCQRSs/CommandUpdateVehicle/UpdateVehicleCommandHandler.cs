using AutoMapper;
using MediatR;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandCreateVehicle;
using TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandDeleteVehicle;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandUpdateVehicle
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommandRequest, UpdateVehicleCommandResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, IUserRepository userRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UpdateVehicleCommandResponse> Handle(UpdateVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            VehicleEntity vehicleEntity = _vehicleRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundVehicle);
            if (vehicleEntity.CompanyID != userEntity.Company?.ID) return Task.FromResult(new UpdateVehicleCommandResponse(ResponseConstants.NotVehicleOwner));

            if (vehicleEntity.IdentificationNumber != request.IdentificationNumber && _vehicleRepository.IsExistsWithSameIdentificationNumber(request.IdentificationNumber)) return Task.FromResult(new UpdateVehicleCommandResponse(ResponseConstants.ExistsVehicleWithSameIdentificationNumber));

            _mapper.Map(request, vehicleEntity);
            _vehicleRepository.Update(vehicleEntity);

            int effectedRows = _vehicleRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdateVehicleCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdateVehicleCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
