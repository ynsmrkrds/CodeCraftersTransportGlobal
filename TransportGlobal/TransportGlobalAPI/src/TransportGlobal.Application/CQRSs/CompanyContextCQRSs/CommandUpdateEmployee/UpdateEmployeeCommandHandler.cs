using AutoMapper;
using MediatR;
using TransportGlobal.Application.Helpers;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Entities.CompanyContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;
using TransportGlobal.Domain.Exceptions;
using TransportGlobal.Domain.Repositories.CompanyContextRepositories;
using TransportGlobal.Domain.Repositories.UserContextRepositories;

namespace TransportGlobal.Application.CQRSs.CompanyContextCQRSs.CommandUpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUserRepository userRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            int userID = TokenHelper.Instance().DecodeTokenInRequest()?.UserID ?? throw new ClientSideException(ExceptionConstants.TokenError);
            UserEntity userEntity = _userRepository.GetByID(userID) ?? throw new ClientSideException(ExceptionConstants.NotFoundUser);

            EmployeeEntity employeeEntity = _employeeRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundEmployee);
            if (employeeEntity.CompanyID != userEntity.Company?.ID) return Task.FromResult(new UpdateEmployeeCommandResponse(ResponseConstants.NotVehicleOwner));

            if (employeeEntity.Email != request.Email && _userRepository.IsExistsWithSameEmail(request.Email)) return Task.FromResult(new UpdateEmployeeCommandResponse(ResponseConstants.ExistsEmployeeWithSameEmail));

            _mapper.Map(request, employeeEntity);
            _employeeRepository.Update(employeeEntity);

            int effectedRows = _employeeRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdateEmployeeCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdateEmployeeCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
